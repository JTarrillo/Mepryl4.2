using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Comunes;
using Entidades;

namespace CapaDatosMepryl
{
    public class UsuarioTipo
    {
        public UsuarioTipo()
        {

        }

        public bool GuardarTipoUsuario(List<object> valores)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = @"INSERT INTO dbo.UsuarioTipo 
                     (NombreTipo, PantVentanilla, PantMesaEntrada, PantPacientes, PantExamenes, PantConfiguracion, PantTurnos, PantResumen, PermisoVer, PermisoModif, PermisoEliminar, PantAudioMetria) 
                     VALUES 
                     (
                        '" + valores[0].ToString() + @"', 
                        '" + Convert.ToBoolean(valores[1].ToString()) + @"', 
                        '" + Convert.ToBoolean(valores[2].ToString()) + @"', 
                        '" + Convert.ToBoolean(valores[3].ToString()) + @"', 
                        '" + Convert.ToBoolean(valores[4].ToString()) + @"', 
                        '" + Convert.ToBoolean(valores[5].ToString()) + @"', 
                        '" + Convert.ToBoolean(valores[6].ToString()) + @"', 
                        '" + Convert.ToBoolean(valores[7].ToString()) + @"',                        
                        '" + Convert.ToBoolean(valores[8].ToString()) + @"',                        
                        '" + Convert.ToBoolean(valores[9].ToString()) + @"',                        
                        '" + Convert.ToBoolean(valores[10].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[11].ToString()) + @"')";
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

        public bool ActualizarTipoUsuario(int intID, List<object> valores)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = @"UPDATE dbo.UsuarioTipo
                        SET
	                        NombreTipo = '" + valores[0].ToString() + @"',
                            PantVentanilla = '" + Convert.ToBoolean(valores[1].ToString()) + @"',
	                        PantMesaEntrada = '" + Convert.ToBoolean(valores[2].ToString()) + @"',
	                        PantPacientes = '" + Convert.ToBoolean(valores[3].ToString()) + @"',
	                        PantExamenes = '" + Convert.ToBoolean(valores[4].ToString()) + @"',
	                        PantConfiguracion = '" + Convert.ToBoolean(valores[5].ToString()) + @"',                            
	                        PantTurnos = '" + Convert.ToBoolean(valores[6].ToString()) + @"',	                        
                            PantResumen = '" + Convert.ToBoolean(valores[7].ToString()) + @"',
	                        PermisoVer = '" + Convert.ToBoolean(valores[8].ToString()) + @"',
	                        PermisoModif = '" + Convert.ToBoolean(valores[9].ToString()) + @"',
                            permisoEliminar = '" + Convert.ToBoolean(valores[10].ToString()) + @"',
	                        PantAudioMetria = '" + Convert.ToBoolean(valores[11].ToString()) + @"'
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

        public DataTable ListarTipoUsuarios()
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT * FROM dbo.UsuarioTipo";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public bool TipoUsuarioExiste(string strNombreUsuario)
        {
            bool blnResultado = false;
            string strSQL = "";
            DataTable dt = null;

            strSQL = @"SELECT TOP 1 * FROM dbo.UsuarioTipo WHERE NombreTipo = '" + strNombreUsuario + @"'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }

        public DataTable BuscarTiposUsuario(string strUsuario)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = @"SELECT * FROM dbo.UsuarioTipo WHERE NombreTipo = '" + strUsuario + @"'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                        
            return dt;
        }

        public DataTable ListarNombreTipoUsuario()
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT id, NombreTipo FROM dbo.UsuarioTipo";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public bool BorrarTipoUsuario(int intID)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = "DELETE dbo.UsuarioTipo WHERE id = " + intID;
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }
    }
}
