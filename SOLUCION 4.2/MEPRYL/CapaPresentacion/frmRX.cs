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
    public partial class frmRX : Form
    {
        private CapaNegocioMepryl.ExamenPreventiva preventiva;
        public DataGridViewRow tipoExamen;
        public frmBusquedaExamen formBusqueda;
        public frmPaciente formPac;

        string strCambioObservacion = "";
        string strCambioDictamen = "";

        public frmRX(frmBusquedaExamen frm, DataGridViewRow r)
        {
            InitializeComponent();
            this.Text = "N° Examen: " + r.Cells[3].Value.ToString() + " - Liga: " +
            r.Cells[4].Value.ToString() + " - Club: " + r.Cells[5].Value.ToString()
            + " - Examinado: " + r.Cells[7].Value.ToString() + "  " + r.Cells[8].Value.ToString();
            formBusqueda = frm;
            inicializarExamen(r);
        }

        public frmRX(frmBusquedaExamen frm, DataGridViewRow r, bool PuedeModificar)
        {
            InitializeComponent();
            this.Text = "N° Examen: " + r.Cells[3].Value.ToString() + " - Liga: " +
            r.Cells[4].Value.ToString() + " - Club: " + r.Cells[5].Value.ToString()
            + " - Examinado: " + r.Cells[7].Value.ToString() + "  " + r.Cells[8].Value.ToString();
            formBusqueda = frm;
            inicializarExamen(r);

            ModoPermisos(PuedeModificar);
        }

        public frmRX(frmPaciente frm, DataGridViewRow r)
        {
            InitializeComponent();
            formPac = frm;
            inicializarExamen(r);
            cbo71.SelectedIndex = 0;

        }

        public frmRX(frmPaciente frm, DataGridViewRow r, DataTable ve)
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
            this.ActiveControl = cbo70;
            cbo70.Focus();
        }

        private void cargarEntidad()
        {
            Entidades.ExamenPreventiva entidad = preventiva.cargarExamen(tipoExamen.Cells[0].Value.ToString());
            tbId.Text = entidad.IdTipoExamen.ToString();
            cbo70.SelectedValue = entidad.RxTorax;
            cbo71.SelectedValue = entidad.RxColumna;
            cbo72.SelectedValue = entidad.DictRx;
            tb73.Text = entidad.OtrosRx;
            tb74.Text = entidad.ObsRx;
            if (cbo71.SelectedIndex == -1) { cbo71.SelectedIndex = 0; }

            strCambioObservacion = tb74.Text;
            strCambioDictamen = cbo72.Text;
        }

        private void cargarComboBoxs()
        {
            llenarCombo(cbo70, "70");
            llenarCombo(cbo71, "71");
            llenarCombo(cbo72, "72");
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
                if ((strCambioObservacion != tb74.Text) || (strCambioDictamen != cbo72.Text))
                {
                    formBusqueda.blnExamenModificado = preventiva.GenerarNuevamenteReportes(tbId.Text);
                }
            }
        }

        private void guardar()
        {
            Entidades.Resultado result = preventiva.guardarExRx(llenarEntidad());
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
            if (cbo70.SelectedIndex != -1) { retorno.RxTorax = Convert.ToInt16(cbo70.SelectedValue); }
            if (cbo71.SelectedIndex != -1) { retorno.RxColumna = Convert.ToInt16(cbo71.SelectedValue); }
            if (cbo72.SelectedIndex != -1) { retorno.DictRx = Convert.ToInt16(cbo72.SelectedValue); }
            retorno.OtrosRx = tb73.Text;
            retorno.ObsRx = tb74.Text;
            return retorno;
        }


        private bool validarIngreso()
        {
            if (indexActualValido(cbo72) && indexActualValido(cbo70) &&
                indexActualValido(cbo71)) { return true; }
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

        private void tb73_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb73);
        }

        private void tb74_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb74);
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo70_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo70.SelectedIndex.ToString(), (DataRowView)cbo70.SelectedItem, pb70);
        }

        private void cbo71_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo71.SelectedIndex.ToString(), (DataRowView)cbo71.SelectedItem, pb71);
        }

        private void cbo72_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo72.SelectedIndex.ToString(), (DataRowView)cbo72.SelectedItem, pb72);
        }

        private void frmRX_KeyDown(object sender, KeyEventArgs e)
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
