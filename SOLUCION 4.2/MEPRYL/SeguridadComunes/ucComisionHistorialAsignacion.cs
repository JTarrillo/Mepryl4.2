using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Comunes
{
	/// <summary>
	/// Summary description for ucArticuloConsulta.
	/// </summary>
	public class ucComisionHistorialAsignacion : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbRubroB;
		private System.Windows.Forms.GroupBox gbProveedor;
		private System.Windows.Forms.ComboBox cbSubRubroB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TabPage tabFiltro3;
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
		private System.Windows.Forms.TabControl tabFiltro;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private Hashtable controles = new Hashtable();
		private Hashtable controlesDet = new Hashtable();
		public bool consultaRapida = false;
		private Control tbCodigoUsado;
		public DataSet dataset = (DataSet) new dsArticulos();
		private System.Windows.Forms.TextBox tbAniosB;
		private System.Windows.Forms.TextBox tbGraduacionAlcoholicaB;
		private System.Windows.Forms.ComboBox cbCosechaB;
		private System.Windows.Forms.ComboBox cbOrigenB;
		private System.Windows.Forms.ComboBox cbVariedadB;
		private System.Windows.Forms.ComboBox cbRegionB;
		private System.Windows.Forms.ComboBox cbCepajeB;
		private System.Windows.Forms.ComboBox cbBodegaB;
		private System.Windows.Forms.ComboBox cbCategoriaB;
		private System.Windows.Forms.ComboBox cbMarcaB;
		private System.Windows.Forms.ComboBox cbTipoB;
		private System.Windows.Forms.TextBox tbSaborB;
		private System.Windows.Forms.TextBox tbContenidoB;
		private System.Windows.Forms.ComboBox cbPresentacionB;
		private System.Windows.Forms.TextBox tbCodigoBarrasB;
		private System.Windows.Forms.TextBox tbCodigoInternoB;
		private System.Windows.Forms.TextBox tbDescripcionB;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn Rubro;
		private System.Windows.Forms.DataGridTextBoxColumn SubRubro;
		private System.Windows.Forms.DataGridTextBoxColumn Precio;
		private System.Windows.Forms.DataGridTextBoxColumn Descripcion;
		private System.Windows.Forms.DataGridTextBoxColumn CodigoInterno;
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbPalabrasClaveB;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox tbStockExistencia;
		private System.Windows.Forms.ComboBox cbRubro;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox tbDescripcion;
		private System.Windows.Forms.Button butRubroRefrescar;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Button butSubRubroRefrescar;
		private KMCurrencyTextBox.KMCurrencyTextBox ktbMargen;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.TextBox tbCodigoBarras;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox tbSabor;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbCodigoInterno;
		private System.Windows.Forms.ComboBox cbCategoria;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox tbAnios;
		private KMCurrencyTextBox.KMCurrencyTextBox ktbPrecioCosto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.ComboBox cbVariedad;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox cbRegion;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label1;
		private KMCurrencyTextBox.KMCurrencyTextBox ktbImporte;
		private System.Windows.Forms.TextBox tbContenido;
		private System.Windows.Forms.Label label40;
		private KMCurrencyTextBox.KMCurrencyTextBox tbGraduacionAlcoholica;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.ComboBox cbPresentacion;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ComboBox cbCosecha;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.ComboBox cbOrigen;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.ComboBox cbCepaje;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.ComboBox cbMarca;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.ComboBox cbBodega;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox tbStockMaximo;
		private System.Windows.Forms.ComboBox cbSubRubro;
		private System.Windows.Forms.TextBox tbStockMinimo;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.CheckBox chkArticuloCompuesto;
		private System.Windows.Forms.GroupBox gbArticuloCompuesto;
		private System.Windows.Forms.TextBox tbCodigoInternoAC;
		private System.Windows.Forms.Label tbDescripcionAC;
		private System.Windows.Forms.Label tbSubRubroAC;
		private System.Windows.Forms.Label tbRubroAC;
		private System.Windows.Forms.Button butBuscarArticuloAC;
		private System.Windows.Forms.Button butAgregarArticuloAC;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TextBox tbCantidadAC;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TextBox tbCodigoBarrasAC;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private Comunes.ucCustomGrid dgSubArticulos;
		private System.Windows.Forms.Button butBorrarArticulosComponentes;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn CodigoInterno1;
		private System.Windows.Forms.DataGridTextBoxColumn CodigoBarras1;
		private System.Windows.Forms.DataGridTextBoxColumn Cantidad1;
		private System.Windows.Forms.DataGridTextBoxColumn Rubro1;
		private System.Windows.Forms.DataGridTextBoxColumn SubRubro1;
		private System.Windows.Forms.DataGridTextBoxColumn Descripcion1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbArticuloCompuesto;
		private System.Windows.Forms.TextBox tbID2;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.DataGridTextBoxColumn Indicador;
		private System.Windows.Forms.Button butAceptar4;
		private System.Windows.Forms.Button butSalir4;
		private System.Windows.Forms.Button butLimpiar4;
		private System.Windows.Forms.Button butBuscar4;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.Button butSalir3;
		private System.Windows.Forms.Button butLimpiar3;
		private System.Windows.Forms.Button butBuscar3;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.Button butSalir2;
		private System.Windows.Forms.Button butLimpiar2;
		private System.Windows.Forms.Button butBuscar2;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.DateTimePicker dtpFechaHastaB;
		private System.Windows.Forms.DateTimePicker dtpFechaDesdeB;
		private System.Windows.Forms.CheckBox chkFechaB;
		private System.Windows.Forms.DataGridTextBoxColumn Fecha;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox cbIndicadorComisionB;
		private System.ComponentModel.IContainer components;

		public ucComisionHistorialAsignacion()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucComisionHistorialAsignacion));
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.butVistaPrevia = new System.Windows.Forms.Button();
            this.butImprimir = new System.Windows.Forms.Button();
            this.butBorrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.Fecha = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Indicador = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CodigoInterno = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Rubro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SubRubro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gbFechaEmision = new System.Windows.Forms.GroupBox();
            this.dtpFechaHastaB = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesdeB = new System.Windows.Forms.DateTimePicker();
            this.chkFechaB = new System.Windows.Forms.CheckBox();
            this.butAceptar4 = new System.Windows.Forms.Button();
            this.butSalir4 = new System.Windows.Forms.Button();
            this.butLimpiar4 = new System.Windows.Forms.Button();
            this.butBuscar4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPalabrasClaveB = new System.Windows.Forms.TextBox();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbIndicadorComisionB = new System.Windows.Forms.ComboBox();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbArticuloCompuesto = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbRubroB = new System.Windows.Forms.ComboBox();
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.cbSubRubroB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDescripcionB = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.butSalir2 = new System.Windows.Forms.Button();
            this.butLimpiar2 = new System.Windows.Forms.Button();
            this.butBuscar2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbAniosB = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbGraduacionAlcoholicaB = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbCosechaB = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbOrigenB = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbVariedadB = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbRegionB = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbCepajeB = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbBodegaB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cbCategoriaB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMarcaB = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTipoB = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbSaborB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbContenidoB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPresentacionB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCodigoBarrasB = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbCodigoInternoB = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butGuardar = new System.Windows.Forms.Button();
            this.butSalir = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.tbSabor = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tbGraduacionAlcoholica = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.butAnterior = new System.Windows.Forms.Button();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tbAnios = new System.Windows.Forms.TextBox();
            this.tbContenido = new System.Windows.Forms.TextBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbPresentacion = new System.Windows.Forms.ComboBox();
            this.tbCodigoInterno = new System.Windows.Forms.TextBox();
            this.cbOrigen = new System.Windows.Forms.ComboBox();
            this.cbVariedad = new System.Windows.Forms.ComboBox();
            this.ktbPrecioCosto = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.ktbMargen = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.cbBodega = new System.Windows.Forms.ComboBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.cbCosecha = new System.Windows.Forms.ComboBox();
            this.butRubroRefrescar = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cbCepaje = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbCodigoBarras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStockMaximo = new System.Windows.Forms.TextBox();
            this.tbStockExistencia = new System.Windows.Forms.TextBox();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.tbStockMinimo = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.butSubRubroRefrescar = new System.Windows.Forms.Button();
            this.ktbImporte = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cbRubro = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cbSubRubro = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.chkArticuloCompuesto = new System.Windows.Forms.CheckBox();
            this.gbArticuloCompuesto = new System.Windows.Forms.GroupBox();
            this.butBorrarArticulosComponentes = new System.Windows.Forms.Button();
            this.tbID2 = new System.Windows.Forms.TextBox();
            this.tbCodigoInternoAC = new System.Windows.Forms.TextBox();
            this.tbDescripcionAC = new System.Windows.Forms.Label();
            this.tbSubRubroAC = new System.Windows.Forms.Label();
            this.tbRubroAC = new System.Windows.Forms.Label();
            this.butBuscarArticuloAC = new System.Windows.Forms.Button();
            this.butAgregarArticuloAC = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.tbCantidadAC = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.tbCodigoBarrasAC = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.dgSubArticulos = new Comunes.ucCustomGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.CodigoInterno1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CodigoBarras1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Cantidad1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Rubro1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SubRubro1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Descripcion1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.butLimpiar = new System.Windows.Forms.Button();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.gbFechaEmision.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbModificacionProveedores.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.gbArticuloCompuesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).BeginInit();
            this.SuspendLayout();
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
            this.tabPrincipal.Size = new System.Drawing.Size(800, 456);
            this.tabPrincipal.TabIndex = 4;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.butVistaPrevia);
            this.tabPage1.Controls.Add(this.butImprimir);
            this.tabPage1.Controls.Add(this.butBorrar);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.dgItems);
            this.tabPage1.Controls.Add(this.tabFiltro);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 4;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Historial Artículos y Comisiones";
            // 
            // butVistaPrevia
            // 
            this.butVistaPrevia.BackColor = System.Drawing.Color.SteelBlue;
            this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
            this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVistaPrevia.Location = new System.Drawing.Point(451, 157);
            this.butVistaPrevia.Name = "butVistaPrevia";
            this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
            this.butVistaPrevia.TabIndex = 10;
            this.butVistaPrevia.Text = "&Vista Previa";
            this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butVistaPrevia.UseVisualStyleBackColor = false;
            this.butVistaPrevia.Visible = false;
            // 
            // butImprimir
            // 
            this.butImprimir.BackColor = System.Drawing.Color.SteelBlue;
            this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimir.ForeColor = System.Drawing.Color.White;
            this.butImprimir.Image = ((System.Drawing.Image)(resources.GetObject("butImprimir.Image")));
            this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimir.Location = new System.Drawing.Point(379, 157);
            this.butImprimir.Name = "butImprimir";
            this.butImprimir.Size = new System.Drawing.Size(64, 23);
            this.butImprimir.TabIndex = 9;
            this.butImprimir.Text = "&Imprimir";
            this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimir.UseVisualStyleBackColor = false;
            this.butImprimir.Visible = false;
            this.butImprimir.Click += new System.EventHandler(this.butImprimir_Click);
            // 
            // butBorrar
            // 
            this.butBorrar.BackColor = System.Drawing.Color.Maroon;
            this.butBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrar.ForeColor = System.Drawing.Color.White;
            this.butBorrar.Image = ((System.Drawing.Image)(resources.GetObject("butBorrar.Image")));
            this.butBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrar.Location = new System.Drawing.Point(644, 157);
            this.butBorrar.Name = "butBorrar";
            this.butBorrar.Size = new System.Drawing.Size(64, 23);
            this.butBorrar.TabIndex = 11;
            this.butBorrar.Text = "&Borrar";
            this.butBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrar.UseVisualStyleBackColor = false;
            this.butBorrar.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // dgItems
            // 
            this.dgItems.AllowNavigation = false;
            this.dgItems.AllowSorting = false;
            this.dgItems.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dgItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItems.CaptionBackColor = System.Drawing.Color.SteelBlue;
            this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.CaptionForeColor = System.Drawing.Color.White;
            this.dgItems.CaptionText = "     Historial Artículos y Comisiones";
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
            this.dgItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgItems.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgItems.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.Size = new System.Drawing.Size(792, 278);
            this.dgItems.TabIndex = 1;
            this.dgItems.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.dgItems;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.Fecha,
            this.Indicador,
            this.CodigoInterno,
            this.Rubro,
            this.SubRubro,
            this.Descripcion,
            this.Precio});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Items";
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.Format = "g";
            this.Fecha.FormatInfo = null;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MappingName = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 115;
            // 
            // Indicador
            // 
            this.Indicador.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Indicador.Format = "";
            this.Indicador.FormatInfo = null;
            this.Indicador.HeaderText = "Indicador";
            this.Indicador.MappingName = "Comisión Indicador";
            this.Indicador.ReadOnly = true;
            this.Indicador.Width = 75;
            // 
            // CodigoInterno
            // 
            this.CodigoInterno.Format = "";
            this.CodigoInterno.FormatInfo = null;
            this.CodigoInterno.HeaderText = "Cód. Interno";
            this.CodigoInterno.MappingName = "Código Interno";
            this.CodigoInterno.ReadOnly = true;
            this.CodigoInterno.Width = 75;
            // 
            // Rubro
            // 
            this.Rubro.Format = "";
            this.Rubro.FormatInfo = null;
            this.Rubro.HeaderText = "Rubro";
            this.Rubro.MappingName = "Rubro";
            this.Rubro.ReadOnly = true;
            this.Rubro.Width = 75;
            // 
            // SubRubro
            // 
            this.SubRubro.Format = "";
            this.SubRubro.FormatInfo = null;
            this.SubRubro.HeaderText = "Sub Rubro";
            this.SubRubro.MappingName = "Sub Rubro";
            this.SubRubro.ReadOnly = true;
            this.SubRubro.Width = 75;
            // 
            // Descripcion
            // 
            this.Descripcion.Format = "";
            this.Descripcion.FormatInfo = null;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MappingName = "Descripción";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 250;
            // 
            // Precio
            // 
            this.Precio.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.Precio.Format = "C";
            this.Precio.FormatInfo = null;
            this.Precio.HeaderText = "Precio";
            this.Precio.MappingName = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 75;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabPage6);
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
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.gbFechaEmision);
            this.tabPage6.Controls.Add(this.butAceptar4);
            this.tabPage6.Controls.Add(this.butSalir4);
            this.tabPage6.Controls.Add(this.butLimpiar4);
            this.tabPage6.Controls.Add(this.butBuscar4);
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.ImageIndex = 0;
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(784, 126);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Búsqueda de Texto";
            // 
            // gbFechaEmision
            // 
            this.gbFechaEmision.Controls.Add(this.dtpFechaHastaB);
            this.gbFechaEmision.Controls.Add(this.dtpFechaDesdeB);
            this.gbFechaEmision.Controls.Add(this.chkFechaB);
            this.gbFechaEmision.Location = new System.Drawing.Point(216, 72);
            this.gbFechaEmision.Name = "gbFechaEmision";
            this.gbFechaEmision.Size = new System.Drawing.Size(200, 48);
            this.gbFechaEmision.TabIndex = 214;
            this.gbFechaEmision.TabStop = false;
            // 
            // dtpFechaHastaB
            // 
            this.dtpFechaHastaB.Enabled = false;
            this.dtpFechaHastaB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHastaB.Location = new System.Drawing.Point(104, 16);
            this.dtpFechaHastaB.Name = "dtpFechaHastaB";
            this.dtpFechaHastaB.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaHastaB.TabIndex = 8;
            this.dtpFechaHastaB.ValueChanged += new System.EventHandler(this.dtpFechaHastaB_ValueChanged);
            // 
            // dtpFechaDesdeB
            // 
            this.dtpFechaDesdeB.Enabled = false;
            this.dtpFechaDesdeB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeB.Location = new System.Drawing.Point(8, 16);
            this.dtpFechaDesdeB.Name = "dtpFechaDesdeB";
            this.dtpFechaDesdeB.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaDesdeB.TabIndex = 7;
            this.dtpFechaDesdeB.ValueChanged += new System.EventHandler(this.dtbFechaDesdeB_ValueChanged);
            // 
            // chkFechaB
            // 
            this.chkFechaB.Location = new System.Drawing.Point(8, 0);
            this.chkFechaB.Name = "chkFechaB";
            this.chkFechaB.Size = new System.Drawing.Size(56, 16);
            this.chkFechaB.TabIndex = 4;
            this.chkFechaB.Text = "Fecha";
            this.chkFechaB.CheckedChanged += new System.EventHandler(this.chkFechaB_CheckedChanged);
            // 
            // butAceptar4
            // 
            this.butAceptar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar4.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar4.Image")));
            this.butAceptar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar4.Location = new System.Drawing.Point(632, 96);
            this.butAceptar4.Name = "butAceptar4";
            this.butAceptar4.Size = new System.Drawing.Size(72, 24);
            this.butAceptar4.TabIndex = 15;
            this.butAceptar4.Text = "&Aceptar";
            this.butAceptar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar4.Visible = false;
            // 
            // butSalir4
            // 
            this.butSalir4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir4.Image = ((System.Drawing.Image)(resources.GetObject("butSalir4.Image")));
            this.butSalir4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir4.Location = new System.Drawing.Point(640, 88);
            this.butSalir4.Name = "butSalir4";
            this.butSalir4.Size = new System.Drawing.Size(64, 23);
            this.butSalir4.TabIndex = 14;
            this.butSalir4.Text = "&Salir";
            this.butSalir4.Click += new System.EventHandler(this.butSalir4_Click_1);
            // 
            // butLimpiar4
            // 
            this.butLimpiar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar4.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar4.Image")));
            this.butLimpiar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar4.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar4.Name = "butLimpiar4";
            this.butLimpiar4.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar4.TabIndex = 13;
            this.butLimpiar4.Text = "&Limpiar";
            this.butLimpiar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar4.Click += new System.EventHandler(this.butLimpiar4_Click_1);
            // 
            // butBuscar4
            // 
            this.butBuscar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar4.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar4.Image")));
            this.butBuscar4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar4.Location = new System.Drawing.Point(640, 16);
            this.butBuscar4.Name = "butBuscar4";
            this.butBuscar4.Size = new System.Drawing.Size(64, 41);
            this.butBuscar4.TabIndex = 12;
            this.butBuscar4.Text = "&Buscar";
            this.butBuscar4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar4.Click += new System.EventHandler(this.butBuscar4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPalabrasClaveB);
            this.groupBox3.Location = new System.Drawing.Point(112, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(408, 48);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Palabras clave";
            // 
            // tbPalabrasClaveB
            // 
            this.tbPalabrasClaveB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPalabrasClaveB.Location = new System.Drawing.Point(8, 16);
            this.tbPalabrasClaveB.Name = "tbPalabrasClaveB";
            this.tbPalabrasClaveB.Size = new System.Drawing.Size(392, 20);
            this.tbPalabrasClaveB.TabIndex = 1;
            this.tbPalabrasClaveB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPalabrasClaveB_KeyPress);
            // 
            // tabFiltro1
            // 
            this.tabFiltro1.Controls.Add(this.groupBox5);
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.Controls.Add(this.groupBox4);
            this.tabFiltro1.Controls.Add(this.groupBox2);
            this.tabFiltro1.Controls.Add(this.gbProveedor);
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.ImageIndex = 1;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbIndicadorComisionB);
            this.groupBox5.Location = new System.Drawing.Point(424, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 48);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Indicador Comisión";
            // 
            // cbIndicadorComisionB
            // 
            this.cbIndicadorComisionB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndicadorComisionB.ItemHeight = 13;
            this.cbIndicadorComisionB.Items.AddRange(new object[] {
            "Todos",
            "Compuesto",
            "Simple"});
            this.cbIndicadorComisionB.Location = new System.Drawing.Point(8, 16);
            this.cbIndicadorComisionB.Name = "cbIndicadorComisionB";
            this.cbIndicadorComisionB.Size = new System.Drawing.Size(184, 21);
            this.cbIndicadorComisionB.TabIndex = 10;
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
            this.butSalir1.Click += new System.EventHandler(this.butSalir1_Click_1);
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
            this.butLimpiar1.Click += new System.EventHandler(this.butLimpiar1_Click_1);
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
            this.butBuscar1.Click += new System.EventHandler(this.butBuscar1_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbArticuloCompuesto);
            this.groupBox4.Location = new System.Drawing.Point(424, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 48);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo de Artículo";
            // 
            // cbArticuloCompuesto
            // 
            this.cbArticuloCompuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArticuloCompuesto.ItemHeight = 13;
            this.cbArticuloCompuesto.Items.AddRange(new object[] {
            "Todos",
            "Compuesto",
            "Simple"});
            this.cbArticuloCompuesto.Location = new System.Drawing.Point(8, 16);
            this.cbArticuloCompuesto.Name = "cbArticuloCompuesto";
            this.cbArticuloCompuesto.Size = new System.Drawing.Size(184, 21);
            this.cbArticuloCompuesto.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbRubroB);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rubro";
            // 
            // cbRubroB
            // 
            this.cbRubroB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRubroB.ItemHeight = 13;
            this.cbRubroB.Location = new System.Drawing.Point(8, 16);
            this.cbRubroB.Name = "cbRubroB";
            this.cbRubroB.Size = new System.Drawing.Size(184, 21);
            this.cbRubroB.TabIndex = 10;
            this.cbRubroB.SelectedIndexChanged += new System.EventHandler(this.cbRubroB_SelectedIndexChanged);
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.cbSubRubroB);
            this.gbProveedor.Location = new System.Drawing.Point(216, 8);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(200, 48);
            this.gbProveedor.TabIndex = 2;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Sub Rubro";
            // 
            // cbSubRubroB
            // 
            this.cbSubRubroB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubRubroB.ItemHeight = 13;
            this.cbSubRubroB.Location = new System.Drawing.Point(8, 16);
            this.cbSubRubroB.Name = "cbSubRubroB";
            this.cbSubRubroB.Size = new System.Drawing.Size(184, 21);
            this.cbSubRubroB.TabIndex = 10;
            this.cbSubRubroB.SelectedIndexChanged += new System.EventHandler(this.cbSubRubroB_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDescripcionB);
            this.groupBox1.Location = new System.Drawing.Point(8, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descripción";
            // 
            // tbDescripcionB
            // 
            this.tbDescripcionB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescripcionB.Location = new System.Drawing.Point(8, 16);
            this.tbDescripcionB.Name = "tbDescripcionB";
            this.tbDescripcionB.Size = new System.Drawing.Size(392, 20);
            this.tbDescripcionB.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.butSalir2);
            this.tabPage3.Controls.Add(this.butLimpiar2);
            this.tabPage3.Controls.Add(this.butBuscar2);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 126);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Filtro Avanzado";
            // 
            // butSalir2
            // 
            this.butSalir2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir2.Image = ((System.Drawing.Image)(resources.GetObject("butSalir2.Image")));
            this.butSalir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir2.Location = new System.Drawing.Point(640, 88);
            this.butSalir2.Name = "butSalir2";
            this.butSalir2.Size = new System.Drawing.Size(64, 23);
            this.butSalir2.TabIndex = 22;
            this.butSalir2.Text = "&Salir";
            this.butSalir2.Click += new System.EventHandler(this.butSalir2_Click_1);
            // 
            // butLimpiar2
            // 
            this.butLimpiar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar2.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar2.Image")));
            this.butLimpiar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar2.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar2.Name = "butLimpiar2";
            this.butLimpiar2.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar2.TabIndex = 21;
            this.butLimpiar2.Text = "&Limpiar";
            this.butLimpiar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar2.Click += new System.EventHandler(this.butLimpiar2_Click_1);
            // 
            // butBuscar2
            // 
            this.butBuscar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar2.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar2.Image")));
            this.butBuscar2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar2.Location = new System.Drawing.Point(640, 16);
            this.butBuscar2.Name = "butBuscar2";
            this.butBuscar2.Size = new System.Drawing.Size(64, 41);
            this.butBuscar2.TabIndex = 20;
            this.butBuscar2.Text = "&Buscar";
            this.butBuscar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar2.Click += new System.EventHandler(this.butBuscar2_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 120);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbAniosB);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.tbGraduacionAlcoholicaB);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.cbCosechaB);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.cbOrigenB);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.cbVariedadB);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.cbRegionB);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.cbCepajeB);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.cbBodegaB);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(624, 94);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Bebidas";
            // 
            // tbAniosB
            // 
            this.tbAniosB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAniosB.Location = new System.Drawing.Point(320, 64);
            this.tbAniosB.Name = "tbAniosB";
            this.tbAniosB.Size = new System.Drawing.Size(96, 20);
            this.tbAniosB.TabIndex = 7;
            this.tbAniosB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(320, 48);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 14);
            this.label23.TabIndex = 166;
            this.label23.Text = "Años";
            // 
            // tbGraduacionAlcoholicaB
            // 
            this.tbGraduacionAlcoholicaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGraduacionAlcoholicaB.Location = new System.Drawing.Point(472, 64);
            this.tbGraduacionAlcoholicaB.Name = "tbGraduacionAlcoholicaB";
            this.tbGraduacionAlcoholicaB.Size = new System.Drawing.Size(96, 20);
            this.tbGraduacionAlcoholicaB.TabIndex = 8;
            this.tbGraduacionAlcoholicaB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(472, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(120, 14);
            this.label24.TabIndex = 164;
            this.label24.Text = "Graduación Alcohólica";
            // 
            // cbCosechaB
            // 
            this.cbCosechaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCosechaB.ItemHeight = 13;
            this.cbCosechaB.Location = new System.Drawing.Point(168, 64);
            this.cbCosechaB.MaxLength = 100;
            this.cbCosechaB.Name = "cbCosechaB";
            this.cbCosechaB.Size = new System.Drawing.Size(136, 21);
            this.cbCosechaB.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(168, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(128, 14);
            this.label21.TabIndex = 162;
            this.label21.Text = "Cosecha";
            // 
            // cbOrigenB
            // 
            this.cbOrigenB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigenB.ItemHeight = 13;
            this.cbOrigenB.Location = new System.Drawing.Point(16, 64);
            this.cbOrigenB.MaxLength = 100;
            this.cbOrigenB.Name = "cbOrigenB";
            this.cbOrigenB.Size = new System.Drawing.Size(136, 21);
            this.cbOrigenB.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(16, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 14);
            this.label20.TabIndex = 160;
            this.label20.Text = "Origen";
            // 
            // cbVariedadB
            // 
            this.cbVariedadB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariedadB.ItemHeight = 13;
            this.cbVariedadB.Location = new System.Drawing.Point(320, 16);
            this.cbVariedadB.MaxLength = 100;
            this.cbVariedadB.Name = "cbVariedadB";
            this.cbVariedadB.Size = new System.Drawing.Size(136, 21);
            this.cbVariedadB.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(320, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 14);
            this.label12.TabIndex = 158;
            this.label12.Text = "Variedad";
            // 
            // cbRegionB
            // 
            this.cbRegionB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegionB.ItemHeight = 13;
            this.cbRegionB.Location = new System.Drawing.Point(472, 16);
            this.cbRegionB.MaxLength = 100;
            this.cbRegionB.Name = "cbRegionB";
            this.cbRegionB.Size = new System.Drawing.Size(136, 21);
            this.cbRegionB.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(472, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 14);
            this.label13.TabIndex = 156;
            this.label13.Text = "Región";
            // 
            // cbCepajeB
            // 
            this.cbCepajeB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCepajeB.ItemHeight = 13;
            this.cbCepajeB.Location = new System.Drawing.Point(168, 16);
            this.cbCepajeB.MaxLength = 100;
            this.cbCepajeB.Name = "cbCepajeB";
            this.cbCepajeB.Size = new System.Drawing.Size(136, 21);
            this.cbCepajeB.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(168, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 14);
            this.label11.TabIndex = 139;
            this.label11.Text = "Cepaje";
            // 
            // cbBodegaB
            // 
            this.cbBodegaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodegaB.ItemHeight = 13;
            this.cbBodegaB.Location = new System.Drawing.Point(16, 16);
            this.cbBodegaB.MaxLength = 100;
            this.cbBodegaB.Name = "cbBodegaB";
            this.cbBodegaB.Size = new System.Drawing.Size(136, 21);
            this.cbBodegaB.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 14);
            this.label10.TabIndex = 135;
            this.label10.Text = "Bodega";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cbCategoriaB);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.cbMarcaB);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.cbTipoB);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.tbSaborB);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.tbContenidoB);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.cbPresentacionB);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.tbCodigoBarrasB);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.tbCodigoInternoB);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(624, 94);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Otros";
            // 
            // cbCategoriaB
            // 
            this.cbCategoriaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoriaB.ItemHeight = 13;
            this.cbCategoriaB.Location = new System.Drawing.Point(320, 16);
            this.cbCategoriaB.MaxLength = 100;
            this.cbCategoriaB.Name = "cbCategoriaB";
            this.cbCategoriaB.Size = new System.Drawing.Size(136, 21);
            this.cbCategoriaB.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(320, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 14);
            this.label3.TabIndex = 198;
            this.label3.Text = "Categoría";
            // 
            // cbMarcaB
            // 
            this.cbMarcaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarcaB.ItemHeight = 13;
            this.cbMarcaB.Location = new System.Drawing.Point(472, 16);
            this.cbMarcaB.MaxLength = 100;
            this.cbMarcaB.Name = "cbMarcaB";
            this.cbMarcaB.Size = new System.Drawing.Size(136, 21);
            this.cbMarcaB.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(472, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 14);
            this.label9.TabIndex = 196;
            this.label9.Text = "Marca";
            // 
            // cbTipoB
            // 
            this.cbTipoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoB.ItemHeight = 13;
            this.cbTipoB.Location = new System.Drawing.Point(320, 64);
            this.cbTipoB.MaxLength = 100;
            this.cbTipoB.Name = "cbTipoB";
            this.cbTipoB.Size = new System.Drawing.Size(136, 21);
            this.cbTipoB.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(320, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 14);
            this.label16.TabIndex = 194;
            this.label16.Text = "Tipo";
            // 
            // tbSaborB
            // 
            this.tbSaborB.Location = new System.Drawing.Point(472, 64);
            this.tbSaborB.Name = "tbSaborB";
            this.tbSaborB.Size = new System.Drawing.Size(136, 20);
            this.tbSaborB.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(472, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 14);
            this.label15.TabIndex = 192;
            this.label15.Text = "Sabor";
            // 
            // tbContenidoB
            // 
            this.tbContenidoB.Location = new System.Drawing.Point(168, 64);
            this.tbContenidoB.Name = "tbContenidoB";
            this.tbContenidoB.Size = new System.Drawing.Size(136, 20);
            this.tbContenidoB.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(168, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 14);
            this.label4.TabIndex = 190;
            this.label4.Text = "Contenido";
            // 
            // cbPresentacionB
            // 
            this.cbPresentacionB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPresentacionB.ItemHeight = 13;
            this.cbPresentacionB.Location = new System.Drawing.Point(16, 64);
            this.cbPresentacionB.MaxLength = 100;
            this.cbPresentacionB.Name = "cbPresentacionB";
            this.cbPresentacionB.Size = new System.Drawing.Size(136, 21);
            this.cbPresentacionB.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 14);
            this.label7.TabIndex = 188;
            this.label7.Text = "Presentación";
            // 
            // tbCodigoBarrasB
            // 
            this.tbCodigoBarrasB.Location = new System.Drawing.Point(168, 16);
            this.tbCodigoBarrasB.Name = "tbCodigoBarrasB";
            this.tbCodigoBarrasB.Size = new System.Drawing.Size(136, 20);
            this.tbCodigoBarrasB.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(168, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 14);
            this.label19.TabIndex = 186;
            this.label19.Text = "Código de Barras";
            // 
            // tbCodigoInternoB
            // 
            this.tbCodigoInternoB.Location = new System.Drawing.Point(16, 16);
            this.tbCodigoInternoB.Name = "tbCodigoInternoB";
            this.tbCodigoInternoB.Size = new System.Drawing.Size(136, 20);
            this.tbCodigoInternoB.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(16, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 14);
            this.label17.TabIndex = 184;
            this.label17.Text = "Código Interno";
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
            this.butSalir3.TabIndex = 16;
            this.butSalir3.Text = "&Salir";
            this.butSalir3.Click += new System.EventHandler(this.butSalir3_Click_1);
            // 
            // butLimpiar3
            // 
            this.butLimpiar3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar3.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar3.Image")));
            this.butLimpiar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar3.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar3.Name = "butLimpiar3";
            this.butLimpiar3.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar3.TabIndex = 15;
            this.butLimpiar3.Text = "&Limpiar";
            this.butLimpiar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar3.Click += new System.EventHandler(this.butLimpiar3_Click_1);
            // 
            // butBuscar3
            // 
            this.butBuscar3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar3.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar3.Image")));
            this.butBuscar3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar3.Location = new System.Drawing.Point(640, 16);
            this.butBuscar3.Name = "butBuscar3";
            this.butBuscar3.Size = new System.Drawing.Size(64, 41);
            this.butBuscar3.TabIndex = 14;
            this.butBuscar3.Text = "&Ordenar";
            this.butBuscar3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar3.Click += new System.EventHandler(this.butBuscar3_Click_1);
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
            "Código Interno",
            "Comisión Indicador",
            "Descripción",
            "Fecha",
            "Precio",
            "Rubro",
            "Sub Rubro",
            "Comisión Indicador"});
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
            "Código Interno",
            "Comisión Indicador",
            "Descripción",
            "Fecha",
            "Precio",
            "Rubro",
            "Sub Rubro",
            "Comisión Indicador"});
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
            this.cbCampoOrden1.ItemHeight = 13;
            this.cbCampoOrden1.Items.AddRange(new object[] {
            "---",
            "Código Interno",
            "Comisión Indicador",
            "Descripción",
            "Fecha",
            "Precio",
            "Rubro",
            "Sub Rubro",
            "Comisión Indicador"});
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
            this.cbCampoOrden3.ItemHeight = 13;
            this.cbCampoOrden3.Items.AddRange(new object[] {
            "---",
            "Código Interno",
            "Comisión Indicador",
            "Descripción",
            "Fecha",
            "Precio",
            "Rubro",
            "Sub Rubro",
            "Comisión Indicador"});
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
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butGuardar);
            this.tabPage2.Controls.Add(this.butSalir);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.gbModificacionProveedores);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.butLimpiar);
            this.tabPage2.ImageIndex = 5;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.Visible = false;
            // 
            // butGuardar
            // 
            this.butGuardar.Enabled = false;
            this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
            this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGuardar.Location = new System.Drawing.Point(552, 403);
            this.butGuardar.Name = "butGuardar";
            this.butGuardar.Size = new System.Drawing.Size(120, 24);
            this.butGuardar.TabIndex = 115;
            this.butGuardar.Text = "&Guardar";
            // 
            // butSalir
            // 
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(680, 403);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(96, 24);
            this.butSalir.TabIndex = 116;
            this.butSalir.Text = "&Salir";
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 114;
            this.pictureBox2.TabStop = false;
            // 
            // gbModificacionProveedores
            // 
            this.gbModificacionProveedores.Controls.Add(this.tabControl2);
            this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbModificacionProveedores.Location = new System.Drawing.Point(0, 16);
            this.gbModificacionProveedores.Name = "gbModificacionProveedores";
            this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 384);
            this.gbModificacionProveedores.TabIndex = 113;
            this.gbModificacionProveedores.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.HotTrack = true;
            this.tabControl2.ImageList = this.imagenesTab;
            this.tabControl2.Location = new System.Drawing.Point(3, 16);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(794, 365);
            this.tabControl2.TabIndex = 114;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.label28);
            this.tabPage7.Controls.Add(this.cbCategoria);
            this.tabPage7.Controls.Add(this.label43);
            this.tabPage7.Controls.Add(this.tbSabor);
            this.tabPage7.Controls.Add(this.label34);
            this.tabPage7.Controls.Add(this.tbGraduacionAlcoholica);
            this.tabPage7.Controls.Add(this.groupBox9);
            this.tabPage7.Controls.Add(this.label35);
            this.tabPage7.Controls.Add(this.label31);
            this.tabPage7.Controls.Add(this.tbAnios);
            this.tabPage7.Controls.Add(this.tbContenido);
            this.tabPage7.Controls.Add(this.tbDescripcion);
            this.tabPage7.Controls.Add(this.label25);
            this.tabPage7.Controls.Add(this.cbPresentacion);
            this.tabPage7.Controls.Add(this.tbCodigoInterno);
            this.tabPage7.Controls.Add(this.cbOrigen);
            this.tabPage7.Controls.Add(this.cbVariedad);
            this.tabPage7.Controls.Add(this.ktbPrecioCosto);
            this.tabPage7.Controls.Add(this.tbID);
            this.tabPage7.Controls.Add(this.ktbMargen);
            this.tabPage7.Controls.Add(this.cbBodega);
            this.tabPage7.Controls.Add(this.cbMarca);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Controls.Add(this.label40);
            this.tabPage7.Controls.Add(this.label36);
            this.tabPage7.Controls.Add(this.cbCosecha);
            this.tabPage7.Controls.Add(this.butRubroRefrescar);
            this.tabPage7.Controls.Add(this.label26);
            this.tabPage7.Controls.Add(this.cbTipo);
            this.tabPage7.Controls.Add(this.label37);
            this.tabPage7.Controls.Add(this.label38);
            this.tabPage7.Controls.Add(this.cbCepaje);
            this.tabPage7.Controls.Add(this.label22);
            this.tabPage7.Controls.Add(this.tbCodigoBarras);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.tbStockMaximo);
            this.tabPage7.Controls.Add(this.tbStockExistencia);
            this.tabPage7.Controls.Add(this.cbRegion);
            this.tabPage7.Controls.Add(this.tbStockMinimo);
            this.tabPage7.Controls.Add(this.label39);
            this.tabPage7.Controls.Add(this.butSubRubroRefrescar);
            this.tabPage7.Controls.Add(this.ktbImporte);
            this.tabPage7.Controls.Add(this.label14);
            this.tabPage7.Controls.Add(this.label30);
            this.tabPage7.Controls.Add(this.label5);
            this.tabPage7.Controls.Add(this.label32);
            this.tabPage7.Controls.Add(this.label6);
            this.tabPage7.Controls.Add(this.label29);
            this.tabPage7.Controls.Add(this.cbRubro);
            this.tabPage7.Controls.Add(this.label33);
            this.tabPage7.Controls.Add(this.cbSubRubro);
            this.tabPage7.Controls.Add(this.label41);
            this.tabPage7.Controls.Add(this.label42);
            this.tabPage7.ImageIndex = 6;
            this.tabPage7.Location = new System.Drawing.Point(4, 23);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(786, 338);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Atributos";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(264, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 14);
            this.label8.TabIndex = 156;
            this.label8.Text = "Años";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(0, 251);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(136, 14);
            this.label28.TabIndex = 145;
            this.label28.Text = "Contenido";
            // 
            // cbCategoria
            // 
            this.cbCategoria.ItemHeight = 13;
            this.cbCategoria.Location = new System.Drawing.Point(536, 74);
            this.cbCategoria.MaxLength = 100;
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(232, 21);
            this.cbCategoria.TabIndex = 157;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(160, 299);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(72, 14);
            this.label43.TabIndex = 186;
            this.label43.Text = "Precio Venta";
            // 
            // tbSabor
            // 
            this.tbSabor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSabor.Location = new System.Drawing.Point(264, 267);
            this.tbSabor.Name = "tbSabor";
            this.tbSabor.Size = new System.Drawing.Size(104, 20);
            this.tbSabor.TabIndex = 159;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(264, 107);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(128, 14);
            this.label34.TabIndex = 133;
            this.label34.Text = "Bodega";
            // 
            // tbGraduacionAlcoholica
            // 
            this.tbGraduacionAlcoholica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGraduacionAlcoholica.CurrencyDecimalSeparator = ",";
            this.tbGraduacionAlcoholica.CurrencyGroupSeparator = ".";
            this.tbGraduacionAlcoholica.CurrencySymbol = "";
            this.tbGraduacionAlcoholica.DecimalsDigits = 2;
            this.tbGraduacionAlcoholica.Location = new System.Drawing.Point(408, 219);
            this.tbGraduacionAlcoholica.Name = "tbGraduacionAlcoholica";
            this.tbGraduacionAlcoholica.Size = new System.Drawing.Size(88, 20);
            this.tbGraduacionAlcoholica.TabIndex = 169;
            this.tbGraduacionAlcoholica.Text = " 0,00";
            this.tbGraduacionAlcoholica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.butSiguiente);
            this.groupBox9.Controls.Add(this.butAnterior);
            this.groupBox9.Controls.Add(this.lblRegistro);
            this.groupBox9.Location = new System.Drawing.Point(536, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(232, 48);
            this.groupBox9.TabIndex = 102;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Registro";
            // 
            // butSiguiente
            // 
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(176, 12);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(48, 24);
            this.butSiguiente.TabIndex = 104;
            this.butSiguiente.Text = "Sig.";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butAnterior
            // 
            this.butAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAnterior.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior.Image")));
            this.butAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAnterior.Location = new System.Drawing.Point(8, 12);
            this.butAnterior.Name = "butAnterior";
            this.butAnterior.Size = new System.Drawing.Size(48, 24);
            this.butAnterior.TabIndex = 103;
            this.butAnterior.Text = "Ant.";
            this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRegistro
            // 
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(64, 24);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(104, 14);
            this.lblRegistro.TabIndex = 102;
            this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(264, 3);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(128, 14);
            this.label35.TabIndex = 117;
            this.label35.Text = "Sub Rubro";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(536, 154);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(128, 14);
            this.label31.TabIndex = 139;
            this.label31.Text = "Origen";
            // 
            // tbAnios
            // 
            this.tbAnios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAnios.Location = new System.Drawing.Point(264, 219);
            this.tbAnios.Name = "tbAnios";
            this.tbAnios.Size = new System.Drawing.Size(96, 20);
            this.tbAnios.TabIndex = 155;
            this.tbAnios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbContenido
            // 
            this.tbContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContenido.Location = new System.Drawing.Point(0, 267);
            this.tbContenido.Name = "tbContenido";
            this.tbContenido.Size = new System.Drawing.Size(232, 20);
            this.tbContenido.TabIndex = 144;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescripcion.Location = new System.Drawing.Point(0, 75);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(232, 20);
            this.tbDescripcion.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(264, 155);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(128, 14);
            this.label25.TabIndex = 152;
            this.label25.Text = "Región";
            // 
            // cbPresentacion
            // 
            this.cbPresentacion.ItemHeight = 13;
            this.cbPresentacion.Location = new System.Drawing.Point(536, 218);
            this.cbPresentacion.MaxLength = 100;
            this.cbPresentacion.Name = "cbPresentacion";
            this.cbPresentacion.Size = new System.Drawing.Size(232, 21);
            this.cbPresentacion.TabIndex = 142;
            // 
            // tbCodigoInterno
            // 
            this.tbCodigoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoInterno.Location = new System.Drawing.Point(264, 75);
            this.tbCodigoInterno.Name = "tbCodigoInterno";
            this.tbCodigoInterno.Size = new System.Drawing.Size(112, 20);
            this.tbCodigoInterno.TabIndex = 163;
            // 
            // cbOrigen
            // 
            this.cbOrigen.ItemHeight = 13;
            this.cbOrigen.Location = new System.Drawing.Point(536, 170);
            this.cbOrigen.MaxLength = 100;
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(232, 21);
            this.cbOrigen.TabIndex = 138;
            // 
            // cbVariedad
            // 
            this.cbVariedad.ItemHeight = 13;
            this.cbVariedad.Location = new System.Drawing.Point(0, 171);
            this.cbVariedad.MaxLength = 100;
            this.cbVariedad.Name = "cbVariedad";
            this.cbVariedad.Size = new System.Drawing.Size(232, 21);
            this.cbVariedad.TabIndex = 153;
            // 
            // ktbPrecioCosto
            // 
            this.ktbPrecioCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ktbPrecioCosto.CurrencyDecimalSeparator = ",";
            this.ktbPrecioCosto.CurrencyGroupSeparator = ".";
            this.ktbPrecioCosto.CurrencySymbol = "$";
            this.ktbPrecioCosto.DecimalsDigits = 2;
            this.ktbPrecioCosto.Location = new System.Drawing.Point(0, 315);
            this.ktbPrecioCosto.Name = "ktbPrecioCosto";
            this.ktbPrecioCosto.Size = new System.Drawing.Size(72, 20);
            this.ktbPrecioCosto.TabIndex = 183;
            this.ktbPrecioCosto.Text = "$ 0,00";
            this.ktbPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ktbPrecioCosto.Leave += new System.EventHandler(this.ktbPrecioCosto_Leave);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(568, 312);
            this.tbID.MaxLength = 2;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(40, 20);
            this.tbID.TabIndex = 104;
            this.tbID.Visible = false;
            // 
            // ktbMargen
            // 
            this.ktbMargen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ktbMargen.CurrencyDecimalSeparator = ",";
            this.ktbMargen.CurrencyGroupSeparator = ".";
            this.ktbMargen.CurrencySymbol = "";
            this.ktbMargen.DecimalsDigits = 2;
            this.ktbMargen.Location = new System.Drawing.Point(88, 315);
            this.ktbMargen.Name = "ktbMargen";
            this.ktbMargen.Size = new System.Drawing.Size(56, 20);
            this.ktbMargen.TabIndex = 184;
            this.ktbMargen.Text = " 0,00";
            this.ktbMargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ktbMargen.Leave += new System.EventHandler(this.ktbMargen_Leave);
            // 
            // cbBodega
            // 
            this.cbBodega.ItemHeight = 13;
            this.cbBodega.Location = new System.Drawing.Point(264, 123);
            this.cbBodega.MaxLength = 100;
            this.cbBodega.Name = "cbBodega";
            this.cbBodega.Size = new System.Drawing.Size(232, 21);
            this.cbBodega.TabIndex = 132;
            // 
            // cbMarca
            // 
            this.cbMarca.ItemHeight = 13;
            this.cbMarca.Location = new System.Drawing.Point(0, 123);
            this.cbMarca.MaxLength = 100;
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(232, 21);
            this.cbMarca.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(384, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 14);
            this.label1.TabIndex = 166;
            this.label1.Text = "Código de Barras";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(536, 250);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 14);
            this.label40.TabIndex = 180;
            this.label40.Text = "Stock Min.";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(0, 3);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(136, 14);
            this.label36.TabIndex = 91;
            this.label36.Text = "Rubro";
            // 
            // cbCosecha
            // 
            this.cbCosecha.ItemHeight = 13;
            this.cbCosecha.Location = new System.Drawing.Point(0, 219);
            this.cbCosecha.MaxLength = 100;
            this.cbCosecha.Name = "cbCosecha";
            this.cbCosecha.Size = new System.Drawing.Size(232, 21);
            this.cbCosecha.TabIndex = 140;
            // 
            // butRubroRefrescar
            // 
            this.butRubroRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRubroRefrescar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butRubroRefrescar.Location = new System.Drawing.Point(232, 19);
            this.butRubroRefrescar.Name = "butRubroRefrescar";
            this.butRubroRefrescar.Size = new System.Drawing.Size(24, 24);
            this.butRubroRefrescar.TabIndex = 167;
            this.butRubroRefrescar.Visible = false;
            this.butRubroRefrescar.Click += new System.EventHandler(this.butRubroRefrescar_Click);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(384, 203);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(120, 14);
            this.label26.TabIndex = 150;
            this.label26.Text = "Graduación Alcohólica";
            // 
            // cbTipo
            // 
            this.cbTipo.ItemHeight = 13;
            this.cbTipo.Location = new System.Drawing.Point(376, 267);
            this.cbTipo.MaxLength = 100;
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(120, 21);
            this.cbTipo.TabIndex = 161;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(0, 59);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(136, 14);
            this.label37.TabIndex = 87;
            this.label37.Text = "Descripción";
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(696, 250);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(64, 14);
            this.label38.TabIndex = 182;
            this.label38.Text = "Existencia";
            // 
            // cbCepaje
            // 
            this.cbCepaje.ItemHeight = 13;
            this.cbCepaje.Location = new System.Drawing.Point(536, 122);
            this.cbCepaje.MaxLength = 100;
            this.cbCepaje.Name = "cbCepaje";
            this.cbCepaje.Size = new System.Drawing.Size(232, 21);
            this.cbCepaje.TabIndex = 136;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(0, 155);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(128, 14);
            this.label22.TabIndex = 154;
            this.label22.Text = "Variedad";
            // 
            // tbCodigoBarras
            // 
            this.tbCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoBarras.Location = new System.Drawing.Point(384, 75);
            this.tbCodigoBarras.Name = "tbCodigoBarras";
            this.tbCodigoBarras.Size = new System.Drawing.Size(112, 20);
            this.tbCodigoBarras.TabIndex = 165;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(264, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 14);
            this.label2.TabIndex = 164;
            this.label2.Text = "Código Interno";
            // 
            // tbStockMaximo
            // 
            this.tbStockMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStockMaximo.Location = new System.Drawing.Point(616, 266);
            this.tbStockMaximo.Name = "tbStockMaximo";
            this.tbStockMaximo.Size = new System.Drawing.Size(72, 20);
            this.tbStockMaximo.TabIndex = 178;
            this.tbStockMaximo.Text = "0";
            this.tbStockMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbStockExistencia
            // 
            this.tbStockExistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStockExistencia.Location = new System.Drawing.Point(696, 266);
            this.tbStockExistencia.Name = "tbStockExistencia";
            this.tbStockExistencia.Size = new System.Drawing.Size(72, 20);
            this.tbStockExistencia.TabIndex = 179;
            this.tbStockExistencia.Text = "0";
            this.tbStockExistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbRegion
            // 
            this.cbRegion.ItemHeight = 13;
            this.cbRegion.Location = new System.Drawing.Point(264, 171);
            this.cbRegion.MaxLength = 100;
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(232, 21);
            this.cbRegion.TabIndex = 151;
            // 
            // tbStockMinimo
            // 
            this.tbStockMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStockMinimo.Location = new System.Drawing.Point(536, 266);
            this.tbStockMinimo.Name = "tbStockMinimo";
            this.tbStockMinimo.Size = new System.Drawing.Size(72, 20);
            this.tbStockMinimo.TabIndex = 177;
            this.tbStockMinimo.Text = "0";
            this.tbStockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(616, 250);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 14);
            this.label39.TabIndex = 181;
            this.label39.Text = "Stock. Max.";
            // 
            // butSubRubroRefrescar
            // 
            this.butSubRubroRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSubRubroRefrescar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butSubRubroRefrescar.Location = new System.Drawing.Point(496, 19);
            this.butSubRubroRefrescar.Name = "butSubRubroRefrescar";
            this.butSubRubroRefrescar.Size = new System.Drawing.Size(24, 24);
            this.butSubRubroRefrescar.TabIndex = 168;
            this.butSubRubroRefrescar.Visible = false;
            this.butSubRubroRefrescar.Click += new System.EventHandler(this.butSubRubroRefrescar_Click);
            // 
            // ktbImporte
            // 
            this.ktbImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ktbImporte.CurrencyDecimalSeparator = ",";
            this.ktbImporte.CurrencyGroupSeparator = ".";
            this.ktbImporte.CurrencySymbol = "$";
            this.ktbImporte.DecimalsDigits = 2;
            this.ktbImporte.Location = new System.Drawing.Point(160, 315);
            this.ktbImporte.Name = "ktbImporte";
            this.ktbImporte.Size = new System.Drawing.Size(72, 20);
            this.ktbImporte.TabIndex = 148;
            this.ktbImporte.Text = "$ 0,00";
            this.ktbImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ktbImporte.Leave += new System.EventHandler(this.ktbImporte_Leave);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(536, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 14);
            this.label14.TabIndex = 158;
            this.label14.Text = "Categoría";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(0, 203);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(128, 14);
            this.label30.TabIndex = 141;
            this.label30.Text = "Cosecha";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(376, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 14);
            this.label5.TabIndex = 162;
            this.label5.Text = "Tipo";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(536, 106);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(128, 14);
            this.label32.TabIndex = 137;
            this.label32.Text = "Cepaje";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(264, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 14);
            this.label6.TabIndex = 160;
            this.label6.Text = "Sabor";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(536, 202);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(128, 14);
            this.label29.TabIndex = 143;
            this.label29.Text = "Presentación";
            // 
            // cbRubro
            // 
            this.cbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRubro.ItemHeight = 13;
            this.cbRubro.Location = new System.Drawing.Point(0, 19);
            this.cbRubro.MaxLength = 100;
            this.cbRubro.Name = "cbRubro";
            this.cbRubro.Size = new System.Drawing.Size(232, 21);
            this.cbRubro.TabIndex = 3;
            this.cbRubro.SelectedIndexChanged += new System.EventHandler(this.cbRubro_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(0, 107);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(128, 14);
            this.label33.TabIndex = 135;
            this.label33.Text = "Marca";
            // 
            // cbSubRubro
            // 
            this.cbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubRubro.ItemHeight = 13;
            this.cbSubRubro.Location = new System.Drawing.Point(264, 19);
            this.cbSubRubro.MaxLength = 100;
            this.cbSubRubro.Name = "cbSubRubro";
            this.cbSubRubro.Size = new System.Drawing.Size(232, 21);
            this.cbSubRubro.TabIndex = 4;
            this.cbSubRubro.SelectedIndexChanged += new System.EventHandler(this.cbSubRubro_SelectedIndexChanged);
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(80, 299);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(64, 14);
            this.label41.TabIndex = 188;
            this.label41.Text = "Margen %";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(0, 299);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(72, 14);
            this.label42.TabIndex = 187;
            this.label42.Text = "Precio Costo";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.chkArticuloCompuesto);
            this.tabPage8.Controls.Add(this.gbArticuloCompuesto);
            this.tabPage8.ImageIndex = 7;
            this.tabPage8.Location = new System.Drawing.Point(4, 23);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(786, 338);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Artículo Compuesto";
            // 
            // chkArticuloCompuesto
            // 
            this.chkArticuloCompuesto.Location = new System.Drawing.Point(8, 0);
            this.chkArticuloCompuesto.Name = "chkArticuloCompuesto";
            this.chkArticuloCompuesto.Size = new System.Drawing.Size(160, 24);
            this.chkArticuloCompuesto.TabIndex = 2;
            this.chkArticuloCompuesto.Text = "Es un Artículo Compuesto";
            this.chkArticuloCompuesto.CheckedChanged += new System.EventHandler(this.chkArticuloCompuesto_CheckedChanged);
            // 
            // gbArticuloCompuesto
            // 
            this.gbArticuloCompuesto.Controls.Add(this.butBorrarArticulosComponentes);
            this.gbArticuloCompuesto.Controls.Add(this.tbID2);
            this.gbArticuloCompuesto.Controls.Add(this.tbCodigoInternoAC);
            this.gbArticuloCompuesto.Controls.Add(this.tbDescripcionAC);
            this.gbArticuloCompuesto.Controls.Add(this.tbSubRubroAC);
            this.gbArticuloCompuesto.Controls.Add(this.tbRubroAC);
            this.gbArticuloCompuesto.Controls.Add(this.butBuscarArticuloAC);
            this.gbArticuloCompuesto.Controls.Add(this.butAgregarArticuloAC);
            this.gbArticuloCompuesto.Controls.Add(this.label27);
            this.gbArticuloCompuesto.Controls.Add(this.label44);
            this.gbArticuloCompuesto.Controls.Add(this.label45);
            this.gbArticuloCompuesto.Controls.Add(this.tbCantidadAC);
            this.gbArticuloCompuesto.Controls.Add(this.label46);
            this.gbArticuloCompuesto.Controls.Add(this.tbCodigoBarrasAC);
            this.gbArticuloCompuesto.Controls.Add(this.label47);
            this.gbArticuloCompuesto.Controls.Add(this.label48);
            this.gbArticuloCompuesto.Controls.Add(this.dgSubArticulos);
            this.gbArticuloCompuesto.Enabled = false;
            this.gbArticuloCompuesto.Location = new System.Drawing.Point(0, 0);
            this.gbArticuloCompuesto.Name = "gbArticuloCompuesto";
            this.gbArticuloCompuesto.Size = new System.Drawing.Size(768, 344);
            this.gbArticuloCompuesto.TabIndex = 1;
            this.gbArticuloCompuesto.TabStop = false;
            // 
            // butBorrarArticulosComponentes
            // 
            this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarArticulosComponentes.Enabled = false;
            this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
            this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(192, 68);
            this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
            this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
            this.butBorrarArticulosComponentes.TabIndex = 133;
            this.butBorrarArticulosComponentes.Text = "&Borrar";
            this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarArticulosComponentes.UseVisualStyleBackColor = false;
            this.butBorrarArticulosComponentes.Click += new System.EventHandler(this.butBorrarArticulosComponentes_Click);
            // 
            // tbID2
            // 
            this.tbID2.Location = new System.Drawing.Point(656, 24);
            this.tbID2.Name = "tbID2";
            this.tbID2.Size = new System.Drawing.Size(64, 20);
            this.tbID2.TabIndex = 131;
            this.tbID2.Visible = false;
            // 
            // tbCodigoInternoAC
            // 
            this.tbCodigoInternoAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoInternoAC.Enabled = false;
            this.tbCodigoInternoAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoInternoAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoInternoAC.Location = new System.Drawing.Point(8, 40);
            this.tbCodigoInternoAC.Name = "tbCodigoInternoAC";
            this.tbCodigoInternoAC.Size = new System.Drawing.Size(88, 21);
            this.tbCodigoInternoAC.TabIndex = 1;
            this.tbCodigoInternoAC.Enter += new System.EventHandler(this.tbCodigoInternoAC_FocusEnter);
            this.tbCodigoInternoAC.Leave += new System.EventHandler(this.tbCodigoInternoAC_Leave);
            this.tbCodigoInternoAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoInternoAC_KeyPress);
            // 
            // tbDescripcionAC
            // 
            this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcionAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbDescripcionAC.Location = new System.Drawing.Point(528, 40);
            this.tbDescripcionAC.Name = "tbDescripcionAC";
            this.tbDescripcionAC.Size = new System.Drawing.Size(224, 24);
            this.tbDescripcionAC.TabIndex = 130;
            this.tbDescripcionAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSubRubroAC
            // 
            this.tbSubRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSubRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbSubRubroAC.Location = new System.Drawing.Point(408, 40);
            this.tbSubRubroAC.Name = "tbSubRubroAC";
            this.tbSubRubroAC.Size = new System.Drawing.Size(112, 24);
            this.tbSubRubroAC.TabIndex = 129;
            this.tbSubRubroAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbRubroAC
            // 
            this.tbRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbRubroAC.Location = new System.Drawing.Point(288, 40);
            this.tbRubroAC.Name = "tbRubroAC";
            this.tbRubroAC.Size = new System.Drawing.Size(112, 24);
            this.tbRubroAC.TabIndex = 128;
            this.tbRubroAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butBuscarArticuloAC
            // 
            this.butBuscarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarArticuloAC.Enabled = false;
            this.butBuscarArticuloAC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butBuscarArticuloAC.Location = new System.Drawing.Point(232, 40);
            this.butBuscarArticuloAC.Name = "butBuscarArticuloAC";
            this.butBuscarArticuloAC.Size = new System.Drawing.Size(24, 24);
            this.butBuscarArticuloAC.TabIndex = 5;
            this.butBuscarArticuloAC.UseVisualStyleBackColor = false;
            this.butBuscarArticuloAC.Enter += new System.EventHandler(this.butBuscarArticuloAC_Enter);
            this.butBuscarArticuloAC.Click += new System.EventHandler(this.butBuscarArticuloAC_Click);
            this.butBuscarArticuloAC.Leave += new System.EventHandler(this.butBuscarArticuloAC_Leave);
            // 
            // butAgregarArticuloAC
            // 
            this.butAgregarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butAgregarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butAgregarArticuloAC.Location = new System.Drawing.Point(720, 16);
            this.butAgregarArticuloAC.Name = "butAgregarArticuloAC";
            this.butAgregarArticuloAC.Size = new System.Drawing.Size(24, 24);
            this.butAgregarArticuloAC.TabIndex = 4;
            this.butAgregarArticuloAC.UseVisualStyleBackColor = false;
            this.butAgregarArticuloAC.Visible = false;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(528, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 16);
            this.label27.TabIndex = 124;
            this.label27.Text = "Descripción";
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(408, 24);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(100, 16);
            this.label44.TabIndex = 122;
            this.label44.Text = "Sub Rubro";
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(288, 24);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(100, 16);
            this.label45.TabIndex = 120;
            this.label45.Text = "Rubro";
            // 
            // tbCantidadAC
            // 
            this.tbCantidadAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCantidadAC.Enabled = false;
            this.tbCantidadAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidadAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCantidadAC.Location = new System.Drawing.Point(184, 40);
            this.tbCantidadAC.Name = "tbCantidadAC";
            this.tbCantidadAC.Size = new System.Drawing.Size(48, 21);
            this.tbCantidadAC.TabIndex = 3;
            this.tbCantidadAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCantidadAC.Enter += new System.EventHandler(this.tbCantidadAC_Enter);
            this.tbCantidadAC.Leave += new System.EventHandler(this.tbCantidadAC_Leave);
            this.tbCantidadAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidadAC_KeyPress);
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(184, 24);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(64, 16);
            this.label46.TabIndex = 118;
            this.label46.Text = "Cantidad";
            // 
            // tbCodigoBarrasAC
            // 
            this.tbCodigoBarrasAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoBarrasAC.Enabled = false;
            this.tbCodigoBarrasAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoBarrasAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoBarrasAC.Location = new System.Drawing.Point(96, 40);
            this.tbCodigoBarrasAC.Name = "tbCodigoBarrasAC";
            this.tbCodigoBarrasAC.Size = new System.Drawing.Size(88, 21);
            this.tbCodigoBarrasAC.TabIndex = 2;
            this.tbCodigoBarrasAC.Enter += new System.EventHandler(this.tbCodigoBarrasAC_Enter);
            this.tbCodigoBarrasAC.Leave += new System.EventHandler(this.tbCodigoBarrasAC_Leave);
            this.tbCodigoBarrasAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoBarrasAC_KeyPress);
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(96, 24);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(100, 16);
            this.label47.TabIndex = 116;
            this.label47.Text = "Código de Barras";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(8, 24);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(100, 16);
            this.label48.TabIndex = 114;
            this.label48.Text = "Código Interno";
            // 
            // dgSubArticulos
            // 
            this.dgSubArticulos.AllowSorting = false;
            this.dgSubArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSubArticulos.CaptionBackColor = System.Drawing.Color.SteelBlue;
            this.dgSubArticulos.CaptionForeColor = System.Drawing.Color.White;
            this.dgSubArticulos.CaptionText = "Artículos Componentes";
            this.dgSubArticulos.DataMember = "";
            this.dgSubArticulos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgSubArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSubArticulos.Location = new System.Drawing.Point(3, 69);
            this.dgSubArticulos.Name = "dgSubArticulos";
            this.dgSubArticulos.Size = new System.Drawing.Size(762, 272);
            this.dgSubArticulos.TabIndex = 6;
            this.dgSubArticulos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgSubArticulos.Visible = false;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.dgSubArticulos;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.CodigoInterno1,
            this.CodigoBarras1,
            this.Cantidad1,
            this.Rubro1,
            this.SubRubro1,
            this.Descripcion1});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "v_Articulo";
            // 
            // CodigoInterno1
            // 
            this.CodigoInterno1.Format = "";
            this.CodigoInterno1.FormatInfo = null;
            this.CodigoInterno1.HeaderText = "Cod.Interno";
            this.CodigoInterno1.MappingName = "Código Interno";
            this.CodigoInterno1.ReadOnly = true;
            this.CodigoInterno1.Width = 75;
            // 
            // CodigoBarras1
            // 
            this.CodigoBarras1.Format = "";
            this.CodigoBarras1.FormatInfo = null;
            this.CodigoBarras1.HeaderText = "Cod.Barras";
            this.CodigoBarras1.MappingName = "Código de Barras";
            this.CodigoBarras1.ReadOnly = true;
            this.CodigoBarras1.Width = 75;
            // 
            // Cantidad1
            // 
            this.Cantidad1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.Cantidad1.Format = "";
            this.Cantidad1.FormatInfo = null;
            this.Cantidad1.HeaderText = "Cantidad";
            this.Cantidad1.MappingName = "Cantidad";
            this.Cantidad1.Width = 75;
            // 
            // Rubro1
            // 
            this.Rubro1.Format = "";
            this.Rubro1.FormatInfo = null;
            this.Rubro1.HeaderText = "Rubro";
            this.Rubro1.MappingName = "Rubro";
            this.Rubro1.ReadOnly = true;
            this.Rubro1.Width = 75;
            // 
            // SubRubro1
            // 
            this.SubRubro1.Format = "";
            this.SubRubro1.FormatInfo = null;
            this.SubRubro1.HeaderText = "Sub Rubro";
            this.SubRubro1.MappingName = "Sub Rubro";
            this.SubRubro1.ReadOnly = true;
            this.SubRubro1.Width = 75;
            // 
            // Descripcion1
            // 
            this.Descripcion1.Format = "";
            this.Descripcion1.FormatInfo = null;
            this.Descripcion1.HeaderText = "Descripción";
            this.Descripcion1.MappingName = "Descripción";
            this.Descripcion1.ReadOnly = true;
            this.Descripcion1.Width = 300;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(792, 16);
            this.label18.TabIndex = 95;
            this.label18.Text = "     Detalle del Artículo";
            // 
            // butLimpiar
            // 
            this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar.Location = new System.Drawing.Point(808, 216);
            this.butLimpiar.Name = "butLimpiar";
            this.butLimpiar.Size = new System.Drawing.Size(96, 24);
            this.butLimpiar.TabIndex = 11;
            this.butLimpiar.Text = "&Limpiar";
            this.butLimpiar.Visible = false;
            // 
            // ucComisionHistorialAsignacion
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucComisionHistorialAsignacion";
            this.Size = new System.Drawing.Size(800, 456);
            this.Load += new System.EventHandler(this.ucArticuloConsulta_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.gbFechaEmision.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabFiltro1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbProveedor.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbModificacionProveedores.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.gbArticuloCompuesto.ResumeLayout(false);
            this.gbArticuloCompuesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				UtilUI.llenarCombo(ref cbRubroB, this.conexion, "sp_getAllRubros", "Todos", 0);
				llenarSubRubros();
				UtilUI.llenarCombo(ref cbCategoriaB, this.conexion, "sp_getAlltv_ArticuloCategorias", "Todas", 0);
				UtilUI.llenarCombo(ref cbMarcaB, this.conexion, "sp_getAlltv_ArticuloMarcas", "Todas", 0);
				UtilUI.llenarCombo(ref cbBodegaB, this.conexion, "sp_getAlltv_ArticuloBodegas", "Todas", 0);
				UtilUI.llenarCombo(ref cbCepajeB, this.conexion, "sp_getAlltv_ArticuloCepajes", "Todos", 0);
				UtilUI.llenarCombo(ref cbVariedadB, this.conexion, "sp_getAlltv_ArticuloVariedads", "Todas", 0);
				UtilUI.llenarCombo(ref cbRegionB, this.conexion, "sp_getAlltv_ArticuloRegions", "Todas", 0);
				UtilUI.llenarCombo(ref cbOrigenB, this.conexion, "sp_getAlltv_ArticuloOrigens", "Todos", 0);
				UtilUI.llenarCombo(ref cbCosechaB, this.conexion, "sp_getAlltv_ArticuloCosechas", "Todas", 0);
				UtilUI.llenarCombo(ref cbPresentacionB, this.conexion, "sp_getAlltv_ArticuloPresentacions", "Todas", 0);
				UtilUI.llenarCombo(ref cbTipoB, this.conexion, "sp_getAlltv_ArticuloTipos", "Todos", 0);
				UtilUI.llenarCombo(ref cbIndicadorComisionB, this.conexion, "sp_getAllComisionIndicadorParaComboLimpio", "Todos", 0);
				cbArticuloCompuesto.SelectedIndex = 0;

				//Guarda las referencias a los controles
				//Controles de Busqueda
				controles.Add("Bodega", cbBodegaB);
				controles.Add("Marca", cbMarcaB);
				controles.Add("Cepaje", cbCepajeB);
				controles.Add("Origen", cbOrigenB);
				controles.Add("Cosecha", cbCosechaB);
				controles.Add("Presentación", cbPresentacionB);
				controles.Add("Contenido", tbContenidoB);
				controles.Add("Precio", new Control());
				controles.Add("Graduación Alcohólica", tbGraduacionAlcoholicaB);
				controles.Add("Región", cbRegionB);
				controles.Add("Variedad", cbVariedadB);
				controles.Add("Años", tbAniosB);
				controles.Add("Categoría", cbCategoriaB);
				controles.Add("Sabor", tbSaborB);
				controles.Add("Tipo", cbTipoB);
				controles.Add("Descripción", tbDescripcionB);
				controles.Add("Código Interno", tbCodigoInternoB);
				controles.Add("Código de Barras", tbCodigoBarrasB);
				//Controles de Detalle
				controlesDet.Add("Bodega", cbBodega);
				controlesDet.Add("Marca", cbMarca);
				controlesDet.Add("Cepaje", cbCepaje);
				controlesDet.Add("Origen", cbOrigen);
				controlesDet.Add("Cosecha", cbCosecha);
				controlesDet.Add("Presentación", cbPresentacion);
				controlesDet.Add("Contenido", tbContenido);
				controlesDet.Add("Precio", ktbImporte);
				controlesDet.Add("Graduación Alcohólica", tbGraduacionAlcoholica);
				controlesDet.Add("Región", cbRegion);
				controlesDet.Add("Variedad", cbVariedad);
				controlesDet.Add("Años", tbAnios);
				controlesDet.Add("Categoría", cbCategoria);
				controlesDet.Add("Sabor", tbSabor);
				controlesDet.Add("Tipo", cbTipo);
				controlesDet.Add("Descripción", tbDescripcion);
				controlesDet.Add("Código Interno", tbCodigoInterno);
				controlesDet.Add("Código de Barras", tbCodigoBarras);

				//Establece los campos activos
				activarCampos();

				acomodarCombosOrden();

				//Define el tipo de consulta
				if (consultaRapida)
				{
					butSalir4.Visible = false;
					butAceptar4.Visible = true;
				}
				else
				{
					butSalir4.Visible = true;
					butAceptar4.Visible = false;
				}

				//Asigna la tabla a la datagrid
				dgSubArticulos.DataSource = (DataTable)dataset.Tables["v_Articulo"];
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Lee los campos del subrubro seleccionado y activa los campos que le corresponden
		private void activarCampos()
		{
			try
			{
				if (cbSubRubroB.SelectedValue!=null)
				{
					//Lee los campos del subrubro
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@subRubroID", cbSubRubroB.SelectedValue.ToString());
					SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllSubRubroCampoBySubRubro", param);

					//Primero desactiva todos los campos
					Object enume = controles.Keys.GetEnumerator();
					//Si no hay sub rubor seleccionado activa todos los campos
					bool enabled = cbSubRubroB.SelectedValue.ToString()=="0" ? true : false;
					while (((IEnumerator)enume).MoveNext())
					{
						((Control)controles[((IEnumerator)enume).Current]).Enabled = enabled;
					}

					if (dr.HasRows)
					{
						while (dr.Read())
						{
							if (controles.ContainsKey(dr["campoEtiqueta"].ToString()))
								((Control)controles[dr["campoEtiqueta"].ToString()]).Enabled = true;
						}
					}
					dr.Close();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		//Activa los campos del formulario de Detalle
		private void activarCamposDet()
		{
			try
			{
				if (cbSubRubro.SelectedValue!=null)
				{
					//Lee los campos del subrubro
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@subRubroID", cbSubRubro.SelectedValue.ToString());
					SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllSubRubroCampoBySubRubro", param);

					//Primero desactiva todos los campos
					Object enume = controlesDet.Keys.GetEnumerator();
					//Si no hay sub rubor seleccionado activa todos los campos
					bool enabled = cbSubRubro.SelectedValue.ToString()=="0" ? true : false;
					while (((IEnumerator)enume).MoveNext())
					{
						((Control)controlesDet[((IEnumerator)enume).Current]).Enabled = enabled;
					}

					if (dr.HasRows)
					{
						while (dr.Read())
						{
							if (controlesDet.ContainsKey(dr["campoEtiqueta"].ToString()))
								((Control)controlesDet[dr["campoEtiqueta"].ToString()]).Enabled = true;
						}
					}
					dr.Close();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Llena el combo del fomulario de busqueda
		private void llenarSubRubros()
		{
			try
			{
				if (cbRubroB.SelectedValue!=null)
				{
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@rubroID", new System.Guid(cbRubroB.SelectedValue.ToString()));
					UtilUI.llenarCombo(ref cbSubRubroB, this.conexion, "sp_getAllSubRubros", "Todos", 0, param);

					if (cbSubRubroB.Items.Count>0)
						cbSubRubroB.SelectedIndex = 0;

					activarCampos();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		//Llena el combo del fomulario de Detalle
		private void llenarSubRubrosDet()
		{
			try
			{
				if (cbRubro.SelectedValue!=null)
				{
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@rubroID", new System.Guid(cbRubro.SelectedValue.ToString()));
					UtilUI.llenarCombo(ref cbSubRubro, this.conexion, "sp_getAllSubRubros", "", -1, param);

					if (cbSubRubro.Items.Count>0)
						cbSubRubro.SelectedIndex = 0;

					activarCamposDet();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cbRubroB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarSubRubros();
		}

		private void cbSubRubroB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			activarCampos();
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
				dgItems.DataSource = dsItems.Tables["Items"];
				dgItems.Visible = true;

				//close connection
				oConn.Close();

				if (this.consultaRapida)
				{
					if (dvItems.Table.Rows.Count>0)
						butAceptar4.Select();
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
				string sql = "SELECT     dbo.Rubro.descripcion AS Rubro, dbo.SubRubro.descripcion AS [Sub Rubro], dbo.tv_ArticuloBodega.descripcion AS Bodega, " +
					"dbo.tv_ArticuloMarca.descripcion AS Marca, dbo.tv_ArticuloCepaje.descripcion AS Cepaje, dbo.tv_ArticuloOrigen.descripcion AS Origen, " + 
					"dbo.tv_ArticuloCosecha.descripcion AS Cosecha, dbo.tv_ArticuloPresentacion.descripcion AS Presentación, " +
					"dbo.tv_ArticuloRegion.descripcion AS Región, dbo.tv_ArticuloVariedad.descripcion AS Variedad, dbo.tv_ArticuloCategoria.descripcion AS Categoría, " +
					"dbo.tv_ArticuloTipo.descripcion AS Tipo, dbo.Articulo.bodegaID, dbo.Articulo.marcaID, dbo.Articulo.cepajeID, dbo.Articulo.origenID, " +
					"dbo.Articulo.cosechaID, dbo.Articulo.presentacionID, dbo.Articulo.contenido, dbo.Articulo.precio, " +
					"dbo.Articulo.graduacionAlcoholica AS [Graduación Alcohólica], dbo.Articulo.regionID, dbo.Articulo.variedadID, dbo.Articulo.anios AS Años, " +
					"dbo.Articulo.categoriaID, dbo.Articulo.sabor, dbo.Articulo.tipoID, dbo.Articulo.descripcion AS Descripción, dbo.Articulo.rubroID, dbo.Articulo.subRubroID, " +
					"dbo.Articulo.codigoInterno AS [Código Interno], dbo.Articulo.codigoBarras AS [Código de Barras], " +
					"CASE dbo.Articulo.articuloCompuestoID WHEN 0 THEN 'No' WHEN 1 THEN 'Si' END AS Compuesto, dbo.Articulo.stockMinimo AS [Stock Min.], " +
					"dbo.Articulo.stockMaximo AS [Stock Max.], dbo.Articulo.stockExistencia AS [Stock Exist.], dbo.Articulo.precioCosto AS [P. Costo], dbo.Articulo.margen, " +
					"dbo.ComisionHistorialCambioIndicadorArticulo.articuloID, dbo.ComisionHistorialCambioIndicadorArticulo.indicadorComisionID, " +
					"dbo.ComisionIndicador.descripcion AS [Comisión Indicador], dbo.ComisionHistorialCambioIndicadorArticulo.fecha AS Fecha, " +
					"dbo.ComisionHistorialCambioIndicadorArticulo.id " +
					"FROM         dbo.Articulo INNER JOIN " +
					"dbo.ComisionHistorialCambioIndicadorArticulo ON dbo.Articulo.id = dbo.ComisionHistorialCambioIndicadorArticulo.articuloID INNER JOIN " +
					"dbo.ComisionIndicador ON dbo.ComisionHistorialCambioIndicadorArticulo.indicadorComisionID = dbo.ComisionIndicador.id LEFT OUTER JOIN " +
					"dbo.SubRubro ON dbo.Articulo.subRubroID = dbo.SubRubro.id LEFT OUTER JOIN " +
					"dbo.Rubro ON dbo.Articulo.rubroID = dbo.Rubro.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloTipo ON dbo.Articulo.tipoID = dbo.tv_ArticuloTipo.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloCategoria ON dbo.Articulo.categoriaID = dbo.tv_ArticuloCategoria.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloVariedad ON dbo.Articulo.variedadID = dbo.tv_ArticuloVariedad.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloRegion ON dbo.Articulo.regionID = dbo.tv_ArticuloRegion.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloPresentacion ON dbo.Articulo.presentacionID = dbo.tv_ArticuloPresentacion.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloCosecha ON dbo.Articulo.cosechaID = dbo.tv_ArticuloCosecha.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloOrigen ON dbo.Articulo.origenID = dbo.tv_ArticuloOrigen.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloCepaje ON dbo.Articulo.cepajeID = dbo.tv_ArticuloCepaje.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloMarca ON dbo.Articulo.marcaID = dbo.tv_ArticuloMarca.id LEFT OUTER JOIN " +
					"dbo.tv_ArticuloBodega ON dbo.Articulo.bodegaID = dbo.tv_ArticuloBodega.id " +
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

				if (tbPalabrasClaveB.Text.Trim()!="") 
					filtro += obtenerWHEREBLOB(tbPalabrasClaveB.Text);

				if (cbRubroB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.rubroID = CAST('" + cbRubroB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbSubRubroB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.subRubroID = '" + cbSubRubroB.SelectedValue.ToString() + "'";
				}
				if (tbDescripcionB.Enabled && tbDescripcionB.Text.Trim()!="") 
				{
					filtro = filtro + " AND dbo.Articulo.descripcion LIKE '%" + tbDescripcionB.Text.Trim() + "%'";
				}
				if (cbBodegaB.Enabled && cbBodegaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.bodegaID = CAST('" + cbBodegaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbCepajeB.Enabled && cbCepajeB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.cepajeID = CAST('" + cbCepajeB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbVariedadB.Enabled && cbVariedadB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.variedadID = CAST('" + cbVariedadB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbRegionB.Enabled && cbRegionB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.regionID = CAST('" + cbRegionB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbOrigenB.Enabled && cbOrigenB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.origenID = CAST('" + cbOrigenB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbCosechaB.Enabled && cbCosechaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.cosechaID = CAST('" + cbCosechaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (tbAniosB.Enabled && tbAniosB.Text.Trim()!="" && Utilidades.IsNumeric(tbAniosB.Text.Trim())) 
				{
					filtro = filtro + " AND dbo.Articulo.anios = " + tbAniosB.Text.Trim();
				}
				if (tbGraduacionAlcoholicaB.Enabled && tbGraduacionAlcoholicaB.Text.Trim()!="" && Utilidades.IsNumeric(tbGraduacionAlcoholicaB.Text.Trim())) 
				{
					filtro = filtro + " AND dbo.Articulo.graduacionAlcoholica = " + tbGraduacionAlcoholicaB.Text.Trim();
				}
				if (tbCodigoInternoB.Enabled && tbCodigoInternoB.Text.Trim()!="") 
				{
					filtro = filtro + " AND dbo.Articulo.codigoInterno = '" + tbCodigoInternoB.Text.Trim() + "'";
				}
				if (tbCodigoBarrasB.Enabled && tbCodigoBarrasB.Text.Trim()!="") 
				{
					filtro = filtro + " AND dbo.Articulo.codigoBarras = '" + tbCodigoBarrasB.Text.Trim() + "'";
				}
				if (cbCategoriaB.Enabled && cbCategoriaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.categoriaID = CAST('" + cbCategoriaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbMarcaB.Enabled && cbMarcaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.marcaID = CAST('" + cbMarcaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbPresentacionB.Enabled && cbPresentacionB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.presentacionID = CAST('" + cbPresentacionB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (tbContenidoB.Enabled && tbContenidoB.Text.Trim()!="") 
				{
					filtro = filtro + " AND dbo.Articulo.contenido LIKE '%" + tbCodigoBarrasB.Text.Trim() + "%'";
				}
				if (cbTipoB.Enabled && cbTipoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Articulo.tipoID = CAST('" + cbTipoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (tbSaborB.Enabled && tbSaborB.Text.Trim()!="") 
				{
					filtro = filtro + " AND dbo.Articulo.sabor LIKE '%" + tbSaborB.Text.Trim() + "%'";
				}

				//Fechas
				DateTime fechaDesde, fechaHasta;
				string dia, mes, anio, sfechaDesde, sfechaHasta;
				if (chkFechaB.Checked)
				{
					fechaDesde = dtpFechaDesdeB.Value;
					fechaHasta = dtpFechaHastaB.Value;
					dia = fechaDesde.Day.ToString("00");
					mes = fechaDesde.Month.ToString("00");
					anio = fechaDesde.Year.ToString("0000");
					sfechaDesde = "{ts '" + anio + "-" + mes + "-" + dia + " 00:00:00'}";
					filtro = filtro + " AND fecha >= " + sfechaDesde;
				
					dia = fechaHasta.Day.ToString("00");
					mes = fechaHasta.Month.ToString("00");
					anio = fechaHasta.Year.ToString("0000");
					sfechaHasta = "{ts '" + anio + "-" + mes + "-" + dia + " 23:59:59'}";
					filtro = filtro + " AND fecha <= " + sfechaHasta;
				}

				if (cbIndicadorComisionB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.ComisionHistorialCambioIndicadorArticulo.indicadorComisionID = CAST('" + cbIndicadorComisionB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}

				if (cbArticuloCompuesto.Text!="Todos")
				{
					string articuloCompuestoID = cbArticuloCompuesto.Text=="Compuesto" ? "1" : "0";
					filtro = filtro + " AND dbo.Articulo.articuloCompuestoID = CAST('" + articuloCompuestoID + "' AS uniqueidentifier)";
				}

				return filtro;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		//Prepara los LIKEs para las palabras clave
		private string obtenerWHEREBLOB(string palabras)
		{
			try
			{
				//Extrae los espacios de mas
				while (palabras.IndexOf("  ")>-1)
					palabras = palabras.Replace("  "," ");

				string[] aPalabras = palabras.Split(' ');
				string where = "";
				for (int i=0; i<aPalabras.Length; i++)
				{
					where += " AND registroBLOB LIKE '%" + aPalabras[i] + "%'";
				}
				return where;
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

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 4;  //Fecha
				rbDesc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 2;  //Indicador
				rbAsc2.Checked = true;
				cbCampoOrden3.SelectedIndex = 6;  //Rubro
				rbAsc3.Checked = true;
				cbCampoOrden4.SelectedIndex = 7;  //Sub Rubro
				rbAsc4.Checked = true;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butBuscar2_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butBuscar3_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void limpiarBusqueda()
		{
			try
			{
				tbPalabrasClaveB.Text = "";
				cbRubroB.SelectedIndex = 0;
				cbSubRubroB.SelectedIndex = 0;
				tbDescripcionB.Text = "";
				tbCodigoInternoB.Text = "";
				tbCodigoBarrasB.Text = "";
				cbCategoriaB.SelectedIndex = 0;
				cbMarcaB.SelectedIndex = 0;
				cbPresentacionB.SelectedIndex = 0;
				tbContenidoB.Text = "";
				cbTipoB.SelectedIndex = 0;
				tbSaborB.Text = "";
				cbBodegaB.SelectedIndex = 0;
				cbCepajeB.SelectedIndex = 0;
				cbVariedadB.SelectedIndex = 0;
				cbRegionB.SelectedIndex = 0;
				cbOrigenB.SelectedIndex = 0;
				cbCosechaB.SelectedIndex = 0;
				tbAniosB.Text = "";
				tbGraduacionAlcoholicaB.Text = "";
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butLimpiar2_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butLimpiar3_Click(object sender, System.EventArgs e)
		{
			acomodarCombosOrden();
		}

		private void dgItems_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.consultaRapida)
				((Form)this.Parent).Close();				
			else
				tabPrincipal.SelectedIndex = 1;
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
							gbModificacionProveedores.Enabled = true;
						}
						else
							gbModificacionProveedores.Enabled = false;
					else
						gbModificacionProveedores.Enabled = false;
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

						tbID.Text = dt.Rows[currentRow]["ID"].ToString();

						UtilUI.llenarCombo(ref cbRubro, this.conexion, "sp_getAllRubros", "", -1);
						cbRubro.SelectedValue = dt.Rows[currentRow]["rubroID"].ToString();

						llenarSubRubrosDet();
						cbSubRubro.SelectedValue = dt.Rows[currentRow]["subRubroID"].ToString();

						if (tbDescripcion.Enabled)
							tbDescripcion.Text = dt.Rows[currentRow]["Descripción"].ToString();

						if (tbCodigoInterno.Enabled)
							tbCodigoInterno.Text = dt.Rows[currentRow]["Código Interno"].ToString();
					
						if (tbCodigoBarras.Enabled)
							tbCodigoBarras.Text = dt.Rows[currentRow]["Código de Barras"].ToString();
			
						UtilUI.llenarCombo(ref cbCategoria, this.conexion, "sp_getAlltv_ArticuloCategorias", "", -1);
						if (cbCategoria.Enabled)
						{
							cbCategoria.SelectedValue = dt.Rows[currentRow]["categoriaID"].ToString();
						}

						UtilUI.llenarCombo(ref cbMarca, this.conexion, "sp_getAlltv_ArticuloMarcas", "", -1);
						if (cbMarca.Enabled)
						{
							cbMarca.SelectedValue = dt.Rows[currentRow]["marcaID"].ToString();
						}
					
						UtilUI.llenarCombo(ref cbBodega, this.conexion, "sp_getAlltv_ArticuloBodegas", "", -1);
						if (cbBodega.Enabled)
						{
							cbBodega.SelectedValue = dt.Rows[currentRow]["bodegaID"].ToString();
						}
					
						UtilUI.llenarCombo(ref cbCepaje, this.conexion, "sp_getAlltv_ArticuloCepajes", "", -1);
						if (cbCepaje.Enabled)
						{
							cbCepaje.SelectedValue = dt.Rows[currentRow]["cepajeID"].ToString();
						}
					
						UtilUI.llenarCombo(ref cbVariedad, this.conexion, "sp_getAlltv_ArticuloVariedads", "", -1);
						if (cbVariedad.Enabled)
						{
							cbVariedad.SelectedValue = dt.Rows[currentRow]["variedadID"].ToString();
						}
					
						UtilUI.llenarCombo(ref cbRegion, this.conexion, "sp_getAlltv_ArticuloRegions", "", -1);
						if (cbRegion.Enabled)
						{
							cbRegion.SelectedValue = dt.Rows[currentRow]["regionID"].ToString();
						}
					
						UtilUI.llenarCombo(ref cbOrigen, this.conexion, "sp_getAlltv_ArticuloOrigens", "", -1);
						if (cbOrigen.Enabled)
						{
							cbOrigen.SelectedValue = dt.Rows[currentRow]["origenID"].ToString();
						}
					
						UtilUI.llenarCombo(ref cbCosecha, this.conexion, "sp_getAlltv_ArticuloCosechas", "", -1);
						if (cbCosecha.Enabled)
						{
							cbCosecha.SelectedValue = dt.Rows[currentRow]["cosechaID"].ToString();
						}
						if (tbAnios.Enabled)
							tbAnios.Text = dt.Rows[currentRow]["Años"].ToString();

						if (tbGraduacionAlcoholica.Enabled)
							tbGraduacionAlcoholica.Text = dt.Rows[currentRow]["Graduación Alcohólica"].ToString();

					
						UtilUI.llenarCombo(ref cbPresentacion, this.conexion, "sp_getAlltv_ArticuloPresentacions", "", -1);
						if (cbPresentacion.Enabled)
						{
							cbPresentacion.SelectedValue = dt.Rows[currentRow]["presentacionID"].ToString();
						}

						if (tbContenido.Enabled)
							tbContenido.Text = dt.Rows[currentRow]["Contenido"].ToString();

						if (tbSabor.Enabled)
							tbSabor.Text = dt.Rows[currentRow]["Sabor"].ToString();

						if (ktbImporte.Enabled)
							ktbImporte.Text = double.Parse(dt.Rows[currentRow]["Precio"].ToString()).ToString("C");
					
						UtilUI.llenarCombo(ref cbTipo, this.conexion, "sp_getAlltv_ArticuloTipos", "", -1);
						if (cbTipo.Enabled)
						{	
							cbTipo.SelectedValue = dt.Rows[currentRow]["tipoID"].ToString();
						}

						if (tbStockMinimo.Enabled)
							tbStockMinimo.Text = dt.Rows[currentRow]["Stock Min."].ToString();

						if (tbStockMaximo.Enabled)
							tbStockMaximo.Text = dt.Rows[currentRow]["Stock Max."].ToString();
					
						if (tbStockExistencia.Enabled)
							tbStockExistencia.Text = dt.Rows[currentRow]["Stock Exist."].ToString();

						if (ktbPrecioCosto.Enabled)
							ktbPrecioCosto.Text = double.Parse(dt.Rows[currentRow]["P. Costo"].ToString()).ToString("C");

						if (ktbMargen.Enabled)
							ktbMargen.Text = double.Parse(dt.Rows[currentRow]["Margen"].ToString()).ToString("N");

						chkArticuloCompuesto.Checked = dt.Rows[currentRow]["Compuesto"].ToString()=="Si" ? true : false;


						//Borra los registros de la grilla de SubArticulos
						DataTable tabla = (DataTable)dgSubArticulos.DataSource;
						tabla.Rows.Clear();
						//Carga los articulos componentes
						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@articuloCompuestoID", new System.Guid(tbID.Text));
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllArticuloComponentes", param);
						if (dr.HasRows)
						{
							while (dr.Read())
							{
								DataRow newRow = tabla.NewRow();
								newRow["Código Interno"] = dr["Código Interno"].ToString();
								newRow["Código de Barras"] = dr["Código de Barras"].ToString();
								newRow["Cantidad"] = dr["Cantidad"].ToString();
								newRow["Rubro"] = dr["Rubro"].ToString();
								newRow["Sub Rubro"] = dr["Sub Rubro"].ToString();
								newRow["Descripción"] = dr["Descripción"].ToString();
								newRow["articuloID"] = dr["articuloID"].ToString();
								tabla.Rows.Add(newRow);
							}
						}
						dr.Close();


						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
					}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cbRubro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarSubRubrosDet();
		}

		private void cbSubRubro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
			activarCamposDet();
		}

		private void butAnterior_Click(object sender, System.EventArgs e)
		{
			if (dgItems.CurrentRowIndex>0)
			{
				dgItems.CurrentRowIndex = dgItems.CurrentRowIndex - 1;
				cargarDetalle();
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

		private void butRubroRefrescar_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable dt = (DataTable)dgItems.DataSource;
				int currentRow = dgItems.CurrentRowIndex;

				UtilUI.llenarCombo(ref cbRubro, this.conexion, "sp_getAllRubros", "", -1);
				cbRubro.SelectedValue = cbRubro.SelectedValue = int.Parse(dt.Rows[currentRow]["rubroID"].ToString());
				llenarSubRubrosDet();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSubRubroRefrescar_Click(object sender, System.EventArgs e)
		{
			llenarSubRubrosDet();
		}

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Registro...", true);
				if (validarFormulario())
					guardarCambios();
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
			
				if (tbAnios.Enabled)
					if (tbAnios.Text.Trim()=="" || !Utilidades.IsNumeric(tbAnios.Text.Trim()))
					{
						mensaje += "   - El valor del campo Años debe ser un número.\r\n";
						resultado = false;
					}
				if (tbGraduacionAlcoholica.Enabled)
					if (tbGraduacionAlcoholica.Text.Trim()=="" || !Utilidades.IsNumeric(tbGraduacionAlcoholica.Text.Trim()))
					{
						mensaje += "   - El valor del campo Graduación Alcohólica debe ser un número.\r\n";
						resultado = false;
					}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Modificación de Artículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Guarda los cambios en la base de datos
		private void guardarCambios()
		{
			try
			{
				//Obtiene los valores a insertar
				string ID = tbID.Text;
				string rubroID = cbRubro.SelectedValue.ToString();
				string subRubroID = cbSubRubro.SelectedValue.ToString();
				string descripcion = tbDescripcion.Enabled ? tbDescripcion.Text : "";
				string codigoInterno = tbCodigoInterno.Enabled ? tbCodigoInterno.Text : "";
				string codigoBarras = tbCodigoBarras.Enabled ? tbCodigoBarras.Text : "";
				string categoriaID = cbCategoria.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbCategoria, "sp_Inserttv_ArticuloCategoria") : "0";
				string marcaID = cbMarca.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbMarca, "sp_Inserttv_ArticuloMarca") : "0";
				string bodegaID = cbBodega.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbBodega, "sp_Inserttv_ArticuloBodega") : "0";
				string cepajeID = cbCepaje.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbCepaje, "sp_Inserttv_ArticuloCepaje") : "0";
				string variedadID = cbVariedad.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbVariedad, "sp_Inserttv_ArticuloVariedad") : "0";
				string regionID = cbRegion.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbRegion, "sp_Inserttv_ArticuloRegion") : "0";
				string origenID = cbOrigen.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbOrigen, "sp_Inserttv_ArticuloOrigen") : "0";
				string cosechaID = cbCosecha.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbCosecha, "sp_Inserttv_ArticuloCosecha") : "0";
				string presentacionID = cbPresentacion.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbPresentacion, "sp_Inserttv_ArticuloPresentacion") : "0";
				string tipoID = cbTipo.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbTipo, "sp_Inserttv_ArticuloTipo") : "0";
				string anios = tbAnios.Enabled ? tbAnios.Text : "0";
				string contenido = tbContenido.Enabled ? tbContenido.Text : "";
				string sabor = tbSabor.Enabled ? tbSabor.Text : "";
			
				string simporte = ktbImporte.CurrencyValue().Replace(".","");
				double importe = double.Parse(simporte);

				string sgraduacion = tbGraduacionAlcoholica.CurrencyValue().Replace(".","");
				double graduacion = double.Parse(sgraduacion);
				string registroBLOB = generarRegistroBLOB();

				string articuloCompuestoID = chkArticuloCompuesto.Checked ? "1" : "0";
				string stockMinimo = tbStockMinimo.Text;
				string stockMaximo = tbStockMaximo.Text;
				string stockExistencia = tbStockExistencia.Text;
			
				string sprecioCosto = ktbPrecioCosto.CurrencyValue().Replace(".","");
				double precioCosto = double.Parse(sprecioCosto);

				string smargen = ktbMargen.Text.Replace(".","");
				double margen = double.Parse(smargen);

				SqlParameter[] param = new SqlParameter[28];
			
				param[0] = new SqlParameter("@ID", new System.Guid(ID));
				param[1] = new SqlParameter("@rubroID", new System.Guid(rubroID));
				param[2] = new SqlParameter("@subRubroID", subRubroID);
				param[3] = new SqlParameter("@descripcion", descripcion);
				param[4] = new SqlParameter("@codigoInterno", codigoInterno);
				param[5] = new SqlParameter("@codigoBarras", codigoBarras);
				param[6] = new SqlParameter("@categoriaID", new System.Guid(categoriaID));
				param[7] = new SqlParameter("@marcaID", new System.Guid(marcaID));
				param[8] = new SqlParameter("@bodegaID", new System.Guid(bodegaID));
				param[9] = new SqlParameter("@cepajeID", new System.Guid(cepajeID));
				param[10] = new SqlParameter("@variedadID", new System.Guid(variedadID));
				param[11] = new SqlParameter("@regionID", new System.Guid(regionID));
				param[12] = new SqlParameter("@origenID", new System.Guid(origenID));
				param[13] = new SqlParameter("@cosechaID", new System.Guid(cosechaID));
				param[14] = new SqlParameter("@presentacionID", new System.Guid(presentacionID));
				param[15] = new SqlParameter("@tipoID", new System.Guid(tipoID));
				param[16] = new SqlParameter("@anios", anios);
				param[17] = new SqlParameter("@graduacion", graduacion);
				param[18] = new SqlParameter("@contenido", contenido);
				param[19] = new SqlParameter("@sabor", sabor);
				param[20] = new SqlParameter("@precio", importe);
				param[21] = new SqlParameter("@registroBLOB", registroBLOB);
				param[22] = new SqlParameter("@articuloCompuestoID", articuloCompuestoID);
				param[23] = new SqlParameter("@stockMinimo", stockMinimo);
				param[24] = new SqlParameter("@stockMaximo", stockMaximo);
				param[25] = new SqlParameter("@stockExistencia", stockExistencia);
				param[26] = new SqlParameter("@precioCosto", precioCosto);
				param[27] = new SqlParameter("@margen", margen);
			
				while (true)
				{
					try 
					{
						//Modifica el articulo
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarArticulo", param);

						//Primero Borra los articulos componentes
						string articuloPadreID = ID;
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@articuloCompuestoID", new System.Guid(articuloPadreID));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteArticuloComponentes", param);
						//Inserta los articulos componentes
						if (chkArticuloCompuesto.Checked)
						{
							string articuloID = Utilidades.ID_VACIO;
							string cantidad = "0";

							DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
							for (int i=0; i<dtSubArticulos.Rows.Count; i++)
							{
								cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
								if (cantidad.Trim()!="")
								{
									articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
									param = new SqlParameter[3];
									param[0] = new SqlParameter("@articuloCompuestoID", new System.Guid(articuloPadreID));
									param[1] = new SqlParameter("@articuloID", new System.Guid(articuloID));
									param[2] = new SqlParameter("@cantidad", cantidad);
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertArticuloComponente", param);
								}
							}
						}
						MessageBox.Show("Artículo modificado con éxito.", "Modifiación de Artículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Artículo modificado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo guardar el Artículo. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar el Artículo. \r\n" + e.Message, false);
						if (dr != DialogResult.Retry)
							break;
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Genera el registro BLOB a partir de los textos de los controles
		private string generarRegistroBLOB()
		{
			try
			{
				string registroBLOB = "";

				registroBLOB += cbRubro.Text.Trim() + " , ";
				registroBLOB += cbSubRubro.Text.Trim() + " , ";
				if (tbDescripcion.Enabled)
					registroBLOB += tbDescripcion.Text.Trim() + " , ";
				if (tbCodigoInterno.Enabled)
					registroBLOB += tbCodigoInterno.Text.Trim() + " , ";
				if (tbCodigoBarras.Enabled)
					registroBLOB += tbCodigoBarras.Text.Trim() + " , ";
				if (cbCategoria.Enabled)
					registroBLOB += cbCategoria.Text.Trim() + " , ";
				if (cbMarca.Enabled)
					registroBLOB += cbMarca.Text.Trim() + " , ";
				if (cbBodega.Enabled)
					registroBLOB += cbBodega.Text.Trim() + " , ";
				if (cbCepaje.Enabled)
					registroBLOB += cbCepaje.Text.Trim() + " , ";
				if (cbVariedad.Enabled)
					registroBLOB += cbVariedad.Text.Trim() + " , ";
				if (cbRegion.Enabled)
					registroBLOB += cbRegion.Text.Trim() + " , ";
				if (cbOrigen.Enabled)
					registroBLOB += cbOrigen.Text.Trim() + " , ";
				if (tbAnios.Enabled)
					registroBLOB += tbAnios.Text.Trim() + " , ";
				if (tbGraduacionAlcoholica.Enabled)
					registroBLOB += tbGraduacionAlcoholica.Text.Trim() + " , ";
				if (cbPresentacion.Enabled)
					registroBLOB += cbPresentacion.Text.Trim() + " , ";
				if (tbContenido.Enabled)
					registroBLOB += tbContenido.Text.Trim() + " , ";
				if (tbSabor.Enabled)
					registroBLOB += tbSabor.Text.Trim() + " , ";
				if (ktbImporte.Enabled)
					registroBLOB += ktbImporte.Text.Trim() + " , ";
				if (tbSabor.Enabled)
					registroBLOB += tbSabor.Text.Trim() + " , ";

				return registroBLOB;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Artículos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Artículos...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarArticulo", param);

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

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir2_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir3_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void tbPalabrasClaveB_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				ejecutarBusqueda();
			}
		}

		//Devuelve el ID de articulo seleccionado en la grilla
		public string getArticuloID()
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

		private void butSalir4_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butLimpiar4_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void ucArticuloConsulta_Load(object sender, System.EventArgs e)
		{
			tbPalabrasClaveB.Select();
		}

		private void butAceptar4_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butBorrarArticulosComponentes_Click(object sender, System.EventArgs e)
		{
			borrarRegistrosArticulosComponentes();
		}

		private void borrarRegistrosArticulosComponentes()
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

		private void ktbPrecioCosto_Leave(object sender, System.EventArgs e)
		{
			calcularPrecioVenta();
		}

		private void ktbMargen_Leave(object sender, System.EventArgs e)
		{
			calcularPrecioVenta();
		}

		private void ktbImporte_Leave(object sender, System.EventArgs e)
		{
			calcularMargen();
		}

		private void calcularPrecioVenta()
		{
			try
			{
				double costo = double.Parse(ktbPrecioCosto.CurrencyValue());
				double margen = double.Parse(ktbMargen.Text);
				double venta = double.Parse(ktbImporte.CurrencyValue());

				ktbImporte.Text = ((double)(costo + ((costo/100)*margen))).ToString("C");
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void calcularMargen()
		{
			try
			{
				double costo = double.Parse(ktbPrecioCosto.CurrencyValue());
				double margen = double.Parse(ktbMargen.Text);
				double venta = double.Parse(ktbImporte.CurrencyValue());

				if (costo!=0)
					ktbMargen.Text = ((venta-costo)*100/costo).ToString("N");
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void chkArticuloCompuesto_CheckedChanged(object sender, System.EventArgs e)
		{
			gbArticuloCompuesto.Enabled = chkArticuloCompuesto.Checked;
			dgSubArticulos.Visible = chkArticuloCompuesto.Checked;
		}

		private void tbCodigoInternoAC_FocusEnter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void tbCodigoInternoAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
		}

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

		private void tbCodigoBarrasAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void tbCodigoBarrasAC_Leave(object sender, System.EventArgs e)
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

		private void tbCantidadAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void tbCantidadAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
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
			abrirConsultaRapida();
		}

		//Abre el formulario de consulta en modo rapido
		private void abrirConsultaRapida()
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
		//Agrega el articulo en la lista de articulos
		private void agregarArticulo(ref Control controlFocus)
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", true);
				if (Utilidades.IsNumeric(tbCantidadAC.Text) &&
					tbCantidadAC.Text.Trim()!="" && 
					tbRubroAC.Text!="No registrado." && tbRubroAC.Text!="" &&
					!(tbCodigoInternoAC.Text.Trim()=="" && tbCodigoBarrasAC.Text.Trim()=="" && tbID2.Text.Trim()==""))
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
					newRow["articuloID"] = tbID2.Text;
					tabla.Rows.Add(newRow);

					//Limpia los codigos
					tbCodigoInternoAC.Text = "";
					tbCodigoBarrasAC.Text = "";
					tbRubroAC.Text = "";
					tbSubRubroAC.Text = "";
					tbDescripcionAC.Text = "";
					tbID2.Text = "";

					//Establece el foco en la grilla y muestra el ultimo registro
					dgSubArticulos.Select();
					dgSubArticulos.CurrentRowIndex = ((DataTable)dgSubArticulos.DataSource).Rows.Count - 1;

					//Establece el foco
					if (controlFocus!=null)
						controlFocus.Select();
				}
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", false);
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
					codigoInterno = tbCodigoInternoAC.Text;
					codigoBarras = tbCodigoBarrasAC.Text;
					articuloID = "";
				}

				tbRubroAC.Text = rubro;
				tbSubRubroAC.Text = subRubro;
				tbDescripcionAC.Text = descripcion;
				tbCodigoInternoAC.Text = codigoInterno;
				tbCodigoBarrasAC.Text = codigoBarras;
				tbID2.Text = articuloID;

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
					tbID2.Text = articuloID;

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
		private void chkFechaB_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpFechaDesdeB.Enabled = chkFechaB.Checked;
			dtpFechaHastaB.Enabled = chkFechaB.Checked;
		}

		private void dtbFechaDesdeB_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaHastaB.Value < dtpFechaDesdeB.Value)
				dtpFechaHastaB.Value = dtpFechaDesdeB.Value;
		}

		private void dtpFechaHastaB_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaDesdeB.Value > dtpFechaHastaB.Value)
				dtpFechaDesdeB.Value = dtpFechaHastaB.Value;
		}

		private void butBuscar4_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butLimpiar4_Click_1(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butSalir4_Click_1(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butBuscar1_Click_1(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butBuscar2_Click_1(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butBuscar3_Click_1(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butLimpiar1_Click_1(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butLimpiar2_Click_1(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butLimpiar3_Click_1(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butSalir1_Click_1(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir2_Click_1(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir3_Click_1(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir_Click_1(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

        private void butImprimir_Click(object sender, EventArgs e)
        {

        }
	}
}
