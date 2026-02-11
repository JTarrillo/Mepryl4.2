using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProfesionales : Form
    {
        private frmBusquedaProfesionales formBusqueda;
        private CapaNegocioMepryl.Profesionales profesionales;

        public frmProfesionales(frmBusquedaProfesionales frm)
        {
            InitializeComponent();
            formBusqueda = frm;
            profesionales = new CapaNegocioMepryl.Profesionales();
        }

        public void modoConsulta(object id)
        {
            botGuardar.Visible = false;
            botCancelar.Visible = false;
            botVolver.Visible = true;
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
            botModificar.Visible = false;
            setearId(id);
            mostrarDatos();
            lbTitulo.Text = "Edición del Médico";
        }

        public void modoNuevo()
        {
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            botVolver.Visible = false;
            botModificar.Visible = false;
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
        }

        private void botVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botGuardar_Click(object sender, EventArgs e)
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
                this.Close();
                formBusqueda.actualizarListado();
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
                this.Close();
                formBusqueda.actualizarListado();
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
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }

        private void modificar()
        {
            botVolver.Visible = false;
            botModificar.Visible = false;
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            lbTitulo.Text = "Edición del Médico";
            cambiarHabilitacionControles(true);
        }

   


    }
}
