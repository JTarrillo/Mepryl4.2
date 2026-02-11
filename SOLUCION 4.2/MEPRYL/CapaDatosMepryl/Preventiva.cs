using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.IO;
using Comunes;


namespace CapaDatosMepryl
{
    public class Preventiva
    {
        private DataTable validaciones;
        private DataTable configReporte;
        private DataTable validacionesAutomaticas;

        public Preventiva()
        {
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
            // GRV - Ramírez - Mostrar Logo y firma almacenados en disco duro
            // configReporte = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.ConfigReportes");
            configReporte = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, logo, firma, profesional, matricula, cargo, piePagina, tipoReporte, libroFolio FROM dbo.ConfigReportes");
            validacionesAutomaticas = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.ValidacionesDictamen");
        }

        public void actualizarValidaciones()
        {
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
            validacionesAutomaticas = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.ValidacionesDictamen");
        }

        public Entidades.ExamenPreventiva cargarExamen(string idTipoExamen)
        {
            Entidades.ExamenPreventiva retorno = new Entidades.ExamenPreventiva();
            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.ExamenPreventiva where idTipoExamen = '" + idTipoExamen + "'");
            if (examen.Rows.Count == 1)
            {
                retorno.Id = Convert.ToInt64(examen.Rows[0].ItemArray[0]);
                retorno.IdTipoExamen = new Guid(examen.Rows[0].ItemArray[1].ToString());
                retorno.Biotipo = convertirInt(examen.Rows[0].ItemArray[2]);
                retorno.EntAire = convertirInt(examen.Rows[0].ItemArray[3]);
                retorno.RuiAgre = convertirInt(examen.Rows[0].ItemArray[4]);
                retorno.RuiCard = convertirInt(examen.Rows[0].ItemArray[5]);
                retorno.Silencios = convertirInt(examen.Rows[0].ItemArray[6]);
                retorno.TaMax = convertirInt(examen.Rows[0].ItemArray[7]);
                retorno.TaMin = convertirInt(examen.Rows[0].ItemArray[8]);
                retorno.Pulso = convertirInt(examen.Rows[0].ItemArray[9]);
                retorno.Abdomen = convertirInt(examen.Rows[0].ItemArray[10]);
                retorno.Hernias = convertirInt(examen.Rows[0].ItemArray[11]);
                retorno.Varices = convertirInt(examen.Rows[0].ItemArray[12]);
                retorno.ApGenitour = convertirInt(examen.Rows[0].ItemArray[13]);
                retorno.PielYFaneras = convertirInt(examen.Rows[0].ItemArray[14]);
                retorno.ApLocomotor = convertirInt(examen.Rows[0].ItemArray[15]);
                retorno.Snc = convertirInt(examen.Rows[0].ItemArray[16]);
                retorno.OjoDer = convertirInt(examen.Rows[0].ItemArray[17]);
                retorno.OjoDerLent = convertirInt(examen.Rows[0].ItemArray[18]);
                retorno.OjoIzq = convertirInt(examen.Rows[0].ItemArray[19]);
                retorno.OjoIzqLent = convertirInt(examen.Rows[0].ItemArray[20]);
                retorno.VisionCromatica = convertirInt(examen.Rows[0].ItemArray[21]);
                retorno.Odonto = convertirInt(examen.Rows[0].ItemArray[22]);
                retorno.DictFisico = convertirInt(examen.Rows[0].ItemArray[23]);
                retorno.ObsFisico = examen.Rows[0].ItemArray[24].ToString();
                retorno.Medico = convertirGuid(examen.Rows[0].ItemArray[25]);
                retorno.Talla = examen.Rows[0].ItemArray[26].ToString();
                retorno.Peso = examen.Rows[0].ItemArray[27].ToString();
                retorno.AntCli = examen.Rows[0].ItemArray[28].ToString();
                retorno.AntQui = examen.Rows[0].ItemArray[29].ToString();
                retorno.AntTrau = examen.Rows[0].ItemArray[30].ToString();
                retorno.GRojos = examen.Rows[0].ItemArray[31].ToString();
                retorno.GBlancos = examen.Rows[0].ItemArray[32].ToString();
                retorno.Hemoglob = examen.Rows[0].ItemArray[33].ToString();
                retorno.Hemato = examen.Rows[0].ItemArray[34].ToString();
                retorno.Eritro = examen.Rows[0].ItemArray[35].ToString();
                retorno.Cayado = convertirInt(examen.Rows[0].ItemArray[36]);
                retorno.Segmentado = convertirInt(examen.Rows[0].ItemArray[37]);
                retorno.Eosinof = convertirInt(examen.Rows[0].ItemArray[38]);
                retorno.Basof = convertirInt(examen.Rows[0].ItemArray[39]);
                retorno.Linfoc = convertirInt(examen.Rows[0].ItemArray[40]);
                retorno.Monoc = convertirInt(examen.Rows[0].ItemArray[41]);
                retorno.Glucemia = convertirInt(examen.Rows[0].ItemArray[42]);
                retorno.Uremia = convertirInt(examen.Rows[0].ItemArray[43]);
                retorno.Chagas = convertirInt(examen.Rows[0].ItemArray[44]);
                retorno.Vdrl = convertirInt(examen.Rows[0].ItemArray[45]);
                retorno.Grupo = convertirInt(examen.Rows[0].ItemArray[46]);
                retorno.Factor = convertirInt(examen.Rows[0].ItemArray[47]);
                retorno.Color = convertirInt(examen.Rows[0].ItemArray[48]);
                retorno.Aspecto = convertirInt(examen.Rows[0].ItemArray[49]);
                retorno.Densidad = examen.Rows[0].ItemArray[50].ToString();
                retorno.Ph = convertirInt(examen.Rows[0].ItemArray[51]);
                retorno.Glucosa = convertirInt(examen.Rows[0].ItemArray[52]);
                retorno.Proteinas = convertirInt(examen.Rows[0].ItemArray[53]);
                retorno.HemoglobOrina = convertirInt(examen.Rows[0].ItemArray[54]);
                retorno.Bilirrubina = convertirInt(examen.Rows[0].ItemArray[55]);
                retorno.Celulas = convertirInt(examen.Rows[0].ItemArray[56]);
                retorno.Leucocitos = convertirInt(examen.Rows[0].ItemArray[57]);
                retorno.Hematies = convertirInt(examen.Rows[0].ItemArray[58]);
                retorno.Piocitos = convertirInt(examen.Rows[0].ItemArray[59]);
                retorno.Mucus = convertirInt(examen.Rows[0].ItemArray[60]);
                retorno.DictLab = convertirInt(examen.Rows[0].ItemArray[61]);
                retorno.ObsSerieRoja = examen.Rows[0].ItemArray[62].ToString();
                retorno.ObsSerieBlanca = examen.Rows[0].ItemArray[63].ToString();
                retorno.OtrosOrina1 = examen.Rows[0].ItemArray[64].ToString();
                retorno.OtrosOrina2 = examen.Rows[0].ItemArray[65].ToString();
                retorno.ObsLaborat = examen.Rows[0].ItemArray[66].ToString();
                retorno.RxTorax = convertirInt(examen.Rows[0].ItemArray[67]);
                retorno.RxColumna = convertirInt(examen.Rows[0].ItemArray[68]);
                retorno.DictRx = convertirInt(examen.Rows[0].ItemArray[69]);
                retorno.OtrosRx = examen.Rows[0].ItemArray[70].ToString();
                retorno.ObsRx = examen.Rows[0].ItemArray[71].ToString();
                retorno.Ecg = convertirInt(examen.Rows[0].ItemArray[72]);
                retorno.DictCar = convertirInt(examen.Rows[0].ItemArray[73]);
                retorno.ObsCar = examen.Rows[0].ItemArray[74].ToString();
                retorno.DictFinal = convertirInt(examen.Rows[0].ItemArray[75]);
            }
            return retorno;
        }

        public Entidades.Resultado guardarClinico(Entidades.ExamenPreventiva examen)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateClinico = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@biotipo", "@entAire", "@ruiAgre", "@ruiCard",
                "@silencios", "@taMax", "@taMin", "@pulso", "@abdomen", "@hernias", "@varices", "@apGenitour", "@pielYFaneras", "@apLocomotor",
                "@snc", "@ojoDer", "@ojoDerLent", "@ojoIzq", "@ojoIzqLent", "@visionCromat", "@odonto", "@dictClinico", "@obsClinico", "@medico",
                "@talla", "@peso", "@antCli", "@antQui", "@antTrau");
                SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateClinico", updateClinico, examen.IdTipoExamen, guardarInt(examen.Biotipo),
                    guardarInt(examen.EntAire), guardarInt(examen.RuiAgre), guardarInt(examen.RuiCard), guardarInt(examen.Silencios),
                    guardarInt(examen.TaMax), guardarInt(examen.TaMin), guardarInt(examen.Pulso), guardarInt(examen.Abdomen),
                    guardarInt(examen.Hernias), guardarInt(examen.Varices), guardarInt(examen.ApGenitour), guardarInt(examen.PielYFaneras),
                    guardarInt(examen.ApLocomotor), guardarInt(examen.Snc), guardarInt(examen.OjoDer), guardarInt(examen.OjoDerLent),
                    guardarInt(examen.OjoIzq), guardarInt(examen.OjoIzqLent), guardarInt(examen.VisionCromatica), guardarInt(examen.Odonto),
                    guardarInt(examen.DictFisico), examen.ObsFisico, guardarGuid(examen.Medico), examen.Talla, examen.Peso, examen.AntCli,
                    examen.AntQui, examen.AntTrau);
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

        public Entidades.Resultado guardarLaboratorio(Entidades.ExamenPreventiva examen)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateLaboratorio = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@gRojos", "@gBlancos", "@hemoglo",
                "@hemato", "@eritro", "@nCayado", "@nSegment", "@eosinof", "@basof", "@linfo", "@monoc", "@glucemia", "@uremia", "@chagas", "@vdrl",
                "@grupo", "@factor", "@color", "@aspecto", "@densidad", "@ph", "@glucosa", "@proteina", "@hemogloOrina", "@bilirrubina", "@celulas",
                "@leuco", "@hematies", "@piocitos", "@mucus", "@dictLaborat", "@obsSerieRoja", "@obsSerieBlanca", "@otrosOrina1", "@otrosOrina2", "@obsLaborat");
                SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateLaboratorio", updateLaboratorio, examen.IdTipoExamen, examen.GRojos,
                    examen.GBlancos, examen.Hemoglob, examen.Hemato, examen.Eritro, guardarInt(examen.Cayado), guardarInt(examen.Segmentado),
                    guardarInt(examen.Eosinof), guardarInt(examen.Basof), guardarInt(examen.Linfoc), guardarInt(examen.Monoc),
                    guardarInt(examen.Glucemia), guardarInt(examen.Uremia), guardarInt(examen.Chagas), guardarInt(examen.Vdrl),
                    guardarInt(examen.Grupo), guardarInt(examen.Factor), guardarInt(examen.Color), guardarInt(examen.Aspecto),
                    examen.Densidad, guardarInt(examen.Ph), guardarInt(examen.Glucosa), guardarInt(examen.Proteinas),
                    guardarInt(examen.HemoglobOrina), guardarInt(examen.Bilirrubina), guardarInt(examen.Celulas), guardarInt(examen.Leucocitos),
                    guardarInt(examen.Hematies), guardarInt(examen.Piocitos), guardarInt(examen.Mucus), guardarInt(examen.DictLab),
                    examen.ObsSerieRoja, examen.ObsSerieBlanca, examen.OtrosOrina1, examen.OtrosOrina2, examen.ObsLaborat);
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

        public Entidades.Resultado guardarCardiologia(Entidades.ExamenPreventiva examen)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateCardiologia = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@ecg", "@dictCar", "@obsCar");
                SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateCardiologia", updateCardiologia, examen.IdTipoExamen,
                    guardarInt(examen.Ecg), guardarInt(examen.DictCar), examen.ObsCar);
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

        public Entidades.Resultado guardarDictamenFinal(Entidades.ExamenPreventiva examen)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateDictFinal = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@dictFinal");
                SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateDictFinal", updateDictFinal, examen.IdTipoExamen,
                    guardarInt(examen.DictFinal));
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

        public Entidades.Resultado guardarRx(Entidades.ExamenPreventiva examen)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateRx = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@rxTorax", "@rxColumna", "@otrasRx"
                , "@obsRx", "@dictRx");
                SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateRx", updateRx, examen.IdTipoExamen,
                    guardarInt(examen.RxTorax), guardarInt(examen.RxColumna), examen.OtrosRx, examen.ObsRx, guardarInt(examen.DictRx));
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


        private int convertirInt(object objeto)
        {
            if (objeto.ToString() != "" && objeto != null)
            {
                return Convert.ToInt16(objeto);
            }
            return -1;
        }

        private Guid convertirGuid(object objeto)
        {
            if (objeto.ToString() != "" && objeto != null)
            {
                return new Guid(objeto.ToString());
            }
            return Guid.Empty;
        }


        private object guardarInt(int objeto)
        {
            if (objeto.ToString() != "" && objeto != -1)
            {
                return objeto;
            }
            return null;
        }

        private object guardarGuid(Guid objeto)
        {
            if (objeto.ToString() != "" && objeto != Guid.Empty)
            {
                return objeto;
            }
            return null;
        }

        public DataTable cargarParametrosLaboratorio(object idTipoExamen, object idConsulta)
        {
            DataTable retorno = crearTablaParametrosLaboratorio();
            DataTable datos = cargarDatos(idConsulta);
            retorno.Rows.Add(((DateTime)datos.Rows[0].ItemArray[0]).ToShortDateString(), datos.Rows[0].ItemArray[1].ToString(),
            datos.Rows[0].ItemArray[2].ToString(), ((DateTime)datos.Rows[0].ItemArray[3]).ToShortDateString(),
            datos.Rows[0].ItemArray[4].ToString(), datos.Rows[0].ItemArray[39].ToString(), datos.Rows[0].ItemArray[40].ToString(),
            datos.Rows[0].ItemArray[41].ToString(), datos.Rows[0].ItemArray[42].ToString(), datos.Rows[0].ItemArray[43].ToString(),
            datos.Rows[0].ItemArray[44].ToString(), datos.Rows[0].ItemArray[45].ToString(), datos.Rows[0].ItemArray[46].ToString(),
            datos.Rows[0].ItemArray[47].ToString(), datos.Rows[0].ItemArray[48].ToString(), datos.Rows[0].ItemArray[49].ToString(),
            datos.Rows[0].ItemArray[50].ToString(), datos.Rows[0].ItemArray[51].ToString(),
            cargarValorValidacion(datos.Rows[0].ItemArray[52]), cargarValorValidacion(datos.Rows[0].ItemArray[53]),
            cargarValorValidacion(datos.Rows[0].ItemArray[56]), cargarValorValidacion(datos.Rows[0].ItemArray[57]),
            datos.Rows[0].ItemArray[58].ToString(), datos.Rows[0].ItemArray[59].ToString(),
            cargarValorValidacion(datos.Rows[0].ItemArray[60]), cargarValorValidacion(datos.Rows[0].ItemArray[61]),
            cargarValorValidacion(datos.Rows[0].ItemArray[62]), cargarValorValidacion(datos.Rows[0].ItemArray[63]),
            cargarValorValidacion(datos.Rows[0].ItemArray[64]), cargarValorValidacion(datos.Rows[0].ItemArray[65]),
            cargarValorValidacion(datos.Rows[0].ItemArray[66]), cargarValorValidacion(datos.Rows[0].ItemArray[67]),
            cargarValorValidacion(datos.Rows[0].ItemArray[68]), datos.Rows[0].ItemArray[74].ToString());
            return retorno;
        }

        public DataTable cargarParametrosExamen(object idTipoExamen, object idConsulta)
        {
            DataTable retorno = crearTablaParametrosExamen();
            DataTable datos = cargarDatos(idConsulta);
            DataTable clubesPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion 
            as Liga, c.descripcion as Club from dbo.clubesPorTipoExamen cte inner join dbo.Club c on 
            cte.idClub = c.id inner join dbo.Liga l on c.ligaID = l.id where cte.idTipoExamen = '"
            + idTipoExamen.ToString() + "'");


            List<string> lista = new List<string>();
            lista.Add("");
            lista.Add("");
            lista.Add("");
            lista.Add("");
            int contador = 0;
            foreach (DataRow r in clubesPorExamen.Rows)
            {
                if (contador <= 3)
                {
                    lista[contador] = r.ItemArray[0].ToString();
                    contador++;
                    lista[contador] = r.ItemArray[1].ToString();
                    contador++;
                }
            }

            string retiro = "";
            if (datos.Rows[0].ItemArray[7].ToString() == "1") { retiro = "R.M."; }

            string obsCli = datos.Rows[0].ItemArray[32].ToString();
            if (obsCli != "") { obsCli = "CLINICO: " + obsCli + " \n"; }
            string obsLab = datos.Rows[0].ItemArray[74].ToString();
            if (obsLab != "") { obsLab = "LABORATORIO: " + obsLab + " \n"; }
            string obsRx = datos.Rows[0].ItemArray[79].ToString();
            if (obsRx != "") { obsRx = "RX: " + obsRx + " \n"; }
            string obsCar = datos.Rows[0].ItemArray[82].ToString();
            if (obsCar != "") { obsCar = "CARDIOLOGIA: " + obsCar + " \n"; }
            string observaciones = obsCli + obsLab + obsRx + obsCar;

            

            retorno.Rows.Add(((DateTime)datos.Rows[0].ItemArray[0]).ToShortDateString(), datos.Rows[0].ItemArray[1].ToString(),
            datos.Rows[0].ItemArray[2].ToString(), ((DateTime)datos.Rows[0].ItemArray[3]).ToShortDateString(),
            datos.Rows[0].ItemArray[4].ToString(), ((DateTime)datos.Rows[0].ItemArray[3]).Year.ToString(), lista[0], lista[1], lista[2], lista[3],
            datos.Rows[0].ItemArray[36].ToString(), datos.Rows[0].ItemArray[37].ToString(),
            datos.Rows[0].ItemArray[38].ToString(), datos.Rows[0].ItemArray[34].ToString() + " m",
            datos.Rows[0].ItemArray[35].ToString() + " kg", cargarValorValidacion(datos.Rows[0].ItemArray[10]),
            cargarValorValidacion(datos.Rows[0].ItemArray[11]), cargarValorValidacion(datos.Rows[0].ItemArray[12]),
            cargarValorValidacion(datos.Rows[0].ItemArray[13]), cargarValorValidacion(datos.Rows[0].ItemArray[14]),
            datos.Rows[0].ItemArray[15].ToString(), datos.Rows[0].ItemArray[16].ToString(),
            datos.Rows[0].ItemArray[17].ToString() + " xMin", cargarValorValidacion(datos.Rows[0].ItemArray[18]),
            cargarValorValidacion(datos.Rows[0].ItemArray[19]), cargarValorValidacion(datos.Rows[0].ItemArray[20]),
            cargarValorValidacion(datos.Rows[0].ItemArray[21]), cargarValorValidacion(datos.Rows[0].ItemArray[22]),
            cargarValorValidacion(datos.Rows[0].ItemArray[23]), cargarValorValidacion(datos.Rows[0].ItemArray[24]),
            cargarValorValidacion(datos.Rows[0].ItemArray[25]), cargarValorValidacion(datos.Rows[0].ItemArray[26]),
            cargarValorValidacion(datos.Rows[0].ItemArray[27]), cargarValorValidacion(datos.Rows[0].ItemArray[28]),
            cargarValorValidacion(datos.Rows[0].ItemArray[29]), cargarValorValidacion(datos.Rows[0].ItemArray[30]),
            cargarValorValidacion(datos.Rows[0].ItemArray[69]), cargarValorValidacion(datos.Rows[0].ItemArray[80]),
            cargarValorValidacion(datos.Rows[0].ItemArray[75]), cargarValorValidacion(datos.Rows[0].ItemArray[76]),
            datos.Rows[0].ItemArray[78].ToString(), cargarValorValidacion(datos.Rows[0].ItemArray[83]),
            //cargarValorValidacion(datos.Rows[0].ItemArray[31]), obsCli, obsLab, obsRx, obsCar, retiro);
            cargarValorValidacion(datos.Rows[0].ItemArray[31]), observaciones, retiro);

            return retorno;
        }

        private DataTable cargarDatos(object idConsulta)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select c.fecha,c.identificador, 
            p.dni, p.fechaNacimiento,(p.apellido + ' ' + p.nombres) as nombre, p.telefonos, p.celular, tep.rm, ep.*
            from dbo.Consulta c inner join dbo.Paciente p on c.pacienteID = p.id 
            inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
            inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen
            where c.id = '" + idConsulta.ToString() + "'");
        }

        private DataTable crearTablaParametrosExamen()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Examen");
            retorno.Columns.Add("DNI");
            retorno.Columns.Add("FechaNacimiento");
            retorno.Columns.Add("ApellidoNombre");
            retorno.Columns.Add("Categoria");
            retorno.Columns.Add("Liga1");
            retorno.Columns.Add("Club1");
            retorno.Columns.Add("Liga2");
            retorno.Columns.Add("Club2");
            retorno.Columns.Add("AntCli");
            retorno.Columns.Add("AntQui");
            retorno.Columns.Add("AntTrau");
            retorno.Columns.Add("Talla");
            retorno.Columns.Add("Peso");
            retorno.Columns.Add("Biotipo");
            retorno.Columns.Add("EntAire");
            retorno.Columns.Add("RuidosAgre");
            retorno.Columns.Add("RuidosCard");
            retorno.Columns.Add("Silencios");
            retorno.Columns.Add("TaMax");
            retorno.Columns.Add("TaMin");
            retorno.Columns.Add("Pulso");
            retorno.Columns.Add("Abdomen");
            retorno.Columns.Add("Hernias");
            retorno.Columns.Add("Varices");
            retorno.Columns.Add("ApGenitour");
            retorno.Columns.Add("PielYFaneras");
            retorno.Columns.Add("ApLocomotor");
            retorno.Columns.Add("Snc");
            retorno.Columns.Add("OjoDer");
            retorno.Columns.Add("OjoDerLent");
            retorno.Columns.Add("OjoIzq");
            retorno.Columns.Add("OjoIzqLent");
            retorno.Columns.Add("VisionCromat");
            retorno.Columns.Add("ExOdonto");
            retorno.Columns.Add("Laboratorio");
            retorno.Columns.Add("ECG");
            retorno.Columns.Add("RxTorax");
            retorno.Columns.Add("RxColumna");
            retorno.Columns.Add("RxOtras");
            retorno.Columns.Add("DictFinal");
            retorno.Columns.Add("DictClinico");
            retorno.Columns.Add("ObsCli");
            //retorno.Columns.Add("ObsLab");
            //retorno.Columns.Add("ObsRx");
            //retorno.Columns.Add("ObsCar");
            retorno.Columns.Add("RM");
            return retorno;
        }

        private DataTable crearTablaParametrosLaboratorio()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Examen");
            retorno.Columns.Add("DNI");
            retorno.Columns.Add("FechaNacimiento");
            retorno.Columns.Add("ApellidoNombre");
            retorno.Columns.Add("GRojos");
            retorno.Columns.Add("GBlancos");
            retorno.Columns.Add("Hemoglobina");
            retorno.Columns.Add("Hematocrito");
            retorno.Columns.Add("Eritrosedimentacion");
            retorno.Columns.Add("Cayado");
            retorno.Columns.Add("Segmentado");
            retorno.Columns.Add("Eosinofilos");
            retorno.Columns.Add("Basofilos");
            retorno.Columns.Add("Linfocitos");
            retorno.Columns.Add("Monocitos");
            retorno.Columns.Add("Glucemia");
            retorno.Columns.Add("Uremia");
            retorno.Columns.Add("Chagas");
            retorno.Columns.Add("Vdrl");
            retorno.Columns.Add("Color");
            retorno.Columns.Add("Aspecto");
            retorno.Columns.Add("Densidad");
            retorno.Columns.Add("Ph");
            retorno.Columns.Add("Glucosa");
            retorno.Columns.Add("Proteinas");
            retorno.Columns.Add("HemoglobOrina");
            retorno.Columns.Add("Bilirrubina");
            retorno.Columns.Add("Celulas");
            retorno.Columns.Add("Leucocitos");
            retorno.Columns.Add("Hematies");
            retorno.Columns.Add("Piocitos");
            retorno.Columns.Add("Mucus");
            retorno.Columns.Add("Observaciones");
            return retorno;
        }

        private string cargarValorValidacion(object idValidacion)
        {
            if (idValidacion.ToString() != "" && idValidacion != null)
            {
                DataRow[] dr = validaciones.Select("id = " + idValidacion);
                if (dr.Length > 0) { return dr[0][3].ToString(); }
            }
            return string.Empty;
        }

        public DataTable cargarDataSourceExamen()
        {
            return cargarDataSourceReporte(1);
        }

        public DataTable cargarDataSourceLaboratorio()
        {
            return cargarDataSourceReporte(2);
        }


        private DataTable cargarDataSourceReporte(int tipo)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Logo");
            retorno.Columns.Add("Firma");
            retorno.Columns.Add("Profesional");
            retorno.Columns.Add("Matricula");
            retorno.Columns.Add("Cargo");
            retorno.Columns.Add("PiePagina");
            try
            {

                retorno.Columns[0].DataType = System.Type.GetType("System.Byte[]");
                retorno.Columns[1].DataType = System.Type.GetType("System.Byte[]");

                DataRow[] dr = configReporte.Select("tipoReporte = " + tipo);

                //GRV - Ramírez - Modificado
                // retorno.Rows.Add(dr[0][1], dr[0][2], dr[0][3], dr[0][4],
                //    dr[0][5], dr[0][6]);
                retorno.Rows.Add(Imagen_A_Bytes(Convert.ToString(dr[0][1])), Imagen_A_Bytes(Convert.ToString(dr[0][2])), dr[0][3], dr[0][4],
                    dr[0][5], dr[0][6]);
            }
            catch (System.FormatException ex)
            {

            }

            return retorno;
        }

        // GRV - Ramírez - Convertir imagenes a bytes
        public Byte[] Imagen_A_Bytes(String ruta)
        {
            Byte[] arreglo;

            try
            {

                if (ruta != "")
                {
                    FileStream foto = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    arreglo = new Byte[foto.Length];
                    BinaryReader reader = new BinaryReader(foto);
                    arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));
                    foto.Dispose();
                    foto.Close();
                    return arreglo;
                }
                else
                {
                    arreglo = new byte[ruta.Length * sizeof(char)];
                    System.Buffer.BlockCopy(ruta.ToCharArray(), 0, arreglo, 0, arreglo.Length);
                    return arreglo;
                }
            }
            catch (System.InvalidCastException ex)
            {
                //
                return null;
            }
        }

        public void actualizarImpresionExamen(object idTipoExamen)
        {
            List<string> listImp = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateImpresion", listImp,
                new Guid(idTipoExamen.ToString()), "1");
        }

        public void ActualizaConsolidadoExamen(string idTipoExamen)
        {
            string strSQL = "";

            strSQL = "update dbo.TipoExamenDePaciente " +
                     "set cons = '1' " +
                     "where id = '" + idTipoExamen + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool GenerarNuevamenteReportes(string idTipoExamen)
        {
            string strSQL = "";
            bool blnRetorno = false;

            strSQL = "update dbo.TipoExamenDePaciente " +
                     "set " + 
                     "cons = '0', " +
                     "imp = '0', " +
                     "impLab = '0', " +
                     "mail = '0' " +
                     "where id = '" + idTipoExamen + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            blnRetorno = true;

            return blnRetorno;
        }

        public void actualizarImpresionLaboratorio(object idTipoExamen)
        {
            List<string> listImp = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateImpresionLaboratorio", listImp,
                new Guid(idTipoExamen.ToString()), "1");
        }

        public void actualizarEnvioMail(object idTipoExamen)
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateMail", lista,
                new Guid(idTipoExamen.ToString()), "1");
        }

        public string getCodigoValidacion(string idValidacion)
        {
            if (idValidacion != "")
            {
                return validaciones.Select("id = " + idValidacion)[0][2].ToString();
            }
            return "00";
        }

        public void dictamenRxAutomatico(object idTipoExamen)
        {
            TipoExamen te = new TipoExamen();
            DataTable rx = te.cargarEstudiosPorExamen(idTipoExamen.ToString()).LaboralesBasicas;
            string codigoInterno70;
            string codigoInterno71;
            string codigoInterno72;
            if ((bool)rx.Rows[0][2])
            {
                codigoInterno70 = "1";
                codigoInterno71 = "1";
                codigoInterno72 = "01";
            }
            else
            {
                codigoInterno70 = "3";
                codigoInterno71 = "1";
                codigoInterno72 = "05";
            }

            int idTorax = filtrarValidaciones("70", codigoInterno70);
            int idColLumbar = filtrarValidaciones("71", codigoInterno71);
            int idDictamenRx = filtrarValidaciones("72", codigoInterno72);

            List<string> updateRx = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@rxTorax",
                "@rxColumna", "dictRx", "@otrosRx", "obsRx");
            SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateRxAutomatico", updateRx, new Guid(idTipoExamen.ToString()),
                idTorax, idColLumbar, idDictamenRx, null, null);
        }

        private int filtrarValidaciones(string codigo, string codigoInterno)
        {
            DataRow[] dr = validaciones.Select("codigo = '" + codigo + "' and codigoInterno = '" + codigoInterno + "'");
            if (dr.Length > 0) { return Convert.ToInt16(dr[0][0].ToString()); }
            return -1;
        }

        public void dictamenCarAutomatico(object idTipoExamen)
        {
            int ecg = filtrarValidaciones("80", "1");
            int dictCar = filtrarValidaciones("81", "01");

            List<string> lista = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@ecg", "@dictCar", "@obsCar");
            SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateCardiologiaAutomatico", lista,
                new Guid(idTipoExamen.ToString()), ecg, dictCar, null);
        }

        public void dictamenFinalAutomatico(object idTipoExamen)
        {
            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString(@"select ep.dictClinico, ep.dictLab, ep.dictRx, ep.dictCar, c.fecha, ep.dictFinal
            from dbo.TipoExamenDePaciente tep inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen
            inner join dbo.Consulta c on tep.idConsulta = c.id
            where tep.id = '" + idTipoExamen.ToString() + "' and (tep.dictAut is NULL or tep.dictAut = '')");
            if (examen.Rows.Count > 0)
            {
                if (getCodigoValidacion(examen.Rows[0].ItemArray[5].ToString()) != "10" &&
                    getCodigoValidacion(examen.Rows[0].ItemArray[5].ToString()) != "14" &&
                    (getCodigoValidacion(examen.Rows[0].ItemArray[5].ToString()) != "00"
                    || getCodigoValidacion(examen.Rows[0].ItemArray[0].ToString()) != "00"))
                {
                    DataRow[] dr = validacionesAutomaticas.Select("fisico = '" + getCodigoValidacion(examen.Rows[0].ItemArray[0].ToString())
                        + "' and laboratorio = '" + getCodigoValidacion(examen.Rows[0].ItemArray[1].ToString()) + "' and rx = '"
                        + getCodigoValidacion(examen.Rows[0].ItemArray[2].ToString()) + "' and car = '" +
                        getCodigoValidacion(examen.Rows[0].ItemArray[3].ToString()) + "'");
                    int idDictFinal;
                    if (dr.Length > 0)
                    {
                        idDictFinal = filtrarValidaciones("90", dr[0][5].ToString());
                    }
                    else
                    {
                        idDictFinal = filtrarValidaciones("90", "13");
                    }

                    if (((DateTime)examen.Rows[0].ItemArray[4]) < DateTime.Today.AddDays(-60))
                    {
                        if (idDictFinal == filtrarValidaciones("90", "04"))
                        {
                            idDictFinal = filtrarValidaciones("90", "09");
                        }
                    }

                    List<string> updateDictFinal = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@dictFinal");
                    SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateDictFinal", updateDictFinal,
                        new Guid(idTipoExamen.ToString()), idDictFinal);
                }
            }

        }

        public Entidades.Resultado revalidarCondicionales()
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                DataTable consultas = SQLConnector.obtenerTablaSegunConsultaString(@"select c.fecha, tep.id, ep.dictFinal from 
                dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
                inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen
                where c.tipo = 'P'");
                foreach (DataRow r in consultas.Rows)
                {
                    if (((DateTime)r.ItemArray[0]) < DateTime.Today.AddDays(-60))
                    {
                        if (r.ItemArray[2].ToString() == filtrarValidaciones("90", "04").ToString())
                        {
                            List<string> listUpdate = SQLConnector.generarListaParaProcedure("@id", "@dictFinal");
                            SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateDictamenFinal", listUpdate, new Guid(r.ItemArray[1].ToString()), filtrarValidaciones("90", "09"));
                        }
                    }
                }
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

        public void eliminarExamen(string idTipoExamen, string idConsulta)
        {
            List<string> cteDelete = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Delete", cteDelete,
                new Guid(idTipoExamen));
            List<string> itemsDelete = SQLConnector.generarListaParaProcedure("@id");
            SQLConnector.executeProcedure("sp_ItemsPorPaciente_Delete", itemsDelete,
            new Guid(idTipoExamen));
            SQLConnector.executeProcedure("sp_Consulta_Delete", itemsDelete,
                new Guid(idConsulta));
            SQLConnector.executeProcedure("sp_ExamenPreventiva_Delete",
                cteDelete, new Guid(idTipoExamen));
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_Delete",
                itemsDelete, new Guid(idTipoExamen));
        }

        public void inhabilitarExamen(object idTipoExamen, string codigo)
        {
            List<string> listUpdate = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@dictFinal");
            SQLConnector.executeProcedure("sp_ExamenPreventiva_UpdateDictFinal", listUpdate, new Guid(idTipoExamen.ToString()),
                filtrarValidaciones("90",codigo));
        }

        public bool estaInhabilitado(object idTipoExamen)
        {
            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString(@"select dictFinal
            from dbo.ExamenPreventiva where idTipoExamen = '" + idTipoExamen.ToString() + "'");
            if (examen.Rows[0].ItemArray[0].ToString() == filtrarValidaciones("90", "10").ToString()
            || examen.Rows[0].ItemArray[0].ToString() == filtrarValidaciones("90", "14").ToString())
            {
                return true;
            }
            return false;
        }

        public bool estaInhabilitadoDni(string dni)
        {
            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString(@"select ep.dictFinal from dbo.Consulta c 
            inner join dbo.Paciente p on c.pacienteID = p.id
            inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta 
            inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen
            where p.dni = '" + dni + "'");
            foreach (DataRow r in examen.Rows)
            {
                if (r.ItemArray[0].ToString() == filtrarValidaciones("90", "10").ToString()
                || r.ItemArray[0].ToString() == filtrarValidaciones("90", "14").ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public void crearExamen(string idTipoExamen)
        {
            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.ExamenPreventiva where idTipoExamen = '" + idTipoExamen + "'");
            if (examen.Rows.Count <= 0)
            {
                List<string> listInsert = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_ExamenPreventiva_InsertRapido", listInsert, new Guid(idTipoExamen));
            }
        }

        public DataTable ListaInformeRadiologico(DateTime Desde, DateTime Hasta, string DNI, string NroOrden)
        {
            DataTable dtConsulta = null;
            string strSQL = "";

            strSQL = "select CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Examen', p.dni as DNI, " +
                     "(p.apellido + ' ' + p.nombres) as Paciente, v.descripcion " +
                     "from dbo.Consulta c " +
                     "inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta " +
                     "inner join dbo.Paciente p on c.pacienteID = p.id " +
                     "INNER JOIN dbo.ExamenPreventiva EP ON tep.id = EP.idTipoExamen " +
                     "INNER JOIN dbo.Validaciones v ON EP.rxTorax = v.id " +
                     "where c.tipo = 'P' and Convert(date,c.fecha) >= convert(date,'" + Desde.ToShortDateString() + "',105) and Convert(date,c.fecha) " +
                     "<= convert(date,'" + Hasta.ToShortDateString() + "',105) AND p.dni = '" + DNI + "' AND c.identificador = '" + NroOrden + "' " +
                     "order by c.fecha asc, convert(int,c.identificador) asc";
            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtConsulta;
        }

        public string ObtieneTipoExamenPaciente(DateTime Fecha, string DNI)
        {
            DataTable dtConsulta = null;
            string strSQL = "";
            string strResultado = "";

            strSQL = "SELECT TOP 1 tep.id as IdTipoExamen, c.identificador as 'Nº Examen', " +
                     "(p.apellido + ' ' + p.nombres) as Paciente, p.fechaNacimiento " +
                     "FROM dbo.Consulta c " +
                     "INNER JOIN dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta " +
                     "INNER JOIN dbo.Paciente p on c.pacienteID = p.id " +
                     "WHERE p.dni = '" + DNI + "' AND Convert(date,c.fecha) = convert(date,'" + Fecha + "',105)";
            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strResultado = dtConsulta.Rows[0].ItemArray[0].ToString();
            }

            return strResultado;
        }

        public bool ExamenConsolidado(string idTipoExamen)
        {
            DataTable dtConsulta = null;
            bool blnRetorno = false;
            string strSQL = "";

            strSQL = "SELECT cons FROM dbo.TipoExamenDePaciente WHERE id = '" + idTipoExamen + "'";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[0].ToString()))
                    blnRetorno = Convert.ToBoolean(Convert.ToUInt32(dtConsulta.Rows[0].ItemArray[0].ToString()));
            }
            
            return blnRetorno;
        }

        public void ActualizaEnvioMailExamen(string idTipoExamen)
        {            
            string strSQL = "";

            strSQL = "UPDATE dbo.TipoExamenDePaciente " +
                     "SET mail = '1' " +
                     "WHERE id = '" + idTipoExamen + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }
    }
}
