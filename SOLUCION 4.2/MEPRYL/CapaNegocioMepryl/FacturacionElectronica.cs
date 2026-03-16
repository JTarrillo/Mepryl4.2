using System;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    /// <summary>
    /// Capa de negocio para Facturación Electrónica AFIP.
    /// Orquesta: datos de la consulta → llamada WSAA/WSFE → persistencia del CAE.
    ///
    /// TIPOS DE COMPROBANTE más usados:
    ///   1  = Factura A  (emisor RI, receptor RI o RE — requiere CUIT receptor)
    ///   6  = Factura B  (emisor RI, receptor CF o Monotributista)
    ///   11 = Factura C  (emisor Monotributista — sin discriminar IVA)
    ///
    /// ALÍCUOTAS IVA (campo Id para WSFE):
    ///   3  = 0%
    ///   4  = 10.5%
    ///   5  = 21%
    /// </summary>
    public class FacturacionElectronica
    {
        private readonly CapaDatosMepryl.FacturacionElectronica _datos;

        public FacturacionElectronica()
        {
            _datos = new CapaDatosMepryl.FacturacionElectronica();
        }

        // ─────────────────────────────────────────────────────────────────────
        // CONFIGURACIÓN
        // ─────────────────────────────────────────────────────────────────────

        public DataTable ObtenerConfiguracion()
        {
            return _datos.ObtenerConfiguracion();
        }

        public Entidades.Resultado GuardarConfiguracion(
            string cuitEmisor, string razonSocial, string condicionIVA,
            int puntoVenta, char ambiente,
            string rutaCertificado, string passwordCert, string domicilio)
        {
            return _datos.GuardarConfiguracion(
                cuitEmisor, razonSocial, condicionIVA,
                puntoVenta, ambiente,
                rutaCertificado, passwordCert, domicilio);
        }

        // ─────────────────────────────────────────────────────────────────────
        // EMISIÓN DE COMPROBANTE — método principal
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Proceso completo de emisión de una factura electrónica:
        ///   1. Lee la configuración AFIP.
        ///   2. Obtiene el próximo nro de comprobante (local + verificación AFIP).
        ///   3. Inserta el comprobante en estado "Pendiente".
        ///   4. Llama a AFIP (WSAA + WSFE).
        ///   5. Guarda el CAE o marca como rechazado.
        /// </summary>
        /// <param name="idTurno">ID del turno a facturar</param>
        /// <param name="tipoComprobante">1=FactA, 6=FactB, 11=FactC</param>
        /// <param name="cuitReceptor">CUIT del paciente/empresa. "0" para consumidor final.</param>
        /// <param name="nombreReceptor">Razón social o nombre del receptor</param>
        /// <param name="condicionIVAReceptor">CF=Cons.Final, RI=Resp.Inscr., MO=Monotrib.</param>
        /// <param name="importeTotal">Total del comprobante en pesos</param>
        /// <param name="alicuotaIVA">Porcentaje de IVA: 21, 10.5 o 0</param>
        /// <param name="concepto">1=Productos, 2=Servicios (prestaciones médicas), 3=Ambos</param>
        public Entidades.Resultado EmitirFactura(
            Guid    idTurno,
            int     tipoComprobante,
            string  cuitReceptor,
            string  nombreReceptor,
            string  condicionIVAReceptor,
            decimal importeTotal,
            decimal alicuotaIVA = 21m,
            int     concepto    = 2)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // 1. Cargar configuración
                DataTable config = _datos.ObtenerConfiguracion();
                if (config.Rows.Count == 0)
                {
                    resultado.Modo    = -1;
                    resultado.Mensaje = "No hay configuración AFIP cargada. Configure CUIT, certificado y punto de venta primero.";
                    return resultado;
                }

                DataRow cfg       = config.Rows[0];
                string  cuitEmisor  = cfg["cuitEmisor"].ToString();
                int     puntoVenta  = Convert.ToInt32(cfg["puntoVenta"]);
                char    ambiente    = cfg["ambiente"].ToString()[0];
                string  rutaCert    = cfg["rutaCertificado"].ToString();
                string  passCert    = cfg["passwordCert"].ToString();

                // 2. Calcular importe IVA
                decimal coefIVA  = alicuotaIVA / 100m;
                decimal impNeto  = tipoComprobante == 11
                    ? importeTotal              // Factura C: no discrimina IVA
                    : Math.Round(importeTotal / (1 + coefIVA), 2);
                decimal impIVA   = tipoComprobante == 11
                    ? 0m
                    : Math.Round(importeTotal - impNeto, 2);

                // Alícuota IVA para WSFE (ID interno AFIP)
                int alicuotaId = alicuotaIVA == 21m ? 5
                               : alicuotaIVA == 10.5m ? 4
                               : 3; // 0%

                // 3. Obtener próximo nro de comprobante
                long ultimoLocal = _datos.ObtenerUltimoNroComprobante(tipoComprobante, puntoVenta);

                // Verificar contra AFIP (evita desfase)
                var wsAfip     = new ServiciosAfip(ambiente, rutaCert, passCert);
                long ultimoAfip = wsAfip.ConsultarUltimoNroAutorizado(cuitEmisor, puntoVenta, tipoComprobante);

                long proximoNro = Math.Max(ultimoLocal, ultimoAfip) + 1;

                // 4. Insertar en BD como "Pendiente"
                Guid idFactura = _datos.InsertarComprobante(
                    idTurno, tipoComprobante, puntoVenta, proximoNro,
                    cuitReceptor, nombreReceptor, condicionIVAReceptor,
                    impNeto, impIVA, importeTotal,
                    concepto, "");

                // 5. Llamar a WSFE
                RespuestaCAE respuesta = wsAfip.AutorizarComprobante(
                    cuitEmisor, puntoVenta, tipoComprobante,
                    proximoNro, concepto,
                    cuitReceptor, importeTotal, impIVA, alicuotaId);

                // 6. Guardar resultado
                if (respuesta.Autorizado && !string.IsNullOrEmpty(respuesta.CAE))
                {
                    _datos.ActualizarConCAE(idFactura, respuesta.CAE, respuesta.FechaVencimientoCAE);
                    resultado.Modo      = 1;
                    resultado.Mensaje   = $"Factura autorizada. CAE: {respuesta.CAE} — Vence: {respuesta.FechaVencimientoCAE:dd/MM/yyyy}";
                    resultado.IdRetorno = idFactura;
                }
                else
                {
                    string motivo = string.IsNullOrEmpty(respuesta.Errores)
                        ? respuesta.Observaciones
                        : respuesta.Errores;
                    _datos.MarcarComoRechazado(idFactura, motivo);
                    resultado.Modo    = 0;
                    resultado.Mensaje = $"AFIP rechazó el comprobante: {motivo}";
                }
            }
            catch (Exception ex)
            {
                resultado.Modo    = -1;
                resultado.Mensaje = "Error en el proceso de facturación electrónica: " + ex.Message;
            }
            return resultado;
        }

        // ─────────────────────────────────────────────────────────────────────
        // CONSULTAS DE COMPROBANTES
        // ─────────────────────────────────────────────────────────────────────

        public DataTable ObtenerComprobantesPorTurno(Guid idTurno)
        {
            return _datos.ObtenerComprobantesPorTurno(idTurno);
        }

        public DataTable ListarComprobantesDia()
        {
            return _datos.ListarComprobantesDia();
        }

        public DataTable ListarComprobantesEntreFechas(DateTime desde, DateTime hasta)
        {
            return _datos.ListarComprobantesEntreFechas(desde, hasta);
        }

        // ─────────────────────────────────────────────────────────────────────
        // HELPERS PARA LA PRESENTACIÓN
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Determina el tipo de comprobante según la condición frente al IVA del receptor.
        /// Regla general para Responsable Inscripto:
        ///   Receptor RI  → Factura A (tipo 1)
        ///   Receptor CF/MO → Factura B (tipo 6)
        /// </summary>
        public int DeterminarTipoComprobante(string condicionIVAEmisor, string condicionIVAReceptor)
        {
            if (condicionIVAEmisor == "MO") // Monotributista siempre Factura C
                return 11;

            if (condicionIVAReceptor == "RI" || condicionIVAReceptor == "RE")
                return 1; // Factura A

            return 6; // Factura B
        }

        /// <summary>
        /// Verifica la conexión con AFIP (útil para diagnóstico desde la UI).
        /// </summary>
        public Entidades.Resultado VerificarConexionAfip()
        {
            var resultado = new Entidades.Resultado();
            try
            {
                DataTable config = _datos.ObtenerConfiguracion();
                if (config.Rows.Count == 0)
                {
                    resultado.Modo    = -1;
                    resultado.Mensaje = "Sin configuración AFIP.";
                    return resultado;
                }

                DataRow cfg    = config.Rows[0];
                char ambiente  = cfg["ambiente"].ToString()[0];
                string rutaCert = cfg["rutaCertificado"].ToString();
                string passCert = cfg["passwordCert"].ToString();

                var ws     = new ServiciosAfip(ambiente, rutaCert, passCert);
                var ticket = ws.ObtenerTicketAcceso();

                resultado.Modo    = 1;
                resultado.Mensaje = $"Conexión OK. Token válido hasta: {ticket.Expiracion:dd/MM/yyyy HH:mm}";
            }
            catch (Exception ex)
            {
                resultado.Modo    = -1;
                resultado.Mensaje = "Error de conexión AFIP: " + ex.Message;
            }
            return resultado;
        }
    }
}
