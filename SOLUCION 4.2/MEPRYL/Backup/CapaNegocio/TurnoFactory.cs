using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;
using System.Data;

namespace CapaNegocio
{
    public class TurnoFactory : EntidadFactoryBase
    {
        public event ProgresoEventHandler progreso;

        public TurnoFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            if (this.datEntidadFac == null)
                this.datEntidadFac = new CapaDatos.TurnoFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Turno();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Turno negTurno = new CapaNegocio.Turno();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negTurno;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negTurno = (CapaNegocio.Turno)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negTurno;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                CapaNegocio.Turno turno = (CapaNegocio.Turno)negEntidad;
                
                crearDatEntidadFac();

                CapaDatos.Turno datTurno = (CapaDatos.Turno)turno.convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datTurno);
                datTurno = (CapaDatos.Turno)resultado.objeto;
                turno = (CapaNegocio.Turno)convertirEnObjetoNegocio(datTurno);

                resultado.objeto = turno;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        //Cambia el estado habilitado de todos los registros seleccionados
        public void cambiarEstadoHabilitar(string where, int estado)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).cambiarEstadoHabilitar(where, estado);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Da el alta recibiendo todos los datos en un objeto, generando el nuevo codigo, todo en el mismo procedimiento
        public void altaRapida(CapaNegocioBase.EntidadBase negEntidad)
        {
            try
            {
                CapaNegocio.Turno turno = (CapaNegocio.Turno)negEntidad;

                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).altaRapida(turno.codigo, turno.fecha, turno.estadoID, turno.hora, turno.horaReferencia,
                                                        turno.nroOrden, turno.pacienteID, turno.horarioID, turno.observaciones,
                                                        turno.domingo, turno.lunes, turno.martes, turno.miercoles, turno.jueves, turno.viernes, turno.sabado,
                                                        turno.codigo + " " + turno.observaciones + " " + turno.pacienteTexto + " " + turno.pacienteTelefonos + " " + turno.pacienteCelular + " " + turno.pacienteDni);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");

            try
            {
                CapaNegocio.Turno turno = (CapaNegocio.Turno)entidad;
                
                crearDatEntidadFac();

                CapaDatos.Turno datTurno = (CapaDatos.Turno)turno.convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datTurno);

                datTurno = (CapaDatos.Turno)resultado.objeto;
                turno = (CapaNegocio.Turno)convertirEnObjetoNegocio(datTurno);

                resultado.objeto = turno;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        public void cambiarEstadoTurno(Turno turno, string estadoCodigo)
        {
            try
            {
                
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).cambiarEstadoTurno(turno.id, estadoCodigo);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public void generarTurnos(CapaNegocio.Horario horario)
        {
            try
            {
                //Borra los turnos generados para este horario, siempre que no estén ocupados
                borrarTurnosLibres(horario);

                //Toma los dias de la semana que se atiende
                Dictionary<DayOfWeek, bool> diasAtencion = new Dictionary<DayOfWeek, bool>();
                diasAtencion.Add(DayOfWeek.Sunday, horario.domingo);
                diasAtencion.Add(DayOfWeek.Monday, horario.lunes);
                diasAtencion.Add(DayOfWeek.Tuesday, horario.martes);
                diasAtencion.Add(DayOfWeek.Wednesday, horario.miercoles);
                diasAtencion.Add(DayOfWeek.Thursday, horario.jueves);
                diasAtencion.Add(DayOfWeek.Friday, horario.viernes);
                diasAtencion.Add(DayOfWeek.Saturday, horario.sabado);

                string[] aHoraDesde = horario.horaDesde.Split(":".ToCharArray());
                string[] aHoraHasta = horario.horaHasta.Split(":".ToCharArray());
                DateTime horaDesde = new DateTime(2010, 1, 1, int.Parse(aHoraDesde[0]), int.Parse(aHoraDesde[1]), 0);
                DateTime horaHasta = new DateTime(2010, 1, 1, int.Parse(aHoraHasta[0]), int.Parse(aHoraHasta[1]), 0);
                TimeSpan segmentoTotal = horaHasta - horaDesde;
                horario.cantidadTurnos = ((int)segmentoTotal.TotalMinutes / horario.citarCada)*horario.pacientesGrupo;
                TimeSpan segmentoTurno = new TimeSpan(segmentoTotal.Ticks / horario.cantidadTurnos);

                TimeSpan unidadHoraria = new TimeSpan(0, horario.citarCada, 0); //El segmento de tiempo donde se dan los turnos por nro de orden.

                //Ahora debe recorrer todas las fechas, todas las horas del segmento total
                DateTime fechaActual = horario.fechaDesde.Date;
                DateTime fechaFinal = horario.fechaHasta.Date.AddDays(1);
                CapaNegocio.Turno turno = new Turno();
                TimeSpan cantDias = fechaFinal - fechaActual;
                int contador = 0;
                while (fechaActual < fechaFinal)
                {
                    //Procesa el día si es un dia de la semana que el medico atiende
                    if (diasAtencion[fechaActual.DayOfWeek])
                    {
                        DateTime horaActual = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, int.Parse(aHoraDesde[0]), int.Parse(aHoraDesde[1]), 0);
                        horaHasta = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, int.Parse(aHoraHasta[0]), int.Parse(aHoraHasta[1]), 0);
                        int nroOrden = 1;
                        DateTime horaReferencia = horaActual;
                        EntidadBase turnoBase;
                        while (horaActual < horaHasta)
                        {
                            if (horaActual >= horaReferencia + unidadHoraria)
                            {
                                horaReferencia += unidadHoraria;
                                nroOrden = 1;
                            }

                            //Crea el Turno
                            turno.fecha = fechaActual;
                            turno.hora = horaActual.ToString("HH:mm");
                            turno.horaReferencia = horaReferencia.ToString("HH:mm");
                            turno.nroOrden = nroOrden;
                            turno.horarioID = horario.id;

                            if (fechaActual.DayOfWeek == DayOfWeek.Sunday)
                                turno.domingo = true;
                            else
                                turno.domingo = false;

                            if (fechaActual.DayOfWeek == DayOfWeek.Monday)
                                turno.lunes = true;
                            else
                                turno.lunes = false;
                            
                            if (fechaActual.DayOfWeek == DayOfWeek.Tuesday)
                                turno.martes = true;
                            else
                                turno.martes = false;
                            
                            if (fechaActual.DayOfWeek == DayOfWeek.Wednesday)
                                turno.miercoles = true;
                            else
                                turno.miercoles = false;
                            
                            if (fechaActual.DayOfWeek == DayOfWeek.Thursday)
                                turno.jueves = true;
                            else
                                turno.jueves = false;
                            
                            if (fechaActual.DayOfWeek == DayOfWeek.Friday)
                                turno.viernes = true;
                            else
                                turno.viernes = false;
                            
                            if (fechaActual.DayOfWeek == DayOfWeek.Saturday)
                                turno.sabado = true;
                            else
                                turno.sabado = false;

                            turnoBase = turno;
                            //obtenerNuevoCodigo(ref turnoBase);
                            altaRapida(turno);

                            horaActual += segmentoTurno;
                            nroOrden++;

                        }
                    }
                    contador++;
                    fechaActual = fechaActual.AddDays(1);
                    if (this.progreso!=null)
                        this.progreso(contador, cantDias.Days);
                    
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public void borrarTurnosLibres(CapaNegocio.Horario horario)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).borrarTurnosLibres(horario.id);
             
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Elimina todos los turnos de un horario.
        public void eliminarTurnos(string horarioID)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).eliminarTurnos(new Guid(horarioID));

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        //Elimina turnos por fechas.
        public void eliminarTurnosPorFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).eliminarTurnosPorFechas(fechaDesde, fechaHasta);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        
        //Contar turnos por fechas.
        public string contarTurnosPorFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            string resultado = "";
            try
            {
                crearDatEntidadFac();

                resultado = ((CapaDatos.TurnoFactory)datEntidadFac).contarTurnosPorFechas(fechaDesde, fechaHasta);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }

            return resultado;
        }


        //Bloquea o desbloquea un Turno.
        public void cambiarBloqueo(Guid turnoID, bool bloquear)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).cambiarBloqueo(turnoID, bloquear);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        //Consulta el estado del bloqueo de un Turno.
        public bool consultarBloqueo(Guid turnoID, bool verificarAsignacion)
        {
            bool resultado = false;
            try
            {
                resultado = ((CapaDatos.TurnoFactory)datEntidadFac).consultarBloqueo(turnoID, verificarAsignacion);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }


        //Obtiene las opciones horarias de turnos dispoibles para una fecha.
        public string obtenerOpcionesHorarias(ref DateTime fecha)
        {
            string resultado = "";
            try
            {
                crearDatEntidadFac();

                resultado = ((CapaDatos.TurnoFactory)datEntidadFac).obtenerOpcionesHorarias(ref fecha, EEspecialidad.Preventiva); //Modificar acaaa!!!

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }

        /* En desarrollo: varias especialidades
        //Realiza el registro de la solicitud de turno.
        public void registrarSolicitudTurno(DateTime fechaSolicitada, string telefono, string dni, string nombres, string mensaje, Especialidad especialidad)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).registrarSolicitudTurno(fechaSolicitada, telefono, dni, nombres, mensaje, especialidad);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        */

        //Realiza el registro de la solicitud de turno.
        public void registrarSolicitudTurno(DateTime fechaSolicitada, string telefono, string dni, string nombres, string mensaje)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).registrarSolicitudTurno(fechaSolicitada, telefono, dni, nombres, mensaje, EEspecialidad.Preventiva);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        //Cambia el estado de las solicitudes pendientes para un telefono.
        public void cambiarEstadoSolicitudTurno(string telefono)
        {
            try
            {
                crearDatEntidadFac();

                ((CapaDatos.TurnoFactory)datEntidadFac).cambiarEstadoSolicitudTurno(telefono);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Registra el Paciente y realiza la reserva del turno.
        // 07/11/2014: Modificado para atender varias especialidades
        public Turno reservarTurno(string telefono, string opcionCodigo)
        {
            Turno turno = null;
            try
            {
                crearDatEntidadFac();
                CapaDatos.TurnoFactory turnoFac = (CapaDatos.TurnoFactory)datEntidadFac;

                //Primero obtiene los datos de la última solicitud de turno para este telefono.
                Dictionary<string, string> soliticudTurno = turnoFac.obtenerSolicitudTurno(telefono);

                //Si no es nulo, existe una solicitud. Sino, hay que notificar el error
                if (soliticudTurno!=null)
                {
                    //Intenta obtener el paciente, si no existe lo registra.
                    PacienteFactory pacienteFac = new PacienteFactory(this.configuracion, "Paciente");

                    Paciente paciente = (Paciente)pacienteFac.getByCodigo(soliticudTurno["dni"]);

                    if (paciente == null) //Si no existe, lo da de alta
                    {
                        paciente = (Paciente)pacienteFac.alta(soliticudTurno["nombres"]);
                        paciente.codigo = soliticudTurno["dni"];

                        string[] apnom = soliticudTurno["nombres"].Split(' ');
                        if (apnom.Length > 0)
                            paciente.apellido = apnom[0]; 
                        if (apnom.Length > 1)
                            paciente.nombres = apnom[1];
                        if (apnom.Length > 2)
                            paciente.nombres += " " + apnom[2];
                        
                        paciente.dni = soliticudTurno["dni"];
                        paciente.observaciones = "Registrado por DataSMS.";
                    }

                    //Siempre acualiza el celular y modifica el Paciente
                    paciente.celular = soliticudTurno["telefono"];
                    pacienteFac.modificar(paciente);

                    //Obtiene la lista de horarios
                    Dictionary<string, object[]> segmentosHorarios = turnoFac.obtenerSegmentosHorarios(EEspecialidad.Preventiva);  //Modificar acaaa!!!

                    //Obtiene un turno libre: Si no encuentra turno para la fecha y hora pedidas, trae la mas proxima hacia adelante.
                    string filtro = "fecha>=" + Utilidades.fechaCanonicaSQL(DateTime.Parse(soliticudTurno["fecha"]),"00:00:00") + " AND " +
                                    "hora>='" + segmentosHorarios[opcionCodigo][3].ToString() + "' AND " +
                                    "pacienteID='" + Utilidades.ID_VACIO + "' AND " +
                                    "habilitado=1";
                                    //"dbo.Horario.ID='19B35290-9376-4364-A502-954F30BC574F' AND habilitado=1";

                    ///DataTable dt = turnoFac.getAllInDataTable(filtro, 1);
                    //DataTable dt = turnoFac.getAllInDataTable(filtro, 1, "Turno", soliticudTurno["especialidadCodigo"]);  //me quede aca!!!
                    DataTable dt = turnoFac.getAllInDataTable(filtro, 1, "Turno", EEspecialidad.Preventiva);  //me quede aca!!!

                    //Si no hay turnos, estamos en problemas
                    if (dt.Rows.Count > 0)
                    {
                        //Recupera el turno en objeto
                        turno = (Turno)this.getByCodigo(dt.Rows[0]["codigo"].ToString());
                        
                        turno.pacienteID = paciente.id;
                        turno.pacienteDni = paciente.dni;
                        turno.pacienteCelular = paciente.celular;
                        turno.pacienteTexto = paciente.apellido + ", " + paciente.nombres;

                        //Asigna el Paciente y reserva el turno
                        this.modificar(turno);

                        //Cambia el estado a Libre
                        this.cambiarEstadoTurno(turno, "2");
                    }
                    else
                    {
                        //No hay turnos para asignar. :S
                    }
                    dt.Dispose();
                    dt = null;
                }
                else
                {
                    //No existe una solicitud previa.
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return turno;
        }
    }
}