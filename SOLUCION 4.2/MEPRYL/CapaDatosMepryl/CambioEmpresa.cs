using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class CambioEmpresa
    {
        public string obtenerEmpresaActual(string idTipoExamen)
        {
            DataTable empresa = SQLConnector.obtenerTablaSegunConsultaString(@"select  e.razonSocial 
                from dbo.empresaPorTipoDeExamen ete inner join dbo.Empresa e on ete.idEmpresa = e.id
                where ete.idTipoExamen = '" + idTipoExamen + "'");
            if (empresa.Rows.Count > 0)
            {
                return empresa.Rows[0][0].ToString();
            }
            return string.Empty;
        }

        public string obtenerTareaActual(string idTipoExamen)
        {
            DataTable tarea = SQLConnector.obtenerTablaSegunConsultaString(@"select ete.tarea
                from dbo.empresaPorTipoDeExamen ete
                where ete.idTipoExamen = '" + idTipoExamen + "'");
            if (tarea.Rows.Count > 0)
            {
                return tarea.Rows[0][0].ToString();
            }
            return string.Empty;
        }

        public Entidades.Resultado guardarCambio(string idTe, string idEmp, string tarea)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> listUpdate = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idEmpresa", "@tarea");
                SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Update", listUpdate, new Guid(idTe), new Guid(idEmp), tarea);
                retorno.Modo = 1;
                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }
    }
}
