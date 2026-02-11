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
	/// Summary description for ucMercaderiaIngreso.
	/// </summary>
	public class ucReciboAlta : System.Windows.Forms.UserControl
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
		private System.Windows.Forms.GroupBox gbConceptos;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button butBorrarArticulosComponentes;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbClienteNombre;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCUIT;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butBuscarCliente;
		private System.Windows.Forms.TextBox tbDireccion;
		private System.Windows.Forms.ComboBox cbIVA;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbClienteID;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblSubTotal2;
		private System.Windows.Forms.Label lblBonificacion;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblSubTotal1;
		private System.Windows.Forms.ComboBox cbAutorizadorBonificacion;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblBonifica;
		private System.Windows.Forms.TextBox tbBonificacion;
		private System.Windows.Forms.Button butCancelar;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.ComboBox cbCtadoCtaCte;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button butBorrarPagos;
		private System.Windows.Forms.DataGrid dgPagos;
		private System.Windows.Forms.Label lblTotalFacturado;
		private System.Windows.Forms.Label lblSaldoPagos;
		private System.Windows.Forms.Label lblTotalPagos;
		private System.Windows.Forms.ComboBox cbTipoPagoDetalle;
		private System.Windows.Forms.ComboBox cbTipoPago;
		private System.Windows.Forms.GroupBox gbContado;
		private System.Windows.Forms.Label lblPesos;
		private System.Windows.Forms.Label lblAjusteEtiqueta;
		private KMCurrencyTextBox.KMCurrencyTextBox tbImportePago;
		private KMCurrencyTextBox.KMCurrencyTextBox tbPesos;
		private System.Windows.Forms.Button butAgregarPago;
		private KMCurrencyTextBox.KMCurrencyTextBox lblAjusteValor;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.Label lblAdicional;
		private System.Windows.Forms.TextBox tbAdicional;
		private System.Windows.Forms.ComboBox cbAdicional;
		private System.Windows.Forms.Label lblTotalConInteresE;
		private System.Windows.Forms.Label lblInteresValE;
		private System.Windows.Forms.Label lblTotalConInteresV;
		private System.Windows.Forms.Label lblInteresValV;
		private System.Windows.Forms.Label lblInteresPorE;
		private System.Windows.Forms.Label lblInteresPorV;
		private System.Windows.Forms.Button butSuspender2;
		private System.Windows.Forms.Button butCancelar2;
		private System.Windows.Forms.Button butContinuar2;
		private System.Windows.Forms.TextBox tbFormaPagoID;
		private System.Windows.Forms.TextBox tbNroAC;
		private System.Windows.Forms.ComboBox cbConceptoAC;
		private System.Windows.Forms.TextBox tbNroSucAC;
		private System.Windows.Forms.TextBox tbDescripcionAC;
		private KMCurrencyTextBox.KMCurrencyTextBox tbImporteAC;
		private System.Windows.Forms.TextBox tbFacturaID;
		private System.Windows.Forms.Label lblNro;
		private System.Windows.Forms.Button butAgregarConcepto;
		private System.Windows.Forms.TextBox tbNotaDebitoID;
		private System.Windows.Forms.Label lblGuion;
		private System.Windows.Forms.DataGridTableStyle dgtsReciboLinea;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		public DataSet datasetReciboLinea = (DataSet) new dsReciboLinea();
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGrid dgReciboLinea;
		private System.Windows.Forms.Button butSuspender;
		private System.Windows.Forms.Button butImprimirRecibo;
		private System.Windows.Forms.Button butNuevoRecibo;
		private System.Windows.Forms.TextBox tbReciboID;
        private Button butBuscarConcepto;
        private ComboBox cbTipoComprobante;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private TextBox tbNotaCreditoID;
        private Button butBuscarNC;
		public DataSet datasetFormaPagoLineas = (DataSet) new dsFormaPagoLinea();
        public NavegadorFormulario navegador;
        public NavegadorFormulario navegadorConceptos;
        public NavegadorFormulario navegadorFormasPago;

		public ucReciboAlta()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            navegador = new NavegadorFormulario(this.configuracion);
            navegadorConceptos = new NavegadorFormulario(this.configuracion);
            navegadorFormasPago = new NavegadorFormulario(this.configuracion);


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReciboAlta));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbReciboID = new System.Windows.Forms.TextBox();
            this.tbClienteID = new System.Windows.Forms.TextBox();
            this.cbIVA = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCUIT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butBuscarCliente = new System.Windows.Forms.Button();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClienteNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butBorrarArticulosComponentes = new System.Windows.Forms.Button();
            this.dgReciboLinea = new System.Windows.Forms.DataGrid();
            this.dgtsReciboLinea = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butSuspender = new System.Windows.Forms.Button();
            this.butContinuar2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSubTotal2 = new System.Windows.Forms.Label();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSubTotal1 = new System.Windows.Forms.Label();
            this.cbAutorizadorBonificacion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBonifica = new System.Windows.Forms.Label();
            this.tbBonificacion = new System.Windows.Forms.TextBox();
            this.butCancelar = new System.Windows.Forms.Button();
            this.gbConceptos = new System.Windows.Forms.GroupBox();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.butBuscarConcepto = new System.Windows.Forms.Button();
            this.lblGuion = new System.Windows.Forms.Label();
            this.butAgregarConcepto = new System.Windows.Forms.Button();
            this.tbImporteAC = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.tbDescripcionAC = new System.Windows.Forms.TextBox();
            this.tbNroSucAC = new System.Windows.Forms.TextBox();
            this.cbConceptoAC = new System.Windows.Forms.ComboBox();
            this.tbNotaDebitoID = new System.Windows.Forms.TextBox();
            this.tbNroAC = new System.Windows.Forms.TextBox();
            this.tbFacturaID = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblNro = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.butBorrarPagos = new System.Windows.Forms.Button();
            this.dgPagos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblInteresPorE = new System.Windows.Forms.Label();
            this.cbCtadoCtaCte = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblInteresPorV = new System.Windows.Forms.Label();
            this.lblTotalConInteresE = new System.Windows.Forms.Label();
            this.lblInteresValE = new System.Windows.Forms.Label();
            this.lblTotalConInteresV = new System.Windows.Forms.Label();
            this.lblInteresValV = new System.Windows.Forms.Label();
            this.butNuevoRecibo = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblTotalFacturado = new System.Windows.Forms.Label();
            this.lblSaldoPagos = new System.Windows.Forms.Label();
            this.lblTotalPagos = new System.Windows.Forms.Label();
            this.butImprimirRecibo = new System.Windows.Forms.Button();
            this.butSuspender2 = new System.Windows.Forms.Button();
            this.butCancelar2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbContado = new System.Windows.Forms.GroupBox();
            this.butBuscarNC = new System.Windows.Forms.Button();
            this.tbNotaCreditoID = new System.Windows.Forms.TextBox();
            this.cbAdicional = new System.Windows.Forms.ComboBox();
            this.tbAdicional = new System.Windows.Forms.TextBox();
            this.lblAdicional = new System.Windows.Forms.Label();
            this.lblAjusteValor = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.butAgregarPago = new System.Windows.Forms.Button();
            this.tbPesos = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.lblAjusteEtiqueta = new System.Windows.Forms.Label();
            this.lblPesos = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cbTipoPagoDetalle = new System.Windows.Forms.ComboBox();
            this.cbTipoPago = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbImportePago = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.tbFormaPagoID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReciboLinea)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbConceptos.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbContado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGreen;
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
            this.label18.BackColor = System.Drawing.Color.LightGreen;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkGreen;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(800, 32);
            this.label18.TabIndex = 114;
            this.label18.Text = "     Recibo";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.butSiguiente);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cabecera";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbReciboID);
            this.groupBox2.Controls.Add(this.tbClienteID);
            this.groupBox2.Controls.Add(this.cbIVA);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbCUIT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.butBuscarCliente);
            this.groupBox2.Controls.Add(this.tbDireccion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbClienteNombre);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 104);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // tbReciboID
            // 
            this.tbReciboID.Location = new System.Drawing.Point(704, 40);
            this.tbReciboID.Name = "tbReciboID";
            this.tbReciboID.Size = new System.Drawing.Size(24, 20);
            this.tbReciboID.TabIndex = 13;
            this.tbReciboID.Text = "0";
            this.tbReciboID.Visible = false;
            // 
            // tbClienteID
            // 
            this.tbClienteID.Location = new System.Drawing.Point(704, 16);
            this.tbClienteID.Name = "tbClienteID";
            this.tbClienteID.Size = new System.Drawing.Size(24, 20);
            this.tbClienteID.TabIndex = 12;
            this.tbClienteID.Text = "0";
            this.tbClienteID.Visible = false;
            // 
            // cbIVA
            // 
            this.cbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIVA.Enabled = false;
            this.cbIVA.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbIVA.Location = new System.Drawing.Point(240, 32);
            this.cbIVA.Name = "cbIVA";
            this.cbIVA.Size = new System.Drawing.Size(208, 21);
            this.cbIVA.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(240, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "IVA";
            // 
            // tbCUIT
            // 
            this.tbCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCUIT.Location = new System.Drawing.Point(240, 72);
            this.tbCUIT.Name = "tbCUIT";
            this.tbCUIT.ReadOnly = true;
            this.tbCUIT.Size = new System.Drawing.Size(208, 20);
            this.tbCUIT.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(240, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "CUIT";
            // 
            // butBuscarCliente
            // 
            this.butBuscarCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarCliente.Image")));
            this.butBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarCliente.Location = new System.Drawing.Point(496, 48);
            this.butBuscarCliente.Name = "butBuscarCliente";
            this.butBuscarCliente.Size = new System.Drawing.Size(135, 24);
            this.butBuscarCliente.TabIndex = 6;
            this.butBuscarCliente.Text = "F1 - Buscar Cliente";
            this.butBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarCliente.UseVisualStyleBackColor = false;
            this.butBuscarCliente.Click += new System.EventHandler(this.butBuscarCliente_Click);
            // 
            // tbDireccion
            // 
            this.tbDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccion.Location = new System.Drawing.Point(8, 72);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.ReadOnly = true;
            this.tbDireccion.Size = new System.Drawing.Size(208, 20);
            this.tbDireccion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dirección";
            // 
            // tbClienteNombre
            // 
            this.tbClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClienteNombre.Location = new System.Drawing.Point(8, 32);
            this.tbClienteNombre.Name = "tbClienteNombre";
            this.tbClienteNombre.ReadOnly = true;
            this.tbClienteNombre.Size = new System.Drawing.Size(208, 20);
            this.tbClienteNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre / Razón Social";
            // 
            // butSiguiente
            // 
            this.butSiguiente.BackColor = System.Drawing.SystemColors.Control;
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(496, 216);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(135, 24);
            this.butSiguiente.TabIndex = 158;
            this.butSiguiente.Text = "F3 - Continuar";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSiguiente.UseVisualStyleBackColor = false;
            this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butBorrarArticulosComponentes);
            this.tabPage2.Controls.Add(this.dgReciboLinea);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.gbConceptos);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Conceptos";
            this.tabPage2.Visible = false;
            // 
            // butBorrarArticulosComponentes
            // 
            this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
            this.butBorrarArticulosComponentes.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarArticulosComponentes.Image")));
            this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(224, 92);
            this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
            this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
            this.butBorrarArticulosComponentes.TabIndex = 155;
            this.butBorrarArticulosComponentes.Text = "&Borrar";
            this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarArticulosComponentes.UseVisualStyleBackColor = false;
            this.butBorrarArticulosComponentes.Click += new System.EventHandler(this.butBorrarArticulosComponentes_Click);
            // 
            // dgReciboLinea
            // 
            this.dgReciboLinea.CaptionBackColor = System.Drawing.Color.DarkGreen;
            this.dgReciboLinea.CaptionForeColor = System.Drawing.Color.White;
            this.dgReciboLinea.CaptionText = "Conceptos";
            this.dgReciboLinea.DataMember = "";
            this.dgReciboLinea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReciboLinea.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgReciboLinea.Location = new System.Drawing.Point(0, 91);
            this.dgReciboLinea.Name = "dgReciboLinea";
            this.dgReciboLinea.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgReciboLinea.Size = new System.Drawing.Size(792, 195);
            this.dgReciboLinea.TabIndex = 157;
            this.dgReciboLinea.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsReciboLinea});
            this.dgReciboLinea.CurrentCellChanged += new System.EventHandler(this.dgRemitoLinea_CurrentCellChanged);
            // 
            // dgtsReciboLinea
            // 
            this.dgtsReciboLinea.AllowSorting = false;
            this.dgtsReciboLinea.AlternatingBackColor = System.Drawing.Color.LightYellow;
            this.dgtsReciboLinea.DataGrid = this.dgReciboLinea;
            this.dgtsReciboLinea.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19});
            this.dgtsReciboLinea.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsReciboLinea.MappingName = "v_ReciboLinea";
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "Concepto";
            this.dataGridTextBoxColumn17.MappingName = "Concepto";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 140;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Tipo";
            this.dataGridTextBoxColumn3.MappingName = "tipoComprobante";
            this.dataGridTextBoxColumn3.Width = 30;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Nro.";
            this.dataGridTextBoxColumn1.MappingName = "comprobanteSuc";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Comprobante";
            this.dataGridTextBoxColumn2.MappingName = "comprobanteNro";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "Descripción";
            this.dataGridTextBoxColumn18.MappingName = "descripcion";
            this.dataGridTextBoxColumn18.Width = 300;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn19.Format = "C";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "Importe   .";
            this.dataGridTextBoxColumn19.MappingName = "importe";
            this.dataGridTextBoxColumn19.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butSuspender);
            this.groupBox1.Controls.Add(this.butContinuar2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblSubTotal2);
            this.groupBox1.Controls.Add(this.lblBonificacion);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblSubTotal1);
            this.groupBox1.Controls.Add(this.cbAutorizadorBonificacion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblBonifica);
            this.groupBox1.Controls.Add(this.tbBonificacion);
            this.groupBox1.Controls.Add(this.butCancelar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 112);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            // 
            // butSuspender
            // 
            this.butSuspender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender.Image")));
            this.butSuspender.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSuspender.Location = new System.Drawing.Point(8, 48);
            this.butSuspender.Name = "butSuspender";
            this.butSuspender.Size = new System.Drawing.Size(120, 24);
            this.butSuspender.TabIndex = 158;
            this.butSuspender.Text = "F5 - Suspender";
            this.butSuspender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender.Visible = false;
            this.butSuspender.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // butContinuar2
            // 
            this.butContinuar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butContinuar2.Image = ((System.Drawing.Image)(resources.GetObject("butContinuar2.Image")));
            this.butContinuar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinuar2.Location = new System.Drawing.Point(184, 80);
            this.butContinuar2.Name = "butContinuar2";
            this.butContinuar2.Size = new System.Drawing.Size(144, 23);
            this.butContinuar2.TabIndex = 157;
            this.butContinuar2.Text = "F3 - Continuar";
            this.butContinuar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butContinuar2.Click += new System.EventHandler(this.butContinuar2_Click);
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
            this.cbAutorizadorBonificacion.Location = new System.Drawing.Point(184, 16);
            this.cbAutorizadorBonificacion.Name = "cbAutorizadorBonificacion";
            this.cbAutorizadorBonificacion.Size = new System.Drawing.Size(144, 21);
            this.cbAutorizadorBonificacion.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(136, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 24);
            this.label8.TabIndex = 34;
            this.label8.Text = "Autoriza";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBonifica
            // 
            this.lblBonifica.Location = new System.Drawing.Point(8, 16);
            this.lblBonifica.Name = "lblBonifica";
            this.lblBonifica.Size = new System.Drawing.Size(80, 24);
            this.lblBonifica.TabIndex = 33;
            this.lblBonifica.Text = "Bonificación %";
            this.lblBonifica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBonificacion
            // 
            this.tbBonificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBonificacion.Location = new System.Drawing.Point(88, 16);
            this.tbBonificacion.Name = "tbBonificacion";
            this.tbBonificacion.Size = new System.Drawing.Size(40, 20);
            this.tbBonificacion.TabIndex = 32;
            this.tbBonificacion.Text = "0";
            this.tbBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBonificacion.Enter += new System.EventHandler(this.tbBonificacion_Enter);
            this.tbBonificacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbBonificacion_MouseDown);
            this.tbBonificacion.Validating += new System.ComponentModel.CancelEventHandler(this.tbBonificacion_Validating);
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar.Location = new System.Drawing.Point(8, 80);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(120, 24);
            this.butCancelar.TabIndex = 29;
            this.butCancelar.Text = "F12 - Cancelar";
            this.butCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // gbConceptos
            // 
            this.gbConceptos.Controls.Add(this.cbTipoComprobante);
            this.gbConceptos.Controls.Add(this.butBuscarConcepto);
            this.gbConceptos.Controls.Add(this.lblGuion);
            this.gbConceptos.Controls.Add(this.butAgregarConcepto);
            this.gbConceptos.Controls.Add(this.tbImporteAC);
            this.gbConceptos.Controls.Add(this.tbDescripcionAC);
            this.gbConceptos.Controls.Add(this.tbNroSucAC);
            this.gbConceptos.Controls.Add(this.cbConceptoAC);
            this.gbConceptos.Controls.Add(this.tbNotaDebitoID);
            this.gbConceptos.Controls.Add(this.tbNroAC);
            this.gbConceptos.Controls.Add(this.tbFacturaID);
            this.gbConceptos.Controls.Add(this.label23);
            this.gbConceptos.Controls.Add(this.label27);
            this.gbConceptos.Controls.Add(this.label20);
            this.gbConceptos.Controls.Add(this.lblNro);
            this.gbConceptos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConceptos.Location = new System.Drawing.Point(0, 0);
            this.gbConceptos.Name = "gbConceptos";
            this.gbConceptos.Size = new System.Drawing.Size(792, 91);
            this.gbConceptos.TabIndex = 153;
            this.gbConceptos.TabStop = false;
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoComprobante.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cbTipoComprobante.Location = new System.Drawing.Point(146, 32);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(35, 21);
            this.cbTipoComprobante.TabIndex = 161;
            // 
            // butBuscarConcepto
            // 
            this.butBuscarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarConcepto.Image")));
            this.butBuscarConcepto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarConcepto.Location = new System.Drawing.Point(8, 59);
            this.butBuscarConcepto.Name = "butBuscarConcepto";
            this.butBuscarConcepto.Size = new System.Drawing.Size(132, 25);
            this.butBuscarConcepto.TabIndex = 158;
            this.butBuscarConcepto.Text = "F1 - Buscar Concepto";
            this.butBuscarConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarConcepto.Click += new System.EventHandler(this.butBuscarConcepto_Click);
            // 
            // lblGuion
            // 
            this.lblGuion.Location = new System.Drawing.Point(216, 32);
            this.lblGuion.Name = "lblGuion";
            this.lblGuion.Size = new System.Drawing.Size(8, 16);
            this.lblGuion.TabIndex = 157;
            this.lblGuion.Text = "-";
            // 
            // butAgregarConcepto
            // 
            this.butAgregarConcepto.BackColor = System.Drawing.Color.Gainsboro;
            this.butAgregarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAgregarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarConcepto.Image")));
            this.butAgregarConcepto.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butAgregarConcepto.Location = new System.Drawing.Point(624, 16);
            this.butAgregarConcepto.Name = "butAgregarConcepto";
            this.butAgregarConcepto.Size = new System.Drawing.Size(56, 40);
            this.butAgregarConcepto.TabIndex = 156;
            this.butAgregarConcepto.Text = "Agregar";
            this.butAgregarConcepto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butAgregarConcepto.UseVisualStyleBackColor = false;
            this.butAgregarConcepto.Click += new System.EventHandler(this.butAgregarConcepto_Click);
            // 
            // tbImporteAC
            // 
            this.tbImporteAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImporteAC.CurrencyDecimalSeparator = ",";
            this.tbImporteAC.CurrencyGroupSeparator = ".";
            this.tbImporteAC.CurrencySymbol = "$";
            this.tbImporteAC.DecimalsDigits = 2;
            this.tbImporteAC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbImporteAC.Location = new System.Drawing.Point(544, 32);
            this.tbImporteAC.Name = "tbImporteAC";
            this.tbImporteAC.Size = new System.Drawing.Size(64, 20);
            this.tbImporteAC.TabIndex = 155;
            this.tbImporteAC.Text = "$ 0,00";
            this.tbImporteAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbImporteAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbImporteAC_KeyPress);
            // 
            // tbDescripcionAC
            // 
            this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcionAC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbDescripcionAC.Location = new System.Drawing.Point(315, 32);
            this.tbDescripcionAC.Name = "tbDescripcionAC";
            this.tbDescripcionAC.Size = new System.Drawing.Size(221, 20);
            this.tbDescripcionAC.TabIndex = 154;
            this.tbDescripcionAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDescripcionAC_KeyPress);
            // 
            // tbNroSucAC
            // 
            this.tbNroSucAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroSucAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroSucAC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbNroSucAC.Location = new System.Drawing.Point(184, 32);
            this.tbNroSucAC.Name = "tbNroSucAC";
            this.tbNroSucAC.Size = new System.Drawing.Size(32, 20);
            this.tbNroSucAC.TabIndex = 152;
            this.tbNroSucAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNroSucAC.Enter += new System.EventHandler(this.tbNroSucAC_Enter);
            this.tbNroSucAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroSucAC_KeyPress);
            this.tbNroSucAC.Validated += new System.EventHandler(this.tbNroSucAC_Validated);
            // 
            // cbConceptoAC
            // 
            this.cbConceptoAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConceptoAC.Location = new System.Drawing.Point(8, 32);
            this.cbConceptoAC.Name = "cbConceptoAC";
            this.cbConceptoAC.Size = new System.Drawing.Size(132, 21);
            this.cbConceptoAC.TabIndex = 151;
            this.cbConceptoAC.SelectedIndexChanged += new System.EventHandler(this.cbConceptoAC_SelectedIndexChanged);
            // 
            // tbNotaDebitoID
            // 
            this.tbNotaDebitoID.Location = new System.Drawing.Point(704, 8);
            this.tbNotaDebitoID.Name = "tbNotaDebitoID";
            this.tbNotaDebitoID.Size = new System.Drawing.Size(16, 20);
            this.tbNotaDebitoID.TabIndex = 150;
            this.tbNotaDebitoID.Visible = false;
            // 
            // tbNroAC
            // 
            this.tbNroAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroAC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbNroAC.Location = new System.Drawing.Point(224, 32);
            this.tbNroAC.Name = "tbNroAC";
            this.tbNroAC.Size = new System.Drawing.Size(88, 20);
            this.tbNroAC.TabIndex = 153;
            this.tbNroAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNroAC.Enter += new System.EventHandler(this.tbNroAC_Enter);
            this.tbNroAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroAC_KeyPress);
            this.tbNroAC.Validated += new System.EventHandler(this.tbNroAC_Validated);
            // 
            // tbFacturaID
            // 
            this.tbFacturaID.Location = new System.Drawing.Point(688, 8);
            this.tbFacturaID.Name = "tbFacturaID";
            this.tbFacturaID.Size = new System.Drawing.Size(16, 20);
            this.tbFacturaID.TabIndex = 147;
            this.tbFacturaID.Visible = false;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(544, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 16);
            this.label23.TabIndex = 140;
            this.label23.Text = "Importe";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(312, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 16);
            this.label27.TabIndex = 143;
            this.label27.Text = "Descripción";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 16);
            this.label20.TabIndex = 138;
            this.label20.Text = "Concepto";
            // 
            // lblNro
            // 
            this.lblNro.Location = new System.Drawing.Point(146, 16);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(166, 16);
            this.lblNro.TabIndex = 139;
            this.lblNro.Text = "Nro. Comprobante";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.butBorrarPagos);
            this.tabPage3.Controls.Add(this.dgPagos);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 398);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Formas de Pago";
            // 
            // butBorrarPagos
            // 
            this.butBorrarPagos.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarPagos.ForeColor = System.Drawing.Color.White;
            this.butBorrarPagos.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarPagos.Image")));
            this.butBorrarPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarPagos.Location = new System.Drawing.Point(208, 88);
            this.butBorrarPagos.Name = "butBorrarPagos";
            this.butBorrarPagos.Size = new System.Drawing.Size(64, 20);
            this.butBorrarPagos.TabIndex = 159;
            this.butBorrarPagos.Text = "&Borrar";
            this.butBorrarPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarPagos.UseVisualStyleBackColor = false;
            this.butBorrarPagos.Click += new System.EventHandler(this.butBorrarPagos_Click);
            // 
            // dgPagos
            // 
            this.dgPagos.CaptionBackColor = System.Drawing.Color.LightGreen;
            this.dgPagos.CaptionForeColor = System.Drawing.Color.DarkGreen;
            this.dgPagos.CaptionText = "Formas de Pago";
            this.dgPagos.DataMember = "";
            this.dgPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPagos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPagos.Location = new System.Drawing.Point(0, 88);
            this.dgPagos.Name = "dgPagos";
            this.dgPagos.Size = new System.Drawing.Size(792, 198);
            this.dgPagos.TabIndex = 158;
            this.dgPagos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGridTableStyle2.DataGrid = this.dgPagos;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "v_FormaPagoLinea";
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Tipo de Pago";
            this.dataGridTextBoxColumn12.MappingName = "Tipo Pago";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 150;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Detalle";
            this.dataGridTextBoxColumn13.MappingName = "Detalle";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 300;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn14.Format = "C";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Importe   .";
            this.dataGridTextBoxColumn14.MappingName = "Importe";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 75;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn15.Format = "C";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "Ajuste   .";
            this.dataGridTextBoxColumn15.MappingName = "Ajuste";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 75;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn16.Format = "C";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "Pesos   .";
            this.dataGridTextBoxColumn16.MappingName = "Pesos";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblInteresPorE);
            this.groupBox6.Controls.Add(this.cbCtadoCtaCte);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.lblInteresPorV);
            this.groupBox6.Controls.Add(this.lblTotalConInteresE);
            this.groupBox6.Controls.Add(this.lblInteresValE);
            this.groupBox6.Controls.Add(this.lblTotalConInteresV);
            this.groupBox6.Controls.Add(this.lblInteresValV);
            this.groupBox6.Controls.Add(this.butNuevoRecibo);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.lblTotalFacturado);
            this.groupBox6.Controls.Add(this.lblSaldoPagos);
            this.groupBox6.Controls.Add(this.lblTotalPagos);
            this.groupBox6.Controls.Add(this.butImprimirRecibo);
            this.groupBox6.Controls.Add(this.butSuspender2);
            this.groupBox6.Controls.Add(this.butCancelar2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 286);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(792, 112);
            this.groupBox6.TabIndex = 157;
            this.groupBox6.TabStop = false;
            // 
            // lblInteresPorE
            // 
            this.lblInteresPorE.Location = new System.Drawing.Point(296, 40);
            this.lblInteresPorE.Name = "lblInteresPorE";
            this.lblInteresPorE.Size = new System.Drawing.Size(56, 24);
            this.lblInteresPorE.TabIndex = 164;
            this.lblInteresPorE.Text = "Interés %";
            this.lblInteresPorE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresPorE.Visible = false;
            // 
            // cbCtadoCtaCte
            // 
            this.cbCtadoCtaCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCtadoCtaCte.Location = new System.Drawing.Point(292, 91);
            this.cbCtadoCtaCte.Name = "cbCtadoCtaCte";
            this.cbCtadoCtaCte.Size = new System.Drawing.Size(136, 21);
            this.cbCtadoCtaCte.TabIndex = 154;
            this.cbCtadoCtaCte.Visible = false;
            this.cbCtadoCtaCte.SelectedIndexChanged += new System.EventHandler(this.cbCtadoCtaCte_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(292, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 153;
            this.label15.Text = "Contado/Cta. Cte.";
            this.label15.Visible = false;
            // 
            // lblInteresPorV
            // 
            this.lblInteresPorV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInteresPorV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInteresPorV.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblInteresPorV.Location = new System.Drawing.Point(360, 40);
            this.lblInteresPorV.Name = "lblInteresPorV";
            this.lblInteresPorV.Size = new System.Drawing.Size(48, 24);
            this.lblInteresPorV.TabIndex = 163;
            this.lblInteresPorV.Text = "0";
            this.lblInteresPorV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresPorV.Visible = false;
            // 
            // lblTotalConInteresE
            // 
            this.lblTotalConInteresE.Location = new System.Drawing.Point(584, 40);
            this.lblTotalConInteresE.Name = "lblTotalConInteresE";
            this.lblTotalConInteresE.Size = new System.Drawing.Size(88, 24);
            this.lblTotalConInteresE.TabIndex = 162;
            this.lblTotalConInteresE.Text = "Total con Interés";
            this.lblTotalConInteresE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalConInteresE.Visible = false;
            // 
            // lblInteresValE
            // 
            this.lblInteresValE.Location = new System.Drawing.Point(408, 40);
            this.lblInteresValE.Name = "lblInteresValE";
            this.lblInteresValE.Size = new System.Drawing.Size(72, 24);
            this.lblInteresValE.TabIndex = 161;
            this.lblInteresValE.Text = "Interés $";
            this.lblInteresValE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresValE.Visible = false;
            // 
            // lblTotalConInteresV
            // 
            this.lblTotalConInteresV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalConInteresV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalConInteresV.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalConInteresV.Location = new System.Drawing.Point(680, 40);
            this.lblTotalConInteresV.Name = "lblTotalConInteresV";
            this.lblTotalConInteresV.Size = new System.Drawing.Size(96, 24);
            this.lblTotalConInteresV.TabIndex = 160;
            this.lblTotalConInteresV.Text = "0";
            this.lblTotalConInteresV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalConInteresV.Visible = false;
            // 
            // lblInteresValV
            // 
            this.lblInteresValV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInteresValV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInteresValV.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblInteresValV.Location = new System.Drawing.Point(488, 40);
            this.lblInteresValV.Name = "lblInteresValV";
            this.lblInteresValV.Size = new System.Drawing.Size(96, 24);
            this.lblInteresValV.TabIndex = 159;
            this.lblInteresValV.Text = "0";
            this.lblInteresValV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresValV.Visible = false;
            // 
            // butNuevoRecibo
            // 
            this.butNuevoRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butNuevoRecibo.Image = ((System.Drawing.Image)(resources.GetObject("butNuevoRecibo.Image")));
            this.butNuevoRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNuevoRecibo.Location = new System.Drawing.Point(8, 48);
            this.butNuevoRecibo.Name = "butNuevoRecibo";
            this.butNuevoRecibo.Size = new System.Drawing.Size(129, 24);
            this.butNuevoRecibo.TabIndex = 158;
            this.butNuevoRecibo.Text = "F10 - Nuevo Recibo";
            this.butNuevoRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNuevoRecibo.Click += new System.EventHandler(this.butNuevoRecibo_Click);
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(560, 80);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 24);
            this.label31.TabIndex = 156;
            this.label31.Text = "Saldo";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(584, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 24);
            this.label34.TabIndex = 153;
            this.label34.Text = "Total Conceptos";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(408, 16);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 24);
            this.label36.TabIndex = 151;
            this.label36.Text = "Total Pagos";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalFacturado
            // 
            this.lblTotalFacturado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalFacturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFacturado.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalFacturado.Location = new System.Drawing.Point(680, 16);
            this.lblTotalFacturado.Name = "lblTotalFacturado";
            this.lblTotalFacturado.Size = new System.Drawing.Size(96, 24);
            this.lblTotalFacturado.TabIndex = 150;
            this.lblTotalFacturado.Text = "0";
            this.lblTotalFacturado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldoPagos
            // 
            this.lblSaldoPagos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSaldoPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoPagos.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblSaldoPagos.Location = new System.Drawing.Point(656, 80);
            this.lblSaldoPagos.Name = "lblSaldoPagos";
            this.lblSaldoPagos.Size = new System.Drawing.Size(120, 24);
            this.lblSaldoPagos.TabIndex = 148;
            this.lblSaldoPagos.Text = "0";
            this.lblSaldoPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPagos
            // 
            this.lblTotalPagos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagos.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalPagos.Location = new System.Drawing.Point(488, 16);
            this.lblTotalPagos.Name = "lblTotalPagos";
            this.lblTotalPagos.Size = new System.Drawing.Size(96, 24);
            this.lblTotalPagos.TabIndex = 145;
            this.lblTotalPagos.Text = "0";
            this.lblTotalPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butImprimirRecibo
            // 
            this.butImprimirRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirRecibo.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirRecibo.Image")));
            this.butImprimirRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimirRecibo.Location = new System.Drawing.Point(8, 16);
            this.butImprimirRecibo.Name = "butImprimirRecibo";
            this.butImprimirRecibo.Size = new System.Drawing.Size(129, 24);
            this.butImprimirRecibo.TabIndex = 31;
            this.butImprimirRecibo.Text = "F7 - Imprimir Recibo";
            this.butImprimirRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirRecibo.Click += new System.EventHandler(this.butImprimirRecibo_Click);
            // 
            // butSuspender2
            // 
            this.butSuspender2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender2.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender2.Image")));
            this.butSuspender2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSuspender2.Location = new System.Drawing.Point(152, 16);
            this.butSuspender2.Name = "butSuspender2";
            this.butSuspender2.Size = new System.Drawing.Size(120, 24);
            this.butSuspender2.TabIndex = 30;
            this.butSuspender2.Text = "F5 - Suspender";
            this.butSuspender2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender2.Visible = false;
            this.butSuspender2.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // butCancelar2
            // 
            this.butCancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar2.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar2.Image")));
            this.butCancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar2.Location = new System.Drawing.Point(152, 48);
            this.butCancelar2.Name = "butCancelar2";
            this.butCancelar2.Size = new System.Drawing.Size(120, 24);
            this.butCancelar2.TabIndex = 29;
            this.butCancelar2.Text = "F12 - Cancelar";
            this.butCancelar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar2.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gbContado);
            this.groupBox4.Controls.Add(this.tbFormaPagoID);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(792, 88);
            this.groupBox4.TabIndex = 154;
            this.groupBox4.TabStop = false;
            // 
            // gbContado
            // 
            this.gbContado.Controls.Add(this.butBuscarNC);
            this.gbContado.Controls.Add(this.tbNotaCreditoID);
            this.gbContado.Controls.Add(this.cbAdicional);
            this.gbContado.Controls.Add(this.tbAdicional);
            this.gbContado.Controls.Add(this.lblAdicional);
            this.gbContado.Controls.Add(this.lblAjusteValor);
            this.gbContado.Controls.Add(this.butAgregarPago);
            this.gbContado.Controls.Add(this.tbPesos);
            this.gbContado.Controls.Add(this.lblAjusteEtiqueta);
            this.gbContado.Controls.Add(this.lblPesos);
            this.gbContado.Controls.Add(this.label28);
            this.gbContado.Controls.Add(this.cbTipoPagoDetalle);
            this.gbContado.Controls.Add(this.cbTipoPago);
            this.gbContado.Controls.Add(this.label30);
            this.gbContado.Controls.Add(this.label16);
            this.gbContado.Controls.Add(this.tbImportePago);
            this.gbContado.Location = new System.Drawing.Point(3, 8);
            this.gbContado.Name = "gbContado";
            this.gbContado.Size = new System.Drawing.Size(632, 80);
            this.gbContado.TabIndex = 155;
            this.gbContado.TabStop = false;
            this.gbContado.Text = "Contado";
            // 
            // butBuscarNC
            // 
            this.butBuscarNC.BackColor = System.Drawing.SystemColors.Control;
            this.butBuscarNC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarNC.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarNC.Image")));
            this.butBuscarNC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarNC.Location = new System.Drawing.Point(345, 53);
            this.butBuscarNC.Name = "butBuscarNC";
            this.butBuscarNC.Size = new System.Drawing.Size(86, 24);
            this.butBuscarNC.TabIndex = 164;
            this.butBuscarNC.Text = "F1 - Buscar";
            this.butBuscarNC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarNC.UseVisualStyleBackColor = false;
            this.butBuscarNC.Visible = false;
            this.butBuscarNC.Click += new System.EventHandler(this.butBuscarNC_Click);
            // 
            // tbNotaCreditoID
            // 
            this.tbNotaCreditoID.Location = new System.Drawing.Point(511, 60);
            this.tbNotaCreditoID.Name = "tbNotaCreditoID";
            this.tbNotaCreditoID.Size = new System.Drawing.Size(16, 20);
            this.tbNotaCreditoID.TabIndex = 163;
            this.tbNotaCreditoID.Visible = false;
            // 
            // cbAdicional
            // 
            this.cbAdicional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdicional.Location = new System.Drawing.Point(176, 56);
            this.cbAdicional.Name = "cbAdicional";
            this.cbAdicional.Size = new System.Drawing.Size(160, 21);
            this.cbAdicional.TabIndex = 154;
            this.cbAdicional.Visible = false;
            this.cbAdicional.SelectedIndexChanged += new System.EventHandler(this.cbAdicional_SelectedIndexChanged);
            // 
            // tbAdicional
            // 
            this.tbAdicional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAdicional.Location = new System.Drawing.Point(176, 56);
            this.tbAdicional.Name = "tbAdicional";
            this.tbAdicional.Size = new System.Drawing.Size(160, 20);
            this.tbAdicional.TabIndex = 153;
            this.tbAdicional.Visible = false;
            // 
            // lblAdicional
            // 
            this.lblAdicional.Location = new System.Drawing.Point(72, 56);
            this.lblAdicional.Name = "lblAdicional";
            this.lblAdicional.Size = new System.Drawing.Size(100, 16);
            this.lblAdicional.TabIndex = 162;
            this.lblAdicional.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAjusteValor
            // 
            this.lblAjusteValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAjusteValor.CurrencyDecimalSeparator = ",";
            this.lblAjusteValor.CurrencyGroupSeparator = ".";
            this.lblAjusteValor.CurrencySymbol = "";
            this.lblAjusteValor.DecimalsDigits = 2;
            this.lblAjusteValor.Location = new System.Drawing.Point(416, 32);
            this.lblAjusteValor.Name = "lblAjusteValor";
            this.lblAjusteValor.ReadOnly = true;
            this.lblAjusteValor.Size = new System.Drawing.Size(64, 20);
            this.lblAjusteValor.TabIndex = 156;
            this.lblAjusteValor.Text = " 0,00";
            this.lblAjusteValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butAgregarPago
            // 
            this.butAgregarPago.BackColor = System.Drawing.Color.Gainsboro;
            this.butAgregarPago.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAgregarPago.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarPago.Image")));
            this.butAgregarPago.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butAgregarPago.Location = new System.Drawing.Point(568, 19);
            this.butAgregarPago.Name = "butAgregarPago";
            this.butAgregarPago.Size = new System.Drawing.Size(56, 40);
            this.butAgregarPago.TabIndex = 158;
            this.butAgregarPago.Text = "Agregar";
            this.butAgregarPago.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butAgregarPago.UseVisualStyleBackColor = false;
            this.butAgregarPago.Click += new System.EventHandler(this.butAgregarPago_Click);
            // 
            // tbPesos
            // 
            this.tbPesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPesos.CurrencyDecimalSeparator = ",";
            this.tbPesos.CurrencyGroupSeparator = ".";
            this.tbPesos.CurrencySymbol = "$";
            this.tbPesos.DecimalsDigits = 2;
            this.tbPesos.Location = new System.Drawing.Point(488, 32);
            this.tbPesos.Name = "tbPesos";
            this.tbPesos.ReadOnly = true;
            this.tbPesos.Size = new System.Drawing.Size(64, 20);
            this.tbPesos.TabIndex = 157;
            this.tbPesos.Text = "$ 0,00";
            this.tbPesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAjusteEtiqueta
            // 
            this.lblAjusteEtiqueta.Location = new System.Drawing.Point(416, 16);
            this.lblAjusteEtiqueta.Name = "lblAjusteEtiqueta";
            this.lblAjusteEtiqueta.Size = new System.Drawing.Size(64, 16);
            this.lblAjusteEtiqueta.TabIndex = 155;
            this.lblAjusteEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPesos
            // 
            this.lblPesos.Location = new System.Drawing.Point(496, 16);
            this.lblPesos.Name = "lblPesos";
            this.lblPesos.Size = new System.Drawing.Size(56, 16);
            this.lblPesos.TabIndex = 154;
            this.lblPesos.Text = "Pesos";
            this.lblPesos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(8, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 16);
            this.label28.TabIndex = 138;
            this.label28.Text = "Tipo de Pago";
            // 
            // cbTipoPagoDetalle
            // 
            this.cbTipoPagoDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPagoDetalle.Location = new System.Drawing.Point(176, 32);
            this.cbTipoPagoDetalle.Name = "cbTipoPagoDetalle";
            this.cbTipoPagoDetalle.Size = new System.Drawing.Size(160, 21);
            this.cbTipoPagoDetalle.TabIndex = 152;
            this.cbTipoPagoDetalle.SelectedIndexChanged += new System.EventHandler(this.cbTipoPagoDetalle_SelectedIndexChanged);
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPago.Location = new System.Drawing.Point(8, 32);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.Size = new System.Drawing.Size(160, 21);
            this.cbTipoPago.TabIndex = 151;
            this.cbTipoPago.SelectedIndexChanged += new System.EventHandler(this.cbTipoPago_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(176, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 16);
            this.label30.TabIndex = 139;
            this.label30.Text = "Detalle";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(328, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 140;
            this.label16.Text = "Importe";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbImportePago
            // 
            this.tbImportePago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImportePago.CurrencyDecimalSeparator = ",";
            this.tbImportePago.CurrencyGroupSeparator = ".";
            this.tbImportePago.CurrencySymbol = "$";
            this.tbImportePago.DecimalsDigits = 2;
            this.tbImportePago.Location = new System.Drawing.Point(344, 32);
            this.tbImportePago.Name = "tbImportePago";
            this.tbImportePago.Size = new System.Drawing.Size(64, 20);
            this.tbImportePago.TabIndex = 155;
            this.tbImportePago.Text = "$ 0,00";
            this.tbImportePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbImportePago.Enter += new System.EventHandler(this.tbImportePago_Enter);
            this.tbImportePago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbImportePago_KeyPress);
            this.tbImportePago.Validated += new System.EventHandler(this.tbImportePago_Validated);
            // 
            // tbFormaPagoID
            // 
            this.tbFormaPagoID.Location = new System.Drawing.Point(720, 42);
            this.tbFormaPagoID.Name = "tbFormaPagoID";
            this.tbFormaPagoID.Size = new System.Drawing.Size(16, 20);
            this.tbFormaPagoID.TabIndex = 149;
            this.tbFormaPagoID.Visible = false;
            // 
            // ucReciboAlta
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label18);
            this.Name = "ucReciboAlta";
            this.Size = new System.Drawing.Size(800, 456);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReciboLinea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbConceptos.ResumeLayout(false);
            this.gbConceptos.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbContado.ResumeLayout(false);
            this.gbContado.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		
		
		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				tbFacturaID.Text = Utilidades.ID_VACIO;
				tbNotaDebitoID.Text = Utilidades.ID_VACIO;

				//Llena los combos
				//Obtiene todos los vendedores de la sucursal actual
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
				UtilUI.llenarCombo(ref cbAutorizadorBonificacion, this.conexion, "sp_getAllVendedorsBySucursal", "", -1, param);

				UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", 1);

				//Conceptos
				UtilUI.llenarCombo(ref cbConceptoAC, this.conexion, "sp_getAlltv_ReciboConcepto", "", 0);

                cbTipoComprobante.SelectedIndex = 0;

				//Asigna la tabla a la datagrid
				dgReciboLinea.DataSource = (DataTable)datasetReciboLinea.Tables["v_ReciboLinea"];
				dgPagos.DataSource = (DataTable)datasetFormaPagoLineas.Tables["v_FormaPagoLinea"];


				//Controles del Tab Formas de Pago
				UtilUI.llenarCombo(ref cbCtadoCtaCte, this.conexion, "sp_getAlltv_PlazoPago", "", 0); 
				UtilUI.llenarCombo(ref cbTipoPago, this.conexion, "sp_getAlltv_TipoPago", "", 0);
				UtilUI.llenarCombo(ref cbAdicional, this.conexion, "sp_getAlltv_CantidadPagos", "", 0);
                tbNotaCreditoID.Text = Utilidades.ID_VACIO;
				llenarTipoPagoDetalle();

                //Carga el Navegador de formularios
                cargarNavegadorFormulario();

                //Asigna los eventos a la grilla para evitar la tecla DEL
                asignarEventosGrilla(ref dgPagos);

                tbClienteNombre.Select();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Llena el combo TipoPagoDetalle
		private void llenarTipoPagoDetalle()
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@tipoPagoID", new System.Guid(cbTipoPago.SelectedValue.ToString()));
				UtilUI.llenarCombo(ref cbTipoPagoDetalle, this.conexion, "sp_getAlltv_TipoPagoDetalle", "", -1, param);
				if (cbTipoPagoDetalle.Items.Count>0)
					cbTipoPagoDetalle.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		
		//Abre el formulario de consulta en modo rapido
		private void abrirConsultaRapida()
		{
			try
			{
				frmClienteConsulta form = new frmClienteConsulta(this.configuracion, true);
				form.statusBar1 = this.statusBarPrincipal;

				//Crea y asigna el Delegate
				form.objDelegateDevolverID = new Comunes.frmClienteConsulta.DelegateDevolverID(buscarCliente);
			
				form.ShowDialog();
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
				string razonSocial="", direccion="", cuit="";
				string ivaID = Utilidades.ID_VACIO;
			
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
						direccion = dr["Calle (empresa)"].ToString() 
							+ "  Nro.:" + dr["Nro. (empresa)"].ToString() 
							+ "  Piso:" + dr["Piso (empresa)"].ToString() 
							+ "  Of.:" + dr["Of. (empresa)"].ToString() 
							+ "  C.P.:" + dr["Cod.Post. (empresa)"].ToString();
						cuit = dr["CUIT (empresa)"].ToString();
						ivaID = dr["ivaID"].ToString();
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
					direccion = "";
					cuit = "";
					clienteID = Utilidades.ID_VACIO;
					ivaID = Utilidades.ID_VACIO;;
				}

				tbClienteID.Text = clienteID;
				tbClienteNombre.Text = razonSocial;
				tbDireccion.Text = direccion;
				tbCUIT.Text = cuit;
				cbIVA.SelectedValue = ivaID;

				this.Cursor = Cursors.Arrow;

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

	


		private void butBorrarArticulosComponentes_Click(object sender, System.EventArgs e)
		{
			borrarRegistrosArticulosComponentes();
		}
		private void borrarRegistrosArticulosComponentes()
		{
			try
			{
				if (dgReciboLinea.DataSource!=null)
				{
					DataTable dt = (DataTable)dgReciboLinea.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgReciboLinea.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							DialogResult dr = MessageBox.Show("¿Desea borrar los Registros seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Registros...", true);
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									//dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = Utilidades.ID_VACIO; // "-1";
								}
								//Recorre los renglones marcados para borrar
                                DataRow[] rowsBorrar = dt.Select("id='" + Utilidades.ID_VACIO + "'"); //dt.Select("id='-1'");
								for (int k=0; k<rowsBorrar.Length; k++)
								{
									rowsBorrar[k].Delete();
								}
								dt.AcceptChanges();

								//Renumera los items
								renumerarItems();

								calcularSubTotales();

								dgReciboLinea.Refresh();
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
				DataTable dt = (DataTable)dgReciboLinea.DataSource;

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
				if (((DataTable)dgReciboLinea.DataSource).Rows.Count==0)
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

		private bool validarPago()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;

				string simportePago = tbImportePago.CurrencyValue().Replace(".","");
				double importePago = double.Parse(simportePago);
				if (importePago<=0)
				{
					mensaje += "   - El Importe debe ser mayor que 0.\r\n";
					resultado = false;
				}
                double saldo = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);
                if (saldo <= 0)
                {
                    mensaje += "   - No se puede seguir ingresando pagos.\r\n";
                    resultado = false;
                }

                if (tbAdicional.Visible && tbAdicional.Text == "")
                {
                    mensaje += "    - El campo no puede estar vacío.\r\n";
                    resultado = false;
                }
			
			
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				tbReciboID.Text = "";
				((DataTable)dgReciboLinea.DataSource).Rows.Clear();
				tbDescripcionAC.Text = "";
				tbClienteNombre.Text = "";
				tbClienteID.Text = "0";
				tbDireccion.Text = "";
				tbCUIT.Text = "";
				tabControl1.SelectedIndex = 0;
				//Totales
				tbBonificacion.Text = "0";
				lblSubTotal1.Text = "0";
				lblSubTotal2.Text = "0";
				lblBonificacion.Text = "0";
				lblTotal.Text = "0";

				//Formas de pago
				tbFormaPagoID.Text = "";
				tbImportePago.Text = "$ 0,00";
				tbImportePago.Text = "$ 0,00";
				lblAjusteValor.Text = "0,00";
				tbPesos.Text = "$ 0,00";
				tbAdicional.Text = "";
				((DataTable)dgPagos.DataSource).Rows.Clear();
				lblTotalPagos.Text = "0";
				lblTotalFacturado.Text = "0";
				lblInteresPorV.Text = "0";
				lblInteresValV.Text = "0";
				lblTotalConInteresV.Text = "0";
				lblSaldoPagos.Text = "0";

				//butCrearRemitos.Enabled = false;
				butSuspender.Enabled = true;
				butSuspender2.Enabled = true;
				butImprimirRecibo.Enabled = true;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Se perderán los cambios efectuados.\r\n\r\n¿Desea salir de todas formas?", "Cancelar y Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
				((Form)this.Parent).Close();
		}

		private void butBuscarCliente_Click(object sender, System.EventArgs e)
		{
			abrirConsultaRapida();
		}

		
		private void dgRemitoLinea_CurrentCellChanged(object sender, System.EventArgs e)
		{
			calcularSubTotalesConceptos();
		}

		private void butSuspender_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Recibo...", true);
				if (validarFormularioCabecera())
				{
					guardarRecibo("SUSPENDIDO");  //Estado 1: suspendida.
				
					//Limpia el formulario para que otro vendedor siga con otro Recibo
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
			
			
				if (tbClienteID.Text=="0" || tbClienteID.Text=="")
				{
					mensaje += "   - Debe seleccionar un Cliente.\r\n";
					resultado = false;
				}
			
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Recibo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Guarda el Recibo con el estado que se le indique.
		private void guardarRecibo(string estado)
		{
			try
			{
				//Primero guarda las formas de pago
				guardarFormasDePago();

				//Obtiene los valores
				DateTime fecha_creacion = DateTime.Now;
				string clienteID = tbClienteID.Text;
				double bonificacion = double.Parse(tbBonificacion.Text);
				string autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
				double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
				double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
				string estadoRecibo = estado;
				string maquinaID = configuracion.maquina.id.ToString(); 
				double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
				double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
				string formaPagoID = tbFormaPagoID.Text=="" ? Utilidades.ID_VACIO : tbFormaPagoID.Text;

				SqlParameter[] param = new SqlParameter[13];
			
				param[0] = new SqlParameter("@fecha_creacion", fecha_creacion);
				param[1] = new SqlParameter("@clienteID", new System.Guid(clienteID));
				param[2] = new SqlParameter("@usuarioID", new System.Guid(configuracion.usuario.id));
				param[3] = new SqlParameter("@bonificacion", bonificacion);
				param[4] = new SqlParameter("@autorizadorBonificacionID", new System.Guid(autorizadorBonificacionID));
				param[5] = new SqlParameter("@subTotal1", subTotal1);
				param[6] = new SqlParameter("@total", total);
				param[7] = new SqlParameter("@estadoRecibo", estadoRecibo);
				param[8] = new SqlParameter("@maquinaID", new System.Guid(maquinaID));
				param[9] = new SqlParameter("@subTotal2", subTotal2);
				param[10] = new SqlParameter("@bonificacionImporte", bonificacionImporte);
				param[11] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                param[12] = new SqlParameter("@estadoCuentaCorriente", "_");

				while (true)
				{
					try 
					{
						//Inserta el registro y obtiene el ID
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoRecibo", param);
					
						//Inserta las lineas
						if (dr.HasRows)
						{
							dr.Read();
							string reciboID = dr["ID"].ToString();
							tbReciboID.Text = reciboID.ToString();
							string conceptoID = Utilidades.ID_VACIO;
							string facturaID = Utilidades.ID_VACIO;
							string notaDebitoID = Utilidades.ID_VACIO;
                            string comprobanteTipo = "";
                            string comprobanteSuc = "";
							string comprobanteNro = "";
							string descripcion = "";
							double importe = 0;
						
							DataTable dtRemitoLinea = (DataTable)dgReciboLinea.DataSource;
							for (int i=0; i<dtRemitoLinea.Rows.Count; i++)
							{
								string concepto = dtRemitoLinea.Rows[i]["Concepto"].ToString();
								if (concepto.Trim()!="")
								{
									conceptoID = dtRemitoLinea.Rows[i]["conceptoID"].ToString();
									facturaID = dtRemitoLinea.Rows[i]["facturaID"].ToString();
                                    notaDebitoID = dtRemitoLinea.Rows[i]["notaDebitoID"].ToString();
                                    comprobanteTipo = dtRemitoLinea.Rows[i]["tipoComprobante"].ToString();
									comprobanteSuc = dtRemitoLinea.Rows[i]["comprobanteSuc"].ToString();
									comprobanteNro = dtRemitoLinea.Rows[i]["comprobanteNro"].ToString();
									descripcion = dtRemitoLinea.Rows[i]["descripcion"].ToString();
									importe = double.Parse(dtRemitoLinea.Rows[i]["importe"].ToString(), NumberStyles.Currency);
									param = new SqlParameter[9];
									param[0] = new SqlParameter("@reciboID", new System.Guid(reciboID));
									param[1] = new SqlParameter("@conceptoID", new System.Guid(conceptoID));
									param[2] = new SqlParameter("@facturaID", new System.Guid(facturaID));
									param[3] = new SqlParameter("@notaDebitoID", new System.Guid(notaDebitoID));
                                    param[4] = new SqlParameter("@comprobanteTipo", comprobanteTipo);
									param[5] = new SqlParameter("@comprobanteSuc", comprobanteSuc);
									param[6] = new SqlParameter("@comprobanteNro", comprobanteNro);
									param[7] = new SqlParameter("@descripcion", descripcion);
									param[8] = new SqlParameter("@importe", importe);
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertReciboLinea", param);
								}
							}
						}
						dr.Close();

						MessageBox.Show("Recibo guardado con éxito.", "Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Recibo guardado con éxito.", false);

						//Limpia el formulario
						//limpiarFormulario();

						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo guardar el Recibo. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar el Recibo. \r\n" + e.Message, false);
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


		//Guarda las Formas de Pago.
		private void guardarFormasDePago()
		{
			try
			{
				//Obtiene los valores
				string plazoPagoID = cbCtadoCtaCte.SelectedValue.ToString();
				double totalPagos = double.Parse(lblTotalPagos.Text, NumberStyles.Currency);
				double totalFacturado = double.Parse(lblTotalFacturado.Text, NumberStyles.Currency);
				double interesPor = double.Parse(lblInteresPorV.Text, NumberStyles.Currency);
				double interesVal = double.Parse(lblInteresValV.Text, NumberStyles.Currency);
				double totalConInteres = double.Parse(lblTotalConInteresV.Text, NumberStyles.Currency);
				double saldo = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);
			
				SqlParameter[] param = new SqlParameter[7];
			
				param[0] = new SqlParameter("@plazoPagoID", new System.Guid(plazoPagoID));
				param[1] = new SqlParameter("@totalPagos", totalPagos);
				param[2] = new SqlParameter("@totalFacturado", totalFacturado);
				param[3] = new SqlParameter("@interesPor", interesPor);
				param[4] = new SqlParameter("@interesVal", interesVal);
				param[5] = new SqlParameter("@totalConInteres", totalConInteres);
				param[6] = new SqlParameter("@saldo", saldo);
			
				while (true)
				{
					try 
					{
						//Inserta el registro y obtiene el ID
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevaFormaPago", param);
					
						//Inserta los items
						if (dr.HasRows && gbContado.Enabled)
						{
							dr.Read();
							string formaPagoID = dr["ID"].ToString();
							tbFormaPagoID.Text = formaPagoID.ToString();
							string tipoPagoID = Utilidades.ID_VACIO;
							string tipoPagoDetalleID = Utilidades.ID_VACIO;
							double importe = 0;
							double ajuste = 0;
							double pesos = 0;
							string nroCheque = "";
							string bancoID = Utilidades.ID_VACIO;
							string cantidadPagosID = Utilidades.ID_VACIO;
                            string detalle = "";
                            string notaCreditoID = Utilidades.ID_VACIO;

							DataTable dtPagos = (DataTable)dgPagos.DataSource;
							for (int i=0; i<dtPagos.Rows.Count; i++)
							{
								tipoPagoID = dtPagos.Rows[i]["tipoPagoID"].ToString();
								tipoPagoDetalleID = dtPagos.Rows[i]["tipoPagoDetalleID"].ToString();
								importe = double.Parse(dtPagos.Rows[i]["importe"].ToString());
								ajuste = double.Parse(dtPagos.Rows[i]["ajuste"].ToString());
								pesos = double.Parse(dtPagos.Rows[i]["pesos"].ToString());
								nroCheque = dtPagos.Rows[i]["Nro. Cheque"].ToString();
								bancoID = dtPagos.Rows[i]["bancoID"].ToString();
								cantidadPagosID = dtPagos.Rows[i]["cantidadPagosID"].ToString();
                                detalle = dtPagos.Rows[i]["detalle"].ToString();
                                notaCreditoID = dtPagos.Rows[i]["notaCreditoID"].ToString();

								param = new SqlParameter[11];
								param[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
								param[1] = new SqlParameter("@tipoPagoID", new System.Guid(tipoPagoID));
								param[2] = new SqlParameter("@tipoPagoDetalleID", new System.Guid(tipoPagoDetalleID));
								param[3] = new SqlParameter("@importe", importe);
								param[4] = new SqlParameter("@ajuste", ajuste);
								param[5] = new SqlParameter("@pesos", pesos);
								param[6] = new SqlParameter("@nroCheque", nroCheque);
								param[7] = new SqlParameter("@bancoID", new System.Guid(bancoID));
								param[8] = new SqlParameter("@cantidadPagosID", new System.Guid(cantidadPagosID));
                                param[9] = new SqlParameter("@detalle", detalle);
                                param[10] = new SqlParameter("@notaCreditoID", new System.Guid(notaCreditoID));
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertFormaPagoLinea", param);
							}
						}
						else
							tbFormaPagoID.Text = Utilidades.ID_VACIO;

						dr.Close();

						//MessageBox.Show("Nota de Pedido guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Recibo guardado con éxito.", false);

						//Limpia el formulario
						//limpiarFormulario();

						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo guardar la Forma de Pago. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Forma de Pago. \r\n" + e.Message, false);
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
		
		//Calcula los subtotales
		private void calcularSubTotales()
		{/*
			if (((DataTable)dgSubArticulos.DataSource).Rows.Count>0)
			{
				//Subtotal 1
				decimal subTotal1 = (decimal)((DataTable)dgSubArticulos.DataSource).Compute("Sum(precioTotalConDesc)","");
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
			}*/
		}


		//Calcula los subtotales para los Pagos
		private void calcularSubTotalesPagos()
		{
			try
			{
				decimal totalPagos = 0;
				if (((DataTable)dgPagos.DataSource).Rows.Count>0)
				{
					//Total Pagos
					totalPagos = (decimal)((DataTable)dgPagos.DataSource).Compute("Sum(Pesos)","");
				}

				lblTotalPagos.Text = totalPagos.ToString("C");
			
				//Total Facturado
				decimal totalFacturado = decimal.Parse(lblTotal.Text, NumberStyles.Currency);
				lblTotalFacturado.Text = totalFacturado.ToString("C");

				//Total con Interes
				decimal totalConInteres = decimal.Parse(lblTotalConInteresV.Text, NumberStyles.Currency);
				if (totalConInteres==0)
					totalConInteres = totalFacturado;

				//Saldo
				decimal saldoPagos = totalConInteres-totalPagos;
				lblSaldoPagos.Text = saldoPagos.ToString("C");

				//Pone en el importe el saldo
				tbImportePago.Text = lblSaldoPagos.Text;
			
				string tipoPago = ((DataTable)cbTipoPago.DataSource).Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
				convertirDivisa(tipoPago);
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
					calcularSubTotalesConceptos();
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
		{
			try
			{
				frmRemitoAlta frmRemit = new frmRemitoAlta(this.configuracion);
				frmRemit.statusBar1 = this.statusBarPrincipal;
				frmRemit.toolBar2 = null; 
				frmRemit.Show();
				//frmRemit.ucRemitoAlta1.buscarNotaPedido(tbNotaPedidoID.Text);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butImprimirRecibo_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (validarFormularioCabecera())
				{
					Recibo recibo = new Recibo(this.configuracion);

					//Primero guarda el Recibo
					guardarRecibo("SUSPENDIDO");  
				
					//Luego lo imprime
					if (recibo.imprimirRecibo(tbReciboID.Text))
					{
						//Cambia el estado a IMPRESO
						recibo.cambiarEstadoRecibo(tbReciboID.Text, "IMPRESO");

                        
						//butCrearRemitos.Enabled = true;
						butSuspender.Enabled = false;
						butSuspender2.Enabled = false;
						butImprimirRecibo.Enabled = false;

                        butNuevoRecibo_Click(sender, e);
					}

					recibo = null;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butNuevoRecibo_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		private void butSiguiente_Click(object sender, System.EventArgs e)
		{
			tabControl1.SelectedIndex = 1;
		}

		private void cbTipoPago_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarTipoPagoDetalle();
			habilitarAjuste();
		}

		private void cbCtadoCtaCte_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			habilitarContado();
		}

		//Habilita o no el cuadro de cotroles para el pago Contado
		private void habilitarContado()
		{
			try
			{
				if (cbCtadoCtaCte.SelectedIndex>-1)
				{
					DataTable dtPlazo = (DataTable)cbCtadoCtaCte.DataSource;

					if (dtPlazo.Rows[cbCtadoCtaCte.SelectedIndex]["identificador"].ToString()=="CONTADO")
						gbContado.Enabled = true;
					else
						gbContado.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Habilita las etiquetas de ajuste
		private void habilitarAjuste()
		{
			try
			{
				if (cbTipoPago.SelectedIndex>-1)
				{
					DataTable dtTipoPago = (DataTable)cbTipoPago.DataSource;

					if (dtTipoPago.Rows[cbTipoPago.SelectedIndex]["operacion"].ToString()=="CAMBIO")
					{
						lblAjusteEtiqueta.Visible = true;
						lblAjusteValor.Visible = true;
						lblAjusteEtiqueta.Text = "Cambio";
						lblAjusteValor.Text = "$ 0,00";

						lblPesos.Visible = true;
						tbPesos.Visible = true;
						tbPesos.Text = "$ 0,00";
					}
					else
					{
						lblAjusteEtiqueta.Visible = false;
						lblAjusteValor.Visible = false;
						lblAjusteEtiqueta.Text = "";
						lblAjusteValor.Text = "$ 0,00";

						lblPesos.Visible = false;
						tbPesos.Visible = false;
						tbPesos.Text = "$ 0,00";
					}

					//Decide que hacer dependiendo del tipo de pago
					string identificadorTP = dtTipoPago.Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
					switch (identificadorTP)
					{
						case "PESOS":
						case "DIVISAS":
						case "T_DEBITO":
						{
							lblAdicional.Visible = false;
							tbAdicional.Text = "";
							tbAdicional.Visible = false;
							cbAdicional.Visible = false;
							lblInteresPorE.Visible = false;
							lblInteresPorV.Text = "0";
							lblInteresPorV.Visible = false;
							lblInteresValE.Visible = false;
							lblInteresValV.Text = "0";
							lblInteresValV.Visible = false;
							lblTotalConInteresE.Visible = false;
							lblTotalConInteresV.Text = "0";
							lblTotalConInteresV.Visible = false;
                            butBuscarNC.Visible = false;
							calcularSubTotalesPagos();
							break;
						}
						case "CHEQUES":
						{
							lblAdicional.Text = "Cheque Nro.";
							lblAdicional.Visible = true;
							tbAdicional.Text = "";
							tbAdicional.Visible = true;
                            tbAdicional.ReadOnly = false;
							cbAdicional.Visible = false;
							lblInteresPorE.Visible = false;
							lblInteresPorV.Text = "0";
							lblInteresPorV.Visible = false;
							lblInteresValE.Visible = false;
							lblInteresValV.Text = "0";
							lblInteresValV.Visible = false;
							lblTotalConInteresE.Visible = false;
							lblTotalConInteresV.Text = "0";
							lblTotalConInteresV.Visible = false;
                            butBuscarNC.Visible = false;
							calcularSubTotalesPagos();
							break;
						}
                        case "NOTA_CREDITO":
                        {
                            lblAdicional.Text = "Nota Crédito Nro.";
                            lblAdicional.Visible = true;
                            tbAdicional.Text = "";
                            tbAdicional.Visible = true;
                            tbAdicional.ReadOnly = true;
                            cbAdicional.Visible = false;
                            lblInteresPorE.Visible = false;
                            lblInteresPorV.Text = "0";
                            lblInteresPorV.Visible = false;
                            lblInteresValE.Visible = false;
                            lblInteresValV.Text = "0";
                            lblInteresValV.Visible = false;
                            lblTotalConInteresE.Visible = false;
                            lblTotalConInteresV.Text = "0";
                            lblTotalConInteresV.Visible = false;
                            butBuscarNC.Visible = true;
                            calcularSubTotalesPagos();
                            break;
                        }
						case "T_CREDITO":
						{
							lblAdicional.Text = "Cantidad de Pagos";
							lblAdicional.Visible = true;
							tbAdicional.Text = "";
							tbAdicional.Visible = false;
							cbAdicional.Visible = true;

						
							lblInteresPorE.Visible = true;
							//lblInteresPorV.Text = "0";
							lblInteresPorV.Visible = true;
							lblInteresValE.Visible = true;
							//lblInteresValV.Text = "0";
							lblInteresValV.Visible = true;
							lblTotalConInteresE.Visible = true;
							//lblTotalConInteresV.Text = "0";
							lblTotalConInteresV.Visible = true;
                            butBuscarNC.Visible = false;

							visualizarInteres();
							break;
						}
					}

					establecerAjuste();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Muestra en los controles todos los datos referentes al interes aplicado
		private void visualizarInteres()
		{
			try
			{
				if (cbAdicional.SelectedIndex>-1 && cbAdicional.Visible)
				{
					calcularSubTotalesPagos();
					DataTable dtCantidadPagos = (DataTable)cbAdicional.DataSource;
					double interesPor = double.Parse(dtCantidadPagos.Rows[cbAdicional.SelectedIndex]["interes"].ToString());
					double totalFacturado = double.Parse(lblTotalFacturado.Text, NumberStyles.Currency);
				
					double interesVal = 0;
					if (totalFacturado!=0)
						interesVal = (totalFacturado/100)*interesPor;
					else
						interesVal = 0;

					double totalConInteres = totalFacturado + interesVal;

					lblInteresPorV.Text = interesPor.ToString("N");
					lblInteresValV.Text = interesVal.ToString("C");
					lblTotalConInteresV.Text = totalConInteres.ToString("C");
				}
				calcularSubTotalesPagos();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butAgregarPago_Click(object sender, System.EventArgs e)
		{
			if (validarPago())
				agregarPago();
		}

		//Agrega el pago a la grilla.
		private void agregarPago()
		{
			try
			{
                //Actualiza el importe Pesos
                convertirDivisa("");

				string identificadorTipoPago = ((DataTable)cbTipoPago.DataSource).Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
				string detalle = cbTipoPagoDetalle.Text;
				switch (identificadorTipoPago)
				{
					case "CHEQUES":
						detalle += ", Nro. " + tbAdicional.Text;
						break;
                    case "NOTA_CREDITO":
                        detalle += ", Nro. " + tbAdicional.Text;
                        break;
					case "T_CREDITO":
						detalle += ", " + cbAdicional.Text;
						break;
				}
				//Agrega un registro a la tabla de la grilla
				DataTable tabla = (DataTable)dgPagos.DataSource;
				DataRow newRow = tabla.NewRow();
                newRow["id"] = Guid.NewGuid();
                newRow["formaPagoID"] = Guid.NewGuid();

				newRow["tipoPagoID"] = cbTipoPago.SelectedValue;
				newRow["Tipo Pago"] = cbTipoPago.Text;
				newRow["tipoPagoDetalleID"] = cbTipoPagoDetalle.SelectedValue!=null ? cbTipoPagoDetalle.SelectedValue : Utilidades.ID_VACIO;
				newRow["Detalle"] = detalle;
				newRow["Importe"] = double.Parse(tbImportePago.CurrencyValue(), NumberStyles.Currency);
				newRow["Ajuste"] = double.Parse(lblAjusteValor.Text, NumberStyles.Currency);
				newRow["Pesos"] = double.Parse(tbPesos.CurrencyValue(), NumberStyles.Currency);
				newRow["Nro. Cheque"] = tbAdicional.Text;
                newRow["notaCreditoID"] = new Guid(tbNotaCreditoID.Text);

				DataTable dtTipoPagoDetalle = ((DataTable)cbTipoPagoDetalle.DataSource);
				string bancoID = Utilidades.ID_VACIO;
				if (dtTipoPagoDetalle.Rows.Count>0)
					bancoID = dtTipoPagoDetalle.Rows[cbTipoPagoDetalle.SelectedIndex]["bancoID"].ToString();

				newRow["bancoID"] = bancoID;

				newRow["cantidadPagosID"] = cbAdicional.SelectedValue;
			
				tabla.Rows.Add(newRow);

				//Limpia el importe
				tbImportePago.Text = "$ 0,00";
				tbAdicional.Text = "";
                tbNotaCreditoID.Text = Utilidades.ID_VACIO;
			
				//Establece el foco en la grilla y muestra el ultimo registro
				dgPagos.Select();
				dgPagos.CurrentRowIndex = ((DataTable)dgPagos.DataSource).Rows.Count - 1;

				//Establece el foco
				cbTipoPago.Select();

				calcularSubTotalesPagos();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbImportePago_Validated(object sender, System.EventArgs e)
		{
			convertirDivisa("");
		}

		//Reliza el calculo de conversion de divisa
		private void convertirDivisa(string tipoPago)
		{
			try
			{
				string simportePago = tbImportePago.CurrencyValue();
				double importePago = double.Parse(simportePago, NumberStyles.Currency);

				double pesos = importePago;

				string sajuste = lblAjusteValor.CurrencyValue();
				double ajuste = double.Parse(sajuste, NumberStyles.Currency);

				if (ajuste>0)
				{
					if (tipoPago=="DIVISAS")
					{
						pesos = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);
						importePago = pesos / ajuste;
						tbImportePago.Text = importePago.ToString("C");
					}
					else
						pesos = importePago * ajuste;
				}
				else  //si ajuste==0
				{
					if (tipoPago=="DIVISAS")
					{
						pesos = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);
						importePago = pesos;
						tbImportePago.Text = importePago.ToString("C");
					}
				}

				tbPesos.Text = pesos.ToString("C");
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cbTipoPagoDetalle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			establecerAjuste();
		}

		private void establecerAjuste()
		{
			try
			{
				DataTable dtDetalle = (DataTable)cbTipoPagoDetalle.DataSource;

				if (dtDetalle.Rows.Count>0)
				{
					string nombreParametro = dtDetalle.Rows[cbTipoPagoDetalle.SelectedIndex]["ajuste"].ToString();

					double valorAjuste = 0;
					if (nombreParametro!="")
						valorAjuste = (double)this.configuracion.obtenerParametro(nombreParametro);

					lblAjusteValor.Text = valorAjuste.ToString("C");

					string tipoPago = ((DataTable)cbTipoPago.DataSource).Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
					convertirDivisa(tipoPago);
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbImportePago_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
				if (validarPago())
					agregarPago();
		}


		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
                if (tabControl1.SelectedIndex == 0)
                {
                    tbClienteNombre.Select();
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    cbConceptoAC.Select();
                }
                //si el es tab de formas de pago, calcula los subtotales
                if (tabControl1.SelectedIndex == 2)
                {
                    //cbCtadoCtaCte.Select();
                    cbTipoPago.Select();
                    calcularSubTotalesPagos();
                }

			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butBorrarPagos_Click(object sender, System.EventArgs e)
		{
			borrarRegistrosPagos();
		}

		private void borrarRegistrosPagos()
		{
			try
			{
				if (dgPagos.DataSource!=null)
				{
					DataTable dt = (DataTable)dgPagos.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgPagos.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							DialogResult dr = MessageBox.Show("¿Desea borrar los Pagos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Pagos...", true);
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									//dt.Rows[renglon].Delete();
									//dt.Rows[renglon]["id"] = "-1";
                                    dt.Rows[renglon]["id"] = Utilidades.ID_VACIO;
								}
								//Recorre los renglones marcados para borrar
								//DataRow[] rowsBorrar = dt.Select("id='-1'");
                                DataRow[] rowsBorrar = dt.Select("id='" + Utilidades.ID_VACIO + "'");
								for (int k=0; k<rowsBorrar.Length; k++)
								{
									rowsBorrar[k].Delete();
								}
								dt.AcceptChanges();

								//Renumera los items
								renumerarItemsPagos();

								dgPagos.Refresh();

								visualizarInteres();
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
		private void renumerarItemsPagos()
		{
			/*DataTable dt = (DataTable)dgPagos.DataSource;

			for (int i=0; i<dt.Rows.Count; i++)
			{
				dt.Rows[i]["itemNro"] = i + 1;
			}*/
		}

		private void cbAdicional_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			visualizarInteres();
		}

		private void butContinuar2_Click(object sender, System.EventArgs e)
		{
			tabControl1.SelectedIndex = 2;
			cbCtadoCtaCte.Select();
		}

		private void tbImportePago_Enter(object sender, System.EventArgs e)
		{
			tbImportePago.SelectAll();
		}

		private void tbNroSucAC_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string facturaSuc = tbNroSucAC.Text;
				Utilidades.agregarCerosIzquierda(ref facturaSuc,4);
				tbNroSucAC.Text = facturaSuc;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNroSucAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				tbNroAC.Select();
			}
		}

		private void tbNroAC_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string facturaNro = tbNroAC.Text;
				Utilidades.agregarCerosIzquierda(ref facturaNro,8);
				tbNroAC.Text = facturaNro;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNroAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar==(char)Keys.Enter)
				{
					tbDescripcionAC.Select();
					string idConcepto = ((DataTable)cbConceptoAC.DataSource).Rows[cbConceptoAC.SelectedIndex]["identificador"].ToString();

					if (idConcepto=="FACTURA")
						buscarFactura();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void buscarFactura()
		{
			try
			{
				SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@facturaTipo", cbTipoComprobante.Text);
				param[1] = new SqlParameter("@facturaSuc", tbNroSucAC.Text);
				param[2] = new SqlParameter("@facturaNro", tbNroAC.Text);

				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getFacturaByNumero", param);

				string facturaID = Utilidades.ID_VACIO;
				double total = 0;

				if (dr.HasRows)
				{
					dr.Read();
					facturaID = dr["id"].ToString();
					total = double.Parse(dr["total"].ToString());
				}
				else
				{
					MessageBox.Show("No existe la Factura Nro: " + tbNroSucAC.Text + "-" + tbNroAC.Text, "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					tbNroAC.Select();
				}

				dr.Close();

				tbFacturaID.Text = facturaID;
				tbImporteAC.Text = total.ToString("C");
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNroSucAC_Enter(object sender, System.EventArgs e)
		{
			tbNroSucAC.SelectAll();
		}

		private void tbNroAC_Enter(object sender, System.EventArgs e)
		{
			tbNroAC.SelectAll();
		}

		private void tbDescripcionAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
				tbImporteAC.Select();
		}

		private void tbImporteAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
				MessageBox.Show("Cuco");
		}

		private void cbConceptoAC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			establecerConcepto();
		}

		private void establecerConcepto()
		{
			try
			{
				DataTable dtConcepto = (DataTable)cbConceptoAC.DataSource;
				string idConcepto = dtConcepto.Rows[cbConceptoAC.SelectedIndex]["identificador"].ToString();

				switch (idConcepto)
				{
					case "FACTURA":
					{
						lblNro.Visible = true;
						lblGuion.Visible = true;
						tbNroSucAC.Visible = true;
						tbNroAC.Visible = true;
						break;
					}
					case "NOTA_DEBITO":
					{
						lblNro.Visible = true;
						lblGuion.Visible = true;
						tbNroSucAC.Visible = true;
						tbNroAC.Visible = true;
						break;
					}
					case "OTRO":
					{
						lblNro.Visible = false;
						lblGuion.Visible = false;
						tbNroSucAC.Visible = false;
						tbNroAC.Visible = false;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butAgregarConcepto_Click(object sender, System.EventArgs e)
		{
			if (validarConcepto())
				agregarConcepto();
		}

		private bool validarConcepto()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;

				string simporteConcepto = tbImporteAC.CurrencyValue();

				double importeConcepto = double.Parse(simporteConcepto, NumberStyles.Currency);
				if (importeConcepto<=0)
				{
					mensaje += "   - El Importe debe ser mayor que 0.\r\n";
					resultado = false;
				}
			
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Agrega el Concepto a la grilla.
		private void agregarConcepto()
		{
			try
			{
				string idConcepto = ((DataTable)cbConceptoAC.DataSource).Rows[cbConceptoAC.SelectedIndex]["identificador"].ToString();
                string tipoComprobante = cbTipoComprobante.Text;
				string comprobanteSuc = tbNroSucAC.Text;
				string comprobanteNro = tbNroAC.Text;
				string facturaID = tbFacturaID.Text=="" ? Utilidades.ID_VACIO : tbFacturaID.Text;
				string notaDebitoID = tbNotaDebitoID.Text=="" ? Utilidades.ID_VACIO : tbNotaDebitoID.Text;
				string descripcion = "";
				switch (idConcepto)
				{
					case "FACTURA":
					case "NOTA_DEBITO":
						descripcion = tbDescripcionAC.Text;
						break;
					case "OTRO":
						descripcion = tbDescripcionAC.Text;
						break;
				}
				//Agrega un registro a la tabla de la grilla
				DataTable tabla = (DataTable)dgReciboLinea.DataSource;
				DataRow newRow = tabla.NewRow();
                newRow["reciboID"] = Utilidades.ID_VACIO;
				newRow["conceptoID"] = cbConceptoAC.SelectedValue;
				newRow["facturaID"] = facturaID;
				newRow["notaDebitoID"] = notaDebitoID;
                newRow["tipoComprobante"] = tipoComprobante;
                newRow["comprobanteSuc"] = tbNroSucAC.Text;
				newRow["comprobanteNro"] = tbNroAC.Text;
				newRow["descripcion"] = descripcion;
				newRow["importe"] = double.Parse(tbImporteAC.CurrencyValue(), NumberStyles.Currency);
				newRow["Concepto"] = cbConceptoAC.Text;
				newRow["idConcepto"] = idConcepto;
                newRow["id"] = Utilidades.ID_VACIO; 

				tabla.Rows.Add(newRow);

				//Limpia el importe
				tbNroSucAC.Text = "";
				tbNroAC.Text= "";
				tbDescripcionAC.Text = "";
				tbImporteAC.Text = "$ 0,00";
				tbFacturaID.Text = Utilidades.ID_VACIO;
				tbNotaDebitoID.Text = Utilidades.ID_VACIO;
			
				//Establece el foco en la grilla y muestra el ultimo registro
				dgReciboLinea.Select();
				dgReciboLinea.CurrentRowIndex = ((DataTable)dgReciboLinea.DataSource).Rows.Count - 1;

				//Establece el foco
				cbConceptoAC.Select();

				calcularSubTotalesConceptos();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Calcula los subtotales de los conceptos de pago
		private void calcularSubTotalesConceptos()
		{
			try
			{
				if (((DataTable)dgReciboLinea.DataSource).Rows.Count>0)
				{
					//Subtotal 1
					decimal subTotal1 = (decimal)((DataTable)dgReciboLinea.DataSource).Compute("Sum(importe)","");
					lblSubTotal1.Text = subTotal1.ToString("C");

					//Bonificacion
					decimal bonificacionPorc = decimal.Parse(tbBonificacion.Text);
					decimal bonificacionImp = subTotal1/100*bonificacionPorc;
					lblBonificacion.Text = bonificacionImp.ToString("C");

					//Subtotal 2
					decimal subTotal2 = subTotal1-bonificacionImp;
					lblSubTotal2.Text = subTotal2.ToString("C");

					//Total general
					decimal total = subTotal2;
					lblTotal.Text = total.ToString("C");
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

        private void butBuscarConcepto_Click(object sender, EventArgs e)
        {
            utilRecibo.buscarConcepto(this.configuracion, ref gbConceptos, tbClienteID.Text);
        }

        private void butBuscarNC_Click(object sender, EventArgs e)
        {
            utilRecibo.buscarConceptoPago(this.configuracion, ref tabControl1, tbClienteID.Text);
        }

        //Carga el Navegador de Formularios
        private void cargarNavegadorFormulario()
        {
            /*************************************
             * Navegador de la Solapa Cabecera
             * ***********************************/
            //Carga las teclas rapidas primero
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscarCliente, 0, (char)Keys.F1));
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butSiguiente, 1, (char)Keys.F3));

            //Carga los controles
            navegador.agregarControl(new CapsulaControl((Control)butBuscarCliente, 0));
            navegador.agregarControl(new CapsulaControl((Control)butSiguiente, 1));
            
            //Agrega los handlers para todos los controles del control contenedor
            navegador.agregarHandlersContenedor(tabControl1.TabPages[0]);


            /*************************************
             * Navegador de la Solapa Conceptos
             * ***********************************/
            //Carga las teclas rapidas primero
            navegadorConceptos.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscarConcepto, 0, (char)Keys.F1));
            navegadorConceptos.agregarControlTeclaRapida(new CapsulaControl((Control)butContinuar2, 1, (char)Keys.F3));
            navegadorConceptos.agregarControlTeclaRapida(new CapsulaControl((Control)butSuspender, 2, (char)Keys.F5));
            navegadorConceptos.agregarControlTeclaRapida(new CapsulaControl((Control)butCancelar, 3, (char)Keys.F12));

            //Carga los controles
            navegadorConceptos.agregarControl(new CapsulaControl((Control)tbBonificacion, 0));
            navegadorConceptos.agregarControl(new CapsulaControl((Control)cbAutorizadorBonificacion, 1));
            navegadorConceptos.agregarControl(new CapsulaControl((Control)butContinuar2, 2));

            //Agrega los handlers para todos los controles del control contenedor
            navegadorConceptos.agregarHandlersContenedor(tabControl1.TabPages[1]);


            /*************************************
			 * Navegador de la Solapa Formas de Pago
			 * ***********************************/
            //Carga las teclas rapidas primero
            navegadorFormasPago.agregarControlTeclaRapida(new CapsulaControl((Control)butImprimirRecibo, 0, (char)Keys.F7));
            navegadorFormasPago.agregarControlTeclaRapida(new CapsulaControl((Control)butSuspender2, 1, (char)Keys.F5));
            navegadorFormasPago.agregarControlTeclaRapida(new CapsulaControl((Control)butCancelar2, 3, (char)Keys.F12));
            navegadorFormasPago.agregarControlTeclaRapida(new CapsulaControl((Control)butNuevoRecibo, 4, (char)Keys.F10));
            navegadorFormasPago.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscarNC, 5, (char)Keys.F1));

            //Carga los controles
            /*navegadorItems.agregarControl(new CapsulaControl((Control)butBonificacion, 0));
            navegadorItems.agregarControl(new CapsulaControl((Control)tbBonificacion, 1));
            navegadorItems.agregarControl(new CapsulaControl((Control)cbAutorizadorBonificacion, 2));
            navegadorItems.agregarControl(new CapsulaControl((Control)lblBonificacion, 3));
            navegadorItems.agregarControl(new CapsulaControl((Control)butContinuar2, 4));*/

            //Agrega los handlers para todos los controles del control contenedor
            navegadorFormasPago.agregarHandlersContenedor(tabControl1.TabPages[2]);
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