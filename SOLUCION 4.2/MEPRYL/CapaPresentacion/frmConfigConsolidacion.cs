using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocioMepryl;
using Entidades;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigConsolidacion : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtDatos;
        private CapaNegocioMepryl.ConfigConsolidacion Cons;
        List<string> valoresPreventiva = new List<string>();
        string strTipoPaciente = "";
        frmBasePrincipal frmThis;

        public frmConfigConsolidacion()
        {
            InitializeComponent();
            Cons = new CapaNegocioMepryl.ConfigConsolidacion();
            CargarDatosPreventiva();
        }

        public frmConfigConsolidacion(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            Cons = new CapaNegocioMepryl.ConfigConsolidacion();
            CargarDatosPreventiva();
            frmThis = parentForm;
        }

        public frmConfigConsolidacion(frmBasePrincipal parentForm, string TipoPaciente)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            Cons = new CapaNegocioMepryl.ConfigConsolidacion();
            CargarDatosPreventiva();
            strTipoPaciente = TipoPaciente;
            frmThis = parentForm;

            if (strTipoPaciente == "P")
            {
                tbcTabConfiguracion.TabPages.Remove(tabPage2);
                
            }
            else
            {
                tbcTabConfiguracion.TabPages.Remove(tabPage1);
            }
        }

        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            txtPlantilla.Text = SelectArchivo();
        }
        
        private void btnRadiologico_Click(object sender, EventArgs e)
        {
            txtRadiologico.Text = SelectDirectorio();
        }

        private string SelectDirectorio()
        {
            string strDirectorio = "";
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                strDirectorio = fbdMostrarDirectorio.SelectedPath;
            }

            return strDirectorio;
        }

        private void btnClinico_Click(object sender, EventArgs e)
        {
            txtClinico.Text = SelectDirectorio();
        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            txtLaboratorio.Text = SelectDirectorio();
        }

        private void btnRayos_Click(object sender, EventArgs e)
        {
            txtRayos.Text = SelectDirectorio();
        }

        private void btnECG_Click(object sender, EventArgs e)
        {
            txtECG.Text = SelectDirectorio();
        }

        private string SelectArchivo()
        {
            string strArchivo = "";

            openFileDialog.Filter = "Documento de Word |*.docx; *.doc";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                strArchivo = openFileDialog.FileName;                
            }

            return strArchivo;
        }

        private void CargarDatosPreventiva()
        {
            dtDatos = Cons.DirectoriosConsPreventiva();

            if (dtDatos.Rows.Count > 0)
            {
                foreach (DataRow row in dtDatos.Rows)
                {
                    txtPlantilla.Text = row.ItemArray[1].ToString();
                    txtRadiologico.Text = row.ItemArray[2].ToString();
                    txtClinico.Text = row.ItemArray[3].ToString();
                    txtLaboratorio.Text = row.ItemArray[4].ToString();
                    txtRayos.Text = row.ItemArray[5].ToString();
                    txtECG.Text = row.ItemArray[6].ToString();
                    txtConsolidado.Text = row.ItemArray[7].ToString();
                    txtInfEspirometria.Text = row.ItemArray[9].ToString();
                    txtInfAudiometria.Text = row.ItemArray[12].ToString();                    
                    txtInfPsicotecnico.Text = row.ItemArray[13].ToString();
                    txtInfEcodoppler.Text = row.ItemArray[11].ToString();
                    txtInfEEG.Text = row.ItemArray[10].ToString();
                    txtInfErgometria.Text = row.ItemArray[14].ToString();
                }
            }
        }

        private bool ValidaDatosPreventiva()
        {
            bool blnValor = true;

            valoresPreventiva.Clear();

            valoresPreventiva.Add(txtPlantilla.Text);
            valoresPreventiva.Add(txtRadiologico.Text);
            //valoresPreventiva.Add("c:");
            valoresPreventiva.Add(txtClinico.Text);
            valoresPreventiva.Add(txtLaboratorio.Text);
            valoresPreventiva.Add(txtRayos.Text);
            valoresPreventiva.Add(txtECG.Text);
            valoresPreventiva.Add(txtInfEspirometria.Text);
            valoresPreventiva.Add(txtInfEcodoppler.Text);
            valoresPreventiva.Add(txtInfAudiometria.Text);
            valoresPreventiva.Add(txtInfPsicotecnico.Text);
            valoresPreventiva.Add(txtInfEEG.Text);
            valoresPreventiva.Add(txtInfErgometria.Text);


            //foreach (string strValor in valoresPreventiva)
            //{
            //    if (strValor == "")
            //    {
            //        blnValor = false;
            //    }
            //}

            if (blnValor == false)
                MessageBox.Show("todos los campos son obligatorios", "Configuración básica", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return blnValor;
        }

        private bool ActualizaDatosPreventiva()
        {
            bool blnValor = false;

            if (ValidaDatosPreventiva())
            {
                Cons.ActualizaConsPreventiva(valoresPreventiva);
                blnValor = true;
            }

            return blnValor;
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            if (ActualizaDatosPreventiva())
            {
                MessageBox.Show("Datos guardados correctamente.", "Configuración básica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsolidado_Click(object sender, EventArgs e)
        {
            txtConsolidado.Text = SelectDirectorio();
        }

        private void frmConfigConsolidacion_Load(object sender, EventArgs e)
        {
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            txtInfEcodoppler.Text = SelectDirectorio();
        }

        private void btnInfEspirometria_Click(object sender, EventArgs e)
        {
            txtInfEspirometria.Text = SelectDirectorio();
        }

        private void btnAudiometria_Click(object sender, EventArgs e)
        {
            txtInfAudiometria.Text = SelectDirectorio();
        }

        private void btnPsicotecnico_Click(object sender, EventArgs e)
        {
            txtInfPsicotecnico.Text = SelectDirectorio();
        }

        private void btnEEG_Click(object sender, EventArgs e)
        {
            txtInfEEG.Text = SelectDirectorio();
        }

        private void btnErgometria_Click(object sender, EventArgs e)
        {
            txtInfErgometria.Text = SelectDirectorio();
        }
    }
}
