using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace Comunes
{
	/// <summary>
	/// Summary description for ucRemitoConsulta.
	/// </summary>
	public class ucRemitoConsulta : System.Windows.Forms.UserControl
	{
		
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		public bool consultaRapida = false;
        public string tipoPresentacion = "";
		private Control tbCodigoUsado;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.ComponentModel.IContainer components;

		public DataSet dataset = (DataSet) new dsArticulos();
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.Button butAceptar1;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox tbCuitB;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbRazonSocialB;
		private System.Windows.Forms.TabPage tabFiltro3;
		private System.Windows.Forms.Button butSalir3;
		private System.Windows.Forms.Button butLimpiar3;
		private System.Windows.Forms.Button butBuscar3;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.RadioButton rbAsc2;
		private System.Windows.Forms.ComboBox cbCampoOrden2;
		private System.Windows.Forms.RadioButton rbDesc2;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.RadioButton rbAsc4;
		private System.Windows.Forms.ComboBox cbCampoOrden4;
		private System.Windows.Forms.RadioButton rbDesc4;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.RadioButton rbAsc1;
		private System.Windows.Forms.ComboBox cbCampoOrden1;
		private System.Windows.Forms.RadioButton rbDesc1;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.RadioButton rbAsc3;
		private System.Windows.Forms.ComboBox cbCampoOrden3;
		private System.Windows.Forms.RadioButton rbDesc3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.ComboBox cbRegaloEmpresarioB;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox gbNuevoRemito;
		private System.Windows.Forms.TextBox tbDireccionDestinatario;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbNombreDestinatario;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butGuardarRemito;
		private System.Windows.Forms.Button butImprimirRemito;
		private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox gbProveedor;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.ComboBox cbSucursalB;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionHasta;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionDesde;
		private System.Windows.Forms.CheckBox chkFechaEmision;
		private System.Windows.Forms.Button butSalir2;
		private System.Windows.Forms.Button butLimpiar2;
		private System.Windows.Forms.Button butBuscar2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.ComboBox cbEstadoRemitoB;
		private System.Windows.Forms.ComboBox cbEstadoMercaderiaB;
		private System.Windows.Forms.TextBox tbRemitoSucHastaB;
		private System.Windows.Forms.TextBox tbRemitoNroDesdeB;
		private System.Windows.Forms.TextBox tbRemitoNroHastaB;
		private System.Windows.Forms.TextBox tbRemitoSucDesdeB;
		private System.Windows.Forms.TextBox tbNombreDestinatarioB;
		private System.Windows.Forms.TextBox tbDireccionDestinatarioB;
		private System.Windows.Forms.DataGridTableStyle dgtsListadoRemitos;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.ComboBox cbUsuarioB;
		private System.Windows.Forms.ComboBox cbEstadoMercaderia;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbEstadoMercaderiaTestigo;
		private System.Windows.Forms.TextBox tbRemitoID;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.DataGrid dgRemitoLinea;
		private System.Windows.Forms.DataGridTableStyle dgtsRemitoLinea;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
		private System.Windows.Forms.Label lblTituloRemito;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
        private CheckBox chkMostrarTodosFletes;
        private TextBox tbBultos;
        private TextBox tbObsequiante;
        private Label label10;
        private Label label9;
        private ComboBox cbFlete;
        private ComboBox cbZona;
        private Label label8;
        private Label label6;
        private DataGridTableStyle dgtsImprimirAsignarRemito;
        private DataGridBoolColumn dataGridBoolColumn1;
        private DataGridTextBoxColumn dataGridTextBoxColumn44;
        private DataGridTextBoxColumn dataGridTextBoxColumn45;
        private DataGridTextBoxColumn dataGridTextBoxColumn46;
        private DataGridTextBoxColumn dataGridTextBoxColumn47;
        private DataGridTextBoxColumn dataGridTextBoxColumn48;
        private DataGridTextBoxColumn dataGridTextBoxColumn49;
        private DataGridTextBoxColumn dataGridTextBoxColumn50;
        private DataGridTextBoxColumn dataGridTextBoxColumn51;
        private DataGridTextBoxColumn dataGridTextBoxColumn52;
        private DataGridTextBoxColumn dataGridTextBoxColumn53;
        private DataGridTextBoxColumn dataGridTextBoxColumn54;
        private DataGridTextBoxColumn dataGridTextBoxColumn55;
        private Button butImprimirPool;
        private CheckBox chkSeleccionarTodo;
        private TextBox tbNotaPedidoNroDesdeB;
        private TextBox tbNotaPedidoSucDesdeB;
        private TextBox tbFacturaNro;
        private TextBox tbFacturaSuc;
        private Label label30;
        private ComboBox cbProvincia;
        private Label label17;
        private ComboBox cbLocalidad;
        private Label label16;
        private DataGridTextBoxColumn dataGridTextBoxColumn56;
        private DataGridTextBoxColumn dataGridTextBoxColumn57;
        private Button butSuspender;
        private DataGridBoolColumn dataGridBoolColumn2;
        private ComboBox cbRSucursal;
        private Label label29;
        private Button butBorrarRemito;
        private TextBox tbEstadoRemitoIdentificador;
		public DataSet datasetFormaPagoLineas = (DataSet) new dsFormaPagoLinea();

		public ucRemitoConsulta()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public Configuracion configuracion
		{
			get
			{
				return m_configuracion;
			}
			set
			{
				m_configuracion = value;
				if (m_configuracion!=null)
					conexion = m_configuracion.getConectionString();
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRemitoConsulta));
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.butImprimirPool = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butVistaPrevia = new System.Windows.Forms.Button();
            this.butBorrar = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dgtsListadoRemitos = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn56 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn57 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtsImprimirAsignarRemito = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn55 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.gbFechaEmision = new System.Windows.Forms.GroupBox();
            this.dtpFechaEmisionHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaEmisionDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFechaEmision = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbRemitoSucHastaB = new System.Windows.Forms.TextBox();
            this.tbRemitoNroDesdeB = new System.Windows.Forms.TextBox();
            this.tbRemitoNroHastaB = new System.Windows.Forms.TextBox();
            this.tbRemitoSucDesdeB = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.cbRegaloEmpresarioB = new System.Windows.Forms.ComboBox();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbCuitB = new System.Windows.Forms.TextBox();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRazonSocialB = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbDireccionDestinatarioB = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbNombreDestinatarioB = new System.Windows.Forms.TextBox();
            this.butSalir2 = new System.Windows.Forms.Button();
            this.butLimpiar2 = new System.Windows.Forms.Button();
            this.butBuscar2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbEstadoMercaderiaB = new System.Windows.Forms.ComboBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.cbSucursalB = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbEstadoRemitoB = new System.Windows.Forms.ComboBox();
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.cbUsuarioB = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbNotaPedidoNroDesdeB = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoSucDesdeB = new System.Windows.Forms.TextBox();
            this.tabFiltro3 = new System.Windows.Forms.TabPage();
            this.butSalir3 = new System.Windows.Forms.Button();
            this.butLimpiar3 = new System.Windows.Forms.Button();
            this.butBuscar3 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.rbAsc2 = new System.Windows.Forms.RadioButton();
            this.cbCampoOrden2 = new System.Windows.Forms.ComboBox();
            this.rbDesc2 = new System.Windows.Forms.RadioButton();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rbAsc4 = new System.Windows.Forms.RadioButton();
            this.cbCampoOrden4 = new System.Windows.Forms.ComboBox();
            this.rbDesc4 = new System.Windows.Forms.RadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbAsc1 = new System.Windows.Forms.RadioButton();
            this.cbCampoOrden1 = new System.Windows.Forms.ComboBox();
            this.rbDesc1 = new System.Windows.Forms.RadioButton();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.rbAsc3 = new System.Windows.Forms.RadioButton();
            this.cbCampoOrden3 = new System.Windows.Forms.ComboBox();
            this.rbDesc3 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgRemitoLinea = new System.Windows.Forms.DataGrid();
            this.dgtsRemitoLinea = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gbNuevoRemito = new System.Windows.Forms.GroupBox();
            this.butBorrarRemito = new System.Windows.Forms.Button();
            this.cbRSucursal = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.butSuspender = new System.Windows.Forms.Button();
            this.tbFacturaNro = new System.Windows.Forms.TextBox();
            this.tbFacturaSuc = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkMostrarTodosFletes = new System.Windows.Forms.CheckBox();
            this.tbBultos = new System.Windows.Forms.TextBox();
            this.tbObsequiante = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbFlete = new System.Windows.Forms.ComboBox();
            this.cbZona = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.butAnterior = new System.Windows.Forms.Button();
            this.cbEstadoMercaderiaTestigo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEstadoMercaderia = new System.Windows.Forms.ComboBox();
            this.tbDireccionDestinatario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNombreDestinatario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRemitoID = new System.Windows.Forms.TextBox();
            this.butGuardarRemito = new System.Windows.Forms.Button();
            this.butImprimirRemito = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTituloRemito = new System.Windows.Forms.Label();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tbEstadoRemitoIdentificador = new System.Windows.Forms.TextBox();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.gbFechaEmision.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRemitoLinea)).BeginInit();
            this.gbNuevoRemito.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagenesTab
            // 
            this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
            this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenesTab.Images.SetKeyName(0, "");
            this.imagenesTab.Images.SetKeyName(1, "");
            this.imagenesTab.Images.SetKeyName(2, "");
            this.imagenesTab.Images.SetKeyName(3, "");
            this.imagenesTab.Images.SetKeyName(4, "");
            this.imagenesTab.Images.SetKeyName(5, "");
            this.imagenesTab.Images.SetKeyName(6, "");
            this.imagenesTab.Images.SetKeyName(7, "");
            this.imagenesTab.Images.SetKeyName(8, "Borrar.ico");
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.chkSeleccionarTodo);
            this.tabPage1.Controls.Add(this.butImprimirPool);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.butVistaPrevia);
            this.tabPage1.Controls.Add(this.butBorrar);
            this.tabPage1.Controls.Add(this.dgItems);
            this.tabPage1.Controls.Add(this.tabFiltro);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 4;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado de Remitos";
            // 
            // chkSeleccionarTodo
            // 
            this.chkSeleccionarTodo.BackColor = System.Drawing.Color.DarkKhaki;
            this.chkSeleccionarTodo.Checked = true;
            this.chkSeleccionarTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeleccionarTodo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkSeleccionarTodo.Location = new System.Drawing.Point(248, 161);
            this.chkSeleccionarTodo.Name = "chkSeleccionarTodo";
            this.chkSeleccionarTodo.Size = new System.Drawing.Size(112, 18);
            this.chkSeleccionarTodo.TabIndex = 156;
            this.chkSeleccionarTodo.Text = "Seleccionar Todo";
            this.chkSeleccionarTodo.UseVisualStyleBackColor = false;
            this.chkSeleccionarTodo.Visible = false;
            this.chkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodo_CheckedChanged);
            // 
            // butImprimirPool
            // 
            this.butImprimirPool.BackColor = System.Drawing.Color.DarkKhaki;
            this.butImprimirPool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirPool.ForeColor = System.Drawing.Color.White;
            this.butImprimirPool.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirPool.Image")));
            this.butImprimirPool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirPool.Location = new System.Drawing.Point(377, 157);
            this.butImprimirPool.Name = "butImprimirPool";
            this.butImprimirPool.Size = new System.Drawing.Size(68, 23);
            this.butImprimirPool.TabIndex = 118;
            this.butImprimirPool.Text = "&Imprimir";
            this.butImprimirPool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimirPool.UseVisualStyleBackColor = false;
            this.butImprimirPool.Visible = false;
            this.butImprimirPool.Click += new System.EventHandler(this.butImprimirPool_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 117;
            this.pictureBox1.TabStop = false;
            // 
            // butVistaPrevia
            // 
            this.butVistaPrevia.BackColor = System.Drawing.Color.Purple;
            this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVistaPrevia.Location = new System.Drawing.Point(540, 158);
            this.butVistaPrevia.Name = "butVistaPrevia";
            this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
            this.butVistaPrevia.TabIndex = 4;
            this.butVistaPrevia.Text = "&Vista Previa";
            this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butVistaPrevia.UseVisualStyleBackColor = false;
            this.butVistaPrevia.Visible = false;
            // 
            // butBorrar
            // 
            this.butBorrar.BackColor = System.Drawing.Color.Maroon;
            this.butBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrar.ForeColor = System.Drawing.Color.White;
            this.butBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrar.ImageIndex = 8;
            this.butBorrar.ImageList = this.imagenesTab;
            this.butBorrar.Location = new System.Drawing.Point(644, 157);
            this.butBorrar.Name = "butBorrar";
            this.butBorrar.Size = new System.Drawing.Size(64, 23);
            this.butBorrar.TabIndex = 2;
            this.butBorrar.Text = "&Borrar";
            this.butBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrar.UseVisualStyleBackColor = false;
            this.butBorrar.Visible = false;
            this.butBorrar.Click += new System.EventHandler(this.butBorrar_Click);
            // 
            // dgItems
            // 
            this.dgItems.AllowSorting = false;
            this.dgItems.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dgItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItems.CaptionBackColor = System.Drawing.Color.DarkKhaki;
            this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.CaptionForeColor = System.Drawing.Color.White;
            this.dgItems.CaptionText = "     Listado de Remitos";
            this.dgItems.DataMember = "";
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgItems.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dgItems.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgItems.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.LinkColor = System.Drawing.Color.Teal;
            this.dgItems.Location = new System.Drawing.Point(0, 152);
            this.dgItems.Name = "dgItems";
            this.dgItems.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dgItems.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.ReadOnly = true;
            this.dgItems.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgItems.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.Size = new System.Drawing.Size(792, 286);
            this.dgItems.TabIndex = 1;
            this.dgItems.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsListadoRemitos,
            this.dgtsImprimirAsignarRemito});
            this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            this.dgItems.CurrentCellChanged += new System.EventHandler(this.dgItems_CurrentCellChanged);
            this.dgItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgItems_KeyPress);
            // 
            // dgtsListadoRemitos
            // 
            this.dgtsListadoRemitos.AllowSorting = false;
            this.dgtsListadoRemitos.AlternatingBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgtsListadoRemitos.DataGrid = this.dgItems;
            this.dgtsListadoRemitos.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn56,
            this.dataGridTextBoxColumn57});
            this.dgtsListadoRemitos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsListadoRemitos.MappingName = "Items";
            this.dgtsListadoRemitos.ReadOnly = true;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Fecha Creación";
            this.dataGridTextBoxColumn25.MappingName = "Fecha";
            this.dataGridTextBoxColumn25.ReadOnly = true;
            this.dataGridTextBoxColumn25.Width = 140;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "Destinatario";
            this.dataGridTextBoxColumn42.MappingName = "Destinatario";
            this.dataGridTextBoxColumn42.ReadOnly = true;
            this.dataGridTextBoxColumn42.Width = 75;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Dirección Destinatario";
            this.dataGridTextBoxColumn27.MappingName = "Dirección Destinatario";
            this.dataGridTextBoxColumn27.ReadOnly = true;
            this.dataGridTextBoxColumn27.Width = 140;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "Razón Social";
            this.dataGridTextBoxColumn26.MappingName = "Razón Social";
            this.dataGridTextBoxColumn26.ReadOnly = true;
            this.dataGridTextBoxColumn26.Width = 140;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "Estado Remito";
            this.dataGridTextBoxColumn40.MappingName = "Estado Remito";
            this.dataGridTextBoxColumn40.ReadOnly = true;
            this.dataGridTextBoxColumn40.Width = 75;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "Nro. Factura";
            this.dataGridTextBoxColumn32.MappingName = "facturaNro";
            this.dataGridTextBoxColumn32.ReadOnly = true;
            this.dataGridTextBoxColumn32.Width = 120;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "Nro. Remito";
            this.dataGridTextBoxColumn24.MappingName = "Nro. Remito";
            this.dataGridTextBoxColumn24.ReadOnly = true;
            this.dataGridTextBoxColumn24.Width = 120;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "CUIT";
            this.dataGridTextBoxColumn28.MappingName = "CUIT";
            this.dataGridTextBoxColumn28.ReadOnly = true;
            this.dataGridTextBoxColumn28.Width = 75;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "Usuario";
            this.dataGridTextBoxColumn39.MappingName = "Usuario";
            this.dataGridTextBoxColumn39.ReadOnly = true;
            this.dataGridTextBoxColumn39.Width = 75;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Reg. Empresario";
            this.dataGridTextBoxColumn29.MappingName = "Regalo Empresario";
            this.dataGridTextBoxColumn29.ReadOnly = true;
            this.dataGridTextBoxColumn29.Width = 50;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "Estado Mercadería";
            this.dataGridTextBoxColumn30.MappingName = "Estado Mercadería";
            this.dataGridTextBoxColumn30.ReadOnly = true;
            this.dataGridTextBoxColumn30.Width = 75;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "Fecha Est. Mercadería";
            this.dataGridTextBoxColumn31.MappingName = "Fecha Est. Mercadería";
            this.dataGridTextBoxColumn31.ReadOnly = true;
            this.dataGridTextBoxColumn31.Width = 140;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "Nota Pedido";
            this.dataGridTextBoxColumn43.MappingName = "Nota Pedido";
            this.dataGridTextBoxColumn43.ReadOnly = true;
            this.dataGridTextBoxColumn43.Width = 120;
            // 
            // dataGridTextBoxColumn56
            // 
            this.dataGridTextBoxColumn56.Format = "";
            this.dataGridTextBoxColumn56.FormatInfo = null;
            this.dataGridTextBoxColumn56.HeaderText = "Zona";
            this.dataGridTextBoxColumn56.MappingName = "Zona";
            this.dataGridTextBoxColumn56.ReadOnly = true;
            this.dataGridTextBoxColumn56.Width = 75;
            // 
            // dataGridTextBoxColumn57
            // 
            this.dataGridTextBoxColumn57.Format = "";
            this.dataGridTextBoxColumn57.FormatInfo = null;
            this.dataGridTextBoxColumn57.HeaderText = "Flete";
            this.dataGridTextBoxColumn57.MappingName = "Flete";
            this.dataGridTextBoxColumn57.ReadOnly = true;
            this.dataGridTextBoxColumn57.Width = 75;
            // 
            // dgtsImprimirAsignarRemito
            // 
            this.dgtsImprimirAsignarRemito.DataGrid = this.dgItems;
            this.dgtsImprimirAsignarRemito.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn45,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn46,
            this.dataGridTextBoxColumn47,
            this.dataGridTextBoxColumn50,
            this.dataGridTextBoxColumn51,
            this.dataGridTextBoxColumn52,
            this.dataGridTextBoxColumn53,
            this.dataGridTextBoxColumn54,
            this.dataGridTextBoxColumn55,
            this.dataGridTextBoxColumn48,
            this.dataGridTextBoxColumn49});
            this.dgtsImprimirAsignarRemito.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsImprimirAsignarRemito.MappingName = "ItemsImprimirAsignar";
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.HeaderText = "Selec.";
            this.dataGridBoolColumn1.MappingName = "Seleccionado";
            this.dataGridBoolColumn1.Width = 50;
            // 
            // dataGridTextBoxColumn45
            // 
            this.dataGridTextBoxColumn45.Format = "";
            this.dataGridTextBoxColumn45.FormatInfo = null;
            this.dataGridTextBoxColumn45.HeaderText = "Fecha";
            this.dataGridTextBoxColumn45.MappingName = "Fecha";
            this.dataGridTextBoxColumn45.Width = 120;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "Destinatario";
            this.dataGridTextBoxColumn44.MappingName = "Destinatario";
            this.dataGridTextBoxColumn44.ReadOnly = true;
            this.dataGridTextBoxColumn44.Width = 140;
            // 
            // dataGridTextBoxColumn46
            // 
            this.dataGridTextBoxColumn46.Format = "";
            this.dataGridTextBoxColumn46.FormatInfo = null;
            this.dataGridTextBoxColumn46.HeaderText = "Dirección Destinatario";
            this.dataGridTextBoxColumn46.MappingName = "Dirección Destinatario";
            this.dataGridTextBoxColumn46.Width = 120;
            // 
            // dataGridTextBoxColumn47
            // 
            this.dataGridTextBoxColumn47.Format = "";
            this.dataGridTextBoxColumn47.FormatInfo = null;
            this.dataGridTextBoxColumn47.HeaderText = "Razón Social";
            this.dataGridTextBoxColumn47.MappingName = "Razón Social";
            this.dataGridTextBoxColumn47.Width = 75;
            // 
            // dataGridTextBoxColumn50
            // 
            this.dataGridTextBoxColumn50.Format = "";
            this.dataGridTextBoxColumn50.FormatInfo = null;
            this.dataGridTextBoxColumn50.HeaderText = "Estado Remito";
            this.dataGridTextBoxColumn50.MappingName = "Estado Remito";
            this.dataGridTextBoxColumn50.Width = 75;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.HeaderText = "Nro. Factura";
            this.dataGridTextBoxColumn51.MappingName = "facturaNro";
            this.dataGridTextBoxColumn51.Width = 120;
            // 
            // dataGridTextBoxColumn52
            // 
            this.dataGridTextBoxColumn52.Format = "";
            this.dataGridTextBoxColumn52.FormatInfo = null;
            this.dataGridTextBoxColumn52.HeaderText = "Nro. Remito";
            this.dataGridTextBoxColumn52.MappingName = "Nro. Remito";
            this.dataGridTextBoxColumn52.Width = 120;
            // 
            // dataGridTextBoxColumn53
            // 
            this.dataGridTextBoxColumn53.Format = "";
            this.dataGridTextBoxColumn53.FormatInfo = null;
            this.dataGridTextBoxColumn53.HeaderText = "Regalo Empresario";
            this.dataGridTextBoxColumn53.MappingName = "Regalo Empresario";
            this.dataGridTextBoxColumn53.Width = 75;
            // 
            // dataGridTextBoxColumn54
            // 
            this.dataGridTextBoxColumn54.Format = "";
            this.dataGridTextBoxColumn54.FormatInfo = null;
            this.dataGridTextBoxColumn54.HeaderText = "Nota Pedido";
            this.dataGridTextBoxColumn54.MappingName = "Nota Pedido";
            this.dataGridTextBoxColumn54.Width = 120;
            // 
            // dataGridTextBoxColumn55
            // 
            this.dataGridTextBoxColumn55.Format = "";
            this.dataGridTextBoxColumn55.FormatInfo = null;
            this.dataGridTextBoxColumn55.HeaderText = "Usuario";
            this.dataGridTextBoxColumn55.MappingName = "Usuario";
            this.dataGridTextBoxColumn55.Width = 75;
            // 
            // dataGridTextBoxColumn48
            // 
            this.dataGridTextBoxColumn48.Format = "";
            this.dataGridTextBoxColumn48.FormatInfo = null;
            this.dataGridTextBoxColumn48.HeaderText = "Flete";
            this.dataGridTextBoxColumn48.MappingName = "Flete";
            this.dataGridTextBoxColumn48.Width = 75;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Format = "";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.HeaderText = "Zona";
            this.dataGridTextBoxColumn49.MappingName = "Zona";
            this.dataGridTextBoxColumn49.Width = 75;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabFiltro1);
            this.tabFiltro.Controls.Add(this.tabPage3);
            this.tabFiltro.Controls.Add(this.tabFiltro3);
            this.tabFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabFiltro.HotTrack = true;
            this.tabFiltro.ImageList = this.imagenesTab;
            this.tabFiltro.ItemSize = new System.Drawing.Size(0, 18);
            this.tabFiltro.Location = new System.Drawing.Point(0, 0);
            this.tabFiltro.Multiline = true;
            this.tabFiltro.Name = "tabFiltro";
            this.tabFiltro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabFiltro.SelectedIndex = 0;
            this.tabFiltro.Size = new System.Drawing.Size(792, 152);
            this.tabFiltro.TabIndex = 0;
            // 
            // tabFiltro1
            // 
            this.tabFiltro1.Controls.Add(this.gbFechaEmision);
            this.tabFiltro1.Controls.Add(this.groupBox2);
            this.tabFiltro1.Controls.Add(this.groupBox17);
            this.tabFiltro1.Controls.Add(this.butAceptar1);
            this.tabFiltro1.Controls.Add(this.groupBox10);
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.ImageIndex = 1;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            // 
            // gbFechaEmision
            // 
            this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionHasta);
            this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionDesde);
            this.gbFechaEmision.Controls.Add(this.chkFechaEmision);
            this.gbFechaEmision.Location = new System.Drawing.Point(216, 64);
            this.gbFechaEmision.Name = "gbFechaEmision";
            this.gbFechaEmision.Size = new System.Drawing.Size(200, 48);
            this.gbFechaEmision.TabIndex = 18;
            this.gbFechaEmision.TabStop = false;
            // 
            // dtpFechaEmisionHasta
            // 
            this.dtpFechaEmisionHasta.Enabled = false;
            this.dtpFechaEmisionHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmisionHasta.Location = new System.Drawing.Point(104, 16);
            this.dtpFechaEmisionHasta.Name = "dtpFechaEmisionHasta";
            this.dtpFechaEmisionHasta.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaEmisionHasta.TabIndex = 8;
            this.dtpFechaEmisionHasta.ValueChanged += new System.EventHandler(this.dtpFechaEmisionHasta_ValueChanged);
            // 
            // dtpFechaEmisionDesde
            // 
            this.dtpFechaEmisionDesde.Enabled = false;
            this.dtpFechaEmisionDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmisionDesde.Location = new System.Drawing.Point(8, 16);
            this.dtpFechaEmisionDesde.Name = "dtpFechaEmisionDesde";
            this.dtpFechaEmisionDesde.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaEmisionDesde.TabIndex = 7;
            this.dtpFechaEmisionDesde.ValueChanged += new System.EventHandler(this.dtpFechaEmisionDesde_ValueChanged);
            // 
            // chkFechaEmision
            // 
            this.chkFechaEmision.Location = new System.Drawing.Point(8, 0);
            this.chkFechaEmision.Name = "chkFechaEmision";
            this.chkFechaEmision.Size = new System.Drawing.Size(120, 16);
            this.chkFechaEmision.TabIndex = 4;
            this.chkFechaEmision.Text = "Fecha de Emisión";
            this.chkFechaEmision.CheckedChanged += new System.EventHandler(this.chkFechaEmision_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.tbRemitoSucHastaB);
            this.groupBox2.Controls.Add(this.tbRemitoNroDesdeB);
            this.groupBox2.Controls.Add(this.tbRemitoNroHastaB);
            this.groupBox2.Controls.Add(this.tbRemitoSucDesdeB);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 104);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remito Nro.";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 12);
            this.label19.TabIndex = 5;
            this.label19.Text = "Hasta";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 16);
            this.label22.TabIndex = 4;
            this.label22.Text = "Desde";
            // 
            // tbRemitoSucHastaB
            // 
            this.tbRemitoSucHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemitoSucHastaB.Location = new System.Drawing.Point(8, 72);
            this.tbRemitoSucHastaB.Name = "tbRemitoSucHastaB";
            this.tbRemitoSucHastaB.Size = new System.Drawing.Size(56, 20);
            this.tbRemitoSucHastaB.TabIndex = 2;
            this.tbRemitoSucHastaB.Validated += new System.EventHandler(this.tbRemitoSucHastaB_Validated);
            this.tbRemitoSucHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbRemitoNroDesdeB
            // 
            this.tbRemitoNroDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemitoNroDesdeB.Location = new System.Drawing.Point(64, 32);
            this.tbRemitoNroDesdeB.Name = "tbRemitoNroDesdeB";
            this.tbRemitoNroDesdeB.Size = new System.Drawing.Size(128, 20);
            this.tbRemitoNroDesdeB.TabIndex = 1;
            this.tbRemitoNroDesdeB.Validated += new System.EventHandler(this.tbRemitoNroDesdeB_Validated);
            this.tbRemitoNroDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbRemitoNroHastaB
            // 
            this.tbRemitoNroHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemitoNroHastaB.Location = new System.Drawing.Point(64, 72);
            this.tbRemitoNroHastaB.Name = "tbRemitoNroHastaB";
            this.tbRemitoNroHastaB.Size = new System.Drawing.Size(128, 20);
            this.tbRemitoNroHastaB.TabIndex = 3;
            this.tbRemitoNroHastaB.Validated += new System.EventHandler(this.tbRemitoNroHastaB_Validated);
            this.tbRemitoNroHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbRemitoSucDesdeB
            // 
            this.tbRemitoSucDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemitoSucDesdeB.Location = new System.Drawing.Point(8, 32);
            this.tbRemitoSucDesdeB.Name = "tbRemitoSucDesdeB";
            this.tbRemitoSucDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbRemitoSucDesdeB.TabIndex = 0;
            this.tbRemitoSucDesdeB.Validated += new System.EventHandler(this.tbRemitoSucDesdeB_Validated);
            this.tbRemitoSucDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.cbRegaloEmpresarioB);
            this.groupBox17.Location = new System.Drawing.Point(424, 64);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(200, 48);
            this.groupBox17.TabIndex = 16;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Regalo Empresario";
            // 
            // cbRegaloEmpresarioB
            // 
            this.cbRegaloEmpresarioB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegaloEmpresarioB.ItemHeight = 13;
            this.cbRegaloEmpresarioB.Location = new System.Drawing.Point(8, 16);
            this.cbRegaloEmpresarioB.Name = "cbRegaloEmpresarioB";
            this.cbRegaloEmpresarioB.Size = new System.Drawing.Size(184, 21);
            this.cbRegaloEmpresarioB.TabIndex = 11;
            // 
            // butAceptar1
            // 
            this.butAceptar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar1.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar1.Image")));
            this.butAceptar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar1.Location = new System.Drawing.Point(632, 96);
            this.butAceptar1.Name = "butAceptar1";
            this.butAceptar1.Size = new System.Drawing.Size(72, 24);
            this.butAceptar1.TabIndex = 12;
            this.butAceptar1.Text = "&Aceptar";
            this.butAceptar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar1.Visible = false;
            this.butAceptar1.Click += new System.EventHandler(this.butAceptar1_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbCuitB);
            this.groupBox10.Location = new System.Drawing.Point(424, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(200, 48);
            this.groupBox10.TabIndex = 11;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "CUIT";
            // 
            // tbCuitB
            // 
            this.tbCuitB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCuitB.Location = new System.Drawing.Point(8, 16);
            this.tbCuitB.Name = "tbCuitB";
            this.tbCuitB.Size = new System.Drawing.Size(184, 20);
            this.tbCuitB.TabIndex = 1;
            // 
            // butSalir1
            // 
            this.butSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir1.Image = ((System.Drawing.Image)(resources.GetObject("butSalir1.Image")));
            this.butSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir1.Location = new System.Drawing.Point(640, 88);
            this.butSalir1.Name = "butSalir1";
            this.butSalir1.Size = new System.Drawing.Size(64, 23);
            this.butSalir1.TabIndex = 9;
            this.butSalir1.Text = "&Salir";
            // 
            // butLimpiar1
            // 
            this.butLimpiar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar1.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar1.Image")));
            this.butLimpiar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar1.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar1.Name = "butLimpiar1";
            this.butLimpiar1.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar1.TabIndex = 8;
            this.butLimpiar1.Text = "&Limpiar";
            this.butLimpiar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar1.Click += new System.EventHandler(this.butLimpiar1_Click);
            // 
            // butBuscar1
            // 
            this.butBuscar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar1.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar1.Image")));
            this.butBuscar1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar1.Location = new System.Drawing.Point(640, 16);
            this.butBuscar1.Name = "butBuscar1";
            this.butBuscar1.Size = new System.Drawing.Size(64, 41);
            this.butBuscar1.TabIndex = 7;
            this.butBuscar1.Text = "&Buscar";
            this.butBuscar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar1.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRazonSocialB);
            this.groupBox1.Location = new System.Drawing.Point(216, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombre / Razón Social";
            // 
            // tbRazonSocialB
            // 
            this.tbRazonSocialB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRazonSocialB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRazonSocialB.Location = new System.Drawing.Point(8, 16);
            this.tbRazonSocialB.Name = "tbRazonSocialB";
            this.tbRazonSocialB.Size = new System.Drawing.Size(184, 20);
            this.tbRazonSocialB.TabIndex = 1;
            this.tbRazonSocialB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReazonSocialB_KeyPress);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.butSalir2);
            this.tabPage3.Controls.Add(this.butLimpiar2);
            this.tabPage3.Controls.Add(this.butBuscar2);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox19);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.gbProveedor);
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 126);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Filtro Avanzado";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbDireccionDestinatarioB);
            this.groupBox6.Location = new System.Drawing.Point(480, 64);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(144, 48);
            this.groupBox6.TabIndex = 25;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dirección Destinatario";
            // 
            // tbDireccionDestinatarioB
            // 
            this.tbDireccionDestinatarioB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccionDestinatarioB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDireccionDestinatarioB.Location = new System.Drawing.Point(8, 16);
            this.tbDireccionDestinatarioB.Name = "tbDireccionDestinatarioB";
            this.tbDireccionDestinatarioB.Size = new System.Drawing.Size(128, 20);
            this.tbDireccionDestinatarioB.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbNombreDestinatarioB);
            this.groupBox5.Location = new System.Drawing.Point(328, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(144, 48);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Nombre Destinatario";
            // 
            // tbNombreDestinatarioB
            // 
            this.tbNombreDestinatarioB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombreDestinatarioB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombreDestinatarioB.Location = new System.Drawing.Point(8, 16);
            this.tbNombreDestinatarioB.Name = "tbNombreDestinatarioB";
            this.tbNombreDestinatarioB.Size = new System.Drawing.Size(128, 20);
            this.tbNombreDestinatarioB.TabIndex = 2;
            // 
            // butSalir2
            // 
            this.butSalir2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir2.Image = ((System.Drawing.Image)(resources.GetObject("butSalir2.Image")));
            this.butSalir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir2.Location = new System.Drawing.Point(640, 88);
            this.butSalir2.Name = "butSalir2";
            this.butSalir2.Size = new System.Drawing.Size(64, 23);
            this.butSalir2.TabIndex = 23;
            this.butSalir2.Text = "&Salir";
            this.butSalir2.Click += new System.EventHandler(this.butSalir1_Click);
            // 
            // butLimpiar2
            // 
            this.butLimpiar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar2.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar2.Image")));
            this.butLimpiar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar2.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar2.Name = "butLimpiar2";
            this.butLimpiar2.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar2.TabIndex = 22;
            this.butLimpiar2.Text = "&Limpiar";
            this.butLimpiar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar2.Click += new System.EventHandler(this.butLimpiar2_Click);
            // 
            // butBuscar2
            // 
            this.butBuscar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar2.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar2.Image")));
            this.butBuscar2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar2.Location = new System.Drawing.Point(640, 16);
            this.butBuscar2.Name = "butBuscar2";
            this.butBuscar2.Size = new System.Drawing.Size(64, 41);
            this.butBuscar2.TabIndex = 21;
            this.butBuscar2.Text = "&Buscar";
            this.butBuscar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar2.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbEstadoMercaderiaB);
            this.groupBox4.Location = new System.Drawing.Point(160, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 48);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estado Mercadería";
            // 
            // cbEstadoMercaderiaB
            // 
            this.cbEstadoMercaderiaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoMercaderiaB.ItemHeight = 13;
            this.cbEstadoMercaderiaB.Location = new System.Drawing.Point(8, 16);
            this.cbEstadoMercaderiaB.Name = "cbEstadoMercaderiaB";
            this.cbEstadoMercaderiaB.Size = new System.Drawing.Size(128, 21);
            this.cbEstadoMercaderiaB.TabIndex = 10;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.cbSucursalB);
            this.groupBox19.Location = new System.Drawing.Point(424, 8);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(200, 48);
            this.groupBox19.TabIndex = 19;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Sucursal";
            // 
            // cbSucursalB
            // 
            this.cbSucursalB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursalB.ItemHeight = 13;
            this.cbSucursalB.Location = new System.Drawing.Point(8, 16);
            this.cbSucursalB.Name = "cbSucursalB";
            this.cbSucursalB.Size = new System.Drawing.Size(184, 21);
            this.cbSucursalB.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbEstadoRemitoB);
            this.groupBox3.Location = new System.Drawing.Point(8, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 48);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado Remito";
            // 
            // cbEstadoRemitoB
            // 
            this.cbEstadoRemitoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoRemitoB.ItemHeight = 13;
            this.cbEstadoRemitoB.Location = new System.Drawing.Point(8, 16);
            this.cbEstadoRemitoB.Name = "cbEstadoRemitoB";
            this.cbEstadoRemitoB.Size = new System.Drawing.Size(128, 21);
            this.cbEstadoRemitoB.TabIndex = 10;
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.cbUsuarioB);
            this.gbProveedor.Location = new System.Drawing.Point(216, 8);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(200, 48);
            this.gbProveedor.TabIndex = 17;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Usuario";
            // 
            // cbUsuarioB
            // 
            this.cbUsuarioB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuarioB.ItemHeight = 13;
            this.cbUsuarioB.Location = new System.Drawing.Point(8, 16);
            this.cbUsuarioB.Name = "cbUsuarioB";
            this.cbUsuarioB.Size = new System.Drawing.Size(184, 21);
            this.cbUsuarioB.TabIndex = 10;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbNotaPedidoNroDesdeB);
            this.groupBox8.Controls.Add(this.tbNotaPedidoSucDesdeB);
            this.groupBox8.Location = new System.Drawing.Point(8, 8);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 48);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Nota Pedido Nro.";
            // 
            // tbNotaPedidoNroDesdeB
            // 
            this.tbNotaPedidoNroDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoNroDesdeB.Location = new System.Drawing.Point(66, 16);
            this.tbNotaPedidoNroDesdeB.Name = "tbNotaPedidoNroDesdeB";
            this.tbNotaPedidoNroDesdeB.Size = new System.Drawing.Size(128, 20);
            this.tbNotaPedidoNroDesdeB.TabIndex = 9;
            this.tbNotaPedidoNroDesdeB.Validated += new System.EventHandler(this.tbNotaPedidoNroDesdeB_Validated_1);
            this.tbNotaPedidoNroDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbNotaPedidoSucDesdeB
            // 
            this.tbNotaPedidoSucDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoSucDesdeB.Location = new System.Drawing.Point(10, 16);
            this.tbNotaPedidoSucDesdeB.Name = "tbNotaPedidoSucDesdeB";
            this.tbNotaPedidoSucDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbNotaPedidoSucDesdeB.TabIndex = 8;
            this.tbNotaPedidoSucDesdeB.Validated += new System.EventHandler(this.tbNotaPedidoSucDesdeB_Validated);
            this.tbNotaPedidoSucDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tabFiltro3
            // 
            this.tabFiltro3.Controls.Add(this.butSalir3);
            this.tabFiltro3.Controls.Add(this.butLimpiar3);
            this.tabFiltro3.Controls.Add(this.butBuscar3);
            this.tabFiltro3.Controls.Add(this.groupBox12);
            this.tabFiltro3.Controls.Add(this.groupBox13);
            this.tabFiltro3.Controls.Add(this.groupBox11);
            this.tabFiltro3.Controls.Add(this.groupBox14);
            this.tabFiltro3.ImageIndex = 3;
            this.tabFiltro3.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro3.Name = "tabFiltro3";
            this.tabFiltro3.Size = new System.Drawing.Size(784, 126);
            this.tabFiltro3.TabIndex = 2;
            this.tabFiltro3.Text = "Orden";
            this.tabFiltro3.Visible = false;
            // 
            // butSalir3
            // 
            this.butSalir3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir3.Image = ((System.Drawing.Image)(resources.GetObject("butSalir3.Image")));
            this.butSalir3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir3.Location = new System.Drawing.Point(640, 88);
            this.butSalir3.Name = "butSalir3";
            this.butSalir3.Size = new System.Drawing.Size(64, 23);
            this.butSalir3.TabIndex = 13;
            this.butSalir3.Text = "&Salir";
            this.butSalir3.Click += new System.EventHandler(this.butSalir1_Click);
            // 
            // butLimpiar3
            // 
            this.butLimpiar3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar3.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar3.Image")));
            this.butLimpiar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar3.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar3.Name = "butLimpiar3";
            this.butLimpiar3.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar3.TabIndex = 12;
            this.butLimpiar3.Text = "&Limpiar";
            this.butLimpiar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar3.Click += new System.EventHandler(this.butLimpiar3_Click);
            // 
            // butBuscar3
            // 
            this.butBuscar3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar3.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar3.Image")));
            this.butBuscar3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar3.Location = new System.Drawing.Point(640, 16);
            this.butBuscar3.Name = "butBuscar3";
            this.butBuscar3.Size = new System.Drawing.Size(64, 41);
            this.butBuscar3.TabIndex = 11;
            this.butBuscar3.Text = "&Ordenar";
            this.butBuscar3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar3.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.rbAsc2);
            this.groupBox12.Controls.Add(this.cbCampoOrden2);
            this.groupBox12.Controls.Add(this.rbDesc2);
            this.groupBox12.Location = new System.Drawing.Point(328, 8);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(296, 48);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Segunda Columna";
            // 
            // rbAsc2
            // 
            this.rbAsc2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAsc2.Checked = true;
            this.rbAsc2.Image = ((System.Drawing.Image)(resources.GetObject("rbAsc2.Image")));
            this.rbAsc2.Location = new System.Drawing.Point(232, 16);
            this.rbAsc2.Name = "rbAsc2";
            this.rbAsc2.Size = new System.Drawing.Size(24, 24);
            this.rbAsc2.TabIndex = 16;
            this.rbAsc2.TabStop = true;
            // 
            // cbCampoOrden2
            // 
            this.cbCampoOrden2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampoOrden2.ItemHeight = 13;
            this.cbCampoOrden2.Items.AddRange(new object[] {
            "---",
            "CUIT",
            "Destinatario",
            "Dirección Destinatario",
            "Estado Mercadería",
            "Estado Remito",
            "Fecha Creación",
            "Fecha Est. Mercadería",
            "Nro. Factura",
            "Nro. Remito",
            "Razón Social",
            "Regalo Empresario",
            "Usuario"});
            this.cbCampoOrden2.Location = new System.Drawing.Point(8, 16);
            this.cbCampoOrden2.Name = "cbCampoOrden2";
            this.cbCampoOrden2.Size = new System.Drawing.Size(216, 21);
            this.cbCampoOrden2.TabIndex = 14;
            // 
            // rbDesc2
            // 
            this.rbDesc2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDesc2.Image = ((System.Drawing.Image)(resources.GetObject("rbDesc2.Image")));
            this.rbDesc2.Location = new System.Drawing.Point(264, 16);
            this.rbDesc2.Name = "rbDesc2";
            this.rbDesc2.Size = new System.Drawing.Size(24, 24);
            this.rbDesc2.TabIndex = 17;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rbAsc4);
            this.groupBox13.Controls.Add(this.cbCampoOrden4);
            this.groupBox13.Controls.Add(this.rbDesc4);
            this.groupBox13.Location = new System.Drawing.Point(328, 64);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(296, 48);
            this.groupBox13.TabIndex = 4;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Cuarta Columna";
            // 
            // rbAsc4
            // 
            this.rbAsc4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAsc4.Checked = true;
            this.rbAsc4.Image = ((System.Drawing.Image)(resources.GetObject("rbAsc4.Image")));
            this.rbAsc4.Location = new System.Drawing.Point(232, 16);
            this.rbAsc4.Name = "rbAsc4";
            this.rbAsc4.Size = new System.Drawing.Size(24, 24);
            this.rbAsc4.TabIndex = 16;
            this.rbAsc4.TabStop = true;
            // 
            // cbCampoOrden4
            // 
            this.cbCampoOrden4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampoOrden4.ItemHeight = 13;
            this.cbCampoOrden4.Items.AddRange(new object[] {
            "---",
            "CUIT",
            "Destinatario",
            "Dirección Destinatario",
            "Estado Mercadería",
            "Estado Remito",
            "Fecha Creación",
            "Fecha Est. Mercadería",
            "Nro. Factura",
            "Nro. Remito",
            "Razón Social",
            "Regalo Empresario",
            "Usuario"});
            this.cbCampoOrden4.Location = new System.Drawing.Point(8, 16);
            this.cbCampoOrden4.Name = "cbCampoOrden4";
            this.cbCampoOrden4.Size = new System.Drawing.Size(216, 21);
            this.cbCampoOrden4.TabIndex = 14;
            // 
            // rbDesc4
            // 
            this.rbDesc4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDesc4.Image = ((System.Drawing.Image)(resources.GetObject("rbDesc4.Image")));
            this.rbDesc4.Location = new System.Drawing.Point(264, 16);
            this.rbDesc4.Name = "rbDesc4";
            this.rbDesc4.Size = new System.Drawing.Size(24, 24);
            this.rbDesc4.TabIndex = 17;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.rbAsc1);
            this.groupBox11.Controls.Add(this.cbCampoOrden1);
            this.groupBox11.Controls.Add(this.rbDesc1);
            this.groupBox11.Location = new System.Drawing.Point(8, 8);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(296, 48);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Primer Columna";
            // 
            // rbAsc1
            // 
            this.rbAsc1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAsc1.Checked = true;
            this.rbAsc1.Image = ((System.Drawing.Image)(resources.GetObject("rbAsc1.Image")));
            this.rbAsc1.Location = new System.Drawing.Point(232, 16);
            this.rbAsc1.Name = "rbAsc1";
            this.rbAsc1.Size = new System.Drawing.Size(24, 24);
            this.rbAsc1.TabIndex = 16;
            this.rbAsc1.TabStop = true;
            // 
            // cbCampoOrden1
            // 
            this.cbCampoOrden1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampoOrden1.ItemHeight = 13;
            this.cbCampoOrden1.Items.AddRange(new object[] {
            "---",
            "CUIT",
            "Destinatario",
            "Dirección Destinatario",
            "Estado Mercadería",
            "Estado Remito",
            "Fecha Creación",
            "Fecha Est. Mercadería",
            "Nro. Factura",
            "Nro. Remito",
            "Razón Social",
            "Regalo Empresario",
            "Usuario"});
            this.cbCampoOrden1.Location = new System.Drawing.Point(8, 16);
            this.cbCampoOrden1.Name = "cbCampoOrden1";
            this.cbCampoOrden1.Size = new System.Drawing.Size(216, 21);
            this.cbCampoOrden1.TabIndex = 14;
            // 
            // rbDesc1
            // 
            this.rbDesc1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDesc1.Image = ((System.Drawing.Image)(resources.GetObject("rbDesc1.Image")));
            this.rbDesc1.Location = new System.Drawing.Point(264, 16);
            this.rbDesc1.Name = "rbDesc1";
            this.rbDesc1.Size = new System.Drawing.Size(24, 24);
            this.rbDesc1.TabIndex = 17;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.rbAsc3);
            this.groupBox14.Controls.Add(this.cbCampoOrden3);
            this.groupBox14.Controls.Add(this.rbDesc3);
            this.groupBox14.Location = new System.Drawing.Point(8, 64);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(296, 48);
            this.groupBox14.TabIndex = 3;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Tercer Columna";
            // 
            // rbAsc3
            // 
            this.rbAsc3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAsc3.Checked = true;
            this.rbAsc3.Image = ((System.Drawing.Image)(resources.GetObject("rbAsc3.Image")));
            this.rbAsc3.Location = new System.Drawing.Point(232, 16);
            this.rbAsc3.Name = "rbAsc3";
            this.rbAsc3.Size = new System.Drawing.Size(24, 24);
            this.rbAsc3.TabIndex = 16;
            this.rbAsc3.TabStop = true;
            // 
            // cbCampoOrden3
            // 
            this.cbCampoOrden3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampoOrden3.ItemHeight = 13;
            this.cbCampoOrden3.Items.AddRange(new object[] {
            "---",
            "CUIT",
            "Destinatario",
            "Dirección Destinatario",
            "Estado Mercadería",
            "Estado Remito",
            "Fecha Creación",
            "Fecha Est. Mercadería",
            "Nro. Factura",
            "Nro. Remito",
            "Razón Social",
            "Regalo Empresario",
            "Usuario"});
            this.cbCampoOrden3.Location = new System.Drawing.Point(8, 16);
            this.cbCampoOrden3.Name = "cbCampoOrden3";
            this.cbCampoOrden3.Size = new System.Drawing.Size(216, 21);
            this.cbCampoOrden3.TabIndex = 14;
            // 
            // rbDesc3
            // 
            this.rbDesc3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDesc3.Image = ((System.Drawing.Image)(resources.GetObject("rbDesc3.Image")));
            this.rbDesc3.Location = new System.Drawing.Point(264, 16);
            this.rbDesc3.Name = "rbDesc3";
            this.rbDesc3.Size = new System.Drawing.Size(24, 24);
            this.rbDesc3.TabIndex = 17;
            this.rbDesc3.Tag = "lalala";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgRemitoLinea);
            this.tabPage2.Controls.Add(this.gbNuevoRemito);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.lblTituloRemito);
            this.tabPage2.ImageIndex = 5;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.Visible = false;
            // 
            // dgRemitoLinea
            // 
            this.dgRemitoLinea.CaptionBackColor = System.Drawing.Color.DarkKhaki;
            this.dgRemitoLinea.CaptionText = "Remito";
            this.dgRemitoLinea.DataMember = "";
            this.dgRemitoLinea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRemitoLinea.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRemitoLinea.Location = new System.Drawing.Point(0, 246);
            this.dgRemitoLinea.Name = "dgRemitoLinea";
            this.dgRemitoLinea.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgRemitoLinea.Size = new System.Drawing.Size(792, 192);
            this.dgRemitoLinea.TabIndex = 20;
            this.dgRemitoLinea.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsRemitoLinea});
            // 
            // dgtsRemitoLinea
            // 
            this.dgtsRemitoLinea.DataGrid = this.dgRemitoLinea;
            this.dgtsRemitoLinea.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridBoolColumn2,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn41});
            this.dgtsRemitoLinea.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsRemitoLinea.MappingName = "v_Articulo";
            // 
            // dataGridBoolColumn2
            // 
            this.dataGridBoolColumn2.AllowNull = false;
            this.dataGridBoolColumn2.HeaderText = "Seleccionar";
            this.dataGridBoolColumn2.MappingName = "itemSeleccionado";
            this.dataGridBoolColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "# Item  .";
            this.dataGridTextBoxColumn33.MappingName = "itemNro";
            this.dataGridTextBoxColumn33.ReadOnly = true;
            this.dataGridTextBoxColumn33.Width = 50;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "Cod.Interno .";
            this.dataGridTextBoxColumn34.MappingName = "Código Interno";
            this.dataGridTextBoxColumn34.ReadOnly = true;
            this.dataGridTextBoxColumn34.Width = 75;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "Cod.Barras .";
            this.dataGridTextBoxColumn35.MappingName = "Código de Barras";
            this.dataGridTextBoxColumn35.ReadOnly = true;
            this.dataGridTextBoxColumn35.Width = 75;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "Cantidad .";
            this.dataGridTextBoxColumn36.MappingName = "Cantidad";
            this.dataGridTextBoxColumn36.Width = 50;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "Rubro";
            this.dataGridTextBoxColumn37.MappingName = "Rubro";
            this.dataGridTextBoxColumn37.ReadOnly = true;
            this.dataGridTextBoxColumn37.Width = 75;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "Sub Rubro";
            this.dataGridTextBoxColumn38.MappingName = "Sub Rubro";
            this.dataGridTextBoxColumn38.ReadOnly = true;
            this.dataGridTextBoxColumn38.Width = 75;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "Descripción";
            this.dataGridTextBoxColumn41.MappingName = "Descripción";
            this.dataGridTextBoxColumn41.ReadOnly = true;
            this.dataGridTextBoxColumn41.Width = 300;
            // 
            // gbNuevoRemito
            // 
            this.gbNuevoRemito.Controls.Add(this.tbEstadoRemitoIdentificador);
            this.gbNuevoRemito.Controls.Add(this.butBorrarRemito);
            this.gbNuevoRemito.Controls.Add(this.cbRSucursal);
            this.gbNuevoRemito.Controls.Add(this.label29);
            this.gbNuevoRemito.Controls.Add(this.butSuspender);
            this.gbNuevoRemito.Controls.Add(this.tbFacturaNro);
            this.gbNuevoRemito.Controls.Add(this.tbFacturaSuc);
            this.gbNuevoRemito.Controls.Add(this.label30);
            this.gbNuevoRemito.Controls.Add(this.cbProvincia);
            this.gbNuevoRemito.Controls.Add(this.label17);
            this.gbNuevoRemito.Controls.Add(this.cbLocalidad);
            this.gbNuevoRemito.Controls.Add(this.label16);
            this.gbNuevoRemito.Controls.Add(this.chkMostrarTodosFletes);
            this.gbNuevoRemito.Controls.Add(this.tbBultos);
            this.gbNuevoRemito.Controls.Add(this.tbObsequiante);
            this.gbNuevoRemito.Controls.Add(this.label10);
            this.gbNuevoRemito.Controls.Add(this.label9);
            this.gbNuevoRemito.Controls.Add(this.cbFlete);
            this.gbNuevoRemito.Controls.Add(this.cbZona);
            this.gbNuevoRemito.Controls.Add(this.label8);
            this.gbNuevoRemito.Controls.Add(this.label6);
            this.gbNuevoRemito.Controls.Add(this.tbObservaciones);
            this.gbNuevoRemito.Controls.Add(this.label2);
            this.gbNuevoRemito.Controls.Add(this.groupBox9);
            this.gbNuevoRemito.Controls.Add(this.cbEstadoMercaderiaTestigo);
            this.gbNuevoRemito.Controls.Add(this.label1);
            this.gbNuevoRemito.Controls.Add(this.cbEstadoMercaderia);
            this.gbNuevoRemito.Controls.Add(this.tbDireccionDestinatario);
            this.gbNuevoRemito.Controls.Add(this.label4);
            this.gbNuevoRemito.Controls.Add(this.tbNombreDestinatario);
            this.gbNuevoRemito.Controls.Add(this.label3);
            this.gbNuevoRemito.Controls.Add(this.tbRemitoID);
            this.gbNuevoRemito.Controls.Add(this.butGuardarRemito);
            this.gbNuevoRemito.Controls.Add(this.butImprimirRemito);
            this.gbNuevoRemito.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNuevoRemito.Location = new System.Drawing.Point(0, 32);
            this.gbNuevoRemito.Name = "gbNuevoRemito";
            this.gbNuevoRemito.Size = new System.Drawing.Size(792, 214);
            this.gbNuevoRemito.TabIndex = 156;
            this.gbNuevoRemito.TabStop = false;
            // 
            // butBorrarRemito
            // 
            this.butBorrarRemito.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarRemito.ForeColor = System.Drawing.Color.White;
            this.butBorrarRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarRemito.ImageIndex = 8;
            this.butBorrarRemito.ImageList = this.imagenesTab;
            this.butBorrarRemito.Location = new System.Drawing.Point(669, 150);
            this.butBorrarRemito.Name = "butBorrarRemito";
            this.butBorrarRemito.Size = new System.Drawing.Size(107, 23);
            this.butBorrarRemito.TabIndex = 163;
            this.butBorrarRemito.Text = "&Borrar Remito";
            this.butBorrarRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarRemito.UseVisualStyleBackColor = false;
            this.butBorrarRemito.Click += new System.EventHandler(this.butBorrarRemito_Click);
            // 
            // cbRSucursal
            // 
            this.cbRSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRSucursal.Location = new System.Drawing.Point(291, 122);
            this.cbRSucursal.Name = "cbRSucursal";
            this.cbRSucursal.Size = new System.Drawing.Size(242, 21);
            this.cbRSucursal.TabIndex = 9;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(288, 107);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(104, 16);
            this.label29.TabIndex = 162;
            this.label29.Text = "Sucursal";
            // 
            // butSuspender
            // 
            this.butSuspender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender.Image")));
            this.butSuspender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender.Location = new System.Drawing.Point(563, 180);
            this.butSuspender.Name = "butSuspender";
            this.butSuspender.Size = new System.Drawing.Size(100, 24);
            this.butSuspender.TabIndex = 18;
            this.butSuspender.Text = "&Suspender";
            this.butSuspender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSuspender.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // tbFacturaNro
            // 
            this.tbFacturaNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaNro.Location = new System.Drawing.Point(402, 70);
            this.tbFacturaNro.Name = "tbFacturaNro";
            this.tbFacturaNro.Size = new System.Drawing.Size(128, 20);
            this.tbFacturaNro.TabIndex = 8;
            // 
            // tbFacturaSuc
            // 
            this.tbFacturaSuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaSuc.Enabled = false;
            this.tbFacturaSuc.Location = new System.Drawing.Point(349, 70);
            this.tbFacturaSuc.Name = "tbFacturaSuc";
            this.tbFacturaSuc.Size = new System.Drawing.Size(56, 20);
            this.tbFacturaSuc.TabIndex = 7;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(288, 70);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 16);
            this.label30.TabIndex = 159;
            this.label30.Text = "Factura Nº";
            // 
            // cbProvincia
            // 
            this.cbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProvincia.Location = new System.Drawing.Point(348, 46);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(182, 21);
            this.cbProvincia.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(288, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 16);
            this.label17.TabIndex = 158;
            this.label17.Text = "Provincia";
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLocalidad.Location = new System.Drawing.Point(348, 19);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(182, 21);
            this.cbLocalidad.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(288, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 16);
            this.label16.TabIndex = 157;
            this.label16.Text = "Localidad";
            // 
            // chkMostrarTodosFletes
            // 
            this.chkMostrarTodosFletes.Location = new System.Drawing.Point(690, 107);
            this.chkMostrarTodosFletes.Name = "chkMostrarTodosFletes";
            this.chkMostrarTodosFletes.Size = new System.Drawing.Size(96, 16);
            this.chkMostrarTodosFletes.TabIndex = 13;
            this.chkMostrarTodosFletes.Text = "Mostrar Todos";
            this.chkMostrarTodosFletes.CheckedChanged += new System.EventHandler(this.chkMostrarTodosFletes_CheckedChanged);
            // 
            // tbBultos
            // 
            this.tbBultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBultos.Location = new System.Drawing.Point(249, 123);
            this.tbBultos.Name = "tbBultos";
            this.tbBultos.Size = new System.Drawing.Size(33, 20);
            this.tbBultos.TabIndex = 4;
            // 
            // tbObsequiante
            // 
            this.tbObsequiante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObsequiante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObsequiante.Location = new System.Drawing.Point(8, 123);
            this.tbObsequiante.Name = "tbObsequiante";
            this.tbObsequiante.Size = new System.Drawing.Size(232, 20);
            this.tbObsequiante.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(246, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 150;
            this.label10.Text = "Bultos";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 149;
            this.label9.Text = "Obsequiante";
            // 
            // cbFlete
            // 
            this.cbFlete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFlete.Location = new System.Drawing.Point(649, 123);
            this.cbFlete.Name = "cbFlete";
            this.cbFlete.Size = new System.Drawing.Size(127, 21);
            this.cbFlete.TabIndex = 14;
            // 
            // cbZona
            // 
            this.cbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZona.Location = new System.Drawing.Point(539, 123);
            this.cbZona.Name = "cbZona";
            this.cbZona.Size = new System.Drawing.Size(104, 21);
            this.cbZona.TabIndex = 12;
            this.cbZona.SelectedIndexChanged += new System.EventHandler(this.cbZona_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(649, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 148;
            this.label8.Text = "Flete";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(539, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 147;
            this.label6.Text = "Zona";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Location = new System.Drawing.Point(539, 72);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(237, 27);
            this.tbObservaciones.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(536, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 130;
            this.label2.Text = "Observaciones";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblRegistro);
            this.groupBox9.Controls.Add(this.butSiguiente);
            this.groupBox9.Controls.Add(this.butAnterior);
            this.groupBox9.Location = new System.Drawing.Point(8, 156);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(240, 48);
            this.groupBox9.TabIndex = 129;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Registro";
            // 
            // lblRegistro
            // 
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(60, 21);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(118, 19);
            this.lblRegistro.TabIndex = 102;
            this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butSiguiente
            // 
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(184, 16);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(48, 24);
            this.butSiguiente.TabIndex = 16;
            this.butSiguiente.Text = "Sig.";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
            // 
            // butAnterior
            // 
            this.butAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAnterior.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior.Image")));
            this.butAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAnterior.Location = new System.Drawing.Point(6, 16);
            this.butAnterior.Name = "butAnterior";
            this.butAnterior.Size = new System.Drawing.Size(48, 24);
            this.butAnterior.TabIndex = 15;
            this.butAnterior.Text = "Ant.";
            this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
            // 
            // cbEstadoMercaderiaTestigo
            // 
            this.cbEstadoMercaderiaTestigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoMercaderiaTestigo.ItemHeight = 13;
            this.cbEstadoMercaderiaTestigo.Location = new System.Drawing.Point(224, 48);
            this.cbEstadoMercaderiaTestigo.Name = "cbEstadoMercaderiaTestigo";
            this.cbEstadoMercaderiaTestigo.Size = new System.Drawing.Size(32, 21);
            this.cbEstadoMercaderiaTestigo.TabIndex = 128;
            this.cbEstadoMercaderiaTestigo.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(536, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 127;
            this.label1.Text = "Estado Mercadería";
            // 
            // cbEstadoMercaderia
            // 
            this.cbEstadoMercaderia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoMercaderia.ItemHeight = 13;
            this.cbEstadoMercaderia.Location = new System.Drawing.Point(539, 32);
            this.cbEstadoMercaderia.Name = "cbEstadoMercaderia";
            this.cbEstadoMercaderia.Size = new System.Drawing.Size(237, 21);
            this.cbEstadoMercaderia.TabIndex = 10;
            this.cbEstadoMercaderia.SelectedIndexChanged += new System.EventHandler(this.cbEstadoMercaderia_SelectedIndexChanged);
            // 
            // tbDireccionDestinatario
            // 
            this.tbDireccionDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccionDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDireccionDestinatario.Location = new System.Drawing.Point(8, 72);
            this.tbDireccionDestinatario.MaxLength = 63;
            this.tbDireccionDestinatario.Name = "tbDireccionDestinatario";
            this.tbDireccionDestinatario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDireccionDestinatario.Size = new System.Drawing.Size(274, 20);
            this.tbDireccionDestinatario.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 124;
            this.label4.Text = "Dirección de Entrega";
            // 
            // tbNombreDestinatario
            // 
            this.tbNombreDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombreDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombreDestinatario.Location = new System.Drawing.Point(8, 32);
            this.tbNombreDestinatario.MaxLength = 50;
            this.tbNombreDestinatario.Name = "tbNombreDestinatario";
            this.tbNombreDestinatario.Size = new System.Drawing.Size(274, 20);
            this.tbNombreDestinatario.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 120;
            this.label3.Text = "Destinatario";
            // 
            // tbRemitoID
            // 
            this.tbRemitoID.Location = new System.Drawing.Point(208, 48);
            this.tbRemitoID.Name = "tbRemitoID";
            this.tbRemitoID.Size = new System.Drawing.Size(16, 20);
            this.tbRemitoID.TabIndex = 119;
            this.tbRemitoID.Visible = false;
            // 
            // butGuardarRemito
            // 
            this.butGuardarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGuardarRemito.Image = ((System.Drawing.Image)(resources.GetObject("butGuardarRemito.Image")));
            this.butGuardarRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGuardarRemito.Location = new System.Drawing.Point(669, 180);
            this.butGuardarRemito.Name = "butGuardarRemito";
            this.butGuardarRemito.Size = new System.Drawing.Size(107, 24);
            this.butGuardarRemito.TabIndex = 19;
            this.butGuardarRemito.Text = "&Guardar";
            this.butGuardarRemito.Click += new System.EventHandler(this.butGuardarRemito_Click);
            // 
            // butImprimirRemito
            // 
            this.butImprimirRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirRemito.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirRemito.Image")));
            this.butImprimirRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirRemito.Location = new System.Drawing.Point(410, 180);
            this.butImprimirRemito.Name = "butImprimirRemito";
            this.butImprimirRemito.Size = new System.Drawing.Size(120, 24);
            this.butImprimirRemito.TabIndex = 17;
            this.butImprimirRemito.Text = "&Imprimir Remito";
            this.butImprimirRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimirRemito.Click += new System.EventHandler(this.butImprimirRemito_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 120;
            this.pictureBox2.TabStop = false;
            // 
            // lblTituloRemito
            // 
            this.lblTituloRemito.BackColor = System.Drawing.Color.DarkKhaki;
            this.lblTituloRemito.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloRemito.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRemito.ForeColor = System.Drawing.Color.White;
            this.lblTituloRemito.Location = new System.Drawing.Point(0, 0);
            this.lblTituloRemito.Name = "lblTituloRemito";
            this.lblTituloRemito.Size = new System.Drawing.Size(792, 32);
            this.lblTituloRemito.TabIndex = 119;
            this.lblTituloRemito.Text = "     Remito";
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.ImageList = this.imagenesTab;
            this.tabPrincipal.ItemSize = new System.Drawing.Size(94, 18);
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(800, 464);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "Nro.   .";
            this.dataGridTextBoxColumn18.MappingName = "id";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 50;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Fecha Creación";
            this.dataGridTextBoxColumn1.MappingName = "Fecha Creación";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 140;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Razón Social";
            this.dataGridTextBoxColumn2.MappingName = "Razón Social";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 140;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Dirección Cliente";
            this.dataGridTextBoxColumn3.MappingName = "Dirección Cliente";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 140;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "CUIT";
            this.dataGridTextBoxColumn4.MappingName = "CUIT";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Dirección Entrega";
            this.dataGridTextBoxColumn5.MappingName = "Dirección Entrega";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 140;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn6.Format = "N";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Bonif. %  .";
            this.dataGridTextBoxColumn6.MappingName = "Bonif. %";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn7.Format = "C";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "SubTotal 1  .";
            this.dataGridTextBoxColumn7.MappingName = "SubTotal 1";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn8.Format = "C";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "IVA 1  .";
            this.dataGridTextBoxColumn8.MappingName = "IVA 1";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn9.Format = "C";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "IVA 2  .";
            this.dataGridTextBoxColumn9.MappingName = "IVA 2";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn10.Format = "C";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Total";
            this.dataGridTextBoxColumn10.MappingName = "total";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 75;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn11.Format = "C";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "SubTotal 2  .";
            this.dataGridTextBoxColumn11.MappingName = "SubTotal 2";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn12.Format = "C";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Bonificación  .";
            this.dataGridTextBoxColumn12.MappingName = "Bonificación";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 75;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Máquina";
            this.dataGridTextBoxColumn13.MappingName = "Máquina";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Tipo IVA";
            this.dataGridTextBoxColumn14.MappingName = "Tipo IVA";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 75;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "Vendedor";
            this.dataGridTextBoxColumn15.MappingName = "Vendedor";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 75;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "Estado";
            this.dataGridTextBoxColumn16.MappingName = "Estado";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "Autorizó";
            this.dataGridTextBoxColumn17.MappingName = "Autorizó";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 75;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "Tipo de Pago";
            this.dataGridTextBoxColumn19.MappingName = "Tipo Pago";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 150;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "Detalle";
            this.dataGridTextBoxColumn20.MappingName = "Detalle";
            this.dataGridTextBoxColumn20.ReadOnly = true;
            this.dataGridTextBoxColumn20.Width = 300;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn21.Format = "C";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "Importe   .";
            this.dataGridTextBoxColumn21.MappingName = "Importe";
            this.dataGridTextBoxColumn21.ReadOnly = true;
            this.dataGridTextBoxColumn21.Width = 75;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn22.Format = "C";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Ajuste   .";
            this.dataGridTextBoxColumn22.MappingName = "Ajuste";
            this.dataGridTextBoxColumn22.ReadOnly = true;
            this.dataGridTextBoxColumn22.Width = 75;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn23.Format = "C";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "Pesos   .";
            this.dataGridTextBoxColumn23.MappingName = "Pesos";
            this.dataGridTextBoxColumn23.ReadOnly = true;
            this.dataGridTextBoxColumn23.Width = 75;
            // 
            // tbEstadoRemitoIdentificador
            // 
            this.tbEstadoRemitoIdentificador.Location = new System.Drawing.Point(186, 53);
            this.tbEstadoRemitoIdentificador.Name = "tbEstadoRemitoIdentificador";
            this.tbEstadoRemitoIdentificador.Size = new System.Drawing.Size(16, 20);
            this.tbEstadoRemitoIdentificador.TabIndex = 164;
            this.tbEstadoRemitoIdentificador.Visible = false;
            // 
            // ucRemitoConsulta
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucRemitoConsulta";
            this.Size = new System.Drawing.Size(800, 464);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabFiltro1.ResumeLayout(false);
            this.gbFechaEmision.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbProveedor.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRemitoLinea)).EndInit();
            this.gbNuevoRemito.ResumeLayout(false);
            this.gbNuevoRemito.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ucRemitoConsulta_Load(object sender, System.EventArgs e)
		{
			tbRazonSocialB.Select();
		}

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 2;  //Destinatario
				rbAsc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 0;  //Nada
				rbAsc2.Checked = true;
				cbCampoOrden3.SelectedIndex = 0;  //Nada
				rbAsc3.Checked = true;
				cbCampoOrden4.SelectedIndex = 0;  //Nada
				rbAsc4.Checked = true;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butBuscar1_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		//Ejecuta el select de la busqueda
		private void ejecutarBusqueda()
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Ejecutando búsqueda...", true);

				string sqlTotal = construirSQL();
	
				SqlConnection oConn = new SqlConnection(this.conexion);
				SqlCommand oComm = new SqlCommand();
				SqlDataAdapter oSQLDataAdapter;

				oComm.Connection = oConn;
				oComm.CommandType = CommandType.Text;
				oComm.CommandText = sqlTotal;

				//open connection
				oConn.Open();

				//prepare data adapter object
				oSQLDataAdapter = new SqlDataAdapter();

                string nombreTabla = "";
                if (this.tipoPresentacion == "CONSULTA_MODIFICACION")
                    nombreTabla = "Items";
                else if (this.tipoPresentacion == "IMPRIMIR_ASIGNAR")
                    nombreTabla = "ItemsImprimirAsignar";
                else
                    nombreTabla = "Items";

				oSQLDataAdapter.TableMappings.Add("Table", nombreTabla);
				oSQLDataAdapter.SelectCommand = oComm;

				//initialize dataset
				DataSet dsItems = new DataSet(nombreTabla);
				oSQLDataAdapter.Fill(dsItems);

				//prepare dataview to sort
				DataView dvItems;
                dvItems = new DataView(dsItems.Tables[nombreTabla]);
				//dgItems.DataSource = dvItems;
                dgItems.DataSource = dsItems.Tables[nombreTabla];
				dgItems.Visible = true;

				//close connection
				oConn.Close();

				if (this.consultaRapida)
				{
					if (dvItems.Table.Rows.Count>0)
						butAceptar1.Select();
				}

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private string construirSQL()
		{
			try
			{
				string filtro = obtenerWHERE();
				string order = obtenerORDER();

				//prepare command object
                string sql = "SELECT     dbo.Remito.id, dbo.Remito.fecha_creacion AS Fecha, dbo.Remito.notaPedidoID, dbo.Remito.remitoBaseID, dbo.Remito.sucursalCreacionID, " +
                      "dbo.Remito.sucursalEmisionID, dbo.Remito.nroRemitoSucursal, dbo.Remito.nroRemitoNumero,  " +
                      "dbo.Remito.remitoSuc + '-' + dbo.Remito.remitoNro AS [Nro. Remito], dbo.Remito.estadoRemitoID, dbo.Remito.remitoSuc, dbo.Remito.remitoNro,  " +
                      "dbo.Remito.destinatarioNombre AS Destinatario, dbo.Remito.destinatarioDireccion AS [Dirección Destinatario], dbo.Remito.mercaderiaEnTransitoID, " + 
                      "dbo.tv_RemitoEstado.descripcion AS [Estado Remito], dbo.Remito.obsequiante AS [Razón Social],  " +
                      "dbo.NotaPedido.direccionCliente AS [Dirección Cliente], dbo.NotaPedido.cuitCliente AS CUIT, dbo.NotaPedido.regaloEmpresarioID,  " +
                      "dbo.tv_NotaPedidoRegaloEmpresario.descripcion AS [Regalo Empresario], dbo.MercaderiaEnTransito.estadoMercaderiaEnTransitoID,  " +
                      "dbo.MercaderiaEnTransito.fecha_ultimoCambio AS [Fecha Est. Mercadería], dbo.tv_MercaderiaEnTransitoEstado.descripcion AS [Estado Mercadería],  " +
                      "dbo.Remito.facturaSuc + '-' + dbo.Remito.facturaNro AS [Nro. Factura], dbo.Remito.usuarioID,  " +
                      "dbo.Usuario.apellido + ', ' + dbo.Usuario.nombre AS Usuario, dbo.MercaderiaEnTransitoLinea.observaciones,  " +
                      "dbo.NotaPedido.notaPedidoSuc + '-' + dbo.NotaPedido.notaPedidoNro AS [Nota Pedido], dbo.Flete.nombre AS Flete, dbo.Zona.nombre AS Zona,  " +
                      "dbo.Remito.zonaID, dbo.Remito.fleteID, dbo.Remito.bultos, dbo.Remito.obsequiante, dbo.Remito.regaloEmpresario, CAST(1 AS bit) AS Seleccionado,  " +
                      "dbo.tv_RemitoEstado.identificador AS estadoRemitoIdentificador, dbo.Remito.facturaSuc, dbo.Remito.facturaNro, dbo.Remito.destinatarioLocalidadID,  " +
                      "dbo.Remito.destinatarioProvinciaID " +
                        "FROM         dbo.Flete RIGHT OUTER JOIN " +
                      "dbo.Zona RIGHT OUTER JOIN " +
                      "dbo.Remito ON dbo.Zona.id = dbo.Remito.zonaID ON dbo.Flete.id = dbo.Remito.fleteID LEFT OUTER JOIN " +
                      "dbo.Usuario ON dbo.Remito.usuarioID = dbo.Usuario.id LEFT OUTER JOIN " +
                      "dbo.MercaderiaEnTransito LEFT OUTER JOIN " +
                      "dbo.MercaderiaEnTransitoLinea ON dbo.MercaderiaEnTransito.id = dbo.MercaderiaEnTransitoLinea.mercaderiaEnTransitoID AND  " +
                      "dbo.MercaderiaEnTransito.fecha_ultimoCambio = dbo.MercaderiaEnTransitoLinea.fecha LEFT OUTER JOIN " +
                      "dbo.tv_MercaderiaEnTransitoEstado ON dbo.MercaderiaEnTransito.estadoMercaderiaEnTransitoID = dbo.tv_MercaderiaEnTransitoEstado.id ON  " +
                      "dbo.Remito.mercaderiaEnTransitoID = dbo.MercaderiaEnTransito.id LEFT OUTER JOIN " +
                      "dbo.tv_NotaPedidoRegaloEmpresario RIGHT OUTER JOIN " +
                      "dbo.Factura RIGHT OUTER JOIN " +
                      "dbo.NotaPedido ON dbo.Factura.notaPedidoID = dbo.NotaPedido.id ON  " +
                      "dbo.tv_NotaPedidoRegaloEmpresario.id = dbo.NotaPedido.regaloEmpresarioID ON dbo.Remito.notaPedidoID = dbo.NotaPedido.id LEFT OUTER JOIN " +
                      "dbo.tv_RemitoEstado ON dbo.Remito.estadoRemitoID = dbo.tv_RemitoEstado.id " +
                    "WHERE " + filtro;

				string sqlTotal = "";

				sqlTotal = sql + " " + order;

				return sqlTotal;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		private string obtenerWHERE()
		{
			try
			{
				string filtro = "1=1";

				//Filtro Rapido
				/*if (cbFacturaTipoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND facturaTipo ='" + cbFacturaTipoB.Text.Trim() + "'";
				}
				if (tbFacturaSucDesdeB.Text!="" && tbFacturaNroDesdeB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Factura.facturaSuc AS int) >= " + int.Parse(tbFacturaSucDesdeB.Text);
					filtro = filtro + " AND CAST(dbo.Factura.facturaNro AS int) >= " + int.Parse(tbFacturaNroDesdeB.Text);
				}
				if (tbFacturaSucHastaB.Text!="" && tbFacturaNroHastaB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Factura.facturaSuc AS int) <= " + int.Parse(tbFacturaSucHastaB.Text);
					filtro = filtro + " AND CAST(dbo.Factura.facturaNro AS int) <= " + int.Parse(tbFacturaNroHastaB.Text);
				}*/
				if (tbRemitoSucDesdeB.Text!="" && tbRemitoNroDesdeB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Remito.remitoSuc AS int) >= " + int.Parse(tbRemitoSucDesdeB.Text);
					filtro = filtro + " AND CAST(dbo.Remito.remitoNro AS int) >= " + int.Parse(tbRemitoNroDesdeB.Text);
				}
				if (tbRemitoSucHastaB.Text!="" && tbRemitoNroHastaB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Remito.remitoSuc AS int) <= " + int.Parse(tbRemitoSucHastaB.Text);
					filtro = filtro + " AND CAST(dbo.Remito.remitoNro AS int) <= " + int.Parse(tbRemitoNroHastaB.Text);
				}
				if (tbRazonSocialB.Text!="") 
				{
					filtro = filtro + " AND dbo.NotaPedido.nombreCliente LIKE '%" + tbRazonSocialB.Text.Trim() + "%'";
				}
				if (tbCuitB.Text!="") 
				{
					filtro = filtro + " AND dbo.NotaPedido.cuitCliente = " + tbCuitB.Text.Trim();
				}
				//Fechas
				DateTime fechaDesde, fechaHasta;
				string dia, mes, anio, sfechaDesde, sfechaHasta;
				if (chkFechaEmision.Checked)
				{
					fechaDesde = dtpFechaEmisionDesde.Value;
					fechaHasta = dtpFechaEmisionHasta.Value;
					dia = fechaDesde.Day.ToString("00");
					mes = fechaDesde.Month.ToString("00");
					anio = fechaDesde.Year.ToString("0000");
					sfechaDesde = "{ts '" + anio + "-" + mes + "-" + dia + " 00:00:00'}";
					filtro = filtro + " AND dbo.Remito.fecha_creacion >= " + sfechaDesde;
				
					dia = fechaHasta.Day.ToString("00");
					mes = fechaHasta.Month.ToString("00");
					anio = fechaHasta.Year.ToString("0000");
					sfechaHasta = "{ts '" + anio + "-" + mes + "-" + dia + " 23:59:59'}";
					filtro = filtro + " AND dbo.Remito.fecha_creacion <= " + sfechaHasta;
				}
				if (cbRegaloEmpresarioB.SelectedIndex>0) 
				{
					filtro = filtro + " AND regaloEmpresarioID = CAST('" + cbRegaloEmpresarioB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}

				//Filtro Avanzado
				if (tbNotaPedidoNroDesdeB.Text!="") 
				{
					filtro = filtro + " AND dbo.NotaPedido.notaPedidoSuc = '" + tbNotaPedidoSucDesdeB.Text + "'";
                    filtro = filtro + " AND dbo.NotaPedido.notaPedidoNro = '" + tbNotaPedidoNroDesdeB.Text + "'";
				}
				/*if (tbNotaPedidoNroHastaB.Text!="") 
				{
					filtro = filtro + " AND dbo.Remito.notaPedidoID <= " + tbNotaPedidoNroHastaB.Text;
				}*/
				if (cbUsuarioB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Remito.usuarioID = CAST('" + cbUsuarioB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbSucursalB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Remito.sucursalEmisionID = CAST('" + cbSucursalB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbEstadoRemitoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Remito.estadoRemitoID = CAST('" + cbEstadoRemitoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbEstadoMercaderiaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.MercaderiaEnTransito.estadoMercaderiaEnTransitoID = CAST('" + cbEstadoMercaderiaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (tbNombreDestinatarioB.Text!="") 
				{
					filtro = filtro + " AND dbo.Remito.destinatarioNombre LIKE '%" + tbNombreDestinatarioB.Text.Trim() + "%'";
				}
				if (tbDireccionDestinatarioB.Text!="") 
				{
					filtro = filtro + " AND dbo.Remito.destinatarioDireccion LIKE '%" + tbDireccionDestinatarioB.Text.Trim() + "%'";
				}
			
				return filtro;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		
		private string obtenerORDER()
		{
			try
			{
				string orden = "";
				string coma = "";
				string sentido = "";

				if (cbCampoOrden1.Text!="---")
				{
					if (orden.IndexOf("[" + cbCampoOrden1.Text + "]")==-1) 
					{
						sentido = rbAsc1.Checked ? " ASC " : " DESC ";
						orden = "[" + cbCampoOrden1.Text + "]" + sentido;
					}
				}
				if (cbCampoOrden2.Text!="---")
				{
					coma = "";
					if (orden!="") coma = ", ";
				
					if (orden.IndexOf("[" + cbCampoOrden2.Text + "]")==-1) 
					{
						sentido = rbAsc2.Checked ? " ASC " : " DESC ";
						orden += coma + "[" + cbCampoOrden2.Text + "]" + sentido;
					}
				}
				if (cbCampoOrden3.Text!="---")
				{
					coma = "";
					if (orden!="") coma = ", ";
				
					if (orden.IndexOf("[" + cbCampoOrden3.Text + "]")==-1) 
					{
						sentido = rbAsc3.Checked ? " ASC " : " DESC ";
						orden += coma + "[" + cbCampoOrden3.Text + "]" + sentido;
					}
				}
				if (cbCampoOrden4.Text!="---")
				{
					coma = "";
					if (orden!="") coma = ", ";
				
					if (orden.IndexOf("[" + cbCampoOrden4.Text + "]")==-1) 
					{
						sentido = rbAsc4.Checked ? " ASC " : " DESC ";
						orden += coma + "[" + cbCampoOrden4.Text + "]" + sentido;
					}
				}

				if (orden!="") orden = " ORDER BY " + orden;

				return orden;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		private void butBuscar3_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butSalir3_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			try
			{
				tbRemitoSucDesdeB.Text = "";
				tbRemitoNroDesdeB.Text = "";
				tbRemitoSucHastaB.Text = "";
				tbRemitoNroHastaB.Text = "";
				tbRazonSocialB.Text = "";
				tbCuitB.Text = "";
				chkFechaEmision.Checked = false;
				cbRegaloEmpresarioB.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dgItems_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.consultaRapida)
					((Form)this.Parent).Close();				
				//else
					//tabPrincipal.SelectedIndex = 1;
                
                //Si es consulta y no impresion
                if (this.tipoPresentacion=="CONSULTA_MODIFICACION")
                    tabPrincipal.SelectedIndex = 1;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tabPrincipal_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (tabPrincipal.SelectedIndex==1)
				{
					this.Refresh();
					if (dgItems.DataSource!=null)
						if (((DataTable)dgItems.DataSource).Rows.Count>0)
						{
							cargarDetalle();
						}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cargarDetalle()
		{
			try
			{
				if (dgItems.DataSource!=null)
					if (((DataTable)dgItems.DataSource).Rows.Count>0)
					{
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cargando...", true);

						DataTable dt = (DataTable)dgItems.DataSource;
						int currentRow = dgItems.CurrentRowIndex;

						tbRemitoID.Text = dt.Rows[currentRow]["ID"].ToString();
                        tbEstadoRemitoIdentificador.Text = dt.Rows[currentRow]["estadoRemitoIdentificador"].ToString();
						tbNombreDestinatario.Text = dt.Rows[currentRow]["Destinatario"].ToString();
						tbDireccionDestinatario.Text = dt.Rows[currentRow]["Dirección Destinatario"].ToString();
					
						UtilUI.llenarCombo(ref cbEstadoMercaderia, this.conexion, "sp_getAlltv_MercaderiaEnTransitoEstados", "", -1);
						cbEstadoMercaderia.SelectedValue = dt.Rows[currentRow]["estadoMercaderiaEnTransitoID"].ToString();

						UtilUI.llenarCombo(ref cbEstadoMercaderiaTestigo, this.conexion, "sp_getAlltv_MercaderiaEnTransitoEstados", "", -1);
						cbEstadoMercaderiaTestigo.SelectedValue = dt.Rows[currentRow]["estadoMercaderiaEnTransitoID"].ToString();

						//Anula el boton guardar
						//butGuardarRemito.Enabled = false;

						/********************************
						 * Carga los items en la grilla
						 * ******************************/
						//Borra los registros de la grilla de SubArticulos
						DataTable tabla = (DataTable)dgRemitoLinea.DataSource;
						tabla.Rows.Clear();
						//Carga los articulos componentes
						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@remitoID", new System.Guid(tbRemitoID.Text));
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllRemitoLineas", param);
						if (dr.HasRows)
						{
							while (dr.Read())
							{
								DataRow newRow = tabla.NewRow();
                                newRow["itemSeleccionado"] = true;
                                newRow["ID"] = dr["ID"];
                                newRow["itemNro"] = dr["itemNro"].ToString();
								newRow["Código Interno"] = dr["codigoInterno"].ToString();
								newRow["Código de Barras"] = dr["codigoBarras"].ToString();
								newRow["Cantidad"] = dr["cantidad"].ToString();
								newRow["Rubro"] = dr["Rubro"].ToString();
								newRow["Sub Rubro"] = dr["SubRubro"].ToString();
								newRow["Descripción"] = dr["descripcion"].ToString();
								newRow["articuloID"] = dr["articuloID"].ToString();
								tabla.Rows.Add(newRow);
							}
						}
						dr.Close();


						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();
						//lblRegistro2.Text = lblRegistro.Text;

						string estadoRemito = dt.Rows[currentRow]["Estado Remito"].ToString();
						//Carga el titulo
						lblTituloRemito.Text = "     Remito Nº " + dt.Rows[currentRow]["Nro. Remito"].ToString() +
															", " + estadoRemito;
						//Habilita o deshabilita el boton de imprimir
						/*if (estadoRemito=="Impreso")
							butImprimirRemito.Enabled = false;
						else
							butImprimirRemito.Enabled = true;*/

						//Toma las observaciones del ultimo cambio de estado en la Mercaderia
						tbObservaciones.Text = dt.Rows[currentRow]["observaciones"].ToString();

                        //Datos nuevos
                        tbObsequiante.Text = dt.Rows[currentRow]["Obsequiante"].ToString();
                        tbBultos.Text = dt.Rows[currentRow]["Bultos"].ToString();

                        //Selecciona la zona
                        string zonaID = dt.Rows[currentRow]["zonaID"].ToString();
                        if (zonaID!="")
                            cbZona.SelectedValue =  dt.Rows[currentRow]["zonaID"];

                        //Marca Mostrar todos y selecciona el flete
                        chkMostrarTodosFletes.Checked = true;
                        UtilUI.llenarCombo(ref cbFlete, this.conexion, "sp_getAllFletes", "", -1);
                        string fleteID = dt.Rows[currentRow]["fleteID"].ToString();
                        if (fleteID != "")
                            cbFlete.SelectedValue = dt.Rows[currentRow]["fleteID"];

                        string localidadID = dt.Rows[currentRow]["destinatarioLocalidadID"].ToString();
                        if (localidadID != "")
                            cbLocalidad.SelectedValue = dt.Rows[currentRow]["destinatarioLocalidadID"];

                        string provinciaID = dt.Rows[currentRow]["destinatarioProvinciaID"].ToString();
                        if (provinciaID != "")
                            cbProvincia.SelectedValue = dt.Rows[currentRow]["destinatarioProvinciaID"];

                        string sucursalID = dt.Rows[currentRow]["sucursalCreacionID"].ToString();
                        if (sucursalID != "")
                            cbRSucursal.SelectedValue = dt.Rows[currentRow]["sucursalCreacionID"];

                        tbFacturaSuc.Text = dt.Rows[currentRow]["facturaSuc"].ToString();
                        tbFacturaNro.Text = dt.Rows[currentRow]["facturaNro"].ToString();


						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
					}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butAnterior_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dgItems.CurrentRowIndex>0)
				{
					dgItems.CurrentRowIndex = dgItems.CurrentRowIndex - 1;
					cargarDetalle();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSiguiente_Click(object sender, System.EventArgs e)
		{
			try
			{
				int count = ((DataTable)dgItems.DataSource).Rows.Count-1;
				if (dgItems.CurrentRowIndex<count)
				{
					dgItems.CurrentRowIndex = dgItems.CurrentRowIndex + 1;
					cargarDetalle();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Guardando registro...", true);
			if (validarFormulario())
				guardarCambios();
			else
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
		}

		private bool validarFormulario()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;

				/*
				if (tbRazonSocial.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar la Razón Social.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				*/

				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Guarda los cambios efectuados al registro
		private void guardarCambios()
		{
			/*

			int localidadID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidad, "sp_InsertLocalidad");
			int provinciaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvincia, "sp_InsertProvincia");

			SqlParameter[] param = new SqlParameter[13];
			
			param[0] = new SqlParameter("@ID", tbID.Text.Trim());
			param[1] = new SqlParameter("@razonSocial", tbRazonSocial.Text.Trim());
			param[2] = new SqlParameter("@calle", tbCalle.Text.Trim());
			param[3] = new SqlParameter("@telefonos", tbTelefonos.Text.Trim());
			param[4] = new SqlParameter("@nro", tbNro.Text.Trim());
			param[5] = new SqlParameter("@piso", tbPiso.Text.Trim());
			param[6] = new SqlParameter("@oficina", tbOficina.Text.Trim());
			param[7] = new SqlParameter("@codigoPostal", tbCodPost.Text.Trim());
			param[8] = new SqlParameter("@email", tbEmail.Text.Trim());
			param[9] = new SqlParameter("@localidadID", localidadID);
			param[10] = new SqlParameter("@cuit", tbCuit.Text.Trim());
			param[11] = new SqlParameter("@provinciaID", provinciaID);
			param[12] = new SqlParameter("@notas", tbNotas.Text.Trim());
			
			while (true)
			{
				try 
				{
					SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarProveedor", param);
					MessageBox.Show("Proveedor modificado con éxito.", "Modificación de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Proveedor modificado con éxito.", false);
					break;
				}
				catch (Exception e)
				{
					DialogResult dr = MessageBox.Show("No se pudo modificar el Proveedor. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Proveedor. \r\n" + e.Message, false);
					if (dr != DialogResult.Retry)
						break;
				}
			}
			*/
		}

		private void butBorrar_Click(object sender, System.EventArgs e)
		{
			borrarRegistrosSeleccionados();
		}

		private void borrarRegistrosSeleccionados()
		{
			try
			{
				if (dgItems.DataSource!=null)
				{
					DataTable dt = (DataTable)dgItems.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgItems.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							DialogResult dr = MessageBox.Show("¿Desea borrar los Remitos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Remitos...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));

                                    SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarRemitoActualizaCantidades", param);

									//dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = Utilidades.ID_VACIO; // "-1";
								}
								//Recorre los renglones marcados para borrar
								//DataRow[] rowsBorrar = dt.Select("id='-1'");
                                DataRow[] rowsBorrar = dt.Select("id='" + Utilidades.ID_VACIO + "'");
								for (int k=0; k<rowsBorrar.Length; k++)
								{
									rowsBorrar[k].Delete();
								}
								dt.AcceptChanges();
								dgItems.Refresh();
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butLimpiar3_Click(object sender, System.EventArgs e)
		{
			acomodarCombosOrden();
		}

		private void tbReazonSocialB_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				ejecutarBusqueda();
			}
		}

		private void butAceptar1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
				UtilUI.llenarCombo(ref cbRegaloEmpresarioB, this.conexion, "sp_getAlltv_NotaPedidoRegaloEmpresarios", "Todos", 0);
				UtilUI.llenarCombo(ref cbUsuarioB, this.conexion, "sp_getAllUsuariosBySucursal", "Todos", 0, param);
				UtilUI.llenarCombo(ref cbSucursalB, this.conexion, "sp_getAllSucursals", "Todas", 0);
				UtilUI.llenarCombo(ref cbEstadoRemitoB, this.conexion, "sp_getAlltv_RemitoEstados", "Todos", 0);
				UtilUI.llenarCombo(ref cbEstadoMercaderiaB, this.conexion, "sp_getAlltv_MercaderiaEnTransitoEstados", "Todos", 0);
				acomodarCombosOrden();

                //Zonas
                UtilUI.llenarCombo(ref cbZona, this.conexion, "sp_getAllZonas", "", -1);
                UtilUI.llenarCombo(ref cbFlete, this.conexion, "sp_getAllFletes", "", -1);

				//Define el tipo de consulta
				if (consultaRapida)
				{
					butSalir1.Visible = false;
					butAceptar1.Visible = true;
				}
				else
				{
					butSalir1.Visible = true;
					butAceptar1.Visible = false;
				}

				//Asigna la tabla a la datagrid
				dgRemitoLinea.DataSource = (DataTable)dataset.Tables["v_Articulo"];


                //Selecciona el tipo de presentacion
                if (this.tipoPresentacion == "IMPRIMIR_ASIGNAR")
                {
                    tabFiltro.SelectedIndex = 1; //Selecciona el Filtro Avanzado
                    cbUsuarioB.SelectedValue = this.configuracion.usuario.id;
                    UtilUI.comboSeleccionarItemByIdentificador("SUSPENDIDO", ref cbEstadoRemitoB);
                    chkSeleccionarTodo.Visible = true;
                    butImprimirPool.Visible = true;
                    dgItems.ReadOnly = false;
                    ejecutarBusqueda();
                }

                UtilUI.llenarCombo(ref cbLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
                UtilUI.llenarCombo(ref cbProvincia, this.conexion, "sp_getAllProvincias", "", -1);

                UtilUI.llenarCombo(ref cbRSucursal, this.conexion, "sp_getAllSucursals", "", -1);

			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Devuelve el ID de proveedor seleccionado en la grilla
		public string getProveedorID()
		{
			string id = "0";

			if (dgItems.DataSource!=null)
			{
				DataTable tabla = (DataTable)dgItems.DataSource;

				if (tabla.Rows.Count>0)
					if (dgItems.CurrentRowIndex>=0)
					{
						id = tabla.Rows[dgItems.CurrentRowIndex]["id"].ToString();
					}
			}
			return id;
		}


		private void tbNotaPedidoNroDesdeB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				string notaPedidoNroDesdeB = tbNotaPedidoNroDesdeB.Text.Trim().Replace(",","").Replace(".","");
				if (notaPedidoNroDesdeB!="")
				{
					if (!Utilidades.IsNumeric(notaPedidoNroDesdeB))
					{
						e.Cancel = true;
						MessageBox.Show("Nota Pedido Nro. (Desde) debe contener un número entero.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				tbNotaPedidoNroDesdeB.Text = notaPedidoNroDesdeB;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		

		//Valida el Formulario antes de guardarlo
		private bool validarFormularioCabecera()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;
			
				/*
				if (rbProveedor.Checked && tbProveedorID.Text=="")
				{
					mensaje += "   - Debe seleccionar un Proveedor.\r\n";
					resultado = false;
				}
				if (!Utilidades.IsNumeric(tbNroRemito1.Text) ||
					!Utilidades.IsNumeric(tbNroRemito2.Text) ||
					int.Parse(tbNroRemito1.Text)==0 ||
					int.Parse(tbNroRemito2.Text)==0)
				{
					mensaje += "   - Debe Completar el Nro. de Remito.\r\n";
					resultado = false;
				}
				if (((DataTable)dgSubArticulos.DataSource).Rows.Count==0)
				{
					mensaje += "   - Debe ingresar al menos un Artículo.\r\n";
					resultado = false;
				}

				*/
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		


		private void butCancelar_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void dgItems_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
				((Form)this.Parent).Close();
		}

		private void dgItems_CurrentCellChanged(object sender, System.EventArgs e)
		{
			dgItems.Select();
		}

		private void tbRemitoSucDesdeB_Validated(object sender, System.EventArgs e)
		{
			string remitoSuc = tbRemitoSucDesdeB.Text;
			Utilidades.agregarCerosIzquierda(ref remitoSuc,4);
			tbRemitoSucDesdeB.Text = remitoSuc;
		}
		private void tbRemitoSucHastaB_Validated(object sender, System.EventArgs e)
		{
			string remitoSuc = tbRemitoSucHastaB.Text;
			Utilidades.agregarCerosIzquierda(ref remitoSuc,4);
			tbRemitoSucHastaB.Text = remitoSuc;
		}

		private void tbRemitoNroDesdeB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega los ceros a la izquiera
				string remitoSuc = tbRemitoNroDesdeB.Text;
				Utilidades.agregarCerosIzquierda(ref remitoSuc,8);
				tbRemitoNroDesdeB.Text = remitoSuc;

				//Pone el valor Hasta
				string remitoNroDesdeB = tbRemitoNroDesdeB.Text.Trim();
				string remitoNroHastaB = tbRemitoNroHastaB.Text.Trim();
				if (remitoNroDesdeB!="")
				{
					if (remitoNroHastaB=="" || int.Parse(remitoNroHastaB)<int.Parse(remitoNroDesdeB))
					{
						tbRemitoSucHastaB.Text = tbRemitoSucDesdeB.Text;
						tbRemitoNroHastaB.Text = tbRemitoNroDesdeB.Text;
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void campoEntero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				TextBox tb = (TextBox)sender;
				string valor = tb.Text.Trim().Replace(",","").Replace(".","");
				if (valor!="")
				{
					if (!Utilidades.IsNumeric(valor))
					{
						e.Cancel = true;
						MessageBox.Show("El valor del campo debe contener un número entero.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				tb.Text = valor;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbRemitoNroHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega ceros a la izquierda
				string remitoNro = tbRemitoNroHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref remitoNro,8);
				tbRemitoNroHastaB.Text = remitoNro;

				//Establece el valor desde
				string remitoNroDesdeB = tbRemitoNroDesdeB.Text.Trim();
				string remitoNroHastaB = tbRemitoNroHastaB.Text.Trim();
				if (remitoNroHastaB!="")
				{
					if (remitoNroDesdeB=="" || int.Parse(remitoNroDesdeB)>int.Parse(remitoNroHastaB))
						tbRemitoNroDesdeB.Text = tbRemitoNroHastaB.Text;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dtpFechaEmisionHasta_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaEmisionDesde.Value > dtpFechaEmisionHasta.Value)
				dtpFechaEmisionDesde.Value = dtpFechaEmisionHasta.Value;
		}

		private void dtpFechaEmisionDesde_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaEmisionHasta.Value < dtpFechaEmisionDesde.Value)
				dtpFechaEmisionHasta.Value = dtpFechaEmisionDesde.Value;
		}

		private void chkFechaEmision_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpFechaEmisionDesde.Enabled = chkFechaEmision.Checked;
			dtpFechaEmisionHasta.Enabled = chkFechaEmision.Checked;
		}

		private void butLimpiar2_Click(object sender, System.EventArgs e)
		{
			try
			{
                tbNotaPedidoSucDesdeB.Text = "";
				tbNotaPedidoNroDesdeB.Text = "";
				cbUsuarioB.SelectedIndex = 0;
				cbSucursalB.SelectedIndex = 0;
				cbEstadoRemitoB.SelectedIndex = 0;
				cbEstadoMercaderiaB.SelectedIndex = 0;
				tbNombreDestinatarioB.Text = "";
				tbDireccionDestinatarioB.Text = "";
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butImprimirRemito_Click(object sender, System.EventArgs e)
		{

            //Si no esta suspendido
            if (tbEstadoRemitoIdentificador.Text == "IMPRESO")
            {
                //Verifica el permiso y/o permite la autorizacion del administrador
                Usuario usuarioInicial = this.configuracion.usuario;
                Seguridad seguridad = new Seguridad(this.configuracion);
                if (seguridad.verificarPermiso("Administracion.RemitoReimpresion", "EJECUTAR"))
                    imprimirIndividual();
                seguridad = null;
                this.configuracion.usuario = usuarioInicial;
            }
            else
                imprimirIndividual();

		}

        private void imprimirIndividual()
        {
            DialogResult dr = MessageBox.Show("Está a punto de imprimir el Remito.\r\n\r\n¿Desea continuar?", "Impresión de Remitos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Remito remito = new Remito(this.configuracion);

                //Primero guarda el Remito
                utilRemito.guardarCambios(this.configuracion, ref tabPrincipal, "SUSPENDIDO");

                //Luego lo imprime
                if (remito.imprimirRemito(tbRemitoID.Text))
                {
                    //Cambia el estado a IMPRESO
                    remito.cambiarEstadoRemito(tbRemitoID.Text, "IMPRESO");

                    //Actualiza el stock
                    remito.actualizarStock(((DataTable)dgRemitoLinea.DataSource), tbRemitoID.Text);

                    //Cambia el estado de la mercaderia
                    remito.cambiarEstadoMercaderia(tbRemitoID.Text, "DESPACHADA", "");

                    MessageBox.Show("El Remito fue enviado a la cola de impresión.\r\n\r\nDestinatario: " + tbNombreDestinatario.Text, "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //limpiarFormularioRemito();
                }
                remito = null;
            }
        }

        private void actualizarRegistroGrilla(Remito remito, string zonaID, string fleteID, string estadoRemito)
        {
            //Actualiza el registro de la grilla de consulta de Remitos
            DataTable dtRemitos = (DataTable)dgItems.DataSource;
            int row = dgItems.CurrentRowIndex;
            
            if (estadoRemito!="")
                dtRemitos.Rows[row]["Estado Remito"] = estadoRemito;
            
            dtRemitos.Rows[row]["Nro. Remito"] = remito.RemitoSuc + "-" + remito.RemitoNro;
            dtRemitos.Rows[row]["zonaID"] = new Guid(zonaID);
            dtRemitos.Rows[row]["fleteID"] = new Guid(fleteID);

            if (cbEstadoMercaderia.SelectedValue!=null)
                dtRemitos.Rows[row]["estadoMercaderiaEnTransitoID"] = new Guid(cbEstadoMercaderia.SelectedValue.ToString());

            dtRemitos.Rows[row]["Observaciones"] = tbObservaciones.Text;


            dtRemitos = null;
        }

		private void cbEstadoMercaderia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*if (cbEstadoMercaderia.SelectedValue != cbEstadoMercaderiaTestigo.SelectedValue)
				butGuardarRemito.Enabled = true;
			else
				butGuardarRemito.Enabled = false;*/
		}

		private void butGuardarRemito_Click(object sender, System.EventArgs e)
		{
            DataTable dt;
            Remito remito = new Remito(this.configuracion);

            //Cambia el estado de la mercaderia
			if (cbEstadoMercaderia.SelectedIndex > -1)
			{
				dt = (DataTable)cbEstadoMercaderia.DataSource;
				remito.cambiarEstadoMercaderia(tbRemitoID.Text, dt.Rows[cbEstadoMercaderia.SelectedIndex]["identificador"].ToString(), tbObservaciones.Text);
				dt = null;
			}

            //Guarda el flete y la zona
            string zonaID = Utilidades.ID_VACIO;
            string fleteID = Utilidades.ID_VACIO;

            if (cbZona.SelectedValue != null) zonaID = cbZona.SelectedValue.ToString();
            if (cbFlete.SelectedValue != null) fleteID = cbFlete.SelectedValue.ToString();

            remito.asignarZonayFlete(tbRemitoID.Text, zonaID, fleteID);

            actualizarRegistroGrilla(remito, zonaID, fleteID, "");

            remito = null;

            //MessageBox.Show("Se han guardado los cambios.","Guardar Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            dt = (DataTable)dgItems.DataSource;
            string estadoRemitoIdentificador = dt.Rows[dgItems.CurrentRowIndex]["estadoRemitoIdentificador"].ToString();
            if (estadoRemitoIdentificador == "")
                estadoRemitoIdentificador = "SUSPENDIDO";

            UserControl uc = (UserControl)this;
            if (utilRemito.guardarCambios(this.configuracion, ref tabPrincipal, estadoRemitoIdentificador))
            {
                MessageBox.Show("Remito guardado con éxito.\r\n\r\nDestinatario: " + tbNombreDestinatario.Text, "Guardar Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //limpiarFormularioRemito();
            }
            
		}

        private void cbZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkMostrarTodosFletes.Checked)
                utilRemito.cargarFletes(this.configuracion, ref cbZona, ref cbFlete, chkMostrarTodosFletes.Checked);
        }

        private void chkMostrarTodosFletes_CheckedChanged(object sender, EventArgs e)
        {
            utilRemito.cargarFletes(this.configuracion, ref cbZona, ref cbFlete, chkMostrarTodosFletes.Checked);
        }

        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            seleccionarTodo();
        }

        //Marca o desmarca todos los registros de la grilla
        private void seleccionarTodo()
        {
            try
            {
                DataTable tabla = (DataTable)dgItems.DataSource;
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow row in tabla.Rows)
                    {
                        row["Seleccionado"] = chkSeleccionarTodo.Checked;
                    }
                }
                tabla.Dispose();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butImprimirPool_Click(object sender, EventArgs e)
        {
            if (UtilUI.obtenerIdentificadorCombo(ref cbEstadoRemitoB) != "SUSPENDIDO")
            {
                //Verifica el permiso y/o permite la autorizacion del administrador
                Usuario usuarioInicial = this.configuracion.usuario;
                Seguridad seguridad = new Seguridad(this.configuracion);
                if (seguridad.verificarPermiso("Administracion.RemitoReimpresion", "EJECUTAR"))
                    imprimirPool();
                seguridad = null;
                this.configuracion.usuario = usuarioInicial;
            }
            else
                imprimirPool();

            ejecutarBusqueda();
        }

        //Imprime los remitos seleccionados
        private void imprimirPool()
        {
            try
            {
                DialogResult dl = MessageBox.Show("Está a punto de imprimir todos los Remitos seleccionados.\r\n\r\n¿Desea continuar?", "Impresión de Remitos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    DataTable dt = (DataTable)dgItems.DataSource;
                    int cantidad = 0;
                    if (dt.Rows.Count > 0)
                    {
                        Remito remito = new Remito(this.configuracion);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (bool.Parse(dt.Rows[i]["Seleccionado"].ToString()))
                            {
                                if (dt.Rows[i]["estadoRemitoIdentificador"].ToString() == "SUSPENDIDO" ||
                                    dt.Rows[i]["estadoRemitoIdentificador"].ToString() == "IMPRESO")
                                {
                                    string remitoID = dt.Rows[i]["ID"].ToString();
                                    if (remito.imprimirRemito(remitoID))
                                    {
                                        //Cambia el estado a IMPRESO
                                        remito.cambiarEstadoRemito(remitoID, "IMPRESO");

                                        //Actualiza el stock
                                        remito.actualizarStock(remitoID);

                                        //Cambia el estado de la mercaderia
                                        remito.cambiarEstadoMercaderia(remitoID, "DESPACHADA", "");

                                        //Aumenta la cantidad de remitos impresos
                                        cantidad++;

                                        Application.DoEvents();
                                        Thread.Sleep(3000);
                                    }
                                    else //si no se imprimio correctamente el remito.
                                    {
                                        dl = MessageBox.Show("No se pudo imprimir el Remito para " +
                                            dt.Rows[i]["Destinatario"].ToString() + ".\r\n\r\n¿Reintentar?", "Error de Impresión",
                                            MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);

                                        if (dl == DialogResult.Abort)
                                        {
                                            break;
                                        }
                                        else if (dl == DialogResult.Retry)
                                        {
                                            i--;
                                        }
                                        else if (dl == DialogResult.Ignore)
                                        { }
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Se enviaron " + cantidad.ToString() + " REMITOS a la cola de impresión.\r\n\r\nPor favor cuéntelos. Si no coinciden las cantidades, verifique la BANDEJA DE IMPRESION.", "Impresión de Remitos",
                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        remito = null;
                    }
                }

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbNotaPedidoSucDesdeB_Validated(object sender, EventArgs e)
        {
            string suc = tbNotaPedidoSucDesdeB.Text;
            Utilidades.agregarCerosIzquierda(ref suc, 4);
            tbNotaPedidoSucDesdeB.Text = suc;
        }

        private void tbNotaPedidoNroDesdeB_Validated_1(object sender, EventArgs e)
        {
            try
            {
                //Agrega los ceros a la izquiera
                string suc = tbNotaPedidoNroDesdeB.Text;
                Utilidades.agregarCerosIzquierda(ref suc, 8);
                tbNotaPedidoNroDesdeB.Text = suc;

                //Agrega los ceros en la sucursal
                tbNotaPedidoSucDesdeB_Validated(sender, e);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butSuspender_Click(object sender, EventArgs e)
        {
            //if (verificarCantidadesRemito())
            //{
                UserControl uc = (UserControl)this;
                if (utilRemito.guardarCambios(this.configuracion, ref tabPrincipal, "SUSPENDIDO"))  //Estado 2, Guardado no impreso.
                {
                    MessageBox.Show("Remito suspendido con éxito.\r\n\r\nDestinatario: " + tbNombreDestinatario.Text, "Suspender", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //limpiarFormularioRemito();
                }
            //}
        }

        private void butBorrarRemito_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea borrar el Remito?", "Borrar Remito", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dr== DialogResult.Yes)
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Remitos...", true);
				SqlParameter[] param = new SqlParameter[1];
			
				param[0] = new SqlParameter("@remitoID", new System.Guid(tbRemitoID.Text));

                SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarRemitoActualizaCantidades", param);
                tabPrincipal.SelectedIndex = 0;
                ejecutarBusqueda();

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
		
        }

        //Esta region maneja los eventos para la grilla
        #region Maneja los eventos Dobleclick, return y DEL sobre las celdas de la grilla

        private bool estaFocoEnCelda = false;
        //Asigna el manejador de eventos a las celdas de la grilla
        private void asignarEventosGrilla(ref DataGrid dg)
        {
            DataGridTextBoxColumn tbCol = null;
            foreach (DataGridTableStyle ts in dg.TableStyles)
                //foreach (DataGridTextBoxColumn tbCol in ts.GridColumnStyles)
                foreach (DataGridColumnStyle colSty in ts.GridColumnStyles)
                {
                    if (colSty.GetType().FullName == "System.Windows.Forms.DataGridTextBoxColumn")
                    {
                        tbCol = (DataGridTextBoxColumn)colSty;
                        tbCol.TextBox.DoubleClick += new EventHandler(TextBox_DoubleClick);
                        tbCol.TextBox.GotFocus += new EventHandler(TextBox_GotFocus);
                        tbCol.TextBox.LostFocus += new EventHandler(TextBox_LostFocus);
                    }
                }
        }

        private void TextBox_DoubleClick(object sender, EventArgs e)
        {
            ejecutarAccionAceptar(sender, e);
        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            this.estaFocoEnCelda = true;
        }
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            this.estaFocoEnCelda = false;
        }

        private void ejecutarAccionAceptar(object sender, EventArgs e)
        {
            /*if (this.estaFocoEnCelda)
            {
                if (this.consultaRapida)
                    butAceptar4_Click(sender, e);
                else
                    dgItems_DoubleClick(sender, e);
            }*/
        }
        private void ejecutarAccionEscape(object sender, EventArgs e)
        {
            /*if (this.consultaRapida)
            {
                DataTable dt = (DataTable)dgItems.DataSource;
                if (dt != null)
                    (dt).Rows.Clear(); //Borra los registros asi no selecciona el registro actual.
                butSalir_Click(sender, e);
                dt = null;
            }*/
        }

        private const int WM_KEYDOWN = 0x100;

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            bool keyDel = false;
            switch (msg.Msg)
            {
                case WM_KEYDOWN:
                    {
                        switch (keyData)
                        {
                            case System.Windows.Forms.Keys.Enter:
                                {
                                    try
                                    {
                                        //ejecutarAccionAceptar(new object(), new EventArgs());
                                        //DataGridCell newCell = new DataGridCell(dgItems.CurrentCell.RowNumber, dgItems.CurrentCell.ColumnNumber + 1);
                                        //dgItems.CurrentCell = newCell;
                                    }
                                    catch (Exception e)
                                    { }
                                    break;
                                }
                            case System.Windows.Forms.Keys.Escape:
                                //ejecutarAccionEscape(new object(), new EventArgs());
                                break;
                            case System.Windows.Forms.Keys.Delete:
                                keyDel = true;
                                break;
                            default:
                                //MessageBox.Show(keyData.ToString());
                                break;
                        }
                        break;
                    }
            }

            if (keyDel)
                return true;
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
	}
}
