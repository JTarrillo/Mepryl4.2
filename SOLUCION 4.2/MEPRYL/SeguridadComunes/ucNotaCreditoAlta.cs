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
	/// Summary description for ucNotaCreditoAlta.
	/// </summary>
	public class ucNotaCreditoAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = "";
		public Configuracion m_configuracion;
		private Hashtable controles = new Hashtable();
		private Hashtable controlesDet = new Hashtable();
		public bool consultaRapida = false;
		private Control tbCodigoUsado;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Button butAgregarArticuloAC;
		private System.Windows.Forms.TextBox tbCodigoBarrasAC;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox tbCodigoInternoAC;
		private System.Windows.Forms.Label tbDescripcionAC;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label tbSubRubroAC;
		private System.Windows.Forms.Label tbRubroAC;
		private System.Windows.Forms.Button butBuscarArticuloAC;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbCantidadAC;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button butBorrarArticulosComponentes;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbVendedor;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbPrecioAC;
		private System.Windows.Forms.TextBox tbPromocionAC;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblSubTotal2;
		private System.Windows.Forms.Label lblBonificacion;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblIva2;
		private System.Windows.Forms.Label lblIva1;
		private System.Windows.Forms.Label lblSubTotal1;
		private System.Windows.Forms.ComboBox cbAutorizadorBonificacion;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblBonifica;
		private System.Windows.Forms.TextBox tbBonificacion;
		private System.Windows.Forms.Button butSuspender;
		private System.Windows.Forms.Button butCancelar;
		private System.Windows.Forms.Button butCrearRemitos;
		private System.Windows.Forms.DataGrid dgSubArticulos;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butNuevaNotaCredito;
		private System.Windows.Forms.Button butBuscarFactura;
		private System.Windows.Forms.Label lbIVA;
		private System.Windows.Forms.Label lbDireccion;
		private System.Windows.Forms.Label lbCUIT;
		private System.Windows.Forms.Button butImprimirNota;
		private System.Windows.Forms.Label lbClienteNombre;
		private System.Windows.Forms.TextBox tbFacturaNro;
		private System.Windows.Forms.TextBox tbFacturaSucursal;
		private System.Windows.Forms.TextBox tbFacturaID;
		private System.Windows.Forms.TextBox tbNotaCreditoID;
		private System.Windows.Forms.ComboBox cbIVA;
        private Button butBuscarConcepto;
        private TextBox tbClienteID;
        private ComboBox cbTipoFactura;
		public DataSet dataset = (DataSet) new dsArticulos();
        public NavegadorFormulario navegador;
        public NavegadorFormulario navegadorItems;

		public ucNotaCreditoAlta()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            navegador = new NavegadorFormulario(this.configuracion);
            navegadorItems = new NavegadorFormulario(this.configuracion);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNotaCreditoAlta));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbClienteID = new System.Windows.Forms.TextBox();
            this.cbIVA = new System.Windows.Forms.ComboBox();
            this.tbFacturaID = new System.Windows.Forms.TextBox();
            this.lbCUIT = new System.Windows.Forms.Label();
            this.lbDireccion = new System.Windows.Forms.Label();
            this.lbIVA = new System.Windows.Forms.Label();
            this.lbClienteNombre = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTipoFactura = new System.Windows.Forms.ComboBox();
            this.butBuscarConcepto = new System.Windows.Forms.Button();
            this.butBuscarFactura = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFacturaNro = new System.Windows.Forms.TextBox();
            this.tbFacturaSucursal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butBorrarArticulosComponentes = new System.Windows.Forms.Button();
            this.dgSubArticulos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butNuevaNotaCredito = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSubTotal2 = new System.Windows.Forms.Label();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIva2 = new System.Windows.Forms.Label();
            this.lblIva1 = new System.Windows.Forms.Label();
            this.lblSubTotal1 = new System.Windows.Forms.Label();
            this.cbAutorizadorBonificacion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBonifica = new System.Windows.Forms.Label();
            this.tbBonificacion = new System.Windows.Forms.TextBox();
            this.butImprimirNota = new System.Windows.Forms.Button();
            this.butSuspender = new System.Windows.Forms.Button();
            this.butCancelar = new System.Windows.Forms.Button();
            this.butCrearRemitos = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbNotaCreditoID = new System.Windows.Forms.TextBox();
            this.tbPromocionAC = new System.Windows.Forms.TextBox();
            this.tbPrecioAC = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.butAgregarArticuloAC = new System.Windows.Forms.Button();
            this.tbCodigoBarrasAC = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCodigoInternoAC = new System.Windows.Forms.TextBox();
            this.tbDescripcionAC = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbSubRubroAC = new System.Windows.Forms.Label();
            this.tbRubroAC = new System.Windows.Forms.Label();
            this.butBuscarArticuloAC = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.tbCantidadAC = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(800, 32);
            this.label18.TabIndex = 114;
            this.label18.Text = "     Nota de Crédito";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(93, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 424);
            this.tabControl1.TabIndex = 152;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.butSiguiente);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cabecera";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbClienteID);
            this.groupBox3.Controls.Add(this.cbIVA);
            this.groupBox3.Controls.Add(this.tbFacturaID);
            this.groupBox3.Controls.Add(this.lbCUIT);
            this.groupBox3.Controls.Add(this.lbDireccion);
            this.groupBox3.Controls.Add(this.lbIVA);
            this.groupBox3.Controls.Add(this.lbClienteNombre);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(792, 120);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // tbClienteID
            // 
            this.tbClienteID.Location = new System.Drawing.Point(528, 42);
            this.tbClienteID.Name = "tbClienteID";
            this.tbClienteID.Size = new System.Drawing.Size(24, 20);
            this.tbClienteID.TabIndex = 19;
            this.tbClienteID.Text = "0";
            this.tbClienteID.Visible = false;
            // 
            // cbIVA
            // 
            this.cbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIVA.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbIVA.Location = new System.Drawing.Point(424, 32);
            this.cbIVA.Name = "cbIVA";
            this.cbIVA.Size = new System.Drawing.Size(56, 21);
            this.cbIVA.TabIndex = 18;
            this.cbIVA.Visible = false;
            // 
            // tbFacturaID
            // 
            this.tbFacturaID.Location = new System.Drawing.Point(528, 16);
            this.tbFacturaID.Name = "tbFacturaID";
            this.tbFacturaID.Size = new System.Drawing.Size(24, 20);
            this.tbFacturaID.TabIndex = 17;
            this.tbFacturaID.Text = "0";
            this.tbFacturaID.Visible = false;
            // 
            // lbCUIT
            // 
            this.lbCUIT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCUIT.Location = new System.Drawing.Point(240, 80);
            this.lbCUIT.Name = "lbCUIT";
            this.lbCUIT.Size = new System.Drawing.Size(208, 24);
            this.lbCUIT.TabIndex = 16;
            // 
            // lbDireccion
            // 
            this.lbDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDireccion.Location = new System.Drawing.Point(8, 80);
            this.lbDireccion.Name = "lbDireccion";
            this.lbDireccion.Size = new System.Drawing.Size(208, 24);
            this.lbDireccion.TabIndex = 15;
            // 
            // lbIVA
            // 
            this.lbIVA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbIVA.Location = new System.Drawing.Point(240, 32);
            this.lbIVA.Name = "lbIVA";
            this.lbIVA.Size = new System.Drawing.Size(208, 24);
            this.lbIVA.TabIndex = 14;
            // 
            // lbClienteNombre
            // 
            this.lbClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbClienteNombre.Location = new System.Drawing.Point(8, 32);
            this.lbClienteNombre.Name = "lbClienteNombre";
            this.lbClienteNombre.Size = new System.Drawing.Size(208, 24);
            this.lbClienteNombre.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(240, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "CUIT";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dirección";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre / Razón Social";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(240, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "IVA";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTipoFactura);
            this.groupBox2.Controls.Add(this.butBuscarConcepto);
            this.groupBox2.Controls.Add(this.butBuscarFactura);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbFacturaNro);
            this.groupBox2.Controls.Add(this.tbFacturaSucursal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbVendedor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 95);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cbTipoFactura
            // 
            this.cbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFactura.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cbTipoFactura.Location = new System.Drawing.Point(302, 11);
            this.cbTipoFactura.Name = "cbTipoFactura";
            this.cbTipoFactura.Size = new System.Drawing.Size(35, 21);
            this.cbTipoFactura.TabIndex = 160;
            // 
            // butBuscarConcepto
            // 
            this.butBuscarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarConcepto.Image")));
            this.butBuscarConcepto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarConcepto.Location = new System.Drawing.Point(240, 58);
            this.butBuscarConcepto.Name = "butBuscarConcepto";
            this.butBuscarConcepto.Size = new System.Drawing.Size(128, 25);
            this.butBuscarConcepto.TabIndex = 159;
            this.butBuscarConcepto.Text = "F1 - Buscar Factura";
            this.butBuscarConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarConcepto.Click += new System.EventHandler(this.butBuscarConcepto_Click);
            // 
            // butBuscarFactura
            // 
            this.butBuscarFactura.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarFactura.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarFactura.Image")));
            this.butBuscarFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarFactura.Location = new System.Drawing.Point(464, 30);
            this.butBuscarFactura.Name = "butBuscarFactura";
            this.butBuscarFactura.Size = new System.Drawing.Size(112, 24);
            this.butBuscarFactura.TabIndex = 14;
            this.butBuscarFactura.Text = "&Ingresar Factura";
            this.butBuscarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarFactura.UseVisualStyleBackColor = false;
            this.butBuscarFactura.Click += new System.EventHandler(this.butBuscarFactura_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(288, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(8, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "-";
            // 
            // tbFacturaNro
            // 
            this.tbFacturaNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaNro.Location = new System.Drawing.Point(296, 32);
            this.tbFacturaNro.Name = "tbFacturaNro";
            this.tbFacturaNro.Size = new System.Drawing.Size(152, 20);
            this.tbFacturaNro.TabIndex = 12;
            this.tbFacturaNro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbFacturaNro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFacturaNro_KeyPress);
            this.tbFacturaNro.Validated += new System.EventHandler(this.tbFacturaNro_Validated);
            // 
            // tbFacturaSucursal
            // 
            this.tbFacturaSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaSucursal.Location = new System.Drawing.Point(240, 32);
            this.tbFacturaSucursal.Name = "tbFacturaSucursal";
            this.tbFacturaSucursal.Size = new System.Drawing.Size(48, 20);
            this.tbFacturaSucursal.TabIndex = 11;
            this.tbFacturaSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbFacturaSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFacturaSucursal_KeyPress);
            this.tbFacturaSucursal.Validated += new System.EventHandler(this.tbFacturaSucursal_Validated);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(240, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Factura Nro.";
            // 
            // cbVendedor
            // 
            this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedor.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbVendedor.Location = new System.Drawing.Point(8, 32);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(208, 21);
            this.cbVendedor.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vendedor";
            // 
            // butSiguiente
            // 
            this.butSiguiente.BackColor = System.Drawing.SystemColors.Control;
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(464, 230);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(112, 24);
            this.butSiguiente.TabIndex = 158;
            this.butSiguiente.Text = "F3 - Continuar";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSiguiente.UseVisualStyleBackColor = false;
            this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butBorrarArticulosComponentes);
            this.tabPage2.Controls.Add(this.dgSubArticulos);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.Visible = false;
            // 
            // butBorrarArticulosComponentes
            // 
            this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
            this.butBorrarArticulosComponentes.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarArticulosComponentes.Image")));
            this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(208, 88);
            this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
            this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
            this.butBorrarArticulosComponentes.TabIndex = 155;
            this.butBorrarArticulosComponentes.Text = "&Borrar";
            this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarArticulosComponentes.UseVisualStyleBackColor = false;
            this.butBorrarArticulosComponentes.Click += new System.EventHandler(this.butBorrarArticulosComponentes_Click);
            // 
            // dgSubArticulos
            // 
            this.dgSubArticulos.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgSubArticulos.CaptionBackColor = System.Drawing.Color.DarkSeaGreen;
            this.dgSubArticulos.CaptionText = "Artículos";
            this.dgSubArticulos.DataMember = "";
            this.dgSubArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSubArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSubArticulos.Location = new System.Drawing.Point(0, 88);
            this.dgSubArticulos.Name = "dgSubArticulos";
            this.dgSubArticulos.RowHeadersVisible = false;
            this.dgSubArticulos.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgSubArticulos.Size = new System.Drawing.Size(792, 198);
            this.dgSubArticulos.TabIndex = 157;
            this.dgSubArticulos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgSubArticulos.DoubleClick += new System.EventHandler(this.dgSubArticulos_DoubleClick);
            this.dgSubArticulos.CurrentCellChanged += new System.EventHandler(this.dgSubArticulos_CurrentCellChanged);
            this.dgSubArticulos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgSubArticulos_KeyPress);
            this.dgSubArticulos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgSubArticulos_KeyUp);
            this.dgSubArticulos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSubArticulos_KeyDown);
            this.dgSubArticulos.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgSubArticulos_PreviewKeyDown);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.LightYellow;
            this.dataGridTableStyle1.DataGrid = this.dgSubArticulos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "v_Articulo";
            this.dataGridTableStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "# .";
            this.dataGridTextBoxColumn1.MappingName = "itemNro";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 25;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Cod.Interno .";
            this.dataGridTextBoxColumn2.MappingName = "Código Interno";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Cod.Barras .";
            this.dataGridTextBoxColumn3.MappingName = "Código de Barras";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Cantidad .";
            this.dataGridTextBoxColumn4.MappingName = "Cantidad";
            this.dataGridTextBoxColumn4.Width = 50;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Descripción";
            this.dataGridTextBoxColumn7.MappingName = "Descripción";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 300;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn8.Format = "C";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "P.Unitario  .";
            this.dataGridTextBoxColumn8.MappingName = "Precio";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn9.Format = "C";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Total  .";
            this.dataGridTextBoxColumn9.MappingName = "precioTotal";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butNuevaNotaCredito);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblSubTotal2);
            this.groupBox1.Controls.Add(this.lblBonificacion);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblIva2);
            this.groupBox1.Controls.Add(this.lblIva1);
            this.groupBox1.Controls.Add(this.lblSubTotal1);
            this.groupBox1.Controls.Add(this.cbAutorizadorBonificacion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblBonifica);
            this.groupBox1.Controls.Add(this.tbBonificacion);
            this.groupBox1.Controls.Add(this.butImprimirNota);
            this.groupBox1.Controls.Add(this.butSuspender);
            this.groupBox1.Controls.Add(this.butCancelar);
            this.groupBox1.Controls.Add(this.butCrearRemitos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 112);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            // 
            // butNuevaNotaCredito
            // 
            this.butNuevaNotaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butNuevaNotaCredito.Image = ((System.Drawing.Image)(resources.GetObject("butNuevaNotaCredito.Image")));
            this.butNuevaNotaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNuevaNotaCredito.Location = new System.Drawing.Point(280, 56);
            this.butNuevaNotaCredito.Name = "butNuevaNotaCredito";
            this.butNuevaNotaCredito.Size = new System.Drawing.Size(150, 40);
            this.butNuevaNotaCredito.TabIndex = 157;
            this.butNuevaNotaCredito.Text = "F10 - Nueva Nota de Crédito";
            this.butNuevaNotaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNuevaNotaCredito.Click += new System.EventHandler(this.butNuevaNotaCredito_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(592, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 24);
            this.label14.TabIndex = 156;
            this.label14.Text = "TOTAL";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(616, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 24);
            this.label13.TabIndex = 155;
            this.label13.Text = "IVA 2";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(464, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 24);
            this.label12.TabIndex = 154;
            this.label12.Text = "IVA 1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(616, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 24);
            this.label11.TabIndex = 153;
            this.label11.Text = "SubTotal";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(448, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 24);
            this.label10.TabIndex = 152;
            this.label10.Text = "Bonificación";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(616, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 24);
            this.label9.TabIndex = 151;
            this.label9.Text = "SubTotal";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal2
            // 
            this.lblSubTotal2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal2.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblSubTotal2.Location = new System.Drawing.Point(680, 32);
            this.lblSubTotal2.Name = "lblSubTotal2";
            this.lblSubTotal2.Size = new System.Drawing.Size(96, 24);
            this.lblSubTotal2.TabIndex = 150;
            this.lblSubTotal2.Text = "0";
            this.lblSubTotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacion.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblBonificacion.Location = new System.Drawing.Point(528, 32);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(80, 24);
            this.lblBonificacion.TabIndex = 149;
            this.lblBonificacion.Text = "0";
            this.lblBonificacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotal.Location = new System.Drawing.Point(656, 80);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 24);
            this.lblTotal.TabIndex = 148;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIva2
            // 
            this.lblIva2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIva2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva2.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblIva2.Location = new System.Drawing.Point(680, 56);
            this.lblIva2.Name = "lblIva2";
            this.lblIva2.Size = new System.Drawing.Size(96, 24);
            this.lblIva2.TabIndex = 147;
            this.lblIva2.Text = "0";
            this.lblIva2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIva1
            // 
            this.lblIva1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIva1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva1.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblIva1.Location = new System.Drawing.Point(528, 56);
            this.lblIva1.Name = "lblIva1";
            this.lblIva1.Size = new System.Drawing.Size(80, 24);
            this.lblIva1.TabIndex = 146;
            this.lblIva1.Text = "0";
            this.lblIva1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal1
            // 
            this.lblSubTotal1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubTotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal1.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblSubTotal1.Location = new System.Drawing.Point(680, 8);
            this.lblSubTotal1.Name = "lblSubTotal1";
            this.lblSubTotal1.Size = new System.Drawing.Size(96, 24);
            this.lblSubTotal1.TabIndex = 145;
            this.lblSubTotal1.Text = "0";
            this.lblSubTotal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAutorizadorBonificacion
            // 
            this.cbAutorizadorBonificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutorizadorBonificacion.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbAutorizadorBonificacion.Location = new System.Drawing.Point(184, 8);
            this.cbAutorizadorBonificacion.Name = "cbAutorizadorBonificacion";
            this.cbAutorizadorBonificacion.Size = new System.Drawing.Size(144, 21);
            this.cbAutorizadorBonificacion.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(136, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 24);
            this.label8.TabIndex = 34;
            this.label8.Text = "Autoriza";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBonifica
            // 
            this.lblBonifica.Location = new System.Drawing.Point(8, 8);
            this.lblBonifica.Name = "lblBonifica";
            this.lblBonifica.Size = new System.Drawing.Size(80, 24);
            this.lblBonifica.TabIndex = 33;
            this.lblBonifica.Text = "Bonificación %";
            this.lblBonifica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBonificacion
            // 
            this.tbBonificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBonificacion.Location = new System.Drawing.Point(88, 8);
            this.tbBonificacion.Name = "tbBonificacion";
            this.tbBonificacion.Size = new System.Drawing.Size(40, 20);
            this.tbBonificacion.TabIndex = 32;
            this.tbBonificacion.Text = "0";
            this.tbBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBonificacion.Enter += new System.EventHandler(this.tbBonificacion_Enter);
            this.tbBonificacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbBonificacion_MouseDown);
            this.tbBonificacion.Validating += new System.ComponentModel.CancelEventHandler(this.tbBonificacion_Validating);
            // 
            // butImprimirNota
            // 
            this.butImprimirNota.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirNota.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirNota.Image")));
            this.butImprimirNota.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimirNota.Location = new System.Drawing.Point(8, 48);
            this.butImprimirNota.Name = "butImprimirNota";
            this.butImprimirNota.Size = new System.Drawing.Size(120, 24);
            this.butImprimirNota.TabIndex = 31;
            this.butImprimirNota.Text = "F7 - Imprimir N.C.";
            this.butImprimirNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirNota.Click += new System.EventHandler(this.butImprimirNota_Click);
            // 
            // butSuspender
            // 
            this.butSuspender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender.Image")));
            this.butSuspender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender.Location = new System.Drawing.Point(136, 48);
            this.butSuspender.Name = "butSuspender";
            this.butSuspender.Size = new System.Drawing.Size(120, 24);
            this.butSuspender.TabIndex = 30;
            this.butSuspender.Text = "&Suspender";
            this.butSuspender.Visible = false;
            this.butSuspender.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar.Location = new System.Drawing.Point(136, 80);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(120, 24);
            this.butCancelar.TabIndex = 29;
            this.butCancelar.Text = "F12 - Cancelar";
            this.butCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // butCrearRemitos
            // 
            this.butCrearRemitos.Enabled = false;
            this.butCrearRemitos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCrearRemitos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCrearRemitos.Location = new System.Drawing.Point(8, 80);
            this.butCrearRemitos.Name = "butCrearRemitos";
            this.butCrearRemitos.Size = new System.Drawing.Size(120, 24);
            this.butCrearRemitos.TabIndex = 28;
            this.butCrearRemitos.Text = "&Crear Remito(s)";
            this.butCrearRemitos.Visible = false;
            this.butCrearRemitos.Click += new System.EventHandler(this.butCrearRemitos_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbNotaCreditoID);
            this.groupBox5.Controls.Add(this.tbPromocionAC);
            this.groupBox5.Controls.Add(this.tbPrecioAC);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.butAgregarArticuloAC);
            this.groupBox5.Controls.Add(this.tbCodigoBarrasAC);
            this.groupBox5.Controls.Add(this.tbID);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.tbCodigoInternoAC);
            this.groupBox5.Controls.Add(this.tbDescripcionAC);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.tbSubRubroAC);
            this.groupBox5.Controls.Add(this.tbRubroAC);
            this.groupBox5.Controls.Add(this.butBuscarArticuloAC);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.tbCantidadAC);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(792, 88);
            this.groupBox5.TabIndex = 153;
            this.groupBox5.TabStop = false;
            // 
            // tbNotaCreditoID
            // 
            this.tbNotaCreditoID.Location = new System.Drawing.Point(704, 8);
            this.tbNotaCreditoID.Name = "tbNotaCreditoID";
            this.tbNotaCreditoID.Size = new System.Drawing.Size(16, 20);
            this.tbNotaCreditoID.TabIndex = 150;
            this.tbNotaCreditoID.Visible = false;
            // 
            // tbPromocionAC
            // 
            this.tbPromocionAC.Location = new System.Drawing.Point(656, 8);
            this.tbPromocionAC.Name = "tbPromocionAC";
            this.tbPromocionAC.Size = new System.Drawing.Size(16, 20);
            this.tbPromocionAC.TabIndex = 149;
            this.tbPromocionAC.Visible = false;
            // 
            // tbPrecioAC
            // 
            this.tbPrecioAC.Location = new System.Drawing.Point(672, 8);
            this.tbPrecioAC.Name = "tbPrecioAC";
            this.tbPrecioAC.Size = new System.Drawing.Size(16, 20);
            this.tbPrecioAC.TabIndex = 148;
            this.tbPrecioAC.Visible = false;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(296, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 16);
            this.label24.TabIndex = 141;
            this.label24.Text = "Rubro";
            // 
            // butAgregarArticuloAC
            // 
            this.butAgregarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butAgregarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butAgregarArticuloAC.Location = new System.Drawing.Point(720, 8);
            this.butAgregarArticuloAC.Name = "butAgregarArticuloAC";
            this.butAgregarArticuloAC.Size = new System.Drawing.Size(24, 24);
            this.butAgregarArticuloAC.TabIndex = 136;
            this.butAgregarArticuloAC.UseVisualStyleBackColor = false;
            this.butAgregarArticuloAC.Visible = false;
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
            this.tbCodigoBarrasAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatosIngresoArticulos_KeyDown);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(688, 8);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(16, 20);
            this.tbID.TabIndex = 147;
            this.tbID.Visible = false;
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
            this.tbCodigoInternoAC.Size = new System.Drawing.Size(80, 21);
            this.tbCodigoInternoAC.TabIndex = 133;
            this.tbCodigoInternoAC.Enter += new System.EventHandler(this.tbCodigoInternoAC_Enter);
            this.tbCodigoInternoAC.Leave += new System.EventHandler(this.tbCodigoInternoAC_Leave);
            this.tbCodigoInternoAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoInternoAC_KeyPress);
            this.tbCodigoInternoAC.TextChanged += new System.EventHandler(this.tbCodigoInternoAC_TextChanged);
            this.tbCodigoInternoAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatosIngresoArticulos_KeyDown);
            // 
            // tbDescripcionAC
            // 
            this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcionAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbDescripcionAC.Location = new System.Drawing.Point(536, 32);
            this.tbDescripcionAC.Name = "tbDescripcionAC";
            this.tbDescripcionAC.Size = new System.Drawing.Size(248, 48);
            this.tbDescripcionAC.TabIndex = 146;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(536, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 16);
            this.label27.TabIndex = 143;
            this.label27.Text = "Descripción";
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
            // 
            // butBuscarArticuloAC
            // 
            this.butBuscarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarArticuloAC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarArticuloAC.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarArticuloAC.Image")));
            this.butBuscarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscarArticuloAC.Location = new System.Drawing.Point(248, 32);
            this.butBuscarArticuloAC.Name = "butBuscarArticuloAC";
            this.butBuscarArticuloAC.Size = new System.Drawing.Size(42, 38);
            this.butBuscarArticuloAC.TabIndex = 137;
            this.butBuscarArticuloAC.Text = "[F1]";
            this.butBuscarArticuloAC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscarArticuloAC.UseVisualStyleBackColor = false;
            this.butBuscarArticuloAC.Enter += new System.EventHandler(this.butBuscarArticuloAC_Enter);
            this.butBuscarArticuloAC.Click += new System.EventHandler(this.butBuscarArticuloAC_Click);
            this.butBuscarArticuloAC.Leave += new System.EventHandler(this.butBuscarArticuloAC_Leave);
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
            this.tbCantidadAC.TextChanged += new System.EventHandler(this.tbCantidadAC_TextChanged);
            this.tbCantidadAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatosIngresoArticulos_KeyDown);
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
            // ucNotaCreditoAlta
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label18);
            this.Name = "ucNotaCreditoAlta";
            this.Size = new System.Drawing.Size(800, 456);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		
		
		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				tbFacturaID.Text = Utilidades.ID_VACIO;
				tbNotaCreditoID.Text = Utilidades.ID_VACIO;
                tbClienteID.Text = Utilidades.ID_VACIO;

				//Llena los combos
				//Obtiene todos los vendedores de la sucursal actual
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
				UtilUI.llenarCombo(ref cbVendedor, this.conexion, "sp_getAllVendedorsBySucursal", "", -1, param);
				UtilUI.llenarCombo(ref cbAutorizadorBonificacion, this.conexion, "sp_getAllVendedorsBySucursal", "", -1, param);
				UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
                cbTipoFactura.SelectedIndex = 0;  //Selecciona A
			
				//Asigna la tabla a la datagrid
				dgSubArticulos.DataSource = (DataTable)dataset.Tables["v_Articulo"];

                //Carga el Navegador de formularios
                cargarNavegadorFormulario();


                asignarEventosGrilla(ref dgSubArticulos);
                cbTipoFactura.Select();  //Pone el foco en el tipo de factura
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
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
				string precio="", promocion="";
			
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
				tbPrecioAC.Text = precio;
				tbPromocionAC.Text = promocion;

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
					tbPrecioAC.Text = precio;
					tbPromocionAC.Text = promocion;

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


		private void tbCodigoInternoAC_Enter(object sender, System.EventArgs e)
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
			/*try
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
					newRow["precio"] = double.Parse(tbPrecioAC.Text);
					newRow["promocion"] = bool.Parse(tbPromocionAC.Text);
					newRow["itemNro"] = tabla.Rows.Count + 1;
					newRow["descuento"] = 0;
					newRow["precioTotal"] = double.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
					newRow["precioTotalConDesc"] = double.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
					tabla.Rows.Add(newRow);

					//Limpia los codigos
					tbCodigoInternoAC.Text = "";
					tbCodigoBarrasAC.Text = "";
					tbRubroAC.Text = "";
					tbSubRubroAC.Text = "";
					tbDescripcionAC.Text = "";
					tbID.Text = "";
					tbPrecioAC.Text = "";
					tbPromocionAC.Text = "";

					//Establece el foco en la grilla y muestra el ultimo registro
					dgSubArticulos.Select();
					dgSubArticulos.CurrentRowIndex = ((DataTable)dgSubArticulos.DataSource).Rows.Count - 1;

					//Establece el foco
					if (controlFocus!=null)
						controlFocus.Select();

					calcularSubTotales();
				}
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}*/

            try
            {
                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", true);
                if (Utilidades.IsNumeric(tbCantidadAC.Text) &&
                    tbCantidadAC.Text.Trim() != "" &&
                    tbRubroAC.Text != "No registrado." && tbRubroAC.Text != "" &&
                    !(tbCodigoInternoAC.Text.Trim() == "" && tbCodigoBarrasAC.Text.Trim() == "" && tbID.Text.Trim() == ""))
                {
                    //Agrega un registro a la tabla de la grilla
                    DataTable tabla = (DataTable)dgSubArticulos.DataSource;

                    bool existe = false;
                    int i = 0;
                    //Busca si el articulo ya fue ingresado
                    for (i = 0; i < tabla.Rows.Count; i++)
                    {
                        if (tabla.Rows[i]["articuloID"].ToString() == tbID.Text)
                        {
                            existe = true;
                            break;
                        }
                    }
                    decimal precioUnitario = decimal.Parse(tbPrecioAC.Text);
                    if (existe)
                    {
                        tabla.Rows[i]["cantidad"] = ((int)(int.Parse(tabla.Rows[i]["cantidad"].ToString()) + int.Parse(tbCantidadAC.Text))).ToString();
                        tabla.Rows[i]["precioTotal"] = precioUnitario * int.Parse(tabla.Rows[i]["cantidad"].ToString());
                        tabla.Rows[i]["precioTotalConDesc"] = precioUnitario * int.Parse(tabla.Rows[i]["cantidad"].ToString());
                    }
                    else
                    {
                        DataRow newRow = tabla.NewRow();
                        newRow["Código Interno"] = tbCodigoInternoAC.Text;
                        newRow["Código de Barras"] = tbCodigoBarrasAC.Text;
                        newRow["Cantidad"] = tbCantidadAC.Text;
                        newRow["Rubro"] = tbRubroAC.Text;
                        newRow["Sub Rubro"] = tbSubRubroAC.Text;
                        newRow["Descripción"] = tbDescripcionAC.Text;
                        newRow["articuloID"] = tbID.Text;

                        //Verifica si hay que agregar el IVA al articulo

                        string idenIVA = UtilUI.obtenerIdentificadorCombo(ref cbIVA);

                        //El precio ya tiene IVA, si es responsable se le descuenta del precio del articulo
                        /*if (idenIVA == "M" || idenIVA == "F")
                        {
                            precioUnitario = precioUnitario + ((precioUnitario / 100) * decimal.Parse(configuracion.obtenerParametro("IVA1").ToString()));
                            precioUnitario = Decimal.Round(precioUnitario, 2);
                        }*/
                        if (idenIVA != "M" && idenIVA != "F")
                        {
                            decimal iva = decimal.Parse(configuracion.obtenerParametro("IVA1").ToString());
                            decimal coef = (100 + iva) / 100;
                            precioUnitario = precioUnitario / coef;
                            precioUnitario = Decimal.Round(precioUnitario, 2);
                        }
                        newRow["precio"] = precioUnitario;

                        //Agrega el precio con IVA
                        //decimal precioUnitarioIVA = decimal.Parse(tbPrecioIVAAC.Text);
                        decimal precioUnitarioIVA = decimal.Parse(tbPrecioAC.Text); ;
                        precioUnitarioIVA = Decimal.Round(precioUnitarioIVA, 2);

                        newRow["precioUnitarioIVA"] = precioUnitarioIVA;

                        newRow["promocion"] = bool.Parse(tbPromocionAC.Text);
                        newRow["itemNro"] = tabla.Rows.Count + 1;
                        newRow["descuento"] = 0;
                        //newRow["precioTotal"] = decimal.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
                        //newRow["precioTotalConDesc"] = decimal.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
                        newRow["precioTotal"] = precioUnitario * int.Parse(tbCantidadAC.Text);
                        newRow["precioTotalConDesc"] = precioUnitario * int.Parse(tbCantidadAC.Text);
                        tabla.Rows.Add(newRow);
                    }
                    //Limpia los codigos
                    tbCodigoInternoAC.Text = "";
                    tbCodigoBarrasAC.Text = "";
                    tbRubroAC.Text = "";
                    tbSubRubroAC.Text = "";
                    tbDescripcionAC.Text = "";
                    tbID.Text = "";
                    tbPrecioAC.Text = "";
                    //tbPrecioIVAAC.Text = "";
                    tbPromocionAC.Text = "";

                    //Establece el foco en la grilla y muestra el ultimo registro
                    dgSubArticulos.Select();
                    dgSubArticulos.CurrentRowIndex = ((DataTable)dgSubArticulos.DataSource).Rows.Count - 1;

                    //Establece el foco
                    if (controlFocus != null)
                        controlFocus.Select();

                    calcularSubTotales();
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
            tbCantidadAC.Focus();
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

								//Renumera los items
								renumerarItems();

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

		//Renumera los items de la Tabla
		private void renumerarItems()
		{
			try
			{
				DataTable dt = (DataTable)dgSubArticulos.DataSource;

				for (int i=0; i<dt.Rows.Count; i++)
				{
					dt.Rows[i]["itemNro"] = i + 1;
				}
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
							}*/
				if (((DataTable)dgSubArticulos.DataSource).Rows.Count==0)
				{
					mensaje += "   - Debe ingresar al menos un Artículo.\r\n";
					resultado = false;
				}


				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Ingreso de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			//Obtiene los valores a insertar
			/*string proveedorID = "";
			string sucursalOrigenID = "";
			string nroRemito1 = tbNroRemito1.Text;
			string nroRemito2 = tbNroRemito2.Text;
			DateTime fecha = dtpFechaRemito.Value;
			string observaciones = tbObservaciones.Text;
			string usuarioID = "0";  //Modificar
			string sucursalDestinoID = "0"; //Modificar

			string origenID = "";
			if (rbProveedor.Checked)
			{
				origenID = "1"; //Proveedor
				proveedorID = tbProveedorID.Text=="" ? "0" : tbProveedorID.Text;
				sucursalOrigenID = "0";
			}
			if (rbSucursal.Checked)
			{
				origenID = "2"; //Sucursal
				proveedorID = "0";
				sucursalOrigenID = cbSucursal.SelectedValue.ToString();
			}
			if (rbDevolucion.Checked)
			{
				origenID = "3"; //Devolucion
				proveedorID = "0";
				sucursalOrigenID = "0";
			}
			
			SqlParameter[] param = new SqlParameter[9];
			
			param[0] = new SqlParameter("@proveedorID", proveedorID);
			param[1] = new SqlParameter("@sucursalOrigenID", sucursalOrigenID);
			param[2] = new SqlParameter("@nroRemito1", nroRemito1);
			param[3] = new SqlParameter("@nroRemito2", nroRemito2);
			param[4] = new SqlParameter("@usuarioID", usuarioID);
			param[5] = new SqlParameter("@fecha", fecha);
			param[6] = new SqlParameter("@origenID", origenID);
			param[7] = new SqlParameter("@sucursalDestinoID", sucursalDestinoID);
			param[8] = new SqlParameter("@observaciones", observaciones);
			
			while (true)
			{
				try 
				{
					//Inserta el registro y obtiene el ID
					SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoMercaderiaIngresada", param);
					
					//Inserta los articulos
					if (dr.HasRows)
					{
						dr.Read();
						string mercaderiaIngresadaID = dr["ID"].ToString();
						string articuloID = "0";
						string cantidad = "0";

						DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
						for (int i=0; i<dtSubArticulos.Rows.Count; i++)
						{
							cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
							if (cantidad.Trim()!="")
							{
								articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
								param = new SqlParameter[3];
								param[0] = new SqlParameter("@mercaderiaIngresadaID", mercaderiaIngresadaID);
								param[1] = new SqlParameter("@articuloID", articuloID);
								param[2] = new SqlParameter("@cantidad", cantidad);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertMercaderiaIngresadaLinea", param);
							}
						}
					}
					dr.Close();

					MessageBox.Show("Mercadería Ingresada con éxito.", "Ingreso de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Information);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Mercadería Ingresada con éxito.", false);

					//Limpia el formulario
					limpiarFormulario();

					break;
				}
				catch (Exception e)
				{
					DialogResult dr = MessageBox.Show("No se pudo ingresar la Mercadería. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar la Mercadería. \r\n" + e.Message, false);
					if (dr != DialogResult.Retry)
						break;
				}
			}*/
		}

		private void limpiarFormulario()
		{
			try
			{
				tbNotaCreditoID.Text = Utilidades.ID_VACIO;
				((DataTable)dgSubArticulos.DataSource).Rows.Clear();
				tbPromocionAC.Text = "";
				tbPrecioAC.Text = "";
				tbID.Text = "";
				tbCodigoBarrasAC.Text = "";
				tbCodigoInternoAC.Text = "";
				tbCantidadAC.Text = "";
				tbRubroAC.Text = "";
				tbSubRubroAC.Text = "";
				tbDescripcionAC.Text = "";
				lbClienteNombre.Text = "";
				lbDireccion.Text = "";
				lbCUIT.Text = "";
				tabControl1.SelectedIndex = 0;
				lbIVA.Text = "";
				tbFacturaID.Text = Utilidades.ID_VACIO;
				tbFacturaSucursal.Text = "";
				tbFacturaNro.Text = "";

				//butCrearRemitos.Enabled = false;
				butSuspender.Enabled = true;
				butImprimirNota.Enabled = true;
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

		//Calcula el precio de toda la grilla
		private void calcularPreciosTotalesGrilla()
		{
			try
			{
				DataTable dt = (DataTable)dgSubArticulos.DataSource;
                dt.AcceptChanges();
				for (int i=0; i<dt.Rows.Count; i++)
				{
                    
					//Calcula el precio
					dt.Rows[i]["precioTotal"] = double.Parse(dt.Rows[i]["Precio"].ToString()) * int.Parse(dt.Rows[i]["Cantidad"].ToString());

					//Si en descuento no hay un numero, asigna un cero.
					if (!Utilidades.IsNumeric(dt.Rows[i]["descuento"].ToString()))
						dt.Rows[i]["descuento"] = 0;

					//Calcula el descuento //
					double precioTotal = double.Parse(dt.Rows[i]["precioTotal"].ToString());
					double descuento = double.Parse(dt.Rows[i]["descuento"].ToString());
					double precioTotalConDesc = precioTotal - (precioTotal/100*descuento);

					dt.Rows[i]["precioTotalConDesc"] = precioTotalConDesc;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dgSubArticulos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			calcularPreciosTotalesGrilla();
			calcularSubTotales();
		}

		private void butSuspender_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Nota de Crédito...", true);
				if (validarFormularioCabecera())
				{
					guardarNotaCredito("SUSPENDIDA",null);  //Estado 1: suspendida.
				
					//Limpia el formulario para que otro vendedor siga con otra Nota de Crédito
					limpiarFormulario();
				}
				else
					UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Valida el Formulario antes de guardarlo
		private bool validarFormularioCabecera()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;
			
			
				if (tbFacturaID.Text==Utilidades.ID_VACIO)
				{
					mensaje += "   - Indicar una factura existente.\r\n";
					resultado = false;
				}
			
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Guarda la Nota de Crédito con el estado que se le indique.
		private bool guardarNotaCredito(string estado, DocumentoFiscalXML ncx)
		{
			bool resultado = true;
			try
			{
                string notaCreditoSuc = "";
                string notaCreditoNro = "";
                string notaCreditoTipo = "";
                
                //Obtiene el numero de NC
                if (ncx != null)
                {
                    notaCreditoSuc = this.configuracion.sucursal.numero.ToString("0000");
                    notaCreditoNro = ncx.comprobanteNumero.ToString("00000000");
                    notaCreditoTipo = ncx.comprobanteTipo;
                }
				//Obtiene los valores
				DateTime fecha_creacion = DateTime.Now;
                DateTime fecha_vencimiento = fecha_creacion.AddDays(30);
                Guid clienteID = new Guid(tbClienteID.Text);
				string facturaID = tbFacturaID.Text;
				string vendedorID = cbVendedor.SelectedValue.ToString();
				double bonificacion = double.Parse(tbBonificacion.Text);
                string autorizadorBonificacionID = "";
                if (cbAutorizadorBonificacion.SelectedValue != null)
                    autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
				autorizadorBonificacionID = autorizadorBonificacionID=="" ? Utilidades.ID_VACIO : autorizadorBonificacionID;
				double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
				double iva1 = double.Parse(lblIva1.Text, NumberStyles.Currency);
				double iva2 = double.Parse(lblIva2.Text, NumberStyles.Currency);
				double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
				string estadoNotaCredito = estado;
				//Sys maquinaID = configuracion.maquina.id;
				double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
				double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
                Guid jornadaVentaID = this.configuracion.JornadaVentaID;
                Guid sucursalID = this.configuracion.sucursal.id;

				SqlParameter[] param = new SqlParameter[21];
			
				param[0] = new SqlParameter("@fecha_creacion", fecha_creacion);
                param[1] = new SqlParameter("@clienteID", clienteID);
				param[2] = new SqlParameter("@facturaID", new System.Guid(facturaID));
				param[3] = new SqlParameter("@vendedorID", new System.Guid(vendedorID));
				param[4] = new SqlParameter("@bonificacion", bonificacion);
				param[5] = new SqlParameter("@autorizadorBonificacionID", new System.Guid(autorizadorBonificacionID));
				param[6] = new SqlParameter("@subTotal1", subTotal1);
				param[7] = new SqlParameter("@iva1", iva1);
				param[8] = new SqlParameter("@iva2", iva2);
				param[9] = new SqlParameter("@total", total);
				param[10] = new SqlParameter("@estadoNotaCredito", estadoNotaCredito);
				param[11] = new SqlParameter("@maquinaID", configuracion.maquina.id);
				param[12] = new SqlParameter("@subTotal2", subTotal2);
				param[13] = new SqlParameter("@bonificacionImporte", bonificacionImporte);
                param[14] = new SqlParameter("@notaCreditoTipo", notaCreditoTipo);
                param[15] = new SqlParameter("@notaCreditoSuc", notaCreditoSuc);
                param[16] = new SqlParameter("@notaCreditoNumero", notaCreditoNro);
                param[17] = new SqlParameter("@jornadaVentaID", jornadaVentaID);
                param[18] = new SqlParameter("@sucursalID", sucursalID);
                param[19] = new SqlParameter("@estadoCuentaCorriente", "PENDIENTE");
                param[20] = new SqlParameter("@fecha_vencimiento", fecha_vencimiento);

				while (true)
				{
					try 
					{
						//Inserta el registro y obtiene el ID
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevaNotaCredito", param);
					
						//Inserta los articulos
						if (dr.HasRows)
						{
							dr.Read();
							string notaCreditoID = dr["ID"].ToString();
							tbNotaCreditoID.Text = notaCreditoID.ToString();

							string articuloID = Utilidades.ID_VACIO;
							string cantidad = "0";
							int itemNro = 0;
							double precioTotal = 0;
							double precioUnitario = 0;

							DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
							for (int i=0; i<dtSubArticulos.Rows.Count; i++)
							{
								cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
								if (cantidad.Trim()!="")
								{
									articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
									itemNro = int.Parse(dtSubArticulos.Rows[i]["itemNro"].ToString());
									precioTotal = double.Parse(dtSubArticulos.Rows[i]["precioTotal"].ToString());
									precioUnitario = double.Parse(dtSubArticulos.Rows[i]["precio"].ToString());
									param = new SqlParameter[6];
									param[0] = new SqlParameter("@notaCreditoID", new System.Guid(notaCreditoID));
									param[1] = new SqlParameter("@cantidad", cantidad);
									param[2] = new SqlParameter("@articuloID", new System.Guid(articuloID));
									param[3] = new SqlParameter("@itemNro", itemNro);
									param[4] = new SqlParameter("@precioTotal", precioTotal);
									param[5] = new SqlParameter("@precioUnitario", precioUnitario);
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertNotaCreditoLinea", param);
								}
							}

                            //Siempre aumenta el Stock.
                            ControlStock cs = new ControlStock(this.configuracion);
                            cs.aumentarExistencia(dtSubArticulos, "articuloID", "cantidad");
                            cs = null;
						}

						MessageBox.Show("Nota de Crédito Nro.: " + dr["notaCreditoSuc"].ToString() + "-" + dr["notaCreditoNro"].ToString() + " guardada con éxito.", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Crédito guardada con éxito.", false);

						dr.Close();

                 

						//Limpia el formulario
						//limpiarFormulario();

						break;
					}
					catch (Exception e)
					{
						resultado = false;
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo guardar la Nota de Crédito. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Nota de Crédito. \r\n" + e.Message, false);
						if (dr != DialogResult.Retry)
							break;
					}
				}
				resultado = true;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				resultado = false;
			}
			return resultado;
		}

		//Calcula los subtotales
		private void calcularSubTotales()
		{
			try
			{
				if (((DataTable)dgSubArticulos.DataSource).Rows.Count>0)
				{
					//Subtotal 1
					decimal subTotal1 = (decimal)((DataTable)dgSubArticulos.DataSource).Compute("Sum(precioTotal)","");
					lblSubTotal1.Text = subTotal1.ToString("C");

					//Bonificacion
					decimal bonificacionPorc = decimal.Parse(tbBonificacion.Text);
					decimal bonificacionImp = subTotal1/100*bonificacionPorc;
					lblBonificacion.Text = bonificacionImp.ToString("C");

					//Subtotal 2
					decimal subTotal2 = subTotal1-bonificacionImp;
					lblSubTotal2.Text = subTotal2.ToString("C");

					//Iva 1
					//decimal iva1Porc = configuracion.parametros
					decimal iva1Imp = 0;
					//Iva 2
					//decimal iva2Porc = configuracion.parametros
					decimal iva2Imp = 0;

					//Total general
					decimal total = subTotal2 + iva1Imp + iva2Imp;
					lblTotal.Text = total.ToString("C");
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbBonificacion_Enter(object sender, System.EventArgs e)
		{
			tbBonificacion.SelectAll();
		}

		private void tbBonificacion_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tbBonificacion.SelectAll();
		}

		private void tbBonificacion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				TextBox tb = (TextBox)sender;
				if (!Utilidades.IsNumeric(tb.Text))
				{
					MessageBox.Show("Debe ingresar un valor numérico para la Bonificación.", "Bonificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Cancel = true;
				}
				else
					calcularSubTotales();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbCantidadAC_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void butCrearRemitos_Click(object sender, System.EventArgs e)
		{/*
			frmRemitoAlta frmRemit = new frmRemitoAlta(this.configuracion);
			frmRemit.statusBar1 = this.statusBarPrincipal;
			frmRemit.toolBar2 = null; 
			frmRemit.Show();
			frmRemit.ucRemitoAlta1.buscarNotaPedido(tbNotaPedidoID.Text);*/
		}

		private void butImprimirNota_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (DialogResult.OK == MessageBox.Show("Está a punto de imprimir la Nota de Crédito.\r\n\r\nPor favor, prepare la impresora.", "Imprimir Nota de Crédito", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    if (validarFormularioCabecera() && validarFormulario())
                    {
                        //Luego la imprime
                        if (imprimirNotaCredito(tbNotaCreditoID.Text))
                        {
                            //butCrearRemitos.Enabled = true;
                            butSuspender.Enabled = false;
                            butImprimirNota.Enabled = false;
                            limpiarFormulario();
                        }
                    }
                }
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}

		}

		//Imprime la Nota de Credito
		private bool imprimirNotaCredito(string notaPedidoID)
		{
			bool res1=false, res2=true;
			DocumentoFiscalXML nc = generarImpresionXML();   
			if (nc!=null)
				if (nc.mensajeServidor=="")
				{
					res1 = guardarNotaCredito("IMPRESA",nc);  //Guarda con el Estado 1: Facturada.
					//res2 = guardarFactura(fx);
				}
				else
				{
					MessageBox.Show(nc.mensajeServidor, "Error de impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			else
				MessageBox.Show("No se pudo generar el objeto FacturaXML.", "Error de impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);

			return (res1 && res2);
		}

		//Genera un objeto FacturaXML para enviarlo
		private DocumentoFiscalXML generarImpresionXML()
		{
			try
			{
				DocumentoFiscalXML nc = new DocumentoFiscalXML(this.configuracion);
				
				nc.documentoNombre = "NC";
				nc.nombreCliente = lbClienteNombre.Text;
				nc.direccionCliente = lbDireccion.Text;
				nc.ivaCliente = cbIVA.Text;
				nc.cuitCliente = lbCUIT.Text;
				nc.vendedor = cbVendedor.Text;
                nc.comprobanteOrigenNro = tbFacturaSucursal.Text + "-" + tbFacturaNro.Text;
				
				if (UtilUI.obtenerIdentificadorCombo(ref cbIVA)=="I")
				{
					nc.comprobanteTipo = "A";
					nc.comprobanteCopias = 3;
				}
				else
				{
					nc.comprobanteTipo = "B";  
					nc.comprobanteCopias = 2; 
				}

				//Toma el identificador del iva
				DataTable dtIva = (DataTable)cbIVA.DataSource;
				nc.ivaIdentificador = dtIva.Rows[cbIVA.SelectedIndex]["identificador"].ToString();

				nc.items = (DataTable)dgSubArticulos.DataSource;
				nc.bonifPorcentaje = double.Parse(tbBonificacion.Text);
				nc.autorizadorBonificacion = cbAutorizadorBonificacion.Text;
				nc.bonifImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);

                //Sale la impresion por el controlador C1
                nc.plazoPago = "CONTADO";

                //Aqui debe esperar la respuesta del servidor.
                if (nc.enviarPaquete() == "")   //Imprime el formulario.
                    nc.recibirRespuesta();
				
				return nc;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}


		private void butNuevaNotaCredito_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		private void butSiguiente_Click(object sender, System.EventArgs e)
		{
			tabControl1.SelectedIndex = 1;
			tbCodigoInternoAC.Select();
		}

		private void tbFacturaSucursal_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				tbFacturaNro.Select();
			}
		}

		private void tbFacturaSucursal_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string facturaSuc = tbFacturaSucursal.Text;
				Utilidades.agregarCerosIzquierda(ref facturaSuc,4);
				tbFacturaSucursal.Text = facturaSuc;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbFacturaNro_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string facturaNro = tbFacturaNro.Text;
				Utilidades.agregarCerosIzquierda(ref facturaNro,8);
				tbFacturaNro.Text = facturaNro;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbFacturaNro_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				butSiguiente.Select();
				buscarFactura();
			}
		}

		private void butBuscarFactura_Click(object sender, System.EventArgs e)
		{
			buscarFactura();
		}

		private void buscarFactura()
		{
			try
			{
				SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@facturaTipo", cbTipoFactura.Text);
                param[1] = new SqlParameter("@facturaSuc", tbFacturaSucursal.Text);
				param[2] = new SqlParameter("@facturaNro", tbFacturaNro.Text);
                
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getFacturaByNumero", param);

				string facturaID = Utilidades.ID_VACIO;
                string clienteID = Utilidades.ID_VACIO;
				string clienteNombre = "";
				string iva = "";
				string direccion = "";
				string cuit = "";
				System.Guid ivaID = Guid.NewGuid();
				if (dr.HasRows)
				{
					dr.Read();
					facturaID = dr["id"].ToString();
					clienteNombre = dr["Razón Social"].ToString();
					iva = dr["IVA"].ToString();
					direccion = dr["Dirección Cliente"].ToString();
					cuit = dr["CUIT"].ToString();
					ivaID = new Guid(dr["ivaIDCliente"].ToString());
                    clienteID = dr["clienteID"].ToString();

                    Control con = tabControl1;
                    //Carga la grilla con los items
                    utilNotaCredito.buscarFactura(this.configuracion, facturaID, ref con);
				}
				dr.Close();

				tbFacturaID.Text = facturaID;
                if (clienteID!="")
                    tbClienteID.Text = clienteID;
				lbClienteNombre.Text = clienteNombre;
				lbIVA.Text = iva;
				lbDireccion.Text = direccion;
				lbCUIT.Text = cuit;
				cbIVA.SelectedValue = ivaID;

			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

        private void butBuscarConcepto_Click(object sender, EventArgs e)
        {
            utilNotaCredito.buscarConcepto(this.configuracion, ref tabControl1);
        }

        private void dgSubArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                e.Handled = true;
        }

        private void dgSubArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
                e.Handled = true;
        }

        private void dgSubArticulos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                
            }
                
        }

        private void dgSubArticulos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                e.SuppressKeyPress = true;
        }

        private void dgSubArticulos_DoubleClick(object sender, EventArgs e)
        {
            Inputbox.Show("Titulo", "Mensaje", FormStartPosition.CenterScreen);
        }

        //Carga el Navegador de Formularios
        private void cargarNavegadorFormulario()
        {
            /*************************************
             * Navegador de la Solapa Cabecera
             * ***********************************/
            //Carga las teclas rapidas primero
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscarConcepto, 0, (char)Keys.F1));
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butSiguiente, 1, (char)Keys.F3));

            //Carga los controles
            navegador.agregarControl(new CapsulaControl((Control)cbVendedor, 0));
            navegador.agregarControl(new CapsulaControl((Control)cbTipoFactura, 1));
            navegador.agregarControl(new CapsulaControl((Control)tbFacturaSucursal, 2));
            navegador.agregarControl(new CapsulaControl((Control)tbFacturaNro, 3));
            navegador.agregarControl(new CapsulaControl((Control)butBuscarFactura, 4));
            navegador.agregarControl(new CapsulaControl((Control)butSiguiente, 5));

            //Agrega los handlers para todos los controles del control contenedor
            navegador.agregarHandlersContenedor(tabControl1.TabPages[0]);


            /*************************************
             * Navegador de la Solapa Items
             * ***********************************/
            //Carga las teclas rapidas primero
            navegadorItems.agregarControlTeclaRapida(new CapsulaControl((Control)butImprimirNota, 0, (char)Keys.F7));
            navegadorItems.agregarControlTeclaRapida(new CapsulaControl((Control)butNuevaNotaCredito, 1, (char)Keys.F10));
            navegadorItems.agregarControlTeclaRapida(new CapsulaControl((Control)butCancelar, 2, (char)Keys.F12));

            //Carga los controles
            //navegadorItems.agregarControl(new CapsulaControl((Control)butBonificacion, 0));
            navegadorItems.agregarControl(new CapsulaControl((Control)tbBonificacion, 0));
            navegadorItems.agregarControl(new CapsulaControl((Control)cbAutorizadorBonificacion, 1));
            //navegadorItems.agregarControl(new CapsulaControl((Control)lblBonificacion, 3));
            navegadorItems.agregarControl(new CapsulaControl((Control)butImprimirNota, 2));
            navegadorItems.agregarControl(new CapsulaControl((Control)butNuevaNotaCredito, 3));

            //Agrega los handlers para todos los controles del control contenedor
            navegadorItems.agregarHandlersContenedor(tabControl1.TabPages[1]);

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

        private void tbCodigoInternoAC_TextChanged(object sender, EventArgs e)
        {

        }

        private void DatosIngresoArticulos_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode==Keys.F1)
				butBuscarArticuloAC_Click(sender, e);
			//else if (e.KeyCode==Keys.F2)
				//butNuevoArticulo_Click(sender, e);

			
		}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                cbTipoFactura.Select();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                tbCodigoInternoAC.Select();
            }
        }

	}
}