using System;
using System.Globalization;
using System.Windows.Forms;

namespace CapaPresentacion
{
    /// <summary>
    /// Diálogo rápido de confirmación de cobro antes de emitir la factura electrónica.
    /// Muestra el nombre del paciente, la especialidad y permite ajustar el importe y medio de pago.
    /// </summary>
    public class frmDialogoFactura : Form
    {
        public decimal Importe   { get; private set; }
        public string  MedioPago { get; private set; }

        private TextBox     txtImporte;
        private ComboBox    cboMedioPago;
        private Button      btnOk;
        private Button      btnCancelar;

        public frmDialogoFactura(string nombrePaciente, string especialidad, decimal precioBase)
        {
            InitControls(nombrePaciente, especialidad, precioBase);
        }

        private void InitControls(string nombrePaciente, string especialidad, decimal precioBase)
        {
            Text            = "Cobrar y Emitir Factura Electrónica";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition   = FormStartPosition.CenterParent;
            MaximizeBox     = false;
            MinimizeBox     = false;
            Width           = 400;
            Height          = 280;
            Font            = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);

            // ── Paciente / Especialidad ──────────────────────────────────────
            var lblPac = new Label
            {
                Text     = "Paciente:",
                Left     = 20, Top = 18, Width = 80,
                Font     = new System.Drawing.Font("Microsoft Sans Serif", 9f,
                               System.Drawing.FontStyle.Bold)
            };
            var lblPacVal = new Label
            {
                Text  = nombrePaciente,
                Left  = 105, Top = 18, Width = 270, Height = 20,
                Font  = new System.Drawing.Font("Microsoft Sans Serif", 9f)
            };

            var lblEsp = new Label
            {
                Text  = "Especialidad:",
                Left  = 20, Top = 42, Width = 80,
                Font  = new System.Drawing.Font("Microsoft Sans Serif", 9f,
                            System.Drawing.FontStyle.Bold)
            };
            var lblEspVal = new Label
            {
                Text  = especialidad,
                Left  = 105, Top = 42, Width = 270, Height = 20,
                Font  = new System.Drawing.Font("Microsoft Sans Serif", 9f)
            };

            // ── Importe ──────────────────────────────────────────────────────
            var lblImp = new Label
            {
                Text  = "Importe ($):",
                Left  = 20, Top = 80, Width = 100,
                Font  = new System.Drawing.Font("Microsoft Sans Serif", 9.75f,
                            System.Drawing.FontStyle.Bold)
            };
            txtImporte = new TextBox
            {
                Left  = 125, Top = 77, Width = 200,
                Font  = new System.Drawing.Font("Microsoft Sans Serif", 11f,
                            System.Drawing.FontStyle.Bold),
                Text  = precioBase > 0
                        ? precioBase.ToString("F2", CultureInfo.InvariantCulture)
                        : "0.00"
            };
            txtImporte.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '\b')
                    e.Handled = true;
            };

            // ── Medio de Pago ────────────────────────────────────────────────
            var lblMedio = new Label
            {
                Text  = "Medio de Pago:",
                Left  = 20, Top = 120, Width = 110
            };
            cboMedioPago = new ComboBox
            {
                Left          = 135, Top = 117, Width = 190,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboMedioPago.Items.AddRange(new object[]
            {
                "EFECTIVO", "TARJETA_CREDITO", "TARJETA_DEBITO",
                "TRANSFERENCIA", "MERCADO_PAGO"
            });
            cboMedioPago.SelectedIndex = 0;

            // ── Separador ────────────────────────────────────────────────────
            var sep = new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                Left = 10, Top = 160, Width = 365, Height = 2
            };

            // ── Botones ──────────────────────────────────────────────────────
            btnOk = new Button
            {
                Text      = "✓  Emitir Factura",
                Left      = 45, Top = 170,
                Width     = 140, Height = 40,
                BackColor = System.Drawing.Color.FromArgb(0, 128, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new System.Drawing.Font("Microsoft Sans Serif", 9.75f,
                                System.Drawing.FontStyle.Bold),
                DialogResult = DialogResult.OK
            };
            btnOk.Click += BtnOk_Click;

            btnCancelar = new Button
            {
                Text         = "Cancelar",
                Left         = 210, Top = 170,
                Width        = 120, Height = 40,
                DialogResult = DialogResult.Cancel
            };

            AcceptButton = btnOk;
            CancelButton = btnCancelar;

            Controls.AddRange(new Control[]
            {
                lblPac, lblPacVal, lblEsp, lblEspVal,
                lblImp, txtImporte,
                lblMedio, cboMedioPago,
                sep, btnOk, btnCancelar
            });
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            decimal imp;
            if (!decimal.TryParse(
                    txtImporte.Text.Replace(',', '.'),
                    NumberStyles.Any, CultureInfo.InvariantCulture,
                    out imp) || imp <= 0)
            {
                MessageBox.Show("Ingrese un importe válido mayor a $0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            Importe   = imp;
            MedioPago = cboMedioPago.SelectedItem?.ToString() ?? "EFECTIVO";
        }
    }
}
