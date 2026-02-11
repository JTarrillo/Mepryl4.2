namespace UserControls
{
    partial class ucComboBoxActualizable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboCombo
            // 
            this.cboCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCombo.FormattingEnabled = true;
            this.cboCombo.Location = new System.Drawing.Point(0, 0);
            this.cboCombo.Name = "cboCombo";
            this.cboCombo.Size = new System.Drawing.Size(145, 21);
            this.cboCombo.TabIndex = 0;
            this.cboCombo.SelectedIndexChanged += new System.EventHandler(this.cboCombo_SelectedIndexChanged);
            this.cboCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCombo_KeyDown);
            this.cboCombo.TextChanged += new System.EventHandler(this.cboCombo_TextChanged);
            // 
            // ucComboBoxActualizable
            // 
            this.Controls.Add(this.cboCombo);
            this.Name = "ucComboBoxActualizable";
            this.Size = new System.Drawing.Size(145, 24);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cboCombo;




    }
}
