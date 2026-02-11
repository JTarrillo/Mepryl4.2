using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class ConfigMensajesCorreo
    {
        CapaDatosMepryl.ConfigMensajesCorreo Mensajes;

        public ConfigMensajesCorreo()
        {
            Mensajes = new CapaDatosMepryl.ConfigMensajesCorreo();
        }

        public bool GuardarCorreo(List<object> valores)
        {
            return Mensajes.GuardarCorreo(valores);
        }

        public bool ActualizarCorreo(int intID, List<object> valores)
        {
            return Mensajes.ActualizarCorreo(intID, valores);
        }

        public DataTable ListarNombreCorreos(string strTipoCorreo)
        {
            return Mensajes.ListarNombreCorreos(strTipoCorreo);
        }

        public DataTable ListarCorreosId(int intID, string strTipoCorreo)
        {
            return Mensajes.ListarCorreosId(intID, strTipoCorreo);
        }

        public DataTable ListarNombreCorreosPrevetniva(string strTipoCorreo)
        {
            return Mensajes.ListarNombreCorreosPrevetniva(strTipoCorreo);
        }

        public DataTable ListarCorreosIdPreventiva(int intID, string strTipoCorreo)
        {
            return Mensajes.ListarCorreosIdPreventiva(intID, strTipoCorreo);
        }
    }
}
