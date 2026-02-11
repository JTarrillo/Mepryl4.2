using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmMensajeAlta.
	/// </summary>
	public class frmMensajeAlta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private string mensajeID = Utilidades.ID_VACIO;
		private string operacion = "";
		private Comunes.ucMensajeAlta ucMensajeAlta1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMensajeAlta(Configuracion conf)
		{
			//
			// Required for Windows Form Designer support
			//
			this.configuracion = conf;
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmMensajeAlta(Configuracion conf, string mensajeID, string operacion)
		{
			this.mensajeID = mensajeID;
			this.operacion = operacion;
			
			this.configuracion = conf;
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMensajeAlta));
			this.ucMensajeAlta1 = new Comunes.ucMensajeAlta();
			this.SuspendLayout();
			// 
			// ucMensajeAlta1
			// 
			this.ucMensajeAlta1.configuracion = null;
			this.ucMensajeAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMensajeAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucMensajeAlta1.Name = "ucMensajeAlta1";
			this.ucMensajeAlta1.Size = new System.Drawing.Size(816, 472);
			this.ucMensajeAlta1.TabIndex = 0;
			// 
			// frmMensajeAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 472);
			this.Controls.Add(this.ucMensajeAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMensajeAlta";
			this.Text = "Nuevo Mensaje";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMensajeAlta_Closing);
			this.Load += new System.EventHandler(this.frmMensajeAlta_Load);
			this.Enter += new System.EventHandler(this.frmMensajeAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMensajeAlta_Load(object sender, System.EventArgs e)
		{
			ucMensajeAlta1.statusBarPrincipal = statusBar1;
			ucMensajeAlta1.formContenedor = this;
			ucMensajeAlta1.configuracion = configuracion;
			ucMensajeAlta1.mensajeID = this.mensajeID;
			ucMensajeAlta1.operacion = this.operacion;
			ucMensajeAlta1.inicializarComponentes();
		}

		private void frmMensajeAlta_Enter(object sender, System.EventArgs e)
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

		private void frmMensajeAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}
