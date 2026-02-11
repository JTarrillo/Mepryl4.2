using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using Comunes;
using System.IO;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmPacienteLaboral : DevExpress.XtraEditors.XtraForm
    {
        string test = string.Empty;
        private string busqueda = string.Empty;
        private CapaNegocioMepryl.PacienteLaboral pacienteLaboral;
        private CapaNegocioMepryl.UbicacionFotos DirectorioFotos;
        private string strDniAnterior = ""; // GRV - Ramírez - Poder mdificar el DNI
        private CapaNegocioMepryl.UtilidadesMepryl UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl();
        Comunes.Configuracion config = new Comunes.Configuracion();

        public delegate void DelegateDevolverID(string idPaciente, string idEmpresa);
        public DelegateDevolverID objDelegateDevolverID = null;
        private int celda = -1;
        private string strIdProfesional = "";

        public frmPacienteLaboral()
        {
            InitializeComponent();
            inicializar();
            tbEmpresa.Select();
        }

        public frmPacienteLaboral(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            inicializar();
            tbEmpresa.Select();
            config = parentForm.configuracion;
        }

        private void inicializar()
        {
            btnEliminarPaciente.Enabled = false;
            btnEliminarPaciente.Visible = false;
            pacienteLaboral = new PacienteLaboral();
            DirectorioFotos = new UbicacionFotos();
            llenarCboNacionalidad();
            modoInicio();
            tbEmpresa.Text = "Presione F1 para buscar";
            tbEmpresa.ForeColor = Color.Gray;
            tbPaciente.Text = "Presione F1 para buscar";
            tbPaciente.ForeColor = Color.Gray;
        }

        private void llenarCboNacionalidad()
        {
            cboNacionalidad.DataSource = pacienteLaboral.cargarNacionalidades();
            cboNacionalidad.DisplayMember = "descripcion";
            cboNacionalidad.ValueMember = "id";
            cboNacionalidad.SelectedIndex = -1;
        }

        public void cargarPacienteEspecifico(string idEmpresa, string idPaciente)
        {
            tbIdPaciente.Text = idPaciente;
            tbIdEmpresa.Text = idEmpresa;
            Entidades.PacienteLaboral paciente = pacienteLaboral.leerDatosEntidad(tbIdPaciente.Text, tbIdEmpresa.Text);
            llenarFormulario(paciente);
            //cboSexo.Focus();
            cboSexo.Select();
            tbPaciente.Text = tbDNI.Text + " | " + tbApellido.Text + " " + tbNombre.Text;
            tbEmpresa.Text = pacienteLaboral.cargarCuilRazonSocialEmpresa(idEmpresa);
            modoEdicion();
        }

        private void modoInicio()
        {
            panelDatos.Visible = true;
            panelDatos.Enabled = true;
            panelBusqueda.Visible = false;
            tabControl.Enabled = false;
            botGuardar.Visible = false;
            botCancelar.Visible = false;
            btnEliminarPaciente.Visible = false;
            botBuscarDNI.Visible = false;
        }

        private void busquedaEmpresa()
        {
            busqueda = "E";
            llenarDgv();
        }

        private void llenarDgv()
        {
            dgvBusqueda.DataSource = pacienteLaboral.cargarDataGridBusqueda(busqueda, tbBusqueda.Text, tbIdEmpresa.Text);
            dgvBusqueda.Columns[0].Visible = false;
            lblPacienteNoEncontrado.Visible = false;
            botAltaPaciente.Visible = false;
            if (busqueda == "P")
            {
                botAltaPaciente.Visible = true;
                if (dgvBusqueda.Rows.Count == 0)
                {
                    lblPacienteNoEncontrado.Visible = true;
                }
            }
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            llenarDgv();
        }

        private void dgvBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
   
            if (dgvBusqueda.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (busqueda == "E")
                {
                    cargarDatosEmpresa();
                }
                else
                {
                    setearDatosPaciente();
                    cargarDatosPaciente();
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                modoInicio();
                if (busqueda == "P")
                {
                    tbPaciente.Focus();
                    tbPaciente.Select();
                }
                else
                {
                    tbEmpresa.Focus();
                    tbEmpresa.Select();
                }
            }
        }

        private void cargarDatosEmpresa()
        {
            tbIdEmpresa.Text = dgvBusqueda.SelectedRows[0].Cells[0].Value.ToString();
            tbEmpresa.Text = dgvBusqueda.SelectedRows[0].Cells[1].Value.ToString() + "  |  " +
                dgvBusqueda.SelectedRows[0].Cells[2].Value.ToString();
            modoInicio();
            tbIdPaciente.Clear();
            tbPaciente.Clear();
            tbPaciente.Focus();            
            limpiarFicha();
        }
        
        private void dgvBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }


        private void busquedaPaciente()
        {
            busqueda = "P";
            llenarDgv();
        }

        private void cargarDatosPaciente()
        {
                modoEdicion();
                cargarPaciente();
        }

        private void modoEdicion()
        {
            panelBusqueda.Visible = false;
            panelDatos.Enabled = false;
            tabControl.Enabled = true;
            botCancelar.Visible = true;
            botGuardar.Visible = true;
            panelBusquedaDni.Enabled = true;
            panelDatosPersonales.Enabled = true;
            panelDomicilio.Enabled = true;
            panelContacto.Enabled = true;
        }

        private void tbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                modoBusqueda();
                busquedaEmpresa();

            }
            else if (e.KeyCode == Keys.Enter && tbIdEmpresa.Text != string.Empty)
            {
                tbPaciente.Focus();
                SendKeys.Send("{F1}");
            }            
        }

        private void tbPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (tbIdEmpresa.Text != string.Empty)
                {
                    modoBusqueda();
                    busquedaPaciente();
                    chkProfesional.Visible = pacienteLaboral.EsEmpresaPrincipal(tbIdEmpresa.Text); //
                    //btnHorario.Visible = chkProfesional.Visible;
                }
                else
                {
                    MessageBox.Show("¡Se debe seleccionar una empresa!", "Seleccionar Empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (tbIdEmpresa.Text != string.Empty && tbIdPaciente.Text != string.Empty)
                {
                    cargarDatosPaciente();
                    modoEdicion();
                }
            }
        }

        private void modoBusqueda()
        {
            panelDatos.Enabled = false;
            panelBusqueda.Visible = true;
            tbBusqueda.Clear();
            tbBusqueda.Focus();
        }

        private void tbBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvBusqueda.Rows.Count == 1)
            {
                if (busqueda == "E")
                {
                    cargarDatosEmpresa();
                }
                else
                {
                    setearDatosPaciente();
                    cargarDatosPaciente();
                }
            }
            else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down) && dgvBusqueda.Rows.Count > 1)
            {
                dgvBusqueda.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                modoInicio();
                if (busqueda == "P")
                {
                    tbPaciente.Focus();
                    tbPaciente.Select();
                }
                else
                {
                    tbEmpresa.Focus();
                    tbEmpresa.Select();
                }
            }
            else if (e.KeyCode == Keys.F2 && busqueda == "P")
            {
                habilitarAltaPaciente();
            }
        }

        private void cargarPaciente()
        {
            limpiarFicha();
            if (tbPaciente.Text != string.Empty)
            {
                Entidades.PacienteLaboral paciente = pacienteLaboral.leerDatosEntidad(tbIdPaciente.Text, tbIdEmpresa.Text);
                if (!TieneConsulta(paciente))
                {
                    btnEliminarPaciente.Visible = true;
                    btnEliminarPaciente.Enabled = true;
                }
                else
                {
                    btnEliminarPaciente.Visible = false;
                    btnEliminarPaciente.Enabled = false;
                }
                llenarFormulario(paciente);
                cboSexo.Focus();
            }
        }

        private bool TieneConsulta(Entidades.PacienteLaboral paciente)
        {
            DataTable info = new DataTable();
                info = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as idConsulta
                from dbo.Consulta c 
			    inner join dbo.PacienteLaboral pl on pl.id=c.pacienteID 
                where c.pacienteID = '" + paciente.Id.ToString() + "'");
            if (info.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void refreshHistoriaClinica()
        {
            Entidades.PacienteLaboral paciente = pacienteLaboral.leerDatosEntidad(tbIdPaciente.Text, tbIdEmpresa.Text);
            dgvHistoriaClinica.Rows.Clear();
            llenarDgvHistoriaClinica(paciente.HistoriaClinica);
        }

        private void limpiarFicha()
        {
            tbApellido.Clear();
            tbNombre.Clear();
            cboSexo.SelectedIndex = -1;
            tbDNI.Clear();
            tbCuil.Clear();
            tbNacimiento.Clear();
            txtEdad.Clear();
            cboNacionalidad.SelectedIndex = -1;
            tbTarea.Clear();
            tbTarea2.Clear();
            tbDireccion.Clear();
            tbEntreCalle1.Clear();
            tbEntreCalle2.Clear();
            tbLocalidad.Clear();
            tbIdLocalidad.Clear();
            tbTelefonoCelular.Clear();
            tbTelefonoParticular.Clear();
            tbMail.Clear();
            dgvHistoriaClinica.Rows.Clear();
            pbFoto.Image = null;
            pbFoto2.Image = null;
            tbIngreso.Clear();
            tbIngreso2.Clear();
            txtAntiguedad.Clear(); // GRV Modificado
            chkProfesional.Checked = false;
        }

        private void llenarFormulario(Entidades.PacienteLaboral paciente)
        {
            tbApellido.Text = paciente.Apellido;
            tbNombre.Text = paciente.Nombre;
            if (paciente.Nacimiento != new DateTime(1800, 1, 1))
            {
                tbNacimiento.Text = paciente.Nacimiento.ToString();
                //Calcular Edad
                txtEdad.Text =(DateTime.Today.AddTicks(-paciente.Nacimiento.Ticks).Year - 1).ToString();
            }
            if (paciente.Sexo != string.Empty) { cboSexo.SelectedItem = paciente.Sexo; }
            cboNacionalidad.SelectedIndex = 0;
            if (paciente.Nacionalidad != Guid.Empty) 
            { 
                cboNacionalidad.SelectedValue = paciente.Nacionalidad; 
            }
            tbDireccion.Text = paciente.Direccion;
            tbEntreCalle1.Text = paciente.EntreCalle1;
            tbEntreCalle2.Text = paciente.EntreCalle2;
            tbTelefonoCelular.Text = paciente.TelefonoCelular;
            tbTelefonoParticular.Text = paciente.TelefonoParticular;
            tbDNI.Text = paciente.Dni.ToString();
            strDniAnterior = paciente.Dni.ToString(); // GRV - Ramírez - Modificar el DNI;
            tbTarea.Text = paciente.Tarea;
            tbTarea2.Text = paciente.Tarea;
            tbMail.Text = paciente.Mail;            

            if (paciente.Ingreso != new DateTime(1800, 1, 1))
            {
                tbIngreso.Text = paciente.Ingreso.ToString();
                tbIngreso2.Text = paciente.Ingreso.ToShortDateString();
                txtAntiguedad.Text = CalcularAntiguedad(paciente.Ingreso); // GRV - Modificado
            }
            if (paciente.IdLocalidad != Guid.Empty) { tbIdLocalidad.Text = paciente.IdLocalidad.ToString(); tbLocalidad.Text = paciente.LocalidadTexto; }
            calculoCuil();
            cargarImagen();

            chkProfesional.Checked = paciente.EsProfesional;    //
            chkProfesional.Visible = pacienteLaboral.EsEmpresaPrincipal(tbIdEmpresa.Text); //

            llenarDgvHistoriaClinica(paciente.HistoriaClinica);

        }

        private void llenarDgvHistoriaClinica(DataTable historia)
        {
            Image imgCli = null;
            Image imgLab = null;
            Image imgCons = null;
            Image imgEnv = null;
            dgvHistoriaClinica.DataSource = null;

            foreach (DataRow dr in historia.Rows)
            {
                imgCli = Image.FromFile("P:\\img-system\\blanco.png");
                imgLab = Image.FromFile("P:\\img-system\\blanco.png");
                imgCons = Image.FromFile("P:\\img-system\\blanco.png");
                imgEnv = Image.FromFile("P:\\img-system\\blanco.png");

                if (!(string.IsNullOrEmpty(dr.ItemArray[14].ToString())))
                {
                    if (dr.ItemArray[14].ToString() == "1")
                        imgCli = Image.FromFile("P:\\img-system\\tick.png");
                }
                if (!(string.IsNullOrEmpty(dr.ItemArray[15].ToString())))
                {
                    if (dr.ItemArray[15].ToString() == "1")
                        imgLab = Image.FromFile("P:\\img-system\\tick.png");
                }
                if (!(string.IsNullOrEmpty(dr.ItemArray[16].ToString())))
                {
                    if (dr.ItemArray[16].ToString() == "1")
                        imgCons = Image.FromFile("P:\\img-system\\tick.png");
                }

                dgvHistoriaClinica.Rows.Add(dr.ItemArray[0], dr.ItemArray[1],
                    dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4], dr.ItemArray[5], dr.ItemArray[6],
                    dr.ItemArray[7], dr.ItemArray[8], dr.ItemArray[9], null, imgCli, imgLab, imgCons, imgEnv);
            }
            dgvHistoriaClinica.Columns[0].Visible = false;
            dgvHistoriaClinica.Columns[1].Visible = false;
            dgvHistoriaClinica.Columns[2].Visible = false;
            dgvHistoriaClinica.Columns[4].Visible = false;
            colorearFilasHistoriaClinica();
        }

        private void colorearFilasHistoriaClinica()
        {
            foreach (DataGridViewRow row in dgvHistoriaClinica.Rows)
            {
                Color color = Color.White;
                switch (row.Cells[4].Value.ToString())
                {
                    case "P":
                        color = Color.MistyRose;
                        break;
                    case "L":
                        color = Color.Moccasin;
                        break;
                    case "EC":
                        color = Color.Azure;
                        break;
                    case "CO":
                        color = Color.LightSteelBlue;
                        break;
                    case "R":
                        color = Color.LightYellow;
                        break;
                }
                row.DefaultCellStyle.BackColor = color;
            }
        }

        private void cargarImagen()
        {
            try
            {  
                //GRV - Ramírez - Modificado
                //FileStream fs = new System.IO.FileStream(@"S:/FOTOS/" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                FileStream fs = new System.IO.FileStream(DirectorioFotos.UbicacionFotoLaboral() + "\\" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                pbFoto.Image = Image.FromStream(fs);
                pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                pbFoto2.Image = Image.FromStream(fs);
                pbFoto2.SizeMode = PictureBoxSizeMode.StretchImage;
                fs.Close();
            }
            catch
            {
                pbFoto.Image = null;
            }
        }

        private void modoBusquedaLocalidad()
        {
            panelLocalidad.Visible = true;
            tbBusquedaLocalidad.Clear();
            tbBusquedaLocalidad.Focus();
        }

        private void llenarDgvLocalidades()
        {
            lblAnadirLocalidad.Visible = false;
            dgvLocalidad.DataSource = pacienteLaboral.cargarDataGridLocalidad(tbBusquedaLocalidad.Text);
            dgvLocalidad.Columns[0].Visible = false;

            if (dgvLocalidad.Rows.Count == 0)
            {
                lblAnadirLocalidad.Visible = true;
            }
        }

        private void tbLocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                modoBusquedaLocalidad();
                llenarDgvLocalidades();
            }
        }

        private void tbBusquedaLocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvLocalidad.Rows.Count == 1)
            {
                tbLocalidad.Text = dgvLocalidad.SelectedRows[0].Cells[1].Value.ToString();
                tbIdLocalidad.Text = dgvLocalidad.SelectedRows[0].Cells[0].Value.ToString();
                panelLocalidad.Visible = false;
                tbLocalidad.Focus();
            }
            else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down) && dgvLocalidad.Rows.Count > 1)
            {
                dgvLocalidad.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                panelLocalidad.Visible = false;
                tbLocalidad.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {
                frmABMPrestaciones frmPrestaciones = new frmABMPrestaciones();
                frmPrestaciones.ShowDialog();
            }
        }

        private void dgvLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvLocalidad.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                tbLocalidad.Text = dgvLocalidad.SelectedRows[0].Cells[1].Value.ToString();
                tbIdLocalidad.Text = dgvLocalidad.SelectedRows[0].Cells[0].Value.ToString();
                panelLocalidad.Visible = false;
                tbLocalidad.Focus();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                panelLocalidad.Visible = false;
                tbLocalidad.Focus();
            }
        }

        private void dgvLocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbBusquedaLocalidad_TextChanged(object sender, EventArgs e)
        {
            llenarDgvLocalidades();
        }

        private void tbDNI_Leave(object sender, EventArgs e)
        {
            calculoCuil();
        }

        private void cboSexo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            calculoCuil();
        }

        private void calculoCuil()
        {
            if (cboSexo.SelectedIndex != -1)
            {
                tbCuil.Text = Utilidades.calcularCuil(tbDNI.Text, cboSexo.SelectedItem.ToString());
            }
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDNI.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el DNI del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(tbApellido.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el apellido del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (tbNacimiento.Text == "  /  /")
            {
                MessageBox.Show("Para continuar debe ingresar la fecha de nacimiento del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el nombre del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (cboSexo.SelectedItem == null)
            {
                MessageBox.Show("Para continuar debe ingresar el sexo del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            guardarFicha();            
        }

        private void guardarFicha()
        {
            if (tbIdPaciente.Text != string.Empty)
            {
                guardarPacienteEditado();
            }
            else
            {
                nuevoPaciente();                
            }
        }

        private void nuevoPaciente()
        {            
            Entidades.Resultado resultado = pacienteLaboral.guardarDatosEntidadNueva(llenarEntidad());

            //if (chkProfesional.Visible)
            //{
            //    if (chkProfesional.Checked)
            //    {
            //        CapaNegocioMepryl.Profesionales profesionales = new CapaNegocioMepryl.Profesionales(); //
            //        Entidades.Profesional profesional = cargarDatosProfesional(); //
            //        Entidades.Resultado resulPro = profesionales.nuevoProfesional(profesional); //
            //    }

            //    CapaNegocioMepryl.UsuarioSistema usuarios = new CapaNegocioMepryl.UsuarioSistema();
            //    Entidades.UsuarioSistema usuario = cargarDatosUsuarios();
            //    usuarios.GuardarUsuario(usuario);
            //}

            GuardaActualizaPaciente();

            switch (resultado.Modo)
            {
                case 1:
                    tbIdPaciente.Text = resultado.Mensaje;
                    tbPaciente.Text = tbDNI.Text + " | " + tbApellido.Text + " " + tbNombre.Text;
                    modoInicio();
                    cargarPaciente();
                    if (objDelegateDevolverID != null)
                    {
                        objDelegateDevolverID(tbIdPaciente.Text, tbIdEmpresa.Text);
                        this.Close();
                    }    
                    break;
                case 2:
                    MessageBox.Show("¡Error al guardar los datos del paciente!\n\nError:" + resultado.Mensaje, "Guardar Paciente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("¡El DNI ingresado está asignado a otro paciente, por favor verifique!", "Guardar Paciente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void guardarPacienteEditado()
        {            
            Entidades.Resultado resultado;
            
            resultado = pacienteLaboral.guardarDatosEntidadEdicion(llenarEntidad());

            //if (chkProfesional.Visible)
            //{
            //    if (chkProfesional.Checked)
            //    {
            //        CapaNegocioMepryl.Profesionales profesionales = new CapaNegocioMepryl.Profesionales(); //
            //        Entidades.Profesional profesional = cargarDatosProfesional(); //  
            //        Entidades.Resultado resulPro = profesionales.editarProfesional(profesional); //
            //    }

            //    CapaNegocioMepryl.UsuarioSistema usuarios = new CapaNegocioMepryl.UsuarioSistema();
            //    Entidades.UsuarioSistema usuario = cargarDatosUsuarios();
            //    usuarios.ActualizarUsuario(usuario);
            //}
            GuardaActualizaPaciente();

            switch (resultado.Modo)
            {
                case 1: 
                    modoInicio();
                    cargarPaciente();
                    if (objDelegateDevolverID != null)
                    {
                        objDelegateDevolverID(tbIdPaciente.Text, tbIdEmpresa.Text);
                        cargarDatosProfesional();
                        
                        this.Close();
                    }    
                    break;
                case 2:
                    MessageBox.Show("¡Error al guardar los datos del paciente!\n\nError:" + resultado.Mensaje, "Guardar Paciente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("¡El DNI ingresado está asignado a otro paciente, por favor verifique!", "Guardar Paciente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private Entidades.PacienteLaboral llenarEntidad()
        {            
            Entidades.PacienteLaboral retorno = new Entidades.PacienteLaboral();
            
            if (tbIdPaciente.Text != string.Empty) { retorno.Id = new Guid(tbIdPaciente.Text); }
            if (cboSexo.SelectedIndex != -1){ retorno.Sexo = cboSexo.SelectedItem.ToString();}
            retorno.Dni = tbDNI.Text;
            retorno.Cuil = tbCuil.Text.Replace("-", "");
            retorno.Apellido = tbApellido.Text;
            retorno.Nombre = tbNombre.Text;
            retorno.DniAnterior = strDniAnterior; // GRV - Ramírez - Poder mdificar el DNI
            // GRV - Ramírez - Poder mdificar el DNI
            //CapaNegocioMepryl.PacienteLaboral objRecuperarPaciente = new CapaNegocioMepryl.PacienteLaboral();
            //strIDPaciente = objRecuperarPaciente.obtenerIdPaciente(strDNI);
            //retorno.DniAnterior = 
            //Entidades.PacienteLaboral paciente = new Entidades.PacienteLaboral();

            try
            {
                retorno.Nacimiento = Convert.ToDateTime(tbNacimiento.Text);
            }
            catch
            {
                retorno.Nacimiento = new DateTime(1800, 1, 1);
            }     
            if (cboNacionalidad.SelectedIndex > 0) { retorno.Nacionalidad = new Guid(cboNacionalidad.SelectedValue.ToString());}
            retorno.Tarea = tbTarea.Text;
            retorno.Direccion = tbDireccion.Text;
            retorno.EntreCalle1 = tbEntreCalle1.Text;
            retorno.EntreCalle2 = tbEntreCalle2.Text;
            if (tbIdLocalidad.Text != string.Empty) { retorno.IdLocalidad = new Guid(tbIdLocalidad.Text); }
            retorno.TelefonoCelular = tbTelefonoCelular.Text;
            retorno.TelefonoParticular = tbTelefonoParticular.Text;
            retorno.Mail = tbMail.Text;
            retorno.IdEmpresa = new Guid(tbIdEmpresa.Text);
            try
            {
                retorno.Ingreso = Convert.ToDateTime(tbIngreso.Text);
            }
            catch
            {
                retorno.Ingreso = new DateTime(1800, 1, 1);
            }
            retorno.EsProfesional = chkProfesional.Checked;

            return retorno;
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            modoInicio();
            cargarPaciente();
            if (objDelegateDevolverID != null)
            {
                this.Close();
            } 
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // GRV - Ramírez - El sistema se cuelga al llamar a este metodo
            SendKeys.Send("{ENTER}");
            //KeyEventArgs ee = new KeyEventArgs(Keys.Enter);            
            //dgvBusqueda_KeyDown(sender, ee);
        }

        private void dgvLocalidad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void habilitarAltaPaciente()
        {
            limpiarFicha();
            panelBusqueda.Visible = false;
            tbIdPaciente.Clear();
            tbPaciente.Clear();
            panelDatos.Enabled = false;
            tabControl.Enabled = true;
            panelDomicilio.Enabled = false;
            panelContacto.Enabled = false;
            panelDatosPersonales.Enabled = false;
            panelBusquedaDni.Enabled = true;
            cboSexo.Focus();
            botCancelar.Visible = true;
            botBuscarDNI.Visible = true;

        }

        private void botAltaPaciente_Click(object sender, EventArgs e)
        {
            habilitarAltaPaciente();
        }

        private void altaDePaciente()
        {
            Entidades.Resultado resultado = pacienteLaboral.verificarDNIIngresadoEnEmpresa(tbDNI.Text, tbIdEmpresa.Text);
            if (resultado.Modo == 1)
            {
                cargarImagen();
                cboNacionalidad.SelectedIndex = 0;
            }
            else if (resultado.Modo == 2)
            {
                MessageBox.Show("¡El DNI ingresado ya se encuentra dado de alta en la empresa seleccionada!",
                    "Alta de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDatosPacientePorDni();
            }
            else
            {
                MessageBox.Show("El DNI ingresado se encuentra dado de alta en la empresa " + resultado.Mensaje,
                   "Alta de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDatosPacientePorDni();
            }
            botBuscarDNI.Visible = false;
            modoEdicion();
            tbApellido.Focus();

        }

        private void tbDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbIdPaciente.Text == string.Empty)
            {
                altaDePaciente();
                calculoCuil();
            }
        }

        private void cargarDatosPacientePorDni()
        {
            Entidades.PacienteLaboral paciente = pacienteLaboral.leerDatosEntidad(pacienteLaboral.obtenerIdPaciente(tbDNI.Text),tbIdEmpresa.Text);
            llenarFormulario(paciente);
            tbIdPaciente.Text = paciente.Id.ToString();
            tbPaciente.Text = paciente.Dni + " | " + paciente.Apellido + " " + paciente.Nombre;
            cboSexo.Focus();
        }

        private void setearDatosPaciente()
        {
            tbIdPaciente.Text = dgvBusqueda.SelectedRows[0].Cells[0].Value.ToString();
            tbPaciente.Text = dgvBusqueda.SelectedRows[0].Cells[1].Value.ToString() +
                " | " + dgvBusqueda.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void botBuscarDNI_Click(object sender, EventArgs e)
        {
            altaDePaciente();
            calculoCuil();
        }

        private void tabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && botGuardar.Visible)
            {
                botGuardar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && botCancelar.Visible)
            {
                botCancelar.PerformClick();
            }
        }

        private void dobleClickHistoriaClinica(DataGridViewCellEventArgs e)
        {
            celda = e.ColumnIndex;

            if (e.RowIndex >= 0 && e.ColumnIndex == 10)
            {
                if (dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[4].Value.ToString()
                    == "CO")
                {
                    abrirFormularioConsultorio();
                }
                else if (dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[4].Value.ToString()
                    == "L")
                {
                    abrirFormularioExamen();
                }
                else if(dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[4].Value.ToString()
                    == "EC")
                {
                    abrirFormularioEstudios();
                }
            }
            
            if (e.ColumnIndex == 13)
            {
                ExamenSeleccionado();
            }
        }

        private void abrirFormularioEstudios()
        {
            frmExamenLaboral el = new frmExamenLaboral();
            el.setearValoresEstudioComplementario(dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[1].Value.ToString(), tbIdEmpresa.Text);
            el.Show();
            el.objDelegateRefreshHistoria = new frmExamenLaboral.DelegateRefreshHistoriaClinica(refreshHistoriaClinica);
            //ec.CargaDatos(pacienteLaboral.cargarIdConsultaLaboral(dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[1].Value.ToString())); //error
        }

        private void abrirFormularioConsultorio()
        {
            frmConsultorio fConsultorio = new frmConsultorio();
            fConsultorio.setearValores(pacienteLaboral.cargarIdConsultorioLaboral(dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[1].Value.ToString()), 
            tbIdEmpresa.Text);
            fConsultorio.objDelegateRefreshHistoria = new frmConsultorio.DelegateRefreshHistoriaClinica(refreshHistoriaClinica);
            fConsultorio.ShowDialog();
        }

        private void dgvHistoriaClinica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dobleClickHistoriaClinica(e);                        
        }

        private void abrirFormularioExamen()
        {
            frmExamenLaboral fExamen = new frmExamenLaboral();
            fExamen.Show();
            fExamen.setearValores(pacienteLaboral.cargarIdConsultaLaboral(dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[1].Value.ToString()),
            tbEmpresa.Text, tbTarea.Text, tbApellido.Text + " " + tbNombre.Text, dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[3].Value.ToString(),
            dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[5].Value.ToString(),
            dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[6].Value.ToString(),
            tbDNI.Text, pacienteLaboral.cargarIdExamenLaboral(dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[1].Value.ToString()), tbIdEmpresa.Text);
            fExamen.objDelegateRefreshHistoria = new frmExamenLaboral.DelegateRefreshHistoriaClinica(refreshHistoriaClinica);
        }

        private void botImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void imprimir()
        {
            if (tpDesde.Value <= tpHasta.Value)
            {
                Reportes report = new Reportes(new rptHistoriaClinica());
                report.setearDataSource(new dsHistoriaClinica(), pacienteLaboral.cargarHistoriaClinicaReporte(tbIdPaciente.Text, tbIdEmpresa.Text,
                    tpDesde.Value.ToShortDateString(),
                    tpHasta.Value.ToShortDateString()), pacienteLaboral.cargarDataSourceReporteHistoriaClinica());
                Entidades.PacienteLaboral paciente = pacienteLaboral.leerDatosEntidad(tbIdPaciente.Text, tbIdEmpresa.Text);
                DataTable parametros = new DataTable();
                parametros.Columns.Add("ApellidoNombre");
                parametros.Columns.Add("DNI");
                parametros.Columns.Add("Empresa");
                parametros.Rows.Add(paciente.Apellido + " " + paciente.Nombre, paciente.Dni, paciente.Empresa);
                report.setearParametrosReporte(parametros);
                report.imprimir();
            }
            else
            {
                MessageBox.Show("La fecha DESDE debe ser menor que la fecha HASTA",
                    "Imprimir Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // GRV - Ramírez - recuperar directorio
        private string DirectorioReporte()
        {
            byte bytTipo = 6;
            string strDirectorio = "";

            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"select reporte from dbo.ConfigReportes
            where tipoReporte = '" + bytTipo + "'");

            if (valores.Rows.Count > 0)
            {
                strDirectorio = valores.Rows[0].ItemArray[0].ToString() + "\\";
            }
            else
            {
                strDirectorio = "P:\\HISTORIAS CLINICAS\\";
            }

            return strDirectorio;
        }

        private void mail()
        {
            if (tpDesde.Value <= tpHasta.Value)
            {
                Reportes report = new Reportes(new rptHistoriaClinica());
                report.setearDataSource(new dsHistoriaClinica(), pacienteLaboral.cargarHistoriaClinicaReporte(tbIdPaciente.Text, tbIdEmpresa.Text,
                    tpDesde.Value.ToShortDateString(),
                    tpHasta.Value.ToShortDateString()), pacienteLaboral.cargarDataSourceReporteHistoriaClinica());
                Entidades.PacienteLaboral paciente = pacienteLaboral.leerDatosEntidad(tbIdPaciente.Text, tbIdEmpresa.Text);
                DataTable parametros = new DataTable();
                parametros.Columns.Add("ApellidoNombre");
                parametros.Columns.Add("DNI");
                parametros.Columns.Add("Empresa");
                parametros.Rows.Add(paciente.Apellido + " " + paciente.Nombre, paciente.Dni, paciente.Empresa);
                report.setearParametrosReporte(parametros);

                List<string> archivos = new List<string>();
                //string ruta = report.exportarAPDF(@"P:\HISTORIAS CLINICAS\" + tbDNI.Text + "-" + DateTime.Today.ToShortDateString().Replace('/', '-') + ".pdf");
                string ruta = report.exportarAPDF(DirectorioReporte() + tbDNI.Text + "-" + DateTime.Today.ToShortDateString().Replace('/', '-') + ".pdf");
                archivos.Add(ruta);

                frmMail frm = frmMail.GetForm();
                frm.archivosAdjuntos(archivos);
           
                frm.setearAsunto("HISTORIA CLINICA");
                frm.setearMensaje("Adjuntamos al presente mail la historia clinica solicitada.");
                frm.mailLaboral();
                frm.mostrar(this.MdiParent);

            }
            else
            {
                MessageBox.Show("La fecha DESDE debe ser menor que la fecha HASTA",
                    "Imprimir Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botMail_Click(object sender, EventArgs e)
        {
            mail();
        }

        private void pbFoto_DoubleClick(object sender, EventArgs e)
        {
            if (tbDNI.Text != string.Empty)
            {
                frmFotoPaciente fFoto = new frmFotoPaciente(tbDNI.Text, 'L');
                fFoto.ShowDialog();
                cargarImagen();
            }
            else
            {
                MessageBox.Show("Debe ingresar primero el DNI del paciente", "Foto paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //DialogResult rpta = MessageBox.Show("La ventana se cerrará y perderá las modificaciones que no hayan guardado", "Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (rpta == DialogResult.Yes)
            //{
                this.Close();
            //}
        }

        // GRV - Modificado
        private string CalcularAntiguedad(DateTime fechaComienzo)
        {
            string strAntiguedad = "";
            string strNum = "";
            DateTime fechaFin = DateTime.Now.Date;            
            int intMeses = 0;
            int intAnio = 0;

            fechaComienzo = fechaComienzo.Date;
                        
            while (fechaComienzo < fechaFin)
            {
                fechaComienzo = fechaComienzo.AddMonths(1);
                intMeses++;
            }

            intMeses--;

            if (intMeses < 12)
                strAntiguedad = "0 años y " + intMeses + " meses";
            else if(intMeses < 24)
                strAntiguedad = "1 año y " + (intMeses - 12) + " meses";
            else if (intMeses < 36)
                strAntiguedad = intAnio + "2 años y " + (intMeses - 24) + " meses";
            else if (intMeses < 48)
                strAntiguedad = intAnio + "3 años y " + (intMeses - 36) + " meses";
            else if (intMeses < 60)
                strAntiguedad = intAnio + "4 años y " + (intMeses - 48) + " meses";
            else if (intMeses < 72)
                strAntiguedad = intAnio + "5 años y " + (intMeses - 60) + " meses";
            else if (intMeses < 84)
                strAntiguedad = intAnio + "6 años y " + (intMeses - 72) + " meses";
            else if (intMeses < 96)
                strAntiguedad = intAnio + "+6 años y " + (intMeses - 84) + " meses";
                        
            return strAntiguedad;
        }

        private void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            frmBusquedaPacienteLaboral f = new frmBusquedaPacienteLaboral(this);
            f.ShowDialog();
        }

        private void tbNacimiento_Leave(object sender, EventArgs e)
        {               
            try
            {                
                DateTime dtNacimiento = Convert.ToDateTime(tbNacimiento.Text);
                DateTime dtHoy = DateTime.Today;

                if ((DateTime.Compare(dtNacimiento, dtHoy)) < 0)
                    txtEdad.Text = (DateTime.Today.AddTicks(-dtNacimiento.Ticks).Year - 1).ToString();
                else
                {
                    MessageBox.Show("Fecha de nacimiento no puede ser mayor a la fecha de hoy", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbNacimiento.Focus();
                    tbNacimiento.SelectedText = tbNacimiento.Text;
                }

            }catch(System.FormatException ex)
            {
                txtEdad.Text = "0";
            }
        }

        private void tbIngreso_Leave(object sender, EventArgs e)
        {
            try
            {
                DateTime dtIngreso = Convert.ToDateTime(tbIngreso.Text);
                DateTime dtHoy = DateTime.Today;

                if ((DateTime.Compare(dtIngreso, dtHoy)) > 0)
                {
                    //
                }
            }
            catch (System.FormatException ex)
            {
                //
            }
        }

        private void frmPacienteLaboral_Load(object sender, EventArgs e)
        {
            rbcMenu.Minimized = true;
            rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            tbEmpresa.Select();
        }

        private void bbiBuscarPaciente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnBuscarApellido_Click(sender, e);
        }

        private void bbiImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botImprimir_Click(sender, e);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botMail_Click(sender, e);
        }

        private void bbiAnadirEmpresa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBusquedaEmpresa FBusqueda = new frmBusquedaEmpresa();
            frmEmpresa frm = new frmEmpresa(FBusqueda);
            frm.modoNuevo();
            frm.ShowDialog();
        }

        private void frmPacienteLaboral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && botGuardar.Visible)
            {
                botGuardar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && botCancelar.Visible)
            {
                botCancelar.PerformClick();
            }
        }

        private void cboSexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && botGuardar.Visible)
            {
                botGuardar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && botCancelar.Visible)
            {
                botCancelar.PerformClick();
            }
        }

        private string DirectorioConsolidado()
        {
            CapaNegocioMepryl.ConsolidarReportes Consolidar = new CapaNegocioMepryl.ConsolidarReportes();
            string strDirectorioConsolidar = "";

            DataTable dt = Consolidar.DirectoriosLaboral();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    strDirectorioConsolidar = r.ItemArray[10].ToString();
                }
            }

            return strDirectorioConsolidar;
        }

        private void UbicarArchivoDisco(string FullPath)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + FullPath + "\"");
        }

        private void ExamenSeleccionado()
        {
            if (dgvHistoriaClinica.Rows.Count > 0)
            {
                celda = dgvHistoriaClinica.SelectedCells[0].ColumnIndex;
                foreach (DataGridViewCell cell in dgvHistoriaClinica.SelectedCells)
                {
                    if (celda == cell.ColumnIndex)
                    {
                        DataGridViewRow row = dgvHistoriaClinica.Rows[cell.RowIndex];                        
                        //if (row.Cells[9].Value.ToString() != "0" && row.Cells[1

                        AbrirCarperta(row.Cells[6].Value.ToString(), Convert.ToDateTime(row.Cells[3].Value.ToString()));
                    }
                }
            }
        }

        private void AbrirCarperta(string NroOrden, DateTime Fecha)
        {
            string strDia = "";
            string strMes = "";
            string strAnio = "";
            string strDirecConsolTemp = "";
            string strNombreMes = "";
            string strFechaCorta = "";
            string strFiltro = NroOrden + " -*";

            strDia = UtilMepryl.NroDia(Fecha).ToUpper();
            strMes = UtilMepryl.NroMes(Fecha).ToUpper();
            strNombreMes = UtilMepryl.NombreMes(Int32.Parse(strMes)).ToUpper();
            strAnio = Convert.ToString(Fecha.Year).ToUpper();
            strFechaCorta = strDia + "-" + strMes + "-" + strAnio;

            strDirecConsolTemp = DirectorioConsolidado() + "\\" + strAnio + "\\" + strMes + "-" + strNombreMes
                                                          + "\\" + strFechaCorta + "\\";

            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirecConsolTemp);
                foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                {
                    if (System.IO.File.Exists(fi.FullName))
                        //System.Diagnostics.Process.Start(fi.DirectoryName);
                        UbicarArchivoDisco(fi.FullName);
                    else
                        MessageBox.Show("No se encontro el archivo de consolidado en la ruta.\n" + fi.DirectoryName, "Examenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show("No se encontro el archivo de consolidado.", "Examenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Entidades.Profesional cargarDatosProfesional()
        {
            DataTable dt = null;            
            
            Entidades.Profesional retorno = new Entidades.Profesional();
            //dt = pacienteLaboral.ListaProfesionalLabora(tbDNI.Text);
            dt = pacienteLaboral.ListaProfesional(tbDNI.Text);

            if (dt.Rows.Count > 0)
            {
                strIdProfesional = dt.Rows[0].ItemArray[0].ToString();

                //retorno.NroDocumento = dt.Rows[0].ItemArray[24].ToString(); 
                //retorno.Activo = Convert.ToBoolean(dt.Rows[0].ItemArray[23].ToString());
                //retorno.CodigoPostal = dt.Rows[0].ItemArray[16].ToString();
                //retorno.LugarMatricula = dt.Rows[0].ItemArray[17].ToString();
                //retorno.NroMatricula = dt.Rows[0].ItemArray[18].ToString();
                //retorno.Especialidad = dt.Rows[0].ItemArray[19].ToString();
                //retorno.VisitasCapital = Convert.ToBoolean(dt.Rows[0].ItemArray[20].ToString());
                //retorno.VisitasProvincia = Convert.ToBoolean(dt.Rows[0].ItemArray[21].ToString());
                //retorno.Firma = dt.Rows[0].ItemArray[22].ToString();

                retorno.NroDocumento = dt.Rows[0].ItemArray[10].ToString();
                retorno.Activo = Convert.ToBoolean(dt.Rows[0].ItemArray[22].ToString());
                retorno.CodigoPostal = dt.Rows[0].ItemArray[13].ToString();
                retorno.LugarMatricula = dt.Rows[0].ItemArray[5].ToString();
                retorno.NroMatricula = dt.Rows[0].ItemArray[6].ToString();
                retorno.Especialidad = dt.Rows[0].ItemArray[7].ToString();
                retorno.VisitasCapital = Convert.ToBoolean(dt.Rows[0].ItemArray[19].ToString());
                retorno.VisitasProvincia = Convert.ToBoolean(dt.Rows[0].ItemArray[20].ToString());
                retorno.Firma = dt.Rows[0].ItemArray[21].ToString();
            }

            if (strIdProfesional != string.Empty) { retorno.Id = new Guid(strIdProfesional); }
            retorno.Nombre = tbNombre.Text;
            retorno.Apellido = tbApellido.Text;            
            retorno.Direccion = tbDireccion.Text;
            retorno.Localidad = tbLocalidad.Text;
            retorno.Telefono = tbTelefonoParticular.Text;
            retorno.Celular = tbTelefonoCelular.Text;
            retorno.Mail = tbMail.Text;
            retorno.DNI = tbDNI.Text;
            retorno.Cuil = tbCuil.Text;
            retorno.Activo = true;
                        
            return retorno;
        }

        private Entidades.UsuarioSistema cargarDatosUsuarios()
        {            
            DataTable dt = null;
            string strIdUsuario = "";
            string strIdServer = "";
            string strProfesionalAsignando = "";
            string strSucursalID = "";
            CapaNegocioMepryl.UsuarioSistema usuario = new CapaNegocioMepryl.UsuarioSistema();
            Entidades.UsuarioSistema retorno = new Entidades.UsuarioSistema();

            dt = usuario.ListarUsuarios(tbDNI.Text);

            strIdUsuario = tbIdPaciente.Text;

            if (chkProfesional.Checked)
            {
                retorno.Tipo = "MEDICOS";
            }else
            {
                retorno.Tipo = "OPERADOR";
            }

            if(!string.IsNullOrEmpty(strIdProfesional))
            {
                retorno.ProfesionalAsignado = new Guid(strIdProfesional);
            }
            

            if (dt.Rows.Count > 0)
            {
                strIdUsuario = dt.Rows[0].ItemArray[0].ToString();
                retorno.Tipo = dt.Rows[0].ItemArray[22].ToString();
                retorno.Username = dt.Rows[0].ItemArray[14].ToString();
                retorno.Password = Utilidades.desencriptar(dt.Rows[0].ItemArray[15].ToString());
                strSucursalID = dt.Rows[0].ItemArray[16].ToString();
                if (strSucursalID != string.Empty) { retorno.SucursalId = new Guid(strSucursalID); }
                retorno.Actualiza_Local = Convert.ToDateTime(dt.Rows[0].ItemArray[19].ToString());
                retorno.Operacion_Local = dt.Rows[0].ItemArray[20].ToString();
                strIdServer = dt.Rows[0].ItemArray[21].ToString();
                if (strIdServer != string.Empty) { retorno.ServerId = new Guid(strIdServer); } 
                retorno.VentConfiguracion = Convert.ToBoolean(dt.Rows[0].ItemArray[23].ToString());
                retorno.VentExamenes = Convert.ToBoolean(dt.Rows[0].ItemArray[24].ToString());
                retorno.VentMesa = Convert.ToBoolean(dt.Rows[0].ItemArray[25].ToString());
                retorno.VentPacientes = Convert.ToBoolean(dt.Rows[0].ItemArray[26].ToString());
                retorno.VentVentanilla = Convert.ToBoolean(dt.Rows[0].ItemArray[27].ToString());
                retorno.VentResumen = Convert.ToBoolean( dt.Rows[0].ItemArray[28].ToString());
                retorno.VentTurnos = Convert.ToBoolean(dt.Rows[0].ItemArray[29].ToString());
                retorno.VentAudiometria = Convert.ToBoolean(dt.Rows[0].ItemArray[30].ToString());
                retorno.PermisoVer = Convert.ToBoolean(dt.Rows[0].ItemArray[31].ToString());
                retorno.PermisoModificar = Convert.ToBoolean(dt.Rows[0].ItemArray[32].ToString());
                retorno.PermisoEliminar = Convert.ToBoolean(dt.Rows[0].ItemArray[33].ToString());
                retorno.Activo = Convert.ToBoolean(dt.Rows[0].ItemArray[34].ToString());
                strProfesionalAsignando = dt.Rows[0].ItemArray[35].ToString();
                if (strProfesionalAsignando != string.Empty) { retorno.ProfesionalAsignado = new Guid(strProfesionalAsignando); }                
            }
            
            if (strIdUsuario != string.Empty) { retorno.Id = new Guid(strIdUsuario); }
            retorno.Nombre = tbNombre.Text;
            retorno.Apellido = tbApellido.Text;
            retorno.DNI = tbDNI.Text;
            retorno.Email = tbMail.Text;            
            if (retorno.Username == string.Empty) { retorno.Username = tbNombre.Text.Replace(" ", "").ToLower(); }
            
            return retorno;
        }

        private void GuardaActualizaPaciente()
        {
            if (chkProfesional.Visible)
            {
                strIdProfesional = "";

                if (chkProfesional.Checked)
                {
                    CapaNegocioMepryl.Profesionales profesionales = new CapaNegocioMepryl.Profesionales(); //
                    Entidades.Profesional profesional = cargarDatosProfesional(); //
                    
                    if (pacienteLaboral.ListaProfesional(tbDNI.Text).Rows.Count > 0)
                    {                        
                        Entidades.Resultado resulPro = profesionales.editarProfesional(profesional); //
                    }
                    else
                    {
                        Entidades.Resultado resulPro = profesionales.nuevoProfesional(profesional); //
                    }
                }

                strIdProfesional = pacienteLaboral.idProfesional(tbDNI.Text);
                CapaNegocioMepryl.UsuarioSistema usuarios = new CapaNegocioMepryl.UsuarioSistema();
                Entidades.UsuarioSistema usuario = cargarDatosUsuarios();
                                
                if (usuarios.ListarUsuarios(tbDNI.Text).Rows.Count > 0)
                {
                    usuarios.ActualizarUsuario(usuario);
                }
                else
                {
                    usuarios.GuardarUsuario(usuario);
                }                
            }
        }

        private void chkProfesional_Click(object sender, EventArgs e)
        {
            btnHorario.Enabled = chkProfesional.Checked;
            if (chkProfesional.Checked)
            {
                //btnHorario.PerformClick();
                llamaVentanaPreofesional();
                editarProfesional();
            }
            else
            {

            }
        }

        private void editarProfesional()
        {
            string strIdProfesional = pacienteLaboral.idProfesional(tbDNI.Text);

            if (!string.IsNullOrEmpty(strIdProfesional))
            {
                frmProfesionalesCopy frm = new frmProfesionalesCopy(this);
                frm.modoEdicion2(strIdProfesional);
                //frm.retornoValores(this);
                frm.Show();
            }else
            {
                //MessageBox.Show("Ha ocurrido un problema al ingresar un nuevo profesional.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
                chkProfesional.Checked = false;
            }
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDNI.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el DNI del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(tbApellido.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el apellido del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (tbNacimiento.Text == "  /  /")
            {
                MessageBox.Show("Para continuar debe ingresar la fecha de nacimiento del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el nombre del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
                        

            if (chkProfesional.Checked)
            {
                CapaNegocioMepryl.Profesionales profesionales = new CapaNegocioMepryl.Profesionales(); //
                Entidades.Profesional profesional = cargarDatosProfesional(); //

                if (pacienteLaboral.ListaProfesional(tbDNI.Text).Rows.Count > 0)
                {
                    Entidades.Resultado resulPro = profesionales.editarProfesional(profesional); //
                }
                else
                {
                    Entidades.Resultado resulPro = profesionales.nuevoProfesional(profesional); //
                }
            }
            strIdProfesional = "";
            //strIdProfesional = pacienteLaboral.idProfesional(tbDNI.Text);

            //if (chkProfesional.Checked && !string.IsNullOrEmpty(strIdProfesional) )
            //{
            //    frmHorario frm = new frmHorario(config, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA);
            //    if (strIdProfesional != string.Empty)
            //    {
            //        //frm.strIdProfesional = tbApellido.Text + " " + tbNombre.Text;
            //        frm.strIdProfesional = strIdProfesional;
            //    }
            //    frm.ShowDialog();
            //}
        }

        private void llamaVentanaPreofesional()
        {
            if (string.IsNullOrEmpty(tbDNI.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el DNI del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(tbApellido.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el apellido del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (tbNacimiento.Text == "  /  /")
            {
                MessageBox.Show("Para continuar debe ingresar la fecha de nacimiento del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                MessageBox.Show("Para continuar debe ingresar el nombre del paciente.", "Paciente Laboral", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            if (chkProfesional.Checked)
            {
                CapaNegocioMepryl.Profesionales profesionales = new CapaNegocioMepryl.Profesionales(); //
                Entidades.Profesional profesional = cargarDatosProfesional(); //

                if (pacienteLaboral.ListaProfesional(tbDNI.Text).Rows.Count > 0)
                {
                    Entidades.Resultado resulPro = profesionales.editarProfesional(profesional); //
                }
                else
                {
                    Entidades.Resultado resulPro = profesionales.nuevoProfesional(profesional); //
                }
            }
            strIdProfesional = "";
        }

        public void ActualizaDireccionPacientelaboral(Entidades.Profesional Profesional)
        {
            tbDireccion.Text = Profesional.Direccion;
            tbTelefonoParticular.Text = Profesional.Telefono;
            tbTelefonoCelular.Text = Profesional.Celular;
            tbMail.Text = Profesional.Mail;
        }

        private void tbEmpresa_Enter(object sender, EventArgs e)
        {

        }

        private void tbEmpresa_Leave(object sender, EventArgs e)
        {
            if (tbEmpresa.Text == "")
            {
                tbEmpresa.Text = "Presione F1 para buscar";
                tbEmpresa.ForeColor = Color.Gray;
            }
        }

        private void tbPaciente_Enter(object sender, EventArgs e)
        {

        }

        private void tbPaciente_Leave(object sender, EventArgs e)
        {
            if (tbPaciente.Text == "")
            {
                tbPaciente.Text = "Presione F1 para buscar";
                tbPaciente.ForeColor = Color.Gray;
            }
        }

        private void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            Entidades.PacienteLaboral paciente = pacienteLaboral.leerDatosEntidad(tbIdPaciente.Text, tbIdEmpresa.Text);
            SQLConnector.EjecutarConsulta(@"delete from dbo.PacienteLaboral where id = '" + paciente.Id.ToString() + "'");
            limpiarFicha();
            modoInicio();
        }
    }
}
