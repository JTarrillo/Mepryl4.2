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
    public class ucNotaDebitoAlta : System.Windows.Forms.UserControl
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
        private System.Windows.Forms.TextBox tbClienteNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCondicionEntrega;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCUIT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDireccionEntrega;
        private System.Windows.Forms.Button butBuscarCliente;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.ComboBox cbIVA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPrecioAC;
        private System.Windows.Forms.TextBox tbPromocionAC;
        private System.Windows.Forms.TextBox tbClienteID;
        private System.Windows.Forms.TextBox tbNotaPedidoID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSubTotal2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIva2;
        private System.Windows.Forms.Label lblIva1;
        private System.Windows.Forms.Label lblSubTotal1;
        private System.Windows.Forms.ComboBox cbAutorizadorBonificacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbBonificacion;
        private System.Windows.Forms.Button butSuspender;
        private System.Windows.Forms.Button butCancelar;
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
        private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
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
        public DataSet dataset = (DataSet)new dsArticulos();
        private System.Windows.Forms.Label lblAdicional;
        private System.Windows.Forms.TextBox tbAdicional;
        private System.Windows.Forms.ComboBox cbAdicional;
        private System.Windows.Forms.Label lblTotalConInteresE;
        private System.Windows.Forms.Label lblInteresValE;
        private System.Windows.Forms.Label lblTotalConInteresV;
        private System.Windows.Forms.Label lblInteresValV;
        private System.Windows.Forms.Label lblInteresPorE;
        private System.Windows.Forms.Label lblInteresPorV;
        private System.Windows.Forms.Button butNuevaNotaPedido;
        private System.Windows.Forms.Button butImprimirFactura;
        private System.Windows.Forms.Button butSuspender2;
        private System.Windows.Forms.Button butCancelar2;
        private System.Windows.Forms.Button butCrearRemitos;
        private System.Windows.Forms.Button butContinuar2;
        private System.Windows.Forms.TextBox tbFormaPagoID;
        private System.Windows.Forms.ComboBox cbRegaloEmpresario;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbFacturaID;
        private System.Windows.Forms.Button butNuevoArticulo;
        private System.Windows.Forms.Button butConsumidorFinal;
        private KMCurrencyTextBox.KMCurrencyTextBox lblBonificacion;
        public DataSet datasetFormaPagoLineas = (DataSet)new dsFormaPagoLinea();

        public NavegadorFormulario navegador;
        private System.Windows.Forms.Button butBonificacion;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.TextBox tbPrecioIVAAC;
        public NavegadorFormulario navegadorItems;

        public ucNotaDebitoAlta()
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
                if (m_configuracion != null)
                    conexion = m_configuracion.getConectionString();
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucNotaPedidoAlta));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbRegaloEmpresario = new System.Windows.Forms.ComboBox();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCondicionEntrega = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDireccionEntrega = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butConsumidorFinal = new System.Windows.Forms.Button();
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
            this.dgSubArticulos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butBonificacion = new System.Windows.Forms.Button();
            this.lblBonificacion = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.butContinuar2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSubTotal2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIva2 = new System.Windows.Forms.Label();
            this.lblIva1 = new System.Windows.Forms.Label();
            this.lblSubTotal1 = new System.Windows.Forms.Label();
            this.cbAutorizadorBonificacion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbBonificacion = new System.Windows.Forms.TextBox();
            this.butSuspender = new System.Windows.Forms.Button();
            this.butCancelar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbPrecioIVAAC = new System.Windows.Forms.TextBox();
            this.butNuevoArticulo = new System.Windows.Forms.Button();
            this.tbFacturaID = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoID = new System.Windows.Forms.TextBox();
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
            this.lblInteresPorV = new System.Windows.Forms.Label();
            this.lblTotalConInteresE = new System.Windows.Forms.Label();
            this.lblInteresValE = new System.Windows.Forms.Label();
            this.lblTotalConInteresV = new System.Windows.Forms.Label();
            this.lblInteresValV = new System.Windows.Forms.Label();
            this.butNuevaNotaPedido = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblTotalFacturado = new System.Windows.Forms.Label();
            this.lblSaldoPagos = new System.Windows.Forms.Label();
            this.lblTotalPagos = new System.Windows.Forms.Label();
            this.butImprimirFactura = new System.Windows.Forms.Button();
            this.butSuspender2 = new System.Windows.Forms.Button();
            this.butCancelar2 = new System.Windows.Forms.Button();
            this.butCrearRemitos = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbContado = new System.Windows.Forms.GroupBox();
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
            this.cbCtadoCtaCte = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbFormaPagoID = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbContado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MediumBlue;
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
            this.label18.BackColor = System.Drawing.Color.MediumBlue;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(800, 32);
            this.label18.TabIndex = 114;
            this.label18.Text = "     Nueva Nota de Pedido";
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl1
            // 
            this.tabControl1.CausesValidation = false;
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
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.cbRegaloEmpresario);
            this.groupBox3.Controls.Add(this.cbVendedor);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbCondicionEntrega);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbDireccionEntrega);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(792, 104);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(240, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(184, 16);
            this.label17.TabIndex = 13;
            this.label17.Text = "Regalo Empresario";
            // 
            // cbRegaloEmpresario
            // 
            this.cbRegaloEmpresario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegaloEmpresario.ItemHeight = 13;
            this.cbRegaloEmpresario.Location = new System.Drawing.Point(240, 72);
            this.cbRegaloEmpresario.Name = "cbRegaloEmpresario";
            this.cbRegaloEmpresario.Size = new System.Drawing.Size(208, 21);
            this.cbRegaloEmpresario.TabIndex = 9;
            // 
            // cbVendedor
            // 
            this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedor.Items.AddRange(new object[] {
															"Inmediata",
															"Diferida"});
            this.cbVendedor.Location = new System.Drawing.Point(240, 32);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(208, 21);
            this.cbVendedor.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(240, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vendedor";
            // 
            // cbCondicionEntrega
            // 
            this.cbCondicionEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionEntrega.Items.AddRange(new object[] {
																	"Inmediata",
																	"Diferida"});
            this.cbCondicionEntrega.Location = new System.Drawing.Point(8, 72);
            this.cbCondicionEntrega.Name = "cbCondicionEntrega";
            this.cbCondicionEntrega.Size = new System.Drawing.Size(208, 21);
            this.cbCondicionEntrega.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Condición de Entrega";
            // 
            // tbDireccionEntrega
            // 
            this.tbDireccionEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccionEntrega.Location = new System.Drawing.Point(8, 32);
            this.tbDireccionEntrega.Name = "tbDireccionEntrega";
            this.tbDireccionEntrega.Size = new System.Drawing.Size(208, 20);
            this.tbDireccionEntrega.TabIndex = 6;
            this.tbDireccionEntrega.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dirección de Entrega";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butConsumidorFinal);
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
            // butConsumidorFinal
            // 
            this.butConsumidorFinal.BackColor = System.Drawing.SystemColors.Control;
            this.butConsumidorFinal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butConsumidorFinal.Image = ((System.Drawing.Image)(resources.GetObject("butConsumidorFinal.Image")));
            this.butConsumidorFinal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butConsumidorFinal.Location = new System.Drawing.Point(496, 72);
            this.butConsumidorFinal.Name = "butConsumidorFinal";
            this.butConsumidorFinal.Size = new System.Drawing.Size(144, 24);
            this.butConsumidorFinal.TabIndex = 13;
            this.butConsumidorFinal.Text = "F2 - Consumidor Final";
            this.butConsumidorFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butConsumidorFinal.Click += new System.EventHandler(this.butConsumidorFinal_Click);
            // 
            // tbClienteID
            // 
            this.tbClienteID.Location = new System.Drawing.Point(752, 8);
            this.tbClienteID.Name = "tbClienteID";
            this.tbClienteID.Size = new System.Drawing.Size(40, 20);
            this.tbClienteID.TabIndex = 12;
            this.tbClienteID.Text = "0";
            this.tbClienteID.Visible = false;
            // 
            // cbIVA
            // 
            this.cbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIVA.Items.AddRange(new object[] {
													   "Inmediata",
													   "Diferida"});
            this.cbIVA.Location = new System.Drawing.Point(240, 32);
            this.cbIVA.Name = "cbIVA";
            this.cbIVA.Size = new System.Drawing.Size(208, 21);
            this.cbIVA.TabIndex = 2;
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
            this.tbCUIT.Size = new System.Drawing.Size(208, 20);
            this.tbCUIT.TabIndex = 4;
            this.tbCUIT.Text = "";
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
            this.butBuscarCliente.BackColor = System.Drawing.SystemColors.Control;
            this.butBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarCliente.Image")));
            this.butBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarCliente.Location = new System.Drawing.Point(496, 32);
            this.butBuscarCliente.Name = "butBuscarCliente";
            this.butBuscarCliente.Size = new System.Drawing.Size(144, 24);
            this.butBuscarCliente.TabIndex = 5;
            this.butBuscarCliente.Text = "F1 - Buscar Cliente";
            this.butBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarCliente.Click += new System.EventHandler(this.butBuscarCliente_Click);
            // 
            // tbDireccion
            // 
            this.tbDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccion.Location = new System.Drawing.Point(8, 72);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(208, 20);
            this.tbDireccion.TabIndex = 3;
            this.tbDireccion.Text = "";
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
            // butSiguiente
            // 
            this.butSiguiente.BackColor = System.Drawing.SystemColors.Control;
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(496, 216);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(144, 24);
            this.butSiguiente.TabIndex = 10;
            this.butSiguiente.Text = "F3 - Continuar";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(192, 89);
            this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
            this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
            this.butBorrarArticulosComponentes.TabIndex = 155;
            this.butBorrarArticulosComponentes.Text = "&Borrar";
            this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarArticulosComponentes.Click += new System.EventHandler(this.butBorrarArticulosComponentes_Click);
            // 
            // dgSubArticulos
            // 
            this.dgSubArticulos.CaptionBackColor = System.Drawing.Color.MediumBlue;
            this.dgSubArticulos.CaptionForeColor = System.Drawing.Color.White;
            this.dgSubArticulos.CaptionText = "Artículos";
            this.dgSubArticulos.DataMember = "";
            this.dgSubArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSubArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSubArticulos.Location = new System.Drawing.Point(0, 88);
            this.dgSubArticulos.Name = "dgSubArticulos";
            this.dgSubArticulos.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgSubArticulos.Size = new System.Drawing.Size(792, 198);
            this.dgSubArticulos.TabIndex = 157;
            this.dgSubArticulos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									   this.dataGridTableStyle1});
            this.dgSubArticulos.CurrentCellChanged += new System.EventHandler(this.dgSubArticulos_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.dgSubArticulos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridBoolColumn1,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "v_Articulo";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "#  .";
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
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn17.Format = "C";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "P.U.+IVA   .";
            this.dataGridTextBoxColumn17.MappingName = "precioUnitarioIVA";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn9.Format = "C";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Subtotal  .";
            this.dataGridTextBoxColumn9.MappingName = "precioTotal";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.FalseValue = false;
            this.dataGridBoolColumn1.HeaderText = "Promo";
            this.dataGridBoolColumn1.MappingName = "promocion";
            this.dataGridBoolColumn1.NullValue = ((object)(resources.GetObject("dataGridBoolColumn1.NullValue")));
            this.dataGridBoolColumn1.TrueValue = true;
            this.dataGridBoolColumn1.Width = 50;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Descuento  .";
            this.dataGridTextBoxColumn10.MappingName = "descuento";
            this.dataGridTextBoxColumn10.Width = 50;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn11.Format = "C";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Total  .";
            this.dataGridTextBoxColumn11.MappingName = "precioTotalConDesc";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butBonificacion);
            this.groupBox1.Controls.Add(this.lblBonificacion);
            this.groupBox1.Controls.Add(this.butContinuar2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblSubTotal2);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblIva2);
            this.groupBox1.Controls.Add(this.lblIva1);
            this.groupBox1.Controls.Add(this.lblSubTotal1);
            this.groupBox1.Controls.Add(this.cbAutorizadorBonificacion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbBonificacion);
            this.groupBox1.Controls.Add(this.butSuspender);
            this.groupBox1.Controls.Add(this.butCancelar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 112);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            // 
            // butBonificacion
            // 
            this.butBonificacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBonificacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBonificacion.Location = new System.Drawing.Point(8, 8);
            this.butBonificacion.Name = "butBonificacion";
            this.butBonificacion.Size = new System.Drawing.Size(96, 23);
            this.butBonificacion.TabIndex = 159;
            this.butBonificacion.Text = "F4 - Bonificación";
            this.butBonificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBonificacion.Click += new System.EventHandler(this.butBonificacion_Click);
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBonificacion.CurrencyDecimalSeparator = ",";
            this.lblBonificacion.CurrencyGroupSeparator = ".";
            this.lblBonificacion.CurrencySymbol = "$";
            this.lblBonificacion.DecimalsDigits = 2;
            this.lblBonificacion.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblBonificacion.Location = new System.Drawing.Point(520, 32);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(80, 20);
            this.lblBonificacion.TabIndex = 158;
            this.lblBonificacion.Text = "$ 0,00";
            this.lblBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lblBonificacion.Validating += new System.ComponentModel.CancelEventHandler(this.lblBonificacion_Validating);
            // 
            // butContinuar2
            // 
            this.butContinuar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butContinuar2.Image = ((System.Drawing.Image)(resources.GetObject("butContinuar2.Image")));
            this.butContinuar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinuar2.Location = new System.Drawing.Point(208, 64);
            this.butContinuar2.Name = "butContinuar2";
            this.butContinuar2.Size = new System.Drawing.Size(144, 23);
            this.butContinuar2.TabIndex = 157;
            this.butContinuar2.Text = "F3 - Continuar";
            this.butContinuar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butContinuar2.Click += new System.EventHandler(this.butContinuar2_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.label12.Location = new System.Drawing.Point(456, 56);
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
            this.label10.Location = new System.Drawing.Point(440, 32);
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
            this.lblSubTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblSubTotal2.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblSubTotal2.Location = new System.Drawing.Point(680, 32);
            this.lblSubTotal2.Name = "lblSubTotal2";
            this.lblSubTotal2.Size = new System.Drawing.Size(96, 24);
            this.lblSubTotal2.TabIndex = 150;
            this.lblSubTotal2.Text = "0";
            this.lblSubTotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.lblIva2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.lblIva1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblIva1.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblIva1.Location = new System.Drawing.Point(520, 56);
            this.lblIva1.Name = "lblIva1";
            this.lblIva1.Size = new System.Drawing.Size(80, 24);
            this.lblIva1.TabIndex = 146;
            this.lblIva1.Text = "0";
            this.lblIva1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal1
            // 
            this.lblSubTotal1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubTotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.cbAutorizadorBonificacion.Location = new System.Drawing.Point(208, 8);
            this.cbAutorizadorBonificacion.Name = "cbAutorizadorBonificacion";
            this.cbAutorizadorBonificacion.Size = new System.Drawing.Size(144, 21);
            this.cbAutorizadorBonificacion.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(160, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 24);
            this.label8.TabIndex = 34;
            this.label8.Text = "Autoriza";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBonificacion
            // 
            this.tbBonificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBonificacion.Location = new System.Drawing.Point(112, 8);
            this.tbBonificacion.Name = "tbBonificacion";
            this.tbBonificacion.Size = new System.Drawing.Size(40, 20);
            this.tbBonificacion.TabIndex = 32;
            this.tbBonificacion.Text = "0";
            this.tbBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBonificacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbBonificacion_MouseDown);
            this.tbBonificacion.Validating += new System.ComponentModel.CancelEventHandler(this.tbBonificacion_Validating);
            this.tbBonificacion.Enter += new System.EventHandler(this.tbBonificacion_Enter);
            // 
            // butSuspender
            // 
            this.butSuspender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender.Image")));
            this.butSuspender.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSuspender.Location = new System.Drawing.Point(8, 48);
            this.butSuspender.Name = "butSuspender";
            this.butSuspender.Size = new System.Drawing.Size(144, 24);
            this.butSuspender.TabIndex = 30;
            this.butSuspender.Text = "F5 - Suspender";
            this.butSuspender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar.Location = new System.Drawing.Point(8, 80);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(144, 24);
            this.butCancelar.TabIndex = 29;
            this.butCancelar.Text = "F12 - Cancelar";
            this.butCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbPrecioIVAAC);
            this.groupBox5.Controls.Add(this.butNuevoArticulo);
            this.groupBox5.Controls.Add(this.tbFacturaID);
            this.groupBox5.Controls.Add(this.tbNotaPedidoID);
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
            // tbPrecioIVAAC
            // 
            this.tbPrecioIVAAC.Location = new System.Drawing.Point(744, 8);
            this.tbPrecioIVAAC.Name = "tbPrecioIVAAC";
            this.tbPrecioIVAAC.Size = new System.Drawing.Size(16, 20);
            this.tbPrecioIVAAC.TabIndex = 153;
            this.tbPrecioIVAAC.Text = "";
            this.tbPrecioIVAAC.Visible = false;
            // 
            // butNuevoArticulo
            // 
            this.butNuevoArticulo.BackColor = System.Drawing.Color.Gainsboro;
            this.butNuevoArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butNuevoArticulo.Image = ((System.Drawing.Image)(resources.GetObject("butNuevoArticulo.Image")));
            this.butNuevoArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNuevoArticulo.Location = new System.Drawing.Point(8, 56);
            this.butNuevoArticulo.Name = "butNuevoArticulo";
            this.butNuevoArticulo.Size = new System.Drawing.Size(176, 24);
            this.butNuevoArticulo.TabIndex = 152;
            this.butNuevoArticulo.Text = "[F2] Nuevo Artículo";
            this.butNuevoArticulo.Visible = false;
            this.butNuevoArticulo.Click += new System.EventHandler(this.butNuevoArticulo_Click);
            // 
            // tbFacturaID
            // 
            this.tbFacturaID.Location = new System.Drawing.Point(640, 8);
            this.tbFacturaID.Name = "tbFacturaID";
            this.tbFacturaID.Size = new System.Drawing.Size(16, 20);
            this.tbFacturaID.TabIndex = 151;
            this.tbFacturaID.Text = "";
            this.tbFacturaID.Visible = false;
            // 
            // tbNotaPedidoID
            // 
            this.tbNotaPedidoID.Location = new System.Drawing.Point(704, 8);
            this.tbNotaPedidoID.Name = "tbNotaPedidoID";
            this.tbNotaPedidoID.Size = new System.Drawing.Size(16, 20);
            this.tbNotaPedidoID.TabIndex = 150;
            this.tbNotaPedidoID.Text = "";
            this.tbNotaPedidoID.Visible = false;
            // 
            // tbPromocionAC
            // 
            this.tbPromocionAC.Location = new System.Drawing.Point(656, 8);
            this.tbPromocionAC.Name = "tbPromocionAC";
            this.tbPromocionAC.Size = new System.Drawing.Size(16, 20);
            this.tbPromocionAC.TabIndex = 149;
            this.tbPromocionAC.Text = "";
            this.tbPromocionAC.Visible = false;
            // 
            // tbPrecioAC
            // 
            this.tbPrecioAC.Location = new System.Drawing.Point(672, 8);
            this.tbPrecioAC.Name = "tbPrecioAC";
            this.tbPrecioAC.Size = new System.Drawing.Size(16, 20);
            this.tbPrecioAC.TabIndex = 148;
            this.tbPrecioAC.Text = "";
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
            this.butAgregarArticuloAC.Visible = false;
            // 
            // tbCodigoBarrasAC
            // 
            this.tbCodigoBarrasAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoBarrasAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.tbCodigoBarrasAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoBarrasAC.Location = new System.Drawing.Point(96, 32);
            this.tbCodigoBarrasAC.Name = "tbCodigoBarrasAC";
            this.tbCodigoBarrasAC.Size = new System.Drawing.Size(88, 21);
            this.tbCodigoBarrasAC.TabIndex = 134;
            this.tbCodigoBarrasAC.Text = "";
            this.tbCodigoBarrasAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatosIngresoArticulos_KeyDown);
            this.tbCodigoBarrasAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoBarrasAC_KeyPress);
            this.tbCodigoBarrasAC.Leave += new System.EventHandler(this.tbCodigoBarrasAC_Leave);
            this.tbCodigoBarrasAC.Enter += new System.EventHandler(this.tbCodigoBarrasAC_Enter);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(688, 8);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(16, 20);
            this.tbID.TabIndex = 147;
            this.tbID.Text = "";
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
            this.tbCodigoInternoAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.tbCodigoInternoAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoInternoAC.Location = new System.Drawing.Point(8, 32);
            this.tbCodigoInternoAC.Name = "tbCodigoInternoAC";
            this.tbCodigoInternoAC.Size = new System.Drawing.Size(80, 21);
            this.tbCodigoInternoAC.TabIndex = 133;
            this.tbCodigoInternoAC.Text = "";
            this.tbCodigoInternoAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatosIngresoArticulos_KeyDown);
            this.tbCodigoInternoAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoInternoAC_KeyPress);
            this.tbCodigoInternoAC.Leave += new System.EventHandler(this.tbCodigoInternoAC_Leave);
            this.tbCodigoInternoAC.Enter += new System.EventHandler(this.tbCodigoInternoAC_Enter);
            // 
            // tbDescripcionAC
            // 
            this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.tbSubRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.tbSubRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbSubRubroAC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbSubRubroAC.Location = new System.Drawing.Point(416, 32);
            this.tbSubRubroAC.Name = "tbSubRubroAC";
            this.tbSubRubroAC.Size = new System.Drawing.Size(112, 48);
            this.tbSubRubroAC.TabIndex = 145;
            // 
            // tbRubroAC
            // 
            this.tbRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.butBuscarArticuloAC.Size = new System.Drawing.Size(32, 40);
            this.butBuscarArticuloAC.TabIndex = 137;
            this.butBuscarArticuloAC.Text = "[F1]";
            this.butBuscarArticuloAC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscarArticuloAC.Click += new System.EventHandler(this.butBuscarArticuloAC_Click);
            this.butBuscarArticuloAC.Enter += new System.EventHandler(this.butBuscarArticuloAC_Enter);
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
            this.tbCantidadAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.tbCantidadAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCantidadAC.Location = new System.Drawing.Point(192, 32);
            this.tbCantidadAC.Name = "tbCantidadAC";
            this.tbCantidadAC.Size = new System.Drawing.Size(48, 21);
            this.tbCantidadAC.TabIndex = 135;
            this.tbCantidadAC.Text = "";
            this.tbCantidadAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCantidadAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatosIngresoArticulos_KeyDown);
            this.tbCantidadAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidadAC_KeyPress);
            this.tbCantidadAC.Leave += new System.EventHandler(this.tbCantidadAC_Leave);
            this.tbCantidadAC.Enter += new System.EventHandler(this.tbCantidadAC_Enter);
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
            this.butBorrarPagos.Click += new System.EventHandler(this.butBorrarPagos_Click);
            // 
            // dgPagos
            // 
            this.dgPagos.CaptionBackColor = System.Drawing.Color.Brown;
            this.dgPagos.CaptionForeColor = System.Drawing.Color.White;
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
            this.groupBox6.Controls.Add(this.lblInteresPorV);
            this.groupBox6.Controls.Add(this.lblTotalConInteresE);
            this.groupBox6.Controls.Add(this.lblInteresValE);
            this.groupBox6.Controls.Add(this.lblTotalConInteresV);
            this.groupBox6.Controls.Add(this.lblInteresValV);
            this.groupBox6.Controls.Add(this.butNuevaNotaPedido);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.lblTotalFacturado);
            this.groupBox6.Controls.Add(this.lblSaldoPagos);
            this.groupBox6.Controls.Add(this.lblTotalPagos);
            this.groupBox6.Controls.Add(this.butImprimirFactura);
            this.groupBox6.Controls.Add(this.butSuspender2);
            this.groupBox6.Controls.Add(this.butCancelar2);
            this.groupBox6.Controls.Add(this.butCrearRemitos);
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
            this.lblInteresPorE.Text = "Interés  %";
            this.lblInteresPorE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresPorE.Visible = false;
            // 
            // lblInteresPorV
            // 
            this.lblInteresPorV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInteresPorV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.lblTotalConInteresV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.lblInteresValV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblInteresValV.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblInteresValV.Location = new System.Drawing.Point(488, 40);
            this.lblInteresValV.Name = "lblInteresValV";
            this.lblInteresValV.Size = new System.Drawing.Size(96, 24);
            this.lblInteresValV.TabIndex = 159;
            this.lblInteresValV.Text = "0";
            this.lblInteresValV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresValV.Visible = false;
            // 
            // butNuevaNotaPedido
            // 
            this.butNuevaNotaPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butNuevaNotaPedido.Image = ((System.Drawing.Image)(resources.GetObject("butNuevaNotaPedido.Image")));
            this.butNuevaNotaPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNuevaNotaPedido.Location = new System.Drawing.Point(8, 80);
            this.butNuevaNotaPedido.Name = "butNuevaNotaPedido";
            this.butNuevaNotaPedido.Size = new System.Drawing.Size(248, 24);
            this.butNuevaNotaPedido.TabIndex = 158;
            this.butNuevaNotaPedido.Text = "(&N)ueva Nota de Pedido";
            this.butNuevaNotaPedido.Click += new System.EventHandler(this.butNuevaNotaPedido_Click);
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.label34.Text = "Total Facturado";
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
            this.lblTotalFacturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.lblSaldoPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
            this.lblTotalPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblTotalPagos.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalPagos.Location = new System.Drawing.Point(488, 16);
            this.lblTotalPagos.Name = "lblTotalPagos";
            this.lblTotalPagos.Size = new System.Drawing.Size(96, 24);
            this.lblTotalPagos.TabIndex = 145;
            this.lblTotalPagos.Text = "0";
            this.lblTotalPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butImprimirFactura
            // 
            this.butImprimirFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirFactura.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirFactura.Image")));
            this.butImprimirFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirFactura.Location = new System.Drawing.Point(8, 16);
            this.butImprimirFactura.Name = "butImprimirFactura";
            this.butImprimirFactura.Size = new System.Drawing.Size(120, 24);
            this.butImprimirFactura.TabIndex = 31;
            this.butImprimirFactura.Text = "(&I)mprimir Factura";
            this.butImprimirFactura.Click += new System.EventHandler(this.butImprimirFactura_Click);
            // 
            // butSuspender2
            // 
            this.butSuspender2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender2.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender2.Image")));
            this.butSuspender2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender2.Location = new System.Drawing.Point(136, 16);
            this.butSuspender2.Name = "butSuspender2";
            this.butSuspender2.Size = new System.Drawing.Size(120, 24);
            this.butSuspender2.TabIndex = 30;
            this.butSuspender2.Text = "(&S)uspender";
            this.butSuspender2.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // butCancelar2
            // 
            this.butCancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar2.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar2.Image")));
            this.butCancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar2.Location = new System.Drawing.Point(136, 48);
            this.butCancelar2.Name = "butCancelar2";
            this.butCancelar2.Size = new System.Drawing.Size(120, 24);
            this.butCancelar2.TabIndex = 29;
            this.butCancelar2.Text = "Cancelar (&X)";
            this.butCancelar2.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // butCrearRemitos
            // 
            this.butCrearRemitos.Enabled = false;
            this.butCrearRemitos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCrearRemitos.Image = ((System.Drawing.Image)(resources.GetObject("butCrearRemitos.Image")));
            this.butCrearRemitos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCrearRemitos.Location = new System.Drawing.Point(8, 48);
            this.butCrearRemitos.Name = "butCrearRemitos";
            this.butCrearRemitos.Size = new System.Drawing.Size(120, 24);
            this.butCrearRemitos.TabIndex = 28;
            this.butCrearRemitos.Text = "Crear (&R)emito/s";
            this.butCrearRemitos.Click += new System.EventHandler(this.butCrearRemitos_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gbContado);
            this.groupBox4.Controls.Add(this.cbCtadoCtaCte);
            this.groupBox4.Controls.Add(this.label15);
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
            this.gbContado.Location = new System.Drawing.Point(152, 8);
            this.gbContado.Name = "gbContado";
            this.gbContado.Size = new System.Drawing.Size(632, 80);
            this.gbContado.TabIndex = 155;
            this.gbContado.TabStop = false;
            this.gbContado.Text = "Contado";
            // 
            // cbAdicional
            // 
            this.cbAdicional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdicional.Location = new System.Drawing.Point(176, 56);
            this.cbAdicional.Name = "cbAdicional";
            this.cbAdicional.Size = new System.Drawing.Size(160, 21);
            this.cbAdicional.TabIndex = 154;
            this.cbAdicional.Visible = false;
            this.cbAdicional.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormaPago_KeyPress);
            this.cbAdicional.SelectedIndexChanged += new System.EventHandler(this.cbAdicional_SelectedIndexChanged);
            // 
            // tbAdicional
            // 
            this.tbAdicional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAdicional.Location = new System.Drawing.Point(176, 56);
            this.tbAdicional.Name = "tbAdicional";
            this.tbAdicional.Size = new System.Drawing.Size(160, 20);
            this.tbAdicional.TabIndex = 153;
            this.tbAdicional.Text = "";
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
            this.butAgregarPago.Location = new System.Drawing.Point(560, 19);
            this.butAgregarPago.Name = "butAgregarPago";
            this.butAgregarPago.Size = new System.Drawing.Size(72, 37);
            this.butAgregarPago.TabIndex = 158;
            this.butAgregarPago.Text = "(&A)gregar";
            this.butAgregarPago.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.cbTipoPagoDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormaPago_KeyPress);
            this.cbTipoPagoDetalle.SelectedIndexChanged += new System.EventHandler(this.cbTipoPagoDetalle_SelectedIndexChanged);
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPago.Location = new System.Drawing.Point(8, 32);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.Size = new System.Drawing.Size(160, 21);
            this.cbTipoPago.TabIndex = 151;
            this.cbTipoPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormaPago_KeyPress);
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
            this.tbImportePago.Leave += new System.EventHandler(this.tbImportePago_Leave);
            this.tbImportePago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbImportePago_KeyPress);
            this.tbImportePago.Validated += new System.EventHandler(this.tbImportePago_Validated);
            this.tbImportePago.Enter += new System.EventHandler(this.tbImportePago_Enter);
            // 
            // cbCtadoCtaCte
            // 
            this.cbCtadoCtaCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCtadoCtaCte.Location = new System.Drawing.Point(8, 40);
            this.cbCtadoCtaCte.Name = "cbCtadoCtaCte";
            this.cbCtadoCtaCte.Size = new System.Drawing.Size(136, 21);
            this.cbCtadoCtaCte.TabIndex = 154;
            this.cbCtadoCtaCte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormaPago_KeyPress);
            this.cbCtadoCtaCte.SelectedIndexChanged += new System.EventHandler(this.cbCtadoCtaCte_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 153;
            this.label15.Text = "Contado/Cta. Cte.";
            // 
            // tbFormaPagoID
            // 
            this.tbFormaPagoID.Location = new System.Drawing.Point(8, 64);
            this.tbFormaPagoID.Name = "tbFormaPagoID";
            this.tbFormaPagoID.Size = new System.Drawing.Size(16, 20);
            this.tbFormaPagoID.TabIndex = 149;
            this.tbFormaPagoID.Text = "";
            this.tbFormaPagoID.Visible = false;
            // 
            // ucNotaPedidoAlta
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label18);
            this.Name = "ucNotaPedidoAlta";
            this.Size = new System.Drawing.Size(800, 456);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gbContado.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion



        //Llena los comboBox y demas inicializaciones
        public void inicializarComponentes()
        {
            try
            {
                //Llena los combos
                //Obtiene todos los vendedores de la sucursal actual
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
                UtilUI.llenarCombo(ref cbVendedor, this.conexion, "sp_getAllVendedorsBySucursal", "", -1, param);
                UtilUI.llenarCombo(ref cbAutorizadorBonificacion, this.conexion, "sp_getAllVendedorsBySucursal", "", -1, param);

                UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", 1);
                UtilUI.llenarCombo(ref cbRegaloEmpresario, this.conexion, "sp_getAlltv_NotaPedidoRegaloEmpresarios", "", 2);
                UtilUI.llenarCombo(ref cbCondicionEntrega, this.conexion, "sp_getAlltv_NotaPedidoCondicionEntrega", "", 2);

                cbCondicionEntrega.SelectedIndex = 0;

                //Asigna la tabla a la datagrid
                dgSubArticulos.DataSource = (DataTable)dataset.Tables["v_Articulo"];
                dgPagos.DataSource = (DataTable)datasetFormaPagoLineas.Tables["v_FormaPagoLinea"];


                //Controles del Tab Formas de Pago
                UtilUI.llenarCombo(ref cbCtadoCtaCte, this.conexion, "sp_getAlltv_PlazoPago", "", 0);
                UtilUI.llenarCombo(ref cbTipoPago, this.conexion, "sp_getAlltv_TipoPago", "", 0);
                UtilUI.llenarCombo(ref cbAdicional, this.conexion, "sp_getAlltv_CantidadPagos", "", 0);
                llenarTipoPagoDetalle();

                tbClienteID.Text = Utilidades.ID_VACIO;
                tbFormaPagoID.Text = Utilidades.ID_VACIO;
                tbID.Text = Utilidades.ID_VACIO;
                tbNotaPedidoID.Text = Utilidades.ID_VACIO;

                //Le da el foco al primer control de texto para escribir la razon social del cliente
                tbClienteNombre.Select();

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
            /*************************************
             * Navegador de la Solapa Cabecera
             * ***********************************/
            //Carga las teclas rapidas primero
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscarCliente, 0, (char)Keys.F1));
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butConsumidorFinal, 1, (char)Keys.F2));
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butSiguiente, 2, (char)Keys.F3));

            //Carga los controles
            navegador.agregarControl(new CapsulaControl((Control)tbClienteNombre, 0));
            navegador.agregarControl(new CapsulaControl((Control)tbDireccion, 1));
            navegador.agregarControl(new CapsulaControl((Control)cbIVA, 2));
            navegador.agregarControl(new CapsulaControl((Control)tbCUIT, 3));
            navegador.agregarControl(new CapsulaControl((Control)tbDireccionEntrega, 4));
            navegador.agregarControl(new CapsulaControl((Control)cbVendedor, 5));
            navegador.agregarControl(new CapsulaControl((Control)cbCondicionEntrega, 6));
            navegador.agregarControl(new CapsulaControl((Control)cbRegaloEmpresario, 7));
            navegador.agregarControl(new CapsulaControl((Control)butSiguiente, 8));

            //Agrega los handlers para todos los controles del control contenedor
            navegador.agregarHandlersContenedor(tabControl1.TabPages[0]);


            /*************************************
             * Navegador de la Solapa Items
             * ***********************************/
            //Carga las teclas rapidas primero
            navegadorItems.agregarControlTeclaRapida(new CapsulaControl((Control)butBonificacion, 0, (char)Keys.F4));
            navegadorItems.agregarControlTeclaRapida(new CapsulaControl((Control)butContinuar2, 1, (char)Keys.F3));
            navegadorItems.agregarControlTeclaRapida(new CapsulaControl((Control)butSuspender, 2, (char)Keys.F5));
            navegadorItems.agregarControlTeclaRapida(new CapsulaControl((Control)butCancelar, 3, (char)Keys.F12));

            //Carga los controles
            navegadorItems.agregarControl(new CapsulaControl((Control)butBonificacion, 0));
            navegadorItems.agregarControl(new CapsulaControl((Control)tbBonificacion, 1));
            navegadorItems.agregarControl(new CapsulaControl((Control)cbAutorizadorBonificacion, 2));
            navegadorItems.agregarControl(new CapsulaControl((Control)lblBonificacion, 3));
            navegadorItems.agregarControl(new CapsulaControl((Control)butContinuar2, 4));

            //Agrega los handlers para todos los controles del control contenedor
            navegadorItems.agregarHandlersContenedor(tabControl1.TabPages[1]);
        }

        //Llena el combo TipoPagoDetalle
        private void llenarTipoPagoDetalle()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@tipoPagoID", new System.Guid(cbTipoPago.SelectedValue.ToString()));
                UtilUI.llenarCombo(ref cbTipoPagoDetalle, this.conexion, "sp_getAlltv_TipoPagoDetalle", "", -1, param);
                if (cbTipoPagoDetalle.Items.Count > 0)
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
                string razonSocial = "", direccion = "", cuit = "";
                string ivaID = Utilidades.ID_VACIO;

                this.Cursor = Cursors.WaitCursor;

                string sparam = "", sp = "";
                sparam = "@clienteID";
                sp = "sp_getClienteByID";

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter(sparam, new System.Guid(clienteID));
                SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

                //Si se encontro el registro
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["Empresa"].ToString() != "")
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
                    ivaID = Utilidades.ID_VACIO;
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
                tbDireccion.Text = direccion;
                tbCUIT.Text = cuit;
                //cbIVA.SelectedIndex = ivaID;
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



        private void tbCodigoInternoAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
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

        private bool buscarArticulo(string tipoCodigo, string codigo)
        {
            return buscarArticulo(tipoCodigo, codigo, Utilidades.ID_VACIO);
        }

        private bool buscarArticulo(string tipoCodigo, string codigo, string p_articuloID)
        {
            try
            {
                bool encontrado = false;

                if (tipoCodigo != "" || codigo != "" || p_articuloID != Utilidades.ID_VACIO)
                {
                    string rubro = "", subRubro = "", descripcion = "", codigoInterno = "", codigoBarras = "", articuloID = Utilidades.ID_VACIO;
                    string precio = "", promocion = "", precioIVA = "";

                    this.Cursor = Cursors.WaitCursor;

                    string sparam = "", sp = "";
                    if (p_articuloID != Utilidades.ID_VACIO)
                    {
                        codigo = p_articuloID;
                        sparam = "@articuloID";
                        sp = "sp_getArticuloByID";
                    }
                    else if (tipoCodigo == "CodigoInterno")
                    {
                        sparam = "@codigoInterno";
                        sp = "sp_getArticuloByCodigoInterno";
                    }
                    else if (tipoCodigo == "CodigoBarras")
                    {
                        sparam = "@codigoBarras";
                        sp = "sp_getArticuloByCodigoBarras";
                    }

                    //string valorCelda = codigo;
                    SqlParameter[] param = new SqlParameter[1];

                    if (p_articuloID != Utilidades.ID_VACIO)
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
                        precioIVA = double.Parse(dr["precioUnitarioIVA"].ToString()).ToString("N");
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
                        if (p_articuloID != Utilidades.ID_VACIO)
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
                    tbPrecioIVAAC.Text = precioIVA;
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
                if (foco == "Enter")
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
            tbCodigoInternoAC.Select();
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
                if (e.KeyChar == (char)Keys.Enter)
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
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (Utilidades.IsNumeric(tbCantidadAC.Text))
                    {
                        agregarArticulo(ref tbCodigoUsado);
                    }
                    else
                    {
                        MessageBox.Show("La Cantidad debe ser un valor numérico.", "Valor Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    DataRow newRow = tabla.NewRow();
                    newRow["Código Interno"] = tbCodigoInternoAC.Text;
                    newRow["Código de Barras"] = tbCodigoBarrasAC.Text;
                    newRow["Cantidad"] = tbCantidadAC.Text;
                    newRow["Rubro"] = tbRubroAC.Text;
                    newRow["Sub Rubro"] = tbSubRubroAC.Text;
                    newRow["Descripción"] = tbDescripcionAC.Text;
                    newRow["articuloID"] = tbID.Text;

                    //Verifica si hay que agregar el IVA al articulo
                    decimal precioUnitario = decimal.Parse(tbPrecioAC.Text);
                    string idenIVA = UtilUI.obtenerIdentificadorCombo(ref cbIVA);
                    if (idenIVA == "M" || idenIVA == "F")
                    {
                        precioUnitario = precioUnitario + ((precioUnitario / 100) * decimal.Parse(configuracion.obtenerParametro("IVA1").ToString()));
                        precioUnitario = Decimal.Round(precioUnitario, 2);
                    }
                    newRow["precio"] = precioUnitario;

                    //Agrega el precio con IVA
                    decimal precioUnitarioIVA = decimal.Parse(tbPrecioIVAAC.Text);
                    precioUnitarioIVA = Decimal.Round(precioUnitarioIVA, 2);
                    newRow["precioUnitarioIVA"] = precioUnitarioIVA;

                    newRow["promocion"] = bool.Parse(tbPromocionAC.Text);
                    newRow["itemNro"] = tabla.Rows.Count + 1;
                    newRow["descuento"] = 0;
                    newRow["precioTotal"] = decimal.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
                    newRow["precioTotalConDesc"] = decimal.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
                    tabla.Rows.Add(newRow);

                    //Limpia los codigos
                    tbCodigoInternoAC.Text = "";
                    tbCodigoBarrasAC.Text = "";
                    tbRubroAC.Text = "";
                    tbSubRubroAC.Text = "";
                    tbDescripcionAC.Text = "";
                    tbID.Text = "";
                    tbPrecioAC.Text = "";
                    tbPrecioIVAAC.Text = "";
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
                if (dgSubArticulos.DataSource != null)
                {
                    DataTable dt = (DataTable)dgSubArticulos.DataSource;
                    if (dt.Rows.Count > 0)
                    {
                        //Primero recorre los renglones seleccionados
                        string sRows = "";
                        string coma = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dgSubArticulos.IsSelected(i))
                            {
                                sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
                                coma = ",";
                            }
                        }

                        if (sRows != "")
                        {
                            DialogResult dr = MessageBox.Show("¿Desea borrar los Artículos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Artículos...", true);
                                string[] rows = sRows.Split(",".ToCharArray());
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    string id = rows[j].Split(":".ToCharArray())[0];
                                    int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

                                    //dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = "-1";
                                }
                                //Recorre los renglones marcados para borrar
                                DataRow[] rowsBorrar = dt.Select("id='-1'");
                                for (int k = 0; k < rowsBorrar.Length; k++)
                                {
                                    rowsBorrar[k].Delete();
                                }
                                dt.AcceptChanges();

                                //Renumera los items
                                renumerarItems();

                                calcularSubTotales();

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

                for (int i = 0; i < dt.Rows.Count; i++)
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
                if (((DataTable)dgSubArticulos.DataSource).Rows.Count == 0)
                {
                    mensaje += "   - Debe ingresar al menos un Artículo.\r\n";
                    resultado = false;
                }


                if (mensaje != "")
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

                string simportePago = tbImportePago.CurrencyValue().Replace(".", "");
                double importePago = double.Parse(simportePago);
                if (importePago <= 0)
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

                if (mensaje != "")
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
                tbNotaPedidoID.Text = Utilidades.ID_VACIO;
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
                tbClienteNombre.Text = "";
                tbClienteID.Text = Utilidades.ID_VACIO;
                tbDireccion.Text = "";
                tbCUIT.Text = "";
                tbDireccionEntrega.Text = "";
                tabControl1.SelectedIndex = 0;
                //Totales
                tbBonificacion.Text = "0";
                lblSubTotal1.Text = "0";
                lblSubTotal2.Text = "0";
                lblBonificacion.Text = "0";
                lblIva1.Text = "0";
                lblIva2.Text = "0";
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

                butCrearRemitos.Enabled = false;
                butSuspender.Enabled = true;
                butSuspender2.Enabled = true;
                butImprimirFactura.Enabled = true;
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

        private void butBuscarCliente_Click(object sender, System.EventArgs e)
        {
            abrirConsultaRapida();
        }

        //Calcula el precio de toda la grilla
        private void calcularPreciosTotalesGrilla()
        {
            try
            {
                DataTable dt = (DataTable)dgSubArticulos.DataSource;
                dt.AcceptChanges();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Calcula el precio
                    dt.Rows[i]["precioTotal"] = double.Parse(dt.Rows[i]["Precio"].ToString()) * int.Parse(dt.Rows[i]["Cantidad"].ToString());

                    //Si en descuento no hay un numero, asigna un cero.
                    if (!Utilidades.IsNumeric(dt.Rows[i]["descuento"].ToString()))
                        dt.Rows[i]["descuento"] = 0;

                    //Calcula el descuento //
                    double precioTotal = double.Parse(dt.Rows[i]["precioTotal"].ToString());
                    double descuento = double.Parse(dt.Rows[i]["descuento"].ToString());
                    double precioTotalConDesc = precioTotal - (precioTotal / 100 * descuento);

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
                UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Nota de Pedido...", true);
                if (validarFormularioCabecera(true))
                {
                    guardarNotaPedido("SUSPENDIDA");  //Estado 1: suspendida.

                    //Limpia el formulario para que otro vendedor siga con otra Nota de Pedido
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
        private bool validarFormularioCabecera(bool suspender)
        {
            try
            {
                string mensaje = "";
                bool resultado = true;


                if (tbClienteNombre.Text == "")
                {
                    mensaje += "   - Debe escribir el Nombre del Cliente.\r\n";
                    resultado = false;
                }

                tbCUIT.Text = Utilidades.limpiarCUIT(tbCUIT.Text);
                if (UtilUI.obtenerIdentificadorCombo(ref cbIVA) != "F" && !Utilidades.validarCUIT(tbCUIT.Text))
                {
                    mensaje += "   - CUIT con formato erróneo.\r\n";
                    resultado = false;
                }

                if (!suspender)
                {
                    if (UtilUI.obtenerIdentificadorCombo(ref cbCtadoCtaCte) != "CUENTA_CORRIENTE" &&
                        double.Parse(lblTotalPagos.Text, NumberStyles.Currency) == 0)
                    {
                        mensaje += "   - Debe indicar la Forma de Pago.\r\n";
                        resultado = false;
                    }
                }

                if (mensaje != "")
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

        private bool guardarNotaPedido(string estado)
        {
            DocumentoFiscalXML fx = new DocumentoFiscalXML(this.configuracion);
            return guardarNotaPedido(ref fx, estado);
        }

        //Guarda la Nota de Pedido con el estado que se le indique.
        private bool guardarNotaPedido(ref DocumentoFiscalXML fx, string estado)
        {
            try
            {
                //Primero guarda las formas de pago
                guardarFormasDePago();

                bool resultado = true;

                //Obtiene el numero de nota de pedido
                string notaPedidoSuc = "", notaPedidoNro = "";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
                param[1] = new SqlParameter("@notaPedidoSuc", notaPedidoSuc);
                param[1].Direction = ParameterDirection.InputOutput;
                param[2] = new SqlParameter("@notaPedidoNro", notaPedidoNro);
                param[2].Direction = ParameterDirection.InputOutput;

                SqlDataReader drNotaPedidoNro = SqlHelper.ExecuteReader(this.conexion, "sp_getNuevoNotaPedidoNro", param);
                if (drNotaPedidoNro.HasRows)
                {
                    drNotaPedidoNro.Read();
                    notaPedidoSuc = drNotaPedidoNro["notaPedidoSuc"].ToString();
                    notaPedidoNro = drNotaPedidoNro["notaPedidoNro"].ToString();
                }

                //Obtiene los valores
                DateTime fecha_creacion = DateTime.Now;
                string clienteID = tbClienteID.Text;
                string nombreCliente = tbClienteNombre.Text;
                string ivaIDCliente = cbIVA.SelectedValue.ToString();
                string direccionCliente = tbDireccion.Text;
                string cuitCliente = tbCUIT.Text;
                string direccionEntrega = tbDireccionEntrega.Text;
                string vendedorID = cbVendedor.SelectedValue.ToString();
                string condicionEntregaID = cbCondicionEntrega.SelectedValue.ToString();
                double bonificacion = double.Parse(tbBonificacion.Text);
                string autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
                double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
                double iva1 = double.Parse(lblIva1.Text, NumberStyles.Currency);
                double iva2 = double.Parse(lblIva2.Text, NumberStyles.Currency);
                double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
                string estadoNotaPedidoID = estado;
                string maquinaID = configuracion.maquina.id.ToString();
                double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
                double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
                string formaPagoID = tbFormaPagoID.Text == "" ? Utilidades.ID_VACIO : tbFormaPagoID.Text;
                string regaloEmpresarioID = cbRegaloEmpresario.SelectedValue.ToString();

                param = new SqlParameter[23];

                param[0] = new SqlParameter("@fecha_creacion", fecha_creacion);
                param[1] = new SqlParameter("@clienteID", new System.Guid(clienteID));
                param[2] = new SqlParameter("@nombreCliente", nombreCliente);
                param[3] = new SqlParameter("@ivaIDCliente", new System.Guid(ivaIDCliente));
                param[4] = new SqlParameter("@direccionCliente", direccionCliente);
                param[5] = new SqlParameter("@cuitCliente", cuitCliente);
                param[6] = new SqlParameter("@direccionEntrega", direccionEntrega);
                param[7] = new SqlParameter("@vendedorID", new System.Guid(vendedorID));
                param[8] = new SqlParameter("@condicionEntregaID", new System.Guid(condicionEntregaID));
                param[9] = new SqlParameter("@bonificacion", bonificacion);
                param[10] = new SqlParameter("@autorizadorBonificacionID", new System.Guid(autorizadorBonificacionID));
                param[11] = new SqlParameter("@subTotal1", subTotal1);
                param[12] = new SqlParameter("@iva1", iva1);
                param[13] = new SqlParameter("@iva2", iva2);
                param[14] = new SqlParameter("@total", total);
                param[15] = new SqlParameter("@estadoNotaPedido", estado);
                param[16] = new SqlParameter("@maquinaID", configuracion.maquina.id);
                param[17] = new SqlParameter("@subTotal2", subTotal2);
                param[18] = new SqlParameter("@bonificacionImporte", bonificacionImporte);
                param[19] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                param[20] = new SqlParameter("@regaloEmpresarioID", new System.Guid(regaloEmpresarioID));
                param[21] = new SqlParameter("@notaPedidoSuc", notaPedidoSuc);
                param[22] = new SqlParameter("@notaPedidoNro", notaPedidoNro);

                while (true)
                {
                    try
                    {
                        DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;

                        //Inserta el registro y obtiene el ID
                        SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevaNotaPedido", param);

                        //Inserta los articulos
                        if (dr.HasRows)
                        {
                            dr.Read();
                            string notaPedidoID = dr["ID"].ToString();

                            //Guarda el ID de nota de pedido
                            if (fx != null)
                                fx.notaPedidoID = new Guid(notaPedidoID);

                            tbNotaPedidoID.Text = notaPedidoID.ToString();
                            string articuloID = Utilidades.ID_VACIO;
                            string cantidad = "0";
                            double descuento = 0;
                            int itemNro = 0;
                            string aplicaPromocion = "2";
                            double precioTotal = 0;
                            double precioTotalConDesc = 0;
                            double precioUnitario = 0;

                            for (int i = 0; i < dtSubArticulos.Rows.Count; i++)
                            {
                                cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
                                if (cantidad.Trim() != "")
                                {
                                    articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
                                    descuento = double.Parse(dtSubArticulos.Rows[i]["descuento"].ToString(), NumberStyles.Any);
                                    itemNro = int.Parse(dtSubArticulos.Rows[i]["itemNro"].ToString());
                                    aplicaPromocion = dtSubArticulos.Rows[i]["promocion"].ToString();
                                    aplicaPromocion = aplicaPromocion == "True" ? "1" : "2";
                                    precioTotal = double.Parse(dtSubArticulos.Rows[i]["precioTotal"].ToString());
                                    precioTotalConDesc = double.Parse(dtSubArticulos.Rows[i]["precioTotalConDesc"].ToString());
                                    precioUnitario = double.Parse(dtSubArticulos.Rows[i]["precio"].ToString());
                                    param = new SqlParameter[9];
                                    param[0] = new SqlParameter("@notaPedidoID", new System.Guid(notaPedidoID));
                                    param[1] = new SqlParameter("@cantidad", cantidad);
                                    param[2] = new SqlParameter("@articuloID", new System.Guid(articuloID));
                                    param[3] = new SqlParameter("@descuento", descuento);
                                    param[4] = new SqlParameter("@itemNro", itemNro);
                                    param[5] = new SqlParameter("@aplicaPromocion", aplicaPromocion);
                                    param[6] = new SqlParameter("@precioTotal", precioTotal);
                                    param[7] = new SqlParameter("@precioTotalConDesc", precioTotalConDesc);
                                    param[8] = new SqlParameter("@precioUnitario", precioUnitario);
                                    SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertNotaPedidoLinea", param);
                                }
                            }
                        }
                        dr.Close();

                        //Esto lo  hace cuando guarda la factura 
                        /*
                        //Actualiza el stock si es una factura de entrega inmediata
                        if (cbCondicionEntrega.Text=="Inmediata" && estado=="FACTURADA")
                        {
                            ControlStock cs = new ControlStock(this.configuracion);
                            cs.disminuirExistencia(dtSubArticulos, "articuloID", "cantidad");
                            cs = null;
                        }*/

                        MessageBox.Show("Nota de Pedido Nro.: " + notaPedidoSuc + "-" + notaPedidoNro + " guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Pedido guardada con éxito.", false);

                        //Limpia el formulario
                        //limpiarFormulario();

                        resultado = true;
                        break;
                    }
                    catch (Exception e)
                    {
                        ManejadorErrores.escribirLog(e, true);
                        DialogResult dr = MessageBox.Show("No se pudo guardar la Nota de Pedido. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Nota de Pedido. \r\n" + e.Message, false);
                        if (dr != DialogResult.Retry)
                        {
                            resultado = false;
                            break;
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }


        //Guarda la nueva factura.
        private bool guardarFactura(DocumentoFiscalXML fx)
        {
            try
            {
                bool resultado = true;

                //Obtiene el numero de Factura
                string facturaSuc = this.configuracion.sucursal.numero.ToString("0000");
                string facturaNro = fx.comprobanteNumero.ToString("00000000");
                string facturaTipo = fx.comprobanteTipo;

                //Obtiene los valores
                DateTime fecha_creacion = DateTime.Now;
                string clienteID = tbClienteID.Text;
                string nombreCliente = tbClienteNombre.Text;
                string ivaIDCliente = cbIVA.SelectedValue.ToString();
                string direccionCliente = tbDireccion.Text;
                string cuitCliente = tbCUIT.Text;
                string direccionEntrega = tbDireccionEntrega.Text;
                string vendedorID = cbVendedor.SelectedValue.ToString();
                string condicionEntregaID = cbCondicionEntrega.SelectedValue.ToString();
                double bonificacion = double.Parse(tbBonificacion.Text);
                string autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
                double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
                double iva1 = double.Parse(lblIva1.Text, NumberStyles.Currency);
                double iva2 = double.Parse(lblIva2.Text, NumberStyles.Currency);
                double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
                string estadoFactura = "IMPRESA";
                string maquinaID = configuracion.maquina.id.ToString();
                double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
                double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
                string formaPagoID = tbFormaPagoID.Text == "" ? Utilidades.ID_VACIO : tbFormaPagoID.Text;
                Guid jornadaVentaID = this.configuracion.JornadaVentaID;
                string estadoCuentaCorriente;
                string regaloEmpresarioID = cbRegaloEmpresario.SelectedValue.ToString();
                DateTime fecha_vencimiento = fecha_creacion.AddDays(30);

                //Establece el estado de la factura, para saber si es en cuenta corriente
                if (UtilUI.obtenerIdentificadorCombo(ref cbCtadoCtaCte) == "CUENTA_CORRIENTE")
                    estadoCuentaCorriente = "PENDIENTE";
                else
                    estadoCuentaCorriente = "PAGADA";


                SqlParameter[] param = new SqlParameter[29];

                param[0] = new SqlParameter("@fecha_creacion", fecha_creacion);
                param[1] = new SqlParameter("@clienteID", new System.Guid(clienteID));
                param[2] = new SqlParameter("@nombreCliente", nombreCliente);
                param[3] = new SqlParameter("@ivaIDCliente", new System.Guid(ivaIDCliente));
                param[4] = new SqlParameter("@direccionCliente", direccionCliente);
                param[5] = new SqlParameter("@cuitCliente", cuitCliente);
                param[6] = new SqlParameter("@direccionEntrega", direccionEntrega);
                param[7] = new SqlParameter("@vendedorID", new System.Guid(vendedorID));
                param[8] = new SqlParameter("@condicionEntregaID", new System.Guid(condicionEntregaID));
                param[9] = new SqlParameter("@bonificacion", bonificacion);
                param[10] = new SqlParameter("@autorizadorBonificacionID", new System.Guid(autorizadorBonificacionID));
                param[11] = new SqlParameter("@subTotal1", subTotal1);
                param[12] = new SqlParameter("@iva1", iva1);
                param[13] = new SqlParameter("@iva2", iva2);
                param[14] = new SqlParameter("@total", total);
                param[15] = new SqlParameter("@estadoFactura", estadoFactura);
                param[16] = new SqlParameter("@maquinaID", configuracion.maquina.id);
                param[17] = new SqlParameter("@subTotal2", subTotal2);
                param[18] = new SqlParameter("@bonificacionImporte", bonificacionImporte);
                param[19] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                param[20] = new SqlParameter("@facturaSuc", facturaSuc);
                param[21] = new SqlParameter("@facturaNro", facturaNro);
                param[22] = new SqlParameter("@facturaTipo", facturaTipo);
                param[23] = new SqlParameter("@jornadaVentaID", jornadaVentaID);
                param[24] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
                param[25] = new SqlParameter("@notaPedidoID", fx.notaPedidoID);
                param[26] = new SqlParameter("@estadoCuentaCorriente", estadoCuentaCorriente);
                param[27] = new SqlParameter("@regaloEmpresarioID", new System.Guid(regaloEmpresarioID));
                param[28] = new SqlParameter("@fecha_vencimiento", fecha_vencimiento);

                while (true)
                {
                    try
                    {
                        DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;

                        //Inserta el registro y obtiene el ID
                        SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevaFactura", param);

                        //Inserta los articulos
                        if (dr.HasRows)
                        {
                            dr.Read();
                            string facturaID = dr["ID"].ToString();
                            tbFacturaID.Text = facturaID.ToString();
                            string articuloID = Utilidades.ID_VACIO;
                            string cantidad = "0";
                            double descuento = 0;
                            int itemNro = 0;
                            string aplicaPromocion = "2";
                            double precioTotal = 0;
                            double precioTotalConDesc = 0;
                            double precioUnitario = 0;

                            for (int i = 0; i < dtSubArticulos.Rows.Count; i++)
                            {
                                cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
                                if (cantidad.Trim() != "")
                                {
                                    articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
                                    descuento = double.Parse(dtSubArticulos.Rows[i]["descuento"].ToString(), NumberStyles.Any);
                                    itemNro = int.Parse(dtSubArticulos.Rows[i]["itemNro"].ToString());
                                    aplicaPromocion = dtSubArticulos.Rows[i]["promocion"].ToString();
                                    aplicaPromocion = aplicaPromocion == "True" ? "1" : "2";
                                    precioTotal = double.Parse(dtSubArticulos.Rows[i]["precioTotal"].ToString());
                                    precioTotalConDesc = double.Parse(dtSubArticulos.Rows[i]["precioTotalConDesc"].ToString());
                                    precioUnitario = double.Parse(dtSubArticulos.Rows[i]["precio"].ToString());
                                    param = new SqlParameter[9];
                                    param[0] = new SqlParameter("@facturaID", new System.Guid(facturaID));
                                    param[1] = new SqlParameter("@cantidad", cantidad);
                                    param[2] = new SqlParameter("@articuloID", new System.Guid(articuloID));
                                    param[3] = new SqlParameter("@descuento", descuento);
                                    param[4] = new SqlParameter("@itemNro", itemNro);
                                    param[5] = new SqlParameter("@aplicaPromocion", aplicaPromocion);
                                    param[6] = new SqlParameter("@precioTotal", precioTotal);
                                    param[7] = new SqlParameter("@precioTotalConDesc", precioTotalConDesc);
                                    param[8] = new SqlParameter("@precioUnitario", precioUnitario);
                                    SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertFacturaLinea", param);
                                }
                            }
                        }
                        dr.Close();

                        /*** Esto lo debe hacer solo cuando Imprime la factura ***/
                        //Actualiza el stock si es una factura de entrega inmediata
                        if (cbCondicionEntrega.Text == "Inmediata") // && estado=="FACTURADA")
                        {
                            ControlStock cs = new ControlStock(this.configuracion);
                            cs.disminuirExistencia(dtSubArticulos, "articuloID", "cantidad");
                            cs = null;
                        }

                        //MessageBox.Show("Nota de Pedido guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Pedido guardada con éxito.", false);

                        //Limpia el formulario
                        //limpiarFormulario();

                        resultado = true;
                        break;
                    }
                    catch (Exception e)
                    {
                        ManejadorErrores.escribirLog(e, true);
                        DialogResult dr = MessageBox.Show("No se pudo guardar la Factura. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Factura. \r\n" + e.Message, false);
                        if (dr != DialogResult.Retry)
                        {
                            resultado = false;
                            break;
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
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
                            tbFormaPagoID.Text = formaPagoID;
                            string tipoPagoID = Utilidades.ID_VACIO;
                            string tipoPagoDetalleID = Utilidades.ID_VACIO;
                            double importe = 0;
                            double ajuste = 0;
                            double pesos = 0;
                            string nroCheque = "";
                            string bancoID = Utilidades.ID_VACIO;
                            string cantidadPagosID = Utilidades.ID_VACIO;

                            DataTable dtPagos = (DataTable)dgPagos.DataSource;
                            for (int i = 0; i < dtPagos.Rows.Count; i++)
                            {
                                tipoPagoID = dtPagos.Rows[i]["tipoPagoID"].ToString();
                                tipoPagoDetalleID = dtPagos.Rows[i]["tipoPagoDetalleID"].ToString();
                                importe = double.Parse(dtPagos.Rows[i]["importe"].ToString());
                                ajuste = double.Parse(dtPagos.Rows[i]["ajuste"].ToString());
                                pesos = double.Parse(dtPagos.Rows[i]["pesos"].ToString());
                                nroCheque = dtPagos.Rows[i]["Nro. Cheque"].ToString();
                                bancoID = dtPagos.Rows[i]["bancoID"].ToString();
                                cantidadPagosID = dtPagos.Rows[i]["cantidadPagosID"].ToString();

                                param = new SqlParameter[9];
                                param[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                                param[1] = new SqlParameter("@tipoPagoID", new System.Guid(tipoPagoID));
                                param[2] = new SqlParameter("@tipoPagoDetalleID", new System.Guid(tipoPagoDetalleID));
                                param[3] = new SqlParameter("@importe", importe);
                                param[4] = new SqlParameter("@ajuste", ajuste);
                                param[5] = new SqlParameter("@pesos", pesos);
                                param[6] = new SqlParameter("@nroCheque", nroCheque);
                                param[7] = new SqlParameter("@bancoID", new System.Guid(bancoID));
                                param[8] = new SqlParameter("@cantidadPagosID", new System.Guid(cantidadPagosID));
                                SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertFormaPagoLinea", param);
                            }
                        }
                        else
                            tbFormaPagoID.Text = Utilidades.ID_VACIO;

                        dr.Close();

                        //MessageBox.Show("Nota de Pedido guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Pedido guardada con éxito.", false);

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
        {
            try
            {
                if (((DataTable)dgSubArticulos.DataSource).Rows.Count > 0)
                {
                    //Subtotal 1
                    decimal subTotal1 = (decimal)((DataTable)dgSubArticulos.DataSource).Compute("Sum(precioTotalConDesc)", "");
                    lblSubTotal1.Text = subTotal1.ToString("C");

                    //Bonificacion
                    decimal bonificacionPorc = decimal.Parse(tbBonificacion.Text);
                    decimal bonificacionImp = subTotal1 / 100 * bonificacionPorc;
                    lblBonificacion.Text = bonificacionImp.ToString("C");

                    //Subtotal 2
                    decimal subTotal2 = subTotal1 - bonificacionImp;
                    lblSubTotal2.Text = subTotal2.ToString("C");

                    //Iva 1
                    //Si es Responsable inscripto, calcula el IVA
                    string idIVA = UtilUI.obtenerIdentificadorCombo(ref cbIVA).ToString();
                    decimal iva1Porc = 0;
                    decimal iva1Imp = 0;
                    if (idIVA == "I")
                    {
                        iva1Porc = decimal.Parse((string)configuracion.obtenerParametro("IVA1").ToString());
                        iva1Imp = (subTotal2 / 100) * iva1Porc;
                        lblIva1.Text = iva1Imp.ToString("C");
                    }
                    //Iva 2   No hay para Ligier.
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


        //Calcula los subtotales para los Pagos
        private void calcularSubTotalesPagos()
        {
            try
            {
                decimal totalPagos = 0;
                if (((DataTable)dgPagos.DataSource).Rows.Count > 0)
                {
                    //Total Pagos
                    totalPagos = (decimal)((DataTable)dgPagos.DataSource).Compute("Sum(Pesos)", "");
                }

                lblTotalPagos.Text = totalPagos.ToString("C");

                //Total Facturado
                decimal totalFacturado = decimal.Parse(lblTotal.Text, NumberStyles.Currency);
                lblTotalFacturado.Text = totalFacturado.ToString("C");

                //Total con Interes
                decimal totalConInteres = decimal.Parse(lblTotalConInteresV.Text, NumberStyles.Currency);
                if (totalConInteres == 0)
                    totalConInteres = totalFacturado;

                //Saldo
                decimal saldoPagos = totalConInteres - totalPagos;
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
                    calcularSubTotales();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butCrearRemitos_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmRemitoAlta frmRemit = new frmRemitoAlta(this.configuracion);
                frmRemit.statusBar1 = this.statusBarPrincipal;
                frmRemit.toolBar2 = null;
                frmRemit.Show();
                frmRemit.ucRemitoAlta1.buscarNotaPedido(tbNotaPedidoID.Text);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butImprimirFactura_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (validarFormularioCabecera(false))
                {
                    butImprimirFactura.Enabled = false;

                    //Luego la imprime
                    if (imprimirNotaPedido(tbNotaPedidoID.Text))
                    {
                        butCrearRemitos.Enabled = true;
                        butSuspender.Enabled = false;
                        butSuspender2.Enabled = false;
                        butImprimirFactura.Enabled = false;

                        //Limpia el formulario para una nueva Nota de Pedido
                        limpiarFormulario();
                    }
                    else
                    {
                        butImprimirFactura.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Imprime la Nota de Pedido
        private bool imprimirNotaPedido(string notaPedidoID)
        {
            bool res1 = false, res2 = true;
            DocumentoFiscalXML fx = generarImpresionXML();
            if (fx != null)
                if (fx.mensajeServidor == "")
                {
                    res1 = guardarNotaPedido(ref fx, "FACTURADA");  //Guarda con el Estado 1: Facturada.
                    res2 = guardarFactura(fx);
                }
                else
                {
                    MessageBox.Show(fx.mensajeServidor, "Error de impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                MessageBox.Show("No se pudo generar el objeto FacturaXML.", "Error de impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return (res1 && res2);
        }

        //Genera un objeto Factura para imprimirlo
        /*
        private FacturaImpresion generarImpresion()
        {
            try
            {
                FacturaImpresion fi = new FacturaImpresion(this.configuracion);
				
                fi.PrinterOCX = this.axPrinterFiscal1;
                fi.nombreCliente = tbClienteNombre.Text;
                fi.direccionCliente = tbDireccion.Text;
                fi.ivaCliente = cbIVA.Text;
                fi.cuitCliente = tbCUIT.Text;
                fi.direccionEntrega = tbDireccionEntrega.Text;
                fi.condicionEntrega = cbCondicionEntrega.Text;
                fi.vendedor = cbVendedor.Text;
				
                if (UtilUI.obtenerIdentificadorCombo(ref cbIVA)=="I")
                {
                    fi.comprobanteTipo = "A";
                    fi.comprobanteCopias = 3;
                }
                else
                {
                    fi.comprobanteTipo = "B";  
                    fi.comprobanteCopias = 2; 
                }

                //Toma el identificador del iva
                DataTable dtIva = (DataTable)cbIVA.DataSource;
                fi.ivaIdentificador = dtIva.Rows[cbIVA.SelectedIndex]["identificador"].ToString();

                fi.items = (DataTable)dgSubArticulos.DataSource;
                fi.bonifPorcentaje = double.Parse(tbBonificacion.Text);
                fi.autorizadorBonificacion = cbAutorizadorBonificacion.Text;
                fi.bonifImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
                fi.formasPago = (DataTable)dgPagos.DataSource;

                fi.imprimir();   //Imprime el formulario.
				
                return fi;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }*/

        //Genera un objeto FacturaXML para enviarlo
        private DocumentoFiscalXML generarImpresionXML()
        {
            try
            {
                DocumentoFiscalXML fx = new DocumentoFiscalXML(this.configuracion);

                fx.documentoNombre = "FA";
                fx.nombreCliente = tbClienteNombre.Text;
                fx.direccionCliente = tbDireccion.Text;
                fx.ivaCliente = cbIVA.Text;
                fx.cuitCliente = tbCUIT.Text;
                fx.direccionEntrega = tbDireccionEntrega.Text;
                fx.condicionEntrega = cbCondicionEntrega.Text;
                fx.vendedor = cbVendedor.Text;

                if (UtilUI.obtenerIdentificadorCombo(ref cbIVA) == "I")
                {
                    fx.comprobanteTipo = "A";
                    fx.comprobanteCopias = 3;
                }
                else
                {
                    fx.comprobanteTipo = "B";
                    fx.comprobanteCopias = 2;
                }

                //Toma el identificador del iva
                DataTable dtIva = (DataTable)cbIVA.DataSource;
                fx.ivaIdentificador = dtIva.Rows[cbIVA.SelectedIndex]["identificador"].ToString();

                fx.items = (DataTable)dgSubArticulos.DataSource;
                fx.bonifPorcentaje = double.Parse(tbBonificacion.Text);
                fx.autorizadorBonificacion = cbAutorizadorBonificacion.Text;
                fx.bonifImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
                fx.formasPago = (DataTable)dgPagos.DataSource;

                fx.plazoPago = UtilUI.obtenerIdentificadorCombo(ref cbCtadoCtaCte);

                //Aqui debe esperar la respuesta del servidor.
                fx.enviarPaquete();   //Imprime el formulario.
                fx.recibirRespuesta();

                return fx;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }

        private void butNuevaNotaPedido_Click(object sender, System.EventArgs e)
        {
            limpiarFormulario();
        }

        private void butSiguiente_Click(object sender, System.EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            tbCodigoInternoAC.Select();
            Application.DoEvents();
            tbCodigoInternoAC.Select();
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
                if (cbCtadoCtaCte.SelectedIndex > -1)
                {
                    DataTable dtPlazo = (DataTable)cbCtadoCtaCte.DataSource;

                    if (dtPlazo.Rows[cbCtadoCtaCte.SelectedIndex]["identificador"].ToString() == "CONTADO")
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
                if (cbTipoPago.SelectedIndex > -1)
                {
                    DataTable dtTipoPago = (DataTable)cbTipoPago.DataSource;

                    if (dtTipoPago.Rows[cbTipoPago.SelectedIndex]["operacion"].ToString() == "CAMBIO")
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
                                calcularSubTotalesPagos();
                                break;
                            }
                        case "CHEQUES":
                            {
                                lblAdicional.Text = "Cheque Nro.";
                                lblAdicional.Visible = true;
                                tbAdicional.Text = "";
                                tbAdicional.Visible = true;
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
                calcularSubTotalesPagos();
                if (cbAdicional.SelectedIndex > -1 && cbAdicional.Visible)
                {
                    DataTable dtCantidadPagos = (DataTable)cbAdicional.DataSource;
                    double interesPor = double.Parse(dtCantidadPagos.Rows[cbAdicional.SelectedIndex]["interes"].ToString());
                    double totalFacturado = double.Parse(lblTotalFacturado.Text, NumberStyles.Currency);

                    double interesVal = 0;
                    if (totalFacturado != 0)
                        interesVal = (totalFacturado / 100) * interesPor;
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
                convertirDivisa("");

                string identificadorTipoPago = ((DataTable)cbTipoPago.DataSource).Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
                string detalle = cbTipoPagoDetalle.Text;
                switch (identificadorTipoPago)
                {
                    case "CHEQUES":
                        detalle += ", Nro. " + tbAdicional.Text;
                        break;
                    case "T_CREDITO":
                        detalle += ", " + cbAdicional.Text;
                        break;
                }
                //Agrega un registro a la tabla de la grilla
                DataTable tabla = (DataTable)dgPagos.DataSource;
                DataRow newRow = tabla.NewRow();
                newRow["tipoPagoID"] = cbTipoPago.SelectedValue;
                newRow["Tipo Pago"] = cbTipoPago.Text;
                newRow["tipoPagoDetalleID"] = cbTipoPagoDetalle.SelectedValue != null ? cbTipoPagoDetalle.SelectedValue : Utilidades.ID_VACIO;
                newRow["Detalle"] = detalle;
                newRow["Importe"] = double.Parse(tbImportePago.CurrencyValue(), NumberStyles.Currency);
                newRow["Ajuste"] = double.Parse(lblAjusteValor.Text, NumberStyles.Currency);
                newRow["Pesos"] = double.Parse(tbPesos.CurrencyValue(), NumberStyles.Currency);
                newRow["Nro. Cheque"] = tbAdicional.Text;

                DataTable dtTipoPagoDetalle = ((DataTable)cbTipoPagoDetalle.DataSource);
                string bancoID = Utilidades.ID_VACIO;
                if (dtTipoPagoDetalle.Rows.Count > 0)
                    bancoID = dtTipoPagoDetalle.Rows[cbTipoPagoDetalle.SelectedIndex]["bancoID"].ToString();

                newRow["bancoID"] = bancoID;

                newRow["cantidadPagosID"] = cbAdicional.SelectedValue;

                tabla.Rows.Add(newRow);

                //Limpia el importe
                tbImportePago.Text = "$ 0,00";
                tbAdicional.Text = "";

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

                if (ajuste > 0)
                {
                    if (tipoPago == "DIVISAS")
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
                    if (tipoPago == "DIVISAS")
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

                if (dtDetalle.Rows.Count > 0)
                {
                    string nombreParametro = dtDetalle.Rows[cbTipoPagoDetalle.SelectedIndex]["ajuste"].ToString();

                    double valorAjuste = 0;
                    if (nombreParametro != "")
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
            if (e.KeyChar == (char)Keys.Enter)
                if (validarPago())
                    agregarPago();
        }


        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                tbClienteNombre.Select();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                tbCodigoInternoAC.Select();
            }
            //si el es tab de formas de pago, calcula los subtotales
            if (tabControl1.SelectedIndex == 2)
            {
                cbCtadoCtaCte.Select();
                calcularSubTotalesPagos();
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
                if (dgPagos.DataSource != null)
                {
                    DataTable dt = (DataTable)dgPagos.DataSource;

                    if (dt.Rows.Count > 0)
                    {
                        //Primero recorre los renglones seleccionados
                        string sRows = "";
                        string coma = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dgPagos.IsSelected(i))
                            {
                                sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
                                coma = ",";
                            }
                        }

                        if (sRows != "")
                        {
                            DialogResult dr = MessageBox.Show("¿Desea borrar los Pagos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Pagos...", true);
                                string[] rows = sRows.Split(",".ToCharArray());
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    string id = rows[j].Split(":".ToCharArray())[0];
                                    int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

                                    //dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = "-1";
                                }
                                //Recorre los renglones marcados para borrar
                                DataRow[] rowsBorrar = dt.Select("id='-1'");
                                for (int k = 0; k < rowsBorrar.Length; k++)
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
            //Asigna el boton default al formulario contenedor
            this.formContenedor.AcceptButton = this.butAgregarPago;
        }
        private void tbImportePago_Leave(object sender, System.EventArgs e)
        {
            this.formContenedor.AcceptButton = null;
        }

        private void DatosCliente_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                butBuscarCliente_Click(sender, e);
        }

        private void DatosIngresoArticulos_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                butBuscarArticuloAC_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
                butNuevoArticulo_Click(sender, e);

            //tbCodigoInternoAC_KeyPress(sender, new KeyPressEventArgs((char)e.KeyValue));
        }

        private void FormaPago_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            butAgregarPago_Click(sender, e);
        }

        private void butNuevoArticulo_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmArticuloAlta form = new frmArticuloAlta(this.configuracion);
                //form.statusBar1 = this.statusBarPrincipal;

                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tabControl1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            if (tab.SelectedIndex == 0) //Cabecera
                DatosCliente_KeyDown(sender, e);
            else if (tab.SelectedIndex == 1) //Items
                DatosIngresoArticulos_KeyDown(sender, e);
        }

        private void butConsumidorFinal_Click(object sender, System.EventArgs e)
        {
            ponerConsumidorFinal();
        }

        //Pone los datos del cliente Consumidor Final
        private void ponerConsumidorFinal()
        {
            this.Cursor = Cursors.WaitCursor;
            Cliente cliente = new Cliente(this.configuracion);
            SqlDataReader drCliente = cliente.getByApellidoyNombres("Consumidor", "Final");

            if (drCliente.HasRows)
            {
                drCliente.Read();
                tbClienteNombre.Text = drCliente["apellido"].ToString() + " " + drCliente["nombres"].ToString();
                UtilUI.comboSeleccionarItemByIdentificador("F", ref cbIVA);
                tbDireccion.Text = "";
                tbCUIT.Text = "00000000";
                tbClienteID.Text = drCliente["id"].ToString();
            }

            drCliente.Close();
            drCliente = null;
            cliente = null;

            this.Cursor = Cursors.Default;
        }

        private void lblBonificacion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                KMCurrencyTextBox.KMCurrencyTextBox tb = (KMCurrencyTextBox.KMCurrencyTextBox)sender;
                decimal subtotal = decimal.Parse(lblSubTotal1.Text, NumberStyles.Currency);
                decimal importeBon = decimal.Parse(tb.CurrencyValue(), NumberStyles.Currency);
                decimal porcentaje = importeBon * 100 / subtotal;
                tbBonificacion.Text = decimal.Round(porcentaje, 2).ToString();
                calcularSubTotales();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butBonificacion_Click(object sender, System.EventArgs e)
        {
            tbBonificacion.Select();
            tbBonificacion.SelectAll();
        }

    }
}