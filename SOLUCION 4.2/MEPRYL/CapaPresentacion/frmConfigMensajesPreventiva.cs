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

        public frmConfigMensajesPreventiva()
        {
            InitializeComponent();
            //CorreosPreventiva = new CapaNegocioMepryl.ConfigMensajesCorreo();
            Inicializar();
        }

        public frmConfigMensajesPreventiva(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            //CorreosPreventiva = new CapaNegocioMepryl.ConfigMensajesCorreo();
            Inicializar();
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
                if (rbtOpcionMensaje01.Checked)
                {
                    ActualizaPathArchivoMensajeTurno();
                    GuardarArchivoTextbox();
                }
                else if (rbtOpcionMensaje02.Checked)
                {
                    ActualizaPathArchivoMensajeTurno2();
                    GuardarArchivoTextbox();
                }
                else if (rbtOpcionMensaje03.Checked)
                {
                    ActualizaPathArchivoMensajeTurno3();
                    GuardarArchivoTextbox();
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
            RepuperaArchivoTextoTurno();
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
            System.IO.File.WriteAllText(@txtUbicacionArchivoTurno.Text, txtArchivoTextoTurnos.Text);
        }

        private void ActualizaPathArchivoMensajeTurno()
        {
            Reporte.ActualizaMensajeTurno('P', txtUbicacionArchivoTurno.Text);
        }

        private void ActualizaPathArchivoMensajeTurno2()
        {
            Reporte.ActualizaMensajeTurno2('P', txtUbicacionArchivoTurno.Text);
        }

        private void ActualizaPathArchivoMensajeTurno3()
        {
            Reporte.ActualizaMensajeTurno3('P', txtUbicacionArchivoTurno.Text);
        }

        private void RepuperaArchivoTextoTurno()
        {
            DataTable dt = null;

            if (rbtOpcionMensaje01.Checked)
            {
                 dt = Reporte.ListarPlantillas("P");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txtUbicacionArchivoTurno.Text = dt.Rows[i][8].ToString();
                        MostrarArchivoTextBox();
                    }
                }
            }
            else if(rbtOpcionMensaje02.Checked)
            {
                dt = Reporte.ListarPlantillas("P");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txtUbicacionArchivoTurno.Text = dt.Rows[i][9].ToString();
                        MostrarArchivoTextBox();
                    }
                }
            }else if (rbtOpcionMensaje03.Checked)
            {
                dt = Reporte.ListarPlantillas("P");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txtUbicacionArchivoTurno.Text = dt.Rows[i][10].ToString();
                        MostrarArchivoTextBox();
                    }
                }
            }

            
        }

        private void rbtOpcionMensaje01_CheckedChanged(object sender, EventArgs e)
        {
            RepuperaArchivoTextoTurno();
        }

        private void rbtOpcionMensaje02_CheckedChanged(object sender, EventArgs e)
        {
            RepuperaArchivoTextoTurno();
        }

        private void rbtOpcionMensaje03_CheckedChanged(object sender, EventArgs e)
        {
            RepuperaArchivoTextoTurno();
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
