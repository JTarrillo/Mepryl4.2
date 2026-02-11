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
	/// Summary description for ucMaquinaAlta.
	/// </summary>
	public class ucMaquinaAlta : System.Windows.Forms.UserControl
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
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbNombreMaquina;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbSucursal;
		private System.Windows.Forms.Button butGuardar;
		private System.ComponentModel.IContainer components;

		public ucMaquinaAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucMaquinaAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.cbSucursal = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbNombreMaquina = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.tbObservaciones = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.butSalir = new System.Windows.Forms.Button();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gbModificacionProveedores.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.cbSucursal);
			this.gbModificacionProveedores.Controls.Add(this.label1);
			this.gbModificacionProveedores.Controls.Add(this.tbNombreMaquina);
			this.gbModificacionProveedores.Controls.Add(this.label27);
			this.gbModificacionProveedores.Controls.Add(this.tbObservaciones);
			this.gbModificacionProveedores.Controls.Add(this.label13);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
			this.gbModificacionProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbModificacionProveedores.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gbModificacionProveedores.Location = new System.Drawing.Point(0, 32);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(816, 424);
			this.gbModificacionProveedores.TabIndex = 114;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(552, 376);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 234;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// cbSucursal
			// 
			this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSucursal.Location = new System.Drawing.Point(8, 96);
			this.cbSucursal.Name = "cbSucursal";
			this.cbSucursal.Size = new System.Drawing.Size(288, 21);
			this.cbSucursal.TabIndex = 233;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 14);
			this.label1.TabIndex = 232;
			this.label1.Text = "Sucursal";
			// 
			// tbNombreMaquina
			// 
			this.tbNombreMaquina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombreMaquina.Location = new System.Drawing.Point(8, 32);
			this.tbNombreMaquina.Name = "tbNombreMaquina";
			this.tbNombreMaquina.Size = new System.Drawing.Size(288, 20);
			this.tbNombreMaquina.TabIndex = 228;
			this.tbNombreMaquina.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(8, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(136, 14);
			this.label27.TabIndex = 231;
			this.label27.Text = "Nombre de la Máquina";
			// 
			// tbObservaciones
			// 
			this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbObservaciones.Location = new System.Drawing.Point(320, 32);
			this.tbObservaciones.Multiline = true;
			this.tbObservaciones.Name = "tbObservaciones";
			this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbObservaciones.Size = new System.Drawing.Size(456, 88);
			this.tbObservaciones.TabIndex = 229;
			this.tbObservaciones.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(320, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(136, 14);
			this.label13.TabIndex = 230;
			this.label13.Text = "Observaciones";
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(680, 376);
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
			this.butLimpiar.Location = new System.Drawing.Point(680, 344);
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
			this.label18.BackColor = System.Drawing.Color.Orchid;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(816, 32);
			this.label18.TabIndex = 113;
			this.label18.Text = "     Alta de Máquinas";
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
			// ucMaquinaAlta
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucMaquinaAlta";
			this.Size = new System.Drawing.Size(816, 456);
			this.gbModificacionProveedores.ResumeLayout(false);
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
			
				tbNombreMaquina.Select();
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
				tbNombreMaquina.Text = "";
				tbObservaciones.Text = "";
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
			
				if (tbNombreMaquina.Text.Trim()=="")
				{
					mensaje += "   - El Nombre de la Máquina está vacía.\r\n";
					resultado = false;
				}
				else if (existeNombreMaquina(tbNombreMaquina.Text.Trim()))
				{
					mensaje += "   - El Nombre de la Máquina '" + tbNombreMaquina.Text.Trim() + "' ya existe. Utilice un nombre diferente.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Máquinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Verifica en la tabla de maquinas si existe alguna maquina con el mismo nombre
		private bool existeNombreMaquina(string nombreMaquina)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
			
				param[0] = new SqlParameter("@nombreMaquina", nombreMaquina);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getMaquinaByNombre", param);

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
				string nombreMaquina = tbNombreMaquina.Text;
				string observaciones = tbObservaciones.Text;
				string sucursalID = cbSucursal.SelectedValue.ToString();
			
				SqlParameter[] param = new SqlParameter[3];
			
				param[0] = new SqlParameter("@nombreMaquina", nombreMaquina);
				param[1] = new SqlParameter("@sucursalID", new System.Guid(sucursalID));
				param[2] = new SqlParameter("@observaciones", observaciones);
			
				while (true)
				{
					try 
					{
						//Agrega el registro en la tabla de Perfiles
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevaMaquina", param);
					
						MessageBox.Show("Máquina ingresada con éxito.", "Alta de Máquina", MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarCamposUnicos();
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Máquina ingresada con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo ingresar la Máquina. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar la Máquina. \r\n" + e.Message, false);
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
			tbNombreMaquina.Text = "";
			tbObservaciones.Text = "";
		}

		

		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

	}
}
