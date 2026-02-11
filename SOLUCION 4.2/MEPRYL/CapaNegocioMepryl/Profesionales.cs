using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaNegocioMepryl
{
    public class Profesionales
    {
        CapaDatosMepryl.Profesional profesionales;

        public Profesionales()
        {
            profesionales = new CapaDatosMepryl.Profesional();
        }

        public DataTable cargarProfesionales()
        {
            return profesionales.cargarProfesionales();
        }

        public Entidades.Profesional cargarProfesional(Guid id)
        {
            return profesionales.cargarProfesional(id);
        }

        public Entidades.Resultado nuevoProfesional(Entidades.Profesional p)
        {
            return profesionales.nuevoProfesional(p);
        }

        public Entidades.Resultado editarProfesional(Entidades.Profesional p)
        {
            return profesionales.editarProfesional(p);
        }

        public Entidades.Resultado eliminarProfesional(object id)
        {
            return profesionales.eliminarProfesional(id);
        }

        public DataTable cargarProfesionalesReducido()
        {
            return profesionales.cargarProfesionalesReducido();
        }

        public void ActualizaProfesionalActivo(string strId, bool blnActivo)
        {
            profesionales.ActualizaProfesionalActivo(strId, blnActivo);
        }

        public DataTable FiltrarProfesional(string strApellido)
        {
            return profesionales.FiltrarProfesional(strApellido);
        }

        public void ActualizaBasicaPaciente(Entidades.PacienteLaboral paciente)
        {
            profesionales.ActualizaBasicaPaciente(paciente);
        }

        public void ActualizaProfesionalTieneHorario(string strId, bool blnActivo)
        {
            profesionales.ActualizaProfesionalTieneHorario(strId, blnActivo);
        }
    }
}
