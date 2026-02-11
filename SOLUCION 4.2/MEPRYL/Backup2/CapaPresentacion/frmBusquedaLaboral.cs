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

namespace CapaPresentacion
{
    public partial class frmBusquedaLaboral : Form
    {
        private CapaNegocioMepryl.CargaLaboral laboral;
        private CapaNegocioMepryl.Examen examenLaboral;
        private CapaNegocioMepryl.Consultorio consultorio;
        private CapaNegocioMepryl.UtilidadesMepryl UtilMepryl; // GRV - Modificado
        private int puntero;
        private int celda;
        private bool modificarPunteros;
        private string strBoton = "";
        private int intFilaSelecc = 0;  // GRV - Modificado
        Thread SubProceso02;
        DataTable dtMensajeError;
        DialogResult resultExamen01;
        DialogResult resultExamen02;

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


        private void botBuscar_Click(object sender, EventArgs e)
        {
            puntero = -1;
            celda = -1;
            cargarExamenesSinFiltro(tpDesde.Value, tpHasta.Value, obtenerFiltro());
        }

        private void cargarExamenesSinFiltro(DateTime desde, DateTime hasta, List<string> filtro)
        {
            DataTable laborales = laboral.cargarListadoSinFiltro(desde, hasta, filtro);
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
            if (dgv.Rows.Count > 0) { dgv.Rows.Clear(); }
            foreach (DataRow r in laborales.Rows)
            {
                dgv.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], r.ItemArray[3], r.ItemArray[4], r.ItemArray[5],
                    r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9], r.ItemArray[10], r.ItemArray[11], r.ItemArray[12],
                    r.ItemArray[13], null, r.ItemArray[15], r.ItemArray[16], r.ItemArray[17], r.ItemArray[18], r.ItemArray[19], r.ItemArray[20]);
                bool colorGris = colorearFila(dgv.Rows[dgv.Rows.Count - 1]);
                if (r.ItemArray[19].ToString() == "")
                {
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
        }

        public void actualizar()
        {
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
                Utilidades.abrirFormulario(this.MdiParent, frm, new Configuracion());
                frm.setearLabelTitulo(dgv.Rows[c.RowIndex].Cells[4].Value.ToString());
                frm.setearValores(dgv.Rows[c.RowIndex].Cells[18].Value.ToString());
            }
            else if (dgv.Rows[c.RowIndex].Cells[12].Value.ToString() == "1")
            {
                frmExamenLaboral frm = new frmExamenLaboral(this);
                Utilidades.abrirFormulario(this.MdiParent, frm, new Configuracion());
                frm.setearLabelTitulo(dgv.Rows[c.RowIndex].Cells[4].Value.ToString());
                frm.setearValores(dgv.Rows[c.RowIndex].Cells[11].Value.ToString(), dgv.Rows[c.RowIndex].Cells[6].Value.ToString(),
                dgv.Rows[c.RowIndex].Cells[7].Value.ToString(), dgv.Rows[c.RowIndex].Cells[8].Value.ToString() + " - " +
                dgv.Rows[c.RowIndex].Cells[9].Value.ToString(), dgv.Rows[c.RowIndex].Cells[1].Value.ToString(),
                dgv.Rows[c.RowIndex].Cells[4].Value.ToString(), dgv.Rows[c.RowIndex].Cells[3].Value.ToString(),
                dgv.Rows[c.RowIndex].Cells[8].Value.ToString(), dgv.Rows[c.RowIndex].Cells[17].Value.ToString());
            }
            puntero = c.RowIndex;
            celda = c.ColumnIndex;
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
            //switch (strBoton)
            //{
            //    case "Ex. Aptitud":
            //        botL_CheckedChanged(sender, e);
            //        break;
            //    case "Consultorios":
            //        botCO_CheckedChanged(sender, e);
            //        break;
            //    case "Domicilios":
            //        botV_CheckedChanged(sender, e);
            //        break;
            //}

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
            if (botL.Checked) { lbTitulo.Text = "Ex. Aptitud"; botImprimirEx.Visible = false; }
            if (botCO.Checked) { lbTitulo.Text = "Consultorios"; botImprimirEx.Visible = false; }
            if (botV.Checked) { lbTitulo.Text = "Domicilios"; botImprimirEx.Visible = false; }
            if (botCO.Checked && botV.Checked) { lbTitulo.Text = "Consultorios/Domicilios"; botImprimirEx.Visible = false; }
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
            if (dgv.CurrentCell != null && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                abrirVentana(dgv.CurrentCell);
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

            SubProceso02 = new Thread(ExportarExamPDF);
            SubProceso02.Start();
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
                            ExportarProtocoloPDF(row, 2);
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
                                    ExportarProtocoloPDF(row, 2);
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
                MessageBox.Show("El proceso de exportación ha finalizado.", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            OcultarProgresoBarra();
            SubProceso02.Join();
        }
        
        private void botImprimirEx_Click(object sender, EventArgs e)
        {

        }

        private void ExportarClincoPDF(DataGridViewRow r)
        {
            string strIdExamenLaboral = r.Cells[17].Value.ToString();
            string strDNI = r.Cells[8].Value.ToString();

            string strNombreArchivo = "";
            string strNombreArchivoEspirometria = "";

            strNombreArchivo = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + " - C.pdf";
            strNombreArchivoEspirometria = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + ".pdf";

            Reportes report = new Reportes(new rptExamenLaboral());
            report.exportarAPDF(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, false),
            new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(strDNI), "3"),
            UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "CLINICOS Y LABORATORIOS") + strNombreArchivo);

            GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "ESPIROMETRIA") + strNombreArchivoEspirometria, false);
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

        private void ExportarProtocoloPDF(DataGridViewRow r, sbyte tipoReporte)
        {
            string strIdExamenLaboral = r.Cells[17].Value.ToString();
            string strNombreArchivo = "";
            DataTable dtConsulta = examenLaboral.cargarParametrosLaboratorio(strIdExamenLaboral, tipoReporte);
            Reportes report = new Reportes(new rptProtocoloLaboratorioLaboral());

            strNombreArchivo = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + " - L.pdf";

            if (dtConsulta.Rows.Count > 0)
            {
                //if (string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[31].ToString()) && string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[32].ToString()))
                //{
                //    report = null;
                //    report = new Reportes(new rptProtocoloLaboratorioLaboral01());
                //}
                bool blnPerfilLipidico01 = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[31].ToString());
                bool blnPerfilLipidico02 = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[32].ToString());
                bool blnCreatininaArbitro = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[66].ToString());

                if (dtConsulta.Rows[0].ItemArray[31].ToString() != "0" && dtConsulta.Rows[0].ItemArray[31].ToString() != "0") 
                {
                    if (blnPerfilLipidico01 && blnPerfilLipidico02)
                    {
                        report = null;
                        report = new Reportes(new rptProtocoloLaboratorioLaboral01());
                    }
                }

                if (!blnCreatininaArbitro) 
                {
                    if (dtConsulta.Rows[0].ItemArray[66].ToString() != "0")
                    {
                        report = null;
                        report = new Reportes(new rptProtocoloLaboratorioLaboral02());
                    }
                }
            }
                        
            report.ExportarLaboratorio(dtConsulta, 
                UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 4, "CLINICOS Y LABORATORIOS") + strNombreArchivo);
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
            //ExportarOlivera();
        }

        private void ExportarOlivera()
        {
            int intCont = 0;

            if (dgv.Rows.Count > 0)
            {
                //MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
                //DialogResult resultExamen = MessageBox.Show("¿Desea exportar todos los estudios de la fecha?\n\n    Presione No para exportar solo los exámenes seleccionados.", "Exportar Examenes",
                //MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultExamen02 == DialogResult.Yes)
                {
                    //progressBar.Visible = true;
                    //progressBar.Minimum = 1;
                    //progressBar.Value = 1;
                    //progressBar.Maximum = dgv.Rows.Count;
                    //progressBar.Step = 1;

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                && row.Cells[17].Value.ToString() != "0")
                        {
                            ExportarOliveraPDF(row);
                            ExportarProtocoloPDF(row, 2);
                            //progressBar.PerformStep();
                            IncreProcesoBarra(++intCont);
                        }
                    }

                    //SubProceso02 = new Thread(Exportacion_B01);
                    //SubProceso02.Start();                                       
                }
                else if (resultExamen02 == DialogResult.No)
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
                                    ExportarOliveraPDF(row);
                                    ExportarProtocoloPDF(row, 2);
                                    //progressBar.PerformStep();
                                    IncreProcesoBarra(++intCont);
                                }
                            }
                        }

                        //SubProceso02 = new Thread(Exportacion_B02);
                        //SubProceso02.Start();

                        //progressBar.Visible = false;
                    }
                }
            }

            MessageBox.Show("El proceso de exportación ha finalizado.", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            OcultarProgresoBarra();
            SubProceso02.Join();
        }

        private void ExportarOliveraPDF(DataGridViewRow r)
        {
            string strIdExamenLaboral = r.Cells[17].Value.ToString();
            string strDNI = r.Cells[8].Value.ToString();

            string strNombreArchivo = "";
            string strNombreArchivoEspirometria = "";

            strNombreArchivo = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + " - C.pdf";
            strNombreArchivoEspirometria = r.Cells[3].Value.ToString() + " - " + r.Cells[8].Value.ToString() + " - " + ConvertirFechaString(r.Cells[1].Value.ToString()) + " - " + r.Cells[9].Value.ToString() + ".pdf";

            Reportes report = new Reportes(new rptExamenLaboral());
            report.exportarAPDF(examenLaboral.cargarParametrosExamen(strIdExamenLaboral, true),
            new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(strDNI), "4"),
            UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "CLINICOS Y LABORATORIOS") + strNombreArchivo);

            GenerarReporteEspirometria(strDNI, strIdExamenLaboral, r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString(), UtilMepryl.CreaDirectorioPorFecha(Convert.ToDateTime(r.Cells[1].Value.ToString()), 3, "ESPIROMETRIA") + strNombreArchivoEspirometria, true);
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
                    ExportarProtocoloPDF(row, 2);
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
                        ExportarProtocoloPDF(row, 2);
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
                    ExportarProtocoloPDF(row, 2);
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
                        ExportarProtocoloPDF(row, 2);
                        //progressBar.PerformStep();
                    }
                }
            }
        }

        private void botImportar_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmImportarLaboratorioLaboral(), new Configuracion());
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
    }
}
