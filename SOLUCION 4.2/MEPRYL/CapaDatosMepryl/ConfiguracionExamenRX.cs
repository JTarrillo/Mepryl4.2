using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class ConfiguracionExamenRX
    {
        public ConfiguracionExamenRX()
        {
            // Constructor
        }

        public DataTable MostrarLigasActivas(string strFiltro)
        {
            string strSQL = "SELECT P.id, P.codigo, descripcion, imagen, pathimagen, categoriainicial, novenaCategoria, UltimoPeriodoDesde, ultimoPeriodoHasta, VerificaRX, VerificaClub, AdmiteMenores, IdLiga " +
                            "FROM dbo.Liga L INNER JOIN dbo.ParametrosPlacas P ON L.id = P.IdLiga " + 
                            "WHERE activo = 1 AND descripcion LIKE '%" + strFiltro + "%' " +
                            "ORDER BY descripcion ASC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool InsertarLigasActivas(string IdLiga)
        {
            bool blnResultado = false;

            if (!(ComprobarExisteLiga(IdLiga)))
            {
                List<string> list = SQLConnector.generarListaParaProcedure("@Codigo", "@IdLiga");
                SQLConnector.executeProcedure("sp_ParametrosPlacas_Insert", list,
                    NuevoCodigoIngresado(),
                    IdLiga);

                blnResultado = true;
            }

            return blnResultado;
        }

        public bool ComprobarExisteLiga(string strCodigo)
        {
            bool blnVerifica = false;
            string strSQL = "";

            if (!string.IsNullOrEmpty(strCodigo))
            {
                strSQL = "SELECT TOP 1 * from dbo.ParametrosPlacas WHERE IdLiga = '" + strCodigo + "'";

                if (SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count > 0)
                    blnVerifica = true;
                else
                    blnVerifica = false;
            }

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

        public DataTable CampoCodigoOrdenado()
        {
            string strSQL = "SELECT codigo " +
                            "FROM dbo.ParametrosPlacas " +
                            "ORDER BY (CASE " +
                            "when isnumeric(codigo) = 1 then cast (codigo as int) " +
                            "END) DESC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool ActualizarExamenRX(DataTable dtTabla)
        { 
            bool blnVerifica = false;
            byte bytVerificaRX = 0;
            byte bytVerificaClub = 0;
            byte bytAdminteMenores = 0;            
            string strSQL = "";

            foreach (DataRow r in dtTabla.Rows)
            {
                bool blnVerificaRX = (bool)r[5];
                bool blnVerificaClub = (bool)r[6];
                bool blnAdminteMenores = (bool)r[7];
                DateTime dtFechaPeriodoDesde = (DateTime)r[3];
                DateTime dtFechaUltimoHasta = (DateTime)r[4];

                if (blnVerificaRX == true)
                    bytVerificaRX = 1;
                else
                    bytVerificaRX = 0;
                if (blnVerificaClub == true)
                    bytVerificaClub = 1;
                else
                    bytVerificaClub = 0;
                if (blnAdminteMenores == true)
                    bytAdminteMenores = 1;
                else
                    bytAdminteMenores = 0;
                                
                strSQL = "UPDATE dbo.ParametrosPlacas " +
                         "SET categoriaInicial = '" + r[1].ToString() + "', novenaCategoria = '" + r[2].ToString() + "', " +
                         "ultimoPeriodoDesde = convert(date,'" + dtFechaPeriodoDesde.ToShortDateString() + "',105), ultimoPeriodoHasta = convert(date,'" + dtFechaUltimoHasta.ToShortDateString() + "',105), " +
                         "VerificaRX = " + bytVerificaRX + ", VerificaClub = " + bytVerificaClub + ", AdmiteMenores = " + bytAdminteMenores + " " + ", LigasIDs = '" + r[8].ToString() + "' " +
                         "WHERE id = '" + r[0].ToString() + "'";

                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                blnVerifica = true;
            }

            return blnVerifica;
        }
    }
}
