using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class LocalidadesYPrestaciones
    {
        public DataTable cargarLocalidadesYPrestaciones(string filtro)
        {
            return retornarLocalidadesYPrestaciones(SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, codPres as Codigo,
            tiPres as Tipo, pres as 'Prestacion/Localidad', zona as Zona from dbo.Prestaciones
            where tiPres = '" + filtro + "' order by codPres"));
        }

        public DataTable cargarLocalidadesYPrestacionesFiltro(string filtro, string filtroTexto)
        {
            return retornarLocalidadesYPrestaciones(SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, codPres as Codigo,
            tiPres as Tipo, pres as 'Prestacion/Localidad', zona as Zona from dbo.Prestaciones
            where tiPres = '" + filtro + "' and pres like '%" + filtroTexto + "%' order by codPres"));
        }

        public DataTable cargarEspecialidad(string filtroTexto)
        {
            string strSQL = "";

            strSQL = @"SELECT id, codigo, tipo, 
            Descripcion AS 'Prestacion/Localidad', '' as Zona, idPadre FROM dbo.Especialidad
            WHERE padre = 0 AND descripcion like '%"+ filtroTexto + "%' ORDER BY codigo";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        private DataTable retornarLocalidadesYPrestaciones(DataTable consulta)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Tipo");
            retorno.Columns.Add("Prestacion/Localidad");
            retorno.Columns.Add("ZonaOculta");
            retorno.Columns.Add("Zona");
            DataTable zonas = cargarZonas();
            foreach (DataRow r in consulta.Rows)
            {
                string zona = "";
                if (r.ItemArray[4].ToString() != string.Empty && r.ItemArray[4].ToString() != "-1")
                {
                    zona = zonas.Select("Id = " + r.ItemArray[4].ToString())[0][2].ToString();
                }
                retorno.Rows.Add(r.ItemArray[0], String.Format("{0:00-00-00}", Convert.ToInt32(r.ItemArray[1].ToString())) , r.ItemArray[2],
                    r.ItemArray[3], r.ItemArray[4], zona);
            }
            return retorno;
        }

        public Entidades.Resultado guardarNueva(Entidades.LocalidadPrestacion entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                int codigo = obtenerProximoCodigo(entidad.Tipo);
                List<string> newPrestacion = SQLConnector.generarListaParaProcedure("@codigo","@tipo",
                    "@descripcion","@zona");
                SQLConnector.executeProcedure("sp_Prestaciones_Add", newPrestacion,
                    codigo, entidad.Tipo, entidad.Descripcion, obtenerCodigoZona(entidad.Zona));
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

        private object obtenerCodigoZona(int codigo)
        {
            if (codigo != -1) { return codigo; }
            return null;
        }

        private int obtenerProximoCodigo(string tipo)
        {
            DataTable codigos = SQLConnector.obtenerTablaSegunConsultaString(@"select codPres from dbo.Prestaciones
            where tiPres = '" + tipo + "' order by codPres");
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

        public Entidades.Resultado editar(Entidades.LocalidadPrestacion entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updatePrestacion = SQLConnector.generarListaParaProcedure("@id",
                    "@descripcion", "@zona");
                SQLConnector.executeProcedure("sp_Prestaciones_Update", updatePrestacion,
                    entidad.Id, entidad.Descripcion, obtenerCodigoZona(entidad.Zona));
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

        public bool verificarEliminar(string id, string tipo)
        {
            switch (tipo)
            {
                case "V":
                    return verificarLocalidad(id);
            }
            return true;
        }

        private bool verificarLocalidad(string id)
        {
            if ((SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Paciente
            where localidad = '" + id + "'").Rows.Count) <= 0 && (SQLConnector.obtenerTablaSegunConsultaString
            ("select * from dbo.VisitasLaboral where localidad = '" + id + "'").Rows.Count) <= 0)
            {
                return true;
            }
            return false;
        }

        public Entidades.Resultado eliminar(string id)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> deletePrestacion = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_Prestaciones_Delete", deletePrestacion,
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

        public DataTable cargarZonas()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Descripcion");
            retorno.Columns.Add("DescripcionSinCodigo");
            retorno.Rows.Add("0", "NO APLICA");
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, convert(varchar(2), id) + ' - ' + 
            descripcion as Descripcion, descripcion from dbo.Zonas order by id");
            foreach (DataRow r in consulta.Rows)
            {
                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString(), r.ItemArray[2].ToString());
            }
            return retorno;
        }

        public DataTable cargarZonasSinNoAplica()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, id as Codigo,
            descripcion as Descripcion from dbo.Zonas order by id");
        }

        public bool verificarZonaAsignada(string idZona)
        {
            if (SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Prestaciones where zona = " + idZona).Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public Entidades.Resultado eliminarZona(string idZona)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> deleteZona = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_Zonas_Delete", deleteZona,
                    Convert.ToInt32(idZona));
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

        public Entidades.Resultado guardarZona(string descripcion)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> newZona = SQLConnector.generarListaParaProcedure("@descripcion");
                SQLConnector.executeProcedure("sp_Zonas_Add", newZona,
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

        public Entidades.Resultado editarZona(string idZona, string descripcion)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateZona = SQLConnector.generarListaParaProcedure("@id",
                    "@descripcion");
                SQLConnector.executeProcedure("sp_Zonas_Update", updateZona,
                    Convert.ToInt16(idZona), descripcion);
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
    }
}
