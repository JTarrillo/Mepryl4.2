using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;


namespace CapaPresentacionBase
{
    public partial class frmBasePrincipal : Form
    {
        public Configuracion configuracion; // = new Configuracion();
        public bool login = true;
        public string modo = "";

        public frmBasePrincipal() : this(true)
        {
            
        }
        public frmBasePrincipal(bool conectarBaseDatos)
        {
            this.configuracion = new Configuracion(conectarBaseDatos);
            InitializeComponent();
            this.login = conectarBaseDatos;
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new frmBasePrincipal());
        }

        protected virtual void abrirFormularioInicial() { }


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

        private void frmBasePrincipal_Load(object sender, EventArgs e)
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
                    abrirFormularioMenu();
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

                //Toma el nombre del usuario
                this.Text = this.Text + " - " + usuario.apellido + ", " + usuario.nombre;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void frmBasePrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro que desea salir?", "Salir",
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
            botConsolidaciónInformes.Visible = true;
        }

        public void mostrarPreventiva()
        {
             cargarPreventiva();
             modo = "P";
             Menu.Visible = true;
        }

        public void mostrarLaboral()
        {
            cargarLaboral();
            modo = "L";
            Menu.Visible = true;
        }

        private void botInicio_Click(object sender, EventArgs e)
        {
            abrirFormularioMenu();
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
            botConsolidaciónInformes.Visible = false;
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
            botConsolidaciónInformes.Visible = false;
        }

        private void frmBasePrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            SQLConnector.desconectarBaseDeDatos();
        }



 
  





 

   




 



     



     

    





  
    }
}