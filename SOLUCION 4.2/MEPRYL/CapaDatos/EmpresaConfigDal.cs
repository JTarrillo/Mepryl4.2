using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
   public class EmpresaConfigDal:EntidadBase
    {
       public string razonSocial = "";
       public string rutaLogo = "";
       public string rutaFirma = "";
       public string direccion = "";
       public string unidadFotos = "";
       public EmpresaConfigDal(string entidadNom)
            : base(entidadNom)
        { }

       public EmpresaConfigDal(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
           // this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
