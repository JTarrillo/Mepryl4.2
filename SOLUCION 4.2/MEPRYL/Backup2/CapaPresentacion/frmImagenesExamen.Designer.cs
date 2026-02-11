namespace CapaPresentacion
{
    partial class frmImagenesExamen
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
            this.botAgCarg = new System.Windows.Forms.Button();
            this.botQuitCarg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbIdCarg = new System.Windows.Forms.TextBox();
            this.pbCarg = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbIdNoCarg = new System.Windows.Forms.TextBox();
            this.pbNoCarg = new System.Windows.Forms.PictureBox();
            this.botAgNoCarg = new System.Windows.Forms.Button();
            this.botQuitNoCarg = new System.Windows.Forms.Button();
            this.botFL1 = new System.Windows.Forms.Button();
            this.botFD = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarg)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoCarg)).BeginInit();
            this.SuspendLayout();
            // 
            // botAgCarg
            // 
            this.botAgCarg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAgCarg.Location = new System.Drawing.Point(6, 73);
            this.botAgCarg.Name = "botAgCarg";
            this.botAgCarg.Size = new System.Drawing.Size(56, 23);
            this.botAgCarg.TabIndex = 1;
            this.botAgCarg.Text = "Agregar";
            this.botAgCarg.UseVisualStyleBackColor = true;
            this.botAgCarg.Click += new System.EventHandler(this.botAgCarg_Click);
            // 
            // botQuitCarg
            // 
            this.botQuitCarg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botQuitCarg.Location = new System.Drawing.Point(67, 73);
            this.botQuitCarg.Name = "botQuitCarg";
            this.botQuitCarg.Size = new System.Drawing.Size(56, 23);
            this.botQuitCarg.TabIndex = 2;
            this.botQuitCarg.Text = "Quitar";
            this.botQuitCarg.UseVisualStyleBackColor = true;
            this.botQuitCarg.Click += new System.EventHandler(this.botQuitCarg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botFD);
            this.groupBox1.Controls.Add(this.tbIdCarg);
            this.groupBox1.Controls.Add(this.pbCarg);
            this.groupBox1.Controls.Add(this.botAgCarg);
            this.groupBox1.Controls.Add(this.botQuitCarg);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 114);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exámen Cargado";
            // 
            // tbIdCarg
            // 
            this.tbIdCarg.Location = new System.Drawing.Point(6, 19);
            this.tbIdCarg.Name = "tbIdCarg";
            this.tbIdCarg.Size = new System.Drawing.Size(26, 20);
            this.tbIdCarg.TabIndex = 4;
            this.tbIdCarg.Visible = false;
            // 
            // pbCarg
            // 
            this.pbCarg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCarg.Location = new System.Drawing.Point(129, 19);
            this.pbCarg.Name = "pbCarg";
            this.pbCarg.Size = new System.Drawing.Size(77, 77);
            this.pbCarg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCarg.TabIndex = 3;
            this.pbCarg.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.botFL1);
            this.groupBox2.Controls.Add(this.tbIdNoCarg);
            this.groupBox2.Controls.Add(this.pbNoCarg);
            this.groupBox2.Controls.Add(this.botAgNoCarg);
            this.groupBox2.Controls.Add(this.botQuitNoCarg);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 114);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exámen No Cargado";
            // 
            // tbIdNoCarg
            // 
            this.tbIdNoCarg.Location = new System.Drawing.Point(6, 19);
            this.tbIdNoCarg.Name = "tbIdNoCarg";
            this.tbIdNoCarg.Size = new System.Drawing.Size(26, 20);
            this.tbIdNoCarg.TabIndex = 5;
            this.tbIdNoCarg.Visible = false;
            // 
            // pbNoCarg
            // 
            this.pbNoCarg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNoCarg.Location = new System.Drawing.Point(129, 19);
            this.pbNoCarg.Name = "pbNoCarg";
            this.pbNoCarg.Size = new System.Drawing.Size(77, 77);
            this.pbNoCarg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNoCarg.TabIndex = 3;
            this.pbNoCarg.TabStop = false;
            // 
            // botAgNoCarg
            // 
            this.botAgNoCarg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAgNoCarg.Location = new System.Drawing.Point(6, 73);
            this.botAgNoCarg.Name = "botAgNoCarg";
            this.botAgNoCarg.Size = new System.Drawing.Size(56, 23);
            this.botAgNoCarg.TabIndex = 1;
            this.botAgNoCarg.Text = "Agregar";
            this.botAgNoCarg.UseVisualStyleBackColor = true;
            this.botAgNoCarg.Click += new System.EventHandler(this.botAgNoCarg_Click);
            // 
            // botQuitNoCarg
            // 
            this.botQuitNoCarg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botQuitNoCarg.Location = new System.Drawing.Point(67, 73);
            this.botQuitNoCarg.Name = "botQuitNoCarg";
            this.botQuitNoCarg.Size = new System.Drawing.Size(56, 23);
            this.botQuitNoCarg.TabIndex = 2;
            this.botQuitNoCarg.Text = "Quitar";
            this.botQuitNoCarg.UseVisualStyleBackColor = true;
            this.botQuitNoCarg.Click += new System.EventHandler(this.botQuitNoCarg_Click);
            // 
            // botFL1
            // 
            this.botFL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFL1.Location = new System.Drawing.Point(95, 19);
            this.botFL1.Name = "botFL1";
            this.botFL1.Size = new System.Drawing.Size(28, 23);
            this.botFL1.TabIndex = 6;
            this.botFL1.Text = "...";
            this.botFL1.UseVisualStyleBackColor = true;
            this.botFL1.Click += new System.EventHandler(this.botFL1_Click);
            // 
            // botFD
            // 
            this.botFD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFD.Location = new System.Drawing.Point(95, 19);
            this.botFD.Name = "botFD";
            this.botFD.Size = new System.Drawing.Size(28, 23);
            this.botFD.TabIndex = 7;
            this.botFD.Text = "...";
            this.botFD.UseVisualStyleBackColor = true;
            this.botFD.Click += new System.EventHandler(this.botFD_Click);
            // 
            // frmImagenesExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 262);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImagenesExamen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarg)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoCarg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botAgCarg;
        private System.Windows.Forms.Button botQuitCarg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbCarg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbNoCarg;
        private System.Windows.Forms.Button botAgNoCarg;
        private System.Windows.Forms.Button botQuitNoCarg;
        private System.Windows.Forms.TextBox tbIdCarg;
        private System.Windows.Forms.TextBox tbIdNoCarg;
        private System.Windows.Forms.Button botFD;
        private System.Windows.Forms.Button botFL1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}