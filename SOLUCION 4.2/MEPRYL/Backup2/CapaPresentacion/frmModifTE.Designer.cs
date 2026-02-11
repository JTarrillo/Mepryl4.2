namespace CapaPresentacion
{
    partial class frmModifTE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifTE));
            this.label5 = new System.Windows.Forms.Label();
            this.cbTipoDeExamen = new System.Windows.Forms.ComboBox();
            this.botCancelar = new System.Windows.Forms.Button();
            this.botAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 16);
            this.label5.TabIndex = 270;
            this.label5.Text = "Seleccione Tipo de Exámen";
            // 
            // cbTipoDeExamen
            // 
            this.cbTipoDeExamen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbTipoDeExamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoDeExamen.FormattingEnabled = true;
            this.cbTipoDeExamen.Location = new System.Drawing.Point(47, 35);
            this.cbTipoDeExamen.Name = "cbTipoDeExamen";
            this.cbTipoDeExamen.Size = new System.Drawing.Size(334, 28);
            this.cbTipoDeExamen.TabIndex = 269;
            // 
            // botCancelar
            // 
            this.botCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(220, 89);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(100, 46);
            this.botCancelar.TabIndex = 272;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botAceptar
            // 
            this.botAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botAceptar.Image")));
            this.botAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptar.Location = new System.Drawing.Point(108, 89);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(100, 46);
            this.botAceptar.TabIndex = 271;
            this.botAceptar.Text = "Aceptar";
            this.botAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptar.UseVisualStyleBackColor = true;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // frmModifTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 160);
            this.Controls.Add(this.botCancelar);
            this.Controls.Add(this.botAceptar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTipoDeExamen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifTE";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación Tipo de Exámen";
            this.Load += new System.EventHandler(this.frmModifTE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTipoDeExamen;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.Button botAceptar;
    }
}