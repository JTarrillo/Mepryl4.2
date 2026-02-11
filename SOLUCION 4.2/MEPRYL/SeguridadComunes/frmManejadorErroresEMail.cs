using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;
using System.Web.Mail;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmManejadorErroresEMail.
	/// </summary>
	public class frmManejadorErroresEMail : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbObservaciones;
		private System.Windows.Forms.Button butEnviar;
		private System.Windows.Forms.Button butSalir;
		public System.Windows.Forms.TextBox Mensaje;
		public System.Windows.Forms.TextBox Modulo;
		public System.Windows.Forms.TextBox PilaLlamadas;
		public Configuracion configuracion;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmManejadorErroresEMail()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmManejadorErroresEMail));
			this.label2 = new System.Windows.Forms.Label();
			this.tbObservaciones = new System.Windows.Forms.TextBox();
			this.butEnviar = new System.Windows.Forms.Button();
			this.butSalir = new System.Windows.Forms.Button();
			this.Mensaje = new System.Windows.Forms.TextBox();
			this.Modulo = new System.Windows.Forms.TextBox();
			this.PilaLlamadas = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Observaciones";
			// 
			// tbObservaciones
			// 
			this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbObservaciones.Location = new System.Drawing.Point(8, 32);
			this.tbObservaciones.Multiline = true;
			this.tbObservaciones.Name = "tbObservaciones";
			this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbObservaciones.Size = new System.Drawing.Size(392, 192);
			this.tbObservaciones.TabIndex = 4;
			this.tbObservaciones.Text = "";
			// 
			// butEnviar
			// 
			this.butEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butEnviar.Image = ((System.Drawing.Image)(resources.GetObject("butEnviar.Image")));
			this.butEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butEnviar.Location = new System.Drawing.Point(408, 96);
			this.butEnviar.Name = "butEnviar";
			this.butEnviar.TabIndex = 9;
			this.butEnviar.Text = "Enviar";
			this.butEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butEnviar.Click += new System.EventHandler(this.butEnviar_Click);
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(408, 136);
			this.butSalir.Name = "butSalir";
			this.butSalir.TabIndex = 10;
			this.butSalir.Text = "Salir";
			this.butSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Mensaje
			// 
			this.Mensaje.AcceptsReturn = true;
			this.Mensaje.AcceptsTab = true;
			this.Mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Mensaje.Location = new System.Drawing.Point(280, 48);
			this.Mensaje.Multiline = true;
			this.Mensaje.Name = "Mensaje";
			this.Mensaje.ReadOnly = true;
			this.Mensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Mensaje.Size = new System.Drawing.Size(71, 88);
			this.Mensaje.TabIndex = 14;
			this.Mensaje.Text = "";
			this.Mensaje.Visible = false;
			this.Mensaje.WordWrap = false;
			// 
			// Modulo
			// 
			this.Modulo.AcceptsReturn = true;
			this.Modulo.AcceptsTab = true;
			this.Modulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Modulo.Location = new System.Drawing.Point(280, 0);
			this.Modulo.Multiline = true;
			this.Modulo.Name = "Modulo";
			this.Modulo.ReadOnly = true;
			this.Modulo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Modulo.Size = new System.Drawing.Size(71, 20);
			this.Modulo.TabIndex = 13;
			this.Modulo.Text = "";
			this.Modulo.Visible = false;
			// 
			// PilaLlamadas
			// 
			this.PilaLlamadas.AcceptsReturn = true;
			this.PilaLlamadas.AcceptsTab = true;
			this.PilaLlamadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PilaLlamadas.Location = new System.Drawing.Point(280, 160);
			this.PilaLlamadas.Multiline = true;
			this.PilaLlamadas.Name = "PilaLlamadas";
			this.PilaLlamadas.ReadOnly = true;
			this.PilaLlamadas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.PilaLlamadas.Size = new System.Drawing.Size(71, 88);
			this.PilaLlamadas.TabIndex = 12;
			this.PilaLlamadas.Text = "";
			this.PilaLlamadas.Visible = false;
			this.PilaLlamadas.WordWrap = false;
			// 
			// frmManejadorErroresEMail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(490, 248);
			this.Controls.Add(this.Mensaje);
			this.Controls.Add(this.Modulo);
			this.Controls.Add(this.PilaLlamadas);
			this.Controls.Add(this.butSalir);
			this.Controls.Add(this.butEnviar);
			this.Controls.Add(this.tbObservaciones);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmManejadorErroresEMail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enviar Error por e-mail";
			this.ResumeLayout(false);

		}
		#endregion

		private void butEnviar_Click(object sender, System.EventArgs e)
		{
			string error = "", messageID = "";
			string body;

			string smtp, mail;

			error = "";
			smtp = ""; mail = "";
			
			this.Cursor = Cursors.WaitCursor;
			//Prepara el mensaje
			body =	"-----------------\r\n" +
					"Observaciones: \r\n" + 
					"-----------------\r\n" +
					tbObservaciones.Text + "\r\n\r\n------------------------- Detalle del error -------------------------\r\n\r\n" +
					"-----------------\r\n" +
					"Fecha   : " + DateTime.Now.ToString() + "\r\n" +
					"Sucursal: " + configuracion.sucursal.nombre + "\r\n" +
					"Maquina : " + configuracion.maquina.nombre + "\r\n" +
					"Modulo  : " + Modulo.Text + "\r\n" +
					"-----------------\r\n\r\n" +
					"-----------------\r\n" +
					"Mensaje: \r\n" + 
					"-----------------\r\n" +
					Mensaje.Text + "\r\n\r\n" +
					"-----------------\r\n" +
					"Pila de Llamadas: \r\n" + 
					"-----------------\r\n" +
					PilaLlamadas.Text + "\r\n\r\n";


			
			//Envia el mail
			SMTPMail smtpMail = new SMTPMail();
			smtpMail.Identity = "datadom1";
			smtpMail.ReplyTo = configuracion.email_errores;
			smtpMail.MailFrom = configuracion.email_errores;

			smtpMail.MessageID = "<" + (Guid.NewGuid()).ToString() + ">";
			smtpMail.MailTo = configuracion.email_errores;
			smtpMail.Subject = "Ligier Errores: " + Mensaje.Text;
			smtpMail.MailData = body;

			//Primero prueba con el smtp.
			smtp = "mail.datadominus.com.ar";
			smtpMail.SMTPServerIP = smtp;
			//Ejecuta el Ping1
			//ping1 = ping.ping(smtpMail.SMTPServerIP);
			int ping1 = 1, ping2 = 0;
			if (ping1==1)
			{
				smtpMail.SendMail();
				error = smtpMail.ErrorMessage;
			}
			if (ping1!=1 || error!="")
			{
				//Ejecuta el ping2
				mail = "smtp.datadominus.com.ar";
				smtpMail.SMTPServerIP = mail;
				//ping2 = ping.ping(smtpMail.SMTPServerIP);
				ping2 = 1;
				smtpMail.ErrorMessage = "";

				if (ping2==1)
				{
					smtpMail.SendMail();
					error += "\r\n\r\n/********************** Despues del error de smtp.servidor.com *********************\r\n\r\n" +
						smtpMail.ErrorMessage;
				}
			}
			this.Cursor = Cursors.Arrow;
			//Si hubo errores en los ping
			if (smtpMail.ErrorMessage!="")
			{
				MessageBox.Show(smtpMail.ErrorMessage, "Error al enviar e-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			

/*
			//Version starndard
			MailMessage Message = new MailMessage();
			Message.To = configuracion.email_errores;
			Message.From = "chucamaster@yahoo.com";
			Message.Subject = "Ligier Errores: " + Mensaje.Text;
			Message.Body = body;

			try
			{
				SmtpMail.SmtpServer = "sqllab.ligier.corp";
				SmtpMail.Send(Message);
			}
			catch(System.Web.HttpException ehttp)
			{
				MessageBox.Show(ehttp.Message, "Error al enviar e-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
*/
			this.Close();
		}
	}
}
