namespace CapaPresentacion
{
    partial class frmMesaSelecTipoExamen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesaSelecTipoExamen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.botonPreventiva = new System.Windows.Forms.RadioButton();
            this.botonRepeticion = new System.Windows.Forms.RadioButton();
            this.botonLaboral = new System.Windows.Forms.RadioButton();
            this.botonClinica = new System.Windows.Forms.RadioButton();
            this.botonConsultorio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botAceptar = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // botonPreventiva
            // 
            this.botonPreventiva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonPreventiva.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonPreventiva.BackColor = System.Drawing.Color.MistyRose;
            this.botonPreventiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPreventiva.Location = new System.Drawing.Point(51, 21);
            this.botonPreventiva.Name = "botonPreventiva";
            this.botonPreventiva.Size = new System.Drawing.Size(37, 35);
            this.botonPreventiva.TabIndex = 25;
            this.botonPreventiva.Text = "P";
            this.botonPreventiva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonPreventiva.UseVisualStyleBackColor = false;
            this.botonPreventiva.CheckedChanged += new System.EventHandler(this.botonPreventiva_CheckedChanged);
            // 
            // botonRepeticion
            // 
            this.botonRepeticion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonRepeticion.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonRepeticion.BackColor = System.Drawing.Color.LightYellow;
            this.botonRepeticion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRepeticion.Location = new System.Drawing.Point(238, 21);
            this.botonRepeticion.Name = "botonRepeticion";
            this.botonRepeticion.Size = new System.Drawing.Size(38, 35);
            this.botonRepeticion.TabIndex = 28;
            this.botonRepeticion.Text = "R";
            this.botonRepeticion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonRepeticion.UseVisualStyleBackColor = false;
            this.botonRepeticion.CheckedChanged += new System.EventHandler(this.botonRepeticion_CheckedChanged);
            // 
            // botonLaboral
            // 
            this.botonLaboral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonLaboral.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonLaboral.BackColor = System.Drawing.Color.Moccasin;
            this.botonLaboral.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLaboral.Location = new System.Drawing.Point(94, 21);
            this.botonLaboral.Name = "botonLaboral";
            this.botonLaboral.Size = new System.Drawing.Size(35, 35);
            this.botonLaboral.TabIndex = 26;
            this.botonLaboral.Text = "L";
            this.botonLaboral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonLaboral.UseVisualStyleBackColor = false;
            this.botonLaboral.CheckedChanged += new System.EventHandler(this.botonLaboral_CheckedChanged);
            // 
            // botonClinica
            // 
            this.botonClinica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonClinica.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonClinica.BackColor = System.Drawing.Color.Azure;
            this.botonClinica.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClinica.Location = new System.Drawing.Point(135, 21);
            this.botonClinica.Name = "botonClinica";
            this.botonClinica.Size = new System.Drawing.Size(53, 35);
            this.botonClinica.TabIndex = 27;
            this.botonClinica.Text = "EC";
            this.botonClinica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonClinica.UseVisualStyleBackColor = false;
            this.botonClinica.CheckedChanged += new System.EventHandler(this.botonClinica_CheckedChanged);
            // 
            // botonConsultorio
            // 
            this.botonConsultorio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonConsultorio.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonConsultorio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.botonConsultorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConsultorio.Location = new System.Drawing.Point(194, 21);
            this.botonConsultorio.Name = "botonConsultorio";
            this.botonConsultorio.Size = new System.Drawing.Size(38, 35);
            this.botonConsultorio.TabIndex = 29;
            this.botonConsultorio.Text = "C";
            this.botonConsultorio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonConsultorio.UseVisualStyleBackColor = false;
            this.botonConsultorio.CheckedChanged += new System.EventHandler(this.botonConsultorio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonConsultorio);
            this.groupBox1.Controls.Add(this.botonPreventiva);
            this.groupBox1.Controls.Add(this.botonClinica);
            this.groupBox1.Controls.Add(this.botonRepeticion);
            this.groupBox1.Controls.Add(this.botonLaboral);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 64);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motivo de Consulta";
            // 
            // botAceptar
            // 
            this.botAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.botAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botAceptar.Image")));
            this.botAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptar.Location = new System.Drawing.Point(34, 447);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(136, 45);
            this.botAceptar.TabIndex = 279;
            this.botAceptar.Text = "Aceptar";
            this.botAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptar.UseVisualStyleBackColor = false;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.botCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(176, 447);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(136, 45);
            this.botCancelar.TabIndex = 278;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGrilla);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 345);
            this.groupBox2.TabIndex = 280;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Exámen";
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(11, 21);
            this.dgvGrilla.Name = "dgvGrilla";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGrilla.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrilla.Size = new System.Drawing.Size(306, 313);
            this.dgvGrilla.TabIndex = 31;
            this.dgvGrilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellDoubleClick);
            this.dgvGrilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Enabled = false;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBuscar.Location = new System.Drawing.Point(388, 88);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(276, 22);
            this.txtBuscar.TabIndex = 281;
            this.txtBuscar.Visible = false;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(339, 87);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(43, 13);
            this.lblNombre.TabIndex = 282;
            this.lblNombre.Text = "Buscar:";
            this.lblNombre.Visible = false;
            // 
            // frmMesaSelecTipoExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 499);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.botAceptar);
            this.Controls.Add(this.botCancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMesaSelecTipoExamen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Tipo Exámen";
            this.Load += new System.EventHandler(this.frmMesaSelecTipoExamen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton botonPreventiva;
        private System.Windows.Forms.RadioButton botonRepeticion;
        private System.Windows.Forms.RadioButton botonLaboral;
        private System.Windows.Forms.RadioButton botonClinica;
        private System.Windows.Forms.RadioButton botonConsultorio;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button botAceptar;
        protected System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblNombre;
    }
}