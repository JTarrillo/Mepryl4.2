namespace CapaPresentacionBase
{
    partial class frmBaseGrillaABM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseGrillaABM));
            this.panCentro = new System.Windows.Forms.Panel();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butBuscar = new System.Windows.Forms.Button();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.labe2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panBusqueda = new System.Windows.Forms.Panel();
            this.gbControles = new System.Windows.Forms.GroupBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbCodigo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panBotones = new System.Windows.Forms.Panel();
            this.imagenesTab = new System.Windows.Forms.ImageList(this.components);
            this.panIzquierda = new System.Windows.Forms.Panel();
            this.panAbajo = new System.Windows.Forms.Panel();
            this.tbEntidadNombre = new System.Windows.Forms.TextBox();
            this.panDerecha = new System.Windows.Forms.Panel();
            this.butImprimir = new System.Windows.Forms.Button();
            this.butSalir = new System.Windows.Forms.Button();
            this.butAgregar = new System.Windows.Forms.Button();
            this.butCancelar = new System.Windows.Forms.Button();
            this.butEliminar = new System.Windows.Forms.Button();
            this.butAceptar = new System.Windows.Forms.Button();
            this.butModificar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panArriba = new System.Windows.Forms.Panel();
            this.lbEstadoEdicion = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panBusqueda.SuspendLayout();
            this.gbControles.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panArriba.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Controls.Add(this.dgItems);
            this.panCentro.Controls.Add(this.panel1);
            this.panCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCentro.Location = new System.Drawing.Point(10, 40);
            this.panCentro.Name = "panCentro";
            this.panCentro.Size = new System.Drawing.Size(674, 425);
            this.panCentro.TabIndex = 8;
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.Location = new System.Drawing.Point(0, 115);
            this.dgItems.Name = "dgItems";
            this.dgItems.ReadOnly = true;
            this.dgItems.Size = new System.Drawing.Size(674, 310);
            this.dgItems.TabIndex = 7;
            this.dgItems.DoubleClick += new System.EventHandler(this.butModificar_Click);
            this.dgItems.CurrentCellChanged += new System.EventHandler(this.dgItems_CurrentCellChanged);
            this.dgItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgItems_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabPrincipal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 115);
            this.panel1.TabIndex = 6;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.ImageList = this.imagenesTab;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(674, 115);
            this.tabPrincipal.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butBuscar);
            this.tabPage2.Controls.Add(this.tbBusqueda);
            this.tabPage2.Controls.Add(this.labe2);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(666, 88);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Búsqueda";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // butBuscar
            // 
            this.butBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar.Image")));
            this.butBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscar.Location = new System.Drawing.Point(568, 31);
            this.butBuscar.Name = "butBuscar";
            this.butBuscar.Size = new System.Drawing.Size(86, 21);
            this.butBuscar.TabIndex = 11;
            this.butBuscar.Text = "Buscar";
            this.butBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscar.UseVisualStyleBackColor = false;
            this.butBuscar.Click += new System.EventHandler(this.butBuscar_Click);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBusqueda.Location = new System.Drawing.Point(57, 32);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(505, 20);
            this.tbBusqueda.TabIndex = 9;
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);
            this.tbBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusqueda_KeyDown);
            // 
            // labe2
            // 
            this.labe2.AutoSize = true;
            this.labe2.Location = new System.Drawing.Point(54, 16);
            this.labe2.Name = "labe2";
            this.labe2.Size = new System.Drawing.Size(77, 13);
            this.labe2.TabIndex = 10;
            this.labe2.Text = "Palabras clave";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panBusqueda);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(666, 88);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingreso de Datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panBusqueda
            // 
            this.panBusqueda.Controls.Add(this.gbControles);
            this.panBusqueda.Controls.Add(this.panBotones);
            this.panBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBusqueda.Location = new System.Drawing.Point(0, 0);
            this.panBusqueda.Name = "panBusqueda";
            this.panBusqueda.Size = new System.Drawing.Size(666, 88);
            this.panBusqueda.TabIndex = 7;
            // 
            // gbControles
            // 
            this.gbControles.Controls.Add(this.tbId);
            this.gbControles.Controls.Add(this.tbCodigo);
            this.gbControles.Controls.Add(this.label1);
            this.gbControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbControles.Location = new System.Drawing.Point(0, 0);
            this.gbControles.Name = "gbControles";
            this.gbControles.Size = new System.Drawing.Size(522, 88);
            this.gbControles.TabIndex = 5;
            this.gbControles.TabStop = false;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(516, 63);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(20, 20);
            this.tbId.TabIndex = 9;
            this.tbId.Visible = false;
            // 
            // tbCodigo
            // 
            this.tbCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigo.Location = new System.Drawing.Point(6, 26);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(48, 20);
            this.tbCodigo.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código";
            // 
            // panBotones
            // 
            this.panBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panBotones.Location = new System.Drawing.Point(522, 0);
            this.panBotones.Name = "panBotones";
            this.panBotones.Size = new System.Drawing.Size(144, 88);
            this.panBotones.TabIndex = 0;
            // 
            // imagenesTab
            // 
            this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
            this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenesTab.Images.SetKeyName(0, "");
            this.imagenesTab.Images.SetKeyName(1, "Buscar.ico");
            // 
            // panIzquierda
            // 
            this.panIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panIzquierda.Location = new System.Drawing.Point(0, 40);
            this.panIzquierda.Name = "panIzquierda";
            this.panIzquierda.Size = new System.Drawing.Size(10, 425);
            this.panIzquierda.TabIndex = 7;
            // 
            // panAbajo
            // 
            this.panAbajo.Controls.Add(this.tbEntidadNombre);
            this.panAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panAbajo.Location = new System.Drawing.Point(0, 465);
            this.panAbajo.Name = "panAbajo";
            this.panAbajo.Size = new System.Drawing.Size(684, 24);
            this.panAbajo.TabIndex = 6;
            // 
            // tbEntidadNombre
            // 
            this.tbEntidadNombre.Enabled = false;
            this.tbEntidadNombre.Location = new System.Drawing.Point(454, 6);
            this.tbEntidadNombre.Name = "tbEntidadNombre";
            this.tbEntidadNombre.Size = new System.Drawing.Size(96, 20);
            this.tbEntidadNombre.TabIndex = 6;
            this.tbEntidadNombre.Visible = false;
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.butImprimir);
            this.panDerecha.Controls.Add(this.butSalir);
            this.panDerecha.Controls.Add(this.butAgregar);
            this.panDerecha.Controls.Add(this.butCancelar);
            this.panDerecha.Controls.Add(this.butEliminar);
            this.panDerecha.Controls.Add(this.butAceptar);
            this.panDerecha.Controls.Add(this.butModificar);
            this.panDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.panDerecha.Location = new System.Drawing.Point(684, 40);
            this.panDerecha.Name = "panDerecha";
            this.panDerecha.Size = new System.Drawing.Size(117, 449);
            this.panDerecha.TabIndex = 0;
            // 
            // butImprimir
            // 
            this.butImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimir.Image = ((System.Drawing.Image)(resources.GetObject("butImprimir.Image")));
            this.butImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimir.Location = new System.Drawing.Point(6, 373);
            this.butImprimir.Name = "butImprimir";
            this.butImprimir.Size = new System.Drawing.Size(106, 24);
            this.butImprimir.TabIndex = 5;
            this.butImprimir.Text = "Imprimir [F10]";
            this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimir.Click += new System.EventHandler(this.butImprimir_Click);
            // 
            // butSalir
            // 
            this.butSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(0, 425);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(117, 24);
            this.butSalir.TabIndex = 6;
            this.butSalir.Text = "&Salir [Esc]";
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // butAgregar
            // 
            this.butAgregar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAgregar.Image = ((System.Drawing.Image)(resources.GetObject("butAgregar.Image")));
            this.butAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAgregar.Location = new System.Drawing.Point(6, 24);
            this.butAgregar.Name = "butAgregar";
            this.butAgregar.Size = new System.Drawing.Size(106, 28);
            this.butAgregar.TabIndex = 2;
            this.butAgregar.Text = "A&gregar [F7]";
            this.butAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAgregar.UseVisualStyleBackColor = false;
            this.butAgregar.Visible = false;
            this.butAgregar.Click += new System.EventHandler(this.butAgregar_Click);
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(6, 192);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(106, 28);
            this.butCancelar.TabIndex = 1;
            this.butCancelar.Text = "&Cancelar [F6]";
            this.butCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click);
            // 
            // butEliminar
            // 
            this.butEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butEliminar.Image = ((System.Drawing.Image)(resources.GetObject("butEliminar.Image")));
            this.butEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEliminar.Location = new System.Drawing.Point(6, 92);
            this.butEliminar.Name = "butEliminar";
            this.butEliminar.Size = new System.Drawing.Size(106, 28);
            this.butEliminar.TabIndex = 4;
            this.butEliminar.Text = "&Eliminar [F9]";
            this.butEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEliminar.UseVisualStyleBackColor = false;
            this.butEliminar.Visible = false;
            this.butEliminar.Click += new System.EventHandler(this.butEliminar_Click);
            // 
            // butAceptar
            // 
            this.butAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar.Image")));
            this.butAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar.Location = new System.Drawing.Point(6, 158);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(106, 28);
            this.butAceptar.TabIndex = 0;
            this.butAceptar.Text = "&Aceptar [F5]";
            this.butAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // butModificar
            // 
            this.butModificar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butModificar.Image = ((System.Drawing.Image)(resources.GetObject("butModificar.Image")));
            this.butModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butModificar.Location = new System.Drawing.Point(6, 58);
            this.butModificar.Name = "butModificar";
            this.butModificar.Size = new System.Drawing.Size(106, 28);
            this.butModificar.TabIndex = 3;
            this.butModificar.Text = "&Modificar [F8]";
            this.butModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butModificar.UseVisualStyleBackColor = false;
            this.butModificar.Visible = false;
            this.butModificar.Click += new System.EventHandler(this.butModificar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Location = new System.Drawing.Point(785, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 122;
            this.pictureBox2.TabStop = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Black;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(801, 40);
            this.lbTitulo.TabIndex = 119;
            this.lbTitulo.Text = "Grilla";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panArriba
            // 
            this.panArriba.Controls.Add(this.lbEstadoEdicion);
            this.panArriba.Controls.Add(this.pictureBox2);
            this.panArriba.Controls.Add(this.lbTitulo);
            this.panArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.panArriba.Location = new System.Drawing.Point(0, 0);
            this.panArriba.Name = "panArriba";
            this.panArriba.Size = new System.Drawing.Size(801, 40);
            this.panArriba.TabIndex = 4;
            // 
            // lbEstadoEdicion
            // 
            this.lbEstadoEdicion.AutoSize = true;
            this.lbEstadoEdicion.BackColor = System.Drawing.Color.Transparent;
            this.lbEstadoEdicion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbEstadoEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoEdicion.ForeColor = System.Drawing.Color.White;
            this.lbEstadoEdicion.Location = new System.Drawing.Point(785, 0);
            this.lbEstadoEdicion.Name = "lbEstadoEdicion";
            this.lbEstadoEdicion.Size = new System.Drawing.Size(0, 25);
            this.lbEstadoEdicion.TabIndex = 123;
            this.lbEstadoEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmBaseGrillaABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 489);
            this.Controls.Add(this.panCentro);
            this.Controls.Add(this.panIzquierda);
            this.Controls.Add(this.panAbajo);
            this.Controls.Add(this.panDerecha);
            this.Controls.Add(this.panArriba);
            this.Name = "frmBaseGrillaABM";
            this.ShowIcon = false;
            this.Text = "frmBaseGrillaABM";
            this.Load += new System.EventHandler(this.frmBaseGrillaABM_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseGrillaABM_FormClosing);
            this.panCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panBusqueda.ResumeLayout(false);
            this.gbControles.ResumeLayout(false);
            this.gbControles.PerformLayout();
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panArriba.ResumeLayout(false);
            this.panArriba.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panCentro;
        private System.Windows.Forms.ImageList imagenesTab;
        private System.Windows.Forms.Panel panIzquierda;
        protected System.Windows.Forms.Panel panAbajo;
        protected System.Windows.Forms.TextBox tbEntidadNombre;
        protected System.Windows.Forms.Panel panDerecha;
        protected System.Windows.Forms.Button butCancelar;
        protected System.Windows.Forms.Button butAceptar;
        protected System.Windows.Forms.PictureBox pictureBox2;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panArriba;
        protected System.Windows.Forms.Button butSalir;
        protected System.Windows.Forms.TabControl tabPrincipal;
        protected System.Windows.Forms.TextBox tbBusqueda;
        protected System.Windows.Forms.Label labe2;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.Panel panBusqueda;
        public System.Windows.Forms.GroupBox gbControles;
        protected System.Windows.Forms.Label tbCodigo;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbId;
        protected System.Windows.Forms.Button butAgregar;
        protected System.Windows.Forms.Button butEliminar;
        protected System.Windows.Forms.Button butModificar;
        protected System.Windows.Forms.Button butBuscar;
        protected System.Windows.Forms.Panel panBotones;
        protected System.Windows.Forms.TabPage tabPage2;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbEstadoEdicion;
        protected System.Windows.Forms.Button butImprimir;
        protected System.Windows.Forms.PrintDialog printDialog1;
        public System.Windows.Forms.DataGridView dgItems;
    }
}