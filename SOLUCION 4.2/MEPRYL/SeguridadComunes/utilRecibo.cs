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
    class utilRecibo
    {
        public static void buscarConcepto(Configuracion configuracion, ref GroupBox gb, string clienteID)
        {
            try
            {
                if (clienteID != "" && clienteID!="0" && clienteID!=Utilidades.ID_VACIO)
                {
                    ComboBox cbConcepto = (ComboBox)gb.Controls.Find("cbConceptoAC", true)[0];

                    switch (UtilUI.obtenerIdentificadorCombo(ref cbConcepto))
                    {
                        case "FACTURA":
                            {
                                frmFacturaConsulta fc = new frmFacturaConsulta(configuracion, true, "CONSULTA_DESDE_RECIBO");
                                fc.clienteID = clienteID;
                                fc.controlContenedorResultados = gb;
                                //Crea y asigna el Delegate
                                fc.objDelegateDevolverID = new frmFacturaConsulta.DelegateDevolverID(buscarFactura);
                                fc.ShowDialog();
                                break;
                            }
                        case "NOTA_DEBITO":
                            break;
                        case "OTRO":
                            break;
                    }
                }
                else
                    MessageBox.Show("Primero debe seleccionar un cliente.", "Buscar Concepto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, configuracion);
			}
        }


        public static void buscarConceptoPago(Configuracion configuracion, ref TabControl tab, string clienteID)
        {
            try
            {
                if (clienteID != "" && clienteID != "0" && clienteID != Utilidades.ID_VACIO)
                {
                    frmNotaCreditoConsulta ncc = new frmNotaCreditoConsulta(configuracion, true, "CONSULTA_DESDE_RECIBO");
                    ncc.clienteID = clienteID;
                    ncc.controlContenedorResultados = tab;
                    //Crea y asigna el Delegate
                    ncc.objDelegateDevolverID = new frmNotaCreditoConsulta.DelegateDevolverID(buscarNotaCreditoPago);
                    ncc.ShowDialog();
                }
                else
                    MessageBox.Show("Primero debe seleccionar un cliente.", "Buscar Concepto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
        }

        
        //Busca la nota de credito cuando el cuadro de busqueda se cierra
        private static bool buscarNotaCreditoPago(Configuracion configuracion, string notaCreditoID, ref Control controlContenedorResultado)
        {
            try
            {
                bool encontrado = false;

                controlContenedorResultado.FindForm().Cursor = Cursors.WaitCursor;

                TextBox tbAdicional = (TextBox)controlContenedorResultado.Controls.Find("tbAdicional", true)[0];
                TextBox tbNotaCreditoID = (TextBox)controlContenedorResultado.Controls.Find("tbNotaCreditoID", true)[0];
                KMCurrencyTextBox.KMCurrencyTextBox tbImportePago = (KMCurrencyTextBox.KMCurrencyTextBox)controlContenedorResultado.Controls.Find("tbImportePago", true)[0];

                tbNotaCreditoID.Text = notaCreditoID;
                
                if (notaCreditoID != "" && notaCreditoID != Utilidades.ID_VACIO)
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@notaCreditoID", new Guid(notaCreditoID));
                    SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_getNotaCreditoByID", param);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        tbAdicional.Text = dr["Tipo N.C."].ToString() + " " + dr["notaCreditoSuc"].ToString() + "-" + dr["notaCreditoNro"].ToString();
                        tbImportePago.Text = String.Format("{0:C}", double.Parse(dr["total"].ToString()));
                        
                        dr.Close();

                        encontrado = true;
                    }
                    else
                    {
                        tbAdicional.Text = "";
                        tbNotaCreditoID.Text = Utilidades.ID_VACIO;
                        tbImportePago.Text = "$ 0,00";
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

        
        //Busca la factura cuando el cuadro de busqueda se cierra
        private static bool buscarFactura(Configuracion configuracion, string facturaID, ref Control controlContenedorResultado)
        {
            try
            {
                bool encontrado = false;

                controlContenedorResultado.FindForm().Cursor = Cursors.WaitCursor;

                ComboBox cbTipoFactura = (ComboBox)controlContenedorResultado.Controls.Find("cbTipoComprobante", true)[0];
                TextBox tbFacturaID = (TextBox)controlContenedorResultado.Controls.Find("tbFacturaID", true)[0];
                TextBox tbNroSuc = (TextBox)controlContenedorResultado.Controls.Find("tbNroSucAC", true)[0];
                TextBox tbNro = (TextBox)controlContenedorResultado.Controls.Find("tbNroAC", true)[0];
                KMCurrencyTextBox.KMCurrencyTextBox tbImporte = (KMCurrencyTextBox.KMCurrencyTextBox)controlContenedorResultado.Controls.Find("tbImporteAC", true)[0];
                
                if (facturaID != "")
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@facturaID", new Guid(facturaID));
                    SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_getFacturaByID", param);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        
                        tbFacturaID.Text = facturaID;
                        cbTipoFactura.Text= dr["Tipo Factura"].ToString();
                        tbNroSuc.Text = dr["facturaSuc"].ToString();
                        tbNro.Text = dr["facturaNro"].ToString();
                        tbImporte.Text = double.Parse(dr["total"].ToString()).ToString("C");
                        encontrado = true;
                    }
                    else
                    {
                        tbFacturaID.Text = "";
                        tbNroSuc.Text = "";
                        tbNro.Text = "";
                        tbImporte.Text = "$0,00";
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
