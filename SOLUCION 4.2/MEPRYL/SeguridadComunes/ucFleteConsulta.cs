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
	/// Summary description for ucZonaConsulta.
	/// </summary>
	public class ucFleteConsulta : System.Windows.Forms.UserControl
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
		private System.Windows.Forms.TextBox tbObservacionesB;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.GroupBox gbModificacion;
		private System.Windows.Forms.TextBox tbNombreFleteB;
		private System.Windows.Forms.TextBox tbFleteID;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ComboBox cbIVA;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Button butLimpiarDatosLaborales;
		private System.Windows.Forms.TextBox tbTelefonosEmpresa;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbEmailEmpresa;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbCodPostEmpresa;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbPaisEmpresa;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbProvinciaEmpresa;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbLocalidadEmpresa;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbOficinaEmpresa;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbPisoEmpresa;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbNroEmpresa;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbCalleEmpresa;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCuit;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox tbNombreFlete;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.CheckedListBox clbZonas1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbRegistro2;
		private System.Windows.Forms.Button butSiguiente2;
		private System.Windows.Forms.Button butAnterior2;
		private System.Windows.Forms.Label lbRazonSocial;
		private System.ComponentModel.IContainer components;

		public ucFleteConsulta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucFleteConsulta));
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
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.butLimpiar1 = new System.Windows.Forms.Button();
			this.butBuscar1 = new System.Windows.Forms.Button();
			this.gbProveedor = new System.Windows.Forms.GroupBox();
			this.tbObservacionesB = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbNombreFleteB = new System.Windows.Forms.TextBox();
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
			this.gbModificacion = new System.Windows.Forms.GroupBox();
			this.tbFleteID = new System.Windows.Forms.TextBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.butSalir = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.cbIVA = new System.Windows.Forms.ComboBox();
			this.label33 = new System.Windows.Forms.Label();
			this.butLimpiarDatosLaborales = new System.Windows.Forms.Button();
			this.tbTelefonosEmpresa = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbEmailEmpresa = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbCodPostEmpresa = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbPaisEmpresa = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbProvinciaEmpresa = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbLocalidadEmpresa = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbOficinaEmpresa = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbPisoEmpresa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbNroEmpresa = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbCalleEmpresa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCuit = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label37 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.tbNombreFlete = new System.Windows.Forms.TextBox();
			this.tbObservaciones = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.lblRegistro = new System.Windows.Forms.Label();
			this.butSiguiente = new System.Windows.Forms.Button();
			this.butAnterior = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.clbZonas1 = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lbRegistro2 = new System.Windows.Forms.Label();
			this.butSiguiente2 = new System.Windows.Forms.Button();
			this.butAnterior2 = new System.Windows.Forms.Button();
			this.lbRazonSocial = new System.Windows.Forms.Label();
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
			this.gbModificacion.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.tabPage1.Text = "Listado de Fletes";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.DarkTurquoise;
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
			this.dgItems.CaptionBackColor = System.Drawing.Color.Gray;
			this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgItems.CaptionForeColor = System.Drawing.Color.White;
			this.dgItems.CaptionText = "     Listado de Fletes";
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
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn18,
																												  this.dataGridTextBoxColumn19,
																												  this.dataGridTextBoxColumn20,
																												  this.dataGridTextBoxColumn21,
																												  this.dataGridTextBoxColumn22,
																												  this.dataGridTextBoxColumn23,
																												  this.dataGridTextBoxColumn24,
																												  this.dataGridTextBoxColumn16});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Items";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "Nombre Flete";
			this.dataGridTextBoxColumn11.MappingName = "Nombre Flete";
			this.dataGridTextBoxColumn11.ReadOnly = true;
			this.dataGridTextBoxColumn11.Width = 300;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "Teléfonos";
			this.dataGridTextBoxColumn12.MappingName = "Teléfonos";
			this.dataGridTextBoxColumn12.ReadOnly = true;
			this.dataGridTextBoxColumn12.Width = 120;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "E-Mail";
			this.dataGridTextBoxColumn13.MappingName = "E-Mail";
			this.dataGridTextBoxColumn13.ReadOnly = true;
			this.dataGridTextBoxColumn13.Width = 120;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "Calle";
			this.dataGridTextBoxColumn14.MappingName = "Calle";
			this.dataGridTextBoxColumn14.ReadOnly = true;
			this.dataGridTextBoxColumn14.Width = 75;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "Nro.";
			this.dataGridTextBoxColumn15.MappingName = "Nro.";
			this.dataGridTextBoxColumn15.ReadOnly = true;
			this.dataGridTextBoxColumn15.Width = 40;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "Piso";
			this.dataGridTextBoxColumn17.MappingName = "Piso";
			this.dataGridTextBoxColumn17.Width = 30;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Format = "";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.HeaderText = "Of.";
			this.dataGridTextBoxColumn18.MappingName = "Of.";
			this.dataGridTextBoxColumn18.ReadOnly = true;
			this.dataGridTextBoxColumn18.Width = 30;
			// 
			// dataGridTextBoxColumn19
			// 
			this.dataGridTextBoxColumn19.Format = "";
			this.dataGridTextBoxColumn19.FormatInfo = null;
			this.dataGridTextBoxColumn19.HeaderText = "Cod.Post.";
			this.dataGridTextBoxColumn19.MappingName = "Cod.Post.";
			this.dataGridTextBoxColumn19.ReadOnly = true;
			this.dataGridTextBoxColumn19.Width = 40;
			// 
			// dataGridTextBoxColumn20
			// 
			this.dataGridTextBoxColumn20.Format = "";
			this.dataGridTextBoxColumn20.FormatInfo = null;
			this.dataGridTextBoxColumn20.HeaderText = "Localidad";
			this.dataGridTextBoxColumn20.MappingName = "Localidad";
			this.dataGridTextBoxColumn20.ReadOnly = true;
			this.dataGridTextBoxColumn20.Width = 75;
			// 
			// dataGridTextBoxColumn21
			// 
			this.dataGridTextBoxColumn21.Format = "";
			this.dataGridTextBoxColumn21.FormatInfo = null;
			this.dataGridTextBoxColumn21.HeaderText = "Provincia";
			this.dataGridTextBoxColumn21.MappingName = "Provincia";
			this.dataGridTextBoxColumn21.ReadOnly = true;
			this.dataGridTextBoxColumn21.Width = 75;
			// 
			// dataGridTextBoxColumn22
			// 
			this.dataGridTextBoxColumn22.Format = "";
			this.dataGridTextBoxColumn22.FormatInfo = null;
			this.dataGridTextBoxColumn22.HeaderText = "Pais";
			this.dataGridTextBoxColumn22.MappingName = "Pais";
			this.dataGridTextBoxColumn22.ReadOnly = true;
			this.dataGridTextBoxColumn22.Width = 75;
			// 
			// dataGridTextBoxColumn23
			// 
			this.dataGridTextBoxColumn23.Format = "";
			this.dataGridTextBoxColumn23.FormatInfo = null;
			this.dataGridTextBoxColumn23.HeaderText = "CUIT";
			this.dataGridTextBoxColumn23.MappingName = "CUIT";
			this.dataGridTextBoxColumn23.ReadOnly = true;
			this.dataGridTextBoxColumn23.Width = 120;
			// 
			// dataGridTextBoxColumn24
			// 
			this.dataGridTextBoxColumn24.Format = "";
			this.dataGridTextBoxColumn24.FormatInfo = null;
			this.dataGridTextBoxColumn24.HeaderText = "IVA";
			this.dataGridTextBoxColumn24.MappingName = "IVA";
			this.dataGridTextBoxColumn24.ReadOnly = true;
			this.dataGridTextBoxColumn24.Width = 120;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "Observaciones";
			this.dataGridTextBoxColumn16.MappingName = "Observaciones";
			this.dataGridTextBoxColumn16.ReadOnly = true;
			this.dataGridTextBoxColumn16.Width = 300;
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
			this.gbProveedor.Controls.Add(this.tbObservacionesB);
			this.gbProveedor.Location = new System.Drawing.Point(216, 8);
			this.gbProveedor.Name = "gbProveedor";
			this.gbProveedor.Size = new System.Drawing.Size(200, 48);
			this.gbProveedor.TabIndex = 5;
			this.gbProveedor.TabStop = false;
			this.gbProveedor.Text = "Observaciones";
			// 
			// tbObservacionesB
			// 
			this.tbObservacionesB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbObservacionesB.Location = new System.Drawing.Point(8, 16);
			this.tbObservacionesB.Name = "tbObservacionesB";
			this.tbObservacionesB.Size = new System.Drawing.Size(184, 20);
			this.tbObservacionesB.TabIndex = 2;
			this.tbObservacionesB.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbNombreFleteB);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Nombre del Flete";
			// 
			// tbNombreFleteB
			// 
			this.tbNombreFleteB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombreFleteB.Location = new System.Drawing.Point(8, 16);
			this.tbNombreFleteB.Name = "tbNombreFleteB";
			this.tbNombreFleteB.Size = new System.Drawing.Size(184, 20);
			this.tbNombreFleteB.TabIndex = 1;
			this.tbNombreFleteB.Text = "";
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
															   "Nombre Flete",
															   "Observaciones"});
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
															   "Nombre Flete",
															   "Observaciones"});
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
															   "Nombre Flete",
															   "Observaciones"});
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
															   "Nombre Flete",
															   "Observaciones"});
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
			this.tabPage2.Controls.Add(this.gbModificacion);
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
			// gbModificacion
			// 
			this.gbModificacion.Controls.Add(this.tbFleteID);
			this.gbModificacion.Controls.Add(this.butGuardar);
			this.gbModificacion.Controls.Add(this.butSalir);
			this.gbModificacion.Controls.Add(this.tabControl1);
			this.gbModificacion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbModificacion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacion.Location = new System.Drawing.Point(0, 32);
			this.gbModificacion.Name = "gbModificacion";
			this.gbModificacion.Size = new System.Drawing.Size(808, 398);
			this.gbModificacion.TabIndex = 119;
			this.gbModificacion.TabStop = false;
			// 
			// tbFleteID
			// 
			this.tbFleteID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbFleteID.Location = new System.Drawing.Point(488, 360);
			this.tbFleteID.Name = "tbFleteID";
			this.tbFleteID.Size = new System.Drawing.Size(32, 20);
			this.tbFleteID.TabIndex = 236;
			this.tbFleteID.Text = "";
			this.tbFleteID.Visible = false;
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(576, 360);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 234;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(704, 360);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 24);
			this.butSalir.TabIndex = 235;
			this.butSalir.Text = "&Salir";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.HotTrack = true;
			this.tabControl1.ImageList = this.imagenesTab;
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(792, 320);
			this.tabControl1.TabIndex = 238;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.cbIVA);
			this.tabPage3.Controls.Add(this.label33);
			this.tabPage3.Controls.Add(this.butLimpiarDatosLaborales);
			this.tabPage3.Controls.Add(this.tbTelefonosEmpresa);
			this.tabPage3.Controls.Add(this.label11);
			this.tabPage3.Controls.Add(this.tbEmailEmpresa);
			this.tabPage3.Controls.Add(this.label10);
			this.tabPage3.Controls.Add(this.tbCodPostEmpresa);
			this.tabPage3.Controls.Add(this.label9);
			this.tabPage3.Controls.Add(this.cbPaisEmpresa);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Controls.Add(this.cbProvinciaEmpresa);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.cbLocalidadEmpresa);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.tbOficinaEmpresa);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.tbPisoEmpresa);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.tbNroEmpresa);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.tbCalleEmpresa);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.tbCuit);
			this.tabPage3.Controls.Add(this.label15);
			this.tabPage3.Controls.Add(this.label14);
			this.tabPage3.Controls.Add(this.comboBox1);
			this.tabPage3.Controls.Add(this.label37);
			this.tabPage3.Controls.Add(this.textBox1);
			this.tabPage3.Controls.Add(this.label38);
			this.tabPage3.Controls.Add(this.label39);
			this.tabPage3.Controls.Add(this.textBox2);
			this.tabPage3.Controls.Add(this.textBox3);
			this.tabPage3.Controls.Add(this.label40);
			this.tabPage3.Controls.Add(this.textBox4);
			this.tabPage3.Controls.Add(this.label41);
			this.tabPage3.Controls.Add(this.tbNombreFlete);
			this.tabPage3.Controls.Add(this.tbObservaciones);
			this.tabPage3.Controls.Add(this.label13);
			this.tabPage3.Controls.Add(this.groupBox9);
			this.tabPage3.ImageIndex = 0;
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(784, 293);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Datos Empresa";
			// 
			// cbIVA
			// 
			this.cbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbIVA.Location = new System.Drawing.Point(664, 24);
			this.cbIVA.MaxLength = 100;
			this.cbIVA.Name = "cbIVA";
			this.cbIVA.Size = new System.Drawing.Size(104, 21);
			this.cbIVA.TabIndex = 4;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(664, 8);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(72, 14);
			this.label33.TabIndex = 187;
			this.label33.Text = "IVA";
			// 
			// butLimpiarDatosLaborales
			// 
			this.butLimpiarDatosLaborales.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butLimpiarDatosLaborales.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiarDatosLaborales.Image")));
			this.butLimpiarDatosLaborales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiarDatosLaborales.Location = new System.Drawing.Point(664, 256);
			this.butLimpiarDatosLaborales.Name = "butLimpiarDatosLaborales";
			this.butLimpiarDatosLaborales.Size = new System.Drawing.Size(104, 24);
			this.butLimpiarDatosLaborales.TabIndex = 15;
			this.butLimpiarDatosLaborales.Text = "&Limpiar";
			// 
			// tbTelefonosEmpresa
			// 
			this.tbTelefonosEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbTelefonosEmpresa.Location = new System.Drawing.Point(272, 168);
			this.tbTelefonosEmpresa.Name = "tbTelefonosEmpresa";
			this.tbTelefonosEmpresa.Size = new System.Drawing.Size(232, 20);
			this.tbTelefonosEmpresa.TabIndex = 14;
			this.tbTelefonosEmpresa.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(272, 152);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(136, 14);
			this.label11.TabIndex = 184;
			this.label11.Text = "Teléfonos";
			// 
			// tbEmailEmpresa
			// 
			this.tbEmailEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEmailEmpresa.Location = new System.Drawing.Point(8, 168);
			this.tbEmailEmpresa.Name = "tbEmailEmpresa";
			this.tbEmailEmpresa.Size = new System.Drawing.Size(232, 20);
			this.tbEmailEmpresa.TabIndex = 13;
			this.tbEmailEmpresa.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 152);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(136, 14);
			this.label10.TabIndex = 182;
			this.label10.Text = "E-Mail";
			// 
			// tbCodPostEmpresa
			// 
			this.tbCodPostEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCodPostEmpresa.Location = new System.Drawing.Point(704, 72);
			this.tbCodPostEmpresa.Name = "tbCodPostEmpresa";
			this.tbCodPostEmpresa.Size = new System.Drawing.Size(64, 20);
			this.tbCodPostEmpresa.TabIndex = 10;
			this.tbCodPostEmpresa.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(704, 56);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 14);
			this.label9.TabIndex = 180;
			this.label9.Text = "Cod.Post.";
			// 
			// cbPaisEmpresa
			// 
			this.cbPaisEmpresa.Location = new System.Drawing.Point(272, 120);
			this.cbPaisEmpresa.MaxLength = 100;
			this.cbPaisEmpresa.Name = "cbPaisEmpresa";
			this.cbPaisEmpresa.Size = new System.Drawing.Size(232, 21);
			this.cbPaisEmpresa.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(272, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 14);
			this.label8.TabIndex = 178;
			this.label8.Text = "Pais";
			// 
			// cbProvinciaEmpresa
			// 
			this.cbProvinciaEmpresa.Location = new System.Drawing.Point(8, 120);
			this.cbProvinciaEmpresa.MaxLength = 100;
			this.cbProvinciaEmpresa.Name = "cbProvinciaEmpresa";
			this.cbProvinciaEmpresa.Size = new System.Drawing.Size(232, 21);
			this.cbProvinciaEmpresa.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 14);
			this.label7.TabIndex = 176;
			this.label7.Text = "Provincia";
			// 
			// cbLocalidadEmpresa
			// 
			this.cbLocalidadEmpresa.Location = new System.Drawing.Point(536, 72);
			this.cbLocalidadEmpresa.MaxLength = 100;
			this.cbLocalidadEmpresa.Name = "cbLocalidadEmpresa";
			this.cbLocalidadEmpresa.Size = new System.Drawing.Size(160, 21);
			this.cbLocalidadEmpresa.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(536, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 14);
			this.label6.TabIndex = 174;
			this.label6.Text = "Localidad";
			// 
			// tbOficinaEmpresa
			// 
			this.tbOficinaEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbOficinaEmpresa.Location = new System.Drawing.Point(440, 72);
			this.tbOficinaEmpresa.Name = "tbOficinaEmpresa";
			this.tbOficinaEmpresa.Size = new System.Drawing.Size(64, 20);
			this.tbOficinaEmpresa.TabIndex = 8;
			this.tbOficinaEmpresa.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(440, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 14);
			this.label5.TabIndex = 172;
			this.label5.Text = "Oficina";
			// 
			// tbPisoEmpresa
			// 
			this.tbPisoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbPisoEmpresa.Location = new System.Drawing.Point(360, 72);
			this.tbPisoEmpresa.Name = "tbPisoEmpresa";
			this.tbPisoEmpresa.Size = new System.Drawing.Size(64, 20);
			this.tbPisoEmpresa.TabIndex = 7;
			this.tbPisoEmpresa.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(360, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 14);
			this.label4.TabIndex = 170;
			this.label4.Text = "Piso";
			// 
			// tbNroEmpresa
			// 
			this.tbNroEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNroEmpresa.Location = new System.Drawing.Point(272, 72);
			this.tbNroEmpresa.Name = "tbNroEmpresa";
			this.tbNroEmpresa.Size = new System.Drawing.Size(72, 20);
			this.tbNroEmpresa.TabIndex = 6;
			this.tbNroEmpresa.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(272, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 14);
			this.label3.TabIndex = 168;
			this.label3.Text = "Nro.";
			// 
			// tbCalleEmpresa
			// 
			this.tbCalleEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCalleEmpresa.Location = new System.Drawing.Point(8, 72);
			this.tbCalleEmpresa.Name = "tbCalleEmpresa";
			this.tbCalleEmpresa.Size = new System.Drawing.Size(232, 20);
			this.tbCalleEmpresa.TabIndex = 5;
			this.tbCalleEmpresa.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 14);
			this.label2.TabIndex = 166;
			this.label2.Text = "Calle";
			// 
			// tbCuit
			// 
			this.tbCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCuit.Location = new System.Drawing.Point(536, 24);
			this.tbCuit.Name = "tbCuit";
			this.tbCuit.Size = new System.Drawing.Size(120, 20);
			this.tbCuit.TabIndex = 3;
			this.tbCuit.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(536, 8);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(136, 14);
			this.label15.TabIndex = 164;
			this.label15.Text = "CUIT";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(128, 14);
			this.label14.TabIndex = 160;
			this.label14.Text = "Razón Social";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(664, 24);
			this.comboBox1.MaxLength = 100;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(104, 21);
			this.comboBox1.TabIndex = 4;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(664, 8);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(72, 14);
			this.label37.TabIndex = 187;
			this.label37.Text = "IVA";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(8, 72);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(232, 20);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(272, 56);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(80, 14);
			this.label38.TabIndex = 168;
			this.label38.Text = "Nro.";
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(8, 56);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(136, 14);
			this.label39.TabIndex = 166;
			this.label39.Text = "Calle";
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(360, 72);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(64, 20);
			this.textBox2.TabIndex = 7;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox3.Location = new System.Drawing.Point(536, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(120, 20);
			this.textBox3.TabIndex = 3;
			this.textBox3.Text = "";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(360, 56);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(48, 14);
			this.label40.TabIndex = 170;
			this.label40.Text = "Piso";
			// 
			// textBox4
			// 
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox4.Location = new System.Drawing.Point(272, 72);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(72, 20);
			this.textBox4.TabIndex = 6;
			this.textBox4.Text = "";
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(536, 8);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(136, 14);
			this.label41.TabIndex = 164;
			this.label41.Text = "CUIT";
			// 
			// tbNombreFlete
			// 
			this.tbNombreFlete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombreFlete.Location = new System.Drawing.Point(8, 24);
			this.tbNombreFlete.Name = "tbNombreFlete";
			this.tbNombreFlete.Size = new System.Drawing.Size(232, 20);
			this.tbNombreFlete.TabIndex = 1;
			this.tbNombreFlete.Text = "";
			// 
			// tbObservaciones
			// 
			this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbObservaciones.Location = new System.Drawing.Point(8, 216);
			this.tbObservaciones.Multiline = true;
			this.tbObservaciones.Name = "tbObservaciones";
			this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbObservaciones.Size = new System.Drawing.Size(496, 64);
			this.tbObservaciones.TabIndex = 15;
			this.tbObservaciones.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 200);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(96, 16);
			this.label13.TabIndex = 230;
			this.label13.Text = "Observaciones";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.lblRegistro);
			this.groupBox9.Controls.Add(this.butSiguiente);
			this.groupBox9.Controls.Add(this.butAnterior);
			this.groupBox9.Location = new System.Drawing.Point(664, 136);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(104, 104);
			this.groupBox9.TabIndex = 235;
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
			this.butSiguiente.TabIndex = 17;
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
			this.butAnterior.TabIndex = 16;
			this.butAnterior.Text = "Anterior";
			this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.lbRazonSocial);
			this.tabPage4.Controls.Add(this.groupBox2);
			this.tabPage4.Controls.Add(this.clbZonas1);
			this.tabPage4.Controls.Add(this.label1);
			this.tabPage4.ImageIndex = 1;
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(784, 293);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Asignación de Zonas";
			this.tabPage4.Visible = false;
			// 
			// clbZonas1
			// 
			this.clbZonas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.clbZonas1.CheckOnClick = true;
			this.clbZonas1.Location = new System.Drawing.Point(8, 56);
			this.clbZonas1.Name = "clbZonas1";
			this.clbZonas1.Size = new System.Drawing.Size(648, 212);
			this.clbZonas1.TabIndex = 236;
			this.clbZonas1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbZonas1_ItemCheck);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 235;
			this.label1.Text = "Zonas Asignadas";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.DarkTurquoise;
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
			this.label18.BackColor = System.Drawing.Color.Gray;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(808, 32);
			this.label18.TabIndex = 116;
			this.label18.Text = "     Modificación de Fletes";
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lbRegistro2);
			this.groupBox2.Controls.Add(this.butSiguiente2);
			this.groupBox2.Controls.Add(this.butAnterior2);
			this.groupBox2.Location = new System.Drawing.Point(672, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(104, 104);
			this.groupBox2.TabIndex = 237;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Registro";
			// 
			// lbRegistro2
			// 
			this.lbRegistro2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbRegistro2.Location = new System.Drawing.Point(8, 48);
			this.lbRegistro2.Name = "lbRegistro2";
			this.lbRegistro2.Size = new System.Drawing.Size(88, 14);
			this.lbRegistro2.TabIndex = 102;
			this.lbRegistro2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butSiguiente2
			// 
			this.butSiguiente2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSiguiente2.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente2.Image")));
			this.butSiguiente2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSiguiente2.Location = new System.Drawing.Point(16, 72);
			this.butSiguiente2.Name = "butSiguiente2";
			this.butSiguiente2.Size = new System.Drawing.Size(72, 24);
			this.butSiguiente2.TabIndex = 17;
			this.butSiguiente2.Text = "Siguiente";
			this.butSiguiente2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butSiguiente2.Click += new System.EventHandler(this.butSiguiente_Click);
			// 
			// butAnterior2
			// 
			this.butAnterior2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAnterior2.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior2.Image")));
			this.butAnterior2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAnterior2.Location = new System.Drawing.Point(16, 16);
			this.butAnterior2.Name = "butAnterior2";
			this.butAnterior2.Size = new System.Drawing.Size(72, 24);
			this.butAnterior2.TabIndex = 16;
			this.butAnterior2.Text = "Anterior";
			this.butAnterior2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAnterior2.Click += new System.EventHandler(this.butAnterior_Click);
			// 
			// lbRazonSocial
			// 
			this.lbRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbRazonSocial.Location = new System.Drawing.Point(8, 8);
			this.lbRazonSocial.Name = "lbRazonSocial";
			this.lbRazonSocial.Size = new System.Drawing.Size(648, 32);
			this.lbRazonSocial.TabIndex = 238;
			// 
			// ucFleteConsulta
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucFleteConsulta";
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
			this.gbModificacion.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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
				string sql = "SELECT     dbo.Flete.id AS ID, dbo.Flete.nombre AS [Nombre Flete], dbo.Flete.calle AS Calle, dbo.Flete.nro AS [Nro.], dbo.Flete.piso AS Piso, " +
                      "dbo.Flete.oficina AS [Of.], dbo.Flete.provinciaID, dbo.Flete.localidadID, dbo.Flete.paisID, dbo.Flete.codPost AS [Cod.Post.], dbo.Flete.eMail AS [E-Mail],  " +
                      "dbo.Flete.telefonos AS Teléfonos, dbo.Flete.cuit AS CUIT, dbo.Flete.ivaID, dbo.Flete.observaciones AS Observaciones,  " +
                      "dbo.Localidad.descripcion AS Localidad, dbo.Pais.descripcion AS Pais, dbo.Provincia.descripcion AS Provincia, dbo.IVA.descripcion AS IVA,  " +
                      "dbo.IVA.identificador AS ivaIdentificador " +
					"FROM         dbo.Flete LEFT OUTER JOIN " +
                      "dbo.IVA ON dbo.Flete.ivaID = dbo.IVA.id LEFT OUTER JOIN " +
                      "dbo.Provincia ON dbo.Flete.provinciaID = dbo.Provincia.id LEFT OUTER JOIN " +
                      "dbo.Pais ON dbo.Flete.paisID = dbo.Pais.id LEFT OUTER JOIN " +
                      "dbo.Localidad ON dbo.Flete.localidadID = dbo.Localidad.id " +
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

				if (tbNombreFleteB.Text!="") 
				{
					filtro = filtro + " AND dbo.Flete.nombre LIKE '%" + tbNombreFleteB.Text.Trim() + "%'";
				}
				if (tbObservacionesB.Text!="") 
				{
					filtro = filtro + " AND dbo.Flete.observaciones LIKE '%" + tbObservacionesB.Text.Trim() + "%'";
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
				cbCampoOrden1.SelectedIndex = 1;  //Nombre Zona
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

		public void inicializarComponentes()
		{
			try
			{
				acomodarCombosOrden();

				//Carga las zonas
				clbZonas1.BindingContext = this.BindingContext;
				UtilUI.llenarCheckedListBox(ref clbZonas1, this.conexion, "sp_getAllZonas", "", "-1");

				//Datos Laborales
				UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
				UtilUI.comboSeleccionarItemByText("Resp. Inscripto", ref cbIVA);

				UtilUI.llenarCombo(ref cbLocalidadEmpresa, this.conexion, "sp_getAllLocalidads", "", -1);
				UtilUI.llenarCombo(ref cbProvinciaEmpresa, this.conexion, "sp_getAllProvincias", "", -1);
				UtilUI.llenarCombo(ref cbPaisEmpresa, this.conexion, "sp_getAllPaiss", "", -1);
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
							gbModificacion.Enabled = true;
						}
						else
							gbModificacion.Enabled = false;
					else
						gbModificacion.Enabled = false;
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

						tbFleteID.Text = dt.Rows[currentRow]["ID"].ToString();
						tbNombreFlete.Text = dt.Rows[currentRow]["Nombre Flete"].ToString();

						//Datos Laborales
						tbCuit.Text = dt.Rows[currentRow]["CUIT"].ToString();

						UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
						cbIVA.SelectedValue = dt.Rows[currentRow]["ivaID"].ToString();

						tbCalleEmpresa.Text = dt.Rows[currentRow]["Calle"].ToString();
						tbNroEmpresa.Text = dt.Rows[currentRow]["Nro."].ToString();
						tbPisoEmpresa.Text = dt.Rows[currentRow]["Piso"].ToString();
						tbOficinaEmpresa.Text = dt.Rows[currentRow]["Of."].ToString();

						UtilUI.llenarCombo(ref cbLocalidadEmpresa, this.conexion, "sp_getAllLocalidads", "", -1);
						cbLocalidadEmpresa.SelectedValue = dt.Rows[currentRow]["localidadID"].ToString();

						tbCodPostEmpresa.Text = dt.Rows[currentRow]["Cod.Post."].ToString();

						UtilUI.llenarCombo(ref cbProvinciaEmpresa, this.conexion, "sp_getAllProvincias", "", -1);
						cbProvinciaEmpresa.SelectedValue = dt.Rows[currentRow]["provinciaID"].ToString();
					
						UtilUI.llenarCombo(ref cbPaisEmpresa, this.conexion, "sp_getAllPaiss", "", -1);
						cbPaisEmpresa.SelectedValue = dt.Rows[currentRow]["paisID"].ToString();

						tbEmailEmpresa.Text = dt.Rows[currentRow]["E-Mail"].ToString();
						tbTelefonosEmpresa.Text = dt.Rows[currentRow]["Teléfonos"].ToString();

						tbObservaciones.Text = dt.Rows[currentRow]["Observaciones"].ToString();

						//Limpia las zonas checkeadas
						for (int j=0; j<clbZonas1.Items.Count; j++)
						{
							clbZonas1.SetItemChecked(j, false);
						}
															

						//Marca las zonas asignadas
						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@fleteID", new Guid(dt.Rows[currentRow]["ID"].ToString()));
						SqlDataReader drFleteZona = SqlHelper.ExecuteReader(this.conexion, "sp_getAllFleteZonas", param); 

						if (drFleteZona.HasRows)
						{
							DataTable dtZonas = (DataTable)clbZonas1.DataSource;
							while (drFleteZona.Read())
							{
								for (int i=0; i<clbZonas1.Items.Count; i++)
								{
									if (dtZonas.Rows[i]["ID"].ToString() == drFleteZona["zonaID"].ToString())
									{
										clbZonas1.SetItemChecked(i, true);
									}
								}
							}
							dtZonas = null;
						}

						drFleteZona.Close();
						drFleteZona = null;
					
						tbNombreFlete.Select();

						lbRazonSocial.Text = tbNombreFlete.Text;

						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();
						lbRegistro2.Text = lblRegistro.Text;
						dt = null;

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
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				tbNombreFleteB.Text = "";
				tbObservacionesB.Text = "";
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
			
				if (tbNombreFlete.Text.Trim()=="")
				{
					mensaje += "   - El Nombre del Flete está vacío.\r\n";
					resultado = false;
				}
			
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Modificación de Fletes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				string nombreFlete = tbNombreFlete.Text;
				string cuit = tbCuit.Text;
				string ivaID = Utilidades.ID_VACIO;
				if (cbIVA.SelectedValue!=null)
					ivaID = cbIVA.SelectedValue.ToString();
				string calle = tbCalleEmpresa.Text;
				string nro = tbNroEmpresa.Text;
				string piso = tbPisoEmpresa.Text;
				string oficina = tbOficinaEmpresa.Text;
				string localidadID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidadEmpresa, "sp_InsertLocalidad", "sp_getAllLocalidads");
				string codPost = tbCodPostEmpresa.Text;
				string provinciaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvinciaEmpresa, "sp_InsertProvincia", "sp_getAllProvincias");
				string paisID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbPaisEmpresa, "sp_InsertPais", "sp_getAllPaiss");
				string eMail = tbEmailEmpresa.Text;
				string telefonos = tbTelefonosEmpresa.Text;
				string observaciones = tbObservaciones.Text;
			
				SqlParameter[] param = new SqlParameter[15];
			
				param[0] = new SqlParameter("@fleteID", new System.Guid(tbFleteID.Text));
				param[1] = new SqlParameter("@nombreFlete", nombreFlete);
				param[2] = new SqlParameter("@cuit", cuit);
				param[3] = new SqlParameter("@ivaID", new System.Guid(ivaID));
				param[4] = new SqlParameter("@calle", calle);
				param[5] = new SqlParameter("@nro", nro);
				param[6] = new SqlParameter("@piso", piso);
				param[7] = new SqlParameter("@oficina", oficina);
				param[8] = new SqlParameter("@localidadID", new System.Guid(localidadID));
				param[9] = new SqlParameter("@codPost", codPost);
				param[10] = new SqlParameter("@provinciaID", new System.Guid(provinciaID));
				param[11] = new SqlParameter("@paisID", new System.Guid(paisID));
				param[12] = new SqlParameter("@eMail", eMail);
				param[13] = new SqlParameter("@telefonos", telefonos);
				param[14] = new SqlParameter("@observaciones", observaciones);
			
				while (true)
				{
					try 
					{
						//Modifica el registro en la tabla de Fletes
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarFlete", param);

						//Borra y reasigna las zonas
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@fleteID", new Guid(tbFleteID.Text));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteFleteZonas", param);

						DataTable dtZonas = (DataTable)clbZonas1.DataSource;
						for (int i=0; i<clbZonas1.Items.Count; i++)
						{
							if (clbZonas1.CheckedIndices.Contains(i))
							{
								param = new SqlParameter[2];
								param[0] = new SqlParameter("@fleteID", new Guid(tbFleteID.Text));
								param[1] = new SqlParameter("@zonaID", new Guid(dtZonas.Rows[i]["id"].ToString()));
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevaFleteZona", param);
							}
						}

					
						MessageBox.Show("Flete modificado con éxito.", "Modificación de Fletes", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//limpiarCamposUnicos();
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Flete modificado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo modificar el Flete. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Flete. \r\n" + e.Message, false);
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Fletes seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Fletes...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarFlete", param);

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

		private void butLimpiar_Click_1(object sender, System.EventArgs e)
		{
			try
			{
				tbNombreFlete.Text = "";
				tbObservaciones.Text = "";
				tbFleteID.Text = "";
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void clbZonas1_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			//clbZonas1.
		}
	}
}
