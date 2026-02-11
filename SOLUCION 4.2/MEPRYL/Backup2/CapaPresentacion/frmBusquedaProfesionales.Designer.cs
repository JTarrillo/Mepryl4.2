namespace CapaPresentacion
{
    partial class frmBusquedaProfesionales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaProfesionales));
            this.botonLaboratorio = new System.Windows.Forms.Panel();
            this.botVerDatos = new System.Windows.Forms.Button();
            this.botModificar = new System.Windows.Forms.Button();
            this.botEliminar = new System.Windows.Forms.Button();
            this.botAgregar = new System.Windows.Forms.Button();
            this.botFiltrar = new System.Windows.Forms.Button();
            this.tbFiltro = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.botLimpiar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.botonLaboratorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonLaboratorio
            // 
            this.botonLaboratorio.BackColor = System.Drawing.Color.Gainsboro;
            this.botonLaboratorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botonLaboratorio.Controls.Add(this.btnSalir);
            this.botonLaboratorio.Controls.Add(this.botVerDatos);
            this.botonLaboratorio.Controls.Add(this.botModificar);
            this.botonLaboratorio.Controls.Add(this.botEliminar);
            this.botonLaboratorio.Controls.Add(this.botAgregar);
            this.botonLaboratorio.Dock = System.Windows.Forms.DockStyle.Right;
            this.botonLaboratorio.Location = new System.Drawing.Point(791, 40);
            this.botonLaboratorio.Name = "botonLaboratorio";
            this.botonLaboratorio.Size = new System.Drawing.Size(213, 475);
            this.botonLaboratorio.TabIndex = 134;
            // 
            // botVerDatos
            // 
            this.botVerDatos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botVerDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botVerDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botVerDatos.Image = ((System.Drawing.Image)(resources.GetObject("botVerDatos.Image")));
            this.botVerDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botVerDatos.Location = new System.Drawing.Point(-1, 297);
            this.botVerDatos.Name = "botVerDatos";
            this.botVerDatos.Size = new System.Drawing.Size(213, 55);
            this.botVerDatos.TabIndex = 136;
            this.botVerDatos.Text = "Ver Datos";
            this.botVerDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botVerDatos.UseVisualStyleBackColor = true;
            this.botVerDatos.Click += new System.EventHandler(this.botVerDatos_Click);
            // 
            // botModificar
            // 
            this.botModificar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botModificar.Image = ((System.Drawing.Image)(resources.GetObject("botModificar.Image")));
            this.botModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botModificar.Location = new System.Drawing.Point(-1, 189);
            this.botModificar.Name = "botModificar";
            this.botModificar.Size = new System.Drawing.Size(213, 55);
            this.botModificar.TabIndex = 135;
            this.botModificar.Text = "Modificar";
            this.botModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botModificar.UseVisualStyleBackColor = true;
            this.botModificar.Click += new System.EventHandler(this.botModificar_Click);
            // 
            // botEliminar
            // 
            this.botEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar.Image")));
            this.botEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar.Location = new System.Drawing.Point(-1, 243);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(213, 55);
            this.botEliminar.TabIndex = 134;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // botAgregar
            // 
            this.botAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAgregar.Image = ((System.Drawing.Image)(resources.GetObject("botAgregar.Image")));
            this.botAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAgregar.Location = new System.Drawing.Point(-1, 135);
            this.botAgregar.Name = "botAgregar";
            this.botAgregar.Size = new System.Drawing.Size(213, 55);
            this.botAgregar.TabIndex = 133;
            this.botAgregar.Text = "Agregar";
            this.botAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAgregar.UseVisualStyleBackColor = true;
            this.botAgregar.Click += new System.EventHandler(this.botAgregar_Click);
            // 
            // botFiltrar
            // 
            this.botFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("botFiltrar.Image")));
            this.botFiltrar.Location = new System.Drawing.Point(3, 56);
            this.botFiltrar.Name = "botFiltrar";
            this.botFiltrar.Size = new System.Drawing.Size(100, 26);
            this.botFiltrar.TabIndex = 430;
            this.botFiltrar.UseVisualStyleBackColor = true;
            this.botFiltrar.Click += new System.EventHandler(this.botFiltrar_Click);
            // 
            // tbFiltro
            // 
            this.tbFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltro.Location = new System.Drawing.Point(3, 26);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(205, 26);
            this.tbFiltro.TabIndex = 429;
            this.tbFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFiltro_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(-1, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 19);
            this.label15.TabIndex = 427;
            this.label15.Text = "Buscar Médico";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.Silver;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv.ColumnHeadersHeight = 25;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.GridColor = System.Drawing.Color.DarkGray;
            this.dgv.Location = new System.Drawing.Point(0, 40);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(789, 475);
            this.dgv.TabIndex = 133;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1004, 40);
            this.lbTitulo.TabIndex = 132;
            this.lbTitulo.Text = "Staff Médico";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // botLimpiar
            // 
            this.botLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("botLimpiar.Image")));
            this.botLimpiar.Location = new System.Drawing.Point(106, 56);
            this.botLimpiar.Name = "botLimpiar";
            this.botLimpiar.Size = new System.Drawing.Size(102, 26);
            this.botLimpiar.TabIndex = 431;
            this.botLimpiar.UseVisualStyleBackColor = true;
            this.botLimpiar.Click += new System.EventHandler(this.botLimpiar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.botLimpiar);
            this.panel1.Controls.Add(this.botFiltrar);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.tbFiltro);
            this.panel1.Location = new System.Drawing.Point(791, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 89);
            this.panel1.TabIndex = 432;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(-1, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(213, 55);
            this.btnSalir.TabIndex = 137;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmBusquedaProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 515);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonLaboratorio);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBusquedaProfesionales";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Médico";
            this.botonLaboratorio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel botonLaboratorio;
        private System.Windows.Forms.Button botFiltrar;
        private System.Windows.Forms.TextBox tbFiltro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button botVerDatos;
        private System.Windows.Forms.Button botModificar;
        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.Button botAgregar;
        private System.Windows.Forms.DataGridView dgv;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Button botLimpiar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
    }
}