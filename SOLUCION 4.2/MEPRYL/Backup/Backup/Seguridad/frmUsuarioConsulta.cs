using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Seguridad
{
	/// <summary>
	/// Summary description for frmUsuarioConsulta.
	/// </summary>
	public class frmUsuarioConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Seguridad.ucUsuarioConsulta ucUsuarioConsulta1;
		//private Seguridad.ucUsuarioConsulta ucUsuarioConsulta1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUsuarioConsulta(Configuracion conf, bool esConsultaRapida)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUsuarioConsulta));
			this.ucUsuarioConsulta1 = new Seguridad.ucUsuarioConsulta();
			this.SuspendLayout();
			// 
			// ucUsuarioConsulta1
			// 
			this.ucUsuarioConsulta1.configuracion = null;
			this.ucUsuarioConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucUsuarioConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucUsuarioConsulta1.Name = "ucUsuarioConsulta1";
			this.ucUsuarioConsulta1.Size = new System.Drawing.Size(728, 358);
			this.ucUsuarioConsulta1.TabIndex = 0;
			// 
			// frmUsuarioConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 358);
			this.Controls.Add(this.ucUsuarioConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmUsuarioConsulta";
			this.Text = "Consulta de Usuarios";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmUsuarioConsulta_Closing);
			this.Load += new System.EventHandler(this.frmUsuarioConsulta_Load);
			this.Enter += new System.EventHandler(this.frmUsuarioConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmUsuarioConsulta_Load(object sender, System.EventArgs e)
		{
			ucUsuarioConsulta1.statusBarPrincipal = statusBar1;
			ucUsuarioConsulta1.formContenedor = this;
			ucUsuarioConsulta1.configuracion = configuracion;
			//ucUsuarioConsulta1.consultaRapida = this.consultaRapida;
			ucUsuarioConsulta1.inicializarComponentes();
		}

		private void frmUsuarioConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmUsuarioConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			//if (objDelegateDevolverID!=null)
			//	objDelegateDevolverID(ucUsuarioConsulta1.getProveedorID());
		}
	}
}
