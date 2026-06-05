using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocioMepryl
{
    public class PrecioPromo
    {
        private CapaDatosMepryl.PrecioPromo precioPromo;

        public PrecioPromo()
        {
            precioPromo = new CapaDatosMepryl.PrecioPromo();
        }

        public DataTable ListarEspecialidadesHijas()
        {
            return precioPromo.ListarEspecialidadesHijas();
        }

        public DataTable ListarPreciosPublico(int mes, int anio)
        {
            return precioPromo.ListarPreciosPublico(mes, anio);
        }

        public void GuardarPreciosPublico(int mes, int anio, DataTable dtDatos)
        {
            precioPromo.GuardarPreciosPublico(mes, anio, dtDatos);
        }

        public void CopiarPrecios(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            precioPromo.CopiarPrecios(mesOrigen, anioOrigen, mesDestino, anioDestino);
        }

        public void AplicarVariacion(int mes, int anio, decimal porcentaje)
        {
            precioPromo.AplicarVariacion(mes, anio, porcentaje);
        }

        public void EliminarPreciosMes(int mes, int anio)
        {
            precioPromo.EliminarPreciosMes(mes, anio);
        }

        public bool ExistenPrecios(int mes, int anio)
        {
            return precioPromo.ExistenPrecios(mes, anio);
        }

        public decimal ObtenerCoeficiente(int mes, int anio)
        {
            return precioPromo.ObtenerCoeficiente(mes, anio);
        }

        public void GuardarCoeficiente(int mes, int anio, decimal coeficiente)
        {
            precioPromo.GuardarCoeficiente(mes, anio, coeficiente);
        }

        public DataTable ListarPreciosPublicoAnio(int anio)
        {
            return precioPromo.ListarPreciosPublicoAnio(anio);
        }

        public DataTable ListarCoeficientesAnio(int anio)
        {
            return precioPromo.ListarCoeficientesAnio(anio);
        }

        public void GuardarCoeficientesAnio(int anio, decimal[] coeficientes)
        {
            precioPromo.GuardarCoeficientesAnio(anio, coeficientes);
        }

        public void GuardarPreciosPublicoAnio(int anio, DataTable dtDatos)
        {
            precioPromo.GuardarPreciosPublicoAnio(anio, dtDatos);
        }

        public bool ExistenPreciosAnio(int anio)
        {
            return precioPromo.ExistenPreciosAnio(anio);
        }

        public DataTable ListarConfigEspecialidades()
        {
            return precioPromo.ListarConfigEspecialidades();
        }

        public void GuardarConfigEspecialidades(DataTable dtDatos)
        {
            precioPromo.GuardarConfigEspecialidades(dtDatos);
        }
    }
}
