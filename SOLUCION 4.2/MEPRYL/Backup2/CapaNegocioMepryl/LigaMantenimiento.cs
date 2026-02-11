using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace CapaNegocioMepryl
{
    public class LigaMantenimiento
    {
        private CapaDatosMepryl.LigaMantenimiento Liga;

        public LigaMantenimiento()
        {
            Liga = new CapaDatosMepryl.LigaMantenimiento();
        }

        public DataTable MostrarLigasConFiltro(string strFiltro)
        {
            return Liga.MostrarLigasConFiltro(strFiltro);
        }

        public int NuevoCodigoIngresado()
        {
            // Corresponde al campo código, devuelve el último codigo ingresado + 1
            int intValor = 0;

            DataTable dtResultado = Liga.CampoCodigoOrdenado();
            if (dtResultado.Rows.Count > 0)
            {
                intValor = int.Parse(dtResultado.Rows[0].ItemArray[0].ToString());
            }

            return intValor + 1;
        }

        public bool ActualizarLigas(DataTable dtTabla)
        {
            return Liga.ActualizarLigas(dtTabla);
        }

        public bool EliminarLiga(string strID)
        {
            return Liga.EliminarLiga(strID);
        }

        public DataTable LigasActivas()
        {
            return Liga.LigasActivas();
        }

        public string RecuperaCodigoLiga(string IdLiga)
        {
            return Liga.RecuperaCodigoLiga(IdLiga);
        }
    }
}
