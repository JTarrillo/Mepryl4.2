using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using Comunes;

namespace CapaDatosMepryl
{
    public class MesaEntrada
    {
        string test;
        DataTable prueba;

        public DataTable cargarTiposDeExamen(string idMotivoConsulta)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, descripcion
            from dbo.Especialidad
            where idMotivoConsulta = " + idMotivoConsulta + "  order by convert(int,codigo)");            
        }

        public DataTable cargarTiposDeExamenBuscar(string strValor)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, descripcion 
            from dbo.Especialidad
            where descripcion LIKE '%" + strValor + "%' order by convert(int,codigo)");
        }

        public void ActualizaTipoExamenIDConsulta(string IdConsulta, string IdEspecialidad)
        {
            List<string> updateIdTipoExamen = SQLConnector.generarListaParaProcedure("@idConsulta", "@idEspecialidad");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateTipoExamenPaciente", updateIdTipoExamen, IdConsulta, IdEspecialidad);
        }

        public void ActualizaIdentificadorConsulta(string IdConsulta, string Tipo, string NroIdentificador)
        {
            List<string> updateIdentiConsulta = SQLConnector.generarListaParaProcedure("@idConsulta", "@identificador", "@tipo");
            SQLConnector.executeProcedure("sp_Consulta_UpdateIdentificaExmPaciente", updateIdentiConsulta, IdConsulta, NroIdentificador, Tipo);
        }

        public void EliminaIdentificadorConsulta(string IdConsulta)
        {
            string strSQL = "";

            strSQL = "DELETE FROM dbo.ConsultaLaboral WHERE idTipoExamen = '" + IdConsulta + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        private DataTable crearTablaRetornoGrilla()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("IdConsulta");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("IdTipoExamen");
            retorno.Columns.Add("IdTurno");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Orden");
            retorno.Columns.Add("Tipo");
            retorno.Columns.Add("Tipo Examen");
            retorno.Columns.Add("Nº Examen");
            retorno.Columns.Add("Dni");
            retorno.Columns.Add("Apellido");
            retorno.Columns.Add("Nombre");
            retorno.Columns.Add("Observac. Turno");
            retorno.Columns.Add("Observac. Mesa Entrada");
            retorno.Columns.Add("RM");
            retorno.Columns.Add("FechaNaci");
            retorno.Columns[15].DataType = System.Type.GetType("System.Boolean");
            return retorno;
        }

        private DataTable crearTablaRetornoGrillaPlanilla()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("IdConsulta");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("IdTipoExamen");
            retorno.Columns.Add("IdTurno");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Orden");
            retorno.Columns.Add("Tipo");
            retorno.Columns.Add("TipoExamen");
            retorno.Columns.Add("NroExamen");
            retorno.Columns.Add("Dni");
            retorno.Columns.Add("Apellido");
            retorno.Columns.Add("Nombre");
            retorno.Columns.Add("ObservacTurno");
            retorno.Columns.Add("ObservacMesaEntrada");
            retorno.Columns.Add("RM");
            retorno.Columns.Add("FechaNaci");
            retorno.Columns.Add("Revisado");
            retorno.Columns[15].DataType = System.Type.GetType("System.Boolean");
            //retorno.Columns[17].DataType = System.Type.GetType("System.Boolean");
            return retorno;
        }

        public DataTable cargarMesaEntradaPlanilla()
        {
            DataTable retorno = crearTablaRetornoGrillaPlanilla();
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as IdConsulta, c.pacienteID as IdPaciente, 
            te.id as IdTipoExamen, te.idTurno as IdTurno, Format(c.fecha, 'dd-MM-yyyy hh:mm', 'en-US') as Fecha, c.nroOrden as 'Nº Ingreso', c.tipo as Tipo, c.identificador as 'Nº Orden',
            c.observaciones as Observaciones, e.descripcion as 'Tipo de Exámen', te.rm, te.modificado, c.revisado
            from Consulta c
            inner join dbo.TipoExamenDePaciente te on te.idConsulta = c.id
            inner join dbo.Especialidad e on te.idEspecialidad = e.id
            where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.valido = '1' and c.nroOrden != '0' and c.tipo != 'V' order by c.nroOrden");
            foreach (DataRow row in consulta.Rows)
            {
                procesarFilaTablaGrillaPlanilla(ref retorno, row);
            }
            return retorno;
        }

        private void procesarFilaTablaGrillaPlanilla(ref DataTable retorno, DataRow fila)
        {
            List<object> list = cargarDatosPaciente(new Guid(fila.ItemArray[1].ToString()));
            Guid idTurno = new Guid(fila[3].ToString());
            retorno.Rows.Add(fila.ItemArray[0], fila.ItemArray[1], fila.ItemArray[2], fila.ItemArray[3],
                Convert.ToDateTime(fila.ItemArray[4]).ToShortDateString(), String.Format("{0:HH:mm}", Convert.ToDateTime(fila.ItemArray[4])),
                fila.ItemArray[5], fila.ItemArray[6], fila.ItemArray[9].ToString() + " " + fila.ItemArray[11].ToString(), fila.ItemArray[7],
                devolverStringLista(list, 0), devolverStringLista(list, 1), devolverStringLista(list, 2),
                cargarObservacionesTurno(new Guid(fila.ItemArray[3].ToString())), fila.ItemArray[8],
                devolverBooleano(fila.ItemArray[10]), devolverStringLista(list, 3), fila.ItemArray[12].ToString());
        }

        public void RevisarPaciente(string IdConsulta, bool blnEstado)
        {
            sbyte intNro = 0;
            string strSQL = "";

            if (blnEstado == true)
            {
                intNro = 1;
            }

            strSQL = "UPDATE dbo.Consulta " +
                     "SET revisado = " + intNro + " " +
                     "WHERE id = '" + IdConsulta + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool Revisado(string IdConsulta)
        {
            bool blnRevisado = false;

            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString("SELECT Revisado from dbo.Consulta WHERE id = '" + IdConsulta + "'");

            if (consulta.Rows.Count > 0)
            {
                blnRevisado = Convert.ToBoolean(consulta.Rows[0][0].ToString());
            }

            return blnRevisado;
        }


        public DataTable cargarMesaEntrada()
        {
            DataTable retorno = crearTablaRetornoGrilla();
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(
             @"select c.id as IdConsulta, c.pacienteID as IdPaciente, 
            te.id as IdTipoExamen, te.idTurno as IdTurno, Format(c.fecha, 'dd-MM-yyyy hh:mm', 'en-US') as Fecha, c.nroOrden as 'Nº Ingreso', c.tipo as Tipo, c.identificador as 'Nº Orden',
            c.observaciones as Observaciones, e.descripcion as 'Tipo de Exámen', te.rm, te.modificado
            from Consulta c
            inner join dbo.TipoExamenDePaciente te on te.idConsulta = c.id
            inner join dbo.Especialidad e on te.idEspecialidad = e.id
            where convert(Date,c.fecha) = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' and c.valido = '1' and c.nroOrden != '0' and c.tipo != 'V' order by c.nroOrden"
          );
            foreach (DataRow row in consulta.Rows)
            {
                procesarFilaTablaGrilla(ref retorno, row);
            }
            return retorno;
        }

        public DataTable cargarMesaEntradaVista()
        {
            DataTable retorno = crearTablaRetornoGrilla();
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as IdConsulta, c.pacienteID as IdPaciente, 
            te.id as IdTipoExamen, te.idTurno as IdTurno, Format(c.fecha, 'dd-MM-yyyy hh:mm', 'en-US') as Fecha, c.nroOrden as 'Nº Ingreso', c.tipo as Tipo, c.identificador as 'Nº Orden',
            c.observaciones as Observaciones, e.descripcion as 'Tipo de Exámen', te.rm, te.modificado
            from Consulta c
            inner join dbo.TipoExamenDePaciente te on te.idConsulta = c.id
            inner join dbo.Especialidad e on te.idEspecialidad = e.id
            where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.valido = '1' and c.nroOrden != '0' and c.tipo != 'V' order by c.nroOrden");
            foreach (DataRow row in consulta.Rows)
            {
                procesarFilaTablaGrilla(ref retorno, row);
            }
            return retorno;
        }

        public DataTable exportarMesaEntrada(DateTime dtDesde, DateTime dtHasta)
        {
            string strSQL = "";
            DataTable dtConsulta;

            strSQL = "SELECT CONVERT(DATE, c.fecha, 105) AS 'Fecha', c.identificador AS 'Nro Ex', " +
                     "       e.descripcion AS 'Tipo Ex', p.dni AS 'DNI', p.apellido AS 'Apellido', p.nombres AS 'Nombre', " +
                     "       CONVERT(DATE, p.fechaNacimiento, 103) AS 'Nacimiento', cb.descripcion AS 'Club', " +
                     "       RX = " +
                     "              CASE " +
                     "                WHEN tep.modificado = '(*)' THEN 'X' " +
                     "              END, " +
                     "      p.telefonos AS 'Telefono', p.celular AS 'Celular', p.Email AS 'E-Mail' " +
                     "FROM dbo.Consulta c " +
                     "INNER JOIN dbo.TipoExamenDePaciente tep ON tep.idConsulta = c.id " +
                     "INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id " +
                     "INNER JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id " +
                     "INNER JOIN dbo.Paciente p ON p.id = c.pacienteID " +
                     "INNER JOIN dbo.clubesPorTipoExamen cpe ON cpe.idTipoExamen = tep.id " +
                     "INNER JOIN dbo.Club cb ON cb.id = cpe.idClub " +
                     "WHERE CONVERT(DATE,c.fecha) >= '" + dtDesde.ToShortDateString() + "' AND CONVERT(DATE,c.fecha) <= '" + dtHasta.ToShortDateString() + "' AND c.nroOrden > 0 AND c.tipo = 'P' " +
                     "ORDER BY CONVERT(INT,c.nroOrden) ASC, c.fecha ASC";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtConsulta;
        }
        private void procesarFilaTablaGrilla(ref DataTable retorno, DataRow fila)
        {
            List<object> list = cargarDatosPaciente(new Guid(fila.ItemArray[1].ToString()));
            Guid idTurno = new Guid(fila[3].ToString());
            retorno.Rows.Add(fila.ItemArray[0], fila.ItemArray[1], fila.ItemArray[2], fila.ItemArray[3],
                Convert.ToDateTime(fila.ItemArray[4]).ToShortDateString(), String.Format("{0:HH:mm}", Convert.ToDateTime(fila.ItemArray[4])),
                fila.ItemArray[5], fila.ItemArray[6], fila.ItemArray[9].ToString() + " " + fila.ItemArray[11].ToString(), fila.ItemArray[7],
                devolverStringLista(list, 0), devolverStringLista(list, 1), devolverStringLista(list, 2),
                cargarObservacionesTurno(new Guid(fila.ItemArray[3].ToString())), fila.ItemArray[8],
                devolverBooleano(fila.ItemArray[10]), devolverStringLista(list, 3));
        }

        private bool devolverBooleano(object objeto)
        {
            if (objeto.ToString() == "1")
            {
                return true;
            }
            return false;
        }

        private string devolverStringLista(List<object> lista, int posicion)
        {
            if (lista.Count > 0)
            {
                return lista[posicion].ToString();
            }
            return string.Empty;
        }

        private string cargarObservacionesTurno(Guid idTurno)
        {
            if (idTurno != Guid.Empty)
            {
                DataTable observaciones = SQLConnector.obtenerTablaSegunConsultaString(@"select observaciones from dbo.Turno
                where id = '" + idTurno.ToString() + "'");
                if (observaciones.Rows.Count > 0) { return observaciones.Rows[0][0].ToString(); }
            }
            return string.Empty;
        }

        private List<object> cargarDatosPaciente(Guid idPaciente)
        {
            if (verificarTipoPaciente(idPaciente) == 'P')
            {
                return cargarDatosPacientePreventiva(idPaciente);
            }
            return cargarDatosPacienteLaboral(idPaciente);
        }

        private List<object> cargarDatosPacientePreventiva(Guid idPaciente)
        {
            List<object> retorno = new List<object>();
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            DataTable datos = SQLConnector.obtenerTablaSegunConsultaString(@"select dni, apellido, nombres,
            CONVERT(VARCHAR(10), fechaNacimiento, 103) as 'fechaNacimiento', telefonos, celular, Email
            from dbo.Paciente where id = '" + idPaciente.ToString() + "'");
            if (datos.Rows.Count > 0)
            {
                retorno[0] = datos.Rows[0][0].ToString();
                retorno[1] = datos.Rows[0][1].ToString();
                retorno[2] = datos.Rows[0][2].ToString();
                retorno[3] = datos.Rows[0][3].ToString();
                retorno[4] = datos.Rows[0][4].ToString();
                retorno[5] = datos.Rows[0][5].ToString();
                retorno[6] = datos.Rows[0][6].ToString();

            }
            return retorno;           
        }

        private List<object> cargarDatosPacienteLaboral(Guid idPaciente)
        {
            List<object> retorno = new List<object>();
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            retorno.Add("");
            DataTable datos = SQLConnector.obtenerTablaSegunConsultaString(@"select dni, apellido, nombres,
            CONVERT(VARCHAR(10), fechaNacimiento,103), telefonos, celular, mail 
            from dbo.PacienteLaboral where id = '" + idPaciente.ToString() + "'");
            if (datos.Rows.Count > 0)
            {
                retorno[0] = datos.Rows[0][0].ToString();
                retorno[1] = datos.Rows[0][1].ToString();
                retorno[2] = datos.Rows[0][2].ToString();
                retorno[3] = datos.Rows[0][3].ToString();
                retorno[4] = datos.Rows[0][4].ToString();
                retorno[5] = datos.Rows[0][5].ToString();
                retorno[6] = datos.Rows[0][6].ToString();
            }
            return retorno;
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

        public DataTable cargarTunosSegunMotivoDeConsulta(string idMotivo)
        {
            DataTable retorno = crearTablaRetornoTurnos();
            DataTable turnosPendientesIngreso = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id as Id, 
            convert(date,t.fecha) as Fecha,t.hora as Hora, e.descripcion as 'Tipo de Exámen', 
            mc.nombre as 'Motivo de Consulta', t.codigo as Código, 
            t.observaciones as Observaciones, t.pacienteID as IdPaciente, te.id,
            te.modificado           
            from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            inner join dbo.TipoExamenDePaciente te on te.idTurno = t.id
            where t.recepcion = '1' and mc.id = " + idMotivo + " and (t.mesaDeEntrada = '0' or t.mesaDeEntrada = '')");
            foreach (DataRow row in turnosPendientesIngreso.Rows)
            {
                procesarFilaTablaTurnos(ref retorno, row);
            }
            return retorno;
        }

        private DataTable crearTablaRetornoTurnos()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("IdTurno");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("TipoExamen");
            retorno.Columns.Add("Apellido");
            retorno.Columns.Add("Nombre");
            retorno.Columns.Add("MotivoConsulta");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Observaciones");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("IdTipoExamen");
            retorno.Columns.Add("Dni");
            return retorno;
        }

        private void procesarFilaTablaTurnos(ref DataTable retorno, DataRow fila)
        {
            List<object> list = cargarDatosPaciente(new Guid(fila.ItemArray[7].ToString()));
            retorno.Rows.Add(fila.ItemArray[0],
            Convert.ToDateTime(fila.ItemArray[1]).ToShortDateString(), fila.ItemArray[2],
            fila.ItemArray[3].ToString() + " " + fila.ItemArray[9].ToString(),
            devolverStringLista(list, 1), devolverStringLista(list, 2), 
            fila.ItemArray[4],  fila.ItemArray[5], fila.ItemArray[6], fila.ItemArray[7],
            fila.ItemArray[8], devolverStringLista(list, 0));
        }

        public Entidades.MesaEntrada cargarInformacionConsulta(Guid idConsulta)
        {
            Entidades.MesaEntrada retorno = new Entidades.MesaEntrada();
            DataTable infoConsulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.nroOrden, c.identificador, 
            c.pacienteID, c.observaciones, c.idTurno, tep.id from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep 
            on tep.idConsulta = c.id
            where c.id = '" + idConsulta.ToString() + "'");
            if (infoConsulta.Rows.Count > 0)
            {
                retorno.NroOrden = infoConsulta.Rows[0][0].ToString();
                retorno.NroExamen = infoConsulta.Rows[0][1].ToString();
                List<object> infoPaciente = cargarDatosPaciente(new Guid(infoConsulta.Rows[0][2].ToString()));
                retorno.ObservacionesMesaEntrada = infoConsulta.Rows[0][3].ToString();
                retorno.ObservacionesTurno = cargarObservacionesTurno(new Guid(infoConsulta.Rows[0][4].ToString()));
                retorno.Dni = infoPaciente[0].ToString();
                retorno.Apellido = infoPaciente[1].ToString();
                retorno.Nombre = infoPaciente[2].ToString();
                if (infoPaciente[3].ToString() != string.Empty && Convert.ToDateTime(infoPaciente[3].ToString()) != new DateTime(1800, 1, 1))
                {
                    retorno.Nacimiento = Convert.ToDateTime(infoPaciente[3].ToString()).ToShortDateString();
                }
                retorno.Telefono = infoPaciente[4].ToString();
                retorno.Celular = infoPaciente[5].ToString();
                retorno.ClubesOEmpresa = cargarClubesOEmpresa(idConsulta);
                TipoExamen tipoEx = new TipoExamen();
                retorno.TipoExamen = tipoEx.cargarEstudiosPorExamen(infoConsulta.Rows[0][5].ToString());
                retorno.Mail = infoPaciente[6].ToString();
            }
            return retorno;
        }

        private DataTable cargarClubesOEmpresa(Guid idConsulta)
        {
            DataTable retorno = new DataTable();
            DataTable idTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select id from
            dbo.TipoExamenDePaciente where idConsulta = '" + idConsulta + "'");
            if (idTipoExamen.Rows.Count > 0)
            {
                DataTable ligaYClubes = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion, 
                c.descripcion, c.id from dbo.clubesPorTipoExamen cte inner join dbo.Club c 
                on cte.idClub = c.id inner join dbo.Liga l on c.ligaID = l.id
                where cte.idTipoExamen = '" + idTipoExamen.Rows[0][0].ToString() + "'");
                if (ligaYClubes.Rows.Count > 0)
                {
                    procesarRetornoEmpresaOClub(ref retorno, ligaYClubes, "Liga", "Club", "IdClub");
                }
                else
                {
                    DataTable empresaYTarea = SQLConnector.obtenerTablaSegunConsultaString(@"select e.razonSocial, 
                    ete.tarea, e.id from dbo.empresaPorTipoDeExamen ete inner join dbo.Empresa e on ete.idEmpresa = e.id
                    where ete.idTipoExamen = '" + idTipoExamen.Rows[0][0].ToString() + "'");
                    procesarRetornoEmpresaOClub(ref retorno, empresaYTarea, "Empresa", "Tarea", "IdEmpresa");            
                }
            }
            return retorno;
        }

        private void procesarRetornoEmpresaOClub(ref DataTable retorno, DataTable datos, string nombreCol0, string nombreCol1, string nombreCol2)
        {
            retorno.Columns.Add(nombreCol0);
            retorno.Columns.Add(nombreCol1);
            retorno.Columns.Add(nombreCol2);
            foreach (DataRow r in datos.Rows)
            {
                retorno.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2]);
            }
        }

        public Entidades.Resultado verificarIngresoTurno(Guid idTurno)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();

            DataTable infoTurno = SQLConnector.obtenerTablaSegunConsultaString(@"select t.pacienteID, 
            mc.identificadorInterno from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            where t.id = '" + idTurno.ToString() + "'");

            return retorno;
        }

        public Entidades.Resultado ingresarTurno(Guid idTurno)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            DataTable infoTurno = SQLConnector.obtenerTablaSegunConsultaString(@"select t.pacienteID, 
            mc.identificadorInterno from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            where t.id = '" + idTurno.ToString() + "'");










            return retorno;
            /*string motivo = dgvTurno.SelectedRows[0].Cells[6].Value.ToString();
                        string idConsulta = "";
                        if (motivo == "PREVENTIVA")
                            idConsulta = insertarEnBaseDeDatosPreventiva("P", 0, "");
                        if (motivo == "LABORAL")
                            idConsulta = insertarEnBaseDeDatosOtros("L", 0, "");
                        if (motivo == "CONSULTAS")
                            idConsulta = insertarEnBaseDeDatosOtros("CO", 0, "");
                        if (motivo == "REPETICIONES")
                            idConsulta = insertarEnBaseDeDatosOtros("R", 0, "");
                        if (motivo == "ESTUDIOS COMPLEMENTARIOS")
                            idConsulta = insertarEnBaseDeDatosOtros("EC", 0, "");


                        List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
                        SQLConnector.executeProcedure("sp_Turno_UpdateMesaDeEntrada", lista, dgvTurno.SelectedRows[0].Cells[0].Value.ToString(), "1");

                        List<string> list = SQLConnector.generarListaParaProcedure("@idTurno", "@idConsulta");
                        SQLConnector.executeProcedure("sp_Items_UpdateItemsPorPaciente", list, dgvTurno.SelectedRows[0].Cells[0].Value.ToString(), idConsulta);

                        if (motivo == "PREVENTIVA")
                        {
                            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select pacienteID from dbo.Consulta
                        where id = '" + idConsulta + "'");
                            if (consulta.Rows.Count > 0)
                            {
                                string paciente = consulta.Rows[0].ItemArray[0].ToString();
                                DataTable clubesPorPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.clubesPorPaciente
                            where paciente = '" + paciente + "'");
                                if (clubesPorPaciente.Rows.Count > 0)
                                {
                                    DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.TipoExamenDePaciente
                                where idConsulta = '" + idConsulta + "'");

                                    if (tipoExamen.Rows.Count > 0)
                                    {

                                        string idTe = tipoExamen.Rows[0].ItemArray[0].ToString();

                                        DataTable clubesPorTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * 
                                    from dbo.clubesPorTipoExamen where idTipoExamen = '" + idTe + "'");
                                        if (clubesPorTipoExamen.Rows.Count == 0)
                                        {
                                            List<string> add = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                                            foreach (DataRow r in clubesPorPaciente.Rows)
                                            {
                                                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add",
                                                    add, new Guid(idTe), new Guid(r.ItemArray[2].ToString()));

                                            }
                                        }

                                        exPreventiva.crearExamen(idTe);
                                    }

                                    
                                }
                            }
                        }
                        else
                        {
                            generarLaboral(idConsulta);
                        }*/


        }

        public DataTable cargarParametrosReporteHojaRuta(string idConsulta)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("nroOrden");
            retorno.Columns.Add("nroId");
            retorno.Columns.Add("tipoExamen");
            retorno.Columns.Add("fechaExamen");
            retorno.Columns.Add("liga1");
            retorno.Columns.Add("club1");
            retorno.Columns.Add("liga2");
            retorno.Columns.Add("club2");
            retorno.Columns.Add("liga3");
            retorno.Columns.Add("club3");
            retorno.Columns.Add("liga4");
            retorno.Columns.Add("club4");
            retorno.Columns.Add("nombre");
            retorno.Columns.Add("nacimiento");
            retorno.Columns.Add("dni");
            retorno.Columns.Add("tarea");
            retorno.Columns.Add("telefono");
            retorno.Columns.Add("item1");
            retorno.Columns.Add("item2");
            retorno.Columns.Add("item3");
            retorno.Columns.Add("item4");
            retorno.Columns.Add("item5");
            retorno.Columns.Add("item6");
            retorno.Columns.Add("item7");
            retorno.Columns.Add("item8");
            retorno.Columns.Add("item9");
            retorno.Columns.Add("item10");
            retorno.Columns.Add("item11");
            retorno.Columns.Add("item12");
            retorno.Columns.Add("item13");
            retorno.Columns.Add("item14");
            retorno.Columns.Add("item15");
            retorno.Columns.Add("item16");
            retorno.Columns.Add("item17");
            retorno.Columns.Add("item18");
            retorno.Columns.Add("item19");
            retorno.Columns.Add("item20");
            retorno.Columns.Add("item21");
            retorno.Columns.Add("estudios");
            retorno.Columns.Add("item22");
            retorno.Columns.Add("item23");
            retorno.Columns.Add("item24");
            retorno.Columns.Add("item25");
            retorno.Columns.Add("item26");
            retorno.Columns.Add("item27");
            retorno.Columns.Add("item28");


            DataTable info = cargarInfoBasicaReportes(idConsulta);

            if (info.Rows.Count > 0)
            {
                return procesarRetornoReporteHojaRuta(retorno, info);
            }
            return tablaVacia(retorno);
        }

        public DataTable cargarParametrosReporteHojaRuta(string idConsulta, string mail)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("nroOrden");
            retorno.Columns.Add("nroId");
            retorno.Columns.Add("tipoExamen");
            retorno.Columns.Add("fechaExamen");
            retorno.Columns.Add("liga1");
            retorno.Columns.Add("club1");
            retorno.Columns.Add("liga2");
            retorno.Columns.Add("club2");
            retorno.Columns.Add("liga3");
            retorno.Columns.Add("club3");
            retorno.Columns.Add("liga4");
            retorno.Columns.Add("club4");
            retorno.Columns.Add("nombre");
            retorno.Columns.Add("nacimiento");
            retorno.Columns.Add("dni");
            retorno.Columns.Add("tarea");
            retorno.Columns.Add("telefono");
            retorno.Columns.Add("item1");
            retorno.Columns.Add("item2");
            retorno.Columns.Add("item3");
            retorno.Columns.Add("item4");
            retorno.Columns.Add("item5");
            retorno.Columns.Add("item6");
            retorno.Columns.Add("item7");
            retorno.Columns.Add("item8");
            retorno.Columns.Add("item9");
            retorno.Columns.Add("item10");
            retorno.Columns.Add("item11");
            retorno.Columns.Add("item12");
            retorno.Columns.Add("item13");
            retorno.Columns.Add("item14");
            retorno.Columns.Add("item15");
            retorno.Columns.Add("item16");
            retorno.Columns.Add("item17");
            retorno.Columns.Add("item18");
            retorno.Columns.Add("item19");
            retorno.Columns.Add("item20");
            retorno.Columns.Add("item21");
            retorno.Columns.Add("estudios");
            retorno.Columns.Add("item22");
            retorno.Columns.Add("item23");
            retorno.Columns.Add("item24");
            retorno.Columns.Add("item25");
            retorno.Columns.Add("item26");
            retorno.Columns.Add("item27");
            retorno.Columns.Add("item28");
            retorno.Columns.Add("mail");

            DataTable info = cargarInfoBasicaReportes(idConsulta);

            if (info.Rows.Count > 0)
            {
                return procesarRetornoReporteHojaRuta(retorno, info, mail);
            }
            return tablaVacia(retorno);
        }

        private DataTable procesarRetornoReporteHojaRuta(DataTable retorno, DataTable info, string mail)
        {
            DataRow datoPaciente = cargarDatoPaciente(info.Rows[0][8].ToString());
            DataTable clubesOEmpresa = cargarClubesOEmpresa(new Guid(info.Rows[0][0].ToString()));
            List<string> paramLigaClubOEmpTarea = new List<string>();
            for (int i = 0; i <= 7; i++)
            {
                paramLigaClubOEmpTarea.Add("");
            }
            int cont = 0;
            foreach (DataRow dr in clubesOEmpresa.Rows)
            {
                paramLigaClubOEmpTarea[cont] = dr[0].ToString();
                cont++;
                paramLigaClubOEmpTarea[cont] = dr[1].ToString();
                cont++;
            }
            string telefono = "";
            if (datoPaciente[3].ToString() != string.Empty) { telefono = datoPaciente[3].ToString(); }
            if (datoPaciente[4].ToString() != string.Empty)
            {
                if (telefono == string.Empty)
                {
                    telefono = datoPaciente[4].ToString();
                }
                else
                {
                    telefono = telefono + "/" + datoPaciente[4].ToString();
                }
            }

            string tarea = "";
            if (verificarTipoPaciente(new Guid(info.Rows[0][8].ToString())) == 'L')
            {
                tarea = paramLigaClubOEmpTarea[1];
                paramLigaClubOEmpTarea[1] = string.Empty;
            }

            Laboral laboral = new Laboral();

            DataTable estudiosPorExamen = laboral.consultarItemsPorTipoExamenSegunIdConsulta(info.Rows[0].ItemArray[0].ToString());

            List<string> paramEstudiosPorExamen = new List<string>();
            for (int i = 0; i <= 28; i++)
            {
                paramEstudiosPorExamen.Add("");
            }

            procesarParametrosEstudiosString(ref paramEstudiosPorExamen, 0, 3, estudiosPorExamen.Select("ordenFormulario = 1"));
            procesarParametrosEstudiosString(ref paramEstudiosPorExamen, 4, 15, estudiosPorExamen.Select(@"ordenFormulario = 8 or ordenFormulario = 9
            or ordenFormulario = 10 or ordenFormulario = 11"));
            procesarParametrosEstudiosString(ref paramEstudiosPorExamen, 16, 27, estudiosPorExamen.Select("ordenFormulario = 12"));
            procesarParametrosEstudiosTextBox(ref paramEstudiosPorExamen, estudiosPorExamen.Select(@"ordenFormulario = 2 or ordenFormulario = 3
            or ordenFormulario = 4 or ordenFormulario = 5 or ordenFormulario = 6 or ordenFormulario = 7"));


            retorno.Rows.Add(info.Rows[0][1].ToString(), info.Rows[0][2].ToString(),
            info.Rows[0][4].ToString() + " " + info.Rows[0][5].ToString(),
            procesarFechaString(info.Rows[0][6].ToString()),
            paramLigaClubOEmpTarea[0], paramLigaClubOEmpTarea[1], paramLigaClubOEmpTarea[2],
            paramLigaClubOEmpTarea[3], paramLigaClubOEmpTarea[4], paramLigaClubOEmpTarea[5],
            paramLigaClubOEmpTarea[6], paramLigaClubOEmpTarea[7],
            datoPaciente[1].ToString(), procesarFechaString(datoPaciente[2].ToString()),
            datoPaciente[0].ToString(), tarea, telefono, paramEstudiosPorExamen[0],
            paramEstudiosPorExamen[1], paramEstudiosPorExamen[2], paramEstudiosPorExamen[3],
            paramEstudiosPorExamen[4], paramEstudiosPorExamen[5], paramEstudiosPorExamen[6],
            paramEstudiosPorExamen[7], paramEstudiosPorExamen[8], paramEstudiosPorExamen[9],
            paramEstudiosPorExamen[10], paramEstudiosPorExamen[11], paramEstudiosPorExamen[12],
            paramEstudiosPorExamen[13], paramEstudiosPorExamen[14], paramEstudiosPorExamen[15],
            paramEstudiosPorExamen[16], paramEstudiosPorExamen[17], paramEstudiosPorExamen[18],
            paramEstudiosPorExamen[19], paramEstudiosPorExamen[20], paramEstudiosPorExamen[28],
            paramEstudiosPorExamen[21], paramEstudiosPorExamen[22], paramEstudiosPorExamen[23],
            paramEstudiosPorExamen[24], paramEstudiosPorExamen[25], paramEstudiosPorExamen[26],
            paramEstudiosPorExamen[27], mail);
            return retorno;

        }

        private DataTable procesarRetornoReporteHojaRuta(DataTable retorno, DataTable info)
        {
            DataRow datoPaciente = cargarDatoPaciente(info.Rows[0][8].ToString());
            DataTable clubesOEmpresa = cargarClubesOEmpresa(new Guid(info.Rows[0][0].ToString()));
            List<string> paramLigaClubOEmpTarea = new List<string>();
            for (int i = 0; i <= 7; i++)
            {
                paramLigaClubOEmpTarea.Add("");
            }
            int cont = 0;
            foreach (DataRow dr in clubesOEmpresa.Rows)
            {
                paramLigaClubOEmpTarea[cont] = dr[0].ToString();
                cont++;
                paramLigaClubOEmpTarea[cont] = dr[1].ToString();
                cont++;
            }
            string telefono = "";
            if (datoPaciente[3].ToString() != string.Empty) { telefono = datoPaciente[3].ToString(); }
            if (datoPaciente[4].ToString() != string.Empty)
            {
                if (telefono == string.Empty)
                {
                    telefono = datoPaciente[4].ToString();
                }
                else
                {
                    telefono = telefono + "/" + datoPaciente[4].ToString();
                }
            }

            string tarea = "";
            if (verificarTipoPaciente(new Guid(info.Rows[0][8].ToString())) == 'L')
            {
                tarea = paramLigaClubOEmpTarea[1];
                paramLigaClubOEmpTarea[1] = string.Empty;
            }

            Laboral laboral = new Laboral();

            DataTable estudiosPorExamen = laboral.consultarItemsPorTipoExamenSegunIdConsulta(info.Rows[0].ItemArray[0].ToString());

            List<string> paramEstudiosPorExamen = new List<string>();
            for (int i = 0; i <= 28; i++)
            {
                paramEstudiosPorExamen.Add("");
            }

            procesarParametrosEstudiosString(ref paramEstudiosPorExamen, 0, 3, estudiosPorExamen.Select("ordenFormulario = 1"));
            procesarParametrosEstudiosString(ref paramEstudiosPorExamen, 4, 15, estudiosPorExamen.Select(@"ordenFormulario = 8 or ordenFormulario = 9
            or ordenFormulario = 10 or ordenFormulario = 11"));
            procesarParametrosEstudiosString(ref paramEstudiosPorExamen, 16, 27, estudiosPorExamen.Select("ordenFormulario = 12"));
            procesarParametrosEstudiosTextBox(ref paramEstudiosPorExamen, estudiosPorExamen.Select(@"ordenFormulario = 2 or ordenFormulario = 3
            or ordenFormulario = 4 or ordenFormulario = 5 or ordenFormulario = 6 or ordenFormulario = 7"));


            retorno.Rows.Add(info.Rows[0][1].ToString(), info.Rows[0][2].ToString(),
            info.Rows[0][4].ToString() + " " + info.Rows[0][5].ToString(),
            procesarFechaString(info.Rows[0][6].ToString()),
            paramLigaClubOEmpTarea[0], paramLigaClubOEmpTarea[1], paramLigaClubOEmpTarea[2],
            paramLigaClubOEmpTarea[3], paramLigaClubOEmpTarea[4], paramLigaClubOEmpTarea[5],
            paramLigaClubOEmpTarea[6], paramLigaClubOEmpTarea[7],
            datoPaciente[1].ToString(), procesarFechaString(datoPaciente[2].ToString()),
            datoPaciente[0].ToString(), tarea, telefono, paramEstudiosPorExamen[0],
            paramEstudiosPorExamen[1], paramEstudiosPorExamen[2], paramEstudiosPorExamen[3],
            paramEstudiosPorExamen[4], paramEstudiosPorExamen[5], paramEstudiosPorExamen[6],
            paramEstudiosPorExamen[7], paramEstudiosPorExamen[8], paramEstudiosPorExamen[9],
            paramEstudiosPorExamen[10], paramEstudiosPorExamen[11], paramEstudiosPorExamen[12],
            paramEstudiosPorExamen[13], paramEstudiosPorExamen[14], paramEstudiosPorExamen[15],
            paramEstudiosPorExamen[16], paramEstudiosPorExamen[17], paramEstudiosPorExamen[18],
            paramEstudiosPorExamen[19], paramEstudiosPorExamen[20], paramEstudiosPorExamen[28],
            paramEstudiosPorExamen[21], paramEstudiosPorExamen[22], paramEstudiosPorExamen[23],
            paramEstudiosPorExamen[24], paramEstudiosPorExamen[25], paramEstudiosPorExamen[26],
            paramEstudiosPorExamen[27], info.Rows[0][9].ToString());
            return retorno;

        }

        public DataTable cargarParametrosReporteExClinico(string idConsulta)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("nroOrden");
            retorno.Columns.Add("nroId");
            retorno.Columns.Add("tipoExamen");
            retorno.Columns.Add("fechaExamen");
            retorno.Columns.Add("liga1");
            retorno.Columns.Add("club1");
            retorno.Columns.Add("liga2");
            retorno.Columns.Add("club2");
            retorno.Columns.Add("liga3");
            retorno.Columns.Add("club3");
            retorno.Columns.Add("liga4");
            retorno.Columns.Add("club4");
            retorno.Columns.Add("nombre");
            retorno.Columns.Add("nacimiento");
            retorno.Columns.Add("dni");
            retorno.Columns.Add("tarea");
            retorno.Columns.Add("telefono");
            retorno.Columns.Add("rm");

            DataTable info = cargarInfoBasicaReportes(idConsulta);

            if (info.Rows.Count > 0)
            {
                return procesarRetornoReporteClinico(retorno, info);
            }
            return tablaVacia(retorno);
        }

        public DataTable cargarParametrosReporteExClinico(string idConsulta, string mail)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("nroOrden");
            retorno.Columns.Add("nroId");
            retorno.Columns.Add("tipoExamen");
            retorno.Columns.Add("fechaExamen");
            retorno.Columns.Add("liga1");
            retorno.Columns.Add("club1");
            retorno.Columns.Add("liga2");
            retorno.Columns.Add("club2");
            retorno.Columns.Add("liga3");
            retorno.Columns.Add("club3");
            retorno.Columns.Add("liga4");
            retorno.Columns.Add("club4");
            retorno.Columns.Add("nombre");
            retorno.Columns.Add("nacimiento");
            retorno.Columns.Add("dni");
            retorno.Columns.Add("tarea");
            retorno.Columns.Add("telefono");
            retorno.Columns.Add("mail");
            retorno.Columns.Add("rm");

            DataTable info = cargarInfoBasicaReportes(idConsulta);

            if (info.Rows.Count > 0)
            {
                return procesarRetornoReporteClinico(retorno, info, mail);
            }
            return tablaVacia(retorno);
        }

        private DataTable procesarRetornoReporteClinico(DataTable retorno, DataTable info, string mail)
        {
            prueba = info;
            DataRow datoPaciente = cargarDatoPaciente(info.Rows[0][8].ToString());
            DataTable clubesOEmpresa = cargarClubesOEmpresa(new Guid(info.Rows[0][0].ToString()));
            List<string> paramLigaClubOEmpTarea = new List<string>();
            for (int i = 0; i <= 7; i++)
            {
                paramLigaClubOEmpTarea.Add("");
            }
            int cont = 0;
            foreach (DataRow dr in clubesOEmpresa.Rows)
            {
                paramLigaClubOEmpTarea[cont] = dr[0].ToString();
                cont++;
                paramLigaClubOEmpTarea[cont] = dr[1].ToString();
                cont++;
            }
            string rm = "";
            if (info.Rows[0][7].ToString() == "1") { rm = "R.M."; }
            string telefono = "";
            if (datoPaciente[3].ToString() != string.Empty) { telefono = datoPaciente[3].ToString(); }
            if (datoPaciente[4].ToString() != string.Empty)
            {
                if (telefono == string.Empty)
                {
                    telefono = datoPaciente[4].ToString();
                }
                else
                {
                    telefono = telefono + "/" + datoPaciente[4].ToString();
                }
            }

            string tarea = "";
            if (verificarTipoPaciente(new Guid(info.Rows[0][8].ToString())) == 'L')
            {
                tarea = paramLigaClubOEmpTarea[1];
                paramLigaClubOEmpTarea[1] = string.Empty;
            }

            retorno.Rows.Add(info.Rows[0][1].ToString(), info.Rows[0][2].ToString(),
            info.Rows[0][4].ToString() + " " + info.Rows[0][5].ToString(),
            procesarFechaString(info.Rows[0][6].ToString()),
            paramLigaClubOEmpTarea[0], paramLigaClubOEmpTarea[1], paramLigaClubOEmpTarea[2],
            paramLigaClubOEmpTarea[3], paramLigaClubOEmpTarea[4], paramLigaClubOEmpTarea[5],
            paramLigaClubOEmpTarea[6], paramLigaClubOEmpTarea[7],
            datoPaciente[1].ToString(), procesarFechaString(datoPaciente[2].ToString()),
            datoPaciente[0].ToString(), tarea,
            telefono, mail, rm);
            return retorno;

        }

        private DataTable procesarRetornoReporteClinico(DataTable retorno, DataTable info)
        {
            prueba = info;
            DataRow datoPaciente = cargarDatoPaciente(info.Rows[0][8].ToString());
            DataTable clubesOEmpresa = cargarClubesOEmpresa(new Guid(info.Rows[0][0].ToString()));
            List<string> paramLigaClubOEmpTarea = new List<string>();
            for (int i = 0; i <= 7; i++)
            {
                paramLigaClubOEmpTarea.Add("");
            }
            int cont = 0;
            foreach (DataRow dr in clubesOEmpresa.Rows)
            {
                paramLigaClubOEmpTarea[cont] = dr[0].ToString();
                cont++;
                paramLigaClubOEmpTarea[cont] = dr[1].ToString();
                cont++;
            }
            string rm = "";
            if (info.Rows[0][7].ToString() == "1") { rm = "R.M."; }
            string telefono = "";
            if (datoPaciente[3].ToString() != string.Empty) { telefono = datoPaciente[3].ToString(); }
            if (datoPaciente[4].ToString() != string.Empty)
            {
                if (telefono == string.Empty)
                {
                    telefono = datoPaciente[4].ToString();
                }
                else
                {
                    telefono = telefono + "/" + datoPaciente[4].ToString();
                }
            }

            string tarea = "";
            if (verificarTipoPaciente(new Guid(info.Rows[0][8].ToString())) == 'L')
            {
                tarea = paramLigaClubOEmpTarea[1];
                paramLigaClubOEmpTarea[1] = string.Empty;
            }

            test = info.Rows[0][9].ToString();
            test = info.Rows[0][9].ToString();
            test = info.Rows[0][9].ToString();

            retorno.Rows.Add(info.Rows[0][1].ToString(), info.Rows[0][2].ToString(),
            info.Rows[0][4].ToString() + " " + info.Rows[0][5].ToString(),
            procesarFechaString(info.Rows[0][6].ToString()),
            paramLigaClubOEmpTarea[0], paramLigaClubOEmpTarea[1], paramLigaClubOEmpTarea[2],
            paramLigaClubOEmpTarea[3], paramLigaClubOEmpTarea[4], paramLigaClubOEmpTarea[5],
            paramLigaClubOEmpTarea[6], paramLigaClubOEmpTarea[7],
            datoPaciente[1].ToString(), procesarFechaString(datoPaciente[2].ToString()),
            datoPaciente[0].ToString(), tarea,
            telefono, info.Rows[0][9].ToString(), rm);
            return retorno;

        }

        private void procesarParametrosEstudiosString(ref List<string> listParam, int inicio, int fin, DataRow[] filtroEstudios)
        {
            int actual = inicio;
            foreach (DataRow dr in filtroEstudios)
            {
                if (actual <= fin)
                {
                    listParam[actual] = dr[1].ToString();
                }
                actual++;
            }
        }

        private void procesarParametrosEstudiosTextBox(ref List<string> listParam, DataRow[] filtroEstudios)
        {
            string cadena = "";
            foreach (DataRow dr in filtroEstudios)
            {
                if (cadena != string.Empty)
                {
                    cadena = cadena + " - " + dr[3].ToString();
                }
                else
                {
                    cadena = dr[3].ToString();
                }
            }
            listParam[28] = cadena;
        }


        private string procesarFechaString(string valor)
        {
            try
            {
                string valorRetorno = Convert.ToDateTime(valor).ToShortDateString();
                if (valorRetorno != "01-01-1800")
                {
                    return valorRetorno;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private DataTable tablaVacia(DataTable retorno)
        {
            retorno.Rows.Add();
            foreach (DataColumn dc in retorno.Columns)
            {
                retorno.Rows[0][dc.Ordinal] = string.Empty;
            }
            return retorno;
        }

        private DataTable cargarInfoBasicaReportes(string idConsulta)
        {
            DataTable info = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as idConsulta, c.nroOrden, c.identificador, tep.id as idTipoExamen,
            e.descripcion, tep.modificado, c.fecha, tep.rm, c.pacienteID from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id 
            where c.id = '" + idConsulta + "'");
            return info;

        }
        private DataTable cargarInfoBasicaReportes(string idConsulta, bool laboral)
        {
            DataTable info=new DataTable();
            if (laboral)
            {
                info = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as idConsulta, c.nroOrden, c.identificador, tep.id as idTipoExamen,e.descripcion, tep.modificado, c.fecha, tep.rm, c.pacienteID, pl.mail 
			    from dbo.Consulta c 
			    inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
                inner join dbo.Especialidad e on tep.idEspecialidad = e.id
			    inner join dbo.PacienteLaboral pl on pl.id=c.pacienteID 
                where c.id = '" + idConsulta + "'");
            }
            else if (!laboral)
            {
                info = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as idConsulta, c.nroOrden, c.identificador, tep.id as idTipoExamen,e.descripcion, tep.modificado, c.fecha, tep.rm, c.pacienteID, p.Email 
			    from dbo.Consulta c 
			    inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
                inner join dbo.Especialidad e on tep.idEspecialidad = e.id
			    inner join dbo.Paciente p on p.id=c.pacienteID
                where c.id = '" + idConsulta + "'");
            }
            return info;
        }

        private DataRow cargarDatoPaciente(string idPaciente)
        {
            DataTable pacientePreventiva = SQLConnector.obtenerTablaSegunConsultaString(@"
                    select p.dni, p.apellido + ' ' + p.nombres as Paciente, p.fechaNacimiento,
                    telefonos, celular
                    from dbo.Paciente p
                    where p.id = '" + idPaciente + "'");
            if (pacientePreventiva.Rows.Count > 0)
            {
                return pacientePreventiva.Rows[0];
            }
            else
            {
                DataTable pacienteLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"
                        select p.dni, p.apellido + ' ' + p.nombres as Paciente,
                        p.fechaNacimiento, telefonos, celular
                        from dbo.PacienteLaboral p
                        where p.id = '" + idPaciente + "'");
                return pacienteLaboral.Rows[0];
            }
        }

        public void actualizarClubPorTipoExamen(string idConsulta, string idPaciente)
        {
            Entidades.MesaEntrada entidad = cargarInformacionConsulta(new Guid(idConsulta));
            List<string> deleteClubes = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Delete", deleteClubes, entidad.TipoExamen.IdTipoExamenPaciente);

            DataTable clubesActuales = SQLConnector.obtenerTablaSegunConsultaString(@"select club from dbo.clubesPorPaciente
            where paciente = '" + idPaciente + "'");

            List<string> addClub = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
            foreach (DataRow r in clubesActuales.Rows)
            {
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", addClub, entidad.TipoExamen.IdTipoExamenPaciente,
                    new Guid(r.ItemArray[0].ToString()));
            }          
        }

        public void actualizarEmpresaPorTipoExamen(string idConsulta, string idPaciente, string idEmpresa)
        {
            Entidades.MesaEntrada entidad = cargarInformacionConsulta(new Guid(idConsulta));
            List<string> deleteEmpresa = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Delete", deleteEmpresa, entidad.TipoExamen.IdTipoExamenPaciente);

            DataTable empresaActual = SQLConnector.obtenerTablaSegunConsultaString(@"select tarea from dbo.EmpresasPorPaciente
            where idEmpresa = '" + idEmpresa + "' and idPaciente = '" + idPaciente + "'");

            if (empresaActual.Rows.Count > 0)
            {

                List<string> addEmpresa = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idEmpresa", "@tarea");
                SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Add", addEmpresa, entidad.TipoExamen.IdTipoExamenPaciente,
                    new Guid(idEmpresa), empresaActual.Rows[0][0].ToString());

            }     
        }

        public string ObtenerDNI(string strIdPaciente)
        {
            string strDNI = "";
            string strSQL = "";

            strSQL = "SELECT codigo FROM dbo.Paciente WHERE id = '" + strIdPaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strDNI = dtConsulta.Rows[0][0].ToString();
            }

            return strDNI;
        }

        private DataTable crearTablaRetornoGrillaPlanillaCompleta()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("IdConsulta");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("IdTipoExamen");
            retorno.Columns.Add("IdTurno");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Orden");
            retorno.Columns.Add("Tipo");
            retorno.Columns.Add("Subtipo de Examen");
            retorno.Columns.Add("NroExamen");
            retorno.Columns.Add("Dni");
            retorno.Columns.Add("Apellido");
            retorno.Columns.Add("Nombre");
            retorno.Columns.Add("ObservacTurno");
            retorno.Columns.Add("ObservacMesaEntrada");
            retorno.Columns.Add("RM");
            retorno.Columns.Add("FechaNaci");
            retorno.Columns.Add("Revisado");
            retorno.Columns[15].DataType = System.Type.GetType("System.Boolean");
            retorno.Columns.Add("Clinico");
            retorno.Columns.Add("Laboratorio");
            retorno.Columns.Add("RX");
            retorno.Columns.Add("Complementarios");
            retorno.Columns.Add("LigaEmpresa");
            retorno.Columns.Add("ClubTarea");
            retorno.Columns.Add("Modificado");
            retorno.Columns[24].DataType = System.Type.GetType("System.Boolean");

            return retorno;
        }

        private void procesarFilaTablaGrillaPlanillaCompleta(ref DataTable retorno, DataRow fila)
        {
            Entidades.MesaEntrada paciente = cargarInformacionConsulta(new Guid(fila.ItemArray[0].ToString())); 
            List<object> list = cargarDatosPaciente(new Guid(fila.ItemArray[1].ToString()));
            DataTable clubesOEmpresa = cargarClubesOEmpresa(new Guid(fila.ItemArray[0].ToString()));

            //Guid idTurno = new Guid(fila[3].ToString());
            

            retorno.Rows.Add(fila.ItemArray[0], fila.ItemArray[1], fila.ItemArray[2], fila.ItemArray[3],
                Convert.ToDateTime(fila.ItemArray[4]).ToShortDateString(), String.Format("{0:HH:mm}", Convert.ToDateTime(fila.ItemArray[4])),
                fila.ItemArray[5], fila.ItemArray[6], fila.ItemArray[9].ToString() + " " + fila.ItemArray[11].ToString(), fila.ItemArray[7],
                devolverStringLista(list, 0), devolverStringLista(list, 1), devolverStringLista(list, 2),
                cargarObservacionesTurno(new Guid(fila.ItemArray[3].ToString())), fila.ItemArray[8],
                devolverBooleano(fila.ItemArray[10]), devolverStringLista(list, 3), fila.ItemArray[12].ToString(),
                //  Nueva lìnea
                paciente.TipoExamen.TextoClinico, paciente.TipoExamen.TextoLaboratorio, paciente.TipoExamen.TextoRx,
                paciente.TipoExamen.TextoEstComplement, clubesOEmpresa.Rows[0][0].ToString(), clubesOEmpresa.Rows[0][1].ToString(),
                paciente.TipoExamen.Modificado);
        }

        public DataTable cargarMesaEntradaPlanillaCompleta()
        {
            DataTable retorno = crearTablaRetornoGrillaPlanillaCompleta();
            string fechaSql = DateTime.Today.ToString("yyyy-MM-dd");
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(
                @"select c.id as IdConsulta, c.pacienteID as IdPaciente, 
        te.id as IdTipoExamen, te.idTurno as IdTurno, Format(c.fecha, 'dd-MM-yyyy hh:mm', 'en-US') as Fecha, c.nroOrden as 'Nº Ingreso', c.tipo as Tipo, c.identificador as 'Nº Orden',
        c.observaciones as Observaciones, e.descripcion as 'Subtipo de Exámen', te.rm, te.modificado, c.revisado
        from Consulta c
        inner join dbo.TipoExamenDePaciente te on te.idConsulta = c.id
        inner join dbo.Especialidad e on te.idEspecialidad = e.id
        where convert(Date,c.fecha) = '" + fechaSql + "' and c.valido = '1' and c.nroOrden != '0' and c.tipo != 'V' order by c.nroOrden"
            );
            foreach (DataRow row in consulta.Rows)
            {
                procesarFilaTablaGrillaPlanillaCompleta(ref retorno, row);
            }
            return retorno;
        }
    }
}
