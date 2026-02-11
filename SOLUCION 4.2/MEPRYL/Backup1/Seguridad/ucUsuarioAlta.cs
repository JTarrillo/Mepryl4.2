using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Seguridad
{
	/// <summary>
	/// Summary description for ucUsuarioAlta.
	/// </summary>
	public class ucUsuarioAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbApellido;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbNombres;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label34;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.TextBox tbComentarios;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox lbxPosee;
		private System.Windows.Forms.ListBox lbxNoPosee;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button butAgregar;
		private System.Windows.Forms.Button butQuitar;
		private System.Windows.Forms.Button butAgregarTodo;
		private System.Windows.Forms.Button butQuitarTodo;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.ComboBox cbSucursal;
		private System.Windows.Forms.TextBox tbClave;
		private System.Windows.Forms.TextBox tbNombreUsuario;
		private System.ComponentModel.IContainer components;

		public ucUsuarioAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucUsuarioAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.butQuitarTodo = new System.Windows.Forms.Button();
			this.butAgregarTodo = new System.Windows.Forms.Button();
			this.butQuitar = new System.Windows.Forms.Button();
			this.butAgregar = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lbxNoPosee = new System.Windows.Forms.ListBox();
			this.lbxPosee = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbClave = new System.Windows.Forms.TextBox();
			this.tbNombreUsuario = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbSucursal = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.tbApellido = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbNombres = new System.Windows.Forms.TextBox();
			this.tbComentarios = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.butSalir = new System.Windows.Forms.Button();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gbModificacionProveedores.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.groupBox3);
			this.gbModificacionProveedores.Controls.Add(this.groupBox2);
			this.gbModificacionProveedores.Controls.Add(this.groupBox1);
			this.gbModificacionProveedores.Controls.Add(this.tbComentarios);
			this.gbModificacionProveedores.Controls.Add(this.label34);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 416);
			this.gbModificacionProveedores.TabIndex = 114;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(560, 384);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 3;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.butQuitarTodo);
			this.groupBox3.Controls.Add(this.butAgregarTodo);
			this.groupBox3.Controls.Add(this.butQuitar);
			this.groupBox3.Controls.Add(this.butAgregar);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.lbxNoPosee);
			this.groupBox3.Controls.Add(this.lbxPosee);
			this.groupBox3.Location = new System.Drawing.Point(8, 136);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 176);
			this.groupBox3.TabIndex = 227;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Perfil(es) del Usuario";
			// 
			// butQuitarTodo
			// 
			this.butQuitarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarTodo.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarTodo.Image")));
			this.butQuitarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarTodo.Location = new System.Drawing.Point(344, 128);
			this.butQuitarTodo.Name = "butQuitarTodo";
			this.butQuitarTodo.Size = new System.Drawing.Size(96, 24);
			this.butQuitarTodo.TabIndex = 4;
			this.butQuitarTodo.Text = "&Quitar Todo";
			this.butQuitarTodo.Click += new System.EventHandler(this.butQuitarTodo_Click);
			// 
			// butAgregarTodo
			// 
			this.butAgregarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarTodo.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarTodo.Image")));
			this.butAgregarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregarTodo.Location = new System.Drawing.Point(344, 104);
			this.butAgregarTodo.Name = "butAgregarTodo";
			this.butAgregarTodo.Size = new System.Drawing.Size(96, 24);
			this.butAgregarTodo.TabIndex = 3;
			this.butAgregarTodo.Text = "&Agregar Todo";
			this.butAgregarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAgregarTodo.Click += new System.EventHandler(this.butAgregarTodo_Click);
			// 
			// butQuitar
			// 
			this.butQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitar.Image = ((System.Drawing.Image)(resources.GetObject("butQuitar.Image")));
			this.butQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitar.Location = new System.Drawing.Point(344, 64);
			this.butQuitar.Name = "butQuitar";
			this.butQuitar.Size = new System.Drawing.Size(96, 24);
			this.butQuitar.TabIndex = 2;
			this.butQuitar.Text = "&Quitar";
			this.butQuitar.Click += new System.EventHandler(this.butQuitar_Click);
			// 
			// butAgregar
			// 
			this.butAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregar.Image = ((System.Drawing.Image)(resources.GetObject("butAgregar.Image")));
			this.butAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAgregar.Location = new System.Drawing.Point(344, 40);
			this.butAgregar.Name = "butAgregar";
			this.butAgregar.Size = new System.Drawing.Size(96, 24);
			this.butAgregar.TabIndex = 1;
			this.butAgregar.Text = "&Agregar";
			this.butAgregar.Click += new System.EventHandler(this.butAgregar_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(480, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 220;
			this.label5.Text = "No Posee";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 14);
			this.label4.TabIndex = 219;
			this.label4.Text = "Posee";
			// 
			// lbxNoPosee
			// 
			this.lbxNoPosee.BackColor = System.Drawing.SystemColors.Window;
			this.lbxNoPosee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxNoPosee.Location = new System.Drawing.Point(480, 40);
			this.lbxNoPosee.Name = "lbxNoPosee";
			this.lbxNoPosee.Size = new System.Drawing.Size(272, 106);
			this.lbxNoPosee.TabIndex = 5;
			this.lbxNoPosee.DoubleClick += new System.EventHandler(this.lbxNoPosee_DoubleClick);
			// 
			// lbxPosee
			// 
			this.lbxPosee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxPosee.Location = new System.Drawing.Point(32, 40);
			this.lbxPosee.Name = "lbxPosee";
			this.lbxPosee.Size = new System.Drawing.Size(272, 106);
			this.lbxPosee.TabIndex = 0;
			this.lbxPosee.DoubleClick += new System.EventHandler(this.lbxPosee_DoubleClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.tbClave);
			this.groupBox2.Controls.Add(this.tbNombreUsuario);
			this.groupBox2.Location = new System.Drawing.Point(464, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(328, 112);
			this.groupBox2.TabIndex = 226;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Identificación";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 14);
			this.label3.TabIndex = 222;
			this.label3.Text = "Nombre de Usuario";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 14);
			this.label2.TabIndex = 224;
			this.label2.Text = "Contraseña";
			// 
			// tbClave
			// 
			this.tbClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbClave.Location = new System.Drawing.Point(16, 72);
			this.tbClave.Name = "tbClave";
			this.tbClave.Size = new System.Drawing.Size(200, 20);
			this.tbClave.TabIndex = 223;
			this.tbClave.Text = "1234";
			// 
			// tbNombreUsuario
			// 
			this.tbNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombreUsuario.Location = new System.Drawing.Point(16, 32);
			this.tbNombreUsuario.Name = "tbNombreUsuario";
			this.tbNombreUsuario.Size = new System.Drawing.Size(200, 20);
			this.tbNombreUsuario.TabIndex = 221;
			this.tbNombreUsuario.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbSucursal);
			this.groupBox1.Controls.Add(this.label26);
			this.groupBox1.Controls.Add(this.tbApellido);
			this.groupBox1.Controls.Add(this.label27);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbEmail);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.tbNombres);
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(448, 112);
			this.groupBox1.TabIndex = 225;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos";
			// 
			// cbSucursal
			// 
			this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSucursal.Location = new System.Drawing.Point(232, 72);
			this.cbSucursal.MaxLength = 100;
			this.cbSucursal.Name = "cbSucursal";
			this.cbSucursal.Size = new System.Drawing.Size(200, 21);
			this.cbSucursal.TabIndex = 221;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(232, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 14);
			this.label26.TabIndex = 214;
			this.label26.Text = "Nombres";
			// 
			// tbApellido
			// 
			this.tbApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbApellido.Location = new System.Drawing.Point(16, 32);
			this.tbApellido.Name = "tbApellido";
			this.tbApellido.Size = new System.Drawing.Size(200, 20);
			this.tbApellido.TabIndex = 1;
			this.tbApellido.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(16, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(136, 14);
			this.label27.TabIndex = 212;
			this.label27.Text = "Apellido";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(232, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 14);
			this.label1.TabIndex = 220;
			this.label1.Text = "Sucursal";
			// 
			// tbEmail
			// 
			this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEmail.Location = new System.Drawing.Point(16, 72);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(200, 20);
			this.tbEmail.TabIndex = 13;
			this.tbEmail.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 56);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(136, 14);
			this.label13.TabIndex = 208;
			this.label13.Text = "E-Mail";
			// 
			// tbNombres
			// 
			this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombres.Location = new System.Drawing.Point(232, 32);
			this.tbNombres.Name = "tbNombres";
			this.tbNombres.Size = new System.Drawing.Size(200, 20);
			this.tbNombres.TabIndex = 2;
			this.tbNombres.Text = "";
			// 
			// tbComentarios
			// 
			this.tbComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbComentarios.Location = new System.Drawing.Point(16, 336);
			this.tbComentarios.Multiline = true;
			this.tbComentarios.Name = "tbComentarios";
			this.tbComentarios.Size = new System.Drawing.Size(432, 64);
			this.tbComentarios.TabIndex = 1;
			this.tbComentarios.Text = "";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(16, 320);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(104, 14);
			this.label34.TabIndex = 218;
			this.label34.Text = "Comentarios";
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(688, 384);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 24);
			this.butSalir.TabIndex = 4;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// butLimpiar
			// 
			this.butLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(688, 352);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 2;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
			// 
			// imagenesTab
			// 
			this.imagenesTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.SaddleBrown;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(816, 32);
			this.label18.TabIndex = 113;
			this.label18.Text = "     Alta de Usuarios";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.SaddleBrown;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 115;
			this.pictureBox1.TabStop = false;
			// 
			// ucUsuarioAlta
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucUsuarioAlta";
			this.Size = new System.Drawing.Size(816, 456);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				UtilUI.llenarCombo(ref cbSucursal, this.conexion, "sp_getAllSucursals", "", -1);
				cbSucursal.SelectedIndex = 0;
				UtilUI.llenarListBox(ref lbxNoPosee, this.conexion, "sp_getAllPerfils", "", -1);
				lbxNoPosee.SelectedIndex = 0;

				UtilUI.llenarListBox(ref lbxPosee, this.conexion, "sp_getAllPerfils", "", -1);
				((DataTable)lbxPosee.DataSource).Rows.Clear();

				tbApellido.Select();
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
				inicializarComponentes();
				tbApellido.Text = "";
				tbNombres.Text = "";
				tbEmail.Text = "";
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
			UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Registro...", true);
			if (validarFormulario())
				darAlta();
			else
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
		}

		private bool validarFormulario()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;
			
				if (tbApellido.Text.Trim()=="")
				{
					mensaje += "   - El campo Apellido está vacío.\r\n";
					resultado = false;
				}
				if (tbNombres.Text.Trim()=="")
				{
					mensaje += "   - El campo Nombres está vacío.\r\n";
					resultado = false;
				}

				if (tbEmail.Text.Trim()!="")
					if (!Utilidades.IsEmailAddress(tbEmail.Text.Trim()))
					{
						mensaje += "   - El campo E-Mail en Datos Personales es incorrecto.\r\n";
						resultado = false;
					}
			
				if (existeNombreUsuario(tbNombreUsuario.Text.Trim()))
				{
					mensaje += "   - El nombre de usuario '" + tbNombreUsuario.Text.Trim() + "' ya existe en la base de datos.\r\n";
					resultado = false;
				}

				if (tbNombreUsuario.Text.Trim()=="")
				{
					mensaje += "   - El campo Nombre de Usuario está vacío.\r\n";
					resultado = false;
				}

				if (tbClave.Text.Trim()=="")
				{
					mensaje += "   - El campo Contraseña está vacío.\r\n";
					resultado = false;
				}
		
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Verifica en la tabla de usuarios si existe algun usuario con el mismo nombre
		private bool existeNombreUsuario(string username)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
			
				param[0] = new SqlParameter("@usuario", username);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getUsuario", param);

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
				//Datos
				string apellido = tbApellido.Text;
				string nombres = tbNombres.Text;
				string email = tbEmail.Text;
				string sucursalID = cbSucursal.SelectedValue.ToString();
				string username = tbNombreUsuario.Text;
				string password = tbClave.Text;
				string comentarios = tbComentarios.Text;
			
				SqlParameter[] param = new SqlParameter[7];
			
				param[0] = new SqlParameter("@apellido", apellido);
				param[1] = new SqlParameter("@nombres", nombres);
				param[2] = new SqlParameter("@email", email);
				param[3] = new SqlParameter("@sucursalID", new System.Guid(sucursalID));
				param[4] = new SqlParameter("@username", username);
				param[5] = new SqlParameter("@password", Utilidades.encriptar(password));
				param[6] = new SqlParameter("@comentarios", comentarios);
			
				while (true)
				{
					try 
					{
						//Agrega el registro en la tabla de usuarios
						SqlDataReader drUsuario = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoUsuario", param);
						drUsuario.Read();

						//Agrega las filas de perfiles
						bool esVendedor = false;
						DataTable dtPerfiles = (DataTable)lbxPosee.DataSource;
						if (dtPerfiles.Rows.Count>0)
						{
							for (int i=0; i<dtPerfiles.Rows.Count; i++)
							{
								//Verifica si es vendedor
								if (dtPerfiles.Rows[i]["identificador"].ToString()=="VENDEDOR")
									esVendedor = true;

								param = new SqlParameter[2];
								param[0] = new SqlParameter("@usuarioID", new System.Guid(drUsuario["ID"].ToString()));
								param[1] = new SqlParameter("@seguridadPerfilID", new System.Guid(dtPerfiles.Rows[i]["id"].ToString()));
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoUsuario_ItemSeguridad", param);
							}
						}

						//Si posee el perfil de vendedor, lo da de alta en la tabla de vendedores.
						if (esVendedor)
						{
							param = new SqlParameter[2];
							param[0] = new SqlParameter("@usuarioID", new System.Guid(drUsuario["ID"].ToString()));
							param[1] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
							SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoVendedor", param);
						}

						MessageBox.Show("Usuario ingresado con éxito.", "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarCamposUnicos();
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Usuario ingresado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo ingresar el Usuario. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar el Usuario. \r\n" + e.Message, false);
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
			try
			{
				tbApellido.Text = "";
				tbNombres.Text = "";
				tbEmail.Text = "";
				tbNombreUsuario.Text = "";
				tbComentarios.Text = "";
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

		private void butAgregar_Click(object sender, System.EventArgs e)
		{
			agregarPerfil();
		}

		//Agrega el perfil seleccionado en la lista de la derecha a la de la izquierda
		private void agregarPerfil()
		{
			try
			{
				DataTable dtNoPosee = (DataTable)lbxNoPosee.DataSource;
				if (dtNoPosee.Rows.Count>0)
				{
					int selectedIndex = 0;
					if (lbxNoPosee.SelectedIndex>-1)
						selectedIndex = lbxNoPosee.SelectedIndex;

					DataTable dtPosee = (DataTable)lbxPosee.DataSource;
					DataRow row = dtPosee.NewRow();
					row["id"] = dtNoPosee.Rows[selectedIndex]["id"];
					row["descripcion"] = dtNoPosee.Rows[selectedIndex]["descripcion"];
					row["identificador"] = dtNoPosee.Rows[selectedIndex]["identificador"];
					dtPosee.Rows.Add(row);
					dtPosee.AcceptChanges();

					dtNoPosee.Rows[selectedIndex].Delete();
					dtNoPosee.AcceptChanges();

				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		//Quita el perfil seleccionado en la lista de la izquierda a la de la derecha
		private void quitarPerfil()
		{
			try
			{
				DataTable dtPosee = (DataTable)lbxPosee.DataSource;
				if (dtPosee.Rows.Count>0)
				{
					int selectedIndex = 0;
					if (lbxPosee.SelectedIndex>-1)
						selectedIndex = lbxPosee.SelectedIndex;

					DataTable dtNoPosee = (DataTable)lbxNoPosee.DataSource;
					DataRow row = dtNoPosee.NewRow();
					row["id"] = dtPosee.Rows[selectedIndex]["id"];
					row["descripcion"] = dtPosee.Rows[selectedIndex]["descripcion"];
					row["identificador"] = dtPosee.Rows[selectedIndex]["identificador"];
					dtNoPosee.Rows.Add(row);
					dtNoPosee.AcceptChanges();

					dtPosee.Rows[selectedIndex].Delete();
					dtPosee.AcceptChanges();

				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Agrega todos los perfiles
		private void agregarTodo()
		{
			try
			{
				DataTable dtNoPosee = (DataTable)lbxNoPosee.DataSource;
				while (dtNoPosee.Rows.Count>0)
				{
					lbxNoPosee.SelectedIndex = 0;

					agregarPerfil();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Quita todos los perfiles
		private void quitarTodo()
		{
			try
			{
				DataTable dtPosee = (DataTable)lbxPosee.DataSource;
				while (dtPosee.Rows.Count>0)
				{
					lbxPosee.SelectedIndex = 0;
					quitarPerfil();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void lbxNoPosee_DoubleClick(object sender, System.EventArgs e)
		{
			agregarPerfil();
		}

		private void butAgregarTodo_Click(object sender, System.EventArgs e)
		{
			agregarTodo();
		}

		private void butQuitar_Click(object sender, System.EventArgs e)
		{
			quitarPerfil();
		}

		private void lbxPosee_DoubleClick(object sender, System.EventArgs e)
		{
			quitarPerfil();
		}

		private void butQuitarTodo_Click(object sender, System.EventArgs e)
		{
			quitarTodo();
		}
	}
}
