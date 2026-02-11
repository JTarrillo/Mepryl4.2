using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Comunes;
using CapaDatosBase;

namespace CapaNegocioBase
{
    public abstract class EntidadFactoryBase
    {
        public string EntidadNombre = "";
        public Configuracion configuracion = null;
        public CapaDatosBase.EntidadFactoryBase datEntidadFac;
        public string idLiga = "";
        //Viviana
        public EntidadFactoryBase(Configuracion conf, string entNombre, string idLiga)
        {
            this.configuracion = conf;
            this.EntidadNombre = entNombre;
            this.idLiga = idLiga;
            crearDatEntidadFac();
        }


        public EntidadFactoryBase(Configuracion conf, string entNombre)
        {
            this.configuracion = conf;
            this.EntidadNombre = entNombre;

            crearDatEntidadFac();

            //this.datEntidadFac = new CapaDatosBase.EntidadFactoryBase(this.configuracion, this.EntidadNombre);
        }

        ~EntidadFactoryBase()
        {
            this.configuracion = null;
            this.datEntidadFac = null;
        }



        public abstract void crearDatEntidadFac();
        protected abstract EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad);
        protected abstract CapaNegocioBase.EntidadBase crearEntidadNegocio();

        //Da el alta recibiendo todos los datos en un objeto
        public abstract Resultado alta(CapaNegocioBase.EntidadBase negEntidad);
        public abstract Resultado modificar(EntidadBase entidad);

        public DataTable getAllInDataTable()
        {
            return getAllInDataTable(null,0);
        }
        public DataTable getAllInDataTable(string filtro)
        {
            return getAllInDataTable(filtro, 0);
        }
        public DataTable getAllInDataTable(string filtro, int top)
        {
            return getAllInDataTable(filtro, top, this.EntidadNombre);
        }
        public DataTable getAllInDataTable(string filtro, int top, string nombreSP)
        {
            DataTable tabla = null;
            try
            {

                tabla = datEntidadFac.getAllInDataTable(filtro, top, nombreSP);

                return tabla;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return tabla;
            }
        }

        //Viviana
        public DataTable getSelectClub(string filtro)
        {
            DataTable tabla = null;
            try
            {
                tabla = datEntidadFac.obtenerClubxLiga(filtro);

                return tabla;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return tabla;
            }
        }
        //Viviana
        public DataTable getSelectBusClub(string filtro,string idLiga)
        {
            DataTable tabla = null;
            try
            {
                tabla = datEntidadFac.getSelectBusClub(filtro,idLiga);
                return tabla;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return tabla;
            }
        }
        //Devuelve una DataTable con los registros que cumplen la condición de filtro
        public DataTable getSelect(string filtro)
        {
            DataTable tabla = null;
            try
            {
                tabla = datEntidadFac.getSelect(filtro);

                return tabla;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return tabla;
            }
        }

        public CapaNegocioBase.EntidadBase alta(string descripcion)
        {
            //CapaNegocioBase.EntidadBase negEntidad = new EntidadBase();
            CapaNegocioBase.EntidadBase negEntidad = crearEntidadNegocio();
            try
            {
                SqlDataReader dr = datEntidadFac.alta(descripcion);

                if (dr.HasRows)
                {
                    dr.Read();
                    negEntidad.id = new Guid(dr["id"].ToString());
                }

                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
            return negEntidad;
        }

        public EntidadBase getById(string id)
        {
            try 
            {
                Guid guid;
                try
                {
                    guid = new Guid(id);
                }
                catch (Exception ex1)
                {
                    guid = new Guid(Utilidades.ID_VACIO);
                }
                
                CapaDatosBase.EntidadBase datEntidad = datEntidadFac.getById(guid);

                if (datEntidad != null)
                    return convertirEnObjetoNegocio(datEntidad);
                else
                    return null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }

        public EntidadBase getByCodigo(string codigo)
        {
            try
            {
                CapaDatosBase.EntidadBase datEntidad = datEntidadFac.getByCodigo(codigo);

                if (datEntidad != null)
                    return convertirEnObjetoNegocio(datEntidad);
                else
                    return null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }


        public EntidadBase getByFiltro(string filtro)
        {
            try
            {
                CapaDatosBase.EntidadBase datEntidad = datEntidadFac.getByFiltro(filtro);

                if (datEntidad != null)
                    return convertirEnObjetoNegocio(datEntidad);
                else
                    return null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }

        //Valida un objeto para diferentes operaciones
        public virtual string validar(CapaNegocioBase.EntidadBase negEntidad, ModoEdicion edicion)
        {
            string resultado = "";

            try
            {
                if (edicion == ModoEdicion.AGREGANDO)
                {
                    if (negEntidad.codigo == "")
                        obtenerNuevoCodigo(ref negEntidad);

                    if (negEntidad.codigo != "")
                    {
                        if (existe(negEntidad))
                            resultado = "Ya existe un registro con el código: " + negEntidad.codigo;
                    }
                    
                }
                else if (edicion == ModoEdicion.MODIFICANDO)
                {
                    resultado = validarParaModificacion(negEntidad);
                }
                else if (edicion == ModoEdicion.VACIO)
                {
                    resultado = "No se puede realizar la operación: Objeto vacío.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return resultado;
        }

        //Verifica si existe un registro en la base de datos con el mismo código
        public bool existe(CapaNegocioBase.EntidadBase negEntidad)
        {
            bool resultado = false;
            try
            {
                CapaDatosBase.EntidadBase datEntidad = negEntidad.convertirEnObjetoDatos();

                resultado = datEntidadFac.existe(datEntidad);

                datEntidad = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        //Genera un nuevo código y se lo asigna al objeto
        public void obtenerNuevoCodigo(ref CapaNegocioBase.EntidadBase entidad)
        {
            try
            {
                entidad.codigo = datEntidadFac.obtenerNuevoCodigo();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Valida los datos del objeto para modificar
        protected virtual string validarParaModificacion(CapaNegocioBase.EntidadBase negEntidad)
        {
            return "";
        }


        public virtual string borrar(string id)
        {
            string resultado = "";
            try
            {
                crearDatEntidadFac();
                resultado = datEntidadFac.borrar(new Guid(id));
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

    }
}
