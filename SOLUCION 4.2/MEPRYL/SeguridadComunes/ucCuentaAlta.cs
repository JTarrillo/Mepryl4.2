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
	/// Summary description for ucCuentaAlta.
	/// </summary>
	public class ucCuentaAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.TextBox tbNumero;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbBanco;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbTitular;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbCuenta;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.Label label18;
		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private System.Windows.Forms.TextBox tbSerieChequeDirecto;
		private System.Windows.Forms.TextBox tbChequeNroDirecto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbSerieChequeDiferido;
		private System.Windows.Forms.TextBox tbChequeNroDiferido;
		private System.Windows.Forms.Label label2;
		//public string conexion = "SERVER=MONICA2;DATABASE=Ligier;UID=sa;PWD=;";
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucCuentaAlta()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucCuentaAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.tbNumero = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbBanco = new System.Windows.Forms.ComboBox();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTitular = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbCuenta = new System.Windows.Forms.TextBox();
			this.butSalir = new System.Windows.Forms.Button();
			this.tbObservaciones = new System.Windows.Forms.TextBox();
			this.butGuardar = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.butLimpiar = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.tbSerieChequeDirecto = new System.Windows.Forms.TextBox();
			this.tbChequeNroDirecto = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbSerieChequeDiferido = new System.Windows.Forms.TextBox();
			this.tbChequeNroDiferido = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.gbModificacionProveedores.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.tbSerieChequeDiferido);
			this.gbModificacionProveedores.Controls.Add(this.tbChequeNroDiferido);
			this.gbModificacionProveedores.Controls.Add(this.label2);
			this.gbModificacionProveedores.Controls.Add(this.tbSerieChequeDirecto);
			this.gbModificacionProveedores.Controls.Add(this.tbChequeNroDirecto);
			this.gbModificacionProveedores.Controls.Add(this.label8);
			this.gbModificacionProveedores.Controls.Add(this.tbNumero);
			this.gbModificacionProveedores.Controls.Add(this.label1);
			this.gbModificacionProveedores.Controls.Add(this.cbBanco);
			this.gbModificacionProveedores.Controls.Add(this.cbTipo);
			this.gbModificacionProveedores.Controls.Add(this.label6);
			this.gbModificacionProveedores.Controls.Add(this.tbTitular);
			this.gbModificacionProveedores.Controls.Add(this.label5);
			this.gbModificacionProveedores.Controls.Add(this.tbCuenta);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.tbObservaciones);
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.label22);
			this.gbModificacionProveedores.Controls.Add(this.label26);
			this.gbModificacionProveedores.Controls.Add(this.label14);
			this.gbModificacionProveedores.Controls.Add(this.butLimpiar);
			this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(704, 344);
			this.gbModificacionProveedores.TabIndex = 110;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// tbNumero
			// 
			this.tbNumero.Location = new System.Drawing.Point(280, 32);
			this.tbNumero.Name = "tbNumero";
			this.tbNumero.Size = new System.Drawing.Size(248, 20);
			this.tbNumero.TabIndex = 2;
			this.tbNumero.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(280, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 14);
			this.label1.TabIndex = 123;
			this.label1.Text = "Número";
			// 
			// cbBanco
			// 
			this.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBanco.Items.AddRange(new object[] {
														 "",
														 "F",
														 "Y"});
			this.cbBanco.Location = new System.Drawing.Point(280, 80);
			this.cbBanco.MaxLength = 100;
			this.cbBanco.Name = "cbBanco";
			this.cbBanco.Size = new System.Drawing.Size(248, 21);
			this.cbBanco.TabIndex = 4;
			// 
			// cbTipo
			// 
			this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTipo.Items.AddRange(new object[] {
														"",
														"F",
														"Y"});
			this.cbTipo.Location = new System.Drawing.Point(8, 80);
			this.cbTipo.MaxLength = 100;
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(248, 21);
			this.cbTipo.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 14);
			this.label6.TabIndex = 119;
			this.label6.Text = "Titular";
			// 
			// tbTitular
			// 
			this.tbTitular.Location = new System.Drawing.Point(8, 128);
			this.tbTitular.Name = "tbTitular";
			this.tbTitular.Size = new System.Drawing.Size(248, 20);
			this.tbTitular.TabIndex = 5;
			this.tbTitular.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(280, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 14);
			this.label5.TabIndex = 117;
			this.label5.Text = "Banco / Sucursal";
			// 
			// tbCuenta
			// 
			this.tbCuenta.Location = new System.Drawing.Point(8, 32);
			this.tbCuenta.Name = "tbCuenta";
			this.tbCuenta.Size = new System.Drawing.Size(248, 20);
			this.tbCuenta.TabIndex = 1;
			this.tbCuenta.Text = "";
			// 
			// butSalir
			// 
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(432, 304);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 23);
			this.butSalir.TabIndex = 13;
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
			this.tbObservaciones.TabIndex = 10;
			this.tbObservaciones.Text = "";
			// 
			// butGuardar
			// 
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(304, 304);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(120, 24);
			this.butGuardar.TabIndex = 12;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 64);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(136, 14);
			this.label22.TabIndex = 91;
			this.label22.Text = "Tipo de Cuenta";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 14);
			this.label26.TabIndex = 87;
			this.label26.Text = "Cuenta";
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
			this.butLimpiar.TabIndex = 11;
			this.butLimpiar.Text = "&Limpiar";
			this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Green;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(720, 32);
			this.label18.TabIndex = 109;
			this.label18.Text = "Alta de Cuentas";
			// 
			// tbSerieChequeDirecto
			// 
			this.tbSerieChequeDirecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSerieChequeDirecto.Location = new System.Drawing.Point(280, 128);
			this.tbSerieChequeDirecto.MaxLength = 2;
			this.tbSerieChequeDirecto.Name = "tbSerieChequeDirecto";
			this.tbSerieChequeDirecto.Size = new System.Drawing.Size(20, 20);
			this.tbSerieChequeDirecto.TabIndex = 6;
			this.tbSerieChequeDirecto.Text = "";
			// 
			// tbChequeNroDirecto
			// 
			this.tbChequeNroDirecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbChequeNroDirecto.Location = new System.Drawing.Point(304, 128);
			this.tbChequeNroDirecto.Name = "tbChequeNroDirecto";
			this.tbChequeNroDirecto.Size = new System.Drawing.Size(224, 20);
			this.tbChequeNroDirecto.TabIndex = 7;
			this.tbChequeNroDirecto.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(280, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(192, 14);
			this.label8.TabIndex = 126;
			this.label8.Text = "Próximo Nro. Cheque Pago Directo ";
			// 
			// tbSerieChequeDiferido
			// 
			this.tbSerieChequeDiferido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSerieChequeDiferido.Location = new System.Drawing.Point(280, 176);
			this.tbSerieChequeDiferido.MaxLength = 2;
			this.tbSerieChequeDiferido.Name = "tbSerieChequeDiferido";
			this.tbSerieChequeDiferido.Size = new System.Drawing.Size(20, 20);
			this.tbSerieChequeDiferido.TabIndex = 8;
			this.tbSerieChequeDiferido.Text = "";
			// 
			// tbChequeNroDiferido
			// 
			this.tbChequeNroDiferido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbChequeNroDiferido.Location = new System.Drawing.Point(304, 176);
			this.tbChequeNroDiferido.Name = "tbChequeNroDiferido";
			this.tbChequeNroDiferido.Size = new System.Drawing.Size(224, 20);
			this.tbChequeNroDiferido.TabIndex = 9;
			this.tbChequeNroDiferido.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(280, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(192, 14);
			this.label2.TabIndex = 129;
			this.label2.Text = "Próximo Nro. Cheque Pago Diferido";
			// 
			// ucCuentaAlta
			// 
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucCuentaAlta";
			this.Size = new System.Drawing.Size(720, 440);
			this.Load += new System.EventHandler(this.ucCuentaAlta_Load);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ucCuentaAlta_Load(object sender, System.EventArgs e)
		{
			UtilUI.llenarCombo(ref cbBanco, this.conexion, "sp_getAllBancosSucursal", "", -1);
			UtilUI.llenarCombo(ref cbTipo, this.conexion, "sp_getAllCuentasTipo", "", -1);
		}

		private void butLimpiar_Click(object sender, System.EventArgs e)
		{
			limpiarFormulario();
		}

		private void limpiarFormulario()
		{
			try
			{
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Cargando...", true);
				UtilUI.llenarCombo(ref cbBanco, this.conexion, "sp_getAllBancosSucursal", "", -1);
				UtilUI.llenarCombo(ref cbTipo, this.conexion, "sp_getAllCuentasTipo", "", -1);
				tbCuenta.Text = "";
				tbNumero.Text = "";
				tbTitular.Text = "";
				tbObservaciones.Text = "";
				tbSerieChequeDirecto.Text = "";
				tbSerieChequeDiferido.Text = "";
				tbChequeNroDirecto.Text = "";
				tbChequeNroDiferido.Text = "";
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

				if (tbCuenta.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el nombre de la Cuenta.\r\n";
					resultado = false;
				}
				if (tbNumero.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el Número de Cuenta.\r\n";
					resultado = false;
				}
				if (tbChequeNroDirecto.Text.Trim()=="" || !Utilidades.IsNumeric(tbChequeNroDirecto.Text.Trim()))
				{
					mensaje += "   - Nro. de Cheque Pago Directo incorrecto.\r\n";
					resultado = false;
				}
				if (tbChequeNroDiferido.Text.Trim()=="" || !Utilidades.IsNumeric(tbChequeNroDiferido.Text.Trim()))
				{
					mensaje += "   - Nro. de Cheque Pago Diferido incorrecto.\r\n";
					resultado = false;
				}

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				SqlParameter[] param = new SqlParameter[10];
			
				param[0] = new SqlParameter("@numero", tbNumero.Text.Trim());
				param[1] = new SqlParameter("@bancoID", new System.Guid(cbBanco.SelectedValue.ToString()));
				param[2] = new SqlParameter("@titular", tbTitular.Text.Trim());
				param[3] = new SqlParameter("@tipoID", new System.Guid(cbTipo.SelectedValue.ToString()));
				param[4] = new SqlParameter("@descripcion", tbCuenta.Text.Trim());
				param[5] = new SqlParameter("@observaciones", tbObservaciones.Text.Trim());
				param[6] = new SqlParameter("@serieActualDirecto", tbSerieChequeDirecto.Text.Trim());
				param[7] = new SqlParameter("@proximoNroChequeDirecto", tbChequeNroDirecto.Text.Trim());
				param[8] = new SqlParameter("@serieActualDiferido", tbSerieChequeDiferido.Text.Trim());
				param[9] = new SqlParameter("@proximoNroChequeDiferido", tbChequeNroDiferido.Text.Trim());
			
				while (true)
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_NuevoCuenta", param);
						MessageBox.Show("Cuenta ingresada con éxito.", "Alta de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cuenta ingresada con éxito.", false);
						break;
					}
					catch (Exception e)
					{
						ManejadorErrores.escribirLog(e, true);
						DialogResult dr = MessageBox.Show("No se pudo ingresar la Cuenta. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo ingresar la Cuenta. \r\n" + e.Message, false);
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
			tbCuenta.Text = "";
			tbNumero.Text = "";
		}
	}
}
