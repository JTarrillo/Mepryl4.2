namespace CapaPresentacion
{
    partial class frmCondicionesLaborales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondicionesLaborales));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.cboLugarAtencion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCondicionesLaborales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botAgregar = new System.Windows.Forms.Button();
            this.botEliminar = new System.Windows.Forms.Button();
            this.botEditar = new System.Windows.Forms.Button();
            this.panelEdicion = new System.Windows.Forms.Panel();
            this.tbId = new System.Windows.Forms.TextBox();
            this.cboFechaCitacion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboFechaAlta = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboAlta = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboJustificacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLugarAtencionEditar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.botCancelar = new System.Windows.Forms.Button();
            this.botGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPrincipal.SuspendLayout();
            this.panelEdicion.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(896, 25);
            this.lbTitulo.TabIndex = 127;
            this.lbTitulo.Text = "   Configuración de Condiciones Laborales";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.cboLugarAtencion);
            this.panelPrincipal.Controls.Add(this.label4);
            this.panelPrincipal.Controls.Add(this.cboCondicionesLaborales);
            this.panelPrincipal.Controls.Add(this.label1);
            this.panelPrincipal.Location = new System.Drawing.Point(5, 43);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(707, 100);
            this.panelPrincipal.TabIndex = 0;
            // 
            // cboLugarAtencion
            // 
            this.cboLugarAtencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLugarAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLugarAtencion.FormattingEnabled = true;
            this.cboLugarAtencion.Items.AddRange(new object[] {
            "CONSULTORIO",
            "DOMICILIO"});
            this.cboLugarAtencion.Location = new System.Drawing.Point(13, 22);
            this.cboLugarAtencion.Name = "cboLugarAtencion";
            this.cboLugarAtencion.Size = new System.Drawing.Size(172, 24);
            this.cboLugarAtencion.TabIndex = 0;
            this.cboLugarAtencion.SelectionChangeCommitted += new System.EventHandler(this.cboLugarAtencion_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Lugar de Atención";
            // 
            // cboCondicionesLaborales
            // 
            this.cboCondicionesLaborales.DropDownHeight = 150;
            this.cboCondicionesLaborales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionesLaborales.DropDownWidth = 400;
            this.cboCondicionesLaborales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicionesLaborales.FormattingEnabled = true;
            this.cboCondicionesLaborales.IntegralHeight = false;
            this.cboCondicionesLaborales.Location = new System.Drawing.Point(13, 67);
            this.cboCondicionesLaborales.Name = "cboCondicionesLaborales";
            this.cboCondicionesLaborales.Size = new System.Drawing.Size(430, 24);
            this.cboCondicionesLaborales.TabIndex = 1;
            this.cboCondicionesLaborales.SelectionChangeCommitted += new System.EventHandler(this.cboCondicionesLaborales_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Condiciones Laborales";
            // 
            // botAgregar
            // 
            this.botAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAgregar.Image = ((System.Drawing.Image)(resources.GetObject("botAgregar.Image")));
            this.botAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAgregar.Location = new System.Drawing.Point(14, 18);
            this.botAgregar.Name = "botAgregar";
            this.botAgregar.Size = new System.Drawing.Size(122, 46);
            this.botAgregar.TabIndex = 2;
            this.botAgregar.Text = "Agregar";
            this.botAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAgregar.UseVisualStyleBackColor = true;
            this.botAgregar.Click += new System.EventHandler(this.botAgregar_Click);
            // 
            // botEliminar
            // 
            this.botEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar.Image")));
            this.botEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar.Location = new System.Drawing.Point(14, 122);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(122, 46);
            this.botEliminar.TabIndex = 4;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // botEditar
            // 
            this.botEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEditar.Image = ((System.Drawing.Image)(resources.GetObject("botEditar.Image")));
            this.botEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEditar.Location = new System.Drawing.Point(14, 70);
            this.botEditar.Name = "botEditar";
            this.botEditar.Size = new System.Drawing.Size(122, 46);
            this.botEditar.TabIndex = 3;
            this.botEditar.Text = "Editar";
            this.botEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEditar.UseVisualStyleBackColor = true;
            this.botEditar.Click += new System.EventHandler(this.botEditar_Click);
            // 
            // panelEdicion
            // 
            this.panelEdicion.Controls.Add(this.tbId);
            this.panelEdicion.Controls.Add(this.cboFechaCitacion);
            this.panelEdicion.Controls.Add(this.label9);
            this.panelEdicion.Controls.Add(this.cboFechaAlta);
            this.panelEdicion.Controls.Add(this.label8);
            this.panelEdicion.Controls.Add(this.cboAlta);
            this.panelEdicion.Controls.Add(this.label7);
            this.panelEdicion.Controls.Add(this.cboJustificacion);
            this.panelEdicion.Controls.Add(this.label6);
            this.panelEdicion.Controls.Add(this.cboLugarAtencionEditar);
            this.panelEdicion.Controls.Add(this.label5);
            this.panelEdicion.Controls.Add(this.tbDescripcion);
            this.panelEdicion.Controls.Add(this.label3);
            this.panelEdicion.Controls.Add(this.tbCodigo);
            this.panelEdicion.Controls.Add(this.label2);
            this.panelEdicion.Location = new System.Drawing.Point(5, 149);
            this.panelEdicion.Name = "panelEdicion";
            this.panelEdicion.Size = new System.Drawing.Size(707, 244);
            this.panelEdicion.TabIndex = 1;
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(257, 69);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(46, 22);
            this.tbId.TabIndex = 26;
            this.tbId.Visible = false;
            // 
            // cboFechaCitacion
            // 
            this.cboFechaCitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFechaCitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaCitacion.FormattingEnabled = true;
            this.cboFechaCitacion.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cboFechaCitacion.Location = new System.Drawing.Point(13, 205);
            this.cboFechaCitacion.Name = "cboFechaCitacion";
            this.cboFechaCitacion.Size = new System.Drawing.Size(59, 24);
            this.cboFechaCitacion.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(231, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "¿Debe llevar SIEMPRE fecha de Próxima Visita?";
            // 
            // cboFechaAlta
            // 
            this.cboFechaAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaAlta.FormattingEnabled = true;
            this.cboFechaAlta.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cboFechaAlta.Location = new System.Drawing.Point(13, 160);
            this.cboFechaAlta.Name = "cboFechaAlta";
            this.cboFechaAlta.Size = new System.Drawing.Size(59, 24);
            this.cboFechaAlta.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "¿Debe llevar SIEMPRE fecha de Alta?";
            // 
            // cboAlta
            // 
            this.cboAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlta.FormattingEnabled = true;
            this.cboAlta.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cboAlta.Location = new System.Drawing.Point(13, 115);
            this.cboAlta.Name = "cboAlta";
            this.cboAlta.Size = new System.Drawing.Size(59, 24);
            this.cboAlta.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "¿Estadisticamente es Alta?";
            // 
            // cboJustificacion
            // 
            this.cboJustificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJustificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboJustificacion.FormattingEnabled = true;
            this.cboJustificacion.Items.AddRange(new object[] {
            "JUSTIFICADO",
            "NO JUSTIFICADO"});
            this.cboJustificacion.Location = new System.Drawing.Point(13, 69);
            this.cboJustificacion.Name = "cboJustificacion";
            this.cboJustificacion.Size = new System.Drawing.Size(224, 24);
            this.cboJustificacion.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Justificación Médica";
            // 
            // cboLugarAtencionEditar
            // 
            this.cboLugarAtencionEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLugarAtencionEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLugarAtencionEditar.FormattingEnabled = true;
            this.cboLugarAtencionEditar.Items.AddRange(new object[] {
            "CONSULTORIO",
            "DOMICILIO"});
            this.cboLugarAtencionEditar.Location = new System.Drawing.Point(13, 24);
            this.cboLugarAtencionEditar.Name = "cboLugarAtencionEditar";
            this.cboLugarAtencionEditar.Size = new System.Drawing.Size(172, 24);
            this.cboLugarAtencionEditar.TabIndex = 0;
            this.cboLugarAtencionEditar.SelectionChangeCommitted += new System.EventHandler(this.cboLugarAtencionEditar_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Lugar de Atención";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion.Location = new System.Drawing.Point(243, 25);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(456, 22);
            this.tbDescripcion.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descripción";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Enabled = false;
            this.tbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigo.Location = new System.Drawing.Point(191, 25);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(46, 22);
            this.tbCodigo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código";
            // 
            // botCancelar
            // 
            this.botCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(14, 297);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(122, 46);
            this.botCancelar.TabIndex = 7;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Visible = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botGuardar
            // 
            this.botGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botGuardar.Image = ((System.Drawing.Image)(resources.GetObject("botGuardar.Image")));
            this.botGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botGuardar.Location = new System.Drawing.Point(14, 245);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(122, 46);
            this.botGuardar.TabIndex = 6;
            this.botGuardar.Text = "Guardar";
            this.botGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botGuardar.UseVisualStyleBackColor = true;
            this.botGuardar.Visible = false;
            this.botGuardar.Click += new System.EventHandler(this.botGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(14, 362);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(122, 46);
            this.btnSalir.TabIndex = 128;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Visible = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.botGuardar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.botEliminar);
            this.panel1.Controls.Add(this.botAgregar);
            this.panel1.Controls.Add(this.botEditar);
            this.panel1.Controls.Add(this.botCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(744, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 425);
            this.panel1.TabIndex = 129;
            // 
            // frmCondicionesLaborales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelEdicion);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmCondicionesLaborales";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de Condiciones Laborales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCondicionesLaborales_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.panelEdicion.ResumeLayout(false);
            this.panelEdicion.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCondicionesLaborales;
        private System.Windows.Forms.Button botAgregar;
        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.Button botEditar;
        private System.Windows.Forms.Panel panelEdicion;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLugarAtencion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFechaCitacion;
        private System.Windows.Forms.ComboBox cboFechaAlta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAlta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboJustificacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboLugarAtencionEditar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.Button botGuardar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
    }
}