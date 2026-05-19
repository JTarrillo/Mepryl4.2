namespace CapaPresentacion
{
    partial class frmMesaSelecSubtipoExamen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblSubtipo = new System.Windows.Forms.Label();
            this.cbTipoPadre = new System.Windows.Forms.ComboBox();
            this.cbSubtipo = new System.Windows.Forms.ComboBox();
            this.botAceptar = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(30, 30);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(109, 16);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo de Examen:";
            // 
            // lblSubtipo
            // 
            this.lblSubtipo.AutoSize = true;
            this.lblSubtipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtipo.Location = new System.Drawing.Point(30, 90);
            this.lblSubtipo.Name = "lblSubtipo";
            this.lblSubtipo.Size = new System.Drawing.Size(127, 16);
            this.lblSubtipo.TabIndex = 2;
            this.lblSubtipo.Text = "Subtipo de Examen:";
            // 
            // cbTipoPadre
            // 
            this.cbTipoPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPadre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoPadre.FormattingEnabled = true;
            this.cbTipoPadre.Location = new System.Drawing.Point(30, 50);
            this.cbTipoPadre.Name = "cbTipoPadre";
            this.cbTipoPadre.Size = new System.Drawing.Size(1000, 24);
            this.cbTipoPadre.TabIndex = 1;
            this.cbTipoPadre.SelectedIndexChanged += new System.EventHandler(this.cbTipoPadre_SelectedIndexChanged);
            // 
            // cbSubtipo
            // 
            this.cbSubtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubtipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubtipo.FormattingEnabled = true;
            this.cbSubtipo.Location = new System.Drawing.Point(30, 110);
            this.cbSubtipo.Name = "cbSubtipo";
            this.cbSubtipo.Size = new System.Drawing.Size(1000, 24);
            this.cbSubtipo.TabIndex = 3;
            // 
            // botAceptar
            // 
            this.botAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.botAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botAceptar.Image = global::CapaPresentacion.Properties.Resources.disco_flexible;
            this.botAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptar.Location = new System.Drawing.Point(716, 155);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(150, 45);
            this.botAceptar.TabIndex = 4;
            this.botAceptar.Text = "Aceptar";
            this.botAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptar.UseVisualStyleBackColor = false;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.botCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botCancelar.Image = global::CapaPresentacion.Properties.Resources.cancelar;
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(884, 155);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(150, 45);
            this.botCancelar.TabIndex = 5;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // frmMesaSelecSubtipoExamen
            // 
            this.AcceptButton = this.botAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botCancelar;
            this.ClientSize = new System.Drawing.Size(1060, 220);
            this.Controls.Add(this.botCancelar);
            this.Controls.Add(this.botAceptar);
            this.Controls.Add(this.cbSubtipo);
            this.Controls.Add(this.cbTipoPadre);
            this.Controls.Add(this.lblSubtipo);
            this.Controls.Add(this.lblTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMesaSelecSubtipoExamen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Tipo y Subtipo de Examen";
            this.Load += new System.EventHandler(this.frmMesaSelecSubtipoExamen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblSubtipo;
        private System.Windows.Forms.ComboBox cbTipoPadre;
        private System.Windows.Forms.ComboBox cbSubtipo;
        protected System.Windows.Forms.Button botAceptar;
        protected System.Windows.Forms.Button botCancelar;
    }
}
