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
                "ISNULL(e.precioBase, 0) AS precioBase, " +
                "ISNULL(p.Seña, 0) AS Seña, " +
                "ISNULL(p.LlevaPlanilla, 0) AS LlevaPlanilla, " +
                "ISNULL(p.ObservacionesExtra, '') AS ObservacionesExtra, " +
                "ISNULL(p.CoeficienteIndividual, 0) AS CoeficienteIndividual, " +
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
                string seña = dtDatos.Rows[i]["Seña"].ToString().Replace(",", ".");
                string llevaPlanilla = (Convert.ToBoolean(dtDatos.Rows[i]["LlevaPlanilla"]) ? "1" : "0");
                string obsExtra = dtDatos.Rows[i]["ObservacionesExtra"].ToString().Replace("'", "''");
                string coeficienteIndividual = dtDatos.Rows[i]["CoeficienteIndividual"].ToString().Replace(",", ".");

                sb.Append("IF EXISTS (SELECT 1 FROM PrecioPublico WHERE idEspecialidad = '" + idEspecialidad + "' AND Mes = " + mes + " AND Anio = " + anio + ") ");
                sb.Append("UPDATE PrecioPublico SET ");
                sb.Append("Descripcion = '" + descripcion + "', ");
                sb.Append("PrecioLista = " + precioLista + ", ");
                sb.Append("Seña = " + seña + ", ");
                sb.Append("LlevaPlanilla = " + llevaPlanilla + ", ");
                sb.Append("ObservacionesExtra = '" + obsExtra + "', ");
                sb.Append("CoeficienteIndividual = " + coeficienteIndividual + ", ");
                sb.Append("FechaModificacion = GETDATE(), ");
                sb.Append("Eliminado = 0 ");
                sb.Append("WHERE idEspecialidad = '" + idEspecialidad + "' AND Mes = " + mes + " AND Anio = " + anio + " ");
                sb.Append("ELSE ");
                sb.Append("INSERT INTO PrecioPublico (idEspecialidad, Descripcion, Mes, Anio, PrecioLista, Seña, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual) ");
                sb.AppendLine("VALUES('" + idEspecialidad + "', '" + descripcion + "', " + mes + ", " + anio + ", " + precioLista + ", " + seña + ", " + llevaPlanilla + ", '" + obsExtra + "', " + coeficienteIndividual + "); ");
            }

            SQLConnector.obtenerTablaSegunConsultaString(sb.ToString());

            // Sincronizar a Especialidad siempre al guardar
            StringBuilder sbSync = new StringBuilder();
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string idEsp = dtDatos.Rows[i]["idEspecialidad"].ToString();
                string pLista = dtDatos.Rows[i]["PrecioLista"].ToString().Replace(",", ".");
                sbSync.AppendLine("UPDATE Especialidad SET precioLista = " + pLista + " WHERE id = '" + idEsp + "'; ");
            }
            SQLConnector.obtenerTablaSegunConsultaString(sbSync.ToString());
        }

        /// <summary>
        /// Copia precios de un mes/año a otro (para arrastrar precios)
        /// </summary>
        public void CopiarPrecios(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            string strSQL = "INSERT INTO PrecioPublico (idEspecialidad, Descripcion, Mes, Anio, PrecioLista, Seña, LlevaPlanilla, ObservacionesExtra) " +
                "SELECT idEspecialidad, Descripcion, " + mesDestino + ", " + anioDestino + ", PrecioLista, Seña, LlevaPlanilla, ObservacionesExtra " +
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

        /// <summary>
        /// Devuelve los 12 coeficientes de un año (uno por mes).
        /// </summary>
        public DataTable ListarCoeficientesAnio(int anio)
        {
            string strSQL = "SELECT Mes, ISNULL(Coeficiente, 1) AS Coeficiente FROM CoeficientePrecio WHERE Anio = " + anio + " ORDER BY Mes";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Guarda los 12 coeficientes de un año en un solo batch.
        /// </summary>
        public void GuardarCoeficientesAnio(int anio, decimal[] coeficientes)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                for (int mes = 1; mes <= 12; mes++)
                {
                    string coef = coeficientes[mes - 1].ToString().Replace(",", ".");
                    sb.Append("IF EXISTS (SELECT 1 FROM CoeficientePrecio WHERE Mes = " + mes + " AND Anio = " + anio + ") ");
                    sb.Append("UPDATE CoeficientePrecio SET Coeficiente = " + coef + ", FechaModificacion = GETDATE() WHERE Mes = " + mes + " AND Anio = " + anio + " ");
                    sb.AppendLine("ELSE INSERT INTO CoeficientePrecio (Mes, Anio, Coeficiente) VALUES(" + mes + ", " + anio + ", " + coef + ");");
                }
                SQLConnector.obtenerTablaSegunConsultaString(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar coeficientes: " + ex.Message);
            }
        }

        /// <summary>
        /// Carga todos los meses del año en columnas pivoteadas (Promo01..Promo12)
        /// </summary>
        public DataTable ListarPreciosPublicoAnio(int anio)
        {
            string strSQL =
                "SELECT e.id AS idEspecialidad, " +
                "ISNULL(m.nombre, '') AS Motivo, " +
                "ISNULL(padre.descripcion, '') AS Tipo, " +
                "e.descripcion AS Descripcion, " +
                "e.IPCBase AS IPCBase, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 1  THEN p.CoeficienteIndividual END), 0) AS Coef01, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 2  THEN p.CoeficienteIndividual END), 0) AS Coef02, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 3  THEN p.CoeficienteIndividual END), 0) AS Coef03, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 4  THEN p.CoeficienteIndividual END), 0) AS Coef04, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 5  THEN p.CoeficienteIndividual END), 0) AS Coef05, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 6  THEN p.CoeficienteIndividual END), 0) AS Coef06, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 7  THEN p.CoeficienteIndividual END), 0) AS Coef07, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 8  THEN p.CoeficienteIndividual END), 0) AS Coef08, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 9  THEN p.CoeficienteIndividual END), 0) AS Coef09, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 10 THEN p.CoeficienteIndividual END), 0) AS Coef10, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 11 THEN p.CoeficienteIndividual END), 0) AS Coef11, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 12 THEN p.CoeficienteIndividual END), 0) AS Coef12, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 1  THEN p.PrecioLista END), 0) AS Promo01, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 2  THEN p.PrecioLista END), 0) AS Promo02, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 3  THEN p.PrecioLista END), 0) AS Promo03, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 4  THEN p.PrecioLista END), 0) AS Promo04, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 5  THEN p.PrecioLista END), 0) AS Promo05, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 6  THEN p.PrecioLista END), 0) AS Promo06, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 7  THEN p.PrecioLista END), 0) AS Promo07, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 8  THEN p.PrecioLista END), 0) AS Promo08, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 9  THEN p.PrecioLista END), 0) AS Promo09, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 10 THEN p.PrecioLista END), 0) AS Promo10, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 11 THEN p.PrecioLista END), 0) AS Promo11, " +
                "ISNULL(MAX(CASE WHEN p.Mes = 12 THEN p.PrecioLista END), 0) AS Promo12 " +
                "FROM Especialidad e " +
                "LEFT JOIN PrecioPublico p ON e.id = p.idEspecialidad AND p.Anio = " + anio + " AND p.Eliminado = 0 " +
                "LEFT JOIN MotivoDeConsulta m ON e.idMotivoConsulta = m.id " +
                "LEFT JOIN Especialidad padre ON e.IdPadre = padre.id " +
                "WHERE e.Padre = 0 AND e.estado = 1 AND e.IdPadre IS NOT NULL " +
                "AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas) " +
                "GROUP BY e.id, m.nombre, padre.descripcion, e.descripcion, e.IPCBase " +
                "ORDER BY m.nombre, padre.descripcion, e.descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Guarda o actualiza PrecioPublico de los 12 meses del año (vista anual).
        /// No sobreescribe PrecioLista, SeñaPromo, SeñaLista ni ObservacionesExtra.
        /// También actualiza el IPCBase en la tabla Especialidad.
        /// </summary>
        public void GuardarPreciosPublicoAnio(int anio, DataTable dtDatos)
        {
            if (dtDatos == null || dtDatos.Rows.Count == 0) return;

            // 1. IPCBase: un UPDATE set-based en lugar de N statements individuales
            var sbIPC = new StringBuilder();
            sbIPC.Append("UPDATE e SET e.IPCBase=v.IPC FROM dbo.Especialidad e INNER JOIN (VALUES ");
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                if (i > 0) sbIPC.Append(",");
                sbIPC.Append("('" + dtDatos.Rows[i]["idEspecialidad"] + "'," +
                             dtDatos.Rows[i]["IPCBase"].ToString().Replace(",", ".") + ")");
            }
            sbIPC.Append(") AS v(idEsp,IPC) ON e.id=v.idEsp;");
            SQLConnector.obtenerTablaSegunConsultaString(sbIPC.ToString());

            // 2. Precios: UPDATE set-based (join) + INSERT para faltantes (NOT EXISTS)
            var sbUpd = new StringBuilder();
            sbUpd.Append("UPDATE pp SET pp.PrecioLista=v.Lista,pp.CoeficienteIndividual=v.Coef,pp.FechaModificacion=GETDATE() " +
                         "FROM dbo.PrecioPublico pp INNER JOIN (VALUES ");

            var sbIns = new StringBuilder();
            sbIns.Append("INSERT INTO dbo.PrecioPublico(idEspecialidad,Descripcion,Mes,Anio,PrecioLista," +
                         "Seña,LlevaPlanilla,ObservacionesExtra,CoeficienteIndividual) " +
                         "SELECT v.idEsp,v.Dsc,v.Mes," + anio + ",v.Lista,0,0,'',v.Coef FROM (VALUES ");

            bool first = true;
            for (int mes = 1; mes <= 12; mes++)
            {
                string colPromo = "Promo" + mes.ToString("00"); // En el DGV se llama PromoXX pero mapea a Lista
                string colCoef = "Coef" + mes.ToString("00");
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    string idEsp = dtDatos.Rows[i]["idEspecialidad"].ToString();
                    string desc = dtDatos.Rows[i]["Descripcion"].ToString().Replace("'", "''");
                    string lista = dtDatos.Rows[i][colPromo].ToString().Replace(",", ".");
                    string coef = dtDatos.Rows[i][colCoef].ToString().Replace(",", ".");
                    if (!first) { sbUpd.Append(","); sbIns.Append(","); }
                    first = false;
                    sbUpd.Append("('" + idEsp + "'," + mes + "," + lista + "," + coef + ")");
                    sbIns.Append("('" + idEsp + "','" + desc + "'," + mes + "," + lista + "," + coef + ")");
                }
            }
            sbUpd.Append(") AS v(idEsp,Mes,Lista,Coef) ON pp.idEspecialidad=v.idEsp AND pp.Mes=v.Mes AND pp.Anio=" + anio + " AND pp.Eliminado=0;");
            sbIns.Append(") AS v(idEsp,Dsc,Mes,Lista,Coef) WHERE NOT EXISTS(SELECT 1 FROM dbo.PrecioPublico pp2 WHERE pp2.idEspecialidad=v.idEsp AND pp2.Mes=v.Mes AND pp2.Anio=" + anio + ");");

            SQLConnector.obtenerTablaSegunConsultaString(sbUpd.ToString());
            SQLConnector.obtenerTablaSegunConsultaString(sbIns.ToString());
        }

        /// <summary>
        /// Verifica si existen precios para cualquier mes del año dado.
        /// </summary>
        public bool ExistenPreciosAnio(int anio)
        {
            string strSQL = "SELECT COUNT(*) AS Cantidad FROM PrecioPublico WHERE Anio = " + anio + " AND Eliminado = 0";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            return dt != null && dt.Rows.Count > 0 && int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        /// <summary>
        /// Lista configuración de señas/planilla por especialidad (independiente del período).
        /// </summary>
        public DataTable ListarConfigEspecialidades()
        {
            string strSQL =
                "SELECT e.id AS idEspecialidad, " +
                "ISNULL(m.nombre,'') AS Motivo, " +
                "ISNULL(padre.descripcion,'') AS Tipo, " +
                "e.descripcion AS Descripcion, " +
                "ISNULL(c.Seña, 0) AS Seña, " +
                "ISNULL(c.LlevaPlanilla, 0) AS LlevaPlanilla, " +
                "ISNULL(c.Observaciones, '') AS Observaciones " +
                "FROM Especialidad e " +
                "LEFT JOIN ConfigPrecioEspecialidad c ON c.idEspecialidad = e.id " +
                "LEFT JOIN MotivoDeConsulta m ON e.idMotivoConsulta = m.id " +
                "LEFT JOIN Especialidad padre ON e.IdPadre = padre.id " +
                "WHERE e.Padre = 0 AND e.estado = 1 AND e.IdPadre IS NOT NULL " +
                "AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas) " +
                "ORDER BY m.nombre, padre.descripcion, e.descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Guarda señas/planilla/observaciones en ConfigPrecioEspecialidad.
        /// Solo inserta si hay al menos un valor distinto de cero/vacío.
        /// </summary>
        public void GuardarConfigEspecialidades(DataTable dtDatos)
        {
            if (dtDatos == null || dtDatos.Rows.Count == 0) return;

            // UPDATE set-based para registros existentes
            var sbUpd = new StringBuilder();
            sbUpd.Append("UPDATE c SET c.Seña=v.SP,c.LlevaPlanilla=v.LP,c.Observaciones=v.Obs,c.FechaModificacion=GETDATE() " +
                         "FROM dbo.ConfigPrecioEspecialidad c INNER JOIN (VALUES ");

            // INSERT para especialidades que no tienen config todavía
            var sbIns = new StringBuilder();
            sbIns.Append("INSERT INTO dbo.ConfigPrecioEspecialidad(idEspecialidad,Seña,LlevaPlanilla,Observaciones) " +
                         "SELECT v.idEsp,v.SP,v.LP,v.Obs FROM (VALUES ");

            bool first = true;
            bool anyInsert = false;
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string id = dtDatos.Rows[i]["idEspecialidad"].ToString();
                string s = dtDatos.Rows[i]["Seña"].ToString().Replace(",", ".");
                string planilla = (Convert.ToBoolean(dtDatos.Rows[i]["LlevaPlanilla"]) ? "1" : "0");
                string obs = dtDatos.Rows[i]["Observaciones"].ToString().Replace("'", "''");

                if (!first) { sbUpd.Append(","); sbIns.Append(","); }
                first = false;
                string row = "('" + id + "'," + s + "," + planilla + ",'" + obs + "')";
                sbUpd.Append(row);

                // Solo incluir en INSERT si hay al menos un valor distinto de cero/vacío
                if (s != "0" && s != "0." || planilla == "1" || obs.Length > 0)
                    anyInsert = true;
                sbIns.Append(row);
            }

            sbUpd.Append(") AS v(idEsp,SP,LP,Obs) ON c.idEspecialidad=v.idEsp;");
            sbIns.Append(") AS v(idEsp,SP,LP,Obs) WHERE NOT EXISTS(SELECT 1 FROM dbo.ConfigPrecioEspecialidad c2 WHERE c2.idEspecialidad=v.idEsp);");

            SQLConnector.obtenerTablaSegunConsultaString(sbUpd.ToString());
            if (anyInsert)
                SQLConnector.obtenerTablaSegunConsultaString(sbIns.ToString());
        }
    }
}
