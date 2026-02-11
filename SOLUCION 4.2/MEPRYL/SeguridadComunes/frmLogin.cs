using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	public class frmLogin : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbNombre;
		private System.Windows.Forms.TextBox tbClave;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butAceptar;

		private Configuracion configuracion;
		private Usuario usuario = null;

		//Define el Delegado 
		public delegate void DelegateDevolverID(Usuario usuario);
		public DelegateDevolverID objDelegateDevolverID = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLogin(Configuracion conf)
		{
			//
			// Required for Windows Form Designer support
			//

			this.configuracion = conf;

			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbNombre = new System.Windows.Forms.TextBox();
			this.tbClave = new System.Windows.Forms.TextBox();
			this.butSalir = new System.Windows.Forms.Button();
			this.butAceptar = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(200, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(137, 118);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(344, 96);
			this.panel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 96);
			this.label1.TabIndex = 1;
			this.label1.Text = "Inicio de Sesión";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nombre de Usuario";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Clave";
			// 
			// tbNombre
			// 
			this.tbNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNombre.Location = new System.Drawing.Point(32, 136);
			this.tbNombre.Name = "tbNombre";
			this.tbNombre.Size = new System.Drawing.Size(272, 20);
			this.tbNombre.TabIndex = 4;
			this.tbNombre.Text = "";
			this.tbNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNombre_KeyPress);
			// 
			// tbClave
			// 
			this.tbClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbClave.Location = new System.Drawing.Point(32, 192);
			this.tbClave.Name = "tbClave";
			this.tbClave.PasswordChar = '*';
			this.tbClave.Size = new System.Drawing.Size(272, 20);
			this.tbClave.TabIndex = 5;
			this.tbClave.Text = "";
			this.tbClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbClave_KeyPress);
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(176, 256);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(128, 23);
			this.butSalir.TabIndex = 15;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// butAceptar
			// 
			this.butAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butAceptar.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar.Image")));
			this.butAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAceptar.Location = new System.Drawing.Point(32, 256);
			this.butAceptar.Name = "butAceptar";
			this.butAceptar.Size = new System.Drawing.Size(128, 24);
			this.butAceptar.TabIndex = 14;
			this.butAceptar.Text = "&Aceptar";
			this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
			// 
			// frmLogin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 302);
			this.Controls.Add(this.butSalir);
			this.Controls.Add(this.butAceptar);
			this.Controls.Add(this.tbClave);
			this.Controls.Add(this.tbNombre);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Inicio de Sesión";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLogin_Closing);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void butAceptar_Click(object sender, System.EventArgs e)
		{
			validarUsuario();
		}

		//Valida el usuario contra la base de datos
		private void validarUsuario()
		{
			UsuarioFactory uf = new UsuarioFactory();

			uf.strConexion = configuracion.getConectionString();

			if (uf.validarUsuario(tbNombre.Text.Trim(), tbClave.Text.Trim()))
			{
				this.DialogResult = DialogResult.OK;
				this.usuario = uf.getUsuario(tbNombre.Text.Trim());
				this.Close();
			}
			else
			{
				this.usuario = null;
				MessageBox.Show("El nombre de usuario o la contraseña no son correctos. Por favor inténtelo nuevamente.", "No se pudo iniciar la sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void frmLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult != DialogResult.OK)
				this.DialogResult = DialogResult.Cancel;

			//Devuelve objeto Usuario
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(this.usuario);
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void tbNombre_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==13)
				butAceptar_Click(null, null);
		}

		private void tbClave_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==13)
				butAceptar_Click(null, null);
		}
	}
}
