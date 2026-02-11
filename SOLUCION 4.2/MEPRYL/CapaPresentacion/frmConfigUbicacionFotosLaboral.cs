using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocioMepryl;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigUbicacionFotosLaboral : DevExpress.XtraEditors.XtraForm
    {
        UbicacionFotos DirectorioFotos = new UbicacionFotos();
        string strValorPreventiva = "";
        frmBasePrincipal frmThis;

        public frmConfigUbicacionFotosLaboral()
        {
            InitializeComponent();
        }

        public frmConfigUbicacionFotosLaboral(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
        }
        
        private void btnLaboral_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtLaboral.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            DirectorioFotos.GuardarDirectorioFotos(strValorPreventiva, txtLaboral.Text);
            MessageBox.Show("¡Se guardó correctamente!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmConfigUbicacionFotos_Load(object sender, EventArgs e)
        {
            txtLaboral.Text = DirectorioFotos.UbicacionFotoLaboral();
            strValorPreventiva = DirectorioFotos.UbicacionFotopreventiva();
        }

        private void rbtFotos_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigUbicacionFotosLaboral(frmThis), new Configuracion());
        }

        private void rbtPlantillasReportes_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigPlantillaReporteLaboral(frmThis), new Configuracion());
        }

        private void rbtArchivosConsolidados_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigConsolidacionLaboral(frmThis, "L"), new Configuracion());
        }

        private void rbtDirectorioConsolidados_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigConsolidadosGuardarLab(frmThis), new Configuracion());
        }
    }
}
