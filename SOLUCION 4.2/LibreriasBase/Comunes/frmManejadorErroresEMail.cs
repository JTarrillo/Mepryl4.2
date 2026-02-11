using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using System.Web.Mail;


namespace Comunes
{
    public partial class frmManejadorErroresEMail : Form
    {
        public Configuracion configuracion;

        public frmManejadorErroresEMail()
        {
            InitializeComponent();
        }

        private void butEnviar_Click(object sender, System.EventArgs e)
        {
            string error = "", messageID = "";
            string body;

            string smtp, mail;

            error = "";
            smtp = ""; mail = "";

            this.Cursor = Cursors.WaitCursor;
            //Prepara el mensaje
            body = "-----------------\r\n" +
                    "Observaciones: \r\n" +
                    "-----------------\r\n" +
                    tbObservaciones.Text + "\r\n\r\n------------------------- Detalle del error -------------------------\r\n\r\n" +
                    "-----------------\r\n" +
                    "Fecha   : " + DateTime.Now.ToString() + "\r\n" +
                    "Sucursal: " + configuracion.sucursal.nombre + "\r\n" +
                    "Maquina : " + configuracion.maquina.nombre + "\r\n" +
                    "Modulo  : " + Modulo.Text + "\r\n" +
                    "-----------------\r\n\r\n" +
                    "-----------------\r\n" +
                    "Mensaje: \r\n" +
                    "-----------------\r\n" +
                    Mensaje.Text + "\r\n\r\n" +
                    "-----------------\r\n" +
                    "Pila de Llamadas: \r\n" +
                    "-----------------\r\n" +
                    PilaLlamadas.Text + "\r\n\r\n";



            //Envia el mail
            SMTPMail smtpMail = new SMTPMail();
            smtpMail.Identity = "Sistema de Errores";
            smtpMail.ReplyTo = configuracion.email_errores;
            smtpMail.MailFrom = configuracion.email_errores;

            smtpMail.MessageID = "<" + (Guid.NewGuid()).ToString() + ">";
            smtpMail.MailTo = configuracion.email_errores;
            smtpMail.Subject = "Errores: " + Mensaje.Text;
            smtpMail.MailData = body;

            //Primero prueba con el smtp.
            smtp = "mail.datadominus.com.ar";
            smtpMail.SMTPServerIP = smtp;
            //Ejecuta el Ping1
            //ping1 = ping.ping(smtpMail.SMTPServerIP);
            int ping1 = 1, ping2 = 0;
            if (ping1 == 1)
            {
                smtpMail.SendMail();
                error = smtpMail.ErrorMessage;
            }
            if (ping1 != 1 || error != "")
            {
                //Ejecuta el ping2
                mail = "smtp.datadominus.com.ar";
                smtpMail.SMTPServerIP = mail;
                //ping2 = ping.ping(smtpMail.SMTPServerIP);
                ping2 = 1;
                smtpMail.ErrorMessage = "";

                if (ping2 == 1)
                {
                    smtpMail.SendMail();
                    error += "\r\n\r\n/********************** Despues del error de smtp.servidor.com *********************\r\n\r\n" +
                        smtpMail.ErrorMessage;
                }
            }
            this.Cursor = Cursors.Arrow;
            //Si hubo errores en los ping
            if (smtpMail.ErrorMessage != "")
            {
                MessageBox.Show(smtpMail.ErrorMessage, "Error al enviar e-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}