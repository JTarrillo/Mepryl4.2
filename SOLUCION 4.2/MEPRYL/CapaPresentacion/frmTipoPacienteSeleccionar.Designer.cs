namespace CapaPresentacion
{
    partial class frmTipoPacienteSeleccionar
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
            this.botLab = new System.Windows.Forms.Button();
            this.botPreventiva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botLab
            // 
            this.botLab.BackColor = System.Drawing.Color.SeaGreen;
            this.botLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLab.ForeColor = System.Drawing.Color.White;
            this.botLab.Location = new System.Drawing.Point(260, 22);
            this.botLab.Name = "botLab";
            this.botLab.Size = new System.Drawing.Size(128, 53);
            this.botLab.TabIndex = 9;
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
            this.botPreventiva.Location = new System.Drawing.Point(68, 22);
            this.botPreventiva.Name = "botPreventiva";
            this.botPreventiva.Size = new System.Drawing.Size(128, 53);
            this.botPreventiva.TabIndex = 8;
            this.botPreventiva.Text = "Preventiva";
            this.botPreventiva.UseVisualStyleBackColor = false;
            this.botPreventiva.Click += new System.EventHandler(this.botPreventiva_Click);
            // 
            // frmTipoPacienteSeleccionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 93);
            this.Controls.Add(this.botLab);
            this.Controls.Add(this.botPreventiva);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoPacienteSeleccionar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar tipo paciente";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button botLab;
        public System.Windows.Forms.Button botPreventiva;
    }
}