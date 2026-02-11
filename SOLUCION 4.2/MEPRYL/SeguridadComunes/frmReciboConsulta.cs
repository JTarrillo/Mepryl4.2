using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for frmReciboConsulta.
	/// </summary>
	public class frmReciboConsulta : System.Windows.Forms.Form
	{
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		private bool consultaRapida = false;

		//Define el Delegado 
		public delegate bool DelegateDevolverID(string reciboID);
		public DelegateDevolverID objDelegateDevolverID = null;

		private Comunes.ucReciboConsulta ucReciboConsulta1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReciboConsulta(Configuracion conf, bool esConsultaRapida)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReciboConsulta));
			this.ucReciboConsulta1 = new Comunes.ucReciboConsulta();
			this.SuspendLayout();
			// 
			// ucReciboConsulta1
			// 
			this.ucReciboConsulta1.configuracion = null;
			this.ucReciboConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucReciboConsulta1.Location = new System.Drawing.Point(0, 0);
			this.ucReciboConsulta1.Name = "ucReciboConsulta1";
			this.ucReciboConsulta1.Size = new System.Drawing.Size(736, 376);
			this.ucReciboConsulta1.TabIndex = 0;
			// 
			// frmReciboConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(736, 376);
			this.Controls.Add(this.ucReciboConsulta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmReciboConsulta";
			this.Text = "Consulta de Recibos";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmReciboConsulta_Closing);
			this.Load += new System.EventHandler(this.frmReciboConsulta_Load);
			this.Enter += new System.EventHandler(this.frmReciboConsulta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmReciboConsulta_Load(object sender, System.EventArgs e)
		{
			ucReciboConsulta1.statusBarPrincipal = statusBar1;
			ucReciboConsulta1.formContenedor = this;
			ucReciboConsulta1.configuracion = configuracion;
			ucReciboConsulta1.consultaRapida = this.consultaRapida;
			ucReciboConsulta1.inicializarComponentes();
		}

		private void frmReciboConsulta_Enter(object sender, System.EventArgs e)
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

		private void frmReciboConsulta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Elimina el boton de la barra de tareas
			if (this.toolBar2!=null)
				this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

			//Devuelve el ID del Remito Seleccionado
			if (objDelegateDevolverID!=null)
				objDelegateDevolverID(ucReciboConsulta1.getID());
		}

	}
}
