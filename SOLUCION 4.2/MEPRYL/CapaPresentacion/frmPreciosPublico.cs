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

            // Cargar coeficientes y mostrarlos en el encabezado de colCoef
            _coefs = ObtenerCoeficientesAnio(anio);
            for (int mes = 1; mes <= 12; mes++)
                dgvPrecios.Columns["colCoef" + mes.ToString("00")].HeaderText =
                    _coefs[mes - 1].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
            dgvPrecios.Columns["colIPCBase"].HeaderText = _coefs[0].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);

            foreach (DataRow row in dt.Rows)
            {
                int idx = dgvPrecios.Rows.Add();
                dgvPrecios.Rows[idx].Cells["colIdEspecialidad"].Value = row["idEspecialidad"].ToString();
                dgvPrecios.Rows[idx].Cells["colMotivo"].Value        = row["Motivo"].ToString();
                dgvPrecios.Rows[idx].Cells["colTipo"].Value          = row["Tipo"].ToString();
                dgvPrecios.Rows[idx].Cells["colDescripcion"].Value   = row["Descripcion"].ToString();
                
                // Cargar IPC base desde la base de datos (0 = sin valor individual, usa global)
                decimal ipcBase = (row["IPCBase"] == DBNull.Value) ? 0m : Convert.ToDecimal(row["IPCBase"]);
                dgvPrecios.Rows[idx].Cells["colIPCBase"].Value = ipcBase;

                decimal precioLista = Convert.ToDecimal(row["PrecioLista"]);
                decimal precioPromo = Convert.ToDecimal(row["PrecioPromo"]);
                decimal precioBase = Convert.ToDecimal(row["precioBase"]);

                // Si no hay precios cargados, auto-completar Promo desde precioBase
                if (precioLista == 0 && precioPromo == 0 && precioBase > 0)
                {
                    string campo = "Promo" + mes.ToString("00");
                    decimal valorPromo = (row[campo] == DBNull.Value) ? 0 : Convert.ToDecimal(row[campo]);
                    dgvPrecios.Rows[idx].Cells["col" + campo].Value = valorPromo;
                    
                    string campoCoef = "Coef" + mes.ToString("00");
                    decimal coefInd = (row[campoCoef] == DBNull.Value) ? 0m : Convert.ToDecimal(row[campoCoef]);
                    dgvPrecios.Rows[idx].Cells["colCoef" + mes.ToString("00")].Value = coefInd;
                }

                dgvPrecios.Rows[idx].Cells["colPrecioLista"].Value = precioLista;
                dgvPrecios.Rows[idx].Cells["colPrecioPromo"].Value = precioPromo;
            }

            lblTotal.Text = "Prestaciones: " + dt.Rows.Count;
            txtBuscar.Clear();

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
            
            // Guardar el coeficiente modificado en la base de datos inmediatamente
            int anio = (int)nudAnio.Value;
            precioPublico.GuardarCoeficientesAnio(anio, _coefs);
            
            // Aplicar cálculo para el mes correspondiente al coeficiente modificado
            AplicarCalculoCoeficientesSucesivos(mes);
        }

        private void AplicarCalculoCoeficientesSucesivos(int mesModificado)
        {
            try
            {
                // Desactivar eventos para evitar interferencias
                dgvPrecios.CellEndEdit -= dgvPrecios_CellEndEdit;
                
                // colCoef{X} está entre mes X y mes X+1, por eso recalculamos desde X+1
                int mesInicio = mesModificado + 1;
                if (mesInicio > 12) return;
                
                foreach (DataGridViewRow row in dgvPrecios.Rows)
                {
                    if (!row.Visible) continue;
                    
                    // Capturar valores originales para no propagar a meses que estaban en 0
                    decimal[] originalValues = new decimal[13]; // índice 1..12
                    for (int m = mesInicio; m <= 12; m++)
                        originalValues[m] = ParseDecimal(row.Cells["colPromo" + m.ToString("00")].Value);
                    
                    for (int mes = mesInicio; mes <= 12; mes++)
                    {
                        // Para el segundo mes en adelante: si el mes anterior era 0 originalmente, detener cascada
                        if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;
                        
                        string colMesAnterior = "colPromo" + (mes - 1).ToString("00");
                        decimal valorMesAnterior = ParseDecimal(row.Cells[colMesAnterior].Value);
                        
                        string colActual = "colPromo" + mes.ToString("00");
                        
                        // colCoef(mes-1) = coef entre el mes anterior y este mes
                        decimal coeficiente = _coefs[mes - 2];
                        decimal nuevoValor = valorMesAnterior * coeficiente;
                        
                        int colIndex = dgvPrecios.Columns[colActual].Index;
                        row.Cells[colIndex].Value = nuevoValor;
                    }
                }
                
                string mensaje = $"Se han recalculado los precios desde {NombresMeses[mesInicio - 1]} hasta Diciembre aplicando los coeficientes sucesivamente.";
                MessageBox.Show(mensaje, "Cálculo aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                decimal porcentaje = (coeficiente - 1) * 100;
                txtVariacion.Text = porcentaje.ToString("0.##");
            }
        }

        private void AplicarCalculoCoeficientesSucesivosFila(int mesModificado, int rowIndex, bool cascadeSoloConValores = false)
        {
            try
            {
                // Desactivar eventos para evitar interferencias
                dgvPrecios.CellEndEdit -= dgvPrecios_CellEndEdit;
                
                // colCoef{X} está entre mes X y mes X+1, por eso recalculamos desde X+1
                int mesInicio = mesModificado + 1;
                DataGridViewRow filaActual = dgvPrecios.Rows[rowIndex];
                
                // Capturar valores originales para no propagar a meses que estaban en 0
                decimal[] originalValues = new decimal[13]; // índice 1..12
                for (int m = mesInicio; m <= 12; m++)
                    originalValues[m] = ParseDecimal(filaActual.Cells["colPromo" + m.ToString("00")].Value);
                
                for (int mes = mesInicio; mes <= 12; mes++)
                {
                    if (!filaActual.Visible) continue;
                    
                    if (cascadeSoloConValores)
                    {
                        // Editando precio directo: solo actualizar meses que ya tenían valor, nunca llenar ceros
                        if (originalValues[mes] == 0m) continue;
                    }
                    else
                    {
                        // Editando coeficiente: el primer mes siempre se calcula; detener en el siguiente cero
                        if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;
                    }
                    
                    // Valor base: el precio del mes anterior
                    string colMesAnterior = "colPromo" + (mes - 1).ToString("00");
                    decimal valorBase = ParseDecimal(filaActual.Cells[colMesAnterior].Value);
                    
                    string colActual = "colPromo" + mes.ToString("00");
                    
                    // colCoef(mes-1) = coef entre el mes anterior y este mes
                    decimal coeficiente = ParseDecimal(filaActual.Cells["colCoef" + (mes - 1).ToString("00")].Value);
                    if (coeficiente == 0) coeficiente = _coefs[mes - 2];
                    decimal nuevoValor = valorBase * coeficiente;
                    
                    int colIndex = dgvPrecios.Columns[colActual].Index;
                    filaActual.Cells[colIndex].Value = nuevoValor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar cálculo de coeficientes en la fila: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reactivar eventos
                dgvPrecios.CellEndEdit += dgvPrecios_CellEndEdit;
            }
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

        private decimal AplicarFormulaIncremento(decimal valorN4, decimal incrementoPromosFebrero)
        {
            // Implementación de la fórmula: =+N4*Incremento_Promos_Febrero
            return valorN4 * incrementoPromosFebrero;
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
                int mes = cboMes.SelectedIndex + 1;
                int anio = (int)nudAnio.Value;

                DataTable dtGuardar = new DataTable();
                dtGuardar.Columns.Add("idEspecialidad", typeof(string));
                dtGuardar.Columns.Add("Descripcion",    typeof(string));
                dtGuardar.Columns.Add("IPCBase",       typeof(decimal));
                for (int mes = 1; mes <= 12; mes++)
                {
                    dtGuardar.Columns.Add("Promo" + mes.ToString("00"), typeof(decimal));
                    dtGuardar.Columns.Add("Coef"  + mes.ToString("00"), typeof(decimal));
                }

                // Guardar coeficientes globales desde _coefs
                precioPublico.GuardarCoeficientesAnio(anio, _coefs);

                foreach (DataGridViewRow row in dgvPrecios.Rows)
                {
                    if (!row.Visible) continue;

                    DataRow dr = dtGuardar.NewRow();
                    dr["idEspecialidad"] = row.Cells["colIdEspecialidad"].Value?.ToString() ?? "";
                    dr["Descripcion"]    = row.Cells["colDescripcion"].Value?.ToString()    ?? "";
                    dr["IPCBase"]       = ParseDecimal(row.Cells["colIPCBase"].Value);
                    for (int mes = 1; mes <= 12; mes++)
                    {
                        dr["Promo" + mes.ToString("00")] = ParseDecimal(row.Cells["colPromo" + mes.ToString("00")].Value);
                        dr["Coef"  + mes.ToString("00")] = ParseDecimal(row.Cells["colCoef"  + mes.ToString("00")].Value);
                    }
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

            // Filtrar también la pestaña de configuración
            foreach (DataGridViewRow row in dgvConfig.Rows)
            {
                if (string.IsNullOrEmpty(filtro))
                    row.Visible = true;
                else
                {
                    string desc   = row.Cells["colCfgDescripcion"].Value?.ToString().ToLower() ?? "";
                    string motivo = row.Cells["colCfgMotivo"].Value?.ToString().ToLower()      ?? "";
                    string tipo   = row.Cells["colCfgTipo"].Value?.ToString().ToLower()        ?? "";
                    row.Visible = desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
                }
            }
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

        private void dgvPrecios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex < 0) return;

            string colName = dgvPrecios.Columns[e.ColumnIndex].Name;
            Color backColor = (colName.StartsWith("colCoef") || colName == "colIPCBase") ? Color.FromArgb(180, 0, 0) : Color.SeaGreen;

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
            else if (col == "colIPCBase")
            {
                e.CellStyle.BackColor          = Color.FromArgb(240, 240, 240);
                e.CellStyle.ForeColor          = Color.FromArgb(0, 100, 200);
                e.CellStyle.SelectionBackColor = Color.FromArgb(220, 230, 240);
                e.CellStyle.SelectionForeColor = Color.FromArgb(0, 100, 200);
            }
            else if (col.StartsWith("colCoef"))
            {
                e.CellStyle.BackColor          = Color.FromArgb(255, 210, 210);
                e.CellStyle.ForeColor          = Color.FromArgb(140, 0, 0);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 210);
                e.CellStyle.SelectionForeColor = Color.FromArgb(140, 0, 0);
            }
        }

        private void dgvPrecios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string colName = dgvPrecios.Columns[e.ColumnIndex].Name;
            
            // Permitir editar las columnas de precios (colPromo), coeficientes (colCoef) e IPCBase
            if (!colName.StartsWith("colPromo") && !colName.StartsWith("colCoef") && colName != "colIPCBase")
            {
                e.Cancel = true;
                return;
            }
        }

        private void dgvPrecios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvPrecios.Columns[e.ColumnIndex].Name;
            
            if (colName == "colIPCBase")
            {
                // Validar y formatear el valor ingresado para IPCBase
                var cell = dgvPrecios.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                
                // Permitir 0 (sin valor individual); solo rechazar negativos
                if (value < 0) value = 0m;
                
                cell.Value = value;
                
                // Solo recalcular si se definió un valor base individual (>0).
                // Si es 0 significa "usar coeficiente global" → no cascadear desde ENERO 0.
                if (value > 0)
                    AplicarCalculoCoeficientesSucesivosFila(1, e.RowIndex);
            }
            else if (colName.StartsWith("colPromo"))
            {
                // Validar y formatear el valor ingresado
                var cell = dgvPrecios.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                
                // Asegurar que el valor no sea negativo
                if (value < 0) value = 0;
                
                cell.Value = value;
                
                // Solo cascadear si el valor ingresado es > 0.
                // Si es 0 (click sin editar, o borrado) no propagar, para no destruir meses siguientes.
                if (value > 0)
                {
                    int mes = int.Parse(colName.Substring(8)); // "colPromo01" -> 8 para obtener "01"
                    AplicarCalculoCoeficientesSucesivosFila(mes, e.RowIndex, cascadeSoloConValores: true);
                }
            }
            else if (colName.StartsWith("colCoef"))
            {
                // Manejar edición de celdas de coeficiente (individual por fila, no afecta global)
                var cell = dgvPrecios.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                
                // Asegurar que el valor no sea negativo
                if (value < 0) value = 0;
                
                cell.Value = value;
                
                // Recalcular solo esta fila (el coeficiente global _coefs[] no cambia)
                int mes = int.Parse(colName.Substring(7)); // "colCoef01" -> 7 para obtener "01"
                AplicarCalculoCoeficientesSucesivosFila(mes, e.RowIndex);
            }
        }

        private void dgvPrecios_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string colName = dgvPrecios.CurrentCell?.OwningColumn.Name ?? "";
            
            if ((colName.StartsWith("colPromo") || colName.StartsWith("colCoef") || colName == "colIPCBase") && e.Control is TextBox textBox)
            {
                // Remover manejadores anteriores para evitar duplicados
                textBox.KeyPress -= NumericTextBox_KeyPress;
                
                // Agregar manejador para solo aceptar números
                textBox.KeyPress += NumericTextBox_KeyPress;
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir dígitos, backspace, y tecla de borrado
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
