using System;
using Spire.Doc;
using Spire.Doc.Documents;
using System.Drawing;
using Spire.Doc.Fields;
 
using System.Drawing.Printing;
using System.Diagnostics;
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
                    doc.Replace(etiquetas[i, 0], etiquetas[i, 1], true, true);
                    
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
                doc.LoadFromFile(PlantillaWord.ToString());

                for (int i = 0; i < etiquetas.GetLength(0); i++)
                {
                    doc.Replace(etiquetas[i, 0], etiquetas[i, 1], true, true);
                }

                //GuardarPdf(GuardarComo.ToString());
                ImprimirDoc();
                //GuardarDocumentoWord();

                return true;

            }
            catch (System.IO.IOException EX)
            {
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
        
        private void ImprimirDoc()
        {
            try
            {
                img = doc.SaveToImages(0, ImageType.Bitmap);
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);                
                pd.Print();
                //PrintDocument printDoc = doc.PrintDocument;
                //printDoc.PrintController = new StandardPrintController();
                //printDoc.Print();
            }
            catch (System.IO.IOException ex)
            {

            }
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
