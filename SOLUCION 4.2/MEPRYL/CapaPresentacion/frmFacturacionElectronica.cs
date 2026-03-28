using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmFacturacionElectronica : DevExpress.XtraEditors.XtraForm
    {
        private readonly CapaNegocioMepryl.FacturacionElectronica _negocio;

        private string _ultimoPdfUrl = null;
        private System.Data.DataTable _dtEspecialidades = null;
        private ComboBox _cboEspecialidad = null;

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
            InicializarComboEspecialidad();
        }

        private void InicializarComboEspecialidad()
        {
            try
            {
                _dtEspecialidades = _negocio.ObtenerEspecialidadesConPrecio();

                // Label encima del combo
                var lbl = new Label();
                lbl.Text = "Especialidad / Artículo:";
                lbl.Font = new System.Drawing.Font("Segoe UI", 9f);
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(12, 18);
                grpImporte.Controls.Add(lbl);

                // ComboBox de especialidades
                _cboEspecialidad = new ComboBox();
                _cboEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
                _cboEspecialidad.Font = new System.Drawing.Font("Segoe UI", 10f);
                _cboEspecialidad.Location = new System.Drawing.Point(12, 38);
                _cboEspecialidad.Size = new System.Drawing.Size(400, 28);
                _cboEspecialidad.Name = "cboEspecialidad";

                // item vacío al inicio
                _cboEspecialidad.Items.Add("-- Ingreso manual --");
                foreach (System.Data.DataRow row in _dtEspecialidades.Rows)
                    _cboEspecialidad.Items.Add(row["nombre"].ToString());

                _cboEspecialidad.SelectedIndex = 0;
                _cboEspecialidad.SelectedIndexChanged += cboEspecialidad_SelectedIndexChanged;
                grpImporte.Controls.Add(_cboEspecialidad);

                // Mover txtImporte y lblImporteLabel hacia abajo para que entren
                lblImporteLabel.Top  = 72;
                txtImporte.Top       = 92;
                lblIVANota.Top       = txtImporte.Top + txtImporte.Height + 4;
                lblMedioPagoLabel.Top = lblIVANota.Top + lblIVANota.Height + 4;
                cboMedioPago.Top     = lblMedioPagoLabel.Top + lblMedioPagoLabel.Height + 2;

                // Ampliar el GroupBox si es necesario
                if (grpImporte.Height < cboMedioPago.Bottom + 20)
                    grpImporte.Height = cboMedioPago.Bottom + 20;
            }
            catch { /* Si falla no bloquea el formulario */ }
        }

        private void cboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cboEspecialidad == null || _dtEspecialidades == null) return;
            int idx = _cboEspecialidad.SelectedIndex - 1; // -1 = item vacío
            if (idx < 0) return;
            DataRow row = _dtEspecialidades.Rows[idx];
            decimal precio = row["precio"] == DBNull.Value ? 0m : Convert.ToDecimal(row["precio"]);
            if (precio > 0)
                txtImporte.Text = precio.ToString(System.Globalization.CultureInfo.InvariantCulture);
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

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            using (var frm = new Form())
            {
                frm.Text = "Buscar Paciente";
                frm.Size = new Size(640, 490);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;

                var lbl = new Label  { Text = "Nombre o DNI:", AutoSize = true, Location = new Point(12, 15), Font = new Font("Segoe UI", 9f) };
                var txt = new TextBox { Location = new Point(108, 11), Size = new Size(330, 25), Font = new Font("Segoe UI", 10f) };
                var btnBuscar = new Button { Text = "Buscar", Location = new Point(445, 10), Size = new Size(80, 28) };

                var dgv = new DataGridView
                {
                    Location = new Point(12, 50), Size = new Size(606, 340),
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = false,
                    AllowUserToAddRows = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                var btnOk     = new Button { Text = "Seleccionar", Location = new Point(466, 410), Size = new Size(140, 32), DialogResult = DialogResult.OK, Enabled = false };
                var btnCancel = new Button { Text = "Cancelar",    Location = new Point(316, 410), Size = new Size(140, 32), DialogResult = DialogResult.Cancel };

                DataTable dtRes = new DataTable();

                Action buscar = () =>
                {
                    string q = txt.Text.Trim();
                    if (string.IsNullOrEmpty(q)) return;
                    string safe = q.Replace("'", "''");
                    string like = "%" + safe + "%";
                    try
                    {
                        dtRes = SQLConnector.obtenerTablaSegunConsultaString(
                            "SELECT apellido + ' ' + nombres AS Paciente, dni AS Documento, '' AS CUIL, 'Preventiva' AS Tipo " +
                            "FROM dbo.Paciente " +
                            "WHERE dni LIKE '" + like + "' OR LTRIM(RTRIM(apellido + ' ' + nombres)) LIKE '" + like + "' " +
                            "UNION ALL " +
                            "SELECT apellido + ' ' + nombres, dni, ISNULL(cuil,''), 'Laboral' " +
                            "FROM dbo.PacienteLaboral " +
                            "WHERE dni LIKE '" + like + "' OR LTRIM(RTRIM(apellido + ' ' + nombres)) LIKE '" + like + "' " +
                            "ORDER BY 1");
                        dgv.DataSource = dtRes;
                        btnOk.Enabled = false;
                    }
                    catch (Exception ex) { MessageBox.Show("Error en búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                };

                btnBuscar.Click      += (s, ev) => buscar();
                txt.KeyDown          += (s, ev) => { if (ev.KeyCode == Keys.Enter) { buscar(); } };
                dgv.SelectionChanged += (s, ev) => btnOk.Enabled = dgv.SelectedRows.Count > 0;
                dgv.CellDoubleClick  += (s, ev) => { if (dgv.SelectedRows.Count > 0) { frm.DialogResult = DialogResult.OK; frm.Close(); } };

                frm.Controls.AddRange(new Control[] { lbl, txt, btnBuscar, dgv, btnOk, btnCancel });
                frm.AcceptButton = btnBuscar;

                if (frm.ShowDialog(this) == DialogResult.OK && dgv.SelectedRows.Count > 0)
                {
                    DataGridViewRow fila = dgv.SelectedRows[0];
                    string nombre  = fila.Cells["Paciente"].Value?.ToString()  ?? "";
                    string dniVal  = fila.Cells["Documento"].Value?.ToString() ?? "";
                    string cuilVal = fila.Cells["CUIL"].Value?.ToString()      ?? "";

                    // Preferir CUIL si existe; si no, usar DNI
                    string doc = !string.IsNullOrWhiteSpace(cuilVal) && cuilVal != "0" ? cuilVal : dniVal;

                    txtNombreReceptor.Text = nombre;

                    if (!string.IsNullOrWhiteSpace(doc) && doc != "0")
                    {
                        rbConCuit.Checked    = true;
                        txtCuitReceptor.Text = doc;
                    }
                    else
                    {
                        rbConsumidorFinal.Checked = true;
                    }
                }
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

            // Descripción y código de artículo de la especialidad seleccionada
            string descArticulo = "Prestación médica";
            string codArticulo  = "";
            if (_cboEspecialidad != null && _dtEspecialidades != null)
            {
                int idx = _cboEspecialidad.SelectedIndex - 1;
                if (idx >= 0)
                {
                    DataRow row = _dtEspecialidades.Rows[idx];
                    descArticulo = row["nombreFacturacion"].ToString();
                    codArticulo  = row["codigo"].ToString();
                }
            }

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
                    tipoTF, nroAsociado, medioPago,
                    descArticulo, codArticulo);

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
            if (_cboEspecialidad != null) _cboEspecialidad.SelectedIndex = 0;
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
