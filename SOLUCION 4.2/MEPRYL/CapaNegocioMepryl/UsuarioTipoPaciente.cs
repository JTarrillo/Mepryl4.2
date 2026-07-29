using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{
    public class UsuarioTipoPaciente
    {
        private CapaDatosMepryl.UsuarioTipoPaciente usuarioTipoPaciente;

        public UsuarioTipoPaciente()
        {
            usuarioTipoPaciente = new CapaDatosMepryl.UsuarioTipoPaciente();
        }

        public DataTable ListarPorDNI(string strDNI)
        {
            return usuarioTipoPaciente.ListarPorDNI(strDNI);
        }

        public bool Guardar(Entidades.UsuarioTipoPaciente entidad)
        {
            return usuarioTipoPaciente.Guardar(entidad);
        }

        public bool Actualizar(Entidades.UsuarioTipoPaciente entidad)
        {
            return usuarioTipoPaciente.Actualizar(entidad);
        }

        public bool ActualizaActivo(bool blnActivo, string strIdUsuario)
        {
            return usuarioTipoPaciente.ActualizaActivo(blnActivo, strIdUsuario);
        }
    }
}
