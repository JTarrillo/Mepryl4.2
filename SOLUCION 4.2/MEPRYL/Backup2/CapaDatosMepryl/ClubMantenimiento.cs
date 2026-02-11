using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class ClubMantenimiento
    {
        public ClubMantenimiento()
        {
            // Constructor
        }

        public DataTable MostrarClubConFiltro(string strFiltro)
        {
            string strSQL = "EXEC sp_Club_MostrarFiltro '" + strFiltro + "'";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable MostrarClubConFiltro(string strFiltro, string strFiltro2)
        {
            string strSQL = "SELECT C.id, C.codigo, C.ligaID, C.codigoliga, C.descripcion as Club, L.imagen as Imagen ,L.descripcion AS Liga, C.activo, C.pathImagen, C.direccion1, C.direccion2, C.contacto, C.telefono, C.mail, C.urlMapa " + 
	                        "FROM dbo.Club C INNER JOIN dbo.Liga L ON C.ligaID = L.id " +
                            "WHERE L.activo = 1 AND C.descripcion LIKE '%" + strFiltro + "%' AND L.descripcion = '" + strFiltro2 + "' " +
	                        "ORDER BY Club ASC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool ActualizarClub(DataTable dtTabla)
        {
            bool blnResultado = false;
            byte bytActivo = 0;
            string strSQL = "";

            foreach (DataRow r in dtTabla.Rows)
            {
                //byte[] valorColumna = (byte[])r[4];
                //objIMG = new System.IO.MemoryStream(valorColumna);
                bool blnActivo = (bool)r[5];

                if (blnActivo == true)
                    bytActivo = 1;
                else
                    bytActivo = 0;

                if (ComprobarExisteClub(r[1].ToString()))
                {
                    strSQL = "UPDATE dbo.Club " +
                             "SET ligaID = '" + r[2].ToString() + "', codigoliga = '" + r[3].ToString() + "', descripcion = '" + r[4].ToString() + "', activo = " + bytActivo + ", pathImagen = '" + r[6].ToString() + "' , direccion1 = '" + r[7].ToString() + "', direccion2 = '" + r[8].ToString() + "', contacto = '" + r[9].ToString() + "', telefono = '" + r[10].ToString() + "', mail = '" + r[11].ToString() + "', urlMapa = '" + r[12].ToString() + "' " +
                             "WHERE id = '" + r[0].ToString() + "'";
                             
                    SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                    blnResultado = true;
                }
                else
                {
                    List<string> list = SQLConnector.generarListaParaProcedure("@Codigo", "@LigaId"
                       , "@CodigoLiga", "@Descripcion", "@Activo", "@PathImagen", "@Direccion1", "@Direccion2"
                       , "@Contacto", "@Telefono", "@mail", "@urlMapa");
                    SQLConnector.executeProcedure("sp_Club_InsertFiltro", list,
                        NuevoCodigoIngresado(),
                        r[2].ToString(),
                        r[3].ToString(),
                        r[4].ToString(),
                        bytActivo,
                        r[6].ToString(),
                        r[7].ToString(),
                        r[8].ToString(),
                        r[9].ToString(),
                        r[10].ToString(),
                        r[11].ToString(),
                        r[12].ToString());

                    blnResultado = true;
                }
            }

            return blnResultado;
        }

        public bool ComprobarExisteClub(string strCodigo)
        {
            bool blnVerifica = false;
            string strSQL = "";

            strSQL = "SELECT TOP 1 * from dbo.Club WHERE codigo = '" + strCodigo + "'";
            if (SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count > 0)
                blnVerifica = true;
            else
                blnVerifica = false;

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
                            "FROM dbo.Club " +
                            "ORDER BY (CASE " +
                            "when isnumeric(codigo) = 1 then cast (codigo as int) " +
                            "END) DESC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool EliminarClub(string strID)
        {
            bool blnVerifica = false;
            string strSQL = "";

            strSQL = "DELETE FROM dbo.Club WHERE id =  '" + strID + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            blnVerifica = true;

            return blnVerifica;
        }

        public DataTable LigaDelClubPorNombre(string strNombreClub)
        {
            string strSQL = "";
            strSQL = "SELECT TOP 1 l.id AS LigaID, l.descripcion AS Liga, c.id AS ClubID  FROM dbo.Club c " +
                     "INNER JOIN dbo.Liga l ON l.id = c.ligaID " +
                     "WHERE c.descripcion = '" + strNombreClub + "'";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public string LigaDelClub(string strNombreClub)
        {
            string strNombreLiga = "";

            if (LigaDelClubPorNombre(strNombreClub).Rows.Count > 0)
            {
                foreach (DataRow drFila in LigaDelClubPorNombre(strNombreClub).Rows)
                {
                    strNombreLiga = drFila["Liga"].ToString();
                }
            }

            return strNombreLiga;
        }
        
    }
}
