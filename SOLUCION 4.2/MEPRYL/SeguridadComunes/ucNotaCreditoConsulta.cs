using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Comunes
{
    public partial class ucNotaCreditoConsulta : UserControl
    {
        public StatusBar statusBarPrincipal;
        public Form formContenedor;
        public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
        public Configuracion m_configuracion;
        public bool consultaRapida = false;
        //public bool facturaDescuento = false;
        public string tipoPresentacion = "";
        public string clienteID = "";

        private Control tbCodigoUsado;

        public DataSet dataset = (DataSet)new dsArticulos();
        public DataSet datasetFormaPagoLineas = (DataSet)new dsFormaPagoLinea();

        public ucNotaCreditoConsulta()
        {
            InitializeComponent();
        }

        public Configuracion configuracion
        {
            get
            {
                return m_configuracion;
            }
            set
            {
                m_configuracion = value;
                if (m_configuracion != null)
                    conexion = m_configuracion.getConectionString();
            }
        }


        private void ucFacturaConsulta_Load(object sender, System.EventArgs e)
        {
            tbRazonSocialB.Select(); 
        }

        private void acomodarCombosOrden()
        {
            try
            {
                cbCampoOrden1.SelectedIndex = 21;  //Tipo Factura
                rbAsc1.Checked = true;
                cbCampoOrden2.SelectedIndex = 15;  //Nro Factura
                rbAsc2.Checked = true;
                cbCampoOrden3.SelectedIndex = 0;  //Nada
                rbAsc3.Checked = true;
                cbCampoOrden4.SelectedIndex = 0;  //Nada
                rbAsc4.Checked = true;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butBuscar1_Click(object sender, System.EventArgs e)
        {
            ejecutarBusqueda();
        }

        //Ejecuta el select de la busqueda
        private void ejecutarBusqueda()
        {
            try
            {
                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Ejecutando búsqueda...", true);

                string sqlTotal = construirSQL();

                SqlConnection oConn = new SqlConnection(this.conexion);
                SqlCommand oComm = new SqlCommand();
                SqlDataAdapter oSQLDataAdapter;

                oComm.Connection = oConn;
                oComm.CommandType = CommandType.Text;
                oComm.CommandText = sqlTotal;

                //open connection
                oConn.Open();

                //prepare data adapter object
                oSQLDataAdapter = new SqlDataAdapter();

                //Si es Factura con descuento, le cambia el nombre a la tabla para que tome otro TableStyle
                string nombreTabla = "";
                switch (this.tipoPresentacion)
                {
                    case "":
                        nombreTabla = "Items";
                        break;
                    case "FACTURA_CON_DESCUENTO":
                        nombreTabla = "FacturaDescuento";
                        break;
                    case "CONSULTA_DESDE_RECIBO":
                        nombreTabla = "Items";
                        break;
                    case "CONSULTA_DESDE_NOTACREDITO":
                        nombreTabla = "Items";
                        break;
                    case "CONSULTA_DESDE_NOTAPEDIDO":
                        nombreTabla = "Items";
                        break;

                }

                oSQLDataAdapter.TableMappings.Add("Table", nombreTabla);

                oSQLDataAdapter.SelectCommand = oComm;

                //initialize dataset
                DataSet dsItems = new DataSet(nombreTabla);
                oSQLDataAdapter.Fill(dsItems);

                //prepare dataview to sort
                DataView dvItems;
                dvItems = new DataView(dsItems.Tables[nombreTabla]);
                //dgItems.DataSource = dvItems;
                dgItems.DataSource = dsItems.Tables[nombreTabla];
                dgItems.Visible = true;

                //close connection
                oConn.Close();

                if (this.consultaRapida)
                {
                    if (dvItems.Table.Rows.Count > 0)
                        butAceptar1.Select();
                }

                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private string construirSQL()
        {
            try
            {
                string filtro = obtenerWHERE();
                string order = obtenerORDER();

                string sql = "SELECT     dbo.NotaCredito.fecha_creacion AS Fecha, dbo.NotaCredito.clienteID, dbo.Cliente.apellido, dbo.Cliente.nombres, " +
                      "dbo.Factura.nombreCliente AS [Razón Social], dbo.Factura.ivaIDCliente, dbo.IVA.descripcion AS IVA, dbo.Factura.direccionCliente AS [Dirección Cliente],  " +
                      "dbo.Factura.cuitCliente AS CUIT, dbo.NotaCredito.id, dbo.Factura.direccionEntrega AS [Dirección Entrega], dbo.NotaCredito.vendedorID,  " +
                      "Usuario_1.apellido + ', ' + Usuario_1.nombre AS Vendedor, dbo.NotaCredito.autorizadorBonificacionID,  " +
                      "Usuario_1.apellido + ', ' + Usuario_1.nombre AS Autorizó, dbo.NotaCredito.bonificacion AS [Bonif. %], dbo.NotaCredito.subTotal1 AS [SubTotal 1],  " +
                      "dbo.NotaCredito.iva1 AS [IVA 1], dbo.NotaCredito.iva2 AS [IVA 2], dbo.NotaCredito.total, dbo.NotaCredito.estadoNotaCreditoID,  " +
                      "dbo.NotaCredito.maquinaID, dbo.Maquina.nombre AS Máquina, dbo.NotaCredito.subTotal2 AS [SubTotal 2],  " +
                      "dbo.NotaCredito.bonificacionImporte AS [Bonif. Importe], dbo.NotaCredito.formaPagoID, dbo.NotaCredito.notaCreditoSuc,  " +
                      "dbo.NotaCredito.notaCreditoNro, dbo.NotaCredito.notaCreditoTipo AS [Tipo N.C.],  " +
                      "dbo.NotaCredito.notaCreditoSuc + '-' + dbo.NotaCredito.notaCreditoNro AS [Nro. N.C.], dbo.NotaCredito.jornadaVentaID,  " +
                      "RIGHT('00' + RTRIM(LTRIM(CAST(dbo.Sucursal.numero AS char(2)))), 2) + ' - ' + dbo.Sucursal.nombre AS Sucursal, dbo.Factura.notaPedidoID,  " +
                      "dbo.tv_NotaCreditoEstado.descripcion AS Estado, dbo.NotaCredito.estadoCuentaCorrienteID,  " +
                      "dbo.tv_NotaCreditoEstadoCuentaCorriente.descripcion AS [Estado Cta. Cte.], dbo.tv_PlazoPago.descripcion AS [Plazo Pago],  " +
                      "dbo.JornadaVenta.jornadaVentaNro AS [Ejercicio Nro.], dbo.Factura.facturaSuc, dbo.Factura.facturaNro,  " +
                      "dbo.Factura.facturaSuc + '-' + dbo.Factura.facturaNro AS Factura, dbo.NotaCredito.sucursalID " +
                        "FROM         dbo.Factura RIGHT OUTER JOIN " +
                      "dbo.NotaCredito ON dbo.Factura.id = dbo.NotaCredito.facturaID LEFT OUTER JOIN " +
                      "dbo.JornadaVenta ON dbo.NotaCredito.jornadaVentaID = dbo.JornadaVenta.id LEFT OUTER JOIN " +
                      "dbo.FormaPago INNER JOIN " +
                      "dbo.tv_PlazoPago ON dbo.FormaPago.plazoPagoID = dbo.tv_PlazoPago.id ON dbo.NotaCredito.formaPagoID = dbo.FormaPago.id LEFT OUTER JOIN " +
                      "dbo.tv_NotaCreditoEstadoCuentaCorriente ON dbo.NotaCredito.estadoCuentaCorrienteID = dbo.tv_NotaCreditoEstadoCuentaCorriente.id LEFT OUTER JOIN " +
                      "dbo.tv_NotaCreditoEstado ON dbo.NotaCredito.estadoNotaCreditoID = dbo.tv_NotaCreditoEstado.id LEFT OUTER JOIN " +
                      "dbo.Sucursal ON dbo.NotaCredito.sucursalID = dbo.Sucursal.id LEFT OUTER JOIN " +
                      "dbo.Maquina ON dbo.NotaCredito.maquinaID = dbo.Maquina.id LEFT OUTER JOIN " +
                      "dbo.Vendedor AS Vendedor_1 INNER JOIN " +
                      "dbo.Usuario AS Usuario_1 ON Vendedor_1.usuarioID = Usuario_1.id ON dbo.NotaCredito.autorizadorBonificacionID = Vendedor_1.id LEFT OUTER JOIN " +
                      "dbo.Usuario AS Usuario_2 INNER JOIN " +
                      "dbo.Vendedor AS Vendedor_2 ON Usuario_2.id = Vendedor_2.usuarioID ON dbo.NotaCredito.vendedorID = Vendedor_2.id LEFT OUTER JOIN " +
                      "dbo.IVA ON dbo.Factura.ivaIDCliente = dbo.IVA.id LEFT OUTER JOIN " +
                      "dbo.Cliente ON dbo.Factura.clienteID = dbo.Cliente.id " +
                "WHERE " + filtro;

                string sqlTotal = "";

                sqlTotal = sql + " " + order;

                return sqlTotal;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }

        private string obtenerWHERE()
        {
            try
            {
                string filtro = "1=1";

                //Filtro Rapido
                if (cbNotaCreditoTipoB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND notaCreditoTipo ='" + cbNotaCreditoTipoB.Text.Trim() + "'";
                }
                if (tbNotaCreditoSucDesdeB.Text != "" && tbNotaCreditoNroDesdeB.Text != "")
                {
                    filtro = filtro + " AND CAST(dbo.NotaCredito.notaCreditoSuc AS int) >= " + int.Parse(tbNotaCreditoSucDesdeB.Text);
                    filtro = filtro + " AND CAST(dbo.NotaCredito.notaCreditoNro AS int) >= " + int.Parse(tbNotaCreditoNroDesdeB.Text);
                }
                if (tbNotaCreditoSucHastaB.Text != "" && tbNotaCreditoNroHastaB.Text != "")
                {
                    filtro = filtro + " AND CAST(dbo.NotaCredito.notaCreditoSuc AS int) <= " + int.Parse(tbNotaCreditoSucHastaB.Text);
                    filtro = filtro + " AND CAST(dbo.NotaCredito.notaCreditoNro AS int) <= " + int.Parse(tbNotaCreditoNroHastaB.Text);
                }
                if (tbRazonSocialB.Text != "")
                {
                    filtro = filtro + " AND dbo.Factura.nombreCliente LIKE '%" + tbRazonSocialB.Text.Trim() + "%'";
                }
                if (tbCuitB.Text != "")
                {
                    filtro = filtro + " AND dbo.Factura.cuitCliente = " + tbCuitB.Text.Trim();
                }
                //Fechas
                DateTime fechaDesde, fechaHasta;
                string dia, mes, anio, sfechaDesde, sfechaHasta;
                if (chkFechaEmision.Checked)
                {
                    fechaDesde = dtpFechaEmisionDesde.Value;
                    fechaHasta = dtpFechaEmisionHasta.Value;
                    dia = fechaDesde.Day.ToString("00");
                    mes = fechaDesde.Month.ToString("00");
                    anio = fechaDesde.Year.ToString("0000");
                    sfechaDesde = "{ts '" + anio + "-" + mes + "-" + dia + " 00:00:00'}";
                    filtro = filtro + " AND dbo.NotaCredito.fecha_creacion >= " + sfechaDesde;

                    dia = fechaHasta.Day.ToString("00");
                    mes = fechaHasta.Month.ToString("00");
                    anio = fechaHasta.Year.ToString("0000");
                    sfechaHasta = "{ts '" + anio + "-" + mes + "-" + dia + " 23:59:59'}";
                    filtro = filtro + " AND dbo.NotaCredito.fecha_creacion <= " + sfechaHasta;
                }
                if (cbBonificacionB.Text == "Con Bonif.")
                {
                    filtro = filtro + " AND dbo.NotaCredito.bonificacion > 0";
                }
                else if (cbBonificacionB.Text == "Sin Bonif.")
                {
                    filtro = filtro + " AND dbo.NotaCredito.bonificacion = 0";
                }
                if (cbAutorizadorB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND dbo.NotaCredito.autorizadorBonificacionID = CAST('" + cbAutorizadorB.SelectedValue.ToString() + "' AS uniqueidentifier)";
                }

                //Filtro Avanzado
                if (tbFacturaSucDesdeB.Text != "" && tbFacturaNroDesdeB.Text != "")
                {
                    filtro = filtro + " AND CAST(dbo.Factura.facturaSuc AS int) >= " + int.Parse(tbFacturaSucDesdeB.Text);
                    filtro = filtro + " AND CAST(dbo.Factura.facturaNro AS int) >= " + int.Parse(tbFacturaNroDesdeB.Text);
                }
                if (tbFacturaSucHastaB.Text != "" && tbFacturaNroHastaB.Text != "")
                {
                    filtro = filtro + " AND CAST(dbo.Factura.facturaSuc AS int) <= " + int.Parse(tbFacturaSucHastaB.Text);
                    filtro = filtro + " AND CAST(dbo.Factura.facturaNro AS int) <= " + int.Parse(tbFacturaNroHastaB.Text);
                }
                if (cbVendedorB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND dbo.NotaCredito.vendedorID = CAST('" + cbVendedorB.SelectedValue.ToString() + "' AS uniqueidentifier)";
                }
                if (tbEjercicioNroB.Text != "")
                {
                    filtro += " AND dbo.JornadaVenta.jornadaVentaNro = " + tbEjercicioNroB.Text;
                }
                /*if (cbCondicionEntregaB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND dbo.Factura.condicionEntregaID = CAST('" + cbCondicionEntregaB.SelectedValue.ToString() + "' AS uniqueidentifier)";
                }*/
                if (cbEstadoB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND dbo.NotaCredito.estadoNotaCreditoID = CAST('" + cbEstadoB.SelectedValue.ToString() + "' AS uniqueidentifier)";
                }
                if (cbEstadoCtaCteB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND dbo.NotaCredito.estadoCuentaCorrienteID = CAST('" + cbEstadoCtaCteB.SelectedValue.ToString() + "' AS uniqueidentifier)";
                }
                if (cbSucursalB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND dbo.NotaCredito.sucursalID = CAST('" + cbSucursalB.SelectedValue.ToString() + "' AS uniqueidentifier)";
                }
                /*if (cbPlazoPagoB.SelectedIndex > 0)
                {
                    filtro = filtro + " AND dbo.FormaPago.plazoPagoID = CAST('" + cbPlazoPagoB.SelectedValue.ToString() + "' AS uniqueidentifier)";

                    if (cbEstadoFacturaCtaCteB.SelectedIndex > 0)
                        filtro = filtro + " AND dbo.Factura.estadoCuentaCorrienteID = CAST('" + cbEstadoFacturaCtaCteB.SelectedValue.ToString() + "' AS uniqueidentifier)";
                }*/
                if (tbClienteIDB.Text != "")
                {
                    filtro += " AND dbo.NotaCredito.clienteID = CAST('" + tbClienteIDB.Text + "' AS uniqueidentifier)";
                }

                return filtro;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }


        private string obtenerORDER()
        {
            try
            {
                string orden = "";
                string coma = "";
                string sentido = "";

                if (cbCampoOrden1.Text != "---")
                {
                    if (orden.IndexOf("[" + cbCampoOrden1.Text + "]") == -1)
                    {
                        sentido = rbAsc1.Checked ? " ASC " : " DESC ";
                        orden = "[" + cbCampoOrden1.Text + "]" + sentido;
                    }
                }
                if (cbCampoOrden2.Text != "---")
                {
                    coma = "";
                    if (orden != "") coma = ", ";

                    if (orden.IndexOf("[" + cbCampoOrden2.Text + "]") == -1)
                    {
                        sentido = rbAsc2.Checked ? " ASC " : " DESC ";
                        orden += coma + "[" + cbCampoOrden2.Text + "]" + sentido;
                    }
                }
                if (cbCampoOrden3.Text != "---")
                {
                    coma = "";
                    if (orden != "") coma = ", ";

                    if (orden.IndexOf("[" + cbCampoOrden3.Text + "]") == -1)
                    {
                        sentido = rbAsc3.Checked ? " ASC " : " DESC ";
                        orden += coma + "[" + cbCampoOrden3.Text + "]" + sentido;
                    }
                }
                if (cbCampoOrden4.Text != "---")
                {
                    coma = "";
                    if (orden != "") coma = ", ";

                    if (orden.IndexOf("[" + cbCampoOrden4.Text + "]") == -1)
                    {
                        sentido = rbAsc4.Checked ? " ASC " : " DESC ";
                        orden += coma + "[" + cbCampoOrden4.Text + "]" + sentido;
                    }
                }

                if (orden != "") orden = " ORDER BY " + orden;

                return orden;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return null;
            }
        }

        private void butBuscar3_Click(object sender, System.EventArgs e)
        {
            ejecutarBusqueda();
        }

        private void butSalir3_Click(object sender, System.EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void butSalir1_Click(object sender, System.EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void butLimpiar1_Click(object sender, System.EventArgs e)
        {
            try
            {
                cbNotaCreditoTipoB.SelectedIndex = 0;
                tbFacturaSucDesdeB.Text = "";
                tbFacturaNroDesdeB.Text = "";
                tbFacturaSucHastaB.Text = "";
                tbFacturaNroHastaB.Text = "";
                tbRazonSocialB.Text = "";
                tbCuitB.Text = "";
                chkFechaEmision.Checked = false;
                cbBonificacionB.SelectedIndex = 0;
                cbAutorizadorB.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void dgItems_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (this.consultaRapida)
                    ((Form)this.Parent).Close();
                else
                    tabPrincipal.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tabPrincipal_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (tabPrincipal.SelectedIndex == 1)
                {
                    this.Refresh();
                    if (dgItems.DataSource != null)
                        if (((DataTable)dgItems.DataSource).Rows.Count > 0)
                        {
                            cargarDetalle();
                            //tabNotaPedido.Enabled = true;
                        }
                        else
                            tabNotaPedido.Enabled = false;
                    else
                        tabNotaPedido.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void cargarDetalle()
        {
            try
            {
                if (dgItems.DataSource != null)
                    if (((DataTable)dgItems.DataSource).Rows.Count > 0)
                    {
                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Cargando...", true);

                        DataTable dt = (DataTable)dgItems.DataSource;
                        int currentRow = dgItems.CurrentRowIndex;

                        tbNotaCreditoID.Text = dt.Rows[currentRow]["ID"].ToString();
                        tbFacturaSucursal.Text = dt.Rows[currentRow]["facturaSuc"].ToString();
                        tbFacturaNro.Text = dt.Rows[currentRow]["facturaNro"].ToString();
                        tbClienteID.Text = dt.Rows[currentRow]["clienteID"].ToString();
                        lbClienteNombre.Text = dt.Rows[currentRow]["Razón Social"].ToString();
                        lbDireccion.Text = dt.Rows[currentRow]["Dirección Cliente"].ToString();
                        //tbDireccionEntrega.Text = dt.Rows[currentRow]["Dirección Entrega"].ToString();
                        lbCUIT.Text = dt.Rows[currentRow]["CUIT"].ToString();

                        UtilUI.llenarCombo(ref cbIVA, this.conexion, "sp_getAllIVAs", "", -1);
                        cbIVA.SelectedValue = dt.Rows[currentRow]["ivaIDCliente"].ToString();
                        lbIVA.Text = cbIVA.Text;


                        //Pone el numero y el estado en el titulo
                        string nroNotaCredito = dt.Rows[currentRow]["notaCreditoSuc"].ToString() + "-" + dt.Rows[currentRow]["notaCreditoNro"].ToString();
                        string estadoNotaCredito = dt.Rows[currentRow]["Estado"].ToString();
                        string estadoCtaCte = dt.Rows[currentRow]["Estado Cta. Cte."].ToString();
                        lbTitulo.Text = "     Nota Crédito Nº: " + nroNotaCredito + ", " + estadoNotaCredito + ", " + estadoCtaCte;


                        UtilUI.llenarCombo(ref cbVendedor, this.conexion, "sp_getAllVendedors", "", -1);
                        cbVendedor.SelectedValue = dt.Rows[currentRow]["vendedorID"].ToString();

                        

                        UtilUI.llenarCombo(ref cbEstado, this.conexion, "sp_getAlltv_NotaCreditoEstados", "", -1);
                        cbEstado.SelectedValue = dt.Rows[currentRow]["estadoNotaCreditoID"].ToString();

                        UtilUI.llenarCombo(ref cbEstadoCtaCte, this.conexion, "sp_getAlltv_NotaCreditoCuentaCorrienteEstados", "", -1);
                        cbEstadoCtaCte.SelectedValue = dt.Rows[currentRow]["estadoCuentaCorrienteID"].ToString();


                        UtilUI.llenarCombo(ref cbAutorizadorBonificacion, this.conexion, "sp_getAllVendedors", "", -1);
                        cbAutorizadorBonificacion.SelectedValue = dt.Rows[currentRow]["autorizadorBonificacionID"].ToString();

                        //Subtotal 1
                        decimal subTotal1 = decimal.Parse(dt.Rows[currentRow]["SubTotal 1"].ToString());
                        lblSubTotal1.Text = subTotal1.ToString("C");

                        //Bonificacion
                        decimal bonificacionPorc = decimal.Parse(dt.Rows[currentRow]["Bonif. %"].ToString());
                        tbBonificacion.Text = bonificacionPorc.ToString("N");
                        decimal bonificacionImp = decimal.Parse(dt.Rows[currentRow]["Bonif. Importe"].ToString());
                        lblBonificacion.Text = bonificacionImp.ToString("C");

                        //Subtotal 2
                        decimal subTotal2 = decimal.Parse(dt.Rows[currentRow]["SubTotal 2"].ToString());
                        lblSubTotal2.Text = subTotal2.ToString("C");

                        //Iva 1
                        //decimal iva1Porc = configuracion.parametros
                        decimal iva1Imp = decimal.Parse(dt.Rows[currentRow]["IVA 1"].ToString());
                        lblIva1.Text = iva1Imp.ToString("C");
                        //Iva 2
                        //decimal iva2Porc = configuracion.parametros
                        decimal iva2Imp = decimal.Parse(dt.Rows[currentRow]["IVA 2"].ToString());
                        lblIva2.Text = iva2Imp.ToString("C");

                        //Total general
                        decimal total = decimal.Parse(dt.Rows[currentRow]["total"].ToString());
                        lblTotal.Text = total.ToString("C");


                        /********************************
                         * Carga los items en la grilla
                         * ******************************/
                        //Borra los registros de la grilla de SubArticulos
                        DataTable tabla = (DataTable)dgSubArticulos.DataSource;
                        tabla.Rows.Clear();
                        //Carga los articulos componentes
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@notaCreditoID", new System.Guid(tbNotaCreditoID.Text));
                        SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllNotaCreditoLineas", param);
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


                        lblRegistro.Text = (currentRow + 1).ToString() + " de " + dt.Rows.Count.ToString();
                        lblRegistro2.Text = lblRegistro.Text;

                        //Carga las formas de pago
                        cargarFormasPago(dt.Rows[currentRow]["formaPagoID"].ToString());

                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
                    }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butAnterior_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dgItems.CurrentRowIndex > 0)
                {
                    dgItems.CurrentRowIndex = dgItems.CurrentRowIndex - 1;
                    cargarDetalle();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butSiguiente_Click(object sender, System.EventArgs e)
        {
            try
            {
                int count = ((DataTable)dgItems.DataSource).Rows.Count - 1;
                if (dgItems.CurrentRowIndex < count)
                {
                    dgItems.CurrentRowIndex = dgItems.CurrentRowIndex + 1;
                    cargarDetalle();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butLimpiar_Click(object sender, System.EventArgs e)
        {
            //limpiarFormulario();
        }

        private void limpiarFormularioFormasPago()
        {
            try
            {
                //Limpia solo las Formas de pago
                /*tbFormaPagoID.Text = "";
                tbImportePago.Text = "$ 0,00";
                tbImportePago.Text = "$ 0,00";
                lblAjusteValor.Text = "0,00";
                tbPesos.Text = "$ 0,00";
                tbAdicional.Text = "";
                ((DataTable)dgPagos.DataSource).Rows.Clear();
                lblTotalPagos.Text = "0";
                lblTotalNotaCreditodo.Text = "0";
                lblInteresPorV.Text = "0";
                lblInteresValV.Text = "0";
                lblTotalConInteresV.Text = "0";
                lblSaldoPagos.Text = "0";*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butSalir_Click(object sender, System.EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void butGuardar_Click(object sender, System.EventArgs e)
        {
            UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Guardando registro...", true);
            if (validarFormulario())
                guardarCambios();
            else
                UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
        }

        private bool validarFormulario()
        {
            try
            {
                string mensaje = "";
                bool resultado = true;

                /*
                if (tbRazonSocial.Text.Trim()=="")
                {
                    mensaje += "   - Debe ingresar la Razón Social.\r\n";
                    resultado = false;
                }

                if (mensaje!="")
                {
                    mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
                    MessageBox.Show(mensaje, "Alta de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                */

                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        //Guarda los cambios efectuados al registro
        private void guardarCambios()
        {
            /*

            int localidadID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbLocalidad, "sp_InsertLocalidad");
            int provinciaID = UtilUI.obtenerIDListaActualizable(this.conexion, ref cbProvincia, "sp_InsertProvincia");

            SqlParameter[] param = new SqlParameter[13];
			
            param[0] = new SqlParameter("@ID", tbID.Text.Trim());
            param[1] = new SqlParameter("@razonSocial", tbRazonSocial.Text.Trim());
            param[2] = new SqlParameter("@calle", tbCalle.Text.Trim());
            param[3] = new SqlParameter("@telefonos", tbTelefonos.Text.Trim());
            param[4] = new SqlParameter("@nro", tbNro.Text.Trim());
            param[5] = new SqlParameter("@piso", tbPiso.Text.Trim());
            param[6] = new SqlParameter("@oficina", tbOficina.Text.Trim());
            param[7] = new SqlParameter("@codigoPostal", tbCodPost.Text.Trim());
            param[8] = new SqlParameter("@email", tbEmail.Text.Trim());
            param[9] = new SqlParameter("@localidadID", localidadID);
            param[10] = new SqlParameter("@cuit", tbCuit.Text.Trim());
            param[11] = new SqlParameter("@provinciaID", provinciaID);
            param[12] = new SqlParameter("@notas", tbNotas.Text.Trim());
			
            while (true)
            {
                try 
                {
                    SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarProveedor", param);
                    MessageBox.Show("Proveedor modificado con éxito.", "Modificación de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Proveedor modificado con éxito.", false);
                    break;
                }
                catch (Exception e)
                {
                    DialogResult dr = MessageBox.Show("No se pudo modificar el Proveedor. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo modificar el Proveedor. \r\n" + e.Message, false);
                    if (dr != DialogResult.Retry)
                        break;
                }
            }
            */
        }

        private void butBorrar_Click(object sender, System.EventArgs e)
        {
            borrarRegistrosSeleccionados();
        }

        private void borrarRegistrosSeleccionados()
        {
            try
            {
                if (dgItems.DataSource != null)
                {
                    DataTable dt = (DataTable)dgItems.DataSource;

                    if (dt.Rows.Count > 0)
                    {
                        //Primero recorre los renglones seleccionados
                        string sRows = "";
                        string coma = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dgItems.IsSelected(i))
                            {
                                sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
                                coma = ",";
                            }
                        }

                        if (sRows != "")
                        {
                            DialogResult dr = MessageBox.Show("¿Desea borrar las Notas de Pedido seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Notas de Pedido...", true);
                                SqlParameter[] param = new SqlParameter[1];
                                string[] rows = sRows.Split(",".ToCharArray());
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    string id = rows[j].Split(":".ToCharArray())[0];
                                    int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

                                    param[0] = new SqlParameter("@id", new System.Guid(id));

                                    SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarProveedor", param);

                                    //dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = "-1";
                                }
                                //Recorre los renglones marcados para borrar
                                DataRow[] rowsBorrar = dt.Select("id='-1'");
                                for (int k = 0; k < rowsBorrar.Length; k++)
                                {
                                    rowsBorrar[k].Delete();
                                }
                                dt.AcceptChanges();
                                dgItems.Refresh();
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butLimpiar3_Click(object sender, System.EventArgs e)
        {
            acomodarCombosOrden();
        }

        private void tbReazonSocialB_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ejecutarBusqueda();
            }
        }

        private void butAceptar1_Click(object sender, System.EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        //Llena los comboBox y demas inicializaciones
        public void inicializarComponentes()
        {
            try
            {
                cbNotaCreditoTipoB.SelectedIndex = 0;
                cbBonificacionB.SelectedIndex = 0;

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@sucursalID", this.configuracion.sucursal.id);
                UtilUI.llenarCombo(ref cbAutorizadorB, this.conexion, "sp_getAllVendedorsBySucursal", "Todos", 0, param);
                UtilUI.llenarCombo(ref cbVendedorB, this.conexion, "sp_getAllVendedorsBySucursal", "Todos", 0, param);
                UtilUI.llenarCombo(ref cbEstadoB, this.conexion, "sp_getAlltv_NotaCreditoEstados", "Todos", 0);
                UtilUI.llenarCombo(ref cbEstadoCtaCteB, this.conexion, "sp_getAlltv_NotaCreditoCuentaCorrienteEstados", "Todos", 0);
                UtilUI.llenarCombo(ref cbCondicionEntregaB, this.conexion, "sp_getAlltv_NotaPedidoCondicionEntrega", "Todas", 0);
                UtilUI.llenarCombo(ref cbSucursalB, this.conexion, "sp_getAllSucursals", "Todas", 0);
                //UtilUI.llenarCombo(ref cbPlazoPagoB, this.conexion, "sp_getAlltv_PlazoPago", "Todos", 0);
                //UtilUI.llenarCombo(ref cbEstadoNotaCreditoCtaCteB, this.conexion, "sp_getAlltv_FacturaCuentaCorrienteEstados", "Todos", 0);
                acomodarCombosOrden();

                //Define el tipo de consulta
                if (consultaRapida)
                {
                    butSalir1.Visible = false;
                    butAceptar1.Visible = true;
                }
                else
                {
                    butSalir1.Visible = true;
                    butAceptar1.Visible = false;
                }

                //Asigna la tabla a la datagrid
                dgSubArticulos.DataSource = (DataTable)dataset.Tables["v_Articulo"];

                //Controles del Tab Formas de Pago
                /*dgPagos.DataSource = (DataTable)datasetFormaPagoLineas.Tables["v_FormaPagoLinea"];
                UtilUI.llenarCombo(ref cbCtadoCtaCte, this.conexion, "sp_getAlltv_PlazoPago", "", 0);
                UtilUI.llenarCombo(ref cbTipoPago, this.conexion, "sp_getAlltv_TipoPago", "", 0);
                UtilUI.llenarCombo(ref cbAdicional, this.conexion, "sp_getAlltv_CantidadPagos", "", 0);
                llenarTipoPagoDetalle();
                */
                //Establece el tab inicial
                tabNotaPedido.SelectedIndex = 0;

                //Segun el tipo de presentacion
                switch (this.tipoPresentacion)
                {
                    case "FACTURA_CON_DESCUENTO":
                        configurarFacturaConDescuento();
                        break;
                    case "CONSULTA_DESDE_RECIBO":
                        configurarParaRecibo();
                        break;
                    case "CONSULTA_DESDE_NOTACREDITO":
                        configurarParaNotaCredito();
                        break;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Devuelve el ID seleccionado en la grilla
        public string getID()
        {
            string id = Utilidades.ID_VACIO;

            if (dgItems.DataSource != null)
            {
                DataTable tabla = (DataTable)dgItems.DataSource;

                if (tabla.Rows.Count > 0)
                    if (dgItems.CurrentRowIndex >= 0)
                    {
                        id = tabla.Rows[dgItems.CurrentRowIndex]["id"].ToString();
                    }
            }
            return id;
        }

        private void butBuscarCliente_Click(object sender, System.EventArgs e)
        {
            abrirConsultaRapida();
        }

        //Abre el formulario de consulta en modo rapido
        private void abrirConsultaRapida()
        {
            try
            {
                frmClienteConsulta form = new frmClienteConsulta(this.configuracion, true);
                form.statusBar1 = this.statusBarPrincipal;

                //Crea y asigna el Delegate
                form.objDelegateDevolverID = new Comunes.frmClienteConsulta.DelegateDevolverID(buscarCliente);

                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        //Busca el proveedor segun el codigo ingresado.
        private bool buscarCliente(string clienteID)
        {
            try
            {
               /* bool encontrado = false;
                string razonSocial = "", direccion = "", cuit = "";
                string ivaID = Utilidades.ID_VACIO;

                this.Cursor = Cursors.WaitCursor;

                string sparam = "", sp = "";
                sparam = "@clienteID";
                sp = "sp_getClienteByID";

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter(sparam, new System.Guid(clienteID));
                SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

                //Si se encontro el registro
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["Empresa"].ToString() != "")
                    {
                        razonSocial = dr["Empresa"].ToString();
                        direccion = dr["Calle (empresa)"].ToString()
                            + "  Nro.:" + dr["Nro. (empresa)"].ToString()
                            + "  Piso:" + dr["Piso (empresa)"].ToString()
                            + "  Of.:" + dr["Of. (empresa)"].ToString()
                            + "  C.P.:" + dr["Cod.Post. (empresa)"].ToString();
                        cuit = dr["CUIT (empresa)"].ToString();
                        ivaID = dr["ivaID"].ToString();
                    }
                    else
                        razonSocial = dr["apellido"].ToString() + ", " + dr["nombres"].ToString();

                    encontrado = true;
                }
                else
                {
                    encontrado = false;
                }
                dr.Close();


                if (!encontrado)
                {
                    razonSocial = "No registrado.";
                    direccion = "";
                    cuit = "";
                    clienteID = Utilidades.ID_VACIO;
                    ivaID = Utilidades.ID_VACIO;
                }

                tbClienteID.Text = clienteID;
                tbClienteNombre.Text = razonSocial;
                tbDireccion.Text = direccion;
                tbCUIT.Text = cuit;
                cbIVA.SelectedValue = ivaID;

                this.Cursor = Cursors.Arrow;

                return encontrado;*/
                return true;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        private void tbCodigoInternoAC_Enter(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Enter");
        }

        private void tbCodigoInternoAC_Leave(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Leave");
        }

        private void tbCodigoInternoAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (buscarArticulo("CodigoInterno", tbCodigoInternoAC.Text))
                    {
                        tbCodigoUsado = (Control)sender;
                        tbCantidadAC.Select();
                    }
                    else
                        tbCodigoInternoAC.SelectAll();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbCodigoBarrasAC_Enter(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Enter");
        }

        private void tbCodigoBarrasAC_Leave(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Leave");
        }

        private void tbCodigoBarrasAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (buscarArticulo("CodigoBarras", tbCodigoBarrasAC.Text))
                    {
                        tbCodigoUsado = (Control)sender;
                        tbCantidadAC.Select();
                    }
                    else
                    {
                        tbCodigoBarrasAC.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbCantidadAC_Enter(object sender, System.EventArgs e)
        {
            try
            {
                controlarColorFondo(ref sender, "Enter");
                //Seleciona todo el texto
                tbCantidadAC.SelectAll();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbCantidadAC_Leave(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Leave");
        }

        private void tbCantidadAC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (Utilidades.IsNumeric(tbCantidadAC.Text))
                    {
                        agregarArticulo(ref tbCodigoUsado);
                    }
                    else
                    {
                        MessageBox.Show("La Cantidad debe ser un valor numérico.", "Valor Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbCantidadAC.Select();
                        tbCantidadAC.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butBuscarArticuloAC_Click(object sender, System.EventArgs e)
        {
            abrirConsultaRapidaArticulos();
        }

        private void butBuscarArticuloAC_Enter(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Enter");
        }

        private void butBuscarArticuloAC_Leave(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Leave");
        }

        private void butBorrarArticulosComponentes_Click(object sender, System.EventArgs e)
        {
            borrarRegistrosArticulosComponentes();
        }

        private void borrarRegistrosArticulosComponentes()
        {
            try
            {
                if (dgSubArticulos.DataSource != null)
                {
                    DataTable dt = (DataTable)dgSubArticulos.DataSource;

                    if (dt.Rows.Count > 0)
                    {
                        //Primero recorre los renglones seleccionados
                        string sRows = "";
                        string coma = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dgSubArticulos.IsSelected(i))
                            {
                                sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
                                coma = ",";
                            }
                        }

                        if (sRows != "")
                        {
                            DialogResult dr = MessageBox.Show("¿Desea borrar los Artículos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Artículos...", true);
                                string[] rows = sRows.Split(",".ToCharArray());
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    string id = rows[j].Split(":".ToCharArray())[0];
                                    int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

                                    //dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = "-1";
                                }
                                //Recorre los renglones marcados para borrar
                                DataRow[] rowsBorrar = dt.Select("id='-1'");
                                for (int k = 0; k < rowsBorrar.Length; k++)
                                {
                                    rowsBorrar[k].Delete();
                                }
                                dt.AcceptChanges();

                                //Renumera los items
                                renumerarItems();

                                dgSubArticulos.Refresh();
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Renumera los items de la Tabla
        private void renumerarItems()
        {
            try
            {
                DataTable dt = (DataTable)dgSubArticulos.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["itemNro"] = i + 1;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Busca el articulo segun el codigo ingresado.
        private bool buscarArticulo(string articuloID)
        {
            try
            {
                tbCodigoUsado = (Control)butBuscarArticuloAC;
                tbCantidadAC.Select();
                return buscarArticulo("", "", articuloID);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        /*
        private bool buscarArticulo(string tipoCodigo, string codigo)
        {
            return buscarArticulo(tipoCodigo, codigo, "");
        }
		
        private bool buscarArticulo(string tipoCodigo, string codigo, string p_articuloID)
        {
            try
            {
                bool encontrado = false;
                string rubro="", subRubro="", descripcion="", codigoInterno="", codigoBarras="", articuloID="";
                string precio="", promocion="";
			
                this.Cursor = Cursors.WaitCursor;
	
                string sparam="", sp="";
                if (p_articuloID!="")
                {
                    codigo = p_articuloID;
                    sparam = "@articuloID";
                    sp = "sp_getArticuloByID";
                }
                else if (tipoCodigo=="CodigoInterno")
                {
                    sparam = "@codigoInterno";
                    sp = "sp_getArticuloByCodigoInterno";
                }
                else if (tipoCodigo=="CodigoBarras")
                {
                    sparam = "@codigoBarras";
                    sp = "sp_getArticuloByCodigoBarras";
                }

                string valorCelda = codigo;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter(sparam, valorCelda);
                SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

                //Si se encontro el registro
                if (dr.HasRows)
                {
                    dr.Read();
                    rubro = dr["Rubro"].ToString();
                    subRubro = dr["Sub Rubro"].ToString();
                    descripcion = dr["Descripción"].ToString();
                    codigoInterno = dr["Código Interno"].ToString();
                    codigoBarras = dr["Código de Barras"].ToString();
                    articuloID = dr["id"].ToString();
                    precio = double.Parse(dr["Precio"].ToString()).ToString("N");
                    promocion = "True";
                    encontrado = true;
                }
                else
                {
                    encontrado = false;
                }
                dr.Close();


                if (!encontrado)
                {
                    rubro = "No registrado.";
                    subRubro = "No registrado.";
                    descripcion = "Artículo No Registrado.";
                    if (p_articuloID!="")
                    {
                        codigoInterno = "";
                        codigoBarras = "";
                    }
                    else
                    {
                        codigoInterno = tbCodigoInternoAC.Text;
                        codigoBarras = tbCodigoBarrasAC.Text;
                    }
                    articuloID = "";
                }

                tbRubroAC.Text = rubro;
                tbSubRubroAC.Text = subRubro;
                tbDescripcionAC.Text = descripcion;
                tbCodigoInternoAC.Text = codigoInterno;
                tbCodigoBarrasAC.Text = codigoBarras;
                tbID.Text = articuloID;
                tbPrecioAC.Text = precio;
                tbPromocionAC.Text = promocion;

                this.Cursor = Cursors.Arrow;

                return encontrado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        */
        private bool buscarArticulo(string tipoCodigo, string codigo)
        {
            return buscarArticulo(tipoCodigo, codigo, Utilidades.ID_VACIO);
        }

        private bool buscarArticulo(string tipoCodigo, string codigo, string p_articuloID)
        {
            try
            {
                bool encontrado = false;

                if (tipoCodigo != "" || codigo != "" || p_articuloID != Utilidades.ID_VACIO)
                {
                    string rubro = "", subRubro = "", descripcion = "", codigoInterno = "", codigoBarras = "", articuloID = Utilidades.ID_VACIO;
                    string precio = "", promocion = "";

                    this.Cursor = Cursors.WaitCursor;

                    string sparam = "", sp = "";
                    if (p_articuloID != Utilidades.ID_VACIO)
                    {
                        codigo = p_articuloID;
                        sparam = "@articuloID";
                        sp = "sp_getArticuloByID";
                    }
                    else if (tipoCodigo == "CodigoInterno")
                    {
                        sparam = "@codigoInterno";
                        sp = "sp_getArticuloByCodigoInterno";
                    }
                    else if (tipoCodigo == "CodigoBarras")
                    {
                        sparam = "@codigoBarras";
                        sp = "sp_getArticuloByCodigoBarras";
                    }

                    //string valorCelda = codigo;
                    SqlParameter[] param = new SqlParameter[1];

                    if (p_articuloID != Utilidades.ID_VACIO)
                        param[0] = new SqlParameter(sparam, new System.Guid(codigo));
                    else
                        param[0] = new SqlParameter(sparam, codigo);

                    SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, sp, param);

                    //Si se encontro el registro
                    if (dr.HasRows)
                    {
                        dr.Read();
                        rubro = dr["Rubro"].ToString();
                        subRubro = dr["Sub Rubro"].ToString();
                        descripcion = dr["Descripción"].ToString();
                        codigoInterno = dr["Código Interno"].ToString();
                        codigoBarras = dr["Código de Barras"].ToString();
                        articuloID = dr["id"].ToString();
                        precio = double.Parse(dr["Precio"].ToString()).ToString("N");
                        promocion = "True";
                        encontrado = true;
                    }
                    else
                    {
                        encontrado = false;
                    }
                    dr.Close();


                    if (!encontrado)
                    {
                        rubro = "No registrado.";
                        subRubro = "No registrado.";
                        descripcion = "Artículo No Registrado.";
                        if (p_articuloID != Utilidades.ID_VACIO)
                        {
                            codigoInterno = "";
                            codigoBarras = "";
                        }
                        else
                        {
                            codigoInterno = tbCodigoInternoAC.Text;
                            codigoBarras = tbCodigoBarrasAC.Text;
                        }
                        articuloID = Utilidades.ID_VACIO;
                    }

                    tbRubroAC.Text = rubro;
                    tbSubRubroAC.Text = subRubro;
                    tbDescripcionAC.Text = descripcion;
                    tbCodigoInternoAC.Text = codigoInterno;
                    tbCodigoBarrasAC.Text = codigoBarras;
                    tbID.Text = articuloID;
                    tbPrecioAC.Text = precio;
                    tbPromocionAC.Text = promocion;

                    this.Cursor = Cursors.Arrow;
                }
                return encontrado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        //Cambia el color de fondo segun tenga o pierda el foco
        private void controlarColorFondo(ref object sender, string foco)
        {
            try
            {
                Control control = (Control)sender;
                if (foco == "Enter")
                {
                    control.BackColor = Color.LightCyan;
                    control.ForeColor = Color.Black;
                }
                else
                {
                    if (control is Button)
                        control.BackColor = Color.Gainsboro;
                    else
                        control.BackColor = Color.White;

                    control.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Agrega el articulo en la lista de articulos
        private void agregarArticulo(ref Control controlFocus)
        {
            try
            {
                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", true);
                if (Utilidades.IsNumeric(tbCantidadAC.Text) &&
                    tbCantidadAC.Text.Trim() != "" &&
                    tbRubroAC.Text != "No registrado." && tbRubroAC.Text != "" &&
                    !(tbCodigoInternoAC.Text.Trim() == "" && tbCodigoBarrasAC.Text.Trim() == "" && tbID.Text.Trim() == ""))
                {
                    //Agrega un registro a la tabla de la grilla
                    DataTable tabla = (DataTable)dgSubArticulos.DataSource;
                    DataRow newRow = tabla.NewRow();
                    newRow["Código Interno"] = tbCodigoInternoAC.Text;
                    newRow["Código de Barras"] = tbCodigoBarrasAC.Text;
                    newRow["Cantidad"] = tbCantidadAC.Text;
                    newRow["Rubro"] = tbRubroAC.Text;
                    newRow["Sub Rubro"] = tbSubRubroAC.Text;
                    newRow["Descripción"] = tbDescripcionAC.Text;
                    newRow["articuloID"] = tbID.Text;
                    newRow["precio"] = double.Parse(tbPrecioAC.Text);
                    newRow["promocion"] = bool.Parse(tbPromocionAC.Text);
                    newRow["itemNro"] = tabla.Rows.Count + 1;
                    newRow["descuento"] = 0;
                    newRow["precioTotal"] = double.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
                    newRow["precioTotalConDesc"] = double.Parse(tbPrecioAC.Text) * int.Parse(tbCantidadAC.Text);
                    tabla.Rows.Add(newRow);

                    //Limpia los codigos
                    tbCodigoInternoAC.Text = "";
                    tbCodigoBarrasAC.Text = "";
                    tbRubroAC.Text = "";
                    tbSubRubroAC.Text = "";
                    tbDescripcionAC.Text = "";
                    tbID.Text = "";
                    tbPrecioAC.Text = "";
                    tbPromocionAC.Text = "";

                    //Establece el foco en la grilla y muestra el ultimo registro
                    dgSubArticulos.Select();
                    dgSubArticulos.CurrentRowIndex = ((DataTable)dgSubArticulos.DataSource).Rows.Count - 1;

                    //Establece el foco
                    if (controlFocus != null)
                        controlFocus.Select();

                    calcularSubTotales();
                }
                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "", false);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Abre el formulario de consulta en modo rapido
        private void abrirConsultaRapidaArticulos()
        {
            try
            {
                frmArticuloConsulta form = new frmArticuloConsulta(this.configuracion, true);
                form.statusBar1 = this.statusBarPrincipal;

                //Crea y asigna el Delegate
                form.objDelegateDevolverID = new Comunes.frmArticuloConsulta.DelegateDevolverID(buscarArticulo);

                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Calcula los subtotales
        private void calcularSubTotales()
        {
            try
            {
                //Subtotal 1
                decimal subTotal1 = (decimal)((DataTable)dgSubArticulos.DataSource).Compute("Sum(precioTotalConDesc)", "");
                lblSubTotal1.Text = subTotal1.ToString("C");

                //Bonificacion
                decimal bonificacionPorc = decimal.Parse(tbBonificacion.Text);
                decimal bonificacionImp = subTotal1 / 100 * bonificacionPorc;
                lblBonificacion.Text = bonificacionImp.ToString("C");

                //Subtotal 2
                decimal subTotal2 = subTotal1 - bonificacionImp;
                lblSubTotal2.Text = subTotal2.ToString("C");

                //Iva 1
                //decimal iva1Porc = configuracion.parametros
                decimal iva1Imp = 0;
                //Iva 2
                //decimal iva2Porc = configuracion.parametros
                decimal iva2Imp = 0;

                //Total general
                decimal total = subTotal2 + iva1Imp + iva2Imp;
                lblTotal.Text = total.ToString("C");
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbNotaPedidoNroDesdeB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                //Agrega los ceros a la izquiera
                string notaPedidoSuc = tbFacturaNroDesdeB.Text;
                Utilidades.agregarCerosIzquierda(ref notaPedidoSuc, 8);
                tbFacturaNroDesdeB.Text = notaPedidoSuc;

                //Pone el valor Hasta
                string notaPedidoNroDesdeB = tbFacturaNroDesdeB.Text.Trim();
                string notaPedidoNroHastaB = tbFacturaNroHastaB.Text.Trim();
                if (notaPedidoNroDesdeB != "")
                {
                    if (notaPedidoNroHastaB == "" || int.Parse(notaPedidoNroHastaB) < int.Parse(notaPedidoNroDesdeB))
                    {
                        tbFacturaSucHastaB.Text = tbFacturaSucDesdeB.Text;
                        tbFacturaNroHastaB.Text = tbFacturaNroDesdeB.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butSuspender_Click(object sender, System.EventArgs e)
        {
            try
            {
                UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Nota de Pedido...", true);
                if (validarFormularioCabecera())
                {
                    guardarNotaPedido(1);  //Estado: suspendida.

                    //Cambia al tab principal de busqueda para que otro vendedor pueda seguir trabajando con otra Nota de Pedido
                    tabPrincipal.SelectedIndex = 0;
                }
                else
                    UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Valida el Formulario antes de guardarlo
        private bool validarFormularioCabecera()
        {
            try
            {
                string mensaje = "";
                bool resultado = true;

                /*
                if (rbProveedor.Checked && tbProveedorID.Text=="")
                {
                    mensaje += "   - Debe seleccionar un Proveedor.\r\n";
                    resultado = false;
                }
                if (!Utilidades.IsNumeric(tbNroRemito1.Text) ||
                    !Utilidades.IsNumeric(tbNroRemito2.Text) ||
                    int.Parse(tbNroRemito1.Text)==0 ||
                    int.Parse(tbNroRemito2.Text)==0)
                {
                    mensaje += "   - Debe Completar el Nro. de Remito.\r\n";
                    resultado = false;
                }
                if (((DataTable)dgSubArticulos.DataSource).Rows.Count==0)
                {
                    mensaje += "   - Debe ingresar al menos un Artículo.\r\n";
                    resultado = false;
                }

                */
                if (mensaje != "")
                {
                    mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
                    MessageBox.Show(mensaje, "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        //Guarda la Nota de Pedido con el estado que se le indique.
        private void guardarNotaPedido(int estado)
        {
            try
            {
                /*
                //Primero guarda las formas de pago
                guardarFormasDePago();

                //Obtiene los valores
                string notaPedidoID = tbNotaCreditoID.Text;
                string clienteID = tbClienteID.Text;
                string nombreCliente = tbClienteNombre.Text;
                string ivaIDCliente = cbIVA.SelectedValue.ToString();
                string direccionCliente = tbDireccion.Text;
                string cuitCliente = tbCUIT.Text;
                string direccionEntrega = tbDireccionEntrega.Text;
                string vendedorID = cbVendedor.SelectedValue.ToString();
                string condicionEntregaID = cbCondicionEntrega.Text;
                condicionEntregaID = condicionEntregaID == "Inmediata" ? "1" : "2";
                double bonificacion = double.Parse(tbBonificacion.Text);
                string autorizadorBonificacionID = cbAutorizadorBonificacion.SelectedValue.ToString();
                double subTotal1 = double.Parse(lblSubTotal1.Text, NumberStyles.Currency);
                double iva1 = double.Parse(lblIva1.Text, NumberStyles.Currency);
                double iva2 = double.Parse(lblIva2.Text, NumberStyles.Currency);
                double total = double.Parse(lblTotal.Text, NumberStyles.Currency);
                string estadoNotaPedidoID = estado.ToString();
                string maquinaID = configuracion.maquina.id.ToString();
                double subTotal2 = double.Parse(lblSubTotal2.Text, NumberStyles.Currency);
                double bonificacionImporte = double.Parse(lblBonificacion.Text, NumberStyles.Currency);
                string formaPagoID = tbFormaPagoID.Text == "" ? "0" : tbFormaPagoID.Text;

                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@notaPedidoID", new System.Guid(notaPedidoID));
                param[1] = new SqlParameter("@clienteID", new System.Guid(clienteID));
                param[2] = new SqlParameter("@nombreCliente", nombreCliente);
                param[3] = new SqlParameter("@ivaIDCliente", new System.Guid(ivaIDCliente));
                param[4] = new SqlParameter("@direccionCliente", direccionCliente);
                param[5] = new SqlParameter("@cuitCliente", cuitCliente);
                param[6] = new SqlParameter("@direccionEntrega", direccionEntrega);
                param[7] = new SqlParameter("@vendedorID", new System.Guid(vendedorID));
                param[8] = new SqlParameter("@condicionEntregaID", new System.Guid(condicionEntregaID));
                param[9] = new SqlParameter("@bonificacion", bonificacion);
                param[10] = new SqlParameter("@autorizadorBonificacionID", new System.Guid(autorizadorBonificacionID));
                param[11] = new SqlParameter("@subTotal1", subTotal1);
                param[12] = new SqlParameter("@iva1", iva1);
                param[13] = new SqlParameter("@iva2", iva2);
                param[14] = new SqlParameter("@total", total);
                param[15] = new SqlParameter("@estadoNotaPedidoID", new System.Guid(estadoNotaPedidoID));
                param[16] = new SqlParameter("@maquinaID", new System.Guid(maquinaID));
                param[17] = new SqlParameter("@subTotal2", subTotal2);
                param[18] = new SqlParameter("@bonificacionImporte", bonificacionImporte);
                param[19] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));

                while (true)
                {
                    try
                    {
                        //Modifica la Nota de Pedido, la cabecera
                        SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarNotaPedido", param);


                        //Primero Borra los articulos componentes
                        param = new SqlParameter[1];
                        param[0] = new SqlParameter("@notaPedidoID", new System.Guid(tbNotaCreditoID.Text));
                        SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteNotaPedidoLinea", param);


                        //Inserta los articulos
                        string articuloID = Utilidades.ID_VACIO;
                        string cantidad = "0";
                        double descuento = 0;
                        int itemNro = 0;
                        string aplicaPromocion = "2";
                        double precioTotal = 0;
                        double precioTotalConDesc = 0;
                        double precioUnitario = 0;

                        DataTable dtSubArticulos = (DataTable)dgSubArticulos.DataSource;
                        for (int i = 0; i < dtSubArticulos.Rows.Count; i++)
                        {
                            cantidad = dtSubArticulos.Rows[i]["cantidad"].ToString();
                            if (cantidad.Trim() != "")
                            {
                                articuloID = dtSubArticulos.Rows[i]["articuloID"].ToString();
                                descuento = double.Parse(dtSubArticulos.Rows[i]["descuento"].ToString(), NumberStyles.Any);
                                itemNro = int.Parse(dtSubArticulos.Rows[i]["itemNro"].ToString());
                                aplicaPromocion = dtSubArticulos.Rows[i]["promocion"].ToString();
                                aplicaPromocion = aplicaPromocion == "True" ? "1" : "2";
                                precioTotal = double.Parse(dtSubArticulos.Rows[i]["precioTotal"].ToString());
                                precioTotalConDesc = double.Parse(dtSubArticulos.Rows[i]["precioTotalConDesc"].ToString());
                                precioUnitario = double.Parse(dtSubArticulos.Rows[i]["precio"].ToString());
                                param = new SqlParameter[9];
                                param[0] = new SqlParameter("@notaPedidoID", new System.Guid(notaPedidoID));
                                param[1] = new SqlParameter("@cantidad", cantidad);
                                param[2] = new SqlParameter("@articuloID", new System.Guid(articuloID));
                                param[3] = new SqlParameter("@descuento", descuento);
                                param[4] = new SqlParameter("@itemNro", itemNro);
                                param[5] = new SqlParameter("@aplicaPromocion", aplicaPromocion);
                                param[6] = new SqlParameter("@precioTotal", precioTotal);
                                param[7] = new SqlParameter("@precioTotalConDesc", precioTotalConDesc);
                                param[8] = new SqlParameter("@precioUnitario", precioUnitario);
                                SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertNotaPedidoLinea", param);
                            }
                        }

                        MessageBox.Show("Nota de Pedido guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Pedido guardada con éxito.", false);

                        //Limpia el formulario
                        //limpiarFormulario();

                        break;
                    }
                    catch (Exception e)
                    {
                        ManejadorErrores.escribirLog(e, true);
                        DialogResult dr = MessageBox.Show("No se pudo guardar la Nota de Pedido. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Nota de Pedido. \r\n" + e.Message, false);
                        if (dr != DialogResult.Retry)
                            break;
                    }
                }
                 * */
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butImprimirFactura_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (validarFormularioCabecera())
                {
                    //Primero guarda la Nota de Pedido
                    guardarNotaPedido(1);  //Estado 1: suspendida.

                    //Luego la imprime
                    if (imprimirNotaPedido(tbNotaCreditoID.Text))
                    {
                        /*butCrearRemitos.Enabled = true;
                        butSuspender.Enabled = false;
                        butImprimirFactura.Enabled = false;*/
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Imprime la Nota de Pedido
        private bool imprimirNotaPedido(string notaPedidoID)
        {
            return true;
        }

        private void butCancelar_Click(object sender, System.EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void butCrearRemitos_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmRemitoAlta frmRemit = new frmRemitoAlta(this.configuracion);
                frmRemit.statusBar1 = this.statusBarPrincipal;
                frmRemit.toolBar2 = null;
                frmRemit.Show();
                frmRemit.ucRemitoAlta1.buscarNotaPedido(tbNotaCreditoID.Text);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butContinuar1_Click(object sender, System.EventArgs e)
        {
            tabNotaPedido.SelectedIndex = 1;
            tbCodigoInternoAC.Select();
        }

        private void butContinuar2_Click(object sender, System.EventArgs e)
        {
            tabNotaPedido.SelectedIndex = 2;
            //cbCtadoCtaCte.Select();
        }


        private void cbTipoPago_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            llenarTipoPagoDetalle();
            habilitarAjuste();
        }

        private void cbCtadoCtaCte_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            habilitarContado();
        }

        //Habilita o no el cuadro de cotroles para el pago Contado
        private void habilitarContado()
        {
            try
            {/*
                if (cbCtadoCtaCte.SelectedIndex > -1)
                {
                    DataTable dtPlazo = (DataTable)cbCtadoCtaCte.DataSource;

                    if (dtPlazo.Rows[cbCtadoCtaCte.SelectedIndex]["identificador"].ToString() == "CONTADO")
                        gbContado.Enabled = true;
                    else
                        gbContado.Enabled = false;
                }*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Habilita las etiquetas de ajuste
        //Habilita las etiquetas de ajuste
        private void habilitarAjuste()
        {
            try
            {
                /*if (cbTipoPago.SelectedIndex > -1)
                {
                    DataTable dtTipoPago = (DataTable)cbTipoPago.DataSource;

                    if (dtTipoPago.Rows[cbTipoPago.SelectedIndex]["operacion"].ToString() == "CAMBIO")
                    {
                        lblAjusteEtiqueta.Visible = true;
                        lblAjusteValor.Visible = true;
                        lblAjusteEtiqueta.Text = "Cambio";
                        lblAjusteValor.Text = "$ 0,00";

                        lblPesos.Visible = true;
                        tbPesos.Visible = true;
                        tbPesos.Text = "$ 0,00";
                    }
                    else
                    {
                        lblAjusteEtiqueta.Visible = false;
                        lblAjusteValor.Visible = false;
                        lblAjusteEtiqueta.Text = "";
                        lblAjusteValor.Text = "$ 0,00";

                        lblPesos.Visible = false;
                        tbPesos.Visible = false;
                        tbPesos.Text = "$ 0,00";
                    }

                    //Decide que hacer dependiendo del tipo de pago
                    string identificadorTP = dtTipoPago.Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
                    switch (identificadorTP)
                    {
                        case "PESOS":
                        case "DIVISAS":
                        case "T_DEBITO":
                            {
                                lblAdicional.Visible = false;
                                tbAdicional.Text = "";
                                tbAdicional.Visible = false;
                                cbAdicional.Visible = false;
                                lblInteresPorE.Visible = false;
                                lblInteresPorV.Text = "0";
                                lblInteresPorV.Visible = false;
                                lblInteresValE.Visible = false;
                                lblInteresValV.Text = "0";
                                lblInteresValV.Visible = false;
                                lblTotalConInteresE.Visible = false;
                                lblTotalConInteresV.Text = "0";
                                lblTotalConInteresV.Visible = false;
                                calcularSubTotalesPagos();
                                break;
                            }
                        case "CHEQUES":
                            {
                                lblAdicional.Text = "Cheque Nro.";
                                lblAdicional.Visible = true;
                                tbAdicional.Text = "";
                                tbAdicional.Visible = true;
                                cbAdicional.Visible = false;
                                lblInteresPorE.Visible = false;
                                lblInteresPorV.Text = "0";
                                lblInteresPorV.Visible = false;
                                lblInteresValE.Visible = false;
                                lblInteresValV.Text = "0";
                                lblInteresValV.Visible = false;
                                lblTotalConInteresE.Visible = false;
                                lblTotalConInteresV.Text = "0";
                                lblTotalConInteresV.Visible = false;
                                calcularSubTotalesPagos();
                                break;
                            }
                        case "T_CREDITO":
                            {
                                lblAdicional.Text = "Cantidad de Pagos";
                                lblAdicional.Visible = true;
                                tbAdicional.Text = "";
                                tbAdicional.Visible = false;
                                cbAdicional.Visible = true;


                                lblInteresPorE.Visible = true;
                                //lblInteresPorV.Text = "0";
                                lblInteresPorV.Visible = true;
                                lblInteresValE.Visible = true;
                                //lblInteresValV.Text = "0";
                                lblInteresValV.Visible = true;
                                lblTotalConInteresE.Visible = true;
                                //lblTotalConInteresV.Text = "0";
                                lblTotalConInteresV.Visible = true;

                                visualizarInteres();
                                break;
                            }
                    }

                    establecerAjuste();
                }*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        //Muestra en los controles todos los datos referentes al interes aplicado
        private void visualizarInteres()
        {
            try
            {/*
                calcularSubTotalesPagos();
                if (cbAdicional.SelectedIndex > -1 && cbAdicional.Visible)
                {
                    DataTable dtCantidadPagos = (DataTable)cbAdicional.DataSource;
                    double interesPor = double.Parse(dtCantidadPagos.Rows[cbAdicional.SelectedIndex]["interes"].ToString());
                    double totalFacturado = double.Parse(lblTotalNotaCreditodo.Text, NumberStyles.Currency);

                    double interesVal = 0;
                    if (totalFacturado != 0)
                        interesVal = (totalFacturado / 100) * interesPor;
                    else
                        interesVal = 0;

                    double totalConInteres = totalFacturado + interesVal;

                    lblInteresPorV.Text = interesPor.ToString("N");
                    lblInteresValV.Text = interesVal.ToString("C");
                    lblTotalConInteresV.Text = totalConInteres.ToString("C");
                }
                calcularSubTotalesPagos();*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butAgregarPago_Click(object sender, System.EventArgs e)
        {
            if (validarPago())
                agregarPago();
        }
        //Agrega el pago a la grilla.
        private void agregarPago()
        {
            try
            {/*
                string identificadorTipoPago = ((DataTable)cbTipoPago.DataSource).Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
                string detalle = cbTipoPagoDetalle.Text;
                switch (identificadorTipoPago)
                {
                    case "CHEQUES":
                        detalle += ", Nro. " + tbAdicional.Text;
                        break;
                    case "T_CREDITO":
                        detalle += ", " + cbAdicional.Text;
                        break;
                }
                //Agrega un registro a la tabla de la grilla
                DataTable tabla = (DataTable)dgPagos.DataSource;
                DataRow newRow = tabla.NewRow();
                newRow["tipoPagoID"] = cbTipoPago.SelectedValue;
                newRow["Tipo Pago"] = cbTipoPago.Text;
                newRow["tipoPagoDetalleID"] = cbTipoPagoDetalle.SelectedValue != null ? cbTipoPagoDetalle.SelectedValue : Utilidades.ID_VACIO;
                newRow["Detalle"] = detalle;
                newRow["Importe"] = double.Parse(tbImportePago.CurrencyValue(), NumberStyles.Currency);
                newRow["Ajuste"] = double.Parse(lblAjusteValor.Text, NumberStyles.Currency);
                newRow["Pesos"] = double.Parse(tbPesos.CurrencyValue(), NumberStyles.Currency);
                newRow["Nro. Cheque"] = tbAdicional.Text;

                DataTable dtTipoPagoDetalle = ((DataTable)cbTipoPagoDetalle.DataSource);
                string bancoID = Utilidades.ID_VACIO;
                if (dtTipoPagoDetalle.Rows.Count > 0)
                    bancoID = dtTipoPagoDetalle.Rows[cbTipoPagoDetalle.SelectedIndex]["bancoID"].ToString();

                newRow["bancoID"] = bancoID;

                newRow["cantidadPagosID"] = cbAdicional.SelectedValue;

                tabla.Rows.Add(newRow);

                //Limpia el importe
                tbImportePago.Text = "$ 0,00";
                tbAdicional.Text = "";

                //Establece el foco en la grilla y muestra el ultimo registro
                dgPagos.Select();
                dgPagos.CurrentRowIndex = ((DataTable)dgPagos.DataSource).Rows.Count - 1;

                //Establece el foco
                cbTipoPago.Select();

                calcularSubTotalesPagos();*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbImportePago_Validated(object sender, System.EventArgs e)
        {
            convertirDivisa("");
        }

        //Reliza el calculo de conversion de divisa
        private void convertirDivisa(string tipoPago)
        {
            try
            {/*
                string simportePago = tbImportePago.CurrencyValue();
                double importePago = double.Parse(simportePago, NumberStyles.Currency);

                double pesos = importePago;

                string sajuste = lblAjusteValor.CurrencyValue();
                double ajuste = double.Parse(sajuste, NumberStyles.Currency);

                if (ajuste > 0)
                {
                    if (tipoPago == "DIVISAS")
                    {
                        pesos = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);
                        importePago = pesos / ajuste;
                        tbImportePago.Text = importePago.ToString("C");
                    }
                    else
                        pesos = importePago * ajuste;
                }
                else  //si ajuste==0
                {
                    if (tipoPago == "DIVISAS")
                    {
                        pesos = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);
                        importePago = pesos;
                        tbImportePago.Text = importePago.ToString("C");
                    }
                }

                tbPesos.Text = pesos.ToString("C");*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void cbTipoPagoDetalle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            establecerAjuste();
        }

        private void establecerAjuste()
        {
            try
            {/*
                DataTable dtDetalle = (DataTable)cbTipoPagoDetalle.DataSource;

                if (dtDetalle.Rows.Count > 0)
                {
                    string nombreParametro = dtDetalle.Rows[cbTipoPagoDetalle.SelectedIndex]["ajuste"].ToString();

                    double valorAjuste = 0;
                    if (nombreParametro != "")
                        valorAjuste = (double)this.configuracion.obtenerParametro(nombreParametro);

                    lblAjusteValor.Text = valorAjuste.ToString("C");

                    string tipoPago = ((DataTable)cbTipoPago.DataSource).Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
                    convertirDivisa(tipoPago);
                }*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbImportePago_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                if (validarPago())
                    agregarPago();
        }


        private void tabNotaPedido_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //si el es tab de formas de pago, calcula los subtotales
            if (tabNotaPedido.SelectedIndex == 2)
                calcularSubTotalesPagos();
        }

        private void butBorrarPagos_Click(object sender, System.EventArgs e)
        {
            borrarRegistrosPagos();
        }

        private void borrarRegistrosPagos()
        {
            try
            {/*
                if (dgPagos.DataSource != null)
                {
                    DataTable dt = (DataTable)dgPagos.DataSource;

                    if (dt.Rows.Count > 0)
                    {
                        //Primero recorre los renglones seleccionados
                        string sRows = "";
                        string coma = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dgPagos.IsSelected(i))
                            {
                                sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
                                coma = ",";
                            }
                        }

                        if (sRows != "")
                        {
                            DialogResult dr = MessageBox.Show("¿Desea borrar los Pagos seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Pagos...", true);
                                string[] rows = sRows.Split(",".ToCharArray());
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    string id = rows[j].Split(":".ToCharArray())[0];
                                    int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

                                    //dt.Rows[renglon].Delete();
                                    dt.Rows[renglon]["id"] = "-1";
                                }
                                //Recorre los renglones marcados para borrar
                                DataRow[] rowsBorrar = dt.Select("id='-1'");
                                for (int k = 0; k < rowsBorrar.Length; k++)
                                {
                                    rowsBorrar[k].Delete();
                                }
                                dt.AcceptChanges();

                                //Renumera los items
                                renumerarItemsPagos();

                                dgPagos.Refresh();

                                visualizarInteres();
                                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
                            }
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Renumera los items de la Tabla
        private void renumerarItemsPagos()
        {
            /*DataTable dt = (DataTable)dgPagos.DataSource;

            for (int i=0; i<dt.Rows.Count; i++)
            {
                dt.Rows[i]["itemNro"] = i + 1;
            }*/
        }

        private void cbAdicional_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            visualizarInteres();
        }


        private void tbImportePago_Enter(object sender, System.EventArgs e)
        {
            //tbImportePago.SelectAll();
        }

        //Carga las Formas de Pago
        private void cargarFormasPago(string formaPagoID)
        {
            try
            {/*
                SqlParameter[] paramFP = new SqlParameter[1];
                paramFP[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                SqlDataReader drFormaPago = SqlHelper.ExecuteReader(this.conexion, "sp_getFormaPago", paramFP);

                if (drFormaPago.HasRows)
                {
                    drFormaPago.Read();

                    tbFormaPagoID.Text = drFormaPago["id"].ToString();

                    cbCtadoCtaCte.SelectedValue = drFormaPago["plazoPagoID"].ToString();


                    //Total Pagos
                    double totalPagos = double.Parse(drFormaPago["totalPagos"].ToString());
                    lblTotalPagos.Text = totalPagos.ToString("C");

                    //Total Facturado
                    double totalFacturado = double.Parse(drFormaPago["totalFacturado"].ToString());
                    lblTotalNotaCreditodo.Text = totalFacturado.ToString("C");

                    //Interes
                    double interesVal = double.Parse(drFormaPago["interesVal"].ToString());
                    lblInteresValV.Text = interesVal.ToString("C");

                    //Total con interes
                    double totalConInteres = double.Parse(drFormaPago["totalConInteres"].ToString());
                    lblTotalConInteresV.Text = totalConInteres.ToString("C");

                    //Interes Por
                    double interesPor = double.Parse(drFormaPago["interesPor"].ToString());
                    lblInteresPorV.Text = interesPor.ToString("N");

                    //Saldo
                    double saldo = double.Parse(drFormaPago["saldo"].ToString());
                    lblSaldoPagos.Text = saldo.ToString("N");

                    /********************************
                    * Carga los items en la grilla
                    * ****************************** /
                    //Borra los registros de la grilla de Pagos
                    DataTable tabla = (DataTable)dgPagos.DataSource;
                    tabla.Rows.Clear();
                    //Carga los articulos componentes
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@formaPagoID", new System.Guid(tbFormaPagoID.Text));
                    SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllFormaPagoLineas", param);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DataRow newRow = tabla.NewRow();
                            newRow["tipoPagoID"] = dr["tipoPagoID"].ToString();
                            newRow["tipoPagoDetalleID"] = dr["tipoPagoDetalleID"].ToString();
                            newRow["importe"] = double.Parse(dr["importe"].ToString());
                            newRow["ajuste"] = double.Parse(dr["ajuste"].ToString());
                            newRow["pesos"] = double.Parse(dr["pesos"].ToString());
                            newRow["Tipo Pago"] = dr["Tipo Pago"].ToString();
                            newRow["identificador"] = dr["identificador"].ToString();
                            newRow["operacion"] = dr["operacion"].ToString();
                            newRow["Detalle"] = dr["Detalle"].ToString();
                            newRow["Nro. Cheque"] = dr["Nro. Cheque"].ToString();
                            newRow["bancoID"] = dr["bancoID"].ToString();
                            newRow["cantidadPagosID"] = dr["cantidadPagosID"].ToString();
                            newRow["ID"] = "";

                            tabla.Rows.Add(newRow);
                        }
                    }
                    dr.Close();
                }
                else
                {
                    limpiarFormularioFormasPago();
                    calcularSubTotalesPagos();
                }*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Llena el combo TipoPagoDetalle
        private void llenarTipoPagoDetalle()
        {
            try
            {/*
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@tipoPagoID", new System.Guid(cbTipoPago.SelectedValue.ToString()));
                UtilUI.llenarCombo(ref cbTipoPagoDetalle, this.conexion, "sp_getAlltv_TipoPagoDetalle", "", -1, param);
                if (cbTipoPagoDetalle.Items.Count > 0)
                    cbTipoPagoDetalle.SelectedIndex = 0;*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Calcula los subtotales para los Pagos
        private void calcularSubTotalesPagos()
        {
            try
            {/*
                decimal totalPagos = 0;
                if (((DataTable)dgPagos.DataSource).Rows.Count > 0)
                {
                    //Total Pagos
                    totalPagos = (decimal)((DataTable)dgPagos.DataSource).Compute("Sum(Pesos)", "");
                }

                lblTotalPagos.Text = totalPagos.ToString("C");

                //Total Facturado
                decimal totalFacturado = decimal.Parse(lblTotal.Text, NumberStyles.Currency);
                lblTotalNotaCreditodo.Text = totalFacturado.ToString("C");

                //Total con Interes
                decimal totalConInteres = decimal.Parse(lblTotalConInteresV.Text, NumberStyles.Currency);
                if (totalConInteres == 0)
                    totalConInteres = totalFacturado;

                //Saldo
                decimal saldoPagos = totalConInteres - totalPagos;
                lblSaldoPagos.Text = saldoPagos.ToString("C");

                //Pone en el importe el saldo
                tbImportePago.Text = lblSaldoPagos.Text;

                string tipoPago = ((DataTable)cbTipoPago.DataSource).Rows[cbTipoPago.SelectedIndex]["identificador"].ToString();
                convertirDivisa(tipoPago);*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private bool validarPago()
        {
            try
            {/*
                string mensaje = "";
                bool resultado = true;

                string simportePago = tbImportePago.CurrencyValue().Replace(".", "");
                double importePago = double.Parse(simportePago);
                if (importePago <= 0)
                {
                    mensaje += "   - El Importe debe ser mayor que 0.\r\n";
                    resultado = false;
                }

                if (mensaje != "")
                {
                    mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
                    MessageBox.Show(mensaje, "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return resultado;*/
                return true;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        //Guarda las Formas de Pago.
        private void guardarFormasDePago()
        {
            try
            {/*
                if (tbFormaPagoID.Text != "" && tbFormaPagoID.Text != Utilidades.ID_VACIO)
                {
                    //Obtiene los valores
                    string formaPagoID = tbFormaPagoID.Text;
                    string plazoPagoID = cbCtadoCtaCte.SelectedValue.ToString();
                    double totalPagos = double.Parse(lblTotalPagos.Text, NumberStyles.Currency);
                    double totalFacturado = double.Parse(lblTotalNotaCreditodo.Text, NumberStyles.Currency);
                    double interesPor = double.Parse(lblInteresPorV.Text, NumberStyles.Currency);
                    double interesVal = double.Parse(lblInteresValV.Text, NumberStyles.Currency);
                    double totalConInteres = double.Parse(lblTotalConInteresV.Text, NumberStyles.Currency);
                    double saldo = double.Parse(lblSaldoPagos.Text, NumberStyles.Currency);

                    SqlParameter[] param = new SqlParameter[8];

                    param[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                    param[1] = new SqlParameter("@plazoPagoID", new System.Guid(plazoPagoID));
                    param[2] = new SqlParameter("@totalPagos", totalPagos);
                    param[3] = new SqlParameter("@totalFacturado", totalFacturado);
                    param[4] = new SqlParameter("@interesPor", interesPor);
                    param[5] = new SqlParameter("@interesVal", interesVal);
                    param[6] = new SqlParameter("@totalConInteres", totalConInteres);
                    param[7] = new SqlParameter("@saldo", saldo);

                    while (true)
                    {
                        try
                        {
                            //Inserta el registro y obtiene el ID
                            SqlHelper.ExecuteNonQuery(this.conexion, "sp_ModificarFormaPago", param);

                            //Primero Borra los items de la forma de pago
                            param = new SqlParameter[1];
                            param[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                            SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteFormaPagoLinea", param);

                            //Inserta los items
                            string tipoPagoID = Utilidades.ID_VACIO;
                            string tipoPagoDetalleID = Utilidades.ID_VACIO;
                            double importe = 0;
                            double ajuste = 0;
                            double pesos = 0;
                            string nroCheque = "";
                            string bancoID = Utilidades.ID_VACIO;
                            string cantidadPagosID = Utilidades.ID_VACIO;

                            DataTable dtPagos = (DataTable)dgPagos.DataSource;
                            for (int i = 0; i < dtPagos.Rows.Count; i++)
                            {
                                tipoPagoID = dtPagos.Rows[i]["tipoPagoID"].ToString();
                                tipoPagoDetalleID = dtPagos.Rows[i]["tipoPagoDetalleID"].ToString();
                                importe = double.Parse(dtPagos.Rows[i]["importe"].ToString());
                                ajuste = double.Parse(dtPagos.Rows[i]["ajuste"].ToString());
                                pesos = double.Parse(dtPagos.Rows[i]["pesos"].ToString());
                                nroCheque = dtPagos.Rows[i]["Nro. Cheque"].ToString();
                                bancoID = dtPagos.Rows[i]["bancoID"].ToString();
                                cantidadPagosID = dtPagos.Rows[i]["cantidadPagosID"].ToString();

                                param = new SqlParameter[9];
                                param[0] = new SqlParameter("@formaPagoID", new System.Guid(formaPagoID));
                                param[1] = new SqlParameter("@tipoPagoID", new System.Guid(tipoPagoID));
                                param[2] = new SqlParameter("@tipoPagoDetalleID", new System.Guid(tipoPagoDetalleID));
                                param[3] = new SqlParameter("@importe", importe);
                                param[4] = new SqlParameter("@ajuste", ajuste);
                                param[5] = new SqlParameter("@pesos", pesos);
                                param[6] = new SqlParameter("@nroCheque", nroCheque);
                                param[7] = new SqlParameter("@bancoID", new System.Guid(bancoID));
                                param[8] = new SqlParameter("@cantidadPagosID", new System.Guid(cantidadPagosID));
                                SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertFormaPagoLinea", param);
                            }

                            //MessageBox.Show("Nota de Pedido guardada con éxito.", "Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Nota de Pedido guardada con éxito.", false);

                            //Limpia el formulario
                            //limpiarFormulario();

                            break;
                        }
                        catch (Exception e)
                        {
                            ManejadorErrores.escribirLog(e, true);
                            DialogResult dr = MessageBox.Show("No se pudo guardar la Forma de Pago. \r\n" + e.Message, "Guardar", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                            UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "No se pudo guardar la Forma de Pago. \r\n" + e.Message, false);
                            if (dr != DialogResult.Retry)
                                break;
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbFacturaSucDesdeB_Validated(object sender, System.EventArgs e)
        {
            string facturaSuc = tbFacturaSucDesdeB.Text;
            Utilidades.agregarCerosIzquierda(ref facturaSuc, 4);
            tbFacturaSucDesdeB.Text = facturaSuc;
        }

        private void tbFacturaSucHastaB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                string facturaSuc = tbFacturaSucHastaB.Text;
                Utilidades.agregarCerosIzquierda(ref facturaSuc, 4);
                tbFacturaSucHastaB.Text = facturaSuc;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbFacturaNroDesdeB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                //Agrega los ceros a la izquiera
                string facturaSuc = tbFacturaNroDesdeB.Text;
                Utilidades.agregarCerosIzquierda(ref facturaSuc, 8);
                tbFacturaNroDesdeB.Text = facturaSuc;

                //Pone el valor Hasta
                string facturaNroDesdeB = tbFacturaNroDesdeB.Text.Trim();
                string facturaNroHastaB = tbFacturaNroHastaB.Text.Trim();
                if (facturaNroDesdeB != "")
                {
                    if (facturaNroHastaB == "" || int.Parse(facturaNroHastaB) < int.Parse(facturaNroDesdeB))
                    {
                        tbFacturaSucHastaB.Text = tbFacturaSucDesdeB.Text;
                        tbFacturaNroHastaB.Text = tbFacturaNroDesdeB.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbNotaCreditoSucDesdeB_Validated(object sender, System.EventArgs e)
        {
            string notaCreditoSuc = tbNotaCreditoSucDesdeB.Text;
            Utilidades.agregarCerosIzquierda(ref notaCreditoSuc, 4);
            tbNotaCreditoSucDesdeB.Text = notaCreditoSuc;
        }

        private void tbNotaCreditoSucHastaB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                string notaCreditoSuc = tbNotaCreditoSucHastaB.Text;
                Utilidades.agregarCerosIzquierda(ref notaCreditoSuc, 4);
                tbNotaCreditoSucHastaB.Text = notaCreditoSuc;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbNotaCreditoNroDesdeB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                //Agrega los ceros a la izquiera
                string notaCreditoSuc = tbNotaCreditoNroDesdeB.Text;
                Utilidades.agregarCerosIzquierda(ref notaCreditoSuc, 8);
                tbNotaCreditoNroDesdeB.Text = notaCreditoSuc;

                //Pone el valor Hasta
                string notaCreditoNroDesdeB = tbNotaCreditoNroDesdeB.Text.Trim();
                string notaCreditoNroHastaB = tbNotaCreditoNroHastaB.Text.Trim();
                if (notaCreditoNroDesdeB != "")
                {
                    if (notaCreditoNroHastaB == "" || int.Parse(notaCreditoNroHastaB) < int.Parse(notaCreditoNroDesdeB))
                    {
                        tbNotaCreditoSucHastaB.Text = tbNotaCreditoSucDesdeB.Text;
                        tbNotaCreditoNroHastaB.Text = tbNotaCreditoNroDesdeB.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void campoEntero_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)sender;
                string valor = tb.Text.Trim().Replace(",", "").Replace(".", "");
                if (valor != "")
                {
                    if (!Utilidades.IsNumeric(valor))
                    {
                        e.Cancel = true;
                        MessageBox.Show("El valor del campo debe contener un número entero.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                tb.Text = valor;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbFacturaNroHastaB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                //Agrega ceros a la izquierda
                string facturaNro = tbFacturaNroHastaB.Text;
                Utilidades.agregarCerosIzquierda(ref facturaNro, 8);
                tbFacturaNroHastaB.Text = facturaNro;

                //Establece el valor desde
                string facturaNroDesdeB = tbFacturaNroDesdeB.Text.Trim();
                string facturaNroHastaB = tbFacturaNroHastaB.Text.Trim();
                if (facturaNroHastaB != "")
                {
                    if (facturaNroDesdeB == "" || int.Parse(facturaNroDesdeB) > int.Parse(facturaNroHastaB))
                        tbFacturaNroDesdeB.Text = tbFacturaNroHastaB.Text;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbNotaCreditoNroHastaB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                //Agrega ceros a la izquierda
                string notaCreditoNro = tbNotaCreditoNroHastaB.Text;
                Utilidades.agregarCerosIzquierda(ref notaCreditoNro, 8);
                tbNotaCreditoNroHastaB.Text = notaCreditoNro;

                //Establece el valor desde
                string notaCreditoNroDesdeB = tbNotaCreditoNroDesdeB.Text.Trim();
                string notaCreditoNroHastaB = tbNotaCreditoNroHastaB.Text.Trim();
                if (notaCreditoNroHastaB != "")
                {
                    if (notaCreditoNroDesdeB == "" || int.Parse(notaCreditoNroDesdeB) > int.Parse(notaCreditoNroHastaB))
                        tbNotaCreditoNroDesdeB.Text = tbNotaCreditoNroHastaB.Text;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        private void dtpFechaEmisionHasta_ValueChanged(object sender, System.EventArgs e)
        {
            if (dtpFechaEmisionDesde.Value > dtpFechaEmisionHasta.Value)
                dtpFechaEmisionDesde.Value = dtpFechaEmisionHasta.Value;
        }

        private void dtpFechaEmisionDesde_ValueChanged(object sender, System.EventArgs e)
        {
            if (dtpFechaEmisionHasta.Value < dtpFechaEmisionDesde.Value)
                dtpFechaEmisionHasta.Value = dtpFechaEmisionDesde.Value;
        }

        private void chkFechaEmision_CheckedChanged(object sender, System.EventArgs e)
        {
            dtpFechaEmisionDesde.Enabled = chkFechaEmision.Checked;
            dtpFechaEmisionHasta.Enabled = chkFechaEmision.Checked;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                tbFacturaNroDesdeB.Text = "";
                tbFacturaNroHastaB.Text = "";
                cbVendedorB.SelectedIndex = 0;
                tbEjercicioNroB.Text = "";
                cbCondicionEntregaB.SelectedIndex = 0;
                cbEstadoB.SelectedIndex = 0;
                cbEstadoCtaCteB.SelectedIndex = 0;
                cbSucursalB.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Metodo que permite indicar que el control es de tipo Factura con Descuento
        public void configurarFacturaConDescuento()
        {
            try
            {
                //Establece la propiedad FacturaDescuento
                //this.facturaDescuento = true;

                //Obtiene el nro. de ejercicio
                SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getJornadaVentaAbierta");
                dr.Read();
                //tbEjercicioNroB.Text = dr["id"].ToString();
                tbEjercicioNroB.Text = dr["Nro."].ToString();
                cbBonificacionB.Text = "Con Bonif.";

                //Cambia el Titulo de la grilla
                dgItems.CaptionText = "     Facturas con Descuento";

                //Ejecuta la busqueda
                ejecutarBusqueda();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Configura el formulario para buscar facturas desde un recibo.
        public void configurarParaRecibo()
        {
            try
            {
                //Cambia el Titulo de la grilla
                dgItems.CaptionText = "     Facturas Pendientes";

                //Configura el filtro
                /*tabFiltro.SelectedIndex = 2; //Selecciona el tab Cuenta Corriente
                UtilUI.comboSeleccionarItemByIdentificador("CUENTA_CORRIENTE", ref cbPlazoPagoB);
                UtilUI.comboSeleccionarItemByIdentificador("PENDIENTE_DE_PAGO", ref cbEstadoNotaCreditoCtaCteB);
                tbClienteIDB.Text = this.clienteID;*/

                //Ejecuta la busqueda
                ejecutarBusqueda();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        //Configura el formulario para buscar facturas desde una nota de credito.
        public void configurarParaNotaCredito()
        {
            try
            {
                //Cambia el Titulo de la grilla
                dgItems.CaptionText = "     Facturas Impresas";

                //Configura el filtro
                tabFiltro.SelectedIndex = 0; //Selecciona el tab Filtro Avanzado
                UtilUI.comboSeleccionarItemByIdentificador("IMPRESA", ref cbEstadoB);

                //Ejecuta la busqueda
                ejecutarBusqueda();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butLimpiar4_Click(object sender, System.EventArgs e)
        {
            //cbPlazoPagoB.SelectedIndex = 0;
            //cbEstadoNotaCreditoCtaCteB.SelectedIndex = 0;
        }

        private void butSalir4_Click(object sender, System.EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        /*private void cbPlazoPagoB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                DataTable dtPlazo = (DataTable)cbPlazoPagoB.DataSource;
                if (dtPlazo.Rows[cbPlazoPagoB.SelectedIndex]["identificador"].ToString() == "CUENTA_CORRIENTE")
                    gbCuentaCorrienteB.Enabled = true;
                else
                    gbCuentaCorrienteB.Enabled = false;

                dtPlazo = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }*/

        private void tbNotaPedidoSucDesdeB_Validated(object sender, System.EventArgs e)
        {
            string notaPedidoSuc = tbFacturaSucDesdeB.Text;
            Utilidades.agregarCerosIzquierda(ref notaPedidoSuc, 4);
            tbFacturaSucDesdeB.Text = notaPedidoSuc;
        }

        private void tbNotaPedidoSucHastaB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                string notaPedidoSuc = tbFacturaSucHastaB.Text;
                Utilidades.agregarCerosIzquierda(ref notaPedidoSuc, 4);
                tbFacturaSucHastaB.Text = notaPedidoSuc;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbNotaPedidoNroHastaB_Validated(object sender, System.EventArgs e)
        {
            try
            {
                //Agrega ceros a la izquierda
                string notaPedidoNro = tbFacturaNroHastaB.Text;
                Utilidades.agregarCerosIzquierda(ref notaPedidoNro, 8);
                tbFacturaNroHastaB.Text = notaPedidoNro;

                //Establece el valor desde
                string notaPedidoNroDesdeB = tbFacturaNroDesdeB.Text.Trim();
                string notaPedidoNroHastaB = tbFacturaNroHastaB.Text.Trim();
                if (notaPedidoNroHastaB != "")
                {
                    if (notaPedidoNroDesdeB == "" || int.Parse(notaPedidoNroDesdeB) > int.Parse(notaPedidoNroHastaB))
                        tbFacturaNroDesdeB.Text = tbFacturaNroHastaB.Text;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butVistaPrevia_Click(object sender, System.EventArgs e)
        {
            try
            {

                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Preparando Reporte...", true);
                crListadoFacturas doc = new crListadoFacturas();

                doc.SetDataSource(((DataTable)dgItems.DataSource));

                doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

                string cadenaFiltro = ""; //obtenerCadenaFiltro();
                string cadenaOrden = ""; //obtenerCadenaOrden();
                if (cadenaFiltro != "")
                    doc.DataDefinition.FormulaFields["txtFiltroF"].Text = "\"" + cadenaFiltro + "\"";
                else
                    doc.Section1.ReportObjects["txtFiltroTitulo"].ObjectFormat.EnableSuppress = true;

                if (cadenaOrden != "")
                    doc.DataDefinition.FormulaFields["txtOrdenF"].Text = "\"" + cadenaOrden + "\"";
                else
                    doc.Section7.ReportObjects["txtOrdenTitulo"].ObjectFormat.EnableSuppress = true;

                frmPreview fp = new frmPreview();
                fp.Text = "Vista Previa: " + dgItems.CaptionText;
                fp.crystalReportViewer1.ReportSource = doc;
                fp.Show();
                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Reporte Listo.", false);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butImprimir_Click(object sender, System.EventArgs e)
        {
            try
            {

                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Preparando Reporte...", true);
                crListadoFacturas doc = new crListadoFacturas();

                doc.SetDataSource(((DataTable)dgItems.DataSource));

                doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

                string cadenaFiltro = ""; //obtenerCadenaFiltro();
                string cadenaOrden = ""; //obtenerCadenaOrden();
                if (cadenaFiltro != "")
                    doc.DataDefinition.FormulaFields["txtFiltroF"].Text = "\"" + cadenaFiltro + "\"";
                else
                    doc.Section1.ReportObjects["txtFiltroTitulo"].ObjectFormat.EnableSuppress = true;

                if (cadenaOrden != "")
                    doc.DataDefinition.FormulaFields["txtOrdenF"].Text = "\"" + cadenaOrden + "\"";
                else
                    doc.Section7.ReportObjects["txtOrdenTitulo"].ObjectFormat.EnableSuppress = true;

                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Reporte Listo.", false);

                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                printDialog1.Document = pd;

                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    int desde = 0, hasta = 0;
                    if (printDialog1.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages)
                    {
                        desde = 1;
                        hasta = 10000;
                    }
                    else
                    {
                        desde = printDialog1.PrinterSettings.FromPage;
                        hasta = printDialog1.PrinterSettings.ToPage;
                    }
                    int copias = printDialog1.PrinterSettings.Copies;
                    doc.PrintToPrinter(copias, printDialog1.PrinterSettings.Collate, desde, hasta);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butGuardarEstadoFactura_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cambiar los Estados de esta Nota de Crédito?", "Guardar cambios de Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@notaCreditoID", new Guid(tbNotaCreditoID.Text));
                    param[1] = new SqlParameter("@estadoNotaCredito", UtilUI.obtenerIdentificadorCombo(ref cbEstado));
                    param[2] = new SqlParameter("@estadoCtaCte", UtilUI.obtenerIdentificadorCombo(ref cbEstadoCtaCte));

                    SqlHelper.ExecuteNonQuery(this.conexion, "sp_CambiarEstadoNotaCredito", param);
                }
                catch (Exception ex)
                {
                    ManejadorErrores.escribirLog(ex, true, this.configuracion);
                }
            }
        }

        private void dgItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                e.Handled = true;
        }

    }
}
