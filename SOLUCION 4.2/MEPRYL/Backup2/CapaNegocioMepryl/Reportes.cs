using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{    
    public class Reportes
    {
        private CapaDatosMepryl.Reportes reporte;

        public Reportes()
        {
            reporte = new CapaDatosMepryl.Reportes();
        }

        public DataTable ReporteEspirometria(string strIdExamenLaboral, string strDNI)
        {
            return reporte.ReporteEspirometria(strIdExamenLaboral, strDNI);
        }                
    }
}
