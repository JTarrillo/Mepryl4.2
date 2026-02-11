using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using Comunes;
using System.IO;

namespace CapaDatosMepryl
{
    public class UbicacionFotos
    {
        public DataTable RecuperarDirectorioFotos()
        {
            string strSQL = "SELECT TOP 1 UbicacionPreventiva, UbicacionLaboral, UbicacionLiga, UbicacionClub FROM dbo.UbicacionFotos WHERE IdUbicacion = 1";
            DataTable UbicacionFotos = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            return UbicacionFotos;
        }

        public void GuardarDirectorioFotos(string strDirPreventiva, string strDirLaboral)
        {
            List<string> updateUbicaciones = SQLConnector.generarListaParaProcedure("@Preventiva", "@Laboral");
            SQLConnector.executeProcedure("sp_UbicacionFotos_UpdateUbicacion", updateUbicaciones, strDirPreventiva, strDirLaboral);
        }

        public void GuardarFotosLiga(string strDirLiga, string strDirClub)
        {
            string strSQL = "";

            strSQL = "UPDATE dbo.UbicacionFotos " +
                     "SET UbicacionLiga = '"+ strDirLiga + "', UbicacionClub = '" + strDirClub + "' " +
                     "WHERE idUbicacion = 1";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

        }

    }
}
