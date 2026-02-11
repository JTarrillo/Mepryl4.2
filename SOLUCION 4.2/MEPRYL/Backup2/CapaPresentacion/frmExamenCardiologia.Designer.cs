namespace CapaPresentacion
{
    partial class frmExamenCardiologia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamenCardiologia));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panDerecha = new System.Windows.Forms.Panel();
            this.butCancelar = new System.Windows.Forms.Button();
            this.butAceptar = new System.Windows.Forms.Button();
            this.pb80 = new System.Windows.Forms.PictureBox();
            this.cbo80 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pb81 = new System.Windows.Forms.PictureBox();
            this.cbo81 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb82 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.panDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb81)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.MediumBlue;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(627, 40);
            this.lbTitulo.TabIndex = 129;
            this.lbTitulo.Text = "Exámen Cardiológico";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panDerecha
            // 
            this.panDerecha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panDerecha.Controls.Add(this.butCancelar);
            this.panDerecha.Controls.Add(this.butAceptar);
            this.panDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.panDerecha.Location = new System.Drawing.Point(627, 0);
            this.panDerecha.Name = "panDerecha";
            this.panDerecha.Size = new System.Drawing.Size(126, 340);
            this.panDerecha.TabIndex = 3;
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(6, 166);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(114, 45);
            this.butCancelar.TabIndex = 1;
            this.butCancelar.Text = "Cancelar [F10]";
            this.butCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click);
            // 
            // butAceptar
            // 
            this.butAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.butAceptar.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar.Image")));
            this.butAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar.Location = new System.Drawing.Point(6, 115);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(114, 45);
            this.butAceptar.TabIndex = 0;
            this.butAceptar.Text = "Aceptar [F5]";
            this.butAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // pb80
            // 
            this.pb80.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pb80.Location = new System.Drawing.Point(512, 59);
            this.pb80.Name = "pb80";
            this.pb80.Size = new System.Drawing.Size(30, 26);
            this.pb80.TabIndex = 182;
            this.pb80.TabStop = false;
            // 
            // cbo80
            // 
            this.cbo80.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo80.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo80.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo80.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo80.FormattingEnabled = true;
            this.cbo80.Location = new System.Drawing.Point(170, 59);
            this.cbo80.Name = "cbo80";
            this.cbo80.Size = new System.Drawing.Size(336, 26);
            this.cbo80.TabIndex = 0;
            this.cbo80.SelectedIndexChanged += new System.EventHandler(this.cbo80_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 180;
            this.label4.Text = "Electrocardiograma";
            // 
            // pb81
            // 
            this.pb81.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pb81.Location = new System.Drawing.Point(562, 259);
            this.pb81.Name = "pb81";
            this.pb81.Size = new System.Drawing.Size(39, 32);
            this.pb81.TabIndex = 185;
            this.pb81.TabStop = false;
            // 
            // cbo81
            // 
            this.cbo81.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo81.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo81.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo81.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo81.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo81.FormattingEnabled = true;
            this.cbo81.Location = new System.Drawing.Point(139, 259);
            this.cbo81.Name = "cbo81";
            this.cbo81.Size = new System.Drawing.Size(417, 32);
            this.cbo81.TabIndex = 2;
            this.cbo81.SelectedIndexChanged += new System.EventHandler(this.cbo81_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 183;
            this.label1.Text = "Dict. Cardiológico";
            // 
            // tb82
            // 
            this.tb82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb82.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb82.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb82.Location = new System.Drawing.Point(170, 91);
            this.tb82.Multiline = true;
            this.tb82.Name = "tb82";
            this.tb82.Size = new System.Drawing.Size(336, 106);
            this.tb82.TabIndex = 1;
            this.tb82.Enter += new System.EventHandler(this.tb82_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 187;
            this.label2.Text = "Observaciones";
            // 
            // tbId
            // 
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(5, 43);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(28, 22);
            this.tbId.TabIndex = 375;
            this.tbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbId.Visible = false;
            // 
            // frmExamenCardiologia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 340);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb82);
            this.Controls.Add(this.pb81);
            this.Controls.Add(this.cbo81);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb80);
            this.Controls.Add(this.cbo80);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.panDerecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExamenCardiologia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nombre Paciente";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmExamenCardiologia_KeyDown);
            this.panDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb81)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        protected System.Windows.Forms.Panel panDerecha;
        protected System.Windows.Forms.Button butCancelar;
        protected System.Windows.Forms.Button butAceptar;
        protected System.Windows.Forms.PictureBox pb80;
        private System.Windows.Forms.ComboBox cbo80;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.PictureBox pb81;
        private System.Windows.Forms.ComboBox cbo81;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb82;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbId;
    }
}