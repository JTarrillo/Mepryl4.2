using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmTipoPacienteSeleccionar : Form
    {
        public char strTipo = 'N';

        public frmTipoPacienteSeleccionar()
        {
            InitializeComponent();
        }

        private void botPreventiva_Click(object sender, EventArgs e)
        {
            strTipo = 'P';
            this.Close();
        }

        private void botLab_Click(object sender, EventArgs e)
        {
            strTipo = 'L';
            this.Close();
        }

    }
}
