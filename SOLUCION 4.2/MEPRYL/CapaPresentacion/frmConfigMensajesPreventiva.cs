using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigMensajesPreventiva : DevExpress.XtraEditors.XtraForm
    {
        List<object> strDatos = new List<object>();
        CapaNegocioMepryl.ConfigMensajesCorreo CorreosPreventiva = new CapaNegocioMepryl.ConfigMensajesCorreo();
        CapaNegocioMepryl.ConfigPlantillaReporte Reporte = new CapaNegocioMepryl.ConfigPlantillaReporte();
        bool blnNuevo = false;

        // Datos de cascada: MotivoConsulta → TipoExamen (Padre=1) → Subtipo (Padre=0)
        private DataTable dtMotivosConsulta;
        private DataTable dtTiposExamen;
        private DataTable dtSubtipos;
        private string strIdMotivoSeleccionado;
        private CapaNegocioMepryl.TipoExamen tipoExamen = new CapaNegocioMepryl.TipoExamen();

        public frmConfigMensajesPreventiva()
        {
            InitializeComponent();
            Inicializar();
        }

        public frmConfigMensajesPreventiva(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            Inicializar();
        }

        private void CargarMotivosConsulta()
        {
            dtMotivosConsulta = tipoExamen.cargarMotivosDeConsulta();
            cmbMotivoConsulta.Items.Clear();
            foreach (DataRow row in dtMotivosConsulta.Rows)
                cmbMotivoConsulta.Items.Add(row["nombre"].ToString());
            if (cmbMotivoConsulta.Items.Count > 0)
                cmbMotivoConsulta.SelectedIndex = 0; // dispara cmbMotivoConsulta_SelectedIndexChanged → CargarTiposExamen
        }

        private void cmbMotivoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTiposExamen();
        }

        private void CargarTiposExamen()
        {
            if (cmbMotivoConsulta.SelectedIndex < 0 || dtMotivosConsulta == null) return;
            strIdMotivoSeleccionado = dtMotivosConsulta.Rows[cmbMotivoConsulta.SelectedIndex]["id"].ToString();

            dtTiposExamen = tipoExamen.cargarTiposDeExamenPadre(strIdMotivoSeleccionado);
            cmbTipoExamen.Items.Clear();
            foreach (DataRow row in dtTiposExamen.Rows)
                cmbTipoExamen.Items.Add(row["descripcion"].ToString());
            if (cmbTipoExamen.Items.Count > 0)
                cmbTipoExamen.SelectedIndex = 0; // dispara cmbTipoExamen_SelectedIndexChanged → CargarSubtipos
        }

        private void CargarSubtipos(string idPadre)
        {
            dtSubtipos = tipoExamen.cargarTiposDeExamenHijo(strIdMotivoSeleccionado, idPadre);
            cmbSubtipos.Items.Clear();
            foreach (DataRow row in dtSubtipos.Rows)
                cmbSubtipos.Items.Add(row["descripcion"].ToString());
            if (cmbSubtipos.Items.Count > 0)
                cmbSubtipos.SelectedIndex = 0; // dispara cmbSubtipos_SelectedIndexChanged → CargarArchivoDelSubtipoSeleccionado
            else
            {
                txtUbicacionArchivoTurno.Text = string.Empty;
                txtArchivoTextoTurnos.Text = string.Empty;
            }
        }

        private string GetIdSubtipoSeleccionado()
        {
            if (cmbSubtipos.SelectedIndex < 0 || dtSubtipos == null || dtSubtipos.Rows.Count == 0)
                return string.Empty;
            return dtSubtipos.Rows[cmbSubtipos.SelectedIndex]["id"].ToString();
        }

        private void cmbTipoExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoExamen.SelectedIndex < 0 || dtTiposExamen == null) return;
            string idPadre = dtTiposExamen.Rows[cmbTipoExamen.SelectedIndex]["id"].ToString();
            CargarSubtipos(idPadre);
        }

        private void cmbSubtipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarArchivoDelSubtipoSeleccionado();
        }

        private const string STR_RUTA_DEFAULT           = @"P:\Temporal\PLANTILLA REPORTE INFORMES";
        private const string STR_RUTA_PREVENTIVA        = @"P:\Temporal\PLANTILLA REPORTE INFORMES\Preventiva";
        private const string STR_RUTA_LABORAL           = @"P:\Temporal\PLANTILLA REPORTE INFORMES\Laboral";

        private string GetRutaDefault() => EsMotivoLaboral() ? STR_RUTA_LABORAL : STR_RUTA_PREVENTIVA;

        private bool EsMotivoLaboral()
        {
            if (cmbMotivoConsulta.SelectedIndex < 0 || dtMotivosConsulta == null) return false;
            string nombre = dtMotivosConsulta.Rows[cmbMotivoConsulta.SelectedIndex]["nombre"].ToString().ToUpper();
            return nombre == "LABORAL";
        }

        private void CargarArchivoDelSubtipoSeleccionado()
        {
            if (cmbSubtipos.SelectedIndex < 0 || dtSubtipos == null || dtSubtipos.Rows.Count == 0) return;
            string idSubtipo = dtSubtipos.Rows[cmbSubtipos.SelectedIndex]["id"].ToString();
            string path = EsMotivoLaboral()
                ? Reporte.GetPathMensajePorSubtipoLaboral(idSubtipo)
                : Reporte.GetPathMensajePorSubtipo(idSubtipo);

            string rutaCorrecta = GetRutaDefault();

            // Migrar paths antiguos (guardados en la raíz) al subfolder (Preventiva / Laboral)
            if (!string.IsNullOrEmpty(path))
            {
                string dir = System.IO.Path.GetDirectoryName(path) ?? "";
                if (!string.Equals(dir, rutaCorrecta, StringComparison.OrdinalIgnoreCase))
                    path = System.IO.Path.Combine(rutaCorrecta, System.IO.Path.GetFileName(path));
            }

            if (string.IsNullOrEmpty(path))
            {
                string nombreSubtipo = dtSubtipos.Rows[cmbSubtipos.SelectedIndex]["descripcion"].ToString();
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    nombreSubtipo = nombreSubtipo.Replace(c.ToString(), "");
                path = System.IO.Path.Combine(rutaCorrecta, "PlantillaMensajeTurnos" + nombreSubtipo + ".txt");
            }
            txtUbicacionArchivoTurno.Text = path;
            if (System.IO.File.Exists(path))
                MostrarArchivoTextBox();
            else
                txtArchivoTextoTurnos.Text = string.Empty;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            blnNuevo = true;
            txtNombreCorreo.Enabled = true;
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (tbcCorreoE.SelectedTab == tabPage4)
            {
                if (blnNuevo == true)
                {
                    GuardarDatosCorreo();
                    MessageBox.Show("El correo se creado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    blnNuevo = false;
                    txtNombreCorreo.Enabled = false;
                }
                else
                {
                    ActualizarDatosCorreo();
                    MessageBox.Show("El correo se actualizado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarGrilla();
            }

            if (tbcCorreoE.SelectedTab == tpgMensajeTurno)
            {
                string idSubtipo = GetIdSubtipoSeleccionado();
                if (!string.IsNullOrEmpty(idSubtipo))
                {
                    if (EsMotivoLaboral())
                        Reporte.GuardarPathMensajePorSubtipoLaboral(idSubtipo, txtUbicacionArchivoTurno.Text);
                    else
                        Reporte.GuardarPathMensajePorSubtipo(idSubtipo, txtUbicacionArchivoTurno.Text);
                    GuardarArchivoTextbox();
                    MessageBox.Show("Plantilla guardada correctamente.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GuardarDatosCorreo()
        {
            CargarDatos();
            CorreosPreventiva.GuardarCorreo(strDatos);
        }

        private void CargarDatos()
        {
            strDatos.Clear();

            strDatos.Add(txtNombreCorreo.Text);
            strDatos.Add(txtCorreo01.Text);
            strDatos.Add(txtContrasenia01.Text);
            strDatos.Add(txtSmtp01.Text);
            strDatos.Add(txtPuertoSmtp01.Text);
            strDatos.Add(chkSsl01.Checked);
            strDatos.Add(nudTiempoEnvio.Value.ToString());
            strDatos.Add(txtNombreUsuario.Text);

            strDatos.Add(txtAsunto.Text);
            strDatos.Add(chkAdjuntos.Checked);
            strDatos.Add(txtMensaje.Text);
            strDatos.Add(txtCabecera.Text);
            strDatos.Add(txtPie.Text);
            strDatos.Add("P");
        }

        private void CargarGrilla()
        {
            dgvCorreos.DataSource = null;
            dgvCorreos.DataSource = CorreosPreventiva.ListarNombreCorreosPrevetniva("P");
            dgvCorreos.Columns[0].Visible = false;
            dgvCorreos.Columns[2].Visible = false;

            dgvCorreos.Columns[1].Width = 200;
        }

        private void Inicializar()
        {
            CargarGrilla();
            txtNombreCorreo.Enabled = false;
            CargarMotivosConsulta(); // carga motivos → dispara cascada TipoExamen→Subtipo
            tbcCorreoE.SelectedTab = tabPage4;
        }

        private void dgvLista_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatosDeCorreo(Convert.ToInt32(dgvCorreos.Rows[dgvCorreos.CurrentCell.RowIndex].Cells[0].Value.ToString()));
            }
            catch (System.NullReferenceException ex)
            {

            }
        }

        private void CargarDatosDeCorreo(int intID)
        {
            DataTable dt = null;
            dt = CorreosPreventiva.ListarCorreosIdPreventiva(intID, "P");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtNombreCorreo.Text = dt.Rows[i][1].ToString();
                    txtCorreo01.Text = dt.Rows[i][2].ToString();
                    txtContrasenia01.Text = dt.Rows[i][3].ToString();
                    txtSmtp01.Text = dt.Rows[i][4].ToString();
                    txtPuertoSmtp01.Text = dt.Rows[i][5].ToString();
                    chkSsl01.Checked = Convert.ToBoolean(dt.Rows[i][6].ToString());
                    nudTiempoEnvio.Value = Convert.ToInt32(dt.Rows[i][7].ToString());
                    txtNombreUsuario.Text = dt.Rows[i][8].ToString();
                    txtAsunto.Text = dt.Rows[i][9].ToString();
                    chkAdjuntos.Checked = Convert.ToBoolean(dt.Rows[i][10].ToString());
                    txtMensaje.Text = dt.Rows[i][11].ToString();
                    txtCabecera.Text = dt.Rows[i][12].ToString();
                    txtPie.Text = dt.Rows[i][13].ToString();
                }
            }
        }

        private void ActualizarDatosCorreo()
        {
            int intID = Convert.ToInt32(dgvCorreos.Rows[dgvCorreos.CurrentCell.RowIndex].Cells[0].Value.ToString());
            CargarDatos();
            CorreosPreventiva.ActualizarCorreo(intID, strDatos);
        }

        private void btnUbicarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();
            fbdMostrarDirectorio.Filter = "Archivos txt (*.txt)|*.txt|All files (*.*)|*.*";
            fbdMostrarDirectorio.FilterIndex = 2;
            fbdMostrarDirectorio.RestoreDirectory = true;
            fbdMostrarDirectorio.Title = "Seleccione un archivo";
            fbdMostrarDirectorio.InitialDirectory = GetRutaDefault();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtUbicacionArchivoTurno.Text = fbdMostrarDirectorio.FileName;
                MostrarArchivoTextBox();
            }
        }

        private void MostrarArchivoTextBox()
        {
            txtArchivoTextoTurnos.Text = System.IO.File.ReadAllText(txtUbicacionArchivoTurno.Text);
        }

        private void GuardarArchivoTextbox()
        {
            System.IO.File.WriteAllText(txtUbicacionArchivoTurno.Text, txtArchivoTextoTurnos.Text);
        }

        private void tbcCorreoE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcCorreoE.SelectedIndex == 0)
            {
                btnNuevo.Enabled = false;
            }
            else
            {
                btnNuevo.Enabled = true;
            }
        }

    }
}
