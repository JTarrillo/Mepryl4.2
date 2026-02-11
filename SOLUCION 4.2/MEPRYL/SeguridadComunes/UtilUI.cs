using System;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace Comunes
{
	/// <summary>
	/// Summary description for UtilUI.
	/// </summary>
	public class UtilUI
	{
		public UtilUI()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault, SqlParameter[] param)
		{
			llenarCombo(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), param);
		}

		public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault)
		{			
			llenarCombo(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), null);
		}

		public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault)
		{			
			llenarCombo(ref combo, conexion, sp, etiquetaDefault, valorDefault, null);
		}

		public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault, SqlParameter[] param)
		{
			try 
			{
				DataSet ds = SqlHelper.ExecuteDataset(conexion, sp, param);

				if (valorDefault!="-1" && etiquetaDefault!="")
				{
					if (valorDefault.Length < "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".Length)
						valorDefault = Utilidades.ID_VACIO;

					DataRow dr = ds.Tables[0].NewRow();
					dr["id"] = valorDefault;
					dr["descripcion"] = etiquetaDefault;
					ds.Tables[0].Rows.InsertAt(dr, 0);
				}

				combo.DisplayMember = "descripcion";
				combo.ValueMember = "id";
				combo.DataSource = ds.Tables[0];

				if (valorDefault=="-1" || valorDefault=="0")
				{
					if (combo.Items.Count > 0)
						combo.SelectedIndex = 0; //Selecciona el primer elemento.
				}//combo.SelectedIndex = -1;
				else
					if (etiquetaDefault=="")
						combo.SelectedValue = valorDefault;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}


		public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault)
		{
			llenarListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString());
		}
		public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault)
		{			
			llenarListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault, null);
		}

		public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault, SqlParameter[] param)
		{
			llenarListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), param);
		}

		public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault, SqlParameter[] param)
		{
			try 
			{
				DataSet ds = SqlHelper.ExecuteDataset(conexion, sp, param);

				if (valorDefault!="-1" && etiquetaDefault!="")
				{
					if (valorDefault.Length < "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".Length)
						valorDefault = Utilidades.ID_VACIO;

					DataRow dr = ds.Tables[0].NewRow();
					dr["id"] = valorDefault;
					dr["descripcion"] = etiquetaDefault;
					ds.Tables[0].Rows.InsertAt(dr, 0);
				}

				combo.DisplayMember = "descripcion";
				combo.ValueMember = "id";
				combo.DataSource = ds.Tables[0];

				if (valorDefault=="-1")
					combo.SelectedIndex = -1;
				else
					if (etiquetaDefault=="")
					combo.SelectedValue = valorDefault;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}


		public static void llenarCheckedListBox(ref CheckedListBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault)
		{
			llenarCheckedListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString());
		}
		public static void llenarCheckedListBox(ref CheckedListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault)
		{			
			llenarCheckedListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault, null);
		}

		public static void llenarCheckedListBox(ref CheckedListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault, SqlParameter[] param)
		{
			try 
			{
				DataSet ds = SqlHelper.ExecuteDataset(conexion, sp, param);

				if (valorDefault!="-1" && etiquetaDefault!="")
				{
					if (valorDefault.Length < "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".Length)
						valorDefault = Utilidades.ID_VACIO;

					DataRow dr = ds.Tables[0].NewRow();
					dr["id"] = valorDefault;
					dr["descripcion"] = etiquetaDefault;
					ds.Tables[0].Rows.InsertAt(dr, 0);
				}

                combo.DataSource = ds.Tables[0];
				combo.DisplayMember = "descripcion";
				combo.ValueMember = "id";

				if (valorDefault=="-1")
					combo.SelectedIndex = -1;
				else
					if (etiquetaDefault=="")
					combo.SelectedValue = valorDefault;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}


		public static bool verificarConfig(string conexion, ref Control control, ref StatusBar statusBarPrincipal)
		{
			try
			{
				System.Drawing.Icon icono = null;
				bool config = false;
				string path = AppDomain.CurrentDomain.BaseDirectory;
				try 
				{
					SqlHelper.ExecuteNonQuery(conexion, "sp_Config", null);
					config = true;
					icono = new System.Drawing.Icon(path + "Disco.ico");
				}
				catch (Exception e)
				{
					config = false;
					icono = new System.Drawing.Icon(path + "Deshabilitado.ico");
				}
				control.Visible = config;
				statusBarPrincipal.Panels[2].Icon = icono;
				return config;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return false;
			}
		}

		public static void trabajando(Form form, ref StatusBar statusBarPrincipal, string mensaje, bool trabajando)
		{
			try
			{
				if (form!=null)
				{
					System.Drawing.Icon icono = null;
					string path = AppDomain.CurrentDomain.BaseDirectory;
					if (trabajando)
					{
						form.Cursor = Cursors.WaitCursor;
						icono = new System.Drawing.Icon(path + "Mano.ico");
					}
					else
					{
						form.Cursor = Cursors.Arrow;
						icono = new System.Drawing.Icon(path + "Ok.ico");
					}
					form.Focus();
					if (statusBarPrincipal!=null)
					{
						statusBarPrincipal.Panels[0].Text = mensaje;
						statusBarPrincipal.Panels[1].Icon = icono;
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}

		/// <summary>
		/// Verifica si el item seleccionado existe en la base o es nuevo, si existe devuelve el ID, si no lo inserta en la base y trae el nuevoID.
		/// </summary>
		public static string obtenerIDListaActualizable(string conexion, ref ComboBox combo, string sp)
		{
			return obtenerIDListaActualizable(conexion, ref combo, sp, "");
		}
		public static string obtenerIDListaActualizable(string conexion, ref ComboBox combo, string sp, string sp_getAll)
		{
			try
			{
				string id = Utilidades.ID_VACIO;
                string textoCombo;

                if (combo.AccessibilityObject.Value != null)
                    textoCombo = combo.AccessibilityObject.Value.ToString();
                else
                    textoCombo = combo.Text;

				//if (combo.Text.Trim()!="")
                if (textoCombo.Trim() != "")
				{
					//Primero se fija si esta en la lista
					//string textoOriginal = combo.Text;
                    string textoOriginal = textoCombo;
					DataTable dt = (DataTable)combo.DataSource;
					for (int i=0; i<dt.Rows.Count; i++)
					{
						Application.DoEvents();
						if (dt.Rows[i][combo.DisplayMember].ToString().Trim().ToUpper()
							== textoOriginal.Trim().ToUpper())
						{
							combo.SelectedIndex = i;
							break;
						}
					}

					if (combo.SelectedIndex==-1 ||
                        combo.Text!=textoCombo)
					{
						SqlParameter[] param;
						SqlDataReader dr;
						if (sp_getAll!="")
						{
							//Primero lo busca en la base de datos
							param = new SqlParameter[2];
							param[0] = new SqlParameter("@id", null);
							//param[1] = new SqlParameter("@descripcion", combo.Text);
                            param[1] = new SqlParameter("@descripcion", textoCombo);
							dr = SqlHelper.ExecuteReader(conexion, sp_getAll, param);
							if (dr.HasRows)
							{
								dr.Read();
								id = dr[0].ToString();
								dr.Close();
							}
						}

						//Si no esta, lo inserta como un registro nuevo
						if (id==Utilidades.ID_VACIO)
						{
							param = new SqlParameter[1];
							//param[0] = new SqlParameter("@descripcion", combo.Text);
                            param[0] = new SqlParameter("@descripcion", textoCombo);
							dr = SqlHelper.ExecuteReader(conexion, sp, param);
							dr.Read();
							id = dr[0].ToString();
							dr.Close();
						}
					}
					else
						id = combo.SelectedValue.ToString();
				}
				return id;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return null;
			}
		}

		//Obtiene el identificador del item seleccionado
		public static string obtenerIdentificadorCombo(ref ComboBox cb)
		{
			string resultado = "";
			DataTable dt = (DataTable)cb.DataSource;
			if (dt!=null)
				if (dt.Rows.Count>0)
                    if (cb.SelectedIndex>-1)
					    resultado = dt.Rows[cb.SelectedIndex]["identificador"].ToString();

			dt = null;
			return resultado;
		}


        //Obtiene el ID del item seleccionado
        public static string obtenerIDCombo(ref ComboBox cb)
        {
            string resultado = Utilidades.ID_VACIO;
            DataTable dt = (DataTable)cb.DataSource;
            if (dt != null)
                if (dt.Rows.Count > 0)
                    resultado = dt.Rows[cb.SelectedIndex]["ID"].ToString();

            dt = null;
            return resultado;
        }


		//Selecciona el item segun el texto del parametro
		public static void comboSeleccionarItemByText(string texto, ref ComboBox cb)
		{
			try
			{
				int index = 0;
				for (int i=0; i<cb.Items.Count; i++)
				{
					cb.SelectedIndex = i;
					if (cb.Text==texto)
					{
						index = i;
						break;
					}
				}
				cb.SelectedIndex = index;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}

		//Selecciona el item segun el identificador
		public static void comboSeleccionarItemByIdentificador(string identificador, ref ComboBox cb)
		{
			try
			{
				DataTable dt = (DataTable)cb.DataSource;
				int index = 0;
				for (int i=0; i<dt.Rows.Count; i++)
				{
					if (dt.Rows[i]["identificador"].ToString() == identificador)
					{
						index = i;
						break;
					}
				}
				cb.SelectedIndex = index;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}
	}
}
