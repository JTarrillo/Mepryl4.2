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

namespace Comunes
{
	/// <summary>
	/// Summary description for ucMercaderiaIngreso.
	/// </summary>
	public class ucRemitoAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = "";
		public Configuracion m_configuracion;
		private Hashtable controles = new Hashtable();
		private Hashtable controlesDet = new Hashtable();
		public bool consultaRapida = false;
		private Control tbCodigoUsado;
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox gbRemitoBase;
		private System.Windows.Forms.Button butNuevoRemito;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.ComboBox cbEstadoB;
		private System.Windows.Forms.Button butAceptar1;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox tbCuitB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbCondicionEntregaB;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox gbProveedor;
		private System.Windows.Forms.ComboBox cbVendedorB;
		private System.Windows.Forms.GroupBox groupBox3;
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
		private System.Windows.Forms.DataGrid dgArticulosBase;
		private System.Windows.Forms.DataGrid dgArticulosNuevoRemito;
		public DataSet datasetRemitoBase = (DataSet) new dsArticulos();
		private System.Windows.Forms.TextBox tbNotaPedidoID;
		private System.Windows.Forms.TextBox tbRemitoBaseID;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.TabControl tabConfeccionarRemitos;
		private System.Windows.Forms.CheckBox chkSeleccionarTodo;
		private System.Windows.Forms.Button butCancelarRemito;
		private System.Windows.Forms.Button butGuardarRemito;
		private System.Windows.Forms.Button butImprimirRemito;
		private System.Windows.Forms.GroupBox gbNuevoRemito;
		private System.Windows.Forms.TextBox tbNuevoRemitoID;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.Button butBorrarArticulosComponentes;
		private System.Windows.Forms.DataGrid dgSubArticulos;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button butContinuar2;
		private System.Windows.Forms.Button butCancelar;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox tbPromocionAC;
		private System.Windows.Forms.TextBox tbPrecioAC;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Button butAgregarArticuloAC;
		private System.Windows.Forms.TextBox tbCodigoBarrasAC;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox tbCodigoInternoAC;
		private System.Windows.Forms.Label tbDescripcionAC;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label tbSubRubroAC;
		private System.Windows.Forms.Label tbRubroAC;
		private System.Windows.Forms.Button butBuscarArticuloAC;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbCantidadAC;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox cbSucursal;
		private System.Windows.Forms.TextBox tbNroNotaPedido;
		private System.Windows.Forms.TabControl tabArticulosManualmente;
		private System.Windows.Forms.DataGridTableStyle dgtsListadoNotaPedido;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTableStyle dgtsArticulosManualmente;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTableStyle dgtsRemitoArticulos;
		private System.Windows.Forms.DataGridTableStyle dgtsArticulosBase;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn44;
		public DataSet datasetRemito = (DataSet) new dsArticulos();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbNombreDestinatario;
		private System.Windows.Forms.TextBox tbDireccionDestinatario;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbRBDireccionDestinatario;
		private System.Windows.Forms.TextBox tbRBNombreDestinatario;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.ComboBox cbRegaloEmpresarioB;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tbNotaPedidoSucHastaB;
		private System.Windows.Forms.TextBox tbNotaPedidoNroDesdeB;
		private System.Windows.Forms.TextBox tbNotaPedidoNroHastaB;
		private System.Windows.Forms.TextBox tbNotaPedidoSucDesdeB;
		private System.Windows.Forms.TextBox tbNotaPedidoIDB;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbRBBultos;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cbRBFlete;
		private System.Windows.Forms.ComboBox cbRBZona;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbRBObsequiante;
		private System.Windows.Forms.ComboBox cbZona;
		private System.Windows.Forms.ComboBox cbFlete;
		private System.Windows.Forms.TextBox tbObsequiante;
		private System.Windows.Forms.TextBox tbBultos;
		private System.Windows.Forms.CheckBox chkRBRegaloEmpresario;
        private CheckBox chkRBMostrarTodosFletes;
        private CheckBox chkMostrarTodosFletes;
        private Label label15;
        private ComboBox cbLocalidad;
        private ComboBox cbRBLocalidad;
        private Label label16;
        private ComboBox cbRBProvincia;
        private Label label17;
        private ComboBox cbProvincia;
        private Label label19;
        private Button butCerrar;
        private ComboBox cbRBSucursal;
        private Label label28;
        private ComboBox cbRSucursal;
        private Label label29;
        private TextBox tbFacturaNro;
        private TextBox tbFacturaSuc;
        private Label label30;
		public DataSet datasetArticulosManualmente = (DataSet) new dsArticulos();

		public ucRemitoAlta()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRemitoAlta));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dgtsListadoNotaPedido = new System.Windows.Forms.DataGridTableStyle();
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
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbNotaPedidoIDB = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tbNotaPedidoSucHastaB = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoNroDesdeB = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoNroHastaB = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoSucDesdeB = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.cbRegaloEmpresarioB = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbEstadoB = new System.Windows.Forms.ComboBox();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbCuitB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCondicionEntregaB = new System.Windows.Forms.ComboBox();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.cbVendedorB = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbRazonSocialB = new System.Windows.Forms.TextBox();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabArticulosManualmente = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNroNotaPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.butBorrarArticulosComponentes = new System.Windows.Forms.Button();
            this.dgSubArticulos = new System.Windows.Forms.DataGrid();
            this.dgtsArticulosManualmente = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.butContinuar2 = new System.Windows.Forms.Button();
            this.butCancelar = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbPromocionAC = new System.Windows.Forms.TextBox();
            this.tbPrecioAC = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.butAgregarArticuloAC = new System.Windows.Forms.Button();
            this.tbCodigoBarrasAC = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCodigoInternoAC = new System.Windows.Forms.TextBox();
            this.tbDescripcionAC = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbSubRubroAC = new System.Windows.Forms.Label();
            this.tbRubroAC = new System.Windows.Forms.Label();
            this.butBuscarArticuloAC = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.tbCantidadAC = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabConfeccionarRemitos = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgArticulosBase = new System.Windows.Forms.DataGrid();
            this.dgtsArticulosBase = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gbRemitoBase = new System.Windows.Forms.GroupBox();
            this.tbFacturaNro = new System.Windows.Forms.TextBox();
            this.tbFacturaSuc = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cbRBSucursal = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.butCerrar = new System.Windows.Forms.Button();
            this.cbRBProvincia = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbRBLocalidad = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkRBMostrarTodosFletes = new System.Windows.Forms.CheckBox();
            this.chkRBRegaloEmpresario = new System.Windows.Forms.CheckBox();
            this.tbRBObsequiante = new System.Windows.Forms.TextBox();
            this.tbRBBultos = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbRBFlete = new System.Windows.Forms.ComboBox();
            this.cbRBZona = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbRBDireccionDestinatario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRBNombreDestinatario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRemitoBaseID = new System.Windows.Forms.TextBox();
            this.butNuevoRemito = new System.Windows.Forms.Button();
            this.tbNotaPedidoID = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.dgArticulosNuevoRemito = new System.Windows.Forms.DataGrid();
            this.dgtsRemitoArticulos = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gbNuevoRemito = new System.Windows.Forms.GroupBox();
            this.cbRSucursal = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.butCancelarRemito = new System.Windows.Forms.Button();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkMostrarTodosFletes = new System.Windows.Forms.CheckBox();
            this.tbBultos = new System.Windows.Forms.TextBox();
            this.tbObsequiante = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbFlete = new System.Windows.Forms.ComboBox();
            this.cbZona = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDireccionDestinatario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNombreDestinatario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNuevoRemitoID = new System.Windows.Forms.TextBox();
            this.butGuardarRemito = new System.Windows.Forms.Button();
            this.butImprimirRemito = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabArticulosManualmente.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabConfeccionarRemitos.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulosBase)).BeginInit();
            this.gbRemitoBase.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulosNuevoRemito)).BeginInit();
            this.gbNuevoRemito.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.YellowGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.YellowGreen;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(800, 32);
            this.label18.TabIndex = 114;
            this.label18.Text = "     Alta de Remitos";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Controls.Add(this.tabPage5);
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.ImageList = this.imageList1;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 32);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(800, 424);
            this.tabPrincipal.TabIndex = 116;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.dgItems);
            this.tabPage1.Controls.Add(this.tabFiltro);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Buscar Nota de Pedido";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Purple;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 123;
            this.pictureBox2.TabStop = false;
            // 
            // dgItems
            // 
            this.dgItems.AllowSorting = false;
            this.dgItems.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dgItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItems.CaptionBackColor = System.Drawing.Color.Purple;
            this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.CaptionForeColor = System.Drawing.Color.White;
            this.dgItems.CaptionText = "     Listado Notas de Pedido";
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
            this.dgItems.Size = new System.Drawing.Size(792, 245);
            this.dgItems.TabIndex = 119;
            this.dgItems.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsListadoNotaPedido});
            this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            // 
            // dgtsListadoNotaPedido
            // 
            this.dgtsListadoNotaPedido.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.dgtsListadoNotaPedido.DataGrid = this.dgItems;
            this.dgtsListadoNotaPedido.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18});
            this.dgtsListadoNotaPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsListadoNotaPedido.MappingName = "Items";
            this.dgtsListadoNotaPedido.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Nro.";
            this.dataGridTextBoxColumn1.MappingName = "Nro.";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 120;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Fecha Creación";
            this.dataGridTextBoxColumn2.MappingName = "Fecha Creación";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 140;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Razón Social";
            this.dataGridTextBoxColumn3.MappingName = "Razón Social";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 140;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Dirección Cliente";
            this.dataGridTextBoxColumn4.MappingName = "Dirección Cliente";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 140;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "CUIT";
            this.dataGridTextBoxColumn5.MappingName = "CUIT";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Dirección Entrega";
            this.dataGridTextBoxColumn6.MappingName = "Dirección Entrega";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 140;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn7.Format = "N";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Bonif. %  .";
            this.dataGridTextBoxColumn7.MappingName = "Bonif. %";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn8.Format = "C";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "SubTotal 1  .";
            this.dataGridTextBoxColumn8.MappingName = "SubTotal 1";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn9.Format = "C";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "IVA 1  .";
            this.dataGridTextBoxColumn9.MappingName = "IVA 1";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn10.Format = "C";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "IVA 2  .";
            this.dataGridTextBoxColumn10.MappingName = "IVA 2";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 75;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn11.Format = "C";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Total";
            this.dataGridTextBoxColumn11.MappingName = "total";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn12.Format = "C";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "SubTotal 2  .";
            this.dataGridTextBoxColumn12.MappingName = "SubTotal 2";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 75;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn13.Format = "C";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Bonificación  .";
            this.dataGridTextBoxColumn13.MappingName = "Bonificación";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Máquina";
            this.dataGridTextBoxColumn14.MappingName = "Máquina";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 75;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "Tipo IVA";
            this.dataGridTextBoxColumn15.MappingName = "Tipo IVA";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 75;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "Vendedor";
            this.dataGridTextBoxColumn16.MappingName = "Vendedor";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "Estado";
            this.dataGridTextBoxColumn17.MappingName = "Estado";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 75;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "Autorizó";
            this.dataGridTextBoxColumn18.MappingName = "Autorizó";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 75;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabFiltro1);
            this.tabFiltro.Controls.Add(this.tabFiltro3);
            this.tabFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabFiltro.HotTrack = true;
            this.tabFiltro.ImageList = this.imageList1;
            this.tabFiltro.ItemSize = new System.Drawing.Size(0, 18);
            this.tabFiltro.Location = new System.Drawing.Point(0, 0);
            this.tabFiltro.Multiline = true;
            this.tabFiltro.Name = "tabFiltro";
            this.tabFiltro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabFiltro.SelectedIndex = 0;
            this.tabFiltro.Size = new System.Drawing.Size(792, 152);
            this.tabFiltro.TabIndex = 118;
            // 
            // tabFiltro1
            // 
            this.tabFiltro1.Controls.Add(this.button1);
            this.tabFiltro1.Controls.Add(this.groupBox4);
            this.tabFiltro1.Controls.Add(this.groupBox17);
            this.tabFiltro1.Controls.Add(this.groupBox7);
            this.tabFiltro1.Controls.Add(this.butAceptar1);
            this.tabFiltro1.Controls.Add(this.groupBox10);
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.Controls.Add(this.gbProveedor);
            this.tabFiltro1.Controls.Add(this.groupBox3);
            this.tabFiltro1.ImageIndex = 3;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(736, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 32);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbNotaPedidoIDB);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.tbNotaPedidoSucHastaB);
            this.groupBox4.Controls.Add(this.tbNotaPedidoNroDesdeB);
            this.groupBox4.Controls.Add(this.tbNotaPedidoNroHastaB);
            this.groupBox4.Controls.Add(this.tbNotaPedidoSucDesdeB);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 104);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nota Pedido Nro.";
            // 
            // tbNotaPedidoIDB
            // 
            this.tbNotaPedidoIDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoIDB.Location = new System.Drawing.Point(120, 8);
            this.tbNotaPedidoIDB.Name = "tbNotaPedidoIDB";
            this.tbNotaPedidoIDB.Size = new System.Drawing.Size(32, 20);
            this.tbNotaPedidoIDB.TabIndex = 12;
            this.tbNotaPedidoIDB.Visible = false;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 12);
            this.label22.TabIndex = 11;
            this.label22.Text = "Hasta";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 16);
            this.label26.TabIndex = 10;
            this.label26.Text = "Desde";
            // 
            // tbNotaPedidoSucHastaB
            // 
            this.tbNotaPedidoSucHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoSucHastaB.Location = new System.Drawing.Point(8, 70);
            this.tbNotaPedidoSucHastaB.Name = "tbNotaPedidoSucHastaB";
            this.tbNotaPedidoSucHastaB.Size = new System.Drawing.Size(56, 20);
            this.tbNotaPedidoSucHastaB.TabIndex = 8;
            this.tbNotaPedidoSucHastaB.Validated += new System.EventHandler(this.tbNotaPedidoSucHastaB_Validated);
            this.tbNotaPedidoSucHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbNotaPedidoNroDesdeB
            // 
            this.tbNotaPedidoNroDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoNroDesdeB.Location = new System.Drawing.Point(64, 30);
            this.tbNotaPedidoNroDesdeB.Name = "tbNotaPedidoNroDesdeB";
            this.tbNotaPedidoNroDesdeB.Size = new System.Drawing.Size(128, 20);
            this.tbNotaPedidoNroDesdeB.TabIndex = 7;
            this.tbNotaPedidoNroDesdeB.Validated += new System.EventHandler(this.tbNotaPedidoNroDesdeB_Validated_1);
            this.tbNotaPedidoNroDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbNotaPedidoNroHastaB
            // 
            this.tbNotaPedidoNroHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoNroHastaB.Location = new System.Drawing.Point(64, 70);
            this.tbNotaPedidoNroHastaB.Name = "tbNotaPedidoNroHastaB";
            this.tbNotaPedidoNroHastaB.Size = new System.Drawing.Size(128, 20);
            this.tbNotaPedidoNroHastaB.TabIndex = 9;
            this.tbNotaPedidoNroHastaB.Validated += new System.EventHandler(this.tbNotaPedidoNroHastaB_Validated_1);
            this.tbNotaPedidoNroHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbNotaPedidoSucDesdeB
            // 
            this.tbNotaPedidoSucDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoSucDesdeB.Location = new System.Drawing.Point(8, 30);
            this.tbNotaPedidoSucDesdeB.Name = "tbNotaPedidoSucDesdeB";
            this.tbNotaPedidoSucDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbNotaPedidoSucDesdeB.TabIndex = 6;
            this.tbNotaPedidoSucDesdeB.Validated += new System.EventHandler(this.tbNotaPedidoSucDesdeB_Validated);
            this.tbNotaPedidoSucDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.cbRegaloEmpresarioB);
            this.groupBox17.Location = new System.Drawing.Point(360, 64);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(128, 48);
            this.groupBox17.TabIndex = 17;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Regalo Empresario";
            // 
            // cbRegaloEmpresarioB
            // 
            this.cbRegaloEmpresarioB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegaloEmpresarioB.ItemHeight = 13;
            this.cbRegaloEmpresarioB.Location = new System.Drawing.Point(8, 16);
            this.cbRegaloEmpresarioB.Name = "cbRegaloEmpresarioB";
            this.cbRegaloEmpresarioB.Size = new System.Drawing.Size(112, 21);
            this.cbRegaloEmpresarioB.TabIndex = 11;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbEstadoB);
            this.groupBox7.Location = new System.Drawing.Point(496, 64);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(128, 48);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Estado";
            // 
            // cbEstadoB
            // 
            this.cbEstadoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoB.Location = new System.Drawing.Point(8, 16);
            this.cbEstadoB.Name = "cbEstadoB";
            this.cbEstadoB.Size = new System.Drawing.Size(112, 21);
            this.cbEstadoB.TabIndex = 10;
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
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbCuitB);
            this.groupBox10.Location = new System.Drawing.Point(496, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(128, 48);
            this.groupBox10.TabIndex = 11;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "CUIT";
            // 
            // tbCuitB
            // 
            this.tbCuitB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCuitB.Location = new System.Drawing.Point(8, 16);
            this.tbCuitB.Name = "tbCuitB";
            this.tbCuitB.Size = new System.Drawing.Size(112, 20);
            this.tbCuitB.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCondicionEntregaB);
            this.groupBox1.Location = new System.Drawing.Point(216, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 48);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condición Entrega";
            // 
            // cbCondicionEntregaB
            // 
            this.cbCondicionEntregaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionEntregaB.Location = new System.Drawing.Point(8, 16);
            this.cbCondicionEntregaB.Name = "cbCondicionEntregaB";
            this.cbCondicionEntregaB.Size = new System.Drawing.Size(120, 21);
            this.cbCondicionEntregaB.TabIndex = 10;
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
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.cbVendedorB);
            this.gbProveedor.Location = new System.Drawing.Point(360, 8);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(128, 48);
            this.gbProveedor.TabIndex = 5;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Vendedor";
            // 
            // cbVendedorB
            // 
            this.cbVendedorB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedorB.Location = new System.Drawing.Point(8, 16);
            this.cbVendedorB.Name = "cbVendedorB";
            this.cbVendedorB.Size = new System.Drawing.Size(112, 21);
            this.cbVendedorB.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbRazonSocialB);
            this.groupBox3.Location = new System.Drawing.Point(216, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nombre / Razón Social";
            // 
            // tbRazonSocialB
            // 
            this.tbRazonSocialB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRazonSocialB.Location = new System.Drawing.Point(8, 16);
            this.tbRazonSocialB.Name = "tbRazonSocialB";
            this.tbRazonSocialB.Size = new System.Drawing.Size(120, 20);
            this.tbRazonSocialB.TabIndex = 1;
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
            this.tabFiltro3.ImageIndex = 4;
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
            this.cbCampoOrden2.Items.AddRange(new object[] {
            "---",
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Estado",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nro.",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Tipo IVA",
            "Vendedo"});
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
            this.cbCampoOrden4.Items.AddRange(new object[] {
            "---",
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Estado",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nro.",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Tipo IVA",
            "Vendedo"});
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
            this.rbAsc1.Image = ((System.Drawing.Image)(resources.GetObject("rbAsc1.Image")));
            this.rbAsc1.Location = new System.Drawing.Point(232, 16);
            this.rbAsc1.Name = "rbAsc1";
            this.rbAsc1.Size = new System.Drawing.Size(24, 24);
            this.rbAsc1.TabIndex = 16;
            // 
            // cbCampoOrden1
            // 
            this.cbCampoOrden1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampoOrden1.Items.AddRange(new object[] {
            "---",
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Estado",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nro.",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Tipo IVA",
            "Vendedor"});
            this.cbCampoOrden1.Location = new System.Drawing.Point(8, 16);
            this.cbCampoOrden1.Name = "cbCampoOrden1";
            this.cbCampoOrden1.Size = new System.Drawing.Size(216, 21);
            this.cbCampoOrden1.TabIndex = 14;
            // 
            // rbDesc1
            // 
            this.rbDesc1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDesc1.Checked = true;
            this.rbDesc1.Image = ((System.Drawing.Image)(resources.GetObject("rbDesc1.Image")));
            this.rbDesc1.Location = new System.Drawing.Point(264, 16);
            this.rbDesc1.Name = "rbDesc1";
            this.rbDesc1.Size = new System.Drawing.Size(24, 24);
            this.rbDesc1.TabIndex = 17;
            this.rbDesc1.TabStop = true;
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
            this.cbCampoOrden3.Items.AddRange(new object[] {
            "---",
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Estado",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nro.",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Tipo IVA",
            "Vendedo"});
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
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabArticulosManualmente);
            this.tabPage5.ImageIndex = 5;
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(792, 397);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Ingresar Artículos Manualmente";
            // 
            // tabArticulosManualmente
            // 
            this.tabArticulosManualmente.Controls.Add(this.tabPage6);
            this.tabArticulosManualmente.Controls.Add(this.tabPage7);
            this.tabArticulosManualmente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabArticulosManualmente.HotTrack = true;
            this.tabArticulosManualmente.ImageList = this.imageList1;
            this.tabArticulosManualmente.ItemSize = new System.Drawing.Size(93, 18);
            this.tabArticulosManualmente.Location = new System.Drawing.Point(0, 0);
            this.tabArticulosManualmente.Name = "tabArticulosManualmente";
            this.tabArticulosManualmente.SelectedIndex = 0;
            this.tabArticulosManualmente.Size = new System.Drawing.Size(792, 397);
            this.tabArticulosManualmente.TabIndex = 153;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox6);
            this.tabPage6.ImageIndex = 6;
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(784, 371);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Cabecera";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbSucursal);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.tbNroNotaPedido);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.butSiguiente);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(784, 104);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nota de Pedido";
            // 
            // cbSucursal
            // 
            this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursal.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbSucursal.Location = new System.Drawing.Point(128, 56);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(208, 21);
            this.cbSucursal.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(128, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Sucursal";
            // 
            // tbNroNotaPedido
            // 
            this.tbNroNotaPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroNotaPedido.Location = new System.Drawing.Point(8, 56);
            this.tbNroNotaPedido.Name = "tbNroNotaPedido";
            this.tbNroNotaPedido.Size = new System.Drawing.Size(104, 20);
            this.tbNroNotaPedido.TabIndex = 1;
            this.tbNroNotaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro. Nota de Pedido";
            // 
            // butSiguiente
            // 
            this.butSiguiente.BackColor = System.Drawing.SystemColors.Control;
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(360, 56);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(96, 24);
            this.butSiguiente.TabIndex = 158;
            this.butSiguiente.Text = "&Continuar";
            this.butSiguiente.UseVisualStyleBackColor = false;
            this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.butBorrarArticulosComponentes);
            this.tabPage7.Controls.Add(this.dgSubArticulos);
            this.tabPage7.Controls.Add(this.groupBox8);
            this.tabPage7.Controls.Add(this.groupBox9);
            this.tabPage7.ImageIndex = 7;
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(784, 371);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Items";
            this.tabPage7.Visible = false;
            // 
            // butBorrarArticulosComponentes
            // 
            this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
            this.butBorrarArticulosComponentes.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarArticulosComponentes.Image")));
            this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(208, 89);
            this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
            this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
            this.butBorrarArticulosComponentes.TabIndex = 155;
            this.butBorrarArticulosComponentes.Text = "&Borrar";
            this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarArticulosComponentes.UseVisualStyleBackColor = false;
            this.butBorrarArticulosComponentes.Click += new System.EventHandler(this.butBorrarArticulosManualmente_Click);
            // 
            // dgSubArticulos
            // 
            this.dgSubArticulos.CaptionBackColor = System.Drawing.Color.MediumBlue;
            this.dgSubArticulos.CaptionForeColor = System.Drawing.Color.White;
            this.dgSubArticulos.CaptionText = "Artículos";
            this.dgSubArticulos.DataMember = "";
            this.dgSubArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSubArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSubArticulos.Location = new System.Drawing.Point(0, 88);
            this.dgSubArticulos.Name = "dgSubArticulos";
            this.dgSubArticulos.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgSubArticulos.Size = new System.Drawing.Size(784, 171);
            this.dgSubArticulos.TabIndex = 157;
            this.dgSubArticulos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsArticulosManualmente});
            // 
            // dgtsArticulosManualmente
            // 
            this.dgtsArticulosManualmente.DataGrid = this.dgSubArticulos;
            this.dgtsArticulosManualmente.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25});
            this.dgtsArticulosManualmente.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsArticulosManualmente.MappingName = "v_Articulo";
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "# Item  .";
            this.dataGridTextBoxColumn19.MappingName = "itemNro";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 50;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "Cod.Interno .";
            this.dataGridTextBoxColumn20.MappingName = "Código Interno";
            this.dataGridTextBoxColumn20.ReadOnly = true;
            this.dataGridTextBoxColumn20.Width = 75;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "Cod.Barras .";
            this.dataGridTextBoxColumn21.MappingName = "Código de Barras";
            this.dataGridTextBoxColumn21.ReadOnly = true;
            this.dataGridTextBoxColumn21.Width = 75;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Cantidad .";
            this.dataGridTextBoxColumn22.MappingName = "Cantidad";
            this.dataGridTextBoxColumn22.Width = 50;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "Rubro";
            this.dataGridTextBoxColumn23.MappingName = "Rubro";
            this.dataGridTextBoxColumn23.ReadOnly = true;
            this.dataGridTextBoxColumn23.Width = 75;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "Sub Rubro";
            this.dataGridTextBoxColumn24.MappingName = "Sub Rubro";
            this.dataGridTextBoxColumn24.ReadOnly = true;
            this.dataGridTextBoxColumn24.Width = 75;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Descripción";
            this.dataGridTextBoxColumn25.MappingName = "Descripción";
            this.dataGridTextBoxColumn25.ReadOnly = true;
            this.dataGridTextBoxColumn25.Width = 300;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.butContinuar2);
            this.groupBox8.Controls.Add(this.butCancelar);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox8.Location = new System.Drawing.Point(0, 259);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(784, 112);
            this.groupBox8.TabIndex = 156;
            this.groupBox8.TabStop = false;
            // 
            // butContinuar2
            // 
            this.butContinuar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butContinuar2.Image = ((System.Drawing.Image)(resources.GetObject("butContinuar2.Image")));
            this.butContinuar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinuar2.Location = new System.Drawing.Point(184, 80);
            this.butContinuar2.Name = "butContinuar2";
            this.butContinuar2.Size = new System.Drawing.Size(144, 23);
            this.butContinuar2.TabIndex = 157;
            this.butContinuar2.Text = "Continuar";
            this.butContinuar2.Click += new System.EventHandler(this.butContinuar2_Click);
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(8, 80);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(120, 24);
            this.butCancelar.TabIndex = 29;
            this.butCancelar.Text = "C&ancelar";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox1);
            this.groupBox9.Controls.Add(this.tbPromocionAC);
            this.groupBox9.Controls.Add(this.tbPrecioAC);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Controls.Add(this.butAgregarArticuloAC);
            this.groupBox9.Controls.Add(this.tbCodigoBarrasAC);
            this.groupBox9.Controls.Add(this.tbID);
            this.groupBox9.Controls.Add(this.label23);
            this.groupBox9.Controls.Add(this.tbCodigoInternoAC);
            this.groupBox9.Controls.Add(this.tbDescripcionAC);
            this.groupBox9.Controls.Add(this.label27);
            this.groupBox9.Controls.Add(this.tbSubRubroAC);
            this.groupBox9.Controls.Add(this.tbRubroAC);
            this.groupBox9.Controls.Add(this.butBuscarArticuloAC);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.tbCantidadAC);
            this.groupBox9.Controls.Add(this.label25);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(784, 88);
            this.groupBox9.TabIndex = 153;
            this.groupBox9.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(704, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(16, 20);
            this.textBox1.TabIndex = 150;
            this.textBox1.Visible = false;
            // 
            // tbPromocionAC
            // 
            this.tbPromocionAC.Location = new System.Drawing.Point(656, 8);
            this.tbPromocionAC.Name = "tbPromocionAC";
            this.tbPromocionAC.Size = new System.Drawing.Size(16, 20);
            this.tbPromocionAC.TabIndex = 149;
            this.tbPromocionAC.Visible = false;
            // 
            // tbPrecioAC
            // 
            this.tbPrecioAC.Location = new System.Drawing.Point(672, 8);
            this.tbPrecioAC.Name = "tbPrecioAC";
            this.tbPrecioAC.Size = new System.Drawing.Size(16, 20);
            this.tbPrecioAC.TabIndex = 148;
            this.tbPrecioAC.Visible = false;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(296, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 16);
            this.label24.TabIndex = 141;
            this.label24.Text = "Rubro";
            // 
            // butAgregarArticuloAC
            // 
            this.butAgregarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butAgregarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butAgregarArticuloAC.Location = new System.Drawing.Point(720, 8);
            this.butAgregarArticuloAC.Name = "butAgregarArticuloAC";
            this.butAgregarArticuloAC.Size = new System.Drawing.Size(24, 24);
            this.butAgregarArticuloAC.TabIndex = 136;
            this.butAgregarArticuloAC.UseVisualStyleBackColor = false;
            this.butAgregarArticuloAC.Visible = false;
            // 
            // tbCodigoBarrasAC
            // 
            this.tbCodigoBarrasAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoBarrasAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoBarrasAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoBarrasAC.Location = new System.Drawing.Point(96, 32);
            this.tbCodigoBarrasAC.Name = "tbCodigoBarrasAC";
            this.tbCodigoBarrasAC.Size = new System.Drawing.Size(88, 21);
            this.tbCodigoBarrasAC.TabIndex = 134;
            this.tbCodigoBarrasAC.Enter += new System.EventHandler(this.tbCodigoBarrasAC_Enter);
            this.tbCodigoBarrasAC.Leave += new System.EventHandler(this.tbCodigoBarrasAC_Leave);
            this.tbCodigoBarrasAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoBarrasAC_KeyPress);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(688, 8);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(16, 20);
            this.tbID.TabIndex = 147;
            this.tbID.Visible = false;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(192, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 16);
            this.label23.TabIndex = 140;
            this.label23.Text = "Cantidad";
            // 
            // tbCodigoInternoAC
            // 
            this.tbCodigoInternoAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoInternoAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoInternoAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoInternoAC.Location = new System.Drawing.Point(8, 32);
            this.tbCodigoInternoAC.Name = "tbCodigoInternoAC";
            this.tbCodigoInternoAC.Size = new System.Drawing.Size(80, 21);
            this.tbCodigoInternoAC.TabIndex = 133;
            this.tbCodigoInternoAC.Enter += new System.EventHandler(this.tbCodigoInternoAC_Enter);
            this.tbCodigoInternoAC.Leave += new System.EventHandler(this.tbCodigoInternoAC_Leave);
            this.tbCodigoInternoAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoInternoAC_KeyPress);
            // 
            // tbDescripcionAC
            // 
            this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcionAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbDescripcionAC.Location = new System.Drawing.Point(536, 32);
            this.tbDescripcionAC.Name = "tbDescripcionAC";
            this.tbDescripcionAC.Size = new System.Drawing.Size(240, 48);
            this.tbDescripcionAC.TabIndex = 146;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(536, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 16);
            this.label27.TabIndex = 143;
            this.label27.Text = "Descripción";
            // 
            // tbSubRubroAC
            // 
            this.tbSubRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSubRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbSubRubroAC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbSubRubroAC.Location = new System.Drawing.Point(416, 32);
            this.tbSubRubroAC.Name = "tbSubRubroAC";
            this.tbSubRubroAC.Size = new System.Drawing.Size(112, 48);
            this.tbSubRubroAC.TabIndex = 145;
            // 
            // tbRubroAC
            // 
            this.tbRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbRubroAC.Location = new System.Drawing.Point(296, 32);
            this.tbRubroAC.Name = "tbRubroAC";
            this.tbRubroAC.Size = new System.Drawing.Size(112, 48);
            this.tbRubroAC.TabIndex = 144;
            // 
            // butBuscarArticuloAC
            // 
            this.butBuscarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarArticuloAC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarArticuloAC.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarArticuloAC.Image")));
            this.butBuscarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butBuscarArticuloAC.Location = new System.Drawing.Point(248, 32);
            this.butBuscarArticuloAC.Name = "butBuscarArticuloAC";
            this.butBuscarArticuloAC.Size = new System.Drawing.Size(24, 24);
            this.butBuscarArticuloAC.TabIndex = 137;
            this.butBuscarArticuloAC.UseVisualStyleBackColor = false;
            this.butBuscarArticuloAC.Enter += new System.EventHandler(this.butBuscarArticuloAC_Enter);
            this.butBuscarArticuloAC.Click += new System.EventHandler(this.butBuscarArticuloAC_Click);
            this.butBuscarArticuloAC.Leave += new System.EventHandler(this.butBuscarArticuloAC_Leave);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 16);
            this.label20.TabIndex = 138;
            this.label20.Text = "Código Interno";
            // 
            // tbCantidadAC
            // 
            this.tbCantidadAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCantidadAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidadAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCantidadAC.Location = new System.Drawing.Point(192, 32);
            this.tbCantidadAC.Name = "tbCantidadAC";
            this.tbCantidadAC.Size = new System.Drawing.Size(48, 21);
            this.tbCantidadAC.TabIndex = 135;
            this.tbCantidadAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCantidadAC.Enter += new System.EventHandler(this.tbCantidadAC_Enter);
            this.tbCantidadAC.Leave += new System.EventHandler(this.tbCantidadAC_Leave);
            this.tbCantidadAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidadAC_KeyPress);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(416, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 16);
            this.label25.TabIndex = 142;
            this.label25.Text = "Sub Rubro";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(96, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 16);
            this.label21.TabIndex = 139;
            this.label21.Text = "Código de Barras";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabConfeccionarRemitos);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Preparar Remitos";
            // 
            // tabConfeccionarRemitos
            // 
            this.tabConfeccionarRemitos.Controls.Add(this.tabPage3);
            this.tabConfeccionarRemitos.Controls.Add(this.tabPage4);
            this.tabConfeccionarRemitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfeccionarRemitos.HotTrack = true;
            this.tabConfeccionarRemitos.ImageList = this.imageList1;
            this.tabConfeccionarRemitos.ItemSize = new System.Drawing.Size(93, 18);
            this.tabConfeccionarRemitos.Location = new System.Drawing.Point(0, 0);
            this.tabConfeccionarRemitos.Name = "tabConfeccionarRemitos";
            this.tabConfeccionarRemitos.SelectedIndex = 0;
            this.tabConfeccionarRemitos.Size = new System.Drawing.Size(792, 397);
            this.tabConfeccionarRemitos.TabIndex = 153;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgArticulosBase);
            this.tabPage3.Controls.Add(this.gbRemitoBase);
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 371);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Artículos Base";
            // 
            // dgArticulosBase
            // 
            this.dgArticulosBase.AllowSorting = false;
            this.dgArticulosBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgArticulosBase.CaptionBackColor = System.Drawing.Color.SlateGray;
            this.dgArticulosBase.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgArticulosBase.CaptionText = "Articulos, Nota de Pedido Nº";
            this.dgArticulosBase.DataMember = "";
            this.dgArticulosBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgArticulosBase.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgArticulosBase.Location = new System.Drawing.Point(0, 152);
            this.dgArticulosBase.Name = "dgArticulosBase";
            this.dgArticulosBase.ReadOnly = true;
            this.dgArticulosBase.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgArticulosBase.Size = new System.Drawing.Size(784, 219);
            this.dgArticulosBase.TabIndex = 15;
            this.dgArticulosBase.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsArticulosBase});
            // 
            // dgtsArticulosBase
            // 
            this.dgtsArticulosBase.DataGrid = this.dgArticulosBase;
            this.dgtsArticulosBase.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn44});
            this.dgtsArticulosBase.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsArticulosBase.MappingName = "v_Articulo";
            this.dgtsArticulosBase.ReadOnly = true;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "# Item  .";
            this.dataGridTextBoxColumn38.MappingName = "itemNro";
            this.dataGridTextBoxColumn38.ReadOnly = true;
            this.dataGridTextBoxColumn38.Width = 50;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "Cod.Interno .";
            this.dataGridTextBoxColumn39.MappingName = "Código Interno";
            this.dataGridTextBoxColumn39.ReadOnly = true;
            this.dataGridTextBoxColumn39.Width = 75;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "Cod.Barras .";
            this.dataGridTextBoxColumn40.MappingName = "Código de Barras";
            this.dataGridTextBoxColumn40.ReadOnly = true;
            this.dataGridTextBoxColumn40.Width = 75;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "Cantidad .";
            this.dataGridTextBoxColumn41.MappingName = "Cantidad";
            this.dataGridTextBoxColumn41.ReadOnly = true;
            this.dataGridTextBoxColumn41.Width = 50;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "Rubro";
            this.dataGridTextBoxColumn42.MappingName = "Rubro";
            this.dataGridTextBoxColumn42.ReadOnly = true;
            this.dataGridTextBoxColumn42.Width = 75;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "Sub Rubro";
            this.dataGridTextBoxColumn43.MappingName = "Sub Rubro";
            this.dataGridTextBoxColumn43.ReadOnly = true;
            this.dataGridTextBoxColumn43.Width = 75;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "Descripción";
            this.dataGridTextBoxColumn44.MappingName = "Descripción";
            this.dataGridTextBoxColumn44.ReadOnly = true;
            this.dataGridTextBoxColumn44.Width = 300;
            // 
            // gbRemitoBase
            // 
            this.gbRemitoBase.Controls.Add(this.tbFacturaNro);
            this.gbRemitoBase.Controls.Add(this.tbFacturaSuc);
            this.gbRemitoBase.Controls.Add(this.label30);
            this.gbRemitoBase.Controls.Add(this.cbRBSucursal);
            this.gbRemitoBase.Controls.Add(this.label28);
            this.gbRemitoBase.Controls.Add(this.butCerrar);
            this.gbRemitoBase.Controls.Add(this.cbRBProvincia);
            this.gbRemitoBase.Controls.Add(this.label17);
            this.gbRemitoBase.Controls.Add(this.cbRBLocalidad);
            this.gbRemitoBase.Controls.Add(this.label16);
            this.gbRemitoBase.Controls.Add(this.chkRBMostrarTodosFletes);
            this.gbRemitoBase.Controls.Add(this.chkRBRegaloEmpresario);
            this.gbRemitoBase.Controls.Add(this.tbRBObsequiante);
            this.gbRemitoBase.Controls.Add(this.tbRBBultos);
            this.gbRemitoBase.Controls.Add(this.label11);
            this.gbRemitoBase.Controls.Add(this.label12);
            this.gbRemitoBase.Controls.Add(this.cbRBFlete);
            this.gbRemitoBase.Controls.Add(this.cbRBZona);
            this.gbRemitoBase.Controls.Add(this.label13);
            this.gbRemitoBase.Controls.Add(this.label14);
            this.gbRemitoBase.Controls.Add(this.tbRBDireccionDestinatario);
            this.gbRemitoBase.Controls.Add(this.label2);
            this.gbRemitoBase.Controls.Add(this.tbRBNombreDestinatario);
            this.gbRemitoBase.Controls.Add(this.label5);
            this.gbRemitoBase.Controls.Add(this.tbRemitoBaseID);
            this.gbRemitoBase.Controls.Add(this.butNuevoRemito);
            this.gbRemitoBase.Controls.Add(this.tbNotaPedidoID);
            this.gbRemitoBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRemitoBase.Location = new System.Drawing.Point(0, 0);
            this.gbRemitoBase.Name = "gbRemitoBase";
            this.gbRemitoBase.Size = new System.Drawing.Size(784, 152);
            this.gbRemitoBase.TabIndex = 155;
            this.gbRemitoBase.TabStop = false;
            this.gbRemitoBase.Enter += new System.EventHandler(this.gbRemitoBase_Enter);
            // 
            // tbFacturaNro
            // 
            this.tbFacturaNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaNro.Location = new System.Drawing.Point(650, 67);
            this.tbFacturaNro.Name = "tbFacturaNro";
            this.tbFacturaNro.Size = new System.Drawing.Size(128, 20);
            this.tbFacturaNro.TabIndex = 8;
            this.tbFacturaNro.Validated += new System.EventHandler(this.tbFacturaNro_Validated);
            this.tbFacturaNro.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbFacturaSuc
            // 
            this.tbFacturaSuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaSuc.Enabled = false;
            this.tbFacturaSuc.Location = new System.Drawing.Point(594, 67);
            this.tbFacturaSuc.Name = "tbFacturaSuc";
            this.tbFacturaSuc.Size = new System.Drawing.Size(56, 20);
            this.tbFacturaSuc.TabIndex = 7;
            this.tbFacturaSuc.Validated += new System.EventHandler(this.tbFacturaSuc_Validated);
            this.tbFacturaSuc.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(533, 67);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 16);
            this.label30.TabIndex = 152;
            this.label30.Text = "Factura Nº";
            // 
            // cbRBSucursal
            // 
            this.cbRBSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRBSucursal.Location = new System.Drawing.Point(256, 120);
            this.cbRBSucursal.Name = "cbRBSucursal";
            this.cbRBSucursal.Size = new System.Drawing.Size(271, 21);
            this.cbRBSucursal.TabIndex = 12;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(256, 104);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 16);
            this.label28.TabIndex = 151;
            this.label28.Text = "Sucursal";
            // 
            // butCerrar
            // 
            this.butCerrar.Enabled = false;
            this.butCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCerrar.Image = ((System.Drawing.Image)(resources.GetObject("butCerrar.Image")));
            this.butCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCerrar.Location = new System.Drawing.Point(680, 120);
            this.butCerrar.Name = "butCerrar";
            this.butCerrar.Size = new System.Drawing.Size(93, 24);
            this.butCerrar.TabIndex = 14;
            this.butCerrar.Text = "Cerrar";
            this.butCerrar.Click += new System.EventHandler(this.butCerrar_Click);
            // 
            // cbRBProvincia
            // 
            this.cbRBProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRBProvincia.Enabled = false;
            this.cbRBProvincia.Location = new System.Drawing.Point(593, 43);
            this.cbRBProvincia.Name = "cbRBProvincia";
            this.cbRBProvincia.Size = new System.Drawing.Size(185, 21);
            this.cbRBProvincia.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(533, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 16);
            this.label17.TabIndex = 147;
            this.label17.Text = "Provincia";
            // 
            // cbRBLocalidad
            // 
            this.cbRBLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRBLocalidad.Enabled = false;
            this.cbRBLocalidad.Location = new System.Drawing.Point(593, 16);
            this.cbRBLocalidad.Name = "cbRBLocalidad";
            this.cbRBLocalidad.Size = new System.Drawing.Size(185, 21);
            this.cbRBLocalidad.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(533, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 16);
            this.label16.TabIndex = 145;
            this.label16.Text = "Localidad";
            // 
            // chkRBMostrarTodosFletes
            // 
            this.chkRBMostrarTodosFletes.Location = new System.Drawing.Point(152, 102);
            this.chkRBMostrarTodosFletes.Name = "chkRBMostrarTodosFletes";
            this.chkRBMostrarTodosFletes.Size = new System.Drawing.Size(96, 16);
            this.chkRBMostrarTodosFletes.TabIndex = 11;
            this.chkRBMostrarTodosFletes.Text = "Mostrar Todos";
            this.chkRBMostrarTodosFletes.CheckedChanged += new System.EventHandler(this.chkRBMostrarTodosFletes_CheckedChanged);
            // 
            // chkRBRegaloEmpresario
            // 
            this.chkRBRegaloEmpresario.Location = new System.Drawing.Point(8, 80);
            this.chkRBRegaloEmpresario.Name = "chkRBRegaloEmpresario";
            this.chkRBRegaloEmpresario.Size = new System.Drawing.Size(147, 16);
            this.chkRBRegaloEmpresario.TabIndex = 4;
            this.chkRBRegaloEmpresario.Text = "Regalo Empresario";
            this.chkRBRegaloEmpresario.Visible = false;
            // 
            // tbRBObsequiante
            // 
            this.tbRBObsequiante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRBObsequiante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRBObsequiante.Location = new System.Drawing.Point(256, 77);
            this.tbRBObsequiante.Name = "tbRBObsequiante";
            this.tbRBObsequiante.Size = new System.Drawing.Size(271, 20);
            this.tbRBObsequiante.TabIndex = 6;
            // 
            // tbRBBultos
            // 
            this.tbRBBultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRBBultos.Location = new System.Drawing.Point(184, 76);
            this.tbRBBultos.Name = "tbRBBultos";
            this.tbRBBultos.Size = new System.Drawing.Size(64, 20);
            this.tbRBBultos.TabIndex = 5;
            this.tbRBBultos.Text = "1";
            this.tbRBBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(181, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 139;
            this.label11.Text = "Bultos";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(256, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 16);
            this.label12.TabIndex = 138;
            this.label12.Text = "Obsequiante";
            // 
            // cbRBFlete
            // 
            this.cbRBFlete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRBFlete.Location = new System.Drawing.Point(118, 120);
            this.cbRBFlete.Name = "cbRBFlete";
            this.cbRBFlete.Size = new System.Drawing.Size(130, 21);
            this.cbRBFlete.TabIndex = 10;
            // 
            // cbRBZona
            // 
            this.cbRBZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRBZona.Location = new System.Drawing.Point(8, 120);
            this.cbRBZona.Name = "cbRBZona";
            this.cbRBZona.Size = new System.Drawing.Size(104, 21);
            this.cbRBZona.TabIndex = 9;
            this.cbRBZona.SelectedIndexChanged += new System.EventHandler(this.cbRBZona_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(118, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 16);
            this.label13.TabIndex = 135;
            this.label13.Text = "Flete";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 134;
            this.label14.Text = "Zona";
            // 
            // tbRBDireccionDestinatario
            // 
            this.tbRBDireccionDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRBDireccionDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRBDireccionDestinatario.Location = new System.Drawing.Point(256, 32);
            this.tbRBDireccionDestinatario.MaxLength = 63;
            this.tbRBDireccionDestinatario.Name = "tbRBDireccionDestinatario";
            this.tbRBDireccionDestinatario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRBDireccionDestinatario.Size = new System.Drawing.Size(271, 20);
            this.tbRBDireccionDestinatario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(256, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 128;
            this.label2.Text = "Dirección de Entrega";
            // 
            // tbRBNombreDestinatario
            // 
            this.tbRBNombreDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRBNombreDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRBNombreDestinatario.Location = new System.Drawing.Point(8, 32);
            this.tbRBNombreDestinatario.MaxLength = 50;
            this.tbRBNombreDestinatario.Name = "tbRBNombreDestinatario";
            this.tbRBNombreDestinatario.Size = new System.Drawing.Size(240, 20);
            this.tbRBNombreDestinatario.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 126;
            this.label5.Text = "Destinatario";
            // 
            // tbRemitoBaseID
            // 
            this.tbRemitoBaseID.Location = new System.Drawing.Point(712, 8);
            this.tbRemitoBaseID.Name = "tbRemitoBaseID";
            this.tbRemitoBaseID.Size = new System.Drawing.Size(16, 20);
            this.tbRemitoBaseID.TabIndex = 118;
            this.tbRemitoBaseID.Visible = false;
            // 
            // butNuevoRemito
            // 
            this.butNuevoRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butNuevoRemito.Image = ((System.Drawing.Image)(resources.GetObject("butNuevoRemito.Image")));
            this.butNuevoRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNuevoRemito.Location = new System.Drawing.Point(536, 120);
            this.butNuevoRemito.Name = "butNuevoRemito";
            this.butNuevoRemito.Size = new System.Drawing.Size(120, 24);
            this.butNuevoRemito.TabIndex = 13;
            this.butNuevoRemito.Text = "&Nuevo Remito";
            this.butNuevoRemito.Click += new System.EventHandler(this.butNuevoRemito_Click);
            // 
            // tbNotaPedidoID
            // 
            this.tbNotaPedidoID.Location = new System.Drawing.Point(680, 8);
            this.tbNotaPedidoID.Name = "tbNotaPedidoID";
            this.tbNotaPedidoID.Size = new System.Drawing.Size(16, 20);
            this.tbNotaPedidoID.TabIndex = 117;
            this.tbNotaPedidoID.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chkSeleccionarTodo);
            this.tabPage4.Controls.Add(this.dgArticulosNuevoRemito);
            this.tabPage4.Controls.Add(this.gbNuevoRemito);
            this.tabPage4.ImageIndex = 1;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(784, 371);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Remito";
            this.tabPage4.Visible = false;
            // 
            // chkSeleccionarTodo
            // 
            this.chkSeleccionarTodo.BackColor = System.Drawing.Color.YellowGreen;
            this.chkSeleccionarTodo.Checked = true;
            this.chkSeleccionarTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeleccionarTodo.Location = new System.Drawing.Point(128, 155);
            this.chkSeleccionarTodo.Name = "chkSeleccionarTodo";
            this.chkSeleccionarTodo.Size = new System.Drawing.Size(120, 15);
            this.chkSeleccionarTodo.TabIndex = 155;
            this.chkSeleccionarTodo.Text = "Seleccionar Todo";
            this.chkSeleccionarTodo.UseVisualStyleBackColor = false;
            this.chkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodo_CheckedChanged);
            // 
            // dgArticulosNuevoRemito
            // 
            this.dgArticulosNuevoRemito.CaptionBackColor = System.Drawing.Color.YellowGreen;
            this.dgArticulosNuevoRemito.CaptionText = "Nuevo Remito";
            this.dgArticulosNuevoRemito.DataMember = "";
            this.dgArticulosNuevoRemito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgArticulosNuevoRemito.Enabled = false;
            this.dgArticulosNuevoRemito.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgArticulosNuevoRemito.Location = new System.Drawing.Point(0, 152);
            this.dgArticulosNuevoRemito.Name = "dgArticulosNuevoRemito";
            this.dgArticulosNuevoRemito.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgArticulosNuevoRemito.Size = new System.Drawing.Size(784, 219);
            this.dgArticulosNuevoRemito.TabIndex = 154;
            this.dgArticulosNuevoRemito.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsRemitoArticulos});
            this.dgArticulosNuevoRemito.CurrentCellChanged += new System.EventHandler(this.dgArticulosNuevoRemito_CurrentCellChanged);
            // 
            // dgtsRemitoArticulos
            // 
            this.dgtsRemitoArticulos.AllowSorting = false;
            this.dgtsRemitoArticulos.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgtsRemitoArticulos.DataGrid = this.dgArticulosNuevoRemito;
            this.dgtsRemitoArticulos.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32});
            this.dgtsRemitoArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsRemitoArticulos.MappingName = "v_Articulo";
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.MappingName = "itemSeleccionado";
            this.dataGridBoolColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "# Item  .";
            this.dataGridTextBoxColumn26.MappingName = "itemNro";
            this.dataGridTextBoxColumn26.ReadOnly = true;
            this.dataGridTextBoxColumn26.Width = 50;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Cod.Interno .";
            this.dataGridTextBoxColumn27.MappingName = "Código Interno";
            this.dataGridTextBoxColumn27.ReadOnly = true;
            this.dataGridTextBoxColumn27.Width = 75;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "Cod.Barras .";
            this.dataGridTextBoxColumn28.MappingName = "Código de Barras";
            this.dataGridTextBoxColumn28.ReadOnly = true;
            this.dataGridTextBoxColumn28.Width = 75;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Cantidad .";
            this.dataGridTextBoxColumn29.MappingName = "Cantidad";
            this.dataGridTextBoxColumn29.Width = 60;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "Rubro";
            this.dataGridTextBoxColumn30.MappingName = "Rubro";
            this.dataGridTextBoxColumn30.ReadOnly = true;
            this.dataGridTextBoxColumn30.Width = 75;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "Sub Rubro";
            this.dataGridTextBoxColumn31.MappingName = "Sub Rubro";
            this.dataGridTextBoxColumn31.ReadOnly = true;
            this.dataGridTextBoxColumn31.Width = 75;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "Descripción";
            this.dataGridTextBoxColumn32.MappingName = "Descripción";
            this.dataGridTextBoxColumn32.ReadOnly = true;
            this.dataGridTextBoxColumn32.Width = 300;
            // 
            // gbNuevoRemito
            // 
            this.gbNuevoRemito.Controls.Add(this.cbRSucursal);
            this.gbNuevoRemito.Controls.Add(this.label29);
            this.gbNuevoRemito.Controls.Add(this.butCancelarRemito);
            this.gbNuevoRemito.Controls.Add(this.cbProvincia);
            this.gbNuevoRemito.Controls.Add(this.label19);
            this.gbNuevoRemito.Controls.Add(this.cbLocalidad);
            this.gbNuevoRemito.Controls.Add(this.label15);
            this.gbNuevoRemito.Controls.Add(this.chkMostrarTodosFletes);
            this.gbNuevoRemito.Controls.Add(this.tbBultos);
            this.gbNuevoRemito.Controls.Add(this.tbObsequiante);
            this.gbNuevoRemito.Controls.Add(this.label10);
            this.gbNuevoRemito.Controls.Add(this.label9);
            this.gbNuevoRemito.Controls.Add(this.cbFlete);
            this.gbNuevoRemito.Controls.Add(this.cbZona);
            this.gbNuevoRemito.Controls.Add(this.label8);
            this.gbNuevoRemito.Controls.Add(this.label6);
            this.gbNuevoRemito.Controls.Add(this.tbDireccionDestinatario);
            this.gbNuevoRemito.Controls.Add(this.label4);
            this.gbNuevoRemito.Controls.Add(this.tbNombreDestinatario);
            this.gbNuevoRemito.Controls.Add(this.label3);
            this.gbNuevoRemito.Controls.Add(this.tbNuevoRemitoID);
            this.gbNuevoRemito.Controls.Add(this.butGuardarRemito);
            this.gbNuevoRemito.Controls.Add(this.butImprimirRemito);
            this.gbNuevoRemito.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNuevoRemito.Location = new System.Drawing.Point(0, 0);
            this.gbNuevoRemito.Name = "gbNuevoRemito";
            this.gbNuevoRemito.Size = new System.Drawing.Size(784, 152);
            this.gbNuevoRemito.TabIndex = 153;
            this.gbNuevoRemito.TabStop = false;
            // 
            // cbRSucursal
            // 
            this.cbRSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRSucursal.Location = new System.Drawing.Point(256, 120);
            this.cbRSucursal.Name = "cbRSucursal";
            this.cbRSucursal.Size = new System.Drawing.Size(271, 21);
            this.cbRSucursal.TabIndex = 10;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(256, 104);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(104, 16);
            this.label29.TabIndex = 153;
            this.label29.Text = "Sucursal";
            // 
            // butCancelarRemito
            // 
            this.butCancelarRemito.Enabled = false;
            this.butCancelarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelarRemito.Image = ((System.Drawing.Image)(resources.GetObject("butCancelarRemito.Image")));
            this.butCancelarRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelarRemito.Location = new System.Drawing.Point(746, 118);
            this.butCancelarRemito.Name = "butCancelarRemito";
            this.butCancelarRemito.Size = new System.Drawing.Size(28, 24);
            this.butCancelarRemito.TabIndex = 13;
            this.butCancelarRemito.Click += new System.EventHandler(this.butCancelarRemito_Click);
            // 
            // cbProvincia
            // 
            this.cbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProvincia.Location = new System.Drawing.Point(534, 80);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(240, 21);
            this.cbProvincia.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(534, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 16);
            this.label19.TabIndex = 145;
            this.label19.Text = "Provincia";
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLocalidad.Location = new System.Drawing.Point(534, 32);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(240, 21);
            this.cbLocalidad.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(534, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 16);
            this.label15.TabIndex = 143;
            this.label15.Text = "Localidad";
            // 
            // chkMostrarTodosFletes
            // 
            this.chkMostrarTodosFletes.Location = new System.Drawing.Point(152, 104);
            this.chkMostrarTodosFletes.Name = "chkMostrarTodosFletes";
            this.chkMostrarTodosFletes.Size = new System.Drawing.Size(96, 16);
            this.chkMostrarTodosFletes.TabIndex = 8;
            this.chkMostrarTodosFletes.Text = "Mostrar Todos";
            this.chkMostrarTodosFletes.CheckedChanged += new System.EventHandler(this.chkMostrarTodosFletes_CheckedChanged);
            // 
            // tbBultos
            // 
            this.tbBultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBultos.Location = new System.Drawing.Point(8, 80);
            this.tbBultos.Name = "tbBultos";
            this.tbBultos.Size = new System.Drawing.Size(64, 20);
            this.tbBultos.TabIndex = 4;
            // 
            // tbObsequiante
            // 
            this.tbObsequiante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObsequiante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObsequiante.Location = new System.Drawing.Point(256, 80);
            this.tbObsequiante.Name = "tbObsequiante";
            this.tbObsequiante.Size = new System.Drawing.Size(272, 20);
            this.tbObsequiante.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 131;
            this.label10.Text = "Bultos";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(256, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 130;
            this.label9.Text = "Obsequiante";
            // 
            // cbFlete
            // 
            this.cbFlete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFlete.Location = new System.Drawing.Point(118, 120);
            this.cbFlete.Name = "cbFlete";
            this.cbFlete.Size = new System.Drawing.Size(130, 21);
            this.cbFlete.TabIndex = 9;
            // 
            // cbZona
            // 
            this.cbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZona.Location = new System.Drawing.Point(8, 120);
            this.cbZona.Name = "cbZona";
            this.cbZona.Size = new System.Drawing.Size(104, 21);
            this.cbZona.TabIndex = 7;
            this.cbZona.SelectedIndexChanged += new System.EventHandler(this.cbZona_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(118, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 127;
            this.label8.Text = "Flete";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 126;
            this.label6.Text = "Zona";
            // 
            // tbDireccionDestinatario
            // 
            this.tbDireccionDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccionDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDireccionDestinatario.Location = new System.Drawing.Point(256, 32);
            this.tbDireccionDestinatario.MaxLength = 63;
            this.tbDireccionDestinatario.Name = "tbDireccionDestinatario";
            this.tbDireccionDestinatario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDireccionDestinatario.Size = new System.Drawing.Size(272, 20);
            this.tbDireccionDestinatario.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(256, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 16);
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
            this.tbNombreDestinatario.Size = new System.Drawing.Size(240, 20);
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
            // tbNuevoRemitoID
            // 
            this.tbNuevoRemitoID.Location = new System.Drawing.Point(760, 8);
            this.tbNuevoRemitoID.Name = "tbNuevoRemitoID";
            this.tbNuevoRemitoID.Size = new System.Drawing.Size(16, 20);
            this.tbNuevoRemitoID.TabIndex = 119;
            this.tbNuevoRemitoID.Visible = false;
            // 
            // butGuardarRemito
            // 
            this.butGuardarRemito.Enabled = false;
            this.butGuardarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGuardarRemito.Image = ((System.Drawing.Image)(resources.GetObject("butGuardarRemito.Image")));
            this.butGuardarRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGuardarRemito.Location = new System.Drawing.Point(534, 118);
            this.butGuardarRemito.Name = "butGuardarRemito";
            this.butGuardarRemito.Size = new System.Drawing.Size(100, 24);
            this.butGuardarRemito.TabIndex = 11;
            this.butGuardarRemito.Text = "&Suspender";
            this.butGuardarRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butGuardarRemito.Click += new System.EventHandler(this.butGuardarRemito_Click);
            // 
            // butImprimirRemito
            // 
            this.butImprimirRemito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirRemito.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirRemito.Image")));
            this.butImprimirRemito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirRemito.Location = new System.Drawing.Point(640, 118);
            this.butImprimirRemito.Name = "butImprimirRemito";
            this.butImprimirRemito.Size = new System.Drawing.Size(100, 24);
            this.butImprimirRemito.TabIndex = 12;
            this.butImprimirRemito.Text = "&Imprimir Remito";
            this.butImprimirRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimirRemito.Click += new System.EventHandler(this.butImprimirRemito_Click);
            // 
            // ucRemitoAlta
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label18);
            this.Name = "ucRemitoAlta";
            this.Size = new System.Drawing.Size(800, 456);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabFiltro1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbProveedor.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabArticulosManualmente.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabConfeccionarRemitos.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulosBase)).EndInit();
            this.gbRemitoBase.ResumeLayout(false);
            this.gbRemitoBase.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulosNuevoRemito)).EndInit();
            this.gbNuevoRemito.ResumeLayout(false);
            this.gbNuevoRemito.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		
		
		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				//Inicializa los tbID
				tbNotaPedidoID.Text = Utilidades.ID_VACIO;;
				tbNotaPedidoIDB.Text = Utilidades.ID_VACIO;
				tbNuevoRemitoID.Text = Utilidades.ID_VACIO;
				tbRemitoBaseID.Text = Utilidades.ID_VACIO;
				//Llena los combos
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
				UtilUI.llenarCombo(ref cbVendedorB, this.conexion, "sp_getAllVendedorsBySucursal", "Todos", 0, param);
				UtilUI.llenarCombo(ref cbEstadoB, this.conexion, "sp_getAlltv_NotaPedidoEstados", "Todos", 0);
				UtilUI.llenarCombo(ref cbCondicionEntregaB, this.conexion, "sp_getAlltv_NotaPedidoCondicionEntrega", "Todas", 0);
				acomodarCombosOrden();

                //Zonas
                UtilUI.llenarCombo(ref cbRBZona, this.conexion, "sp_getAllZonas", "", -1);
                UtilUI.llenarCombo(ref cbZona, this.conexion, "sp_getAllZonas", "", -1);

                //Localidad y Provincia
                UtilUI.llenarCombo(ref cbRBLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
                UtilUI.llenarCombo(ref cbLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
                UtilUI.llenarCombo(ref cbRBProvincia, this.conexion, "sp_getAllProvincias", "", -1);
                UtilUI.llenarCombo(ref cbProvincia, this.conexion, "sp_getAllProvincias", "", -1);

                //Sucursales
                UtilUI.llenarCombo(ref cbRBSucursal, this.conexion, "sp_getAllSucursals", "", -1);
                UtilUI.llenarCombo(ref cbRSucursal, this.conexion, "sp_getAllSucursals", "", -1);
                //Selecciona la sucursal por defecto.
                cbRBSucursal.SelectedValue = configuracion.sucursal.id;
                

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
				dgArticulosBase.DataSource = (DataTable)datasetRemitoBase.Tables["v_Articulo"];
				dgArticulosNuevoRemito.DataSource = (DataTable)datasetRemito.Tables["v_Articulo"];
				dgSubArticulos.DataSource = (DataTable)datasetArticulosManualmente.Tables["v_Articulo"];

				//Establece el tab inicial
				//tabNotaPedido.SelectedIndex = 1;

				//Desactiva los controles del remito
                utilRemito.activarControlesRemito(this.configuracion, ref gbNuevoRemito, ref dgArticulosNuevoRemito, false);

				//Desactiva los controles del remito base
                utilRemito.activarControlesRemitoBase(this.configuracion, ref gbRemitoBase, ref dgArticulosBase, false);

				//Carga las sucursales
				UtilUI.llenarCombo(ref cbSucursal, this.conexion, "sp_getAllSucursals", "", -1);

                //Asigna los eventos a la grilla para evitar la tecla DEL
                asignarEventosGrilla(ref dgSubArticulos);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 12;  //Nro., descendente
				rbDesc1.Checked = true;
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
	

		private void butBorrarArticulosComponentes_Click(object sender, System.EventArgs e)
		{
			borrarRegistrosArticulosComponentes();
		}

		private void borrarRegistrosArticulosComponentes()
		{
			/*if (dgSubArticulos.DataSource!=null)
			{
				DataTable dt = (DataTable)dgSubArticulos.DataSource;
				
				if (dt.Rows.Count>0)
				{
					//Primero recorre los renglones seleccionados
					string sRows = "";
					string coma = "";
					for (int i=0; i<dt.Rows.Count; i++)
					{
						if (dgSubArticulos.IsSelected(i))
						{
							sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
							coma = ",";
						}
					}

					if (sRows!="")
					{
						DialogResult dr = MessageBox.Show("¿Desea borrar los Artículos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (dr== DialogResult.Yes)
						{
							UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Artículos...", true);
							string[] rows = sRows.Split(",".ToCharArray());
							for (int j=0; j<rows.Length; j++)
							{
								string id = rows[j].Split(":".ToCharArray())[0];
								int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

								//dt.Rows[renglon].Delete();
								dt.Rows[renglon]["id"] = "-1";
							}
							//Recorre los renglones marcados para borrar
							DataRow[] rowsBorrar = dt.Select("id='-1'");
							for (int k=0; k<rowsBorrar.Length; k++)
							{
								rowsBorrar[k].Delete();
							}
							dt.AcceptChanges();

							//Renumera los items
							renumerarItems();

							dgSubArticulos.Refresh();
							UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
						}
					}
				}
			}*/
		}

		//Renumera los items de la Tabla
		private void renumerarItems()
		{
			try
			{
				DataTable dt = (DataTable)dgArticulosNuevoRemito.DataSource;

				int item=0;
				for (int i=0; i<dt.Rows.Count; i++)
				{
					string itemSeleccionado = dt.Rows[i]["itemSeleccionado"].ToString();
					if (itemSeleccionado!="")
						if (bool.Parse(itemSeleccionado))
						{
							int cantRemito = int.Parse(dt.Rows[i]["Cantidad"].ToString());
							//Deselecciona el item si la cantidad es cero
							if (cantRemito==0)
							{
								dt.Rows[i]["itemSeleccionado"] = false;
								dt.Rows[i]["itemNro"] = 0;
							}
							else
							{
								item++;
								dt.Rows[i]["itemNro"] = item;
							}
						}
						else
							dt.Rows[i]["itemNro"] = 0;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Ingreso de Mercadería...", true);
				if (validarFormulario())
					darAlta();
				else
					UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private bool validarFormulario()
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
							}*/
				/*if (((DataTable)dgSubArticulos.DataSource).Rows.Count==0)
				{
					mensaje += "   - Debe ingresar al menos un Artículo.\r\n";
					resultado = false;
				}*/


				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Ingreso de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Inserta un nuevo registro en la base de datos
		private void darAlta()
		{
			//Obtiene los valores a insertar
			/*string proveedorID = "";
			string sucursalOrigenID = "";
			string nroRemito1 = tbNroRemito1.Text;
			string nroRemito2 = tbNroRemito2.Text;
			DateTime fecha = dtpFechaRemito.Value;
			string observaciones = tbObservaciones.Text;
			string usuarioID = "0";  //Modificar
			string sucursalDestinoID = "0"; //Modificar

			string origenID = "";
			if (rbProveedor.Checked)
			{
				origenID = "1"; //Proveedor
				proveedorID = tbProveedorID.Text=="" ? "0" : tbProveedorID.Text;
				sucursalOrigenID = "0";
			}
			if (rbSucursal.Checked)
			{
				origenID = "2"; //Sucursal
				proveedorID = "0";
				sucursalOrigenID = cbSucursal.SelectedValue.ToString();
			}
			if (rbDevolucion.Checked)
			{
				origenID = "3"; //Devolucion
				proveedorID = "0";
				sucursalOrigenID = "0";
			}
			
			SqlParameter[] param = new SqlParameter[9];
			
			param[0] = new SqlParameter("@proveedorID", proveedorID);
			param[1] = new SqlParameter("@sucursalOrigenID", sucursalOrigenID);
			param[2] = new SqlParameter("@nroRemito1", nroRemito1);
			param[3] = new SqlParameter("@nroRemito2", nroRemito2);
			param[4] = new SqlParameter("@usuarioID", usuarioID);
			param[5] = new SqlParameter("@fecha", fecha);
			param[6] = new SqlParameter("@origenID", origenID);
			param[7] = new SqlParameter("@sucursalDestinoID", sucursalDestinoID);
			param[8] = new SqlParameter("@observaciones", observaciones);
			
			while (true)
			{
				try 
				{
					//Inserta el registro y obtiene el ID
					SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoMercaderiaIngresada", param);
					
					//Inserta los articulos
					if (dr.HasRows)
					{
						dr.Read();
						string mercaderiaIngresadaID = dr["ID"].ToString();
						string articuloID = "0";
						string cantidad = "0";

						DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
						for (int i=0; i<dtSubArticulos.Rows.Count; i++)
						{
							cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
							if (cantidad.Trim()!="")
							{
								articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
								param = new SqlParameter[3];
								param[0] = new SqlParameter("@mercaderiaIngresadaID", mercaderiaIngresadaID);
								param[1] = new SqlParameter("@articuloID", articuloID);
								param[2] = new SqlParameter("@cantidad", cantidad);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertMercaderiaIngresadaLinea", param);
							}
						}
					}
					dr.Close();

					MessageBox.Show("Mercadería Ingresada con éxito.", "Ingreso de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Information);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Mercadería Ingresada con éxito.", false);

					//Limpia el formulario
					limpiarFormulario();

					break;
				}
				catch (Exception e)
				{
					DialogResult dr = MessageBox.Show("No se pudo ingresar la Mercadería. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar la Mercadería. \r\n" + e.Message, false);
					if (dr != DialogResult.Retry)
						break;
				}
			}*/
		}

		private void limpiarFormulario()
		{
			/*((DataTable)dgSubArticulos.DataSource).Rows.Clear();
			tbNroRemito1.Text = "";
			tbNroRemito2.Text = "";
			tbObservaciones.Text = "";
			tbCodigoBarrasAC.Text = "";
			tbCodigoInternoAC.Text = "";
			tbCantidadAC.Text = "";
			tabControl1.SelectedIndex = 0;*/
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}



		
		private void dgSubArticulos_CurrentCellChanged(object sender, System.EventArgs e)
		{
		
		}

		private void butSuspender_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Nota de Pedido...", true);
				if (validarFormularioCabecera())
				{
					guardarNotaPedido(1);  //Estado: suspendida.
					//Cierra la ventana, pues la suspencion lo produce
					((Form)this.ParentForm).Close();
				}
				else
					UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
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

		//Guarda la Nota de Pedido con el estado que se le indique.
		private void guardarNotaPedido(int estado)
		{
			/*
			//Obtiene los valores
			DateTime fecha_creacion = DateTime.Now;
			string clienteID = tbClienteID.Text;
			string nombreCliente = tbClienteNombre.Text;
			string ivaIDCliente = cbIVA.SelectedValue.ToString();
			string direccionCliente = tbDireccion.Text;
			string cuitCliente = tbCUIT.Text;
			string direccionEntrega = tbDireccionEntrega.Text;
			string vendedorID = cbVendedor.SelectedValue.ToString();
			string condicionEntregaID = cbCondicionEntrega.Text;
			condicionEntregaID = condicionEntregaID=="Inmediata" ? "1" : "2";
			double bonificacion = double.Parse(tbBonificacion.Text);
			string autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
			double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
			double iva1 = double.Parse(lblIva1.Text, NumberStyles.Currency);
			double iva2 = double.Parse(lblIva2.Text, NumberStyles.Currency);
			double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
			string estadoNotaPedidoID = estado.ToString();
			string maquinaID = "1";  //OJO!!!!!!!!!!
			double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
			double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);

			SqlParameter[] param = new SqlParameter[19];
			
			param[0] = new SqlParameter("@fecha_creacion", fecha_creacion);
			param[1] = new SqlParameter("@clienteID", clienteID);
			param[2] = new SqlParameter("@nombreCliente", nombreCliente);
			param[3] = new SqlParameter("@ivaIDCliente", ivaIDCliente);
			param[4] = new SqlParameter("@direccionCliente", direccionCliente);
			param[5] = new SqlParameter("@cuitCliente", cuitCliente);
			param[6] = new SqlParameter("@direccionEntrega", direccionEntrega);
			param[7] = new SqlParameter("@vendedorID", vendedorID);
			param[8] = new SqlParameter("@condicionEntregaID", condicionEntregaID);
			param[9] = new SqlParameter("@bonificacion", bonificacion);
			param[10] = new SqlParameter("@autorizadorBonificacionID", autorizadorBonificacionID);
			param[11] = new SqlParameter("@subTotal1", subTotal1);
			param[12] = new SqlParameter("@iva1", iva1);
			param[13] = new SqlParameter("@iva2", iva2);
			param[14] = new SqlParameter("@total", total);
			param[15] = new SqlParameter("@estadoNotaPedidoID", estadoNotaPedidoID);
			param[16] = new SqlParameter("@maquinaID", maquinaID);
			param[17] = new SqlParameter("@subTotal2", subTotal2);
			param[18] = new SqlParameter("@bonificacionImporte", bonificacionImporte);

			while (true)
			{
				try 
				{
					//Inserta el registro y obtiene el ID
					SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevaNotaPedido", param);
					
					//Inserta los articulos
					if (dr.HasRows)
					{
						dr.Read();
						int notaPedidoID = int.Parse(dr["ID"].ToString());
						int articuloID = 0;
						string cantidad = "0";
						double descuento = 0;
						int itemNro = 0;
						string aplicaPromocion = "2";
						double precioTotal = 0;
						double precioTotalConDesc = 0;
						double precioUnitario = 0;

						DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
						for (int i=0; i<dtSubArticulos.Rows.Count; i++)
						{
							cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
							if (cantidad.Trim()!="")
							{
								articuloID = int.Parse(dtSubArticulos.Rows[i]["articuloID"].ToString());
								descuento = double.Parse(dtSubArticulos.Rows[i]["descuento"].ToString(), NumberStyles.Any);
								itemNro = int.Parse(dtSubArticulos.Rows[i]["itemNro"].ToString());
								aplicaPromocion = dtSubArticulos.Rows[i]["promocion"].ToString();
								aplicaPromocion = aplicaPromocion=="True" ? "1" : "2";
								precioTotal = double.Parse(dtSubArticulos.Rows[i]["precioTotal"].ToString());
								precioTotalConDesc = double.Parse(dtSubArticulos.Rows[i]["precioTotalConDesc"].ToString());
								precioUnitario = double.Parse(dtSubArticulos.Rows[i]["precio"].ToString());
								param = new SqlParameter[9];
								param[0] = new SqlParameter("@notaPedidoID", notaPedidoID);
								param[1] = new SqlParameter("@cantidad", cantidad);
								param[2] = new SqlParameter("@articuloID", articuloID);
								param[3] = new SqlParameter("@descuento", descuento);
								param[4] = new SqlParameter("@itemNro", itemNro);
								param[5] = new SqlParameter("@aplicaPromocion", aplicaPromocion);
								param[6] = new SqlParameter("@precioTotal", precioTotal);
								param[7] = new SqlParameter("@precioTotalConDesc", precioTotalConDesc);
								param[8] = new SqlParameter("@precioUnitario", precioUnitario);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertNotaPedidoLinea", param);
							}
						}
					}
					dr.Close();

					MessageBox.Show("Nota de Pedido guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Pedido guardada con éxito.", false);

					//Limpia el formulario
					limpiarFormulario();

					break;
				}
				catch (Exception e)
				{
					DialogResult dr = MessageBox.Show("No se pudo guardar la Nota de Pedido. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Nota de Pedido. \r\n" + e.Message, false);
					if (dr != DialogResult.Retry)
						break;
				}
			}
			*/
		}

		private void tbNotaPedidoNroDesdeB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string notaPedidoNroDesdeB = tbNotaPedidoNroDesdeB.Text.Trim();
				string notaPedidoNroHastaB = tbNotaPedidoNroHastaB.Text.Trim();
				if (notaPedidoNroDesdeB!="")
				{
					if (notaPedidoNroHastaB=="" || int.Parse(notaPedidoNroHastaB)<int.Parse(notaPedidoNroDesdeB))
						tbNotaPedidoNroHastaB.Text = tbNotaPedidoNroDesdeB.Text;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
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

		private void tbNotaPedidoNroHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string notaPedidoNroDesdeB = tbNotaPedidoNroDesdeB.Text.Trim();
				string notaPedidoNroHastaB = tbNotaPedidoNroHastaB.Text.Trim();
				if (notaPedidoNroHastaB!="")
				{
					if (notaPedidoNroDesdeB=="" || int.Parse(notaPedidoNroDesdeB)>int.Parse(notaPedidoNroHastaB))
						tbNotaPedidoNroDesdeB.Text = tbNotaPedidoNroHastaB.Text;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNotaPedidoNroHastaB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				string notaPedidoNroHastaB = tbNotaPedidoNroHastaB.Text.Trim().Replace(",","").Replace(".","");
				if (notaPedidoNroHastaB!="")
				{
					if (!Utilidades.IsNumeric(notaPedidoNroHastaB))
					{
						e.Cancel = true;
						MessageBox.Show("Nota Pedido Nro. (Hasta) debe contener un número entero.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				tbNotaPedidoNroHastaB.Text = notaPedidoNroHastaB;
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
				oSQLDataAdapter.TableMappings.Add("Table", "Items");
				oSQLDataAdapter.SelectCommand = oComm;

				//initialize dataset
				DataSet dsItems = new DataSet("Items");
				oSQLDataAdapter.Fill(dsItems);

				//prepare dataview to sort
				DataView dvItems;
				dvItems = new DataView(dsItems.Tables["Items"]);
				//dgItems.DataSource = dvItems;
				dgItems.DataSource = dsItems.Tables["Items"];
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
				string sql = "SELECT     dbo.NotaPedido.id, dbo.NotaPedido.fecha_creacion AS [Fecha Creación], dbo.NotaPedido.clienteID, dbo.NotaPedido.nombreCliente AS [Razón Social], " +
					"dbo.NotaPedido.ivaIDCliente, dbo.NotaPedido.direccionCliente AS [Dirección Cliente], dbo.NotaPedido.cuitCliente AS CUIT,  " +
					"dbo.NotaPedido.direccionEntrega AS [Dirección Entrega], dbo.NotaPedido.vendedorID, dbo.NotaPedido.condicionEntregaID,  " +
					"dbo.NotaPedido.bonificacion AS [Bonif. %], dbo.NotaPedido.autorizadorBonificacionID, dbo.NotaPedido.subTotal1 AS [SubTotal 1],  " +
					"dbo.NotaPedido.iva1 AS [IVA 1], dbo.NotaPedido.iva2 AS [IVA 2], dbo.NotaPedido.total, dbo.NotaPedido.estadoNotaPedidoID,  " +
					"dbo.NotaPedido.maquinaID, dbo.NotaPedido.subTotal2 AS [SubTotal 2], dbo.NotaPedido.bonificacionImporte AS Bonificación,  " +
					"dbo.Maquina.nombre AS Máquina, dbo.IVA.descripcion AS [Tipo IVA], dbo.Vendedor.usuarioID,  " +
					"dbo.Usuario.apellido + ', ' + dbo.Usuario.nombre AS Vendedor, dbo.tv_NotaPedidoEstado.descripcion AS Estado,  " +
					"Usuario_1.apellido + ', ' + Usuario_1.nombre AS Autorizó, dbo.NotaPedido.formaPagoID,  " +
					"dbo.tv_NotaPedidoRegaloEmpresario.descripcion AS [Regalo Empresario],  " +
					"dbo.tv_NotaPedidoRegaloEmpresario.identificador AS identificadorRegaloEmpresario, regaloEmpresarioID, " +
					"dbo.NotaPedido.notaPedidoSuc + '-' + dbo.NotaPedido.notaPedidoNro AS [Nro.] " +  
					"FROM         dbo.tv_NotaPedidoRegaloEmpresario RIGHT OUTER JOIN " +
					"dbo.NotaPedido ON dbo.tv_NotaPedidoRegaloEmpresario.id = dbo.NotaPedido.regaloEmpresarioID LEFT OUTER JOIN " +
					"dbo.Usuario Usuario_1 INNER JOIN " +
					"dbo.Vendedor Vendedor_1 ON Usuario_1.id = Vendedor_1.usuarioID ON dbo.NotaPedido.autorizadorBonificacionID = Vendedor_1.id LEFT OUTER JOIN " +
					"dbo.tv_NotaPedidoEstado ON dbo.NotaPedido.estadoNotaPedidoID = dbo.tv_NotaPedidoEstado.id LEFT OUTER JOIN " +
					"dbo.Usuario INNER JOIN " +
					"dbo.Vendedor ON dbo.Usuario.id = dbo.Vendedor.usuarioID ON dbo.NotaPedido.vendedorID = dbo.Vendedor.id LEFT OUTER JOIN " +
					"dbo.IVA ON dbo.NotaPedido.ivaIDCliente = dbo.IVA.id LEFT OUTER JOIN " +
					"dbo.Maquina ON dbo.NotaPedido.maquinaID = dbo.Maquina.id LEFT OUTER JOIN " +
					"dbo.Cliente ON dbo.NotaPedido.clienteID = dbo.Cliente.id " +
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
				
				//Este es para el alta de remitos invocada desde la Nota de Pedido
				if (tbNotaPedidoIDB.Text!=Utilidades.ID_VACIO)
				{
					filtro += " AND dbo.NotaPedido.id = CAST('" + tbNotaPedidoIDB.Text + "' AS uniqueidentifier)";
				}
				if (tbNotaPedidoSucDesdeB.Text!="" && tbNotaPedidoNroDesdeB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoSuc AS int) >= " + int.Parse(tbNotaPedidoSucDesdeB.Text);
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoNro AS int) >= " + int.Parse(tbNotaPedidoNroDesdeB.Text);
				}
				if (tbNotaPedidoSucHastaB.Text!="" && tbNotaPedidoNroHastaB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoSuc AS int) <= " + int.Parse(tbNotaPedidoSucHastaB.Text);
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoNro AS int) <= " + int.Parse(tbNotaPedidoNroHastaB.Text);
				}
				if (tbRazonSocialB.Text!="") 
				{
					filtro = filtro + " AND dbo.NotaPedido.nombreCliente LIKE '%" + tbRazonSocialB.Text.Trim() + "%'";
				}
				if (cbVendedorB.SelectedIndex>0) 
				{
					filtro = filtro + " AND vendedorID = CAST('" + cbVendedorB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbEstadoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND estadoNotaPedidoID = CAST('" + cbEstadoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (tbCuitB.Text!="") 
				{
					filtro = filtro + " AND dbo.NotaPedido.cuitCliente = " + tbCuitB.Text.Trim();
				}
				if (cbCondicionEntregaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND condicionEntregaID = CAST('" + cbCondicionEntregaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
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

		private void dgItems_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.consultaRapida)
					((Form)this.Parent).Close();				
				else
				{
					DataTable dt = (DataTable)dgItems.DataSource;
					int currentRow = dgItems.CurrentRowIndex;

					string notaPedidoID = dt.Rows[currentRow]["ID"].ToString();
					tbNotaPedidoID.Text = notaPedidoID;
					//Carga los articulos de la Nota de Pedido para generar los remitos.
					cargarArticulosBase(notaPedidoID);
					tabPrincipal.SelectedIndex = 2;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		//Carga los articulos de la nota de Pedido, en base al ID.
		private void cargarArticulosBase(string notaPedidoID)
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cargando...", true);

				/********************************
				* Carga los items en la grilla
				* ******************************/
				//Borra los registros de la grilla de ArticulosBase
				DataTable tabla = (DataTable)dgArticulosBase.DataSource;
				tabla.Rows.Clear();
                
                //Toma el numero de nota de pedido
                DataTable tablaNotaPedido = (DataTable)dgItems.DataSource;
                string notaPedidoNumero = tablaNotaPedido.Rows[dgItems.CurrentRowIndex]["Nro."].ToString();
                dgArticulosBase.CaptionText = "Articulos, Nota de Pedido Nº " + notaPedidoNumero;
                //Regalo empresario
                string regaloEmpresario = tablaNotaPedido.Rows[dgItems.CurrentRowIndex]["Regalo Empresario"].ToString();
                if (regaloEmpresario == "Sí")
                {
                    chkRBRegaloEmpresario.Checked = true;
                    tbRBNombreDestinatario.Enabled = false;
                    tbRBDireccionDestinatario.Enabled = false;
                }
                else
                {
                    chkRBRegaloEmpresario.Checked = false;
                    tbRBNombreDestinatario.Enabled = true;
                    tbRBDireccionDestinatario.Enabled = true;
                }
                tablaNotaPedido = null;

				//Carga los articulos base
				System.Guid remitoBaseID = new Guid();
				SqlParameter[] param = new SqlParameter[1];
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@notaPedidoID", new System.Guid(notaPedidoID));
				param[1] = new SqlParameter("@remitoBaseIDout", remitoBaseID);
				param[1].Direction = ParameterDirection.Output;
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllRemitoArticulosBase", param);

				//Carga los registros encontrados
				if (dr.HasRows)
				{
					bool primeraVez = true;
					while (dr.Read())
					{
						DataRow newRow = tabla.NewRow();
						newRow["ID"] = dr["ID"].ToString();
						newRow["itemNro"] = dr["itemNro"].ToString();
						newRow["Código Interno"] = dr["codigoInterno"].ToString();
						newRow["Código de Barras"] = dr["codigoBarras"].ToString();
						newRow["Cantidad"] = dr["cantidad"].ToString();
						newRow["Rubro"] = dr["Rubro"].ToString();
						newRow["Sub Rubro"] = dr["SubRubro"].ToString();
						newRow["Descripción"] = dr["descripcion"].ToString();
						newRow["articuloID"] = dr["articuloID"].ToString();
						tabla.Rows.Add(newRow);

						if (primeraVez)
						{
							//Toma el remitoBaseID
							tbRemitoBaseID.Text = dr["remitoBaseIDOUT"].ToString();
                            if (chkRBRegaloEmpresario.Checked)
                                tbRBNombreDestinatario.Text = "";
                            else
							    tbRBNombreDestinatario.Text = dr["destinatarioNombre"].ToString();

							tbRBDireccionDestinatario.Text = dr["destinatarioDireccion"].ToString();
							tbRBObsequiante.Text = dr["obsequiante"].ToString();

							primeraVez = false;
						}

					}
				}
				dr.Close();

				//Activa los controles del Remito Base
                utilRemito.activarControlesRemitoBase(this.configuracion, ref gbRemitoBase, ref dgArticulosBase, true);

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Carga el Remito Base usando los items ingresados manualmente
		private void cargarArticulosBaseManual()
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cargando...", true);

				//Primero crea un nuevo remito base en la base de datos y recupera el ID
				System.Guid remitoBaseID = new Guid();
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@remitoBaseIDout", remitoBaseID);
				param[0].Direction = ParameterDirection.Output;
				SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoRemitoBaseManual", param);

				//Carga las lineas del remito base
				DataTable dtArticulosManual = (DataTable)dgSubArticulos.DataSource;
				for (int i=0; i<dtArticulosManual.Rows.Count; i++)
				{
					param = new SqlParameter[4];
					param[0] = new SqlParameter("@remitoBaseID", remitoBaseID);
					param[1] = new SqlParameter("@articuloID", new System.Guid(dtArticulosManual.Rows[i]["articuloID"].ToString()));
					param[2] = new SqlParameter("@cantidad", dtArticulosManual.Rows[i]["cantidad"].ToString());
					param[3] = new SqlParameter("@itemNro", dtArticulosManual.Rows[i]["itemNro"].ToString());
					SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertRemitoBaseLineaManual", param);
				}

				/********************************
				* Carga los items en la grilla
				* ******************************/
				//Borra los registros de la grilla de ArticulosBase
				DataTable tabla = (DataTable)dgArticulosBase.DataSource;
				tabla.Rows.Clear();
				//Carga los articulos base
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@remitoBaseID", remitoBaseID);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllRemitoArticulosBaseManual", param);

				//Carga los registros encontrados
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						DataRow newRow = tabla.NewRow();
						newRow["ID"] = dr["ID"].ToString();
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

				//Toma el remitoBaseID
				tbRemitoBaseID.Text = remitoBaseID.ToString();

				//Activa los controles del Remito Base
                utilRemito.activarControlesRemitoBase(this.configuracion, ref gbRemitoBase, ref dgArticulosBase, true);

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		

		private void butNuevoRemito_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (verificarPosibleNuevoRemito())
				{
					nuevoRemito();
					tabConfeccionarRemitos.SelectedIndex = 1;

					//Desactiva las notas de pedido y el remito base
					activarControlesNotasPedido(false);
					utilRemito.activarControlesRemitoBase(this.configuracion, ref gbRemitoBase, ref dgArticulosBase, false);

					//Activa el remito
                    utilRemito.activarControlesRemito(this.configuracion, ref gbNuevoRemito, ref dgArticulosNuevoRemito, true);

                    //Selecciona el flete 
                    chkMostrarTodosFletes.Checked = chkRBMostrarTodosFletes.Checked;
                    cbZona.SelectedIndex = cbRBZona.SelectedIndex;
                    cbFlete.SelectedIndex = cbRBFlete.SelectedIndex;

                    //Transmite Obsequiante y Bultos
                    tbObsequiante.Text = tbRBObsequiante.Text;
                    tbBultos.Text = tbRBBultos.Text;

                    cbRSucursal.SelectedValue = cbRBSucursal.SelectedValue;

                    //Hereda los datos del destinatario
                    if (!chkRBRegaloEmpresario.Checked)
                    {
                        tbNombreDestinatario.Text = tbRBNombreDestinatario.Text;
                        tbDireccionDestinatario.Text = tbRBDireccionDestinatario.Text;
                        butImprimirRemito.Enabled = true;
                    }
                    else
                    {
                        butImprimirRemito.Enabled = false;
                    }
                    if (cbRBLocalidad.SelectedValue != null)
                        cbLocalidad.SelectedValue = cbRBLocalidad.SelectedValue;
                    else
                        cbLocalidad.Text = cbRBLocalidad.Text;


                    if (cbRBProvincia.SelectedValue!=null)
                        cbProvincia.SelectedValue = cbRBProvincia.SelectedValue;
                    else
                        cbProvincia.Text = cbRBProvincia.Text;

                    tbNombreDestinatario.Text = "";
                    tbDireccionDestinatario.Text = "";

					//Renumera los items del remito
					renumerarItems();
				}
				else
				{
					MessageBox.Show("No hay cantidades suficientes para generar un nuevo remito.","Cantidades agotadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    butCerrar_Click(butCerrar, new EventArgs());
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Verifica si hay cantidades suficientes para hacer un nuevo remito
		private bool verificarPosibleNuevoRemito()
		{
			try
			{
				bool resultado = true;

				DataTable dtRemitoBase = (DataTable)dgArticulosBase.DataSource;
			
				if (dtRemitoBase.Rows.Count>0)
				{
					Int64 suma = (Int64)dtRemitoBase.Compute("Sum(Cantidad)", "True");

					dtRemitoBase.Dispose();

					if (suma>0)
						resultado = true;
					else
						resultado = false;
				}
				else
					resultado = false;

				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Genera un nuevo remito, llena la grilla y cambia de tab.
		private void nuevoRemito()
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cargando...", true);

				/********************************
				* Carga los items en la grilla
				* ******************************/
				//Borra los registros de la grilla de Articulos Remito
				DataTable tabla = (DataTable)dgArticulosNuevoRemito.DataSource;
				tabla.Rows.Clear();
				//Carga los articulos base
				SqlParameter[] param = new SqlParameter[6];
				param[0] = new SqlParameter("@notaPedidoID", new System.Guid(tbNotaPedidoID.Text));
				param[1] = new SqlParameter("@remitoBaseID", new System.Guid(tbRemitoBaseID.Text));
				//param[2] = new SqlParameter("@sucursalCreacionID", this.configuracion.sucursal.id);
                param[2] = new SqlParameter("@sucursalCreacionID", (Guid)cbRBSucursal.SelectedValue);
				param[3] = new SqlParameter("@usuarioID", new System.Guid(this.configuracion.usuario.id));
                param[4] = new SqlParameter("@facturaSuc", tbFacturaSuc.Text);
                param[5] = new SqlParameter("@facturaNro", tbFacturaNro.Text);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoRemito", param);
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						DataRow newRow = tabla.NewRow();
						newRow["ID"] = dr["ID"].ToString();
						newRow["itemNro"] = dr["itemNro"].ToString();
						newRow["Código Interno"] = dr["codigoInterno"].ToString();
						newRow["Código de Barras"] = dr["codigoBarras"].ToString();
						newRow["Cantidad"] = dr["cantidad"].ToString();
						newRow["Rubro"] = dr["Rubro"].ToString();
						newRow["Sub Rubro"] = dr["SubRubro"].ToString();
						newRow["Descripción"] = dr["descripcion"].ToString();
						newRow["articuloID"] = dr["articuloID"].ToString();
						newRow["itemSeleccionado"] = dr["itemSeleccionado"].ToString();
						tabla.Rows.Add(newRow);

						//Toma el remitoID
						tbNuevoRemitoID.Text = dr["remitoID"].ToString();
					}
				}
				dr.Close();

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void chkSeleccionarTodo_CheckedChanged(object sender, System.EventArgs e)
		{
			seleccionarTodo();
			renumerarItems();
		}

		//Marca o desmarca todos los registros de la grilla
		private void seleccionarTodo()
		{
			try
			{
				DataTable tabla = (DataTable)dgArticulosNuevoRemito.DataSource;
				if (tabla.Rows.Count>0)
				{
					foreach (DataRow row in tabla.Rows)
					{
						row["itemSeleccionado"] = chkSeleccionarTodo.Checked;
					}
				}
				tabla.Dispose();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dgArticulosNuevoRemito_CurrentCellChanged(object sender, System.EventArgs e)
		{
			renumerarItems();
		}

		private void butImprimirRemito_Click(object sender, System.EventArgs e)
		{
			if (verificarCantidadesRemito())
			{
				DialogResult dr = MessageBox.Show("Está a punto de imprimir el Remito.\r\n\r\n¿Desea continuar?", "Impresión de Remitos",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					Remito remito = new Remito(this.configuracion);

					//Primero guarda el Remito
					utilRemito.guardarRemito(this.configuracion, ref tabConfeccionarRemitos, "SUSPENDIDO");  
					
					//Luego lo imprime
					if (remito.imprimirRemito(tbNuevoRemitoID.Text))
					{
						//Cambia el estado a IMPRESO
						remito.cambiarEstadoRemito(tbNuevoRemitoID.Text, "IMPRESO");
						
						//Actualiza el stock
						remito.actualizarStock(((DataTable)dgArticulosNuevoRemito.DataSource), tbNuevoRemitoID.Text);

						//Cambia el estado de la mercaderia
						remito.cambiarEstadoMercaderia(tbNuevoRemitoID.Text, "DESPACHADA", "");

                        MessageBox.Show("El Remito fue enviado a la cola de impresión.\r\n\r\nDestinatario: " + tbNombreDestinatario.Text, "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
						
						limpiarFormularioRemito();
					}
					remito = null;
				}
			}
		}

		//Limpia el formulario, cambia el tab
		private void limpiarFormularioRemito()
		{
			try
			{
				DataTable dt = (DataTable)dgArticulosNuevoRemito.DataSource;
				dt.Rows.Clear();
				dt.Dispose();

				tbNuevoRemitoID.Text = Utilidades.ID_VACIO;

				tabConfeccionarRemitos.SelectedIndex = 0;
			
				//Desactiva el formulario del Remito
                utilRemito.activarControlesRemito(this.configuracion, ref gbNuevoRemito, ref dgArticulosNuevoRemito, false);

				//Activa los demas formularios
                utilRemito.activarControlesRemitoBase(this.configuracion, ref gbRemitoBase, ref dgArticulosBase, true);
				activarControlesNotasPedido(true);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		
		//Activa o desactiva los controles de la busqueda de notas de pedido
		private void activarControlesNotasPedido(bool activar)
		{
			try
			{
				tabFiltro.Enabled = activar;
				dgItems.Enabled = activar;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Verifica las cantidades del Remito. No deben sobrepasar las cantidades del RemitoBase.
		private bool verificarCantidadesRemito()
		{
			try
			{
				bool resultado = false;
                bool consumeTodasCant = false;

                if (validarNuevoRemito())
                {

                    //renumerarItems();

                    DataTable dtRemito = (DataTable)dgArticulosNuevoRemito.DataSource;
                    DataTable dtRemitoBase = (DataTable)dgArticulosBase.DataSource;

                    string mensaje = "";
                    //Recorre los registros
                    for (int i = 0; i < dtRemito.Rows.Count; i++)
                    {
                        string sItemSeleccionado = dtRemito.Rows[i]["itemSeleccionado"].ToString();
                        if (sItemSeleccionado != "")
                        {
                            bool itemSeleccionado = bool.Parse(sItemSeleccionado);
                            if (itemSeleccionado)
                            {
                                int cantRemito = int.Parse(dtRemito.Rows[i]["Cantidad"].ToString());
                                int indiceRB = Utilidades.DataTableSeek(ref dtRemitoBase, "Código Interno", dtRemito.Rows[i]["Código Interno"].ToString());
                                int cantRemitoBase = int.Parse(dtRemitoBase.Rows[indiceRB]["Cantidad"].ToString());
                                string itemNro = dtRemito.Rows[i]["itemNro"].ToString();

                                if (cantRemito > cantRemitoBase)
                                {
                                    mensaje += "- Item #" + itemNro + ": la Cantidad (" + cantRemito.ToString() + ") no puede ser superior a " + cantRemitoBase.ToString() + ".\r\n";
                                }
                                if (cantRemito < 0)
                                {
                                    mensaje += "- Item #" + itemNro + ": la Cantidad (" + cantRemito.ToString() + ") no puede ser menor que 0.\r\n";
                                }
                                if (cantRemito == cantRemitoBase)
                                    consumeTodasCant = true;
                                else
                                    consumeTodasCant = false;

                            }
                        }
                    }

                    if (mensaje != "")
                    {
                        mensaje = "Hay algunos datos incorrectos en el remito.\r\n\r\n" + mensaje;
                        resultado = false;
                        MessageBox.Show(mensaje, "Verificar Remito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (consumeTodasCant)
                        {
                            DialogResult dlr = MessageBox.Show("Ud. ha seleccionado todas las cantidades disponibles.\r\n\r\n¿Desea continuar?", "Todas las cantidades", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dlr == DialogResult.Yes)
                                resultado = true;
                            else
                                resultado = false;
                        }
                        else
                        {
                            resultado = true;
                        }

                    }
                }
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

        private bool validarNuevoRemito()
        {
            try
            {
                string mensaje = "";
                bool resultado = true;

                if (tbNombreDestinatario.Text.Trim()=="")
                {
                    mensaje += "   - Debe ingresar el Destinatario.\r\n";
                    resultado = false;
                }
                if (tbDireccionDestinatario.Text.Trim() == "")
                {
                    mensaje += "   - Debe ingresar la Dirección del Destinatario.\r\n";
                    resultado = false;
                }
                if (tbObsequiante.Text.Trim() == "")
                {
                    mensaje += "   - Debe ingresar la Dirección del Destinatario.\r\n";
                    resultado = false;
                }
                
                //Recorre los items
                DataTable dt = (DataTable)dgArticulosNuevoRemito.DataSource;
                bool nadaSeleccionado = true, cantidadesEnCero = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (((bool)dt.Rows[i]["itemSeleccionado"]) == true)
                    {
                        nadaSeleccionado = false;
                        if (dt.Rows[i]["cantidad"].ToString() == "" || dt.Rows[i]["cantidad"].ToString() == "0")
                            cantidadesEnCero = true;
                    }
                }
                
                if (nadaSeleccionado)
                {
                    mensaje += "   - Debe seleccionar algún Item.\r\n";
                    resultado = false;
                }
                if (cantidadesEnCero)
                {
                    mensaje += "   - Las cantidades deben ser mayor que 0.\r\n";
                    resultado = false;
                }
                

                if (mensaje != "")
                {
                    mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
                    MessageBox.Show(mensaje, "Nuevo Remito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

		private void butGuardarRemito_Click(object sender, System.EventArgs e)
		{
			if (verificarCantidadesRemito())
			{
                UserControl uc = (UserControl)this;
                if (utilRemito.guardarRemito(this.configuracion, ref tabConfeccionarRemitos, "SUSPENDIDO"))  //Estado 2, Guardado no impreso.
                {
                    MessageBox.Show("Remito guardado con éxito.\r\n\r\nDestinatario: " + tbNombreDestinatario.Text, "Suspender", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarFormularioRemito();
                    butNuevoRemito_Click(butNuevoRemito, new EventArgs());
                }
			}
		}

		private void butCancelarRemito_Click(object sender, System.EventArgs e)
		{
			borrarRemitoTemporal();
			limpiarFormularioRemito();
		}

		//Limpia la tabla de reistros temporales. Remitos que no llegan a ser confirmados por el usuario
		public void borrarRemitoTemporal()
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cargando...", true);

				if (tbNuevoRemitoID.Text!=Utilidades.ID_VACIO)
				{
					//Ejecuta el procedimiento almacenado
					SqlParameter[] param = new SqlParameter[1];
					param = new SqlParameter[1];
					param[0] = new SqlParameter("@remitoID", new System.Guid(tbNuevoRemitoID.Text));
					SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarRemitoTemporal", param);
				}

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Guarda el Remito
		/*private bool guardarRemito(string estadoRemito)
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Guardando...", true);

				bool resultado = true;
			
				try 
				{
					//Primero guarda el remito, sin numero todavia.
					//Recorre las lineas y las guarda una por una
					DataTable dt = (DataTable)dgArticulosNuevoRemito.DataSource;
					DataTable dtRemitoBase = (DataTable)dgArticulosBase.DataSource;
					for (int i=0; i<dt.Rows.Count; i++)
					{
						string sItemSeleccionado = dt.Rows[i]["itemSeleccionado"].ToString();
						if (sItemSeleccionado!="")
						{
							int itemSeleccionado = bool.Parse(sItemSeleccionado) ? 1 : 2;
							string ID = dt.Rows[i]["ID"].ToString();

							//Si el item es seleccionado, lo guarda. Sino, lo borra
							if (itemSeleccionado==1)
							{
								string itemNro = dt.Rows[i]["itemNro"].ToString();
								int cantidad = int.Parse(dt.Rows[i]["Cantidad"].ToString());
								string remitoBaseLineaID = dtRemitoBase.Rows[i]["ID"].ToString();
								int cantidadRemitoBase = int.Parse(dtRemitoBase.Rows[i]["cantidad"].ToString());
								cantidadRemitoBase -= cantidad;

								//Guarda los cambios de la linea del Remito
								SqlParameter[] param = new SqlParameter[4];
								param[0] = new SqlParameter("@ID", new System.Guid(ID));
								param[1] = new SqlParameter("@itemSeleccionado", itemSeleccionado);
								param[2] = new SqlParameter("@itemNro", itemNro);
								param[3] = new SqlParameter("@cantidad", cantidad);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_GuardarRemitoLinea", param);

		
								//Actualiza la cantidad en la linea del Remito Base
								param = new SqlParameter[2];
								param[0] = new SqlParameter("@ID", new System.Guid(remitoBaseLineaID));
								param[1] = new SqlParameter("@cantidad", cantidadRemitoBase);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_GuardarCantidadRemitoBaseLinea", param);

								//Actualiza la cantidad en la grilla del remito base
								dtRemitoBase.Rows[i]["Cantidad"] = cantidadRemitoBase;
							}
							else //Item no seleccionado, lo borra
							{
								//Borra el item que no fue seleccionado por el usuario
								SqlParameter[] param0 = new SqlParameter[1];
								param0[0] = new SqlParameter("@ID", new System.Guid(ID));
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarRemitoLinea", param0);
							}
						}
					}
					//dt.Dispose();
					//dtRemitoBase.Dispose();

					//Agrega el destinatario
					SqlParameter[] param1 = new SqlParameter[3];
					param1[0] = new SqlParameter("@remitoID", new System.Guid(tbNuevoRemitoID.Text));
					param1[1] = new SqlParameter("@destinatarioNombre", tbNombreDestinatario.Text);
					param1[2] = new SqlParameter("@destinatarioDireccion", tbDireccionDestinatario.Text);
					SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarRemitoDestinatario", param1);

					//Actualiza el estado del Remito
					param1 = new SqlParameter[2];
					param1[0] = new SqlParameter("@ID", new System.Guid(tbNuevoRemitoID.Text));
					param1[1] = new SqlParameter("@estadoRemito", estadoRemito);
					SqlHelper.ExecuteNonQuery(this.conexion, "sp_ActualizarEstadoRemito", param1);

					resultado = true;
				}
				catch (Exception e)
				{
					ManejadorErrores.escribirLog(e, true);
					MessageBox.Show(e.Message, "Error al Guardar el Remito", MessageBoxButtons.OK, MessageBoxIcon.Error);
					resultado = false;
				}
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);

				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}*/

		//Ejecuta la busqueda de una Nota de Pedido, segun su numero
		public void buscarNotaPedido(string notaPedidoID)
		{
			try
			{
				//Coloca el numero en los casilleros
				tbNotaPedidoIDB.Text = notaPedidoID;
				
				//Ejecuta la Busqueda
				ejecutarBusqueda();

				//Si encontro la Nota de Pedido, la carga
				DataTable dt = (DataTable)dgItems.DataSource;
				if (dt.Rows.Count>0)
				{
					dgItems.CurrentRowIndex = 0;
					tbNotaPedidoID.Text = notaPedidoID;
					//Carga los articulos de la Nota de Pedido para generar los remitos.
					cargarArticulosBase(notaPedidoID);
					tabPrincipal.SelectedIndex = 2;
				}
				dt.Dispose();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butContinuar2_Click(object sender, System.EventArgs e)
		{
			cargarArticulosBaseManual();
			tabPrincipal.SelectedIndex = 2;
			tabConfeccionarRemitos.SelectedIndex = 0;
		}

		private void butSiguiente_Click(object sender, System.EventArgs e)
		{
			tabArticulosManualmente.SelectedIndex = 1;
		}



		#region Manejadores para el ingreso Manual
		private void tbCodigoInternoAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar==(char)Keys.Enter)
				{
					if (buscarArticulo("CodigoInterno", tbCodigoInternoAC.Text))
					{
						tbCodigoUsado = (Control)sender;
						tbCantidadAC.Select();
					}
					else
						tbCodigoInternoAC.SelectAll();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Busca el articulo segun el codigo ingresado.
		private bool buscarArticulo(string articuloID)
		{
			try
			{
				tbCodigoUsado = (Control)butBuscarArticuloAC;
				tbCantidadAC.Select();
				return buscarArticulo("", "", articuloID);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		/*
		private bool buscarArticulo(string tipoCodigo, string codigo)
		{
			return buscarArticulo(tipoCodigo, codigo, "");
		}
		
		private bool buscarArticulo(string tipoCodigo, string codigo, string p_articuloID)
		{
			try
			{
				bool encontrado = false;
				string rubro="", subRubro="", descripcion="", codigoInterno="", codigoBarras="", articuloID="";
				string precio="", promocion="";
			
				this.Cursor = Cursors.WaitCursor;
	
				string sparam="", sp="";
				if (p_articuloID!="")
				{
					codigo = p_articuloID;
					sparam = "@articuloID";
					sp = "sp_getArticuloByID";
				}
				else if (tipoCodigo=="CodigoInterno")
				{
					sparam = "@codigoInterno";
					sp = "sp_getArticuloByCodigoInterno";
				}
				else if (tipoCodigo=="CodigoBarras")
				{
					sparam = "@codigoBarras";
					sp = "sp_getArticuloByCodigoBarras";
				}

				string valorCelda = codigo;
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(sparam, valorCelda);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

				//Si se encontro el registro
				if (dr.HasRows)
				{
					dr.Read();
					rubro = dr["Rubro"].ToString();
					subRubro = dr["Sub Rubro"].ToString();
					descripcion = dr["Descripción"].ToString();
					codigoInterno = dr["Código Interno"].ToString();
					codigoBarras = dr["Código de Barras"].ToString();
					articuloID = dr["id"].ToString();
					precio = double.Parse(dr["Precio"].ToString()).ToString("N");
					promocion = "True";
					encontrado = true;
				}
				else
				{
					encontrado = false;
				}
				dr.Close();


				if (!encontrado)
				{
					rubro = "No registrado.";
					subRubro = "No registrado.";
					descripcion = "Artículo No Registrado.";
					if (p_articuloID!="")
					{
						codigoInterno = "";
						codigoBarras = "";
					}
					else
					{
						codigoInterno = tbCodigoInternoAC.Text;
						codigoBarras = tbCodigoBarrasAC.Text;
					}
					articuloID = "";
				}

				tbRubroAC.Text = rubro;
				tbSubRubroAC.Text = subRubro;
				tbDescripcionAC.Text = descripcion;
				tbCodigoInternoAC.Text = codigoInterno;
				tbCodigoBarrasAC.Text = codigoBarras;
				tbID.Text = articuloID;
				tbPrecioAC.Text = precio;
				tbPromocionAC.Text = promocion;

				this.Cursor = Cursors.Arrow;

				return encontrado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		*/
		private bool buscarArticulo(string tipoCodigo, string codigo)
		{
			return buscarArticulo(tipoCodigo, codigo, Utilidades.ID_VACIO);
		}
		
		private bool buscarArticulo(string tipoCodigo, string codigo, string p_articuloID)
		{
			try
			{
				bool encontrado = false;

				if (tipoCodigo!="" || codigo!="" || p_articuloID!=Utilidades.ID_VACIO)
				{
					string rubro="", subRubro="", descripcion="", codigoInterno="", codigoBarras="", articuloID=Utilidades.ID_VACIO;
					string precio="", promocion="";
			
					this.Cursor = Cursors.WaitCursor;
	
					string sparam="", sp="";
					if (p_articuloID!=Utilidades.ID_VACIO)
					{
						codigo = p_articuloID;
						sparam = "@articuloID";
						sp = "sp_getArticuloByID";
					}
					else if (tipoCodigo=="CodigoInterno")
					{
						sparam = "@codigoInterno";
						sp = "sp_getArticuloByCodigoInterno";
					}
					else if (tipoCodigo=="CodigoBarras")
					{
						sparam = "@codigoBarras";
						sp = "sp_getArticuloByCodigoBarras";
					}

					//string valorCelda = codigo;
					SqlParameter[] param = new SqlParameter[1];
					
					if (p_articuloID!=Utilidades.ID_VACIO)
						param[0] = new SqlParameter(sparam, new System.Guid(codigo));
					else
						param[0] = new SqlParameter(sparam, codigo);

					SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

					//Si se encontro el registro
					if (dr.HasRows)
					{
						dr.Read();
						rubro = dr["Rubro"].ToString();
						subRubro = dr["Sub Rubro"].ToString();
						descripcion = dr["Descripción"].ToString();
						codigoInterno = dr["Código Interno"].ToString();
						codigoBarras = dr["Código de Barras"].ToString();
						articuloID = dr["id"].ToString();
						precio = double.Parse(dr["Precio"].ToString()).ToString("N");
						promocion = "True";
						encontrado = true;
					}
					else
					{
						encontrado = false;
					}
					dr.Close();


					if (!encontrado)
					{
						rubro = "No registrado.";
						subRubro = "No registrado.";
						descripcion = "Artículo No Registrado.";
						if (p_articuloID!=Utilidades.ID_VACIO)
						{
							codigoInterno = "";
							codigoBarras = "";
						}
						else
						{
							codigoInterno = tbCodigoInternoAC.Text;
							codigoBarras = tbCodigoBarrasAC.Text;
						}
						articuloID = Utilidades.ID_VACIO;
					}

					tbRubroAC.Text = rubro;
					tbSubRubroAC.Text = subRubro;
					tbDescripcionAC.Text = descripcion;
					tbCodigoInternoAC.Text = codigoInterno;
					tbCodigoBarrasAC.Text = codigoBarras;
					tbID.Text = articuloID;
					tbPrecioAC.Text = precio;
					tbPromocionAC.Text = promocion;

					this.Cursor = Cursors.Arrow;
				}
				return encontrado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Cambia el color de fondo segun tenga o pierda el foco
		private void controlarColorFondo(ref object sender, string foco)
		{
			try
			{
				Control control = (Control)sender;
				if (foco=="Enter")
				{
					control.BackColor = Color.LightCyan;
					control.ForeColor = Color.Black;
				}
				else
				{
					if (control is Button)
						control.BackColor = Color.Gainsboro;
					else
						control.BackColor = Color.White;

					control.ForeColor = Color.Black;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		private void tbCodigoInternoAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void tbCodigoInternoAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
		}

		private void tbCodigoBarrasAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void tbCodigoBarrasAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
		}

		private void tbCantidadAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
			//Seleciona todo el texto
			tbCantidadAC.SelectAll();
		}

		private void tbCantidadAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
		}

		private void butAgregarArticuloAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void butAgregarArticuloAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
		}

		private void tbCodigoBarrasAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar==(char)Keys.Enter)
				{
					if (buscarArticulo("CodigoBarras", tbCodigoBarrasAC.Text))
					{
						tbCodigoUsado = (Control)sender;
						tbCantidadAC.Select();
					}
					else
					{
						tbCodigoBarrasAC.SelectAll();
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbCantidadAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar==(char)Keys.Enter)
				{
					if (Utilidades.IsNumeric(tbCantidadAC.Text))
					{
						agregarArticulo(ref tbCodigoUsado);
					}
					else
					{
						MessageBox.Show("La Cantidad debe ser un valor numérico.","Valor Incorrecto",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						tbCantidadAC.Select();
						tbCantidadAC.SelectAll();
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Agrega el articulo en la lista de articulos
		private void agregarArticulo(ref Control controlFocus)
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", true);
				if (Utilidades.IsNumeric(tbCantidadAC.Text) &&
					tbCantidadAC.Text.Trim()!="" && 
					tbRubroAC.Text!="No registrado." && tbRubroAC.Text!="" &&
					!(tbCodigoInternoAC.Text.Trim()=="" && tbCodigoBarrasAC.Text.Trim()=="" && tbID.Text.Trim()==""))
				{
					//Agrega un registro a la tabla de la grilla
					DataTable tabla = (DataTable)dgSubArticulos.DataSource;
					DataRow newRow = tabla.NewRow();
					newRow["Código Interno"] = tbCodigoInternoAC.Text;
					newRow["Código de Barras"] = tbCodigoBarrasAC.Text;
					newRow["Cantidad"] = tbCantidadAC.Text;
					newRow["Rubro"] = tbRubroAC.Text;
					newRow["Sub Rubro"] = tbSubRubroAC.Text;
					newRow["Descripción"] = tbDescripcionAC.Text;
					newRow["articuloID"] = tbID.Text;
					newRow["precio"] = double.Parse(tbPrecioAC.Text);
					newRow["promocion"] = bool.Parse(tbPromocionAC.Text);
					newRow["itemNro"] = tabla.Rows.Count + 1;
					newRow["descuento"] = 0;
					newRow["precioTotal"] = double.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
					newRow["precioTotalConDesc"] = double.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
					tabla.Rows.Add(newRow);

					//Limpia los codigos
					tbCodigoInternoAC.Text = "";
					tbCodigoBarrasAC.Text = "";
					tbRubroAC.Text = "";
					tbSubRubroAC.Text = "";
					tbDescripcionAC.Text = "";
					tbID.Text = "";
					tbPrecioAC.Text = "";
					tbPromocionAC.Text = "";

					//Establece el foco en la grilla y muestra el ultimo registro
					dgSubArticulos.Select();
					dgSubArticulos.CurrentRowIndex = ((DataTable)dgSubArticulos.DataSource).Rows.Count - 1;

					//Establece el foco
					if (controlFocus!=null)
						controlFocus.Select();

					//calcularSubTotales();
				}
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butAgregarArticuloAC_Click(object sender, System.EventArgs e)
		{
			agregarArticulo(ref tbCodigoUsado);
		}

		private void butBuscarArticuloAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void butBuscarArticuloAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
		}

		private void butBuscarArticuloAC_Click(object sender, System.EventArgs e)
		{
			abrirConsultaRapidaArticulos();
		}

		//Abre el formulario de consulta en modo rapido
		private void abrirConsultaRapidaArticulos()
		{
			try
			{
				frmArticuloConsulta form = new frmArticuloConsulta(this.configuracion, true);
				form.statusBar1 = this.statusBarPrincipal;

				//Crea y asigna el Delegate
				form.objDelegateDevolverID = new Comunes.frmArticuloConsulta.DelegateDevolverID(buscarArticulo);
			
				form.ShowDialog();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		private void butBorrarArticulosManualmente_Click(object sender, System.EventArgs e)
		{
			borrarRegistrosArticulosManualmente();
		}
		private void borrarRegistrosArticulosManualmente()
		{
			try
			{
				if (dgSubArticulos.DataSource!=null)
				{
					DataTable dt = (DataTable)dgSubArticulos.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgSubArticulos.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							DialogResult dr = MessageBox.Show("¿Desea borrar los Artículos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Artículos...", true);
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									//dt.Rows[renglon].Delete();
									dt.Rows[renglon]["id"] = "-1";
								}
								//Recorre los renglones marcados para borrar
								DataRow[] rowsBorrar = dt.Select("id='-1'");
								for (int k=0; k<rowsBorrar.Length; k++)
								{
									rowsBorrar[k].Delete();
								}
								dt.AcceptChanges();

								//Renumera los items
								renumerarItemsArticulosManualmente();

								//calcularSubTotales();

								dgSubArticulos.Refresh();
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

		//Renumera los items de la Tabla
		private void renumerarItemsArticulosManualmente()
		{
			try
			{
				DataTable dt = (DataTable)dgSubArticulos.DataSource;

				for (int i=0; i<dt.Rows.Count; i++)
				{
					dt.Rows[i]["itemNro"] = i + 1;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		#endregion


		private void tbNotaPedidoSucDesdeB_Validated(object sender, System.EventArgs e)
		{
			string suc = tbNotaPedidoSucDesdeB.Text;
			Utilidades.agregarCerosIzquierda(ref suc,4);
			tbNotaPedidoSucDesdeB.Text = suc;
		}

		private void tbNotaPedidoNroDesdeB_Validated_1(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega los ceros a la izquiera
				string suc = tbNotaPedidoNroDesdeB.Text;
				Utilidades.agregarCerosIzquierda(ref suc,8);
				tbNotaPedidoNroDesdeB.Text = suc;

				//Pone el valor Hasta
				string NotaPedidoNroDesdeB = tbNotaPedidoNroDesdeB.Text.Trim();
				string NotaPedidoNroHastaB = tbNotaPedidoNroHastaB.Text.Trim();
				if (NotaPedidoNroDesdeB!="")
				{
					if (NotaPedidoNroHastaB=="" || int.Parse(NotaPedidoNroHastaB)<int.Parse(NotaPedidoNroDesdeB))
					{
						tbNotaPedidoSucHastaB.Text = tbNotaPedidoSucDesdeB.Text;
						tbNotaPedidoNroHastaB.Text = tbNotaPedidoNroDesdeB.Text;
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNotaPedidoSucHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string suc = tbNotaPedidoSucHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref suc,4);
				tbNotaPedidoSucHastaB.Text = suc;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNotaPedidoNroHastaB_Validated_1(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega ceros a la izquierda
				string suc = tbNotaPedidoSucHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref suc,4);
				tbNotaPedidoSucHastaB.Text = suc;

				//Establece el valor desde
				string NotaPedidoNroDesdeB = tbNotaPedidoNroDesdeB.Text.Trim();
				string NotaPedidoNroHastaB = tbNotaPedidoNroHastaB.Text.Trim();
				if (NotaPedidoNroHastaB!="")
				{
					if (NotaPedidoNroDesdeB=="" || int.Parse(NotaPedidoNroDesdeB)>int.Parse(NotaPedidoNroHastaB))
						tbNotaPedidoNroDesdeB.Text = tbNotaPedidoNroHastaB.Text;
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			string s = ""; // device-dependent string, need a FormFeed?
    
			// Allow the user to select a printer.
			PrintDialog pd  = new PrintDialog();
			pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
			if( DialogResult.OK == pd.ShowDialog(this) )
			{
				//for (int i=1; i<71; i++)
				//	s += i.ToString("00") + "-45678901234567890123456789012345678901234567890123456789012345678901234567890\r\n";

				//Ejemplo con el formato del Remito
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += Utilidades.espacios(48) + DateTime.Now.Day.ToString() + "   " + DateTime.Now.Month.ToString() + "   " + DateTime.Now.Year.ToString() + "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += Utilidades.espacios(7) + ("Nombre Cliente" + Utilidades.espacios(34)).Substring(0,34) + Utilidades.espacios(10) + "0001-2212121" + "\r\n";
				s += "\r\n";
				s += Utilidades.espacios(7) + ("Domicilio" + Utilidades.espacios(63)).Substring(0,63)  + "\r\n";
				s += Utilidades.espacios(7) + ("Condicion IVA" + Utilidades.espacios(34)).Substring(0,34) + Utilidades.espacios(10) + "CUIT" + "\r\n";
				s += Utilidades.espacios(17) + ("Condiciones Venta" + Utilidades.espacios(24)).Substring(0,24) + "\r\n";
				s += "\r\n";
				s += Utilidades.espacios(10) + ("Transportista" + Utilidades.espacios(60)).Substring(0,60)  + "\r\n";
				s += "\r\n";
				s += Utilidades.espacios(7) + ("Domicilio" + Utilidades.espacios(63)).Substring(0,63)  + "\r\n";
				s += Utilidades.espacios(7) + ("Condicion IVA" + Utilidades.espacios(34)).Substring(0,34) + Utilidades.espacios(10) + "CUIT" + "\r\n";
				s += "\r\n";
				s += "\r\n";
				//Escribe los items
				for (int i=0; i<18; i++)
				{
					s += ("codigo" + Utilidades.espacios(10)).Substring(0,10) + " " + ("1" + Utilidades.espacios(4)) + " " + ("Descripcion" + Utilidades.espacios(54)).Substring(0,54) + "\r\n";
				}
				//Escribe el pie de pagina
				s += "Items: " + "1" + "    Bultos: " + "1" + "\r\n";
				s += ("Atencion de: " + "Empresa S.A." + Utilidades.espacios(57)).Substring(0,57) + "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				s += "\r\n";
				// Send a printer-specific to the printer.
				RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
			}
		}

        private void cbRBZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkRBMostrarTodosFletes.Checked)
                utilRemito.cargarFletes(this.configuracion, ref cbRBZona, ref cbRBFlete, chkRBMostrarTodosFletes.Checked);
        }

        private void chkRBMostrarTodosFletes_CheckedChanged(object sender, EventArgs e)
        {
            utilRemito.cargarFletes(this.configuracion, ref cbRBZona, ref cbRBFlete, chkRBMostrarTodosFletes.Checked);
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

        private void gbRemitoBase_Enter(object sender, EventArgs e)
        {

        }

        private void butCerrar_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void tbFacturaSuc_Validated(object sender, EventArgs e)
        {
            string suc = tbFacturaSuc.Text;
            Utilidades.agregarCerosIzquierda(ref suc, 4);
            tbFacturaSuc.Text = suc;
        }

        private void tbFacturaNro_Validated(object sender, EventArgs e)
        {
            try
            {
                //Agrega los ceros a la izquiera
                string suc = tbFacturaNro.Text;
                Utilidades.agregarCerosIzquierda(ref suc, 8);
                tbFacturaNro.Text = suc;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
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