namespace CapaPresentacion
{
    partial class frmImportarLaboratorioLaboral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarLaboratorioLaboral));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImpExcel = new System.Windows.Forms.Button();
            this.botComenzarExcel = new System.Windows.Forms.Button();
            this.botImpExcel = new System.Windows.Forms.Button();
            this.tbArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnSalir2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.lbTitulo.Size = new System.Drawing.Size(379, 30);
            this.lbTitulo.TabIndex = 127;
            this.lbTitulo.Text = "Importación Laboratorio";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnImpExcel);
            this.groupBox1.Controls.Add(this.botComenzarExcel);
            this.groupBox1.Controls.Add(this.botImpExcel);
            this.groupBox1.Controls.Add(this.tbArchivo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 87);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel";
            // 
            // btnSalir
            // 
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(155, 83);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(110, 33);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Visible = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImpExcel
            // 
            this.btnImpExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImpExcel.Location = new System.Drawing.Point(306, 42);
            this.btnImpExcel.Name = "btnImpExcel";
            this.btnImpExcel.Size = new System.Drawing.Size(35, 29);
            this.btnImpExcel.TabIndex = 1;
            this.btnImpExcel.Text = "...";
            this.btnImpExcel.UseVisualStyleBackColor = false;
            this.btnImpExcel.Click += new System.EventHandler(this.btnImpExcel_Click);
            // 
            // botComenzarExcel
            // 
            this.botComenzarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botComenzarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzarExcel.Location = new System.Drawing.Point(11, 83);
            this.botComenzarExcel.Name = "botComenzarExcel";
            this.botComenzarExcel.Size = new System.Drawing.Size(110, 33);
            this.botComenzarExcel.TabIndex = 3;
            this.botComenzarExcel.Text = "Comenzar";
            this.botComenzarExcel.UseVisualStyleBackColor = true;
            this.botComenzarExcel.Visible = false;
            this.botComenzarExcel.Click += new System.EventHandler(this.botComenzarExcel_Click);
            // 
            // botImpExcel
            // 
            this.botImpExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImpExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpExcel.Location = new System.Drawing.Point(289, 41);
            this.botImpExcel.Name = "botImpExcel";
            this.botImpExcel.Size = new System.Drawing.Size(41, 22);
            this.botImpExcel.TabIndex = 2;
            this.botImpExcel.Text = "...";
            this.botImpExcel.UseVisualStyleBackColor = true;
            this.botImpExcel.Visible = false;
            this.botImpExcel.Click += new System.EventHandler(this.botImpExcel_Click);
            // 
            // tbArchivo
            // 
            this.tbArchivo.BackColor = System.Drawing.Color.White;
            this.tbArchivo.Location = new System.Drawing.Point(25, 45);
            this.tbArchivo.Name = "tbArchivo";
            this.tbArchivo.ReadOnly = true;
            this.tbArchivo.Size = new System.Drawing.Size(272, 22);
            this.tbArchivo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ubicación";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.MediumBlue;
            this.progressBar.Location = new System.Drawing.Point(12, 186);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(356, 15);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 130;
            this.progressBar.Visible = false;
            // 
            // btnComenzar
            // 
            this.btnComenzar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnComenzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnComenzar.Image = ((System.Drawing.Image)(resources.GetObject("btnComenzar.Image")));
            this.btnComenzar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComenzar.Location = new System.Drawing.Point(46, 135);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(113, 45);
            this.btnComenzar.TabIndex = 2;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComenzar.UseVisualStyleBackColor = false;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnSalir2
            // 
            this.btnSalir2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalir2.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir2.Image")));
            this.btnSalir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir2.Location = new System.Drawing.Point(221, 135);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(113, 45);
            this.btnSalir2.TabIndex = 3;
            this.btnSalir2.Text = "Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir2.UseVisualStyleBackColor = false;
            this.btnSalir2.Click += new System.EventHandler(this.btnSalir2_Click);
            // 
            // frmImportarLaboratorioLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 213);
            this.Controls.Add(this.btnSalir2);
            this.Controls.Add(this.btnComenzar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportarLaboratorioLaboral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Laboratorio Laboral";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botComenzarExcel;
        private System.Windows.Forms.Button botImpExcel;
        private System.Windows.Forms.TextBox tbArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnSalir2;
        public System.Windows.Forms.Button btnImpExcel;
    }
}