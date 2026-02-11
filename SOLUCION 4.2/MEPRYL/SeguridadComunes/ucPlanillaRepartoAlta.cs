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
using System.Collections;

namespace Comunes
{
    public partial class ucPlanillaRepartoAlta : UserControl
    {

        public StatusBar statusBarPrincipal; 
        public Form formContenedor;
        public string conexion = "";
        public Configuracion m_configuracion;
        public bool consultaRapida = false;
        public NavegadorFormulario navegador;
        public DataSet dataset = (DataSet)new dsPlanillaReparto();
        public string[,] planillaRepartoLineas;

        public ucPlanillaRepartoAlta()
        {
            InitializeComponent();

            navegador = new NavegadorFormulario(this.configuracion);
        }

        private void campoEntero_Validating(object sender, CancelEventArgs e)
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

        //Llena los comboBox y demas inicializaciones
        public void inicializarComponentes()
        {
            try
            {
                
                //Carga el Navegador de formularios
                cargarNavegadorFormulario();

                //Asigna la tabla a la datagrid
                DataTable dt = (DataTable)dataset.Tables["v_PlanillaRepartoLinea"];
                DataColumn[] dca = new DataColumn[1];
                dca[0] = dt.Columns["codigo"];
                dt.PrimaryKey = dca;
                dgSubArticulos.DataSource = dt;

                ArrayList array = new ArrayList();
                array.Add(new ItemRemito("", ""));
                cbRemitosCargados.DataSource = array;
                cbRemitosCargados.ValueMember = "remitoID";
                cbRemitosCargados.DisplayMember = "descripcion";

                dtpFecha.Select();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbRemitoSucDesdeB_Validated(object sender, EventArgs e)
        {
            string remitoSuc = tbRemitoSucDesdeB.Text;
            Utilidades.agregarCerosIzquierda(ref remitoSuc, 4);
            tbRemitoSucDesdeB.Text = remitoSuc;
        }

        private void tbRemitoNroDesdeB_Validated(object sender, EventArgs e)
        {
            try
            {
                //Agrega los ceros a la izquiera
                string remitoSuc = tbRemitoNroDesdeB.Text;
                Utilidades.agregarCerosIzquierda(ref remitoSuc, 8);
                tbRemitoNroDesdeB.Text = remitoSuc;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbRemitoSucDesdeB_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            tb.SelectAll();
        }

        private void tbRemitoNroDesdeB_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            tb.SelectAll();
        }

        //Carga el Navegador de Formularios
        private void cargarNavegadorFormulario()
        {
            /*************************************
             * Navegador de la Solapa Cabecera
             * ***********************************/
            //Carga las teclas rapidas primero
            /*navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscarCliente, 0, (char)Keys.F1));
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butConsumidorFinal, 1, (char)Keys.F2));
            navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butSiguiente, 2, (char)Keys.F3));*/

            //Carga los controles
            navegador.agregarControl(new CapsulaControl((Control)dtpFecha, 0));
            navegador.agregarControl(new CapsulaControl((Control)tbTransporteNombre, 1));
            navegador.agregarControl(new CapsulaControl((Control)tbRemitoSucDesdeB, 2));
            navegador.agregarControl(new CapsulaControl((Control)tbRemitoNroDesdeB, 3));
            navegador.agregarControl(new CapsulaControl((Control)butAgregar, 4));
            

            //Agrega los handlers para todos los controles del control contenedor
            navegador.agregarHandlersContenedor(tabControl1.TabPages[0]);

        }

        private void butAgregar_Click(object sender, EventArgs e)
        {
            if (tbRemitoID.Text == Utilidades.ID_VACIO)
            {
            }
            else
            {
                agregarRemito();
                tbRemitoSucDesdeB.Text = "";
                tbRemitoNroDesdeB.Text = "";
                tbRemitoID.Text = Utilidades.ID_VACIO;
                lbDestinatario.Text = "";
                lbDireccion.Text = "";
                lbObsequiante.Text = "";
            }

            tbRemitoSucDesdeB.Select();
        }

        private void tbRemitoNroDesdeB_Leave(object sender, EventArgs e)
        {
            try
            {
                buscar();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private bool buscar()
        {
            try
            {
                bool encontrado = false;

                string destinatario = "", direccion = "", obsequiante = "", remitoID = Utilidades.ID_VACIO;
                
                this.Cursor = Cursors.WaitCursor;

                SqlParameter[] param = new SqlParameter[2];
                
                //Completa los ceros
                string cadena;
                if (tbRemitoSucDesdeB.Text.Length<4)
                {
                    cadena = tbRemitoSucDesdeB.Text;
                    Utilidades.agregarCerosIzquierda(ref cadena, 4);
                    tbRemitoSucDesdeB.Text = cadena;
                }
                if (tbRemitoNroDesdeB.Text.Length < 8)
                {
                    cadena = tbRemitoNroDesdeB.Text;
                    Utilidades.agregarCerosIzquierda(ref cadena, 8);
                    tbRemitoNroDesdeB.Text = cadena;
                }
                param[0] = new SqlParameter("@remitoSuc", tbRemitoSucDesdeB.Text);
                param[1] = new SqlParameter("@remitoNro", tbRemitoNroDesdeB.Text);

                DataSet ds = SqlHelper.ExecuteDataset(this.conexion, "sp_getAllRemitoLineasPlanilla", param);

                //Si se encontro el registro
                if (ds.Tables[0].Rows.Count>0)
                {
                    planillaRepartoLineas = new string[ds.Tables[0].Rows.Count,3];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //Carga la cabecera
                        if (!encontrado)
                        {
                            destinatario = ds.Tables[0].Rows[i]["destinatarioNombre"].ToString();
                            direccion = ds.Tables[0].Rows[i]["destinatarioDireccion"].ToString();
                            obsequiante = ds.Tables[0].Rows[i]["obsequiante"].ToString();
                            remitoID = ds.Tables[0].Rows[i]["remitoID"].ToString();

                            encontrado = true;
                        }

                        //Carga las lineas
                        planillaRepartoLineas[i, 0] = ds.Tables[0].Rows[i]["codigoInterno"].ToString();
                        planillaRepartoLineas[i, 1] = ds.Tables[0].Rows[i]["cantidad"].ToString();
                        planillaRepartoLineas[i, 2] = ds.Tables[0].Rows[i]["descripcion"].ToString();

                        Application.DoEvents();
                    }
                }
                else
                {
                    encontrado = false;
                }
                ds.Dispose();


                if (!encontrado)
                {
                    destinatario = "No registrado.";
                    direccion = "No registrado.";
                    obsequiante = "No registrado.";
                    remitoID = Utilidades.ID_VACIO;
                }

                lbDestinatario.Text = destinatario;
                lbDireccion.Text = direccion;
                lbObsequiante.Text = obsequiante;
                tbRemitoID.Text = remitoID;
                
                this.Cursor = Cursors.Arrow;
                return encontrado;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                return false;
            }
        }

        private void agregarRemito()
        {
            try
            {
                
                this.Cursor = Cursors.WaitCursor;

                //Actualiza el Combo
                string descripcion = tbRemitoSucDesdeB.Text + "-" + tbRemitoNroDesdeB.Text + ", " + lbDestinatario.Text + ", " + lbDireccion.Text;

                ArrayList array = (ArrayList)cbRemitosCargados.DataSource;
                int index = array.Add(new ItemRemito(tbRemitoID.Text, descripcion));
                cbRemitosCargados.DataSource = null;
                cbRemitosCargados.DataSource = array;
                cbRemitosCargados.ValueMember = "remitoID";
                cbRemitosCargados.DisplayMember = "descripcion";
                cbRemitosCargados.SelectedIndex = index;

                lbRemitosCargados.Text = "Remitos cargados (" + ((int)(cbRemitosCargados.Items.Count - 1)).ToString() + ")";

                
                //Actualiza la lista
                sumarLista();

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void sumarLista()
        {
            try
            {
                DataTable dt = (DataTable)dgSubArticulos.DataSource;
                //Recorre el array con los items del remito
                for (int i = 0; i < planillaRepartoLineas.GetLength(0); i++)
                {
                    //Busca en la lista
                    DataRow row = dt.Rows.Find(planillaRepartoLineas[i, 0]);
                    bool encontrado;
                    if (row == null)
                    {
                        encontrado = false;
                        row = dt.NewRow();
                        row["codigo"] = planillaRepartoLineas[i, 0];
                        row["cantidad"] = int.Parse(planillaRepartoLineas[i, 1]);
                    }
                    else 
                    {
                        encontrado = true;
                        row["cantidad"] = int.Parse(row["cantidad"].ToString()) + int.Parse(planillaRepartoLineas[i, 1]);
                    }
                    
                    row["descripcion"] = planillaRepartoLineas[i, 2];
                    string nRemito;
                    nRemito = " " + int.Parse(tbRemitoSucDesdeB.Text).ToString() + "-" + int.Parse(tbRemitoNroDesdeB.Text).ToString() + ",";
                    row["remitosDescripcion"] = row["remitosDescripcion"].ToString() + nRemito;

                    if (encontrado)
                        dt.AcceptChanges();
                    else
                        dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        private void restarLista() //Hay que cargar los items del remito desde la base de datos antes de borrarlo.
        {
            try
            {
                //Obtiene el remito
                string remitoSuc, remitoNro, remitoSuc0, remitoNro0;
                remitoSuc = int.Parse(cbRemitosCargados.Text.Substring(0, 4)).ToString();
                remitoNro = int.Parse(cbRemitosCargados.Text.Substring(5, 8)).ToString();
                
                remitoSuc0 = remitoSuc;
                remitoNro0 = remitoNro;
                Utilidades.agregarCerosIzquierda(ref remitoSuc0, 4);
                Utilidades.agregarCerosIzquierda(ref remitoNro0, 8);

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@remitoSuc", remitoSuc0);
                param[1] = new SqlParameter("@remitoNro", remitoNro0);

                DataSet ds = SqlHelper.ExecuteDataset(this.conexion, "sp_getAllRemitoLineasPlanilla", param);

                //Si se encontro el registro
                if (ds.Tables[0].Rows.Count > 0)
                {
                    planillaRepartoLineas = new string[ds.Tables[0].Rows.Count, 3];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //Carga las lineas
                        planillaRepartoLineas[i, 0] = ds.Tables[0].Rows[i]["codigoInterno"].ToString();
                        planillaRepartoLineas[i, 1] = ds.Tables[0].Rows[i]["cantidad"].ToString();
                        planillaRepartoLineas[i, 2] = ds.Tables[0].Rows[i]["descripcion"].ToString();

                        Application.DoEvents();
                    }
                }
                ds.Dispose();

                DataTable dt = (DataTable)dgSubArticulos.DataSource;
                //Recorre el array con los items del remito
                for (int i = 0; i < planillaRepartoLineas.GetLength(0); i++)
                {
                    //Busca en la lista
                    DataRow row = dt.Rows.Find(planillaRepartoLineas[i, 0]);
                    string nRemito = "";
                    int cantidad = 0;
                    if (row != null)
                    {
                        cantidad = int.Parse(row["cantidad"].ToString()) - int.Parse(planillaRepartoLineas[i, 1]);
                        row["cantidad"] = cantidad;
                        nRemito = " " + remitoSuc + "-" + remitoNro + ",";
                        row["remitosDescripcion"] = row["remitosDescripcion"].ToString().Replace(nRemito, "");
                        if (cantidad <= 0)
                            dt.Rows.Remove(row);

                        dt.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butBorrarRemito_Click(object sender, EventArgs e)
        {
            int index = cbRemitosCargados.SelectedIndex;
            if (index > -1)
            {
                restarLista();

                ArrayList array = (ArrayList)cbRemitosCargados.DataSource;
                array.RemoveAt(index); //array.Add(new ItemRemito(tbRemitoID.Text, descripcion));
                cbRemitosCargados.DataSource = null;
                cbRemitosCargados.DataSource = array;
                cbRemitosCargados.ValueMember = "remitoID";
                cbRemitosCargados.DisplayMember = "descripcion";
                if (index<cbRemitosCargados.Items.Count)
                    cbRemitosCargados.SelectedIndex = index;

                lbRemitosCargados.Text = "Remitos cargados (" + ((int)(cbRemitosCargados.Items.Count - 1)).ToString() + ")";

            }
            else
                lbRemitosCargados.Text = "Remitos cargados (0)";
        }

        private void butImprimirPlanilla_Click(object sender, EventArgs e)
        {
            imprimirPlanilla();
        }

        //Imprime la planilla
        private void imprimirPlanilla()
        {
            try
            {

                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Preparando Reporte...", true);

                /****************** Preparamos el Reporte ****************************/
                crPlanillaReparto doc = new crPlanillaReparto();
                doc.SetDataSource((DataTable)dgSubArticulos.DataSource);

                doc.DataDefinition.FormulaFields["txtFecha"].Text = "\"" + dtpFecha.Text + "\"";
                doc.DataDefinition.FormulaFields["txtTransporteNombre"].Text = "\"" + tbTransporteNombre.Text + "\"";
                

                UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Reporte Listo.", false);

                /*frmPreview fp = new frmPreview();
                fp.Text = "Vista Previa: "; // + dgItems.CaptionText;
                fp.crystalReportViewer1.ReportSource = doc;
                fp.Show();*/



                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                printDialog1.Document = pd;
                printDialog1.PrinterSettings.Copies = 2;

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

        private void butLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            DialogResult dlg = MessageBox.Show("¿Desea borrar los datos de esta Planilla?", "Borrar Planilla de Reparto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                tbTransporteNombre.Text = "";
                tbRemitoSucDesdeB.Text = "";
                tbRemitoNroDesdeB.Text = "";
                lbDestinatario.Text = "";
                lbDireccion.Text = "";
                lbObsequiante.Text = "";
                tbRemitoID.Text = Utilidades.ID_VACIO;
                ArrayList ar = (ArrayList)cbRemitosCargados.DataSource;
                ar.Clear();
                ar.Add(new ItemRemito(Utilidades.ID_VACIO, ""));
                cbRemitosCargados.DataSource = null;
                cbRemitosCargados.DataSource = ar;
                cbRemitosCargados.ValueMember = "remitoID";
                cbRemitosCargados.DisplayMember = "descripcion";
                ((DataTable)dgSubArticulos.DataSource).Rows.Clear();
            }
        }

    }

    public class ItemRemito
    {
        string p_remitoID;
        string p_descripcion;

        public ItemRemito(string remitoID, string descripcion)
        {
            this.p_remitoID = remitoID;
            this.p_descripcion = descripcion;
        }

        public string descripcion
        {
            get { return this.p_descripcion; }
        }

        public string remitoID
        {
            get { return this.p_remitoID; }
        } 

    }
}