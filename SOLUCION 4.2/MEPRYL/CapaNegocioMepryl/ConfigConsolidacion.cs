using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class ConfigConsolidacion
    {
        CapaDatosMepryl.ConfigConsolidacion Consolidar;

        public ConfigConsolidacion()
        {
            //Constructor
            Consolidar = new CapaDatosMepryl.ConfigConsolidacion();
        }

        public DataTable DirectoriosConsPreventiva()
        {
            return Consolidar.DirectoriosConsPreventiva();
        }

        public bool ActualizaConsPreventiva(List<string> valores)
        {
            return Consolidar.ActualizaConsPreventiva(valores);
        }

        public bool ActualizaGeneraConsolidado(List<string> valores)
        {
            return Consolidar.ActualizaGeneraConsolidado(valores);
        }

        public DataTable DirectoriosConsLaboral()
        {
            return Consolidar.DirectoriosConsLaboral();
        }

        public bool ActualizaConsLaboral(List<string> valores)
        {
            return Consolidar.ActualizaConsLaboral(valores);
        }

        public bool ActualizaGeneraConsolidadoLaboral(List<string> valores)
        {
            return Consolidar.ActualizaGeneraConsolidadoLaboral(valores);
        }
    }
}
