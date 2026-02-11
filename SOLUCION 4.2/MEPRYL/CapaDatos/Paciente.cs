using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;
using System.Data;

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
        public string club = "";
        public string empresaTarea = "";
        public string dni = "";
        public DateTime fechaNacimiento = DateTime.Now;
        public string telefonos = "";
        public string celular = "";
        public string observaciones = "";
        public DateTime fechaUltimoExamen;
        public int hizoPlacaID = 0;
        public Guid nacionalidad = Guid.Empty;
        public Guid localidad = Guid.Empty;
        public string direccion = "";
        //public string Email = ""; // GRV - Modificado

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
