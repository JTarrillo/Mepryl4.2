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
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.botLab = new System.Windows.Forms.Button();
            this.botPreventiva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMensaje
            // 
            this.tbMensaje.BackColor = System.Drawing.SystemColors.Control;
            this.tbMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMensaje.Enabled = false;
            this.tbMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMensaje.Location = new System.Drawing.Point(12, 16);
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.Size = new System.Drawing.Size(431, 14);
            this.tbMensaje.TabIndex = 2;
            this.tbMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // botLab
            // 
            this.botLab.BackColor = System.Drawing.Color.LightSeaGreen;
            this.botLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLab.ForeColor = System.Drawing.Color.White;
            this.botLab.Location = new System.Drawing.Point(230, 52);
            this.botLab.Name = "botLab";
            this.botLab.Size = new System.Drawing.Size(128, 53);
            this.botLab.TabIndex = 7;
            this.botLab.Text = "Laboral";
            this.botLab.UseVisualStyleBackColor = false;
            this.botLab.Click += new System.EventHandler(this.botLab_Click);
            // 
            // botPreventiva
            // 
            this.botPreventiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(84)))), ((int)(((byte)(173)))));
            this.botPreventiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botPreventiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botPreventiva.ForeColor = System.Drawing.Color.White;
            this.botPreventiva.Location = new System.Drawing.Point(96, 52);
            this.botPreventiva.Name = "botPreventiva";
            this.botPreventiva.Size = new System.Drawing.Size(128, 53);
            this.botPreventiva.TabIndex = 6;
            this.botPreventiva.Text = "Preventiva";
            this.botPreventiva.UseVisualStyleBackColor = false;
            this.botPreventiva.Click += new System.EventHandler(this.botPreventiva_Click);
            // 
            // frmTipoPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 125);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMensaje;
        public System.Windows.Forms.Button botLab;
        public System.Windows.Forms.Button botPreventiva;
    }
}