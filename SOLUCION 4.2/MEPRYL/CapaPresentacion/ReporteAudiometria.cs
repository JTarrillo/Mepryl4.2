using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using System.IO;
using CapaPresentacionBase;
using Comunes;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace CapaPresentacion
{
    public class ReporteAudiometria : DevExpress.XtraEditors.XtraForm
    // Caracteres inválidos para nombres de archivo en Windows
    {
        private static readonly char[] InvalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();

        private CapaNegocioMepryl.Reportes reporte;

        DevExpress.XtraSpreadsheet.SpreadsheetControl control = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
        public static IWorkbook workbook;
        public Worksheet worksheet;

        string strNroOrden = "";
        DateTime dtFecha = DateTime.Now;
        string strApellido = "";
        string strdni;
        string strNombre = "";
        string strEmpresa = "";
        string strDiagnostico = "";
        string strIdExamenLaboral = "";
        string strTipoPaciente = "";
        bool blnEstadoRevision = false;
        DataTable dtDatosAudiometria = null;

        private Thread demoThread = null;

        public ReporteAudiometria()
        {
            reporte = new CapaNegocioMepryl.Reportes();
            //this.demoThread = new Thread(new ThreadStart(this.AbrirArchivoExcel));
            //this.demoThread.Start();
            AbrirArchivoExcel();
        }

        public void AbrirArchivoExcel()
        {
            using (FileStream stream = new FileStream(@"P:\Temporal\PLANTILLA REPORTE INFORMES\Informe Audio Digitalizada2.xlsx", FileMode.Open))
            {
                control.LoadDocument(stream, DocumentFormat.OpenXml);
                workbook = control.Document;
                //workbook.LoadDocument(stream, DocumentFormat.OpenXml);
                worksheet = workbook.Worksheets[0]; // 1era Hoja del libro de excel
                control = null;
                stream.Dispose();
                stream.Close();
            }

        }

        public bool GeneraAutoReporteAudiometria(DateTime dtFechaEstudios, string nroOrden)
        {
            bool blnResultado = false;
            DataTable dt = null;

            dt = reporte.AudiometriaEstablcerDatos(dtFechaEstudios, nroOrden);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strNroOrden = nroOrden;
                    dtFecha = dtFechaEstudios;
                    strApellido = dt.Rows[i][3].ToString();
                    strNombre = dt.Rows[i][4].ToString();
                    strEmpresa = dt.Rows[i][5].ToString();
                    strDiagnostico = dt.Rows[i][6].ToString();
                    strTipoPaciente = dt.Rows[i][35].ToString();
                    blnEstadoRevision = Convert.ToBoolean(dt.Rows[i][33].ToString());
                    if (blnEstadoRevision)
                    {
                        EstablcerDatos();
                        GuardarDatosPdf();
                        blnResultado = true;
                    }
                }
            }
            else
            {
                DataTable dtDiagnostico = reporte.AudiometriaDiagnostico(dtFechaEstudios, nroOrden);
                if (dtDiagnostico.Rows.Count > 0)
                {
                    if (dtDiagnostico.Rows.Count > 0)
                    {
                        strNroOrden = nroOrden;
                        dtFecha = dtFechaEstudios;

                        for (int i = 0; i < dtDiagnostico.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(dtDiagnostico.Rows[i][6].ToString()))
                            {
                                strdni = dtDiagnostico.Rows[i][2].ToString();
                                strApellido = dtDiagnostico.Rows[i][3].ToString();
                                strNombre = dtDiagnostico.Rows[i][4].ToString();
                                strEmpresa = dtDiagnostico.Rows[i][5].ToString();
                                strDiagnostico = dtDiagnostico.Rows[i][6].ToString();
                                strTipoPaciente = dtDiagnostico.Rows[i][34].ToString();
                                blnEstadoRevision = Convert.ToBoolean(dtDiagnostico.Rows[i][31].ToString());
                                if (blnEstadoRevision)
                                {
                                    EstablcerDatos();
                                    GuardarDatosPdf();
                                    blnResultado = true;
                                }
                            }
                        }
                    }
                }
            }

            return blnResultado;
        }

        public void EstablcerDatos()
        {


            dtDatosAudiometria = null;
            //dtDatosAudiometria = reporte.AudiometriaEstablcerDatos(dtFecha, strNroOrden);
            dtDatosAudiometria = reporte.AudiometriaDiagnostico(dtFecha, strNroOrden);
            string strPathFirma = "";

            //Datos Cabecera
            if (strApellido.Length > 26)
                worksheet.Cells["I4"].Value = strApellido.Substring(0, 26);
            else
                worksheet.Cells["I4"].Value = strApellido;
            if (strNombre.Length > 26)
                worksheet.Cells["I7"].Value = strNombre.Substring(0, 26);
            else
                worksheet.Cells["I7"].Value = strNombre;
            if (strEmpresa.Length > 26)
                worksheet.Cells["I10"].Value = strEmpresa.Substring(0, 26);
            else
                worksheet.Cells["I10"].Value = strEmpresa;
            worksheet.Cells["E9"].Value = strNroOrden;
            worksheet.Cells["J2"].Value = dtFecha.ToString("dd");
            worksheet.Cells["L2"].Value = dtFecha.ToString("MM");
            worksheet.Cells["N2"].Value = dtFecha.ToString("yyyy");

            //Datos Informe                        

            if (dtDatosAudiometria.Rows.Count > 0)
            {
                foreach (DataRow fila in dtDatosAudiometria.Rows)
                {
                    // Oido Izquierdo
                    if (string.IsNullOrEmpty(fila["OidoIzq0"].ToString()))
                        worksheet.Cells["Q3"].Value = null;
                    else
                        worksheet.Cells["Q3"].Value = Convert.ToInt32(fila["OidoIzq0"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq32"].ToString()))
                        worksheet.Cells["Q4"].Value = null;
                    else
                        worksheet.Cells["Q4"].Value = Convert.ToInt32(fila["OidoIzq32"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq64"].ToString()))
                        worksheet.Cells["Q5"].Value = null;
                    else
                        worksheet.Cells["Q5"].Value = Convert.ToInt32(fila["OidoIzq64"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq128"].ToString()))
                        worksheet.Cells["Q6"].Value = 20;
                    else
                        worksheet.Cells["Q6"].Value = Convert.ToInt32(fila["OidoIzq128"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq256"].ToString()))
                        worksheet.Cells["Q7"].Value = 20;
                    else
                        worksheet.Cells["Q7"].Value = Convert.ToInt32(fila["OidoIzq256"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq512"].ToString()))
                        worksheet.Cells["Q8"].Value = 20;
                    else
                        worksheet.Cells["Q8"].Value = Convert.ToInt32(fila["OidoIzq512"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq1024"].ToString()))
                        worksheet.Cells["Q9"].Value = 20;
                    else
                        worksheet.Cells["Q9"].Value = Convert.ToInt32(fila["OidoIzq1024"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq2048"].ToString()))
                        worksheet.Cells["Q10"].Value = 20;
                    else
                        worksheet.Cells["Q10"].Value = Convert.ToInt32(fila["OidoIzq2048"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq4096"].ToString()))
                        worksheet.Cells["Q11"].Value = 20;
                    else
                        worksheet.Cells["Q11"].Value = Convert.ToInt32(fila["OidoIzq4096"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq8192"].ToString()))
                        worksheet.Cells["Q12"].Value = 20;
                    else
                        worksheet.Cells["Q12"].Value = Convert.ToInt32(fila["OidoIzq8192"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq16334"].ToString()))
                        worksheet.Cells["Q13"].Value = null;
                    else
                        worksheet.Cells["Q13"].Value = Convert.ToInt32(fila["OidoIzq16334"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoIzq20000"].ToString()))
                        worksheet.Cells["Q14"].Value = null;
                    else
                        worksheet.Cells["Q14"].Value = Convert.ToInt32(fila["OidoIzq20000"].ToString());

                    // Oido Derecho
                    if (string.IsNullOrEmpty(fila["OidoDer0"].ToString()))
                        worksheet.Cells["R3"].Value = null;
                    else
                        worksheet.Cells["R3"].Value = Convert.ToInt32(fila["OidoDer0"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer32"].ToString()))
                        worksheet.Cells["R4"].Value = null;
                    else
                        worksheet.Cells["R4"].Value = Convert.ToInt32(fila["OidoDer32"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer64"].ToString()))
                        worksheet.Cells["R5"].Value = null;
                    else
                        worksheet.Cells["R5"].Value = Convert.ToInt32(fila["OidoDer64"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer128"].ToString()))
                        worksheet.Cells["R6"].Value = 18;
                    else
                        worksheet.Cells["R6"].Value = Convert.ToInt32(fila["OidoDer128"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer256"].ToString()))
                        worksheet.Cells["R7"].Value = 18;
                    else
                        worksheet.Cells["R7"].Value = Convert.ToInt32(fila["OidoDer256"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer512"].ToString()))
                        worksheet.Cells["R8"].Value = 18;
                    else
                        worksheet.Cells["R8"].Value = Convert.ToInt32(fila["OidoDer512"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer1024"].ToString()))
                        worksheet.Cells["R9"].Value = 18;
                    else
                        worksheet.Cells["R9"].Value = Convert.ToInt32(fila["OidoDer1024"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer2048"].ToString()))
                        worksheet.Cells["R10"].Value = 18;
                    else
                        worksheet.Cells["R10"].Value = Convert.ToInt32(fila["OidoDer2048"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer4096"].ToString()))
                        worksheet.Cells["R11"].Value = 18;
                    else
                        worksheet.Cells["R11"].Value = Convert.ToInt32(fila["OidoDer4096"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer8192"].ToString()))
                        worksheet.Cells["R12"].Value = 18;
                    else
                        worksheet.Cells["R12"].Value = Convert.ToInt32(fila["OidoDer8192"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer16334"].ToString()))
                        worksheet.Cells["R13"].Value = null;
                    else
                        worksheet.Cells["R13"].Value = Convert.ToInt32(fila["OidoDer16334"].ToString());

                    if (string.IsNullOrEmpty(fila["OidoDer20000"].ToString()))
                        worksheet.Cells["R14"].Value = null;
                    else
                        worksheet.Cells["R14"].Value = Convert.ToInt32(fila["OidoDer20000"].ToString());
                }
            }

            // Datos diagnostico
            worksheet.Cells["B41"].Value = strDiagnostico;

            strPathFirma = PathFirmaProfesional();

            if (!string.IsNullOrEmpty(strPathFirma))
            {
                InsertarFirma01(strPathFirma, worksheet, workbook);
            }

            //pgbPanelCarga.Visible = false;
        }

        private void InsertarFirma01(string strFirma, Worksheet worksheet01, IWorkbook workbook01)
        {
            string imageUri = strFirma;

            SpreadsheetImageSource imageSource = SpreadsheetImageSource.FromUri(imageUri, workbook01);
            workbook.Unit = DevExpress.Office.DocumentUnit.Point;

            workbook.BeginUpdate();

            try
            {
                worksheet01.Pictures.AddPicture(imageSource, 310, 666, 130, 90);
            }
            finally
            {
                workbook.EndUpdate();
            }
        }

        private string NombreUsuarioSistema()
        {
            reporte.AudiometriaDiagnostico(dtFecha, strNroOrden);
            string strUsuario = "";

            foreach (DataRow fila in dtDatosAudiometria.Rows)
            {
                strUsuario = fila["Usuario"].ToString();
            }

            return strUsuario;
        }

        private string PathFirmaProfesional()
        {
            string strPath = "";
            CapaNegocioMepryl.UsuarioSistema usuario = new CapaNegocioMepryl.UsuarioSistema();
            strPath = usuario.FirmaProfesional(NombreUsuarioSistema());

            return strPath;
        }

        public void GuardarDatosPdf()
        {
            string strArchivoAudiometria = "";

            if (strTipoPaciente == "L")
            {
                strArchivoAudiometria = reporte.ReporteSalida("AUDIOMETRIA", false, dtFecha, GenerarNombreReporte());
            }
            else
            {
                strArchivoAudiometria = reporte.ReporteSalida("AUDIOMETRIA", true, dtFecha, GenerarNombreReporte());
            }

            using (FileStream pdfFileStream = new FileStream(strArchivoAudiometria, FileMode.Create))
            {
                workbook.ExportToPdf(pdfFileStream);
            }
        }

        private string GenerarNombreReporte()
        {
            string strNombreReporte = strNroOrden + "-" + Convert.ToDateTime(dtFecha.ToShortDateString()).ToString("ddMMyyyy") + "-" + strApellido + " " + strNombre + ".pdf";
            // Sanitizar el nombre del archivo
            return SanitizarNombreArchivo(strNombreReporte);
        }

        // Elimina caracteres inválidos para nombres de archivo en Windows
        private string SanitizarNombreArchivo(string nombre)
        {
            foreach (char c in InvalidFileNameChars)
            {
                nombre = nombre.Replace(c.ToString(), "_");
            }
            return nombre;
        }
    }

}