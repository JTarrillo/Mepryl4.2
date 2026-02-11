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
using KMCurrencyTextBox;

namespace Comunes
{
    class utilNotaCredito
    {
        public static void buscarConcepto(Configuracion configuracion, ref TabControl tab)
        {
            try
            {
                frmFacturaConsulta fc = new frmFacturaConsulta(configuracion, true, "CONSULTA_DESDE_NOTACREDITO");
                fc.controlContenedorResultados = tab;
                //Crea y asigna el Delegate
                fc.objDelegateDevolverID = new frmFacturaConsulta.DelegateDevolverID(buscarFactura);
                fc.ShowDialog();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
        }

        //Busca la factura cuando el cuadro de busqueda se cierra
        public static bool buscarFactura(Configuracion configuracion, string facturaID, ref Control controlContenedorResultado)
        {
            try
            {
                bool encontrado = false;

                controlContenedorResultado.FindForm().Cursor = Cursors.WaitCursor;

                TextBox tbFacturaID = (TextBox)controlContenedorResultado.Controls.Find("tbFacturaID", true)[0];
                TextBox tbFacturaSucursal = (TextBox)controlContenedorResultado.Controls.Find("tbFacturaSucursal", true)[0];
                TextBox tbFacturaNro = (TextBox)controlContenedorResultado.Controls.Find("tbFacturaNro", true)[0];
                Label lbClienteNombre = (Label)controlContenedorResultado.Controls.Find("lbClienteNombre", true)[0];
                Label lbIVA= (Label)controlContenedorResultado.Controls.Find("lbIVA", true)[0];
                Label lbDireccion = (Label)controlContenedorResultado.Controls.Find("lbDireccion", true)[0];
                Label lbCUIT = (Label)controlContenedorResultado.Controls.Find("lbCUIT", true)[0];
                ComboBox cbIVA = (ComboBox)controlContenedorResultado.Controls.Find("cbIVA", true)[0];

                //Controles agregados para obtener toda la informacion de la factura
                ComboBox cbAutorizadorBonificacion = (ComboBox)controlContenedorResultado.Controls.Find("cbAutorizadorBonificacion", true)[0];
                Label lblSubTotal1 = (Label)controlContenedorResultado.Controls.Find("lblSubTotal1", true)[0];
                TextBox tbBonificacion = (TextBox)controlContenedorResultado.Controls.Find("tbBonificacion", true)[0];
                Label lblBonificacion = (Label)controlContenedorResultado.Controls.Find("lblBonificacion", true)[0];
                Label lblSubTotal2 = (Label)controlContenedorResultado.Controls.Find("lblSubTotal2", true)[0];
                Label lblIva1 = (Label)controlContenedorResultado.Controls.Find("lblIva1", true)[0];
                Label lblIva2 = (Label)controlContenedorResultado.Controls.Find("lblIva2", true)[0];
                Label lblTotal = (Label)controlContenedorResultado.Controls.Find("lblTotal", true)[0];
                DataGrid dgSubArticulos = (DataGrid)controlContenedorResultado.Controls.Find("dgSubArticulos", true)[0];
                

                if (facturaID != "" && facturaID != Utilidades.ID_VACIO)
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@facturaID", new Guid(facturaID));
                    SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_getFacturaByID", param);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        //Carga la cabecera
                        tbFacturaID.Text = facturaID;
                        tbFacturaSucursal.Text = dr["facturaSuc"].ToString();
                        tbFacturaNro.Text = dr["facturaNro"].ToString();
                        //lbClienteNombre.Text = dr["Nombre Cliente"].ToString();
                        lbClienteNombre.Text = dr["Razón Social"].ToString();
                        lbIVA.Text = dr["IVA"].ToString();
                        lbDireccion.Text = dr["Dirección Cliente"].ToString();
                        lbCUIT.Text = dr["CUIT"].ToString();
                        cbIVA.SelectedValue = new Guid(dr["ivaIDCliente"].ToString());

                        //Carga otros datos de cabecera
                        UtilUI.llenarCombo(ref cbAutorizadorBonificacion, configuracion.getConectionString(), "sp_getAllVendedors", "", -1);
                        cbAutorizadorBonificacion.SelectedValue = dr["autorizadorBonificacionID"].ToString();

                        //Subtotal 1
                        decimal subTotal1 = decimal.Parse(dr["SubTotal 1"].ToString());
                        lblSubTotal1.Text = subTotal1.ToString("C");

                        //Bonificacion
                        decimal bonificacionPorc = decimal.Parse(dr["Bonif. %"].ToString());
                        tbBonificacion.Text = bonificacionPorc.ToString("N");
                        decimal bonificacionImp = decimal.Parse(dr["Bonif. Importe"].ToString());
                        lblBonificacion.Text = bonificacionImp.ToString("C");

                        //Subtotal 2
                        decimal subTotal2 = decimal.Parse(dr["SubTotal 2"].ToString());
                        lblSubTotal2.Text = subTotal2.ToString("C");

                        //Iva 1
                        //decimal iva1Porc = configuracion.parametros
                        decimal iva1Imp = decimal.Parse(dr["IVA 1"].ToString());
                        lblIva1.Text = iva1Imp.ToString("C");
                        //Iva 2
                        //decimal iva2Porc = configuracion.parametros
                        decimal iva2Imp = decimal.Parse(dr["IVA 2"].ToString());
                        lblIva2.Text = iva2Imp.ToString("C");

                        //Total general
                        decimal total = decimal.Parse(dr["total"].ToString());
                        lblTotal.Text = total.ToString("C");


                        /********************************
                         * Carga los items en la grilla
                         * ******************************/
                        //Borra los registros de la grilla de SubArticulos
                        DataTable tabla = (DataTable)dgSubArticulos.DataSource;
                        tabla.Rows.Clear();
                        //Carga los articulos componentes
                        param = new SqlParameter[1];
                        param[0] = new SqlParameter("@facturaID", new System.Guid(tbFacturaID.Text));
                        dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_getAllFacturaLineas", param);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                DataRow newRow = tabla.NewRow();
                                newRow["itemNro"] = dr["itemNro"].ToString();
                                newRow["Código Interno"] = dr["codigoInterno"].ToString();
                                newRow["Código de Barras"] = dr["codigoBarras"].ToString();
                                newRow["Cantidad"] = dr["cantidad"].ToString();
                                newRow["Rubro"] = dr["Rubro"].ToString();
                                newRow["Sub Rubro"] = dr["SubRubro"].ToString();
                                newRow["Descripción"] = dr["descripcion"].ToString();
                                newRow["articuloID"] = dr["articuloID"].ToString();
                                newRow["Precio"] = dr["precioUnitario"].ToString();
                                newRow["precioTotal"] = dr["precioTotal"].ToString();
                                newRow["precioTotalConDesc"] = dr["precioTotalConDesc"].ToString();
                                newRow["Promocion"] = dr["aplicaPromocion"].ToString() == "1" ? true : false;
                                newRow["Descuento"] = dr["descuento"].ToString();
                                tabla.Rows.Add(newRow);
                            }
                        }
                        dr.Close();



                        
                        encontrado = true;
                    }
                    else
                    {
                        tbFacturaID.Text = "";
                        tbFacturaSucursal.Text = "";
                        tbFacturaNro.Text = "";
                        lbClienteNombre.Text = "";
                        lbIVA.Text = "";
                        lbDireccion.Text = "";
                        lbCUIT.Text = "";
                        //cbIVA.SelectedValue = new Guid(dr["ivaIDCliente"].ToString());

                        encontrado = false;
                    }
                    dr.Close();
                }
                controlContenedorResultado.FindForm().Cursor = Cursors.Arrow;
                return encontrado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return false;
            }
        }
    }
}