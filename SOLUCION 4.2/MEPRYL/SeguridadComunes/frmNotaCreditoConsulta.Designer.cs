namespace Comunes
{
    partial class frmNotaCreditoConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaCreditoConsulta));
            this.ucNotaCreditoConsulta1 = new Comunes.ucNotaCreditoConsulta();
            this.SuspendLayout();
            // 
            // ucNotaCreditoConsulta1
            // 
            this.ucNotaCreditoConsulta1.configuracion = null;
            this.ucNotaCreditoConsulta1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNotaCreditoConsulta1.Location = new System.Drawing.Point(0, 0);
            this.ucNotaCreditoConsulta1.Name = "ucNotaCreditoConsulta1";
            this.ucNotaCreditoConsulta1.Size = new System.Drawing.Size(734, 360);
            this.ucNotaCreditoConsulta1.TabIndex = 0;
            // 
            // frmNotaCreditoConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 360);
            this.Controls.Add(this.ucNotaCreditoConsulta1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNotaCreditoConsulta";
            this.Text = "Consulta de Notas de Crédito";
            this.Enter += new System.EventHandler(this.frmNotaCreditoConsulta_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNotaCreditoConsulta_FormClosing);
            this.Load += new System.EventHandler(this.frmNotaCreditoConsulta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucNotaCreditoConsulta ucNotaCreditoConsulta1;
    }
}