using System;
using System.Collections.Generic;
using System.Text;

namespace Comunes
{
    public class Item
    {
        public string etiqueta;
        private string svalor;

        public Item(string eti, string val)
        {
            this.etiqueta = eti;
            this.valor = val;
        }

        public string valor
        {
            get
            {
                return this.svalor;
            }
            set
            {
                this.svalor = value;
            }
        }

        public override string ToString()
        {
            return etiqueta;
        }
    }
}
