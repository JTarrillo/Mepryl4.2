namespace CapaPresentacionBase
{
    partial class frmBasePrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBasePrincipal));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.botInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.botConfigGral = new System.Windows.Forms.ToolStripMenuItem();
            this.botonEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.botonLigas = new System.Windows.Forms.ToolStripMenuItem();
            this.botonClubes = new System.Windows.Forms.ToolStripMenuItem();
            this.botonEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.botonProfesionales = new System.Windows.Forms.ToolStripMenuItem();
            this.botonHorarios = new System.Windows.Forms.ToolStripMenuItem();
            this.botonRayosX = new System.Windows.Forms.ToolStripMenuItem();
            this.botonValidaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.botonReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.botValidacionesAutomaticas = new System.Windows.Forms.ToolStripMenuItem();
            this.botCondicionesLaborales = new System.Windows.Forms.ToolStripMenuItem();
            this.botLocalidadesYPrestaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.botZonas = new System.Windows.Forms.ToolStripMenuItem();
            this.botNacionalidades = new System.Windows.Forms.ToolStripMenuItem();
            this.botUbicacionFotos = new System.Windows.Forms.ToolStripMenuItem();
            this.botConsolidaciónInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.botPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.botTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.botonAsignarTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.botonAgenda = new System.Windows.Forms.ToolStripMenuItem();
            this.botonVentanilla = new System.Windows.Forms.ToolStripMenuItem();
            this.botMesaEntrada = new System.Windows.Forms.ToolStripMenuItem();
            this.botonMesaDeEntrada = new System.Windows.Forms.ToolStripMenuItem();
            this.botonHistorico = new System.Windows.Forms.ToolStripMenuItem();
            this.botonExamenes = new System.Windows.Forms.ToolStripMenuItem();
            this.botLaboral = new System.Windows.Forms.ToolStripMenuItem();
            this.botVisitasDomicilio = new System.Windows.Forms.ToolStripMenuItem();
            this.botExportPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.botUtilidadesPagina = new System.Windows.Forms.ToolStripMenuItem();
            this.botUtilidadesDataSMS = new System.Windows.Forms.ToolStripMenuItem();
            this.botControl = new System.Windows.Forms.ToolStripMenuItem();
            this.botExportaMesaEntrada = new System.Windows.Forms.ToolStripMenuItem();
            this.botonNotificaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.botConsolidarEstudios = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Menu
            // 
            this.Menu.AutoSize = false;
            this.Menu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botInicio,
            this.botConfigGral,
            this.botPacientes,
            this.botTurnos,
            this.botonVentanilla,
            this.botMesaEntrada,
            this.botonExamenes,
            this.botLaboral,
            this.botVisitasDomicilio,
            this.botExportPrev,
            this.botonNotificaciones});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1356, 40);
            this.Menu.TabIndex = 17;
            this.Menu.Text = "menuStrip1";
            // 
            // botInicio
            // 
            this.botInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botInicio.Image = ((System.Drawing.Image)(resources.GetObject("botInicio.Image")));
            this.botInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botInicio.Name = "botInicio";
            this.botInicio.Size = new System.Drawing.Size(86, 36);
            this.botInicio.Text = "Inicio";
            this.botInicio.Click += new System.EventHandler(this.botInicio_Click);
            // 
            // botConfigGral
            // 
            this.botConfigGral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonEmpresas,
            this.botonLigas,
            this.botonClubes,
            this.botonEspecialidades,
            this.botonProfesionales,
            this.botonHorarios,
            this.botonRayosX,
            this.botonValidaciones,
            this.botonReportes,
            this.botValidacionesAutomaticas,
            this.botCondicionesLaborales,
            this.botLocalidadesYPrestaciones,
            this.botZonas,
            this.botNacionalidades,
            this.botUbicacionFotos,
            this.botConsolidaciónInformes});
            this.botConfigGral.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botConfigGral.Image = ((System.Drawing.Image)(resources.GetObject("botConfigGral.Image")));
            this.botConfigGral.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botConfigGral.Name = "botConfigGral";
            this.botConfigGral.Size = new System.Drawing.Size(180, 36);
            this.botConfigGral.Text = "Configuración Gral.";
            // 
            // botonEmpresas
            // 
            this.botonEmpresas.Name = "botonEmpresas";
            this.botonEmpresas.Size = new System.Drawing.Size(257, 22);
            this.botonEmpresas.Text = "Empresas";
            this.botonEmpresas.Visible = false;
            // 
            // botonLigas
            // 
            this.botonLigas.Name = "botonLigas";
            this.botonLigas.Size = new System.Drawing.Size(257, 22);
            this.botonLigas.Text = "Ligas";
            // 
            // botonClubes
            // 
            this.botonClubes.Name = "botonClubes";
            this.botonClubes.Size = new System.Drawing.Size(257, 22);
            this.botonClubes.Text = "Clubes";
            // 
            // botonEspecialidades
            // 
            this.botonEspecialidades.Name = "botonEspecialidades";
            this.botonEspecialidades.Size = new System.Drawing.Size(257, 22);
            this.botonEspecialidades.Text = "Tipos de Examen";
            // 
            // botonProfesionales
            // 
            this.botonProfesionales.Name = "botonProfesionales";
            this.botonProfesionales.Size = new System.Drawing.Size(257, 22);
            this.botonProfesionales.Text = "Staff Médico";
            // 
            // botonHorarios
            // 
            this.botonHorarios.Name = "botonHorarios";
            this.botonHorarios.Size = new System.Drawing.Size(257, 22);
            this.botonHorarios.Text = "Horarios";
            // 
            // botonRayosX
            // 
            this.botonRayosX.Name = "botonRayosX";
            this.botonRayosX.Size = new System.Drawing.Size(257, 22);
            this.botonRayosX.Text = "Rayos X";
            // 
            // botonValidaciones
            // 
            this.botonValidaciones.Name = "botonValidaciones";
            this.botonValidaciones.Size = new System.Drawing.Size(257, 22);
            this.botonValidaciones.Text = "Validaciones";
            // 
            // botonReportes
            // 
            this.botonReportes.Name = "botonReportes";
            this.botonReportes.Size = new System.Drawing.Size(257, 22);
            this.botonReportes.Text = "Reportes";
            // 
            // botValidacionesAutomaticas
            // 
            this.botValidacionesAutomaticas.Name = "botValidacionesAutomaticas";
            this.botValidacionesAutomaticas.Size = new System.Drawing.Size(257, 22);
            this.botValidacionesAutomaticas.Text = "Validaciones Automáticas";
            // 
            // botCondicionesLaborales
            // 
            this.botCondicionesLaborales.Name = "botCondicionesLaborales";
            this.botCondicionesLaborales.Size = new System.Drawing.Size(257, 22);
            this.botCondicionesLaborales.Text = "Condiciones Laborales";
            this.botCondicionesLaborales.Visible = false;
            // 
            // botLocalidadesYPrestaciones
            // 
            this.botLocalidadesYPrestaciones.Name = "botLocalidadesYPrestaciones";
            this.botLocalidadesYPrestaciones.Size = new System.Drawing.Size(257, 22);
            this.botLocalidadesYPrestaciones.Text = "Localidades y Prestaciones";
            // 
            // botZonas
            // 
            this.botZonas.Name = "botZonas";
            this.botZonas.Size = new System.Drawing.Size(257, 22);
            this.botZonas.Text = "Zonas Geográficas";
            // 
            // botNacionalidades
            // 
            this.botNacionalidades.Name = "botNacionalidades";
            this.botNacionalidades.Size = new System.Drawing.Size(257, 22);
            this.botNacionalidades.Text = "Nacionalidades";
            // 
            // botUbicacionFotos
            // 
            this.botUbicacionFotos.Name = "botUbicacionFotos";
            this.botUbicacionFotos.Size = new System.Drawing.Size(257, 22);
            this.botUbicacionFotos.Text = "Ubicación de fotos";
            // 
            // botConsolidaciónInformes
            // 
            this.botConsolidaciónInformes.Name = "botConsolidaciónInformes";
            this.botConsolidaciónInformes.Size = new System.Drawing.Size(257, 22);
            this.botConsolidaciónInformes.Text = "Consolidación de Informes";
            // 
            // botPacientes
            // 
            this.botPacientes.Image = ((System.Drawing.Image)(resources.GetObject("botPacientes.Image")));
            this.botPacientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botPacientes.Name = "botPacientes";
            this.botPacientes.Size = new System.Drawing.Size(119, 36);
            this.botPacientes.Text = "Pacientes";
            // 
            // botTurnos
            // 
            this.botTurnos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonAsignarTurnos,
            this.botonAgenda});
            this.botTurnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botTurnos.Image = ((System.Drawing.Image)(resources.GetObject("botTurnos.Image")));
            this.botTurnos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botTurnos.Name = "botTurnos";
            this.botTurnos.Size = new System.Drawing.Size(99, 36);
            this.botTurnos.Text = "Turnos";
            // 
            // botonAsignarTurnos
            // 
            this.botonAsignarTurnos.Image = ((System.Drawing.Image)(resources.GetObject("botonAsignarTurnos.Image")));
            this.botonAsignarTurnos.Name = "botonAsignarTurnos";
            this.botonAsignarTurnos.Size = new System.Drawing.Size(176, 22);
            this.botonAsignarTurnos.Text = "Asignar Turnos";
            // 
            // botonAgenda
            // 
            this.botonAgenda.Image = ((System.Drawing.Image)(resources.GetObject("botonAgenda.Image")));
            this.botonAgenda.Name = "botonAgenda";
            this.botonAgenda.Size = new System.Drawing.Size(176, 22);
            this.botonAgenda.Text = "Agenda";
            // 
            // botonVentanilla
            // 
            this.botonVentanilla.Image = ((System.Drawing.Image)(resources.GetObject("botonVentanilla.Image")));
            this.botonVentanilla.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botonVentanilla.Name = "botonVentanilla";
            this.botonVentanilla.Size = new System.Drawing.Size(123, 36);
            this.botonVentanilla.Text = "Ventanilla";
            // 
            // botMesaEntrada
            // 
            this.botMesaEntrada.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonMesaDeEntrada,
            this.botonHistorico});
            this.botMesaEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botMesaEntrada.Image = ((System.Drawing.Image)(resources.GetObject("botMesaEntrada.Image")));
            this.botMesaEntrada.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botMesaEntrada.Name = "botMesaEntrada";
            this.botMesaEntrada.Size = new System.Drawing.Size(172, 36);
            this.botMesaEntrada.Text = "Mesa de Entradas";
            // 
            // botonMesaDeEntrada
            // 
            this.botonMesaDeEntrada.Image = ((System.Drawing.Image)(resources.GetObject("botonMesaDeEntrada.Image")));
            this.botonMesaDeEntrada.Name = "botonMesaDeEntrada";
            this.botonMesaDeEntrada.Size = new System.Drawing.Size(196, 22);
            this.botonMesaDeEntrada.Text = "Mesa de Entradas";
            // 
            // botonHistorico
            // 
            this.botonHistorico.Image = ((System.Drawing.Image)(resources.GetObject("botonHistorico.Image")));
            this.botonHistorico.Name = "botonHistorico";
            this.botonHistorico.Size = new System.Drawing.Size(196, 22);
            this.botonHistorico.Text = "Histórico";
            // 
            // botonExamenes
            // 
            this.botonExamenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonExamenes.Image = ((System.Drawing.Image)(resources.GetObject("botonExamenes.Image")));
            this.botonExamenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botonExamenes.Name = "botonExamenes";
            this.botonExamenes.Size = new System.Drawing.Size(122, 36);
            this.botonExamenes.Text = "Exámenes";
            // 
            // botLaboral
            // 
            this.botLaboral.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLaboral.Image = ((System.Drawing.Image)(resources.GetObject("botLaboral.Image")));
            this.botLaboral.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botLaboral.Name = "botLaboral";
            this.botLaboral.Size = new System.Drawing.Size(155, 36);
            this.botLaboral.Text = "Carga/Consulta";
            // 
            // botVisitasDomicilio
            // 
            this.botVisitasDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botVisitasDomicilio.Image = ((System.Drawing.Image)(resources.GetObject("botVisitasDomicilio.Image")));
            this.botVisitasDomicilio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botVisitasDomicilio.Name = "botVisitasDomicilio";
            this.botVisitasDomicilio.Size = new System.Drawing.Size(161, 36);
            this.botVisitasDomicilio.Text = "Visitas Domicilio";
            // 
            // botExportPrev
            // 
            this.botExportPrev.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botUtilidadesPagina,
            this.botUtilidadesDataSMS,
            this.botControl,
            this.botExportaMesaEntrada,
            this.toolStripSeparator1,
            this.botConsolidarEstudios});
            this.botExportPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botExportPrev.Image = ((System.Drawing.Image)(resources.GetObject("botExportPrev.Image")));
            this.botExportPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botExportPrev.Name = "botExportPrev";
            this.botExportPrev.Size = new System.Drawing.Size(147, 36);
            this.botExportPrev.Text = "Exportaciones";
            // 
            // botUtilidadesPagina
            // 
            this.botUtilidadesPagina.Image = ((System.Drawing.Image)(resources.GetObject("botUtilidadesPagina.Image")));
            this.botUtilidadesPagina.Name = "botUtilidadesPagina";
            this.botUtilidadesPagina.Size = new System.Drawing.Size(271, 22);
            this.botUtilidadesPagina.Text = "Listados para la Pagina Web";
            // 
            // botUtilidadesDataSMS
            // 
            this.botUtilidadesDataSMS.Image = ((System.Drawing.Image)(resources.GetObject("botUtilidadesDataSMS.Image")));
            this.botUtilidadesDataSMS.Name = "botUtilidadesDataSMS";
            this.botUtilidadesDataSMS.Size = new System.Drawing.Size(271, 22);
            this.botUtilidadesDataSMS.Text = "Exportación para el DataSMS";
            // 
            // botControl
            // 
            this.botControl.Image = ((System.Drawing.Image)(resources.GetObject("botControl.Image")));
            this.botControl.Name = "botControl";
            this.botControl.Size = new System.Drawing.Size(271, 22);
            this.botControl.Text = "Exportaciones a Medida";
            // 
            // botExportaMesaEntrada
            // 
            this.botExportaMesaEntrada.Image = ((System.Drawing.Image)(resources.GetObject("botExportaMesaEntrada.Image")));
            this.botExportaMesaEntrada.Name = "botExportaMesaEntrada";
            this.botExportaMesaEntrada.Size = new System.Drawing.Size(271, 22);
            this.botExportaMesaEntrada.Text = "Exportar Mesa de Entrada";
            // 
            // botonNotificaciones
            // 
            this.botonNotificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonNotificaciones.Image = ((System.Drawing.Image)(resources.GetObject("botonNotificaciones.Image")));
            this.botonNotificaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botonNotificaciones.Name = "botonNotificaciones";
            this.botonNotificaciones.Size = new System.Drawing.Size(146, 36);
            this.botonNotificaciones.Text = "Notificaciones";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(268, 6);
            // 
            // botConsolidarEstudios
            // 
            this.botConsolidarEstudios.Image = ((System.Drawing.Image)(resources.GetObject("botConsolidarEstudios.Image")));
            this.botConsolidarEstudios.Name = "botConsolidarEstudios";
            this.botConsolidarEstudios.Size = new System.Drawing.Size(271, 22);
            this.botConsolidarEstudios.Text = "Consolidar Estudios";
            // 
            // frmBasePrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1356, 527);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Menu;
            this.Name = "frmBasePrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBasePrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBasePrincipal_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBasePrincipal_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBasePrincipal_FormClosing);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem botConfigGral;
        private System.Windows.Forms.ToolStripMenuItem botTurnos;
        private System.Windows.Forms.ToolStripMenuItem botMesaEntrada;
        public System.Windows.Forms.ToolStripMenuItem botonExamenes;
        public System.Windows.Forms.ToolStripMenuItem botonNotificaciones;
        public System.Windows.Forms.ToolStripMenuItem botonAsignarTurnos;
        public System.Windows.Forms.ToolStripMenuItem botonLigas;
        public System.Windows.Forms.ToolStripMenuItem botonClubes;
        public System.Windows.Forms.ToolStripMenuItem botonEspecialidades;
        public System.Windows.Forms.ToolStripMenuItem botonProfesionales;
        public System.Windows.Forms.ToolStripMenuItem botonHorarios;
        public System.Windows.Forms.ToolStripMenuItem botonRayosX;
        public System.Windows.Forms.ToolStripMenuItem botonMesaDeEntrada;
        public System.Windows.Forms.ToolStripMenuItem botonEmpresas;
        public System.Windows.Forms.ToolStripMenuItem botonHistorico;
        public System.Windows.Forms.ToolStripMenuItem botonValidaciones;
        public System.Windows.Forms.ToolStripMenuItem botonReportes;
        public System.Windows.Forms.ToolStripMenuItem botValidacionesAutomaticas;
        public System.Windows.Forms.ToolStripMenuItem botPacientes;
        public System.Windows.Forms.ToolStripMenuItem botonVentanilla;
        public System.Windows.Forms.ToolStripMenuItem botonAgenda;
        public System.Windows.Forms.ToolStripMenuItem botExportPrev;
        public System.Windows.Forms.ToolStripMenuItem botUtilidadesPagina;
        public System.Windows.Forms.ToolStripMenuItem botUtilidadesDataSMS;
        public System.Windows.Forms.ToolStripMenuItem botControl;
        public System.Windows.Forms.ToolStripMenuItem botLaboral;
        private System.Windows.Forms.ToolStripMenuItem botInicio;
        public System.Windows.Forms.ToolStripMenuItem botCondicionesLaborales;
        public System.Windows.Forms.ToolStripMenuItem botVisitasDomicilio;
        public System.Windows.Forms.ToolStripMenuItem botLocalidadesYPrestaciones;
        public System.Windows.Forms.ToolStripMenuItem botZonas;
        public System.Windows.Forms.ToolStripMenuItem botNacionalidades;
        public System.Windows.Forms.ToolStripMenuItem botUbicacionFotos;
        public System.Windows.Forms.ToolStripMenuItem botExportaMesaEntrada;
        public System.Windows.Forms.ToolStripMenuItem botConsolidaciónInformes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem botConsolidarEstudios;
    }
}