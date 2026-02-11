namespace Comunes
{
    partial class frmManejadorErroresEMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManejadorErroresEMail));
            this.Mensaje = new System.Windows.Forms.TextBox();
            this.Modulo = new System.Windows.Forms.TextBox();
            this.PilaLlamadas = new System.Windows.Forms.TextBox();
            this.butSalir = new System.Windows.Forms.Button();
            this.butEnviar = new System.Windows.Forms.Button();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Mensaje
            // 
            this.Mensaje.AcceptsReturn = true;
            this.Mensaje.AcceptsTab = true;
            this.Mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mensaje.Location = new System.Drawing.Point(284, 49);
            this.Mensaje.Multiline = true;
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.ReadOnly = true;
            this.Mensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Mensaje.Size = new System.Drawing.Size(71, 88);
            this.Mensaje.TabIndex = 21;
            this.Mensaje.Visible = false;
            this.Mensaje.WordWrap = false;
            // 
            // Modulo
            // 
            this.Modulo.AcceptsReturn = true;
            this.Modulo.AcceptsTab = true;
            this.Modulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Modulo.Location = new System.Drawing.Point(284, 1);
            this.Modulo.Multiline = true;
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            this.Modulo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Modulo.Size = new System.Drawing.Size(71, 20);
            this.Modulo.TabIndex = 20;
            this.Modulo.Visible = false;
            // 
            // PilaLlamadas
            // 
            this.PilaLlamadas.AcceptsReturn = true;
            this.PilaLlamadas.AcceptsTab = true;
            this.PilaLlamadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PilaLlamadas.Location = new System.Drawing.Point(284, 161);
            this.PilaLlamadas.Multiline = true;
            this.PilaLlamadas.Name = "PilaLlamadas";
            this.PilaLlamadas.ReadOnly = true;
            this.PilaLlamadas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PilaLlamadas.Size = new System.Drawing.Size(71, 88);
            this.PilaLlamadas.TabIndex = 19;
            this.PilaLlamadas.Visible = false;
            this.PilaLlamadas.WordWrap = false;
            // 
            // butSalir
            // 
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(412, 137);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(75, 23);
            this.butSalir.TabIndex = 18;
            this.butSalir.Text = "Salir";
            this.butSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // butEnviar
            // 
            this.butEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butEnviar.Image = ((System.Drawing.Image)(resources.GetObject("butEnviar.Image")));
            this.butEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEnviar.Location = new System.Drawing.Point(412, 97);
            this.butEnviar.Name = "butEnviar";
            this.butEnviar.Size = new System.Drawing.Size(75, 23);
            this.butEnviar.TabIndex = 17;
            this.butEnviar.Text = "Enviar";
            this.butEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEnviar.Click += new System.EventHandler(this.butEnviar_Click);
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.Location = new System.Drawing.Point(12, 33);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbObservaciones.Size = new System.Drawing.Size(392, 192);
            this.tbObservaciones.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Observaciones";
            // 
            // frmManejadorErroresEMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 256);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.Modulo);
            this.Controls.Add(this.PilaLlamadas);
            this.Controls.Add(this.butSalir);
            this.Controls.Add(this.butEnviar);
            this.Controls.Add(this.tbObservaciones);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManejadorErroresEMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar Error por E-Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Mensaje;
        public System.Windows.Forms.TextBox Modulo;
        public System.Windows.Forms.TextBox PilaLlamadas;
        private System.Windows.Forms.Button butSalir;
        private System.Windows.Forms.Button butEnviar;
        private System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.Label label2;
    }
}