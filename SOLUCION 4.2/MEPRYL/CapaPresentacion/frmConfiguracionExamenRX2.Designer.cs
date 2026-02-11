namespace CapaPresentacion
{
    partial class frmConfiguracionExamenRX2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracionExamenRX2));
            this.dgvLiga = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.botGuardar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.botFiltrar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRX = new System.Windows.Forms.Button();
            this.btnDictamen = new System.Windows.Forms.Button();
            this.btnValidaciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiga)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLiga
            // 
            this.dgvLiga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiga.Location = new System.Drawing.Point(0, 114);
            this.dgvLiga.Name = "dgvLiga";
            this.dgvLiga.Size = new System.Drawing.Size(1003, 361);
            this.dgvLiga.TabIndex = 2;
            this.dgvLiga.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiga_CellClick);
            this.dgvLiga.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiga_CellContentClick);
            this.dgvLiga.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLiga_CellMouseDoubleClick);
            this.dgvLiga.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiga_CellMouseEnter);
            this.dgvLiga.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiga_CellMouseLeave);
            this.dgvLiga.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiga_CellValueChanged);
            this.dgvLiga.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLiga_RowLeave);
            this.dgvLiga.SelectionChanged += new System.EventHandler(this.dgvLiga_SelectionChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1003, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configuración estudios RX";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 134;
            this.label2.Text = "Buscar: ";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(97, 22);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(503, 22);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(980, 255);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 45);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(1002, 93);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(113, 45);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(980, 306);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(113, 45);
            this.botCancelar.TabIndex = 5;
            this.botCancelar.Text = "Eliminar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Visible = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(980, 408);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 45);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Visible = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // botGuardar
            // 
            this.botGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.botGuardar.Image = ((System.Drawing.Image)(resources.GetObject("botGuardar.Image")));
            this.botGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botGuardar.Location = new System.Drawing.Point(980, 357);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(113, 45);
            this.botGuardar.TabIndex = 131;
            this.botGuardar.Text = "Guardar";
            this.botGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botGuardar.UseVisualStyleBackColor = true;
            this.botGuardar.Visible = false;
            this.botGuardar.Click += new System.EventHandler(this.botGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.botFiltrar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 64);
            this.panel1.TabIndex = 135;
            // 
            // botFiltrar
            // 
            this.botFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.botFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("botFiltrar.Image")));
            this.botFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFiltrar.Location = new System.Drawing.Point(616, 17);
            this.botFiltrar.Name = "botFiltrar";
            this.botFiltrar.Size = new System.Drawing.Size(87, 33);
            this.botFiltrar.TabIndex = 437;
            this.botFiltrar.Text = "Buscar";
            this.botFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botFiltrar.UseVisualStyleBackColor = false;
            this.botFiltrar.Click += new System.EventHandler(this.botFiltrar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvLiga);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 475);
            this.panel2.TabIndex = 136;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRX);
            this.panel3.Controls.Add(this.btnDictamen);
            this.panel3.Controls.Add(this.btnValidaciones);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1003, 50);
            this.panel3.TabIndex = 320;
            // 
            // btnRX
            // 
            this.btnRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRX.Location = new System.Drawing.Point(362, 10);
            this.btnRX.Name = "btnRX";
            this.btnRX.Size = new System.Drawing.Size(69, 28);
            this.btnRX.TabIndex = 2;
            this.btnRX.Text = "RX";
            this.btnRX.UseVisualStyleBackColor = true;
            this.btnRX.Click += new System.EventHandler(this.btnRX_Click);
            // 
            // btnDictamen
            // 
            this.btnDictamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDictamen.Location = new System.Drawing.Point(154, 10);
            this.btnDictamen.Name = "btnDictamen";
            this.btnDictamen.Size = new System.Drawing.Size(202, 28);
            this.btnDictamen.TabIndex = 1;
            this.btnDictamen.Text = "Dictamenes Automaticos";
            this.btnDictamen.UseVisualStyleBackColor = true;
            this.btnDictamen.Click += new System.EventHandler(this.btnDictamen_Click);
            // 
            // btnValidaciones
            // 
            this.btnValidaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidaciones.Location = new System.Drawing.Point(28, 10);
            this.btnValidaciones.Name = "btnValidaciones";
            this.btnValidaciones.Size = new System.Drawing.Size(120, 28);
            this.btnValidaciones.TabIndex = 0;
            this.btnValidaciones.Text = "Validaciones";
            this.btnValidaciones.UseVisualStyleBackColor = true;
            this.btnValidaciones.Click += new System.EventHandler(this.btnValidaciones_Click);
            // 
            // frmConfiguracionExamenRX2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.botCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.botGuardar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConfiguracionExamenRX2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Examen RX";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfiguracionExamenRX2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiga)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLiga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button botGuardar;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRX;
        private System.Windows.Forms.Button btnDictamen;
        private System.Windows.Forms.Button btnValidaciones;
        public System.Windows.Forms.Button botFiltrar;
    }
}