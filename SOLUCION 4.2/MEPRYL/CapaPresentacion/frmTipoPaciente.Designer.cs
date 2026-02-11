namespace CapaPresentacion
{
    partial class frmTipoPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoPaciente));
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.botLab = new System.Windows.Forms.Button();
            this.botPreventiva = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMensaje
            // 
            this.tbMensaje.BackColor = System.Drawing.SystemColors.Control;
            this.tbMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMensaje.Enabled = false;
            this.tbMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMensaje.Location = new System.Drawing.Point(73, 29);
            this.tbMensaje.Multiline = true;
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.Size = new System.Drawing.Size(385, 17);
            this.tbMensaje.TabIndex = 2;
            this.tbMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // botLab
            // 
            this.botLab.BackColor = System.Drawing.Color.SeaGreen;
            this.botLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLab.ForeColor = System.Drawing.Color.White;
            this.botLab.Location = new System.Drawing.Point(280, 72);
            this.botLab.Name = "botLab";
            this.botLab.Size = new System.Drawing.Size(128, 36);
            this.botLab.TabIndex = 7;
            this.botLab.Text = "Laboral";
            this.botLab.UseVisualStyleBackColor = false;
            this.botLab.Click += new System.EventHandler(this.botLab_Click);
            // 
            // botPreventiva
            // 
            this.botPreventiva.BackColor = System.Drawing.Color.SteelBlue;
            this.botPreventiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botPreventiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botPreventiva.ForeColor = System.Drawing.Color.White;
            this.botPreventiva.Location = new System.Drawing.Point(90, 72);
            this.botPreventiva.Name = "botPreventiva";
            this.botPreventiva.Size = new System.Drawing.Size(128, 36);
            this.botPreventiva.TabIndex = 6;
            this.botPreventiva.Text = "Preventiva";
            this.botPreventiva.UseVisualStyleBackColor = false;
            this.botPreventiva.Click += new System.EventHandler(this.botPreventiva_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(9, 9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(55, 52);
            this.pictureBox7.TabIndex = 31;
            this.pictureBox7.TabStop = false;
            // 
            // frmTipoPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 120);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.botLab);
            this.Controls.Add(this.botPreventiva);
            this.Controls.Add(this.tbMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoPaciente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMensaje;
        public System.Windows.Forms.Button botLab;
        public System.Windows.Forms.Button botPreventiva;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}