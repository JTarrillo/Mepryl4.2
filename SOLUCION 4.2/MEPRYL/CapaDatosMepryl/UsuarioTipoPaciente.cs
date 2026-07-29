using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class UsuarioTipoPaciente
    {
        public DataTable ListarPorDNI(string strDNI)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT id, username, password, dni, apellido, nombre, Tipo, Activo, fechaCreacion " +
                     "FROM dbo.UsuarioTipoPaciente " +
                     "WHERE dni = '" + strDNI.Replace("'", "''") + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            return dt;
        }

        public bool Guardar(Entidades.UsuarioTipoPaciente entidad)
        {
            string strSQL = "";
            bool blnResultado = false;

            strSQL = @"INSERT INTO dbo.UsuarioTipoPaciente
                     (id, username, password, dni, apellido, nombre, Tipo, Activo, fechaCreacion)
                     VALUES
                     (NEWID(),
                        '" + (entidad.Username ?? "").Replace("'", "''") + @"',
                        '" + (Utilidades.encriptar(entidad.Password ?? "") ?? "") + @"',
                        '" + (entidad.DNI ?? "").Replace("'", "''") + @"',
                        '" + (entidad.Apellido ?? "").Replace("'", "''") + @"',
                        '" + (entidad.Nombre ?? "").Replace("'", "''") + @"',
                        '" + (entidad.Tipo ?? "").Replace("'", "''") + @"',
                        " + (entidad.Activo ? "1" : "0") + @",
                        GETDATE())";

            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            blnResultado = true;

            return blnResultado;
        }

        public bool Actualizar(Entidades.UsuarioTipoPaciente entidad)
        {
            string strSQL = "";
            bool blnResultado = false;

            strSQL = @"UPDATE dbo.UsuarioTipoPaciente
                     SET username = '" + (entidad.Username ?? "").Replace("'", "''") + @"',
                         password = '" + (Utilidades.encriptar(entidad.Password ?? "") ?? "") + @"',
                         apellido = '" + (entidad.Apellido ?? "").Replace("'", "''") + @"',
                         nombre = '" + (entidad.Nombre ?? "").Replace("'", "''") + @"',
                         Activo = " + (entidad.Activo ? "1" : "0") + @"
                     WHERE id = '" + entidad.Id.ToString() + "'";

            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            blnResultado = true;

            return blnResultado;
        }

        public bool ActualizaActivo(bool blnActivo, string strIdUsuario)
        {
            string strSQL = "";
            bool blnResultado = false;

            strSQL = "UPDATE dbo.UsuarioTipoPaciente " +
                     "SET Activo = " + (blnActivo ? "1" : "0") + " " +
                     "WHERE id = '" + strIdUsuario + "'";

            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            blnResultado = true;

            return blnResultado;
        }
    }
}
