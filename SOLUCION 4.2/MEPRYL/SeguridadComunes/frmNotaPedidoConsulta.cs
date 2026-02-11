using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmNotaPedidoConsulta.
	/// </summary>
	public class frmNotaPedidoConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		private bool suspendidas = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Comunes.ucNotaPedidoConsulta ucNotaPedidoConsulta1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNotaPedidoConsulta(Configuracion conf, bool esConsultaRapida, bool esSuspendidas)
		{
			//
			// Required for Windows Form Designer support
			//
			this.configuracion = conf;
			this.consultaRapida = esConsultaRapida;
			this.suspendidas = esSuspendidas;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNotaPedidoConsulta));
			this.ucNotaPedidoConsulta1 = new Comunes.ucNotaPedidoConsulta();
			this.SuspendLayout();
			// 
			// ucNotaPedidoConsulta1
			// 
			this.ucNotaPedidoConsulta1.configuracion = null;
			this.ucNotaPedidoConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucNotaPedidoConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucNotaPedidoConsulta1.Name = "ucNotaPedidoConsulta1";
			this.ucNotaPedidoConsulta1.Size = new System.Drawing.Size(728, 358);
			this.ucNotaPedidoConsulta1.TabIndex = 0;
			// 
			// frmNotaPedidoConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 358);
			this.Controls.Add(this.ucNotaPedidoConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmNotaPedidoConsulta";
			this.Text = "Consulta de Notas de Pedido";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmNotaPedidoConsulta_Closing);
			this.Load += new System.EventHandler(this.frmNotaPedidoConsulta_Load);
			this.Enter += new System.EventHandler(this.frmNotaPedidoConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmNotaPedidoConsulta_Load(object sender, System.EventArgs e)
		{
			ucNotaPedidoConsulta1.statusBarPrincipal = statusBar1;
			ucNotaPedidoConsulta1.formContenedor = this;
			ucNotaPedidoConsulta1.configuracion = configuracion;
			ucNotaPedidoConsulta1.consultaRapida = this.consultaRapida;
			ucNotaPedidoConsulta1.inicializarComponentes();
			if (this.suspendidas)
				ucNotaPedidoConsulta1.configurarNotaPedidoSuspendidas();
		}

		private void frmNotaPedidoConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmNotaPedidoConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(ucNotaPedidoConsulta1.getProveedorID());
		}
	}
}
