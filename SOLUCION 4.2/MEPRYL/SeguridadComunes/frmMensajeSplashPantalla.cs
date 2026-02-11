using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmMensajeSplashPantalla.
	/// </summary>
	public class frmMensajeSplashPantalla : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Label lblMensaje;
		private System.Windows.Forms.Button butCancelar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public DocumentoFiscalXML documentoFiscalXML = null;

		public frmMensajeSplashPantalla(string men)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			lblMensaje.Text = men;
			this.Text = men;

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblMensaje = new System.Windows.Forms.Label();
			this.butCancelar = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.butCancelar);
			this.groupBox1.Controls.Add(this.lblMensaje);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 160);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// lblMensaje
			// 
			this.lblMensaje.Location = new System.Drawing.Point(8, 16);
			this.lblMensaje.Name = "lblMensaje";
			this.lblMensaje.Size = new System.Drawing.Size(440, 104);
			this.lblMensaje.TabIndex = 0;
			this.lblMensaje.Text = "label1";
			this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butCancelar
			// 
			this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butCancelar.Location = new System.Drawing.Point(168, 128);
			this.butCancelar.Name = "butCancelar";
			this.butCancelar.Size = new System.Drawing.Size(112, 24);
			this.butCancelar.TabIndex = 1;
			this.butCancelar.Text = "&Cancelar";
			this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click);
			// 
			// frmMensajeSplashPantalla
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 174);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmMensajeSplashPantalla";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void butCancelar_Click(object sender, System.EventArgs e)
		{
			if (documentoFiscalXML!=null)
				documentoFiscalXML.esperarRespuestaServidor = false;
		}
	}
}
