using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using System.IO;
using System.Threading;
using Comunes;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmBusquedaLaboral : DevExpress.XtraEditors.XtraForm
    {
        string test;
        private CapaNegocioMepryl.ExamenPreventiva EstadoExamenLaboral = new ExamenPreventiva();
        private CapaNegocioMepryl.CargaLaboral laboral;
        private CapaNegocioMepryl.Examen examenLaboral;
        private CapaNegocioMepryl.Consultorio consultorio;
        private CapaNegocioMepryl.UtilidadesMepryl UtilMepryl; // GRV - Modificado
        CapaNegocioMepryl.ConsolidarReportes Consolidar = new ConsolidarReportes();
        private int puntero;
        private int celda;
        private bool modificarPunteros;
        private string strBoton = "";
        private int intFilaSelecc = 0;  // GRV - Modificado
        Thread SubProceso02;
        Thread SubProceso01;
        DataTable dtMensajeError;
        DialogResult resultExamen01;
        DialogResult resultExamen02;
        private int intContador = 0;
        private int intTotalProcesoTemp = 0;
        private byte intProcesoActivo = 0; // 1 Exporta PDF, 2 Consolida
        private bool blnEstadoProcesarConsolidado = false;
        private DataTable dtTempConsolidar;
        private string strDirectorioECG = "";
        private string strDirectorioClinico = "";
        private string strDirectorioLaboratorio = "";
        private string strDirectorioInfRadiologico = "";
        private string strDirectorioRX = "";
        private string strDirectorioConsolidar = "";
        private string strDirectorioEspirometria = "";
        private string strDirectorioEEG = "";
        private string strDirectorioEcodoppler = "";
        private string strDirectorioAudioMetria = "";
        private string strDirectorioPsicotecnico = "";
        private string strDirectorioErgometria = "";
        private string strDirRXTemp = "";
        DataTable dtArchivosPDF;
        private bool blnActualizaLista = false;
        List<string> ListaArchivosPdf;
        private bool blnUsuarioPuedeModificar = true;
        //private string strAudioNroOrden = "";
        //private DateTime dtFechaAudio;
        private Thread demoThread;
        //private FileStream streamArchivo;

        public frmBusquedaLaboral()
        {
            InitializeComponent();
            laboral = new CargaLaboral();
            examenLaboral = new CapaNegocioMepryl.Examen();
            consultorio = new CapaNegocioMepryl.Consultorio();
            UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl(); // GRV - Modificado
            puntero = -1;
            celda = -1;
            cambiarEnabled(true, false);
            dgv.MultiSelect = true;
            progressBar.Visible = false;
            CargarDataTable();
        }

        public frmBusquedaLaboral(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            laboral = new CargaLaboral();
            examenLaboral = new CapaNegocioMepryl.Examen();
            consultorio = new CapaNegocioMepryl.Consultorio();
            UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl(); // GRV - Modificado
            puntero = -1;
            celda = -1;
            cambiarEnabled(true, false);
            dgv.MultiSelect = true;
            progressBar.Visible = false;
            CargarDataTable();
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            puntero = -1;
            celda = -1;
            cargarExamenesSinFiltro(tpDesde.Value, tpHasta.Value, obtenerFiltro());
            tbBusqueda.Text = "";
        }
        private void cargarExamenesSinFiltro(DateTime desde, DateTime hasta, List<string> filtro)
        {
            DataTable laborales = laboral.cargarListadoSinFiltro(desde, hasta, filtro);

            bool encontrado = false;
            foreach (DataRow row in laborales.Rows)
            {
                if (row["Ident."].ToString() == "L29")
                {
                    System.Diagnostics.Debugger.Break();
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                System.Diagnostics.Debug.WriteLine("No se encontró el registro L29");
            }

            llenarDgv(laborales);
        }

        private void cargarExamenesConFiltro()
        {
            botL.Checked = false;
            botCO.Checked = false;
            DataTable laborales = laboral.cargarListadoConFiltro(tbBusqueda.Text);
            llenarDgv(laborales);
        }

        private void llenarDgv(DataTable laborales)
        {
            Image imgCli = null;
            Image imgLab = null;
            Image imgCons = null;
            Image imgEnv = null;

            if (dgv.Rows.Count > 0) { dgv.Rows.Clear(); }
            foreach (DataRow r in laborales.Rows)
            {
                imgCli = Image.FromFile("P:\\img-system\\blanco.png");
                imgLab = Image.FromFile("P:\\img-system\\blanco.png");
                imgCons = Image.FromFile("P:\\img-system\\blanco.png");
                imgEnv = Image.FromFile("P:\\img-system\\blanco.png"); 
                
                if (!(string.IsNullOrEmpty(r.ItemArray[21].ToString())))
                {
                    if (r.ItemArray[21].ToString() == "1")
                        imgCli = Image.FromFile("P:\\img-system\\tick.png");                    
                }
                if (!(string.IsNullOrEmpty(r.ItemArray[22].ToString())))
                {
                    if (r.ItemArray[22].ToString()== "1")
                        imgLab = Image.FromFile("P:\\img-system\\tick.png");                    
                }
                if (!(string.IsNullOrEmpty(r.ItemArray[23].ToString())))
                {
                    if (r.ItemArray[23].ToString() == "1")
                        imgCons = Image.FromFile("P:\\img-system\\tick.png");                    
                }
                if (!(string.IsNullOrEmpty(r.ItemArray[24].ToString())))
                {
                    if (r.ItemArray[24].ToString() == "1")
                        imgEnv = Image.FromFile("P:\\img-system\\tick.png");
                }

                test = r.ItemArray[6].ToString();
                test = r.ItemArray[6].ToString();

                dgv.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], r.ItemArray[3], r.ItemArray[4], r.ItemArray[5],
                    r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9], r.ItemArray[10], r.ItemArray[11], r.ItemArray[12],
                    r.ItemArray[13], null, r.ItemArray[15], r.ItemArray[16], r.ItemArray[17], r.ItemArray[18], r.ItemArray[19], r.ItemArray[20], imgCli, imgLab, imgCons, imgEnv);
                bool colorGris = colorearFila(dgv.Rows[dgv.Rows.Count - 1]);
                if (r.ItemArray[19].ToString() == "")
                {
                    //MessageBox.Show(r.ItemArray[19].ToString());
                    if (!colorGris)
                    {
                        dgv.Rows[dgv.Rows.Count - 1].Cells[14].Style.BackColor = Color.White;
                    }
                }
                else
                {
                    dgv.Rows[dgv.Rows.Count - 1].Cells[14].Style.BackColor = Color.DarkSeaGreen;
                }                
            }
            cambiarVisibilidadColumnas();
            if (dgv.Rows.Count > 0) { seleccionarCelda(); }
            CambiaColorRepYEC();
        }

        private void CambiaColorRepYEC()
        {
            List<int> indicesEC = new List<int>();//Celeste
            List<int> indicesR = new List<int>();//Amarillo clarito
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                if (dr.Cells[3].Value.ToString().Contains("EC"))
                {
                    indicesEC.Add(dr.Index);
                }
                else if (dr.Cells[3].Value.ToString().Contains("R"))
                {
                    indicesR.Add(dr.Index);
                }
            }
            foreach (int indice in indicesEC)
            {
                dgv.Rows[indice].DefaultCellStyle.BackColor = Color.Azure;
            }
            foreach (int indice in indicesR)
            {
                dgv.Rows[indice].DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private bool colorearFila(DataGridViewRow dgvR)
        {
            if (dgvR.Cells[3].Value.ToString().Contains("L"))
            {
                if (Convert.ToInt16(dgvR.Cells[3].Value.ToString().Replace("L", "")) >= 200)
                {
                    dgvR.DefaultCellStyle.BackColor = Color.Gainsboro;
                    return true;
                }
            }
            return false;
        }

        private void seleccionarCelda()
        {
            try
            {
                if (puntero != -1)
                {
                    dgv.Rows[puntero].Cells[celda].Selected = true;
                    //dgv.Rows[puntero].Selected = true;
                    dgv.CurrentCell = dgv.Rows[puntero].Cells[14];
                }
                else
                {
                    dgv.Rows[0].Cells[1].Selected = true;
                }
            }catch(System.ArgumentOutOfRangeException ex)
            {
                if (dgv.Rows.Count > 0)
                {
                    dgv.Rows[0].Cells[1].Selected = true;
                }
            }
        }

        public void actualizar()
        {
            if (!string.IsNullOrEmpty(tbBusqueda.Text))
            {
                DataTable laborales = laboral.cargarListadoConFiltro(tbBusqueda.Text);
                llenarDgv(laborales);
                return;
            }
            if (panel1.Enabled)
            {
                cargarExamenesSinFiltro(tpFecha.Value, tpFecha.Value, obtenerFiltro());
            }
            else
            {
                cargarExamenesSinFiltro(tpDesde.Value, tpHasta.Value, obtenerFiltro());
            }            
        }

        private void cambiarEnabled(bool estPanel1, bool estPanel2)
        {
            panel1.Enabled = estPanel1;
            panel2.Enabled = estPanel2;
        }
        
        private void abrirVentanaCarga(DataGridViewCellEventArgs c)
        {
            intFilaSelecc = dgv.CurrentCell.RowIndex; // GRV - Modificado
            puntero = intFilaSelecc;
            //celda = dgv.CurrentCell.ColumnIndex;            

            if (c.RowIndex != -1 && c.ColumnIndex == 14)
            {
                abrirVentana(dgv.Rows[c.RowIndex].Cells[c.ColumnIndex]);
                dgv.CurrentCell = dgv.Rows[intFilaSelecc].Cells[14];
            }

            // GRV - Modificado
            //dgv.Rows[intFilaSelecc].Selected = true;
            
        }

        private void abrirVentana(DataGridViewCell c)
        {
            if (dgv.Rows[c.RowIndex].Cells[12].Value.ToString() == "0")
            {
                frmConsultorio frm = new frmConsultorio(this);
                //Utilidades.abrirFormulario(this.MdiParent, frm, new Configuracion());                
                AbrirForm(frm);
                frm.setearLabelTitulo(dgv.Rows[c.RowIndex].Cells[4].Value.ToString());
                frm.setearValores(dgv.Rows[c.RowIndex].Cells[18].Value.ToString());                
            }
            else if (dgv.Rows[c.RowIndex].Cells[12].Value.ToString() == "1")
            {
                frmExamenLaboral frm = new frmExamenLaboral(this, blnUsuarioPuedeModificar);
                //Utilidades.abrirFormulario(this.MdiParent, frm, new Configuracion());
                AbrirForm(frm);
                frm.setearLabelTitulo(dgv.Rows[c.RowIndex].Cells[4].Value.ToString());
                if (dgv.Rows[c.RowIndex].Cells[3].Value.ToString().Contains("L"))
                {
                    frm.setearValores(dgv.Rows[c.RowIndex].Cells[11].Value.ToString(), dgv.Rows[c.RowIndex].Cells[6].Value.ToString(),
                dgv.Rows[c.RowIndex].Cells[7].Value.ToString(), dgv.Rows[c.RowIndex].Cells[8].Value.ToString() + " - " +
                dgv.Rows[c.RowIndex].Cells[9].Value.ToString(), dgv.Rows[c.RowIndex].Cells[1].Value.ToString(),
                dgv.Rows[c.RowIndex].Cells[4].Value.ToString(), dgv.Rows[c.RowIndex].Cells[3].Value.ToString(),
                dgv.Rows[c.RowIndex].Cells[8].Value.ToString(), dgv.Rows[c.RowIndex].Cells[17].Value.ToString());
                }
                else if (dgv.Rows[c.RowIndex].Cells[3].Value.ToString().Contains("EC"))
                {
                    frm.setearValoresEstudioComplementario(dgv.Rows[c.RowIndex].Cells[20].Value.ToString(), dgv.Rows[c.RowIndex].Cells[5].Value.ToString());
                }                
            }

            puntero = c.RowIndex;
            celda = c.ColumnIndex;
        }

        private void AbrirForm(Form frm)
        {
            frm.Show();
        }

        private void botonRango_Click(object sender, EventArgs e)
        {
            cambiarEnabled(false, true);
        }

        private void botonFecha_Click(object sender, EventArgs e)
        {
            cambiarEnabled(true, false);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirVentanaCarga(e);
            // ***************            
        }

        private List<string> obtenerFiltro()
        {
            List<string> retorno = new List<string>();
            if (botL.Checked) { retorno.Add("L"); }
            if (botCO.Checked) { retorno.Add("CO"); }
            return retorno;

        }

        private void botBuscarPorDia_Click(object sender, EventArgs e)
        {
            puntero = -1;
            celda = -1;
            cargarExamenesSinFiltro(tpFecha.Value, tpFecha.Value, obtenerFiltro());
            tbBusqueda.Text = "";
        }


        private void botCO_CheckedChanged(object sender, EventArgs e)
        {
            strBoton = "Consultorios"; // GRV - Ramírez
            if (botCO.Checked) { botL.Checked = false; tbBusqueda.Clear(); }
            cargarSegunEnabled();
            setearTitulo();
        }

        private void botL_CheckedChanged(object sender, EventArgs e)
        {
            strBoton = "Ex. Aptitud"; // GRV - Ramírez
            if (botL.Checked) { botCO.Checked = false; botV.Checked = false; tbBusqueda.Clear(); }
            cargarSegunEnabled();
            setearTitulo();
        }

        private void botV_CheckedChanged(object sender, EventArgs e)
        {
            strBoton = "Domicilios";
            if (botV.Checked) { botL.Checked = false; tbBusqueda.Clear(); }
            cargarSegunEnabled();
            setearTitulo();
        }

        private void cargarSegunEnabled()
        {
            puntero = -1;
            celda = -1;
            if (panel1.Enabled)
            {
                cargarExamenesSinFiltro(tpFecha.Value, tpFecha.Value, obtenerFiltro());
            }
            else
            {
                cargarExamenesSinFiltro(tpDesde.Value, tpHasta.Value, obtenerFiltro());
            }

        }

        private void setearTitulo()
        {
            if (botL.Checked) { lbTitulo.Text = "   Ex. Aptitud"; botImprimirEx.Visible = false; }
            if (botCO.Checked) { lbTitulo.Text = "   Consultorios"; botImprimirEx.Visible = false; }
            if (botV.Checked) { lbTitulo.Text = "   Domicilios"; botImprimirEx.Visible = false; }
            if (botCO.Checked && botV.Checked) { lbTitulo.Text = "   Consultorios/Domicilios"; botImprimirEx.Visible = false; }
            if (!botL.Checked && !botCO.Checked && !botV.Checked) { lbTitulo.Text = string.Empty; }

        }

        private void cambiarVisibilidadColumnas()
        {
            dgv.Columns[2].Visible = false;
            if (botL.Checked) { editarColumnas(false, "Examen", false, true); }
            if (botCO.Checked || botV.Checked) { editarColumnas(true, "Diagnostico", true, false); }
        }

        private void editarColumnas(bool estAt, string header, bool fechaAltCit, bool dict)
        {
            dgv.Columns[13].Visible = estAt;
            dgv.Columns[14].HeaderText = header;
            dgv.Columns[15].Visible = fechaAltCit;
            dgv.Columns[16].Visible = dict;
            dgv.Columns[20].Visible = false;
        }

        private void botMail_Click(object sender, EventArgs e)
        {
            mail();
        }

        private void mail()
        {
            if (dgv.SelectedCells.Count > 0)
            {
                if (botL.Checked)
                {
                    mailExAptitud();
                }
                else if (botCO.Checked || botV.Checked)
                {
                    mailConsultoriosVisitas();
                }
            }
            else
            {
                MessageBox.Show("¡Seleccione lo que desea enviar por mail!", "Enviar Mail",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void mailExAptitud()
        {
            List<string> archivos = new List<string>();
            frmMail frm = frmMail.GetForm();
            int celda = dgv.SelectedCells[0].ColumnIndex;
            foreach (DataGridViewCell dgvC in dgv.SelectedCells)
            {
                if (celda == dgvC.ColumnIndex)
                {
                    Reportes report = new Reportes(new rptExamenLaboral());
                    string ruta = report.exportarAPDF(examenLaboral.cargarParametrosExamen(dgv.Rows[dgvC.RowIndex].Cells[17].Value.ToString(), false),
                         new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(cargarImagen(dgv.Rows[dgvC.RowIndex].Cells[8].Value.ToString()), "3"),
                         // GRV - Ramírez - Modificado
                         // @"P:\EX. APTITUD\" + dgv.Rows[dgvC.RowIndex].Cells[3].Value.ToString() + "-" + dgv.Rows[dgvC.RowIndex].Cells[1].Value.ToString().Replace('/', '-') + ".pdf");
                         DirectorioReporte(3) + dgv.Rows[dgvC.RowIndex].Cells[3].Value.ToString() + "-" + dgv.Rows[dgvC.RowIndex].Cells[1].Value.ToString().Replace('/', '-') + ".pdf");
                    archivos.Add(ruta);
                    frm.direccionesMail(examenLaboral.cargarMailsEmpresaExamenLaboral(dgv.Rows[dgvC.RowIndex].Cells[17].Value.ToString()));
                }
            }

            frm.archivosAdjuntos(archivos);
            frm.setearAsunto("RESULTADO DE EXAMEN SOLICITADO");
            frm.setearMensaje("Adjuntamos al presente mail el exámen solicitado.");
            frm.mailLaboral();
            frm.mostrar(this.MdiParent);
        }

        private byte[] cargarImagen(string dni)
        {
            MemoryStream ms = new MemoryStream();
            Image imagen = Image.FromFile(@"S:\\FOTOS\\" + dni + ".jpg");
            if (imagen != null)
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        private void mailConsultoriosVisitas()
        {
            List<string> archivos = new List<string>();
            frmMail frm = frmMail.GetForm();
            int celda = dgv.SelectedCells[0].ColumnIndex;
            foreach (DataGridViewCell dgvC in dgv.SelectedCells)
            {
                if (celda == dgvC.ColumnIndex)
                {
                    Reportes report = new Reportes(new rptConsultorioDomicilios());
                    string ruta = report.exportarAPDF(consultorio.cargarParametrosConsultorio(dgv.Rows[dgvC.RowIndex].Cells[18].Value.ToString()),
                    new dsMedicinaLaboral(), consultorio.cargarDataSourceConsultorio(),
                    // GRV - Ramírez - Modificado
                    // @"P:\CONSULTORIOS\" + dgv.Rows[dgvC.RowIndex].Cells[6].Value.ToString() + "-" + dgv.Rows[dgvC.RowIndex].Cells[1].Value.ToString().Replace('/', '.') +
                    DirectorioReporte(5) + dgv.Rows[dgvC.RowIndex].Cells[6].Value.ToString() + "-" + dgv.Rows[dgvC.RowIndex].Cells[1].Value.ToString().Replace('/', '.') +
                    "-" + dgv.Rows[dgvC.RowIndex].Cells[9].Value.ToString() + ".pdf");
                    archivos.Add(ruta);
                    frm.direccionesMail(consultorio.cargarMailsEmpresa(dgv.Rows[dgvC.RowIndex].Cells[18].Value.ToString()));
                }
            }

            frm.archivosAdjuntos(archivos);
            frm.setearAsunto("DIAGNOSTICO DE ATENCION EN CONSULTORIO");
            frm.setearMensaje("Adjuntamos al presente mail el diagnóstico de atención en consultorio.");
            frm.mailLaboral();
            frm.mostrar(this.MdiParent);
        }

        // GRV - Ramírez - recuperar directorio
        private string DirectorioReporte(byte tipo)
        {
            byte bytTipo = tipo;
            string strDirectorio = "";

            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"select reporte from dbo.ConfigReportes
            where tipoReporte = '" + bytTipo + "'");

            if (valores.Rows.Count > 0)
            {
                strDirectorio = valores.Rows[0].ItemArray[0].ToString() + "\\";
            }
            else
            {
                strDirectorio = "P:\\CONSULTORIOS\\";
            }

            return strDirectorio;
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (dgv.CurrentCell != null && e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    abrirVentana(dgv.CurrentCell);
                }
            }
        }

        private void botCambiarEmpresa_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells != null && dgv.SelectedCells.Count > 0)
            {
                frmCambioEmpresa frm = new frmCambioEmpresa(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[20].Value.ToString(),this);
                frm.ShowDialog();
            }
        }

        private void botImportarCasino_Click(object sender, EventArgs e)
        {
            abrirVentanaImportacionCasino();
        }

        private void abrirVentanaImportacionCasino()
        {
            frmImportacionCasino fCasino = new frmImportacionCasino();
            fCasino.objDelegateFormulario = new frmImportacionCasino.DelegateFormulario(recargarConFechaEspecifica);
            fCasino.ShowDialog();
        }

        private void recargarConFechaEspecifica(string fecha)
        {
            panel1.Enabled = true;
            tpFecha.Value = Convert.ToDateTime(fecha);
            botL.Checked = true;
            actualizar();
        }

        private void botFiltrar_Click(object sender, EventArgs e)
        {
            cargarExamenesConFiltro();
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            tbBusqueda.Text = "";
            actualizar();
        }

        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                botFiltrar_Click(sender, e);
            }
        }

        private void btnExportarExamenes_Click(object sender, EventArgs e)
        {
            iniciaProcesoBarra();

            MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
            resultExamen01 = MessageBox.Show("¿Desea exportar todos los estudios de la fecha?\n\n", "Exportar Examenes",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            //FileStream stream = new FileStream(@"P:\Temporal\PLANTILLA REPORTE INFORMES\Informe Audio Digitalizada2.xlsx", FileMode.Open);
            //streamArchivo = stream;
            //stream.Dispose();
            //stream.Close();

            SubProceso02 = new Thread(ExportarExamPDF);
            SubProceso02.Start();
            blnActualizaLista = false;
            timerActualizaEstados.Enabled = true;
            //SubProceso02.Join();
            //ExportarExamPDF();
        }

        private void iniciaProcesoBarra()
        {
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = dgv.Rows.Count;
            progressBar.Step = 1;
        }

        private void IncreProcesoBarra(int intValor)
        {
            if (progressBar.InvokeRequired)
            {
                MethodInvoker mi = new MethodInvoker(() => progressBar.Value = intValor);
                progressBar.Invoke(mi);
            }
            else
            {
                progressBar.PerformStep();
            }
        }

        private void OcultarProgresoBarra()
        {
            if (progressBar.InvokeRequired)
            {
                MethodInvoker mi = new MethodInvoker(() => progressBar.Visible = false);
                progressBar.Invoke(mi);
            }
        }
        
        private void ExportarExamPDF()
        {
            int intCont = 0;
            if (dgv.Rows.Count > 0)
            {
                //MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
                //DialogResult resultExamen = MessageBox.Show("¿Desea exportar todos los estudios de la fecha?\n\n    Presione No para exportar solo los exámenes seleccionados.", "Exportar Examenes",
                //MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultExamen01 == DialogResult.Yes)
                {
                    //progressBar.Visible = true;
                    //progressBar.Minimum = 1;                    
                    //progressBar.Maximum = dgv.Rows.Count;
                    //progressBar.Step = 1;

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                && row.Cells[17].Value.ToString() != "0")
                        {
                            ExportarClincoPDF(row);
                            ExportarProtocoloPDF(row, 2, false);
                            //progressBar.PerformStep();
                            IncreProcesoBarra(++intCont);
                        }
                    }

                    //SubProceso02 = new Thread(Exportacion_A01);
                    //SubProceso02.Start();
                    //progressBar.Visible = false;
                }
                else if (resultExamen01 == DialogResult.No)
                {
                    if (dgv.SelectedCells.Count > 0)
                    {
                        //progressBar.Visible = true;
                        //progressBar.Minimum = 1;
                        //progressBar.Value = 1;
                        //progressBar.Maximum = dgv.Rows.Count;
                        //progressBar.Step = 1;

                        celda = dgv.SelectedCells[0].ColumnIndex;
                        foreach (DataGridViewCell cell in dgv.SelectedCells)
                        {
                            if (celda == cell.ColumnIndex)
                            {
                                DataGridViewRow row = dgv.Rows[cell.RowIndex];
                                if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                    row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                    && row.Cells[17].Value.ToString() != "0")
                                {
                                    ExportarClincoPDF(row);
                                    ExportarProtocoloPDF(row, 2, false);
                                    //progressBar.PerformStep();
                                    IncreProcesoBarra(++intCont);
                                }
                            }
                        }
                                                
                        //SubProceso02 = new Thread(Exportacion_A02);
                        //SubProceso02.Start();

                        //progressBar.Visible = false;
                    }
                }
            }

            if (!ListaErrorEpirometria())
            {
                MessageBox.Show("El proceso de exportación ha finalizado.", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
            OcultarProgresoBarra();
            blnActualizaLista = true;            
            SubProceso02.Join();
            //
            //ProcesoRefrescarLista();
        }
        
        private void botImprimirEx_Click(object sender, EventArgs e)
        {

        }

        private void ExportarClincoPDF(DataGridViewRow r)
        {
            CapaNegocioMepryl.Reportes rpt = new CapaNegocioMepryl.Reportes();
            CapaNegocioMepryl.ExamenPreventiva preventiva = new CapaNegocioMepryl.ExamenPreventiva();

            string strIdExamenLaboral = r.Cells[17].Value.ToString();
            string strDNI = r.Cells[8].Value.ToString();
            string strIdTipoExamenDePaciente = r.Cells[20].Value.ToString();

            string strNombreArchivo = "";
            string strNombreArchivoEspirometria = "";

            strNombreArchivo = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + " - C.pdf";
            strNombreArchivoEspirometria = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + ".pdf";

            //rpt.ClinicoLaboral(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, false), strNombreArchivo, Convert.ToDateTime(r.Cells[1].Value.ToString()));
            //Reportes report = new Reportes(new rptExamenLaboral());
            //report.exportarAPDF(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, false),
            //new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(strDNI), "3"),
            //UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "CLINICOS Y LABORATORIOS") + strNombreArchivo);
            Reportes report = new Reportes(new rptExamenLaboral());
            report.exportarAPDF(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, false),
            new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(strDNI), "3"),
            rpt.ReporteSalida("CLINICO-LABORAL", false, Convert.ToDateTime(r.Cells[1].Value.ToString()), strNombreArchivo));

            //GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "ESPIROMETRIA") + strNombreArchivoEspirometria, false);
            //GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), rpt.ReporteSalida("ESPIROMETRIA",false, Convert.ToDateTime(r.Cells[1].Value.ToString()),strNombreArchivoEspirometria), false);
            GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), strNombreArchivoEspirometria, false);

            preventiva.actualizarImpresionExamen(strIdTipoExamenDePaciente);
        }

        private string ConvertirFechaString(string Fecha)
        {
            string strFecha = "";
            DateTime dtfecha = Convert.ToDateTime(Fecha);
            string strDia = dtfecha.Day.ToString();
            string strMes = dtfecha.Month.ToString();

            if (dtfecha.Day <= 9)
                strDia = "0" + strDia;
            if (dtfecha.Month <= 9)
                strMes = "0" + strMes;

            strFecha = strDia + strMes + dtfecha.Year.ToString();

            return strFecha;
        }

        public void ExportarProtocoloPDF(DataGridViewRow r, sbyte tipoReporte, bool blnImprimir)
        {
            CapaNegocioMepryl.Reportes rpt = new CapaNegocioMepryl.Reportes();
            CapaNegocioMepryl.ExamenPreventiva preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            //ReporteAudiometria repAudio = new ReporteAudiometria();

            string strIdExamenLaboral = r.Cells[17].Value.ToString();
            string strIdTipoExamenDePaciente = r.Cells[20].Value.ToString();
            string strNombreArchivo = "";            

            DataTable dtConsulta = examenLaboral.cargarParametrosLaboratorio(strIdExamenLaboral, tipoReporte);
            Reportes report = new Reportes(new rptProtocoloLaboratorioLaboral());
            string strTipoLaboratorio = "NORMAL";

            strNombreArchivo = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + " - L.pdf";

            if (dtConsulta.Rows.Count > 0)
            {                
                bool blnPerfilLipidico01 = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[31].ToString());
                bool blnPerfilLipidico02 = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[32].ToString());
                bool blnCreatininaArbitro = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[66].ToString());
                bool blnTieneOrina = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[48].ToString());

                if (dtConsulta.Rows[0].ItemArray[31].ToString() != "0" && dtConsulta.Rows[0].ItemArray[31].ToString() != "0") 
                {
                    if (blnPerfilLipidico01 && blnPerfilLipidico02)
                    {
                        strTipoLaboratorio = "CASINO";
                        //report = null;
                        //report = new Reportes(new rptProtocoloLaboratorioLaboral01());
                    }
                }

                if (!blnCreatininaArbitro) 
                {
                    if (dtConsulta.Rows[0].ItemArray[66].ToString() != "0")
                    {
                        strTipoLaboratorio = "ARBITRO";
                        //report = null;
                        //report = new Reportes(new rptProtocoloLaboratorioLaboral02());
                    }
                }

                if (blnTieneOrina)
                {
                    
                        strTipoLaboratorio = "LIBRETA";
                        //report = null;
                        //report = new Reportes(new rptProtocoloLaboratorioLaboral02());
                    
                }
            }

            //report.ExportarLaboratorio(dtConsulta, 
            //    UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 4, "CLINICOS Y LABORATORIOS") + strNombreArchivo);
            
            //report.ExportarLaboratorio(dtConsulta,
            //    rpt.ReporteSalida("LABORATORIO-LABORAL", false, Convert.ToDateTime(r.Cells[1].Value.ToString()), strNombreArchivo));
            rpt.LaboratorioLaboral(dtConsulta, strNombreArchivo, Convert.ToDateTime(r.Cells[1].Value.ToString()), strTipoLaboratorio, blnImprimir);

            preventiva.actualizarImpresionLaboratorio(strIdTipoExamenDePaciente);

            //strAudioNroOrden = r.Cells[3].Value.ToString();
            //dtFechaAudio = Convert.ToDateTime(r.Cells[1].Value.ToString());

            //repAudio.GeneraAutoReporteAudiometria(Convert.ToDateTime(r.Cells[1].Value.ToString()), r.Cells[3].Value.ToString());            
            // --ReporteAudiometria
            //System.Threading.Thread _thread = new System.Threading.Thread(new ThreadStart(this.LanzarReporteAudiometria));
            //_thread.SetApartmentState(System.Threading.ApartmentState.STA);
            //_thread.Start();
        }

        private void LanzarReporteAudiometria(string strNroOrden, DateTime dtFecha)
        {               
            ReporteAudiometria repAudio = new ReporteAudiometria();            
            repAudio.GeneraAutoReporteAudiometria(dtFecha, strNroOrden); 
        }

        private byte[] imageToArray(string DNI)
        {
            PictureBox pbFoto = new PictureBox();
            MemoryStream ms = new MemoryStream();
            string strPathFoto = UtilMepryl.PathFotoLaboral() + DNI + ".jpg";
            try
            {
                if (File.Exists(strPathFoto))
                    pbFoto.Image = Image.FromFile(strPathFoto);
                else
                    pbFoto.Image = null;

                if (pbFoto.Image != null) { pbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); }
                return ms.ToArray();
            }
            catch (System.IO.FileNotFoundException ex) 
            {
                return null;
            }
        }

        private void btnExportarOlivera_Click(object sender, EventArgs e)
        {
            iniciaProcesoBarra();

            MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
            resultExamen02 = MessageBox.Show("¿Desea exportar todos los estudios de la fecha?\n\n", "Exportar Examenes",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            SubProceso02 = new Thread(ExportarOlivera);
            SubProceso02.Start();
            blnActualizaLista = false;
            timerActualizaEstados.Enabled = true;
            //ExportarOlivera();
        }

        private void ExportarOlivera()
        {
            int intCont = 0;

            if (dgv.Rows.Count > 0)
            {                
                if (resultExamen02 == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                && row.Cells[17].Value.ToString() != "0")
                        {
                            ExportarOliveraPDF(row);
                            ExportarProtocoloPDF(row, 2, false);                            
                            IncreProcesoBarra(++intCont);
                        }
                    }                                            
                }
                else if (resultExamen02 == DialogResult.No)
                {
                    if (dgv.SelectedCells.Count > 0)
                    {
                        celda = dgv.SelectedCells[0].ColumnIndex;
                        foreach (DataGridViewCell cell in dgv.SelectedCells)
                        {
                            if (celda == cell.ColumnIndex)
                            {
                                DataGridViewRow row = dgv.Rows[cell.RowIndex];
                                if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                    row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                    && row.Cells[17].Value.ToString() != "0")
                                {
                                    ExportarOliveraPDF(row);
                                    ExportarProtocoloPDF(row, 2, false);                                    
                                    IncreProcesoBarra(++intCont);
                                }
                            }
                        }                        
                    }
                }
            }

            MessageBox.Show("El proceso de exportación ha finalizado.", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            OcultarProgresoBarra();
            blnActualizaLista = true;            
            SubProceso02.Join();
            //
            //ProcesoRefrescarLista();
        }

        private void ProcesoRefrescarLista()
        {
            if (!string.IsNullOrEmpty(tbBusqueda.Text))
            {
                DataTable laborales = laboral.cargarListadoConFiltro(tbBusqueda.Text);
                llenarDgv(laborales);
                return;
            }
            if (panel1.Enabled)
            {
                cargarExamenesSinFiltro(tpFecha.Value, tpFecha.Value, obtenerFiltro());
            }
            else
            {
                cargarExamenesSinFiltro(tpDesde.Value, tpHasta.Value, obtenerFiltro());
            }
        }

        private void ExportarOliveraPDF(DataGridViewRow r)
        {
            CapaNegocioMepryl.Reportes rpt = new CapaNegocioMepryl.Reportes();
            CapaNegocioMepryl.ExamenPreventiva preventiva = new CapaNegocioMepryl.ExamenPreventiva();

            string strIdExamenLaboral = r.Cells[17].Value.ToString();
            string strDNI = r.Cells[8].Value.ToString();
            string strIdTipoExamenDePaciente = r.Cells[20].Value.ToString();

            string strNombreArchivo = "";
            string strNombreArchivoEspirometria = "";

            strNombreArchivo = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + " - C.pdf";
            strNombreArchivoEspirometria = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + ".pdf";

            //rpt.OliveraLaboral(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, true), strNombreArchivo, Convert.ToDateTime(r.Cells[1].Value.ToString()));
            //Reportes report = new Reportes(new rptExamenLaboral());
            //report.exportarAPDF(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, true),
            //new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(strDNI), "4"),
            //UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "CLINICOS Y LABORATORIOS") + strNombreArchivo);
            Reportes report = new Reportes(new rptExamenLaboral());
            report.exportarAPDF(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, true),
            new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(strDNI), "4"),
            rpt.ReporteSalida("CLINICO-LABORAL", false, Convert.ToDateTime(r.Cells[1].Value.ToString()), strNombreArchivo));

            //GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "ESPIROMETRIA") + strNombreArchivoEspirometria, true);
            //GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), rpt.ReporteSalida("ESPIROMETRIA", false, Convert.ToDateTime(r.Cells[1].Value.ToString()), strNombreArchivoEspirometria), false);
            GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), strNombreArchivoEspirometria, false);

            preventiva.actualizarImpresionExamen(strIdTipoExamenDePaciente);
        }

        private void Exportacion_A01()
        {
            // Exporta todos los examenes a la fecha seleccionada y 
            // genera el reporte clinico y laboratorio
            bool blnResultado = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                        row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                        && row.Cells[17].Value.ToString() != "0")
                {
                    ExportarClincoPDF(row);
                    ExportarProtocoloPDF(row, 2, false);
                    //progressBar.PerformStep();                    
                }
                blnResultado = true;
            }

            //return blnResultado;
        }

        private void Exportacion_A02()
        {
            // Exporta solo los examenes seleccionados en el DataGridView y 
            // genera el reporte clinico y laboratorio
            bool blnResultado = false;

            celda = dgv.SelectedCells[0].ColumnIndex;
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                if (celda == cell.ColumnIndex)
                {
                    DataGridViewRow row = dgv.Rows[cell.RowIndex];
                    if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                        row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                        && row.Cells[17].Value.ToString() != "0")
                    {
                        ExportarClincoPDF(row);
                        ExportarProtocoloPDF(row, 2, false);
                        //progressBar.PerformStep();
                    }
                }
                blnResultado = true;
            }

            //return blnResultado;
        }

        private void Exportacion_B01()
        {
            // Exporta todos los examenes a la fecha seleccionada y 
            // genera el reporte clinico Olivera y laboratorio
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                        row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                        && row.Cells[17].Value.ToString() != "0")
                {
                    ExportarOliveraPDF(row);
                    ExportarProtocoloPDF(row, 2, false);
                    //progressBar.PerformStep();
                }
            }
        }

        private void Exportacion_B02()
        {
            // Exporta solo los examenes seleccionados en el DataGridView y 
            // genera el reporte clinico Olivera y laboratorio
            celda = dgv.SelectedCells[0].ColumnIndex;
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                if (celda == cell.ColumnIndex)
                {
                    DataGridViewRow row = dgv.Rows[cell.RowIndex];
                    if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                        row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                        && row.Cells[17].Value.ToString() != "0")
                    {
                        ExportarOliveraPDF(row);
                        ExportarProtocoloPDF(row, 2, false);
                        //progressBar.PerformStep();
                    }
                }
            }
        }

        private void botImportar_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this.MdiParent, new frmImportarLaboratorioLaboral(), new Configuracion());
            frmImportarLaboratorioLaboral frm = new frmImportarLaboratorioLaboral();
            frm.ShowDialog();
        }

        private void GenerarReporteEspirometria(string strDNI, string strIdExamenLaboral, string strFecha, string strIdentificador, string strArchivoSalida, bool blnOlivera )
        {
            ReporteEspirometria reporte = new ReporteEspirometria();
            CapaNegocioMepryl.Reportes resultado = new CapaNegocioMepryl.Reportes();
            DataTable dt = null;
            dt = resultado.ReporteEspirometria(strIdExamenLaboral, strDNI);            
            bool blnTieneInforme = false;
            bool blnTieneImagen = false;

            foreach (DataRow r in dt.Rows)
            {
                blnTieneInforme = (!string.IsNullOrEmpty(r.ItemArray[4].ToString()));
            }
            
            if (blnTieneInforme)
            {
                blnTieneImagen = reporte.CargarEtiquetas(strDNI, strIdExamenLaboral, strFecha, strIdentificador, strArchivoSalida, blnOlivera);
                
                if (!blnTieneImagen)
                    RegistrarError(strFecha, strIdentificador, strDNI, "No hay imagen de espirometría");                
            }
        }

        private void CargarDataTable()
        {
            dtMensajeError = new DataTable();

            dtMensajeError.Columns.Add("Fecha",typeof(System.String));
            dtMensajeError.Columns.Add("Orden", typeof(System.String));
            dtMensajeError.Columns.Add("DNI", typeof(System.String));
            dtMensajeError.Columns.Add("Mensaje", typeof(System.String));
        }

        private void RegistrarError(string Fecha, string Orden, string DNI, string Mensaje)
        {
            dtMensajeError.Rows.Add(Fecha, Orden, DNI, Mensaje);
        }

        private bool ListaErrorEpirometria()
        {
            bool blnResultado = false;

            if (dtMensajeError.Rows.Count > 0)
            {
                blnResultado = true;

                DialogResult result01 = MessageBox.Show("El proceso de exportación ha finalizado.\nAlgunos archivos estan incompletos.\n\n¿Ver examenes faltantes?", "Proceso completo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result01 == DialogResult.Yes)
                {
                    frmMensajeAlerta frm = new frmMensajeAlerta("Los siguientes exámenes no fueron creados", "Exámenes", dtMensajeError);
                    frm.ShowDialog();
                }
                dtMensajeError.Rows.Clear();
            }

            return blnResultado;
        }

        private void bbiCasino_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botImportarCasino_Click(sender, e);
        }

        private void bbiLaboratorio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botImportar_Click(sender, e);
        }

        private void bbiCambioEmpresa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botCambiarEmpresa_Click(sender, e);
        }

        private void frmBusquedaLaboral_Load(object sender, EventArgs e)
        {
            rbcMenu.Minimized = true;
            botL.Checked = true;

            PermisosUsuario();
        }

        private void bbiExportarExam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnExportarExamenes_Click(sender, e);
        }

        private void bbiExportarOliv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnExportarOlivera_Click(sender, e);
        }

        private void botRevalidarCondicionales_Click(object sender, EventArgs e)
        {
            intContador = 0;
            intTotalProcesoTemp = 0;
            intProcesoActivo = 2;

            MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
            DialogResult resultExamen = MessageBox.Show("¿Consolidar estudios a la fecha?\n\n", "Consolidar Estudios",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (resultExamen == DialogResult.Yes)
            {
                blnEstadoProcesarConsolidado = true;
                dtTempConsolidar = CargarDT(true);
            }
            else if (resultExamen == DialogResult.No)
            {
                blnEstadoProcesarConsolidado = false;
                dtTempConsolidar = CargarDT(false);
            }
            else
                return;

            CargarDirectorios();
            EstablecerColumnas();
            iniciaProcesoBarra();
            SubProceso01 = new Thread(ListarArchivosBase);
            SubProceso01.Start();
            blnActualizaLista = false;
            timerActualizaEstados.Enabled = true;
            //botRevalidarCondicionales.Enabled = false;
            bbiConsolidarEstudios.Enabled = false;
        }

        private void CargarDirectorios()
        {
            DataTable dt = Consolidar.DirectoriosLaboral();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {                    
                    strDirectorioClinico = r.ItemArray[0].ToString();
                    strDirectorioLaboratorio = r.ItemArray[1].ToString();
                    strDirectorioRX = r.ItemArray[2].ToString();
                    strDirectorioECG = r.ItemArray[3].ToString();                    
                    strDirectorioEspirometria = r.ItemArray[4].ToString();
                    strDirectorioEEG = r.ItemArray[5].ToString();
                    strDirectorioEcodoppler = r.ItemArray[6].ToString();
                    strDirectorioAudioMetria = r.ItemArray[7].ToString();
                    strDirectorioPsicotecnico = r.ItemArray[8].ToString();
                    strDirectorioErgometria = r.ItemArray[9].ToString();
                    strDirectorioConsolidar = r.ItemArray[10].ToString();                    
                }
            }
        }

        private void EstablecerColumnas()
        {
            dtArchivosPDF = new DataTable();
            dtMensajeError = new DataTable();

            dtArchivosPDF.Columns.Add("Dia");
            dtArchivosPDF.Columns.Add("Mes");
            dtArchivosPDF.Columns.Add("Anio");
            dtArchivosPDF.Columns.Add("Orden");
            dtArchivosPDF.Columns.Add("DNI");
            dtArchivosPDF.Columns.Add("Paciente");
            dtArchivosPDF.Columns.Add("InfClinico");
            dtArchivosPDF.Columns.Add("InfLaboratorio");
            dtArchivosPDF.Columns.Add("InfECG");
            dtArchivosPDF.Columns.Add("InfEspiro");
            dtArchivosPDF.Columns.Add("ImgRX01");
            dtArchivosPDF.Columns.Add("ImgRX02");
            dtArchivosPDF.Columns.Add("ImgRX03");

            dtMensajeError.Columns.Add("Fecha");
            dtMensajeError.Columns.Add("Orden");
            dtMensajeError.Columns.Add("DNI");
            dtMensajeError.Columns.Add("Mensaje");
        }

        private DataTable CargarDT(bool ConsolidaTodo)
        {
            DataTable dtConsulta = new DataTable();
            DataRow drFila;
            string intNroOrden = "";
            DateTime dtFecha;
            string strIdTipoExamen = "";
            string strDNI = "";

            dtConsulta.Columns.Add("Fecha", typeof(System.DateTime)); // index 0
            dtConsulta.Columns.Add("Nº Examen", typeof(System.String)); // index 1
            dtConsulta.Columns.Add("DNI", typeof(System.String)); // index 2
            dtConsulta.Columns.Add("Paciente", typeof(System.String)); // index 3
            dtConsulta.Columns.Add("Infantil Inicial", typeof(System.Int32)); // index 4
            dtConsulta.Columns.Add("Clinico", typeof(System.Boolean)); // index 5
            dtConsulta.Columns.Add("Orina", typeof(System.Boolean)); // index 6
            dtConsulta.Columns.Add("RX", typeof(System.Boolean)); // index 7
            dtConsulta.Columns.Add("ECG", typeof(System.Boolean)); // index 8
            dtConsulta.Columns.Add("EEG", typeof(System.Boolean)); // index 9
            dtConsulta.Columns.Add("Psico", typeof(System.Boolean)); // index 10
            dtConsulta.Columns.Add("Audio", typeof(System.Boolean)); // index 11
            dtConsulta.Columns.Add("Ergo", typeof(System.Boolean)); // index 12
            dtConsulta.Columns.Add("Eco", typeof(System.Boolean)); // index 13
            dtConsulta.Columns.Add("Oto", typeof(System.Boolean)); // index 14
            dtConsulta.Columns.Add("Espiro", typeof(System.Boolean)); // index 15
            dtConsulta.Columns.Add("IdTep", typeof(System.String)); // index 16

            if (!ConsolidaTodo)
            {
                if (dgv.SelectedCells.Count > 0)
                //if (dgvTempConsolidar.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in dgv.SelectedCells)
                    //foreach (DataGridViewCell cell in dgvTempConsolidar.SelectedCells)
                    {
                        DataGridViewRow row = dgv.Rows[cell.RowIndex];
                        //DataGridViewRow row = dgvTempConsolidar.Rows[cell.RowIndex];
                        intNroOrden = row.Cells[3].Value.ToString();
                        dtFecha = Convert.ToDateTime(row.Cells[1].Value.ToString());
                        strIdTipoExamen = row.Cells[10].Value.ToString();
                        strDNI = row.Cells[8].Value.ToString();

                        drFila = Consolidar.DatosBaseLaboral(dtFecha, dtFecha, true, true, intNroOrden, strIdTipoExamen, strDNI);
                        if (drFila != null)
                            dtConsulta.ImportRow(drFila);

                        drFila = null;
                    }
                }
            }
            else
            {
                if (dgv.Rows.Count > 0)
                //if (dgvTempConsolidar.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    //foreach (DataGridViewRow row in dgvTempConsolidar.Rows)
                    {
                        intNroOrden = row.Cells[3].Value.ToString();
                        dtFecha = Convert.ToDateTime(row.Cells[1].Value.ToString());
                        strIdTipoExamen = row.Cells[10].Value.ToString();
                        strDNI = row.Cells[8].Value.ToString();

                        drFila = Consolidar.DatosBaseLaboral(dtFecha, dtFecha, true, true, intNroOrden, strIdTipoExamen, strDNI);
                        if (drFila != null)
                            dtConsulta.ImportRow(drFila);

                        drFila = null;
                    }
                }
            }

            return dtConsulta;
        }

        // Consolidar Estudios
        private void ListarArchivosBase()
        {
            DataTable dt;
            ListaArchivosPdf = new List<string>();

            string strError = "";
            string strUltimaFecha = "";
            
            dt = dtTempConsolidar;
            dtTempConsolidar = null;

            string strDirecConsolTemp = "";
            string strDia = "";
            string strMes = "";
            string strAnio = "";
            string strNombreMes = "";
            string strFechaCorta = "";

            intTotalProcesoTemp = dt.Rows.Count;

            if (dt.Rows.Count > 0)
            {
                maximoProcesoBarra(dt.Rows.Count);
                strError = "";

                foreach (DataRow r in dt.Rows)
                {
                    strDia = UtilMepryl.NroDia(Convert.ToDateTime(r.ItemArray[0])).ToUpper();
                    strMes = UtilMepryl.NroMes(Convert.ToDateTime(r.ItemArray[0])).ToUpper();
                    strNombreMes = UtilMepryl.NombreMes(Int32.Parse(strMes)).ToUpper();
                    strAnio = Convert.ToString(Convert.ToDateTime(r.ItemArray[0]).Year).ToUpper();
                    strFechaCorta = strDia + "-" + strMes + "-" + strAnio;

                    strDirecConsolTemp = strDirectorioConsolidar + "\\" + strAnio + "\\" + strMes + "-" + strNombreMes
                                                           + "\\" + strFechaCorta + "\\";

                    dtArchivosPDF.Rows.Add(strDia,
                                           strMes,
                                           strAnio,
                                           r.ItemArray[1].ToString(), // NroOrden
                                           r.ItemArray[2].ToString(), // DNI
                                           r.ItemArray[3].ToString()); // Nombre                   

                    if (!string.IsNullOrEmpty(r.ItemArray[4].ToString()))
                    {
                        if (Int32.Parse(r.ItemArray[4].ToString()) != 502) // 502 significa "INFANTIL INICIAL"    
                        {
                            CargarArchivoClinico(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(), 6, strAnio, Boolean.Parse(r.ItemArray[5].ToString()));
                            CargarArchivoLaboratorio(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(), 7, strAnio, Boolean.Parse(r.ItemArray[6].ToString()));
                            CargarArchivoECG(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 8, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[8].ToString()));
                            CargarArchivoRX(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 9, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[7].ToString()));
                            CargarArchivoAudiometria(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 10, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[11].ToString()));
                            CargarArchivoOtoscopia(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 11, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[14].ToString()));
                            CargarArchivoErgometria(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 12, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[12].ToString()));
                            CargarArchivoEspirometria(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 13, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[15].ToString()));                            
                            CargarArchivoPsicotecnico(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 14, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[10].ToString()));
                            CargarArchivoEEG(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 15, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[9].ToString()));
                            CargarArchivoEcoDoppler(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(), 16, strAnio, Boolean.Parse(r.ItemArray[13].ToString()));
                        }
                        else
                        {
                            CargarArchivoLaboratorio(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(), 6, strAnio, Boolean.Parse(r.ItemArray[6].ToString()));
                            CargarArchivoRX(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 7, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[8].ToString()));
                            
                        }

                        //if (Int32.Parse(r.ItemArray[1].ToString()) < 200 || Int32.Parse(r.ItemArray[1].ToString()) > 399)
                        //    strError = UtilMepryl.ConcatenarPDFs(dtArchivosPDF, strDirecConsolTemp + "MOVIL");
                        //else
                        //strError = UtilMepryl.ConcatenarPDFsLaboral(dtArchivosPDF, strDirecConsolTemp + "CLINICA", ListaArchivosPdf);
                        strError = UtilMepryl.ConcatenarPDFsLaboral(dtArchivosPDF, strDirecConsolTemp, ListaArchivosPdf);
                        ListaArchivosPdf.Clear();
                        //---
                        //VerificaEstudiosComplementarios(r, r.ItemArray[1].ToString(), r.ItemArray[2].ToString());

                        if (!string.IsNullOrEmpty(strError))
                        {
                            DialogResult result = MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + dt.Rows.Count.ToString() + " archivos creados.\n¡El sistema ha experimentado un error.!\n\nDesea continuar con el proceso...\n\nDetalles:\n---\n" + strError, "Proceso incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.No)
                            {
                                //HabilitarBotonComenzar();
                                blnActualizaLista = true;
                                OcultarProgresoBarra();
                                SubProceso01.Join();
                                break;
                            }
                            if (intContador <= 0)
                                intContador = 0;
                            else
                                intContador--;
                        }

                        strDirecConsolTemp = "";
                        dtArchivosPDF.Clear();
                        IncreProcesoBarra(++intContador);
                        EstadoExamenLaboral.ActualizaConsolidadoExamen(r.ItemArray[16].ToString());
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strUltimaFecha))
                            strUltimaFecha = Convert.ToDateTime(r.ItemArray[0]).ToShortDateString();
                    }
                }                
            }            
            OcultarProgresoBarra();
            
            blnActualizaLista = true;
            SubProceso01.Join();
        }

        private void maximoProcesoBarra(int Max)
        {
            if (progressBar.InvokeRequired)
            {
                MethodInvoker mi = new MethodInvoker(() => progressBar.Maximum = Max);
                progressBar.Invoke(mi);
            }
        }

        private void VerificaEstudiosComplementarios(DataRow Requerido, string Orden, string DNI)
        {
            string strFecha = Convert.ToDateTime(Requerido.ItemArray[0].ToString()).ToShortDateString();

            if (bool.Parse(Requerido.ItemArray[9].ToString()))
                RegistrarError(strFecha, Orden, DNI, "EEG");
            if (bool.Parse(Requerido.ItemArray[10].ToString()))
                RegistrarError(strFecha, Orden, DNI, "Psicotecnico");
            if (bool.Parse(Requerido.ItemArray[11].ToString()))
                RegistrarError(strFecha, Orden, DNI, "Audiometria");
            if (bool.Parse(Requerido.ItemArray[12].ToString()))
                RegistrarError(strFecha, Orden, DNI, "Ergometria");
            if (bool.Parse(Requerido.ItemArray[13].ToString()))
                RegistrarError(strFecha, Orden, DNI, "Ecodoppler");
        }

        private void CargarArchivoClinico(string DNI, string Mes, string Dia, string NombreMes, string NroOrden, int Posicion, string Anio, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = NroOrden + "*" + DNI + "*C.pdf";
            string strFecha = Dia + "/" + Mes + "/" + Anio;
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioClinico + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                ListaArchivosPdf.Add(fi.FullName);
                            }

                            else
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "Clinico");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Clinico");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para Clinico.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Clinico");
                    }
                }
            }
        }

        private void CargarArchivoLaboratorio(string DNI, string Mes, string Dia, string NombreMes, string NroOrden, int Posicion, string Anio, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = NroOrden + "*" + DNI + "*L.pdf";
            string strFecha = Dia + "/" + Mes + "/" + Anio;
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioLaboratorio + "\\" + Anio + "\\" + Mes + "-" + NombreMes
                                                         + "\\" + Dia + "\\";

            Requerido = true; // Modificado para acepte todos los laboratorios

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                ListaArchivosPdf.Add(fi.FullName);
                            }
                            else
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Laboratorio");
                    }

                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para laboratorio.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Laboratorio");
                    }
                }
            }
        }

        private void CargarArchivoECG(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = NroOrden + "_*ECG*_" + Dia + "*.pdf";
            string strFecha = Dia + "/" + Mes + "/" + Anio;
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioECG + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                ListaArchivosPdf.Add(fi.FullName);
                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "ECG");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "ECG");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "ECG");
                    }
                }
            }
        }

        private void CargarArchivoAudiometria(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            
            //string strFecha = Dia + "/" + Mes + "/" + Anio;
            string strFecha = Dia + Mes + Anio;
            string strFiltro = NroOrden + "-" + strFecha + "-*.pdf";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioAudioMetria + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";


            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                                ListaArchivosPdf.Add(fi.FullName);
                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "Audiometria");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Audiometria");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Audiometria");
                    }
                }
            }
        }

        private void CargarArchivoOtoscopia(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            string strArchivoOtoscop = "";
            //string strFecha = Dia + "/" + Mes + "/" + Anio;
            string strFecha = Dia + Mes + Anio;
            string strFiltro = NroOrden + "_" + strFecha + "_*.pdf";
            bool blnVeri01 = false;
                        
            strArchivoOtoscop = strDirectorioAudioMetria + "\\" + Anio + "\\" + "OTOSCOPIA.pdf";

            if (Requerido)
            {
                try
                {
                    blnVeri01 = true;

                    if (dtArchivosPDF.Rows.Count > 0)
                    {
                        if (System.IO.File.Exists(strArchivoOtoscop) && Requerido == true)
                            ListaArchivosPdf.Add(strArchivoOtoscop);
                        else
                        {
                            //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                            ListaArchivosPdf.Add("");
                            if (Requerido)
                                RegistrarError(strFecha, NroOrden, DNI, "Otoscopia");
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Otoscopia");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Audiometria");
                    }
                }
            }
        }

        private void CargarArchivoEEG(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";            
            //string strFecha = Dia + "/" + Mes + "/" + Anio;
            string strFecha = Dia + Mes + Anio;
            string strFiltro = NroOrden + "-" + strFecha + "-*.pdf";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioEEG + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                                ListaArchivosPdf.Add(fi.FullName);
                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "EEG");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "EEG");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "EEG");
                    }
                }
            }
        }

        private void CargarArchivoPsicotecnico(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";            
            //string strFecha = Dia + "/" + Mes + "/" + Anio;
            string strFecha = Dia + Mes + Anio;
            string strFiltro = NroOrden + "-" + strFecha + "-*.pdf";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioPsicotecnico + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                                ListaArchivosPdf.Add(fi.FullName);
                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "Psicotecnico");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Psicotecnico");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Psicotecnico");
                    }
                }
            }
        }

        private void CargarArchivoErgometria(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";            
            //string strFecha = Dia + "/" + Mes + "/" + Anio;
            string strFecha = Dia + "_" + Mes+ "_" + Anio;
            string strFiltro = NroOrden + "_*_" + strFecha + ".pdf";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioErgometria + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                                ListaArchivosPdf.Add(fi.FullName);
                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "Ergometria");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Ergometria");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Ergometria");
                    }
                }
            }
        }

        private void CargarArchivoEspirometria(string Dia, string Mes, string Anio, string NroOrden, string NombreMes, int Posicion, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = "";
            string strFecha = "";
            string strFecha01 = "";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioEspirometria + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            Mes = Mes.Substring(0, 2);
            //strFecha = Anio + Mes + Dia;
            strFecha = Dia + Mes + Anio;
            strFecha01 = Dia + "/" + Mes + "/" + Anio;
            //strFiltro = strFecha + "*_" + NroOrden + "_*.jpg";            
            strFiltro = NroOrden + " - " + DNI + " - " + strFecha + " - *.pdf";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);

                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                            {
                                strDirRXTemp = fi.FullName;
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                ListaArchivosPdf.Add(fi.FullName);
                            }
                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "Espirometria");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha01, NroOrden, DNI, "Espirometria");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha01, NroOrden, DNI, "Espirometria");
                    }
                }
            }
        }

        private void CargarArchivoRX(string Dia, string Mes, string Anio, string NroOrden, string NombreMes, int Posicion, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = "";
            string strFecha = "";
            string strFecha01 = "";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioRX + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            Mes = Mes.Substring(0, 2);
            strFecha = Anio + Mes + Dia;
            strFecha01 = Dia + "/" + Mes + "/" + Anio;
            //strFiltro = strFecha + "*_" + NroOrden + "_*.jpg";            
            strFiltro = strFecha + "*_" + NroOrden + " *_?????_*.jpg";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);

                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                            {
                                strDirRXTemp = fi.FullName;
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                //Posicion++;
                                ListaArchivosPdf.Add(fi.FullName);
                            }
                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "RX"); Posicion++;
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha01, NroOrden, DNI, "RX");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha01, NroOrden, DNI, "RX");
                    }
                }
            }
        }

        private void CargarArchivoEcoDoppler(string DNI, string Mes, string Dia, string NombreMes, string NroOrden, int Posicion, string Anio, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = NroOrden + "*" + DNI + "*.pdf";
            string strFecha = Dia + "/" + Mes + "/" + Anio;
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioEcodoppler + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);
                    foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (System.IO.File.Exists(fi.FullName))
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                ListaArchivosPdf.Add(fi.FullName);
                            }

                            else
                            {
                                //dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "Ecodoppler");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Ecodoppler");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para Clinico.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Ecodoppler");
                    }
                }
            }
        }

        private void bbiConsolidarEstudios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botRevalidarCondicionales_Click(sender, e);
        }

        private void timerActualizaEstados_Tick(object sender, EventArgs e)
        {
            while (blnActualizaLista)
            {
                if (!dgv.InvokeRequired)
                {
                    blnActualizaLista = false;
                    timerActualizaEstados.Enabled = false;

                    if (intProcesoActivo == 1)
                    {
                        bbiConsolidarEstudios.Enabled = true;
                        MessageBox.Show("¡El proceso ha finalizado!.", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else if (intProcesoActivo == 2)
                    {
                        MensajesConsolidar();
                        //botRevalidarCondicionales.Enabled = true;
                        bbiConsolidarEstudios.Enabled = true;
                    }

                    intProcesoActivo = 0;
                    //actualizarExamenes();
                    ProcesoRefrescarLista();
                    seleccionarCelda();
                    return;
                }
            }
        }

        private void MensajesConsolidar()
        {
            if (intTotalProcesoTemp > 0)
            {
                if (intContador != intTotalProcesoTemp)
                    MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + intTotalProcesoTemp.ToString() + " archivos creados.\n\n No se han cargado todos los estudio a partir de la fecha ", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (dtMensajeError.Rows.Count > 0)
                    {
                        DialogResult result01 = MessageBox.Show("Se ha completado el proceso de consolidación.\n" + intTotalProcesoTemp.ToString() + " archivos creados.\nAlgunos archivos están incompletos.\n\n¿Ver examenes faltantes para los siguientes Nros. de Orden?", "Proceso completo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result01 == DialogResult.Yes)
                        {
                            frmMensajeAlerta frm = new frmMensajeAlerta("Los siguientes exámenes no fueron incluidos en el proceso de consolidado", "Proceso de Consolidación", dtMensajeError);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se ha completado el proceso de consolidación.\n" + intTotalProcesoTemp.ToString() + " archivos creados.", "Proceso completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se han cargado estudios para la fecha señalada.\n\nDebe exportar exámenes de laboratorio y clinico para continuar...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExamenSeleccionado()
        {
            if (dgv.Rows.Count > 0)
            {
                celda = dgv.SelectedCells[0].ColumnIndex;
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    if (celda == cell.ColumnIndex)
                    {
                        DataGridViewRow row = dgv.Rows[cell.RowIndex];

                        AbrirCarperta(row.Cells[3].Value.ToString(), Convert.ToDateTime(row.Cells[1].Value.ToString()));
                    }
                }
            }
        }

        private void UbicarArchivoDisco(string FullPath)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + FullPath + "\"");
        }

        private void AbrirCarperta(string NroOrden, DateTime Fecha)
        {
            string strDia = "";
            string strMes = "";
            string strAnio = "";
            string strDirecConsolTemp = "";
            string strNombreMes = "";
            string strFechaCorta = "";
            string strFiltro = NroOrden + " -*";

            strDia = UtilMepryl.NroDia(Fecha).ToUpper();
            strMes = UtilMepryl.NroMes(Fecha).ToUpper();
            strNombreMes = UtilMepryl.NombreMes(Int32.Parse(strMes)).ToUpper();
            strAnio = Convert.ToString(Fecha.Year).ToUpper();
            strFechaCorta = strDia + "-" + strMes + "-" + strAnio;

            strDirecConsolTemp = DirectorioConsolidaddo() + "\\" + strAnio + "\\" + strMes + "-" + strNombreMes
                                                          + "\\" + strFechaCorta + "\\";

            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirecConsolTemp);
                foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                {
                    if (System.IO.File.Exists(fi.FullName))
                        //System.Diagnostics.Process.Start(fi.DirectoryName);
                        UbicarArchivoDisco(fi.FullName);
                    else
                        MessageBox.Show("No se encontro el archivo de consolidado en la ruta.\n" + fi.DirectoryName, "Examenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show("No se encontro el archivo de consolidado.", "Examenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string DirectorioConsolidaddo()
        {
            CapaNegocioMepryl.ConsolidarReportes Consolidar = new CapaNegocioMepryl.ConsolidarReportes();
            string strDirectorioConsolidar = "";

            DataTable dt = Consolidar.DirectoriosLaboral();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    strDirectorioConsolidar = r.ItemArray[10].ToString();
                }
            }

            return strDirectorioConsolidar;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 23)
            {
                ExamenSeleccionado();
            }

            if (e.ColumnIndex == 24)
            {
                AbrirOutlookCorreo(dgv.Rows[e.RowIndex].Cells[8].Value.ToString(),           // DNI
                        dgv.Rows[e.RowIndex].Cells[3].Value.ToString(),                      // NroOrden
                        Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells[1].Value.ToString()),  // Fecha
                        dgv.Rows[e.RowIndex].Cells[20].Value.ToString(),                     // IdTipoExamen
                        dgv.Rows[e.RowIndex].Cells[5].Value.ToString());                     // IdEmpresa
            }

            celda = e.ColumnIndex;

            seleccionarCeldaMail();
        }

        private void PermisosUsuario()
        {
            bool blnModificar = false;
            bool blnVer = false;
            bool blnEliminar = false;

            if (!string.IsNullOrEmpty(UsuarioGlobal.Usuario))
            {
                UsuarioSistema user = new UsuarioSistema();
                DataTable dt = null;


                dt = user.ListaPermisoUserName(UsuarioGlobal.Usuario);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        blnVer = Convert.ToBoolean(fila["PermisoVer"].ToString());
                        blnModificar = Convert.ToBoolean(fila["PermisoModificar"].ToString());
                        blnEliminar = Convert.ToBoolean(fila["PermisoEliminar"].ToString());
                    }

                    ModoPermisos(blnVer, blnModificar, blnEliminar);
                }
            }
        }

        private void ModoPermisos(bool blnVer, bool blnModificar, bool blnEliminar)
        {
            if (blnVer == true)
            {
                ribbonPageGroup1.Enabled = false;
                blnUsuarioPuedeModificar = blnModificar;
            }

            if (blnEliminar == false)
            {
                //ribbonPageGroup1.Enabled = true;
                //bbiEliminar.Enabled = blnEliminar;
            }

            if (blnModificar == true)
            {
                ribbonPageGroup1.Enabled = true;
                blnUsuarioPuedeModificar = blnModificar;
            }
        }

        private void AbrirOutlookCorreo(string strDNI, string strNroOrden, DateTime dtFecha, string strIDTipoExamen, string strIdEmpresa)
        {
            CapaNegocioMepryl.PacienteLaboral Paciente = new CapaNegocioMepryl.PacienteLaboral();
            CapaNegocioMepryl.EnviarCorreoConOutlook Outlook = new CapaNegocioMepryl.EnviarCorreoConOutlook();
            CapaNegocioMepryl.ConfigMensajesCorreo Mensaje = new CapaNegocioMepryl.ConfigMensajesCorreo();
            CapaNegocioMepryl.ExamenPreventiva preventiva = new CapaNegocioMepryl.ExamenPreventiva();

            DataTable dt = null;
            string strMail = ""; 
            string strBody = "";
            string strAsunto = "";
            string strArchivo = "";
            string strNombreEmpresa = "";            
            string strNombrePaciente = "";            
            bool blnEnviado = false;
            int intValor = 0;
            string strIdPaciente = "";

            strIdPaciente = Paciente.obtenerIdPaciente(strDNI);

            dt = Paciente.MailPacientePorEmpresa(strIdPaciente, strIdEmpresa);

            foreach (DataRow fila in dt.Rows)
            {                
                strNombreEmpresa = fila["razonSocial"].ToString();
                strNombrePaciente = fila["Apellido"].ToString() + " " + fila["Nombres"].ToString();

                if (strNombreEmpresa == "PARTICULARES")
                {
                    strMail = fila["EmailPaciente"].ToString();
                }
                else
                {
                    strMail = fila["Email"].ToString();
                }                
            }
            dt = null;

            dt = Mensaje.ListarCorreosId(3, "L");
            foreach (DataRow fila in dt.Rows)
            {
                strAsunto = fila["Asunto"].ToString();
                strBody = fila["Mensaje"].ToString();
            }
            dt = null;

            strBody = strBody.Replace("<<Nombre>>", strNombrePaciente);
            strBody = strBody.Replace("<<dni>>", strDNI);
            strBody = strBody.Replace("<<Empresa>>", strNombreEmpresa);

            strArchivo = UbicarArchivoMail(strNroOrden, dtFecha);
            if (System.IO.File.Exists(strArchivo))
            {
                FileInfo file = new FileInfo(strArchivo);
                intValor = Convert.ToInt32((file.Length / 1024) / 1024);
            }

            if (!string.IsNullOrEmpty(strArchivo) && !string.IsNullOrEmpty(strMail) && (intValor < 20))
            {
                blnEnviado = Outlook.AbrirOutlook(strMail, strAsunto, strBody, strArchivo);
            }
            else
            {
                string strValorMail = "NO";
                string strValorConsolidado = "NO";
                string strTamañoArchivo = intValor + "MB Tiene que ser menor a 20MB";

                if (!string.IsNullOrEmpty(strArchivo))
                    strValorConsolidado = "SI";
                if (!string.IsNullOrEmpty(strMail))
                    strValorMail = "SI";
                if (intValor < 20)
                    strTamañoArchivo = intValor + "MB. Max permitido 20MB";

                MsgBoxUtil.HackMessageBox("Enviar", "No enviar");
                DialogResult Respuesta = MessageBox.Show("El paciente no cumple con los datos necesarios para enviar el Correo-E\n\n * Tiene Email: " + strValorMail + "\n * Tiene Consolidado: " + strValorConsolidado + "\n * Tamaño Archivo: " + strTamañoArchivo, "Envió de correo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //blnEnviado = Outlook.AbrirOutlook(strMail, strAsunto, strBody, strArchivo);

                if (Respuesta == DialogResult.Yes)
                {
                    blnEnviado = Outlook.AbrirOutlook(strMail, strAsunto, strBody, strArchivo);
                }
                else
                {
                    blnEnviado = false;
                }
            }

            if (blnEnviado)
                preventiva.actualizarEnvioMail(strIDTipoExamen);

            
            actualizar();
        }

        private string UbicarArchivoMail(string NroOrden, DateTime Fecha)
        {
            string strDia = "";
            string strMes = "";
            string strAnio = "";
            string strDirecConsolTemp = "";
            string strNombreMes = "";
            string strFechaCorta = "";
            string strFiltro = NroOrden + " -*";
            string strPath = "";

            strDia = UtilMepryl.NroDia(Fecha).ToUpper();
            strMes = UtilMepryl.NroMes(Fecha).ToUpper();
            strNombreMes = UtilMepryl.NombreMes(Int32.Parse(strMes)).ToUpper();
            strAnio = Convert.ToString(Fecha.Year).ToUpper();
            strFechaCorta = strDia + "-" + strMes + "-" + strAnio;

            strDirecConsolTemp = DirectorioConsolidaddo() + "\\" + strAnio + "\\" + strMes + "-" + strNombreMes
                                                          + "\\" + strFechaCorta + "\\";

            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirecConsolTemp);
                foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                {
                    if (System.IO.File.Exists(fi.FullName))
                        strPath = fi.FullName;
                    else
                        strPath = "";
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                strPath = "";
            }

            return strPath;
        }

        private void ExportarAudioMetrias()
        {
            int intCont = 0;
            if (dgv.Rows.Count > 0)
            {
                // Comentar
                MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
                DialogResult resultExamen = MessageBox.Show("¿Desea exportar todos los estudios de la fecha?\n", "Exportar Examenes",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                // Comentar

                if (resultExamen == DialogResult.Yes)
                {
                    // Comentar
                    progressBar.Visible = true;
                    progressBar.Minimum = 1;
                    progressBar.Maximum = dgv.Rows.Count;
                    progressBar.Step = 1;
                    // Comentar

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                && row.Cells[17].Value.ToString() != "0")
                        {
                            ExportarAudioPDF(row);
                            
                            // Comentar
                            progressBar.PerformStep();
                            // Comentar
                            IncreProcesoBarra(++intCont);
                        }
                    }

                    // Comentar                    
                    progressBar.Visible = false;
                    // Comentar
                }
                else if (resultExamen == DialogResult.No)
                {
                    if (dgv.SelectedCells.Count > 0)
                    {
                        // Comentar
                        progressBar.Visible = true;
                        progressBar.Minimum = 1;
                        progressBar.Value = 1;
                        progressBar.Maximum = dgv.Rows.Count;
                        progressBar.Step = 1;
                        // Comentar

                        celda = dgv.SelectedCells[0].ColumnIndex;
                        foreach (DataGridViewCell cell in dgv.SelectedCells)
                        {
                            if (celda == cell.ColumnIndex)
                            {
                                DataGridViewRow row = dgv.Rows[cell.RowIndex];
                                if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                    row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                    && row.Cells[17].Value.ToString() != "0")
                                {
                                    ExportarAudioPDF(row);
                                    
                                    // Comentar
                                    progressBar.PerformStep();
                                    // Comentar
                                    IncreProcesoBarra(++intCont);
                                }
                            }
                        }

                        // Comentar                        
                        progressBar.Visible = false;
                        // Comentar
                    }
                }

                MessageBox.Show("El proceso de exportación ha finalizado.", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportarAudioPDF(DataGridViewRow r)
        {
            string strNroOrden = "";
            DateTime dtFecha;

            strNroOrden = r.Cells[3].Value.ToString();
            dtFecha = Convert.ToDateTime(r.Cells[1].Value.ToString());

            LanzarReporteAudiometria(strNroOrden, dtFecha);
        }

        private void bbiExportarAudio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportarAudioMetrias();
        }

        private void seleccionarCeldaMail()
        {
            dgv.ClearSelection();
            try
            {
                if (puntero != -1)
                {
                    dgv.Rows[puntero].Cells[celda].Selected = true;
                    //dgv.Rows[puntero].Selected = true;
                    //dgv.CurrentCell = dgv.Rows[puntero].Cells[14];
                }
                else
                {
                    dgv.Rows[0].Cells[1].Selected = true;
                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                if (dgv.Rows.Count > 0)
                {
                    dgv.Rows[0].Cells[1].Selected = true;
                }
            }
        }
    }
}
