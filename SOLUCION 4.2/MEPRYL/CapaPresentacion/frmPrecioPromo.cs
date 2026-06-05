using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocioMepryl;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmPrecioPromo : DevExpress.XtraEditors.XtraForm
    {
        private PrecioPromo precioPromo;
        private PrecioPublico precioPublico;
        private bool yaInicializado = false;
        private decimal[] _coefs = new decimal[12];

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };

        public frmPrecioPromo(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            precioPromo = new PrecioPromo();
            precioPublico = new PrecioPublico();
        }

        private void frmPrecioPromo_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvPrecios.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn col in dgvPrecioPublico.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            ConfigurarGrillaConfig();
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

        private bool EsPrecioPublico()
        {
            return tabControl.SelectedTab == tabPrecioPublico;
        }

        private DataGridView ObtenerDGVActual()
        {
            return EsPrecioPublico() ? dgvPrecioPublico : dgvPrecios;
        }

        private DataTable ObtenerDatosActual(int anio)
        {
            return EsPrecioPublico() ? precioPublico.ListarPreciosPublicoAnio(anio) : precioPromo.ListarPreciosPublicoAnio(anio);
        }

        private void GuardarDatosActual(int anio, DataTable dtDatos)
        {
            if (EsPrecioPublico())
                precioPublico.GuardarPreciosPublicoAnio(anio, dtDatos);
            else
                precioPromo.GuardarPreciosPublicoAnio(anio, dtDatos);
        }

        private bool ExistenPreciosActual(int anio)
        {
            return EsPrecioPublico() ? precioPublico.ExistenPreciosAnio(anio) : precioPromo.ExistenPreciosAnio(anio);
        }

        private DataTable ObtenerCoeficientesActual(int anio)
        {
            return EsPrecioPublico() ? precioPublico.ListarCoeficientesAnio(anio) : precioPromo.ListarCoeficientesAnio(anio);
        }

        private void GuardarCoeficientesActual(int anio, decimal[] coef)
        {
            if (EsPrecioPublico())
                precioPublico.GuardarCoeficientesAnio(anio, coef);
            else
                precioPromo.GuardarCoeficientesAnio(anio, coef);
        }

        private void CopiarPreciosActual(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            if (EsPrecioPublico())
                precioPublico.CopiarPrecios(mesOrigen, anioOrigen, mesDestino, anioDestino);
            else
                precioPromo.CopiarPrecios(mesOrigen, anioOrigen, mesDestino, anioDestino);
        }

        private void AplicarVariacionActual(int mes, int anio, decimal porcentaje)
        {
            if (EsPrecioPublico())
                precioPublico.AplicarVariacion(mes, anio, porcentaje);
            else
                precioPromo.AplicarVariacion(mes, anio, porcentaje);
        }

        private void CargarGrilla()
        {
            int anio = (int)nudAnio.Value;
            DataGridView dgv = ObtenerDGVActual();

            dgv.Rows.Clear();

            // Cargar coeficientes
            _coefs = new decimal[12];
            for (int i = 0; i < 12; i++) _coefs[i] = 1;
            DataTable dtCoef = ObtenerCoeficientesActual(anio);
            foreach (DataRow row in dtCoef.Rows)
            {
                int mes = Convert.ToInt32(row["Mes"]);
                if (mes >= 1 && mes <= 12)
                    _coefs[mes - 1] = Convert.ToDecimal(row["Coeficiente"]);
            }

            // Cargar datos
            DataTable dt = ObtenerDatosActual(anio);
            foreach (DataRow row in dt.Rows)
            {
                int idx = dgv.Rows.Add();
                dgv.Rows[idx].Cells[0].Value = row["idEspecialidad"].ToString();
                dgv.Rows[idx].Cells[1].Value = row["Motivo"].ToString();
                dgv.Rows[idx].Cells[2].Value = row["Tipo"].ToString();
                dgv.Rows[idx].Cells[3].Value = row["Descripcion"].ToString();

                // Cargar IPC
                decimal ipcBase = (row["IPCBase"] == DBNull.Value) ? 0m : Convert.ToDecimal(row["IPCBase"]);
                dgv.Rows[idx].Cells[4].Value = ipcBase;

                // Cargar precios y coeficientes
                for (int mes = 1; mes <= 12; mes++)
                {
                    string colPromo = "Promo" + mes.ToString("00");
                    string colCoef = "Coef" + mes.ToString("00");
                    decimal valorPromo = (row[colPromo] == DBNull.Value) ? 0 : Convert.ToDecimal(row[colPromo]);
                    decimal coefInd = (row[colCoef] == DBNull.Value) ? 0m : Convert.ToDecimal(row[colCoef]);
                    dgv.Rows[idx].Cells[5 + (mes - 1) * 2].Value = valorPromo;
                    dgv.Rows[idx].Cells[6 + (mes - 1) * 2].Value = coefInd;
                }
            }

            // Actualizar encabezados de coeficientes
            for (int mes = 1; mes <= 12; mes++)
            {
                dgv.Columns[6 + (mes - 1) * 2].HeaderText = _coefs[mes - 1].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
            }
            dgv.Columns[4].HeaderText = _coefs[0].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);

            CargarGrillaConfig();
            txtBuscar_TextChanged(this, EventArgs.Empty);
        }

        private void dgvPrecios_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            string colName = ObtenerDGVActual().Columns[e.ColumnIndex].Name;
            
            if (colName.StartsWith("colCoef"))
            {
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
                ObtenerDGVActual().Columns[e.ColumnIndex].HeaderText = v.ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);

                int anio = (int)nudAnio.Value;
                GuardarCoeficientesActual(anio, _coefs);
                AplicarCalculoCoeficientesSucesivos(mes);
            }
        }

        private void AplicarCalculoCoeficientesSucesivos(int mesModificado)
        {
            try
            {
                DataGridView dgv = ObtenerDGVActual();
                dgv.CellEndEdit -= dgvPrecios_CellEndEdit;

                int mesInicio = mesModificado + 1;
                if (mesInicio > 12) return;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.Visible) continue;

                    decimal[] originalValues = new decimal[13]; // índice 1..12
                    for (int m = mesInicio; m <= 12; m++)
                        originalValues[m] = ParseDecimal(row.Cells[5 + (m - 1) * 2].Value);

                    for (int mes = mesInicio; mes <= 12; mes++)
                    {
                        if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;

                        decimal valorMesAnterior = ParseDecimal(row.Cells[5 + (mes - 2) * 2].Value);
                        decimal coeficiente = _coefs[mes - 2];
                        decimal nuevoValor = valorMesAnterior * coeficiente;
                        row.Cells[5 + (mes - 1) * 2].Value = nuevoValor;
                    }
                }

                string mensaje = $"Se han recalculado los precios desde {NombresMeses[mesInicio - 1]} hasta Diciembre aplicando los coeficientes sucesivos.";
                MessageBox.Show(mensaje, "Cálculo aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar cálculo de coeficientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ObtenerDGVActual().CellEndEdit += dgvPrecios_CellEndEdit;
            }
        }

        private void AplicarCalculoCoeficientesSucesivosFila(int mesModificado, int rowIndex, bool cascadeSoloConValores = false)
        {
            try
            {
                DataGridView dgv = ObtenerDGVActual();
                dgv.CellEndEdit -= dgvPrecios_CellEndEdit;

                int mesInicio = mesModificado + 1;
                DataGridViewRow filaActual = dgv.Rows[rowIndex];

                decimal[] originalValues = new decimal[13]; // índice 1..12
                for (int m = mesInicio; m <= 12; m++)
                    originalValues[m] = ParseDecimal(filaActual.Cells[5 + (m - 1) * 2].Value);

                for (int mes = mesInicio; mes <= 12; mes++)
                {
                    if (!filaActual.Visible) continue;

                    if (cascadeSoloConValores)
                    {
                        if (originalValues[mes] == 0m) continue;
                    }
                    else
                    {
                        if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;
                    }

                    decimal valorBase = ParseDecimal(filaActual.Cells[5 + (mes - 2) * 2].Value);
                    decimal coeficiente = ParseDecimal(filaActual.Cells[6 + (mes - 2) * 2].Value);
                    if (coeficiente == 0) coeficiente = _coefs[mes - 2];
                    decimal nuevoValor = valorBase * coeficiente;
                    filaActual.Cells[5 + (mes - 1) * 2].Value = nuevoValor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar cálculo de coeficientes en la fila: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ObtenerDGVActual().CellEndEdit += dgvPrecios_CellEndEdit;
            }
        }

        private decimal[] ObtenerCoeficientesAnio(int anio)
        {
            decimal[] result = new decimal[12];
            for (int i = 0; i < 12; i++) result[i] = 1;
            DataTable dt = ObtenerCoeficientesActual(anio);
            foreach (DataRow row in dt.Rows)
            {
                int mes = Convert.ToInt32(row["Mes"]);
                if (mes >= 1 && mes <= 12)
                    result[mes - 1] = Convert.ToDecimal(row["Coeficiente"]);
            }
            return result;
        }

        private decimal AplicarFormulaIncremento(decimal valorN4, decimal incrementoPromosFebrero)
        {
            return valorN4 * incrementoPromosFebrero;
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            if (yaInicializado) CargarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int anio = (int)nudAnio.Value;
                DataGridView dgv = ObtenerDGVActual();

                DataTable dtGuardar = new DataTable();
                dtGuardar.Columns.Add("idEspecialidad", typeof(string));
                dtGuardar.Columns.Add("Descripcion", typeof(string));
                dtGuardar.Columns.Add("IPCBase", typeof(decimal));
                for (int mes = 1; mes <= 12; mes++)
                {
                    dtGuardar.Columns.Add("Promo" + mes.ToString("00"), typeof(decimal));
                    dtGuardar.Columns.Add("Coef" + mes.ToString("00"), typeof(decimal));
                }

                GuardarCoeficientesActual(anio, _coefs);

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.Visible) continue;
                    DataRow dr = dtGuardar.NewRow();
                    dr["idEspecialidad"] = row.Cells[0].Value?.ToString() ?? "";
                    dr["Descripcion"] = row.Cells[3].Value?.ToString() ?? "";
                    dr["IPCBase"] = ParseDecimal(row.Cells[4].Value);
                    for (int mes = 1; mes <= 12; mes++)
                    {
                        dr["Promo" + mes.ToString("00")] = ParseDecimal(row.Cells[5 + (mes - 1) * 2].Value);
                        dr["Coef" + mes.ToString("00")] = ParseDecimal(row.Cells[6 + (mes - 1) * 2].Value);
                    }
                    dtGuardar.Rows.Add(dr);
                }

                GuardarDatosActual(anio, dtGuardar);
                GuardarConfig();
                MessageBox.Show("Precios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopiarAnio_Click(object sender, EventArgs e)
        {
            int anioActual = (int)nudAnio.Value;
            int anioAnterior = anioActual - 1;

            if (!ExistenPreciosActual(anioAnterior))
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
                    CopiarPreciosActual(mes, anioAnterior, mes, anioActual);

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

            int mesIdx = cboMesVariacion.SelectedIndex; // 0 = Todos, 1-12 = mes
            string alcanceMes = mesIdx == 0 ? "todos los meses" : NombresMeses[mesIdx - 1];

            DataGridView dgv = ObtenerDGVActual();
            int seleccionadas = 0;
            foreach (DataGridViewRow r in dgv.SelectedRows)
                seleccionadas++;
            int totalData = dgv.Rows.Count;
            string alcance = seleccionadas == 0 || seleccionadas >= totalData
                ? "TODAS las prestaciones"
                : seleccionadas + " prestación(es) seleccionada(s)";

            DialogResult dr = MessageBox.Show(
                "Se aplicará factor " + factor.ToString("0.##") + " a " + alcanceMes + " en " + alcance + ".\n\n" +
                "(Los cambios quedan en la grilla. Presione Guardar para confirmar.)\n¿Continuar?",
                "Confirmar variación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            if (seleccionadas == 0 || seleccionadas >= totalData)
                foreach (DataGridViewRow row in dgv.Rows)
                    filas.Add(row);
            else
                foreach (DataGridViewRow row in dgv.SelectedRows)
                    filas.Add(row);

            int mesInicio = mesIdx == 0 ? 1 : mesIdx;
            int mesFin = mesIdx == 0 ? 12 : mesIdx;

            foreach (DataGridViewRow row in filas)
            {
                for (int mes = mesInicio; mes <= mesFin; mes++)
                {
                    int colIdx = 5 + (mes - 1) * 2;
                    decimal precio = ParseDecimal(row.Cells[colIdx].Value) * factor;
                    row.Cells[colIdx].Value = Math.Ceiling(precio / 1000m) * 1000m;
                }
            }

            txtVariacion.Text = "0";
            MessageBox.Show("Variación aplicada a " + alcanceMes + " en " + alcance + ".\nRecuerde presionar Guardar para confirmar.",
                "Variación aplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            int visibles = 0;
            DataGridView dgv = ObtenerDGVActual();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    row.Visible = true;
                    visibles++;
                }
                else
                {
                    string desc = row.Cells[3].Value?.ToString().ToLower() ?? "";
                    string motivo = row.Cells[1].Value?.ToString().ToLower() ?? "";
                    string tipo = row.Cells[2].Value?.ToString().ToLower() ?? "";
                    row.Visible = desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
                    if (row.Visible) visibles++;
                }
            }

            lblTotal.Text = "Prestaciones: " + visibles;

            // Filtrar también la pestaña de configuración
            foreach (DataGridViewRow row in dgvConfig.Rows)
            {
                if (string.IsNullOrEmpty(filtro))
                    row.Visible = true;
                else
                {
                    string desc = row.Cells[3].Value?.ToString().ToLower() ?? "";
                    string motivo = row.Cells[1].Value?.ToString().ToLower() ?? "";
                    string tipo = row.Cells[2].Value?.ToString().ToLower() ?? "";
                    row.Visible = desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
                }
            }
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

            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            Color backColor = (colName.StartsWith("colCoef") || colName == "colIPCBase") ? Color.FromArgb(180, 0, 0) : Color.SeaGreen;

            using (var brush = new System.Drawing.SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.CellBounds);

            string text = dgv.Columns[e.ColumnIndex].HeaderText;
            var font = e.CellStyle.Font ?? dgv.ColumnHeadersDefaultCellStyle.Font;
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
            DataGridView dgv = (DataGridView)sender;
            string col = dgv.Columns[e.ColumnIndex].Name;

            if (col.Contains("Motivo") || (col.StartsWith("col") && col.Contains("Motivo")))
            {
                e.CellStyle.BackColor = Color.FromArgb(230, 245, 235);
                e.CellStyle.ForeColor = Color.FromArgb(20, 70, 40);
                e.CellStyle.SelectionBackColor = Color.FromArgb(230, 245, 235);
                e.CellStyle.SelectionForeColor = Color.Black;
            }
            else if (col.Contains("Tipo") || (col.StartsWith("col") && col.Contains("Tipo")))
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(30, 30, 90);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(30, 30, 90);
            }
            else if (col.Contains("Descripcion") || (col.StartsWith("col") && col.Contains("Descripcion")))
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(20, 20, 20);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col.Contains("Promo") || (col.StartsWith("col") && col.Contains("Promo")))
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(20, 20, 20);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col == "colIPCBase" || col == "colPublicoIPCBase")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 240, 240);
                e.CellStyle.ForeColor = Color.FromArgb(0, 100, 200);
                e.CellStyle.SelectionBackColor = Color.FromArgb(220, 230, 240);
                e.CellStyle.SelectionForeColor = Color.FromArgb(0, 100, 200);
            }
            else if (col.StartsWith("colCoef"))
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 210, 210);
                e.CellStyle.ForeColor = Color.FromArgb(140, 0, 0);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 210);
                e.CellStyle.SelectionForeColor = Color.FromArgb(140, 0, 0);
            }
        }

        private void dgvPrecios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;

            // Permitir editar las columnas de precios (colPromo), coeficientes (colCoef) e IPCBase
            if (!colName.Contains("Promo") && !colName.Contains("Coef") && !colName.Contains("IPCBase"))
            {
                e.Cancel = true;
                return;
            }
        }

        private void dgvPrecios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;

            if (colName.Contains("IPCBase"))
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                if (value < 0) value = 0m;
                cell.Value = value;
                if (value > 0)
                    AplicarCalculoCoeficientesSucesivosFila(1, e.RowIndex);
            }
            else if (colName.Contains("Promo"))
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                if (value < 0) value = 0;
                cell.Value = value;
                if (value > 0)
                {
                    int mes = int.Parse(colName.Substring(colName.IndexOf("Promo") + 5));
                    AplicarCalculoCoeficientesSucesivosFila(mes, e.RowIndex, cascadeSoloConValores: true);
                }
            }
            else if (colName.Contains("Coef"))
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                if (value < 0) value = 0;
                cell.Value = value;
                int mes = int.Parse(colName.Substring(colName.IndexOf("Coef") + 4));
                AplicarCalculoCoeficientesSucesivosFila(mes, e.RowIndex);
            }
        }

        private void dgvPrecios_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.CurrentCell?.OwningColumn.Name ?? "";

            if ((colName.Contains("Promo") || colName.Contains("Coef") || colName.Contains("IPCBase")) && e.Control is TextBox textBox)
            {
                textBox.KeyPress -= NumericTextBox_KeyPress;
                textBox.KeyPress += NumericTextBox_KeyPress;
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ConfigurarGrillaConfig()
        {
            foreach (DataGridViewColumn col in dgvConfig.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvConfig.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 140);
            dgvConfig.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvConfig.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConfig.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void CargarGrillaConfig()
        {
            dgvConfig.Rows.Clear();
            DataTable dt = precioPromo.ListarConfigEspecialidades();
            if (dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                int idx = dgvConfig.Rows.Add();
                dgvConfig.Rows[idx].Cells[0].Value = row["idEspecialidad"].ToString();
                dgvConfig.Rows[idx].Cells[1].Value = row["Motivo"].ToString();
                dgvConfig.Rows[idx].Cells[2].Value = row["Tipo"].ToString();
                dgvConfig.Rows[idx].Cells[3].Value = row["Descripcion"].ToString();
                dgvConfig.Rows[idx].Cells[4].Value = Convert.ToDecimal(row["Seña"]);
                dgvConfig.Rows[idx].Cells[5].Value = Convert.ToBoolean(row["LlevaPlanilla"]);
                dgvConfig.Rows[idx].Cells[6].Value = row["Observaciones"].ToString();
            }
        }

        private void GuardarConfig()
        {
            DataTable dtConfig = new DataTable();
            dtConfig.Columns.Add("idEspecialidad", typeof(string));
            dtConfig.Columns.Add("Seña", typeof(decimal));
            dtConfig.Columns.Add("LlevaPlanilla", typeof(bool));
            dtConfig.Columns.Add("Observaciones", typeof(string));

            foreach (DataGridViewRow row in dgvConfig.Rows)
            {
                DataRow dr = dtConfig.NewRow();
                dr["idEspecialidad"] = row.Cells[0].Value?.ToString() ?? "";
                decimal seña = ParseDecimal(row.Cells[4].Value);
                dr["Seña"] = seña;
                dr["LlevaPlanilla"] = (row.Cells[5].Value as bool?) ?? false;
                dr["Observaciones"] = row.Cells[6].Value?.ToString() ?? "";
                dtConfig.Rows.Add(dr);
            }
            precioPromo.GuardarConfigEspecialidades(dtConfig);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yaInicializado)
                CargarGrilla();
        }
    }
}
