using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmClienteCtaCte.
	/// </summary>
	public class frmClienteCtaCte : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		private bool facturaDescuento = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Comunes.ucClienteCtaCte ucClienteCtaCte1;
		

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmClienteCtaCte(Configuracion conf, bool esConsultaRapida, bool esFacturaDescuento)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmClienteCtaCte));
			this.ucClienteCtaCte1 = new Comunes.ucClienteCtaCte();
			this.SuspendLayout();
			// 
			// ucClienteCtaCte1
			// 
			this.ucClienteCtaCte1.configuracion = null;
			this.ucClienteCtaCte1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucClienteCtaCte1.Location = new System.Drawing.Point(0, 0);
			this.ucClienteCtaCte1.Name = "ucClienteCtaCte1";
			this.ucClienteCtaCte1.Size = new System.Drawing.Size(824, 366);
			this.ucClienteCtaCte1.TabIndex = 0;
			// 
			// frmClienteCtaCte
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(824, 366);
			this.Controls.Add(this.ucClienteCtaCte1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmClienteCtaCte";
			this.Text = "Cuenta Corriente de Clientes";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmClienteCtaCte_Closing);
			this.Load += new System.EventHandler(this.frmClienteCtaCte_Load);
			this.Enter += new System.EventHandler(this.frmClienteCtaCte_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmClienteCtaCte_Load(object sender, System.EventArgs e)
		{
			ucClienteCtaCte1.statusBarPrincipal = statusBar1;
			ucClienteCtaCte1.formContenedor = this;
			ucClienteCtaCte1.configuracion = configuracion;
			//ucClienteCtaCte1.consultaRapida = this.consultaRapida;
			ucClienteCtaCte1.inicializarComponentes();
			//if (this.facturaDescuento)
			//	ucClienteCtaCte1.configurarFacturaConDescuento();
		}

		private void frmClienteCtaCte_Enter(object sender, System.EventArgs e)
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

		private void frmClienteCtaCte_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			//if (objDelegateDevolverID!=null)
			//	objDelegateDevolverID(ucClienteCtaCte1.getProveedorID());
		}
	}
}
