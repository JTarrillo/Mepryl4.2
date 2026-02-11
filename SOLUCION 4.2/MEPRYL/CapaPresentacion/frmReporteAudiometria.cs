using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using System.IO;
using CapaPresentacionBase;
using Comunes;
using System.Reflection;

namespace CapaPresentacion
{
    public partial class frmReporteAudiometria : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.Reportes reporte;

        IWorkbook workbook;        
        Worksheet worksheet;
        string strNroOrden = "";
        DateTime dtFecha = DateTime.Now;
        string strTipoPac;
        string strApellido = "";
        string strdni;
        string strNombre = "";
        string strEmpresa = "";
        string strDiagnostico = "";
        string strIdExamenLaboral = "";
        bool blnEstadoRevision = false;
        DataTable dtDatosAudiometria = null;        
               
        public frmReporteAudiometria()
        {
            InitializeComponent();
            //AbrirArchivoExcel();
        }

        public frmReporteAudiometria(frmBasePrincipal parentForm, bool blnModoVista)
        {
            InitializeComponent();            
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;            
            reporte = new CapaNegocioMepryl.Reportes();
            ModoVista(blnModoVista);
            //AbrirArchivoExcel();
        }

        public frmReporteAudiometria(bool blnModoVista)
        {
            InitializeComponent();            
            reporte = new CapaNegocioMepryl.Reportes();
            ModoVista(blnModoVista);
            //AbrirArchivoExcel();
        }
        public frmReporteAudiometria(bool blnModoVista, frmExamenLaboral ExLab)
        {
            InitializeComponent();
            reporte = new CapaNegocioMepryl.Reportes();
            ModoVista(blnModoVista);
            //AbrirArchivoExcel();
            strTipoPac = "L";
        }

        private void ModoVista(bool blnVerPanel)
        {
            panel3.Visible = blnVerPanel;            
            
            if(blnVerPanel == false)
            {
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Size = new Size(913, 611);
                btnGuardarDatosExcel.Visible = true;
                btnCrearReporte.Visible = true;
            }else
            {
                chkRevisar.Visible = true;
            }
        }

        private void AbrirArchivoExcel()
        {
            using (FileStream stream = new FileStream(@"P:\Temporal\PLANTILLA REPORTE INFORMES\Informe Audio Digitalizada2.xlsx", FileMode.Open))
            {
                spreadsheetControl1.LoadDocument(stream, DocumentFormat.OpenXml);
                workbook = spreadsheetControl1.Document;
                worksheet = workbook.Worksheets[0]; // 1era Hoja del libro de excel

                spreadsheetCommandBarCheckItem2.Checked = false;                
            }
        }

        public void GuardarDatosPdf()
        {
            string strArchivoAudiometria = reporte.ReporteSalida("AUDIOMETRIA", false, dtFecha, GenerarNombreReporte());

            using (FileStream pdfFileStream = new FileStream(strArchivoAudiometria, FileMode.Create))
            {
                spreadsheetControl1.ExportToPdf(pdfFileStream);                
            }
        }

        private string GenerarNombreReporte()
        {
            string strNombreReporte = "";
            strNombreReporte = strNroOrden + "-" + Convert.ToDateTime(dtFecha.ToShortDateString()).ToString("ddMMyyyy") + "-" + strApellido + " " + strNombre + ".pdf";

            return strNombreReporte;
        }

        private void btnGuardarDatosExcel_Click(object sender, EventArgs e)
        {            
            InsertarDatos(RecuperarDatos());
            this.Close();
        }

        public bool EstablcerDatos()
        {
            bool blnResultado = false;

            dtDatosAudiometria = null;
            //dtDatosAudiometria = reporte.AudiometriaEstablcerDatos(dtFecha, strNroOrden);
            dtDatosAudiometria = reporte.AudiometriaDiagnostico(dtFecha, strNroOrden);
            string strPathFirma = "";

            //Datos Cabecera
            if (strApellido.Length > 26)
                worksheet.Cells["I4"].Value = strApellido.Substring(0, 26);
            else
                worksheet.Cells["I4"].Value = strApellido;
            if(strNombre.Length > 26)
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
                    chkRevisar.Checked = Convert.ToBoolean(fila["Revisado"].ToString());

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
            blnResultado = true;
            return blnResultado;
        }

        private void InsertarFirma01(string strFirma, Worksheet worksheet01, IWorkbook workbook01)
        {
            string imageUri = strFirma;

            SpreadsheetImageSource imageSource = SpreadsheetImageSource.FromUri(imageUri, workbook01);
            workbook.Unit = DevExpress.Office.DocumentUnit.Point;

            workbook.BeginUpdate();

            try
            {
                worksheet01.Pictures.AddPicture(imageSource, 320, 685, 110, 70);
            }
            finally
            {
                workbook.EndUpdate();
            }
        }

        public List<string> RecuperarDatos()
        {
            
            List<string> strValor = new List<string>();

            strValor.Add(strNroOrden);
            strValor.Add(dtFecha.ToString());
            strValor.Add(strApellido);
            strValor.Add(strNombre);
            strValor.Add(strEmpresa);
            strValor.Add(strDiagnostico);
                                    
            // Oido Derecho
            if (string.IsNullOrEmpty(worksheet.Cells["Q3"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["Q3"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["Q4"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["Q4"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["Q5"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["Q5"].Value.ToString());
            strValor.Add(worksheet.Cells["Q6"].Value.ToString());
            strValor.Add(worksheet.Cells["Q7"].Value.ToString());
            strValor.Add(worksheet.Cells["Q8"].Value.ToString());
            strValor.Add(worksheet.Cells["Q9"].Value.ToString());
            strValor.Add(worksheet.Cells["Q10"].Value.ToString());
            strValor.Add(worksheet.Cells["Q11"].Value.ToString());
            strValor.Add(worksheet.Cells["Q12"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["Q13"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["Q13"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["Q14"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["Q14"].Value.ToString());

            // Oido Izquierdo
            if (string.IsNullOrEmpty(worksheet.Cells["R3"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["R3"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["R4"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["R4"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["R5"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["R5"].Value.ToString());
            strValor.Add(worksheet.Cells["R6"].Value.ToString());
            strValor.Add(worksheet.Cells["R7"].Value.ToString());
            strValor.Add(worksheet.Cells["R8"].Value.ToString());
            strValor.Add(worksheet.Cells["R9"].Value.ToString());
            strValor.Add(worksheet.Cells["R10"].Value.ToString());
            strValor.Add(worksheet.Cells["R11"].Value.ToString());
            strValor.Add(worksheet.Cells["R12"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["R13"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["R13"].Value.ToString());
            if (string.IsNullOrEmpty(worksheet.Cells["R14"].Value.ToString()))
                strValor.Add("''");
            else
                strValor.Add(worksheet.Cells["R14"].Value.ToString());

            strValor.Add(strIdExamenLaboral); //Guarda el ID examen laboral

            strValor.Add(strTipoPac);

            return strValor;
        }

        public void CargarParametrosEntrada(string NroOrden, DateTime Fecha, string dni, string Empresa, string Diagnostico, string IdExamenLaboral)
        {
            strNroOrden = NroOrden;
            dtFecha = Fecha;
            strdni = dni;
            strEmpresa = Empresa;
            strDiagnostico = Diagnostico;
            strIdExamenLaboral = IdExamenLaboral;

            DataTable dt = reporte.AudiometriaApellidoNombre(strdni);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strApellido = dt.Rows[i][0].ToString();
                    strNombre = dt.Rows[i][1].ToString();
                }
            }
        }

        private void CargarDatosPaciente()
        {            
            DataTable dt = reporte.AudiometriaDiagnostico(dtFecha, strNroOrden); 

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    strNombre = fila["Nombre"].ToString();
                    strApellido = fila["Apellido"].ToString();
                    strEmpresa = fila["Empresa"].ToString();
                    strDiagnostico = fila["Diagnostico"].ToString();
                    strIdExamenLaboral = fila["IdExamenLaboral"].ToString();
                }
            }
        }
                
        private void CargarListView()
      {
            dtDatosAudiometria = null;
            dtDatosAudiometria = reporte.AudiometriaEstablcerDatos(dtFecha);
            lstListaPaciente.DataSource = dtDatosAudiometria;
            lstListaPaciente.DisplayMember = "NombreApellido";
            lstListaPaciente.ValueMember = "NroOrden";
            if(lstListaPaciente.Items.Count > 0)
                lstListaPaciente.SelectedIndex = 0;

            gbActualizando.Visible = false;
        }

        private void lstListaPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbActualizando.Visible = true;

            if (panel3.Visible == true)
            {
                strNroOrden = lstListaPaciente.SelectedValue.ToString();
                dtFecha = dtpCalendario.SelectionRange.Start;
                CargarDatosPaciente();
                EstablcerDatos();
            }

            gbActualizando.Visible = false;
        }

        private void dtpCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (panel3.Visible == true)
            {
                MostrarPanelActualiza();
                dtFecha = dtpCalendario.SelectionRange.Start;
                CargarListView();
                
            }
        }

        private void btnCrearReporte_Click(object sender, EventArgs e)
        {
            GuardarDatosPdf();
        }

        private void InsertarDatos(List<string> strDatos)
        {
            reporte.InsertarDatos(strDatos);
        }

        private void bntSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    EstablcerDatos();
                    GuardarDatosPdf();
                    blnResultado = true;
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
                                EstablcerDatos();
                                GuardarDatosPdf();
                                blnResultado = true;
                            }
                        }
                    }
                }
            }

            return blnResultado;
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
        
        private void chkRevisar_Click(object sender, EventArgs e)
        {
            //reporte.ActualizaRevisado(strIdExamenLaboral, Comunes.UsuarioGlobal.Usuario, chkRevisar.Checked, strDiagnostico, strTipoPaciente);
        }

        private void chkRevisar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRevisar.Checked == true)
            {
                chkRevisar.Image = Image.FromFile("P:\\img-system\\mCheck01_36x36.png");
                chkRevisar.Text = "Revisado";
            }
            else
            {
                chkRevisar.Image = Image.FromFile("P:\\img-system\\mCheck02_36x36.png");
                chkRevisar.Text = "Revisar";
            }
        }

        private void frmReporteAudiometria_Shown(object sender, EventArgs e)
        {
            AbrirArchivoExcel();

            if (panel3.Visible == true)
            {
                CargarListView();
            }
            else
            {
                EstablcerDatos();
            }            
            
            gbActualizando.Visible = false;
        }

        private void frmReporteAudiometria_Load(object sender, EventArgs e)
        {
            //EstablcerDatos(); 
            MostrarPanelActualiza();
            //AbrirArchivoExcel();

                              
            
        }

        private void MostrarPanelActualiza()
        {
            gbActualizando.Visible = true;
            pbActualizando.Value = 0;
            pbActualizando.Maximum = 101;
            for (int i = 1; i <= 100; i++)
            {
                pbActualizando.Value = i;
                Thread.Sleep(25);
            }
            gbActualizando.Visible = true;
            
        }
    }
}
