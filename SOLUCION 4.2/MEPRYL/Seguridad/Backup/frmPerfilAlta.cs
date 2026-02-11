using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Seguridad
{
	/// <summary>
	/// Summary description for frmPerfilAlta.
	/// </summary>
	public class frmPerfilAlta : System.Windows.Forms.Form
	{
		private Seguridad.ucPerfilAlta ucPerfilAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPerfilAlta(Configuracion conf)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPerfilAlta));
			this.ucPerfilAlta1 = new Seguridad.ucPerfilAlta();
			this.SuspendLayout();
			// 
			// ucPerfilAlta1
			// 
			this.ucPerfilAlta1.configuracion = null;
			this.ucPerfilAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucPerfilAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucPerfilAlta1.Name = "ucPerfilAlta1";
			this.ucPerfilAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucPerfilAlta1.TabIndex = 0;
			// 
			// frmPerfilAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucPerfilAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPerfilAlta";
			this.Text = "Alta de Pefil de usuario";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPerfilAlta_Closing);
			this.Load += new System.EventHandler(this.frmPerfilAlta_Load);
			this.Enter += new System.EventHandler(this.frmPerfilAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmPerfilAlta_Load(object sender, System.EventArgs e)
		{
			ucPerfilAlta1.statusBarPrincipal = ((frmPrincipal)this.ParentForm).statusBar1;
			ucPerfilAlta1.formContenedor = this;
			ucPerfilAlta1.configuracion = configuracion;
			ucPerfilAlta1.inicializarComponentes();
		}

		private void frmPerfilAlta_Enter(object sender, System.EventArgs e)
		{
			((frmPrincipal)this.ParentForm).soltarBotones();
			((ToolBarButton)this.Tag).Pushed = true;
		}

		private void frmPerfilAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			((frmPrincipal)this.ParentForm).toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}
