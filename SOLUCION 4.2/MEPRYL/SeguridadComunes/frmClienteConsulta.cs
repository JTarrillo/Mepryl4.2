using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmClienteConsulta.
	/// </summary>
	public class frmClienteConsulta : System.Windows.Forms.Form
	{
		private Comunes.ucClienteConsulta ucClienteConsulta1;
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

		public frmClienteConsulta(Configuracion conf, bool esConsultaRapida)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmClienteConsulta));
			this.ucClienteConsulta1 = new Comunes.ucClienteConsulta();
			this.SuspendLayout();
			// 
			// ucClienteConsulta1
			// 
			this.ucClienteConsulta1.configuracion = null;
			this.ucClienteConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucClienteConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucClienteConsulta1.Name = "ucClienteConsulta1";
			this.ucClienteConsulta1.Size = new System.Drawing.Size(800, 454);
			this.ucClienteConsulta1.TabIndex = 0;
			// 
			// frmClienteConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 454);
			this.Controls.Add(this.ucClienteConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmClienteConsulta";
			this.Text = "Consulta de Clientes";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmClienteConsulta_Closing);
			this.Load += new System.EventHandler(this.frmClienteConsulta_Load);
			this.Enter += new System.EventHandler(this.frmClienteConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmClienteConsulta_Load(object sender, System.EventArgs e)
		{
			ucClienteConsulta1.statusBarPrincipal = statusBar1;
			ucClienteConsulta1.formContenedor = this;
			ucClienteConsulta1.configuracion = configuracion;
			ucClienteConsulta1.consultaRapida = this.consultaRapida;
			ucClienteConsulta1.inicializarComponentes();
		}

		private void frmClienteConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmClienteConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(ucClienteConsulta1.getID());
		}

	}
}
