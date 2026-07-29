using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using Comunes;
using Entidades;

namespace CapaDatosMepryl
{
    public class UsuarioSistema
    {
        private bool blnPermisoVer, blnPermisoMod, blnPermisoEli;
        private bool blnPantConfig, blnPantExamen, blnPantPacien, blnPantMesa, blnPantVenta, blnPantResumen;

        public UsuarioSistema()
        {
            //
        }

        public bool GuardarUsuario(List<object> valores)
        {
            bool blnRetornar = false;
            string strSQL = "";

            strSQL = @"INSERT INTO dbo.Usuario 
                     (id, username, password, apellido, nombre, email1, Tipo, 
                      VentConfiguracion, VentExamenes, VentMesa, VentPacientes, VentVentanilla, VentResumen,
                      PermisoVer, PermisoModificar, PermisoEliminar, VentTurnos, Activo, VentAudiometria, VentFacturacion, dni)
                     VALUES
                     (NEWID(), 
                        '" + valores[0].ToString() + @"', 
                        '" + Utilidades.encriptar(valores[1].ToString()) + @"', 
                        '" + valores[2].ToString() + @"', 
                        '" + valores[3].ToString() + @"', 
                        '" + valores[4].ToString() + @"', 
                        '" + valores[5].ToString() + @"',
                        '" + Convert.ToBoolean(valores[6].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[7].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[8].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[9].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[10].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[11].ToString()) + @"',
                        
                        '" + Convert.ToBoolean(valores[12].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[13].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[14].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[15].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[16].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[17].ToString()) + @"',
                        '" + Convert.ToBoolean(valores[18].ToString()) + @"',
                        '" + valores[19].ToString() + @"'
                        )";
            try
            {
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }
            catch (Exception ex)
            {
                blnRetornar = true;
            }

            return blnRetornar;
        }

        public bool GuardarUsuario(Entidades.UsuarioSistema entidad)
        {
            bool blnRetornar = false;
            try
            {
                // DIAG TEMPORAL
                Debug.WriteLine("===== DIAG GuardarUsuario =====");
                Debug.WriteLine("Tipo='" + entidad.Tipo + "' (len=" + (entidad.Tipo ?? "").Length + ")");
                Debug.WriteLine("Username='" + entidad.Username + "'");
                Debug.WriteLine("Password='" + entidad.Password + "'");
                Debug.WriteLine("Apellido='" + entidad.Apellido + "'");
                Debug.WriteLine("Nombre='" + entidad.Nombre + "'");
                Debug.WriteLine("Email='" + entidad.Email + "'");
                Debug.WriteLine("DNI='" + entidad.DNI + "'");
                Debug.WriteLine("ProfAsig='" + entidad.ProfesionalAsignado + "'");
                Debug.WriteLine("================================");
                string strProfAsig = entidad.ProfesionalAsignado == Guid.Empty ? "NULL" : "'" + entidad.ProfesionalAsignado.ToString() + "'";
                string strSQL = @"INSERT INTO dbo.Usuario 
                     (id, username, password, apellido, nombre, email1, Tipo, 
                      VentConfiguracion, VentExamenes, VentMesa, VentPacientes, VentVentanilla, VentResumen,
                      PermisoVer, PermisoModificar, PermisoEliminar, VentTurnos, Activo, VentAudiometria, dni, ProfesionalAsignado)
                     VALUES
                     (NEWID(), 
                        '" + (entidad.Username ?? "").Replace("'", "''") + @"', 
                        '" + (Utilidades.encriptar(entidad.Password ?? "") ?? "") + @"', 
                        '" + (entidad.Apellido ?? "").Replace("'", "''") + @"', 
                        '" + (entidad.Nombre ?? "").Replace("'", "''") + @"', 
                        '" + (entidad.Email ?? "").Replace("'", "''") + @"', 
                        '" + (entidad.Tipo ?? "").Replace("'", "''") + @"',
                        " + (entidad.VentConfiguracion ? "1" : "0") + @",
                        " + (entidad.VentExamenes ? "1" : "0") + @",
                        " + (entidad.VentMesa ? "1" : "0") + @",
                        " + (entidad.VentPacientes ? "1" : "0") + @",
                        " + (entidad.VentVentanilla ? "1" : "0") + @",
                        " + (entidad.VentResumen ? "1" : "0") + @",
                        " + (entidad.PermisoVer ? "1" : "0") + @",
                        " + (entidad.PermisoModificar ? "1" : "0") + @",
                        " + (entidad.PermisoEliminar ? "1" : "0") + @",
                        " + (entidad.VentTurnos ? "1" : "0") + @",
                        " + (entidad.Activo ? "1" : "0") + @",
                        " + (entidad.VentAudiometria ? "1" : "0") + @",
                        '" + (entidad.DNI ?? "").Replace("'", "''") + @"',
                        " + strProfAsig + @"
                        )";
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }
            catch (Exception ex)
            {
                blnRetornar = true;
            }

            return blnRetornar;
        }

        public bool ActualizarUsuario(string strId, List<object> valores)
        {
            bool blnRetornar = false;
            string strSQL = "";

            strSQL = @"UPDATE dbo.Usuario  
                       SET  
                          username = '" + valores[0].ToString() + @"', 
                          password = '" + Utilidades.encriptar(valores[1].ToString()) + @"',  
                          apellido = '" + valores[2].ToString() + @"',
                          nombre = '" + valores[3].ToString() + @"', 
                          email1 = '" + valores[4].ToString() + @"', 
                          Tipo = '" + valores[5].ToString() + @"',

                          VentConfiguracion = '" + Convert.ToBoolean(valores[6].ToString()) + @"',
                          VentExamenes = '" + Convert.ToBoolean(valores[7].ToString()) + @"',
                          VentMesa = '" + Convert.ToBoolean(valores[8].ToString()) + @"',
                          VentPacientes = '" + Convert.ToBoolean(valores[9].ToString()) + @"',
                          VentVentanilla = '" + Convert.ToBoolean(valores[10].ToString()) + @"',
                          VentResumen = '" + Convert.ToBoolean(valores[11].ToString()) + @"',

                          PermisoVer = '" + Convert.ToBoolean(valores[12].ToString()) + @"',
                          PermisoModificar = '" + Convert.ToBoolean(valores[13].ToString()) + @"',
                          PermisoEliminar = '" + Convert.ToBoolean(valores[14].ToString()) + @"' ,

                          VentTurnos = '" + Convert.ToBoolean(valores[15].ToString()) + @"' ,
                          Activo = '" + Convert.ToBoolean(valores[16].ToString()) + @"' ,
                          VentAudiometria = '" + Convert.ToBoolean(valores[17].ToString()) + @"' ,
                          VentFacturacion = '" + Convert.ToBoolean(valores[18].ToString()) + @"' ,
                          dni = '" + valores[19].ToString() + @"'
                      WHERE id = '" + strId + @"'";
            try
            {
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }
            catch (Exception ex)
            {
                blnRetornar = true;
            }

            return blnRetornar;
        }

        public bool ActualizarUsuario(Entidades.UsuarioSistema entidad)
        {
            bool blnRetornar = false;
            try
            {
                // DIAG TEMPORAL
                Debug.WriteLine("===== DIAG ActualizarUsuario =====");
                Debug.WriteLine("Tipo='" + entidad.Tipo + "' (len=" + (entidad.Tipo ?? "").Length + ")");
                Debug.WriteLine("Username='" + entidad.Username + "'");
                Debug.WriteLine("DNI='" + entidad.DNI + "'");
                Debug.WriteLine("Id='" + entidad.Id + "'");
                Debug.WriteLine("==================================");
                string strProfAsig = entidad.ProfesionalAsignado == Guid.Empty ? "NULL" : "'" + entidad.ProfesionalAsignado.ToString() + "'";
                string strSQL = @"UPDATE dbo.Usuario  
                       SET  
                          username = '" + (entidad.Username ?? "").Replace("'", "''") + @"', 
                          password = '" + (Utilidades.encriptar(entidad.Password ?? "") ?? "") + @"',  
                          apellido = '" + (entidad.Apellido ?? "").Replace("'", "''") + @"',
                          nombre = '" + (entidad.Nombre ?? "").Replace("'", "''") + @"', 
                          email1 = '" + (entidad.Email ?? "").Replace("'", "''") + @"', 
                          Tipo = '" + (entidad.Tipo ?? "").Replace("'", "''") + @"',
                          VentConfiguracion = " + (entidad.VentConfiguracion ? "1" : "0") + @",
                          VentExamenes = " + (entidad.VentExamenes ? "1" : "0") + @",
                          VentMesa = " + (entidad.VentMesa ? "1" : "0") + @",
                          VentPacientes = " + (entidad.VentPacientes ? "1" : "0") + @",
                          VentVentanilla = " + (entidad.VentVentanilla ? "1" : "0") + @",
                          VentResumen = " + (entidad.VentResumen ? "1" : "0") + @",
                          PermisoVer = " + (entidad.PermisoVer ? "1" : "0") + @",
                          PermisoModificar = " + (entidad.PermisoModificar ? "1" : "0") + @",
                          PermisoEliminar = " + (entidad.PermisoEliminar ? "1" : "0") + @",
                          VentTurnos = " + (entidad.VentTurnos ? "1" : "0") + @",
                          Activo = " + (entidad.Activo ? "1" : "0") + @",
                          VentAudiometria = " + (entidad.VentAudiometria ? "1" : "0") + @",
                          ProfesionalAsignado = " + strProfAsig + @" 
                      WHERE id = '" + entidad.Id + @"'";
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }
            catch (Exception ex)
            {
                blnRetornar = true;
            }

            return blnRetornar;
        }

        public bool ActualizaProfesionalAsignado(string strIdUsuario, string strIdProfesinal)
        {
            bool blnRetornar = false;
            string strSQL = "";

            strSQL = "update dbo.Usuario " +
                     "set ProfesionalAsignado = '" + strIdProfesinal + "' " +
                     "WHERE id = '" + strIdUsuario + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnRetornar;
        }

        public string RecuperaIDProfesionalAsignado(string strIdUsuario)
        {
            string strIdProfesional = "";
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT ProfesionalAsignado FROM dbo.Usuario WHERE id = '" + strIdUsuario + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                strIdProfesional = dt.Rows[0][0].ToString();
            }

            return strIdProfesional;
        }

        public DataTable ListarUsuarios()
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT TOP 50 id, password, username as 'Usuario', nombre as 'Nombre', apellido as 'Apellido', email1 as 'E-Mail', Tipo as 'Tipo Usuario', Activo, ProfesionalAsignado, dni FROM dbo.Usuario WHERE Activo = 1 ORDER BY username";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable ListarUsuarios(string strDNI)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT USU.id as 'IdProfesional', PAL.id as 'IdPaciente', EMP.id as 'idEmpresa', " +
                     "EMP.razonSocial, PAL.apellido, PAL.nombres, PAL.dni, PAL.cuil, PAL.fechaNacimiento, PAL.telefonos, " +
                     "PAL.celular, PAL.direccion, EPP.tarea, PAL.mail, " +
                     "USU.username, USU.password, USU.sucursalID, USU.email1, USU.comentarios, USU.actualizacion_local, USU.operacion_local, USU.serverID, USU.Tipo, " +
                     "USU.VentConfiguracion, VentExamenes, VentMesa, VentPacientes, VentVentanilla, VentResumen, VentTurnos, VentAudiometria, PermisoVer, " +
                     "PermisoModificar, PermisoEliminar, Activo, ProfesionalAsignado " +
                     "FROM dbo.Usuario USU " +
                     "INNER JOIN PacienteLaboral PAL ON USU.dni = PAL.dni " +
                     "INNER JOIN EmpresasPorPaciente EPP ON EPP.idPaciente = PAL.id " +
                     "INNER JOIN Empresa EMP ON EMP.id = EPP.idEmpresa " +
                     "WHERE USU.dni = '" + strDNI + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public bool ActualizaActivo(Byte blnActivo, string strIdUsuario)
        {
            DataTable dt = null;
            string strSQL = "";
            bool blnResultado = false;

            strSQL = "UPDATE dbo.Usuario " +
                     "SET Activo = " + blnActivo + " " +
                     "WHERE id = '" + strIdUsuario + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        public void ActualizarCampoUsuario(string strIdUsuario, string strCampo, string strValor)
        {
            string strSQL = "UPDATE dbo.Usuario SET [" + strCampo + "] = " + strValor + " WHERE id = '" + strIdUsuario + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool BorrarUsuario(string strID)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = "DELETE FROM dbo.Usuario WHERE id = '" + strID + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnResultado;
        }

        public bool EliminarUsuario(string strID)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = "DELETE FROM dbo.Usuario WHERE id = '" + strID + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            blnResultado = true;
            return blnResultado;
        }

        public bool BuscaNombreUsuario(string strUsuario)
        {
            DataTable dt = null;
            bool blnResultado = false;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE username = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }

        public bool BuscaDNIExacto(string strDNI)
        {
            DataTable dt = null;
            bool blnResultado = false;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE dni = '" + strDNI + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }

        public DataTable ListaPermisoUsuarios(string strUsuario)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE id = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable ListaPermisoUsuariosDefecto(string strUsuario)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE Tipo = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable ListaPermisoUserName(string strNombreUsuario)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE username = '" + strNombreUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public string FirmaProfesional(string strUsername)
        {
            string strResultado = "";
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT firma  from dbo.Usuario USU " +
                        "INNER JOIN dbo.Profesional PRO ON USU.profesionalAsignado = PRO.id " +
                        "where username = '" + strUsername + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                strResultado = dt.Rows[0][0].ToString();
            }

            return strResultado;
        }

        public DataTable ListaPermisoPorNombre(string strUsuario)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * FROM dbo.Usuario WHERE username = '" + strUsuario + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable BuscarApellidoUsuario(string strApellido)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT TOP 50 id, password, username as 'Usuario', nombre as 'Nombre', apellido as 'Apellido', " +
                     "email1 as 'E-Mail', Tipo as 'Tipo Usuario', Activo, ProfesionalAsignado, " +
                     "apellido + ' ' + nombre as 'NombreApellido', Tipo as 'TipoUsuario', dni " +
                     "FROM dbo.Usuario " +
                     "WHERE apellido like '%" + strApellido + "%' AND Activo = 1 " +
                     "ORDER BY apellido";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable BuscarDNIUsuario(string strDNI)
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT TOP 50 id, password, username as 'Usuario', nombre as 'Nombre', apellido as 'Apellido', " +
                     "email1 as 'E-Mail', Tipo as 'Tipo Usuario', Activo, ProfesionalAsignado, " +
                     "apellido + ' ' + nombre as 'NombreApellido', Tipo as 'TipoUsuario', dni " +
                     "FROM dbo.Usuario " +
                     "WHERE dni like '%" + strDNI + "%' " +
                     "ORDER BY apellido";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable ListarUsuariosConPermisos()
        {
            DataTable dt = null;
            string strSQL = "";

            strSQL = "SELECT id, username as 'Usuario', apellido as 'Apellido', nombre as 'Nombre', " +
                     "Tipo as 'Tipo Usuario', dni as 'DNI', Activo, " +
                     "fechaCreacion as 'Fecha Creación', " +
                     "VentVentanilla as 'Ventanilla', VentMesa as 'Mesa Entrada', " +
                     "VentPacientes as 'Pacientes', VentExamenes as 'Exámenes', " +
                     "VentConfiguracion as 'Configuración', VentTurnos as 'Turnos', " +
                     "VentResumen as 'Planilla', VentAudiometria as 'Audiometría', " +
                     "VentFacturacion as 'Facturación', " +
                     "PermisoVer as 'Ver', PermisoModificar as 'Modificar', PermisoEliminar as 'Eliminar' " +
                     "FROM dbo.Usuario ORDER BY apellido";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public void ActualizaProfesionalAsignado(string strDNI)
        {
            DataTable dt = null;
            string strSQL = "";
            string strIdProfesional = "";

            strSQL = "SELECT * from dbo.Profesional WHERE dni = '" + strDNI + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                strIdProfesional = dt.Rows[0][0].ToString();

                strSQL = "UPDATE dbo.Usuario " +
                         "SET ProfesionalAsignado = '" + strIdProfesional + "' " +
                         "WHERE dni = '" + strDNI + "'";
                dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }
        }

        public void ActualizaUsuarioBasico(Entidades.UsuarioSistema entidad)
        {
            string strSQL = "";

            strSQL = "UPDATE dbo.Usuario " +
                     "SET apellido = '" + entidad.Apellido + "', nombre = '" + entidad.Nombre + "', email1 = '" + entidad.Email + "' " +
                     "WHERE dni = '" + entidad.DNI + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListaUsuariosPorEmpresa(string strIdEmpresa)
        {
            string strSQL = "";

            strSQL = "SELECT PAL.nombres, PAL.Apellido, PAL.dni, PAL.Telefonos, PAL.mail FROM PacienteLaboral PAL " +
                     "INNER JOIN EmpresasPorPaciente EPP ON EPP.idPaciente = PAL.id " +
                     "INNER JOIN Empresa EMP ON EMP.id = EPP.idEmpresa " +
                     "WHERE EMP.id = '" + strIdEmpresa + "'";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool ExisteUsuario(string strDNI)
        {
            string strSQL = "";
            bool blnResultado = false;

            strSQL = "SELECT dni FROM dbo.Usuario WHERE dni = '" + strDNI + "'";
            if (SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }
    }
}
