using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaPresentacionBase;
using Comunes;
using System.IO;

namespace CapaPresentacion
{
    public partial class frmProfesionalesCopy : DevExpress.XtraEditors.XtraForm
    {
        private frmBusquedaProfesionales formBusqueda;
        private CapaNegocioMepryl.Profesionales profesionales;
        private string strPathFirma = "";
        private CapaNegocioMepryl.UbicacionFotos DirectorioFotos;
        private Comunes.Configuracion config = new Comunes.Configuracion();
        private frmPacienteLaboral frmLaboral;
        private DataTable listado;
        private int Puntero = 0;

        public frmProfesionalesCopy(frmBusquedaProfesionales frm)
        {
            InitializeComponent();
            formBusqueda = frm;
            profesionales = new CapaNegocioMepryl.Profesionales();
            cargarListado();
            cargarListadoLista();
        }

        public frmProfesionalesCopy(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            profesionales = new CapaNegocioMepryl.Profesionales();
            DirectorioFotos = new CapaNegocioMepryl.UbicacionFotos();
            cargarListado();
            config = parentForm.configuracion;
            modoLectura(false);
            cargarListadoLista();
        }

        public frmProfesionalesCopy(frmPacienteLaboral frm)
        {
            InitializeComponent();
            frmLaboral = frm;
            profesionales = new CapaNegocioMepryl.Profesionales();
            DirectorioFotos = new CapaNegocioMepryl.UbicacionFotos();
            cargarListado();
            cargarListadoLista();
            this.tabControl1.SelectedTab = tabPage2;
        }

        public void modoConsulta(object id)
        {
            botGuardar.Visible = false;
            botCancelar.Visible = false;
            botVolver.Visible = false;
            botModificar.Visible = true;
            setearId(id);
            mostrarDatos();
            lbTitulo.Text = "Ficha del Médico";
            cambiarHabilitacionControles(false);
        }

        public void modoEdicion(object id)
        {
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            botVolver.Visible = false;
            //botModificar.Visible = false;
            setearId(id);
            mostrarDatos();
            lbTitulo.Text = "Edición del Médico";
        }

        public void modoEdicion2(object id)
        {
            botGuardar.Visible = true;
            botGuardar.Enabled = true;
            botCancelar.Visible = true;
            botCancelar.Enabled = true;
            botVolver.Visible = false;
            //botModificar.Visible = false;
            setearId(id);
            mostrarDatos();
            cambiarHabilitacionControles(true);
            lbTitulo.Text = "Edición del Médico";
        }

        public void modoNuevo()
        {
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            botVolver.Visible = false;
            //botModificar.Visible = false;
            botModificar.Enabled = false;
            limpiarFormulario();
            lbTitulo.Text = "Ingreso de Médico";
        }

        private void setearId(object id)
        {
            tbId.Text = id.ToString();
        }

        private void mostrarDatos()
        {
            Entidades.Profesional profesional = profesionales.cargarProfesional(new Guid(tbId.Text));
            llenarFormulario(profesional);
        }

        private void llenarFormulario(Entidades.Profesional profesional)
        {
            tbId.Text = profesional.Id.ToString();
            cboDoctor.SelectedItem = profesional.Tipo;
            tbApellido.Text = profesional.Apellido;
            tbNombre.Text = profesional.Nombre;
            cboLugarMatricula.SelectedItem = profesional.LugarMatricula;
            tbNroMatricula.Text = profesional.NroMatricula;
            cboEspecialidad.SelectedItem = profesional.Especialidad;
            cboEstadoCivil.SelectedItem = profesional.EstadoCivil;
            cboTipoDocumento.SelectedItem = profesional.TipoDocumento;
            tbNroDocumento.Text = profesional.NroDocumento;
            cboTipoContribuyente.SelectedItem = profesional.TipoContribuyente;
            tbDireccion.Text = profesional.Direccion;
            tbCodigoPostal.Text = profesional.CodigoPostal;
            tbLocalidad.Text = profesional.Localidad;
            cboProvincia.SelectedItem = profesional.Provincia;
            tbTelefono.Text = profesional.Telefono;
            tbCelular.Text = profesional.Celular;
            tbMail.Text = profesional.Mail;
            cbRealizaVisitasCapital.Checked = profesional.VisitasCapital;
            cbRealizaVisitasProvincia.Checked = profesional.VisitasProvincia;
            cargarImagen(profesional.Firma);
            chkMedicoActivo.Checked = profesional.Activo;
            txtDNI.Text = profesional.DNI;
            txtCUIL.Text = profesional.Cuil;
            chkTieneHorario.Checked = profesional.TieneHorario;

            cargarImagen();  // foto del paciente
        }

        private void botVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ActualizarHorarioActivo();
                MessageBox.Show("Datos guardados correctamente",
                        "Guardar Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
                if (verificarIngreso())
                {
                    guardarDatos();
                }
                else
                {
                    MessageBox.Show("¡Los campos Apellido y Nombre son necesarios para editar o registrar un médico!",
                        "Guardar Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                modoLectura(false);
            }
        }

        private bool verificarIngreso()
        {
            if (tbApellido.Text.Length > 0 && tbNombre.Text.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void guardarDatos()
        {
            if (tbId.Text == string.Empty)
            {
                nuevoProfesional();
            }
            else
            {
                editarProfesional();
            }
        }

        private void nuevoProfesional()
        {
            Entidades.Profesional profesional = cargarDatos();
            Entidades.Resultado resultado = profesionales.nuevoProfesional(profesional);
            if (resultado.Modo == -1)
            {
                MessageBox.Show("Error al crear médico.\nError: " + resultado.Mensaje, "Ingresar Médico",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("¡Médico ingresado correctamente!", "Ingresar Médico",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
                //formBusqueda.actualizarListado();
                ActualizarPacienteLaboral(profesional); //Para actualizar paciente laboral
                modoLectura(false);
            }
        }

        private void editarProfesional()
        {
            Entidades.Profesional profesional = cargarDatos();
            Entidades.Resultado resultado = profesionales.editarProfesional(profesional);
            if (resultado.Modo == -1)
            {
                MessageBox.Show("Error al editar los datos del médico.\nError: " + resultado.Mensaje, "Editar Médico",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("¡Datos actualizados correctamente correctamente!", "Editar Médico",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
                //formBusqueda.actualizarListado();
                ActualizarPacienteLaboral(profesional); //Para actualizar paciente laboral
            }
        }

        private Entidades.Profesional cargarDatos()
        {
            Entidades.Profesional retorno = new Entidades.Profesional();
            if (tbId.Text != string.Empty) { retorno.Id = new Guid(tbId.Text); }
            if (cboDoctor.SelectedIndex != -1) { retorno.Tipo = cboDoctor.SelectedItem.ToString(); }
            retorno.Nombre = tbNombre.Text;
            retorno.Apellido = tbApellido.Text;
            if (cboLugarMatricula.SelectedIndex != -1) { retorno.LugarMatricula = cboLugarMatricula.SelectedItem.ToString(); }
            retorno.NroMatricula = tbNroMatricula.Text;
            if (cboEspecialidad.SelectedIndex != -1) { retorno.Especialidad = cboEspecialidad.SelectedItem.ToString(); }
            if (cboEstadoCivil.SelectedIndex != -1) { retorno.EstadoCivil = cboEstadoCivil.SelectedItem.ToString(); }
            if (cboTipoDocumento.SelectedIndex != -1) { retorno.TipoDocumento = cboTipoDocumento.SelectedItem.ToString(); }
            retorno.NroDocumento = tbNroDocumento.Text;
            if (cboTipoContribuyente.SelectedIndex != -1) { retorno.TipoContribuyente = cboTipoContribuyente.SelectedItem.ToString(); }
            retorno.Direccion = tbDireccion.Text;
            retorno.CodigoPostal = tbCodigoPostal.Text;
            retorno.Localidad = tbLocalidad.Text;
            if (cboProvincia.SelectedIndex != -1) { retorno.Provincia = cboProvincia.SelectedItem.ToString(); }
            retorno.Telefono = tbTelefono.Text;
            retorno.Celular = tbCelular.Text;
            retorno.Mail = tbMail.Text;
            retorno.VisitasCapital = cbRealizaVisitasCapital.Checked;
            retorno.VisitasProvincia = cbRealizaVisitasProvincia.Checked;
            retorno.Firma = strPathFirma;
            retorno.Activo = chkMedicoActivo.Checked;
            retorno.DNI = txtDNI.Text.Trim();
            retorno.Cuil = txtCUIL.Text.Trim();
            retorno.TieneHorario = chkTieneHorario.Checked;
            return retorno;
        }

        private void limpiarFormulario()
        {
            tbId.Clear();
            tbNombre.Clear();
            tbApellido.Clear();
            cboDoctor.SelectedIndex = -1;
            cboLugarMatricula.SelectedIndex = -1;
            tbNroMatricula.Clear();
            cboEspecialidad.SelectedIndex = -1;
            cboEstadoCivil.SelectedIndex = -1;
            cboTipoContribuyente.SelectedIndex = -1;
            tbNroDocumento.Clear();
            cboTipoDocumento.SelectedIndex = -1;
            tbDireccion.Clear();
            tbLocalidad.Clear();
            tbCodigoPostal.Clear();
            cboProvincia.SelectedIndex = -1;
            tbTelefono.Clear();
            tbCelular.Clear();
            tbMail.Clear();
            cbRealizaVisitasCapital.Checked = false;
            cbRealizaVisitasProvincia.Checked = false;
            ptbFirma.Image = null;
            chkMedicoActivo.Checked = true;
            txtCUIL.Clear();
            txtDNI.Clear();
            chkTieneHorario.Checked = false;
            ptbFoto1.Image = null;
            
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            //this.Close();
            limpiarFormulario();
            tbApellido.Select();
            modoLectura(false);
            botGuardar.Enabled = false;
            botCancelar.Enabled = false;
            ocultarBuscar();
            botModificar.Enabled = false;
        }

        private void cambiarHabilitacionControles(bool visibilidad)
        {
            cboDoctor.Enabled = visibilidad;
            tbApellido.Enabled = visibilidad;
            tbNombre.Enabled = visibilidad;
            cboLugarMatricula.Enabled = visibilidad;
            tbNroMatricula.Enabled = visibilidad;
            cboEspecialidad.Enabled = visibilidad;
            cboEstadoCivil.Enabled = visibilidad;
            cboTipoDocumento.Enabled = visibilidad;
            tbNroDocumento.Enabled = visibilidad;
            cboTipoContribuyente.Enabled = visibilidad;
            tbDireccion.Enabled = visibilidad;
            tbCodigoPostal.Enabled = visibilidad;
            tbLocalidad.Enabled = visibilidad;
            cboProvincia.Enabled = visibilidad;
            tbTelefono.Enabled = visibilidad;
            tbCelular.Enabled = visibilidad;
            tbMail.Enabled = visibilidad;
            cbRealizaVisitasCapital.Enabled = visibilidad;
            cbRealizaVisitasProvincia.Enabled = visibilidad;
            chkHorario.Enabled = visibilidad;
            chkMedicoActivo.Enabled = visibilidad;
            ptbFoto1.Enabled = visibilidad;
            ptbFirma.Enabled = visibilidad;
            chkTieneHorario.Enabled = visibilidad;
            btnHorario.Enabled = visibilidad;

            txtCUIL.Enabled = visibilidad;
            txtDNI.Enabled = visibilidad;
        }
               

        private void modificar()
        {
            this.tabControl1.SelectedTab = tabPage2;
            botVolver.Visible = false;
            //botModificar.Visible = false;
            botGuardar.Visible = true;
            botGuardar.Enabled = true;
            botCancelar.Visible = true;
            botCancelar.Enabled = true;
            lbTitulo.Text = "Edición del Médico";
            cambiarHabilitacionControles(true);
            tbApellido.Select();
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fbdMostrarDirectorio = new OpenFileDialog();

            try
            {
                if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
                {
                    strPathFirma = fbdMostrarDirectorio.FileName;
                    System.IO.FileStream fs = new System.IO.FileStream(strPathFirma, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    ptbFirma.Image = Image.FromStream(fs);
                    ptbFirma.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                }
            }
            catch
            {
                ptbFirma.Image = null;
            }
        }

        private void cargarImagen(string PathImagen)
        {
            try
            {
                //GRV - Ramírez - Modificado
                strPathFirma = PathImagen;
                System.IO.FileStream fs = new System.IO.FileStream(strPathFirma, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                ptbFirma.Image = Image.FromStream(fs);
                ptbFirma.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                fs.Dispose();
                fs.Close();
            }
            catch
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaciente));                
                ptbFirma.Image = null;
            }
        }

        private void frmProfesionalesCopy_Load(object sender, EventArgs e)
        {
            tbApellido.Select();
            //modoLectura(false);
            if(tabControl1.SelectedIndex == 1)
            {

            }
        }               

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {        
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                consultaProfesionalDobleClick();
                txtBuscar.Visible = false;
                dgv.Visible = false;
                botCancelar.Visible = true;
                botCancelar.Enabled = true;
            } 
        }

        private void consultaProfesional()
        {
            try
            {
                if (dgv.CurrentCell.RowIndex > 0)
                {
                    modoConsulta(dgv.Rows[dgv.CurrentCell.RowIndex - 1].Cells[0].Value);
                    Puntero = dgv.CurrentCell.RowIndex - 1;
                }
                else
                {
                    modoConsulta(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                }

                
            }
            catch(System.ArgumentOutOfRangeException ex)
            {

            }

            botModificar.Enabled = true;
        }

        private void consultaProfesionalDobleClick()
        {
            try
            {
                if (dgv.CurrentCell.RowIndex > 0)
                {
                    modoConsulta(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                    Puntero = dgv.CurrentCell.RowIndex;
                }
                else
                {
                    modoConsulta(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                }                
            }
            catch (System.ArgumentOutOfRangeException ex)
            {

            }

            botModificar.Enabled = true;
        }

        private void cargarListado()
        { 
            dgv.DataSource = profesionales.cargarProfesionales();
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = true;
            dgv.Columns[2].Visible = true;
            dgv.Columns[1].Width = 160;
            dgv.Columns[2].Width = 140;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;
        }

        private void cargarListadoLista()
        {
            tbFiltro.Text = "";
            listado = profesionales.cargarProfesionales();
            dgv1.DataSource = listado;
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].ReadOnly = true;
            dgv1.Columns[2].ReadOnly = true;
            dgv1.Columns[3].ReadOnly = true;
            dgv1.Columns[4].ReadOnly = true;
            dgv1.Columns[5].ReadOnly = true;
            dgv1.Columns[6].ReadOnly = true;
            dgv1.Columns[7].ReadOnly = false;
        }

        private void cargarListadoFiltroString(string strApellido)
        {
            dgv.DataSource = profesionales.FiltrarProfesional(strApellido);
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = true;
            dgv.Columns[2].Visible = true;
            dgv.Columns[1].Width = 160;
            dgv.Columns[2].Width = 140;
        }

        private void tbApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                mostrarBuscar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarListadoFiltroString(txtBuscar.Text);
            if(dgv.Rows.Count < 1)
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }

        private void mostrarBuscar()
        {
            txtBuscar.Text = "";
            txtBuscar.Visible = true;
            dgv.Visible = true;
            txtBuscar.Select();
        }

        private void ocultarBuscar()
        {
            txtBuscar.Visible = false;
            dgv.Visible = false;
            tbApellido.Select();
            txtBuscar.Text = "";
            tbApellido.Enabled = true;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgv.Rows.Count == 1)
            {
                consultaProfesional();
                txtBuscar.Visible = false;
                dgv.Visible = false;
                botCancelar.Visible = true;
                botCancelar.Enabled = true;
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

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                consultaProfesional();
                txtBuscar.Visible = false;
                dgv.Visible = false;                
                botCancelar.Visible = true;
                botCancelar.Enabled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                ocultarBuscar();
            }
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (tbNroDocumento.Text != string.Empty)
            {
                frmFotoPaciente fFoto = new frmFotoPaciente(tbNroDocumento.Text, 'L');
                fFoto.ShowDialog();
                cargarImagen();
            }
            else
            {
                MessageBox.Show("Debe ingresar primero el nombre de usuario", "Foto usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cargarImagen()
        {
            string strPathFoto = "";
            try
            {
                //GRV - Ramírez - Modificado
                //FileStream fs = new System.IO.FileStream(@"S:/FOTOS/" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                strPathFoto = DirectorioFotos.UbicacionFotoLaboral() + "\\" + txtDNI.Text + ".jpg";

                System.IO.FileStream fs = new System.IO.FileStream(strPathFoto, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                ptbFoto1.Image = Image.FromStream(fs);
                ptbFoto1.SizeMode = PictureBoxSizeMode.StretchImage;

                fs.Close();
            }
            catch
            {
                ptbFoto1.Image = null;
            }
        }

        private void ptbFoto1_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text != string.Empty)
            {
                frmFotoPaciente fFoto = new frmFotoPaciente(txtDNI.Text, 'L');
                fFoto.ShowDialog();
                cargarImagen();
            }
            else
            {
                MessageBox.Show("Debe ingresar primero el nro de documento", "Foto profesional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkHorario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHorario.Checked)
            {
                frmHorario frm = new frmHorario(config, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA);
                if (tbId.Text != string.Empty) {
                    //frm.strIdProfesional = tbApellido.Text + " " + tbNombre.Text;
                
                }
                frm.ShowDialog();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modoAgregar(true);
            botCancelar.Enabled = true;

        }

        private void modoAgregar(bool visibilidad)
        {            
            cboDoctor.Enabled = visibilidad;            
            tbNombre.Enabled = visibilidad;
            cboLugarMatricula.Enabled = visibilidad;
            tbNroMatricula.Enabled = visibilidad;
            cboEspecialidad.Enabled = visibilidad;
            cboEstadoCivil.Enabled = visibilidad;
            cboTipoDocumento.Enabled = visibilidad;
            tbNroDocumento.Enabled = visibilidad;
            cboTipoContribuyente.Enabled = visibilidad;
            tbDireccion.Enabled = visibilidad;
            tbCodigoPostal.Enabled = visibilidad;
            tbLocalidad.Enabled = visibilidad;
            cboProvincia.Enabled = visibilidad;
            tbTelefono.Enabled = visibilidad;
            tbCelular.Enabled = visibilidad;
            tbMail.Enabled = visibilidad;
            cbRealizaVisitasCapital.Enabled = visibilidad;
            cbRealizaVisitasProvincia.Enabled = visibilidad;
            chkHorario.Enabled = visibilidad;
            chkMedicoActivo.Enabled = visibilidad;
            ptbFoto1.Enabled = visibilidad;
            ptbFirma.Enabled = visibilidad;
            btnAgregar.Enabled = visibilidad;
            botGuardar.Enabled = visibilidad;

            txtCUIL.Enabled = visibilidad;
            txtDNI.Enabled = visibilidad;
            ocultarBuscar();
        }

        private void modoLectura(bool visibilidad)
        {
            cboDoctor.Enabled = visibilidad;
            tbNombre.Enabled = visibilidad;
            cboLugarMatricula.Enabled = visibilidad;
            tbNroMatricula.Enabled = visibilidad;
            cboEspecialidad.Enabled = visibilidad;
            cboEstadoCivil.Enabled = visibilidad;
            cboTipoDocumento.Enabled = visibilidad;
            tbNroDocumento.Enabled = visibilidad;
            cboTipoContribuyente.Enabled = visibilidad;
            tbDireccion.Enabled = visibilidad;
            tbCodigoPostal.Enabled = visibilidad;
            tbLocalidad.Enabled = visibilidad;
            cboProvincia.Enabled = visibilidad;
            tbTelefono.Enabled = visibilidad;
            tbCelular.Enabled = visibilidad;
            tbMail.Enabled = visibilidad;
            cbRealizaVisitasCapital.Enabled = visibilidad;
            cbRealizaVisitasProvincia.Enabled = visibilidad;
            chkHorario.Enabled = visibilidad;
            chkMedicoActivo.Enabled = visibilidad;
            ptbFoto1.Enabled = visibilidad;
            ptbFirma.Enabled = visibilidad;
            btnAgregar.Enabled = visibilidad;
            //botGuardar.Enabled = visibilidad;
            chkTieneHorario.Enabled = visibilidad;

            txtDNI.Enabled = visibilidad;
            txtCUIL.Enabled = visibilidad;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            frmHorario frm = new frmHorario(config, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA);
            if (tbId.Text != string.Empty)
            {
                //frm.strIdProfesional = tbApellido.Text + " " + tbNombre.Text;
           
            }
            frm.ShowDialog();
        }

        private void ActualizarPacienteLaboral(Entidades.Profesional profesional)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                frmLaboral = new frmPacienteLaboral();
            }
            Entidades.PacienteLaboral paciente = new Entidades.PacienteLaboral();

            paciente.TelefonoCelular = profesional.Celular;
            paciente.TelefonoParticular = profesional.Telefono;
            paciente.Mail = profesional.Mail;
            paciente.Direccion = profesional.Direccion;
            paciente.Dni = profesional.DNI;

            profesionales.ActualizaBasicaPaciente(paciente);
            frmLaboral.ActualizaDireccionPacientelaboral(profesional);
            //this.Close();
        }

        public void retornoValores(frmPacienteLaboral frm)
        {
            //Entidades.Profesional profesional = new Entidades.Profesional();

            //profesional.Direccion = tbDireccion.Text;
            //profesional.Celular = tbCelular.Text;
            //profesional.Telefono = tbTelefono.Text;
            //profesional.Mail = tbMail.Text;

            //frm.ActualizaDireccionPacientelaboral(profesional);
        }

        private void chkTieneHorario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTieneHorario.Checked)
            {
                btnHorario.Enabled = true;
            }else
            {
                btnHorario.Enabled = false;
            }
        }

        private void dgv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv.IsCurrentCellDirty)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                //profesionales.ActualizaProfesionalActivo(dgv1.Rows[dgv1.CurrentCell.RowIndex].Cells[0].Value.ToString(), bool.Parse(dgv1.Rows[dgv1.CurrentCell.RowIndex].Cells[7].Value.ToString()));
                //profesionalActivo();
                Puntero = dgv1.CurrentCell.RowIndex;
            }

            if (e.ColumnIndex == 8)
            {
                //profesionales.ActualizaProfesionalTieneHorario(dgv1.Rows[dgv1.CurrentCell.RowIndex].Cells[0].Value.ToString(), bool.Parse(dgv1.Rows[dgv1.CurrentCell.RowIndex].Cells[7].Value.ToString()));
                //profesionalHorario();
            }            
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.Rows.Count > 0)
            {
                Puntero = dgv1.CurrentCell.RowIndex;
                VerProfesional();
            }            
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.Rows.Count > 0)
            {
                botModificar.Enabled = true;
                botModificar.Visible = true;
                botGuardar.Enabled = true;
                botGuardar.Visible = true;
            }
        }

        private void VerProfesional()
        {
            Puntero = 0;

            if (dgv1.Rows.Count > 0)
            {
                string strIdProfesional = "";

                if (dgv1.CurrentCell.RowIndex > 0)
                {
                    Puntero = dgv1.CurrentCell.RowIndex;
                    //strIdProfesional = dgv.Rows[dgv.CurrentCell.RowIndex - 1].Cells[0].Value.ToString();
                    strIdProfesional = dgv1.Rows[Puntero].Cells[0].Value.ToString();
                }
                else
                {
                    //strIdProfesional = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    strIdProfesional = dgv1.Rows[Puntero].Cells[0].Value.ToString();
                }

                if (!string.IsNullOrEmpty(strIdProfesional))
                {
                    this.tabControl1.SelectedTab = tabPage2;
                    modoEdicion2(strIdProfesional);
                }
                else
                {
                    //MessageBox.Show("Ha ocurrido un problema al ingresar un nuevo profesional.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return;
                    
                }
            }
        }

        private void filtrar()
        {
            if (tbFiltro.Text.Length > 0)
            {
                DataTable tablaAuxiliar = new DataTable();
                foreach (DataGridViewColumn c in dgv1.Columns)
                {
                    tablaAuxiliar.Columns.Add(c.HeaderText);
                }
                dgv1.DataSource = null;
                DataRow[] drColection = listado.Select("Médico like '%" + tbFiltro.Text + "%'");
                foreach (DataRow r in drColection)
                {
                    tablaAuxiliar.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2],
                        r.ItemArray[3], r.ItemArray[4], r.ItemArray[5]);
                }
                dgv1.DataSource = tablaAuxiliar;
                dgv1.Columns[0].Visible = false;
                if (dgv1.Rows.Count > 0) { dgv1.Rows[0].Cells[1].Selected = true; }
            }
            else
            {
                cargarListadoLista();
            }
        }

        private void botFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void tbFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                filtrar();
            }
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            if (this.tabPage1.TabIndex == 0)
            {
                VerProfesional();
            }

            modificar();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == tabPage1)
            {
                botCancelar.PerformClick();
                botGuardar.Visible = true;
                botGuardar.Enabled = false;
                botCancelar.Visible = false;
                cargarListadoLista();
            }
            else
            {
                botGuardar.Visible = true;
                botGuardar.Enabled = false;
                botModificar.Enabled = false; ///****************
                botCancelar.Visible = true;
            }
        }

        private void profesionalActivo()
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgv1.Rows[dgv1.CurrentRow.Index].Cells[7];

            if (ch1.Value == null)
                ch1.Value = false;
                       
            switch (ch1.Value.ToString())
            {
                case "True":
                    {
                        ch1.Value = false;
                        break;
                    }
                case "False":
                    {
                        ch1.Value = true;                        
                        break;
                    }
            }
            
            profesionales.ActualizaProfesionalActivo(dgv1.Rows[dgv1.CurrentCell.RowIndex].Cells[0].Value.ToString(), bool.Parse(ch1.Value.ToString()));             
        }

        private void profesionalHorario()
        {
            DataGridViewCheckBoxCell ch2 = new DataGridViewCheckBoxCell();
            ch2 = (DataGridViewCheckBoxCell)dgv1.Rows[dgv1.CurrentRow.Index].Cells[8];
            
            if (ch2.Value == null)
                ch2.Value = false;

            switch (ch2.Value.ToString())
            {
                case "True":
                    {
                        ch2.Value = false;
                        break;
                    }
                case "False":
                    {
                        ch2.Value = true;
                        break;
                    }
            }
            
            profesionales.ActualizaProfesionalTieneHorario(dgv1.Rows[dgv1.CurrentCell.RowIndex].Cells[0].Value.ToString(), bool.Parse(ch2.Value.ToString()));
        }

        private void ActualizarHorarioActivo()
        {
            DataGridViewCheckBoxCell ck = new DataGridViewCheckBoxCell();

            foreach (DataGridViewRow r in dgv1.Rows)
            {               
                ck = r.Cells[7] as DataGridViewCheckBoxCell;
                if (ck.Value == null)
                    ck.Value = false;

                switch (ck.Value.ToString())
                {
                    case "True":
                        {
                            profesionales.ActualizaProfesionalActivo(r.Cells[0].Value.ToString(), true);
                            break;
                        }
                    case "False":
                        {
                            profesionales.ActualizaProfesionalActivo(r.Cells[0].Value.ToString(), false);
                            break;
                        }
                }

                ck = r.Cells[8] as DataGridViewCheckBoxCell;
                if (ck.Value == null)
                    ck.Value = false;

                switch (ck.Value.ToString())
                {
                    case "True":
                        {
                            profesionales.ActualizaProfesionalTieneHorario(r.Cells[0].Value.ToString(), true);
                            break;
                        }
                    case "False":
                        {
                            profesionales.ActualizaProfesionalTieneHorario(r.Cells[0].Value.ToString(), false);
                            break;
                        }
                }
            }
        }
    }
}
