namespace CapaPresentacion
{
    partial class frmExportarMesaEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportarMesaEntrada));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIgualarFecha = new System.Windows.Forms.Button();
            this.tpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.botComenzar = new System.Windows.Forms.Button();
            this.botAbrirUbicacion = new System.Windows.Forms.Button();
            this.tbUbicacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTarea = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.lbTitulo.Size = new System.Drawing.Size(456, 30);
            this.lbTitulo.TabIndex = 141;
            this.lbTitulo.Text = "Exportación Mesa de Entrada";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIgualarFecha);
            this.groupBox1.Controls.Add(this.tpFechaHasta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tpFechaDesde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 80);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha";
            // 
            // btnIgualarFecha
            // 
            this.btnIgualarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgualarFecha.Location = new System.Drawing.Point(168, 42);
            this.btnIgualarFecha.Name = "btnIgualarFecha";
            this.btnIgualarFecha.Size = new System.Drawing.Size(96, 28);
            this.btnIgualarFecha.TabIndex = 138;
            this.btnIgualarFecha.Text = "Igualar Fecha";
            this.btnIgualarFecha.UseVisualStyleBackColor = false;
            this.btnIgualarFecha.Click += new System.EventHandler(this.btnIgualarFecha_Click);
            // 
            // tpFechaHasta
            // 
            this.tpFechaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.SeaGreen;
            this.tpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFechaHasta.Location = new System.Drawing.Point(281, 44);
            this.tpFechaHasta.Name = "tpFechaHasta";
            this.tpFechaHasta.Size = new System.Drawing.Size(123, 22);
            this.tpFechaHasta.TabIndex = 135;
            this.tpFechaHasta.Value = new System.DateTime(2017, 2, 21, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 134;
            this.label1.Text = "Hasta";
            // 
            // tpFechaDesde
            // 
            this.tpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaDesde.CalendarTitleBackColor = System.Drawing.Color.SeaGreen;
            this.tpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFechaDesde.Location = new System.Drawing.Point(30, 44);
            this.tpFechaDesde.Name = "tpFechaDesde";
            this.tpFechaDesde.Size = new System.Drawing.Size(123, 22);
            this.tpFechaDesde.TabIndex = 133;
            this.tpFechaDesde.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 132;
            this.label3.Text = "Desde";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.botComenzar);
            this.groupBox4.Controls.Add(this.botAbrirUbicacion);
            this.groupBox4.Controls.Add(this.tbUbicacion);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(432, 120);
            this.groupBox4.TabIndex = 144;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Exportación Excel";
            // 
            // botComenzar
            // 
            this.botComenzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzar.Location = new System.Drawing.Point(141, 83);
            this.botComenzar.Name = "botComenzar";
            this.botComenzar.Size = new System.Drawing.Size(125, 28);
            this.botComenzar.TabIndex = 10;
            this.botComenzar.Text = "Comenzar";
            this.botComenzar.UseVisualStyleBackColor = false;
            this.botComenzar.Click += new System.EventHandler(this.botComenzar_Click);
            // 
            // botAbrirUbicacion
            // 
            this.botAbrirUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAbrirUbicacion.Location = new System.Drawing.Point(363, 50);
            this.botAbrirUbicacion.Name = "botAbrirUbicacion";
            this.botAbrirUbicacion.Size = new System.Drawing.Size(41, 22);
            this.botAbrirUbicacion.TabIndex = 9;
            this.botAbrirUbicacion.Text = "...";
            this.botAbrirUbicacion.UseVisualStyleBackColor = false;
            this.botAbrirUbicacion.Click += new System.EventHandler(this.botAbrirUbicacion_Click);
            // 
            // tbUbicacion
            // 
            this.tbUbicacion.BackColor = System.Drawing.Color.White;
            this.tbUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUbicacion.Location = new System.Drawing.Point(30, 50);
            this.tbUbicacion.Name = "tbUbicacion";
            this.tbUbicacion.ReadOnly = true;
            this.tbUbicacion.Size = new System.Drawing.Size(327, 22);
            this.tbUbicacion.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ubicación";
            // 
            // lblTarea
            // 
            this.lblTarea.AutoSize = true;
            this.lblTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarea.ForeColor = System.Drawing.Color.Brown;
            this.lblTarea.Location = new System.Drawing.Point(10, 281);
            this.lblTarea.Name = "lblTarea";
            this.lblTarea.Size = new System.Drawing.Size(259, 16);
            this.lblTarea.TabIndex = 146;
            this.lblTarea.Text = "CONSULTANDO BASE DE DATOS...";
            this.lblTarea.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Location = new System.Drawing.Point(11, 253);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(301, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 145;
            this.progressBar.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(346, 257);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 36);
            this.btnCancelar.TabIndex = 147;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmExportarMesaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 301);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTarea);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportarMesaEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar Mesa de Entrada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker tpFechaHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tpFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button botComenzar;
        private System.Windows.Forms.Button botAbrirUbicacion;
        private System.Windows.Forms.TextBox tbUbicacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTarea;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnIgualarFecha;
        private System.Windows.Forms.Button btnCancelar;
    }
}