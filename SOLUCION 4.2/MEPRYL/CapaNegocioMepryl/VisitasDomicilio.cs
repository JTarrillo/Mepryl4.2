using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{
    public class VisitasDomicilio
    {
        private CapaDatosMepryl.VisitasDomicilio visitas;

        public VisitasDomicilio()
        {
            visitas = new CapaDatosMepryl.VisitasDomicilio();
        }

        public DataTable cargarEmpresas(string filtro)
        {
            return visitas.cargarEmpresas(filtro);
        }

        public DataTable cargarLocalidad(string filtro)
        {
            return visitas.cargarLocalidad(filtro);
        }

        public Entidades.Resultado buscarDni(string dni, string idEmpresa)
        {
            return visitas.buscarDni(dni,idEmpresa);
        }

        public void cambiarEmpresaDePaciente(Guid idPaciente, Guid idEmpresa)
        {
            visitas.cambiarEmpresaDePaciente(idPaciente, idEmpresa);
        }

        public Entidades.VisitasDomicilio inicializarVisita(Guid idPaciente)
        {
            return visitas.inicializarVisita(idPaciente);
        }

        public DataTable cargarMotivoConsulta()
        {
            return visitas.cargarMotivoConsulta();
        }

        public DataTable cargarEstadoAtencion()
        {
            return visitas.cargarEstadoAtencion();
        }

        public DataTable cargarMedico()
        {
            return visitas.cargarMedico();
        }

        public Entidades.Resultado verificarDomicilio(Entidades.VisitasDomicilio entidad)
        {
            return visitas.verificarDomicilio(entidad);
        }

        public void actualizarDomicilioPaciente(Entidades.VisitasDomicilio entidad)
        {
            visitas.actualizarDomicilioPaciente(entidad);
        }

        public Entidades.Resultado guardarVisita(Entidades.VisitasDomicilio entidad)
        {
            return visitas.guardarVisita(entidad);
        }

        public DataTable cargarVisitasPendientes()
        {
            return visitas.cargarVisitasPendientes();
        }

        public Entidades.VisitasDomicilio cargarVisita(Guid idVisita)
        {
            return visitas.cargarVisita(idVisita);
        }

        public DataTable cargarParametrosReporteVisita(string idVisita)
        {
            return visitas.cargarParametrosReporte(idVisita);
        }

        public DataTable cargarDataSourceVisita()
        {
            return visitas.cargarDataSource();
        }

        public void eliminarVisita(string idVisita)
        {
            visitas.eliminarVisita(idVisita);
        }

        public void actualizarEnvio(string idVisita)
        {
            visitas.actualizarEnvio(idVisita);
        }
    }
}
