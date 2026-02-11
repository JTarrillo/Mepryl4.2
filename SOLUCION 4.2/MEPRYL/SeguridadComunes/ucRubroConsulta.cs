using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Threading;

namespace Comunes
{
	/// <summary>
	/// Summary description for ucRubroConsulta.
	/// </summary>
	public class ucRubroConsulta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button butVistaPrevia;
		private System.Windows.Forms.Button butImprimir;
		private System.Windows.Forms.Button butBorrar;
		private System.Windows.Forms.DataGrid dgItems;
		private System.Windows.Forms.TabControl tabFiltro;
		private System.Windows.Forms.TabPage tabFiltro1;
		private System.Windows.Forms.Button butSalir1;
		private System.Windows.Forms.Button butLimpiar1;
		private System.Windows.Forms.Button butBuscar1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbRubroB;
		private System.Windows.Forms.CheckedListBox clbCampos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dgSubRubros;
		private System.Windows.Forms.TextBox tbRubro;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button butLimpiar;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lblRegistro;
		private System.Windows.Forms.Button butSiguiente;
		private System.Windows.Forms.Button butAnterior;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		private DataRow[] ultimosCampos;
		private bool recordarCambios = true;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn tbDescripcion;
		private System.Windows.Forms.GroupBox gbModificacion;
		private DataTable tablaCampos = null;
		public DataSet dataset = (DataSet) new dsRubros();
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.Button butBorrarSubRubros;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.ImageList imagenesTab;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ComboBox cbCampo5;
		private System.Windows.Forms.ComboBox cbCampo4;
		private System.Windows.Forms.ComboBox cbCampo3;
		private System.Windows.Forms.ComboBox cbCampo2;
		private System.Windows.Forms.ComboBox cbCampo1;
		private System.Windows.Forms.TextBox tbDescripcionArticulo;
		private System.ComponentModel.IContainer components;

		private bool habilitarHandlerCombos = true;
		private bool habilitarHandlerRowChanged = true;
		private System.Windows.Forms.GroupBox gbDescripcion;
		private System.Windows.Forms.Label lblTituloCampos;
		public static bool combosEstanOcupadas = false;

		public ucRubroConsulta()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		public Configuracion configuracion
		{
			get
			{
				return m_configuracion;
			}
			set
			{
				m_configuracion = value;
				if (m_configuracion!=null)
					conexion = m_configuracion.getConectionString();
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRubroConsulta));
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butVistaPrevia = new System.Windows.Forms.Button();
            this.butImprimir = new System.Windows.Forms.Button();
            this.butBorrar = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.tbDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabFiltro = new System.Windows.Forms.TabControl();
            this.tabFiltro1 = new System.Windows.Forms.TabPage();
            this.butSalir1 = new System.Windows.Forms.Button();
            this.butLimpiar1 = new System.Windows.Forms.Button();
            this.butBuscar1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRubroB = new System.Windows.Forms.TextBox();
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.butSiguiente = new System.Windows.Forms.Button();
            this.butAnterior = new System.Windows.Forms.Button();
            this.gbModificacion = new System.Windows.Forms.GroupBox();
            this.gbDescripcion = new System.Windows.Forms.GroupBox();
            this.cbCampo5 = new System.Windows.Forms.ComboBox();
            this.cbCampo4 = new System.Windows.Forms.ComboBox();
            this.cbCampo3 = new System.Windows.Forms.ComboBox();
            this.cbCampo2 = new System.Windows.Forms.ComboBox();
            this.cbCampo1 = new System.Windows.Forms.ComboBox();
            this.tbDescripcionArticulo = new System.Windows.Forms.TextBox();
            this.butBorrarSubRubros = new System.Windows.Forms.Button();
            this.lblTituloCampos = new System.Windows.Forms.Label();
            this.clbCampos = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgSubRubros = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tbRubro = new System.Windows.Forms.TextBox();
            this.butSalir = new System.Windows.Forms.Button();
            this.butGuardar = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.butLimpiar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.tabFiltro.SuspendLayout();
            this.tabFiltro1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.gbModificacion.SuspendLayout();
            this.gbDescripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubRubros)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.ImageList = this.imagenesTab;
            this.tabPrincipal.ItemSize = new System.Drawing.Size(94, 18);
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(808, 456);
            this.tabPrincipal.TabIndex = 3;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.butVistaPrevia);
            this.tabPage1.Controls.Add(this.butImprimir);
            this.tabPage1.Controls.Add(this.butBorrar);
            this.tabPage1.Controls.Add(this.dgItems);
            this.tabPage1.Controls.Add(this.tabFiltro);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 4;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(800, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado de Rubros";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // butVistaPrevia
            // 
            this.butVistaPrevia.BackColor = System.Drawing.Color.SteelBlue;
            this.butVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.butVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("butVistaPrevia.Image")));
            this.butVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVistaPrevia.Location = new System.Drawing.Point(340, 157);
            this.butVistaPrevia.Name = "butVistaPrevia";
            this.butVistaPrevia.Size = new System.Drawing.Size(88, 23);
            this.butVistaPrevia.TabIndex = 4;
            this.butVistaPrevia.Text = "&Vista Previa";
            this.butVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butVistaPrevia.UseVisualStyleBackColor = false;
            this.butVistaPrevia.Visible = false;
            // 
            // butImprimir
            // 
            this.butImprimir.BackColor = System.Drawing.Color.SteelBlue;
            this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimir.ForeColor = System.Drawing.Color.White;
            this.butImprimir.Image = ((System.Drawing.Image)(resources.GetObject("butImprimir.Image")));
            this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimir.Location = new System.Drawing.Point(266, 157);
            this.butImprimir.Name = "butImprimir";
            this.butImprimir.Size = new System.Drawing.Size(64, 23);
            this.butImprimir.TabIndex = 3;
            this.butImprimir.Text = "&Imprimir";
            this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimir.UseVisualStyleBackColor = false;
            this.butImprimir.Visible = false;
            // 
            // butBorrar
            // 
            this.butBorrar.BackColor = System.Drawing.Color.Maroon;
            this.butBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrar.ForeColor = System.Drawing.Color.White;
            this.butBorrar.Image = ((System.Drawing.Image)(resources.GetObject("butBorrar.Image")));
            this.butBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrar.Location = new System.Drawing.Point(644, 157);
            this.butBorrar.Name = "butBorrar";
            this.butBorrar.Size = new System.Drawing.Size(64, 23);
            this.butBorrar.TabIndex = 5;
            this.butBorrar.Text = "&Borrar";
            this.butBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrar.UseVisualStyleBackColor = false;
            this.butBorrar.Click += new System.EventHandler(this.butBorrar_Click);
            // 
            // dgItems
            // 
            this.dgItems.AllowSorting = false;
            this.dgItems.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dgItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItems.CaptionBackColor = System.Drawing.Color.SteelBlue;
            this.dgItems.CaptionFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.CaptionForeColor = System.Drawing.Color.White;
            this.dgItems.CaptionText = "     Listado de Rubros";
            this.dgItems.DataMember = "";
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgItems.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dgItems.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgItems.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.LinkColor = System.Drawing.Color.Teal;
            this.dgItems.Location = new System.Drawing.Point(0, 152);
            this.dgItems.Name = "dgItems";
            this.dgItems.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dgItems.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dgItems.ReadOnly = true;
            this.dgItems.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgItems.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.Size = new System.Drawing.Size(800, 278);
            this.dgItems.TabIndex = 1;
            this.dgItems.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.dgItems;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.tbDescripcion});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Items";
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Format = "";
            this.tbDescripcion.FormatInfo = null;
            this.tbDescripcion.HeaderText = "Descripcion";
            this.tbDescripcion.MappingName = "Descripcion";
            this.tbDescripcion.ReadOnly = true;
            this.tbDescripcion.Width = 200;
            // 
            // tabFiltro
            // 
            this.tabFiltro.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabFiltro.Controls.Add(this.tabFiltro1);
            this.tabFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabFiltro.HotTrack = true;
            this.tabFiltro.ImageList = this.imagenesTab;
            this.tabFiltro.ItemSize = new System.Drawing.Size(0, 18);
            this.tabFiltro.Location = new System.Drawing.Point(0, 0);
            this.tabFiltro.Multiline = true;
            this.tabFiltro.Name = "tabFiltro";
            this.tabFiltro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabFiltro.SelectedIndex = 0;
            this.tabFiltro.Size = new System.Drawing.Size(800, 152);
            this.tabFiltro.TabIndex = 0;
            // 
            // tabFiltro1
            // 
            this.tabFiltro1.Controls.Add(this.butSalir1);
            this.tabFiltro1.Controls.Add(this.butLimpiar1);
            this.tabFiltro1.Controls.Add(this.butBuscar1);
            this.tabFiltro1.Controls.Add(this.groupBox1);
            this.tabFiltro1.ImageIndex = 1;
            this.tabFiltro1.Location = new System.Drawing.Point(4, 4);
            this.tabFiltro1.Name = "tabFiltro1";
            this.tabFiltro1.Size = new System.Drawing.Size(792, 126);
            this.tabFiltro1.TabIndex = 0;
            this.tabFiltro1.Text = "Filtro Rápido";
            // 
            // butSalir1
            // 
            this.butSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir1.Image = ((System.Drawing.Image)(resources.GetObject("butSalir1.Image")));
            this.butSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir1.Location = new System.Drawing.Point(640, 88);
            this.butSalir1.Name = "butSalir1";
            this.butSalir1.Size = new System.Drawing.Size(64, 23);
            this.butSalir1.TabIndex = 9;
            this.butSalir1.Text = "&Salir";
            this.butSalir1.Click += new System.EventHandler(this.butSalir1_Click);
            // 
            // butLimpiar1
            // 
            this.butLimpiar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar1.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar1.Image")));
            this.butLimpiar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar1.Location = new System.Drawing.Point(640, 64);
            this.butLimpiar1.Name = "butLimpiar1";
            this.butLimpiar1.Size = new System.Drawing.Size(64, 24);
            this.butLimpiar1.TabIndex = 8;
            this.butLimpiar1.Text = "&Limpiar";
            this.butLimpiar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLimpiar1.Click += new System.EventHandler(this.butLimpiar1_Click);
            // 
            // butBuscar1
            // 
            this.butBuscar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar1.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar1.Image")));
            this.butBuscar1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butBuscar1.Location = new System.Drawing.Point(640, 16);
            this.butBuscar1.Name = "butBuscar1";
            this.butBuscar1.Size = new System.Drawing.Size(64, 41);
            this.butBuscar1.TabIndex = 7;
            this.butBuscar1.Text = "&Buscar";
            this.butBuscar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butBuscar1.Click += new System.EventHandler(this.butBuscar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRubroB);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rubro";
            // 
            // tbRubroB
            // 
            this.tbRubroB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRubroB.Location = new System.Drawing.Point(8, 16);
            this.tbRubroB.Name = "tbRubroB";
            this.tbRubroB.Size = new System.Drawing.Size(352, 20);
            this.tbRubroB.TabIndex = 1;
            // 
            // imagenesTab
            // 
            this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
            this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenesTab.Images.SetKeyName(0, "");
            this.imagenesTab.Images.SetKeyName(1, "");
            this.imagenesTab.Images.SetKeyName(2, "");
            this.imagenesTab.Images.SetKeyName(3, "");
            this.imagenesTab.Images.SetKeyName(4, "");
            this.imagenesTab.Images.SetKeyName(5, "");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.tbID);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.gbModificacion);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.ImageIndex = 5;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(800, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 119;
            this.pictureBox2.TabStop = false;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(696, 192);
            this.tbID.MaxLength = 2;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(40, 20);
            this.tbID.TabIndex = 118;
            this.tbID.Visible = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblRegistro);
            this.groupBox9.Controls.Add(this.butSiguiente);
            this.groupBox9.Controls.Add(this.butAnterior);
            this.groupBox9.Location = new System.Drawing.Point(664, 32);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(104, 104);
            this.groupBox9.TabIndex = 99;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Registro";
            // 
            // lblRegistro
            // 
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(8, 48);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(88, 14);
            this.lblRegistro.TabIndex = 102;
            this.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butSiguiente
            // 
            this.butSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("butSiguiente.Image")));
            this.butSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSiguiente.Location = new System.Drawing.Point(16, 72);
            this.butSiguiente.Name = "butSiguiente";
            this.butSiguiente.Size = new System.Drawing.Size(72, 24);
            this.butSiguiente.TabIndex = 15;
            this.butSiguiente.Text = "Siguiente";
            this.butSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSiguiente.Click += new System.EventHandler(this.butSiguiente_Click);
            // 
            // butAnterior
            // 
            this.butAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAnterior.Image = ((System.Drawing.Image)(resources.GetObject("butAnterior.Image")));
            this.butAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAnterior.Location = new System.Drawing.Point(16, 16);
            this.butAnterior.Name = "butAnterior";
            this.butAnterior.Size = new System.Drawing.Size(72, 24);
            this.butAnterior.TabIndex = 14;
            this.butAnterior.Text = "Anterior";
            this.butAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAnterior.Click += new System.EventHandler(this.butAnterior_Click);
            // 
            // gbModificacion
            // 
            this.gbModificacion.Controls.Add(this.gbDescripcion);
            this.gbModificacion.Controls.Add(this.butBorrarSubRubros);
            this.gbModificacion.Controls.Add(this.lblTituloCampos);
            this.gbModificacion.Controls.Add(this.clbCampos);
            this.gbModificacion.Controls.Add(this.label1);
            this.gbModificacion.Controls.Add(this.dgSubRubros);
            this.gbModificacion.Controls.Add(this.tbRubro);
            this.gbModificacion.Controls.Add(this.butSalir);
            this.gbModificacion.Controls.Add(this.butGuardar);
            this.gbModificacion.Controls.Add(this.label22);
            this.gbModificacion.Controls.Add(this.butLimpiar);
            this.gbModificacion.Location = new System.Drawing.Point(8, 32);
            this.gbModificacion.Name = "gbModificacion";
            this.gbModificacion.Size = new System.Drawing.Size(648, 392);
            this.gbModificacion.TabIndex = 97;
            this.gbModificacion.TabStop = false;
            // 
            // gbDescripcion
            // 
            this.gbDescripcion.Controls.Add(this.cbCampo5);
            this.gbDescripcion.Controls.Add(this.cbCampo4);
            this.gbDescripcion.Controls.Add(this.cbCampo3);
            this.gbDescripcion.Controls.Add(this.cbCampo2);
            this.gbDescripcion.Controls.Add(this.cbCampo1);
            this.gbDescripcion.Controls.Add(this.tbDescripcionArticulo);
            this.gbDescripcion.Location = new System.Drawing.Point(8, 304);
            this.gbDescripcion.Name = "gbDescripcion";
            this.gbDescripcion.Size = new System.Drawing.Size(528, 80);
            this.gbDescripcion.TabIndex = 101;
            this.gbDescripcion.TabStop = false;
            this.gbDescripcion.Text = "Campos que componen la Descripción del Artículo";
            // 
            // cbCampo5
            // 
            this.cbCampo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo5.Items.AddRange(new object[] {
            "---"});
            this.cbCampo5.Location = new System.Drawing.Point(424, 16);
            this.cbCampo5.Name = "cbCampo5";
            this.cbCampo5.Size = new System.Drawing.Size(96, 21);
            this.cbCampo5.TabIndex = 98;
            this.cbCampo5.SelectedIndexChanged += new System.EventHandler(this.cbCampo5_SelectedIndexChanged);
            // 
            // cbCampo4
            // 
            this.cbCampo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo4.Items.AddRange(new object[] {
            "---"});
            this.cbCampo4.Location = new System.Drawing.Point(320, 16);
            this.cbCampo4.Name = "cbCampo4";
            this.cbCampo4.Size = new System.Drawing.Size(96, 21);
            this.cbCampo4.TabIndex = 97;
            this.cbCampo4.SelectedIndexChanged += new System.EventHandler(this.cbCampo4_SelectedIndexChanged);
            // 
            // cbCampo3
            // 
            this.cbCampo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo3.Items.AddRange(new object[] {
            "---"});
            this.cbCampo3.Location = new System.Drawing.Point(216, 16);
            this.cbCampo3.Name = "cbCampo3";
            this.cbCampo3.Size = new System.Drawing.Size(96, 21);
            this.cbCampo3.TabIndex = 96;
            this.cbCampo3.SelectedIndexChanged += new System.EventHandler(this.cbCampo3_SelectedIndexChanged);
            // 
            // cbCampo2
            // 
            this.cbCampo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo2.Items.AddRange(new object[] {
            "---"});
            this.cbCampo2.Location = new System.Drawing.Point(112, 16);
            this.cbCampo2.Name = "cbCampo2";
            this.cbCampo2.Size = new System.Drawing.Size(96, 21);
            this.cbCampo2.TabIndex = 95;
            this.cbCampo2.SelectedIndexChanged += new System.EventHandler(this.cbCampo2_SelectedIndexChanged);
            // 
            // cbCampo1
            // 
            this.cbCampo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo1.Items.AddRange(new object[] {
            "---"});
            this.cbCampo1.Location = new System.Drawing.Point(8, 16);
            this.cbCampo1.Name = "cbCampo1";
            this.cbCampo1.Size = new System.Drawing.Size(96, 21);
            this.cbCampo1.TabIndex = 94;
            this.cbCampo1.SelectedIndexChanged += new System.EventHandler(this.cbCampo1_SelectedIndexChanged);
            // 
            // tbDescripcionArticulo
            // 
            this.tbDescripcionArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescripcionArticulo.Location = new System.Drawing.Point(8, 48);
            this.tbDescripcionArticulo.Multiline = true;
            this.tbDescripcionArticulo.Name = "tbDescripcionArticulo";
            this.tbDescripcionArticulo.ReadOnly = true;
            this.tbDescripcionArticulo.Size = new System.Drawing.Size(512, 24);
            this.tbDescripcionArticulo.TabIndex = 93;
            this.tbDescripcionArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butBorrarSubRubros
            // 
            this.butBorrarSubRubros.BackColor = System.Drawing.Color.Maroon;
            this.butBorrarSubRubros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarSubRubros.ForeColor = System.Drawing.Color.White;
            this.butBorrarSubRubros.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarSubRubros.Image")));
            this.butBorrarSubRubros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarSubRubros.Location = new System.Drawing.Point(248, 64);
            this.butBorrarSubRubros.Name = "butBorrarSubRubros";
            this.butBorrarSubRubros.Size = new System.Drawing.Size(64, 23);
            this.butBorrarSubRubros.TabIndex = 93;
            this.butBorrarSubRubros.Text = "&Borrar";
            this.butBorrarSubRubros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarSubRubros.UseVisualStyleBackColor = false;
            this.butBorrarSubRubros.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTituloCampos
            // 
            this.lblTituloCampos.Location = new System.Drawing.Point(328, 16);
            this.lblTituloCampos.Name = "lblTituloCampos";
            this.lblTituloCampos.Size = new System.Drawing.Size(296, 14);
            this.lblTituloCampos.TabIndex = 97;
            this.lblTituloCampos.Text = "Campos para el Sub Rubro";
            // 
            // clbCampos
            // 
            this.clbCampos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbCampos.CheckOnClick = true;
            this.clbCampos.Location = new System.Drawing.Point(328, 32);
            this.clbCampos.Name = "clbCampos";
            this.clbCampos.Size = new System.Drawing.Size(312, 257);
            this.clbCampos.TabIndex = 95;
            this.clbCampos.Enter += new System.EventHandler(this.clbCampos_Enter);
            this.clbCampos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCampos_ItemCheck);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 14);
            this.label1.TabIndex = 94;
            this.label1.Text = "Sub Rubros";
            // 
            // dgSubRubros
            // 
            this.dgSubRubros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgSubRubros.CaptionVisible = false;
            this.dgSubRubros.DataMember = "";
            this.dgSubRubros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSubRubros.Location = new System.Drawing.Point(8, 88);
            this.dgSubRubros.Name = "dgSubRubros";
            this.dgSubRubros.Size = new System.Drawing.Size(304, 208);
            this.dgSubRubros.TabIndex = 94;
            this.dgSubRubros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgSubRubros.CurrentCellChanged += new System.EventHandler(this.dgSubRubros_CurrentCellChanged);
            this.dgSubRubros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgSubRubros_KeyPress);
            this.dgSubRubros.Leave += new System.EventHandler(this.dgSubRubros_Leave);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.dgSubRubros;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "SubRubro";
            this.dataGridTableStyle2.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridTextBoxColumn1.MappingName = "descripcion";
            this.dataGridTextBoxColumn1.Width = 250;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.MappingName = "id";
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Nuevo";
            this.dataGridTextBoxColumn3.MappingName = "registroNuevo";
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // tbRubro
            // 
            this.tbRubro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRubro.Location = new System.Drawing.Point(8, 32);
            this.tbRubro.Name = "tbRubro";
            this.tbRubro.Size = new System.Drawing.Size(304, 20);
            this.tbRubro.TabIndex = 92;
            // 
            // butSalir
            // 
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(544, 349);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(96, 24);
            this.butSalir.TabIndex = 98;
            this.butSalir.Text = "&Salir";
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // butGuardar
            // 
            this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
            this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGuardar.Location = new System.Drawing.Point(544, 317);
            this.butGuardar.Name = "butGuardar";
            this.butGuardar.Size = new System.Drawing.Size(96, 24);
            this.butGuardar.TabIndex = 97;
            this.butGuardar.Text = "&Guardar";
            this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(136, 14);
            this.label22.TabIndex = 91;
            this.label22.Text = "Rubro";
            // 
            // butLimpiar
            // 
            this.butLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("butLimpiar.Image")));
            this.butLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLimpiar.Location = new System.Drawing.Point(544, 325);
            this.butLimpiar.Name = "butLimpiar";
            this.butLimpiar.Size = new System.Drawing.Size(96, 24);
            this.butLimpiar.TabIndex = 96;
            this.butLimpiar.Text = "&Limpiar";
            this.butLimpiar.Visible = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(800, 32);
            this.label18.TabIndex = 95;
            this.label18.Text = "     Modificación de Rubros";
            // 
            // ucRubroConsulta
            // 
            this.Controls.Add(this.tabPrincipal);
            this.Name = "ucRubroConsulta";
            this.Size = new System.Drawing.Size(808, 456);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.tabFiltro.ResumeLayout(false);
            this.tabFiltro1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.gbModificacion.ResumeLayout(false);
            this.gbModificacion.PerformLayout();
            this.gbDescripcion.ResumeLayout(false);
            this.gbDescripcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubRubros)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void butBuscar1_Click(object sender, System.EventArgs e)
		{
			ejecutarBusqueda();
		}

		//Ejecuta el select de la busqueda
		private void ejecutarBusqueda()
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Ejecutando búsqueda...", true);

				string sqlTotal = construirSQL();
	
				SqlConnection oConn = new SqlConnection(this.conexion);
				SqlCommand oComm = new SqlCommand();
				SqlDataAdapter oSQLDataAdapter;

				oComm.Connection = oConn;
				oComm.CommandType = CommandType.Text;
				oComm.CommandText = sqlTotal;

				//open connection
				oConn.Open();

				//prepare data adapter object
				oSQLDataAdapter = new SqlDataAdapter();
				oSQLDataAdapter.TableMappings.Add("Table", "Items");
				oSQLDataAdapter.SelectCommand = oComm;

				//initialize dataset
				DataSet dsItems = new DataSet("Items");
				oSQLDataAdapter.Fill(dsItems);

				//prepare dataview to sort
				DataView dvItems;
				dvItems = new DataView(dsItems.Tables["Items"]);
				//dgItems.DataSource = dvItems;
				dgItems.DataSource = dsItems.Tables["Items"];
				dgItems.Visible = true;

				//close connection
				oConn.Close();

				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private string construirSQL()
		{
			try
			{
				string filtro = obtenerWHERE();
				string order = obtenerORDER();

				//prepare command object
				string sql = "SELECT  Descripcion, id FROM Rubro " +
					"WHERE " + filtro;

				string sqlTotal = "";

				sqlTotal = sql + " " + order;

				return sqlTotal;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		private string obtenerWHERE()
		{
			try
			{
				string filtro = "1=1";

				if (tbRubroB.Text!="") 
				{
					filtro = filtro + " AND descripcion LIKE '%" + tbRubroB.Text.Trim() + "%'";
				}
			
				return filtro;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		
		private string obtenerORDER()
		{
			try
			{
				string orden = " ORDER BY descripcion";
				string coma = "";
				string sentido = "";
				/*
				if (cbCampoOrden1.Text!="---")
				{
					if (orden.IndexOf("[" + cbCampoOrden1.Text + "]")==-1) 
					{
						sentido = rbAsc1.Checked ? " ASC " : " DESC ";
						orden = "[" + cbCampoOrden1.Text + "]" + sentido;
					}
				}
				if (cbCampoOrden2.Text!="---")
				{
					coma = "";
					if (orden!="") coma = ", ";
				
					if (orden.IndexOf("[" + cbCampoOrden2.Text + "]")==-1) 
					{
						sentido = rbAsc2.Checked ? " ASC " : " DESC ";
						orden += coma + "[" + cbCampoOrden2.Text + "]" + sentido;
					}
				}
				if (cbCampoOrden3.Text!="---")
				{
					coma = "";
					if (orden!="") coma = ", ";
				
					if (orden.IndexOf("[" + cbCampoOrden3.Text + "]")==-1) 
					{
						sentido = rbAsc3.Checked ? " ASC " : " DESC ";
						orden += coma + "[" + cbCampoOrden3.Text + "]" + sentido;
					}
				}
				if (cbCampoOrden4.Text!="---")
				{
					coma = "";
					if (orden!="") coma = ", ";
				
					if (orden.IndexOf("[" + cbCampoOrden4.Text + "]")==-1) 
					{
						sentido = rbAsc4.Checked ? " ASC " : " DESC ";
						orden += coma + "[" + cbCampoOrden4.Text + "]" + sentido;
					}
				}

				if (orden!="") orden = " ORDER BY " + orden;
				*/
				return orden;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return null;
			}
		}

		private void dgItems_DoubleClick(object sender, System.EventArgs e)
		{
			tabPrincipal.SelectedIndex = 1;
		}

		private void tabPrincipal_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (tabPrincipal.SelectedIndex==1)
				{
					this.Refresh();
					if (dgItems.DataSource!=null)
						if (((DataTable)dgItems.DataSource).Rows.Count>0)
						{
							cargarDetalle();
							gbModificacion.Enabled = true;
						}
						else
							gbModificacion.Enabled = false;
					else
						gbModificacion.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cargarDetalle()
		{
			try
			{
				if (dgItems.DataSource!=null)
					if (((DataTable)dgItems.DataSource).Rows.Count>0)
					{
						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cargando...", true);

						//Carga los campos plantilla en la lista
						//if (tablaCampos==null)
						if (true)
						{
							//Borra los campos
							clbCampos.Items.Clear();
							//Borra el recuerdo
							ultimosCampos = null;
							//Carga nuevamente los campos
							//SqlParameter[] param1 = new SqlParameter[1];
							//param1[0] = new SqlParameter("@tablaID","1");
							SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllts_Campos"); //, param1);
			
							if (dr.HasRows)
							{
								while (dr.Read())
								{
									clbCampos.Items.Add(dr["campoEtiqueta"].ToString());
								}
							}
							dr.Close();
						}

						//Carga el Rubro
						DataTable dt = (DataTable)dgItems.DataSource;
						int currentRow = dgItems.CurrentRowIndex;

						tbID.Text = dt.Rows[currentRow]["id"].ToString();
						tbRubro.Text = dt.Rows[currentRow]["descripcion"].ToString();
					
						//Carga los subrubros
						SqlParameter[] param = new SqlParameter[1];
						param[0] = new SqlParameter("@rubroID", new System.Guid(tbID.Text));
						DataSet dsSubRubros = SqlHelper.ExecuteDataset(this.conexion, "sp_getAllSubRubros", param);
						dsSubRubros.Tables[0].TableName = "SubRubro";
						dsSubRubros.Tables["SubRubro"].Columns["descripcion"].DefaultValue = " ";
						//Asigna el valor default
						dsSubRubros.Tables["SubRubro"].Columns["registroNuevo"].DefaultValue = "1";
						//Asigna el delegate
						dsSubRubros.Tables["SubRubro"].RowChanged += new DataRowChangeEventHandler(dataTableSubRubro_RowChanged);
						dgSubRubros.DataSource = dsSubRubros.Tables["SubRubro"];


						//Carga los Campos en la tabla de memoria
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@rubroID", new System.Guid(tbID.Text));
						dsSubRubros = SqlHelper.ExecuteDataset(this.conexion, "sp_getAllSubRubroCampoByRubro", param);
						tablaCampos = dsSubRubros.Tables[0];
					
						lblRegistro.Text = (currentRow+1).ToString() + " de " + dt.Rows.Count.ToString();

						componerSubRubroCampos();

						//Carga los combos
						cargarCamposCombosDescripcion();
						acomodarCombosEstructura();
						armarEstructuraDescripcion(null);

						mostrarSubRubro();

						UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
					}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Maneja el evento de modificacion de registros
		protected void dataTableSubRubro_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
		{
			if (habilitarHandlerRowChanged)
			{
				armarEstructuraDescripcion(e);
			}
		}

		private void componerSubRubroCampos()
		{
			try
			{
				if (dgSubRubros.CurrentRowIndex==-1)
				{
					MessageBox.Show("Debe seleccionar un Sub Rubro.", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					//Marca que no hay que recordar los cambios en la lista
					recordarCambios = false;
					colocarSubRubroID();
					string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());

					//Obtiene la lista de campos para este Sub Rubro
					//DataRow[] rows = dataset.Tables["SubRubroCampo"].Select("subRubroID='" + subRubroID + "'");
					DataRow[] rows = tablaCampos.Select("subRubroID='" + subRubroID + "'");

					bool encontrado;
					//Si no tiene campos, toma los campos del ultimo sub rubro
					if (rows.Length==0)
					{
						//Deselecciona primero
						for (int i=0; i<clbCampos.Items.Count; i++)
							clbCampos.SetItemChecked(i, false);

						//Selecciona los campos del recuerdo
						for (int i=0; i<clbCampos.Items.Count; i++)
						{
							if (ultimosCampos!=null ? ultimosCampos.Length==0 : true)
								clbCampos.SetItemChecked(i, false);
							else
							{
								encontrado = false;
								for (int j=0; j<ultimosCampos.Length; j++)
								{
									if (ultimosCampos[j]["campoEtiqueta"].ToString()==clbCampos.Items[i].ToString())
									{
										encontrado = true;
										clbCampos.SetItemChecked(i, true);
										break;
									}
								}
								if (!encontrado)
									clbCampos.SetItemChecked(i, false);
							}
						}
					}
					else
					{
						//Selecciona los campos que corresponden al resultado
						for (int i=0; i<clbCampos.Items.Count; i++)
						{
							if (rows.Length==0)
								clbCampos.SetItemChecked(i, false);
							else
							{
								encontrado = false;
								for (int j=0; j<rows.Length; j++)
								{
									if (rows[j]["campoEtiqueta"].ToString()==clbCampos.Items[i].ToString())
									{
										encontrado = true;
										clbCampos.SetItemChecked(i, true);
										break;
									}
								}
								if (!encontrado)
									clbCampos.SetItemChecked(i, false);
							}
						}

						//Guarda en el recuerdo los campos seleccionados para este sub rubro
						ultimosCampos = (DataRow[])rows.Clone();
					}
					recordarCambios = true;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void colocarSubRubroIDs()
		{
			try
			{
				DataTable tabla = (DataTable)dgSubRubros.DataSource;
			
				if (tabla.Rows.Count>0)
				{
					for (int rowIndex = 0; rowIndex<tabla.Rows.Count; rowIndex++)
					{
						string subRubroID = Utilidades.validarGUID(tabla.Rows[rowIndex]["id"].ToString());
						if (subRubroID=="" || subRubroID==Utilidades.ID_VACIO)
						{
							tabla.Rows[rowIndex]["id"] = System.Guid.NewGuid().ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				//ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void colocarSubRubroID()
		{
			try
			{
				//Pone el codigo unico en el subrubro
				string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());
				string descripcion = dgSubRubros[dgSubRubros.CurrentRowIndex, 0].ToString();
				if (subRubroID=="" && descripcion!="")
				{
					dgSubRubros[dgSubRubros.CurrentRowIndex, 1] = System.Guid.NewGuid().ToString();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dgSubRubros_CurrentCellChanged(object sender, System.EventArgs e)
		{
			mostrarSubRubro();
			colocarSubRubroIDs();
			componerSubRubroCampos();
			//En observacion
			cargarCamposCombosDescripcion();
			//
			acomodarCombosEstructura();
		}

		//Muestra el Sub Rubro seleccionado
		private void mostrarSubRubro()
		{
			int row = dgSubRubros.CurrentCell.RowNumber;
			DataTable dt = (DataTable)dgSubRubros.DataSource;
			string subRubro = "";
			if (dt.Rows.Count>row)
				subRubro = dt.Rows[row]["descripcion"].ToString();

			lblTituloCampos.Text = "Campos para: " + subRubro;
			gbDescripcion.Text = "Descripción para: " + subRubro;

			dt = null;
		}

		private void butAnterior_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dgItems.CurrentRowIndex>0)
				{
					dgItems.CurrentRowIndex = dgItems.CurrentRowIndex - 1;
					cargarDetalle();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSiguiente_Click(object sender, System.EventArgs e)
		{
			try
			{
				int count = ((DataTable)dgItems.DataSource).Rows.Count-1;
				if (dgItems.CurrentRowIndex<count)
				{
					dgItems.CurrentRowIndex = dgItems.CurrentRowIndex + 1;
					cargarDetalle();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void clbCampos_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			try
			{
				if (dgSubRubros.CurrentRowIndex==-1)
				{
					MessageBox.Show("Debe seleccionar un Sub Rubro.", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					DataTable tabla = tablaCampos;//dataset.Tables["SubRubroCampo"];
					//Graba o borra el campo seleccionado de la tabla de campos
					if (e.NewValue==CheckState.Checked)
					{
						DataRow row = tabla.NewRow();
						//Cambios MMM
						string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());
						if (tabla.Select("subRubroID='" + subRubroID + "' AND campoNombre='" + clbCampos.Items[e.Index].ToString() + "'").Length < 1)
						{
							row["id"] = System.Guid.NewGuid().ToString();
							row["campoNombre"] = clbCampos.Items[e.Index].ToString();
							row["campoEtiqueta"] = clbCampos.Items[e.Index].ToString();
							row["subRubroID"] = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());
							tabla.Rows.Add(row);
						}
						tabla.AcceptChanges();
						if (recordarCambios)
							ultimosCampos = (DataRow[])tabla.Select("subRubroID='" + row["subRubroID"].ToString() + "'").Clone();
					}
					else //Si es deschequeado
					{
						//Solo si hay subRubroID
						string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex,1].ToString());
						if (subRubroID!="0")
						{
							//Busca el registro dentro de la tabla
							DataRow[] rows = tabla.Select("subRubroID='" + subRubroID + "'");
							if (rows.Length>0)
							{
								for (int i=0; i<rows.Length; i++)
								{
									//Si encuentra el campo
									if (rows[i]["campoEtiqueta"].ToString()==clbCampos.Items[e.Index].ToString())
									{
										//Borra el registro
										tabla.Rows.Remove(rows[i]);
									}
								}
								tabla.AcceptChanges();
								if (recordarCambios)
									ultimosCampos = (DataRow[])tabla.Select("subRubroID='" + subRubroID + "'").Clone();
							}
						}
					}
					//Carga los items en los combos
					if (recordarCambios)
					{
						cargarCamposCombosDescripcion();
						armarEstructuraDescripcion(null);
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cargarCamposCombosDescripcion()
		{
			try
			{
				//Si estan siendo ocupadas por otro proceso, espera
				while (combosEstanOcupadas)
					Thread.Sleep(200);


				//Marca el semaforo para ocupar las combos
				combosEstanOcupadas = true;

				if (dgSubRubros.CurrentRowIndex>-1)
				{
					//Obtiene el id del subRubro actual
					string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex,1].ToString());

					//Obtiene una copia de la tabla
					DataRow[] rows = tablaCampos.Copy().Select("subRubroID='" + subRubroID + "'", "campoNombre");
					DataTable tabla = tablaCampos.Clone();

					//Agrega el primer registro
					DataRow dr = tabla.NewRow();
					dr["id"] = "0";
					dr["campoNombre"] = "---";
					dr["campoEtiqueta"] = "---";
					tabla.Rows.Add(dr);

					//Agrega los registros con campos
					string campoNombreAnterior = "";
					for (int i=0; i<rows.Length; i++)
					{
						if (rows[i]["campoEtiqueta"].ToString()!="Descripción")
						{
							if (campoNombreAnterior!=rows[i]["campoNombre"].ToString())
							{
								dr = tabla.NewRow();
								dr["id"] = rows[i]["id"];
								dr["campoNombre"] = rows[i]["campoNombre"];
								dr["campoEtiqueta"] = rows[i]["campoEtiqueta"];
								tabla.Rows.Add(dr);
								campoNombreAnterior = rows[i]["campoNombre"].ToString();
							}
						}
					}
			
					habilitarHandlerCombos = false;

					//Asigna la tabla como origen de datos.
					string itemSeleccionado = cbCampo1.Text;
					cbCampo1.DataSource = tabla;
					cbCampo1.DisplayMember = "campoNombre";
					cbCampo1.ValueMember = "id";
					UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo1);

					itemSeleccionado = cbCampo2.Text;
					cbCampo2.DataSource = tabla.Copy();
					cbCampo2.DisplayMember = "campoNombre";
					cbCampo2.ValueMember = "id";
					UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo2);

					itemSeleccionado = cbCampo3.Text;
					cbCampo3.DataSource = tabla.Copy();
					cbCampo3.DisplayMember = "campoNombre";
					cbCampo3.ValueMember = "id";
					UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo3);

					itemSeleccionado = cbCampo4.Text;
					cbCampo4.DataSource = tabla.Copy();
					cbCampo4.DisplayMember = "campoNombre";
					cbCampo4.ValueMember = "id";
					UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo4);

					itemSeleccionado = cbCampo5.Text;
					cbCampo5.DataSource = tabla.Copy();
					cbCampo5.DisplayMember = "campoNombre";
					cbCampo5.ValueMember = "id";
					UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo5);

					habilitarHandlerCombos = true;
			
				}
				//Desocupa las combos
				combosEstanOcupadas = false;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void armarEstructuraDescripcion(System.Data.DataRowChangeEventArgs e)
		{
			try
			{
				//Espera hasta que se desocupen las combos
				while (combosEstanOcupadas)
					Thread.Sleep(200);

				combosEstanOcupadas = true;

				string texto = "";
				string coma = "";

				if (cbCampo1.Text!="---")
				{
					texto += coma + cbCampo1.Text;
					coma = ", ";
				}
				if (cbCampo2.Text!="---")
				{
					texto += coma + cbCampo2.Text;
					coma = ", ";
				}
				if (cbCampo3.Text!="---")
				{
					texto += coma + cbCampo3.Text;
					coma = ", ";
				}
				if (cbCampo4.Text!="---")
				{
					texto += coma + cbCampo4.Text;
					coma = ", ";
				}
				if (cbCampo5.Text!="---")
				{
					texto += coma + cbCampo5.Text;
				}
				tbDescripcionArticulo.Text = texto;

				combosEstanOcupadas = false;

			
				//Guarda el texto en el registro del subrubro
				DataTable subRubros = (DataTable)dgSubRubros.DataSource;
				habilitarHandlerRowChanged = false;

				if (e!=null)
					e.Row["cadenaDescripcion"] = texto;
				else
				{
					if (dgSubRubros.CurrentRowIndex>-1)
					{
						subRubros.Rows[dgSubRubros.CurrentRowIndex]["cadenaDescripcion"] = texto;
						subRubros.AcceptChanges();
					}
				}
				habilitarHandlerRowChanged = true;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void acomodarCombosEstructura()
		{
			try
			{
				if (dgSubRubros.CurrentRowIndex>-1)
				{
					DataTable subRubros = (DataTable)dgSubRubros.DataSource;
					//subRubros.AcceptChanges(); no porque llama al evento rowchanged
					if (dgSubRubros.CurrentRowIndex<subRubros.Rows.Count)
					{
						string texto;
						//Verifica que no este borrado
						if (subRubros.Rows[dgSubRubros.CurrentRowIndex].RowState!=DataRowState.Deleted)
							texto = subRubros.Rows[dgSubRubros.CurrentRowIndex]["cadenaDescripcion"].ToString();
						else
							texto = "";

						//Si hay una estructura guardada, la toma
						if (texto!="")
						{
							habilitarHandlerCombos = false;

							tbDescripcionArticulo.Text = texto;

							texto = texto.Replace(", ",":");
							string[] aTexto = texto.Split(":".ToCharArray());
				
							if (aTexto.Length>0)
								UtilUI.comboSeleccionarItemByText(aTexto[0], ref cbCampo1);
							else
								cbCampo1.SelectedIndex = 0;

							if (aTexto.Length>1)
								UtilUI.comboSeleccionarItemByText(aTexto[1], ref cbCampo2);
							else
								cbCampo2.SelectedIndex = 0;
				
							if (aTexto.Length>2)
								UtilUI.comboSeleccionarItemByText(aTexto[2], ref cbCampo3);
							else
								cbCampo3.SelectedIndex = 0;

							if (aTexto.Length>3)
								UtilUI.comboSeleccionarItemByText(aTexto[3], ref cbCampo4);
							else
								cbCampo4.SelectedIndex = 0;

							if (aTexto.Length>4)
								UtilUI.comboSeleccionarItemByText(aTexto[4], ref cbCampo5);
							else
								cbCampo5.SelectedIndex = 0;

							habilitarHandlerCombos = true;
						}
						else //Si no hay estructura guardada, guarda definida por la posicion de los combos
						{
							//armarEstructuraDescripcion();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}


		private void clbCampos_Enter(object sender, System.EventArgs e)
		{
			if (dgSubRubros.CurrentRowIndex>-1)
			{
				colocarSubRubroID();

				//Toma de la tabla los campos que tiene
				componerSubRubroCampos();
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dgSubRubros.DataSource!=null)
				{
					DataTable dt = (DataTable)dgSubRubros.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Selecciona el registro actual
						if (dgSubRubros.CurrentCell.RowNumber>-1)
						{
							dgSubRubros.Select(dgSubRubros.CurrentCell.RowNumber);
						}
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgSubRubros.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							DialogResult dr = MessageBox.Show("¿Desea eliminar permanentemente los Sub Rubros seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Sub Rubros...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									//param[0] = new SqlParameter("@id", new System.Guid(id));
									param[0] = new SqlParameter("@id", id);
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarSubRubro", param);

									//dt.Rows[renglon].Delete();
									dt.Rows[renglon]["id"] = "-1";
								}
								//Recorre los renglones marcados para borrar
								DataRow[] rowsBorrar = dt.Select("id='-1'");
								for (int k=0; k<rowsBorrar.Length; k++)
								{
									rowsBorrar[k].Delete();
								}
								dt.AcceptChanges();
								dgItems.Refresh();
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			try
			{
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Guardando registro...", true);
                if (validarFormulario())
                {
                    colocarSubRubroIDs();  //Esta a prueba, para que no guarde GUID 00000
                    guardarCambios();
                }
                else
                    UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void guardarCambios()
		{
			try
			{
				//Guarda el Rubro
				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter("@id", new System.Guid(tbID.Text.Trim()));
				param[1] = new SqlParameter("@descripcion", tbRubro.Text.Trim());
				SqlHelper.ExecuteNonQuery(this.conexion, "sp_UpdateRubro", param);

				//Guarda los subrubros
				string rubroID = tbID.Text.ToString();
				string subRubroID = "";
				string descripcion = "";
				string cadenaDescripcion = "";

				DataTable dtSubRubros = (DataTable)dgSubRubros.DataSource;
				for (int i=0; i<dtSubRubros.Rows.Count; i++)
				{
					if (dtSubRubros.Rows[i].RowState!=DataRowState.Deleted)
						descripcion = dtSubRubros.Rows[i]["descripcion"].ToString();
					else
						descripcion = "";

					cadenaDescripcion = dtSubRubros.Rows[i]["cadenaDescripcion"].ToString();
					if (descripcion.Trim()!="")
					{
						subRubroID = Utilidades.validarGUID(dtSubRubros.Rows[i]["id"].ToString());
                        param = new SqlParameter[4];
						param[0] = new SqlParameter("@id", subRubroID);
						param[1] = new SqlParameter("@descripcion", descripcion);
						param[2] = new SqlParameter("@rubroID", new System.Guid(rubroID));
						param[3] = new SqlParameter("@cadenaDescripcion", cadenaDescripcion);

						//Verifica si es un registro nuevo
						string registroNuevo = dtSubRubros.Rows[i]["registroNuevo"].ToString();
                        if (registroNuevo == "1") //Registro Nuevo
                        {
                            SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertSubRubro", param);
                            dtSubRubros.Rows[i]["registroNuevo"] = "0";
                        }
                        else //Registro existente
                            SqlHelper.ExecuteNonQuery(this.conexion, "sp_UpdateSubRubro", param);  //error sin resolver


						//Inserta los campos
						//Primero borra los campos existentes
						param = new SqlParameter[1];
						param[0] = new SqlParameter("@subRubroID", subRubroID);
						SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteSubRubroCampos", param);

						//Toma los registros de la tabla de memoria
						DataRow[] campos = tablaCampos.Select("subRubroID='" + subRubroID + "'");

						//Luego inserta uno a uno los campos
						for (int j=0; j<campos.Length; j++)
						{
							param = new SqlParameter[4];
							param[0] = new SqlParameter("@id", campos[j]["id"].ToString());
							param[1] = new SqlParameter("@subRubroID", Utilidades.validarGUID(campos[j]["subRubroID"].ToString()));
							param[2] = new SqlParameter("@campoNombre", campos[j]["campoNombre"].ToString());
							param[3] = new SqlParameter("@campoEtiqueta", campos[j]["campoEtiqueta"].ToString());
							SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertSubRubroCampo", param);
						}
					}	
				}
				MessageBox.Show("Rubro Modificado con éxito.", "Modificación de Rubros", MessageBoxButtons.OK, MessageBoxIcon.Information);
			
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Rubro Modificado con éxito.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private bool validarFormulario()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;
			
				if (tbRubro.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el nombre del Rubro.\r\n";
					resultado = false;
				}
                if (clbCampos.CheckedItems.Count == 0)
                {
                    mensaje += "   - Debe seleccionar algún campo para habilitar la carga de artículos.\r\n";
                    resultado = false;
                }  

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Modificación de Rubros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Limpia los campos del formulario
		private void limpiarCamposUnicos()
		{
			tbRubro.Text = "";
		}

		private void butBorrar_Click(object sender, System.EventArgs e)
		{
			borrarRubrosSeleccionados();
		}

		private void borrarRubrosSeleccionados()
		{
			try
			{
				if (dgItems.DataSource!=null)
				{
					DataTable dt = (DataTable)dgItems.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgItems.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							DialogResult dr = MessageBox.Show("¿Desea borrar los Rubros seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Rubros...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									param[0] = new SqlParameter("@id", new System.Guid(id));
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarRubro", param);

									//dt.Rows[renglon]["id"] = "-1";
                                    dt.Rows[renglon]["id"] = Utilidades.ID_VACIO;

									//Obtiene los IDs de SubRubros para este Rubro
									param[0] = new SqlParameter("@rubroID", new System.Guid(id));
									SqlDataReader dr2 = SqlHelper.ExecuteReader(this.conexion, "sp_getAllSubRubros", param);

									if (dr2.HasRows)
									{
										//Borra los subRubros y los campos para cada uno de estos SubRubros
										while (dr2.Read())
										{
											param[0] = new SqlParameter("@id", dr2["id"].ToString());
											SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarSubRubro", param);
										}
									}
									dr2.Close();

								}
								//Recorre los renglones marcados para borrar
								//DataRow[] rowsBorrar = dt.Select("id='-1'");
                                DataRow[] rowsBorrar = dt.Select("id='" + Utilidades.ID_VACIO + "'");
								for (int k=0; k<rowsBorrar.Length; k++)
								{
									rowsBorrar[k].Delete();
								}

								dt.AcceptChanges();
								dgItems.Refresh();
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butSalir1_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void butLimpiar1_Click(object sender, System.EventArgs e)
		{
			tbRubroB.Text = "";
		}

		private void cbCampo1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo5_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void dgSubRubros_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Delete)
				MessageBox.Show("Delete");
		}

		private void dgSubRubros_Leave(object sender, System.EventArgs e)
		{
			mostrarSubRubro();
		}
	}
}
