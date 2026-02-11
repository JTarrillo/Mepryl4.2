using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class ConfigMensajesCorreo
    {

        public ConfigMensajesCorreo()
        {
            //
        }

        public bool GuardarCorreo(List<object> valores)
        {
            bool blnResultado = false;
            DataTable dt = null;
            string strSQL = "";

            strSQL = @"INSERT INTO dbo.MensajesCorreo 
                        (Nombre, DireccionCorreo, Contrasena, ServidorSMTP, PuertoSMTP, SSL, TiempoEnvio, NombreUsuario, Asunto, IncluirAdjunto, Mensaje, Cabecera, Pie, TipoCorreo)
                        VALUES
                        (
                            '" + valores[0].ToString() + @"', 
                            '" + valores[1].ToString() + @"',
                            '" + valores[2].ToString() + @"', 
                            '" + valores[3].ToString() + @"', 
                            " + Convert.ToInt32(valores[4].ToString()) + @", 
                            " + VoF(valores[5].ToString()) + @", 
                            " + Convert.ToInt32(valores[6].ToString()) + @", 
                            '" + valores[7].ToString() + @"', 
                            '" + valores[8].ToString() + @"', 
                            " + VoF(valores[9].ToString()) + @", 
                            '" + valores[10].ToString() + @"',
                            '" + valores[11].ToString() + @"',
                            '" + valores[12].ToString() + @"',
                            '" + valores[13].ToString() + @"')
                        ";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        private byte VoF(string strValor)
        {
            byte intVerdadero = 0;

            if (strValor == "True")
                intVerdadero = 1;
            else
                intVerdadero = 0;

            return intVerdadero;
        }

        public bool ActualizarCorreo(int intID, List<object> valores)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = @"UPDATE dbo.MensajesCorreo
                        SET
                            Nombre = '" + valores[0].ToString() + @"',
	                        DireccionCorreo = '" + valores[1].ToString() + @"',
                            Contrasena = '" + valores[2].ToString() + @"',
                            ServidorSMTP = '" + valores[3].ToString() + @"',
	                        PuertoSMTP = " + Convert.ToInt32(valores[4].ToString()) + @", 
	                        SSL = " + VoF(valores[5].ToString()) + @", 
                            TiempoEnvio = " + Convert.ToInt32(valores[6].ToString()) + @", 
	                        NombreUsuario = '" + valores[7].ToString() + @"',
                            Asunto = '" + valores[8].ToString() + @"',
                            IncluirAdjunto = " + VoF(valores[9].ToString()) + @", 
                            Mensaje = '" + valores[10].ToString() + @"',
                            Cabecera = '" + valores[11].ToString() + @"',
                            Pie = '" + valores[12].ToString() + @"',
                            TipoCorreo = '" + valores[13].ToString() + @"'
                        WHERE id = " + intID + "";
            try
            {
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }
            catch (Exception ex)
            {
                blnResultado = true;
            }

            return blnResultado;
        }

        public DataTable ListarNombreCorreos(string strTipoCorreo)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT id, Nombre, DireccionCorreo FROM dbo.MensajesCorreo where TipoCorreo = '" + strTipoCorreo + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable ListarCorreosId(int intID, string strTipoCorreo)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT TOP 20 * FROM dbo.MensajesCorreo where id = " + intID + " AND TipoCorreo = '" + strTipoCorreo + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable ListarNombreCorreosPrevetniva(string strTipoCorreo)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT id, Nombre, DireccionCorreo FROM dbo.MensajesCorreo where TipoCorreo = 'P'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable ListarCorreosIdPreventiva(int intID, string strTipoCorreo)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT TOP 20 * FROM dbo.MensajesCorreo where id = " + intID + " AND TipoCorreo = 'P'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

    }    
}
