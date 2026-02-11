using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class VisitasDomicilio
    {
        private Guid id;
        private DateTime fechaHora;
        private Guid idLugarAtencion;
        private Guid idMotivoConsulta;
        private Guid idEstadoAtencion;
        private Guid idPatologia;
        private string diagnostico;
        private Guid idCondicionLaboral;
        private DateTime fechaAltaCitacion;
        private Guid medico;
        private Guid idPaciente;
        private string domicilio;
        private string entreCalle1;
        private string entreCalle2;
        private Guid localidad;
        private string observaciones;
        private int domicilioTransitorio;
        private bool visitaEnviada;
        private bool visitaPendiente;
        private string paciente;
        private string dniPaciente;
        private string empresa;
        private string localidadDescripcion;
        private Guid idEmpresa;
        private string tarea;
        private string identificador;




        public VisitasDomicilio()
        {
            this.id = Guid.Empty;
            this.fechaHora = new DateTime(1800, 1, 1);
            this.idLugarAtencion = Guid.Empty;
            this.idMotivoConsulta = Guid.Empty;
            this.idEstadoAtencion = Guid.Empty;
            this.idPatologia = Guid.Empty;
            this.diagnostico = string.Empty;
            this.idCondicionLaboral = Guid.Empty;
            this.fechaAltaCitacion = new DateTime(1800, 1, 1);
            this.medico = Guid.Empty;
            this.idPaciente = Guid.Empty;
            this.domicilio = string.Empty;
            this.entreCalle1 = string.Empty;
            this.entreCalle2 = string.Empty;
            this.localidad = Guid.Empty;
            this.observaciones = string.Empty;
            this.domicilioTransitorio = -1;
            this.visitaEnviada = false;
            this.visitaPendiente = false;
            this.paciente = string.Empty;
            this.dniPaciente = string.Empty;
            this.empresa = string.Empty;
            this.localidadDescripcion = string.Empty;
            this.idEmpresa = Guid.Empty;
            this.tarea = string.Empty;
            this.identificador = string.Empty;

        }

        #region Getters&Setters

        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }

        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }


        public Guid IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public Guid IdLugarAtencion
        {
            get { return idLugarAtencion; }
            set { idLugarAtencion = value; }
        }

        public Guid IdMotivoConsulta
        {
            get { return idMotivoConsulta; }
            set { idMotivoConsulta = value; }
        }

        public Guid IdEstadoAtencion
        {
            get { return idEstadoAtencion; }
            set { idEstadoAtencion = value; }
        }

        public Guid IdPatologia
        {
            get { return idPatologia; }
            set { idPatologia = value; }
        }

        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        public Guid IdCondicionLaboral
        {
            get { return idCondicionLaboral; }
            set { idCondicionLaboral = value; }
        }

        public DateTime FechaAltaCitacion
        {
            get { return fechaAltaCitacion; }
            set { fechaAltaCitacion = value; }
        }

        public Guid Medico
        {
            get { return medico; }
            set { medico = value; }
        }

        public Guid IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
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

        public Guid Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public int DomicilioTransitorio
        {
            get { return domicilioTransitorio; }
            set { domicilioTransitorio = value; }
        }

        public bool VisitaEnviada
        {
            get { return visitaEnviada; }
            set { visitaEnviada = value; }
        }

        public bool VisitaPendiente
        {
            get { return visitaPendiente; }
            set { visitaPendiente = value; }
        }

        public string Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public string DniPaciente
        {
            get { return dniPaciente; }
            set { dniPaciente = value; }
        }

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public string LocalidadDescripcion
        {
            get { return localidadDescripcion; }
            set { localidadDescripcion = value; }
        }



        #endregion


    }
}
