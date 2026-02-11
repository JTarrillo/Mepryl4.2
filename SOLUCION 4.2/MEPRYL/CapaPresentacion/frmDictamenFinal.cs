using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using Entidades;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmDictamenFinal : DevExpress.XtraEditors.XtraForm
    {
        DataGridViewRow row;
        frmBusquedaExamen frm;
        frmPaciente formPac;
        DataTable validaciones;
        bool blnFrmBusquedaExamen = false;
        bool blnFrmPaciente = false;

        CapaNegocioMepryl.ExamenPreventiva preventiva;

        public frmDictamenFinal(frmBusquedaExamen f, DataGridViewRow r, bool frmActivoBusqExamen)
        {
            InitializeComponent();
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            row = r;
            frm = f;
            blnFrmBusquedaExamen = true;

            this.Text = "N° Examen: " + r.Cells[3].Value.ToString() + " - DNI: " +
                  r.Cells[4].Value.ToString() + " Examinado: " + r.Cells[5].Value.ToString();
            llenarCombo(cboDictFinal, "90");
            llenarEntidad(r.Cells[0].Value);
            this.ActiveControl = cboDictFinal;
            chequearDictamen();
        }

        public frmDictamenFinal(frmPaciente f, DataGridViewRow r, bool frmActivoPaciente)
        {
            InitializeComponent();
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            row = r;
            formPac = f;
            blnFrmPaciente = true;

            llenarCombo(cboDictFinal, "90");
            llenarEntidad(r.Cells[0].Value);
            this.ActiveControl = cboDictFinal;
            chequearDictamen();
        }


        private void llenarEntidad(object idTipoExamen)
        {
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones v inner join dbo.Clasificaciones c on v.idClasif = c.id");
            Entidades.ExamenPreventiva examen = preventiva.cargarExamen(idTipoExamen.ToString());
            tbId.Text = examen.IdTipoExamen.ToString();
            tbDictCli.Text = filtrarValidacion(examen.DictFisico);
            tbDictLab.Text = filtrarValidacion(examen.DictLab);
            tbDictRX.Text = filtrarValidacion(examen.DictRx);
            tbDictCar.Text = filtrarValidacion(examen.DictCar);
            if (examen.DictFinal != -1) { cboDictFinal.SelectedValue = examen.DictFinal; }
            tbObsClinico.Text = examen.ObsFisico;
            tbObsLaboratorio.Text = examen.ObsLaborat;
            tbObsRX.Text = examen.ObsRx;
            tbObsCardiolog.Text = examen.ObsCar;
            comprobarValidacion(examen.DictFisico, tbCli, pbDictCli);
            comprobarValidacion(examen.DictLab, tbLab, pbDictLab);
            comprobarValidacion(examen.DictRx, tbRx, pbDictRX);
            comprobarValidacion(examen.DictCar, tbCar, pbDictCar);
        }


        public void llenarCombo(ComboBox cbo, string codigo)
        {
            DataTable combo = SQLConnector.obtenerTablaSegunConsultaString(@"select v.id, (convert(varchar(4),v.codigoInterno) + ' - ' + v.descripcion) as detalle, c.imagen from dbo.Validaciones v
            inner join dbo.Clasificaciones c on v.idClasif = c.id
            where v.codigo = " + codigo);
            cbo.DataSource = combo;
            cbo.ValueMember = "id";
            cbo.DisplayMember = "detalle";
            cbo.SelectedIndex = -1;
        }

        private string filtrarValidacion(object valor)
        {
            if (Convert.ToInt16(valor) != -1)
            {
                return validaciones.Select("id = " + valor.ToString())[0][3].ToString();
            }
            return string.Empty;
        }

        private void comprobarValidacion(int valor, TextBox tbCodigo, PictureBox pb)
        {
            if (valor != -1)
            {
                DataRow[] dr = validaciones.Select("id = " + valor.ToString());
                if (dr.Length > 0)
                {
                    byte[] imageBuffer = (byte[])dr[0][10];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Image = Image.FromStream(ms);
                    tbCodigo.Text = dr[0][2].ToString();
                }
           
            }
            else
            {
                tbCodigo.Text = "00";
                pb.Image = null;
            }
        }


        private void butAceptar_Click(object sender, EventArgs e)
        {
            if (cboDictFinal.SelectedIndex != -1) { guardarValor(); }
            else
            {
                MessageBox.Show("¡Debe seleccionar un dictamen final!",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guardarValor()
        {
            if (cboDictFinal.SelectedIndex != -1)
            {
                Entidades.ExamenPreventiva examen = new Entidades.ExamenPreventiva();
                examen.IdTipoExamen = new Guid(tbId.Text);
                examen.DictFinal = Convert.ToInt16(cboDictFinal.SelectedValue);
                Entidades.Resultado result = preventiva.guardarDictamenFinal(examen);
                if (result.Modo == -1)
                {
                    MessageBox.Show("Error al guardar dictámen final.\nError: " + result.Mensaje, "Error al guardar",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();

            if (blnFrmBusquedaExamen)
                frm.actualizarExamenes();
            if (blnFrmPaciente)
                formPac.cargarExamenes();
        }


        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chequearDictamen()
        {
            DataTable teDictamenAut = SQLConnector.obtenerTablaSegunConsultaString(@"select dictAut from dbo.TipoExamenDePaciente
            where id = '" + row.Cells[0].Value.ToString() + "'");
            if (teDictamenAut.Rows[0].ItemArray[0].ToString() != "1")
            {
                cbDictamen.Checked = true;
                cboDictFinal.Enabled = false;
            }
            else
            {
                cbDictamen.Checked = false;
                cboDictFinal.Enabled = true;
            }
        }

        private void cbDictamen_CheckedChanged(object sender, EventArgs e)
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
            string valor = "";
            cboDictFinal.Enabled = false;
            if (!cbDictamen.Checked)
            {
                valor = "1";
                cboDictFinal.Enabled = true;
            }
    
            SQLConnector.executeProcedure("TipoExamenDePaciente_UpdateDictAut", lista,
                  new Guid(row.Cells[0].Value.ToString()), valor);
        }

        private void botAgregarValidacion_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this.MdiParent, new frmConfigDictamenAutomatico(tbCli.Text,
            //    tbLab.Text, tbRx.Text, tbCar.Text), new Configuracion());

            frmConfigDictamenAutomatico frm = new frmConfigDictamenAutomatico(tbCli.Text,
                tbLab.Text, tbRx.Text, tbCar.Text);
            frm.ShowDialog();
        }

        private void cboDictFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDictFinal.SelectedIndex != -1)
            {
                byte[] imageBuffer = (byte[])(((DataRowView)cboDictFinal.SelectedItem)[2]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                pbDictFinal.SizeMode = PictureBoxSizeMode.StretchImage;
                pbDictFinal.Image = Image.FromStream(ms);
            }
            else
            {
                pbDictFinal.Image = null;
            }
        }
      


 
    }
}
