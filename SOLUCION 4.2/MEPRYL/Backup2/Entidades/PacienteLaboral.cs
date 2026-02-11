using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entidades
{
    public class PacienteLaboral
    {
        private Guid id;
        private string sexo;
        private string dni;
        private string apellido;
        private string nombre;
        private DateTime nacimiento;
        private Guid nacionalidad;
        private string direccion;
        private string entreCalle1;
        private string entreCalle2;
        private Guid idLocalidad;
        private string localidadTexto;
        private string telefonoParticular;
        private string telefonoCelular;
        private string tarea;
        private string mail;
        private string cuil;
        private Guid idEmpresa;
        private DataTable historiaClinica;
        private string empresa;
        private DateTime ingreso;
        private string dniAnterior;  // GRV - Ramírez - Referencia al DNI anterior antes de modificar

  

        public PacienteLaboral()
        {
            this.id = Guid.Empty;
            this.sexo = string.Empty;
            this.dni = string.Empty;
            this.apellido = string.Empty;
            this.nombre = string.Empty;
            this.nacimiento = new DateTime(1800, 1, 1);
            this.nacionalidad = Guid.Empty;
            this.direccion = string.Empty;
            this.entreCalle1 = string.Empty;
            this.entreCalle2 = string.Empty;
            this.idLocalidad = Guid.Empty;
            this.localidadTexto = string.Empty;
            this.telefonoParticular = string.Empty;
            this.telefonoCelular = string.Empty;
            this.tarea = string.Empty;
            this.mail = string.Empty;
            this.cuil = string.Empty;
            this.idEmpresa = Guid.Empty;
            this.historiaClinica = new DataTable();
            this.empresa = string.Empty;
            this.ingreso = new DateTime(1800, 1, 1);
            this.dniAnterior = string.Empty; // GRV - Ramírez - Referencia al DNI anterior antes de modificar
        }


        #region Getters&Setters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Ingreso
        {
            get { return ingreso; }
            set { ingreso = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
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

        public DateTime Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }

        public Guid Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string EntreCalle1
        {
            get { return entreCalle1; }
            set { entreCalle1 = value; }
        }

        public string EntreCalle2
        {
            get { return entreCalle2; }
            set { entreCalle2 = value; }
        }

        public Guid IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }

        public string LocalidadTexto
        {
            get { return localidadTexto; }
            set { localidadTexto = value; }
        }

        public string TelefonoParticular
        {
            get { return telefonoParticular; }
            set { telefonoParticular = value; }
        }

        public string TelefonoCelular
        {
            get { return telefonoCelular; }
            set { telefonoCelular = value; }
        }

        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Cuil
        {
            get { return cuil; }
            set { cuil = value; }
        }

        public Guid IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }

        public DataTable HistoriaClinica
        {
            get { return historiaClinica; }
            set { historiaClinica = value; }
        }

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public string DniAnterior
        {
            get { return dniAnterior; }
            set { dniAnterior = value; }
        }

        
        #endregion

    }
}
