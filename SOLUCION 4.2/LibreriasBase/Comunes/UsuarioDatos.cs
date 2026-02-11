using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Comunes
{
    public class UsuarioDatos
    {
        public static string UsuarioSistema { get; set; }

        public List<bool> Permisos(string strUsuario)
        {
            List<bool> blnLista = new List<bool>();
            DataTable dt = null;

            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE username = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][13].ToString()));
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][14].ToString()));
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][15].ToString()));
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][16].ToString()));
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][17].ToString()));
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][18].ToString())); // Resumen

                blnLista.Add(Convert.ToBoolean(dt.Rows[0][19].ToString())); // Ver
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][20].ToString())); // Modificar
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][21].ToString())); // Eliminar

                blnLista.Add(Convert.ToBoolean(dt.Rows[0][22].ToString())); // Turnos
                blnLista.Add(Convert.ToBoolean(dt.Rows[0][24].ToString())); // Audiometria
            }

            return blnLista;
        }

        public string RecuperaMailUsuario(string strUsuario)
        {
            string strSQL = "";
            string strEmail = "";
            DataTable dt = null;

            strSQL = "SELECT TOP 1 email1 FROM dbo.Usuario WHERE username = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                strEmail = dt.Rows[0][0].ToString();
            }

            return strEmail;
        }

        public string RecuperaPassWordUsuario(string strUsuario)
        {
            string strSQL = "";
            string strpassword = "";
            DataTable dt = null;

            strSQL = "SELECT TOP 1 password FROM dbo.Usuario WHERE username = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                strpassword = dt.Rows[0][0].ToString();
            }

            return strpassword;
        }

        public bool VerificaUsuario(string strUsuario)
        {
            string strSQL = "";
            bool blnResultado = false;
            DataTable dt = null;

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE username = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }

        public bool ActualizaUsuario(string strUsuario, string strMail, string strPassword)
        {
            string strSQL = "";
            bool blnResultado = false;
            DataTable dt = null;

            strSQL = @"UPDATE dbo.Usuario
                        SET 
	                        password = '" + strPassword + @"',
	                        email1 = '" + strMail + @"'
                        WHERE username = '" + strUsuario + @"'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);


            return blnResultado;
        }

        // Método para obtener un usuario y asignar correctamente la propiedad Tipo
        public Usuario ObtenerUsuarioPorUsername(string strUsuario)
        {
            string strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE username = '" + strUsuario + "'";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            if (dt.Rows.Count > 0)
            {
                var usuario = new Usuario(
                    dt.Rows[0]["id"].ToString(),
                    dt.Rows[0]["nombre"].ToString(),
                    dt.Rows[0]["apellido"].ToString(),
                    dt.Rows[0]["username"].ToString(),
                    dt.Rows[0]["email1"].ToString(),
                    dt.Rows[0]["comentarios"].ToString(),
                    dt.Rows[0]["sucursalID"].ToString()
                );
                usuario.Tipo = dt.Rows[0]["Tipo"].ToString(); // Asignar correctamente el tipo
                // Asignar otros campos si es necesario
                return usuario;
            }
            return null;
        }

    }
}
