using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocioMepryl
{
    public class ConfigPlantillaReporte
    {
        CapaDatosMepryl.ConfigPlantillaReporte Plantilla;

        public ConfigPlantillaReporte()
        {
            Plantilla = new CapaDatosMepryl.ConfigPlantillaReporte();
        }

        public bool guardarPlantilla(List<object> valores)
        {
            return Plantilla.guardarPlantilla(valores);
        }

        public bool ActualizaPlantilla(string strTipo, List<object> valores)
        {
            return Plantilla.ActualizaPlantilla(strTipo, valores);
        }

        public DataTable ListarPlantillas(string strTipo)
        {
            return Plantilla.ListarPlantillas(strTipo);
        }

        public bool ActualizaMensajeTurno(char strTipoPaciente, string strPathArchivo)
        {
            return Plantilla.ActualizaMensajeTurno(strTipoPaciente, strPathArchivo);
        }

        public bool ActualizaMensajeTurno2(char strTipoPaciente, string strPathArchivo)
        {
            return Plantilla.ActualizaMensajeTurno2(strTipoPaciente, strPathArchivo);
        }

        public bool ActualizaMensajeTurno3(char strTipoPaciente, string strPathArchivo)
        {
            return Plantilla.ActualizaMensajeTurno3(strTipoPaciente, strPathArchivo);
        }

        }
}
