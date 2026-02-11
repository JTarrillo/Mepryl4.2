using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunes;
using System.Data;
using Entidades;

namespace CapaDatosMepryl
{
    public class CondicionLaboral
    {
        public DataTable cargarCondiciones(string lugarAtencion)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, convert(varchar(2),codigo) + ' - ' + descripcion as descripcion
            from dbo.CondicionLaboral
            where lugarAtencion = '" + lugarAtencion + "' order by codigo");
        }

        public Entidades.CondicionLaboral cargarCondicion(string id)
        {
            Entidades.CondicionLaboral retorno = new Entidades.CondicionLaboral();
            DataTable condiciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.CondicionLaboral where id = '" + id + "'");
            if (condiciones.Rows.Count > 0)
            {
                retorno.Id = new Guid(condiciones.Rows[0].ItemArray[0].ToString());
                retorno.LugarAtencion = condiciones.Rows[0].ItemArray[1].ToString();
                retorno.Codigo = Convert.ToInt16(condiciones.Rows[0].ItemArray[2].ToString());
                retorno.Descripcion = condiciones.Rows[0].ItemArray[3].ToString();
                retorno.Justificacion = condiciones.Rows[0].ItemArray[4].ToString();
                retorno.Alta = condiciones.Rows[0].ItemArray[5].ToString();
                retorno.FechaAlta = condiciones.Rows[0].ItemArray[6].ToString();
                retorno.FechaCitacion = condiciones.Rows[0].ItemArray[7].ToString();
            }
            return retorno;
        }

        public int getProximoCodigo(string lugarAtencion)
        {
            DataTable codigosCargados = SQLConnector.obtenerTablaSegunConsultaString(@"select codigo from dbo.CondicionLaboral
            where lugarAtencion = '" + lugarAtencion + "' order by codigo");
            int codActual = 0;
            foreach (DataRow r in codigosCargados.Rows)
            {
                if (codActual != Convert.ToInt16(r.ItemArray[0].ToString()))
                {
                    return codActual;
                   
                }
                codActual++;
            }
            return codActual;          
        }

        public Entidades.Resultado deleteCondicion(string idCondicion)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> listDelete = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_CondicionLaboral_Delete", listDelete, new Guid(idCondicion));
                retorno.Modo = 1;
                retorno.Mensaje = "¡Condición laboral eliminada correctamente!";
                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = "¡No se puede eliminar la condición laboral!\nError: " + ex.ToString();
                return retorno;
            }
    
        }

        public Entidades.Resultado insertCondicion(Entidades.CondicionLaboral entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> listInsert = SQLConnector.generarListaParaProcedure("@lugarAtencion", "@codigo",
                    "@descripcion", "@justificacion", "@alta", "@fechaAlta", "@fechaCitacion");
                SQLConnector.executeProcedure("sp_CondicionLaboral_Insert", listInsert, entidad.LugarAtencion,
                    entidad.Codigo, entidad.Descripcion,entidad.Justificacion, entidad.Alta,entidad.FechaAlta, entidad.FechaCitacion);
                retorno.Modo = 1;
                retorno.Mensaje = "¡Condición laboral agregada correctamente!";
                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = "¡No se puede insertar la condición laboral!\nError: " + ex.ToString();
                return retorno;
            }
      
        }

        public Entidades.Resultado updateCondicion(Entidades.CondicionLaboral entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> listUpdate = SQLConnector.generarListaParaProcedure("@id","@lugarAtencion", "@codigo",
                    "@descripcion", "@justificacion", "@alta", "@fechaAlta", "@fechaCitacion");
                SQLConnector.executeProcedure("sp_CondicionLaboral_Update", listUpdate, entidad.Id, entidad.LugarAtencion,
                    entidad.Codigo, entidad.Descripcion, entidad.Justificacion, entidad.Alta, entidad.FechaAlta, entidad.FechaCitacion);
                retorno.Modo = 1;
                retorno.Mensaje = "¡Condición laboral editada correctamente!";
                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = "¡No se puede editar la condición laboral\nError: " + ex.ToString();
                return retorno;
            }
     
        }
    }
}
