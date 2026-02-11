using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes
{
    public class UsuarioGlobal
    {        
        static string _usuario = "";

        public static string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
    }
}
