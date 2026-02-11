using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Paciente : EntidadBase
    {
        private PacienteTipo _pacienteTipo;
        public PacienteTipo pacienteTipo
        {
            get
            {
                if (_pacienteTipo == null)
                    _pacienteTipo = new PacienteTipo("PacienteTipo"); //

                return _pacienteTipo;
            }
            set
            {
                _pacienteTipo = value;
            }
        }

        private Empresa _empresa;
        public Empresa empresa
        {
            get
            {
                if (_empresa == null)
                    _empresa = new Empresa("Empresa");

                return _empresa;
            }
            set
            {
                _empresa = value;
            }
        }


        public string apellido = "";
        public string nombres = "";
        public Guid ligaID = new Guid(Utilidades.ID_VACIO);
        public Guid clubID = new Guid(Utilidades.ID_VACIO);
        public string empresaTarea = "";
        public string dni = "";
        public DateTime fechaNacimiento = DateTime.Now;
        public string telefonos = "";
        public string celular = "";
        public string observaciones = "";
        public DateTime fechaUltimoExamen;
        public int hizoPlacaID = 0;

        public Paciente(string entidadNom)
            : base(entidadNom)
        { }

        public Paciente(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
