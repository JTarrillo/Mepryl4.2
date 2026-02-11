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
	/// Summary description for ucPerfilAlta.
	/// </summary>
	public class ucPerfilAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.Label label18;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbNombrePerfil;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbDescripcion;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butAgregarPermiso;
		private System.Windows.Forms.Button butQuitarPermiso;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.ListBox lbxObjetoSistema;
		private System.Windows.Forms.CheckedListBox clbTipoPermiso;
		private System.Windows.Forms.DataGrid dgPermisoAcceso;
		private System.Windows.Forms.ComboBox cbModuloSistema;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.ComponentModel.IContainer components;

		public ucPerfilAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucPerfilAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.tbNombrePerfil = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.tbDescripcion = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.butQuitarPermiso = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dgPermisoAcceso = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.cbModuloSistema = new System.Windows.Forms.ComboBox();
			this.clbTipoPermiso = new System.Windows.Forms.CheckedListBox();
			this.butAgregarPermiso = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.lbxObjetoSistema = new System.Windows.Forms.ListBox();
			this.butSalir = new System.Windows.Forms.Button();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gbModificacionProveedores.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPermisoAcceso)).BeginInit();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.tbNombrePerfil);
			this.gbModificacionProveedores.Controls.Add(this.label27);
			this.gbModificacionProveedores.Controls.Add(this.tbDescripcion);
			this.gbModificacionProveedores.Controls.Add(this.label13);
			this.gbModificacionProveedores.Controls.Add(this.groupBox3);
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(800, 416);
			this.gbModificacionProveedores.TabIndex = 114;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// tbNombrePerfil
			// 
			this.tbNombrePerfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombrePerfil.Location = new System.Drawing.Point(8, 32);
			this.tbNombrePerfil.Name = "tbNombrePerfil";
			this.tbNombrePerfil.Size = new System.Drawing.Size(288, 20);
			this.tbNombrePerfil.TabIndex = 228;
			this.tbNombrePerfil.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(8, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(136, 14);
			this.label27.TabIndex = 231;
			this.label27.Text = "Nombre del Perfil";
			// 
			// tbDescripcion
			// 
			this.tbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDescripcion.Location = new System.Drawing.Point(320, 32);
			this.tbDescripcion.Name = "tbDescripcion";
			this.tbDescripcion.Size = new System.Drawing.Size(472, 20);
			this.tbDescripcion.TabIndex = 229;
			this.tbDescripcion.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(320, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(136, 14);
			this.label13.TabIndex = 230;
			this.label13.Text = "Descripción";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.butGuardar);
			this.groupBox3.Controls.Add(this.butQuitarPermiso);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.dgPermisoAcceso);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.cbModuloSistema);
			this.groupBox3.Controls.Add(this.clbTipoPermiso);
			this.groupBox3.Controls.Add(this.butAgregarPermiso);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.lbxObjetoSistema);
			this.groupBox3.Controls.Add(this.butSalir);
			this.groupBox3.Controls.Add(this.butLimpiar);
			this.groupBox3.Location = new System.Drawing.Point(8, 64);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 344);
			this.groupBox3.TabIndex = 227;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Arme el Perfil";
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(544, 312);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 227;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// butQuitarPermiso
			// 
			this.butQuitarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butQuitarPermiso.Image = ((System.Drawing.Image)(resources.GetObject("butQuitarPermiso.Image")));
			this.butQuitarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butQuitarPermiso.Location = new System.Drawing.Point(312, 192);
			this.butQuitarPermiso.Name = "butQuitarPermiso";
			this.butQuitarPermiso.Size = new System.Drawing.Size(104, 24);
			this.butQuitarPermiso.TabIndex = 226;
			this.butQuitarPermiso.Text = "&Borrar";
			this.butQuitarPermiso.Click += new System.EventHandler(this.butQuitarPermiso_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(440, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 14);
			this.label2.TabIndex = 225;
			this.label2.Text = "Permisos de acceso";
			// 
			// dgPermisoAcceso
			// 
			this.dgPermisoAcceso.AllowSorting = false;
			this.dgPermisoAcceso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgPermisoAcceso.CaptionVisible = false;
			this.dgPermisoAcceso.DataMember = "";
			this.dgPermisoAcceso.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dgPermisoAcceso.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPermisoAcceso.Location = new System.Drawing.Point(440, 40);
			this.dgPermisoAcceso.Name = "dgPermisoAcceso";
			this.dgPermisoAcceso.ReadOnly = true;
			this.dgPermisoAcceso.Size = new System.Drawing.Size(328, 256);
			this.dgPermisoAcceso.TabIndex = 224;
			this.dgPermisoAcceso.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.dgPermisoAcceso;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "v_Permisos";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Módulo";
			this.dataGridTextBoxColumn1.MappingName = "modulo_nombre";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Sección";
			this.dataGridTextBoxColumn2.MappingName = "objeto_descripcion";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Permiso";
			this.dataGridTextBoxColumn3.MappingName = "operacion_nombre";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 150;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 14);
			this.label1.TabIndex = 223;
			this.label1.Text = "Tipo de Permiso";
			// 
			// cbModuloSistema
			// 
			this.cbModuloSistema.BackColor = System.Drawing.SystemColors.Window;
			this.cbModuloSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModuloSistema.Location = new System.Drawing.Point(16, 40);
			this.cbModuloSistema.Name = "cbModuloSistema";
			this.cbModuloSistema.Size = new System.Drawing.Size(272, 21);
			this.cbModuloSistema.TabIndex = 222;
			this.cbModuloSistema.SelectedIndexChanged += new System.EventHandler(this.cbModuloSistema_SelectedIndexChanged);
			// 
			// clbTipoPermiso
			// 
			this.clbTipoPermiso.BackColor = System.Drawing.SystemColors.Window;
			this.clbTipoPermiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.clbTipoPermiso.Location = new System.Drawing.Point(16, 200);
			this.clbTipoPermiso.Name = "clbTipoPermiso";
			this.clbTipoPermiso.Size = new System.Drawing.Size(272, 122);
			this.clbTipoPermiso.TabIndex = 221;
			// 
			// butAgregarPermiso
			// 
			this.butAgregarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAgregarPermiso.Image = ((System.Drawing.Image)(resources.GetObject("butAgregarPermiso.Image")));
			this.butAgregarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAgregarPermiso.Location = new System.Drawing.Point(312, 152);
			this.butAgregarPermiso.Name = "butAgregarPermiso";
			this.butAgregarPermiso.Size = new System.Drawing.Size(104, 24);
			this.butAgregarPermiso.TabIndex = 1;
			this.butAgregarPermiso.Text = "&Agregar";
			this.butAgregarPermiso.Click += new System.EventHandler(this.butAgregar_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 14);
			this.label4.TabIndex = 219;
			this.label4.Text = "Módulo del Sistema";
			// 
			// lbxObjetoSistema
			// 
			this.lbxObjetoSistema.BackColor = System.Drawing.SystemColors.Window;
			this.lbxObjetoSistema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbxObjetoSistema.Location = new System.Drawing.Point(16, 64);
			this.lbxObjetoSistema.Name = "lbxObjetoSistema";
			this.lbxObjetoSistema.Size = new System.Drawing.Size(272, 106);
			this.lbxObjetoSistema.TabIndex = 5;
			this.lbxObjetoSistema.DoubleClick += new System.EventHandler(this.lbxObjetoSistema_DoubleClick);
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(672, 312);
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
			this.butLimpiar.Location = new System.Drawing.Point(440, 312);
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
			this.label18.BackColor = System.Drawing.Color.MediumAquamarine;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(816, 32);
			this.label18.TabIndex = 113;
			this.label18.Text = "     Alta de Perfil de usuario";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.MediumAquamarine;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 115;
			this.pictureBox1.TabStop = false;
			// 
			// ucPerfilAlta
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucPerfilAlta";
			this.Size = new System.Drawing.Size(816, 456);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgPermisoAcceso)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				UtilUI.llenarCombo(ref cbModuloSistema, this.conexion, "sp_getAlltv_ModuloSistemas", "", -1);
				cbModuloSistema.SelectedIndex = 0;
			
				llenarObjetosSistema();
				llenarTiposPermiso();

				tbNombrePerfil.Select();

				//Carga la estructura en la grilla
				DataSet dataset = new dsPermisos();
				dgPermisoAcceso.DataSource = (DataTable)dataset.Tables["v_Permisos"];
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Llena la ListBox con los objetos de sistema segun el modulo seleccinado
		private void llenarObjetosSistema()
		{
			try
			{
				if (cbModuloSistema.SelectedValue!=null)
				{
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@moduloSistemaID", new System.Guid(cbModuloSistema.SelectedValue.ToString()));
					UtilUI.llenarListBox(ref lbxObjetoSistema, this.conexion, "sp_getAlltv_ObjetoSistemas","", -1, param);
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Llena la ListBox con los permisos de acceso
		private void llenarTiposPermiso()
		{
			UtilUI.llenarCheckedListBox(ref clbTipoPermiso, this.conexion, "sp_getAllSeguridadOperacions","", -1);
		}

		private void limpiarFormulario()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				tbNombrePerfil.Text = "";
				tbDescripcion.Text = "";
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
					darAlta();
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
			
				if (tbNombrePerfil.Text.Trim()=="")
				{
					mensaje += "   - El Nombre del Perfil está vacío.\r\n";
					resultado = false;
				}
				else if (existeNombrePerfil(tbNombrePerfil.Text.Trim()))
				{
					mensaje += "   - El Nombre del Perfil '" + tbNombrePerfil.Text.Trim() + "' ya existe. Utilice un nombre diferente.\r\n";
					resultado = false;
				}
				if (tbDescripcion.Text.Trim()=="")
				{
					mensaje += "   - La Descripción está vacía.\r\n";
					resultado = false;
				}

				DataTable dt = (DataTable)dgPermisoAcceso.DataSource;
				if (dt.Rows.Count==0)
				{
					mensaje += "   - La lista de Permisos de Acceso está vacía.\r\n";
					resultado = false;
				}
			
			
				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Perfil de usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

		//Verifica en la tabla de Perfiles si existe algun perfil con el mismo nombre
		private bool existeNombrePerfil(string perfil)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
			
				param[0] = new SqlParameter("@nombrePerfil", perfil);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getPerfilByNombre", param);

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
				string nombrePerfil = tbNombrePerfil.Text;
				string descripcion = tbDescripcion.Text;
			
				SqlParameter[] param = new SqlParameter[2];
			
				param[0] = new SqlParameter("@nombrePerfil", nombrePerfil);
				param[1] = new SqlParameter("@descripcion", descripcion);
			
				while (true)
				{
					try 
					{
						//Agrega el registro en la tabla de Perfiles
						SqlDataReader drPerfil = SqlHelper.ExecuteReader(this.conexion, "sp_NuevoSeguridadPerfil", param);
						drPerfil.Read();

						//Agrega las filas de Permisos
						DataTable dtPermisos = (DataTable)dgPermisoAcceso.DataSource;
						if (dtPermisos.Rows.Count>0)
						{
							for (int i=0; i<dtPermisos.Rows.Count; i++)
							{
								param = new SqlParameter[3];
								param[0] = new SqlParameter("@seguridadPerfilID", new System.Guid(drPerfil["ID"].ToString()));
								param[1] = new SqlParameter("@seguridadOperacionID", new System.Guid(dtPermisos.Rows[i]["seguridadOperacionID"].ToString()));
								param[2] = new SqlParameter("@seguridadObjetoID", new System.Guid(dtPermisos.Rows[i]["seguridadObjetoID"].ToString()));
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoSeguridadPerfil_Item", param);
							}
						}

						MessageBox.Show("Perfil ingresado con éxito.", "Alta de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarCamposUnicos();
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Perfil ingresado con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo ingresar el Perfil. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar el Perfil. \r\n" + e.Message, false);
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
			tbNombrePerfil.Text = "";
			tbDescripcion.Text = "";
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
				DataTable dtObjetos = (DataTable)lbxObjetoSistema.DataSource;
				if (dtObjetos.Rows.Count>0)
				{
					int selectedIndex = 0;
					if (lbxObjetoSistema.SelectedIndex==-1)
						lbxObjetoSistema.SelectedIndex = 0;

					selectedIndex = lbxObjetoSistema.SelectedIndex;

					DataTable dtPermisoAcceso = (DataTable)dgPermisoAcceso.DataSource;
					//Recorre los registros marcados de tipos de permiso
					for (int i=0; i<clbTipoPermiso.Items.Count; i++)
					{
						if (clbTipoPermiso.GetItemChecked(i))
						{
							clbTipoPermiso.SelectedIndex = i;
							//Crea un nuevo registro y lo graba en la grilla
							DataRow row = dtPermisoAcceso.NewRow();
							row["id"] = 0;
							row["seguridadPerfilID"] = 0;
							row["seguridadOperacionID"] = clbTipoPermiso.SelectedValue;
							row["seguridadObjetoID"] = lbxObjetoSistema.SelectedValue;
							row["operacion_nombre"] = clbTipoPermiso.Text;
							row["operacion_descripcion"] = "";
							row["moduloSistemaID"] = cbModuloSistema.SelectedValue;
							row["objeto_descripcion"] = lbxObjetoSistema.Text;
							row["objeto_identificador"] = "" ; //cbModuloSistema.Text + "." + lbxObjetoSistema.Text;
							row["objeto_nombre"] = "";
							row["modulo_nombre"] = cbModuloSistema.Text;

							dtPermisoAcceso.Rows.Add(row);
							dtPermisoAcceso.AcceptChanges();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		private void quitarPermisosSeleccionados()
		{
			try
			{
				if (dgPermisoAcceso.DataSource!=null)
				{
					DataTable dt = (DataTable)dgPermisoAcceso.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgPermisoAcceso.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							string[] rows = sRows.Split(",".ToCharArray());
							for (int j=0; j<rows.Length; j++)
							{
								string id = rows[j].Split(":".ToCharArray())[0];
								int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);
								dt.Rows[renglon]["id"] = "-1";
							}
							//Recorre los renglones marcados para borrar
							DataRow[] rowsBorrar = dt.Select("id='-1'");
							for (int k=0; k<rowsBorrar.Length; k++)
							{
								rowsBorrar[k].Delete();
							}
							dt.AcceptChanges();
							dgPermisoAcceso.Refresh();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		//Agrega todos los perfiles
		private void agregarTodo()
		{/*
			DataTable dtNoPosee = (DataTable)lbxNoPosee.DataSource;
			while (dtNoPosee.Rows.Count>0)
			{
				lbxNoPosee.SelectedIndex = 0;

				agregarPerfil();
			}*/
		}

		//Quita todos los perfiles
		private void quitarTodo()
		{/*
			DataTable dtPosee = (DataTable)lbxPosee.DataSource;
			while (dtPosee.Rows.Count>0)
			{
				lbxPosee.SelectedIndex = 0;
				quitarPerfil();
			}*/
		}

		private void lbxObjetoSistema_DoubleClick(object sender, System.EventArgs e)
		{
			agregarPerfil();
		}

		private void butAgregarTodo_Click(object sender, System.EventArgs e)
		{
			agregarTodo();
		}



		private void cbModuloSistema_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			llenarObjetosSistema();
		}

		private void butQuitarPermiso_Click(object sender, System.EventArgs e)
		{
			quitarPermisosSeleccionados();
		}

	}
}
