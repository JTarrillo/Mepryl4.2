using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{
    public class UsuarioSistema
    {
        private CapaDatosMepryl.UsuarioSistema userSistema;        

        public UsuarioSistema()
        {
            userSistema = new CapaDatosMepryl.UsuarioSistema();
        }

        public bool GuardarUsuario(List<object> valores)
        {
            return userSistema.GuardarUsuario(valores);
        }

        public DataTable ListarUsuarios()
        {
            return userSistema.ListarUsuarios();
        }

        public bool ActualizarUsuario(string strId, List<object> valores)
        {
            return userSistema.ActualizarUsuario(strId, valores);
        }

        public bool BuscaNombreUsuario(string strUsuario)
        {
            return userSistema.BuscaNombreUsuario(strUsuario);
        }

        public bool BorrarUsuario(string strID)
        {
            return userSistema.BorrarUsuario(strID);
        }

        public DataTable ListaPermisoUsuarios(string strUsuario)
        {
            return userSistema.ListaPermisoUsuarios(strUsuario);
        }

        public DataTable ListaPermisoUsuariosDefecto(string strUsuario)
        {
            return userSistema.ListaPermisoUsuariosDefecto(strUsuario);
        }

        public DataTable ListaPermisoUserName(string strNombreUsuario)
        {
            return userSistema.ListaPermisoUserName(strNombreUsuario);
        }

        public bool ActualizaProfesionalAsignado(string strIdUsuario, string strIdProfesinal)
        {
            return userSistema.ActualizaProfesionalAsignado(strIdUsuario, strIdProfesinal);
        }

        public string RecuperaIDProfesionalAsignado(string strIdUsuario)
        {
            return userSistema.RecuperaIDProfesionalAsignado(strIdUsuario);
        }

        public string FirmaProfesional(string strUsername)
        {
            return userSistema.FirmaProfesional(strUsername);
        }

        public DataTable ListaPermisoPorNombre(string strUsuario)
        {
            return userSistema.ListaPermisoPorNombre(strUsuario);
        }

        public bool ActualizaActivo(Byte blnActivo, string strIdUsuario)
        {
            return userSistema.ActualizaActivo(blnActivo, strIdUsuario);
        }

        public DataTable BuscarApellidoUsuario(string strApellido)
        {
            return userSistema.BuscarApellidoUsuario(strApellido);
        }

        public DataTable ListarUsuarios(string strDNI)
        {
            return userSistema.ListarUsuarios(strDNI);
        }

        public bool GuardarUsuario(Entidades.UsuarioSistema entidad)
        {
            return userSistema.GuardarUsuario(entidad);
        }

        public bool ActualizarUsuario(Entidades.UsuarioSistema entidad)
        {
            return userSistema.ActualizarUsuario(entidad);
        }

        public void ActualizaProfesionalAsignado(string strDNI)
        {
            userSistema.ActualizaProfesionalAsignado(strDNI);
        }

        public void ActualizaUsuarioBasico(Entidades.UsuarioSistema entidad)
        {
            userSistema.ActualizaUsuarioBasico(entidad);
        }

        public DataTable ListaUsuariosPorEmpresa(string strIdEmpresa)
        {
            return userSistema.ListaUsuariosPorEmpresa(strIdEmpresa);
        }

        public bool ExisteUsuario(string strDNI)
        {
            return userSistema.ExisteUsuario(strDNI);
        }
    }
}
