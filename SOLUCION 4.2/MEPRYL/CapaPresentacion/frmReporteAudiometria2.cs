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
    public partial class frmReporteAudiometria2 : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.Reportes reporte;
        private ReporteAudiometria ReporteAudio;

        IWorkbook workbook;        
        Worksheet worksheet;
        string strNroOrden = "";
        DateTime dtFecha = DateTime.Now;
        string strApellido = "";
        string strdni;
        string strNombre = "";
        string strEmpresa = "";
        string strDiagnostico = "";
        string strTipoExamen = "";
        string strTipoPaciente = "";
        bool blnEstadoRevision = false;
        DataTable dtDatosAudiometria = null;
        bool blnItemsCargados = false;
        string strTipoUsuario = "";
        int intIndexLista = 0;
               
        public frmReporteAudiometria2()
        {
            InitializeComponent();
            //AbrirArchivoExcel();
        }

        public frmReporteAudiometria2(frmBasePrincipal parentForm, bool blnModoVista)
        {
            InitializeComponent();            
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;            
            reporte = new CapaNegocioMepryl.Reportes();
            ModoVista(blnModoVista);
            //AbrirArchivoExcel();            
        }

        public frmReporteAudiometria2(bool blnModoVista)
        {
            InitializeComponent();            
            reporte = new CapaNegocioMepryl.Reportes();
            ModoVista(blnModoVista);
            //AbrirArchivoExcel();
            
        }

        private void ModoVista(bool blnVerPanel)
        {
            panel3.Visible = blnVerPanel;
            FormatoListView();

            if (blnVerPanel == false)
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

            PermisosUsuario();
            btnGuardarDatosExcel.Enabled = false;
            chkRevisar.Enabled = false;
            pnlPie.Enabled = false;
        }

        private void AbrirArchivoExcel()
        {
            using (FileStream stream = new FileStream(@"P:\Temporal\PLANTILLA REPORTE INFORMES\Informe Audio Digitalizada3.xlsx", FileMode.Open))
            {
                spreadsheetControl1.LoadDocument(stream, DocumentFormat.OpenXml);
                workbook = spreadsheetControl1.Document;
                
                workbook.Worksheets[0].ActiveView.ShowGridlines = false;
                workbook.Worksheets[0].ActiveView.ShowHeadings = false;
                worksheet = workbook.Worksheets[0]; // 1era Hoja del libro de excel

                spreadsheetControl1 = null;
                //spreadsheetCommandBarCheckItem2.Checked = false;                
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
            PintarBlancoTextBox();

            if (TextBoxRangoNumeros())
            {
                //MensajeDefectoDictamen();
                InsertarDatos(RecuperarDatos());
                VerificaEstudioCargado();
                CambiarColorLista();
                lstLista.Select();
            }
            //this.Close();
        }

        public bool EstablcerDatos()
        {
            bool blnResultado = false;

            dtDatosAudiometria = null;
            //dtDatosAudiometria = reporte.AudiometriaEstablcerDatos(dtFecha, strNroOrden);
            dtDatosAudiometria = reporte.AudiometriaDiagnostico(dtFecha, strNroOrden);
            string strPathFirma = "";

            //Datos Cabecera
            //if (strApellido.Length > 26)
            //    worksheet.Cells["I4"].Value = strApellido.Substring(0, 26);
            //else
            //    worksheet.Cells["I4"].Value = strApellido;
            //if(strNombre.Length > 26)
            //    worksheet.Cells["I7"].Value = strNombre.Substring(0, 26);
            //else
            //    worksheet.Cells["I7"].Value = strNombre;
            //if (strEmpresa.Length > 26)
            //    worksheet.Cells["I10"].Value = strEmpresa.Substring(0, 26);
            //else
            //    worksheet.Cells["I10"].Value = strEmpresa;
            //worksheet.Cells["E9"].Value = strNroOrden;
            //worksheet.Cells["J2"].Value = dtFecha.ToString("dd");
            //worksheet.Cells["L2"].Value = dtFecha.ToString("MM");
            //worksheet.Cells["N2"].Value = dtFecha.ToString("yyyy");

            txtNombre.Text = strApellido + " " + strNombre;
            txtEmpresa.Text = strEmpresa;
            txtNroOrden.Text = strNroOrden;

            //Datos Informe                        

            if (dtDatosAudiometria.Rows.Count > 0)
            {
                foreach (DataRow fila in dtDatosAudiometria.Rows)
                {
                    if (string.IsNullOrEmpty(fila["Revisado"].ToString())) {
                        chkRevisar.Checked = false;
                    }
                    else
                    {
                        chkRevisar.Checked = Convert.ToBoolean(fila["Revisado"].ToString());
                    }
                    
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
                    {
                        worksheet.Cells["Q6"].Value = 20;
                        txt128IZQ.Text = "20";
                    }
                    else
                    {
                        worksheet.Cells["Q6"].Value = Convert.ToInt32(fila["OidoIzq128"].ToString());
                        txt128IZQ.Text = fila["OidoIzq128"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoIzq256"].ToString()))
                    {
                        worksheet.Cells["Q7"].Value = 20;
                        txt256IZQ.Text = "20";
                    }
                    else
                    {
                        worksheet.Cells["Q7"].Value = Convert.ToInt32(fila["OidoIzq256"].ToString());
                        txt256IZQ.Text = fila["OidoIzq256"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoIzq512"].ToString()))
                    {
                        worksheet.Cells["Q8"].Value = 20;
                        txt512IZQ.Text = "20";
                    }
                    else
                    {
                        worksheet.Cells["Q8"].Value = Convert.ToInt32(fila["OidoIzq512"].ToString());
                        txt512IZQ.Text = fila["OidoIzq512"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoIzq1024"].ToString()))
                    {
                        worksheet.Cells["Q9"].Value = 20;
                        txt1024IZQ.Text = "20";
                    }
                    else
                    {
                        worksheet.Cells["Q9"].Value = Convert.ToInt32(fila["OidoIzq1024"].ToString());
                        txt1024IZQ.Text = fila["OidoIzq1024"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoIzq2048"].ToString()))
                    {
                        worksheet.Cells["Q10"].Value = 20;
                        txt2048IZQ.Text = "20";
                    }
                    else
                    {
                        worksheet.Cells["Q10"].Value = Convert.ToInt32(fila["OidoIzq2048"].ToString());
                        txt2048IZQ.Text = fila["OidoIzq2048"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoIzq4096"].ToString()))
                    {
                        worksheet.Cells["Q11"].Value = 20;
                        txt4096IZQ.Text = "20";
                    }
                    else
                    {
                        worksheet.Cells["Q11"].Value = Convert.ToInt32(fila["OidoIzq4096"].ToString());
                        txt4096IZQ.Text = fila["OidoIzq4096"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoIzq8192"].ToString()))
                    {
                        worksheet.Cells["Q12"].Value = 20;
                        txt8192IZQ.Text = "20";
                    }
                    else
                    {
                        worksheet.Cells["Q12"].Value = Convert.ToInt32(fila["OidoIzq8192"].ToString());
                        txt8192IZQ.Text = fila["OidoIzq8192"].ToString();
                    }

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
                    {
                        worksheet.Cells["R6"].Value = 18;
                        txt128DER.Text = "18";
                    }
                    else
                    {
                        worksheet.Cells["R6"].Value = Convert.ToInt32(fila["OidoDer128"].ToString());
                        txt128DER.Text = fila["OidoDer128"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoDer256"].ToString()))
                    {
                        worksheet.Cells["R7"].Value = 18;
                        txt256DER.Text = "18";
                    }
                    else
                    {
                        worksheet.Cells["R7"].Value = Convert.ToInt32(fila["OidoDer256"].ToString());
                        txt256DER.Text = fila["OidoDer256"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoDer512"].ToString()))
                    {
                        worksheet.Cells["R8"].Value = 18;
                        txt512DER.Text = "18";
                    }
                    else
                    {
                        worksheet.Cells["R8"].Value = Convert.ToInt32(fila["OidoDer512"].ToString());
                        txt512DER.Text = fila["OidoDer512"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoDer1024"].ToString()))
                    {
                        worksheet.Cells["R9"].Value = 18;
                        txt1024DER.Text = "18";
                    }
                    else
                    {
                        worksheet.Cells["R9"].Value = Convert.ToInt32(fila["OidoDer1024"].ToString());
                        txt1024DER.Text = fila["OidoDer1024"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoDer2048"].ToString()))
                    {
                        worksheet.Cells["R10"].Value = 18;
                        txt2048DER.Text = "18";
                    }
                    else
                    {
                        worksheet.Cells["R10"].Value = Convert.ToInt32(fila["OidoDer2048"].ToString());
                        txt2048DER.Text = fila["OidoDer2048"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoDer4096"].ToString()))
                    {
                        worksheet.Cells["R11"].Value = 18;
                        txt4096DER.Text = "18";
                    }
                    else
                    {
                        worksheet.Cells["R11"].Value = Convert.ToInt32(fila["OidoDer4096"].ToString());
                        txt4096DER.Text = fila["OidoDer4096"].ToString();
                    }

                    if (string.IsNullOrEmpty(fila["OidoDer8192"].ToString()))
                    {
                        worksheet.Cells["R12"].Value = 18;
                        txt8192DER.Text = "18";
                    }
                    else
                    {
                        worksheet.Cells["R12"].Value = Convert.ToInt32(fila["OidoDer8192"].ToString());
                        txt8192DER.Text = fila["OidoDer8192"].ToString();
                    }

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
            txtDiagnostico.Text = strDiagnostico;
            
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

            strDiagnostico = txtDiagnostico.Text;

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

            strValor.Add(strTipoExamen); //Guarda el ID examen laboral
            strValor.Add(strTipoPaciente);

            return strValor;
        }

        public void CargarParametrosEntrada(string NroOrden, DateTime Fecha, string dni, string Empresa, string Diagnostico, string IdExamenLaboral)
        {
            strNroOrden = NroOrden;
            dtFecha = Fecha;
            strdni = dni;
            strEmpresa = Empresa;
            strDiagnostico = Diagnostico;
            strTipoExamen = IdExamenLaboral;

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

            LimpiarVariablesGlobales();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    strNombre = fila["Nombre"].ToString();
                    strApellido = fila["Apellido"].ToString();
                    strEmpresa = fila["Empresa"].ToString();
                    strDiagnostico = fila["Diagnostico"].ToString();
                    //strTipoExamen = fila["IdExamenLaboral"].ToString();
                    strTipoExamen = fila["IdTipoExamen"].ToString();
                    strTipoPaciente = fila["TipoPaciente"].ToString();
                }
            }
        }
      
        private void FormatoListView()
        {
            lstLista.View = View.Details;            
            lstLista.Columns.Add("Nro");
            lstLista.Columns.Add("Ord");
            lstLista.Columns.Add("Nro");
            lstLista.Columns.Add("Paciente");
            lstLista.Columns[0].Width = 0;
            lstLista.Columns[1].Width = 40;
            lstLista.Columns[2].Width = 40;
            lstLista.Columns[3].Width = 210;
        }
                         
      private void CargarListView()
      {
            dtDatosAudiometria = null;
            dtDatosAudiometria = reporte.AudiometriaEstablcerDatos(dtFecha);
            //lstListaPaciente.DataSource = dtDatosAudiometria;
            //lstListaPaciente.DisplayMember = "NombreApellido";
            //lstListaPaciente.ValueMember = "NroOrden";
            //if (lstListaPaciente.Items.Count > 0)
            //{
            //    //lstListaPaciente.SelectedIndex = 0;
            //    //lstListaPaciente.TopIndex = lstListaPaciente.SelectedIndex;
            //    lstListaPaciente.ClearSelected();
            //    blnItemsCargados = true;
            //}

            // provando listview           

            lstLista.Items.Clear();

            if (dtDatosAudiometria.Rows.Count > 0)
            {
                foreach (DataRow fila in dtDatosAudiometria.Rows)
                {
                    ListViewItem item = new ListViewItem(fila["NroOrden"].ToString());
                    item.SubItems.Add(fila["Ingreso"].ToString());
                    item.SubItems.Add(fila["NroOrden"].ToString());
                    item.SubItems.Add(fila["Paciente"].ToString());
                    lstLista.Items.Add(item);
                }

                blnItemsCargados = true;
                CambiarColorLista();
            }

            gbActualizando.Visible = false;
        }

        private void lstListaPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbActualizando.Visible = true;

            // if (panel3.Visible == true)
            if (panel3.Visible == true && blnItemsCargados == true)
            {
                strNroOrden = lstListaPaciente.SelectedValue.ToString();
                dtFecha = dtpCalendario.SelectionRange.Start;
                CargarDatosPaciente();
                EstablcerDatos();
                VerificaEstudioCargado();
            }

            if (blnItemsCargados)
            {
                btnGuardarDatosExcel.Enabled = true;
                //chkRevisar.Enabled = true;
            }else
            {
                btnGuardarDatosExcel.Enabled = false;
                //chkRevisar.Enabled = false;
            }

            gbActualizando.Visible = false;
        }

        private void dtpCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (panel3.Visible == true)
            {
                blnItemsCargados = false;
                MostrarPanelActualiza();
                dtFecha = dtpCalendario.SelectionRange.Start;
                LimpiarVariablesGlobales();
                CargarListView();
                btnGuardarDatosExcel.Enabled = false;
                chkRevisar.Enabled = false;
                pnlPie.Enabled = false;                
            }
        }

        private void btnCrearReporte_Click(object sender, EventArgs e)
        {
            //GuardarDatosPdf();
            bool blnEstado = false;
            string strReporteSalida;
            ReporteAudio = new ReporteAudiometria();
            blnEstado = ReporteAudio.GeneraAutoReporteAudiometria(dtFecha, strNroOrden);

            strReporteSalida = reporte.ReporteSalida("AUDIOMETRIA", false, dtFecha, GenerarNombreReporte());

            if (blnEstado)
            {
                MessageBox.Show("El reporte se ha generado correctamente en...\n\n" + strReporteSalida, "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El reporte no se ha podido generar." + GenerarNombreReporte(), "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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
            string strDiagnosticoAux = "";

            if (!string.IsNullOrEmpty(txtDiagnostico.Text))
            {
                if (chkRevisar.Checked == false)
                {
                    txtDiagnostico.Text = "";
                }

                strDiagnosticoAux = txtDiagnostico.Text;

                if (strDiagnosticoAux.Length > 254)
                {
                    strDiagnosticoAux = txtDiagnostico.Text.Substring(0, 254);
                }

                if (reporte.ActualizaRevisado(strTipoExamen, Comunes.UsuarioGlobal.Usuario, chkRevisar.Checked, strDiagnosticoAux, strTipoPaciente))
                {
                    CambiarColorLista();
                    MessageBox.Show("Datos guardados correctamente.", "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    lstLista.Select();
                }                                
            }
            else
            {
                MessageBox.Show("Debe ingresar el diagnóstico del paciente.", "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                chkRevisar.Checked = false;
                txtDiagnostico.Select();
            }
        }

        private void chkRevisar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRevisar.Checked == true)
            {
                chkRevisar.Image = Image.FromFile("P:\\img-system\\mCheck01_36x36.png");
                chkRevisar.Text = "Revisado";
                MensajeDefectoDictamen();
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
            //blnItemsCargados = true;
            
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

        // OIDO Izquierdo
        private void txt128IZQ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt128IZQ.Text))
            {
                worksheet.Cells["Q6"].Value = int.Parse(txt128IZQ.Text);
            }
            else
            {
                worksheet.Cells["Q6"].Value = 0;
            }
        }

        private void txt256IZQ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt256IZQ.Text))
            {
                worksheet.Cells["Q7"].Value = int.Parse(txt256IZQ.Text);
            }
            else
            {
                worksheet.Cells["Q7"].Value = 0;
            }
        }

        private void txt512IZQ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt512IZQ.Text))
            {
                worksheet.Cells["Q8"].Value = int.Parse(txt512IZQ.Text);
            }
            else
            {
                worksheet.Cells["Q8"].Value =0;
            }
        }

        private void txt1024IZQ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt1024IZQ.Text))
            {
                worksheet.Cells["Q9"].Value = int.Parse(txt1024IZQ.Text);
            }
            else
            {
                worksheet.Cells["Q9"].Value = 0;
            }
        }

        private void txt2048IZQ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt2048IZQ.Text))
            {
                worksheet.Cells["Q10"].Value = int.Parse(txt2048IZQ.Text);
            }
            else
            {
                worksheet.Cells["Q10"].Value = 0;
            }
        }

        private void txt4096IZQ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt4096IZQ.Text))
            {
                worksheet.Cells["Q11"].Value = int.Parse(txt4096IZQ.Text);
            }
            else
            {
                worksheet.Cells["Q11"].Value = 0;
            }
        }

        private void txt8192IZQ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt8192IZQ.Text))
            {
                worksheet.Cells["Q12"].Value = int.Parse(txt8192IZQ.Text);
            }
            else
            {
                worksheet.Cells["Q12"].Value = 0;
            }
        }

        // OIDO Derecho
        private void txt128DER_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt128DER.Text))
            {
                worksheet.Cells["R6"].Value = int.Parse(txt128DER.Text);
            }
            else
            {
                worksheet.Cells["R6"].Value = 0;
            }
        }

        private void txt256DER_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt256DER.Text))
            {
                worksheet.Cells["R7"].Value = int.Parse(txt256DER.Text);
            }
            else
            {
                worksheet.Cells["R7"].Value = 0;
            }
        }

        private void txt512DER_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt512DER.Text))
            {
                worksheet.Cells["R8"].Value = int.Parse(txt512DER.Text);
            }
            else
            {
                worksheet.Cells["R8"].Value = 0;
            }
        }

        private void txt1024DER_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt1024DER.Text))
            {
                worksheet.Cells["R9"].Value = int.Parse(txt1024DER.Text);
            }
            else
            {
                worksheet.Cells["R9"].Value = 0;
            }
        }

        private void txt2048DER_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt2048DER.Text))
            {
                worksheet.Cells["R10"].Value = int.Parse(txt2048DER.Text);
            }
            else
            {
                worksheet.Cells["R10"].Value = 0;
            }
        }

        private void txt4096DER_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt4096DER.Text))
            {
                worksheet.Cells["R11"].Value = int.Parse(txt4096DER.Text);
            }
            else
            {
                worksheet.Cells["R11"].Value = 0;
            }

        }

        private void txt8192DER_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt8192DER.Text))
            {
                worksheet.Cells["R12"].Value = int.Parse(txt8192DER.Text);
            }
            else
            {
                worksheet.Cells["R12"].Value = 0;
            }
        }

        private void txt128IZQ_Enter(object sender, EventArgs e)
        {
            txt128IZQ.SelectionStart = 0;
            txt128IZQ.SelectionLength = txt128IZQ.Text.Length;
        }

        private void txt128IZQ_Click(object sender, EventArgs e)
        {
            txt128IZQ.SelectAll();
        }

        private void txt256IZQ_Enter(object sender, EventArgs e)
        {
            txt256IZQ.SelectAll();
        }

        private void txt512IZQ_Enter(object sender, EventArgs e)
        {
            txt512IZQ.SelectAll();
        }

        private void txt1024IZQ_Enter(object sender, EventArgs e)
        {
            txt1024IZQ.SelectAll();
        }

        private void txt2048IZQ_Enter(object sender, EventArgs e)
        {
            txt128IZQ.SelectAll();
        }

        private void txt4096IZQ_Enter(object sender, EventArgs e)
        {
            txt4096IZQ.SelectAll();
        }

        private void txt8192IZQ_Enter(object sender, EventArgs e)
        {
            txt8192IZQ.SelectAll();
        }

        private void txt128DER_Enter(object sender, EventArgs e)
        {
            txt128DER.SelectAll();
        }

        private void txt256DER_Enter(object sender, EventArgs e)
        {
            txt256DER.SelectAll();
        }

        private void txt512DER_Enter(object sender, EventArgs e)
        {
            txt512DER.SelectAll();
        }

        private void txt1024DER_Enter(object sender, EventArgs e)
        {
            txt1024DER.SelectAll();
        }

        private void txt2048DER_Enter(object sender, EventArgs e)
        {
            txt2048DER.SelectAll();
        }

        private void txt4096DER_Enter(object sender, EventArgs e)
        {
            txt4096DER.SelectAll();
        }

        private void txt8192DER_Enter(object sender, EventArgs e)
        {
            txt8192DER.SelectAll();
        }

        private void txtDiagnostico_Enter(object sender, EventArgs e)
        {
            txtDiagnostico.SelectAll();
        }

        private void PintarDeColor(DateTime fecha, string NroOrden, int IndexList)
        {
            //lstListaPaciente
            
        }

        private void VerificaEstudioCargado()
        {
            bool blnEstado = false;

            blnEstado = reporte.VerificaEstudioAudioCargado(strTipoExamen);

            chkRevisar.Enabled = blnEstado;
            if (strTipoUsuario == "MEDICOS" || strTipoUsuario == "ADMINISTRADOR")
            {
                pnlPie.Enabled = blnEstado;
                chkRevisar.Visible = true;
            }
            else
            {
                pnlPie.Enabled = false;
                chkRevisar.Visible = false;
            }
        }

        private void LimpiarVariablesGlobales()
        {
            strNombre = "";
            strApellido = "";
            strEmpresa = "";
            strDiagnostico = "";
            strTipoExamen = "";

            txtNombre.Text = "";
            txtNroOrden.Text = "";
            txtEmpresa.Text = "";
            txtDiagnostico.Text = "";
            strTipoPaciente = "";
        }        

        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbActualizando.Visible = true;

            // if (panel3.Visible == true)
            try
            {
                PintarBlancoTextBox();

                if (panel3.Visible == true && blnItemsCargados == true)
                {
                    ListViewItem listItem = lstLista.SelectedItems[0];
                    strNroOrden = listItem.SubItems[0].Text.ToString();
                    dtFecha = dtpCalendario.SelectionRange.Start;
                    CargarDatosPaciente();
                    EstablcerDatos();
                    VerificaEstudioCargado();
                }

                if (blnItemsCargados)
                {
                    btnGuardarDatosExcel.Enabled = true;
                    //chkRevisar.Enabled = true;
                }
                else
                {
                    btnGuardarDatosExcel.Enabled = false;
                    //chkRevisar.Enabled = false;
                }               

                VerificaEstudioRevisado();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {

            }

            gbActualizando.Visible = false;
        }

        private void CambiarColorLista()
        {
            dtDatosAudiometria = null;            
            string strNroOrdenCCL = "";

            if (lstLista.Items.Count > 0)
            {
                for (int i = 0; i < lstLista.Items.Count; i++)
                {
                    strNroOrdenCCL = lstLista.Items[i].SubItems[0].Text;

                    dtDatosAudiometria = reporte.AudiometriaEstablcerDatos(dtFecha, strNroOrdenCCL);

                    if (dtDatosAudiometria.Rows.Count > 0)
                    {
                        foreach (DataRow fila in dtDatosAudiometria.Rows)
                        {
                            bool blnValor = Convert.ToBoolean(fila["Revisado"].ToString());

                            if (blnValor)
                                lstLista.Items[i].BackColor = Color.LimeGreen;
                            else
                                lstLista.Items[i].BackColor = Color.Orange;
                        }
                    }

                }

            }
        }

        private void PermisosUsuario()
        {
            CapaNegocioMepryl.UsuarioSistema usuario = new CapaNegocioMepryl.UsuarioSistema();
            DataTable dt = null;

            dt = usuario.ListaPermisoPorNombre(Comunes.UsuarioGlobal.Usuario);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    //btnGuardarDatosExcel.Visible = Convert.ToBoolean(fila["PermisoModificar"].ToString());
                    btnGuardarDatosExcel.Visible = Convert.ToBoolean(fila["PermisoVer"].ToString());
                    chkRevisar.Visible = Convert.ToBoolean(fila["PermisoVer"].ToString());
                    strTipoUsuario = fila["Tipo"].ToString();
                }
            }
        }         

        private void lstLista_Click(object sender, EventArgs e)
        {
            //bool blnRevisado = false;
            //blnRevisado = reporte.EstudioRevisado(strTipoExamen);

            //if (blnRevisado)
            //{
            //    MessageBox.Show("¡Este estudio ya ha sido revisado por un médico! .", "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    if (strTipoUsuario == "MEDICOS" || strTipoUsuario == "ADMINISTRADOR")
            //        btnGuardarDatosExcel.Enabled = true;
            //    else
            //        btnGuardarDatosExcel.Enabled = false;
            //}
            
        }

        private void VerificaEstudioRevisado()
        {
            bool blnRevisado = false;
            blnRevisado = reporte.EstudioRevisado(strTipoExamen);

            if (blnRevisado)
            {
                MessageBox.Show("¡Este estudio ya ha sido revisado por un médico! .", "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (strTipoUsuario == "MEDICOS" || strTipoUsuario == "ADMINISTRADOR")
                    btnGuardarDatosExcel.Enabled = true;
                else
                    btnGuardarDatosExcel.Enabled = false;
            }
        }

        private void ValidaSoloNumeros(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txt512IZQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt128IZQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt128DER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt256IZQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt256DER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt512DER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt1024IZQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt1024DER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt2048IZQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt2048DER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt4096IZQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt4096DER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt8192IZQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private void txt8192DER_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaSoloNumeros(e);
        }

        private bool TextBoxRangoNumeros()
        {
            bool blnEstado = true;

            if (Convert.ToInt32(txt128IZQ.Text) < 20)
            {
                txt128IZQ.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if(Convert.ToInt32(txt256IZQ.Text) < 20)
            {
                txt256IZQ.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt512IZQ.Text) < 20)
            {
                txt512IZQ.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt1024IZQ.Text) < 20)
            {
                txt1024IZQ.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt2048IZQ.Text) < 20)
            {
                txt2048IZQ.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt4096IZQ.Text) < 20)
            {
                txt4096IZQ.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt8192IZQ.Text) < 20)
            {
                txt8192IZQ.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt128DER.Text) < 18)
            {
                txt128DER.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt256DER.Text) < 18)
            {
                txt256DER.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt512DER.Text) < 18)
            {
                txt512DER.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt1024DER.Text) < 18)
            {
                txt1024DER.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt2048DER.Text) < 18)
            {
                txt2048DER.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt4096DER.Text) < 18)
            {
                txt4096DER.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (Convert.ToInt32(txt8192DER.Text) < 18)
            {
                txt8192DER.BackColor = Color.LightYellow;
                blnEstado = false;
            }

            if (!blnEstado)
                MessageBox.Show("¡Compruebe los valores ingresados! .", "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return blnEstado;
        }

        private void PintarBlancoTextBox()
        {
            txt128DER.BackColor = Color.White;
            txt512DER.BackColor = Color.White;
            txt1024DER.BackColor = Color.White;
            txt2048DER.BackColor = Color.White;
            txt4096DER.BackColor = Color.White;
            txt8192DER.BackColor = Color.White;

            txt128IZQ.BackColor = Color.White;
            txt512IZQ.BackColor = Color.White;
            txt1024IZQ.BackColor = Color.White;
            txt2048IZQ.BackColor = Color.White;
            txt4096IZQ.BackColor = Color.White;
            txt8192IZQ.BackColor = Color.White;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarListView();
        }

        private void MensajeDefectoDictamen()
        {
            bool blnResultado = false;

            if (txt128DER.Text != "18") blnResultado = true;
            if (txt512DER.Text != "18" ) blnResultado = true;
            if (txt256DER.Text != "18") blnResultado = true;
            if (txt1024DER.Text != "18") blnResultado = true;
            if (txt2048DER.Text != "18" ) blnResultado = true;
            if (txt4096DER.Text != "18" ) blnResultado = true;
            if (txt8192DER.Text != "18" ) blnResultado = true;

            if (txt128IZQ.Text != "20") blnResultado = true;
            if (txt256IZQ.Text != "20") blnResultado = true;
            if (txt512IZQ.Text != "20") blnResultado = true;
            if (txt1024IZQ.Text != "20") blnResultado = true;
            if (txt2048IZQ.Text != "20") blnResultado = true; 
            if (txt4096IZQ.Text != "20") blnResultado = true;
            if (txt8192IZQ.Text != "20") blnResultado = true;

            if (blnResultado)
            {
                //txtDiagnostico.Text = "";
                txtDiagnostico.Select();
            }
            else
            {
                txtDiagnostico.Text = "SIN VALOR PATOLÓGICO";
            }
        }

        private void txtDiagnostico_TextChanged(object sender, EventArgs e)
        {
            if(txtDiagnostico.Text.Length > 254){
                MessageBox.Show("Solo puede guardar un máximo de 255 caracteres.", "Audiometría", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
