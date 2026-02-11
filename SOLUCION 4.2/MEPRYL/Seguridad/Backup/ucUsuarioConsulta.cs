using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Seguridad
{
	/// <summary>
	/// Summary description for ucCuentaAlta.
	/// </summary>
	public class ucUsuarioConsulta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
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
		private System.Windows.Forms.GroupBox gbProveedor;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label18;
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
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button butQuitarTodo;
		private System.Windows.Forms.Button butAgregarTodo;
		private System.Windows.Forms.Button butQuitar;
		private System.Windows.Forms.Button butAgregar;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox lbxNoPosee;
		private System.Windows.Forms.ListBox lbxPosee;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbClave;
		private System.Windows.Forms.TextBox tbNombreUsuario;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbSucursal;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tbApellido;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbNombres;
		private System.Windows.Forms.TextBox tbComentarios;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TextBox tbNombresB;
		private System.Windows.Forms.TextBox tbApellidoB;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox tbNombreUsuarioB;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.ComboBox cbSucursalB;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.ComponentModel.IContainer components;

		public ucUsuarioConsulta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucUsuarioConsulta));
			this.tabPrincipal = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.butVistaPrevia = new System.Windows.Forms.Button();
			this.butImprimir = new System.Windows.Forms.Button();
			this.butBorrar = new System.Windows.Forms.Button();
			this.dgItems = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cbSucursalB = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.tbNombreUsuarioB = new System.Windows.Forms.TextBox();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.butLimpiar1 = new System.Windows.Forms.Button();
			this.butBuscar1 = new System.Windows.Forms.Button();
			this.gbProveedor = new System.Windows.Forms.GroupBox();
			this.tbNombresB = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbApellidoB = new System.Windows.Forms.TextBox();
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
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.lblRegistro = new System.Windows.Forms.Label();
			this.butSiguiente = new System.Windows.Forms.Button();
			this.butAnterior = new System.Windows.Forms.Button();
			this.butGuardar = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.butQuitarTodo = new System.Windows.Forms.Button();
			this.butAgregarTodo = new System.Windows.Forms.Button();
			this.butQuitar = new System.Windows.Forms.Button();
			this.butAgregar = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lbxNoPosee = new System.Windows.Forms.ListBox();
			this.lbxPosee = new System.Windows.Forms.ListBox();
			this.tbID = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbClave = new System.Windows.Forms.TextBox();
			this.tbNombreUsuario = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbSucursal = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.tbApellido = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbNombres = new System.Windows.Forms.TextBox();
			this.tbComentarios = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.butSalir = new System.Windows.Forms.Button();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label18 = new System.Windows.Forms.Label();
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
			this.tabPrincipal.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
			this.tabFiltro.SuspendLayout();
			this.tabFiltro1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.gbProveedor.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabFiltro3.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.gbModificacionProveedores.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
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
			this.tabPrincipal.Size = new System.Drawing.Size(816, 456);
			this.tabPrincipal.TabIndex = 3;
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
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabPage1.ImageIndex = 0;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(808, 430);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Listado de Usuarios";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 152);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 116;
			this.pictureBox1.TabStop = false;
			// 
			// butVistaPrevia
			// 
			this.butVistaPrevia.BackColor = System.Drawing.Color.SteelBlue;
			this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
			this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butVistaPrevia.Location = new System.Drawing.Point(340, 157);
			this.butVistaPrevia.Name = "butVistaPrevia";
			this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
			this.butVistaPrevia.TabIndex = 4;
			this.butVistaPrevia.Text = "&Vista Previa";
			this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butVistaPrevia.Visible = false;
			// 
			// butImprimir
			// 
			this.butImprimir.BackColor = System.Drawing.Color.SteelBlue;
			this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butImprimir.ForeColor = System.Drawing.Color.White;
			this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butImprimir.Location = new System.Drawing.Point(266, 157);
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
			this.butBorrar.Image = ((System.Drawing.Image)(resources.GetObject("butBorrar.Image")));
			this.butBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBorrar.Location = new System.Drawing.Point(644, 157);
			this.butBorrar.Name = "butBorrar";
			this.butBorrar.Size = new System.Drawing.Size(64, 23);
			this.butBorrar.TabIndex = 2;
			this.butBorrar.Text = "&Borrar";
			this.butBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.dgItems.CaptionText = "     Listado de Usuarios";
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
			this.dgItems.Size = new System.Drawing.Size(808, 278);
			this.dgItems.TabIndex = 1;
			this.dgItems.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								this.dataGridTableStyle1});
			this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.LightCyan;
			this.dataGridTableStyle1.DataGrid = this.dgItems;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn17});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Items";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "Sucursal";
			this.dataGridTextBoxColumn15.MappingName = "Sucursal";
			this.dataGridTextBoxColumn15.ReadOnly = true;
			this.dataGridTextBoxColumn15.Width = 150;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "Apellido";
			this.dataGridTextBoxColumn13.MappingName = "Apellido";
			this.dataGridTextBoxColumn13.ReadOnly = true;
			this.dataGridTextBoxColumn13.Width = 150;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "Nombres";
			this.dataGridTextBoxColumn14.MappingName = "Nombres";
			this.dataGridTextBoxColumn14.ReadOnly = true;
			this.dataGridTextBoxColumn14.Width = 150;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "Nombre de Usuario";
			this.dataGridTextBoxColumn16.MappingName = "Nombre de Usuario";
			this.dataGridTextBoxColumn16.ReadOnly = true;
			this.dataGridTextBoxColumn16.Width = 150;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "E-Mail";
			this.dataGridTextBoxColumn17.MappingName = "E-Mail";
			this.dataGridTextBoxColumn17.ReadOnly = true;
			this.dataGridTextBoxColumn17.Width = 200;
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
			this.tabFiltro.Size = new System.Drawing.Size(808, 152);
			this.tabFiltro.TabIndex = 0;
			// 
			// tabFiltro1
			// 
			this.tabFiltro1.Controls.Add(this.groupBox6);
			this.tabFiltro1.Controls.Add(this.groupBox5);
			this.tabFiltro1.Controls.Add(this.butSalir1);
			this.tabFiltro1.Controls.Add(this.butLimpiar1);
			this.tabFiltro1.Controls.Add(this.butBuscar1);
			this.tabFiltro1.Controls.Add(this.gbProveedor);
			this.tabFiltro1.Controls.Add(this.groupBox1);
			this.tabFiltro1.ImageIndex = 2;
			this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
			this.tabFiltro1.Name = "tabFiltro1";
			this.tabFiltro1.Size = new System.Drawing.Size(800, 126);
			this.tabFiltro1.TabIndex = 0;
			this.tabFiltro1.Text = "Filtro Rápido";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cbSucursalB);
			this.groupBox6.Location = new System.Drawing.Point(216, 64);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(200, 48);
			this.groupBox6.TabIndex = 11;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Sucursal";
			// 
			// cbSucursalB
			// 
			this.cbSucursalB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSucursalB.Location = new System.Drawing.Point(8, 14);
			this.cbSucursalB.MaxLength = 100;
			this.cbSucursalB.Name = "cbSucursalB";
			this.cbSucursalB.Size = new System.Drawing.Size(184, 21);
			this.cbSucursalB.TabIndex = 222;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.tbNombreUsuarioB);
			this.groupBox5.Location = new System.Drawing.Point(8, 64);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(200, 48);
			this.groupBox5.TabIndex = 10;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Nombre de Usuario";
			// 
			// tbNombreUsuarioB
			// 
			this.tbNombreUsuarioB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombreUsuarioB.Location = new System.Drawing.Point(8, 16);
			this.tbNombreUsuarioB.Name = "tbNombreUsuarioB";
			this.tbNombreUsuarioB.Size = new System.Drawing.Size(184, 20);
			this.tbNombreUsuarioB.TabIndex = 2;
			this.tbNombreUsuarioB.Text = "";
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
			// gbProveedor
			// 
			this.gbProveedor.Controls.Add(this.tbNombresB);
			this.gbProveedor.Location = new System.Drawing.Point(216, 8);
			this.gbProveedor.Name = "gbProveedor";
			this.gbProveedor.Size = new System.Drawing.Size(200, 48);
			this.gbProveedor.TabIndex = 5;
			this.gbProveedor.TabStop = false;
			this.gbProveedor.Text = "Nombres";
			// 
			// tbNombresB
			// 
			this.tbNombresB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombresB.Location = new System.Drawing.Point(8, 16);
			this.tbNombresB.Name = "tbNombresB";
			this.tbNombresB.Size = new System.Drawing.Size(184, 20);
			this.tbNombresB.TabIndex = 2;
			this.tbNombresB.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbApellidoB);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Apellido";
			// 
			// tbApellidoB
			// 
			this.tbApellidoB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbApellidoB.Location = new System.Drawing.Point(8, 16);
			this.tbApellidoB.Name = "tbApellidoB";
			this.tbApellidoB.Size = new System.Drawing.Size(184, 20);
			this.tbApellidoB.TabIndex = 1;
			this.tbApellidoB.Text = "";
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
			this.tabFiltro3.Size = new System.Drawing.Size(800, 126);
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
			this.cbCampoOrden2.Items.AddRange(new object[] {
															   "---",
															   "Apellido",
															   "E-Mail",
															   "Nombre de Usuario",
															   "Nombres",
															   "Sucursal"});
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
															   "Apellido",
															   "E-Mail",
															   "Nombre de Usuario",
															   "Nombres",
															   "Sucursal"});
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
			this.cbCampoOrden1.Items.AddRange(new object[] {
															   "---",
															   "Apellido",
															   "E-Mail",
															   "Nombre de Usuario",
															   "Nombres",
															   "Sucursal"});
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
			this.cbCampoOrden3.Items.AddRange(new object[] {
															   "---",
															   "Apellido",
															   "E-Mail",
															   "Nombre de Usuario",
															   "Nombres",
															   "Sucursal"});
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
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.gbModificacionProveedores);
			this.tabPage2.Controls.Add(this.pictureBox2);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.ImageIndex = 1;
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(808, 430);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Detalle";
			this.tabPage2.Visible = false;
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.groupBox9);
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.groupBox3);
			this.gbModificacionProveedores.Controls.Add(this.groupBox2);
			this.gbModificacionProveedores.Controls.Add(this.groupBox4);
			this.gbModificacionProveedores.Controls.Add(this.tbComentarios);
			this.gbModificacionProveedores.Controls.Add(this.label34);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(4, 32);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 392);
			this.gbModificacionProveedores.TabIndex = 119;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.lblRegistro);
			this.groupBox9.Controls.Add(this.butSiguiente);
			this.groupBox9.Controls.Add(this.butAnterior);
			this.groupBox9.Location = new System.Drawing.Point(349, 304);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(104, 80);
			this.groupBox9.TabIndex = 229;
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
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(560, 352);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 3;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.butQuitarTodo);
			this.groupBox3.Controls.Add(this.butAgregarTodo);
			this.groupBox3.Controls.Add(this.butQuitar);
			this.groupBox3.Controls.Add(this.butAgregar);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.lbxNoPosee);
			this.groupBox3.Controls.Add(this.lbxPosee);
			this.groupBox3.Controls.Add(this.tbID);
			this.groupBox3.Location = new System.Drawing.Point(8, 136);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 160);
			this.groupBox3.TabIndex = 227;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Perfil(es) del Usuario";
			// 
			// butQuitarTodo
			// 
			this.butQuitarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarTodo.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarTodo.Image")));
			this.butQuitarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarTodo.Location = new System.Drawing.Point(344, 128);
			this.butQuitarTodo.Name = "butQuitarTodo";
			this.butQuitarTodo.Size = new System.Drawing.Size(96, 24);
			this.butQuitarTodo.TabIndex = 4;
			this.butQuitarTodo.Text = "&Quitar Todo";
			this.butQuitarTodo.Click += new System.EventHandler(this.butQuitarTodo_Click);
			// 
			// butAgregarTodo
			// 
			this.butAgregarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarTodo.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarTodo.Image")));
			this.butAgregarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarTodo.Location = new System.Drawing.Point(344, 104);
			this.butAgregarTodo.Name = "butAgregarTodo";
			this.butAgregarTodo.Size = new System.Drawing.Size(96, 24);
			this.butAgregarTodo.TabIndex = 3;
			this.butAgregarTodo.Text = "&Agregar Todo";
			this.butAgregarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAgregarTodo.Click += new System.EventHandler(this.butAgregarTodo_Click);
			// 
			// butQuitar
			// 
			this.butQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitar.Image = ((System.Drawing.Image)(resources.GetObject("butQuitar.Image")));
			this.butQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitar.Location = new System.Drawing.Point(344, 64);
			this.butQuitar.Name = "butQuitar";
			this.butQuitar.Size = new System.Drawing.Size(96, 24);
			this.butQuitar.TabIndex = 2;
			this.butQuitar.Text = "&Quitar";
			this.butQuitar.Click += new System.EventHandler(this.butQuitar_Click);
			// 
			// butAgregar
			// 
			this.butAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregar.Image = ((System.Drawing.Image)(resources.GetObject("butAgregar.Image")));
			this.butAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregar.Location = new System.Drawing.Point(344, 40);
			this.butAgregar.Name = "butAgregar";
			this.butAgregar.Size = new System.Drawing.Size(96, 24);
			this.butAgregar.TabIndex = 1;
			this.butAgregar.Text = "&Agregar";
			this.butAgregar.Click += new System.EventHandler(this.butAgregar_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(480, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 220;
			this.label5.Text = "No Posee";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 14);
			this.label4.TabIndex = 219;
			this.label4.Text = "Posee";
			// 
			// lbxNoPosee
			// 
			this.lbxNoPosee.BackColor = System.Drawing.SystemColors.Window;
			this.lbxNoPosee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxNoPosee.Location = new System.Drawing.Point(480, 40);
			this.lbxNoPosee.Name = "lbxNoPosee";
			this.lbxNoPosee.Size = new System.Drawing.Size(272, 106);
			this.lbxNoPosee.TabIndex = 5;
			this.lbxNoPosee.DoubleClick += new System.EventHandler(this.lbxNoPosee_DoubleClick);
			// 
			// lbxPosee
			// 
			this.lbxPosee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxPosee.Location = new System.Drawing.Point(32, 40);
			this.lbxPosee.Name = "lbxPosee";
			this.lbxPosee.Size = new System.Drawing.Size(272, 106);
			this.lbxPosee.TabIndex = 0;
			this.lbxPosee.DoubleClick += new System.EventHandler(this.lbxPosee_DoubleClick);
			// 
			// tbID
			// 
			this.tbID.Location = new System.Drawing.Point(352, 8);
			this.tbID.Name = "tbID";
			this.tbID.Size = new System.Drawing.Size(64, 20);
			this.tbID.TabIndex = 230;
			this.tbID.Text = "";
			this.tbID.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.tbClave);
			this.groupBox2.Controls.Add(this.tbNombreUsuario);
			this.groupBox2.Location = new System.Drawing.Point(464, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(328, 112);
			this.groupBox2.TabIndex = 226;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Identificación";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 14);
			this.label3.TabIndex = 222;
			this.label3.Text = "Nombre de Usuario";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 14);
			this.label2.TabIndex = 224;
			this.label2.Text = "Contraseña";
			// 
			// tbClave
			// 
			this.tbClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbClave.Location = new System.Drawing.Point(16, 72);
			this.tbClave.Name = "tbClave";
			this.tbClave.PasswordChar = '*';
			this.tbClave.Size = new System.Drawing.Size(200, 20);
			this.tbClave.TabIndex = 223;
			this.tbClave.Text = "1234";
			// 
			// tbNombreUsuario
			// 
			this.tbNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombreUsuario.Location = new System.Drawing.Point(16, 32);
			this.tbNombreUsuario.Name = "tbNombreUsuario";
			this.tbNombreUsuario.Size = new System.Drawing.Size(200, 20);
			this.tbNombreUsuario.TabIndex = 221;
			this.tbNombreUsuario.Text = "";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbSucursal);
			this.groupBox4.Controls.Add(this.label26);
			this.groupBox4.Controls.Add(this.tbApellido);
			this.groupBox4.Controls.Add(this.label27);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.tbEmail);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.tbNombres);
			this.groupBox4.Location = new System.Drawing.Point(8, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(448, 112);
			this.groupBox4.TabIndex = 225;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Datos";
			// 
			// cbSucursal
			// 
			this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSucursal.Location = new System.Drawing.Point(232, 72);
			this.cbSucursal.MaxLength = 100;
			this.cbSucursal.Name = "cbSucursal";
			this.cbSucursal.Size = new System.Drawing.Size(200, 21);
			this.cbSucursal.TabIndex = 221;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(232, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 14);
			this.label26.TabIndex = 214;
			this.label26.Text = "Nombres";
			// 
			// tbApellido
			// 
			this.tbApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbApellido.Location = new System.Drawing.Point(16, 32);
			this.tbApellido.Name = "tbApellido";
			this.tbApellido.Size = new System.Drawing.Size(200, 20);
			this.tbApellido.TabIndex = 1;
			this.tbApellido.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(16, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(136, 14);
			this.label27.TabIndex = 212;
			this.label27.Text = "Apellido";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(232, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 14);
			this.label1.TabIndex = 220;
			this.label1.Text = "Sucursal";
			// 
			// tbEmail
			// 
			this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEmail.Location = new System.Drawing.Point(16, 72);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(200, 20);
			this.tbEmail.TabIndex = 13;
			this.tbEmail.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 56);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(136, 14);
			this.label13.TabIndex = 208;
			this.label13.Text = "E-Mail";
			// 
			// tbNombres
			// 
			this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombres.Location = new System.Drawing.Point(232, 32);
			this.tbNombres.Name = "tbNombres";
			this.tbNombres.Size = new System.Drawing.Size(200, 20);
			this.tbNombres.TabIndex = 2;
			this.tbNombres.Text = "";
			// 
			// tbComentarios
			// 
			this.tbComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbComentarios.Location = new System.Drawing.Point(8, 312);
			this.tbComentarios.Multiline = true;
			this.tbComentarios.Name = "tbComentarios";
			this.tbComentarios.Size = new System.Drawing.Size(304, 64);
			this.tbComentarios.TabIndex = 1;
			this.tbComentarios.Text = "";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(8, 296);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(104, 14);
			this.label34.TabIndex = 218;
			this.label34.Text = "Comentarios";
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(688, 352);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 24);
			this.butSalir.TabIndex = 4;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir1_Click);
			// 
			// butLimpiar
			// 
			this.butLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(688, 320);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 2;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click_1);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.DarkSlateGray;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(32, 31);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 118;
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
			this.label18.Size = new System.Drawing.Size(808, 32);
			this.label18.TabIndex = 116;
			this.label18.Text = "     Modificación de Usuario";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Cuenta";
			this.dataGridTextBoxColumn1.MappingName = "Cuenta";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 140;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Numero";
			this.dataGridTextBoxColumn2.MappingName = "Numero";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 75;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Titular";
			this.dataGridTextBoxColumn3.MappingName = "Titular";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 140;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Banco";
			this.dataGridTextBoxColumn4.MappingName = "Banco";
			this.dataGridTextBoxColumn4.ReadOnly = true;
			this.dataGridTextBoxColumn4.Width = 140;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "Sucursal";
			this.dataGridTextBoxColumn5.MappingName = "Sucursal";
			this.dataGridTextBoxColumn5.ReadOnly = true;
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "Tipo";
			this.dataGridTextBoxColumn6.MappingName = "Tipo";
			this.dataGridTextBoxColumn6.ReadOnly = true;
			this.dataGridTextBoxColumn6.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "Serie Directo";
			this.dataGridTextBoxColumn7.MappingName = "serieActualDirecto";
			this.dataGridTextBoxColumn7.ReadOnly = true;
			this.dataGridTextBoxColumn7.Width = 10;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "Directo";
			this.dataGridTextBoxColumn8.MappingName = "proximoNroChequeDirecto";
			this.dataGridTextBoxColumn8.ReadOnly = true;
			this.dataGridTextBoxColumn8.Width = 75;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "Serie Diferido";
			this.dataGridTextBoxColumn9.MappingName = "serieActualDiferido";
			this.dataGridTextBoxColumn9.ReadOnly = true;
			this.dataGridTextBoxColumn9.Width = 10;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "Diferido";
			this.dataGridTextBoxColumn10.MappingName = "proximoNroChequeDiferido";
			this.dataGridTextBoxColumn10.ReadOnly = true;
			this.dataGridTextBoxColumn10.Width = 75;
			// 
			// ucUsuarioConsulta
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucUsuarioConsulta";
			this.Size = new System.Drawing.Size(816, 456);
			this.tabPrincipal.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.gbProveedor.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabFiltro3.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			limpiarFormularioBusqueda();
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
				string sql = "SELECT     dbo.Usuario.id, dbo.Usuario.username AS [Nombre de Usuario], dbo.Usuario.password, dbo.Usuario.apellido AS Apellido, " +
					"dbo.Usuario.nombre AS Nombres, dbo.Usuario.sucursalID, dbo.Usuario.email1 AS [E-Mail], dbo.Usuario.comentarios, " +
					"dbo.Sucursal.nombre AS Sucursal, dbo.Sucursal.numero AS sucursalNumero " +
					"FROM         dbo.Usuario LEFT OUTER JOIN " +
					"dbo.Sucursal ON dbo.Usuario.sucursalID = dbo.Sucursal.id " +
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

				if (tbApellidoB.Text!="") 
				{
					filtro = filtro + " AND apellido LIKE '%" + tbApellidoB.Text.Trim() + "%'";
				}
				if (tbNombresB.Text!="") 
				{
					filtro = filtro + " AND dbo.Usuario.nombre LIKE '%" + tbNombresB.Text.Trim() + "%'";
				}
				if (tbNombreUsuarioB.Text!="") 
				{
					filtro = filtro + " AND username LIKE '%" + tbNombreUsuarioB.Text.Trim() + "%'";
				}
				if (cbSucursalB.SelectedIndex>0) 
				{
					filtro = filtro + " AND sucursalID = CAST('" + cbSucursalB.SelectedValue.ToString() + "' AS uniqueidentifier)";
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

		private void butLimpiar3_Click(object sender, System.EventArgs e)
		{
			acomodarCombosOrden();
		}

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 1;  //Apellido
				rbAsc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 4;  //Nombres
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

		public void inicializarComponentes()
		{
			acomodarCombosOrden();

			UtilUI.llenarCombo(ref cbSucursalB, this.conexion, "sp_getAllSucursals", "Todas", 0);

			UtilUI.llenarCombo(ref cbSucursal, this.conexion, "sp_getAllSucursals", "", -1);
		}

		private void dgItems_DoubleClick(object sender, System.EventArgs e)
		{
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
						tbApellido.Text = dt.Rows[currentRow]["Apellido"].ToString();
						tbNombres.Text = dt.Rows[currentRow]["Nombres"].ToString();
						tbEmail.Text = dt.Rows[currentRow]["E-Mail"].ToString();
						tbNombreUsuario.Text = dt.Rows[currentRow]["Nombre de Usuario"].ToString();
						tbClave.Text = Utilidades.desencriptar(dt.Rows[currentRow]["password"].ToString());
						cbSucursal.SelectedValue = dt.Rows[currentRow]["sucursalID"].ToString();
					
						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@usuarioID", new System.Guid(tbID.Text));
						UtilUI.llenarListBox(ref lbxPosee, this.conexion, "sp_getPerfilesByUsuarioPosee", "", -1, param);

						UtilUI.llenarListBox(ref lbxNoPosee, this.conexion, "sp_getPerfilesByUsuarioNoPosee", "", -1, param);

						tbComentarios.Text = dt.Rows[currentRow]["comentarios"].ToString();


						tbApellido.Select();

						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

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

		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		private void limpiarFormulario()
		{
			try
			{
				tbApellido.Text = "";
				tbNombres.Text = "";
				tbEmail.Text = "";
				cbSucursal.SelectedIndex = 0;
				tbNombreUsuario.Text = "";
				tbClave.Text = "";
				tbComentarios.Text = "";
				quitarTodo();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void limpiarFormularioBusqueda()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				tbApellidoB.Text = "";
				tbNombresB.Text = "";
				tbNombreUsuarioB.Text = "";
				inicializarComponentes();
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
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Guardando registro...", true);
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
			
				if (tbApellido.Text.Trim()=="")
				{
					mensaje += "   - El campo Apellido está vacío.\r\n";
					resultado = false;
				}
				if (tbNombres.Text.Trim()=="")
				{
					mensaje += "   - El campo Nombres está vacío.\r\n";
					resultado = false;
				}

				if (tbEmail.Text.Trim()!="")
					if (!Utilidades.IsEmailAddress(tbEmail.Text.Trim()))
					{
						mensaje += "   - El campo E-Mail en Datos Personales es incorrecto.\r\n";
						resultado = false;
					}
			
				/*if (existeNombreUsuario(tbNombreUsuario.Text.Trim()))
				{
					mensaje += "   - El nombre de usuario '" + tbNombreUsuario.Text.Trim() + "' ya existe en la base de datos.\r\n";
					resultado = false;
				}*/

				if (tbNombreUsuario.Text.Trim()=="")
				{
					mensaje += "   - El campo Nombre de Usuario está vacío.\r\n";
					resultado = false;
				}

				if (tbClave.Text.Trim()=="")
				{
					mensaje += "   - El campo Contraseña está vacío.\r\n";
					resultado = false;
				}
		
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Modificación de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

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
			try
			{
				//Obtiene los valores a insertar
				//Datos
				string usuarioID = tbID.Text;
				string apellido = tbApellido.Text;
				string nombres = tbNombres.Text;
				string email = tbEmail.Text;
				string sucursalID = cbSucursal.SelectedValue.ToString();
				string username = tbNombreUsuario.Text;
				string password = tbClave.Text;
				string comentarios = tbComentarios.Text;
			
				SqlParameter[] param = new SqlParameter[8];
			
				param[0] = new SqlParameter("@usuarioID", new System.Guid(usuarioID));
				param[1] = new SqlParameter("@apellido", apellido);
				param[2] = new SqlParameter("@nombre", nombres);
				param[3] = new SqlParameter("@email1", email);
				param[4] = new SqlParameter("@sucursalID", new System.Guid(sucursalID));
				param[5] = new SqlParameter("@username", username);
				param[6] = new SqlParameter("@password", Utilidades.encriptar(password));
				param[7] = new SqlParameter("@comentarios", comentarios);
			
				while (true)
				{
					try 
					{
						//Modifica el registro en la tabla de usuarios
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarUsuario", param);

						//Borra las filas existentes de perfiles
						SqlParameter[] param1 = new SqlParameter[1];
						param1[0] = new SqlParameter("@usuarioID", new System.Guid(usuarioID));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteUsuario_ItemsSeguridadByUsuario", param1);
					
						//Agrega las filas de perfiles
						DataTable dtPerfiles = (DataTable)lbxPosee.DataSource;
						if (dtPerfiles.Rows.Count>0)
						{
							for (int i=0; i<dtPerfiles.Rows.Count; i++)
							{
								param = new SqlParameter[2];
								param[0] = new SqlParameter("@usuarioID", new System.Guid(usuarioID));
								param[1] = new SqlParameter("@seguridadPerfilID", new System.Guid(dtPerfiles.Rows[i]["id"].ToString()));
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoUsuario_ItemSeguridad", param);
							}
						}

						MessageBox.Show("Usuario modificado con éxito.", "Modificación de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//limpiarCamposUnicos();
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Usuario modificado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo modificar el Usuario. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Usuario. \r\n" + e.Message, false);
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

		//Limpia los campos del formulario
		private void limpiarCamposUnicos()
		{
			/*tbApellido.Text = "";
			tbNombres.Text = "";
			tbEmail.Text = "";
			tbNombreUsuario.Text = "";
			tbComentarios.Text = "";*/
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Usuarios seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Usuarios...", true);
								SqlParameter[] param;
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

                                    param = new SqlParameter[2];
									param[0] = new SqlParameter("@id", new System.Guid(id));
                                    param[1] = new SqlParameter("@identificadorPerfil", "VENDEDOR");
								
									//Verifica si es un vendedor
									SqlDataReader drEsVendedor = SqlHelper.ExecuteReader(this.conexion, "sp_getUsuarioContienePerfil", param);
									if (drEsVendedor.HasRows)
									{
										drEsVendedor.Read();
										if (int.Parse(drEsVendedor[0].ToString())>0)
										{
											SqlParameter[] param1 = new SqlParameter[1];
											param1[0] = new SqlParameter("@usuarioID", new System.Guid(id));
											
											SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarVendedor", param1);
										}
									}

                                    param = new SqlParameter[1];
                                    param[0] = new SqlParameter("@id", new System.Guid(id));
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarUsuario", param);

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

		private void butAgregar_Click(object sender, System.EventArgs e)
		{
			agregarPerfil();
		}

		//Agrega el perfil seleccionado en la lista de la derecha a la de la izquierda
		private void agregarPerfil()
		{
			try
			{
				DataTable dtNoPosee = (DataTable)lbxNoPosee.DataSource;
				if (dtNoPosee.Rows.Count>0)
				{
					int selectedIndex = 0;
					if (lbxNoPosee.SelectedIndex>-1)
						selectedIndex = lbxNoPosee.SelectedIndex;

					DataTable dtPosee = (DataTable)lbxPosee.DataSource;
					DataRow row = dtPosee.NewRow();
					row["id"] = dtNoPosee.Rows[selectedIndex]["id"];
					row["descripcion"] = dtNoPosee.Rows[selectedIndex]["descripcion"];
					dtPosee.Rows.Add(row);
					dtPosee.AcceptChanges();

					dtNoPosee.Rows[selectedIndex].Delete();
					dtNoPosee.AcceptChanges();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		//Quita el perfil seleccionado en la lista de la izquierda a la de la derecha
		private void quitarPerfil()
		{
			try
			{
				DataTable dtPosee = (DataTable)lbxPosee.DataSource;
				if (dtPosee.Rows.Count>0)
				{
					int selectedIndex = 0;
					if (lbxPosee.SelectedIndex>-1)
						selectedIndex = lbxPosee.SelectedIndex;

					DataTable dtNoPosee = (DataTable)lbxNoPosee.DataSource;
					DataRow row = dtNoPosee.NewRow();
					row["id"] = dtPosee.Rows[selectedIndex]["id"];
					row["descripcion"] = dtPosee.Rows[selectedIndex]["descripcion"];
					dtNoPosee.Rows.Add(row);
					dtNoPosee.AcceptChanges();

					dtPosee.Rows[selectedIndex].Delete();
					dtPosee.AcceptChanges();

				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Agrega todos los perfiles
		private void agregarTodo()
		{
			try
			{
				DataTable dtNoPosee = (DataTable)lbxNoPosee.DataSource;
				while (dtNoPosee.Rows.Count>0)
				{
					lbxNoPosee.SelectedIndex = 0;

					agregarPerfil();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Quita todos los perfiles
		private void quitarTodo()
		{
			try
			{
				DataTable dtPosee = (DataTable)lbxPosee.DataSource;
				while (dtPosee.Rows.Count>0)
				{
					lbxPosee.SelectedIndex = 0;
					quitarPerfil();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void lbxNoPosee_DoubleClick(object sender, System.EventArgs e)
		{
			agregarPerfil();
		}

		private void butAgregarTodo_Click(object sender, System.EventArgs e)
		{
			agregarTodo();
		}

		private void butQuitar_Click(object sender, System.EventArgs e)
		{
			quitarPerfil();
		}

		private void lbxPosee_DoubleClick(object sender, System.EventArgs e)
		{
			quitarPerfil();
		}

		private void butQuitarTodo_Click(object sender, System.EventArgs e)
		{
			quitarTodo();
		}

		private void butLimpiar_Click_1(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

	}
}
