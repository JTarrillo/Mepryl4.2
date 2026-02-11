using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmExamenCardiologia : Form
    {
        public DataGridViewRow tipoExamen;
        public frmBusquedaExamen formBusqueda;
        public frmPaciente formPac;
        private CapaNegocioMepryl.ExamenPreventiva preventiva;

        int ind = -1;
        int indCar = -1;

        string strCambioObservacion01 = "";
        string strCambioDictamen01 = "";

        public frmExamenCardiologia(frmBusquedaExamen frm, DataGridViewRow r)
        {
            InitializeComponent();
            formBusqueda = frm;
            this.Text = "N° Examen: " + r.Cells[3].Value.ToString() + " - Liga: " +
                      r.Cells[4].Value.ToString() + " - Club: " + r.Cells[5].Value.ToString()
                      + " - Examinado: " + r.Cells[7].Value.ToString() + "  " + r.Cells[8].Value.ToString();
            inicializarExamen(r);
        }

        public frmExamenCardiologia(frmBusquedaExamen frm, DataGridViewRow r, bool PuedeModificar)
        {
            InitializeComponent();
            formBusqueda = frm;
            this.Text = "N° Examen: " + r.Cells[3].Value.ToString() + " - Liga: " +
                      r.Cells[4].Value.ToString() + " - Club: " + r.Cells[5].Value.ToString()
                      + " - Examinado: " + r.Cells[7].Value.ToString() + "  " + r.Cells[8].Value.ToString();
            inicializarExamen(r);

            ModoPermisos(PuedeModificar);
        }

        public frmExamenCardiologia(frmPaciente frm, DataGridViewRow r)
        {
            InitializeComponent();
            formPac = frm;
            inicializarExamen(r);
        }

        public frmExamenCardiologia(frmPaciente frm, DataGridViewRow r, DataTable ve)
        {
            InitializeComponent();
            formPac = frm;
            inicializarExamen(r);

        }

        private void inicializarExamen(DataGridViewRow r)
        {
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            tipoExamen = r;
            cargarComboBoxs();
            cargarEntidad();
        }

        private void cargarEntidad()
        {
            Entidades.ExamenPreventiva entidad = preventiva.cargarExamen(tipoExamen.Cells[0].Value.ToString());
            tbId.Text = entidad.IdTipoExamen.ToString();
            cbo80.SelectedValue = entidad.Ecg;
            cbo81.SelectedValue = entidad.DictCar;
            tb82.Text = entidad.ObsCar;

            strCambioObservacion01 = tb82.Text;
            strCambioDictamen01 = cbo81.Text;
        }

        private void cargarComboBoxs()
        {
            llenarCombo(cbo80, "80");
            llenarCombo(cbo81, "81");
        }

        public void llenarCombo(ComboBox cbo, string codigo)
        {
            DataTable combo = SQLConnector.obtenerTablaSegunConsultaString(@"select v.id, (convert(varchar(4),v.codigoInterno) + ' - ' + v.descripcion) as detalle, c.imagen from dbo.Validaciones v
            inner join dbo.Clasificaciones c on v.idClasif = c.id
            where v.codigo = " + codigo + " order by convert(int,v.codigoInterno) asc");
            cbo.DataSource = combo;
            cbo.ValueMember = "id";
            cbo.DisplayMember = "detalle";
            cbo.SelectedIndex = -1;
        }

        private void cargarIcono(string index, DataRowView row, PictureBox pb)
        {
            if (index != "-1")
            {
                byte[] imageBuffer = (byte[])row.Row[2];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromStream(ms);
            }
            else
            {
                pb.Image = null;
            }
        }


        private void cbo80_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo80.SelectedIndex.ToString(), (DataRowView)cbo80.SelectedItem, pb80);
            indCar = cbo80.SelectedIndex;
        }

        private void cbo81_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo81.SelectedIndex.ToString(), (DataRowView)cbo81.SelectedItem, pb81);
            ind = cbo81.SelectedIndex;
        }



        private void butAceptar_Click(object sender, EventArgs e)
        {
            guardarExamen();
        }

        private void guardarExamen()
        {
            if (validarIngreso())
            {
                guardar();
                this.Close();
                if (formBusqueda != null)
                {
                    ActualizaEstadoReportes();
                    formBusqueda.actualizarExamenes();
                }
                else if (formPac != null)
                {
                    formPac.cargarExamenes();
                }
            }
            else
            {
                MessageBox.Show("¡Faltan ingresar campos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizaEstadoReportes()
        {
            bool blnActualiza = preventiva.ExamenConsolidado(tbId.Text);

            if (blnActualiza)
            {
                if ((strCambioObservacion01 != tb82.Text) || (strCambioDictamen01 != cbo81.Text))
                {
                    formBusqueda.blnExamenModificado = preventiva.GenerarNuevamenteReportes(tbId.Text);
                }
            }
        }

        private bool validarIngreso()
        {
            if (indexActualValido(cbo81)) { return true; }
            return false;
        }

        private bool indexActualValido(ComboBox cb)
        {
            if (cb.SelectedIndex != -1) { return true; }
            return false;
        }



        private void seleccionarTexto(TextBox tb)
        {
            if (tb.Text.Length > 0)
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }

        private void tb82_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb82);
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardar()
        {
            Entidades.Resultado result = preventiva.guardarExCardiologico(llenarEntidad());
            if (result.Modo == -1)
            {
                MessageBox.Show("No se puede guardar el exámen de cardiología.\nError: " + result.Mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Entidades.ExamenPreventiva llenarEntidad()
        {
            Entidades.ExamenPreventiva retorno = new Entidades.ExamenPreventiva();
            retorno.IdTipoExamen = new Guid(tbId.Text);
            if (cbo80.SelectedIndex != -1) { retorno.Ecg = Convert.ToInt16(cbo80.SelectedValue); }
            if (cbo81.SelectedIndex != -1) { retorno.DictCar = Convert.ToInt16(cbo81.SelectedValue); }
            retorno.ObsCar = tb82.Text;          
            return retorno;
        }

        private void frmExamenCardiologia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && butAceptar.Visible)
            {
                butAceptar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && butCancelar.Visible)
            {
                butCancelar.PerformClick();
            }
        }

        private void ModoPermisos(bool blnModifica)
        {
            if (!blnModifica)
            {
                butAceptar.Enabled = false;
            }
        }
    }
}
