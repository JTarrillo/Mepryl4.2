using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Comunes
{
    class utilRemito
    {
        //Carga los fletes segun la zona seleccionada
        public static void cargarFletes(Configuracion configuracion, ref ComboBox zona, ref ComboBox flete, bool mostrarTodos)
        {
            //Solo si hay algun item seleccionado
            if (zona.SelectedIndex > -1)
            {
                if (!mostrarTodos)
                {
                    DataTable dt = (DataTable)zona.DataSource;
                    string zonaID = dt.Rows[zona.SelectedIndex]["id"].ToString();

                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("zonaID", new Guid(zonaID));
                    UtilUI.llenarCombo(ref flete, configuracion.getConectionString(), "sp_getAllFletesByZonaID", "", -1, param);
                }
                else
                {
                    UtilUI.llenarCombo(ref flete, configuracion.getConectionString(), "sp_getAllFletes", "", -1);
                }
            }
        }

        //Activa o desactiva los controles del Remito
        public static void activarControlesRemito(Configuracion configuracion, ref GroupBox gb, ref DataGrid dg, bool activar)
        {
            try
            {
                gb.Controls["butImprimirRemito"].Enabled = activar;
                gb.Controls["butGuardarRemito"].Enabled = activar;
                gb.Controls["butCancelarRemito"].Enabled = activar;
                gb.Controls["tbNombreDestinatario"].Enabled = activar;
                gb.Controls["tbDireccionDestinatario"].Enabled = activar;
                gb.Controls["tbObsequiante"].Enabled = activar;
                gb.Controls["tbBultos"].Enabled = activar;
                gb.Controls["cbZona"].Enabled = activar;
                gb.Controls["cbFlete"].Enabled = activar;
                gb.Controls["chkMostrarTodosFletes"].Enabled = activar;
                dg.Enabled = activar;

                /*butImprimirRemito.Enabled = activar;
                butGuardarRemito.Enabled = activar;
                butCancelarRemito.Enabled = activar;
                dgArticulosNuevoRemito.Enabled = activar;
                chkSeleccionarTodo.Enabled = activar;
                tbNombreDestinatario.Enabled = activar;
                tbDireccionDestinatario.Enabled = activar;*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
        }

        //Activa o desactiva los controles del ArticuloBase
        public static void activarControlesRemitoBase(Configuracion configuracion, ref GroupBox gb, ref DataGrid dg, bool activar)
        {
            try
            {
                gb.Controls["tbRBNombreDestinatario"].Enabled = activar;
                gb.Controls["tbRBDireccionDestinatario"].Enabled = activar;
                gb.Controls["butNuevoRemito"].Enabled = activar;
                gb.Controls["chkRBRegaloEmpresario"].Enabled = activar;
                gb.Controls["tbRBObsequiante"].Enabled = activar;
                gb.Controls["tbRBBultos"].Enabled = activar;
                gb.Controls["cbRBZona"].Enabled = activar;
                gb.Controls["cbRBFlete"].Enabled = activar;
                gb.Controls["chkRBMostrarTodosFletes"].Enabled = activar;
                dg.Enabled = activar;

                if (((CheckBox)gb.Controls["chkRBRegaloEmpresario"]).Checked)
                {
                    gb.Controls["tbRBNombreDestinatario"].Enabled = false;
                    gb.Controls["tbRBDireccionDestinatario"].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
        }

        //Guarda el Remito Nuevo
        public static bool guardarRemito(Configuracion configuracion, ref TabControl tab, string estadoRemito)
        {
            try
            {
                //UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Guardando...", true);
                ((Form)tab.FindForm()).Cursor = Cursors.WaitCursor;

                bool resultado = true;

                try
                {
        
                    //Primero guarda el remito, sin numero todavia.
                    //Recorre las lineas y las guarda una por una
                    DataTable dt = (DataTable)((DataGrid)tab.Controls.Find("dgArticulosNuevoRemito", true)[0]).DataSource;
                    DataTable dtRemitoBase = (DataTable)((DataGrid)tab.Controls.Find("dgArticulosBase", true)[0]).DataSource;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sItemSeleccionado = dt.Rows[i]["itemSeleccionado"].ToString();
                        if (sItemSeleccionado != "")
                        {
                            int itemSeleccionado = bool.Parse(sItemSeleccionado) ? 1 : 2;
                            string ID = dt.Rows[i]["ID"].ToString();

                            //Si el item es seleccionado, lo guarda. Sino, lo borra
                            if (itemSeleccionado == 1)
                            {
                                string itemNro = dt.Rows[i]["itemNro"].ToString();
                                int cantidad = int.Parse(dt.Rows[i]["Cantidad"].ToString());
                                string remitoBaseLineaID = dtRemitoBase.Rows[i]["ID"].ToString();
                                int cantidadRemitoBase = int.Parse(dtRemitoBase.Rows[i]["cantidad"].ToString());
                                cantidadRemitoBase -= cantidad;

                                //Guarda los cambios de la linea del Remito
                                SqlParameter[] param = new SqlParameter[4];
                                param[0] = new SqlParameter("@ID", new System.Guid(ID));
                                param[1] = new SqlParameter("@itemSeleccionado", itemSeleccionado);
                                param[2] = new SqlParameter("@itemNro", itemNro);
                                param[3] = new SqlParameter("@cantidad", cantidad);
                                SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_GuardarRemitoLinea", param);


                                //Actualiza la cantidad en la linea del Remito Base
                                param = new SqlParameter[2];
                                param[0] = new SqlParameter("@ID", new System.Guid(remitoBaseLineaID));
                                param[1] = new SqlParameter("@cantidad", cantidadRemitoBase);
                                SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_GuardarCantidadRemitoBaseLinea", param);

                                //Actualiza la cantidad en la grilla del remito base
                                dtRemitoBase.Rows[i]["Cantidad"] = cantidadRemitoBase;
                            }
                            else //Item no seleccionado, lo borra
                            {
                                //Borra el item que no fue seleccionado por el usuario
                                SqlParameter[] param0 = new SqlParameter[1];
                                param0[0] = new SqlParameter("@ID", new System.Guid(ID));
                                SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_BorrarRemitoLinea", param0);
                            }
                        }
                    }

                    //Agrega el destinatario y los demas datos
                    ComboBox cb = null;
                    string zonaID = Utilidades.ID_VACIO;
                    cb = (ComboBox)tab.Controls.Find("cbZona", true)[0];
                    zonaID = UtilUI.obtenerIDCombo(ref cb);
                  
                    string fleteID = Utilidades.ID_VACIO;
                    cb = (ComboBox)tab.Controls.Find("cbFlete", true)[0];
                    fleteID = UtilUI.obtenerIDCombo(ref cb);

                    //Obtiene la localidad y provincia
                    ComboBox cbLocalidadX = (ComboBox)tab.Controls.Find("cbLocalidad", true)[0];
                    string localidadID = UtilUI.obtenerIDListaActualizable(configuracion.getConectionString(), ref cbLocalidadX, "sp_InsertLocalidad", "sp_getAllLocalidads");

                    ComboBox cbProvinciaX = (ComboBox)tab.Controls.Find("cbProvincia", true)[0];
                    string provinciaID = UtilUI.obtenerIDListaActualizable(configuracion.getConectionString(), ref cbProvinciaX, "sp_InsertProvincia", "sp_getAllProvincias");

                    SqlParameter[] param1 = new SqlParameter[11];
                    param1[0] = new SqlParameter("@remitoID", new System.Guid(tab.Controls.Find("tbNuevoRemitoID",true)[0].Text));
                    param1[1] = new SqlParameter("@destinatarioNombre", tab.Controls.Find("tbNombreDestinatario",true)[0].Text);
                    param1[2] = new SqlParameter("@destinatarioDireccion", tab.Controls.Find("tbDireccionDestinatario", true)[0].Text);
                    param1[3] = new SqlParameter("@regaloEmpresario", ((CheckBox)tab.Controls.Find("chkRBRegaloEmpresario", true)[0]).Checked);
                    param1[4] = new SqlParameter("@obsequiante", tab.Controls.Find("tbObsequiante", true)[0].Text);
                    param1[5] = new SqlParameter("@bultos", tab.Controls.Find("tbBultos", true)[0].Text);
                    param1[6] = new SqlParameter("@zonaID", new Guid(zonaID));
                    param1[7] = new SqlParameter("@fleteID", new Guid(fleteID));
                    param1[8] = new SqlParameter("@localidadID", new Guid(localidadID));
                    param1[9] = new SqlParameter("@provinciaID", new Guid(provinciaID));
                    param1[10] = new SqlParameter("@sucursalID", (Guid)((ComboBox)tab.Controls.Find("cbRSucursal", true)[0]).SelectedValue);
                    
                    SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_ModificarRemitoDestinatario", param1);

                    //Actualiza el estado del Remito
                    param1 = new SqlParameter[2];
                    param1[0] = new SqlParameter("@ID", new System.Guid(tab.Controls.Find("tbNuevoRemitoID",true)[0].Text));
                    param1[1] = new SqlParameter("@estadoRemito", estadoRemito);
                    SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_ActualizarEstadoRemito", param1);
                    
                    resultado = true;
                }
                catch (Exception e)
                {
                    ManejadorErrores.escribirLog(e, true);
                    MessageBox.Show(e.Message, "Error al Guardar el Remito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultado = false;
                }
                //UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
                ((Form)tab.FindForm()).Cursor = Cursors.Arrow;

                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return false;
            }
        }


        //Guarda los cambios en un Remito existente
        public static bool guardarCambios(Configuracion configuracion, ref TabControl tab, string estadoRemito)
        {
            try
            {
                ((Form)tab.FindForm()).Cursor = Cursors.WaitCursor;
                
                string remitoID = ((TextBox)tab.Controls.Find("tbRemitoID", true)[0]).Text;

                bool resultado = true;

                try
                {
                    //Primero guarda el remito, sin numero todavia.
                    //Recorre las lineas y las guarda una por una
                    DataTable dt = (DataTable)((DataGrid)tab.Controls.Find("dgRemitoLinea", true)[0]).DataSource;
                    //DataTable dtRemitoBase = (DataTable)((DataGrid)tab.Controls.Find("dgArticulosBase", true)[0]).DataSource;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sItemSeleccionado = dt.Rows[i]["itemSeleccionado"].ToString();
                        if (sItemSeleccionado != "")
                        {
                            int itemSeleccionado = bool.Parse(sItemSeleccionado) ? 1 : 2;
                            string ID = dt.Rows[i]["ID"].ToString();

                            //Si el item es seleccionado, lo guarda. Sino, lo borra
                            if (itemSeleccionado == 1)
                            {
                                string itemNro = dt.Rows[i]["itemNro"].ToString();
                                int cantidad = int.Parse(dt.Rows[i]["Cantidad"].ToString());
                                //string remitoBaseLineaID = dtRemitoBase.Rows[i]["ID"].ToString();
                                //int cantidadRemitoBase = int.Parse(dtRemitoBase.Rows[i]["cantidad"].ToString());
                                //cantidadRemitoBase -= cantidad;

                                //Guarda los cambios de la linea del Remito
                                SqlParameter[] param = new SqlParameter[4];
                                param[0] = new SqlParameter("@ID", new System.Guid(ID));
                                param[1] = new SqlParameter("@itemSeleccionado", itemSeleccionado);
                                param[2] = new SqlParameter("@itemNro", itemNro);
                                param[3] = new SqlParameter("@cantidad", cantidad);
                                SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_GuardarRemitoLinea", param);

                                /*
                                //Actualiza la cantidad en la linea del Remito Base
                                param = new SqlParameter[2];
                                param[0] = new SqlParameter("@ID", new System.Guid(remitoBaseLineaID));
                                param[1] = new SqlParameter("@cantidad", cantidadRemitoBase);
                                SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_GuardarCantidadRemitoBaseLinea", param);

                                //Actualiza la cantidad en la grilla del remito base
                                dtRemitoBase.Rows[i]["Cantidad"] = cantidadRemitoBase;
                                 * */
                            }
                            else //Item no seleccionado, lo borra
                            {
                                //Borra el item que no fue seleccionado por el usuario
                                SqlParameter[] param0 = new SqlParameter[1];
                                param0[0] = new SqlParameter("@ID", new System.Guid(ID));
                                SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_BorrarRemitoLinea", param0);
                            }
                        }
                    }

                    //Agrega el destinatario y los demas datos
                    ComboBox cb = null;
                    string zonaID = Utilidades.ID_VACIO;
                    cb = (ComboBox)tab.Controls.Find("cbZona", true)[0];
                    zonaID = UtilUI.obtenerIDCombo(ref cb);

                    string fleteID = Utilidades.ID_VACIO;
                    cb = (ComboBox)tab.Controls.Find("cbFlete", true)[0];
                    fleteID = UtilUI.obtenerIDCombo(ref cb);

                    //Obtiene la localidad y provincia
                    ComboBox cbLocalidadX = (ComboBox)tab.Controls.Find("cbLocalidad", true)[0];
                    string localidadID = UtilUI.obtenerIDListaActualizable(configuracion.getConectionString(), ref cbLocalidadX, "sp_InsertLocalidad", "sp_getAllLocalidads");

                    ComboBox cbProvinciaX = (ComboBox)tab.Controls.Find("cbProvincia", true)[0];
                    string provinciaID = UtilUI.obtenerIDListaActualizable(configuracion.getConectionString(), ref cbProvinciaX, "sp_InsertProvincia", "sp_getAllProvincias");

                    SqlParameter[] param1 = new SqlParameter[11];
                    param1[0] = new SqlParameter("@remitoID", new System.Guid(tab.Controls.Find("tbRemitoID", true)[0].Text));
                    param1[1] = new SqlParameter("@destinatarioNombre", tab.Controls.Find("tbNombreDestinatario", true)[0].Text);
                    param1[2] = new SqlParameter("@destinatarioDireccion", tab.Controls.Find("tbDireccionDestinatario", true)[0].Text);
                    //param1[3] = new SqlParameter("@regaloEmpresario", ((CheckBox)tab.Controls.Find("chkRBRegaloEmpresario", true)[0]).Checked);
                    param1[3] = new SqlParameter("@regaloEmpresario", true);  //OJO!!!!!!!!!!!!!
                    param1[4] = new SqlParameter("@obsequiante", tab.Controls.Find("tbObsequiante", true)[0].Text);
                    param1[5] = new SqlParameter("@bultos", tab.Controls.Find("tbBultos", true)[0].Text);
                    param1[6] = new SqlParameter("@zonaID", new Guid(zonaID));
                    param1[7] = new SqlParameter("@fleteID", new Guid(fleteID));
                    param1[8] = new SqlParameter("@localidadID", new Guid(localidadID));
                    param1[9] = new SqlParameter("@provinciaID", new Guid(provinciaID));
                    param1[10] = new SqlParameter("@sucursalID", (Guid)((ComboBox)tab.Controls.Find("cbRSucursal", true)[0]).SelectedValue);

                    SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_ModificarRemitoDestinatario", param1);

                    //Actualiza el estado del Remito
                    param1 = new SqlParameter[2];
                    param1[0] = new SqlParameter("@ID", new System.Guid(tab.Controls.Find("tbRemitoID", true)[0].Text));
                    param1[1] = new SqlParameter("@estadoRemito", estadoRemito);
                    SqlHelper.ExecuteNonQuery(configuracion.getConectionString(), "sp_ActualizarEstadoRemito", param1);

                    resultado = true;
                }
                catch (Exception e)
                {
                    ManejadorErrores.escribirLog(e, true);
                    MessageBox.Show(e.Message, "Error al Guardar el Remito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultado = false;
                }
                //UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
                ((Form)tab.FindForm()).Cursor = Cursors.Arrow;

                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return false;
            }
        }


    }
}
