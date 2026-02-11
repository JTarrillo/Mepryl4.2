using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Resultado
    {
        private int modo;
        private string mensaje;
        private Guid idRetorno;


        public Resultado()
        {
            modo = 0;
            mensaje = "";
            idRetorno = Guid.Empty;
        }

        #region Getters&Setters

        public int Modo
        {
            get { return modo; }
            set { modo = value; }
        }
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public Guid IdRetorno
        {
            get { return idRetorno; }
            set { idRetorno = value; }
        }

        #endregion

    }

   
}
