using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaPresentacionBase;
using Comunes;

namespace CapaPresentacion
{
    public partial class FrmDelegados : DevExpress.XtraEditors.XtraForm
    {
        private frmBasePrincipal parentForm;

        public FrmDelegados()
        {
            InitializeComponent();
        }

        public FrmDelegados(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void FrmDelegados_Load(object sender, EventArgs e)
        {
            try
            {
                // Aquí irá la lógica de carga del formulario
                CargarDatos();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, parentForm.configuracion);
            }
        }

        private void CargarDatos()
        {
            // TODO: Implementar carga de datos de delegados
        }
    }
}
