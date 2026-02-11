using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacionBase
{
    public partial class frmInicio : Form
    {
        frmBasePrincipal form;
        public frmInicio(frmBasePrincipal frm)
        {
            InitializeComponent();
            form = frm;
        }

        private void botPreventiva_Click(object sender, EventArgs e)
        {
            form.mostrarPreventiva();
            this.Close();
        }

        private void botLab_Click(object sender, EventArgs e)
        {
            form.mostrarLaboral();
            this.Close();
        }
    }
}
