using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Consulta : EntidadBase
    {
        public string tipo = "";
        public DateTime fecha = DateTime.Now;
        public int nroOrden = 0;
        public string identificador = "";
        public Paciente paciente;
        public string observaciones = "";

        public Consulta(string entidadNom)
            : base(entidadNom)
        { }

        public Consulta(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
