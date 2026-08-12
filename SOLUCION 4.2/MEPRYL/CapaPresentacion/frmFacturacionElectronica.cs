using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
        private string _idEmpresaSeleccionada = null; // ID de empresa cuando se factura a empresa
        private bool _cargandoCuitPrueba = false; // Bandera para evitar limpieza en CheckedChanged

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
            InicializarCombosCondicionIVA();
            
            // Ocultar campos de tokens (ya no se usan con API local)
            grpTokens.Visible = false;
        }

        private void InicializarComboEspecialidad()
        {
            try
            {
                _dtEspecialidades = _negocio.ObtenerEspecialidadesConPrecio();

                // Label encima del combo (ahora en la parte superior del GroupBox)
                var lbl = new Label();
                lbl.Text = "Especialidad / Artículo:";
                lbl.Font = new System.Drawing.Font("Segoe UI", 9f);
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(20, 20);
                lbl.BringToFront();
                grpImporte.Controls.Add(lbl);

                // ComboBox de especialidades (en la parte superior)
                _cboEspecialidad = new ComboBox();
                _cboEspecialidad.DropDownStyle = ComboBoxStyle.DropDown; // Permitir escribir para autocompletado
                _cboEspecialidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Autocompletado rápido
                _cboEspecialidad.AutoCompleteSource = AutoCompleteSource.ListItems; // Usar items del ComboBox
                _cboEspecialidad.Font = new System.Drawing.Font("Segoe UI", 10f);
                _cboEspecialidad.Location = new System.Drawing.Point(20, 45);
                _cboEspecialidad.Size = new System.Drawing.Size(400, 28);
                _cboEspecialidad.Name = "cboEspecialidad";
                _cboEspecialidad.BringToFront();

                // item vacío al inicio
                _cboEspecialidad.Items.Add("-- Ingreso manual --");
                foreach (System.Data.DataRow row in _dtEspecialidades.Rows)
                    _cboEspecialidad.Items.Add(row["nombre"].ToString());

                _cboEspecialidad.SelectedIndex = 0;
                _cboEspecialidad.SelectedIndexChanged += cboEspecialidad_SelectedIndexChanged;
                grpImporte.Controls.Add(_cboEspecialidad);
            }
            catch { /* Si falla no bloquea el formulario */ }
        }

        private void InicializarCombosCondicionIVA()
        {
            try
            {
                // LOG: Ver valor inicial del combo
                System.Diagnostics.Debug.WriteLine($"[INICIALIZAR_COMBO] Valor inicial de cboCondicionIvaEmisor: {cboCondicionIvaEmisor.SelectedItem?.ToString() ?? "NULL"}");

                // NO auto-seleccionar la configuración del emisor - dejar que el usuario elija para simulación
                // El combo condicionIvaEmisor queda sin selección para que el usuario pueda elegir libremente
                
                // Seleccionar Consumidor Final por defecto en receptor
                cboCondicionIvaReceptor.SelectedIndex = 0;
            }
            catch { /* Si falla no bloquea el formulario */ }
        }

        private void BtnCuitPrueba_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                if (btn == null) return;

                // Activar bandera para evitar limpieza en CheckedChanged
                _cargandoCuitPrueba = true;

                // Extraer CUIT y condición del texto del botón
                string[] lineas = btn.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
                string cuit = lineas[0].Trim();
                string condicion = lineas[1].Trim();

                // Cargar datos del receptor
                txtCuitReceptor.Text = cuit;
                txtNombreReceptor.Text = $"Cliente Test - {condicion}";
                rbConCuit.Checked = true;
                rbConsumidorFinal.Checked = false;

                // Desactivar bandera
                _cargandoCuitPrueba = false;

                // Determinar condición IVA según el CUIT seleccionado
                string condicionIVA = "CF"; // Default
                int tipoComprobanteSugerido = 11; // Default Factura C

                switch (condicion)
                {
                    case "Responsable Inscripto":
                        condicionIVA = "RI";
                        tipoComprobanteSugerido = 1; // Factura A
                        break;
                    case "Monotributista":
                        condicionIVA = "MO";
                        tipoComprobanteSugerido = 11; // Factura C
                        break;
                    case "Exento":
                        condicionIVA = "EX";
                        tipoComprobanteSugerido = 11; // Factura C
                        break;
                    case "Consumidor Final":
                        condicionIVA = "CF";
                        tipoComprobanteSugerido = 6; // Factura B
                        break;
                }

                // Leer configuración del emisor
                DataTable config = _negocio.ObtenerConfiguracion();
                if (config.Rows.Count > 0)
                {
                    string condicionEmisor = config.Rows[0]["condicionIVA"].ToString().ToUpper();

                    // Calcular tipo de comprobante según emisor y receptor
                    tipoComprobanteSugerido = CalcularTipoComprobanteAutomatico(condicionEmisor, condicionIVA);

                    // Seleccionar tipo de comprobante sugerido en el combo
                    string tipoTexto = ObtenerTipoComprobanteTexto(tipoComprobanteSugerido);
                    for (int i = 0; i < cboTipoComprobante.Items.Count; i++)
                    {
                        if (cboTipoComprobante.Items[i].ToString() == tipoTexto)
                        {
                            cboTipoComprobante.SelectedIndex = i;
                            break;
                        }
                    }
                }

                MessageBox.Show($"CUIT de prueba cargado: {cuit}\nCondición: {condicion}\n" +
                              $"Condición IVA: {condicionIVA}\nTipo sugerido: {ObtenerTipoComprobanteTexto(tipoComprobanteSugerido)}",
                              "CUIT de Testeo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar CUIT de prueba: " + ex.Message);
            }
        }

        private int CalcularTipoComprobanteAutomatico(string condicionEmisor, string condicionReceptor)
        {
            // Monotributista: Siempre Factura C
            if (condicionEmisor == "MONOTRIBUTISTA" || condicionEmisor == "MO" || condicionEmisor == "M")
                return 11; // Factura C

            // Exento: Siempre Factura C
            if (condicionEmisor == "EXENTO" || condicionEmisor == "EX")
                return 11; // Factura C

            // Responsable Inscripto
            if (condicionEmisor == "RESPONSABLE INSCRIPTO" || condicionEmisor == "RI")
            {
                // RI → RI: Factura A
                if (condicionReceptor == "RI")
                    return 1; // Factura A

                // RI → Consumidor Final: Factura B
                if (condicionReceptor == "CF")
                    return 6; // Factura B;

                // RI → Exento: Factura B
                if (condicionReceptor == "EX")
                    return 6; // Factura B

                // RI → Monotributista: Factura C
                if (condicionReceptor == "MO")
                    return 11; // Factura C
            }

            // Default: Factura C
            return 11;
        }

        private string ObtenerTipoComprobanteTexto(int tipoComprobante)
        {
            switch (tipoComprobante)
            {
                case 1: return "FACTURA A";
                case 6: return "FACTURA B";
                case 11: return "FACTURA C";
                default: return "FACTURA C";
            }
        }

        private void CargarEspecialidadesGenerales()
        {
            try
            {
                _dtEspecialidades = _negocio.ObtenerEspecialidadesConPrecio();
                _cboEspecialidad.Items.Clear();
                _cboEspecialidad.Items.Add("-- Ingreso manual --");
                foreach (System.Data.DataRow row in _dtEspecialidades.Rows)
                    _cboEspecialidad.Items.Add(row["nombre"].ToString());
                _cboEspecialidad.SelectedIndex = 0;
            }
            catch { }
        }

        private void CargarEspecialidadesEmpresa(string idEmpresa)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Cargando especialidades para empresa ID: {idEmpresa}");
                
                // Obtener especialidades específicas de la empresa
                string query = "SELECT e.descripcion, e.precioBase " +
                    "FROM dbo.empresaPorTipoDeExamen epte " +
                    "INNER JOIN dbo.Especialidad e ON epte.idTipoExamen = e.id " +
                    "WHERE epte.idEmpresa = '" + idEmpresa + "'";
                
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Query: {query}");
                
                DataTable dtEspecialidadesEmpresa = SQLConnector.obtenerTablaSegunConsultaString(query);
                
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Filas encontradas: {dtEspecialidadesEmpresa.Rows.Count}");
                
                _cboEspecialidad.Items.Clear();
                _cboEspecialidad.Items.Add("-- Ingreso manual --");
                
                foreach (System.Data.DataRow row in dtEspecialidadesEmpresa.Rows)
                {
                    string desc = row["descripcion"].ToString();
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Especialidad: {desc}");
                    _cboEspecialidad.Items.Add(desc);
                }
                
                _cboEspecialidad.SelectedIndex = 0;
                
                if (dtEspecialidadesEmpresa.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] No se encontraron especialidades para esta empresa. Cargando especialidades generales.");
                    CargarEspecialidadesGenerales();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERROR] Error al cargar especialidades de empresa: {ex.Message}");
                // Si falla, cargar especialidades generales
                CargarEspecialidadesGenerales();
            }
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

            // Actualizar texto del tipo seleccionado
            string tipo = cboTipoComprobante.SelectedItem?.ToString() ?? "FACTURA C";
            string descripcion = ObtenerDescripcionTipoComprobante(tipo);
            lblTipoValor.Text = $"{tipo}  —  {descripcion}";
            lblTipoValor.Visible = true;
        }

        private string ObtenerDescripcionTipoComprobante(string tipo)
        {
            switch (tipo)
            {
                case "FACTURA A":
                    return "Responsable Inscripto (discrimina IVA)";
                case "FACTURA B":
                    return "Consumidor Final (IVA contenido)";
                case "FACTURA C":
                    return "Monotributista (sin discriminar IVA)";
                case "NOTA DE CREDITO A":
                    return "NC Responsable Inscripto";
                case "NOTA DE CREDITO B":
                    return "NC Consumidor Final";
                case "NOTA DE CREDITO C":
                    return "NC Monotributista";
                case "NOTA DE DEBITO A":
                    return "ND Responsable Inscripto";
                case "NOTA DE DEBITO B":
                    return "ND Consumidor Final";
                case "NOTA DE DEBITO C":
                    return "ND Monotributista";
                default:
                    return "Comprobante electrónico";
            }
        }

        private void rbConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            // Si estamos cargando un CUIT de prueba, no limpiar los campos
            if (_cargandoCuitPrueba) return;

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
                    string like = safe + "%"; // Solo comodín al final para usar índices
                    try
                    {
                        dtRes = SQLConnector.obtenerTablaSegunConsultaString(
                            "SELECT p.apellido + ' ' + p.nombres AS Paciente, p.dni AS Documento, '' AS CUIL, 'Preventiva' AS Tipo, '' AS Empresa, '' AS CUIT_Empresa, '' AS IdEmpresa " +
                            "FROM dbo.Paciente p " +
                            "WHERE p.dni LIKE '" + like + "' OR p.apellido LIKE '" + like + "' OR p.nombres LIKE '" + like + "' " +
                            "UNION ALL " +
                            "SELECT pl.apellido + ' ' + pl.nombres, pl.dni, ISNULL(pl.cuil,''), 'Laboral', " +
                            "ISNULL(e.razonSocial, ''), ISNULL(e.cuit, ''), ISNULL(CAST(epp.idEmpresa AS VARCHAR(36)), '') " +
                            "FROM dbo.PacienteLaboral pl " +
                            "LEFT JOIN dbo.EmpresasPorPaciente epp ON pl.id = epp.idPaciente " +
                            "LEFT JOIN dbo.Empresa e ON epp.idEmpresa = e.id " +
                            "WHERE pl.dni LIKE '" + like + "' OR pl.apellido LIKE '" + like + "' OR pl.nombres LIKE '" + like + "' " +
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
                    string tipo    = fila.Cells["Tipo"].Value?.ToString()     ?? "";
                    string empresa = fila.Cells["Empresa"].Value?.ToString()  ?? "";
                    string cuitEmpresa = fila.Cells["CUIT_Empresa"].Value?.ToString() ?? "";
                    string idEmpresa = fila.Cells["IdEmpresa"].Value?.ToString() ?? "";

                    // Si es laboral y tiene empresa asociada, preguntar a quién facturar
                    if (tipo == "Laboral" && !string.IsNullOrWhiteSpace(empresa) && !string.IsNullOrWhiteSpace(cuitEmpresa))
                    {
                        var result = MessageBox.Show(
                            $"Paciente: {nombre}\nEmpresa asociada: {empresa} (CUIT: {cuitEmpresa})\n\n¿Desea facturar a la EMPRESA?\n\nSí = Facturar a empresa (CUIT)\nNo = Facturar a paciente (DNI)",
                            "Consulta Laboral",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Facturar a empresa
                            txtNombreReceptor.Text = empresa;
                            rbConCuit.Checked = true;
                            txtCuitReceptor.Text = cuitEmpresa;
                            _idEmpresaSeleccionada = idEmpresa;
                            // Recargar especialidades específicas de la empresa
                            CargarEspecialidadesEmpresa(idEmpresa);
                        }
                        else
                        {
                            // Facturar a paciente
                            txtNombreReceptor.Text = nombre;
                            // Preferir CUIL si existe; si no, usar DNI
                            string doc = !string.IsNullOrWhiteSpace(cuilVal) && cuilVal != "0" ? cuilVal : dniVal;
                            if (!string.IsNullOrWhiteSpace(doc) && doc != "0")
                            {
                                rbConCuit.Checked = true;
                                txtCuitReceptor.Text = doc;
                            }
                            else
                            {
                                rbConsumidorFinal.Checked = true;
                                txtCuitReceptor.Text = dniVal;
                            }
                            _idEmpresaSeleccionada = null;
                            // Recargar especialidades generales
                            CargarEspecialidadesGenerales();
                        }
                    }
                    else
                    {
                        // Preventiva o laboral sin empresa: facturar a paciente
                        txtNombreReceptor.Text = nombre;
                        // Preferir CUIL si existe; si no, usar DNI
                        string doc = !string.IsNullOrWhiteSpace(cuilVal) && cuilVal != "0" ? cuilVal : dniVal;
                        if (!string.IsNullOrWhiteSpace(doc) && doc != "0")
                        {
                            rbConCuit.Checked = true;
                            txtCuitReceptor.Text = doc;
                        }
                        else
                        {
                            rbConsumidorFinal.Checked = true;
                            txtCuitReceptor.Text = dniVal;
                        }
                        _idEmpresaSeleccionada = null;
                        // Recargar especialidades generales
                        CargarEspecialidadesGenerales();
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

            // Tipo de comprobante y comprobante asociado
            string tipoTF = cboTipoComprobante.SelectedItem?.ToString() ?? "FACTURA B";
            int tipoComprobanteAFIP = ObtenerCodigoAFIP(tipoTF);
            long   nroAsociado = 0;
            if (cboTipoComprobante.SelectedIndex > 0)
                long.TryParse(txtNroAsociado.Text.Trim(), out nroAsociado);

            string cuit    = rbConsumidorFinal.Checked ? "0" : txtCuitReceptor.Text.Trim();
            string nombre  = txtNombreReceptor.Text.Trim();
            string condIVA = ObtenerCondicionIVA(tipoTF, rbConsumidorFinal.Checked);

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

            // Para Factura B (Exento), no enviar IVA - usar valor 0
            decimal alicuotaIVA = tipoComprobanteAFIP == 6 ? 0m : 21m;

            // Medio de pago
            string medioPago = (cboMedioPago.SelectedItem as string) ?? "EFECTIVO";

            // Condición IVA emisor: usar el combo seleccionado por el usuario
            int condicionIvaEmisorId = 6; // Default: Monotributista
            if (cboCondicionIvaEmisor.SelectedItem != null)
            {
                string condicion = cboCondicionIvaEmisor.SelectedItem.ToString().ToUpper();
                if (condicion.Contains("INSCRIPTO") || condicion == "RI")
                    condicionIvaEmisorId = 1; // Responsable Inscripto
                else if (condicion.Contains("EXENTO") || condicion == "EX")
                    condicionIvaEmisorId = 3; // Exento
                else if (condicion.Contains("MONOTRIB"))
                    condicionIvaEmisorId = 6; // Monotributista
            }

            // LOG: Ver valor que se envía desde el formulario
            System.Diagnostics.Debug.WriteLine($"[FORMULARIO] condicionIvaEmisorId que se envía: {condicionIvaEmisorId}");
            System.Diagnostics.Debug.WriteLine($"[FORMULARIO] Combo seleccionado: {cboCondicionIvaEmisor.SelectedItem?.ToString()}");

            btnEmitir.Enabled = false;
            btnEmitir.Text    = "Emitiendo...";
            Cursor = Cursors.WaitCursor;

            try
            {
                var res = _negocio.EmitirFactura(
                    Guid.Empty, tipoComprobanteAFIP, cuit, nombre, condIVA, importe, alicuotaIVA, 2,
                    tipoTF, nroAsociado, medioPago,
                    descArticulo, codArticulo, condicionIvaEmisorId);

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

            // Configuración de altura de filas
            dgvHistorial.RowTemplate.Height = 35; // Altura de fila fija de 35px
            dgvHistorial.RowTemplate.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4); // Padding: izq, arriba, der, abajo

            // Configuración general de la grilla
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);
            dgvHistorial.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 102, 204);
            dgvHistorial.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvHistorial.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHistorial.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.GridColor = Color.FromArgb(200, 200, 200);
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurar alineación del contenido de las celdas
            dgvHistorial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            MostrarColumna("nroComprobante",    "Nro.",         80);
            MostrarColumna("nombreReceptor",    "Receptor",    200);
            MostrarColumna("cuitReceptor",      "CUIT",         120);
            MostrarColumna("importeTotal",      "Total ($)",    100);
            MostrarColumna("cae",               "CAE",         150);
            MostrarColumna("fechaVencCAE",      "Venc. CAE",   100);
            MostrarColumna("estado",            "Estado",       100);
            MostrarColumna("fechaEmision",      "Fecha",        100);
            MostrarColumna("tipoComprobante",   "Tipo",         80);
            MostrarColumna("puntoVenta",        "Pto. Venta",   80);
            MostrarColumna("tipoTF",            "Tipo TF",      100);

            // Configurar columna PDF como enlace
            if (dgvHistorial.Columns.Contains("pdfUrl"))
            {
                var colPdf = dgvHistorial.Columns["pdfUrl"];
                colPdf.Visible = true;
                colPdf.HeaderText = "PDF";
                colPdf.MinimumWidth = 80;
                colPdf.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                colPdf.DefaultCellStyle.ForeColor = Color.Blue;
                colPdf.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            }
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

        private void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Permitir abrir el PDF con un solo clic en la columna PDF
            if (e.RowIndex < 0) return;
            if (dgvHistorial.Columns.Contains("pdfUrl") && dgvHistorial.Columns[e.ColumnIndex].Name == "pdfUrl")
            {
                string pdf = dgvHistorial.Rows[e.RowIndex].Cells["pdfUrl"].Value?.ToString();
                if (!string.IsNullOrEmpty(pdf))
                    Process.Start(new ProcessStartInfo(pdf) { UseShellExecute = true });
            }
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

            try
            {
                // Obtener condición IVA del combo seleccionado
                string condicionIVA = "MO"; // Default: Monotributista
                if (cboCondicionIvaEmisor.SelectedItem != null)
                {
                    string condicion = cboCondicionIvaEmisor.SelectedItem.ToString().ToUpper();
                    if (condicion.Contains("INSCRIPTO") || condicion == "RI")
                        condicionIVA = "RI"; // Responsable Inscripto
                    else if (condicion.Contains("EXENTO") || condicion == "EX")
                        condicionIVA = "EX"; // Exento
                    else if (condicion.Contains("MONOTRIB"))
                        condicionIVA = "MO"; // Monotributista
                }

                // LOG: Ver valor que se va a guardar
                System.Diagnostics.Debug.WriteLine($"[GUARDAR_CONFIG] Condición IVA que se guardará: {condicionIVA}");
                System.Diagnostics.Debug.WriteLine($"[GUARDAR_CONFIG] Combo seleccionado: {cboCondicionIvaEmisor.SelectedItem?.ToString()}");

                var res = _negocio.GuardarConfiguracion(
                    txtCuit.Text.Trim(), txtRazonSocial.Text.Trim(), condicionIVA,
                    1, 'P', "", "", "");

                if (res.Modo == 1)
                {
                    MessageBox.Show(
                        "Configuración guardada correctamente. La API local usará los certificados digitales configurados.",
                        "Guardado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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

        private int ObtenerCodigoAFIP(string tipoTF)
        {
            // Mapeo de tipos de comprobantes a códigos AFIP
            switch (tipoTF)
            {
                case "FACTURA A":
                    return 1;  // Responsable Inscripto
                case "FACTURA B":
                    return 6;  // Exento/Monotributista
                case "FACTURA C":
                    return 11; // Consumidor Final
                case "NOTA DE CREDITO A":
                    return 3;
                case "NOTA DE CREDITO B":
                    return 8;
                case "NOTA DE CREDITO C":
                    return 13;
                case "NOTA DE DEBITO A":
                    return 2;
                case "NOTA DE DEBITO B":
                    return 7;
                case "NOTA DE DEBITO C":
                    return 12;
                default:
                    return 11; // Por defecto Factura C
            }
        }

        private string ObtenerCondicionIVA(string tipoTF, bool esConsumidorFinal)
        {
            // Mapeo de condición IVA según tipo de factura
            if (esConsumidorFinal)
            {
                return "CF"; // Consumidor Final para Factura C
            }

            switch (tipoTF)
            {
                case "FACTURA A":
                case "NOTA DE CREDITO A":
                case "NOTA DE DEBITO A":
                    return "RI"; // Responsable Inscripto
                case "FACTURA B":
                case "NOTA DE CREDITO B":
                case "NOTA DE DEBITO B":
                    return "EX"; // Exento/Monotributista
                case "FACTURA C":
                case "NOTA DE CREDITO C":
                case "NOTA DE DEBITO C":
                    return "CF"; // Consumidor Final
                default:
                    return "RI"; // Por defecto Responsable Inscripto
            }
        }
    }
}
