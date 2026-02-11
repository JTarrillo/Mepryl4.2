using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigDictamenAutomatico : DevExpress.XtraEditors.XtraForm
    {
        private bool modo;
        private bool cierre = false;
        public frmConfigDictamenAutomatico()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            llenarCombo(cboClinico, "22");
            llenarCombo(cboLaboratorio, "60");
            llenarCombo(cboRX, "72");
            llenarCombo(cboCar, "81");
            llenarCombo(cboDictFinal, "90");
            cargarTabla();
            modo = false; //para agregar nuevo registro
        }

        public frmConfigDictamenAutomatico(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            llenarCombo(cboClinico, "22");
            llenarCombo(cboLaboratorio, "60");
            llenarCombo(cboRX, "72");
            llenarCombo(cboCar, "81");
            llenarCombo(cboDictFinal, "90");
            cargarTabla();
            modo = false; //para agregar nuevo registro
        }

        public frmConfigDictamenAutomatico(string cli, string lab, string rx, string car)
        {
            InitializeComponent();
            llenarCombo(cboClinico, "22");
            llenarCombo(cboLaboratorio, "60");
            llenarCombo(cboRX, "72");
            llenarCombo(cboCar, "81");
            llenarCombo(cboDictFinal, "90");
            cargarTabla();
            modo = false; //para agregar nuevo registro
            cboClinico.SelectedValue = cli;
            cboLaboratorio.SelectedValue = lab;
            cboRX.SelectedValue = rx;
            cboCar.SelectedValue = car;
            cierre = true;
            this.ActiveControl = cboDictFinal;

            btnValidaciones.Enabled = false;
            btnDictamen.Enabled = false;
            btnRX.Enabled = false;
            botSalir.Visible = true;
        }

        public void llenarCombo(ComboBox cbo, string codigo)
        {
            DataTable combo = SQLConnector.obtenerTablaSegunConsultaString(@"select v.id, (convert(varchar(4),v.codigoInterno) + ' - ' + v.descripcion) as detalle, c.imagen, 
            v.codigoInterno from dbo.Validaciones v
            inner join dbo.Clasificaciones c on v.idClasif = c.id
            where v.codigo = " + codigo + " order by v.codigo asc");
            cbo.DataSource = combo;
            cbo.ValueMember = "codigoInterno";
            cbo.DisplayMember = "detalle";
            cbo.SelectedIndex = -1;
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (cboDictFinal.SelectedIndex != -1)
            {
                guardar();
            }
            else
            {
                MessageBox.Show("¡Faltan ingresar campos!", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guardar()
        {
            string clinico = obtenerCodigoInterno(cboClinico);
            string laboratorio = obtenerCodigoInterno(cboLaboratorio);
            string rx = obtenerCodigoInterno(cboRX);
            string car = obtenerCodigoInterno(cboCar);
            string final = obtenerCodigoInterno(cboDictFinal);
            if (!modo)
            {
                if (!existeCombinacion(clinico, laboratorio, rx, car, final))
                {
                    List<string> lista = SQLConnector.generarListaParaProcedure("@fis", "@lab", "@rx", "@car", "@fin");
                    SQLConnector.executeProcedure("sp_ValidacionesDictamen_Add", lista, clinico, laboratorio, rx, car, final);
                    MessageBox.Show("¡Guardado correctamente!", "Guardar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarFormulario();
                    cargarTabla();
                    if (dgv.Rows.Count > 0) { dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[2]; }
                    if (cierre) { this.Close(); }
                }
                else
                {
                    MessageBox.Show("¡Esa combinación ya fue ingresada previamente!", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                List<string> lista = SQLConnector.generarListaParaProcedure("@id","@fis", "@lab", "@rx", "@car", "@fin");
                SQLConnector.executeProcedure("sp_ValidacionesDictamen_Update", lista, new Guid(dgv.CurrentRow.Cells[0].Value.ToString()),clinico, laboratorio, rx, car, final);
                MessageBox.Show("¡Editado correctamente!", "Editar",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarFormulario();
                cargarTabla();
            }
        }

        private string obtenerCodigoInterno(ComboBox cbo)
        {
            string retorno = "00";
            if (cbo.SelectedIndex != -1)
            {
                DataRowView items = (DataRowView)cbo.SelectedItem;
                retorno = items[3].ToString();
            }
            return retorno;

        }

        private bool existeCombinacion(string cli, string lab, string rx, string car, string final)
        {
            DataTable combinacion = SQLConnector.obtenerTablaSegunConsultaString(@"Select * from
            dbo.ValidacionesDictamen where fisico = '" + cli + "' and laboratorio = '" + lab +
            "' and rx = '" + rx + "' and car = '" + car + "'");
            if (combinacion.Rows.Count > 0) { return true; }
            return false;
        }

        private void limpiarFormulario()
        {
            cboClinico.SelectedIndex = -1;
            cboLaboratorio.SelectedIndex = -1;
            cboRX.SelectedIndex = -1;
            cboCar.SelectedIndex = -1;
            cboDictFinal.SelectedIndex = -1;
            modo = false;
        }

        private void cargarTabla()
        {
            if (dgv.Rows.Count > 0) { dgv.Rows.Clear(); }
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, fisico as Clinico,
            laboratorio as Laboratorio, rx as RX, car as Cardiología, final as Final from dbo.ValidacionesDictamen");
            foreach (DataRow row in tabla.Rows)
            {
                string descripCli = consultarDescripcion(row.ItemArray[1].ToString(), "22");
                string descripLab = consultarDescripcion(row.ItemArray[2].ToString(), "60");
                string descripRx = consultarDescripcion(row.ItemArray[3].ToString(), "72");
                string descripCar = consultarDescripcion(row.ItemArray[4].ToString(), "81");
                string descripFinal = consultarDescripcion(row.ItemArray[5].ToString(), "90");
                dgv.Rows.Add(row.ItemArray[0], row.ItemArray[1], descripCli, row.ItemArray[2], descripLab,
                    row.ItemArray[3], descripRx, row.ItemArray[4], descripCar, row.ItemArray[5], descripFinal);

            }
          
        }

        private string consultarDescripcion(string codigoInterno, string codigoValidacion)
        {
            DataTable validacion = SQLConnector.obtenerTablaSegunConsultaString(@"Select (codigoInterno + '-' + descripcion) from dbo.Validaciones
             where codigo = " + codigoValidacion + " and codigoInterno = " + codigoInterno);
            if (validacion.Rows.Count > 0)
            {
                return validacion.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                return "";
            }
        }

        private void botSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botEditar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.Index != -1)
            {
                modo = true;
                if (dgv.CurrentRow.Cells[1].Value.ToString() != "")
                {
                    cboClinico.SelectedValue = dgv.CurrentRow.Cells[1].Value.ToString();
                }
                else
                {
                    cboClinico.SelectedIndex = -1;
                }

                if (dgv.CurrentRow.Cells[3].Value.ToString() != "")
                {
                    cboLaboratorio.SelectedValue = dgv.CurrentRow.Cells[3].Value.ToString();
                }
                else
                {
                    cboLaboratorio.SelectedIndex = -1;
                }

                if (dgv.CurrentRow.Cells[5].Value.ToString() != "")
                {
                    cboRX.SelectedValue = dgv.CurrentRow.Cells[5].Value.ToString();
                }
                else
                {
                    cboRX.SelectedIndex = -1;
                }

                if (dgv.CurrentRow.Cells[7].Value.ToString() != "")
                {
                    cboCar.SelectedValue = dgv.CurrentRow.Cells[7].Value.ToString();
                }
                else
                {
                    cboCar.SelectedIndex = -1;
                }

                if (dgv.CurrentRow.Cells[9].Value.ToString() != "")
                {
                    cboDictFinal.SelectedValue = dgv.CurrentRow.Cells[9].Value.ToString();
                }
                else
                {
                    cboDictFinal.SelectedIndex = -1;
                }

            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.Index != -1)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que quiere eliminar la combinación?", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    List<string> lista = SQLConnector.generarListaParaProcedure("@id");
                    SQLConnector.executeProcedure("sp_ValidacionesDictamen_Delete", lista, new Guid(dgv.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("¡Combinacion eliminada correctamente!", "Eliminar",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarTabla();
                    limpiarFormulario();

                }

            }
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            frmValidacionesExamen frm = new frmValidacionesExamen();
            frm.ShowDialog();
        }

        private void btnDictamen_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigDictamenAutomatico(), new Configuracion());
        }

        private void btnRX_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfiguracionExamenRX2(), new Configuracion());
        }
    }
}
