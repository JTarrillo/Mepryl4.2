using System;//
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Paciente : CapaNegocioBase.EntidadBase
    {
        private PacienteTipo _pacienteTipo;
        public PacienteTipo pacienteTipo
        {
            get
            {
                if (_pacienteTipo == null)
                    _pacienteTipo = new PacienteTipo();

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
                    _empresa = new Empresa();

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

        public Paciente()
        { }

        public Paciente(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }




        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Paciente datPaciente = new CapaDatos.Paciente(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datPaciente;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datPaciente = (CapaDatos.Paciente)destino;

                origen = null;
                destino = null;
                /*************************/

                //Copia el objeto Empresa
                datPaciente.empresa = (CapaDatos.Empresa)(new CapaDatos.EmpresaFactory(new Configuracion(), "Empresa")).getById(this.empresa.id);
                datPaciente.pacienteTipo = (CapaDatos.PacienteTipo)(new CapaDatos.PacienteTipoFactory(new Configuracion(), "PacienteTipo")).getById(this.pacienteTipo.id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datPaciente;
        }
    }
}