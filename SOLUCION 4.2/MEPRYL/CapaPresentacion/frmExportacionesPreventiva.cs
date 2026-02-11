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
    public partial class frmExportacionesPreventiva : DevExpress.XtraEditors.XtraForm
    {
        public frmExportacionesPreventiva()
        {
            InitializeComponent();
        }

        public frmExportacionesPreventiva(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
        }

        private void bbiExpMedida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExportacionCompleta frm = new frmExportacionCompleta();
            frm.ShowDialog();
        }

        private void bbiExpWeb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUtilidadesPaginaWeb frm = new frmUtilidadesPaginaWeb();
            frm.ShowDialog();
        }

        private void bbiDataSMS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUtilidadesDataSMS frm = new frmUtilidadesDataSMS();
            frm.ShowDialog();
        }

        private void bbiExportarMesaEnt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExportarMesaEntrada frm = new frmExportarMesaEntrada();
            frm.ShowDialog();
        }

        private void bbiExportarConsolidadoPreventiva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExportarConsolidado frm = new frmExportarConsolidado();
            frm.ShowDialog();
        }

        private void bbiCrearTablaJumpy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCrearTablaJumpy frm = new frmCrearTablaJumpy();
            frm.ShowDialog();
        }
    }
}
