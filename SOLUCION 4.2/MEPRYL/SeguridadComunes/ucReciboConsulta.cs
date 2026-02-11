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
	/// Summary description for ucReciboConsulta.
	/// </summary>
	public class ucReciboConsulta : System.Windows.Forms.UserControl
	{
		
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		public bool consultaRapida = false;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.ComboBox cbEstadoB;
		private System.Windows.Forms.Button butAceptar1;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox tbCuitB;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox gbProveedor;
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
		private System.Windows.Forms.PictureBox pictureBox2;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
		private System.Windows.Forms.DataGridTableStyle dgtsItems;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24Items;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25Items;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26Items;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbReciboID;
		private System.Windows.Forms.TextBox tbClienteID;
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
		private System.Windows.Forms.DataGrid dgReciboLinea;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button butSuspender;
		private System.Windows.Forms.Button butContinuar2;
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
		private System.Windows.Forms.GroupBox gbConceptos;
		private System.Windows.Forms.Label lblGuion;
		private System.Windows.Forms.Button butAgregarConcepto;
		private KMCurrencyTextBox.KMCurrencyTextBox tbImporteAC;
		private System.Windows.Forms.TextBox tbDescripcionAC;
		private System.Windows.Forms.TextBox tbNroSucAC;
		private System.Windows.Forms.ComboBox cbConceptoAC;
		private System.Windows.Forms.TextBox tbNotaDebitoID;
		private System.Windows.Forms.TextBox tbNroAC;
		private System.Windows.Forms.TextBox tbFacturaID;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lblNro;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Button butBorrarPagos;
		private System.Windows.Forms.DataGrid dgPagos;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label lblInteresPorE;
		private System.Windows.Forms.Label lblInteresPorV;
		private System.Windows.Forms.Label lblTotalConInteresE;
		private System.Windows.Forms.Label lblInteresValE;
		private System.Windows.Forms.Label lblTotalConInteresV;
		private System.Windows.Forms.Label lblInteresValV;
		private System.Windows.Forms.Button butNuevoRecibo;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label lblTotalFacturado;
		private System.Windows.Forms.Label lblSaldoPagos;
		private System.Windows.Forms.Label lblTotalPagos;
		private System.Windows.Forms.Button butImprimirRecibo;
		private System.Windows.Forms.Button butSuspender2;
		private System.Windows.Forms.Button butCancelar2;
		private System.Windows.Forms.GroupBox groupBox9;
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
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbFormaPagoID;
		private System.Windows.Forms.TextBox tbReciboNroHastaB;
		private System.Windows.Forms.ComboBox cbUsuarioB;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.TextBox tbReciboSucDesdeB;
		private System.Windows.Forms.TextBox tbReciboNroDesdeB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbReciboSucHastaB;
		private System.Windows.Forms.TabControl tabRecibo;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		public DataSet datasetFormaPagoLineas = (DataSet) new dsFormaPagoLinea();
		private System.Windows.Forms.TextBox tbUsuarioID;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.Button butContinuar;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.GroupBox groupBox16;
		private System.Windows.Forms.Label lblRegistro2;
		private System.Windows.Forms.Button butSiguiente2;
		private System.Windows.Forms.Button butAnterior2;
		private System.Windows.Forms.Button butBorrarReciboLineas;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
		private System.Windows.Forms.Label lblTituloRecibo;
        private Button butBuscarConcepto;
        private ComboBox cbTipoComprobante;
        private DataGridTextBoxColumn dataGridTextBoxColumn44;
		public DataSet datasetReciboLinea = (DataSet) new dsReciboLinea();

		public ucReciboConsulta()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReciboConsulta));
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butVistaPrevia = new System.Windows.Forms.Button();
            this.butImprimir = new System.Windows.Forms.Button();
            this.butBorrar = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dgtsItems = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn24Items = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25Items = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26Items = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbReciboSucHastaB = new System.Windows.Forms.TextBox();
            this.tbReciboNroDesdeB = new System.Windows.Forms.TextBox();
            this.tbReciboNroHastaB = new System.Windows.Forms.TextBox();
            this.tbReciboSucDesdeB = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbEstadoB = new System.Windows.Forms.ComboBox();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbCuitB = new System.Windows.Forms.TextBox();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.cbUsuarioB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRazonSocialB = new System.Windows.Forms.TextBox();
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
            this.tabRecibo = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbUsuarioID = new System.Windows.Forms.TextBox();
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
            this.butContinuar = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.butBorrarReciboLineas = new System.Windows.Forms.Button();
            this.dgReciboLinea = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.butAnterior = new System.Windows.Forms.Button();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.butBorrarPagos = new System.Windows.Forms.Button();
            this.dgPagos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTituloRecibo = new System.Windows.Forms.Label();
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
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabRecibo.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReciboLinea)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbConceptos.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox9.SuspendLayout();
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
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista de Recibos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Wheat;
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
            this.butVistaPrevia.BackColor = System.Drawing.Color.Purple;
            this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVistaPrevia.Location = new System.Drawing.Point(376, 157);
            this.butVistaPrevia.Name = "butVistaPrevia";
            this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
            this.butVistaPrevia.TabIndex = 4;
            this.butVistaPrevia.Text = "&Vista Previa";
            this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butVistaPrevia.UseVisualStyleBackColor = false;
            this.butVistaPrevia.Visible = false;
            // 
            // butImprimir
            // 
            this.butImprimir.BackColor = System.Drawing.Color.Purple;
            this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimir.ForeColor = System.Drawing.Color.White;
            this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimir.Location = new System.Drawing.Point(296, 157);
            this.butImprimir.Name = "butImprimir";
            this.butImprimir.Size = new System.Drawing.Size(64, 23);
            this.butImprimir.TabIndex = 3;
            this.butImprimir.Text = "&Imprimir";
            this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimir.UseVisualStyleBackColor = false;
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
            this.dgItems.CaptionBackColor = System.Drawing.Color.Wheat;
            this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.CaptionForeColor = System.Drawing.Color.DarkGoldenrod;
            this.dgItems.CaptionText = "     Listado de Recibos";
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
            this.dgtsItems});
            this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            // 
            // dgtsItems
            // 
            this.dgtsItems.AllowSorting = false;
            this.dgtsItems.AlternatingBackColor = System.Drawing.Color.AntiqueWhite;
            this.dgtsItems.DataGrid = this.dgItems;
            this.dgtsItems.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn24Items,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn25Items,
            this.dataGridTextBoxColumn26Items,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn41});
            this.dgtsItems.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgtsItems.MappingName = "Items";
            this.dgtsItems.ReadOnly = true;
            // 
            // dataGridTextBoxColumn24Items
            // 
            this.dataGridTextBoxColumn24Items.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn24Items.Format = "";
            this.dataGridTextBoxColumn24Items.FormatInfo = null;
            this.dataGridTextBoxColumn24Items.HeaderText = "Nro.  .";
            this.dataGridTextBoxColumn24Items.MappingName = "Nro.";
            this.dataGridTextBoxColumn24Items.ReadOnly = true;
            this.dataGridTextBoxColumn24Items.Width = 50;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Recibo   .";
            this.dataGridTextBoxColumn25.MappingName = "Recibo";
            this.dataGridTextBoxColumn25.ReadOnly = true;
            this.dataGridTextBoxColumn25.Width = 75;
            // 
            // dataGridTextBoxColumn25Items
            // 
            this.dataGridTextBoxColumn25Items.Format = "";
            this.dataGridTextBoxColumn25Items.FormatInfo = null;
            this.dataGridTextBoxColumn25Items.HeaderText = "Fecha Creación";
            this.dataGridTextBoxColumn25Items.MappingName = "Fecha Creación";
            this.dataGridTextBoxColumn25Items.ReadOnly = true;
            this.dataGridTextBoxColumn25Items.Width = 140;
            // 
            // dataGridTextBoxColumn26Items
            // 
            this.dataGridTextBoxColumn26Items.Format = "";
            this.dataGridTextBoxColumn26Items.FormatInfo = null;
            this.dataGridTextBoxColumn26Items.HeaderText = "Razón Social";
            this.dataGridTextBoxColumn26Items.MappingName = "Razón Social";
            this.dataGridTextBoxColumn26Items.ReadOnly = true;
            this.dataGridTextBoxColumn26Items.Width = 140;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "Nombre Cliente";
            this.dataGridTextBoxColumn24.MappingName = "Nombre Cliente";
            this.dataGridTextBoxColumn24.ReadOnly = true;
            this.dataGridTextBoxColumn24.Width = 140;
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
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn34.Format = "C";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "Total";
            this.dataGridTextBoxColumn34.MappingName = "Total   .";
            this.dataGridTextBoxColumn34.ReadOnly = true;
            this.dataGridTextBoxColumn34.Width = 75;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn36.Format = "C";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "Bonificación  .";
            this.dataGridTextBoxColumn36.MappingName = "Bonificación";
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
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "Usuario";
            this.dataGridTextBoxColumn39.MappingName = "Usuario";
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
            this.tabFiltro.Size = new System.Drawing.Size(792, 152);
            this.tabFiltro.TabIndex = 0;
            // 
            // tabFiltro1
            // 
            this.tabFiltro1.Controls.Add(this.groupBox8);
            this.tabFiltro1.Controls.Add(this.groupBox7);
            this.tabFiltro1.Controls.Add(this.butAceptar1);
            this.tabFiltro1.Controls.Add(this.groupBox10);
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.Controls.Add(this.gbProveedor);
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.ImageIndex = 2;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.tbReciboSucHastaB);
            this.groupBox8.Controls.Add(this.tbReciboNroDesdeB);
            this.groupBox8.Controls.Add(this.tbReciboNroHastaB);
            this.groupBox8.Controls.Add(this.tbReciboSucDesdeB);
            this.groupBox8.Location = new System.Drawing.Point(8, 8);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 104);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Recibo Nro.";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde";
            // 
            // tbReciboSucHastaB
            // 
            this.tbReciboSucHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReciboSucHastaB.Location = new System.Drawing.Point(8, 72);
            this.tbReciboSucHastaB.Name = "tbReciboSucHastaB";
            this.tbReciboSucHastaB.Size = new System.Drawing.Size(56, 20);
            this.tbReciboSucHastaB.TabIndex = 2;
            this.tbReciboSucHastaB.Validated += new System.EventHandler(this.tbReciboSucHastaB_Validated);
            this.tbReciboSucHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbReciboNroDesdeB
            // 
            this.tbReciboNroDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReciboNroDesdeB.Location = new System.Drawing.Point(64, 32);
            this.tbReciboNroDesdeB.Name = "tbReciboNroDesdeB";
            this.tbReciboNroDesdeB.Size = new System.Drawing.Size(128, 20);
            this.tbReciboNroDesdeB.TabIndex = 1;
            this.tbReciboNroDesdeB.Validated += new System.EventHandler(this.tbReciboNroDesdeB_Validated);
            this.tbReciboNroDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbReciboNroHastaB
            // 
            this.tbReciboNroHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReciboNroHastaB.Location = new System.Drawing.Point(64, 72);
            this.tbReciboNroHastaB.Name = "tbReciboNroHastaB";
            this.tbReciboNroHastaB.Size = new System.Drawing.Size(128, 20);
            this.tbReciboNroHastaB.TabIndex = 3;
            this.tbReciboNroHastaB.Validated += new System.EventHandler(this.tbReciboNroHastaB_Validated);
            this.tbReciboNroHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // tbReciboSucDesdeB
            // 
            this.tbReciboSucDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReciboSucDesdeB.Location = new System.Drawing.Point(8, 32);
            this.tbReciboSucDesdeB.Name = "tbReciboSucDesdeB";
            this.tbReciboSucDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbReciboSucDesdeB.TabIndex = 0;
            this.tbReciboSucDesdeB.Validated += new System.EventHandler(this.tbReciboSucDesdeB_Validated);
            this.tbReciboSucDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.campoEntero_Validating);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbEstadoB);
            this.groupBox7.Location = new System.Drawing.Point(424, 64);
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
            this.cbEstadoB.TabIndex = 6;
            // 
            // butAceptar1
            // 
            this.butAceptar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar1.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar1.Image")));
            this.butAceptar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar1.Location = new System.Drawing.Point(632, 96);
            this.butAceptar1.Name = "butAceptar1";
            this.butAceptar1.Size = new System.Drawing.Size(72, 24);
            this.butAceptar1.TabIndex = 9;
            this.butAceptar1.Text = "&Aceptar";
            this.butAceptar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar1.Visible = false;
            this.butAceptar1.Click += new System.EventHandler(this.butAceptar1_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbCuitB);
            this.groupBox10.Location = new System.Drawing.Point(216, 64);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(200, 48);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "CUIT";
            // 
            // tbCuitB
            // 
            this.tbCuitB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCuitB.Location = new System.Drawing.Point(8, 16);
            this.tbCuitB.Name = "tbCuitB";
            this.tbCuitB.Size = new System.Drawing.Size(184, 20);
            this.tbCuitB.TabIndex = 5;
            this.tbCuitB.Validated += new System.EventHandler(this.tbImportePago_Enter);
            // 
            // butSalir1
            // 
            this.butSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir1.Image = ((System.Drawing.Image)(resources.GetObject("butSalir1.Image")));
            this.butSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir1.Location = new System.Drawing.Point(640, 88);
            this.butSalir1.Name = "butSalir1";
            this.butSalir1.Size = new System.Drawing.Size(64, 23);
            this.butSalir1.TabIndex = 8;
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
            this.butLimpiar1.TabIndex = 7;
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
            this.butBuscar1.TabIndex = 6;
            this.butBuscar1.Text = "&Buscar";
            this.butBuscar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar1.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.cbUsuarioB);
            this.gbProveedor.Location = new System.Drawing.Point(424, 8);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(200, 48);
            this.gbProveedor.TabIndex = 3;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Usuario";
            // 
            // cbUsuarioB
            // 
            this.cbUsuarioB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuarioB.ItemHeight = 13;
            this.cbUsuarioB.Location = new System.Drawing.Point(8, 16);
            this.cbUsuarioB.Name = "cbUsuarioB";
            this.cbUsuarioB.Size = new System.Drawing.Size(184, 21);
            this.cbUsuarioB.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRazonSocialB);
            this.groupBox1.Location = new System.Drawing.Point(216, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombre / Razón Social";
            // 
            // tbRazonSocialB
            // 
            this.tbRazonSocialB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRazonSocialB.Location = new System.Drawing.Point(8, 16);
            this.tbRazonSocialB.Name = "tbRazonSocialB";
            this.tbRazonSocialB.Size = new System.Drawing.Size(184, 20);
            this.tbRazonSocialB.TabIndex = 3;
            this.tbRazonSocialB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReazonSocialB_KeyPress);
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
            "Estado",
            "Fecha Creación",
            "Máquina",
            "Nombre Cliente",
            "Nro.",
            "Recibo",
            "Razón Social",
            "Total",
            "Usuario"});
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
            "Estado",
            "Fecha Creación",
            "Máquina",
            "Nombre Cliente",
            "Nro.",
            "Recibo",
            "Razón Social",
            "Total",
            "Usuario"});
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
            this.rbAsc1.Image = ((System.Drawing.Image)(resources.GetObject("rbAsc1.Image")));
            this.rbAsc1.Location = new System.Drawing.Point(232, 16);
            this.rbAsc1.Name = "rbAsc1";
            this.rbAsc1.Size = new System.Drawing.Size(24, 24);
            this.rbAsc1.TabIndex = 16;
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
            "Estado",
            "Fecha Creación",
            "Máquina",
            "Nombre Cliente",
            "Nro.",
            "Recibo",
            "Razón Social",
            "Total",
            "Usuario"});
            this.cbCampoOrden1.Location = new System.Drawing.Point(8, 16);
            this.cbCampoOrden1.Name = "cbCampoOrden1";
            this.cbCampoOrden1.Size = new System.Drawing.Size(216, 21);
            this.cbCampoOrden1.TabIndex = 14;
            // 
            // rbDesc1
            // 
            this.rbDesc1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDesc1.Checked = true;
            this.rbDesc1.Image = ((System.Drawing.Image)(resources.GetObject("rbDesc1.Image")));
            this.rbDesc1.Location = new System.Drawing.Point(264, 16);
            this.rbDesc1.Name = "rbDesc1";
            this.rbDesc1.Size = new System.Drawing.Size(24, 24);
            this.rbDesc1.TabIndex = 17;
            this.rbDesc1.TabStop = true;
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
            "Estado",
            "Fecha Creación",
            "Máquina",
            "Nombre Cliente",
            "Nro.",
            "Recibo",
            "Razón Social",
            "Total",
            "Usuario"});
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
            this.tabPage2.Controls.Add(this.tabRecibo);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.lblTituloRecibo);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.Visible = false;
            // 
            // tabRecibo
            // 
            this.tabRecibo.Controls.Add(this.tabPage3);
            this.tabRecibo.Controls.Add(this.tabPage4);
            this.tabRecibo.Controls.Add(this.tabPage5);
            this.tabRecibo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRecibo.HotTrack = true;
            this.tabRecibo.ImageList = this.imagenesTab;
            this.tabRecibo.ItemSize = new System.Drawing.Size(93, 18);
            this.tabRecibo.Location = new System.Drawing.Point(0, 32);
            this.tabRecibo.Name = "tabRecibo";
            this.tabRecibo.SelectedIndex = 0;
            this.tabRecibo.Size = new System.Drawing.Size(792, 406);
            this.tabRecibo.TabIndex = 153;
            this.tabRecibo.SelectedIndexChanged += new System.EventHandler(this.tabRecibo_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.butContinuar);
            this.tabPage3.ImageIndex = 4;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(784, 380);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Cabecera";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbUsuarioID);
            this.groupBox3.Controls.Add(this.tbReciboID);
            this.groupBox3.Controls.Add(this.tbClienteID);
            this.groupBox3.Controls.Add(this.cbIVA);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbCUIT);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.butBuscarCliente);
            this.groupBox3.Controls.Add(this.tbDireccion);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbClienteNombre);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 104);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // tbUsuarioID
            // 
            this.tbUsuarioID.Location = new System.Drawing.Point(704, 64);
            this.tbUsuarioID.Name = "tbUsuarioID";
            this.tbUsuarioID.Size = new System.Drawing.Size(24, 20);
            this.tbUsuarioID.TabIndex = 14;
            this.tbUsuarioID.Text = "0";
            this.tbUsuarioID.Visible = false;
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
            this.butBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarCliente.Location = new System.Drawing.Point(496, 48);
            this.butBuscarCliente.Name = "butBuscarCliente";
            this.butBuscarCliente.Size = new System.Drawing.Size(103, 24);
            this.butBuscarCliente.TabIndex = 6;
            this.butBuscarCliente.Text = "&Buscar Cliente";
            this.butBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // butContinuar
            // 
            this.butContinuar.BackColor = System.Drawing.SystemColors.Control;
            this.butContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butContinuar.Image = ((System.Drawing.Image)(resources.GetObject("butContinuar.Image")));
            this.butContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butContinuar.Location = new System.Drawing.Point(496, 216);
            this.butContinuar.Name = "butContinuar";
            this.butContinuar.Size = new System.Drawing.Size(103, 24);
            this.butContinuar.TabIndex = 158;
            this.butContinuar.Text = "&Continuar";
            this.butContinuar.UseVisualStyleBackColor = false;
            this.butContinuar.Click += new System.EventHandler(this.butContinuar_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.butBorrarReciboLineas);
            this.tabPage4.Controls.Add(this.dgReciboLinea);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.gbConceptos);
            this.tabPage4.ImageIndex = 5;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(784, 380);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Conceptos";
            this.tabPage4.Visible = false;
            // 
            // butBorrarReciboLineas
            // 
            this.butBorrarReciboLineas.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarReciboLineas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarReciboLineas.ForeColor = System.Drawing.Color.White;
            this.butBorrarReciboLineas.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarReciboLineas.Image")));
            this.butBorrarReciboLineas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarReciboLineas.Location = new System.Drawing.Point(224, 90);
            this.butBorrarReciboLineas.Name = "butBorrarReciboLineas";
            this.butBorrarReciboLineas.Size = new System.Drawing.Size(64, 20);
            this.butBorrarReciboLineas.TabIndex = 155;
            this.butBorrarReciboLineas.Text = "&Borrar";
            this.butBorrarReciboLineas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarReciboLineas.UseVisualStyleBackColor = false;
            this.butBorrarReciboLineas.Click += new System.EventHandler(this.butBorrarReciboLineas_Click);
            // 
            // dgReciboLinea
            // 
            this.dgReciboLinea.CaptionBackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgReciboLinea.CaptionForeColor = System.Drawing.Color.White;
            this.dgReciboLinea.CaptionText = "Conceptos";
            this.dgReciboLinea.DataMember = "";
            this.dgReciboLinea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReciboLinea.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgReciboLinea.Location = new System.Drawing.Point(0, 90);
            this.dgReciboLinea.Name = "dgReciboLinea";
            this.dgReciboLinea.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.dgReciboLinea.Size = new System.Drawing.Size(784, 178);
            this.dgReciboLinea.TabIndex = 157;
            this.dgReciboLinea.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgReciboLinea.CurrentCellChanged += new System.EventHandler(this.dgReciboLinea_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Bisque;
            this.dataGridTableStyle1.DataGrid = this.dgReciboLinea;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "v_ReciboLinea";
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "Concepto";
            this.dataGridTextBoxColumn26.MappingName = "Concepto";
            this.dataGridTextBoxColumn26.ReadOnly = true;
            this.dataGridTextBoxColumn26.Width = 140;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "Tipo";
            this.dataGridTextBoxColumn44.MappingName = "tipoComprobante";
            this.dataGridTextBoxColumn44.Width = 30;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Nro.";
            this.dataGridTextBoxColumn27.MappingName = "comprobanteSuc";
            this.dataGridTextBoxColumn27.ReadOnly = true;
            this.dataGridTextBoxColumn27.Width = 40;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Comprobante";
            this.dataGridTextBoxColumn29.MappingName = "comprobanteNro";
            this.dataGridTextBoxColumn29.ReadOnly = true;
            this.dataGridTextBoxColumn29.Width = 75;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "Descripción";
            this.dataGridTextBoxColumn31.MappingName = "descripcion";
            this.dataGridTextBoxColumn31.Width = 300;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn32.Format = "C";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "Importe   .";
            this.dataGridTextBoxColumn32.MappingName = "importe";
            this.dataGridTextBoxColumn32.Width = 75;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.butSuspender);
            this.groupBox4.Controls.Add(this.butContinuar2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lblSubTotal2);
            this.groupBox4.Controls.Add(this.lblBonificacion);
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.lblSubTotal1);
            this.groupBox4.Controls.Add(this.cbAutorizadorBonificacion);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblBonifica);
            this.groupBox4.Controls.Add(this.tbBonificacion);
            this.groupBox4.Controls.Add(this.butCancelar);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(784, 112);
            this.groupBox4.TabIndex = 156;
            this.groupBox4.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRegistro);
            this.groupBox2.Controls.Add(this.butSiguiente);
            this.groupBox2.Controls.Add(this.butAnterior);
            this.groupBox2.Location = new System.Drawing.Point(340, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 96);
            this.groupBox2.TabIndex = 159;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro";
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
            // butSuspender
            // 
            this.butSuspender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSuspender.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender.Image")));
            this.butSuspender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSuspender.Location = new System.Drawing.Point(8, 48);
            this.butSuspender.Name = "butSuspender";
            this.butSuspender.Size = new System.Drawing.Size(120, 24);
            this.butSuspender.TabIndex = 158;
            this.butSuspender.Text = "Suspender";
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
            this.butContinuar2.Text = "Continuar";
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
            this.label10.Location = new System.Drawing.Point(440, 32);
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
            this.lblBonificacion.Location = new System.Drawing.Point(520, 32);
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
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(8, 80);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(120, 24);
            this.butCancelar.TabIndex = 29;
            this.butCancelar.Text = "C&ancelar";
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
            this.gbConceptos.Size = new System.Drawing.Size(784, 90);
            this.gbConceptos.TabIndex = 153;
            this.gbConceptos.TabStop = false;
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoComprobante.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cbTipoComprobante.Location = new System.Drawing.Point(163, 31);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(35, 21);
            this.cbTipoComprobante.TabIndex = 162;
            // 
            // butBuscarConcepto
            // 
            this.butBuscarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarConcepto.Image")));
            this.butBuscarConcepto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarConcepto.Location = new System.Drawing.Point(11, 59);
            this.butBuscarConcepto.Name = "butBuscarConcepto";
            this.butBuscarConcepto.Size = new System.Drawing.Size(144, 25);
            this.butBuscarConcepto.TabIndex = 159;
            this.butBuscarConcepto.Text = "&Buscar";
            this.butBuscarConcepto.Click += new System.EventHandler(this.butBuscarConcepto_Click);
            // 
            // lblGuion
            // 
            this.lblGuion.Location = new System.Drawing.Point(232, 32);
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
            this.tbDescripcionAC.Location = new System.Drawing.Point(334, 32);
            this.tbDescripcionAC.Name = "tbDescripcionAC";
            this.tbDescripcionAC.Size = new System.Drawing.Size(202, 20);
            this.tbDescripcionAC.TabIndex = 154;
            this.tbDescripcionAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDescripcionAC_KeyPress);
            // 
            // tbNroSucAC
            // 
            this.tbNroSucAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroSucAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroSucAC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbNroSucAC.Location = new System.Drawing.Point(200, 32);
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
            this.cbConceptoAC.Size = new System.Drawing.Size(144, 21);
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
            this.tbNroAC.Location = new System.Drawing.Point(240, 32);
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
            this.label27.Location = new System.Drawing.Point(331, 16);
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
            this.lblNro.Location = new System.Drawing.Point(160, 16);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(128, 16);
            this.lblNro.TabIndex = 139;
            this.lblNro.Text = "Nro. Comprobante";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.butBorrarPagos);
            this.tabPage5.Controls.Add(this.dgPagos);
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Controls.Add(this.groupBox9);
            this.tabPage5.ImageIndex = 6;
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(784, 380);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Formas de Pago";
            this.tabPage5.Visible = false;
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
            this.dgPagos.CaptionBackColor = System.Drawing.Color.Wheat;
            this.dgPagos.CaptionForeColor = System.Drawing.Color.DarkGoldenrod;
            this.dgPagos.CaptionText = "Formas de Pago";
            this.dgPagos.DataMember = "";
            this.dgPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPagos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPagos.Location = new System.Drawing.Point(0, 88);
            this.dgPagos.Name = "dgPagos";
            this.dgPagos.Size = new System.Drawing.Size(784, 180);
            this.dgPagos.TabIndex = 158;
            this.dgPagos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.OldLace;
            this.dataGridTableStyle2.DataGrid = this.dgPagos;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn43});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "v_FormaPagoLinea";
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "Tipo de Pago";
            this.dataGridTextBoxColumn33.MappingName = "Tipo Pago";
            this.dataGridTextBoxColumn33.ReadOnly = true;
            this.dataGridTextBoxColumn33.Width = 150;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "Detalle";
            this.dataGridTextBoxColumn35.MappingName = "Detalle";
            this.dataGridTextBoxColumn35.ReadOnly = true;
            this.dataGridTextBoxColumn35.Width = 300;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn38.Format = "C";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "Importe   .";
            this.dataGridTextBoxColumn38.MappingName = "Importe";
            this.dataGridTextBoxColumn38.ReadOnly = true;
            this.dataGridTextBoxColumn38.Width = 75;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn42.Format = "C";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "Ajuste   .";
            this.dataGridTextBoxColumn42.MappingName = "Ajuste";
            this.dataGridTextBoxColumn42.ReadOnly = true;
            this.dataGridTextBoxColumn42.Width = 75;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn43.Format = "C";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "Pesos   .";
            this.dataGridTextBoxColumn43.MappingName = "Pesos";
            this.dataGridTextBoxColumn43.ReadOnly = true;
            this.dataGridTextBoxColumn43.Width = 75;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox16);
            this.groupBox6.Controls.Add(this.lblInteresPorE);
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
            this.groupBox6.Location = new System.Drawing.Point(0, 268);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(784, 112);
            this.groupBox6.TabIndex = 157;
            this.groupBox6.TabStop = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.lblRegistro2);
            this.groupBox16.Controls.Add(this.butSiguiente2);
            this.groupBox16.Controls.Add(this.butAnterior2);
            this.groupBox16.Location = new System.Drawing.Point(288, 8);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(104, 96);
            this.groupBox16.TabIndex = 166;
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
            // butNuevoRecibo
            // 
            this.butNuevoRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butNuevoRecibo.Image = ((System.Drawing.Image)(resources.GetObject("butNuevoRecibo.Image")));
            this.butNuevoRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNuevoRecibo.Location = new System.Drawing.Point(8, 48);
            this.butNuevoRecibo.Name = "butNuevoRecibo";
            this.butNuevoRecibo.Size = new System.Drawing.Size(120, 24);
            this.butNuevoRecibo.TabIndex = 158;
            this.butNuevoRecibo.Text = "&Nuevo Recibo";
            this.butNuevoRecibo.Visible = false;
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
            this.label34.Text = "Total Conceptos";
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
            // butImprimirRecibo
            // 
            this.butImprimirRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirRecibo.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirRecibo.Image")));
            this.butImprimirRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirRecibo.Location = new System.Drawing.Point(8, 16);
            this.butImprimirRecibo.Name = "butImprimirRecibo";
            this.butImprimirRecibo.Size = new System.Drawing.Size(120, 24);
            this.butImprimirRecibo.TabIndex = 31;
            this.butImprimirRecibo.Text = "&Imprimir Recibo";
            this.butImprimirRecibo.Visible = false;
            this.butImprimirRecibo.Click += new System.EventHandler(this.butImprimirRecibo_Click);
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
            this.butSuspender2.Text = "&Suspender";
            this.butSuspender2.Visible = false;
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
            this.butCancelar2.Text = "C&ancelar";
            this.butCancelar2.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.gbContado);
            this.groupBox9.Controls.Add(this.cbCtadoCtaCte);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.tbFormaPagoID);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(784, 88);
            this.groupBox9.TabIndex = 154;
            this.groupBox9.TabStop = false;
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
            // cbCtadoCtaCte
            // 
            this.cbCtadoCtaCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCtadoCtaCte.Location = new System.Drawing.Point(8, 40);
            this.cbCtadoCtaCte.Name = "cbCtadoCtaCte";
            this.cbCtadoCtaCte.Size = new System.Drawing.Size(136, 21);
            this.cbCtadoCtaCte.TabIndex = 154;
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
            this.tbFormaPagoID.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Wheat;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 118;
            this.pictureBox2.TabStop = false;
            // 
            // lblTituloRecibo
            // 
            this.lblTituloRecibo.BackColor = System.Drawing.Color.Wheat;
            this.lblTituloRecibo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloRecibo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRecibo.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTituloRecibo.Location = new System.Drawing.Point(0, 0);
            this.lblTituloRecibo.Name = "lblTituloRecibo";
            this.lblTituloRecibo.Size = new System.Drawing.Size(792, 32);
            this.lblTituloRecibo.TabIndex = 95;
            this.lblTituloRecibo.Text = "     Recibo Nº:";
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
            // ucReciboConsulta
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucReciboConsulta";
            this.Size = new System.Drawing.Size(800, 464);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabFiltro1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.gbProveedor.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabRecibo.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReciboLinea)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbConceptos.ResumeLayout(false);
            this.gbConceptos.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPagos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.gbContado.ResumeLayout(false);
            this.gbContado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ucReciboConsulta_Load(object sender, System.EventArgs e)
		{
			tbRazonSocialB.Select();
		}

		private void acomodarCombosOrden()
		{
			try
			{
				cbCampoOrden1.SelectedIndex = 9;  //Suc, descendente
				rbDesc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 10;  //Nro, descendente
				rbDesc2.Checked = true;
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
				string sql = "SELECT     dbo.Recibo.id, dbo.Recibo.fecha_creacion AS [Fecha Creación], dbo.Recibo.clienteID, dbo.Recibo.usuarioID, dbo.Recibo.bonificacion AS [Bonif. %], " +
                      "dbo.Recibo.autorizadorBonificacionID, dbo.Recibo.subTotal1, dbo.Recibo.total AS Total, dbo.Recibo.estadoReciboID, dbo.Recibo.maquinaID,  " +
                      "dbo.Recibo.subTotal2, dbo.Recibo.bonificacionImporte AS Bonificación, dbo.Recibo.formaPagoID, RTRIM(dbo.Cliente.apellido)  " +
                      "+ ', ' + RTRIM(dbo.Cliente.nombres) AS [Nombre Cliente], RTRIM(dbo.Usuario.apellido) + ', ' + RTRIM(dbo.Usuario.nombre) AS Usuario,  " +
                      "RTRIM(Usuario_1.apellido) + ', ' + RTRIM(Usuario_1.nombre) AS Autorizó, dbo.tv_ReciboEstado.identificador AS identificadorEstado,  " +
                      "dbo.Maquina.nombre AS Máquina, dbo.Cliente.empresa_cuit AS CUIT, dbo.tv_ReciboEstado.descripcion AS Estado,  " +
                      "dbo.tv_ClienteEmpresa.descripcion AS [Razón Social], dbo.Recibo.reciboSuc AS [Nro.], dbo.Recibo.reciboNro AS Recibo, dbo.Cliente.ivaID,  " +
                      "dbo.Cliente.empresa_calle AS [Calle (empresa)], dbo.Cliente.empresa_nro AS [Nro. (empresa)], dbo.Cliente.empresa_piso AS [Piso (empresa)],  " +
                      "dbo.Cliente.empresa_oficina AS [Of. (empresa)], dbo.Cliente.empresa_codPost AS [Cod.Post. (empresa)] " +
					"FROM         dbo.Usuario Usuario_1 INNER JOIN " +
                      "dbo.Vendedor ON Usuario_1.id = dbo.Vendedor.usuarioID RIGHT OUTER JOIN " +
                      "dbo.Maquina RIGHT OUTER JOIN " +
                      "dbo.Recibo ON dbo.Maquina.id = dbo.Recibo.maquinaID LEFT OUTER JOIN " +
                      "dbo.tv_ReciboEstado ON dbo.Recibo.estadoReciboID = dbo.tv_ReciboEstado.id ON  " +
                      "dbo.Vendedor.id = dbo.Recibo.autorizadorBonificacionID LEFT OUTER JOIN " +
                      "dbo.Usuario ON dbo.Recibo.usuarioID = dbo.Usuario.id LEFT OUTER JOIN " +
                      "dbo.tv_ClienteEmpresa RIGHT OUTER JOIN " +
                      "dbo.Cliente ON dbo.tv_ClienteEmpresa.id = dbo.Cliente.empresaID ON dbo.Recibo.clienteID = dbo.Cliente.id " +
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

				if (tbReciboSucDesdeB.Text!="" && tbReciboNroDesdeB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Recibo.reciboSuc AS int) >= " + int.Parse(tbReciboSucDesdeB.Text);
					filtro = filtro + " AND CAST(dbo.Recibo.reciboNro AS int) >= " + int.Parse(tbReciboNroDesdeB.Text);
				}
				if (tbReciboSucHastaB.Text!="" && tbReciboNroHastaB.Text!="") 
				{
					filtro = filtro + " AND CAST(dbo.Recibo.reciboSuc AS int) <= " + int.Parse(tbReciboSucHastaB.Text);
					filtro = filtro + " AND CAST(dbo.Recibo.reciboNro AS int) <= " + int.Parse(tbReciboNroHastaB.Text);
				}
			
				if (tbRazonSocialB.Text!="") 
				{
					filtro = filtro + " AND (dbo.tv_ClienteEmpresa.descripcion LIKE '%" + tbRazonSocialB.Text.Trim() + "%' OR RTRIM(dbo.Cliente.apellido) + ', ' + RTRIM(dbo.Cliente.nombres) LIKE '%" + tbRazonSocialB.Text.Trim() + "%')";
				}
				if (cbUsuarioB.SelectedIndex>0) 
				{
					filtro = filtro + " AND usuarioID = CAST('" + cbUsuarioB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (cbEstadoB.SelectedIndex>0) 
				{
					filtro = filtro + " AND estadoReciboID = CAST('" + cbEstadoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
				}
				if (tbCuitB.Text!="") 
				{
					filtro = filtro + " AND dbo.Cliente.empresa_cuit = " + tbCuitB.Text.Trim();
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
				tbRazonSocialB.Text = "";
				tbCuitB.Text = "";
				cbUsuarioB.SelectedIndex = 0;
				tbReciboSucDesdeB.Text = "";
				tbReciboSucHastaB.Text = "";
				tbReciboNroDesdeB.Text = "";
				tbReciboNroHastaB.Text = "";
				cbEstadoB.SelectedIndex = 0;
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
							tabRecibo.Enabled = true;
						}
						else
							tabRecibo.Enabled = false;
					else
						tabRecibo.Enabled = false;
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

						tbReciboID.Text = dt.Rows[currentRow]["ID"].ToString();
						tbClienteID.Text = dt.Rows[currentRow]["clienteID"].ToString();
						tbClienteNombre.Text = dt.Rows[currentRow]["Razón Social"].ToString();
						tbDireccion.Text = dt.Rows[currentRow]["Calle (empresa)"].ToString() 
							+ "  Nro.:" + dt.Rows[currentRow]["Nro. (empresa)"].ToString() 
							+ "  Piso:" + dt.Rows[currentRow]["Piso (empresa)"].ToString() 
							+ "  Of.:" + dt.Rows[currentRow]["Of. (empresa)"].ToString() 
							+ "  C.P.:" + dt.Rows[currentRow]["Cod.Post. (empresa)"].ToString();
						tbCUIT.Text = dt.Rows[currentRow]["CUIT"].ToString();
						tbUsuarioID.Text = dt.Rows[currentRow]["usuarioID"].ToString();
					
						UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
						cbIVA.SelectedValue = dt.Rows[currentRow]["ivaID"].ToString();

						//UtilUI.llenarCombo(ref cbEstado, this.conexion, "sp_getAlltv_ReciboEstados", "", -1);
						//cbEstado.SelectedValue = int.Parse(dt.Rows[currentRow]["estadoReciboID"].ToString());

						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
						UtilUI.llenarCombo(ref cbAutorizadorBonificacion, this.conexion, "sp_getAllVendedorsBySucursal", "", -1, param);
						cbAutorizadorBonificacion.SelectedValue = dt.Rows[currentRow]["autorizadorBonificacionID"].ToString();

						//Subtotal 1
						decimal subTotal1 = decimal.Parse(dt.Rows[currentRow]["subTotal1"].ToString());
						lblSubTotal1.Text = subTotal1.ToString("C");

						//Bonificacion
						decimal bonificacionPorc = decimal.Parse(dt.Rows[currentRow]["Bonif. %"].ToString());
						tbBonificacion.Text = bonificacionPorc.ToString("N");
						decimal bonificacionImp = decimal.Parse(dt.Rows[currentRow]["Bonificación"].ToString());
						lblBonificacion.Text = bonificacionImp.ToString("C");

						//Subtotal 2
						decimal subTotal2 = decimal.Parse(dt.Rows[currentRow]["subTotal2"].ToString());
						lblSubTotal2.Text = subTotal2.ToString("C");

						//Total general
						decimal total = decimal.Parse(dt.Rows[currentRow]["total"].ToString());
						lblTotal.Text = total.ToString("C");


						/********************************
						 * Carga los items en la grilla
						 * ******************************/
						//Borra los registros de la grilla de RebicoLinea
						DataTable tabla = (DataTable)dgReciboLinea.DataSource;
						tabla.Rows.Clear();
						//Carga las lineas del recibo
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@reciboID", new System.Guid(tbReciboID.Text));
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllReciboLineas", param);
						if (dr.HasRows)
						{
							while (dr.Read())
							{
								DataRow newRow = tabla.NewRow();
								newRow["reciboID"] = dr["reciboID"].ToString();
								newRow["conceptoID"] = dr["conceptoID"].ToString();
								newRow["facturaID"] = dr["facturaID"].ToString();
								newRow["notaDebitoID"] = dr["notaDebitoID"].ToString();
                                newRow["tipoComprobante"] = dr["tipoComprobante"].ToString();
								newRow["comprobanteSuc"] = dr["comprobanteSuc"].ToString();
								newRow["comprobanteNro"] = dr["comprobanteNro"].ToString();
								newRow["descripcion"] = dr["descripcion"].ToString();
								newRow["importe"] = double.Parse(dr["importe"].ToString(),NumberStyles.Currency);
								newRow["Concepto"] = dr["Concepto"].ToString();
								newRow["idConcepto"] = dr["idConcepto"].ToString();
                                newRow["id"] = dr["id"].ToString();
								tabla.Rows.Add(newRow);
							}
						}
						dr.Close();


						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();
						lblRegistro2.Text = lblRegistro.Text;

						//Carga las formas de pago
						cargarFormasPago(dt.Rows[currentRow]["formaPagoID"].ToString());

						//Pone el titulo
						lblTituloRecibo.Text = "     Recibo Nº: " + dt.Rows[currentRow]["Nro."].ToString() + "-" + dt.Rows[currentRow]["Recibo"].ToString();

						//Habilita los botones
						butSuspender.Enabled = true;
						butSuspender2.Enabled= true;
						if (dt.Rows[currentRow]["Estado"].ToString()=="Impreso")
							butImprimirRecibo.Enabled = false;
						else
							butImprimirRecibo.Enabled = true;

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
			if (MessageBox.Show("Se perderán los cambios efectuados.\r\n\r\n¿Desea salir de todas formas?", "Cancelar y Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
				((Form)this.Parent).Close();
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Proveedores seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Proveedores...", true);
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
				tbFacturaID.Text = Utilidades.ID_VACIO;
				tbNotaDebitoID.Text = Utilidades.ID_VACIO;

				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
				UtilUI.llenarCombo(ref cbUsuarioB, this.conexion, "sp_getAllUsuariosBySucursal", "Todos", 0, param);
				UtilUI.llenarCombo(ref cbEstadoB, this.conexion, "sp_getAlltv_ReciboEstados", "Todos", 0);
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

				//Controles Cabecera
				UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", 1); 

				//Controles Conceptos
				UtilUI.llenarCombo(ref cbConceptoAC, this.conexion, "sp_getAlltv_ReciboConcepto", "", 0); 
				param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
				UtilUI.llenarCombo(ref cbAutorizadorBonificacion, this.conexion, "sp_getAllVendedorsBySucursal", "", -1, param);

                cbTipoComprobante.SelectedIndex = 0;

				//Asigna la tabla a la datagrid
				dgReciboLinea.DataSource = (DataTable)datasetReciboLinea.Tables["v_ReciboLinea"];

				//Controles del Tab Formas de Pago
				dgPagos.DataSource = (DataTable)datasetFormaPagoLineas.Tables["v_FormaPagoLinea"];
				UtilUI.llenarCombo(ref cbCtadoCtaCte, this.conexion, "sp_getAlltv_PlazoPago", "", 0); 
				UtilUI.llenarCombo(ref cbTipoPago, this.conexion, "sp_getAlltv_TipoPago", "", 0);
				UtilUI.llenarCombo(ref cbAdicional, this.conexion, "sp_getAlltv_CantidadPagos", "", 0);
				llenarTipoPagoDetalle();

				//Establece el tab inicial
				tabRecibo.SelectedIndex = 1;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Devuelve el ID seleccionado en la grilla
		public string getID()
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

		private void borrarRegistrosArticulosComponentes()
		{/*
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
			}*/
		}

		//Renumera los items de la Tabla
		private void renumerarItems()
		{/*
			DataTable dt = (DataTable)dgSubArticulos.DataSource;

			for (int i=0; i<dt.Rows.Count; i++)
			{
				dt.Rows[i]["itemNro"] = i + 1;
			}*/
		}

		
		//Calcula los subtotales
		private void calcularSubTotales()
		{/*
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
*/
		}

		private void tbReciboNroDesdeB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega los ceros a la izquiera
				string reciboSuc = tbReciboNroDesdeB.Text;
				Utilidades.agregarCerosIzquierda(ref reciboSuc,8);
				tbReciboNroDesdeB.Text = reciboSuc;

				//Pone el valor Hasta
				string reciboNroDesdeB = tbReciboNroDesdeB.Text.Trim();
				string reciboNroHastaB = tbReciboNroHastaB.Text.Trim();
				if (reciboNroDesdeB!="")
				{
					if (reciboNroHastaB=="" || int.Parse(reciboNroHastaB)<int.Parse(reciboNroDesdeB))
					{
						tbReciboSucHastaB.Text = tbReciboSucDesdeB.Text;
						tbReciboNroHastaB.Text = tbReciboNroDesdeB.Text;
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

		private void tbReciboNroHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{
				//Agrega ceros a la izquierda
				string reciboSuc = tbReciboSucHastaB.Text;
				Utilidades.agregarCerosIzquierda(ref reciboSuc,8);
				tbReciboSucHastaB.Text = reciboSuc;

				//Establece el valor desde
				string reciboNroDesdeB = tbReciboNroDesdeB.Text.Trim();
				string reciboNroHastaB = tbReciboNroHastaB.Text.Trim();
				if (reciboNroHastaB!="")
				{
					if (reciboNroDesdeB=="" || int.Parse(reciboNroDesdeB)>int.Parse(reciboNroHastaB))
						tbReciboNroDesdeB.Text = tbReciboNroHastaB.Text;
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
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Recibo...", true);
				if (validarFormularioCabecera())
				{
					guardarRecibo("SUSPENDIDO");  //Estado 1: suspendida.
				
					//Limpia el formulario para que otro vendedor siga con otro Recibo
					//limpiarFormulario();
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

		//Guarda el Recibo con el estado que se le indique.
		private void guardarRecibo(string estado)
		{
			try
			{
				//Primero guarda las formas de pago
				guardarFormasDePago();

				//Obtiene los valores
				string reciboID = tbReciboID.Text;
				string clienteID = tbClienteID.Text;
				string usuarioID = tbUsuarioID.Text;
				double bonificacion = double.Parse(tbBonificacion.Text);
				string autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
				double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
				double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
				string estadoRecibo = estado;
				string maquinaID = configuracion.maquina.id.ToString();
				double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
				double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
				string formaPagoID = tbFormaPagoID.Text=="" ? "0" : tbFormaPagoID.Text;

				SqlParameter[] param = new SqlParameter[12];
			
				param[0] = new SqlParameter("@reciboID", new System.Guid(reciboID));
				param[1] = new SqlParameter("@clienteID", new System.Guid(clienteID));
				param[2] = new SqlParameter("@usuarioID", new System.Guid(usuarioID));
				param[3] = new SqlParameter("@bonificacion", bonificacion);
				param[4] = new SqlParameter("@autorizadorBonificacionID", new System.Guid(autorizadorBonificacionID));
				param[5] = new SqlParameter("@subTotal1", subTotal1);
				param[6] = new SqlParameter("@total", total);
				param[7] = new SqlParameter("@estadoRecibo", estadoRecibo);
				param[8] = new SqlParameter("@maquinaID", new System.Guid(maquinaID));
				param[9] = new SqlParameter("@subTotal2", subTotal2);
				param[10] = new SqlParameter("@bonificacionImporte", bonificacionImporte);
				param[11] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));

				while (true)
				{
					try 
					{
						//Modifica el Registro
						SqlHelper.ExecuteReader(this.conexion, "sp_ModificarRecibo", param);
					
						//Primero Borra las lineas del recibo
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@reciboID", new System.Guid(tbReciboID.Text));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteReciboLinea", param);

						//Inserta las lineas
						tbReciboID.Text = reciboID.ToString();
						string conceptoID = Utilidades.ID_VACIO;
						string facturaID = Utilidades.ID_VACIO;
						string notaDebitoID = Utilidades.ID_VACIO;
                        string comprobanteTipo = "";
                        string comprobanteSuc = "";
						string comprobanteNro = "";
						string descripcion = "";
						double importe = 0;
					
						DataTable dtReciboLinea = (DataTable)dgReciboLinea.DataSource;
						for (int i=0; i<dtReciboLinea.Rows.Count; i++)
						{
							string concepto = dtReciboLinea.Rows[i]["Concepto"].ToString();
							if (concepto.Trim()!="")
							{
								conceptoID = dtReciboLinea.Rows[i]["conceptoID"].ToString();
								facturaID = dtReciboLinea.Rows[i]["facturaID"].ToString();
								notaDebitoID = dtReciboLinea.Rows[i]["notaDebitoID"].ToString();
                                comprobanteTipo = dtReciboLinea.Rows[i]["tipoComprobante"].ToString();
								comprobanteSuc = dtReciboLinea.Rows[i]["comprobanteSuc"].ToString();
								comprobanteNro = dtReciboLinea.Rows[i]["comprobanteNro"].ToString();
								descripcion = dtReciboLinea.Rows[i]["descripcion"].ToString();
								importe = double.Parse(dtReciboLinea.Rows[i]["importe"].ToString(), NumberStyles.Currency);
								param = new SqlParameter[9];
								param[0] = new SqlParameter("@reciboID", new System.Guid(reciboID));
								param[1] = new SqlParameter("@conceptoID", new System.Guid(conceptoID));
								param[2] = new SqlParameter("@facturaID", new System.Guid(facturaID));
								param[3] = new SqlParameter("@notaDebitoID", new System.Guid(notaDebitoID));
                                param[4] = new SqlParameter("@tipoComprobante", comprobanteTipo);
                                param[5] = new SqlParameter("@comprobanteSuc", comprobanteSuc);
								param[6] = new SqlParameter("@comprobanteNro", comprobanteNro);
								param[7] = new SqlParameter("@descripcion", descripcion);
								param[8] = new SqlParameter("@importe", importe);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertReciboLinea", param);
							}
						}

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


		
		private void butImprimirFactura_Click(object sender, System.EventArgs e)
		{/*
			if (validarFormularioCabecera())
			{
				//Primero guarda la Nota de Pedido
				guardarNotaPedido(1);  //Estado 1: suspendida.
				
				//Luego la imprime
				if (imprimirNotaPedido(tbNotaPedidoID.Text))
				{
					//butCrearRemitos.Enabled = true;
					//butSuspender.Enabled = false;
					//butImprimirFactura.Enabled = false;
				}
			}*/
		}


		private void butCancelar_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}


		private void butContinuar2_Click(object sender, System.EventArgs e)
		{
			tabRecibo.SelectedIndex = 2;
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
			//if (tabNotaPedido.SelectedIndex == 2)
			//	calcularSubTotalesPagos();		
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
                            newRow["ID"] = dr["ID"].ToString();
                            newRow["formaPagoID"] = dr["formaPagoID"].ToString();
                            newRow["notaCreditoID"] = dr["notaCreditoID"].ToString();

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

		private void tbReciboSucDesdeB_Validated(object sender, System.EventArgs e)
		{
			string reciboSuc = tbReciboSucDesdeB.Text;
			Utilidades.agregarCerosIzquierda(ref reciboSuc,4);
			tbReciboSucDesdeB.Text = reciboSuc;
		}

		private void tbReciboSucHastaB_Validated(object sender, System.EventArgs e)
		{
			string reciboSuc = tbReciboSucHastaB.Text;
			Utilidades.agregarCerosIzquierda(ref reciboSuc,4);
			tbReciboSucHastaB.Text = reciboSuc;
		}

		private void butContinuar_Click(object sender, System.EventArgs e)
		{
			tabRecibo.SelectedIndex = 1;
		}

		private void tabRecibo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//si el es tab de formas de pago, calcula los subtotales
			if (tabRecibo.SelectedIndex == 2)
				calcularSubTotalesPagos();
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

		private void tbNroSucAC_Enter(object sender, System.EventArgs e)
		{
			tbNroSucAC.SelectAll();
		}

		private void tbNroSucAC_Validated(object sender, System.EventArgs e)
		{
			string facturaSuc = tbNroSucAC.Text;
			Utilidades.agregarCerosIzquierda(ref facturaSuc,4);
			tbNroSucAC.Text = facturaSuc;
		}

		private void tbNroSucAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				tbNroAC.Select();
			}
		}

		private void tbNroAC_Enter(object sender, System.EventArgs e)
		{
			tbNroAC.SelectAll();
		}

		private void tbNroAC_Validated(object sender, System.EventArgs e)
		{
			string facturaNro = tbNroAC.Text;
			Utilidades.agregarCerosIzquierda(ref facturaNro,8);
			tbNroAC.Text = facturaNro;
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
                string comprobanteTipo = cbTipoComprobante.Text;
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
                newRow["tipoComprobante"] = cbTipoComprobante.Text;
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

		private void butBorrarReciboLineas_Click(object sender, System.EventArgs e)
		{
			borrarReciboLineas();
		}

		private void borrarReciboLineas()
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

		private void tbBonificacion_Enter(object sender, System.EventArgs e)
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

		private void tbBonificacion_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tbBonificacion.SelectAll();
		}

		private void dgReciboLinea_CurrentCellChanged(object sender, System.EventArgs e)
		{
			calcularSubTotalesConceptos();
		}

		private void butImprimirRecibo_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (validarFormularioCabecera())
				{
					Recibo recibo = new Recibo(this.configuracion);

					//Primero guarda la Nota de Pedido
					guardarRecibo("SUSPENDIDO");  //Estado 1: suspendida.
				
					//Luego la imprime
					if (recibo.imprimirRecibo(tbReciboID.Text))
					{
						//Cambia el estado a IMPRESO
						recibo.cambiarEstadoRecibo(tbReciboID.Text, "IMPRESO");
						
						//butCrearRemitos.Enabled = true;
						butSuspender.Enabled = false;
						butSuspender2.Enabled = false;
						butImprimirRecibo.Enabled = false;
					}

					recibo = null;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
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
				tabRecibo.SelectedIndex = 0;
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

        private void butBuscarConcepto_Click(object sender, EventArgs e)
        {
            utilRecibo.buscarConcepto(this.configuracion, ref gbConceptos, tbClienteID.Text);
        }
	}
}
