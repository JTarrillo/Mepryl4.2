using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class FrmNuevoMotivoConsulta : Form
    {
        public string NombreMotivo { get; private set; }
        public string IdentificadorInterno { get; private set; }
        public bool Estado { get; private set; } = true; // ✅ Por defecto activo

        private TextBox txtNombre;
        private TextBox txtIdentificador;
        private CheckBox chkEstado; // ✅ Checkbox para estado
        private Button btnAceptar;
        private Button btnCancelar;

        public FrmNuevoMotivoConsulta()
        {
            this.Text = "Nuevo Motivo de Consulta";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 400;
            this.Height = 190; // ✅ Aumentar altura para el checkbox
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int labelWidth = 100;
            int textBoxWidth = 220;
            int formPadding = 20;
            int controlSpacing = 15;
            int buttonWidth = 90;
            int buttonHeight = 30;
            int buttonSpacing = 20;

            Label lblNombre = new Label
            {
                Text = "Nombre:",
                Left = formPadding,
                Top = formPadding,
                Width = labelWidth
            };
            txtNombre = new TextBox
            {
                Left = formPadding + labelWidth + controlSpacing,
                Top = formPadding - 2,
                Width = textBoxWidth
            };

            // ✅ Checkbox para estado (activo/inactivo)
            chkEstado = new CheckBox
            {
                Text = "Activo",
                Left = formPadding,
                Top = formPadding + 35,
                Width = 150,
                Checked = true // Por defecto activo
            };

            // El identificador interno no se muestra en pantalla, pero se mantiene para uso interno
            txtIdentificador = new TextBox { Visible = false };

            // Centrar los botones horizontalmente
            int totalButtonWidth = (buttonWidth * 2) + buttonSpacing;
            int buttonsLeft = (this.Width - totalButtonWidth) / 2;
            int buttonsTop = formPadding + 70; // ✅ Ajustado para dejar espacio al checkbox

            btnAceptar = new Button
            {
                Text = "Aceptar",
                Left = buttonsLeft,
                Top = buttonsTop,
                Width = buttonWidth,
                Height = buttonHeight
            };
            btnCancelar = new Button
            {
                Text = "Cancelar",
                Left = buttonsLeft + buttonWidth + buttonSpacing,
                Top = buttonsTop,
                Width = buttonWidth,
                Height = buttonHeight
            };

            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            // Permitir aceptar con Enter
            this.AcceptButton = btnAceptar;

            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(chkEstado); // ✅ Agregar checkbox de estado
            // No se agrega lblIdentificador ni txtIdentificador a Controls
            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            NombreMotivo = txtNombre.Text.Trim();
            IdentificadorInterno = txtIdentificador.Text.Trim();
            Estado = chkEstado.Checked; // ✅ Guardar estado
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
