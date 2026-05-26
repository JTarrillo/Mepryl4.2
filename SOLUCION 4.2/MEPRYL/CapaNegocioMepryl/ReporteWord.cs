using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace CapaNegocioMepryl
{
    public class ReporteWord
    {
        private Image _imgImprimir = null;

        public ReporteWord()
        {
        }

        public bool CreateWordDocument(object PlantillaWord, object GuardarComo, object image, string[,] etiquetas, char chrTipoPaciente, bool blnImprimir)
        {
            if (!File.Exists((string)PlantillaWord))
                return false;

            try
            {
                Document doc = new Document();
                doc.LoadFromFile(PlantillaWord.ToString());

                for (int i = 0; i < etiquetas.GetLength(0); i++)
                    ReemplazarTexto(doc, etiquetas[i, 0], etiquetas[i, 1]);

                string tempPath = Convert.ToString(image);
                if (!string.IsNullOrEmpty(tempPath) && File.Exists(tempPath))
                    InsertarImagen(doc, tempPath, chrTipoPaciente);

                if (!blnImprimir)
                    doc.SaveToFile(GuardarComo.ToString(), FileFormat.PDF);
                else
                    ImprimirDoc(doc);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PrintWordDocument(object PlantillaWord, object image, string[,] etiquetas)
        {
            if (!File.Exists((string)PlantillaWord))
                return false;

            try
            {
                Document doc = new Document();
                doc.LoadFromFile(PlantillaWord.ToString());

                for (int i = 0; i < etiquetas.GetLength(0); i++)
                    ReemplazarTexto(doc, etiquetas[i, 0], etiquetas[i, 1]);

                ImprimirDoc(doc);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ImprimirDoc(Document doc)
        {
            try
            {
                _imgImprimir = doc.SaveToImages(0, ImageType.Bitmap);
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.Print();
            }
            catch (Exception) { }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawImage(_imgImprimir, 0, 0);
        }

        private void InsertarImagen(Document doc, string imagePath, char chrTipoPaciente)
        {
            try
            {
                int indiceParrafo = (chrTipoPaciente == 'P') ? 26 : 3;

                if (doc.Sections.Count > 0 && doc.Sections[0].Paragraphs.Count > indiceParrafo)
                {
                    Paragraph parrafo = doc.Sections[0].Paragraphs[indiceParrafo];
                    Image img = RedimencionarImagen(imagePath, 90, 200);
                    DocPicture pic = new DocPicture(doc);
                    pic.LoadImage(img);
                    parrafo.ChildObjects.Add(pic);
                    img.Dispose();
                }
            }
            catch (Exception) { }
        }

        private void ReemplazarTexto(Document doc, string textoOriginal, string textoReemplazo)
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
                    // Intentar reemplazo general
                    doc.Replace(textoOriginal, textoReemplazo, true, true);

                    // Si no se encontró en el cuerpo, intentar en headers y footers
                    foreach (Section sec in doc.Sections)
                    {
                        try
                        {
                            if (sec.HeadersFooters != null)
                            {
                                // Header
                                if (sec.HeadersFooters.Header != null)
                                {
                                    foreach (Paragraph p in sec.HeadersFooters.Header.Paragraphs)
                                    {
                                        try { p.Replace(textoOriginal, textoReemplazo, true, true); } catch { }
                                    }
                                }
                                // Footer
                                if (sec.HeadersFooters.Footer != null)
                                {
                                    foreach (Paragraph p in sec.HeadersFooters.Footer.Paragraphs)
                                    {
                                        try { p.Replace(textoOriginal, textoReemplazo, true, true); } catch { }
                                    }
                                }
                            }

                            // Fallback agresivo: colapsar runs por párrafo y reemplazar si la etiqueta se encuentra
                            foreach (Paragraph p in sec.Paragraphs)
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

                                        // Log replacement for debugging
                                        try
                                        {
                                            string logPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "mepryl_reemplazo.log");
                                            System.IO.File.AppendAllText(logPath, DateTime.Now.ToString("s") + " Replaced in paragraph: " + textoOriginal + " -> " + textoReemplazo + "\n");
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
            catch (Exception)
            {
                // Continue replacing other etiquetas even if one entry fails.
            }
        }

        private Image RedimencionarImagen(string strPathFoto, int intAlto, int intAncho)
        {
            Image imgFoto = Image.FromFile(strPathFoto);
            Bitmap bmpImagen = new Bitmap(intAncho, intAlto);
            using (Graphics g = Graphics.FromImage(bmpImagen))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgFoto, 0, 0, intAncho, intAlto);
            }
            imgFoto.Dispose();
            return bmpImagen;
        }

        // Mantenido por compatibilidad con código existente
        public List<int> getRunningProcesses()
        {
            return new List<int>();
        }
    }
}
