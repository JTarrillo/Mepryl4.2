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
using Comunes;
using System.IO;

namespace CapaPresentacion
{
    public partial class frmUsuariosSistema : DevExpress.XtraEditors.XtraForm
    {
        List<object> strDatos = new List<object>();
        CapaNegocioMepryl.UsuarioSistema UserSistema;
        CapaNegocioMepryl.UsuarioTipo TipoUsuario;
        private CapaNegocioMepryl.UbicacionFotos DirectorioFotos;

        bool blnNuevo = false;

        bool blnVConfiguracion, blnVExamenes, blnVMesa, blnVPacientes, blnVVentanilla, blnVResumen, blnVTurno, blnVerAudio, blnVFacturacion;
        bool blnPVer, blnPModificar, blnPEliminar;
        int intFilaSelecc = 0;
        bool blnEstadoInicial = false;

        public frmUsuariosSistema()
        {
            InitializeComponent();
            UserSistema = new UsuarioSistema();
            TipoUsuario = new CapaNegocioMepryl.UsuarioTipo();
            DirectorioFotos = new UbicacionFotos();
            //ListarUsuarios();
            cargarGrilla();
        }

        public frmUsuariosSistema(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            UserSistema = new CapaNegocioMepryl.UsuarioSistema();
            TipoUsuario = new CapaNegocioMepryl.UsuarioTipo();
            DirectorioFotos = new UbicacionFotos();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            //ListarUsuarios();
            cargarGrilla();
            CargarDatosDGV();
        }

        private void btnPortal_Click(object sender, EventArgs e)
        {
            frmPortalPacientes frm = new frmPortalPacientes();
            frm.ShowDialog();
        }

        private void actualizar()
        {
            string strID = "";
            CargarDatos();
            
            /*if (dgv.CurrentCell.RowIndex > 0)
            {
                strID = dgv.Rows[dgv.CurrentCell.RowIndex - 1].Cells[0].Value.ToString();
            }
            else
            {
                strID = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }*/
            strID = dgv.Rows[intFilaSelecc].Cells[0].Value.ToString();

            UserSistema.ActualizarUsuario(strID, strDatos);

            if (cmbTipoUsuario.Text == "MEDICOS")
            {
                UserSistema.ActualizaProfesionalAsignado(txtDNI.Text);
            }

            RefrescarImagenLinkDGV();
        }

        private void Guardar()
        {
            CargarDatos();
            UserSistema.GuardarUsuario(strDatos);

            if (cmbTipoUsuario.Text == "MEDICOS")
            {
                UserSistema.ActualizaProfesionalAsignado(txtDNI.Text);
            }
        }

        private void CargarDatos()
        {            
            strDatos.Clear();
            strDatos.Add(txtNombreUsuario.Text);
            strDatos.Add(txtContrasena.Text);
            strDatos.Add(txtApellido.Text);
            strDatos.Add(txtNombre.Text);
            strDatos.Add(txtCorreo.Text);
            strDatos.Add(cmbTipoUsuario.Text);

            strDatos.Add(chkConfiguracion.Checked);
            strDatos.Add(chkExamenes.Checked);
            strDatos.Add(chkMesaEntrada.Checked);
            strDatos.Add(chkPacientes.Checked);
            strDatos.Add(chkVentanilla.Checked);
            strDatos.Add(chkResumen.Checked);

            strDatos.Add(chkVer.Checked);
            strDatos.Add(chkModificar.Checked);
            strDatos.Add(chkEliminar.Checked);

            strDatos.Add(chkTurnos.Checked);
            strDatos.Add(chkActivo.Checked);
            strDatos.Add(chkVerAudiometria.Checked);
            strDatos.Add(chkverfacturacion.Checked);
            strDatos.Add(txtDNI.Text);
        }

        private void cargarGrilla()
        {
            //dgwDatos = null;
            AgregarColumnaDGV("id", "id", false, "Text");
            AgregarColumnaDGV("password", "password", false, "Text");
            AgregarColumnaDGV("username", "Usuarios", true, "Text");
            AgregarColumnaDGV("nombre", "Nombre", true, "Text");
            AgregarColumnaDGV("apellido", "Apellido", true, "Text");
            AgregarColumnaDGV("email1", "E-mail", true, "Text");
            AgregarColumnaDGV("Tipo", "Tipo Usuario", true, "Text");
            AgregarColumnaDGV("Activo", "Activo", true, "CheckBox");
            AgregarColumnaDGV("ProfesionalAsignado", "ProfesionalAsignado", false, "Text");
            AgregarColumnaDGV("dni", "DNI", false, "Text");
            AgregarColumnaDGV("Medico", "Medico", true, "Image");

            dgwDatos.Columns[0].Visible = false;
            dgwDatos.Columns[1].Visible = false;
            dgwDatos.Columns[0].Width = 100;
            dgwDatos.Columns[1].Width = 130;
            dgwDatos.Columns[2].Width = 130;
            dgwDatos.Columns[3].Width = 150;
            dgwDatos.Columns[4].Width = 180;
            dgwDatos.Columns[5].Width = 180;
            dgwDatos.Columns[6].Width = 180;
            dgwDatos.Columns[7].Width = 100;
            dgwDatos.Columns[8].Visible = false;
                        
            cmbTipoUsuario.DataSource = TipoUsuario.ListarNombreTipoUsuario();
            cmbTipoUsuario.ValueMember = "id";
            cmbTipoUsuario.DisplayMember = "NombreTipo";
            cmbTipoUsuario.SelectedIndex = 0;
            
        }

        private void AgregarColumnaDGV(string nombreOculto, string nombreAMostrar, bool visible, string TipoColumna)
        {
            switch (TipoColumna)
            {
                case "CheckBox":
                    DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
                    dgwDatos.Columns.Add(col1);
                    dgwDatos.Columns[7].Name = nombreOculto;
                    dgwDatos.Columns[7].HeaderText = nombreAMostrar;
                    dgwDatos.Columns[7].Visible = visible;
                    break;
                case "Image":
                    DataGridViewImageColumn col2 = new DataGridViewImageColumn();
                    col2.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgwDatos.Columns.Add(col2);
                    dgwDatos.Columns[5].Name = nombreOculto;
                    dgwDatos.Columns[5].HeaderText = nombreAMostrar;
                    dgwDatos.Columns[5].Visible = visible;                    
                    break;
                case "Button":
                    //DataGridViewButtonColumn col3 = new DataGridViewButtonColumn();                    
                    DataGridViewImageColumn col3 = new DataGridViewImageColumn();
                    col3.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgwDatos.Columns.Add(col3);
                    dgwDatos.Columns[15].Name = nombreOculto;
                    dgwDatos.Columns[15].HeaderText = nombreAMostrar;
                    dgwDatos.Columns[15].Visible = visible;
                    break;
                default:
                    dgwDatos.Columns.Add(nombreOculto, nombreAMostrar);
                    dgwDatos.Columns[nombreOculto].Visible = visible;
                    break;
            }
        }

        public void ListarUsuarios()
        {
            dgwDatos.DataSource = UserSistema.ListarUsuarios();            
            cargarGrilla();            
        }

        private void CargarDatosDGV()
        {
            if (dgwDatos.Rows.Count > 0)
                dgwDatos.Rows.Clear();

            foreach (DataRow r in UserSistema.ListarUsuarios().Rows)
            {
                dgwDatos.Rows.Add(r.ItemArray);
            }

            RefrescarImagenLinkDGV();
            dgwDatos.AllowUserToAddRows = false; // Elimina la última fila en blanco
        }

        private void dgwDatos_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgwDatos.Rows.Count > 0)
            //{
            //    try
            //    {
            //        LimpiarValores();
            //        //if (blnEstadoInicial)
            //        //{
            //        txtContrasena.Text = Utilidades.desencriptar(dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[1].Value.ToString());
            //        txtNombreUsuario.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[2].Value.ToString();
            //        txtNombre.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[3].Value.ToString();
            //        txtApellido.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[4].Value.ToString();
            //        txtCorreo.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[5].Value.ToString();
            //        cmbTipoUsuario.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[6].Value.ToString();
            //        cargarImagen();
            //        //}
            //        CargarPermisosDefecto(cmbTipoUsuario.Text);
            //        CargarPermisos(cmbTipoUsuario.Text);
            //    }catch(System.NullReferenceException ex)
            //    {
            //        //
            //    }
            //}
        }

        private void CargaPrimerUsuario()
        {
            if (dgwDatos.Rows.Count > 0)
            {
                CargarPermisosDefecto(cmbTipoUsuario.Text);
                CargarPermisos(cmbTipoUsuario.Text);               
            }
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            // Prevenir doble clic
            botAceptar.Enabled = false;
            try
            {
                // Validación: solo el administrador puede asignar el tipo "ADMINISTRADOR"
                if (!UsuarioActualEsAdministrador() && cmbTipoUsuario.Text == "ADMINISTRADOR")
                {
                    MessageBox.Show("No tiene permisos para asignar el tipo ADMINISTRADOR.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (blnNuevo == true)
                {
                    if (UserSistema.BuscaNombreUsuario(txtNombreUsuario.Text))
                    {
                        MessageBox.Show("Este usuario ya existe", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (txtDNI.Text.Trim() != "" && UserSistema.BuscaDNIExacto(txtDNI.Text.Trim()))
                    {
                        MessageBox.Show("Ya existe un usuario con este DNI", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    Guardar();
                    MessageBox.Show("Usuario creado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombreUsuario.Enabled = false;

                    blnNuevo = false;
                }
                else
                {
                    actualizar();
                    MessageBox.Show("Usuario actualizado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                botAceptar.Enabled = true;
            }

            // Si el usuario editado es el usuario actualmente logueado, refrescar visibilidad en tiempo real
            if (txtNombreUsuario.Text.Trim().Equals(Comunes.UsuarioDatos.UsuarioSistema, StringComparison.OrdinalIgnoreCase))
            {
                var frmPadre = this.MdiParent as CapaPresentacionBase.frmBasePrincipal;
                if (frmPadre != null)
                    frmPadre.PermisosUsuario(Comunes.UsuarioDatos.UsuarioSistema);
            }

            CargarDatosDGV();

            if (dgv.Rows.Count > 0)
            {
                intFilaSelecc = 0;
            }

            ModoLectura(false);
            LimpiarValores();
            botModificar.Visible = true;
            botCancelar.Visible = true;
            botAceptar.Visible = false;
            blnNuevo = false;
        }
        private void botCancelar_Click(object sender, EventArgs e)
        {
            LimpiarValores();
            //txtNombreUsuario.Enabled = false;
            //ModoNormal();     
            ModoLectura(false);
            ocultarBuscar();
            blnNuevo = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            blnNuevo = true;         
            LimpiarValores();
            txtNombreUsuario.Enabled = true;
            //ModoNuevo();
            ModoLectura(true);
            btnNuevo.Enabled = false;
            botAceptar.Visible = true;
            botCancelar.Visible = true;
            botModificar.Visible = false;
            ocultarBuscar();
        }

        private void ModoEdicion()
        {
            blnNuevo = false;
            btnEliminar.Enabled = false;
            btnTipoUsuario.Enabled = false;
            btnNuevo.Enabled = false;
        }

        private void ModoNuevo()
        {
            blnNuevo = true;
            btnEliminar.Enabled = false;
            btnTipoUsuario.Enabled = false;
            btnNuevo.Enabled = false;
            txtNombre.Focus();
            //txtNombre.BackColor = Color.LightYellow;
            txtNombreUsuario.Enabled = true;
        }

        private void ModoNormal()
        {
            blnNuevo = false;
            btnEliminar.Visible = true;
            btnTipoUsuario.Enabled = true;
            btnNuevo.Enabled = true;
            botAceptar.Visible = true;
            botCancelar.Visible = true;
            //txtNombre.BackColor = Color.White;
            txtNombreUsuario.Enabled = false;
            txtApellido.Enabled = true;
            txtNombre.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtContrasena.Enabled = false;
        }

        private void LimpiarValores()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtContrasena.Text = "";
            txtCorreo.Text = "";
            txtNombreUsuario.Text = "";
            txtDNI.Text = "";

            chkConfiguracion.ForeColor = Color.Black;
            chkExamenes.ForeColor = Color.Black;
            chkMesaEntrada.ForeColor = Color.Black;
            chkPacientes.ForeColor = Color.Black;
            chkVentanilla.ForeColor = Color.Black;
            chkTurnos.ForeColor = Color.Black;
            chkResumen.ForeColor = Color.Black;

            chkVer.ForeColor = Color.Black;
            chkModificar.ForeColor = Color.Black;
            chkEliminar.ForeColor = Color.Black;

            chkVerAudiometria.ForeColor = Color.Black;
            chkverfacturacion.ForeColor = Color.Black;
            pbFoto.Image = null;
        }

        private void frmUsuariosSistema_Load(object sender, EventArgs e)
        {
            ModoLectura(false);
            cargarListadoFiltroString(txtBuscar.Text);

            // Verificación de administrador
            if (!UsuarioActualEsAdministrador())
            {
                cmbTipoUsuario.Enabled = false;
                // Si quieres, deshabilita también los checkboxes de permisos:
                chkConfiguracion.Enabled = false;
                chkExamenes.Enabled = false;
                chkMesaEntrada.Enabled = false;
                chkPacientes.Enabled = false;
                chkVentanilla.Enabled = false;
                chkTurnos.Enabled = false;
                chkResumen.Enabled = false;
                chkVerAudiometria.Enabled = false;
                chkVer.Enabled = false;
                chkModificar.Enabled = false;
                chkEliminar.Enabled = false;
                chkverfacturacion.Enabled = false;
            }
        }

        // Método para verificar si el usuario actual es administrador
        private bool UsuarioActualEsAdministrador()
        {
            return Configuracion.usuario != null &&
                   Configuracion.usuario.Tipo == "ADMINISTRADOR";
        }

        private void dgwDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwDatos.Rows.Count > 0)
            {
                //LimpiarValores();
                //txtContrasena.Text = Utilidades.desencriptar(dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[1].Value.ToString());
                //txtNombreUsuario.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[2].Value.ToString();
                //txtNombre.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[3].Value.ToString();
                //txtApellido.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[4].Value.ToString();
                //txtCorreo.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[5].Value.ToString();
                //cmbTipoUsuario.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[6].Value.ToString();
                blnEstadoInicial = true;                
                txtNombreUsuario.Enabled = false;                
            }
        }

        private void dgwDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgwDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgwDatos.Rows.Count > 0)
            //{
            //    LimpiarValores();
            //    if (blnEstadoInicial)
            //    {
            //        txtContrasena.Text = Utilidades.desencriptar(dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[1].Value.ToString());
            //        txtNombreUsuario.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[2].Value.ToString();
            //        txtNombre.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[3].Value.ToString();
            //        txtApellido.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[4].Value.ToString();
            //        txtCorreo.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[5].Value.ToString();
            //        cmbTipoUsuario.Text = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[6].Value.ToString();
            //    }

            //    blnNuevo = false;
            //    txtNombreUsuario.Enabled = false;
            //}
            
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            //txtNombre.BackColor = Color.White;
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text != string.Empty)
            {
                DialogResult opcion = MessageBox.Show(
                    "¿Desea adjuntar una imagen desde archivo?\n\nSeleccione 'Sí' para adjuntar archivo o 'No' para tomar fotografía con cámara.",
                    "Foto usuario",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    AdjuntarImagen();
                }
                else if (opcion == DialogResult.No)
                {
                    frmFotoPaciente fFoto = new frmFotoPaciente(txtDNI.Text, 'L');
                    fFoto.ShowDialog();
                    cargarImagen();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar primero el nombre de usuario", "Foto usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AdjuntarImagen()
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Seleccionar imagen";
                openDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos los archivos|*.*";
                openDialog.FilterIndex = 1;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string destino = DirectorioFotos.UbicacionFotoLaboral() + "\\" + txtDNI.Text + ".jpg";

                        using (Image img = Image.FromFile(openDialog.FileName))
                        {
                            img.Save(destino, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }

                        cargarImagen();
                        MessageBox.Show("Imagen adjuntada correctamente.", "Foto usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al adjuntar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cargarImagen()
        {
            try
            {
                //GRV - Ramírez - Modificado
                //FileStream fs = new System.IO.FileStream(@"S:/FOTOS/" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                FileStream fs = new System.IO.FileStream(DirectorioFotos.UbicacionFotoLaboral() + "\\" + txtDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                pbFoto.Image = Image.FromStream(fs);
                pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                
                fs.Close();
            }
            catch
            {
                pbFoto.Image = null;
            }
        }

        private void pbFoto_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dgwDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //puntero = dgvExamenes.CurrentCell.RowIndex;
            //celda = e.ColumnIndex;

            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 9)
                {
                    frmSeleccionarProfesional frm = new frmSeleccionarProfesional(dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    frm.ShowDialog();
                    CargarDatosDGV();
                }

                //    if (e.ColumnIndex == 12)
                //    {
                //        abrirLaboratorio(e.RowIndex);

                //    }

                //    if (e.ColumnIndex == 14)
                //    {
                //        abrirRX(e.RowIndex);
                //    }

                //    if (e.ColumnIndex == 16)
                //    {
                //        abrirCard(e.RowIndex);
                //    }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgwDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool blnDato = false;

            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 7)
                {
                    blnDato = Convert.ToBoolean(dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[7].Value.ToString());

                    if (blnDato)
                    {
                        UserSistema.ActualizaActivo(1, dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }
                    else
                    {
                        UserSistema.ActualizaActivo(0, dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }
                }
            }
        }
                

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string strID = "";

            strID = dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[0].Value.ToString();

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el usuario",
                "Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                if (!UserSistema.BorrarUsuario(strID))
                {
                    MessageBox.Show("Usuario eliminado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //ListarUsuarios();
                CargarDatosDGV();
                ModoNormal();
            }
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarPermisosDefecto(cmbTipoUsuario.Text);
                //CargarPermisos(dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
            catch (System.NullReferenceException ex)
            {
                //
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                mostrarBuscar();
            }
        }

        private void mostrarBuscar()
        {           
            tblBuscar.Visible = true;
            txtBuscar.Select();
            txtBuscar.Text = "";
        }

        private void ocultarBuscar()
        {
            tblBuscar.Visible = false;
            txtApellido.Select();            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarListadoFiltroString(txtBuscar.Text);
            if (dgv.Rows.Count < 1)
            {
                btnNuevo.Enabled = true;
            }
            else
            {
                btnNuevo.Enabled = false;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgv.Rows.Count == 1)
            {
                ConsultarUsuario();
                ocultarBuscar();
                botModificar.Enabled = true;
                botModificar.Visible = true;
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                dgv.Select();
            }

            else if (e.KeyCode == Keys.Escape)
            {
                ocultarBuscar();
            }
        }

        private void CargarPermisosDefecto(string strTipoUsuario)
        {
            DataTable dt = null;

            dt = TipoUsuario.BuscarTiposUsuario(strTipoUsuario);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!blnNuevo)
                    {
                        blnVVentanilla = Convert.ToBoolean(dt.Rows[i][2].ToString());
                        blnVMesa = Convert.ToBoolean(dt.Rows[i][3].ToString());
                        blnVPacientes = Convert.ToBoolean(dt.Rows[i][4].ToString());
                        blnVExamenes = Convert.ToBoolean(dt.Rows[i][5].ToString());
                        blnVConfiguracion = Convert.ToBoolean(dt.Rows[i][6].ToString());
                        blnVTurno = Convert.ToBoolean(dt.Rows[i][7].ToString());
                        blnVResumen = Convert.ToBoolean(dt.Rows[i][8].ToString());

                        blnPVer = Convert.ToBoolean(dt.Rows[i][9].ToString());
                        blnPModificar = Convert.ToBoolean(dt.Rows[i][10].ToString());
                        blnPEliminar = Convert.ToBoolean(dt.Rows[i][11].ToString());

                        blnVerAudio = Convert.ToBoolean(dt.Rows[i][12].ToString());
                        blnVFacturacion = dt.Columns.Count > 13 ? Convert.ToBoolean(dt.Rows[i][13].ToString()) : false;

                        // ---

                        chkVentanilla.Checked = Convert.ToBoolean(dt.Rows[i][2].ToString());
                        chkMesaEntrada.Checked = Convert.ToBoolean(dt.Rows[i][3].ToString());
                        chkPacientes.Checked = Convert.ToBoolean(dt.Rows[i][4].ToString());
                        chkExamenes.Checked = Convert.ToBoolean(dt.Rows[i][5].ToString());
                        chkConfiguracion.Checked = Convert.ToBoolean(dt.Rows[i][6].ToString());
                        chkTurnos.Checked = Convert.ToBoolean(dt.Rows[i][7].ToString());
                        chkResumen.Checked = Convert.ToBoolean(dt.Rows[i][8].ToString());

                        chkVer.Checked = Convert.ToBoolean(dt.Rows[i][9].ToString());
                        chkModificar.Checked = Convert.ToBoolean(dt.Rows[i][10].ToString());
                        chkEliminar.Checked = Convert.ToBoolean(dt.Rows[i][11].ToString());
                        chkVerAudiometria.Checked = Convert.ToBoolean(dt.Rows[i][12].ToString());
                        chkverfacturacion.Checked = dt.Columns.Count > 13 ? Convert.ToBoolean(dt.Rows[i][13].ToString()) : false;
                    }
                    else
                    {
                        chkVentanilla.Checked = Convert.ToBoolean(dt.Rows[i][2].ToString());
                        chkMesaEntrada.Checked = Convert.ToBoolean(dt.Rows[i][3].ToString());
                        chkPacientes.Checked = Convert.ToBoolean(dt.Rows[i][4].ToString());
                        chkExamenes.Checked = Convert.ToBoolean(dt.Rows[i][5].ToString());
                        chkConfiguracion.Checked = Convert.ToBoolean(dt.Rows[i][6].ToString());
                        chkTurnos.Checked = Convert.ToBoolean(dt.Rows[i][7].ToString());
                        chkResumen.Checked = Convert.ToBoolean(dt.Rows[i][8].ToString());

                        chkVer.Checked = Convert.ToBoolean(dt.Rows[i][9].ToString());
                        chkModificar.Checked = Convert.ToBoolean(dt.Rows[i][10].ToString());
                        chkEliminar.Checked = Convert.ToBoolean(dt.Rows[i][11].ToString());
                        chkVerAudiometria.Checked = Convert.ToBoolean(dt.Rows[i][12].ToString());
                        chkverfacturacion.Checked = dt.Columns.Count > 13 ? Convert.ToBoolean(dt.Rows[i][13].ToString()) : false;
                    }
                }
            }
        }

        private void CargarPermisos(string strTipoUsuario)
        {
            DataTable dt = null;

            try
            {
                dt = UserSistema.ListaPermisoUsuarios(dgv.Rows[intFilaSelecc].Cells[0].Value.ToString());

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chkConfiguracion.Checked = Convert.ToBoolean(dt.Rows[i][13].ToString());
                        chkExamenes.Checked = Convert.ToBoolean(dt.Rows[i][14].ToString());
                        chkMesaEntrada.Checked = Convert.ToBoolean(dt.Rows[i][15].ToString());
                        chkPacientes.Checked = Convert.ToBoolean(dt.Rows[i][16].ToString());
                        chkVentanilla.Checked = Convert.ToBoolean(dt.Rows[i][17].ToString());
                        chkTurnos.Checked = Convert.ToBoolean(dt.Rows[i][22].ToString());
                        chkResumen.Checked = Convert.ToBoolean(dt.Rows[i][18].ToString());

                        chkVer.Checked = Convert.ToBoolean(dt.Rows[i][19].ToString());
                        chkModificar.Checked = Convert.ToBoolean(dt.Rows[i][20].ToString());
                        chkEliminar.Checked = Convert.ToBoolean(dt.Rows[i][21].ToString());
                        chkVerAudiometria.Checked = Convert.ToBoolean(dt.Rows[i][24].ToString());
                        chkverfacturacion.Checked = Convert.ToBoolean(dt.Rows[i]["VentFacturacion"].ToString());

                        if (chkConfiguracion.Checked != blnVConfiguracion)
                            chkConfiguracion.ForeColor = Color.Red;
                        if (chkExamenes.Checked != blnVExamenes)
                            chkExamenes.ForeColor = Color.Red;
                        if (chkMesaEntrada.Checked != blnVMesa)
                            chkMesaEntrada.ForeColor = Color.Red;
                        if (chkPacientes.Checked != blnVPacientes)
                            chkPacientes.ForeColor = Color.Red;
                        if (chkVentanilla.Checked != blnVVentanilla)
                            chkVentanilla.ForeColor = Color.Red;
                        if (chkTurnos.Checked != blnVTurno)
                            chkTurnos.ForeColor = Color.Red;
                        if (chkResumen.Checked != blnVResumen)
                            chkResumen.ForeColor = Color.Red;
                        if (chkVerAudiometria.Checked != blnVerAudio)
                            chkVerAudiometria.ForeColor = Color.Red;
                        if (chkVer.Checked != blnPVer)
                            chkVer.ForeColor = Color.Red;
                        if (chkModificar.Checked != blnPModificar)
                            chkModificar.ForeColor = Color.Red;
                        if (chkEliminar.Checked != blnPEliminar)
                            chkEliminar.ForeColor = Color.Red;
                        if (chkverfacturacion.Checked != blnVFacturacion)
                            chkverfacturacion.ForeColor = Color.Red;
                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                //
            }
        }
        
        private void AccesoAdministrador()
        {
            chkConfiguracion.Checked = true;
            chkExamenes.Checked = true;
            chkMesaEntrada.Checked = true;
            chkPacientes.Checked = true;
            chkVentanilla.Checked = true;
            chkTurnos.Checked = true;
            chkResumen.Checked = true;
            chkVerAudiometria.Checked = true;

            chkModificar.Checked = true;
            chkVer.Checked = true;
            chkEliminar.Checked = true;            
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            ModoLectura(true);
            botModificar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (chkActivo.Checked)
                {
                    UserSistema.ActualizaActivo(1, dgv.Rows[intFilaSelecc].Cells[0].Value.ToString());
                }
                else
                {
                    UserSistema.ActualizaActivo(0, dgv.Rows[intFilaSelecc].Cells[0].Value.ToString());
                }
            }
        }

        private void chkMedico_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMedico.Checked == true)
            {
                frmSeleccionarProfesional frm = new frmSeleccionarProfesional(dgwDatos.Rows[intFilaSelecc].Cells[0].Value.ToString());
                frm.ShowDialog();
                CargarDatosDGV();
            }
        }

        private void chkResumen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AccesoOperador()
        {
            chkConfiguracion.Checked = false;
            chkExamenes.Checked = true;
            chkMesaEntrada.Checked = true;
            chkPacientes.Checked = true;
            chkVentanilla.Checked = true;
            chkTurnos.Checked = true;
            chkResumen.Checked = false;
            chkVerAudiometria.Checked = false;

            chkModificar.Checked = true;
            chkVer.Checked = true;
            chkEliminar.Checked = false;            
        }

        private void AccesoTecnico()
        {
            chkConfiguracion.Checked = false;
            chkExamenes.Checked = false;
            chkMesaEntrada.Checked = false;
            chkPacientes.Checked = false;
            chkVentanilla.Checked = false;
            chkTurnos.Checked = false;
            chkResumen.Checked = true;
            chkVerAudiometria.Checked = true;

            chkModificar.Checked = false;
            chkVer.Checked = true;
            chkEliminar.Checked = false;            
        }

        private void btnTipoUsuario_Click(object sender, EventArgs e)
        {
            frmUsuarioSistemaTipo frm = new frmUsuarioSistemaTipo();
            frm.ShowDialog();
            cmbTipoUsuario.DataSource = TipoUsuario.ListarNombreTipoUsuario();
            cmbTipoUsuario.ValueMember = "id";
            cmbTipoUsuario.DisplayMember = "NombreTipo";
            cmbTipoUsuario.SelectedIndex = 0;
        }

        private void RefrescarImagenLinkDGV()
        {
            if (dgwDatos.Rows.Count > 0)
            {
                //for (int i = 0; i < dgwDatos.Rows.Count; i++)
                //{
                //    dgwDatos.Rows[i].Cells[9].Value = Image.FromFile("P:\\img-system\\mEnlaceRoto36x36.png");

                //    if (!string.IsNullOrEmpty(dgwDatos.Rows[i].Cells[8].Value.ToString()))
                //    {
                //        dgwDatos.Rows[i].Cells[9].Value = Image.FromFile("P:\\img-system\\mEnlace36x36.png");
                //    }
                //}
            }
        }
                

        private void cargarListadoFiltroString(string strApellido)
        {
            dgv.DataSource = UserSistema.BuscarApellidoUsuario(strApellido);
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[9].Visible = true;
            dgv.Columns[10].Visible = true;
            dgv.Columns[9].Width = 155;
            dgv.Columns[10].Width = 125;
            dgv.Columns[11].Visible = false;
        }

        private void ConsultarUsuario()
        {
            if (dgv.Rows.Count > 0)
            {
                if (intFilaSelecc < 0)
                    intFilaSelecc = 0;

                try
                {
                    LimpiarValores();
                    //if (blnEstadoInicial)
                    //{
                    //txtContrasena.Text = Utilidades.desencriptar(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    //txtNombreUsuario.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    //txtNombre.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    //txtApellido.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    //txtCorreo.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    //cmbTipoUsuario.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    txtContrasena.Text = Utilidades.desencriptar(dgv.Rows[intFilaSelecc].Cells[1].Value.ToString());
                    txtNombreUsuario.Text = dgv.Rows[intFilaSelecc].Cells[2].Value.ToString();
                    txtNombre.Text = dgv.Rows[intFilaSelecc].Cells[3].Value.ToString();
                    txtApellido.Text = dgv.Rows[intFilaSelecc].Cells[4].Value.ToString();
                    txtCorreo.Text = dgv.Rows[intFilaSelecc].Cells[5].Value.ToString();
                    cmbTipoUsuario.Text = dgv.Rows[intFilaSelecc].Cells[6].Value.ToString();
                    chkActivo.Checked = Convert.ToBoolean(dgv.Rows[intFilaSelecc].Cells[7].Value);
                    txtDNI.Text = dgv.Rows[intFilaSelecc].Cells[11].Value.ToString();
                    cargarImagen();
                    //}
                    CargarPermisosDefecto(cmbTipoUsuario.Text);
                    CargarPermisos(cmbTipoUsuario.Text);
                }
                catch (System.NullReferenceException ex)
                {
                    //
                }
            }
        }

        private void ModoLectura(bool blnActivo)
        {
            txtContrasena.Enabled = blnActivo;
            txtNombreUsuario.Enabled = blnActivo;
            txtNombre.Enabled = blnActivo; 
            txtCorreo.Enabled = blnActivo;
            txtDNI.Enabled = blnActivo;
            cmbTipoUsuario.Enabled = blnActivo;
            pbFoto.Enabled = blnActivo;
            gpbAccesoPantallas.Enabled = blnActivo;
            gpbPermisos.Enabled = blnActivo;

            botAceptar.Visible = blnActivo;            
            botModificar.Visible = blnActivo;
            btnNuevo.Visible = UsuarioActualEsAdministrador();
            btnNuevo.Enabled = UsuarioActualEsAdministrador() && !blnActivo;
            botCancelar.Visible = blnActivo;

            chkActivo.Enabled = blnActivo;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                intFilaSelecc = dgv.CurrentCell.RowIndex;
                ConsultarUsuario();
                ocultarBuscar();
                ModoLectura(false);
                botModificar.Enabled = true;
                botModificar.Visible = true;                
            }            
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                intFilaSelecc = dgv.CurrentCell.RowIndex - 1;
                ConsultarUsuario();
                ocultarBuscar();
                ModoLectura(false);
                botModificar.Enabled = true;
                botModificar.Visible = true;                
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                ocultarBuscar();
            }
        }

        // ==================== TAB GESTIONAR USUARIOS ====================

        private DataTable dtGestion;
        private bool filtroFechaActivo = false;
        private string campoBusqueda = "DNI";  // Campo actual de búsqueda: DNI, Nombre, Apellido, Usuario

        private void tabControlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlUsuarios.SelectedTab == tabGestion)
            {
                CargarGrillaGestion();
            }
        }

        private void CargarGrillaGestion()
        {
            dtGestion = UserSistema.ListarUsuariosConPermisos();
            FiltrarGrillaGestion(txtBuscarGestion.Text);
        }

        private void FiltrarGrillaGestion(string filtro)
        {
            if (dtGestion == null) return;

            DataView dv = dtGestion.DefaultView;
            List<string> filtros = new List<string>();

            // Filtro por campo seleccionado
            if (!string.IsNullOrEmpty(filtro))
                filtros.Add("[" + campoBusqueda + "] LIKE '%" + filtro.Replace("'", "''") + "%'");

            // Filtro por rango de fechas
            if (filtroFechaActivo)
            {
                string desde = dtpDesde.Value.ToString("yyyy-MM-dd");
                string hasta = dtpHasta.Value.Date.AddDays(1).ToString("yyyy-MM-dd");
                filtros.Add("[Fecha Creación] >= #" + desde + "# AND [Fecha Creación] < #" + hasta + "#");
            }

            dv.RowFilter = filtros.Count > 0 ? string.Join(" AND ", filtros.ToArray()) : "";

            dgvGestion.DataSource = dv;
            dgvGestion.Columns["id"].Visible = false;

            // Ocultar columnas de permisos (se ven en el modal)
            string[] colsOcultas = { "Ventanilla", "Mesa Entrada", "Pacientes",
                                     "Exámenes", "Configuración", "Turnos", "Planilla",
                                     "Audiometría", "Facturación", "Ver", "Modificar", "Eliminar" };
            foreach (string col in colsOcultas)
            {
                dgvGestion.Columns[col].Visible = false;
            }

            dgvGestion.Columns["Usuario"].FillWeight = 100;
            dgvGestion.Columns["Apellido"].FillWeight = 120;
            dgvGestion.Columns["Nombre"].FillWeight = 120;
            dgvGestion.Columns["Tipo Usuario"].FillWeight = 100;
            dgvGestion.Columns["DNI"].FillWeight = 80;
            dgvGestion.Columns["Activo"].FillWeight = 50;
            dgvGestion.Columns["Fecha Creación"].FillWeight = 80;
            dgvGestion.Columns["Fecha Creación"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvGestion.ReadOnly = true;

            // Agregar botón "Configurar" si no existe
            if (!dgvGestion.Columns.Contains("btnConfigurar"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "btnConfigurar";
                btnCol.HeaderText = "Permisos";
                btnCol.Text = "Configurar";
                btnCol.UseColumnTextForButtonValue = true;
                btnCol.FillWeight = 70;
                dgvGestion.Columns.Add(btnCol);
            }

            // Actualizar total
            txtTotalGestion.Text = "Total: " + dv.Count + " usuario(s)";

            dgvGestion.ClearSelection();
        }

        private void dgvGestion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvGestion.Columns[e.ColumnIndex].Name != "btnConfigurar") return;

            string strId = dgvGestion.Rows[e.RowIndex].Cells["id"].Value.ToString();
            string strUsuario = dgvGestion.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();

            DataTable dt = UserSistema.ListaPermisoUsuarios(strId);
            if (dt.Rows.Count == 0) return;
            DataRow row = dt.Rows[0];

            using (frmPermisosUsuario frm = new frmPermisosUsuario(strUsuario, row, UsuarioActualEsAdministrador()))
            {
                if (frm.ShowDialog() == DialogResult.OK && UsuarioActualEsAdministrador())
                {
                    // Guardar cada permiso
                    Dictionary<string, string> mapeo = new Dictionary<string, string>
                    {
                        { "Activo", "Activo" },
                        { "VentVentanilla", "VentVentanilla" },
                        { "VentMesa", "VentMesa" },
                        { "VentPacientes", "VentPacientes" },
                        { "VentExamenes", "VentExamenes" },
                        { "VentConfiguracion", "VentConfiguracion" },
                        { "VentTurnos", "VentTurnos" },
                        { "VentResumen", "VentResumen" },
                        { "VentAudiometria", "VentAudiometria" },
                        { "VentFacturacion", "VentFacturacion" },
                        { "PermisoVer", "PermisoVer" },
                        { "PermisoModificar", "PermisoModificar" },
                        { "PermisoEliminar", "PermisoEliminar" }
                    };

                    foreach (var kvp in mapeo)
                    {
                        string strValor = frm.Permisos[kvp.Key] ? "1" : "0";
                        UserSistema.ActualizarCampoUsuario(strId, kvp.Value, strValor);
                    }

                    CargarGrillaGestion();
                }
            }
        }

        private void dgvGestion_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
        }

        private void dgvGestion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            filtroFechaActivo = !filtroFechaActivo;
            if (filtroFechaActivo)
            {
                btnFiltrarFecha.Text = "Quitar Filtro";
                btnFiltrarFecha.IconChar = FontAwesome.Sharp.IconChar.FilterCircleXmark;
                btnFiltrarFecha.IconColor = System.Drawing.Color.Crimson;
            }
            else
            {
                btnFiltrarFecha.Text = "Filtrar";
                btnFiltrarFecha.IconChar = FontAwesome.Sharp.IconChar.Filter;
                btnFiltrarFecha.IconColor = System.Drawing.Color.FromArgb(0, 122, 204);
            }
            FiltrarGrillaGestion(txtBuscarGestion.Text);
        }

        private void txtBuscarGestion_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrillaGestion(txtBuscarGestion.Text);
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (filtroFechaActivo)
            {
                filtroFechaActivo = false;
                btnFiltrarFecha.Text = "Filtrar";
                btnFiltrarFecha.IconChar = FontAwesome.Sharp.IconChar.Filter;
                btnFiltrarFecha.IconColor = System.Drawing.Color.FromArgb(0, 122, 204);
                FiltrarGrillaGestion(txtBuscarGestion.Text);
            }
        }

        private void btnCambioBusqueda_Click(object sender, EventArgs e)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = "Buscar por...";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.Size = new System.Drawing.Size(260, 220);
                dlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);

                RadioButton rbDNI = new RadioButton { Text = "DNI", Location = new System.Drawing.Point(30, 20), AutoSize = true, Checked = campoBusqueda == "DNI" };
                RadioButton rbNombre = new RadioButton { Text = "Nombre", Location = new System.Drawing.Point(30, 50), AutoSize = true, Checked = campoBusqueda == "Nombre" };
                RadioButton rbApellido = new RadioButton { Text = "Apellido", Location = new System.Drawing.Point(30, 80), AutoSize = true, Checked = campoBusqueda == "Apellido" };
                RadioButton rbUsuario = new RadioButton { Text = "Usuario", Location = new System.Drawing.Point(30, 110), AutoSize = true, Checked = campoBusqueda == "Usuario" };

                Button btnAceptarDlg = new Button
                {
                    Text = "Aceptar",
                    DialogResult = DialogResult.OK,
                    Location = new System.Drawing.Point(30, 145),
                    Size = new System.Drawing.Size(90, 30),
                    BackColor = System.Drawing.Color.SeaGreen,
                    ForeColor = System.Drawing.Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                Button btnCancelarDlg = new Button
                {
                    Text = "Cancelar",
                    DialogResult = DialogResult.Cancel,
                    Location = new System.Drawing.Point(130, 145),
                    Size = new System.Drawing.Size(90, 30),
                    FlatStyle = FlatStyle.Flat
                };

                dlg.Controls.AddRange(new Control[] { rbDNI, rbNombre, rbApellido, rbUsuario, btnAceptarDlg, btnCancelarDlg });
                dlg.AcceptButton = btnAceptarDlg;
                dlg.CancelButton = btnCancelarDlg;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    if (rbDNI.Checked) campoBusqueda = "DNI";
                    else if (rbNombre.Checked) campoBusqueda = "Nombre";
                    else if (rbApellido.Checked) campoBusqueda = "Apellido";
                    else if (rbUsuario.Checked) campoBusqueda = "Usuario";

                    lblBuscarGestion.Text = "Buscar por " + campoBusqueda + ":";
                    txtBuscarGestion.Text = "";
                    txtBuscarGestion.Focus();
                }
            }
        }
    }
}
