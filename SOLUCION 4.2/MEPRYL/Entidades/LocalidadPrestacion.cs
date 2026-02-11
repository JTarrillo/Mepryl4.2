using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class LocalidadPrestacion
    {
        private Guid id;
        private int codigo;
        private string tipo;
        private string descripcion;
        private int zona;

        public LocalidadPrestacion()
        {
            this.id = Guid.Empty;
            this.codigo = -1;
            this.tipo = string.Empty;
            this.descripcion = string.Empty;
            this.zona = -1;
        }

        #region Getters&Settters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        #endregion
    }
}
