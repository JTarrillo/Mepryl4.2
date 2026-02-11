using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class CondicionLaboral
    {
        private Guid id;
        private string lugarAtencion;
        private int codigo;
        private string descripcion;
        private string justificacion;
        private string alta;
        private string fechaAlta;
        private string fechaCitacion;

        public CondicionLaboral()
        {
            id = new Guid();
            lugarAtencion = "";
            codigo = -1;
            descripcion = "";
            justificacion = "";
            alta = "";
            fechaAlta = "";
            fechaCitacion = "";
        }

        #region Getters&Setters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string LugarAtencion
        {
            get { return lugarAtencion; }
            set { lugarAtencion = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Justificacion
        {
            get { return justificacion; }
            set { justificacion = value; }
        }

        public string Alta
        {
            get { return alta; }
            set { alta = value; }
        }

        public string FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        public string FechaCitacion
        {
            get { return fechaCitacion; }
            set { fechaCitacion = value; }
        }

        #endregion
    }
}
