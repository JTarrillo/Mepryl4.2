namespace CapaPresentacion
{
    partial class frmExportacionPreventiva
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
            this.lbTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botComenzarExcel = new System.Windows.Forms.Button();
            this.botImpExcel = new System.Windows.Forms.Button();
            this.tbExcel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.botComenzarDBF = new System.Windows.Forms.Button();
            this.botImpDBF = new System.Windows.Forms.Button();
            this.tbDBF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tpDesde = new System.Windows.Forms.DateTimePicker();
            this.tpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.botComenzarLafij = new System.Windows.Forms.Button();
            this.botImpLafij = new System.Windows.Forms.Button();
            this.tbLafij = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIgualarFecha = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(353, 30);
            this.lbTitulo.TabIndex = 126;
            this.lbTitulo.Text = "Exportación Preventiva";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botComenzarExcel);
            this.groupBox1.Controls.Add(this.botImpExcel);
            this.groupBox1.Controls.Add(this.tbExcel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 113);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel";
            // 
            // botComenzarExcel
            // 
            this.botComenzarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzarExcel.Location = new System.Drawing.Point(92, 75);
            this.botComenzarExcel.Name = "botComenzarExcel";
            this.botComenzarExcel.Size = new System.Drawing.Size(127, 30);
            this.botComenzarExcel.TabIndex = 3;
            this.botComenzarExcel.Text = "Comenzar";
            this.botComenzarExcel.UseVisualStyleBackColor = false;
            this.botComenzarExcel.Click += new System.EventHandler(this.botComenzarExcel_Click);
            // 
            // botImpExcel
            // 
            this.botImpExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpExcel.Location = new System.Drawing.Point(272, 43);
            this.botImpExcel.Name = "botImpExcel";
            this.botImpExcel.Size = new System.Drawing.Size(41, 22);
            this.botImpExcel.TabIndex = 2;
            this.botImpExcel.Text = "...";
            this.botImpExcel.UseVisualStyleBackColor = false;
            this.botImpExcel.Click += new System.EventHandler(this.botImpExcel_Click);
            // 
            // tbExcel
            // 
            this.tbExcel.BackColor = System.Drawing.Color.White;
            this.tbExcel.Location = new System.Drawing.Point(25, 43);
            this.tbExcel.Name = "tbExcel";
            this.tbExcel.ReadOnly = true;
            this.tbExcel.Size = new System.Drawing.Size(240, 22);
            this.tbExcel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ubicación";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.botComenzarDBF);
            this.groupBox2.Controls.Add(this.botImpDBF);
            this.groupBox2.Controls.Add(this.tbDBF);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 113);
            this.groupBox2.TabIndex = 128;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DBF";
            // 
            // botComenzarDBF
            // 
            this.botComenzarDBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzarDBF.Location = new System.Drawing.Point(94, 73);
            this.botComenzarDBF.Name = "botComenzarDBF";
            this.botComenzarDBF.Size = new System.Drawing.Size(127, 30);
            this.botComenzarDBF.TabIndex = 7;
            this.botComenzarDBF.Text = "Comenzar";
            this.botComenzarDBF.UseVisualStyleBackColor = false;
            this.botComenzarDBF.Click += new System.EventHandler(this.botComenzarDBF_Click);
            // 
            // botImpDBF
            // 
            this.botImpDBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpDBF.Location = new System.Drawing.Point(274, 40);
            this.botImpDBF.Name = "botImpDBF";
            this.botImpDBF.Size = new System.Drawing.Size(41, 22);
            this.botImpDBF.TabIndex = 6;
            this.botImpDBF.Text = "...";
            this.botImpDBF.UseVisualStyleBackColor = false;
            this.botImpDBF.Click += new System.EventHandler(this.botImpDBF_Click);
            // 
            // tbDBF
            // 
            this.tbDBF.BackColor = System.Drawing.Color.White;
            this.tbDBF.Location = new System.Drawing.Point(25, 40);
            this.tbDBF.Name = "tbDBF";
            this.tbDBF.ReadOnly = true;
            this.tbDBF.Size = new System.Drawing.Size(240, 22);
            this.tbDBF.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ubicación";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.MediumBlue;
            this.progressBar.Location = new System.Drawing.Point(6, 451);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(335, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 129;
            this.progressBar.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 130;
            this.label3.Text = "Desde";
            // 
            // tpDesde
            // 
            this.tpDesde.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.tpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpDesde.Location = new System.Drawing.Point(9, 56);
            this.tpDesde.Name = "tpDesde";
            this.tpDesde.Size = new System.Drawing.Size(112, 22);
            this.tpDesde.TabIndex = 131;
            this.tpDesde.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // tpHasta
            // 
            this.tpHasta.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.tpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpHasta.Location = new System.Drawing.Point(229, 56);
            this.tpHasta.Name = "tpHasta";
            this.tpHasta.Size = new System.Drawing.Size(112, 22);
            this.tpHasta.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(226, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 132;
            this.label4.Text = "Hasta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.botComenzarLafij);
            this.groupBox3.Controls.Add(this.botImpLafij);
            this.groupBox3.Controls.Add(this.tbLafij);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 113);
            this.groupBox3.TabIndex = 134;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Examinados LAFIJ";
            // 
            // botComenzarLafij
            // 
            this.botComenzarLafij.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzarLafij.Location = new System.Drawing.Point(92, 74);
            this.botComenzarLafij.Name = "botComenzarLafij";
            this.botComenzarLafij.Size = new System.Drawing.Size(127, 30);
            this.botComenzarLafij.TabIndex = 3;
            this.botComenzarLafij.Text = "Comenzar";
            this.botComenzarLafij.UseVisualStyleBackColor = false;
            this.botComenzarLafij.Click += new System.EventHandler(this.botComenzarLafij_Click);
            // 
            // botImpLafij
            // 
            this.botImpLafij.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpLafij.Location = new System.Drawing.Point(272, 43);
            this.botImpLafij.Name = "botImpLafij";
            this.botImpLafij.Size = new System.Drawing.Size(41, 22);
            this.botImpLafij.TabIndex = 2;
            this.botImpLafij.Text = "...";
            this.botImpLafij.UseVisualStyleBackColor = false;
            this.botImpLafij.Click += new System.EventHandler(this.botImpLafij_Click);
            // 
            // tbLafij
            // 
            this.tbLafij.BackColor = System.Drawing.Color.White;
            this.tbLafij.Location = new System.Drawing.Point(25, 43);
            this.tbLafij.Name = "tbLafij";
            this.tbLafij.ReadOnly = true;
            this.tbLafij.Size = new System.Drawing.Size(240, 22);
            this.tbLafij.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ubicación";
            // 
            // btnIgualarFecha
            // 
            this.btnIgualarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgualarFecha.Location = new System.Drawing.Point(127, 54);
            this.btnIgualarFecha.Name = "btnIgualarFecha";
            this.btnIgualarFecha.Size = new System.Drawing.Size(96, 28);
            this.btnIgualarFecha.TabIndex = 138;
            this.btnIgualarFecha.Text = "Igualar Fecha";
            this.btnIgualarFecha.UseVisualStyleBackColor = false;
            this.btnIgualarFecha.Click += new System.EventHandler(this.btnIgualarFecha_Click);
            // 
            // frmExportacionPreventiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 480);
            this.Controls.Add(this.btnIgualarFecha);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tpHasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tpDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportacionPreventiva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportación Preventiva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExportacionPreventiva_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button botImpExcel;
        private System.Windows.Forms.TextBox tbExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botComenzarExcel;
        private System.Windows.Forms.Button botComenzarDBF;
        private System.Windows.Forms.Button botImpDBF;
        private System.Windows.Forms.TextBox tbDBF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker tpDesde;
        private System.Windows.Forms.DateTimePicker tpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button botComenzarLafij;
        private System.Windows.Forms.Button botImpLafij;
        private System.Windows.Forms.TextBox tbLafij;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIgualarFecha;
    }
}