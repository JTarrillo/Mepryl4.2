using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmZonaAlta.
	/// </summary>
	public class frmZonaAlta : System.Windows.Forms.Form
	{
		private Comunes.ucZonaAlta ucZonaAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmZonaAlta(Configuracion conf)
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
			this.ucZonaAlta1 = new Comunes.ucZonaAlta();
			this.SuspendLayout();
			// 
			// ucZonaAlta1
			// 
			this.ucZonaAlta1.configuracion = null;
			this.ucZonaAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucZonaAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucZonaAlta1.Name = "ucZonaAlta1";
			this.ucZonaAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucZonaAlta1.TabIndex = 0;
			// 
			// frmZonaAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucZonaAlta1);
			this.Name = "frmZonaAlta";
			this.Text = "Alta de Zonas";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmZonaAlta_Closing);
			this.Load += new System.EventHandler(this.frmZonaAlta_Load);
			this.Enter += new System.EventHandler(this.frmZonaAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmZonaAlta_Load(object sender, System.EventArgs e)
		{
			ucZonaAlta1.statusBarPrincipal = statusBar1;
			ucZonaAlta1.formContenedor = this;
			ucZonaAlta1.configuracion = configuracion;
			ucZonaAlta1.inicializarComponentes();
		}

		private void frmZonaAlta_Enter(object sender, System.EventArgs e)
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

		private void frmZonaAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}