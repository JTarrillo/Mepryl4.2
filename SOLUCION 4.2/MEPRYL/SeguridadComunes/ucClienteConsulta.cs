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
	/// Summary description for ucClienteConsulta.
	/// </summary>
	public class ucClienteConsulta : System.Windows.Forms.UserControl
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
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button butSalir2;
		private System.Windows.Forms.Button butLimpiar2;
		private System.Windows.Forms.Button butBuscar2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
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
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Button butSalir4;
		private System.Windows.Forms.Button butLimpiar4;
		private System.Windows.Forms.Button butBuscar4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.GroupBox gbFechaEmision;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.DateTimePicker dtpFechaNacimientoHastaB;
		private System.Windows.Forms.DateTimePicker dtpFechaNacimientoDesdeB;
		private System.Windows.Forms.CheckBox chkFechaNacimientoB;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox tbPalabrasClaveB;
		private System.Windows.Forms.TextBox tbNombresB;
		private System.Windows.Forms.TextBox tbApellidoB;
		private System.Windows.Forms.TextBox tbDniB;
		private System.Windows.Forms.TextBox tbCuitB;
		private System.Windows.Forms.ComboBox cbEmpresaB;
		private System.Windows.Forms.CheckBox chkParticularB;
		private System.Windows.Forms.CheckBox chkCorporativoB;
		private System.Windows.Forms.ComboBox cbEstadoB;
		private System.Windows.Forms.TextBox tbCalleB;
		private System.Windows.Forms.TextBox tbDeptoB;
		private System.Windows.Forms.TextBox tbPisoB;
		private System.Windows.Forms.TextBox tbNroB;
		private System.Windows.Forms.ComboBox cbLocalidadB;
		private System.Windows.Forms.ComboBox cbProvinciaB;
		private System.Windows.Forms.TextBox tbCodPostB;
		private System.Windows.Forms.ComboBox cbPaisB;
		private System.Windows.Forms.TextBox tbEmailB;
		private System.Windows.Forms.TextBox tbTelefonosB;
		private System.Windows.Forms.ComboBox cbCargoB;
		private System.Windows.Forms.ComboBox cbIVAB;
		private System.Windows.Forms.TextBox tbCalleEmpresaB;
		private System.Windows.Forms.TextBox tbOficinaEmpresaB;
		private System.Windows.Forms.TextBox tbPisoEmpresaB;
		private System.Windows.Forms.TextBox tbNroEmpresaB;
		private System.Windows.Forms.TextBox tbCodPostEmpresaB;
		private System.Windows.Forms.ComboBox cbProvinciaEmpresaB;
		private System.Windows.Forms.ComboBox cbLocalidadEmpresaB;
		private System.Windows.Forms.TextBox tbTelefonosEmpresaB;
		private System.Windows.Forms.TextBox tbEmailEmpresaB;
		private System.Windows.Forms.ComboBox cbPaisEmpresaB;
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox chkParticular;
		private System.Windows.Forms.CheckBox chkCorporativo;
		private System.Windows.Forms.ComboBox cbEstado;
		private System.Windows.Forms.TextBox tbComentarios;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox tbAjusteManual;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox tbPuntajeAutomatico;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox tbRanking;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.Button butLimpiarDatosPersonales;
		private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox tbNombres;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tbApellido;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbTelefonos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCodPost;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbPais;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbProvincia;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbLocalidad;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbDepto;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox tbPiso;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox tbNro;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox tbCalle;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox tbDni;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.ComboBox cbIVA;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Button butLimpiarDatosLaborales;
		private System.Windows.Forms.TextBox tbTelefonosEmpresa;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.TextBox tbEmailEmpresa;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.TextBox tbCodPostEmpresa;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.ComboBox cbPaisEmpresa;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.ComboBox cbProvinciaEmpresa;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.ComboBox cbLocalidadEmpresa;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.TextBox tbOficinaEmpresa;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.TextBox tbPisoEmpresa;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.TextBox tbNroEmpresa;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.TextBox tbCalleEmpresa;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.TextBox tbCuit;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.ComboBox cbCargo;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.ComboBox cbEmpresa;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Button butLimpiar;
		private System.ComponentModel.IContainer components;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = "";
		public Configuracion m_configuracion;
		public bool consultaRapida = false;


		private System.Windows.Forms.TextBox tbRankingHastaB;
		private System.Windows.Forms.TextBox tbRankingDesdeB;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn Ranking;
		private System.Windows.Forms.DataGridTextBoxColumn Apellido;
		private System.Windows.Forms.DataGridTextBoxColumn Nombres;
		private System.Windows.Forms.DataGridTextBoxColumn Empresa;
		private System.Windows.Forms.DataGridTextBoxColumn Cargo;
		private System.Windows.Forms.DataGridTextBoxColumn Telefonos;
		private System.Windows.Forms.DataGridTextBoxColumn EMail;
		private System.Windows.Forms.DataGridTextBoxColumn Calle;
		private System.Windows.Forms.DataGridTextBoxColumn Nro;
		private System.Windows.Forms.DataGridTextBoxColumn Piso;
		private System.Windows.Forms.DataGridTextBoxColumn Depto;
		private System.Windows.Forms.DataGridTextBoxColumn Localidad;
		private System.Windows.Forms.DataGridTextBoxColumn Provincia;
		private System.Windows.Forms.DataGridTextBoxColumn Pais;
		private System.Windows.Forms.DataGridTextBoxColumn CodPost;
		private System.Windows.Forms.DataGridTextBoxColumn Dni;
		private System.Windows.Forms.DataGridTextBoxColumn FNacimiento;
		private System.Windows.Forms.DataGridTextBoxColumn Estado;
		private System.Windows.Forms.DataGridTextBoxColumn PuntajeAutomatico;
		private System.Windows.Forms.DataGridTextBoxColumn AjusteManual;
		private System.Windows.Forms.DataGridTextBoxColumn IVA;
		private System.Windows.Forms.DataGridTextBoxColumn Particular;
		private System.Windows.Forms.DataGridTextBoxColumn Corporativo;
		private System.Windows.Forms.DataGridTextBoxColumn CalleEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn NroEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn PisoEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn OficinaEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn LocalidadEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn ProvinciaEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn PaisEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn CodPostEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn EMailEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn TelefonosEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn CUIT;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.GroupBox gbRegistro;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button butAceptar1; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";

		public ucClienteConsulta()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucClienteConsulta));
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butVistaPrevia = new System.Windows.Forms.Button();
            this.butImprimir = new System.Windows.Forms.Button();
            this.butBorrar = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.Empresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Ranking = new System.Windows.Forms.DataGridTextBoxColumn();
            this.EMailEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.TelefonosEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CUIT = new System.Windows.Forms.DataGridTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CalleEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.NroEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PisoEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.OficinaEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CodPostEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.LocalidadEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ProvinciaEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PaisEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Corporativo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Telefonos = new System.Windows.Forms.DataGridTextBoxColumn();
            this.EMail = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Nro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Depto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CodPost = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Provincia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Pais = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Dni = new System.Windows.Forms.DataGridTextBoxColumn();
            this.FNacimiento = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PuntajeAutomatico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.AjusteManual = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Particular = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPalabrasClaveB = new System.Windows.Forms.TextBox();
            this.butSalir4 = new System.Windows.Forms.Button();
            this.butLimpiar4 = new System.Windows.Forms.Button();
            this.butBuscar4 = new System.Windows.Forms.Button();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbRankingHastaB = new System.Windows.Forms.TextBox();
            this.tbRankingDesdeB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkParticularB = new System.Windows.Forms.CheckBox();
            this.chkCorporativoB = new System.Windows.Forms.CheckBox();
            this.cbEstadoB = new System.Windows.Forms.ComboBox();
            this.tbCuitB = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.cbEmpresaB = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tbNombresB = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tbApellidoB = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tbDniB = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.butSalir2 = new System.Windows.Forms.Button();
            this.butLimpiar2 = new System.Windows.Forms.Button();
            this.butBuscar2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tbTelefonosEmpresaB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbEmailEmpresaB = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbPaisEmpresaB = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.cbLocalidadEmpresaB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCodPostEmpresaB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbProvinciaEmpresaB = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.tbOficinaEmpresaB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPisoEmpresaB = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbNroEmpresaB = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.tbCalleEmpresaB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbIVAB = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbCargoB = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbTelefonosB = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbEmailB = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gbFechaEmision = new System.Windows.Forms.GroupBox();
            this.dtpFechaNacimientoHastaB = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaNacimientoDesdeB = new System.Windows.Forms.DateTimePicker();
            this.chkFechaNacimientoB = new System.Windows.Forms.CheckBox();
            this.cbPaisB = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbCodPostB = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.cbProvinciaB = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbLocalidadB = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDeptoB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPisoB = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.tbNroB = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tbCalleB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.gbRegistro = new System.Windows.Forms.GroupBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.butAnterior = new System.Windows.Forms.Button();
            this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkParticular = new System.Windows.Forms.CheckBox();
            this.chkCorporativo = new System.Windows.Forms.CheckBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.tbComentarios = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbAjusteManual = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbPuntajeAutomatico = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbRanking = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.cbIVA = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.butLimpiarDatosLaborales = new System.Windows.Forms.Button();
            this.tbTelefonosEmpresa = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.tbEmailEmpresa = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.tbCodPostEmpresa = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.cbPaisEmpresa = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.cbProvinciaEmpresa = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.cbLocalidadEmpresa = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.tbOficinaEmpresa = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.tbPisoEmpresa = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.tbNroEmpresa = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.tbCalleEmpresa = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.tbCuit = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.label62 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.butLimpiarDatosPersonales = new System.Windows.Forms.Button();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.tbNombres = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbTelefonos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCodPost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPais = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDepto = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbPiso = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbNro = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.butSalir = new System.Windows.Forms.Button();
            this.butGuardar = new System.Windows.Forms.Button();
            this.butLimpiar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gbFechaEmision.SuspendLayout();
            this.tabFiltro3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbRegistro.SuspendLayout();
            this.gbModificacionProveedores.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage7.SuspendLayout();
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
            this.tabPrincipal.Size = new System.Drawing.Size(824, 456);
            this.tabPrincipal.TabIndex = 5;
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
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 4;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(816, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista de Clientes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 160);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // butVistaPrevia
            // 
            this.butVistaPrevia.BackColor = System.Drawing.Color.SteelBlue;
            this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
            this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVistaPrevia.Location = new System.Drawing.Point(340, 164);
            this.butVistaPrevia.Name = "butVistaPrevia";
            this.butVistaPrevia.Size = new System.Drawing.Size(88, 24);
            this.butVistaPrevia.TabIndex = 4;
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
            this.butImprimir.Location = new System.Drawing.Point(266, 164);
            this.butImprimir.Name = "butImprimir";
            this.butImprimir.Size = new System.Drawing.Size(64, 24);
            this.butImprimir.TabIndex = 3;
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
            this.butBorrar.Location = new System.Drawing.Point(644, 164);
            this.butBorrar.Name = "butBorrar";
            this.butBorrar.Size = new System.Drawing.Size(64, 24);
            this.butBorrar.TabIndex = 5;
            this.butBorrar.Text = "&Borrar";
            this.butBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrar.UseVisualStyleBackColor = false;
            this.butBorrar.Click += new System.EventHandler(this.butBorrar_Click);
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
            this.dgItems.CaptionText = "     Lista de Clientes";
            this.dgItems.DataMember = "";
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgItems.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dgItems.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgItems.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.LinkColor = System.Drawing.Color.Teal;
            this.dgItems.Location = new System.Drawing.Point(0, 160);
            this.dgItems.Name = "dgItems";
            this.dgItems.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dgItems.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgItems.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.Size = new System.Drawing.Size(816, 270);
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
            this.Empresa,
            this.Ranking,
            this.EMailEmpresa,
            this.TelefonosEmpresa,
            this.CUIT,
            this.IVA,
            this.CalleEmpresa,
            this.NroEmpresa,
            this.PisoEmpresa,
            this.OficinaEmpresa,
            this.CodPostEmpresa,
            this.LocalidadEmpresa,
            this.ProvinciaEmpresa,
            this.PaisEmpresa,
            this.Corporativo,
            this.Cargo,
            this.Apellido,
            this.Nombres,
            this.Telefonos,
            this.EMail,
            this.Calle,
            this.Nro,
            this.Piso,
            this.Depto,
            this.CodPost,
            this.Localidad,
            this.Provincia,
            this.Pais,
            this.Dni,
            this.FNacimiento,
            this.PuntajeAutomatico,
            this.AjusteManual,
            this.Particular,
            this.Estado});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Items";
            // 
            // Empresa
            // 
            this.Empresa.Format = "";
            this.Empresa.FormatInfo = null;
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.MappingName = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Width = 150;
            // 
            // Ranking
            // 
            this.Ranking.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.Ranking.Format = "";
            this.Ranking.FormatInfo = null;
            this.Ranking.HeaderText = "Ranking";
            this.Ranking.MappingName = "Ranking";
            this.Ranking.ReadOnly = true;
            this.Ranking.Width = 30;
            // 
            // EMailEmpresa
            // 
            this.EMailEmpresa.Format = "";
            this.EMailEmpresa.FormatInfo = null;
            this.EMailEmpresa.HeaderText = "E-Mail (empresa)";
            this.EMailEmpresa.MappingName = "E-Mail (empresa)";
            this.EMailEmpresa.ReadOnly = true;
            this.EMailEmpresa.Width = 140;
            // 
            // TelefonosEmpresa
            // 
            this.TelefonosEmpresa.Format = "";
            this.TelefonosEmpresa.FormatInfo = null;
            this.TelefonosEmpresa.HeaderText = "Teléfonos (empresa)";
            this.TelefonosEmpresa.MappingName = "Teléfonos (empresa)";
            this.TelefonosEmpresa.ReadOnly = true;
            this.TelefonosEmpresa.Width = 75;
            // 
            // CUIT
            // 
            this.CUIT.Format = "";
            this.CUIT.FormatInfo = null;
            this.CUIT.HeaderText = "CUIT (empresa)";
            this.CUIT.MappingName = "CUIT (empresa)";
            this.CUIT.ReadOnly = true;
            this.CUIT.Width = 75;
            // 
            // IVA
            // 
            this.IVA.Format = "";
            this.IVA.FormatInfo = null;
            this.IVA.HeaderText = "IVA";
            this.IVA.MappingName = "IVA";
            this.IVA.ReadOnly = true;
            this.IVA.Width = 75;
            // 
            // CalleEmpresa
            // 
            this.CalleEmpresa.Format = "";
            this.CalleEmpresa.FormatInfo = null;
            this.CalleEmpresa.HeaderText = "Calle (empresa)";
            this.CalleEmpresa.MappingName = "Calle (empresa)";
            this.CalleEmpresa.ReadOnly = true;
            this.CalleEmpresa.Width = 75;
            // 
            // NroEmpresa
            // 
            this.NroEmpresa.Format = "";
            this.NroEmpresa.FormatInfo = null;
            this.NroEmpresa.HeaderText = "Nro. (empresa)";
            this.NroEmpresa.MappingName = "Nro. (empresa)";
            this.NroEmpresa.ReadOnly = true;
            this.NroEmpresa.Width = 30;
            // 
            // PisoEmpresa
            // 
            this.PisoEmpresa.Format = "";
            this.PisoEmpresa.FormatInfo = null;
            this.PisoEmpresa.HeaderText = "Piso (empresa)";
            this.PisoEmpresa.MappingName = "Piso (empresa)";
            this.PisoEmpresa.ReadOnly = true;
            this.PisoEmpresa.Width = 30;
            // 
            // OficinaEmpresa
            // 
            this.OficinaEmpresa.Format = "";
            this.OficinaEmpresa.FormatInfo = null;
            this.OficinaEmpresa.HeaderText = "Of. (empresa)";
            this.OficinaEmpresa.MappingName = "Of. (empresa)";
            this.OficinaEmpresa.ReadOnly = true;
            this.OficinaEmpresa.Width = 30;
            // 
            // CodPostEmpresa
            // 
            this.CodPostEmpresa.Format = "";
            this.CodPostEmpresa.FormatInfo = null;
            this.CodPostEmpresa.HeaderText = "Cod.Post. (empresa)";
            this.CodPostEmpresa.MappingName = "Cod. Post. (empresa)";
            this.CodPostEmpresa.ReadOnly = true;
            this.CodPostEmpresa.Width = 30;
            // 
            // LocalidadEmpresa
            // 
            this.LocalidadEmpresa.Format = "";
            this.LocalidadEmpresa.FormatInfo = null;
            this.LocalidadEmpresa.HeaderText = "Localidad (empresa)";
            this.LocalidadEmpresa.MappingName = "Localidad (empresa)";
            this.LocalidadEmpresa.ReadOnly = true;
            this.LocalidadEmpresa.Width = 75;
            // 
            // ProvinciaEmpresa
            // 
            this.ProvinciaEmpresa.Format = "";
            this.ProvinciaEmpresa.FormatInfo = null;
            this.ProvinciaEmpresa.HeaderText = "Provinicia (empresa)";
            this.ProvinciaEmpresa.MappingName = "Provincia (empresa)";
            this.ProvinciaEmpresa.ReadOnly = true;
            this.ProvinciaEmpresa.Width = 75;
            // 
            // PaisEmpresa
            // 
            this.PaisEmpresa.Format = "";
            this.PaisEmpresa.FormatInfo = null;
            this.PaisEmpresa.HeaderText = "País (empresa)";
            this.PaisEmpresa.MappingName = "País (empresa)";
            this.PaisEmpresa.ReadOnly = true;
            this.PaisEmpresa.Width = 50;
            // 
            // Corporativo
            // 
            this.Corporativo.Format = "";
            this.Corporativo.FormatInfo = null;
            this.Corporativo.HeaderText = "Corporativo";
            this.Corporativo.MappingName = "Corporativo";
            this.Corporativo.ReadOnly = true;
            this.Corporativo.Width = 30;
            // 
            // Cargo
            // 
            this.Cargo.Format = "";
            this.Cargo.FormatInfo = null;
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.MappingName = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Width = 75;
            // 
            // Apellido
            // 
            this.Apellido.Format = "";
            this.Apellido.FormatInfo = null;
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MappingName = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 75;
            // 
            // Nombres
            // 
            this.Nombres.Format = "";
            this.Nombres.FormatInfo = null;
            this.Nombres.HeaderText = "Nombres";
            this.Nombres.MappingName = "Nombres";
            this.Nombres.ReadOnly = true;
            this.Nombres.Width = 75;
            // 
            // Telefonos
            // 
            this.Telefonos.Format = "";
            this.Telefonos.FormatInfo = null;
            this.Telefonos.HeaderText = "Teléfonos (part.)";
            this.Telefonos.MappingName = "Teléfonos";
            this.Telefonos.ReadOnly = true;
            this.Telefonos.Width = 75;
            // 
            // EMail
            // 
            this.EMail.Format = "";
            this.EMail.FormatInfo = null;
            this.EMail.HeaderText = "E-Mail (part.)";
            this.EMail.MappingName = "E-Mail";
            this.EMail.ReadOnly = true;
            this.EMail.Width = 140;
            // 
            // Calle
            // 
            this.Calle.Format = "";
            this.Calle.FormatInfo = null;
            this.Calle.HeaderText = "Calle (part.)";
            this.Calle.MappingName = "Calle";
            this.Calle.ReadOnly = true;
            this.Calle.Width = 75;
            // 
            // Nro
            // 
            this.Nro.Format = "";
            this.Nro.FormatInfo = null;
            this.Nro.HeaderText = "Nro. (part.)";
            this.Nro.MappingName = "Nro.";
            this.Nro.ReadOnly = true;
            this.Nro.Width = 30;
            // 
            // Piso
            // 
            this.Piso.Format = "";
            this.Piso.FormatInfo = null;
            this.Piso.HeaderText = "Piso (part.)";
            this.Piso.MappingName = "Piso";
            this.Piso.ReadOnly = true;
            this.Piso.Width = 30;
            // 
            // Depto
            // 
            this.Depto.Format = "";
            this.Depto.FormatInfo = null;
            this.Depto.HeaderText = "Depto. (part.)";
            this.Depto.MappingName = "Depto.";
            this.Depto.ReadOnly = true;
            this.Depto.Width = 30;
            // 
            // CodPost
            // 
            this.CodPost.Format = "";
            this.CodPost.FormatInfo = null;
            this.CodPost.HeaderText = "Cod.Post.";
            this.CodPost.MappingName = "Cod.Post.";
            this.CodPost.ReadOnly = true;
            this.CodPost.Width = 30;
            // 
            // Localidad
            // 
            this.Localidad.Format = "";
            this.Localidad.FormatInfo = null;
            this.Localidad.HeaderText = "Localidad (part.)";
            this.Localidad.MappingName = "Localidad";
            this.Localidad.ReadOnly = true;
            this.Localidad.Width = 75;
            // 
            // Provincia
            // 
            this.Provincia.Format = "";
            this.Provincia.FormatInfo = null;
            this.Provincia.HeaderText = "Provincia (part.)";
            this.Provincia.MappingName = "Provincia";
            this.Provincia.ReadOnly = true;
            this.Provincia.Width = 75;
            // 
            // Pais
            // 
            this.Pais.Format = "";
            this.Pais.FormatInfo = null;
            this.Pais.HeaderText = "País (part.)";
            this.Pais.MappingName = "País";
            this.Pais.ReadOnly = true;
            this.Pais.Width = 50;
            // 
            // Dni
            // 
            this.Dni.Format = "";
            this.Dni.FormatInfo = null;
            this.Dni.HeaderText = "DNI";
            this.Dni.MappingName = "DNI";
            this.Dni.ReadOnly = true;
            this.Dni.Width = 75;
            // 
            // FNacimiento
            // 
            this.FNacimiento.Format = "";
            this.FNacimiento.FormatInfo = null;
            this.FNacimiento.HeaderText = "F.Nacimiento";
            this.FNacimiento.MappingName = "F.Nacimiento";
            this.FNacimiento.ReadOnly = true;
            this.FNacimiento.Width = 75;
            // 
            // PuntajeAutomatico
            // 
            this.PuntajeAutomatico.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.PuntajeAutomatico.Format = "";
            this.PuntajeAutomatico.FormatInfo = null;
            this.PuntajeAutomatico.HeaderText = "Ptje.Aut.";
            this.PuntajeAutomatico.MappingName = "Ptje.Aut.";
            this.PuntajeAutomatico.ReadOnly = true;
            this.PuntajeAutomatico.Width = 30;
            // 
            // AjusteManual
            // 
            this.AjusteManual.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.AjusteManual.Format = "";
            this.AjusteManual.FormatInfo = null;
            this.AjusteManual.HeaderText = "Ajt.Manual";
            this.AjusteManual.MappingName = "Ajt.Manual";
            this.AjusteManual.ReadOnly = true;
            this.AjusteManual.Width = 30;
            // 
            // Particular
            // 
            this.Particular.Format = "";
            this.Particular.FormatInfo = null;
            this.Particular.HeaderText = "Particular";
            this.Particular.MappingName = "Particular";
            this.Particular.ReadOnly = true;
            this.Particular.Width = 30;
            // 
            // Estado
            // 
            this.Estado.Format = "";
            this.Estado.FormatInfo = null;
            this.Estado.HeaderText = "Estado";
            this.Estado.MappingName = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 75;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabPage6);
            this.tabFiltro.Controls.Add(this.tabFiltro1);
            this.tabFiltro.Controls.Add(this.tabPage3);
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
            this.tabFiltro.Size = new System.Drawing.Size(816, 160);
            this.tabFiltro.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.butAceptar1);
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Controls.Add(this.butSalir4);
            this.tabPage6.Controls.Add(this.butLimpiar4);
            this.tabPage6.Controls.Add(this.butBuscar4);
            this.tabPage6.ImageIndex = 0;
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(808, 134);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Búsqueda de Texto";
            // 
            // butAceptar1
            // 
            this.butAceptar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar1.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar1.Image")));
            this.butAceptar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar1.Location = new System.Drawing.Point(632, 96);
            this.butAceptar1.Name = "butAceptar1";
            this.butAceptar1.Size = new System.Drawing.Size(72, 24);
            this.butAceptar1.TabIndex = 13;
            this.butAceptar1.Text = "&Aceptar";
            this.butAceptar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar1.Visible = false;
            this.butAceptar1.Click += new System.EventHandler(this.butAceptar1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPalabrasClaveB);
            this.groupBox3.Location = new System.Drawing.Point(112, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(408, 48);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Palabras clave";
            // 
            // tbPalabrasClaveB
            // 
            this.tbPalabrasClaveB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPalabrasClaveB.Location = new System.Drawing.Point(8, 16);
            this.tbPalabrasClaveB.Name = "tbPalabrasClaveB";
            this.tbPalabrasClaveB.Size = new System.Drawing.Size(392, 20);
            this.tbPalabrasClaveB.TabIndex = 1;
            this.tbPalabrasClaveB.TextChanged += new System.EventHandler(this.tbPalabrasClaveB_TextChanged);
            this.tbPalabrasClaveB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPalabrasClaveB_KeyDown);
            // 
            // butSalir4
            // 
            this.butSalir4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir4.Image = ((System.Drawing.Image)(resources.GetObject("butSalir4.Image")));
            this.butSalir4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir4.Location = new System.Drawing.Point(640, 88);
            this.butSalir4.Name = "butSalir4";
            this.butSalir4.Size = new System.Drawing.Size(64, 23);
            this.butSalir4.TabIndex = 8;
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
            this.butLimpiar4.TabIndex = 7;
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
            this.butBuscar4.TabIndex = 6;
            this.butBuscar4.Text = "&Buscar";
            this.butBuscar4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar4.Click += new System.EventHandler(this.butBuscar4_Click);
            // 
            // tabFiltro1
            // 
            this.tabFiltro1.Controls.Add(this.groupBox2);
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.Controls.Add(this.tbCuitB);
            this.tabFiltro1.Controls.Add(this.label41);
            this.tabFiltro1.Controls.Add(this.cbEmpresaB);
            this.tabFiltro1.Controls.Add(this.label42);
            this.tabFiltro1.Controls.Add(this.tbNombresB);
            this.tabFiltro1.Controls.Add(this.label38);
            this.tabFiltro1.Controls.Add(this.tbApellidoB);
            this.tabFiltro1.Controls.Add(this.label39);
            this.tabFiltro1.Controls.Add(this.tbDniB);
            this.tabFiltro1.Controls.Add(this.label40);
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.ImageIndex = 1;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(808, 134);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbRankingHastaB);
            this.groupBox2.Controls.Add(this.tbRankingDesdeB);
            this.groupBox2.Location = new System.Drawing.Point(296, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 48);
            this.groupBox2.TabIndex = 226;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ranking";
            // 
            // tbRankingHastaB
            // 
            this.tbRankingHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRankingHastaB.Location = new System.Drawing.Point(72, 16);
            this.tbRankingHastaB.Name = "tbRankingHastaB";
            this.tbRankingHastaB.Size = new System.Drawing.Size(56, 20);
            this.tbRankingHastaB.TabIndex = 1;
            this.tbRankingHastaB.Validated += new System.EventHandler(this.tbRankingHastaB_Validated);
            this.tbRankingHastaB.Validating += new System.ComponentModel.CancelEventHandler(this.tbRankingHastaB_Validating);
            // 
            // tbRankingDesdeB
            // 
            this.tbRankingDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRankingDesdeB.Location = new System.Drawing.Point(8, 16);
            this.tbRankingDesdeB.Name = "tbRankingDesdeB";
            this.tbRankingDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbRankingDesdeB.TabIndex = 0;
            this.tbRankingDesdeB.Validated += new System.EventHandler(this.tbRankingDesdeB_Validated);
            this.tbRankingDesdeB.Validating += new System.ComponentModel.CancelEventHandler(this.tbRankingDesdeB_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkParticularB);
            this.groupBox1.Controls.Add(this.chkCorporativoB);
            this.groupBox1.Controls.Add(this.cbEstadoB);
            this.groupBox1.Location = new System.Drawing.Point(448, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 96);
            this.groupBox1.TabIndex = 225;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Cliente";
            // 
            // chkParticularB
            // 
            this.chkParticularB.Location = new System.Drawing.Point(8, 64);
            this.chkParticularB.Name = "chkParticularB";
            this.chkParticularB.Size = new System.Drawing.Size(104, 24);
            this.chkParticularB.TabIndex = 20;
            this.chkParticularB.Text = "Particular";
            // 
            // chkCorporativoB
            // 
            this.chkCorporativoB.Location = new System.Drawing.Point(8, 40);
            this.chkCorporativoB.Name = "chkCorporativoB";
            this.chkCorporativoB.Size = new System.Drawing.Size(104, 24);
            this.chkCorporativoB.TabIndex = 19;
            this.chkCorporativoB.Text = "Corporativo";
            // 
            // cbEstadoB
            // 
            this.cbEstadoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstadoB.Items.AddRange(new object[] {
            "Activo",
            "Potencial"});
            this.cbEstadoB.Location = new System.Drawing.Point(8, 16);
            this.cbEstadoB.MaxLength = 100;
            this.cbEstadoB.Name = "cbEstadoB";
            this.cbEstadoB.Size = new System.Drawing.Size(120, 21);
            this.cbEstadoB.TabIndex = 18;
            // 
            // tbCuitB
            // 
            this.tbCuitB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCuitB.Location = new System.Drawing.Point(152, 80);
            this.tbCuitB.Name = "tbCuitB";
            this.tbCuitB.Size = new System.Drawing.Size(136, 20);
            this.tbCuitB.TabIndex = 222;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(152, 64);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 14);
            this.label41.TabIndex = 224;
            this.label41.Text = "CUIT";
            // 
            // cbEmpresaB
            // 
            this.cbEmpresaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresaB.Location = new System.Drawing.Point(8, 80);
            this.cbEmpresaB.MaxLength = 100;
            this.cbEmpresaB.Name = "cbEmpresaB";
            this.cbEmpresaB.Size = new System.Drawing.Size(136, 21);
            this.cbEmpresaB.TabIndex = 221;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(8, 64);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(128, 14);
            this.label42.TabIndex = 223;
            this.label42.Text = "Empresa";
            // 
            // tbNombresB
            // 
            this.tbNombresB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombresB.Location = new System.Drawing.Point(152, 32);
            this.tbNombresB.Name = "tbNombresB";
            this.tbNombresB.Size = new System.Drawing.Size(136, 20);
            this.tbNombresB.TabIndex = 216;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(152, 16);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(72, 14);
            this.label38.TabIndex = 220;
            this.label38.Text = "Nombres";
            // 
            // tbApellidoB
            // 
            this.tbApellidoB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApellidoB.Location = new System.Drawing.Point(8, 32);
            this.tbApellidoB.Name = "tbApellidoB";
            this.tbApellidoB.Size = new System.Drawing.Size(136, 20);
            this.tbApellidoB.TabIndex = 215;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(8, 16);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(72, 14);
            this.label39.TabIndex = 219;
            this.label39.Text = "Apellido";
            // 
            // tbDniB
            // 
            this.tbDniB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDniB.Location = new System.Drawing.Point(296, 32);
            this.tbDniB.Name = "tbDniB";
            this.tbDniB.Size = new System.Drawing.Size(136, 20);
            this.tbDniB.TabIndex = 217;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(296, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(40, 14);
            this.label40.TabIndex = 218;
            this.label40.Text = "DNI";
            // 
            // butSalir1
            // 
            this.butSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir1.Image = ((System.Drawing.Image)(resources.GetObject("butSalir1.Image")));
            this.butSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir1.Location = new System.Drawing.Point(640, 88);
            this.butSalir1.Name = "butSalir1";
            this.butSalir1.Size = new System.Drawing.Size(64, 23);
            this.butSalir1.TabIndex = 5;
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
            this.butLimpiar1.TabIndex = 4;
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
            this.butBuscar1.TabIndex = 3;
            this.butBuscar1.Text = "&Buscar";
            this.butBuscar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar1.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.butSalir2);
            this.tabPage3.Controls.Add(this.butLimpiar2);
            this.tabPage3.Controls.Add(this.butBuscar2);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(808, 134);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Filtro Avanzado";
            this.tabPage3.Visible = false;
            // 
            // butSalir2
            // 
            this.butSalir2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir2.Image = ((System.Drawing.Image)(resources.GetObject("butSalir2.Image")));
            this.butSalir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir2.Location = new System.Drawing.Point(728, 88);
            this.butSalir2.Name = "butSalir2";
            this.butSalir2.Size = new System.Drawing.Size(64, 23);
            this.butSalir2.TabIndex = 19;
            this.butSalir2.Text = "&Salir";
            this.butSalir2.Click += new System.EventHandler(this.butSalir2_Click);
            // 
            // butLimpiar2
            // 
            this.butLimpiar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar2.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar2.Image")));
            this.butLimpiar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar2.Location = new System.Drawing.Point(728, 64);
            this.butLimpiar2.Name = "butLimpiar2";
            this.butLimpiar2.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar2.TabIndex = 18;
            this.butLimpiar2.Text = "&Limpiar";
            this.butLimpiar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar2.Click += new System.EventHandler(this.butLimpiar2_Click);
            // 
            // butBuscar2
            // 
            this.butBuscar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar2.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar2.Image")));
            this.butBuscar2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar2.Location = new System.Drawing.Point(728, 16);
            this.butBuscar2.Name = "butBuscar2";
            this.butBuscar2.Size = new System.Drawing.Size(64, 41);
            this.butBuscar2.TabIndex = 17;
            this.butBuscar2.Text = "&Buscar";
            this.butBuscar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar2.Click += new System.EventHandler(this.butBuscar2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImageList = this.imagenesTab;
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 128);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tbTelefonosEmpresaB);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.tbEmailEmpresaB);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.cbPaisEmpresaB);
            this.tabPage5.Controls.Add(this.label48);
            this.tabPage5.Controls.Add(this.cbLocalidadEmpresaB);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.tbCodPostEmpresaB);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.cbProvinciaEmpresaB);
            this.tabPage5.Controls.Add(this.label47);
            this.tabPage5.Controls.Add(this.tbOficinaEmpresaB);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.tbPisoEmpresaB);
            this.tabPage5.Controls.Add(this.label24);
            this.tabPage5.Controls.Add(this.tbNroEmpresaB);
            this.tabPage5.Controls.Add(this.label46);
            this.tabPage5.Controls.Add(this.tbCalleEmpresaB);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.cbIVAB);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.cbCargoB);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.ImageIndex = 7;
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(712, 102);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Datos Empresa";
            this.tabPage5.Visible = false;
            // 
            // tbTelefonosEmpresaB
            // 
            this.tbTelefonosEmpresaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefonosEmpresaB.Location = new System.Drawing.Point(552, 64);
            this.tbTelefonosEmpresaB.Name = "tbTelefonosEmpresaB";
            this.tbTelefonosEmpresaB.Size = new System.Drawing.Size(136, 20);
            this.tbTelefonosEmpresaB.TabIndex = 222;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(552, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 14);
            this.label15.TabIndex = 223;
            this.label15.Text = "Teléfonos";
            // 
            // tbEmailEmpresaB
            // 
            this.tbEmailEmpresaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmailEmpresaB.Location = new System.Drawing.Point(408, 64);
            this.tbEmailEmpresaB.Name = "tbEmailEmpresaB";
            this.tbEmailEmpresaB.Size = new System.Drawing.Size(136, 20);
            this.tbEmailEmpresaB.TabIndex = 220;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(408, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 14);
            this.label16.TabIndex = 221;
            this.label16.Text = "E-Mail";
            // 
            // cbPaisEmpresaB
            // 
            this.cbPaisEmpresaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaisEmpresaB.Location = new System.Drawing.Point(272, 64);
            this.cbPaisEmpresaB.MaxLength = 11;
            this.cbPaisEmpresaB.Name = "cbPaisEmpresaB";
            this.cbPaisEmpresaB.Size = new System.Drawing.Size(128, 21);
            this.cbPaisEmpresaB.TabIndex = 218;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(272, 48);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(32, 14);
            this.label48.TabIndex = 219;
            this.label48.Text = "Pais";
            // 
            // cbLocalidadEmpresaB
            // 
            this.cbLocalidadEmpresaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalidadEmpresaB.Location = new System.Drawing.Point(552, 16);
            this.cbLocalidadEmpresaB.MaxLength = 100;
            this.cbLocalidadEmpresaB.Name = "cbLocalidadEmpresaB";
            this.cbLocalidadEmpresaB.Size = new System.Drawing.Size(136, 21);
            this.cbLocalidadEmpresaB.TabIndex = 215;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(552, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 14);
            this.label4.TabIndex = 216;
            this.label4.Text = "Localidad";
            // 
            // tbCodPostEmpresaB
            // 
            this.tbCodPostEmpresaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodPostEmpresaB.Location = new System.Drawing.Point(16, 64);
            this.tbCodPostEmpresaB.Name = "tbCodPostEmpresaB";
            this.tbCodPostEmpresaB.Size = new System.Drawing.Size(48, 20);
            this.tbCodPostEmpresaB.TabIndex = 213;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 14);
            this.label7.TabIndex = 214;
            this.label7.Text = "Cod.Post.";
            // 
            // cbProvinciaEmpresaB
            // 
            this.cbProvinciaEmpresaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvinciaEmpresaB.Location = new System.Drawing.Point(80, 64);
            this.cbProvinciaEmpresaB.MaxLength = 100;
            this.cbProvinciaEmpresaB.Name = "cbProvinciaEmpresaB";
            this.cbProvinciaEmpresaB.Size = new System.Drawing.Size(136, 21);
            this.cbProvinciaEmpresaB.TabIndex = 211;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(80, 48);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(96, 14);
            this.label47.TabIndex = 212;
            this.label47.Text = "Provincia";
            // 
            // tbOficinaEmpresaB
            // 
            this.tbOficinaEmpresaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOficinaEmpresaB.Location = new System.Drawing.Point(504, 16);
            this.tbOficinaEmpresaB.Name = "tbOficinaEmpresaB";
            this.tbOficinaEmpresaB.Size = new System.Drawing.Size(40, 20);
            this.tbOficinaEmpresaB.TabIndex = 207;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(504, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 14);
            this.label9.TabIndex = 210;
            this.label9.Text = "Oficina";
            // 
            // tbPisoEmpresaB
            // 
            this.tbPisoEmpresaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPisoEmpresaB.Location = new System.Drawing.Point(456, 16);
            this.tbPisoEmpresaB.Name = "tbPisoEmpresaB";
            this.tbPisoEmpresaB.Size = new System.Drawing.Size(40, 20);
            this.tbPisoEmpresaB.TabIndex = 206;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(456, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 14);
            this.label24.TabIndex = 209;
            this.label24.Text = "Piso";
            // 
            // tbNroEmpresaB
            // 
            this.tbNroEmpresaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroEmpresaB.Location = new System.Drawing.Point(408, 16);
            this.tbNroEmpresaB.Name = "tbNroEmpresaB";
            this.tbNroEmpresaB.Size = new System.Drawing.Size(40, 20);
            this.tbNroEmpresaB.TabIndex = 205;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(408, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(48, 14);
            this.label46.TabIndex = 208;
            this.label46.Text = "Nro.";
            // 
            // tbCalleEmpresaB
            // 
            this.tbCalleEmpresaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCalleEmpresaB.Location = new System.Drawing.Point(272, 16);
            this.tbCalleEmpresaB.Name = "tbCalleEmpresaB";
            this.tbCalleEmpresaB.Size = new System.Drawing.Size(128, 20);
            this.tbCalleEmpresaB.TabIndex = 203;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(272, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 14);
            this.label3.TabIndex = 204;
            this.label3.Text = "Calle";
            // 
            // cbIVAB
            // 
            this.cbIVAB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIVAB.Location = new System.Drawing.Point(160, 16);
            this.cbIVAB.MaxLength = 100;
            this.cbIVAB.Name = "cbIVAB";
            this.cbIVAB.Size = new System.Drawing.Size(104, 21);
            this.cbIVAB.TabIndex = 201;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(160, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 14);
            this.label19.TabIndex = 202;
            this.label19.Text = "IVA";
            // 
            // cbCargoB
            // 
            this.cbCargoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargoB.Location = new System.Drawing.Point(16, 16);
            this.cbCargoB.MaxLength = 100;
            this.cbCargoB.Name = "cbCargoB";
            this.cbCargoB.Size = new System.Drawing.Size(136, 21);
            this.cbCargoB.TabIndex = 199;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(16, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 14);
            this.label17.TabIndex = 200;
            this.label17.Text = "Cargo";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbTelefonosB);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.tbEmailB);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.gbFechaEmision);
            this.tabPage4.Controls.Add(this.cbPaisB);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.tbCodPostB);
            this.tabPage4.Controls.Add(this.label45);
            this.tabPage4.Controls.Add(this.cbProvinciaB);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.cbLocalidadB);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.tbDeptoB);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.tbPisoB);
            this.tabPage4.Controls.Add(this.label43);
            this.tabPage4.Controls.Add(this.tbNroB);
            this.tabPage4.Controls.Add(this.label44);
            this.tabPage4.Controls.Add(this.tbCalleB);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.ImageIndex = 6;
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(712, 102);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Datos Peronsales";
            // 
            // tbTelefonosB
            // 
            this.tbTelefonosB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefonosB.Location = new System.Drawing.Point(320, 64);
            this.tbTelefonosB.Name = "tbTelefonosB";
            this.tbTelefonosB.Size = new System.Drawing.Size(136, 20);
            this.tbTelefonosB.TabIndex = 216;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(320, 48);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 14);
            this.label23.TabIndex = 217;
            this.label23.Text = "Teléfonos";
            // 
            // tbEmailB
            // 
            this.tbEmailB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmailB.Location = new System.Drawing.Point(168, 64);
            this.tbEmailB.Name = "tbEmailB";
            this.tbEmailB.Size = new System.Drawing.Size(136, 20);
            this.tbEmailB.TabIndex = 214;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(168, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 14);
            this.label21.TabIndex = 215;
            this.label21.Text = "E-Mail";
            // 
            // gbFechaEmision
            // 
            this.gbFechaEmision.Controls.Add(this.dtpFechaNacimientoHastaB);
            this.gbFechaEmision.Controls.Add(this.dtpFechaNacimientoDesdeB);
            this.gbFechaEmision.Controls.Add(this.chkFechaNacimientoB);
            this.gbFechaEmision.Location = new System.Drawing.Point(472, 48);
            this.gbFechaEmision.Name = "gbFechaEmision";
            this.gbFechaEmision.Size = new System.Drawing.Size(200, 48);
            this.gbFechaEmision.TabIndex = 213;
            this.gbFechaEmision.TabStop = false;
            // 
            // dtpFechaNacimientoHastaB
            // 
            this.dtpFechaNacimientoHastaB.Enabled = false;
            this.dtpFechaNacimientoHastaB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimientoHastaB.Location = new System.Drawing.Point(104, 16);
            this.dtpFechaNacimientoHastaB.Name = "dtpFechaNacimientoHastaB";
            this.dtpFechaNacimientoHastaB.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaNacimientoHastaB.TabIndex = 8;
            this.dtpFechaNacimientoHastaB.ValueChanged += new System.EventHandler(this.dtpFechaNacimientoHastaB_ValueChanged);
            // 
            // dtpFechaNacimientoDesdeB
            // 
            this.dtpFechaNacimientoDesdeB.Enabled = false;
            this.dtpFechaNacimientoDesdeB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimientoDesdeB.Location = new System.Drawing.Point(8, 16);
            this.dtpFechaNacimientoDesdeB.Name = "dtpFechaNacimientoDesdeB";
            this.dtpFechaNacimientoDesdeB.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaNacimientoDesdeB.TabIndex = 7;
            this.dtpFechaNacimientoDesdeB.ValueChanged += new System.EventHandler(this.dtbFechaNacimientoDesdeB_ValueChanged);
            // 
            // chkFechaNacimientoB
            // 
            this.chkFechaNacimientoB.Location = new System.Drawing.Point(8, 0);
            this.chkFechaNacimientoB.Name = "chkFechaNacimientoB";
            this.chkFechaNacimientoB.Size = new System.Drawing.Size(136, 16);
            this.chkFechaNacimientoB.TabIndex = 4;
            this.chkFechaNacimientoB.Text = "Fecha de Nacimiento";
            this.chkFechaNacimientoB.CheckedChanged += new System.EventHandler(this.chkFechaNacimientoB_CheckedChanged);
            // 
            // cbPaisB
            // 
            this.cbPaisB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaisB.Location = new System.Drawing.Point(16, 64);
            this.cbPaisB.MaxLength = 11;
            this.cbPaisB.Name = "cbPaisB";
            this.cbPaisB.Size = new System.Drawing.Size(136, 21);
            this.cbPaisB.TabIndex = 211;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(16, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 14);
            this.label20.TabIndex = 212;
            this.label20.Text = "Pais";
            // 
            // tbCodPostB
            // 
            this.tbCodPostB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodPostB.Location = new System.Drawing.Point(472, 16);
            this.tbCodPostB.Name = "tbCodPostB";
            this.tbCodPostB.Size = new System.Drawing.Size(48, 20);
            this.tbCodPostB.TabIndex = 209;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(472, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 14);
            this.label45.TabIndex = 210;
            this.label45.Text = "Cod.Post.";
            // 
            // cbProvinciaB
            // 
            this.cbProvinciaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvinciaB.Location = new System.Drawing.Point(536, 16);
            this.cbProvinciaB.MaxLength = 100;
            this.cbProvinciaB.Name = "cbProvinciaB";
            this.cbProvinciaB.Size = new System.Drawing.Size(136, 21);
            this.cbProvinciaB.TabIndex = 207;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(536, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 14);
            this.label13.TabIndex = 208;
            this.label13.Text = "Provincia";
            // 
            // cbLocalidadB
            // 
            this.cbLocalidadB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalidadB.Location = new System.Drawing.Point(320, 16);
            this.cbLocalidadB.MaxLength = 100;
            this.cbLocalidadB.Name = "cbLocalidadB";
            this.cbLocalidadB.Size = new System.Drawing.Size(136, 21);
            this.cbLocalidadB.TabIndex = 205;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(320, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 14);
            this.label12.TabIndex = 206;
            this.label12.Text = "Localidad";
            // 
            // tbDeptoB
            // 
            this.tbDeptoB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDeptoB.Location = new System.Drawing.Point(264, 16);
            this.tbDeptoB.Name = "tbDeptoB";
            this.tbDeptoB.Size = new System.Drawing.Size(40, 20);
            this.tbDeptoB.TabIndex = 201;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(264, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 14);
            this.label11.TabIndex = 204;
            this.label11.Text = "Depto.";
            // 
            // tbPisoB
            // 
            this.tbPisoB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPisoB.Location = new System.Drawing.Point(216, 16);
            this.tbPisoB.Name = "tbPisoB";
            this.tbPisoB.Size = new System.Drawing.Size(40, 20);
            this.tbPisoB.TabIndex = 200;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(216, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(32, 14);
            this.label43.TabIndex = 203;
            this.label43.Text = "Piso";
            // 
            // tbNroB
            // 
            this.tbNroB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroB.Location = new System.Drawing.Point(168, 16);
            this.tbNroB.Name = "tbNroB";
            this.tbNroB.Size = new System.Drawing.Size(40, 20);
            this.tbNroB.TabIndex = 199;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(168, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 14);
            this.label44.TabIndex = 202;
            this.label44.Text = "Nro.";
            // 
            // tbCalleB
            // 
            this.tbCalleB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCalleB.Location = new System.Drawing.Point(16, 16);
            this.tbCalleB.Name = "tbCalleB";
            this.tbCalleB.Size = new System.Drawing.Size(136, 20);
            this.tbCalleB.TabIndex = 193;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 14);
            this.label10.TabIndex = 194;
            this.label10.Text = "Calle";
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
            this.tabFiltro3.Size = new System.Drawing.Size(808, 134);
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
            "Ajt.Manual",
            "Apellido",
            "Calle",
            "Calle (empresa)",
            "Cargo",
            "Cod.Post.",
            "Cod.Post. (empresa)",
            "Corporativo",
            "Depto.",
            "DNI",
            "E-Mail",
            "E-Mail (empresa)",
            "Empresa",
            "Estado",
            "F.Nacimiento",
            "IVA",
            "Localidad",
            "Localidad (empresa)",
            "Nombres",
            "Nro.",
            "Nro. (empresa)",
            "Of. (empresa)",
            "País",
            "País (empresa)",
            "Particular",
            "Piso",
            "Piso (empresa)",
            "Provincia",
            "Provincia (empresa)",
            "Ptje.Aut.",
            "Ranking",
            "Teléfonos",
            "Teléfonos (empresa)"});
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
            "Ajt.Manual",
            "Apellido",
            "Calle",
            "Calle (empresa)",
            "Cargo",
            "Cod.Post.",
            "Cod.Post. (empresa)",
            "Corporativo",
            "Depto.",
            "DNI",
            "E-Mail",
            "E-Mail (empresa)",
            "Empresa",
            "Estado",
            "F.Nacimiento",
            "IVA",
            "Localidad",
            "Localidad (empresa)",
            "Nombres",
            "Nro.",
            "Nro. (empresa)",
            "Of. (empresa)",
            "País",
            "País (empresa)",
            "Particular",
            "Piso",
            "Piso (empresa)",
            "Provincia",
            "Provincia (empresa)",
            "Ptje.Aut.",
            "Ranking",
            "Teléfonos",
            "Teléfonos (empresa)"});
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
            "Ajt.Manual",
            "Apellido",
            "Calle",
            "Calle (empresa)",
            "Cargo",
            "Cod.Post.",
            "Cod.Post. (empresa)",
            "Corporativo",
            "Depto.",
            "DNI",
            "E-Mail",
            "E-Mail (empresa)",
            "Empresa",
            "Estado",
            "F.Nacimiento",
            "IVA",
            "Localidad",
            "Localidad (empresa)",
            "Nombres",
            "Nro.",
            "Nro. (empresa)",
            "Of. (empresa)",
            "País",
            "País (empresa)",
            "Particular",
            "Piso",
            "Piso (empresa)",
            "Provincia",
            "Provincia (empresa)",
            "Ptje.Aut.",
            "Ranking",
            "Teléfonos",
            "Teléfonos (empresa)"});
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
            "Ajt.Manual",
            "Apellido",
            "Calle",
            "Calle (empresa)",
            "Cargo",
            "Cod.Post.",
            "Cod.Post. (empresa)",
            "Corporativo",
            "Depto.",
            "DNI",
            "E-Mail",
            "E-Mail (empresa)",
            "Empresa",
            "Estado",
            "F.Nacimiento",
            "IVA",
            "Localidad",
            "Localidad (empresa)",
            "Nombres",
            "Nro.",
            "Nro. (empresa)",
            "Of. (empresa)",
            "País",
            "País (empresa)",
            "Particular",
            "Piso",
            "Piso (empresa)",
            "Provincia",
            "Provincia (empresa)",
            "Ptje.Aut.",
            "Ranking",
            "Teléfonos",
            "Teléfonos (empresa)"});
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
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.tbID);
            this.tabPage2.Controls.Add(this.gbRegistro);
            this.tabPage2.Controls.Add(this.gbModificacionProveedores);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.ImageIndex = 5;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(816, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 117;
            this.pictureBox2.TabStop = false;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(432, 512);
            this.tbID.MaxLength = 2;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(40, 20);
            this.tbID.TabIndex = 116;
            this.tbID.Visible = false;
            // 
            // gbRegistro
            // 
            this.gbRegistro.Controls.Add(this.lblRegistro);
            this.gbRegistro.Controls.Add(this.butSiguiente);
            this.gbRegistro.Controls.Add(this.butAnterior);
            this.gbRegistro.Location = new System.Drawing.Point(576, 32);
            this.gbRegistro.Name = "gbRegistro";
            this.gbRegistro.Size = new System.Drawing.Size(232, 48);
            this.gbRegistro.TabIndex = 102;
            this.gbRegistro.TabStop = false;
            this.gbRegistro.Text = "Registro";
            // 
            // lblRegistro
            // 
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(64, 24);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(104, 14);
            this.lblRegistro.TabIndex = 102;
            this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butSiguiente
            // 
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Location = new System.Drawing.Point(176, 16);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(48, 24);
            this.butSiguiente.TabIndex = 15;
            this.butSiguiente.Text = "Sig.";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
            // 
            // butAnterior
            // 
            this.butAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAnterior.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior.Image")));
            this.butAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAnterior.Location = new System.Drawing.Point(8, 16);
            this.butAnterior.Name = "butAnterior";
            this.butAnterior.Size = new System.Drawing.Size(48, 24);
            this.butAnterior.TabIndex = 14;
            this.butAnterior.Text = "Ant.";
            this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
            // 
            // gbModificacionProveedores
            // 
            this.gbModificacionProveedores.Controls.Add(this.label36);
            this.gbModificacionProveedores.Controls.Add(this.label35);
            this.gbModificacionProveedores.Controls.Add(this.groupBox4);
            this.gbModificacionProveedores.Controls.Add(this.tbComentarios);
            this.gbModificacionProveedores.Controls.Add(this.label34);
            this.gbModificacionProveedores.Controls.Add(this.label32);
            this.gbModificacionProveedores.Controls.Add(this.tbAjusteManual);
            this.gbModificacionProveedores.Controls.Add(this.label31);
            this.gbModificacionProveedores.Controls.Add(this.tbPuntajeAutomatico);
            this.gbModificacionProveedores.Controls.Add(this.label30);
            this.gbModificacionProveedores.Controls.Add(this.tbRanking);
            this.gbModificacionProveedores.Controls.Add(this.label29);
            this.gbModificacionProveedores.Controls.Add(this.tabControl2);
            this.gbModificacionProveedores.Controls.Add(this.butSalir);
            this.gbModificacionProveedores.Controls.Add(this.butGuardar);
            this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
            this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 32);
            this.gbModificacionProveedores.Name = "gbModificacionProveedores";
            this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 392);
            this.gbModificacionProveedores.TabIndex = 115;
            this.gbModificacionProveedores.TabStop = false;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(744, 315);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(40, 16);
            this.label36.TabIndex = 222;
            this.label36.Text = "(0..10)";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(744, 290);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 14);
            this.label35.TabIndex = 221;
            this.label35.Text = "(-10..10)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkParticular);
            this.groupBox4.Controls.Add(this.chkCorporativo);
            this.groupBox4.Controls.Add(this.cbEstado);
            this.groupBox4.Location = new System.Drawing.Point(328, 256);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 128);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo de Cliente";
            // 
            // chkParticular
            // 
            this.chkParticular.Location = new System.Drawing.Point(40, 88);
            this.chkParticular.Name = "chkParticular";
            this.chkParticular.Size = new System.Drawing.Size(104, 24);
            this.chkParticular.TabIndex = 20;
            this.chkParticular.Text = "Particular";
            // 
            // chkCorporativo
            // 
            this.chkCorporativo.Location = new System.Drawing.Point(40, 56);
            this.chkCorporativo.Name = "chkCorporativo";
            this.chkCorporativo.Size = new System.Drawing.Size(104, 24);
            this.chkCorporativo.TabIndex = 19;
            this.chkCorporativo.Text = "Corporativo";
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.Items.AddRange(new object[] {
            "Activo",
            "Potencial"});
            this.cbEstado.Location = new System.Drawing.Point(40, 16);
            this.cbEstado.MaxLength = 100;
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(120, 24);
            this.cbEstado.TabIndex = 18;
            // 
            // tbComentarios
            // 
            this.tbComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbComentarios.Location = new System.Drawing.Point(16, 272);
            this.tbComentarios.Multiline = true;
            this.tbComentarios.Name = "tbComentarios";
            this.tbComentarios.Size = new System.Drawing.Size(296, 112);
            this.tbComentarios.TabIndex = 16;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(16, 256);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(104, 14);
            this.label34.TabIndex = 218;
            this.label34.Text = "Comentarios";
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(656, 272);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(24, 24);
            this.label32.TabIndex = 215;
            this.label32.Text = "+";
            // 
            // tbAjusteManual
            // 
            this.tbAjusteManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAjusteManual.Location = new System.Drawing.Point(688, 288);
            this.tbAjusteManual.Name = "tbAjusteManual";
            this.tbAjusteManual.Size = new System.Drawing.Size(48, 20);
            this.tbAjusteManual.TabIndex = 22;
            this.tbAjusteManual.Text = "0";
            this.tbAjusteManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbAjusteManual.TextChanged += new System.EventHandler(this.tbAjusteManual_TextChanged);
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(560, 288);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 14);
            this.label31.TabIndex = 214;
            this.label31.Text = "Ajuste manual";
            // 
            // tbPuntajeAutomatico
            // 
            this.tbPuntajeAutomatico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPuntajeAutomatico.Location = new System.Drawing.Point(688, 264);
            this.tbPuntajeAutomatico.Name = "tbPuntajeAutomatico";
            this.tbPuntajeAutomatico.ReadOnly = true;
            this.tbPuntajeAutomatico.Size = new System.Drawing.Size(48, 20);
            this.tbPuntajeAutomatico.TabIndex = 21;
            this.tbPuntajeAutomatico.Text = "0";
            this.tbPuntajeAutomatico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(560, 264);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(104, 14);
            this.label30.TabIndex = 212;
            this.label30.Text = "Puntaje automático";
            // 
            // tbRanking
            // 
            this.tbRanking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRanking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRanking.Location = new System.Drawing.Point(688, 312);
            this.tbRanking.Name = "tbRanking";
            this.tbRanking.ReadOnly = true;
            this.tbRanking.Size = new System.Drawing.Size(48, 22);
            this.tbRanking.TabIndex = 23;
            this.tbRanking.Text = "0";
            this.tbRanking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(560, 312);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 16);
            this.label29.TabIndex = 210;
            this.label29.Text = "Ranking";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.HotTrack = true;
            this.tabControl2.ImageList = this.imagenesTab;
            this.tabControl2.Location = new System.Drawing.Point(8, 16);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(784, 232);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.cbIVA);
            this.tabPage8.Controls.Add(this.label50);
            this.tabPage8.Controls.Add(this.butLimpiarDatosLaborales);
            this.tabPage8.Controls.Add(this.tbTelefonosEmpresa);
            this.tabPage8.Controls.Add(this.label51);
            this.tabPage8.Controls.Add(this.tbEmailEmpresa);
            this.tabPage8.Controls.Add(this.label52);
            this.tabPage8.Controls.Add(this.tbCodPostEmpresa);
            this.tabPage8.Controls.Add(this.label53);
            this.tabPage8.Controls.Add(this.cbPaisEmpresa);
            this.tabPage8.Controls.Add(this.label54);
            this.tabPage8.Controls.Add(this.cbProvinciaEmpresa);
            this.tabPage8.Controls.Add(this.label55);
            this.tabPage8.Controls.Add(this.cbLocalidadEmpresa);
            this.tabPage8.Controls.Add(this.label56);
            this.tabPage8.Controls.Add(this.tbOficinaEmpresa);
            this.tabPage8.Controls.Add(this.label57);
            this.tabPage8.Controls.Add(this.tbPisoEmpresa);
            this.tabPage8.Controls.Add(this.label58);
            this.tabPage8.Controls.Add(this.tbNroEmpresa);
            this.tabPage8.Controls.Add(this.label59);
            this.tabPage8.Controls.Add(this.tbCalleEmpresa);
            this.tabPage8.Controls.Add(this.label60);
            this.tabPage8.Controls.Add(this.tbCuit);
            this.tabPage8.Controls.Add(this.label61);
            this.tabPage8.Controls.Add(this.cbCargo);
            this.tabPage8.Controls.Add(this.label62);
            this.tabPage8.Controls.Add(this.cbEmpresa);
            this.tabPage8.Controls.Add(this.label63);
            this.tabPage8.ImageIndex = 7;
            this.tabPage8.Location = new System.Drawing.Point(4, 23);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(776, 205);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Datos Empresa";
            this.tabPage8.Visible = false;
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
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(664, 8);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(72, 14);
            this.label50.TabIndex = 187;
            this.label50.Text = "IVA";
            // 
            // butLimpiarDatosLaborales
            // 
            this.butLimpiarDatosLaborales.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiarDatosLaborales.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiarDatosLaborales.Image")));
            this.butLimpiarDatosLaborales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiarDatosLaborales.Location = new System.Drawing.Point(672, 176);
            this.butLimpiarDatosLaborales.Name = "butLimpiarDatosLaborales";
            this.butLimpiarDatosLaborales.Size = new System.Drawing.Size(96, 24);
            this.butLimpiarDatosLaborales.TabIndex = 15;
            this.butLimpiarDatosLaborales.Text = "&Limpiar";
            this.butLimpiarDatosLaborales.Click += new System.EventHandler(this.butLimpiarDatosLaborales_Click);
            // 
            // tbTelefonosEmpresa
            // 
            this.tbTelefonosEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefonosEmpresa.Location = new System.Drawing.Point(272, 168);
            this.tbTelefonosEmpresa.Name = "tbTelefonosEmpresa";
            this.tbTelefonosEmpresa.Size = new System.Drawing.Size(232, 20);
            this.tbTelefonosEmpresa.TabIndex = 14;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(272, 152);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(136, 14);
            this.label51.TabIndex = 184;
            this.label51.Text = "Teléfonos";
            // 
            // tbEmailEmpresa
            // 
            this.tbEmailEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmailEmpresa.Location = new System.Drawing.Point(8, 168);
            this.tbEmailEmpresa.Name = "tbEmailEmpresa";
            this.tbEmailEmpresa.Size = new System.Drawing.Size(232, 20);
            this.tbEmailEmpresa.TabIndex = 13;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(8, 152);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(136, 14);
            this.label52.TabIndex = 182;
            this.label52.Text = "E-Mail";
            // 
            // tbCodPostEmpresa
            // 
            this.tbCodPostEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodPostEmpresa.Location = new System.Drawing.Point(704, 72);
            this.tbCodPostEmpresa.Name = "tbCodPostEmpresa";
            this.tbCodPostEmpresa.Size = new System.Drawing.Size(64, 20);
            this.tbCodPostEmpresa.TabIndex = 10;
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(704, 56);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(56, 14);
            this.label53.TabIndex = 180;
            this.label53.Text = "Cod.Post.";
            // 
            // cbPaisEmpresa
            // 
            this.cbPaisEmpresa.Location = new System.Drawing.Point(272, 120);
            this.cbPaisEmpresa.MaxLength = 100;
            this.cbPaisEmpresa.Name = "cbPaisEmpresa";
            this.cbPaisEmpresa.Size = new System.Drawing.Size(232, 21);
            this.cbPaisEmpresa.TabIndex = 12;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(272, 104);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(128, 14);
            this.label54.TabIndex = 178;
            this.label54.Text = "Pais";
            // 
            // cbProvinciaEmpresa
            // 
            this.cbProvinciaEmpresa.Location = new System.Drawing.Point(8, 120);
            this.cbProvinciaEmpresa.MaxLength = 100;
            this.cbProvinciaEmpresa.Name = "cbProvinciaEmpresa";
            this.cbProvinciaEmpresa.Size = new System.Drawing.Size(232, 21);
            this.cbProvinciaEmpresa.TabIndex = 11;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(8, 104);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(128, 14);
            this.label55.TabIndex = 176;
            this.label55.Text = "Provincia";
            // 
            // cbLocalidadEmpresa
            // 
            this.cbLocalidadEmpresa.Location = new System.Drawing.Point(536, 72);
            this.cbLocalidadEmpresa.MaxLength = 100;
            this.cbLocalidadEmpresa.Name = "cbLocalidadEmpresa";
            this.cbLocalidadEmpresa.Size = new System.Drawing.Size(160, 21);
            this.cbLocalidadEmpresa.TabIndex = 9;
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(536, 56);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(128, 14);
            this.label56.TabIndex = 174;
            this.label56.Text = "Localidad";
            // 
            // tbOficinaEmpresa
            // 
            this.tbOficinaEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOficinaEmpresa.Location = new System.Drawing.Point(440, 72);
            this.tbOficinaEmpresa.Name = "tbOficinaEmpresa";
            this.tbOficinaEmpresa.Size = new System.Drawing.Size(64, 20);
            this.tbOficinaEmpresa.TabIndex = 8;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(440, 56);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(48, 14);
            this.label57.TabIndex = 172;
            this.label57.Text = "Oficina";
            // 
            // tbPisoEmpresa
            // 
            this.tbPisoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPisoEmpresa.Location = new System.Drawing.Point(360, 72);
            this.tbPisoEmpresa.Name = "tbPisoEmpresa";
            this.tbPisoEmpresa.Size = new System.Drawing.Size(64, 20);
            this.tbPisoEmpresa.TabIndex = 7;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(360, 56);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(48, 14);
            this.label58.TabIndex = 170;
            this.label58.Text = "Piso";
            // 
            // tbNroEmpresa
            // 
            this.tbNroEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroEmpresa.Location = new System.Drawing.Point(272, 72);
            this.tbNroEmpresa.Name = "tbNroEmpresa";
            this.tbNroEmpresa.Size = new System.Drawing.Size(72, 20);
            this.tbNroEmpresa.TabIndex = 6;
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(272, 56);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(80, 14);
            this.label59.TabIndex = 168;
            this.label59.Text = "Nro.";
            // 
            // tbCalleEmpresa
            // 
            this.tbCalleEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCalleEmpresa.Location = new System.Drawing.Point(8, 72);
            this.tbCalleEmpresa.Name = "tbCalleEmpresa";
            this.tbCalleEmpresa.Size = new System.Drawing.Size(232, 20);
            this.tbCalleEmpresa.TabIndex = 5;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 56);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(136, 14);
            this.label60.TabIndex = 166;
            this.label60.Text = "Calle";
            // 
            // tbCuit
            // 
            this.tbCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCuit.Location = new System.Drawing.Point(536, 24);
            this.tbCuit.Name = "tbCuit";
            this.tbCuit.Size = new System.Drawing.Size(120, 20);
            this.tbCuit.TabIndex = 3;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(536, 8);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(136, 14);
            this.label61.TabIndex = 164;
            this.label61.Text = "CUIT";
            // 
            // cbCargo
            // 
            this.cbCargo.Location = new System.Drawing.Point(272, 24);
            this.cbCargo.MaxLength = 100;
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(232, 21);
            this.cbCargo.TabIndex = 2;
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(272, 8);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(128, 14);
            this.label62.TabIndex = 162;
            this.label62.Text = "Cargo";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.Location = new System.Drawing.Point(8, 24);
            this.cbEmpresa.MaxLength = 100;
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(232, 21);
            this.cbEmpresa.TabIndex = 1;
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(8, 8);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(128, 14);
            this.label63.TabIndex = 160;
            this.label63.Text = "Empresa";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.butLimpiarDatosPersonales);
            this.tabPage7.Controls.Add(this.dtpFechaNacimiento);
            this.tabPage7.Controls.Add(this.label28);
            this.tabPage7.Controls.Add(this.tbNombres);
            this.tabPage7.Controls.Add(this.label26);
            this.tabPage7.Controls.Add(this.tbApellido);
            this.tabPage7.Controls.Add(this.label27);
            this.tabPage7.Controls.Add(this.tbTelefonos);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Controls.Add(this.tbEmail);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.tbCodPost);
            this.tabPage7.Controls.Add(this.label5);
            this.tabPage7.Controls.Add(this.cbPais);
            this.tabPage7.Controls.Add(this.label6);
            this.tabPage7.Controls.Add(this.cbProvincia);
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.cbLocalidad);
            this.tabPage7.Controls.Add(this.label14);
            this.tabPage7.Controls.Add(this.tbDepto);
            this.tabPage7.Controls.Add(this.label22);
            this.tabPage7.Controls.Add(this.tbPiso);
            this.tabPage7.Controls.Add(this.label25);
            this.tabPage7.Controls.Add(this.tbNro);
            this.tabPage7.Controls.Add(this.label33);
            this.tabPage7.Controls.Add(this.tbCalle);
            this.tabPage7.Controls.Add(this.label37);
            this.tabPage7.Controls.Add(this.tbDni);
            this.tabPage7.Controls.Add(this.label49);
            this.tabPage7.ImageIndex = 6;
            this.tabPage7.Location = new System.Drawing.Point(4, 23);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(776, 205);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Datos Personales";
            // 
            // butLimpiarDatosPersonales
            // 
            this.butLimpiarDatosPersonales.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiarDatosPersonales.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiarDatosPersonales.Image")));
            this.butLimpiarDatosPersonales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiarDatosPersonales.Location = new System.Drawing.Point(672, 176);
            this.butLimpiarDatosPersonales.Name = "butLimpiarDatosPersonales";
            this.butLimpiarDatosPersonales.Size = new System.Drawing.Size(96, 24);
            this.butLimpiarDatosPersonales.TabIndex = 15;
            this.butLimpiarDatosPersonales.Text = "&Limpiar";
            this.butLimpiarDatosPersonales.Click += new System.EventHandler(this.butLimpiarDatosPersonales_Click);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(536, 120);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(232, 20);
            this.dtpFechaNacimiento.TabIndex = 12;
            this.dtpFechaNacimiento.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(536, 104);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(136, 14);
            this.label28.TabIndex = 216;
            this.label28.Text = "Fecha de Nacimiento";
            // 
            // tbNombres
            // 
            this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombres.Location = new System.Drawing.Point(272, 24);
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.Size = new System.Drawing.Size(232, 20);
            this.tbNombres.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(272, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(136, 14);
            this.label26.TabIndex = 214;
            this.label26.Text = "Nombres";
            // 
            // tbApellido
            // 
            this.tbApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApellido.Location = new System.Drawing.Point(8, 24);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(232, 20);
            this.tbApellido.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(136, 14);
            this.label27.TabIndex = 212;
            this.label27.Text = "Apellido";
            // 
            // tbTelefonos
            // 
            this.tbTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefonos.Location = new System.Drawing.Point(272, 168);
            this.tbTelefonos.Name = "tbTelefonos";
            this.tbTelefonos.Size = new System.Drawing.Size(232, 20);
            this.tbTelefonos.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(272, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 14);
            this.label1.TabIndex = 210;
            this.label1.Text = "Teléfonos";
            // 
            // tbEmail
            // 
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmail.Location = new System.Drawing.Point(8, 168);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(232, 20);
            this.tbEmail.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 14);
            this.label2.TabIndex = 208;
            this.label2.Text = "E-Mail";
            // 
            // tbCodPost
            // 
            this.tbCodPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodPost.Location = new System.Drawing.Point(704, 72);
            this.tbCodPost.Name = "tbCodPost";
            this.tbCodPost.Size = new System.Drawing.Size(64, 20);
            this.tbCodPost.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(704, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 206;
            this.label5.Text = "Cod.Post.";
            // 
            // cbPais
            // 
            this.cbPais.Location = new System.Drawing.Point(272, 120);
            this.cbPais.MaxLength = 11;
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(232, 21);
            this.cbPais.TabIndex = 203;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(272, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 14);
            this.label6.TabIndex = 204;
            this.label6.Text = "Pais";
            // 
            // cbProvincia
            // 
            this.cbProvincia.Location = new System.Drawing.Point(8, 120);
            this.cbProvincia.MaxLength = 100;
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(232, 21);
            this.cbProvincia.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 14);
            this.label8.TabIndex = 202;
            this.label8.Text = "Provincia";
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.Location = new System.Drawing.Point(536, 72);
            this.cbLocalidad.MaxLength = 100;
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(160, 21);
            this.cbLocalidad.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(536, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 14);
            this.label14.TabIndex = 200;
            this.label14.Text = "Localidad";
            // 
            // tbDepto
            // 
            this.tbDepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDepto.Location = new System.Drawing.Point(440, 72);
            this.tbDepto.Name = "tbDepto";
            this.tbDepto.Size = new System.Drawing.Size(64, 20);
            this.tbDepto.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(440, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 14);
            this.label22.TabIndex = 198;
            this.label22.Text = "Depto.";
            // 
            // tbPiso
            // 
            this.tbPiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPiso.Location = new System.Drawing.Point(360, 72);
            this.tbPiso.Name = "tbPiso";
            this.tbPiso.Size = new System.Drawing.Size(64, 20);
            this.tbPiso.TabIndex = 6;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(360, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 14);
            this.label25.TabIndex = 196;
            this.label25.Text = "Piso";
            // 
            // tbNro
            // 
            this.tbNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNro.Location = new System.Drawing.Point(272, 72);
            this.tbNro.Name = "tbNro";
            this.tbNro.Size = new System.Drawing.Size(72, 20);
            this.tbNro.TabIndex = 5;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(272, 56);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(80, 14);
            this.label33.TabIndex = 194;
            this.label33.Text = "Nro.";
            // 
            // tbCalle
            // 
            this.tbCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCalle.Location = new System.Drawing.Point(8, 72);
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.Size = new System.Drawing.Size(232, 20);
            this.tbCalle.TabIndex = 4;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(8, 56);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(136, 14);
            this.label37.TabIndex = 192;
            this.label37.Text = "Calle";
            // 
            // tbDni
            // 
            this.tbDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDni.Location = new System.Drawing.Point(536, 24);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(232, 20);
            this.tbDni.TabIndex = 3;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(536, 8);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(136, 14);
            this.label49.TabIndex = 190;
            this.label49.Text = "DNI";
            // 
            // butSalir
            // 
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(688, 368);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(96, 24);
            this.butSalir.TabIndex = 26;
            this.butSalir.Text = "&Salir";
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // butGuardar
            // 
            this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
            this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGuardar.Location = new System.Drawing.Point(560, 360);
            this.butGuardar.Name = "butGuardar";
            this.butGuardar.Size = new System.Drawing.Size(120, 24);
            this.butGuardar.TabIndex = 25;
            this.butGuardar.Text = "&Guardar";
            this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
            // 
            // butLimpiar
            // 
            this.butLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
            this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar.Location = new System.Drawing.Point(688, 344);
            this.butLimpiar.Name = "butLimpiar";
            this.butLimpiar.Size = new System.Drawing.Size(96, 24);
            this.butLimpiar.TabIndex = 24;
            this.butLimpiar.Text = "&Limpiar";
            this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(816, 32);
            this.label18.TabIndex = 95;
            this.label18.Text = "     Modificación de Clientes";
            // 
            // ucClienteConsulta
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucClienteConsulta";
            this.Size = new System.Drawing.Size(824, 456);
            this.Load += new System.EventHandler(this.ucClienteConsulta_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabFiltro1.ResumeLayout(false);
            this.tabFiltro1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.gbFechaEmision.ResumeLayout(false);
            this.tabFiltro3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbRegistro.ResumeLayout(false);
            this.gbModificacionProveedores.ResumeLayout(false);
            this.gbModificacionProveedores.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{

				UtilUI.llenarCombo(ref cbEstadoB, this.conexion, "sp_getAlltv_ClienteEstados", "Todos", 0);
				UtilUI.llenarCombo(ref cbEmpresaB, this.conexion, "sp_getAlltv_ClienteEmpresas", "Todas", 0);
				UtilUI.llenarCombo(ref cbCargoB, this.conexion, "sp_getAlltv_ClienteCargos", "Todos", 0);
				UtilUI.llenarCombo(ref cbIVAB, this.conexion, "sp_getAllIVAs", "Todos", 0);
				UtilUI.llenarCombo(ref cbLocalidadEmpresaB, this.conexion, "sp_getAllLocalidads", "Todas", 0);
				UtilUI.llenarCombo(ref cbProvinciaEmpresaB, this.conexion, "sp_getAllProvincias", "Todas", 0);
				UtilUI.llenarCombo(ref cbPaisEmpresaB, this.conexion, "sp_getAllPaiss", "Todos", 0);
				UtilUI.llenarCombo(ref cbLocalidadB, this.conexion, "sp_getAllLocalidads", "Todas", 0);
				UtilUI.llenarCombo(ref cbProvinciaB, this.conexion, "sp_getAllProvincias", "Todas", 0);
				UtilUI.llenarCombo(ref cbPaisB, this.conexion, "sp_getAllPaiss", "Todos", 0);
			
				acomodarCombosOrden();

				//Define el tipo de consulta
				if (consultaRapida)
				{
					butSalir4.Visible = false;
					butAceptar1.Visible = true;
				}
				else
				{
					butSalir4.Visible = true;
					butAceptar1.Visible = false;
				}

				asignarEventosGrilla(ref dgItems);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Devuelve el ID de cliente seleccionado en la grilla
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


		private void acomodarCombosOrden()
		{
			try
			{

				cbCampoOrden1.SelectedIndex = 2;  //Apellido
				rbAsc1.Checked = true;
				cbCampoOrden2.SelectedIndex = 19;  //Nombres
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
					//if (dvItems.Table.Rows.Count>0)
						//dgItems.Select();
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
				string sql = "SELECT     dbo.Cliente.id, dbo.Cliente.empresaID, dbo.tv_ClienteEmpresa.descripcion AS Empresa, dbo.Cliente.cargoID, " +
					"dbo.tv_ClienteCargo.descripcion AS Cargo, dbo.Cliente.empresa_calle AS [Calle (empresa)], dbo.Cliente.empresa_nro AS [Nro. (empresa)], " +
					"dbo.Cliente.empresa_piso AS [Piso (empresa)], dbo.Cliente.empresa_oficina AS [Of. (empresa)], dbo.Cliente.empresa_localidadID, " +
					"dbo.Localidad.descripcion AS [Localidad (empresa)], dbo.Cliente.empresa_provinciaID, dbo.Provincia.descripcion AS [Provincia (empresa)], " +
					"dbo.Cliente.empresa_paisID, dbo.Pais.descripcion AS [País (empresa)], dbo.Cliente.empresa_codPost AS [Cod.Post. (empresa)], " +
					"dbo.Cliente.empresa_eMail AS [E-Mail (empresa)], dbo.Cliente.empresa_telefonos AS [Teléfonos (empresa)], " +
					"dbo.Cliente.empresa_cuit AS [CUIT (empresa)], dbo.Cliente.apellido AS [Apellido], dbo.Cliente.nombres AS [Nombres], dbo.Cliente.calle AS [Calle], dbo.Cliente.nro AS [Nro.], dbo.Cliente.piso AS [Piso], " +
					"dbo.Cliente.depto AS [Depto.], dbo.Cliente.localidadID, Localidad_1.descripcion AS Localidad, dbo.Cliente.provinciaID, " +
					"Provincia_1.descripcion AS Provincia, dbo.Cliente.paisID, Pais_1.descripcion AS País, dbo.Cliente.codPost AS [Cod.Post.], dbo.Cliente.eMail AS [E-Mail], " +
					" dbo.Cliente.telefonos AS Teléfonos, dbo.Cliente.dni AS [DNI], dbo.Cliente.fechaNacimiento AS [F.Nacimiento], dbo.Cliente.comentarios, dbo.Cliente.estadoID, " +
					"dbo.tv_ClienteEstado.descripcion AS Estado, dbo.Cliente.puntajeAutomatico AS [Ptje.Aut.], dbo.Cliente.ajusteManual AS [Ajt.Manual], " +
					"dbo.Cliente.ranking AS [Ranking], dbo.Cliente.ivaID, dbo.IVA.descripcion AS IVA, " +
					"CASE dbo.Cliente.clienteParticular WHEN 1 THEN 'Si' WHEN 0 THEN 'No' END AS Particular, " +
					"CASE dbo.Cliente.clienteCorporativo WHEN 1 THEN 'Si' WHEN 0 THEN 'No' END AS Corporativo " +
					"FROM         dbo.Cliente LEFT OUTER JOIN " +
					"dbo.tv_ClienteEstado ON dbo.Cliente.estadoID = dbo.tv_ClienteEstado.id LEFT OUTER JOIN " +
					"dbo.IVA ON dbo.Cliente.ivaID = dbo.IVA.id LEFT OUTER JOIN " +
					"dbo.Pais Pais_1 ON dbo.Cliente.paisID = Pais_1.id LEFT OUTER JOIN " +
					"dbo.Provincia Provincia_1 ON dbo.Cliente.provinciaID = Provincia_1.id LEFT OUTER JOIN " +
					"dbo.Localidad Localidad_1 ON dbo.Cliente.localidadID = Localidad_1.id LEFT OUTER JOIN " +
					"dbo.Pais ON dbo.Cliente.empresa_paisID = dbo.Pais.id LEFT OUTER JOIN " +
					"dbo.Provincia ON dbo.Cliente.empresa_provinciaID = dbo.Provincia.id LEFT OUTER JOIN " +
					"dbo.Localidad ON dbo.Cliente.empresa_localidadID = dbo.Localidad.id LEFT OUTER JOIN " +
					"dbo.tv_ClienteCargo ON dbo.Cliente.cargoID = dbo.tv_ClienteCargo.id LEFT OUTER JOIN " +
					"dbo.tv_ClienteEmpresa ON dbo.Cliente.empresaID = dbo.tv_ClienteEmpresa.id " +
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

				if (tbPalabrasClaveB.Text.Trim()!="") 
					filtro += obtenerWHEREBLOB(tbPalabrasClaveB.Text);

				if (tbApellidoB.Text.Trim()!="") 
					filtro += " AND apellido LIKE '%" + tbApellidoB.Text.Trim() + "%'";

				if (tbNombresB.Text.Trim()!="") 
					filtro += " AND nombres LIKE '%" + tbNombresB.Text.Trim() + "%'";

				if (tbDniB.Text.Trim()!="") 
					filtro += " AND dni LIKE '" + tbDniB.Text.Trim() + "%'";

				if (cbEmpresaB.SelectedIndex>0) 
					filtro += " AND empresaID = CAST('" + cbEmpresaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (tbCuitB.Text.Trim()!="") 
					filtro += " AND empresa_cuit LIKE '" + tbCuitB.Text.Trim() + "%'";

				if (tbRankingDesdeB.Text.Trim()!="") 
					filtro += " AND ranking >= " + tbRankingDesdeB.Text.Trim();

				if (tbRankingHastaB.Text.Trim()!="") 
					filtro += " AND ranking <= " + tbRankingHastaB.Text.Trim();

				if (cbEstadoB.SelectedIndex>0) 
					filtro += " AND estadoID = CAST('" + cbEstadoB.SelectedValue.ToString() + "' AS uniqueidentifier)";

				if (chkCorporativoB.Checked)
					filtro += " AND clienteCorporativo=1";

				if (chkParticularB.Checked)
					filtro += " AND clienteParticular=1";

				if (tbCalleB.Text.Trim()!="") 
					filtro += " AND calle LIKE '%" + tbCalleB.Text.Trim() + "%'";

				if (tbNroB.Text.Trim()!="") 
					filtro += " AND nro = '" + tbNroB.Text.Trim() + "'";

				if (tbPisoB.Text.Trim()!="") 
					filtro += " AND piso = '" + tbPisoB.Text.Trim() + "'";

				if (tbDeptoB.Text.Trim()!="") 
					filtro += " AND depto = '" + tbDeptoB.Text.Trim() + "'";

				if (cbLocalidadB.SelectedIndex>0) 
					filtro += " AND localidadID = CAST('" + cbLocalidadB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (tbCodPostB.Text.Trim()!="") 
					filtro += " AND codPost = '" + tbCodPostB.Text.Trim() + "'";
			
				if (cbProvinciaB.SelectedIndex>0) 
					filtro += " AND provinciaID = CAST('" + cbProvinciaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (cbPaisB.SelectedIndex>0) 
					filtro += " AND paisID = CAST('" + cbPaisB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (tbEmailB.Text.Trim()!="") 
					filtro += " AND eMail = '" + tbEmailB.Text.Trim() + "%'";

				if (tbTelefonosB.Text.Trim()!="") 
					filtro += " AND telefonos = '" + tbTelefonosB.Text.Trim() + "%'";
			
				//Fechas
				DateTime fechaDesde, fechaHasta;
				string dia, mes, anio, sfechaDesde, sfechaHasta;
				if (chkFechaNacimientoB.Checked)
				{
					fechaDesde = dtpFechaNacimientoDesdeB.Value;
					fechaHasta = dtpFechaNacimientoHastaB.Value;
					dia = fechaDesde.Day.ToString("00");
					mes = fechaDesde.Month.ToString("00");
					anio = fechaDesde.Year.ToString("0000");
					sfechaDesde = "{ts '" + anio + "-" + mes + "-" + dia + " 00:00:00'}";
					filtro = filtro + " AND fechaNacimiento >= " + sfechaDesde;
				
					dia = fechaHasta.Day.ToString("00");
					mes = fechaHasta.Month.ToString("00");
					anio = fechaHasta.Year.ToString("0000");
					sfechaHasta = "{ts '" + anio + "-" + mes + "-" + dia + " 23:59:59'}";
					filtro = filtro + " AND fechaNacimiento <= " + sfechaHasta;
				}
			
				if (cbCargoB.SelectedIndex>0) 
					filtro += " AND cargoID = CAST('" + cbCargoB.SelectedValue.ToString() + "' AS uniqueidentifier)";

				if (cbIVAB.SelectedIndex>0) 
					filtro += " AND ivaID = CAST('" + cbIVAB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (tbCalleEmpresaB.Text.Trim()!="") 
					filtro += " AND empresa_calle LIKE '%" + tbCalleEmpresaB.Text.Trim() + "%'";

				if (tbNroEmpresaB.Text.Trim()!="") 
					filtro += " AND empresa_nro = '" + tbNroEmpresaB.Text.Trim() + "'";

				if (tbPisoEmpresaB.Text.Trim()!="") 
					filtro += " AND empresa_piso = '" + tbPisoEmpresaB.Text.Trim() + "'";

				if (tbOficinaEmpresaB.Text.Trim()!="") 
					filtro += " AND empresa_oficina = '" + tbOficinaEmpresaB.Text.Trim() + "'";

				if (cbLocalidadEmpresaB.SelectedIndex>0) 
					filtro += " AND empresa_localidadID = CAST('" + cbLocalidadEmpresaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (tbCodPostEmpresaB.Text.Trim()!="") 
					filtro += " AND empresa_codPost = '" + tbCodPostEmpresaB.Text.Trim() + "'";
			
				if (cbProvinciaEmpresaB.SelectedIndex>0) 
					filtro += " AND empresa_provinciaID = CAST('" + cbProvinciaEmpresaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (cbPaisEmpresaB.SelectedIndex>0) 
					filtro += " AND empresa_paisID = CAST('" + cbPaisEmpresaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
			
				if (tbEmailEmpresaB.Text.Trim()!="") 
					filtro += " AND empresa_eMail = '" + tbEmailEmpresaB.Text.Trim() + "%'";

				if (tbTelefonosEmpresaB.Text.Trim()!="") 
					filtro += " AND empresa_telefonos = '" + tbTelefonosEmpresaB.Text.Trim() + "%'";

				return filtro;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		//Prepara los LIKEs para las palabras clave
		private string obtenerWHEREBLOB(string palabras)
		{
			try
			{

				//Extrae los espacios de mas
				while (palabras.IndexOf("  ")>-1)
					palabras = palabras.Replace("  "," ");

				string[] aPalabras = palabras.Split(' ');
				string where = "";
				for (int i=0; i<aPalabras.Length; i++)
				{
					where += " AND registroBLOB LIKE '%" + aPalabras[i] + "%'";
				}
				return where;
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

		private void butBuscar4_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butBuscar1_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butBuscar2_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butBuscar3_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void butSalir4_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
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

		//Limpia todos los campos del formulario de busqueda
		private void limpiarBusqueda()
		{
			try
			{

				//Busqueda textual
				tbPalabrasClaveB.Text = "";
				//Filtro rapido
				tbApellidoB.Text = "";
				tbNombresB.Text = "";
				tbDni.Text = "";
				cbEstadoB.SelectedIndex = 0;
				chkCorporativoB.Checked = false;
				chkParticularB.Checked = false;
				cbEmpresaB.SelectedIndex = 0;
				tbCuitB.Text = "";
				tbRankingDesdeB.Text = "";
				tbRankingHastaB.Text = "";
				//Datos Personales
				tbCalleB.Text = "";
				tbNroB.Text = "";
				tbPisoB.Text = "";
				tbDeptoB.Text = "";
				cbLocalidadB.SelectedIndex = 0;
				tbCodPostB.Text = "";
				cbProvinciaB.SelectedIndex = 0;
				cbPaisB.SelectedIndex = 0;
				tbEmailB.Text = "";
				tbTelefonosB.Text = "";
				chkFechaNacimientoB.Checked = false;
				dtpFechaNacimientoDesdeB.Value = DateTime.Now;
				dtpFechaNacimientoHastaB.Value = DateTime.Now;
				//Datos Laborales
				cbCargoB.SelectedIndex = 0;
				cbIVAB.SelectedIndex = 0;
				tbCalleEmpresaB.Text = "";
				tbNroEmpresaB.Text = "";
				tbPisoEmpresaB.Text = "";
				tbOficinaEmpresaB.Text = "";
				cbLocalidadEmpresaB.SelectedIndex = 0;
				tbCodPostEmpresaB.Text = "";
				cbProvinciaEmpresaB.SelectedIndex = 0;
				cbPaisEmpresaB.SelectedIndex = 0;
				tbEmailEmpresaB.Text = "";
				tbTelefonosEmpresaB.Text = "";
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butLimpiar4_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void butLimpiar2_Click(object sender, System.EventArgs e)
		{
			limpiarBusqueda();
		}

		private void tbRankingDesdeB_Validated(object sender, System.EventArgs e)
		{
			try
			{

				string rankingDesde = tbRankingDesdeB.Text.Trim();
				string rankingHasta = tbRankingHastaB.Text.Trim();
				if (rankingDesde!="")
				{
					if (rankingHasta=="" || int.Parse(rankingHasta)<int.Parse(rankingDesde))
						tbRankingHastaB.Text = tbRankingDesdeB.Text;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbRankingDesdeB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{

				string rankingDesde = tbRankingDesdeB.Text.Trim().Replace(",","").Replace(".","");
				if (rankingDesde!="")
				{
					if (!Utilidades.IsNumeric(rankingDesde))
					{
						e.Cancel = true;
						MessageBox.Show("El Ranking (Desde) debe contener un número entero.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				tbRankingDesdeB.Text = rankingDesde;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbRankingHastaB_Validated(object sender, System.EventArgs e)
		{
			try
			{

				string rankingDesde = tbRankingDesdeB.Text.Trim();
				string rankingHasta = tbRankingHastaB.Text.Trim();
				if (rankingHasta!="")
				{
					if (rankingDesde=="" || int.Parse(rankingDesde)>int.Parse(rankingHasta))
						tbRankingDesdeB.Text = tbRankingHastaB.Text;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void tbRankingHastaB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{

				string rankingHasta = tbRankingHastaB.Text.Trim().Replace(",","").Replace(".","");
				if (rankingHasta!="")
				{
					if (!Utilidades.IsNumeric(rankingHasta))
					{
						e.Cancel = true;
						MessageBox.Show("Ranking (Hasta) debe contener un número entero.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				tbRankingHastaB.Text = rankingHasta;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void chkFechaNacimientoB_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpFechaNacimientoDesdeB.Enabled = chkFechaNacimientoB.Checked;
			dtpFechaNacimientoHastaB.Enabled = chkFechaNacimientoB.Checked;
		}

		private void dtbFechaNacimientoDesdeB_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaNacimientoHastaB.Value < dtpFechaNacimientoDesdeB.Value)
				dtpFechaNacimientoHastaB.Value = dtpFechaNacimientoDesdeB.Value;
		}

		private void dtpFechaNacimientoHastaB_ValueChanged(object sender, System.EventArgs e)
		{
			if (dtpFechaNacimientoDesdeB.Value > dtpFechaNacimientoHastaB.Value)
				dtpFechaNacimientoDesdeB.Value = dtpFechaNacimientoHastaB.Value;
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
							gbModificacionProveedores.Enabled = true;
							gbRegistro.Enabled = true;
						}
						else
						{
							gbModificacionProveedores.Enabled = false;
							gbRegistro.Enabled = false;
						}
					else
					{
						gbModificacionProveedores.Enabled = false;
						gbRegistro.Enabled = false;
					}
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

						//Datos Personales
						tbApellido.Text = dt.Rows[currentRow]["Apellido"].ToString();
						tbNombres.Text = dt.Rows[currentRow]["Nombres"].ToString();
						tbDni.Text = dt.Rows[currentRow]["DNI"].ToString();
						tbCalle.Text = dt.Rows[currentRow]["Calle"].ToString();
						tbNro.Text = dt.Rows[currentRow]["Nro."].ToString();
						tbPiso.Text = dt.Rows[currentRow]["Piso"].ToString();
						tbDepto.Text = dt.Rows[currentRow]["Depto."].ToString();
					
						UtilUI.llenarCombo(ref cbLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
						cbLocalidad.SelectedValue = dt.Rows[currentRow]["localidadID"].ToString();

						tbCodPost.Text = dt.Rows[currentRow]["Cod.Post."].ToString();

						UtilUI.llenarCombo(ref cbProvincia, this.conexion, "sp_getAllProvincias", "", -1);
						cbProvincia.SelectedValue = dt.Rows[currentRow]["provinciaID"].ToString();
					
						UtilUI.llenarCombo(ref cbPais, this.conexion, "sp_getAllPaiss", "", -1);
						cbPais.SelectedValue = dt.Rows[currentRow]["paisID"].ToString();

						dtpFechaNacimiento.Value = DateTime.Parse(dt.Rows[currentRow]["F.Nacimiento"].ToString());
						tbEmail.Text = dt.Rows[currentRow]["E-Mail"].ToString();
						tbTelefonos.Text = dt.Rows[currentRow]["Teléfonos"].ToString();

						//Datos Laborales
						UtilUI.llenarCombo(ref cbEmpresa, this.conexion, "sp_getAlltv_ClienteEmpresas", "", -1);
						cbEmpresa.SelectedValue = dt.Rows[currentRow]["empresaID"].ToString();

						UtilUI.llenarCombo(ref cbCargo, this.conexion, "sp_getAlltv_ClienteCargos", "", -1);
						cbCargo.SelectedValue = dt.Rows[currentRow]["cargoID"].ToString();
					
						tbCuit.Text = dt.Rows[currentRow]["CUIT (empresa)"].ToString();

						UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
						cbIVA.SelectedValue = dt.Rows[currentRow]["ivaID"].ToString();

						tbCalleEmpresa.Text = dt.Rows[currentRow]["Calle (empresa)"].ToString();
						tbNroEmpresa.Text = dt.Rows[currentRow]["Nro. (empresa)"].ToString();
						tbPisoEmpresa.Text = dt.Rows[currentRow]["Piso (empresa)"].ToString();
						tbOficinaEmpresa.Text = dt.Rows[currentRow]["Of. (empresa)"].ToString();

						UtilUI.llenarCombo(ref cbLocalidadEmpresa, this.conexion, "sp_getAllLocalidads", "", -1);
						cbLocalidadEmpresa.SelectedValue = dt.Rows[currentRow]["empresa_localidadID"].ToString();

						tbCodPostEmpresa.Text = dt.Rows[currentRow]["Cod.Post. (empresa)"].ToString();

						UtilUI.llenarCombo(ref cbProvinciaEmpresa, this.conexion, "sp_getAllProvincias", "", -1);
						cbProvinciaEmpresa.SelectedValue = dt.Rows[currentRow]["empresa_provinciaID"].ToString();
					
						UtilUI.llenarCombo(ref cbPaisEmpresa, this.conexion, "sp_getAllPaiss", "", -1);
						cbPaisEmpresa.SelectedValue = dt.Rows[currentRow]["empresa_paisID"].ToString();

						tbEmailEmpresa.Text = dt.Rows[currentRow]["E-Mail (empresa)"].ToString();
						tbTelefonosEmpresa.Text = dt.Rows[currentRow]["Teléfonos (empresa)"].ToString();

						//Otros datos
						tbComentarios.Text = dt.Rows[currentRow]["comentarios"].ToString();

						UtilUI.llenarCombo(ref cbEstado, this.conexion, "sp_getAlltv_ClienteEstados", "", -1);
						cbEstado.SelectedValue = dt.Rows[currentRow]["estadoID"].ToString();

						if (dt.Rows[currentRow]["Corporativo"].ToString()=="Si")
							chkCorporativo.Checked = true;
						if (dt.Rows[currentRow]["Particular"].ToString()=="Si")
							chkParticular.Checked = true;

						tbPuntajeAutomatico.Text = dt.Rows[currentRow]["Ptje.Aut."].ToString();
						tbAjusteManual.Text = dt.Rows[currentRow]["Ajt.Manual"].ToString();
						tbRanking.Text = dt.Rows[currentRow]["Ranking"].ToString();


						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

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

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Registro...", true);
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

                if (cbEmpresa.Text.Trim() == "")
                {
                    if (tbApellido.Text.Trim() == "")
                    {
                        mensaje += "   - El campo Apellido está vacío.\r\n";
                        resultado = false;
                    }
                    if (tbNombres.Text.Trim() == "")
                    {
                        mensaje += "   - El campo Nombres está vacío.\r\n";
                        resultado = false;
                    }
                }

                //Valida el CUIT
                if (cbEmpresa.Text.Trim() != "")
                {
                    tbCuit.Text = Utilidades.limpiarCUIT(tbCuit.Text.Trim());
                    if (!Utilidades.validarCUIT(tbCuit.Text))
                    {
                        mensaje += "   - El campo CUIT es incorrecto.\r\n";
                        resultado = false;
                    }
                }

				if (tbAjusteManual.Text.Trim()=="" || !Utilidades.IsNumeric(tbAjusteManual.Text.Trim()))
				{
					mensaje += "   - El valor del campo Ajuste manual debe ser un número.\r\n";
					resultado = false;
				}
				if (tbEmail.Text.Trim()!="")
					if (!Utilidades.IsEmailAddress(tbEmail.Text.Trim()))
					{
						mensaje += "   - El campo E-Mail en Datos Personales es incorrecto.\r\n";
						resultado = false;
					}
				if (tbEmailEmpresa.Text.Trim()!="")
					if (!Utilidades.IsEmailAddress(tbEmailEmpresa.Text.Trim()))
					{
						mensaje += "   - El campo E-Mail en Datos Laborales es incorrecto.\r\n";
						resultado = false;
					}

                

                //Valida el DNI
                tbDni.Text = Utilidades.limpiarCUIT(tbDni.Text.Trim());
		
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Modificación de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Guarda los cambios del registro en la base de datos
		private void guardarCambios()
		{
			try
			{
				//Obtiene los valores a modificar
				string id = tbID.Text;
				//Datos Personales
				string apellido = tbApellido.Text;
				string nombres = tbNombres.Text;
				string dni = tbDni.Text;
				string calle = tbCalle.Text;
				string nro = tbNro.Text;
				string piso = tbPiso.Text;
				string depto = tbDepto.Text;
				string localidadID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidad, "sp_InsertLocalidad", "sp_getAllLocalidads");
				string codPost = tbCodPost.Text;
				string provinciaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvincia, "sp_InsertProvincia", "sp_getAllProvincias");
				string paisID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbPais, "sp_InsertPais", "sp_getAllPaiss");
				DateTime fechaNacimiento = dtpFechaNacimiento.Value;
				string eMail = tbEmail.Text;
				string telefonos = tbTelefonos.Text;

				//Datos Laborales
				string empresaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbEmpresa, "sp_Inserttv_ClienteEmpresa");
				string cargoID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbCargo, "sp_Inserttv_ClienteCargo");
				string cuit = tbCuit.Text;
				string ivaID = cbIVA.SelectedValue.ToString();
				string calleEmpresa = tbCalleEmpresa.Text;
				string nroEmpresa = tbNroEmpresa.Text;
				string pisoEmpresa = tbPisoEmpresa.Text;
				string oficinaEmpresa = tbOficinaEmpresa.Text;
				string localidadEmpresaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidadEmpresa, "sp_InsertLocalidad", "sp_getAllLocalidads");
				string codPostEmpresa = tbCodPostEmpresa.Text;
				string provinciaEmpresaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvinciaEmpresa, "sp_InsertProvincia", "sp_getAllProvincias");
				string paisEmpresaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbPaisEmpresa, "sp_InsertPais", "sp_getAllPaiss");
				string eMailEmpresa = tbEmailEmpresa.Text;
				string telefonosEmpresa = tbTelefonosEmpresa.Text;

				//Otros datos
				string comentarios = tbComentarios.Text;
				string estadoID = cbEstado.SelectedValue.ToString();
				int clienteCorporativo = chkCorporativo.Checked ? 1 : 0;
				int clienteParticular = chkParticular.Checked ? 1 : 0;
				string puntajeManual = tbAjusteManual.Text;
				string ranking = tbRanking.Text;
				string registroBLOB = generarRegistroBLOB();


				SqlParameter[] param = new SqlParameter[36];
			
				param[0] = new SqlParameter("@ID", new System.Guid(id));
				param[1] = new SqlParameter("@apellido", apellido);
				param[2] = new SqlParameter("@nombres", nombres);
				param[3] = new SqlParameter("@dni", dni);
				param[4] = new SqlParameter("@calle", calle);
				param[5] = new SqlParameter("@nro", nro);
				param[6] = new SqlParameter("@piso", piso);
				param[7] = new SqlParameter("@depto", depto);
				param[8] = new SqlParameter("@localidadID", new System.Guid(localidadID));
				param[9] = new SqlParameter("@codPost", codPost);
				param[10] = new SqlParameter("@provinciaID", new System.Guid(provinciaID));
				param[11] = new SqlParameter("@paisID", new System.Guid(paisID));
				param[12] = new SqlParameter("@fechaNacimiento", fechaNacimiento);
				param[13] = new SqlParameter("@eMail", eMail);
				param[14] = new SqlParameter("@telefonos", telefonos);
				param[15] = new SqlParameter("@empresaID", new System.Guid(empresaID));
				param[16] = new SqlParameter("@cargoID", new System.Guid(cargoID));
				param[17] = new SqlParameter("@cuit", cuit);
				param[18] = new SqlParameter("@ivaID", new System.Guid(ivaID));
				param[19] = new SqlParameter("@calleEmpresa", calleEmpresa);
				param[20] = new SqlParameter("@nroEmpresa", nroEmpresa);
				param[21] = new SqlParameter("@pisoEmpresa", pisoEmpresa);
				param[22] = new SqlParameter("@oficinaEmpresa", oficinaEmpresa);
				param[23] = new SqlParameter("@localidadEmpresaID", new System.Guid(localidadEmpresaID));
				param[24] = new SqlParameter("@codPostEmpresa", codPostEmpresa);
				param[25] = new SqlParameter("@provinciaEmpresaID", new System.Guid(provinciaEmpresaID));
				param[26] = new SqlParameter("@paisEmpresaID", new System.Guid(paisEmpresaID));
				param[27] = new SqlParameter("@eMailEmpresa", eMailEmpresa);
				param[28] = new SqlParameter("@telefonosEmpresa", telefonosEmpresa);
				param[29] = new SqlParameter("@comentarios", comentarios);
				param[30] = new SqlParameter("@estadoID", new System.Guid(estadoID));
				param[31] = new SqlParameter("@clienteCorporativo", clienteCorporativo);
				param[32] = new SqlParameter("@clienteParticular", clienteParticular);
				param[33] = new SqlParameter("@puntajeManual", puntajeManual);
				param[34] = new SqlParameter("@ranking", ranking);
				param[35] = new SqlParameter("@registroBLOB", registroBLOB);
			
				while (true)
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarCliente", param);
						MessageBox.Show("Cliente modificado con éxito.", "Modificación de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cliente modificado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo modificar el Cliente. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Cliente. \r\n" + e.Message, false);
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

		//Genera el registro BLOB a partir de los textos de los controles
		private string generarRegistroBLOB()
		{
			try
			{
				string registroBLOB = tbApellido.Text.Trim() + " , ";
				registroBLOB += tbNombres.Text.Trim() + " , ";
				registroBLOB += tbDni.Text.Trim() + " , ";
				registroBLOB += tbCalle.Text.Trim() + " , ";
				registroBLOB += tbNro.Text.Trim() + " , ";
				registroBLOB += tbPiso.Text.Trim() + " , ";
				registroBLOB += tbDepto.Text.Trim() + " , ";
				registroBLOB += cbLocalidad.Text.Trim() + " , ";
				registroBLOB += tbCodPost.Text.Trim() + " , ";
				registroBLOB += cbProvincia.Text.Trim() + " , ";
				registroBLOB += cbPais.Text.Trim() + " , ";
				registroBLOB += dtpFechaNacimiento.Text.Trim() + " , ";
				registroBLOB += tbEmail.Text.Trim() + " , ";
				registroBLOB += tbTelefonos.Text.Trim() + " , ";
				registroBLOB += cbEmpresa.Text.Trim() + " , ";
				registroBLOB += cbCargo.Text.Trim() + " , ";
				registroBLOB += tbCuit.Text.Trim() + " , ";
				registroBLOB += cbIVA.Text.Trim() + " , ";
				registroBLOB += tbCalleEmpresa.Text.Trim() + " , ";
				registroBLOB += tbNroEmpresa.Text.Trim() + " , ";
				registroBLOB += tbPisoEmpresa.Text.Trim() + " , ";
				registroBLOB += tbOficinaEmpresa.Text.Trim() + " , ";
				registroBLOB += cbLocalidadEmpresa.Text.Trim() + " , ";
				registroBLOB += tbCodPostEmpresa.Text.Trim() + " , ";
				registroBLOB += cbProvinciaEmpresa.Text.Trim() + " , ";
				registroBLOB += cbPaisEmpresa.Text.Trim() + " , ";
				registroBLOB += tbEmailEmpresa.Text.Trim() + " , ";
				registroBLOB += tbTelefonosEmpresa.Text.Trim() + " , ";
				registroBLOB += tbComentarios.Text.Trim() + " , ";
				registroBLOB += cbEstado.Text.Trim() + " , ";

				return registroBLOB;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		private void tbAjusteManual_TextChanged(object sender, System.EventArgs e)
		{
			calcularPuntajes();
		}

		//Calcula los calores de los puntajes para el ranking
		private void calcularPuntajes()
		{
			try
			{
				//Primero valida el ajuste manual
				if (tbAjusteManual.Text.Trim()!="" && Utilidades.IsNumeric(tbAjusteManual.Text))
				{
					int puntajeManual = int.Parse(tbAjusteManual.Text.Trim());
					if (puntajeManual>10)
						puntajeManual = 10;
					if (puntajeManual<-10)
						puntajeManual = -10;
					tbAjusteManual.Text = puntajeManual.ToString();

					int ranking = int.Parse(tbPuntajeAutomatico.Text) + puntajeManual;
					if (ranking>10)
						ranking = 10;
					if (ranking<-0)
						ranking = 0;

					tbRanking.Text = ranking.ToString();
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

		private void butLimpiarDatosPersonales_Click(object sender, System.EventArgs e)
		{
			limpiarFormularioDatosPersonales();
		}

		private void butLimpiarDatosLaborales_Click(object sender, System.EventArgs e)
		{
			limpiarFormularioDatosLaborales();
		}

		private void limpiarFormulario()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				tbComentarios.Text = "";
				chkCorporativo.Checked = false;
				chkParticular.Checked = false;
				tbPuntajeAutomatico.Text = "0";
				tbAjusteManual.Text = "0";
				tbRanking.Text = "0";
				cbEstado.SelectedIndex = 0;
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		private void limpiarFormularioDatosPersonales()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				tbApellido.Text = "";
				tbNombres.Text = "";
				tbDni.Text = "";
				tbCalle.Text = "";
				tbNro.Text = "";
				tbPiso.Text = "";
				tbDepto.Text = "";
				cbLocalidad.SelectedIndex = -1;
				tbCodPost.Text = "";
				cbProvincia.SelectedIndex = -1;
				cbPais.SelectedIndex = -1;
				dtpFechaNacimiento.Value = new DateTime(1900,01,01);
				tbEmail.Text = "";
				tbTelefonos.Text = "";
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		private void limpiarFormularioDatosLaborales()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				cbEmpresa.SelectedIndex = -1;
				cbCargo.SelectedIndex = -1;
				tbNombres.Text = "";
				tbCuit.Text = "";
				cbIVA.SelectedIndex = -1;
				tbCalleEmpresa.Text = "";
				tbNroEmpresa.Text = "";
				tbPisoEmpresa.Text = "";
				tbOficinaEmpresa.Text = "";
				cbLocalidadEmpresa.SelectedIndex = -1;
				tbCodPostEmpresa.Text = "";
				cbProvinciaEmpresa.SelectedIndex = -1;
				cbPaisEmpresa.SelectedIndex = -1;
				tbEmailEmpresa.Text = "";
				tbTelefonosEmpresa.Text = "";
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
							DialogResult dr = MessageBox.Show("¿Desea borrar los Clientes seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Clientes...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarCliente", param);

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

		private void ucClienteConsulta_Load(object sender, System.EventArgs e)
		{
			tbPalabrasClaveB.Select();
		}

		private void butAceptar1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		//Esta region maneja los eventos para la grilla
		#region Maneja los eventos Dobleclick y return sobre las celdas de la grilla
		
		private bool estaFocoEnCelda = false;
		//Asigna el manejador de eventos a las celdas de la grilla
		private void asignarEventosGrilla(ref DataGrid dg)
		{
			foreach (DataGridTableStyle ts in dg.TableStyles)
				foreach (DataGridTextBoxColumn tbCol in ts.GridColumnStyles)
				{
					tbCol.TextBox.DoubleClick+=new EventHandler(TextBox_DoubleClick);
					tbCol.TextBox.GotFocus+=new EventHandler(TextBox_GotFocus);
					tbCol.TextBox.LostFocus+=new EventHandler(TextBox_LostFocus);
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
			if (this.estaFocoEnCelda)
			{
				if (this.consultaRapida)
					butAceptar1_Click(sender, e);
				else
					dgItems_DoubleClick(sender, e);
			}
		}
		private void ejecutarAccionEscape(object sender, EventArgs e)
		{
			if (this.consultaRapida)
			{
				DataTable dt = (DataTable)dgItems.DataSource;
				if (dt!=null)
					(dt).Rows.Clear(); //Borra los registros asi no selecciona el registro actual.
				butSalir_Click(sender, e);
				dt = null;
			}
		}

		private const int WM_KEYDOWN = 0x100;

		protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
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
								ejecutarAccionAceptar(new object(), new EventArgs());
								//DataGridCell newCell = new DataGridCell(dgItems.CurrentCell.RowNumber, dgItems.CurrentCell.ColumnNumber + 1);
								//dgItems.CurrentCell = newCell;
							}
							catch (Exception e)
							{}
							break;
						}
						case System.Windows.Forms.Keys.Escape:
							ejecutarAccionEscape(new object(), new EventArgs());
							break;
						default:
							//MessageBox.Show(keyData.ToString());
							break;
					}
					break;
				}
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		
		#endregion

		private void tbPalabrasClaveB_TextChanged(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		private void tbPalabrasClaveB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter ||
				e.KeyCode==Keys.Down)
				dgItems.Select();
		}

        private void butImprimir_Click(object sender, EventArgs e)
        {

        }

	}
}
