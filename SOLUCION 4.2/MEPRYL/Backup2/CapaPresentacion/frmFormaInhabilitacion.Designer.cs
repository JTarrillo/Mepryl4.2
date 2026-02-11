namespace CapaPresentacion
{
    partial class frmFormaInhabilitacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormaInhabilitacion));
            this.rbNoEfectuado = new System.Windows.Forms.RadioButton();
            this.rbNoRenovado = new System.Windows.Forms.RadioButton();
            this.butCancelar = new System.Windows.Forms.Button();
            this.butAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbNoEfectuado
            // 
            this.rbNoEfectuado.AutoSize = true;
            this.rbNoEfectuado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoEfectuado.Location = new System.Drawing.Point(58, 22);
            this.rbNoEfectuado.Name = "rbNoEfectuado";
            this.rbNoEfectuado.Size = new System.Drawing.Size(165, 24);
            this.rbNoEfectuado.TabIndex = 0;
            this.rbNoEfectuado.TabStop = true;
            this.rbNoEfectuado.Text = "NO EFECTUADO";
            this.rbNoEfectuado.UseVisualStyleBackColor = true;
            // 
            // rbNoRenovado
            // 
            this.rbNoRenovado.AutoSize = true;
            this.rbNoRenovado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoRenovado.Location = new System.Drawing.Point(58, 55);
            this.rbNoRenovado.Name = "rbNoRenovado";
            this.rbNoRenovado.Size = new System.Drawing.Size(157, 24);
            this.rbNoRenovado.TabIndex = 1;
            this.rbNoRenovado.TabStop = true;
            this.rbNoRenovado.Text = "NO RENOVADO";
            this.rbNoRenovado.UseVisualStyleBackColor = true;
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(141, 103);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(114, 45);
            this.butCancelar.TabIndex = 3;
            this.butCancelar.Text = "Cancelar";
            this.butCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click);
            // 
            // butAceptar
            // 
            this.butAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAceptar.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar.Image")));
            this.butAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar.Location = new System.Drawing.Point(21, 103);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(114, 45);
            this.butAceptar.TabIndex = 2;
            this.butAceptar.Text = "Aceptar";
            this.butAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // frmFormaInhabilitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 160);
            this.Controls.Add(this.butCancelar);
            this.Controls.Add(this.butAceptar);
            this.Controls.Add(this.rbNoRenovado);
            this.Controls.Add(this.rbNoEfectuado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormaInhabilitacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbNoEfectuado;
        private System.Windows.Forms.RadioButton rbNoRenovado;
        protected System.Windows.Forms.Button butCancelar;
        protected System.Windows.Forms.Button butAceptar;
    }
}