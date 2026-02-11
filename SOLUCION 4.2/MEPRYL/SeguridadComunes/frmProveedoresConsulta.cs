using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmProveedoresConsulta.
	/// </summary>
	public class frmProveedoresConsulta : System.Windows.Forms.Form
	{
		private Comunes.ucProveedorConsulta ucProveedorConsulta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmProveedoresConsulta(Configuracion conf, bool esConsultaRapida)
		{
			//
			// Required for Windows Form Designer support
			//
			this.configuracion = conf;
			this.consultaRapida = esConsultaRapida;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmProveedoresConsulta));
			this.ucProveedorConsulta1 = new Comunes.ucProveedorConsulta();
			this.SuspendLayout();
			// 
			// ucProveedorConsulta1
			// 
			this.ucProveedorConsulta1.configuracion = null;
			this.ucProveedorConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucProveedorConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucProveedorConsulta1.Name = "ucProveedorConsulta1";
			this.ucProveedorConsulta1.Size = new System.Drawing.Size(800, 454);
			this.ucProveedorConsulta1.TabIndex = 0;
			// 
			// frmProveedoresConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 454);
			this.Controls.Add(this.ucProveedorConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmProveedoresConsulta";
			this.Text = "Consulta de Proveedores";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmProveedoresConsulta_Closing);
			this.Load += new System.EventHandler(this.frmProveedoresConsulta_Load);
			this.Enter += new System.EventHandler(this.frnProveedoresConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmProveedoresConsulta_Load(object sender, System.EventArgs e)
		{
			ucProveedorConsulta1.statusBarPrincipal = statusBar1;
			ucProveedorConsulta1.formContenedor = this;
			ucProveedorConsulta1.configuracion = configuracion;
			ucProveedorConsulta1.consultaRapida = this.consultaRapida;
			ucProveedorConsulta1.inicializarComponentes();
		}

		private void frnProveedoresConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmProveedoresConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(ucProveedorConsulta1.getProveedorID());
		}

	}
}
