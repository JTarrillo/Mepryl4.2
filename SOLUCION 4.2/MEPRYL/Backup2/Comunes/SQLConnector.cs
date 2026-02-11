using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using Comunes;

namespace Comunes
{
    public class SQLConnector
    {
        public static Configuracion configuracion = new Configuracion();
        public static string cadena_nula = "";
        public static int entero_nulo = -1;
        private static SqlConnection cn;

        public static bool conectarABaseDeDatos()
        {
            try
            {
                cn = new SqlConnection(configuracion.getConectionString());
                cn.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool desconectarBaseDeDatos()
        {
            try
            {
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static SqlConnection getCn()
        {
            return cn;
        }



        /// <summary>
        /// Realiza una consulta y devuelve un datatable con el resultado del mismo.
        /// </summary>
        /// <param name="procedure">Consulta.</param>
        /// <returns></returns>
        public static DataTable obtenerTablaSegunConsultaString(string consulta)
        {
            DataTable dt = new DataTable();
            try
            {
                //SqlConnection cn = new SqlConnection(configuracion.getConectionString());
                //cn.Open();
                //SqlConnection conection = getCn();
                SqlCommand cmd = new SqlCommand(consulta, getCn());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                dt.Dispose();
            }
        }

        /// <summary>
        /// Ejecuta un stored procedure que devuelve un datatable con el resultado del mismo.
        /// </summary>
        /// <param name="procedure">Consulta.</param>
        /// <returns></returns>
        public static DataTable obtenerTablaSegunProcedure(string procedure, List<string> args, params object[] values)
        {
            DataTable dt = new DataTable();
            try
            {
                //SqlConnection cn = new SqlConnection(configuracion.getConectionString());
                //cn.Open();
                SqlCommand cmd = new SqlCommand(procedure, getCn());
                cmd.CommandType = CommandType.StoredProcedure;
                if (_validateArgumentsAndParameters(args, values))
                {
                    _loadSqlCommand(args, values, cmd);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /*
        public static void executeDynamicQuery(string consulta)
        {
            SqlCommand cm = new SqlCommand();
            SqlDataReader dr;
            List<string> args = new List<string>();
            try
            {
                SqlConnection cn = getCn();
                cm.CommandText =consulta;
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }
    */
        /// <summary>
        /// Ejecuta un stored procedure y devuelve un datatable con el resultado del mismo.
        /// </summary>
        /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
        /// <param name="values">Argumentos que recibe el stored procedure.</param>
        /// <returns></returns>
        /*
          public static DataTable retrieveDataTable(string procedure, params object[] values)
          {
              List<string> argumentos = _generateArguments(procedure);
              return _retrieveDataTable(procedure, argumentos, values);
          }
        
          /// <summary>
          /// Ejecuta un stored procedure y devuelve un datatable con el resultado del mismo.
          /// </summary>
          /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
          /// <returns></returns>
          /// 
      
          public static DataTable retrieveDataTable(string procedure)
          {
              return _retrieveDataTable(procedure, null, null);
          }
        
                */
        /// <summary>
        /// Ejecuta un stored procedure.
        /// </summary>
        /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
        /// <param name="values">Argumentos que recibe el stored procedure.</param>
        /// 
        /*
        public static bool executeProcedure(string procedure, params object[] values)
        {
            List<string> argumentos = _generateArguments(procedure);
            return _executeProcedure(procedure, argumentos, values);
        }
        /// <summary>
        /// Ejecuta un stored procedure.
        /// </summary>
        /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
        public static bool executeProcedure(string procedure)
        {
            return _executeProcedure(procedure, null, null);
        }
        */

        /// <summary>
        /// Ejecuta una consulta (a partir de un stored procedure) y devuelve si encontró datos o no.
        /// </summary>
        /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
        /// <param name="values">Argumentos que recibe el stored procedure.</param>
        /// <returns> True: la consulta devolvió alguna fila. False: no devolvió filas.</returns>
        /*public static bool checkIfExists(string procedure, params object[] values)
        {
            List<string> argumentos = _generateArguments(procedure);
            return _checkIfExists(procedure, argumentos, values);
        }
        */
        /// <summary>
        /// Ejecuta una consulta (a partir de un stored procedure) y devuelve si encontró datos o no.
        /// </summary>
        /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
        /// <returns> True: la consulta devolvió alguna fila. False: no devolvió filas.</returns>
        /// 
        /*
        public static bool checkIfExists(string procedure)
        {
            return _checkIfExists(procedure, null, null);
        }
        */
        /// <summary>
        /// Ejecuta un stored procedure que devuelve un valor númerico y retorna dicho valor.
        /// </summary>
        /// <param name="procedure">Nombre del stored procedure almacenado en la BDD sin el nombre del esquema delante.</param>
        /// <param name="values">Argumentos que recibe el stored procedure.</param>
        /// <returns> Valor de retorno del stored procedure.</returns>
        /// 
        /*
        public static int executeProcedureWithReturnValue(string procedure, params object[] values)
        {
            List<string> argumentos = _generateArguments(procedure);
            return _executeProcedureWithReturnValue(procedure, argumentos, values);
        }
        */

        public static bool executeProcedure(string procedure, List<string> args, params object[] values)
        {
            try
            {
                SqlDataReader dr;
                //SqlConnection cn = new SqlConnection(configuracion.getConectionString());
                //cn.Open();
                SqlCommand cmd = new SqlCommand(procedure, getCn());
                cmd.CommandType = CommandType.StoredProcedure;
                if (_validateArgumentsAndParameters(args, values))
                {
                    _loadSqlCommand(args, values, cmd);
                }
                dr = cmd.ExecuteReader();
                dr.Close();
                //cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static List<string> generarListaParaProcedure(params Object[] parametros)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < parametros.Length; i++)
            {
                lista.Add(parametros[i].ToString());
            }
            return lista;
        }
        /*
        private static bool _checkIfExists(string procedure, List<string> args, params object[] values)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            SqlDataReader dr;
            DataTable dt = new DataTable();
            try
            {
                conexionSql(cn, cm);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "COMPUMUNDO_HIPER_MEGA_RED." + procedure;
                if (_validateArgumentsAndParameters(args, values))
                {
                    _loadSqlCommand(args, values, cm);
                }
                dr = cm.ExecuteReader();
                return dr.HasRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }
         */
        public static string executeProcedureWithReturnValue(string procedure, List<string> args, params object[] values)
        {
            try
            {
                //SqlConnection cn = new SqlConnection(configuracion.getConectionString());
                //cn.Open();
                SqlCommand cmd = new SqlCommand(procedure, getCn());
                cmd.CommandType = CommandType.StoredProcedure;
                if (_validateArgumentsAndParameters(args, values))
                {
                    _loadSqlCommand(args, values, cmd);
                }
                cmd.Parameters.Add("@retorno", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //cn.Close();
                return cmd.Parameters["@retorno"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        /*
            private static DataTable _retrieveDataTable(string procedure, List<string> args, params object[] values)
            {
                SqlConnection cn = new SqlConnection();
                SqlCommand cm = new SqlCommand();
                SqlDataReader dr;
                DataTable dt = new DataTable();
                try
                {
                    conexionSql(cn, cm);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "COMPUMUNDO_HIPER_MEGA_RED." + procedure;
                    if (_validateArgumentsAndParameters(args, values))
                    {
                        _loadSqlCommand(args, values, cm);
                    }
                    dr = cm.ExecuteReader();
                    dt.Load(dr);
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (cn != null)
                    {
                        cn.Close();
                    }
                }
            }
        
            private static List<string> _generateArguments(string procedure)
            {
                SqlConnection cn = new SqlConnection();
                SqlCommand cm = new SqlCommand();
                SqlDataReader dr;
                DataTable dt = new DataTable();
                List<string> args = new List<string>();
                try
                {
                    conexionSql(cn, cm);
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT PARAMETER_NAME FROM information_schema.parameters WHERE SPECIFIC_SCHEMA='COMPUMUNDO_HIPER_MEGA_RED' AND SPECIFIC_NAME='" + procedure + "'";
                    dr = cm.ExecuteReader();
                    dt.Load(dr);
                    foreach (DataRow d in dt.Rows)
                    {
                        args.Add(d[0].ToString());
                    }
                    return args;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (cn != null)
                    {
                        cn.Close();
                    }
                }
            }
        */

        private static bool _validateArgumentsAndParameters(List<string> args, params object[] values)
        {
            if (args != null && values != null)
            {
                if (args.Count != values.Length)
                {
                    throw new ApplicationException();
                }
                return true;
            }
            return false;
        }
        private static void _loadSqlCommand(List<string> args, object[] values, SqlCommand cm)
        {
            for (int i = 0; i < args.Count; i++)
            {
                if (values[i] != null)
                {
                    cm.Parameters.AddWithValue(args[i], values[i]);
                }
                else
                {
                    cm.Parameters.AddWithValue(args[i], DBNull.Value);
                }
            }
        }
    }
}
