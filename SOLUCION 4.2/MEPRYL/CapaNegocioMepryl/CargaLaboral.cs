using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class CargaLaboral
    {
        private CapaDatosMepryl.Laboral datLaboral;

        public CargaLaboral()
        {
            datLaboral = new Laboral();
        }

        public DataTable cargarListadoSinFiltro(DateTime desde, DateTime hasta, List<string> filtro)
        {
            return datLaboral.consultasSinFiltro(desde.ToShortDateString(), hasta.ToShortDateString(), filtro);
        }

        public DataTable cargarListadoConFiltro(string filtro)
        {
            return datLaboral.consultasConFiltro(filtro);
        }
    }
}
