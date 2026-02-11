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
	/// Summary description for ucMensajeConsulta.
	/// </summary>
	public class ucMensajeConsulta : System.Windows.Forms.UserControl
	{
		
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		public bool consultaRapida = false;
		private Control tbCodigoUsado;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.ComponentModel.IContainer components;

		public DataSet dataset = (DataSet) new dsArticulos();
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.Button butAceptar1;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox groupBox1;
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
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionHasta;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionDesde;
		private System.Windows.Forms.CheckBox chkFechaEmision;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Windows.Forms.ComboBox cbEmisorB;
		private System.Windows.Forms.TextBox tbAsuntoB;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox tbCuerpoB;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cbPrioridadB;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbEstadoB;
		private System.Windows.Forms.DataGridTableStyle dgtsListadoMensajes;
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.TextBox tbDestino;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbPrioridad;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbAsunto;
		private System.Windows.Forms.TextBox tbCuerpo;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TabControl tabDestinatarios;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ListBox lbxUsuariosListados;
		private System.Windows.Forms.ListBox lbxUsuariosSeleccionados;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.ListBox lbxGruposListados;
		private System.Windows.Forms.ListBox lbxGruposSeleccionados;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.ListBox lbxSucursalesListadas;
		private System.Windows.Forms.ListBox lbxSucursalesSeleccionadas;
		private System.Windows.Forms.Button butResponder;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbMensajeID;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbEnviadoPor;
		private System.Windows.Forms.Button butReenviar;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.Timer timer1;
		public DataSet datasetFormaPagoLineas = (DataSet) new dsFormaPagoLinea();

		public ucMensajeConsulta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucMensajeConsulta));
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.butVistaPrevia = new System.Windows.Forms.Button();
			this.butImprimir = new System.Windows.Forms.Button();
			this.butBorrar = new System.Windows.Forms.Button();
			this.dgItems = new System.Windows.Forms.DataGrid();
			this.dgtsListadoMensajes = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbEstadoB = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cbPrioridadB = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbCuerpoB = new System.Windows.Forms.TextBox();
			this.gbFechaEmision = new System.Windows.Forms.GroupBox();
			this.dtpFechaEmisionHasta = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaEmisionDesde = new System.Windows.Forms.DateTimePicker();
			this.chkFechaEmision = new System.Windows.Forms.CheckBox();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.cbEmisorB = new System.Windows.Forms.ComboBox();
			this.butAceptar1 = new System.Windows.Forms.Button();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.butLimpiar1 = new System.Windows.Forms.Button();
			this.butBuscar1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbAsuntoB = new System.Windows.Forms.TextBox();
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
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.butReenviar = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.tbEnviadoPor = new System.Windows.Forms.TextBox();
			this.tbMensajeID = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.butResponder = new System.Windows.Forms.Button();
			this.tbDestino = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbPrioridad = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbAsunto = new System.Windows.Forms.TextBox();
			this.tbCuerpo = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.tabDestinatarios = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.lbxUsuariosListados = new System.Windows.Forms.ListBox();
			this.lbxUsuariosSeleccionados = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.lbxGruposListados = new System.Windows.Forms.ListBox();
			this.lbxGruposSeleccionados = new System.Windows.Forms.ListBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.lbxSucursalesListadas = new System.Windows.Forms.ListBox();
			this.lbxSucursalesSeleccionadas = new System.Windows.Forms.ListBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label18 = new System.Windows.Forms.Label();
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
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.lblRegistro = new System.Windows.Forms.Label();
			this.butSiguiente = new System.Windows.Forms.Button();
			this.butAnterior = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
			this.tabFiltro.SuspendLayout();
			this.tabFiltro1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gbFechaEmision.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabFiltro3.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.gbModificacionProveedores.SuspendLayout();
			this.tabDestinatarios.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPrincipal.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.SuspendLayout();
			// 
			// imagenesTab
			// 
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
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
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabPage1.ImageIndex = 2;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(792, 438);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Listado de Mensajes";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
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
			this.butVistaPrevia.Location = new System.Drawing.Point(376, 157);
			this.butVistaPrevia.Name = "butVistaPrevia";
			this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
			this.butVistaPrevia.TabIndex = 4;
			this.butVistaPrevia.Text = "&Vista Previa";
			this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butVistaPrevia.Visible = false;
			// 
			// butImprimir
			// 
			this.butImprimir.BackColor = System.Drawing.Color.Purple;
			this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butImprimir.ForeColor = System.Drawing.Color.White;
			this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butImprimir.Location = new System.Drawing.Point(296, 157);
			this.butImprimir.Name = "butImprimir";
			this.butImprimir.Size = new System.Drawing.Size(64, 23);
			this.butImprimir.TabIndex = 3;
			this.butImprimir.Text = "&Imprimir";
			this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butImprimir.Visible = false;
			// 
			// butBorrar
			// 
			this.butBorrar.BackColor = System.Drawing.Color.Maroon;
			this.butBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBorrar.ForeColor = System.Drawing.Color.White;
			this.butBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBorrar.Location = new System.Drawing.Point(644, 157);
			this.butBorrar.Name = "butBorrar";
			this.butBorrar.Size = new System.Drawing.Size(64, 23);
			this.butBorrar.TabIndex = 2;
			this.butBorrar.Text = "&Borrar";
			this.butBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.dgItems.CaptionBackColor = System.Drawing.Color.DarkSlateGray;
			this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgItems.CaptionForeColor = System.Drawing.Color.White;
			this.dgItems.CaptionText = "     Mensajes Recibidos";
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
																								this.dgtsListadoMensajes});
			this.dgItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgItems_KeyPress);
			this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
			this.dgItems.CurrentCellChanged += new System.EventHandler(this.dgItems_CurrentCellChanged);
			// 
			// dgtsListadoMensajes
			// 
			this.dgtsListadoMensajes.AllowSorting = false;
			this.dgtsListadoMensajes.AlternatingBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.dgtsListadoMensajes.DataGrid = this.dgItems;
			this.dgtsListadoMensajes.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn28,
																												  this.dataGridTextBoxColumn24,
																												  this.dataGridTextBoxColumn25,
																												  this.dataGridTextBoxColumn42,
																												  this.dataGridTextBoxColumn26,
																												  this.dataGridTextBoxColumn27});
			this.dgtsListadoMensajes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgtsListadoMensajes.MappingName = "Items";
			this.dgtsListadoMensajes.ReadOnly = true;
			// 
			// dataGridTextBoxColumn28
			// 
			this.dataGridTextBoxColumn28.Format = "";
			this.dataGridTextBoxColumn28.FormatInfo = null;
			this.dataGridTextBoxColumn28.HeaderText = "Estado";
			this.dataGridTextBoxColumn28.MappingName = "Estado";
			this.dataGridTextBoxColumn28.ReadOnly = true;
			this.dataGridTextBoxColumn28.Width = 50;
			// 
			// dataGridTextBoxColumn24
			// 
			this.dataGridTextBoxColumn24.Format = "";
			this.dataGridTextBoxColumn24.FormatInfo = null;
			this.dataGridTextBoxColumn24.HeaderText = "Prioridad";
			this.dataGridTextBoxColumn24.MappingName = "Prioridad";
			this.dataGridTextBoxColumn24.ReadOnly = true;
			this.dataGridTextBoxColumn24.Width = 50;
			// 
			// dataGridTextBoxColumn25
			// 
			this.dataGridTextBoxColumn25.Format = "";
			this.dataGridTextBoxColumn25.FormatInfo = null;
			this.dataGridTextBoxColumn25.HeaderText = "Fecha";
			this.dataGridTextBoxColumn25.MappingName = "Fecha";
			this.dataGridTextBoxColumn25.ReadOnly = true;
			this.dataGridTextBoxColumn25.Width = 140;
			// 
			// dataGridTextBoxColumn42
			// 
			this.dataGridTextBoxColumn42.Format = "";
			this.dataGridTextBoxColumn42.FormatInfo = null;
			this.dataGridTextBoxColumn42.HeaderText = "Enviado por";
			this.dataGridTextBoxColumn42.MappingName = "Enviado por";
			this.dataGridTextBoxColumn42.ReadOnly = true;
			this.dataGridTextBoxColumn42.Width = 140;
			// 
			// dataGridTextBoxColumn26
			// 
			this.dataGridTextBoxColumn26.Format = "";
			this.dataGridTextBoxColumn26.FormatInfo = null;
			this.dataGridTextBoxColumn26.HeaderText = "Asunto";
			this.dataGridTextBoxColumn26.MappingName = "Asunto";
			this.dataGridTextBoxColumn26.ReadOnly = true;
			this.dataGridTextBoxColumn26.Width = 200;
			// 
			// dataGridTextBoxColumn27
			// 
			this.dataGridTextBoxColumn27.Format = "";
			this.dataGridTextBoxColumn27.FormatInfo = null;
			this.dataGridTextBoxColumn27.HeaderText = "Mensaje";
			this.dataGridTextBoxColumn27.MappingName = "Mensaje";
			this.dataGridTextBoxColumn27.ReadOnly = true;
			this.dataGridTextBoxColumn27.Width = 300;
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
			this.tabFiltro1.Controls.Add(this.groupBox4);
			this.tabFiltro1.Controls.Add(this.groupBox3);
			this.tabFiltro1.Controls.Add(this.groupBox2);
			this.tabFiltro1.Controls.Add(this.gbFechaEmision);
			this.tabFiltro1.Controls.Add(this.groupBox17);
			this.tabFiltro1.Controls.Add(this.butAceptar1);
			this.tabFiltro1.Controls.Add(this.butSalir1);
			this.tabFiltro1.Controls.Add(this.butLimpiar1);
			this.tabFiltro1.Controls.Add(this.butBuscar1);
			this.tabFiltro1.Controls.Add(this.groupBox1);
			this.tabFiltro1.ImageIndex = 0;
			this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
			this.tabFiltro1.Name = "tabFiltro1";
			this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
			this.tabFiltro1.TabIndex = 0;
			this.tabFiltro1.Text = "Filtro Rápido";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbEstadoB);
			this.groupBox4.Location = new System.Drawing.Point(424, 64);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(200, 48);
			this.groupBox4.TabIndex = 21;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Estado";
			// 
			// cbEstadoB
			// 
			this.cbEstadoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEstadoB.ItemHeight = 13;
			this.cbEstadoB.Location = new System.Drawing.Point(8, 16);
			this.cbEstadoB.Name = "cbEstadoB";
			this.cbEstadoB.Size = new System.Drawing.Size(184, 21);
			this.cbEstadoB.TabIndex = 11;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cbPrioridadB);
			this.groupBox3.Location = new System.Drawing.Point(424, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 48);
			this.groupBox3.TabIndex = 20;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Prioridad";
			// 
			// cbPrioridadB
			// 
			this.cbPrioridadB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPrioridadB.ItemHeight = 13;
			this.cbPrioridadB.Location = new System.Drawing.Point(8, 16);
			this.cbPrioridadB.Name = "cbPrioridadB";
			this.cbPrioridadB.Size = new System.Drawing.Size(184, 21);
			this.cbPrioridadB.TabIndex = 11;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbCuerpoB);
			this.groupBox2.Location = new System.Drawing.Point(216, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 48);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cuerpo de Mensaje";
			// 
			// tbCuerpoB
			// 
			this.tbCuerpoB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCuerpoB.Location = new System.Drawing.Point(8, 16);
			this.tbCuerpoB.Name = "tbCuerpoB";
			this.tbCuerpoB.Size = new System.Drawing.Size(184, 20);
			this.tbCuerpoB.TabIndex = 1;
			this.tbCuerpoB.Text = "";
			// 
			// gbFechaEmision
			// 
			this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionHasta);
			this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionDesde);
			this.gbFechaEmision.Controls.Add(this.chkFechaEmision);
			this.gbFechaEmision.Location = new System.Drawing.Point(8, 8);
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
			this.chkFechaEmision.Size = new System.Drawing.Size(104, 16);
			this.chkFechaEmision.TabIndex = 4;
			this.chkFechaEmision.Text = "Fecha de Envío";
			this.chkFechaEmision.CheckedChanged += new System.EventHandler(this.chkFechaEmision_CheckedChanged);
			// 
			// groupBox17
			// 
			this.groupBox17.Controls.Add(this.cbEmisorB);
			this.groupBox17.Location = new System.Drawing.Point(8, 64);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(200, 48);
			this.groupBox17.TabIndex = 16;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Enviados por";
			// 
			// cbEmisorB
			// 
			this.cbEmisorB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEmisorB.ItemHeight = 13;
			this.cbEmisorB.Location = new System.Drawing.Point(8, 16);
			this.cbEmisorB.Name = "cbEmisorB";
			this.cbEmisorB.Size = new System.Drawing.Size(184, 21);
			this.cbEmisorB.TabIndex = 11;
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
			this.groupBox1.Controls.Add(this.tbAsuntoB);
			this.groupBox1.Location = new System.Drawing.Point(216, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Asunto";
			// 
			// tbAsuntoB
			// 
			this.tbAsuntoB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbAsuntoB.Location = new System.Drawing.Point(8, 16);
			this.tbAsuntoB.Name = "tbAsuntoB";
			this.tbAsuntoB.Size = new System.Drawing.Size(184, 20);
			this.tbAsuntoB.TabIndex = 1;
			this.tbAsuntoB.Text = "";
			this.tbAsuntoB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReazonSocialB_KeyPress);
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
			this.tabFiltro3.ImageIndex = 1;
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
															   "Asunto",
															   "Enviado por",
															   "Estado",
															   "Fecha",
															   "Mensaje",
															   "Prioridad"});
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
															   "Asunto",
															   "Enviado por",
															   "Estado",
															   "Fecha",
															   "Mensaje",
															   "Prioridad"});
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
															   "Asunto",
															   "Enviado por",
															   "Estado",
															   "Fecha",
															   "Mensaje",
															   "Prioridad"});
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
															   "Asunto",
															   "Enviado por",
															   "Estado",
															   "Fecha",
															   "Mensaje",
															   "Prioridad"});
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
			this.tabPage2.Controls.Add(this.gbModificacionProveedores);
			this.tabPage2.Controls.Add(this.pictureBox2);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.ImageIndex = 3;
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(792, 438);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Detalle";
			this.tabPage2.Visible = false;
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.groupBox9);
			this.gbModificacionProveedores.Controls.Add(this.butReenviar);
			this.gbModificacionProveedores.Controls.Add(this.label7);
			this.gbModificacionProveedores.Controls.Add(this.tbEnviadoPor);
			this.gbModificacionProveedores.Controls.Add(this.tbMensajeID);
			this.gbModificacionProveedores.Controls.Add(this.button1);
			this.gbModificacionProveedores.Controls.Add(this.butResponder);
			this.gbModificacionProveedores.Controls.Add(this.tbDestino);
			this.gbModificacionProveedores.Controls.Add(this.label6);
			this.gbModificacionProveedores.Controls.Add(this.label3);
			this.gbModificacionProveedores.Controls.Add(this.label2);
			this.gbModificacionProveedores.Controls.Add(this.cbPrioridad);
			this.gbModificacionProveedores.Controls.Add(this.label1);
			this.gbModificacionProveedores.Controls.Add(this.tbAsunto);
			this.gbModificacionProveedores.Controls.Add(this.tbCuerpo);
			this.gbModificacionProveedores.Controls.Add(this.label34);
			this.gbModificacionProveedores.Controls.Add(this.tabDestinatarios);
			this.gbModificacionProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(0, 32);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(792, 406);
			this.gbModificacionProveedores.TabIndex = 121;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// butReenviar
			// 
			this.butReenviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butReenviar.Image = ((System.Drawing.Image)(resources.GetObject("butReenviar.Image")));
			this.butReenviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butReenviar.Location = new System.Drawing.Point(688, 320);
			this.butReenviar.Name = "butReenviar";
			this.butReenviar.Size = new System.Drawing.Size(96, 24);
			this.butReenviar.TabIndex = 233;
			this.butReenviar.Text = "&Reenviar";
			this.butReenviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butReenviar.Click += new System.EventHandler(this.butReenviar_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 14);
			this.label7.TabIndex = 232;
			this.label7.Text = "Envió:";
			// 
			// tbEnviadoPor
			// 
			this.tbEnviadoPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEnviadoPor.Location = new System.Drawing.Point(72, 128);
			this.tbEnviadoPor.Name = "tbEnviadoPor";
			this.tbEnviadoPor.ReadOnly = true;
			this.tbEnviadoPor.Size = new System.Drawing.Size(600, 20);
			this.tbEnviadoPor.TabIndex = 231;
			this.tbEnviadoPor.Text = "";
			// 
			// tbMensajeID
			// 
			this.tbMensajeID.Location = new System.Drawing.Point(624, 80);
			this.tbMensajeID.Name = "tbMensajeID";
			this.tbMensajeID.Size = new System.Drawing.Size(32, 20);
			this.tbMensajeID.TabIndex = 230;
			this.tbMensajeID.Text = "";
			this.tbMensajeID.Visible = false;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(688, 272);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 40);
			this.button1.TabIndex = 229;
			this.button1.Text = "&Responder a Todos";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// butResponder
			// 
			this.butResponder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butResponder.Image = ((System.Drawing.Image)(resources.GetObject("butResponder.Image")));
			this.butResponder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butResponder.Location = new System.Drawing.Point(688, 240);
			this.butResponder.Name = "butResponder";
			this.butResponder.Size = new System.Drawing.Size(96, 24);
			this.butResponder.TabIndex = 226;
			this.butResponder.Text = "&Responder";
			this.butResponder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butResponder.Click += new System.EventHandler(this.butResponder_Click);
			// 
			// tbDestino
			// 
			this.tbDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDestino.Location = new System.Drawing.Point(72, 160);
			this.tbDestino.Multiline = true;
			this.tbDestino.Name = "tbDestino";
			this.tbDestino.ReadOnly = true;
			this.tbDestino.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDestino.Size = new System.Drawing.Size(600, 32);
			this.tbDestino.TabIndex = 225;
			this.tbDestino.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 224;
			this.label6.Text = "Destino:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 14);
			this.label3.TabIndex = 223;
			this.label3.Text = "Destino:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(560, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 14);
			this.label2.TabIndex = 222;
			this.label2.Text = "Prioridad";
			// 
			// cbPrioridad
			// 
			this.cbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPrioridad.Location = new System.Drawing.Point(560, 32);
			this.cbPrioridad.Name = "cbPrioridad";
			this.cbPrioridad.Size = new System.Drawing.Size(112, 21);
			this.cbPrioridad.TabIndex = 221;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 14);
			this.label1.TabIndex = 220;
			this.label1.Text = "Asunto:";
			// 
			// tbAsunto
			// 
			this.tbAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbAsunto.Location = new System.Drawing.Point(72, 200);
			this.tbAsunto.Name = "tbAsunto";
			this.tbAsunto.ReadOnly = true;
			this.tbAsunto.Size = new System.Drawing.Size(600, 20);
			this.tbAsunto.TabIndex = 219;
			this.tbAsunto.Text = "";
			// 
			// tbCuerpo
			// 
			this.tbCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCuerpo.Location = new System.Drawing.Point(16, 240);
			this.tbCuerpo.MaxLength = 8000;
			this.tbCuerpo.Multiline = true;
			this.tbCuerpo.Name = "tbCuerpo";
			this.tbCuerpo.ReadOnly = true;
			this.tbCuerpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCuerpo.Size = new System.Drawing.Size(656, 160);
			this.tbCuerpo.TabIndex = 16;
			this.tbCuerpo.Text = "";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(16, 224);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(104, 14);
			this.label34.TabIndex = 218;
			this.label34.Text = "Mensaje";
			// 
			// tabDestinatarios
			// 
			this.tabDestinatarios.Controls.Add(this.tabPage3);
			this.tabDestinatarios.Controls.Add(this.tabPage4);
			this.tabDestinatarios.Controls.Add(this.tabPage5);
			this.tabDestinatarios.HotTrack = true;
			this.tabDestinatarios.ImageList = this.imagenesTab;
			this.tabDestinatarios.Location = new System.Drawing.Point(72, 16);
			this.tabDestinatarios.Name = "tabDestinatarios";
			this.tabDestinatarios.SelectedIndex = 0;
			this.tabDestinatarios.Size = new System.Drawing.Size(480, 104);
			this.tabDestinatarios.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.lbxUsuariosListados);
			this.tabPage3.Controls.Add(this.lbxUsuariosSeleccionados);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.ImageIndex = 4;
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(472, 77);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Usuarios";
			// 
			// lbxUsuariosListados
			// 
			this.lbxUsuariosListados.BackColor = System.Drawing.SystemColors.Window;
			this.lbxUsuariosListados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxUsuariosListados.Location = new System.Drawing.Point(288, 4);
			this.lbxUsuariosListados.Name = "lbxUsuariosListados";
			this.lbxUsuariosListados.Size = new System.Drawing.Size(176, 67);
			this.lbxUsuariosListados.TabIndex = 234;
			// 
			// lbxUsuariosSeleccionados
			// 
			this.lbxUsuariosSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxUsuariosSeleccionados.Location = new System.Drawing.Point(8, 4);
			this.lbxUsuariosSeleccionados.Name = "lbxUsuariosSeleccionados";
			this.lbxUsuariosSeleccionados.Size = new System.Drawing.Size(160, 67);
			this.lbxUsuariosSeleccionados.TabIndex = 229;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(316, -26);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 228;
			this.label5.Text = "No Posee";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(-132, -26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 14);
			this.label4.TabIndex = 227;
			this.label4.Text = "Posee";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.lbxGruposListados);
			this.tabPage4.Controls.Add(this.lbxGruposSeleccionados);
			this.tabPage4.ImageIndex = 5;
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(472, 77);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Grupos";
			this.tabPage4.Visible = false;
			// 
			// lbxGruposListados
			// 
			this.lbxGruposListados.BackColor = System.Drawing.SystemColors.Window;
			this.lbxGruposListados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxGruposListados.Location = new System.Drawing.Point(288, 4);
			this.lbxGruposListados.Name = "lbxGruposListados";
			this.lbxGruposListados.Size = new System.Drawing.Size(176, 67);
			this.lbxGruposListados.TabIndex = 232;
			// 
			// lbxGruposSeleccionados
			// 
			this.lbxGruposSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxGruposSeleccionados.Location = new System.Drawing.Point(8, 4);
			this.lbxGruposSeleccionados.Name = "lbxGruposSeleccionados";
			this.lbxGruposSeleccionados.Size = new System.Drawing.Size(160, 67);
			this.lbxGruposSeleccionados.TabIndex = 227;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.lbxSucursalesListadas);
			this.tabPage5.Controls.Add(this.lbxSucursalesSeleccionadas);
			this.tabPage5.ImageIndex = 6;
			this.tabPage5.Location = new System.Drawing.Point(4, 23);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(472, 77);
			this.tabPage5.TabIndex = 2;
			this.tabPage5.Text = "Sucursales";
			this.tabPage5.Visible = false;
			// 
			// lbxSucursalesListadas
			// 
			this.lbxSucursalesListadas.BackColor = System.Drawing.SystemColors.Window;
			this.lbxSucursalesListadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxSucursalesListadas.Location = new System.Drawing.Point(288, 4);
			this.lbxSucursalesListadas.Name = "lbxSucursalesListadas";
			this.lbxSucursalesListadas.Size = new System.Drawing.Size(176, 67);
			this.lbxSucursalesListadas.TabIndex = 232;
			// 
			// lbxSucursalesSeleccionadas
			// 
			this.lbxSucursalesSeleccionadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxSucursalesSeleccionadas.Location = new System.Drawing.Point(8, 4);
			this.lbxSucursalesSeleccionadas.Name = "lbxSucursalesSeleccionadas";
			this.lbxSucursalesSeleccionadas.Size = new System.Drawing.Size(160, 67);
			this.lbxSucursalesSeleccionadas.TabIndex = 227;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.DarkSlateGray;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(32, 31);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 120;
			this.pictureBox2.TabStop = false;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.DarkSlateGray;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(792, 32);
			this.label18.TabIndex = 119;
			this.label18.Text = "     Leer Mensaje";
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
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.lblRegistro);
			this.groupBox9.Controls.Add(this.butSiguiente);
			this.groupBox9.Controls.Add(this.butAnterior);
			this.groupBox9.Location = new System.Drawing.Point(680, 128);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(104, 80);
			this.groupBox9.TabIndex = 234;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Registro";
			// 
			// lblRegistro
			// 
			this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRegistro.Location = new System.Drawing.Point(8, 40);
			this.lblRegistro.Name = "lblRegistro";
			this.lblRegistro.Size = new System.Drawing.Size(88, 14);
			this.lblRegistro.TabIndex = 102;
			this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butSiguiente
			// 
			this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
			this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSiguiente.Location = new System.Drawing.Point(16, 56);
			this.butSiguiente.Name = "butSiguiente";
			this.butSiguiente.Size = new System.Drawing.Size(72, 16);
			this.butSiguiente.TabIndex = 15;
			this.butSiguiente.Text = "Siguiente";
			this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
			// 
			// butAnterior
			// 
			this.butAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAnterior.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior.Image")));
			this.butAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAnterior.Location = new System.Drawing.Point(16, 16);
			this.butAnterior.Name = "butAnterior";
			this.butAnterior.Size = new System.Drawing.Size(72, 16);
			this.butAnterior.TabIndex = 14;
			this.butAnterior.Text = "Anterior";
			this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 180000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ucMensajeConsulta
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucMensajeConsulta";
			this.Size = new System.Drawing.Size(800, 464);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.gbFechaEmision.ResumeLayout(false);
			this.groupBox17.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabFiltro3.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.tabDestinatarios.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPrincipal.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ucMensajeConsulta_Load(object sender, System.EventArgs e)
		{
			//tbRazonSocialB.Select();
		}

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 4;  //Fecha, descendente
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

		//Carga el formulario transparente de avisos
		private void mostrarAviso(int cantidad)
		{
			try
			{
				string mensaje = "";
				if (cantidad==1)
					mensaje = "Ha recibido un mensaje nuevo.";
				else if (cantidad>1)
					mensaje = "Ha recibido " + cantidad.ToString() + " mensajes nuevos.";
			
				if (mensaje!="")
				{
					frmAvisosTransparente frmAviso = new frmAvisosTransparente(mensaje, ref this.formContenedor);
					frmAviso.Show();
					frmAviso.Top = Screen.PrimaryScreen.WorkingArea.Bottom - frmAviso.Height - 28; //this.formContenedor.Height;
					frmAviso.Left = this.formContenedor.Left + 4;
				}
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
				string sql = "SELECT     dbo.Mensaje.id, dbo.Mensaje.asunto AS Asunto, dbo.Mensaje.cuerpo AS Mensaje, dbo.Mensaje.fecha AS Fecha, dbo.Mensaje.prioridadID, " +
					"dbo.Mensaje.estadoMensajeID, dbo.Mensaje.usuarioEmisorID, dbo.tv_MensajeEstado.descripcion AS Estado,  " +
					"dbo.tv_MensajePrioridad.descripcion AS Prioridad, Usuario_1.apellido + ', ' + Usuario_1.nombre AS [Enviado por] " +
					"FROM         dbo.Usuario Usuario_1 RIGHT OUTER JOIN " +
					"dbo.Mensaje ON Usuario_1.id = dbo.Mensaje.usuarioEmisorID LEFT OUTER JOIN " +
					"dbo.tv_MensajePrioridad ON dbo.Mensaje.prioridadID = dbo.tv_MensajePrioridad.id LEFT OUTER JOIN " +
					"dbo.MensajeLeido INNER JOIN " +
					"dbo.tv_MensajeEstado ON dbo.MensajeLeido.estadoMensajeID = dbo.tv_MensajeEstado.id INNER JOIN " +
					"dbo.Usuario ON dbo.MensajeLeido.usuarioID = dbo.Usuario.id ON dbo.Mensaje.id = dbo.MensajeLeido.mensajeID " +
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
				if (tbAsuntoB.Text!="") 
				{
					filtro = filtro + " AND dbo.Mensaje.asunto LIKE '%" + tbAsuntoB.Text.Trim() + "%'";
				}
				if (tbCuerpoB.Text!="") 
				{
					filtro = filtro + " AND dbo.Mensaje.cuerpo LIKE '%" + tbCuerpoB.Text.Trim() + "%'";
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
					filtro = filtro + " AND dbo.Mensaje.fecha >= " + sfechaDesde;
				
					dia = fechaHasta.Day.ToString("00");
					mes = fechaHasta.Month.ToString("00");
					anio = fechaHasta.Year.ToString("0000");
					sfechaHasta = "{ts '" + anio + "-" + mes + "-" + dia + " 23:59:59'}";
					filtro = filtro + " AND dbo.Mensaje.fecha <= " + sfechaHasta;
				}
				if (cbPrioridadB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Mensaje.prioridadID = CAST('" + cbPrioridadB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbEmisorB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Mensaje.usuarioEmisorID = CAST('" + cbEmisorB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbEstadoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.MensajeLeido.estadoMensajeID = CAST('" + cbEstadoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}

				//Este filtro lo agrega siempre, es para que muestre solo los mensajes dirigidos al usuario que consulta
				filtro += " AND dbo.MensajeLeido.usuarioID = CAST('" + this.configuracion.usuario.id.ToString() + "' AS uniqueidentifier)";

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
		{/*
			chkFechaEmision.Checked = false;
			tbAsuntoB.Text = "";
			cbPrioridadB.SelectedValue = 0;
			cbEmisorB.SelectedValue = 0;
			tbCuerpoB.Text = "";
			tbRazonSocialB.Text = "";
			cbEstadoB.SelectedValue = 0;*/
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

						tbMensajeID.Text = dt.Rows[currentRow]["ID"].ToString();

						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@mensajeID", new System.Guid(tbMensajeID.Text));
					
						//Carga al emisor y a todos los que fueron copiados como destinatarios.
						UtilUI.llenarListBox(ref lbxUsuariosSeleccionados, this.conexion, "sp_getMensajeDestinoUsuarioByPosee", "", -1, param);
						UtilUI.llenarListBox(ref lbxUsuariosListados, this.conexion, "sp_getMensajeDestinoUsuarioByNoPosee", "", -1, param);
					
						UtilUI.llenarListBox(ref lbxGruposSeleccionados, this.conexion, "sp_getMensajeDestinoGrupoByPosee", "", -1, param);
						UtilUI.llenarListBox(ref lbxGruposListados, this.conexion, "sp_getMensajeDestinoGrupoByNoPosee", "", -1, param);

						UtilUI.llenarListBox(ref lbxSucursalesSeleccionadas, this.conexion, "sp_getMensajeDestinoSucursalByPosee", "", -1, param);
						UtilUI.llenarListBox(ref lbxSucursalesListadas, this.conexion, "sp_getMensajeDestinoSucursalByNoPosee", "", -1, param);
					
						tbAsunto.Text = dt.Rows[currentRow]["Asunto"].ToString();
						tbCuerpo.Text = dt.Rows[currentRow]["Mensaje"].ToString();
						string prioridadID = dt.Rows[currentRow]["prioridadID"].ToString();;
						prioridadID = prioridadID=="" ? Utilidades.ID_VACIO : prioridadID;
						cbPrioridad.SelectedValue = prioridadID; //dt.Rows[currentRow]["prioridadID"].ToString();
						tbEnviadoPor.Text = dt.Rows[currentRow]["Enviado por"].ToString();

						armarCadenaDestino();

						//Marca el mensaje como leido
						param = new SqlParameter[2];
						param[0] = new SqlParameter("@mensajeID", new System.Guid(tbMensajeID.Text));
						param[1] = new SqlParameter("@usuarioID", new System.Guid(this.configuracion.usuario.id));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_MensajeMarcarComoLeido", param);
						dt.Rows[currentRow]["Estado"] = "Leído";

						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
					}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		private void armarCadenaDestino()
		{
			try
			{
				string coma = "";
				string cadena = "";
				int i = 0;
			
				//Recorre los usuarios
				DataTable dt = (DataTable)lbxUsuariosSeleccionados.DataSource;
				for (i=0; i<dt.Rows.Count; i++)
				{
					cadena += dt.Rows[i]["descripcion"].ToString() + "; ";
				}

				//Recorre los grupos
				dt = (DataTable)lbxGruposSeleccionados.DataSource;
				for (i=0; i<dt.Rows.Count; i++)
				{
					cadena += dt.Rows[i]["descripcion"].ToString() + "; ";
				}

				//Recorre las sucursales
				dt = (DataTable)lbxSucursalesSeleccionadas.DataSource;
				for (i=0; i<dt.Rows.Count; i++)
				{
					cadena += dt.Rows[i]["descripcion"].ToString() + "; ";
				}

				tbDestino.Text = cadena;
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
							DialogResult dr = MessageBox.Show("¿Desea borrar las Notas de Pedido seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Notas de Pedido...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarProveedor", param);

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
				UtilUI.llenarCombo(ref cbEmisorB, this.conexion, "sp_getAllUsuarios", "Todos", 0);
				UtilUI.llenarCombo(ref cbPrioridadB, this.conexion, "sp_getAlltv_MensajePrioridad", "Todas", 0);
				UtilUI.llenarCombo(ref cbEstadoB, this.conexion, "sp_getAlltv_MensajeEstados", "Todos", 0);
				acomodarCombosOrden();

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
				//dgRemitoLinea.DataSource = (DataTable)dataset.Tables["v_Articulo"];

				//Inicializa los combos de detalle
				UtilUI.llenarCombo(ref cbPrioridad, this.conexion, "sp_getAlltv_MensajePrioridad", "", -1);
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


		private void butResponder_Click(object sender, System.EventArgs e)
		{
			abrirFormularioAlta(tbMensajeID.Text, "RESPONDER");
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			abrirFormularioAlta(tbMensajeID.Text, "RESPONDER_A_TODOS");
		}
		private void butReenviar_Click(object sender, System.EventArgs e)
		{
			abrirFormularioAlta(tbMensajeID.Text, "REENVIAR");
		}

		//Abre el formulario de alta de mensajes
		private void abrirFormularioAlta(string mensajeID, string operacion)
		{
			try
			{
				frmMensajeAlta form = new frmMensajeAlta(this.configuracion, mensajeID, operacion);
				form.statusBar1 = this.statusBarPrincipal;
			
				form.ShowDialog();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		public void autoEjecutar()
		{
			try
			{
				//Establece buscar los mensajes no leidos
				UtilUI.comboSeleccionarItemByIdentificador("NO_LEIDO", ref cbEstadoB);

				//Ejecuta la busqueda
				ejecutarBusqueda();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				//Verifica si hay mensajes nuevos en el servidor
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@usuarioID", new System.Guid(this.configuracion.usuario.id));
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_ConsultarMensajesNuevos", param);
				if (dr.HasRows)
				{
					dr.Read();
					mostrarAviso(int.Parse(dr["cantidad"].ToString()));
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


	}
}
