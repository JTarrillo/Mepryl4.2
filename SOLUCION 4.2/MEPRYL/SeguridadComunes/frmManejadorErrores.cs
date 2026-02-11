using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmManejadorErrores.
	/// </summary>
	public class frmManejadorErrores : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label blPilaLlamadas;
		public System.Windows.Forms.TextBox PilaLlamadas;
		public System.Windows.Forms.TextBox Modulo;
		public System.Windows.Forms.TextBox Mensaje;
		public System.Windows.Forms.Button butEnviarMail;
		public Configuracion configuracion;
		private System.Windows.Forms.Button butOk; 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmManejadorErrores()
		{
			//
			// Required for Windows Form Designer support
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmManejadorErrores));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.blPilaLlamadas = new System.Windows.Forms.Label();
			this.PilaLlamadas = new System.Windows.Forms.TextBox();
			this.Modulo = new System.Windows.Forms.TextBox();
			this.Mensaje = new System.Windows.Forms.TextBox();
			this.butEnviarMail = new System.Windows.Forms.Button();
			this.butOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DarkRed;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(376, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ha ocurrido un error";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Módulo";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Mensaje";
			// 
			// blPilaLlamadas
			// 
			this.blPilaLlamadas.Location = new System.Drawing.Point(8, 240);
			this.blPilaLlamadas.Name = "blPilaLlamadas";
			this.blPilaLlamadas.Size = new System.Drawing.Size(104, 16);
			this.blPilaLlamadas.TabIndex = 6;
			this.blPilaLlamadas.Text = "Pila de llamadas";
			// 
			// PilaLlamadas
			// 
			this.PilaLlamadas.AcceptsReturn = true;
			this.PilaLlamadas.AcceptsTab = true;
			this.PilaLlamadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PilaLlamadas.Location = new System.Drawing.Point(8, 256);
			this.PilaLlamadas.Multiline = true;
			this.PilaLlamadas.Name = "PilaLlamadas";
			this.PilaLlamadas.ReadOnly = true;
			this.PilaLlamadas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.PilaLlamadas.Size = new System.Drawing.Size(376, 112);
			this.PilaLlamadas.TabIndex = 9;
			this.PilaLlamadas.Text = "";
			this.PilaLlamadas.WordWrap = false;
			// 
			// Modulo
			// 
			this.Modulo.AcceptsReturn = true;
			this.Modulo.AcceptsTab = true;
			this.Modulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Modulo.Location = new System.Drawing.Point(8, 72);
			this.Modulo.Multiline = true;
			this.Modulo.Name = "Modulo";
			this.Modulo.ReadOnly = true;
			this.Modulo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Modulo.Size = new System.Drawing.Size(376, 20);
			this.Modulo.TabIndex = 10;
			this.Modulo.Text = "";
			// 
			// Mensaje
			// 
			this.Mensaje.AcceptsReturn = true;
			this.Mensaje.AcceptsTab = true;
			this.Mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Mensaje.Location = new System.Drawing.Point(8, 120);
			this.Mensaje.Multiline = true;
			this.Mensaje.Name = "Mensaje";
			this.Mensaje.ReadOnly = true;
			this.Mensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Mensaje.Size = new System.Drawing.Size(376, 112);
			this.Mensaje.TabIndex = 11;
			this.Mensaje.Text = "";
			this.Mensaje.WordWrap = false;
			// 
			// butEnviarMail
			// 
			this.butEnviarMail.Enabled = false;
			this.butEnviarMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butEnviarMail.Image = ((System.Drawing.Image)(resources.GetObject("butEnviarMail.Image")));
			this.butEnviarMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butEnviarMail.Location = new System.Drawing.Point(8, 376);
			this.butEnviarMail.Name = "butEnviarMail";
			this.butEnviarMail.Size = new System.Drawing.Size(176, 23);
			this.butEnviarMail.TabIndex = 12;
			this.butEnviarMail.Text = "Enviar error por e-mail";
			this.butEnviarMail.Click += new System.EventHandler(this.butEnviarMail_Click);
			// 
			// butOk
			// 
			this.butOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
			this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butOk.Location = new System.Drawing.Point(264, 376);
			this.butOk.Name = "butOk";
			this.butOk.Size = new System.Drawing.Size(120, 24);
			this.butOk.TabIndex = 25;
			this.butOk.Text = "&Ok";
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// frmManejadorErrores
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(392, 408);
			this.Controls.Add(this.butOk);
			this.Controls.Add(this.butEnviarMail);
			this.Controls.Add(this.Mensaje);
			this.Controls.Add(this.Modulo);
			this.Controls.Add(this.PilaLlamadas);
			this.Controls.Add(this.blPilaLlamadas);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmManejadorErrores";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Error";
			this.ResumeLayout(false);

		}
		#endregion

		private void butOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butEnviarMail_Click(object sender, System.EventArgs e)
		{
			frmManejadorErroresEMail f = new frmManejadorErroresEMail();
			f.Modulo.Text = this.Modulo.Text;
			f.Mensaje.Text = this.Mensaje.Text;
			f.PilaLlamadas.Text = this.PilaLlamadas.Text;
			f.configuracion = this.configuracion;

			f.ShowDialog();

		}
	}
}
