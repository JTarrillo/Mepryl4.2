namespace CapaPresentacion
{
    partial class frmBusquedaLaboral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaLaboral));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.botBuscarPorDia = new System.Windows.Forms.Button();
            this.tpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.IdConsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoConsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdConsultaLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoConsultaLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnostico = new System.Windows.Forms.DataGridViewImageColumn();
            this.FechaAltaCitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dictamen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdExamenLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdConsultorioLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClinicoCargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoExamen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.botBuscar = new System.Windows.Forms.Button();
            this.tpHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tpDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.botCO = new System.Windows.Forms.CheckBox();
            this.botL = new System.Windows.Forms.CheckBox();
            this.botV = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.botImportar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnExportarOlivera = new System.Windows.Forms.Button();
            this.btnExportarExamenes = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.botLimpiar = new System.Windows.Forms.Button();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botFiltrar = new System.Windows.Forms.Button();
            this.botImportarCasino = new System.Windows.Forms.Button();
            this.botCambiarEmpresa = new System.Windows.Forms.Button();
            this.botMail = new System.Windows.Forms.Button();
            this.botImprimirEx = new System.Windows.Forms.Button();
            this.botonRango = new System.Windows.Forms.Button();
            this.botonFecha = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1349, 40);
            this.lbTitulo.TabIndex = 126;
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.botBuscarPorDia);
            this.panel1.Controls.Add(this.tpFecha);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 135);
            this.panel1.TabIndex = 127;
            // 
            // botBuscarPorDia
            // 
            this.botBuscarPorDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botBuscarPorDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botBuscarPorDia.Image = ((System.Drawing.Image)(resources.GetObject("botBuscarPorDia.Image")));
            this.botBuscarPorDia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botBuscarPorDia.Location = new System.Drawing.Point(6, 97);
            this.botBuscarPorDia.Name = "botBuscarPorDia";
            this.botBuscarPorDia.Size = new System.Drawing.Size(106, 33);
            this.botBuscarPorDia.TabIndex = 277;
            this.botBuscarPorDia.Text = "Buscar";
            this.botBuscarPorDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botBuscarPorDia.Click += new System.EventHandler(this.botBuscarPorDia_Click);
            // 
            // tpFecha
            // 
            this.tpFecha.CalendarMonthBackground = System.Drawing.Color.White;
            this.tpFecha.CalendarTitleBackColor = System.Drawing.Color.MediumBlue;
            this.tpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.tpFecha.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.tpFecha.CustomFormat = "yyyy";
            this.tpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFecha.Location = new System.Drawing.Point(6, 43);
            this.tpFecha.Name = "tpFecha";
            this.tpFecha.Size = new System.Drawing.Size(106, 26);
            this.tpFecha.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdConsulta,
            this.Fecha,
            this.Hora,
            this.Identif,
            this.MotivoConsulta,
            this.IdEmpresa,
            this.Empresa,
            this.Tarea,
            this.DNI,
            this.Paciente,
            this.IdPaciente,
            this.IdConsultaLaboral,
            this.TipoConsultaLaboral,
            this.EstadoAtencion,
            this.Diagnostico,
            this.FechaAltaCitacion,
            this.Dictamen,
            this.IdExamenLaboral,
            this.IdConsultorioLaboral,
            this.ClinicoCargado,
            this.IdTipoExamen});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 182);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.RowTemplate.Height = 25;
            this.dgv.Size = new System.Drawing.Size(1349, 314);
            this.dgv.TabIndex = 128;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // IdConsulta
            // 
            this.IdConsulta.HeaderText = "IdConsulta";
            this.IdConsulta.Name = "IdConsulta";
            this.IdConsulta.ReadOnly = true;
            this.IdConsulta.Visible = false;
            this.IdConsulta.Width = 82;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 62;
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 55;
            // 
            // Identif
            // 
            this.Identif.HeaderText = "Ident.";
            this.Identif.Name = "Identif";
            this.Identif.ReadOnly = true;
            this.Identif.Width = 59;
            // 
            // MotivoConsulta
            // 
            this.MotivoConsulta.HeaderText = "Motivo Consulta";
            this.MotivoConsulta.Name = "MotivoConsulta";
            this.MotivoConsulta.ReadOnly = true;
            this.MotivoConsulta.Width = 99;
            // 
            // IdEmpresa
            // 
            this.IdEmpresa.HeaderText = "IdEmpresa";
            this.IdEmpresa.Name = "IdEmpresa";
            this.IdEmpresa.ReadOnly = true;
            this.IdEmpresa.Visible = false;
            this.IdEmpresa.Width = 82;
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Width = 73;
            // 
            // Tarea
            // 
            this.Tarea.HeaderText = "Tarea";
            this.Tarea.Name = "Tarea";
            this.Tarea.ReadOnly = true;
            this.Tarea.Width = 60;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 51;
            // 
            // Paciente
            // 
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            this.Paciente.Width = 74;
            // 
            // IdPaciente
            // 
            this.IdPaciente.HeaderText = "IdPaciente";
            this.IdPaciente.Name = "IdPaciente";
            this.IdPaciente.ReadOnly = true;
            this.IdPaciente.Visible = false;
            this.IdPaciente.Width = 83;
            // 
            // IdConsultaLaboral
            // 
            this.IdConsultaLaboral.HeaderText = "IdConsultaLaboral";
            this.IdConsultaLaboral.Name = "IdConsultaLaboral";
            this.IdConsultaLaboral.ReadOnly = true;
            this.IdConsultaLaboral.Visible = false;
            this.IdConsultaLaboral.Width = 117;
            // 
            // TipoConsultaLaboral
            // 
            this.TipoConsultaLaboral.HeaderText = "TipoConsultaLaboral";
            this.TipoConsultaLaboral.Name = "TipoConsultaLaboral";
            this.TipoConsultaLaboral.ReadOnly = true;
            this.TipoConsultaLaboral.Visible = false;
            this.TipoConsultaLaboral.Width = 129;
            // 
            // EstadoAtencion
            // 
            this.EstadoAtencion.HeaderText = "Estado Atención";
            this.EstadoAtencion.Name = "EstadoAtencion";
            this.EstadoAtencion.ReadOnly = true;
            this.EstadoAtencion.Width = 101;
            // 
            // Diagnostico
            // 
            this.Diagnostico.HeaderText = "Diagnostico";
            this.Diagnostico.Image = ((System.Drawing.Image)(resources.GetObject("Diagnostico.Image")));
            this.Diagnostico.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Diagnostico.Name = "Diagnostico";
            this.Diagnostico.ReadOnly = true;
            this.Diagnostico.Width = 69;
            // 
            // FechaAltaCitacion
            // 
            this.FechaAltaCitacion.HeaderText = "Fecha Alta/Citación";
            this.FechaAltaCitacion.Name = "FechaAltaCitacion";
            this.FechaAltaCitacion.ReadOnly = true;
            this.FechaAltaCitacion.Width = 115;
            // 
            // Dictamen
            // 
            this.Dictamen.HeaderText = "Dictamen";
            this.Dictamen.Name = "Dictamen";
            this.Dictamen.ReadOnly = true;
            this.Dictamen.Width = 77;
            // 
            // IdExamenLaboral
            // 
            this.IdExamenLaboral.HeaderText = "IdExamenLaboral";
            this.IdExamenLaboral.Name = "IdExamenLaboral";
            this.IdExamenLaboral.ReadOnly = true;
            this.IdExamenLaboral.Visible = false;
            this.IdExamenLaboral.Width = 114;
            // 
            // IdConsultorioLaboral
            // 
            this.IdConsultorioLaboral.HeaderText = "IdConsultorioLaboral";
            this.IdConsultorioLaboral.Name = "IdConsultorioLaboral";
            this.IdConsultorioLaboral.ReadOnly = true;
            this.IdConsultorioLaboral.Visible = false;
            this.IdConsultorioLaboral.Width = 128;
            // 
            // ClinicoCargado
            // 
            this.ClinicoCargado.HeaderText = "ClinicoCargado";
            this.ClinicoCargado.Name = "ClinicoCargado";
            this.ClinicoCargado.ReadOnly = true;
            this.ClinicoCargado.Visible = false;
            this.ClinicoCargado.Width = 103;
            // 
            // IdTipoExamen
            // 
            this.IdTipoExamen.HeaderText = "IdTipoExamen";
            this.IdTipoExamen.Name = "IdTipoExamen";
            this.IdTipoExamen.ReadOnly = true;
            this.IdTipoExamen.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.botBuscar);
            this.panel2.Controls.Add(this.tpHasta);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tpDesde);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(169, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 135);
            this.panel2.TabIndex = 131;
            // 
            // botBuscar
            // 
            this.botBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.botBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botBuscar.Image")));
            this.botBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botBuscar.Location = new System.Drawing.Point(4, 97);
            this.botBuscar.Name = "botBuscar";
            this.botBuscar.Size = new System.Drawing.Size(110, 33);
            this.botBuscar.TabIndex = 276;
            this.botBuscar.Text = "Buscar";
            this.botBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botBuscar.UseVisualStyleBackColor = false;
            this.botBuscar.Click += new System.EventHandler(this.botBuscar_Click);
            // 
            // tpHasta
            // 
            this.tpHasta.CalendarMonthBackground = System.Drawing.Color.White;
            this.tpHasta.CalendarTitleBackColor = System.Drawing.Color.MediumBlue;
            this.tpHasta.CalendarTitleForeColor = System.Drawing.Color.White;
            this.tpHasta.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.tpHasta.CustomFormat = "yyyy";
            this.tpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpHasta.Location = new System.Drawing.Point(4, 65);
            this.tpHasta.Name = "tpHasta";
            this.tpHasta.Size = new System.Drawing.Size(110, 26);
            this.tpHasta.TabIndex = 275;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 274;
            this.label5.Text = "Hasta";
            // 
            // tpDesde
            // 
            this.tpDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.tpDesde.CalendarTitleBackColor = System.Drawing.Color.MediumBlue;
            this.tpDesde.CalendarTitleForeColor = System.Drawing.Color.White;
            this.tpDesde.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.tpDesde.CustomFormat = "yyyy";
            this.tpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpDesde.Location = new System.Drawing.Point(4, 21);
            this.tpDesde.Name = "tpDesde";
            this.tpDesde.Size = new System.Drawing.Size(110, 26);
            this.tpDesde.TabIndex = 273;
            this.tpDesde.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 272;
            this.label4.Text = "Desde";
            // 
            // botCO
            // 
            this.botCO.Appearance = System.Windows.Forms.Appearance.Button;
            this.botCO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.botCO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCO.Location = new System.Drawing.Point(304, 48);
            this.botCO.Name = "botCO";
            this.botCO.Size = new System.Drawing.Size(114, 43);
            this.botCO.TabIndex = 278;
            this.botCO.Text = "Consultorios";
            this.botCO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botCO.UseVisualStyleBackColor = true;
            this.botCO.CheckedChanged += new System.EventHandler(this.botCO_CheckedChanged);
            // 
            // botL
            // 
            this.botL.Appearance = System.Windows.Forms.Appearance.Button;
            this.botL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.botL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botL.Location = new System.Drawing.Point(304, 2);
            this.botL.Name = "botL";
            this.botL.Size = new System.Drawing.Size(114, 43);
            this.botL.TabIndex = 279;
            this.botL.Text = "Ex. Aptitud";
            this.botL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botL.UseVisualStyleBackColor = true;
            this.botL.CheckedChanged += new System.EventHandler(this.botL_CheckedChanged);
            // 
            // botV
            // 
            this.botV.Appearance = System.Windows.Forms.Appearance.Button;
            this.botV.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.botV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botV.Location = new System.Drawing.Point(304, 94);
            this.botV.Name = "botV";
            this.botV.Size = new System.Drawing.Size(114, 43);
            this.botV.TabIndex = 280;
            this.botV.Text = "Domicilios";
            this.botV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botV.UseVisualStyleBackColor = true;
            this.botV.CheckedChanged += new System.EventHandler(this.botV_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.botImportar);
            this.panel3.Controls.Add(this.progressBar);
            this.panel3.Controls.Add(this.btnExportarOlivera);
            this.panel3.Controls.Add(this.btnExportarExamenes);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.botImportarCasino);
            this.panel3.Controls.Add(this.botCambiarEmpresa);
            this.panel3.Controls.Add(this.botMail);
            this.panel3.Controls.Add(this.botImprimirEx);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.botV);
            this.panel3.Controls.Add(this.botonRango);
            this.panel3.Controls.Add(this.botL);
            this.panel3.Controls.Add(this.botonFecha);
            this.panel3.Controls.Add(this.botCO);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1349, 142);
            this.panel3.TabIndex = 281;
            // 
            // botImportar
            // 
            this.botImportar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botImportar.Image = ((System.Drawing.Image)(resources.GetObject("botImportar.Image")));
            this.botImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImportar.Location = new System.Drawing.Point(682, 44);
            this.botImportar.Name = "botImportar";
            this.botImportar.Size = new System.Drawing.Size(169, 38);
            this.botImportar.TabIndex = 294;
            this.botImportar.Text = "Importar Labo.";
            this.botImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImportar.UseVisualStyleBackColor = false;
            this.botImportar.Click += new System.EventHandler(this.botImportar_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(682, 123);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(515, 16);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 293;
            // 
            // btnExportarOlivera
            // 
            this.btnExportarOlivera.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarOlivera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportarOlivera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarOlivera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarOlivera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExportarOlivera.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarOlivera.Image")));
            this.btnExportarOlivera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarOlivera.Location = new System.Drawing.Point(1028, 44);
            this.btnExportarOlivera.Name = "btnExportarOlivera";
            this.btnExportarOlivera.Size = new System.Drawing.Size(169, 38);
            this.btnExportarOlivera.TabIndex = 292;
            this.btnExportarOlivera.Text = "Exportar Olivera";
            this.btnExportarOlivera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarOlivera.UseVisualStyleBackColor = false;
            this.btnExportarOlivera.Click += new System.EventHandler(this.btnExportarOlivera_Click);
            // 
            // btnExportarExamenes
            // 
            this.btnExportarExamenes.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportarExamenes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportarExamenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExamenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExamenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExportarExamenes.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExamenes.Image")));
            this.btnExportarExamenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExamenes.Location = new System.Drawing.Point(855, 44);
            this.btnExportarExamenes.Name = "btnExportarExamenes";
            this.btnExportarExamenes.Size = new System.Drawing.Size(169, 38);
            this.btnExportarExamenes.TabIndex = 291;
            this.btnExportarExamenes.Text = "Exportar Examenes";
            this.btnExportarExamenes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarExamenes.UseVisualStyleBackColor = false;
            this.btnExportarExamenes.Click += new System.EventHandler(this.btnExportarExamenes_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.botLimpiar);
            this.panel4.Controls.Add(this.tbBusqueda);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.botFiltrar);
            this.panel4.Location = new System.Drawing.Point(432, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 135);
            this.panel4.TabIndex = 285;
            // 
            // botLimpiar
            // 
            this.botLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("botLimpiar.Image")));
            this.botLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botLimpiar.Location = new System.Drawing.Point(135, 74);
            this.botLimpiar.Name = "botLimpiar";
            this.botLimpiar.Size = new System.Drawing.Size(97, 26);
            this.botLimpiar.TabIndex = 282;
            this.botLimpiar.Text = "Limpiar";
            this.botLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botLimpiar.Click += new System.EventHandler(this.botLimpiar_Click);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusqueda.Location = new System.Drawing.Point(4, 50);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(228, 22);
            this.tbBusqueda.TabIndex = 279;
            this.tbBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBusqueda_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 278;
            this.label1.Text = "Busqueda DNI Paciente";
            // 
            // botFiltrar
            // 
            this.botFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("botFiltrar.Image")));
            this.botFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFiltrar.Location = new System.Drawing.Point(4, 74);
            this.botFiltrar.Name = "botFiltrar";
            this.botFiltrar.Size = new System.Drawing.Size(125, 26);
            this.botFiltrar.TabIndex = 277;
            this.botFiltrar.Text = "Filtrar";
            this.botFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botFiltrar.Click += new System.EventHandler(this.botFiltrar_Click);
            // 
            // botImportarCasino
            // 
            this.botImportarCasino.BackColor = System.Drawing.SystemColors.Control;
            this.botImportarCasino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botImportarCasino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImportarCasino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImportarCasino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botImportarCasino.Image = ((System.Drawing.Image)(resources.GetObject("botImportarCasino.Image")));
            this.botImportarCasino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImportarCasino.Location = new System.Drawing.Point(682, 4);
            this.botImportarCasino.Name = "botImportarCasino";
            this.botImportarCasino.Size = new System.Drawing.Size(169, 38);
            this.botImportarCasino.TabIndex = 284;
            this.botImportarCasino.Text = "Importar Casino";
            this.botImportarCasino.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImportarCasino.UseVisualStyleBackColor = false;
            this.botImportarCasino.Click += new System.EventHandler(this.botImportarCasino_Click);
            // 
            // botCambiarEmpresa
            // 
            this.botCambiarEmpresa.BackColor = System.Drawing.SystemColors.Control;
            this.botCambiarEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botCambiarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCambiarEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCambiarEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botCambiarEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("botCambiarEmpresa.Image")));
            this.botCambiarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCambiarEmpresa.Location = new System.Drawing.Point(855, 4);
            this.botCambiarEmpresa.Name = "botCambiarEmpresa";
            this.botCambiarEmpresa.Size = new System.Drawing.Size(169, 38);
            this.botCambiarEmpresa.TabIndex = 283;
            this.botCambiarEmpresa.Text = "Cambiar Empresa";
            this.botCambiarEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCambiarEmpresa.UseVisualStyleBackColor = false;
            this.botCambiarEmpresa.Click += new System.EventHandler(this.botCambiarEmpresa_Click);
            // 
            // botMail
            // 
            this.botMail.BackColor = System.Drawing.SystemColors.Control;
            this.botMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botMail.Image = ((System.Drawing.Image)(resources.GetObject("botMail.Image")));
            this.botMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botMail.Location = new System.Drawing.Point(1028, 4);
            this.botMail.Name = "botMail";
            this.botMail.Size = new System.Drawing.Size(169, 38);
            this.botMail.TabIndex = 282;
            this.botMail.Text = "Mail";
            this.botMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botMail.UseVisualStyleBackColor = false;
            this.botMail.Click += new System.EventHandler(this.botMail_Click);
            // 
            // botImprimirEx
            // 
            this.botImprimirEx.BackColor = System.Drawing.SystemColors.Control;
            this.botImprimirEx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botImprimirEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImprimirEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImprimirEx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botImprimirEx.Image = ((System.Drawing.Image)(resources.GetObject("botImprimirEx.Image")));
            this.botImprimirEx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImprimirEx.Location = new System.Drawing.Point(682, 84);
            this.botImprimirEx.Name = "botImprimirEx";
            this.botImprimirEx.Size = new System.Drawing.Size(169, 38);
            this.botImprimirEx.TabIndex = 281;
            this.botImprimirEx.Text = "Imprimir";
            this.botImprimirEx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImprimirEx.UseVisualStyleBackColor = false;
            this.botImprimirEx.Visible = false;
            this.botImprimirEx.Click += new System.EventHandler(this.botImprimirEx_Click);
            // 
            // botonRango
            // 
            this.botonRango.BackColor = System.Drawing.Color.Transparent;
            this.botonRango.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonRango.BackgroundImage")));
            this.botonRango.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRango.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.botonRango.Location = new System.Drawing.Point(129, 26);
            this.botonRango.Name = "botonRango";
            this.botonRango.Size = new System.Drawing.Size(34, 33);
            this.botonRango.TabIndex = 129;
            this.botonRango.UseVisualStyleBackColor = false;
            this.botonRango.Click += new System.EventHandler(this.botonRango_Click);
            // 
            // botonFecha
            // 
            this.botonFecha.BackColor = System.Drawing.Color.Transparent;
            this.botonFecha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonFecha.BackgroundImage")));
            this.botonFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonFecha.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.botonFecha.Location = new System.Drawing.Point(129, 60);
            this.botonFecha.Name = "botonFecha";
            this.botonFecha.Size = new System.Drawing.Size(34, 33);
            this.botonFecha.TabIndex = 130;
            this.botonFecha.UseVisualStyleBackColor = false;
            this.botonFecha.Click += new System.EventHandler(this.botonFecha_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Diagnostico";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 69;
            // 
            // frmBusquedaLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 496);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBusquedaLaboral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Laboral";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker tpFecha;
        private System.Windows.Forms.Button botonFecha;
        private System.Windows.Forms.Button botonRango;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button botBuscar;
        private System.Windows.Forms.DateTimePicker tpHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker tpDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox botCO;
        private System.Windows.Forms.CheckBox botL;
        private System.Windows.Forms.CheckBox botV;
        public System.Windows.Forms.Button botBuscarPorDia;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Button botMail;
        protected System.Windows.Forms.Button botImprimirEx;
        protected System.Windows.Forms.Button botCambiarEmpresa;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        protected System.Windows.Forms.Button botImportarCasino;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button botFiltrar;
        public System.Windows.Forms.Button botLimpiar;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identif;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConsultaLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoConsultaLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoAtencion;
        private System.Windows.Forms.DataGridViewImageColumn Diagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAltaCitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dictamen;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdExamenLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConsultorioLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClinicoCargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoExamen;
        protected System.Windows.Forms.Button btnExportarExamenes;
        protected System.Windows.Forms.Button btnExportarOlivera;
        private System.Windows.Forms.ProgressBar progressBar;
        protected System.Windows.Forms.Button botImportar;
    }
}