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

namespace CapaPresentacion
{
    public partial class frmPacienteLaboral : Form
    {
        private string busqueda = string.Empty;
        private CapaNegocioMepryl.PacienteLaboral pacienteLaboral;
        private CapaNegocioMepryl.UbicacionFotos DirectorioFotos;
        private string strDniAnterior = ""; // GRV - Ramírez - Poder mdificar el DNI

        public delegate void DelegateDevolverID(string idPaciente, string idEmpresa);
        public DelegateDevolverID objDelegateDevolverID = null;

        public frmPacienteLaboral()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            pacienteLaboral = new PacienteLaboral();
            DirectorioFotos = new UbicacionFotos();
            llenarCboNacionalidad();
            modoInicio();
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
            cboSexo.Focus();
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
            botBuscarDNI.Visible = false;
        }

        private void modoBusqueda()
        {
            panelDatos.Enabled = false;
            panelBusqueda.Visible = true;
            tbBusqueda.Clear();
            tbBusqueda.Focus();
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
                }
                else
                {
                    tbEmpresa.Focus();
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
                }
                else
                {
                    tbEmpresa.Focus();
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
                llenarFormulario(paciente);
                cboSexo.Focus();
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
            llenarDgvHistoriaClinica(paciente.HistoriaClinica);

        }

        private void llenarDgvHistoriaClinica(DataTable historia)
        {
            foreach (DataRow dr in historia.Rows)
            {
                dgvHistoriaClinica.Rows.Add(dr.ItemArray[0], dr.ItemArray[1],
                    dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4], dr.ItemArray[5], dr.ItemArray[6],
                    dr.ItemArray[7], dr.ItemArray[8], dr.ItemArray[9], null);
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
            switch (resultado.Modo)
            {
                case 1:
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
            }
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
            tbDNI.Text, pacienteLaboral.cargarIdExamenLaboral(dgvHistoriaClinica.Rows[dgvHistoriaClinica.SelectedCells[0].RowIndex].Cells[1].Value.ToString()));
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


    }
}
