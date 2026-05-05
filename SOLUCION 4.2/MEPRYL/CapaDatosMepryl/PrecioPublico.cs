using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class PrecioPublico
    {
        public PrecioPublico()
        {
        }

        /// <summary>
        /// Lista todas las especialidades hijas activas (subtipos) para cargar la grilla
        /// </summary>
        public DataTable ListarEspecialidadesHijas()
        {
            string strSQL = "SELECT id, codigo, descripcion, precioBase FROM Especialidad WHERE Padre = 0 AND estado = 1 AND IdPadre IS NOT NULL AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas) ORDER BY descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Carga los precios público de un mes/año determinado
        /// </summary>
        public DataTable ListarPreciosPublico(int mes, int anio)
        {
            string strSQL = "SELECT e.id AS idEspecialidad, e.descripcion AS Descripcion, " +
                            "ISNULL(p.PrecioLista, 0) AS PrecioLista, " +
                            "ISNULL(p.PrecioPromo, 0) AS PrecioPromo, " +
                            "ISNULL(e.precioBase, 0) AS precioBase, " +
                            "ISNULL(p.SeñaPromo, 0) AS SeñaPromo, " +
                            "ISNULL(p.SeñaLista, 0) AS SeñaLista, " +
                            "ISNULL(p.LlevaPlanilla, 0) AS LlevaPlanilla, " +
                            "ISNULL(p.ObservacionesExtra, '') AS ObservacionesExtra, " +
                            "ISNULL(m.nombre, '') AS Motivo, " +
                            "ISNULL(padre.descripcion, '') AS Tipo " +
                            "FROM Especialidad e " +
                            "LEFT JOIN PrecioPublico p ON e.id = p.idEspecialidad AND p.Mes = " + mes + " AND p.Anio = " + anio + " AND p.Eliminado = 0 " +
                            "LEFT JOIN MotivoDeConsulta m ON e.idMotivoConsulta = m.id " +
                            "LEFT JOIN Especialidad padre ON e.IdPadre = padre.id " +
                            "WHERE e.Padre = 0 AND e.estado = 1 AND e.IdPadre IS NOT NULL AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas) " +
                            "ORDER BY m.nombre, padre.descripcion, e.descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Guarda o actualiza los precios de un mes/año usando MERGE
        /// </summary>
        public void GuardarPreciosPublico(int mes, int anio, DataTable dtDatos)
        {
            if (dtDatos == null || dtDatos.Rows.Count == 0) return;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string idEspecialidad = dtDatos.Rows[i]["idEspecialidad"].ToString();
                string descripcion = dtDatos.Rows[i]["Descripcion"].ToString().Replace("'", "''");
                string precioLista = dtDatos.Rows[i]["PrecioLista"].ToString().Replace(",", ".");
                string precioPromo = dtDatos.Rows[i]["PrecioPromo"].ToString().Replace(",", ".");
                string señaPromo = dtDatos.Rows[i]["SeñaPromo"].ToString().Replace(",", ".");
                string señaLista = dtDatos.Rows[i]["SeñaLista"].ToString().Replace(",", ".");
                string llevaPlanilla = (Convert.ToBoolean(dtDatos.Rows[i]["LlevaPlanilla"]) ? "1" : "0");
                string obsExtra = dtDatos.Rows[i]["ObservacionesExtra"].ToString().Replace("'", "''");

                sb.Append("IF EXISTS (SELECT 1 FROM PrecioPublico WHERE idEspecialidad = '" + idEspecialidad + "' AND Mes = " + mes + " AND Anio = " + anio + ") ");
                sb.Append("UPDATE PrecioPublico SET ");
                sb.Append("Descripcion = '" + descripcion + "', ");
                sb.Append("PrecioLista = " + precioLista + ", ");
                sb.Append("PrecioPromo = " + precioPromo + ", ");
                sb.Append("SeñaPromo = " + señaPromo + ", ");
                sb.Append("SeñaLista = " + señaLista + ", ");
                sb.Append("LlevaPlanilla = " + llevaPlanilla + ", ");
                sb.Append("ObservacionesExtra = '" + obsExtra + "', ");
                sb.Append("FechaModificacion = GETDATE(), ");
                sb.Append("Eliminado = 0 ");
                sb.Append("WHERE idEspecialidad = '" + idEspecialidad + "' AND Mes = " + mes + " AND Anio = " + anio + " ");
                sb.Append("ELSE ");
                sb.Append("INSERT INTO PrecioPublico (idEspecialidad, Descripcion, Mes, Anio, PrecioLista, PrecioPromo, SeñaPromo, SeñaLista, LlevaPlanilla, ObservacionesExtra) ");
                sb.AppendLine("VALUES('" + idEspecialidad + "', '" + descripcion + "', " + mes + ", " + anio + ", " + precioLista + ", " + precioPromo + ", " + señaPromo + ", " + señaLista + ", " + llevaPlanilla + ", '" + obsExtra + "'); ");
            }

            SQLConnector.obtenerTablaSegunConsultaString(sb.ToString());

            // Sincronizar a Especialidad siempre al guardar
            StringBuilder sbSync = new StringBuilder();
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string idEsp = dtDatos.Rows[i]["idEspecialidad"].ToString();
                string pLista = dtDatos.Rows[i]["PrecioLista"].ToString().Replace(",", ".");
                string pPromo = dtDatos.Rows[i]["PrecioPromo"].ToString().Replace(",", ".");
                sbSync.AppendLine("UPDATE Especialidad SET precioBase = " + pPromo + ", precioLista = " + pLista + " WHERE id = '" + idEsp + "'; ");
            }
            SQLConnector.obtenerTablaSegunConsultaString(sbSync.ToString());
        }

        /// <summary>
        /// Copia precios de un mes/año a otro (para arrastrar precios)
        /// </summary>
        public void CopiarPrecios(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            string strSQL = "INSERT INTO PrecioPublico (idEspecialidad, Descripcion, Mes, Anio, PrecioLista, PrecioPromo, SeñaPromo, SeñaLista, LlevaPlanilla, ObservacionesExtra) " +
                            "SELECT idEspecialidad, Descripcion, " + mesDestino + ", " + anioDestino + ", PrecioLista, PrecioPromo, SeñaPromo, SeñaLista, LlevaPlanilla, ObservacionesExtra " +
                            "FROM PrecioPublico " +
                            "WHERE Mes = " + mesOrigen + " AND Anio = " + anioOrigen + " AND Eliminado = 0 " +
                            "AND idEspecialidad NOT IN (SELECT idEspecialidad FROM PrecioPublico WHERE Mes = " + mesDestino + " AND Anio = " + anioDestino + ")";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Aplica un porcentaje de variación a todos los precios de un mes/año
        /// </summary>
        public void AplicarVariacion(int mes, int anio, decimal porcentaje)
        {
            string factor = (1 + porcentaje / 100).ToString().Replace(",", ".");
            string strSQL = "UPDATE PrecioPublico SET " +
                            "PrecioLista = ROUND(PrecioLista * " + factor + ", 2), " +
                            "PrecioPromo = ROUND(PrecioPromo * " + factor + ", 2), " +
                            "FechaModificacion = GETDATE() " +
                            "WHERE Mes = " + mes + " AND Anio = " + anio + " AND Eliminado = 0";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Elimina (soft delete) los precios de un mes/año
        /// </summary>
        public void EliminarPreciosMes(int mes, int anio)
        {
            string strSQL = "UPDATE PrecioPublico SET Eliminado = 1 WHERE Mes = " + mes + " AND Anio = " + anio;
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Verifica si ya existen precios para un mes/año
        /// </summary>
        public bool ExistenPrecios(int mes, int anio)
        {
            string strSQL = "SELECT COUNT(*) AS Cantidad FROM PrecioPublico WHERE Mes = " + mes + " AND Anio = " + anio + " AND Eliminado = 0";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            return dt.Rows.Count > 0 && int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        /// <summary>
        /// Obtiene el coeficiente de incremento para un mes/año. Devuelve 1 si no existe.
        /// </summary>
        public decimal ObtenerCoeficiente(int mes, int anio)
        {
            string strSQL = "SELECT Coeficiente FROM CoeficientePrecio WHERE Mes = " + mes + " AND Anio = " + anio;
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                return Convert.ToDecimal(dt.Rows[0][0]);
            return 1;
        }

        /// <summary>
        /// Guarda o actualiza el coeficiente de incremento para un mes/año.
        /// </summary>
        public void GuardarCoeficiente(int mes, int anio, decimal coeficiente)
        {
            string coef = coeficiente.ToString().Replace(",", ".");
            string strSQL = "IF EXISTS (SELECT 1 FROM CoeficientePrecio WHERE Mes = " + mes + " AND Anio = " + anio + ") " +
                            "UPDATE CoeficientePrecio SET Coeficiente = " + coef + ", FechaModificacion = GETDATE() " +
                            "WHERE Mes = " + mes + " AND Anio = " + anio + " " +
                            "ELSE " +
                            "INSERT INTO CoeficientePrecio (Mes, Anio, Coeficiente) VALUES(" + mes + ", " + anio + ", " + coef + ")";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }
    }
}
