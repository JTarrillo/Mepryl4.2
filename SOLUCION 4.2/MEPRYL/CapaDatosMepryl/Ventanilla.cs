using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunes;
using System.Data;
using Entidades;

namespace CapaDatosMepryl
{
    public class Ventanilla
    {
        private Turno turno;
        private int intTotalOcultos = 0;

        public Ventanilla()
        {
            turno = new Turno();
        }

        public DataTable cargar(DateTime desde, DateTime hasta, bool blnPrimerImgreso)
        {
            string strFiltro = blnPrimerImgreso ? "AND ocultar <> 1" : "";

            // Sargable: usar rango en lugar de CONVERT en columna
            string fechaDesde = desde.Date.ToString("yyyyMMdd");
            string fechaHasta = hasta.Date.AddDays(1).ToString("yyyyMMdd");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            DataTable rawTurnos = SQLConnector.obtenerTablaSegunConsultaString(
                @"select t.id as Id, t.fecha as Fecha, t.horaReferencia as Hora, t.nroOrden as Orden,
                e.descripcion as SubtipoExamen, e.precioBase as PrecioBase,
                ISNULL(ePadre.descripcion, CASE WHEN e.Padre = 0 THEN e.descripcion ELSE NULL END) as TipoPadre,
                t.observaciones as Observaciones, t.codigo as Codigo,
                t.asistio, t.reserva, t.pacienteID, t.abono, t.reservado, t.ocultar
                from dbo.Turno t
                inner join dbo.Horario h on t.horarioID = h.id
                inner join dbo.Especialidad e on h.especialidadID = e.id
                left join dbo.Especialidad ePadre on e.IdPadre = ePadre.id
                where t.fecha >= '" + fechaDesde + "' and t.fecha < '" + fechaHasta +
                "' and (t.recepcion = '0' or t.recepcion is NULL) and t.habilitado = '1' " +
                strFiltro + " order by t.fecha asc, t.hora asc, t.nroOrden asc");
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[VENTANILLA] Query principal: {sw.ElapsedMilliseconds} ms ({rawTurnos.Rows.Count} filas)");

            DataTable dt = generarTablaRetornoVentanillaBatch(rawTurnos);
            intTotalOcultos = dt.Rows.Count;
            return dt;
        }

        private DataTable generarTablaRetornoVentanillaBatch(DataTable rawTurnos)
        {
            DataTable retorno = crearTablaRetornoVentanilla();

            if (rawTurnos.Rows.Count == 0) return retorno;

            // Recolectar IDs únicos para batch queries
            var turnoIds   = rawTurnos.AsEnumerable().Select(r => r["Id"].ToString()).Distinct().ToList();
            var pacienteIds = rawTurnos.AsEnumerable()
                .Select(r => r["pacienteID"].ToString())
                .Where(s => !string.IsNullOrEmpty(s) && s != Guid.Empty.ToString())
                .Distinct().ToList();

            string tIn = "'" + string.Join("','", turnoIds) + "'";
            string pIn = pacienteIds.Count > 0 ? "'" + string.Join("','", pacienteIds) + "'" : "'00000000-0000-0000-0000-000000000000'";

            var sw = System.Diagnostics.Stopwatch.StartNew();

            // Batch: pacientes preventiva y laboral en una sola query UNION
            DataTable pacientes = SQLConnector.obtenerTablaSegunConsultaString(
                "select id, dni, apellido + ' ' + nombres as Paciente from dbo.Paciente where id in (" + pIn + ")" +
                " UNION ALL " +
                "select id, dni, apellido + ' ' + nombres as Paciente from dbo.PacienteLaboral where id in (" + pIn + ")");

            // Batch: TipoExamenDePaciente (trae idTurno, id, precioExamen, modificado)
            DataTable tipoExamenBatch = SQLConnector.obtenerTablaSegunConsultaString(
                @"select tep.idTurno, tep.id, tep.precioExamen, tep.modificado
                from dbo.TipoExamenDePaciente tep
                where tep.idTurno in (" + tIn + ")");

            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[VENTANILLA] Batch pacientes+TipoExamen: {sw.ElapsedMilliseconds} ms");
            sw.Restart();

            // IDs de TipoExamen para batch clubes/empresas
            var teIds = tipoExamenBatch.AsEnumerable().Select(r => r["id"].ToString()).Distinct().ToList();
            string teIn = teIds.Count > 0 ? "'" + string.Join("','", teIds) + "'" : "'00000000-0000-0000-0000-000000000000'";

            // precioBase ya viene en rawTurnos (columna PrecioBase desde Especialidad)

            // Batch: clubes por tipo examen
            DataTable clubesBatch = SQLConnector.obtenerTablaSegunConsultaString(
                @"select cte.idTipoExamen, c.descripcion as Club
                from dbo.clubesPorTipoExamen cte inner join dbo.Club c on cte.idClub = c.id
                where cte.idTipoExamen in (" + teIn + ")");

            // Batch: empresas por tipo examen
            DataTable empresasBatch = SQLConnector.obtenerTablaSegunConsultaString(
                @"select ete.idTipoExamen, e.razonSocial as Empresa, e.id as IdEmpresa
                from dbo.empresaPorTipoDeExamen ete inner join dbo.Empresa e on ete.idEmpresa = e.id
                where ete.idTipoExamen in (" + teIn + ")");

            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[VENTANILLA] Batch precios+clubes+empresas: {sw.ElapsedMilliseconds} ms");

            // Armar diccionarios en memoria O(1)
            var dictPaciente = new Dictionary<string, DataRow>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in pacientes.Rows)
            {
                string id = r["id"].ToString();
                if (!dictPaciente.ContainsKey(id)) dictPaciente[id] = r;
            }

            // turnoId -> (idTE, precioExamen, modificado)
            var dictTE = new Dictionary<string, (string idTE, string precio, string modificado)>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in tipoExamenBatch.Rows)
            {
                string idTurno = r["idTurno"].ToString();
                if (!dictTE.ContainsKey(idTurno))
                    dictTE[idTurno] = (r["id"].ToString(), r["precioExamen"].ToString(), r["modificado"].ToString());
            }

            // precioBase por turno tomado directamente de rawTurnos
            var dictPrecioBase = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in rawTurnos.Rows)
                dictPrecioBase[r["Id"].ToString()] = r["PrecioBase"].ToString();

            // idTE -> (empresaClub, idEmpresa) — clubes tienen prioridad sobre empresas
            var dictEmpresaClub = new Dictionary<string, (string nombre, string id)>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in empresasBatch.Rows)
            {
                string key = r["idTipoExamen"].ToString();
                if (!dictEmpresaClub.ContainsKey(key))
                    dictEmpresaClub[key] = (r["Empresa"].ToString(), r["IdEmpresa"].ToString());
            }
            // Clubes sobreescriben empresas si existen
            var dictClubes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in clubesBatch.Rows)
            {
                string key = r["idTipoExamen"].ToString();
                if (dictClubes.ContainsKey(key))
                    dictClubes[key] = dictClubes[key] + " / " + r["Club"].ToString();
                else
                    dictClubes[key] = r["Club"].ToString();
            }

            // Procesar filas en memoria — cero queries adicionales
            foreach (DataRow r in rawTurnos.Rows)
            {
                bool asistio   = r["asistio"].ToString() == "1";
                bool abono     = r["abono"].ToString() == "1";
                bool reservado = r["reservado"].ToString() == "1";
                bool ocultar   = r["ocultar"].ToString() == "1";

                string idTurno    = r["Id"].ToString();
                string idPaciente = r["pacienteID"].ToString();
                string fecha      = Convert.ToDateTime(r["Fecha"]).ToShortDateString();
                string tipoPadre  = r["TipoPadre"] == DBNull.Value ? string.Empty : r["TipoPadre"].ToString();

                dictTE.TryGetValue(idTurno, out var teData);
                string idTE       = teData.idTE ?? string.Empty;
                string modificado = teData.modificado ?? string.Empty;
                string importe    = string.Empty;
                if (!string.IsNullOrEmpty(teData.precio)) importe = teData.precio;
                else dictPrecioBase.TryGetValue(idTurno, out importe);

                string empresaClub = string.Empty, idEmpresa = string.Empty;
                if (!string.IsNullOrEmpty(idTE))
                {
                    if (dictClubes.TryGetValue(idTE, out string clubNombre))
                        empresaClub = clubNombre;
                    else if (dictEmpresaClub.TryGetValue(idTE, out var empData))
                    { empresaClub = empData.nombre; idEmpresa = empData.id; }
                }

                if (!string.IsNullOrEmpty(idPaciente) && idPaciente != Guid.Empty.ToString())
                {
                    string dni = string.Empty, paciente = string.Empty;
                    if (dictPaciente.TryGetValue(idPaciente, out DataRow pacRow))
                    { dni = pacRow["dni"].ToString(); paciente = pacRow["Paciente"].ToString(); }

                    retorno.Rows.Add(asistio, abono, idTurno, fecha, r["Hora"],
                        r["Orden"], tipoPadre,
                        r["SubtipoExamen"].ToString() + " " + modificado,
                        dni, paciente, importe, empresaClub,
                        r["Observaciones"], r["Codigo"], idPaciente,
                        reservado, idEmpresa, ocultar);
                }
                else if (reservado)
                {
                    string paciente = "RESERVA " + r["reserva"].ToString().ToUpper();
                    retorno.Rows.Add(asistio, abono, idTurno, fecha, r["Hora"],
                        r["Orden"], tipoPadre,
                        r["SubtipoExamen"],
                        string.Empty, paciente, importe, string.Empty,
                        string.Empty, r["Codigo"], Guid.Empty,
                        reservado, string.Empty, ocultar);
                }
            }
            return retorno;
        }

        private DataTable crearTablaRetornoVentanilla()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Asistio");
            retorno.Columns.Add("Abono");
            retorno.Columns.Add("IdTurno");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Nro");
            retorno.Columns.Add("Tipo");
            retorno.Columns.Add("Subtipo de Examen");
            retorno.Columns.Add("Dni");
            retorno.Columns.Add("Paciente");
            retorno.Columns.Add("Importe");
            retorno.Columns.Add("EmpresaClub");
            retorno.Columns.Add("Observaciones");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("Reservado");
            retorno.Columns.Add("IdEmpresa");
            retorno.Columns.Add("Ocultar");
            retorno.Columns[0].DataType = typeof(bool);
            retorno.Columns[1].DataType = typeof(bool);
            retorno.Columns[15].DataType = typeof(bool);
            retorno.Columns[17].DataType = typeof(bool);
            return retorno;
        }
                

        //public int TotalTurnosVentanilla(DateTime desde, DateTime hasta)
        //{            
        //    DataTable ventanilla = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id as Id,
        //    Convert(date,t.fecha) as Fecha, t.horaReferencia as Hora, t.nroOrden as Orden, 
        //    e.descripcion as 'Exámen', 
        //    t.observaciones as Observaciones, t.codigo as Código, t.asistio, t.reserva, t.pacienteID, t.abono, t.reservado, t.ocultar
        //    from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
        //    inner join dbo.Especialidad e on h.especialidadID = e.id 
        //    inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
        //    where Convert(Date,t.fecha) >= '" + desde.ToShortDateString() + @"' and Convert(Date,t.fecha) <= '" + hasta.ToShortDateString() +
        //   "' and (t.recepcion = '0' or t.recepcion is NULL) and t.habilitado = '1' order  by t.fecha asc, t.hora asc, t.nroOrden asc");

        //    return generarTablaRetornoVentanilla(ventanilla).Rows.Count;

        //}

        public DataTable cargarFiltrado(DateTime desde, DateTime hasta, string filtro)
        {
            return filtrar(cargar(desde, hasta, false), filtro);
        }

        private DataTable filtrar(DataTable tabla, string filtro)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Asistio");     // 0
            retorno.Columns.Add("Abono");       // 1
            retorno.Columns.Add("IdTurno");     // 2
            retorno.Columns.Add("Fecha");       // 3
            retorno.Columns.Add("Hora");        // 4
            retorno.Columns.Add("Nro");         // 5
            retorno.Columns.Add("Tipo");        // 6
            retorno.Columns.Add("Subtipo de Examen");      // 7
            retorno.Columns.Add("Dni");         // 8
            retorno.Columns.Add("Paciente");    // 9
            retorno.Columns.Add("Importe");     // 10
            retorno.Columns.Add("EmpresaClub"); // 11
            retorno.Columns.Add("Observaciones");   // 12
            retorno.Columns.Add("Codigo");      // 13
            retorno.Columns.Add("IdPaciente");  // 14
            retorno.Columns.Add("Reservado");   // 15
            retorno.Columns.Add("IdEmpresa");   // 16
            retorno.Columns.Add("Ocultar");     // 17
            retorno.Columns[0].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[1].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[15].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[17].DataType = System.Type.GetType("System.Boolean");

            if (filtro.Where(x => Char.IsDigit(x)).Any())
            {
                procesarFiltro(ref retorno, tabla, filtro, "Dni");
                procesarFiltro(ref retorno, tabla, filtro, "Codigo");
            }
            else
            {
                procesarFiltro(ref retorno, tabla, filtro, "Paciente");
                procesarFiltro(ref retorno, tabla, filtro, "Tipo");
                procesarFiltro(ref retorno, tabla, filtro, "Subtipo de Examen");
                procesarFiltro(ref retorno, tabla, filtro, "EmpresaClub");
            }
            return retorno;
        }

        private void procesarFiltro(ref DataTable retorno, DataTable tablaAFiltrar, string filtro, string columna)
        {
            DataRow[] drColect = tablaAFiltrar.Select("[" + columna + "] like '%" + filtro + "%'");
            foreach (DataRow dr in drColect)
            {
                if (retorno.Select("IdTurno = '" + dr[2].ToString() + "'").Length == 0)
                {
                    retorno.Rows.Add(dr.ItemArray);
                }
            }
        }

        private DataTable generarTablaRetornoVentanilla(DataTable ventanilla)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Asistio");     // 0
            retorno.Columns.Add("Abono");       // 1
            retorno.Columns.Add("IdTurno");     // 2
            retorno.Columns.Add("Fecha");       // 3
            retorno.Columns.Add("Hora");        // 4
            retorno.Columns.Add("Nro");         // 5
            retorno.Columns.Add("Subtipo de Examen");     // 6
            retorno.Columns.Add("Dni");         // 7
            retorno.Columns.Add("Paciente");    // 8
            retorno.Columns.Add("Importe");     // 9
            retorno.Columns.Add("EmpresaClub"); // 10
            retorno.Columns.Add("Observaciones");   // 11
            retorno.Columns.Add("Codigo");      // 12
            retorno.Columns.Add("IdPaciente");  // 13
            retorno.Columns.Add("Reservado");   // 14
            retorno.Columns.Add("IdEmpresa");   // 15
            retorno.Columns.Add("Ocultar");     // 16
            retorno.Columns[0].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[1].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[14].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[16].DataType = System.Type.GetType("System.Boolean");

            foreach (DataRow r in ventanilla.Rows)
            {
                bool asistio = false;
                bool abono = false;
                bool reservado = false;
                bool ocultar = false;
                if (r.ItemArray[7].ToString() == "1") { asistio = true; }
                if (r.ItemArray[10].ToString() == "1") { abono = true; }
                if (r.ItemArray[11].ToString() == "1") { reservado = true; }
                if (r.ItemArray[12].ToString() == "1") { ocultar = true; }

                string paciente = string.Empty;
                string dni = string.Empty;
                string Modificado = "";

                if (r.ItemArray[9].ToString() != Guid.Empty.ToString())
                {
                    Modificado = EstudioModificadoPaciente(r.ItemArray[0].ToString());
                    DataRow dr = cargarDatoPaciente(r.ItemArray[9].ToString());
                    dni = dr.ItemArray[0].ToString();
                    paciente = dr.ItemArray[1].ToString();
                    retorno.Rows.Add(asistio, abono, r.ItemArray[0], Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(), r.ItemArray[2],
                    r.ItemArray[3], r.ItemArray[4] + " " + Modificado, dni, paciente, cargarImporte(new Guid(r.ItemArray[0].ToString())),
                    //r.ItemArray[3], r.ItemArray[4], dni, paciente, cargarImporte(new Guid(r.ItemArray[0].ToString())),
                    cargarEmpresaClub(new Guid(r.ItemArray[0].ToString()))[0], r.ItemArray[5],
                    r.ItemArray[6], r.ItemArray[9], reservado, cargarEmpresaClub(new Guid(r.ItemArray[0].ToString()))[1], ocultar);
                }
                else
                {
                    paciente = "RESERVA " + r.ItemArray[8].ToString().ToUpper();
                    if (reservado) 
                    {
                        retorno.Rows.Add(asistio, abono, r.ItemArray[0], Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(), r.ItemArray[2],
                        //r.ItemArray[3], r.ItemArray[4] + " " + r.ItemArray[12], dni, paciente, cargarImporte(new Guid(r.ItemArray[0].ToString())),
                        r.ItemArray[3], r.ItemArray[4], dni, paciente, cargarImporte(new Guid(r.ItemArray[0].ToString())),
                        string.Empty, string.Empty,
                        r.ItemArray[6], Guid.Empty, reservado, string.Empty, ocultar);
                    }
                }

            }
            return retorno;
        }

        private DataRow cargarDatoPaciente(string idPaciente)
        {
            DataTable pacientePreventiva = SQLConnector.obtenerTablaSegunConsultaString(@"
                    select p.dni, p.apellido + ' ' + p.nombres as Paciente, YEAR(p.fechaNacimiento) as Categoria
                    from dbo.Paciente p
                    where p.id = '" + idPaciente + "'");
            if (pacientePreventiva.Rows.Count > 0)
            {
                return pacientePreventiva.Rows[0];
            }
            else
            {
                DataTable pacienteLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"
                        select p.dni, p.apellido + ' ' + p.nombres as Paciente
                        from dbo.PacienteLaboral p
                        where p.id = '" + idPaciente + "'");
                return pacienteLaboral.Rows[0];
            }
        }

        private string EstudioModificadoPaciente(string idTurno)
        {
            DataTable dtConsulta;
            string strSQL = "";
            string strRetorno = "";

            strSQL = "SELECT TOP 1 modificado FROM dbo.TipoExamenDePaciente te WHERE te.idTurno = '" + idTurno + "'";
            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strRetorno = dtConsulta.Rows[0][0].ToString();

                if (string.IsNullOrEmpty(strRetorno))
                    strRetorno = "";
            }

            return strRetorno;
        }

        private string cargarImporte(Guid idTurno)
        {
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select precioExamen from dbo.TipoExamenDePaciente 
            where idTurno = '" + idTurno.ToString() + "'");
            if (tipoExamen.Rows.Count > 0) { return tipoExamen.Rows[0][0].ToString();}
            return cargarImporteSegunTipoExamen(idTurno);
        }

        private string cargarImporteSegunTipoExamen(Guid idTurno)
        {
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select e.precioBase from dbo.Turno t 
            inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            where t.id = '" + idTurno.ToString() + "'");
            return tipoExamen.Rows[0][0].ToString();
        }

        private List<string> cargarEmpresaClub(Guid idTurno)
        {
            List<string> retorno = new List<string>();
            retorno.Add(string.Empty);
            retorno.Add(string.Empty);
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.TipoExamenDePaciente 
            where idTurno = '" + idTurno.ToString() + "'");
            if (tipoExamen.Rows.Count > 0)
            {
                return cargarEmpresaClubPorTipoExamen(new Guid(tipoExamen.Rows[0][0].ToString()));
            }
            return retorno;
        }

        private List<string> cargarEmpresaClubPorTipoExamen(Guid idTipoExamen)
        {
            List<string> retorno = new List<string>();
            DataTable clubPorTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select c.descripcion 
            from dbo.TipoExamenDePaciente tep inner join dbo.clubesPorTipoExamen cte on tep.id = cte.idTipoExamen
            inner join dbo.Club c on cte.idClub = c.id where tep.id = '" + idTipoExamen.ToString() + "'");
            if (clubPorTipoExamen.Rows.Count > 0)
            {
                return devolverStringClubes(clubPorTipoExamen);
            }
            DataTable empresaPorTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial 
            from dbo.TipoExamenDePaciente tep inner join dbo.empresaPorTipoDeExamen ete
            on tep.id = ete.idTipoExamen inner join dbo.Empresa e on ete.idEmpresa = e.id
            where tep.id = '" + idTipoExamen.ToString() + "'");
            if (empresaPorTipoExamen.Rows.Count > 0)
            {
                // GRV - Modificado
                //retorno.Add(empresaPorTipoExamen.Rows[0][1].ToString().ToUpper());
                retorno.Add(empresaPorTipoExamen.Rows[0][1].ToString());
                retorno.Add(empresaPorTipoExamen.Rows[0][0].ToString());
                return retorno;
            }
            retorno.Add(string.Empty);
            retorno.Add(string.Empty);
            return retorno;
        }

        private List<string> devolverStringClubes(DataTable clubes)
        {
            List<string> lista = new List<string>();
            string retorno = "";
            foreach (DataRow r in clubes.Rows)
            {
                // GRV - Modificado                
                //if (retorno == string.Empty) { retorno = r.ItemArray[0].ToString().ToUpper(); }
                //else { retorno = retorno + " / " + r.ItemArray[0].ToString().ToUpper(); }
                if (retorno == string.Empty) { retorno = r.ItemArray[0].ToString(); }
                else { retorno = retorno + " / " + r.ItemArray[0].ToString(); }
            }
            lista.Add(retorno);
            lista.Add(string.Empty);
            return lista;
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

        public void actualizarClubesPorTipoExamenSegunTurno(Guid idTurno, Guid idPaciente)
        {
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.TipoExamenDePaciente
            where idTurno = '" + idTurno.ToString() + "'");
            if (tipoExamen.Rows.Count > 0)
            {
                Guid idTipoExamen = new Guid(tipoExamen.Rows[0][0].ToString());
                List<string> deleteClubesPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Delete", deleteClubesPorTipoExamen, idTipoExamen);
                DataTable clubesActuales = SQLConnector.obtenerTablaSegunConsultaString(@"select club from dbo.clubesPorPaciente
                where paciente = '" + idPaciente.ToString() + "'");
                foreach (DataRow r in clubesActuales.Rows)
                {
                    List<string> addClubesPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen","@idClub");
                    SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", addClubesPorTipoExamen, idTipoExamen, new Guid(r.ItemArray[0].ToString()));
                }
            }
        }

        public void actualizarPresente(Guid idTurno, bool valor)
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure("sp_Turno_UpdatePresente", lista, idTurno, devolverStringBooleano(valor));
        }

        private string devolverStringBooleano(bool valor)
        {
            if (valor) { return "1"; }
            return "0";
        }

        public void actualizarAbono(Guid idTurno, bool valor)
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure("sp_Turno_UpdateAbono", lista, idTurno, devolverStringBooleano(valor));
        }

        public void registrarIngreso(Guid idTurno)
        {
            List<string> registrarIngreso = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure("sp_Turno_CambiarEstadoRecepcion", registrarIngreso, idTurno, "1");
        }

        public char verificarTipoTurno(Guid idTurno)
        {
            return turno.verificarTipoTurno(idTurno);
        }

        public Entidades.Resultado nuevoTurnoPacientePreventiva(string idPaciente, string idTurno)
        {
            return turno.asignarTurnoPacientePreventivaVentanillaMesaEntrada(idPaciente, idTurno);
        }

        public Entidades.Resultado nuevoTurnoPacienteLaboral(string idPaciente, string idTurno, string idEmpresa)
        {
            return turno.asignarTurnoPacienteLaboralVentanillaMesaEntrada(idPaciente, idTurno, idEmpresa);
        }

        public void actualizarOcultar(string idTurno, bool valor)
        {            
            string strSQL = "";
            string strValor = "0";

            if (valor)
            {
                strValor = "1";
            }

            strSQL = "UPDATE dbo.Turno " +
                     "SET ocultar = '" + strValor + "' " +
                     "WHERE id = '" + idTurno + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public int TurnosNoOcultos(DateTime desde, DateTime hasta)
        {
            string strSQL = "";

            strSQL = @"select t.id as Id
        from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
        inner join dbo.Especialidad e on h.especialidadID = e.id 
        inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
        WHERE Convert(Date,t.fecha) >= '" + desde.ToString("yyyy-MM-dd") + @"' 
        and Convert(Date,t.fecha) <= '" + hasta.ToString("yyyy-MM-dd") + @"' 
        and (t.recepcion = '0' or t.recepcion is NULL) and t.habilitado = '1' AND t.ocultar <> 1 
        AND t.pacienteID <> '00000000-0000-0000-0000-000000000000'
        order  by t.fecha asc, t.hora asc, t.nroOrden asc";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count;
        }


        public int TurnosOcultos(DateTime desde, DateTime hasta)
        {
            string strSQL = "";

            strSQL = @"select t.id as Id
        from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
        inner join dbo.Especialidad e on h.especialidadID = e.id 
        inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
        WHERE Convert(Date,t.fecha) >= '" + desde.ToString("yyyy-MM-dd") + @"' 
        and Convert(Date,t.fecha) <= '" + hasta.ToString("yyyy-MM-dd") + @"' 
        and (t.recepcion = '0' or t.recepcion is NULL) and t.habilitado = '1' AND t.ocultar = 1 
        AND t.pacienteID <> '00000000-0000-0000-0000-000000000000'
        order  by t.fecha asc, t.hora asc, t.nroOrden asc";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count;
        }
    }
}
