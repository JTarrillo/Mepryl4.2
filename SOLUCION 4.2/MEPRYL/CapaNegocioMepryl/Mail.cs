using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using Entidades;

namespace CapaNegocioMepryl
{
    public class Mail
    {
        public Entidades.Mail enviarMail(Entidades.Mail m)
        {
            CapaDatosMepryl.EnviadorMail enviador = new EnviadorMail();
            return enviador.enviarMail(m);
        }
    }
}
