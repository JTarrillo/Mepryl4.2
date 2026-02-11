using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Seguridad
{
	/// <summary>
	/// Summary description for frmMaquinaAlta.
	/// </summary>
	public class frmMaquinaAlta : System.Windows.Forms.Form
	{
		private Seguridad.ucMaquinaAlta ucMaquinaAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMaquinaAlta(Configuracion conf)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMaquinaAlta));
			this.ucMaquinaAlta1 = new Seguridad.ucMaquinaAlta();
			this.SuspendLayout();
			// 
			// ucMaquinaAlta1
			// 
			this.ucMaquinaAlta1.configuracion = null;
			this.ucMaquinaAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucMaquinaAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucMaquinaAlta1.Name = "ucMaquinaAlta1";
			this.ucMaquinaAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucMaquinaAlta1.TabIndex = 0;
			// 
			// frmMaquinaAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucMaquinaAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMaquinaAlta";
			this.Text = "Alta de Máquinas";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMaquinaAlta_Closing);
			this.Load += new System.EventHandler(this.frmMaquinaAlta_Load);
			this.Enter += new System.EventHandler(this.frmMaquinaAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMaquinaAlta_Load(object sender, System.EventArgs e)
		{
			ucMaquinaAlta1.statusBarPrincipal = ((frmPrincipal)this.ParentForm).statusBar1;
			ucMaquinaAlta1.formContenedor = this;
			ucMaquinaAlta1.configuracion = configuracion;
			ucMaquinaAlta1.inicializarComponentes();
		}

		private void frmMaquinaAlta_Enter(object sender, System.EventArgs e)
		{
			((frmPrincipal)this.ParentForm).soltarBotones();
			((ToolBarButton)this.Tag).Pushed = true;
		}

		private void frmMaquinaAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			((frmPrincipal)this.ParentForm).toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}
