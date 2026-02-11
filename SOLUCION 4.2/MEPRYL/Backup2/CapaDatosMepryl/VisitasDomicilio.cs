using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunes;
using Entidades;
using System.Data;

namespace CapaDatosMepryl
{
    public class VisitasDomicilio
    {
        public DataTable cargarEmpresas(string filtro)
        {
            if (filtro.Length == 0)
            {
                return  SQLConnector.obtenerTablaSegunConsultaString("select e.id, e.razonSocial as Empresa from dbo.Empresa e order by e.razonSocial");
            }
            return  SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial as Empresa from dbo.Empresa e where e.razonSocial LIKE '%" + filtro + @"%' 
            order by e.razonSocial");
        }

        public DataTable cargarLocalidad(string filtro)
        {
            if (filtro.Length == 0)
            {
                return  SQLConnector.obtenerTablaSegunConsultaString(@"select id, pres from dbo.Prestaciones where tiPres = 'V' and pres != 'A DESIGNAR'
                order by pres");
            }
            return  SQLConnector.obtenerTablaSegunConsultaString(@"select id, pres from dbo.Prestaciones
            where tiPres = 'V' and pres != 'A DESIGNAR' and pres LIKE '%" + filtro + @"%'
            order by pres");
        }

        public Entidades.Resultado buscarDni(string dni, string empresa)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(@"select p.id from dbo.Paciente p
            where p.empresaID = '" + empresa + "' and p.dni = '" + dni + "'");
            if (tabla.Rows.Count > 0)
            {
                retorno.Modo = 1;
                retorno.IdRetorno = new Guid(tabla.Rows[0][0].ToString());
                return retorno;
            }
            else
            {
                tabla = SQLConnector.obtenerTablaSegunConsultaString(@"select p.id, p.empresaID from dbo.Paciente p
                where p.dni = '" + dni + "'");
                if (tabla.Rows.Count > 0)
                {
                    if (tabla.Rows[0][1].ToString() != string.Empty && new Guid(tabla.Rows[0][1].ToString()) != Guid.Empty)
                    {
                        DataTable tablaEmpresa = SQLConnector.obtenerTablaSegunConsultaString(@"select e.razonSocial from dbo.Empresa e
                        where e.id = '" + tabla.Rows[0][1].ToString() + "'");
                        retorno.Modo = 2;
                        retorno.Mensaje = tablaEmpresa.Rows[0][0].ToString();
                        retorno.IdRetorno = new Guid(tabla.Rows[0][0].ToString());
                        return retorno;
                    }
                    else
                    {
                        retorno.Modo = 4;
                        retorno.IdRetorno = new Guid(tabla.Rows[0][0].ToString());
                        return retorno;
                    }
                }
                retorno.Modo = 3;
                retorno.IdRetorno = Guid.Empty;
                return retorno;               
            }
        }

        public void cambiarEmpresaDePaciente(Guid idPaciente, Guid idEmpresa)
        {
            List<string> updateEmpresa = SQLConnector.generarListaParaProcedure("@idPaciente","@idEmpresa");
            SQLConnector.executeProcedure("sp_Paciente_UpdateEmpresa", updateEmpresa, idPaciente, idEmpresa);
        }

        public Entidades.VisitasDomicilio inicializarVisita(Guid idPaciente)
        {
            Entidades.VisitasDomicilio retorno = new Entidades.VisitasDomicilio();
            DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString(@"select p.id, p.apellido + ' ' + p.nombres as nombre,
            p.dni, e.razonSocial, p.direccion, p.localidad, e.id, p.empresaTarea from dbo.Paciente p inner join dbo.Empresa e on p.empresaID = e.id
            where p.id = '" + idPaciente + "'");
            if (paciente.Rows.Count > 0)
            {
                retorno.IdPaciente = new Guid(paciente.Rows[0][0].ToString());
                retorno.Paciente = paciente.Rows[0][1].ToString();
                retorno.DniPaciente = paciente.Rows[0][2].ToString();
                retorno.Empresa = paciente.Rows[0][3].ToString();
                retorno.Domicilio = paciente.Rows[0][4].ToString();
                if (paciente.Rows[0][5].ToString() != string.Empty && new Guid(paciente.Rows[0][5].ToString()) != Guid.Empty)
                {
                    DataTable localidad = SQLConnector.obtenerTablaSegunConsultaString("select pres from dbo.Prestaciones where id = '"
                        + paciente.Rows[0][5].ToString() + "'");
                    retorno.LocalidadDescripcion = localidad.Rows[0][0].ToString();
                }
                retorno.IdEmpresa = new Guid(paciente.Rows[0][6].ToString());
                retorno.Tarea = paciente.Rows[0][7].ToString();
            }
            return retorno;
        }

        public DataTable cargarMotivoConsulta()
        {
            return SQLConnector.obtenerTablaSegunConsultaString("select id, descripcion from dbo.MotivoDeConsultaLaboral");
        }

        public DataTable cargarEstadoAtencion()
        {
            return SQLConnector.obtenerTablaSegunConsultaString("select id, descripcion from dbo.EstadoAtencion where codigo = 1");
        }

        public DataTable cargarMedico()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, apellido + ' ' + nombres as descripcion from dbo.Profesional
            where visitasCapital = 1 and visitasProvincia = 1");
        }

        public Entidades.Resultado verificarDomicilio(Entidades.VisitasDomicilio entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Paciente where id = '" +
                entidad.IdPaciente.ToString() + "' and direccion = '" + entidad.Domicilio + "' and localidad = '" + entidad.Localidad.ToString() + "'");
            if (consulta.Rows.Count > 0)
            {
                retorno.Modo = 1;
                return retorno;
            }
            retorno.Modo = 2;
            return retorno;
        }

        public void actualizarDomicilioPaciente(Entidades.VisitasDomicilio entidad)
        {
            List<string> updateDomicilio = SQLConnector.generarListaParaProcedure("@idPaciente", "@localidad", "@domicilio");
            SQLConnector.executeProcedure("sp_Paciente_UpdateDomicilio", updateDomicilio, entidad.IdPaciente, entidad.Localidad, entidad.Domicilio);
        }

        public Entidades.Resultado guardarVisita(Entidades.VisitasDomicilio entidad)
        {
            Entidades.Resultado resultado = new Entidades.Resultado();
            try
            {
                if (entidad.Id == Guid.Empty)
                {
                    List<string> listaCreateCons = SQLConnector.generarListaParaProcedure("@tipo", "@fecha", "@nroOrden", "@identificador", "@pacienteID", "@observaciones", "@valido", "@idTurno");
                    string idConsulta = SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", listaCreateCons, "V", entidad.FechaHora, obtenerProximoNumeroIdentificador(entidad.FechaHora), "V" + obtenerProximoNumeroIdentificador(entidad.FechaHora), entidad.IdPaciente, "", 1, Guid.Empty);
                    string idEspecialidad = SQLConnector.obtenerTablaSegunConsultaString("select id from dbo.Especialidad where descripcion = 'VISITAS'").Rows[0][0].ToString();
                    List<string> listaAddTipoExamen = SQLConnector.generarListaParaProcedure("@idConsulta", "@idTurno", "@modificado", "@idEspecialidad", "@importe", "@factClub");
                    string idTipoExamen = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", listaAddTipoExamen, new Guid(idConsulta), Guid.Empty, "", new Guid(idEspecialidad), 0.00, "0");

                    DataTable predefinidos = SQLConnector.obtenerTablaSegunConsultaString(@"select I.id As IdItem, IP.estado as Estado 
                    from dbo.ItemsPredefinidos IP inner join dbo.Items I
                    on IP.idItem = I.id  where IP.idEspecialidad = '" + idEspecialidad + "' order by IP.idItem asc");
                    List<string> listaProcedure = SQLConnector.generarListaParaProcedure("@idItem", "@idExamenPaciente", "@estado");
                    foreach (DataRow row in predefinidos.Rows)
                    {
     
                      SQLConnector.executeProcedure("sp_Items_AddPorPaciente", listaProcedure, row.ItemArray[0], new Guid(idTipoExamen), row.ItemArray[1]);

                    }

                    List<string> listaAddEmpresa = SQLConnector.generarListaParaProcedure("@idEmpresa", "@idTipoExamen", "@tarea");
                    SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Add", listaAddEmpresa, entidad.IdEmpresa, new Guid(idTipoExamen), entidad.Tarea);

                    List<string> listaCreateConsultaLaboral = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@tipo");
                    string idConsultaLaboral = SQLConnector.executeProcedureWithReturnValue("sp_ConsultaLaboral_Insert",listaCreateConsultaLaboral, new Guid(idTipoExamen), 2);

                    List<string> add = SQLConnector.generarListaParaProcedure("@fechaHora", "@idMotivo", "@idEstadoAtencion",
                    "@medico", "@idPaciente", "@domicilio", "@entreCalle1", "@entreCalle2", "@localidad", "@observaciones", "@domicilioTransitorio");
                    string idExamenLaboral = SQLConnector.executeProcedureWithReturnValue("sp_VisitasLaboral_Insert", add, entidad.FechaHora, entidad.IdMotivoConsulta,
                        entidad.IdEstadoAtencion, entidad.Medico, entidad.IdPaciente, entidad.Domicilio,
                        entidad.EntreCalle1, entidad.EntreCalle2, entidad.Localidad, entidad.Observaciones, entidad.DomicilioTransitorio);

                    List<string> updateConsultaLaboral = SQLConnector.generarListaParaProcedure("@id", "@idVisita");
                    SQLConnector.executeProcedure("sp_ConsultaLaboral_UpdateIdVisita", updateConsultaLaboral, new Guid(idConsultaLaboral), new Guid(idExamenLaboral));

                }
                else
                {
                    string idConsulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id 
                    from dbo.VisitasLaboral vl
                    inner join dbo.ConsultaLaboral cl on cl.idVisitaLaboral = vl.id
                    inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
                    inner join dbo.Consulta c on tep.idConsulta = c.id
                    where vl.id = '" + entidad.Id.ToString() + "'").Rows[0][0].ToString();
                    List<string> updateConsulta = SQLConnector.generarListaParaProcedure("@fecha", "@nroOrden", "@identificador", "@idConsulta");
                    SQLConnector.executeProcedure("sp_Consulta_UpdateFechaIdentificador", updateConsulta, entidad.FechaHora, obtenerProximoNumeroIdentificador(entidad.FechaHora),
                        "V" + obtenerProximoNumeroIdentificador(entidad.FechaHora), new Guid(idConsulta));
                    List<string> update = SQLConnector.generarListaParaProcedure("@id", "@fechaHora", "@idMotivo", "@idEstadoAtencion",
                    "@medico", "@domicilio", "@entreCalle1", "@entreCalle2", "@localidad", "@observaciones", "@domicilioTransitorio");
                    SQLConnector.executeProcedure("sp_VisitasLaboral_UpdateVisita", update, entidad.Id, entidad.FechaHora,
                        entidad.IdMotivoConsulta, entidad.IdEstadoAtencion, entidad.Medico, entidad.Domicilio, entidad.EntreCalle1,
                        entidad.EntreCalle2, entidad.Localidad, entidad.Observaciones, entidad.DomicilioTransitorio);
                }
                resultado.Modo = 1;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = ex.ToString();
                return resultado;
            }
        }

        private string obtenerProximoNumeroIdentificador(DateTime fecha)
        {
            DataTable consultas = SQLConnector.obtenerTablaSegunConsultaString(@"select nroOrden from dbo.Consulta where tipo = 'V'
            and CONVERT(date,fecha) = '" + fecha.ToShortDateString() + @"'
            order by nroOrden");
            if (consultas.Rows.Count > 0)
            {
                return (Convert.ToInt16(consultas.Rows[consultas.Rows.Count - 1].ItemArray[0].ToString()) + 1).ToString();
            }
            return "1";
        }

        public DataTable cargarVisitasPendientes()
        {
            DataTable imagenEnviado = SQLConnector.obtenerTablaSegunConsultaString(@"select imagen from dbo.Clasificaciones
            where codigo = 1");
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"
            select vl.id, CONVERT(VARCHAR(10), vl.fechaHora, 103) as Fecha, c.identificador as 'Nº Visita', prof.apellido + ' ' + prof.nombres as Medico,
            e.razonSocial as Empresa, p.dni as DNI, p.apellido + ' ' + p.nombres as Paciente,
            vl.domicilio as Dirección, l.pres as Localidad, vl.visitaEnviada
            from dbo.VisitasLaboral vl
            inner join dbo.Paciente p on vl.idPaciente = p.id
            inner join dbo.Profesional prof on vl.medico = prof.id
            inner join dbo.Prestaciones l on vl.localidad = l.id
            inner join dbo.ConsultaLaboral cl on vl.id = cl.idVisitaLaboral
            inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
            inner join dbo.Empresa e on ete.idEmpresa = e.id
            inner join dbo.Consulta c on tep.idConsulta = c.id
            where vl.visitaPendiente IS NULL order by c.fecha, c.nroOrden");
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Nº Visita");
            retorno.Columns.Add("Medico");
            retorno.Columns.Add("Empresa");
            retorno.Columns.Add("DNI");
            retorno.Columns.Add("Paciente");
            retorno.Columns.Add("Dirección");
            retorno.Columns.Add("Localidad");
            retorno.Columns.Add("Enviada");
            retorno.Columns[9].DataType = System.Type.GetType("System.Byte[]");
            foreach (DataRow r in consulta.Rows)
            {
                byte[] imagen = null;

                if (r.ItemArray[9].ToString() != string.Empty && (bool)r.ItemArray[9])
                {
                    imagen = (byte[])imagenEnviado.Rows[0][0];
                }

                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString(),
                    r.ItemArray[2].ToString(), r.ItemArray[3].ToString(), r.ItemArray[4].ToString(),
                    r.ItemArray[5].ToString(), r.ItemArray[6].ToString(), r.ItemArray[7].ToString(),
                    r.ItemArray[8].ToString(), imagen);
            }
            return retorno;
        }

        public Entidades.VisitasDomicilio cargarVisita(Guid idVisita)
        {
            Entidades.VisitasDomicilio retorno = new Entidades.VisitasDomicilio();
            DataTable datos = SQLConnector.obtenerTablaSegunConsultaString(@"select vl.id, vl.fechaHora, vl.idMotivo, vl.idEstadoAtencion, vl.domicilio, vl.entreCalle1,
            vl.entreCalle2, vl.localidad, l.pres, vl.medico, vl.observaciones, vl.idPaciente, p.apellido + ' ' + p.nombres,
            e.razonSocial, ete.tarea, e.id, vl.domicilioTransitorio, c.identificador, p.dni
            from dbo.VisitasLaboral vl
            inner join dbo.Paciente p on vl.idPaciente = p.id
            inner join dbo.Profesional prof on vl.medico = prof.id
            inner join dbo.Prestaciones l on vl.localidad = l.id
            inner join dbo.ConsultaLaboral cl on vl.id = cl.idVisitaLaboral
            inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
            inner join dbo.Empresa e on ete.idEmpresa = e.id
            inner join dbo.Consulta c on tep.idConsulta = c.id
            where vl.id = '" + idVisita.ToString() + "'");
            if (datos.Rows.Count > 0)
            {
                retorno.Id = new Guid(datos.Rows[0][0].ToString());
                retorno.FechaHora = Convert.ToDateTime(datos.Rows[0].ItemArray[1].ToString());
                retorno.IdMotivoConsulta = new Guid(datos.Rows[0][2].ToString());
                retorno.IdEstadoAtencion = new Guid(datos.Rows[0][3].ToString());
                retorno.Domicilio = datos.Rows[0][4].ToString();
                retorno.EntreCalle1 = datos.Rows[0][5].ToString();
                retorno.EntreCalle2 = datos.Rows[0][6].ToString();
                retorno.Localidad = new Guid(datos.Rows[0][7].ToString());
                retorno.LocalidadDescripcion = datos.Rows[0][8].ToString();
                retorno.Medico = new Guid(datos.Rows[0][9].ToString());
                retorno.Observaciones = datos.Rows[0][10].ToString();
                retorno.IdPaciente = new Guid(datos.Rows[0][11].ToString());
                retorno.Paciente = datos.Rows[0][12].ToString();
                retorno.Empresa = datos.Rows[0][13].ToString();
                retorno.Tarea = datos.Rows[0][14].ToString();
                retorno.IdEmpresa = new Guid(datos.Rows[0][15].ToString());
                retorno.DomicilioTransitorio = convertirBoolAInt(Convert.ToBoolean(datos.Rows[0].ItemArray[16].ToString()));
                retorno.Identificador = datos.Rows[0][17].ToString();
                retorno.DniPaciente = datos.Rows[0][18].ToString();
            }
            return retorno;
        }

        private int convertirBoolAInt(bool valor)
        {
            if (valor) { return 1; }
            return 0;
        }

        public DataTable cargarParametrosReporte(string idVisita)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Tipo");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Empresa");
            retorno.Columns.Add("DNI");
            retorno.Columns.Add("ApellidoNombre");
            retorno.Columns.Add("Direccion");
            retorno.Columns.Add("Localidad");
            retorno.Columns.Add("Observaciones");
            retorno.Columns.Add("EntreCalle1");
            retorno.Columns.Add("EntreCalle2");
            retorno.Columns.Add("NroVisita");
            retorno.Columns.Add("Médico");
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(@"
            select e.descripcionInformes, vl.fechaHora, emp.razonSocial,
            p.dni, p.apellido + ' ' + p.nombres, vl.domicilio, pres.pres,
            vl.observaciones, vl.entreCalle1, vl.entreCalle2,
            c.identificador, prof.apellido + ' ' + prof.nombres from dbo.VisitasLaboral vl
            inner join dbo.ConsultaLaboral cl on cl.idVisitaLaboral = vl.id
            inner join dbo.Paciente p on vl.idPaciente = p.id
            inner join dbo.TipoExamenDePaciente tep on tep.id = cl.idTipoExamen
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            inner join dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
            inner join dbo.Empresa emp on ete.idEmpresa = emp.id
            inner join dbo.Profesional prof on vl.medico = prof.id
            inner join dbo.Prestaciones pres on vl.localidad = pres.id
            inner join dbo.Consulta c on tep.idConsulta = c.id
            where vl.id = '" + idVisita + "'");
            foreach (DataRow r in tabla.Rows)
            {
                retorno.Rows.Add(r.ItemArray[0].ToString(), Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(),
                    r.ItemArray[2].ToString(),r.ItemArray[3].ToString(),r.ItemArray[4].ToString(),
                    r.ItemArray[5].ToString(),r.ItemArray[6].ToString(),r.ItemArray[7].ToString(),
                    r.ItemArray[8].ToString(), r.ItemArray[9].ToString(), r.ItemArray[10].ToString(), r.ItemArray[11].ToString());
            }
            return retorno;
        }

        public DataTable cargarDataSource()
        {
            DataTable configReporte = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ConfigReportes
            where tipoReporte = 3");
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Logo");
            retorno.Columns.Add("Firma");
            retorno.Columns.Add("PiePagina");
            retorno.Columns.Add("Profesional");
            retorno.Columns.Add("Matricula");
            retorno.Columns.Add("Cargo");
            retorno.Columns.Add("Foto");
            retorno.Columns.Add("LibroFolio");
            retorno.Columns[0].DataType = System.Type.GetType("System.Byte[]");
            retorno.Columns[1].DataType = System.Type.GetType("System.Byte[]");
            retorno.Columns[6].DataType = System.Type.GetType("System.Byte[]");
            if (configReporte.Rows.Count > 0)
            {
                retorno.Rows.Add(configReporte.Rows[0].ItemArray[1], configReporte.Rows[0].ItemArray[2],
                     configReporte.Rows[0].ItemArray[6], configReporte.Rows[0].ItemArray[3],
                     configReporte.Rows[0].ItemArray[4], configReporte.Rows[0].ItemArray[5],
                     null, configReporte.Rows[0].ItemArray[8]);
            }
            return retorno;
        }

        public void eliminarVisita(string idVisita)
        {
            DataTable datosIdAEliminar = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as IdConsulta,vl.id as IdVisita, cl.id as IdConsultaLaboral, 
            tep.id as IdTipoExamen from dbo.VisitasLaboral vl 
            inner join dbo.ConsultaLaboral cl on vl.id = cl.idVisitaLaboral
            inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join dbo.Consulta c on tep.idConsulta = c.id
            where vl.id = '" + idVisita + "'");
            if (datosIdAEliminar.Rows.Count > 0)
            {
                List<string> deleteById = SQLConnector.generarListaParaProcedure("@id");
                List<string> deleteByIdTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_Consulta_Delete", deleteById, new Guid(datosIdAEliminar.Rows[0][0].ToString()));
                SQLConnector.executeProcedure("sp_TipoExamenDePaciente_Delete", deleteById, new Guid(datosIdAEliminar.Rows[0][3].ToString()));
                SQLConnector.executeProcedure("sp_ItemsPorPaciente_Delete", deleteById, new Guid(datosIdAEliminar.Rows[0][3].ToString()));
                SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Delete", deleteByIdTipoExamen, new Guid(datosIdAEliminar.Rows[0][3].ToString()));
                SQLConnector.executeProcedure("sp_VisitasLaboral_Delete", deleteById, new Guid(datosIdAEliminar.Rows[0][1].ToString()));
                SQLConnector.executeProcedure("sp_ConsultaLaboral_Delete", deleteById, new Guid(datosIdAEliminar.Rows[0][2].ToString()));
            }
        }

        public void actualizarEnvio(string idVisita)
        {
            List<string> updateEnvio = SQLConnector.generarListaParaProcedure("@id");
            SQLConnector.executeProcedure("sp_VisitasLaboral_UpdateEnvio", updateEnvio, new Guid(idVisita));
        }
    }
}
