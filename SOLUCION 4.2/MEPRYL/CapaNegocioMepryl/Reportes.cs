using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{    
    public class Reportes
    {
        string test;
        private CapaDatosMepryl.Reportes reporte;
        CapaNegocioMepryl.ReporteWord CrearReporte;
        CapaNegocioMepryl.ReporteWordSpire ReporteSpire;

        public Reportes()
        {
            reporte = new CapaDatosMepryl.Reportes();
            CrearReporte = new CapaNegocioMepryl.ReporteWord();
            ReporteSpire = new CapaNegocioMepryl.ReporteWordSpire();
        }

        public DataTable ReporteEspirometria(string strIdExamenLaboral, string strDNI)
        {
            return reporte.ReporteEspirometria(strIdExamenLaboral, strDNI);
        }

        private string PlantillaWord(string strNombrePlantilla, bool blnPreventiva)
        {
            ConfigPlantillaReporte preventiva = new ConfigPlantillaReporte();
            DataTable dt = preventiva.ListarPlantillas("P");
            DataTable db = preventiva.ListarPlantillas("L");
            string strPath = "";

            if (dt.Rows.Count > 0 && blnPreventiva)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    switch (strNombrePlantilla)
                    {
                        case "CLINICO-PREVENTIVA":
                            strPath = @fila["Clinico"].ToString();
                            break;
                        case "LABORATORIO-PREVENTIVA":
                            strPath = @fila["Laboratorio"].ToString();
                            break;                        
                        default:
                            break;
                        case "HOJA-RUTA":
                            strPath = @"P:\Temporal\PLANTILLA REPORTE INFORMES\PRUEBA\HojaRuta.docx";
                            break;
                        case "HOJA-CLINICO":
                            strPath = @"P:\Temporal\PLANTILLA REPORTE INFORMES\PRUEBA\HojaClinico.docx";
                            break;                            
                    }
                }
            }
            else if(db.Rows.Count > 0 && !blnPreventiva)
            {
                foreach (DataRow fila in db.Rows)
                {
                    switch (strNombrePlantilla)
                    {
                        case "CLINICO-LABORAL":
                            strPath = @fila["Clinico"].ToString();
                            break;
                        case "LABORATORIO-LABORAL":
                            strPath = @fila["Laboratorio"].ToString();
                            break;
                        case "OLIVERA-LABORAL":
                            strPath = @fila["Olivera"].ToString();
                            break;
                        default:
                            break;
                    }
                }
            }

            return strPath;
        }

        public string ReporteSalida(string strNombrePlantilla, bool blnPreventiva, DateTime dtFecha, string strNombreReporte)
        {
            string strResultado = "";
                                    
            ConfigConsolidacion directorio = new ConfigConsolidacion();
            DataTable dt = directorio.DirectoriosConsPreventiva();
            DataTable db = directorio.DirectoriosConsLaboral();
          //  string strPath = "";
            
            if (dt.Rows.Count > 0 && blnPreventiva)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    switch (strNombrePlantilla)
                    {
                        case "CLINICO-PREVENTIVA":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["InfClinico"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        case "LABORATORIO-PREVENTIVA":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["InfLaboratorio"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        case "AUDIOMETRIA":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["infAudiometria"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (db.Rows.Count > 0 && !blnPreventiva)
            {
                foreach (DataRow fila in db.Rows)
                {
                    switch (strNombrePlantilla)
                    {
                        case "CLINICO-LABORAL":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["InfClinico"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        case "LABORATORIO-LABORAL":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["InfLaboratorio"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        case "OLIVERA-LABORAL":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["InfOlivera"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        case "ESPIROMETRIA":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["infEspirometria"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        case "AUDIOMETRIA":
                            strResultado = DirectorioReportePorFecha(dtFecha, @fila["infAudiometria"].ToString(), "");
                            strResultado = strResultado + strNombreReporte;
                            break;
                        default:
                            break;
                    }
                }
            }

            return strResultado;
        }

        public bool ClinicoPreventiva(DataTable dt, string strNombreArchivo, DateTime dtFecha)
        {               
            bool blnResultado = false;
            string[,] Etiquetas = new string[48, 2];
            object objImagen = null;

            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<Fecha>>"; Etiquetas[0, 1] = r.ItemArray[0].ToString();
                Etiquetas[1, 0] = "<<N>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                Etiquetas[2, 0] = "<<Dni>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                Etiquetas[3, 0] = "<<FechaNac>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                Etiquetas[4, 0] = "<<ApellidoNombre>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();
                Etiquetas[5, 0] = "<<Categoria>>"; Etiquetas[5, 1] = r.ItemArray[5].ToString();
                Etiquetas[6, 0] = "<<Liga1>>"; Etiquetas[6, 1] = r.ItemArray[6].ToString();
                Etiquetas[7, 0] = "<<Club1>>"; Etiquetas[7, 1] = r.ItemArray[7].ToString();
                Etiquetas[8, 0] = "<<Liga2>>"; Etiquetas[8, 1] = r.ItemArray[8].ToString();
                Etiquetas[9, 0] = "<<Club2>>"; Etiquetas[9, 1] = r.ItemArray[9].ToString();
                Etiquetas[10, 0] = "<<AntClinico>>"; Etiquetas[10, 1] = r.ItemArray[10].ToString();
                Etiquetas[11, 0] = "<<AntQuirurgico>>"; Etiquetas[11, 1] = r.ItemArray[11].ToString();
                Etiquetas[12, 0] = "<<AntTraumatico>>"; Etiquetas[12, 1] = r.ItemArray[12].ToString();
                Etiquetas[13, 0] = "<<Talla>>"; Etiquetas[13, 1] = r.ItemArray[13].ToString();
                Etiquetas[14, 0] = "<<Peso>>"; Etiquetas[14, 1] = r.ItemArray[14].ToString();
                Etiquetas[15, 0] = "<<Biotipo>>"; Etiquetas[15, 1] = r.ItemArray[15].ToString();
                Etiquetas[16, 0] = "<<EntraAire>>"; Etiquetas[16, 1] = r.ItemArray[16].ToString();
                Etiquetas[17, 0] = "<<RuidoAgregado>>"; Etiquetas[17, 1] = r.ItemArray[17].ToString();
                Etiquetas[18, 0] = "<<RuidoCardio>>"; Etiquetas[18, 1] = r.ItemArray[18].ToString();
                Etiquetas[19, 0] = "<<Silencios>>"; Etiquetas[19, 1] = r.ItemArray[19].ToString();
                Etiquetas[20, 0] = "<<Tma>>"; Etiquetas[20, 1] = r.ItemArray[20].ToString();
                Etiquetas[21, 0] = "<<Tmi>>"; Etiquetas[21, 1] = r.ItemArray[21].ToString();
                Etiquetas[22, 0] = "<<Pulso>>"; Etiquetas[22, 1] = r.ItemArray[22].ToString();
                Etiquetas[23, 0] = "<<Abdomen>>"; Etiquetas[23, 1] = r.ItemArray[23].ToString();
                Etiquetas[24, 0] = "<<Hernias>>"; Etiquetas[24, 1] = r.ItemArray[24].ToString();
                Etiquetas[25, 0] = "<<Varices>>"; Etiquetas[25, 1] = r.ItemArray[25].ToString();
                Etiquetas[26, 0] = "<<ApG>>"; Etiquetas[26, 1] = r.ItemArray[26].ToString();
                Etiquetas[27, 0] = "<<PielFaneras>>"; Etiquetas[27, 1] = r.ItemArray[27].ToString();
                Etiquetas[28, 0] = "<<ApL>>"; Etiquetas[28, 1] = r.ItemArray[28].ToString();
                Etiquetas[29, 0] = "<<Snc>>"; Etiquetas[29, 1] = r.ItemArray[29].ToString();
                Etiquetas[30, 0] = "<<OjoD>>"; Etiquetas[30, 1] = r.ItemArray[30].ToString();
                Etiquetas[31, 0] = "<<OjoDL>>"; Etiquetas[31, 1] = r.ItemArray[31].ToString();
                Etiquetas[32, 0] = "<<OjoI>>"; Etiquetas[32, 1] = r.ItemArray[32].ToString();
                Etiquetas[33, 0] = "<<OjoIL>>"; Etiquetas[33, 1] = r.ItemArray[33].ToString();
                Etiquetas[34, 0] = "<<VisionC>>"; Etiquetas[34, 1] = r.ItemArray[34].ToString();
                Etiquetas[35, 0] = "<<ExOdonto>>"; Etiquetas[35, 1] = r.ItemArray[35].ToString();                
                Etiquetas[36, 0] = "<<DLaboratorio>>"; Etiquetas[36, 1] = r.ItemArray[36].ToString();
                Etiquetas[37, 0] = "<<Ecg>>"; Etiquetas[37, 1] = r.ItemArray[37].ToString();
                Etiquetas[38, 0] = "<<RxTorax>>"; Etiquetas[38, 1] = r.ItemArray[38].ToString();
                Etiquetas[39, 0] = "<<RxColumna>>"; Etiquetas[39, 1] = r.ItemArray[39].ToString();
                Etiquetas[40, 0] = "<<RxOtras>>"; Etiquetas[40, 1] = r.ItemArray[40].ToString();
                Etiquetas[41, 0] = "<<DFinal>>"; Etiquetas[41, 1] = r.ItemArray[41].ToString();
                Etiquetas[42, 0] = "<<DClinico>>"; Etiquetas[42, 1] = r.ItemArray[42].ToString();
                Etiquetas[43, 0] = "<<ObsClinico>>"; Etiquetas[43, 1] = r.ItemArray[43].ToString();
                Etiquetas[44, 0] = "<<ObsLaboratorio>>"; Etiquetas[44, 1] = r.ItemArray[44].ToString();
                Etiquetas[45, 0] = "<<ObsRX>>"; Etiquetas[45, 1] = r.ItemArray[45].ToString();
                Etiquetas[46, 0] = "<<ObsCardiologia>>"; Etiquetas[46, 1] = r.ItemArray[46].ToString();
                Etiquetas[47, 0] = "<<RM>>"; Etiquetas[47, 1] = r.ItemArray[47].ToString();
            }

            CrearReporte.CreateWordDocument(PlantillaWord("CLINICO-PREVENTIVA", true), ReporteSalida("CLINICO-PREVENTIVA", true, dtFecha ,strNombreArchivo), objImagen, Etiquetas, 'P', false);
            blnResultado = true;
            
            return blnResultado;
        }

        public bool LaboratorioPreventiva(DataTable dt, string strNombreArchivo, DateTime dtFecha)
        {
            bool blnResultado = false;
            string[,] Etiquetas = new string[34, 2];
            object objImagen = null;

            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<Fecha>>"; Etiquetas[0, 1] = r.ItemArray[0].ToString();
                Etiquetas[1, 0] = "<<Nro>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                Etiquetas[2, 0] = "<<Dni>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                Etiquetas[3, 0] = "<<FechaNac>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                Etiquetas[4, 0] = "<<ApellidoNombre>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();
                Etiquetas[5, 0] = "<<Gr>>"; Etiquetas[5, 1] = r.ItemArray[5].ToString();
                Etiquetas[6, 0] = "<<Gb>>"; Etiquetas[6, 1] = r.ItemArray[6].ToString();
                Etiquetas[7, 0] = "<<Hg>>"; Etiquetas[7, 1] = r.ItemArray[7].ToString();
                Etiquetas[8, 0] = "<<Hc>>"; Etiquetas[8, 1] = r.ItemArray[8].ToString();
                Etiquetas[9, 0] = "<<Et>>"; Etiquetas[9, 1] = r.ItemArray[9].ToString();
                Etiquetas[10, 0] = "<<Ca>>"; Etiquetas[10, 1] = r.ItemArray[10].ToString();
                Etiquetas[11, 0] = "<<Se>>"; Etiquetas[11, 1] = r.ItemArray[11].ToString();
                Etiquetas[12, 0] = "<<Es>>"; Etiquetas[12, 1] = r.ItemArray[12].ToString();
                Etiquetas[13, 0] = "<<Ba>>"; Etiquetas[13, 1] = r.ItemArray[13].ToString();
                Etiquetas[14, 0] = "<<Li>>"; Etiquetas[14, 1] = r.ItemArray[14].ToString();
                Etiquetas[15, 0] = "<<Mo>>"; Etiquetas[15, 1] = r.ItemArray[15].ToString();
                Etiquetas[16, 0] = "<<Glu>>"; Etiquetas[16, 1] = r.ItemArray[16].ToString();
                Etiquetas[17, 0] = "<<Ure>>"; Etiquetas[17, 1] = r.ItemArray[17].ToString();
                Etiquetas[18, 0] = "<<Cha>>"; Etiquetas[18, 1] = r.ItemArray[18].ToString();
                Etiquetas[19, 0] = "<<Vdrl>>"; Etiquetas[19, 1] = r.ItemArray[19].ToString();
                Etiquetas[20, 0] = "<<Col>>"; Etiquetas[20, 1] = r.ItemArray[20].ToString();
                Etiquetas[21, 0] = "<<Asp>>"; Etiquetas[21, 1] = r.ItemArray[21].ToString();
                Etiquetas[22, 0] = "<<Den>>"; Etiquetas[22, 1] = r.ItemArray[22].ToString();
                Etiquetas[23, 0] = "<<Ph>>"; Etiquetas[23, 1] = r.ItemArray[23].ToString();
                Etiquetas[24, 0] = "<<Glucosa>>"; Etiquetas[24, 1] = r.ItemArray[24].ToString();
                Etiquetas[25, 0] = "<<Pro>>"; Etiquetas[25, 1] = r.ItemArray[25].ToString();
                Etiquetas[26, 0] = "<<Hemo>>"; Etiquetas[26, 1] = r.ItemArray[26].ToString();
                Etiquetas[27, 0] = "<<Bili>>"; Etiquetas[27, 1] = r.ItemArray[27].ToString();
                Etiquetas[28, 0] = "<<Celu>>"; Etiquetas[28, 1] = r.ItemArray[28].ToString();
                Etiquetas[29, 0] = "<<Leu>>"; Etiquetas[29, 1] = r.ItemArray[29].ToString();
                Etiquetas[30, 0] = "<<Hema>>"; Etiquetas[30, 1] = r.ItemArray[30].ToString();
                Etiquetas[31, 0] = "<<Pio>>"; Etiquetas[31, 1] = r.ItemArray[31].ToString();
                Etiquetas[32, 0] = "<<Mucus>>"; Etiquetas[32, 1] = r.ItemArray[32].ToString();
                Etiquetas[33, 0] = "<<Observaciones>>"; Etiquetas[33, 1] = r.ItemArray[33].ToString();                
            }

            CrearReporte.CreateWordDocument(PlantillaWord("LABORATORIO-PREVENTIVA", true), ReporteSalida("LABORATORIO-PREVENTIVA", true, dtFecha, strNombreArchivo), objImagen, Etiquetas, 'P', false);
            blnResultado = true;            

            return blnResultado;
        }

        private string DirectorioReportePorFecha(DateTime Fecha, string strDirectorioBase, string leyenda)
        {
            string strDirectorio = "";            
            string strDia = "";

            if (!string.IsNullOrEmpty(leyenda))
                leyenda = leyenda + " ";
            else
                leyenda = "";

            strDia = Fecha.Day.ToString();

            if (Fecha.Day <= 9)
                strDia = "0" + Fecha.Day;
                        

            if (Fecha.Month <= 9)
                strDirectorio = strDirectorioBase + "\\" + leyenda + Fecha.Year.ToString() + "\\0" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";
                //strDirectorio = strDirectorioBase + "\\" + leyenda + "\\0" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";
            else
                strDirectorio = strDirectorioBase + "\\" + leyenda + Fecha.Year.ToString() + "\\" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";
                //strDirectorio = strDirectorioBase + "\\" + leyenda + "\\" + Fecha.Month.ToString() + "-" + MonthName(Fecha.Month).ToUpper() + "\\" + strDia + "\\";

            if (!System.IO.Directory.Exists(strDirectorio))
            {
                System.IO.Directory.CreateDirectory(strDirectorio);
            }

            return strDirectorio;
        }

        private string MonthName(int month)
        {
            System.Globalization.DateTimeFormatInfo dtinfo = new System.Globalization.CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public bool ClinicoLaboral(DataTable dt, string strNombreArchivo, DateTime dtFecha)
        {
            bool blnResultado = false;
            string[,] Etiquetas = new string[49, 2];
            object objImagen = null;

            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<TipoExamen>>"; Etiquetas[0, 1] = r.ItemArray[0].ToString();                
                Etiquetas[1, 0] = "<<Fecha>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                Etiquetas[2, 0] = "<<Nro>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                Etiquetas[3, 0] = "<<RazonSocial>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                Etiquetas[4, 0] = "<<Dni>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();
                Etiquetas[5, 0] = "<<FechaNac>>"; Etiquetas[5, 1] = r.ItemArray[5].ToString();
                Etiquetas[6, 0] = "<<ApellidoNombre>>"; Etiquetas[6, 1] = r.ItemArray[6].ToString();
                Etiquetas[7, 0] = "<<Nacionalidad>>"; Etiquetas[7, 1] = r.ItemArray[7].ToString();
                Etiquetas[8, 0] = "<<Direccion>>"; Etiquetas[8, 1] = r.ItemArray[8].ToString();
                Etiquetas[9, 0] = "<<Localidad>>"; Etiquetas[9, 1] = r.ItemArray[9].ToString();
                Etiquetas[10, 0] = "<<Telefono>>"; Etiquetas[10, 1] = r.ItemArray[10].ToString();
                Etiquetas[11, 0] = "<<Tarea>>"; Etiquetas[11, 1] = r.ItemArray[11].ToString();
                Etiquetas[12, 0] = "<<AntCli>>"; Etiquetas[12, 1] = r.ItemArray[12].ToString();
                Etiquetas[13, 0] = "<<AntQui>>"; Etiquetas[13, 1] = r.ItemArray[13].ToString();
                Etiquetas[14, 0] = "<<AntTra>>"; Etiquetas[14, 1] = r.ItemArray[14].ToString();
                Etiquetas[15, 0] = "<<Talla>>"; Etiquetas[15, 1] = r.ItemArray[15].ToString();
                Etiquetas[16, 0] = "<<Peso>>"; Etiquetas[16, 1] = r.ItemArray[16].ToString();
                Etiquetas[17, 0] = "<<Imc>>"; Etiquetas[17, 1] = r.ItemArray[17].ToString();
                Etiquetas[18, 0] = "<<EntraAire>>"; Etiquetas[18, 1] = r.ItemArray[18].ToString();
                Etiquetas[19, 0] = "<<RuidoAgregado>>"; Etiquetas[19, 1] = r.ItemArray[19].ToString();
                Etiquetas[20, 0] = "<<Ruidos>>"; Etiquetas[20, 1] = r.ItemArray[20].ToString();
                Etiquetas[21, 0] = "<<Silencios>>"; Etiquetas[21, 1] = r.ItemArray[21].ToString();
                Etiquetas[22, 0] = "<<TMax>>"; Etiquetas[22, 1] = r.ItemArray[22].ToString();
                Etiquetas[23, 0] = "<<TMin>>"; Etiquetas[23, 1] = r.ItemArray[23].ToString();
                Etiquetas[24, 0] = "<<Pulso>>"; Etiquetas[24, 1] = r.ItemArray[24].ToString();
                Etiquetas[25, 0] = "<<Abdomen>>"; Etiquetas[25, 1] = r.ItemArray[25].ToString();
                Etiquetas[26, 0] = "<<Hernias>>"; Etiquetas[26, 1] = r.ItemArray[26].ToString();
                Etiquetas[27, 0] = "<<Varices>>"; Etiquetas[27, 1] = r.ItemArray[27].ToString();
                Etiquetas[28, 0] = "<<ApG>>"; Etiquetas[28, 1] = r.ItemArray[28].ToString();
                Etiquetas[29, 0] = "<<Piel>>"; Etiquetas[29, 1] = r.ItemArray[29].ToString();
                Etiquetas[30, 0] = "<<ApL>>"; Etiquetas[30, 1] = r.ItemArray[30].ToString();
                Etiquetas[31, 0] = "<<Snc>>"; Etiquetas[31, 1] = r.ItemArray[31].ToString();
                Etiquetas[32, 0] = "<<OjoD>>"; Etiquetas[32, 1] = r.ItemArray[32].ToString();
                Etiquetas[33, 0] = "<<OjoDC>>"; Etiquetas[33, 1] = r.ItemArray[33].ToString();
                Etiquetas[34, 0] = "<<OjoI>>"; Etiquetas[34, 1] = r.ItemArray[34].ToString();
                Etiquetas[35, 0] = "<<OjoIDC>>"; Etiquetas[35, 1] = r.ItemArray[35].ToString();
                Etiquetas[36, 0] = "<<VisionC>>"; Etiquetas[36, 1] = r.ItemArray[36].ToString();
                Etiquetas[37, 0] = "<<ExO>>"; Etiquetas[37, 1] = r.ItemArray[37].ToString();
                Etiquetas[38, 0] = "<<ObsV>>"; Etiquetas[38, 1] = r.ItemArray[41].ToString();
                Etiquetas[39, 0] = "<<Medico>>"; Etiquetas[39, 1] = r.ItemArray[40].ToString();
                Etiquetas[40, 0] = "<<DicCli>>"; Etiquetas[40, 1] = r.ItemArray[43].ToString();
                Etiquetas[41, 0] = "<<Laboratorio>>"; Etiquetas[41, 1] = r.ItemArray[45].ToString();
                Etiquetas[42, 0] = "<<Ecg>>"; Etiquetas[42, 1] = r.ItemArray[47].ToString();
                Etiquetas[43, 0] = "<<RxToraxF>>"; Etiquetas[43, 1] = r.ItemArray[49].ToString();
                Etiquetas[44, 0] = "<<Ergometria>>"; Etiquetas[44, 1] = r.ItemArray[51].ToString();
                Etiquetas[45, 0] = "<<Ecocardiograma>>"; Etiquetas[45, 1] = r.ItemArray[53].ToString();
                Etiquetas[46, 0] = "<<Espirometria>>"; Etiquetas[46, 1] = r.ItemArray[55].ToString();
                Etiquetas[47, 0] = "<<DictamenFinal>>"; Etiquetas[47, 1] = r.ItemArray[72].ToString();
                Etiquetas[48, 0] = "<<ObsFinal>>"; Etiquetas[48, 1] = r.ItemArray[73].ToString();

                objImagen = RecuperarFoto(r.ItemArray[4].ToString(), 'L');
            }            
            
            ReporteSpire.CreateWordDocument(PlantillaWord("CLINICO-LABORAL", false), ReporteSalida("CLINICO-LABORAL", false, dtFecha, strNombreArchivo), objImagen, Etiquetas, true, "");

            blnResultado = true;

            return blnResultado;
        }

        public bool OliveraLaboral(DataTable dt, string strNombreArchivo, DateTime dtFecha)
        {
            bool blnResultado = false;
            string[,] Etiquetas = new string[49, 2];
            object objImagen = null;

            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<TipoExamen>>"; Etiquetas[0, 1] = r.ItemArray[0].ToString();
                Etiquetas[1, 0] = "<<Fecha>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                Etiquetas[2, 0] = "<<Nro>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                Etiquetas[3, 0] = "<<RazonSocial>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                Etiquetas[4, 0] = "<<Dni>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();
                Etiquetas[5, 0] = "<<FechaNac>>"; Etiquetas[5, 1] = r.ItemArray[5].ToString();
                Etiquetas[6, 0] = "<<ApellidoNombre>>"; Etiquetas[6, 1] = r.ItemArray[6].ToString();
                Etiquetas[7, 0] = "<<Nacionalidad>>"; Etiquetas[7, 1] = r.ItemArray[7].ToString();
                Etiquetas[8, 0] = "<<Direccion>>"; Etiquetas[8, 1] = r.ItemArray[8].ToString();
                Etiquetas[9, 0] = "<<Localidad>>"; Etiquetas[9, 1] = r.ItemArray[9].ToString();
                Etiquetas[10, 0] = "<<Telefono>>"; Etiquetas[10, 1] = r.ItemArray[10].ToString();
                Etiquetas[11, 0] = "<<Tarea>>"; Etiquetas[11, 1] = r.ItemArray[11].ToString();
                Etiquetas[12, 0] = "<<AntCli>>"; Etiquetas[12, 1] = r.ItemArray[12].ToString();
                Etiquetas[13, 0] = "<<AntQui>>"; Etiquetas[13, 1] = r.ItemArray[13].ToString();
                Etiquetas[14, 0] = "<<AntTra>>"; Etiquetas[14, 1] = r.ItemArray[14].ToString();
                Etiquetas[15, 0] = "<<Talla>>"; Etiquetas[15, 1] = r.ItemArray[15].ToString();
                Etiquetas[16, 0] = "<<Peso>>"; Etiquetas[16, 1] = r.ItemArray[16].ToString();
                Etiquetas[17, 0] = "<<Imc>>"; Etiquetas[17, 1] = r.ItemArray[17].ToString();
                Etiquetas[18, 0] = "<<EntraAire>>"; Etiquetas[18, 1] = r.ItemArray[18].ToString();
                Etiquetas[19, 0] = "<<RuidoAgregado>>"; Etiquetas[19, 1] = r.ItemArray[19].ToString();
                Etiquetas[20, 0] = "<<Ruidos>>"; Etiquetas[20, 1] = r.ItemArray[20].ToString();
                Etiquetas[21, 0] = "<<Silencios>>"; Etiquetas[21, 1] = r.ItemArray[21].ToString();
                Etiquetas[22, 0] = "<<TMax>>"; Etiquetas[22, 1] = r.ItemArray[22].ToString();
                Etiquetas[23, 0] = "<<TMin>>"; Etiquetas[23, 1] = r.ItemArray[23].ToString();
                Etiquetas[24, 0] = "<<Pulso>>"; Etiquetas[24, 1] = r.ItemArray[24].ToString();
                Etiquetas[25, 0] = "<<Abdomen>>"; Etiquetas[25, 1] = r.ItemArray[25].ToString();
                Etiquetas[26, 0] = "<<Hernias>>"; Etiquetas[26, 1] = r.ItemArray[26].ToString();
                Etiquetas[27, 0] = "<<Varices>>"; Etiquetas[27, 1] = r.ItemArray[27].ToString();
                Etiquetas[28, 0] = "<<ApG>>"; Etiquetas[28, 1] = r.ItemArray[28].ToString();
                Etiquetas[29, 0] = "<<Piel>>"; Etiquetas[29, 1] = r.ItemArray[29].ToString();
                Etiquetas[30, 0] = "<<ApL>>"; Etiquetas[30, 1] = r.ItemArray[30].ToString();
                Etiquetas[31, 0] = "<<Snc>>"; Etiquetas[31, 1] = r.ItemArray[31].ToString();
                Etiquetas[32, 0] = "<<OjoD>>"; Etiquetas[32, 1] = r.ItemArray[32].ToString();
                Etiquetas[33, 0] = "<<OjoDC>>"; Etiquetas[33, 1] = r.ItemArray[33].ToString();
                Etiquetas[34, 0] = "<<OjoI>>"; Etiquetas[34, 1] = r.ItemArray[34].ToString();
                Etiquetas[35, 0] = "<<OjoIDC>>"; Etiquetas[35, 1] = r.ItemArray[35].ToString();
                Etiquetas[36, 0] = "<<VisionC>>"; Etiquetas[36, 1] = r.ItemArray[36].ToString();
                Etiquetas[37, 0] = "<<ExO>>"; Etiquetas[37, 1] = r.ItemArray[37].ToString();
                Etiquetas[38, 0] = "<<ObsV>>"; Etiquetas[38, 1] = r.ItemArray[41].ToString();
                Etiquetas[39, 0] = "<<Medico>>"; Etiquetas[39, 1] = r.ItemArray[40].ToString();
                Etiquetas[40, 0] = "<<DicCli>>"; Etiquetas[40, 1] = r.ItemArray[43].ToString();
                Etiquetas[41, 0] = "<<Laboratorio>>"; Etiquetas[41, 1] = r.ItemArray[45].ToString();
                Etiquetas[42, 0] = "<<Ecg>>"; Etiquetas[42, 1] = r.ItemArray[47].ToString();
                Etiquetas[43, 0] = "<<RxToraxF>>"; Etiquetas[43, 1] = r.ItemArray[49].ToString();
                Etiquetas[44, 0] = "<<Ergometria>>"; Etiquetas[44, 1] = r.ItemArray[51].ToString();
                Etiquetas[45, 0] = "<<Ecocardiograma>>"; Etiquetas[45, 1] = r.ItemArray[53].ToString();
                Etiquetas[46, 0] = "<<Espirometria>>"; Etiquetas[46, 1] = r.ItemArray[55].ToString();
                Etiquetas[47, 0] = "<<DictamenFinal>>"; Etiquetas[47, 1] = r.ItemArray[72].ToString();
                Etiquetas[48, 0] = "<<ObsFinal>>"; Etiquetas[48, 1] = r.ItemArray[73].ToString();

                objImagen = RecuperarFoto(r.ItemArray[4].ToString(), 'L');
            }


            
            ReporteSpire.CreateWordDocument(PlantillaWord("OLIVERA-LABORAL", false), ReporteSalida("OLIVERA-LABORAL", false, dtFecha, strNombreArchivo), objImagen, Etiquetas, true, "");

            blnResultado = true;

            return blnResultado;
        }

        public bool LaboratorioLaboral(DataTable dt, string strNombreArchivo, DateTime dtFecha, string strTipoLaboratorio, bool blnImprimir)
        {
            bool blnResultado = false;
            string[,] Etiquetas = new string[63, 2];
            object objImagen = "";
            bool blnPerfilLipidico = false;

            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<Fecha>>"; Etiquetas[0, 1] = Convert.ToDateTime(r.ItemArray[0].ToString()).ToShortDateString();
                Etiquetas[1, 0] = "<<Nro>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                Etiquetas[2, 0] = "<<RazonSocial>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                Etiquetas[3, 0] = "<<DNI>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                Etiquetas[4, 0] = "<<FechaNac>>"; Etiquetas[4, 1] = Convert.ToDateTime(r.ItemArray[4].ToString()).ToShortDateString();
                Etiquetas[5, 0] = "<<ApellidoNombre>>"; Etiquetas[5, 1] = r.ItemArray[5].ToString();
                Etiquetas[6, 0] = "<<Grojos>>"; Etiquetas[6, 1] = r.ItemArray[8].ToString();
                Etiquetas[7, 0] = "<<GBlanc>>"; Etiquetas[7, 1] = r.ItemArray[9].ToString();
                Etiquetas[8, 0] = "<<Hemog>>"; Etiquetas[8, 1] = r.ItemArray[10].ToString();
                Etiquetas[9, 0] = "<<Hemat>>"; Etiquetas[9, 1] = r.ItemArray[11].ToString();
                Etiquetas[10, 0] = "<<Eritro>>"; Etiquetas[10, 1] = r.ItemArray[12].ToString();
                Etiquetas[11, 0] = "<<Plaque>>"; Etiquetas[11, 1] = r.ItemArray[13].ToString();
                Etiquetas[12, 0] = "<<ObsSRoja>>"; Etiquetas[12, 1] = r.ItemArray[14].ToString();
                Etiquetas[13, 0] = "<<Cayao>>"; Etiquetas[13, 1] = r.ItemArray[15].ToString();
                Etiquetas[14, 0] = "<<NSeg>>"; Etiquetas[14, 1] = r.ItemArray[16].ToString();
                Etiquetas[15, 0] = "<<Eosi>>"; Etiquetas[15, 1] = r.ItemArray[17].ToString();
                Etiquetas[16, 0] = "<<Basof>>"; Etiquetas[16, 1] = r.ItemArray[18].ToString();
                Etiquetas[17, 0] = "<<Linfoc>>"; Etiquetas[17, 1] = r.ItemArray[19].ToString();
                Etiquetas[18, 0] = "<<Monoc>>"; Etiquetas[18, 1] = r.ItemArray[20].ToString();
                Etiquetas[19, 0] = "<<ObsSBlanc>>"; Etiquetas[19, 1] = r.ItemArray[21].ToString();
                Etiquetas[20, 0] = "<<Gluce>>"; Etiquetas[20, 1] = r.ItemArray[22].ToString();
                Etiquetas[21, 0] = "<<Urem>>"; Etiquetas[21, 1] = r.ItemArray[23].ToString();
                Etiquetas[22, 0] = "<<Chaga>>"; Etiquetas[22, 1] = r.ItemArray[24].ToString();
                Etiquetas[23, 0] = "<<VDRL>>"; Etiquetas[23, 1] = r.ItemArray[25].ToString();
                Etiquetas[24, 0] = "<<Grupo>>"; Etiquetas[24, 1] = r.ItemArray[26].ToString();
                Etiquetas[25, 0] = "<<Fac>>"; Etiquetas[25, 1] = r.ItemArray[27].ToString();
                Etiquetas[26, 0] = "<<Uricemia>>"; Etiquetas[26, 1] = r.ItemArray[28].ToString();
                Etiquetas[27, 0] = "<<TE>>"; Etiquetas[27, 1] = r.ItemArray[29].ToString();
                Etiquetas[28, 0] = "<<OtrosHema>>"; Etiquetas[28, 1] = r.ItemArray[30].ToString();
                Etiquetas[29, 0] = "<<ColT>>"; Etiquetas[29, 1] = r.ItemArray[31].ToString();
                Etiquetas[30, 0] = "<<Hdl>>"; Etiquetas[30, 1] = r.ItemArray[32].ToString();
                Etiquetas[31, 0] = "<<Ldl>>"; Etiquetas[31, 1] = r.ItemArray[33].ToString();
                Etiquetas[32, 0] = "<<Trig>>"; Etiquetas[32, 1] = r.ItemArray[34].ToString();
                Etiquetas[33, 0] = "<<OtrosLip>>"; Etiquetas[33, 1] = r.ItemArray[35].ToString();
                Etiquetas[34, 0] = "<<Color>>"; Etiquetas[34, 1] = r.ItemArray[36].ToString();
                Etiquetas[35, 0] = "<<Aspecto>>"; Etiquetas[35, 1] = r.ItemArray[37].ToString();
                Etiquetas[36, 0] = "<<Células>>"; Etiquetas[36, 1] = r.ItemArray[38].ToString();
                Etiquetas[37, 0] = "<<Leucocitos>>"; Etiquetas[37, 1] = r.ItemArray[39].ToString();
                Etiquetas[38, 0] = "<<Hematíes>>"; Etiquetas[38, 1] = r.ItemArray[40].ToString();
                Etiquetas[39, 0] = "<<Glucosa>>"; Etiquetas[39, 1] = r.ItemArray[41].ToString();
                Etiquetas[40, 0] = "<<HemogOrina>>"; Etiquetas[40, 1] = r.ItemArray[42].ToString();
                Etiquetas[41, 0] = "<<Proteinas>>"; Etiquetas[41, 1] = r.ItemArray[43].ToString();
                Etiquetas[42, 0] = "<<Cetonas>>"; Etiquetas[42, 1] = r.ItemArray[44].ToString();
                Etiquetas[43, 0] = "<<Bilirrubina>>"; Etiquetas[43, 1] = r.ItemArray[45].ToString();
                Etiquetas[44, 0] = "<<OtrosOrina>>"; Etiquetas[44, 1] = r.ItemArray[46].ToString();
                Etiquetas[45, 0] = "<<DictamenLab>>"; Etiquetas[45, 1] = r.ItemArray[47].ToString();
                Etiquetas[46, 0] = "<<Densidad>>"; Etiquetas[46, 1] = r.ItemArray[48].ToString();
                Etiquetas[47, 0] = "<<Ph>>"; Etiquetas[47, 1] = r.ItemArray[49].ToString();
                Etiquetas[48, 0] = "<<Profesional>>"; Etiquetas[48, 1] = r.ItemArray[51].ToString();
                Etiquetas[49, 0] = "<<Matricula>>"; Etiquetas[49, 1] = r.ItemArray[52].ToString();                
                Etiquetas[50, 0] = "<<Cargo>>"; Etiquetas[50, 1] = r.ItemArray[53].ToString();
                Etiquetas[51, 0] = "<<ObservacionesLab>>"; Etiquetas[51, 1] = r.ItemArray[55].ToString();
                Etiquetas[52, 0] = "<<Na>>"; Etiquetas[52, 1] = r.ItemArray[56].ToString();
                Etiquetas[53, 0] = "<<K>>"; Etiquetas[53, 1] = r.ItemArray[57].ToString();
                Etiquetas[54, 0] = "<<ProT>>"; Etiquetas[54, 1] = r.ItemArray[58].ToString();
                Etiquetas[55, 0] = "<<Album>>"; Etiquetas[55, 1] = r.ItemArray[59].ToString();
                Etiquetas[56, 0] = "<<Alfa1>>"; Etiquetas[56, 1] = r.ItemArray[60].ToString();
                Etiquetas[57, 0] = "<<Alfa2>>"; Etiquetas[57, 1] = r.ItemArray[61].ToString();
                Etiquetas[58, 0] = "<<Beta1>>"; Etiquetas[58, 1] = r.ItemArray[62].ToString();
                Etiquetas[59, 0] = "<<Beta2>>"; Etiquetas[59, 1] = r.ItemArray[63].ToString();
                Etiquetas[60, 0] = "<<Gamma>>"; Etiquetas[60, 1] = r.ItemArray[64].ToString();
                Etiquetas[61, 0] = "<<RelAG>>"; Etiquetas[61, 1] = r.ItemArray[65].ToString();
                Etiquetas[62, 0] = "<<Creati>>"; Etiquetas[62, 1] = r.ItemArray[66].ToString();

                if (!string.IsNullOrEmpty(r.ItemArray[31].ToString()) && !string.IsNullOrEmpty(r.ItemArray[32].ToString()) && !string.IsNullOrEmpty(r.ItemArray[31].ToString()))
                  blnPerfilLipidico = true;


            }

            if (strTipoLaboratorio == "NORMAL")
                CrearReporte.CreateWordDocument(@"P:\Temporal\Temp\Laboratorio Casino.docx", ReporteSalida("LABORATORIO-LABORAL", false, dtFecha, strNombreArchivo), objImagen, Etiquetas, 'L', blnImprimir);
            if (strTipoLaboratorio == "CASINO")
                CrearReporte.CreateWordDocument(@"P:\Temporal\Temp\Laboratorio Normal.docx", ReporteSalida("LABORATORIO-LABORAL", false, dtFecha, strNombreArchivo), objImagen, Etiquetas, 'L', blnImprimir);
            if (strTipoLaboratorio == "ARBITRO")
                CrearReporte.CreateWordDocument(PlantillaWord("LABORATORIO-LABORAL", false), ReporteSalida("LABORATORIO-LABORAL", false, dtFecha, strNombreArchivo), objImagen, Etiquetas, 'L', blnImprimir);
            if (strTipoLaboratorio == "LIBRETA")
                CrearReporte.CreateWordDocument(@"P:\Temporal\Temp\Laboratorio Libreta.docx", ReporteSalida("LABORATORIO-LABORAL", false, dtFecha, strNombreArchivo), objImagen, Etiquetas, 'L', blnImprimir);

            blnResultado = true;

            return blnResultado;
        }

        public bool HojaDeRuta(DataTable dt)
        {
            bool blnResultado = false;
            string[,] Etiquetas = new string[47, 2];
            object objImagen = "";            

            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<Na>>"; Etiquetas[0, 1] = r.ItemArray[0].ToString();
                Etiquetas[1, 0] = "<<Nro>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                Etiquetas[2, 0] = "<<TipoExamen>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                Etiquetas[3, 0] = "<<FecEx>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                Etiquetas[4, 0] = "<<Liga1>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();
                Etiquetas[5, 0] = "<<Club1>>"; Etiquetas[5, 1] = r.ItemArray[5].ToString();
                Etiquetas[6, 0] = "<<Liga2>>"; Etiquetas[6, 1] = r.ItemArray[6].ToString();
                Etiquetas[7, 0] = "<<Club2>>"; Etiquetas[7, 1] = r.ItemArray[7].ToString();
                Etiquetas[8, 0] = "<<Liga3>>"; Etiquetas[8, 1] = r.ItemArray[8].ToString();
                Etiquetas[9, 0] = "<<Club3>>"; Etiquetas[9, 1] = r.ItemArray[9].ToString();
                Etiquetas[10, 0] = "<<Liga4>>"; Etiquetas[10, 1] = r.ItemArray[10].ToString();
                Etiquetas[11, 0] = "<<Club4>>"; Etiquetas[11, 1] = r.ItemArray[11].ToString();
                Etiquetas[12, 0] = "<<NombreApellido>>"; Etiquetas[12, 1] = r.ItemArray[12].ToString();
                Etiquetas[13, 0] = "<<Nac>>"; Etiquetas[13, 1] = r.ItemArray[13].ToString();
                Etiquetas[14, 0] = "<<Dni>>"; Etiquetas[14, 1] = r.ItemArray[14].ToString();
                Etiquetas[15, 0] = "<<Tarea>>"; Etiquetas[15, 1] = r.ItemArray[15].ToString();
                Etiquetas[16, 0] = "<<Telefono>>"; Etiquetas[16, 1] = r.ItemArray[16].ToString();
                Etiquetas[17, 0] = "<<ítem1>>"; Etiquetas[17, 1] = r.ItemArray[17].ToString();
                Etiquetas[18, 0] = "<<ítem2>>"; Etiquetas[18, 1] = r.ItemArray[18].ToString();
                Etiquetas[19, 0] = "<<ítem3>>"; Etiquetas[19, 1] = r.ItemArray[19].ToString();
                Etiquetas[20, 0] = "<<ítem4>>"; Etiquetas[20, 1] = r.ItemArray[20].ToString();
                Etiquetas[21, 0] = "<<ítem5>>"; Etiquetas[21, 1] = r.ItemArray[21].ToString();
                Etiquetas[22, 0] = "<<ítem6>>"; Etiquetas[22, 1] = r.ItemArray[22].ToString();
                Etiquetas[23, 0] = "<<ítem7>>"; Etiquetas[23, 1] = r.ItemArray[23].ToString();
                Etiquetas[24, 0] = "<<ítem8>>"; Etiquetas[24, 1] = r.ItemArray[24].ToString();
                Etiquetas[25, 0] = "<<ítem9>>"; Etiquetas[25, 1] = r.ItemArray[25].ToString();
                Etiquetas[26, 0] = "<<ítem10>>"; Etiquetas[26, 1] = r.ItemArray[26].ToString();
                Etiquetas[27, 0] = "<<ítem11>>"; Etiquetas[27, 1] = r.ItemArray[27].ToString();
                Etiquetas[28, 0] = "<<ítem12>>"; Etiquetas[28, 1] = r.ItemArray[28].ToString();
                Etiquetas[29, 0] = "<<ítem13>>"; Etiquetas[29, 1] = r.ItemArray[29].ToString();
                Etiquetas[30, 0] = "<<ítem14>>"; Etiquetas[30, 1] = r.ItemArray[30].ToString();
                Etiquetas[31, 0] = "<<ítem15>>"; Etiquetas[31, 1] = r.ItemArray[31].ToString();
                Etiquetas[32, 0] = "<<ítem16>>"; Etiquetas[32, 1] = r.ItemArray[32].ToString();
                Etiquetas[33, 0] = "<<ítem17>>"; Etiquetas[33, 1] = r.ItemArray[33].ToString();
                Etiquetas[34, 0] = "<<ítem18>>"; Etiquetas[34, 1] = r.ItemArray[34].ToString();
                Etiquetas[35, 0] = "<<ítem19>>"; Etiquetas[35, 1] = r.ItemArray[35].ToString();
                Etiquetas[36, 0] = "<<ítem20>>"; Etiquetas[36, 1] = r.ItemArray[36].ToString();
                Etiquetas[37, 0] = "<<ítem21>>"; Etiquetas[37, 1] = r.ItemArray[37].ToString();
                Etiquetas[38, 0] = "<<Estudios>>"; Etiquetas[38, 1] = r.ItemArray[38].ToString();
                Etiquetas[39, 0] = "<<ítem22>>"; Etiquetas[39, 1] = r.ItemArray[39].ToString();
                Etiquetas[40, 0] = "<<ítem23>>"; Etiquetas[40, 1] = r.ItemArray[40].ToString();
                Etiquetas[41, 0] = "<<ítem24>>"; Etiquetas[41, 1] = r.ItemArray[41].ToString();
                Etiquetas[42, 0] = "<<ítem25>>"; Etiquetas[42, 1] = r.ItemArray[42].ToString();
                Etiquetas[43, 0] = "<<ítem26>>"; Etiquetas[43, 1] = r.ItemArray[43].ToString();
                Etiquetas[44, 0] = "<<ítem27>>"; Etiquetas[44, 1] = r.ItemArray[44].ToString();
                Etiquetas[45, 0] = "<<ítem28>>"; Etiquetas[45, 1] = r.ItemArray[45].ToString();
                Etiquetas[46, 0] = "<<Mail>>"; Etiquetas[46, 1] = r.ItemArray[46].ToString();
            }

            //CrearReporte.PrintWordDocument(PlantillaWord("HOJA-RUTA", true), objImagen, Etiquetas);
            ReporteSpire.PrintWordDocument(PlantillaWord("HOJA-RUTA", true), objImagen, Etiquetas);
            blnResultado = true;

            return blnResultado;
        }

        public bool HojaDeClinico(DataTable dt)
        {
            bool blnResultado = false;
            string[,] Etiquetas = new string[19, 2];
            object objImagen = "";

            foreach (DataRow r in dt.Rows)
            {
                Etiquetas[0, 0] = "<<Na>>"; Etiquetas[0, 1] = r.ItemArray[0].ToString();
                Etiquetas[1, 0] = "<<Nro>>"; Etiquetas[1, 1] = r.ItemArray[1].ToString();
                Etiquetas[2, 0] = "<<TipoExamen>>"; Etiquetas[2, 1] = r.ItemArray[2].ToString();
                Etiquetas[3, 0] = "<<FecEx>>"; Etiquetas[3, 1] = r.ItemArray[3].ToString();
                Etiquetas[4, 0] = "<<Liga1>>"; Etiquetas[4, 1] = r.ItemArray[4].ToString();
                Etiquetas[5, 0] = "<<Club1>>"; Etiquetas[5, 1] = r.ItemArray[5].ToString();
                Etiquetas[6, 0] = "<<Liga2>>"; Etiquetas[6, 1] = r.ItemArray[6].ToString();
                Etiquetas[7, 0] = "<<Club2>>"; Etiquetas[7, 1] = r.ItemArray[7].ToString();
                Etiquetas[8, 0] = "<<Liga3>>"; Etiquetas[8, 1] = r.ItemArray[8].ToString();
                Etiquetas[9, 0] = "<<Club3>>"; Etiquetas[9, 1] = r.ItemArray[9].ToString();
                Etiquetas[10, 0] = "<<Liga4>>"; Etiquetas[10, 1] = r.ItemArray[10].ToString();
                Etiquetas[11, 0] = "<<Club4>>"; Etiquetas[11, 1] = r.ItemArray[11].ToString();
                Etiquetas[12, 0] = "<<NombreApellido>>"; Etiquetas[12, 1] = r.ItemArray[12].ToString();
                Etiquetas[13, 0] = "<<Nac>>"; Etiquetas[13, 1] = r.ItemArray[13].ToString();
                Etiquetas[14, 0] = "<<Dni>>"; Etiquetas[14, 1] = r.ItemArray[14].ToString();
                Etiquetas[15, 0] = "<<Tarea>>"; Etiquetas[15, 1] = r.ItemArray[15].ToString();
                Etiquetas[16, 0] = "<<Telefono>>"; Etiquetas[16, 1] = r.ItemArray[16].ToString();
                Etiquetas[17, 0] = "<<Mail>>"; Etiquetas[17, 1] = r.ItemArray[17].ToString();
                Etiquetas[18, 0] = "<<Rm>>"; Etiquetas[18, 1] = r.ItemArray[18].ToString();
            }

            ReporteSpire.PrintWordDocument(PlantillaWord("HOJA-CLINICO", true), objImagen, Etiquetas);
            blnResultado = true;

            return blnResultado;
        }

        public string RecuperarFoto(string strDni, char chrTipoPaciente)
        {
            string strResultado = "";
            UbicacionFotos fotos = new UbicacionFotos();
            DataTable dt = null;

            dt = fotos.RecuperarDirectorioFotos();

            if (dt.Rows.Count > 0 && chrTipoPaciente == 'P')
            {
                foreach (DataRow fila in dt.Rows)
                {
                    strResultado = @fila["UbicacionPreventiva"].ToString();
                }
            }else if (dt.Rows.Count > 0 && chrTipoPaciente == 'L')
            {
                foreach (DataRow fila in dt.Rows)
                {
                    strResultado = @fila["UbicacionLaboral"].ToString();
                }
            }

            strResultado = strResultado + "\\" + strDni + ".jpg";

            return strResultado;
        }

        public bool ReporteMesaEntrada(List<string> strDatos)
        {
            bool blnRetorno = false;
            string[,] Etiquetas = new string[7, 2];
            object objImagen = "";

            if (strDatos.Count > 0)
            {
                Etiquetas[0, 0] = "<<Puesto>>";
                Etiquetas[0, 1] = strDatos[0].ToString();
                Etiquetas[1, 0] = "<<Fecha>>";
                Etiquetas[1, 1] = strDatos[1].ToString();
                Etiquetas[2, 0] = "<<Orden>>";
                Etiquetas[2, 1] = strDatos[2].ToString();
                Etiquetas[3, 0] = "<<Empresa>>";
                Etiquetas[3, 1] = strDatos[3].ToString();
                Etiquetas[4, 0] = "<<Apellido>>";
                Etiquetas[4, 1] = strDatos[4].ToString();
                Etiquetas[5, 0] = "<<Dni>>";
                Etiquetas[5, 1] = strDatos[5].ToString();
                Etiquetas[6, 0] = "<<FNac>>";
                Etiquetas[6, 1] = strDatos[6].ToString();                
            }

            ReporteSpire.PrintWordDocument(@"P:\Temporal\PLANTILLA REPORTE INFORMES\Hoja de Ex. Físico II Laboral.doc", objImagen, Etiquetas);
            //ReporteSpire.PrintWordDocument(@"P:\Temporal\PLANTILLA REPORTE INFORMES\Hoja de Ex. Físico II Laboral.doc", objImagen, Etiquetas);
            //CrearReporte.PrintWordDocument(@"P:\Temporal\PLANTILLA REPORTE INFORMES\Hoja de Ex. Físico II Laboral.doc", objImagen, Etiquetas);
            blnRetorno = true;

            return blnRetorno;
        }
        
        public DataTable AudiometriaEstablcerDatos(DateTime dtFecha)
        {
            return reporte.AudiometriaEstablcerDatos(dtFecha);
        }

        public DataTable AudiometriaEstablcerDatos(DateTime dtFecha, string strNroOrden)
        {
            return reporte.AudiometriaEstablcerDatos(dtFecha, strNroOrden);
        }

        public DataTable AudiometriaApellidoNombre(string strDni)
        {
            return reporte.AudiometriaApellidoNombre(strDni);
        }

        public DataTable AudiometriaDiagnostico(DateTime dtfecha, string strNroOrden)
        {
            return reporte.AudiometriaDiagnostico(dtfecha, strNroOrden);
        }

        public bool InsertarDatos(List<string> strDatos)
        {
            return reporte.InsertarDatos(strDatos);
        }

        public bool ActualizaRevisado(string IdExamenLaboral, string Usuario, bool Estado, string strDicAudio, string strTipoPaciente)
        {
            return reporte.ActualizaRevisado(IdExamenLaboral, Usuario, Estado, strDicAudio, strTipoPaciente);
        }

        public bool VerificaEstudioAudioCargado(string strIdExamenLaboral)
        {
            return reporte.VerificaEstudioAudioCargado(strIdExamenLaboral);
        }

        public bool EstudioRevisado(string strIdExamenLaboral)
        {
            return reporte.EstudioRevisado(strIdExamenLaboral);
        }
    }
}
