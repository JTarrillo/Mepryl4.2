using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class PrecioEmpresa
    {
        private CapaDatosMepryl.PrecioEmpresaDatos precioEmpresaDatos;

        public PrecioEmpresa()
        {
            precioEmpresaDatos = new CapaDatosMepryl.PrecioEmpresaDatos();
        }

        public DataTable ListarPreciosEmpresaAnio(int anio)
        {
            return precioEmpresaDatos.ListarPreciosEmpresaAnio(anio);
        }

        public void GuardarPreciosEmpresa(DataTable dtDatos, int mes, int anio)
        {
            precioEmpresaDatos.GuardarPreciosEmpresa(dtDatos, mes, anio);
        }

        public void GuardarPreciosEmpresaAnio(int anio, DataTable dtDatos)
        {
            precioEmpresaDatos.GuardarPreciosEmpresaAnio(anio, dtDatos);
        }

        public void CopiarPrecios(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            precioEmpresaDatos.CopiarPrecios(mesOrigen, anioOrigen, mesDestino, anioDestino);
        }

        public void AplicarVariacion(int mes, int anio, decimal porcentaje)
        {
            precioEmpresaDatos.AplicarVariacion(mes, anio, porcentaje);
        }

        public DataTable ListarCoeficientesAnio(int anio)
        {
            return precioEmpresaDatos.ListarCoeficientesAnio(anio);
        }

        public void GuardarCoeficientesAnio(int anio, decimal[] coeficientes)
        {
            precioEmpresaDatos.GuardarCoeficientesAnio(anio, coeficientes);
        }
    }
}