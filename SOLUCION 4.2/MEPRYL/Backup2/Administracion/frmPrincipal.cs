using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaPresentacionBase;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmPrincipal : CapaPresentacionBase.frmBasePrincipal
    {
        public frmPrincipal()
        {
            InitializeComponent();

        }

        [STAThread]
        static void Main()
        {
            try
            {
                try
                {
                    Application.Run(new frmPrincipal());
                }
                catch (System.ObjectDisposedException ex)
                {
                    //
                }
            }
            catch (System.NullReferenceException ex)
            {
                //
            }
        }


        public  void mostrarExamenes()
        {
            Form formExamen = new CapaPresentacion.frmBusquedaExamen();
            Utilidades.abrirFormulario(this, formExamen, this.configuracion);
        }

        private void abrirTurnos()
        {
            //frmTurno fTurno = new frmTurno(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA);
            //Utilidades.abrirFormulario(this, fTurno, this.configuracion);
            //fTurno.cbEspecialidadB.Focus();
            frmTurnos fTurnos = new frmTurnos();
            Utilidades.abrirFormulario(this, fTurnos, this.configuracion);

        }

        protected override void abrirFormularioInicial()
        {
            base.abrirFormularioInicial();

            //Oculta los botones si no es administrador
            //if (!this.configuracion.usuario.contienePerfil("Administrador"))
      
        }


        private void cargarBotonesAToolbar(ToolBar barra, ToolBarButton boton, string texto)
        {
            boton = new System.Windows.Forms.ToolBarButton();
            boton.Name = boton.ToString();
            boton.Text = boton.ToString();
            barra.Buttons.Add(boton);

        }

        private void botonExamenes_Click(object sender, EventArgs e)
        {

            mostrarExamenes();
        }

        private void botonNotificaciones_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmNotificacionesSMS(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA), this.configuracion);
        }


        private void botonAsignarTurnos_Click(object sender, EventArgs e)
        {
            abrirTurnos();
        }

        private void botonAgenda_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmAgendaTurno(), this.configuracion);
        }


        private void botonReporte_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmReporteTurnosAsignados(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA), this.configuracion);
        }

        private void botonLigas_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this, new frmLiga(this.configuracion), this.configuracion);
            Utilidades.abrirFormulario(this, new frmLigaMantenimiento(), this.configuracion);
        }

        private void botonClubes_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this, new frmClub(this.configuracion), this.configuracion);
            Utilidades.abrirFormulario(this, new frmClubMantenimiento(), this.configuracion);
        }

        private void botonEspecialidades_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this, new frmEspecialidad(this.configuracion), this.configuracion);
            Utilidades.abrirFormulario(this, new frmConfigTipoExamen(), this.configuracion);

        }

        private void botonProfesionales_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmBusquedaProfesionales(), this.configuracion);
        }


        private void botonHorarios_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmHorario(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA), this.configuracion);
        }

        private void botonRayosX_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this, new frmParametrosPlacas(this.configuracion), this.configuracion);
            Utilidades.abrirFormulario(this, new frmConfiguracionExamenRX2(), this.configuracion);
        }

        private void botonMesaDeEntrada_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmMesaDeEntrada(), this.configuracion);
        }

        private void botonEmpresas_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmBusquedaEmpresa(), this.configuracion);
        }


        private void botonHistorico_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmHistoricoMesaEntrada(), this.configuracion);
        }

        private void botonValidaciones_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmValidacionesExamen(), this.configuracion);
        }

        private void botonReportes_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigReportes(), this.configuracion);
        }

        private void botValidacionesAutomaticas_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigDictamenAutomatico(), this.configuracion);
        }

        private void botPacientes_Click(object sender, EventArgs e)
        {
              if (base.modo == "P")
              {
                  Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion), this.configuracion);
              }
              else
              {
                  Utilidades.abrirFormulario(this, new frmPacienteLaboral(), this.configuracion);
              }
        }

        private void botonVentanilla_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmRecepcion(), this.configuracion);
        }

        private void botUtilidadesPagina_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmUtilidadesPaginaWeb(), this.configuracion);
        }

        private void botUtilidadesDataSMS_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmUtilidadesDataSMS(), this.configuracion);
        }

        private void botControl_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmExportacionCompleta(), this.configuracion);
        }

        private void botLaboral_Click(object sender, EventArgs e)
        {
            frmBusquedaLaboral frm = new frmBusquedaLaboral();
            Utilidades.abrirFormulario(this, frm, this.configuracion);
        }

        private void botCondicionesLaborales_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmCondicionesLaborales(), this.configuracion);
        }

        private void botVisitasDomicilio_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmVisitasADomicilio(), this.configuracion);
        }

        private void botLocalidadesYPrestaciones_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmABMPrestaciones(), this.configuracion);
        }

        private void botZonas_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmABMZonas(), this.configuracion);
        }

        private void botNacionalidades_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmABMNacionalidades(), this.configuracion);
        }

        private void botUbicacionFotos_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigUbicacionFotos(), this.configuracion);            
        }

        private void botExportaMesaEntrada_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmExportarMesaEntrada(), this.configuracion);
        }

        private void botConsolidaciónInformes_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigConsolidacion(), this.configuracion);
        }

        private void botConsolidarEstudios_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmExportarConsolidado(), this.configuracion);
        }












    }
}

