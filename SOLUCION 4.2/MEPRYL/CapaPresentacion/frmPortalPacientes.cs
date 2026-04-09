using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmPortalPacientes : DevExpress.XtraEditors.XtraForm
    {
        private const string PLACEHOLDER_BUSQUEDA = "Buscar por DNI, apellido o nombre...";
        private bool isPlaceholder = true;
        private Timer timerBusqueda;
        private bool inicializado = false;

        public frmPortalPacientes()
        {
            InitializeComponent();
            // Placeholder manual para .NET Framework 4.8
            tbBusqueda.Text = PLACEHOLDER_BUSQUEDA;
            tbBusqueda.ForeColor = Color.Gray;
            tbBusqueda.GotFocus += tbBusqueda_GotFocus;
            tbBusqueda.LostFocus += tbBusqueda_LostFocus;
            // Timer para no consultar en cada tecla
            timerBusqueda = new Timer();
            timerBusqueda.Interval = 500;
            timerBusqueda.Tick += (s, ev) => { timerBusqueda.Stop(); cargarPacientes(); };
            inicializado = true;
        }

        private void tbBusqueda_GotFocus(object sender, EventArgs e)
        {
            if (isPlaceholder)
            {
                tbBusqueda.Text = "";
                tbBusqueda.ForeColor = Color.Black;
                isPlaceholder = false;
            }
        }

        private void tbBusqueda_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbBusqueda.Text))
            {
                tbBusqueda.Text = PLACEHOLDER_BUSQUEDA;
                tbBusqueda.ForeColor = Color.Gray;
                isPlaceholder = true;
            }
        }

        private void frmPortalPacientes_Load(object sender, EventArgs e)
        {
            cargarPacientesConAcceso();
        }

        private void cargarPacientesConAcceso()
        {
            string sql = @"
                SELECT u.dni, u.apellido, u.nombre, 
                       CASE WHEN u.Tipo = 'PACIENTE LABORAL' THEN 'Laboral' ELSE 'Preventiva' END AS tipo,
                       'SI' AS tieneAcceso,
                       u.username,
                       u.password AS passwordEnc
                FROM dbo.Usuario u
                WHERE u.Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA') AND u.Activo = 1
                ORDER BY u.apellido, u.nombre";

            try
            {
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);
                llenarGrilla(dt);
                lblInfo.Text = dt.Rows.Count + " pacientes con acceso al portal";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarPacientes()
        {
            string filtroTipo = "";
            string filtroBusqueda = isPlaceholder ? "" : tbBusqueda.Text.Trim().Replace("'", "");

            if (string.IsNullOrEmpty(filtroBusqueda))
            {
                cargarPacientesConAcceso();
                return;
            }

            switch (cboTipoPaciente.SelectedIndex)
            {
                case 1: filtroTipo = "AND tipo = 'Laboral'"; break;
                case 2: filtroTipo = "AND tipo = 'Preventiva'"; break;
            }

            string filtroBusq = string.Format(
                "AND (p.dni LIKE '%{0}%' OR p.apellido LIKE '%{0}%' OR p.nombre LIKE '%{0}%')",
                filtroBusqueda);

            string sql = string.Format(@"
                SELECT TOP 100 p.dni, p.apellido, p.nombre, p.tipo,
                       CASE WHEN u.id IS NOT NULL THEN 'SI' ELSE 'NO' END AS tieneAcceso,
                       ISNULL(u.username, '') AS username,
                       ISNULL(u.password, '') AS passwordEnc
                FROM (
                    SELECT dni, apellido, nombres AS nombre, 'Laboral' AS tipo FROM dbo.PacienteLaboral WHERE dni IS NOT NULL AND dni <> ''
                    UNION ALL
                    SELECT dni, apellido, nombres AS nombre, 'Preventiva' AS tipo FROM dbo.Paciente WHERE dni IS NOT NULL AND dni <> ''
                ) p
                LEFT JOIN dbo.Usuario u ON u.dni = p.dni AND u.Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA')
                WHERE 1=1 {0} {1}
                ORDER BY p.apellido, p.nombre",
                filtroTipo, filtroBusq);

            try
            {
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);
                llenarGrilla(dt);
                lblInfo.Text = dt.Rows.Count + " pacientes encontrados" + (dt.Rows.Count == 100 ? " (máx. 100)" : "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarGrilla(DataTable dt)
        {
            dgvPacientes.SuspendLayout();
            dgvPacientes.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string passwordDesencriptada = "";
                string passEnc = row["passwordEnc"].ToString();
                if (!string.IsNullOrEmpty(passEnc))
                {
                    try { passwordDesencriptada = Utilidades.desencriptar(passEnc); }
                    catch { passwordDesencriptada = "***"; }
                }

                int idx = dgvPacientes.Rows.Add(
                    row["dni"].ToString(),
                    row["apellido"].ToString(),
                    row["nombre"].ToString(),
                    row["tipo"].ToString(),
                    row["tieneAcceso"].ToString(),
                    row["username"].ToString(),
                    passwordDesencriptada
                );

                if (row["tieneAcceso"].ToString() == "SI")
                {
                    dgvPacientes.Rows[idx].Cells[4].Style.BackColor = Color.FromArgb(200, 240, 200);
                    dgvPacientes.Rows[idx].Cells[4].Style.ForeColor = Color.FromArgb(30, 130, 50);
                }
                else
                {
                    dgvPacientes.Rows[idx].Cells[4].Style.BackColor = Color.FromArgb(255, 220, 220);
                    dgvPacientes.Rows[idx].Cells[4].Style.ForeColor = Color.FromArgb(180, 50, 50);
                }

                if (row["tipo"].ToString() == "Laboral")
                    dgvPacientes.Rows[idx].Cells[3].Style.ForeColor = Color.FromArgb(200, 80, 0);
                else
                    dgvPacientes.Rows[idx].Cells[3].Style.ForeColor = Color.FromArgb(0, 120, 50);
            }

            dgvPacientes.ResumeLayout();
        }

        private void btnGenerarAcceso_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente de la lista.", "Portal Pacientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = dgvPacientes.SelectedRows[0];
            string dni = row.Cells[0].Value.ToString();
            string apellido = row.Cells[1].Value.ToString();
            string nombre = row.Cells[2].Value.ToString();
            string tipo = row.Cells[3].Value.ToString();
            string tieneAcceso = row.Cells[4].Value.ToString();

            if (tieneAcceso == "SI")
            {
                DialogResult rpta = MessageBox.Show(
                    "Este paciente ya tiene acceso al portal.\n\n" +
                    "¿Desea regenerar la contraseña?",
                    "Portal Pacientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rpta == DialogResult.No) return;

                // Regenerar contraseña
                string nuevaPass = generarPassword();
                string passEncriptada = Utilidades.encriptar(nuevaPass);

                SQLConnector.EjecutarConsulta(string.Format(
                    "UPDATE dbo.Usuario SET password = '{0}' WHERE dni = '{1}' AND Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA')",
                    passEncriptada, dni));

                mostrarCredenciales(dni, apellido, nombre, row.Cells[5].Value.ToString(), nuevaPass);
                cargarPacientes();
                return;
            }

            // Crear nuevo acceso
            string password = generarPassword();
            string passwordEnc = Utilidades.encriptar(password);
            string username = nombre.Split(' ')[0].ToLower().Replace(" ", "") + "." + apellido.ToLower().Replace(" ", "");
            string tipoUsuario = tipo == "Laboral" ? "PACIENTE LABORAL" : "PACIENTE PREVENTIVA";

            // Verificar que no exista ya el username
            DataTable dtCheck = SQLConnector.obtenerTablaSegunConsultaString(
                "SELECT COUNT(*) FROM dbo.Usuario WHERE username = '" + username.Replace("'", "") + "'");
            if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
            {
                username = username + dni.Substring(dni.Length - 3);
            }

            string sqlInsert = string.Format(@"
                INSERT INTO dbo.Usuario 
                (id, username, password, apellido, nombre, Tipo, Activo, dni,
                 VentConfiguracion, VentExamenes, VentMesa, VentPacientes, 
                 VentVentanilla, VentResumen, PermisoVer, PermisoModificar, 
                 PermisoEliminar, VentTurnos, VentAudiometria, VentFacturacion)
                VALUES 
                (NEWID(), '{0}', '{1}', '{2}', '{3}', '{4}', 1, '{5}',
                 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0)",
                username.Replace("'", ""), 
                passwordEnc, 
                apellido.Replace("'", "''"), 
                nombre.Replace("'", "''"), 
                tipoUsuario, 
                dni);

            try
            {
                SQLConnector.EjecutarConsulta(sqlInsert);
                mostrarCredenciales(dni, apellido, nombre, username, password);
                cargarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear acceso:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerCredenciales_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente de la lista.", "Portal Pacientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = dgvPacientes.SelectedRows[0];
            string tieneAcceso = row.Cells[4].Value.ToString();

            if (tieneAcceso != "SI")
            {
                MessageBox.Show("Este paciente no tiene acceso al portal.\nUse 'Generar Acceso' primero.",
                    "Portal Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mostrarCredenciales(
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[5].Value.ToString(),
                row.Cells[6].Value.ToString()
            );
        }

        private void mostrarCredenciales(string dni, string apellido, string nombre, string username, string password)
        {
            string mensaje = string.Format(
                "╔══════════════════════════════════╗\n" +
                "║   CREDENCIALES PORTAL PACIENTES   ║\n" +
                "╠══════════════════════════════════╣\n" +
                "║                                                        ║\n" +
                "║  Paciente: {0} {1}\n" +
                "║  DNI: {2}\n" +
                "║                                                        ║\n" +
                "║  Usuario: {3}\n" +
                "║  Contraseña: {4}\n" +
                "║                                                        ║\n" +
                "║  Ingresar en: http://SERVIDOR:3000  ║\n" +
                "╚══════════════════════════════════╝",
                apellido, nombre, dni, username, password);

            MessageBox.Show(mensaje, "Credenciales de Acceso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string generarPassword()
        {
            const string chars = "abcdefghjkmnpqrstuvwxyz23456789";
            Random random = new Random();
            char[] password = new char[8];
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return new string(password);
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (!inicializado) return;
            timerBusqueda.Stop();
            timerBusqueda.Start();
        }

        private void cboTipoPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inicializado) return;
            cargarPacientes();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
