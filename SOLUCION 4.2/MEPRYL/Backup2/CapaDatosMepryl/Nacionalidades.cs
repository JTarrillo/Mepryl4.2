using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using Comunes;

namespace CapaDatosMepryl
{
    public class Nacionalidades
    {
        public DataTable cargarNacionalidades()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, codigo as Código, descripcion as Nacionalidad from dbo.Nacionalidad
            order by codigo");
        }

        public bool verificarNacionalidadAsignada(string id)
        {
            if (SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Paciente where nacionalidad = '" + id + "'").Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public Entidades.Resultado eliminar(string id)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> deleteNacionalidad = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_Nacionalidad_Delete", deleteNacionalidad,
                    new Guid(id));
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


        public Entidades.Resultado guardarNacionalidad(string descripcion)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> newNacionalidad = SQLConnector.generarListaParaProcedure("@codigo","@descripcion");
                SQLConnector.executeProcedure("sp_Nacionalidad_Add", newNacionalidad, obtenerProximoCodigo(),
                    descripcion);
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

        public Entidades.Resultado editarNacionalidad(string idNacionalidad, string descripcion)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateNacionalidad = SQLConnector.generarListaParaProcedure("@id",
                    "@descripcion");
                SQLConnector.executeProcedure("sp_Nacionalidad_Update", updateNacionalidad,
                    new Guid(idNacionalidad), descripcion);
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

        private int obtenerProximoCodigo()
        {
            DataTable codigos = SQLConnector.obtenerTablaSegunConsultaString(@"select codigo from dbo.Nacionalidad
            order by codigo");
            int contador = 0;
            foreach (DataRow r in codigos.Rows)
            {
                if (contador != Convert.ToInt32(r.ItemArray[0].ToString()))
                {
                    return contador;
                }
                contador++;
            }
            return contador;
        }
    }
}
