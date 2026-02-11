using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comunes;
using CapaNegocioMepryl;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigConsolidadosGuardarLab : DevExpress.XtraEditors.XtraForm
    {
        string DireccionLogoCompleta, DireccionFirmaCompleta, DireccionAMostrar;
        string[] DireccionLogoSeparada, DireccionFirmaSeparada;
        frmBasePrincipal frmThis;
        private CapaNegocioMepryl.ConfigConsolidacion Cons;
        List<string> valoresPreventiva = new List<string>();

        public frmConfigConsolidadosGuardarLab()
        {
            InitializeComponent();
            CargarDatosPreventiva();
        }

        public frmConfigConsolidadosGuardarLab(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            frmThis = parentForm;
            Cons = new ConfigConsolidacion();
            CargarDatosFecha();
            CargarDatosParaPDF();
            CargarDatosPreventiva();
        }

        private void CargarDatosFecha()
        {
            DateTime fecha;
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("select Fecha from [MEPRYLv2.1].[dbo].[ConfigFecha] where TipoFecha = 'L'");
            if (dt.Rows.Count != 0)
            {
                fecha = Convert.ToDateTime(dt.Rows[0][0].ToString());
                tpExportacionDesde.Value = fecha;
            }
        }

    private void CargarDatosParaPDF()
        {
            DataTable DatosPDF = new DataTable();
            DatosPDF = SQLConnector.obtenerTablaSegunConsultaString("select logo, firma from dbo.ConfigReportes where tipoReporte=3 ");
            DireccionLogoCompleta = DatosPDF.Rows[0][0].ToString();
            DireccionFirmaCompleta = DatosPDF.Rows[0][1].ToString();
            DireccionLogoSeparada = DireccionLogoCompleta.Split(Convert.ToChar(@"\"));
            DireccionFirmaSeparada = DireccionFirmaCompleta.Split(Convert.ToChar(@"\"));
            tbNombreLogo.Text = DireccionLogoSeparada[DireccionLogoSeparada.Count() - 1];
            tbNombreFirma.Text = DireccionFirmaSeparada[DireccionFirmaSeparada.Count() - 1];
            DireccionAMostrar = DireccionLogoSeparada[0];
            for (int i = 1; i < DireccionLogoSeparada.Count() - 1; i++)
            {
                DireccionAMostrar = DireccionAMostrar + @"\" + DireccionLogoSeparada[i];
            }
            tbDireccionArchivosPDF.Text = DireccionAMostrar;
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

        private void btnPreventiva_Click(object sender, EventArgs e)
        {
            txtGuardaConsolidado.Text = SelectDirectorio();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ActualizaDatosPreventiva() && ActualizaDatosPDF() && ActualizaDatosFecha())
            {
                MessageBox.Show("Datos guardados correctamente.", "Configuración básica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, Verifique los datos ingresados.", "Configuración básica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool ActualizaDatosPDF()
        {
            bool retorno = false;
            if (tbDireccionArchivosPDF.Text != string.Empty && tbNombreFirma.Text != string.Empty && tbNombreLogo.Text != string.Empty)
            {
                SQLConnector.EjecutarConsulta("update [MEPRYLv2.1].[dbo].[ConfigReportes] set logo = '" + tbDireccionArchivosPDF.Text.ToString() + @"\" + tbNombreLogo.Text.ToString() + "', firma = '" + tbDireccionArchivosPDF.Text.ToString() + @"\" + tbNombreFirma.Text.ToString() + "' where tipoReporte = 3");
                retorno = true;
            }
            return retorno;
        }

        private bool ActualizaDatosFecha()
        {
            bool retorno = false;
            if (tpExportacionDesde.Value != null)
            {
                SQLConnector.EjecutarConsulta("delete from [MEPRYLv2.1].[dbo].[ConfigFecha] where TipoFecha = 'L'");
                SQLConnector.EjecutarConsulta("insert into [MEPRYLv2.1].[dbo].[ConfigFecha] (TipoFecha, Fecha) values ('L' , convert(datetime, '" + tpExportacionDesde.Value.ToShortDateString() + "'))");
                retorno = true;
            }
            return retorno;
        }

        private bool ActualizaDatosPreventiva()
        {
            bool blnValor = false;

            if (ValidaDatosPreventiva())
            {
                Cons.ActualizaGeneraConsolidadoLaboral(valoresPreventiva);
                blnValor = true;
            }

            return blnValor;
        }

        private void btnArchivosPDF_Click(object sender, EventArgs e)
        {
            tbDireccionArchivosPDF.Text = SelectDirectorio();
        }

        private bool ValidaDatosPreventiva()
        {
            bool blnValor = true;

            valoresPreventiva.Clear();

            valoresPreventiva.Add(txtGuardaConsolidado.Text);

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

        private void CargarDatosPreventiva()
        {
            DataTable dtDatos;
            dtDatos = Cons.DirectoriosConsLaboral();

            if (dtDatos.Rows.Count > 0)
            {
                foreach (DataRow row in dtDatos.Rows)
                {
                    txtGuardaConsolidado.Text = row.ItemArray[7].ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
