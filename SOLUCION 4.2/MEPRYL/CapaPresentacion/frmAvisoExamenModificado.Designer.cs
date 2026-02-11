namespace CapaPresentacion
{
    partial class frmAvisoExamenModificado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvisoExamenModificado));
            this.botonAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClinico = new System.Windows.Forms.TextBox();
            this.tbLaboratorio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEstudiosComplementarios = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbImporte = new System.Windows.Forms.TextBox();
            this.botonImprimir = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botonAceptar
            // 
            this.botonAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botonAceptar.Image")));
            this.botonAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonAceptar.Location = new System.Drawing.Point(360, 435);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(125, 45);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonAceptar.UseVisualStyleBackColor = false;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Clínico";
            // 
            // tbClinico
            // 
            this.tbClinico.BackColor = System.Drawing.Color.White;
            this.tbClinico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClinico.Location = new System.Drawing.Point(12, 72);
            this.tbClinico.Multiline = true;
            this.tbClinico.Name = "tbClinico";
            this.tbClinico.ReadOnly = true;
            this.tbClinico.Size = new System.Drawing.Size(361, 26);
            this.tbClinico.TabIndex = 4;
            // 
            // tbLaboratorio
            // 
            this.tbLaboratorio.BackColor = System.Drawing.Color.White;
            this.tbLaboratorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLaboratorio.Location = new System.Drawing.Point(12, 123);
            this.tbLaboratorio.Multiline = true;
            this.tbLaboratorio.Name = "tbLaboratorio";
            this.tbLaboratorio.ReadOnly = true;
            this.tbLaboratorio.Size = new System.Drawing.Size(495, 82);
            this.tbLaboratorio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Laboratorio";
            // 
            // tbRx
            // 
            this.tbRx.BackColor = System.Drawing.Color.White;
            this.tbRx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRx.Location = new System.Drawing.Point(12, 231);
            this.tbRx.Multiline = true;
            this.tbRx.Name = "tbRx";
            this.tbRx.ReadOnly = true;
            this.tbRx.Size = new System.Drawing.Size(495, 76);
            this.tbRx.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rayos X";
            // 
            // tbEstudiosComplementarios
            // 
            this.tbEstudiosComplementarios.BackColor = System.Drawing.Color.White;
            this.tbEstudiosComplementarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEstudiosComplementarios.Location = new System.Drawing.Point(12, 336);
            this.tbEstudiosComplementarios.Multiline = true;
            this.tbEstudiosComplementarios.Name = "tbEstudiosComplementarios";
            this.tbEstudiosComplementarios.ReadOnly = true;
            this.tbEstudiosComplementarios.Size = new System.Drawing.Size(495, 84);
            this.tbEstudiosComplementarios.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estudios Complementarios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Importe";
            // 
            // tbImporte
            // 
            this.tbImporte.BackColor = System.Drawing.Color.White;
            this.tbImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbImporte.Location = new System.Drawing.Point(388, 72);
            this.tbImporte.Name = "tbImporte";
            this.tbImporte.ReadOnly = true;
            this.tbImporte.Size = new System.Drawing.Size(119, 26);
            this.tbImporte.TabIndex = 12;
            this.tbImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // botonImprimir
            // 
            this.botonImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("botonImprimir.Image")));
            this.botonImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonImprimir.Location = new System.Drawing.Point(25, 435);
            this.botonImprimir.Name = "botonImprimir";
            this.botonImprimir.Size = new System.Drawing.Size(125, 45);
            this.botonImprimir.TabIndex = 14;
            this.botonImprimir.Text = "Imprimir";
            this.botonImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonImprimir.UseVisualStyleBackColor = false;
            this.botonImprimir.Click += new System.EventHandler(this.botonImprimir_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.SeaGreen;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(0, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(523, 35);
            this.lblNombre.TabIndex = 264;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAvisoExamenModificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 492);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.botonImprimir);
            this.Controls.Add(this.tbImporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEstudiosComplementarios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbLaboratorio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbClinico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botonAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAvisoExamenModificado";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aviso de Examen";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAvisoExamenModificado_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbClinico;
        private System.Windows.Forms.TextBox tbLaboratorio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEstudiosComplementarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbImporte;
        private System.Windows.Forms.Button botonImprimir;
        protected System.Windows.Forms.Label lblNombre;
    }
}