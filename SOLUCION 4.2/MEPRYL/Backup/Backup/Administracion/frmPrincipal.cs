using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaPresentacion;
using Comunes;

namespace DataSMSTurnos
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
            Application.Run(new frmPrincipal());
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Text)
            {
                case "Ligas":
                    Utilidades.abrirFormulario(this, new frmLiga(this.configuracion), this.configuracion);
                    break;
                case "Pacientes":
                    Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion), this.configuracion);
                    break;
                case "Clubes":
                    Utilidades.abrirFormulario(this, new frmClub(this.configuracion), this.configuracion);
                    break;
                case "Especialidades":
                    Utilidades.abrirFormulario(this, new frmEspecialidad(this.configuracion), this.configuracion);
                    break;
                case "Profesionales":
                    Utilidades.abrirFormulario(this, new frmProfesional(this.configuracion), this.configuracion);
                    break;
                case "Horarios":
                    Utilidades.abrirFormulario(this, new frmHorario(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA), this.configuracion);
                    break;
                case "Turnos":
                    {
                        abrirTurnos();
                        break;
                    }
                case "Agenda":
                    Utilidades.abrirFormulario(this, new frmAgenda(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA), this.configuracion);
                    break;
                case "Reporte":
                    Utilidades.abrirFormulario(this, new frmReporteTurnosAsignados(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA), this.configuracion);
                    break;
                case "Notificaciones SMS":
                    Utilidades.abrirFormulario(this, new frmNotificacionesSMS(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA), this.configuracion);
                    break;
                case "Configuración":
                    Utilidades.abrirFormulario(this, new frmParametrosPlacas(this.configuracion), this.configuracion);
                    break;
            }
        }

        private void abrirTurnos()
        {
            frmTurno fTurno = new frmTurno(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA);
            Utilidades.abrirFormulario(this, fTurno, this.configuracion);
            fTurno.cbEspecialidadB.Focus();
        }

        protected override void abrirFormularioInicial()
        {
            base.abrirFormularioInicial();

            //Oculta los botones si no es administrador
            if (!this.configuracion.usuario.contienePerfil("Administrador"))
                toolBar1.Buttons["toolBarButton9"].Visible = false;

            abrirTurnos();
        }
    }
}

