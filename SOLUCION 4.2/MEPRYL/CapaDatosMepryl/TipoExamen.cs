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

        // ...existing code...

        // ✅ NUEVO: Cargar todos los tipos de examen padre con subtipos activos (sin filtrar por motivo)
        public DataTable cargarTodosLosTiposDeExamenPadreConSubtiposActivos()
        {
            string query = @"
        SELECT e.*
        FROM dbo.Especialidad e
        WHERE e.descripcion <> 'VISITAS'
          AND e.Padre = 1
          AND e.estado = 1
          AND EXISTS (
              SELECT 1 FROM dbo.Especialidad s
              WHERE s.IdPadre = e.id AND s.Padre = 0 AND s.estado = 1
          )
        ORDER BY CASE WHEN ISNUMERIC(e.codigo) = 1 THEN CONVERT(int, e.codigo) ELSE 999999 END, e.codigo";
            return SQLConnector.obtenerTablaSegunConsultaString(query);
        }
        // ...existing code...

        public DataTable cargarTiposDeExamen(string idMotivoConsulta)
        {
            if (!int.TryParse(idMotivoConsulta, out int id))
                return new DataTable();

            // Traer solo especialidades PADRE (Padre = 1) y NO eliminadas lógicamente
            return SQLConnector.obtenerTablaSegunConsultaString(
                $@"select * from dbo.Especialidad
        where descripcion <> 'VISITAS' 
        and idMotivoConsulta = {id}
        and Padre = 1
        and id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
        order by CASE WHEN ISNUMERIC(codigo) = 1 THEN CONVERT(int, codigo) ELSE 999999 END, codigo");
        }

        public DataTable cargarTiposDeExamenHijo(string idMotivoConsulta, string strIdPadre)
        {
            // Si no hay MotivoConsulta o IdPadre, buscar solo por IdPadre
            if (string.IsNullOrWhiteSpace(strIdPadre))
                return new DataTable();

            string strSQL = @"select e.* from dbo.Especialidad e
                            LEFT JOIN dbo.EspecialidadesEliminadas eel ON e.id = eel.id
                            where e.descripcion <> 'VISITAS' 
                            and e.Padre = 0 
                            and e.IdPadre = '" + strIdPadre + @"'
                            and eel.id IS NULL";

            // Solo agregar filtro de MotivoConsulta si viene valor
            if (!string.IsNullOrWhiteSpace(idMotivoConsulta) && int.TryParse(idMotivoConsulta, out int idMotivo))
            {
                strSQL += @" and e.idMotivoConsulta = " + idMotivo;
            }

            strSQL += " order by CASE WHEN ISNUMERIC(e.codigo) = 1 THEN CONVERT(int, e.codigo) ELSE 999999 END, e.codigo";

            return RetornarTipoExamenHijo(SQLConnector.obtenerTablaSegunConsultaString(strSQL));
        }

        /// <summary>
        /// Obtiene el IdPadre de un subtipo dado su ID
        /// </summary>
        public string ObtenerIdPadreDeSubtipo(string idSubtipo)
        {
            if (string.IsNullOrWhiteSpace(idSubtipo))
                return null;

            string query = $@"SELECT IdPadre FROM dbo.Especialidad WHERE id = '{idSubtipo}' AND Padre = 0";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(query);

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["IdPadre"] != DBNull.Value)
                return dt.Rows[0]["IdPadre"].ToString();

            return null;
        }

        /// <summary>
        /// Verifica si un tipo padre tiene subtipos activos
        /// </summary>
        public bool TieneSubtiposActivos(string idPadre)
        {
            if (string.IsNullOrWhiteSpace(idPadre))
                return false;

            string query = $@"
        SELECT COUNT(*) FROM dbo.Especialidad
        WHERE IdPadre = '{idPadre}'
          AND Padre = 0
          AND estado = 1
          AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(query);

            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]) > 0;

            return false;
        }

        /// <summary>
        /// Carga SOLO los subtipos ACTIVOS (estado = 1) para un tipo padre específico
        public DataTable cargarNivel2EspecialidadActivos(string idPadre)
        {
            if (string.IsNullOrWhiteSpace(idPadre))
                return new DataTable();

            string query = $@"
    SELECT e.*
    FROM dbo.Especialidad e
    WHERE (e.Padre IS NULL OR e.Padre = 0)
      AND UPPER(e.IdPadre) = UPPER('{idPadre}')
      AND e.estado = 1
      AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
    ORDER BY e.descripcion";

            return SQLConnector.obtenerTablaSegunConsultaString(query);
        }
        /// <summary>
        /// Carga subtipos activos por padre (alias para cargarNivel2EspecialidadActivos)
        /// </summary>
        public DataTable cargarSubtiposActivosPorPadre(string idPadre)
        {
            return cargarNivel2EspecialidadActivos(idPadre);
        }

        /// <summary>
        /// Activa todos los subtipos (Padre = 0) de un motivo de consulta específico.
        /// </summary>

        public Entidades.Resultado DesactivarTodosLosSubtipos()
        {
            var resultado = new Entidades.Resultado();
            try
            {
                string sql = @"UPDATE dbo.Especialidad 
                               SET estado = 0 
                               WHERE Padre = 0 
                                 AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sql);
                resultado.Modo = 1;
                resultado.Mensaje = "Todos los subtipos desactivados correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al desactivar subtipos: " + ex.Message;
            }
            return resultado;
        }
        public Entidades.Resultado ActivarTodosLosSubtiposPorMotivo(string idMotivoConsulta)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // Usar lista de parámetros como en otros métodos
                List<string> parametros = SQLConnector.generarListaParaProcedure("@idMotivoConsulta");
                SQLConnector.executeProcedure("ActivarTodosLosSubtiposPorMotivo", parametros, Convert.ToInt32(idMotivoConsulta));
                resultado.Modo = 1;
                resultado.Mensaje = "Todos los subtipos del motivo han sido activados correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo = 0;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }


        public Entidades.Resultado DesactivarSubtiposPorTipoYMotivo(string idPadre, int idMotivoConsulta)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // Desactivar todos los subtipos (Padre = 0) para el tipo y motivo indicados
                string sql = $@"UPDATE dbo.Especialidad 
                        SET estado = 0 
                        WHERE Padre = 0 
                          AND IdPadre = '{idPadre}' 
                          AND idMotivoConsulta = {idMotivoConsulta}
                          AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sql);

                // Desactivar el tipo de examen padre (Padre = 1) si corresponde
                string sqlPadre = $@"UPDATE dbo.Especialidad 
                             SET estado = 0 
                             WHERE id = '{idPadre}' 
                               AND Padre = 1 
                               AND idMotivoConsulta = {idMotivoConsulta}
                               AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sqlPadre);

                resultado.Modo = 1;
                resultado.Mensaje = "Subtipos y tipo de examen padre desactivados correctamente para el tipo y motivo indicados.";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al desactivar subtipos y tipo padre: " + ex.Message;
            }
            return resultado;
        }

        public Entidades.Resultado ActivarTodosLosSubtiposGlobal()
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // Activar todos los subtipos (Padre = 0)
                string sql = @"UPDATE dbo.Especialidad 
                       SET estado = 1 
                       WHERE Padre = 0 
                         AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sql);

                // Activar todos los tipos de examen padre (Padre = 1)
                string sqlPadres = @"UPDATE dbo.Especialidad 
                             SET estado = 1 
                             WHERE Padre = 1 
                               AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sqlPadres);

                resultado.Modo = 1;
                resultado.Mensaje = "Todos los tipos y subtipos activados correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo = 0;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }
        public Entidades.Resultado ActivarTodosLosSubtipos(string idPadre)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // Activar todos los subtipos (Padre = 0) del tipo padre indicado
                string sqlSubtipos = $@"UPDATE dbo.Especialidad 
                                SET estado = 1 
                                WHERE IdPadre = '{idPadre}' 
                                  AND Padre = 0 
                                  AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sqlSubtipos);

                // Activar el tipo de examen padre (Padre = 1)
                string sqlPadre = $@"UPDATE dbo.Especialidad 
                             SET estado = 1 
                             WHERE id = '{idPadre}' 
                               AND Padre = 1 
                               AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sqlPadre);

                resultado.Modo = 1;
                resultado.Mensaje = "Todos los subtipos y el tipo de examen padre activados correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al activar subtipos y tipo padre: " + ex.Message;
            }
            return resultado;
        }
        public Entidades.Resultado DesactivarTodosLosSubtipos(string idPadre)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // Desactivar todos los subtipos (Padre = 0)
                string sqlSubtipos = @"UPDATE dbo.Especialidad 
                               SET estado = 0 
                               WHERE Padre = 0 
                                 AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sqlSubtipos);

                // Desactivar todos los tipos de examen padre (Padre = 1)
                string sqlPadres = @"UPDATE dbo.Especialidad 
                             SET estado = 0 
                             WHERE Padre = 1 
                               AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sqlPadres);

                resultado.Modo = 1;
                resultado.Mensaje = "Todos los tipos y subtipos desactivados correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al desactivar tipos y subtipos: " + ex.Message;
            }
            return resultado;
        }


        public DataTable cargarTiposDeExamenHijo(string idMotivoConsulta)
        {
            if (!int.TryParse(idMotivoConsulta, out int id))
                return new DataTable();

            string strSQL = @"select * from dbo.Especialidad 
                where descripcion <> 'VISITAS' and idMotivoConsulta = " + id + @" AND Padre = 0 
                order by CASE WHEN ISNUMERIC(codigo) = 1 THEN CONVERT(int, codigo) ELSE 999999 END, codigo";

            return RetornarTipoExamenHijo(SQLConnector.obtenerTablaSegunConsultaString(strSQL));
        }

        public DataTable cargarTiposDeExamenHijo(string idMotivoConsulta, string strBuscar, bool blnAtv)
        {
            if (!int.TryParse(idMotivoConsulta, out int id) || string.IsNullOrWhiteSpace(strBuscar))
                return new DataTable();

            string buscar = strBuscar.Replace("'", "''");
            string strSQL = @"select * from dbo.Especialidad 
                where descripcion <> 'VISITAS' and idMotivoConsulta = " + id + @" AND Padre = 0 
                and descripcion LIKE '%" + buscar + @"%'
                order by CASE WHEN ISNUMERIC(codigo) = 1 THEN CONVERT(int, codigo) ELSE 999999 END, codigo";

            return RetornarTipoExamenHijo(SQLConnector.obtenerTablaSegunConsultaString(strSQL));
        }

        public DataTable cargarTiposDeExamenFinales(string idMotivoConsulta, string strBuscar, bool blnAtv)
        {
            string strSQL = @"select * from dbo.Especialidad e
                where e.descripcion <> 'VISITAS' 
                and NOT EXISTS (select 1 from dbo.Especialidad e2 where e2.IdPadre = e.id)";

            if (!string.IsNullOrWhiteSpace(idMotivoConsulta) && int.TryParse(idMotivoConsulta, out int idMotivo))
                strSQL += $" and e.idMotivoConsulta = {idMotivo}";

            if (!string.IsNullOrWhiteSpace(strBuscar))
            {
                string buscar = strBuscar.Replace("'", "''");
                strSQL += $" and e.descripcion LIKE '%{buscar}%'";
            }

            strSQL += " order by CASE WHEN ISNUMERIC(e.codigo) = 1 THEN CONVERT(int, e.codigo) ELSE 999999 END, e.codigo";

            return RetornarTipoExamenHijo(SQLConnector.obtenerTablaSegunConsultaString(strSQL));
        }

        public DataTable RetornarTipoExamenHijo(DataTable dt)
        {
            DataTable retorno = new DataTable();

            retorno.Columns.Add("id");
            retorno.Columns.Add("codigo");
            retorno.Columns.Add("descripcion");
            retorno.Columns.Add("registroBLOB");
            retorno.Columns.Add("actualizacion_local");
            retorno.Columns.Add("operacion_local");
            retorno.Columns.Add("sincronizado");
            retorno.Columns.Add("serverID");
            retorno.Columns.Add("idMotivoConsulta");
            retorno.Columns.Add("precioBase");
            retorno.Columns.Add("orden");
            retorno.Columns.Add("tipo");
            retorno.Columns.Add("descripcionInformes");
            retorno.Columns.Add("Padre");
            retorno.Columns.Add("IdPadre");

            foreach (DataRow r in dt.Rows)
            {
                retorno.Rows.Add(r.ItemArray[0], String.Format("{0:00-00-00}", Convert.ToInt32(r.ItemArray[1].ToString())), r.ItemArray[2],
                r.ItemArray[3], r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9],
                r.ItemArray[10], r.ItemArray[11], r.ItemArray[12], r.ItemArray[13], r.ItemArray[14]);
            }

            return retorno;
        }

        public DataTable cargarTiposDeExamenPadre(string idMotivoConsulta)
        {
            if (string.IsNullOrWhiteSpace(idMotivoConsulta))
                return new DataTable();

            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(
               @"select e.* from dbo.Especialidad e
        LEFT JOIN dbo.EspecialidadesEliminadas eel ON e.id = eel.id
        where e.descripcion <> 'VISITAS' and e.idMotivoConsulta = " + idMotivoConsulta + @"
        and e.Padre = 1 
        and e.estado = 1
        and eel.id IS NULL
        order by CASE WHEN ISNUMERIC(e.codigo) = 1 THEN CONVERT(int, e.codigo) ELSE 999999 END, e.codigo");

            return dt;
        }

        public Entidades.Resultado ActualizarNombreSubtipo(string idSubtipo, string nuevoNombre)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // Validar que el nuevo nombre no esté vacío
                if (string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    resultado.Modo = -1;
                    resultado.Mensaje = "El nombre del subtipo no puede estar vacío.";
                    return resultado;
                }

                // Sanitizar el nombre para evitar SQL injection
                string nombreSeguro = nuevoNombre.Replace("'", "''").Trim();

                // Actualizar la descripción en la tabla Especialidad
                string sql = $@"UPDATE dbo.Especialidad 
                    SET descripcion = '{nombreSeguro}' 
                    WHERE id = '{idSubtipo}' AND Padre = 0";

                SQLConnector.EjecutarConsulta(sql);
                resultado.Modo = 1;
                resultado.Mensaje = $"Subtipo actualizado a: '{nuevoNombre}'";

                System.Diagnostics.Debug.WriteLine($"✓ Subtipo actualizado: {idSubtipo} -> {nuevoNombre}");
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = $"Error al actualizar el nombre del subtipo: {ex.Message}";
                System.Diagnostics.Debug.WriteLine($"ERROR en ActualizarNombreSubtipo: {ex.Message}");
            }
            return resultado;
        }
    


        // Devuelve la descripción de la especialidad por ID
        public string DescripcionEspecialidad(string idEspecialidad)
        {
            string strSQL = "SELECT descripcion FROM dbo.Especialidad WHERE id = '" + idEspecialidad + "'";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "";
        }

        // Devuelve el ID del padre de una especialidad (subtipo)
        public string ObtenerIdPadreEspecialidad(string idSubtipo)
        {
            string strSQL = "SELECT IdPadre FROM dbo.Especialidad WHERE id = '" + idSubtipo + "'";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return null;
        }

        public DataTable cargarMotivosDeConsulta()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.MotivoDeConsulta
            where nombre <> 'VISITAS' AND ISNULL(estado, 1) = 1");
        }

        public DataTable cargarMotivosDeConsultaExAptitud()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.MotivoDeConsulta 
                where nombre <> 'VISITAS' AND nombre <> 'PREVENTIVA' AND nombre <> 'LABORAL' AND ISNULL(estado, 1) = 1");
        }

        public DataTable cargarMotivosDeConsultaTipoExamen()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.MotivoDeConsulta 
            where nombre <> 'VISITAS' AND ISNULL(estado, 1) = 1
            ORDER BY id ASC");
        }

        /// <summary>
        /// NIVEL 1: Devuelve las Especialidades padre (Padre=1) para un MotivoDeConsulta
        /// Ej: CARDIOLOGÍA, NEUMOLOGÍA, etc. dentro de PREVENTIVA/LABORAL
        /// </summary>
        public DataTable cargarNivel1Especialidad(string idMotivoConsulta)
        {
            if (!int.TryParse(idMotivoConsulta, out int id))
                return new DataTable();

            return SQLConnector.obtenerTablaSegunConsultaString(
                @"SELECT * FROM dbo.Especialidad
          WHERE descripcion <> 'VISITAS'
            AND idMotivoConsulta = " + id + @"
            AND Padre = 1
            AND estado = 1
            AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
          ORDER BY LOWER(descripcion)");
        }
        /// <summary>
        /// Verifica si un ID de especialidad tiene hijos (sub-elementos)
        /// Retorna DataTable vacío si es un EXAMEN FINAL, o con filas si tiene hijos
        public DataTable cargarNivel2Especialidad(string idPadre)
        {
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(@"
              SELECT * FROM dbo.Especialidad
              WHERE Padre = 0 
              AND IdPadre = '" + idPadre + @"'
              AND estado = 1
              AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
              ORDER BY LOWER(descripcion)");
            if (!dt.Columns.Contains("id") && dt.Columns.Contains("Id"))
                dt.Columns["Id"].ColumnName = "id";

            // Debug: imprimir el orden de los subtipos antes de retornar
            foreach (DataRow dr in dt.Rows)
            {
                System.Diagnostics.Debug.WriteLine($"Subtipo DB: {dr["descripcion"]}");
            }

            return dt;
        }

        /// <summary>
        /// ALIAS: cargarNivel3Especialidad es un alias para cargarNivel2Especialidad
        /// Devuelve los Subtipos (Nivel 3) dentro de un Tipo (Nivel 2)
        /// WHERE Padre = 0 AND IdPadre = @idTipo
        /// </summary>
        public DataTable cargarNivel3Especialidad(string idTipo)
        {
            return cargarNivel2Especialidad(idTipo);
        }
        public Entidades.Resultado DesactivarTodosLosSubtiposPorMotivo(string idMotivoConsulta)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                if (!int.TryParse(idMotivoConsulta, out int idMotivo))
                {
                    resultado.Modo = -1;
                    resultado.Mensaje = "ID de motivo inválido.";
                    return resultado;
                }

                string sql = $@"UPDATE dbo.Especialidad 
                                    SET estado = 0 
                                    WHERE Padre = 0 
                                      AND idMotivoConsulta = {idMotivo}
                                      AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)";
                SQLConnector.EjecutarConsulta(sql);
                resultado.Modo = 1;
                resultado.Mensaje = "Todos los subtipos del motivo han sido desactivados correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al desactivar subtipos: " + ex.Message;
            }
            return resultado;
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

                // Validar conversión segura del código
                if (int.TryParse(tipoExamen.Rows[0][1].ToString(), out int codigo))
                {
                    retorno.Codigo = codigo;
                }
                else
                {
                    retorno.Codigo = 0;
                }

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


        public Entidades.Resultado editarSubtipoExamen(Entidades.TipoExamen entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateTipoExamen = SQLConnector.generarListaParaProcedure("@id",
                "@descripcion", "@idMotivoConsulta", "@precioBase", "@descripcionInformes");
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

        public Entidades.Resultado editarTipoExamen(Entidades.TipoExamen entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> updateTipoExamen = SQLConnector.generarListaParaProcedure("@id",
                "@descripcion", "@idMotivoConsulta", "@precioBase", "@descripcionInformes");
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
                    "@idMotivoConsulta", "@precioBase", "@descripcionInformes", "@codigo");
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

        public Entidades.Resultado crearTipoExamenHijo(Entidades.TipoExamen entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> newTipoExamen = SQLConnector.generarListaParaProcedure("@id",
               "@descripcion", "@idMotivoConsulta", "@precioBase", "@descripcionInformes", "@codigo", "@Padre", "@IdPadre", "@tipo");

                SQLConnector.executeProcedure("sp_Especialidad_InsertRapidoHijo",
                    newTipoExamen,
                    entidad.Id,
                    entidad.Descripcion,
                    entidad.IdMotivoConsulta,
                    entidad.PrecioBase,
                    entidad.DescripcionInformes,
                    entidad.Codigo.ToString("00"),
                    0,  // @Padre = 0 (es HIJO)
                    entidad.IdPadre,
                    entidad.Tipo ?? (object)DBNull.Value // <-- Aquí pasas el tipo
                );

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

        public Entidades.Resultado crearTipoExamenPadre(Entidades.TipoExamen entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                // Para crear una especialidad PADRE, usamos sp_Especialidad_InsertRapidoPadre
                // que inserta con Padre = 1 e IdPadre = NULL
                List<string> parameterNames = SQLConnector.generarListaParaProcedure(
                    "@id", "@descripcion", "@idMotivoConsulta", "@precioBase",
                    "@descripcionInformes", "@codigo", "@Padre", "@IdPadre", "@estado");

                SQLConnector.executeProcedure("sp_Especialidad_InsertRapidoPadre",
                    parameterNames,
                    entidad.Id,
                    entidad.Descripcion,
                    entidad.IdMotivoConsulta,
                    entidad.PrecioBase,
                    entidad.DescripcionInformes,
                    entidad.Codigo.ToString("00"),
                    1,  // @Padre = 1
                    DBNull.Value,  // @IdPadre = null
                    entidad.Estado  // Nuevo parámetro estado
                );

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
            cargarValoresTablaActualizacion(entidad.QuimicaHematica, ref r);
            cargarValoresTablaActualizacion(entidad.Serologia, ref r);
            cargarValoresTablaActualizacion(entidad.PerfilLipidico, ref r);
            cargarValoresTablaActualizacion(entidad.Bacteriologia, ref r);
            cargarValoresTablaActualizacion(entidad.Orina, ref r);
            cargarValoresTablaActualizacion(entidad.LaboralesBasicas, ref r);
            cargarValoresTablaActualizacion(entidad.CraneoYMSuperior, ref r);
            cargarValoresTablaActualizacion(entidad.TroncoYPelvis, ref r);
            cargarValoresTablaActualizacion(entidad.MiembroInferior, ref r);
            cargarValoresTablaActualizacion(entidad.EstComplementarios, ref r);
            tablaAEnviar.Rows.Add(r);

            List<string> lista = SQLConnector.generarListaParaProcedure("@idEspecialidad", "@item1", "@item2",
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
            SQLConnector.executeProcedure("sp_EstudiosPorTipoExamen_Update", lista, entidad.Id,
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
            for (int i = 0; i <= 96; i++)
            {
                retorno.Columns.Add(i.ToString());
                retorno.Columns[i].DataType = System.Type.GetType("System.Boolean");
            }
            return retorno;
        }

        private void cargarValoresTablaActualizacion(DataTable tabla, ref DataRow tablaActualizacion)
        {
            foreach (DataRow r in tabla.Rows)
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
            DataTable codigos = SQLConnector.obtenerTablaSegunConsultaString(@"
                SELECT TOP 1 codigo 
                FROM dbo.Especialidad
                WHERE ISNUMERIC(codigo) = 1
                ORDER BY CASE 
                    WHEN ISNUMERIC(codigo) = 1 THEN CONVERT(int, codigo) 
                    ELSE 999999 
                END DESC");

            if (codigos.Rows.Count > 0 && int.TryParse(codigos.Rows[0][0].ToString(), out int codigo))
            {
                // ✅ SIN LÍMITE - Retorna el siguiente código
                return codigo + 1;
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
            retorno.Columns.Add("OrdenFormulario");

            retorno.Columns[2].DataType = System.Type.GetType("System.Boolean");

            DataRow[] dr = items.Select("ordenFormulario = " + ordenFormulario.ToString());

            foreach (DataRow r in dr)
            {
                int codigoItem = Convert.ToInt16(r.ItemArray[6].ToString()) + 1;
                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[6].ToString(), false, r.ItemArray[2].ToString(), ordenFormulario);
            }
            return retorno;
        }

        /// <summary>
        /// ✅ NUEVO MÉTODO: Devuelve TODOS los items (96-97) sin filtrar por categoría
        /// Para usar en FrmSeleccionarItems donde se muestran todos juntos
        /// </summary>
        public DataTable cargarTodosLosItems()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Id");
            retorno.Columns.Add("Codigo");
            retorno.Columns.Add("Estado", typeof(bool));
            retorno.Columns.Add("Item");
            retorno.Columns.Add("OrdenFormulario");

            // Validar que items existe y tiene datos
            if (items == null || items.Rows.Count == 0)
            {
                return retorno;  // Retornar vacío si no hay items
            }

            // Cargar TODOS los items ordenados
            try
            {
                foreach (DataRow r in items.Rows)
                {
                    // Validar que existan los índices
                    if (r.ItemArray.Length < 8)
                        continue;

                    retorno.Rows.Add(
                        r.ItemArray[0]?.ToString() ?? "",        // Id
                        r.ItemArray[6]?.ToString() ?? "",        // Codigo
                        false,                                   // Estado (tipo bool)
                        r.ItemArray[2]?.ToString() ?? "",        // Item (nombre)
                        r.ItemArray[7]?.ToString() ?? "0"        // OrdenFormulario
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en cargarTodosLosItems: " + ex.Message);
            }

            return retorno;
        }

        public Entidades.Resultado eliminarTipoExamen(string idTipoExamen)
        {
            // DELEGADO a eliminarTipoExamenPadre para mantener validaciones consistentes
            // Este método es mantenido por compatibilidad hacia atrás
            return eliminarTipoExamenPadre(idTipoExamen);
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

        /// <summary>
        /// Elimina los estudios asociados a un TipoExamenDePaciente específico
        /// </summary>
        public void eliminarEstudiosPorExamen(Guid idTipoExamenPaciente)
        {
            List<string> deleteEstudios = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_EstudiosPorExamen_Delete", deleteEstudios, idTipoExamenPaciente);
        }

        public bool verificarSiEstaModificado(Entidades.TipoExamen tipoExamen)
        {
            Entidades.TipoExamen examenPredeterminado = cargarEntidad(tipoExamen.Id.ToString());

            // Validación: Si no se pudo cargar el examen predeterminado, no se modificó
            if (examenPredeterminado == null)
            {
                System.Diagnostics.Debug.WriteLine($"[ADVERTENCIA] verificarSiEstaModificado: No se encontró examen predeterminado para ID {tipoExamen.Id}");
                return false;
            }

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
                retorno.Clinico = cargarTablaItemTipoExamenPaciente(estudiosPorExamen, 1);
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

        // GRV - Modificado: Filtra items excepto item38 para preventivas sin RX
        private DataTable cargarTablaItemTipoExamenPaciente2(DataTable estudiosPorTipoExamen, int nroOrden, bool blnTieneRX)
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
                    if (dr.Length > 0 && dr[0][3].ToString() == nroOrden.ToString())
                    {
                        bool valor = (contador == 39 && !blnTieneRX) ? false : Convert.ToBoolean(obj);
                        retorno.Rows.Add(dr[0][0].ToString(), dr[0][6].ToString(), valor, dr[0][2].ToString(), dr[0][1].ToString());
                    }
                }
                contador++;
            }
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
            if (entidad.Modificado) { modificado = "(*)"; }
            List<string> updateImporteYModificado = SQLConnector.generarListaParaProcedure("@id", "@modificado", "@importe");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateModificadoEImporte", updateImporteYModificado,
                entidad.IdTipoExamenPaciente, modificado, entidad.PrecioBase);

            DataTable tablaAEnviar = crearTablaActualizacion();
            DataRow r = tablaAEnviar.NewRow();
            cargarValoresTablaActualizacion(entidad.Clinico, ref r);
            cargarValoresTablaActualizacion(entidad.Hematologia, ref r);
            cargarValoresTablaActualizacion(entidad.QuimicaHematica, ref r);
            cargarValoresTablaActualizacion(entidad.Serologia, ref r);
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
        public DataTable ListaEstudioPorTipoExamen(Guid idTipoExamen)
        {
            string strSQL = "";

            //strSQL = "SELECT * FROM dbo.EstudiosPorTipoExamen";
            strSQL = @"SELECT ETE.* FROM 
                      dbo.EstudiosPorTipoExamen ETE
                      INNER JOIN Especialidad E ON e.id = ETE.idEspecialidad
                      WHERE e.Padre <> 1";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListaEstudioPorTipoExamen()
        {
            string strSQL = "";

            //strSQL = "SELECT * FROM dbo.EstudiosPorTipoExamen";
            strSQL = @"SELECT ETE.* FROM 
                      dbo.EstudiosPorTipoExamen ETE
                      INNER JOIN Especialidad E ON e.id = ETE.idEspecialidad
                      WHERE e.Padre <> 1";

            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool VerificaNombreRepetido(string strDescripcionEspecialidad)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "select descripcion from dbo.Especialidad WHERE descripcion = '" + strDescripcionEspecialidad.Replace("'", "''") + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                // ❌ PROBLEMA: Encuentra incluso el nombre actual si es edición
                return true;
            }
            return false;
        }

        // Devuelve el idMotivoConsulta de una especialidad subtipo (Padre=0)
        public string ObtenerIdMotivoDeSubtipo(string idEspecialidad)
        {
            if (string.IsNullOrEmpty(idEspecialidad))
                return null;
            string sql = $"SELECT idMotivoConsulta FROM dbo.Especialidad WHERE id = '{idEspecialidad}' AND Padre = 0";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Contains("idMotivoConsulta"))
                return dt.Rows[0]["idMotivoConsulta"].ToString();
            return null;
        }

        public bool VerificaNombreRepetidos(string strDescripcionEspecialidad, Guid idActual)
        {
            string strSQL = "";
            DataTable dt = null;

            // ✅ EXCLUIR el ID actual de la búsqueda
            strSQL = $@"SELECT descripcion, id FROM dbo.Especialidad 
                        WHERE descripcion = '{strDescripcionEspecialidad.Replace("'", "''")}'
                        AND id <> '{idActual}'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                // ✅ Existe OTRO examen con ese nombre (diferente ID)
                return true;
            }
            return false;
        }

        public bool VerificaNombreRepetidoEnPadre(string strDescripcionEspecialidad, string idPadre)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "select descripcion from dbo.Especialidad WHERE id NOT IN (SELECT id from dbo.EspecialidadesEliminadas) AND Padre = '0' AND IdPadre = '" + idPadre + "' AND descripcion = '" + strDescripcionEspecialidad.Replace("'", "''") + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (strDescripcionEspecialidad == dt.Rows[i][0].ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void EliminarEspecialidad(string strIdEspecialidad)
        {
            string strSQL = "";

            strSQL = "DELETE dbo.Especialidad WHERE id = '" + strIdEspecialidad + "'";

            SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public string ObtenerMotivoConsulta(string strIdEspecialidad)
        {
            string strSQL = "";
            DataTable dt = null;
            string strResultado = "";

            strSQL = "SELECT idMotivoConsulta FROM dbo.Especialidad WHERE id = '" + strIdEspecialidad + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strResultado = dt.Rows[i][0].ToString();
                }
            }

            return strResultado;
        }

        public DataTable FiltrarMotivoConsulta(string strId)
        {
            string strSQL = "";
            DataTable dt = null;

            strSQL = "SELECT * from dbo.MotivoDeConsulta WHERE id = " + strId;
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        /// <summary>
        /// Carga los items (estudios) desde la tabla EstudiosPorTipoExamen para un examen específico
        /// Retorna DataTable con columnas: Id, Codigo, Estado, Item, NombreCompleto, ordenFormulario
        /// </summary>
        public DataTable CargarItemsDesdeEstudiosPorExamen(Guid idEspecialidad)
        {
            // Obtiene la fila de EstudiosPorTipoExamen para ese id
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(
                "SELECT * FROM EstudiosPorTipoExamen WHERE idEspecialidad = '" + idEspecialidad.ToString() + "'"
            );

            // Obtiene todos los items para mapear nombre/codigo
            DataTable dtItems = SQLConnector.obtenerTablaSegunConsultaString(
                "SELECT codigo, nombreCompleto, ordenFormulario FROM Items ORDER BY ordenFormulario, codigo"
            );

            DataTable resultado = new DataTable();
            resultado.Columns.Add("Codigo");
            resultado.Columns.Add("Estado", typeof(bool));
            resultado.Columns.Add("Item");
            resultado.Columns.Add("OrdenFormulario", typeof(int));

            if (dt.Rows.Count > 0)
            {
                DataRow examenRow = dt.Rows[0];
                foreach (DataRow itemRow in dtItems.Rows)
                {
                    string codigo = itemRow["codigo"].ToString();
                    string nombre = itemRow["nombreCompleto"].ToString();
                    int orden = Convert.ToInt32(itemRow["ordenFormulario"]);

                    bool estado = false;
                    // Construir nombre de columna: item1, item2, item3, etc.
                    string nombreColumna = "item" + codigo;
                    if (dt.Columns.Contains(nombreColumna))
                    {
                        var valor = examenRow[nombreColumna];
                        estado = valor != DBNull.Value && Convert.ToBoolean(valor);
                    }
                    resultado.Rows.Add(codigo, estado, nombre, orden);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Carga los subtipos (especialidades) para una especialidad padre
        /// </summary>
        public DataTable cargarSubtipos(string idEspecialidad)
        {
            if (string.IsNullOrWhiteSpace(idEspecialidad))
                return new DataTable();

            return SQLConnector.obtenerTablaSegunConsultaString(
                $@"SELECT 
                    id, 
                    descripcion
                FROM dbo.Especialidad 
                WHERE IdPadre = '{idEspecialidad}' 
                AND Padre = 0 
                ORDER BY descripcion"
            );
        }



        /*
        public DataTable cargarSubtiposPorDia(string idEspecialidad, string diaSemana)
        {
            if (string.IsNullOrWhiteSpace(idEspecialidad) || string.IsNullOrWhiteSpace(diaSemana))
                return new DataTable();

            string columnaFiltro = diaSemana.ToLower() switch
            {
                "lunes" => "lunes",
                "martes" => "martes",
                "miercoles" => "miercoles",
                "jueves" => "jueves",
                "viernes" => "viernes",
                _ => "lunes"
            };

            return SQLConnector.obtenerTablaSegunConsultaString(
                $@"SELECT 
                    id, 
                    descripcion
                FROM dbo.Especialidad 
                WHERE IdPadre = '{idEspecialidad}' 
                AND Padre = 0 
                AND {columnaFiltro} = 1
                ORDER BY descripcion"
            );
        }
        */


        /*
        public Entidades.Resultado actualizarDiasSubtipo(
            string idSubtipo, 
            bool lunes, 
            bool martes, 
            bool miercoles, 
            bool jueves, 
            bool viernes)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> parametros = SQLConnector.generarListaParaProcedure(
                    "@id", "@lunes", "@martes", "@miercoles", "@jueves", "@viernes");

                SQLConnector.executeProcedure(
                    "sp_Especialidad_ActualizarDias",
                    parametros,
                    new Guid(idSubtipo),
                    lunes ? 1 : 0,
                    martes ? 1 : 0,
                    miercoles ? 1 : 0,
                    jueves ? 1 : 0,
                    viernes ? 1 : 0);

                retorno.Modo = 1;
                retorno.Mensaje = "Días actualizados correctamente";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = "Error al actualizar días: " + ex.Message;
                return retorno;
            }
        }
        */

        /// <summary>
        /// Elimina un Tipo Examen PADRE (Padre=1) con validaciones de seguridad
        /// Retorna un Resultado indicando éxito o error
        /// </summary>
        public Entidades.Resultado eliminarTipoExamenPadre(string idTipoExamen)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                Guid guidId = new Guid(idTipoExamen);

                // Validar que sea un PADRE
                DataTable dtValidar = SQLConnector.obtenerTablaSegunConsultaString(
                    $"SELECT Padre FROM dbo.Especialidad WHERE id = '{guidId}'");

                if (dtValidar.Rows.Count == 0)
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = "El Tipo de Examen no existe";
                    return retorno;
                }

                // Verificar que sea PADRE (Padre = 1)
                string padreValue = dtValidar.Rows[0]["Padre"].ToString().Trim();

                if (padreValue != "1" && padreValue.ToLower() != "true")
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = "Este elemento no es un Tipo Examen PADRE. Solo se pueden eliminar Tipos Padres.";
                    return retorno;
                }

                // Validar que no tenga HIJOS (subtipos)
                DataTable dtHijos = SQLConnector.obtenerTablaSegunConsultaString(
                    $"SELECT COUNT(*) as total FROM dbo.Especialidad WHERE IdPadre = '{guidId}' AND Padre = 0");

                if (dtHijos.Rows.Count > 0 && Convert.ToInt32(dtHijos.Rows[0]["total"]) > 0)
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = "No se puede eliminar este Tipo de Examen porque tiene Subtipos asociados. Elimine primero los Subtipos.";
                    return retorno;
                }

                // Validar que no tenga consultas/turnos
                DataTable consultasYTurnos = SQLConnector.obtenerTablaSegunConsultaString(
                    $"SELECT COUNT(*) as total FROM dbo.TipoExamenDePaciente WHERE idEspecialidad = '{guidId}'");

                if (consultasYTurnos.Rows.Count > 0 && Convert.ToInt32(consultasYTurnos.Rows[0]["total"]) > 0)
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = "El Tipo de Examen ya tiene consultas y/o turnos asignados. No se puede eliminar.";
                    return retorno;
                }

                // Proceder con la eliminación
                try
                {
                    // Eliminar EstudiosPorExamen (usar el nombre correcto del procedimiento)
                    List<string> deleteEstudios = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                    SQLConnector.executeProcedure("sp_EstudiosPorExamen_Delete", deleteEstudios, guidId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error eliminando EstudiosPorExamen: {ex.Message}");
                }

                try
                {
                    // Eliminar clubes por examen
                    eliminarClubesPorExamen(guidId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error eliminando clubes: {ex.Message}");
                }

                try
                {
                    // Eliminar empresa por examen
                    eliminarEmpresaPorExamen(guidId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error eliminando empresa: {ex.Message}");
                }

                // Eliminar el tipo examen padre
                List<string> deleteTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_Especialidad_DeleteRapido", deleteTipoExamen, guidId);

                retorno.Modo = 1;
                retorno.Mensaje = "Tipo de Examen PADRE eliminado correctamente";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = $"Error al eliminar Tipo de Examen: {ex.Message}";
                return retorno;
            }
        }

        /// <summary>
        /// Elimina un Subtipo (Padre=0) con validaciones de seguridad
        /// Solo elimina si Padre=0
        /// Retorna un Resultado indicando éxito o error
        /// </summary>
        public Entidades.Resultado eliminarSubtipo(string idSubtipo)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                Guid guidId = new Guid(idSubtipo);

                // Obtener datos del elemento
                DataTable dtValidar = SQLConnector.obtenerTablaSegunConsultaString(
                    $"SELECT Padre, IdPadre, descripcion FROM dbo.Especialidad WHERE id = '{guidId}'");

                if (dtValidar.Rows.Count == 0)
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = "El elemento no existe";
                    return retorno;
                }

                int esPadre = 0;
                string padreValue = dtValidar.Rows[0]["Padre"].ToString().Trim();
                if (padreValue == "0" || padreValue.ToLower() == "false")
                {
                    esPadre = 0;
                }
                else if (padreValue == "1" || padreValue.ToLower() == "true")
                {
                    esPadre = 1;
                }
                string descripcion = dtValidar.Rows[0]["descripcion"].ToString();

                // VALIDACIÓN ESTRICTA: Solo debe ser Padre=0 (es HIJO/SUBTIPO)
                if (esPadre != 0)
                {
                    retorno.Modo = -1;
                    retorno.Mensaje = $"Este elemento NO es un Subtipo. Es un Tipo Examen PADRE (Padre=1). Use el botón 'Eliminar' de la sección de Tipos.";
                    return retorno;
                }

                // Proceder con la eliminación
                try
                {
                    // Eliminar turno/consultas asociadas (TipoExamenDePaciente)
                    SQLConnector.EjecutarConsulta(
                        $"DELETE FROM dbo.TipoExamenDePaciente WHERE idEspecialidad = '{guidId}'");
                }
                catch (Exception exDelete)
                {
                    System.Diagnostics.Debug.WriteLine($"Error en DELETE TipoExamenDePaciente: {exDelete.Message}");
                    // Continuar sin fallar
                }

                try
                {
                    // Eliminar EstudiosPorExamen (usar el nombre correcto del procedimiento)
                    List<string> deleteEstudios = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                    SQLConnector.executeProcedure("sp_EstudiosPorExamen_Delete", deleteEstudios, guidId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error eliminando EstudiosPorExamen: {ex.Message}");
                }

                try
                {
                    // Eliminar clubes por examen
                    eliminarClubesPorExamen(guidId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error eliminando clubes: {ex.Message}");
                }

                try
                {
                    // Eliminar empresa por examen
                    eliminarEmpresaPorExamen(guidId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error eliminando empresa: {ex.Message}");
                }

                // Eliminar el subtipo
                List<string> deleteSubtipo = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                SQLConnector.executeProcedure("sp_Especialidad_DeleteRapido", deleteSubtipo, guidId);

                retorno.Modo = 1;
                retorno.Mensaje = $"Subtipo '{descripcion}' eliminado correctamente";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = $"Error al eliminar Subtipo: {ex.Message}";
                return retorno;
            }
        }        /// <summary>
                 /// Carga SOLO los Tipos de Examen PADRE (Padre=1) para un Motivo de Consulta
                 /// Sin incluir Subtipos (Padre=0)
                 /// Retorna DataTable con id, descripcion, Padre, IdPadre
                 /// </summary>
        public DataTable cargarTiposExamenPadreOnly(string idMotivoConsulta)
        {
            if (!int.TryParse(idMotivoConsulta, out int id))
                return new DataTable();

            return SQLConnector.obtenerTablaSegunConsultaString(
                $@"SELECT id, codigo, descripcion, idMotivoConsulta, precioBase, descripcionInformes, Padre, IdPadre
        FROM dbo.Especialidad
        WHERE descripcion <> 'VISITAS' 
        AND idMotivoConsulta = {id}
        AND Padre = 1
        ORDER BY CASE WHEN ISNUMERIC(codigo) = 1 THEN CONVERT(int, codigo) ELSE 999999 END, codigo");
        }

        public Entidades.Resultado ActualizarEstadoEspecialidad(string idEspecialidad, int estado)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                var parametros = SQLConnector.generarListaParaProcedure("@idEspecialidad", "@estado");
                SQLConnector.executeProcedure("sp_Especialidad_ActualizarEstado", parametros, new Guid(idEspecialidad), estado);
                resultado.Modo = 1;
                resultado.Mensaje = "Estado actualizado correctamente.";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al actualizar estado: " + ex.Message;
            }
            return resultado;
        }

        public Entidades.Resultado ActualizarEstadoEspecialidadDirecto(string idEspecialidad, int estado)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                string sql = $"UPDATE Especialidad SET estado = {estado} WHERE id = '{idEspecialidad}'";
                SQLConnector.obtenerTablaSegunConsultaString(sql);
                resultado.Modo = 1;
                resultado.Mensaje = $"Estado actualizado correctamente (directo) a {(estado == 1 ? "activo" : "inactivo")}.";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al actualizar estado: " + ex.Message;
            }
            return resultado;
        }

        // ...existing code...
        public DataTable ObtenerMotivoTipoSubtipoExamenPorMotivo(int idMotivoConsulta, string idResaltado = null)
        {
            string where = idMotivoConsulta > 0 ? $"WHERE m.id = {idMotivoConsulta}" : "";

            // Ordenar por id de motivo, luego por descripción de tipo y subtipo
            string orderBy = "ORDER BY m.id, e.descripcion, s.descripcion";

            if (!string.IsNullOrEmpty(idResaltado))
            {
                orderBy = $@"ORDER BY 
    m.id, e.id, 
    CASE WHEN s.id = '{idResaltado}' THEN 0 ELSE 1 END, 
    s.id";
            }

            string query = $@"
SELECT 
    m.nombre AS MotivoConsulta,
    ISNULL(m.estado, 1) AS EstadoMotivo,
    e.descripcion AS TipoExamen,
    s.descripcion AS SubtipoExamen,
    s.precioBase AS PrecioSubtipo,
    e.estado AS EstadoTipo,
    s.estado AS EstadoSubtipo,
    e.id AS IdTipo,
    s.id AS IdSubtipo,
    m.id AS idMotivoConsulta,
    e.Padre AS PadreTipo,
    s.Padre AS PadreSubtipo
FROM 
    MotivoDeConsulta m
LEFT JOIN 
    Especialidad e ON m.id = e.idMotivoConsulta AND e.Padre = 1 AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
LEFT JOIN 
    Especialidad s ON s.IdPadre = e.id AND s.Padre = 0 AND s.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
{where}
{orderBy}";
            return SQLConnector.obtenerTablaSegunConsultaString(query);
        }
        // ...existing code...
        public Entidades.Resultado CrearMotivoDeConsulta(string nombre, string identificadorInterno, int estado = 1)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // ✅ Usar INSERT directo para incluir el estado
                string query = $@"INSERT INTO MotivoDeConsulta (nombre, identificadorInterno, estado) 
                                  VALUES ('{nombre.Replace("'", "''")}', '{identificadorInterno.Replace("'", "''")}', {estado})";
                SQLConnector.EjecutarConsulta(query);
                resultado.Modo = 1;
                resultado.Mensaje = "Motivo de consulta creado correctamente";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al crear motivo de consulta: " + ex.Message;
            }
            return resultado;
        }

        public string ObtenerIdPadreSiTieneSubtiposActivos(string idSubtipo)
        {
            if (string.IsNullOrWhiteSpace(idSubtipo))
                return null;

            // Obtener el IdPadre del subtipo
            string queryPadre = $"SELECT IdPadre FROM Especialidad WHERE id = '{idSubtipo}'";
            var dtPadre = SQLConnector.obtenerTablaSegunConsultaString(queryPadre);

            if (dtPadre == null || dtPadre.Rows.Count == 0 || dtPadre.Rows[0]["IdPadre"] == DBNull.Value)
                return null;

            string idPadre = dtPadre.Rows[0]["IdPadre"].ToString();

            // Verificar si el padre tiene subtipos activos
            string queryActivos = $@"
        SELECT COUNT(*) FROM Especialidad
        WHERE IdPadre = '{idPadre}' AND Padre = 0 AND estado = 1";
            var dtActivos = SQLConnector.obtenerTablaSegunConsultaString(queryActivos);

            if (dtActivos != null && dtActivos.Rows.Count > 0 && Convert.ToInt32(dtActivos.Rows[0][0]) > 0)
                return idPadre;

            return null;
        }

        public Entidades.Resultado ActivarPadrePorSubtipo(string idSubtipo)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                // Buscar el IdPadre del subtipo
                string queryPadre = $"SELECT IdPadre FROM Especialidad WHERE id = '{idSubtipo}'";
                var dt = SQLConnector.obtenerTablaSegunConsultaString(queryPadre);
                if (dt.Rows.Count > 0)
                {
                    string idPadre = dt.Rows[0]["IdPadre"].ToString();
                    // Activar el padre
                    string queryUpdate = $"UPDATE Especialidad SET estado = 1 WHERE id = '{idPadre}'";
                    SQLConnector.EjecutarConsulta(queryUpdate);
                    resultado.Modo = 1;
                    resultado.Mensaje = "Padre activado correctamente";
                }
                else
                {
                    resultado.Modo = 0;
                    resultado.Mensaje = "No se encontró el padre";
                }
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al activar padre: " + ex.Message;
            }
            return resultado;
        }

        // ✅ NUEVO: Actualizar estado de un motivo de consulta
        public Entidades.Resultado ActualizarEstadoMotivoConsulta(int idMotivoConsulta, int estado)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                string query = $"UPDATE MotivoDeConsulta SET estado = {estado} WHERE id = {idMotivoConsulta}";
                SQLConnector.EjecutarConsulta(query);
                resultado.Modo = 1;
                resultado.Mensaje = estado == 1 ? "Motivo de consulta activado" : "Motivo de consulta desactivado";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al actualizar estado: " + ex.Message;
            }
            return resultado;
        }
        public DataTable FiltrarTiposDeExamenPadrePorNombre(string idMotivoConsulta, string nombreTipoExamen)
        {
            if (!int.TryParse(idMotivoConsulta, out int id) || string.IsNullOrWhiteSpace(nombreTipoExamen))
                return new DataTable();

            string buscar = nombreTipoExamen.Replace("'", "''");
            string strSQL = $@"
        SELECT * FROM dbo.Especialidad
        WHERE descripcion <> 'VISITAS'
        AND idMotivoConsulta = {id}
        AND Padre = 1
        AND descripcion LIKE '%{buscar}%'
        ORDER BY descripcion";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable cargarTodosLosSubtiposActivos()
        {
            string strSQL = @"select e.* from dbo.Especialidad e
                where e.descripcion <> 'VISITAS' and e.Padre = 0 and e.estado = 1
                order by e.descripcion";
            return RetornarTipoExamenHijo(SQLConnector.obtenerTablaSegunConsultaString(strSQL));
        }
        public DataTable cargarTiposDeExamenPadreConSubtiposActivos(string idMotivoConsulta)
        {
            if (!int.TryParse(idMotivoConsulta, out int id))
                return new DataTable();

            string query = $@"
        SELECT e.*
        FROM dbo.Especialidad e
        WHERE e.descripcion <> 'VISITAS'
          AND e.idMotivoConsulta = {id}
          AND e.Padre = 1
          AND e.estado = 1
          AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
          AND EXISTS (
              SELECT 1 FROM dbo.Especialidad s
              WHERE s.IdPadre = e.id AND s.Padre = 0 AND s.estado = 1
                    AND s.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
          )
        ORDER BY e.descripcion";

            return SQLConnector.obtenerTablaSegunConsultaString(query);
        }


        /// <summary>
        /// Carga los Tipos de Examen PADRE (Padre=1) que están activos (estado=1) para un Motivo de Consulta.
        /// Retorna DataTable con todas las columnas de Especialidad.
        /// </summary>
        public DataTable cargarTiposExamenPadreActivos(string idMotivoConsulta)
        {
            if (!int.TryParse(idMotivoConsulta, out int id))
                return new DataTable();

            string query = $@"
        SELECT e.*
        FROM dbo.Especialidad e
        WHERE e.descripcion <> 'VISITAS'
          AND e.idMotivoConsulta = {id}
          AND e.Padre = 1
          AND e.estado = 1
          AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
        ORDER BY e.descripcion";

            return SQLConnector.obtenerTablaSegunConsultaString(query);
        }






        public Entidades.Resultado EliminarMotivoDeConsulta(int idMotivoConsulta)
        {
            var resultado = new Entidades.Resultado();
            try
            {
                List<string> parametros = SQLConnector.generarListaParaProcedure("@idMotivoConsulta");
                SQLConnector.executeProcedure("sp_MotivoDeConsulta_Delete", parametros, idMotivoConsulta);
                resultado.Modo = 1;
                resultado.Mensaje = "Motivo de consulta eliminado correctamente";
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = "Error al eliminar motivo de consulta: " + ex.Message;
            }
            return resultado;
        }
        public Entidades.Resultado crearTipoExamenHijoNivel4(Entidades.TipoExamen entidad)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                List<string> newTipoExamen = SQLConnector.generarListaParaProcedure("@id",
                    "@descripcion", "@idMotivoConsulta", "@precioBase", "@descripcionInformes", "@codigo", "@Padre", "@IdPadre");

                SQLConnector.executeProcedure("sp_Especialidad_InsertRapidoHijo",
                    newTipoExamen,
                    entidad.Id,
                    entidad.Descripcion,
                    entidad.IdMotivoConsulta,
                    entidad.PrecioBase,
                    entidad.DescripcionInformes,
                    entidad.Codigo.ToString("00"),
                    0,  // @Padre = 0 (es HIJO)
                    entidad.IdPadre);

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
        public DataTable ObtenerItemsPorSeccion(string seccion, int idMotivoConsulta)
        {
            string query = $@"
                SELECT 
                    i.codigo AS Codigo,
                    i.nombreCompleto AS Descripcion,
                    i.ordenFormulario AS Orden,
                    0 AS Estado, -- Puedes ajustar si tienes el estado en otra tabla
                    ss.Subseccion AS SubseccionNombre
                FROM Items i
                INNER JOIN SeccionSubseccion ss ON i.ordenFormulario = ss.ordenFormulario
                WHERE ss.Seccion = '{seccion}'
                ORDER BY ss.Subseccion, i.ordenFormulario, i.codigo";
            return SQLConnector.obtenerTablaSegunConsultaString(query);
        }

        /// <summary>
        /// Limpia todos los items del subtipo en BD (pone todos en 0, sin eliminar la fila)
        /// </summary>
        public void limpiarEstudiosPorSubtipo(string idSubtipo)
        {
            try
            {
                // Construir SQL para poner TODOS los items en 0
                string columnas = string.Join(", ", Enumerable.Range(1, 97).Select(i => $"item{i} = 0"));
                string sql = $"UPDATE dbo.EstudiosPorTipoExamen SET {columnas} WHERE idEspecialidad = '{idSubtipo}'";

                SQLConnector.EjecutarConsulta(sql);
                System.Diagnostics.Debug.WriteLine($"✓ Todos los items puestos en 0 para subtipo {idSubtipo}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en limpiarEstudiosPorSubtipo: {ex.Message}");
                throw;
            }
        }

        public bool EstaEspecialidadActiva(string idEspecialidad)
        {
            if (string.IsNullOrWhiteSpace(idEspecialidad))
                return false;

            try
            {
                string sql = $@"SELECT ISNULL(estado, 1) AS estado FROM dbo.Especialidad WHERE id = '{idEspecialidad}'";
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    var valor = dt.Rows[0]["estado"];
                    if (valor == DBNull.Value) return true;

                    // Puede guardarse como int (1/0) o como bool/texto
                    int estadoInt;
                    if (int.TryParse(valor.ToString(), out estadoInt))
                        return estadoInt == 1;

                    bool estadoBool;
                    if (bool.TryParse(valor.ToString(), out estadoBool))
                        return estadoBool;

                    return valor.ToString() == "1";
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR en EstaEspecialidadActiva: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Marca un item específico como 1 (true) para un subtipo en BD
        /// </summary>
        public void insertarEstudioPorSubtipo(string idSubtipo, int codigoItem, string descripcionItem, int orden)
        {
            try
            {
                // En EstudiosPorTipoExamen, cada item está en una columna: item1...item97
                string columnName = $"item{codigoItem}";
                string sql = $@"UPDATE dbo.EstudiosPorTipoExamen 
                    SET {columnName} = 1 
                    WHERE idEspecialidad = '{idSubtipo}'";

                SQLConnector.EjecutarConsulta(sql);
                System.Diagnostics.Debug.WriteLine($"✓ Item marcado: [{codigoItem}] {descripcionItem}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en insertarEstudioPorSubtipo: {ex.Message}");
                throw;
            }
        }
    }



}
