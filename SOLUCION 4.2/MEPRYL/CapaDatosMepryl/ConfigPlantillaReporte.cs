using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class ConfigPlantillaReporte
    {
        public ConfigPlantillaReporte()
        {
            //
        }

        public bool guardarPlantilla(List<object> valores)
        {
            bool blnResultado = false;
            string strSQL;

            strSQL = @"INSERT INTO dbo.ConfigPlantillaReporte (TipoReporte, Caratula, Clinico, Laboratorio, Espirometria, Olivera, HistoriaClinica)
                        VALUES 
                        ('" + valores[0].ToString() + @"', 
	                        '" + valores[1].ToString() + @"', 
	                        '" + valores[2].ToString() + @"', 
	                        '" + valores[3].ToString() + @"',
	                        '" + valores[4].ToString() + @"',
	                        '" + valores[5].ToString() + @"',
	                        '" + valores[7].ToString() + @"')";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        public bool ActualizaPlantilla(string strTipo, List<object> valores)
        {
            bool blnResultado = false;
            string strSQL;

            strSQL = @"UPDATE dbo.ConfigPlantillaReporte 
                        SET
	                        TipoReporte = '" + valores[0].ToString() + @"', 
                            Caratula = '" + valores[1].ToString() + @"', 
	                        Clinico = '" + valores[2].ToString() + @"', 
	                        Laboratorio = '" + valores[3].ToString() + @"', 
	                        Espirometria = '" + valores[4].ToString() + @"', 
	                        Olivera = '" + valores[5].ToString() + @"', 
	                        HistoriaClinica = '" + valores[6].ToString() + @"'
                        WHERE TipoReporte = '" + strTipo + @"'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        public DataTable ListarPlantillas(string strTipo)
        {
            string strSQL;
            DataTable dt = null;

            strSQL = "SELECT TOP 1 * FROM dbo.ConfigPlantillaReporte WHERE TipoReporte = '"+ strTipo + @"'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public bool ActualizaMensajeTurno(char strTipoPaciente, string strPathArchivo)
        {
            bool blnResultado = false;
            string strSQL;

            strSQL = "UPDATE dbo.ConfigPlantillaReporte " + 
                      "SET " +
                      "MensajeTurno = '" + strPathArchivo + "' " +
                      "WHERE TipoReporte = '" + strTipoPaciente + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        public bool ActualizaMensajeTurno2(char strTipoPaciente, string strPathArchivo)
        {
            bool blnResultado = false;
            string strSQL;

            strSQL = "UPDATE dbo.ConfigPlantillaReporte " +
                      "SET " +
                      "MensajeTurno2 = '" + strPathArchivo + "' " +
                      "WHERE TipoReporte = '" + strTipoPaciente + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        public bool ActualizaMensajeTurno3(char strTipoPaciente, string strPathArchivo)
        {
            bool blnResultado = false;
            string strSQL;

            strSQL = "UPDATE dbo.ConfigPlantillaReporte " +
                      "SET " +
                      "MensajeTurno3 = '" + strPathArchivo + "' " +
                      "WHERE TipoReporte = '" + strTipoPaciente + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        // ─── Mensajería dinámica por subtipo de Preventiva ───────────────────────

        /// Devuelve todos los subtipos activos de Preventiva con su PathArchivo configurado (puede ser vacío)
        public DataTable ListarSubtiposPreventivaConMensaje()
        {
            string strSQL = @"
                SELECT 
                    e.id         AS IdSubtipo,
                    e.descripcion AS Subtipo,
                    ISNULL(m.PathArchivo, '') AS PathArchivo
                FROM dbo.Especialidad e
                INNER JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id
                LEFT  JOIN dbo.ConfigMensajeSubtipoPreventiva m ON m.IdSubtipo = e.id
                WHERE mc.nombre = 'PREVENTIVA'
                  AND e.Padre = 0
                  AND e.estado = 1
                ORDER BY e.descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// Devuelve el PathArchivo para un subtipo específico; vacío si no está configurado
        public string GetPathMensajePorSubtipo(string idSubtipo)
        {
            string strSQL = "SELECT ISNULL(PathArchivo,'') FROM dbo.ConfigMensajeSubtipoPreventiva WHERE IdSubtipo = '" + idSubtipo + "'";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return string.Empty;
        }

        /// Guarda o actualiza el PathArchivo para un subtipo (upsert)
        public void GuardarPathMensajePorSubtipo(string idSubtipo, string pathArchivo)
        {
            string strSQL = @"
                IF EXISTS (SELECT 1 FROM dbo.ConfigMensajeSubtipoPreventiva WHERE IdSubtipo = '" + idSubtipo + @"')
                    UPDATE dbo.ConfigMensajeSubtipoPreventiva SET PathArchivo = '" + pathArchivo.Replace("'", "''") + @"' WHERE IdSubtipo = '" + idSubtipo + @"'
                ELSE
                    INSERT INTO dbo.ConfigMensajeSubtipoPreventiva (IdSubtipo, PathArchivo) VALUES ('" + idSubtipo + @"', '" + pathArchivo.Replace("'", "''") + @"')";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        /// Devuelve el PathArchivo laboral para un subtipo; vacío si no está configurado
        public string GetPathMensajePorSubtipoLaboral(string idSubtipo)
        {
            string strSQL = "SELECT ISNULL(PathArchivo,'') FROM dbo.ConfigMensajeSubtipoLaboral WHERE IdSubtipo = '" + idSubtipo + "'";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return string.Empty;
        }

        /// Guarda o actualiza el PathArchivo laboral para un subtipo (upsert)
        public void GuardarPathMensajePorSubtipoLaboral(string idSubtipo, string pathArchivo)
        {
            string strSQL = @"
                IF EXISTS (SELECT 1 FROM dbo.ConfigMensajeSubtipoLaboral WHERE IdSubtipo = '" + idSubtipo + @"')
                    UPDATE dbo.ConfigMensajeSubtipoLaboral SET PathArchivo = '" + pathArchivo.Replace("'", "''") + @"' WHERE IdSubtipo = '" + idSubtipo + @"'
                ELSE
                    INSERT INTO dbo.ConfigMensajeSubtipoLaboral (IdSubtipo, PathArchivo) VALUES ('" + idSubtipo + @"', '" + pathArchivo.Replace("'", "''") + @"')";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }
    }
}
