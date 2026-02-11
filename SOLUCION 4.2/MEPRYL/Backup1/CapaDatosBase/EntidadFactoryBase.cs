using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.OleDb;

namespace CapaDatosBase
{
    public abstract class EntidadFactoryBase
    {
        public Configuracion configuracion = null;
        public string EntidadNombre = "";
        public EntidadBase entidad;

        public EntidadFactoryBase(Configuracion conf, string entNombre)
        {
            this.configuracion = conf;
            this.EntidadNombre = entNombre;
        }

        ~EntidadFactoryBase()
        {
            this.configuracion = null;
        }

        public abstract Resultado modificar(EntidadBase entidad);


        public virtual void inicializarEntidad()
        {
            entidad = new EntidadBase(this.EntidadNombre);
        }

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
            return getAllInDataTable(filtro, top, nombreSP, EEspecialidad.Preventiva);
        }
        // 07/11/2014: Modificado para agregar varias especialidades
        public DataTable getAllInDataTable(string filtro, int top, string nombreSP, EEspecialidad especialidad)
        {
            DataTable tabla = null;
            try
            {
                DataSet ds = new DataSet();

                //Crea la conexion
                OleDbConnection conexion = new OleDbConnection("PROVIDER=SQLOLEDB;" + this.configuracion.getConectionString());
                conexion.Open();
                OleDbCommand comando = new OleDbCommand();
                comando.Connection = conexion;
                comando.CommandTimeout = 5000;
                comando.CommandType = CommandType.StoredProcedure;

                OleDbParameter[] param = null;
                if (filtro != null)
                {
                    if (top == 0)
                    {
                        param = new OleDbParameter[1];
                        param[0] = new OleDbParameter("@filtro", filtro);
                        comando.Parameters.Add(new OleDbParameter("@filtro", filtro));
                        
                        //SqlConnection con = new SqlConnection(cs);
                        //ds = SqlHelper.ExecuteDataset(cs, "sp_" + nombreSP + "_SelectFiltro", param);


                        comando.CommandText = "sp_" + nombreSP + "_SelectFiltro";
                    }
                    else
                    {
                        param = new OleDbParameter[3];
                        param[0] = new OleDbParameter("@filtro", filtro);
                        param[1] = new OleDbParameter("@top", '1');
                        string orden = "";
                        if (top == 1)
                            orden = "";
                        if (top == -1)
                            orden = "DESC";
                        param[2] = new OleDbParameter("@orden", orden);
                        //param[3] = new OleDbParameter("@especialidadCodigo", especialidad.ToString());

                        comando.Parameters.Add(new OleDbParameter("@filtro", filtro));
                        comando.Parameters.Add(new OleDbParameter("@top", '1'));
                        comando.Parameters.Add(new OleDbParameter("@orden", orden));
                        //comando.Parameters.Add(new OleDbParameter("@especialidadCodigo", especialidad.ToString()));
                        
                        comando.CommandText = "sp_" + this.EntidadNombre + "_SelectFiltroTop";
                    }
                }
                else
                {
                    param = null;
                    comando.CommandText = "sp_" + this.EntidadNombre + "_SelectAll";
                }

                //comando.Parameters.AddRange(param);
                //Obtiene el dataset
                OleDbDataAdapter da = new OleDbDataAdapter(comando);
                da.Fill(ds);
                
                if (ds.Tables.Count > 0)
                    tabla = ds.Tables[0];

                ds = null;
                da = null;
                conexion.Close();
                conexion = null;
                comando = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
            return tabla;
        }

        public DataTable getSelect(string palabrasClave)
        {
            DataTable tabla = null;
            try
            {
                //Arma la cadena de filtro
                string[] palabras = palabrasClave.Trim().Split(' ');
                string filtro = "1=1";
                for (int i = 0; i < palabras.Length; i++)
                {
                    if (palabras[i].Trim() != "")
                    {
                        filtro += " AND registroBLOB LIKE '%" + palabras[i].Trim() + "%' ";
                    }
                }

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@filtro", filtro);
                DataSet ds = SqlHelper.ExecuteDataset(configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_SelectFiltro", param);
                if (ds.Tables.Count > 0)
                    tabla = ds.Tables[0];

                ds = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
            return tabla;
        }

        public SqlDataReader alta(string descripcion)
        {
            SqlDataReader dr = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@descripcion", descripcion);
                dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_InsertByDescripcion", param);

                param = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
            return dr;
        }

        public EntidadBase getById(Guid id)
        {
            entidad = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@id", id);

                SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_getById", param);

                if (dr.HasRows)
                {
                    dr.Read();

                    entidad = leerRegistro(dr);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
            return entidad;
        }

        public EntidadBase getByCodigo(string codigo)
        {
            entidad = null;
            try
            {
                if (codigo != "")
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@codigo", codigo);

                    SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_getByCodigo", param);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        entidad = leerRegistro(dr);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
            return entidad;
        }

        //Trae el primer registro con la condición dada
        public EntidadBase getByFiltro(string filtro)
        {
            entidad = null;
            try
            {
                if (filtro != "")
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@filtro", filtro);

                    SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_getByFiltro", param);

                    if (dr.HasRows)
                    {
                        dr.Read();

                        entidad = leerRegistro(dr);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
            return entidad;
        }


        //Lee el registro obtenido: en cada clase de la jerarquía se leen los datos que se conocen
        protected virtual EntidadBase leerRegistro(SqlDataReader dr)
        {
            entidad = null;
            try
            {
                DataTable esquema = dr.GetSchemaTable();

                entidad = new EntidadBase(this.EntidadNombre);
                entidad.id = new Guid(dr["id"].ToString());
                entidad.codigo = dr["codigo"].ToString();

                //Carga todos los campos en un diccionario
                for (int i = 0; i < esquema.Rows.Count; i++ )
                {
                    entidad.campos[esquema.Rows[i][0].ToString()] = dr[esquema.Rows[i][0].ToString()];
                }
                esquema = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                
            }
            return entidad;
        }

        public bool existe(EntidadBase ent)
        {
            bool resultado = false;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@codigo", ent.codigo);

                SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_getByCodigo", param);

                if (dr.HasRows)
                {
                    resultado = true; 
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        public abstract Resultado alta(EntidadBase entidad);

        protected Resultado altaID(EntidadBase ent)
        {
            inicializarEntidad();

            entidad = ent;

            Resultado resultado = new Resultado(ent, "");
            try
            {
                //Primero da el alta vacío
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@codigo", entidad.codigo);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_InsertByCodigo", param);

                if (dr.HasRows)
                {
                    dr.Read();

                    entidad.id = new Guid(dr["id"].ToString());
                }
                else
                    resultado.mensaje = "No se pudo insertar el registro.";

                dr.Close();


                resultado.objeto = entidad;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        public string obtenerNuevoCodigo()
        {
            string nuevoCodigo = "";
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@entidad", this.EntidadNombre);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_getNuevoCodigo", param);

                if (dr.HasRows)
                {
                    dr.Read();
                    nuevoCodigo = dr["nuevoCodigo"].ToString();
                }
                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return nuevoCodigo;
        }

        public string borrar(Guid id)
        {
            string resultado = "";
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@id", id);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_" + this.EntidadNombre + "_Delete", param);

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
