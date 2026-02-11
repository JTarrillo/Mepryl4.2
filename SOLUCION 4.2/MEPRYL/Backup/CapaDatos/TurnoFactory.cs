using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class TurnoFactory : EntidadFactoryBase
    {
        public Turno entidad;

        public TurnoFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Turno turno = (Turno)entidad;

                SqlParameter[] param = new SqlParameter[12];

                param[0] = new SqlParameter("@id", turno.id);
                param[1] = new SqlParameter("@codigo", turno.codigo);
                param[2] = new SqlParameter("@fecha", turno.fecha);
                param[3] = new SqlParameter("@estadoID", turno.estadoID);
                param[4] = new SqlParameter("@hora", turno.hora);
                param[5] = new SqlParameter("@horaReferencia", turno.horaReferencia);
                param[6] = new SqlParameter("@nroOrden", turno.nroOrden);
                param[7] = new SqlParameter("@pacienteID", turno.pacienteID);
                param[8] = new SqlParameter("@horarioID", turno.horarioID);
                param[9] = new SqlParameter("@usuarioID", new Guid(this.configuracion.usuario.id));
                param[10] = new SqlParameter("@observaciones", turno.observaciones);
                param[11] = new SqlParameter("@registroBLOB", turno.codigo + " " + turno.observaciones + " " + turno.pacienteTexto + " " + turno.pacienteTelefonos + " " + turno.pacienteCelular + " " + turno.pacienteDni);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Turno_Update", param);

                param = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }

            return resultado;
        }


        //Implementacion
        public override void inicializarEntidad()
        {
            base.inicializarEntidad();
            entidad = new Turno(base.entidad);
        }

        public override Resultado alta(EntidadBase ent)
        {
            Resultado resultado = new Resultado();
            try
            {
                //Da el alta del registro vacío para obtener el ID
                resultado = altaID(ent);

                //Modifica el registro nuevo con los datos completos del alta
                if (resultado.mensaje == "")
                {
                    Turno datTurno = (Turno)resultado.objeto;
                    resultado = modificar(datTurno);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }


        //El alta manda todos los datos en una sola instrucción
        public void altaRapida(string codigo, DateTime fecha, Guid estadoID, string hora, string horaReferencia,
                            int nroOrden, Guid pacienteID, Guid horarioID, string observaciones,
                            bool domingo, bool lunes, bool martes, bool miercoles, bool jueves, bool viernes, bool sabado,
                            string registroBLOB)
        {
            try
            {
                
                SqlParameter[] param = new SqlParameter[17];

                param[0] = new SqlParameter("@codigo", codigo);
                param[1] = new SqlParameter("@fecha", fecha);
                param[2] = new SqlParameter("@estadoID", estadoID);
                param[3] = new SqlParameter("@hora", hora);
                param[4] = new SqlParameter("@horaReferencia", horaReferencia);
                param[5] = new SqlParameter("@nroOrden", nroOrden);
                param[6] = new SqlParameter("@pacienteID", pacienteID);
                param[7] = new SqlParameter("@horarioID", horarioID);
                param[8] = new SqlParameter("@observaciones", observaciones);
                param[9] = new SqlParameter("@domingo", domingo);
                param[10] = new SqlParameter("@lunes", lunes);
                param[11] = new SqlParameter("@martes", martes);
                param[12] = new SqlParameter("@miercoles", miercoles);
                param[13] = new SqlParameter("@jueves", jueves);
                param[14] = new SqlParameter("@viernes", viernes);
                param[15] = new SqlParameter("@sabado", sabado);
                param[16] = new SqlParameter("@registroBLOB", registroBLOB);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Turno_InsertRapido", param);

                param = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Cambia el estado habilitado en el conjunto de registros que indica el where
        public void cambiarEstadoHabilitar(string where, int estado)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@where", where);
                param[1] = new SqlParameter("@estado", estado);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Turno_CambiarEstadoHabilitar", param);

                param = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Lee el registro obtenido de la base de datos, cada implementación agrega los campos espefícicos.
        protected override EntidadBase leerRegistro(SqlDataReader dr)
        {
            Turno turno = new Turno(base.leerRegistro(dr));
            try
            {
                turno.fecha = DateTime.Parse(dr["fecha"].ToString());
                turno.estadoID = new Guid(dr["estadoID"].ToString());
                turno.estadoTexto = dr["estadoTexto"].ToString();
                turno.hora = dr["hora"].ToString();
                turno.horaReferencia = dr["horaReferencia"].ToString();
                turno.nroOrden = int.Parse(dr["nroOrden"].ToString());
                turno.pacienteID = new Guid(dr["pacienteID"].ToString());
                turno.pacienteTexto = dr["pacienteTexto"].ToString();
                turno.pacienteTelefonos = dr["pacienteTelefonos"].ToString();
                turno.pacienteCelular = dr["pacienteCelular"].ToString();
                turno.pacienteDni = dr["pacienteDni"].ToString();
                turno.horarioID = new Guid(dr["horarioID"].ToString());
                turno.usuarioID = new Guid(dr["usuarioID"].ToString());
                turno.usuarioTexto = dr["usuarioTexto"].ToString();
                turno.profesionalTexto = dr["profesionalTexto"].ToString();
                turno.especialidadTexto = dr["especialidadTexto"].ToString();
                turno.observaciones = dr["observaciones"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return turno;
        }

        //Borra los registros de Turnos libres para un horario determinado
        public string borrarTurnosLibres(Guid horarioID)
        {
            string resultado = "";
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@horarioID", horarioID);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_DeleteTurnosLibres", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        //Borra todos los turnos de un horario
        public string eliminarTurnos(Guid horarioID)
        {
            string resultado = "";
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@horarioID", horarioID);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_DeleteByHorario", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        //Borra todos por fechas
        public string eliminarTurnosPorFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            string resultado = "";
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@fechaDesde", Utilidades.fechaCanonicaSQL(fechaDesde, "00:00:00"));
                param[1] = new SqlParameter("@fechaHasta", Utilidades.fechaCanonicaSQL(fechaHasta, "23:59:59"));

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_DeleteByFechas", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        //Cuenta turnos por fechas
        public string contarTurnosPorFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            string resultado = "";
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@fechaDesde", Utilidades.fechaCanonicaSQL(fechaDesde, "00:00:00"));
                param[1] = new SqlParameter("@fechaHasta", Utilidades.fechaCanonicaSQL(fechaHasta, "23:59:59"));

                resultado = SqlHelper.ExecuteScalar(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_DeleteByFechasContarRegistros", param).ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        //Cambia el bloqueo
        public string cambiarBloqueo(Guid turnoID, bool bloquear)
        {
            string resultado = "";
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@turnoID", turnoID);
                param[1] = new SqlParameter("@bloquear", bloquear);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_RegistroCambiarEstado", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        //Consulta el estado del bloqueo
        public bool consultarBloqueo(Guid turnoID, bool verificarAsignacion)
        {
            bool resultado = false;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@turnoID", turnoID);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_registroEstado", param);
                if (dr.HasRows)
                {
                    dr.Read();
                    resultado = bool.Parse(dr["bloqueado"].ToString());
                    if (verificarAsignacion && dr["estadoCodigo"].ToString() == "2")
                        resultado = true;
                }
                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }


        //Obtiene las opciones horarias de turnos libres para una fecha determinada.
        public string obtenerOpcionesHorarias(ref DateTime fecha, EEspecialidad especialidad)
        {
            string resultado = "";
            try
            {
                Dictionary<string, object[]> listaOpciones = obtenerSegmentosHorarios(especialidad);

                //Ejecuta una consulta por cada segmento horario para saber si hay turnos libres en cada segmento
                
                bool turnoLibreEncontrado = false;
                while (!turnoLibreEncontrado)
                {
                    string separador = "";
                    int contador = 0;
                    //Si no encuentra para la fecha, el mismo día en la semana próxima... así hasta un mes.
                    while (resultado == "" && contador < 5)
                    {
                        foreach (object[] row in listaOpciones.Values)
                        {
                            resultado += buscarTurnosLibres(row, ref fecha, ref separador, false, especialidad);
                        }
                        if (resultado == "") {
                            fecha = fecha.AddDays(7);
                            contador++;
                        }
                    }
                    //Si no se encontró turno libre, se busca la proxima fecha disponible
                    //RESPETAR EL DIA ELEGIDO POR EL USUARIO
                    //ACA ESTA LA LOGICA QUE HAY QUE CAMBIAR 
                    if (resultado == "")
                    {
                        if (listaOpciones.Count>0)
                            resultado = buscarTurnosLibres(listaOpciones["1"], ref fecha, ref separador, true, especialidad);
    
                        if (resultado == "")
                        {
                            resultado = "No hay turnos disponibles.";
                            break;
                        }
                        else
                            resultado = "";
                    }
                    else
                        turnoLibreEncontrado = true;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        //Otiene los segmentos horarios predefefinidos por la clinica.
        //07/11/2014 Modificado para agregar diferentes especialidades.
        public Dictionary<string, object[]> obtenerSegmentosHorarios(EEspecialidad especialidad)
        {
            Dictionary<string, object[]> listaOpciones = new Dictionary<string, object[]>();
            try
            {
                //Primero obtiene la lista de segmentos horarios
                object[] valores;

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@especialidadCodigo", especialidad.ToString()); 
                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), CommandType.StoredProcedure, "sp_TurnoOpcionesHorarias_SelectAll"); //Hay que proporcinarle los parametros para diferenciar las epecialidades.
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        valores = new object[11];
                        dr.GetValues(valores);
                        listaOpciones[dr["codigo"].ToString()] = valores;
                    }
                }
                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return listaOpciones;
        }

        //Realiza la búsqueda de turnos libres en determinado segmento de fechas y horarios
        // 07/11/2014: Modificado para agregar diferentes especialidades
        private string buscarTurnosLibres(object[] row, ref DateTime fecha, ref string separador, bool buscarProximaFecha, EEspecialidad especialidad)
        {
            string resultado = "";
            try 
            {
                string filtro = "fecha>=" + Utilidades.fechaCanonicaSQL(fecha, "00:00:00");
                if (!buscarProximaFecha)
                {
                    filtro += " AND " + "hora>='" + row[3].ToString() + "' AND " +
                                        "hora<='" + row[4].ToString() + "'" + " AND " + 
                                        "fecha<=" + Utilidades.fechaCanonicaSQL(fecha, "23:59:59");
                }

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@filtro", filtro);
                param[1] = new SqlParameter("@especialidadCodigo", "1");
                //param[1] = new SqlParameter("@especialidadCodigo", especialidad.ToString());

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_Turno_SelectFiltroSMS", param);
                if (dr.HasRows)
                {
                    dr.Read();
                    resultado += separador + row[1].ToString() + " " + row[2].ToString() + ". ";
                    separador = "\r";
                    fecha = DateTime.Parse(dr["fecha"].ToString()).Date;
                }
                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        //Modificaciones: Agregar especialidades
        /*
        //Registra la solicitud de turno
        public void registrarSolicitudTurno(DateTime fechaSolicitada, string telefono, string dni, string nombres, string mensaje, Especialidad especialidad)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@fecha", fechaSolicitada);
                param[1] = new SqlParameter("@telefono", telefono);
                param[2] = new SqlParameter("@dni", dni);
                param[3] = new SqlParameter("@nombres", nombres);
                param[4] = new SqlParameter("@mensaje", mensaje);
                param[5] = new SqlParameter("@especialidadCodigo", especialidad.ToString());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_TurnoSolicitud_InsertRapido", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

        }
        */
        //Registra la solicitud de turno
        public void registrarSolicitudTurno(DateTime fechaSolicitada, string telefono, string dni, string nombres, string mensaje, EEspecialidad especialidad)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@fecha", fechaSolicitada);
                param[1] = new SqlParameter("@telefono", telefono);
                param[2] = new SqlParameter("@dni", dni);
                param[3] = new SqlParameter("@nombres", nombres);
                param[4] = new SqlParameter("@mensaje", mensaje);
                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_TurnoSolicitud_InsertRapido", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

        }


        //Registra la solicitud de turno
        public void cambiarEstadoSolicitudTurno(string telefono)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@telefono", telefono);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_TurnoSolicitud_cambioEstado", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

        }


        //Obtiene la ultima solicitud de turno realizada por el telefono
        public Dictionary<string, string> obtenerSolicitudTurno(string telefono)
        {
            Dictionary<string, string> resultado = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@filtro", "telefono='" + telefono + "' AND estadoID=0");

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_TurnoSolicitud_SelectFiltroSMS", param);

                if (dr.HasRows)
                {
                    resultado = new Dictionary<string, string>();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            resultado[dr.GetName(i)] = dr[i].ToString();
                        }
                    }
                }
                dr.Close();
                dr = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;

        }

        //Cambia el estado de un turno
        public void cambiarEstadoTurno(Guid turnoID, string estadoCodigo)
        {
            try
            {
            
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@id", turnoID);
                param[1] = new SqlParameter("@estadoCodigo", estadoCodigo);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Turno_CambiarEstado", param);

                param = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                
            }

        }

    }
}