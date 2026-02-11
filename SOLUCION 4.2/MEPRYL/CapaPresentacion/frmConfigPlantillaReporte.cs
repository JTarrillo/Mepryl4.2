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
using CapaNegocioMepryl;
using CapaPresentacionBase;
using System.Diagnostics;

namespace CapaPresentacion
{
    public partial class frmConfigPlantillaReporte : DevExpress.XtraEditors.XtraForm
    {
        List<object> strDatos = new List<object>();
        CapaNegocioMepryl.ConfigPlantillaReporte Reporte = new CapaNegocioMepryl.ConfigPlantillaReporte();
        private string strTipoPlantilla = "P";
        frmBasePrincipal frmThis;

        public frmConfigPlantillaReporte()
        {
            InitializeComponent();
            Inicializar();
        }

        public frmConfigPlantillaReporte(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            Inicializar();
            frmThis = parentForm;
        }

        private void btnCaratula1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                 txtClinicoLab.Text = fbdMostrarDirectorio.FileName;
            }
        }        

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtLaboratorioLab.Text = fbdMostrarDirectorio.FileName;
            }
        }

        private void btnEspirometria1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtEspirometriaLab.Text = fbdMostrarDirectorio.FileName;
            }
        }

        private void btnClinico2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtClinicoLab.Text = fbdMostrarDirectorio.FileName;
            }
        }
                
        private void btnOlivera2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtCaratula.Text = fbdMostrarDirectorio.FileName;
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
            strDatos.Add(txtCaratula.Text);
            strDatos.Add(txtClinicoLab.Text);
            strDatos.Add(txtLaboratorioLab.Text);
            strDatos.Add(txtEspirometriaLab.Text);
            strDatos.Add("");
            strDatos.Add("");            
        }

        private void Guardar()
        {
            CargarValores();
            Reporte.guardarPlantilla(strDatos);
        }

        private void Actualizar()
        {
            CargarValores();
            Reporte.ActualizaPlantilla(strTipoPlantilla, strDatos);
        }

        private void Inicializar()
        {
            DataTable dt = null;

            dt = Reporte.ListarPlantillas(strTipoPlantilla);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtCaratula.Text = dt.Rows[i][2].ToString();
                    txtClinicoLab.Text = dt.Rows[i][3].ToString();
                    txtLaboratorioLab.Text = dt.Rows[i][4].ToString();
                    txtEspirometriaLab.Text = dt.Rows[i][5].ToString();
                }
            }
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
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigConsolidacion(frmThis, "P"), new Configuracion());
        }

        private void rbtDirectorioConsolidados_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigConsolidadosGuardarPre(frmThis), new Configuracion());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRadiologico_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtRadioligico.Text = fbdMostrarDirectorio.FileName;
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
            Process.Start(txtCaratula.Text);
        }

        private void btnVer04_Click(object sender, EventArgs e)
        {
            Process.Start(txtEspirometriaLab.Text);
        }

        private void btn05_Click(object sender, EventArgs e)
        {
            Process.Start(txtRadioligico.Text);
        }
    }
}
