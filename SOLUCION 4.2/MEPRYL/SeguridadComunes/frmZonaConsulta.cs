using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmZonaConsulta.
	/// </summary>
	public class frmZonaConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		private bool facturaDescuento = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Comunes.ucZonaConsulta ucZonaConsulta1;
		

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmZonaConsulta(Configuracion conf, bool esConsultaRapida, bool esFacturaDescuento)
		{
			//
			// Required for Windows Form Designer support
			//
			this.configuracion = conf;
			this.consultaRapida = esConsultaRapida;
			this.facturaDescuento = esFacturaDescuento;
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
			this.ucZonaConsulta1 = new Comunes.ucZonaConsulta();
			this.SuspendLayout();
			// 
			// ucZonaConsulta1
			// 
			this.ucZonaConsulta1.configuracion = null;
			this.ucZonaConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucZonaConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucZonaConsulta1.Name = "ucZonaConsulta1";
			this.ucZonaConsulta1.Size = new System.Drawing.Size(728, 358);
			this.ucZonaConsulta1.TabIndex = 0;
			// 
			// frmZonaConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 358);
			this.Controls.Add(this.ucZonaConsulta1);
			this.Name = "frmZonaConsulta";
			this.Text = "Consulta de Zonas";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmZonaConsulta_Closing);
			this.Load += new System.EventHandler(this.frmZonaConsulta_Load);
			this.Enter += new System.EventHandler(this.frmZonaConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmZonaConsulta_Load(object sender, System.EventArgs e)
		{
			ucZonaConsulta1.statusBarPrincipal = statusBar1;
			ucZonaConsulta1.formContenedor = this;
			ucZonaConsulta1.configuracion = configuracion;
			//ucZonaConsulta1.consultaRapida = this.consultaRapida;
			ucZonaConsulta1.inicializarComponentes();
			//if (this.facturaDescuento)
			//	ucZonaConsulta1.configurarFacturaConDescuento();
		}

		private void frmZonaConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmZonaConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			//if (objDelegateDevolverID!=null)
			//	objDelegateDevolverID(ucZonaConsulta1.getProveedorID());
		}
	}
}
