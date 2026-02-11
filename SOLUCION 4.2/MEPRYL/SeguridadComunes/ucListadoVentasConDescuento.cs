using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for ucListadoVentasConDescuento.
	/// </summary>
	public class ucListadoVentasConDescuento : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox tbNotaPedidoNroHastaB;
		private System.Windows.Forms.TextBox tbNotaPedidoNroDesdeB;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.ComboBox cbEstadoB;
		private System.Windows.Forms.Button butAceptar1;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox tbCuitB;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbCondicionEntregaB;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox gbProveedor;
		private System.Windows.Forms.ComboBox cbVendedorB;
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
		private System.Windows.Forms.TextBox tbNotaPedidoID;
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
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.ComponentModel.IContainer components;

		public ucListadoVentasConDescuento()
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucListadoVentasConDescuento));
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.butVistaPrevia = new System.Windows.Forms.Button();
			this.butImprimir = new System.Windows.Forms.Button();
			this.butBorrar = new System.Windows.Forms.Button();
			this.dgItems = new System.Windows.Forms.DataGrid();
			this.tabFiltro = new System.Windows.Forms.TabControl();
			this.tabFiltro1 = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.tbNotaPedidoNroHastaB = new System.Windows.Forms.TextBox();
			this.tbNotaPedidoNroDesdeB = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cbEstadoB = new System.Windows.Forms.ComboBox();
			this.butAceptar1 = new System.Windows.Forms.Button();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.tbCuitB = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbCondicionEntregaB = new System.Windows.Forms.ComboBox();
			this.butSalir1 = new System.Windows.Forms.Button();
			this.butLimpiar1 = new System.Windows.Forms.Button();
			this.butBuscar1 = new System.Windows.Forms.Button();
			this.gbProveedor = new System.Windows.Forms.GroupBox();
			this.cbVendedorB = new System.Windows.Forms.ComboBox();
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
			this.tabNotaPedido = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.butContinuar1 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cbEstado = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cbVendedor = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbCondicionEntrega = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbDireccionEntrega = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbNotaPedidoID = new System.Windows.Forms.TextBox();
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
			this.label18 = new System.Windows.Forms.Label();
			this.tabPrincipal = new System.Windows.Forms.TabControl();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
			this.tabFiltro.SuspendLayout();
			this.tabFiltro1.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
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
			this.tabPrincipal.SuspendLayout();
			this.SuspendLayout();
			// 
			// imagenesTab
			// 
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
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
			this.tabPage1.ImageIndex = 4;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(792, 438);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Lista de Notas de Pedido";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Purple;
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
			this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
			this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butVistaPrevia.Location = new System.Drawing.Point(376, 157);
			this.butVistaPrevia.Name = "butVistaPrevia";
			this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
			this.butVistaPrevia.TabIndex = 4;
			this.butVistaPrevia.Text = "&Vista Previa";
			this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butVistaPrevia.Visible = false;
			// 
			// butImprimir
			// 
			this.butImprimir.BackColor = System.Drawing.Color.Purple;
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
			this.butBorrar.Visible = false;
			// 
			// dgItems
			// 
			this.dgItems.AllowSorting = false;
			this.dgItems.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dgItems.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgItems.BackgroundColor = System.Drawing.Color.LightGray;
			this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgItems.CaptionBackColor = System.Drawing.Color.Purple;
			this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgItems.CaptionForeColor = System.Drawing.Color.White;
			this.dgItems.CaptionText = "     Listado Notas de Pedido";
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
			// 
			// tabFiltro
			// 
			this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabFiltro.Controls.Add(this.tabFiltro1);
			this.tabFiltro.Controls.Add(this.tabFiltro3);
			this.tabFiltro.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabFiltro.HotTrack = true;
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
			this.tabFiltro1.Controls.Add(this.groupBox2);
			this.tabFiltro1.Controls.Add(this.butSalir1);
			this.tabFiltro1.Controls.Add(this.butLimpiar1);
			this.tabFiltro1.Controls.Add(this.butBuscar1);
			this.tabFiltro1.Controls.Add(this.gbProveedor);
			this.tabFiltro1.Controls.Add(this.groupBox1);
			this.tabFiltro1.ImageIndex = 1;
			this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
			this.tabFiltro1.Name = "tabFiltro1";
			this.tabFiltro1.Size = new System.Drawing.Size(784, 126);
			this.tabFiltro1.TabIndex = 0;
			this.tabFiltro1.Text = "Filtro Rápido";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.tbNotaPedidoNroHastaB);
			this.groupBox8.Controls.Add(this.tbNotaPedidoNroDesdeB);
			this.groupBox8.Location = new System.Drawing.Point(8, 8);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(200, 48);
			this.groupBox8.TabIndex = 15;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Nota Pedido Nro.";
			// 
			// tbNotaPedidoNroHastaB
			// 
			this.tbNotaPedidoNroHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNotaPedidoNroHastaB.Location = new System.Drawing.Point(104, 16);
			this.tbNotaPedidoNroHastaB.Name = "tbNotaPedidoNroHastaB";
			this.tbNotaPedidoNroHastaB.Size = new System.Drawing.Size(88, 20);
			this.tbNotaPedidoNroHastaB.TabIndex = 1;
			this.tbNotaPedidoNroHastaB.Text = "";
			// 
			// tbNotaPedidoNroDesdeB
			// 
			this.tbNotaPedidoNroDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNotaPedidoNroDesdeB.Location = new System.Drawing.Point(8, 16);
			this.tbNotaPedidoNroDesdeB.Name = "tbNotaPedidoNroDesdeB";
			this.tbNotaPedidoNroDesdeB.Size = new System.Drawing.Size(88, 20);
			this.tbNotaPedidoNroDesdeB.TabIndex = 0;
			this.tbNotaPedidoNroDesdeB.Text = "";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.cbEstadoB);
			this.groupBox7.Location = new System.Drawing.Point(424, 64);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(200, 48);
			this.groupBox7.TabIndex = 13;
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
			// butAceptar1
			// 
			this.butAceptar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAceptar1.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar1.Image")));
			this.butAceptar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAceptar1.Location = new System.Drawing.Point(632, 96);
			this.butAceptar1.Name = "butAceptar1";
			this.butAceptar1.Size = new System.Drawing.Size(72, 24);
			this.butAceptar1.TabIndex = 12;
			this.butAceptar1.Text = "&Aceptar";
			this.butAceptar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAceptar1.Visible = false;
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.tbCuitB);
			this.groupBox10.Location = new System.Drawing.Point(8, 64);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(200, 48);
			this.groupBox10.TabIndex = 11;
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
			this.tbCuitB.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbCondicionEntregaB);
			this.groupBox2.Location = new System.Drawing.Point(216, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 48);
			this.groupBox2.TabIndex = 10;
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
			// 
			// gbProveedor
			// 
			this.gbProveedor.Controls.Add(this.cbVendedorB);
			this.gbProveedor.Location = new System.Drawing.Point(424, 8);
			this.gbProveedor.Name = "gbProveedor";
			this.gbProveedor.Size = new System.Drawing.Size(200, 48);
			this.gbProveedor.TabIndex = 5;
			this.gbProveedor.TabStop = false;
			this.gbProveedor.Text = "Vendedor";
			// 
			// cbVendedorB
			// 
			this.cbVendedorB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbVendedorB.ItemHeight = 13;
			this.cbVendedorB.Location = new System.Drawing.Point(8, 16);
			this.cbVendedorB.Name = "cbVendedorB";
			this.cbVendedorB.Size = new System.Drawing.Size(184, 21);
			this.cbVendedorB.TabIndex = 10;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbRazonSocialB);
			this.groupBox1.Location = new System.Drawing.Point(216, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Nombre / Razón Social";
			// 
			// tbRazonSocialB
			// 
			this.tbRazonSocialB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRazonSocialB.Location = new System.Drawing.Point(8, 16);
			this.tbRazonSocialB.Name = "tbRazonSocialB";
			this.tbRazonSocialB.Size = new System.Drawing.Size(184, 20);
			this.tbRazonSocialB.TabIndex = 1;
			this.tbRazonSocialB.Text = "";
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
															   "Estado",
															   "Fecha Creación",
															   "IVA 1",
															   "IVA 2",
															   "Máquina",
															   "Nro.",
															   "Razón Social",
															   "SubTotal 1",
															   "SubTotal 2",
															   "Tipo IVA",
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
															   "Estado",
															   "Fecha Creación",
															   "IVA 1",
															   "IVA 2",
															   "Máquina",
															   "Nro.",
															   "Razón Social",
															   "SubTotal 1",
															   "SubTotal 2",
															   "Tipo IVA",
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
															   "Dirección Cliente",
															   "Dirección Entrega",
															   "Estado",
															   "Fecha Creación",
															   "IVA 1",
															   "IVA 2",
															   "Máquina",
															   "Nro.",
															   "Razón Social",
															   "SubTotal 1",
															   "SubTotal 2",
															   "Tipo IVA",
															   "Vendedor"});
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
															   "Dirección Cliente",
															   "Dirección Entrega",
															   "Estado",
															   "Fecha Creación",
															   "IVA 1",
															   "IVA 2",
															   "Máquina",
															   "Nro.",
															   "Razón Social",
															   "SubTotal 1",
															   "SubTotal 2",
															   "Tipo IVA",
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
			this.tabPage2.Controls.Add(this.label18);
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
			this.tabNotaPedido.ItemSize = new System.Drawing.Size(93, 18);
			this.tabNotaPedido.Location = new System.Drawing.Point(0, 32);
			this.tabNotaPedido.Name = "tabNotaPedido";
			this.tabNotaPedido.SelectedIndex = 0;
			this.tabNotaPedido.Size = new System.Drawing.Size(792, 406);
			this.tabNotaPedido.TabIndex = 154;
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
			// 
			// butContinuar1
			// 
			this.butContinuar1.BackColor = System.Drawing.SystemColors.Control;
			this.butContinuar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butContinuar1.Image = ((System.Drawing.Image)(resources.GetObject("butContinuar1.Image")));
			this.butContinuar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butContinuar1.Location = new System.Drawing.Point(464, 240);
			this.butContinuar1.Name = "butContinuar1";
			this.butContinuar1.Size = new System.Drawing.Size(96, 24);
			this.butContinuar1.TabIndex = 159;
			this.butContinuar1.Text = "&Continuar";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cbEstado);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.cbVendedor);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.cbCondicionEntrega);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.tbDireccionEntrega);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.tbNotaPedidoID);
			this.groupBox3.Controls.Add(this.tbClienteID);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 120);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 104);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
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
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(496, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(184, 16);
			this.label15.TabIndex = 10;
			this.label15.Text = "Estado Nota de Pedido";
			// 
			// cbVendedor
			// 
			this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.tbDireccionEntrega.Size = new System.Drawing.Size(208, 20);
			this.tbDireccionEntrega.TabIndex = 5;
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
			// tbNotaPedidoID
			// 
			this.tbNotaPedidoID.Location = new System.Drawing.Point(456, 64);
			this.tbNotaPedidoID.Name = "tbNotaPedidoID";
			this.tbNotaPedidoID.Size = new System.Drawing.Size(24, 20);
			this.tbNotaPedidoID.TabIndex = 13;
			this.tbNotaPedidoID.Text = "";
			this.tbNotaPedidoID.Visible = false;
			// 
			// tbClienteID
			// 
			this.tbClienteID.Location = new System.Drawing.Point(456, 32);
			this.tbClienteID.Name = "tbClienteID";
			this.tbClienteID.Size = new System.Drawing.Size(24, 20);
			this.tbClienteID.TabIndex = 12;
			this.tbClienteID.Text = "";
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
			this.tbCUIT.Size = new System.Drawing.Size(208, 20);
			this.tbCUIT.TabIndex = 8;
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
			this.butBuscarCliente.BackColor = System.Drawing.Color.Gainsboro;
			this.butBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarCliente.Image")));
			this.butBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBuscarCliente.Location = new System.Drawing.Point(464, 48);
			this.butBuscarCliente.Name = "butBuscarCliente";
			this.butBuscarCliente.Size = new System.Drawing.Size(96, 24);
			this.butBuscarCliente.TabIndex = 6;
			this.butBuscarCliente.Text = "Buscar Cliente";
			this.butBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.dgSubArticulos.SelectionBackColor = System.Drawing.Color.MediumBlue;
			this.dgSubArticulos.Size = new System.Drawing.Size(784, 180);
			this.dgSubArticulos.TabIndex = 154;
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
			this.tbPromocionAC.Text = "";
			this.tbPromocionAC.Visible = false;
			// 
			// tbPrecioAC
			// 
			this.tbPrecioAC.Location = new System.Drawing.Point(656, 8);
			this.tbPrecioAC.Name = "tbPrecioAC";
			this.tbPrecioAC.Size = new System.Drawing.Size(16, 20);
			this.tbPrecioAC.TabIndex = 148;
			this.tbPrecioAC.Text = "";
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
			// 
			// tbID
			// 
			this.tbID.Location = new System.Drawing.Point(672, 8);
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
			// 
			// tbDescripcionAC
			// 
			this.tbDescripcionAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tbDescripcionAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.tbSubRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSubRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbSubRubroAC.Location = new System.Drawing.Point(408, 32);
			this.tbSubRubroAC.Name = "tbSubRubroAC";
			this.tbSubRubroAC.Size = new System.Drawing.Size(112, 48);
			this.tbSubRubroAC.TabIndex = 145;
			// 
			// tbRubroAC
			// 
			this.tbRubroAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tbRubroAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbRubroAC.ForeColor = System.Drawing.Color.ForestGreen;
			this.tbRubroAC.Location = new System.Drawing.Point(288, 32);
			this.tbRubroAC.Name = "tbRubroAC";
			this.tbRubroAC.Size = new System.Drawing.Size(112, 48);
			this.tbRubroAC.TabIndex = 144;
			// 
			// butBuscarArticuloAC
			// 
			this.butBuscarArticuloAC.BackColor = System.Drawing.Color.Gainsboro;
			this.butBuscarArticuloAC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBuscarArticuloAC.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarArticuloAC.Image")));
			this.butBuscarArticuloAC.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.butBuscarArticuloAC.Location = new System.Drawing.Point(248, 32);
			this.butBuscarArticuloAC.Name = "butBuscarArticuloAC";
			this.butBuscarArticuloAC.Size = new System.Drawing.Size(24, 24);
			this.butBuscarArticuloAC.TabIndex = 137;
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
			this.butSuspender2.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender2.Image")));
			this.butSuspender2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSuspender2.Location = new System.Drawing.Point(8, 48);
			this.butSuspender2.Name = "butSuspender2";
			this.butSuspender2.Size = new System.Drawing.Size(120, 24);
			this.butSuspender2.TabIndex = 162;
			this.butSuspender2.Text = "&Suspender";
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
			// 
			// butContinuar2
			// 
			this.butContinuar2.BackColor = System.Drawing.SystemColors.Control;
			this.butContinuar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butContinuar2.Image = ((System.Drawing.Image)(resources.GetObject("butContinuar2.Image")));
			this.butContinuar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butContinuar2.Location = new System.Drawing.Point(184, 64);
			this.butContinuar2.Name = "butContinuar2";
			this.butContinuar2.Size = new System.Drawing.Size(144, 24);
			this.butContinuar2.TabIndex = 160;
			this.butContinuar2.Text = "&Continuar";
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblSubTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblBonificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblIva2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblIva1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblSubTotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			// 
			// butBorrarArticulosComponentes
			// 
			this.butBorrarArticulosComponentes.BackColor = System.Drawing.Color.Maroon;
			this.butBorrarArticulosComponentes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBorrarArticulosComponentes.ForeColor = System.Drawing.Color.White;
			this.butBorrarArticulosComponentes.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarArticulosComponentes.Image")));
			this.butBorrarArticulosComponentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBorrarArticulosComponentes.Location = new System.Drawing.Point(48, 104);
			this.butBorrarArticulosComponentes.Name = "butBorrarArticulosComponentes";
			this.butBorrarArticulosComponentes.Size = new System.Drawing.Size(64, 20);
			this.butBorrarArticulosComponentes.TabIndex = 155;
			this.butBorrarArticulosComponentes.Text = "&Borrar";
			this.butBorrarArticulosComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.butBorrarPagos.TabIndex = 163;
			this.butBorrarPagos.Text = "&Borrar";
			this.butBorrarPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.dgPagos.Size = new System.Drawing.Size(784, 180);
			this.dgPagos.TabIndex = 162;
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
			this.butImprimirFactura.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirFactura.Image")));
			this.butImprimirFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butImprimirFactura.Location = new System.Drawing.Point(8, 16);
			this.butImprimirFactura.Name = "butImprimirFactura";
			this.butImprimirFactura.Size = new System.Drawing.Size(120, 24);
			this.butImprimirFactura.TabIndex = 169;
			this.butImprimirFactura.Text = "&Imprimir Factura";
			// 
			// butSuspender
			// 
			this.butSuspender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSuspender.Image = ((System.Drawing.Image)(resources.GetObject("butSuspender.Image")));
			this.butSuspender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSuspender.Location = new System.Drawing.Point(136, 16);
			this.butSuspender.Name = "butSuspender";
			this.butSuspender.Size = new System.Drawing.Size(120, 24);
			this.butSuspender.TabIndex = 168;
			this.butSuspender.Text = "&Suspender";
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
			// 
			// butCrearRemitos
			// 
			this.butCrearRemitos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butCrearRemitos.Image = ((System.Drawing.Image)(resources.GetObject("butCrearRemitos.Image")));
			this.butCrearRemitos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCrearRemitos.Location = new System.Drawing.Point(8, 48);
			this.butCrearRemitos.Name = "butCrearRemitos";
			this.butCrearRemitos.Size = new System.Drawing.Size(120, 24);
			this.butCrearRemitos.TabIndex = 166;
			this.butCrearRemitos.Text = "&Crear Remito(s)";
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
			this.lblRegistro2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblInteresPorV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblTotalConInteresV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblInteresValV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblTotalFacturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblSaldoPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblTotalPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.cbAdicional.ItemHeight = 13;
			this.cbAdicional.Location = new System.Drawing.Point(176, 56);
			this.cbAdicional.Name = "cbAdicional";
			this.cbAdicional.Size = new System.Drawing.Size(160, 21);
			this.cbAdicional.TabIndex = 154;
			this.cbAdicional.Visible = false;
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
			this.butAgregarPago.Location = new System.Drawing.Point(568, 19);
			this.butAgregarPago.Name = "butAgregarPago";
			this.butAgregarPago.Size = new System.Drawing.Size(56, 40);
			this.butAgregarPago.TabIndex = 158;
			this.butAgregarPago.Text = "Agregar";
			this.butAgregarPago.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			this.cbTipoPagoDetalle.ItemHeight = 13;
			this.cbTipoPagoDetalle.Location = new System.Drawing.Point(176, 32);
			this.cbTipoPagoDetalle.Name = "cbTipoPagoDetalle";
			this.cbTipoPagoDetalle.Size = new System.Drawing.Size(160, 21);
			this.cbTipoPagoDetalle.TabIndex = 152;
			// 
			// cbTipoPago
			// 
			this.cbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTipoPago.ItemHeight = 13;
			this.cbTipoPago.Location = new System.Drawing.Point(8, 32);
			this.cbTipoPago.Name = "cbTipoPago";
			this.cbTipoPago.Size = new System.Drawing.Size(160, 21);
			this.cbTipoPago.TabIndex = 151;
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
			// 
			// cbCtadoCtaCte
			// 
			this.cbCtadoCtaCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCtadoCtaCte.ItemHeight = 13;
			this.cbCtadoCtaCte.Location = new System.Drawing.Point(8, 40);
			this.cbCtadoCtaCte.Name = "cbCtadoCtaCte";
			this.cbCtadoCtaCte.Size = new System.Drawing.Size(136, 21);
			this.cbCtadoCtaCte.TabIndex = 154;
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
			this.tbFormaPagoID.Text = "";
			this.tbFormaPagoID.Visible = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Purple;
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
			this.label18.BackColor = System.Drawing.Color.Purple;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(792, 32);
			this.label18.TabIndex = 95;
			this.label18.Text = "     Nota de Pedido Nº:";
			// 
			// tabPrincipal
			// 
			this.tabPrincipal.Controls.Add(this.tabPage1);
			this.tabPrincipal.Controls.Add(this.tabPage2);
			this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPrincipal.HotTrack = true;
			this.tabPrincipal.ItemSize = new System.Drawing.Size(94, 18);
			this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
			this.tabPrincipal.Name = "tabPrincipal";
			this.tabPrincipal.SelectedIndex = 0;
			this.tabPrincipal.Size = new System.Drawing.Size(800, 464);
			this.tabPrincipal.TabIndex = 2;
			// 
			// ucListadoVentasConDescuento
			// 
			this.Controls.Add(this.tabPrincipal);
			this.Name = "ucListadoVentasConDescuento";
			this.Size = new System.Drawing.Size(800, 464);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro1.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
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
			this.tabNotaPedido.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSubArticulos)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.gbPieItems.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgPagos)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			this.gbContado.ResumeLayout(false);
			this.tabPrincipal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
