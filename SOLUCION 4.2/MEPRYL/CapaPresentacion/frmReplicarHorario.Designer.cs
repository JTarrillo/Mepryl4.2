namespace CapaPresentacion

{
    partial class frmReplicarHorario
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
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.dtpOrigenDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpOrigenHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDestinoDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpDestinoHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde1 = new System.Windows.Forms.Label();
            this.lblHasta1 = new System.Windows.Forms.Label();
            this.lblDesde2 = new System.Windows.Forms.Label();
            this.lblHasta2 = new System.Windows.Forms.Label();
            this.btnReplicar = new FontAwesome.Sharp.IconButton();
            this.cmbProfesional = new System.Windows.Forms.ComboBox();
            this.lblProfesional = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Location = new System.Drawing.Point(17, 76);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(82, 13);
            this.lblOrigen.TabIndex = 0;
            this.lblOrigen.Text = "Período Origen:";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(12, 133);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(87, 13);
            this.lblDestino.TabIndex = 1;
            this.lblDestino.Text = "Período Destino:";
            // 
            // dtpOrigenDesde
            // 
            this.dtpOrigenDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrigenDesde.Location = new System.Drawing.Point(121, 70);
            this.dtpOrigenDesde.Name = "dtpOrigenDesde";
            this.dtpOrigenDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpOrigenDesde.TabIndex = 2;
            // 
            // dtpOrigenHasta
            // 
            this.dtpOrigenHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrigenHasta.Location = new System.Drawing.Point(260, 70);
            this.dtpOrigenHasta.Name = "dtpOrigenHasta";
            this.dtpOrigenHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpOrigenHasta.TabIndex = 3;
            // 
            // dtpDestinoDesde
            // 
            this.dtpDestinoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDestinoDesde.Location = new System.Drawing.Point(121, 133);
            this.dtpDestinoDesde.Name = "dtpDestinoDesde";
            this.dtpDestinoDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDestinoDesde.TabIndex = 4;
            // 
            // dtpDestinoHasta
            // 
            this.dtpDestinoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDestinoHasta.Location = new System.Drawing.Point(260, 133);
            this.dtpDestinoHasta.Name = "dtpDestinoHasta";
            this.dtpDestinoHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpDestinoHasta.TabIndex = 5;
            // 
            // lblDesde1
            // 
            this.lblDesde1.AutoSize = true;
            this.lblDesde1.Location = new System.Drawing.Point(130, 45);
            this.lblDesde1.Name = "lblDesde1";
            this.lblDesde1.Size = new System.Drawing.Size(38, 13);
            this.lblDesde1.TabIndex = 6;
            this.lblDesde1.Text = "Desde";
            // 
            // lblHasta1
            // 
            this.lblHasta1.AutoSize = true;
            this.lblHasta1.Location = new System.Drawing.Point(257, 45);
            this.lblHasta1.Name = "lblHasta1";
            this.lblHasta1.Size = new System.Drawing.Size(35, 13);
            this.lblHasta1.TabIndex = 7;
            this.lblHasta1.Text = "Hasta";
            // 
            // lblDesde2
            // 
            this.lblDesde2.AutoSize = true;
            this.lblDesde2.Location = new System.Drawing.Point(130, 106);
            this.lblDesde2.Name = "lblDesde2";
            this.lblDesde2.Size = new System.Drawing.Size(38, 13);
            this.lblDesde2.TabIndex = 8;
            this.lblDesde2.Text = "Desde";
            // 
            // lblHasta2
            // 
            this.lblHasta2.AutoSize = true;
            this.lblHasta2.Location = new System.Drawing.Point(257, 106);
            this.lblHasta2.Name = "lblHasta2";
            this.lblHasta2.Size = new System.Drawing.Size(35, 13);
            this.lblHasta2.TabIndex = 9;
            this.lblHasta2.Text = "Hasta";
            // 
            // btnReplicar
            // 
            this.btnReplicar.IconChar = FontAwesome.Sharp.IconChar.Clone;
            this.btnReplicar.IconColor = System.Drawing.Color.Black;
            this.btnReplicar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReplicar.IconSize = 20;
            this.btnReplicar.Location = new System.Drawing.Point(133, 218);
            this.btnReplicar.Name = "btnReplicar";
            this.btnReplicar.Size = new System.Drawing.Size(120, 30);
            this.btnReplicar.TabIndex = 10;
            this.btnReplicar.Text = "Replicar";
            this.btnReplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReplicar.UseVisualStyleBackColor = true;
            this.btnReplicar.Click += new System.EventHandler(this.btnReplicar_Click);
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesional.FormattingEnabled = true;
            this.cmbProfesional.Location = new System.Drawing.Point(121, 4);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Size = new System.Drawing.Size(230, 21);
            this.cmbProfesional.TabIndex = 1;
            // 
            // lblProfesional
            // 
            this.lblProfesional.AutoSize = true;
            this.lblProfesional.Location = new System.Drawing.Point(26, 7);
            this.lblProfesional.Name = "lblProfesional";
            this.lblProfesional.Size = new System.Drawing.Size(62, 13);
            this.lblProfesional.TabIndex = 0;
            this.lblProfesional.Text = "Profesional:";
            // 
            // frmReplicarHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 282);
            this.Controls.Add(this.cmbProfesional);
            this.Controls.Add(this.lblProfesional);
            this.Controls.Add(this.btnReplicar);
            this.Controls.Add(this.lblHasta2);
            this.Controls.Add(this.lblDesde2);
            this.Controls.Add(this.lblHasta1);
            this.Controls.Add(this.lblDesde1);
            this.Controls.Add(this.dtpDestinoHasta);
            this.Controls.Add(this.dtpDestinoDesde);
            this.Controls.Add(this.dtpOrigenHasta);
            this.Controls.Add(this.dtpOrigenDesde);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblOrigen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplicarHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replicar Períodos de Horario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.DateTimePicker dtpOrigenDesde;
        private System.Windows.Forms.DateTimePicker dtpOrigenHasta;
        private System.Windows.Forms.DateTimePicker dtpDestinoDesde;
        private System.Windows.Forms.DateTimePicker dtpDestinoHasta;
        private System.Windows.Forms.Label lblDesde1;
        private System.Windows.Forms.Label lblHasta1;
        private System.Windows.Forms.Label lblDesde2;
        private System.Windows.Forms.Label lblHasta2;
        private FontAwesome.Sharp.IconButton btnReplicar;

        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.Label lblProfesional;
    }
}
