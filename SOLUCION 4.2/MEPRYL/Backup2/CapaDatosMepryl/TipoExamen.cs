using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class TipoExamen
    {
        private DataTable items;
        public bool blnTieneRX = true;

        public TipoExamen()
        {
            items = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Items order by codigo");
        }

        public DataTable cargarTiposDeExamen(string idMotivoConsulta)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Especialidad
            where descripcion <> 'VISITAS' and idMotivoConsulta = " + idMotivoConsulta + 
            " order by CONVERT(int,codigo)");
        }

        public DataTable cargarMotivosDeConsulta()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.MotivoDeConsulta
            where nombre <> 'VISITAS'");
        }

        public Entidades.TipoExamen cargarEntidad(string id)
        {
            Entidades.TipoExamen retorno = new Entidades.TipoExamen();
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select id, codigo, descripcion, idMotivoConsulta, 
            precioBase, descripcionInformes from dbo.Especialidad where id = '" + id + "'");
            DataTable estudiosPorTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.EstudiosPorTipoExamen
            where idEspecialidad = '" + id + "'");
            if (tipoExamen.Rows.Count > 0)
            {
                retorno.Id = new Guid(tipoExamen.Rows[0][0].ToString());
                retorno.Codigo = Convert.ToInt16(tipoExamen.Rows[0][1].ToString());
                retorno.Descripcion = tipoExamen.Rows[0][2].ToString();
                retorno.IdMotivoConsulta = Convert.ToInt16(tipoExamen.Rows[0][3].ToString());
                retorno.PrecioBase = Convert.ToDouble(tipoExamen.Rows[0][4].ToString());
                retorno.DescripcionInformes = tipoExamen.Rows[0][5].ToString();
                retorno.Clinico = cargarTablaSegunFiltro(1, estudiosPorTipoExamen);
                retorno.Hematologia = cargarTablaSegunFiltro(2, estudiosPorTipoExamen);
                retorno.QuimicaHematica = cargarTablaSegunFiltro(3, estudiosPorTipoExamen);
                retorno.Serologia = cargarTablaSegunFiltro(4, estudiosPorTipoExamen);
                retorno.PerfilLipidico = cargarTablaSegunFiltro(5, estudiosPorTipoExamen);
                retorno.Bacteriologia = cargarTablaSegunFiltro(6, estudiosPorTipoExamen);
                retorno.Orina = cargarTablaSegunFiltro(7, estudiosPorTipoExamen);
                retorno.LaboralesBasicas = cargarTablaSegunFiltro(8, estudiosPorTipoExamen);
                retorno.CraneoYMSuperior = cargarTablaSegunFiltro(9, estudiosPorTipoExamen);
                retorno.TroncoYPelvis = cargarTablaSegunFiltro(10, estudiosPorTipoExamen);
                retorno.MiembroInferior = cargarTablaSegunFiltro(11, estudiosPorTipoExamen);
                retorno.EstComplementarios = cargarTablaSegunFiltro(12, estudiosPorTipoExamen);

            }
            return retorno;
        }

        public DataTable cargarTablaSegunFiltro(int ordenFormulario, DataTable estudiosPorTipoExamen)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Estado");
            retorno.Columns.Add("Item");

            retorno.Columns[2].DataType = System.Type.GetType("System.Boolean");

            DataRow[] dr = items.Select("ordenFormulario = " + ordenFormulario.ToString());

            foreach (DataRow r in dr)
            {
                int codigoItem = Convert.ToInt16(r.ItemArray[6].ToString()) + 1;
                bool valorItem = obtenerValor(estudiosPorTipoExamen.Rows[0].ItemArray[codigoItem].ToString());
                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[6].ToString(), valorItem, r.ItemArray[2].ToString());
            }
            return retorno;
        }

        private bool obtenerValor(string valor)
        {
            if (valor != string.Empty && valor.ToString() == "True")
            {
                return true;
            }
            return false;
        }

        public Entidades.Resultado editarTipoExamen(Entidades.TipoExamen entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateTipoExamen = SQLConnector.generarListaParaProcedure("@id",
                "@descripcion","@idMotivoConsulta","@precioBase","@descripcionInformes");
                SQLConnector.executeProcedure("sp_Especialidad_Update", updateTipoExamen, entidad.Id,
                    entidad.Descripcion, entidad.IdMotivoConsulta, entidad.PrecioBase, entidad.DescripcionInformes);
                actualizarEstudiosPorTipoExamen(entidad);
                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }

        public Entidades.Resultado crearTipoExamen(Entidades.TipoExamen entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> newTipoExamen = SQLConnector.generarListaParaProcedure("@descripcion", 
                    "@idMotivoConsulta", "@precioBase", "@descripcionInformes","@codigo");
                string idEspecialidad = SQLConnector.executeProcedureWithReturnValue("sp_Especialidad_InsertRapido",
                    newTipoExamen,
                    entidad.Descripcion, entidad.IdMotivoConsulta, entidad.PrecioBase, entidad.DescripcionInformes,
                    entidad.Codigo.ToString());
                entidad.Id = new Guid(idEspecialidad);
                List<string> newEstudiosPorExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_EstudiosPorTipoExamen_Insert", newEstudiosPorExamen, entidad.Id); 
                actualizarEstudiosPorTipoExamen(entidad);
                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }

        private void actualizarEstudiosPorTipoExamen(Entidades.TipoExamen entidad)
        {
            DataTable tablaAEnviar = crearTablaActualizacion();
            DataRow r = tablaAEnviar.NewRow();
            cargarValoresTablaActualizacion(entidad.Clinico, ref r);
            cargarValoresTablaActualizacion(entidad.Hematologia, ref r);
            cargarValoresTablaActualizacion(entidad.QuimicaHematica, ref  r);
            cargarValoresTablaActualizacion(entidad.Serologia, ref  r);
            cargarValoresTablaActualizacion(entidad.PerfilLipidico, ref r);
            cargarValoresTablaActualizacion(entidad.Bacteriologia, ref r);
            cargarValoresTablaActualizacion(entidad.Orina, ref r);
            cargarValoresTablaActualizacion(entidad.LaboralesBasicas, ref r);
            cargarValoresTablaActualizacion(entidad.CraneoYMSuperior, ref r);
            cargarValoresTablaActualizacion(entidad.TroncoYPelvis, ref r);
            cargarValoresTablaActualizacion(entidad.MiembroInferior, ref r);
            cargarValoresTablaActualizacion(entidad.EstComplementarios, ref r);
            tablaAEnviar.Rows.Add(r);

            List<string> lista = SQLConnector.generarListaParaProcedure("@idEspecialidad","@item1","@item2",
            "@item3","@item4","@item5","@item6","@item7","@item8","@item9","@item10","@item11","@item12","@item13",
            "@item14","@item15","@item16","@item17","@item18","@item19","@item20","@item21","@item22","@item23",
            "@item24","@item25","@item26","@item27","@item28","@item29","@item30","@item31","@item32","@item33",
            "@item34","@item35","@item36","@item37","@item38","@item39","@item40","@item41","@item42", "@item43",
            "@item44","@item45","@item46","@item47","@item48","@item49","@item50","@item51","@item52","@item53",
            "@item54","@item55","@item56","@item57","@item58","@item59","@item60","@item61","@item62","@item63",
            "@item64","@item65","@item66","@item67","@item68","@item69","@item70","@item71","@item72","@item73",
            "@item74","@item75","@item76","@item77","@item78","@item79","@item80","@item81","@item82","@item83",
            "@item84","@item85","@item86","@item87","@item88","@item89","@item90","@item91","@item92","@item93",
            "@item94","@item95","@item96","@item97");
            SQLConnector.executeProcedure("sp_EstudiosPorTipoExamen_Update", lista, entidad.Id, 
            guardarValor(tablaAEnviar.Rows[0].ItemArray[0].ToString()),
            guardarValor(tablaAEnviar.Rows[0][1].ToString()),guardarValor(tablaAEnviar.Rows[0][2].ToString()),
            guardarValor(tablaAEnviar.Rows[0][3].ToString()),guardarValor(tablaAEnviar.Rows[0][4].ToString()),
            guardarValor(tablaAEnviar.Rows[0][5].ToString()),guardarValor(tablaAEnviar.Rows[0][6].ToString()),
            guardarValor(tablaAEnviar.Rows[0][7].ToString()),guardarValor(tablaAEnviar.Rows[0][8].ToString()),
            guardarValor(tablaAEnviar.Rows[0][9].ToString()),guardarValor(tablaAEnviar.Rows[0][10].ToString()),
            guardarValor(tablaAEnviar.Rows[0][11].ToString()),guardarValor(tablaAEnviar.Rows[0][12].ToString()),
            guardarValor(tablaAEnviar.Rows[0][13].ToString()),guardarValor(tablaAEnviar.Rows[0][14].ToString()),
            guardarValor(tablaAEnviar.Rows[0][15].ToString()),guardarValor(tablaAEnviar.Rows[0][16].ToString()),
            guardarValor(tablaAEnviar.Rows[0][17].ToString()),guardarValor(tablaAEnviar.Rows[0][18].ToString()),
            guardarValor(tablaAEnviar.Rows[0][19].ToString()),guardarValor(tablaAEnviar.Rows[0][20].ToString()),
            guardarValor(tablaAEnviar.Rows[0][21].ToString()),guardarValor(tablaAEnviar.Rows[0][22].ToString()),
            guardarValor(tablaAEnviar.Rows[0][23].ToString()),guardarValor(tablaAEnviar.Rows[0][24].ToString()),
            guardarValor(tablaAEnviar.Rows[0][25].ToString()),guardarValor(tablaAEnviar.Rows[0][26].ToString()),
            guardarValor(tablaAEnviar.Rows[0][27].ToString()),guardarValor(tablaAEnviar.Rows[0][28].ToString()),
            guardarValor(tablaAEnviar.Rows[0][29].ToString()),guardarValor(tablaAEnviar.Rows[0][30].ToString()),
            guardarValor(tablaAEnviar.Rows[0][31].ToString()),guardarValor(tablaAEnviar.Rows[0][32].ToString()),
            guardarValor(tablaAEnviar.Rows[0][33].ToString()),guardarValor(tablaAEnviar.Rows[0][34].ToString()),
            guardarValor(tablaAEnviar.Rows[0][35].ToString()),guardarValor(tablaAEnviar.Rows[0][36].ToString()),
            guardarValor(tablaAEnviar.Rows[0][37].ToString()),guardarValor(tablaAEnviar.Rows[0][38].ToString()),
            guardarValor(tablaAEnviar.Rows[0][39].ToString()),guardarValor(tablaAEnviar.Rows[0][40].ToString()),
            guardarValor(tablaAEnviar.Rows[0][41].ToString()),guardarValor(tablaAEnviar.Rows[0][42].ToString()),
            guardarValor(tablaAEnviar.Rows[0][43].ToString()),guardarValor(tablaAEnviar.Rows[0][44].ToString()),
            guardarValor(tablaAEnviar.Rows[0][45].ToString()),guardarValor(tablaAEnviar.Rows[0][46].ToString()),
            guardarValor(tablaAEnviar.Rows[0][47].ToString()),guardarValor(tablaAEnviar.Rows[0][48].ToString()),
            guardarValor(tablaAEnviar.Rows[0][49].ToString()),guardarValor(tablaAEnviar.Rows[0][50].ToString()),
            guardarValor(tablaAEnviar.Rows[0][51].ToString()),guardarValor(tablaAEnviar.Rows[0][52].ToString()),
            guardarValor(tablaAEnviar.Rows[0][53].ToString()),guardarValor(tablaAEnviar.Rows[0][54].ToString()),
            guardarValor(tablaAEnviar.Rows[0][55].ToString()),guardarValor(tablaAEnviar.Rows[0][56].ToString()),
            guardarValor(tablaAEnviar.Rows[0][57].ToString()),guardarValor(tablaAEnviar.Rows[0][58].ToString()),
            guardarValor(tablaAEnviar.Rows[0][59].ToString()),guardarValor(tablaAEnviar.Rows[0][60].ToString()),
            guardarValor(tablaAEnviar.Rows[0][61].ToString()),guardarValor(tablaAEnviar.Rows[0][62].ToString()),
            guardarValor(tablaAEnviar.Rows[0][63].ToString()),guardarValor(tablaAEnviar.Rows[0][64].ToString()),
            guardarValor(tablaAEnviar.Rows[0][65].ToString()),guardarValor(tablaAEnviar.Rows[0][66].ToString()),
            guardarValor(tablaAEnviar.Rows[0][67].ToString()),guardarValor(tablaAEnviar.Rows[0][68].ToString()),
            guardarValor(tablaAEnviar.Rows[0][69].ToString()),guardarValor(tablaAEnviar.Rows[0][70].ToString()),
            guardarValor(tablaAEnviar.Rows[0][71].ToString()),guardarValor(tablaAEnviar.Rows[0][72].ToString()),
            guardarValor(tablaAEnviar.Rows[0][73].ToString()),guardarValor(tablaAEnviar.Rows[0][74].ToString()),
            guardarValor(tablaAEnviar.Rows[0][75].ToString()),guardarValor(tablaAEnviar.Rows[0][76].ToString()),
            guardarValor(tablaAEnviar.Rows[0][77].ToString()),guardarValor(tablaAEnviar.Rows[0][78].ToString()),
            guardarValor(tablaAEnviar.Rows[0][79].ToString()),guardarValor(tablaAEnviar.Rows[0][80].ToString()),
            guardarValor(tablaAEnviar.Rows[0][81].ToString()),guardarValor(tablaAEnviar.Rows[0][82].ToString()),
            guardarValor(tablaAEnviar.Rows[0][83].ToString()),guardarValor(tablaAEnviar.Rows[0][84].ToString()),
            guardarValor(tablaAEnviar.Rows[0][85].ToString()),guardarValor(tablaAEnviar.Rows[0][86].ToString()),
            guardarValor(tablaAEnviar.Rows[0][87].ToString()),guardarValor(tablaAEnviar.Rows[0][88].ToString()),
            guardarValor(tablaAEnviar.Rows[0][89].ToString()),guardarValor(tablaAEnviar.Rows[0][90].ToString()),
            guardarValor(tablaAEnviar.Rows[0][91].ToString()),guardarValor(tablaAEnviar.Rows[0][92].ToString()),
            guardarValor(tablaAEnviar.Rows[0][93].ToString()),guardarValor(tablaAEnviar.Rows[0][94].ToString()),
            guardarValor(tablaAEnviar.Rows[0][95].ToString()),guardarValor(tablaAEnviar.Rows[0][96].ToString()));
        }

        private object guardarValor(string valor)
        {
            if (valor != string.Empty)
            {
                return Convert.ToBoolean(valor);
            }
            return null;
        }



        private DataTable crearTablaActualizacion()
        {
            DataTable retorno = new DataTable();
            for(int i = 0; i <= 96; i++)
            {
                retorno.Columns.Add(i.ToString());
                retorno.Columns[i].DataType = System.Type.GetType("System.Boolean");
            }
            return retorno;
        }

        private void cargarValoresTablaActualizacion(DataTable tabla, ref DataRow tablaActualizacion)
        {
            foreach(DataRow r in tabla.Rows)
            {
                int codigo = Convert.ToInt16(r.ItemArray[1].ToString());
                tablaActualizacion[codigo - 1] = Convert.ToBoolean(r.ItemArray[2]);
            }
        }

        public Entidades.TipoExamen cargarItems()
        {
            Entidades.TipoExamen retorno = new Entidades.TipoExamen();
            retorno.Clinico = cargarItemsSegunOrdenFormulario(1);
            retorno.Hematologia = cargarItemsSegunOrdenFormulario(2);
            retorno.QuimicaHematica = cargarItemsSegunOrdenFormulario(3);
            retorno.Serologia = cargarItemsSegunOrdenFormulario(4);
            retorno.PerfilLipidico = cargarItemsSegunOrdenFormulario(5);
            retorno.Bacteriologia = cargarItemsSegunOrdenFormulario(6);
            retorno.Orina = cargarItemsSegunOrdenFormulario(7);
            retorno.LaboralesBasicas = cargarItemsSegunOrdenFormulario(8);
            retorno.CraneoYMSuperior = cargarItemsSegunOrdenFormulario(9);
            retorno.TroncoYPelvis = cargarItemsSegunOrdenFormulario(10);
            retorno.MiembroInferior = cargarItemsSegunOrdenFormulario(11);
            retorno.EstComplementarios = cargarItemsSegunOrdenFormulario(12);
            retorno.Codigo = obtenerProximoCodigo();
            return retorno;
        }

        private int obtenerProximoCodigo()
        {
            DataTable codigos = SQLConnector.obtenerTablaSegunConsultaString(@"select top 1 codigo from dbo.Especialidad
            order by CONVERT(int,codigo) desc");
            if (codigos.Rows.Count > 0)
            {
                return Convert.ToInt16(codigos.Rows[0][0].ToString()) + 1;
            }
            return 1;
        }

        private DataTable cargarItemsSegunOrdenFormulario(int ordenFormulario)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Estado");
            retorno.Columns.Add("Item");

            retorno.Columns[2].DataType = System.Type.GetType("System.Boolean");

            DataRow[] dr = items.Select("ordenFormulario = " + ordenFormulario.ToString());

            foreach (DataRow r in dr)
            {
                int codigoItem = Convert.ToInt16(r.ItemArray[6].ToString()) + 1;
                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[6].ToString(), false, r.ItemArray[2].ToString());
            }
            return retorno;
        }

        public Entidades.Resultado eliminarTipoExamen(string idTipoExamen)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                DataTable consultasYTurnos = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.TipoExamenDePaciente
                where idEspecialidad = '" + idTipoExamen + "'");
                if (consultasYTurnos.Rows.Count > 0)
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = "El Tipo de Examen ya tiene consultas y/o turnos asignados";
                    return retorno;
                }
                List<string> deleteTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_Especialidad_DeleteRapido", deleteTipoExamen, new Guid(idTipoExamen));               
                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }

        public void eliminarTipoExamenPaciente(Guid idTurno, Guid idTipoExamen)
        {
            List<string> deleteTipoExamen = SQLConnector.generarListaParaProcedure("@id");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_Delete", deleteTipoExamen, idTurno);
            List<string> deleteEstudiosPorExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_EstudiosPorExamen_Delete", deleteEstudiosPorExamen, idTipoExamen);
        }

        public void eliminarClubesPorExamen(Guid idTipoExamen)
        {
            List<string> deleteClubesPorExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Delete", deleteClubesPorExamen, idTipoExamen);
        }

        public void eliminarEmpresaPorExamen(Guid idTipoExamen)
        {
            List<string> deleteEmpresaPorExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Delete", deleteEmpresaPorExamen, idTipoExamen);
        }


        public bool verificarSiEstaModificado(Entidades.TipoExamen tipoExamen)
        {
            Entidades.TipoExamen examenPredeterminado = cargarEntidad(tipoExamen.Id.ToString());
            if (examenPredeterminado.PrecioBase.ToString() != tipoExamen.PrecioBase.ToString())
            {
                return true;
            }
            return verificarItemsExamen(examenPredeterminado, tipoExamen);
        }

        private bool verificarItemsExamen(Entidades.TipoExamen examenPredet, Entidades.TipoExamen examen)
        {
            if (compararItemsExamen(examenPredet.Clinico, examen.Clinico)) { return true; }
            if (compararItemsExamen(examenPredet.Hematologia, examen.Hematologia)) { return true; }
            if (compararItemsExamen(examenPredet.QuimicaHematica, examen.QuimicaHematica)) { return true; }
            if (compararItemsExamen(examenPredet.Serologia, examen.Serologia)) { return true; }
            if (compararItemsExamen(examenPredet.PerfilLipidico, examen.PerfilLipidico)) { return true; }
            if (compararItemsExamen(examenPredet.Bacteriologia, examen.Bacteriologia)) { return true; }
            if (compararItemsExamen(examenPredet.Orina, examen.Orina)) { return true; }
            if (compararItemsExamen(examenPredet.LaboralesBasicas, examen.LaboralesBasicas)) { return true; }
            if (compararItemsExamen(examenPredet.CraneoYMSuperior, examen.CraneoYMSuperior)) { return true; }
            if (compararItemsExamen(examenPredet.TroncoYPelvis, examen.TroncoYPelvis)) { return true; }
            if (compararItemsExamen(examenPredet.MiembroInferior, examen.MiembroInferior)) { return true; }
            if (compararItemsExamen(examenPredet.CraneoYMSuperior, examen.CraneoYMSuperior)) { return true; }
            if (compararItemsExamen(examenPredet.EstComplementarios, examen.EstComplementarios)) { return true; }
            return false;
        }

        private bool compararItemsExamen(DataTable tabla1, DataTable tabla2)
        {
            int contador = 0;
            foreach (DataRow r in tabla1.Rows)
            {
                if (r.ItemArray[2].ToString() != tabla2.Rows[contador].ItemArray[2].ToString())
                {
                    return true;
                }
                contador++;
            }
            return false;
        }

        public Entidades.TipoExamen cargarEstudiosPorExamen(string idTipoExamen)
        {
            Entidades.TipoExamen retorno = new Entidades.TipoExamen();
            DataTable estudiosPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select epe.*, tep.id, e.id, e.descripcion, tep.precioExamen, tep.modificado from dbo.TipoExamenDePaciente tep inner join dbo.EstudiosPorExamen epe on tep.id = epe.idTipoExamen
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id 
            where tep.id = '" + idTipoExamen + "'");
            if (estudiosPorExamen.Rows.Count > 0)
            {
                retorno.IdTipoExamenPaciente = new Guid(estudiosPorExamen.Rows[0][99].ToString());
                retorno.Id = new Guid(estudiosPorExamen.Rows[0][100].ToString());
                retorno.Descripcion = estudiosPorExamen.Rows[0][101].ToString();
                Double result;
                if (Double.TryParse(estudiosPorExamen.Rows[0][102].ToString(), out result))
                {
                    retorno.PrecioBase = result;
                }
                if (estudiosPorExamen.Rows[0][103].ToString() != string.Empty)
                {
                    retorno.Modificado = true;
                }
                retorno.Clinico = cargarTablaItemTipoExamenPaciente(estudiosPorExamen,1);
                retorno.Hematologia = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 2);
                retorno.QuimicaHematica = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 3);
                retorno.Serologia = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 4);
                retorno.PerfilLipidico = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 5);
                retorno.Bacteriologia = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 6);
                retorno.Orina = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 7);
                if (blnTieneRX)                    
                    retorno.LaboralesBasicas = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 8);
                 else
                    retorno.LaboralesBasicas = cargarTablaItemTipoExamenPaciente2(estudiosPorExamen, 8, blnTieneRX);
                retorno.CraneoYMSuperior = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 9);
                retorno.TroncoYPelvis = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 10);
                retorno.MiembroInferior = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 11);
                retorno.EstComplementarios = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 12);

                List<DataTable> lista = new List<DataTable>();
                lista.Add(retorno.Clinico);
                retorno.TextoClinico = estudiosString(ref lista);
                lista.Add(retorno.Hematologia);
                lista.Add(retorno.QuimicaHematica);
                lista.Add(retorno.Serologia);
                lista.Add(retorno.PerfilLipidico);
                lista.Add(retorno.Bacteriologia);
                lista.Add(retorno.Orina);
                retorno.TextoLaboratorio = estudiosString(ref lista);
                lista.Add(retorno.LaboralesBasicas);
                lista.Add(retorno.CraneoYMSuperior);
                lista.Add(retorno.TroncoYPelvis);
                lista.Add(retorno.MiembroInferior);
                retorno.TextoRx = estudiosString(ref lista);
                lista.Add(retorno.EstComplementarios);
                retorno.TextoEstComplement = estudiosString(ref lista);

            }
            return retorno;
        }

        private string estudiosString(ref List<DataTable> lista)
        {
            string texto = string.Empty;
            foreach (DataTable dt in lista)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr.ItemArray[2])
                    {
                        if (texto.Length == 0)
                        {
                            texto = dr.ItemArray[3].ToString();
                        }
                        else
                        {
                            texto = texto + " - " + dr.ItemArray[3].ToString();
                        }

                    }
                }
            }
            lista.Clear();
            return texto;
        }

        public Entidades.TipoExamen cargarTipoExamenSegunIdTurno(Guid idTurno)
        {
            DataTable idTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.TipoExamenDePaciente
            where idTurno = '" + idTurno.ToString() + "'");
            return cargarEstudiosPorExamen(idTipoExamen.Rows[0][0].ToString());
        }

        public Entidades.TipoExamen cargarTipoExamenSegunIdConsulta(Guid idConsulta)
        {
            DataTable idTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.TipoExamenDePaciente
            where idConsulta = '" + idConsulta.ToString() + "'");
            return cargarEstudiosPorExamen(idTipoExamen.Rows[0][0].ToString());
        }

        public Entidades.TipoExamen cargarTipoExamenSegunId(Guid idTipoExamen)
        {
            return cargarEstudiosPorExamen(idTipoExamen.ToString());
        }

        // GRV - Modificado mostrar MODF.
        //public Entidades.TipoExamen cargarEstudiosPorTipoExamen(string idTipoExamen)
        public Entidades.TipoExamen cargarEstudiosPorTipoExamen(string idTipoExamen)
        {
            Entidades.TipoExamen retorno = new Entidades.TipoExamen();
            DataTable estudiosPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select epe.*, e.id, e.descripcion, e.precioBase from dbo.EstudiosPorTipoExamen epe
            inner join dbo.Especialidad e on epe.idEspecialidad = e.id 
            where epe.idEspecialidad = '" + idTipoExamen + "'");
            if (estudiosPorExamen.Rows.Count > 0)
            {
                retorno.Id = new Guid(estudiosPorExamen.Rows[0][99].ToString());
                retorno.Descripcion = estudiosPorExamen.Rows[0][100].ToString();
                Double result;
                if (Double.TryParse(estudiosPorExamen.Rows[0][101].ToString(), out result))
                {
                    retorno.PrecioBase = result;
                }
                retorno.Clinico = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 1);
                retorno.Hematologia = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 2);
                retorno.QuimicaHematica = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 3);
                retorno.Serologia = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 4);
                retorno.PerfilLipidico = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 5);
                retorno.Bacteriologia = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 6);
                retorno.Orina = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 7);
                // GRV - Modificado
                if (blnTieneRX)
                    retorno.LaboralesBasicas = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 8);
                else
                    retorno.LaboralesBasicas = cargarTablaItemTipoExamenPaciente2(estudiosPorExamen, 8, blnTieneRX);
                retorno.CraneoYMSuperior = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 9);
                retorno.TroncoYPelvis = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 10);
                retorno.MiembroInferior = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 11);
                retorno.EstComplementarios = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 12);
            }
            return retorno;
        }

        private DataTable cargarTablaItemTipoExamenPaciente(DataTable estudiosPorTipoExamen, int nroOrden)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Estado");
            retorno.Columns.Add("Item");
            retorno.Columns.Add("Nombre Completo");


            retorno.Columns[2].DataType = System.Type.GetType("System.Boolean");
            int contador = 0;
            foreach (object obj in estudiosPorTipoExamen.Rows[0].ItemArray)
            {
                if (contador >= 2 && contador <= 98 && obj.ToString() != string.Empty)
                {
                    DataRow[] dr = items.Select("codigo = " + (contador - 1).ToString());
                    if (dr.Length > 0)
                    {
                        if (dr[0][3].ToString() == nroOrden.ToString())
                        {
                            retorno.Rows.Add(dr[0][0].ToString(), dr[0][6].ToString(), obj, dr[0][2].ToString(),
                                 dr[0][1].ToString());
                        }
                    }
                }
                contador++;
            }          
            return retorno;
        }

        // GRV - Modificado
        private DataTable cargarTablaItemTipoExamenPaciente2(DataTable estudiosPorTipoExamen, int nroOrden, bool blnTieneRX)
        {
            PacientePreventiva PacientePre = new PacientePreventiva();
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Estado");
            retorno.Columns.Add("Item");
            retorno.Columns.Add("Nombre Completo");



            retorno.Columns[2].DataType = System.Type.GetType("System.Boolean");
            int contador = 0;
            foreach (object obj in estudiosPorTipoExamen.Rows[0].ItemArray)
            {
                if (contador >= 2 && contador <= 98 && obj.ToString() != string.Empty)
                {
                    DataRow[] dr = items.Select("codigo = " + (contador - 1).ToString());
                    if (dr.Length > 0)
                    {
                        if (dr[0][3].ToString() == nroOrden.ToString())
                        {
                            if (contador != 39)
                            {
                                retorno.Rows.Add(dr[0][0].ToString(), dr[0][6].ToString(), obj, dr[0][2].ToString(),
                                     dr[0][1].ToString());
                            }
                            else
                            {
                                retorno.Rows.Add(dr[0][0].ToString(), dr[0][6].ToString(), false, dr[0][2].ToString(),
                                     dr[0][1].ToString());
                            }
                        }
                    }
                }
                contador++;
            }
            blnTieneRX = true;
            return retorno;
        }

        public void crearEstudiosPorExamen(Entidades.TipoExamen entidad)
        {
            List<string> estudiosPorExamenAdd = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_EstudiosPorExamen_Add", estudiosPorExamenAdd, entidad.IdTipoExamenPaciente);
            actualizarEstudiosPorExamen(entidad);
        }

        public void actualizarEstudiosPorExamen(Entidades.TipoExamen entidad)
        {
            string modificado = "";
            if(entidad.Modificado){modificado = "(*)";}
            List<string> updateImporteYModificado = SQLConnector.generarListaParaProcedure("@id", "@modificado", "@importe");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateModificadoEImporte", updateImporteYModificado,
                entidad.IdTipoExamenPaciente, modificado, entidad.PrecioBase);

            DataTable tablaAEnviar = crearTablaActualizacion();
            DataRow r = tablaAEnviar.NewRow();
            cargarValoresTablaActualizacion(entidad.Clinico, ref r);
            cargarValoresTablaActualizacion(entidad.Hematologia, ref r);
            cargarValoresTablaActualizacion(entidad.QuimicaHematica, ref  r);
            cargarValoresTablaActualizacion(entidad.Serologia, ref  r);
            cargarValoresTablaActualizacion(entidad.PerfilLipidico, ref r);
            cargarValoresTablaActualizacion(entidad.Bacteriologia, ref r);
            cargarValoresTablaActualizacion(entidad.Orina, ref r);
            cargarValoresTablaActualizacion(entidad.LaboralesBasicas, ref r);
            cargarValoresTablaActualizacion(entidad.CraneoYMSuperior, ref r);
            cargarValoresTablaActualizacion(entidad.TroncoYPelvis, ref r);
            cargarValoresTablaActualizacion(entidad.MiembroInferior, ref r);
            cargarValoresTablaActualizacion(entidad.EstComplementarios, ref r);
            tablaAEnviar.Rows.Add(r);

            List<string> lista = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@item1", "@item2",
            "@item3", "@item4", "@item5", "@item6", "@item7", "@item8", "@item9", "@item10", "@item11", "@item12", "@item13",
            "@item14", "@item15", "@item16", "@item17", "@item18", "@item19", "@item20", "@item21", "@item22", "@item23",
            "@item24", "@item25", "@item26", "@item27", "@item28", "@item29", "@item30", "@item31", "@item32", "@item33",
            "@item34", "@item35", "@item36", "@item37", "@item38", "@item39", "@item40", "@item41", "@item42", "@item43",
            "@item44", "@item45", "@item46", "@item47", "@item48", "@item49", "@item50", "@item51", "@item52", "@item53",
            "@item54", "@item55", "@item56", "@item57", "@item58", "@item59", "@item60", "@item61", "@item62", "@item63",
            "@item64", "@item65", "@item66", "@item67", "@item68", "@item69", "@item70", "@item71", "@item72", "@item73",
            "@item74", "@item75", "@item76", "@item77", "@item78", "@item79", "@item80", "@item81", "@item82", "@item83",
            "@item84", "@item85", "@item86", "@item87", "@item88", "@item89", "@item90", "@item91", "@item92", "@item93",
            "@item94", "@item95", "@item96", "@item97");
            SQLConnector.executeProcedure("sp_EstudiosPorExamen_Update", lista, entidad.IdTipoExamenPaciente,
            guardarValor(tablaAEnviar.Rows[0].ItemArray[0].ToString()),
            guardarValor(tablaAEnviar.Rows[0][1].ToString()), guardarValor(tablaAEnviar.Rows[0][2].ToString()),
            guardarValor(tablaAEnviar.Rows[0][3].ToString()), guardarValor(tablaAEnviar.Rows[0][4].ToString()),
            guardarValor(tablaAEnviar.Rows[0][5].ToString()), guardarValor(tablaAEnviar.Rows[0][6].ToString()),
            guardarValor(tablaAEnviar.Rows[0][7].ToString()), guardarValor(tablaAEnviar.Rows[0][8].ToString()),
            guardarValor(tablaAEnviar.Rows[0][9].ToString()), guardarValor(tablaAEnviar.Rows[0][10].ToString()),
            guardarValor(tablaAEnviar.Rows[0][11].ToString()), guardarValor(tablaAEnviar.Rows[0][12].ToString()),
            guardarValor(tablaAEnviar.Rows[0][13].ToString()), guardarValor(tablaAEnviar.Rows[0][14].ToString()),
            guardarValor(tablaAEnviar.Rows[0][15].ToString()), guardarValor(tablaAEnviar.Rows[0][16].ToString()),
            guardarValor(tablaAEnviar.Rows[0][17].ToString()), guardarValor(tablaAEnviar.Rows[0][18].ToString()),
            guardarValor(tablaAEnviar.Rows[0][19].ToString()), guardarValor(tablaAEnviar.Rows[0][20].ToString()),
            guardarValor(tablaAEnviar.Rows[0][21].ToString()), guardarValor(tablaAEnviar.Rows[0][22].ToString()),
            guardarValor(tablaAEnviar.Rows[0][23].ToString()), guardarValor(tablaAEnviar.Rows[0][24].ToString()),
            guardarValor(tablaAEnviar.Rows[0][25].ToString()), guardarValor(tablaAEnviar.Rows[0][26].ToString()),
            guardarValor(tablaAEnviar.Rows[0][27].ToString()), guardarValor(tablaAEnviar.Rows[0][28].ToString()),
            guardarValor(tablaAEnviar.Rows[0][29].ToString()), guardarValor(tablaAEnviar.Rows[0][30].ToString()),
            guardarValor(tablaAEnviar.Rows[0][31].ToString()), guardarValor(tablaAEnviar.Rows[0][32].ToString()),
            guardarValor(tablaAEnviar.Rows[0][33].ToString()), guardarValor(tablaAEnviar.Rows[0][34].ToString()),
            guardarValor(tablaAEnviar.Rows[0][35].ToString()), guardarValor(tablaAEnviar.Rows[0][36].ToString()),
            guardarValor(tablaAEnviar.Rows[0][37].ToString()), guardarValor(tablaAEnviar.Rows[0][38].ToString()),
            guardarValor(tablaAEnviar.Rows[0][39].ToString()), guardarValor(tablaAEnviar.Rows[0][40].ToString()),
            guardarValor(tablaAEnviar.Rows[0][41].ToString()), guardarValor(tablaAEnviar.Rows[0][42].ToString()),
            guardarValor(tablaAEnviar.Rows[0][43].ToString()), guardarValor(tablaAEnviar.Rows[0][44].ToString()),
            guardarValor(tablaAEnviar.Rows[0][45].ToString()), guardarValor(tablaAEnviar.Rows[0][46].ToString()),
            guardarValor(tablaAEnviar.Rows[0][47].ToString()), guardarValor(tablaAEnviar.Rows[0][48].ToString()),
            guardarValor(tablaAEnviar.Rows[0][49].ToString()), guardarValor(tablaAEnviar.Rows[0][50].ToString()),
            guardarValor(tablaAEnviar.Rows[0][51].ToString()), guardarValor(tablaAEnviar.Rows[0][52].ToString()),
            guardarValor(tablaAEnviar.Rows[0][53].ToString()), guardarValor(tablaAEnviar.Rows[0][54].ToString()),
            guardarValor(tablaAEnviar.Rows[0][55].ToString()), guardarValor(tablaAEnviar.Rows[0][56].ToString()),
            guardarValor(tablaAEnviar.Rows[0][57].ToString()), guardarValor(tablaAEnviar.Rows[0][58].ToString()),
            guardarValor(tablaAEnviar.Rows[0][59].ToString()), guardarValor(tablaAEnviar.Rows[0][60].ToString()),
            guardarValor(tablaAEnviar.Rows[0][61].ToString()), guardarValor(tablaAEnviar.Rows[0][62].ToString()),
            guardarValor(tablaAEnviar.Rows[0][63].ToString()), guardarValor(tablaAEnviar.Rows[0][64].ToString()),
            guardarValor(tablaAEnviar.Rows[0][65].ToString()), guardarValor(tablaAEnviar.Rows[0][66].ToString()),
            guardarValor(tablaAEnviar.Rows[0][67].ToString()), guardarValor(tablaAEnviar.Rows[0][68].ToString()),
            guardarValor(tablaAEnviar.Rows[0][69].ToString()), guardarValor(tablaAEnviar.Rows[0][70].ToString()),
            guardarValor(tablaAEnviar.Rows[0][71].ToString()), guardarValor(tablaAEnviar.Rows[0][72].ToString()),
            guardarValor(tablaAEnviar.Rows[0][73].ToString()), guardarValor(tablaAEnviar.Rows[0][74].ToString()),
            guardarValor(tablaAEnviar.Rows[0][75].ToString()), guardarValor(tablaAEnviar.Rows[0][76].ToString()),
            guardarValor(tablaAEnviar.Rows[0][77].ToString()), guardarValor(tablaAEnviar.Rows[0][78].ToString()),
            guardarValor(tablaAEnviar.Rows[0][79].ToString()), guardarValor(tablaAEnviar.Rows[0][80].ToString()),
            guardarValor(tablaAEnviar.Rows[0][81].ToString()), guardarValor(tablaAEnviar.Rows[0][82].ToString()),
            guardarValor(tablaAEnviar.Rows[0][83].ToString()), guardarValor(tablaAEnviar.Rows[0][84].ToString()),
            guardarValor(tablaAEnviar.Rows[0][85].ToString()), guardarValor(tablaAEnviar.Rows[0][86].ToString()),
            guardarValor(tablaAEnviar.Rows[0][87].ToString()), guardarValor(tablaAEnviar.Rows[0][88].ToString()),
            guardarValor(tablaAEnviar.Rows[0][89].ToString()), guardarValor(tablaAEnviar.Rows[0][90].ToString()),
            guardarValor(tablaAEnviar.Rows[0][91].ToString()), guardarValor(tablaAEnviar.Rows[0][92].ToString()),
            guardarValor(tablaAEnviar.Rows[0][93].ToString()), guardarValor(tablaAEnviar.Rows[0][94].ToString()),
            guardarValor(tablaAEnviar.Rows[0][95].ToString()), guardarValor(tablaAEnviar.Rows[0][96].ToString()));
        }

        // GRV - Modificado 
        public void VerificaExamenPreventiva(bool blnTieneExamen, string strIdTipoExamen)
        {
            string strSQL = "";

            if (!blnTieneExamen)
            {
                strSQL = "UPDATE dbo.TipoExamenDePaciente " +
                         "SET modificado = '(*)' " +
                         "WHERE id = '" + strIdTipoExamen + "' ";
            }
            else
            {
                strSQL = "UPDATE dbo.TipoExamenDePaciente " +
                         "SET modificado = '' " +
                         "WHERE id = '" + strIdTipoExamen + "' ";
            }

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (!blnTieneExamen)
            {
                strSQL = "UPDATE dbo.EstudiosPorExamen " +
                         "SET item38 = 0 " +
                         "WHERE idTipoExamen = '" + strIdTipoExamen + "' ";
            }
            else
            {
                strSQL = "UPDATE dbo.EstudiosPorExamen " +
                         "SET item38 = 1 " +
                         "WHERE idTipoExamen = '" + strIdTipoExamen + "' ";
            }

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
        } 

    }
}
