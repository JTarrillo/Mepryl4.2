namespace CapaPresentacion
{
    partial class frmBorrarTurnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrarTurnos));
            this.panCentro = new System.Windows.Forms.Panel();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.butAceptar = new System.Windows.Forms.Button();
            this.tbUltimoCodigoTurno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.tbId = new System.Windows.Forms.TextBox();
            this.butEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panIzquierda = new System.Windows.Forms.Panel();
            this.panDerecha = new System.Windows.Forms.Panel();
            this.panAbajo = new System.Windows.Forms.Panel();
            this.butSalir = new System.Windows.Forms.Button();
            this.tbEntidadNombre = new System.Windows.Forms.TextBox();
            this.panArriba = new System.Windows.Forms.Panel();
            this.lbEstadoEdicion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panCentro.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panArriba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Controls.Add(this.tabPrincipal);
            this.panCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCentro.Location = new System.Drawing.Point(10, 40);
            this.panCentro.Name = "panCentro";
            this.panCentro.Size = new System.Drawing.Size(513, 333);
            this.panCentro.TabIndex = 8;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(513, 333);
            this.tabPrincipal.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.butAceptar);
            this.tabPage1.Controls.Add(this.tbUltimoCodigoTurno);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpFechaHasta);
            this.tabPage1.Controls.Add(this.dtpFechaDesde);
            this.tabPage1.Controls.Add(this.tbId);
            this.tabPage1.Controls.Add(this.butEliminar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(505, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Principales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // butAceptar
            // 
            this.butAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAceptar.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar.Image")));
            this.butAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar.Location = new System.Drawing.Point(240, 135);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(114, 28);
            this.butAceptar.TabIndex = 54;
            this.butAceptar.Text = "&Guardar";
            this.butAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // tbUltimoCodigoTurno
            // 
            this.tbUltimoCodigoTurno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUltimoCodigoTurno.Location = new System.Drawing.Point(18, 140);
            this.tbUltimoCodigoTurno.Name = "tbUltimoCodigoTurno";
            this.tbUltimoCodigoTurno.Size = new System.Drawing.Size(115, 20);
            this.tbUltimoCodigoTurno.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Último Código de Turno";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(122, 31);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaHasta.TabIndex = 53;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(18, 31);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaDesde.TabIndex = 52;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(479, 0);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(54, 20);
            this.tbId.TabIndex = 7;
            this.tbId.Visible = false;
            // 
            // butEliminar
            // 
            this.butEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butEliminar.Image = ((System.Drawing.Image)(resources.GetObject("butEliminar.Image")));
            this.butEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEliminar.Location = new System.Drawing.Point(240, 29);
            this.butEliminar.Name = "butEliminar";
            this.butEliminar.Size = new System.Drawing.Size(114, 28);
            this.butEliminar.TabIndex = 5;
            this.butEliminar.Text = "&Borrar Turnos";
            this.butEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEliminar.UseVisualStyleBackColor = false;
            this.butEliminar.Click += new System.EventHandler(this.butEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Período";
            // 
            // panIzquierda
            // 
            this.panIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panIzquierda.Location = new System.Drawing.Point(0, 40);
            this.panIzquierda.Name = "panIzquierda";
            this.panIzquierda.Size = new System.Drawing.Size(10, 333);
            this.panIzquierda.TabIndex = 7;
            // 
            // panDerecha
            // 
            this.panDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.panDerecha.Location = new System.Drawing.Point(523, 40);
            this.panDerecha.Name = "panDerecha";
            this.panDerecha.Size = new System.Drawing.Size(126, 333);
            this.panDerecha.TabIndex = 6;
            // 
            // panAbajo
            // 
            this.panAbajo.Controls.Add(this.butSalir);
            this.panAbajo.Controls.Add(this.tbEntidadNombre);
            this.panAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panAbajo.Location = new System.Drawing.Point(0, 373);
            this.panAbajo.Name = "panAbajo";
            this.panAbajo.Size = new System.Drawing.Size(649, 28);
            this.panAbajo.TabIndex = 5;
            // 
            // butSalir
            // 
            this.butSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(523, 0);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(126, 28);
            this.butSalir.TabIndex = 7;
            this.butSalir.Text = "&Salir [Esc]";
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
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
            // panArriba
            // 
            this.panArriba.Controls.Add(this.lbEstadoEdicion);
            this.panArriba.Controls.Add(this.pictureBox2);
            this.panArriba.Controls.Add(this.lbTitulo);
            this.panArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.panArriba.Location = new System.Drawing.Point(0, 0);
            this.panArriba.Name = "panArriba";
            this.panArriba.Size = new System.Drawing.Size(649, 40);
            this.panArriba.TabIndex = 4;
            // 
            // lbEstadoEdicion
            // 
            this.lbEstadoEdicion.AutoSize = true;
            this.lbEstadoEdicion.BackColor = System.Drawing.Color.Transparent;
            this.lbEstadoEdicion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbEstadoEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoEdicion.ForeColor = System.Drawing.Color.White;
            this.lbEstadoEdicion.Location = new System.Drawing.Point(633, 0);
            this.lbEstadoEdicion.Name = "lbEstadoEdicion";
            this.lbEstadoEdicion.Size = new System.Drawing.Size(0, 25);
            this.lbEstadoEdicion.TabIndex = 124;
            this.lbEstadoEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkMagenta;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Location = new System.Drawing.Point(633, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 122;
            this.pictureBox2.TabStop = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.DarkMagenta;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(649, 40);
            this.lbTitulo.TabIndex = 119;
            this.lbTitulo.Text = "Borrar Turnos";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBorrarTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 401);
            this.Controls.Add(this.panCentro);
            this.Controls.Add(this.panIzquierda);
            this.Controls.Add(this.panDerecha);
            this.Controls.Add(this.panAbajo);
            this.Controls.Add(this.panArriba);
            this.Name = "frmBorrarTurnos";
            this.Text = "Borrar Turnos";
            this.panCentro.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panArriba.ResumeLayout(false);
            this.panArriba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panCentro;
        protected System.Windows.Forms.TabControl tabPrincipal;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.TextBox tbId;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panIzquierda;
        protected System.Windows.Forms.Panel panDerecha;
        protected System.Windows.Forms.Button butEliminar;
        protected System.Windows.Forms.Panel panAbajo;
        protected System.Windows.Forms.Button butSalir;
        protected System.Windows.Forms.TextBox tbEntidadNombre;
        private System.Windows.Forms.Panel panArriba;
        private System.Windows.Forms.Label lbEstadoEdicion;
        protected System.Windows.Forms.PictureBox pictureBox2;
        protected System.Windows.Forms.Label lbTitulo;
        protected System.Windows.Forms.DateTimePicker dtpFechaHasta;
        protected System.Windows.Forms.DateTimePicker dtpFechaDesde;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbUltimoCodigoTurno;
        protected System.Windows.Forms.Button butAceptar;
    }
}