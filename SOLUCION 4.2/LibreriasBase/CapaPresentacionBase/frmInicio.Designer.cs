namespace CapaPresentacionBase
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.botLab = new System.Windows.Forms.Button();
            this.botPreventiva = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // botLab
            // 
            this.botLab.BackColor = System.Drawing.Color.LightSeaGreen;
            this.botLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLab.ForeColor = System.Drawing.Color.White;
            this.botLab.Location = new System.Drawing.Point(337, 206);
            this.botLab.Name = "botLab";
            this.botLab.Size = new System.Drawing.Size(305, 71);
            this.botLab.TabIndex = 5;
            this.botLab.Text = "Medicina Laboral";
            this.botLab.UseVisualStyleBackColor = false;
            this.botLab.Click += new System.EventHandler(this.botLab_Click);
            // 
            // botPreventiva
            // 
            this.botPreventiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(84)))), ((int)(((byte)(173)))));
            this.botPreventiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botPreventiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botPreventiva.ForeColor = System.Drawing.Color.White;
            this.botPreventiva.Location = new System.Drawing.Point(26, 206);
            this.botPreventiva.Name = "botPreventiva";
            this.botPreventiva.Size = new System.Drawing.Size(305, 71);
            this.botPreventiva.TabIndex = 4;
            this.botPreventiva.Text = "Medicina Preventiva";
            this.botPreventiva.UseVisualStyleBackColor = false;
            this.botPreventiva.Click += new System.EventHandler(this.botPreventiva_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(9, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(649, 168);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 311);
            this.Controls.Add(this.botLab);
            this.Controls.Add(this.botPreventiva);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInicio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInicio";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button botLab;
        public System.Windows.Forms.Button botPreventiva;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}