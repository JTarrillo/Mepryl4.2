using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;

namespace CapaNegocioMepryl
{
    public class MesaEntrada
    {
        private CapaDatosMepryl.MesaEntrada mesaEntrada;

        public MesaEntrada()
        {
            mesaEntrada = new CapaDatosMepryl.MesaEntrada();
        }

        public DataTable cargarTiposDeExamen(string idMotivoConsulta)
        {
            return mesaEntrada.cargarTiposDeExamen(idMotivoConsulta);
        }

        public DataTable cargarTiposDeExamenBuscar(string strBuscar)
        {
            return mesaEntrada.cargarTiposDeExamenBuscar(strBuscar);
        }

        public void ActualizaTipoExamenIDConsulta(string IdConsulta, string IdEspecialidad)
        {
            mesaEntrada.ActualizaTipoExamenIDConsulta(IdConsulta, IdEspecialidad);
        }

        public void ActualizaIdentificadorConsulta(string IdConsulta, string Tipo, string NroIdentificador)
        {
            mesaEntrada.ActualizaIdentificadorConsulta(IdConsulta, Tipo, NroIdentificador);
        }

        public void EliminaIdentificadorConsulta(string IdConsulta)
        {
            mesaEntrada.EliminaIdentificadorConsulta(IdConsulta);
        }

        public DataTable cargarMesaEntrada()
        {
            return mesaEntrada.cargarMesaEntrada();
        }

        public DataTable cargarTurnosSegunMotivoDeConsulta(string idMotivo)
        {
            return mesaEntrada.cargarTunosSegunMotivoDeConsulta(idMotivo);
        }

        public Entidades.MesaEntrada cargarInformacionConsulta(Guid idConsulta)
        {
            return mesaEntrada.cargarInformacionConsulta(idConsulta);
        }

        public Entidades.Resultado verificarIngresoTurno(Guid idTurno)
        {
            return mesaEntrada.verificarIngresoTurno(idTurno);
        }

        public char verificarTipoPaciente(Guid idPaciente)
        {
            return mesaEntrada.verificarTipoPaciente(idPaciente);
        }

        public DataTable cargarParametrosReporteExClinico(string idConsulta)
        {
            return mesaEntrada.cargarParametrosReporteExClinico(idConsulta);
        }

        public DataTable cargarParametrosReporteHojaRuta(string idConsulta)
        {
            return mesaEntrada.cargarParametrosReporteHojaRuta(idConsulta);
        }

        public void actualizarClubPorTipoExamen(string idConsulta, string idPaciente)
        {
            mesaEntrada.actualizarClubPorTipoExamen(idConsulta, idPaciente);
        }

        public void actualizarEmpresaPorTipoExamen(string idConsulta, string idPaciente, string idEmpresa)
        {
            mesaEntrada.actualizarEmpresaPorTipoExamen(idConsulta, idPaciente, idEmpresa);
        }

        public string ObtenerDNI(string strIdPaciente)
        {
            return mesaEntrada.ObtenerDNI(strIdPaciente);
        }

        public DataTable exportarMesaEntrada(DateTime dtDesde, DateTime dtHasta)
        {
            return mesaEntrada.exportarMesaEntrada(dtDesde, dtHasta);
        }
    }
}
