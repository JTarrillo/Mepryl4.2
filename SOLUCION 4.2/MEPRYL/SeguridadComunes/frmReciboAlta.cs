using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmReciboAlta.
	/// </summary>
	public class frmReciboAlta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private Comunes.ucReciboAlta ucReciboAlta1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReciboAlta(Configuracion conf)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReciboAlta));
			this.ucReciboAlta1 = new Comunes.ucReciboAlta();
			this.SuspendLayout();
			// 
			// ucReciboAlta1
			// 
			this.ucReciboAlta1.configuracion = null;
			this.ucReciboAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucReciboAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucReciboAlta1.Name = "ucReciboAlta1";
			this.ucReciboAlta1.Size = new System.Drawing.Size(728, 472);
			this.ucReciboAlta1.TabIndex = 0;
			// 
			// frmReciboAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 472);
			this.Controls.Add(this.ucReciboAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmReciboAlta";
			this.Text = "Alta de Recibos";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmReciboAlta_Closing);
			this.Load += new System.EventHandler(this.frmReciboAlta_Load);
			this.Enter += new System.EventHandler(this.frmReciboAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmReciboAlta_Load(object sender, System.EventArgs e)
		{
			ucReciboAlta1.statusBarPrincipal = statusBar1;
			ucReciboAlta1.formContenedor = this;
			ucReciboAlta1.configuracion = configuracion;
			ucReciboAlta1.inicializarComponentes();
		}

		private void frmReciboAlta_Enter(object sender, System.EventArgs e)
		{
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

		private void frmReciboAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}
