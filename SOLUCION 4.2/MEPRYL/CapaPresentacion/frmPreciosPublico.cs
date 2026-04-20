using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmPreciosPublico : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.PrecioPublico precioPublico;
        private DataTable dtOriginal;
        private bool yaInicializado = false;

        public frmPreciosPublico(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            precioPublico = new CapaNegocioMepryl.PrecioPublico();
        }

        private void frmPreciosPublico_Load(object sender, EventArgs e)
        {
            cboMes.SelectedIndex = DateTime.Now.Month - 1;
            nudAnio.Value = DateTime.Now.Year;
            CargarGrilla();
            yaInicializado = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (yaInicializado)
                CargarGrilla();
        }

        private void CargarGrilla()
        {
            int mes = cboMes.SelectedIndex + 1;
            int anio = (int)nudAnio.Value;

            dgvPrecios.Rows.Clear();

            DataTable dt = precioPublico.ListarPreciosPublico(mes, anio);
            dtOriginal = dt.Copy();

            foreach (DataRow row in dt.Rows)
            {
                int idx = dgvPrecios.Rows.Add();
                dgvPrecios.Rows[idx].Cells["colIdEspecialidad"].Value = row["idEspecialidad"].ToString();
                dgvPrecios.Rows[idx].Cells["colMotivo"].Value = row["Motivo"].ToString();
                dgvPrecios.Rows[idx].Cells["colTipo"].Value = row["Tipo"].ToString();
                dgvPrecios.Rows[idx].Cells["colDescripcion"].Value = row["Descripcion"].ToString();

                decimal precioLista = Convert.ToDecimal(row["PrecioLista"]);
                decimal precioPromo = Convert.ToDecimal(row["PrecioPromo"]);
                decimal precioBase = Convert.ToDecimal(row["precioBase"]);

                // Si no hay precios cargados, auto-completar Promo desde precioBase
                if (precioLista == 0 && precioPromo == 0 && precioBase > 0)
                {
                    precioPromo = precioBase;
                }

                dgvPrecios.Rows[idx].Cells["colPrecioLista"].Value = precioLista;
                dgvPrecios.Rows[idx].Cells["colPrecioPromo"].Value = precioPromo;
            }

            lblTotal.Text = "Prestaciones: " + dt.Rows.Count;
            txtBuscar.Clear();

            // Cargar coeficiente guardado para este mes/año
            decimal coeficiente = precioPublico.ObtenerCoeficiente(mes, anio);
            if (chkFactor.Checked)
            {
                txtVariacion.Text = coeficiente.ToString("0.##");
            }
            else
            {
                decimal porcentaje = (coeficiente - 1) * 100;
                txtVariacion.Text = porcentaje.ToString("0.##");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int mes = cboMes.SelectedIndex + 1;
                int anio = (int)nudAnio.Value;

                DataTable dtGuardar = new DataTable();
                dtGuardar.Columns.Add("idEspecialidad", typeof(string));
                dtGuardar.Columns.Add("Descripcion", typeof(string));
                dtGuardar.Columns.Add("PrecioLista", typeof(decimal));
                dtGuardar.Columns.Add("PrecioPromo", typeof(decimal));

                foreach (DataGridViewRow row in dgvPrecios.Rows)
                {
                    if (!row.Visible) continue;

                    DataRow dr = dtGuardar.NewRow();
                    dr["idEspecialidad"] = row.Cells["colIdEspecialidad"].Value?.ToString() ?? "";
                    dr["Descripcion"] = row.Cells["colDescripcion"].Value?.ToString() ?? "";
                    dr["PrecioLista"] = ParseDecimal(row.Cells["colPrecioLista"].Value);
                    dr["PrecioPromo"] = ParseDecimal(row.Cells["colPrecioPromo"].Value);
                    dtGuardar.Rows.Add(dr);
                }

                precioPublico.GuardarPreciosPublico(mes, anio, dtGuardar);
                MessageBox.Show("Precios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopiarMes_Click(object sender, EventArgs e)
        {
            int mesActual = cboMes.SelectedIndex + 1;
            int anioActual = (int)nudAnio.Value;

            int mesAnterior = mesActual - 1;
            int anioAnterior = anioActual;
            if (mesAnterior < 1)
            {
                mesAnterior = 12;
                anioAnterior--;
            }

            string nombreMesAnterior = cboMes.Items[mesAnterior - 1].ToString();
            string nombreMesActual = cboMes.Items[mesActual - 1].ToString();

            if (!precioPublico.ExistenPrecios(mesAnterior, anioAnterior))
            {
                MessageBox.Show("No existen precios en " + nombreMesAnterior + " " + anioAnterior + " para copiar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (precioPublico.ExistenPrecios(mesActual, anioActual))
            {
                DialogResult dr = MessageBox.Show(
                    "Ya existen precios en " + nombreMesActual + " " + anioActual + ". Se copiarán solo las prestaciones faltantes.\n¿Continuar?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;
            }

            try
            {
                precioPublico.CopiarPrecios(mesAnterior, anioAnterior, mesActual, anioActual);
                MessageBox.Show("Precios copiados desde " + nombreMesAnterior + " " + anioAnterior + ".",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al copiar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            mnuAplicar.Show(btnAplicar, 0, btnAplicar.Height);
        }

        private void btnVariacion_Click(object sender, EventArgs e)
        {
            AplicarVariacionGrilla(true, true, "ambos precios");
        }

        private void btnVariacionPromo_Click(object sender, EventArgs e)
        {
            AplicarVariacionGrilla(false, true, "Precio Promo");
        }

        private void btnVariacionLista_Click(object sender, EventArgs e)
        {
            AplicarVariacionGrilla(true, false, "Precio Lista");
        }

        private void AplicarVariacionGrilla(bool aplicarLista, bool aplicarPromo, string descripcion)
        {
            decimal factor = ObtenerFactor();
            if (factor <= 0)
            {
                MessageBox.Show("Ingrese un valor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int seleccionadas = dgvPrecios.SelectedRows.Count;
            bool todasSeleccionadas = seleccionadas == dgvPrecios.Rows.Count;

            string alcance = todasSeleccionadas || seleccionadas == 0
                ? "TODAS las prestaciones"
                : seleccionadas + " prestación(es) seleccionada(s)";

            DialogResult dr = MessageBox.Show(
                "Se aplicará variación (factor " + factor.ToString("0.##") + ") a " + descripcion + " en " + alcance + ".\n\n(Los cambios quedan en la grilla. Presione Guardar para confirmar.)\n¿Continuar?",
                "Confirmar variación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            List<DataGridViewRow> filasAplicar = new List<DataGridViewRow>();
            if (todasSeleccionadas || seleccionadas == 0)
            {
                foreach (DataGridViewRow row in dgvPrecios.Rows)
                    filasAplicar.Add(row);
            }
            else
            {
                foreach (DataGridViewRow row in dgvPrecios.SelectedRows)
                    filasAplicar.Add(row);
            }

            foreach (DataGridViewRow row in filasAplicar)
            {
                if (aplicarLista)
                {
                    decimal lista = ParseDecimal(row.Cells["colPrecioLista"].Value) * factor;
                    row.Cells["colPrecioLista"].Value = Math.Ceiling(lista / 1000m) * 1000m;
                }
                if (aplicarPromo)
                {
                    decimal promo = ParseDecimal(row.Cells["colPrecioPromo"].Value) * factor;
                    row.Cells["colPrecioPromo"].Value = Math.Ceiling(promo / 1000m) * 1000m;
                }
            }

            txtVariacion.Text = "0";
            MessageBox.Show("Variación aplicada a " + descripcion + " en " + alcance + ".\nRecuerde presionar Guardar para confirmar los cambios.",
                "Variación aplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCalcularLista_Click(object sender, EventArgs e)
        {
            decimal factor = ObtenerFactor();
            if (factor <= 0)
            {
                MessageBox.Show("Ingrese un valor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int seleccionadas = dgvPrecios.SelectedRows.Count;
            bool todasSeleccionadas = seleccionadas == dgvPrecios.Rows.Count;

            string alcance = todasSeleccionadas || seleccionadas == 0
                ? "TODAS las prestaciones"
                : seleccionadas + " prestación(es) seleccionada(s)";

            DialogResult dr = MessageBox.Show(
                "Se calculará Precio Lista = Redondear(Precio Promo × " + factor.ToString("0.##") + ") al millar en " + alcance + ".\n\n(Los cambios quedan en la grilla. Presione Guardar para confirmar.)\n¿Continuar?",
                "Calcular Lista desde Promo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            List<DataGridViewRow> filasAplicar = new List<DataGridViewRow>();
            if (todasSeleccionadas || seleccionadas == 0)
            {
                foreach (DataGridViewRow row in dgvPrecios.Rows)
                    filasAplicar.Add(row);
            }
            else
            {
                foreach (DataGridViewRow row in dgvPrecios.SelectedRows)
                    filasAplicar.Add(row);
            }

            foreach (DataGridViewRow row in filasAplicar)
            {
                decimal promo = ParseDecimal(row.Cells["colPrecioPromo"].Value);
                if (promo > 0)
                {
                    decimal lista = Math.Ceiling(promo * factor / 1000m) * 1000m;
                    row.Cells["colPrecioLista"].Value = lista;
                }
            }

            // Guardar el coeficiente para este mes/año
            int mes = cboMes.SelectedIndex + 1;
            int anio = (int)nudAnio.Value;
            precioPublico.GuardarCoeficiente(mes, anio, factor);

            txtVariacion.Text = "0";
            MessageBox.Show("Precio Lista calculado en " + alcance + " (factor " + factor.ToString("0.##") + ").\nRecuerde presionar Guardar para confirmar los cambios.",
                "Cálculo aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            int visibles = 0;

            foreach (DataGridViewRow row in dgvPrecios.Rows)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    row.Visible = true;
                    visibles++;
                }
                else
                {
                    string desc = row.Cells["colDescripcion"].Value?.ToString().ToLower() ?? "";
                    string motivo = row.Cells["colMotivo"].Value?.ToString().ToLower() ?? "";
                    string tipo = row.Cells["colTipo"].Value?.ToString().ToLower() ?? "";
                    row.Visible = desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
                    if (row.Visible) visibles++;
                }
            }

            lblTotal.Text = "Prestaciones: " + visibles;
        }

        private void dgvPrecios_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == colPrecioLista.Index || e.ColumnIndex == colPrecioPromo.Index)
            {
                if (e.Value != null)
                {
                    decimal result;
                    if (decimal.TryParse(e.Value.ToString(), out result))
                    {
                        e.Value = result;
                        e.ParsingApplied = true;
                    }
                }
            }
        }

        private decimal ParseDecimal(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            decimal result;
            if (decimal.TryParse(value.ToString(), out result))
                return result;
            return 0;
        }

        private decimal ObtenerFactor()
        {
            decimal valor;
            string texto = txtVariacion.Text.Replace(".", ",");
            if (!decimal.TryParse(texto, out valor))
                return -1;

            if (chkFactor.Checked)
                return valor;
            else
                return 1 + valor / 100;
        }

        private void chkFactor_CheckedChanged(object sender, EventArgs e)
        {
            decimal valor;
            string texto = txtVariacion.Text.Replace(".", ",");
            if (!decimal.TryParse(texto, out valor)) return;

            if (chkFactor.Checked)
            {
                lblVariacion.Text = "Factor:";
                // Convertir porcentaje a factor
                txtVariacion.Text = (1 + valor / 100).ToString("0.##");
            }
            else
            {
                lblVariacion.Text = "Incremento %:";
                // Convertir factor a porcentaje
                txtVariacion.Text = ((valor - 1) * 100).ToString("0.##");
            }
        }
    }
}
