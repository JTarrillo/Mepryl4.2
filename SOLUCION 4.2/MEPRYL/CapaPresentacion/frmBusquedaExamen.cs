using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using System.Net.Mail;
using System.Threading;
using CapaNegocioMepryl;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmBusquedaExamen : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.ExamenPreventiva preventiva;
        
        int puntero = -1;
        int celda = -1;
        Color color;
        DataTable valoresExamen;
        DataTable cacheDgv;
        DataTable clasif;
        DataTable valid;
        DataTable valor;
        DataTable ligYClub;
        DataRow[] filtroTabla;
        string filtro = "";
        int nroFila = -1;
        int modo = -1;
        frmMesaDeEntrada frm;
        Thread SubProceso01;
        Thread SubProceso02;
        Thread SubProceso03;
        private int intContador = 0;
        DataTable dtArchivosPDF;  // Inicio Consolidado
        DataTable dtMensajeError;
        CapaNegocioMepryl.ConsolidarReportes Consolidar = new ConsolidarReportes();
        CapaNegocioMepryl.UtilidadesMepryl UtilMepryl = new UtilidadesMepryl();
        CapaNegocioMepryl.ExamenPreventiva ExamPreventiva = new ExamenPreventiva();
        CapaNegocioMepryl.ReporteWord CrearReporte = new ReporteWord();
        private string strDirectorioECG = "";
        private string strDirectorioClinico = "";
        private string strDirectorioLaboratorio = "";
        private string strDirectorioInfRadiologico = "";
        private string strDirectorioRX = "";
        private string strDirectorioConsolidar = "";
        private string strArchivoPlantilla = "";
        private string strDirRXTemp = "";        
        private string strDirectorioAudioMetria = "";
        private string strDirectorioErgometria = "";
        private bool blnEstadoProcesarConsolidado = false;
        private bool blnEstadoProcesarExportaPDF = false;
        private int intPunteroCol = 0;
        private int intPunteroFil = 0;
        private DataTable dtTempConsolidar;
        private bool blnActualizaLista = false;
        private int intTotalProcesoTemp = 0;
        private byte intProcesoActivo = 0; // 1 Exporta PDF, 2 Consolida
        List<string> strDestinatarios = new List<string>();
        List<string> strArchivosAdjuntos = new List<string>();
        List<string> ListaArchivosPdf;

        public bool blnExamenModificado = false;
        public bool blnUsuarioPuedeModificar = true;
        
        // -----------------
        public frmBusquedaExamen()
        {
            InitializeComponent();
            preventiva = new ExamenPreventiva();
            
            CheckForIllegalCrossThreadCalls = false;
            this.ActiveControl = dgvExamenes;
            dgvExamenes.VirtualMode = true;
            dgvExamenes.CellValueNeeded += new
              DataGridViewCellValueEventHandler(dgvExamenes_CellValueNeeded);
        }

        public frmBusquedaExamen(frmMesaDeEntrada f, int m)
        {
            InitializeComponent();
            preventiva = new ExamenPreventiva();
            
            this.ActiveControl = dgvExamenes;
            dgvExamenes.VirtualMode = true;
            dgvExamenes.CellValueNeeded += new
              DataGridViewCellValueEventHandler(dgvExamenes_CellValueNeeded);
            modo = m;
            frm = f;
        }

        public frmBusquedaExamen(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            preventiva = new ExamenPreventiva();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            CheckForIllegalCrossThreadCalls = false;
            this.ActiveControl = dgvExamenes;
            dgvExamenes.VirtualMode = true;
            dgvExamenes.CellValueNeeded += new
              DataGridViewCellValueEventHandler(dgvExamenes_CellValueNeeded);
        }

        private void frmBusquedaExamen_Load(object sender, EventArgs e)
        {
            rbcMenu.Minimized = true;

            llenarCombo("select id, descripcion from dbo.Liga where descripcion != 'A DESIGNAR...' order by descripcion asc", cboL, "id", "descripcion", "TODAS",0);
            llenarCombo("select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' order by descripcion asc", cboC, "id", "descripcion", "TODOS",0);
            llenarCombo("select id, descripcion from dbo.Validaciones where codigo = '90' order by CONVERT(int,codigoInterno) asc", cboD, "id", "descripcion", "TODOS",1);
            dgvExamenes.Columns[10].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[12].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[14].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[16].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[21].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[23].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[27].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[29].DefaultCellStyle.NullValue = null;
            cboTipoBusqueda.SelectedIndex = 1;
            filtro = "";
            inicializarTabla();
            tamañoColumnas();
            rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;

            PermisosUsuario();
        }

        private void inicializarTabla()
        {
            cacheDgv = new DataTable();
            cacheDgv.Columns.Add("idTe"); // index 0
            cacheDgv.Columns.Add("idC"); // index 1
            cacheDgv.Columns.Add("Fecha"); // index 2
            cacheDgv.Columns.Add("NEx"); // index 3
            cacheDgv.Columns.Add("Liga"); // index 4
            cacheDgv.Columns.Add("Club"); // index 5
            cacheDgv.Columns.Add("Categoria"); // index 6
            cacheDgv.Columns.Add("DNI"); // index 7
            cacheDgv.Columns.Add("Paciente"); // index 8
            cacheDgv.Columns.Add("txtCLI"); // index 9
            cacheDgv.Columns.Add("CLI"); // index 10
            cacheDgv.Columns.Add("txtLAB"); // index 11
            cacheDgv.Columns.Add("LAB"); // index 12
            cacheDgv.Columns.Add("txtRX"); // index 13
            cacheDgv.Columns.Add("RX"); // index 14
            cacheDgv.Columns.Add("txtCAR"); // index 15
            cacheDgv.Columns.Add("CAR"); // index 16
            cacheDgv.Columns.Add("txtDICT"); // index 17
            cacheDgv.Columns.Add("DICF"); // index 18
            cacheDgv.Columns.Add("RM"); // index 19
            cacheDgv.Columns.Add("txtIMP"); // index 20
            cacheDgv.Columns.Add("IMP"); // index 21
            cacheDgv.Columns.Add("txtIMPLAB");  // index 22
            cacheDgv.Columns.Add("IMPLAB");  // index 23 
            cacheDgv.Columns.Add("txtINF"); // index 24
            cacheDgv.Columns.Add("INF"); // index 25
            cacheDgv.Columns.Add("txtConsolidado"); // index 26
            cacheDgv.Columns.Add("Cons"); // index 27
            cacheDgv.Columns.Add("txtEnviado"); // index 28
            cacheDgv.Columns.Add("Enviado"); // index 29
            cacheDgv.Columns.Add("Color"); // index 30
            
            cacheDgv.Columns[10].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[12].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[14].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[16].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[21].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[23].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[25].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[27].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[29].DataType = System.Type.GetType("System.Byte[]");
            cacheDgv.Columns[30].DataType = typeof(System.Drawing.Color);
            cargarExamenes(DateTime.Today, DateTime.Today);
        }

        private void inicializarGridView() //Metodo que crea la dgv visible(Desde aca se edita el layout)
        {
            DataGridViewImageColumn col2 = new DataGridViewImageColumn();
            col2.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col21 = new DataGridViewImageColumn();
            col21.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col22 = new DataGridViewImageColumn();
            col22.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col23 = new DataGridViewImageColumn();
            col23.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col24 = new DataGridViewImageColumn();
            col24.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col25 = new DataGridViewImageColumn();
            col25.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col26 = new DataGridViewImageColumn();
            col26.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col27 = new DataGridViewImageColumn();
            col27.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewImageColumn col28 = new DataGridViewImageColumn();
            col28.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            DataGridViewCheckBoxColumn col12 = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            dgvExamenes.Columns.Clear();
            dgvExamenes.Columns.Add("idTe", "idTe");
            dgvExamenes.Columns.Add("idC", "idC");
            dgvExamenes.Columns.Add("Fecha", "Fecha");
            dgvExamenes.Columns.Add("NEx", "Nº Ex.");
            dgvExamenes.Columns.Add("Liga", "Liga");
            dgvExamenes.Columns.Add("Club", "Club");
            dgvExamenes.Columns.Add("Categoria", "Categ.");
            dgvExamenes.Columns.Add("DNI", "DNI");
            dgvExamenes.Columns.Add("Paciente", "Paciente");
            dgvExamenes.Columns.Add("txtCLI", "txtCLI");
            dgvExamenes.Columns.Add(col2);            
            dgvExamenes.Columns.Add("txtLAB", "txtLAB");
            dgvExamenes.Columns.Add(col21);
            dgvExamenes.Columns.Add("txtRX", "txtRX");
            dgvExamenes.Columns.Add(col22);
            dgvExamenes.Columns.Add("txtCAR", "txtCAR");
            dgvExamenes.Columns.Add(col23);
            dgvExamenes.Columns.Add("txtDICT", "txtDICT");
            dgvExamenes.Columns.Add(col3);
            dgvExamenes.Columns.Add(col1);
            dgvExamenes.Columns.Add("txtIMP", "txtIMP");
            dgvExamenes.Columns.Add(col24);
            dgvExamenes.Columns.Add("txtIMPLAB", "txtIMPLAB");
            dgvExamenes.Columns.Add(col25);
            dgvExamenes.Columns.Add(col12);
            dgvExamenes.Columns.Add(col26);
            dgvExamenes.Columns.Add("txtConsolidado", "txtConsolidado");
            dgvExamenes.Columns.Add(col27);
            dgvExamenes.Columns.Add("txtEnviado", "txtEnviado");
            dgvExamenes.Columns.Add(col28);            

            dgvExamenes.Columns[0].Visible = false;
            dgvExamenes.Columns[1].Visible = false;
            dgvExamenes.Columns[9].Visible = false;
            dgvExamenes.Columns[10].Name = "CLI";
            dgvExamenes.Columns[10].HeaderText = "CLI";
            dgvExamenes.Columns[11].Visible = false;
            dgvExamenes.Columns[12].Name = "LAB";
            dgvExamenes.Columns[12].HeaderText = "LAB";
            dgvExamenes.Columns[13].Visible = false;
            dgvExamenes.Columns[14].Name = "RX";
            dgvExamenes.Columns[14].HeaderText = "RX";
            dgvExamenes.Columns[15].Visible = false;
            dgvExamenes.Columns[16].Name = "CAR";
            dgvExamenes.Columns[16].HeaderText = "ECG";
            dgvExamenes.Columns[17].Visible = false;
            dgvExamenes.Columns[18].Name = "DICF";
            dgvExamenes.Columns[18].HeaderText = "Dictámen Final";
            //dgvExamenes.Columns[18].DefaultCellStyle.Font.Bold;
            dgvExamenes.Columns[19].Name = "RM";
            dgvExamenes.Columns[19].HeaderText = "RM";
            dgvExamenes.Columns[20].Visible = false;
            dgvExamenes.Columns[21].Name = "IMP-C";
            dgvExamenes.Columns[21].HeaderText = "EXP-C";
            dgvExamenes.Columns[22].Visible = false;
            dgvExamenes.Columns[23].Name = "IMP-L";
            dgvExamenes.Columns[23].HeaderText = "EXP-L";
            dgvExamenes.Columns[24].Name = "RET";
            dgvExamenes.Columns[24].HeaderText = "RET";
            dgvExamenes.Columns[25].Name = "INF";
            dgvExamenes.Columns[25].HeaderText = "INF";
            dgvExamenes.Columns[25].Visible = false;
            dgvExamenes.Columns[26].Visible = false;            
            dgvExamenes.Columns[27].Name = "CONS";
            dgvExamenes.Columns[27].HeaderText = "CONS";
            dgvExamenes.Columns[28].Visible = false;
            dgvExamenes.Columns[29].Name = "ENV";
            dgvExamenes.Columns[29].HeaderText = "ENV";            
        }

        private void tamañoColumnas()
        {
            // GRV - Modificado
            dgvExamenes.Columns[2].Width = 75; //fecha
            dgvExamenes.Columns[3].Width = 65;  //NroExamen
            dgvExamenes.Columns[4].Width = 130; //Liga
            dgvExamenes.Columns[5].Width = 220; //Club
            dgvExamenes.Columns[6].Width = 45;  //Categoria
            dgvExamenes.Columns[7].Width = 70; //DNI
            dgvExamenes.Columns[8].Width = 180; //Nombre
            dgvExamenes.Columns[10].Width = 30;  //CLI
            dgvExamenes.Columns[12].Width = 30; //LAB
            dgvExamenes.Columns[14].Width = 30; //RX
            dgvExamenes.Columns[16].Width = 30; //ECG
            dgvExamenes.Columns[18].Width = 115;//Dictamen            
            dgvExamenes.Columns[19].Visible = false; //RM
            dgvExamenes.Columns[24].Visible = false; //Retirado
        }

        public void actualizarExamenes()
        {
            try
            {
                if (puntero != -1) { dictamenFinalAutomatico(puntero); }
                if (gbRango.Enabled) { cargarExamenes(tpDesde.Value, tpHasta.Value); }
                if (gbFecha.Enabled) { cargarExamenes(tpFecha.Value, tpFecha.Value); }
            }
            catch(System.ObjectDisposedException ex)
            {
                //
            }
        }

        public void cargarExamenes(DateTime desde, DateTime hasta)
        {
            try // GRV - Ramírez
            {
                //Form formTemp = new Form();
                //// formTemp.MdiChildren;
                
                //if (this.Text == "Exámenes")
                //{
                //    formTemp = this;
                //}

                progressBar.Visible = true;
                clasif = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Clasificaciones");
                valid = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
                valor = SQLConnector.obtenerTablaSegunConsultaString(@"select v.id as Id, v.descripcion as Descrip, c.codigo as Cod
                from dbo.Validaciones v 
                inner join dbo.Clasificaciones c on v.idClasif = c.id");
                ligYClub = SQLConnector.obtenerTablaSegunConsultaString("select c.id as id, c.descripcion as club, l.descripcion as liga from dbo.Club c inner join dbo.Liga l on c.ligaID = l.id");
                if (cacheDgv.Rows.Count > 0) { cacheDgv.Clear(); GC.Collect(); filtroTabla = null; }
                if (dgvExamenes.Rows.Count > 0) { dgvExamenes.Rows.Clear(); dgvExamenes.Refresh(); }
                DataTable tipoDeExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id as IdTE, c.id as IdC, 
                CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Examen', p.dni as DNI,
                (p.apellido + ' ' + p.nombres) as Paciente, tep.rm as RM, tep.imp as IMP, tep.inf as INF,
                tep.mail as Mail, tep.dictAut, tep.ImpLab, p.fechaNacimiento, tep.cons 
                from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id
                where c.tipo = 'P' and Convert(date,c.fecha) >= convert(date,'" + desde.ToShortDateString() + @"',105) and Convert(date,c.fecha)
                <= convert(date,'" + hasta.ToShortDateString() + "',105) " + filtro + " order by convert(int,c.identificador) asc, c.fecha asc");
                progressBar.Minimum = 1;
                progressBar.Value = 1;
                progressBar.Maximum = tipoDeExamen.Rows.Count;

                //inicializarGridView(); // GRV - Modificado
                foreach (DataRow row in tipoDeExamen.Rows)
                {
                    valoresExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select dictClinico, dictLab, dictRx, dictCar, dictFinal from dbo.ExamenPreventiva
                    where idTipoExamen = '" + row.ItemArray[0].ToString() + "'");
                    cargarValores(row);
                    progressBar.PerformStep();
                }
                filtroTabla = cacheDgv.Select(obtenerFiltroString());
                lblCantReg.Text = filtroTabla.Length + " Exámenes";
                sumarValores();
                try
                {
                    if (tipoDeExamen.Rows.Count > 0) { tipoDeExamen.Clear(); }
                    progressBar.Minimum = 1;
                    progressBar.Value = 1;
                    progressBar.Maximum = filtroTabla.Length;
                    dgvExamenes.RowCount = filtroTabla.Length;
                    if (dgvExamenes.Rows.Count > 0 && puntero != -1) { dgvExamenes.CurrentCell = dgvExamenes.Rows[puntero].Cells[celda]; }
                    if (dgvExamenes.Rows.Count > 0 && puntero == -1) { dgvExamenes.CurrentCell = dgvExamenes.Rows[0].Cells[2]; }
                    progressBar.Visible = false;
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                //    //this.Close();
                //    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    inicializarGridView();
                //    if (this.Text == "")
                //    {
                //        //this.Dispose();
                //        //frmBusquedaExamen frmBusqueda = new frmBusquedaExamen();
                //        this.Controls.Add(formTemp);
                //    }
                //    puntero = -1;
                //    cargarExamenes(tpFecha.Value, tpFecha.Value);
                //    //Comunes.Configuracion conf = new Comunes.Configuracion();
                //    //Form formExamen = new CapaPresentacion.frmBusquedaExamen();
                //    //Utilidades.abrirFormulario(this, formExamen, conf);
                }
                catch (System.NullReferenceException ex)
                {
                //    MessageBox.Show("ERROR - 2", "ERROR - 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    puntero = -1;
                }
            }
            catch (System.NullReferenceException ex)
            {
                //MessageBox.Show("ERROR - 3", "ERROR - 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //puntero = -1;
                //
            }
        }

        private void agregarFilaAlDgv(object idE, object idC, object fecha, object numeroEx,object liga, object club,object cat, object DNI, object pac,
            object txtCLI, object CLI, object txtLAB, object LAB, object txtRX, object RX, object txtCAR, object CAR,
            object txtDIC, object DIC, object RM, object txtIMP, object IMP, object txtIMPLAB, object IMPLAB, object txtINF, object INF, object txtCONS, 
            object CONS, object txtMAIL, object MAIL, object color)
        {
            cacheDgv.Rows.Add(idE, idC, fecha, numeroEx,liga, club,cat,DNI, pac, txtCLI, CLI, txtLAB, LAB, txtRX, RX, txtCAR, CAR,
                txtDIC, DIC, RM, txtIMP, IMP, txtIMPLAB, IMPLAB, txtINF, INF, txtCONS, CONS, txtMAIL, MAIL, color);
        }

        private string obtenerFiltroString()
        {
            string cadena = "";
            if (cboL.SelectedIndex != 0) { cadena = "Liga LIKE '%" + cboL.SelectedValue.ToString() + "%'"; }
            if (cboC.SelectedIndex != 0) { if (cadena == "") { cadena = "Club like '%" + cboC.SelectedValue.ToString() + "%'"; } else { cadena = cadena + " and Club like '%" + cboC.SelectedValue.ToString() + "%'"; }}
            if (cboD.SelectedIndex != 0) { if (cadena == "") { cadena = "DICF = '" + cboD.SelectedValue.ToString() + "'"; } else { cadena = cadena + " and DICF = '" + cboD.SelectedValue.ToString() + "'"; }}
            return cadena;
        }
        
        private void sumarValores()
        {
            int cli = 0;
            int lab = 0;
            int rx = 0;
            int car = 0;
            int nc = 0;
            int impE = 0;
            int impL = 0;
            foreach (DataRow row in filtroTabla)
            {
                if (row.ItemArray[9].ToString() == "0" && row.ItemArray[18].ToString() != "NO RENOVADO"
                    && row.ItemArray[18].ToString() != "NO EFECTUADO") { cli++; }
                if (row.ItemArray[11].ToString() == "0" && row.ItemArray[18].ToString() != "NO RENOVADO"
                    && row.ItemArray[18].ToString() != "NO EFECTUADO") { lab++; }
                if (row.ItemArray[13].ToString() == "0" && row.ItemArray[18].ToString() != "NO RENOVADO"
                    && row.ItemArray[18].ToString() != "NO EFECTUADO") { rx++; }
                if (row.ItemArray[15].ToString() == "0" && row.ItemArray[18].ToString() != "NO RENOVADO"
                    && row.ItemArray[18].ToString() != "NO EFECTUADO") { car++; }
                if (row.ItemArray[17].ToString() == "0" && row.ItemArray[18].ToString() != "NO RENOVADO"
                    && row.ItemArray[18].ToString() != "NO EFECTUADO") { nc++; }
                if (row.ItemArray[20].ToString() == "0" && row.ItemArray[18].ToString() != "NO RENOVADO"
                    && row.ItemArray[18].ToString() != "NO EFECTUADO") { impE++; }
                if (row.ItemArray[22].ToString() == "0" && row.ItemArray[18].ToString() != "NO RENOVADO"
                    && row.ItemArray[18].ToString() != "NO EFECTUADO") { impL++; }
            }
            txtCantFis.Text = cli.ToString();
            txtCantLab.Text = lab.ToString();
            txtCantRX.Text = rx.ToString();
            txtCantCar.Text = car.ToString();
            tbNoCarg.Text = nc.ToString();
            tbImpEx.Text = impE.ToString();
            tbImpLab.Text = impL.ToString();
        }

        private byte[] setearImagen(DataTable clasificaciones, string codigo)
        {
            if (codigo != "0")
            {
                DataRow[] row = clasificaciones.Select("id = " + codigo);

                return (byte[])row[0].ItemArray[3];
            }
            return null;
        }
         
        private void cargarValores(DataRow tipoDeExamen)
        {
            bool rm = false;
            if (tipoDeExamen.ItemArray[6].ToString() == "1")
            {
                rm = true;
            }
            string idTe = tipoDeExamen.ItemArray[0].ToString();
            string liga = "";
            string club = "";
            DataTable ligaYClubes = SQLConnector.obtenerTablaSegunConsultaString(@"select idClub from dbo.clubesPorTipoExamen 
            where idTipoExamen = '" + idTe + "'");

            try // GRV - Modificado 
            {
                foreach (DataRow r in ligaYClubes.Rows)
                {
                    if (liga == "") { liga = consultarLigaYClub(r.ItemArray[0].ToString(), 2); club = consultarLigaYClub(r.ItemArray[0].ToString(), 1); }
                    else { liga = liga + "/" + consultarLigaYClub(r.ItemArray[0].ToString(), 2); club = club + "/" + consultarLigaYClub(r.ItemArray[0].ToString(), 1); }
                }

                string idC = tipoDeExamen.ItemArray[1].ToString();
                string fecha = ((DateTime)tipoDeExamen.ItemArray[2]).ToShortDateString();
                string nroEx = tipoDeExamen.ItemArray[3].ToString();
                string dni = tipoDeExamen.ItemArray[4].ToString();
                string paciente = tipoDeExamen.ItemArray[5].ToString();
                string imp = tipoDeExamen.ItemArray[7].ToString();
                string mail = tipoDeExamen.ItemArray[9].ToString();
                string inf = tipoDeExamen.ItemArray[8].ToString();
                string impLab = tipoDeExamen.ItemArray[11].ToString();
                string cons = tipoDeExamen.ItemArray[13].ToString();
                string nacimiento = Convert.ToDateTime(tipoDeExamen.ItemArray[12].ToString()).Year.ToString();
                if (imp == "") { imp = "0"; }
                if (mail == "") { mail = "0"; }
                if (impLab == "") { impLab = "0"; }
                if (cons == "") { cons = "0"; }
                bool informado = true;
                if (inf == "0") { informado = false; }
                if (inf == "") { informado = false; }



                if (valoresExamen.Rows.Count > 0)
                {
                    string fisico = filtrarValores(valid, 0);
                    string lab = filtrarValores(valid, 1);
                    string rx = filtrarValores(valid, 2);
                    string car = filtrarValores(valid, 3);

                    byte[] imgFisico = setearImagenSegunValor(fisico, clasif);
                    byte[] imgLab = setearImagenSegunValor(lab, clasif);
                    byte[] imgRX = setearImagenSegunValor(rx, clasif);
                    byte[] imgCar = setearImagenSegunValor(car, clasif);
                    byte[] imgImp = setearImagen(clasif, imp);
                    byte[] imgMail = setearImagen(clasif, mail);
                    byte[] imgImpLab = setearImagen(clasif, impLab);
                    byte[] imgCons = setearImagen(clasif, cons);
                    fisico = consultarIdValidacion(0);
                    lab = consultarIdValidacion(1);
                    rx = consultarIdValidacion(2);
                    car = consultarIdValidacion(3);
                    string final = cargarDictamenFinal(tipoDeExamen, fisico, lab, rx, car, nroEx);
                    string valorFinal = consultarIdValidacion(4);
                    agregarFilaAlDgv(idTe, idC, fecha, nroEx, liga, club, nacimiento, dni, paciente, fisico, imgFisico, lab, imgLab,
                        rx, imgRX, car, imgCar, valorFinal, final, rm, imp, imgImp, impLab, imgImpLab, informado, setearImagen(clasif, "0"),
                        cons, imgCons, mail, imgMail, color);
                }
                else
                {
                    Color colorVacio;
                    if (Convert.ToInt16(nroEx) >= 200) { colorVacio = Color.White; } else { colorVacio = Color.Gainsboro; }
                    agregarFilaAlDgv(idTe, idC, fecha, nroEx, liga, club, nacimiento,
                           dni, paciente, "0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"),
                           "0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"), "0", "NO CARGADO",
                           rm, "0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"), informado, setearImagen(clasif, "0"),"0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"), colorVacio);
                }
            }
            catch (System.IndexOutOfRangeException ex)
            {
                //
            } 
        }

        private string consultarLigaYClub(string idClub, int posicion)
        {
            return ligYClub.Select("id = '" + idClub + "'")[0][posicion].ToString();
        }



        private byte[] setearImagenSegunValor(string valor, DataTable clasificaciones)
        {
            if (valor != "0") { return setearImagen(clasificaciones,valor); } else { return setearImagen(clasificaciones,"0"); }
        }


        private string filtrarValores(DataTable validaciones,int posicion)
        {
            if (valoresExamen.Rows.Count > 0 && valoresExamen.Rows[0][posicion].ToString() != "")
            {
             
                    DataRow[] valid = validaciones.Select("id = " + valoresExamen.Rows[0][posicion].ToString());
                    return valid[0][6].ToString();
            }

            return "0";
        }

        private string consultarIdValidacion(int posicion)
        {

            if (valoresExamen.Rows.Count > 0 && valoresExamen.Rows[0][posicion].ToString() != "")
            {
                return valoresExamen.Rows[0].ItemArray[posicion].ToString();

            }
            return "0";

        }

        private string cargarDictamenFinal(DataRow tipoExamen, string fis, string lab,
            string rx, string car, string nroEx)
        {

                if (valoresExamen.Rows.Count > 0 && valoresExamen.Rows[0].ItemArray[4].ToString() != "")
                {
                    string idValidacion;
                    idValidacion = valoresExamen.Rows[0].ItemArray[4].ToString();

                    DataRow[] r = valor.Select("Id = " + idValidacion);


                    switch (Convert.ToInt16(r[0][2].ToString()))
                    {
                        case 1:
                            color = Color.DarkSeaGreen;
                            break;
                        case 2:
                            color = Color.Khaki;
                            break;
                        case 3:
                            color = Color.IndianRed;
                            break;
                        case 4:
                            color = Color.LightBlue; ;
                            break;
                        case 5:
                            color = Color.PeachPuff;
                            break;
                    }
                    return r[0][1].ToString();
                }
                if (Convert.ToInt16(nroEx) >= 200){ color = Color.White; } else { color = Color.Gainsboro; }
                return "NO CARGADO";              
   
        }

        private void dictamenFinalAutomatico(int puntero)
        {
            try
            {
                preventiva.dictamenFinalAutomatico(dgvExamenes.Rows[puntero].Cells[0].Value);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //
            }
        }

        private string consultarCodigoValidacion(DataTable ve, string codigo)
        {
            DataRow[] rows = ve.Select("codigo = '" + codigo + "'");
            if (rows.Length > 0)
            {
                string idValidacion = rows[0][3].ToString();
                DataRow[] r = valid.Select("id = " + idValidacion);
                return r[0][2].ToString();
            }
            else
            {
                return "00";
            }
        }


        private void dgvExamenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            puntero = dgvExamenes.CurrentCell.RowIndex;
            celda = e.ColumnIndex;

            if (e.RowIndex >= 0)
            {
              
                if (e.ColumnIndex == 10)
                {
                    abrirClinico(e.RowIndex);
                }

                if (e.ColumnIndex == 12)
                {
                    abrirLaboratorio(e.RowIndex);
                }

                if (e.ColumnIndex == 14)
                {
                    abrirRX(e.RowIndex);
                }
                
                if (e.ColumnIndex == 16)
                {
                    abrirCard(e.RowIndex);
                }

                if (e.ColumnIndex == 18)
                {
                    if (dgvExamenes.Rows[e.RowIndex].Cells[18].Value.ToString() != "NO RENOVADO"
                    && dgvExamenes.Rows[e.RowIndex].Cells[18].Value.ToString() != "NO EFECTUADO"
                    && dgvExamenes.Rows[e.RowIndex].Cells[18].Value.ToString() != "NO CARGADO")
                    {
                        //Utilidades.abrirFormulario(this.MdiParent, new frmDictamenFinal(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                        frmDictamenFinal frm = new frmDictamenFinal(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], true);
                        frm.ShowDialog();
                    }
                }

                if (e.ColumnIndex == 27)
                {
                    ExamenSeleccionado();
                }

                if(e.ColumnIndex == 29)
                {
                    AbrirOutlookCorreo(dgvExamenes.Rows[e.RowIndex].Cells[7].Value.ToString(),       // DNI
                        dgvExamenes.Rows[e.RowIndex].Cells[3].Value.ToString(),                      // NroOrden
                        Convert.ToDateTime(dgvExamenes.Rows[e.RowIndex].Cells[2].Value.ToString()),  // Fecha
                        dgvExamenes.Rows[e.RowIndex].Cells[0].Value.ToString());                     //    
                }

                puntero = dgvExamenes.CurrentCell.RowIndex;
                celda = e.ColumnIndex;

                SeleccinarFilaTurno(puntero, celda);
            } 
        }

        private void cambiarEstado(string idTe, string valor, string procedure)
        {
            string val = "0";
            if(valor == "False"){val = "1";}
            List<string> l = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure(procedure, l, idTe, val);
            actualizarExamenes();
        }


        private void tpFecha_ValueChanged(object sender, EventArgs e)
        {
            cargarExamenes(tpFecha.Value,tpFecha.Value);
        }

        private void dgvExamenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvExamenes.Rows.Count > 0)
            {
                puntero = dgvExamenes.CurrentCell.RowIndex;
                celda = dgvExamenes.CurrentCell.ColumnIndex;

                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    if (dgvExamenes.Rows[dgvExamenes.CurrentCell.RowIndex].Cells[18].Value.ToString() != "JUGADOR INHABILITADO")
                    {
                        if (dgvExamenes.CurrentCell.ColumnIndex == 10) { abrirClinico(dgvExamenes.CurrentCell.RowIndex); }
                        if (dgvExamenes.CurrentCell.ColumnIndex == 12) { abrirLaboratorio(dgvExamenes.CurrentCell.RowIndex); }
                        if (dgvExamenes.CurrentCell.ColumnIndex == 14) { abrirRX(dgvExamenes.CurrentCell.RowIndex); }
                        if (dgvExamenes.CurrentCell.ColumnIndex == 16) { abrirCard(dgvExamenes.CurrentCell.RowIndex); }

                        if (dgvExamenes.CurrentCell.ColumnIndex == 18)
                        {
                            //Utilidades.abrirFormulario(this.MdiParent, new frmDictamenFinal(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                            frmDictamenFinal frm = new frmDictamenFinal(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], true);
                            frm.ShowDialog();
                        }
                    }
                    puntero = dgvExamenes.CurrentCell.RowIndex;
                    celda = dgvExamenes.CurrentCell.ColumnIndex;

                    SeleccinarFilaTurno(puntero, celda);
                }
            }
        }

        private void abrirClinico(int r)
        {
            if (dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO RENOVADO" &&
                dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO EFECTUADO")
            {
                //Utilidades.abrirFormulario(this.MdiParent, new frmExamenFisico(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                frmExamenFisico frm = new frmExamenFisico(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], blnUsuarioPuedeModificar);
                frm.ShowDialog();

                if (blnExamenModificado)
                {
                    AlertaExamenModificado();
                    blnExamenModificado = false;
                }
            }
        }

        private void abrirLaboratorio(int r)
        {
            if (dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO RENOVADO"
                && dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO EFECTUADO"
                && dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO CARGADO")
            {
                //Utilidades.abrirFormulario(this.MdiParent, new frmExamenLaboratorio(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                frmExamenLaboratorio frm = new frmExamenLaboratorio(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], blnUsuarioPuedeModificar);
                frm.ShowDialog();

                if (blnExamenModificado)
                {
                    AlertaExamenModificado();
                    blnExamenModificado = false;
                }
            }

        }

        private void abrirRX(int r)
        {
            if (dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO RENOVADO"
                && dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO EFECTUADO"
                && dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO CARGADO")
            {
                //Utilidades.abrirFormulario(this.MdiParent, new frmRX(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                frmRX frm = new frmRX(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], blnUsuarioPuedeModificar);
                frm.ShowDialog();

                if (blnExamenModificado)
                {
                    AlertaExamenModificado();
                    blnExamenModificado = false;
                }
            }
        }

        private void abrirCard(int r)
        {
            if (dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO RENOVADO"
                && dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO EFECTUADO"
                && dgvExamenes.Rows[r].Cells[18].Value.ToString() != "NO CARGADO")
            {
                //Utilidades.abrirFormulario(this.MdiParent, new frmExamenCardiologia(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                frmExamenCardiologia frm = new frmExamenCardiologia(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], blnUsuarioPuedeModificar);
                frm.ShowDialog();

                if (blnExamenModificado)
                {
                    AlertaExamenModificado();
                    blnExamenModificado = false;
                }
            }
        }

        private void botImprimir_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(imprimir));
            //thread.Start();

            //SubProceso01 = new Thread(imprimir);
            //SubProceso01.Start();
            //imprimir();
            
        }

        private void imprimir()
        {
            DialogResult resultExamen = MessageBox.Show("¿Desea imprimir la carátula de exámen?", "Imprimir Carátula",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult resultProtocolo = MessageBox.Show("¿Desea imprimir el protocolo de laboratorio?", "Imprimir Protocolo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgvExamenes.SelectedCells.Count > 0)
            {
                puntero = dgvExamenes.SelectedCells[0].RowIndex;
                celda = dgvExamenes.SelectedCells[0].ColumnIndex;
                foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                {
                    if (celda == cell.ColumnIndex)
                    {
                        DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
                        if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                            row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                            && row.Cells[17].Value.ToString() != "0")
                        {
                            if (resultExamen == DialogResult.Yes) { imprimirExamen(row); }
                            if (resultProtocolo == DialogResult.Yes) { imprimirProtocolo(row); }
                        }
                        else
                        {
                            MessageBox.Show("No se puede imprimir el exámen Nº: " + row.Cells[3].Value.ToString() + " de la fecha: " +
                                row.Cells[2].Value.ToString() + " . ¡Faltan cargar estudios!",
                                "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            // GRV - M
            //actualizarExamenes();
            //SubProceso01.Join(); // Bloquea el subproceso actual
        }

        private void exportarPDF()
        {
            //if (dgvExamenes.Rows.Count > 0)
            //{
            //    DialogResult resultExamen = MessageBox.Show("¿Desea exportar todos los estudios de la fecha?\n\n    Presione No para exportar solo los exámenes seleccionados.", "Exportar Examenes",
            //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            //    if (resultExamen == DialogResult.Yes)
            //    {                    
            //        maximoProcesoBarra(dgvExamenes.Rows.Count);

            //        foreach (DataGridViewRow row in dgvExamenes.Rows)
            //        {
            //            if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
            //                    row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
            //                    && row.Cells[17].Value.ToString() != "0")
            //            {                            
            //                ExportarExamenPDF(row);
            //                ExportarProtocoloPDF(row);
            //                //progressBar.PerformStep();
            //                IncreProcesoBarra(++intContador);                            
            //            }
            //        }                    
            //    }
            //    else if(resultExamen == DialogResult.No)
            //    {
            //        if (dgvExamenes.SelectedCells.Count > 0)
            //        {                        
            //            maximoProcesoBarra(dgvExamenes.Rows.Count);

            //            celda = dgvExamenes.SelectedCells[0].ColumnIndex;
            //            foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
            //            {
            //                if (celda == cell.ColumnIndex)
            //                {
            //                    DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
            //                    if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
            //                        row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
            //                        && row.Cells[17].Value.ToString() != "0")
            //                    {
            //                        ExportarExamenPDF(row);
            //                        ExportarProtocoloPDF(row);
            //                        IncreProcesoBarra(++intContador);
            //                        //progressBar.PerformStep();                                    
            //                    }
            //                }
            //            }                        
            //        }
            //    }
            //}
            DataTable dt = new DataTable();
            dt = dtTempConsolidar;
            dtTempConsolidar = null;

            if (dt.Rows.Count > 0)
            {
                maximoProcesoBarra(dt.Rows.Count);

                foreach (DataRow row in dt.Rows)
                {
                    ExportarExamenPDF(row);
                    ExportarProtocoloPDF(row);

                    IncreProcesoBarra(++intContador);
                }
            }

            OcultarProgresoBarra();
            //MessageBox.Show("El proceso de exportación ha finalizado.", "Preventiva", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            //actualizarExamenes();
            //seleccionarCelda();
            blnActualizaLista = true;
            SubProceso02.Join();
        }        

        private void imprimirExamen(DataGridViewRow r)
        {
            Reportes report = new Reportes(new rptExamenPreventiva());

            Entidades.Resultado result = report.imprimirYExportar(preventiva.cargarParametrosExamen(r.Cells[0].Value, r.Cells[1].Value),
            new dsExamenPreventiva(), preventiva.cargarDataSourceExamen(),
            // GRV - Ramírez - Modificado
            // @"P:\ESTUDIOS TEMPORADA 2016\" + cargarRutaDestino(r,"E") + ".pdf");
            DirectorioReporte(1) + cargarRutaDestino(r, "E") + ".pdf");

            if (result.Modo == 1) { preventiva.actualizarImpresionExamen(r.Cells[0].Value); }
            else { MessageBox.Show(result.Mensaje); }
        }

        private string cargarRutaDestino(DataGridViewRow r, string tipo)
        {
            string strTexto = "";

            try
            {
                //DateTime fecha = Convert.ToDateTime(r.Cells[2].Value); //GRV - Modificado
                DateTime fecha = Convert.ToDateTime(r.Cells[2].Value.ToString());
                int dia = fecha.Day;
                string diaStr = dia.ToString();
                if (dia <= 9) { diaStr = "0" + diaStr; }

                int mes = fecha.Month;
                string mesStr = mes.ToString();
                if (mes <= 9) { mesStr = "0" + mesStr; }

                //return (diaStr + mesStr + fecha.Year.ToString() + "-" + r.Cells[7].Value.ToString() + "-" + tipo).Replace(" ", ""); //GRV - Modificado
                strTexto = (diaStr + mesStr + fecha.Year.ToString() + "-" + r.Cells[7].Value.ToString() + "-" + tipo).Replace(" ", "");
            }
            catch (System.FormatException ex)
            {
                //
            }
            return strTexto;
        }

        private string DirectorioReportePorFecha(DateTime Fecha, byte TipoReporte, string leyenda)
        {
            string strDirectorio = "";
            string strDirectorioBase = "";
            string strDia = "";

            if (!string.IsNullOrEmpty(leyenda))
                leyenda = leyenda + " ";

            strDia = Fecha.Day.ToString();

            if (Fecha.Day <= 9)
                strDia = "0" + Fecha.Day;

            strDirectorioBase = DirectorioExportacion(TipoReporte);
            if (Fecha.Month <= 9)
                strDirectorio = strDirectorioBase + leyenda + Fecha.Year.ToString() + "\\0" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";
            else
                strDirectorio = strDirectorioBase + leyenda + Fecha.Year.ToString() + "\\" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";

            if (!System.IO.Directory.Exists(strDirectorio))
            {
                System.IO.Directory.CreateDirectory(strDirectorio);
            }

            return strDirectorio;
        }

        //private void ExportarExamenPDF(DataGridViewRow r)
        private void ExportarExamenPDF(DataRow r)
        {
            CapaNegocioMepryl.Reportes rpt = new CapaNegocioMepryl.Reportes();
            Reportes report = new Reportes(new rptExamenPreventiva());
            string strNombreArchivo = "";
            
            strNombreArchivo = r.ItemArray[3].ToString() + " - " + r.ItemArray[4].ToString() + " - " + ConvertirFechaString(r.ItemArray[2].ToString()) + " - " + r.ItemArray[5].ToString() + " - C.pdf";

            //rpt.ClinicoPreventiva(preventiva.cargarParametrosExamen(r.ItemArray[0], r.ItemArray[1]), strNombreArchivo, Convert.ToDateTime(r.ItemArray[2].ToString()));

            //report.exportarAPDF(preventiva.cargarParametrosExamen(r.ItemArray[0], r.ItemArray[1]),
            //new dsExamenPreventiva(), preventiva.cargarDataSourceExamen(),
            //DirectorioReportePorFecha(Convert.ToDateTime(r.ItemArray[2].ToString()), 1, "CLINICOS Y LABORATORIOS") + strNombreArchivo);
            report.exportarAPDF(preventiva.cargarParametrosExamen(r.ItemArray[0], r.ItemArray[1]),
            new dsExamenPreventiva(),
            preventiva.cargarDataSourceExamen(),
            rpt.ReporteSalida("CLINICO-PREVENTIVA", true, Convert.ToDateTime(r.ItemArray[2].ToString()), strNombreArchivo));
            
            preventiva.actualizarImpresionExamen(r.ItemArray[0]);
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

        //private void ExportarProtocoloPDF(DataGridViewRow r)
        private void ExportarProtocoloPDF(DataRow r)
        {
            CapaNegocioMepryl.Reportes rpt = new CapaNegocioMepryl.Reportes();
            Reportes report = new Reportes(new rptProtocoloLaboratorioPreventiva());
            string strNombreArchivo = "";

            //strNombreArchivo = r.Cells[3].Value.ToString() + " - " + r.Cells[7].Value.ToString() + " - " + ConvertirFechaString(r.Cells[2].Value.ToString()) + " - " + r.Cells[8].Value.ToString() + " - L.pdf";
            strNombreArchivo = r.ItemArray[3].ToString() + " - " + r.ItemArray[4].ToString() + " - " + ConvertirFechaString(r.ItemArray[2].ToString()) + " - " + r.ItemArray[5].ToString() + " - L.pdf";

            rpt.LaboratorioPreventiva(preventiva.cargarParametrosLaboratorio(r.ItemArray[0], r.ItemArray[1]), strNombreArchivo, Convert.ToDateTime(r.ItemArray[2].ToString()));
            
            ////report.exportarAPDF(preventiva.cargarParametrosLaboratorio(r.Cells[0].Value, r.Cells[1].Value),
            //report.exportarAPDF(preventiva.cargarParametrosLaboratorio(r.ItemArray[0], r.ItemArray[1]),
            //new dsExamenPreventiva(), preventiva.cargarDataSourceProtocoloLaboratorio(),
            ////DirectorioReportePorFecha(Convert.ToDateTime(r.Cells[2].Value.ToString()), 2, "CLINICOS Y LABORATORIOS") + strNombreArchivo);
            //DirectorioReportePorFecha(Convert.ToDateTime(r.ItemArray[2].ToString()), 2, "CLINICOS Y LABORATORIOS") + strNombreArchivo);

            //if (result.Modo == 1) { preventiva.actualizarImpresionLaboratorio(r.Cells[0].Value); }
            //else { MessageBox.Show(result.Mensaje); }
            //preventiva.actualizarImpresionLaboratorio(r.Cells[0].Value);
            preventiva.actualizarImpresionLaboratorio(r.ItemArray[0]);
        }

        private string MonthName(int month)
        {
            System.Globalization.DateTimeFormatInfo dtinfo = new System.Globalization.CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        // GRV - Ramírez - Guarda en el directorio configurado
        private string DirectorioReporte(byte valor)
        {
            byte bytTipo = valor;
            string strDirectorio = "";

            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT reporte FROM dbo.ConfigReportes
            WHERE tipoReporte = '" + bytTipo + "'");

            if (valores.Rows.Count > 0)
            {
                strDirectorio = valores.Rows[0].ItemArray[0].ToString() + "\\";
            }
            else
            {
                strDirectorio = "P:\\ESTUDIOS TEMPORADA 2016\\";
            }

            return strDirectorio;
        }

        private string DirectorioExportacion(byte valor)
        {
            byte bytTipo = valor;
            string strDirectorio = "";

            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT exportar FROM dbo.ConfigReportes
            WHERE tipoReporte = '" + bytTipo + "'");

            if (valores.Rows.Count > 0)
            {
                strDirectorio = valores.Rows[0].ItemArray[0].ToString() + "\\";
            }
            else
            {
                strDirectorio = "P:\\ESTUDIOS TEMPORADA 2016\\";
            }

            return strDirectorio;
        }

        private void imprimirProtocolo(DataGridViewRow r)
        {
            Reportes report = new Reportes(new rptProtocoloLaboratorioPreventiva());

            Entidades.Resultado result = report.imprimirYExportar(preventiva.cargarParametrosLaboratorio(r.Cells[0].Value, r.Cells[1].Value),
            new dsExamenPreventiva(), preventiva.cargarDataSourceProtocoloLaboratorio(),
            // GRV - Ramírez - Modificado
            // @"P:\ESTUDIOS TEMPORADA 2016\" + cargarRutaDestino(r, "L") + ".pdf");
            DirectorioReporte(2) + cargarRutaDestino(r, "L") + ".pdf");

            if (result.Modo == 1) { preventiva.actualizarImpresionLaboratorio(r.Cells[0].Value); }
            else { MessageBox.Show(result.Mensaje); }

        }

        private void botonRango_Click(object sender, EventArgs e)
        {
            gbRango.Enabled = true;
            gbFecha.Enabled = false;
        }

        private void botonFecha_Click(object sender, EventArgs e)
        {
            gbFecha.Enabled = true;
            gbRango.Enabled = false;
        }


        private void botonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                buscarExamen();
            }
            catch
            {

            }
        }

        private void buscarExamen()
        {
             cargarExamenesConFiltro();
        }

        private void cargarExamenesConFiltro()
        {
            if (tbBusqueda.Text != "")
            {
                if (cboTipoBusqueda.SelectedIndex == 0) { filtro = "and (p.apellido + ' ' + p.nombres) LIKE '%" + tbBusqueda.Text + "%'"; }
                if (cboTipoBusqueda.SelectedIndex == 1) { filtro = "and CONVERT(varchar,p.dni) LIKE '%" + tbBusqueda.Text + "%'"; }
            }
            if (gbRango.Enabled) { cargarExamenes(tpDesde.Value, tpHasta.Value); }
            if (gbFecha.Enabled) { cargarExamenes(tpFecha.Value, tpFecha.Value); }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            tbBusqueda.Clear();
            filtro = "";
            cboC.SelectedIndex = 0;
            cboL.SelectedIndex = 0;
            cboD.SelectedIndex = 0;

            //cargarExamenesConFiltro();
        }
        
        private void botBuscar_Click(object sender, EventArgs e)
        {
            cargarExamenes(tpDesde.Value, tpHasta.Value);
        }

        private void botMail_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                mail();
                Cursor.Current = Cursors.Default;
            }

            //MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
            //DialogResult resultExamen = MessageBox.Show("¿Desea enviar un correo a los pacientes con su estudio consolidado?\n\n", "Enviar correo",
            //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //if (dgvExamenes.Rows.Count > 0)
            //{
            //    if (resultExamen == DialogResult.Yes)
            //    {                    
            //        dtTempConsolidar = CargarDataTableTemp(true);
            //    }
            //    else if (resultExamen == DialogResult.No)
            //    {                    
            //        dtTempConsolidar = CargarDataTableTemp(false);
            //    }
            //    else
            //        return;

            //    SubProceso03 = new Thread(EnvioMailLote);
            //    SubProceso03.Start();                
            //}            
        }

        private void mail()
        {
            List<string> archivos = new List<string>();
            puntero = dgvExamenes.SelectedCells[0].RowIndex;
            celda = dgvExamenes.SelectedCells[0].ColumnIndex;
            frmMail frm = frmMail.GetForm();

            foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
            {
                if (celda == cell.ColumnIndex)
                {
                    Reportes reportPreventiva = new Reportes(new rptExamenPreventiva());
                    string rutaPreventiva = reportPreventiva.exportarAPDF(preventiva.cargarParametrosExamen(dgvExamenes.Rows[cell.RowIndex].Cells[0].Value,
                        dgvExamenes.Rows[cell.RowIndex].Cells[1].Value),
                    new dsExamenPreventiva(), preventiva.cargarDataSourceExamen(),
                    // GRV - Ramírez - Modificado
                    //@"P:\ESTUDIOS POR MAIL\" + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "E") + ".pdf");
                    DirectorioReporte(1) + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "E") + ".pdf");                    
                    archivos.Add(rutaPreventiva);

                    Reportes reportProtocolo = new Reportes(new rptProtocoloLaboratorioPreventiva());
                    string rutaProtocolo = reportProtocolo.exportarAPDF(preventiva.cargarParametrosLaboratorio(dgvExamenes.Rows[cell.RowIndex].Cells[0].Value,
                    dgvExamenes.Rows[cell.RowIndex].Cells[1].Value),
                    new dsExamenPreventiva(), preventiva.cargarDataSourceProtocoloLaboratorio(),
                    // GRV - Ramírez - Modificado
                    //@"P:\ESTUDIOS POR MAIL\" + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "P") + ".pdf");
                    DirectorioReporte(2) + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "P") + ".pdf");
                    archivos.Add(rutaProtocolo);
                    frm.agregarIdTipoExamen(new Guid(dgvExamenes.Rows[cell.RowIndex].Cells[0].Value.ToString()));
                }
            }
            frm.archivosAdjuntos(archivos);
            frm.setearAsunto("RESULTADO EXAMEN DE APTITUD DEPORTIVA");
            frm.setearMensaje("Adjuntamos al presente mail los estudios solicitados.");
            frm.mailPreventiva();
            frm.objDelegateDevolverResultadoEnvio = new frmMail.DelegateDevolverResultadoEnvio(actualizarEnvioMail);
            frm.mostrar(this.MdiParent);
        }

        

        public void actualizarEnvioMail(bool resultado, List<Guid> idsTipoExamen)
        {
            if (resultado)
            {
                foreach (Guid obj in idsTipoExamen)
                {
                    preventiva.actualizarEnvioMail(obj);
                }
                actualizarExamenes();
            }
        }

        private void botonRevalidar_Click(object sender, EventArgs e)
        {
            MsgBoxUtil.HackMessageBox("Dictámenes", "Condicionales");
            DialogResult Respuesta = MessageBox.Show("Proceso de revalidación.\nSeleccione el proceso a realizar", "Revalidar dictámenes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Respuesta == DialogResult.Yes)
            {
                if (dgvExamenes.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Se van a revalidar todos los dictámenes dentro del rango de fechas elegido. ¿Desea continuar?",
                        "Revalidar dictámenes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        revalidar();
                    }
                }
            }
            else
            {
                DialogResult result01 = MessageBox.Show("Se van a revalidar todos los dictámenes condicionales, cambiando su estado a" +
                    " condicional vencido. ¿Desea continuar?",
                        "Revalidar Condicionales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result01 == DialogResult.Yes)
                {
                    revalidarCondicionales();
                }
            }
        }

        private void revalidar()
        {
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = dgvExamenes.Rows.Count;
            foreach (DataGridViewRow r in dgvExamenes.Rows)
            {
                preventiva.actualizarValidaciones();
                dictamenFinalAutomatico(r.Index);
                progressBar.PerformStep();
            }
            progressBar.Visible = false;
            MessageBox.Show("Revalidación completada con éxito", "Revalidar dictámenes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarExamenes();
        }

        private void botImportar_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this.MdiParent, new frmImportacionLaboratorio(this), new Configuracion());
            frmImportacionLaboratorio frm = new frmImportacionLaboratorio(this);
            frm.ShowDialog();
        }

        private void botonRx_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.Rows.Count > 0)
            {
                if (mostrarDialogo("RX")) { generarRxAutomatico(); }
            }
        }

        private bool mostrarDialogo(string estudio)
        {
            DialogResult result = MessageBox.Show("Se va generar automáticamente el estudio " + estudio + " de los examenes seleccionados. ¿Desea continuar?", "Estudio Automático",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result) { return true; }
            return false;
        }

        private void generarRxAutomatico()
        {
            foreach (DataGridViewCell r in dgvExamenes.SelectedCells)
            {
                if (dgvExamenes.Rows[r.RowIndex].Cells[13].Value.ToString() == "0"
                    && dgvExamenes.Rows[r.RowIndex].Cells[18].Value.ToString() != "NO RENOVADO"
                    && dgvExamenes.Rows[r.RowIndex].Cells[18].Value.ToString() != "NO EFECTUADO"
                    && dgvExamenes.Rows[r.RowIndex].Cells[18].Value.ToString() != "NO CARGADO")
                {
                    preventiva.dictamenRxAutomatico(dgvExamenes.Rows[r.RowIndex].Cells[0].Value);
                }
            }
            MessageBox.Show("¡Estudio RX generado con éxito!", "Generar Estudio RX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            revalidar();
            
        }

        private string filtrarValidaciones(DataTable valid, string codigo, string codigoInterno)
        {
            DataRow[] r = valid.Select("codigo = '" + codigo + "' and codigoInterno = '" + codigoInterno + "'");
            return r[0][0].ToString();
        }


        private void botECGAuto_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.Rows.Count > 0)
            {
                if (mostrarDialogo("ECG")) { generarECGAutomatico(); }
            }
        }

        private void generarECGAutomatico()
        {

            DataTable validaciones = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Validaciones");
            foreach (DataGridViewCell r in dgvExamenes.SelectedCells)
            {
                if (dgvExamenes.Rows[r.RowIndex].Cells[15].Value.ToString() == "0"
                    && dgvExamenes.Rows[r.RowIndex].Cells[18].Value.ToString() != "NO RENOVADO"
                    && dgvExamenes.Rows[r.RowIndex].Cells[18].Value.ToString() != "NO EFECTUADO"
                    && dgvExamenes.Rows[r.RowIndex].Cells[18].Value.ToString() != "NO CARGADO")
                {
                    preventiva.dictamenCarAutomatico(dgvExamenes.Rows[r.RowIndex].Cells[0].Value);
                }             
            }
            MessageBox.Show("¡Estudio ECG generado con éxito!", "Generar Estudio ECG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            revalidar();
        }

        private void botonCambiarClub_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.SelectedCells[0].RowIndex != -1)
            {
                mostrarCambioClub();
            }
        }

        private void botCerrar_Click(object sender, EventArgs e)
        {
            panelCambioDeClub.Visible = false;
            actualizarExamenes();
        }

        private void mostrarCambioClub()
        {
            panelNuevoClub.Visible = false;
            tbRow.Text = dgvExamenes.SelectedCells[0].RowIndex.ToString();
            lblJugador.Text = dgvExamenes.Rows[Convert.ToInt16(tbRow.Text)].Cells[7].Value.ToString() + " - " +
                dgvExamenes.Rows[Convert.ToInt16(tbRow.Text)].Cells[8].Value.ToString();
            cargarClub();
            panelCambioDeClub.Visible = true;
            botAgregar.Enabled = true;
            cargarCombo(cboLiga, "select l.id, l.descripcion from dbo.Liga l where l.id != '00000000-0000-0000-0000-000000000000' order by l.descripcion asc");
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            panelNuevoClub.Visible = true;
            botAgregar.Enabled = false;
        }

        private void cargarClub()
        {
            string idTe = dgvExamenes.Rows[Convert.ToInt16(tbRow.Text)].Cells[0].Value.ToString();
            DataTable ligaYClubes = SQLConnector.obtenerTablaSegunConsultaString(@"select cte.id,l.id, l.descripcion as Liga, c.id, c.descripcion as Club
            from dbo.clubesPorTipoExamen cte inner join dbo.Club c on cte.idClub = c.id
            inner join dbo.Liga l on c.ligaID = l.id where cte.idTipoExamen = '" + idTe + "'");
            dgvClub.DataSource = ligaYClubes;
            dgvClub.Columns[0].Visible = false;
            dgvClub.Columns[1].Visible = false;
            dgvClub.Columns[3].Visible = false;
        }

        private void cargarCombo(ComboBox cb, string consulta)
        {
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(consulta);
            cb.DataSource = tabla;
            cb.DisplayMember = "descripcion";
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClub.SelectedRows.Count > 0)
            {
                List<string> listDelete = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_DeleteById", listDelete, Convert.ToInt32(dgvClub.SelectedRows[0].Cells[0].Value.ToString()));
                cargarClub();

            }
        }

        private void cboLiga_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarCombo(cboClub, "select c.id, c.descripcion from dbo.Club c where c.ligaID = '" + cboLiga.SelectedValue.ToString() + 
                "' order by c.descripcion asc");
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (cboClub.SelectedIndex != -1 && !juegaEnLiga())
            {
                string idTe = dgvExamenes.Rows[Convert.ToInt16(tbRow.Text)].Cells[0].Value.ToString();
                string idClub = cboClub.SelectedValue.ToString();
                List<string> listAdd = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", listAdd, new Guid(idTe), new Guid(idClub));
                panelNuevoClub.Visible = false;
                botAgregar.Enabled = true;
                cboLiga.SelectedIndex = -1;
                cboClub.DataSource = null;
                cargarClub();
            }
        }

        private bool juegaEnLiga()
        {
            foreach (DataGridViewRow r in dgvClub.Rows)
            {
                if (r.Cells[1].Value.ToString() == cboLiga.SelectedValue.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                botonBuscar.PerformClick();
            }
        }

        private void botImportarMovil_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this.MdiParent, new frmImportarJugadores(), new Configuracion());
            frmImportarJugadores frm = new frmImportarJugadores();
            frm.ShowDialog();
        }

        private void dgvExamenes_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                if (filtroTabla != null && filtroTabla.Length > 0)
                {
                    if (e.RowIndex != nroFila)
                    {
                        nroFila = e.RowIndex;
                        //progressBar.PerformStep();
                    }
                    int rowI = e.RowIndex;
                    int colI = e.ColumnIndex;
                    if (colI == 10 || colI == 12 || colI == 14 || colI == 16 || colI == 21
                        || colI == 23 || colI == 25 || colI == 27)
                    {
                        try
                        {
                            if (filtroTabla[rowI][colI] != System.DBNull.Value)
                            {
                                byte[] imageBuffer = (byte[])filtroTabla[rowI][colI];
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                                e.Value = Image.FromStream(ms);
                            }
                            else
                            {
                                e.Value = null;
                            }
                        }
                        catch (System.IO.IOException ex)
                        {
                            //
                        }
                        catch (System.FormatException ex)
                        {
                            //
                        }
                    }
                    else
                    {

                        e.Value = filtroTabla[rowI][colI];
                    }
                    try
                    {

                        if (colI == 3)
                        {
                            if (!dgvExamenes.InvokeRequired)
                            {
                                if (Convert.ToInt16(e.Value) < 200) { dgvExamenes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro; }
                            }
                            else
                            {
                                if (Convert.ToInt16(e.Value) < 200)
                                    GridViewColorFondo(colI, e);
                            }
                        }
                        if (colI == 18)
                        {
                            if (!dgvExamenes.InvokeRequired)
                            {
                                dgvExamenes.Rows[e.RowIndex].Cells[18].Style.BackColor =
                                    (Color)filtroTabla[e.RowIndex][30];
                            }
                            else
                            {
                                GridViewColorFondo(colI, e);
                            }
                        }
                    }
                    catch (System.FormatException ex)
                    {
                        //
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                //
            }
            catch (System.NullReferenceException ex)
            {
                //
            }
            catch (System.FormatException ex)
            {
                //
            }
        }

        private void dgvExamenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intPunteroCol = e.ColumnIndex;
                intPunteroFil = e.RowIndex;

                if (e.ColumnIndex == 19)
                {
                    cambiarEstado(dgvExamenes.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvExamenes.Rows[e.RowIndex].Cells[19].Value.ToString(),
                        "sp_TipoExamenDePaciente_UpdateRM");
                }

                if (e.ColumnIndex == 24)
                {
                    cambiarEstado(dgvExamenes.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvExamenes.Rows[e.RowIndex].Cells[24].Value.ToString(),
                        "sp_TipoExamenDePaciente_UpdateRetiro");
                }
            }
        }

        private void llenarCombo(string consulta, ComboBox cbo, string value, string display, string valorDefecto, int modo)
        {
            DataTable combo = new DataTable();
            combo.Columns.Add(value);
            combo.Columns.Add(display);
            if (valorDefecto != "")
            {
                combo.Rows.Add("0", valorDefecto);
            }

            if (modo == 1)
            {
                combo.Rows.Add("0", "NO CARGADO");
            }
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(consulta);
            foreach (DataRow r in tabla.Rows)
            {
                combo.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString());
            }
            cbo.DataSource = combo;
            cbo.ValueMember = display;
            cbo.DisplayMember = display;
            cbo.SelectedIndex = 0;
        }

        private void cboL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboL.SelectedIndex == 0)
            {
                llenarCombo("select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' order by descripcion asc", cboC, "id", "descripcion", "TODOS",0);
            }
            else
            {
                string id = ((DataRowView)cboL.SelectedItem).Row[0].ToString();
                llenarCombo(@"select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' and
                ligaID = '" + id + "' order by descripcion asc", cboC, "id", "descripcion", "TODOS",0);
            }
        }

        private void botEliminarExamen_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.SelectedCells.Count > 0)
            {
                eliminarExamenes();
            }
            else
            {
                MessageBox.Show("¡Seleccione un examen para eliminar!", "Eliminar Exámenes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void eliminarExamenes()
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar los examenes seleccionados?\nSe perderá toda la información ya cargada en los examenes seleccionados",
                "Eliminar Examenes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                {
                    string idTe = dgvExamenes.Rows[cell.RowIndex].Cells[0].Value.ToString();
                    string idC = dgvExamenes.Rows[cell.RowIndex].Cells[1].Value.ToString();
                    preventiva.eliminarExamen(idTe, idC);
                }
                actualizarExamenes();
            }
        }

        private void botonHabilitarInabiitar_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.SelectedCells != null)
            {
                cambiarHabilitacion();
            }
            else
            {
                MessageBox.Show("Por favor seleccione los examenes de jugadores para inhabilitar",
                    "Inhabilitar Jugador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cambiarHabilitacion()
        {
            DialogResult result = MessageBox.Show(@"Atención, esta accion va a cambiar el estado de habilitación de los jugadores seleccionados. ¿Quiere continuar con la acción?",
                "Habilitar/Inhabilitar Jugadores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                if (dgvExamenes.SelectedCells != null)
                {
                    if (preventiva.estaInhabilitado(dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[0].Value))
                    {
                        DialogResult r = MessageBox.Show("El jugador: " + dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[8].Value.ToString() +
                        "se encuentra inhabilitado.\nPara ser habilitado nuevamente el jugador debe ser ingresado posteriormente\n"
                        + "¿Desea habilitarlo de todas formas?", "Habilitar Jugador", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            string idTe = dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                            string idC = dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                            preventiva.eliminarExamen(idTe, idC);
                            MessageBox.Show("El jugador fue habilitado. Puede ingresarlo nuevamente por Mesa de Entradas o Importando Móvil",
                                 "Jugador habilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualizarExamenes();
                            if (modo == 1) { this.Close(); frm.ingresarPaciente(); }
                            if (modo == 2) { this.Close(); frm.botonBuscarDni.PerformClick(); }
                        }
                    }
                    else
                    {
                        frmFormaInhabilitacion frm = new frmFormaInhabilitacion(this);
                        frm.ShowDialog();
                    }
                }
            }           
        }

        public void inhabilitar(string codigo)
        {
            foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
            {

                if (dgvExamenes.Rows[cell.RowIndex].Cells[9].Value.ToString() == "0" && dgvExamenes.Rows[cell.RowIndex].Cells[11].Value.ToString() == "0" &&
                               dgvExamenes.Rows[cell.RowIndex].Cells[13].Value.ToString() == "0" && dgvExamenes.Rows[cell.RowIndex].Cells[15].Value.ToString() == "0"
                               && dgvExamenes.Rows[cell.RowIndex].Cells[17].Value.ToString() == "0")
                {
                    preventiva.inhabilitarExamen(dgvExamenes.Rows[cell.RowIndex].Cells[0].Value, codigo);
                }
                else
                {
                    MessageBox.Show("¡El jugador no puede ser inhabilitado por que los resultados ya fueron cargados!",
                        "Habilitar/Inhabilitar Jugador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            actualizarExamenes();
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
            botRevalidarCondicionales.Enabled = false;
        }

        private void revalidarCondicionales()
        {
            Entidades.Resultado result = preventiva.revalidarCondicionales();
            if (result.Modo == 1)
            {
                MessageBox.Show("Revalidación completada con éxito", "Revalidar Condicionales", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en la revalidación de condicionales.\nError: " + result.Mensaje,
                    "Revalidar Condicionales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            actualizarExamenes();
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {            
            intContador = 0;
            intProcesoActivo = 1;            

            MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
            DialogResult resultExamen = MessageBox.Show("¿Desea exportar todos los estudios de la fecha?\n\n", "Exportar Examenes",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (resultExamen == DialogResult.Yes)
            {
                blnEstadoProcesarExportaPDF = true;
                dtTempConsolidar = CargarDataTableTemp(true);
            }
            else if (resultExamen == DialogResult.No)
            {
                blnEstadoProcesarExportaPDF = false;
                dtTempConsolidar = CargarDataTableTemp(false);
            }
            else
                return;

            iniciaProcesoBarra();
            SubProceso02 = new Thread(exportarPDF);            
            SubProceso02.Start();
            blnActualizaLista = false;
            timerActualizaEstados.Enabled = true;
            btnExportarPDF.Enabled = false;
        }

        // Barra de progreso - Inicio
        private void iniciaProcesoBarra()
        {
            pgrBarraProgreso.Visible = true;
            pgrBarraProgreso.Minimum = 1;
            pgrBarraProgreso.Step = 1;
            tpFecha.Enabled = false;
            tpDesde.Enabled = false;
            tpHasta.Enabled = false;
            progressBar.Enabled = false;
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
                MethodInvoker mo = new MethodInvoker(() => tpFecha.Enabled = true);
                tpFecha.Invoke(mo);
                MethodInvoker mu = new MethodInvoker(() => tpDesde.Enabled = true);
                tpDesde.Invoke(mu);
                MethodInvoker me = new MethodInvoker(() => tpHasta.Enabled = true);
                tpHasta.Invoke(me);
                MethodInvoker pa = new MethodInvoker(() => progressBar.Enabled = true);
                tpHasta.Invoke(pa);
            }
        }
        // Barra de progreso - Fin
        
        // Consolidar Estudios
        private void ListarArchivosBase()
        {                       
            DataTable dt;
            ListaArchivosPdf = new List<string>();

            string strError = "";
            string strUltimaFecha = "";
            
            //if (blnEstadoProcesarConsolidado == true)
            //    dt = CargarDT(true);
            //else if (blnEstadoProcesarConsolidado == false)
            //    dt = CargarDT(false);
            //else
            //{
            //    SubProceso01.Join();
            //    return;
            //}
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
                            CargarArchivoAudiometria(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 10, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[11].ToString()));
                            CargarArchivoErgometria(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 11, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[12].ToString()));
                        }
                        else
                        {
                            CargarArchivoLaboratorio(r.ItemArray[2].ToString(), strMes, strDia, strNombreMes, r.ItemArray[1].ToString(), 6, strAnio, Boolean.Parse(r.ItemArray[6].ToString()));
                            CargarArchivoRX(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 7, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[8].ToString()));
                            CargarArchivoAudiometria(strDia, strMes, strAnio, r.ItemArray[1].ToString(), strNombreMes, 7, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[11].ToString()));
                            CargarArchivoErgometria(strDia, strMes, r.ItemArray[1].ToString(), strNombreMes, 11, strAnio, r.ItemArray[2].ToString(), Boolean.Parse(r.ItemArray[12].ToString()));
                            CargarArchivoRadiologico(r.ItemArray[2].ToString(), strMes, strDia, strAnio, strNombreMes, r.ItemArray[1].ToString(), 8, Boolean.Parse(r.ItemArray[5].ToString()));                            
                        }

                        if (Int32.Parse(r.ItemArray[1].ToString()) < 200 || Int32.Parse(r.ItemArray[1].ToString()) > 399)
                        {
                            //strError = UtilMepryl.ConcatenarPDFs(dtArchivosPDF, strDirecConsolTemp + "MOVIL");
                            strError = UtilMepryl.ConcatenarPDFsLaboral(dtArchivosPDF, strDirecConsolTemp + "MOVIL", ListaArchivosPdf);
                        }
                        else
                        {
                            //strError = UtilMepryl.ConcatenarPDFs(dtArchivosPDF, strDirecConsolTemp + "CLINICA");
                            strError = UtilMepryl.ConcatenarPDFsLaboral(dtArchivosPDF, strDirecConsolTemp + "CLINICA", ListaArchivosPdf);
                        }
                        ListaArchivosPdf.Clear();

                        //---
                        VerificaEstudiosComplementarios(r, r.ItemArray[1].ToString(), r.ItemArray[2].ToString());

                        if (!string.IsNullOrEmpty(strError))
                        {
                            DialogResult result = MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + dt.Rows.Count.ToString() + " archivos creados.\n¡El sistema ha experimentado un error.!\n\nDesea continuar con el proceso...\n\nDetalles:\n---\n" + strError, "Proceso incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (result == DialogResult.No)
                            {
                                //HabilitarBotonComenzar();
                                OcultarProgresoBarra();
                                SubProceso01.Join();
                                break;
                            }

                            intContador--;
                        }

                        strDirecConsolTemp = "";
                        dtArchivosPDF.Clear();
                        IncreProcesoBarra(++intContador);
                        preventiva.ActualizaConsolidadoExamen(r.ItemArray[14].ToString());                        
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strUltimaFecha))
                            strUltimaFecha = Convert.ToDateTime(r.ItemArray[0]).ToShortDateString();
                    }
                }

                //if (intContador != dt.Rows.Count)
                //    MessageBox.Show("Proceso de consolidación incompleto.\n" + intContador + " de " + dt.Rows.Count.ToString() + " archivos creados.\n\n No se han cargado todos los estudio a partir de la fecha " + strUltimaFecha, "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //else
                //{
                //    if (dtMensajeError.Rows.Count > 0)
                //    {
                //        DialogResult result01 = MessageBox.Show("Se ha completado el proceso de consolidación.\n" + dt.Rows.Count.ToString() + " archivos creados.\nAlgunos archivos estan incompletos.\n\n¿Ver examenes faltantes para los siguientes Nros. de Orden?", "Proceso completo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //        if (result01 == DialogResult.Yes)
                //        {
                //            frmMensajeAlerta frm = new frmMensajeAlerta("Los siguientes exámenes no fueron incluidos en el proceso de consolidado", "Proceso de Consolidación", dtMensajeError);
                //            frm.ShowDialog();
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Se ha completado el proceso de consolidación.\n" + dt.Rows.Count.ToString() + " archivos creados.", "Proceso completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
            }
            //else
            //{
            //    MessageBox.Show("No se han cargado estudios para la fecha señalada.\n\nDebe exportar exámenes de laboratorio y clinico para continuar...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //HabilitarBotonComenzar();
            OcultarProgresoBarra();
            //actualizarExamenes();
            //seleccionarCelda();
            blnActualizaLista = true;
            SubProceso01.Join();            
        }

        private void MyProcess_Exited(object sender, System.EventArgs e)
        {
            actualizarExamenes();
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
            dtArchivosPDF.Columns.Add("InfAudiometria");
            dtArchivosPDF.Columns.Add("Ergometria");

            dtMensajeError.Columns.Add("Fecha");
            dtMensajeError.Columns.Add("Orden");
            dtMensajeError.Columns.Add("DNI");
            dtMensajeError.Columns.Add("Mensaje");
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
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                ListaArchivosPdf.Add(fi.FullName);
                            }
                            else
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
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
            strFiltro = strFecha + "_??????_" + NroOrden + "_*.jpg";

            if (Requerido)
            {
                try
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirectorioBase);

                    if (Convert.ToInt32(NroOrden) < 200 || Convert.ToInt32(NroOrden) > 399)
                    {
                        foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                        {
                            blnVeri01 = true;

                            if (dtArchivosPDF.Rows.Count > 0)
                            {
                                if (System.IO.File.Exists(fi.FullName))
                                {
                                    strDirRXTemp = fi.FullName;
                                    dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                    ListaArchivosPdf.Add(fi.FullName);
                                }
                                else
                                {
                                    dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                    ListaArchivosPdf.Add("");
                                    if (Requerido)
                                        RegistrarError(strFecha, NroOrden, DNI, "RX");
                                }
                            }
                        }
                    }
                    else
                    {
                        strFiltro = strFecha + "*_" + NroOrden + " DNI*.jpg";


                        foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                        {
                            blnVeri01 = true;

                            if (dtArchivosPDF.Rows.Count > 0)
                            {
                                if (System.IO.File.Exists(fi.FullName))
                                {
                                    strDirRXTemp = fi.FullName;
                                    dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                    ListaArchivosPdf.Add(fi.FullName);
                                }
                                else
                                {
                                    dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                    ListaArchivosPdf.Add("");
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
        }

        private void CargarArchivoAudiometria(string Dia, string Mes, string Anio, string NroOrden, string NombreMes, int Posicion, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            string strFiltro = "";
            string strFecha = "";
            string strFecha01 = "";
            bool blnVeri01 = false;

            strDirectorioBase = strDirectorioAudioMetria + "\\" + Anio + "\\" + Mes + "-" + NombreMes + "\\" + Dia + "\\";

            Mes = Mes.Substring(0, 2);
            strFecha = Anio + Mes + Dia;
            strFecha01 = Dia + "/" + Mes + "/" + Anio;
            //strFiltro = strFecha + "*_" + NroOrden + "_*.jpg";
            strFecha = Dia + Mes + Anio;
            strFiltro = NroOrden + "-" + strFecha + "-*.pdf";

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
                    //ErrorGenerararchivo("No se ha exportado el PDF para Clinico.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Audiometria");
                    }
                }
            }
        }

        private void CargarArchivoErgometria(string Dia, string Mes, string NroOrden, string NombreMes, int Posicion, string Anio, string DNI, bool Requerido)
        {
            string strDirectorioBase = "";
            //string strFiltro = NroOrden + "_*ERGO*_" + Dia + "*.pdf";
            //string strFecha = Dia + "/" + Mes + "/" + Anio;
            string strFecha = Dia + "_" + Mes + "_" + Anio;
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
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = fi.FullName;
                                ListaArchivosPdf.Add(fi.FullName);
                            }
                            else
                            {
                                dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                                ListaArchivosPdf.Add("");
                                if (Requerido)
                                    RegistrarError(strFecha, NroOrden, DNI, "Ergometría");
                            }
                        }
                    }

                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Ergometría");
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    //ErrorGenerararchivo("No se ha exportado el PDF para ECG.\n" + ex.Message + "\n" + ex.Source, strFecha);
                    if (!blnVeri01)
                    {
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Egometría");
                    }
                }
            }
        }

        private void CargarArchivoRadiologico(string DNI, string Mes, string Dia, string Anio, string NombreMes, string NroOrden, int Posicion, bool Requerido)
        {
            GenerarInfoRadiologico(DNI, Mes, Dia, Anio, NombreMes, NroOrden, Posicion, Requerido);
        }

        private void GenerarInfoRadiologico(string DNI, string Mes, string Dia, string Anio, string NombreMes, string NroOrden, int Posicion, bool Requerido)
        {
            DataTable dt;

            if (tpFecha.Enabled == true)
                dt = ExamPreventiva.ListaInformeRadiologico(tpFecha.Value, tpFecha.Value, DNI, NroOrden);
            else
                dt = ExamPreventiva.ListaInformeRadiologico(tpDesde.Value, tpHasta.Value, DNI, NroOrden);

            List<string> strNombreArchivoRadiologico = new List<string>();
            string strDirectorioBase = "";
            string[,] Etiquetas = new string[5, 2];
            string strPath = "";
            string strFecha = "";

            //strDirectorioBase = Consolidar.DirectorioPlacaRX(strDirectorioRX, Anio + Mes + Dia, NroOrden);

            if (System.IO.File.Exists(strDirRXTemp))
                strDirectorioBase = System.IO.Path.GetDirectoryName(strDirRXTemp).ToString();

            if (dt.Rows.Count > 0)
            {
                strNombreArchivoRadiologico.Add(Dia);
                strNombreArchivoRadiologico.Add(Mes);
                strNombreArchivoRadiologico.Add(Anio);
                strNombreArchivoRadiologico.Add(NroOrden);
                strNombreArchivoRadiologico.Add(DNI);
                strFecha = Anio + Mes + Dia;

                foreach (DataRow r in dt.Rows)
                {
                    Etiquetas[0, 0] = "<<Fecha>>"; Etiquetas[0, 1] = Convert.ToDateTime(r.ItemArray[0].ToString()).ToShortDateString();
                    Etiquetas[1, 0] = "<<Nro.Examen>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                    Etiquetas[2, 0] = "<<DNI>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                    Etiquetas[3, 0] = "<<Apellido>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                    Etiquetas[4, 0] = "<<Conclusiones>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();

                    strNombreArchivoRadiologico.Add(r.ItemArray[3].ToString());
                }

                strPath = UtilMepryl.PathArchivoConsolidado(strNombreArchivoRadiologico, strDirectorioBase);

                CrearReporte.CreateWordDocument(strArchivoPlantilla, strPath, new object(), Etiquetas, 'P', false);

                Array.Clear(Etiquetas, 0, Etiquetas.Length);

                if (dtArchivosPDF.Rows.Count > 0)
                {
                    if (System.IO.File.Exists(strPath))
                    {
                        dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = strPath;
                        ListaArchivosPdf.Add(strPath);
                    }
                    else
                    {
                        dtArchivosPDF.Rows[dtArchivosPDF.Rows.Count - 1][Posicion] = "";
                        ListaArchivosPdf.Add("");
                        if (Requerido)
                            RegistrarError(strFecha, NroOrden, DNI, "Radiologico");
                    }
                }

                strDirRXTemp = "";
            }
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
                    strDirectorioAudioMetria = r.ItemArray[7].ToString();
                    strDirectorioErgometria = r.ItemArray[9].ToString();
                }
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
                //RegistrarError(strFecha, Orden, DNI, "Audiometria");
            if (bool.Parse(Requerido.ItemArray[12].ToString()))
                //RegistrarError(strFecha, Orden, DNI, "Ergometria");
            if (bool.Parse(Requerido.ItemArray[13].ToString()))
                RegistrarError(strFecha, Orden, DNI, "Ecodoppler");
        }

        private DataTable CargarDT(bool ConsolidaTodo)
        {
            DataTable dtConsulta = new DataTable();
            DataRow drFila;
            int intNroOrden = 0;
            DateTime dtFecha;
            string strIdTipoExamen = "";

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
            dtConsulta.Columns.Add("IdTep", typeof(System.String)); // index 14

            if (!ConsolidaTodo)
            {
                if (dgvExamenes.SelectedCells.Count > 0)
                //if (dgvTempConsolidar.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                    //foreach (DataGridViewCell cell in dgvTempConsolidar.SelectedCells)
                    {                        
                        DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
                        //DataGridViewRow row = dgvTempConsolidar.Rows[cell.RowIndex];
                        intNroOrden = Int32.Parse(row.Cells[3].Value.ToString());
                        dtFecha = Convert.ToDateTime(row.Cells[2].Value.ToString());
                        strIdTipoExamen = row.Cells[0].Value.ToString();

                        drFila = Consolidar.DatosBase(dtFecha, dtFecha, true, true, intNroOrden, strIdTipoExamen);
                        if (drFila != null)
                            dtConsulta.ImportRow(drFila);

                        drFila = null;
                    }
                }
            }
            else
            {
                if (dgvExamenes.Rows.Count > 0)
                //if (dgvTempConsolidar.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvExamenes.Rows)
                    //foreach (DataGridViewRow row in dgvTempConsolidar.Rows)
                    {                        
                        intNroOrden = Int32.Parse(row.Cells[3].Value.ToString());
                        dtFecha = Convert.ToDateTime(row.Cells[2].Value.ToString());
                        strIdTipoExamen = row.Cells[0].Value.ToString();

                        drFila = Consolidar.DatosBase(dtFecha, dtFecha, true, true, intNroOrden, strIdTipoExamen);
                        if (drFila != null)
                            dtConsulta.ImportRow(drFila);

                        drFila = null;
                    }
                }
            }

            return dtConsulta;
        }

        private void ExamenSeleccionado()
        {
            if (dgvExamenes.Rows.Count > 0)
            {
                celda = dgvExamenes.SelectedCells[0].ColumnIndex;
                foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                {
                    if (celda == cell.ColumnIndex)
                    {
                        DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
                        
                        AbrirCarperta(row.Cells[3].Value.ToString(), Convert.ToDateTime(row.Cells[2].Value.ToString()));
                    }
                }
            }
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

            DataTable dt = Consolidar.Directorios();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    strDirectorioConsolidar = r.ItemArray[5].ToString();
                }
            }

            return strDirectorioConsolidar;
        }

        private void UbicarArchivoDisco(string FullPath)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + FullPath + "\"");
        }

        private void seleccionarCelda()
        {
            try
            {
                if (intPunteroFil != -1 && intPunteroCol > 0)
                {
                    if (!dgvExamenes.InvokeRequired)
                    {
                        dgvExamenes.Rows[intPunteroFil].Cells[intPunteroCol].Selected = true;
                        //dgv.Rows[puntero].Selected = true;
                        dgvExamenes.CurrentCell = dgvExamenes.Rows[intPunteroFil].Cells[intPunteroCol];
                    }
                    else
                    {
                        GridViewCeldaSeleccionada();
                    }
                }
                else
                {
                    if (!dgvExamenes.InvokeRequired)
                    {
                        dgvExamenes.Rows[0].Cells[1].Selected = true;
                    }
                    else
                    {
                        GridViewCeldaSeleccionada();
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {

            }
        }
        
        private void GridViewColorFondo(int Col, DataGridViewCellValueEventArgs e)
        {
            if (Col == 18)
            {
                if (dgvExamenes.InvokeRequired)
                {
                    MethodInvoker mi = new MethodInvoker(() => dgvExamenes.Rows[e.RowIndex].Cells[18].Style.BackColor =
                        (Color)filtroTabla[e.RowIndex][30]);
                    dgvExamenes.Invoke(mi);
                }
            }
            else
            {
                if (dgvExamenes.InvokeRequired)
                {
                    MethodInvoker mi = new MethodInvoker(() => dgvExamenes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro);
                    dgvExamenes.Invoke(mi);
                }
            }
        }

        private void GridViewCeldaSeleccionada()
        {
            if (intPunteroFil != -1 && intPunteroCol > 0)
            {
                if (dgvExamenes.InvokeRequired)
                {
                    MethodInvoker mi = new MethodInvoker(() => dgvExamenes.Rows[intPunteroFil].Cells[intPunteroCol].Selected = true);
                    dgvExamenes.Invoke(mi);

                    MethodInvoker mo = new MethodInvoker(() => dgvExamenes.CurrentCell = dgvExamenes.Rows[intPunteroFil].Cells[intPunteroCol]);
                    dgvExamenes.Invoke(mo);
                }
            }
            else
            {
                if (dgvExamenes.InvokeRequired)
                {
                    MethodInvoker mi = new MethodInvoker(() => dgvExamenes.Rows[0].Cells[1].Selected = true);
                    dgvExamenes.Invoke(mi);
                }
            }
        }

        private DataTable CargarDataTableTemp(bool CargarTodo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idTe", typeof(System.String)); // index 0
            dt.Columns.Add("idC", typeof(System.String)); // index 1
            dt.Columns.Add("Fecha", typeof(System.DateTime)); // index 2
            dt.Columns.Add("NEx", typeof(System.String)); // index 3            
            dt.Columns.Add("DNI", typeof(System.String)); // index 7
            dt.Columns.Add("Paciente", typeof(System.String)); // index 8                        

            if (dgvExamenes.Rows.Count > 0)
            {
                if (CargarTodo)
                { 
                    foreach (DataGridViewRow row in dgvExamenes.Rows)
                    {
                        if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                && row.Cells[17].Value.ToString() != "0")
                        {
                            DataRow r = dt.NewRow();

                            r["idTe"] = row.Cells[0].Value.ToString();
                            r["idC"] = row.Cells[1].Value.ToString();
                            r["Fecha"] = Convert.ToDateTime(row.Cells[2].Value.ToString());
                            r["NEx"] = row.Cells[3].Value.ToString();
                            r["DNI"] = row.Cells[7].Value.ToString();
                            r["Paciente"] = row.Cells[8].Value.ToString();
                            
                            dt.Rows.Add(r);
                        }  
                    } 
                }
                else
                {
                    if (dgvExamenes.SelectedCells.Count > 0)
                    {
                        celda = dgvExamenes.SelectedCells[0].ColumnIndex;
                        foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                        {
                            if (celda == cell.ColumnIndex)
                            {
                                DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
                                if (row.Cells[9].Value.ToString() != "0" && row.Cells[11].Value.ToString() != "0" &&
                                    row.Cells[13].Value.ToString() != "0" && row.Cells[15].Value.ToString() != "0"
                                    && row.Cells[17].Value.ToString() != "0")
                                {
                                    DataRow r = dt.NewRow();

                                    r["idTe"] = row.Cells[0].Value.ToString();
                                    r["idC"] = row.Cells[1].Value.ToString();
                                    r["Fecha"] = Convert.ToDateTime(row.Cells[2].Value.ToString());
                                    r["NEx"] = row.Cells[3].Value.ToString();
                                    r["DNI"] = row.Cells[7].Value.ToString();
                                    r["Paciente"] = row.Cells[8].Value.ToString();

                                    dt.Rows.Add(r);                                                                      
                                }
                            }
                        }
                    }
                }
            }

            return dt;
        }

        private void timerActualizaEstados_Tick(object sender, EventArgs e)
        {
            while (blnActualizaLista)
            {
                if (!dgvExamenes.InvokeRequired)
                {
                    blnActualizaLista = false;
                    timerActualizaEstados.Enabled = false;

                    if (intProcesoActivo == 1)
                    {
                        MessageBox.Show("¡El proceso ha finalizado!.", "Preventiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnExportarPDF.Enabled = true;
                    }
                    else if (intProcesoActivo == 2)
                    {
                        MensajesConsolidar();
                        botRevalidarCondicionales.Enabled = true;
                    }

                    intProcesoActivo = 0;
                    actualizarExamenes();
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
                        DialogResult result01 = MessageBox.Show("Se ha completado el proceso de consolidación.\n" + intTotalProcesoTemp.ToString() + " archivos creados.\n¡Algunos archivos están incompletos!\n\n¿Ver estudios faltantes para los siguientes Nros. de Orden?", "Proceso completo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                

        private void CargarMail()
        {
            CapaNegocioMepryl.Mail enviador = new CapaNegocioMepryl.Mail();
            Entidades.Mail mail = new Entidades.Mail();
        }

        private void EnvioMailLote()
        {
            DataTable dt = new DataTable();
            dt = dtTempConsolidar;
            dtTempConsolidar = null;
            string strMail = "";

            CapaNegocioMepryl.PacientePreventiva PacientePre = new CapaNegocioMepryl.PacientePreventiva();

            strDestinatarios.Clear();
            strArchivosAdjuntos.Clear();

            if (dt.Rows.Count > 0)
            {                
                foreach (DataRow row in dt.Rows)
                {
                    strMail = PacientePre.VerMail(row.ItemArray[4].ToString()); // Pasamos DNI
                    strMail = strMail.Replace(";", ",");
                    if (!string.IsNullOrEmpty(strMail))
                    {
                        strDestinatarios.Add(strMail);
                        strArchivosAdjuntos.Add(UbicarArchivoMail(row.ItemArray[4].ToString(), Convert.ToDateTime(row.ItemArray[2])));

                        CapaNegocioMepryl.Mail enviador = new CapaNegocioMepryl.Mail();
                        Entidades.Mail mail = new Entidades.Mail();
                        mail.Adjuntos = strArchivosAdjuntos;
                        mail.Destinatarios = strDestinatarios;
                        mail.Asunto = "MEPRYL :: Resultado de exámenes médicos";
                        mail.Cuerpo = UtilMepryl.LeerArchivoTexto(@"C:\MEPRYL\header01.grv");
                        mail.Host = "mail.mepryl.com.ar";
                        mail.Cuenta = "resultados@mepryl.com.ar";
                        mail.Contraseña = "M123_resultados";
                        mail.TextoCuenta = "Centro Médico MEPRYL";
                        Cursor.Current = Cursors.WaitCursor;
                        enviador.enviarMail(mail);

                        strDestinatarios.Clear();
                        strArchivosAdjuntos.Clear();
                        Thread.Sleep(90000);
                    } 
                }                
            }

            SubProceso01.Join();
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

        private void bbiImportarLaboratorio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botImportar_Click(sender, e);
        }

        private void bbiCambioClub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botonCambiarClub_Click(sender, e);
        }

        private void bbiImportarJugador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botImportarMovil_Click(sender, e);
        }

        private void bbiHabilitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botonHabilitarInabiitar_Click(sender, e);
        }

        private void bbiEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botEliminarExamen_Click(sender, e);
        }

        private void bbiImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiRXAutomatico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botonRx_Click(sender, e);
        }

        private void bbiEcgAutomatico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botECGAuto_Click(sender, e);
        }

        private void bbiConsolidarEstudios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            botRevalidarCondicionales_Click(sender, e);
        }

        private void bbiExportarPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnExportarPDF_Click(sender, e);
        }

        private void bbiEnviarEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botMail_Click(sender, e);
        }
        
        private void SeleccinarFilaTurno(int intFila, int intColumna)
        {
            if (dgvExamenes.Rows.Count > 0)
            {
                dgvExamenes.Rows[intFila].Selected = true;
                dgvExamenes.CurrentCell = dgvExamenes.Rows[intFila].Cells[intColumna];
            }
        }

        private void bbiRevalidacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botonRevalidar_Click(sender, e);
        }

        private void AlertaExamenModificado()
        {
            MessageBox.Show("Se ha modificado el estudio para el paciente: \n\n " +
                dgvExamenes.Rows[dgvExamenes.CurrentCell.RowIndex].Cells[7].Value.ToString() + " - " +
                dgvExamenes.Rows[dgvExamenes.CurrentCell.RowIndex].Cells[8].Value.ToString() + "\n\n" +
                "Por favor vuelva a generar los exámenes.", "Estudios modificados",
            MessageBoxButtons.OK, MessageBoxIcon.Information);            
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

            if(blnEliminar == false)
            {
                //ribbonPageGroup1.Enabled = true;
                bbiEliminar.Enabled = blnEliminar;
            }

            if (blnModificar == true)
            {
                ribbonPageGroup1.Enabled = true;
                blnUsuarioPuedeModificar = blnModificar;
            }
        }

        private string CapitalizeFirstLetter(string value)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        private void AbrirOutlookCorreo(string strDNI, string strNroOrden, DateTime dtFecha, string strIDTipoExamen)
        {
            CapaNegocioMepryl.PacientePreventiva Paciente = new CapaNegocioMepryl.PacientePreventiva();
            CapaNegocioMepryl.EnviarCorreoConOutlook Outlook = new CapaNegocioMepryl.EnviarCorreoConOutlook();
            CapaNegocioMepryl.ConfigMensajesCorreo Mensaje = new CapaNegocioMepryl.ConfigMensajesCorreo();
            DataTable dt = null;
            string strMail = "";
            string strNombrePaciente = ""; 
            string strBody = "";
            string strAsunto = "";
            string strArchivo = "";
            bool blnEnviado = false;
            int intValor = 0;


            dt = Paciente.ListarPacientePorDNI(strDNI);
            foreach (DataRow fila in dt.Rows)
            {
                strMail = fila["Email"].ToString();
                strNombrePaciente = fila["apellido"].ToString() + " " + fila["nombres"].ToString();
                strNombrePaciente = CapitalizeFirstLetter(strNombrePaciente);
            }
            dt = null;
                      
            dt = Mensaje.ListarCorreosIdPreventiva(5, "P");
            foreach (DataRow fila in dt.Rows)
            {
                strAsunto = fila["Asunto"].ToString();
                strBody = fila["Mensaje"].ToString();
            }
            dt = null;

            strBody = strBody.Replace("<<Nombre>>", strNombrePaciente);
            strBody = strBody.Replace("<<dni>>", strDNI);

            strArchivo = UbicarArchivoMail(strNroOrden, dtFecha);

            if (System.IO.File.Exists(strArchivo))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(strArchivo);
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
                if(!string.IsNullOrEmpty(strMail))
                    strValorMail = "SI";
                if (intValor < 20)
                    strTamañoArchivo = intValor + "MB. Max permitido 20MB";

                MsgBoxUtil.HackMessageBox("Enviar", "No enviar");
                DialogResult Respuesta = MessageBox.Show("El paciente no cumple con los datos necesarios para enviar el Correo-E\n\n * Tiene Email: "+strValorMail+"\n * Tiene Consolidado: " +strValorConsolidado + "\n * Tamaño Archivo: " + strTamañoArchivo, "Envió de correo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

            cargarExamenesConFiltro();
        }

        private void bbiAudiometria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportarAudioMetrias();
        }

        private void ExportarAudioPDF(DataGridViewRow r)
        {
            string strNroOrden = "";
            DateTime dtFecha;

            strNroOrden = r.Cells[3].Value.ToString();
            dtFecha = Convert.ToDateTime(r.Cells[2].Value.ToString());

            LanzarReporteAudiometria(strNroOrden, dtFecha);
        }

        private void LanzarReporteAudiometria(string strNroOrden, DateTime dtFecha)
        {
            ReporteAudiometria repAudio = new ReporteAudiometria();
            repAudio.GeneraAutoReporteAudiometria(dtFecha, strNroOrden);
        }

        private void ExportarAudioMetrias()
        {
            int intCont = 0;
            if (dgvExamenes.Rows.Count > 0)
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
                    progressBar.Maximum = dgvExamenes.Rows.Count;
                    progressBar.Step = 1;
                    // Comentar

                    foreach (DataGridViewRow row in dgvExamenes.Rows)
                    {                        
                        ExportarAudioPDF(row);

                        // Comentar
                        progressBar.PerformStep();
                        // Comentar
                        IncreProcesoBarra(++intCont);
                        
                    }

                    // Comentar                    
                    progressBar.Visible = false;
                    // Comentar
                }
                else if (resultExamen == DialogResult.No)
                {
                    if (dgvExamenes.SelectedCells.Count > 0)
                    {
                        // Comentar
                        progressBar.Visible = true;
                        progressBar.Minimum = 1;
                        progressBar.Value = 1;
                        progressBar.Maximum = dgvExamenes.Rows.Count;
                        progressBar.Step = 1;
                        // Comentar

                        celda = dgvExamenes.SelectedCells[0].ColumnIndex;
                        foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                        {
                            if (celda == cell.ColumnIndex)
                            {
                                DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
                                
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
                }

                MessageBox.Show("El proceso de exportación ha finalizado.", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editarPacientePreventiva()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.mostarDatosDni(dgvExamenes.CurrentRow.Cells[7].Value.ToString());
            //fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(recargarDatosPacientePreventiva);
            fPaciente.ShowDialog();
        }

        private void bbiEditarPaciente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            if (dgvExamenes.Rows.Count > 0)
            {
                editarPacientePreventiva();
                cargarExamenesConFiltro();
                SeleccinarFilaTurno(intPunteroFil, intPunteroCol);
            }
        }
    }
}
