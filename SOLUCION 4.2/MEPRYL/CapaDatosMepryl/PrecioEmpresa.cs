using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class PrecioEmpresaDatos
    {
        public PrecioEmpresaDatos()
        {
        }

        /// <summary>
        /// Lista precios de empresas para un año específico
        /// </summary>
        public DataTable ListarPreciosEmpresaAnio(int anio)
        {
            string strSQL =
                "SELECT e.id AS idEspecialidad, " +
                "ISNULL(m.nombre, '') AS Motivo, " +
                "ISNULL(padre.descripcion, '') AS Tipo, " +
                "e.descripcion AS Descripcion, " +
                "e.precioBase AS IPCBase, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 1  THEN pe.CoeficienteIndividual END), 0) AS Coef01, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 2  THEN pe.CoeficienteIndividual END), 0) AS Coef02, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 3  THEN pe.CoeficienteIndividual END), 0) AS Coef03, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 4  THEN pe.CoeficienteIndividual END), 0) AS Coef04, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 5  THEN pe.CoeficienteIndividual END), 0) AS Coef05, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 6  THEN pe.CoeficienteIndividual END), 0) AS Coef06, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 7  THEN pe.CoeficienteIndividual END), 0) AS Coef07, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 8  THEN pe.CoeficienteIndividual END), 0) AS Coef08, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 9  THEN pe.CoeficienteIndividual END), 0) AS Coef09, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 10 THEN pe.CoeficienteIndividual END), 0) AS Coef10, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 11 THEN pe.CoeficienteIndividual END), 0) AS Coef11, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 12 THEN pe.CoeficienteIndividual END), 0) AS Coef12, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 1  THEN pe.PrecioPromo END), 0) AS Promo01, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 2  THEN pe.PrecioPromo END), 0) AS Promo02, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 3  THEN pe.PrecioPromo END), 0) AS Promo03, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 4  THEN pe.PrecioPromo END), 0) AS Promo04, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 5  THEN pe.PrecioPromo END), 0) AS Promo05, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 6  THEN pe.PrecioPromo END), 0) AS Promo06, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 7  THEN pe.PrecioPromo END), 0) AS Promo07, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 8  THEN pe.PrecioPromo END), 0) AS Promo08, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 9  THEN pe.PrecioPromo END), 0) AS Promo09, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 10 THEN pe.PrecioPromo END), 0) AS Promo10, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 11 THEN pe.PrecioPromo END), 0) AS Promo11, " +
                "ISNULL(MAX(CASE WHEN pe.Mes = 12 THEN pe.PrecioPromo END), 0) AS Promo12 " +
                "FROM Especialidad e " +
                "LEFT JOIN PrecioEmpresa pe ON e.id = pe.idEspecialidad AND pe.Anio = " + anio + " AND pe.Eliminado = 0 " +
                "LEFT JOIN MotivoDeConsulta m ON e.idMotivoConsulta = m.id " +
                "LEFT JOIN Especialidad padre ON e.IdPadre = padre.id " +
                "WHERE e.Padre = 0 AND e.estado = 1 AND e.IdPadre IS NOT NULL " +
                "AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas) " +
                "GROUP BY e.id, m.nombre, padre.descripcion, e.descripcion, e.precioBase " +
                "ORDER BY m.nombre, padre.descripcion, e.descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Guarda o actualiza los precios de empresa para un mes/año
        /// </summary>
        public void GuardarPreciosEmpresa(DataTable dtDatos, int mes, int anio)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string idEspecialidad = dtDatos.Rows[i]["idEspecialidad"].ToString();
                string descripcion = dtDatos.Rows[i]["Descripcion"].ToString().Replace("'", "''");
                string precioPromo = dtDatos.Rows[i]["PrecioPromo"].ToString().Replace(",", ".");
                string precioLista = dtDatos.Rows[i]["PrecioLista"].ToString().Replace(",", ".");
                string seña = dtDatos.Rows[i]["Seña"].ToString().Replace(",", ".");
                string llevaPlanilla = (Convert.ToBoolean(dtDatos.Rows[i]["LlevaPlanilla"]) ? "1" : "0");
                string obsExtra = dtDatos.Rows[i]["ObservacionesExtra"].ToString().Replace("'", "''");
                string coeficienteIndividual = dtDatos.Rows[i]["CoeficienteIndividual"].ToString().Replace(",", ".");

                sb.Append("IF EXISTS (SELECT 1 FROM PrecioEmpresa WHERE idEspecialidad = '" + idEspecialidad + "' AND Mes = " + mes + " AND Anio = " + anio + ") ");
                sb.Append("UPDATE PrecioEmpresa SET ");
                sb.Append("Descripcion = '" + descripcion + "', ");
                sb.Append("PrecioPromo = " + precioPromo + ", ");
                sb.Append("PrecioLista = " + precioLista + ", ");
                sb.Append("Seña = " + seña + ", ");
                sb.Append("LlevaPlanilla = " + llevaPlanilla + ", ");
                sb.Append("ObservacionesExtra = '" + obsExtra + "', ");
                sb.Append("CoeficienteIndividual = " + coeficienteIndividual + ", ");
                sb.Append("FechaModificacion = GETDATE(), ");
                sb.Append("Eliminado = 0 ");
                sb.Append("WHERE idEspecialidad = '" + idEspecialidad + "' AND Mes = " + mes + " AND Anio = " + anio + " ");
                sb.Append("ELSE ");
                sb.Append("INSERT INTO PrecioEmpresa (idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, PrecioLista, Seña, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual) ");
                sb.AppendLine("VALUES('" + idEspecialidad + "', '" + descripcion + "', " + mes + ", " + anio + ", " + precioPromo + ", " + precioLista + ", " + seña + ", " + llevaPlanilla + ", '" + obsExtra + "', " + coeficienteIndividual + "); ");
            }

            SQLConnector.obtenerTablaSegunConsultaString(sb.ToString());
        }

        /// <summary>
        /// Guarda o actualiza PrecioEmpresa de los 12 meses del año (vista anual).
        /// Maneja columnas pivotadas Promo01..Promo12 y Coef01..Coef12.
        /// </summary>
        public void GuardarPreciosEmpresaAnio(int anio, DataTable dtDatos)
        {
            if (dtDatos == null || dtDatos.Rows.Count == 0) return;

            // Precios: UPDATE set-based (join) + INSERT para faltantes (NOT EXISTS)
            var sbUpd = new StringBuilder();
            sbUpd.Append("UPDATE pe SET pe.PrecioPromo=v.Promo,pe.CoeficienteIndividual=v.Coef,pe.FechaModificacion=GETDATE() " +
                         "FROM dbo.PrecioEmpresa pe INNER JOIN (VALUES ");

            var sbIns = new StringBuilder();
            sbIns.Append("INSERT INTO dbo.PrecioEmpresa(idEspecialidad,Descripcion,Mes,Anio,PrecioPromo," +
                         "Seña,LlevaPlanilla,ObservacionesExtra,CoeficienteIndividual,Eliminado) " +
                         "SELECT v.idEsp,v.Dsc,v.Mes," + anio + ",v.Promo,0,0,'',v.Coef,0 FROM (VALUES ");

            bool first = true;
            for (int mes = 1; mes <= 12; mes++)
            {
                string colPromo = "Promo" + mes.ToString("00");
                string colCoef  = "Coef"  + mes.ToString("00");
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    string idEsp = dtDatos.Rows[i]["idEspecialidad"].ToString();
                    string desc  = dtDatos.Rows[i]["Descripcion"].ToString().Replace("'", "''");
                    string promo = dtDatos.Rows[i][colPromo].ToString().Replace(",", ".");
                    string coef  = dtDatos.Rows[i][colCoef].ToString().Replace(",", ".");
                    if (!first) { sbUpd.Append(","); sbIns.Append(","); }
                    first = false;
                    sbUpd.Append("('" + idEsp + "'," + mes + "," + promo + "," + coef + ")");
                    sbIns.Append("('" + idEsp + "','" + desc + "'," + mes + "," + promo + "," + coef + ")");
                }
            }

            sbUpd.Append(") AS v(idEsp,Mes,Promo,Coef) ON pe.idEspecialidad=v.idEsp AND pe.Mes=v.Mes AND pe.Anio=" + anio + ";");
            sbIns.Append(") AS v(idEsp,Dsc,Mes,Promo,Coef) WHERE NOT EXISTS (SELECT 1 FROM dbo.PrecioEmpresa pe WHERE pe.idEspecialidad=v.idEsp AND pe.Mes=v.Mes AND pe.Anio=" + anio + ");");

            SQLConnector.obtenerTablaSegunConsultaString(sbUpd.ToString());
            SQLConnector.obtenerTablaSegunConsultaString(sbIns.ToString());
        }

        /// <summary>
        /// Copia precios de empresa de un mes/año a otro
        /// </summary>
        public void CopiarPrecios(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            string strSQL = "INSERT INTO PrecioEmpresa (idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, PrecioLista, Seña, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual) " +
                "SELECT idEspecialidad, Descripcion, " + mesDestino + ", " + anioDestino + ", PrecioPromo, PrecioLista, Seña, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual " +
                "FROM PrecioEmpresa " +
                "WHERE Mes = " + mesOrigen + " AND Anio = " + anioOrigen + " AND Eliminado = 0 " +
                "AND idEspecialidad NOT IN (SELECT idEspecialidad FROM PrecioEmpresa WHERE Mes = " + mesDestino + " AND Anio = " + anioDestino + ")";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Aplica un porcentaje de variación a todos los precios de empresa de un mes/año
        /// </summary>
        public void AplicarVariacion(int mes, int anio, decimal porcentaje)
        {
            string factor = (1 + porcentaje / 100).ToString().Replace(",", ".");
            string strSQL = "UPDATE PrecioEmpresa SET " +
                            "PrecioPromo = ROUND(PrecioPromo * " + factor + ", 2), " +
                            "PrecioLista = ROUND(PrecioLista * " + factor + ", 2), " +
                            "FechaModificacion = GETDATE() " +
                            "WHERE Mes = " + mes + " AND Anio = " + anio + " AND Eliminado = 0";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Lista coeficientes de empresa para un año
        /// </summary>
        public DataTable ListarCoeficientesAnio(int anio)
        {
            string strSQL = "SELECT Mes, Anio, Coeficiente FROM CoeficientePrecio WHERE Anio = " + anio + " AND Tipo = 'EMPRESA' ORDER BY Mes";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// <summary>
        /// Guarda coeficientes de empresa para un año
        /// </summary>
        public void GuardarCoeficientesAnio(int anio, decimal[] coeficientes)
        {
            StringBuilder sb = new StringBuilder();
            for (int mes = 1; mes <= 12; mes++)
            {
                string coef = coeficientes[mes - 1].ToString().Replace(",", ".");
                sb.Append("IF EXISTS (SELECT 1 FROM CoeficientePrecio WHERE Mes = " + mes + " AND Anio = " + anio + " AND Tipo = 'EMPRESA') ");
                sb.Append("UPDATE CoeficientePrecio SET Coeficiente = " + coef + " WHERE Mes = " + mes + " AND Anio = " + anio + " AND Tipo = 'EMPRESA' ");
                sb.Append("ELSE ");
                sb.AppendLine("INSERT INTO CoeficientePrecio (Mes, Anio, Coeficiente, Tipo) VALUES (" + mes + ", " + anio + ", " + coef + ", 'EMPRESA');");
            }
            SQLConnector.obtenerTablaSegunConsultaString(sb.ToString());
        }
    }
}
