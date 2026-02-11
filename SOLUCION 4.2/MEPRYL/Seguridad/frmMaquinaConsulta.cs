using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Seguridad
{
	/// <summary>
	/// Summary description for frmMaquinaConsulta.
	/// </summary>
	public class frmMaquinaConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Seguridad.ucMaquinaConsulta ucMaquinaConsulta1;
		//private Seguridad.ucMaquinaConsulta ucMaquinaConsulta1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMaquinaConsulta(Configuracion conf, bool esConsultaRapida)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMaquinaConsulta));
			this.ucMaquinaConsulta1 = new Seguridad.ucMaquinaConsulta();
			this.SuspendLayout();
			// 
			// ucMaquinaConsulta1
			// 
			this.ucMaquinaConsulta1.configuracion = null;
			this.ucMaquinaConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMaquinaConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucMaquinaConsulta1.Name = "ucMaquinaConsulta1";
			this.ucMaquinaConsulta1.Size = new System.Drawing.Size(728, 358);
			this.ucMaquinaConsulta1.TabIndex = 0;
			// 
			// frmMaquinaConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 358);
			this.Controls.Add(this.ucMaquinaConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMaquinaConsulta";
			this.Text = "Consulta de Máquinas";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMaquinaConsulta_Closing);
			this.Load += new System.EventHandler(this.frmMaquinaConsulta_Load);
			this.Enter += new System.EventHandler(this.frmMaquinaConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMaquinaConsulta_Load(object sender, System.EventArgs e)
		{
			ucMaquinaConsulta1.statusBarPrincipal = statusBar1;
			ucMaquinaConsulta1.formContenedor = this;
			ucMaquinaConsulta1.configuracion = configuracion;
			//ucMaquinaConsulta1.consultaRapida = this.consultaRapida;
			ucMaquinaConsulta1.inicializarComponentes();
		}

		private void frmMaquinaConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmMaquinaConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			//if (objDelegateDevolverID!=null)
			//	objDelegateDevolverID(ucMaquinaConsulta1.getProveedorID());
		}
	}
}
