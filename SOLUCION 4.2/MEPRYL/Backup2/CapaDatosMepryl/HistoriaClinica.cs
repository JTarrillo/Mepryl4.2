using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class HistoriaClinica
    {
        public DataTable cargarHistoriaClinicaLaboral(string idPaciente, string idEmpresa)
        {
            DataTable retorno = generarTablaRetornoLaboral();
            DataTable consultas = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, 
            c.tipo, c.fecha, c.identificador, c.pacienteID, tep.id, e.descripcion from dbo.Consulta c
            inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            inner join dbo.empresaPorTipoDeExamen ete on ete.idTipoExamen = tep.id
            where c.pacienteID = '" + idPaciente + @"' and ete.idEmpresa = '" + idEmpresa + @"'
            order by c.fecha");
            foreach (DataRow r in consultas.Rows)
            {
                procesarConsulta(r, ref retorno);
            }
            return retorno;
        }

        public DataTable cargarHistoriaClinicaReporte(string idPaciente, string idEmpresa, string 
            fechaDesde, string fechaHasta)
        {
            DataTable retorno = generarTablaRetornoLaboral();
            DataTable consultas = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, 
            c.tipo, c.fecha, c.identificador, c.pacienteID, tep.id, e.descripcion from dbo.Consulta c
            inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            inner join dbo.empresaPorTipoDeExamen ete on ete.idTipoExamen = tep.id
            where c.pacienteID = '" + idPaciente + @"' and ete.idEmpresa = '" + idEmpresa + @"'
            and convert(date, c.fecha) >= '" + fechaDesde + "' and convert(date, c.fecha) <= '" + fechaHasta + @"'
            order by c.fecha");
            foreach (DataRow r in consultas.Rows)
            {
                procesarConsulta(r, ref retorno);
            }
            return retornarTablaParaReporte(retorno);
        }

 

        private void procesarConsulta(DataRow r, ref DataTable retorno)
        {
            string tipo = r.ItemArray[1].ToString();
            switch (tipo)
            {
                case "L":
                    procesarLaboral(r, ref retorno);
                    break;
                case "CO":
                    procesarConsultorio(r, ref retorno);
                    break;
                default:
                    procesarOtros(r, ref retorno);
                    break;
            }
        }

        private void procesarLaboral(DataRow r, ref DataTable retorno)
        {
            string dictamenTxt = "NO CARGADO";
            DataTable dictamenLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"
            select el.dictamen from dbo.ConsultaLaboral cl inner join dbo.ExamenLaboral el on cl.idExamenLaboral = el.id
            where cl.idTipoExamen = '" + r.ItemArray[5].ToString() + "'");
            if (dictamenLaboral.Rows.Count > 0)
            {
                if (dictamenLaboral.Rows[0][0].ToString() != string.Empty)
                {
                    dictamenTxt = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.DictamenesLaboral
                    where id = '" + dictamenLaboral.Rows[0][0].ToString() + "'").Rows[0][0].ToString();
                }
                retorno.Rows.Add(r.ItemArray[0], r.ItemArray[5], r.ItemArray[4],
                    Convert.ToDateTime(r.ItemArray[2].ToString()).ToShortDateString(),
                    r.ItemArray[1], r.ItemArray[6], r.ItemArray[3], "PRIMERA VEZ", dictamenTxt, null, "CLINICA", null, null, null);
            }
        }


        private void procesarOtros(DataRow r, ref DataTable retorno)
        {
            retorno.Rows.Add(r.ItemArray[0], r.ItemArray[5], r.ItemArray[4],
                 Convert.ToDateTime(r.ItemArray[2].ToString()).ToShortDateString(),
                 r.ItemArray[1], r.ItemArray[6], r.ItemArray[3], "PRIMERA VEZ", null, null, "CLINICA",null, null, null);
        }

        private void procesarConsultorio(DataRow r, ref DataTable retorno)
        {
            string condicionLaboralTxt = string.Empty;
            string fechaAltaCitacionTxt = string.Empty;
            string estadoAtencionTxt = string.Empty;
            string lugarAtencionTxt = string.Empty;
            string motivoTxt = string.Empty;
            string patologiaTxt = string.Empty;
            DataTable dictamenLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"
            select consL.fechaAltaCitacion, consL.idCondicionLaboral, consL.idEstadoAtencion, consL.idLugarAtencion,
            consL.idMotivo, consL.idPatologia, consL.diagnostico from dbo.ConsultaLaboral cl inner join dbo.ConsultorioLaboral consL on cl.idConsultorioLaboral = consL.id
            where cl.idTipoExamen = '" + r.ItemArray[5].ToString() + "'");
            if (dictamenLaboral.Rows.Count > 0)
            {
                if (dictamenLaboral.Rows[0][0].ToString() != string.Empty)
                {
                    fechaAltaCitacionTxt = Convert.ToDateTime(dictamenLaboral.Rows[0][0].ToString()).ToShortDateString();
                }
                if (dictamenLaboral.Rows[0][1].ToString() != string.Empty)
                {
                    condicionLaboralTxt = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.CondicionLaboral
                    where id = '" + dictamenLaboral.Rows[0][1].ToString() + "'").Rows[0][0].ToString();
                }
                if (dictamenLaboral.Rows[0][2].ToString() != string.Empty)
                {
                    estadoAtencionTxt = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.EstadoAtencion
                    where id = '" + dictamenLaboral.Rows[0][2].ToString() + "'").Rows[0][0].ToString();
                }
                if (dictamenLaboral.Rows[0][3].ToString() != string.Empty)
                {
                    lugarAtencionTxt = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.LugarAtencion
                    where id = '" + dictamenLaboral.Rows[0][3].ToString() + "'").Rows[0][0].ToString();
                }
                if (dictamenLaboral.Rows[0][4].ToString() != string.Empty)
                {
                    motivoTxt = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.MotivoDeConsultaLaboral
                    where id = '" + dictamenLaboral.Rows[0][4].ToString() + "'").Rows[0][0].ToString();
                }
                if (dictamenLaboral.Rows[0][5].ToString() != string.Empty)
                {
                    patologiaTxt = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.Patologia
                    where id = '" + dictamenLaboral.Rows[0][5].ToString() + "'").Rows[0][0].ToString();
                }
                retorno.Rows.Add(r.ItemArray[0], r.ItemArray[5], r.ItemArray[4],
                    Convert.ToDateTime(r.ItemArray[2].ToString()).ToShortDateString(),
                    r.ItemArray[1], r.ItemArray[6], r.ItemArray[3], estadoAtencionTxt, condicionLaboralTxt, fechaAltaCitacionTxt,
                    lugarAtencionTxt, motivoTxt, patologiaTxt, dictamenLaboral.Rows[0][6].ToString());
            }
        }

        private DataTable generarTablaRetornoLaboral()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("IdConsulta");
            retorno.Columns.Add("IdTipoExamen");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Area de Consulta");
            retorno.Columns.Add("Tipo de Examen");
            retorno.Columns.Add("Identificador");
            retorno.Columns.Add("Estado de Atencion");
            retorno.Columns.Add("Condición Laboral");
            retorno.Columns.Add("Fecha Alta/Citacion");
            retorno.Columns.Add("LugarAtencion");
            retorno.Columns.Add("Motivo");
            retorno.Columns.Add("Patologia");
            retorno.Columns.Add("Diagnostico");
            return retorno;
        }

        private DataTable retornarTablaParaReporte(DataTable tabla)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("TipoExamen");
            retorno.Columns.Add("LugarAtencion");
            retorno.Columns.Add("Motivo");
            retorno.Columns.Add("EstadoAtencion");
            retorno.Columns.Add("Patologia");
            retorno.Columns.Add("Diagnostico");
            retorno.Columns.Add("CondicionLaboral");
            retorno.Columns.Add("FechaAlta/Citacion");
            foreach (DataRow dr in tabla.Rows)
            {
                retorno.Rows.Add(dr.ItemArray[3], dr.ItemArray[5], dr.ItemArray[10], dr.ItemArray[11],
                    dr.ItemArray[7], dr.ItemArray[12], dr.ItemArray[13], dr.ItemArray[8],
                    dr.ItemArray[9]);
            }  
            return retorno;
        }
    }
}
