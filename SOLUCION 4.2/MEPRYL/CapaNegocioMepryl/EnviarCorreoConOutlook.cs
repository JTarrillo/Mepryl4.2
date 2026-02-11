using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;

namespace CapaNegocioMepryl
{
    public class EnviarCorreoConOutlook
    {
        public EnviarCorreoConOutlook()
        {

        }

        public bool AbrirOutlook(string mailDirection, string mailSubject, string mailContent, string mailAdjunto)
        {
            bool blnRespuesta = false; 

            try
            {
                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                // Corregir Mail
                mailDirection = mailDirection.Replace("\n", "");
                mailDirection = mailDirection.Replace("\t", "");
                mailDirection = mailDirection.Trim();

                oMsg.Subject = mailSubject;
                oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                oMsg.BCC = "";
                oMsg.To = mailDirection;

                oMsg.HTMLBody = mailContent;
                if (!string.IsNullOrEmpty(mailAdjunto))
                {
                    oMsg.Attachments.Add(Convert.ToString(mailAdjunto), Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                    blnRespuesta = true;
                }
                else
                    blnRespuesta = false;

                oMsg.Display(true); //In order to displ
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                return false;
            }

            return blnRespuesta;
        }
    }
}
