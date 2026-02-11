using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;

namespace CapaNegocioMepryl
{
    public class LocalidadesYPrestaciones
    {
        private CapaDatosMepryl.LocalidadesYPrestaciones localidaesPrest;

        public LocalidadesYPrestaciones()
        {
            localidaesPrest = new CapaDatosMepryl.LocalidadesYPrestaciones();
        }

        public DataTable cargarLocalidadesYPrestaciones(string filtro)
        {
            return localidaesPrest.cargarLocalidadesYPrestaciones(filtro);
        }

        public DataTable cargarLocalidadesYPrestacionesFiltro(string filtroTipo, string filtroTexto)
        {
            return localidaesPrest.cargarLocalidadesYPrestacionesFiltro(filtroTipo, filtroTexto);
        }

        public Entidades.Resultado guardarNueva(Entidades.LocalidadPrestacion entidad)
        {
            return localidaesPrest.guardarNueva(entidad);
        }

        public Entidades.Resultado editar(Entidades.LocalidadPrestacion entidad)
        {
            return localidaesPrest.editar(entidad);
        }

        public bool verificarEliminar(string id, string tipo)
        {
            return localidaesPrest.verificarEliminar(id, tipo);
        }

        public Entidades.Resultado eliminar(string id)
        {
            return localidaesPrest.eliminar(id);
        }

        public DataTable cargarZonas()
        {
            return localidaesPrest.cargarZonas();
        }

        public DataTable cargarZonasSinNoAplica()
        {
            return localidaesPrest.cargarZonasSinNoAplica();
        }

        public bool verificarZonaAsignada(string idZona)
        {
            return localidaesPrest.verificarZonaAsignada(idZona);
        }

        public Entidades.Resultado eliminarZona(string idZona)
        {
            return localidaesPrest.eliminarZona(idZona);
        }

        public Entidades.Resultado guardarZona(string descripcion)
        {
            return localidaesPrest.guardarZona(descripcion);
        }

        public Entidades.Resultado editarZona(string id, string descripcion)
        {
            return localidaesPrest.editarZona(id, descripcion);
        }
    }
}
