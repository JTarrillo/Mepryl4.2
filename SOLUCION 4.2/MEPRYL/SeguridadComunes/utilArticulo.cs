using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Globalization;
using KMCurrencyTextBox;

namespace Comunes
{
    class utilArticulo
    {
        public static bool existeElArticulo(Configuracion configuracion, string codigoInterno)
        {
            try
            {
                bool resultado;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@codigoInterno", codigoInterno);

                SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_getArticuloByCodigoInterno",param);

                if (dr.HasRows)
                    resultado = true;
                else
                    resultado = false;

                dr.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return false;
            }
        }
    }
}
