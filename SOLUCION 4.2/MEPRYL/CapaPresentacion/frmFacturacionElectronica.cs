using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmFacturacionElectronica : DevExpress.XtraEditors.XtraForm
    {
        private readonly CapaNegocioMepryl.FacturacionElectronica _negocio;

        private string _ultimoPdfUrl = null;

        public frmFacturacionElectronica()
        {
            InitializeComponent();
            _negocio = new CapaNegocioMepryl.FacturacionElectronica();
        }

        private void frmFacturacionElectronica_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            rbConsumidorFinal.Checked = true;
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;
            CargarHistorial();
            CargarConfiguracion();
        }

        // ─── TAB EMISIÓN ──────────────────────────────────────────────────────

        private void cboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esNcNd = cboTipoComprobante.SelectedIndex > 0;
            lblNroAsociadoLabel.Visible = esNcNd;
            txtNroAsociado.Visible      = esNcNd;
        }

        private void rbConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            bool esCF = rbConsumidorFinal.Checked;
            txtCuitReceptor.Enabled = !esCF;
            if (esCF)
            {
                txtNombreReceptor.Text = "Consumidor Final";
                txtCuitReceptor.Text   = "0";
            }
            else
            {
                if (txtNombreReceptor.Text == "Consumidor Final")
                    txtNombreReceptor.Text = "";
                txtCuitReceptor.Text = "";
                txtCuitReceptor.Focus();
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            decimal total;
            if (decimal.TryParse(txtImporte.Text.Replace(',', '.'),
                NumberStyles.Any, CultureInfo.InvariantCulture, out total))
            {
                lblTotalValor.Text    = "$" + total.ToString("N2");
                lblSubtotalValor.Text = "$" + total.ToString("N2");
            }
            else
            {
                lblTotalValor.Text    = "$0.00";
                lblSubtotalValor.Text = "$0.00";
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if (!ValidarEmision()) return;

            decimal importe;
            decimal.TryParse(txtImporte.Text.Replace(',', '.'),
                NumberStyles.Any, CultureInfo.InvariantCulture, out importe);

            string cuit    = rbConsumidorFinal.Checked ? "0" : txtCuitReceptor.Text.Trim();
            string nombre  = txtNombreReceptor.Text.Trim();
            string condIVA = rbConsumidorFinal.Checked ? "CF" : "RI";

            // Tipo de comprobante y comprobante asociado
            string tipoTF = cboTipoComprobante.SelectedItem?.ToString() ?? "FACTURA C";
            long   nroAsociado = 0;
            if (cboTipoComprobante.SelectedIndex > 0)
                long.TryParse(txtNroAsociado.Text.Trim(), out nroAsociado);

            // Medio de pago
            string medioPago = (cboMedioPago.SelectedItem as string) ?? "EFECTIVO";

            btnEmitir.Enabled = false;
            btnEmitir.Text    = "Emitiendo...";
            Cursor = Cursors.WaitCursor;

            try
            {
                var res = _negocio.EmitirFactura(
                    Guid.Empty, 11, cuit, nombre, condIVA, importe, 0m, 2,
                    tipoTF, nroAsociado, medioPago);

                panelResultado.Visible = true;

                if (res.Modo == 1)
                {
                    panelResultado.BackColor    = Color.FromArgb(220, 255, 220);
                    lblResultadoTitulo.Text     = "✓  Factura Autorizada por AFIP";
                    lblResultadoTitulo.ForeColor = Color.FromArgb(0, 128, 0);
                    lblCaeValor.Text            = ExtraerSegmento(res.Mensaje, "CAE: ", " —");
                    lblNroComprobanteValor.Text  = ExtraerSegmento(res.Mensaje, "Nro: ", " —");
                    lblVencimientoValor.Text     = ExtraerSegmento(res.Mensaje, "Vence: ", " —");
                    // Capturar URL del PDF si TusFacturas la devuelve
                    _ultimoPdfUrl = ExtraerSegmento(res.Mensaje, "PDF:", null);
                    btnVerPdf.Visible = !string.IsNullOrEmpty(_ultimoPdfUrl);
                    CargarHistorial();
                }
                else
                {
                    panelResultado.BackColor     = Color.FromArgb(255, 220, 220);
                    lblResultadoTitulo.Text      = "✗  Error al emitir la factura";
                    lblResultadoTitulo.ForeColor = Color.FromArgb(180, 0, 0);
                    lblCaeValor.Text             = "---";
                    lblNroComprobanteValor.Text   = "---";
                    lblVencimientoValor.Text      = res.Mensaje;
                }
            }
            finally
            {
                btnEmitir.Enabled = true;
                btnEmitir.Text    = "⚡  Emitir Factura Electrónica";
                Cursor = Cursors.Default;
            }
        }

        private bool ValidarEmision()
        {
            decimal importe;
            if (!decimal.TryParse(txtImporte.Text.Replace(',', '.'),
                NumberStyles.Any, CultureInfo.InvariantCulture, out importe) || importe <= 0)
            {
                MessageBox.Show("Ingrese un importe válido mayor a $0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return false;
            }
            if (rbConCuit.Checked && string.IsNullOrWhiteSpace(txtCuitReceptor.Text))
            {
                MessageBox.Show("Ingrese el CUIT del receptor.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuitReceptor.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombreReceptor.Text))
            {
                MessageBox.Show("Ingrese el nombre del receptor.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreReceptor.Focus();
                return false;
            }
            return true;
        }

        private string ExtraerSegmento(string msg, string inicio, string fin)
        {
            int i = msg.IndexOf(inicio);
            if (i < 0) return "--";
            string resto = msg.Substring(i + inicio.Length);
            if (fin == null) return resto.Trim();
            int f = resto.IndexOf(fin);
            return f < 0 ? resto.Trim() : resto.Substring(0, f).Trim();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtImporte.Text           = "";
            rbConsumidorFinal.Checked  = true;
            txtNombreReceptor.Text    = "Consumidor Final";
            txtCuitReceptor.Text      = "0";
            cboTipoComprobante.SelectedIndex = 0;
            txtNroAsociado.Text       = "";
            cboMedioPago.SelectedIndex = 0;
            panelResultado.Visible    = false;
            btnVerPdf.Visible         = false;
            _ultimoPdfUrl             = null;
            lblTotalValor.Text        = "$0.00";
            lblSubtotalValor.Text     = "$0.00";
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_ultimoPdfUrl))
                Process.Start(new ProcessStartInfo(_ultimoPdfUrl) { UseShellExecute = true });
        }

        // ─── TAB HISTORIAL ────────────────────────────────────────────────────

        private void CargarHistorial()
        {
            try
            {
                DataTable dt = _negocio.ListarComprobantesEntreFechas(
                    dtpDesde.Value.Date, dtpHasta.Value.Date);
                dgvHistorial.DataSource = dt;
                AjustarColumnasGrilla();
            }
            catch { }
        }

        private void AjustarColumnasGrilla()
        {
            if (dgvHistorial.Columns.Count == 0) return;
            foreach (DataGridViewColumn c in dgvHistorial.Columns)
                c.Visible = false;

            MostrarColumna("nroComprobante",    "Nro.",         75);
            MostrarColumna("nombreReceptor",    "Receptor",    175);
            MostrarColumna("cuitReceptor",      "CUIT",         110);
            MostrarColumna("importeTotal",      "Total ($)",    90);
            MostrarColumna("cae",               "CAE",         145);
            MostrarColumna("fechaVencCAE",      "Venc. CAE",    90);
            MostrarColumna("estado",            "Estado",       90);
            MostrarColumna("fechaEmision",      "Fecha",        90);
            MostrarColumna("pdfUrl",            "PDF",          50);
        }

        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string pdf = dgvHistorial.Columns.Contains("pdfUrl")
                ? dgvHistorial.Rows[e.RowIndex].Cells["pdfUrl"].Value?.ToString()
                : null;
            if (!string.IsNullOrEmpty(pdf))
                Process.Start(new ProcessStartInfo(pdf) { UseShellExecute = true });
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null) return;

            string estado = dgvHistorial.Columns.Contains("estado")
                ? dgvHistorial.CurrentRow.Cells["estado"].Value?.ToString() ?? ""
                : "";
            if (estado == "Anulado")
            {
                MessageBox.Show("Este comprobante ya está anulado.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string idStr = dgvHistorial.Columns.Contains("id")
                ? dgvHistorial.CurrentRow.Cells["id"].Value?.ToString() ?? ""
                : "";
            long nro = 0;
            if (dgvHistorial.Columns.Contains("nroComprobante"))
                long.TryParse(dgvHistorial.CurrentRow.Cells["nroComprobante"].Value?.ToString(), out nro);

            if (string.IsNullOrEmpty(idStr) || nro == 0)
            {
                MessageBox.Show("No se puede anular: falta ID o número de comprobante.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    $"\u00bfAnular comprobante N° {nro}? Esta acción es irreversible.",
                    "Confirmar anulación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            Cursor = Cursors.WaitCursor;
            try
            {
                var res = _negocio.AnularComprobante(Guid.Parse(idStr), nro);
                MessageBox.Show(res.Mensaje,
                    res.Modo == 1 ? "Anulado ✓" : "Error",
                    MessageBoxButtons.OK,
                    res.Modo == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (res.Modo == 1) CargarHistorial();
            }
            finally { Cursor = Cursors.Default; }
        }

        private void MostrarColumna(string nombre, string encabezado, int ancho)
        {
            if (!dgvHistorial.Columns.Contains(nombre)) return;
            var col       = dgvHistorial.Columns[nombre];
            col.Visible   = true;
            col.HeaderText = encabezado;
            col.Width     = ancho;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        // ─── TAB CONFIGURACIÓN ────────────────────────────────────────────────

        private void CargarConfiguracion()
        {
            try
            {
                DataTable dt = _negocio.ObtenerConfiguracion();
                if (dt.Rows.Count == 0) return;
                DataRow row         = dt.Rows[0];
                txtCuit.Text        = row["cuitEmisor"].ToString();
                txtRazonSocial.Text = row["razonSocial"].ToString();
                txtPuntoVenta.Text  = row["puntoVenta"].ToString();
                txtApiKey.Text      = dt.Columns.Contains("tfApiKey")    ? row["tfApiKey"].ToString()    : "";
                txtApiToken.Text    = dt.Columns.Contains("tfApiToken")  ? row["tfApiToken"].ToString()  : "";
                txtUserToken.Text   = dt.Columns.Contains("tfUserToken") ? row["tfUserToken"].ToString() : "";
            }
            catch { }
        }

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                MessageBox.Show("Ingrese el CUIT del emisor.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuit.Focus();
                return;
            }
            int pdv;
            if (!int.TryParse(txtPuntoVenta.Text.Trim(), out pdv) || pdv < 1)
                pdv = 1;

            try
            {
                var res = _negocio.GuardarConfiguracion(
                    txtCuit.Text.Trim(), txtRazonSocial.Text.Trim(), "MO",
                    pdv, 'P', "", "", "");

                if (res.Modo == 1)
                {
                    var resTF = _negocio.GuardarTokensTusFacturas(
                        txtApiKey.Text.Trim(),
                        txtApiToken.Text.Trim(),
                        txtUserToken.Text.Trim());

                    MessageBox.Show(
                        resTF.Modo == 1
                            ? "Configuración guardada correctamente."
                            : "Datos guardados pero tokens: " + resTF.Mensaje,
                        "Guardado",
                        MessageBoxButtons.OK,
                        resTF.Modo == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(res.Mensaje, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var res = _negocio.VerificarConexionAfip();
                MessageBox.Show(res.Mensaje,
                    res.Modo == 1 ? "Conexión OK ✓" : "Error de conexión",
                    MessageBoxButtons.OK,
                    res.Modo == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
