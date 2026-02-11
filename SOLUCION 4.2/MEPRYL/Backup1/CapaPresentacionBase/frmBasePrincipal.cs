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
                    abrirFormularioInicial();
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
                this.configuracion.usuario = usuario;

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


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}