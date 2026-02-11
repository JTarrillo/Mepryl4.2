using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using Entidades;
using System.Data;

namespace CapaNegocioMepryl
{
    public class Nacionalidades
    {
        private CapaDatosMepryl.Nacionalidades nacionalidades;

        public Nacionalidades()
        {
            nacionalidades = new CapaDatosMepryl.Nacionalidades();
        }

        public DataTable cargarNacionalidades()
        {
            return nacionalidades.cargarNacionalidades();
        }

        public bool verificarNacionalidadAsignada(string id)
        {
            return nacionalidades.verificarNacionalidadAsignada(id);
        }

        public Entidades.Resultado eliminar(string id)
        {
            return nacionalidades.eliminar(id);
        }

        public Entidades.Resultado guardar(string descripcion)
        {
            return nacionalidades.guardarNacionalidad(descripcion);
        }

        public Entidades.Resultado editar(string id, string descripcion)
        {
            return nacionalidades.editarNacionalidad(id, descripcion);
        }
    }
}
