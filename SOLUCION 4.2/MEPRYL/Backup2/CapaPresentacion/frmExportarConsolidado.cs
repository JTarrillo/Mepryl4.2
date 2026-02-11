using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmExportarConsolidado : Form
    {
        CapaNegocioMepryl.ConsolidarReportes Consolidar;
        CapaNegocioMepryl.UtilidadesMepryl UtilMepryl;
        CapaNegocioMepryl.ExamenPreventiva ExamPreventiva;
        CapaNegocioMepryl.ReporteWord CrearReporte;
        DataTable dtArchivosPDF;
        DataTable dtMensajeError;
        private string strDirectorioECG = "";
        private string strDirectorioClinico = "";
        private string strDirectorioLaboratorio = "";
        private string strDirectorioInfRadiologico = "";
        private string strDirectorioRX = "";
        private string strDirectorioConsolidar = "";
        private string strArchivoPlantilla = "";
        private int intContador = 0;
        Thread SubProceso02;

        private bool blnEstado = false;
        private string strDirRXTemp = "";

        public frmExportarConsolidado()
        {
            InitializeComponent();
            Consolidar = new CapaNegocioMepryl.ConsolidarReportes();
            UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl();
            ExamPreventiva = new CapaNegocioMepryl.ExamenPreventiva();
            CrearReporte = new CapaNegocioMepryl.ReporteWord();

            CargarDirectorios();
            EstablecerColumnas();
        }

        private void CargarDirectorios()
        {
            DataTable dt = Consolidar.Directorios();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    strDirectorioInfRadiologico = r.ItemArray[0].ToString();
                    strDirectorioClinico = r.ItemArray[1].ToString();
                    strDirectorioLaboratorio = r.ItemArray[2].ToString();
                    strDirectorioRX = r.ItemArray[3].ToString();
                    strDirectorioECG = r.ItemArray[4].ToString();
                    strDirectorioConsolidar = r.ItemArray[5].ToString();
                    strArchivoPlantilla = r.ItemArray[6].ToString();
                }
            }
        }

        private void frmExportarConsolidado_Load(object sender, EventArgs e)
        {
            txtUbicacion.Text = strDirectorioConsolidar;
            dtpFechaDesde.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now;
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            //ListarArchivosBase();
            intContador = 0;
            lblTarea.Text = "BUSCANDO ARCHIVOS...";
            btnComenzar.Enabled = false;
            btnCancelar.Enabled = true;
            blnEstado = false;
            dtMensajeError.Clear();
            iniciaProcesoBarra();
            SubProceso02 = new Thread(ListarArchivosBase);
            SubProceso02.Start();
        }

        private void btnAbrirUbicacion_Click(object sender, EventArgs e)
        {
            txtUbicacion.Text = SelectDirectorio();
        }

        private string SelectDirectorio()
        {
            string strDirectorio = "";
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                strDirectorio = fbdMostrarDirectorio.SelectedPath;
            }

            return strDirectorio;
        }

        private void ListarArchivosBase()
        {
            string strError = "";
            
            string strUltimaFecha = "";
            DataTable dt = Consolidar.DatosBase(dtpFechaDesde.Value, dtpFechaHasta.Value, chkMovil.Checked, chkClinica.Checked);
            
            string strDirecConsolTemp = "";
            string strDia = "";  
            string strMes = "";
            string strAnio = "";
            string strNombreMes = "";
            string strFechaCorta = "";
            string strIdTipoExamen = "";

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
                    strIdTipoExamen = ExamPreventiva.ObtieneTipoExamenPaciente(Convert.ToDateTime(r.ItemArray[0]), r.ItemArray[2].ToString());
                    
                    strDirecConsolTemp = txtUbicacion.Text + "\\" + strAnio + "\\" + strMes + "-" + strNombreMes
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
                            CargarArchivoClinico(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(),6, strAnio, Boolean.Parse(r.ItemArray[5].ToString()));
                            CargarArchivoLaboratorio(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(), 7, strAnio, Boolean.Parse(r.ItemArray[6].ToString()));
                            CargarArchivoECG(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 8, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[8].ToString()));
                            CargarArchivoRX(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 9, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[7].ToString()));
                        }
                        else
                        {
                            CargarArchivoLaboratorio(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(), 6, strAnio, Boolean.Parse(r.ItemArray[6].ToString()));
                            CargarArchivoRX(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 7, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[8].ToString()));
                            CargarArchivoRadiologico(r.ItemArray[2].ToString(), strMes, strDia, strAnio, strNombreMes, r.ItemArray[1].ToString(), 8, Boolean.Parse(r.ItemArray[5].ToString()));
                        }                        

                        if (Int32.Parse(r.ItemArray[1].ToString()) < 200 || Int32.Parse(r.ItemArray[1].ToString()) > 399)
                            strError = UtilMepryl.ConcatenarPDFs(dtArchivosPDF, strDirecConsolTemp + "MOVIL");
                        else
                            strError = UtilMepryl.ConcatenarPDFs(dtArchivosPDF, strDirecConsolTemp + "CLINICA");

                        //---
                        VerificaEstudiosComplementarios(r, r.ItemArray[1].ToString(), r.ItemArray[2].ToString());

                        if (!string.IsNullOrEmpty(strError))
                        {
                            DialogResult result = MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + dt.Rows.Count.ToString() + " archivos creados.\n¡El sistema ha experimentado un error.!\n\nDesea continuar con el proceso...\n\nDetalles:\n---\n" + strError, "Proceso incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (result == DialogResult.No)
                            {
                                HabilitarBotonComenzar();
                                OcultarProgresoBarra();
                                SubProceso02.Join();
                                break;                
                            }

                            intContador--;
                        }

                        strDirecConsolTemp = "";
                        dtArchivosPDF.Clear();                        
                        IncreProcesoBarra(++intContador);
                        ExamPreventiva.ActualizaConsolidadoExamen(strIdTipoExamen);
                        
                        if (blnEstado == true)
                        {
                            if (dtMensajeError.Rows.Count > 0)
                            {
                                DialogResult result01 = MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + dt.Rows.Count.ToString() + " archivos creados.\nEl proceso fue cancelado.\n\n¿Ver examenes faltantes para los siguientes Nros. de Orden?", "Proceso incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (result01 == DialogResult.Yes)
                                {
                                    frmMensajeAlerta frm = new frmMensajeAlerta("Los siguientes exámenes no fueron incluidos en el proceso de consolidado", "Proceso de Consolidación", dtMensajeError);
                                    frm.ShowDialog();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + dt.Rows.Count.ToString() + " archivos creados.\n\nEl proceso fue cancelado.", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            HabilitarBotonComenzar();
                            OcultarProgresoBarra();
                            SubProceso02.Join();
                            break;                            
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strUltimaFecha))
                            strUltimaFecha = Convert.ToDateTime(r.ItemArray[0]).ToShortDateString();                        
                    }
                }

                if (intContador != dt.Rows.Count)
                    MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + dt.Rows.Count.ToString() + " archivos creados.\n\n No se han cargado todos los estudio a partir de la fecha " + strUltimaFecha, "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (dtMensajeError.Rows.Count > 0)
                    {
                        DialogResult result01 = MessageBox.Show("Se a completado el proceso de consolidación.\n" + dt.Rows.Count.ToString() + " archivos creados.\nAlgunos archivos estan inclompetos.\n\n¿Ver examenes faltantes para los siguientes Nros. de Orden?", "Proceso completo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result01 == DialogResult.Yes)
                        {
                            frmMensajeAlerta frm = new frmMensajeAlerta("Los siguientes exámenes no fueron incluidos en el proceso de consolidado", "Proceso de Consolidación", dtMensajeError);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se a completado el proceso de consolidación.\n" + dt.Rows.Count.ToString() + " archivos creados.", "Proceso completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se han cargado estudios para la fecha señalada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            HabilitarBotonComenzar();
            OcultarProgresoBarra();
            SubProceso02.Join();
        }

        private void CargarArchivoLaboratorio(string DNI, string Mes, string Dia, string NombreMes, string NroOrden, int Posicion, string Anio, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = NroOrden + "*" + DNI + "*L.pdf";
            string strFecha = Dia+"/"+Mes+"/"+Anio;
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioLaboratorio + "\\" + Mes + "-" + NombreMes
                                                         + "\\" + Dia + "\\";
            try
            {
                DirectoryInfo di = new DirectoryInfo(strDirectorioBase);
                foreach (var fi in di.GetFiles(strFiltro, SearchOption.AllDirectories))
                {
                    blnVeri01 = true;

                    if (dtArchivosPDF.Rows.Count > 0)
                    {
                        if (File.Exists(fi.FullName))
                            dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                        else
                            dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
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

        private void CargarArchivoRadiologico(string DNI, string Mes, string Dia, string Anio, string NombreMes, string NroOrden, int Posicion, bool Requerido)
        {
            GenerarInfoRadiologico(DNI, Mes, Dia, Anio, NombreMes, NroOrden, Posicion, Requerido);
        }

        private void CargarArchivoClinico(string DNI, string Mes, string Dia, string NombreMes, string NroOrden, int Posicion, string Anio, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = NroOrden + "*" + DNI + "*C.pdf";
            string strFecha = Dia + "/" + Mes + "/" + Anio;
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioClinico + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            try
            {
                DirectoryInfo di = new DirectoryInfo(strDirectorioBase);
                foreach (var fi in di.GetFiles(strFiltro, SearchOption.AllDirectories))
                {
                    blnVeri01 = true;

                    if (dtArchivosPDF.Rows.Count > 0)
                    {
                        if (File.Exists(fi.FullName))
                            dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                        else
                        {
                            dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
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

        private void CargarArchivoECG(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = NroOrden + "_*ECG*_" + Dia + "*.pdf";
            string strFecha = Dia + "/" + Mes + "/" + Anio;
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioECG + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            try
            {
                DirectoryInfo di = new DirectoryInfo(strDirectorioBase);
                foreach (var fi in di.GetFiles(strFiltro, SearchOption.AllDirectories))
                {
                    blnVeri01 = true;

                    if (dtArchivosPDF.Rows.Count > 0)
                    {
                        if (File.Exists(fi.FullName))
                            dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                        else
                        {
                            dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
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

        private void CargarArchivoRX(string Dia, string Mes, string Anio, string NroOrden, string NombreMes, int Posicion, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = "";
            string strFecha = "";
            string strFecha01 = "";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioRX + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            Mes = Mes.Substring(0, 2);
            strFecha = Anio + Mes + Dia;
            strFecha01 = Dia + "/" + Mes + "/" + Anio;
            //strFiltro = strFecha + "*_" + NroOrden + "_*.jpg";
            strFiltro = strFecha + "_??????_" + NroOrden + "_*.jpg";

            try
            {
                DirectoryInfo di = new DirectoryInfo(strDirectorioBase);

                if (Convert.ToInt32(NroOrden) < 200)
                {
                    foreach (var fi in di.GetFiles(strFiltro, SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (File.Exists(fi.FullName))
                            {
                                strDirRXTemp = fi.FullName;
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                            }
                            else
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "RX");
                            }
                        }
                    }
                }
                else
                {
                    strFiltro = strFecha + "*_" + NroOrden + " DNI*.jpg";

                    foreach (var fi in di.GetFiles(strFiltro, SearchOption.AllDirectories))
                    {
                        blnVeri01 = true;

                        if (dtArchivosPDF.Rows.Count > 0)
                        {
                            if (File.Exists(fi.FullName))
                            {
                                strDirRXTemp = fi.FullName;
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                            }
                            else
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "RX");
                            }
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
            dtArchivosPDF.Columns.Add("ImgRX01");

            dtMensajeError.Columns.Add("Fecha");
            dtMensajeError.Columns.Add("Orden");
            dtMensajeError.Columns.Add("DNI");            
            dtMensajeError.Columns.Add("Mensaje");            
        }

        private void GenerarInfoRadiologico(string DNI, string Mes, string Dia, string Anio ,string NombreMes, string NroOrden, int Posicion, bool Requerido)
        {               
            DataTable dt = ExamPreventiva.ListaInformeRadiologico(dtpFechaDesde.Value, dtpFechaHasta.Value, DNI, NroOrden);
            List<string> strNombreArchivoRadiologico = new List<string>();
            string strDirectorioBase = "";
            string[,] Etiquetas = new string[5,2];
            string strPath = "";
            string strFecha = "";

            //strDirectorioBase = Consolidar.DirectorioPlacaRX(strDirectorioRX, Anio + Mes + Dia, NroOrden);
            
            if (File.Exists(strDirRXTemp))
                strDirectorioBase = Path.GetDirectoryName(strDirRXTemp).ToString();
            
            if (dt.Rows.Count > 0)
            {
                strNombreArchivoRadiologico.Add(Dia);
                strNombreArchivoRadiologico.Add(Mes);
                strNombreArchivoRadiologico.Add(Anio);
                strNombreArchivoRadiologico.Add(NroOrden);
                strNombreArchivoRadiologico.Add(DNI);
                strFecha = Anio + Mes + Dia;

                foreach(DataRow r in dt.Rows)
                {
                    Etiquetas[0, 0] = "<<Fecha>>"; Etiquetas[0, 1] = Convert.ToDateTime(r.ItemArray[0].ToString()).ToShortDateString();
                    Etiquetas[1, 0] = "<<Nro.Examen>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                    Etiquetas[2, 0] = "<<DNI>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                    Etiquetas[3, 0] = "<<Apellido>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                    Etiquetas[4, 0] = "<<Conclusiones>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();

                    strNombreArchivoRadiologico.Add(r.ItemArray[3].ToString());
                }

                strPath = UtilMepryl.PathArchivoConsolidado(strNombreArchivoRadiologico, strDirectorioBase);                

                CrearReporte.CreateWordDocument(strArchivoPlantilla, strPath, new object(), Etiquetas);

                Array.Clear(Etiquetas, 0, Etiquetas.Length);

                if (dtArchivosPDF.Rows.Count > 0)
                {
                    if (File.Exists(strPath))
                        dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = strPath;
                    else
                    {
                        dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Radiologico");
                    }
                }
                
                strDirRXTemp = "";
            }
        }
        
        // Barra de progreso - Inicio
        private void iniciaProcesoBarra()
        {
            pgrBarraProgreso.Visible = true;
            pgrBarraProgreso.Minimum = 1;            
            pgrBarraProgreso.Step = 1;
            lblTarea.Visible = true;
        }

        private void maximoProcesoBarra(int Max)
        {
            if (pgrBarraProgreso.InvokeRequired)
            {
                MethodInvoker mi = new MethodInvoker(() => pgrBarraProgreso.Maximum = Max);
                pgrBarraProgreso.Invoke(mi);
            }
        }

        private void IncreProcesoBarra(int intValor)
        {
            if (intValor < 1)
                intValor++;

            if (pgrBarraProgreso.InvokeRequired)
            {
                MethodInvoker mi = new MethodInvoker(() => pgrBarraProgreso.Value = intValor);
                pgrBarraProgreso.Invoke(mi);
            }
            else
            {
                pgrBarraProgreso.PerformStep();
            }
        }

        private void OcultarProgresoBarra()
        {
            if (pgrBarraProgreso.InvokeRequired)
            {
                MethodInvoker mi = new MethodInvoker(() => pgrBarraProgreso.Visible = false);
                pgrBarraProgreso.Invoke(mi);
                MethodInvoker mo = new MethodInvoker(() => lblTarea.Visible = false);
                lblTarea.Invoke(mo);                
            }
        }
        // Barra de progreso - Fin

        private void HabilitarBotonComenzar()
        {
            if (btnComenzar.InvokeRequired)
            {
                MethodInvoker mi = new MethodInvoker(() => btnComenzar.Enabled = true);
                btnComenzar.Invoke(mi);
            }
        }

        private void btnIgualarFecha_Click(object sender, EventArgs e)
        {
            dtpFechaHasta.Value = dtpFechaDesde.Value;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = false;            
            blnEstado = true;
            lblTarea.Text = "CANCELANDO...";
        }

        private void ErrorGenerararchivo(string Mensaje, string Fecha)
        {
            DialogResult result = MessageBox.Show("Proceso de consolidación incompleto.\nEl sistema ha experimentado un error!. No encuentra los archivos para la fecha " + Fecha + "\n\nDesea continuar con el proceso...\n\nDetalles:\n---\n" + Mensaje, "Proceso incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.No)
            {
                HabilitarBotonComenzar();
                OcultarProgresoBarra();
                SubProceso02.Join(); 
            }
        }

        private void RegistrarError(string Fecha, string Orden, string DNI, string Mensaje)
        {
            dtMensajeError.Rows.Add(Fecha, Orden, DNI, Mensaje);
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
    }
}
