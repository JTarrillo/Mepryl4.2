using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class ConfiguracionExamenRX
    {
        CapaDatosMepryl.ConfiguracionExamenRX Config;

        public ConfiguracionExamenRX()
        {
            // constructor
            Config = new CapaDatosMepryl.ConfiguracionExamenRX();
        }

        public DataTable MostrarLigasActivas(string strFiltro)
        {
            return Config.MostrarLigasActivas(strFiltro);
        }

        public bool InsertarLigasActivas(string IdLiga)
        {
            return Config.InsertarLigasActivas(IdLiga);
        }

        public bool ActualizarExamenRX(DataTable dtTabla)
        {
            return Config.ActualizarExamenRX(dtTabla);
        }

    }
}
