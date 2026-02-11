using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmRemitoConsulta.
	/// </summary>
	public class frmRemitoConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		private bool facturaDescuento = false;
        private string tipoPresentacion = "";

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Comunes.ucRemitoConsulta ucRemitoConsulta1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRemitoConsulta(Configuracion conf, bool esConsultaRapida, string tipoPresentacion)
		{
			//
			// Required for Windows Form Designer support
			//
			this.configuracion = conf;
			this.consultaRapida = esConsultaRapida;
            this.tipoPresentacion = tipoPresentacion;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRemitoConsulta));
			this.ucRemitoConsulta1 = new Comunes.ucRemitoConsulta();
			this.SuspendLayout();
			// 
			// ucRemitoConsulta1
			// 
			this.ucRemitoConsulta1.configuracion = null;
			this.ucRemitoConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucRemitoConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucRemitoConsulta1.Name = "ucRemitoConsulta1";
			this.ucRemitoConsulta1.Size = new System.Drawing.Size(728, 358);
			this.ucRemitoConsulta1.TabIndex = 0;
			// 
			// frmRemitoConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 358);
			this.Controls.Add(this.ucRemitoConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmRemitoConsulta";
			this.Text = "Consulta de Remitos";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmRemitoConsulta_Closing);
			this.Load += new System.EventHandler(this.frmRemitoConsulta_Load);
			this.Enter += new System.EventHandler(this.frmRemitoConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmRemitoConsulta_Load(object sender, System.EventArgs e)
		{
			ucRemitoConsulta1.statusBarPrincipal = statusBar1;
			ucRemitoConsulta1.formContenedor = this;
			ucRemitoConsulta1.configuracion = configuracion;
			ucRemitoConsulta1.consultaRapida = this.consultaRapida;
            ucRemitoConsulta1.tipoPresentacion = this.tipoPresentacion;
			ucRemitoConsulta1.inicializarComponentes();
			//if (this.facturaDescuento)
			//	ucRemitoConsulta1.configurarFacturaConDescuento();
		}

		private void frmRemitoConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmRemitoConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(ucRemitoConsulta1.getProveedorID());
		}
	}
}
