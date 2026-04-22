using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Threading;

namespace CapaNegocioMepryl
{
    class ReporteWordSpire
    {
        Document doc;
        int intIndiceDictamen = 0;
        Image img = null;

        private void RegistrarDiagnosticoReporte(string mensaje)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string carpetaLogs = Path.Combine(basePath, "logs");
                Directory.CreateDirectory(carpetaLogs);
                string rutaLog = Path.Combine(carpetaLogs, "diagnostico_impresion_spire.log");
                string linea = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " | " + mensaje + Environment.NewLine;
                File.AppendAllText(rutaLog, linea, Encoding.UTF8);
                Debug.WriteLine("[diagnostico_spire] " + mensaje);
            }
            catch
            {
                // El diagnostico no debe interrumpir el flujo principal.
            }
        }

        public ReporteWordSpire()
        {
            doc = new Document();
        }

        public bool CreateWordDocument(object PlantillaWord, object GuardarComo, object image, string[,] etiquetas, bool blnClinico, string strTipoLaboratorio)
        {
            object objImg = new object();
            objImg = image;
            try
            {
                doc.LoadFromFile(PlantillaWord.ToString());

                for (int i = 0; i < etiquetas.GetLength(0); i++)
                {
                    doc.Replace(etiquetas[i, 0], etiquetas[i, 1], true, true);

                    if (blnClinico)
                        verificaDictamenClinicoLaboral(etiquetas[i, 0], etiquetas[i, 1]);

                }

                if (!string.IsNullOrEmpty(objImg.ToString()))
                {
                    ReemplazarImagen("<<Foto>>", RedimencionarImagen(image.ToString(), 85, 85));
                }

                if (!string.IsNullOrEmpty(strTipoLaboratorio) && !blnClinico)
                {
                    //BorrarTablas(strTipoLaboratorio);
                }

                intIndiceDictamen = 0;
                GuardarPdf(GuardarComo.ToString());

                return true;

            }
            catch (System.IO.IOException EX)
            {
                return false;
            }
        }

        public bool PrintWordDocument(object PlantillaWord, object image, string[,] etiquetas)
        {
            object objImg = new object();
            objImg = image;
            try
            {
                RegistrarDiagnosticoReporte("PrintWordDocument: inicio | plantilla=" + PlantillaWord);
                doc.LoadFromFile(PlantillaWord.ToString());
                RegistrarDiagnosticoReporte("PrintWordDocument: plantilla cargada");

                for (int i = 0; i < etiquetas.GetLength(0); i++)
                {
                    doc.Replace(etiquetas[i, 0], etiquetas[i, 1], true, true);
                }
                RegistrarDiagnosticoReporte("PrintWordDocument: etiquetas reemplazadas | cantidad=" + etiquetas.GetLength(0).ToString());

                //GuardarPdf(GuardarComo.ToString());
                RegistrarDiagnosticoReporte("PrintWordDocument: antes de ImprimirDoc");
                bool resultadoImpresion = ImprimirDoc();
                RegistrarDiagnosticoReporte("PrintWordDocument: despues de ImprimirDoc");
                RegistrarDiagnosticoReporte("PrintWordDocument: resultado impresion=" + resultadoImpresion.ToString());
                //GuardarDocumentoWord();

                return resultadoImpresion;

            }
            catch (System.IO.IOException EX)
            {
                RegistrarDiagnosticoReporte("PrintWordDocument: IOException " + EX.ToString());
                return false;
            }
            catch (Exception ex)
            {
                RegistrarDiagnosticoReporte("PrintWordDocument: Exception " + ex.ToString());
                return false;
            }
        }

        private Image RedimencionarImagen(string strPathFoto, int intAlto, int intAncho)
        {
            Image imgFoto = Image.FromFile(strPathFoto);
            Bitmap bmpImagen = new Bitmap(intAncho, intAlto);

            using (Graphics vGraphics = Graphics.FromImage((Image)bmpImagen))
            {
                vGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                vGraphics.DrawImage(imgFoto, 0, 0, intAncho, intAlto);
            }

            return (Image)bmpImagen;
        }

        private void ReemplazarImagen(string strEtiqueta, Image imgFoto)
        {
            TextSelection[] selecciones = doc.FindAllString(strEtiqueta, true, true);
            int index = 0;
            TextRange range = null;

            foreach (TextSelection sec in selecciones)
            {
                DocPicture pic = new DocPicture(doc);
                pic.LoadImage(imgFoto);

                range = sec.GetAsOneRange();
                index = range.OwnerParagraph.ChildObjects.IndexOf(range);
                range.OwnerParagraph.ChildObjects.Insert(index, pic);
                range.OwnerParagraph.ChildObjects.Remove(range);
            }
        }

        private bool ImprimirDoc()
        {
            try
            {
                RegistrarDiagnosticoReporte("ImprimirDoc: antes de SaveToImages");
                img = doc.SaveToImages(0, ImageType.Bitmap);
                RegistrarDiagnosticoReporte("ImprimirDoc: despues de SaveToImages");

                RegistrarDiagnosticoReporte("ImprimirDoc: antes de pipeline impresion con timeout");
                bool impreso = EjecutarPipelineImpresionConTimeout(15000);
                RegistrarDiagnosticoReporte("ImprimirDoc: resultado pipeline impresion=" + impreso.ToString());
                return impreso;
                //PrintDocument printDoc = doc.PrintDocument;
                //printDoc.PrintController = new StandardPrintController();
                //printDoc.Print();
            }
            catch (System.IO.IOException ex)
            {
                RegistrarDiagnosticoReporte("ImprimirDoc: IOException " + ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                RegistrarDiagnosticoReporte("ImprimirDoc: Exception " + ex.ToString());
                return false;
            }
        }

        private bool EjecutarPipelineImpresionConTimeout(int timeoutMs)
        {
            Exception errorImpresion = null;
            bool termino = false;

            Thread hiloImpresion = new Thread(() =>
            {
                try
                {
                    RegistrarDiagnosticoReporte("PipelineImpresion: antes de new PrintDocument");
                    using (PrintDocument pd = new PrintDocument())
                    {
                        RegistrarDiagnosticoReporte("PipelineImpresion: despues de new PrintDocument");
                        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                        pd.PrintController = new StandardPrintController();
                        RegistrarDiagnosticoReporte("PipelineImpresion: PrintController=StandardPrintController");
                        RegistrarDiagnosticoReporte("PipelineImpresion: antes de pd.Print");
                        pd.Print();
                        RegistrarDiagnosticoReporte("PipelineImpresion: despues de pd.Print");
                    }
                }
                catch (Exception ex)
                {
                    errorImpresion = ex;
                }
                finally
                {
                    termino = true;
                }
            });

            hiloImpresion.IsBackground = true;
            hiloImpresion.SetApartmentState(ApartmentState.STA);
            hiloImpresion.Start();

            if (!hiloImpresion.Join(timeoutMs))
            {
                RegistrarDiagnosticoReporte("PipelineImpresion: timeout de " + timeoutMs.ToString() + "ms");
                return false;
            }

            if (!termino)
            {
                RegistrarDiagnosticoReporte("PipelineImpresion: hilo finalizo sin marcar termino");
                return false;
            }

            if (errorImpresion != null)
            {
                RegistrarDiagnosticoReporte("PipelineImpresion: exception " + errorImpresion.ToString());
                return false;
            }

            return true;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawImage(img, 0, 0);
        }

        private void GuardarPdf(string strArchivoSalida)
        {
            try
            {
                doc.SaveToFile(strArchivoSalida, FileFormat.PDF);
            }
            catch (System.IO.IOException ex)
            {

            }
        }

        private void BorrarTablas(string strTipoReporte)
        {
            switch (strTipoReporte)
            {
                case "CASINO":
                    Table table = doc.Sections[0].Tables[2] as Table;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        table.Rows[i].Cells.RemoveAt(5);
                        table.Rows[i].Cells.RemoveAt(6);
                        table.Rows[i].Cells.RemoveAt(7);
                    }

                    break;
                case "ARBITRO":
                    Table table1 = doc.Sections[1].Tables[3] as Table;

                    for (int i = 0; i < table1.Rows.Count; i++)
                    {
                        table1.Rows[i].Cells.RemoveAt(4);
                    }

                    break;
                default:
                    break;
            }
        }

        private void verificaDictamenClinicoLaboral(string strEtiqueta, string valor)
        {
            Table table = doc.Sections[0].Tables[8] as Table;

            if (strEtiqueta == "<<Laboratorio>>")
            {
                intIndiceDictamen = 2;

                if (string.IsNullOrEmpty(valor))
                {
                    table.Rows.RemoveAt(intIndiceDictamen);
                    --intIndiceDictamen;
                }
            }
            if (strEtiqueta == "<<Ecg>>")
            {
                intIndiceDictamen = intIndiceDictamen + 1;

                if (string.IsNullOrEmpty(valor))
                {
                    table.Rows.RemoveAt(intIndiceDictamen);
                    --intIndiceDictamen;
                }
            }
            if (strEtiqueta == "<<RxToraxF>>")
            {
                intIndiceDictamen = intIndiceDictamen + 1;

                if (string.IsNullOrEmpty(valor))
                {
                    table.Rows.RemoveAt(intIndiceDictamen);
                    --intIndiceDictamen;
                }
            }
            if (strEtiqueta == "<<Ergometria>>")
            {
                intIndiceDictamen = intIndiceDictamen + 1;

                if (string.IsNullOrEmpty(valor))
                {
                    table.Rows.RemoveAt(intIndiceDictamen);
                    --intIndiceDictamen;
                }
            }
            if (strEtiqueta == "<<Ecocardiograma>>")
            {
                intIndiceDictamen = intIndiceDictamen + 1;

                if (string.IsNullOrEmpty(valor))
                {
                    table.Rows.RemoveAt(intIndiceDictamen);
                    --intIndiceDictamen;
                }
            }
            if (strEtiqueta == "<<Espirometria>>")
            {
                intIndiceDictamen = intIndiceDictamen + 1;

                if (string.IsNullOrEmpty(valor))
                {
                    table.Rows.RemoveAt(intIndiceDictamen);
                    --intIndiceDictamen;
                }
            }
        }

        private void GuardarDocumentoWord()
        {
            string strArchivoTemp = @System.IO.Path.GetTempPath() + "\\fisicoII.doc";
            doc.SaveToFile(strArchivoTemp, FileFormat.Doc);

            if (System.IO.File.Exists(strArchivoTemp))
            {
                RichEditDocumentServer server = new RichEditDocumentServer();
                server.Document.AppendDocumentContent(strArchivoTemp, DocumentFormat.Doc);
                DevExpress.XtraPrinting.Native.PrintDialog pDialog = new DevExpress.XtraPrinting.Native.PrintDialog();



                //ProcessStartInfo info = new ProcessStartInfo(strArchivoTemp);
                //info.Verb = "Print";
                //info.CreateNoWindow = true;
                //info.WindowStyle = ProcessWindowStyle.Hidden;
                //Process.Start(info);
            }
        }
    }
}
