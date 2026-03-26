using System;
using System.IO;
using System.Net;
using System.Text;

namespace CapaDatosMepryl
{
    // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
    //  INTEGRACIÃ“N CON TUSFACTURAS.APP  (REST/JSON)
    //  â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    //  Reemplaza la implementaciÃ³n SOAP directa contra AFIP (WSAA + WSFE).
    //  TusFacturas actÃºa como intermediario y gestiona el certificado ARCA.
    //  No se requiere archivo .p12 ni firma CMS.
    //
    //  DocumentaciÃ³n: https://developers.tusfacturas.app/
    //
    //  CONFIGURACIÃ“N (dbo.ConfiguracionAFIP):
    //    tfUserToken â†’ User Token del punto de venta
    //    tfApiToken  â†’ API Token
    //    tfApiKey    â†’ API Key (ej: "71326")
    //    puntoVenta  â†’ NÃºmero de PDV (ej: 1)
    // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•

    // (eliminado: TicketAcceso â€” ya no se usa con TusFacturas)
    // (eliminado: ItemFactura  â€” ya no se usa con TusFacturas)

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    //  Nota: Â¡NO OLVIDAR! Configurar la conexiÃ³n ARCA en el portal TusFacturas:
    //    Mi cuenta â†’ Configurar espacio de trabajo â†’ FacturaciÃ³n ARCA
    //    Sin esa conexiÃ³n, las facturas no serÃ¡n enviadas a AFIP.
    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Respuesta de TusFacturas al autorizar un comprobante.
    /// </summary>
    public class RespuestaCAE
    {
        public bool     Autorizado          { get; set; }
        public string   CAE                 { get; set; }
        public DateTime FechaVencimientoCAE { get; set; }
        public string   Observaciones       { get; set; }
        public string   Errores             { get; set; }
        /// <summary>Nro de comprobante asignado, ej: "00001-00000001"</summary>
        public string   NroComprobante      { get; set; }
        /// <summary>URL del PDF del comprobante en TusFacturas</summary>
        public string   PdfUrl              { get; set; }
    }

    /// <summary>
    /// IntegraciÃ³n con TusFacturas.app API REST/JSON para facturaciÃ³n electrÃ³nica AFIP.
    /// No requiere .p12 ni WSAA â€” TusFacturas gestiona el certificado ARCA.
    /// </summary>
    public class ServiciosAfip
    {
        private const string URL_FACTURACION = "https://www.tusfacturas.app/app/api/v2/facturacion/nuevo";

        private readonly string _userToken;
        private readonly string _apiToken;
        private readonly string _apiKey;
        private readonly string _puntoVenta;   // 5 dÃ­gitos con ceros a la izquierda

        public ServiciosAfip(string userToken, string apiToken, string apiKey, int puntoVenta)
        {
            _userToken  = userToken;
            _apiToken   = apiToken;
            _apiKey     = apiKey;
            _puntoVenta = puntoVenta.ToString().PadLeft(5, '0');
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // EMISIÃ“N DE COMPROBANTE
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        /// <summary>
        /// Emite un comprobante C (Factura, Nota de Crédito o Nota de Débito) a través de TusFacturas.
        /// El número de comprobante es asignado automáticamente (numero=0).
        /// </summary>
        /// <param name="tipoComprobante">FACTURA C | NOTA DE CREDITO C | NOTA DE DEBITO C</param>
        /// <param name="nroComprobanteAsociado">Para NC/ND: nro de la factura original. 0 si no aplica.</param>
        /// <param name="medioPago">EFECTIVO | TARJETA_CREDITO | TARJETA_DEBITO | MERCADO_PAGO | TRANSFERENCIA</param>
        public RespuestaCAE EmitirFacturaC(
            string  descripcion,
            decimal importeTotal,
            string  nombreReceptor        = "Consumidor Final",
            string  documentoReceptor     = "0",
            string  tipoComprobante       = "FACTURA C",
            long    nroComprobanteAsociado = 0,
            string  medioPago             = "EFECTIVO")
        {
            string fechaHoy   = DateTime.Today.ToString("dd/MM/yyyy");
            string importeStr = importeTotal.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

            // Si hay CUIT real → receptor identificado (RI); si no → Consumidor Final
            bool   tieneCuit = documentoReceptor != "0" && !string.IsNullOrWhiteSpace(documentoReceptor);
            string docTipo   = tieneCuit ? "CUIT"            : "CONSUMIDOR_FINAL";
            string condIva   = tieneCuit ? "RI"              : "CF";
            string docNro    = tieneCuit ? documentoReceptor : "0";

            // Comprobantes asociados (requerido para NC y ND)
            bool   esNcNd     = tipoComprobante.StartsWith("NOTA DE");
            string asociados  = "";
            if (esNcNd && nroComprobanteAsociado > 0)
            {
                asociados = $@",
    ""comprobantes_asociados"": [{{
      ""tipo"": ""FACTURA C"",
      ""punto_venta"": ""{_puntoVenta}"",
      ""numero"": {nroComprobanteAsociado}
    }}]";
            }

            // Forma de pago
            string formaPago = string.IsNullOrEmpty(medioPago) ? "EFECTIVO" : medioPago;

            string json = $@"{{
  ""usertoken"": ""{_userToken}"",
  ""apitoken"": ""{_apiToken}"",
  ""apikey"": ""{_apiKey}"",
  ""cliente"": {{
    ""documento_tipo"": ""{docTipo}"",
    ""documento_nro"": ""{Esc(docNro)}"",
    ""razon_social"": ""{Esc(nombreReceptor)}"",
    ""email"": """",
    ""domicilio"": """",
    ""condicion_iva"": ""{condIva}""
  }},
  ""comprobante"": {{
    ""fecha"": ""{fechaHoy}"",
    ""tipo"": ""{tipoComprobante}"",
    ""operacion"": ""V"",
    ""punto_venta"": ""{_puntoVenta}"",
    ""numero"": 0,
    ""periodo_facturado_desde"": ""{fechaHoy}"",
    ""periodo_facturado_hasta"": ""{fechaHoy}"",
    ""rubro"": ""Servicios de salud"",
    ""rubro_grupo_contable"": """",
    ""forma_pago"": ""{formaPago}"",
    ""detalle"": [{{
      ""cantidad"": 1,
      ""producto"": {{
        ""descripcion"": ""{Esc(descripcion)}"",
        ""unidad_bulto"": 1,
        ""lista_precios"": """",
        ""codigo"": """",
        ""precio_unitario_sin_iva"": {importeStr},
        ""alicuota"": 0,
        ""unidad_medida"": ""94""
      }},
      ""iva"": {{
        ""descripcion"": ""0%"",
        ""porcentaje"": 0
      }},
      ""subtotal"": {importeStr}
    }}],
    ""bonificacion"": 0,
    ""iva_array"": [],
    ""subtotal"": {importeStr},
    ""total"": {importeStr},
    ""importe_neto"": {importeStr}{asociados}
  }}}}";

            string respuestaJson = Post(URL_FACTURACION, json);
            return Parsear(respuestaJson);
        }

        /// <summary>
        /// Anula un comprobante ya emitido via TusFacturas.
        /// </summary>
        /// <param name="tipoComprobante">FACTURA C | NOTA DE CREDITO C | NOTA DE DEBITO C</param>
        public RespuestaCAE AnularComprobante(long nroComprobante, string tipoComprobante = "FACTURA C")
        {
            string json = $@"{{
  ""usertoken"": ""{_userToken}"",
  ""apitoken"": ""{_apiToken}"",
  ""apikey"": ""{_apiKey}"",
  ""comprobante"": {{
    ""tipo"": ""{tipoComprobante}"",
    ""punto_venta"": ""{_puntoVenta}"",
    ""numero"": {nroComprobante}
  }}}}";

            string respuestaJson = Post("https://www.tusfacturas.app/app/api/v2/facturacion/anular", json);
            return Parsear(respuestaJson);
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // PARSEO DE RESPUESTA
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        private RespuestaCAE Parsear(string json)
        {
            var r = new RespuestaCAE();
            try
            {
                r.Autorizado     = Valor(json, "error") == "N";
                r.CAE            = Valor(json, "cae");
                r.NroComprobante = Valor(json, "comprobante_nro");
                r.Observaciones  = Valor(json, "rta");
                r.PdfUrl         = Valor(json, "comprobante_pdf_url");

                string fechaVenc = Valor(json, "vencimiento_cae");
                if (!string.IsNullOrEmpty(fechaVenc) && fechaVenc.Length == 8)
                    r.FechaVencimientoCAE = DateTime.ParseExact(fechaVenc, "yyyyMMdd", null);

                if (!r.Autorizado)
                    r.Errores = ExtraerErrores(json);
            }
            catch (Exception ex)
            {
                r.Autorizado = false;
                r.Errores    = "Error al parsear respuesta: " + ex.Message + "\n" + json;
            }
            return r;
        }

        // Extrae "clave":"valor" o "clave":numero
        private string Valor(string json, string clave)
        {
            string patron = $"\"{clave}\":";
            int idx = json.IndexOf(patron);
            if (idx < 0) return string.Empty;
            idx += patron.Length;
            while (idx < json.Length && json[idx] == ' ') idx++;
            if (idx >= json.Length) return string.Empty;
            if (json[idx] == '"')
            {
                idx++;
                int fin = json.IndexOf('"', idx);
                return fin < 0 ? string.Empty : json.Substring(idx, fin - idx);
            }
            else
            {
                int fin = json.IndexOfAny(new[] { ',', '}', '\n' }, idx);
                return fin < 0 ? json.Substring(idx).Trim() : json.Substring(idx, fin - idx).Trim();
            }
        }

        // Extrae "errores":["msg1","msg2"] como string legible
        private string ExtraerErrores(string json)
        {
            int idx = json.IndexOf("\"errores\":");
            if (idx < 0) return string.Empty;
            idx = json.IndexOf('[', idx);
            if (idx < 0) return string.Empty;
            int fin = json.IndexOf(']', idx);
            if (fin < 0) return string.Empty;
            return json.Substring(idx + 1, fin - idx - 1)
                       .Replace("\"", "").Replace(",", " | ").Trim();
        }

        // Escapa caracteres especiales JSON
        private string Esc(string s) =>
            string.IsNullOrEmpty(s) ? string.Empty
                : s.Replace("\\", "\\\\").Replace("\"", "\\\"")
                   .Replace("\n", "\\n").Replace("\r", "\\r");

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // HTTP POST
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        private string Post(string url, string jsonBody)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method      = "POST";
            req.ContentType = "application/json";
            req.Timeout     = 30000;

            byte[] body = Encoding.UTF8.GetBytes(jsonBody);
            req.ContentLength = body.Length;

            using (Stream s = req.GetRequestStream())
                s.Write(body, 0, body.Length);

            try
            {
                using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    return reader.ReadToEnd();
            }
            catch (WebException ex) when (ex.Response != null)
            {
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8))
                    return reader.ReadToEnd();
            }
        }
    }
}
