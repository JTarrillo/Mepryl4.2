using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Net.Mail;
using System.Threading;

namespace CapaDatosMepryl
{
    public class EnviadorMail
    {
        public Mail enviarMail(Mail mail)
        {
            string destinatarioActual = "";
            string errorAl = "";
            foreach (string destinatario in mail.Destinatarios)
            {
                 try
                 {
                    errorAl = "";
                    destinatarioActual = destinatario;

                    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                    mmsg.To.Add(destinatario);
                    mmsg.Subject = mail.Asunto;
                    mmsg.SubjectEncoding = System.Text.Encoding.UTF8;                    
                    mmsg.Body = mail.Cuerpo;
                    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                    mmsg.IsBodyHtml = false;

                    errorAl = "Adjuntar elementos";
                    foreach (string ruta in mail.Adjuntos)
                    {
                        mmsg.Attachments.Add(new Attachment(ruta));
                    }

                    errorAl = "Validar cuenta interna Mepyl";
                    mmsg.From = new System.Net.Mail.MailAddress(mail.Cuenta, mail.TextoCuenta);
                    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                    cliente.Credentials =
                        new System.Net.NetworkCredential(mail.Cuenta, mail.Contraseña);

                    cliente.Port = 587;
                    cliente.EnableSsl = false;
                    cliente.Host = "mail.mepryl.com.ar";

                    errorAl = "Intentar Enviar. Posible direccion inexistente";
                    cliente.Send(mmsg);
                    mmsg.Dispose();
                    mail.Error = 0;
                }
                 catch (System.Net.Mail.SmtpException ex)
                {
                     mail.Error = -1;
                     mail.MensajeError = mail.MensajeError + "No se pudo enviar mail a: " + destinatarioActual + 
                     " (" + errorAl + ") " + " .Codigo error: " + ex.ToString() + "\n";
                }
            }
            return mail;    
        }
    }
}
