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
    public partial class frmConfigConsolidacionLaboral : DevExpress.XtraEditors.XtraForm
    {
        frmBasePrincipal frmThis;
        private DataTable dtDatos;
        private CapaNegocioMepryl.ConfigConsolidacion Cons;
        List<string> valoresPreventiva = new List<string>();
        string strTipoPaciente = "";

        public frmConfigConsolidacionLaboral()
        {
            InitializeComponent();
            Cons = new CapaNegocioMepryl.ConfigConsolidacion();
            CargarDatosLaboral();
        }

        public frmConfigConsolidacionLaboral(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            Cons = new CapaNegocioMepryl.ConfigConsolidacion();
            CargarDatosLaboral();
        }

        public frmConfigConsolidacionLaboral(frmBasePrincipal parentForm, string TipoPaciente)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            Cons = new CapaNegocioMepryl.ConfigConsolidacion();
            CargarDatosLaboral();
            strTipoPaciente = TipoPaciente;            
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

        private void CargarDatosLaboral()
        {
            dtDatos = Cons.DirectoriosConsLaboral();

            if (dtDatos.Rows.Count > 0)
            {
                foreach (DataRow row in dtDatos.Rows)
                {
                    txtInfEcodoppler.Text = row.ItemArray[11].ToString();
                    txtInformeClinicoLaboral.Text = row.ItemArray[3].ToString();
                    txtInfLaboratorioLaboral.Text = row.ItemArray[4].ToString();
                    txtRayosXLaboral.Text = row.ItemArray[5].ToString();
                    txtDirectorioECG.Text = row.ItemArray[6].ToString();
                    txtInfAudiometria.Text = row.ItemArray[12].ToString();
                    txtInfEspirometria.Text = row.ItemArray[9].ToString();
                    txtInfEEG.Text = row.ItemArray[10].ToString();
                    txtInfPsicotecnico.Text = row.ItemArray[13].ToString();
                }
            }
        }

        private bool ValidaDatosPreventiva()
        {
            bool blnValor = true;

            valoresPreventiva.Clear();

            valoresPreventiva.Add(" ");
            //valoresPreventiva.Add(txtRadiologico.Text);
            valoresPreventiva.Add(txtInfEcodoppler.Text);
            valoresPreventiva.Add(txtInformeClinicoLaboral.Text);
            valoresPreventiva.Add(txtInfLaboratorioLaboral.Text);
            valoresPreventiva.Add(txtRayosXLaboral.Text);
            valoresPreventiva.Add(txtDirectorioECG.Text);            
            valoresPreventiva.Add(txtInfAudiometria.Text);            
            valoresPreventiva.Add(txtInfEspirometria.Text);
            valoresPreventiva.Add(txtInfEEG.Text);
            valoresPreventiva.Add(txtInfEcodoppler.Text);
            valoresPreventiva.Add(txtInfAudiometria.Text);
            valoresPreventiva.Add(txtInfPsicotecnico.Text);

            foreach (string strValor in valoresPreventiva)
            {
                if (strValor == "")
                {
                    blnValor = false;
                }
            }

            if (blnValor == false)
                MessageBox.Show("todos los campos son obligatorios", "Configuración básica", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return blnValor;
        }

        private bool ActualizaDatosPreventiva()
        {
            bool blnValor = false;

            if (ValidaDatosPreventiva())
            {
                Cons.ActualizaConsLaboral(valoresPreventiva);
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
                
        private void frmConfigConsolidacion_Load(object sender, EventArgs e)
        {
            
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


        private void btnClinicoLaboral_Click(object sender, EventArgs e)
        {
            txtInformeClinicoLaboral.Text = SelectDirectorio();
        }

        private void btnLaboratorioLaboral_Click(object sender, EventArgs e)
        {
            txtInfLaboratorioLaboral.Text = SelectDirectorio();
        }

        private void btnRayosLaboral_Click(object sender, EventArgs e)
        {
            txtRayosXLaboral.Text = SelectDirectorio();
        }

        private void btnEcgLaboral_Click(object sender, EventArgs e)
        {
            txtDirectorioECG.Text = SelectDirectorio();
        }

        private void btnInfoEcodopplerLaboral_Click(object sender, EventArgs e)
        {
            txtInfEcodoppler.Text = SelectDirectorio();
        }

        private void btnAudiometriaLaboral_Click(object sender, EventArgs e)
        {
            txtInfAudiometria.Text = SelectDirectorio();
        }

        private void btnInfEspirometria_Click(object sender, EventArgs e)
        {
            txtInfEspirometria.Text = SelectDirectorio();
        }

        private void btnPsicotecnico_Click(object sender, EventArgs e)
        {
            txtInfPsicotecnico.Text = SelectDirectorio();
        }

        private void btnEEG_Click(object sender, EventArgs e)
        {
            txtInfEEG.Text = SelectDirectorio();
        }

        private void txtInfPsicotecnico_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
