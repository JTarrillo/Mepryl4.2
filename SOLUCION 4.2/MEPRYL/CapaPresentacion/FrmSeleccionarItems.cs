using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    /// <summary>
    /// ✅ NUEVO FORMULARIO: Seleccionar Items para crear SubTipo
    /// Muestra grid con todos los items disponibles
    /// Usuario marca los que quiere incluir
    /// Retorna Dictionary<codigo, estado>
    /// </summary>
    public class FrmSeleccionarItems : Form
    {
        private CapaNegocioMepryl.TipoExamen negocioTipoExamen;
        public Dictionary<int, bool> ItemsSeleccionados { get; private set; }

        public FrmSeleccionarItems(CapaNegocioMepryl.TipoExamen negocio)
        {
            this.negocioTipoExamen = negocio;
            this.ItemsSeleccionados = new Dictionary<int, bool>();

            this.Text = "Seleccionar Items para el SubTipo";
            this.Width = 700;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ✅ CONECTAR EL EVENTO LOAD
            this.Load += FrmSeleccionarItems_Load;
        }

        private void FrmSeleccionarItems_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear label instructivo
                Label lblInstruccion = new Label();
                lblInstruccion.Text = "Marca los items que deseas incluir en este SubTipo:";
                lblInstruccion.Location = new System.Drawing.Point(10, 10);
                lblInstruccion.Width = 400;
                lblInstruccion.Height = 30;
                this.Controls.Add(lblInstruccion);

                // Configurar DataGridView
                DataGridView dgv = new DataGridView();
                dgv.Name = "dgvItems";
                dgv.Location = new System.Drawing.Point(10, 50);
                dgv.Width = 660;
                dgv.Height = 450;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.ReadOnly = false;
                this.Controls.Add(dgv);

                // Configurar columnas
                dgv.Columns.Add("Codigo", "Código");

                DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
                colCheck.Name = "Seleccionar";
                colCheck.HeaderText = "✓ Incluir";
                colCheck.Width = 70;
                colCheck.TrueValue = true;
                colCheck.FalseValue = false;
                colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns.Add(colCheck);

                dgv.Columns.Add("Item", "Nombre del Item");
                dgv.Columns.Add("Orden", "Orden");

                dgv.Columns[0].Width = 60;
                dgv.Columns[2].Width = 400;
                dgv.Columns[3].Width = 60;

                // Cargar items
                CargarItemsEnGrid(dgv);

                // Botones
                Button btnGuardar = new Button();
                btnGuardar.Text = "✓ Guardar Selección";
                btnGuardar.Location = new System.Drawing.Point(150, 510);
                btnGuardar.Width = 150;
                btnGuardar.Height = 30;
                btnGuardar.Click += (s, args) => GuardarSeleccion(dgv);
                this.Controls.Add(btnGuardar);

                Button btnCancelar = new Button();
                btnCancelar.Text = "✗ Cancelar";
                btnCancelar.Location = new System.Drawing.Point(320, 510);
                btnCancelar.Width = 150;
                btnCancelar.Height = 30;
                btnCancelar.Click += (s, args) => this.Close();
                this.Controls.Add(btnCancelar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarItemsEnGrid(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Clear();

                // ✅ Usar el método correcto que ya existe
                DataTable todosItems = negocioTipoExamen.CargarItemsDesdeEstudiosPorExamen(Guid.Empty);

                if (todosItems != null && todosItems.Rows.Count > 0)
                {
                    foreach (DataRow row in todosItems.Rows)
                    {
                        int rowIndex = dgv.Rows.Add();
                        dgv.Rows[rowIndex].Cells[0].Value = row["Codigo"];
                        dgv.Rows[rowIndex].Cells[1].Value = false;  // Sin seleccionar por defecto
                        dgv.Rows[rowIndex].Cells[2].Value = row["Item"];
                        dgv.Rows[rowIndex].Cells[3].Value = row.IsNull("OrdenFormulario") ? 0 : row["OrdenFormulario"];
                    }
                }
                else
                {
                    MessageBox.Show("No hay items disponibles para cargar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar items: " + ex.Message);
            }
        }

        private void GuardarSeleccion(DataGridView dgv)
        {
            try
            {
                this.ItemsSeleccionados.Clear();

                // Recopilar items SELECCIONADOS
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!int.TryParse(row.Cells[0].Value?.ToString(), out int codigo))
                        continue;

                    bool isChecked = Convert.ToBoolean(row.Cells[1].Value ?? false);
                    this.ItemsSeleccionados[codigo] = isChecked;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
