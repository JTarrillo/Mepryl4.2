using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;

namespace CapaNegocioMepryl
{
    public class Turno
    {
        private CapaDatosMepryl.Turno turno;

        public Turno()
        {
            turno = new CapaDatosMepryl.Turno();
        }

        public DataTable cargarTiposDeExamen()
        {
            return turno.cargarTiposDeExamen();
        }

        public DataTable cargarTurnosConFiltro(string filtro)
        {
            return turno.cargarTurnosConFiltro(filtro);
        }

        public DataTable cargarTurnos(Guid tipoExamen, DateTime fecha, string hora, string estado)
        {
            return turno.cargarTurnos(tipoExamen, fecha, hora, estado);
        }

        public char verificarTipoPaciente(Guid idPaciente)
        {
            return turno.verificarTipoPaciente(idPaciente);
        }

        public Entidades.TurnoPreventiva cargarTurnoPacientePreventiva(Guid idTurno)
        {
            return turno.cargarTurnoPacientePreventiva(idTurno);
        }

        public Entidades.TurnoLaboral cargarTurnoPacienteLaboral(Guid idTurno)
        {
            return turno.cargarTurnoPacienteLaboral(idTurno);
        }

        public char verificarTipoTurno(Guid idTurno)
        {
            return turno.verificarTipoTurno(idTurno);
        }

        public Entidades.TurnoPreventiva nuevoTurnoPacientePreventiva(string idPaciente, string idTurno)
        {
            return turno.nuevoTurnoPacientePreventiva(idPaciente, idTurno);
        }

        public Entidades.Resultado modificarTurnoPreventiva(Entidades.TurnoPreventiva entidad)
        {
            return turno.modificarTurnoPreventiva(entidad);
        }

        public Entidades.Resultado modificarTurnoLaboral(Entidades.TurnoLaboral entidad)
        {
            return turno.modificarTurnoLaboral(entidad);
        }

        public Entidades.TurnoLaboral nuevoTurnoPacienteLaboral(string idPaciente, string idTurno, string idEmpresa)
        {
            return turno.nuevoTurnoPacienteLaboral(idPaciente, idTurno, idEmpresa);
        }

        public Entidades.Resultado nuevoTurnoLaboral(Entidades.TurnoLaboral entidad)
        {
            return turno.generarNuevoTurnoPacienteLaboral(entidad);
        }

        public Entidades.Resultado nuevoTurnoPreventiva(Entidades.TurnoPreventiva entidad)
        {
            return turno.generarNuevoTurnoPacientePreventiva(entidad);
        }

        public Entidades.Resultado liberarTurnoPreventiva(Entidades.TurnoPreventiva entidad)
        {
            return turno.liberarTurnoPreventiva(entidad);
        }

        public Entidades.Resultado liberarTurnoLaboral(Entidades.TurnoLaboral entidad)
        {
            return turno.liberarTurnoLaboral(entidad);
        }

        public void habilitarTurno(Guid idTurno)
        {
            turno.habilitarTurno(idTurno);
        }

        public void inhabilitarTurno(Guid idTurno)
        {
            turno.inhabilitarTurno(idTurno);
        }

        public Entidades.TurnoPreventiva recargarDatoPacientePreventiva(string idPaciente)
        {
            return turno.recargarDatoPacientePreventiva(idPaciente);
        }

        public Entidades.TurnoLaboral recargarDatoPacienteLaboral(string idPaciente, string idEmpresa)
        {
            return turno.recargarDatoPacienteLaboral(idPaciente, idEmpresa);
        }

        public void reservarTurno(Guid idTurno, string destinatario)
        {
            //turno.reservarTurno(idTurno, idEspecialidad, destinatario);
            turno.reservarTurno(idTurno, destinatario);
        }

        public void liberarReservaTurno(Guid idTurno)
        {
            turno.liberarReservaTurno(idTurno);
        }

        public bool VerificaTurnoConsultorio(Guid PacienteID, DateTime FechaReCitado)
        {
            return turno.VerificaTurnoConsultorio(PacienteID, FechaReCitado);
        }

        public DataTable PacienteTieneTurnoAsignado(DateTime fecha, string idPaciente, string idEmpresa = null)

        {
            return turno.PacienteTieneTurnoAsignado(fecha, idPaciente, idEmpresa);
        }

        public DataTable VerificaIDTurnoLibre(string strIdTurno, DateTime Fecha, string IdPaciente)
        {
            return turno.VerificaIDTurnoLibre(strIdTurno, Fecha, IdPaciente);
        }

        public string NombreApellidoPaciente(string IdPaciente)
        {
            return turno.NombreApellidoPaciente(IdPaciente);
        }

        public string NombreUsuario(string IdUsuario)
        {
            return turno.NombreUsuario(IdUsuario);
        }

        public void EsInfantilInicial(string strTipoExamen)
        {
            turno.EsInfantilInicial(strTipoExamen);
        }

        public int TotalTurnosAsignados(DateTime Fecha)
        {
            return turno.TotalTurnosAsignados(Fecha);
        }

        public int TotalErgometrias(DateTime Fecha)
        {
            return turno.TotalErgometrias(Fecha);
        }

        public string ObtenerAlAzarIdErgometria(DateTime Fecha)
        {
            return turno.ObtenerAlAzarIdErgometria(Fecha);
        }

        public int TotalBuzos(DateTime Fecha)
        {
            return turno.TotalBuzos(Fecha);
        }

        public string TurnoReservado(string idTurno)
        {
            return turno.TurnoReservado(idTurno);
        }

        public bool ExisteTurnoFecha(string idProfesional)
        {
            return turno.ExisteTurnoFecha(idProfesional);
        }

        public bool TurnoTieneAsociadoExamen(string idTurno)
        {
            return turno.TurnoTieneAsociadoExamen(idTurno);
        }

        public bool MoverTurno(string strIdTurnoAntiguo, string strIdTurnoNuevo, string NombreEspecialidad)
        {
            return turno.MoverTurno(strIdTurnoAntiguo, strIdTurnoNuevo, NombreEspecialidad);
        }

        public string TipoConsulta(string IdTurno)
        {
            return turno.TipoConsulta(IdTurno);
        }
    }
}
