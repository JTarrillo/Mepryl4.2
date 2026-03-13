using System;
using System.Collections.Generic;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    /// <summary>
    /// Capa de datos para Facturación Electrónica AFIP.
    /// Maneja persistencia de comprobantes, CAEs y configuración.
    /// Requiere las tablas: dbo.FacturaElectronica y dbo.ConfiguracionAFIP
    /// 
    /// Script SQL para crear las tablas:
    /// 
    ///   CREATE TABLE dbo.ConfiguracionAFIP (
    ///       id              INT PRIMARY KEY DEFAULT 1,
    ///       cuitEmisor      VARCHAR(13)  NOT NULL,
    ///       razonSocial     VARCHAR(200) NOT NULL,
    ///       condicionIVA    VARCHAR(50)  NOT NULL DEFAULT 'RI',  -- RI=Resp.Inscripto
    ///       puntoVenta      INT          NOT NULL DEFAULT 1,
    ///       ambiente        CHAR(1)      NOT NULL DEFAULT 'H',   -- H=Homologacion, P=Produccion
    ///       rutaCertificado VARCHAR(500) NOT NULL,
    ///       passwordCert    VARCHAR(200) NOT NULL DEFAULT '',
    ///       domicilioEmisor VARCHAR(300) NOT NULL DEFAULT ''
    ///   );
    ///
    ///   CREATE TABLE dbo.FacturaElectronica (
    ///       id                  UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ///       idConsulta          UNIQUEIDENTIFIER NOT NULL,
    ///       tipoComprobante     INT          NOT NULL,  -- 1=FactA, 6=FactB, 11=FactC
    ///       puntoVenta          INT          NOT NULL,
    ///       nroComprobante      BIGINT       NOT NULL,
    ///       cae                 VARCHAR(14)  NULL,
    ///       fechaVencCAE        DATE         NULL,
    ///       fechaEmision        DATE         NOT NULL DEFAULT GETDATE(),
    ///       cuitReceptor        VARCHAR(13)  NOT NULL DEFAULT '0',
    ///       nombreReceptor      VARCHAR(200) NOT NULL DEFAULT '',
    ///       condicionIVAReceptor VARCHAR(10) NOT NULL DEFAULT 'CF',
    ///       importeNeto         DECIMAL(18,2) NOT NULL DEFAULT 0,
    ///       importeIVA          DECIMAL(18,2) NOT NULL DEFAULT 0,
    ///       importeTotal        DECIMAL(18,2) NOT NULL DEFAULT 0,
    ///       concepto            INT          NOT NULL DEFAULT 2,  -- 1=Prod,2=Serv,3=P+S
    ///       estado              VARCHAR(20)  NOT NULL DEFAULT 'Pendiente',
    ///       observaciones       VARCHAR(500) NULL,
    ///       fechaCreacion       DATETIME     NOT NULL DEFAULT GETDATE()
    ///   );
    /// </summary>
    public class FacturacionElectronica
    {
        // ─────────────────────────────────────────────────────────────────────
        // CONFIGURACIÓN AFIP
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>Obtiene la configuración AFIP del sistema (registro único, id=1).</summary>
        public DataTable ObtenerConfiguracion()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(
                "SELECT * FROM dbo.ConfiguracionAFIP WHERE id = 1");
        }

        /// <summary>Guarda o actualiza la configuración AFIP.</summary>
        public Entidades.Resultado GuardarConfiguracion(
            string cuitEmisor, string razonSocial, string condicionIVA,
            int puntoVenta, char ambiente,
            string rutaCertificado, string passwordCert, string domicilio)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                string cuitSafe   = cuitEmisor.Replace("'", "''").Trim();
                string razonSafe  = razonSocial.Replace("'", "''").Trim();
                string domSafe    = domicilio.Replace("'", "''").Trim();
                string rutaSafe   = rutaCertificado.Replace("'", "''").Trim();
                string passSafe   = passwordCert.Replace("'", "''").Trim();

                // MERGE: insert si no existe, update si existe
                string sql = $@"
                    IF EXISTS (SELECT 1 FROM dbo.ConfiguracionAFIP WHERE id = 1)
                        UPDATE dbo.ConfiguracionAFIP SET
                            cuitEmisor      = '{cuitSafe}',
                            razonSocial     = '{razonSafe}',
                            condicionIVA    = '{condicionIVA}',
                            puntoVenta      = {puntoVenta},
                            ambiente        = '{ambiente}',
                            rutaCertificado = '{rutaSafe}',
                            passwordCert    = '{passSafe}',
                            domicilioEmisor = '{domSafe}'
                        WHERE id = 1
                    ELSE
                        INSERT INTO dbo.ConfiguracionAFIP
                            (id, cuitEmisor, razonSocial, condicionIVA, puntoVenta, ambiente, rutaCertificado, passwordCert, domicilioEmisor)
                        VALUES
                            (1, '{cuitSafe}', '{razonSafe}', '{condicionIVA}', {puntoVenta}, '{ambiente}', '{rutaSafe}', '{passSafe}', '{domSafe}')";

                SQLConnector.EjecutarConsulta(sql);
                resultado.Modo    = 1;
                resultado.Mensaje = "Configuración AFIP guardada correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo    = -1;
                resultado.Mensaje = "Error al guardar configuración AFIP: " + ex.Message;
            }
            return resultado;
        }

        // ─────────────────────────────────────────────────────────────────────
        // COMPROBANTES
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>Obtiene los comprobantes emitidos para una consulta.</summary>
        public DataTable ObtenerComprobantesPorConsulta(Guid idConsulta)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(
                $"SELECT * FROM dbo.FacturaElectronica WHERE idConsulta = '{idConsulta}' ORDER BY fechaCreacion DESC");
        }

        /// <summary>Obtiene un comprobante por su ID.</summary>
        public DataTable ObtenerComprobantePorId(Guid idFactura)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(
                $"SELECT * FROM dbo.FacturaElectronica WHERE id = '{idFactura}'");
        }

        /// <summary>
        /// Devuelve el último número de comprobante emitido para un punto de venta y tipo.
        /// Necesario para calcular el próximo número (AFIP exige consecutividad).
        /// </summary>
        public long ObtenerUltimoNroComprobante(int tipoComprobante, int puntoVenta)
        {
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(
                $@"SELECT ISNULL(MAX(nroComprobante), 0) AS ultimo
                   FROM dbo.FacturaElectronica
                   WHERE tipoComprobante = {tipoComprobante}
                     AND puntoVenta      = {puntoVenta}
                     AND estado          = 'Autorizado'");

            if (dt.Rows.Count > 0 && dt.Rows[0]["ultimo"] != DBNull.Value)
                return Convert.ToInt64(dt.Rows[0]["ultimo"]);

            return 0;
        }

        /// <summary>Inserta un comprobante nuevo (antes de llamar a AFIP).</summary>
        public Guid InsertarComprobante(
            Guid idConsulta, int tipoComprobante, int puntoVenta, long nroComprobante,
            string cuitReceptor, string nombreReceptor, string condicionIVAReceptor,
            decimal importeNeto, decimal importeIVA, decimal importeTotal,
            int concepto, string observaciones)
        {
            Guid nuevoId = Guid.NewGuid();

            string cuitSafe   = cuitReceptor.Replace("'", "''");
            string nombreSafe = nombreReceptor.Replace("'", "''");
            string obsSafe    = (observaciones ?? "").Replace("'", "''");

            string sql = $@"
                INSERT INTO dbo.FacturaElectronica
                    (id, idConsulta, tipoComprobante, puntoVenta, nroComprobante,
                     cuitReceptor, nombreReceptor, condicionIVAReceptor,
                     importeNeto, importeIVA, importeTotal,
                     concepto, estado, observaciones, fechaEmision, fechaCreacion)
                VALUES
                    ('{nuevoId}', '{idConsulta}', {tipoComprobante}, {puntoVenta}, {nroComprobante},
                     '{cuitSafe}', '{nombreSafe}', '{condicionIVAReceptor}',
                     {importeNeto.ToString(System.Globalization.CultureInfo.InvariantCulture)},
                     {importeIVA.ToString(System.Globalization.CultureInfo.InvariantCulture)},
                     {importeTotal.ToString(System.Globalization.CultureInfo.InvariantCulture)},
                     {concepto}, 'Pendiente', '{obsSafe}', GETDATE(), GETDATE())";

            SQLConnector.EjecutarConsulta(sql);
            return nuevoId;
        }

        /// <summary>Actualiza el estado de un comprobante con el CAE devuelto por AFIP.</summary>
        public Entidades.Resultado ActualizarConCAE(Guid idFactura, string cae, DateTime fechaVencCAE)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                string sql = $@"
                    UPDATE dbo.FacturaElectronica SET
                        cae         = '{cae}',
                        fechaVencCAE = '{fechaVencCAE:yyyy-MM-dd}',
                        estado       = 'Autorizado'
                    WHERE id = '{idFactura}'";

                SQLConnector.EjecutarConsulta(sql);
                resultado.Modo    = 1;
                resultado.Mensaje = "CAE registrado correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo    = -1;
                resultado.Mensaje = "Error al guardar CAE: " + ex.Message;
            }
            return resultado;
        }

        /// <summary>Marca un comprobante como rechazado por AFIP.</summary>
        public Entidades.Resultado MarcarComoRechazado(Guid idFactura, string motivoRechazo)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                string motivoSafe = motivoRechazo.Replace("'", "''");
                string sql = $@"
                    UPDATE dbo.FacturaElectronica SET
                        estado       = 'Rechazado',
                        observaciones = '{motivoSafe}'
                    WHERE id = '{idFactura}'";

                SQLConnector.EjecutarConsulta(sql);
                resultado.Modo    = 1;
                resultado.Mensaje = "Comprobante marcado como rechazado.";
            }
            catch (Exception ex)
            {
                resultado.Modo    = -1;
                resultado.Mensaje = "Error al actualizar estado: " + ex.Message;
            }
            return resultado;
        }

        /// <summary>Lista todos los comprobantes del día actual.</summary>
        public DataTable ListarComprobantesDia()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(
                @"SELECT f.*, c.nroOrden, c.identificador
                  FROM dbo.FacturaElectronica f
                  LEFT JOIN dbo.Consulta c ON c.id = f.idConsulta
                  WHERE CONVERT(DATE, f.fechaCreacion) = CONVERT(DATE, GETDATE())
                  ORDER BY f.fechaCreacion DESC");
        }

        /// <summary>Lista comprobantes entre fechas.</summary>
        public DataTable ListarComprobantesEntreFechas(DateTime desde, DateTime hasta)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(
                $@"SELECT f.*, c.nroOrden, c.identificador
                   FROM dbo.FacturaElectronica f
                   LEFT JOIN dbo.Consulta c ON c.id = f.idConsulta
                   WHERE CONVERT(DATE, f.fechaEmision) BETWEEN '{desde:yyyy-MM-dd}' AND '{hasta:yyyy-MM-dd}'
                   ORDER BY f.fechaEmision DESC, f.nroComprobante ASC");
        }
    }
}
