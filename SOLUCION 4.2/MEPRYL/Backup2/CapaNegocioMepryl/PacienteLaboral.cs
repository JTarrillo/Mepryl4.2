using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class PacienteLaboral
    {
        private CapaDatosMepryl.PacienteLaboral pacienteLaboral;
        private CapaDatosMepryl.Laboral laboral;

        public PacienteLaboral()
        {
            pacienteLaboral = new CapaDatosMepryl.PacienteLaboral();
            laboral = new CapaDatosMepryl.Laboral();
        }

        public DataTable cargarDataGridBusqueda(string tipoBusqueda, string filtro, string idEmpresa)
        {
            return pacienteLaboral.cargarDataGridBusqueda(tipoBusqueda, filtro, idEmpresa);
        }

        public DataTable cargarDataGridLocalidad(string filtro)
        {
            return pacienteLaboral.cargarDataGridLocalidad(filtro);
        }

        public Entidades.PacienteLaboral leerDatosEntidad(string idPaciente,string idEmpresa)
        {
            return pacienteLaboral.leerDatosEntidad(idPaciente,idEmpresa);
        }

        public DataTable cargarNacionalidades()
        {
            return pacienteLaboral.cargarNacionalidades();
        }

        public Entidades.Resultado guardarDatosEntidadEdicion(Entidades.PacienteLaboral paciente)
        {
            return pacienteLaboral.guardarDatosEntidadEdicion(paciente);
        }

        public Entidades.Resultado verificarDNIIngresadoEnEmpresa(string dni, string idEmpresa)
        {
            return pacienteLaboral.verificarDNIIngresadoEnEmpresa(dni, idEmpresa);
        }

        public string obtenerIdPaciente(string dni)
        {
            return pacienteLaboral.obtenerIdPaciente(dni);
        }

        // GRV - Ramírez - Obtener el ID de empresa a la que pertenece un paciente
        public string obtenerIdEmpresaPaciente(string strIDpaciente)
        {
            return pacienteLaboral.obtenerIdEmpresaPaciente(strIDpaciente);
        }

        public Entidades.Resultado guardarDatosEntidadNueva(Entidades.PacienteLaboral paciente)
        {
            return pacienteLaboral.guardarDatosEntidadNueva(paciente);
        }

        public string cargarCuilRazonSocialEmpresa(string idEmpresa)
        {
            return pacienteLaboral.cargarCuilRazonSocialEmpresa(idEmpresa);
        }

        public string cargarIdConsultorioLaboral(string idTipoExamen)
        {
            return pacienteLaboral.cargarIdConsultorioLaboral(idTipoExamen);
        }

        public string cargarIdConsultaLaboral(string idTipoExamen)
        {
            return pacienteLaboral.cargarIdConsultaLaboral(idTipoExamen);
        }

        public string cargarIdExamenLaboral(string idTipoExamen)
        {
            return pacienteLaboral.cargarIdExamenLaboral(idTipoExamen);
        }

        public DataTable cargarDataSourceReporteHistoriaClinica()
        {
            return laboral.cargarDataSourceHistoriaClinica();
        }

        public DataTable cargarHistoriaClinicaReporte(string idPaciente, string idEmpresa, string desde, string hasta)
        {
            return pacienteLaboral.cargarHistoriaClinicaReporte(idPaciente, idEmpresa, desde, hasta);
        }

        public string obtenerDNIPaciente(string idPaciente)
        {
            return pacienteLaboral.obtenerDNIPaciente(idPaciente);
        }

        public DataTable BuscarPacienteLaboral(string Clave)
        {
            return pacienteLaboral.BuscarPacienteLaboral(Clave);
        }
    }
}
