using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocioMepryl
{
    public class PrecioPublico
    {
        private CapaDatosMepryl.PrecioPublico precioPublico;

        public PrecioPublico()
        {
            precioPublico = new CapaDatosMepryl.PrecioPublico();
        }

        public DataTable ListarEspecialidadesHijas()
        {
            return precioPublico.ListarEspecialidadesHijas();
        }

        public DataTable ListarPreciosPublico(int mes, int anio)
        {
            return precioPublico.ListarPreciosPublico(mes, anio);
        }

        public void GuardarPreciosPublico(int mes, int anio, DataTable dtDatos)
        {
            precioPublico.GuardarPreciosPublico(mes, anio, dtDatos);
        }

        public void CopiarPrecios(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            precioPublico.CopiarPrecios(mesOrigen, anioOrigen, mesDestino, anioDestino);
        }

        public void AplicarVariacion(int mes, int anio, decimal porcentaje)
        {
            precioPublico.AplicarVariacion(mes, anio, porcentaje);
        }

        public void EliminarPreciosMes(int mes, int anio)
        {
            precioPublico.EliminarPreciosMes(mes, anio);
        }

        public bool ExistenPrecios(int mes, int anio)
        {
            return precioPublico.ExistenPrecios(mes, anio);
        }

        public decimal ObtenerCoeficiente(int mes, int anio)
        {
            return precioPublico.ObtenerCoeficiente(mes, anio);
        }

        public void GuardarCoeficiente(int mes, int anio, decimal coeficiente)
        {
            precioPublico.GuardarCoeficiente(mes, anio, coeficiente);
        }

        public DataTable ListarPreciosPublicoAnio(int anio)
        {
            return precioPublico.ListarPreciosPublicoAnio(anio);
        }

        public DataTable ListarCoeficientesAnio(int anio)
        {
            return precioPublico.ListarCoeficientesAnio(anio);
        }

        public void GuardarCoeficientesAnio(int anio, decimal[] coeficientes)
        {
            precioPublico.GuardarCoeficientesAnio(anio, coeficientes);
        }

        public void GuardarPreciosPublicoAnio(int anio, DataTable dtDatos)
        {
            precioPublico.GuardarPreciosPublicoAnio(anio, dtDatos);
        }

        public bool ExistenPreciosAnio(int anio)
        {
            return precioPublico.ExistenPreciosAnio(anio);
        }

        public DataTable ListarConfigEspecialidades()
        {
            return precioPublico.ListarConfigEspecialidades();
        }

        public void GuardarConfigEspecialidades(DataTable dtDatos)
        {
            precioPublico.GuardarConfigEspecialidades(dtDatos);
        }
    }
}
