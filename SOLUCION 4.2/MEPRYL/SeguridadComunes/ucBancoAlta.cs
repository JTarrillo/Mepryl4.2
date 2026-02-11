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
	/// Summary description for ucBancoAlta.
	/// </summary>
	public class ucBancoAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionCheques;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbProvincia;
		private System.Windows.Forms.TextBox tbCodPost;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbOficina;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPiso;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbNro;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TextBox tbCalle;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.ComboBox cbLocalidad;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbSucursal;
		private System.Windows.Forms.TextBox tbBanco;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbTelefonos;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public Configuracion m_configuracion;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		//public string conexion = "SERVER=MONICA2;DATABASE=Ligier;UID=sa;PWD=;";
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucBancoAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucBancoAlta));
			this.gbModificacionCheques = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbTelefonos = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbSucursal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbProvincia = new System.Windows.Forms.ComboBox();
			this.tbCodPost = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbOficina = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPiso = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbNro = new System.Windows.Forms.TextBox();
			this.tbBanco = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.butSalir = new System.Windows.Forms.Button();
			this.tbObservaciones = new System.Windows.Forms.TextBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.tbCalle = new System.Windows.Forms.TextBox();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.cbLocalidad = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.gbModificacionCheques.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModificacionCheques
			// 
			this.gbModificacionCheques.Controls.Add(this.label5);
			this.gbModificacionCheques.Controls.Add(this.tbTelefonos);
			this.gbModificacionCheques.Controls.Add(this.label6);
			this.gbModificacionCheques.Controls.Add(this.tbSucursal);
			this.gbModificacionCheques.Controls.Add(this.label4);
			this.gbModificacionCheques.Controls.Add(this.cbProvincia);
			this.gbModificacionCheques.Controls.Add(this.tbCodPost);
			this.gbModificacionCheques.Controls.Add(this.label3);
			this.gbModificacionCheques.Controls.Add(this.tbOficina);
			this.gbModificacionCheques.Controls.Add(this.label2);
			this.gbModificacionCheques.Controls.Add(this.tbPiso);
			this.gbModificacionCheques.Controls.Add(this.label1);
			this.gbModificacionCheques.Controls.Add(this.tbNro);
			this.gbModificacionCheques.Controls.Add(this.tbBanco);
			this.gbModificacionCheques.Controls.Add(this.label16);
			this.gbModificacionCheques.Controls.Add(this.label17);
			this.gbModificacionCheques.Controls.Add(this.butSalir);
			this.gbModificacionCheques.Controls.Add(this.tbObservaciones);
			this.gbModificacionCheques.Controls.Add(this.butGuardar);
			this.gbModificacionCheques.Controls.Add(this.label19);
			this.gbModificacionCheques.Controls.Add(this.label22);
			this.gbModificacionCheques.Controls.Add(this.label26);
			this.gbModificacionCheques.Controls.Add(this.label14);
			this.gbModificacionCheques.Controls.Add(this.butLimpiar);
			this.gbModificacionCheques.Controls.Add(this.tbCalle);
			this.gbModificacionCheques.Controls.Add(this.tbEmail);
			this.gbModificacionCheques.Controls.Add(this.cbLocalidad);
			this.gbModificacionCheques.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionCheques.Name = "gbModificacionCheques";
			this.gbModificacionCheques.Size = new System.Drawing.Size(656, 344);
			this.gbModificacionCheques.TabIndex = 109;
			this.gbModificacionCheques.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 14);
			this.label5.TabIndex = 121;
			this.label5.Text = "Teléfonos";
			// 
			// tbTelefonos
			// 
			this.tbTelefonos.Location = new System.Drawing.Point(8, 80);
			this.tbTelefonos.Name = "tbTelefonos";
			this.tbTelefonos.Size = new System.Drawing.Size(248, 20);
			this.tbTelefonos.TabIndex = 2;
			this.tbTelefonos.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 14);
			this.label6.TabIndex = 119;
			this.label6.Text = "Sucursal";
			// 
			// tbSucursal
			// 
			this.tbSucursal.Location = new System.Drawing.Point(8, 128);
			this.tbSucursal.Name = "tbSucursal";
			this.tbSucursal.Size = new System.Drawing.Size(248, 20);
			this.tbSucursal.TabIndex = 3;
			this.tbSucursal.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(280, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 14);
			this.label4.TabIndex = 115;
			this.label4.Text = "Provincia";
			// 
			// cbProvincia
			// 
			this.cbProvincia.Items.AddRange(new object[] {
															 "",
															 "F",
															 "Y"});
			this.cbProvincia.Location = new System.Drawing.Point(280, 176);
			this.cbProvincia.MaxLength = 100;
			this.cbProvincia.Name = "cbProvincia";
			this.cbProvincia.Size = new System.Drawing.Size(248, 21);
			this.cbProvincia.TabIndex = 12;
			// 
			// tbCodPost
			// 
			this.tbCodPost.Location = new System.Drawing.Point(400, 80);
			this.tbCodPost.Name = "tbCodPost";
			this.tbCodPost.Size = new System.Drawing.Size(56, 20);
			this.tbCodPost.TabIndex = 10;
			this.tbCodPost.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(400, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 14);
			this.label3.TabIndex = 112;
			this.label3.Text = "Cod.Post.";
			// 
			// tbOficina
			// 
			this.tbOficina.Location = new System.Drawing.Point(360, 80);
			this.tbOficina.Name = "tbOficina";
			this.tbOficina.Size = new System.Drawing.Size(32, 20);
			this.tbOficina.TabIndex = 9;
			this.tbOficina.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(360, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 14);
			this.label2.TabIndex = 110;
			this.label2.Text = "Oficina";
			// 
			// tbPiso
			// 
			this.tbPiso.Location = new System.Drawing.Point(320, 80);
			this.tbPiso.Name = "tbPiso";
			this.tbPiso.Size = new System.Drawing.Size(32, 20);
			this.tbPiso.TabIndex = 8;
			this.tbPiso.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(320, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 14);
			this.label1.TabIndex = 108;
			this.label1.Text = "Piso";
			// 
			// tbNro
			// 
			this.tbNro.Location = new System.Drawing.Point(280, 80);
			this.tbNro.Name = "tbNro";
			this.tbNro.Size = new System.Drawing.Size(32, 20);
			this.tbNro.TabIndex = 7;
			this.tbNro.Text = "";
			// 
			// tbBanco
			// 
			this.tbBanco.Location = new System.Drawing.Point(8, 32);
			this.tbBanco.Name = "tbBanco";
			this.tbBanco.Size = new System.Drawing.Size(248, 20);
			this.tbBanco.TabIndex = 1;
			this.tbBanco.Text = "";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(280, 64);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 14);
			this.label16.TabIndex = 97;
			this.label16.Text = "Nro.";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 160);
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
			this.butSalir.TabIndex = 15;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// tbObservaciones
			// 
			this.tbObservaciones.Location = new System.Drawing.Point(8, 224);
			this.tbObservaciones.Multiline = true;
			this.tbObservaciones.Name = "tbObservaciones";
			this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbObservaciones.Size = new System.Drawing.Size(248, 104);
			this.tbObservaciones.TabIndex = 5;
			this.tbObservaciones.Text = "";
			// 
			// butGuardar
			// 
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(304, 304);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 14;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(280, 112);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(112, 14);
			this.label19.TabIndex = 94;
			this.label19.Text = "Localidad";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(280, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(136, 14);
			this.label22.TabIndex = 91;
			this.label22.Text = "Calle";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 14);
			this.label26.TabIndex = 87;
			this.label26.Text = "Banco";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 208);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(136, 14);
			this.label14.TabIndex = 99;
			this.label14.Text = "Observaciones";
			// 
			// butLimpiar
			// 
			this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
			this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLimpiar.Location = new System.Drawing.Point(432, 272);
			this.butLimpiar.Name = "butLimpiar";
			this.butLimpiar.Size = new System.Drawing.Size(96, 24);
			this.butLimpiar.TabIndex = 13;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
			// 
			// tbCalle
			// 
			this.tbCalle.Location = new System.Drawing.Point(280, 32);
			this.tbCalle.Name = "tbCalle";
			this.tbCalle.Size = new System.Drawing.Size(248, 20);
			this.tbCalle.TabIndex = 6;
			this.tbCalle.Text = "";
			// 
			// tbEmail
			// 
			this.tbEmail.Location = new System.Drawing.Point(8, 176);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(248, 20);
			this.tbEmail.TabIndex = 4;
			this.tbEmail.Text = "";
			// 
			// cbLocalidad
			// 
			this.cbLocalidad.Items.AddRange(new object[] {
															 "",
															 "F",
															 "Y"});
			this.cbLocalidad.Location = new System.Drawing.Point(280, 128);
			this.cbLocalidad.MaxLength = 100;
			this.cbLocalidad.Name = "cbLocalidad";
			this.cbLocalidad.Size = new System.Drawing.Size(248, 21);
			this.cbLocalidad.TabIndex = 11;
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
			this.label18.Text = "Alta de Bancos";
			// 
			// ucBancoAlta
			// 
			this.Controls.Add(this.gbModificacionCheques);
			this.Controls.Add(this.label18);
			this.Name = "ucBancoAlta";
			this.Size = new System.Drawing.Size(672, 392);
			this.Load += new System.EventHandler(this.ucBancoAlta_Load);
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
				UtilUI.llenarCombo(ref cbLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
				UtilUI.llenarCombo(ref cbProvincia, this.conexion, "sp_getAllProvincias", "", -1);
				cbLocalidad.SelectedIndex = -1;
				cbProvincia.SelectedIndex = -1;
				tbBanco.Text = "";
				tbCalle.Text = "";
				tbTelefonos.Text = "";
				tbNro.Text = "";
				tbPiso.Text = "";
				tbOficina.Text = "";
				tbCodPost.Text = "";
				tbEmail.Text = "";
				tbObservaciones.Text = "";
				tbSucursal.Text = "";
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void ucBancoAlta_Load(object sender, System.EventArgs e)
		{
			cbLocalidad.SelectedIndex = -1;
			cbProvincia.SelectedIndex = -1;
			UtilUI.llenarCombo(ref cbLocalidad, this.conexion, "sp_getAllLocalidads", "", -1);
			UtilUI.llenarCombo(ref cbProvincia, this.conexion, "sp_getAllProvincias", "", -1);
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

				if (tbBanco.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el nombre del Banco.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

				string localidadID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidad, "sp_InsertLocalidad");
				string provinciaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvincia, "sp_InsertProvincia");

				SqlParameter[] param = new SqlParameter[12];
			
				param[0] = new SqlParameter("@nombre", tbBanco.Text);
				param[1] = new SqlParameter("@sucursal", tbSucursal.Text);
				param[2] = new SqlParameter("@calle", tbCalle.Text);
				param[3] = new SqlParameter("@telefonos", tbTelefonos.Text);
				param[4] = new SqlParameter("@nro", tbNro.Text);
				param[5] = new SqlParameter("@piso", tbPiso.Text);
				param[6] = new SqlParameter("@oficina", tbOficina.Text);
				param[7] = new SqlParameter("@codigoPostal", tbCodPost.Text);
				param[8] = new SqlParameter("@email", tbEmail.Text);
				param[9] = new SqlParameter("@localidadID", new System.Guid(localidadID));
				param[10] = new SqlParameter("@provinciaID", new System.Guid(provinciaID));
				param[11] = new SqlParameter("@observaciones", tbObservaciones.Text);

				while (true)
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoBanco", param);
						MessageBox.Show("Banco ingresado con éxito.", "Alta de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(formContenedor, ref this.statusBarPrincipal, "Banco ingresado con éxito.", false);
						limpiarCamposUnicos();
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo registrar el Banco. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(formContenedor, ref this.statusBarPrincipal, "No se pudo registrar el Banco. \r\n" + e.Message, false);
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
			tbBanco.Text = "";
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
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

	}
}
