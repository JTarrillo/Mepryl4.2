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
        private bool yaInicializado = false;
        private decimal[] _coefs = new decimal[12];

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };

        public frmPreciosPublico(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            precioPublico = new CapaNegocioMepryl.PrecioPublico();
        }

        private void frmPreciosPublico_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvPrecios.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            nudAnio.Value = DateTime.Now.Year;
            cboMesVariacion.SelectedIndex = DateTime.Now.Month; // 0 = Todos, 1-12 = mes
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
            int anio = (int)nudAnio.Value;
            dgvPrecios.Rows.Clear();

            // Cargar coeficientes y mostrarlos en el encabezado de colCoef
            _coefs = ObtenerCoeficientesAnio(anio);
            for (int mes = 1; mes <= 12; mes++)
                dgvPrecios.Columns["colCoef" + mes.ToString("00")].HeaderText =
                    _coefs[mes - 1].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);

            // Filas de datos
            DataTable dt = precioPublico.ListarPreciosPublicoAnio(anio);
            foreach (DataRow row in dt.Rows)
            {
                int idx = dgvPrecios.Rows.Add();
                dgvPrecios.Rows[idx].Cells["colIdEspecialidad"].Value = row["idEspecialidad"].ToString();
                dgvPrecios.Rows[idx].Cells["colMotivo"].Value        = row["Motivo"].ToString();
                dgvPrecios.Rows[idx].Cells["colTipo"].Value          = row["Tipo"].ToString();
                dgvPrecios.Rows[idx].Cells["colDescripcion"].Value   = row["Descripcion"].ToString();

                for (int mes = 1; mes <= 12; mes++)
                {
                    string campo = "Promo" + mes.ToString("00");
                    dgvPrecios.Rows[idx].Cells["col" + campo].Value = Convert.ToDecimal(row[campo]);
                    dgvPrecios.Rows[idx].Cells["colCoef" + mes.ToString("00")].ReadOnly = true;
                }
            }

            // Re-aplicar el filtro actual sin borrar el texto de búsqueda
            txtBuscar_TextChanged(this, EventArgs.Empty);
        }

        private void dgvPrecios_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            string colName = dgvPrecios.Columns[e.ColumnIndex].Name;
            if (!colName.StartsWith("colCoef")) return;
            // Obtener índice de mes (1-12)
            int mes = int.Parse(colName.Substring(7)); // "colCoef01" -> 7
            string actual = _coefs[mes - 1].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Coeficiente para " + NombresMeses[mes - 1] + ":", "Editar coeficiente", actual);
            if (string.IsNullOrWhiteSpace(input)) return;
            decimal v;
            if (!decimal.TryParse(input.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out v)) return;
            _coefs[mes - 1] = v;
            dgvPrecios.Columns[e.ColumnIndex].HeaderText = v.ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
        }

        private decimal[] ObtenerCoeficientesAnio(int anio)
        {
            decimal[] result = new decimal[12];
            for (int i = 0; i < 12; i++) result[i] = 1m;
            DataTable dt = precioPublico.ListarCoeficientesAnio(anio);
            foreach (DataRow row in dt.Rows)
            {
                int mes = Convert.ToInt32(row["Mes"]);
                if (mes >= 1 && mes <= 12)
                    result[mes - 1] = Convert.ToDecimal(row["Coeficiente"]);
            }
            return result;
        }

        private void btnCargar_Click(object sender, EventArgs e) => CargarGrilla();

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            if (yaInicializado) CargarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int anio = (int)nudAnio.Value;

                DataTable dtGuardar = new DataTable();
                dtGuardar.Columns.Add("idEspecialidad", typeof(string));
                dtGuardar.Columns.Add("Descripcion",    typeof(string));
                for (int mes = 1; mes <= 12; mes++)
                    dtGuardar.Columns.Add("Promo" + mes.ToString("00"), typeof(decimal));

                // Guardar coeficientes desde _coefs
                precioPublico.GuardarCoeficientesAnio(anio, _coefs);

                foreach (DataGridViewRow row in dgvPrecios.Rows)
                {
                    if (!row.Visible) continue;
                    DataRow dr = dtGuardar.NewRow();
                    dr["idEspecialidad"] = row.Cells["colIdEspecialidad"].Value?.ToString() ?? "";
                    dr["Descripcion"]    = row.Cells["colDescripcion"].Value?.ToString()    ?? "";
                    for (int mes = 1; mes <= 12; mes++)
                        dr["Promo" + mes.ToString("00")] = ParseDecimal(row.Cells["colPromo" + mes.ToString("00")].Value);
                    dtGuardar.Rows.Add(dr);
                }

                precioPublico.GuardarPreciosPublicoAnio(anio, dtGuardar);
                MessageBox.Show("Precios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopiarAnio_Click(object sender, EventArgs e)
        {
            int anioActual   = (int)nudAnio.Value;
            int anioAnterior = anioActual - 1;

            if (!precioPublico.ExistenPreciosAnio(anioAnterior))
            {
                MessageBox.Show("No existen precios en " + anioAnterior + " para copiar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Se copiarán los precios de " + anioAnterior + " a " + anioActual +
                " (solo prestaciones faltantes por mes).\n¿Continuar?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                for (int mes = 1; mes <= 12; mes++)
                    precioPublico.CopiarPrecios(mes, anioAnterior, mes, anioActual);

                MessageBox.Show("Precios copiados desde " + anioAnterior + ".", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void mnuVariacion_Click(object sender, EventArgs e)
        {
            AplicarVariacionGrilla();
        }

        private void AplicarVariacionGrilla()
        {
            decimal factor = ObtenerFactor();
            if (factor <= 0)
            {
                MessageBox.Show("Ingrese un valor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int    mesIdx    = cboMesVariacion.SelectedIndex; // 0 = Todos, 1-12 = mes
            string alcanceMes = mesIdx == 0 ? "todos los meses" : NombresMeses[mesIdx - 1];

            int seleccionadas = 0;
            foreach (DataGridViewRow r in dgvPrecios.SelectedRows)
                seleccionadas++;
            int totalData = dgvPrecios.Rows.Count;
            string alcance = seleccionadas == 0 || seleccionadas >= totalData
                ? "TODAS las prestaciones"
                : seleccionadas + " prestación(es) seleccionada(s)";

            DialogResult dr = MessageBox.Show(
                "Se aplicará factor " + factor.ToString("0.##") + " a " + alcanceMes + " en " + alcance + ".\n\n" +
                "(Los cambios quedan en la grilla. Presione Guardar para confirmar.)\n¿Continuar?",
                "Confirmar variación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            int totalDataRows = dgvPrecios.Rows.Count;
            if (seleccionadas == 0 || seleccionadas >= totalDataRows)
                foreach (DataGridViewRow row in dgvPrecios.Rows)
                    filas.Add(row);
            else
                foreach (DataGridViewRow row in dgvPrecios.SelectedRows)
                    filas.Add(row);

            int mesInicio = mesIdx == 0 ? 1 : mesIdx;
            int mesFin    = mesIdx == 0 ? 12 : mesIdx;

            foreach (DataGridViewRow row in filas)
            {
                for (int mes = mesInicio; mes <= mesFin; mes++)
                {
                    string colName = "colPromo" + mes.ToString("00");
                    decimal precio = ParseDecimal(row.Cells[colName].Value) * factor;
                    row.Cells[colName].Value = Math.Ceiling(precio / 1000m) * 1000m;
                }
            }

            txtVariacion.Text = "0";
            MessageBox.Show("Variación aplicada a " + alcanceMes + " en " + alcance + ".\nRecuerde presionar Guardar para confirmar.",
                "Variación aplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro   = txtBuscar.Text.Trim().ToLower();
            int    visibles = 0;

            foreach (DataGridViewRow row in dgvPrecios.Rows)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    row.Visible = true;
                    visibles++;
                }
                else
                {
                    string desc   = row.Cells["colDescripcion"].Value?.ToString().ToLower() ?? "";
                    string motivo = row.Cells["colMotivo"].Value?.ToString().ToLower()      ?? "";
                    string tipo   = row.Cells["colTipo"].Value?.ToString().ToLower()        ?? "";
                    row.Visible = desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
                    if (row.Visible) visibles++;
                }
            }

            lblTotal.Text = "Prestaciones: " + visibles;
        }

        private decimal ParseDecimal(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            decimal result;
            return decimal.TryParse(value.ToString(), out result) ? result : 0;
        }

        private decimal ObtenerFactor()
        {
            decimal valor;
            string texto = txtVariacion.Text.Replace(".", ",");
            if (!decimal.TryParse(texto, out valor)) return -1;
            return chkFactor.Checked ? valor : 1 + valor / 100;
        }

        private void chkFactor_CheckedChanged(object sender, EventArgs e)
        {
            decimal valor;
            string texto = txtVariacion.Text.Replace(".", ",");
            if (!decimal.TryParse(texto, out valor)) return;

            if (chkFactor.Checked)
            {
                lblVariacion.Text = "Factor:";
                txtVariacion.Text = (1 + valor / 100).ToString("0.##");
            }
            else
            {
                lblVariacion.Text = "Incremento %:";
                txtVariacion.Text = ((valor - 1) * 100).ToString("0.##");
            }
        }

        private void dgvPrecios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex < 0) return;

            string colName = dgvPrecios.Columns[e.ColumnIndex].Name;
            Color backColor = colName.StartsWith("colCoef") ? Color.FromArgb(180, 0, 0) : Color.SeaGreen;

            using (var brush = new System.Drawing.SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.CellBounds);

            string text = dgvPrecios.Columns[e.ColumnIndex].HeaderText;
            var font = e.CellStyle.Font ?? dgvPrecios.ColumnHeadersDefaultCellStyle.Font;
            TextRenderer.DrawText(e.Graphics, text, font, e.CellBounds, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);

            using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 100, 100)))
            {
                e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }

            e.Handled = true;
        }

        private void dgvPrecios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvPrecios.Columns[e.ColumnIndex].Name;

            if (col == "colMotivo")
            {
                e.CellStyle.BackColor          = Color.FromArgb(230, 245, 235);
                e.CellStyle.ForeColor          = Color.FromArgb(20, 70, 40);
                e.CellStyle.SelectionBackColor = Color.FromArgb(230, 245, 235);
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 70, 40);
            }
            else if (col == "colTipo")
            {
                e.CellStyle.BackColor          = Color.White;
                e.CellStyle.ForeColor          = Color.FromArgb(30, 30, 90);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(30, 30, 90);
            }
            else if (col == "colDescripcion")
            {
                e.CellStyle.BackColor          = Color.White;
                e.CellStyle.ForeColor          = Color.FromArgb(20, 20, 20);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col.StartsWith("colPromo"))
            {
                e.CellStyle.BackColor          = Color.White;
                e.CellStyle.ForeColor          = Color.FromArgb(20, 20, 20);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col.StartsWith("colCoef"))
            {
                e.CellStyle.BackColor          = Color.FromArgb(255, 210, 210);
                e.CellStyle.ForeColor          = Color.FromArgb(140, 0, 0);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 210);
                e.CellStyle.SelectionForeColor = Color.FromArgb(140, 0, 0);
            }
        }
    }
}
