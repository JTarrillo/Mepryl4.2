using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class CondicionLaboral
    {
        CapaDatosMepryl.CondicionLaboral datosCondLab;

        public CondicionLaboral()
        {
            datosCondLab = new CapaDatosMepryl.CondicionLaboral();
        }

        public DataTable cargarCondiciones(string lugarAtencion)
        {
            return datosCondLab.cargarCondiciones(lugarAtencion);
        }

        public Entidades.CondicionLaboral cargarCondicionSeleccionada(string idCondicion)
        {
            return datosCondLab.cargarCondicion(idCondicion);
        }

        public int proximoCodigo(string lugarAtencion)
        {
            return datosCondLab.getProximoCodigo(lugarAtencion);
        }

        public Entidades.Resultado eliminar(string id)
        {
            return datosCondLab.deleteCondicion(id);
        }

        public Entidades.Resultado nuevaCondicion(Entidades.CondicionLaboral entCond)
        {
            return datosCondLab.insertCondicion(entCond);
        }

        public Entidades.Resultado editarCondicion(Entidades.CondicionLaboral entCond)
        {
            return datosCondLab.updateCondicion(entCond);
        }

          

    }
}
