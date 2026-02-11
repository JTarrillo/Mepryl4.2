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
    }
}
