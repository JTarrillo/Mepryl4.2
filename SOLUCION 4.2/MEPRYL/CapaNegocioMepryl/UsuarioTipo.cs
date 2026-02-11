using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{
    public class UsuarioTipo
    {
        private CapaDatosMepryl.UsuarioTipo userSistema;

        public UsuarioTipo()
        {
            userSistema = new CapaDatosMepryl.UsuarioTipo();
        }

        public bool GuardarTipoUsuario(List<object> valores)
        {
            return userSistema.GuardarTipoUsuario(valores);
        }

        public bool ActualizarTipoUsuario(int intID, List<object> valores)
        {
            return userSistema.ActualizarTipoUsuario(intID, valores);
        }

        public DataTable ListarTipoUsuarios()
        {
            return userSistema.ListarTipoUsuarios();
        }

        public bool TipoUsuarioExiste(string strNombreUsuario)
        {
            return userSistema.TipoUsuarioExiste(strNombreUsuario);
        }

        public DataTable ListarNombreTipoUsuario()
        {
            return userSistema.ListarNombreTipoUsuario();
        }

        public DataTable BuscarTiposUsuario(string strUsuario)
        {
            return userSistema.BuscarTiposUsuario(strUsuario);
        }

        public bool BorrarTipoUsuario(int intID)
        {
            return userSistema.BorrarTipoUsuario(intID);
        }
     }
}
