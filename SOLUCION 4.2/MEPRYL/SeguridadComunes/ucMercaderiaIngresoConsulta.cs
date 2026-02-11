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
	/// Summary description for ucMercaderiaIngresoConsulta.
	/// </summary>
	public class ucMercaderiaIngresoConsulta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
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
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.DateTimePicker dtpFechaHastaB;
		private System.Windows.Forms.DateTimePicker dtpFechaDesdeB;
		private System.Windows.Forms.CheckBox chkFechaB;
		private System.Windows.Forms.TextBox tbObservacionesB;
		private System.Windows.Forms.TextBox tbNroRemito1B;
		private System.Windows.Forms.TextBox tbNroRemito2B;
		private System.Windows.Forms.TextBox tbProveedorIDB;
		private System.Windows.Forms.ComboBox cbSucursalB;
		private System.Windows.Forms.Label lbProveedorB;
		private System.Windows.Forms.Button butBuscarProveedorB;
		private System.Windows.Forms.CheckBox chkProveedorB;
		private System.Windows.Forms.CheckBox chkSucursalB;
		private System.Windows.Forms.CheckBox chkDevolucionB;
		private System.Windows.Forms.Button butLimpiarProveedorB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbSucursalDestinoB;
		private System.ComponentModel.IContainer components;


		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = "";
		public Configuracion m_configuracion;
		public bool consultaRapida = false;
		private Control tbCodigoUsado;
		private System.Windows.Forms.DataGrid dgSubArticulos;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox tbNroRemito1;
		private System.Windows.Forms.DateTimePicker dtpFechaRemito;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbNroRemito2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox tbProveedorID;
		private System.Windows.Forms.ComboBox cbSucursal;
		private System.Windows.Forms.Label lbProveedor;
		private System.Windows.Forms.Button butBuscarProveedor;
		private System.Windows.Forms.RadioButton rbDevolucion;
		private System.Windows.Forms.RadioButton rbSucursal;
		private System.Windows.Forms.RadioButton rbProveedor;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbCantidadAC;
		private System.Windows.Forms.TextBox tbCodigoBarrasAC;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox tbCodigoInternoAC;
		private System.Windows.Forms.Label tbDescripcionAC;
		private System.Windows.Forms.Button butAgregarArticuloAC;
		private System.Windows.Forms.Label tbSubRubroAC;
		private System.Windows.Forms.Label tbRubroAC;
		private System.Windows.Forms.Button butBuscarArticuloAC;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox tbMercaderiaIngresadaID;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn NroRemito1;
		private System.Windows.Forms.DataGridTextBoxColumn Fecha1;
		private System.Windows.Forms.DataGridTextBoxColumn Proveedor1;
		private System.Windows.Forms.DataGridTextBoxColumn NroSucOrig1;
		private System.Windows.Forms.DataGridTextBoxColumn SucOrigen1;
		private System.Windows.Forms.DataGridTextBoxColumn NroSucDest1;
		private System.Windows.Forms.DataGridTextBoxColumn SucDestino1;
		private System.Windows.Forms.DataGridTextBoxColumn TipoOrigen1;
		private System.Windows.Forms.DataGridTextBoxColumn Usuario1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn CodigoInterno1;
		private System.Windows.Forms.DataGridTextBoxColumn CodigoBarras1;
		private System.Windows.Forms.DataGridTextBoxColumn Cantidad1;
		private System.Windows.Forms.DataGridTextBoxColumn Descripcion1;
		private System.Windows.Forms.Button butBorrarArticulosComponentes;
		public DataSet dataset = (DataSet) new dsArticulos();

		public ucMercaderiaIngresoConsulta()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMercaderiaIngresoConsulta));
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butVistaPrevia = new System.Windows.Forms.Button();
            this.butImprimir = new System.Windows.Forms.Button();
            this.butBorrar = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.NroRemito1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Fecha1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Proveedor1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.NroSucOrig1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SucOrigen1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.NroSucDest1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SucDestino1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.TipoOrigen1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Usuario1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSucursalDestinoB = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbObservacionesB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbNroRemito1B = new System.Windows.Forms.TextBox();
            this.tbNroRemito2B = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.gbFechaEmision = new System.Windows.Forms.GroupBox();
            this.dtpFechaHastaB = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesdeB = new System.Windows.Forms.DateTimePicker();
            this.chkFechaB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butLimpiarProveedorB = new System.Windows.Forms.Button();
            this.chkDevolucionB = new System.Windows.Forms.CheckBox();
            this.chkSucursalB = new System.Windows.Forms.CheckBox();
            this.tbProveedorIDB = new System.Windows.Forms.TextBox();
            this.cbSucursalB = new System.Windows.Forms.ComboBox();
            this.lbProveedorB = new System.Windows.Forms.Label();
            this.butBuscarProveedorB = new System.Windows.Forms.Button();
            this.chkProveedorB = new System.Windows.Forms.CheckBox();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
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
            this.butBorrarArticulosComponentes = new System.Windows.Forms.Button();
            this.dgSubArticulos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.CodigoInterno1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CodigoBarras1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Cantidad1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Descripcion1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.butAnterior = new System.Windows.Forms.Button();
            this.butSalir = new System.Windows.Forms.Button();
            this.butGuardar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbNroRemito1 = new System.Windows.Forms.TextBox();
            this.dtpFechaRemito = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNroRemito2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbMercaderiaIngresadaID = new System.Windows.Forms.TextBox();
            this.tbProveedorID = new System.Windows.Forms.TextBox();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.lbProveedor = new System.Windows.Forms.Label();
            this.butBuscarProveedor = new System.Windows.Forms.Button();
            this.rbDevolucion = new System.Windows.Forms.RadioButton();
            this.rbSucursal = new System.Windows.Forms.RadioButton();
            this.rbProveedor = new System.Windows.Forms.RadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbCantidadAC = new System.Windows.Forms.TextBox();
            this.tbCodigoBarrasAC = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCodigoInternoAC = new System.Windows.Forms.TextBox();
            this.tbDescripcionAC = new System.Windows.Forms.Label();
            this.butAgregarArticuloAC = new System.Windows.Forms.Button();
            this.tbSubRubroAC = new System.Windows.Forms.Label();
            this.tbRubroAC = new System.Windows.Forms.Label();
            this.butBuscarArticuloAC = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.butLimpiar = new System.Windows.Forms.Button();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbFechaEmision.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.imagenesTab.Images.SetKeyName(8, "");
            this.imagenesTab.Images.SetKeyName(9, "");
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
            this.tabPrincipal.TabIndex = 5;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.butVistaPrevia);
            this.tabPage1.Controls.Add(this.butImprimir);
            this.tabPage1.Controls.Add(this.butBorrar);
            this.tabPage1.Controls.Add(this.dgItems);
            this.tabPage1.Controls.Add(this.tabFiltro);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 4;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista de Ingresos de Mercadería";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // butVistaPrevia
            // 
            this.butVistaPrevia.BackColor = System.Drawing.Color.LimeGreen;
            this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
            this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVistaPrevia.Location = new System.Drawing.Point(460, 157);
            this.butVistaPrevia.Name = "butVistaPrevia";
            this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
            this.butVistaPrevia.TabIndex = 4;
            this.butVistaPrevia.Text = "&Vista Previa";
            this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butVistaPrevia.UseVisualStyleBackColor = false;
            this.butVistaPrevia.Visible = false;
            // 
            // butImprimir
            // 
            this.butImprimir.BackColor = System.Drawing.Color.LimeGreen;
            this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimir.ForeColor = System.Drawing.Color.White;
            this.butImprimir.Image = ((System.Drawing.Image)(resources.GetObject("butImprimir.Image")));
            this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimir.Location = new System.Drawing.Point(386, 157);
            this.butImprimir.Name = "butImprimir";
            this.butImprimir.Size = new System.Drawing.Size(64, 23);
            this.butImprimir.TabIndex = 3;
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
            this.butBorrar.TabIndex = 5;
            this.butBorrar.Text = "&Borrar";
            this.butBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrar.UseVisualStyleBackColor = false;
            // 
            // dgItems
            // 
            this.dgItems.AllowNavigation = false;
            this.dgItems.AllowSorting = false;
            this.dgItems.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dgItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItems.CaptionBackColor = System.Drawing.Color.LimeGreen;
            this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.CaptionForeColor = System.Drawing.Color.White;
            this.dgItems.CaptionText = "     Lista de Ingresos de Mercadería";
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
            this.dataGridTableStyle1.DataGrid = this.dgItems;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.NroRemito1,
            this.Fecha1,
            this.Proveedor1,
            this.NroSucOrig1,
            this.SucOrigen1,
            this.NroSucDest1,
            this.SucDestino1,
            this.TipoOrigen1,
            this.Usuario1});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Items";
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // NroRemito1
            // 
            this.NroRemito1.Format = "";
            this.NroRemito1.FormatInfo = null;
            this.NroRemito1.HeaderText = "Remito";
            this.NroRemito1.MappingName = "Nro. Remito";
            this.NroRemito1.ReadOnly = true;
            this.NroRemito1.Width = 140;
            // 
            // Fecha1
            // 
            this.Fecha1.Format = "d";
            this.Fecha1.FormatInfo = null;
            this.Fecha1.HeaderText = "Fecha";
            this.Fecha1.MappingName = "Fecha";
            this.Fecha1.ReadOnly = true;
            this.Fecha1.Width = 75;
            // 
            // Proveedor1
            // 
            this.Proveedor1.Format = "";
            this.Proveedor1.FormatInfo = null;
            this.Proveedor1.HeaderText = "Proveedor";
            this.Proveedor1.MappingName = "Proveedor";
            this.Proveedor1.ReadOnly = true;
            this.Proveedor1.Width = 140;
            // 
            // NroSucOrig1
            // 
            this.NroSucOrig1.Format = "";
            this.NroSucOrig1.FormatInfo = null;
            this.NroSucOrig1.HeaderText = "Nro.Suc.Orig..";
            this.NroSucOrig1.MappingName = "Nro. Suc. Orig.";
            this.NroSucOrig1.ReadOnly = true;
            this.NroSucOrig1.Width = 75;
            // 
            // SucOrigen1
            // 
            this.SucOrigen1.Format = "";
            this.SucOrigen1.FormatInfo = null;
            this.SucOrigen1.HeaderText = "Suc. Origen";
            this.SucOrigen1.MappingName = "Suc. Origen";
            this.SucOrigen1.ReadOnly = true;
            this.SucOrigen1.Width = 75;
            // 
            // NroSucDest1
            // 
            this.NroSucDest1.Format = "";
            this.NroSucDest1.FormatInfo = null;
            this.NroSucDest1.HeaderText = "Nro.Suc.Dest.";
            this.NroSucDest1.MappingName = "Nro. Suc. Dest.";
            this.NroSucDest1.ReadOnly = true;
            this.NroSucDest1.Width = 75;
            // 
            // SucDestino1
            // 
            this.SucDestino1.Format = "";
            this.SucDestino1.FormatInfo = null;
            this.SucDestino1.HeaderText = "Suc.Destino";
            this.SucDestino1.MappingName = "Suc. Destino";
            this.SucDestino1.ReadOnly = true;
            this.SucDestino1.Width = 75;
            // 
            // TipoOrigen1
            // 
            this.TipoOrigen1.Format = "";
            this.TipoOrigen1.FormatInfo = null;
            this.TipoOrigen1.HeaderText = "Tipo Origen";
            this.TipoOrigen1.MappingName = "Tipo Origen";
            this.TipoOrigen1.ReadOnly = true;
            this.TipoOrigen1.Width = 75;
            // 
            // Usuario1
            // 
            this.Usuario1.Format = "";
            this.Usuario1.FormatInfo = null;
            this.Usuario1.HeaderText = "Usuario";
            this.Usuario1.MappingName = "Usuario";
            this.Usuario1.ReadOnly = true;
            this.Usuario1.Width = 75;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabFiltro1);
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
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.Controls.Add(this.groupBox4);
            this.tabFiltro1.Controls.Add(this.groupBox3);
            this.tabFiltro1.Controls.Add(this.groupBox2);
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.ImageIndex = 1;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            this.tabFiltro1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSucursalDestinoB);
            this.groupBox1.Location = new System.Drawing.Point(496, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 48);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sucursal Destino";
            // 
            // cbSucursalDestinoB
            // 
            this.cbSucursalDestinoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursalDestinoB.Location = new System.Drawing.Point(8, 16);
            this.cbSucursalDestinoB.Name = "cbSucursalDestinoB";
            this.cbSucursalDestinoB.Size = new System.Drawing.Size(120, 21);
            this.cbSucursalDestinoB.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbObservacionesB);
            this.groupBox4.Location = new System.Drawing.Point(496, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 48);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Observaciones";
            // 
            // tbObservacionesB
            // 
            this.tbObservacionesB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservacionesB.Location = new System.Drawing.Point(8, 16);
            this.tbObservacionesB.Multiline = true;
            this.tbObservacionesB.Name = "tbObservacionesB";
            this.tbObservacionesB.Size = new System.Drawing.Size(120, 24);
            this.tbObservacionesB.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbNroRemito1B);
            this.groupBox3.Controls.Add(this.tbNroRemito2B);
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Controls.Add(this.gbFechaEmision);
            this.groupBox3.Location = new System.Drawing.Point(280, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 104);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remito";
            // 
            // tbNroRemito1B
            // 
            this.tbNroRemito1B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroRemito1B.Location = new System.Drawing.Point(48, 15);
            this.tbNroRemito1B.MaxLength = 4;
            this.tbNroRemito1B.Name = "tbNroRemito1B";
            this.tbNroRemito1B.Size = new System.Drawing.Size(36, 20);
            this.tbNroRemito1B.TabIndex = 6;
            this.tbNroRemito1B.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNroRemito1B.Validated += new System.EventHandler(this.tbNroRemito1B_Validated);
            // 
            // tbNroRemito2B
            // 
            this.tbNroRemito2B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroRemito2B.Location = new System.Drawing.Point(88, 15);
            this.tbNroRemito2B.MaxLength = 8;
            this.tbNroRemito2B.Name = "tbNroRemito2B";
            this.tbNroRemito2B.Size = new System.Drawing.Size(88, 20);
            this.tbNroRemito2B.TabIndex = 7;
            this.tbNroRemito2B.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNroRemito2B.Validated += new System.EventHandler(this.tbNroRemito2B_Validated);
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(8, 15);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(40, 16);
            this.label51.TabIndex = 1;
            this.label51.Text = "Nro.";
            // 
            // gbFechaEmision
            // 
            this.gbFechaEmision.Controls.Add(this.dtpFechaHastaB);
            this.gbFechaEmision.Controls.Add(this.dtpFechaDesdeB);
            this.gbFechaEmision.Controls.Add(this.chkFechaB);
            this.gbFechaEmision.Location = new System.Drawing.Point(8, 48);
            this.gbFechaEmision.Name = "gbFechaEmision";
            this.gbFechaEmision.Size = new System.Drawing.Size(200, 48);
            this.gbFechaEmision.TabIndex = 215;
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
            // 
            // dtpFechaDesdeB
            // 
            this.dtpFechaDesdeB.Enabled = false;
            this.dtpFechaDesdeB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeB.Location = new System.Drawing.Point(8, 16);
            this.dtpFechaDesdeB.Name = "dtpFechaDesdeB";
            this.dtpFechaDesdeB.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaDesdeB.TabIndex = 7;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butLimpiarProveedorB);
            this.groupBox2.Controls.Add(this.chkDevolucionB);
            this.groupBox2.Controls.Add(this.chkSucursalB);
            this.groupBox2.Controls.Add(this.tbProveedorIDB);
            this.groupBox2.Controls.Add(this.cbSucursalB);
            this.groupBox2.Controls.Add(this.lbProveedorB);
            this.groupBox2.Controls.Add(this.butBuscarProveedorB);
            this.groupBox2.Controls.Add(this.chkProveedorB);
            this.groupBox2.Location = new System.Drawing.Point(8, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 104);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Origen";
            // 
            // butLimpiarProveedorB
            // 
            this.butLimpiarProveedorB.BackColor = System.Drawing.Color.Gainsboro;
            this.butLimpiarProveedorB.Enabled = false;
            this.butLimpiarProveedorB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiarProveedorB.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiarProveedorB.Image")));
            this.butLimpiarProveedorB.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butLimpiarProveedorB.Location = new System.Drawing.Point(240, 12);
            this.butLimpiarProveedorB.Name = "butLimpiarProveedorB";
            this.butLimpiarProveedorB.Size = new System.Drawing.Size(24, 24);
            this.butLimpiarProveedorB.TabIndex = 152;
            this.butLimpiarProveedorB.UseVisualStyleBackColor = false;
            this.butLimpiarProveedorB.Click += new System.EventHandler(this.butLimpiarProveedorB_Click);
            // 
            // chkDevolucionB
            // 
            this.chkDevolucionB.Location = new System.Drawing.Point(8, 60);
            this.chkDevolucionB.Name = "chkDevolucionB";
            this.chkDevolucionB.Size = new System.Drawing.Size(80, 24);
            this.chkDevolucionB.TabIndex = 151;
            this.chkDevolucionB.Text = "Devolución";
            this.chkDevolucionB.CheckedChanged += new System.EventHandler(this.chkDevolucionB_CheckedChanged);
            // 
            // chkSucursalB
            // 
            this.chkSucursalB.Location = new System.Drawing.Point(8, 37);
            this.chkSucursalB.Name = "chkSucursalB";
            this.chkSucursalB.Size = new System.Drawing.Size(80, 24);
            this.chkSucursalB.TabIndex = 150;
            this.chkSucursalB.Text = "Sucursal";
            this.chkSucursalB.CheckedChanged += new System.EventHandler(this.chkSucursalB_CheckedChanged);
            // 
            // tbProveedorIDB
            // 
            this.tbProveedorIDB.Location = new System.Drawing.Point(280, 16);
            this.tbProveedorIDB.Name = "tbProveedorIDB";
            this.tbProveedorIDB.Size = new System.Drawing.Size(40, 20);
            this.tbProveedorIDB.TabIndex = 148;
            this.tbProveedorIDB.Visible = false;
            // 
            // cbSucursalB
            // 
            this.cbSucursalB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursalB.Enabled = false;
            this.cbSucursalB.Location = new System.Drawing.Point(112, 40);
            this.cbSucursalB.Name = "cbSucursalB";
            this.cbSucursalB.Size = new System.Drawing.Size(152, 21);
            this.cbSucursalB.TabIndex = 4;
            // 
            // lbProveedorB
            // 
            this.lbProveedorB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbProveedorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProveedorB.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbProveedorB.Location = new System.Drawing.Point(112, 12);
            this.lbProveedorB.Name = "lbProveedorB";
            this.lbProveedorB.Size = new System.Drawing.Size(128, 24);
            this.lbProveedorB.TabIndex = 2;
            this.lbProveedorB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butBuscarProveedorB
            // 
            this.butBuscarProveedorB.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarProveedorB.Enabled = false;
            this.butBuscarProveedorB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarProveedorB.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarProveedorB.Image")));
            this.butBuscarProveedorB.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butBuscarProveedorB.Location = new System.Drawing.Point(80, 12);
            this.butBuscarProveedorB.Name = "butBuscarProveedorB";
            this.butBuscarProveedorB.Size = new System.Drawing.Size(24, 24);
            this.butBuscarProveedorB.TabIndex = 1;
            this.butBuscarProveedorB.UseVisualStyleBackColor = false;
            this.butBuscarProveedorB.Click += new System.EventHandler(this.butBuscarProveedorB_Click);
            // 
            // chkProveedorB
            // 
            this.chkProveedorB.Location = new System.Drawing.Point(8, 13);
            this.chkProveedorB.Name = "chkProveedorB";
            this.chkProveedorB.Size = new System.Drawing.Size(80, 24);
            this.chkProveedorB.TabIndex = 149;
            this.chkProveedorB.Text = "Proveedor";
            this.chkProveedorB.CheckedChanged += new System.EventHandler(this.chkProveedorB_CheckedChanged);
            // 
            // butSalir1
            // 
            this.butSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir1.Image = ((System.Drawing.Image)(resources.GetObject("butSalir1.Image")));
            this.butSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir1.Location = new System.Drawing.Point(640, 88);
            this.butSalir1.Name = "butSalir1";
            this.butSalir1.Size = new System.Drawing.Size(64, 23);
            this.butSalir1.TabIndex = 5;
            this.butSalir1.Text = "&Salir";
            this.butSalir1.Click += new System.EventHandler(this.butSalir1_Click);
            // 
            // butLimpiar1
            // 
            this.butLimpiar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar1.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar1.Image")));
            this.butLimpiar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar1.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar1.Name = "butLimpiar1";
            this.butLimpiar1.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar1.TabIndex = 4;
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
            this.butBuscar1.TabIndex = 3;
            this.butBuscar1.Text = "&Buscar";
            this.butBuscar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar1.Click += new System.EventHandler(this.butBuscar1_Click);
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
            this.butSalir3.Click += new System.EventHandler(this.butSalir3_Click);
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
            this.butBuscar3.Click += new System.EventHandler(this.butBuscar3_Click);
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
            "Fecha",
            "Nro. Suc. Dest.",
            "Nro. Suc. Orig.",
            "Nro. Remito",
            "Proveedor",
            "Suc. Destino",
            "Suc. Origen",
            "Tipo Origen",
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
            "Fecha",
            "Nro. Suc. Dest.",
            "Nro. Suc. Orig.",
            "Nro. Remito",
            "Proveedor",
            "Suc. Destino",
            "Suc. Origen",
            "Tipo Origen",
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
            "Fecha",
            "Nro. Suc. Dest.",
            "Nro. Suc. Orig.",
            "Nro. Remito",
            "Proveedor",
            "Suc. Destino",
            "Suc. Origen",
            "Tipo Origen",
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
            "Fecha",
            "Nro. Suc. Dest.",
            "Nro. Suc. Orig.",
            "Nro. Remito",
            "Proveedor",
            "Suc. Destino",
            "Suc. Origen",
            "Tipo Origen",
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
            this.tabPage2.Controls.Add(this.butBorrarArticulosComponentes);
            this.tabPage2.Controls.Add(this.dgSubArticulos);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.tabControl1);
            this.tabPage2.Controls.Add(this.pictureBox2);
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
            // butBorrarArticulosComponentes
            // 
            this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
            this.butBorrarArticulosComponentes.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarArticulosComponentes.Image")));
            this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(209, 136);
            this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
            this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
            this.butBorrarArticulosComponentes.TabIndex = 156;
            this.butBorrarArticulosComponentes.Text = "&Borrar";
            this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarArticulosComponentes.UseVisualStyleBackColor = false;
            this.butBorrarArticulosComponentes.Click += new System.EventHandler(this.butBorrarArticulosComponentes_Click);
            // 
            // dgSubArticulos
            // 
            this.dgSubArticulos.CaptionBackColor = System.Drawing.Color.LimeGreen;
            this.dgSubArticulos.CaptionForeColor = System.Drawing.Color.White;
            this.dgSubArticulos.CaptionText = "Artículos";
            this.dgSubArticulos.DataMember = "";
            this.dgSubArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSubArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSubArticulos.Location = new System.Drawing.Point(0, 136);
            this.dgSubArticulos.Name = "dgSubArticulos";
            this.dgSubArticulos.SelectionBackColor = System.Drawing.Color.Goldenrod;
            this.dgSubArticulos.Size = new System.Drawing.Size(792, 238);
            this.dgSubArticulos.TabIndex = 155;
            this.dgSubArticulos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgSubArticulos;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.CodigoInterno1,
            this.CodigoBarras1,
            this.Cantidad1,
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
            // Descripcion1
            // 
            this.Descripcion1.Format = "";
            this.Descripcion1.FormatInfo = null;
            this.Descripcion1.HeaderText = "Descripción";
            this.Descripcion1.MappingName = "Descripción";
            this.Descripcion1.ReadOnly = true;
            this.Descripcion1.Width = 300;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.butSalir);
            this.groupBox5.Controls.Add(this.butGuardar);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 374);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(792, 56);
            this.groupBox5.TabIndex = 154;
            this.groupBox5.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblRegistro);
            this.groupBox9.Controls.Add(this.butSiguiente);
            this.groupBox9.Controls.Add(this.butAnterior);
            this.groupBox9.Location = new System.Drawing.Point(8, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(232, 48);
            this.groupBox9.TabIndex = 103;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Registro";
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
            // butSiguiente
            // 
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(176, 16);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(48, 24);
            this.butSiguiente.TabIndex = 15;
            this.butSiguiente.Text = "Sig.";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
            // 
            // butAnterior
            // 
            this.butAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAnterior.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior.Image")));
            this.butAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAnterior.Location = new System.Drawing.Point(8, 16);
            this.butAnterior.Name = "butAnterior";
            this.butAnterior.Size = new System.Drawing.Size(48, 24);
            this.butAnterior.TabIndex = 14;
            this.butAnterior.Text = "Ant.";
            this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
            // 
            // butSalir
            // 
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(680, 23);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(96, 24);
            this.butSalir.TabIndex = 27;
            this.butSalir.Text = "&Salir";
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // butGuardar
            // 
            this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
            this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGuardar.Location = new System.Drawing.Point(552, 23);
            this.butGuardar.Name = "butGuardar";
            this.butGuardar.Size = new System.Drawing.Size(120, 24);
            this.butGuardar.TabIndex = 26;
            this.butGuardar.Text = "&Guardar";
            this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImageList = this.imagenesTab;
            this.tabControl1.ItemSize = new System.Drawing.Size(93, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 120);
            this.tabControl1.TabIndex = 153;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.ImageIndex = 8;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 94);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Datos del Remito";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbObservaciones);
            this.groupBox6.Location = new System.Drawing.Point(544, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(240, 88);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Observaciones";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.Location = new System.Drawing.Point(8, 16);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.Size = new System.Drawing.Size(224, 64);
            this.tbObservaciones.TabIndex = 9;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbNroRemito1);
            this.groupBox7.Controls.Add(this.dtpFechaRemito);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.tbNroRemito2);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Location = new System.Drawing.Point(352, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(184, 88);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Remito";
            // 
            // tbNroRemito1
            // 
            this.tbNroRemito1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroRemito1.Location = new System.Drawing.Point(48, 22);
            this.tbNroRemito1.MaxLength = 4;
            this.tbNroRemito1.Name = "tbNroRemito1";
            this.tbNroRemito1.Size = new System.Drawing.Size(36, 20);
            this.tbNroRemito1.TabIndex = 6;
            this.tbNroRemito1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFechaRemito
            // 
            this.dtpFechaRemito.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRemito.Location = new System.Drawing.Point(48, 50);
            this.dtpFechaRemito.Name = "dtpFechaRemito";
            this.dtpFechaRemito.Size = new System.Drawing.Size(128, 20);
            this.dtpFechaRemito.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha";
            // 
            // tbNroRemito2
            // 
            this.tbNroRemito2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroRemito2.Location = new System.Drawing.Point(88, 22);
            this.tbNroRemito2.MaxLength = 8;
            this.tbNroRemito2.Name = "tbNroRemito2";
            this.tbNroRemito2.Size = new System.Drawing.Size(88, 20);
            this.tbNroRemito2.TabIndex = 7;
            this.tbNroRemito2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nro.";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbMercaderiaIngresadaID);
            this.groupBox8.Controls.Add(this.tbProveedorID);
            this.groupBox8.Controls.Add(this.cbSucursal);
            this.groupBox8.Controls.Add(this.lbProveedor);
            this.groupBox8.Controls.Add(this.butBuscarProveedor);
            this.groupBox8.Controls.Add(this.rbDevolucion);
            this.groupBox8.Controls.Add(this.rbSucursal);
            this.groupBox8.Controls.Add(this.rbProveedor);
            this.groupBox8.Location = new System.Drawing.Point(8, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(336, 88);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Origen";
            // 
            // tbMercaderiaIngresadaID
            // 
            this.tbMercaderiaIngresadaID.Location = new System.Drawing.Point(280, 64);
            this.tbMercaderiaIngresadaID.Name = "tbMercaderiaIngresadaID";
            this.tbMercaderiaIngresadaID.Size = new System.Drawing.Size(40, 20);
            this.tbMercaderiaIngresadaID.TabIndex = 149;
            this.tbMercaderiaIngresadaID.Visible = false;
            // 
            // tbProveedorID
            // 
            this.tbProveedorID.Location = new System.Drawing.Point(280, 16);
            this.tbProveedorID.Name = "tbProveedorID";
            this.tbProveedorID.Size = new System.Drawing.Size(40, 20);
            this.tbProveedorID.TabIndex = 148;
            this.tbProveedorID.Visible = false;
            // 
            // cbSucursal
            // 
            this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursal.Enabled = false;
            this.cbSucursal.Location = new System.Drawing.Point(112, 40);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(216, 21);
            this.cbSucursal.TabIndex = 4;
            // 
            // lbProveedor
            // 
            this.lbProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProveedor.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbProveedor.Location = new System.Drawing.Point(112, 12);
            this.lbProveedor.Name = "lbProveedor";
            this.lbProveedor.Size = new System.Drawing.Size(216, 24);
            this.lbProveedor.TabIndex = 2;
            this.lbProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butBuscarProveedor
            // 
            this.butBuscarProveedor.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarProveedor.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarProveedor.Image")));
            this.butBuscarProveedor.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butBuscarProveedor.Location = new System.Drawing.Point(80, 12);
            this.butBuscarProveedor.Name = "butBuscarProveedor";
            this.butBuscarProveedor.Size = new System.Drawing.Size(24, 24);
            this.butBuscarProveedor.TabIndex = 1;
            this.butBuscarProveedor.UseVisualStyleBackColor = false;
            // 
            // rbDevolucion
            // 
            this.rbDevolucion.Location = new System.Drawing.Point(8, 64);
            this.rbDevolucion.Name = "rbDevolucion";
            this.rbDevolucion.Size = new System.Drawing.Size(80, 16);
            this.rbDevolucion.TabIndex = 5;
            this.rbDevolucion.Text = "Devolución";
            this.rbDevolucion.CheckedChanged += new System.EventHandler(this.rbDevolucion_CheckedChanged);
            // 
            // rbSucursal
            // 
            this.rbSucursal.Location = new System.Drawing.Point(8, 40);
            this.rbSucursal.Name = "rbSucursal";
            this.rbSucursal.Size = new System.Drawing.Size(72, 16);
            this.rbSucursal.TabIndex = 3;
            this.rbSucursal.Text = "Sucursal";
            this.rbSucursal.CheckedChanged += new System.EventHandler(this.rbSucursal_CheckedChenged);
            // 
            // rbProveedor
            // 
            this.rbProveedor.Checked = true;
            this.rbProveedor.Location = new System.Drawing.Point(8, 16);
            this.rbProveedor.Name = "rbProveedor";
            this.rbProveedor.Size = new System.Drawing.Size(80, 16);
            this.rbProveedor.TabIndex = 0;
            this.rbProveedor.TabStop = true;
            this.rbProveedor.Text = "Proveedor";
            this.rbProveedor.CheckedChanged += new System.EventHandler(this.rbProveedor_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.tbID);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.tbCantidadAC);
            this.tabPage4.Controls.Add(this.tbCodigoBarrasAC);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.tbCodigoInternoAC);
            this.tabPage4.Controls.Add(this.tbDescripcionAC);
            this.tabPage4.Controls.Add(this.butAgregarArticuloAC);
            this.tabPage4.Controls.Add(this.tbSubRubroAC);
            this.tabPage4.Controls.Add(this.tbRubroAC);
            this.tabPage4.Controls.Add(this.butBuscarArticuloAC);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.ImageIndex = 9;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(784, 94);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Formulario de Ingreso";
            this.tabPage4.Visible = false;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(536, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 16);
            this.label27.TabIndex = 143;
            this.label27.Text = "Descripción";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(648, 8);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(64, 20);
            this.tbID.TabIndex = 147;
            this.tbID.Visible = false;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(296, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 16);
            this.label24.TabIndex = 141;
            this.label24.Text = "Rubro";
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
            this.tbCodigoInternoAC.Size = new System.Drawing.Size(88, 21);
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
            this.tbDescripcionAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butAgregarArticuloAC
            // 
            this.butAgregarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butAgregarArticuloAC.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarArticuloAC.Image")));
            this.butAgregarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butAgregarArticuloAC.Location = new System.Drawing.Point(720, 8);
            this.butAgregarArticuloAC.Name = "butAgregarArticuloAC";
            this.butAgregarArticuloAC.Size = new System.Drawing.Size(24, 24);
            this.butAgregarArticuloAC.TabIndex = 136;
            this.butAgregarArticuloAC.UseVisualStyleBackColor = false;
            this.butAgregarArticuloAC.Visible = false;
            // 
            // tbSubRubroAC
            // 
            this.tbSubRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSubRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbSubRubroAC.Location = new System.Drawing.Point(416, 32);
            this.tbSubRubroAC.Name = "tbSubRubroAC";
            this.tbSubRubroAC.Size = new System.Drawing.Size(112, 48);
            this.tbSubRubroAC.TabIndex = 145;
            this.tbSubRubroAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tbRubroAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 114;
            this.pictureBox2.TabStop = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.LimeGreen;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(792, 16);
            this.label18.TabIndex = 95;
            this.label18.Text = "     Modificación Ingreso de Mercadería";
            // 
            // butLimpiar
            // 
            this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
            this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar.Location = new System.Drawing.Point(808, 216);
            this.butLimpiar.Name = "butLimpiar";
            this.butLimpiar.Size = new System.Drawing.Size(96, 24);
            this.butLimpiar.TabIndex = 11;
            this.butLimpiar.Text = "&Limpiar";
            this.butLimpiar.Visible = false;
            // 
            // ucMercaderiaIngresoConsulta
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucMercaderiaIngresoConsulta";
            this.Size = new System.Drawing.Size(800, 456);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabFiltro1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbFechaEmision.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void chkProveedorB_CheckedChanged(object sender, System.EventArgs e)
		{
			activarDesactivarOrigen();
		}

		private void activarDesactivarOrigen()
		{
			try
			{
				if (chkProveedorB.Checked)
				{
					butBuscarProveedorB.Enabled = true;
					butLimpiarProveedorB.Enabled = true;
					lbProveedorB.Enabled = true;
				}
				else
				{
					butBuscarProveedorB.Enabled = false;
					butLimpiarProveedorB.Enabled = false;
					lbProveedorB.Enabled = false;
				}

				if (chkSucursalB.Checked)
					cbSucursalB.Enabled = true;
				else
					cbSucursalB.Enabled = false;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void chkSucursalB_CheckedChanged(object sender, System.EventArgs e)
		{
			activarDesactivarOrigen();
		}

		private void chkDevolucionB_CheckedChanged(object sender, System.EventArgs e)
		{
			activarDesactivarOrigen();
		}

		private void butLimpiarProveedorB_Click(object sender, System.EventArgs e)
		{
			lbProveedorB.Text = "";
			tbProveedorIDB.Text = "";
		}

		private void tbNroRemito1B_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string nroRemito1 = tbNroRemito1B.Text;
				//if (nroRemito1=="") nroRemito1="0";
				if (Utilidades.agregarCerosIzquierda(ref nroRemito1, 4))
					tbNroRemito1B.Text = nroRemito1;
				else
					MessageBox.Show("El Nro. de Remito debe ser numérico.");
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNroRemito2B_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string nroRemito2 = tbNroRemito2B.Text;
				//if (nroRemito2=="") nroRemito2="0";
				if (Utilidades.agregarCerosIzquierda(ref nroRemito2, 8))
					tbNroRemito2B.Text = nroRemito2;
				else
					MessageBox.Show("El Nro. de Remito debe ser numérico.");
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void chkFechaB_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpFechaDesdeB.Enabled = chkFechaB.Checked;
			dtpFechaHastaB.Enabled = chkFechaB.Checked;
		}

		private void butBuscar1_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butBuscar3_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butLimpiar3_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butSalir3_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
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
					//if (dvItems.Table.Rows.Count>0)
					//	butAceptar4.Select();
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
				string sql = "SELECT     dbo.MercaderiaIngresada.id, dbo.MercaderiaIngresada.proveedorID, dbo.MercaderiaIngresada.sucursalOrigenID, dbo.MercaderiaIngresada.nroRemito1, " +
					"dbo.MercaderiaIngresada.nroRemito2, dbo.MercaderiaIngresada.nroRemito1 + '-' + dbo.MercaderiaIngresada.nroRemito2 AS [Nro. Remito], " +
					"dbo.MercaderiaIngresada.usuarioID, dbo.MercaderiaIngresada.fecha AS Fecha, dbo.MercaderiaIngresada.origenID, " +
					"dbo.MercaderiaIngresada.sucursalDestinoID, dbo.MercaderiaIngresada.observaciones AS Observaciones, dbo.Proveedor.razonSocial AS Proveedor, " +
					"dbo.Sucursal.numero AS [Nro. Suc. Orig.], dbo.Sucursal.nombre AS [Suc. Origen], Sucursal_1.numero AS [Nro. Suc. Dest.], " +
					"Sucursal_1.nombre AS [Suc. Destino], dbo.tv_MercaderiaIngresadaOrigen.descripcion AS [Tipo Origen], " +
					"dbo.Usuario.apellido + ', ' + dbo.Usuario.nombre AS Usuario, " +
					"dbo.tv_MercaderiaIngresadaOrigen.identificador AS identificadorOrigen " +
					"FROM         dbo.MercaderiaIngresada LEFT OUTER JOIN " +
					"dbo.Usuario ON dbo.MercaderiaIngresada.usuarioID = dbo.Usuario.id LEFT OUTER JOIN " +
					"dbo.tv_MercaderiaIngresadaOrigen ON dbo.MercaderiaIngresada.origenID = dbo.tv_MercaderiaIngresadaOrigen.id LEFT OUTER JOIN " +
					"dbo.Sucursal Sucursal_1 ON dbo.MercaderiaIngresada.sucursalDestinoID = Sucursal_1.id LEFT OUTER JOIN " +
					"dbo.Sucursal ON dbo.MercaderiaIngresada.sucursalOrigenID = dbo.Sucursal.id LEFT OUTER JOIN " +
					"dbo.Proveedor ON dbo.MercaderiaIngresada.proveedorID = dbo.Proveedor.ID " +
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

				//Procesa el filtro del origen, que es medio complejo
				if (chkProveedorB.Checked || chkSucursalB.Checked || chkDevolucionB.Checked)
				{
					string proveedor = "", sucursal = "", devolucion = "";
					if (chkProveedorB.Checked) 
					{
						//proveedor = "MercaderiaIngresada.origenID=1";
						proveedor = "tv_MercaderiaIngresadaOrigen.identificador='PROVEEDOR'";
						if (tbProveedorIDB.Text!="")
							proveedor += " AND MercaderiaIngresada.proveedorID = CAST('" + tbProveedorIDB.Text + "' AS uniqueidentifier)";
					
						proveedor = "(" + proveedor + ")";
					}
					else
						proveedor = "1=2";

					if (chkSucursalB.Checked) 
					{
						//sucursal = "MercaderiaIngresada.origenID=2";
						sucursal = "tv_MercaderiaIngresadaOrigen.identificador='SUCURSAL'";
						if (cbSucursalB.SelectedIndex>0)
							sucursal += " AND MercaderiaIngresada.sucursalOrigenID = CAST('" + cbSucursalB.SelectedValue + "' AS uniqueidentifier)";
					
						sucursal = "(" + sucursal + ")";
					}
					else
						sucursal = "1=2";

					if (chkDevolucionB.Checked) 
					{
						//devolucion = "MercaderiaIngresada.origenID=3";
						devolucion = "tv_MercaderiaIngresadaOrigen.identificador='DEVOLUCION'";
						devolucion = "(" + devolucion + ")";
					}
					else
						devolucion = "1=2";

					filtro += " AND (" + proveedor + " OR " + sucursal + " OR " + devolucion + ") ";
				}
			

				if (tbNroRemito1B.Text!="" && Utilidades.IsNumeric(tbNroRemito1B.Text)) 
				{
					filtro = filtro + " AND MercaderiaIngresada.nroRemito1 = '" + tbNroRemito1B.Text + "'";
				}
				if (tbNroRemito2B.Text!="" && Utilidades.IsNumeric(tbNroRemito2B.Text)) 
				{
					filtro = filtro + " AND MercaderiaIngresada.nroRemito2 = '" + tbNroRemito2B.Text + "'";
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

				if (tbObservacionesB.Text!="") 
				{
					filtro = filtro + " AND MercaderiaIngresada.observaciones LIKE '%" + tbObservacionesB.Text + "%'";
				}

				if (cbSucursalDestinoB.SelectedIndex>0)
				{
					filtro = filtro + " AND MercaderiaIngresada.sucursalDestinoID = CAST('" + cbSucursalDestinoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
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

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 1;  //Fecha
				rbDesc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 4;  //Remito
				rbAsc2.Checked = true;
				cbCampoOrden3.SelectedIndex = 0;  //---
				rbAsc3.Checked = true;
				cbCampoOrden4.SelectedIndex = 0;  //---
				rbAsc4.Checked = true;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				UtilUI.llenarCombo(ref cbSucursalB, this.conexion, "sp_getAllSucursals", "Todas", 0);
				UtilUI.llenarCombo(ref cbSucursalDestinoB, this.conexion, "sp_getAllSucursals", "Todas", 0);
			
			
				acomodarCombosOrden();

				//Define el tipo de consulta
				if (consultaRapida)
				{
					//butSalir4.Visible = false;
					//butAceptar4.Visible = true;
				}
				else
				{
					//butSalir4.Visible = true;
					//butAceptar4.Visible = false;
				}

				//Asigna la tabla a la datagrid
				dgSubArticulos.DataSource = (DataTable)dataset.Tables["v_Articulo"];

                //Asigna los eventos a la grilla para evitar la tecla DEL
                asignarEventosGrilla(ref dgSubArticulos);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void limpiarBusqueda()
		{
			try
			{
				chkProveedorB.Checked = false;
				chkSucursalB.Checked = false;
				chkDevolucionB.Checked = false;
				lbProveedorB.Text = "";
				tbProveedorIDB.Text = "";
				cbSucursalB.SelectedIndex = 0;
				tbNroRemito1B.Text = "";
				tbNroRemito2B.Text = "";
				chkFechaB.Checked = false;
				tbObservacionesB.Text = "";
				cbSucursalDestinoB.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butBuscarProveedorB_Click(object sender, System.EventArgs e)
		{
			abrirConsultaProveedores();
		}

		//Abre el formulario de consulta en modo rapido
		private void abrirConsultaProveedores()
		{
			try
			{
				frmProveedoresConsulta form = new frmProveedoresConsulta(this.configuracion, true);
				form.statusBar1 = this.statusBarPrincipal;

				//Crea y asigna el Delegate
				form.objDelegateDevolverID = new Comunes.frmProveedoresConsulta.DelegateDevolverID(buscarProveedor);
			
				form.ShowDialog();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private bool buscarProveedor(string proveedorID)
		{
			try
			{
				bool encontrado = false;
				string razonSocial="";
			
				this.Cursor = Cursors.WaitCursor;
	
				string sparam="", sp="";
				sparam = "@proveedorID";
				sp = "sp_getProveedorByID";

				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(sparam, new System.Guid(proveedorID));
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

				//Si se encontro el registro
				if (dr.HasRows)
				{
					dr.Read();
					razonSocial = dr["descripcion"].ToString();
					encontrado = true;
				}
				else
				{
					encontrado = false;
				}
				dr.Close();


				if (!encontrado)
				{
					razonSocial = "No registrado.";
					proveedorID = "";
				}

				lbProveedorB.Text = razonSocial;
				tbProveedorIDB.Text = proveedorID;

				this.Cursor = Cursors.Arrow;

				return encontrado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		private void dgItems_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.consultaRapida)
					((Form)this.Parent).Close();				
				else
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
							//gbModificacionProveedores.Enabled = true;
						}
					//else
					//gbModificacionProveedores.Enabled = false;
					//else
					//gbModificacionProveedores.Enabled = false;
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

						tbMercaderiaIngresadaID.Text = dt.Rows[currentRow]["ID"].ToString();
						UtilUI.llenarCombo(ref cbSucursal, this.conexion, "sp_getAllSucursals", "", -1);

						//Define el tipo de Origen
						string identificadorOrigen = dt.Rows[currentRow]["identificadorOrigen"].ToString();
						if (identificadorOrigen=="PROVEEDOR")  //Proveedor
						{
							rbProveedor.Checked = true;
							tbProveedorID.Text = dt.Rows[currentRow]["proveedorID"].ToString();
							lbProveedor.Text = dt.Rows[currentRow]["Proveedor"].ToString();
						}
						if (identificadorOrigen=="SUCURSAL")  //Sucursal
						{
							rbSucursal.Checked = true;
							cbSucursal.SelectedValue = dt.Rows[currentRow]["sucursalOrigenID"].ToString();
						}
						if (identificadorOrigen=="DEVOLUCION")  //Devolucion
						{
							rbDevolucion.Checked = true;
						}

						tbNroRemito1.Text = dt.Rows[currentRow]["nroRemito1"].ToString();
						tbNroRemito2.Text = dt.Rows[currentRow]["nroRemito2"].ToString();
						dtpFechaRemito.Value = DateTime.Parse(dt.Rows[currentRow]["Fecha"].ToString());
						tbObservaciones.Text = dt.Rows[currentRow]["Observaciones"].ToString();


						//Borra los registros de la grilla de SubArticulos
						DataTable tabla = (DataTable)dgSubArticulos.DataSource;
						tabla.Rows.Clear();
						//Carga los articulos componentes
						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@mercaderiaIngresadaID", new System.Guid(tbMercaderiaIngresadaID.Text));
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllMercaderiaIngresadaLineas", param);
						if (dr.HasRows)
						{
							while (dr.Read())
							{
								DataRow newRow = tabla.NewRow();
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

						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
					}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void rbProveedor_CheckedChanged(object sender, System.EventArgs e)
		{
			activarDesactivarOrigen();
		}

		private void rbSucursal_CheckedChenged(object sender, System.EventArgs e)
		{
			activarDesactivarOrigenDetalle();
		}

		private void rbDevolucion_CheckedChanged(object sender, System.EventArgs e)
		{
			activarDesactivarOrigenDetalle();
		}

		private void activarDesactivarOrigenDetalle()
		{
			try
			{
				if (rbProveedor.Checked)
				{
					butBuscarProveedor.Enabled = true;
					lbProveedor.Enabled = true;
					cbSucursal.Enabled = false;
				}
				if (rbSucursal.Checked)
				{
					butBuscarProveedor.Enabled = false;
					lbProveedor.Enabled = false;
					lbProveedor.Text = "";
					tbProveedorID.Text = "";
					cbSucursal.Enabled = true;
				}
				if (rbDevolucion.Checked)
				{
					butBuscarProveedor.Enabled = false;
					lbProveedor.Enabled = false;
					lbProveedor.Text = "";
					tbProveedorID.Text = "";
					cbSucursal.Enabled = false;
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

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Ingreso de Mercadería...", true);
			if (validarFormulario())
				guardarCambios();
			else
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private bool validarFormulario()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;
			

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


				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Modificación de Ingreso de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Modifica el ingreso de mercaderia
		private void guardarCambios()
		{
			try
			{
				//Obtiene los valores a insertar
				string proveedorID = "";
				string sucursalOrigenID = "";
				string nroRemito1 = tbNroRemito1.Text;
				string nroRemito2 = tbNroRemito2.Text;
				DateTime fecha = dtpFechaRemito.Value;
				string observaciones = tbObservaciones.Text;
				string usuarioID = this.configuracion.usuario.id;  //Modificar OJO
				string sucursalDestinoID = Utilidades.ID_VACIO; //Modificar OJO

				string identificadorOrigen = "";
				if (rbProveedor.Checked)
				{
					identificadorOrigen = "PROVEEDOR"; //Proveedor
					proveedorID = tbProveedorID.Text=="" ? "0" : tbProveedorID.Text;
					sucursalOrigenID = Utilidades.ID_VACIO;
				}
				if (rbSucursal.Checked)
				{
					identificadorOrigen = "SUCURSAL"; //Sucursal
					proveedorID = Utilidades.ID_VACIO;
					sucursalOrigenID = cbSucursal.SelectedValue.ToString();
				}
				if (rbDevolucion.Checked)
				{
					identificadorOrigen = "DEVOLUCION"; //Devolucion
					proveedorID = Utilidades.ID_VACIO;
					sucursalOrigenID = Utilidades.ID_VACIO;
				}
			
				SqlParameter[] param = new SqlParameter[10];
			
				param[0] = new SqlParameter("@ID", new System.Guid(tbMercaderiaIngresadaID.Text));
				param[1] = new SqlParameter("@proveedorID", new System.Guid(proveedorID));
				param[2] = new SqlParameter("@sucursalOrigenID", new System.Guid(sucursalOrigenID));
				param[3] = new SqlParameter("@nroRemito1", nroRemito1);
				param[4] = new SqlParameter("@nroRemito2", nroRemito2);
				param[5] = new SqlParameter("@usuarioID", new System.Guid(usuarioID));
				param[6] = new SqlParameter("@fecha", fecha);
				param[7] = new SqlParameter("@identificadorOrigen", identificadorOrigen);
				param[8] = new SqlParameter("@sucursalDestinoID", new System.Guid(sucursalDestinoID));
				param[9] = new SqlParameter("@observaciones", observaciones);
			
				while (true)
				{
					try 
					{
						//Modifica el registro del Ingreso
						SqlHelper.ExecuteReader(this.conexion, "sp_ModificarMercaderiaIngresada", param);
					
						//Primero Borra los articulos componentes
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@mecaderiaIngresadaID", new System.Guid(tbMercaderiaIngresadaID.Text));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteMercaderiaIngresadaLinea", param);
					

						//Inserta los articulos
						string mercaderiaIngresadaID = tbMercaderiaIngresadaID.Text;
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
								param[0] = new SqlParameter("@mercaderiaIngresadaID", new System.Guid(mercaderiaIngresadaID));
								param[1] = new SqlParameter("@articuloID", new System.Guid(articuloID));
								param[2] = new SqlParameter("@cantidad", cantidad);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertMercaderiaIngresadaLinea", param);
							}
						}


						MessageBox.Show("Ingreso de Mercadería modificado con éxito..", "Modificación de Ingreso de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Ingreso de Mercadería modificado con éxito.", false);


						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo modificar el Ingreso de Mercadería. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Ingreso de Mercadería. \r\n" + e.Message, false);
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






		/****************************************************************************************
		 * Seccion de codigo para manejar el ingreso de articulos en el formulario de ingreso
		 ****************************************************************************************/

		private void tbCodigoInternoAC_Enter(object sender, System.EventArgs e)
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
					tabla.Rows.Add(newRow);

					//Limpia los codigos
					tbCodigoInternoAC.Text = "";
					tbCodigoBarrasAC.Text = "";
					tbRubroAC.Text = "";
					tbSubRubroAC.Text = "";
					tbDescripcionAC.Text = "";
					tbID.Text = "";

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

        private void butImprimir_Click(object sender, EventArgs e)
        {

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