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
            // LOG: Ver valor recibido en capa de negocio
            System.Diagnostics.Debug.WriteLine($"[NEGOCIO_GUARDAR] condicionIVA recibido: {condicionIVA}");

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
        /// <param name="idTurno">ID del turno a facturar. Guid.Empty para emisión manual sin turno.</param>
        /// <param name="tipoComprobante">1=FactA, 6=FactB, 11=FactC</param>
        /// <param name="cuitReceptor">CUIT del paciente/empresa. "0" para consumidor final.</param>
        /// <param name="nombreReceptor">Razón social o nombre del receptor</param>
        /// <param name="condicionIVAReceptor">CF=Cons.Final, RI=Resp.Inscr., MO=Monotrib.</param>
        /// <param name="importeTotal">Total del comprobante en pesos</param>
        /// <param name="alicuotaIVA">Porcentaje de IVA: 21, 10.5 o 0</param>
        /// <param name="concepto">1=Productos, 2=Servicios (prestaciones médicas), 3=Ambos</param>
        /// <param name="tipoTF">FACTURA C | NOTA DE CREDITO C | NOTA DE DEBITO C</param>
        /// <param name="nroAsociado">Para NC/ND: nro de la factura original. 0 si no aplica.</param>
        /// <param name="medioPago">EFECTIVO | TARJETA_CREDITO | TARJETA_DEBITO | MERCADO_PAGO | TRANSFERENCIA</param>
        public Entidades.Resultado EmitirFactura(
            Guid    idTurno,
            int     tipoComprobante,
            string  cuitReceptor,
            string  nombreReceptor,
            string  condicionIVAReceptor,
            decimal importeTotal,
            decimal alicuotaIVA    = 0m,
            int     concepto       = 2,
            string  tipoTF         = "FACTURA C",
            long    nroAsociado    = 0,
            string  medioPago      = "EFECTIVO",
            string  descripcion    = "Prestación médica",
            string  codArticulo    = "",
            int     condicionIvaEmisorId = 6) // Default: Monotributista
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // LOG: Ver valor recibido en capa de negocio
                System.Diagnostics.Debug.WriteLine($"[NEGOCIO] condicionIvaEmisorId recibido: {condicionIvaEmisorId}");

                // 1. Cargar configuración
                DataTable config = _datos.ObtenerConfiguracion();
                if (config.Rows.Count == 0)
                {
                    resultado.Modo    = -1;
                    resultado.Mensaje = "No hay configuración AFIP cargada. Configure CUIT, certificado y punto de venta primero.";
                    return resultado;
                }

                DataRow cfg = config.Rows[0];
                string userToken = cfg["tfUserToken"].ToString();
                string apiToken  = cfg["tfApiToken"].ToString();
                string apiKey    = cfg["tfApiKey"].ToString();
                int    puntoVenta = Convert.ToInt32(cfg["puntoVenta"]);

                // 2. Insertar comprobante con el tipo seleccionado por el usuario
                // El número es asignado automáticamente por TusFacturas (nro=0)
                Guid idFactura = _datos.InsertarComprobante(
                    idTurno, tipoComprobante, puntoVenta, 0,
                    cuitReceptor, nombreReceptor, condicionIVAReceptor,
                    importeTotal, 0m, importeTotal,
                    concepto, "", tipoTF, condicionIvaEmisorId);

                // LOG: Ver valor antes de llamar a ServiciosAfip
                System.Diagnostics.Debug.WriteLine($"[NEGOCIO] condicionIvaEmisorId antes de llamar WS: {condicionIvaEmisorId}");

                // 3. Llamar a API local de facturación
                var ws = new ServiciosAfip(userToken, apiToken, apiKey, puntoVenta);
                RespuestaCAE respuesta = ws.EmitirFacturaC(
                    string.IsNullOrWhiteSpace(descripcion) ? "Prestación médica" : descripcion,
                    importeTotal,
                    nombreReceptor,
                    cuitReceptor,
                    tipoTF,
                    nroAsociado,
                    medioPago,
                    codArticulo,
                    tipoComprobante,
                    condicionIvaEmisorId); // IMPORTANTE: Pasar la condición IVA del emisor

                // 4. Guardar resultado
                if (respuesta.Autorizado && !string.IsNullOrEmpty(respuesta.CAE))
                {
                    long nroAsignado = ParsearNroComprobante(respuesta.NroComprobante);
                    _datos.ActualizarConCAE(idFactura, respuesta.CAE, respuesta.FechaVencimientoCAE, nroAsignado, respuesta.PdfUrl);
                    resultado.Modo      = 1;
                    resultado.Mensaje   = $"{tipoTF} autorizada. CAE: {respuesta.CAE} — Vence: {respuesta.FechaVencimientoCAE:dd/MM/yyyy} — Nro: {respuesta.NroComprobante}";
                    resultado.IdRetorno = idFactura;
                    resultado.PdfUrl    = (respuesta.PdfUrl == null) ? "" : respuesta.PdfUrl;
                    // Pasar URL del PDF al formulario via Tag
                    if (!string.IsNullOrEmpty(respuesta.PdfUrl))
                        resultado.Mensaje += $" — PDF:{respuesta.PdfUrl}";
                }
                else
                {
                    string motivo = string.IsNullOrEmpty(respuesta.Errores)
                        ? respuesta.Observaciones
                        : respuesta.Errores;
                    _datos.MarcarComoRechazado(idFactura, motivo);
                    resultado.Modo    = 0;
                    resultado.Mensaje = "AFIP rechazó el comprobante: " + motivo;
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

        public DataTable ObtenerComprobantesPorConsulta(Guid idConsulta)
        {
            return _datos.ObtenerComprobantesPorConsulta(idConsulta);
        }

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

                DataRow cfg      = config.Rows[0];
                string userToken = cfg["tfUserToken"].ToString();
                string apiToken  = cfg["tfApiToken"].ToString();
                string apiKey    = cfg["tfApiKey"].ToString();
                int    puntoVenta = Convert.ToInt32(cfg["puntoVenta"]);

                if (string.IsNullOrEmpty(userToken) || string.IsNullOrEmpty(apiToken))
                {
                    resultado.Modo    = -1;
                    resultado.Mensaje = "Tokens TusFacturas no configurados (tfUserToken / tfApiToken vacíos).";
                    return resultado;
                }

                resultado.Modo    = 1;
                resultado.Mensaje = $"Configuración TusFacturas OK. PDV: {puntoVenta.ToString().PadLeft(5,'0')} | ApiKey: {apiKey}";
            }
            catch (Exception ex)
            {
                resultado.Modo    = -1;
                resultado.Mensaje = "Error al verificar configuración: " + ex.Message;
            }
            return resultado;
        }

        public Entidades.Resultado GuardarTokensTusFacturas(string apiKey, string apiToken, string userToken)
        {
            return _datos.GuardarTokensTusFacturas(apiKey, apiToken, userToken);
        }

        /// <summary>
        /// Anula un comprobante en TusFacturas y lo marca como Anulado en la BD.
        /// </summary>
        public Entidades.Resultado AnularComprobante(Guid idFactura, long nroComprobante)
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
                DataRow cfg      = config.Rows[0];
                string userToken = cfg["tfUserToken"].ToString();
                string apiToken  = cfg["tfApiToken"].ToString();
                string apiKey    = cfg["tfApiKey"].ToString();
                int    puntoVenta = Convert.ToInt32(cfg["puntoVenta"]);

                // Leer el tipo de comprobante real desde la BD
                string tipoTF = "FACTURA C";
                DataTable dtFact = _datos.ObtenerComprobantePorId(idFactura);
                if (dtFact.Rows.Count > 0 && dtFact.Columns.Contains("tipoTF"))
                {
                    var valor = dtFact.Rows[0]["tipoTF"];
                    tipoTF = (valor == null || DBNull.Value.Equals(valor)) ? "FACTURA C" : valor.ToString();
                }

                var ws        = new ServiciosAfip(userToken, apiToken, apiKey, puntoVenta);
                var respuesta = ws.AnularComprobante(nroComprobante, tipoTF);

                if (respuesta.Autorizado)
                {
                    _datos.AnularComprobante(idFactura);
                    resultado.Modo    = 1;
                    resultado.Mensaje = "Comprobante anulado correctamente en AFIP y en el sistema.";
                }
                else
                {
                    string erroresObs = (respuesta.Errores == null) ? respuesta.Observaciones : respuesta.Errores;
                    resultado.Modo    = 0;
                    resultado.Mensaje = "AFIP rechazó la anulación: " + erroresObs;
                }
            }
            catch (Exception ex)
            {
                resultado.Modo    = -1;
                resultado.Mensaje = "Error al anular: " + ex.Message;
            }
            return resultado;
        }

        public DataTable ObtenerEspecialidadesConPrecio()
        {
            return _datos.ObtenerEspecialidadesConPrecio();
        }

        // Convierte "00001-00000001" → 1L
        private long ParsearNroComprobante(string nroStr)
        {
            if (string.IsNullOrEmpty(nroStr)) return 0;
            string[] partes = nroStr.Split('-');
            if (partes.Length < 2) return 0;
            long nro;
            return long.TryParse(partes[1], out nro) ? nro : 0;
        }
    }
}
