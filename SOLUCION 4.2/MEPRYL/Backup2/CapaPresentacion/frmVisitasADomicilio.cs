using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocioMepryl;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class frmVisitasADomicilio : Form
    {
        private CapaNegocioMepryl.VisitasDomicilio visitas;

        public frmVisitasADomicilio()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            visitas = new VisitasDomicilio();
            limpiarFormulario();
            cargarDataGrids();
            cargarCombos();
            modoConsulta();
            cargarListado();
        }

        private void cargarCombos()
        {
            cargarCombo(cboMotivo,visitas.cargarMotivoConsulta());
            cargarCombo(cboMedicoAEnviar, visitas.cargarMedico());
            cargarCombo(cboEstadoAtencion, visitas.cargarEstadoAtencion());
        }

        private void cargarCombo(ComboBox cbo, DataTable source)
        {
            cbo.DataSource = source;
            cbo.ValueMember = "id";
            cbo.DisplayMember = "descripcion";
        }

        private void cargarDataGrids()
        {
            cargarDgvEmpresa("");
            cargarDgvLocalidad("");
        }

        private void cargarDgvLocalidad(string filtro)
        {
            dgvLocalidad.DataSource = visitas.cargarLocalidad(filtro);
            dgvLocalidad.Columns[0].Visible = false;
        }

        private void cargarDgvEmpresa(string filtro)
        {
            dgvEmpresas.DataSource = visitas.cargarEmpresas(filtro);
            dgvEmpresas.Columns[0].Visible = false;
        }

        private void buscarEmpresaConFiltro()
        {
            cargarDgvEmpresa(tbBusquedaEmpresa.Text);
        }

        private void buscarLocalidadConFiltro()
        {
            cargarDgvLocalidad(tbBusquedaLocalidad.Text);
        }

        private void limpiarFormulario()
        {
            tbBusquedaEmpresa.Clear();
            tbBusquedaPaciente.Clear();
            tbEmpresa.Clear();
            tbPaciente.Clear();
            lbIdentificador.Text = string.Empty;
            tpFecha.CustomFormat = " ";
            cboMotivo.SelectedIndex = -1;
            cboEstadoAtencion.SelectedIndex = -1;
            tbDomicilio.Clear();
            tbEntre1.Clear();
            tbEntre2.Clear();
            tbBusquedaLocalidad.Clear();
            tbObservaciones.Clear();
            cboMedicoAEnviar.SelectedIndex = -1;
            tbIdPaciente.Clear();
            tbIdVisita.Clear();
            tbDomicilioTransitorio.Clear();
            tbDni.Clear();
        }

        private void modoEdicion()
        {
            cambiarHabilitacionControles(true);
            dgvEmpresas.DataSource = null;
            tbBusquedaPaciente.Clear();
            cargarDgvLocalidad("");
            tpFecha.Value = DateTime.Today;
            tpFecha.CustomFormat = "dd-MM-yyyy";
            tbBusquedaEmpresa.Clear();
            cboMedicoAEnviar.SelectedIndex = -1;
            cboEstadoAtencion.SelectedIndex = 0;
            cboMotivo.SelectedIndex = 0;
        }

        private void modoConsulta()
        {
            cambiarHabilitacionControles(false);
            dgvLocalidad.DataSource = null;
            tpFecha.CustomFormat = " ";
            tbBusquedaLocalidad.Clear();
            cboMedicoAEnviar.SelectedIndex = -1;
            cboEstadoAtencion.SelectedIndex = -1;
            cboMotivo.SelectedIndex = -1;
            cargarDgvEmpresa(tbBusquedaEmpresa.Text);
        }

        private void cambiarHabilitacionControles(bool estado)
        {
            tpFecha.Enabled = estado;
            cboMotivo.Enabled = estado;
            cboEstadoAtencion.Enabled = estado;
            tbDomicilio.Enabled = estado;
            tbEntre1.Enabled = estado;
            tbEntre2.Enabled = estado;
            tbObservaciones.Enabled = estado;
            tbBusquedaLocalidad.Enabled = estado;
            dgvLocalidad.Enabled = estado;
            cboMedicoAEnviar.Enabled = estado;
            dgvPendientes.Enabled = !estado;
            tbBusquedaEmpresa.Enabled = !estado;
            dgvEmpresas.Enabled = !estado;
            tbBusquedaPaciente.Enabled = !estado;
            botEditarPaciente.Visible = estado;
            botAceptar.Visible = estado;
            botCancelar.Visible = estado;
            botEditar.Visible = !estado;
            botEliminar.Visible = !estado;
            botEnviarMedico.Visible = !estado;
        }

        private void tbBusquedaEmpresa_TextChanged(object sender, EventArgs e)
        {
            buscarEmpresaConFiltro();
        }

        private void tbBusquedaLocalidad_TextChanged(object sender, EventArgs e)
        {
            buscarLocalidadConFiltro();
        }

        private void botonBuscarDni_Click(object sender, EventArgs e)
        {
            buscarPaciente();
        }

        private void buscarPaciente()
        {
            Regex r = new Regex("^[A-Za-z ]+$");
            if (!r.IsMatch(tbBusquedaPaciente.Text))
            {
                buscarPacientePorDni();
            }
            else
            {
                //buscarPacientePorNombre();
            }
        }

        private void buscarPacientePorDni()
        {
            Entidades.Resultado resultado = visitas.buscarDni(tbBusquedaPaciente.Text, dgvEmpresas.CurrentRow.Cells[0].Value.ToString());
            int caseSwitch = resultado.Modo;
            switch (caseSwitch)
            {
                case 1:
                    inicializarVisita(resultado.IdRetorno);
                    break;
                case 2:
                    DialogResult result2 = MessageBox.Show("Se encontró al paciente en la empresa " + resultado.Mensaje + "\n¿Desea darlo de alta en la empresa seleccionada?",
                        "Ingreso de Visita de Reconocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result2 == DialogResult.Yes)
                    {
                        cambiarEmpresaDePaciente(resultado.IdRetorno, new Guid(dgvEmpresas.CurrentRow.Cells[0].Value.ToString()));
                    }
                    inicializarVisita(resultado.IdRetorno);
                    break;
                case 3:
                    DialogResult result3 = MessageBox.Show("No se encontró al paciente ingresado, ¿Desea darlo de alta?",
                       "Ingreso de Visita de Reconocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result3 == DialogResult.Yes)
                    {
                        altaDePaciente();
                    }
                    break;
                case 4:
                    DialogResult result4 = MessageBox.Show("Se encontró al paciente sin empresa asignada\n¿Desea darlo de alta en la empresa seleccionada?",
                        "Ingreso de Visita de Reconocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result4 == DialogResult.Yes)
                    {
                        cambiarEmpresaDePaciente(resultado.IdRetorno, new Guid(dgvEmpresas.CurrentRow.Cells[0].Value.ToString()));
                        inicializarVisita(resultado.IdRetorno);
                    }
                    break;              
            }
        }

        private void inicializarVisita(Guid idPaciente)
        {
            Entidades.VisitasDomicilio entidad = visitas.inicializarVisita(idPaciente);
            tbIdPaciente.Text = entidad.IdPaciente.ToString();
            tbIdVisita.Text = Guid.Empty.ToString();
            tbPaciente.Text = entidad.DniPaciente + " - " + entidad.Paciente;
            tbEmpresa.Text = entidad.Empresa;
            tbIdEmpresa.Text = entidad.IdEmpresa.ToString();
            tbTarea.Text = entidad.Tarea;
            modoEdicion();
            lbIdentificador.Text = "";
            tbDomicilioTransitorio.Text = "";
            tbBusquedaLocalidad.Text = entidad.LocalidadDescripcion;
            tbDomicilio.Text = entidad.Domicilio;
            tbBusquedaPaciente.Text = entidad.DniPaciente;
            tbBusquedaEmpresa.Text = entidad.Empresa;
            tbDni.Text = entidad.DniPaciente;
        }

        private void cambiarEmpresaDePaciente(Guid idPaciente, Guid idEmpresa)
        {
            visitas.cambiarEmpresaDePaciente(idPaciente, idEmpresa);
        }

        private void altaDePaciente()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.mostrarBotonOk = true;
            fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(asignarPaciente);
            fPaciente.ShowDialog();
        }

        private void asignarPaciente(string idPaciente)
        {
            inicializarVisita(new Guid(idPaciente));
        }

        private bool verificarIngresos()
        {
            if (cboMotivo.SelectedIndex != -1 && cboEstadoAtencion.SelectedIndex != -1 && cboMedicoAEnviar.SelectedIndex != -1
                && tbDomicilio.Text != string.Empty && dgvLocalidad.Rows.Count > 0 && dgvLocalidad.SelectedCells.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            if (verificarIngresos())
            {
                Entidades.VisitasDomicilio entidad = new Entidades.VisitasDomicilio();
                entidad.IdPaciente = new Guid(tbIdPaciente.Text);
                entidad.Domicilio = tbDomicilio.Text;
                entidad.EntreCalle1 = tbEntre1.Text;
                entidad.EntreCalle2 = tbEntre2.Text;
                entidad.Localidad = new Guid(dgvLocalidad.Rows[dgvLocalidad.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                Entidades.Resultado resultado = visitas.verificarDomicilio(entidad);
                tbDomicilioTransitorio.Text = "0";
                if (resultado.Modo == 2)
                {
                    DialogResult result = MessageBox.Show("¡El domicilio ingresado es diferente al que el paciente tiene asignado!\n¿El domicilio es transitorio?",
                    "Guardar Vistida de Reconocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        visitas.actualizarDomicilioPaciente(entidad);
                    }
                    else
                    {
                        tbDomicilioTransitorio.Text = "1";
                    }
                }
                guardarVisita();
                cargarListado();
                modoConsulta();
                cambiarSeleccionDgv();
            }
            else
            {
                MessageBox.Show("¡Faltan ingresar campos requeridos!", "Recepcion de Visitas de Reconocmiento",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guardarVisita()
        {
            Entidades.Resultado result = visitas.guardarVisita(cargarDatosEntidad());

        }

        private Entidades.VisitasDomicilio cargarDatosEntidad()
        {
            Entidades.VisitasDomicilio retorno = new Entidades.VisitasDomicilio();
            retorno.Id = new Guid(tbIdVisita.Text);
            retorno.IdEstadoAtencion = new Guid(cboEstadoAtencion.SelectedValue.ToString());
            retorno.IdMotivoConsulta = new Guid(cboMotivo.SelectedValue.ToString());
            retorno.FechaHora = new DateTime(tpFecha.Value.Year, tpFecha.Value.Month, tpFecha.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            retorno.IdPaciente = new Guid(tbIdPaciente.Text);
            retorno.Domicilio = tbDomicilio.Text;
            retorno.EntreCalle1 = tbEntre1.Text;
            retorno.EntreCalle2 = tbEntre2.Text;
            retorno.Localidad = new Guid(dgvLocalidad.Rows[dgvLocalidad.CurrentCell.RowIndex].Cells[0].Value.ToString());
            retorno.Medico = new Guid(cboMedicoAEnviar.SelectedValue.ToString());
            retorno.DomicilioTransitorio = Convert.ToInt16(tbDomicilioTransitorio.Text);
            retorno.IdEmpresa = new Guid(tbIdEmpresa.Text);
            retorno.Tarea = tbTarea.Text;
            retorno.Observaciones = tbObservaciones.Text;
            return retorno;
        }

        private void cargarListado()
        {
            dgvPendientes.DataSource = visitas.cargarVisitasPendientes();
            dgvPendientes.Columns[0].Visible = false;
            dgvPendientes.Columns[7].Visible = false;
            dgvPendientes.Columns[8].Visible = false;
            dgvPendientes.Columns[9].DefaultCellStyle.NullValue = null;
            dgvPendientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ((DataGridViewImageColumn)dgvPendientes.Columns[9]).ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void cambiarSeleccionDgv()
        {
            if (dgvPendientes.SelectedRows.Count > 0)
            {
                cargarDatosGuardados(new Guid(dgvPendientes.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void cargarDatosGuardados(Guid idVisita)
        {
            limpiarFormulario();
            Entidades.VisitasDomicilio entidad = visitas.cargarVisita(idVisita);
            llenarFormulario(entidad);
        }

        private void llenarFormulario(Entidades.VisitasDomicilio entidad)
        {
                if (entidad.Id != Guid.Empty) { tbIdVisita.Text = entidad.Id.ToString(); }
                if (entidad.FechaHora != new DateTime(1800, 1, 1)) { tpFecha.Value = entidad.FechaHora; }
                if (entidad.IdMotivoConsulta != Guid.Empty) { cboMotivo.SelectedValue = entidad.IdMotivoConsulta; }
                if (entidad.IdEstadoAtencion != Guid.Empty) { cboEstadoAtencion.SelectedValue = entidad.IdEstadoAtencion; }
                tbDomicilio.Text = entidad.Domicilio;
                tbEntre1.Text = entidad.EntreCalle1;
                tbEntre2.Text = entidad.EntreCalle2;
                tbBusquedaLocalidad.Text = entidad.LocalidadDescripcion;
                if (entidad.Medico != Guid.Empty) { cboMedicoAEnviar.SelectedValue = entidad.Medico; }
                tbObservaciones.Text = entidad.Observaciones;
                if (entidad.IdPaciente != Guid.Empty) { tbIdPaciente.Text = entidad.IdPaciente.ToString(); }
                tbPaciente.Text = entidad.DniPaciente + " - " + entidad.Paciente;
                tbEmpresa.Text = entidad.Empresa;
                if (entidad.IdEmpresa != Guid.Empty) { tbIdEmpresa.Text = entidad.IdEmpresa.ToString(); }
                tbDomicilioTransitorio.Text = entidad.DomicilioTransitorio.ToString();
                lbIdentificador.Text = entidad.Identificador;
                tpFecha.CustomFormat = "dd-MM-yyyy";
                tbDni.Text = entidad.DniPaciente;
        }

        private void dgvPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cambiarSeleccionDgv();
        }

        private void botEditar_Click(object sender, EventArgs e)
        {
            modoEdicion();
            cambiarSeleccionDgv();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            modoConsulta();
            cambiarSeleccionDgv();
        }

        private void tbBusquedaPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                botonBuscarDni.PerformClick();
            }
        }

        private void botEnviarMedico_Click(object sender, EventArgs e)
        {
            enviarMail();
        }

        private void enviarMail()
        {
            if (dgvPendientes.SelectedRows.Count > 0)
            {
                List<string> archivos = new List<string>();
                Reportes report = new Reportes(new rptVisitaDomicilio());
                foreach (DataGridViewRow dgvr in dgvPendientes.SelectedRows)
                {
                    string ruta = report.exportarAPDF(visitas.cargarParametrosReporteVisita(dgvr.Cells[0].Value.ToString()),
                         new dsMedicinaLaboral(), visitas.cargarDataSourceVisita(),
                          @"P:\DOMICILIOS\" + dgvr.Cells[1].Value.ToString().Replace('/','.') + "-" + dgvr.Cells[5].Value.ToString() + 
                          "-" + dgvr.Cells[6].Value.ToString() + ".pdf");
                    archivos.Add(ruta);
                    visitas.actualizarEnvio(dgvr.Cells[0].Value.ToString());
                }
                cargarListado();
                cambiarSeleccionDgv();
                frmMail frm = new frmMail();
                frm.archivosAdjuntos(archivos);
                frm.ShowDialog();
            }
        }

        private void botEditarPaciente_Click(object sender, EventArgs e)
        {
            editarPaciente();
        }

        private void editarPaciente()
        {
            frmPaciente frm = new frmPaciente(new Configuracion(),true);
            frm.Show();
            frm.mostarDatosDni(tbDni.Text);
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            eliminarVisita();
        }

        private void eliminarVisita()
        {
            DialogResult result = MessageBox.Show("¡La visita de reconocimiento a domicilio seleccionada va a ser eliminada!\n¿Está seguro que desea continuar?",
                "Eliminar Visita de Reconocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                visitas.eliminarVisita(dgvPendientes.SelectedRows[0].Cells[0].Value.ToString());
                cargarListado();
                cambiarSeleccionDgv();
            }
           
        }
 



        


     
  

   


 


    }
}
