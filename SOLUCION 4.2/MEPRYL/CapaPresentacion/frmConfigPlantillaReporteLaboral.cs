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
using System.Diagnostics;
using Comunes;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmConfigPlantillaReporteLaboral : DevExpress.XtraEditors.XtraForm
    {
        frmBasePrincipal frmThis;
        List<object> strDatos = new List<object>();
        CapaNegocioMepryl.ConfigPlantillaReporte ReporteLab = new CapaNegocioMepryl.ConfigPlantillaReporte();
        private string strTipoPlantilla = "L";

        public frmConfigPlantillaReporteLaboral()
        {
            InitializeComponent();
            Inicializar();
        }

        public frmConfigPlantillaReporteLaboral(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            Inicializar();
        }
                
        private void btnClinico2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtClinicoLab.Text = fbdMostrarDirectorio.FileName;
            }
        }

        private void btnLaboratorio2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtLaboratorioLab.Text = fbdMostrarDirectorio.FileName;
            }
        }

        private void btnOlivera2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtOliveraLab.Text = fbdMostrarDirectorio.FileName;
            }
        }        

        private void btnEsprirometria3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtEspirometriaLab.Text = fbdMostrarDirectorio.FileName;
            }
        }       

        private void botGuardar_Click(object sender, EventArgs e)
        {
            Actualizar();
            MessageBox.Show("¡Se guardó correctamente!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarValores()
        {
            strDatos.Clear();
            strDatos.Add(strTipoPlantilla);
            strDatos.Add("");
            strDatos.Add(txtClinicoLab.Text);
            strDatos.Add(txtLaboratorioLab.Text);
            strDatos.Add(txtEspirometriaLab.Text);
            strDatos.Add(txtOliveraLab.Text);
            strDatos.Add("");
        }

        private void Guardar()
        {
            CargarValores();
            ReporteLab.guardarPlantilla(strDatos);
        }

        private void Actualizar()
        {
            CargarValores();
            ReporteLab.ActualizaPlantilla(strTipoPlantilla, strDatos);
        }

        private void Inicializar()
        {
            DataTable dt = null;

            dt = ReporteLab.ListarPlantillas(strTipoPlantilla);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {                    
                    txtClinicoLab.Text = dt.Rows[i][3].ToString();
                    txtLaboratorioLab.Text = dt.Rows[i][4].ToString();
                    txtEspirometriaLab.Text = dt.Rows[i][5].ToString();
                    txtOliveraLab.Text = dt.Rows[i][6].ToString();
                }
            }
        }

        private void btnVer01_Click(object sender, EventArgs e)
        {
            Process.Start(@"" + txtClinicoLab.Text);
        }

        private void btnVer02_Click(object sender, EventArgs e)
        {
            Process.Start(@"" + txtLaboratorioLab.Text);
        }

        private void btnVer03_Click(object sender, EventArgs e)
        {
            Process.Start(@"" + txtOliveraLab.Text);
        }

        private void btnVer04_Click(object sender, EventArgs e)
        {
            Process.Start(@"" + txtEspirometriaLab.Text);
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
