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
using Entidades;

namespace CapaPresentacion
{
    public partial class FrmEditarSubtipo : Form
    {
        private string idSubtipo;
        private string nombreSubtipoOriginal;
        private CapaNegocioMepryl.TipoExamen negocioTipoExamen;
        private TextBox txtNombreSubtipo;
        private Label lblNombre;
        private Button btnGuardar;
        private Button btnCancelar;

        public FrmEditarSubtipo(string idSubtipo, string nombreSubtipo)
        {
            InitializeComponent();
            this.idSubtipo = idSubtipo;
            this.nombreSubtipoOriginal = nombreSubtipo;
            this.negocioTipoExamen = new CapaNegocioMepryl.TipoExamen();
            
            // Configurar formulario como modal
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = $"Editar Subtipo";
            this.Size = new Size(400, 200);
            this.BackColor = Color.White;

            // ✅ Crear controles para editar nombre
            CrearControles();
        }

        private void CrearControles()
        {
            // ✅ LABEL
            lblNombre = new Label
            {
                Text = "Nombre del Subtipo:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblNombre);

            // ✅ TEXTBOX para editar nombre
            txtNombreSubtipo = new TextBox
            {
                Text = nombreSubtipoOriginal,
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 45),
                Width = 350,
                Height = 35,
                Multiline = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(txtNombreSubtipo);

            // ✅ BOTÓN GUARDAR
            btnGuardar = new Button
            {
                Text = "✓ Guardar",
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 100),
                Width = 160,
                Height = 40,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);

            // ✅ BOTÓN CANCELAR
            btnCancelar = new Button
            {
                Text = "✕ Cancelar",
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(210, 100),
                Width = 160,
                Height = 40,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += BtnCancelar_Click;
            this.Controls.Add(btnCancelar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoNombre = txtNombreSubtipo.Text.Trim();

                if (string.IsNullOrEmpty(nuevoNombre))
                {
                    MessageBox.Show("El nombre del subtipo no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreSubtipo.Focus();
                    return;
                }

                if (nuevoNombre == nombreSubtipoOriginal)
                {
                    MessageBox.Show("El nombre no ha cambiado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // ✅ Actualizar el nombre en la base de datos
                negocioTipoExamen.ActualizarNombreSubtipo(idSubtipo, nuevoNombre);
                
                MessageBox.Show($"Subtipo actualizado a: '{nuevoNombre}'", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[ERROR] {ex.StackTrace}");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
