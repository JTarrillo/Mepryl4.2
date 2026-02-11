using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmFleteAlta.
	/// </summary>
	public class frmFleteAlta : System.Windows.Forms.Form
	{
		private Comunes.ucFleteAlta ucFleteAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmFleteAlta(Configuracion conf)
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
			this.ucFleteAlta1 = new Comunes.ucFleteAlta();
			this.SuspendLayout();
			// 
			// ucFleteAlta1
			// 
			this.ucFleteAlta1.configuracion = null;
			this.ucFleteAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucFleteAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucFleteAlta1.Name = "ucFleteAlta1";
			this.ucFleteAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucFleteAlta1.TabIndex = 0;
			// 
			// frmFleteAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucFleteAlta1);
			this.Name = "frmFleteAlta";
			this.Text = "Alta de Fletes";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmFleteAlta_Closing);
			this.Load += new System.EventHandler(this.frmFleteAlta_Load);
			this.Enter += new System.EventHandler(this.frmFleteAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmFleteAlta_Load(object sender, System.EventArgs e)
		{
			ucFleteAlta1.statusBarPrincipal = statusBar1;
			ucFleteAlta1.formContenedor = this;
			ucFleteAlta1.configuracion = configuracion;
			ucFleteAlta1.inicializarComponentes();
		}

		private void frmFleteAlta_Enter(object sender, System.EventArgs e)
		{
			soltarBotones();
			((ToolBarButton)this.Tag).Pushed = true;
		}

		//Suelta todos los botones de la barra de tareas
		public void soltarBotones()
		{
			foreach (ToolBarButton tbb in toolBar2.Buttons)
				tbb.Pushed = false;
		}

		private void frmFleteAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}