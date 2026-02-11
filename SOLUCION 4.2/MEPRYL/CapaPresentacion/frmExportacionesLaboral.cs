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
using Comunes;

namespace CapaPresentacion
{
    public partial class frmExportacionesLaboral : DevExpress.XtraEditors.XtraForm
    { 
        public frmExportacionesLaboral()
        {
            InitializeComponent();
        }

        public frmExportacionesLaboral(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
        }

        private void bbiExportarDictamen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExportacionLaboralDictamen frm = new frmExportacionLaboralDictamen();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmConsultaFacturacionEmpresa frm = new frmConsultaFacturacionEmpresa();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new System.Drawing.Point(46,165);
            frm.ShowDialog();
            //Utilidades.AbrePopUps(frm);
        }
    }
}
