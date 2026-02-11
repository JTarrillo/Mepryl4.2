using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReservaTurno : Form
    {
        public delegate void DelegateDevolverReserva(string destinatario);
        public DelegateDevolverReserva objDelegateDevolverReserva = null;

        public frmReservaTurno()
        {
            InitializeComponent();
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void aceptar()
        {
            if (textBox.Text != string.Empty)
            {
                if (objDelegateDevolverReserva != null)
                {
                    objDelegateDevolverReserva(textBox.Text);
                    this.Close();
                }    
            }
            else
            {
                MessageBox.Show("¡Es obligatorio indicar para quién se realiza la reserva!",
                    "Reservar Turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                botAceptar.PerformClick();
            }
            else if (e.KeyCode == Keys.F6)
            {
                botCancelar.PerformClick();
            }
        }
    }
}
