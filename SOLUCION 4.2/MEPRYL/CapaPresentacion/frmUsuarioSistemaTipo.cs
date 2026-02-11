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
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmUsuarioSistemaTipo :  DevExpress.XtraEditors.XtraForm
    {
        List<object> strDatos = new List<object>();
        CapaNegocioMepryl.UsuarioTipo UserSistema;
        bool blnNuevo = false;

        public frmUsuarioSistemaTipo()
        {
            InitializeComponent();

            UserSistema = new CapaNegocioMepryl.UsuarioTipo();
            ListarUsuarios();
        }

        public frmUsuarioSistemaTipo(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            UserSistema = new CapaNegocioMepryl.UsuarioTipo();            
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            ListarUsuarios();
        }

        private void CargarDatos()
        {
            strDatos.Clear();
            strDatos.Add(txtNombreTipoUsuario.Text);

            strDatos.Add(chkVentanilla.Checked);
            strDatos.Add(chkMesaEntrada.Checked);
            strDatos.Add(chkPacientes.Checked);
            strDatos.Add(chkExamenes.Checked);
            strDatos.Add(chkConfiguracion.Checked);
            strDatos.Add(chkTurnos.Checked);
            strDatos.Add(chkResumen.Checked);
            
            strDatos.Add(chkVer.Checked);
            strDatos.Add(chkModificar.Checked);
            strDatos.Add(chkEliminar.Checked);

            strDatos.Add(chkAudiometria.Checked);
        }

        private void Guardar()
        {
            CargarDatos();
            UserSistema.GuardarTipoUsuario(strDatos);
        }

        public void ListarUsuarios()
        {
            dgvLista.DataSource = UserSistema.ListarTipoUsuarios();
            cargarGrilla();
        }

        private void cargarGrilla()
        {            
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[2].Visible = false;
            dgvLista.Columns[3].Visible = false;
            dgvLista.Columns[4].Visible = false;
            dgvLista.Columns[5].Visible = false;
            dgvLista.Columns[6].Visible = false;
            dgvLista.Columns[7].Visible = false;
            dgvLista.Columns[8].Visible = false;
            dgvLista.Columns[9].Visible = false;
            dgvLista.Columns[10].Visible = false;
            dgvLista.Columns[11].Visible = false;
            dgvLista.Columns[12].Visible = false;

            dgvLista.Columns[1].HeaderText = "Tipo Usuario";
            dgvLista.Columns[1].Width = 300;
        }

        private void modoNuevo()
        {
            txtNombreTipoUsuario.Enabled = true;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            blnNuevo = true;
        }

        private void modoNormal()
        {
            txtNombreTipoUsuario.Enabled = false;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
            blnNuevo = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            
            LimpiarValores();
            txtNombreTipoUsuario.Focus();
            modoNuevo();
        }

        private void LimpiarValores()
        {
            txtNombreTipoUsuario.Text = "";

            chkVentanilla.Checked = false;
            chkMesaEntrada.Checked = false;
            chkPacientes.Checked = false;
            chkExamenes.Checked = false;
            chkConfiguracion.Checked = false;
            chkTurnos.Checked = false;
            chkResumen.Checked = false;

            chkVer.Checked = false;
            chkModificar.Checked = false;
            chkEliminar.Checked = false;
            chkAudiometria.Checked = false;
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            if (blnNuevo == true)
            {
                if (UserSistema.TipoUsuarioExiste(txtNombreTipoUsuario.Text))
                    MessageBox.Show("El Tipo de usuario existe", "Tipo Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    Guardar();
                    MessageBox.Show("Tipo de usuario creado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modoNormal();
                    txtNombreTipoUsuario.Enabled = false;
                }
            }
            else
            {
                actualizar();
                MessageBox.Show("Tipo usuario actualizado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ListarUsuarios();
        }

        private void actualizar()
        {
            int intID = 0;
            CargarDatos();

            intID = Convert.ToInt32( dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[0].Value.ToString());
            UserSistema.ActualizarTipoUsuario(intID, strDatos);
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                txtNombreTipoUsuario.Text = dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[1].Value.ToString();
                chkVentanilla.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[2].Value.ToString());
                chkMesaEntrada.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[3].Value.ToString());
                chkPacientes.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[4].Value.ToString());
                chkExamenes.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[5].Value.ToString());
                chkConfiguracion.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[6].Value.ToString());
                chkTurnos.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[7].Value.ToString());
                chkResumen.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[8].Value.ToString());

                chkVer.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[9].Value.ToString());
                chkModificar.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[10].Value.ToString());
                chkEliminar.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[11].Value.ToString());

                chkAudiometria.Checked = Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[12].Value.ToString());
            }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            modoNormal();
            dgvLista_SelectionChanged(sender, e);
            this.Close();
        }

        private void frmUsuarioSistemaTipo_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultExamen = MessageBox.Show("¿Desea borrar este tipo de usuario?", "Tipos de usuario",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultExamen == DialogResult.Yes)
            {
                UserSistema.BorrarTipoUsuario(int.Parse(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                MessageBox.Show("Tipo de usuario borrado correctamente", "Tipos de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarUsuarios();
                modoNormal();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
