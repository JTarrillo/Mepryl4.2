namespace CapaPresentacion
{
    partial class frmRX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRX));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panDerecha = new System.Windows.Forms.Panel();
            this.butCancelar = new System.Windows.Forms.Button();
            this.butAceptar = new System.Windows.Forms.Button();
            this.pb70 = new System.Windows.Forms.PictureBox();
            this.cbo70 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pb71 = new System.Windows.Forms.PictureBox();
            this.cbo71 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb73 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pb72 = new System.Windows.Forms.PictureBox();
            this.cbo72 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb74 = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.panDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb72)).BeginInit();
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
            this.lbTitulo.Size = new System.Drawing.Size(620, 40);
            this.lbTitulo.TabIndex = 129;
            this.lbTitulo.Text = "Exámen de RX";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panDerecha
            // 
            this.panDerecha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panDerecha.Controls.Add(this.butCancelar);
            this.panDerecha.Controls.Add(this.butAceptar);
            this.panDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.panDerecha.Location = new System.Drawing.Point(620, 0);
            this.panDerecha.Name = "panDerecha";
            this.panDerecha.Size = new System.Drawing.Size(126, 368);
            this.panDerecha.TabIndex = 5;
            // 
            // butCancelar
            // 
            this.butCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(5, 182);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(115, 45);
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
            this.butAceptar.Location = new System.Drawing.Point(5, 131);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(115, 45);
            this.butAceptar.TabIndex = 0;
            this.butAceptar.Text = "Aceptar [F5]";
            this.butAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // pb70
            // 
            this.pb70.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pb70.Location = new System.Drawing.Point(517, 64);
            this.pb70.Name = "pb70";
            this.pb70.Size = new System.Drawing.Size(30, 26);
            this.pb70.TabIndex = 183;
            this.pb70.TabStop = false;
            // 
            // cbo70
            // 
            this.cbo70.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo70.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo70.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo70.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo70.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo70.FormattingEnabled = true;
            this.cbo70.Location = new System.Drawing.Point(175, 64);
            this.cbo70.Name = "cbo70";
            this.cbo70.Size = new System.Drawing.Size(336, 26);
            this.cbo70.TabIndex = 0;
            this.cbo70.SelectedIndexChanged += new System.EventHandler(this.cbo70_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 181;
            this.label6.Text = "RX Torax";
            // 
            // pb71
            // 
            this.pb71.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pb71.Location = new System.Drawing.Point(517, 105);
            this.pb71.Name = "pb71";
            this.pb71.Size = new System.Drawing.Size(30, 26);
            this.pb71.TabIndex = 186;
            this.pb71.TabStop = false;
            // 
            // cbo71
            // 
            this.cbo71.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo71.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo71.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo71.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo71.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo71.FormattingEnabled = true;
            this.cbo71.Location = new System.Drawing.Point(175, 105);
            this.cbo71.Name = "cbo71";
            this.cbo71.Size = new System.Drawing.Size(336, 26);
            this.cbo71.TabIndex = 1;
            this.cbo71.SelectedIndexChanged += new System.EventHandler(this.cbo71_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 184;
            this.label1.Text = "RX Columna";
            // 
            // tb73
            // 
            this.tb73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb73.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb73.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb73.Location = new System.Drawing.Point(175, 143);
            this.tb73.Name = "tb73";
            this.tb73.Size = new System.Drawing.Size(336, 24);
            this.tb73.TabIndex = 2;
            this.tb73.Enter += new System.EventHandler(this.tb73_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 188;
            this.label2.Text = "Otras RX";
            // 
            // pb72
            // 
            this.pb72.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pb72.Location = new System.Drawing.Point(541, 309);
            this.pb72.Name = "pb72";
            this.pb72.Size = new System.Drawing.Size(41, 32);
            this.pb72.TabIndex = 191;
            this.pb72.TabStop = false;
            // 
            // cbo72
            // 
            this.cbo72.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo72.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo72.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo72.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo72.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo72.FormattingEnabled = true;
            this.cbo72.Location = new System.Drawing.Point(135, 309);
            this.cbo72.Name = "cbo72";
            this.cbo72.Size = new System.Drawing.Size(400, 32);
            this.cbo72.TabIndex = 4;
            this.cbo72.SelectedIndexChanged += new System.EventHandler(this.cbo72_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 189;
            this.label3.Text = "Dictámen RX.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 193;
            this.label4.Text = "Observaciones";
            // 
            // tb74
            // 
            this.tb74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb74.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb74.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb74.Location = new System.Drawing.Point(175, 178);
            this.tb74.Multiline = true;
            this.tb74.Name = "tb74";
            this.tb74.Size = new System.Drawing.Size(336, 89);
            this.tb74.TabIndex = 3;
            this.tb74.Enter += new System.EventHandler(this.tb74_Enter);
            // 
            // tbId
            // 
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(5, 43);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(28, 22);
            this.tbId.TabIndex = 376;
            this.tbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbId.Visible = false;
            // 
            // frmRX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 368);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb74);
            this.Controls.Add(this.pb72);
            this.Controls.Add(this.cbo72);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb73);
            this.Controls.Add(this.pb71);
            this.Controls.Add(this.cbo71);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb70);
            this.Controls.Add(this.cbo70);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.panDerecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRX";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exámen de RX";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRX_KeyDown);
            this.panDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb72)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        protected System.Windows.Forms.Panel panDerecha;
        protected System.Windows.Forms.Button butCancelar;
        protected System.Windows.Forms.Button butAceptar;
        protected System.Windows.Forms.PictureBox pb70;
        private System.Windows.Forms.ComboBox cbo70;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.PictureBox pb71;
        private System.Windows.Forms.ComboBox cbo71;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb73;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.PictureBox pb72;
        private System.Windows.Forms.ComboBox cbo72;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb74;
        private System.Windows.Forms.TextBox tbId;
    }
}