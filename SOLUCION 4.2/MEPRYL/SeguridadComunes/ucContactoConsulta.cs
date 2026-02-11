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
	/// Summary description for ucContactoConsulta.
	/// </summary>
	public class ucContactoConsulta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox gbProveedor;
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
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbNombresB;
		private System.Windows.Forms.ComboBox cbProveedorB;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbTelefonos;
		private System.Windows.Forms.TextBox tbApellido;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.TextBox tbNotas;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TextBox tbNombres;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.ComboBox cbProveedor;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbApellido;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbNombre;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbProveedor;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbTelefonos;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbEmail;
		private System.Windows.Forms.TextBox tbApellidoB;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		//public string conexion = "SERVER=MONICA2;DATABASE=Ligier;UID=sa;PWD=;";
		private System.Windows.Forms.GroupBox gbModificacionContactos;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucContactoConsulta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucContactoConsulta));
			this.tabPrincipal = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.butVistaPrevia = new System.Windows.Forms.Button();
			this.butImprimir = new System.Windows.Forms.Button();
			this.butBorrar = new System.Windows.Forms.Button();
			this.dgItems = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dgtbApellido = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbNombre = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbProveedor = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbTelefonos = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbEmail = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.tbNombresB = new System.Windows.Forms.TextBox();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.butLimpiar1 = new System.Windows.Forms.Button();
			this.butBuscar1 = new System.Windows.Forms.Button();
			this.gbProveedor = new System.Windows.Forms.GroupBox();
			this.cbProveedorB = new System.Windows.Forms.ComboBox();
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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.gbModificacionContactos = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTelefonos = new System.Windows.Forms.TextBox();
			this.tbApellido = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.butSalir = new System.Windows.Forms.Button();
			this.tbNotas = new System.Windows.Forms.TextBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.tbNombres = new System.Windows.Forms.TextBox();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.cbProveedor = new System.Windows.Forms.ComboBox();
			this.tbID = new System.Windows.Forms.TextBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.lblRegistro = new System.Windows.Forms.Label();
			this.butSiguiente = new System.Windows.Forms.Button();
			this.butAnterior = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.tabPrincipal.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
			this.tabFiltro.SuspendLayout();
			this.tabFiltro1.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.gbProveedor.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabFiltro3.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.gbModificacionContactos.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPrincipal
			// 
			this.tabPrincipal.Controls.Add(this.tabPage1);
			this.tabPrincipal.Controls.Add(this.tabPage2);
			this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPrincipal.ItemSize = new System.Drawing.Size(94, 18);
			this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
			this.tabPrincipal.Name = "tabPrincipal";
			this.tabPrincipal.SelectedIndex = 0;
			this.tabPrincipal.Size = new System.Drawing.Size(728, 536);
			this.tabPrincipal.TabIndex = 2;
			this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.butVistaPrevia);
			this.tabPage1.Controls.Add(this.butImprimir);
			this.tabPage1.Controls.Add(this.butBorrar);
			this.tabPage1.Controls.Add(this.dgItems);
			this.tabPage1.Controls.Add(this.tabFiltro);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(720, 510);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Lista de Contactos";
			// 
			// butVistaPrevia
			// 
			this.butVistaPrevia.BackColor = System.Drawing.Color.SteelBlue;
			this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
			this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
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
			this.butImprimir.ForeColor = System.Drawing.Color.White;
			this.butImprimir.Image = ((System.Drawing.Image)(resources.GetObject("butImprimir.Image")));
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
			this.dgItems.CaptionBackColor = System.Drawing.Color.SteelBlue;
			this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgItems.CaptionForeColor = System.Drawing.Color.White;
			this.dgItems.CaptionText = "Listado de Contactos";
			this.dgItems.DataMember = "";
			this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgItems.FlatMode = true;
			this.dgItems.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dgItems.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dgItems.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dgItems.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
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
			this.dgItems.Size = new System.Drawing.Size(720, 358);
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
																												  this.dgtbApellido,
																												  this.dgtbNombre,
																												  this.dgtbProveedor,
																												  this.dgtbTelefonos,
																												  this.dgtbEmail});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Items";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dgtbApellido
			// 
			this.dgtbApellido.Format = "";
			this.dgtbApellido.FormatInfo = null;
			this.dgtbApellido.HeaderText = "Apellido";
			this.dgtbApellido.MappingName = "Apellido";
			this.dgtbApellido.ReadOnly = true;
			this.dgtbApellido.Width = 140;
			// 
			// dgtbNombre
			// 
			this.dgtbNombre.Format = "";
			this.dgtbNombre.FormatInfo = null;
			this.dgtbNombre.HeaderText = "Apellido";
			this.dgtbNombre.MappingName = "Nombre";
			this.dgtbNombre.ReadOnly = true;
			this.dgtbNombre.Width = 140;
			// 
			// dgtbProveedor
			// 
			this.dgtbProveedor.Format = "";
			this.dgtbProveedor.FormatInfo = null;
			this.dgtbProveedor.HeaderText = "Proveedor";
			this.dgtbProveedor.MappingName = "Proveedor";
			this.dgtbProveedor.ReadOnly = true;
			this.dgtbProveedor.Width = 140;
			// 
			// dgtbTelefonos
			// 
			this.dgtbTelefonos.Format = "";
			this.dgtbTelefonos.FormatInfo = null;
			this.dgtbTelefonos.HeaderText = "Teléfonos";
			this.dgtbTelefonos.MappingName = "Teléfonos";
			this.dgtbTelefonos.ReadOnly = true;
			this.dgtbTelefonos.Width = 75;
			// 
			// dgtbEmail
			// 
			this.dgtbEmail.Format = "";
			this.dgtbEmail.FormatInfo = null;
			this.dgtbEmail.HeaderText = "E-Mail";
			this.dgtbEmail.MappingName = "E-Mail";
			this.dgtbEmail.ReadOnly = true;
			this.dgtbEmail.Width = 140;
			// 
			// tabFiltro
			// 
			this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabFiltro.Controls.Add(this.tabFiltro1);
			this.tabFiltro.Controls.Add(this.tabFiltro3);
			this.tabFiltro.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabFiltro.ItemSize = new System.Drawing.Size(0, 18);
			this.tabFiltro.Location = new System.Drawing.Point(0, 0);
			this.tabFiltro.Multiline = true;
			this.tabFiltro.Name = "tabFiltro";
			this.tabFiltro.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tabFiltro.SelectedIndex = 0;
			this.tabFiltro.Size = new System.Drawing.Size(720, 152);
			this.tabFiltro.TabIndex = 0;
			// 
			// tabFiltro1
			// 
			this.tabFiltro1.Controls.Add(this.groupBox10);
			this.tabFiltro1.Controls.Add(this.butSalir1);
			this.tabFiltro1.Controls.Add(this.butLimpiar1);
			this.tabFiltro1.Controls.Add(this.butBuscar1);
			this.tabFiltro1.Controls.Add(this.gbProveedor);
			this.tabFiltro1.Controls.Add(this.groupBox1);
			this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
			this.tabFiltro1.Name = "tabFiltro1";
			this.tabFiltro1.Size = new System.Drawing.Size(712, 126);
			this.tabFiltro1.TabIndex = 0;
			this.tabFiltro1.Text = "Filtro Rápido";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.tbNombresB);
			this.groupBox10.Location = new System.Drawing.Point(8, 64);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(200, 48);
			this.groupBox10.TabIndex = 11;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Nombres";
			// 
			// tbNombresB
			// 
			this.tbNombresB.Location = new System.Drawing.Point(8, 16);
			this.tbNombresB.Name = "tbNombresB";
			this.tbNombresB.Size = new System.Drawing.Size(184, 20);
			this.tbNombresB.TabIndex = 1;
			this.tbNombresB.Text = "";
			// 
			// butSalir1
			// 
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
			this.gbProveedor.Controls.Add(this.cbProveedorB);
			this.gbProveedor.Location = new System.Drawing.Point(216, 8);
			this.gbProveedor.Name = "gbProveedor";
			this.gbProveedor.Size = new System.Drawing.Size(200, 48);
			this.gbProveedor.TabIndex = 5;
			this.gbProveedor.TabStop = false;
			this.gbProveedor.Text = "Proveedor";
			// 
			// cbProveedorB
			// 
			this.cbProveedorB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProveedorB.Location = new System.Drawing.Point(8, 16);
			this.cbProveedorB.Name = "cbProveedorB";
			this.cbProveedorB.Size = new System.Drawing.Size(184, 21);
			this.cbProveedorB.TabIndex = 10;
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
			this.tabFiltro3.Location = new System.Drawing.Point(4, 4);
			this.tabFiltro3.Name = "tabFiltro3";
			this.tabFiltro3.Size = new System.Drawing.Size(712, 126);
			this.tabFiltro3.TabIndex = 2;
			this.tabFiltro3.Text = "Orden";
			this.tabFiltro3.Visible = false;
			// 
			// butSalir3
			// 
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
															   "Nombre",
															   "Proveedor",
															   "E-Mail",
															   "Teléfono"});
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
															   "Nombre",
															   "Proveedor",
															   "E-Mail",
															   "Teléfono"});
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
															   "Nombre",
															   "Proveedor",
															   "E-Mail",
															   "Teléfono"});
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
															   "Nombre",
															   "Proveedor",
															   "E-Mail",
															   "Teléfono"});
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
			this.tabPage2.Controls.Add(this.gbModificacionContactos);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(720, 510);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Detalle";
			this.tabPage2.Visible = false;
			// 
			// gbModificacionContactos
			// 
			this.gbModificacionContactos.Controls.Add(this.label6);
			this.gbModificacionContactos.Controls.Add(this.tbTelefonos);
			this.gbModificacionContactos.Controls.Add(this.tbApellido);
			this.gbModificacionContactos.Controls.Add(this.label17);
			this.gbModificacionContactos.Controls.Add(this.butSalir);
			this.gbModificacionContactos.Controls.Add(this.tbNotas);
			this.gbModificacionContactos.Controls.Add(this.butGuardar);
			this.gbModificacionContactos.Controls.Add(this.label19);
			this.gbModificacionContactos.Controls.Add(this.label22);
			this.gbModificacionContactos.Controls.Add(this.label26);
			this.gbModificacionContactos.Controls.Add(this.label14);
			this.gbModificacionContactos.Controls.Add(this.butLimpiar);
			this.gbModificacionContactos.Controls.Add(this.tbNombres);
			this.gbModificacionContactos.Controls.Add(this.tbEmail);
			this.gbModificacionContactos.Controls.Add(this.cbProveedor);
			this.gbModificacionContactos.Controls.Add(this.tbID);
			this.gbModificacionContactos.Controls.Add(this.groupBox9);
			this.gbModificacionContactos.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionContactos.Name = "gbModificacionContactos";
			this.gbModificacionContactos.Size = new System.Drawing.Size(672, 344);
			this.gbModificacionContactos.TabIndex = 110;
			this.gbModificacionContactos.TabStop = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 14);
			this.label6.TabIndex = 119;
			this.label6.Text = "Teléfonos";
			// 
			// tbTelefonos
			// 
			this.tbTelefonos.Location = new System.Drawing.Point(8, 80);
			this.tbTelefonos.Name = "tbTelefonos";
			this.tbTelefonos.Size = new System.Drawing.Size(248, 20);
			this.tbTelefonos.TabIndex = 3;
			this.tbTelefonos.Text = "";
			// 
			// tbApellido
			// 
			this.tbApellido.Location = new System.Drawing.Point(8, 32);
			this.tbApellido.Name = "tbApellido";
			this.tbApellido.Size = new System.Drawing.Size(248, 20);
			this.tbApellido.TabIndex = 1;
			this.tbApellido.Text = "";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 112);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(88, 14);
			this.label17.TabIndex = 96;
			this.label17.Text = "E-Mail";
			// 
			// butSalir
			// 
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(432, 304);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 23);
			this.butSalir.TabIndex = 10;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// tbNotas
			// 
			this.tbNotas.Location = new System.Drawing.Point(8, 224);
			this.tbNotas.Multiline = true;
			this.tbNotas.Name = "tbNotas";
			this.tbNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbNotas.Size = new System.Drawing.Size(248, 104);
			this.tbNotas.TabIndex = 7;
			this.tbNotas.Text = "";
			// 
			// butGuardar
			// 
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(304, 304);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 9;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(280, 64);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(112, 14);
			this.label19.TabIndex = 94;
			this.label19.Text = "Proveedor";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(280, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(136, 14);
			this.label22.TabIndex = 91;
			this.label22.Text = "Nombres";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 14);
			this.label26.TabIndex = 87;
			this.label26.Text = "Apellido";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 208);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(136, 14);
			this.label14.TabIndex = 99;
			this.label14.Text = "Notas";
			// 
			// butLimpiar
			// 
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(432, 272);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 8;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
			// 
			// tbNombres
			// 
			this.tbNombres.Location = new System.Drawing.Point(280, 32);
			this.tbNombres.Name = "tbNombres";
			this.tbNombres.Size = new System.Drawing.Size(248, 20);
			this.tbNombres.TabIndex = 2;
			this.tbNombres.Text = "";
			// 
			// tbEmail
			// 
			this.tbEmail.Location = new System.Drawing.Point(8, 128);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(248, 20);
			this.tbEmail.TabIndex = 5;
			this.tbEmail.Text = "";
			// 
			// cbProveedor
			// 
			this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProveedor.Items.AddRange(new object[] {
															 "",
															 "F",
															 "Y"});
			this.cbProveedor.Location = new System.Drawing.Point(280, 80);
			this.cbProveedor.MaxLength = 100;
			this.cbProveedor.Name = "cbProveedor";
			this.cbProveedor.Size = new System.Drawing.Size(248, 21);
			this.cbProveedor.TabIndex = 4;
			// 
			// tbID
			// 
			this.tbID.Location = new System.Drawing.Point(584, 184);
			this.tbID.MaxLength = 2;
			this.tbID.Name = "tbID";
			this.tbID.Size = new System.Drawing.Size(40, 20);
			this.tbID.TabIndex = 104;
			this.tbID.Text = "";
			this.tbID.Visible = false;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.lblRegistro);
			this.groupBox9.Controls.Add(this.butSiguiente);
			this.groupBox9.Controls.Add(this.butAnterior);
			this.groupBox9.Location = new System.Drawing.Point(552, 24);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(104, 104);
			this.groupBox9.TabIndex = 102;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Registro";
			// 
			// lblRegistro
			// 
			this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRegistro.Location = new System.Drawing.Point(8, 48);
			this.lblRegistro.Name = "lblRegistro";
			this.lblRegistro.Size = new System.Drawing.Size(88, 14);
			this.lblRegistro.TabIndex = 102;
			this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butSiguiente
			// 
			this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
			this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSiguiente.Location = new System.Drawing.Point(16, 72);
			this.butSiguiente.Name = "butSiguiente";
			this.butSiguiente.Size = new System.Drawing.Size(72, 24);
			this.butSiguiente.TabIndex = 101;
			this.butSiguiente.Text = "Siguiente";
			this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
			// 
			// butAnterior
			// 
			this.butAnterior.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior.Image")));
			this.butAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAnterior.Location = new System.Drawing.Point(16, 16);
			this.butAnterior.Name = "butAnterior";
			this.butAnterior.Size = new System.Drawing.Size(72, 24);
			this.butAnterior.TabIndex = 100;
			this.butAnterior.Text = "Anterior";
			this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.SteelBlue;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(720, 32);
			this.label18.TabIndex = 95;
			this.label18.Text = "Modificación de Contactos";
			// 
			// ucContactoConsulta
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucContactoConsulta";
			this.Size = new System.Drawing.Size(728, 536);
			this.Load += new System.EventHandler(this.ucContactoConsulta_Load);
			this.tabPrincipal.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro1.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.gbProveedor.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabFiltro3.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.gbModificacionContactos.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ucContactoConsulta_Load(object sender, System.EventArgs e)
		{
			UtilUI.llenarCombo(ref cbProveedorB, this.conexion, "sp_getAllProveedors", "Todos", 0);
			acomodarCombosOrden();
		}
		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 1;  //Apellido
				rbAsc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 2;  //Nombre
				rbAsc2.Checked = true;
				cbCampoOrden3.SelectedIndex = 3;  //Proveedor
				rbAsc3.Checked = true;
				cbCampoOrden4.SelectedIndex = 4;  //Nada
				rbAsc4.Checked = true;
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

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			try
			{
				tbApellidoB.Text = "";
				tbNombresB.Text = "";
				cbProveedorB.SelectedIndex = 0;
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
				string sql = "SELECT     dbo.Contacto.ID, dbo.Contacto.nombre, dbo.Contacto.apellido, dbo.Contacto.email1 AS [E-Mail], dbo.Contacto.clienteID, dbo.Contacto.proveedorID, " +
					"dbo.Contacto.email2, dbo.Contacto.email3, dbo.Contacto.notas, dbo.Contacto.telefono AS Teléfonos, dbo.Proveedor.razonSocial AS Proveedor " +
					"FROM         dbo.Proveedor INNER JOIN " +
					"dbo.Contacto ON dbo.Proveedor.ID = dbo.Contacto.proveedorID " +
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
					filtro = filtro + " AND nombre LIKE '%" + tbNombresB.Text.Trim() + "%'";
				}
				if (cbProveedorB.SelectedIndex>0) 
				{
					filtro = filtro + " AND proveedorID = CAST('" + cbProveedorB.SelectedValue.ToString() + "' AS uniqueidentifier)";
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
							gbModificacionContactos.Enabled = true;
						}
						else
							gbModificacionContactos.Enabled = false;
					else
						gbModificacionContactos.Enabled = false;
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
						tbNombres.Text = dt.Rows[currentRow]["Nombre"].ToString();
						tbTelefonos.Text = dt.Rows[currentRow]["Teléfonos"].ToString();
						tbEmail.Text = dt.Rows[currentRow]["E-Mail"].ToString();
						tbNotas.Text = dt.Rows[currentRow]["Notas"].ToString();
					
						UtilUI.llenarCombo(ref cbProveedor, this.conexion, "sp_getAllProveedors", "", -1);
						cbProveedor.SelectedValue = dt.Rows[currentRow]["proveedorID"].ToString();
					
						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
					}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Contactos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Contactos...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarContacto", param);

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
				tbTelefonos.Text= "";
				tbEmail.Text = "";
				tbNotas.Text = "";
				cbProveedor.SelectedIndex = 0;
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

				if (tbApellido.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el Apellido.\r\n";
					resultado = false;
				}
				if (tbNombres.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el Nombre.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				SqlParameter[] param = new SqlParameter[10];
			
				param[0] = new SqlParameter("@ID", new System.Guid(tbID.Text.Trim()));
				param[1] = new SqlParameter("@apellido", tbApellido.Text.Trim());
				param[2] = new SqlParameter("@nombre", tbNombres.Text.Trim());
				param[3] = new SqlParameter("@telefono", tbTelefonos.Text.Trim());
				param[4] = new SqlParameter("@email1", tbEmail.Text.Trim());
				param[5] = new SqlParameter("@email2", "");
				param[6] = new SqlParameter("@email3", "");
				param[7] = new SqlParameter("@clienteID", new System.Guid());
				param[8] = new SqlParameter("@proveedorID", new System.Guid(cbProveedor.SelectedValue.ToString()));
				param[9] = new SqlParameter("@notas", tbNotas.Text.Trim());
			
				while (true)
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarContacto", param);
						MessageBox.Show("Contacto modificado con éxito.", "Modificación de Contactos", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Contacto modificado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo modificar el Contacto. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Contacto. \r\n" + e.Message, false);
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

		private void butBuscar3_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butLimpiar3_Click(object sender, System.EventArgs e)
		{
			acomodarCombosOrden();
		}

		private void butSalir3_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}
	}
}
