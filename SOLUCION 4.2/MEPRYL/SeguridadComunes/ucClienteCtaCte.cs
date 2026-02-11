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
	/// Summary description for ucClienteCtaCte.
	/// </summary>
	public class ucClienteCtaCte : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox tbClienteID;
		private System.Windows.Forms.Button butBuscarCliente;
		private System.Windows.Forms.TextBox tbClienteNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionHasta;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionDesde;
		private System.Windows.Forms.CheckBox chkFechaEmision;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox lbTotalDebe;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox lbTotalHaber;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox lbSaldoTotal;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.ComponentModel.IContainer components;

		public NavegadorFormulario navegador;

		public ucClienteCtaCte()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			navegador = new NavegadorFormulario(this.configuracion);

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucClienteCtaCte));
			this.tabPrincipal = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.butVistaPrevia = new System.Windows.Forms.Button();
			this.butImprimir = new System.Windows.Forms.Button();
			this.butBorrar = new System.Windows.Forms.Button();
			this.dgItems = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbSaldoTotal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lbTotalHaber = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbTotalDebe = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.butSiguiente = new System.Windows.Forms.Button();
			this.gbFechaEmision = new System.Windows.Forms.GroupBox();
			this.dtpFechaEmisionHasta = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaEmisionDesde = new System.Windows.Forms.DateTimePicker();
			this.chkFechaEmision = new System.Windows.Forms.CheckBox();
			this.tbClienteID = new System.Windows.Forms.TextBox();
			this.butBuscarCliente = new System.Windows.Forms.Button();
			this.tbClienteNombre = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
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
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.tabPrincipal.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
			this.tabFiltro.SuspendLayout();
			this.tabFiltro1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gbFechaEmision.SuspendLayout();
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
			this.tabPrincipal.Size = new System.Drawing.Size(816, 456);
			this.tabPrincipal.TabIndex = 3;
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
			this.tabPage1.Text = "Cuenta Corriente";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Gray;
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
			this.butVistaPrevia.BackColor = System.Drawing.Color.Gray;
			this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
			this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
			this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butVistaPrevia.Location = new System.Drawing.Point(340, 157);
			this.butVistaPrevia.Name = "butVistaPrevia";
			this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
			this.butVistaPrevia.TabIndex = 4;
			this.butVistaPrevia.Text = "&Vista Previa";
			this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butVistaPrevia.Click += new System.EventHandler(this.butVistaPrevia_Click);
			// 
			// butImprimir
			// 
			this.butImprimir.BackColor = System.Drawing.Color.Gray;
			this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butImprimir.ForeColor = System.Drawing.Color.White;
			this.butImprimir.Image = ((System.Drawing.Image)(resources.GetObject("butImprimir.Image")));
			this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butImprimir.Location = new System.Drawing.Point(266, 157);
			this.butImprimir.Name = "butImprimir";
			this.butImprimir.Size = new System.Drawing.Size(64, 23);
			this.butImprimir.TabIndex = 3;
			this.butImprimir.Text = "&Imprimir";
			this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.dgItems.CaptionBackColor = System.Drawing.Color.Gray;
			this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgItems.CaptionForeColor = System.Drawing.Color.White;
			this.dgItems.CaptionText = "     Cuenta Corriente";
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
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro;
			this.dataGridTableStyle1.DataGrid = this.dgItems;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn18,
																												  this.dataGridTextBoxColumn19});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Items";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "d";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "Fecha";
			this.dataGridTextBoxColumn11.MappingName = "Fecha";
			this.dataGridTextBoxColumn11.NullText = "";
			this.dataGridTextBoxColumn11.ReadOnly = true;
			this.dataGridTextBoxColumn11.Width = 80;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "Comp.";
			this.dataGridTextBoxColumn16.MappingName = "Comp.";
			this.dataGridTextBoxColumn16.ReadOnly = true;
			this.dataGridTextBoxColumn16.Width = 50;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "Tipo";
			this.dataGridTextBoxColumn12.MappingName = "Tipo";
			this.dataGridTextBoxColumn12.ReadOnly = true;
			this.dataGridTextBoxColumn12.Width = 50;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "Nro.";
			this.dataGridTextBoxColumn13.MappingName = "Nro.";
			this.dataGridTextBoxColumn13.ReadOnly = true;
			this.dataGridTextBoxColumn13.Width = 140;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "Estado";
			this.dataGridTextBoxColumn14.MappingName = "Estado";
			this.dataGridTextBoxColumn14.NullText = "";
			this.dataGridTextBoxColumn14.ReadOnly = true;
			this.dataGridTextBoxColumn14.Width = 140;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "d";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "Vencimiento";
			this.dataGridTextBoxColumn15.MappingName = "Vencimiento";
			this.dataGridTextBoxColumn15.NullText = "";
			this.dataGridTextBoxColumn15.ReadOnly = true;
			this.dataGridTextBoxColumn15.Width = 80;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn17.Format = "C";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "Debe   .";
			this.dataGridTextBoxColumn17.MappingName = "Debe";
			this.dataGridTextBoxColumn17.NullText = "";
			this.dataGridTextBoxColumn17.ReadOnly = true;
			this.dataGridTextBoxColumn17.Width = 75;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn18.Format = "C";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.HeaderText = "Haber   .";
			this.dataGridTextBoxColumn18.MappingName = "Haber";
			this.dataGridTextBoxColumn18.NullText = "";
			this.dataGridTextBoxColumn18.ReadOnly = true;
			this.dataGridTextBoxColumn18.Width = 75;
			// 
			// dataGridTextBoxColumn19
			// 
			this.dataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn19.Format = "C";
			this.dataGridTextBoxColumn19.FormatInfo = null;
			this.dataGridTextBoxColumn19.HeaderText = "Saldo   .";
			this.dataGridTextBoxColumn19.MappingName = "Saldo";
			this.dataGridTextBoxColumn19.ReadOnly = true;
			this.dataGridTextBoxColumn19.Width = 75;
			// 
			// tabFiltro
			// 
			this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabFiltro.Controls.Add(this.tabFiltro1);
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
			this.tabFiltro1.Controls.Add(this.groupBox1);
			this.tabFiltro1.Controls.Add(this.groupBox2);
			this.tabFiltro1.Controls.Add(this.butSalir1);
			this.tabFiltro1.ImageIndex = 1;
			this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
			this.tabFiltro1.Name = "tabFiltro1";
			this.tabFiltro1.Size = new System.Drawing.Size(800, 126);
			this.tabFiltro1.TabIndex = 0;
			this.tabFiltro1.Text = "Datos del Cliente";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbSaldoTotal);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.lbTotalHaber);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.lbTotalDebe);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(384, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(344, 120);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Totales";
			// 
			// lbSaldoTotal
			// 
			this.lbSaldoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbSaldoTotal.Location = new System.Drawing.Point(144, 80);
			this.lbSaldoTotal.Name = "lbSaldoTotal";
			this.lbSaldoTotal.ReadOnly = true;
			this.lbSaldoTotal.Size = new System.Drawing.Size(88, 20);
			this.lbSaldoTotal.TabIndex = 5;
			this.lbSaldoTotal.Text = "";
			this.lbSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(72, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Total Saldo";
			// 
			// lbTotalHaber
			// 
			this.lbTotalHaber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbTotalHaber.Location = new System.Drawing.Point(144, 48);
			this.lbTotalHaber.Name = "lbTotalHaber";
			this.lbTotalHaber.ReadOnly = true;
			this.lbTotalHaber.Size = new System.Drawing.Size(88, 20);
			this.lbTotalHaber.TabIndex = 3;
			this.lbTotalHaber.Text = "";
			this.lbTotalHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(72, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Total Haber";
			// 
			// lbTotalDebe
			// 
			this.lbTotalDebe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbTotalDebe.Location = new System.Drawing.Point(144, 16);
			this.lbTotalDebe.Name = "lbTotalDebe";
			this.lbTotalDebe.ReadOnly = true;
			this.lbTotalDebe.Size = new System.Drawing.Size(88, 20);
			this.lbTotalDebe.TabIndex = 1;
			this.lbTotalDebe.Text = "";
			this.lbTotalDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Total Debe";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.butSiguiente);
			this.groupBox2.Controls.Add(this.gbFechaEmision);
			this.groupBox2.Controls.Add(this.tbClienteID);
			this.groupBox2.Controls.Add(this.butBuscarCliente);
			this.groupBox2.Controls.Add(this.tbClienteNombre);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(376, 120);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cliente";
			// 
			// butSiguiente
			// 
			this.butSiguiente.BackColor = System.Drawing.SystemColors.Control;
			this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
			this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butSiguiente.Location = new System.Drawing.Point(224, 80);
			this.butSiguiente.Name = "butSiguiente";
			this.butSiguiente.Size = new System.Drawing.Size(144, 24);
			this.butSiguiente.TabIndex = 17;
			this.butSiguiente.Text = "F3 - Mostrar registros";
			this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
			// 
			// gbFechaEmision
			// 
			this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionHasta);
			this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionDesde);
			this.gbFechaEmision.Controls.Add(this.chkFechaEmision);
			this.gbFechaEmision.Location = new System.Drawing.Point(8, 64);
			this.gbFechaEmision.Name = "gbFechaEmision";
			this.gbFechaEmision.Size = new System.Drawing.Size(200, 48);
			this.gbFechaEmision.TabIndex = 16;
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
			this.chkFechaEmision.Size = new System.Drawing.Size(72, 16);
			this.chkFechaEmision.TabIndex = 4;
			this.chkFechaEmision.Text = "Intervalo";
			this.chkFechaEmision.CheckedChanged += new System.EventHandler(this.chkFechaEmision_CheckedChanged);
			// 
			// tbClienteID
			// 
			this.tbClienteID.Location = new System.Drawing.Point(304, 8);
			this.tbClienteID.Name = "tbClienteID";
			this.tbClienteID.Size = new System.Drawing.Size(40, 20);
			this.tbClienteID.TabIndex = 12;
			this.tbClienteID.Text = "0";
			this.tbClienteID.Visible = false;
			// 
			// butBuscarCliente
			// 
			this.butBuscarCliente.BackColor = System.Drawing.SystemColors.Control;
			this.butBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarCliente.Image")));
			this.butBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBuscarCliente.Location = new System.Drawing.Point(224, 30);
			this.butBuscarCliente.Name = "butBuscarCliente";
			this.butBuscarCliente.Size = new System.Drawing.Size(144, 24);
			this.butBuscarCliente.TabIndex = 5;
			this.butBuscarCliente.Text = "F1 - Buscar Cliente";
			this.butBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBuscarCliente.Click += new System.EventHandler(this.butBuscarCliente_Click);
			// 
			// tbClienteNombre
			// 
			this.tbClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbClienteNombre.Location = new System.Drawing.Point(8, 32);
			this.tbClienteNombre.Name = "tbClienteNombre";
			this.tbClienteNombre.ReadOnly = true;
			this.tbClienteNombre.Size = new System.Drawing.Size(208, 20);
			this.tbClienteNombre.TabIndex = 1;
			this.tbClienteNombre.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nombre / Razón Social";
			// 
			// butSalir1
			// 
			this.butSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir1.Image = ((System.Drawing.Image)(resources.GetObject("butSalir1.Image")));
			this.butSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butSalir1.Location = new System.Drawing.Point(744, 0);
			this.butSalir1.Name = "butSalir1";
			this.butSalir1.Size = new System.Drawing.Size(56, 23);
			this.butSalir1.TabIndex = 15;
			this.butSalir1.Text = "&Salir";
			this.butSalir1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir1.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// imagenesTab
			// 
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
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
			// ucClienteCtaCte
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucClienteCtaCte";
			this.Size = new System.Drawing.Size(816, 456);
			this.tabPrincipal.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.gbFechaEmision.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		public void inicializarComponentes()
		{
			try
			{
				//Le da el foco al boton para buscar cliente
				butBuscarCliente.Select();

				//Carga el Navegador de formularios
				cargarNavegadorFormulario();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Carga el Navegador de Formularios
		private void cargarNavegadorFormulario()
		{
			//Carga las teclas rapidas primero
			navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscarCliente, 0, (char)Keys.F1));
			navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butSiguiente, 1, (char)Keys.F3));

			//Carga los controles
			navegador.agregarControl(new CapsulaControl((Control)butBuscarCliente, 0));
			navegador.agregarControl(new CapsulaControl((Control)chkFechaEmision, 1));
			navegador.agregarControl(new CapsulaControl((Control)dtpFechaEmisionDesde, 2));
			navegador.agregarControl(new CapsulaControl((Control)dtpFechaEmisionHasta, 3));
			navegador.agregarControl(new CapsulaControl((Control)butSiguiente, 4));
			navegador.agregarControl(new CapsulaControl((Control)dgItems, 5));
			
			//Agrega los handlers para todos los controles del control contenedor
			//navegador.agregarHandlersContenedor(tabPrincipal.TabPages[0]);
			navegador.agregarHandlersContenedor(dgItems);
		}


		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
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


		private void butBuscarCliente_Click(object sender, System.EventArgs e)
		{
			abrirConsultaRapida();
		}

		//Abre el formulario de consulta en modo rapido
		private void abrirConsultaRapida()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				frmClienteConsulta form = new frmClienteConsulta(this.configuracion, true);
				form.statusBar1 = this.statusBarPrincipal;

				//Crea y asigna el Delegate
				form.objDelegateDevolverID = new Comunes.frmClienteConsulta.DelegateDevolverID(buscarCliente);
			
				form.ShowDialog();
				this.Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		//Busca el proveedor segun el codigo ingresado.
		private bool buscarCliente(string clienteID)
		{
			try
			{
				bool encontrado = false;
				string razonSocial = "";
			
				this.Cursor = Cursors.WaitCursor;
	
				string sparam="", sp="";
				sparam = "@clienteID";
				sp = "sp_getClienteByID";

				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(sparam, new System.Guid(clienteID));
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

				//Si se encontro el registro
				if (dr.HasRows)
				{
					dr.Read();
					if (dr["Empresa"].ToString()!="")
					{
						razonSocial = dr["Empresa"].ToString();
					}
					else
						razonSocial = dr["apellido"].ToString() + ", " + dr["nombres"].ToString();

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
					clienteID = Utilidades.ID_VACIO;
					//El foco para buscar
					butBuscarCliente.Select();
				}
				else
				{
					//El foco para continuar
					butSiguiente.Select();
				}

				tbClienteID.Text = clienteID;
				tbClienteNombre.Text = razonSocial;
				
				this.Cursor = Cursors.Arrow;

				return encontrado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		private void chkFechaEmision_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpFechaEmisionDesde.Enabled = chkFechaEmision.Checked;
			dtpFechaEmisionHasta.Enabled = chkFechaEmision.Checked;
		}

		private void dtpFechaEmisionDesde_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaEmisionHasta.Value < dtpFechaEmisionDesde.Value)
				dtpFechaEmisionHasta.Value = dtpFechaEmisionDesde.Value;
		}

		private void dtpFechaEmisionHasta_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaEmisionDesde.Value > dtpFechaEmisionHasta.Value)
				dtpFechaEmisionDesde.Value = dtpFechaEmisionHasta.Value;
		}

		private void butSiguiente_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		//Ejecuta el select de la busqueda
		private void ejecutarBusqueda()
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Ejecutando búsqueda...", true);
			
				//Prepara las fechas
				DateTime fechaEmisionDesde, fechaEmisionHasta;
				if (chkFechaEmision.Checked)
				{
					fechaEmisionDesde = dtpFechaEmisionDesde.Value.Date;
					fechaEmisionHasta = dtpFechaEmisionHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
				}
				else
				{
					fechaEmisionDesde = new DateTime(1900,01,01);
					fechaEmisionHasta = new DateTime(2100,01,01);
				}

				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter("@clienteID", new Guid(tbClienteID.Text));
				param[1] = new SqlParameter("@fechaEmisionDesde", fechaEmisionDesde);
				param[2] = new SqlParameter("@fechaEmisionHasta", fechaEmisionHasta);

				//initialize dataset
				DataSet dsItems = SqlHelper.ExecuteDataset(this.conexion, "sp_getAllClienteCuentaCorriente", param);
				dsItems.Tables[0].TableName = "Items";

				//Calcula el saldo
				double saldo = 0, totalDebe = 0, totalHaber = 0;
				DataTable dt = dsItems.Tables[0];

				for (int i=0; i<dt.Rows.Count; i++)
				{
					if (i==0)
						saldo = double.Parse("0" + dt.Rows[i]["Saldo"].ToString());
					else
						saldo += double.Parse("0" + dt.Rows[i]["Debe"].ToString()) - double.Parse("0" + dt.Rows[i]["Haber"].ToString());

					dt.Rows[i]["Saldo"] = saldo;

					totalDebe += double.Parse("0" + dt.Rows[i]["Debe"].ToString());
					totalHaber += double.Parse("0" + dt.Rows[i]["Haber"].ToString());
				}

				//Muestra los totales
				lbTotalDebe.Text = totalDebe.ToString("C");
				lbTotalHaber.Text = totalHaber.ToString("C");
				lbSaldoTotal.Text = saldo.ToString("C");

				//prepare dataview to sort
				DataView dvItems;
				dvItems = new DataView(dt);
				//dgItems.DataSource = dvItems;
				dgItems.DataSource = dt;
				dgItems.Visible = true;

				dt = null;

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butVistaPrevia_Click(object sender, System.EventArgs e)
		{
			try
			{

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Preparando Reporte...", true);
				crClienteCtaCte doc = new crClienteCtaCte();

				doc.SetDataSource(((DataTable)dgItems.DataSource));

				doc.DataDefinition.FormulaFields["txtRazonSocial"].Text = "\"" + tbClienteNombre.Text + "\"";
				if (chkFechaEmision.Checked)
				{
					doc.DataDefinition.FormulaFields["txtFechaEmisionDesde"].Text = "\"" + dtpFechaEmisionDesde.Text + "\"";
					doc.DataDefinition.FormulaFields["txtFechaEmisionHasta"].Text = "\"" + dtpFechaEmisionHasta.Text + "\"";
				}
				doc.DataDefinition.FormulaFields["txtTotalSaldo"].Text = "\"" + lbSaldoTotal.Text + "\"";

				
				frmPreview fp = new frmPreview();
				fp.Text = "Vista Previa: " + dgItems.CaptionText;
				fp.crystalReportViewer1.ReportSource = doc;
				fp.Show();
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Reporte Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butImprimir_Click(object sender, System.EventArgs e)
		{
			try
			{

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Preparando Reporte...", true);
				crClienteCtaCte doc = new crClienteCtaCte();

				doc.SetDataSource(((DataTable)dgItems.DataSource));

				doc.DataDefinition.FormulaFields["txtRazonSocial"].Text = "\"" + tbClienteNombre.Text + "\"";
				if (chkFechaEmision.Checked)
				{
					doc.DataDefinition.FormulaFields["txtFechaEmisionDesde"].Text = "\"" + dtpFechaEmisionDesde.Text + "\"";
					doc.DataDefinition.FormulaFields["txtFechaEmisionHasta"].Text = "\"" + dtpFechaEmisionHasta.Text + "\"";
				}
				doc.DataDefinition.FormulaFields["txtTotalSaldo"].Text = "\"" + lbSaldoTotal.Text + "\"";


				System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
				printDialog1.Document = pd;
			
				if (printDialog1.ShowDialog()==DialogResult.OK)
				{
					int desde = 0, hasta = 0;
					if (printDialog1.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages)
					{
						desde = 1;
						hasta = 10000;
					}
					else
					{
						desde = printDialog1.PrinterSettings.FromPage;
						hasta = printDialog1.PrinterSettings.ToPage;
					}
					int copias = printDialog1.PrinterSettings.Copies;
					doc.PrintToPrinter(copias, printDialog1.PrinterSettings.Collate, desde, hasta);
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
	}
}
