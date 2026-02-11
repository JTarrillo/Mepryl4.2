using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Consultorio
    {
        private Guid idConsultorio;
        private DateTime fechaHora;
        private string lugarAtencion;
        private Guid idMotivo;
        private Guid idEstadoAtencion;
        private Guid idPatologia;
        private string diagnostico;
        private Guid idCondicionLaboral;
        private string fechaAltaCitacion;
        private Guid idMedico;
        private int facturaPrestacion;
        private Guid idPaciente;
        private string paciente;
        private string identificador;
        private string empresa;
        private string tarea;
        private string dni;
        private Guid idEmpresa; //GRV


        public Consultorio()
        {
            this.idConsultorio = Guid.Empty;
            this.fechaHora = DateTime.Today;
            this.lugarAtencion = string.Empty;
            this.idMotivo = Guid.Empty;
            this.idEstadoAtencion = Guid.Empty;
            this.idPatologia = Guid.Empty;
            this.diagnostico = string.Empty;
            this.idCondicionLaboral = Guid.Empty;
            this.fechaAltaCitacion = string.Empty;
            this.idMedico = Guid.Empty;
            this.facturaPrestacion = -1;
            this.idPaciente = Guid.Empty;
            this.paciente = string.Empty;
            this.identificador = string.Empty;
            this.tarea = string.Empty;
            this.empresa = string.Empty;
            this.dni = string.Empty;
            this.idEmpresa = Guid.Empty;
        }


        #region Getters&Setters

        public string Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        public Guid IdConsultorio
        {
            get { return idConsultorio; }
            set { idConsultorio = value; }
        }

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }


        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }


        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public string LugarAtencion
        {
            get { return lugarAtencion; }
            set { lugarAtencion = value; }
        }

        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }


        public int FacturaPrestacion
        {
            get { return facturaPrestacion; }
            set { facturaPrestacion = value; }
        }

        public Guid IdMedico
        {
            get { return idMedico; }
            set { idMedico = value; }
        }

        public string FechaAltaCitacion
        {
            get { return fechaAltaCitacion; }
            set { fechaAltaCitacion = value; }
        }

        public Guid IdCondicionLaboral
        {
            get { return idCondicionLaboral; }
            set { idCondicionLaboral = value; }
        }

        public Guid IdPatologia
        {
            get { return idPatologia; }
            set { idPatologia = value; }
        }

        public Guid IdEstadoAtencion
        {
            get { return idEstadoAtencion; }
            set { idEstadoAtencion = value; }
        }

        public Guid IdMotivo
        {
            get { return idMotivo; }
            set { idMotivo = value; }
        }

        public Guid IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public Guid IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }

        #endregion



    }
}
