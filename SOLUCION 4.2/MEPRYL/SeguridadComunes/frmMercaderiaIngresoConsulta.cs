using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmMercaderiaIngresoConsulta.
	/// </summary>
	public class frmMercaderiaIngresoConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		
		//Define el Delegado 
		public delegate bool DelegateDevolverID(string ID);
		public DelegateDevolverID objDelegateDevolverID = null;
		private Comunes.ucMercaderiaIngresoConsulta ucMercaderiaIngresoConsulta1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMercaderiaIngresoConsulta(Configuracion conf, bool esConsultaRapida)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMercaderiaIngresoConsulta));
			this.ucMercaderiaIngresoConsulta1 = new Comunes.ucMercaderiaIngresoConsulta();
			this.SuspendLayout();
			// 
			// ucMercaderiaIngresoConsulta1
			// 
			this.ucMercaderiaIngresoConsulta1.configuracion = null;
			this.ucMercaderiaIngresoConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMercaderiaIngresoConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucMercaderiaIngresoConsulta1.Name = "ucMercaderiaIngresoConsulta1";
			this.ucMercaderiaIngresoConsulta1.Size = new System.Drawing.Size(800, 454);
			this.ucMercaderiaIngresoConsulta1.TabIndex = 0;
			// 
			// frmMercaderiaIngresoConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 454);
			this.Controls.Add(this.ucMercaderiaIngresoConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMercaderiaIngresoConsulta";
			this.Text = "Consulta de Ingresos de Mercadería";
			this.Load += new System.EventHandler(this.frmMercaderiaIngresoConsulta_Load);
			this.Enter += new System.EventHandler(this.frmMercaderiaIngresoConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMercaderiaIngresoConsulta_Load(object sender, System.EventArgs e)
		{
			ucMercaderiaIngresoConsulta1.statusBarPrincipal = statusBar1;
			ucMercaderiaIngresoConsulta1.formContenedor = this;
			ucMercaderiaIngresoConsulta1.configuracion = configuracion;
			ucMercaderiaIngresoConsulta1.consultaRapida = this.consultaRapida;
			ucMercaderiaIngresoConsulta1.inicializarComponentes();
		}

		private void frmMercaderiaIngresoConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmArticuloConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Articulo Seleccionado
			//if (objDelegateDevolverID!=null)
				//objDelegateDevolverID(ucMercaderiaIngresoConsulta1.getArticuloID());
		}
	}
}
