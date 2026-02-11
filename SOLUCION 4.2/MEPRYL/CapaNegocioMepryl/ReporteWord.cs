using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/////Añadir referencias (nuevo)
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace CapaNegocioMepryl
{
    public class ReporteWord
    {
      //  string pathImage = @"C:\Users\carlos\Pictures\firma-transp.jpg";

        public ReporteWord()
        {
            // Constructor
        }

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object BuscarTexto, object ReemplazarTexto)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            if (ReemplazarTexto.ToString().Length > 255)
            {
                ReemplazarTexto = ReemplazarTexto.ToString().Substring(0, 255);
            }

            wordApp.Selection.Find.Execute(ref BuscarTexto,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref ReemplazarTexto,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }

        public bool CreateWordDocument(object PlantillaWord, object GuardarComo, object image, string[,] etiquetas, char chrTipoPaciente, bool blnImprimir)
        {
            bool blnEstado = false;
            List<int> processesbeforegen = getRunningProcesses();
            object missing = Missing.Value;
            string tempPath = Convert.ToString(image);

            Word.Application wordApp = new Word.Application();

            Word.Document aDoc = null;

            if (File.Exists((string)PlantillaWord))
            {
                DateTime today = DateTime.Now;

                object readOnly = true; //default
                object isVisible = false;

                wordApp.Visible = false;

                aDoc = wordApp.Documents.Open(ref PlantillaWord, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);

                aDoc.Activate();
                int valor = etiquetas.GetLength(0);

                //Find and replace:
                for (int i = 0; i < etiquetas.GetLength(0); i++)
                {
                    this.FindAndReplace(wordApp, etiquetas[i, 0], etiquetas[i, 1]);                    
                }

                //insert the picture:
                //Image img = resizeImage(pathImage, new Size(200, 90));
                //tempPath = @"C:\Users\carlos\Pictures\firma-transp.jpg"; // System.Windows.Forms.Application.StartupPath - Obtiene el path de donde se esta ejecutando la aplicacion
                //img.Save(tempPath);

                if (chrTipoPaciente == 'P')
                {
                    Object oMissed = aDoc.Paragraphs[27].Range; //the position you want to insert                
                    Object oLinkToFile = false;  //default
                    Object oSaveWithDocument = true;//default
                    if (!string.IsNullOrEmpty(tempPath))
                        aDoc.InlineShapes.AddPicture(tempPath, ref oLinkToFile, ref oSaveWithDocument, ref oMissed);
                }else if(chrTipoPaciente == 'L')
                {
                    Object oMissed = aDoc.Paragraphs[4].Range; //the position you want to insert                
                    Object oLinkToFile = false;  //default
                    Object oSaveWithDocument = true;//default
                    if (!string.IsNullOrEmpty(tempPath))
                        aDoc.InlineShapes.AddPicture(tempPath, ref oLinkToFile, ref oSaveWithDocument, ref oMissed);                        
                }
                
                #region Print Document :
                /*object copies = "1";
                object pages = "1";
                object range = Word.WdPrintOutRange.wdPrintCurrentPage;
                object items = Word.WdPrintOutItem.wdPrintDocumentContent;
                object pageType = Word.WdPrintOutPages.wdPrintAllPages;
                object oTrue = true;
                object oFalse = false;

                Word.Document document = aDoc;
                object nullobj = Missing.Value;
                int dialogResult = wordApp.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Show(ref nullobj);
                wordApp.Visible = false;
                if (dialogResult == 1)
                {
                    document.PrintOut(
                    ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                    ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                    ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
                }
                */
                #endregion
                
                blnEstado = true;
            }
            else
            {                
                return blnEstado;
            }

            //Save as: filename
            //aDoc.SaveAs2(ref GuardarComo, ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing,
            //        ref missing);

            //Exportar: Documento PDF
            if (blnImprimir == false)
            {
                aDoc.ExportAsFixedFormat(
                        GuardarComo.ToString(),
                        Word.WdExportFormat.wdExportFormatPDF,
                        false,
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint,
                        Word.WdExportRange.wdExportAllDocument,
                        0,
                        0,
                        Word.WdExportItem.wdExportDocumentWithMarkup,
                        true,
                        true,
                        Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks,
                        true,
                        true,
                        false,
                        ref missing);
            }
            else
            {
                string strDefaultPrinter = "";

                object copies = "1";
                object pages = "1";
                object range = Word.WdPrintOutRange.wdPrintCurrentPage;
                object items = Word.WdPrintOutItem.wdPrintDocumentContent;
                object pageType = Word.WdPrintOutPages.wdPrintAllPages;
                object oTrue = true;
                object oFalse = false;

                strDefaultPrinter = aDoc.Application.ActivePrinter;

                Word.Document document = aDoc;
                object nullobj = Missing.Value;
                //int dialogResult = wordApp.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Show(ref nullobj);                
                wordApp.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Execute();

                wordApp.Visible = false;
                //if (dialogResult == 1)
                //{
                    document.Application.ActivePrinter = strDefaultPrinter;
                    document.PrintOut(
                    ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                    ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                    ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
                //}
            }

            // https://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.document_methods.aspx
            // https://msdn.microsoft.com/en-us/library/microsoft.office.interop.word._document.exportasfixedformat.aspx

            //Close Document:
            //aDoc.Close(ref missing, ref missing, ref missing);

            //File.Delete(tempPath);
            List<int> processesaftergen = getRunningProcesses();
            killProcesses(processesbeforegen, processesaftergen);
            return blnEstado;
        }

        public bool PrintWordDocument(object PlantillaWord, object image, string[,] etiquetas)
        {
            bool blnEstado = false;
            List<int> processesbeforegen = getRunningProcesses();
            object missing = Missing.Value;
      //      object objNull = null;
            string tempPath = Convert.ToString(image);

            Word.Application wordApp = new Word.Application();

            Word.Document aDoc = null;

            if (File.Exists((string)PlantillaWord))
            {
                DateTime today = DateTime.Now;

                object readOnly = true; //default
                object isVisible = false;

                wordApp.Visible = false;

                aDoc = wordApp.Documents.Open(ref PlantillaWord, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);

                aDoc.Activate();
                int valor = etiquetas.GetLength(0);

                //Find and replace:
                for (int i = 0; i < etiquetas.GetLength(0); i++)
                {
                    this.FindAndReplace(wordApp, etiquetas[i, 0], etiquetas[i, 1]);
                }

                #region Print Document :
                object copies = "1";
                object pages = "1";
                object range = Word.WdPrintOutRange.wdPrintCurrentPage;
                object items = Word.WdPrintOutItem.wdPrintDocumentContent;
                object pageType = Word.WdPrintOutPages.wdPrintAllPages;
                object oTrue = true;
                object oFalse = false;

                Word.Document document = aDoc;

                document.Activate();
                object nullobj = Missing.Value;
                int dialogResult = 1; //wordApp.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Show(ref nullobj);
                wordApp.Visible = false;
                if (dialogResult == 1)
                {                    
                    document.PrintOut(
                    ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                    ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                    ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
                }
                #endregion

                blnEstado = true;
            }
            else
            {
                return blnEstado;
            }
            

            ////Imprimir: Documento
            //aDoc.PrintOut(
            //        true,
            //        false,
            //        Word.WdPrintOutRange.wdPrintCurrentPage,
            //        ref missing,
            //        ref missing,
            //        ref missing,
            //        Word.WdPrintOutItem.wdPrintDocumentContent,
            //        "1",
            //        "1",
            //        Word.WdPrintOutPages.wdPrintAllPages,
            //        false,
            //        true,
            //        ref missing,
            //        false,
            //        ref missing,
            //        ref missing,
            //        ref missing,
            //        ref missing);           

            List<int> processesaftergen = getRunningProcesses();
            killProcesses(processesbeforegen, processesaftergen);
            return blnEstado;
        }

        public List<int> getRunningProcesses()
        {
            List<int> ProcessIDs = new List<int>();
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                if (clsProcess.ProcessName.Contains("WINWORD"))
                {
                    ProcessIDs.Add(clsProcess.Id);
                }
            }
            return ProcessIDs;
        }

        private void killProcesses(List<int> processesbeforegen, List<int> processesaftergen)
        {
            foreach (int pidafter in processesaftergen)
            {
                bool processfound = false;
                foreach (int pidbefore in processesbeforegen)
                {
                    if (pidafter == pidbefore)
                    {
                        processfound = true;
                    }
                }

                if (processfound == false)
                {
                    Process clsProcess = Process.GetProcessById(pidafter);
                    clsProcess.Kill();
                }
            }
        }

        //Change Picture Size :
        private static Image resizeImage(string filename, Size size)
        {
            Image imgToResize = Image.FromFile(filename);
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
    }  
}
