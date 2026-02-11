using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmAvisosTransparente.
	/// </summary>
	public class frmAvisosTransparente : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Label lbMensaje = null;
		private Form formulario = null;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;

		public frmAvisosTransparente(string mensaje, ref Form formularioMostrar)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lbMensaje.Text = mensaje;
			this.formulario = formularioMostrar;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAvisosTransparente));
			this.lbMensaje = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// lbMensaje
			// 
			this.lbMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbMensaje.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbMensaje.Location = new System.Drawing.Point(0, 0);
			this.lbMensaje.Name = "lbMensaje";
			this.lbMensaje.Size = new System.Drawing.Size(184, 96);
			this.lbMensaje.TabIndex = 0;
			this.lbMensaje.Text = "Ha recibido un nuevo mensaje";
			this.lbMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbMensaje.Click += new System.EventHandler(this.lbMensaje_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 180000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(160, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// frmAvisosTransparente
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(184, 96);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lbMensaje);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmAvisosTransparente";
			this.Opacity = 0.8;
			this.ShowInTaskbar = false;
			this.Text = "frmAvisosTransparente";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.SystemColors.Control;
			this.ResumeLayout(false);

		}
		#endregion

		private void lbMensaje_Click(object sender, System.EventArgs e)
		{
			this.formulario.Select();
			this.Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			this.formulario.Select();
			this.Close();
		}
	}
}
