using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmFacturaConsulta.
	/// </summary>
	public class frmFacturaConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		//private bool facturaDescuento = false;
        private string tipoPresentacion = "";
        public string clienteID = "";
        public Control controlContenedorResultados;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(Configuracion configuracion, string ID, ref Control controlContenedorResultados);
		public DelegateDevolverID objDelegateDevolverID = null;
        private Comunes.ucFacturaConsulta ucFacturaConsulta1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmFacturaConsulta(Configuracion conf, bool esConsultaRapida, string  tipoPresentacion)
		{
			//
			// Required for Windows Form Designer support
			//
			this.configuracion = conf;
			this.consultaRapida = esConsultaRapida;
			//this.facturaDescuento = esFacturaDescuento;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturaConsulta));
            this.ucFacturaConsulta1 = new Comunes.ucFacturaConsulta();
            this.SuspendLayout();
            // 
            // ucFacturaConsulta1
            // 
            this.ucFacturaConsulta1.configuracion = null;
            this.ucFacturaConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFacturaConsulta1.Location = new System.Drawing.Point(0, 0);
            this.ucFacturaConsulta1.Name = "ucFacturaConsulta1";
            this.ucFacturaConsulta1.Size = new System.Drawing.Size(728, 441);
            this.ucFacturaConsulta1.TabIndex = 0;
            // 
            // frmFacturaConsulta
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(728, 441);
            this.Controls.Add(this.ucFacturaConsulta1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFacturaConsulta";
            this.Text = "Consulta de Facturas";
            this.Enter += new System.EventHandler(this.frmFacturaConsulta_Enter);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmFacturaConsulta_Closing);
            this.Load += new System.EventHandler(this.frmFacturaConsulta_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmFacturaConsulta_Load(object sender, System.EventArgs e)
		{
			ucFacturaConsulta1.statusBarPrincipal = statusBar1;
			ucFacturaConsulta1.formContenedor = this;
			ucFacturaConsulta1.configuracion = configuracion;
			ucFacturaConsulta1.consultaRapida = this.consultaRapida;
            ucFacturaConsulta1.tipoPresentacion = this.tipoPresentacion;
            ucFacturaConsulta1.clienteID = this.clienteID;
			ucFacturaConsulta1.inicializarComponentes();
			//if (this.facturaDescuento)
			//	ucFacturaConsulta1.configurarFacturaConDescuento();
		}

		private void frmFacturaConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmFacturaConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(this.configuracion, ucFacturaConsulta1.getID(), ref this.controlContenedorResultados);
		}

       
	}
}
