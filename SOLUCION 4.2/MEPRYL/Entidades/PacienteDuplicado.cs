using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Entidades
{
    public class PacienteDuplicado
    {
        private Guid id;
        private string apellido;
        private string nombre;
        private string fechaNacimiento;
        private string dni;
        private DataTable consultasYExamenes;


        public PacienteDuplicado()
        {
            id = new Guid();
            apellido = string.Empty;
            nombre = string.Empty;
            fechaNacimiento = string.Empty;
            dni = string.Empty;
            consultasYExamenes = new DataTable();
        }

        #region Getters&Setters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public DataTable ConsultasYExamenes
        {
            get { return consultasYExamenes; }
            set { consultasYExamenes = value; }
        }

        #endregion

    }
}
