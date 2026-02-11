using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using Excel = Microsoft.Office.Interop.Excel;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigReportes : DevExpress.XtraEditors.XtraForm
    {
        bool existenValores;
        public frmConfigReportes()
        {
            InitializeComponent();
            rbPreventCaratula.Checked = true;
        }

        public frmConfigReportes(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            rbPreventCaratula.Checked = true;
        }

        private void botFLLogo_Click(object sender, EventArgs e)
        {
            abrirFD(1);
        }

        private void botFLFirma_Click(object sender, EventArgs e)
        {
            abrirFD(2);
        }

        private void cargarValores(int modo)
        {
            limpiar();
            existenValores = false;
            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ConfigReportes
            where tipoReporte = '" + modo.ToString() + "'");
            if (valores.Rows.Count > 0)
            {
                existenValores = true;
                //cargarImagenes(pbLogo, (byte[])valores.Rows[0].ItemArray[1]);
                //cargarImagenes(pbFirma, (byte[])valores.Rows[0].ItemArray[2]);
                //tbProfesional.Text = valores.Rows[0].ItemArray[3].ToString();
                //tbMatricula.Text = valores.Rows[0].ItemArray[4].ToString();
                //tbCargo.Text = valores.Rows[0].ItemArray[5].ToString();
                //tbPiePagina.Text = valores.Rows[0].ItemArray[6].ToString();
                //tbLibroYFolio.Text = valores.Rows[0].ItemArray[8].ToString();

                //GRV - Guido 02/12/2016
                //Cargar la ruta de la imagen y reporte en pantalla
                tbLogo.Text = valores.Rows[0].ItemArray[7].ToString();
                tbFirma.Text = valores.Rows[0].ItemArray[8].ToString();
                tbGuardarReporte.Text = valores.Rows[0].ItemArray[9].ToString();
                tbProfesional.Text = valores.Rows[0].ItemArray[1].ToString();
                tbMatricula.Text = valores.Rows[0].ItemArray[2].ToString();
                tbCargo.Text = valores.Rows[0].ItemArray[3].ToString();
                tbPiePagina.Text = valores.Rows[0].ItemArray[4].ToString();
                tbExportarReporte.Text = valores.Rows[0].ItemArray[10].ToString();

                tbLibroYFolio.Text = valores.Rows[0].ItemArray[6].ToString();                
                pbLogo.ImageLocation = valores.Rows[0].ItemArray[7].ToString();
                pbFirma.ImageLocation = valores.Rows[0].ItemArray[8].ToString();                
            }
        }

        private void cargarImagenes(PictureBox pb, byte[] imag)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ms = new System.IO.MemoryStream(imag);
            pb.Image = Image.FromStream(ms);
        }

        private void abrirFD(int modo)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string direccion = openFileDialog.FileName.ToString();
                    if (modo == 1) { pbLogo.Image = Image.FromFile(direccion); tbLogo.Text = direccion;}
                    else { pbFirma.Image = Image.FromFile(direccion); tbFirma.Text = direccion; }         
                }
                catch
                {
                    MessageBox.Show("No se soporta el formato del archivo seleccionado");
                }
            }
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            guardar();
        }


        private void guardar()
        {
            List<string> list = SQLConnector.generarListaParaProcedure("@logo", "@firma", "@profesional"
                   , "@matricula", "@cargo", "@piePagina", "@tipoReporte", "@libroFolio", "@Reporte", "@exportar");

            // GRV - Ramírez 02/12/2016 - guardar ruta de imagenes
            //System.IO.MemoryStream msLogo = new System.IO.MemoryStream();
            //if (pbLogo.Image != null) { pbLogo.Image.Save(msLogo, System.Drawing.Imaging.ImageFormat.Png); }
            //System.IO.MemoryStream msFirma = new System.IO.MemoryStream();
            //if (pbFirma.Image != null) { pbFirma.Image.Save(msFirma, System.Drawing.Imaging.ImageFormat.Png); }

            string tipoReporte = obtenerTipoReporte();

            if (existenValores)
            {
                SQLConnector.executeProcedure("sp_ConfigReportes_Update", list, tbLogo.Text,
                    tbFirma.Text, tbProfesional.Text, tbMatricula.Text, tbCargo.Text, tbPiePagina.Text,tipoReporte, tbLibroYFolio.Text, tbGuardarReporte.Text, tbExportarReporte.Text);
            }
            else
            {
                SQLConnector.executeProcedure("sp_ConfigReportes_Add", list, tbLogo.Text,
                   tbFirma.Text, tbProfesional.Text, tbMatricula.Text, tbCargo.Text, tbPiePagina.Text,tipoReporte, tbLibroYFolio.Text, tbGuardarReporte.Text, tbExportarReporte.Text);
            }
            MessageBox.Show("¡Se guardó correctamente!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void rbPrevLaborat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrevLaborat.Checked) { cargarValores(2); }
        }

        private void rbPreventCaratula_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPreventCaratula.Checked) { cargarValores(1); }
        }

  

        private void limpiar()
        {
            tbCargo.Clear();
            //tbFirma.Clear();
            //tbLogo.Clear();
            tbMatricula.Clear();
            tbPiePagina.Clear();
            tbProfesional.Clear();
            pbFirma.Image = null;
            pbLogo.Image = null;
        }

        private bool chekearEstado(RadioButton r)
        {
            if (r.Checked) { return true; }
            return false;
        }

        private string obtenerTipoReporte()
        {
            if (chekearEstado(rbPreventCaratula)) { return "1";}
            if (chekearEstado(rbPrevLaborat)) { return "2"; }
            if (chekearEstado(rbExAptitud)) { return "3"; }
            if (chekearEstado(rbExAptitudOlivera)) { return "4"; }
            if (chekearEstado(rbConsultorio)) { return "5"; }
            if (chekearEstado(rbHistoriaClinica)) { return "6"; }
            return "";
         
        }

        private void rbExAptitud_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExAptitud.Checked) { cargarValores(3); }
        }

        private void rbExAptitudOlivera_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExAptitudOlivera.Checked) { cargarValores(4); }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbConsultorio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConsultorio.Checked) { cargarValores(5); }
        }

        private void rbHistoriaClinica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHistoriaClinica.Checked) { cargarValores(6); }
        }

        private void botFLReporte_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK) 
            {
                tbGuardarReporte.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }

        private void botFLExportar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                tbExportarReporte.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }

        private void tbLogo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
