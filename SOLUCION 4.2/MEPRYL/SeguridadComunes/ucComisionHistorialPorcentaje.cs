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
	public class ucComisionHistorialPorcentaje : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGrid dgItems;
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
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.DataGridTextBoxColumn Indicador;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.Button butSalir3;
		private System.Windows.Forms.Button butLimpiar3;
		private System.Windows.Forms.Button butBuscar3;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.DateTimePicker dtpFechaHastaB;
		private System.Windows.Forms.DateTimePicker dtpFechaDesdeB;
		private System.Windows.Forms.CheckBox chkFechaB;
		private System.Windows.Forms.DataGridTextBoxColumn Fecha;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox cbIndicadorComisionB;
		private System.Windows.Forms.Button butAceptar4;
		private System.Windows.Forms.Button butSalir4;
		private System.Windows.Forms.Button butLimpiar4;
		private System.Windows.Forms.Button butBuscar4;
		private System.Windows.Forms.DataGridTextBoxColumn Porcentaje;
		private System.ComponentModel.IContainer components;

		public ucComisionHistorialPorcentaje()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucComisionHistorialPorcentaje));
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
            this.Porcentaje = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.butAceptar4 = new System.Windows.Forms.Button();
            this.butSalir4 = new System.Windows.Forms.Button();
            this.butLimpiar4 = new System.Windows.Forms.Button();
            this.butBuscar4 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbIndicadorComisionB = new System.Windows.Forms.ComboBox();
            this.gbFechaEmision = new System.Windows.Forms.GroupBox();
            this.dtpFechaHastaB = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesdeB = new System.Windows.Forms.DateTimePicker();
            this.chkFechaB = new System.Windows.Forms.CheckBox();
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
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbFechaEmision.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.ImageList = this.imagenesTab;
            this.tabPrincipal.ItemSize = new System.Drawing.Size(94, 18);
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(800, 456);
            this.tabPrincipal.TabIndex = 4;
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
            this.tabPage1.Text = "Historial Cambio de Porcentajes";
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
            this.dgItems.CaptionText = "     Historial Cambio de Porcentajes";
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
            this.Porcentaje});
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
            // Porcentaje
            // 
            this.Porcentaje.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.Porcentaje.Format = "N";
            this.Porcentaje.FormatInfo = null;
            this.Porcentaje.HeaderText = "Porcentaje";
            this.Porcentaje.MappingName = "Porcentaje";
            this.Porcentaje.ReadOnly = true;
            this.Porcentaje.Width = 75;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabPage6);
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
            this.tabPage6.Controls.Add(this.butAceptar4);
            this.tabPage6.Controls.Add(this.butSalir4);
            this.tabPage6.Controls.Add(this.butLimpiar4);
            this.tabPage6.Controls.Add(this.butBuscar4);
            this.tabPage6.Controls.Add(this.groupBox5);
            this.tabPage6.Controls.Add(this.gbFechaEmision);
            this.tabPage6.ImageIndex = 1;
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(784, 126);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Filtro Rápido";
            // 
            // butAceptar4
            // 
            this.butAceptar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar4.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar4.Image")));
            this.butAceptar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar4.Location = new System.Drawing.Point(632, 96);
            this.butAceptar4.Name = "butAceptar4";
            this.butAceptar4.Size = new System.Drawing.Size(72, 24);
            this.butAceptar4.TabIndex = 219;
            this.butAceptar4.Text = "&Aceptar";
            this.butAceptar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar4.Visible = false;
            this.butAceptar4.Click += new System.EventHandler(this.butAceptar4_Click);
            // 
            // butSalir4
            // 
            this.butSalir4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir4.Image = ((System.Drawing.Image)(resources.GetObject("butSalir4.Image")));
            this.butSalir4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir4.Location = new System.Drawing.Point(640, 88);
            this.butSalir4.Name = "butSalir4";
            this.butSalir4.Size = new System.Drawing.Size(64, 23);
            this.butSalir4.TabIndex = 218;
            this.butSalir4.Text = "&Salir";
            this.butSalir4.Click += new System.EventHandler(this.butSalir4_Click);
            // 
            // butLimpiar4
            // 
            this.butLimpiar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar4.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar4.Image")));
            this.butLimpiar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar4.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar4.Name = "butLimpiar4";
            this.butLimpiar4.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar4.TabIndex = 217;
            this.butLimpiar4.Text = "&Limpiar";
            this.butLimpiar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar4.Click += new System.EventHandler(this.butLimpiar4_Click);
            // 
            // butBuscar4
            // 
            this.butBuscar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar4.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar4.Image")));
            this.butBuscar4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar4.Location = new System.Drawing.Point(640, 16);
            this.butBuscar4.Name = "butBuscar4";
            this.butBuscar4.Size = new System.Drawing.Size(64, 41);
            this.butBuscar4.TabIndex = 216;
            this.butBuscar4.Text = "&Buscar";
            this.butBuscar4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar4.Click += new System.EventHandler(this.butBuscar4_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbIndicadorComisionB);
            this.groupBox5.Location = new System.Drawing.Point(320, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 48);
            this.groupBox5.TabIndex = 215;
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
            // gbFechaEmision
            // 
            this.gbFechaEmision.Controls.Add(this.dtpFechaHastaB);
            this.gbFechaEmision.Controls.Add(this.dtpFechaDesdeB);
            this.gbFechaEmision.Controls.Add(this.chkFechaB);
            this.gbFechaEmision.Location = new System.Drawing.Point(112, 40);
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
            this.butLimpiar3.TabIndex = 15;
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
            this.butBuscar3.TabIndex = 14;
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
            "Comisión Indicador",
            "Fecha",
            "Porcentaje"});
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
            "Comisión Indicador",
            "Fecha",
            "Porcentaje"});
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
            "Comisión Indicador",
            "Fecha",
            "Porcentaje"});
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
            "Comisión Indicador",
            "Fecha",
            "Porcentaje"});
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
            // ucComisionHistorialPorcentaje
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucComisionHistorialPorcentaje";
            this.Size = new System.Drawing.Size(800, 456);
            this.Load += new System.EventHandler(this.ucArticuloConsulta_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.gbFechaEmision.ResumeLayout(false);
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				UtilUI.llenarCombo(ref cbIndicadorComisionB, this.conexion, "sp_getAllComisionIndicadorParaComboLimpio", "Todos", 0);

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
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
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
				string sql = "SELECT     dbo.ComisionHistorialCambioPorcentajeIndicador.id, dbo.ComisionHistorialCambioPorcentajeIndicador.comisionIndicadorID, " +
					"dbo.ComisionIndicador.descripcion AS [Comisión Indicador], dbo.ComisionHistorialCambioPorcentajeIndicador.fecha AS Fecha, " +
					"dbo.ComisionHistorialCambioPorcentajeIndicador.porcentaje AS Porcentaje " +
					"FROM         dbo.ComisionHistorialCambioPorcentajeIndicador INNER JOIN " +
					"dbo.ComisionIndicador ON dbo.ComisionHistorialCambioPorcentajeIndicador.comisionIndicadorID = dbo.ComisionIndicador.id " +
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
					filtro = filtro + " AND dbo.ComisionHistorialCambioPorcentajeIndicador.comisionIndicadorID = CAST('" + cbIndicadorComisionB.SelectedValue.ToString() + "' AS uniqueidentifier)";
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
				cbCampoOrden1.SelectedIndex = 2;  //Fecha
				rbDesc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 1;  //Indicador
				rbAsc2.Checked = true;
				cbCampoOrden3.SelectedIndex = 3;  //Porcentaje
				rbAsc3.Checked = true;
				cbCampoOrden4.SelectedIndex = 0; 
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
			chkFechaB.Checked = false;
			cbIndicadorComisionB.SelectedIndex = 0;
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
		}

		private void butAceptar4_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
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

        private void butImprimir_Click(object sender, EventArgs e)
        {

        }
	}
}
