using System;
using System.IO;
using Spire.Doc;
using Spire.Doc.Documents;
using System.Drawing;
using Spire.Doc.Fields;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;

namespace CapaNegocioMepryl
{
    class ReporteWordSpire
    {
        Document doc;
        int intIndiceDictamen = 0;
        Image img = null;

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
                    ReemplazarTexto(etiquetas[i, 0], etiquetas[i, 1]);
                    
                    if (blnClinico)
                        verificaDictamenClinicoLaboral(etiquetas[i, 0], etiquetas[i, 1]);
                    
                }

                if (!string.IsNullOrEmpty(objImg.ToString()))
                {
                    ReemplazarImagen("<<Foto>>", RedimencionarImagen(image.ToString(), 85, 85));
                }

                if(!string.IsNullOrEmpty(strTipoLaboratorio) && !blnClinico)
                {
                    //BorrarTablas(strTipoLaboratorio);
                }

                intIndiceDictamen = 0;
                GuardarPdf(GuardarComo.ToString());

                return true;

            }catch(System.IO.IOException EX)
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
                Debug.WriteLine($"[diagnostico_spire] PrintWordDocument: inicio | plantilla={PlantillaWord}");
                doc.LoadFromFile(PlantillaWord.ToString());
                Debug.WriteLine("[diagnostico_spire] PrintWordDocument: plantilla cargada");

                for (int i = 0; i < etiquetas.GetLength(0); i++)
                {
                    ReemplazarTexto(etiquetas[i, 0], etiquetas[i, 1]);
                }
                Debug.WriteLine($"[diagnostico_spire] PrintWordDocument: etiquetas reemplazadas | cantidad={etiquetas.GetLength(0)}");

                Debug.WriteLine("[diagnostico_spire] PrintWordDocument: antes de ImprimirDoc");

                Cursor cursorAnterior = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                bool resultado = false;
                try
                {
                    resultado = ImprimirDoc();
                }
                finally
                {
                    Cursor.Current = cursorAnterior;
                }

                Debug.WriteLine("[diagnostico_spire] PrintWordDocument: despues de ImprimirDoc");
                Debug.WriteLine($"[diagnostico_spire] PrintWordDocument: resultado impresion={resultado}");
                return resultado;
            }
            catch (System.IO.IOException EX)
            {
                Debug.WriteLine($"[diagnostico_spire] PrintWordDocument: IOException | {EX.Message}");
                return false;
            }
        }
        
        private Image RedimencionarImagen(string strPathFoto, int intAlto, int intAncho)
        {
            Image imgFoto = Image.FromFile(strPathFoto);
            Bitmap bmpImagen = new Bitmap(intAncho, intAlto);

            using (Graphics vGraphics = Graphics.FromImage((Image)bmpImagen)){
                vGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                vGraphics.DrawImage(imgFoto, 0, 0, intAncho, intAlto);
            }

            return (Image)bmpImagen;
        }

        private void ReemplazarTexto(string textoOriginal, string textoReemplazo)
        {
            try
            {
                TextSelection[] selecciones = doc.FindAllString(textoOriginal, true, true);
                if (selecciones != null && selecciones.Length > 0)
                {
                    foreach (TextSelection seleccion in selecciones)
                    {
                        seleccion.GetAsOneRange().Text = textoReemplazo;
                    }
                }
                else
                {
                    doc.Replace(textoOriginal, textoReemplazo, true, true);
                    // Reemplazar también en headers y footers (por si la etiqueta está en el encabezado)
                    foreach (Section sec in doc.Sections)
                    {
                        try
                        {
                            if (sec.HeadersFooters != null)
                            {
                                if (sec.HeadersFooters.Header != null)
                                {
                                    foreach (Paragraph p in sec.HeadersFooters.Header.Paragraphs)
                                    {
                                        try { p.Replace(textoOriginal, textoReemplazo, true, true); } catch { }
                                    }
                                }
                                if (sec.HeadersFooters.Footer != null)
                                {
                                    foreach (Paragraph p in sec.HeadersFooters.Footer.Paragraphs)
                                    {
                                        try { p.Replace(textoOriginal, textoReemplazo, true, true); } catch { }
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                    // Fallback: colapsar runs de párrafo y reemplazar si aparece la etiqueta
                    foreach (Section sec2 in doc.Sections)
                    {
                        try
                        {
                            foreach (Paragraph p in sec2.Paragraphs)
                            {
                                try
                                {
                                    string combined = "";
                                    foreach (DocumentObject obj in p.ChildObjects)
                                    {
                                        if (obj is TextRange)
                                            combined += ((TextRange)obj).Text;
                                        else
                                            combined += " ";
                                    }

                                    if (!string.IsNullOrEmpty(combined) && combined.Contains(textoOriginal))
                                    {
                                        string replaced = combined.Replace(textoOriginal, textoReemplazo);
                                        p.ChildObjects.Clear();
                                        p.AppendText(replaced);

                                        try
                                        {
                                            string logPath = Path.Combine(Path.GetTempPath(), "mepryl_reemplazo_spire.log");
                                            File.AppendAllText(logPath, DateTime.Now.ToString("s") + " Replaced in paragraph: " + textoOriginal + " -> " + textoReemplazo + "\n");
                                        }
                                        catch { }
                                    }
                                }
                                catch { }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[diagnostico_spire] ReemplazarTexto: excepcion en etiqueta {textoOriginal} | {ex.Message}");
            }
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
                Debug.WriteLine("[diagnostico_spire] ImprimirDoc: antes de SaveToImages");
                img = doc.SaveToImages(0, ImageType.Bitmap);
                Debug.WriteLine("[diagnostico_spire] ImprimirDoc: despues de SaveToImages");

                Debug.WriteLine("[diagnostico_spire] ImprimirDoc: antes de pipeline impresion con timeout");
                bool resultado = PipelineImpresion();
                Debug.WriteLine($"[diagnostico_spire] ImprimirDoc: resultado pipeline impresion={resultado}");
                return resultado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[diagnostico_spire] ImprimirDoc: excepcion | {ex.Message}");
                return false;
            }
        }

        private bool PipelineImpresion()
        {
            bool imprimioOk = false;
            bool terminado = false;
            const int TIMEOUT_MS = 15000;

            Debug.WriteLine("[diagnostico_spire] PipelineImpresion: antes de new PrintDocument");
            var pd = new PrintDocument();
            Debug.WriteLine("[diagnostico_spire] PipelineImpresion: despues de new PrintDocument");
            pd.PrintController = new StandardPrintController();
            Debug.WriteLine("[diagnostico_spire] PipelineImpresion: PrintController=StandardPrintController");
            pd.PrintPage += pd_PrintPage;

            // Ejecutar pd.Print() en un hilo separado para no bloquear la UI
            Thread hiloImpresion = new Thread(() =>
            {
                try
                {
                    Debug.WriteLine("[diagnostico_spire] PipelineImpresion: antes de pd.Print");
                    pd.Print();
                    Debug.WriteLine("[diagnostico_spire] PipelineImpresion: despues de pd.Print");
                    imprimioOk = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[diagnostico_spire] PipelineImpresion: excepcion en hilo | {ex.Message}");
                    imprimioOk = false;
                }
                finally
                {
                    terminado = true;
                }
            });
            hiloImpresion.SetApartmentState(ApartmentState.STA);
            hiloImpresion.IsBackground = true;
            hiloImpresion.Start();

            // Esperar con Application.DoEvents() para mantener la UI viva
            int transcurrido = 0;
            while (!terminado && transcurrido < TIMEOUT_MS)
            {
                Application.DoEvents();
                Thread.Sleep(50);
                transcurrido += 50;
            }

            if (!terminado)
            {
                Debug.WriteLine($"[diagnostico_spire] PipelineImpresion: timeout de {TIMEOUT_MS}ms");
                // El hilo es background=true, termina solo al cerrar la app
                return false;
            }

            return imprimioOk;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawImage(img, 0,0);            
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
            string strArchivoTemp = @System.IO.Path.GetTempPath() + "\\fisicoII.doc" ;
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
