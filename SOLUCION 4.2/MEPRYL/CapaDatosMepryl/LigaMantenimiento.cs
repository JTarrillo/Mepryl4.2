using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class LigaMantenimiento
    {
        System.IO.MemoryStream objIMG = new System.IO.MemoryStream();
        
        public LigaMantenimiento()
        {
            // Constructor
        }

        public DataTable MostrarLigasConFiltro(string strFiltro)
        {
            string strSQL = "EXEC sp_liga_MostrarFiltro '" + strFiltro + "'";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable CampoCodigoOrdenado()
        {
            string strSQL = "SELECT codigo " +
                            "FROM dbo.Liga " +
                            "ORDER BY (CASE " +
                            "when isnumeric(codigo) = 1 then cast (codigo as int) " +
                            "END) DESC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool ActualizarLigas(DataTable dtTabla)
        {            
            bool blnResultado = false;
            byte bytActivo = 0;
            ConfiguracionExamenRX RX = new ConfiguracionExamenRX();
            
            foreach (DataRow r in dtTabla.Rows)
            {
                //byte[] valorColumna = (byte[])r[4];
                //objIMG = new System.IO.MemoryStream(valorColumna);
                
                bool blnActivo = (bool)r[4];

                if (blnActivo == true)
                    bytActivo = 1;
                else
                    bytActivo = 0;

                if (ComprobarExisteLiga(r[1].ToString()))
                {
                    List<string> list = SQLConnector.generarListaParaProcedure("@Id", "@Codigo", "@Descripcion"
                       , "@registroBLOB", "@Activo", "@PathImagen");
                    SQLConnector.executeProcedure("sp_Liga_UpdateFiltro", list,
                        r[0].ToString(),
                        r[1].ToString(),
                        r[2].ToString(),
                        r[3].ToString(),
                        //objIMG.ToArray(),
                        bytActivo,
                        r[5].ToString());

                    blnResultado = true;
                }
                else
                {
                    List<string> list = SQLConnector.generarListaParaProcedure("@Codigo", "@Descripcion"
                       , "@registroBLOB", "@Activo", "@PathImagen");
                    SQLConnector.executeProcedure("sp_Liga_InsertFiltro", list,                        
                        NuevoCodigoIngresado(),
                        r[2].ToString(),
                        r[3].ToString(),                        
                        bytActivo,
                        r[5].ToString());

                    blnResultado = true;
                }

                RX.InsertarLigasActivas(r[0].ToString());
            }

            return blnResultado;
        }

        public bool ComprobarExisteLiga(string strCodigo)
        {
            bool blnVerifica = false;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * from dbo.Liga WHERE codigo = '" + strCodigo + "'";
            if (SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count > 0)
                blnVerifica = true;
            else
                blnVerifica = false;

            return blnVerifica;
        }

        public bool EliminarLiga(string strID) 
        {
            bool blnVerifica = false;
            string strSQL = "";

            strSQL = "DELETE FROM dbo.Liga WHERE id =  '" + strID + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            blnVerifica = true;

            return blnVerifica;
        }

        public int NuevoCodigoIngresado()
        {
            // Corresponde al campo código, devuelve el último codigo ingresado + 1
            int intValor = 0;

            DataTable dtResultado = CampoCodigoOrdenado();
            if (dtResultado.Rows.Count > 0)
            {
                intValor = int.Parse(dtResultado.Rows[0].ItemArray[0].ToString());
            }

            return intValor + 1;
        }

        public DataTable LigasActivas()
        {       
            string strSQL = "";

            strSQL = "SELECT id, codigo, descripcion from dbo.Liga WHERE activo = 1 ORDER BY descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public string RecuperaCodigoLiga(string IdLiga)
        {
            string strSQL = "";
            string strValor = "";

            strSQL = "SELECT codigo from dbo.Liga WHERE id = '" + IdLiga + "'";

            DataTable dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtResultado.Rows.Count > 0)
            {
                strValor = dtResultado.Rows[0].ItemArray[0].ToString();
            }

            return strValor;            
        }
    }
}
