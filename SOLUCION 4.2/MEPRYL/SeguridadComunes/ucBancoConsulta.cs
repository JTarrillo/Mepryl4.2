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
	/// Summary description for ucBancoConsulta.
	/// </summary>
	public class ucBancoConsulta : System.Windows.Forms.UserControl
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
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbProvinciaB;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox gbProveedor;
		private System.Windows.Forms.ComboBox cbLocalidadB;
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
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbTelefonos;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbProvincia;
		private System.Windows.Forms.TextBox tbCodPost;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbOficina;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPiso;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbNro;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TextBox tbCalle;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.ComboBox cbLocalidad;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbBancoB;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbBanco;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbSucursal;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbCalle;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbNro;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbPiso;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbOficina;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbCodPost;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbLocalidad;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbProvincia;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		//public string conexion = "SERVER=MONICA2;DATABASE=Ligier;UID=sa;PWD=;";
		private System.Windows.Forms.TextBox tbSucursalB;
		private System.Windows.Forms.TextBox tbBanco;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.TextBox tbSucursal;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucBancoConsulta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucBancoConsulta));
			this.tabPrincipal = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.butVistaPrevia = new System.Windows.Forms.Button();
			this.butImprimir = new System.Windows.Forms.Button();
			this.butBorrar = new System.Windows.Forms.Button();
			this.dgItems = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dgtbBanco = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbSucursal = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbCalle = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbNro = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbPiso = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbOficina = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbCodPost = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbLocalidad = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbProvincia = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.tbSucursalB = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbProvinciaB = new System.Windows.Forms.ComboBox();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.butLimpiar1 = new System.Windows.Forms.Button();
			this.butBuscar1 = new System.Windows.Forms.Button();
			this.gbProveedor = new System.Windows.Forms.GroupBox();
			this.cbLocalidadB = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbBancoB = new System.Windows.Forms.TextBox();
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
			this.label6 = new System.Windows.Forms.Label();
			this.tbTelefonos = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbSucursal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbProvincia = new System.Windows.Forms.ComboBox();
			this.tbCodPost = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbOficina = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPiso = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbNro = new System.Windows.Forms.TextBox();
			this.tbBanco = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.butSalir = new System.Windows.Forms.Button();
			this.tbObservaciones = new System.Windows.Forms.TextBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.tbCalle = new System.Windows.Forms.TextBox();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.cbLocalidad = new System.Windows.Forms.ComboBox();
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
			this.groupBox2.SuspendLayout();
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
			this.tabPrincipal.Size = new System.Drawing.Size(792, 464);
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
			this.tabPage1.Size = new System.Drawing.Size(784, 438);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Lista de Bancos";
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
			this.dgItems.CaptionText = "Listado de Bancos";
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
			this.dgItems.Size = new System.Drawing.Size(784, 286);
			this.dgItems.TabIndex = 1;
			this.dgItems.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								this.dataGridTableStyle1});
			this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgItems;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dgtbBanco,
																												  this.dgtbSucursal,
																												  this.dgtbCalle,
																												  this.dgtbNro,
																												  this.dgtbPiso,
																												  this.dgtbOficina,
																												  this.dgtbCodPost,
																												  this.dgtbLocalidad,
																												  this.dgtbProvincia});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Items";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dgtbBanco
			// 
			this.dgtbBanco.Format = "";
			this.dgtbBanco.FormatInfo = null;
			this.dgtbBanco.HeaderText = "Banco";
			this.dgtbBanco.MappingName = "Banco";
			this.dgtbBanco.ReadOnly = true;
			this.dgtbBanco.Width = 140;
			// 
			// dgtbSucursal
			// 
			this.dgtbSucursal.Format = "";
			this.dgtbSucursal.FormatInfo = null;
			this.dgtbSucursal.HeaderText = "Sucursal";
			this.dgtbSucursal.MappingName = "Sucursal";
			this.dgtbSucursal.ReadOnly = true;
			this.dgtbSucursal.Width = 140;
			// 
			// dgtbCalle
			// 
			this.dgtbCalle.Format = "";
			this.dgtbCalle.FormatInfo = null;
			this.dgtbCalle.HeaderText = "Calle";
			this.dgtbCalle.MappingName = "Calle";
			this.dgtbCalle.ReadOnly = true;
			this.dgtbCalle.Width = 140;
			// 
			// dgtbNro
			// 
			this.dgtbNro.Format = "";
			this.dgtbNro.FormatInfo = null;
			this.dgtbNro.HeaderText = "Nro.";
			this.dgtbNro.MappingName = "Nro.";
			this.dgtbNro.ReadOnly = true;
			this.dgtbNro.Width = 30;
			// 
			// dgtbPiso
			// 
			this.dgtbPiso.Format = "";
			this.dgtbPiso.FormatInfo = null;
			this.dgtbPiso.HeaderText = "Piso";
			this.dgtbPiso.MappingName = "Piso";
			this.dgtbPiso.ReadOnly = true;
			this.dgtbPiso.Width = 30;
			// 
			// dgtbOficina
			// 
			this.dgtbOficina.Format = "";
			this.dgtbOficina.FormatInfo = null;
			this.dgtbOficina.HeaderText = "Of.";
			this.dgtbOficina.MappingName = "Of.";
			this.dgtbOficina.ReadOnly = true;
			this.dgtbOficina.Width = 30;
			// 
			// dgtbCodPost
			// 
			this.dgtbCodPost.Format = "";
			this.dgtbCodPost.FormatInfo = null;
			this.dgtbCodPost.HeaderText = "Cod.Post.";
			this.dgtbCodPost.MappingName = "Cod.Post.";
			this.dgtbCodPost.ReadOnly = true;
			this.dgtbCodPost.Width = 30;
			// 
			// dgtbLocalidad
			// 
			this.dgtbLocalidad.Format = "";
			this.dgtbLocalidad.FormatInfo = null;
			this.dgtbLocalidad.HeaderText = "Localidad";
			this.dgtbLocalidad.MappingName = "Localidad";
			this.dgtbLocalidad.ReadOnly = true;
			this.dgtbLocalidad.Width = 75;
			// 
			// dgtbProvincia
			// 
			this.dgtbProvincia.Format = "";
			this.dgtbProvincia.FormatInfo = null;
			this.dgtbProvincia.HeaderText = "Provincia";
			this.dgtbProvincia.MappingName = "Provincia";
			this.dgtbProvincia.ReadOnly = true;
			this.dgtbProvincia.Width = 75;
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
			this.tabFiltro.Size = new System.Drawing.Size(784, 152);
			this.tabFiltro.TabIndex = 0;
			// 
			// tabFiltro1
			// 
			this.tabFiltro1.Controls.Add(this.groupBox10);
			this.tabFiltro1.Controls.Add(this.groupBox2);
			this.tabFiltro1.Controls.Add(this.butSalir1);
			this.tabFiltro1.Controls.Add(this.butLimpiar1);
			this.tabFiltro1.Controls.Add(this.butBuscar1);
			this.tabFiltro1.Controls.Add(this.gbProveedor);
			this.tabFiltro1.Controls.Add(this.groupBox1);
			this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
			this.tabFiltro1.Name = "tabFiltro1";
			this.tabFiltro1.Size = new System.Drawing.Size(776, 126);
			this.tabFiltro1.TabIndex = 0;
			this.tabFiltro1.Text = "Filtro Rápido";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.tbSucursalB);
			this.groupBox10.Location = new System.Drawing.Point(8, 64);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(200, 48);
			this.groupBox10.TabIndex = 11;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Sucursal";
			// 
			// tbSucursalB
			// 
			this.tbSucursalB.Location = new System.Drawing.Point(8, 16);
			this.tbSucursalB.Name = "tbSucursalB";
			this.tbSucursalB.Size = new System.Drawing.Size(184, 20);
			this.tbSucursalB.TabIndex = 1;
			this.tbSucursalB.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbProvinciaB);
			this.groupBox2.Location = new System.Drawing.Point(216, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 48);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Provincia";
			// 
			// cbProvinciaB
			// 
			this.cbProvinciaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProvinciaB.Location = new System.Drawing.Point(8, 16);
			this.cbProvinciaB.Name = "cbProvinciaB";
			this.cbProvinciaB.Size = new System.Drawing.Size(184, 21);
			this.cbProvinciaB.TabIndex = 10;
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
			this.gbProveedor.Controls.Add(this.cbLocalidadB);
			this.gbProveedor.Location = new System.Drawing.Point(216, 8);
			this.gbProveedor.Name = "gbProveedor";
			this.gbProveedor.Size = new System.Drawing.Size(200, 48);
			this.gbProveedor.TabIndex = 5;
			this.gbProveedor.TabStop = false;
			this.gbProveedor.Text = "Localidad";
			// 
			// cbLocalidadB
			// 
			this.cbLocalidadB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLocalidadB.Location = new System.Drawing.Point(8, 16);
			this.cbLocalidadB.Name = "cbLocalidadB";
			this.cbLocalidadB.Size = new System.Drawing.Size(184, 21);
			this.cbLocalidadB.TabIndex = 10;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbBancoB);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Banco";
			// 
			// tbBancoB
			// 
			this.tbBancoB.Location = new System.Drawing.Point(8, 16);
			this.tbBancoB.Name = "tbBancoB";
			this.tbBancoB.Size = new System.Drawing.Size(184, 20);
			this.tbBancoB.TabIndex = 1;
			this.tbBancoB.Text = "";
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
			this.tabFiltro3.Size = new System.Drawing.Size(776, 126);
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
															   "Banco",
															   "Sucrusal"});
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
															   "Banco",
															   "Sucrusal"});
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
															   "Banco",
															   "Sucrusal"});
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
															   "Banco",
															   "Sucrusal"});
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
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(784, 438);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Detalle";
			this.tabPage2.Visible = false;
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.label6);
			this.gbModificacionProveedores.Controls.Add(this.tbTelefonos);
			this.gbModificacionProveedores.Controls.Add(this.label5);
			this.gbModificacionProveedores.Controls.Add(this.tbSucursal);
			this.gbModificacionProveedores.Controls.Add(this.label4);
			this.gbModificacionProveedores.Controls.Add(this.cbProvincia);
			this.gbModificacionProveedores.Controls.Add(this.tbCodPost);
			this.gbModificacionProveedores.Controls.Add(this.label3);
			this.gbModificacionProveedores.Controls.Add(this.tbOficina);
			this.gbModificacionProveedores.Controls.Add(this.label2);
			this.gbModificacionProveedores.Controls.Add(this.tbPiso);
			this.gbModificacionProveedores.Controls.Add(this.label1);
			this.gbModificacionProveedores.Controls.Add(this.tbNro);
			this.gbModificacionProveedores.Controls.Add(this.tbBanco);
			this.gbModificacionProveedores.Controls.Add(this.label16);
			this.gbModificacionProveedores.Controls.Add(this.label17);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.tbObservaciones);
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.label19);
			this.gbModificacionProveedores.Controls.Add(this.label22);
			this.gbModificacionProveedores.Controls.Add(this.label26);
			this.gbModificacionProveedores.Controls.Add(this.label14);
			this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
			this.gbModificacionProveedores.Controls.Add(this.tbCalle);
			this.gbModificacionProveedores.Controls.Add(this.tbEmail);
			this.gbModificacionProveedores.Controls.Add(this.cbLocalidad);
			this.gbModificacionProveedores.Controls.Add(this.tbID);
			this.gbModificacionProveedores.Controls.Add(this.groupBox9);
			this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(704, 344);
			this.gbModificacionProveedores.TabIndex = 108;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 14);
			this.label6.TabIndex = 119;
			this.label6.Text = "Teléfonos";
			// 
			// tbTelefonos
			// 
			this.tbTelefonos.Location = new System.Drawing.Point(8, 128);
			this.tbTelefonos.Name = "tbTelefonos";
			this.tbTelefonos.Size = new System.Drawing.Size(248, 20);
			this.tbTelefonos.TabIndex = 3;
			this.tbTelefonos.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 14);
			this.label5.TabIndex = 117;
			this.label5.Text = "Sucursal";
			// 
			// tbSucursal
			// 
			this.tbSucursal.Location = new System.Drawing.Point(8, 80);
			this.tbSucursal.Name = "tbSucursal";
			this.tbSucursal.Size = new System.Drawing.Size(248, 20);
			this.tbSucursal.TabIndex = 2;
			this.tbSucursal.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(280, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 14);
			this.label4.TabIndex = 115;
			this.label4.Text = "Provincia";
			// 
			// cbProvincia
			// 
			this.cbProvincia.Items.AddRange(new object[] {
															 "",
															 "F",
															 "Y"});
			this.cbProvincia.Location = new System.Drawing.Point(280, 176);
			this.cbProvincia.MaxLength = 100;
			this.cbProvincia.Name = "cbProvincia";
			this.cbProvincia.Size = new System.Drawing.Size(248, 21);
			this.cbProvincia.TabIndex = 12;
			// 
			// tbCodPost
			// 
			this.tbCodPost.Location = new System.Drawing.Point(400, 80);
			this.tbCodPost.Name = "tbCodPost";
			this.tbCodPost.Size = new System.Drawing.Size(56, 20);
			this.tbCodPost.TabIndex = 10;
			this.tbCodPost.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(400, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 14);
			this.label3.TabIndex = 112;
			this.label3.Text = "Cod.Post.";
			// 
			// tbOficina
			// 
			this.tbOficina.Location = new System.Drawing.Point(360, 80);
			this.tbOficina.Name = "tbOficina";
			this.tbOficina.Size = new System.Drawing.Size(32, 20);
			this.tbOficina.TabIndex = 9;
			this.tbOficina.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(360, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 14);
			this.label2.TabIndex = 110;
			this.label2.Text = "Oficina";
			// 
			// tbPiso
			// 
			this.tbPiso.Location = new System.Drawing.Point(320, 80);
			this.tbPiso.Name = "tbPiso";
			this.tbPiso.Size = new System.Drawing.Size(32, 20);
			this.tbPiso.TabIndex = 8;
			this.tbPiso.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(320, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 14);
			this.label1.TabIndex = 108;
			this.label1.Text = "Piso";
			// 
			// tbNro
			// 
			this.tbNro.Location = new System.Drawing.Point(280, 80);
			this.tbNro.Name = "tbNro";
			this.tbNro.Size = new System.Drawing.Size(32, 20);
			this.tbNro.TabIndex = 7;
			this.tbNro.Text = "";
			// 
			// tbBanco
			// 
			this.tbBanco.Location = new System.Drawing.Point(8, 32);
			this.tbBanco.Name = "tbBanco";
			this.tbBanco.Size = new System.Drawing.Size(248, 20);
			this.tbBanco.TabIndex = 1;
			this.tbBanco.Text = "";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(280, 64);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 14);
			this.label16.TabIndex = 97;
			this.label16.Text = "Nro.";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 160);
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
			this.butSalir.TabIndex = 15;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// tbObservaciones
			// 
			this.tbObservaciones.Location = new System.Drawing.Point(8, 224);
			this.tbObservaciones.Multiline = true;
			this.tbObservaciones.Name = "tbObservaciones";
			this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbObservaciones.Size = new System.Drawing.Size(248, 104);
			this.tbObservaciones.TabIndex = 5;
			this.tbObservaciones.Text = "";
			// 
			// butGuardar
			// 
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(304, 304);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 14;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(280, 112);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(112, 14);
			this.label19.TabIndex = 94;
			this.label19.Text = "Localidad";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(280, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(136, 14);
			this.label22.TabIndex = 91;
			this.label22.Text = "Calle";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 14);
			this.label26.TabIndex = 87;
			this.label26.Text = "Banco";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 208);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(136, 14);
			this.label14.TabIndex = 99;
			this.label14.Text = "Observaciones";
			// 
			// butLimpiar
			// 
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(432, 272);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 13;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
			// 
			// tbCalle
			// 
			this.tbCalle.Location = new System.Drawing.Point(280, 32);
			this.tbCalle.Name = "tbCalle";
			this.tbCalle.Size = new System.Drawing.Size(248, 20);
			this.tbCalle.TabIndex = 6;
			this.tbCalle.Text = "";
			// 
			// tbEmail
			// 
			this.tbEmail.Location = new System.Drawing.Point(8, 176);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(248, 20);
			this.tbEmail.TabIndex = 4;
			this.tbEmail.Text = "";
			// 
			// cbLocalidad
			// 
			this.cbLocalidad.Items.AddRange(new object[] {
															 "",
															 "F",
															 "Y"});
			this.cbLocalidad.Location = new System.Drawing.Point(280, 128);
			this.cbLocalidad.MaxLength = 100;
			this.cbLocalidad.Name = "cbLocalidad";
			this.cbLocalidad.Size = new System.Drawing.Size(248, 21);
			this.cbLocalidad.TabIndex = 11;
			// 
			// tbID
			// 
			this.tbID.Location = new System.Drawing.Point(608, 184);
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
			this.groupBox9.Location = new System.Drawing.Point(576, 24);
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
			this.label18.Size = new System.Drawing.Size(784, 32);
			this.label18.TabIndex = 95;
			this.label18.Text = "Modificación de Bancos";
			// 
			// ucBancoConsulta
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucBancoConsulta";
			this.Size = new System.Drawing.Size(792, 464);
			this.Load += new System.EventHandler(this.ucBancoConsulta_Load);
			this.tabPrincipal.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro1.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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
			this.ResumeLayout(false);

		}
		#endregion

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
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
				string sql = "SELECT     dbo.Banco.ID, dbo.Banco.nombre AS Banco, dbo.Banco.sucursal AS Sucrusal, dbo.Banco.calle, dbo.Banco.nro AS [Nro.], dbo.Banco.observaciones, " +
					"dbo.Provincia.descripcion AS Provincia, dbo.Localidad.descripcion AS Localidad, dbo.Banco.localidadID, dbo.Banco.provinciaID, dbo.Banco.piso, " +
					"dbo.Banco.oficina AS [Of.], dbo.Banco.codigoPostal AS [Cod.Post.], dbo.Banco.telefonos AS Teléfonos, dbo.Banco.email AS [E-Mail] " +
					"FROM         dbo.Banco INNER JOIN " +
					"dbo.Provincia ON dbo.Banco.provinciaID = dbo.Provincia.id INNER JOIN " +
					"dbo.Localidad ON dbo.Banco.localidadID = dbo.Localidad.id " +
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

				if (tbBancoB.Text!="") 
				{
					filtro = filtro + " AND nombre LIKE '%" + tbBancoB.Text.Trim() + "%'";
				}
				if (tbSucursalB.Text!="") 
				{
					filtro = filtro + " AND Sucursal LIKE '%" + tbSucursalB.Text.Trim() + "%'";
				}
				if (cbLocalidadB.SelectedIndex>0) 
				{
					filtro = filtro + " AND localidadID = CAST('" + cbLocalidadB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbProvinciaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND provinciaID = CAST('" + cbProvinciaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
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

		private void ucBancoConsulta_Load(object sender, System.EventArgs e)
		{
			UtilUI.llenarCombo(ref cbLocalidadB, this.conexion, "sp_getAllLocalidads", "Todas", 0);
			UtilUI.llenarCombo(ref cbProvinciaB, this.conexion, "sp_getAllProvincias", "Todas", 0);
			acomodarCombosOrden();
		}
		private void acomodarCombosOrden()
		{
			try
			{

				cbCampoOrden1.SelectedIndex = 1;  //Banco
				rbAsc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 2;  //Sucursal
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

		private void butBuscar3_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			try
			{

				tbBancoB.Text = "";
				tbSucursalB.Text = "";
				cbProvinciaB.SelectedItem = 0;
				cbLocalidadB.SelectedItem = 0;
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

		private void butSalir3_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
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
						tbBanco.Text = dt.Rows[currentRow]["Banco"].ToString();
						tbSucursal.Text = dt.Rows[currentRow]["Sucrusal"].ToString();
						tbTelefonos.Text = dt.Rows[currentRow]["Teléfonos"].ToString();
						tbEmail.Text = dt.Rows[currentRow]["E-Mail"].ToString();
						tbObservaciones.Text = dt.Rows[currentRow]["Observaciones"].ToString();
						tbCalle.Text = dt.Rows[currentRow]["Calle"].ToString();
						tbNro.Text = dt.Rows[currentRow]["Nro."].ToString();
						tbPiso.Text = dt.Rows[currentRow]["Piso"].ToString();
						tbOficina.Text = dt.Rows[currentRow]["Of."].ToString();
						tbCodPost.Text = dt.Rows[currentRow]["Cod.Post."].ToString();

						UtilUI.llenarCombo(ref cbLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
						cbLocalidad.SelectedValue = dt.Rows[currentRow]["localidadID"].ToString();
					
						UtilUI.llenarCombo(ref cbProvincia, this.conexion, "sp_getAllProvincias", "", -1);
						cbProvincia.SelectedValue = dt.Rows[currentRow]["provinciaID"].ToString();

						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
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

				if (tbBanco.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el nombre del Banco.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

				string localidadID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidad, "sp_InsertLocalidad");
				string provinciaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvincia, "sp_InsertProvincia");

				SqlParameter[] param = new SqlParameter[13];
			
				param[0] = new SqlParameter("@ID", new System.Guid(tbID.Text.Trim()));
				param[1] = new SqlParameter("@nombre", tbBanco.Text.Trim());
				param[2] = new SqlParameter("@sucrusal", tbSucursal.Text.Trim());
				param[3] = new SqlParameter("@calle", tbCalle.Text.Trim());
				param[4] = new SqlParameter("@telefonos", tbTelefonos.Text.Trim());
				param[5] = new SqlParameter("@nro", tbNro.Text.Trim());
				param[6] = new SqlParameter("@piso", tbPiso.Text.Trim());
				param[7] = new SqlParameter("@oficina", tbOficina.Text.Trim());
				param[8] = new SqlParameter("@codigoPostal", tbCodPost.Text.Trim());
				param[9] = new SqlParameter("@email", tbEmail.Text.Trim());
				param[10] = new SqlParameter("@localidadID", new System.Guid(localidadID));
				param[11] = new SqlParameter("@provinciaID", new System.Guid(provinciaID));
				param[12] = new SqlParameter("@observaciones", tbObservaciones.Text.Trim());
			
				while (true)
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarBanco", param);
						MessageBox.Show("Banco modificado con éxito.", "Modificación de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Banco modificado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo modificar el Banco. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Banco. \r\n" + e.Message, false);
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


		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		private void limpiarFormulario()
		{
			try
			{

				tbBanco.Text = "";
				tbSucursal.Text = "";
				tbTelefonos.Text= "";
				tbEmail.Text = "";
				tbObservaciones.Text = "";
				tbCalle.Text = "";
				tbNro.Text = "";
				tbOficina.Text = "";
				tbPiso.Text = "";
				tbCodPost.Text = "";
				cbLocalidad.SelectedIndex = 0;
				cbProvincia.SelectedIndex = 0;
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Bancos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Bancos...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarBanco", param);

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
			if (dgItems.CurrentRowIndex>0)
			{
				dgItems.CurrentRowIndex = dgItems.CurrentRowIndex - 1;
				cargarDetalle();
			}
		}

		private void butSiguiente_Click(object sender, System.EventArgs e)
		{
			int count = ((DataTable)dgItems.DataSource).Rows.Count-1;
			if (dgItems.CurrentRowIndex<count)
			{
				dgItems.CurrentRowIndex = dgItems.CurrentRowIndex + 1;
				cargarDetalle();
			}
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}
	}
}
