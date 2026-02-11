using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAgregaItemsExamenes : Form
    {
        public frmAgregaItemsExamenes()
        {
            InitializeComponent();
            this.Load += frmAgregaItemsExamenes_Load;
            CargarItems();
            btnNuevo.Click += btnNuevo_Click;
            btnModificar.Click += btnModificar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
            // Suscribir el evento de eliminar
            btnEliminar.Click += btnEliminar_Click;
            panelEdicion.Visible = false;
        }

        private void CargarItems()
        {
            // Consulta los ítems y sus secciones/subsecciones y los muestra en el DataGridView
            string consulta = @"
                SELECT 
                    i.codigo,
                    i.nombreCompleto,
                    i.nombreInformes,
                    s.Seccion,
                    s.Subseccion
                FROM dbo.Items i
                INNER JOIN dbo.SeccionSubseccion s ON i.ordenFormulario = s.ordenFormulario
                ORDER BY i.ordenFormulario, i.codigo";
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString(consulta);
            dgvItems.DataSource = dt;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Obtener el siguiente código disponible
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT ISNULL(MAX(codigo), 0) + 1 AS NuevoCodigo FROM Items");
            string nuevoCodigo = dt.Rows.Count > 0 ? dt.Rows[0]["NuevoCodigo"].ToString() : "1";

            using (var frm = new frmEdicionItemExamen())
            {
                frm.Codigo = nuevoCodigo; // Asignar el nuevo código
                frm.GuardarClick += (s, args) =>
                {
                    string insert = $"INSERT INTO Items (codigo, nombreCompleto, nombreInformes, ordenFormulario) VALUES ('{frm.Codigo}', '{frm.NombreCompleto}', '{frm.NombreInformes}', (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{frm.Seccion}' AND Subseccion = '{frm.Subseccion}'))";
                    Comunes.SQLConnector.EjecutarConsulta(insert);
                    MessageBox.Show("El ítem se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.DialogResult = DialogResult.OK;
                    frm.Close();
                    CargarItems();
                };
                frm.ShowDialog();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var row = dgvItems.SelectedRows[0];
                using (var frm = new frmEdicionItemExamen())
                {
                    frm.Load += (s, args) =>
                    {
                        frm.Codigo = row.Cells["codigo"].Value.ToString();
                        frm.NombreCompleto = row.Cells["nombreCompleto"].Value.ToString();
                        frm.NombreInformes = row.Cells["nombreInformes"].Value.ToString();
                        frm.SeleccionarSeccionYSubseccion(row.Cells["Seccion"].Value.ToString(), row.Cells["Subseccion"].Value.ToString());
                    };
                    frm.GuardarClick += (s, args) =>
                    {
                        string update = $"UPDATE Items SET nombreCompleto = '{frm.NombreCompleto}', nombreInformes = '{frm.NombreInformes}', ordenFormulario = (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{frm.Seccion}' AND Subseccion = '{frm.Subseccion}') WHERE codigo = '{frm.Codigo}'";
                        Comunes.SQLConnector.EjecutarConsulta(update);
                        MessageBox.Show("El ítem se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm.DialogResult = DialogResult.OK;
                        frm.Close();
                        CargarItems();
                    };
                    frm.ShowDialog();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string nombreCompleto = txtNombreCompleto.Text.Trim();
            string nombreInforme = txtNombreInforme.Text.Trim();
            string seccion = cboSeccion.Text.Trim();
            string subseccion = cboSubseccion.Text.Trim();
            if (panelEdicion.Tag.ToString() == "nuevo")
            {
                // INSERT
                string insert = $"INSERT INTO Items (codigo, nombreCompleto, nombreInformes, ordenFormulario) VALUES ('{codigo}', '{nombreCompleto}', '{nombreInforme}', (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{seccion}' AND Subseccion = '{subseccion}'))";
                Comunes.SQLConnector.EjecutarConsulta(insert);
            }
            else
            {
                // UPDATE
                string update = $"UPDATE Items SET nombreCompleto = '{nombreCompleto}', nombreInformes = '{nombreInforme}', ordenFormulario = (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{seccion}' AND Subseccion = '{subseccion}') WHERE codigo = '{codigo}'";
                Comunes.SQLConnector.EjecutarConsulta(update);
            }
            panelEdicion.Visible = false;
            CargarItems();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelEdicion.Visible = false;
        }

        private void LimpiarCamposEdicion()
        {
            txtCodigo.Text = "";
            txtNombreCompleto.Text = "";
            txtNombreInforme.Text = "";
            cboSeccion.SelectedIndex = -1;
            cboSubseccion.SelectedIndex = -1;
        }

        private void frmAgregaItemsExamenes_Load(object sender, EventArgs e)
        {
            // Poblar Seccion y Subseccion en los ComboBox
            DataTable dtSecciones = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT DISTINCT Seccion FROM SeccionSubseccion ORDER BY Seccion");
            cboSeccion.Items.Clear();
            foreach (DataRow row in dtSecciones.Rows)
            {
                cboSeccion.Items.Add(row["Seccion"].ToString());
            }
            cboSeccion.SelectedIndexChanged += cboSeccion_SelectedIndexChanged;
        }

        private void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Poblar Subseccion según la Seccion seleccionada
            string seccion = cboSeccion.SelectedItem?.ToString();
            MessageBox.Show($"Sección seleccionada: {seccion}", "Depuración");
            if (!string.IsNullOrEmpty(seccion))
            {
                DataTable dtSubsecciones = Comunes.SQLConnector.obtenerTablaSegunConsultaString($"SELECT Subseccion FROM SeccionSubseccion WHERE UPPER(LTRIM(RTRIM(Seccion))) = UPPER(LTRIM(RTRIM('{seccion}'))) ORDER BY Subseccion");
                MessageBox.Show($"Subsecciones encontradas: {dtSubsecciones.Rows.Count}", "Depuración");
                cboSubseccion.Items.Clear();
                foreach (DataRow row in dtSubsecciones.Rows)
                {
                    cboSubseccion.Items.Add(row["Subseccion"].ToString());
                }
            }
        }

        // Método para eliminar el ítem seleccionado
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var row = dgvItems.SelectedRows[0];
                string codigo = row.Cells["codigo"].Value.ToString();

                var confirm = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el ítem con código {codigo}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string delete = $"DELETE FROM Items WHERE codigo = '{codigo}'";
                    Comunes.SQLConnector.EjecutarConsulta(delete);
                    MessageBox.Show("El ítem se eliminó correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarItems();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ítem para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
