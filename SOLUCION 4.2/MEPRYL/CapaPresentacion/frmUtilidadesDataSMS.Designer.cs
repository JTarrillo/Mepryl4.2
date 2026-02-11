namespace CapaPresentacion
{
    partial class frmUtilidadesDataSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUtilidadesDataSMS));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.botComenzarDBF = new System.Windows.Forms.Button();
            this.botImpDBF = new System.Windows.Forms.Button();
            this.tbDBF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnIgualarFecha = new System.Windows.Forms.Button();
            this.lblTarea = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(407, 30);
            this.lbTitulo.TabIndex = 143;
            this.lbTitulo.Text = "Exportación para DataSMS";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpHasta
            // 
            this.tpHasta.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.tpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpHasta.Location = new System.Drawing.Point(263, 59);
            this.tpHasta.Name = "tpHasta";
            this.tpHasta.Size = new System.Drawing.Size(112, 22);
            this.tpHasta.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 148;
            this.label4.Text = "Hasta";
            // 
            // tpDesde
            // 
            this.tpDesde.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.tpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpDesde.Location = new System.Drawing.Point(26, 59);
            this.tpDesde.Name = "tpDesde";
            this.tpDesde.Size = new System.Drawing.Size(112, 22);
            this.tpDesde.TabIndex = 147;
            this.tpDesde.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 146;
            this.label3.Text = "Desde";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.botComenzarDBF);
            this.groupBox2.Controls.Add(this.botImpDBF);
            this.groupBox2.Controls.Add(this.tbDBF);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 127);
            this.groupBox2.TabIndex = 145;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generar Archivo DATOS.dbf";
            // 
            // botComenzarDBF
            // 
            this.botComenzarDBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzarDBF.Location = new System.Drawing.Point(98, 89);
            this.botComenzarDBF.Name = "botComenzarDBF";
            this.botComenzarDBF.Size = new System.Drawing.Size(141, 22);
            this.botComenzarDBF.TabIndex = 7;
            this.botComenzarDBF.Text = "Comenzar";
            this.botComenzarDBF.UseVisualStyleBackColor = true;
            this.botComenzarDBF.Click += new System.EventHandler(this.botComenzarDBF_Click);
            // 
            // botImpDBF
            // 
            this.botImpDBF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImpDBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpDBF.Location = new System.Drawing.Point(283, 58);
            this.botImpDBF.Name = "botImpDBF";
            this.botImpDBF.Size = new System.Drawing.Size(41, 22);
            this.botImpDBF.TabIndex = 6;
            this.botImpDBF.Text = "...";
            this.botImpDBF.UseVisualStyleBackColor = true;
            this.botImpDBF.Click += new System.EventHandler(this.botImpDBF_Click);
            // 
            // tbDBF
            // 
            this.tbDBF.BackColor = System.Drawing.Color.White;
            this.tbDBF.Enabled = false;
            this.tbDBF.Location = new System.Drawing.Point(22, 58);
            this.tbDBF.Name = "tbDBF";
            this.tbDBF.ReadOnly = true;
            this.tbDBF.Size = new System.Drawing.Size(254, 22);
            this.tbDBF.TabIndex = 5;
            this.tbDBF.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ubicación";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Location = new System.Drawing.Point(26, 234);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(256, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 150;
            this.progressBar.Visible = false;
            // 
            // btnIgualarFecha
            // 
            this.btnIgualarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgualarFecha.Location = new System.Drawing.Point(151, 55);
            this.btnIgualarFecha.Name = "btnIgualarFecha";
            this.btnIgualarFecha.Size = new System.Drawing.Size(96, 28);
            this.btnIgualarFecha.TabIndex = 151;
            this.btnIgualarFecha.Text = "Igualar Fecha";
            this.btnIgualarFecha.UseVisualStyleBackColor = false;
            this.btnIgualarFecha.Click += new System.EventHandler(this.btnIgualarFecha_Click);
            // 
            // lblTarea
            // 
            this.lblTarea.AutoSize = true;
            this.lblTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarea.ForeColor = System.Drawing.Color.Maroon;
            this.lblTarea.Location = new System.Drawing.Point(23, 255);
            this.lblTarea.Name = "lblTarea";
            this.lblTarea.Size = new System.Drawing.Size(259, 16);
            this.lblTarea.TabIndex = 152;
            this.lblTarea.Text = "CONSULTANDO BASE DE DATOS...";
            this.lblTarea.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(298, 236);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 36);
            this.btnCancelar.TabIndex = 153;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmUtilidadesDataSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 276);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTarea);
            this.Controls.Add(this.btnIgualarFecha);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tpHasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tpDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmUtilidadesDataSMS";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportación para DataSMS";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DateTimePicker tpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button botComenzarDBF;
        private System.Windows.Forms.Button botImpDBF;
        private System.Windows.Forms.TextBox tbDBF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnIgualarFecha;
        private System.Windows.Forms.Label lblTarea;
        private System.Windows.Forms.Button btnCancelar;
    }
}