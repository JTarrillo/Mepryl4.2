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

            // 🔍 DEBUG: Ver cuántos items hay
            DebugCargarItems(dt);
        }

        private void DebugCargarItems(DataTable dt)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("══════════════════════════════════════════");
                System.Diagnostics.Debug.WriteLine($"📊 [DEBUG] ITEMS CARGADOS: Total = {dt.Rows.Count}");
                System.Diagnostics.Debug.WriteLine("══════════════════════════════════════════");

                // Agrupar por sección
                var seccionesunicas = new System.Collections.Generic.Dictionary<string, int>();
                var sectores = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>();

                foreach (DataRow row in dt.Rows)
                {
                    string seccion = row["Seccion"]?.ToString() ?? "SIN SECCIÓN";
                    string subseccion = row["Subseccion"]?.ToString() ?? "SIN SUBSECCIÓN";
                    string codigo = row["codigo"]?.ToString() ?? "SIN CÓDIGO";
                    string nombre = row["nombreCompleto"]?.ToString() ?? "SIN NOMBRE";

                    if (!seccionesunicas.ContainsKey(seccion))
                    {
                        seccionesunicas[seccion] = 0;
                        sectores[seccion] = new System.Collections.Generic.List<string>();
                    }

                    seccionesunicas[seccion]++;
                    sectores[seccion].Add($"[{codigo}] {nombre}");
                }

                // Mostrar resumen por sección
                System.Diagnostics.Debug.WriteLine("📋 RESUMEN POR SECCIÓN:");
                foreach (var sec in seccionesunicas)
                {
                    System.Diagnostics.Debug.WriteLine($"  ✅ {sec.Key}: {sec.Value} items");
                }

                // Mostrar detalles completos
                System.Diagnostics.Debug.WriteLine("\n📝 DETALLE COMPLETO:");
                int conteo = 1;
                foreach (DataRow row in dt.Rows)
                {
                    string codigo = row["codigo"]?.ToString() ?? "SIN CÓDIGO";
                    string nombre = row["nombreCompleto"]?.ToString() ?? "SIN NOMBRE";
                    string seccion = row["Seccion"]?.ToString() ?? "SIN SECCIÓN";
                    string subseccion = row["Subseccion"]?.ToString() ?? "SIN SUBSECCIÓN";

                    System.Diagnostics.Debug.WriteLine($"  {conteo}. [{codigo}] {nombre} ({seccion} / {subseccion})");
                    conteo++;
                }

                System.Diagnostics.Debug.WriteLine("══════════════════════════════════════════");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ [DEBUG] Error en DebugCargarItems: {ex.Message}");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // ✅ CORREGIDO: Buscar el PRIMER código disponible (llenar huecos)
            // Método simple: obtener todos los códigos, ordenar, y encontrar el primer hueco
            string consultaObtenerCodigos = @"
                SELECT CAST(codigo AS INT) AS cod 
                FROM Items 
                WHERE ISNUMERIC(codigo) = 1 
                ORDER BY CAST(codigo AS INT)";

            DataTable dtCodigos = Comunes.SQLConnector.obtenerTablaSegunConsultaString(consultaObtenerCodigos);

            int nuevoCodigo = 1;
            if (dtCodigos.Rows.Count > 0)
            {
                // Buscar el primer hueco
                foreach (DataRow row in dtCodigos.Rows)
                {
                    int codigoExistente = Convert.ToInt32(row["cod"]);
                    if (codigoExistente == nuevoCodigo)
                    {
                        nuevoCodigo++;
                    }
                    else if (codigoExistente > nuevoCodigo)
                    {
                        // Encontramos un hueco
                        break;
                    }
                }
            }

            // 🔍 DEBUG: Ver qué código se está asignando
            System.Diagnostics.Debug.WriteLine($"🆕 [NUEVO ITEM] Código asignado (llenar huecos): {nuevoCodigo}");

            using (var frm = new frmEdicionItemExamen())
            {
                frm.Codigo = nuevoCodigo.ToString(); // Asignar el nuevo código (convertir a string)
                frm.GuardarClick += (s, args) =>
                {
                    // ✅ PREVENIR SQL INJECTION
                    string codigoSeguro = frm.Codigo.Replace("'", "''");
                    string nombreSeguro = frm.NombreCompleto.Replace("'", "''");
                    string informesSeguro = frm.NombreInformes.Replace("'", "''");
                    string seccionSegura = frm.Seccion.Replace("'", "''");
                    string subseccionSegura = frm.Subseccion.Replace("'", "''");

                    string insert = $"INSERT INTO Items (codigo, nombreCompleto, nombreInformes, ordenFormulario) VALUES ('{codigoSeguro}', '{nombreSeguro}', '{informesSeguro}', (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{seccionSegura}' AND Subseccion = '{subseccionSegura}'))";
                    Comunes.SQLConnector.EjecutarConsulta(insert);
                    MessageBox.Show("El ítem se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Debug.WriteLine($"✅ [NUEVO ITEM] Item guardado: [{nuevoCodigo}] {frm.NombreCompleto} en {frm.Seccion}/{frm.Subseccion}");
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
                        // ✅ PREVENIR SQL INJECTION
                        string codigoSeguro = frm.Codigo.Replace("'", "''");
                        string nombreSeguro = frm.NombreCompleto.Replace("'", "''");
                        string informesSeguro = frm.NombreInformes.Replace("'", "''");
                        string seccionSegura = frm.Seccion.Replace("'", "''");
                        string subseccionSegura = frm.Subseccion.Replace("'", "''");

                        string update = $"UPDATE Items SET nombreCompleto = '{nombreSeguro}', nombreInformes = '{informesSeguro}', ordenFormulario = (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{seccionSegura}' AND Subseccion = '{subseccionSegura}') WHERE codigo = '{codigoSeguro}'";
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

            // ✅ PREVENIR SQL INJECTION
            string codigoSeguro = codigo.Replace("'", "''");
            string nombreSeguro = nombreCompleto.Replace("'", "''");
            string informeSeguro = nombreInforme.Replace("'", "''");
            string seccionSegura = seccion.Replace("'", "''");
            string subseccionSegura = subseccion.Replace("'", "''");

            if (panelEdicion.Tag.ToString() == "nuevo")
            {
                // INSERT
                string insert = $"INSERT INTO Items (codigo, nombreCompleto, nombreInformes, ordenFormulario) VALUES ('{codigoSeguro}', '{nombreSeguro}', '{informeSeguro}', (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{seccionSegura}' AND Subseccion = '{subseccionSegura}'))";
                Comunes.SQLConnector.EjecutarConsulta(insert);
            }
            else
            {
                // UPDATE
                string update = $"UPDATE Items SET nombreCompleto = '{nombreSeguro}', nombreInformes = '{informeSeguro}', ordenFormulario = (SELECT TOP 1 ordenFormulario FROM SeccionSubseccion WHERE Seccion = '{seccionSegura}' AND Subseccion = '{subseccionSegura}') WHERE codigo = '{codigoSeguro}'";
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
                    // ✅ PREVENIR SQL INJECTION
                    string codigoSeguro = codigo.Replace("'", "''");
                    string delete = $"DELETE FROM Items WHERE codigo = '{codigoSeguro}'";
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
