using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Comunes;

namespace Seguridad
{
	/// <summary>
	/// Summary description for frmUsuarioAlta.
	/// </summary>
	public class frmUsuarioAlta : System.Windows.Forms.Form
	{
		private Seguridad.ucUsuarioAlta ucUsuarioAlta1;
		private Configuracion configuracion;
		public StatusBar statusBar1 = null;
		public ToolBar toolBar2 = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUsuarioAlta(Configuracion conf)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUsuarioAlta));
			this.ucUsuarioAlta1 = new Seguridad.ucUsuarioAlta();
			this.SuspendLayout();
			// 
			// ucUsuarioAlta1
			// 
			this.ucUsuarioAlta1.configuracion = null;
			this.ucUsuarioAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucUsuarioAlta1.Location = new System.Drawing.Point(0, 0);
			this.ucUsuarioAlta1.Name = "ucUsuarioAlta1";
			this.ucUsuarioAlta1.Size = new System.Drawing.Size(816, 462);
			this.ucUsuarioAlta1.TabIndex = 0;
			// 
			// frmUsuarioAlta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Controls.Add(this.ucUsuarioAlta1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmUsuarioAlta";
			this.Text = "Alta de Usuarios";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmUsuarioAlta_Closing);
			this.Load += new System.EventHandler(this.frmUsuarioAlta_Load);
			this.Enter += new System.EventHandler(this.frmUsuarioAlta_Enter);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmUsuarioAlta_Load(object sender, System.EventArgs e)
		{
			ucUsuarioAlta1.statusBarPrincipal = ((frmPrincipal)this.ParentForm).statusBar1;
			ucUsuarioAlta1.formContenedor = this;
			ucUsuarioAlta1.configuracion = configuracion;
			ucUsuarioAlta1.inicializarComponentes();
		}

		private void frmUsuarioAlta_Enter(object sender, System.EventArgs e)
		{
			((frmPrincipal)this.ParentForm).soltarBotones();
			((ToolBarButton)this.Tag).Pushed = true;
		}

		private void frmUsuarioAlta_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			((frmPrincipal)this.ParentForm).toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
		}
	}
}
