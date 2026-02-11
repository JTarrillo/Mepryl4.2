using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
    public partial class frmLogin : Form
    {

        private Configuracion configuracion;
        private Usuario usuario = null;

        //Define el Delegado 
        public delegate void DelegateDevolverID(Usuario usuario);
        public DelegateDevolverID objDelegateDevolverID = null;


        public frmLogin(Configuracion conf)
        {
            inicializar(conf, "");
        }

        public frmLogin(Configuracion conf, string mensaje)
        {
            inicializar(conf, mensaje);
        }

        private void inicializar(Configuracion conf, string mensaje)
        {
            //
            // Required for Windows Form Designer support
            //

            this.configuracion = conf;

            InitializeComponent();

            if (mensaje != "")
            {
                lbMensaje.Text = mensaje;
                this.Text = mensaje;
            }

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void butAceptar_Click(object sender, System.EventArgs e)
        {
            validarUsuario();
        }

        //Valida el usuario contra la base de datos
        private void validarUsuario()
        {
            UsuarioFactory uf = new UsuarioFactory();

            uf.strConexion = configuracion.getConectionString();

            if (uf.validarUsuario(tbNombre.Text.Trim(), tbClave.Text.Trim()))
            {
                this.DialogResult = DialogResult.OK;
                this.usuario = uf.getUsuario(tbNombre.Text.Trim());
                this.Close();
            }
            else
            {
                this.usuario = null;
                MessageBox.Show("El nombre de usuario o la contraseña no son correctos. Por favor inténtelo nuevamente.", "No se pudo iniciar la sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
        private void butSalir_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbNombre_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbClave.Focus();
        }

        private void tbClave_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butAceptar_Click(null, null);
                e.Handled = true;
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;

            //Devuelve objeto Usuario
            if (objDelegateDevolverID != null)
                objDelegateDevolverID(this.usuario);
        }

    }
}