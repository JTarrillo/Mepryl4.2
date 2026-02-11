namespace Comunes
{
    partial class frmManejadorErrores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManejadorErrores));
            this.butOk = new System.Windows.Forms.Button();
            this.butEnviarMail = new System.Windows.Forms.Button();
            this.Mensaje = new System.Windows.Forms.TextBox();
            this.Modulo = new System.Windows.Forms.TextBox();
            this.PilaLlamadas = new System.Windows.Forms.TextBox();
            this.blPilaLlamadas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(264, 376);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(120, 24);
            this.butOk.TabIndex = 34;
            this.butOk.Text = "&Ok";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butEnviarMail
            // 
            this.butEnviarMail.Enabled = false;
            this.butEnviarMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butEnviarMail.Image = ((System.Drawing.Image)(resources.GetObject("butEnviarMail.Image")));
            this.butEnviarMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEnviarMail.Location = new System.Drawing.Point(8, 376);
            this.butEnviarMail.Name = "butEnviarMail";
            this.butEnviarMail.Size = new System.Drawing.Size(176, 23);
            this.butEnviarMail.TabIndex = 33;
            this.butEnviarMail.Text = "Enviar error por e-mail";
            this.butEnviarMail.Click += new System.EventHandler(this.butEnviarMail_Click);
            // 
            // Mensaje
            // 
            this.Mensaje.AcceptsReturn = true;
            this.Mensaje.AcceptsTab = true;
            this.Mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mensaje.Location = new System.Drawing.Point(8, 120);
            this.Mensaje.Multiline = true;
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.ReadOnly = true;
            this.Mensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Mensaje.Size = new System.Drawing.Size(376, 112);
            this.Mensaje.TabIndex = 32;
            this.Mensaje.WordWrap = false;
            // 
            // Modulo
            // 
            this.Modulo.AcceptsReturn = true;
            this.Modulo.AcceptsTab = true;
            this.Modulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Modulo.Location = new System.Drawing.Point(8, 72);
            this.Modulo.Multiline = true;
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            this.Modulo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Modulo.Size = new System.Drawing.Size(376, 20);
            this.Modulo.TabIndex = 31;
            // 
            // PilaLlamadas
            // 
            this.PilaLlamadas.AcceptsReturn = true;
            this.PilaLlamadas.AcceptsTab = true;
            this.PilaLlamadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PilaLlamadas.Location = new System.Drawing.Point(8, 256);
            this.PilaLlamadas.Multiline = true;
            this.PilaLlamadas.Name = "PilaLlamadas";
            this.PilaLlamadas.ReadOnly = true;
            this.PilaLlamadas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PilaLlamadas.Size = new System.Drawing.Size(376, 112);
            this.PilaLlamadas.TabIndex = 30;
            this.PilaLlamadas.WordWrap = false;
            // 
            // blPilaLlamadas
            // 
            this.blPilaLlamadas.Location = new System.Drawing.Point(8, 240);
            this.blPilaLlamadas.Name = "blPilaLlamadas";
            this.blPilaLlamadas.Size = new System.Drawing.Size(104, 16);
            this.blPilaLlamadas.TabIndex = 29;
            this.blPilaLlamadas.Text = "Pila de llamadas";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Mensaje";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "M�dulo";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 32);
            this.label1.TabIndex = 26;
            this.label1.Text = "Ha ocurrido un error";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmManejadorErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 408);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butEnviarMail);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.Modulo);
            this.Controls.Add(this.PilaLlamadas);
            this.Controls.Add(this.blPilaLlamadas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManejadorErrores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOk;
        public System.Windows.Forms.Button butEnviarMail;
        public System.Windows.Forms.TextBox Mensaje;
        public System.Windows.Forms.TextBox Modulo;
        public System.Windows.Forms.TextBox PilaLlamadas;
        private System.Windows.Forms.Label blPilaLlamadas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}