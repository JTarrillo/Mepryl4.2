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
    public partial class frmConfigMensajesLaboral : DevExpress.XtraEditors.XtraForm
    {
        List<object> strDatos = new List<object>();
        CapaNegocioMepryl.ConfigMensajesCorreo Mensajes;
        bool blnNuevo = false;

        public frmConfigMensajesLaboral()
        {
            InitializeComponent();
            Mensajes = new CapaNegocioMepryl.ConfigMensajesCorreo();
            Inicializar();
        }

        public frmConfigMensajesLaboral(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            Mensajes = new CapaNegocioMepryl.ConfigMensajesCorreo();
            Inicializar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            blnNuevo = true;
            txtNombreCorreo.Enabled = true;
        }

        private void botGuardar_Click(object sender, EventArgs e)
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

        private void GuardarDatosCorreo()
        {
            CargarDatos();
            Mensajes.GuardarCorreo(strDatos);
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
            strDatos.Add("L");
        }

        private void CargarGrilla()
        {
            dgvLista.DataSource = Mensajes.ListarNombreCorreos("L");
            dgvLista.Columns[0].Visible = false;            
            dgvLista.Columns[2].Visible = false;

            dgvLista.Columns[1].Width = 200;
        }

        private void Inicializar()
        {
            CargarGrilla();
            txtNombreCorreo.Enabled = false;
        }

        private void dgvLista_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatosDeCorreo(Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[0].Value.ToString()));
            }
            catch (System.NullReferenceException ex)
            {
                
            }
        }

        private void CargarDatosDeCorreo(int intID)
        {
            DataTable dt = null;
            dt = Mensajes.ListarCorreosId(intID, "L");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtNombreCorreo.Text = dt.Rows[i][1].ToString();
                    txtCorreo01.Text = dt.Rows[i][2].ToString();
                    txtContrasenia01.Text = dt.Rows[i][3].ToString();
                    txtSmtp01.Text = dt.Rows[i][4].ToString();
                    txtPuertoSmtp01.Text = dt.Rows[i][5].ToString();
                    chkSsl01.Checked = Convert.ToBoolean( dt.Rows[i][6].ToString());
                    nudTiempoEnvio.Value = Convert.ToInt32(dt.Rows[i][7].ToString());
                    txtNombreUsuario.Text = dt.Rows[i][8].ToString();
                    txtAsunto.Text = dt.Rows[i][9].ToString();
                    chkAdjuntos.Checked = Convert.ToBoolean( dt.Rows[i][10].ToString());
                    txtMensaje.Text = dt.Rows[i][11].ToString();
                    txtCabecera.Text = dt.Rows[i][12].ToString();
                    txtPie.Text = dt.Rows[i][13].ToString();
                }
            }
        }

        private void ActualizarDatosCorreo()
        {
            int intID = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells[0].Value.ToString());
            CargarDatos();
            Mensajes.ActualizarCorreo(intID, strDatos);           
        }

        
    }
}
