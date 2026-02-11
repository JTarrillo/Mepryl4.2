using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Comunes;

namespace Seguridad
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmPrincipal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem2;
		public System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar toolBar1;
		public System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolBar toolBar2;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ToolBarButton tbbUsuarios;
		private System.Windows.Forms.ContextMenu cmUsuario;
		private System.Windows.Forms.ToolBarButton tbbPerfiles;
		private System.Windows.Forms.ContextMenu cmPerfil;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.ContextMenu cmMaquinas;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbbMaquinas;
		public Configuracion configuracion = new Configuracion();

		public frmPrincipal()
		{
			//
			// Required for Windows Form Designer support
			//
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
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrincipal));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbUsuarios = new System.Windows.Forms.ToolBarButton();
			this.cmUsuario = new System.Windows.Forms.ContextMenu();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.tbbPerfiles = new System.Windows.Forms.ToolBarButton();
			this.cmPerfil = new System.Windows.Forms.ContextMenu();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.toolBar2 = new System.Windows.Forms.ToolBar();
			this.cmMaquinas = new System.Windows.Forms.ContextMenu();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbMaquinas = new System.Windows.Forms.ToolBarButton();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem2});
			this.menuItem1.Text = "&Archivo";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Text = "-";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "&Salir";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem4,
																					  this.menuItem9});
			this.menuItem3.Text = "Mensajes";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "Escribir Mensaje";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click_1);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "Mensajes Recibidos";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbUsuarios,
																						this.tbbPerfiles,
																						this.toolBarButton1,
																						this.tbbMaquinas});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(584, 28);
			this.toolBar1.TabIndex = 3;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbUsuarios
			// 
			this.tbbUsuarios.DropDownMenu = this.cmUsuario;
			this.tbbUsuarios.ImageIndex = 0;
			this.tbbUsuarios.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbbUsuarios.Text = "Usuarios";
			this.tbbUsuarios.ToolTipText = "Consulta de Usuarios";
			// 
			// cmUsuario
			// 
			this.cmUsuario.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem7,
																					  this.menuItem8});
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 0;
			this.menuItem7.Text = "Nuevo Usuario";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.Text = "Consulta de Usuarios";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// tbbPerfiles
			// 
			this.tbbPerfiles.DropDownMenu = this.cmPerfil;
			this.tbbPerfiles.ImageIndex = 1;
			this.tbbPerfiles.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbbPerfiles.Text = "Perfiles";
			this.tbbPerfiles.ToolTipText = "Consulta de Perfiles de Usuario";
			// 
			// cmPerfil
			// 
			this.cmPerfil.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem5,
																					 this.menuItem6});
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "Nuevo Perfil de Usuario";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click_1);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "Consulta  de Perfiles de Usuario";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click_1);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 244);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2,
																						  this.statusBarPanel3});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(584, 22);
			this.statusBar1.TabIndex = 5;
			this.statusBar1.Visible = false;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 200;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel2.Width = 30;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel3.Width = 400;
			// 
			// toolBar2
			// 
			this.toolBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolBar2.DropDownArrows = true;
			this.toolBar2.ImageList = this.imageList1;
			this.toolBar2.Location = new System.Drawing.Point(0, 216);
			this.toolBar2.Name = "toolBar2";
			this.toolBar2.ShowToolTips = true;
			this.toolBar2.Size = new System.Drawing.Size(584, 28);
			this.toolBar2.TabIndex = 7;
			this.toolBar2.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar2.Wrappable = false;
			this.toolBar2.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar2_ButtonClick);
			// 
			// cmMaquinas
			// 
			this.cmMaquinas.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem11,
																					   this.menuItem12});
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 0;
			this.menuItem11.Text = "Nueva Máquina";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 1;
			this.menuItem12.Text = "Consulta de Máquinas";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbMaquinas
			// 
			this.tbbMaquinas.DropDownMenu = this.cmMaquinas;
			this.tbbMaquinas.ImageIndex = 4;
			this.tbbMaquinas.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbbMaquinas.Text = "Máquinas";
			this.tbbMaquinas.ToolTipText = "Máquinas";
			// 
			// frmPrincipal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 266);
			this.Controls.Add(this.toolBar2);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "frmPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seguridad";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPrincipal_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmPrincipal());
		}

		//Asegura que haya solo una instancia de cada formulario
		public Form abrirFormulario(string nombre)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;

				Form frmProv = null;
				foreach (Form frm in this.MdiChildren)
				{
					if (frm.Name==nombre)
					{
						frmProv = frm;
						break;
					}
				}

				string etiquetaBoton = "";
				int imageIndex = 0;
				if (frmProv==null)
				{
					switch (nombre)
					{
						case "frmUsuarioAlta":
						{
							frmProv = new frmUsuarioAlta(configuracion);
							((frmUsuarioAlta)frmProv).statusBar1 = this.statusBar1;
							((frmUsuarioAlta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Nuevo Usuario";
							imageIndex = 0;
							break;
						}
						case "frmPerfilAlta":
						{
							frmProv = new frmPerfilAlta(configuracion);
							((frmPerfilAlta)frmProv).statusBar1 = this.statusBar1;
							((frmPerfilAlta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Nuevo Perfil";
							imageIndex = 1;
							break;
						}
						case "frmPerfilConsulta":
						{
							frmProv = new frmPerfilConsulta(configuracion, false);
							((frmPerfilConsulta)frmProv).statusBar1 = this.statusBar1;
							((frmPerfilConsulta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Consulta Perfiles de usuario";
							imageIndex = 1;
							break;
						}
						case "frmUsuarioConsulta":
						{
							frmProv = new frmUsuarioConsulta(configuracion, false);
							((frmUsuarioConsulta)frmProv).statusBar1 = this.statusBar1;
							((frmUsuarioConsulta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Consulta de Usuarios";
							imageIndex = 0;
							break;
						}
						case "frmMensajeAlta":
						{
							frmProv = new frmMensajeAlta(configuracion);
							((frmMensajeAlta)frmProv).statusBar1 = this.statusBar1;
							((frmMensajeAlta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Nuevo Mensaje";
							imageIndex = 2;
							break;
						}
						case "frmMensajeConsulta":
						{
							frmProv = new frmMensajeConsulta(configuracion, false, true);
							((frmMensajeConsulta)frmProv).statusBar1 = this.statusBar1;
							((frmMensajeConsulta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Mensajes Recibidos";
							imageIndex = 3;
							break;
						}
						case "frmMaquinaAlta":
						{
							frmProv = new frmMaquinaAlta(configuracion);
							((frmMaquinaAlta)frmProv).statusBar1 = this.statusBar1;
							((frmMaquinaAlta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Nueva Máquina";
							imageIndex = 4;
							break;
						}
						case "frmMaquinaConsulta":
						{
							frmProv = new frmMaquinaConsulta(configuracion, false);
							((frmMaquinaConsulta)frmProv).statusBar1 = this.statusBar1;
							((frmMaquinaConsulta)frmProv).toolBar2 = this.toolBar2; 
							etiquetaBoton = "Consulta Máquinas";
							imageIndex = 4;
							break;
						}
	
					}
					frmProv.MdiParent = this;
					frmProv.WindowState = FormWindowState.Maximized;
				
				}

				if (etiquetaBoton!="")
				{
					//Agrega el boton en la barra inferior
					ToolBarButton tbb = new ToolBarButton(etiquetaBoton);
					tbb.ImageIndex = imageIndex;
					tbb.Style = ToolBarButtonStyle.ToggleButton;
					tbb.Pushed = true;
					toolBar2.Buttons.Add(tbb);

					//Asigna las referencias mutuas
					frmProv.Tag = tbb;
					tbb.Tag = frmProv;
				}

				frmProv.Show();
				frmProv.Focus();
				//Presiona el boton
				soltarBotones();
				((ToolBarButton)frmProv.Tag).Pushed = true;

				this.Cursor = Cursors.Arrow;

				return frmProv;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		//Suelta todos los botones de la barra de tareas
		public void soltarBotones()
		{
			try
			{
				foreach (ToolBarButton tbb in toolBar2.Buttons)
					tbb.Pushed = false;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void toolBar2_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			try
			{
				bool pushed = e.Button.Pushed;

				soltarBotones();

				e.Button.Pushed = pushed;

				//Estabece el foco en el formulario
				if (e.Button.Pushed)
					((Form)e.Button.Tag).Select();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			try
			{
				switch (e.Button.Text)
				{
					case "Usuarios" : 
					case "Consulta de Usuarios":
						abrirFormulario("frmUsuarioConsulta");
						break;
					case "Nuevo Usuario" : 
						abrirFormulario("frmUsuarioAlta");
						break;
					case "Perfiles" : 
					case "Consulta de Perfiles de Usuario":
						abrirFormulario("frmPerfilConsulta");
						break;
					case "Nuevo Perfil" : 
						abrirFormulario("frmPerfilAlta");
						break;
					case "Máquinas" : 
						abrirFormulario("frmMaquinaConsulta");
						break;

				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			abrirFormulario("frmMercaderiaIngreso");
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			abrirFormulario("frmMercaderiaIngresoConsulta");
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			abrirFormulario("frmUsuarioAlta");
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			abrirFormulario("frmUsuarioConsulta");
		}

		private void menuItem5_Click_1(object sender, System.EventArgs e)
		{
			abrirFormulario("frmPerfilAlta");
		}

		private void frmPrincipal_Load(object sender, System.EventArgs e)
		{
			try
			{
				//Crea el formulario de login
				frmLogin form = new frmLogin(this.configuracion);

				//Crea y asigna el Delegate
				form.objDelegateDevolverID = new Comunes.frmLogin.DelegateDevolverID(usuarioValidado);
			
				form.ShowDialog();

				if (form.DialogResult==DialogResult.OK)
				{
					//Carga el formulario de consulta de mensajes
					abrirFormulario("frmMensajeConsulta");
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Define si el usuario fue validado o no
		private void usuarioValidado(Usuario usuario)
		{
			try
			{
				this.configuracion.usuario = usuario;

				if (usuario==null)
				{
					this.Close();
				}

				//Toma el nombre del usuario
				this.Text = this.Text + " - " + usuario.apellido + ", " + usuario.nombre;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void menuItem6_Click_1(object sender, System.EventArgs e)
		{
			abrirFormulario("frmPerfilConsulta");
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItem4_Click_1(object sender, System.EventArgs e)
		{
			abrirFormulario("frmMensajeAlta");
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			abrirFormulario("frmMensajeConsulta");
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			abrirFormulario("frmMaquinaAlta");
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			abrirFormulario("frmMaquinaConsulta");
		}
	}
}
