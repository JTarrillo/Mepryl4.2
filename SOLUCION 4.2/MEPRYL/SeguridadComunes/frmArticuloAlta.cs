using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmArticuloAlta.
	/// </summary>
	public class frmArticuloAlta : System.Windows.Forms.Form
	{
		private Comunes.ucArticuloAlta ucArticuloAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmArticuloAlta(Configuracion conf)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmArticuloAlta));
			this.ucArticuloAlta1 = new Comunes.ucArticuloAlta();
			this.SuspendLayout();
			// 
			// ucArticuloAlta1
			// 
			this.ucArticuloAlta1.configuracion = null;
			this.ucArticuloAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucArticuloAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucArticuloAlta1.Name = "ucArticuloAlta1";
			this.ucArticuloAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucArticuloAlta1.TabIndex = 0;
			// 
			// frmArticuloAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucArticuloAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmArticuloAlta";
			this.Text = "Alta de Artículos";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmArticuloAlta_Closing);
			this.Load += new System.EventHandler(this.frmArticuloAlta_Load);
			this.Enter += new System.EventHandler(this.frmArticuloAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmArticuloAlta_Load(object sender, System.EventArgs e)
		{
			//ucArticuloAlta1.statusBarPrincipal = ((frmPrincipal)this.ParentForm).statusBar1;
			ucArticuloAlta1.statusBarPrincipal = statusBar1;
			ucArticuloAlta1.formContenedor = this;
			ucArticuloAlta1.configuracion = configuracion;
			ucArticuloAlta1.inicializarComponentes();
		}

		private void frmArticuloAlta_Enter(object sender, System.EventArgs e)
		{
			//((frmPrincipal)this.ParentForm).soltarBotones();
			if (toolBar2!=null)
			{
				soltarBotones();
				((ToolBarButton)this.Tag).Pushed = true;
			}
		}

		//Suelta todos los botones de la barra de tareas
		public void soltarBotones()
		{
			foreach (ToolBarButton tbb in toolBar2.Buttons)
				tbb.Pushed = false;
		}


		private void frmArticuloAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//((frmPrincipal)this.ParentForm).toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
			
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}
