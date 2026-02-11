using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entidades
{
    public class PacientePreventiva
    {
        private Guid id;
        private string apellidoNombre;
        private string telefono;
        private DataTable ligaYClub;
        private DateTime nacimiento;

        public PacientePreventiva()
        {
            id = Guid.Empty;
            apellidoNombre = string.Empty;
            telefono = string.Empty;
            ligaYClub = new DataTable();
            nacimiento = new DateTime(1800, 1, 1);
        }

        #region Getters&Setters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ApellidoNombre
        {
            get { return apellidoNombre; }
            set { apellidoNombre = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public DataTable LigaYClub
        {
            get { return ligaYClub; }
            set { ligaYClub = value; }
        }

        public DateTime Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }

        #endregion



    }
}
