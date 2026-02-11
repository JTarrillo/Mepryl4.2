using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Mail
    {
        private List<string> destinatarios;
        private List<string> adjuntos;
        private string asunto;
        private string cuerpo;
        private string cuenta;
        private string textoCuenta;
        private string contraseña;
        private string host;
        private int error;
        private string mensajeError;
        private string from;

        public Mail()
        {
            this.destinatarios = new List<string>();
            this.adjuntos = new List<string>();
            this.asunto = string.Empty;
            this.cuerpo = string.Empty;
            this.cuenta = string.Empty;
            this.textoCuenta = string.Empty;
            this.contraseña = string.Empty;
            this.host = string.Empty;
            this.error = 0;
            this.mensajeError = string.Empty;
            
        }
        

        #region Getters&Setters

        public List<string> Destinatarios
        {
            get { return destinatarios; }
            set { destinatarios = value; }
        }

        public List<string> Adjuntos
        {
            get { return adjuntos; }
            set { adjuntos = value; }
        }

        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }


        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }

        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }


        public string TextoCuenta
        {
            get { return textoCuenta; }
            set { textoCuenta = value; }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }


        public string Host
        {
            get { return host; }
            set { host = value; }
        }


        public int Error
        {
            get { return error; }
            set { error = value; }
        }

        public string MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }
        

        #endregion
    }
}
