using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using CapaDatosMepryl;
using Entidades;
using System.Data;

namespace CapaNegocioMepryl
{
    public class Examen
    {
        private CapaDatosMepryl.Laboral laboral;
        public Examen()
        {
            laboral = new Laboral();
        }

        public DataTable consultarItemsPorExamen(string idConsulta)
        {
            return laboral.consultarItemsPorTipoExamen(idConsulta);
        }

        public Resultado guardarExamen(ExamenLaboral examen)
        {
            return laboral.updateExamen(examen);
        }

        public Entidades.ExamenLaboral cargarExamen(string id)
        {
            return laboral.cargarExamen(id);
        }

        public DataTable cargarProfesionales()
        {
            return laboral.cargarProfesionales();
        }

        public DataTable cargarDictamenes()
        {
            return laboral.cargarDictamenes();
        }

        public DataTable cargarParametrosExamen(string idExamen, bool oliv)
        {
            return laboral.cargarParametrosExamen(idExamen, oliv);
        }

        public DataTable cargarDataSourceExamen(byte[] i, string tipo)
        {
            return laboral.cargarDataSourceExamen(i,tipo);
        }

        public string cargarIdTipoExamen(string idConsultaLaboral)
        {
            return laboral.getIdTipoExamen(idConsultaLaboral);
        }

        public List<string> cargarMailsEmpresaExamenLaboral(string idExamenLaboral)
        {
            return laboral.cargarMailsEmpresaExamenLaboral(idExamenLaboral);
        }

        public DataTable cargarParametrosLaboratorio(string idExamenLaboratorio, sbyte tipoReporte)
        {
            return laboral.cargarParametrosLaboratorio(idExamenLaboratorio, tipoReporte);
        }

        public string IDExamenLaboral(string Fecha, string Identificador)
        {
            return laboral.IDExamenLaboral(Fecha, Identificador);
        }

        public bool ActualizarExamenLaboral(string Fecha, string Identificador, List<string> valores)
        {
            return laboral.ActualizarExamenLaboral(Fecha, Identificador, valores);
        }

        public DataTable ComprobarEstudioPorExamen(string idTipoExamen)
        {
            return laboral.ComprobarEstudioPorExamen(idTipoExamen);
        }
    }
}
