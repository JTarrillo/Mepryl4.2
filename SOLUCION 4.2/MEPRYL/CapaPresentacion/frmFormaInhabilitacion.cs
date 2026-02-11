using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmFormaInhabilitacion : Form
    {
        frmBusquedaExamen formExamen;
        public frmFormaInhabilitacion(frmBusquedaExamen frm)
        {
            InitializeComponent();
            formExamen = frm;
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            if (rbNoEfectuado.Checked) { formExamen.inhabilitar("14"); }
            if (rbNoRenovado.Checked) { formExamen.inhabilitar("10"); }
            this.Close();
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
