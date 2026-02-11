using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatosMepryl;
using System.ComponentModel;
using Entidades;

namespace CapaNegocioMepryl
{
    public class Empresa
    {
        private CapaDatosMepryl.Empresa empresa;

        public Empresa()
        {
            empresa = new CapaDatosMepryl.Empresa();
        }

        public Entidades.Empresa cargarDatos(string id)
        {
            return empresa.cargarEmpresa(id);
        }

        public Entidades.Resultado nuevaEmpresa(Entidades.Empresa e)
        {
            return empresa.alta(e);
        }

        public Entidades.Resultado editarEmpresa(Entidades.Empresa e)
        {
            return empresa.modificacion(e);
        }

        public Entidades.Resultado eliminarEmpresa(object idEmpresa)
        {
            return empresa.baja(idEmpresa.ToString());
        }

        public DataTable cargarEmpresas()
        {
            return empresa.cargarEmpresas();
        }

        public bool tieneExamenesRealizados(object idEmpresa)
        {
            return empresa.tieneExamenesRealizados(idEmpresa);
        }

        public DataTable cargarEmpresasConFiltro(string campo, string filtro)
        {
            return empresa.cargarEmpresasConFiltro(campo,filtro);
        }

        public DataTable listarImpuestos()
        {
            return empresa.listarImpuestos();
        }

        public void InsertarIVA(string strNombre, string strValor)
        {
            empresa.InsertarIVA(strNombre, strValor);
        }

        public void ActualizarIVA(string strId, string strNombre, string strValor)
        {
            empresa.ActualizarIVA(strId, strNombre, strValor);
        }
    }
}
