using System;
using System.Collections.Generic;
using System.Text;
using Comunes;
using System.Data.SqlClient;

namespace CapaDatosBase
{
    public class EntidadBase
    {
        public Guid id = new Guid(Utilidades.ID_VACIO);
        public string codigo = "";
        public string EntidadNombre = "";
    }
}
