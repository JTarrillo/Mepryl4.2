namespace CapaPresentacion
{
    partial class frmFotoPaciente
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Estado = new System.Windows.Forms.StatusStrip();
            this.cbxDispositivos = new System.Windows.Forms.ComboBox();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.ptbEspacioCamara = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbEspacioCamara)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.CancelarSalir;
            this.btnGuardar.Location = new System.Drawing.Point(12, 284);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 36);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Estado
            // 
            this.Estado.Location = new System.Drawing.Point(0, 333);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(277, 22);
            this.Estado.TabIndex = 7;
            this.Estado.Text = "Listo";
            // 
            // cbxDispositivos
            // 
            this.cbxDispositivos.FormattingEnabled = true;
            this.cbxDispositivos.Location = new System.Drawing.Point(12, 6);
            this.cbxDispositivos.Name = "cbxDispositivos";
            this.cbxDispositivos.Size = new System.Drawing.Size(253, 21);
            this.cbxDispositivos.TabIndex = 5;
            // 
            // btnCapturar
            // 
            this.btnCapturar.Image = global::CapaPresentacion.Properties.Resources.Camera_Front01;
            this.btnCapturar.Location = new System.Drawing.Point(159, 284);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(95, 36);
            this.btnCapturar.TabIndex = 9;
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // ptbEspacioCamara
            // 
            this.ptbEspacioCamara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbEspacioCamara.Location = new System.Drawing.Point(12, 33);
            this.ptbEspacioCamara.Name = "ptbEspacioCamara";
            this.ptbEspacioCamara.Size = new System.Drawing.Size(253, 245);
            this.ptbEspacioCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbEspacioCamara.TabIndex = 6;
            this.ptbEspacioCamara.TabStop = false;
            // 
            // frmFotoPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 355);
            this.Controls.Add(this.btnCapturar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.ptbEspacioCamara);
            this.Controls.Add(this.cbxDispositivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFotoPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tomar Fotografía";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFotoPaciente_FormClosing);
            this.Load += new System.EventHandler(this.frmFotoPaciente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbEspacioCamara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.StatusStrip Estado;
        private System.Windows.Forms.PictureBox ptbEspacioCamara;
        private System.Windows.Forms.ComboBox cbxDispositivos;
    }
}