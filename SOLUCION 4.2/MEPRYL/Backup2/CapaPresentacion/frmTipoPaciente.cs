using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmTipoPaciente : Form
    {
        public delegate void DelegateDevolverID(char tipo);
        public DelegateDevolverID objDelegateDevolverID = null;

        public frmTipoPaciente()
        {
            InitializeComponent();
            tbMensaje.Text = "SELECCIONE LA ESPECIALIDAD PARA ASIGNAR EL TURNO";
        }

        private void botPreventiva_Click(object sender, EventArgs e)
        {
            if (objDelegateDevolverID != null)
            {
                objDelegateDevolverID('P');
                this.Close();
            }  
        }

        private void botLab_Click(object sender, EventArgs e)
        {
            if (objDelegateDevolverID != null)
            {
                objDelegateDevolverID('L');
                this.Close();
            }  
        }
    }
}
