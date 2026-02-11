using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class Ventanilla
    {
        private CapaDatosMepryl.Ventanilla ventanilla;

        public Ventanilla()
        {
            ventanilla = new CapaDatosMepryl.Ventanilla();
        }

        public DataTable cargar(DateTime desde, DateTime hasta)
        {
            return ventanilla.cargar(desde, hasta);
        }

        public DataTable cargarConFiltro(DateTime desde, DateTime hasta, string filtro)
        {
            return ventanilla.cargarFiltrado(desde, hasta, filtro);
        }

        public char verificarTipoPaciente(Guid idPaciente)
        {
            return ventanilla.verificarTipoPaciente(idPaciente);
        }

        public void actualizarClubesPorTipoExamenSegunTurno(Guid idTurno, Guid idPaciente)
        {
            ventanilla.actualizarClubesPorTipoExamenSegunTurno(idTurno, idPaciente);
        }

        public void actualizarPresente(Guid idTurno, bool valor)
        {
            ventanilla.actualizarPresente(idTurno, valor);
        }

        public void actualizarAbono(Guid idTurno, bool valor)
        {
            ventanilla.actualizarAbono(idTurno, valor);
        }

        public void registrarIngreso(Guid idTurno)
        {
            ventanilla.registrarIngreso(idTurno);
        }

        public char verificarTipoTurno(Guid idTurno)
        {
            return ventanilla.verificarTipoTurno(idTurno);
        }

        public Entidades.Resultado nuevoTurnoPacientePreventiva(string idPaciente, string idTurno)
        {
            return ventanilla.nuevoTurnoPacientePreventiva(idPaciente, idTurno);
        }

        public Entidades.Resultado nuevoTurnoPacienteLaboral(string idPaciente, string idTurno, string idEmpresa)
        {
            return ventanilla.nuevoTurnoPacienteLaboral(idPaciente, idTurno, idEmpresa);
        }
    }
}
