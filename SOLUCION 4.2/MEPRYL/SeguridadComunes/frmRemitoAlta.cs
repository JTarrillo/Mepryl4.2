using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmRemitoAlta.
	/// </summary>
	public class frmRemitoAlta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		public Comunes.ucRemitoAlta ucRemitoAlta1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRemitoAlta(Configuracion conf)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRemitoAlta));
			this.ucRemitoAlta1 = new Comunes.ucRemitoAlta();
			this.SuspendLayout();
			// 
			// ucRemitoAlta1
			// 
			this.ucRemitoAlta1.configuracion = null;
			this.ucRemitoAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucRemitoAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucRemitoAlta1.Name = "ucRemitoAlta1";
			this.ucRemitoAlta1.Size = new System.Drawing.Size(800, 454);
			this.ucRemitoAlta1.TabIndex = 0;
			// 
			// frmRemitoAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 454);
			this.Controls.Add(this.ucRemitoAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmRemitoAlta";
			this.Text = "Alta de Remitos";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmRemitoAlta_Closing);
			this.Load += new System.EventHandler(this.frmRemitoAlta_Load);
			this.Enter += new System.EventHandler(this.frmRemitoAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRemitoAlta_Load(object sender, System.EventArgs e)
		{
			ucRemitoAlta1.statusBarPrincipal = statusBar1;
			ucRemitoAlta1.formContenedor = this;
			ucRemitoAlta1.configuracion = configuracion;
			ucRemitoAlta1.inicializarComponentes();
		}

		private void frmRemitoAlta_Enter(object sender, System.EventArgs e)
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

		private void frmRemitoAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Borra los resgistros temporales
			ucRemitoAlta1.borrarRemitoTemporal();
		}
	}
}
