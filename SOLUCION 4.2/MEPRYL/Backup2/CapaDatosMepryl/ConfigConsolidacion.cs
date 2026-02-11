using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class ConfigConsolidacion
    {
        public ConfigConsolidacion()
        {
            //
        }

        public DataTable DirectoriosConsPreventiva()
        {
            DataTable dtDirectorios;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.configConsolidacion WHERE id = 1";
            dtDirectorios = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtDirectorios;
        }

        public bool ActualizaConsPreventiva(List<string> valores)
        {
            bool blnResultado = false;

            string strSQL = "";

            strSQL = "UPDATE dbo.configConsolidacion " +
                     "SET " +
                        "plantilla = '" + valores[0].ToString() + "', " +
                        "InfRadiologico = '" + valores[1].ToString() + "', " +
                        "InfClinico = '" + valores[2].ToString() + "', " +
                        "InfLaboratorio = '" + valores[3].ToString() + "', " +
                        "InfRX = '" + valores[4].ToString() + "', " +
                        "InfECG = '" + valores[5].ToString() + "', " +
                        "InfConsolidado = '" + valores[6].ToString() + "' " +
                     "WHERE id = 1";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            blnResultado = true;

            return blnResultado;
        }
    }
}
