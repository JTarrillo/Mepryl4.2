using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comunes
{
    public partial class frmCambioContrasena : Form
    {
        private UsuarioDatos UserDatos;
        private string strNombreUsuario = "";

        public frmCambioContrasena()
        {
            InitializeComponent();
        }

        public frmCambioContrasena(string strUsuario)
        {
            InitializeComponent();
            UserDatos = new UsuarioDatos();
            strNombreUsuario = strUsuario;
            cargarDatos();
        }

        public void cargarDatos()
        {
            txtNombreUsuario.Text = strNombreUsuario;

            if (UserDatos.VerificaUsuario(strNombreUsuario))
            {
                txtEmail.Text = UserDatos.RecuperaMailUsuario(strNombreUsuario);
            }else
            {
                MessageBox.Show("El usuario no existe, contacte con el administrador", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VerificaUsuarioCorrecto()
        {
            string strContrasena = Utilidades.desencriptar(UserDatos.RecuperaPassWordUsuario(strNombreUsuario));

            if (txtPassActual.Text == strContrasena)
            {
                UserDatos.ActualizaUsuario(strNombreUsuario, txtEmail.Text, Utilidades.encriptar(txtPassNuevo.Text));
                MessageBox.Show("Datos actualizados correctamente", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("la contraseña actual no es correcta", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            VerificaUsuarioCorrecto();
            this.Close();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
