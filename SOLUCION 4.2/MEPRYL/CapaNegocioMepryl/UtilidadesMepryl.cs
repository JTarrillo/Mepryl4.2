using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using CapaDatosMepryl;
using System.Drawing.Imaging;

namespace CapaNegocioMepryl
{
    public class UtilidadesMepryl
    {
        private CapaDatosMepryl.UtilidadesMepryl UtilMepryl;
        private string strEstado = "";

        public UtilidadesMepryl()
        {
            UtilMepryl = new CapaDatosMepryl.UtilidadesMepryl();
        }

        public string PathFotoLaboral()
        {
            return UtilMepryl.PathFotoLaboral();
        }

        public string PathFotoPreventiva()
        {
            return UtilMepryl.PathFotoPreventiva();
        }

        public string PathExportarReportes(byte intTipoReporte)
        {
            return UtilMepryl.PathExportarReportes(intTipoReporte);
        }

        public string CreaDirectorioPorFecha(DateTime Fecha, byte TipoReporte, string DirectorioContenedor)
        {
            return UtilMepryl.CreaDirectorioPorFecha(Fecha, TipoReporte, DirectorioContenedor);
        }

        public DataTable DatosArchivoExcel(string RutaExcel)
        {
            return UtilMepryl.DatosArchivoExcel(RutaExcel);
        }

        public string CrearDirectorioPorFecha(DateTime Fecha, string strDirectorioBase)
        {
            return UtilMepryl.CrearDirectorioPorFecha(Fecha, strDirectorioBase);
        }

        public bool ConcatenarArchivosGuardaPDF()
        {
            bool blnConsolidado = false;

            return blnConsolidado;
        }

        public DataTable EjecutarSQL(string strSQL)
        {
            return UtilMepryl.EjecutarSQL(strSQL);
        }

        public string ConcatenarPDFs(DataTable ListaArchivos, string DirectorioBase)
        {
            strEstado = "";
            DataTable dtLA = ListaArchivos;
            List<string> Lista01 = new List<string>();
            List<string> Lista02 = new List<string>();

            if (dtLA.Rows.Count > 0)
            {
                foreach (DataRow r in dtLA.Rows)
                {
                    Lista01.Add(r.ItemArray[6].ToString());
                    Lista01.Add(r.ItemArray[7].ToString());
                    Lista01.Add(r.ItemArray[8].ToString());
                    Lista01.Add(r.ItemArray[9].ToString());

                    Lista02.Add(r.ItemArray[0].ToString());
                    Lista02.Add(r.ItemArray[1].ToString());
                    Lista02.Add(r.ItemArray[2].ToString());
                    Lista02.Add(r.ItemArray[3].ToString());
                    Lista02.Add(r.ItemArray[4].ToString());
                    Lista02.Add(r.ItemArray[5].ToString());

                    ProcesoConcatenar(PathArchivoConsolidado(Lista02, DirectorioBase), Lista01);
                    Lista01.Clear();
                    Lista02.Clear();
                }
            }

            return strEstado;
        }

        public string ConcatenarPDFsLaboral(DataTable ListaArchivos, string DirectorioBase, List<string> ArchivosPdf)
        {
            strEstado = "";
            DataTable dtLA = ListaArchivos;
            //List<string> Lista01 = new List<string>();
            List<string> Lista02 = new List<string>();

            if (dtLA.Rows.Count > 0)
            {
                foreach (DataRow r in dtLA.Rows)
                {
                    //Lista01.Add(r.ItemArray[6].ToString());
                    //Lista01.Add(r.ItemArray[7].ToString());
                    //Lista01.Add(r.ItemArray[8].ToString());
                    //Lista01.Add(r.ItemArray[9].ToString());
                    //Lista01.Add(r.ItemArray[10].ToString());
                    //Lista01.Add(r.ItemArray[11].ToString());
                    //Lista01.Add(r.ItemArray[12].ToString());

                    Lista02.Add(r.ItemArray[0].ToString());
                    Lista02.Add(r.ItemArray[1].ToString());
                    Lista02.Add(r.ItemArray[2].ToString());
                    Lista02.Add(r.ItemArray[3].ToString());
                    Lista02.Add(r.ItemArray[4].ToString());
                    Lista02.Add(r.ItemArray[5].ToString());

                    //ProcesoConcatenar(PathArchivoConsolidado(Lista02, DirectorioBase), Lista01);
                    ProcesoConcatenar(PathArchivoConsolidado(Lista02, DirectorioBase), ArchivosPdf);
                    //Lista01.Clear();
                    Lista02.Clear();
                }
            }

            return strEstado;
        }

        public void ProcesoConcatenar(string PathSalida, List<string> Lista)
        {
            string strArchivoRevisado = "";
            try
            {
                iTextSharp.text.Document dcDOC = new iTextSharp.text.Document();
                PdfReader rdPdf;
                //PdfReader rdImg;
                int intNroPg = 0;
                string strImagen = "";

                if (File.Exists(PathSalida))
                    File.Delete(PathSalida);

                if (!ListaVacia(Lista))
                {
                    FileStream fsArchivo = new FileStream(PathSalida, FileMode.Create, FileAccess.Write, FileShare.None);
                    PdfCopy pcPdf = new PdfCopy(dcDOC, fsArchivo);
                
                    CrearImagenPDF(ref Lista);
                
                    dcDOC.Open();

                    foreach (string file in Lista)
                    {
                        if (!string.IsNullOrEmpty(file))
                        {
                            if (Path.GetExtension(file).ToUpper() != ".JPG")
                            {
                                strArchivoRevisado = file;
                                rdPdf = new PdfReader(file);                                

                                intNroPg = rdPdf.NumberOfPages;
                                int intPagina = 0;

                                while (intPagina < intNroPg)
                                {
                                    intPagina += 1;
                                    pcPdf.AddPage(pcPdf.GetImportedPage(rdPdf, intPagina));
                                }

                                pcPdf.FreeReader(rdPdf);
                                rdPdf.Close();
                            }
                            else
                            {
                                strImagen = file;
                            }
                        }
                    }

                    pcPdf.Flush();
                    dcDOC.Close();
                }
                //IncluirImagen(PathSalida, strImagen);
                Lista.Clear();
            }
            catch (System.IO.IOException ex)
            {
                strEstado = "No se creó el consolidado: " + PathSalida + "\n\n" + ex.Message.ToString() + "\n** Error en Archivo: " + strArchivoRevisado;
            }
            catch (System.ArgumentException ex)
            {
                strEstado = "No se creó el consolidado: " + PathSalida + "\n\n** ¡DNI o Nombre de paciente contienen caracteres especiales!\n" + ex.Message.ToString() + "\n** Error en Archivo: " + strArchivoRevisado;
            }
        }

        private void CrearImagenPDF(ref List<string> Lista)
        {
            List<string> Lista01 = new List<string>();
            Lista01.Clear();
            int intCont = 0;
            
            try
            {
                foreach (string file in Lista)
                {

                    if (!string.IsNullOrEmpty(file))
                    {
                        if (Path.GetExtension(file).ToUpper() == ".JPG")
                        {
                            string strPdfTemp = Path.GetTempPath() + Path.GetFileName(file.ToLower());
                            string strNomPDF = Path.GetFileName(file).ToLower();
                            string strExtIMG = Path.GetExtension(strNomPDF).ToLower();

                            strPdfTemp = strPdfTemp.Replace(strExtIMG, ".pdf");
                            IncluirImagen(strPdfTemp, file);
                            //Lista[intCont] = strPdfTemp;
                            Lista01.Add(strPdfTemp);
                        }
                        else
                        {
                            Lista01.Add(Lista[intCont]);
                        }                        
                    }
                    
                    intCont++;
                }

                Lista = Lista01;
                
            }
            catch (System.InvalidOperationException ex)
            {
                //
            }

            //Lista = Lista01;
        }

        private void IncluirImagen(string PathSalida, string Imagen)
        {
            // http://desarrolladores.me/2014/06/itextsharp-como-insertar-imagenes/

            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            string strPdfTemp = "";

            System.Drawing.Bitmap imgTamano = new System.Drawing.Bitmap(Imagen);
            Single fltAncho = Convert.ToSingle((imgTamano.Width * 30) / 100);
            Single fltAlto = Convert.ToSingle((imgTamano.Height * 30) / 100);

            // Proceso de comprimir imagenes
            strPdfTemp = Path.GetTempPath() + Path.GetFileName(Imagen.ToLower());
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            imgTamano.Save(strPdfTemp, myImageCodecInfo, myEncoderParameters);
            //

            Rectangle pageSize = new Rectangle(fltAncho, fltAlto); // Tamaño Personalizado
            iTextSharp.text.Document dcDocumento = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
            Image ImgImagen;
            PdfWriter.GetInstance(dcDocumento, new FileStream(PathSalida, FileMode.Create, FileAccess.Write));
            
            dcDocumento.Open();

            //if (!string.IsNullOrEmpty(Imagen))
            if (!string.IsNullOrEmpty(strPdfTemp))
            {
                //ImgImagen = Image.GetInstance(Imagen);
                ImgImagen = Image.GetInstance(strPdfTemp);
                ImgImagen.BorderWidth = 0;
                //ImgImagen.Alignment = Element.ALIGN_JUSTIFIED_ALL;                
                ImgImagen.Alignment = Element.ALIGN_JUSTIFIED_ALL;
                float fltPorcentaje = 0.0f;
                fltPorcentaje = 800 / ImgImagen.Width;
                //ImgImagen.ScaleAbsoluteWidth(1042);
                //ImgImagen.ScaleAbsoluteHeight(1142);

                //ImgImagen.ScaleAbsoluteWidth((ImgImagen.Width * 40) / 100);
                //ImgImagen.ScaleAbsoluteHeight((ImgImagen.Height * 40) / 100);
                ImgImagen.ScaleAbsoluteWidth((ImgImagen.Width * 30) / 100);
                ImgImagen.ScaleAbsoluteHeight((ImgImagen.Height * 30) / 100);
                ImgImagen.CompressionLevel = PdfStream.BEST_COMPRESSION;

                dcDocumento.Add(ImgImagen);
            }

            dcDocumento.Close();
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public string PathArchivoConsolidado(List<string> Lista, string DirConsolidado)
        {
            string strPath = "";

            try
            {
                if (!System.IO.Directory.Exists(DirConsolidado))
                {
                    System.IO.Directory.CreateDirectory(DirConsolidado);
                }

                strPath = DirConsolidado + "\\" + Lista[3].ToString() + " - " + Lista[4].ToString() + " - " + Lista[0].ToString() + Lista[1].ToString() + Lista[2].ToString() + " - " + Lista[5].ToString() + ".pdf";

                Lista.Clear();
            }catch(System.ArgumentException ex)
            {
                strPath = Path.GetTempPath() + "\\" + Lista[3].ToString() + " - " + Lista[4].ToString() + " - " + Lista[0].ToString() + Lista[1].ToString() + Lista[2].ToString() + " - " + Lista[5].ToString() + ".pdf";
            }
                
            return strPath;
        }

        public string NroDia(DateTime Fecha)
        {
            string strDia = "";

            strDia = Fecha.Day.ToString();

            if (Fecha.Day <= 9)
                strDia = "0" + Fecha.Day;

            return strDia;
        }

        public string NroMes(DateTime Fecha)
        {
            string strMes = "";

            strMes = Fecha.Month.ToString();

            if (Fecha.Month <= 9)
                strMes = "0" + Fecha.Month;

            return strMes;
        }

        public string NombreMes(int NroMes)
        {
            return UtilMepryl.MonthName(NroMes);
        }

        private bool ListaVacia(List<string> Lista)
        {
            bool blnEstado = true;

            foreach (string file in Lista)
            {
                if (!string.IsNullOrEmpty(file))
                    return false;
            }

            return blnEstado;
        }

        public static bool esEmail(string inputEmail)
        {
            if (string.IsNullOrEmpty(inputEmail))
                inputEmail = null;

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";            
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
            
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public string LeerArchivoTexto(string Ruta)
        {
            string strContenido = "";
            string strLinea = "";

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Ruta);
                while ((strLinea = file.ReadLine()) != null)
                {
                    strContenido = strContenido + strLinea;
                }
                file.Close();
            }
            catch (System.IO.IOException ex)
            {
                //
            }

            return strContenido;
        }

        public string AbrirDirectorioExportaciones(string strNombreExamen, DateTime dtFecha, bool blnLaboral)
        {               
            string strMes = "";
            string strAnio = "";
            string strDirecConsolTemp = "";
            string strNombreMes = "";            
            byte intTipoReporte= 1;

            if (blnLaboral == true)
                intTipoReporte = 3;
                        
            strMes = NroMes(dtFecha).ToUpper();
            strNombreMes = NombreMes(Int32.Parse(strMes)).ToUpper();
            strAnio = Convert.ToString(dtFecha.Year).ToUpper();
            
            strDirecConsolTemp = PathExportarReportes(intTipoReporte) + "\\" + (strNombreExamen + " " + strAnio) + "\\" + strMes + "-" + strNombreMes;

            return strDirecConsolTemp;
        }

        public string AbrirDirectorioExportacionesAnio(string strNombreExamen, DateTime dtFecha, bool blnLaboral)
        {
            string strMes = "";
            string strAnio = "";
            string strDirecConsolTemp = "";
            string strNombreMes = "";
            byte intTipoReporte = 1;

            if (blnLaboral == true)
                intTipoReporte = 3;

            strMes = NroMes(dtFecha).ToUpper();
            strNombreMes = NombreMes(Int32.Parse(strMes)).ToUpper();
            strAnio = Convert.ToString(dtFecha.Year).ToUpper();

            strDirecConsolTemp = PathExportarReportes(intTipoReporte) + "\\" + strAnio + "\\" + (strNombreExamen + " " + strAnio) + "\\" + strMes + "-" + strNombreMes;

            return strDirecConsolTemp;
        }

        public string AbrirDirectorioEspiro(string strNombreExamen, DateTime dtFecha, bool blnLaboral)
        {
            ConfigConsolidacion directorio = new ConfigConsolidacion();                      

            string strMes = "";
            string strAnio = "";
            string strDirecConsolTemp = "";
            string strNombreMes = "";
            byte intTipoReporte = 1;
            DataTable db = directorio.DirectoriosConsLaboral();

            foreach (DataRow fila in db.Rows)
            {

                strDirecConsolTemp = fila["infEspirometria"].ToString();
            }

            if (blnLaboral == true)
                intTipoReporte = 3;

            strMes = NroMes(dtFecha).ToUpper();
            strNombreMes = NombreMes(Int32.Parse(strMes)).ToUpper();
            strAnio = Convert.ToString(dtFecha.Year).ToUpper();

            strDirecConsolTemp = strDirecConsolTemp + "\\" + strAnio + "\\" + strMes + "-" + strNombreMes;

            return strDirecConsolTemp;
        }

        public string SoloNumeros(string strTexto)
        {
            return "";
        }
    }
}
