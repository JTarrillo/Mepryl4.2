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
	/// Summary description for ucFacturaConsulta.
	/// </summary>
	public class ucFacturaConsulta : System.Windows.Forms.UserControl
	{
		
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		public bool consultaRapida = false;
		//public bool facturaDescuento = false;
        public string tipoPresentacion = "";
        public string clienteID = "";

		private Control tbCodigoUsado;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.ComponentModel.IContainer components;

		public DataSet dataset = (DataSet) new dsArticulos();
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.Button butAceptar1;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox tbCuitB;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbRazonSocialB;
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
		private System.Windows.Forms.TabControl tabNotaPedido;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button butContinuar1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cbEstado;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cbVendedor;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbCondicionEntrega;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbDireccionEntrega;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbFacturaID;
		private System.Windows.Forms.TextBox tbClienteID;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbIVA;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbCUIT;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butBuscarCliente;
		private System.Windows.Forms.TextBox tbDireccion;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbClienteNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.DataGrid dgSubArticulos;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox tbPromocionAC;
		private System.Windows.Forms.TextBox tbPrecioAC;
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
		private System.Windows.Forms.GroupBox gbPieItems;
		private System.Windows.Forms.Button butSuspender2;
		private System.Windows.Forms.Button butCancelar2;
		private System.Windows.Forms.Button butContinuar2;
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
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.Button butBorrarArticulosComponentes;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Button butBorrarPagos;
		private System.Windows.Forms.DataGrid dgPagos;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button butImprimirFactura;
		private System.Windows.Forms.Button butSuspender;
		private System.Windows.Forms.Button butCancelar;
		private System.Windows.Forms.Button butCrearRemitos;
		private System.Windows.Forms.GroupBox groupBox16;
		private System.Windows.Forms.Label lblRegistro2;
		private System.Windows.Forms.Button butSiguiente2;
		private System.Windows.Forms.Button butAnterior2;
		private System.Windows.Forms.Label lblInteresPorE;
		private System.Windows.Forms.Label lblInteresPorV;
		private System.Windows.Forms.Label lblTotalConInteresE;
		private System.Windows.Forms.Label lblInteresValE;
		private System.Windows.Forms.Label lblTotalConInteresV;
		private System.Windows.Forms.Label lblInteresValV;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label lblTotalFacturado;
		private System.Windows.Forms.Label lblSaldoPagos;
		private System.Windows.Forms.Label lblTotalPagos;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.GroupBox gbContado;
		private System.Windows.Forms.ComboBox cbAdicional;
		private System.Windows.Forms.TextBox tbAdicional;
		private System.Windows.Forms.Label lblAdicional;
		private KMCurrencyTextBox.KMCurrencyTextBox lblAjusteValor;
		private System.Windows.Forms.Button butAgregarPago;
		private KMCurrencyTextBox.KMCurrencyTextBox tbPesos;
		private System.Windows.Forms.Label lblAjusteEtiqueta;
		private System.Windows.Forms.Label lblPesos;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.ComboBox cbTipoPagoDetalle;
		private System.Windows.Forms.ComboBox cbTipoPago;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label16;
		private KMCurrencyTextBox.KMCurrencyTextBox tbImportePago;
		private System.Windows.Forms.ComboBox cbCtadoCtaCte;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tbFormaPagoID;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lbTitulo;
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn44;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn45;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn48;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn49;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn50;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn52;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn53;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn54;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn55;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn56;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn57;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn58;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.ComboBox cbEstadoB;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbCondicionEntregaB;
		private System.Windows.Forms.GroupBox gbProveedor;
		private System.Windows.Forms.ComboBox cbVendedorB;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionHasta;
		private System.Windows.Forms.DateTimePicker dtpFechaEmisionDesde;
		private System.Windows.Forms.CheckBox chkFechaEmision;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.TextBox tbEjercicioNroB;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox tbFacturaSucHastaB;
		private System.Windows.Forms.TextBox tbFacturaNroDesdeB;
		private System.Windows.Forms.TextBox tbFacturaNroHastaB;
		private System.Windows.Forms.TextBox tbFacturaSucDesdeB;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.ComboBox cbBonificacionB;
		private System.Windows.Forms.ComboBox cbAutorizadorB;
		private System.Windows.Forms.ComboBox cbFacturaTipoB;
		private System.Windows.Forms.DataGridTableStyle dgtsFacturaCompleta;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn51;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn59;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn60;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn61;
		private System.Windows.Forms.DataGridTableStyle dgtsFacturaDescuento;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn62;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn63;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn64;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn65;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn66;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn67;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn68;
		private System.Windows.Forms.Button butSalir2;
		private System.Windows.Forms.Button butLimpiar2;
		private System.Windows.Forms.Button butBuscar2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn69;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.ComboBox cbSucursalB;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.ComboBox cbPlazoPagoB;
		private System.Windows.Forms.GroupBox groupBox22;
		private System.Windows.Forms.ComboBox cbEstadoFacturaCtaCteB;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn70;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn71;
		private System.Windows.Forms.Button butLimpiar4;
		private System.Windows.Forms.Button butBuscar4;
		private System.Windows.Forms.Button butSalir4;
		private System.Windows.Forms.GroupBox gbCuentaCorrienteB;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox tbNotaPedidoSucHastaB;
		private System.Windows.Forms.TextBox tbNotaPedidoNroDesdeB;
		private System.Windows.Forms.TextBox tbNotaPedidoNroHastaB;
		private System.Windows.Forms.TextBox tbNotaPedidoSucDesdeB;
		private System.Windows.Forms.PrintDialog printDialog1;
        private TextBox tbClienteIDB;
        private Button butGuardarEstadoFactura;
		public DataSet datasetFormaPagoLineas = (DataSet) new dsFormaPagoLinea();

		public ucFacturaConsulta()
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
				if (m_configuracion!=null)
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFacturaConsulta));
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butVistaPrevia = new System.Windows.Forms.Button();
            this.butImprimir = new System.Windows.Forms.Button();
            this.butBorrar = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dgtsFacturaCompleta = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn59 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn60 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn61 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn70 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn71 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtsFacturaDescuento = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn62 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn63 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn64 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn65 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn66 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn67 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn68 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn69 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.cbAutorizadorB = new System.Windows.Forms.ComboBox();
            this.cbBonificacionB = new System.Windows.Forms.ComboBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.cbFacturaTipoB = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbFacturaSucHastaB = new System.Windows.Forms.TextBox();
            this.tbFacturaNroDesdeB = new System.Windows.Forms.TextBox();
            this.tbFacturaNroHastaB = new System.Windows.Forms.TextBox();
            this.tbFacturaSucDesdeB = new System.Windows.Forms.TextBox();
            this.gbFechaEmision = new System.Windows.Forms.GroupBox();
            this.dtpFechaEmisionHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaEmisionDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFechaEmision = new System.Windows.Forms.CheckBox();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbCuitB = new System.Windows.Forms.TextBox();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbClienteIDB = new System.Windows.Forms.TextBox();
            this.tbRazonSocialB = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.cbSucursalB = new System.Windows.Forms.ComboBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.tbEjercicioNroB = new System.Windows.Forms.TextBox();
            this.butSalir2 = new System.Windows.Forms.Button();
            this.butLimpiar2 = new System.Windows.Forms.Button();
            this.butBuscar2 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbNotaPedidoSucHastaB = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoNroDesdeB = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoNroHastaB = new System.Windows.Forms.TextBox();
            this.tbNotaPedidoSucDesdeB = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbEstadoB = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCondicionEntregaB = new System.Windows.Forms.ComboBox();
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.cbVendedorB = new System.Windows.Forms.ComboBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.gbCuentaCorrienteB = new System.Windows.Forms.GroupBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.cbEstadoFacturaCtaCteB = new System.Windows.Forms.ComboBox();
            this.butLimpiar4 = new System.Windows.Forms.Button();
            this.butBuscar4 = new System.Windows.Forms.Button();
            this.butSalir4 = new System.Windows.Forms.Button();
            this.cbPlazoPagoB = new System.Windows.Forms.ComboBox();
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
            this.tabNotaPedido = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.butContinuar1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.butGuardarEstadoFactura = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCondicionEntrega = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDireccionEntrega = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFacturaID = new System.Windows.Forms.TextBox();
            this.tbClienteID = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbIVA = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCUIT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butBuscarCliente = new System.Windows.Forms.Button();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClienteNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgSubArticulos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
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
            this.gbPieItems = new System.Windows.Forms.GroupBox();
            this.butSuspender2 = new System.Windows.Forms.Button();
            this.butCancelar2 = new System.Windows.Forms.Button();
            this.butContinuar2 = new System.Windows.Forms.Button();
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.butAnterior = new System.Windows.Forms.Button();
            this.butBorrarArticulosComponentes = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.butBorrarPagos = new System.Windows.Forms.Button();
            this.dgPagos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn55 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn56 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn57 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn58 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.butImprimirFactura = new System.Windows.Forms.Button();
            this.butSuspender = new System.Windows.Forms.Button();
            this.butCancelar = new System.Windows.Forms.Button();
            this.butCrearRemitos = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.lblRegistro2 = new System.Windows.Forms.Label();
            this.butSiguiente2 = new System.Windows.Forms.Button();
            this.butAnterior2 = new System.Windows.Forms.Button();
            this.lblInteresPorE = new System.Windows.Forms.Label();
            this.lblInteresPorV = new System.Windows.Forms.Label();
            this.lblTotalConInteresE = new System.Windows.Forms.Label();
            this.lblInteresValE = new System.Windows.Forms.Label();
            this.lblTotalConInteresV = new System.Windows.Forms.Label();
            this.lblInteresValV = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblTotalFacturado = new System.Windows.Forms.Label();
            this.lblSaldoPagos = new System.Windows.Forms.Label();
            this.lblTotalPagos = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
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
            this.label17 = new System.Windows.Forms.Label();
            this.tbFormaPagoID = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
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
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gbFechaEmision.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.gbCuentaCorrienteB.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabNotaPedido.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.gbPieItems.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.gbContado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.SuspendLayout();
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
            this.imagenesTab.Images.SetKeyName(8, "");
            this.imagenesTab.Images.SetKeyName(9, "");
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
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 4;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado de Facturas";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Teal;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 117;
            this.pictureBox1.TabStop = false;
            // 
            // butVistaPrevia
            // 
            this.butVistaPrevia.BackColor = System.Drawing.Color.Teal;
            this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
            this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVistaPrevia.Location = new System.Drawing.Point(376, 157);
            this.butVistaPrevia.Name = "butVistaPrevia";
            this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
            this.butVistaPrevia.TabIndex = 4;
            this.butVistaPrevia.Text = "&Vista Previa";
            this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butVistaPrevia.UseVisualStyleBackColor = false;
            this.butVistaPrevia.Click += new System.EventHandler(this.butVistaPrevia_Click);
            // 
            // butImprimir
            // 
            this.butImprimir.BackColor = System.Drawing.Color.Teal;
            this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimir.ForeColor = System.Drawing.Color.White;
            this.butImprimir.Image = ((System.Drawing.Image)(resources.GetObject("butImprimir.Image")));
            this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimir.Location = new System.Drawing.Point(296, 157);
            this.butImprimir.Name = "butImprimir";
            this.butImprimir.Size = new System.Drawing.Size(64, 23);
            this.butImprimir.TabIndex = 3;
            this.butImprimir.Text = "&Imprimir";
            this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimir.UseVisualStyleBackColor = false;
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
            this.butBorrar.UseVisualStyleBackColor = false;
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
            this.dgItems.CaptionBackColor = System.Drawing.Color.Teal;
            this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.CaptionForeColor = System.Drawing.Color.White;
            this.dgItems.CaptionText = "     Listado de Facturas";
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
            this.dgItems.Size = new System.Drawing.Size(792, 286);
            this.dgItems.TabIndex = 1;
            this.dgItems.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dgtsFacturaCompleta,
            this.dgtsFacturaDescuento});
            this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            // 
            // dgtsFacturaCompleta
            // 
            this.dgtsFacturaCompleta.AllowSorting = false;
            this.dgtsFacturaCompleta.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgtsFacturaCompleta.DataGrid = this.dgItems;
            this.dgtsFacturaCompleta.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn51,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn59,
            this.dataGridTextBoxColumn60,
            this.dataGridTextBoxColumn61,
            this.dataGridTextBoxColumn70,
            this.dataGridTextBoxColumn71});
            this.dgtsFacturaCompleta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsFacturaCompleta.MappingName = "Items";
            this.dgtsFacturaCompleta.ReadOnly = true;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.HeaderText = "Tipo Factura";
            this.dataGridTextBoxColumn51.MappingName = "Tipo Factura";
            this.dataGridTextBoxColumn51.ReadOnly = true;
            this.dataGridTextBoxColumn51.Width = 50;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "Nro.  Factura   .";
            this.dataGridTextBoxColumn24.MappingName = "Nro. Factura";
            this.dataGridTextBoxColumn24.ReadOnly = true;
            this.dataGridTextBoxColumn24.Width = 120;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Fecha";
            this.dataGridTextBoxColumn25.MappingName = "Fecha";
            this.dataGridTextBoxColumn25.ReadOnly = true;
            this.dataGridTextBoxColumn25.Width = 140;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "Razón Social";
            this.dataGridTextBoxColumn26.MappingName = "Razón Social";
            this.dataGridTextBoxColumn26.ReadOnly = true;
            this.dataGridTextBoxColumn26.Width = 140;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Dirección Cliente";
            this.dataGridTextBoxColumn27.MappingName = "Dirección Cliente";
            this.dataGridTextBoxColumn27.ReadOnly = true;
            this.dataGridTextBoxColumn27.Width = 140;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "CUIT";
            this.dataGridTextBoxColumn28.MappingName = "CUIT";
            this.dataGridTextBoxColumn28.ReadOnly = true;
            this.dataGridTextBoxColumn28.Width = 75;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Dirección Entrega";
            this.dataGridTextBoxColumn29.MappingName = "Dirección Entrega";
            this.dataGridTextBoxColumn29.ReadOnly = true;
            this.dataGridTextBoxColumn29.Width = 140;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn30.Format = "N";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "Bonif. %  .";
            this.dataGridTextBoxColumn30.MappingName = "Bonif. %";
            this.dataGridTextBoxColumn30.ReadOnly = true;
            this.dataGridTextBoxColumn30.Width = 75;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn31.Format = "C";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "SubTotal 1  .";
            this.dataGridTextBoxColumn31.MappingName = "SubTotal 1";
            this.dataGridTextBoxColumn31.ReadOnly = true;
            this.dataGridTextBoxColumn31.Width = 75;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn32.Format = "C";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "IVA 1  .";
            this.dataGridTextBoxColumn32.MappingName = "IVA 1";
            this.dataGridTextBoxColumn32.ReadOnly = true;
            this.dataGridTextBoxColumn32.Width = 75;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn33.Format = "C";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "IVA 2  .";
            this.dataGridTextBoxColumn33.MappingName = "IVA 2";
            this.dataGridTextBoxColumn33.ReadOnly = true;
            this.dataGridTextBoxColumn33.Width = 75;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn34.Format = "C";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "Total   .";
            this.dataGridTextBoxColumn34.MappingName = "total";
            this.dataGridTextBoxColumn34.ReadOnly = true;
            this.dataGridTextBoxColumn34.Width = 75;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn35.Format = "C";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "SubTotal 2  .";
            this.dataGridTextBoxColumn35.MappingName = "SubTotal 2";
            this.dataGridTextBoxColumn35.ReadOnly = true;
            this.dataGridTextBoxColumn35.Width = 75;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn36.Format = "C";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "Bonificación  .";
            this.dataGridTextBoxColumn36.MappingName = "Bonif. Importe";
            this.dataGridTextBoxColumn36.ReadOnly = true;
            this.dataGridTextBoxColumn36.Width = 75;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "Máquina";
            this.dataGridTextBoxColumn37.MappingName = "Máquina";
            this.dataGridTextBoxColumn37.ReadOnly = true;
            this.dataGridTextBoxColumn37.Width = 75;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "Tipo IVA";
            this.dataGridTextBoxColumn38.MappingName = "Tipo IVA";
            this.dataGridTextBoxColumn38.ReadOnly = true;
            this.dataGridTextBoxColumn38.Width = 75;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "Vendedor";
            this.dataGridTextBoxColumn39.MappingName = "Vendedor";
            this.dataGridTextBoxColumn39.ReadOnly = true;
            this.dataGridTextBoxColumn39.Width = 75;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "Estado";
            this.dataGridTextBoxColumn40.MappingName = "Estado";
            this.dataGridTextBoxColumn40.ReadOnly = true;
            this.dataGridTextBoxColumn40.Width = 75;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "Autorizó";
            this.dataGridTextBoxColumn41.MappingName = "Autorizó";
            this.dataGridTextBoxColumn41.ReadOnly = true;
            this.dataGridTextBoxColumn41.Width = 75;
            // 
            // dataGridTextBoxColumn59
            // 
            this.dataGridTextBoxColumn59.Format = "";
            this.dataGridTextBoxColumn59.FormatInfo = null;
            this.dataGridTextBoxColumn59.HeaderText = "Sucursal";
            this.dataGridTextBoxColumn59.MappingName = "Sucursal";
            this.dataGridTextBoxColumn59.ReadOnly = true;
            this.dataGridTextBoxColumn59.Width = 75;
            // 
            // dataGridTextBoxColumn60
            // 
            this.dataGridTextBoxColumn60.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn60.Format = "";
            this.dataGridTextBoxColumn60.FormatInfo = null;
            this.dataGridTextBoxColumn60.HeaderText = "Ejercicio Nro.   .";
            this.dataGridTextBoxColumn60.MappingName = "Ejercicio Nro.";
            this.dataGridTextBoxColumn60.ReadOnly = true;
            this.dataGridTextBoxColumn60.Width = 50;
            // 
            // dataGridTextBoxColumn61
            // 
            this.dataGridTextBoxColumn61.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn61.Format = "";
            this.dataGridTextBoxColumn61.FormatInfo = null;
            this.dataGridTextBoxColumn61.HeaderText = "Nota Pedido   .";
            this.dataGridTextBoxColumn61.MappingName = "Nota Pedido";
            this.dataGridTextBoxColumn61.ReadOnly = true;
            this.dataGridTextBoxColumn61.Width = 120;
            // 
            // dataGridTextBoxColumn70
            // 
            this.dataGridTextBoxColumn70.Format = "";
            this.dataGridTextBoxColumn70.FormatInfo = null;
            this.dataGridTextBoxColumn70.HeaderText = "Plazo Pago";
            this.dataGridTextBoxColumn70.MappingName = "Plazo Pago";
            this.dataGridTextBoxColumn70.ReadOnly = true;
            this.dataGridTextBoxColumn70.Width = 75;
            // 
            // dataGridTextBoxColumn71
            // 
            this.dataGridTextBoxColumn71.Format = "";
            this.dataGridTextBoxColumn71.FormatInfo = null;
            this.dataGridTextBoxColumn71.HeaderText = "Estado Cta. Cte.";
            this.dataGridTextBoxColumn71.MappingName = "Estado Cta. Cte.";
            this.dataGridTextBoxColumn71.ReadOnly = true;
            this.dataGridTextBoxColumn71.Width = 75;
            // 
            // dgtsFacturaDescuento
            // 
            this.dgtsFacturaDescuento.DataGrid = this.dgItems;
            this.dgtsFacturaDescuento.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn62,
            this.dataGridTextBoxColumn63,
            this.dataGridTextBoxColumn64,
            this.dataGridTextBoxColumn65,
            this.dataGridTextBoxColumn66,
            this.dataGridTextBoxColumn67,
            this.dataGridTextBoxColumn68,
            this.dataGridTextBoxColumn69});
            this.dgtsFacturaDescuento.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsFacturaDescuento.MappingName = "FacturaDescuento";
            this.dgtsFacturaDescuento.ReadOnly = true;
            // 
            // dataGridTextBoxColumn62
            // 
            this.dataGridTextBoxColumn62.Format = "";
            this.dataGridTextBoxColumn62.FormatInfo = null;
            this.dataGridTextBoxColumn62.HeaderText = "Tipo Factura";
            this.dataGridTextBoxColumn62.MappingName = "Tipo Factura";
            this.dataGridTextBoxColumn62.ReadOnly = true;
            this.dataGridTextBoxColumn62.Width = 75;
            // 
            // dataGridTextBoxColumn63
            // 
            this.dataGridTextBoxColumn63.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn63.Format = "";
            this.dataGridTextBoxColumn63.FormatInfo = null;
            this.dataGridTextBoxColumn63.HeaderText = "Nro. Factura   .";
            this.dataGridTextBoxColumn63.MappingName = "Nro. Factura";
            this.dataGridTextBoxColumn63.ReadOnly = true;
            this.dataGridTextBoxColumn63.Width = 120;
            // 
            // dataGridTextBoxColumn64
            // 
            this.dataGridTextBoxColumn64.Format = "";
            this.dataGridTextBoxColumn64.FormatInfo = null;
            this.dataGridTextBoxColumn64.HeaderText = "Vendedor";
            this.dataGridTextBoxColumn64.MappingName = "Vendedor";
            this.dataGridTextBoxColumn64.ReadOnly = true;
            this.dataGridTextBoxColumn64.Width = 140;
            // 
            // dataGridTextBoxColumn65
            // 
            this.dataGridTextBoxColumn65.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn65.Format = "C";
            this.dataGridTextBoxColumn65.FormatInfo = null;
            this.dataGridTextBoxColumn65.HeaderText = "Total   .";
            this.dataGridTextBoxColumn65.MappingName = "Total";
            this.dataGridTextBoxColumn65.ReadOnly = true;
            this.dataGridTextBoxColumn65.Width = 75;
            // 
            // dataGridTextBoxColumn66
            // 
            this.dataGridTextBoxColumn66.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn66.Format = "N";
            this.dataGridTextBoxColumn66.FormatInfo = null;
            this.dataGridTextBoxColumn66.HeaderText = "Bonif. %   .";
            this.dataGridTextBoxColumn66.MappingName = "Bonif. %";
            this.dataGridTextBoxColumn66.ReadOnly = true;
            this.dataGridTextBoxColumn66.Width = 75;
            // 
            // dataGridTextBoxColumn67
            // 
            this.dataGridTextBoxColumn67.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn67.Format = "C";
            this.dataGridTextBoxColumn67.FormatInfo = null;
            this.dataGridTextBoxColumn67.HeaderText = "Bonif. Importe   .";
            this.dataGridTextBoxColumn67.MappingName = "Bonif. Importe";
            this.dataGridTextBoxColumn67.ReadOnly = true;
            this.dataGridTextBoxColumn67.Width = 75;
            // 
            // dataGridTextBoxColumn68
            // 
            this.dataGridTextBoxColumn68.Format = "";
            this.dataGridTextBoxColumn68.FormatInfo = null;
            this.dataGridTextBoxColumn68.HeaderText = "Autorizó";
            this.dataGridTextBoxColumn68.MappingName = "Autorizó";
            this.dataGridTextBoxColumn68.ReadOnly = true;
            this.dataGridTextBoxColumn68.Width = 140;
            // 
            // dataGridTextBoxColumn69
            // 
            this.dataGridTextBoxColumn69.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn69.Format = "";
            this.dataGridTextBoxColumn69.FormatInfo = null;
            this.dataGridTextBoxColumn69.HeaderText = "Nota Pedido   .";
            this.dataGridTextBoxColumn69.MappingName = "Nota Pedido";
            this.dataGridTextBoxColumn69.ReadOnly = true;
            this.dataGridTextBoxColumn69.Width = 120;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabFiltro1);
            this.tabFiltro.Controls.Add(this.tabPage6);
            this.tabFiltro.Controls.Add(this.tabPage7);
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
            // tabFiltro1
            // 
            this.tabFiltro1.Controls.Add(this.groupBox20);
            this.tabFiltro1.Controls.Add(this.groupBox17);
            this.tabFiltro1.Controls.Add(this.gbFechaEmision);
            this.tabFiltro1.Controls.Add(this.butAceptar1);
            this.tabFiltro1.Controls.Add(this.groupBox10);
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.ImageIndex = 1;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.cbAutorizadorB);
            this.groupBox20.Controls.Add(this.cbBonificacionB);
            this.groupBox20.Location = new System.Drawing.Point(424, 64);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(200, 48);
            this.groupBox20.TabIndex = 7;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Bonificación - Autorizador";
            // 
            // cbAutorizadorB
            // 
            this.cbAutorizadorB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutorizadorB.ItemHeight = 13;
            this.cbAutorizadorB.Location = new System.Drawing.Point(80, 16);
            this.cbAutorizadorB.Name = "cbAutorizadorB";
            this.cbAutorizadorB.Size = new System.Drawing.Size(112, 21);
            this.cbAutorizadorB.TabIndex = 12;
            // 
            // cbBonificacionB
            // 
            this.cbBonificacionB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBonificacionB.ItemHeight = 13;
            this.cbBonificacionB.Items.AddRange(new object[] {
            "Todas",
            "Con Bonif.",
            "Sin Bonif."});
            this.cbBonificacionB.Location = new System.Drawing.Point(8, 16);
            this.cbBonificacionB.Name = "cbBonificacionB";
            this.cbBonificacionB.Size = new System.Drawing.Size(64, 21);
            this.cbBonificacionB.TabIndex = 11;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.cbFacturaTipoB);
            this.groupBox17.Controls.Add(this.label19);
            this.groupBox17.Controls.Add(this.label22);
            this.groupBox17.Controls.Add(this.tbFacturaSucHastaB);
            this.groupBox17.Controls.Add(this.tbFacturaNroDesdeB);
            this.groupBox17.Controls.Add(this.tbFacturaNroHastaB);
            this.groupBox17.Controls.Add(this.tbFacturaSucDesdeB);
            this.groupBox17.Location = new System.Drawing.Point(8, 8);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(200, 104);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Factura Tipo";
            // 
            // cbFacturaTipoB
            // 
            this.cbFacturaTipoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFacturaTipoB.ItemHeight = 13;
            this.cbFacturaTipoB.Items.AddRange(new object[] {
            "---",
            "A",
            "B"});
            this.cbFacturaTipoB.Location = new System.Drawing.Point(80, 0);
            this.cbFacturaTipoB.Name = "cbFacturaTipoB";
            this.cbFacturaTipoB.Size = new System.Drawing.Size(40, 21);
            this.cbFacturaTipoB.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 12);
            this.label19.TabIndex = 5;
            this.label19.Text = "Hasta";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 16);
            this.label22.TabIndex = 4;
            this.label22.Text = "Desde";
            // 
            // tbFacturaSucHastaB
            // 
            this.tbFacturaSucHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaSucHastaB.Location = new System.Drawing.Point(8, 72);
            this.tbFacturaSucHastaB.Name = "tbFacturaSucHastaB";
            this.tbFacturaSucHastaB.Size = new System.Drawing.Size(56, 20);
            this.tbFacturaSucHastaB.TabIndex = 2;
            this.tbFacturaSucHastaB.Validated += new System.EventHandler(this.tbFacturaSucHastaB_Validated);
            this.tbFacturaSucHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbFacturaNroDesdeB
            // 
            this.tbFacturaNroDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaNroDesdeB.Location = new System.Drawing.Point(64, 32);
            this.tbFacturaNroDesdeB.Name = "tbFacturaNroDesdeB";
            this.tbFacturaNroDesdeB.Size = new System.Drawing.Size(128, 20);
            this.tbFacturaNroDesdeB.TabIndex = 1;
            this.tbFacturaNroDesdeB.Validated += new System.EventHandler(this.tbFacturaNroDesdeB_Validated);
            this.tbFacturaNroDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbFacturaNroHastaB
            // 
            this.tbFacturaNroHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaNroHastaB.Location = new System.Drawing.Point(64, 72);
            this.tbFacturaNroHastaB.Name = "tbFacturaNroHastaB";
            this.tbFacturaNroHastaB.Size = new System.Drawing.Size(128, 20);
            this.tbFacturaNroHastaB.TabIndex = 3;
            this.tbFacturaNroHastaB.Validated += new System.EventHandler(this.tbFacturaNroHastaB_Validated);
            this.tbFacturaNroHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbFacturaSucDesdeB
            // 
            this.tbFacturaSucDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFacturaSucDesdeB.Location = new System.Drawing.Point(8, 32);
            this.tbFacturaSucDesdeB.Name = "tbFacturaSucDesdeB";
            this.tbFacturaSucDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbFacturaSucDesdeB.TabIndex = 0;
            this.tbFacturaSucDesdeB.Validated += new System.EventHandler(this.tbFacturaSucDesdeB_Validated);
            this.tbFacturaSucDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // gbFechaEmision
            // 
            this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionHasta);
            this.gbFechaEmision.Controls.Add(this.dtpFechaEmisionDesde);
            this.gbFechaEmision.Controls.Add(this.chkFechaEmision);
            this.gbFechaEmision.Location = new System.Drawing.Point(216, 64);
            this.gbFechaEmision.Name = "gbFechaEmision";
            this.gbFechaEmision.Size = new System.Drawing.Size(200, 48);
            this.gbFechaEmision.TabIndex = 5;
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
            this.chkFechaEmision.Size = new System.Drawing.Size(120, 16);
            this.chkFechaEmision.TabIndex = 4;
            this.chkFechaEmision.Text = "Fecha de Emisión";
            this.chkFechaEmision.CheckedChanged += new System.EventHandler(this.chkFechaEmision_CheckedChanged);
            // 
            // butAceptar1
            // 
            this.butAceptar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar1.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar1.Image")));
            this.butAceptar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar1.Location = new System.Drawing.Point(632, 96);
            this.butAceptar1.Name = "butAceptar1";
            this.butAceptar1.Size = new System.Drawing.Size(72, 24);
            this.butAceptar1.TabIndex = 11;
            this.butAceptar1.Text = "&Aceptar";
            this.butAceptar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar1.Visible = false;
            this.butAceptar1.Click += new System.EventHandler(this.butAceptar1_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbCuitB);
            this.groupBox10.Location = new System.Drawing.Point(424, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(200, 48);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "CUIT";
            // 
            // tbCuitB
            // 
            this.tbCuitB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCuitB.Location = new System.Drawing.Point(8, 16);
            this.tbCuitB.Name = "tbCuitB";
            this.tbCuitB.Size = new System.Drawing.Size(184, 20);
            this.tbCuitB.TabIndex = 1;
            // 
            // butSalir1
            // 
            this.butSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir1.Image = ((System.Drawing.Image)(resources.GetObject("butSalir1.Image")));
            this.butSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir1.Location = new System.Drawing.Point(640, 88);
            this.butSalir1.Name = "butSalir1";
            this.butSalir1.Size = new System.Drawing.Size(64, 23);
            this.butSalir1.TabIndex = 10;
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
            this.butLimpiar1.TabIndex = 9;
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
            this.butBuscar1.TabIndex = 8;
            this.butBuscar1.Text = "&Buscar";
            this.butBuscar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar1.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbClienteIDB);
            this.groupBox1.Controls.Add(this.tbRazonSocialB);
            this.groupBox1.Location = new System.Drawing.Point(216, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombre / Razón Social";
            // 
            // tbClienteIDB
            // 
            this.tbClienteIDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClienteIDB.Location = new System.Drawing.Point(140, 28);
            this.tbClienteIDB.Name = "tbClienteIDB";
            this.tbClienteIDB.Size = new System.Drawing.Size(32, 20);
            this.tbClienteIDB.TabIndex = 2;
            this.tbClienteIDB.Visible = false;
            // 
            // tbRazonSocialB
            // 
            this.tbRazonSocialB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRazonSocialB.Location = new System.Drawing.Point(8, 16);
            this.tbRazonSocialB.Name = "tbRazonSocialB";
            this.tbRazonSocialB.Size = new System.Drawing.Size(184, 20);
            this.tbRazonSocialB.TabIndex = 1;
            this.tbRazonSocialB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReazonSocialB_KeyPress);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox19);
            this.tabPage6.Controls.Add(this.groupBox18);
            this.tabPage6.Controls.Add(this.butSalir2);
            this.tabPage6.Controls.Add(this.butLimpiar2);
            this.tabPage6.Controls.Add(this.butBuscar2);
            this.tabPage6.Controls.Add(this.groupBox8);
            this.tabPage6.Controls.Add(this.groupBox7);
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Controls.Add(this.gbProveedor);
            this.tabPage6.ImageIndex = 2;
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(784, 126);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Filtro Avanzado";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.cbSucursalB);
            this.groupBox19.Location = new System.Drawing.Point(424, 64);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(200, 48);
            this.groupBox19.TabIndex = 6;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Sucursal";
            // 
            // cbSucursalB
            // 
            this.cbSucursalB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursalB.ItemHeight = 13;
            this.cbSucursalB.Location = new System.Drawing.Point(8, 16);
            this.cbSucursalB.Name = "cbSucursalB";
            this.cbSucursalB.Size = new System.Drawing.Size(184, 21);
            this.cbSucursalB.TabIndex = 10;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.tbEjercicioNroB);
            this.groupBox18.Location = new System.Drawing.Point(352, 8);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(64, 48);
            this.groupBox18.TabIndex = 3;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Ejercicio Nro.";
            // 
            // tbEjercicioNroB
            // 
            this.tbEjercicioNroB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEjercicioNroB.Location = new System.Drawing.Point(8, 16);
            this.tbEjercicioNroB.Name = "tbEjercicioNroB";
            this.tbEjercicioNroB.Size = new System.Drawing.Size(48, 20);
            this.tbEjercicioNroB.TabIndex = 0;
            this.tbEjercicioNroB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbEjercicioNroB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // butSalir2
            // 
            this.butSalir2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir2.Image = ((System.Drawing.Image)(resources.GetObject("butSalir2.Image")));
            this.butSalir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir2.Location = new System.Drawing.Point(640, 88);
            this.butSalir2.Name = "butSalir2";
            this.butSalir2.Size = new System.Drawing.Size(64, 23);
            this.butSalir2.TabIndex = 9;
            this.butSalir2.Text = "&Salir";
            this.butSalir2.Click += new System.EventHandler(this.butSalir1_Click);
            // 
            // butLimpiar2
            // 
            this.butLimpiar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar2.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar2.Image")));
            this.butLimpiar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar2.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar2.Name = "butLimpiar2";
            this.butLimpiar2.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar2.TabIndex = 8;
            this.butLimpiar2.Text = "&Limpiar";
            this.butLimpiar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar2.Click += new System.EventHandler(this.button2_Click);
            // 
            // butBuscar2
            // 
            this.butBuscar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar2.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar2.Image")));
            this.butBuscar2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar2.Location = new System.Drawing.Point(640, 16);
            this.butBuscar2.Name = "butBuscar2";
            this.butBuscar2.Size = new System.Drawing.Size(64, 41);
            this.butBuscar2.TabIndex = 7;
            this.butBuscar2.Text = "&Buscar";
            this.butBuscar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar2.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.tbNotaPedidoSucHastaB);
            this.groupBox8.Controls.Add(this.tbNotaPedidoNroDesdeB);
            this.groupBox8.Controls.Add(this.tbNotaPedidoNroHastaB);
            this.groupBox8.Controls.Add(this.tbNotaPedidoSucDesdeB);
            this.groupBox8.Location = new System.Drawing.Point(8, 8);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 104);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Nota de Pedido Nro.";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(8, 56);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(48, 12);
            this.label29.TabIndex = 11;
            this.label29.Text = "Hasta";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(8, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 16);
            this.label32.TabIndex = 10;
            this.label32.Text = "Desde";
            // 
            // tbNotaPedidoSucHastaB
            // 
            this.tbNotaPedidoSucHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoSucHastaB.Location = new System.Drawing.Point(8, 72);
            this.tbNotaPedidoSucHastaB.Name = "tbNotaPedidoSucHastaB";
            this.tbNotaPedidoSucHastaB.Size = new System.Drawing.Size(56, 20);
            this.tbNotaPedidoSucHastaB.TabIndex = 8;
            this.tbNotaPedidoSucHastaB.Validated += new System.EventHandler(this.tbNotaPedidoSucHastaB_Validated);
            this.tbNotaPedidoSucHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbNotaPedidoNroDesdeB
            // 
            this.tbNotaPedidoNroDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoNroDesdeB.Location = new System.Drawing.Point(64, 32);
            this.tbNotaPedidoNroDesdeB.Name = "tbNotaPedidoNroDesdeB";
            this.tbNotaPedidoNroDesdeB.Size = new System.Drawing.Size(128, 20);
            this.tbNotaPedidoNroDesdeB.TabIndex = 7;
            this.tbNotaPedidoNroDesdeB.Validated += new System.EventHandler(this.tbNotaPedidoNroDesdeB_Validated);
            this.tbNotaPedidoNroDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbNotaPedidoNroHastaB
            // 
            this.tbNotaPedidoNroHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoNroHastaB.Location = new System.Drawing.Point(64, 72);
            this.tbNotaPedidoNroHastaB.Name = "tbNotaPedidoNroHastaB";
            this.tbNotaPedidoNroHastaB.Size = new System.Drawing.Size(128, 20);
            this.tbNotaPedidoNroHastaB.TabIndex = 9;
            this.tbNotaPedidoNroHastaB.Validated += new System.EventHandler(this.tbNotaPedidoNroHastaB_Validated);
            this.tbNotaPedidoNroHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbNotaPedidoSucDesdeB
            // 
            this.tbNotaPedidoSucDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotaPedidoSucDesdeB.Location = new System.Drawing.Point(8, 32);
            this.tbNotaPedidoSucDesdeB.Name = "tbNotaPedidoSucDesdeB";
            this.tbNotaPedidoSucDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbNotaPedidoSucDesdeB.TabIndex = 6;
            this.tbNotaPedidoSucDesdeB.Validated += new System.EventHandler(this.tbNotaPedidoSucDesdeB_Validated);
            this.tbNotaPedidoSucDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbEstadoB);
            this.groupBox7.Location = new System.Drawing.Point(216, 64);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 48);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Estado";
            // 
            // cbEstadoB
            // 
            this.cbEstadoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoB.ItemHeight = 13;
            this.cbEstadoB.Location = new System.Drawing.Point(8, 16);
            this.cbEstadoB.Name = "cbEstadoB";
            this.cbEstadoB.Size = new System.Drawing.Size(184, 21);
            this.cbEstadoB.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCondicionEntregaB);
            this.groupBox2.Location = new System.Drawing.Point(424, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condición Entrega";
            // 
            // cbCondicionEntregaB
            // 
            this.cbCondicionEntregaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionEntregaB.ItemHeight = 13;
            this.cbCondicionEntregaB.Location = new System.Drawing.Point(8, 16);
            this.cbCondicionEntregaB.Name = "cbCondicionEntregaB";
            this.cbCondicionEntregaB.Size = new System.Drawing.Size(184, 21);
            this.cbCondicionEntregaB.TabIndex = 10;
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.cbVendedorB);
            this.gbProveedor.Location = new System.Drawing.Point(216, 8);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(136, 48);
            this.gbProveedor.TabIndex = 2;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Vendedor";
            // 
            // cbVendedorB
            // 
            this.cbVendedorB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedorB.ItemHeight = 13;
            this.cbVendedorB.Location = new System.Drawing.Point(8, 16);
            this.cbVendedorB.Name = "cbVendedorB";
            this.cbVendedorB.Size = new System.Drawing.Size(120, 21);
            this.cbVendedorB.TabIndex = 10;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label26);
            this.tabPage7.Controls.Add(this.gbCuentaCorrienteB);
            this.tabPage7.Controls.Add(this.butLimpiar4);
            this.tabPage7.Controls.Add(this.butBuscar4);
            this.tabPage7.Controls.Add(this.butSalir4);
            this.tabPage7.Controls.Add(this.cbPlazoPagoB);
            this.tabPage7.ImageIndex = 9;
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(784, 126);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Cuenta Corriente";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 9);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 16);
            this.label26.TabIndex = 13;
            this.label26.Text = "Plazo de Pago";
            // 
            // gbCuentaCorrienteB
            // 
            this.gbCuentaCorrienteB.Controls.Add(this.groupBox22);
            this.gbCuentaCorrienteB.Enabled = false;
            this.gbCuentaCorrienteB.Location = new System.Drawing.Point(8, 32);
            this.gbCuentaCorrienteB.Name = "gbCuentaCorrienteB";
            this.gbCuentaCorrienteB.Size = new System.Drawing.Size(616, 80);
            this.gbCuentaCorrienteB.TabIndex = 2;
            this.gbCuentaCorrienteB.TabStop = false;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.cbEstadoFacturaCtaCteB);
            this.groupBox22.Location = new System.Drawing.Point(8, 16);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(240, 48);
            this.groupBox22.TabIndex = 3;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Estado Factura";
            // 
            // cbEstadoFacturaCtaCteB
            // 
            this.cbEstadoFacturaCtaCteB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoFacturaCtaCteB.ItemHeight = 13;
            this.cbEstadoFacturaCtaCteB.Location = new System.Drawing.Point(8, 16);
            this.cbEstadoFacturaCtaCteB.Name = "cbEstadoFacturaCtaCteB";
            this.cbEstadoFacturaCtaCteB.Size = new System.Drawing.Size(224, 21);
            this.cbEstadoFacturaCtaCteB.TabIndex = 10;
            // 
            // butLimpiar4
            // 
            this.butLimpiar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar4.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar4.Image")));
            this.butLimpiar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar4.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar4.Name = "butLimpiar4";
            this.butLimpiar4.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar4.TabIndex = 11;
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
            this.butBuscar4.TabIndex = 10;
            this.butBuscar4.Text = "&Buscar";
            this.butBuscar4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar4.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // butSalir4
            // 
            this.butSalir4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir4.Image = ((System.Drawing.Image)(resources.GetObject("butSalir4.Image")));
            this.butSalir4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir4.Location = new System.Drawing.Point(640, 88);
            this.butSalir4.Name = "butSalir4";
            this.butSalir4.Size = new System.Drawing.Size(64, 23);
            this.butSalir4.TabIndex = 12;
            this.butSalir4.Text = "&Salir";
            this.butSalir4.Click += new System.EventHandler(this.butSalir4_Click);
            // 
            // cbPlazoPagoB
            // 
            this.cbPlazoPagoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlazoPagoB.ItemHeight = 13;
            this.cbPlazoPagoB.Items.AddRange(new object[] {
            "---",
            "A",
            "B"});
            this.cbPlazoPagoB.Location = new System.Drawing.Point(96, 8);
            this.cbPlazoPagoB.Name = "cbPlazoPagoB";
            this.cbPlazoPagoB.Size = new System.Drawing.Size(152, 21);
            this.cbPlazoPagoB.TabIndex = 0;
            this.cbPlazoPagoB.SelectedIndexChanged += new System.EventHandler(this.cbPlazoPagoB_SelectedIndexChanged);
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
            this.cbCampoOrden2.ItemHeight = 13;
            this.cbCampoOrden2.Items.AddRange(new object[] {
            "---",
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Ejercicio Nro.",
            "Estado",
            "Estado Cta. Cte.",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nota Pedido",
            "Nro. Factura",
            "Plazo Pago",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Sucursal",
            "Tipo Factura",
            "Vendedor"});
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
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Ejercicio Nro.",
            "Estado",
            "Estado Cta. Cte.",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nota Pedido",
            "Nro. Factura",
            "Plazo Pago",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Sucursal",
            "Tipo Factura",
            "Vendedor"});
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
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Ejercicio Nro.",
            "Estado",
            "Estado Cta. Cte.",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nota Pedido",
            "Nro. Factura",
            "Plazo Pago",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Sucursal",
            "Tipo Factura",
            "Vendedor"});
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
            "Autorizó",
            "Bonif. %",
            "Bonificación",
            "CUIT",
            "Dirección Cliente",
            "Dirección Entrega",
            "Ejercicio Nro.",
            "Estado",
            "Estado Cta. Cte.",
            "Fecha Creación",
            "IVA 1",
            "IVA 2",
            "Máquina",
            "Nota Pedido",
            "Nro. Factura",
            "Plazo Pago",
            "Razón Social",
            "SubTotal 1",
            "SubTotal 2",
            "Sucursal",
            "Tipo Factura",
            "Vendedor"});
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
            this.tabPage2.Controls.Add(this.tabNotaPedido);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.lbTitulo);
            this.tabPage2.ImageIndex = 5;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.Visible = false;
            // 
            // tabNotaPedido
            // 
            this.tabNotaPedido.Controls.Add(this.tabPage3);
            this.tabNotaPedido.Controls.Add(this.tabPage4);
            this.tabNotaPedido.Controls.Add(this.tabPage5);
            this.tabNotaPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabNotaPedido.HotTrack = true;
            this.tabNotaPedido.ImageList = this.imagenesTab;
            this.tabNotaPedido.ItemSize = new System.Drawing.Size(93, 18);
            this.tabNotaPedido.Location = new System.Drawing.Point(0, 32);
            this.tabNotaPedido.Name = "tabNotaPedido";
            this.tabNotaPedido.SelectedIndex = 0;
            this.tabNotaPedido.Size = new System.Drawing.Size(792, 406);
            this.tabNotaPedido.TabIndex = 154;
            this.tabNotaPedido.SelectedIndexChanged += new System.EventHandler(this.tabNotaPedido_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.butContinuar1);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.ImageIndex = 6;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 380);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Cabecera";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // butContinuar1
            // 
            this.butContinuar1.BackColor = System.Drawing.SystemColors.Control;
            this.butContinuar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butContinuar1.Image = ((System.Drawing.Image)(resources.GetObject("butContinuar1.Image")));
            this.butContinuar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinuar1.Location = new System.Drawing.Point(608, 242);
            this.butContinuar1.Name = "butContinuar1";
            this.butContinuar1.Size = new System.Drawing.Size(96, 24);
            this.butContinuar1.TabIndex = 159;
            this.butContinuar1.Text = "&Continuar";
            this.butContinuar1.UseVisualStyleBackColor = false;
            this.butContinuar1.Visible = false;
            this.butContinuar1.Click += new System.EventHandler(this.butContinuar1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.butGuardarEstadoFactura);
            this.groupBox3.Controls.Add(this.cbEstado);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cbVendedor);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbCondicionEntrega);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbDireccionEntrega);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbFacturaID);
            this.groupBox3.Controls.Add(this.tbClienteID);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 104);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // butGuardarEstadoFactura
            // 
            this.butGuardarEstadoFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGuardarEstadoFactura.Image = ((System.Drawing.Image)(resources.GetObject("butGuardarEstadoFactura.Image")));
            this.butGuardarEstadoFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGuardarEstadoFactura.Location = new System.Drawing.Point(560, 69);
            this.butGuardarEstadoFactura.Name = "butGuardarEstadoFactura";
            this.butGuardarEstadoFactura.Size = new System.Drawing.Size(144, 24);
            this.butGuardarEstadoFactura.TabIndex = 25;
            this.butGuardarEstadoFactura.Text = "&Guardar Estado";
            this.butGuardarEstadoFactura.Click += new System.EventHandler(this.butGuardarEstadoFactura_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.ItemHeight = 13;
            this.cbEstado.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbEstado.Location = new System.Drawing.Point(496, 32);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(208, 21);
            this.cbEstado.TabIndex = 11;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(496, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 16);
            this.label15.TabIndex = 10;
            this.label15.Text = "Estado Factura";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // cbVendedor
            // 
            this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedor.Enabled = false;
            this.cbVendedor.ItemHeight = 13;
            this.cbVendedor.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbVendedor.Location = new System.Drawing.Point(240, 32);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(208, 21);
            this.cbVendedor.TabIndex = 9;
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
            this.cbCondicionEntrega.Enabled = false;
            this.cbCondicionEntrega.ItemHeight = 13;
            this.cbCondicionEntrega.Items.AddRange(new object[] {
            "Inmediata",
            "Diferida"});
            this.cbCondicionEntrega.Location = new System.Drawing.Point(8, 72);
            this.cbCondicionEntrega.Name = "cbCondicionEntrega";
            this.cbCondicionEntrega.Size = new System.Drawing.Size(208, 21);
            this.cbCondicionEntrega.TabIndex = 7;
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
            this.tbDireccionEntrega.ReadOnly = true;
            this.tbDireccionEntrega.Size = new System.Drawing.Size(208, 20);
            this.tbDireccionEntrega.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dirección de Entrega";
            // 
            // tbFacturaID
            // 
            this.tbFacturaID.Location = new System.Drawing.Point(456, 64);
            this.tbFacturaID.Name = "tbFacturaID";
            this.tbFacturaID.Size = new System.Drawing.Size(24, 20);
            this.tbFacturaID.TabIndex = 13;
            this.tbFacturaID.Visible = false;
            // 
            // tbClienteID
            // 
            this.tbClienteID.Location = new System.Drawing.Point(456, 32);
            this.tbClienteID.Name = "tbClienteID";
            this.tbClienteID.Size = new System.Drawing.Size(24, 20);
            this.tbClienteID.TabIndex = 12;
            this.tbClienteID.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbIVA);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbCUIT);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.butBuscarCliente);
            this.groupBox4.Controls.Add(this.tbDireccion);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tbClienteNombre);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(784, 120);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cliente";
            // 
            // cbIVA
            // 
            this.cbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIVA.Enabled = false;
            this.cbIVA.ItemHeight = 13;
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
            this.butBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarCliente.Location = new System.Drawing.Point(464, 48);
            this.butBuscarCliente.Name = "butBuscarCliente";
            this.butBuscarCliente.Size = new System.Drawing.Size(103, 24);
            this.butBuscarCliente.TabIndex = 6;
            this.butBuscarCliente.Text = "Buscar Cliente";
            this.butBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarCliente.UseVisualStyleBackColor = false;
            this.butBuscarCliente.Visible = false;
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgSubArticulos);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.gbPieItems);
            this.tabPage4.Controls.Add(this.butBorrarArticulosComponentes);
            this.tabPage4.ImageIndex = 7;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(784, 380);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Items";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Visible = false;
            // 
            // dgSubArticulos
            // 
            this.dgSubArticulos.CaptionBackColor = System.Drawing.Color.MediumVioletRed;
            this.dgSubArticulos.CaptionForeColor = System.Drawing.Color.White;
            this.dgSubArticulos.CaptionText = "Artículos";
            this.dgSubArticulos.DataMember = "";
            this.dgSubArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSubArticulos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSubArticulos.Location = new System.Drawing.Point(0, 88);
            this.dgSubArticulos.Name = "dgSubArticulos";
            this.dgSubArticulos.ReadOnly = true;
            this.dgSubArticulos.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgSubArticulos.Size = new System.Drawing.Size(784, 180);
            this.dgSubArticulos.TabIndex = 154;
            this.dgSubArticulos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgSubArticulos;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn45,
            this.dataGridTextBoxColumn48,
            this.dataGridTextBoxColumn49,
            this.dataGridTextBoxColumn50,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn52,
            this.dataGridTextBoxColumn53});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "v_Articulo";
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "#  .";
            this.dataGridTextBoxColumn42.MappingName = "itemNro";
            this.dataGridTextBoxColumn42.ReadOnly = true;
            this.dataGridTextBoxColumn42.Width = 25;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "Cod.Interno .";
            this.dataGridTextBoxColumn43.MappingName = "Código Interno";
            this.dataGridTextBoxColumn43.ReadOnly = true;
            this.dataGridTextBoxColumn43.Width = 75;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "Cod.Barras .";
            this.dataGridTextBoxColumn44.MappingName = "Código de Barras";
            this.dataGridTextBoxColumn44.ReadOnly = true;
            this.dataGridTextBoxColumn44.Width = 75;
            // 
            // dataGridTextBoxColumn45
            // 
            this.dataGridTextBoxColumn45.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn45.Format = "";
            this.dataGridTextBoxColumn45.FormatInfo = null;
            this.dataGridTextBoxColumn45.HeaderText = "Cantidad .";
            this.dataGridTextBoxColumn45.MappingName = "Cantidad";
            this.dataGridTextBoxColumn45.Width = 50;
            // 
            // dataGridTextBoxColumn48
            // 
            this.dataGridTextBoxColumn48.Format = "";
            this.dataGridTextBoxColumn48.FormatInfo = null;
            this.dataGridTextBoxColumn48.HeaderText = "Descripción";
            this.dataGridTextBoxColumn48.MappingName = "Descripción";
            this.dataGridTextBoxColumn48.ReadOnly = true;
            this.dataGridTextBoxColumn48.Width = 300;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn49.Format = "C";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.HeaderText = "P.Unitario  .";
            this.dataGridTextBoxColumn49.MappingName = "Precio";
            this.dataGridTextBoxColumn49.ReadOnly = true;
            this.dataGridTextBoxColumn49.Width = 75;
            // 
            // dataGridTextBoxColumn50
            // 
            this.dataGridTextBoxColumn50.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn50.Format = "C";
            this.dataGridTextBoxColumn50.FormatInfo = null;
            this.dataGridTextBoxColumn50.HeaderText = "Subtotal  .";
            this.dataGridTextBoxColumn50.MappingName = "precioTotal";
            this.dataGridTextBoxColumn50.ReadOnly = true;
            this.dataGridTextBoxColumn50.Width = 75;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridBoolColumn1.HeaderText = "Promo";
            this.dataGridBoolColumn1.MappingName = "promocion";
            this.dataGridBoolColumn1.NullValue = null;
            this.dataGridBoolColumn1.Width = 50;
            // 
            // dataGridTextBoxColumn52
            // 
            this.dataGridTextBoxColumn52.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn52.Format = "";
            this.dataGridTextBoxColumn52.FormatInfo = null;
            this.dataGridTextBoxColumn52.HeaderText = "Descuento  .";
            this.dataGridTextBoxColumn52.MappingName = "descuento";
            this.dataGridTextBoxColumn52.Width = 50;
            // 
            // dataGridTextBoxColumn53
            // 
            this.dataGridTextBoxColumn53.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn53.Format = "C";
            this.dataGridTextBoxColumn53.FormatInfo = null;
            this.dataGridTextBoxColumn53.HeaderText = "Total  .";
            this.dataGridTextBoxColumn53.MappingName = "precioTotalConDesc";
            this.dataGridTextBoxColumn53.ReadOnly = true;
            this.dataGridTextBoxColumn53.Width = 75;
            // 
            // groupBox5
            // 
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
            this.groupBox5.Size = new System.Drawing.Size(784, 88);
            this.groupBox5.TabIndex = 153;
            this.groupBox5.TabStop = false;
            // 
            // tbPromocionAC
            // 
            this.tbPromocionAC.Location = new System.Drawing.Point(640, 8);
            this.tbPromocionAC.Name = "tbPromocionAC";
            this.tbPromocionAC.Size = new System.Drawing.Size(16, 20);
            this.tbPromocionAC.TabIndex = 149;
            this.tbPromocionAC.Visible = false;
            // 
            // tbPrecioAC
            // 
            this.tbPrecioAC.Location = new System.Drawing.Point(656, 8);
            this.tbPrecioAC.Name = "tbPrecioAC";
            this.tbPrecioAC.Size = new System.Drawing.Size(16, 20);
            this.tbPrecioAC.TabIndex = 148;
            this.tbPrecioAC.Visible = false;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(288, 16);
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
            this.tbCodigoBarrasAC.Enabled = false;
            this.tbCodigoBarrasAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoBarrasAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoBarrasAC.Location = new System.Drawing.Point(96, 32);
            this.tbCodigoBarrasAC.Name = "tbCodigoBarrasAC";
            this.tbCodigoBarrasAC.Size = new System.Drawing.Size(88, 21);
            this.tbCodigoBarrasAC.TabIndex = 134;
            this.tbCodigoBarrasAC.Enter += new System.EventHandler(this.tbCodigoBarrasAC_Enter);
            this.tbCodigoBarrasAC.Leave += new System.EventHandler(this.tbCodigoBarrasAC_Leave);
            this.tbCodigoBarrasAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoBarrasAC_KeyPress);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(672, 8);
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
            this.tbCodigoInternoAC.Enabled = false;
            this.tbCodigoInternoAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoInternoAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbCodigoInternoAC.Location = new System.Drawing.Point(8, 32);
            this.tbCodigoInternoAC.Name = "tbCodigoInternoAC";
            this.tbCodigoInternoAC.Size = new System.Drawing.Size(80, 21);
            this.tbCodigoInternoAC.TabIndex = 133;
            this.tbCodigoInternoAC.Enter += new System.EventHandler(this.tbCodigoInternoAC_Enter);
            this.tbCodigoInternoAC.Leave += new System.EventHandler(this.tbCodigoInternoAC_Leave);
            this.tbCodigoInternoAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoInternoAC_KeyPress);
            // 
            // tbDescripcionAC
            // 
            this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcionAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbDescripcionAC.Location = new System.Drawing.Point(528, 32);
            this.tbDescripcionAC.Name = "tbDescripcionAC";
            this.tbDescripcionAC.Size = new System.Drawing.Size(248, 48);
            this.tbDescripcionAC.TabIndex = 146;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(528, 16);
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
            this.tbSubRubroAC.Location = new System.Drawing.Point(408, 32);
            this.tbSubRubroAC.Name = "tbSubRubroAC";
            this.tbSubRubroAC.Size = new System.Drawing.Size(112, 48);
            this.tbSubRubroAC.TabIndex = 145;
            // 
            // tbRubroAC
            // 
            this.tbRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
            this.tbRubroAC.Location = new System.Drawing.Point(288, 32);
            this.tbRubroAC.Name = "tbRubroAC";
            this.tbRubroAC.Size = new System.Drawing.Size(112, 48);
            this.tbRubroAC.TabIndex = 144;
            // 
            // butBuscarArticuloAC
            // 
            this.butBuscarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
            this.butBuscarArticuloAC.Enabled = false;
            this.butBuscarArticuloAC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarArticuloAC.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarArticuloAC.Image")));
            this.butBuscarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butBuscarArticuloAC.Location = new System.Drawing.Point(248, 32);
            this.butBuscarArticuloAC.Name = "butBuscarArticuloAC";
            this.butBuscarArticuloAC.Size = new System.Drawing.Size(24, 24);
            this.butBuscarArticuloAC.TabIndex = 137;
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
            this.tbCantidadAC.Enabled = false;
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
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(408, 16);
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
            // gbPieItems
            // 
            this.gbPieItems.Controls.Add(this.butSuspender2);
            this.gbPieItems.Controls.Add(this.butCancelar2);
            this.gbPieItems.Controls.Add(this.butContinuar2);
            this.gbPieItems.Controls.Add(this.label14);
            this.gbPieItems.Controls.Add(this.label13);
            this.gbPieItems.Controls.Add(this.label12);
            this.gbPieItems.Controls.Add(this.label11);
            this.gbPieItems.Controls.Add(this.label10);
            this.gbPieItems.Controls.Add(this.label9);
            this.gbPieItems.Controls.Add(this.lblSubTotal2);
            this.gbPieItems.Controls.Add(this.lblBonificacion);
            this.gbPieItems.Controls.Add(this.lblTotal);
            this.gbPieItems.Controls.Add(this.lblIva2);
            this.gbPieItems.Controls.Add(this.lblIva1);
            this.gbPieItems.Controls.Add(this.lblSubTotal1);
            this.gbPieItems.Controls.Add(this.cbAutorizadorBonificacion);
            this.gbPieItems.Controls.Add(this.label8);
            this.gbPieItems.Controls.Add(this.lblBonifica);
            this.gbPieItems.Controls.Add(this.tbBonificacion);
            this.gbPieItems.Controls.Add(this.groupBox9);
            this.gbPieItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbPieItems.Location = new System.Drawing.Point(0, 268);
            this.gbPieItems.Name = "gbPieItems";
            this.gbPieItems.Size = new System.Drawing.Size(784, 112);
            this.gbPieItems.TabIndex = 153;
            this.gbPieItems.TabStop = false;
            // 
            // butSuspender2
            // 
            this.butSuspender2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender2.Location = new System.Drawing.Point(8, 48);
            this.butSuspender2.Name = "butSuspender2";
            this.butSuspender2.Size = new System.Drawing.Size(120, 24);
            this.butSuspender2.TabIndex = 162;
            this.butSuspender2.Text = "&Suspender";
            this.butSuspender2.Visible = false;
            this.butSuspender2.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // butCancelar2
            // 
            this.butCancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar2.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar2.Image")));
            this.butCancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar2.Location = new System.Drawing.Point(8, 80);
            this.butCancelar2.Name = "butCancelar2";
            this.butCancelar2.Size = new System.Drawing.Size(120, 24);
            this.butCancelar2.TabIndex = 161;
            this.butCancelar2.Text = "C&ancelar";
            this.butCancelar2.Click += new System.EventHandler(this.butCancelar_Click);
            // 
            // butContinuar2
            // 
            this.butContinuar2.BackColor = System.Drawing.SystemColors.Control;
            this.butContinuar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butContinuar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinuar2.Location = new System.Drawing.Point(184, 64);
            this.butContinuar2.Name = "butContinuar2";
            this.butContinuar2.Size = new System.Drawing.Size(144, 24);
            this.butContinuar2.TabIndex = 160;
            this.butContinuar2.Text = "&Continuar";
            this.butContinuar2.UseVisualStyleBackColor = false;
            this.butContinuar2.Visible = false;
            this.butContinuar2.Click += new System.EventHandler(this.butContinuar2_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(584, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 24);
            this.label14.TabIndex = 156;
            this.label14.Text = "TOTAL";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(608, 56);
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
            this.label11.Location = new System.Drawing.Point(608, 32);
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
            this.label9.Location = new System.Drawing.Point(608, 8);
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
            this.lblSubTotal2.Location = new System.Drawing.Point(672, 32);
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
            this.lblTotal.Location = new System.Drawing.Point(648, 80);
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
            this.lblIva2.Location = new System.Drawing.Point(672, 56);
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
            this.lblSubTotal1.Location = new System.Drawing.Point(672, 8);
            this.lblSubTotal1.Name = "lblSubTotal1";
            this.lblSubTotal1.Size = new System.Drawing.Size(96, 24);
            this.lblSubTotal1.TabIndex = 145;
            this.lblSubTotal1.Text = "0";
            this.lblSubTotal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAutorizadorBonificacion
            // 
            this.cbAutorizadorBonificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutorizadorBonificacion.Enabled = false;
            this.cbAutorizadorBonificacion.ItemHeight = 13;
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
            this.tbBonificacion.ReadOnly = true;
            this.tbBonificacion.Size = new System.Drawing.Size(40, 20);
            this.tbBonificacion.TabIndex = 32;
            this.tbBonificacion.Text = "0";
            this.tbBonificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblRegistro);
            this.groupBox9.Controls.Add(this.butSiguiente);
            this.groupBox9.Controls.Add(this.butAnterior);
            this.groupBox9.Location = new System.Drawing.Point(344, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(104, 96);
            this.groupBox9.TabIndex = 103;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Registro";
            // 
            // lblRegistro
            // 
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(8, 43);
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
            this.butSiguiente.Location = new System.Drawing.Point(16, 64);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(72, 24);
            this.butSiguiente.TabIndex = 101;
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
            this.butAnterior.TabIndex = 100;
            this.butAnterior.Text = "Anterior";
            this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
            // 
            // butBorrarArticulosComponentes
            // 
            this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
            this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(48, 104);
            this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
            this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
            this.butBorrarArticulosComponentes.TabIndex = 155;
            this.butBorrarArticulosComponentes.Text = "&Borrar";
            this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarArticulosComponentes.UseVisualStyleBackColor = false;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.butBorrarPagos);
            this.tabPage5.Controls.Add(this.dgPagos);
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Controls.Add(this.groupBox15);
            this.tabPage5.ImageIndex = 8;
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(784, 380);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Formas de Pago";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // butBorrarPagos
            // 
            this.butBorrarPagos.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarPagos.ForeColor = System.Drawing.Color.White;
            this.butBorrarPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarPagos.Location = new System.Drawing.Point(208, 88);
            this.butBorrarPagos.Name = "butBorrarPagos";
            this.butBorrarPagos.Size = new System.Drawing.Size(64, 20);
            this.butBorrarPagos.TabIndex = 163;
            this.butBorrarPagos.Text = "&Borrar";
            this.butBorrarPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarPagos.UseVisualStyleBackColor = false;
            this.butBorrarPagos.Visible = false;
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
            this.dgPagos.ReadOnly = true;
            this.dgPagos.Size = new System.Drawing.Size(784, 180);
            this.dgPagos.TabIndex = 162;
            this.dgPagos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dgPagos;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn54,
            this.dataGridTextBoxColumn55,
            this.dataGridTextBoxColumn56,
            this.dataGridTextBoxColumn57,
            this.dataGridTextBoxColumn58});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "v_FormaPagoLinea";
            this.dataGridTableStyle3.ReadOnly = true;
            // 
            // dataGridTextBoxColumn54
            // 
            this.dataGridTextBoxColumn54.Format = "";
            this.dataGridTextBoxColumn54.FormatInfo = null;
            this.dataGridTextBoxColumn54.HeaderText = "Tipo de Pago";
            this.dataGridTextBoxColumn54.MappingName = "Tipo Pago";
            this.dataGridTextBoxColumn54.ReadOnly = true;
            this.dataGridTextBoxColumn54.Width = 150;
            // 
            // dataGridTextBoxColumn55
            // 
            this.dataGridTextBoxColumn55.Format = "";
            this.dataGridTextBoxColumn55.FormatInfo = null;
            this.dataGridTextBoxColumn55.HeaderText = "Detalle";
            this.dataGridTextBoxColumn55.MappingName = "Detalle";
            this.dataGridTextBoxColumn55.ReadOnly = true;
            this.dataGridTextBoxColumn55.Width = 300;
            // 
            // dataGridTextBoxColumn56
            // 
            this.dataGridTextBoxColumn56.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn56.Format = "C";
            this.dataGridTextBoxColumn56.FormatInfo = null;
            this.dataGridTextBoxColumn56.HeaderText = "Importe   .";
            this.dataGridTextBoxColumn56.MappingName = "Importe";
            this.dataGridTextBoxColumn56.ReadOnly = true;
            this.dataGridTextBoxColumn56.Width = 75;
            // 
            // dataGridTextBoxColumn57
            // 
            this.dataGridTextBoxColumn57.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn57.Format = "C";
            this.dataGridTextBoxColumn57.FormatInfo = null;
            this.dataGridTextBoxColumn57.HeaderText = "Ajuste   .";
            this.dataGridTextBoxColumn57.MappingName = "Ajuste";
            this.dataGridTextBoxColumn57.ReadOnly = true;
            this.dataGridTextBoxColumn57.Width = 75;
            // 
            // dataGridTextBoxColumn58
            // 
            this.dataGridTextBoxColumn58.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn58.Format = "C";
            this.dataGridTextBoxColumn58.FormatInfo = null;
            this.dataGridTextBoxColumn58.HeaderText = "Pesos   .";
            this.dataGridTextBoxColumn58.MappingName = "Pesos";
            this.dataGridTextBoxColumn58.ReadOnly = true;
            this.dataGridTextBoxColumn58.Width = 75;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.butImprimirFactura);
            this.groupBox6.Controls.Add(this.butSuspender);
            this.groupBox6.Controls.Add(this.butCancelar);
            this.groupBox6.Controls.Add(this.butCrearRemitos);
            this.groupBox6.Controls.Add(this.groupBox16);
            this.groupBox6.Controls.Add(this.lblInteresPorE);
            this.groupBox6.Controls.Add(this.lblInteresPorV);
            this.groupBox6.Controls.Add(this.lblTotalConInteresE);
            this.groupBox6.Controls.Add(this.lblInteresValE);
            this.groupBox6.Controls.Add(this.lblTotalConInteresV);
            this.groupBox6.Controls.Add(this.lblInteresValV);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.lblTotalFacturado);
            this.groupBox6.Controls.Add(this.lblSaldoPagos);
            this.groupBox6.Controls.Add(this.lblTotalPagos);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 268);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(784, 112);
            this.groupBox6.TabIndex = 161;
            this.groupBox6.TabStop = false;
            // 
            // butImprimirFactura
            // 
            this.butImprimirFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirFactura.Location = new System.Drawing.Point(8, 16);
            this.butImprimirFactura.Name = "butImprimirFactura";
            this.butImprimirFactura.Size = new System.Drawing.Size(120, 24);
            this.butImprimirFactura.TabIndex = 169;
            this.butImprimirFactura.Text = "&Imprimir Factura";
            this.butImprimirFactura.Visible = false;
            this.butImprimirFactura.Click += new System.EventHandler(this.butImprimirFactura_Click);
            // 
            // butSuspender
            // 
            this.butSuspender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender.Location = new System.Drawing.Point(136, 16);
            this.butSuspender.Name = "butSuspender";
            this.butSuspender.Size = new System.Drawing.Size(120, 24);
            this.butSuspender.TabIndex = 168;
            this.butSuspender.Text = "&Suspender";
            this.butSuspender.Visible = false;
            this.butSuspender.Click += new System.EventHandler(this.butSuspender_Click);
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(136, 48);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(120, 24);
            this.butCancelar.TabIndex = 167;
            this.butCancelar.Text = "&Cancelar";
            this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click);
            // 
            // butCrearRemitos
            // 
            this.butCrearRemitos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCrearRemitos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCrearRemitos.Location = new System.Drawing.Point(8, 48);
            this.butCrearRemitos.Name = "butCrearRemitos";
            this.butCrearRemitos.Size = new System.Drawing.Size(120, 24);
            this.butCrearRemitos.TabIndex = 166;
            this.butCrearRemitos.Text = "&Crear Remito(s)";
            this.butCrearRemitos.Visible = false;
            this.butCrearRemitos.Click += new System.EventHandler(this.butCrearRemitos_Click);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.lblRegistro2);
            this.groupBox16.Controls.Add(this.butSiguiente2);
            this.groupBox16.Controls.Add(this.butAnterior2);
            this.groupBox16.Location = new System.Drawing.Point(288, 8);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(104, 96);
            this.groupBox16.TabIndex = 165;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Registro";
            // 
            // lblRegistro2
            // 
            this.lblRegistro2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro2.Location = new System.Drawing.Point(8, 43);
            this.lblRegistro2.Name = "lblRegistro2";
            this.lblRegistro2.Size = new System.Drawing.Size(88, 14);
            this.lblRegistro2.TabIndex = 102;
            this.lblRegistro2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butSiguiente2
            // 
            this.butSiguiente2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente2.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente2.Image")));
            this.butSiguiente2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSiguiente2.Location = new System.Drawing.Point(16, 64);
            this.butSiguiente2.Name = "butSiguiente2";
            this.butSiguiente2.Size = new System.Drawing.Size(72, 24);
            this.butSiguiente2.TabIndex = 101;
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
            this.butAnterior2.TabIndex = 100;
            this.butAnterior2.Text = "Anterior";
            this.butAnterior2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAnterior2.Click += new System.EventHandler(this.butAnterior_Click);
            // 
            // lblInteresPorE
            // 
            this.lblInteresPorE.Location = new System.Drawing.Point(416, 64);
            this.lblInteresPorE.Name = "lblInteresPorE";
            this.lblInteresPorE.Size = new System.Drawing.Size(56, 24);
            this.lblInteresPorE.TabIndex = 164;
            this.lblInteresPorE.Text = "Interés %";
            this.lblInteresPorE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresPorE.Visible = false;
            // 
            // lblInteresPorV
            // 
            this.lblInteresPorV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInteresPorV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInteresPorV.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblInteresPorV.Location = new System.Drawing.Point(480, 64);
            this.lblInteresPorV.Name = "lblInteresPorV";
            this.lblInteresPorV.Size = new System.Drawing.Size(48, 24);
            this.lblInteresPorV.TabIndex = 163;
            this.lblInteresPorV.Text = "0";
            this.lblInteresPorV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresPorV.Visible = false;
            // 
            // lblTotalConInteresE
            // 
            this.lblTotalConInteresE.Location = new System.Drawing.Point(576, 40);
            this.lblTotalConInteresE.Name = "lblTotalConInteresE";
            this.lblTotalConInteresE.Size = new System.Drawing.Size(88, 24);
            this.lblTotalConInteresE.TabIndex = 162;
            this.lblTotalConInteresE.Text = "Total con Interés";
            this.lblTotalConInteresE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalConInteresE.Visible = false;
            // 
            // lblInteresValE
            // 
            this.lblInteresValE.Location = new System.Drawing.Point(400, 40);
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
            this.lblTotalConInteresV.Location = new System.Drawing.Point(672, 40);
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
            this.lblInteresValV.Location = new System.Drawing.Point(480, 40);
            this.lblInteresValV.Name = "lblInteresValV";
            this.lblInteresValV.Size = new System.Drawing.Size(96, 24);
            this.lblInteresValV.TabIndex = 159;
            this.lblInteresValV.Text = "0";
            this.lblInteresValV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInteresValV.Visible = false;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(552, 80);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 24);
            this.label31.TabIndex = 156;
            this.label31.Text = "Saldo";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(576, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 24);
            this.label34.TabIndex = 153;
            this.label34.Text = "Total Facturado";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(400, 16);
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
            this.lblTotalFacturado.Location = new System.Drawing.Point(672, 16);
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
            this.lblSaldoPagos.Location = new System.Drawing.Point(648, 80);
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
            this.lblTotalPagos.Location = new System.Drawing.Point(480, 16);
            this.lblTotalPagos.Name = "lblTotalPagos";
            this.lblTotalPagos.Size = new System.Drawing.Size(96, 24);
            this.lblTotalPagos.TabIndex = 145;
            this.lblTotalPagos.Text = "0";
            this.lblTotalPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.gbContado);
            this.groupBox15.Controls.Add(this.cbCtadoCtaCte);
            this.groupBox15.Controls.Add(this.label17);
            this.groupBox15.Controls.Add(this.tbFormaPagoID);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox15.Location = new System.Drawing.Point(0, 0);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(784, 88);
            this.groupBox15.TabIndex = 160;
            this.groupBox15.TabStop = false;
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
            this.gbContado.Enabled = false;
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
            this.cbAdicional.Enabled = false;
            this.cbAdicional.ItemHeight = 13;
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
            this.butAgregarPago.Enabled = false;
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
            this.cbTipoPagoDetalle.Enabled = false;
            this.cbTipoPagoDetalle.ItemHeight = 13;
            this.cbTipoPagoDetalle.Location = new System.Drawing.Point(176, 32);
            this.cbTipoPagoDetalle.Name = "cbTipoPagoDetalle";
            this.cbTipoPagoDetalle.Size = new System.Drawing.Size(160, 21);
            this.cbTipoPagoDetalle.TabIndex = 152;
            this.cbTipoPagoDetalle.SelectedIndexChanged += new System.EventHandler(this.cbTipoPagoDetalle_SelectedIndexChanged);
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPago.Enabled = false;
            this.cbTipoPago.ItemHeight = 13;
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
            this.tbImportePago.Enabled = false;
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
            // cbCtadoCtaCte
            // 
            this.cbCtadoCtaCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCtadoCtaCte.Enabled = false;
            this.cbCtadoCtaCte.ItemHeight = 13;
            this.cbCtadoCtaCte.Location = new System.Drawing.Point(8, 40);
            this.cbCtadoCtaCte.Name = "cbCtadoCtaCte";
            this.cbCtadoCtaCte.Size = new System.Drawing.Size(136, 21);
            this.cbCtadoCtaCte.TabIndex = 154;
            this.cbCtadoCtaCte.SelectedIndexChanged += new System.EventHandler(this.cbCtadoCtaCte_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 16);
            this.label17.TabIndex = 153;
            this.label17.Text = "Contado/Cta. Cte.";
            // 
            // tbFormaPagoID
            // 
            this.tbFormaPagoID.Location = new System.Drawing.Point(8, 64);
            this.tbFormaPagoID.Name = "tbFormaPagoID";
            this.tbFormaPagoID.Size = new System.Drawing.Size(16, 20);
            this.tbFormaPagoID.TabIndex = 149;
            this.tbFormaPagoID.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Teal;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 118;
            this.pictureBox2.TabStop = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Teal;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(792, 32);
            this.lbTitulo.TabIndex = 95;
            this.lbTitulo.Text = "     Factura Nº:";
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
            this.tabPrincipal.Size = new System.Drawing.Size(800, 464);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "Nro.   .";
            this.dataGridTextBoxColumn18.MappingName = "id";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 50;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Fecha Creación";
            this.dataGridTextBoxColumn1.MappingName = "Fecha Creación";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 140;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Razón Social";
            this.dataGridTextBoxColumn2.MappingName = "Razón Social";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 140;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Dirección Cliente";
            this.dataGridTextBoxColumn3.MappingName = "Dirección Cliente";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 140;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "CUIT";
            this.dataGridTextBoxColumn4.MappingName = "CUIT";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Dirección Entrega";
            this.dataGridTextBoxColumn5.MappingName = "Dirección Entrega";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 140;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn6.Format = "N";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Bonif. %  .";
            this.dataGridTextBoxColumn6.MappingName = "Bonif. %";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn7.Format = "C";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "SubTotal 1  .";
            this.dataGridTextBoxColumn7.MappingName = "SubTotal 1";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn8.Format = "C";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "IVA 1  .";
            this.dataGridTextBoxColumn8.MappingName = "IVA 1";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn9.Format = "C";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "IVA 2  .";
            this.dataGridTextBoxColumn9.MappingName = "IVA 2";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn10.Format = "C";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Total";
            this.dataGridTextBoxColumn10.MappingName = "total";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 75;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn11.Format = "C";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "SubTotal 2  .";
            this.dataGridTextBoxColumn11.MappingName = "SubTotal 2";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn12.Format = "C";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Bonificación  .";
            this.dataGridTextBoxColumn12.MappingName = "Bonificación";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 75;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Máquina";
            this.dataGridTextBoxColumn13.MappingName = "Máquina";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Tipo IVA";
            this.dataGridTextBoxColumn14.MappingName = "Tipo IVA";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 75;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "Vendedor";
            this.dataGridTextBoxColumn15.MappingName = "Vendedor";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 75;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "Estado";
            this.dataGridTextBoxColumn16.MappingName = "Estado";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "Autorizó";
            this.dataGridTextBoxColumn17.MappingName = "Autorizó";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 75;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "Tipo de Pago";
            this.dataGridTextBoxColumn19.MappingName = "Tipo Pago";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 150;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "Detalle";
            this.dataGridTextBoxColumn20.MappingName = "Detalle";
            this.dataGridTextBoxColumn20.ReadOnly = true;
            this.dataGridTextBoxColumn20.Width = 300;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn21.Format = "C";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "Importe   .";
            this.dataGridTextBoxColumn21.MappingName = "Importe";
            this.dataGridTextBoxColumn21.ReadOnly = true;
            this.dataGridTextBoxColumn21.Width = 75;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn22.Format = "C";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Ajuste   .";
            this.dataGridTextBoxColumn22.MappingName = "Ajuste";
            this.dataGridTextBoxColumn22.ReadOnly = true;
            this.dataGridTextBoxColumn22.Width = 75;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn23.Format = "C";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "Pesos   .";
            this.dataGridTextBoxColumn23.MappingName = "Pesos";
            this.dataGridTextBoxColumn23.ReadOnly = true;
            this.dataGridTextBoxColumn23.Width = 75;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            // 
            // ucFacturaConsulta
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucFacturaConsulta";
            this.Size = new System.Drawing.Size(800, 464);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabFiltro1.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.gbFechaEmision.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbProveedor.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.gbCuentaCorrienteB.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabNotaPedido.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbPieItems.ResumeLayout(false);
            this.gbPieItems.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.gbContado.ResumeLayout(false);
            this.gbContado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ucFacturaConsulta_Load(object sender, System.EventArgs e)
		{
			tbRazonSocialB.Select();
		}

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 21;  //Tipo Factura
				rbAsc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 15;  //Nro Factura
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
			
				//Si es Factura con descuento, le cambia el nombre a la tabla para que tome otro TableStyle
				string nombreTabla = "";
                switch (this.tipoPresentacion)
                {
                    case "":
                        nombreTabla = "Items";
                        break;
                    case "FACTURA_CON_DESCUENTO":
                        nombreTabla = "FacturaDescuento";
                        break;
                    case "CONSULTA_DESDE_RECIBO":
                        nombreTabla = "Items";
                        break;
                    case "CONSULTA_DESDE_NOTACREDITO":
                        nombreTabla = "Items";
                        break;
                }

				oSQLDataAdapter.TableMappings.Add("Table", nombreTabla);

				oSQLDataAdapter.SelectCommand = oComm;

				//initialize dataset
				DataSet dsItems = new DataSet(nombreTabla);
				oSQLDataAdapter.Fill(dsItems);

				//prepare dataview to sort
				DataView dvItems;
				dvItems = new DataView(dsItems.Tables[nombreTabla]);
				//dgItems.DataSource = dvItems;
				dgItems.DataSource = dsItems.Tables[nombreTabla];
				dgItems.Visible = true;

				//close connection
				oConn.Close();

				if (this.consultaRapida)
				{
					if (dvItems.Table.Rows.Count>0)
						butAceptar1.Select();
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
				string sql = "SELECT     dbo.Factura.fecha_creacion AS Fecha, dbo.Factura.clienteID, dbo.Cliente.apellido, dbo.Cliente.nombres, dbo.Factura.nombreCliente AS [Razón Social], " +
                      "dbo.Factura.ivaIDCliente, dbo.IVA.descripcion AS IVA, dbo.Factura.direccionCliente AS [Dirección Cliente], dbo.Factura.cuitCliente AS CUIT,  " +
                      "dbo.Factura.id, dbo.Factura.direccionEntrega AS [Dirección Entrega], dbo.Factura.vendedorID,  " +
                      "dbo.Usuario.apellido + ', ' + dbo.Usuario.nombre AS Vendedor, dbo.Factura.autorizadorBonificacionID,  " +
                      "Usuario_1.apellido + ', ' + Usuario_1.nombre AS Autorizó, dbo.tv_NotaPedidoCondicionEntrega.descripcion AS [Condición de Entrega],  " +
                      "dbo.Factura.condicionEntregaID, dbo.Factura.bonificacion AS [Bonif. %], dbo.Factura.subTotal1 AS [SubTotal 1], dbo.Factura.iva1 AS [IVA 1],  " +
                      "dbo.Factura.iva2 AS [IVA 2], dbo.Factura.total, dbo.Factura.estadoFacturaID, dbo.Factura.maquinaID, dbo.Maquina.nombre AS Máquina,  " +
                      "dbo.Factura.subTotal2 AS [SubTotal 2], dbo.Factura.bonificacionImporte AS [Bonif. Importe], dbo.Factura.formaPagoID, dbo.Factura.facturaSuc,  " +
                      "dbo.Factura.facturaNro, dbo.Factura.facturaTipo AS [Tipo Factura], dbo.Factura.facturaSuc + '-' + dbo.Factura.facturaNro AS [Nro. Factura],  " +
                      "dbo.Factura.jornadaVentaID, dbo.Factura.sucursalID, RIGHT('00' + RTRIM(LTRIM(CAST(dbo.Sucursal.numero AS char(2)))), 2)  " +
                      "+ ' - ' + dbo.Sucursal.nombre AS Sucursal, dbo.Factura.notaPedidoID, dbo.tv_FacturaEstado.descripcion AS Estado,  " +
                      "dbo.Factura.estadoCuentaCorrienteID, dbo.tv_FacturaCuentaCorrienteEstado.descripcion AS [Estado Cta. Cte.],  " +
                      "dbo.tv_PlazoPago.descripcion AS [Plazo Pago], dbo.JornadaVenta.jornadaVentaNro AS [Ejercicio Nro.], dbo.NotaPedido.notaPedidoSuc,  " +
                      "dbo.NotaPedido.notaPedidoNro, dbo.NotaPedido.notaPedidoSuc + '-' + dbo.NotaPedido.notaPedidoNro AS [Nota Pedido] " +
					"FROM         dbo.NotaPedido RIGHT OUTER JOIN " +
                      "dbo.Factura ON dbo.NotaPedido.id = dbo.Factura.notaPedidoID LEFT OUTER JOIN " +
                      "dbo.JornadaVenta ON dbo.Factura.jornadaVentaID = dbo.JornadaVenta.id LEFT OUTER JOIN " +
                      "dbo.FormaPago INNER JOIN " +
                      "dbo.tv_PlazoPago ON dbo.FormaPago.plazoPagoID = dbo.tv_PlazoPago.id ON dbo.Factura.formaPagoID = dbo.FormaPago.id LEFT OUTER JOIN " +
                      "dbo.tv_FacturaCuentaCorrienteEstado ON dbo.Factura.estadoCuentaCorrienteID = dbo.tv_FacturaCuentaCorrienteEstado.id LEFT OUTER JOIN " +
                      "dbo.tv_FacturaEstado ON dbo.Factura.estadoFacturaID = dbo.tv_FacturaEstado.id LEFT OUTER JOIN " +
                      "dbo.Sucursal ON dbo.Factura.sucursalID = dbo.Sucursal.id LEFT OUTER JOIN " +
                      "dbo.Maquina ON dbo.Factura.maquinaID = dbo.Maquina.id LEFT OUTER JOIN " +
                      "dbo.tv_NotaPedidoCondicionEntrega ON dbo.Factura.condicionEntregaID = dbo.tv_NotaPedidoCondicionEntrega.id LEFT OUTER JOIN " +
                      "dbo.Vendedor Vendedor_1 INNER JOIN " +
                      "dbo.Usuario Usuario_1 ON Vendedor_1.usuarioID = Usuario_1.id ON dbo.Factura.autorizadorBonificacionID = Vendedor_1.id LEFT OUTER JOIN " +
                      "dbo.Usuario INNER JOIN " +
                      "dbo.Vendedor ON dbo.Usuario.id = dbo.Vendedor.usuarioID ON dbo.Factura.vendedorID = dbo.Vendedor.id LEFT OUTER JOIN " +
                      "dbo.IVA ON dbo.Factura.ivaIDCliente = dbo.IVA.id LEFT OUTER JOIN " +
                      "dbo.Cliente ON dbo.Factura.clienteID = dbo.Cliente.id " +
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

				//Filtro Rapido
				if (cbFacturaTipoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND facturaTipo ='" + cbFacturaTipoB.Text.Trim() + "'";
				}
				if (tbFacturaSucDesdeB.Text!="" && tbFacturaNroDesdeB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Factura.facturaSuc AS int) >= " + int.Parse(tbFacturaSucDesdeB.Text);
					filtro = filtro + " AND CAST(dbo.Factura.facturaNro AS int) >= " + int.Parse(tbFacturaNroDesdeB.Text);
				}
				if (tbFacturaSucHastaB.Text!="" && tbFacturaNroHastaB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Factura.facturaSuc AS int) <= " + int.Parse(tbFacturaSucHastaB.Text);
					filtro = filtro + " AND CAST(dbo.Factura.facturaNro AS int) <= " + int.Parse(tbFacturaNroHastaB.Text);
				}
				if (tbRazonSocialB.Text!="") 
				{
					filtro = filtro + " AND dbo.Factura.nombreCliente LIKE '%" + tbRazonSocialB.Text.Trim() + "%'";
				}
				if (tbCuitB.Text!="") 
				{
					filtro = filtro + " AND dbo.Factura.cuitCliente = " + tbCuitB.Text.Trim();
				}
				//Fechas
				DateTime fechaDesde, fechaHasta;
				string dia, mes, anio, sfechaDesde, sfechaHasta;
				if (chkFechaEmision.Checked)
				{
					fechaDesde = dtpFechaEmisionDesde.Value;
					fechaHasta = dtpFechaEmisionHasta.Value;
					dia = fechaDesde.Day.ToString("00");
					mes = fechaDesde.Month.ToString("00");
					anio = fechaDesde.Year.ToString("0000");
					sfechaDesde = "{ts '" + anio + "-" + mes + "-" + dia + " 00:00:00'}";
					filtro = filtro + " AND dbo.Factura.fecha_creacion >= " + sfechaDesde;
				
					dia = fechaHasta.Day.ToString("00");
					mes = fechaHasta.Month.ToString("00");
					anio = fechaHasta.Year.ToString("0000");
					sfechaHasta = "{ts '" + anio + "-" + mes + "-" + dia + " 23:59:59'}";
					filtro = filtro + " AND dbo.Factura.fecha_creacion <= " + sfechaHasta;
				}
				if (cbBonificacionB.Text=="Con Bonif.") 
				{
					filtro = filtro + " AND dbo.Factura.bonificacion > 0";
				}
				else if  (cbBonificacionB.Text=="Sin Bonif.") 
				{
					filtro = filtro + " AND dbo.Factura.bonificacion = 0";
				}
				if (cbAutorizadorB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Factura.autorizadorBonificacionID = CAST('" + cbAutorizadorB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}

				//Filtro Avanzado
				if (tbNotaPedidoSucDesdeB.Text!="" && tbNotaPedidoNroDesdeB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoSuc AS int) >= " + int.Parse(tbNotaPedidoSucDesdeB.Text);
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoNro AS int) >= " + int.Parse(tbNotaPedidoNroDesdeB.Text);
				}
				if (tbNotaPedidoSucHastaB.Text!="" && tbNotaPedidoNroHastaB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoSuc AS int) <= " + int.Parse(tbNotaPedidoSucHastaB.Text);
					filtro = filtro + " AND CAST(dbo.NotaPedido.notaPedidoNro AS int) <= " + int.Parse(tbNotaPedidoNroHastaB.Text);
				}
				if (cbVendedorB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Factura.vendedorID = CAST('" + cbVendedorB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (tbEjercicioNroB.Text!="")
				{
					filtro += " AND dbo.JornadaVenta.jornadaVentaNro = " + tbEjercicioNroB.Text;
				}
				if (cbCondicionEntregaB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Factura.condicionEntregaID = CAST('" + cbCondicionEntregaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbEstadoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Factura.estadoFacturaID = CAST('" + cbEstadoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbSucursalB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.Factura.sucursalID = CAST('" + cbSucursalB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbPlazoPagoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND dbo.FormaPago.plazoPagoID = CAST('" + cbPlazoPagoB.SelectedValue.ToString() + "' AS uniqueidentifier)";

					if (cbEstadoFacturaCtaCteB.SelectedIndex>0)
						filtro = filtro + " AND dbo.Factura.estadoCuentaCorrienteID = CAST('" + cbEstadoFacturaCtaCteB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
                if (tbClienteIDB.Text != "")
                {
                    filtro += " AND dbo.Factura.clienteID = CAST('" + tbClienteIDB.Text + "' AS uniqueidentifier)";
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

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			try
			{
				cbFacturaTipoB.SelectedIndex = 0;
				tbFacturaSucDesdeB.Text = "";
				tbFacturaNroDesdeB.Text = "";
				tbFacturaSucHastaB.Text = "";
				tbFacturaNroHastaB.Text = "";
				tbRazonSocialB.Text = "";
				tbCuitB.Text = "";
				chkFechaEmision.Checked = false;
				cbBonificacionB.SelectedIndex = 0;
				cbAutorizadorB.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
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
							//tabNotaPedido.Enabled = true;
						}
						else
							tabNotaPedido.Enabled = false;
					else
						tabNotaPedido.Enabled = false;
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

						tbFacturaID.Text = dt.Rows[currentRow]["ID"].ToString();
						tbClienteID.Text = dt.Rows[currentRow]["clienteID"].ToString();
						tbClienteNombre.Text = dt.Rows[currentRow]["Razón Social"].ToString();
						tbDireccion.Text = dt.Rows[currentRow]["Dirección Cliente"].ToString();
						tbDireccionEntrega.Text = dt.Rows[currentRow]["Dirección Entrega"].ToString();
						tbCUIT.Text = dt.Rows[currentRow]["CUIT"].ToString();

                        //Pone el numero y el estado en el titulo
                        string nroFactura = dt.Rows[currentRow]["facturaSuc"].ToString() + "-" + dt.Rows[currentRow]["facturaNro"].ToString();
                        string estadoFactura = dt.Rows[currentRow]["Estado"].ToString();
                        string estadoCtaCte = dt.Rows[currentRow]["Estado Cta. Cte."].ToString();
                        lbTitulo.Text = "     Factura Nº: " + nroFactura + ", " + estadoFactura + ", " + estadoCtaCte;
	

						UtilUI.llenarCombo(ref cbVendedor, this.conexion, "sp_getAllVendedors", "", -1);
						cbVendedor.SelectedValue = dt.Rows[currentRow]["vendedorID"].ToString();
					
						UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
						cbIVA.SelectedValue = dt.Rows[currentRow]["ivaIDCliente"].ToString();

						UtilUI.llenarCombo(ref cbEstado, this.conexion, "sp_getAlltv_FacturaEstados", "", -1);
						cbEstado.SelectedValue = dt.Rows[currentRow]["estadoFacturaID"].ToString();

						UtilUI.llenarCombo(ref cbCondicionEntrega, this.conexion, "sp_getAlltv_NotaPedidoCondicionEntrega", "", -1);
						cbCondicionEntrega.SelectedValue = dt.Rows[currentRow]["condicionEntregaID"].ToString();

						UtilUI.llenarCombo(ref cbAutorizadorBonificacion, this.conexion, "sp_getAllVendedors", "", -1);
						cbAutorizadorBonificacion.SelectedValue = dt.Rows[currentRow]["autorizadorBonificacionID"].ToString();

						//Subtotal 1
						decimal subTotal1 = decimal.Parse(dt.Rows[currentRow]["SubTotal 1"].ToString());
						lblSubTotal1.Text = subTotal1.ToString("C");

						//Bonificacion
						decimal bonificacionPorc = decimal.Parse(dt.Rows[currentRow]["Bonif. %"].ToString());
						tbBonificacion.Text = bonificacionPorc.ToString("N");
						decimal bonificacionImp = decimal.Parse(dt.Rows[currentRow]["Bonif. Importe"].ToString());
						lblBonificacion.Text = bonificacionImp.ToString("C");

						//Subtotal 2
						decimal subTotal2 = decimal.Parse(dt.Rows[currentRow]["SubTotal 2"].ToString());
						lblSubTotal2.Text = subTotal2.ToString("C");

						//Iva 1
						//decimal iva1Porc = configuracion.parametros
						decimal iva1Imp = decimal.Parse(dt.Rows[currentRow]["IVA 1"].ToString());
						lblIva1.Text = iva1Imp.ToString("C");
						//Iva 2
						//decimal iva2Porc = configuracion.parametros
						decimal iva2Imp = decimal.Parse(dt.Rows[currentRow]["IVA 2"].ToString());
						lblIva2.Text = iva2Imp.ToString("C");

						//Total general
						decimal total = decimal.Parse(dt.Rows[currentRow]["total"].ToString());
						lblTotal.Text = total.ToString("C");


						/********************************
						 * Carga los items en la grilla
						 * ******************************/
						//Borra los registros de la grilla de SubArticulos
						DataTable tabla = (DataTable)dgSubArticulos.DataSource;
						tabla.Rows.Clear();
						//Carga los articulos componentes
						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@facturaID", new System.Guid(tbFacturaID.Text));
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllFacturaLineas", param);
						if (dr.HasRows)
						{
							while (dr.Read())
							{
								DataRow newRow = tabla.NewRow();
								newRow["itemNro"] = dr["itemNro"].ToString();
								newRow["Código Interno"] = dr["codigoInterno"].ToString();
								newRow["Código de Barras"] = dr["codigoBarras"].ToString();
								newRow["Cantidad"] = dr["cantidad"].ToString();
								newRow["Rubro"] = dr["Rubro"].ToString();
								newRow["Sub Rubro"] = dr["SubRubro"].ToString();
								newRow["Descripción"] = dr["descripcion"].ToString();
								newRow["articuloID"] = dr["articuloID"].ToString();
								newRow["Precio"] = dr["precioUnitario"].ToString();
								newRow["precioTotal"] = dr["precioTotal"].ToString();
								newRow["precioTotalConDesc"] = dr["precioTotalConDesc"].ToString();
								newRow["Promocion"] = dr["aplicaPromocion"].ToString()=="1" ? true : false;
								newRow["Descuento"] = dr["descuento"].ToString();
								tabla.Rows.Add(newRow);
							}
						}
						dr.Close();


						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();
						lblRegistro2.Text = lblRegistro.Text;

						//Carga las formas de pago
						cargarFormasPago(dt.Rows[currentRow]["formaPagoID"].ToString());

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
			//limpiarFormulario();
		}

		private void limpiarFormularioFormasPago()
		{
			try
			{
				//Limpia solo las Formas de pago
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

				/*
				if (tbRazonSocial.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar la Razón Social.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				*/

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
			/*

			int localidadID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidad, "sp_InsertLocalidad");
			int provinciaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvincia, "sp_InsertProvincia");

			SqlParameter[] param = new SqlParameter[13];
			
			param[0] = new SqlParameter("@ID", tbID.Text.Trim());
			param[1] = new SqlParameter("@razonSocial", tbRazonSocial.Text.Trim());
			param[2] = new SqlParameter("@calle", tbCalle.Text.Trim());
			param[3] = new SqlParameter("@telefonos", tbTelefonos.Text.Trim());
			param[4] = new SqlParameter("@nro", tbNro.Text.Trim());
			param[5] = new SqlParameter("@piso", tbPiso.Text.Trim());
			param[6] = new SqlParameter("@oficina", tbOficina.Text.Trim());
			param[7] = new SqlParameter("@codigoPostal", tbCodPost.Text.Trim());
			param[8] = new SqlParameter("@email", tbEmail.Text.Trim());
			param[9] = new SqlParameter("@localidadID", localidadID);
			param[10] = new SqlParameter("@cuit", tbCuit.Text.Trim());
			param[11] = new SqlParameter("@provinciaID", provinciaID);
			param[12] = new SqlParameter("@notas", tbNotas.Text.Trim());
			
			while (true)
			{
				try 
				{
					SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarProveedor", param);
					MessageBox.Show("Proveedor modificado con éxito.", "Modificación de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Proveedor modificado con éxito.", false);
					break;
				}
				catch (Exception e)
				{
					DialogResult dr = MessageBox.Show("No se pudo modificar el Proveedor. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
					UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Proveedor. \r\n" + e.Message, false);
					if (dr != DialogResult.Retry)
						break;
				}
			}
			*/
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
							DialogResult dr = MessageBox.Show("¿Desea borrar las Notas de Pedido seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Notas de Pedido...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarProveedor", param);

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

		private void butLimpiar3_Click(object sender, System.EventArgs e)
		{
			acomodarCombosOrden();
		}

		private void tbReazonSocialB_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				ejecutarBusqueda();
			}
		}

		private void butAceptar1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				cbFacturaTipoB.SelectedIndex = 0;
				cbBonificacionB.SelectedIndex = 0;

				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
				UtilUI.llenarCombo(ref cbAutorizadorB, this.conexion, "sp_getAllVendedorsBySucursal", "Todos", 0, param);
				UtilUI.llenarCombo(ref cbVendedorB, this.conexion, "sp_getAllVendedorsBySucursal", "Todos", 0, param);
				UtilUI.llenarCombo(ref cbEstadoB, this.conexion, "sp_getAlltv_FacturaEstados", "Todos", 0);
				UtilUI.llenarCombo(ref cbCondicionEntregaB, this.conexion, "sp_getAlltv_NotaPedidoCondicionEntrega", "Todas", 0);
				UtilUI.llenarCombo(ref cbSucursalB, this.conexion, "sp_getAllSucursals", "Todas", 0);
				UtilUI.llenarCombo(ref cbPlazoPagoB, this.conexion, "sp_getAlltv_PlazoPago", "Todos", 0);
				UtilUI.llenarCombo(ref cbEstadoFacturaCtaCteB, this.conexion, "sp_getAlltv_FacturaCuentaCorrienteEstados", "Todos", 0);
				acomodarCombosOrden();

				//Define el tipo de consulta
				if (consultaRapida)
				{
					butSalir1.Visible = false;
					butAceptar1.Visible = true;
				}
				else
				{
					butSalir1.Visible = true;
					butAceptar1.Visible = false;
				}

				//Asigna la tabla a la datagrid
				dgSubArticulos.DataSource = (DataTable)dataset.Tables["v_Articulo"];

				//Controles del Tab Formas de Pago
				dgPagos.DataSource = (DataTable)datasetFormaPagoLineas.Tables["v_FormaPagoLinea"];
				UtilUI.llenarCombo(ref cbCtadoCtaCte, this.conexion, "sp_getAlltv_PlazoPago", "", 0); 
				UtilUI.llenarCombo(ref cbTipoPago, this.conexion, "sp_getAlltv_TipoPago", "", 0);
				UtilUI.llenarCombo(ref cbAdicional, this.conexion, "sp_getAlltv_CantidadPagos", "", 0);
				llenarTipoPagoDetalle();

				//Establece el tab inicial
				tabNotaPedido.SelectedIndex = 0;

                //Segun el tipo de presentacion
                switch (this.tipoPresentacion)
                {
                    case "FACTURA_CON_DESCUENTO":
                        configurarFacturaConDescuento();
                        break;
                    case "CONSULTA_DESDE_RECIBO":
                        configurarParaRecibo();
                        break;
                    case "CONSULTA_DESDE_NOTACREDITO":
                        configurarParaNotaCredito();
                        break;
                }
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Devuelve el ID seleccionado en la grilla
		public string getID()
		{
			string id = Utilidades.ID_VACIO;

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

		private void butBuscarCliente_Click(object sender, System.EventArgs e)
		{
			abrirConsultaRapida();
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
					ivaID = Utilidades.ID_VACIO;
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

		private void tbCodigoInternoAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void tbCodigoInternoAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
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

		private void tbCodigoBarrasAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void tbCodigoBarrasAC_Leave(object sender, System.EventArgs e)
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

		private void tbCantidadAC_Enter(object sender, System.EventArgs e)
		{
			try
			{
				controlarColorFondo(ref sender, "Enter");
				//Seleciona todo el texto
				tbCantidadAC.SelectAll();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbCantidadAC_Leave(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Leave");
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

		private void butBuscarArticuloAC_Click(object sender, System.EventArgs e)
		{
			abrirConsultaRapidaArticulos();
		}

		private void butBuscarArticuloAC_Enter(object sender, System.EventArgs e)
		{
			controlarColorFondo(ref sender, "Enter");
		}

		private void butBuscarArticuloAC_Leave(object sender, System.EventArgs e)
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

		//Agrega el articulo en la lista de articulos
		private void agregarArticulo(ref Control controlFocus)
		{
			try
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
			}
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

		//Calcula los subtotales
		private void calcularSubTotales()
		{
			try
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
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNotaPedidoNroDesdeB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega los ceros a la izquiera
				string notaPedidoSuc = tbNotaPedidoNroDesdeB.Text;
				Utilidades.agregarCerosIzquierda(ref notaPedidoSuc,8);
				tbNotaPedidoNroDesdeB.Text = notaPedidoSuc;

				//Pone el valor Hasta
				string notaPedidoNroDesdeB = tbNotaPedidoNroDesdeB.Text.Trim();
				string notaPedidoNroHastaB = tbNotaPedidoNroHastaB.Text.Trim();
				if (notaPedidoNroDesdeB!="")
				{
					if (notaPedidoNroHastaB=="" || int.Parse(notaPedidoNroHastaB)<int.Parse(notaPedidoNroDesdeB))
					{
						tbNotaPedidoSucHastaB.Text = tbNotaPedidoSucDesdeB.Text;
						tbNotaPedidoNroHastaB.Text = tbNotaPedidoNroDesdeB.Text;
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSuspender_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Nota de Pedido...", true);
				if (validarFormularioCabecera())
				{
					guardarNotaPedido(1);  //Estado: suspendida.
				
					//Cambia al tab principal de busqueda para que otro vendedor pueda seguir trabajando con otra Nota de Pedido
					tabPrincipal.SelectedIndex = 0;
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
				}
				if (((DataTable)dgSubArticulos.DataSource).Rows.Count==0)
				{
					mensaje += "   - Debe ingresar al menos un Artículo.\r\n";
					resultado = false;
				}

				*/
				if (mensaje!="")
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

		//Guarda la Nota de Pedido con el estado que se le indique.
		private void guardarNotaPedido(int estado)
		{
			try
			{
				//Primero guarda las formas de pago
				guardarFormasDePago();

				//Obtiene los valores
				string notaPedidoID = tbFacturaID.Text;
				string clienteID = tbClienteID.Text;
				string nombreCliente = tbClienteNombre.Text;
				string ivaIDCliente = cbIVA.SelectedValue.ToString();
				string direccionCliente = tbDireccion.Text;
				string cuitCliente = tbCUIT.Text;
				string direccionEntrega = tbDireccionEntrega.Text;
				string vendedorID = cbVendedor.SelectedValue.ToString();
				string condicionEntregaID = cbCondicionEntrega.Text;
				condicionEntregaID = condicionEntregaID=="Inmediata" ? "1" : "2";
				double bonificacion = double.Parse(tbBonificacion.Text);
				string autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
				double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
				double iva1 = double.Parse(lblIva1.Text, NumberStyles.Currency);
				double iva2 = double.Parse(lblIva2.Text, NumberStyles.Currency);
				double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
				string estadoNotaPedidoID = estado.ToString();
				string maquinaID = configuracion.maquina.id.ToString();
				double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
				double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
				string formaPagoID = tbFormaPagoID.Text=="" ? "0" : tbFormaPagoID.Text;

				SqlParameter[] param = new SqlParameter[20];
			
				param[0] = new SqlParameter("@notaPedidoID", new System.Guid(notaPedidoID));
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
				param[15] = new SqlParameter("@estadoNotaPedidoID", new System.Guid(estadoNotaPedidoID));
				param[16] = new SqlParameter("@maquinaID", new System.Guid(maquinaID));
				param[17] = new SqlParameter("@subTotal2", subTotal2);
				param[18] = new SqlParameter("@bonificacionImporte", bonificacionImporte);
				param[19] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));

				while (true)
				{
					try 
					{
						//Modifica la Nota de Pedido, la cabecera
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarNotaPedido", param);

					
						//Primero Borra los articulos componentes
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@notaPedidoID", new System.Guid(tbFacturaID.Text));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteNotaPedidoLinea", param);
					

						//Inserta los articulos
						string articuloID = Utilidades.ID_VACIO;
						string cantidad = "0";
						double descuento = 0;
						int itemNro = 0;
						string aplicaPromocion = "2";
						double precioTotal = 0;
						double precioTotalConDesc = 0;
						double precioUnitario = 0;

						DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
						for (int i=0; i<dtSubArticulos.Rows.Count; i++)
						{
							cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
							if (cantidad.Trim()!="")
							{
								articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
								descuento = double.Parse(dtSubArticulos.Rows[i]["descuento"].ToString(), NumberStyles.Any);
								itemNro = int.Parse(dtSubArticulos.Rows[i]["itemNro"].ToString());
								aplicaPromocion = dtSubArticulos.Rows[i]["promocion"].ToString();
								aplicaPromocion = aplicaPromocion=="True" ? "1" : "2";
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
					
						MessageBox.Show("Nota de Pedido guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Pedido guardada con éxito.", false);

						//Limpia el formulario
						//limpiarFormulario();

						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo guardar la Nota de Pedido. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Nota de Pedido. \r\n" + e.Message, false);
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

		private void butImprimirFactura_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (validarFormularioCabecera())
				{
					//Primero guarda la Nota de Pedido
					guardarNotaPedido(1);  //Estado 1: suspendida.
				
					//Luego la imprime
					if (imprimirNotaPedido(tbFacturaID.Text))
					{
						/*butCrearRemitos.Enabled = true;
						butSuspender.Enabled = false;
						butImprimirFactura.Enabled = false;*/
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
			return true;
		}

		private void butCancelar_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butCrearRemitos_Click(object sender, System.EventArgs e)
		{
			try
			{
				frmRemitoAlta frmRemit = new frmRemitoAlta(this.configuracion);
				frmRemit.statusBar1 = this.statusBarPrincipal;
				frmRemit.toolBar2 = null; 
				frmRemit.Show();
				frmRemit.ucRemitoAlta1.buscarNotaPedido(tbFacturaID.Text);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butContinuar1_Click(object sender, System.EventArgs e)
		{
			tabNotaPedido.SelectedIndex = 1;
			tbCodigoInternoAC.Select();
		}

		private void butContinuar2_Click(object sender, System.EventArgs e)
		{
			tabNotaPedido.SelectedIndex = 2;
			cbCtadoCtaCte.Select();
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
				if (cbAdicional.SelectedIndex>-1 && cbAdicional.Visible)
				{
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
				newRow["tipoPagoDetalleID"] = cbTipoPagoDetalle.SelectedValue!=null ? cbTipoPagoDetalle.SelectedValue : Utilidades.ID_VACIO;
				newRow["Detalle"] = detalle;
				newRow["Importe"] = double.Parse(tbImportePago.CurrencyValue(), NumberStyles.Currency);
				newRow["Ajuste"] = double.Parse(lblAjusteValor.Text, NumberStyles.Currency);
				newRow["Pesos"] = double.Parse(tbPesos.CurrencyValue(), NumberStyles.Currency);
				newRow["Nro. Cheque"] = tbAdicional.Text;

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


		private void tabNotaPedido_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//si el es tab de formas de pago, calcula los subtotales
			if (tabNotaPedido.SelectedIndex == 2)
				calcularSubTotalesPagos();		
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


		private void tbImportePago_Enter(object sender, System.EventArgs e)
		{
			tbImportePago.SelectAll();
		}

		//Carga las Formas de Pago
		private void cargarFormasPago(string formaPagoID)
		{
			try
			{
				SqlParameter[] paramFP = new SqlParameter[1];
				paramFP[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
				SqlDataReader drFormaPago = SqlHelper.ExecuteReader(this.conexion, "sp_getFormaPago", paramFP);
			
				if (drFormaPago.HasRows)
				{
					drFormaPago.Read();

					tbFormaPagoID.Text = drFormaPago["id"].ToString();

					cbCtadoCtaCte.SelectedValue = drFormaPago["plazoPagoID"].ToString();


					//Total Pagos
					double totalPagos = double.Parse(drFormaPago["totalPagos"].ToString());
					lblTotalPagos.Text = totalPagos.ToString("C");

					//Total Facturado
					double totalFacturado = double.Parse(drFormaPago["totalFacturado"].ToString());
					lblTotalFacturado.Text = totalFacturado.ToString("C");

					//Interes
					double interesVal = double.Parse(drFormaPago["interesVal"].ToString());
					lblInteresValV.Text = interesVal.ToString("C");

					//Total con interes
					double totalConInteres = double.Parse(drFormaPago["totalConInteres"].ToString());
					lblTotalConInteresV.Text = totalConInteres.ToString("C");

					//Interes Por
					double interesPor = double.Parse(drFormaPago["interesPor"].ToString());
					lblInteresPorV.Text = interesPor.ToString("N");

					//Saldo
					double saldo = double.Parse(drFormaPago["saldo"].ToString());
					lblSaldoPagos.Text = saldo.ToString("N");

					/********************************
					* Carga los items en la grilla
					* ******************************/
					//Borra los registros de la grilla de Pagos
					DataTable tabla = (DataTable)dgPagos.DataSource;
					tabla.Rows.Clear();
					//Carga los articulos componentes
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@formaPagoID", new System.Guid(tbFormaPagoID.Text));
					SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllFormaPagoLineas", param);
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							DataRow newRow = tabla.NewRow();
							newRow["tipoPagoID"] = dr["tipoPagoID"].ToString();
							newRow["tipoPagoDetalleID"] = dr["tipoPagoDetalleID"].ToString();
							newRow["importe"] = double.Parse(dr["importe"].ToString());
							newRow["ajuste"] = double.Parse(dr["ajuste"].ToString());
							newRow["pesos"] = double.Parse(dr["pesos"].ToString());
							newRow["Tipo Pago"] = dr["Tipo Pago"].ToString();
							newRow["identificador"] = dr["identificador"].ToString();
							newRow["operacion"] = dr["operacion"].ToString();
							newRow["Detalle"] = dr["Detalle"].ToString();
							newRow["Nro. Cheque"] = dr["Nro. Cheque"].ToString();
							newRow["bancoID"] = dr["bancoID"].ToString();
							newRow["cantidadPagosID"] = dr["cantidadPagosID"].ToString();
							newRow["ID"] = "";

							tabla.Rows.Add(newRow);
						}
					}
					dr.Close();
				}
				else
				{
					limpiarFormularioFormasPago();
					calcularSubTotalesPagos();	
				}
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

		//Guarda las Formas de Pago.
		private void guardarFormasDePago()
		{
			try
			{
				if (tbFormaPagoID.Text!="" && tbFormaPagoID.Text!=Utilidades.ID_VACIO)
				{
					//Obtiene los valores
					string formaPagoID = tbFormaPagoID.Text;
					string plazoPagoID = cbCtadoCtaCte.SelectedValue.ToString();
					double totalPagos = double.Parse(lblTotalPagos.Text, NumberStyles.Currency);
					double totalFacturado = double.Parse(lblTotalFacturado.Text, NumberStyles.Currency);
					double interesPor = double.Parse(lblInteresPorV.Text, NumberStyles.Currency);
					double interesVal = double.Parse(lblInteresValV.Text, NumberStyles.Currency);
					double totalConInteres = double.Parse(lblTotalConInteresV.Text, NumberStyles.Currency);
					double saldo = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);
				
					SqlParameter[] param = new SqlParameter[8];
				
					param[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
					param[1] = new SqlParameter("@plazoPagoID", new System.Guid(plazoPagoID));
					param[2] = new SqlParameter("@totalPagos", totalPagos);
					param[3] = new SqlParameter("@totalFacturado", totalFacturado);
					param[4] = new SqlParameter("@interesPor", interesPor);
					param[5] = new SqlParameter("@interesVal", interesVal);
					param[6] = new SqlParameter("@totalConInteres", totalConInteres);
					param[7] = new SqlParameter("@saldo", saldo);
				
					while (true)
					{
						try 
						{
							//Inserta el registro y obtiene el ID
							SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarFormaPago", param);
						
							//Primero Borra los items de la forma de pago
							param = new SqlParameter[1];
							param[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
							SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteFormaPagoLinea", param);

							//Inserta los items
							string tipoPagoID = Utilidades.ID_VACIO;
							string tipoPagoDetalleID = Utilidades.ID_VACIO;
							double importe = 0;
							double ajuste = 0;
							double pesos = 0;
							string nroCheque = "";
							string bancoID = Utilidades.ID_VACIO;
							string cantidadPagosID = Utilidades.ID_VACIO;

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
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbFacturaSucDesdeB_Validated(object sender, System.EventArgs e)
		{
			string facturaSuc = tbFacturaSucDesdeB.Text;
			Utilidades.agregarCerosIzquierda(ref facturaSuc,4);
			tbFacturaSucDesdeB.Text = facturaSuc;
		}

		private void tbFacturaSucHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string facturaSuc = tbFacturaSucHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref facturaSuc,4);
				tbFacturaSucHastaB.Text = facturaSuc;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbFacturaNroDesdeB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega los ceros a la izquiera
				string facturaSuc = tbFacturaNroDesdeB.Text;
				Utilidades.agregarCerosIzquierda(ref facturaSuc,8);
				tbFacturaNroDesdeB.Text = facturaSuc;

				//Pone el valor Hasta
				string facturaNroDesdeB = tbFacturaNroDesdeB.Text.Trim();
				string facturaNroHastaB = tbFacturaNroHastaB.Text.Trim();
				if (facturaNroDesdeB!="")
				{
					if (facturaNroHastaB=="" || int.Parse(facturaNroHastaB)<int.Parse(facturaNroDesdeB))
					{
						tbFacturaSucHastaB.Text = tbFacturaSucDesdeB.Text;
						tbFacturaNroHastaB.Text = tbFacturaNroDesdeB.Text;
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void campoEntero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				TextBox tb = (TextBox)sender;
				string valor = tb.Text.Trim().Replace(",","").Replace(".","");
				if (valor!="")
				{
					if (!Utilidades.IsNumeric(valor))
					{
						e.Cancel = true;
						MessageBox.Show("El valor del campo debe contener un número entero.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				tb.Text = valor;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbFacturaNroHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega ceros a la izquierda
				string facturaNro = tbFacturaNroHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref facturaNro,8);
				tbFacturaNroHastaB.Text = facturaNro;

				//Establece el valor desde
				string facturaNroDesdeB = tbFacturaNroDesdeB.Text.Trim();
				string facturaNroHastaB = tbFacturaNroHastaB.Text.Trim();
				if (facturaNroHastaB!="")
				{
					if (facturaNroDesdeB=="" || int.Parse(facturaNroDesdeB)>int.Parse(facturaNroHastaB))
						tbFacturaNroDesdeB.Text = tbFacturaNroHastaB.Text;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dtpFechaEmisionHasta_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaEmisionDesde.Value > dtpFechaEmisionHasta.Value)
				dtpFechaEmisionDesde.Value = dtpFechaEmisionHasta.Value;
		}

		private void dtpFechaEmisionDesde_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaEmisionHasta.Value < dtpFechaEmisionDesde.Value)
				dtpFechaEmisionHasta.Value = dtpFechaEmisionDesde.Value;
		}

		private void chkFechaEmision_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpFechaEmisionDesde.Enabled = chkFechaEmision.Checked;
			dtpFechaEmisionHasta.Enabled = chkFechaEmision.Checked;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				tbNotaPedidoNroDesdeB.Text = "";
				tbNotaPedidoNroHastaB.Text = "";
				cbVendedorB.SelectedIndex = 0;
				tbEjercicioNroB.Text = "";
				cbCondicionEntregaB.SelectedIndex = 0;
				cbEstadoB.SelectedIndex = 0;
				cbSucursalB.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Metodo que permite indicar que el control es de tipo Factura con Descuento
		public void configurarFacturaConDescuento()
		{
			try
			{
				//Establece la propiedad FacturaDescuento
				//this.facturaDescuento = true;
			
				//Obtiene el nro. de ejercicio
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getJornadaVentaAbierta");
				dr.Read();
				//tbEjercicioNroB.Text = dr["id"].ToString();
				tbEjercicioNroB.Text = dr["Nro."].ToString();
				cbBonificacionB.Text = "Con Bonif.";

				//Cambia el Titulo de la grilla
				dgItems.CaptionText = "     Facturas con Descuento";

				//Ejecuta la busqueda
				ejecutarBusqueda();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

        //Configura el formulario para buscar facturas desde un recibo.
        public void configurarParaRecibo()
        {
            try
            {
                //Cambia el Titulo de la grilla
                dgItems.CaptionText = "     Facturas Pendientes";

                //Configura el filtro
                tabFiltro.SelectedIndex = 2; //Selecciona el tab Cuenta Corriente
                UtilUI.comboSeleccionarItemByIdentificador("CUENTA_CORRIENTE", ref cbPlazoPagoB);
                UtilUI.comboSeleccionarItemByIdentificador("PENDIENTE", ref cbEstadoFacturaCtaCteB);
                tbClienteIDB.Text = this.clienteID;

                //Ejecuta la busqueda
                ejecutarBusqueda();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        //Configura el formulario para buscar facturas desde una nota de credito.
        public void configurarParaNotaCredito()
        {
            try
            {
                //Cambia el Titulo de la grilla
                dgItems.CaptionText = "     Facturas Impresas";

                //Configura el filtro
                tabFiltro.SelectedIndex = 0; //Selecciona el tab Filtro Avanzado
                UtilUI.comboSeleccionarItemByIdentificador("IMPRESA", ref cbEstadoB);

                //Ejecuta la busqueda
                ejecutarBusqueda();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

		private void butLimpiar4_Click(object sender, System.EventArgs e)
		{
			cbPlazoPagoB.SelectedIndex = 0;
			cbEstadoFacturaCtaCteB.SelectedIndex = 0;
		}

		private void butSalir4_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void cbPlazoPagoB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				DataTable dtPlazo = (DataTable)cbPlazoPagoB.DataSource;
				if (dtPlazo.Rows[cbPlazoPagoB.SelectedIndex]["identificador"].ToString()=="CUENTA_CORRIENTE")
					gbCuentaCorrienteB.Enabled = true;
				else
					gbCuentaCorrienteB.Enabled = false;

				dtPlazo = null;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNotaPedidoSucDesdeB_Validated(object sender, System.EventArgs e)
		{
			string notaPedidoSuc = tbNotaPedidoSucDesdeB.Text;
			Utilidades.agregarCerosIzquierda(ref notaPedidoSuc,4);
			tbNotaPedidoSucDesdeB.Text = notaPedidoSuc;
		}

		private void tbNotaPedidoSucHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				string notaPedidoSuc = tbNotaPedidoSucHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref notaPedidoSuc,4);
				tbNotaPedidoSucHastaB.Text = notaPedidoSuc;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbNotaPedidoNroHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega ceros a la izquierda
				string notaPedidoNro = tbNotaPedidoNroHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref notaPedidoNro,8);
				tbNotaPedidoNroHastaB.Text = notaPedidoNro;

				//Establece el valor desde
				string notaPedidoNroDesdeB = tbNotaPedidoNroDesdeB.Text.Trim();
				string notaPedidoNroHastaB = tbNotaPedidoNroHastaB.Text.Trim();
				if (notaPedidoNroHastaB!="")
				{
					if (notaPedidoNroDesdeB=="" || int.Parse(notaPedidoNroDesdeB)>int.Parse(notaPedidoNroHastaB))
						tbNotaPedidoNroDesdeB.Text = tbNotaPedidoNroHastaB.Text;
				}
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
				crListadoFacturas doc = new crListadoFacturas();

				doc.SetDataSource(((DataTable)dgItems.DataSource));

				doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

				string cadenaFiltro = ""; //obtenerCadenaFiltro();
				string cadenaOrden = ""; //obtenerCadenaOrden();
				if (cadenaFiltro!="")
					doc.DataDefinition.FormulaFields["txtFiltroF"].Text = "\"" + cadenaFiltro + "\"";
				else
					doc.Section1.ReportObjects["txtFiltroTitulo"].ObjectFormat.EnableSuppress = true;

				if (cadenaOrden!="")
					doc.DataDefinition.FormulaFields["txtOrdenF"].Text = "\"" + cadenaOrden + "\"";
				else
					doc.Section7.ReportObjects["txtOrdenTitulo"].ObjectFormat.EnableSuppress = true;

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
				crListadoFacturas doc = new crListadoFacturas();

				doc.SetDataSource(((DataTable)dgItems.DataSource));

				doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

				string cadenaFiltro = ""; //obtenerCadenaFiltro();
				string cadenaOrden = ""; //obtenerCadenaOrden();
				if (cadenaFiltro!="")
					doc.DataDefinition.FormulaFields["txtFiltroF"].Text = "\"" + cadenaFiltro + "\"";
				else
					doc.Section1.ReportObjects["txtFiltroTitulo"].ObjectFormat.EnableSuppress = true;

				if (cadenaOrden!="")
					doc.DataDefinition.FormulaFields["txtOrdenF"].Text = "\"" + cadenaOrden + "\"";
				else
					doc.Section7.ReportObjects["txtOrdenTitulo"].ObjectFormat.EnableSuppress = true;

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Reporte Listo.", false);

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

        private void butGuardarEstadoFactura_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cambiar el estado de esta Factura?", "Guardar cambio de Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@facturaID", new Guid(tbFacturaID.Text));
                    param[1] = new SqlParameter("@estadoFactura",UtilUI.obtenerIdentificadorCombo(ref cbEstado));

                    SqlHelper.ExecuteNonQuery(this.conexion, "sp_CambiarEstadoFactura", param);
                }
                catch (Exception ex)
                {
                    ManejadorErrores.escribirLog(ex, true, this.configuracion);
                }
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }


	}
}
