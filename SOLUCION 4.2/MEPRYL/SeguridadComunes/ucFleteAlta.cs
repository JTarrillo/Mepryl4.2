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
	/// Summary description for ucZonaAlta.
	/// </summary>
	public class ucFleteAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Label label18;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox clbZonas;
		private System.Windows.Forms.TextBox tbNombreFlete;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
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
		private System.Windows.Forms.TabPage tabPage2;
		private System.ComponentModel.IContainer components;

		public ucFleteAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucFleteAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.clbZonas = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.butGuardar = new System.Windows.Forms.Button();
			this.butSalir = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gbModificacionProveedores.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.tabControl1);
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(0, 32);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(816, 424);
			this.gbModificacionProveedores.TabIndex = 114;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.HotTrack = true;
			this.tabControl1.ImageList = this.imagenesTab;
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 320);
			this.tabControl1.TabIndex = 237;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cbIVA);
			this.tabPage1.Controls.Add(this.label33);
			this.tabPage1.Controls.Add(this.butLimpiarDatosLaborales);
			this.tabPage1.Controls.Add(this.tbTelefonosEmpresa);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.tbEmailEmpresa);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.tbCodPostEmpresa);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.cbPaisEmpresa);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.cbProvinciaEmpresa);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.cbLocalidadEmpresa);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.tbOficinaEmpresa);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.tbPisoEmpresa);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.tbNroEmpresa);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.tbCalleEmpresa);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.tbCuit);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.label14);
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.label37);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label38);
			this.tabPage1.Controls.Add(this.label39);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.label40);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Controls.Add(this.label41);
			this.tabPage1.Controls.Add(this.tbNombreFlete);
			this.tabPage1.Controls.Add(this.tbObservaciones);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.ImageIndex = 0;
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(792, 293);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Datos Empresa";
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
			this.butLimpiarDatosLaborales.Location = new System.Drawing.Point(672, 256);
			this.butLimpiarDatosLaborales.Name = "butLimpiarDatosLaborales";
			this.butLimpiarDatosLaborales.Size = new System.Drawing.Size(96, 24);
			this.butLimpiarDatosLaborales.TabIndex = 16;
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
			this.tbCuit.TabIndex = 2;
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
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.clbZonas);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.ImageIndex = 1;
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(792, 293);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Asignación de Zonas";
			this.tabPage2.Visible = false;
			// 
			// clbZonas
			// 
			this.clbZonas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.clbZonas.CheckOnClick = true;
			this.clbZonas.Location = new System.Drawing.Point(8, 24);
			this.clbZonas.Name = "clbZonas";
			this.clbZonas.Size = new System.Drawing.Size(368, 257);
			this.clbZonas.TabIndex = 236;
			this.clbZonas.BindingContext = this.BindingContext;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 235;
			this.label1.Text = "Zonas Asignadas";
			// 
			// imagenesTab
			// 
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(552, 376);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 17;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(680, 376);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 24);
			this.butSalir.TabIndex = 18;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Gray;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(816, 32);
			this.label18.TabIndex = 113;
			this.label18.Text = "     Alta de Fletes";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Orchid;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 115;
			this.pictureBox1.TabStop = false;
			// 
			// ucFleteAlta
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucFleteAlta";
			this.Size = new System.Drawing.Size(816, 456);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				clbZonas.BindingContext = this.BindingContext;
				UtilUI.llenarCheckedListBox(ref clbZonas, this.conexion, "sp_getAllZonas", "", "-1");

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

		private void limpiarFormulario()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				tbNombreFlete.Text = "";
				tbObservaciones.Text = "";
				
				clbZonas.Items.Clear();
				inicializarComponentes();

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
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Registro...", true);
				if (validarFormulario())
				{
					darAlta();
					limpiarFormularioDatosLaborales();
				}
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
			
				if (tbNombreFlete.Text.Trim()=="")
				{
					mensaje += "   - El Nombre de la Flete está vacío.\r\n";
					resultado = false;
				}
				else if (existeNombreFlete(tbNombreFlete.Text.Trim()))
				{
					mensaje += "   - El Nombre de la Flete '" + tbNombreFlete.Text.Trim() + "' ya existe. Utilice un nombre diferente.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Fletes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		private void limpiarFormularioDatosLaborales()
		{
			try
			{

				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				inicializarComponentes();
				tbNombreFlete.Text = "";
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

		//Verifica en la tabla de fletes si existe algun flete con el mismo nombre
		private bool existeNombreFlete(string nombreFlete)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
			
				param[0] = new SqlParameter("@nombreFlete", nombreFlete);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getFleteByNombre", param);

				bool resultado = false;
				if (dr.HasRows)
					resultado = true;

				dr.Close();

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
			try
			{
				//Obtiene los valores a insertar
				//Datos Laborales
				string cuit = tbCuit.Text;
				string ivaID = cbIVA.SelectedValue.ToString();
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

				//Datos
				string nombreFlete = tbNombreFlete.Text;
				string observaciones = tbObservaciones.Text;
			
				SqlParameter[] param = new SqlParameter[14];
			
				param[0] = new SqlParameter("@nombreFlete", nombreFlete);
				param[1] = new SqlParameter("@cuit", cuit);
				param[2] = new SqlParameter("@ivaID", new System.Guid(ivaID));
				param[3] = new SqlParameter("@calle", calle);
				param[4] = new SqlParameter("@nro", nro);
				param[5] = new SqlParameter("@piso", piso);
				param[6] = new SqlParameter("@oficina", oficina);
				param[7] = new SqlParameter("@localidadID", new System.Guid(localidadID));
				param[8] = new SqlParameter("@codPost", codPost);
				param[9] = new SqlParameter("@provinciaID", new System.Guid(provinciaID));
				param[10] = new SqlParameter("@paisID", new System.Guid(paisID));
				param[11] = new SqlParameter("@eMail", eMail);
				param[12] = new SqlParameter("@telefonos", telefonos);
				param[13] = new SqlParameter("@observaciones", observaciones);
			
				while (true)
				{
					try 
					{
						//Da alta al registro principal
						SqlDataReader drID = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoFlete", param);
						if (drID.HasRows)
						{
							//Da alta a las zonas asignadas
							drID.Read();
							
							DataTable dtZonas = (DataTable)clbZonas.DataSource;
							param = new SqlParameter[2];
							for (int i=0; i<dtZonas.Rows.Count; i++)
							{
								if (clbZonas.CheckedIndices.Contains(i))
								{
									param[0] = new SqlParameter("@fleteID", new Guid(drID["ID"].ToString()));
									param[1] = new SqlParameter("@zonaID", new Guid(dtZonas.Rows[i]["id"].ToString()));
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevaFleteZona", param);
								}
							}
							
							MessageBox.Show("Flete ingresado con éxito.", "Alta de Flete", MessageBoxButtons.OK, MessageBoxIcon.Information);
							limpiarFormularioDatosLaborales();
							UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Flete ingresado con éxito.", false);
						}
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo ingresar el Flete. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar el Flete. \r\n" + e.Message, false);
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

		
		//Limpia los campos del formulario
		private void limpiarCamposUnicos()
		{
			tbNombreFlete.Text = "";
			tbObservaciones.Text = "";
		}


		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		private void butLimpiarDatosLaborales_Click(object sender, System.EventArgs e)
		{
		
		}

	}
}
