namespace CapaPresentacion
{
    partial class frmUtilidadesPaginaWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUtilidadesPaginaWeb));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.botComenzarLafij = new System.Windows.Forms.Button();
            this.botImpLafij = new System.Windows.Forms.Button();
            this.tbLafij = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botComenzarExcel = new System.Windows.Forms.Button();
            this.botImpExcel = new System.Windows.Forms.Button();
            this.tbExcel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.DarkOrange;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(378, 40);
            this.lbTitulo.TabIndex = 128;
            this.lbTitulo.Text = "Listados para la Página Web";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.botComenzarLafij);
            this.groupBox3.Controls.Add(this.botImpLafij);
            this.groupBox3.Controls.Add(this.tbLafij);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(29, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 100);
            this.groupBox3.TabIndex = 141;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Excel de Planillas de LAFIJ";
            // 
            // botComenzarLafij
            // 
            this.botComenzarLafij.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botComenzarLafij.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzarLafij.Location = new System.Drawing.Point(87, 72);
            this.botComenzarLafij.Name = "botComenzarLafij";
            this.botComenzarLafij.Size = new System.Drawing.Size(141, 22);
            this.botComenzarLafij.TabIndex = 3;
            this.botComenzarLafij.Text = "Comenzar";
            this.botComenzarLafij.UseVisualStyleBackColor = true;
            this.botComenzarLafij.Click += new System.EventHandler(this.botComenzarLafij_Click);
            // 
            // botImpLafij
            // 
            this.botImpLafij.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImpLafij.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpLafij.Location = new System.Drawing.Point(272, 41);
            this.botImpLafij.Name = "botImpLafij";
            this.botImpLafij.Size = new System.Drawing.Size(41, 22);
            this.botImpLafij.TabIndex = 2;
            this.botImpLafij.Text = "...";
            this.botImpLafij.UseVisualStyleBackColor = true;
            this.botImpLafij.Click += new System.EventHandler(this.botImpLafij_Click);
            // 
            // tbLafij
            // 
            this.tbLafij.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLafij.Location = new System.Drawing.Point(11, 41);
            this.tbLafij.Name = "tbLafij";
            this.tbLafij.ReadOnly = true;
            this.tbLafij.Size = new System.Drawing.Size(254, 22);
            this.tbLafij.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ubicación";
            // 
            // tpHasta
            // 
            this.tpHasta.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.tpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpHasta.Location = new System.Drawing.Point(241, 68);
            this.tpHasta.Name = "tpHasta";
            this.tpHasta.Size = new System.Drawing.Size(112, 22);
            this.tpHasta.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(238, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 139;
            this.label4.Text = "Hasta";
            // 
            // tpDesde
            // 
            this.tpDesde.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.tpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpDesde.Location = new System.Drawing.Point(29, 68);
            this.tpDesde.Name = "tpDesde";
            this.tpDesde.Size = new System.Drawing.Size(112, 22);
            this.tpDesde.TabIndex = 138;
            this.tpDesde.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 137;
            this.label3.Text = "Desde";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.DarkOrange;
            this.progressBar.Location = new System.Drawing.Point(29, 316);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(324, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 136;
            this.progressBar.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botComenzarExcel);
            this.groupBox1.Controls.Add(this.botImpExcel);
            this.groupBox1.Controls.Add(this.tbExcel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 100);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel de Jugadores Examinados";
            // 
            // botComenzarExcel
            // 
            this.botComenzarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botComenzarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzarExcel.Location = new System.Drawing.Point(87, 72);
            this.botComenzarExcel.Name = "botComenzarExcel";
            this.botComenzarExcel.Size = new System.Drawing.Size(141, 22);
            this.botComenzarExcel.TabIndex = 3;
            this.botComenzarExcel.Text = "Comenzar";
            this.botComenzarExcel.UseVisualStyleBackColor = true;
            this.botComenzarExcel.Click += new System.EventHandler(this.botComenzarExcel_Click);
            // 
            // botImpExcel
            // 
            this.botImpExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImpExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpExcel.Location = new System.Drawing.Point(272, 41);
            this.botImpExcel.Name = "botImpExcel";
            this.botImpExcel.Size = new System.Drawing.Size(41, 22);
            this.botImpExcel.TabIndex = 2;
            this.botImpExcel.Text = "...";
            this.botImpExcel.UseVisualStyleBackColor = true;
            this.botImpExcel.Click += new System.EventHandler(this.botImpExcel_Click);
            // 
            // tbExcel
            // 
            this.tbExcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbExcel.Location = new System.Drawing.Point(11, 41);
            this.tbExcel.Name = "tbExcel";
            this.tbExcel.ReadOnly = true;
            this.tbExcel.Size = new System.Drawing.Size(254, 22);
            this.tbExcel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ubicación";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(331, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 40);
            this.pictureBox1.TabIndex = 142;
            this.pictureBox1.TabStop = false;
            // 
            // frmUtilidadesPaginaWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 355);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tpHasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tpDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmUtilidadesPaginaWeb";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados para la Página Web";
            this.Load += new System.EventHandler(this.frmUtilidadesPaginaWeb_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button botComenzarLafij;
        private System.Windows.Forms.Button botImpLafij;
        private System.Windows.Forms.TextBox tbLafij;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker tpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botComenzarExcel;
        private System.Windows.Forms.Button botImpExcel;
        private System.Windows.Forms.TextBox tbExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}