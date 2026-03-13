using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace CapaDatosMepryl
{
    // ═══════════════════════════════════════════════════════════════════════════
    //  CÓMO AGREGAR LOS WEB SERVICES REALES EN VISUAL STUDIO
    //  ─────────────────────────────────────────────────────
    //  1. Clic derecho en el proyecto CapaDatosMepryl → "Agregar" → "Referencia de servicio"
    //
    //  WSAA (Autenticación):
    //     Homologación: https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl
    //     Producción  : https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl
    //     Namespace   : AfipWSAA
    //
    //  WSFE (Facturación electrónica):
    //     Homologación: https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL
    //     Producción  : https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL
    //     Namespace   : AfipWSFE
    //
    //  Una vez generadas las referencias, reemplazá el envío SOAP manual de esta
    //  clase por las clases proxy generadas (LoginCmsClient / ServiceSoapClient).
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Resultado de autenticación AFIP (Ticket de Acceso).
    /// Se obtiene del WSAA y dura 12 horas; conviene cachearlo.
    /// </summary>
    public class TicketAcceso
    {
        public string Token        { get; set; }
        public string Sign         { get; set; }
        public DateTime Generacion { get; set; }
        public DateTime Expiracion { get; set; }

        public bool EstaVigente()
        {
            return DateTime.Now < Expiracion.AddMinutes(-5);
        }
    }

    /// <summary>
    /// Respuesta del WSFE al autorizar un comprobante.
    /// </summary>
    public class RespuestaCAE
    {
        public bool   Autorizado         { get; set; }
        public string CAE                { get; set; }
        public DateTime FechaVencimientoCAE { get; set; }
        public string Observaciones      { get; set; }
        public string Errores            { get; set; }
    }

    /// <summary>
    /// Wrapper que agrupa los datos de un ítem de factura para AFIP.
    /// </summary>
    public class ItemFactura
    {
        public string Descripcion   { get; set; }
        public int    Cantidad      { get; set; } = 1;
        public decimal PrecioUnitario { get; set; }
        public decimal ImporteTotal { get; set; }
        public decimal AlicuotaIVA  { get; set; } = 21m; // 21%, 10.5% o 0%
    }

    /// <summary>
    /// Integración con los dos web services de AFIP via SOAP manual.
    /// 
    /// FLUJO COMPLETO:
    ///   1. ObtenerTicketAcceso()  → llama a WSAA con el certificado .p12
    ///   2. AutorizarComprobante() → llama a WSFE con el Token+Sign del paso 1
    /// </summary>
    public class ServiciosAfip
    {
        // URLs de los servicios
        private const string WSAA_HOMO = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
        private const string WSAA_PROD = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
        private const string WSFE_HOMO = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";
        private const string WSFE_PROD = "https://servicios1.afip.gov.ar/wsfev1/service.asmx";
        private const string SERVICIO  = "wsfe"; // nombre del servicio destino en el LoginTicketRequest

        private readonly char   _ambiente;       // 'H' u 'P'
        private readonly string _rutaCertificado;
        private readonly string _passwordCert;

        // Cache del ticket durante su vigencia (evita llamar a WSAA en cada factura)
        private static TicketAcceso _ticketCacheado;

        public ServiciosAfip(char ambiente, string rutaCertificado, string passwordCert)
        {
            _ambiente         = char.ToUpper(ambiente);
            _rutaCertificado  = rutaCertificado;
            _passwordCert     = passwordCert;
        }

        // ─────────────────────────────────────────────────────────────────────
        // PASO 1: WSAA — Obtener Ticket de Acceso
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Autentica contra AFIP y devuelve un Ticket de Acceso (Token + Sign).
        /// Usa caché: si el ticket sigue vigente no vuelve a llamar al WS.
        /// </summary>
        public TicketAcceso ObtenerTicketAcceso()
        {
            // Retornar ticket cacheado si sigue vigente
            if (_ticketCacheado != null && _ticketCacheado.EstaVigente())
                return _ticketCacheado;

            // 1. Cargar el certificado .p12
            X509Certificate2 certificado = CargarCertificado();

            // 2. Armar el XML LoginTicketRequest
            string loginTicketRequest = ArmarLoginTicketRequest();

            // 3. Firmar el XML con CMS (PKCS#7) usando la clave privada del certificado
            string cmsFirmadoBase64 = FirmarCMS(loginTicketRequest, certificado);

            // 4. Llamar al WSAA via SOAP
            string wsaaUrl = _ambiente == 'P' ? WSAA_PROD : WSAA_HOMO;
            string respuestaXml = LlamarSOAP(
                wsaaUrl,
                "\"\"", // SOAPAction vacía para WSAA
                ConstruirBodyWSAA(cmsFirmadoBase64));

            // 5. Parsear la respuesta y devolver el ticket
            _ticketCacheado = ParsearRespuestaWSAA(respuestaXml);
            return _ticketCacheado;
        }

        private string ArmarLoginTicketRequest()
        {
            DateTime ahora      = DateTime.Now;
            DateTime expiracion = ahora.AddHours(12);

            return $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<loginTicketRequest version=""1.0"">
  <header>
    <uniqueId>{(long)(ahora - new DateTime(1970,1,1)).TotalSeconds}</uniqueId>
    <generationTime>{ahora.AddMinutes(-5):yyyy-MM-ddTHH:mm:ss}</generationTime>
    <expirationTime>{expiracion:yyyy-MM-ddTHH:mm:ss}</expirationTime>
  </header>
  <service>{SERVICIO}</service>
</loginTicketRequest>";
        }

        private string FirmarCMS(string contenidoXml, X509Certificate2 certificado)
        {
            byte[] datos = Encoding.UTF8.GetBytes(contenidoXml);

            ContentInfo contentInfo = new ContentInfo(datos);
            SignedCms   signedCms   = new SignedCms(contentInfo, false);

            CmsSigner firmante = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificado);
            firmante.IncludeOption = X509IncludeOption.EndCertOnly;

            signedCms.ComputeSignature(firmante, false);

            return Convert.ToBase64String(signedCms.Encode());
        }

        private X509Certificate2 CargarCertificado()
        {
            if (!File.Exists(_rutaCertificado))
                throw new FileNotFoundException($"Certificado AFIP no encontrado en: {_rutaCertificado}");

            return new X509Certificate2(
                _rutaCertificado,
                _passwordCert,
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
        }

        private string ConstruirBodyWSAA(string cmsFirmadoBase64)
        {
            return $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:wsaa=""http://wsaa.view.sua.dvadac.desein.afip.gov"">
   <soapenv:Header/>
   <soapenv:Body>
      <wsaa:loginCms>
         <wsaa:in0>{cmsFirmadoBase64}</wsaa:in0>
      </wsaa:loginCms>
   </soapenv:Body>
</soapenv:Envelope>";
        }

        private TicketAcceso ParsearRespuestaWSAA(string respuestaXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(respuestaXml);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("s", "http://schemas.xmlsoap.org/soap/envelope/");

            // El XML de respuesta contiene un <loginCmsReturn> con otro XML embebido
            string loginCmsReturn = doc.SelectSingleNode("//loginCmsReturn")?.InnerText
                                 ?? doc.SelectSingleNode("//*[local-name()='loginCmsReturn']")?.InnerText;

            if (string.IsNullOrEmpty(loginCmsReturn))
                throw new Exception("WSAA: respuesta vacía o inesperada. XML recibido:\n" + respuestaXml);

            XmlDocument ticketDoc = new XmlDocument();
            ticketDoc.LoadXml(loginCmsReturn);

            var ticket = new TicketAcceso
            {
                Token      = ticketDoc.SelectSingleNode("//token")?.InnerText,
                Sign       = ticketDoc.SelectSingleNode("//sign")?.InnerText,
                Generacion = DateTime.Parse(ticketDoc.SelectSingleNode("//generationTime")?.InnerText ?? DateTime.Now.ToString()),
                Expiracion = DateTime.Parse(ticketDoc.SelectSingleNode("//expirationTime")?.InnerText ?? DateTime.Now.AddHours(12).ToString())
            };

            if (string.IsNullOrEmpty(ticket.Token))
                throw new Exception("WSAA: no se pudo obtener el Token del ticket de acceso.");

            return ticket;
        }

        // ─────────────────────────────────────────────────────────────────────
        // PASO 2: WSFE — Autorizar comprobante (FECAESolicitar)
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        /// Envía un comprobante a AFIP para autorización y devuelve el CAE.
        /// </summary>
        /// <param name="cuitEmisor">CUIT del emisor (sin guiones)</param>
        /// <param name="puntoVenta">Punto de venta habilitado en AFIP</param>
        /// <param name="tipoComprobante">1=FactA, 6=FactB, 11=FactC</param>
        /// <param name="nroComprobante">Nro consecutivo (último autorizado + 1)</param>
        /// <param name="concepto">1=Productos, 2=Servicios, 3=Productos y Servicios</param>
        /// <param name="cuitReceptor">CUIT del receptor (para FactA; "0" para FactB/C)</param>
        /// <param name="importeTotal">Total del comprobante</param>
        /// <param name="importeIVA">Importe de IVA</param>
        /// <param name="alicuotaIVAId">5=21%, 4=10.5%, 3=0%</param>
        public RespuestaCAE AutorizarComprobante(
            string cuitEmisor, int puntoVenta, int tipoComprobante,
            long nroComprobante, int concepto,
            string cuitReceptor, decimal importeTotal, decimal importeIVA,
            int alicuotaIVAId = 5)
        {
            TicketAcceso ticket = ObtenerTicketAcceso();
            string wsfeUrl = _ambiente == 'P' ? WSFE_PROD : WSFE_HOMO;

            string fechaHoy     = DateTime.Today.ToString("yyyyMMdd");
            decimal importeNeto = importeTotal - importeIVA;

            string soapBody = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ar=""http://ar.gov.afip.dif.FEV1/"">
   <soapenv:Header/>
   <soapenv:Body>
      <ar:FECAESolicitar>
         <ar:Auth>
            <ar:Token>{ticket.Token}</ar:Token>
            <ar:Sign>{ticket.Sign}</ar:Sign>
            <ar:Cuit>{cuitEmisor}</ar:Cuit>
         </ar:Auth>
         <ar:FeCAEReq>
            <ar:FeCabReq>
               <ar:CantReg>1</ar:CantReg>
               <ar:PtoVta>{puntoVenta}</ar:PtoVta>
               <ar:CbteTipo>{tipoComprobante}</ar:CbteTipo>
            </ar:FeCabReq>
            <ar:FeDetReq>
               <ar:FECAEDetRequest>
                  <ar:Concepto>{concepto}</ar:Concepto>
                  <ar:DocTipo>{(cuitReceptor == "0" ? 99 : 80)}</ar:DocTipo>
                  <ar:DocNro>{(cuitReceptor == "0" ? "0" : cuitReceptor)}</ar:DocNro>
                  <ar:CbteDesde>{nroComprobante}</ar:CbteDesde>
                  <ar:CbteHasta>{nroComprobante}</ar:CbteHasta>
                  <ar:CbteFch>{fechaHoy}</ar:CbteFch>
                  <ar:ImpTotal>{importeTotal.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}</ar:ImpTotal>
                  <ar:ImpTotConc>0</ar:ImpTotConc>
                  <ar:ImpNeto>{importeNeto.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}</ar:ImpNeto>
                  <ar:ImpOpEx>0</ar:ImpOpEx>
                  <ar:ImpIVA>{importeIVA.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}</ar:ImpIVA>
                  <ar:ImpTrib>0</ar:ImpTrib>
                  <ar:MonId>PES</ar:MonId>
                  <ar:MonCotiz>1</ar:MonCotiz>
                  <ar:Iva>
                     <ar:AlicIva>
                        <ar:Id>{alicuotaIVAId}</ar:Id>
                        <ar:BaseImp>{importeNeto.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}</ar:BaseImp>
                        <ar:Importe>{importeIVA.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}</ar:Importe>
                     </ar:AlicIva>
                  </ar:Iva>
               </ar:FECAEDetRequest>
            </ar:FeDetReq>
         </ar:FeCAEReq>
      </ar:FECAESolicitar>
   </soapenv:Body>
</soapenv:Envelope>";

            string respuestaXml = LlamarSOAP(wsfeUrl, "http://ar.gov.afip.dif.FEV1/FECAESolicitar", soapBody);
            return ParsearRespuestaWSFE(respuestaXml);
        }

        /// <summary>
        /// Consulta el último nro de comprobante autorizado en AFIP (FECompUltimoAutorizado).
        /// Útil para verificar sincronía antes de emitir.
        /// </summary>
        public long ConsultarUltimoNroAutorizado(string cuitEmisor, int puntoVenta, int tipoComprobante)
        {
            TicketAcceso ticket = ObtenerTicketAcceso();
            string wsfeUrl = _ambiente == 'P' ? WSFE_PROD : WSFE_HOMO;

            string soapBody = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ar=""http://ar.gov.afip.dif.FEV1/"">
   <soapenv:Header/>
   <soapenv:Body>
      <ar:FECompUltimoAutorizado>
         <ar:Auth>
            <ar:Token>{ticket.Token}</ar:Token>
            <ar:Sign>{ticket.Sign}</ar:Sign>
            <ar:Cuit>{cuitEmisor}</ar:Cuit>
         </ar:Auth>
         <ar:PtoVta>{puntoVenta}</ar:PtoVta>
         <ar:CbteTipo>{tipoComprobante}</ar:CbteTipo>
      </ar:FECompUltimoAutorizado>
   </soapenv:Body>
</soapenv:Envelope>";

            string respuesta = LlamarSOAP(wsfeUrl, "http://ar.gov.afip.dif.FEV1/FECompUltimoAutorizado", soapBody);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(respuesta);
            string nro = doc.SelectSingleNode("//*[local-name()='CbteNro']")?.InnerText;
            return string.IsNullOrEmpty(nro) ? 0 : Convert.ToInt64(nro);
        }

        private RespuestaCAE ParsearRespuestaWSFE(string respuestaXml)
        {
            var resultado = new RespuestaCAE();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(respuestaXml);

                string resultado_str = doc.SelectSingleNode("//*[local-name()='Resultado']")?.InnerText;
                resultado.Autorizado = resultado_str == "A";

                resultado.CAE = doc.SelectSingleNode("//*[local-name()='CAE']")?.InnerText;

                string fechaVenc = doc.SelectSingleNode("//*[local-name()='CAEFchVto']")?.InnerText;
                if (!string.IsNullOrEmpty(fechaVenc) && fechaVenc.Length == 8)
                    resultado.FechaVencimientoCAE = DateTime.ParseExact(fechaVenc, "yyyyMMdd", null);

                // Observaciones (código + mensaje)
                var obs = new System.Text.StringBuilder();
                foreach (XmlNode n in doc.SelectNodes("//*[local-name()='Obs']") ?? (XmlNodeList)null!)
                    obs.AppendLine($"[{n.SelectSingleNode("*[local-name()='Code']")?.InnerText}] {n.SelectSingleNode("*[local-name()='Msg']")?.InnerText}");
                resultado.Observaciones = obs.ToString().Trim();

                // Errores
                var err = new System.Text.StringBuilder();
                foreach (XmlNode n in doc.SelectNodes("//*[local-name()='Err']") ?? (XmlNodeList)null!)
                    err.AppendLine($"[{n.SelectSingleNode("*[local-name()='Code']")?.InnerText}] {n.SelectSingleNode("*[local-name()='Msg']")?.InnerText}");
                resultado.Errores = err.ToString().Trim();
            }
            catch (Exception ex)
            {
                resultado.Autorizado = false;
                resultado.Errores    = "Error al parsear respuesta WSFE: " + ex.Message;
            }
            return resultado;
        }

        // ─────────────────────────────────────────────────────────────────────
        // HELPER: llamada SOAP via HTTP
        // ─────────────────────────────────────────────────────────────────────

        private string LlamarSOAP(string url, string soapAction, string soapEnvelope)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method      = "POST";
            request.ContentType = "text/xml;charset=UTF-8";
            request.Headers.Add("SOAPAction", soapAction);
            request.Timeout     = 30000; // 30 segundos

            byte[] body = Encoding.UTF8.GetBytes(soapEnvelope);
            request.ContentLength = body.Length;

            using (Stream reqStream = request.GetRequestStream())
                reqStream.Write(body, 0, body.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                return reader.ReadToEnd();
        }
    }
}
