// Devuelve el idMotivoConsulta de una especialidad subtipo (Padre=0)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using Entidades;
using System.Data;

namespace CapaNegocioMepryl
// Nuevo método: cargar todos los subtipos activos de todos los motivos

{
    public class TipoExamen
    // Devuelve la descripción de la especialidad por ID

    {
        private CapaDatosMepryl.TipoExamen tipoExamen;



        public TipoExamen()
        {
            tipoExamen = new CapaDatosMepryl.TipoExamen();
        }

        public bool blnTieneRX(bool blnRX)
        {
            return tipoExamen.blnTieneRX = blnRX;
        }

        public string ObtenerIdMotivoDeSubtipo(string idEspecialidad)
        {
            return tipoExamen.ObtenerIdMotivoDeSubtipo(idEspecialidad);
        }


        public string ObtenerDescripcionEspecialidad(string idEspecialidad)
        {
            return tipoExamen.DescripcionEspecialidad(idEspecialidad);
        }
        public Entidades.Resultado ActualizarNombreSubtipo(string idSubtipo, string nuevoNombre)
        {
            return tipoExamen.ActualizarNombreSubtipo(idSubtipo, nuevoNombre);
        }

        // Devuelve el ID del padre de una especialidad (subtipo)
        public string ObtenerIdPadreEspecialidad(string idSubtipo)
        {
            return tipoExamen.ObtenerIdPadreEspecialidad(idSubtipo);
        }
        public DataTable cargarTiposDeExamen(string idMotivoConsulta)
        {
            return tipoExamen.cargarTiposDeExamen(idMotivoConsulta);
        }
        // ...existing code...

        // ✅ NUEVO MÉTODO: Cargar todos los tipos de examen padre con subtipos activos (sin filtrar por motivo)
        public DataTable cargarTodosLosTiposDeExamenPadreConSubtiposActivos()
        {
            return tipoExamen.cargarTodosLosTiposDeExamenPadreConSubtiposActivos();
        }
        // ...existing code...
        public DataTable cargarMotivosDeConsulta()
        {
            return tipoExamen.cargarMotivosDeConsulta();
        }

        public Entidades.Resultado ActivarTodosLosSubtipos(string idPadre)
        {
            return tipoExamen.ActivarTodosLosSubtipos(idPadre);
        }


        public Entidades.Resultado ActivarTodosLosSubtiposGlobal()
        {
            return tipoExamen.ActivarTodosLosSubtiposGlobal();
        }
        public Entidades.Resultado DesactivarSubtiposPorTipoYMotivo(string idTipoPadre, int idMotivoConsulta)
        {
            return tipoExamen.DesactivarSubtiposPorTipoYMotivo(idTipoPadre, idMotivoConsulta);
        }

        public Entidades.Resultado ActivarTodosLosSubtiposPorMotivo(string idMotivoConsulta)
        {
            return tipoExamen.ActivarTodosLosSubtiposPorMotivo(idMotivoConsulta);
        }
        public Entidades.TipoExamen cargarEntidad(string id)
        {
            return tipoExamen.cargarEntidad(id);
        }

        public Entidades.Resultado editarTipoExamen(Entidades.TipoExamen entidad)
        {
            return tipoExamen.editarTipoExamen(entidad);
        }

        public Entidades.TipoExamen cargarItems()
        {
            return tipoExamen.cargarItems();
        }

        public Entidades.Resultado crearTipoExamen(Entidades.TipoExamen entidad)
        {
            return tipoExamen.crearTipoExamen(entidad);
        }

        public Entidades.Resultado eliminarTipoExamen(string idTipoExamen)
        {
            return tipoExamen.eliminarTipoExamen(idTipoExamen);
        }

        public bool verificarSiEstaModificado(Entidades.TipoExamen te)
        {
            return tipoExamen.verificarSiEstaModificado(te);
        }

        public Entidades.TipoExamen cargarEstudiosPorExamen(string idTipoExamen)
        {
            return tipoExamen.cargarEstudiosPorExamen(idTipoExamen);
        }

        public Entidades.TipoExamen cargarTipoExamenSegunIdTurno(Guid idTurno)
        {
            return tipoExamen.cargarTipoExamenSegunIdTurno(idTurno);
        }

        public Entidades.TipoExamen cargarTipoExamenSegunIdConsulta(Guid idConsulta)
        {
            return tipoExamen.cargarTipoExamenSegunIdConsulta(idConsulta);
        }

        public void crearEstudiosPorExamen(Entidades.TipoExamen entidad)
        {
            tipoExamen.crearEstudiosPorExamen(entidad);
        }

        public void actualizarEstudiosPorExamen(Entidades.TipoExamen entidad)
        {
            tipoExamen.actualizarEstudiosPorExamen(entidad);
        }

        public Entidades.TipoExamen cargarEstudiosPorTipoExamen(string idTipoExamen)
        {
            return tipoExamen.cargarEstudiosPorTipoExamen(idTipoExamen);
        }

        public Entidades.TipoExamen cargarTipoExamenSegunId(Guid idTipoExamen)
        {
            return tipoExamen.cargarTipoExamenSegunId(idTipoExamen);
        }

        public void VerificaExamenPreventiva(bool blnTieneExamen, string strIdTipoExamen)
        {
            tipoExamen.VerificaExamenPreventiva(blnTieneExamen, strIdTipoExamen);
        }
        public DataTable cargarMotivosDeConsultaExAptitud()
        {
            return tipoExamen.cargarMotivosDeConsultaExAptitud();
        }

        public DataTable cargarMotivosDeConsultaTipoExamen()
        {
            return tipoExamen.cargarMotivosDeConsultaTipoExamen();
        }

        public Entidades.Resultado crearTipoExamenHijo(Entidades.TipoExamen entidad)
        {
            return tipoExamen.crearTipoExamenHijo(entidad);
        }

        public Entidades.Resultado crearTipoExamenPadre(Entidades.TipoExamen entidad)
        {
            return tipoExamen.crearTipoExamenPadre(entidad);
        }

        public DataTable cargarTiposDeExamenHijo(string idMotivoConsulta, string strIdPadre)
        {
            return tipoExamen.cargarTiposDeExamenHijo(idMotivoConsulta, strIdPadre);
        }
        public DataTable ListaEstudioPorTipoExamen(Guid idTipoExamen)
        {
            return tipoExamen.ListaEstudioPorTipoExamen(idTipoExamen);
        }

        public DataTable ListaEstudioPorTipoExamen()
        {
            return tipoExamen.ListaEstudioPorTipoExamen();
        }

        public string DescripcionEspecialidad(string strIDEspecialidad)
        {
            return tipoExamen.DescripcionEspecialidad(strIDEspecialidad);
        }

        public bool VerificaNombreRepetido(string strDescripcionEspecialidad)
        {
            return tipoExamen.VerificaNombreRepetido(strDescripcionEspecialidad);
        }

        public bool VerificaNombreRepetidoEnPadre(string strDescripcionEspecialidad, string idPadre)
        {
            return tipoExamen.VerificaNombreRepetidoEnPadre(strDescripcionEspecialidad, idPadre);
        }

        public void EliminarEspecialidad(string strIdEspecialidad)
        {
            tipoExamen.EliminarEspecialidad(strIdEspecialidad);
        }

        public DataTable cargarTiposDeExamenPadre(string idMotivoConsulta)
        {
            return tipoExamen.cargarTiposDeExamenPadre(idMotivoConsulta);
        }

        public DataTable cargarTiposDeExamenHijo(string idMotivoConsulta)
        {
            return tipoExamen.cargarTiposDeExamenHijo(idMotivoConsulta);
        }

        public DataTable cargarTiposDeExamenHijo(string idMotivoConsulta, string strBuscar, bool blnAtv)
        {
            return tipoExamen.cargarTiposDeExamenHijo(idMotivoConsulta, strBuscar, blnAtv);
        }

        public DataTable cargarTiposDeExamenFinales(string idMotivoConsulta, string strBuscar, bool blnAtv)
        {
            return tipoExamen.cargarTiposDeExamenFinales(idMotivoConsulta, strBuscar, blnAtv);
        }

        public string ObtenerMotivoConsulta(string strIdEspecialidad)
        {
            return tipoExamen.ObtenerMotivoConsulta(strIdEspecialidad);
        }


        public DataTable FiltrarMotivoConsulta(string strId)
        {
            return tipoExamen.FiltrarMotivoConsulta(strId);
        }

        public DataTable cargarNivel1Especialidad(string idMotivoConsulta)
        {
            return tipoExamen.cargarNivel1Especialidad(idMotivoConsulta);
        }

        public DataTable cargarNivel2Especialidad(string idPadre)
        {
            return tipoExamen.cargarNivel2Especialidad(idPadre);
        }
        public List<string> ObtenerSubtiposPorPadre(string idPadre)
        {
            var subtipos = new List<string>();
            var dt = tipoExamen.cargarSubtipos(idPadre);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    if (row["id"] != null)
                        subtipos.Add(row["id"].ToString());
                }
            }
            return subtipos;
        }
        public Entidades.Resultado DesactivarTodosLosSubtipos()
        {
            return tipoExamen.DesactivarTodosLosSubtipos();
        }

        /// <summary>
        /// Desactiva todos los subtipos (estado = 0) de un tipo padre específico.
        /// </summary>
        public Entidades.Resultado DesactivarTodosLosSubtipos(string idTipoPadre)
        {
            return tipoExamen.DesactivarTodosLosSubtipos(idTipoPadre);
        }

        // ✅ NUEVO MÉTODO: Cargar subtipos ACTIVOS (estado = 1)
        public DataTable cargarNivel2EspecialidadActivos(string idPadre)
        {
            return tipoExamen.cargarNivel2EspecialidadActivos(idPadre);
        }

        // ✅ Obtiene el IdPadre de un subtipo dado su ID
        public string ObtenerIdPadreDeSubtipo(string idSubtipo)
        {
            return tipoExamen.ObtenerIdPadreDeSubtipo(idSubtipo);
        }

        // ✅ Verifica si un tipo padre tiene subtipos activos
        public bool TieneSubtiposActivos(string idPadre)
        {
            return tipoExamen.TieneSubtiposActivos(idPadre);
        }

        public DataTable cargarNivel3Especialidad(string idPadre)
        {
            return tipoExamen.cargarNivel3Especialidad(idPadre);
        }

        public DataTable cargarSubtipos(string idEspecialidad)
        {
            return tipoExamen.cargarSubtipos(idEspecialidad);
        }

        public DataTable CargarItemsDesdeEstudiosPorExamen(Guid idEspecialidad)
        {
            return tipoExamen.CargarItemsDesdeEstudiosPorExamen(idEspecialidad);
        }

        public Entidades.Resultado eliminarTipoExamenPadre(string idTipoExamen)
        {
            return tipoExamen.eliminarTipoExamenPadre(idTipoExamen);
        }

        public Entidades.Resultado eliminarSubtipo(string idSubtipo)
        {
            return tipoExamen.eliminarSubtipo(idSubtipo);
        }

        public DataTable cargarTiposExamenPadreOnly(string idMotivoConsulta)
        {
            return tipoExamen.cargarTiposExamenPadreOnly(idMotivoConsulta);
        }

        public DataTable cargarTodosLosItems()
        {
            return tipoExamen.cargarTodosLosItems();
        }

        public Entidades.Resultado EliminarTipoExamen(Guid idTipoExamen)
        {
            return tipoExamen.eliminarTipoExamenPadre(idTipoExamen.ToString());
        }

        public Entidades.Resultado EliminarSubtipoExamen(Guid idSubtipo)
        {
            return tipoExamen.eliminarSubtipo(idSubtipo.ToString());
        }

        // Nuevo método para obtener motivo, tipo y subtipo de examen
        public DataTable ObtenerMotivoTipoSubtipoExamenPorMotivo(int idMotivoConsulta, string idSubtipoResaltado = null)
        {
            return tipoExamen.ObtenerMotivoTipoSubtipoExamenPorMotivo(idMotivoConsulta, idSubtipoResaltado);
        }
        // ✅ NUEVO: Actualizar días de la semana para un subtipo
        //public Entidades.Resultado actualizarDiasSubtipo(
        //    string idSubtipo,
        //    bool lunes,
        //    bool martes,
        //    bool miercoles,
        //    bool jueves,
        //    bool viernes)
        //{
        //    return tipoExamen.actualizarDiasSubtipo(idSubtipo, lunes, martes, miercoles, jueves, viernes);
        //}
        public Entidades.Resultado CrearMotivoDeConsulta(string nombre, string identificadorInterno, int estado = 1)
        {
            return tipoExamen.CrearMotivoDeConsulta(nombre, identificadorInterno, estado);
        }

        public Entidades.Resultado ActivarPadrePorSubtipo(string idSubtipo)
        {
            return tipoExamen.ActivarPadrePorSubtipo(idSubtipo);
        }

        // ✅ NUEVO: Actualizar estado de un motivo de consulta
        public Entidades.Resultado ActualizarEstadoMotivoConsulta(int idMotivoConsulta, int estado)
        {
            return tipoExamen.ActualizarEstadoMotivoConsulta(idMotivoConsulta, estado);
        }

        public Entidades.Resultado EliminarMotivoDeConsulta(int idMotivoConsulta)
        {
            return tipoExamen.EliminarMotivoDeConsulta(idMotivoConsulta);
        }

        // ✅ NUEVOS MÉTODOS: Guardar items del subtipo
        public void limpiarEstudiosPorSubtipo(string idSubtipo)
        {
            tipoExamen.limpiarEstudiosPorSubtipo(idSubtipo);
        }

        public void insertarEstudioPorSubtipo(string idSubtipo, int codigoItem, string descripcionItem, int orden)
        {
            tipoExamen.insertarEstudioPorSubtipo(idSubtipo, codigoItem, descripcionItem, orden);
        }

        // ✅ NUEVO MÉTODO: Actualizar estado de especialidad
        public Entidades.Resultado ActualizarEstadoEspecialidad(string idEspecialidad, int estado)
        {
            return tipoExamen.ActualizarEstadoEspecialidadDirecto(idEspecialidad, estado);
        }

        // ✅ NUEVO MÉTODO: Cargar tipos de examen padre con subtipos activos
        public DataTable cargarTiposDeExamenPadreConSubtiposActivos(string idMotivoConsulta)
        {
            return tipoExamen.cargarTiposDeExamenPadreConSubtiposActivos(idMotivoConsulta);
        }
        /// </summary>
        public DataTable cargarTiposExamenPadreActivos(string idMotivoConsulta)
        {
            return tipoExamen.cargarTiposExamenPadreActivos(idMotivoConsulta);
        }
        public Entidades.Resultado DesactivarTodosLosSubtiposPorMotivo(string idMotivoConsulta)
        {
            return tipoExamen.DesactivarTodosLosSubtiposPorMotivo(idMotivoConsulta);
        }


        // ✅ NUEVO MÉTODO: Cargar SOLO subtipos activos por tipo padre
        public DataTable cargarSubtiposActivosPorPadre(string idPadre)
        {
            return tipoExamen.cargarSubtiposActivosPorPadre(idPadre);
        }

        // ✅ NUEVO MÉTODO: Verificar nombre repetido con ID actual
        public bool VerificaNombreRepetidos(string strDescripcionEspecialidad, Guid idActual)
        {
            return tipoExamen.VerificaNombreRepetidos(strDescripcionEspecialidad, idActual);
        }

        public string ObtenerIdPadreSiTieneSubtiposActivos(string idSubtipo)
        {
            return tipoExamen.ObtenerIdPadreSiTieneSubtiposActivos(idSubtipo);
        }

    }
}

