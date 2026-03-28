using System;
using System.IO;
using System.Net;
using System.Text;

namespace CapaDatosMepryl
{
    // ═══════════════════════════════════════════════════════════════════════════
    //  INTEGRACIÓN CON TUSFACTURAS.APP  (REST/JSON)
    //  ───────────────────────────────────────────────────────────────────────
    //  Reemplaza la implementación SOAP directa contra AFIP (WSAA + WSFE).
    //  TusFacturas actúa como intermediario y gestiona el certificado ARCA.
    //  No se requiere archivo .p12 ni firma CMS.
    //
    //  Documentación: https://developers.tusfacturas.app/
    //
    //  CONFIGURACIÓN (dbo.ConfiguracionAFIP):
    //    tfUserToken → User Token del punto de venta
    //    tfApiToken  → API Token
    //    tfApiKey    → API Key (ej: "71326")
    //    puntoVenta  → Número de PDV (ej: 1)
    // ═══════════════════════════════════════════════════════════════════════════

    // (eliminado: TicketAcceso — ya no se usa con TusFacturas)
    // (eliminado: ItemFactura  — ya no se usa con TusFacturas)

    // ─────────────────────────────────────────────────────────────────────────
    //  Nota: ¡NO OLVIDAR! Configurar la conexión ARCA en el portal TusFacturas:
    //    Mi cuenta → Configurar espacio de trabajo → Facturación ARCA
    //    Sin esa conexión, las facturas no serán enviadas a AFIP.
    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Respuesta de TusFacturas al autorizar un comprobante.
    /// </summary>
    public class RespuestaCAE
    {
        public bool Autorizado { get; set; }
        public string CAE { get; set; }
        public DateTime FechaVencimientoCAE { get; set; }
        public string Observaciones { get; set; }
        public string Errores { get; set; }
        /// <summary>Nro de comprobante asignado, ej: "00001-00000001"</summary>
        public string NroComprobante { get; set; }
        /// <summary>URL del PDF del comprobante en TusFacturas</summary>
        public string PdfUrl { get; set; }
    }

    /// <summary>
    /// Integración con TusFacturas.app API REST/JSON para facturación electrónica AFIP.
    /// No requiere .p12 ni WSAA — TusFacturas gestiona el certificado ARCA.
    /// </summary>
    public class ServiciosAfip
    {
        private const string URL_FACTURACION = "https://www.tusfacturas.app/app/api/v2/facturacion/nuevo";

        private readonly string _userToken;
        private readonly string _apiToken;
        private readonly string _apiKey;
        private readonly string _puntoVenta;   // 5 dígitos con ceros a la izquierda

        public ServiciosAfip(string userToken, string apiToken, string apiKey, int puntoVenta)
        {
            _userToken = userToken;
            _apiToken = apiToken;
            _apiKey = apiKey;
            _puntoVenta = puntoVenta.ToString().PadLeft(5, '0');
        }

        // ─────────────────────────────────────────────────────────────────────
        // EMISIÓN DE COMPROBANTE
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Emite un comprobante C (Factura, Nota de Cr�dito o Nota de D�bito) a trav�s de TusFacturas.
        /// El n�mero de comprobante es asignado autom�ticamente (numero=0).
        /// </summary>
        /// <param name="tipoComprobante">FACTURA C | NOTA DE CREDITO C | NOTA DE DEBITO C</param>
        /// <param name="nroComprobanteAsociado">Para NC/ND: nro de la factura original. 0 si no aplica.</param>
        /// <param name="medioPago">EFECTIVO | TARJETA_CREDITO | TARJETA_DEBITO | MERCADO_PAGO | TRANSFERENCIA</param>
        public RespuestaCAE EmitirFacturaC(
            string descripcion,
            decimal importeTotal,
            string nombreReceptor = "Consumidor Final",
            string documentoReceptor = "0",
            string tipoComprobante = "FACTURA C",
            long nroComprobanteAsociado = 0,
            string medioPago = "EFECTIVO",
            string codArticulo = "")
        {
            string fechaHoy = DateTime.Today.ToString("dd/MM/yyyy");
            string fechaVencPago = DateTime.Today.AddDays(30).ToString("dd/MM/yyyy");
            string importeStr = importeTotal.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

            // Si hay CUIT real ? receptor identificado (RI); si no ? Consumidor Final
            string docClean = System.Text.RegularExpressions.Regex.Replace(documentoReceptor ?? "", @"[^0-9]", "");
            bool tieneCuit = docClean.Length == 11;
            bool tieneDni = docClean.Length >= 7 && docClean.Length <= 8;
            string docTipo = tieneCuit ? "CUIT" : (tieneDni ? "DNI" : "CONSUMIDOR_FINAL");
            string condIva = tieneCuit ? "RI" : "CF";
            string docNro = (tieneCuit || tieneDni) ? docClean : "0";

            // Comprobantes asociados (requerido para NC y ND)
            bool esNcNd = tipoComprobante.StartsWith("NOTA DE");
            string asociados = "";
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
    ""domicilio"": ""Sin especificar"",
    ""provincia"": ""1"",
    ""condicion_iva"": ""{condIva}""
  }},
  ""comprobante"": {{
    ""fecha"": ""{fechaHoy}"",
    ""vencimiento"": ""{fechaVencPago}"",
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
        ""codigo"": ""{Esc(codArticulo)}"",
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

            System.Diagnostics.Debug.WriteLine("[TUSFACTURAS] JSON ENVIADO:\n" + json);
            string respuestaJson = Post(URL_FACTURACION, json);
            System.Diagnostics.Debug.WriteLine("[TUSFACTURAS] RESPUESTA:\n" + respuestaJson);
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

        // ─────────────────────────────────────────────────────────────────────
        // PARSEO DE RESPUESTA
        // ─────────────────────────────────────────────────────────────────────

        private RespuestaCAE Parsear(string json)
        {
            var r = new RespuestaCAE();
            try
            {
                r.Autorizado = Valor(json, "error") == "N";
                r.CAE = Valor(json, "cae");
                r.NroComprobante = Valor(json, "comprobante_nro");
                r.Observaciones = Valor(json, "rta");
                r.PdfUrl = Valor(json, "comprobante_pdf_url");

                string fechaVenc = Valor(json, "vencimiento_cae");
                if (!string.IsNullOrEmpty(fechaVenc) && fechaVenc.Length == 8)
                    r.FechaVencimientoCAE = DateTime.ParseExact(fechaVenc, "yyyyMMdd", null);

                if (!r.Autorizado)
                    r.Errores = ExtraerErrores(json);
            }
            catch (Exception ex)
            {
                r.Autorizado = false;
                r.Errores = "Error al parsear respuesta: " + ex.Message + "\n" + json;
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

        // ─────────────────────────────────────────────────────────────────────
        // HTTP POST
        // ─────────────────────────────────────────────────────────────────────

        private string Post(string url, string jsonBody)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Timeout = 30000;

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
