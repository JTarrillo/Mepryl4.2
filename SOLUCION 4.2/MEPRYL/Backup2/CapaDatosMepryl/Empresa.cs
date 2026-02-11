using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunes;
using Entidades;
using System.Data;

namespace CapaDatosMepryl
{
    public class Empresa
    {
        public Empresa()
        {
        }

        public Entidades.Resultado alta(Entidades.Empresa e)
        {
            Entidades.Resultado resul = new Entidades.Resultado();
            try
            { 
                   List<string> listAdd = SQLConnector.generarListaParaProcedure("@razonSocial", "@nombreFantasia",
                    "@cuit", "@tipoDocumento", "@tipoContribuyente", "@direccion", "@codigoPostal", "@localidad", "@provincia",
                    "@tipoEntidad", "@art", "@actividadPrincipal", "@cantidadPersonal", "@paginaWeb", "@apeNom1", "@area1", "@telefono1",
                    "@celular1", "@mail1", "@apeNom2", "@area2", "@telefono2", "@celular2", "@mail2", "@apeNom3", "@area3", "@telefono3",
                    "@celular3", "@mail3", "@categoria", "@condVta", "@tipoContrato", "@listaPrecios", "@modifPrecioConFact", "@diaYHorarioPago", "@observaciones",
                    "@impAbono", "@intPorMora", "@consultas", "@visitas", "@cantVisitas", "@exAptitud", "@cantExAptitud", "@activa", "@logo");
                    SQLConnector.executeProcedure("sp_Empresa_Add", listAdd, convertirString(e.RazonSocial),
                    convertirString(e.NombreFantasia), convertirString(e.NumeroDocumento), convertirString(e.TipoDocumento),
                    convertirString(e.TipoContribuyente), convertirString(e.Direccion), convertirString(e.CodigoPostal),
                    convertirString(e.Localidad), convertirString(e.Provincia), convertirString(e.TipoEntidad),
                    convertirUnique(e.Art), convertirString(e.ActividadPrincipal), convertirInt(e.CantPersonal),
                    convertirString(e.PaginaWeb), convertirString(e.ApeNom1), convertirString(e.Area1),
                    convertirString(e.Telefono1), convertirString(e.Celular1), convertirString(e.Email1),
                    convertirString(e.ApeNom2), convertirString(e.Area2),
                    convertirString(e.Telefono2), convertirString(e.Celular2), convertirString(e.Email2),
                    convertirString(e.ApeNom3), convertirString(e.Area3),
                    convertirString(e.Telefono3), convertirString(e.Celular3), convertirString(e.Email3),
                    convertirString(e.Categoria), convertirString(e.CondicionVenta), convertirString(e.TipoContrato),
                    convertirUnique(e.ListaPrecios), convertirBit(e.ModifConFact), convertirString(e.DiasYHorariosPago),
                    convertirString(e.Observaciones), convertirDecimal(e.ImpAbono), convertirDecimal(e.IntMora),
                    convertirBit(e.Consultas), convertirBit(e.Visitas), convertirInt(e.CantVisitas), convertirBit(e.ExAptitud),
                    convertirInt(e.CantExAptitud), convertirString(e.Activo), e.Logo.GetBuffer());
    
                resul.Modo = 1;
                return resul;

            }
            catch (Exception ex)
            {
                resul.Modo = -1;
                resul.Mensaje = ex.ToString();
                return resul;
            }
        }

        public Entidades.Resultado modificacion(Entidades.Empresa e)
        {
            Entidades.Resultado resul = new Entidades.Resultado();
            try
            {
                List<string> listUpdate = SQLConnector.generarListaParaProcedure("@id","@razonSocial","@nombreFantasia",
                "@cuit","@tipoDocumento","@tipoContribuyente","@direccion","@codigoPostal","@localidad","@provincia",
                "@tipoEntidad","@art","@actividadPrincipal","@cantidadPersonal","@paginaWeb","@apeNom1","@area1","@telefono1",
                "@celular1","@mail1","@apeNom2","@area2","@telefono2","@celular2","@mail2","@apeNom3","@area3","@telefono3",
                "@celular3","@mail3","@categoria","@condVta","@tipoContrato","@listaPrecios","@modifPrecioConFact","@diaYHorarioPago","@observaciones",
                "@impAbono","@intPorMora","@consultas","@visitas","@cantVisitas","@exAptitud","@cantExAptitud","@activa","@logo");
                SQLConnector.executeProcedure("sp_Empresa_Update", listUpdate, e.Id, convertirString(e.RazonSocial),
                    convertirString(e.NombreFantasia), convertirString(e.NumeroDocumento), convertirString(e.TipoDocumento),
                    convertirString(e.TipoContribuyente), convertirString(e.Direccion), convertirString(e.CodigoPostal),
                    convertirString(e.Localidad), convertirString(e.Provincia), convertirString(e.TipoEntidad),
                    convertirUnique(e.Art), convertirString(e.ActividadPrincipal), convertirInt(e.CantPersonal),
                    convertirString(e.PaginaWeb), convertirString(e.ApeNom1), convertirString(e.Area1),
                    convertirString(e.Telefono1), convertirString(e.Celular1), convertirString(e.Email1),
                    convertirString(e.ApeNom2), convertirString(e.Area2),
                    convertirString(e.Telefono2), convertirString(e.Celular2), convertirString(e.Email2),
                    convertirString(e.ApeNom3), convertirString(e.Area3),
                    convertirString(e.Telefono3), convertirString(e.Celular3), convertirString(e.Email3),
                    convertirString(e.Categoria), convertirString(e.CondicionVenta), convertirString(e.TipoContrato),
                    convertirUnique(e.ListaPrecios), convertirBit(e.ModifConFact), convertirString(e.DiasYHorariosPago),
                    convertirString(e.Observaciones), convertirDecimal(e.ImpAbono), convertirDecimal(e.IntMora),
                    convertirBit(e.Consultas), convertirBit(e.Visitas), convertirInt(e.CantVisitas), convertirBit(e.ExAptitud),
                    convertirInt(e.CantExAptitud), convertirString(e.Activo), e.Logo.GetBuffer());
                resul.Modo = 1;
                return resul;

            }
            catch (Exception ex)
            {
                resul.Modo = -1;
                resul.Mensaje = ex.ToString();
                return resul;
            }
        }

        public bool tieneExamenesRealizados(object idEmpresa)
        {
            if (SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.empresaPorTipoDeExamen
            where idEmpresa = '" + idEmpresa + "'").Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private int convertirBit(bool valor)
        {
            if (valor) { return 1; }
            return 0;
        }

        private object convertirInt(int valor)
        {
            if (valor != -1) { return valor; }
            return null;
        }

        private object convertirUnique(Guid valor)
        {
            if (valor != Guid.Empty) { return valor; }
            return null;
        }

        private object convertirString(string valor)
        {
            if (valor != string.Empty) { return valor; }
            return null;
        }

        private object convertirDecimal(decimal valor)
        {
            if(valor != 0) { return valor; }
            return null;
        }

        public Entidades.Resultado baja(string id)
        {
            Entidades.Resultado resul = new Entidades.Resultado();
            try
            {
                List<string> listDelete = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_Empresa_Delete", listDelete, new Guid(id));
                List<string> listLimpiarEmpresa = SQLConnector.generarListaParaProcedure("@idEmpresa");
                SQLConnector.executeProcedure("sp_Paciente_LimpiarEmpresa", listLimpiarEmpresa, new Guid(id));
                resul.Modo = 1;
                return resul;
            }
            catch (Exception ex)
            {
                resul.Modo = -1;
                resul.Mensaje = ex.ToString();
                return resul;
            }

        }


        public Entidades.Empresa cargarEmpresa(string id)
        {         
            Entidades.Empresa retorno = new Entidades.Empresa();
            DataTable empresa = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Empresa where id = '" + id.ToString() + "'");
            if (empresa.Rows.Count > 0)
            {
                retorno.Id = new Guid(empresa.Rows[0][0].ToString());
                retorno.RazonSocial = empresa.Rows[0][1].ToString();
                retorno.NombreFantasia = empresa.Rows[0][2].ToString();
                retorno.NumeroDocumento = empresa.Rows[0][3].ToString();
                retorno.TipoDocumento = empresa.Rows[0][4].ToString();
                retorno.TipoContribuyente = empresa.Rows[0][5].ToString();
                retorno.Direccion = empresa.Rows[0][6].ToString();
                retorno.CodigoPostal = empresa.Rows[0][7].ToString();
                retorno.Localidad = empresa.Rows[0][8].ToString();
                retorno.Provincia = empresa.Rows[0][9].ToString();
                retorno.TipoEntidad = empresa.Rows[0][10].ToString();
                if (empresa.Rows[0][11].ToString() != string.Empty) { retorno.Art = new Guid(empresa.Rows[0][11].ToString()); }
                retorno.ActividadPrincipal = empresa.Rows[0][12].ToString();
                if (empresa.Rows[0][13].ToString() != string.Empty) { retorno.CantPersonal = Convert.ToInt16(empresa.Rows[0][13].ToString()); }
                retorno.PaginaWeb = empresa.Rows[0][14].ToString();
                retorno.ApeNom1 = empresa.Rows[0][15].ToString();
                retorno.Area1 = empresa.Rows[0][16].ToString();
                retorno.Telefono1 = empresa.Rows[0][17].ToString();
                retorno.Celular1 = empresa.Rows[0][18].ToString();
                retorno.Email1 = empresa.Rows[0][19].ToString();
                retorno.ApeNom2 = empresa.Rows[0][20].ToString();
                retorno.Area2 = empresa.Rows[0][21].ToString();
                retorno.Telefono2 = empresa.Rows[0][22].ToString();
                retorno.Celular2 = empresa.Rows[0][23].ToString();
                retorno.Email2 = empresa.Rows[0][24].ToString();
                retorno.ApeNom3 = empresa.Rows[0][25].ToString();
                retorno.Area3 = empresa.Rows[0][26].ToString();
                retorno.Telefono3 = empresa.Rows[0][27].ToString();
                retorno.Celular3 = empresa.Rows[0][28].ToString();
                retorno.Email3 = empresa.Rows[0][29].ToString();
                retorno.Categoria = empresa.Rows[0][30].ToString();
                retorno.CondicionVenta = empresa.Rows[0][31].ToString();
                retorno.TipoContrato = empresa.Rows[0][32].ToString();
                if (empresa.Rows[0][33].ToString() != string.Empty) { retorno.ListaPrecios = new Guid(empresa.Rows[0][33].ToString()); }
                retorno.ModifConFact = cargarDatoBool(empresa.Rows[0][34]);
                retorno.DiasYHorariosPago = empresa.Rows[0][35].ToString();
                retorno.Observaciones = empresa.Rows[0][36].ToString();
                if (empresa.Rows[0][37].ToString() != string.Empty) { retorno.ImpAbono = (decimal)empresa.Rows[0][37]; }
                if (empresa.Rows[0][38].ToString() != string.Empty) { retorno.IntMora = (decimal)empresa.Rows[0][38]; }
                if (empresa.Rows[0][39].ToString() != string.Empty) { retorno.UltMesFact = Convert.ToDateTime(empresa.Rows[0][39].ToString()).Month.ToString(); }
                if (empresa.Rows[0][39].ToString() != string.Empty) { retorno.UltAnioFact = Convert.ToDateTime(empresa.Rows[0][39].ToString()).Year.ToString(); }
                retorno.Consultas = cargarDatoBool(empresa.Rows[0][40]);
                retorno.Visitas = cargarDatoBool(empresa.Rows[0][41]);
                if (empresa.Rows[0][42].ToString() != string.Empty) { retorno.CantVisitas = Convert.ToInt16(empresa.Rows[0][42].ToString()); }
                retorno.ExAptitud = cargarDatoBool(empresa.Rows[0][43]);
                if (empresa.Rows[0][44].ToString() != string.Empty) { retorno.CantExAptitud = Convert.ToInt16(empresa.Rows[0][44].ToString()); }
                if (empresa.Rows[0][45].ToString() != string.Empty) { retorno.FechaAlta = Convert.ToDateTime(empresa.Rows[0][45].ToString()).ToShortDateString(); }
                retorno.Activo = empresa.Rows[0][46].ToString();
                if (empresa.Rows[0][47].ToString() != string.Empty) { retorno.Logo = new System.IO.MemoryStream((byte[]) empresa.Rows[0][47]);}
            }
            return retorno;     
        }

        private bool cargarDatoBool(object objeto)
        {
            if (objeto.ToString().Length > 0)
            {
                return (bool)objeto;
            }
            return false;
        }

        public DataTable cargarEmpresasConFiltro(string campo, string filtro)
        {
            return consultaDeEmpresas("where " + campo + " like '%" + filtro + "%'");
        }

        public DataTable cargarEmpresas()
        {
            return consultaDeEmpresas("");
        }

        private object convertirValor(string valor)
        {
            try
            {
                if (valor.Length > 0)
                {
                    return Convert.ToInt64(valor.Replace("-", ""));
                }
            }
            catch (FormatException ex)
            {

            }

            return "";
        }

        private DataTable consultaDeEmpresas(string filtro)
        {
            
                DataTable retorno = new DataTable();
                retorno.Columns.Add("Id");
                retorno.Columns.Add("Razón Social");
                retorno.Columns.Add("Tipo Doc.");
                retorno.Columns.Add("Nro. Documento");
                retorno.Columns.Add("Tipo Contribuyente");
                retorno.Columns.Add("Categoria");
                retorno.Columns.Add("Domicilio");
                retorno.Columns.Add("Localidad");
                retorno.Columns.Add("Provincia");
                DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select id, razonSocial as 'Razón Social', 
            tipoDeDocumento as 'Tipo Doc.', cuit as 'Nro. Documento',
            tipoDeContribuyente as 'Tipo Contribuyente', categoria as 'Categoria', direccion as 'Domicilio',
            localidad as 'Localidad', provincia as 'Provincia' from dbo.Empresa " + filtro + " order by razonSocial");
                try
                {
                    foreach (DataRow r in consulta.Rows)
                    {

                        retorno.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2],
                            string.Format("{0:##-########-#}", convertirValor(r.ItemArray[3].ToString())), r.ItemArray[4],
                            r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8]);
                    }
                
                }
                catch (FormatException ex)
                {

                }

            return retorno;
        }

    }
}
