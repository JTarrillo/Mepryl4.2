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
	/// Summary description for ucMensajeAlta.
	/// </summary>
	public class ucMensajeAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label34;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		public string mensajeID = Utilidades.ID_VACIO;
		public string operacion = "";
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.TabControl tabDestinatarios;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox tbAsunto;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbPrioridad;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butQuitarTodoGrupo;
		private System.Windows.Forms.Button butAgregarTodoGrupo;
		private System.Windows.Forms.Button butQuitarGrupo;
		private System.Windows.Forms.Button butAgregarGrupo;
		private System.Windows.Forms.ListBox lbxGruposListados;
		private System.Windows.Forms.ListBox lbxGruposSeleccionados;
		private System.Windows.Forms.Button butQuitarTodoSucursal;
		private System.Windows.Forms.Button butAgregarTodoSucursal;
		private System.Windows.Forms.Button butQuitarSucursal;
		private System.Windows.Forms.Button butAgregarSucursal;
		private System.Windows.Forms.ListBox lbxSucursalesListadas;
		private System.Windows.Forms.ListBox lbxSucursalesSeleccionadas;
		private System.Windows.Forms.Button butQuitarTodoUsuario;
		private System.Windows.Forms.Button butAgregarTodoUsuario;
		private System.Windows.Forms.Button butQuitarUsuario;
		private System.Windows.Forms.Button butAgregarUsuario;
		private System.Windows.Forms.ListBox lbxUsuariosListados;
		private System.Windows.Forms.ListBox lbxUsuariosSeleccionados;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbDestino;
		private System.Windows.Forms.Button butEnviar;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TextBox tbCuerpo;
		private System.ComponentModel.IContainer components;

		public ucMensajeAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucMensajeAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.butEnviar = new System.Windows.Forms.Button();
			this.butSalir = new System.Windows.Forms.Button();
			this.tbDestino = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbPrioridad = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbAsunto = new System.Windows.Forms.TextBox();
			this.tbCuerpo = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.tabDestinatarios = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.butQuitarTodoUsuario = new System.Windows.Forms.Button();
			this.butAgregarTodoUsuario = new System.Windows.Forms.Button();
			this.butQuitarUsuario = new System.Windows.Forms.Button();
			this.butAgregarUsuario = new System.Windows.Forms.Button();
			this.lbxUsuariosListados = new System.Windows.Forms.ListBox();
			this.lbxUsuariosSeleccionados = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.butQuitarTodoGrupo = new System.Windows.Forms.Button();
			this.butAgregarTodoGrupo = new System.Windows.Forms.Button();
			this.butQuitarGrupo = new System.Windows.Forms.Button();
			this.butAgregarGrupo = new System.Windows.Forms.Button();
			this.lbxGruposListados = new System.Windows.Forms.ListBox();
			this.lbxGruposSeleccionados = new System.Windows.Forms.ListBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.butQuitarTodoSucursal = new System.Windows.Forms.Button();
			this.butAgregarTodoSucursal = new System.Windows.Forms.Button();
			this.butQuitarSucursal = new System.Windows.Forms.Button();
			this.butAgregarSucursal = new System.Windows.Forms.Button();
			this.lbxSucursalesListadas = new System.Windows.Forms.ListBox();
			this.lbxSucursalesSeleccionadas = new System.Windows.Forms.ListBox();
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gbModificacionProveedores.SuspendLayout();
			this.tabDestinatarios.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
			this.gbModificacionProveedores.Controls.Add(this.butEnviar);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.tbDestino);
			this.gbModificacionProveedores.Controls.Add(this.label6);
			this.gbModificacionProveedores.Controls.Add(this.label3);
			this.gbModificacionProveedores.Controls.Add(this.label2);
			this.gbModificacionProveedores.Controls.Add(this.cbPrioridad);
			this.gbModificacionProveedores.Controls.Add(this.label1);
			this.gbModificacionProveedores.Controls.Add(this.tbAsunto);
			this.gbModificacionProveedores.Controls.Add(this.tbCuerpo);
			this.gbModificacionProveedores.Controls.Add(this.label34);
			this.gbModificacionProveedores.Controls.Add(this.tabDestinatarios);
			this.gbModificacionProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(0, 32);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 424);
			this.gbModificacionProveedores.TabIndex = 114;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// butLimpiar
			// 
			this.butLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(688, 352);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 228;
			this.butLimpiar.Text = "&Limpiar";
			// 
			// butEnviar
			// 
			this.butEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butEnviar.Image = ((System.Drawing.Image)(resources.GetObject("butEnviar.Image")));
			this.butEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butEnviar.Location = new System.Drawing.Point(688, 240);
			this.butEnviar.Name = "butEnviar";
			this.butEnviar.Size = new System.Drawing.Size(96, 24);
			this.butEnviar.TabIndex = 226;
			this.butEnviar.Text = "&Enviar";
			this.butEnviar.Click += new System.EventHandler(this.butEnviar_Click);
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(688, 384);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 24);
			this.butSalir.TabIndex = 227;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click_1);
			// 
			// tbDestino
			// 
			this.tbDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDestino.Location = new System.Drawing.Point(72, 160);
			this.tbDestino.Multiline = true;
			this.tbDestino.Name = "tbDestino";
			this.tbDestino.ReadOnly = true;
			this.tbDestino.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDestino.Size = new System.Drawing.Size(600, 32);
			this.tbDestino.TabIndex = 225;
			this.tbDestino.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 224;
			this.label6.Text = "Destino:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 14);
			this.label3.TabIndex = 223;
			this.label3.Text = "Destino:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(560, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 14);
			this.label2.TabIndex = 222;
			this.label2.Text = "Prioridad";
			// 
			// cbPrioridad
			// 
			this.cbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPrioridad.Location = new System.Drawing.Point(560, 32);
			this.cbPrioridad.Name = "cbPrioridad";
			this.cbPrioridad.Size = new System.Drawing.Size(120, 21);
			this.cbPrioridad.TabIndex = 221;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 14);
			this.label1.TabIndex = 220;
			this.label1.Text = "Asunto:";
			// 
			// tbAsunto
			// 
			this.tbAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbAsunto.Location = new System.Drawing.Point(72, 200);
			this.tbAsunto.Name = "tbAsunto";
			this.tbAsunto.Size = new System.Drawing.Size(600, 20);
			this.tbAsunto.TabIndex = 219;
			this.tbAsunto.Text = "";
			// 
			// tbCuerpo
			// 
			this.tbCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCuerpo.Location = new System.Drawing.Point(16, 240);
			this.tbCuerpo.MaxLength = 8000;
			this.tbCuerpo.Multiline = true;
			this.tbCuerpo.Name = "tbCuerpo";
			this.tbCuerpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCuerpo.Size = new System.Drawing.Size(656, 168);
			this.tbCuerpo.TabIndex = 16;
			this.tbCuerpo.Text = "";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(16, 224);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(104, 14);
			this.label34.TabIndex = 218;
			this.label34.Text = "Mensaje";
			// 
			// tabDestinatarios
			// 
			this.tabDestinatarios.Controls.Add(this.tabPage1);
			this.tabDestinatarios.Controls.Add(this.tabPage2);
			this.tabDestinatarios.Controls.Add(this.tabPage3);
			this.tabDestinatarios.HotTrack = true;
			this.tabDestinatarios.ImageList = this.imagenesTab;
			this.tabDestinatarios.Location = new System.Drawing.Point(72, 16);
			this.tabDestinatarios.Name = "tabDestinatarios";
			this.tabDestinatarios.SelectedIndex = 0;
			this.tabDestinatarios.Size = new System.Drawing.Size(480, 128);
			this.tabDestinatarios.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.butQuitarTodoUsuario);
			this.tabPage1.Controls.Add(this.butAgregarTodoUsuario);
			this.tabPage1.Controls.Add(this.butQuitarUsuario);
			this.tabPage1.Controls.Add(this.butAgregarUsuario);
			this.tabPage1.Controls.Add(this.lbxUsuariosListados);
			this.tabPage1.Controls.Add(this.lbxUsuariosSeleccionados);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.ImageIndex = 0;
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(472, 101);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Usuarios";
			// 
			// butQuitarTodoUsuario
			// 
			this.butQuitarTodoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarTodoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butQuitarTodoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarTodoUsuario.Image")));
			this.butQuitarTodoUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarTodoUsuario.Location = new System.Drawing.Point(180, 76);
			this.butQuitarTodoUsuario.Name = "butQuitarTodoUsuario";
			this.butQuitarTodoUsuario.Size = new System.Drawing.Size(96, 16);
			this.butQuitarTodoUsuario.TabIndex = 233;
			this.butQuitarTodoUsuario.Text = "&Quitar Todo";
			this.butQuitarTodoUsuario.Click += new System.EventHandler(this.butQuitarTodoUsuario_Click);
			// 
			// butAgregarTodoUsuario
			// 
			this.butAgregarTodoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarTodoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butAgregarTodoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarTodoUsuario.Image")));
			this.butAgregarTodoUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarTodoUsuario.Location = new System.Drawing.Point(180, 52);
			this.butAgregarTodoUsuario.Name = "butAgregarTodoUsuario";
			this.butAgregarTodoUsuario.Size = new System.Drawing.Size(96, 16);
			this.butAgregarTodoUsuario.TabIndex = 232;
			this.butAgregarTodoUsuario.Text = "&Agregar Todo";
			this.butAgregarTodoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAgregarTodoUsuario.Click += new System.EventHandler(this.butAgregarTodoUsuario_Click);
			// 
			// butQuitarUsuario
			// 
			this.butQuitarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butQuitarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarUsuario.Image")));
			this.butQuitarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarUsuario.Location = new System.Drawing.Point(180, 28);
			this.butQuitarUsuario.Name = "butQuitarUsuario";
			this.butQuitarUsuario.Size = new System.Drawing.Size(96, 16);
			this.butQuitarUsuario.TabIndex = 231;
			this.butQuitarUsuario.Text = "&Quitar";
			this.butQuitarUsuario.Click += new System.EventHandler(this.butQuitarUsuario_Click);
			// 
			// butAgregarUsuario
			// 
			this.butAgregarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butAgregarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarUsuario.Image")));
			this.butAgregarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarUsuario.Location = new System.Drawing.Point(180, 4);
			this.butAgregarUsuario.Name = "butAgregarUsuario";
			this.butAgregarUsuario.Size = new System.Drawing.Size(96, 16);
			this.butAgregarUsuario.TabIndex = 230;
			this.butAgregarUsuario.Text = "&Agregar";
			this.butAgregarUsuario.Click += new System.EventHandler(this.butAgregarUsuario_Click);
			// 
			// lbxUsuariosListados
			// 
			this.lbxUsuariosListados.BackColor = System.Drawing.SystemColors.Window;
			this.lbxUsuariosListados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxUsuariosListados.Location = new System.Drawing.Point(288, 4);
			this.lbxUsuariosListados.Name = "lbxUsuariosListados";
			this.lbxUsuariosListados.Size = new System.Drawing.Size(176, 93);
			this.lbxUsuariosListados.TabIndex = 234;
			this.lbxUsuariosListados.DoubleClick += new System.EventHandler(this.lbxUsuariosListados_DoubleClick);
			// 
			// lbxUsuariosSeleccionados
			// 
			this.lbxUsuariosSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxUsuariosSeleccionados.Location = new System.Drawing.Point(8, 4);
			this.lbxUsuariosSeleccionados.Name = "lbxUsuariosSeleccionados";
			this.lbxUsuariosSeleccionados.Size = new System.Drawing.Size(160, 93);
			this.lbxUsuariosSeleccionados.TabIndex = 229;
			this.lbxUsuariosSeleccionados.DoubleClick += new System.EventHandler(this.lbxUsuariosSeleccionados_DoubleClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(316, -26);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 228;
			this.label5.Text = "No Posee";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(-132, -26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 14);
			this.label4.TabIndex = 227;
			this.label4.Text = "Posee";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.butQuitarTodoGrupo);
			this.tabPage2.Controls.Add(this.butAgregarTodoGrupo);
			this.tabPage2.Controls.Add(this.butQuitarGrupo);
			this.tabPage2.Controls.Add(this.butAgregarGrupo);
			this.tabPage2.Controls.Add(this.lbxGruposListados);
			this.tabPage2.Controls.Add(this.lbxGruposSeleccionados);
			this.tabPage2.ImageIndex = 1;
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(472, 101);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Grupos";
			// 
			// butQuitarTodoGrupo
			// 
			this.butQuitarTodoGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarTodoGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butQuitarTodoGrupo.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarTodoGrupo.Image")));
			this.butQuitarTodoGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarTodoGrupo.Location = new System.Drawing.Point(180, 76);
			this.butQuitarTodoGrupo.Name = "butQuitarTodoGrupo";
			this.butQuitarTodoGrupo.Size = new System.Drawing.Size(96, 16);
			this.butQuitarTodoGrupo.TabIndex = 231;
			this.butQuitarTodoGrupo.Text = "&Quitar Todo";
			this.butQuitarTodoGrupo.Click += new System.EventHandler(this.butQuitarTodoGrupo_Click);
			// 
			// butAgregarTodoGrupo
			// 
			this.butAgregarTodoGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarTodoGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butAgregarTodoGrupo.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarTodoGrupo.Image")));
			this.butAgregarTodoGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarTodoGrupo.Location = new System.Drawing.Point(180, 52);
			this.butAgregarTodoGrupo.Name = "butAgregarTodoGrupo";
			this.butAgregarTodoGrupo.Size = new System.Drawing.Size(96, 16);
			this.butAgregarTodoGrupo.TabIndex = 230;
			this.butAgregarTodoGrupo.Text = "&Agregar Todo";
			this.butAgregarTodoGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAgregarTodoGrupo.Click += new System.EventHandler(this.butAgregarTodoGrupo_Click);
			// 
			// butQuitarGrupo
			// 
			this.butQuitarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butQuitarGrupo.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarGrupo.Image")));
			this.butQuitarGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarGrupo.Location = new System.Drawing.Point(180, 28);
			this.butQuitarGrupo.Name = "butQuitarGrupo";
			this.butQuitarGrupo.Size = new System.Drawing.Size(96, 16);
			this.butQuitarGrupo.TabIndex = 229;
			this.butQuitarGrupo.Text = "&Quitar";
			this.butQuitarGrupo.Click += new System.EventHandler(this.butQuitarGrupo_Click);
			// 
			// butAgregarGrupo
			// 
			this.butAgregarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butAgregarGrupo.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarGrupo.Image")));
			this.butAgregarGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarGrupo.Location = new System.Drawing.Point(180, 4);
			this.butAgregarGrupo.Name = "butAgregarGrupo";
			this.butAgregarGrupo.Size = new System.Drawing.Size(96, 16);
			this.butAgregarGrupo.TabIndex = 228;
			this.butAgregarGrupo.Text = "&Agregar";
			this.butAgregarGrupo.Click += new System.EventHandler(this.butAgregarGrupo_Click);
			// 
			// lbxGruposListados
			// 
			this.lbxGruposListados.BackColor = System.Drawing.SystemColors.Window;
			this.lbxGruposListados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxGruposListados.Location = new System.Drawing.Point(288, 4);
			this.lbxGruposListados.Name = "lbxGruposListados";
			this.lbxGruposListados.Size = new System.Drawing.Size(176, 93);
			this.lbxGruposListados.TabIndex = 232;
			this.lbxGruposListados.DoubleClick += new System.EventHandler(this.lbxGruposListados_DoubleClick);
			// 
			// lbxGruposSeleccionados
			// 
			this.lbxGruposSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxGruposSeleccionados.Location = new System.Drawing.Point(8, 4);
			this.lbxGruposSeleccionados.Name = "lbxGruposSeleccionados";
			this.lbxGruposSeleccionados.Size = new System.Drawing.Size(160, 93);
			this.lbxGruposSeleccionados.TabIndex = 227;
			this.lbxGruposSeleccionados.DoubleClick += new System.EventHandler(this.lbxGruposSeleccionados_DoubleClick);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.butQuitarTodoSucursal);
			this.tabPage3.Controls.Add(this.butAgregarTodoSucursal);
			this.tabPage3.Controls.Add(this.butQuitarSucursal);
			this.tabPage3.Controls.Add(this.butAgregarSucursal);
			this.tabPage3.Controls.Add(this.lbxSucursalesListadas);
			this.tabPage3.Controls.Add(this.lbxSucursalesSeleccionadas);
			this.tabPage3.ImageIndex = 2;
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(472, 101);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Sucursales";
			// 
			// butQuitarTodoSucursal
			// 
			this.butQuitarTodoSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarTodoSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butQuitarTodoSucursal.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarTodoSucursal.Image")));
			this.butQuitarTodoSucursal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarTodoSucursal.Location = new System.Drawing.Point(180, 76);
			this.butQuitarTodoSucursal.Name = "butQuitarTodoSucursal";
			this.butQuitarTodoSucursal.Size = new System.Drawing.Size(96, 16);
			this.butQuitarTodoSucursal.TabIndex = 231;
			this.butQuitarTodoSucursal.Text = "&Quitar Todo";
			this.butQuitarTodoSucursal.Click += new System.EventHandler(this.butQuitarTodoSucursal_Click);
			// 
			// butAgregarTodoSucursal
			// 
			this.butAgregarTodoSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarTodoSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butAgregarTodoSucursal.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarTodoSucursal.Image")));
			this.butAgregarTodoSucursal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarTodoSucursal.Location = new System.Drawing.Point(180, 52);
			this.butAgregarTodoSucursal.Name = "butAgregarTodoSucursal";
			this.butAgregarTodoSucursal.Size = new System.Drawing.Size(96, 16);
			this.butAgregarTodoSucursal.TabIndex = 230;
			this.butAgregarTodoSucursal.Text = "&Agregar Todo";
			this.butAgregarTodoSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAgregarTodoSucursal.Click += new System.EventHandler(this.butAgregarTodoSucursal_Click);
			// 
			// butQuitarSucursal
			// 
			this.butQuitarSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butQuitarSucursal.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarSucursal.Image")));
			this.butQuitarSucursal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarSucursal.Location = new System.Drawing.Point(180, 28);
			this.butQuitarSucursal.Name = "butQuitarSucursal";
			this.butQuitarSucursal.Size = new System.Drawing.Size(96, 16);
			this.butQuitarSucursal.TabIndex = 229;
			this.butQuitarSucursal.Text = "&Quitar";
			this.butQuitarSucursal.Click += new System.EventHandler(this.butQuitarSucursal_Click);
			// 
			// butAgregarSucursal
			// 
			this.butAgregarSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butAgregarSucursal.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarSucursal.Image")));
			this.butAgregarSucursal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarSucursal.Location = new System.Drawing.Point(180, 4);
			this.butAgregarSucursal.Name = "butAgregarSucursal";
			this.butAgregarSucursal.Size = new System.Drawing.Size(96, 16);
			this.butAgregarSucursal.TabIndex = 228;
			this.butAgregarSucursal.Text = "&Agregar";
			this.butAgregarSucursal.Click += new System.EventHandler(this.butAgregarSucursal_Click);
			// 
			// lbxSucursalesListadas
			// 
			this.lbxSucursalesListadas.BackColor = System.Drawing.SystemColors.Window;
			this.lbxSucursalesListadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxSucursalesListadas.Location = new System.Drawing.Point(288, 4);
			this.lbxSucursalesListadas.Name = "lbxSucursalesListadas";
			this.lbxSucursalesListadas.Size = new System.Drawing.Size(176, 93);
			this.lbxSucursalesListadas.TabIndex = 232;
			this.lbxSucursalesListadas.DoubleClick += new System.EventHandler(this.lbxSucursalesListadas_DoubleClick);
			// 
			// lbxSucursalesSeleccionadas
			// 
			this.lbxSucursalesSeleccionadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxSucursalesSeleccionadas.Location = new System.Drawing.Point(8, 4);
			this.lbxSucursalesSeleccionadas.Name = "lbxSucursalesSeleccionadas";
			this.lbxSucursalesSeleccionadas.Size = new System.Drawing.Size(160, 93);
			this.lbxSucursalesSeleccionadas.TabIndex = 227;
			this.lbxSucursalesSeleccionadas.DoubleClick += new System.EventHandler(this.lbxSucursalesSeleccionadas_DoubleClick);
			// 
			// imagenesTab
			// 
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.SeaGreen;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(800, 32);
			this.label18.TabIndex = 113;
			this.label18.Text = "     Nuevo Mensaje";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.SeaGreen;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 115;
			this.pictureBox1.TabStop = false;
			// 
			// ucMensajeAlta
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucMensajeAlta";
			this.Size = new System.Drawing.Size(800, 456);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.tabDestinatarios.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				UtilUI.llenarCombo(ref cbPrioridad, this.conexion, "sp_getAlltv_MensajePrioridad", "", -1);
				UtilUI.comboSeleccionarItemByIdentificador("NORMAL", ref cbPrioridad);

				UtilUI.llenarListBox(ref lbxUsuariosSeleccionados, this.conexion, "sp_getAllUsuarios", "", -1);
				((DataTable)lbxUsuariosSeleccionados.DataSource).Rows.Clear();
				UtilUI.llenarListBox(ref lbxUsuariosListados, this.conexion, "sp_getAllUsuarios", "", -1);
				lbxUsuariosListados.SelectedIndex = 0;

				UtilUI.llenarListBox(ref lbxGruposSeleccionados, this.conexion, "sp_getAllPerfils", "", -1);
				((DataTable)lbxGruposSeleccionados.DataSource).Rows.Clear();
				UtilUI.llenarListBox(ref lbxGruposListados, this.conexion, "sp_getAllPerfils", "", -1);
				lbxGruposListados.SelectedIndex = 0;

				UtilUI.llenarListBox(ref lbxSucursalesSeleccionadas, this.conexion, "sp_getAllSucursals", "", -1);
				((DataTable)lbxSucursalesSeleccionadas.DataSource).Rows.Clear();
				UtilUI.llenarListBox(ref lbxSucursalesListadas, this.conexion, "sp_getAllSucursals", "", -1);
				lbxSucursalesListadas.SelectedIndex = 0;

				//Si es llamado desde un mensaje anterior, carga los datos del mensaje anterior
				if (this.mensajeID!="0" && this.operacion!="")
				{
					cargarMensajeAnterior();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Carga desde la base de datos el mensaje indicado
		private void cargarMensajeAnterior()
		{
			try
			{
				SqlParameter[] param = null;
				//Carga los datos del mensaje
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@mensajeID", new System.Guid(this.mensajeID));
				SqlDataReader drMensaje = SqlHelper.ExecuteReader(this.conexion, "sp_getMensajeByID", param);
			
				if (drMensaje.HasRows)
				{
					//Carga los campos del Mensaje
					drMensaje.Read();
					tbAsunto.Text = "Re: " + drMensaje["Asunto"].ToString();
					tbCuerpo.Text = "\r\n\r\n" + (new String('-', 50)) + "Mensaje Anterior" + (new String('-', 50)) + "\r\n" +
						"Fecha: " + drMensaje["Fecha"].ToString() + "\r\n" +
						"Enviado por: " + drMensaje["Enviado por"].ToString() + "\r\n\r\n" +
						drMensaje["Mensaje"].ToString();
					cbPrioridad.SelectedValue = drMensaje["prioridadID"].ToString();
					string usuarioEmisorID = drMensaje["usuarioEmisorID"].ToString();
					if (operacion=="RESPONDER")
					{
						//Carga solo al emisor como destinatario
						ponerUsuarioEmisorComoDestino(usuarioEmisorID);
					}
					else if (operacion=="RESPONDER_A_TODOS")
					{
						//Carga al emisor y a todos los que fueron copiados como destinatarios.
						UtilUI.llenarListBox(ref lbxUsuariosSeleccionados, this.conexion, "sp_getMensajeDestinoUsuarioByPosee", "", -1, param);
						UtilUI.llenarListBox(ref lbxUsuariosListados, this.conexion, "sp_getMensajeDestinoUsuarioByNoPosee", "", -1, param);
					
						UtilUI.llenarListBox(ref lbxGruposSeleccionados, this.conexion, "sp_getMensajeDestinoGrupoByPosee", "", -1, param);
						UtilUI.llenarListBox(ref lbxGruposListados, this.conexion, "sp_getMensajeDestinoGrupoByNoPosee", "", -1, param);

						UtilUI.llenarListBox(ref lbxSucursalesSeleccionadas, this.conexion, "sp_getMensajeDestinoSucursalByPosee", "", -1, param);
						UtilUI.llenarListBox(ref lbxSucursalesListadas, this.conexion, "sp_getMensajeDestinoSucursalByNoPosee", "", -1, param);

						ponerUsuarioEmisorComoDestino(usuarioEmisorID);
					}
					else if (operacion=="REENVIAR")
					{
					}
					armarCadenaDestino();
					drMensaje.Close();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void ponerUsuarioEmisorComoDestino(string usuarioEmisorID)
		{
			try
			{
				DataTable dt = (DataTable)lbxUsuariosListados.DataSource;
				bool encontrado = false;
				for (int i=0; i<dt.Rows.Count; i++)
				{
					if (dt.Rows[i]["id"].ToString()==usuarioEmisorID.ToString())
					{
						encontrado = true;
						break;
					}
				}
				if (encontrado)
				{
					lbxUsuariosListados.SelectedValue = usuarioEmisorID;
					moverItem(ref lbxUsuariosListados, ref lbxUsuariosSeleccionados);
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void limpiarFormulario()
		{/*
			UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
			tbComentarios.Text = "";
			chkCorporativo.Checked = false;
			chkParticular.Checked = false;
			tbPuntajeAutomatico.Text = "0";
			tbAjusteManual.Text = "0";
			tbRanking.Text = "0";
			cbEstado.SelectedIndex = 0;
			UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Listo.", false);*/
		}



		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}


		private bool validarFormulario()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;
			
				if (tbDestino.Text.Trim()=="")
				{
					mensaje += "   - Debe indicar el destino de su mensaje.\r\n";
					resultado = false;
				}
				if (tbAsunto.Text.Trim()=="")
				{
					mensaje += "   - Debe escribir un asunto para su mensaje.\r\n";
					resultado = false;
				}
				if (tbCuerpo.Text.Trim()=="")
				{
					mensaje += "   - Debe escribir un mensaje.\r\n";
					resultado = false;
				}


				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Nuevo Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}


		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		

		private void butAgregarUsuario_Click(object sender, System.EventArgs e)
		{
			moverItem(ref lbxUsuariosListados, ref lbxUsuariosSeleccionados);
		}
		private void moverItem(ref ListBox lbxOrigen, ref ListBox lbxDestino)
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", true);
				DataTable dtOrigen = (DataTable)lbxOrigen.DataSource;
				if (dtOrigen.Rows.Count>0)
				{
					int selectedIndex = 0;
					if (lbxOrigen.SelectedIndex>-1)
						selectedIndex = lbxOrigen.SelectedIndex;

					DataTable dtDestino = (DataTable)lbxDestino.DataSource;
					DataRow row = dtDestino.NewRow();
					row["id"] = dtOrigen.Rows[selectedIndex]["id"];
					row["descripcion"] = dtOrigen.Rows[selectedIndex]["descripcion"];
					dtDestino.Rows.Add(row);
					dtDestino.AcceptChanges();

					dtOrigen.Rows[selectedIndex].Delete();
					dtOrigen.AcceptChanges();

				}
				//Arma la cadena Destino;
				armarCadenaDestino();
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butQuitarUsuario_Click(object sender, System.EventArgs e)
		{
			moverItem(ref lbxUsuariosSeleccionados, ref lbxUsuariosListados);
		}

		private void moverTodo(ref ListBox lbxOrigen, ref ListBox lbxDestino)
		{
			try
			{
				DataTable dtOrigen = (DataTable)lbxOrigen.DataSource;
				while (dtOrigen.Rows.Count>0)
				{
					lbxOrigen.SelectedIndex = 0;

					moverItem(ref lbxOrigen, ref lbxDestino);
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butAgregarTodoUsuario_Click(object sender, System.EventArgs e)
		{
			moverTodo(ref lbxUsuariosListados, ref lbxUsuariosSeleccionados);
		}

		private void butQuitarTodoUsuario_Click(object sender, System.EventArgs e)
		{
			moverTodo(ref lbxUsuariosSeleccionados, ref lbxUsuariosListados);
		}

		private void butAgregarGrupo_Click(object sender, System.EventArgs e)
		{
			moverItem(ref lbxGruposListados, ref lbxGruposSeleccionados);
		}

		private void butQuitarGrupo_Click(object sender, System.EventArgs e)
		{
			moverItem(ref lbxGruposSeleccionados, ref lbxGruposListados);
		}

		private void butAgregarTodoGrupo_Click(object sender, System.EventArgs e)
		{
			moverTodo(ref lbxGruposListados, ref lbxGruposSeleccionados);
		}

		private void butQuitarTodoGrupo_Click(object sender, System.EventArgs e)
		{
			moverTodo(ref lbxGruposSeleccionados, ref lbxGruposListados);
		}

		private void butAgregarSucursal_Click(object sender, System.EventArgs e)
		{
			moverItem(ref lbxSucursalesListadas, ref lbxSucursalesSeleccionadas);
		}

		private void butQuitarSucursal_Click(object sender, System.EventArgs e)
		{
			moverItem(ref lbxSucursalesSeleccionadas, ref lbxSucursalesListadas);
		}

		private void butAgregarTodoSucursal_Click(object sender, System.EventArgs e)
		{
			moverTodo(ref lbxSucursalesListadas, ref lbxSucursalesSeleccionadas);
		}

		private void butQuitarTodoSucursal_Click(object sender, System.EventArgs e)
		{
			moverTodo(ref lbxSucursalesSeleccionadas, ref lbxSucursalesListadas);
		}

		private void lbxUsuariosSeleccionados_DoubleClick(object sender, System.EventArgs e)
		{
			moverItem(ref lbxUsuariosSeleccionados, ref lbxUsuariosListados);
		}

		private void lbxUsuariosListados_DoubleClick(object sender, System.EventArgs e)
		{
			moverItem(ref lbxUsuariosListados, ref lbxUsuariosSeleccionados);
		}

		private void lbxGruposSeleccionados_DoubleClick(object sender, System.EventArgs e)
		{
			moverItem(ref lbxGruposSeleccionados, ref lbxGruposListados);
		}

		private void lbxGruposListados_DoubleClick(object sender, System.EventArgs e)
		{
			moverItem(ref lbxGruposListados, ref lbxGruposSeleccionados);
		}

		private void lbxSucursalesSeleccionadas_DoubleClick(object sender, System.EventArgs e)
		{
			moverItem(ref lbxSucursalesSeleccionadas, ref lbxSucursalesListadas);
		}

		private void lbxSucursalesListadas_DoubleClick(object sender, System.EventArgs e)
		{
			moverItem(ref lbxSucursalesListadas, ref lbxSucursalesSeleccionadas);
		}

		private void armarCadenaDestino()
		{
			try
			{
				string coma = "";
				string cadena = "";
				int i = 0;
			
				//Recorre los usuarios
				DataTable dt = (DataTable)lbxUsuariosSeleccionados.DataSource;
				for (i=0; i<dt.Rows.Count; i++)
				{
					cadena += dt.Rows[i]["descripcion"].ToString() + "; ";
				}

				//Recorre los grupos
				dt = (DataTable)lbxGruposSeleccionados.DataSource;
				for (i=0; i<dt.Rows.Count; i++)
				{
					cadena += dt.Rows[i]["descripcion"].ToString() + "; ";
				}

				//Recorre las sucursales
				dt = (DataTable)lbxSucursalesSeleccionadas.DataSource;
				for (i=0; i<dt.Rows.Count; i++)
				{
					cadena += dt.Rows[i]["descripcion"].ToString() + "; ";
				}

				tbDestino.Text = cadena;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSalir_Click_1(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butEnviar_Click(object sender, System.EventArgs e)
		{
			enviarMensaje();
		}

		//Prepara y envia el mensaje
		private void enviarMensaje()
		{
			try 
			{
				if (validarFormulario())
				{
					SqlParameter[] param = new SqlParameter[4];
					param[0] = new SqlParameter("@usuarioEmisorID", new System.Guid(this.configuracion.usuario.id));
					param[1] = new SqlParameter("@prioridadID", new System.Guid(cbPrioridad.SelectedValue.ToString()));
					param[2] = new SqlParameter("@asunto", tbAsunto.Text);
					param[3] = new SqlParameter("@cuerpo", tbCuerpo.Text);

					//Inserta el Mensaje
					SqlDataReader drMensaje = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoMensaje", param);
					drMensaje.Read();

					//Inserta los usuarios
					DataTable dt = (DataTable)lbxUsuariosSeleccionados.DataSource;
					for (int i = 0; i<dt.Rows.Count; i++)
					{
						param = new SqlParameter[2];
						param[0] = new SqlParameter("@mensajeID", new System.Guid(drMensaje["id"].ToString()));
						param[1] = new SqlParameter("@usuarioID", new System.Guid(dt.Rows[i]["id"].ToString()));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertMensajeDestinoUsuario", param);
					}

					//Inserta los grupos
					dt = (DataTable)lbxGruposSeleccionados.DataSource;
					for (int i = 0; i<dt.Rows.Count; i++)
					{
						param = new SqlParameter[2];
						param[0] = new SqlParameter("@mensajeID", new System.Guid(drMensaje["id"].ToString()));
						param[1] = new SqlParameter("@grupoID", new System.Guid(dt.Rows[i]["id"].ToString()));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertMensajeDestinoGrupo", param);
					}

					//Inserta las sucursales
					dt = (DataTable)lbxSucursalesSeleccionadas.DataSource;
					for (int i = 0; i<dt.Rows.Count; i++)
					{
						param = new SqlParameter[2];
						param[0] = new SqlParameter("@mensajeID", new System.Guid(drMensaje["id"].ToString()));
						param[1] = new SqlParameter("@sucursalID", new System.Guid(dt.Rows[i]["id"].ToString()));
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertMensajeDestinoSucursal", param);
					}

					//Inserta los usuarios para MensajeLeido
					param = new SqlParameter[1];
					param[0] = new SqlParameter("@mensajeID", new System.Guid(drMensaje["id"].ToString()));
					SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertMensajeLeidoUsuarios", param);

					MessageBox.Show("Mensaje enviado con éxito.", "Enviar Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

					limpiarCamposUnicos();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
		

		private void limpiarCamposUnicos()
		{
			tbAsunto.Text = "";
			tbCuerpo.Text = "";
		}

	}
}
