using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entidades
{
    public class MesaEntrada
    {
        private string dni;
        private string apellido;
        private string nombre;
        private string telefono;
        private string celular;
        private string nacimiento;
        private string observacionesTurno;
        private string observacionesMesaEntrada; 
        private DataTable clubesOEmpresa;
        private string nroOrden;
        private string nroExamen;
        private TipoExamen tipoExamen;
        private string mail;

        public MesaEntrada()
        {
            dni = string.Empty;
            apellido = string.Empty;
            nombre = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            nacimiento = string.Empty;
            observacionesTurno = string.Empty;
            observacionesMesaEntrada = string.Empty;
            clubesOEmpresa = new DataTable();
            nroOrden = string.Empty;
            nroExamen = string.Empty;
            tipoExamen = new TipoExamen();
            mail = string.Empty;
        }


        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public TipoExamen TipoExamen
        {
            get { return tipoExamen; }
            set { tipoExamen = value; }
        }

        public string NroOrden
        {
            get { return nroOrden; }
            set { nroOrden = value; }
        }

        public string NroExamen
        {
            get { return nroExamen; }
            set { nroExamen = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string ObservacionesTurno
        {
            get { return observacionesTurno; }
            set { observacionesTurno = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }

        public string ObservacionesMesaEntrada
        {
            get { return observacionesMesaEntrada; }
            set { observacionesMesaEntrada = value; }
        }

        public DataTable ClubesOEmpresa
        {
            get { return clubesOEmpresa; }
            set { clubesOEmpresa = value; }
        }
        
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}
