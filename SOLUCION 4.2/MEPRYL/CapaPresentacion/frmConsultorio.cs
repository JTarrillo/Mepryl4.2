using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaPresentacionBase;
using CapaNegocioMepryl;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmConsultorio : Form
    {
        private CapaNegocioMepryl.Consultorio consultorio;
        private frmBusquedaLaboral frmBusquedaLaboral;
        private string fecha;
        private bool fechaGuardada;
        public delegate void DelegateRefreshHistoriaClinica();
        public DelegateRefreshHistoriaClinica objDelegateRefreshHistoria = null;
        private string idEmpresa;
        private string EmpresaID;
        private string PacienteID;
        private DateTime dtFechaAnterior;
        private bool blnResultado = true;
        private Configuracion configuracion;

        public frmConsultorio(frmBusquedaLaboral frm)
        {
            InitializeComponent();
            inicializar();
            frmBusquedaLaboral = frm;            
        }


        public frmConsultorio()
        {
            InitializeComponent();
            inicializar();            
        }


        private void inicializar()
        {
            configuracion = new Configuracion();
            consultorio = new CapaNegocioMepryl.Consultorio();
            llenarCboPatologia();
            llenarCboProfesional();
            llenarCboEstadoAtencion();
            llenarCboMotivoConsulta();
            llenarCboCondicionLaboral();
            tpFechaAltaCitacion.CustomFormat = " ";
        }

        public void setearLabelTitulo(string texto)
        {
            lbTitulo.Text = texto;
        }
        
        public void setearValores(string idConsultaLaboral)
        {
            Entidades.Consultorio entidadConsultorio = consultorio.cargarConsultorio(idConsultaLaboral);
            llenarDatos(entidadConsultorio);
        }

        public void setearValores(string idConsultaLaboral, string idEmp)
        {
            idEmpresa = idEmp;
            Entidades.Consultorio entidadConsultorio = consultorio.cargarConsultorio(idConsultaLaboral);
            llenarDatos(entidadConsultorio);
        }


        private void llenarDatos(Entidades.Consultorio entidadConsultorio)
        {
            tbIdConsultorioLaboral.Text = entidadConsultorio.IdConsultorio.ToString();
            tbFecha.Text = entidadConsultorio.FechaHora.ToShortDateString();
            tpHora.Value = entidadConsultorio.FechaHora;
            tbLugar.Text = entidadConsultorio.LugarAtencion;
            if (entidadConsultorio.IdEstadoAtencion != Guid.Empty)
            {
                cboEstadoAtencion.SelectedValue = entidadConsultorio.IdEstadoAtencion;
            }
            if (entidadConsultorio.IdPatologia != Guid.Empty)
            {
                cboPatologia.SelectedValue = entidadConsultorio.IdPatologia;
            }         
            tbDiagnostico.Text = entidadConsultorio.Diagnostico;
            if (entidadConsultorio.IdCondicionLaboral != Guid.Empty)
            {
                cboCondicionLaboral.SelectedValue = entidadConsultorio.IdCondicionLaboral;
            }
            fechaGuardada = false;
            fecha = string.Empty;
            if (entidadConsultorio.FechaAltaCitacion != "")
            {
                tpFechaAltaCitacion.CustomFormat = "dd-MM-yyyy";
                tpFechaAltaCitacion.Value = Convert.ToDateTime(entidadConsultorio.FechaAltaCitacion);
                fechaGuardada = true;
                fecha = entidadConsultorio.FechaAltaCitacion;
            }
            if (entidadConsultorio.IdMedico != Guid.Empty)
            {
                cboMedico.SelectedValue = entidadConsultorio.IdMedico;
            }  
            tbFactura.Text = entidadConsultorio.FacturaPrestacion.ToString();
            tbIdPaciente.Text = entidadConsultorio.IdPaciente.ToString();
            tbPaciente.Text = entidadConsultorio.Paciente;
            tbEmpresa.Text = entidadConsultorio.Empresa;
            tbTarea.Text = entidadConsultorio.Tarea;
            lbIdentificador.Text = entidadConsultorio.Identificador;
            tbDni.Text = entidadConsultorio.Dni;
            PacienteID = entidadConsultorio.IdPaciente.ToString();
            EmpresaID = entidadConsultorio.IdEmpresa.ToString();
            verificarFecha();
            //GRV - Ramírez
            dtFechaAnterior = tpFechaAltaCitacion.Value;
            if (VerificaTurno())
            {
                lblTurnoAsignado.Text = "Este paciente tiene un turno asignado para la fecha señalada";
            } 
        }

        private void llenarCboProfesional()
        {
            llenarCombo(cboMedico,consultorio.cargarMedicos(), "Profesional" , "id", -1);
        }

        private void llenarCboEstadoAtencion()
        {
            llenarCombo(cboEstadoAtencion, consultorio.cargarEstadoAtencion(), "descripcion", "id", -1);
        }

        private void llenarCboPatologia()
        {
            llenarCombo(cboPatologia, consultorio.cargarPatologia(), "descripcion", "id", -1);
        }

        private void llenarCboMotivoConsulta()
        {
            llenarCombo(cboMotivo,consultorio.cargarMotivoConsulta(), "descripcion", "id", 0);
        }

        private void llenarCboCondicionLaboral()
        {
            llenarCombo(cboCondicionLaboral, consultorio.cargarCondicionLaboral(), "descripcion", "id", -1);
            cboCondicionLaboral.SelectedIndex = 0;
        }

        private void llenarCombo(ComboBox cbo, DataTable tabla, string display, string value, int index)
        {
            cbo.DataSource = tabla;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = index;
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {            
            guardar();
        }

        private bool guardar()
        {
            DateTime dtFechaActual = DateTime.Today;
            DateTime dtFechaAltaCi = Convert.ToDateTime(tpFechaAltaCitacion.Value.ToString());

            Entidades.Resultado resultadoValidacionIngresos = validarIngreso();
            if (resultadoValidacionIngresos.Modo == 1)
            {
                Entidades.Resultado resultadoValidacionEstadoAtencion = verificarEstadoAtencion();
                if (resultadoValidacionEstadoAtencion.Modo == 1)
                {
                    Entidades.Consultorio entidad = new Entidades.Consultorio();
                    entidad.IdConsultorio = new Guid(tbIdConsultorioLaboral.Text);
                    entidad.FechaHora = tpHora.Value;
                    entidad.IdMotivo = new Guid(cboMotivo.SelectedValue.ToString());
                    entidad.IdEstadoAtencion = new Guid(cboEstadoAtencion.SelectedValue.ToString());
                    entidad.IdPatologia = new Guid(cboPatologia.SelectedValue.ToString());
                    entidad.Diagnostico = tbDiagnostico.Text;
                    entidad.IdCondicionLaboral = new Guid(cboCondicionLaboral.SelectedValue.ToString());
                    // GRV - Ramírez modificacón para guardar turno
                    ReservarTurno();
                    //
                    if (tpFechaAltaCitacion.Enabled)
                    {
                        if (blnResultado)
                        {
                            entidad.FechaAltaCitacion = tpFechaAltaCitacion.Value.ToString();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    entidad.IdMedico = new Guid(cboMedico.SelectedValue.ToString());
                    entidad.FacturaPrestacion = -1;
                    consultorio.guardarConsulta(entidad);
                    if (objDelegateRefreshHistoria != null)
                    {
                        objDelegateRefreshHistoria();
                    }
                    else
                    {
                        frmBusquedaLaboral.actualizar();
                    }
                    // GRV - Ramírez modificacón para guardar turno
                    //this.Close();
                    if (blnResultado)
                    {
                        this.Close();
                    }
                    //                    
                    return true;
                }
                return false;
            }
            else
            {
                MessageBox.Show(resultadoValidacionIngresos.Mensaje, "¡No se puede guardar la consulta!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private Entidades.Resultado validarIngreso()
        {
  
            if (cboMotivo.SelectedIndex == -1)
            {
                return retornarError("¡El motivo de consulta seleccionado no es válido!");             
            }
            if (cboEstadoAtencion.SelectedIndex == -1)
            {
                return retornarError("¡El estado de atención seleccionado no es válido!");
            }
            if (cboPatologia.SelectedIndex == -1)
            {
                return retornarError("¡La patología seleccionada no es válida!");
            }
            if (tbDiagnostico.Text.Length <= 0)
            {
                return retornarError("¡Se debe escribir el diagnóstico de la consulta!");
            }
            if (cboCondicionLaboral.SelectedIndex <= 0)
            {
                return retornarError("¡Se debe seleccionar la condición laboral de la consulta!");
            }
            if (cboMedico.SelectedIndex == -1)
            {
                return retornarError("¡Se debe seleccionar el médico que realizó consulta!");
            }
            Entidades.Resultado resultado = new Entidades.Resultado();
            resultado.Modo = 1;
            return resultado;
        }

        private Entidades.Resultado retornarError(string mensaje)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            retorno.Modo = -1;
            retorno.Mensaje = mensaje;
            return retorno;
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botImprimir_Click(object sender, EventArgs e)
        {
            if (guardar())
            {
                imprimir();
            }
        }

        private void imprimir()
        {
            Reportes report = new Reportes(new rptConsultorioDomicilios());
            report.imprimir(consultorio.cargarParametrosConsultorio(tbIdConsultorioLaboral.Text),
                new dsMedicinaLaboral(), consultorio.cargarDataSourceConsultorio());
        }

        private void botAnterior_Click(object sender, EventArgs e)
        {
            validarConsulta(consultorio.cargarConsultorioAnterior(tbFecha.Text, tbIdPaciente.Text, idEmpresa), "anteriores");         
        }

        private void botSiguiente_Click(object sender, EventArgs e)
        {
            validarConsulta(consultorio.cargarConsultorioSiguiente(tbFecha.Text, tbIdPaciente.Text, idEmpresa), "posteriores");
        }

        private void validarConsulta(Entidades.Consultorio c, string texto)
        {
            if (c.IdConsultorio != Guid.Empty)
            {
                llenarDatos(c);
            }
            else
            {
                MessageBox.Show("¡El paciente no registra consultas " + texto + "!", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void botMail_Click(object sender, EventArgs e)
        {
            Entidades.Resultado resultadoValidacionIngresos = validarIngreso();
            if (resultadoValidacionIngresos.Modo == 1)
            {
                mail();
                guardar();
            }
            else
            {
                MessageBox.Show("¡Faltan ingresar campos requeridos o los campos ingresados no son correctos!",
                    "Enviar Mail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // GRV - Ramírez - Guarda en el directorio configurado
        private string DirectorioReporte()
        {
            byte bytTipo = 5;
            string strDirectorio = "";

            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT reporte FROM dbo.ConfigReportes
            WHERE tipoReporte = '" + bytTipo + "'");

            if (valores.Rows.Count > 0)
            {
                strDirectorio = valores.Rows[0].ItemArray[0].ToString() + "\\";
            }
            else
            {
                strDirectorio = "P:\\CONSULTORIOS\\";
            }

            return strDirectorio;
        }

        private void mail()
        {
            List<string> archivos = new List<string>();
            Reportes report = new Reportes(new rptConsultorioDomicilios());
            string ruta = report.exportarAPDF(consultorio.cargarParametrosConsultorio(tbIdConsultorioLaboral.Text),
                 new dsMedicinaLaboral(), consultorio.cargarDataSourceConsultorio(),
                 // GRV - Modificado
                 // @"P:\CONSULTORIOS\" + tbEmpresa.Text + "-" + tbFecha.Text.Replace('/', '.') +
                 DirectorioReporte() + tbEmpresa.Text + "-" + tbFecha.Text.Replace('/', '.') +
                  "-" + tbPaciente.Text + ".pdf");
            archivos.Add(ruta);
            frmMail frm = frmMail.GetForm();
            frm.archivosAdjuntos(archivos);
            frm.direccionesMail(consultorio.cargarMailsEmpresa(tbIdConsultorioLaboral.Text));
            frm.setearAsunto("DIAGNÓSTICO DE ATENCIÓN EN CONSULTORIO");
            frm.setearMensaje("Adjuntamos al presente mail el diagnóstico de atención en consultorio.");
            frm.mailLaboral();
            frm.mostrar(this.MdiParent);
        }

        private void tpFechaAltaCitacion_ValueChanged(object sender, EventArgs e)
        {
            tpFechaAltaCitacion.CustomFormat = "dd-MM-yyyy";
        }

        private void cboCondicionLaboral_SelectionChangeCommitted(object sender, EventArgs e)
        {
            verificarFecha();
        }

        private void verificarFecha()
        {
            if (cboCondicionLaboral.SelectedIndex >= 0)
            {
                DataRowView drv = (DataRowView)cboCondicionLaboral.SelectedItem;
                string fechaAlta = drv[6].ToString();
                string fechaCitacion = drv[7].ToString();
                tpFechaAltaCitacion.Enabled = false;
                tpFechaAltaCitacion.Value = new DateTime(1800, 01, 01);
                tpFechaAltaCitacion.CustomFormat = " ";
                if ((fechaAlta == "SI" || fechaCitacion == "SI"))
                {
                    tpFechaAltaCitacion.Enabled = true;
                    tpFechaAltaCitacion.CustomFormat = "dd-MM-yyyy";
                    if (!fechaGuardada)
                    {
                        tpFechaAltaCitacion.Value = DateTime.Today;
                    }
                    else
                    {
                        tpFechaAltaCitacion.Value = Convert.ToDateTime(fecha);
                    }
                }
            }
        }
        
        private Entidades.Resultado verificarEstadoAtencion()
        {
            Entidades.Resultado result = consultorio.verificarEstadoAtencionSeleccionado(cboEstadoAtencion.SelectedValue.ToString(), tbIdPaciente.Text, tbFecha.Text);
            if (result.Modo == -1)
            {
                MessageBox.Show(result.Mensaje, "No se puede ingresar el estado de atención seleccionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        private void cboEstadoAtencion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            verificarEstadoAtencion();
        }

        // GRV - Ramírez - condición para hacer un Re-Citado
        // Si Condición Laboral = RE-CITADO Y FECHA > A ACTUAL
        private void ReservarTurno()
        {
            DateTime dtFechaActual = DateTime.Today;
            DateTime dtFechaAltaCi = tpFechaAltaCitacion.Value;
            blnResultado = true;
                                    
            if ((cboCondicionLaboral.Text == "RE-CITADO") && (dtFechaAltaCi > dtFechaActual))
            {
                if (!VerificaTurno())                
                {
                    // Pregunta si quiere asignar un turno
                    DialogResult drResultado = MessageBox.Show("¿Desea asignar un turno a este paciente?", "Consultorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (drResultado == DialogResult.Yes && lblTurnoAsignado.Text == "")
                    {
                        if (LlamarPantallaTurnos())
                        {

                            if (VerificaTurno())
                            {
                                MessageBox.Show(
                                    "Se asignado un turno para el paciente \n" + tbPaciente.Text + ", \n" +
                                    "en la siguiente fecha " + dtFechaAltaCi.ToShortDateString() + " \n" +
                                    "Para modificar este turno ir a... Asignar turnos.",
                                    "Consultorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (drResultado == DialogResult.No) 
                    { 
                        // Guarda normalmente y sale
                        tpFechaAltaCitacion.Value = dtFechaAnterior;
                        //blnResultado = true;
                    }
                    else
                    {
                        if (dtFechaAltaCi != dtFechaAnterior)
                        {
                            drResultado = MessageBox.Show(
                                "El paciente \n" + tbPaciente.Text + ", \n" +
                                "ya tiene asignado un turno para la fecha " + dtFechaAnterior.ToShortDateString() + " \n" +
                                "¿Desea liberar este turno?.",
                                "Consultorio", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (drResultado == DialogResult.Yes)
                            {
                                frmTurnos fTurnos = new frmTurnos();
                                fTurnos.ProcesoConsultorioMuestraTurno(PacienteID, EmpresaID, dtFechaAnterior);
                                //Utilidades.abrirFormulario(this.MdiParent, fTurnos, new Configuracion());
                                fTurnos.ShowDialog();
                                if (VerificaTurno(dtFechaAnterior))
                                {
                                    blnResultado = false;
                                    MessageBox.Show(
                                    "El turno para la fecha " + dtFechaAnterior.ToShortDateString() + " \n" +
                                    "¡No ha sido liberado!.",
                                    "Consultorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tpFechaAltaCitacion.Value = dtFechaAnterior;
                                }
                                else
                                {
                                    if (LlamarPantallaTurnos())
                                    {

                                        if (VerificaTurno())
                                        {
                                            MessageBox.Show(
                                                "Se ha asignado un turno para el paciente \n" + tbPaciente.Text + ", \n" +
                                                "en la siguiente fecha " + dtFechaAltaCi.ToShortDateString() + " \n" +
                                                "Para modificar este turno ir a... Asignar turnos.",
                                                "Consultorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }

                                    //blnResultado = true;
                                }
                            }
                            else 
                            {
                                tpFechaAltaCitacion.Value = dtFechaAnterior;
                                //blnResultado = true;
                            }
                        }
                    }
                }
            }else if(cboCondicionLaboral.Text == "RE-CITADO")
            {
                blnResultado = false;
                MessageBox.Show("El paciente esta RE-CITADO. La fecha tiene que ser mayor al " + tpFechaAltaCitacion.Value.ToShortDateString() + " para poder continuar. ", "Consultorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool LlamarPantallaTurnos()
        {
            bool blnValor = false;

            try
            {
                frmTurnos fTurnos = new frmTurnos();
                fTurnos.ProcesoConsultorio(PacienteID, EmpresaID, tpFechaAltaCitacion.Value);
                blnValor = true;
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                DialogResult resultExamen = MessageBox.Show("Todavía no se ha registrado un horario de turnos disponibles para la fecha  " + tpFechaAltaCitacion.Value.Date.ToShortDateString() + "\n\n¿Desea crear o actualizar el horario de turnos disponible?", "Consultorio",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                blnValor = false;

                if (resultExamen == DialogResult.OK)
                {
                    frmHorario fHorario = new frmHorario(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA);
                    fHorario.ShowDialog();
                    //Utilidades.abrirFormulario(this, new frmHorario(this.configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA), this.configuracion);
                    LlamarPantallaTurnos();
                }
                else
                {
                    blnResultado = false;
                }
                
                return blnValor;
            }

            return blnValor;
        }

        private bool VerificaTurno()
        { 
            Guid gidIDPaciente;
            DateTime dtFechaAltaCi = tpFechaAltaCitacion.Value;
            CapaNegocioMepryl.Turno turno = new Turno();

            try
            {
                gidIDPaciente = new Guid(PacienteID);
            }
            catch
            {
                gidIDPaciente = Guid.Empty;
            }

            return turno.VerificaTurnoConsultorio(gidIDPaciente, dtFechaAltaCi);
        }

        private bool VerificaTurno(DateTime dtFechaAnterior)
        {
            Guid gidIDPaciente;            
            CapaNegocioMepryl.Turno turno = new Turno();

            try
            {
                gidIDPaciente = new Guid(PacienteID);
            }
            catch
            {
                gidIDPaciente = Guid.Empty;
            }

            return turno.VerificaTurnoConsultorio(gidIDPaciente, dtFechaAnterior);
        }

        private void frmConsultorio_Load(object sender, EventArgs e)
        {

        }

        private void tbSi_Click(object sender, EventArgs e)
        {
            string idConsultaLaboral = consultorio.ObtenerIdConsultaLaboralSegunConsultorio(tbIdConsultorioLaboral.Text.ToString());
            frmFacturacionPrestaciones frm = new frmFacturacionPrestaciones(this, idEmpresa, idConsultaLaboral);
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(frm.Location.X + 160, frm.Location.Y + 150);
            frm.ShowDialog();
        }
    }
}
