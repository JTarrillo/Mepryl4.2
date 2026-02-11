using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public class ReporteEspirometria
    {
        private CapaNegocioMepryl.Reportes reporte;
        string[,] Etiquetas = new string[8, 2];
        CapaNegocioMepryl.ReporteWord CrearReporte;
        CapaNegocioMepryl.ConfigPlantillaReporte confPlantillas;
        
        public ReporteEspirometria()
        {
            reporte = new CapaNegocioMepryl.Reportes();
            CrearReporte = new ReporteWord();
            confPlantillas = new CapaNegocioMepryl.ConfigPlantillaReporte();
        }

        private string PlantillaWord(bool blnOlivera)
        {
            DataTable db = confPlantillas.ListarPlantillas("L");

            string strPath = "";
            if (blnOlivera)
                strPath = @"P:\Temporal\Temp\INFORME ESPIROMETRIA Olivera 01.docx";
            else
                foreach (DataRow fila in db.Rows)
                {
                    strPath  = @fila["Espirometria"].ToString();
                }                    

            return strPath;
        }
        
        private string ArchivoImagen(string strDNI, string strIdentificador, string strFechaExamen)
        {
            DateTime dtFecha = Convert.ToDateTime(strFechaExamen);
            UtilidadesMepryl UtilMepril = new UtilidadesMepryl();
            string strFiltro = "";
            //string strPathImagen = UtilMepril.AbrirDirectorioExportaciones("ESPIROMETRIA", dtFecha, true) + "\\IMAGENES RECORTADAS\\";
            string strPathImagen = UtilMepril.AbrirDirectorioEspiro("ESPIROMETRIA", dtFecha, true) + "\\IMAGENES RECORTADAS\\";            
            //strPathImagen = strPathImagen + strDNI + ".jpg";

            strFiltro = "*" + strIdentificador + "*" + strDNI + "*";

            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strPathImagen);
                foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                {
                    if (System.IO.File.Exists(fi.FullName))
                    {
                        strPathImagen = fi.FullName;
                        return strPathImagen;
                    }                    
                }

                strFiltro = "*" + strDNI + "*";
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(strPathImagen);
                foreach (var fir in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                {
                    if (System.IO.File.Exists(fir.FullName))
                    {
                        strPathImagen = fir.FullName;
                        return strPathImagen;
                    }                    
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
            }
            
            return strPathImagen;                        
        }
        

        public bool CargarEtiquetas(string strDNI, string strIdExamenLaboral, string strFechaExamen, string strIdentificador, string strArchivoSalida, bool blnOlivera)
        {
            CapaNegocioMepryl.Reportes rpt = new CapaNegocioMepryl.Reportes();

            DataTable dt = null;
            object objImagen = ArchivoImagen(strDNI, strIdentificador, strFechaExamen);
            bool blnResultado = false;
            string strArchivo = "";
            
            dt = reporte.ReporteEspirometria(strIdExamenLaboral, strDNI);
            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<NroOrden>>"; Etiquetas[0, 1] = strIdentificador;
                Etiquetas[1, 0] = "<<Paciente>>"; Etiquetas[1, 1] = r.ItemArray[0].ToString();                
                Etiquetas[2, 0] = "<<Talla>>"; Etiquetas[2, 1] = r.ItemArray[1].ToString() + " m.";
                Etiquetas[3, 0] = "<<Peso>>"; Etiquetas[3, 1] = r.ItemArray[2].ToString() + " Kg.";
                Etiquetas[4, 0] = "<<Nacimiento>>"; Etiquetas[4, 1] = Convert.ToDateTime(r.ItemArray[3].ToString()).ToShortDateString();
                Etiquetas[5, 0] = "<<Fecha>>"; Etiquetas[5, 1] = Convert.ToDateTime(strFechaExamen).ToShortDateString();
                Etiquetas[6, 0] = "<<Informe>>"; Etiquetas[6, 1] = r.ItemArray[4].ToString();
                Etiquetas[7, 0] = "<<Dni>>"; Etiquetas[7, 1] = strDNI;                
            }

            if (System.IO.File.Exists(objImagen.ToString()))
            {
                strArchivo = rpt.ReporteSalida("ESPIROMETRIA", false, Convert.ToDateTime(strFechaExamen), strArchivoSalida);
                //CrearReporte.CreateWordDocument(PlantillaWord(blnOlivera), strArchivoSalida, objImagen, Etiquetas, 'P', false);
                CrearReporte.CreateWordDocument(PlantillaWord(blnOlivera), strArchivo, objImagen, Etiquetas, 'P', false);
                blnResultado = true;
            }
            else
            {
                blnResultado = false;
            }

            return blnResultado;
        }
    }
}