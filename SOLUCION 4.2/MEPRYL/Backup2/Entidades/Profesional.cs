using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Profesional
    {
        private Guid id;
        private string nombre;
        private string apellido;
        private string tipo;
        private string codigo;
        private string lugarMatricula;
        private string nroMatricula;
        private string especialidad;
        private string estadoCivil;
        private string tipoDocumento;
        private string nroDocumento;
        private string tipoContribuyente;
        private string direccion;
        private string codigoPostal;
        private string localidad;
        private string provincia;
        private string telefono;
        private string celular;
        private string mail;
        private bool visitasCapital;
        private bool visitasProvincia;

        public Profesional()
        {
            id = Guid.Empty;
            nombre = string.Empty;
            apellido = string.Empty;
            tipo = string.Empty;
            codigo = string.Empty;
            lugarMatricula = string.Empty;
            nroMatricula = string.Empty;
            especialidad = string.Empty;
            estadoCivil = string.Empty;
            tipoDocumento = string.Empty;
            nroDocumento = string.Empty;
            tipoContribuyente = string.Empty;
            direccion = string.Empty;
            codigoPostal = string.Empty;
            localidad = string.Empty;
            provincia = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            mail = string.Empty;
            visitasCapital = false;
            visitasProvincia = false;
        }


        #region Getters&Setters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string LugarMatricula
        {
            get { return lugarMatricula; }
            set { lugarMatricula = value; }
        }

        public string NroMatricula
        {
            get { return nroMatricula; }
            set { nroMatricula = value; }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }

        public string NroDocumento
        {
            get { return nroDocumento; }
            set { nroDocumento = value; }
        }

        public string TipoContribuyente
        {
            get { return tipoContribuyente; }
            set { tipoContribuyente = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public bool VisitasCapital
        {
            get { return visitasCapital; }
            set { visitasCapital = value; }
        }

        public bool VisitasProvincia
        {
            get { return visitasProvincia; }
            set { visitasProvincia = value; }
        }

        #endregion
    }
}
