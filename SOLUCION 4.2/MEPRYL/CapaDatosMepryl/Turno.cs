using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;
using Entidades;

namespace CapaDatosMepryl
{
    public class Turno
    {
        string date;
        private CapaDatosMepryl.TipoExamen tipoExamen;
        private DataTable usuarios;
        private Configuracion config;
        private bool blnInfantilInicial = false;

        public Turno()
        {
            tipoExamen = new TipoExamen();
            config = new Configuracion();
            cargarUsuarios();
        }

        public void EsInfantilInicial(string strTipoExamen)
        {
            if (strTipoExamen == "INFANTIL INICIAL")
                blnInfantilInicial = true;
            else
                blnInfantilInicial = false;
        }

        private void cargarUsuarios()
        {
            usuarios = SQLConnector.obtenerTablaSegunConsultaString("select id, username from dbo.Usuario");
        }

        public DataTable cargarTiposDeExamen()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Descripcion");
            retorno.Rows.Add(Guid.Empty.ToString(), "TODOS");
            DataTable tiposDeExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select id, 
            descripcion from dbo.Especialidad order by CONVERT(int,codigo)");
            foreach (DataRow r in tiposDeExamen.Rows)
            {
                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString());
            }
            return retorno;
        }

        public DataTable cargarTurnos(Guid tipoExamen, DateTime fecha, string hora, string estado)
        {
            string filtroTipoExamen = string.Empty;
            if (tipoExamen != Guid.Empty)
            {
                filtroTipoExamen = " and (te.id = '" + tipoExamen.ToString() + "' OR tePadre.id = '" + tipoExamen.ToString() + "')";
            }

            string filtroHora = string.Empty;
            if (hora != string.Empty)
            {
                string horaInicio = Convert.ToDateTime(hora).ToString("HH:mm");
                string horaFin = Convert.ToDateTime(hora).AddHours(1).ToString("HH:mm");
                filtroHora = " and (t.horaReferencia >= '" + horaInicio + "' and t.horaReferencia < '" + horaFin + "')";
            }

            string filtroEstado = string.Empty;
            if (estado != string.Empty)
            {
                filtroEstado = " and e.descripcion = '" + estado + "'";
            }

            date = fecha.ToShortDateString();

            DataTable turnos = SQLConnector.obtenerTablaSegunConsultaString(@"
        SELECT 
            t.id as Id,
            ISNULL(tePadre.descripcion, te.descripcion) as TipoPadre,
            te.descripcion as SubTipo,
            p.apellido + ' ' + p.nombres as Profesional,
            t.fecha as Fecha,
            t.horaReferencia as Hora,
            CONVERT(numeric, t.nroOrden) as Nro,
            t.pacienteID as idPaciente,
            t.codigo as Codigo,
            t.reserva as Reserva,
            t.usuarioID as Usuario,
            t.bloqueado as Bloqueado,
            t.asistio as Asistio,
            t.reservado as Reservado,
            tep.id as IdTipoExamen,
            t.habilitado as Habilitado,
            t.estadoID as IdEstado,
            te.id as IdSubtipo,
            ISNULL(tePadre.id, te.id) as IdPadre
        FROM dbo.Turno t
        INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
        INNER JOIN dbo.Horario h ON t.horarioID = h.id
        INNER JOIN dbo.Profesional p ON h.profesionalID = p.id
        LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
        LEFT JOIN dbo.Especialidad te ON h.especialidadID = te.id
        LEFT JOIN dbo.Especialidad tePadre ON te.IdPadre = tePadre.id AND te.Padre = 0
        WHERE convert(date, t.fecha) = convert(date, '" + fecha.ToShortDateString() + "', 105) "
                + filtroTipoExamen + filtroHora + filtroEstado +
                " ORDER BY t.fecha, t.hora");

            return generarTablaRetornoTurno(turnos);
        }
        private DataTable generarTablaRetornoTurno(DataTable turnos)
        {
            try
            {
                DataTable retorno = new DataTable();
                retorno.Columns.Add("Id");
                retorno.Columns.Add("TipoPadre");      // ✅ NUEVO
                retorno.Columns.Add("SubTipo");        // ✅ NUEVO
                retorno.Columns.Add("Profesional");
                retorno.Columns.Add("Fecha");
                retorno.Columns.Add("Hora");
                retorno.Columns.Add("Nro");
                retorno.Columns.Add("IdPaciente");
                retorno.Columns.Add("Dni");
                retorno.Columns.Add("Paciente");
                retorno.Columns.Add("Categoria");
                retorno.Columns.Add("Codigo");
                retorno.Columns.Add("Reserva");
                retorno.Columns.Add("Usuario");
                retorno.Columns.Add("Bloqueado");
                retorno.Columns.Add("Asistio");
                retorno.Columns.Add("Reservado");
                retorno.Columns.Add("IdTipoExamen");
                retorno.Columns.Add("Estado");
                retorno.Columns.Add("IdPadre");        // ✅ NUEVO
                retorno.Columns.Add("IdSubtipo");      // ✅ NUEVO

                foreach (DataRow r in turnos.Rows)
                {
                    string paciente = string.Empty;
                    string dni = string.Empty;
                    string categoria = string.Empty;
                    string estado = string.Empty;

                    if (r.ItemArray[16].ToString() == "8f85032b-b03d-406d-a050-a9436aed0703")
                    {
                        if (r.ItemArray[7].ToString() != "00000000-0000-0000-0000-000000000000")
                        {
                            DataRow dr = cargarDatoPaciente(r.ItemArray[7].ToString());
                            dni = dr.ItemArray[0].ToString();
                            paciente = dr.ItemArray[1].ToString();
                            if (dr.ItemArray.Length > 2) { categoria = dr.ItemArray[2].ToString(); }
                        }
                        estado = "2";
                    }
                    else if (Convert.ToBoolean(r.ItemArray[11].ToString()))
                    {
                        estado = "3";
                    }
                    else if (r.ItemArray[13].ToString() == "1")
                    {
                        estado = "4";
                    }
                    else if (r.ItemArray[15].ToString() == "0")
                    {
                        estado = "5";
                    }
                    else
                    {
                        estado = "1";
                    }

                    retorno.Rows.Add(
                        r.ItemArray[0].ToString(),      // Id
                        r.ItemArray[1].ToString(),      // TipoPadre ✅
                        r.ItemArray[2].ToString(),      // SubTipo ✅
                        r.ItemArray[3].ToString(),      // Profesional
                        Convert.ToDateTime(r.ItemArray[4].ToString()).ToShortDateString(), // Fecha
                        r.ItemArray[5].ToString(),      // Hora
                        r.ItemArray[6].ToString(),      // Nro
                        r.ItemArray[7].ToString(),      // IdPaciente
                        dni,
                        paciente,
                        categoria,
                        r.ItemArray[8].ToString(),      // Codigo
                        r.ItemArray[9].ToString(),      // Reserva
                        obtenerUsuario(r.ItemArray[10].ToString()), // Usuario
                        r.ItemArray[11].ToString(),     // Bloqueado
                        r.ItemArray[12].ToString(),     // Asistio
                        r.ItemArray[13].ToString(),     // Reservado
                        r.ItemArray[14].ToString(),     // IdTipoExamen
                        estado,
                        r.ItemArray[18].ToString(),     // IdPadre ✅
                        r.ItemArray[17].ToString()      // IdSubtipo ✅
                    );
                }
                return retorno;
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        private DataRow cargarDatoPaciente(string idPaciente)
        {
            DataRow drFilaRetorno;

            try
            {
                DataTable pacientePreventiva = SQLConnector.obtenerTablaSegunConsultaString(@"
                    select p.dni, p.apellido + ' ' + p.nombres as Paciente, YEAR(p.fechaNacimiento) as Categoria
                    from dbo.Paciente p
                    where p.id = '" + idPaciente + "'");
                if (pacientePreventiva.Rows.Count > 0)
                {
                    //return pacientePreventiva.Rows[0];
                    drFilaRetorno = pacientePreventiva.Rows[0];
                    return drFilaRetorno;
                }
                //else
                //{
                DataTable pacienteLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"
                        select p.dni, p.apellido + ' ' + p.nombres as Paciente
                        from dbo.PacienteLaboral p
                        where p.id = '" + idPaciente + "'");
                // return pacienteLaboral.Rows[0];
                if (pacienteLaboral.Rows.Count > 0)
                {
                    drFilaRetorno = pacienteLaboral.Rows[0];
                    return drFilaRetorno;
                }
                //}

                return null;
            }
            catch (System.IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        private string obtenerUsuario(string id)
        {
            DataRow[] usuario = usuarios.Select("id = '" + id + "'");
            if (usuario.Length > 0) { return usuario[0][1].ToString().ToUpper(); }
            return string.Empty;
        }

        public char verificarTipoPaciente(Guid idPaciente)
        {
            DataTable pacientePreventiva = SQLConnector.obtenerTablaSegunConsultaString(@"
                    select *
                    from dbo.Paciente p
                    where p.id = '" + idPaciente + "'");
            if (pacientePreventiva.Rows.Count > 0)
            {
                return 'P';
            }
            else
            {
                return 'L';
            }
        }

        public Entidades.TurnoPreventiva cargarTurnoPacientePreventiva(Guid idTurno)
        {
            PacientePreventiva PacientePre = new PacientePreventiva(); //GRV - Modificado
            bool blnRealizaRX = false;                                 //GRV - Modificado
            Entidades.TurnoPreventiva retorno = new TurnoPreventiva();
            DataTable infoTurno = cargarTablaInformacionTurno(idTurno);
            if (infoTurno.Rows.Count > 0)
            {
                retorno.Id = new Guid(infoTurno.Rows[0][0].ToString());
                retorno.Observaciones = infoTurno.Rows[0][2].ToString();
                if (infoTurno.Rows[0].ItemArray[6].ToString() == "1")
                {
                    retorno.FacturaClub = true;
                }
                retorno.IdTipoExamen = new Guid(infoTurno.Rows[0][3].ToString());
                retorno.IdPaciente = new Guid(infoTurno.Rows[0][1].ToString());
                // GRV - Modificado
                retorno.TipoExamen = tipoExamen.cargarEstudiosPorExamen(infoTurno.Rows[0][3].ToString());
                DataTable infoPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id, 
                apellido + ' ' + nombres, fechaNacimiento, telefonos, celular, dni, Email from dbo.Paciente
                where id = '" + infoTurno.Rows[0][1].ToString() + "'");
                if (infoPaciente.Rows.Count > 0)
                {
                    retorno.Dni = infoPaciente.Rows[0][5].ToString();
                    retorno.ApellidoNombre = infoPaciente.Rows[0][1].ToString();
                    if (infoPaciente.Rows[0][2].ToString() != string.Empty)
                    {
                        retorno.Nacimiento = Convert.ToDateTime(infoPaciente.Rows[0][2].ToString());
                    }
                    retorno.Telefono = infoPaciente.Rows[0][3].ToString() + " " + infoPaciente.Rows[0][4].ToString();
                    DataTable ligaYClub = SQLConnector.obtenerTablaSegunConsultaString(@"select l.id as IdLiga, 
                    l.imagen as Liga, c.id as IdClub, c.descripcion as Club 
                    from dbo.clubesPorTipoExamen cte inner join dbo.Club c on cte.idClub = c.id
                    inner join dbo.Liga l on c.ligaID = l.id
                    where cte.idTipoExamen = '" + retorno.IdTipoExamen.ToString() + "'");
                    retorno.LigaClub = ligaYClub;
                    retorno.Mail = infoPaciente.Rows[0][6].ToString();
                }
                //GRV - Modificado
                //blnRealizaRX = PacientePre.DebeRealizarExamenRX(retorno.Dni.ToString());
                ////tipoExamen.VerificaExamenPreventiva(blnRealizaRX, infoTurno.Rows[0][3].ToString());
                //tipoExamen.blnTieneRX = blnRealizaRX;
                retorno.TipoExamen = tipoExamen.cargarEstudiosPorExamen(infoTurno.Rows[0][3].ToString());

            }
            return retorno;
        }

        public DataTable cargarTablaInformacionTurno(Guid idTurno)
        {
            // Consulta normalizada: prioriza TipoExamenDePaciente y solo toma la descripción de Especialidad si es necesario
            return SQLConnector.obtenerTablaSegunConsultaString(@"SELECT 
                t.id, 
                t.pacienteID, 
                t.observaciones, 
                tep.id AS idTipoExamenDePaciente, 
                tep.idEspecialidad, 
                tep.modificado, 
                tep.factClub, 
                tep.precioExamen, 
                e.descripcion AS descripcionEspecialidad
            FROM dbo.Turno t 
            INNER JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
            LEFT JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
            WHERE t.id = '" + idTurno + "'");
        }

        public DataTable cargarTablaInformacionTurnoSinAsignar(Guid idTurno)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select t.id, 
            e.descripcion, e.id
            from dbo.Turno t 
            inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            where t.id = '" + idTurno + "'");
        }

        public Entidades.TurnoLaboral cargarTurnoPacienteLaboral(Guid idTurno)
        {
            Entidades.TurnoLaboral retorno = new TurnoLaboral();
            DataTable infoTurno = cargarTablaInformacionTurno(idTurno);
            string strFechaNac = "";

            //try
            //{
            if (infoTurno.Rows.Count > 0)
            {
                retorno.Id = new Guid(infoTurno.Rows[0][0].ToString());
                retorno.Observaciones = infoTurno.Rows[0][2].ToString();
                retorno.IdTipoExamen = new Guid(infoTurno.Rows[0][3].ToString());
                if (infoTurno.Rows[0].ItemArray[6].ToString() == "1")
                {
                    retorno.FacturaEmpresa = true;
                }
                retorno.IdPaciente = new Guid(infoTurno.Rows[0][1].ToString());
                retorno.TipoExamen = tipoExamen.cargarEstudiosPorExamen(infoTurno.Rows[0][3].ToString());
                DataTable infoPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id, 
                apellido + ' ' + nombres, telefonos, celular, dni, cuil, mail, fechaNacimiento from dbo.PacienteLaboral
                where id = '" + infoTurno.Rows[0][1].ToString() + "'");
                if (infoPaciente.Rows.Count > 0)
                {
                    retorno.Dni = infoPaciente.Rows[0][4].ToString();
                    retorno.Cuil = infoPaciente.Rows[0][5].ToString();
                    retorno.ApellidoNombre = infoPaciente.Rows[0][1].ToString();
                    retorno.Email = infoPaciente.Rows[0][6].ToString();
                    strFechaNac = infoPaciente.Rows[0][7].ToString();
                    if (!string.IsNullOrEmpty(strFechaNac))
                        retorno.FechaNacimiento = Convert.ToDateTime(infoPaciente.Rows[0][7].ToString());
                    else
                        retorno.FechaNacimiento = Convert.ToDateTime("01/01/0001");
                    retorno.Telefono = infoPaciente.Rows[0][2].ToString() + " " + infoPaciente.Rows[0][3].ToString();
                    DataTable empresaYTarea = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial, ete.tarea
                    from dbo.empresaPorTipoDeExamen ete inner join dbo.Empresa e on ete.idEmpresa = e.id
                    where ete.idTipoExamen = '" + retorno.IdTipoExamen.ToString() + "'");
                    if (empresaYTarea.Rows.Count > 0)
                    {
                        retorno.IdEmpresa = new Guid(empresaYTarea.Rows[0][0].ToString());
                        retorno.Empresa = empresaYTarea.Rows[0][1].ToString();
                        retorno.Tarea = empresaYTarea.Rows[0][2].ToString();
                    }
                }

            }
            //}
            //catch(System.FormatException ex)
            //{
            //    //
            //}

            return retorno;
        }

        public char verificarTipoTurno(Guid idTurno)
        {
            DataTable motivoConsulta = SQLConnector.obtenerTablaSegunConsultaString(@"select mc.nombre from dbo.Turno t 
            inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id 
            inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            where t.id = '" + idTurno.ToString() + "'");
            if (motivoConsulta.Rows.Count > 0)
            {
                if (motivoConsulta.Rows[0].ItemArray[0].ToString() == "LABORAL")
                {
                    return 'L';
                }
                if (motivoConsulta.Rows[0].ItemArray[0].ToString() == "PREVENTIVA")
                {
                    return 'P';
                }
            }

            // INICIO GRV - Ramírez - verificar la tabla EmpresasPorPaciente, si el idPaciente existe en esta tabla es laboral

            DataTable motivoConsulta01 = SQLConnector.obtenerTablaSegunConsultaString(@"select t.consulta from dbo.Turno t 
            inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id 
            inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            where t.id = '" + idTurno.ToString() + "'");

            if (motivoConsulta01.Rows.Count > 0)
            {
                if (motivoConsulta01.Rows[0].ItemArray[0].ToString() == "LABORAL")
                {
                    return 'L';
                }
                if (motivoConsulta01.Rows[0].ItemArray[0].ToString() == "PREVENTIVA")
                {
                    return 'P';
                }
            }
            // FIN

            return '*';
        }

        public Entidades.TurnoPreventiva nuevoTurnoPacientePreventiva(string idPaciente, string idTurno)
        {
            bool blnDebeRealizarRX = false;
            PacientePreventiva PacientePre = new PacientePreventiva();
            Entidades.TurnoPreventiva retorno = new TurnoPreventiva();
            DataTable infoTurno = cargarTablaInformacionTurnoSinAsignar(new Guid(idTurno));
            if (infoTurno.Rows.Count > 0)
            {
                retorno.Id = new Guid(infoTurno.Rows[0][0].ToString());
                retorno.IdTipoExamen = new Guid(infoTurno.Rows[0][2].ToString());
                // GRV - Modificado
                //retorno.TipoExamen = tipoExamen.cargarEstudiosPorTipoExamen(retorno.IdTipoExamen.ToString());
                DataTable infoPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id, 
                apellido + ' ' + nombres, fechaNacimiento, telefonos, celular, dni from dbo.Paciente
                where id = '" + idPaciente + "'");
                if (infoPaciente.Rows.Count > 0)
                {
                    retorno.IdPaciente = new Guid(infoPaciente.Rows[0][0].ToString());
                    retorno.Dni = infoPaciente.Rows[0][5].ToString();
                    retorno.ApellidoNombre = infoPaciente.Rows[0][1].ToString();
                    if (infoPaciente.Rows[0][2].ToString() != string.Empty)
                    {
                        retorno.Nacimiento = Convert.ToDateTime(infoPaciente.Rows[0][2].ToString());
                    }
                    retorno.Telefono = infoPaciente.Rows[0][3].ToString() + " " + infoPaciente.Rows[0][4].ToString();
                    DataTable ligaYClub = SQLConnector.obtenerTablaSegunConsultaString(@"select l.id as IdLiga, 
                    l.imagen as Liga, c.id as IdClub, c.descripcion as Club 
                    from dbo.clubesPorPaciente cte inner join dbo.Club c on cte.club = c.id
                    inner join dbo.Liga l on c.ligaID = l.id
                    where cte.paciente = '" + retorno.IdPaciente.ToString() + "'");
                    retorno.LigaClub = ligaYClub;
                }

                // GRV - Modificado
                if (blnInfantilInicial == false)
                {
                    blnDebeRealizarRX = PacientePre.DebeRealizarExamenRX(retorno.Dni.ToString());
                    tipoExamen.blnTieneRX = blnDebeRealizarRX;
                }
                retorno.TipoExamen = tipoExamen.cargarEstudiosPorTipoExamen(retorno.IdTipoExamen.ToString());
                if (blnInfantilInicial == false)
                {
                    retorno.TipoExamen.Modificado = !blnDebeRealizarRX;
                }
            }
            tipoExamen.blnTieneRX = true;
            return retorno;
        }

        public Entidades.TurnoLaboral nuevoTurnoPacienteLaboral(string idPaciente, string idTurno, string idEmpresa)
        {
            Entidades.TurnoLaboral retorno = new TurnoLaboral();
            DataTable infoTurno = cargarTablaInformacionTurnoSinAsignar(new Guid(idTurno));
            string strFechaNac = "";

            if (infoTurno.Rows.Count > 0)
            {
                retorno.Id = new Guid(infoTurno.Rows[0][0].ToString());
                retorno.IdTipoExamen = new Guid(infoTurno.Rows[0][2].ToString());
                // GRV - Modificado
                //retorno.TipoExamen = tipoExamen.cargarEstudiosPorTipoExamen(retorno.IdTipoExamen.ToString());
                retorno.TipoExamen = tipoExamen.cargarEstudiosPorTipoExamen(retorno.IdTipoExamen.ToString());
                DataTable infoPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id, 
                apellido + ' ' + nombres, telefonos, celular, dni, cuil, mail, fechaNacimiento from dbo.PacienteLaboral
                where id = '" + idPaciente + "'");
                if (infoPaciente.Rows.Count > 0)
                {
                    retorno.IdPaciente = new Guid(infoPaciente.Rows[0][0].ToString());
                    retorno.Dni = infoPaciente.Rows[0][4].ToString();
                    retorno.Cuil = infoPaciente.Rows[0][5].ToString();
                    retorno.ApellidoNombre = infoPaciente.Rows[0][1].ToString();
                    retorno.Telefono = infoPaciente.Rows[0][2].ToString() + " " + infoPaciente.Rows[0][3].ToString();
                    retorno.Email = infoPaciente.Rows[0][6].ToString();
                    strFechaNac = infoPaciente.Rows[0][7].ToString();
                    if (!string.IsNullOrEmpty(strFechaNac))
                        retorno.FechaNacimiento = Convert.ToDateTime(infoPaciente.Rows[0][7].ToString());
                    else
                        retorno.FechaNacimiento = Convert.ToDateTime("01/01/0001");
                    DataTable empresaYTarea = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial, epp.tarea from dbo.EmpresasPorPaciente
                    epp inner join dbo.Empresa e on epp.idEmpresa = e.id where epp.idEmpresa = '" + idEmpresa + @"' 
                    and epp.idPaciente = '" + idPaciente + "'");
                    if (empresaYTarea.Rows.Count > 0)
                    {
                        retorno.IdEmpresa = new Guid(empresaYTarea.Rows[0][0].ToString());
                        retorno.Empresa = empresaYTarea.Rows[0][1].ToString();
                        retorno.Tarea = empresaYTarea.Rows[0][2].ToString();
                    }
                }
            }
            return retorno;
        }

        public Entidades.Resultado asignarTurnoPacienteLaboralVentanillaMesaEntrada(string idPaciente, string idTurno, string idEmpresa)
        {
            Entidades.TurnoLaboral entidad = new TurnoLaboral();
            entidad.Id = new Guid(idTurno);
            entidad.IdPaciente = new Guid(idPaciente);
            entidad.IdEmpresa = new Guid(idEmpresa);
            DataTable infoTipoExamenTurno = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.precioBase from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            where t.id = '" + idTurno + "'");
            entidad.TipoExamen.Id = new Guid(infoTipoExamenTurno.Rows[0][0].ToString());
            entidad.TipoExamen.PrecioBase = Convert.ToDouble(infoTipoExamenTurno.Rows[0][1].ToString());
            DataTable tareaPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select tarea 
            from dbo.EmpresasPorPaciente where idPaciente = '" + idPaciente + "' and idEmpresa = '" + idEmpresa + "'");
            entidad.Tarea = tareaPaciente.Rows[0][0].ToString();
            updateReserva(entidad.Id, "0", null); //GRV - Modificado
            //updateReserva(entidad.Id, "0", entidad.TipoExamen.Id.ToString(), null);
            entidad.TipoExamen.Clinico = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Clinico;
            entidad.TipoExamen.Hematologia = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Hematologia;
            entidad.TipoExamen.QuimicaHematica = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).QuimicaHematica;
            entidad.TipoExamen.Serologia = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Serologia;
            entidad.TipoExamen.PerfilLipidico = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).PerfilLipidico;
            entidad.TipoExamen.Bacteriologia = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Bacteriologia;
            entidad.TipoExamen.Orina = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Orina;
            entidad.TipoExamen.LaboralesBasicas = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).LaboralesBasicas;
            entidad.TipoExamen.CraneoYMSuperior = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).CraneoYMSuperior;
            entidad.TipoExamen.TroncoYPelvis = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).TroncoYPelvis;
            entidad.TipoExamen.MiembroInferior = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).MiembroInferior;
            entidad.TipoExamen.EstComplementarios = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).EstComplementarios;
            return generarNuevoTurnoPacienteLaboral(entidad);
        }

        public Entidades.Resultado generarNuevoTurnoPacienteLaboral(Entidades.TurnoLaboral entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> listAddTipoExamen = SQLConnector.generarListaParaProcedure("@idConsulta", "@idTurno", "@modificado",
                "@idEspecialidad", "@importe", "@factClub");
                string idTipoExamen = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", listAddTipoExamen, Guid.Empty, entidad.Id,
                examenModificado(entidad.TipoExamen.Modificado), entidad.TipoExamen.Id, entidad.TipoExamen.PrecioBase,
                facturaClubEmpresa(entidad.FacturaEmpresa));
                entidad.TipoExamen.IdTipoExamenPaciente = new Guid(idTipoExamen);
                List<string> listAddEmpresaPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idEmpresa", "@tarea");
                SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Add", listAddEmpresaPorTipoExamen, new Guid(idTipoExamen),
                entidad.IdEmpresa, entidad.Tarea);
                // GRV - Ramírez - guardar consulta
                // List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones");
                // SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones);
                List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones", "@consulta");
                SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones, entidad.Consulta);
                tipoExamen.crearEstudiosPorExamen(entidad.TipoExamen);
                List<string> updateIdPacienteTurno = SQLConnector.generarListaParaProcedure("@id", "@idPaciente");
                SQLConnector.executeProcedure("sp_Turno_UpdateIdPaciente", updateIdPacienteTurno, entidad.Id, entidad.IdPaciente);
                List<string> updateEstadoTurnoAsignado = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_Turno_UpdateEstadoAsignado", updateEstadoTurnoAsignado, entidad.Id);
                List<string> updateUsuario = SQLConnector.generarListaParaProcedure("@idTurno", "@idUsuario");
                SQLConnector.executeProcedure("sp_Turno_UpdateUsuario", updateUsuario, entidad.Id, new Guid(Configuracion.usuario.id));
                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }

        public Entidades.Resultado asignarTurnoPacientePreventivaVentanillaMesaEntrada(string idPaciente, string idTurno)
        {
            Entidades.TurnoPreventiva entidad = new TurnoPreventiva();
            entidad.Id = new Guid(idTurno);
            entidad.IdPaciente = new Guid(idPaciente);
            DataTable infoTipoExamenTurno = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.precioBase from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            where t.id = '" + idTurno + "'");
            entidad.TipoExamen.Id = new Guid(infoTipoExamenTurno.Rows[0][0].ToString());
            entidad.TipoExamen.PrecioBase = Convert.ToDouble(infoTipoExamenTurno.Rows[0][1].ToString());
            entidad.LigaClub = SQLConnector.obtenerTablaSegunConsultaString(@"select l.id, l.descripcion,
            c.id, c.descripcion from dbo.clubesPorPaciente cpp inner join dbo.Club c on cpp.club = c.id
            inner join dbo.Liga l on c.ligaID = l.id where cpp.paciente = '" + idPaciente + "'");
            updateReserva(entidad.Id, "0", null); // GRV - Modificado
            //updateReserva(entidad.Id, "0", entidad.TipoExamen.Id.ToString(), null);
            entidad.TipoExamen.Clinico = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Clinico;
            entidad.TipoExamen.Hematologia = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Hematologia;
            entidad.TipoExamen.QuimicaHematica = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).QuimicaHematica;
            entidad.TipoExamen.Serologia = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Serologia;
            entidad.TipoExamen.PerfilLipidico = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).PerfilLipidico;
            entidad.TipoExamen.Bacteriologia = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Bacteriologia;
            entidad.TipoExamen.Orina = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).Orina;
            entidad.TipoExamen.LaboralesBasicas = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).LaboralesBasicas;
            entidad.TipoExamen.CraneoYMSuperior = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).CraneoYMSuperior;
            entidad.TipoExamen.TroncoYPelvis = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).TroncoYPelvis;
            entidad.TipoExamen.MiembroInferior = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).MiembroInferior;
            entidad.TipoExamen.EstComplementarios = tipoExamen.cargarEstudiosPorTipoExamen(entidad.TipoExamen.Id.ToString()).EstComplementarios;
            return generarNuevoTurnoPacientePreventiva(entidad);
        }

        public Entidades.Resultado generarNuevoTurnoPacientePreventiva(Entidades.TurnoPreventiva entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            PacientePreventiva PacientePre = new PacientePreventiva();
            string strSQL = "";

            strSQL = "SELECT TOP 10 idTurno FROM dbo.TipoExamenDePaciente te WHERE te.idTurno = '" + entidad.Id + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            try
            {
                if (dtConsulta.Rows.Count < 1)
                {
                    //entidad.TipoExamen.Modificado = !PacientePre.DebeRealizarExamenRX(DNIPaciente(entidad.IdPaciente.ToString()));

                    List<string> listAddTipoExamen = SQLConnector.generarListaParaProcedure("@idConsulta", "@idTurno", "@modificado",
                    "@idEspecialidad", "@importe", "@factClub");
                    string idTipoExamen = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", listAddTipoExamen, Guid.Empty, entidad.Id,
                    examenModificado(entidad.TipoExamen.Modificado), entidad.TipoExamen.Id, entidad.TipoExamen.PrecioBase,
                    facturaClubEmpresa(entidad.FacturaClub));
                    entidad.TipoExamen.IdTipoExamenPaciente = new Guid(idTipoExamen);
                    List<string> listAddClubPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                    foreach (DataRow r in entidad.LigaClub.Rows)
                    {
                        SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", listAddClubPorTipoExamen,
                            entidad.TipoExamen.IdTipoExamenPaciente, new Guid(r.ItemArray[2].ToString()));
                    }
                    // GRV - Ramírez - grabar consulta
                    // List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones");
                    // SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones);
                    List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones", "@consulta");
                    SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones, entidad.Consulta);
                    tipoExamen.crearEstudiosPorExamen(entidad.TipoExamen);
                    List<string> updateIdPacienteTurno = SQLConnector.generarListaParaProcedure("@id", "@idPaciente");
                    SQLConnector.executeProcedure("sp_Turno_UpdateIdPaciente", updateIdPacienteTurno, entidad.Id, entidad.IdPaciente);
                    List<string> updateEstadoTurnoAsignado = SQLConnector.generarListaParaProcedure("@id");
                    SQLConnector.executeProcedure("sp_Turno_UpdateEstadoAsignado", updateEstadoTurnoAsignado, entidad.Id);
                    List<string> updateUsuario = SQLConnector.generarListaParaProcedure("@idTurno", "@idUsuario");
                    SQLConnector.executeProcedure("sp_Turno_UpdateUsuario", updateUsuario, entidad.Id, new Guid(Configuracion.usuario.id));
                    retorno.Modo = 1;
                    return retorno;
                }
                else
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = "El paciente ya tiene un turno asignado";
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }

        public Entidades.Resultado modificarTurnoPreventiva(Entidades.TurnoPreventiva entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                tipoExamen.actualizarEstudiosPorExamen(entidad.TipoExamen);
                List<string> listUpdateTipoExamen = SQLConnector.generarListaParaProcedure("@idTurno", "@valor",
                "@importe", "@factClub");
                SQLConnector.executeProcedure("sp_TipoExamenDePaciente_Update", listUpdateTipoExamen, entidad.Id,
                examenModificado(entidad.TipoExamen.Modificado), entidad.TipoExamen.PrecioBase,
                facturaClubEmpresa(entidad.FacturaClub));
                List<string> deleteClubesPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Delete", deleteClubesPorTipoExamen,
                    entidad.TipoExamen.IdTipoExamenPaciente);
                List<string> addClubesPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                foreach (DataRow r in entidad.LigaClub.Rows)
                {
                    SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", addClubesPorTipoExamen,
                        entidad.TipoExamen.IdTipoExamenPaciente, new Guid(r.ItemArray[2].ToString()));
                }
                // GRV - Ramírez - 
                //List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones");
                //SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones);
                List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones", "@consulta");
                SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones, entidad.Consulta);
                List<string> updateUsuario = SQLConnector.generarListaParaProcedure("@idTurno", "@idUsuario");
                SQLConnector.executeProcedure("sp_Turno_UpdateUsuario", updateUsuario, entidad.Id, new Guid(Configuracion.usuario.id));
                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }

        public Entidades.Resultado modificarTurnoLaboral(Entidades.TurnoLaboral entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                tipoExamen.actualizarEstudiosPorExamen(entidad.TipoExamen);
                List<string> listUpdateTipoExamen = SQLConnector.generarListaParaProcedure("@idTurno", "@valor",
                "@importe", "@factClub");
                SQLConnector.executeProcedure("sp_TipoExamenDePaciente_Update", listUpdateTipoExamen, entidad.Id,
                examenModificado(entidad.TipoExamen.Modificado), entidad.TipoExamen.PrecioBase,
                facturaClubEmpresa(entidad.FacturaEmpresa));
                List<string> listUpdateEmpresaPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idEmpresa", "@tarea");
                SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Update", listUpdateEmpresaPorTipoExamen,
                entidad.TipoExamen.IdTipoExamenPaciente, entidad.IdEmpresa, entidad.Tarea);
                // GRV - Ramírez
                //List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones");
                //SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones);
                List<string> updateObservaciones = SQLConnector.generarListaParaProcedure("@idTurno", "@observaciones", "@consulta");
                SQLConnector.executeProcedure("sp_Turno_UpdateObservaciones", updateObservaciones, entidad.Id, entidad.Observaciones, entidad.Consulta);
                List<string> updateUsuario = SQLConnector.generarListaParaProcedure("@idTurno", "@idUsuario");
                SQLConnector.executeProcedure("sp_Turno_UpdateUsuario", updateUsuario, entidad.Id, new Guid(Configuracion.usuario.id));
                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }

        private object examenModificado(bool estado)
        {
            if (estado)
            {
                return "(*)";
            }
            return null;
        }

        private string facturaClubEmpresa(bool estado)
        {
            if (estado)
            {
                return "1";
            }
            return "0";
        }

        public Entidades.Resultado liberarTurnoPreventiva(Entidades.TurnoPreventiva entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                liberarTurno(entidad.Id);

                // 1. Eliminar primero los ítems hijos
                tipoExamen.eliminarEstudiosPorExamen(entidad.TipoExamen.IdTipoExamenPaciente);

                // 2. Luego eliminar el registro padre
                tipoExamen.eliminarTipoExamenPaciente(entidad.Id, entidad.TipoExamen.IdTipoExamenPaciente);

                // 3. Eliminar clubes si corresponde
                tipoExamen.eliminarClubesPorExamen(entidad.TipoExamen.IdTipoExamenPaciente);

                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }
        public void EliminarTipoExamenConDependencias(Guid idTipoExamen)
        {
            // Elimina los hijos primero
            SQLConnector.obtenerTablaSegunConsultaString($"DELETE FROM EstudiosPorExamenItem WHERE idTipoExamen = '{idTipoExamen}'");

            // Elimina el padre después
            SQLConnector.obtenerTablaSegunConsultaString($"DELETE FROM TipoExamen WHERE id = '{idTipoExamen}'");
        }
        public Entidades.Resultado liberarTurnoLaboral(Entidades.TurnoLaboral entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                liberarTurno(entidad.Id);

                // 1. Eliminar primero los ítems hijos
                tipoExamen.eliminarEstudiosPorExamen(entidad.TipoExamen.IdTipoExamenPaciente);

                // 2. Luego eliminar el registro padre
                tipoExamen.eliminarTipoExamenPaciente(entidad.Id, entidad.TipoExamen.IdTipoExamenPaciente);

                // 3. Eliminar empresas si corresponde
                tipoExamen.eliminarEmpresaPorExamen(entidad.TipoExamen.IdTipoExamenPaciente);

                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }

        }

        private void liberarTurno(Guid idTurno)
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@id");
            SQLConnector.executeProcedure("sp_Turno_UpdateEstadoLibre", lista, idTurno);
            List<string> updateUsuario = SQLConnector.generarListaParaProcedure("@idTurno", "@idUsuario");
            SQLConnector.executeProcedure("sp_Turno_UpdateUsuario", updateUsuario, idTurno, Guid.Empty);
        }

        public void habilitarTurno(Guid idTurno)
        {
            cambiarHabilitacionTurno(idTurno, 0);
        }

        public void inhabilitarTurno(Guid idTurno)
        {
            cambiarHabilitacionTurno(idTurno, 1);
        }

        private void cambiarHabilitacionTurno(Guid idTurno, int estado)
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@idTurno", "@habilitado");
            SQLConnector.executeProcedure("sp_Turno_CambiarEstadoHabilitado", lista, idTurno, estado);
        }

        public Entidades.TurnoPreventiva recargarDatoPacientePreventiva(string idPaciente)
        {
            TurnoPreventiva retorno = new TurnoPreventiva();
            DataTable infoPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id, 
                apellido + ' ' + nombres, fechaNacimiento, telefonos, celular, dni, Email from dbo.Paciente
                where id = '" + idPaciente + "'");
            if (infoPaciente.Rows.Count > 0)
            {
                retorno.Dni = infoPaciente.Rows[0][5].ToString();
                retorno.ApellidoNombre = infoPaciente.Rows[0][1].ToString();
                if (infoPaciente.Rows[0][2].ToString() != string.Empty)
                {
                    retorno.Nacimiento = Convert.ToDateTime(infoPaciente.Rows[0][2].ToString());
                }
                retorno.Telefono = infoPaciente.Rows[0][3].ToString() + " " + infoPaciente.Rows[0][4].ToString();
                DataTable ligaYClub = SQLConnector.obtenerTablaSegunConsultaString(@"select l.id as IdLiga, 
                    l.imagen as Liga, c.id as IdClub, c.descripcion as Club 
                    from dbo.clubesPorPaciente cte inner join dbo.Club c on cte.club = c.id
                    inner join dbo.Liga l on c.ligaID = l.id
                    where cte.paciente = '" + idPaciente + "'");
                retorno.LigaClub = ligaYClub;
                retorno.Mail = infoPaciente.Rows[0][6].ToString();
            }
            return retorno;
        }

        public Entidades.TurnoLaboral recargarDatoPacienteLaboral(string idPaciente, string idEmpresa)
        {
            string strFechaNac = "";
            TurnoLaboral retorno = new TurnoLaboral();
            DataTable infoPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id, 
                apellido + ' ' + nombres, telefonos, celular, dni, cuil, mail, fechaNacimiento from dbo.PacienteLaboral
                where id = '" + idPaciente + "'");
            if (infoPaciente.Rows.Count > 0)
            {
                retorno.Dni = infoPaciente.Rows[0][4].ToString();
                retorno.Cuil = infoPaciente.Rows[0][5].ToString();
                retorno.ApellidoNombre = infoPaciente.Rows[0][1].ToString();
                strFechaNac = infoPaciente.Rows[0][7].ToString();
                if (!string.IsNullOrEmpty(strFechaNac))
                    retorno.FechaNacimiento = Convert.ToDateTime(infoPaciente.Rows[0][7].ToString());
                else
                    retorno.FechaNacimiento = Convert.ToDateTime("01/01/0001");
                retorno.Telefono = infoPaciente.Rows[0][3].ToString() + " " + infoPaciente.Rows[0][4].ToString();
                DataTable empresaYTarea = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial, ete.tarea
                    from dbo.EmpresasPorPaciente ete inner join dbo.Empresa e on ete.idEmpresa = e.id
                    where ete.idEmpresa = '" + idEmpresa + "' and ete.idPaciente = '" + idPaciente + "'");
                if (empresaYTarea.Rows.Count > 0)
                {
                    retorno.IdEmpresa = new Guid(empresaYTarea.Rows[0][0].ToString());
                    retorno.Empresa = empresaYTarea.Rows[0][1].ToString();
                    retorno.Tarea = empresaYTarea.Rows[0][2].ToString();
                }
            }
            return retorno;
        }

        public void reservarTurno(Guid idTurno, string destinatario)
        {
            //updateReserva(idTurno, "1", idEspecialidad, destinatario);
            updateReserva(idTurno, "1", destinatario);
        }

        //private void updateReserva(Guid idTurno, string estado, string idEspecialidad, object destinatario)
        private void updateReserva(Guid idTurno, string estado, object destinatario)
        {
            //string strSQL = "";
            //Guid guiTipoExamenPaciente = Guid.NewGuid(); ;

            //strSQL = "insert into dbo.TipoExamenDePaciente(id,idTurno, idEspecialidad) " +
            //         "values ('" + guiTipoExamenPaciente + "','" + idTurno + "', '" + idEspecialidad + "')";
            //SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            List<string> lista = SQLConnector.generarListaParaProcedure("@idTurno", "@reservado", "@reserva");
            SQLConnector.executeProcedure("sp_Turno_UpdateReserva", lista, idTurno, estado, destinatario);
            Guid idUsuario = Guid.Empty;
            if (estado == "1")
            {
                idUsuario = new Guid(Configuracion.usuario.id);
            }
            List<string> updateUsuario = SQLConnector.generarListaParaProcedure("@idTurno", "@idUsuario");
            SQLConnector.executeProcedure("sp_Turno_UpdateUsuario", updateUsuario, idTurno, idUsuario);
        }

        public void liberarReservaTurno(Guid idTurno)
        {
            updateReserva(idTurno, "0", null); //GRV - Modificado
            //updateReserva(idTurno, "0", "", null);
        }

        public DataTable cargarTurnosConFiltro(string filtro)
        {
            string strSQL = "";

            strSQL = "select t.id as Id, tep.descripcion as TipoExamen, " +
                     "p.apellido + ' ' + p.nombres as Profesional, " +
                     "t.fecha as Fecha, t.horaReferencia as Hora, t.nroOrden as Nro, t.pacienteID as idPaciente, " +
                     "t.codigo as Codigo, t.reserva as Reserva, t.usuarioID as Usuario, t.bloqueado as Bloqueado, " +
                     "t.asistio as Asistio, t.reservado as Reservado, tep.id as IdTipoExamen, t.habilitado as Habilitado, t.estadoID as IdEstado " +
                     "from dbo.Turno t inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                     "inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id " +
                     "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                     "INNER JOIN dbo.Paciente PC ON PC.id = t.pacienteID " +
                     "WHERE PC.dni LIKE '" + filtro + "%' OR t.codigo LIKE '" + filtro + "%' OR (PC.apellido + ' ' + PC.nombres) LIKE '" + filtro + "%'" +
                     "order by t.fecha, t.hora";

            try
            {
                //                DataTable turnos = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id as Id, tep.descripcion as TipoExamen, 
                //                    p.apellido + ' ' + p.nombres as Profesional,
                //                    t.fecha as Fecha, t.horaReferencia as Hora, t.nroOrden as Nro, t.pacienteID as idPaciente,
                //                    t.codigo as Codigo, t.reserva as Reserva, t.usuarioID as Usuario, t.bloqueado as Bloqueado, 
                //                    t.asistio as Asistio, t.reservado as Reservado, tep.id as IdTipoExamen, t.habilitado as Habilitado from dbo.Turno t inner join dbo.TurnoEstado e on t.estadoID = e.id
                //                    inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id
                //                    inner join dbo.Especialidad tep on h.especialidadID = tep.id
                //                    order by t.fecha, t.hora");
                DataTable turnos = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                if (turnos.Rows.Count > 0)
                {
                    string test;
                    test = "aa";
                    test = "aa";
                    return filtrarTabla(generarTablaRetornoTurno(turnos), filtro);
                }
                else if (turnos.Rows.Count < 1)
                {
                    turnos = null;

                    strSQL = "select t.id as Id, tep.descripcion as TipoExamen, " +
                     "p.apellido + ' ' + p.nombres as Profesional, " +
                     "t.fecha as Fecha, t.horaReferencia as Hora, t.nroOrden as Nro, t.pacienteID as idPaciente, " +
                     "t.codigo as Codigo, t.reserva as Reserva, t.usuarioID as Usuario, t.bloqueado as Bloqueado, " +
                     "t.asistio as Asistio, t.reservado as Reservado, tep.id as IdTipoExamen, t.habilitado as Habilitado, t.estadoID as IdEstado " +
                     "from dbo.Turno t inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                     "inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id " +
                     "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                     "INNER JOIN dbo.PacienteLaboral PC ON PC.id = t.pacienteID " +
                     "WHERE PC.dni LIKE '" + filtro + "%' OR t.codigo LIKE '" + filtro + "%' OR (PC.apellido + ' ' + PC.nombres) LIKE '" + filtro + "%'" +
                     "order by t.fecha, t.hora";

                    turnos = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                    if (turnos.Rows.Count > 0)
                    {
                        string test;
                        test = "aa";
                        test = "aa";
                        return filtrarTabla(generarTablaRetornoTurno(turnos), filtro);
                    }
                    else
                    {
                        turnos = null;

                        strSQL = "select t.id as Id, tep.descripcion as TipoExamen, " +
                                "p.apellido + ' ' + p.nombres as Profesional, " +
                                "t.fecha as Fecha, t.horaReferencia as Hora, t.nroOrden as Nro, t.pacienteID as idPaciente, " +
                                "t.codigo as Codigo, t.reserva as Reserva, t.usuarioID as Usuario, t.bloqueado as Bloqueado, " +
                                "t.asistio as Asistio, t.reservado as Reservado, tep.id as IdTipoExamen, t.habilitado as Habilitado, t.estadoID as IdEstado " +
                                "from dbo.Turno t inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                                "inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id " +
                                "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                                "INNER JOIN dbo.PacienteLaboral PC ON PC.id = t.pacienteID " +
                                "order by t.fecha, t.hora";
                        turnos = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                        string test;
                        test = "aa";
                        test = "aa";
                        return filtrarTabla(generarTablaRetornoTurno(turnos), filtro);
                    }
                }
                else
                {
                    turnos = null;

                    strSQL = "select t.id as Id, tep.descripcion as TipoExamen, " +
                            "p.apellido + ' ' + p.nombres as Profesional, " +
                            "t.fecha as Fecha, t.horaReferencia as Hora, t.nroOrden as Nro, t.pacienteID as idPaciente, " +
                            "t.codigo as Codigo, t.reserva as Reserva, t.usuarioID as Usuario, t.bloqueado as Bloqueado, " +
                            "t.asistio as Asistio, t.reservado as Reservado, tep.id as IdTipoExamen, t.habilitado as Habilitado, t.estadoID as IdEstado " +
                            "from dbo.Turno t inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                            "inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id " +
                            "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                            "INNER JOIN dbo.Paciente PC ON PC.id = t.pacienteID " +
                            "order by t.fecha, t.hora";
                    turnos = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                    string test;
                    test = "aa";
                    test = "aa";
                    return filtrarTabla(generarTablaRetornoTurno(turnos), filtro);
                }
            }
            catch (System.NullReferenceException ex)
            {
                return null;
            }
        }

        private DataTable filtrarTabla(DataTable tablaAFiltrar, string filtro)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("TipoExamen");
            retorno.Columns.Add("Profesional");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Nro");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("Dni");
            retorno.Columns.Add("Paciente");
            retorno.Columns.Add("Categoria");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Reserva");
            retorno.Columns.Add("Usuario");
            retorno.Columns.Add("Bloqueado");
            retorno.Columns.Add("Asistio");
            retorno.Columns.Add("Reservado");
            retorno.Columns.Add("IdTipoExamen");
            retorno.Columns.Add("Estado");

            if (filtro.Where(x => Char.IsDigit(x)).Any())
            {
                procesarFiltro(ref retorno, tablaAFiltrar, filtro, "Dni");
                procesarFiltro(ref retorno, tablaAFiltrar, filtro, "Codigo");
            }
            else
            {
                procesarFiltro(ref retorno, tablaAFiltrar, filtro, "Paciente");
            }
            return retorno;
        }

        private void procesarFiltro(ref DataTable retorno, DataTable tablaAFiltrar, string filtro, string columna)
        {
            DataRow[] drColect = tablaAFiltrar.Select(columna + " like '%" + filtro + "%'");
            foreach (DataRow dr in drColect)
            {
                if (retorno.Select("Id = '" + dr[0].ToString() + "'").Length == 0)
                {
                    retorno.Rows.Add(dr.ItemArray);
                }
            }
        }

        public bool VerificaTurnoConsultorio(Guid idPaciente, DateTime FechaReCitado)
        {
            bool blnRespuesta = false;
            string strSQL = @"select mc.nombre from dbo.Turno t 
            inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id 
            inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            where t.pacienteID = '" + idPaciente.ToString() + "' and convert(date,t.fecha) = convert(date,'" + FechaReCitado.ToShortDateString() + "',105)";

            DataTable motivoConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (motivoConsulta.Rows.Count > 0)
            {
                foreach (DataRow r in motivoConsulta.Rows)
                {
                    if (r.ItemArray[0].ToString() == "CONSULTAS")
                    {
                        blnRespuesta = true;
                    }
                }
            }

            return blnRespuesta;
        }

        public DataTable PacienteTieneTurnoAsignado(DateTime fecha, string idPaciente, string idEmpresa = null)
        {
            string strSQL = "select t.id as Id, tep.descripcion as TipoExamen, " +
                            "t.fecha as Fecha, t.horaReferencia as Hora, t.nroOrden as Nro, t.pacienteID as idPaciente, " +
                            "t.asistio as Asistio, t.reservado as Reservado, tep.id as IdTipoExamen, t.habilitado as Habilitado " +
                            "from dbo.Turno t " +
                            "inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                            "inner join dbo.Horario h on t.horarioID = h.id " +
                            "inner join dbo.Profesional p on h.profesionalID = p.id " +
                            "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                            "where convert(date,t.fecha) = convert(date,'" + fecha.ToShortDateString() + "',105) " +
                            "and t.pacienteID = '" + idPaciente + "'";

            // Si es laboral, filtra por empresa
            if (!string.IsNullOrEmpty(idEmpresa))
            {
                strSQL += " and exists (select 1 from dbo.EmpresasPorPaciente ep where ep.idPaciente = t.pacienteID and ep.idEmpresa = '" + idEmpresa + "')";
            }

            strSQL += " order by t.fecha, t.hora";

            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            return dtConsulta;
        }
        public DataTable VerificaIDTurnoLibre(string strIdTurno, DateTime Fecha, string IdPaciente)
        {
            string strSQL = "";

            strSQL = "SELECT TOP 1 fecha, PacienteID, UsuarioID, estadoID as estado FROM dbo.Turno WHERE id = '" + strIdTurno + "'";
            //strSQL = "SELECT TOP 1 fecha, PacienteID, UsuarioID FROM dbo.Turno WHERE (PacienteID <> '00000000-0000-0000-0000-000000000000' AND id = '" + strIdTurno + "') OR " +
            //         "(Convert(date,fecha) = convert(date,'" + Fecha + "',105) AND PacienteID = '" + IdPaciente + "')";

            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtConsulta;
        }

        public string NombreApellidoPaciente(string IdPaciente)
        {
            string strNombre = "";
            string strSQL = "";

            strSQL = "SELECT Top 1 nombres, apellido from dbo.Paciente WHERE id = '" + IdPaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strNombre = dtConsulta.Rows[0][0].ToString() + " " + dtConsulta.Rows[0][1].ToString();
            }

            strSQL = "SELECT Top 1 nombres, apellido from dbo.PacienteLaboral WHERE id = '" + IdPaciente + "'";
            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strNombre = dtConsulta.Rows[0][0].ToString() + " " + dtConsulta.Rows[0][1].ToString();
            }

            return strNombre;
        }

        public string NombreUsuario(string IdUsuario)
        {
            string strNombre = "";
            string strSQL = "";

            strSQL = "SELECT Top 1 nombre, apellido FROM dbo.Usuario WHERE id = '" + IdUsuario + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strNombre = dtConsulta.Rows[0][0].ToString() + " " + dtConsulta.Rows[0][1].ToString();
            }

            return strNombre;
        }

        public string DNIPaciente(string strIdPaciente)
        {
            string strDNI = "";
            string strSQL = "";

            strSQL = "SELECT TOP 1 codigo FROM dbo.Paciente WHERE id = '" + strIdPaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strDNI = dtConsulta.Rows[0][0].ToString();
            }

            return strDNI;
        }

        public int TotalTurnosAsignados(DateTime Fecha)
        {
            string strSQL = "";
            int intTotal = 0;

            strSQL = "SELECT COUNT(t.id) as Total " +
                     "FROM dbo.Turno t INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id " +
                     "INNER JOIN dbo.Horario h ON t.horarioID = h.id " +
                     "INNER JOIN dbo.Profesional p ON h.profesionalID = p.id " +
                     "INNER JOIN dbo.Especialidad tep ON h.especialidadID = tep.id " +
                     "WHERE CONVERT(date,t.fecha) = CONVERT(date,'" + Fecha.ToShortDateString() + "',105)  AND e.descripcion = 'Asignado'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                intTotal = Convert.ToInt32(dtConsulta.Rows[0][0].ToString());
            }

            return intTotal;
        }

        public int TotalErgometrias(DateTime Fecha)
        {
            string strSQL = "";
            int intTotal = 0;

            strSQL = "select COUNT(t.id) as Total " +
                     "from dbo.Turno t " +
                     "inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                     "inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id " +
                     "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                     "where convert(date,t.fecha) = convert(date,'" + Fecha.ToShortDateString() + "',105) " +
                     "and tep.id = 'bd8d30ea-d803-415d-874c-e991157ac26e' AND bloqueado = 0 AND e.descripcion = 'Libre'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                intTotal = Convert.ToInt32(dtConsulta.Rows[0][0].ToString());
            }

            return intTotal;
        }

        public string ObtenerAlAzarIdErgometria(DateTime Fecha)
        {
            string strSQL = "";
            string strResultado = "";

            strSQL = "select top 1 t.id as idTurno " +
                     "from dbo.Turno t " +
                     "inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                     "inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id " +
                     "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                     "where convert(date,t.fecha) = convert(date,'" + Fecha.ToShortDateString() + "',105) " +
                     "and tep.id = 'bd8d30ea-d803-415d-874c-e991157ac26e' AND bloqueado = 0 AND e.descripcion = 'Libre' order by t.fecha, t.hora";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strResultado = dtConsulta.Rows[0][0].ToString();
            }

            return strResultado;
        }

        public int TotalBuzos(DateTime Fecha)
        {
            string strSQL = "";
            int intTotal = 0;

            strSQL = "select COUNT(t.id) as Total " +
                     "from dbo.Turno t " +
                     "inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                     "inner join dbo.Horario h on t.horarioID = h.id inner join dbo.Profesional p on h.profesionalID = p.id " +
                     "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                     "where convert(date,t.fecha) = convert(date,'" + Fecha.ToShortDateString() + "',105) " +
                     "and (tep.id = 'a5251c29-29db-4ae3-9980-ba2cd60a7001' or tep.id = '94b823bd-d36a-4e8f-8127-c89f745c746b') AND bloqueado = 0 AND e.descripcion = 'Asignado'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                intTotal = Convert.ToInt32(dtConsulta.Rows[0][0].ToString());
            }

            return intTotal;
        }

        public bool TurnoTieneAsociadoExamen(string idTurno)
        {
            bool blnResultado = false;
            string strSQL = "SELECT TOP 1 * FROM dbo.TipoExamenDePaciente WHERE idTurno = '" + idTurno + "' AND idConsulta <> '00000000-0000-0000-0000-000000000000'";

            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
                blnResultado = true;

            return blnResultado;
        }

        public string TurnoReservado(string idTurno)
        {
            string strSQL = "";
            string resultado = "";

            strSQL = "SELECT reserva FROM dbo.Turno WHERE id = '" + idTurno + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                resultado = dtConsulta.Rows[0][0].ToString();
            }
            return resultado;
        }

        public bool ExisteTurnoFecha(string idProfesional)
        {
            bool retorno = false;
            string strSQL = "";
            strSQL = "select TOP 1 tep.descripcion as TipoExamen, p.apellido + ' ' + p.nombres as Profesional, t.fecha as Fecha " +
                     "from dbo.Turno t inner join dbo.TurnoEstado e on t.estadoID = e.id " +
                     "inner join dbo.Horario h on t.horarioID = h.id " +
                     "inner join dbo.Profesional p on h.profesionalID = p.id " +
                     "inner join dbo.Especialidad tep on h.especialidadID = tep.id " +
                     "where convert(date,t.fecha) > convert(date,GETDATE(),105) and e.descripcion = 'Asignado' and p.id = '" + idProfesional + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                retorno = true;
            }

            return retorno;
        }

        public bool MoverTurno(string strIdTurnoAntiguo, string strIdTurnoNuevo, string strNombreEspecialidad)
        {
            DataTable dtConsulta = null;
            bool blnRetorno = false;
            string strSQL = "";
            string strEstadoID = "";
            string strPacienteID = "";
            string strConsulta = "";
            string strUsuarioID = "";
            string strObservaciones = "";
            string strIdEspecialidad = "";

            // Cargar datos
            strSQL = "SELECT estadoID, pacienteID, consulta, usuarioID, observaciones FROM dbo.Turno WHERE id = '" + strIdTurnoAntiguo + "'";
            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            strIdEspecialidad = ObtenerIdEspecialidad(strNombreEspecialidad);

            if (dtConsulta.Rows.Count > 0)
            {
                strEstadoID = dtConsulta.Rows[0][0].ToString();
                strPacienteID = dtConsulta.Rows[0][1].ToString();
                strConsulta = dtConsulta.Rows[0][2].ToString();
                strUsuarioID = dtConsulta.Rows[0][3].ToString();
                strObservaciones = dtConsulta.Rows[0][4].ToString();

                strSQL = "UPDATE dbo.Turno " +
                            "SET " +
                            "estadoID = '" + strEstadoID + "', " +
                            "pacienteID = '" + strPacienteID + "', " +
                            "Consulta = '" + strConsulta + "', " +
                            "usuarioID = '" + strUsuarioID + "', " +
                            "recepcion = '0', " +
                            "mesaDeEntrada = '0', " +
                            "asistio = '0', " +
                            "observaciones = '" + strObservaciones + "' " +
                            "WHERE id = '" + strIdTurnoNuevo + "'";
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                strSQL = "UPDATE dbo.TipoExamenDePaciente " +
                            "SET " +
                            "idEspecialidad = '" + strIdEspecialidad + "', " +
                            "idTurno = '" + strIdTurnoNuevo + "' " +
                            "WHERE idTurno = '" + strIdTurnoAntiguo + "'";
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                // Limpiar turno
                strSQL = "UPDATE dbo.Turno " +
                            "SET " +
                            "estadoID = '1737E61F-B256-40F5-8B57-63369638536D', " +
                            "pacienteID = '00000000-0000-0000-0000-000000000000', " +
                            "Consulta = NULL, " +
                            "usuarioID = '6E3FD627-0B05-429B-8376-179889CD489B', " +
                            "recepcion = NULL, " +
                            "mesaDeEntrada = NULL, " +
                            "asistio = NULL, " +
                            "observaciones = '' " +
                            "WHERE id = '" + strIdTurnoAntiguo + "'";
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }

            return blnRetorno;
        }



        public string TipoConsulta(string IdTurno)
        {
            string strRespuesta = "";
            string strSQL = "";

            strSQL = "SELECT consulta from dbo.turno WHERE id = '" + IdTurno + "'";

            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strRespuesta = dtConsulta.Rows[0][0].ToString();
            }

            return strRespuesta;
        }

        public DataTable buscarTurnosPorDNI(string dni)
        {
            try
            {
                string strSQL = @"
                    SELECT t.id as Id, 
                        ISNULL(tePadre.descripcion, te.descripcion) as TipoPadre,
                        te.descripcion as SubTipo,
                        p.apellido + ' ' + p.nombres as Profesional,
                        t.fecha as Fecha,
                        t.horaReferencia as Hora,
                        CONVERT(numeric, t.nroOrden) as Nro,
                        t.pacienteID as idPaciente,
                        t.codigo as Codigo,
                        t.reserva as Reserva,
                        t.usuarioID as Usuario,
                        t.bloqueado as Bloqueado,
                        t.asistio as Asistio,
                        t.reservado as Reservado,
                        tep.id as IdTipoExamen,
                        t.habilitado as Habilitado,
                        t.estadoID as IdEstado,
                        te.id as IdSubtipo,
                        ISNULL(tePadre.id, te.id) as IdPadre
                    FROM dbo.Turno t
                    INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
                    INNER JOIN dbo.Horario h ON t.horarioID = h.id
                    INNER JOIN dbo.Profesional p ON h.profesionalID = p.id
                    LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
                    LEFT JOIN dbo.Especialidad te ON h.especialidadID = te.id
                    LEFT JOIN dbo.Especialidad tePadre ON te.IdPadre = tePadre.id AND te.Padre = 0
                    WHERE t.codigo = '" + dni + @"'
                    OR (t.pacienteID IN (
                        SELECT id FROM dbo.Paciente WHERE dni LIKE '" + dni + @"%'
                        UNION
                        SELECT id FROM dbo.PacienteLaboral WHERE dni LIKE '" + dni + @"%'
                    ))
                    ORDER BY t.fecha DESC, t.horaReferencia DESC";

                DataTable turnos = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                return generarTablaRetornoTurno(turnos);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en buscarTurnosPorDNI: {ex.Message}");
                return new DataTable();
            }
        }

        /// <summary>
        /// Busca turnos por NOMBRE del paciente (búsqueda LIKE)
        /// </summary>
        public DataTable buscarTurnosPorNombre(string nombre)
        {
            try
            {
                string strSQL = @"
                    SELECT t.id as Id, 
                        ISNULL(tePadre.descripcion, te.descripcion) as TipoPadre,
                        te.descripcion as SubTipo,
                        p.apellido + ' ' + p.nombres as Profesional,
                        t.fecha as Fecha,
                        t.horaReferencia as Hora,
                        CONVERT(numeric, t.nroOrden) as Nro,
                        t.pacienteID as idPaciente,
                        t.codigo as Codigo,
                        t.reserva as Reserva,
                        t.usuarioID as Usuario,
                        t.bloqueado as Bloqueado,
                        t.asistio as Asistio,
                        t.reservado as Reservado,
                        tep.id as IdTipoExamen,
                        t.habilitado as Habilitado,
                        t.estadoID as IdEstado,
                        te.id as IdSubtipo,
                        ISNULL(tePadre.id, te.id) as IdPadre
                    FROM dbo.Turno t
                    INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
                    INNER JOIN dbo.Horario h ON t.horarioID = h.id
                    INNER JOIN dbo.Profesional p ON h.profesionalID = p.id
                    LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
                    LEFT JOIN dbo.Especialidad te ON h.especialidadID = te.id
                    LEFT JOIN dbo.Especialidad tePadre ON te.IdPadre = tePadre.id AND te.Padre = 0
                    WHERE t.pacienteID IN (
                        SELECT id FROM dbo.Paciente WHERE (apellido + ' ' + nombres) LIKE '" + nombre + @"%'
                        UNION
                        SELECT id FROM dbo.PacienteLaboral WHERE (apellido + ' ' + nombres) LIKE '" + nombre + @"%'
                    )
                    ORDER BY t.fecha DESC, t.horaReferencia DESC";

                DataTable turnos = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                return generarTablaRetornoTurno(turnos);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en buscarTurnosPorNombre: {ex.Message}");
                return new DataTable();
            }
        }

        public string ObtenerIdEspecialidad(string NombreEspecialidad)
        {
            string strSQL = "";
            string strIdEspecialidad = "";

            strSQL = "SELECT TOP 1 id FROM dbo.Especialidad WHERE descripcion = '" + NombreEspecialidad + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strIdEspecialidad = dtConsulta.Rows[0][0].ToString();
            }

            return strIdEspecialidad;
        }

        /// <summary>
        /// CASCADA NIVEL 1: Carga los Motivos de Consulta disponibles
        /// Ej: PREVENTIVA, LABORAL, etc.
        /// </summary>
        public DataTable cargarMotivosConsultaTurno()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"
                SELECT id, nombre 
                FROM dbo.MotivoDeConsulta 
                WHERE nombre <> 'VISITAS'
                ORDER BY nombre");
        }

        /// <summary>
        /// CASCADA NIVEL 2: Devuelve las Especialidades padre (Padre=1) para un MotivoDeConsulta
        /// Ej: CARDIOLOGÍA, NEUMOLOGÍA, etc. dentro de PREVENTIVA
        /// </summary>
        public DataTable cargarNivel1EspecialidadTurno(string idMotivoConsulta)
        {
            if (!int.TryParse(idMotivoConsulta, out int id))
                return new DataTable();

            return SQLConnector.obtenerTablaSegunConsultaString(
                @"SELECT * FROM dbo.Especialidad
                WHERE Padre = 1 
                AND idMotivoConsulta = " + id + @"
                AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                ORDER BY CASE WHEN ISNUMERIC(codigo) = 1 THEN CONVERT(int, codigo) ELSE 999999 END, codigo");
        }

        /// <summary>
        /// CASCADA NIVEL 3: Devuelve las Especialidades hijo (Padre=0) para un IdPadre
        /// Ej: Subcategorías dentro de CARDIOLOGÍA
        /// </summary>
        public DataTable cargarNivel2EspecialidadTurno(string idPadre)
        {
            if (string.IsNullOrWhiteSpace(idPadre))
                return new DataTable();

            return SQLConnector.obtenerTablaSegunConsultaString(@"
                SELECT * FROM dbo.Especialidad
                WHERE Padre = 0 
                AND IdPadre = '" + idPadre + @"'
                AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                ORDER BY CASE WHEN ISNUMERIC(codigo) = 1 THEN CONVERT(int, codigo) ELSE 999999 END, codigo");
        }

        /// <summary>
        /// Verifica si una especialidad tiene hijos (subcategorías)
        /// Retorna DataTable vacío si no tiene, o con filas si tiene
        /// </summary>
        public DataTable verificarEspecialidadTieneSub(string idEspecialidad)
        {
            if (string.IsNullOrWhiteSpace(idEspecialidad))
                return new DataTable();

            return SQLConnector.obtenerTablaSegunConsultaString(@"
                SELECT * FROM dbo.Especialidad
                WHERE IdPadre = '" + idEspecialidad + @"'
                AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)");
        }
    }
}
