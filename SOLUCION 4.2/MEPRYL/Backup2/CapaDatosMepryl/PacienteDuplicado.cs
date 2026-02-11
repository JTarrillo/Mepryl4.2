using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunes;
using System.Data;

namespace CapaDatosMepryl
{
    public class PacienteDuplicado
    {
        public Entidades.PacienteDuplicado cargarDatosEntidad(string id)
        {
            Entidades.PacienteDuplicado retorno = new Entidades.PacienteDuplicado();
            DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString("select id, dni, apellido, nombres, fechaNacimiento from dbo.Paciente where id = '" + id + "'");
            if (paciente.Rows.Count > 0)
            {
                retorno.Id = new Guid(paciente.Rows[0][0].ToString());
                retorno.Dni = paciente.Rows[0][1].ToString();
                retorno.Apellido = paciente.Rows[0][2].ToString();
                retorno.Nombre = paciente.Rows[0][3].ToString();
                retorno.FechaNacimiento = Convert.ToDateTime(paciente.Rows[0][4].ToString()).ToShortDateString();
                retorno.ConsultasYExamenes = cargarTurnosYConsultas(id);
            }
            return retorno;
        }

        public void moverDatos(DataTable tablaDatos, string idPaciente)
        {
            foreach(DataRow dr in tablaDatos.Rows)
            {
                if (dr[2].ToString() == "CONSULTA"){ actualizarConsulta(dr[0].ToString(), idPaciente); }
                if (dr[2].ToString() == "TURNO") { actualizarTurno(dr[0].ToString(), idPaciente); }
            }
        }

        private void actualizarConsulta(string idConsulta, string idPaciente)
        {
            List<string> update = SQLConnector.generarListaParaProcedure("@id", "@idPaciente");
            SQLConnector.executeProcedure("sp_Consulta_UpdateIdPaciente", update, new Guid(idConsulta), new Guid(idPaciente));
        }

        private void actualizarTurno(string idTurno, string idPaciente)
        {
            List<string> update = SQLConnector.generarListaParaProcedure("@id", "@idPaciente");
            SQLConnector.executeProcedure("sp_Turno_UpdateIdPaciente", update, new Guid(idTurno), new Guid(idPaciente));
        }

        private DataTable cargarTurnosYConsultas(string id)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Tipo");
            retorno.Columns.Add("Especialidad");
            retorno.Columns.Add("Fecha1");

            DataTable turnos = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id, t.fecha, e.descripcion
            from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            where t.pacienteID = '" + id + "'");
            foreach(DataRow turn in turnos.Rows)
            {
                retorno.Rows.Add(turn[0].ToString(), Convert.ToDateTime(turn[1].ToString()).ToShortDateString(),
                    "TURNO", turn[2].ToString(), Convert.ToDateTime(turn[1].ToString()));
            }
            DataTable consultas = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.fecha, e.descripcion
            from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta 
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            where c.pacienteID = '" + id + "'");
            foreach (DataRow cons in consultas.Rows)
            {
                retorno.Rows.Add(cons[0].ToString(), Convert.ToDateTime(cons[1].ToString()).ToShortDateString(),
                    "CONSULTA", cons[2].ToString(), Convert.ToDateTime(cons[1].ToString()));
            }
            DataView dv = retorno.DefaultView;
            dv.Sort = "Fecha1 asc";
            return dv.ToTable();
        }

        public void eliminarPaciente(string id)
        {
            List<string> delete = SQLConnector.generarListaParaProcedure("@id");
            SQLConnector.executeProcedure("sp_Paciente_DeleteClub", delete, new Guid(id));
            SQLConnector.executeProcedure("sp_Paciente_Delete", delete, new Guid(id));
        }






    }
}
