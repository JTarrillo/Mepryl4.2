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
	public class ucPerfilConsulta : System.Windows.Forms.UserControl
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
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.GroupBox gbProveedor;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.TextBox tbNombrePerfil;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbDescripcion;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Button butQuitarPermiso;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dgPermisoAcceso;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbModuloSistema;
		private System.Windows.Forms.CheckedListBox clbTipoPermiso;
		private System.Windows.Forms.Button butAgregarPermiso;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox lbxObjetoSistema;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbNombrePerfilB;
		private System.Windows.Forms.TextBox tbDescripcionB;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.ComponentModel.IContainer components;

		public ucPerfilConsulta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucPerfilConsulta));
			this.tabPrincipal = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.butVistaPrevia = new System.Windows.Forms.Button();
			this.butImprimir = new System.Windows.Forms.Button();
			this.butBorrar = new System.Windows.Forms.Button();
			this.dgItems = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.butLimpiar1 = new System.Windows.Forms.Button();
			this.butBuscar1 = new System.Windows.Forms.Button();
			this.gbProveedor = new System.Windows.Forms.GroupBox();
			this.tbDescripcionB = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbNombrePerfilB = new System.Windows.Forms.TextBox();
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
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.tbNombrePerfil = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.tbDescripcion = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbID = new System.Windows.Forms.TextBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.butQuitarPermiso = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dgPermisoAcceso = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.cbModuloSistema = new System.Windows.Forms.ComboBox();
			this.clbTipoPermiso = new System.Windows.Forms.CheckedListBox();
			this.butAgregarPermiso = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.lbxObjetoSistema = new System.Windows.Forms.ListBox();
			this.butSalir = new System.Windows.Forms.Button();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.lblRegistro = new System.Windows.Forms.Label();
			this.butSiguiente = new System.Windows.Forms.Button();
			this.butAnterior = new System.Windows.Forms.Button();
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
			this.gbProveedor.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabFiltro3.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.gbModificacionProveedores.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPermisoAcceso)).BeginInit();
			this.groupBox9.SuspendLayout();
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
			this.tabPage1.Text = "Listado de Perfiles";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.MediumSlateBlue;
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
			this.dgItems.CaptionBackColor = System.Drawing.Color.MediumSlateBlue;
			this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgItems.CaptionForeColor = System.Drawing.Color.White;
			this.dgItems.CaptionText = "     Listado de Perfiles";
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
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro;
			this.dataGridTableStyle1.DataGrid = this.dgItems;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn12});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Items";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "Nombre Perfil";
			this.dataGridTextBoxColumn11.MappingName = "Nombre Perfil";
			this.dataGridTextBoxColumn11.ReadOnly = true;
			this.dataGridTextBoxColumn11.Width = 300;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "Descripción";
			this.dataGridTextBoxColumn12.MappingName = "Descripción";
			this.dataGridTextBoxColumn12.ReadOnly = true;
			this.dataGridTextBoxColumn12.Width = 300;
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
			this.gbProveedor.Controls.Add(this.tbDescripcionB);
			this.gbProveedor.Location = new System.Drawing.Point(216, 8);
			this.gbProveedor.Name = "gbProveedor";
			this.gbProveedor.Size = new System.Drawing.Size(200, 48);
			this.gbProveedor.TabIndex = 5;
			this.gbProveedor.TabStop = false;
			this.gbProveedor.Text = "Descripción";
			// 
			// tbDescripcionB
			// 
			this.tbDescripcionB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDescripcionB.Location = new System.Drawing.Point(8, 16);
			this.tbDescripcionB.Name = "tbDescripcionB";
			this.tbDescripcionB.Size = new System.Drawing.Size(184, 20);
			this.tbDescripcionB.TabIndex = 2;
			this.tbDescripcionB.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbNombrePerfilB);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Nombre de Perfil";
			// 
			// tbNombrePerfilB
			// 
			this.tbNombrePerfilB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombrePerfilB.Location = new System.Drawing.Point(8, 16);
			this.tbNombrePerfilB.Name = "tbNombrePerfilB";
			this.tbNombrePerfilB.Size = new System.Drawing.Size(184, 20);
			this.tbNombrePerfilB.TabIndex = 1;
			this.tbNombrePerfilB.Text = "";
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
															   "Descripción",
															   "Nombre Perfil"});
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
															   "Descripción",
															   "Nombre Perfil"});
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
															   "Descripción",
															   "Nombre Perfil"});
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
															   "Descripción",
															   "Nombre Perfil"});
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
			this.tabPage2.Controls.Add(this.pictureBox2);
			this.tabPage2.Controls.Add(this.gbModificacionProveedores);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.ImageIndex = 1;
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(808, 430);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Detalle";
			this.tabPage2.Visible = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.MediumSlateBlue;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(32, 31);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 118;
			this.pictureBox2.TabStop = false;
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.tbNombrePerfil);
			this.gbModificacionProveedores.Controls.Add(this.label27);
			this.gbModificacionProveedores.Controls.Add(this.tbDescripcion);
			this.gbModificacionProveedores.Controls.Add(this.label13);
			this.gbModificacionProveedores.Controls.Add(this.groupBox3);
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 32);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 399);
			this.gbModificacionProveedores.TabIndex = 117;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// tbNombrePerfil
			// 
			this.tbNombrePerfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombrePerfil.Location = new System.Drawing.Point(8, 32);
			this.tbNombrePerfil.Name = "tbNombrePerfil";
			this.tbNombrePerfil.Size = new System.Drawing.Size(288, 20);
			this.tbNombrePerfil.TabIndex = 228;
			this.tbNombrePerfil.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(8, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(136, 14);
			this.label27.TabIndex = 231;
			this.label27.Text = "Nombre del Perfil";
			// 
			// tbDescripcion
			// 
			this.tbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDescripcion.Location = new System.Drawing.Point(320, 32);
			this.tbDescripcion.Name = "tbDescripcion";
			this.tbDescripcion.Size = new System.Drawing.Size(472, 20);
			this.tbDescripcion.TabIndex = 229;
			this.tbDescripcion.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(320, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(136, 14);
			this.label13.TabIndex = 230;
			this.label13.Text = "Descripción";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tbID);
			this.groupBox3.Controls.Add(this.butGuardar);
			this.groupBox3.Controls.Add(this.butQuitarPermiso);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.dgPermisoAcceso);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.cbModuloSistema);
			this.groupBox3.Controls.Add(this.clbTipoPermiso);
			this.groupBox3.Controls.Add(this.butAgregarPermiso);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.lbxObjetoSistema);
			this.groupBox3.Controls.Add(this.butSalir);
			this.groupBox3.Controls.Add(this.butLimpiar);
			this.groupBox3.Controls.Add(this.groupBox9);
			this.groupBox3.Location = new System.Drawing.Point(8, 64);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 331);
			this.groupBox3.TabIndex = 227;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Arme el Perfil";
			// 
			// tbID
			// 
			this.tbID.Location = new System.Drawing.Point(328, 136);
			this.tbID.Name = "tbID";
			this.tbID.Size = new System.Drawing.Size(64, 20);
			this.tbID.TabIndex = 228;
			this.tbID.Text = "";
			this.tbID.Visible = false;
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(544, 298);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 23);
			this.butGuardar.TabIndex = 227;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// butQuitarPermiso
			// 
			this.butQuitarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarPermiso.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarPermiso.Image")));
			this.butQuitarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarPermiso.Location = new System.Drawing.Point(312, 80);
			this.butQuitarPermiso.Name = "butQuitarPermiso";
			this.butQuitarPermiso.Size = new System.Drawing.Size(104, 24);
			this.butQuitarPermiso.TabIndex = 226;
			this.butQuitarPermiso.Text = "&Borrar";
			this.butQuitarPermiso.Click += new System.EventHandler(this.butQuitarPermiso_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(440, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 14);
			this.label2.TabIndex = 225;
			this.label2.Text = "Permisos de acceso";
			// 
			// dgPermisoAcceso
			// 
			this.dgPermisoAcceso.AllowSorting = false;
			this.dgPermisoAcceso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgPermisoAcceso.CaptionVisible = false;
			this.dgPermisoAcceso.DataMember = "";
			this.dgPermisoAcceso.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPermisoAcceso.Location = new System.Drawing.Point(440, 40);
			this.dgPermisoAcceso.Name = "dgPermisoAcceso";
			this.dgPermisoAcceso.ReadOnly = true;
			this.dgPermisoAcceso.Size = new System.Drawing.Size(328, 256);
			this.dgPermisoAcceso.TabIndex = 224;
			this.dgPermisoAcceso.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										this.dataGridTableStyle2});
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dgPermisoAcceso;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "v_Permisos";
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "Módulo";
			this.dataGridTextBoxColumn13.MappingName = "modulo_nombre";
			this.dataGridTextBoxColumn13.ReadOnly = true;
			this.dataGridTextBoxColumn13.Width = 75;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "Sección";
			this.dataGridTextBoxColumn14.MappingName = "objeto_descripcion";
			this.dataGridTextBoxColumn14.ReadOnly = true;
			this.dataGridTextBoxColumn14.Width = 150;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "Permiso";
			this.dataGridTextBoxColumn15.MappingName = "operacion_nombre";
			this.dataGridTextBoxColumn15.ReadOnly = true;
			this.dataGridTextBoxColumn15.Width = 150;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 14);
			this.label1.TabIndex = 223;
			this.label1.Text = "Tipo de Permiso";
			// 
			// cbModuloSistema
			// 
			this.cbModuloSistema.BackColor = System.Drawing.SystemColors.Window;
			this.cbModuloSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModuloSistema.Location = new System.Drawing.Point(16, 40);
			this.cbModuloSistema.Name = "cbModuloSistema";
			this.cbModuloSistema.Size = new System.Drawing.Size(272, 21);
			this.cbModuloSistema.TabIndex = 222;
			this.cbModuloSistema.SelectedIndexChanged += new System.EventHandler(this.cbModuloSistema_SelectedIndexChanged);
			// 
			// clbTipoPermiso
			// 
			this.clbTipoPermiso.BackColor = System.Drawing.SystemColors.Window;
			this.clbTipoPermiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.clbTipoPermiso.Location = new System.Drawing.Point(16, 200);
			this.clbTipoPermiso.Name = "clbTipoPermiso";
			this.clbTipoPermiso.Size = new System.Drawing.Size(272, 122);
			this.clbTipoPermiso.TabIndex = 221;
			// 
			// butAgregarPermiso
			// 
			this.butAgregarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarPermiso.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarPermiso.Image")));
			this.butAgregarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAgregarPermiso.Location = new System.Drawing.Point(312, 40);
			this.butAgregarPermiso.Name = "butAgregarPermiso";
			this.butAgregarPermiso.Size = new System.Drawing.Size(104, 24);
			this.butAgregarPermiso.TabIndex = 1;
			this.butAgregarPermiso.Text = "&Agregar";
			this.butAgregarPermiso.Click += new System.EventHandler(this.butAgregarPermiso_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 14);
			this.label4.TabIndex = 219;
			this.label4.Text = "Módulo del Sistema";
			// 
			// lbxObjetoSistema
			// 
			this.lbxObjetoSistema.BackColor = System.Drawing.SystemColors.Window;
			this.lbxObjetoSistema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxObjetoSistema.Location = new System.Drawing.Point(16, 64);
			this.lbxObjetoSistema.Name = "lbxObjetoSistema";
			this.lbxObjetoSistema.Size = new System.Drawing.Size(272, 106);
			this.lbxObjetoSistema.TabIndex = 5;
			this.lbxObjetoSistema.DoubleClick += new System.EventHandler(this.lbxObjetoSistema_DoubleClick);
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(672, 298);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 23);
			this.butSalir.TabIndex = 4;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir1_Click);
			// 
			// butLimpiar
			// 
			this.butLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(440, 298);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 23);
			this.butLimpiar.TabIndex = 2;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar1_Click);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.lblRegistro);
			this.groupBox9.Controls.Add(this.butSiguiente);
			this.groupBox9.Controls.Add(this.butAnterior);
			this.groupBox9.Location = new System.Drawing.Point(312, 216);
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
			this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
			this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSiguiente.Location = new System.Drawing.Point(16, 72);
			this.butSiguiente.Name = "butSiguiente";
			this.butSiguiente.Size = new System.Drawing.Size(72, 24);
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
			this.butAnterior.Size = new System.Drawing.Size(72, 24);
			this.butAnterior.TabIndex = 14;
			this.butAnterior.Text = "Anterior";
			this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.MediumSlateBlue;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(808, 32);
			this.label18.TabIndex = 116;
			this.label18.Text = "     Modificación de Perfil de usuario";
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
			// ucPerfilConsulta
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucPerfilConsulta";
			this.Size = new System.Drawing.Size(816, 456);
			this.tabPrincipal.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro1.ResumeLayout(false);
			this.gbProveedor.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabFiltro3.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgPermisoAcceso)).EndInit();
			this.groupBox9.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
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
				string sql = "SELECT id, nombre AS [Nombre Perfil], descripcion AS [Descripción]" + 
					"FROM         dbo.SeguridadPerfil " +
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

				if (tbNombrePerfilB.Text!="") 
				{
					filtro = filtro + " AND nombre LIKE '%" + tbNombrePerfilB.Text.Trim() + "%'";
				}
				if (tbDescripcionB.Text!="") 
				{
					filtro = filtro + " AND descripcion LIKE '%" + tbDescripcionB.Text.Trim() + "%'";
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
				cbCampoOrden1.SelectedIndex = 2;  //Nombre
				rbAsc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 1;  //Descripcion
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
			try
			{
				acomodarCombosOrden();

				UtilUI.llenarCombo(ref cbModuloSistema, this.conexion, "sp_getAlltv_ModuloSistemas", "", -1);
				cbModuloSistema.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
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
						tbNombrePerfil.Text = dt.Rows[currentRow]["Nombre Perfil"].ToString();
						tbDescripcion.Text = dt.Rows[currentRow]["Descripción"].ToString();
					
						//Carga los items del Perfil
						SqlConnection oConn = new SqlConnection(this.conexion);
						SqlCommand oComm = new SqlCommand();
						SqlDataAdapter oSQLDataAdapter;

						oComm.Connection = oConn;
						oComm.CommandType = CommandType.StoredProcedure;
						oComm.CommandText = "sp_getSeguridadPerfilItemsByPerfil";
						oComm.Parameters.Add("@seguridadPerfilID",tbID.Text);

						//open connection
						oConn.Open();

						//prepare data adapter object
						oSQLDataAdapter = new SqlDataAdapter();
						oSQLDataAdapter.TableMappings.Add("Table", "v_Permisos");
						oSQLDataAdapter.SelectCommand = oComm;

						//initialize dataset
						DataSet dsItems = new DataSet("Items");
						oSQLDataAdapter.Fill(dsItems);

						//prepare dataview to sort
						DataView dvItems;
						dvItems = new DataView(dsItems.Tables["v_Permisos"]);
						dgPermisoAcceso.DataSource = dsItems.Tables["v_Permisos"];
						dgPermisoAcceso.Visible = true;

						//close connection
						oConn.Close();
			
						llenarObjetosSistema();
						llenarTiposPermiso();

						tbNombrePerfil.Select();

						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
					}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Llena la ListBox con los objetos de sistema segun el modulo seleccinado
		private void llenarObjetosSistema()
		{
			try
			{
				if (cbModuloSistema.SelectedValue!=null)
				{
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@moduloSistemaID", new System.Guid(cbModuloSistema.SelectedValue.ToString()));
					UtilUI.llenarListBox(ref lbxObjetoSistema, this.conexion, "sp_getAlltv_ObjetoSistemas","", -1, param);
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Llena la ListBox con los permisos de acceso
		private void llenarTiposPermiso()
		{
			UtilUI.llenarCheckedListBox(ref clbTipoPermiso, this.conexion, "sp_getAllSeguridadOperacions","", -1);
		}

		private void lbxObjetoSistema_DoubleClick(object sender, System.EventArgs e)
		{
			agregarPerfil();
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
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				tbNombrePerfil.Text = "";
				tbDescripcion.Text = "";
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
			
				if (tbNombrePerfil.Text.Trim()=="")
				{
					mensaje += "   - El Nombre del Perfil está vacío.\r\n";
					resultado = false;
				}

				if (tbDescripcion.Text.Trim()=="")
				{
					mensaje += "   - La Descripción está vacía.\r\n";
					resultado = false;
				}

				DataTable dt = (DataTable)dgPermisoAcceso.DataSource;
				if (dt.Rows.Count==0)
				{
					mensaje += "   - La lista de Permisos de Acceso está vacía.\r\n";
					resultado = false;
				}
			
			
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Modificación de Perfil de usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				string nombrePerfil = tbNombrePerfil.Text;
				string descripcion = tbDescripcion.Text;
			
				SqlParameter[] param = new SqlParameter[3];
			
				param[0] = new SqlParameter("@seguridadPerfilID", new System.Guid(tbID.Text));
				param[1] = new SqlParameter("@nombrePerfil", nombrePerfil);
				param[2] = new SqlParameter("@descripcion", descripcion);
			
				while (true)
				{
					try 
					{
						//Modifica el registro en la tabla de Perfiles
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarSeguridadPerfil", param);
					
						//Primero Borra los articulos componentes
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@seguridadPerfilID", new System.Guid(tbID.Text));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteSeguridadPerfil_Item", param);

						//Agrega las filas de Permisos
						DataTable dtPermisos = (DataTable)dgPermisoAcceso.DataSource;
						if (dtPermisos.Rows.Count>0)
						{
							for (int i=0; i<dtPermisos.Rows.Count; i++)
							{
								param = new SqlParameter[3];
								param[0] = new SqlParameter("@seguridadPerfilID", new System.Guid(tbID.Text));
								param[1] = new SqlParameter("@seguridadOperacionID", new System.Guid(dtPermisos.Rows[i]["seguridadOperacionID"].ToString()));
								param[2] = new SqlParameter("@seguridadObjetoID", new System.Guid(dtPermisos.Rows[i]["seguridadObjetoID"].ToString()));
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoSeguridadPerfil_Item", param);
							}
						}

						MessageBox.Show("Perfil modificado con éxito.", "Modificación de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//limpiarCamposUnicos();
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Perfil modificado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo modificar el Perfil. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Perfil. \r\n" + e.Message, false);
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
			tbNombrePerfil.Text = "";
			tbDescripcion.Text = "";
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Perfiles seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Perfiles...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarSeguridadPerfil", param);

									//dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = Utilidades.ID_VACIO; // "-1";
								}
								//Recorre los renglones marcados para borrar
                                DataRow[] rowsBorrar = dt.Select("id='" + Utilidades.ID_VACIO + "'");   //dt.Select("id='-1'");
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

		private void cbModuloSistema_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarObjetosSistema();
		}

	

		//Agrega el perfil seleccionado en la lista de la derecha a la de la izquierda
		private void agregarPerfil()
		{
			try
			{
				DataTable dtObjetos = (DataTable)lbxObjetoSistema.DataSource;
				if (dtObjetos.Rows.Count>0)
				{
					int selectedIndex = 0;
					if (lbxObjetoSistema.SelectedIndex==-1)
						lbxObjetoSistema.SelectedIndex = 0;

					selectedIndex = lbxObjetoSistema.SelectedIndex;

					DataTable dtPermisoAcceso = (DataTable)dgPermisoAcceso.DataSource;
					//Recorre los registros marcados de tipos de permiso
					for (int i=0; i<clbTipoPermiso.Items.Count; i++)
					{
						if (clbTipoPermiso.GetItemChecked(i))
						{
							clbTipoPermiso.SelectedIndex = i;
							//Crea un nuevo registro y lo graba en la grilla
							DataRow row = dtPermisoAcceso.NewRow();
							row["id"] = Utilidades.ID_VACIO;
                            row["seguridadPerfilID"] = Utilidades.ID_VACIO;
							row["seguridadOperacionID"] = clbTipoPermiso.SelectedValue;
							row["seguridadObjetoID"] = lbxObjetoSistema.SelectedValue;
							row["operacion_nombre"] = clbTipoPermiso.Text;
							row["operacion_descripcion"] = "";
							row["moduloSistemaID"] = cbModuloSistema.SelectedValue;
							row["objeto_descripcion"] = lbxObjetoSistema.Text;
							row["objeto_identificador"] = "" ; //cbModuloSistema.Text + "." + lbxObjetoSistema.Text;
							row["objeto_nombre"] = "";
							row["modulo_nombre"] = cbModuloSistema.Text;

							dtPermisoAcceso.Rows.Add(row);
							dtPermisoAcceso.AcceptChanges();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		private void quitarPermisosSeleccionados()
		{
			try
			{
				if (dgPermisoAcceso.DataSource!=null)
				{
					DataTable dt = (DataTable)dgPermisoAcceso.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgPermisoAcceso.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							string[] rows = sRows.Split(",".ToCharArray());
							for (int j=0; j<rows.Length; j++)
							{
								string id = rows[j].Split(":".ToCharArray())[0];
								int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);
                                dt.Rows[renglon]["id"] = Utilidades.ID_VACIO; // "-1";
							}
							//Recorre los renglones marcados para borrar
                            DataRow[] rowsBorrar = dt.Select("id='" + Utilidades.ID_VACIO + "'");  //dt.Select("id='-1'");
							for (int k=0; k<rowsBorrar.Length; k++)
							{
								rowsBorrar[k].Delete();
							}
							dt.AcceptChanges();
							dgPermisoAcceso.Refresh();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butAgregarPermiso_Click(object sender, System.EventArgs e)
		{
			agregarPerfil();
		}

		private void butQuitarPermiso_Click(object sender, System.EventArgs e)
		{
			quitarPermisosSeleccionados();
		}


	}
}
