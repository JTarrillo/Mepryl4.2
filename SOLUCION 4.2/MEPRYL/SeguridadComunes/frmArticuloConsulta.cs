using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmArticuloConsulta.
	/// </summary>
	public class frmArticuloConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;
		public bool fueInicializado = false;
		
		//Define el Delegado 
		public delegate bool DelegateDevolverID(string articuloID);
		public DelegateDevolverID objDelegateDevolverID = null;
		public Comunes.ucArticuloConsulta ucArticuloConsulta1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmArticuloConsulta(Configuracion conf, bool esConsultaRapida)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmArticuloConsulta));
			this.ucArticuloConsulta1 = new Comunes.ucArticuloConsulta();
			this.SuspendLayout();
			// 
			// ucArticuloConsulta1
			// 
			this.ucArticuloConsulta1.configuracion = null;
			this.ucArticuloConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucArticuloConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucArticuloConsulta1.Name = "ucArticuloConsulta1";
			this.ucArticuloConsulta1.Size = new System.Drawing.Size(800, 454);
			this.ucArticuloConsulta1.TabIndex = 0;
			// 
			// frmArticuloConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 454);
			this.Controls.Add(this.ucArticuloConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmArticuloConsulta";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consulta de Artículos";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmArticuloConsulta_Closing);
			this.Load += new System.EventHandler(this.frmArticuloConsulta_Load);
			this.Enter += new System.EventHandler(this.frmArticuloConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmArticuloConsulta_Load(object sender, System.EventArgs e)
		{
			inicializarComponentes();
		}

		public void inicializarComponentes()
		{
			if (!this.fueInicializado)
			{
				ucArticuloConsulta1.statusBarPrincipal = statusBar1;
				ucArticuloConsulta1.formContenedor = this;
				ucArticuloConsulta1.configuracion = configuracion;
				ucArticuloConsulta1.consultaRapida = this.consultaRapida;
				ucArticuloConsulta1.inicializarComponentes();
				this.fueInicializado = true;
			}
		}

		private void frmArticuloConsulta_Enter(object sender, System.EventArgs e)
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
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(ucArticuloConsulta1.getArticuloID());
		}
	}
}
