using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class ParametrosPlacas : EntidadBase
    {
        public string categoriaInicial = "";
        public string novenaCategoria = "";
        public string ligasIDs = "";
        public DateTime ultimoPeriodoDesde;
        public DateTime ultimoPeriodoHasta;
        
        public ParametrosPlacas(string entidadNom)
            : base(entidadNom)
        { }

        public ParametrosPlacas(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
