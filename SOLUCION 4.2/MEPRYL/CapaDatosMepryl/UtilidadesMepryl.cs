using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Comunes;

namespace CapaDatosMepryl
{
    public class UtilidadesMepryl
    {
        public UtilidadesMepryl()
        {

        }

        public string PathFotoLaboral()
        {
            string strPATH = "S:\\FOTOS\\";
            string strSQL = "";

            strSQL = "SELECT TOP 1 UbicacionLaboral FROM dbo.UbicacionFotos";

            DataTable dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtResultado.Rows.Count > 0)
            {
                strPATH = dtResultado.Rows[0].ItemArray[0].ToString() + "\\";
            }

            return strPATH;
        }

        public string PathFotoPreventiva()
        {
            string strPATH = "S:\\FOTOS PREVENTIVA\\";
            string strSQL = "";

            strSQL = "SELECT TOP 1 UbicacionPreventiva FROM dbo.UbicacionFotos";

            DataTable dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtResultado.Rows.Count > 0)
            {
                strPATH = dtResultado.Rows[0].ItemArray[0].ToString() + "\\";
            }

            return strPATH;
        }

        public string PathExportarReportes(byte intTipoReporte)
        {            
            string strPATH = "P:\\Temporal\\";
            string strSQL = "";

            strSQL = "SELECT TOP 1 exportar AS 'ExportarReporte' FROM dbo.ConfigReportes WHERE tipoReporte = '" + intTipoReporte + "'";
            DataTable dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtResultado.Rows.Count > 0)
            {
                strPATH = dtResultado.Rows[0].ItemArray[0].ToString() + "\\";
            }

            return strPATH;
        }

        public string CreaDirectorioPorFecha(DateTime Fecha, byte TipoReporte, string DirectorioContenedor)
        {
            return DirectorioReportePorFecha(Fecha, TipoReporte, DirectorioContenedor);
        }

        private string DirectorioReportePorFecha(DateTime Fecha, byte TipoReporte, string leyenda)
        {
            string strDirectorio = "";
            string strDirectorioBase = "";
            string strDia = "";

            if (!string.IsNullOrEmpty(leyenda))
                leyenda = leyenda + " ";

            strDia = Fecha.Day.ToString();

            if (Fecha.Day <= 9)
                strDia = "0" + Fecha.Day;

            strDirectorioBase = PathExportarReportes(TipoReporte);

            if (Fecha.Month <= 9)
                strDirectorio = strDirectorioBase + leyenda + Fecha.Year.ToString() + "\\0" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";
            else
                strDirectorio = strDirectorioBase + leyenda + Fecha.Year.ToString() + "\\" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";

            if (!System.IO.Directory.Exists(strDirectorio))
            {
                System.IO.Directory.CreateDirectory(strDirectorio);
            }

            return strDirectorio;
        }

        public string CrearDirectorioPorFecha(DateTime Fecha, string strDirectorioBase)
        {
            string strDirectorio = "";            
            string strDia = "";
                       

            strDia = Fecha.Day.ToString();

            if (Fecha.Day <= 9)
                strDia = "0" + Fecha.Day;            

            if (Fecha.Month <= 9)
                strDirectorio = strDirectorioBase + "\\" + Fecha.Year.ToString() + "\\0" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";
            else
                strDirectorio = strDirectorioBase + "\\" + Fecha.Year.ToString() + "\\" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";

            if (!System.IO.Directory.Exists(strDirectorio))
            {
                System.IO.Directory.CreateDirectory(strDirectorio);
            }

            return strDirectorio;
        }

        public string MonthName(int month)
        {
            System.Globalization.DateTimeFormatInfo dtinfo = new System.Globalization.CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        private OleDbConnectionStringBuilder ConectarArchivoExcel(string RutaExcel)
        {
            //Creamos la cadena de conexión con el fichero excel
            OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
            cb.DataSource = RutaExcel;

            if (Path.GetExtension(RutaExcel).ToUpper() == ".XLS")
            {
                cb.Provider = "Microsoft.Jet.OLEDB.4.0";
                cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;Allow Formula=false;");
            }
            else if (Path.GetExtension(RutaExcel).ToUpper() == ".XLSX")
            {
                cb.Provider = "Microsoft.ACE.OLEDB.12.0";
                cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;Allow Formula=false;");
            }

            return cb;
        }

        public DataTable DatosArchivoExcel(string RutaExcel)
        {
            DataTable dt = new DataTable("Datos");

            using (OleDbConnection conn = new OleDbConnection(ConectarArchivoExcel(RutaExcel).ConnectionString))
            {
                //Abrimos la conexión
                conn.Open();

                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [Hoja1$]";

                    //Guardamos los datos en el DataTable
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                }

                //Cerramos la conexión
                conn.Close();
            }

            return dt;
        }

        public DataTable EjecutarSQL(string strSQL)
        {
            DataTable dt = null;

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }
    }
}
