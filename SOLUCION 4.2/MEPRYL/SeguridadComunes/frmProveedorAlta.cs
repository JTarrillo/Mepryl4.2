using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmProveedorAlta.
	/// </summary>
	public class frmProveedorAlta : System.Windows.Forms.Form
	{
		private Comunes.ucProveedor ucProveedorAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmProveedorAlta(Configuracion conf)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmProveedorAlta));
			this.ucProveedorAlta1 = new Comunes.ucProveedor();
			this.SuspendLayout();
			// 
			// ucProveedorAlta1
			// 
			this.ucProveedorAlta1.configuracion = null;
			this.ucProveedorAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucProveedorAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucProveedorAlta1.Name = "ucProveedorAlta1";
			this.ucProveedorAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucProveedorAlta1.TabIndex = 0;
			// 
			// frmProveedorAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucProveedorAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmProveedorAlta";
			this.Text = "Alta de Proveedores";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmProveedorAlta_Closing);
			this.Load += new System.EventHandler(this.frmProveedorAlta_Load);
			this.Enter += new System.EventHandler(this.frmProveedorAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmProveedorAlta_Load(object sender, System.EventArgs e)
		{
			ucProveedorAlta1.statusBarPrincipal = statusBar1;
			ucProveedorAlta1.formContenedor = this;
			ucProveedorAlta1.configuracion = configuracion;
			ucProveedorAlta1.inicializarComponentes();
		}

		private void frmProveedorAlta_Enter(object sender, System.EventArgs e)
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

		private void frmProveedorAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}