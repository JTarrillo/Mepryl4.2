using System;
using System.IO;
using System.Net;
using System.Text;

namespace CapaDatosMepryl
{
    // ═══════════════════════════════════════════════════════════════════════════
    //  INTEGRACIÓN CON API LOCAL DE FACTURACIÓN ELECTRÓNICA (REST/JSON)
    //  ───────────────────────────────────────────────────────────────────────
    //  Conexión directa con API local que se integra con AFIP (WSAA + WSFE).
    //  La API local gestiona el certificado ARCA y la autenticación con AFIP.
    //
    //  API LOCAL: http://localhost:3000/api/comprobantes
    //  ═══════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Respuesta de la API local al autorizar un comprobante.
    /// </summary>
    public class RespuestaCAE
    {
        public bool Autorizado { get; set; }
        public string CAE { get; set; }
        public DateTime FechaVencimientoCAE { get; set; }
        public string Observaciones { get; set; }
        public string Errores { get; set; }
        /// <summary>Nro de comprobante asignado</summary>
        public string NroComprobante { get; set; }
        /// <summary>URL del PDF del comprobante en la API local</summary>
        public string PdfUrl { get; set; }
    }

    /// <summary>
    /// Integración con API local de facturación electrónica AFIP.
    /// La API local gestiona WSAA + WSFE y el certificado ARCA.
    /// </summary>
    public class ServiciosAfip
    {
        private const string URL_API_LOCAL = "http://localhost:3000/api/comprobantes";
        private readonly int _puntoVenta;
        private static int _numeroSecuencial = 0; // Contador local para evitar consultar AFIP

        public ServiciosAfip(string userToken, string apiToken, string apiKey, int puntoVenta)
        {
            // Los tokens ya no se usan, mantenemos el constructor por compatibilidad
            _puntoVenta = puntoVenta;
        }

        // ─────────────────────────────────────────────────────────────────────
        // EMISIÓN DE COMPROBANTE
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Emite un comprobante (Factura A, B o C) a través de la API local.
        /// El número de comprobante es asignado automáticamente por AFIP.
        /// </summary>
        /// <param name="tipoComprobanteAFIP">1 = Factura A, 6 = Factura B, 11 = Factura C</param>
        /// <param name="medioPago">EFECTIVO | TARJETA_CREDITO | TARJETA_DEBITO | TRANSFERENCIA</param>
        /// <param name="condicionIvaEmisorId">Condición IVA del emisor para simulación (1=RI, 4=MO, 3=EX)</param>
        public RespuestaCAE EmitirFacturaC(
            string descripcion,
            decimal importeTotal,
            string nombreReceptor = "Consumidor Final",
            string documentoReceptor = "0",
            string tipoComprobante = "FACTURA C",
            long nroComprobanteAsociado = 0,
            string medioPago = "EFECTIVO",
            string codArticulo = "",
            int tipoComprobanteAFIP = 11,
            int condicionIvaEmisorId = 6) // Default: Monotributista
        {
            try
            {
                // LOG: Ver valor recibido en ServiciosAfip
                System.Diagnostics.Debug.WriteLine($"[SERVICIOS_AFIP] condicionIvaEmisorId recibido: {condicionIvaEmisorId}");

                // Usar el tipo de comprobante recibido como parámetro

                // Determinar tipo de documento y condición IVA según tipo de comprobante
                int docTipo = 99; // Default: Consumidor Final sin documento
                long docNro = 0;
                int condicionIvaReceptorId = 5; // Default: Consumidor Final

                string docClean = System.Text.RegularExpressions.Regex.Replace(documentoReceptor ?? "", @"[^0-9]", "");
                
                if (string.IsNullOrEmpty(docClean) || docClean == "0")
                {
                    // Sin documento: Consumidor Final
                    docTipo = 99;
                    docNro = 0;
                    condicionIvaReceptorId = 5; // CF
                    // Solo permite Factura B o C (no A)
                    if (tipoComprobanteAFIP == 1)
                    {
                        return new RespuestaCAE
                        {
                            Autorizado = false,
                            Errores = "Factura A requiere CUIT del receptor. Use Factura B o C para consumidor final."
                        };
                    }
                }
                else if (docClean.Length >= 7 && docClean.Length <= 9)
                {
                    // DNI (7-9 dígitos): Consumidor Final
                    docTipo = 96; // DNI
                    docNro = long.Parse(docClean);
                    condicionIvaReceptorId = 5; // CF
                    // Solo permite Factura B o C (no A)
                    if (tipoComprobanteAFIP == 1)
                    {
                        return new RespuestaCAE
                        {
                            Autorizado = false,
                            Errores = "Factura A requiere CUIT del receptor. Use Factura B o C para DNI."
                        };
                    }
                }
                else if (docClean.Length == 11 && docClean != "20962031006")
                {
                    // CUIT (11 dígitos)
                    docTipo = 80; // CUIT
                    docNro = long.Parse(docClean);
                    
                    // Asignar condición IVA según tipo de comprobante
                    if (tipoComprobanteAFIP == 1) // Factura A: Responsable Inscripto
                    {
                        condicionIvaReceptorId = 1; // RI
                    }
                    else if (tipoComprobanteAFIP == 6) // Factura B: Exento/Monotributista
                    {
                        condicionIvaReceptorId = 4; // EX (Exento) - podría ser también 6 (MO)
                    }
                    else // Factura C: puede ser cualquier condición, pero emisor es Monotributista
                    {
                        condicionIvaReceptorId = 5; // CF por defecto
                    }
                }
                else
                {
                    // Documento inválido
                    return new RespuestaCAE
                    {
                        Autorizado = false,
                        Errores = "Documento inválido. Ingrese DNI (7-9 dígitos) o CUIT (11 dígitos)."
                    };
                }

                // Generar número secuencial local para evitar consultar AFIP
                _numeroSecuencial++;
                long numeroComprobante = _numeroSecuencial;

                // Calcular IVA según tipo de comprobante
                decimal netoGravado = 0m;
                decimal importeIva = 0m;
                decimal importeIva21 = 0m;
                decimal importeIva105 = 0m;
                decimal importeIvaContenido = 0m;
                decimal alicuotaIva = 0m;

                if (tipoComprobanteAFIP == 1) // Factura A: discriminar IVA
                {
                    // Asumir 21% de IVA para Factura A (puede ajustarse según configuración)
                    alicuotaIva = 21m;
                    netoGravado = importeTotal / 1.21m;
                    importeIva21 = importeTotal - netoGravado;
                    importeIva = importeIva21;
                }
                else if (tipoComprobanteAFIP == 6) // Factura B: Exento/Monotributista - SIN IVA
                {
                    // Factura B es exenta, no tiene IVA
                    alicuotaIva = 0m;
                    netoGravado = importeTotal; // Total es el neto ya que no hay IVA
                    importeIva = 0m;
                    importeIva21 = 0m;
                    importeIvaContenido = 0m;
                }
                // Factura C: no aplica IVA

                // Construir campos de IVA según tipo
                string ivaFields = "";
                string ivaArray = "";
                if (tipoComprobanteAFIP == 1) // Factura A: discriminar IVA
                {
                    ivaFields = $@",
  ""netoGravado"": {netoGravado.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)},
  ""importeIva"": {importeIva.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)},
  ""importeIva21"": {importeIva21.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}";
                    ivaArray = $@",
  ""iva"": [{{
    ""id"": 5,
    ""baseImponible"": {netoGravado.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)},
    ""importe"": {importeIva21.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}
  }}]";
                }
                else if (tipoComprobanteAFIP == 6) // Factura B: IVA contenido (no discriminar)
                {
                    ivaFields = $@",
  ""importeIvaContenido"": {importeIvaContenido.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}";
                    // Factura B NO envía array IVA con alícuotas
                }

                // Construir JSON manualmente para la API local
                string json = $@"{{
  ""puntoVenta"": {_puntoVenta},
  ""tipoComprobante"": {tipoComprobanteAFIP},
  ""concepto"": 1,
  ""docTipo"": {docTipo},
  ""docNro"": {docNro},
  ""condicionIvaReceptorId"": {condicionIvaReceptorId},
  ""condicionIvaEmisorId"": {condicionIvaEmisorId},
  ""cbteFch"": ""{DateTime.Today:yyyyMMdd}"",
  ""monedaId"": ""PES"",
  ""monedaCotiz"": 1,
  ""receptorRazonSocial"": ""{Esc(nombreReceptor)}"",
  ""receptorDomicilio"": ""No informado"",
  ""condicionVenta"": ""{Esc(medioPago)}"",
  ""importeTotal"": {importeTotal.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}{ivaFields}{ivaArray},
  ""items"": [{{
    ""descripcion"": ""{Esc(descripcion)}"",
    ""cantidad"": 1,
    ""precioUnitario"": {importeTotal.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)},
    ""alicuotaIva"": {alicuotaIva.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)},
    ""importeIva"": {(tipoComprobanteAFIP == 1 ? importeIva.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) : "0.00")},
    ""netoGravado"": {(tipoComprobanteAFIP == 1 ? netoGravado.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) : importeTotal.ToString("F2", System.Globalization.CultureInfo.InvariantCulture))}
  }}]
}}";

                System.Diagnostics.Debug.WriteLine("[API LOCAL] JSON ENVIADO:\n" + json);

                // Hacer petición POST a la API local
                string respuestaJson = Post(URL_API_LOCAL + "/factura-c-real", json);

                System.Diagnostics.Debug.WriteLine("[API LOCAL] RESPUESTA:\n" + respuestaJson);
                return ParsearRespuestaLocal(respuestaJson);
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.ConnectionClosed || 
                                              ex.Status == WebExceptionStatus.Timeout ||
                                              (ex.Response != null && ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.ServiceUnavailable))
            {
                // AFIP no está disponible (horario o problema temporal)
                return new RespuestaCAE
                {
                    Autorizado = false,
                    Errores = "AFIP homologación no disponible en este momento. Horario: Lun-Vie 9:00-18:00 hora Argentina. Intente más tarde."
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[API LOCAL] ERROR DETALLADO: " + ex.Message);
                if (ex.InnerException != null)
                    System.Diagnostics.Debug.WriteLine("[API LOCAL] INNER EXCEPTION: " + ex.InnerException.Message);
                
                return new RespuestaCAE
                {
                    Autorizado = false,
                    Errores = ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : "")
                };
            }
        }

        /// <summary>
        /// Anula un comprobante ya emitido (actualmente no implementado en API local).
        /// </summary>
        public RespuestaCAE AnularComprobante(long nroComprobante, string tipoComprobante = "FACTURA C")
        {
            // La API local aún no tiene endpoint de anulación
            return new RespuestaCAE
            {
                Autorizado = false,
                Errores = "Función de anulación no implementada en API local. Use notas de crédito en su lugar."
            };
        }

        // ─────────────────────────────────────────────────────────────────────
        // PARSEO DE RESPUESTA API LOCAL
        // ─────────────────────────────────────────────────────────────────────

        private RespuestaCAE ParsearRespuestaLocal(string json)
        {
            var r = new RespuestaCAE();
            try
            {
                bool ok = Valor(json, "ok") == "true";
                
                if (ok)
                {
                    r.Autorizado = true;
                    r.CAE = Valor(json, "cae");
                    
                    // Buscar numeroComprobante en diferentes estructuras posibles
                    string nroComp = Valor(json, "numeroComprobante");
                    if (string.IsNullOrEmpty(nroComp))
                        nroComp = Valor(json, "nroComprobante");
                    r.NroComprobante = nroComp;

                    string caeVenc = Valor(json, "caeVencimiento");
                    if (string.IsNullOrEmpty(caeVenc))
                        caeVenc = Valor(json, "caeVencimiento");
                    
                    if (!string.IsNullOrEmpty(caeVenc) && caeVenc.Length == 8)
                        r.FechaVencimientoCAE = DateTime.ParseExact(caeVenc, "yyyyMMdd", null);

                    // Generar URL del PDF local
                    string comprobanteId = Valor(json, "id");
                    if (!string.IsNullOrEmpty(comprobanteId))
                        r.PdfUrl = $"{URL_API_LOCAL}/{comprobanteId}/pdf";
                }
                else
                {
                    r.Autorizado = false;
                    r.Errores = Valor(json, "message");
                    if (string.IsNullOrEmpty(r.Errores))
                        r.Errores = "Error desconocido en la respuesta";
                }
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
