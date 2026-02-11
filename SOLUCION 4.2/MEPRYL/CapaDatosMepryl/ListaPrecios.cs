using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class ListaPrecios
    {
        public ListaPrecios()
        {
            // Constructor
        }

        public int InsertarNombreListaPrecios(string NombreLista)
        {
            string strSQL = "";
            int intRetorno = 0;
            DataTable dt = null;
            strSQL = "INSERT INTO dbo.NombreListaPrecios (NombreLista) VALUES ('" + NombreLista + "')";
            
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            strSQL = "SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                intRetorno = int.Parse(dt.Rows[0][0].ToString());
            }

            return intRetorno;
        }

        public void InsertarListaPreciosBase(int IdNombreLista, DataTable dtDatos)
        {
            string strSQL = "";

            if(dtDatos.Rows.Count > 0)
            {
                for(int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    strSQL = "INSERT INTO dbo.ListaPreciosBase (idNombreLista, TipoPrestacion, Codigo, Descripcion, Costo, Factura, Eliminado) " +
                            "VALUES(" +
                            IdNombreLista + ", " +                            
                            "'" + dtDatos.Rows[i][0].ToString() + "', " +
                            "'" + dtDatos.Rows[i][1].ToString() + "', " +
                            "'" + dtDatos.Rows[i][2].ToString() + "', " +
                            "'" + dtDatos.Rows[i][3].ToString() + "', " +
                            "'" + dtDatos.Rows[i][4].ToString() + "', " +
                            "'0')";

                    SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                }
            }
        }

        public void DeleteListaPreciosBase(int IdLista)
        {
            string strSQL = "";
            strSQL = "UPDATE dbo.ListaPreciosBase SET Eliminado = 1 WHERE idNombreLista = " + IdLista;
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public void DeleteNombreListaPrecios(int IdNombreLista)
        {
            string strSQL = "";
            strSQL = "DELETE FROM dbo.NombreListaPrecios WHERE id = " + IdNombreLista;
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListarNombreListaPrecios()
        {
            string strSQL = "";

            strSQL = "SELECT * from dbo.NombreListaPrecios  ORDER BY NombreLista";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ObtenerListaPreciosDeEmpresa(string idEmpresa)
        {
            string strSQL = "";

            strSQL = "SELECT n.* FROM [MEPRYLv2.1].[dbo].[Empresa] e left join [MEPRYLv2.1].dbo.NombreListaPrecios n on e.listaPrecios = n.id where e.id = '" + idEmpresa + "' ORDER BY NombreLista";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListarNombreListaPrecios(string strFiltro)
        {
            string strSQL = "";

            strSQL = "SELECT * from dbo.NombreListaPrecios  WHERE NombreLista LIKE '%" + strFiltro + "%'";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListarListaPreciosBase()
        {
            string strSQL = "";

            strSQL = "SELECT * from dbo.ListaPreciosBase";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListarListaPreciosBase(int intIdNombreLista)
        {
            string strSQL = "";
            strSQL = "SELECT id, idNombreLista, NombrePrestacion, TipoPrestacion, Codigo, Descripcion, Costo, Factura from [MEPRYLv2.1].dbo.ListaPreciosBase WHERE Eliminado = '0' AND idNombreLista = " + intIdNombreLista;

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ObtenerElementoParaAgregar(int codigo)
        {
            string strSQL = "";

            strSQL = "SELECT id, idNombreLista, NombrePrestacion, TipoPrestacion, Codigo, Descripcion, Costo, Factura from [MEPRYLv2.1].dbo.ListaPreciosBase WHERE id = " + codigo ;

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool VerificaNombreListaPrecios(string strNombreLista)
        {
            string strSQL = "";
            DataTable dt = null;
            bool blnResultado = false;

            strSQL = "SELECT NombreLista FROM dbo.NombreListaPrecios WHERE NombreLista LIKE '%" + strNombreLista + "%'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if(dt.Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }
    }
}
