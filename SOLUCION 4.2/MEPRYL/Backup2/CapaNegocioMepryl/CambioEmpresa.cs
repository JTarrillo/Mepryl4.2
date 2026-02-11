using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{
    public class CambioEmpresa
    {
        private CapaDatosMepryl.CambioEmpresa cambioEmpresa;
        private CapaDatosMepryl.PacienteLaboral empresa;

        public CambioEmpresa()
        {
            cambioEmpresa = new CapaDatosMepryl.CambioEmpresa();
            empresa = new CapaDatosMepryl.PacienteLaboral();
        }

        public string obtenerEmpresaActual(string idTipoExamen)
        {
            return cambioEmpresa.obtenerEmpresaActual(idTipoExamen);
        }

        public string obtenerTareaActual(string idTipoExamen)
        {
            return cambioEmpresa.obtenerTareaActual(idTipoExamen);
        }

        public DataTable cargarEmpresas(string filtro)
        {
            return empresa.cargarEmpresas(filtro);
        }

        public Entidades.Resultado guardarCambio(string idTipoExamen, string idEmpresa, string tarea)
        {
            return cambioEmpresa.guardarCambio(idTipoExamen,idEmpresa,tarea);
        }
    }
}
