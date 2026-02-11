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

        public Ventanilla()
        {
            turno = new Turno();
        }

        public DataTable cargar(DateTime desde, DateTime hasta)
        {
            DataTable ventanilla = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id as Id,
            Convert(date,t.fecha) as Fecha, t.horaReferencia as Hora, t.nroOrden as Orden, 
            e.descripcion as 'Exámen', 
            t.observaciones as Observaciones, t.codigo as Código, t.asistio, t.reserva, t.pacienteID, t.abono, t.reservado
            from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id 
            inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            where Convert(Date,t.fecha) >= '" + desde.ToShortDateString() + @"' and Convert(Date,t.fecha) <= '" + hasta.ToShortDateString() +
            "' and (t.recepcion = '0' or t.recepcion is NULL) and t.habilitado = '1' order  by t.fecha asc, t.hora asc, t.nroOrden asc");
            return generarTablaRetornoVentanilla(ventanilla);
        }

        public DataTable cargarFiltrado(DateTime desde, DateTime hasta, string filtro)
        {
            return filtrar(cargar(desde, hasta), filtro);
        }

        private DataTable filtrar(DataTable tabla, string filtro)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Asistio");
            retorno.Columns.Add("Abono");
            retorno.Columns.Add("IdTurno");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Nro");
            retorno.Columns.Add("Examen");
            retorno.Columns.Add("Dni");
            retorno.Columns.Add("Paciente");
            retorno.Columns.Add("Importe");
            retorno.Columns.Add("EmpresaClub");
            retorno.Columns.Add("Observaciones");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("Reservado");
            retorno.Columns.Add("IdEmpresa");
            retorno.Columns[0].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[1].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[14].DataType = System.Type.GetType("System.Boolean");

            if (filtro.Where(x => Char.IsDigit(x)).Any())
            {
                procesarFiltro(ref retorno, tabla, filtro, "Dni");
                procesarFiltro(ref retorno, tabla, filtro, "Codigo");
            }
            else
            {
                procesarFiltro(ref retorno, tabla, filtro, "Paciente");
                procesarFiltro(ref retorno, tabla, filtro, "Examen");
                procesarFiltro(ref retorno, tabla, filtro, "EmpresaClub");
            }
            return retorno;
        }

        private void procesarFiltro(ref DataTable retorno, DataTable tablaAFiltrar, string filtro, string columna)
        {
            DataRow[] drColect = tablaAFiltrar.Select(columna + " like '%" + filtro + "%'");
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
            retorno.Columns.Add("Asistio");
            retorno.Columns.Add("Abono");
            retorno.Columns.Add("IdTurno");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Nro");
            retorno.Columns.Add("Examen");
            retorno.Columns.Add("Dni");
            retorno.Columns.Add("Paciente");
            retorno.Columns.Add("Importe");
            retorno.Columns.Add("EmpresaClub");
            retorno.Columns.Add("Observaciones");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("Reservado");
            retorno.Columns.Add("IdEmpresa");
            retorno.Columns[0].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[1].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns[14].DataType = System.Type.GetType("System.Boolean");

            foreach (DataRow r in ventanilla.Rows)
            {
                bool asistio = false;
                bool abono = false;
                bool reservado = false;
                if (r.ItemArray[7].ToString() == "1") { asistio = true; }
                if (r.ItemArray[10].ToString() == "1") { abono = true; }
                if (r.ItemArray[11].ToString() == "1") { reservado = true; }

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
                    r.ItemArray[6], r.ItemArray[9], reservado, cargarEmpresaClub(new Guid(r.ItemArray[0].ToString()))[1]);
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
                        r.ItemArray[6], Guid.Empty, reservado, string.Empty);
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

    }
}
