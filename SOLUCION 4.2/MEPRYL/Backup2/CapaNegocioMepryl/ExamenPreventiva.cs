using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using Entidades;
using System.Data;

namespace CapaNegocioMepryl
{
    public class ExamenPreventiva
    {
        CapaDatosMepryl.Preventiva datosPreventiva;

        public ExamenPreventiva()
        {
            datosPreventiva = new Preventiva();
        }

        public Entidades.ExamenPreventiva cargarExamen(string idTipoExamen)
        {
            return datosPreventiva.cargarExamen(idTipoExamen);
        }

        public Entidades.Resultado guardarExClinico(Entidades.ExamenPreventiva ep)
        {
            return datosPreventiva.guardarClinico(ep);
        }

        public Entidades.Resultado guardarExLaboratorio(Entidades.ExamenPreventiva ep)
        {
            return datosPreventiva.guardarLaboratorio(ep);
        }

        public Entidades.Resultado guardarExCardiologico(Entidades.ExamenPreventiva ep)
        {
            return datosPreventiva.guardarCardiologia(ep);
        }

        public Entidades.Resultado guardarExRx(Entidades.ExamenPreventiva ep)
        {
            return datosPreventiva.guardarRx(ep);
        }

        public Entidades.Resultado guardarDictamenFinal(Entidades.ExamenPreventiva examen)
        {
            return datosPreventiva.guardarDictamenFinal(examen);
        }

        public DataTable cargarParametrosExamen(object idTipoExamen, object idConsulta)
        {
            return datosPreventiva.cargarParametrosExamen(idTipoExamen, idConsulta);
        }

        public DataTable cargarParametrosLaboratorio(object idTipoExamen, object idConsulta)
        {
            return datosPreventiva.cargarParametrosLaboratorio(idTipoExamen, idConsulta);
        }

        public DataTable cargarDataSourceExamen()
        {
            return datosPreventiva.cargarDataSourceExamen();
        }

        public DataTable cargarDataSourceProtocoloLaboratorio()
        {
            return datosPreventiva.cargarDataSourceLaboratorio();
        }

        public void crearExamen(string idTipoExamen)
        {
            datosPreventiva.crearExamen(idTipoExamen);
        }

        public void actualizarImpresionExamen(object idTipoExamen)
        {
            datosPreventiva.actualizarImpresionExamen(idTipoExamen);
        }

        public void ActualizaConsolidadoExamen(string idTipoExamen)
        {
            datosPreventiva.ActualizaConsolidadoExamen(idTipoExamen);
        }

        public string ObtieneTipoExamenPaciente(DateTime Fecha, string DNI)
        {
            return datosPreventiva.ObtieneTipoExamenPaciente(Fecha, DNI);
        }

        public void actualizarImpresionLaboratorio(object idTipoExamen)
        {
            datosPreventiva.actualizarImpresionLaboratorio(idTipoExamen);
        }

        public void actualizarEnvioMail(object idTipoExamen)
        {
            datosPreventiva.actualizarEnvioMail(idTipoExamen);
        }

        public void dictamenRxAutomatico(object idTipoExamen)
        {
            datosPreventiva.dictamenRxAutomatico(idTipoExamen);
        }

        public void dictamenCarAutomatico(object idTipoExamen)
        {
            datosPreventiva.dictamenCarAutomatico(idTipoExamen);
        }

        public void dictamenFinalAutomatico(object idTipoExamen)
        {
            datosPreventiva.dictamenFinalAutomatico(idTipoExamen);
        }

        public Entidades.Resultado revalidarCondicionales()
        {
            return datosPreventiva.revalidarCondicionales();
        }

        public void eliminarExamen(string idTipoExamen, string idConsulta)
        {
            datosPreventiva.eliminarExamen(idTipoExamen, idConsulta);
        }

        public void inhabilitarExamen(object idTipoExamen, string modo)
        {
            datosPreventiva.inhabilitarExamen(idTipoExamen, modo);
        }

        public bool estaInhabilitado(object idTipoExamen)
        {
            return datosPreventiva.estaInhabilitado(idTipoExamen);
        }

        public void actualizarValidaciones()
        {
            datosPreventiva.actualizarValidaciones();
        }

        public bool estaInhabilitadoDni(string dni)
        {
            return datosPreventiva.estaInhabilitadoDni(dni);
        }

        public DataTable ListaInformeRadiologico(DateTime Desde, DateTime Hasta, string DNI, string NroOrden)
        {
            return datosPreventiva.ListaInformeRadiologico(Desde, Hasta, DNI, NroOrden);
        }
    }
}
