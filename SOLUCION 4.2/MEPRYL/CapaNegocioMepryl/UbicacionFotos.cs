using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaNegocioMepryl
{
    public class UbicacionFotos
    {
        private CapaDatosMepryl.UbicacionFotos Fotos;
                
        public UbicacionFotos()
        {
            Fotos = new CapaDatosMepryl.UbicacionFotos();
        }

        public DataTable RecuperarDirectorioFotos()
        {
            return Fotos.RecuperarDirectorioFotos();
        }

        public void GuardarDirectorioFotos(string strDirPreventiva, string strDirLaboral)
        {
            Fotos.GuardarDirectorioFotos(strDirPreventiva, strDirLaboral);
        }

        public string UbicacionFotoLaboral()
        {
            string strRespuesta = "";

            foreach (DataRow dtRow in RecuperarDirectorioFotos().Rows)
            {
                strRespuesta = dtRow[1].ToString();
            }

            return strRespuesta;
        }

        public string UbicacionFotopreventiva()
        {
            string strRespuesta = "";

            foreach (DataRow dtRow in RecuperarDirectorioFotos().Rows)
            {
                strRespuesta = dtRow[0].ToString();
            }

            return strRespuesta;
        }

        public string UbicacionFotoLiga()
        {
            string strRespuesta = "";

            foreach (DataRow dtRow in RecuperarDirectorioFotos().Rows)
            {
                strRespuesta = dtRow[2].ToString();
            }

            return strRespuesta;
        }

        public string UbicacionFotoClub()
        {
            string strRespuesta = "";

            foreach (DataRow dtRow in RecuperarDirectorioFotos().Rows)
            {
                strRespuesta = dtRow[3].ToString();
            }

            return strRespuesta;
        }

        public void GuardarFotosLiga(string strDirLiga, string strDirClub)
        {
            Fotos.GuardarFotosLiga(strDirLiga, strDirClub);
        }
    }
}
