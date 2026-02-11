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
	/// Summary description for ucContactoAlta.
	/// </summary>
	public class ucContactoAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionCheques;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbTelefonos;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.TextBox tbNotas;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbApellido;
		private System.Windows.Forms.TextBox tbNombres;
		private System.Windows.Forms.ComboBox cbProveedor;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		//public string conexion = "SERVER=MONICA2;DATABASE=Ligier;UID=sa;PWD=;";
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucContactoAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucContactoAlta));
			this.gbModificacionCheques = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTelefonos = new System.Windows.Forms.TextBox();
			this.tbApellido = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.butSalir = new System.Windows.Forms.Button();
			this.tbNotas = new System.Windows.Forms.TextBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.tbNombres = new System.Windows.Forms.TextBox();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.cbProveedor = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.gbModificacionCheques.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModificacionCheques
			// 
			this.gbModificacionCheques.Controls.Add(this.label6);
			this.gbModificacionCheques.Controls.Add(this.tbTelefonos);
			this.gbModificacionCheques.Controls.Add(this.tbApellido);
			this.gbModificacionCheques.Controls.Add(this.label17);
			this.gbModificacionCheques.Controls.Add(this.butSalir);
			this.gbModificacionCheques.Controls.Add(this.tbNotas);
			this.gbModificacionCheques.Controls.Add(this.butGuardar);
			this.gbModificacionCheques.Controls.Add(this.label19);
			this.gbModificacionCheques.Controls.Add(this.label22);
			this.gbModificacionCheques.Controls.Add(this.label26);
			this.gbModificacionCheques.Controls.Add(this.label14);
			this.gbModificacionCheques.Controls.Add(this.butLimpiar);
			this.gbModificacionCheques.Controls.Add(this.tbNombres);
			this.gbModificacionCheques.Controls.Add(this.tbEmail);
			this.gbModificacionCheques.Controls.Add(this.cbProveedor);
			this.gbModificacionCheques.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionCheques.Name = "gbModificacionCheques";
			this.gbModificacionCheques.Size = new System.Drawing.Size(656, 344);
			this.gbModificacionCheques.TabIndex = 109;
			this.gbModificacionCheques.TabStop = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 14);
			this.label6.TabIndex = 119;
			this.label6.Text = "Teléfonos";
			// 
			// tbTelefonos
			// 
			this.tbTelefonos.Location = new System.Drawing.Point(8, 80);
			this.tbTelefonos.Name = "tbTelefonos";
			this.tbTelefonos.Size = new System.Drawing.Size(248, 20);
			this.tbTelefonos.TabIndex = 3;
			this.tbTelefonos.Text = "";
			// 
			// tbApellido
			// 
			this.tbApellido.Location = new System.Drawing.Point(8, 32);
			this.tbApellido.Name = "tbApellido";
			this.tbApellido.Size = new System.Drawing.Size(248, 20);
			this.tbApellido.TabIndex = 1;
			this.tbApellido.Text = "";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 112);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(88, 14);
			this.label17.TabIndex = 96;
			this.label17.Text = "E-Mail";
			// 
			// butSalir
			// 
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(432, 304);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 23);
			this.butSalir.TabIndex = 10;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// tbNotas
			// 
			this.tbNotas.Location = new System.Drawing.Point(8, 224);
			this.tbNotas.Multiline = true;
			this.tbNotas.Name = "tbNotas";
			this.tbNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbNotas.Size = new System.Drawing.Size(248, 104);
			this.tbNotas.TabIndex = 7;
			this.tbNotas.Text = "";
			// 
			// butGuardar
			// 
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(304, 304);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 9;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(280, 64);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(112, 14);
			this.label19.TabIndex = 94;
			this.label19.Text = "Proveedor";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(280, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(136, 14);
			this.label22.TabIndex = 91;
			this.label22.Text = "Nombres";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 14);
			this.label26.TabIndex = 87;
			this.label26.Text = "Apellido";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 208);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(136, 14);
			this.label14.TabIndex = 99;
			this.label14.Text = "Notas";
			// 
			// butLimpiar
			// 
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(432, 272);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 8;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
			// 
			// tbNombres
			// 
			this.tbNombres.Location = new System.Drawing.Point(280, 32);
			this.tbNombres.Name = "tbNombres";
			this.tbNombres.Size = new System.Drawing.Size(248, 20);
			this.tbNombres.TabIndex = 2;
			this.tbNombres.Text = "";
			// 
			// tbEmail
			// 
			this.tbEmail.Location = new System.Drawing.Point(8, 128);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(248, 20);
			this.tbEmail.TabIndex = 5;
			this.tbEmail.Text = "";
			// 
			// cbProveedor
			// 
			this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProveedor.Items.AddRange(new object[] {
															 "",
															 "F",
															 "Y"});
			this.cbProveedor.Location = new System.Drawing.Point(280, 80);
			this.cbProveedor.MaxLength = 100;
			this.cbProveedor.Name = "cbProveedor";
			this.cbProveedor.Size = new System.Drawing.Size(248, 21);
			this.cbProveedor.TabIndex = 4;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Green;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(672, 32);
			this.label18.TabIndex = 108;
			this.label18.Text = "Alta de Contactos";
			// 
			// ucContactoAlta
			// 
			this.Controls.Add(this.gbModificacionCheques);
			this.Controls.Add(this.label18);
			this.Name = "ucContactoAlta";
			this.Size = new System.Drawing.Size(672, 392);
			this.Load += new System.EventHandler(this.ucContactoAlta_Load);
			this.gbModificacionCheques.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}
		private void limpiarFormulario()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				UtilUI.llenarCombo(ref cbProveedor, this.conexion, "sp_getAllProveedors", "", -1);
				tbApellido.Text = "";
				tbNombres.Text = "";
				tbTelefonos.Text = "";
				tbEmail.Text = "";
				tbNotas.Text = "";
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void ucContactoAlta_Load(object sender, System.EventArgs e)
		{
			UtilUI.llenarCombo(ref cbProveedor, this.conexion, "sp_getAllProveedors", "", -1);
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			formContenedor.Close();
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

				if (tbApellido.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el Apellido.\r\n";
					resultado = false;
				}
				if (tbNombres.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el Nombre.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				SqlParameter[] param = new SqlParameter[9];
			
				param[0] = new SqlParameter("@apellido", tbApellido.Text.Trim());
				param[1] = new SqlParameter("@nombre", tbNombres.Text.Trim());
				param[2] = new SqlParameter("@telefonos", tbTelefonos.Text.Trim());
				param[3] = new SqlParameter("@email1", tbEmail.Text.Trim());
				param[4] = new SqlParameter("@email2", "");
				param[5] = new SqlParameter("@email3", "");
				param[6] = new SqlParameter("@clienteID", new System.Guid());
				param[7] = new SqlParameter("@proveedorID", new System.Guid(cbProveedor.SelectedValue.ToString()));
				param[8] = new SqlParameter("@notas", tbNotas.Text.Trim());

				while (true)
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoContacto", param);
						MessageBox.Show("Contacto ingresado con éxito.", "Alta de Contactos", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(formContenedor, ref this.statusBarPrincipal, "contacto ingresado con éxito.", false);
						limpiarCamposUnicos();
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo registrar el Contacto. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(formContenedor, ref this.statusBarPrincipal, "No se pudo registrar el Contacto. \r\n" + e.Message, false);
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
				tbTelefonos.Text = "";
				tbEmail.Text = "";
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
	}
}
