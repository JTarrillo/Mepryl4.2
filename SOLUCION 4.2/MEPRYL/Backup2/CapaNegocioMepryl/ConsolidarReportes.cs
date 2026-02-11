using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class ConsolidarReportes
    {
        private CapaDatosMepryl.ConsolidarReportes cr;

        public ConsolidarReportes()
        {
            cr = new CapaDatosMepryl.ConsolidarReportes();
        }

        public DataTable Directorios()
        {
            return cr.Directorios();
        }

        public DataTable DatosBase(DateTime FechaInicio, DateTime FechaFin, bool Movil, bool Clinica)
        {
            return cr.DatosBase(FechaInicio, FechaFin, Movil, Clinica);
        }

        public DataRow DatosBase(DateTime FechaInicio, DateTime FechaFin, bool Movil, bool Clinica, int NroOrden, string idTipoExamen)
        {
            return cr.DatosBase(FechaInicio, FechaFin, Movil, Clinica, NroOrden, idTipoExamen);
        }

        public string DirectorioPlacaRX(string DirectorioBase, string Fecha, string NroOrden)
        {
            string strPath = "";
            string strFiltro = "";

            strFiltro = Fecha + "*_" + NroOrden + "_*.jpg";

            DirectoryInfo di = new DirectoryInfo(DirectorioBase);

            if (Convert.ToInt32(NroOrden) < 200)
            {
                foreach (var fi in di.GetFiles(strFiltro, SearchOption.AllDirectories))
                {
                    if (File.Exists(fi.FullName))
                        strPath = fi.DirectoryName;
                    else
                        strPath = "";
                }
            }
            else
            {
                strFiltro = Fecha + "*_" + NroOrden + " DNI*.jpg";

                foreach (var fi in di.GetFiles(strFiltro, SearchOption.AllDirectories))
                {                    
                    if (File.Exists(fi.FullName))
                        strPath = fi.DirectoryName;
                    else
                        strPath = "";                    
                }
            }

            return strPath;
        }
    }
}
