
using CapaNegocioBase;
using Comunes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio
{
    //Delegado handler del evento Changed
    public delegate void ProgresoEventHandler(double valorActual, double valorFinal);

    public class HorarioFactory : EntidadFactoryBase
    {
        public event ProgresoEventHandler progreso;
        public bool progresoHandlerAsignado = false;

        public HorarioFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.HorarioFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Horario();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Horario negHorario = new CapaNegocio.Horario();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negHorario;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negHorario = (CapaNegocio.Horario)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negHorario;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                CapaNegocio.Horario horario = (CapaNegocio.Horario)negEntidad;
                //Primero prepara el valor para diasSimplificado
                string dias = "";
                if (horario.domingo) dias += "Dom ";
                if (horario.lunes) dias += "Lun ";
                if (horario.martes) dias += "Mar ";
                if (horario.miercoles) dias += "Mié ";
                if (horario.jueves) dias += "Jue ";
                if (horario.viernes) dias += "Vie ";
                if (horario.sabado) dias += "Sáb ";
                horario.diasSimplificado = dias;


                crearDatEntidadFac();

                CapaDatos.Horario datHorario = (CapaDatos.Horario)horario.convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datHorario);
                datHorario = (CapaDatos.Horario)resultado.objeto;
                horario = (CapaNegocio.Horario)convertirEnObjetoNegocio(datHorario);

                resultado.objeto = horario;

                //Genera los registros de Turnos
                CapaNegocio.TurnoFactory turnoFac = new TurnoFactory(this.configuracion, "Turno");
                turnoFac.progreso += new ProgresoEventHandler(manejarEventoProgreso);
                turnoFac.generarTurnos(horario);
                turnoFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        private void manejarEventoProgreso(double valorActual, double valorTotal)
        {
            if (this.progreso!=null)
                this.progreso(valorActual, valorTotal);
        }
        // Obtiene horarios filtrando por profesional y nivel de especialidad (Padre)
        public DataTable obtenerHorariosPorNivel(string profesionalID, int padre, string idPadre = null)
        {
            string filtro = $"profesionalID='{profesionalID}'";
            if (padre == 1)
                filtro += " AND especialidadID IN (SELECT id FROM dbo.Especialidad WHERE Padre = 1)";
            else if (padre == 0 && idPadre != null)
                filtro += $" AND especialidadID IN (SELECT id FROM dbo.Especialidad WHERE Padre = 0 AND idPadre = '{idPadre}')";
            return getAllInDataTable(filtro);
        }
        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");

            try
            {
                CapaNegocio.Horario horario = (CapaNegocio.Horario)entidad;
                //Primero prepara el valor para diasSimplificado
                string dias = "";
                if (horario.domingo) dias += "Dom ";
                if (horario.lunes) dias += "Lun ";
                if (horario.martes) dias += "Mar ";
                if (horario.miercoles) dias += "Mié ";
                if (horario.jueves) dias += "Jue ";
                if (horario.viernes) dias += "Vie ";
                if (horario.sabado) dias += "Sáb ";
                horario.diasSimplificado = dias;


                //Limpia las fechas
                horario.fechaDesde = horario.fechaDesde.Date;
                horario.fechaHasta = horario.fechaHasta.Date;

                crearDatEntidadFac();

                CapaDatos.Horario datHorario = (CapaDatos.Horario)horario.convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datHorario);

                datHorario = (CapaDatos.Horario)resultado.objeto;
                horario = (CapaNegocio.Horario)convertirEnObjetoNegocio(datHorario);

                resultado.objeto = horario;

                //Genera los registros de Turnos
                CapaNegocio.TurnoFactory turnoFac = new TurnoFactory(this.configuracion, "Turno");
                turnoFac.progreso += new ProgresoEventHandler(manejarEventoProgreso);
                turnoFac.generarTurnos(horario);
                turnoFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        public override string borrar(string id)
        {
            string resultado = base.borrar(id);
            try
            {
                //Elimina los registros de Turnos
                CapaNegocio.TurnoFactory turnoFac = new TurnoFactory(this.configuracion, "Turno");
                turnoFac.eliminarTurnos(id);
                turnoFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }


        //Valida los datos del objeto de negocio
        public override string validar(CapaNegocioBase.EntidadBase negEntidad, ModoEdicion edicion)
        {
            string resultado = "";

            try
            {
                resultado = base.validar(negEntidad, edicion);

                CapaNegocio.Horario horario = (CapaNegocio.Horario)negEntidad;

                string[] aHoraDesde = horario.horaDesde.Split(":".ToCharArray());
                string[] aHoraHasta = horario.horaHasta.Split(":".ToCharArray());
                DateTime horaDesde = DateTime.Now;
                DateTime horaHasta = DateTime.Now;
                try
                {
                    horaDesde = new DateTime(2010, 1, 1, int.Parse(aHoraDesde[0]), int.Parse(aHoraDesde[1]), 0);
                    horaHasta = new DateTime(2010, 1, 1, int.Parse(aHoraHasta[0]), int.Parse(aHoraHasta[1]), 0);
                }
                catch (Exception e1)
                {
                    resultado = "\r\nIntervalo horario erróneo.";
                }
                TimeSpan segmentoTotal = horaHasta - horaDesde;


                if (segmentoTotal.Ticks < 0)
                    resultado += "\r\nLa hora de inicio no puede ser mayor a la hora de finalización.";
                if (horario.horaDesde.Trim().Replace(" ","").Length < 5)
                    resultado += "\r\nHora de Inicio: Valor incorrecto.";
                if (horario.horaHasta.Trim().Replace(" ", "").Length < 5)
                    resultado += "\r\nHora de Finalización: Valor incorrecto.";
                /*if (horario.cantidadTurnos <= 0)
                    resultado += "\r\nLa cantidad de turnos debe ser mayor que 0.";*/
                if (horario.citarCada <= 0)
                    resultado += "\r\nEl campo 'Citar cada' debe ser mayor que 0.";
                if (horario.pacientesGrupo <= 0)
                    resultado += "\r\nEl campo 'Pacientes x cita' debe ser mayor que 0.";
                if (!horario.domingo && !horario.lunes && !horario.martes && !horario.miercoles && !horario.jueves && !horario.viernes && !horario.sabado)
                    resultado += "\r\nDebe seleccionar al menos un día de atención.";
                if (horario.fechaDesde.Date > horario.fechaHasta.Date)
                    resultado += "\r\nLa fecha de inicio no puede ser mayor a la de finalización.";

                
                //Si est� todo bien, finalmente valida que no exista otro horario similar para este profesional y especialidad.
                if (yaExisteHorarioSimilar(horario))
                    resultado += "\r\nYa existe un horario similar.";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }


        //Verifica la existencia de otro horario similar
        public bool yaExisteHorarioSimilar(CapaNegocio.Horario horario)
        {
            bool resultado = false;

            try
            {
                crearDatEntidadFac();

                CapaDatos.Horario datHorario = (CapaDatos.Horario)horario.convertirEnObjetoDatos();
                resultado = ((CapaDatos.HorarioFactory)datEntidadFac).yaExisteHorarioSimilar(datHorario);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }
        
    }
}