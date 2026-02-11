using CapaPresentacion;
using CapaPresentacionBase;
using Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

            try
            {
                try
                {
                    Application.EnableVisualStyles();
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


        public void mostrarExamenes()
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
            //Utilidades.abrirFormulario(this, new frmBusquedaProfesionales(), this.configuracion);
            Utilidades.abrirFormulario(this, new frmProfesionalesCopy(this), this.configuracion);
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

        private void botConsolidacionInformes_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigConsolidacion(), this.configuracion);
        }

        private void botConsolidarEstudios_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmExportarConsolidado(), this.configuracion);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //private void nbiTurnos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmTurnos(this), this.configuracion);
        //    OcultarPestanasRibbon();
        //}

        //private void nbiVentanilla_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmRecepcion(this), this.configuracion);
        //    OcultarPestanasRibbon();
        //}

        //private void nbiMesaEntrada_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmMesaDeEntrada(this), this.configuracion);
        //    OcultarPestanasRibbon();
        //}

        //private void nbiPacientes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion, this), this.configuracion);
        //    OcultarPestanasRibbon();
        //    HabilitarPestanas(1);
        //    //char strTipoPaciente;
        //    //frmTipoPacienteSeleccionar frm = new frmTipoPacienteSeleccionar();
        //    //frm.ShowDialog();
        //    //strTipoPaciente = frm.strTipo;

        //    //if (strTipoPaciente == 'P')
        //    //    Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion, this), this.configuracion);
        //    //if (strTipoPaciente == 'L')
        //    //    Utilidades.abrirFormulario(this, new frmPacienteLaboral(this), this.configuracion);
        //}

        //private void nbiExamenes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmBusquedaExamen(this), this.configuracion);
        //    OcultarPestanasRibbon();
        //    HabilitarPestanas(2);
        //    //char strTipoPaciente;
        //    //frmTipoPacienteSeleccionar frm = new frmTipoPacienteSeleccionar();
        //    //frm.ShowDialog();
        //    //strTipoPaciente = frm.strTipo;

        //    //if (strTipoPaciente == 'P')
        //    //{
        //    //    Utilidades.abrirFormulario(this, new frmBusquedaExamen(this), this.configuracion);                
        //    //}
        //    //if (strTipoPaciente == 'L')
        //    //    Utilidades.abrirFormulario(this, new frmBusquedaLaboral(this), this.configuracion);
        //}


        //private void bbiPreventiva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion, this), this.configuracion);
        //}

        //private void bbiLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmPacienteLaboral(this), this.configuracion);
        //}

        //private void bbiPreventivaExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmBusquedaExamen(this), this.configuracion);
        //}

        //private void bbiLaboralExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmBusquedaLaboral(this), this.configuracion);
        //}

        //private void bbiDirectorioReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmConfigReportes(this), this.configuracion);
        //}

        //private void bbiPlantillaReportes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //Utilidades.abrirFormulario(this, new frmConfigPlantillaReporte(this), this.configuracion);
        //}

        //private void bbiArchivoConsolidar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmConfigConsolidacion(this), this.configuracion);            
        //}



        //private void bbiTipoExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmConfigTipoExamen(this), this.configuracion);            
        //}

        //private void bbiEmpresas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmBusquedaEmpresa(this), this.configuracion);            
        //}

        //private void bbiCondicionLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmCondicionesLaborales(this), this.configuracion);            
        //}

        //private void bbiLigas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmLigaMantenimiento(this), this.configuracion);            
        //}

        //private void bbiClubes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmClubMantenimiento(this), this.configuracion);            
        //}

        //private void bbiConfigRayosX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmConfiguracionExamenRX2(this), this.configuracion);            
        //}

        //private void bbiConfigMedico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmBusquedaProfesionales(this), this.configuracion);
        //    OcultarOpcionesConfiguracion();
        //}

        //private void bbiConfigLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmBusquedaEmpresa(this), this.configuracion);
        //    OcultarOpcionesConfiguracion();
        //    HabilitarOpcionesConfiguracion(1);
        //}

        //private void bbiConfigPreventiva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmClubMantenimiento(this), this.configuracion);
        //    OcultarOpcionesConfiguracion();
        //    HabilitarOpcionesConfiguracion(2);
        //}

        //private void bbiConfigGeneral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmConfigReportes(this), this.configuracion);
        //    OcultarOpcionesConfiguracion();
        //    HabilitarOpcionesConfiguracion(3);
        //}

        //private void bbiUbicarFotos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmConfigUbicacionFotos(this), this.configuracion);            
        //}

        //private void bbiConfigHorarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmHorario(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA), this.configuracion);
        //}

        //private void bbiConfigUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{

        //}

        //protected override void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmHorario(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA), this.configuracion);
        //}

        #region ConfigGeneral                  

        protected override void bbiConfigMedico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Utilidades.abrirFormulario(this, new frmBusquedaProfesionales(this), this.configuracion);
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmHorario")
                {
                    frm.Dispose();
                    frm.Close();
                    break;
                }
            }
            Utilidades.abrirFormulario(this, new frmProfesionalesCopy(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigMedico.Down = true;
        }


  

        //protected override void bbiTipoExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Utilidades.abrirFormulario(this, new frmConfigTipoExamen(this), this.configuracion);
        //    LimpiarEstadoIcono();
        //    bbiTipoExamen.Down = true;
        //}

        protected override void bbiConfigUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmUsuariosSistema(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigUsuarios.Down = true;
        }

        protected override void bbiTransferenciaLegajos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTransferenciaDeLegajos frm = new frmTransferenciaDeLegajos();
            frm.ShowDialog();
        }

        protected override void bbiConfigHorarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmProfesionalesCopy")
                {
                    //frm.BringToFront();
                    //return;
                    frm.Dispose();
                    frm.Close();
                    break;
                }
            }

            Utilidades.abrirFormulario(this, new frmHorario(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigHorarios.Down = true;
        }

        protected override void bbiTipoUsuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmUsuarioSistemaTipo(this), this.configuracion);
        }

        protected override void bbiUbicacionArchivos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigUbicacionFotos(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiUbicacionArchivos.Down = true;
        }

        protected override void bbiListaPrecios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmListaDePrecios(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiListaPrecios.Down = true;
        }

        protected override void bbiConfigAuxiliar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmZonasNacionalidad(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigAuxiliar.Down = true;
        }

        protected override void bbiDelegados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new FrmAñadirEspecialidad(), this.configuracion);
            LimpiarEstadoIcono();
            bbiDelegados.Down = true;
        }

        protected override void bbiConsultaSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConsultasSQL(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConsultaSQL.Down = true;
        }


        protected override void rbcControlMenu_SelectedPageChanged(object sender, EventArgs e)
        {
            //sbyte intValor = 0;

            //intValor = ActivarPestanasConfiguracion(sender);

            //switch (intValor)
            //{
            //    case 1:
            //        configB�sicaDelSistemaToolStripMenuItem_Click(sender, e);
            //        break;
            //    case 2:
            //        configPreventivaToolStripMenuItem_Click(sender, e);

            //        break;
            //    case 3:
            //        configLaboralToolStripMenuItem_Click(sender, e);
            //        break;
            //}

            try
            {
                if (!blnPrimerInicio)
                {
                    string strPage = rbpPacientePre.Collection.Category.Collection.Ribbon.SelectedPage.Name;

                    foreach (Form frm in this.MdiChildren)
                    {
                        switch (frm.Name)
                        {
                            case "frmTurnos":
                                if (strPage == "rbpTurnos")
                                {
                                    minimizarRibbon(true);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmAgendaTurno":
                                if (strPage == "rbpAgendaTurnos")
                                {
                                    minimizarRibbon(true);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmMesaDeEntrada":
                                if (strPage == "rbpMesaEntradas")
                                {
                                    minimizarRibbon(true);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmHistoricoMesaEntrada":
                                if (strPage == "rbpHistoricoMesa")
                                {
                                    minimizarRibbon(true);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmBusquedaExamen":
                                if (strPage == "rbpExamenesPre")
                                {
                                    minimizarRibbon(false);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmBusquedaLaboral":
                                if (strPage == "rbpExamenesLab")
                                {
                                    minimizarRibbon(false);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmPaciente":
                                if (strPage == "rbpPacientePre")
                                {
                                    minimizarRibbon(false);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmPacienteLaboral":
                                if (strPage == "rbpPacienteLab")
                                {
                                    minimizarRibbon(false);
                                    frm.BringToFront();
                                    return;
                                }
                                break;
                            case "frmRecepcion":
                                minimizarRibbon(true);
                                break;
                            default:
                                frm.Dispose();
                                frm.Close();
                                break;
                        }

                        if (strPage == "rbpConfiguracionPreventiva")
                        {
                            frm.Dispose();
                            frm.Close();
                        }

                        if (strPage == "rbpConfiguracionLaboral")
                        {
                            frm.Dispose();
                            frm.Close();
                        }

                        if (strPage == "rbpConfiguracionGeneral")
                        {
                            frm.Dispose();
                            frm.Close();
                        }
                    }

                    //string strPage = rbpPacientePre.Collection.Category.Collection.Ribbon.SelectedPage.Name;
                    //strPage = rbcControlMenu.Pages.Category.Collection.Ribbon.SelectedPage.Name;

                    //rbcControlMenu.Pages.Category.Collection.Ribbon.SelectedPage.Name = "";

                    if (strPage == "rbpPacientePre")
                    {
                        minimizarRibbon(false);
                        Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion, this), this.configuracion);
                    }

                    if (strPage == "rbpPacienteLab")
                    {
                        minimizarRibbon(false);
                        Utilidades.abrirFormulario(this, new frmPacienteLaboral(this), this.configuracion);
                    }

                    if (strPage == "rbpExamenesPre")
                    {
                        Utilidades.abrirFormulario(this, new frmBusquedaExamen(this), this.configuracion);
                        minimizarRibbon(false);
                    }

                    if (strPage == "rbpExamenesLab")
                    {
                        Utilidades.abrirFormulario(this, new frmBusquedaLaboral(this), this.configuracion);
                        minimizarRibbon(false);
                    }

                    if (strPage == "rbpTurnos")
                    {
                        Utilidades.abrirFormulario(this, new frmTurnos(this), this.configuracion);
                        minimizarRibbon(true);
                    }

                    if (strPage == "rbpAgendaTurnos")
                    {
                        Utilidades.abrirFormulario(this, new frmAgendaTurno(this), this.configuracion);
                        minimizarRibbon(true);
                    }

                    if (strPage == "rbpMesaEntradas")
                    {
                        Utilidades.abrirFormulario(this, new frmMesaDeEntrada(this), this.configuracion);
                        minimizarRibbon(true);
                    }

                    if (strPage == "rbpHistoricoMesa")
                    {
                        Utilidades.abrirFormulario(this, new frmHistoricoMesaEntrada(), this.configuracion);
                        minimizarRibbon(true);
                    }

                    if (strPage == "rbpExpPreventiva")
                    {
                        Utilidades.abrirFormulario(this, new frmExportacionesPreventiva(this), this.configuracion);
                        minimizarRibbon(false);
                        ColorRibbonPreventiva();
                    }

                    if (strPage == "rbpExpLaboral")
                    {
                        Utilidades.abrirFormulario(this, new frmExportacionesLaboral(this), this.configuracion);
                        minimizarRibbon(false);
                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                //
            }
        }
        #endregion

        #region ConfiguracionPreventiva
        protected override void bbiLigas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmLigaMantenimiento(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiLigas.Down = true;
        }

        protected override void bbiClubes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmClubMantenimiento(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiClubes.Down = true;
        }

        protected override void bbiConfigRayosX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfiguracionExamenRX2(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigRayosX.Down = true;
        }

        protected override void bbiPlantillaReportes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigPlantillaReporte(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiPlantillaReportes.Down = true;
        }

        protected override void bbiUbicarFotos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigUbicacionFotos(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiUbicarFotos.Down = true;
        }

        protected override void bbiArchivoConsolidar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigConsolidacion(this, "P"), this.configuracion);
            LimpiarEstadoIcono();
            bbiArchivoConsolidar.Down = true;
        }

        protected override void bbiConfigMensajePre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigMensajesPreventiva(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigMensajePre.Down = true;
        }

        protected override void bbiValidaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfiguracionExamenRX2(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiValidaciones.Down = true;
        }
        #endregion

        #region ConfiguracionLaboral
        protected override void bbiLocalidadNacionalidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarEstadoIcono();
            bbiLocalidadNacionalidad.Down = true;
            Utilidades.abrirFormulario(this, new frmLocalidadNacionalidad(this), this.configuracion);
        }

        protected override void bbiConfiguracionesPrestaciones2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarEstadoIcono();
            bbiConfiguracionesPrestaciones2.Down = true;

            // Buscar si ya está abierto
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmLocalidadNacionalidad localidadNacionalidadForm)
                {
                    // Si la pestaña activa es 'Tipo de Examen Médico', limpiar y recargar todo
                    var tab = localidadNacionalidadForm.Controls.OfType<TabControl>().FirstOrDefault();
                    if (tab != null && tab.SelectedTab != null && tab.SelectedTab.Text == "Tipo de Examen Médico")
                    {
                        localidadNacionalidadForm.RefrescarTabTipoExamenMedicoCompleto();
                    }
                    else
                    {
                        localidadNacionalidadForm.RefrescarPantalla();
                    }
                    frm.BringToFront();
                    return;
                }
            }

            // Si no está abierto, lo abre
            Utilidades.abrirFormulario(this, new frmLocalidadNacionalidad(this), this.configuracion);
        }

        protected override void bbiEmpresas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmBusquedaEmpresa(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiEmpresas.Down = true;
        }

        protected override void bbiConfigMensajeLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigMensajesLaboral(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigMensajeLab.Down = true;
        }

        protected override void bbiPlantillaReporteLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigPlantillaReporteLaboral(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiPlantillaReporteLab.Down = true;
        }

        protected override void bbiUbicacionFotosLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigUbicacionFotosLaboral(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiUbicacionFotosLab.Down = true;
        }

        protected override void bbiArchivoConsolidarLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigConsolidacionLaboral(this, "L"), this.configuracion);
            LimpiarEstadoIcono();
            bbiArchivoConsolidarLab.Down = true;
        }

        protected override void bbiCondicionesLaborales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmCondicionesLaborales(), this.configuracion);
            LimpiarEstadoIcono();
            bbiCondicionesLaborales.Down = true;
        }

        protected override void bbiConfigurarIva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Utilidades.abrirFormulario(this, new frmConfiguracionImpuestos(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiConfigurarIva.Down = true;
        }

        #endregion



        #region MenuLateral
        protected override void nbiConfiguracion_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanasConfiguracion();
            ColorRibbonConfiguracion();
        }

        protected override void nbiPacientes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanaPacientePreventiva();
            CambiaNombrePestanaPrevetniva();
            ColorRibbonPreventiva();
            //MostrarPestanasPacientes();

        }

        protected override void nbiMesaEntrada_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();
            Utilidades.abrirFormulario(this, new frmMesaDeEntrada(this), this.configuracion);
        }

        protected override void nbiVentanilla_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();
            Utilidades.abrirFormulario(this, new frmRecepcion(this), this.configuracion);
        }

        protected override void nbiTurnos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();
            Utilidades.abrirFormulario(this, new frmTurnos(this), this.configuracion);
        }

        protected override void nbiAgenda_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonPreventiva();
            Utilidades.abrirFormulario(this, new frmAgendaMesaEntrada(this), this.configuracion);
        }

        protected override void nbiExamenes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanasExamenenPreventiva();
            CambiaNombrePestanaExamenPreventiva();
            ColorRibbonPreventiva();
        }
        #endregion

        #region Pacientes
        protected override void bbiPacientePreventiva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OcultarPestanasRibbon();
            //MostrarPestanasPacientes();
            MostrarPestanaPacientePreventiva();
            Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion, this), this.configuracion);
        }

        protected override void bbiPacienteLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OcultarPestanasRibbon();
            //MostrarPestanasPacientes();
            MostrarPestanaPacienteLaboral();
            Utilidades.abrirFormulario(this, new frmPacienteLaboral(this), this.configuracion);
        }
        #endregion

        #region examen
        protected override void bbiPreventivaExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanasExamenenPreventiva();
            Utilidades.abrirFormulario(this, new frmBusquedaExamen(this), this.configuracion);
            ColorRibbonPreventiva();
        }

        protected override void bbiLaboralExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanasExamenenLaboral();
            ColorRibbonLaboral();
            Utilidades.abrirFormulario(this, new frmBusquedaLaboral(this), this.configuracion);
        }

        protected override void preventivaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanaExamPreven();
            //Utilidades.abrirFormulario(this, new frmBusquedaExamen(this), this.configuracion);            
        }

        protected override void laboralToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanaExamLabora();
            //Utilidades.abrirFormulario(this, new frmBusquedaLaboral(this), this.configuracion);            
        }
        #endregion
        // ----------------------------------------
        // ----------------------------------------
        #region MenuPrevetiva
        protected override void preventivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanaPacientePreven();
            //Utilidades.abrirFormulario(this, new frmPaciente(this.configuracion, this), this.configuracion);
        }

        protected override void laboralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanaPacienteLabora();
            //Utilidades.abrirFormulario(this, new frmPacienteLaboral(this), this.configuracion);
        }
        #endregion

        // --------------------------------------------------
        // --------------------------------------------------
        #region ConfigurarSistema
        protected override void configBasicaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            //Utilidades.abrirFormulario(this, new frmUsuariosSistema(this), this.configuracion);            
            MostrarPestanaConfigBasica();
            LimpiarEstadoIcono();
            //bbiConfigUsuarios.Down = true;
        }

        protected override void configPreventivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            //Utilidades.abrirFormulario(this, new frmLigaMantenimiento(this), this.configuracion);
            MostrarPestanaConfigPreventiva();
            LimpiarEstadoIcono();
            //bbiLigas.Down = true;

        }

        protected override void configLaboralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            //Utilidades.abrirFormulario(this, new frmBusquedaEmpresa(this), this.configuracion);
            MostrarPestanaConfigLaboral();
            LimpiarEstadoIcono();
            //bbiEmpresas.Down = true;
        }
        #endregion
        // --------------------------------------------------
        // --------------------------------------------------
        #region MenuTurnos
        protected override void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();
            MostrarTurnosAgenda();
            //Utilidades.abrirFormulario(this, new frmAgendaTurno(this), this.configuracion);
        }

        protected override void turnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();
            MostrarTurnos();
            //Utilidades.abrirFormulario(this, new frmTurnos(this), this.configuracion);
        }
        #endregion

        #region Mesaentradas
        protected override void mesaDeEntradasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanasMesaEntradas();
            //Utilidades.abrirFormulario(this, new frmMesaDeEntrada(), this.configuracion);
        }

        protected override void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanasHistoricoMesaEntradas();
            //Utilidades.abrirFormulario(this, new frmHistoricoMesaEntrada(), this.configuracion);
        }
        #endregion

        #region planillaExportacionesVentanilla
        protected override void ventanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "frmRecepcion")
                {
                    frm.BringToFront();
                    return;
                }
            }

            Utilidades.abrirFormulario(this, new frmRecepcion(this), this.configuracion);
        }

        protected override void planillaDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonPreventiva();

            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }

            Utilidades.abrirFormulario(this, new frmAgendaMesaEntrada2(this), this.configuracion);
        }

        protected override void prevenExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            MostrarPestanaExportacionPreventiva();
            ColorRibbonPreventiva();
            //Utilidades.abrirFormulario(this, new frmExportacionesPreventiva(this), this.configuracion);
        }

        protected override void laboralExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();
            MostrarPestanaExportacionLaboral();
            //Utilidades.abrirFormulario(this, new frmExportacionesLaboral(this), this.configuracion);
        }

        protected override void informeAudiometriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarPestanasRibbon();
            ColorRibbonLaboral();

            //foreach (Form frm in Application.OpenForms)
            //{
            //    if ((frm.GetType() == typeof(frmAgendaMesaEntrada2)) || (frm.GetType() == typeof(frmMesaDeEntrada)))
            //    {
            //        frm.Dispose();
            //        frm.Close();
            //        break;
            //    }               
            //}

            //foreach (Form frm in Application.OpenForms)
            //{
            //    if ((frm.GetType() == typeof(frmAgendaMesaEntrada2)) || (frm.GetType() == typeof(frmMesaDeEntrada)))
            //    {
            //        frm.Dispose();
            //        frm.Close();
            //        break;
            //    }
            //}
            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }

            Utilidades.abrirFormulario(this, new frmReporteAudiometria2(this, true), this.configuracion);
        }
        #endregion

        protected override void bbiUbicaArchivoLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Utilidades.abrirFormulario(this, new frmConfigUbicacionFotosLaboral(this), this.configuracion);
            LimpiarEstadoIcono();
            bbiUbicacionArchivos.Down = true;
        }

        protected override void frmBasePrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


    }
}

