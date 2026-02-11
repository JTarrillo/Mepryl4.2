using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmMensajeConsulta.
	/// </summary>
	public class frmMensajeConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		private bool autoEjecutable = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Comunes.ucMensajeConsulta ucMensajeConsulta1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMensajeConsulta(Configuracion conf, bool esConsultaRapida, bool esAutoEjecutable)
		{
			//
			// Required for Windows Form Designer support
			//
			this.configuracion = conf;
			this.consultaRapida = esConsultaRapida;
			this.autoEjecutable = esAutoEjecutable;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMensajeConsulta));
			this.ucMensajeConsulta1 = new Comunes.ucMensajeConsulta();
			this.SuspendLayout();
			// 
			// ucMensajeConsulta1
			// 
			this.ucMensajeConsulta1.configuracion = null;
			this.ucMensajeConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMensajeConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucMensajeConsulta1.Name = "ucMensajeConsulta1";
			this.ucMensajeConsulta1.Size = new System.Drawing.Size(728, 358);
			this.ucMensajeConsulta1.TabIndex = 0;
			// 
			// frmMensajeConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 358);
			this.Controls.Add(this.ucMensajeConsulta1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMensajeConsulta";
			this.Text = "Mensajes Recibidos";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMensajeConsulta_Closing);
			this.Load += new System.EventHandler(this.frmMensajeConsulta_Load);
			this.Enter += new System.EventHandler(this.frmMensajeConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMensajeConsulta_Load(object sender, System.EventArgs e)
		{
			ucMensajeConsulta1.statusBarPrincipal = statusBar1;
			ucMensajeConsulta1.formContenedor = this;
			ucMensajeConsulta1.configuracion = configuracion;
			ucMensajeConsulta1.consultaRapida = this.consultaRapida;
			ucMensajeConsulta1.inicializarComponentes();
			if (this.autoEjecutable)
				ucMensajeConsulta1.autoEjecutar();
		}

		private void frmMensajeConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmMensajeConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(ucMensajeConsulta1.getProveedorID());
		}

	}
}
