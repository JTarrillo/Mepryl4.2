namespace CapaPresentacion
{
    partial class frmUsuarioSistemaTipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioSistemaTipo));
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.chkModificar = new System.Windows.Forms.CheckBox();
            this.chkVer = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAudiometria = new System.Windows.Forms.CheckBox();
            this.chkResumen = new System.Windows.Forms.CheckBox();
            this.chkTurnos = new System.Windows.Forms.CheckBox();
            this.chkVentanilla = new System.Windows.Forms.CheckBox();
            this.chkMesaEntrada = new System.Windows.Forms.CheckBox();
            this.chkConfiguracion = new System.Windows.Forms.CheckBox();
            this.chkExamenes = new System.Windows.Forms.CheckBox();
            this.chkPacientes = new System.Windows.Forms.CheckBox();
            this.txtNombreTipoUsuario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.botAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(0, 0);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.Size = new System.Drawing.Size(305, 339);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.SelectionChanged += new System.EventHandler(this.dgvLista_SelectionChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(71)))), ((int)(((byte)(42)))));
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(897, 30);
            this.lblTotal.TabIndex = 276;
            this.lblTotal.Text = "Tipo de usuario del sistema";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.txtNombreTipoUsuario);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 422);
            this.panel2.TabIndex = 277;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvLista);
            this.panel1.Location = new System.Drawing.Point(19, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 339);
            this.panel1.TabIndex = 316;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkEliminar);
            this.groupBox3.Controls.Add(this.chkModificar);
            this.groupBox3.Controls.Add(this.chkVer);
            this.groupBox3.Location = new System.Drawing.Point(351, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 73);
            this.groupBox3.TabIndex = 315;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos";
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Location = new System.Drawing.Point(259, 33);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(75, 20);
            this.chkEliminar.TabIndex = 2;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            // 
            // chkModificar
            // 
            this.chkModificar.AutoSize = true;
            this.chkModificar.Location = new System.Drawing.Point(139, 33);
            this.chkModificar.Name = "chkModificar";
            this.chkModificar.Size = new System.Drawing.Size(82, 20);
            this.chkModificar.TabIndex = 1;
            this.chkModificar.Text = "Modificar";
            this.chkModificar.UseVisualStyleBackColor = true;
            // 
            // chkVer
            // 
            this.chkVer.AutoSize = true;
            this.chkVer.Location = new System.Drawing.Point(50, 33);
            this.chkVer.Name = "chkVer";
            this.chkVer.Size = new System.Drawing.Size(48, 20);
            this.chkVer.TabIndex = 0;
            this.chkVer.Text = "Ver";
            this.chkVer.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAudiometria);
            this.groupBox2.Controls.Add(this.chkResumen);
            this.groupBox2.Controls.Add(this.chkTurnos);
            this.groupBox2.Controls.Add(this.chkVentanilla);
            this.groupBox2.Controls.Add(this.chkMesaEntrada);
            this.groupBox2.Controls.Add(this.chkConfiguracion);
            this.groupBox2.Controls.Add(this.chkExamenes);
            this.groupBox2.Controls.Add(this.chkPacientes);
            this.groupBox2.Location = new System.Drawing.Point(351, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 232);
            this.groupBox2.TabIndex = 314;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accesos Pantallas";
            // 
            // chkAudiometria
            // 
            this.chkAudiometria.AutoSize = true;
            this.chkAudiometria.Location = new System.Drawing.Point(225, 138);
            this.chkAudiometria.Name = "chkAudiometria";
            this.chkAudiometria.Size = new System.Drawing.Size(123, 20);
            this.chkAudiometria.TabIndex = 13;
            this.chkAudiometria.Text = "Ver Audiometria";
            this.chkAudiometria.UseVisualStyleBackColor = true;
            // 
            // chkResumen
            // 
            this.chkResumen.AutoSize = true;
            this.chkResumen.Location = new System.Drawing.Point(37, 138);
            this.chkResumen.Name = "chkResumen";
            this.chkResumen.Size = new System.Drawing.Size(115, 20);
            this.chkResumen.TabIndex = 12;
            this.chkResumen.Text = "Planilla del día";
            this.chkResumen.UseVisualStyleBackColor = true;
            // 
            // chkTurnos
            // 
            this.chkTurnos.AutoSize = true;
            this.chkTurnos.Location = new System.Drawing.Point(225, 101);
            this.chkTurnos.Name = "chkTurnos";
            this.chkTurnos.Size = new System.Drawing.Size(69, 20);
            this.chkTurnos.TabIndex = 11;
            this.chkTurnos.Text = "Turnos";
            this.chkTurnos.UseVisualStyleBackColor = true;
            // 
            // chkVentanilla
            // 
            this.chkVentanilla.AutoSize = true;
            this.chkVentanilla.Location = new System.Drawing.Point(38, 33);
            this.chkVentanilla.Name = "chkVentanilla";
            this.chkVentanilla.Size = new System.Drawing.Size(86, 20);
            this.chkVentanilla.TabIndex = 6;
            this.chkVentanilla.Text = "Ventanilla";
            this.chkVentanilla.UseVisualStyleBackColor = true;
            // 
            // chkMesaEntrada
            // 
            this.chkMesaEntrada.AutoSize = true;
            this.chkMesaEntrada.Location = new System.Drawing.Point(38, 67);
            this.chkMesaEntrada.Name = "chkMesaEntrada";
            this.chkMesaEntrada.Size = new System.Drawing.Size(129, 20);
            this.chkMesaEntrada.TabIndex = 7;
            this.chkMesaEntrada.Text = "Mesa de entrada";
            this.chkMesaEntrada.UseVisualStyleBackColor = true;
            // 
            // chkConfiguracion
            // 
            this.chkConfiguracion.AutoSize = true;
            this.chkConfiguracion.Location = new System.Drawing.Point(225, 67);
            this.chkConfiguracion.Name = "chkConfiguracion";
            this.chkConfiguracion.Size = new System.Drawing.Size(109, 20);
            this.chkConfiguracion.TabIndex = 9;
            this.chkConfiguracion.Text = "Configuración";
            this.chkConfiguracion.UseVisualStyleBackColor = true;
            // 
            // chkExamenes
            // 
            this.chkExamenes.AutoSize = true;
            this.chkExamenes.Location = new System.Drawing.Point(225, 33);
            this.chkExamenes.Name = "chkExamenes";
            this.chkExamenes.Size = new System.Drawing.Size(91, 20);
            this.chkExamenes.TabIndex = 8;
            this.chkExamenes.Text = "Examenes";
            this.chkExamenes.UseVisualStyleBackColor = true;
            // 
            // chkPacientes
            // 
            this.chkPacientes.AutoSize = true;
            this.chkPacientes.Location = new System.Drawing.Point(37, 101);
            this.chkPacientes.Name = "chkPacientes";
            this.chkPacientes.Size = new System.Drawing.Size(87, 20);
            this.chkPacientes.TabIndex = 10;
            this.chkPacientes.Text = "Pacientes";
            this.chkPacientes.UseVisualStyleBackColor = true;
            // 
            // txtNombreTipoUsuario
            // 
            this.txtNombreTipoUsuario.BackColor = System.Drawing.Color.White;
            this.txtNombreTipoUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreTipoUsuario.Enabled = false;
            this.txtNombreTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreTipoUsuario.Location = new System.Drawing.Point(19, 30);
            this.txtNombreTipoUsuario.Name = "txtNombreTipoUsuario";
            this.txtNombreTipoUsuario.Size = new System.Drawing.Size(305, 22);
            this.txtNombreTipoUsuario.TabIndex = 313;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 16);
            this.label9.TabIndex = 312;
            this.label9.Text = "Nombre tipo usuario";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnNuevo);
            this.panel3.Controls.Add(this.btnEliminar);
            this.panel3.Controls.Add(this.botCancelar);
            this.panel3.Controls.Add(this.botAceptar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(749, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(148, 422);
            this.panel3.TabIndex = 278;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(13, 356);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(123, 45);
            this.btnSalir.TabIndex = 278;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(13, 20);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(123, 45);
            this.btnNuevo.TabIndex = 277;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(13, 206);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(123, 45);
            this.btnEliminar.TabIndex = 276;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(13, 143);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(123, 45);
            this.botCancelar.TabIndex = 275;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botAceptar
            // 
            this.botAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botAceptar.Image")));
            this.botAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptar.Location = new System.Drawing.Point(13, 78);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(123, 45);
            this.botAceptar.TabIndex = 274;
            this.botAceptar.Text = "Guardar";
            this.botAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptar.UseVisualStyleBackColor = true;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // frmUsuarioSistemaTipo
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTotal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUsuarioSistemaTipo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipo usuario de sistema";
            this.Load += new System.EventHandler(this.frmUsuarioSistemaTipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNombreTipoUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.CheckBox chkModificar;
        private System.Windows.Forms.CheckBox chkVer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkResumen;
        private System.Windows.Forms.CheckBox chkTurnos;
        private System.Windows.Forms.CheckBox chkVentanilla;
        private System.Windows.Forms.CheckBox chkMesaEntrada;
        private System.Windows.Forms.CheckBox chkConfiguracion;
        private System.Windows.Forms.CheckBox chkExamenes;
        private System.Windows.Forms.CheckBox chkPacientes;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Button btnNuevo;
        protected System.Windows.Forms.Button btnEliminar;
        protected System.Windows.Forms.Button botCancelar;
        protected System.Windows.Forms.Button botAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAudiometria;
        protected System.Windows.Forms.Button btnSalir;
    }
}