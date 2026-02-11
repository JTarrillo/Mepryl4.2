namespace Comunes
{
    partial class frmPlanillaRepartoAlta
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
            this.ucPlanillaRepartoAlta1 = new Comunes.ucPlanillaRepartoAlta();
            this.SuspendLayout();
            // 
            // ucPlanillaRepartoAlta1
            // 
            this.ucPlanillaRepartoAlta1.configuracion = null;
            this.ucPlanillaRepartoAlta1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlanillaRepartoAlta1.Location = new System.Drawing.Point(0, 0);
            this.ucPlanillaRepartoAlta1.Name = "ucPlanillaRepartoAlta1";
            this.ucPlanillaRepartoAlta1.Size = new System.Drawing.Size(804, 432);
            this.ucPlanillaRepartoAlta1.TabIndex = 0;
            this.ucPlanillaRepartoAlta1.Load += new System.EventHandler(this.ucPlanillaRepartoAlta1_Load);
            // 
            // frmPlanillaRepartoAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 432);
            this.Controls.Add(this.ucPlanillaRepartoAlta1);
            this.Name = "frmPlanillaRepartoAlta";
            this.Text = "Nueva Planilla de Reparto";
            this.Enter += new System.EventHandler(this.frmPlanillaRepartoAlta_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlanillaRepartoAlta_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPlanillaRepartoAlta ucPlanillaRepartoAlta1;
    }
}