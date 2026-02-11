using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocio;
using UserControls;

namespace CapaPresentacion
{
    public partial class frmCheque : CapaPresentacionBase.frmBaseGrillaABM
    {
        public Cheque rglEntidad;

        public frmCheque(Configuracion config, ModoApertura modo) : base(config, modo)
        {
            //InitializeComponent();
            EntidadNombre = "Cheque";
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Cheque();
        }

        //Carga el Navegador de Formularios
        protected override void cargarNavegadorFormulario()
        {
            try
            {
                //InitializeComponent();
                base.cargarNavegadorFormulario();
                //Carga las teclas rapidas primero
                //navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscar, (char)Keys.F1));

                //Carga los controles
                navegador.agregarControl(new CapsulaControl((Control)cboaNroCuenta));
                navegador.agregarControl(new CapsulaControl((Control)cboaCliente));
                navegador.agregarControl(new CapsulaControl((Control)cboaBanco));
                navegador.agregarControl(new CapsulaControl((Control)cboaNroSucursal));
                navegador.agregarControl(new CapsulaControl((Control)tbNroCheque));
                navegador.agregarControl(new CapsulaControl((Control)dtpVencimiento));
                navegador.agregarControl(new CapsulaControl((Control)tbImporte));
                navegador.agregarControl(new CapsulaControl((Control)cboaFirmante));
                navegador.agregarControl(new CapsulaControl((Control)cboaProveedor));
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaBaja));
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaRechazo));
                navegador.agregarControl(new CapsulaControl((Control)tbComentariosRechazo));

                //Agrega los handlers para todos los controles del control contenedor
                navegador.agregarHandlersContenedor(this);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void modoEstatico(bool hayObjetoActivo)
        {
            base.modoEstatico(hayObjetoActivo);


            habilitarControles(ref gbControles, ref dgItems, false);
            habilitarControles(ref gbDarDeBaja, ref dgItems, false);
            habilitarControles(ref gbChequeRechazado, ref dgItems, false);
        }
        protected override void modoEditable()
        {
            base.modoEditable();
            habilitarControles(ref gbControles, ref dgItems, true);
            habilitarControles(ref gbDarDeBaja, ref dgItems, true);
            habilitarControles(ref gbChequeRechazado, ref dgItems, true);
            this.Focus();
            if (this.edicion == ModoEdicion.AGREGANDO)
            {
                cboaNroCuenta.inicializar(this.configuracion, "ChequeCuenta");
                cboaNroCuenta.cboCombo.Text = "";
            }
            cboaNroCuenta.Focus();
        }

        private void cboaCliente_Validated(object sender, EventArgs e)
        {
            if (cboaNroCuenta.cboCombo.Text.Trim() == "")
            {
                llenarCuentasCliente();
                verificarRechazados();
            }
        }

        private void llenarCuentasCliente()
        {
            try
            {
                string clienteID = cboaCliente.obtenerID().ToString();
                if (clienteID != Utilidades.ID_VACIO)
                {
                    cboaNroCuenta.inicializar(this.configuracion, "ChequeCuenta", "clienteID='" + clienteID + "'");
                    cargarCuenta();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void inicializarComponentes()
        {
            InitializeComponent();
            base.inicializarComponentes();

            cboaNroCuenta.inicializar(this.configuracion, "ChequeCuenta");
            cboaCliente.inicializar(this.configuracion, "Cliente");
            cboaBanco.inicializar(this.configuracion, "ChequeBanco");
            cboaNroSucursal.inicializar(this.configuracion, "ChequeBancoSucursal");
            cboaFirmante.inicializar(this.configuracion, "ChequeFirmante");
            cboaProveedor.inicializar(this.configuracion, "Proveedor");
            
            inicializarEntidad();

        }

        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro)
        {
            try
            {
                base.inicializarGrilla(ef, filtro);
                
                //Arregla la grilla
                dgItems.Columns["registroBLOB"].Visible = false;
                dgItems.Columns["id"].Visible = false;
                dgItems.Columns["cuentaID"].Visible = false;
                dgItems.Columns["clienteID"].Visible = false;
                dgItems.Columns["sucursalID"].Visible = false;
                dgItems.Columns["firmanteID"].Visible = false;
                dgItems.Columns["bancoID"].Visible = false;
                dgItems.Columns["estadoID"].Visible = false;
                dgItems.Columns["proveedorID"].Visible = false;
                dgItems.Columns["estadoTexto"].Visible = false;

                dgItems.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgItems.Columns["importe"].DefaultCellStyle.Format = "c";

                //Asigna los nombres de la base de datos
                dgItems.Columns["codigo"].HeaderText = "Código";
                dgItems.Columns["cuentaTexto"].HeaderText = "Nro. Cuenta";
                dgItems.Columns["clienteTexto"].HeaderText = "Cliente";
                dgItems.Columns["bancoTexto"].HeaderText = "Banco";
                dgItems.Columns["sucursalTexto"].HeaderText = "Nro. Sucursal";
                dgItems.Columns["nroCheque"].HeaderText = "Nro. Cheque";
                dgItems.Columns["vencimiento"].HeaderText = "Vencimiento";
                dgItems.Columns["importe"].HeaderText = "Importe";
                dgItems.Columns["firmanteTexto"].HeaderText = "Firmante";
                dgItems.Columns["baja"].HeaderText = "Baja";
                dgItems.Columns["proveedorTexto"].HeaderText = "Proveedor";
                dgItems.Columns["fechaBaja"].HeaderText = "Fecha Baja";
                dgItems.Columns["rechazado"].HeaderText = "Rechazado";
                dgItems.Columns["fechaRechazo"].HeaderText = "Fecha Rechazo";
                dgItems.Columns["comentariosRechazo"].HeaderText = "Comentarios Rechazo";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

       
        private void cboaNroCuenta_Validated(object sender, EventArgs e)
        {
            cargarCuenta();
            verificarRechazados();
        }

        private void cargarCuenta()
        {
            try
            {
                //Obtiene la Cuenta
                EntidadGeneralFactory efactory = new EntidadGeneralFactory(this.configuracion, "ChequeCuenta");
                CapaNegocioBase.EntidadBase cuenta = efactory.getByCodigo(cboaNroCuenta.cboCombo.Text);
                //Si existe, trae los datos relacionados
                if (cuenta != null)
                {
                    seleccionarCliente(cuenta);
                    seleccionarBanco(cuenta);
                    seleccionarSucursal(cuenta);
                    llenarFirmantes(cuenta);
                }
                else
                    cboaFirmante.limpiarItems();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void seleccionarCliente(CapaNegocioBase.EntidadBase cuenta)
        {
            try
            {
                //Obtiene la Cuenta
                EntidadGeneralFactory efactory = new EntidadGeneralFactory(this.configuracion, "Cliente");
                CapaNegocioBase.EntidadBase cliente = efactory.getById(cuenta.campos["clienteID"].ToString());
                //Si existe, trae los datos relacionados
                if (cliente != null)
                {
                    cboaCliente.seleccionarItem(cliente);
                }
                cliente = null;
                efactory = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void seleccionarBanco(CapaNegocioBase.EntidadBase cuenta)
        {
            try
            {
                //Obtiene la Cuenta
                EntidadGeneralFactory efactory = new EntidadGeneralFactory(this.configuracion, "ChequeBanco");
                CapaNegocioBase.EntidadBase banco = efactory.getById(cuenta.campos["bancoID"].ToString());
                //Si existe, trae los datos relacionados
                if (banco != null)
                {
                    cboaBanco.seleccionarItem(banco);
                }
                efactory = null;
                banco = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void seleccionarSucursal(CapaNegocioBase.EntidadBase cuenta)
        {
            try
            {
                //Obtiene la Cuenta
                EntidadGeneralFactory efactory = new EntidadGeneralFactory(this.configuracion, "ChequeBancoSucursal");
                CapaNegocioBase.EntidadBase sucursal = efactory.getById(cuenta.campos["bancoSucursalID"].ToString());
                //Si existe, trae los datos relacionados
                if (sucursal != null)
                {
                    cboaNroSucursal.seleccionarItem(sucursal);
                }
                efactory = null;
                sucursal = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butAceptar1_Enter(object sender, EventArgs e)
        {
            butAceptar.Select();
        }

        private void cboaBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarSucursales();
        }

        private void llenarSucursales()
        {
            string textoSucursal = "";
            if (cboaNroSucursal.cboCombo.Text != "" && cboaNroSucursal.cboCombo.SelectedValue == null)
                textoSucursal = cboaNroSucursal.cboCombo.Text;

            string bancoID = cboaBanco.obtenerID().ToString();
            cboaNroSucursal.inicializar(this.configuracion, "ChequeBancoSucursal", "bancoID='" + bancoID + "'");

            if (textoSucursal!="")
            {
                cboaNroSucursal.cboCombo.SelectedIndex = -1;
                cboaNroSucursal.cboCombo.Text = textoSucursal;
            }
        }

        private void llenarFirmantes(CapaNegocioBase.EntidadBase cuenta)
        {
            //string cuentaID = cboaNroCuenta.obtenerID().ToString();
            cboaFirmante.inicializar(this.configuracion, "ChequeFirmante", "cuentaID='" + cuenta.id.ToString() + "'");
        }

        private void cboaBanco_Validated(object sender, EventArgs e)
        {
            //Si el banco es nuevo, borra la lista de sucursales
            if (cboaBanco.cboCombo.SelectedValue == null)
            {
                cboaNroSucursal.limpiarItems();
            }
        }

        public override string validarDatosIngresados()
        {
            return "";
        }

        protected override void cargarObjetoReglas()
        {
            try
            {
                //MessageBox.Show(cboaNroSucursal.cboCombo.Text);
                inicializarEntidad();
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.cuentaID = cboaNroCuenta.obtenerID();
                rglEntidad.cuentaTexto = cboaNroCuenta.cboCombo.Text;
                rglEntidad.clienteID = cboaCliente.obtenerID();
                rglEntidad.clienteTexto = cboaCliente.cboCombo.Text;
                rglEntidad.bancoID = cboaBanco.obtenerID();
                rglEntidad.bancoTexto = cboaBanco.cboCombo.Text;

                rglEntidad.sucursalID = cboaNroSucursal.obtenerID();
                rglEntidad.sucursalTexto = cboaNroSucursal.cboCombo.Text;
                //MessageBox.Show(rglEntidad.sucursalTexto);
                rglEntidad.nroCheque = tbNroCheque.Text;
                rglEntidad.vencimiento = dtpVencimiento.Value;
                rglEntidad.importe = Double.Parse(tbImporte.Text,System.Globalization.NumberStyles.Currency);
                rglEntidad.firmanteID = cboaFirmante.obtenerID();
                rglEntidad.firmanteTexto = cboaFirmante.cboCombo.Text;
                //Datos de la baja
                rglEntidad.baja = chDarDeBaja.Checked;
                rglEntidad.proveedorID = cboaProveedor.obtenerID();
                rglEntidad.proveedorTexto = cboaProveedor.cboCombo.Text;
                rglEntidad.fechaBaja = dtpFechaBaja.Value;
                //Datos del rechazo
                rglEntidad.rechazado = chChequeRechazado.Checked;
                rglEntidad.fechaRechazo = dtpFechaRechazo.Value;
                rglEntidad.comentariosRechazo = tbComentariosRechazo.Text;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            ChequeFactory negEntidadFac = (ChequeFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new ChequeFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                ChequeFactory negEntidadFac = (ChequeFactory)crearNegEntidadFac();
                resultado = negEntidadFac.alta(rglEntidad);
                negEntidadFac = null;

                //Establece las relaciones entre las entidades de las combos
                establecerRelaciones();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        private void establecerRelaciones()
        {
            try
            {
                //Carga los IDs relacionales para Cuenta
                ChequeCuentaFactory cuentaFac = new ChequeCuentaFactory(this.configuracion, "ChequeCuenta");
                ChequeCuenta cuenta = (ChequeCuenta)cuentaFac.getById(cboaNroCuenta.obtenerID().ToString());
                if (cuenta != null)
                {
                    cuenta.clienteID = cboaCliente.obtenerID();
                    cuenta.bancoID = cboaBanco.obtenerID();
                    cuenta.bancoSucursalID = cboaNroSucursal.obtenerID();

                    cuentaFac.modificar(cuenta);
                }
                cuenta = null;
                cuentaFac = null;


                //Carga los IDs relacionales para la Sucursal
                ChequeBancoSucursalFactory bancoSucursalFac = new ChequeBancoSucursalFactory(this.configuracion, "ChequeBancoSucursal");
                ChequeBancoSucursal bancoSucursal = (ChequeBancoSucursal)bancoSucursalFac.getById(cboaNroSucursal.obtenerID().ToString());
                if (bancoSucursal != null)
                {
                    bancoSucursal.bancoID = cboaBanco.obtenerID();

                    bancoSucursalFac.modificar(bancoSucursal);
                }
                bancoSucursal = null;
                bancoSucursalFac = null;



                //Carga los IDs relacionales para el firmante
                ChequeFirmanteFactory firmanteFac = new ChequeFirmanteFactory(this.configuracion, "ChequeFirmante");
                ChequeFirmante firmante = (ChequeFirmante)firmanteFac.getById(cboaFirmante.obtenerID().ToString());
                if (firmante != null)
                {
                    firmante.cuentaID = cboaNroCuenta.obtenerID();

                    firmanteFac.modificar(firmante);
                }
                firmante = null;
                firmanteFac = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        //
        public override Resultado modificar()
        {
            Resultado resultado = new Resultado();
            try
            {
                ChequeFactory negEntidadFac = (ChequeFactory)crearNegEntidadFac();
                resultado = negEntidadFac.modificar(rglEntidad);
                negEntidadFac = null;

                establecerRelaciones();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        public override string borrar(string id)
        {
            string resultado = "";

            try
            {
                ChequeFactory negClienteFac = new ChequeFactory(this.configuracion, this.EntidadNombre);
                resultado = negClienteFac.borrar(id);

                negClienteFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }
        
        protected override void inicializarTabla()
        {
            base.inicializarTabla();

            inicializarGrilla(new ChequeFactory(this.configuracion, this.EntidadNombre), "1=2");
        }


       //Agrega un registro en la grilla
        public override void agregarRegistroGrilla(ref Resultado resultado)
        {
            try
            {
                if (dgItems.DataSource == null)
                    inicializarTabla();

                Cheque cheque = (Cheque)resultado.objeto;

                //Toma los datos en memoria
                string codigo = cheque.codigo;
                string cuentaTexto = cboaNroCuenta.cboCombo.Text;
                string clienteTexto = cboaCliente.cboCombo.Text;
                string bancoTexto = cboaBanco.cboCombo.Text;
                string sucursalTexto = cboaNroSucursal.cboCombo.Text;
                string nroCheque = tbNroCheque.Text;
                string vencimiento = dtpVencimiento.Text;
                double importe = double.Parse(tbImporte.Text, System.Globalization.NumberStyles.Currency);
                string firmanteTexto = cboaFirmante.cboCombo.Text;
                //Datos de la baja
                bool baja = chDarDeBaja.Checked;
                string proveedorTexto = cboaProveedor.cboCombo.Text;
                string fechaBaja = dtpFechaBaja.Text;
                //Datos del rechazo
                bool rechazado = chChequeRechazado.Checked;
                string fechaRechazo = dtpFechaRechazo.Text;
                string comentariosRechazo = tbComentariosRechazo.Text;

                
                DataTable tabla = (DataTable)dgItems.DataSource;
                DataRow row = tabla.NewRow();
                row["id"] = cheque.id;
                row["codigo"] = tbCodigo.Text.Trim() == "" ? 0 : int.Parse(tbCodigo.Text);
                
                tabla.Rows.InsertAt(row, 0);
                tabla.AcceptChanges();

                dgItems.CurrentCell = dgItems[0,0];

                dgItems.Rows[0].Cells["codigo"].Value = codigo;
                dgItems.Rows[0].Cells["cuentaTexto"].Value = cuentaTexto;
                dgItems.Rows[0].Cells["clienteTexto"].Value = clienteTexto;
                dgItems.Rows[0].Cells["bancoTexto"].Value = bancoTexto;
                dgItems.Rows[0].Cells["sucursalTexto"].Value = sucursalTexto;
                dgItems.Rows[0].Cells["nroCheque"].Value = nroCheque;
                dgItems.Rows[0].Cells["vencimiento"].Value = vencimiento;
                dgItems.Rows[0].Cells["importe"].Value = importe;
                dgItems.Rows[0].Cells["firmanteTexto"].Value = firmanteTexto;
                dgItems.Rows[0].Cells["baja"].Value = baja;
                dgItems.Rows[0].Cells["proveedorTexto"].Value = proveedorTexto;
                dgItems.Rows[0].Cells["fechaBaja"].Value = fechaBaja;
                dgItems.Rows[0].Cells["rechazado"].Value = rechazado;
                dgItems.Rows[0].Cells["fechaRechazo"].Value = fechaRechazo;
                dgItems.Rows[0].Cells["comentariosRechazo"].Value = comentariosRechazo;

                recuperarObjetoPorCodigo();

                row = null;
                tabla = null;
                cheque = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
        }

        //Elimina un registro de la grilla
        protected override void eliminarRegistroGrilla()
        {
            try
            {
                if (dgItems.CurrentCell != null)
                {
                    dgItems.Rows.RemoveAt(dgItems.CurrentCell.RowIndex);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Realiza la busqueda de las palabras clave de la caja de texto
        protected override void buscarPalabrasClave()
        {
            try
            {
                base.buscandoPalabrasClave = true;
                string like = "1=1";

                if (chDeBaja.Checked)
                    like += " AND baja=0 ";
                if (chRechazados.Checked)
                    like += " AND rechazado=0 ";

                if (tbBusqueda.Text.Trim() != "")
                {
                    string[] palabras = tbBusqueda.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach (string palabra in palabras)
                    {
                        like += " AND registroBLOB LIKE '%" + palabra + "%' ";
                    }
                }
                inicializarGrilla(new ChequeFactory(this.configuracion, this.EntidadNombre), like);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            finally
            {
                base.buscandoPalabrasClave = false;
            }
        }

        //Edita los datos de un registro de la grilla
        protected override void editarRegistro()
        {
            try
            {
                int i = dgItems.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    tabPrincipal.SelectedIndex = 1;
                    tbCodigo.Text = dgItems.Rows[i].Cells["codigo"].Value.ToString();
                    recuperarObjetoPorCodigo(tbCodigo.Text);



                    //Presiona el boton Modificar
                    base.modificarClick();
                }

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void recuperarObjetoPorCodigo()
        {
            base.recuperandoObjeto = true;
            if (dgItems.CurrentCell!=null)
                base.recuperarObjetoPorCodigo(dgItems["codigo", dgItems.CurrentCell.RowIndex].Value.ToString());
            base.recuperandoObjeto = false;
        }

        //Actualiza el registro de la grilla
        protected override void actualizarRegistro()
        {
            recuperarObjetoPorCodigo(tbCodigo.Text);
            //CapaNegocioBase.EntidadBase entidad = (CapaNegocioBase.EntidadBase)rglEntidad;
            base.actualizarRegistro(ref dgItems);
        }

        protected override void mostrarDatosObjeto()
        {
            base.mostrarDatosObjeto();
            try
            {
                rglEntidad = (Cheque)base.rglEntidad;
                cboaNroCuenta.cboCombo.SelectedValue = rglEntidad.cuentaID.ToString();
                cboaCliente.cboCombo.SelectedValue = rglEntidad.clienteID.ToString();
                cboaBanco.cboCombo.SelectedValue = rglEntidad.bancoID.ToString();
                cboaNroSucursal.cboCombo.SelectedValue = rglEntidad.sucursalID.ToString();
                tbNroCheque.Text = rglEntidad.nroCheque;
                dtpVencimiento.Value = rglEntidad.vencimiento;
                tbImporte.Text = rglEntidad.importe.ToString("c");
                cboaFirmante.cboCombo.SelectedValue = rglEntidad.firmanteID.ToString();

                //Datos de la baja
                chDarDeBaja.Checked = rglEntidad.baja;
                cboaProveedor.cboCombo.SelectedValue = rglEntidad.proveedorID.ToString();
                dtpFechaBaja.Value = rglEntidad.fechaBaja;

                //Datos del rechazo
                chChequeRechazado.Checked = rglEntidad.rechazado;
                dtpFechaRechazo.Value = rglEntidad.fechaRechazo;
                tbComentariosRechazo.Text = rglEntidad.comentariosRechazo;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected override void limpiarFormulario()
        {
            cboaNroCuenta.cboCombo.SelectedIndex = -1;
            cboaCliente.cboCombo.SelectedIndex = -1;
            cboaBanco.cboCombo.SelectedIndex = -1;
            cboaNroSucursal.cboCombo.SelectedIndex = -1;
            cboaNroSucursal.cboCombo.Text = "";
            tbNroCheque.Text = "";
            tbImporte.Text = "$ 0,00";
            cboaFirmante.cboCombo.SelectedIndex = -1;
            dtpVencimiento.Value = DateTime.Now;
            //Datos de la baja
            chDarDeBaja.Checked = false;
            cboaProveedor.cboCombo.SelectedIndex = -1;
            dtpFechaBaja.Value = DateTime.Now;
            //Datos del rechazo
            chChequeRechazado.Checked = false;
            dtpFechaRechazo.Value = DateTime.Now;
            tbComentariosRechazo.Text = "";
        }

        private void chDarDeBaja_CheckedChanged(object sender, EventArgs e)
        {
            cboaProveedor.Enabled = chDarDeBaja.Checked;
            dtpFechaBaja.Enabled = chDarDeBaja.Checked;
        }

        private void chChequeRechazado_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaRechazo.Enabled = chChequeRechazado.Checked;
            tbComentariosRechazo.Enabled = chChequeRechazado.Checked;
        }

        private void chDeBaja_CheckedChanged(object sender, EventArgs e)
        {
            buscarPalabrasClave();
        }


        //Busca si hay cheques rechazados para la cuenta o cliente seleccionado
        private void verificarRechazados()
        {
            try
            {
                ChequeFactory chf = new ChequeFactory(this.configuracion, this.EntidadNombre);
                if (chf.hayChequesRechazados(cboaNroCuenta.obtenerID()))
                {
                    frmAvisoChequeRechazado f = new frmAvisoChequeRechazado(cboaNroCuenta.obtenerID(), this.configuracion);
                    f.ShowDialog(this);
                }
                chf = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void imprimirListado()
        {
			try
			{
				rptListadoCheques doc = new rptListadoCheques();

				doc.SetDataSource(((DataTable)dgItems.DataSource));

				/*doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

				string cadenaFiltro = ""; //obtenerCadenaFiltro();
				string cadenaOrden = ""; //obtenerCadenaOrden();
				if (cadenaFiltro!="")
					doc.DataDefinition.FormulaFields["txtFiltroF"].Text = "\"" + cadenaFiltro + "\"";
				else
					doc.Section1.ReportObjects["txtFiltroTitulo"].ObjectFormat.EnableSuppress = true;

				if (cadenaOrden!="")
					doc.DataDefinition.FormulaFields["txtOrdenF"].Text = "\"" + cadenaOrden + "\"";
				else
					doc.Section7.ReportObjects["txtOrdenTitulo"].ObjectFormat.EnableSuppress = true;
                */
				
				System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
				printDialog1.Document = pd;
			
				if (printDialog1.ShowDialog()==DialogResult.OK)
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cboaNroSucursal.cboCombo.Text);
        }

    }
}