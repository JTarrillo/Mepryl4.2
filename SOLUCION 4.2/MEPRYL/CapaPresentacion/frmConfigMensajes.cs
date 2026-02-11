using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigMensajes : DevExpress.XtraEditors.XtraForm
    {
        public frmConfigMensajes()
        {
            InitializeComponent();
        }

        public frmConfigMensajes(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
        }

        
    }
}
