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
	/// Summary description for ucClienteAlta.
	/// </summary>
	public class ucClienteAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ComboBox cbEmpresa;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cbCargo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCuit;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbCalleEmpresa;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbNroEmpresa;
		private System.Windows.Forms.TextBox tbPisoEmpresa;
		private System.Windows.Forms.TextBox tbOficinaEmpresa;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbLocalidadEmpresa;
		private System.Windows.Forms.ComboBox cbProvinciaEmpresa;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbPaisEmpresa;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbCodPostEmpresa;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbEmailEmpresa;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbTelefonos;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbCodPost;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox cbPais;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ComboBox cbProvincia;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox cbLocalidad;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbDepto;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox tbPiso;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox tbNro;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox tbCalle;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox tbDni;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox tbApellido;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbNombres;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
		private System.Windows.Forms.TextBox tbRanking;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox tbPuntajeAutomatico;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox tbAjusteManual;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkCorporativo;
		private System.Windows.Forms.CheckBox chkParticular;
		private System.Windows.Forms.ComboBox cbEstado;
		private System.Windows.Forms.ComboBox cbIVA;
		private System.Windows.Forms.Label label33;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.TextBox tbComentarios;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox tbTelefonosEmpresa;
		private System.Windows.Forms.Button butLimpiarDatosPersonales;
		private System.Windows.Forms.Button butLimpiarDatosLaborales;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
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
		private System.ComponentModel.IContainer components;
        private TextBox tbID;

        public bool consultaRapida = false;

		public ucClienteAlta()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucClienteAlta));
            this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butLimpiarDatosPersonales = new System.Windows.Forms.Button();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.tbNombres = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbTelefonos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbCodPost = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbPais = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbDepto = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbPiso = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbNro = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.butSalir = new System.Windows.Forms.Button();
            this.butGuardar = new System.Windows.Forms.Button();
            this.butLimpiar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.gbModificacionProveedores.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbModificacionProveedores
            // 
            this.gbModificacionProveedores.Controls.Add(this.label36);
            this.gbModificacionProveedores.Controls.Add(this.label35);
            this.gbModificacionProveedores.Controls.Add(this.groupBox1);
            this.gbModificacionProveedores.Controls.Add(this.tbComentarios);
            this.gbModificacionProveedores.Controls.Add(this.label34);
            this.gbModificacionProveedores.Controls.Add(this.label32);
            this.gbModificacionProveedores.Controls.Add(this.tbAjusteManual);
            this.gbModificacionProveedores.Controls.Add(this.label31);
            this.gbModificacionProveedores.Controls.Add(this.tbPuntajeAutomatico);
            this.gbModificacionProveedores.Controls.Add(this.label30);
            this.gbModificacionProveedores.Controls.Add(this.tbRanking);
            this.gbModificacionProveedores.Controls.Add(this.label29);
            this.gbModificacionProveedores.Controls.Add(this.tabControl1);
            this.gbModificacionProveedores.Controls.Add(this.butSalir);
            this.gbModificacionProveedores.Controls.Add(this.butGuardar);
            this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
            this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 40);
            this.gbModificacionProveedores.Name = "gbModificacionProveedores";
            this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 416);
            this.gbModificacionProveedores.TabIndex = 114;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkParticular);
            this.groupBox1.Controls.Add(this.chkCorporativo);
            this.groupBox1.Controls.Add(this.cbEstado);
            this.groupBox1.Location = new System.Drawing.Point(328, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 136);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Cliente";
            // 
            // chkParticular
            // 
            this.chkParticular.Location = new System.Drawing.Point(40, 104);
            this.chkParticular.Name = "chkParticular";
            this.chkParticular.Size = new System.Drawing.Size(104, 24);
            this.chkParticular.TabIndex = 20;
            this.chkParticular.Text = "Particular";
            // 
            // chkCorporativo
            // 
            this.chkCorporativo.Location = new System.Drawing.Point(40, 72);
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
            this.cbEstado.Location = new System.Drawing.Point(40, 32);
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
            this.tbComentarios.Size = new System.Drawing.Size(296, 136);
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
            this.tbAjusteManual.Validated += new System.EventHandler(this.tbAjusteManual_Validated);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImageList = this.imagenesTab;
            this.tabControl1.Location = new System.Drawing.Point(8, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 232);
            this.tabControl1.TabIndex = 1;
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
            this.tabPage1.Controls.Add(this.cbCargo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbEmpresa);
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
            this.tabPage1.ImageIndex = 7;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(776, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Empresa";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
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
            this.tbCuit.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(536, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 14);
            this.label15.TabIndex = 164;
            this.label15.Text = "CUIT";
            // 
            // cbCargo
            // 
            this.cbCargo.Location = new System.Drawing.Point(272, 24);
            this.cbCargo.MaxLength = 100;
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(232, 21);
            this.cbCargo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(272, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 14);
            this.label1.TabIndex = 162;
            this.label1.Text = "Cargo";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.Location = new System.Drawing.Point(8, 24);
            this.cbEmpresa.MaxLength = 100;
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(232, 21);
            this.cbEmpresa.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 14);
            this.label14.TabIndex = 160;
            this.label14.Text = "Empresa";
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
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(536, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 3;
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
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(536, 8);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(136, 14);
            this.label41.TabIndex = 164;
            this.label41.Text = "CUIT";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butLimpiarDatosPersonales);
            this.tabPage2.Controls.Add(this.dtpFechaNacimiento);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.tbNombres);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.tbApellido);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.tbTelefonos);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbEmail);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.tbCodPost);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.cbPais);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.cbProvincia);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.cbLocalidad);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.tbDepto);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.tbPiso);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.tbNro);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.tbCalle);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.tbDni);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.ImageIndex = 6;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(776, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos Personales";
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
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(272, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 14);
            this.label12.TabIndex = 210;
            this.label12.Text = "Teléfonos";
            // 
            // tbEmail
            // 
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmail.Location = new System.Drawing.Point(8, 168);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(232, 20);
            this.tbEmail.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 14);
            this.label13.TabIndex = 208;
            this.label13.Text = "E-Mail";
            // 
            // tbCodPost
            // 
            this.tbCodPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodPost.Location = new System.Drawing.Point(704, 72);
            this.tbCodPost.Name = "tbCodPost";
            this.tbCodPost.Size = new System.Drawing.Size(64, 20);
            this.tbCodPost.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(704, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 14);
            this.label16.TabIndex = 206;
            this.label16.Text = "Cod.Post.";
            // 
            // cbPais
            // 
            this.cbPais.Location = new System.Drawing.Point(272, 120);
            this.cbPais.MaxLength = 11;
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(232, 21);
            this.cbPais.TabIndex = 203;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(272, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 14);
            this.label17.TabIndex = 204;
            this.label17.Text = "Pais";
            // 
            // cbProvincia
            // 
            this.cbProvincia.Location = new System.Drawing.Point(8, 120);
            this.cbProvincia.MaxLength = 100;
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(232, 21);
            this.cbProvincia.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 14);
            this.label19.TabIndex = 202;
            this.label19.Text = "Provincia";
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.Location = new System.Drawing.Point(536, 72);
            this.cbLocalidad.MaxLength = 100;
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(160, 21);
            this.cbLocalidad.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(536, 56);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 14);
            this.label20.TabIndex = 200;
            this.label20.Text = "Localidad";
            // 
            // tbDepto
            // 
            this.tbDepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDepto.Location = new System.Drawing.Point(440, 72);
            this.tbDepto.Name = "tbDepto";
            this.tbDepto.Size = new System.Drawing.Size(64, 20);
            this.tbDepto.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(440, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 14);
            this.label21.TabIndex = 198;
            this.label21.Text = "Depto.";
            // 
            // tbPiso
            // 
            this.tbPiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPiso.Location = new System.Drawing.Point(360, 72);
            this.tbPiso.Name = "tbPiso";
            this.tbPiso.Size = new System.Drawing.Size(64, 20);
            this.tbPiso.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(360, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 14);
            this.label22.TabIndex = 196;
            this.label22.Text = "Piso";
            // 
            // tbNro
            // 
            this.tbNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNro.Location = new System.Drawing.Point(272, 72);
            this.tbNro.Name = "tbNro";
            this.tbNro.Size = new System.Drawing.Size(72, 20);
            this.tbNro.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(272, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 14);
            this.label23.TabIndex = 194;
            this.label23.Text = "Nro.";
            // 
            // tbCalle
            // 
            this.tbCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCalle.Location = new System.Drawing.Point(8, 72);
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.Size = new System.Drawing.Size(232, 20);
            this.tbCalle.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(136, 14);
            this.label24.TabIndex = 192;
            this.label24.Text = "Calle";
            // 
            // tbDni
            // 
            this.tbDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDni.Location = new System.Drawing.Point(536, 24);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(232, 20);
            this.tbDni.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(536, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(136, 14);
            this.label25.TabIndex = 190;
            this.label25.Text = "DNI";
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
            // butSalir
            // 
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(688, 384);
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
            this.butGuardar.Location = new System.Drawing.Point(560, 384);
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
            this.butLimpiar.Location = new System.Drawing.Point(688, 352);
            this.butLimpiar.Name = "butLimpiar";
            this.butLimpiar.Size = new System.Drawing.Size(96, 24);
            this.butLimpiar.TabIndex = 24;
            this.butLimpiar.Text = "&Limpiar";
            this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Green;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(816, 32);
            this.label18.TabIndex = 113;
            this.label18.Text = "     Alta de Clientes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Green;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // tbID
            // 
            this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbID.Location = new System.Drawing.Point(771, 3);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(29, 20);
            this.tbID.TabIndex = 116;
            this.tbID.Visible = false;
            // 
            // ucClienteAlta
            // 
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbModificacionProveedores);
            this.Controls.Add(this.label18);
            this.Name = "ucClienteAlta";
            this.Size = new System.Drawing.Size(816, 456);
            this.gbModificacionProveedores.ResumeLayout(false);
            this.gbModificacionProveedores.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes(string datos)
		{
			try
			{

				if (datos=="Personales" || datos=="")
				{
					//Datos Personales
					UtilUI.llenarCombo(ref cbLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
					UtilUI.llenarCombo(ref cbProvincia, this.conexion, "sp_getAllProvincias", "", -1);
					UtilUI.llenarCombo(ref cbPais, this.conexion, "sp_getAllPaiss", "", -1);
				}
				if (datos=="Laborales" || datos=="")
				{
					//Datos Laborales
					UtilUI.llenarCombo(ref cbEmpresa, this.conexion, "sp_getAlltv_ClienteEmpresas", " ", 0);
					UtilUI.llenarCombo(ref cbCargo, this.conexion, "sp_getAlltv_ClienteCargos", " ", 0);
					UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
					UtilUI.comboSeleccionarItemByIdentificador("I", ref cbIVA); //Selecciona Responsable Inscripto

					UtilUI.llenarCombo(ref cbLocalidadEmpresa, this.conexion, "sp_getAllLocalidads", "", -1);
					UtilUI.llenarCombo(ref cbProvinciaEmpresa, this.conexion, "sp_getAllProvincias", "", -1);
					UtilUI.llenarCombo(ref cbPaisEmpresa, this.conexion, "sp_getAllPaiss", "", -1);
				}
				UtilUI.llenarCombo(ref cbEstado, this.conexion, "sp_getAlltv_ClienteEstados", "", -1);
				cbEstado.SelectedIndex = 0;
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
				inicializarComponentes("Personales");
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
				inicializarComponentes("Laborales");
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
		private void tabPage1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Registro...", true);
			if (validarFormulario())
			{
					darAlta();
					limpiarFormulario();
					limpiarFormularioDatosLaborales();
					limpiarFormularioDatosPersonales();

                    //Si es consulta rápida cierra la ventana
                    if (this.consultaRapida)
                        ((Form)this.Parent).Close();
			}
			else
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
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
                else
                    UtilUI.comboSeleccionarItemByIdentificador("F", ref cbIVA);  //Si no hay empresa, el IVA es Consumidor Final

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
					MessageBox.Show(mensaje, "Alta de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			try
			{

				//Obtiene los valores a insertar
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


				SqlParameter[] param = new SqlParameter[35];
			
				param[0] = new SqlParameter("@apellido", apellido);
				param[1] = new SqlParameter("@nombres", nombres);
				param[2] = new SqlParameter("@dni", dni);
				param[3] = new SqlParameter("@calle", calle);
				param[4] = new SqlParameter("@nro", nro);
				param[5] = new SqlParameter("@piso", piso);
				param[6] = new SqlParameter("@depto", depto);
				param[7] = new SqlParameter("@localidadID", new System.Guid(localidadID));
				param[8] = new SqlParameter("@codPost", codPost);
				param[9] = new SqlParameter("@provinciaID", new System.Guid(provinciaID));
				param[10] = new SqlParameter("@paisID", new System.Guid(paisID));
				param[11] = new SqlParameter("@fechaNacimiento", fechaNacimiento);
				param[12] = new SqlParameter("@eMail", eMail);
				param[13] = new SqlParameter("@telefonos", telefonos);
				param[14] = new SqlParameter("@empresaID", new System.Guid(empresaID));
				param[15] = new SqlParameter("@cargoID", new System.Guid(cargoID));
				param[16] = new SqlParameter("@cuit", cuit);
				param[17] = new SqlParameter("@ivaID", new System.Guid(ivaID));
				param[18] = new SqlParameter("@calleEmpresa", calleEmpresa);
				param[19] = new SqlParameter("@nroEmpresa", nroEmpresa);
				param[20] = new SqlParameter("@pisoEmpresa", pisoEmpresa);
				param[21] = new SqlParameter("@oficinaEmpresa", oficinaEmpresa);
				param[22] = new SqlParameter("@localidadEmpresaID", new System.Guid(localidadEmpresaID));
				param[23] = new SqlParameter("@codPostEmpresa", codPostEmpresa);
				param[24] = new SqlParameter("@provinciaEmpresaID", new System.Guid(provinciaEmpresaID));
				param[25] = new SqlParameter("@paisEmpresaID", new System.Guid(paisEmpresaID));
				param[26] = new SqlParameter("@eMailEmpresa", eMailEmpresa);
				param[27] = new SqlParameter("@telefonosEmpresa", telefonosEmpresa);
				param[28] = new SqlParameter("@comentarios", comentarios);
				param[29] = new SqlParameter("@estadoID", new System.Guid(estadoID));
				param[30] = new SqlParameter("@clienteCorporativo", clienteCorporativo);
				param[31] = new SqlParameter("@clienteParticular", clienteParticular);
				param[32] = new SqlParameter("@puntajeManual", puntajeManual);
				param[33] = new SqlParameter("@ranking", ranking);
				param[34] = new SqlParameter("@registroBLOB", registroBLOB);
			
				while (true)
				{
					try 
					{
						SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoCliente", param);
                        dr.Read();
                        tbID.Text = dr["ID"].ToString();
                        dr.Close();
						MessageBox.Show("Cliente ingresado con éxito.", "Alta de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarCamposUnicos();
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cliente ingresado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo ingresar el Cliente. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar el Cliente. \r\n" + e.Message, false);
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

		//Limpia los campos del formulario
		private void limpiarCamposUnicos()
		{
			try
			{

				tbApellido.Text = "";
				tbNombres.Text = "";
				tbDni.Text = "";
				dtpFechaNacimiento.Value = new DateTime(1900,01,01);
				tbEmail.Text = "";
				tbTelefonos.Text = "";
				tbAjusteManual.Text = "0";
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
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

		private void tbAjusteManual_Validated(object sender, System.EventArgs e)
		{
			/*if (tbAjusteManual.Text.Trim()=="" || Utilidades.IsNumeric(tbAjusteManual.Text))
			{
				tbAjusteManual.Text = "0";
			}*/
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

        //Devuelve el ID de cliente nuevo
        public string getID()
        {
            string id = tbID.Text;  // Utilidades.ID_VACIO;
            return id;
        }
	}
}
