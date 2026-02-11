using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Empresa
    {
        private Guid id;
        private string razonSocial;
        private string nombreFantasia;
        private string tipoDocumento;
        private string numeroDocumento;
        private string tipoContribuyente;
        private string direccion;
        private string codigoPostal;
        private string provincia;
        private string localidad;
        private string tipoEntidad;
        private Guid art;
        private string actividadPrincipal;
        private int cantPersonal;
        private string paginaWeb;
        private System.IO.MemoryStream logo;
        private string apeNom1;
        private string area1;
        private string telefono1;
        private string celular1;
        private string email1;
        private string apeNom2;
        private string area2;
        private string telefono2;
        private string celular2;
        private string email2;
        private string apeNom3;
        private string area3;
        private string telefono3;
        private string celular3;
        private string email3;
        private string categoria;
        private string condicionVenta;
        private string tipoContrato;
        //private Guid listaPrecios;
        private int listaPrecios;
        private bool modifConFact;
        private string diasYHorariosPago;
        private string observaciones;
        private decimal impAbono;
        private decimal intMora;
        private string ultMesFact;
        private string ultAnioFact;
        private bool consultas;
        private bool visitas;
        private int cantVisitas;
        private bool exAptitud;
        private int cantExAptitud;
        private string fechaAlta;
        private string activo;
        private bool blnEmpresaPrincipal;

        public Empresa()
        {
            this.id = Guid.Empty;
            this.razonSocial = string.Empty;
            this.nombreFantasia = string.Empty;
            this.tipoDocumento = string.Empty;
            this.numeroDocumento = string.Empty;
            this.tipoContribuyente = string.Empty;
            this.direccion = string.Empty;
            this.codigoPostal = string.Empty;
            this.provincia = string.Empty;
            this.localidad = string.Empty;
            this.tipoEntidad = string.Empty;
            this.art = Guid.Empty;
            this.actividadPrincipal = string.Empty;
            this.cantPersonal = -1;
            this.paginaWeb = string.Empty;
            this.logo = new System.IO.MemoryStream();
            this.apeNom1 = string.Empty;
            this.area1 = string.Empty;
            this.telefono1 = string.Empty;
            this.celular1 = string.Empty;
            this.email1 = string.Empty;
            this.apeNom2 = string.Empty;
            this.area2 = string.Empty;
            this.telefono2 = string.Empty;
            this.celular2 = string.Empty;
            this.email2 = string.Empty;
            this.apeNom3 = string.Empty;
            this.area3 = string.Empty;
            this.telefono3 = string.Empty;
            this.celular3 = string.Empty;
            this.email3 = string.Empty;
            this.condicionVenta = string.Empty;
            this.categoria = string.Empty;
            this.tipoContrato = string.Empty;
            //this.listaPrecios = Guid.Empty;
            this.listaPrecios = -1;
            this.modifConFact = false;
            this.diasYHorariosPago = string.Empty;
            this.observaciones = string.Empty;
            this.impAbono = new Decimal(0);
            this.intMora = new Decimal(0);
            this.ultMesFact = string.Empty;
            this.ultAnioFact = string.Empty;
            this.consultas = false;
            this.visitas = false;
            this.cantVisitas = -1;
            this.exAptitud = false;
            this.cantExAptitud = -1;
            this.fechaAlta = string.Empty;
            this.fechaAlta = string.Empty;
            this.activo = string.Empty;
            this.blnEmpresaPrincipal = false;

        }


        #region Getters&Setters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ActividadPrincipal
        {
            get { return actividadPrincipal; }
            set { actividadPrincipal = value; }
        }

        public bool Consultas
        {
            get { return consultas; }
            set { consultas = value; }
        }

        public bool ExAptitud
        {
            get { return exAptitud; }
            set { exAptitud = value; }
        }

        public int CantExAptitud
        {
            get { return cantExAptitud; }
            set { cantExAptitud = value; }
        }

        public int CantVisitas
        {
            get { return cantVisitas; }
            set { cantVisitas = value; }
        }

        public string UltMesFact
        {
            get { return ultMesFact; }
            set { ultMesFact = value; }
        }

        public bool Visitas
        {
            get { return visitas; }
            set { visitas = value; }
        }

        public string Area2
        {
            get { return area2; }
            set { area2 = value; }
        }

        public string UltAnioFact
        {
            get { return ultAnioFact; }
            set { ultAnioFact = value; }
        }

        public string ApeNom3
        {
            get { return apeNom3; }
            set { apeNom3 = value; }
        }

        public string Area3
        {
            get { return area3; }
            set { area3 = value; }
        }

        public decimal IntMora
        {
            get { return intMora; }
            set { intMora = value; }
        }

        public string ApeNom2
        {
            get { return apeNom2; }
            set { apeNom2 = value; }
        }

        public string ApeNom1
        {
            get { return apeNom1; }
            set { apeNom1 = value; }
        }

        public string Area1
        {
            get { return area1; }
            set { area1 = value; }
        }

        public string TipoContrato
        {
            get { return tipoContrato; }
            set { tipoContrato = value; }
        }

        public System.IO.MemoryStream Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        public int CantPersonal
        {
            get { return cantPersonal; }
            set { cantPersonal = value; }
        }

        public Guid Art
        {
            get { return art; }
            set { art = value; }
        }

        public string TipoEntidad
        {
            get { return tipoEntidad; }
            set { tipoEntidad = value; }
        }

        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public string NombreFantasia
        {
            get { return nombreFantasia; }
            set { nombreFantasia = value; }
        }

        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }

        public string NumeroDocumento
        {
            get { return numeroDocumento; }
            set { numeroDocumento = value; }
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

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public string CondicionVenta
        {
            get { return condicionVenta; }
            set { condicionVenta = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public string Telefono1
        {
            get { return telefono1; }
            set { telefono1 = value; }
        }

        public string Telefono2
        {
            get { return telefono2; }
            set { telefono2 = value; }
        }

        public string Telefono3
        {
            get { return telefono3; }
            set { telefono3 = value; }
        }

        public string Celular1
        {
            get { return celular1; }
            set { celular1 = value; }
        }

        public string Celular2
        {
            get { return celular2; }
            set { celular2 = value; }
        }

        public string Celular3
        {
            get { return celular3; }
            set { celular3 = value; }
        }

        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }

        public string Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string PaginaWeb
        {
            get { return paginaWeb; }
            set { paginaWeb = value; }
        }

        public int ListaPrecios
        {
            get { return listaPrecios; }
            set { listaPrecios = value; }
        }

        public bool ModifConFact
        {
            get { return modifConFact; }
            set { modifConFact = value; }
        }

        public string DiasYHorariosPago
        {
            get { return diasYHorariosPago; }
            set { diasYHorariosPago = value; }
        }

        public decimal ImpAbono
        {
            get { return impAbono; }
            set { impAbono = value; }
        }

        public bool EmpresaPrincipal
        {
            get
            {
                return blnEmpresaPrincipal;
            }
            set
            {
                blnEmpresaPrincipal = value;
            }
        }

	    #endregion 
    }
}
