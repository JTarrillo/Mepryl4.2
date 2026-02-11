using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{
    public class ListaPrecios
    {
        private CapaDatosMepryl.ListaPrecios listaPrecios;

        public ListaPrecios()
        {
            // Constructor
            listaPrecios = new CapaDatosMepryl.ListaPrecios();
        }

        public int InsertarNombreListaPrecios(string NombreLista)
        {
            return listaPrecios.InsertarNombreListaPrecios(NombreLista);
        }

        public void InsertarListaPreciosBase(int IdNombreLista, DataTable strDatos)
        {
            listaPrecios.InsertarListaPreciosBase(IdNombreLista, strDatos);
        }

        public DataTable ListarNombreListaPrecios()
        {
            return listaPrecios.ListarNombreListaPrecios();
        }

        public DataTable ObtenerListaPreciosDeEmpresa(string idEmpresa)
        {
            return listaPrecios.ObtenerListaPreciosDeEmpresa(idEmpresa);
        }

        public DataTable ListarListaPreciosBase()
        {
            return listaPrecios.ListarListaPreciosBase();
        }

        public DataTable ListarListaPreciosBase(int intIdNombreLista)
        {
            return listaPrecios.ListarListaPreciosBase(intIdNombreLista);
        }

        public DataTable ListarNombreListaPrecios(string strFiltro)
        {
            return listaPrecios.ListarNombreListaPrecios(strFiltro);
        }

        public void DeleteListaPreciosBase(int IdLista)
        {
            listaPrecios.DeleteListaPreciosBase(IdLista);
        }

        public void DeleteNombreListaPrecios(int IdNombreLista)
        {
            listaPrecios.DeleteNombreListaPrecios(IdNombreLista);
        }

        public bool VerificaNombreListaPrecios(string strNombreLista)
        {
            return listaPrecios.VerificaNombreListaPrecios(strNombreLista);
        }

        public DataTable ObtenerElementoParaAgregar(int codigo)
        {
            return listaPrecios.ObtenerElementoParaAgregar(codigo);
        }

    }
}
