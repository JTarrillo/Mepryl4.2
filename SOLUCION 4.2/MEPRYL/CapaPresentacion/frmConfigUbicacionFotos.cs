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
    public partial class frmConfigUbicacionFotos : DevExpress.XtraEditors.XtraForm
    {
        UbicacionFotos DirectorioFotos = new UbicacionFotos();
        string strValorLaboral = "";
        frmBasePrincipal frmThis;

        public frmConfigUbicacionFotos()
        {
            InitializeComponent();
        }

        public frmConfigUbicacionFotos(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            frmThis = parentForm;
        }

        private void btnPreventiva_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtPreventiva.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            DirectorioFotos.GuardarDirectorioFotos(txtPreventiva.Text, strValorLaboral);
            DirectorioFotos.GuardarFotosLiga(txtLiga.Text, txtClub.Text);
            MessageBox.Show("¡Se guardó correctamente!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void frmConfigUbicacionFotos_Load(object sender, EventArgs e)
        {
            strValorLaboral = DirectorioFotos.UbicacionFotoLaboral();
            txtPreventiva.Text = DirectorioFotos.UbicacionFotopreventiva();
            txtLiga.Text = DirectorioFotos.UbicacionFotoLiga();
            txtClub.Text = DirectorioFotos.UbicacionFotoClub();
        }

        private void rbtFotos_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigUbicacionFotos(frmThis), new Configuracion());
        }

        private void rbtPlantillasReportes_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigPlantillaReporte(frmThis), new Configuracion());
        }

        private void rbtArchivosConsolidados_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigConsolidacion(frmThis,"P"), new Configuracion());
        }

        private void rbtDirectorioConsolidados_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigConsolidadosGuardarPre(frmThis), new Configuracion());
        }

        private void btnLiga_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtLiga.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }

        private void btnClub_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtClub.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }
    }
}
