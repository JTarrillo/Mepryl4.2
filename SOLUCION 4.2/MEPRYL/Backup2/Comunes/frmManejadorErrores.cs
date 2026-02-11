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
    public partial class frmManejadorErrores : Form
    {
        public Configuracion configuracion;
        public frmManejadorErrores()
        {
            InitializeComponent();
        }

        private void butOk_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        private void butEnviarMail_Click(object sender, System.EventArgs e)
        {
            frmManejadorErroresEMail f = new frmManejadorErroresEMail();
            f.Modulo.Text = this.Modulo.Text;
            f.Mensaje.Text = this.Mensaje.Text;
            f.PilaLlamadas.Text = this.PilaLlamadas.Text;
            f.configuracion = this.configuracion;

            f.ShowDialog();

        }

    }
}