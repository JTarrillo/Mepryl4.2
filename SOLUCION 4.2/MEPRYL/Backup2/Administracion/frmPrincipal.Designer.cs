namespace CapaPresentacion
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1024, 483);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPrincipal";
            this.Text = "MEPRYL";
            this.ResumeLayout(false);
            this.PerformLayout();
           this.botonExamenes.Click += new System.EventHandler(this.botonExamenes_Click);
           this.botonNotificaciones.Click += new System.EventHandler(this.botonNotificaciones_Click);
           this.botonAsignarTurnos.Click += new System.EventHandler(this.botonAsignarTurnos_Click);
           this.botonAgenda.Click += new System.EventHandler(this.botonAgenda_Click);
           this.botonLigas.Click += new System.EventHandler(this.botonLigas_Click);
           this.botonClubes.Click += new System.EventHandler(this.botonClubes_Click);
           this.botonEspecialidades.Click += new System.EventHandler(this.botonEspecialidades_Click);
           this.botonProfesionales.Click += new System.EventHandler(this.botonProfesionales_Click);
           this.botonHorarios.Click += new System.EventHandler(this.botonHorarios_Click);
           this.botonRayosX.Click += new System.EventHandler(this.botonRayosX_Click);
           this.botonMesaDeEntrada.Click += new System.EventHandler(this.botonMesaDeEntrada_Click);
           this.botonEmpresas.Click += new System.EventHandler(this.botonEmpresas_Click);
           this.botonHistorico.Click += new System.EventHandler(this.botonHistorico_Click);
           this.botonValidaciones.Click += new System.EventHandler(this.botonValidaciones_Click);
           this.botonReportes.Click += new System.EventHandler(this.botonReportes_Click);
           this.botValidacionesAutomaticas.Click += new System.EventHandler(this.botValidacionesAutomaticas_Click);
           this.botPacientes.Click += new System.EventHandler(this.botPacientes_Click);
           this.botonVentanilla.Click += new System.EventHandler(this.botonVentanilla_Click);
           this.botUtilidadesPagina.Click += new System.EventHandler(this.botUtilidadesPagina_Click);
           this.botUtilidadesDataSMS.Click += new System.EventHandler(this.botUtilidadesDataSMS_Click);
           this.botControl.Click += new System.EventHandler(this.botControl_Click);
           this.botLaboral.Click += new System.EventHandler(this.botLaboral_Click);
           this.botCondicionesLaborales.Click += new System.EventHandler(this.botCondicionesLaborales_Click);
           this.botVisitasDomicilio.Click += new System.EventHandler(this.botVisitasDomicilio_Click);
           this.botLocalidadesYPrestaciones.Click += new System.EventHandler(this.botLocalidadesYPrestaciones_Click);
           this.botZonas.Click += new System.EventHandler(this.botZonas_Click);
           this.botNacionalidades.Click += new System.EventHandler(this.botNacionalidades_Click);
           this.botUbicacionFotos.Click += new System.EventHandler(this.botUbicacionFotos_Click);
           this.botExportaMesaEntrada.Click += new System.EventHandler(this.botExportaMesaEntrada_Click);
           this.botConsolidaciónInformes.Click += new System.EventHandler(this.botConsolidaciónInformes_Click);
           this.botConsolidarEstudios.Click += new System.EventHandler(this.botConsolidarEstudios_Click);
        }

        #endregion
   

       

    }
}
