using Comunes;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacionBase
{
    public partial class frmBasePrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Configuracion configuracion; // = new Configuracion();
        public bool login = true;
        public string modo = "";
        public string strTipoConfig = "";
        private string strNombreUsuario = "";
        private string strApellidoUsuario = "";
        public bool blnPrimerInicio = true;

        public frmBasePrincipal() : this(true)
        {
            this.IsMdiContainer = true; // GRV
        }

        public frmBasePrincipal(bool conectarBaseDatos)
        {
            this.configuracion = new Configuracion(conectarBaseDatos);
            InitializeComponent();
            this.IsMdiContainer = true;  // GRV
            this.login = conectarBaseDatos;
            AbrirLogin();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new frmBasePrincipal());
        }

        protected virtual void abrirFormularioInicial() { }

        private void ActualizarLabelVersionConUsuario(string apellido, string nombre)
        {
            try
            {
                //if (lblVersionInfo != null)
                //{
                //    lblVersionInfo.Text = $"MEPRYL ★ {VersionApp.VERSION} ★ PRUEBA - {apellido}, {nombre}";
                //}
            }
            catch { }
        }


        //Asegura que haya solo una instancia de cada formulario
        /*public Form abrirFormulario(Form frmAbrir)
        {
            try
            {
                //Contorla que se haya iniciado la caja
                this.Cursor = Cursors.WaitCursor;

                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.Name == frmAbrir.Name)
                    {
                        frmAbrir = frm;
                        break;
                    }
                }

                frmAbrir.MdiParent = this;
                frmAbrir.Show();
                frmAbrir.Focus();
                
                //UtilUI.cambiarColorFondo(this, configuracion);

                this.Cursor = Cursors.Arrow;

                return frmAbrir;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }*/

        public void frmBasePrincipal_Load(object sender, EventArgs e)
        {
            this.Text = $"MEPRYL {VersionApp.VERSION}  - {strApellidoUsuario}, {strNombreUsuario}";
            //try
            //{
            //    bool abrirFormulario = true;
            //    Menu.Visible = false;
            //    if (this.login)
            //    {
            //        //Crea el formulario de login
            //        frmLogin form = new frmLogin(this.configuracion);

            //        //Crea y asigna el Delegate
            //        form.objDelegateDevolverID = new Comunes.frmLogin.DelegateDevolverID(usuarioValidado);

            //        form.ShowDialog();

            //        if (form.DialogResult != DialogResult.OK)
            //        {
            //            abrirFormulario = false;
            //        }
            //    }

            //    if (abrirFormulario)
            //    {
            //        abrirFormularioMenu();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ManejadorErrores.escribirLog(ex, true, this.configuracion);
            //}
            MdiClient ctlMDI;

            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }


            //OcultarPestanasRibbon();

            //UserLookAndFeel.Default.SetSkinMaskColors(Color.FromArgb(255, 70, 130, 180), Color.White);
            //SkinManager.EnableMdiFormSkins();

            PermisosUsuario(Comunes.UsuarioDatos.UsuarioSistema);

            //this.menuStrip1.Items[0].MouseHover += new EventHandler(navBarControl1_MouseHover);
            Image img = CapaPresentacion.Properties.Resources.CentroMedicoMepryl;

            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        private void AbrirLogin()
        {
            try
            {
                bool abrirFormulario = true;
                Menu.Visible = false;
                if (this.login)
                {
                    //Crea el formulario de login
                    frmLogin form = new frmLogin(this.configuracion);

                    //Crea y asigna el Delegate
                    form.objDelegateDevolverID = new Comunes.frmLogin.DelegateDevolverID(usuarioValidado);

                    form.ShowDialog();

                    if (form.DialogResult != DialogResult.OK)
                    {
                        abrirFormulario = false;
                    }
                }

                if (abrirFormulario)
                {
                    //abrirFormularioMenu();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Define si el usuario fue validado o no
        private void usuarioValidado(Usuario usuario)
        {
            try
            {
                Configuracion.usuario = usuario;

                if (usuario == null)
                {
                    this.Close();
                }

                //Toma el nombre del usuario con versión de la aplicación
                this.Text = $"MEPRYL {VersionApp.VERSION} Prueba - {usuario.apellido}, {usuario.nombre}";
                ActualizarLabelVersionConUsuario(usuario.apellido, usuario.nombre);
                strNombreUsuario = usuario.nombre;
                strApellidoUsuario = usuario.apellido;

                if (strNombreUsuario == "Carlos")
                {
                    navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
                    //navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed; 
                }
                else
                {
                    navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
                }

                UsuarioGlobal.Usuario = usuario.username;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void frmBasePrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No && Configuracion.usuario != null)
            {
                e.Cancel = true;
            }
        }

        private void abrirFormularioMenu()
        {
            Menu.Visible = false;
            foreach (Form form in this.MdiChildren)
            {
                form.WindowState = FormWindowState.Minimized;
            }
            Menu.Visible = true;
            cargarConfiguracionBasica();
            frmInicio frm = new frmInicio(this);
            frm.Show();
            frm.MdiParent = this;
        }

        private void cargarConfiguracionBasica()
        {
            botConfigGral.Text = "Configuración Gral.";
            botonEmpresas.Visible = false;
            botonLigas.Visible = false;
            botonClubes.Visible = false;
            botonEspecialidades.Visible = false;
            botonProfesionales.Visible = true;
            botonHorarios.Visible = true;
            botonRayosX.Visible = false;
            botonValidaciones.Visible = false;
            botonReportes.Visible = true;
            botValidacionesAutomaticas.Visible = false;
            botPacientes.Visible = false;
            botTurnos.Visible = false;
            botonVentanilla.Visible = false;
            botMesaEntrada.Visible = false;
            botonExamenes.Visible = false;
            botLaboral.Visible = false;
            botExportPrev.Visible = false;
            botonNotificaciones.Visible = false;
            botCondicionesLaborales.Visible = false;
            botInicio.Visible = false;
            botVisitasDomicilio.Visible = false;
            botLocalidadesYPrestaciones.Visible = false;
            botZonas.Visible = false;
            botNacionalidades.Visible = false;
            botUbicacionFotos.Visible = true;
            botConsolidacionInformes.Visible = true;
        }

        public void mostrarPreventiva()
        {
            //cargarPreventiva();
            modo = "P";
            Menu.Visible = true;
        }

        public void mostrarLaboral()
        {
            //cargarLaboral();
            modo = "L";
            Menu.Visible = true;
        }

        private void botInicio_Click(object sender, EventArgs e)
        {
            //abrirFormularioMenu();
        }

        private void cargarPreventiva()
        {
            botConfigGral.Text = "Configuración";
            botInicio.Visible = true;
            botonEmpresas.Visible = false;
            botonLigas.Visible = true;
            botonClubes.Visible = true;
            botonEspecialidades.Visible = true;
            botonProfesionales.Visible = false;
            botonHorarios.Visible = false;
            botonRayosX.Visible = true;
            botonValidaciones.Visible = true;
            botonReportes.Visible = false;
            botValidacionesAutomaticas.Visible = true;
            botPacientes.Visible = true;
            botTurnos.Visible = true;
            botonVentanilla.Visible = true;
            botMesaEntrada.Visible = true;
            botonExamenes.Visible = true;
            botLaboral.Visible = false;
            botExportPrev.Visible = true;
            botonNotificaciones.Visible = true;
            botCondicionesLaborales.Visible = false;
            botVisitasDomicilio.Visible = false;
            botLocalidadesYPrestaciones.Visible = false;
            botZonas.Visible = false;
            botNacionalidades.Visible = false;
            botUbicacionFotos.Visible = false;
            botConsolidacionInformes.Visible = false;
        }

        private void cargarLaboral()
        {
            botConfigGral.Text = "Configuración";
            botInicio.Visible = true;
            botonEmpresas.Visible = true;
            botonLigas.Visible = false;
            botonClubes.Visible = false;
            botonEspecialidades.Visible = true;
            botonProfesionales.Visible = false;
            botonHorarios.Visible = false;
            botonRayosX.Visible = false;
            botonValidaciones.Visible = false;
            botonReportes.Visible = false;
            botValidacionesAutomaticas.Visible = false;
            botPacientes.Visible = true;
            botTurnos.Visible = true;
            botonVentanilla.Visible = true;
            botMesaEntrada.Visible = true;
            botonExamenes.Visible = false;
            botLaboral.Visible = true;
            botExportPrev.Visible = false;
            botonNotificaciones.Visible = false;
            botCondicionesLaborales.Visible = true;
            botVisitasDomicilio.Visible = false;
            botLocalidadesYPrestaciones.Visible = true;
            botZonas.Visible = true;
            botNacionalidades.Visible = true;
            botUbicacionFotos.Visible = false;
            botConsolidacionInformes.Visible = false;
        }

        private void frmBasePrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            SQLConnector.desconectarBaseDeDatos();
        }

        public void OcultarPestanasRibbon()
        {
            blnPrimerInicio = true;
            //
            rbpPacientePre.Visible = false;
            rbpPacienteLab.Visible = false;
            rbpExamenesPre.Visible = false;
            rbpExamenesLab.Visible = false;
            rbpConfiguracionGeneral.Visible = false;
            rbpConfiguracionLaboral.Visible = false;
            rbpConfiguracionPreventiva.Visible = false;
            rbpTurnos.Visible = false;
            rbpAgendaTurnos.Visible = false;
            rbpExpPreventiva.Visible = false;
            rbpExpLaboral.Visible = false;
            rbpMesaEntradas.Visible = false;
            rbpHistoricoMesa.Visible = false;
            //
            blnPrimerInicio = false;
        }

        public void HabilitarPestanas(byte intOrden)
        {
            /*
             * 1 = Pacientes
             * 2 = Examenes
             * 3 = Configuración
             */

            if (intOrden == 1)
                rbpPacientePre.Visible = true;
            if (intOrden == 2)
                rbpExamenesPre.Visible = true;
            if (intOrden == 3)
                rbpConfiguracionGeneral.Visible = true;
        }

        public void minimizarRibbon(bool blnEstado)
        {
            rbcControlMenu.Minimized = blnEstado;
        }

        public void MostrarPestanasConfiguracion()
        {
            rbpConfiguracionGeneral.Visible = true;
            rbpConfiguracionPreventiva.Visible = true;
            rbpConfiguracionLaboral.Visible = true;
        }

        public void MostrarPestanasPacientes()
        {
            rbpPacienteLab.Visible = true;
            rbpPacientePre.Visible = true;
        }

        public void MostrarPestanaPacientePreventiva()
        {
            //rbpPacientePre.Text = "Paciente Preventiva";
            //rbpPacienteLab.Visible = true; // false
            //rbpPacientePre.Visible = true; 
        }

        public void CambiaNombrePestanaPrevetniva()
        {
            rbpPacientePre.Text = "Pacientes";
        }

        public void MostrarPestanaPacienteLaboral()
        {
            //rbpPacienteLab.Visible = true; 
            //rbpPacientePre.Visible = true; // false
        }

        public void ActivarPestaaPaciente(byte intNro)
        {
            if (intNro == 1)
            {

            }
        }

        public void MostrarPestanasExamenenPreventiva()
        {
            rbpExamenesPre.Text = "Exámenes Preventiva";
            rbpExamenesPre.Visible = true;
            rbpExamenesLab.Visible = true; //false
        }

        public void CambiaNombrePestanaExamenPreventiva()
        {
            rbpExamenesPre.Text = "Exámenes";
        }

        public void MostrarPestanasExamenenLaboral()
        {
            rbpExamenesLab.Visible = true;
            rbpExamenesPre.Visible = true; //false            
        }

        public void MostrarTurnosAgenda()
        {
            rbpAgendaTurnos.Visible = true;
            rbpTurnos.Visible = true; //false 
        }

        public void MostrarTurnos()
        {
            rbpTurnos.Visible = true; //false
            rbpAgendaTurnos.Visible = true;
        }

        public void MostrarPestanasMesaEntradas()
        {
            rbpMesaEntradas.Visible = true;
            rbpHistoricoMesa.Visible = true;
        }

        public void MostrarPestanasHistoricoMesaEntradas()
        {
            rbpHistoricoMesa.Visible = true;
            rbpMesaEntradas.Visible = true;
        }

        public void MostrarPestanaExportacionPreventiva()
        {
            rbpExpPreventiva.Visible = true;
            rbpExpLaboral.Visible = true;
        }

        public void MostrarPestanaExportacionLaboral()
        {
            rbpExpLaboral.Visible = true;
            rbpExpPreventiva.Visible = true;
        }

        public void HabilitarOpcionesConfiguracion(byte intOrden)
        {
            /*
             * 1 = Laboral
             * 2 = Preventiva
             * 3 = General
             */
            //if (intOrden == 1)
            //    rpgConfiguracionLAB.Visible = true;
            //if(intOrden == 2)
            //    rpgConfiguracionPRE.Visible = true;
            //if(intOrden == 3)
            //    rpgConfiguracionGEN.Visible = true;
        }


        #region ConfiguracionGeneral

        protected virtual void bbiConfigMedico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarEstadoIcono();
            bbiConfigMedico.Down = true;
        }

        //protected virtual void bbiTipoExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{

        //}

        protected virtual void bbiConfigUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarEstadoIcono();
            bbiConfigUsuarios.Down = true;
        }

        protected virtual void bbiTransferenciaLegajos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConfigHorarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


      
      


        protected virtual void bbiTipoUsuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiUbicacionArchivos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void configBasicaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void configPreventivaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void configLaboralToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void rbcControlMenu_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        protected virtual void bbiListaPrecios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConsultaSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        #endregion

        #region ConfiguracionPreventiva
        protected virtual void bbiLigas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiClubes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConfigRayosX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        protected virtual void bbiPlantillaReportes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiUbicarFotos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiArchivoConsolidar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiDictamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConfigMensajePre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiValidaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiPacientePreventiva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiPacienteLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        #endregion

        #region  ConfiguracionLaboral

        protected virtual void bbiEmpresas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiLocalidadNacionalidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConfigMensajeLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiPlantillaReporteLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiUbicacionFotosLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiArchivoConsolidarLab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiCondicionesLaborales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConfiguracionesPrestaciones2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarEstadoIcono();
            bbiConfiguracionesPrestaciones2.Down = true;
        }
        #endregion

        #region MenuLateral
        protected virtual void nbiPacientes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        protected virtual void nbiConfiguracion_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        protected virtual void nbiMesaEntrada_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        protected virtual void nbiVentanilla_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        protected virtual void nbiTurnos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        protected virtual void nbiAgenda_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        protected virtual void nbiExamenes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
        #endregion

        #region Pacientes        
        protected virtual void laboralToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void preventivaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #region turnos
        protected virtual void turnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        protected virtual void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region examen
        protected virtual void bbiPreventivaExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiLaboralExamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void preventivaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        protected virtual void laboralToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region MesaEntradas
        protected virtual void mesaDeEntradasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        protected virtual void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region planillaExportacionesVentanilla
        protected virtual void ventanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void planillaDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void prevenExportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void laboralExportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected virtual void informeAudiometriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void MostrarVentanas(List<bool> blnLista)
        {
            nbiConfiguracion.Visible = blnLista[0];
            nbiExamenes.Visible = blnLista[1];
            nbiMesaEntrada.Visible = blnLista[2];
            nbiPacientes.Visible = blnLista[3];
            nbiVentanilla.Visible = blnLista[4];
            nbiAgenda.Visible = blnLista[5];
            nbiTurnos.Visible = blnLista[9]; //Turnos

            configuracionToolStripMenuItem.Visible = blnLista[0];
            examenesToolStripMenuItem.Visible = blnLista[1];
            mesaDeEntradasToolStripMenuItem.Visible = blnLista[2];
            pacienteToolStripMenuItem.Visible = blnLista[3];
            ventanillaToolStripMenuItem.Visible = blnLista[4];
            planillaDelDiaToolStripMenuItem.Visible = blnLista[5];
            turnosToolStripMenuItem.Visible = blnLista[9];

            toolStripMenuItem1.Visible = blnLista[0];   //configuracion
            toolStripMenuItem14.Visible = blnLista[1];  //Examenes
            toolStripMenuItem11.Visible = blnLista[2];	//MesaEntradas
            toolStripMenuItem5.Visible = blnLista[3];   //Pacientes
            toolStripMenuItem17.Visible = blnLista[4];  //Ventanilla            
            toolStripMenuItem21.Visible = blnLista[5];  //Planilla
            toolStripMenuItem8.Visible = blnLista[9];   //Turnos

            if (blnLista[1] == true && blnLista[9] == true)
            {
                exportacionesToolStripMenuItem.Visible = blnLista[1];
                toolStripMenuItem18.Visible = blnLista[1];  //Exportaciones
            }
            else
                exportacionesToolStripMenuItem.Visible = false;

            informeAudiometriaToolStripMenuItem.Visible = blnLista[10];
            toolStripMenuItem22.Visible = blnLista[10];  //Audiometria
        }

        public void PermisosUsuario(string strUsuario)
        {
            Comunes.UsuarioDatos DatosUser = new Comunes.UsuarioDatos();
            List<bool> blnLista = new List<bool>();

            blnLista = DatosUser.Permisos(strUsuario);
            MostrarVentanas(blnLista);
        }

        public void CerrarTodosLosFormularios()
        {
            foreach (Form Formulario in this.MdiChildren)
            {
                Formulario.Close();
            }
        }

        public void ColorRibbonPreventiva()
        {
            rbcControlMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
        }

        public void ColorRibbonLaboral()
        {
            rbcControlMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
        }

        public void ColorRibbonConfiguracion()
        {
            rbcControlMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Orange;
        }

        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        #region MenuConfiguraciones
        public void MostrarPestanaConfigBasica()
        {
            rbpConfiguracionGeneral.Visible = true;
            rbpConfiguracionPreventiva.Visible = true;// false
            rbpConfiguracionLaboral.Visible = true;// false
            minimizarRibbon(false);
        }

        public void MostrarPestanaConfigPreventiva()
        {
            rbpConfiguracionPreventiva.Visible = true;// false
            rbpConfiguracionGeneral.Visible = true;// false            
            rbpConfiguracionLaboral.Visible = true;
            minimizarRibbon(false);
        }

        public void MostrarPestanaConfigLaboral()
        {
            rbpConfiguracionLaboral.Visible = true;
            rbpConfiguracionGeneral.Visible = true;// false
            rbpConfiguracionPreventiva.Visible = true;// false 
            minimizarRibbon(false);
        }

        //public bool MostrarPestanasConfiguracion()
        //{

        //}

        public SByte ActivarPestanasConfiguracion(object sender)
        {
            sbyte intValor = 0;

            RibbonControl ribbon = sender as RibbonControl;

            if (strTipoConfig != "")
            {
                if (strTipoConfig == "Basico")
                {
                    intValor = 1;
                    //ribbon.SelectedPage = rbpConfiguracionGeneral;
                }

                if (strTipoConfig == "Preventiva")
                {
                    intValor = 2;
                    //ribbon.SelectedPage = rbpConfiguracionPreventiva;
                }

                if (strTipoConfig == "Laboral")
                {
                    intValor = 3;
                    //ribbon.SelectedPage = rbpConfiguracionLaboral;
                }
            }


            return intValor;
        }
        #endregion

        #region MenuPacientes
        public void MostrarPestanaPacientePreven()
        {
            rbpPacientePre.Visible = true;
            rbpPacienteLab.Visible = true;
        }

        public void MostrarPestanaPacienteLabora()
        {
            rbpPacienteLab.Visible = true;
            rbpPacientePre.Visible = true;
        }

        #endregion

        #region MenuExamenes
        public void MostrarPestanaExamPreven()
        {
            rbpExamenesPre.Visible = true;
            rbpExamenesLab.Visible = true; // false
        }

        public void MostrarPestanaExamLabora()
        {
            rbpExamenesLab.Visible = true;
            rbpExamenesPre.Visible = true; // false           
        }

        #endregion

        // ----------------------------------------------------------------
        // ----------------------------------------------------------------        

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            //try
            //{
            //    for (int i = 0; (i
            //                <= (menuStrip1.Items.Count - 1)); i++)
            //    {
            //        if (menuStrip1.Items[i].Selected)
            //        {
            //            Type t = Type.GetType("System.Windows.Forms.ToolStripDropDownItem.Equals()");
            //            if (menuStrip1.Items[i].GetType() != t)
            //            {
            //                ToolStripDropDownItem item = (ToolStripDropDownItem)menuStrip1.Items[i]; // TryCast(menuStrip1.Items[i], ToolStripDropDownItem);
            //                if ((item.HasDropDownItems
            //                            && !item.DropDown.Visible))
            //                {
            //                    item.ShowDropDown();
            //                    break;
            //                }
            //            }

            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //}
        }

        public void LimpiarEstadoIcono()
        {
            bbiConfigUsuarios.Down = false;
            bbiConfigMedico.Down = false;
            bbiLocalidadNacionalidad.Down = false;
            bbiTipoExamen.Down = false;
            bbiConfigHorarios.Down = false;
            bbiListaPrecios.Down = false;
            bbiLigas.Down = false;
            bbiClubes.Down = false;
            bbiUbicarFotos.Down = false;
            bbiUbicacionArchivos.Down = false;
            bbiValidaciones.Down = false;
            bbiPlantillaReportes.Down = false;
            bbiConfigMensajePre.Down = false;
            bbiArchivoConsolidar.Down = false;
            bbiConfigRayosX.Down = false;
            bbiValidacionesAutomaticas.Down = false;
            bbiEmpresas.Down = false;
            bbiCondicionesLaborales.Down = false;
            bbiUbicacionFotosLab.Down = false;
            bbiPlantillaReporteLab.Down = false;
            bbiArchivoConsolidarLab.Down = false;
            bbiConfigMensajeLab.Down = false;
            bbiConfigAuxiliar.Down = false;
            bbiDelegados.Down = false;
            bbiConsultaSQL.Down = false;
            bbiConfiguracionesPrestaciones2.Down = false;
        }

        private void bbiValidacionesAutomaticas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiUbicaArchivoLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {

        }

        protected virtual void frmBasePrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        protected virtual void bbiConfigIva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConfigurarIva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiConfigAuxiliar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbiDelegados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        //private void menuStrip2_MouseHover(object sender, EventArgs e)
        //{
        //    navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
        //}

        //private void navBarGroupControlContainer1_MouseLeave(object sender, EventArgs e)
        //{
        //    navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
        //}

        //private void navBarControl1_MouseLeave(object sender, EventArgs e)
        //{
        //    navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
        //}

        //private void navBarControl1_Leave(object sender, EventArgs e)
        //{
        //    navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
        //}

        //private void menuStrip1_Leave(object sender, EventArgs e)
        //{
        //    navBarControl1.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
        //}
    }
}