using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using Entidades;
using System.Data;

namespace CapaNegocioMepryl
{
    public class TipoExamen
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

        public DataTable cargarTiposDeExamen(string idMotivoConsulta)
        {
            return tipoExamen.cargarTiposDeExamen(idMotivoConsulta);
        }

        public DataTable cargarMotivosDeConsulta()
        {
            return tipoExamen.cargarMotivosDeConsulta();
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
    }
}
