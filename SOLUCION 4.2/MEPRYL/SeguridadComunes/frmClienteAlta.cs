using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmClienteAlta.
	/// </summary>
	public class frmClienteAlta : System.Windows.Forms.Form
	{
		private Comunes.ucClienteAlta ucClienteAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
        private bool consultaRapida = false;
        public string clienteID = "";
        public Control controlContenedorResultados;

        //Define el Delegado 
        public delegate bool DelegateDevolverID(Configuracion configuracion, string ID, ref Control controlContenedorResultados);
        public DelegateDevolverID objDelegateDevolverID = null;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmClienteAlta(Configuracion conf, bool esConsultaRapida)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmClienteAlta));
			this.ucClienteAlta1 = new Comunes.ucClienteAlta();
			this.SuspendLayout();
			// 
			// ucClienteAlta1
			// 
			this.ucClienteAlta1.configuracion = null;
			this.ucClienteAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucClienteAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucClienteAlta1.Name = "ucClienteAlta1";
			this.ucClienteAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucClienteAlta1.TabIndex = 0;
			// 
			// frmClienteAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucClienteAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmClienteAlta";
			this.Text = "Alta de Clientes";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmClienteAlta_Closing);
			this.Load += new System.EventHandler(this.frmClienteAlta_Load);
			this.Enter += new System.EventHandler(this.frmClienteAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmClienteAlta_Load(object sender, System.EventArgs e)
		{
			ucClienteAlta1.statusBarPrincipal = statusBar1;
			ucClienteAlta1.formContenedor = this;
			ucClienteAlta1.configuracion = configuracion;
            ucClienteAlta1.consultaRapida = this.consultaRapida;
            //ucClienteAlta1.clienteID = this.clienteID;
			ucClienteAlta1.inicializarComponentes("");
		}

		private void frmClienteAlta_Enter(object sender, System.EventArgs e)
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

		private void frmClienteAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

            //Devuelve el ID del nuevo Cliente
            if (objDelegateDevolverID != null)
                objDelegateDevolverID(this.configuracion, ucClienteAlta1.getID(), ref this.controlContenedorResultados);
		}
	}
}
