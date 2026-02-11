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
	/// Summary description for ucArticuloAlta.
	/// </summary>
	public class ucArticuloAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbDescripcion;
		private System.Windows.Forms.ComboBox cbRubro;
		private System.Windows.Forms.ComboBox cbBodega;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbMarca;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbCepaje;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbOrigen;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbCosecha;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbPresentacion;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbContenido;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private KMCurrencyTextBox.KMCurrencyTextBox ktbImporte;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbRegion;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cbVariedad;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbAnios;
		private System.Windows.Forms.ComboBox cbCategoria;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbSabor;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbCodigoInterno;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tbCodigoBarras;
		private System.Windows.Forms.Label label19;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = "";
		public Configuracion m_configuracion;
		private System.Windows.Forms.ComboBox cbSubRubro;
		private Hashtable controles = new Hashtable();
		public DataSet dataset = (DataSet) new dsArticulos();

		private System.Windows.Forms.Button butRubroRefrescar;
		private System.Windows.Forms.Button butSubRubroRefrescar;
		private KMCurrencyTextBox.KMCurrencyTextBox tbGraduacionAlcoholica;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox gbArticuloCompuesto;
		private System.Windows.Forms.CheckBox chkArticuloCompuesto;
		private Comunes.ucCustomGrid dgSubArticulos;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn CodigoInterno1;
		private System.Windows.Forms.DataGridTextBoxColumn CodigoBarras1;
		private System.Windows.Forms.DataGridTextBoxColumn Cantidad1;
		private System.Windows.Forms.DataGridTextBoxColumn Rubro1;
		private System.Windows.Forms.DataGridTextBoxColumn SubRubro1;
		private System.Windows.Forms.DataGridTextBoxColumn Descripcion1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbCodigoBarrasAC;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label tbRubroAC;
		private System.Windows.Forms.Label tbSubRubroAC;
		private System.Windows.Forms.Label tbDescripcionAC;
		private System.Windows.Forms.Button butAgregarArticuloAC;
		private System.Windows.Forms.TextBox tbCodigoInternoAC;
		private System.Windows.Forms.TextBox tbCantidadAC;

		private Control tbCodigoUsado;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.Button butBuscarArticuloAC;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private KMCurrencyTextBox.KMCurrencyTextBox ktbPrecioCosto;
		private KMCurrencyTextBox.KMCurrencyTextBox ktbMargen;
		private System.Windows.Forms.TextBox tbStockMinimo;
		private System.Windows.Forms.TextBox tbStockMaximo;
		private System.Windows.Forms.TextBox tbStockExistencia;
		private System.Windows.Forms.Button butBorrarArticulosComponentes;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox tbEstructuraDescripcion;
		private System.Windows.Forms.Button butDescripcionRefrescar;
		private System.Windows.Forms.CheckBox chkDescripcionAutomatica;
		private System.Windows.Forms.Label lbDescripcionTitulo;
		private System.Windows.Forms.TextBox tbRegistroBLOB;
		private System.ComponentModel.IContainer components;

		public ucArticuloAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucArticuloAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.chkDescripcionAutomatica = new System.Windows.Forms.CheckBox();
			this.butDescripcionRefrescar = new System.Windows.Forms.Button();
			this.label33 = new System.Windows.Forms.Label();
			this.tbEstructuraDescripcion = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.tbStockExistencia = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.tbStockMinimo = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.tbStockMaximo = new System.Windows.Forms.TextBox();
			this.ktbMargen = new KMCurrencyTextBox.KMCurrencyTextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.ktbPrecioCosto = new KMCurrencyTextBox.KMCurrencyTextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.tbCodigoInterno = new System.Windows.Forms.TextBox();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tbSabor = new System.Windows.Forms.TextBox();
			this.cbCategoria = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbAnios = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cbVariedad = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cbRegion = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.ktbImporte = new KMCurrencyTextBox.KMCurrencyTextBox();
			this.tbContenido = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbPresentacion = new System.Windows.Forms.ComboBox();
			this.cbCosecha = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbOrigen = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbMarca = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbBodega = new System.Windows.Forms.ComboBox();
			this.lbDescripcionTitulo = new System.Windows.Forms.Label();
			this.tbGraduacionAlcoholica = new KMCurrencyTextBox.KMCurrencyTextBox();
			this.tbDescripcion = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbCepaje = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tbCodigoBarras = new System.Windows.Forms.TextBox();
			this.butRubroRefrescar = new System.Windows.Forms.Button();
			this.cbSubRubro = new System.Windows.Forms.ComboBox();
			this.butSubRubroRefrescar = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.cbRubro = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.chkArticuloCompuesto = new System.Windows.Forms.CheckBox();
			this.gbArticuloCompuesto = new System.Windows.Forms.GroupBox();
			this.butBorrarArticulosComponentes = new System.Windows.Forms.Button();
			this.tbID = new System.Windows.Forms.TextBox();
			this.tbCodigoInternoAC = new System.Windows.Forms.TextBox();
			this.tbDescripcionAC = new System.Windows.Forms.Label();
			this.tbSubRubroAC = new System.Windows.Forms.Label();
			this.tbRubroAC = new System.Windows.Forms.Label();
			this.butBuscarArticuloAC = new System.Windows.Forms.Button();
			this.butAgregarArticuloAC = new System.Windows.Forms.Button();
			this.label27 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.tbCantidadAC = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.tbCodigoBarrasAC = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.dgSubArticulos = new Comunes.ucCustomGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.CodigoInterno1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CodigoBarras1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Cantidad1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Rubro1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.SubRubro1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Descripcion1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.butSalir = new System.Windows.Forms.Button();
			this.butGuardar = new System.Windows.Forms.Button();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tbRegistroBLOB = new System.Windows.Forms.TextBox();
			this.gbModificacionProveedores.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.gbArticuloCompuesto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).BeginInit();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.tabControl1);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 32);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 424);
			this.gbModificacionProveedores.TabIndex = 112;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.HotTrack = true;
			this.tabControl1.ImageList = this.imagenesTab;
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 376);
			this.tabControl1.TabIndex = 118;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.chkDescripcionAutomatica);
			this.tabPage1.Controls.Add(this.butDescripcionRefrescar);
			this.tabPage1.Controls.Add(this.label33);
			this.tabPage1.Controls.Add(this.tbEstructuraDescripcion);
			this.tabPage1.Controls.Add(this.label32);
			this.tabPage1.Controls.Add(this.tbStockExistencia);
			this.tabPage1.Controls.Add(this.label30);
			this.tabPage1.Controls.Add(this.tbStockMinimo);
			this.tabPage1.Controls.Add(this.label31);
			this.tabPage1.Controls.Add(this.tbStockMaximo);
			this.tabPage1.Controls.Add(this.ktbMargen);
			this.tabPage1.Controls.Add(this.label29);
			this.tabPage1.Controls.Add(this.ktbPrecioCosto);
			this.tabPage1.Controls.Add(this.label28);
			this.tabPage1.Controls.Add(this.label19);
			this.tabPage1.Controls.Add(this.tbCodigoInterno);
			this.tabPage1.Controls.Add(this.cbTipo);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.tbSabor);
			this.tabPage1.Controls.Add(this.cbCategoria);
			this.tabPage1.Controls.Add(this.label14);
			this.tabPage1.Controls.Add(this.tbAnios);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.cbVariedad);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.cbRegion);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.ktbImporte);
			this.tabPage1.Controls.Add(this.tbContenido);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.cbPresentacion);
			this.tabPage1.Controls.Add(this.cbCosecha);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.cbOrigen);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.cbMarca);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.cbBodega);
			this.tabPage1.Controls.Add(this.lbDescripcionTitulo);
			this.tabPage1.Controls.Add(this.tbGraduacionAlcoholica);
			this.tabPage1.Controls.Add(this.tbDescripcion);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.cbCepaje);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.tbCodigoBarras);
			this.tabPage1.Controls.Add(this.butRubroRefrescar);
			this.tabPage1.Controls.Add(this.cbSubRubro);
			this.tabPage1.Controls.Add(this.butSubRubroRefrescar);
			this.tabPage1.Controls.Add(this.label22);
			this.tabPage1.Controls.Add(this.cbRubro);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.ImageIndex = 6;
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(776, 349);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Atributos";
			// 
			// chkDescripcionAutomatica
			// 
			this.chkDescripcionAutomatica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDescripcionAutomatica.Checked = true;
			this.chkDescripcionAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDescripcionAutomatica.Location = new System.Drawing.Point(160, 56);
			this.chkDescripcionAutomatica.Name = "chkDescripcionAutomatica";
			this.chkDescripcionAutomatica.Size = new System.Drawing.Size(80, 16);
			this.chkDescripcionAutomatica.TabIndex = 180;
			this.chkDescripcionAutomatica.Text = "Automática";
			this.chkDescripcionAutomatica.CheckedChanged += new System.EventHandler(this.chkDescripcionAutomatica_CheckedChanged);
			// 
			// butDescripcionRefrescar
			// 
			this.butDescripcionRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butDescripcionRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("butDescripcionRefrescar.Image")));
			this.butDescripcionRefrescar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.butDescripcionRefrescar.Location = new System.Drawing.Point(240, 76);
			this.butDescripcionRefrescar.Name = "butDescripcionRefrescar";
			this.butDescripcionRefrescar.Size = new System.Drawing.Size(24, 24);
			this.butDescripcionRefrescar.TabIndex = 179;
			this.butDescripcionRefrescar.Click += new System.EventHandler(this.butDescripcionRefrescar_Click);
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(536, 8);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(152, 14);
			this.label33.TabIndex = 178;
			this.label33.Text = "Escructura de la Descripción";
			// 
			// tbEstructuraDescripcion
			// 
			this.tbEstructuraDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEstructuraDescripcion.Location = new System.Drawing.Point(536, 24);
			this.tbEstructuraDescripcion.Multiline = true;
			this.tbEstructuraDescripcion.Name = "tbEstructuraDescripcion";
			this.tbEstructuraDescripcion.ReadOnly = true;
			this.tbEstructuraDescripcion.Size = new System.Drawing.Size(232, 32);
			this.tbEstructuraDescripcion.TabIndex = 177;
			this.tbEstructuraDescripcion.Text = "";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(696, 256);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(64, 14);
			this.label32.TabIndex = 176;
			this.label32.Text = "Existencia";
			// 
			// tbStockExistencia
			// 
			this.tbStockExistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbStockExistencia.Location = new System.Drawing.Point(696, 272);
			this.tbStockExistencia.Name = "tbStockExistencia";
			this.tbStockExistencia.Size = new System.Drawing.Size(72, 20);
			this.tbStockExistencia.TabIndex = 24;
			this.tbStockExistencia.Text = "0";
			this.tbStockExistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(616, 256);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(64, 14);
			this.label30.TabIndex = 174;
			this.label30.Text = "Stock. Max.";
			// 
			// tbStockMinimo
			// 
			this.tbStockMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbStockMinimo.Location = new System.Drawing.Point(536, 272);
			this.tbStockMinimo.Name = "tbStockMinimo";
			this.tbStockMinimo.Size = new System.Drawing.Size(72, 20);
			this.tbStockMinimo.TabIndex = 22;
			this.tbStockMinimo.Text = "0";
			this.tbStockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(536, 256);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(64, 14);
			this.label31.TabIndex = 173;
			this.label31.Text = "Stock Min.";
			// 
			// tbStockMaximo
			// 
			this.tbStockMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbStockMaximo.Location = new System.Drawing.Point(616, 272);
			this.tbStockMaximo.Name = "tbStockMaximo";
			this.tbStockMaximo.Size = new System.Drawing.Size(72, 20);
			this.tbStockMaximo.TabIndex = 23;
			this.tbStockMaximo.Text = "0";
			this.tbStockMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ktbMargen
			// 
			this.ktbMargen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ktbMargen.CurrencyDecimalSeparator = ",";
			this.ktbMargen.CurrencyGroupSeparator = ".";
			this.ktbMargen.CurrencySymbol = "";
			this.ktbMargen.DecimalsDigits = 2;
			this.ktbMargen.Location = new System.Drawing.Point(96, 320);
			this.ktbMargen.Name = "ktbMargen";
			this.ktbMargen.Size = new System.Drawing.Size(56, 20);
			this.ktbMargen.TabIndex = 26;
			this.ktbMargen.Text = " 0,00";
			this.ktbMargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ktbMargen.Leave += new System.EventHandler(this.ktbMargen_Leave);
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(96, 304);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(64, 14);
			this.label29.TabIndex = 170;
			this.label29.Text = "Margen %";
			// 
			// ktbPrecioCosto
			// 
			this.ktbPrecioCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ktbPrecioCosto.CurrencyDecimalSeparator = ",";
			this.ktbPrecioCosto.CurrencyGroupSeparator = ".";
			this.ktbPrecioCosto.CurrencySymbol = "$";
			this.ktbPrecioCosto.DecimalsDigits = 2;
			this.ktbPrecioCosto.Location = new System.Drawing.Point(8, 320);
			this.ktbPrecioCosto.Name = "ktbPrecioCosto";
			this.ktbPrecioCosto.Size = new System.Drawing.Size(72, 20);
			this.ktbPrecioCosto.TabIndex = 25;
			this.ktbPrecioCosto.Text = "$ 0,00";
			this.ktbPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ktbPrecioCosto.Leave += new System.EventHandler(this.ktbPrecioCosto_Leave);
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(8, 304);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(72, 14);
			this.label28.TabIndex = 168;
			this.label28.Text = "Precio Costo";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(392, 64);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(104, 14);
			this.label19.TabIndex = 166;
			this.label19.Text = "Código de Barras";
			// 
			// tbCodigoInterno
			// 
			this.tbCodigoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCodigoInterno.Location = new System.Drawing.Point(272, 80);
			this.tbCodigoInterno.Name = "tbCodigoInterno";
			this.tbCodigoInterno.Size = new System.Drawing.Size(112, 20);
			this.tbCodigoInterno.TabIndex = 6;
			this.tbCodigoInterno.Text = "";
			this.tbCodigoInterno.TextChanged += new System.EventHandler(this.tbCodigo_TextChanged);
			// 
			// cbTipo
			// 
			this.cbTipo.Location = new System.Drawing.Point(384, 272);
			this.cbTipo.MaxLength = 100;
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(120, 21);
			this.cbTipo.TabIndex = 21;
			this.cbTipo.TextChanged += new System.EventHandler(this.tbTipo_Textchanged);
			this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(384, 256);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 14);
			this.label16.TabIndex = 162;
			this.label16.Text = "Tipo";
			// 
			// tbSabor
			// 
			this.tbSabor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSabor.Location = new System.Drawing.Point(272, 272);
			this.tbSabor.Name = "tbSabor";
			this.tbSabor.Size = new System.Drawing.Size(104, 20);
			this.tbSabor.TabIndex = 20;
			this.tbSabor.Text = "";
			this.tbSabor.TextChanged += new System.EventHandler(this.tbSabor_TextChanged);
			// 
			// cbCategoria
			// 
			this.cbCategoria.Location = new System.Drawing.Point(536, 80);
			this.cbCategoria.MaxLength = 100;
			this.cbCategoria.Name = "cbCategoria";
			this.cbCategoria.Size = new System.Drawing.Size(232, 21);
			this.cbCategoria.TabIndex = 8;
			this.cbCategoria.TextChanged += new System.EventHandler(this.cbCategoria_TextChanged);
			this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(536, 64);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(128, 14);
			this.label14.TabIndex = 158;
			this.label14.Text = "Categoría";
			// 
			// tbAnios
			// 
			this.tbAnios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbAnios.Location = new System.Drawing.Point(272, 224);
			this.tbAnios.Name = "tbAnios";
			this.tbAnios.Size = new System.Drawing.Size(96, 20);
			this.tbAnios.TabIndex = 16;
			this.tbAnios.Text = "";
			this.tbAnios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbAnios.TextChanged += new System.EventHandler(this.tbAnios_TextChanged);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(272, 208);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(88, 14);
			this.label13.TabIndex = 156;
			this.label13.Text = "Años";
			// 
			// cbVariedad
			// 
			this.cbVariedad.Location = new System.Drawing.Point(8, 176);
			this.cbVariedad.MaxLength = 100;
			this.cbVariedad.Name = "cbVariedad";
			this.cbVariedad.Size = new System.Drawing.Size(232, 21);
			this.cbVariedad.TabIndex = 12;
			this.cbVariedad.TextChanged += new System.EventHandler(this.cbVariedad_TextChanged);
			this.cbVariedad.SelectedIndexChanged += new System.EventHandler(this.cbVariedad_SelectedIndexChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 160);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(128, 14);
			this.label12.TabIndex = 154;
			this.label12.Text = "Variedad";
			// 
			// cbRegion
			// 
			this.cbRegion.Location = new System.Drawing.Point(272, 176);
			this.cbRegion.MaxLength = 100;
			this.cbRegion.Name = "cbRegion";
			this.cbRegion.Size = new System.Drawing.Size(232, 21);
			this.cbRegion.TabIndex = 13;
			this.cbRegion.TextChanged += new System.EventHandler(this.cbRegion_TextChanged);
			this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cbRegion_SelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(384, 208);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(120, 14);
			this.label10.TabIndex = 150;
			this.label10.Text = "Graduación Alcohólica";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ktbImporte
			// 
			this.ktbImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ktbImporte.CurrencyDecimalSeparator = ",";
			this.ktbImporte.CurrencyGroupSeparator = ".";
			this.ktbImporte.CurrencySymbol = "$";
			this.ktbImporte.DecimalsDigits = 2;
			this.ktbImporte.Location = new System.Drawing.Point(168, 320);
			this.ktbImporte.Name = "ktbImporte";
			this.ktbImporte.Size = new System.Drawing.Size(72, 20);
			this.ktbImporte.TabIndex = 27;
			this.ktbImporte.Text = "$ 0,00";
			this.ktbImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ktbImporte.Leave += new System.EventHandler(this.ktbImporte_Leave);
			// 
			// tbContenido
			// 
			this.tbContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbContenido.Location = new System.Drawing.Point(8, 272);
			this.tbContenido.Name = "tbContenido";
			this.tbContenido.Size = new System.Drawing.Size(232, 20);
			this.tbContenido.TabIndex = 19;
			this.tbContenido.Text = "";
			this.tbContenido.TextChanged += new System.EventHandler(this.tbContenido_TextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 256);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 14);
			this.label8.TabIndex = 145;
			this.label8.Text = "Contenido";
			// 
			// cbPresentacion
			// 
			this.cbPresentacion.Location = new System.Drawing.Point(536, 224);
			this.cbPresentacion.MaxLength = 100;
			this.cbPresentacion.Name = "cbPresentacion";
			this.cbPresentacion.Size = new System.Drawing.Size(232, 21);
			this.cbPresentacion.TabIndex = 18;
			this.cbPresentacion.TextChanged += new System.EventHandler(this.cbPresentacion_TextChanged);
			this.cbPresentacion.SelectedIndexChanged += new System.EventHandler(this.cbPresentacion_SelectedIndexChanged);
			// 
			// cbCosecha
			// 
			this.cbCosecha.Location = new System.Drawing.Point(8, 224);
			this.cbCosecha.MaxLength = 100;
			this.cbCosecha.Name = "cbCosecha";
			this.cbCosecha.Size = new System.Drawing.Size(232, 21);
			this.cbCosecha.TabIndex = 15;
			this.cbCosecha.TextChanged += new System.EventHandler(this.cbCosecha_TextChanged);
			this.cbCosecha.SelectedIndexChanged += new System.EventHandler(this.cbCosecha_SelecteIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 208);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 14);
			this.label6.TabIndex = 141;
			this.label6.Text = "Cosecha";
			// 
			// cbOrigen
			// 
			this.cbOrigen.Location = new System.Drawing.Point(536, 176);
			this.cbOrigen.MaxLength = 100;
			this.cbOrigen.Name = "cbOrigen";
			this.cbOrigen.Size = new System.Drawing.Size(232, 21);
			this.cbOrigen.TabIndex = 14;
			this.cbOrigen.TextChanged += new System.EventHandler(this.cbOrigen_TextChanged);
			this.cbOrigen.SelectedIndexChanged += new System.EventHandler(this.cbOrigen_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(536, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 14);
			this.label4.TabIndex = 139;
			this.label4.Text = "Origen";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(536, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 14);
			this.label3.TabIndex = 137;
			this.label3.Text = "Cepaje";
			// 
			// cbMarca
			// 
			this.cbMarca.Location = new System.Drawing.Point(8, 128);
			this.cbMarca.MaxLength = 100;
			this.cbMarca.Name = "cbMarca";
			this.cbMarca.Size = new System.Drawing.Size(232, 21);
			this.cbMarca.TabIndex = 9;
			this.cbMarca.TextChanged += new System.EventHandler(this.cbMarca_TextChanged);
			this.cbMarca.SelectedIndexChanged += new System.EventHandler(this.cbMarca_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 14);
			this.label2.TabIndex = 135;
			this.label2.Text = "Marca";
			// 
			// cbBodega
			// 
			this.cbBodega.Location = new System.Drawing.Point(272, 128);
			this.cbBodega.MaxLength = 100;
			this.cbBodega.Name = "cbBodega";
			this.cbBodega.Size = new System.Drawing.Size(232, 21);
			this.cbBodega.TabIndex = 10;
			this.cbBodega.TextChanged += new System.EventHandler(this.cbBodega_TextChanged);
			this.cbBodega.SelectedIndexChanged += new System.EventHandler(this.cbBodega_SelectedIndexChanged);
			// 
			// lbDescripcionTitulo
			// 
			this.lbDescripcionTitulo.Location = new System.Drawing.Point(8, 56);
			this.lbDescripcionTitulo.Name = "lbDescripcionTitulo";
			this.lbDescripcionTitulo.Size = new System.Drawing.Size(152, 14);
			this.lbDescripcionTitulo.TabIndex = 87;
			this.lbDescripcionTitulo.Text = "Descripción";
			// 
			// tbGraduacionAlcoholica
			// 
			this.tbGraduacionAlcoholica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbGraduacionAlcoholica.CurrencyDecimalSeparator = ",";
			this.tbGraduacionAlcoholica.CurrencyGroupSeparator = ".";
			this.tbGraduacionAlcoholica.CurrencySymbol = "";
			this.tbGraduacionAlcoholica.DecimalsDigits = 2;
			this.tbGraduacionAlcoholica.Location = new System.Drawing.Point(416, 224);
			this.tbGraduacionAlcoholica.Name = "tbGraduacionAlcoholica";
			this.tbGraduacionAlcoholica.Size = new System.Drawing.Size(88, 20);
			this.tbGraduacionAlcoholica.TabIndex = 17;
			this.tbGraduacionAlcoholica.Text = " 0,00";
			this.tbGraduacionAlcoholica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbGraduacionAlcoholica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGraduacionAlcoholica_KeyPress);
			this.tbGraduacionAlcoholica.TextChanged += new System.EventHandler(this.tbGraduacionAlcoholica_Textchanged);
			// 
			// tbDescripcion
			// 
			this.tbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDescripcion.Location = new System.Drawing.Point(8, 72);
			this.tbDescripcion.Multiline = true;
			this.tbDescripcion.Name = "tbDescripcion";
			this.tbDescripcion.ReadOnly = true;
			this.tbDescripcion.Size = new System.Drawing.Size(232, 32);
			this.tbDescripcion.TabIndex = 5;
			this.tbDescripcion.Text = "";
			this.tbDescripcion.TextChanged += new System.EventHandler(this.tbDescripcion_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(272, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 14);
			this.label1.TabIndex = 133;
			this.label1.Text = "Bodega";
			// 
			// cbCepaje
			// 
			this.cbCepaje.Location = new System.Drawing.Point(536, 128);
			this.cbCepaje.MaxLength = 100;
			this.cbCepaje.Name = "cbCepaje";
			this.cbCepaje.Size = new System.Drawing.Size(232, 21);
			this.cbCepaje.TabIndex = 11;
			this.cbCepaje.TextChanged += new System.EventHandler(this.cbCepaje_TextChanged);
			this.cbCepaje.SelectedIndexChanged += new System.EventHandler(this.cbCepaje_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(536, 208);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 14);
			this.label7.TabIndex = 143;
			this.label7.Text = "Presentación";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(176, 304);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 14);
			this.label9.TabIndex = 147;
			this.label9.Text = "Precio Venta";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(272, 160);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(128, 14);
			this.label11.TabIndex = 152;
			this.label11.Text = "Región";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(272, 256);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(136, 14);
			this.label15.TabIndex = 160;
			this.label15.Text = "Sabor";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(272, 64);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(136, 14);
			this.label17.TabIndex = 164;
			this.label17.Text = "Código Interno";
			// 
			// tbCodigoBarras
			// 
			this.tbCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCodigoBarras.Location = new System.Drawing.Point(392, 80);
			this.tbCodigoBarras.Name = "tbCodigoBarras";
			this.tbCodigoBarras.Size = new System.Drawing.Size(112, 20);
			this.tbCodigoBarras.TabIndex = 7;
			this.tbCodigoBarras.Text = "";
			this.tbCodigoBarras.TextChanged += new System.EventHandler(this.tbCodigoBarras_TextChanged);
			// 
			// butRubroRefrescar
			// 
			this.butRubroRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butRubroRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("butRubroRefrescar.Image")));
			this.butRubroRefrescar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.butRubroRefrescar.Location = new System.Drawing.Point(240, 24);
			this.butRubroRefrescar.Name = "butRubroRefrescar";
			this.butRubroRefrescar.Size = new System.Drawing.Size(24, 24);
			this.butRubroRefrescar.TabIndex = 2;
			this.butRubroRefrescar.Click += new System.EventHandler(this.butRubroRefrescar_Click);
			// 
			// cbSubRubro
			// 
			this.cbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSubRubro.Location = new System.Drawing.Point(272, 24);
			this.cbSubRubro.MaxLength = 100;
			this.cbSubRubro.Name = "cbSubRubro";
			this.cbSubRubro.Size = new System.Drawing.Size(232, 21);
			this.cbSubRubro.TabIndex = 3;
			this.cbSubRubro.SelectedIndexChanged += new System.EventHandler(this.cbSubRubro_SelectedIndexChanged);
			// 
			// butSubRubroRefrescar
			// 
			this.butSubRubroRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSubRubroRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("butSubRubroRefrescar.Image")));
			this.butSubRubroRefrescar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.butSubRubroRefrescar.Location = new System.Drawing.Point(504, 24);
			this.butSubRubroRefrescar.Name = "butSubRubroRefrescar";
			this.butSubRubroRefrescar.Size = new System.Drawing.Size(24, 24);
			this.butSubRubroRefrescar.TabIndex = 4;
			this.butSubRubroRefrescar.Click += new System.EventHandler(this.butSubRubroRefrescar_Click);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 8);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(136, 14);
			this.label22.TabIndex = 91;
			this.label22.Text = "Rubro";
			// 
			// cbRubro
			// 
			this.cbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRubro.Location = new System.Drawing.Point(8, 24);
			this.cbRubro.MaxLength = 100;
			this.cbRubro.Name = "cbRubro";
			this.cbRubro.Size = new System.Drawing.Size(232, 21);
			this.cbRubro.TabIndex = 1;
			this.cbRubro.SelectedIndexChanged += new System.EventHandler(this.cbRubro_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(272, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 14);
			this.label5.TabIndex = 117;
			this.label5.Text = "Sub Rubro";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.chkArticuloCompuesto);
			this.tabPage2.Controls.Add(this.gbArticuloCompuesto);
			this.tabPage2.ImageIndex = 7;
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(776, 349);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Artículo Compuesto";
			// 
			// chkArticuloCompuesto
			// 
			this.chkArticuloCompuesto.Location = new System.Drawing.Point(16, 0);
			this.chkArticuloCompuesto.Name = "chkArticuloCompuesto";
			this.chkArticuloCompuesto.Size = new System.Drawing.Size(160, 24);
			this.chkArticuloCompuesto.TabIndex = 0;
			this.chkArticuloCompuesto.Text = "Es un Artículo Compuesto";
			this.chkArticuloCompuesto.CheckedChanged += new System.EventHandler(this.chkArticuloCompuesto_CheckedChanged);
			// 
			// gbArticuloCompuesto
			// 
			this.gbArticuloCompuesto.Controls.Add(this.tbRegistroBLOB);
			this.gbArticuloCompuesto.Controls.Add(this.butBorrarArticulosComponentes);
			this.gbArticuloCompuesto.Controls.Add(this.tbID);
			this.gbArticuloCompuesto.Controls.Add(this.tbCodigoInternoAC);
			this.gbArticuloCompuesto.Controls.Add(this.tbDescripcionAC);
			this.gbArticuloCompuesto.Controls.Add(this.tbSubRubroAC);
			this.gbArticuloCompuesto.Controls.Add(this.tbRubroAC);
			this.gbArticuloCompuesto.Controls.Add(this.butBuscarArticuloAC);
			this.gbArticuloCompuesto.Controls.Add(this.butAgregarArticuloAC);
			this.gbArticuloCompuesto.Controls.Add(this.label27);
			this.gbArticuloCompuesto.Controls.Add(this.label25);
			this.gbArticuloCompuesto.Controls.Add(this.label24);
			this.gbArticuloCompuesto.Controls.Add(this.tbCantidadAC);
			this.gbArticuloCompuesto.Controls.Add(this.label23);
			this.gbArticuloCompuesto.Controls.Add(this.tbCodigoBarrasAC);
			this.gbArticuloCompuesto.Controls.Add(this.label21);
			this.gbArticuloCompuesto.Controls.Add(this.label20);
			this.gbArticuloCompuesto.Controls.Add(this.dgSubArticulos);
			this.gbArticuloCompuesto.Enabled = false;
			this.gbArticuloCompuesto.Location = new System.Drawing.Point(8, 8);
			this.gbArticuloCompuesto.Name = "gbArticuloCompuesto";
			this.gbArticuloCompuesto.Size = new System.Drawing.Size(760, 344);
			this.gbArticuloCompuesto.TabIndex = 0;
			this.gbArticuloCompuesto.TabStop = false;
			// 
			// butBorrarArticulosComponentes
			// 
			this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
			this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
			this.butBorrarArticulosComponentes.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarArticulosComponentes.Image")));
			this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(192, 60);
			this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
			this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
			this.butBorrarArticulosComponentes.TabIndex = 132;
			this.butBorrarArticulosComponentes.Text = "&Borrar";
			this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBorrarArticulosComponentes.Click += new System.EventHandler(this.butBorrarArticulosComponentes_Click);
			// 
			// tbID
			// 
			this.tbID.Location = new System.Drawing.Point(704, 16);
			this.tbID.Name = "tbID";
			this.tbID.Size = new System.Drawing.Size(16, 20);
			this.tbID.TabIndex = 131;
			this.tbID.Text = "";
			this.tbID.Visible = false;
			// 
			// tbCodigoInternoAC
			// 
			this.tbCodigoInternoAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCodigoInternoAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCodigoInternoAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbCodigoInternoAC.Location = new System.Drawing.Point(8, 32);
			this.tbCodigoInternoAC.Name = "tbCodigoInternoAC";
			this.tbCodigoInternoAC.Size = new System.Drawing.Size(88, 21);
			this.tbCodigoInternoAC.TabIndex = 1;
			this.tbCodigoInternoAC.Text = "";
			this.tbCodigoInternoAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoInternoAC_KeyPress);
			this.tbCodigoInternoAC.Leave += new System.EventHandler(this.tbCodigoInternoAC_Leave);
			this.tbCodigoInternoAC.Enter += new System.EventHandler(this.tbCodigoInternoAC_FocusEnter);
			// 
			// tbDescripcionAC
			// 
			this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbDescripcionAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbDescripcionAC.Location = new System.Drawing.Point(528, 32);
			this.tbDescripcionAC.Name = "tbDescripcionAC";
			this.tbDescripcionAC.Size = new System.Drawing.Size(224, 24);
			this.tbDescripcionAC.TabIndex = 130;
			this.tbDescripcionAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSubRubroAC
			// 
			this.tbSubRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tbSubRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSubRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbSubRubroAC.Location = new System.Drawing.Point(408, 32);
			this.tbSubRubroAC.Name = "tbSubRubroAC";
			this.tbSubRubroAC.Size = new System.Drawing.Size(112, 24);
			this.tbSubRubroAC.TabIndex = 129;
			this.tbSubRubroAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbRubroAC
			// 
			this.tbRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tbRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbRubroAC.Location = new System.Drawing.Point(288, 32);
			this.tbRubroAC.Name = "tbRubroAC";
			this.tbRubroAC.Size = new System.Drawing.Size(112, 24);
			this.tbRubroAC.TabIndex = 128;
			this.tbRubroAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butBuscarArticuloAC
			// 
			this.butBuscarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
			this.butBuscarArticuloAC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBuscarArticuloAC.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarArticuloAC.Image")));
			this.butBuscarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.butBuscarArticuloAC.Location = new System.Drawing.Point(232, 32);
			this.butBuscarArticuloAC.Name = "butBuscarArticuloAC";
			this.butBuscarArticuloAC.Size = new System.Drawing.Size(24, 24);
			this.butBuscarArticuloAC.TabIndex = 5;
			this.butBuscarArticuloAC.Click += new System.EventHandler(this.butBuscarArticuloAC_Click);
			this.butBuscarArticuloAC.Enter += new System.EventHandler(this.butBuscarArticuloAC_Enter);
			this.butBuscarArticuloAC.Leave += new System.EventHandler(this.butBuscarArticuloAC_Leave);
			// 
			// butAgregarArticuloAC
			// 
			this.butAgregarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
			this.butAgregarArticuloAC.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarArticuloAC.Image")));
			this.butAgregarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.butAgregarArticuloAC.Location = new System.Drawing.Point(720, 8);
			this.butAgregarArticuloAC.Name = "butAgregarArticuloAC";
			this.butAgregarArticuloAC.Size = new System.Drawing.Size(24, 24);
			this.butAgregarArticuloAC.TabIndex = 4;
			this.butAgregarArticuloAC.Visible = false;
			this.butAgregarArticuloAC.Click += new System.EventHandler(this.butAgregarArticuloAC_Click);
			this.butAgregarArticuloAC.Enter += new System.EventHandler(this.butAgregarArticuloAC_Enter);
			this.butAgregarArticuloAC.Leave += new System.EventHandler(this.butAgregarArticuloAC_Leave);
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(528, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(100, 16);
			this.label27.TabIndex = 124;
			this.label27.Text = "Descripción";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(408, 16);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(100, 16);
			this.label25.TabIndex = 122;
			this.label25.Text = "Sub Rubro";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(288, 16);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 16);
			this.label24.TabIndex = 120;
			this.label24.Text = "Rubro";
			// 
			// tbCantidadAC
			// 
			this.tbCantidadAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCantidadAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCantidadAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbCantidadAC.Location = new System.Drawing.Point(184, 32);
			this.tbCantidadAC.Name = "tbCantidadAC";
			this.tbCantidadAC.Size = new System.Drawing.Size(48, 21);
			this.tbCantidadAC.TabIndex = 3;
			this.tbCantidadAC.Text = "";
			this.tbCantidadAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbCantidadAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidadAC_KeyPress);
			this.tbCantidadAC.Leave += new System.EventHandler(this.tbCantidadAC_Leave);
			this.tbCantidadAC.Enter += new System.EventHandler(this.tbCantidadAC_Enter);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(184, 16);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(64, 16);
			this.label23.TabIndex = 118;
			this.label23.Text = "Cantidad";
			// 
			// tbCodigoBarrasAC
			// 
			this.tbCodigoBarrasAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCodigoBarrasAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCodigoBarrasAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbCodigoBarrasAC.Location = new System.Drawing.Point(96, 32);
			this.tbCodigoBarrasAC.Name = "tbCodigoBarrasAC";
			this.tbCodigoBarrasAC.Size = new System.Drawing.Size(88, 21);
			this.tbCodigoBarrasAC.TabIndex = 2;
			this.tbCodigoBarrasAC.Text = "";
			this.tbCodigoBarrasAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoBarrasAC_KeyPress);
			this.tbCodigoBarrasAC.Leave += new System.EventHandler(this.tbCodigoBarrasAC_Leave);
			this.tbCodigoBarrasAC.Enter += new System.EventHandler(this.tbCodigoBarrasAC_Enter);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(96, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 16);
			this.label21.TabIndex = 116;
			this.label21.Text = "Código de Barras";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 16);
			this.label20.TabIndex = 114;
			this.label20.Text = "Código Interno";
			// 
			// dgSubArticulos
			// 
			this.dgSubArticulos.AllowSorting = false;
			this.dgSubArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgSubArticulos.CaptionBackColor = System.Drawing.Color.Green;
			this.dgSubArticulos.CaptionForeColor = System.Drawing.Color.White;
			this.dgSubArticulos.CaptionText = "Artículos Componentes";
			this.dgSubArticulos.DataMember = "";
			this.dgSubArticulos.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgSubArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSubArticulos.Location = new System.Drawing.Point(3, 61);
			this.dgSubArticulos.Name = "dgSubArticulos";
			this.dgSubArticulos.Size = new System.Drawing.Size(754, 280);
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
			this.CodigoInterno1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.CodigoInterno1.Format = "";
			this.CodigoInterno1.FormatInfo = null;
			this.CodigoInterno1.HeaderText = "Cod.Interno";
			this.CodigoInterno1.MappingName = "Código Interno";
			this.CodigoInterno1.ReadOnly = true;
			this.CodigoInterno1.Width = 75;
			// 
			// CodigoBarras1
			// 
			this.CodigoBarras1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
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
			// imagenesTab
			// 
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(688, 392);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 24);
			this.butSalir.TabIndex = 25;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(560, 392);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 24;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// butLimpiar
			// 
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(688, 376);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 23;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Visible = false;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Green;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(816, 32);
			this.label18.TabIndex = 111;
			this.label18.Text = "     Alta de Artículos";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Honeydew;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 113;
			this.pictureBox1.TabStop = false;
			// 
			// tbRegistroBLOB
			// 
			this.tbRegistroBLOB.Location = new System.Drawing.Point(680, 16);
			this.tbRegistroBLOB.Name = "tbRegistroBLOB";
			this.tbRegistroBLOB.Size = new System.Drawing.Size(16, 20);
			this.tbRegistroBLOB.TabIndex = 133;
			this.tbRegistroBLOB.Text = "";
			this.tbRegistroBLOB.Visible = false;
			// 
			// ucArticuloAlta
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucArticuloAlta";
			this.Size = new System.Drawing.Size(816, 456);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.gbArticuloCompuesto.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{

				UtilUI.llenarCombo(ref cbRubro, this.conexion, "sp_getAllRubros", "", "-1");
				cbRubro.SelectedIndex = 0;
				llenarSubRubros();
				UtilUI.llenarCombo(ref cbCategoria, this.conexion, "sp_getAlltv_ArticuloCategorias", "", "-1");
				UtilUI.llenarCombo(ref cbMarca, this.conexion, "sp_getAlltv_ArticuloMarcas", "", "-1");
				UtilUI.llenarCombo(ref cbBodega, this.conexion, "sp_getAlltv_ArticuloBodegas", "", "-1");
				UtilUI.llenarCombo(ref cbCepaje, this.conexion, "sp_getAlltv_ArticuloCepajes", "", "-1");
				UtilUI.llenarCombo(ref cbVariedad, this.conexion, "sp_getAlltv_ArticuloVariedads", "", "-1");
				UtilUI.llenarCombo(ref cbRegion, this.conexion, "sp_getAlltv_ArticuloRegions", "", "-1");
				UtilUI.llenarCombo(ref cbOrigen, this.conexion, "sp_getAlltv_ArticuloOrigens", "", "-1");
				UtilUI.llenarCombo(ref cbCosecha, this.conexion, "sp_getAlltv_ArticuloCosechas", "", "-1");
				UtilUI.llenarCombo(ref cbPresentacion, this.conexion, "sp_getAlltv_ArticuloPresentacions", "", "-1");
				UtilUI.llenarCombo(ref cbTipo, this.conexion, "sp_getAlltv_ArticuloTipos", "", "-1");

				//Guarda las referencias a los controles
				controles.Add("Bodega", cbBodega);
				controles.Add("Marca", cbMarca);
				controles.Add("Cepaje", cbCepaje);
				controles.Add("Origen", cbOrigen);
				controles.Add("Cosecha", cbCosecha);
				controles.Add("Presentación", cbPresentacion);
				controles.Add("Contenido", tbContenido);
				controles.Add("Precio", ktbImporte);
				controles.Add("Graduación Alcohólica", tbGraduacionAlcoholica);
				controles.Add("Región", cbRegion);
				controles.Add("Variedad", cbVariedad);
				controles.Add("Años", tbAnios);
				controles.Add("Categoría", cbCategoria);
				controles.Add("Sabor", tbSabor);
				controles.Add("Tipo", cbTipo);
				//controles.Add("Descripción", tbDescripcion);
				controles.Add("Código Interno", tbCodigoInterno);
				controles.Add("Código de Barras", tbCodigoBarras);
				controles.Add("Rubro", cbRubro);
				controles.Add("Sub Rubro", cbSubRubro);

				//Establece los campos activos
				activarCampos();

				//Asigna la tabla a la datagrid
				dgSubArticulos.DataSource = (DataTable)dataset.Tables["v_Articulo"];

                //Forma la descripcion
                armarEstructuraDescripcion();

				//Asigna el metodo delegado para manejar el evento KeyDown
				//dgSubArticulos.objDelegateKeyDown = new Comunes.ucCustomGrid.DelegateKeyDown(manejadorKeyDown);

                
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void activarCampos()
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
					Object enume = controles.Keys.GetEnumerator();
					//for (int i=0; i<controles.Keys.Count; i++)
					while (((IEnumerator)enume).MoveNext())
					{
						((Control)controles[((IEnumerator)enume).Current]).Enabled = false;
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

					//Activa siempre los campos de Rubro y sub rubro.
					cbRubro.Enabled = true;
					cbSubRubro.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		private void limpiarFormulario()
		{
			try
			{

				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				inicializarComponentes();
				tbDescripcion.Text = "";
				tbCodigoInterno.Text = "";
				tbCodigoBarras.Text = "";
				tbAnios.Text = "";
				tbGraduacionAlcoholica.Text = "";
				tbContenido.Text = "";
				tbSabor.Text = "";
				ktbImporte.Text= "";
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Listo.", false);
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
			UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Registro...", true);
			if (validarFormulario())
				darAlta();
			else
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
		}

		private bool validarFormulario()
		{
			try
			{

				string mensaje = "";
				bool resultado = true;

                if (tbCodigoInterno.Enabled)
                    if (tbCodigoInterno.Text.Trim() == "")
                    {
                        mensaje += "   - El campo Código Interno está vacío.\r\n";
                        resultado = false;
                    }
                    else if (utilArticulo.existeElArticulo(this.configuracion, tbCodigoInterno.Text.Trim()))
                    {
                        mensaje += "   - Ya existe un artículo en la base de datos con el código: " + tbCodigoInterno.Text + ".\r\n";
                        resultado = false;
                    }
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
				if (tbStockMinimo.Enabled)
					if (tbStockMinimo.Text.Trim()=="" || !Utilidades.IsNumeric(tbStockMinimo.Text.Trim()))
					{
						mensaje += "   - El valor del campo Stock Mínimo debe ser un número.\r\n";
						resultado = false;
					}
				if (tbStockMaximo.Enabled)
					if (tbStockMaximo.Text.Trim()=="" || !Utilidades.IsNumeric(tbStockMaximo.Text.Trim()))
					{
						mensaje += "   - El valor del campo Stock Máximo debe ser un número.\r\n";
						resultado = false;
					}
				if (tbStockExistencia.Enabled)
					if (tbStockExistencia.Text.Trim()=="" || !Utilidades.IsNumeric(tbStockExistencia.Text.Trim()))
					{
						mensaje += "   - El valor del campo Existencia debe ser un número.\r\n";
						resultado = false;
					}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Artículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			try
			{

				//Obtiene los valores a insertar
				string rubroID;
                if (cbRubro.SelectedValue != null)
                    rubroID = cbRubro.SelectedValue.ToString();
                else
                    rubroID = Utilidades.ID_VACIO;

				string subRubroID;
                if (cbSubRubro.SelectedValue != null)
                    subRubroID = cbSubRubro.SelectedValue.ToString();
                else
                    subRubroID = Utilidades.ID_VACIO;

				string descripcion = tbDescripcion.Enabled ? tbDescripcion.Text : "";
				string codigoInterno = tbCodigoInterno.Enabled ? tbCodigoInterno.Text : "";
				string codigoBarras = tbCodigoBarras.Enabled ? tbCodigoBarras.Text : "";
				string categoriaID = cbCategoria.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbCategoria, "sp_Inserttv_ArticuloCategoria") : Utilidades.ID_VACIO;
				string marcaID = cbMarca.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbMarca, "sp_Inserttv_ArticuloMarca") : Utilidades.ID_VACIO;
				string bodegaID = cbBodega.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbBodega, "sp_Inserttv_ArticuloBodega") : Utilidades.ID_VACIO;
				string cepajeID = cbCepaje.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbCepaje, "sp_Inserttv_ArticuloCepaje") : Utilidades.ID_VACIO;
				string variedadID = cbVariedad.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbVariedad, "sp_Inserttv_ArticuloVariedad") : Utilidades.ID_VACIO;
				string regionID = cbRegion.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbRegion, "sp_Inserttv_ArticuloRegion") : Utilidades.ID_VACIO;
				string origenID = cbOrigen.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbOrigen, "sp_Inserttv_ArticuloOrigen") : Utilidades.ID_VACIO;
				string cosechaID = cbCosecha.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbCosecha, "sp_Inserttv_ArticuloCosecha") : Utilidades.ID_VACIO;
				string presentacionID = cbPresentacion.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbPresentacion, "sp_Inserttv_ArticuloPresentacion") : Utilidades.ID_VACIO;
				string tipoID = cbTipo.Enabled ? UtilUI.obtenerIDListaActualizable(this.conexion, ref cbTipo, "sp_Inserttv_ArticuloTipo") : Utilidades.ID_VACIO;
				string anios = tbAnios.Enabled ? tbAnios.Text : "0";
				string contenido = tbContenido.Enabled ? tbContenido.Text : "";
				string sabor = tbSabor.Enabled ? tbSabor.Text : "";
			
				string simporte = ktbImporte.CurrencyValue().Replace(".","");
				double precio = 0;
				if (Utilidades.IsNumeric(simporte))
					precio = double.Parse(simporte);

				string sgraduacion = tbGraduacionAlcoholica.Text.Replace(".","");
				double graduacion = double.Parse(sgraduacion);
				string registroBLOB = generarRegistroBLOB();
				
				//Si es compuesto suma los BLOBs de sus articulos componentes
				if (chkArticuloCompuesto.Checked)
					registroBLOB = sumarBLOBsComponentes(registroBLOB);

				string articuloCompuestoID = chkArticuloCompuesto.Checked ? "1" : "0";
				string stockMinimo = tbStockMinimo.Text;
				string stockMaximo = tbStockMaximo.Text;
				string stockExistencia = tbStockExistencia.Text;
			
				string sprecioCosto = ktbPrecioCosto.CurrencyValue().Replace(".","");
				double precioCosto = 0;
				if (Utilidades.IsNumeric(sprecioCosto)) 
					precioCosto = double.Parse(sprecioCosto);

				string smargen = ktbMargen.Text.Replace(".","");
				double margen = double.Parse(smargen);

				SqlParameter[] param = new SqlParameter[27];
			
				param[0] = new SqlParameter("@rubroID", new System.Guid(rubroID));
				param[1] = new SqlParameter("@subRubroID", subRubroID);
				param[2] = new SqlParameter("@descripcion", descripcion);
				param[3] = new SqlParameter("@codigoInterno", codigoInterno);
				param[4] = new SqlParameter("@codigoBarras", codigoBarras);
				param[5] = new SqlParameter("@categoriaID", new System.Guid(categoriaID));
				param[6] = new SqlParameter("@marcaID", new System.Guid(marcaID));
				param[7] = new SqlParameter("@bodegaID", new System.Guid(bodegaID));
				param[8] = new SqlParameter("@cepajeID", new System.Guid(cepajeID));
				param[9] = new SqlParameter("@variedadID", new System.Guid(variedadID));
				param[10] = new SqlParameter("@regionID", new System.Guid(regionID));
				param[11] = new SqlParameter("@origenID", new System.Guid(origenID));
				param[12] = new SqlParameter("@cosechaID", new System.Guid(cosechaID));
				param[13] = new SqlParameter("@presentacionID", new System.Guid(presentacionID));
				param[14] = new SqlParameter("@tipoID", new System.Guid(tipoID));
				param[15] = new SqlParameter("@anios", anios);
				param[16] = new SqlParameter("@graduacion", graduacion);
				param[17] = new SqlParameter("@contenido", contenido);
				param[18] = new SqlParameter("@sabor", sabor);
				param[19] = new SqlParameter("@precio", precio);
				param[20] = new SqlParameter("@registroBLOB", registroBLOB);
				param[21] = new SqlParameter("@articuloCompuestoID", articuloCompuestoID);
				param[22] = new SqlParameter("@stockMinimo", stockMinimo);
				param[23] = new SqlParameter("@stockMaximo", stockMaximo);
				param[24] = new SqlParameter("@stockExistencia", stockExistencia);
				param[25] = new SqlParameter("@precioCosto", precioCosto);
				param[26] = new SqlParameter("@margen", margen);
			
				while (true)
				{
					try 
					{
						//Inserta el Articulo y obtiene el ID
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoArticulo", param);
					
						//Inserta los articulos componentes
						if (dr.HasRows && chkArticuloCompuesto.Checked)
						{
							dr.Read();
							string articuloPadreID = dr["ID"].ToString();
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
						dr.Close();

						MessageBox.Show("Artículo ingresado con éxito.", "Alta de Artículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Artículo ingresado con éxito.", false);

                        //Limpia el formulario
                        tbCodigoInterno.Text = "";
                        bool estadoChk = chkDescripcionAutomatica.Checked; 
                        chkDescripcionAutomatica.Checked = true;
                        armarEstructuraDescripcion();
                        chkDescripcionAutomatica.Checked = estadoChk;

						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo ingresar el Artículo. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar el Artículo. \r\n" + e.Message, false);
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

		//Suma los campos BLOB de los articulos componentes
		private string sumarBLOBsComponentes(string registroBLOB)
		{
			try
			{
				DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
				string cantidad;
				for (int i=0; i<dtSubArticulos.Rows.Count; i++)
				{
					cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
					if (cantidad.Trim()!="")
					{
						registroBLOB += " , " + dtSubArticulos.Rows[i]["registroBLOB"].ToString();
					}
				}

				return registroBLOB;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		//Limpia los campos del formulario
		private void limpiarCamposUnicos()
		{
			/*
			tbCuenta.Text = "";
			tbNumero.Text = "";
			*/
		}

		private void cbRubro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarSubRubros();
		}

		private void llenarSubRubros()
		{
			try
			{

				if (cbRubro.SelectedValue!=null)
				{
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@rubroID", new System.Guid(cbRubro.SelectedValue.ToString()));
					UtilUI.llenarCombo(ref cbSubRubro, this.conexion, "sp_getAllSubRubros", "", "-1", param);

					if (cbSubRubro.Items.Count>0)
						cbSubRubro.SelectedIndex = 0;

					activarCampos();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cbSubRubro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			activarCampos();

			//Arma la estructura de la descripcion
			armarEstructuraDescripcion();
		}

		//Arma la estructura de la descripcion a partir del sub rubro
		private void armarEstructuraDescripcion()
		{
			try
			{
				if (chkDescripcionAutomatica.Checked)
				{

					DataTable tabla = (DataTable)cbSubRubro.DataSource;
					if (tabla!=null)
						if (cbSubRubro.SelectedIndex>-1 && tabla.Rows.Count>0)
						{
							tbEstructuraDescripcion.Text = tabla.Rows[cbSubRubro.SelectedIndex]["cadenaDescripcion"].ToString();

							if (tbEstructuraDescripcion.Text!="" && controles.Values.Count>0)
							{
								//Arma la descripcion fisica
								string cadenaEstruc = tbEstructuraDescripcion.Text.Replace(", ",":");
								string[] aCampoNombre = cadenaEstruc.Split(':');

								string cadenaDescripcion = "";
								string coma = "";
								for (int i=0; i<aCampoNombre.Length; i++)
								{
                                    if (controles.ContainsKey(aCampoNombre[i]))
                                    {
                                        cadenaDescripcion += coma + ((Control)controles[aCampoNombre[i]]).Text.Trim();
                                        coma = " ";
                                    }
								}

								tbDescripcion.Text = cadenaDescripcion;
							}
						}
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

				UtilUI.llenarCombo(ref cbRubro, this.conexion, "sp_getAllRubros", "", "-1");
				cbRubro.SelectedIndex = 0;
				llenarSubRubros();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSubRubroRefrescar_Click(object sender, System.EventArgs e)
		{
			llenarSubRubros();
		}

		private void chkArticuloCompuesto_CheckedChanged(object sender, System.EventArgs e)
		{
			gbArticuloCompuesto.Enabled = chkArticuloCompuesto.Checked;
			dgSubArticulos.Visible = chkArticuloCompuesto.Checked;
		}

		private void dgSubArticulos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			MessageBox.Show(e.KeyChar.ToString());
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
		//Cambia el color de fondo segun tenga o pierda el foco Buscar articulo viejo
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
					string precio="", promocion="", registroBLOB="";
			
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
						registroBLOB = dr["registroBLOB"].ToString();
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
					tbRegistroBLOB.Text = registroBLOB;

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

		private void tbCodigoInternoAC_FocusEnter(object sender, System.EventArgs e)
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
					newRow["registroBLOB"] = tbRegistroBLOB.Text;
					tabla.Rows.Add(newRow);

					//Limpia los codigos
					tbCodigoInternoAC.Text = "";
					tbCodigoBarrasAC.Text = "";
					tbRubroAC.Text = "";
					tbSubRubroAC.Text = "";
					tbDescripcionAC.Text = "";
					tbID.Text = "";
					tbRegistroBLOB.Text = "";

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


		private void calcularPrecioVenta()
		{
			try
			{
				string scosto = ktbPrecioCosto.CurrencyValue();
				double costo = 0;
				if (Utilidades.IsNumeric(scosto))
					costo = double.Parse(scosto);

				double margen = double.Parse(ktbMargen.Text);
				
				string simporte = ktbImporte.CurrencyValue();
				double venta = 0;
				if (Utilidades.IsNumeric(simporte))
					venta = double.Parse(simporte);

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
				string sprecioCosto = ktbImporte.CurrencyValue();
				double costo = 0;
				if (Utilidades.IsNumeric(sprecioCosto))
					costo = double.Parse(sprecioCosto);
				
				double margen = double.Parse(ktbMargen.Text);
				
				string simporte = ktbImporte.CurrencyValue();
				double venta = 0;
				if (Utilidades.IsNumeric(simporte))
					venta = double.Parse(simporte);

				if (costo!=0)
					ktbMargen.Text = ((venta-costo)*100/costo).ToString("N");
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

		private void butDescripcionRefrescar_Click(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbCategoria_TextChanged(object sender, System.EventArgs e)
		{
			//MessageBox.Show("TextChanged");
			armarEstructuraDescripcion();
		}

		private void cbMarca_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbBodega_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbCepaje_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbVariedad_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbRegion_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbOrigen_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbCosecha_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbGraduacionAlcoholica_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbPresentacion_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbCategoria_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbCodigo_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbCodigoBarras_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbMarca_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbBodega_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbCepaje_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbVariedad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbOrigen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbCosecha_SelecteIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbAnios_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbGraduacionAlcoholica_Textchanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbPresentacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbContenido_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbSabor_TextChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void tbTipo_Textchanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void cbTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			armarEstructuraDescripcion();
		}

		private void chkDescripcionAutomatica_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkDescripcionAutomatica.Checked)
				tbDescripcion.ReadOnly = true;
			else
				tbDescripcion.ReadOnly = false;
		}

		private void tbDescripcion_TextChanged(object sender, System.EventArgs e)
		{
			lbDescripcionTitulo.Text = "Descripción (" + tbDescripcion.Text.Length.ToString() + ")";
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