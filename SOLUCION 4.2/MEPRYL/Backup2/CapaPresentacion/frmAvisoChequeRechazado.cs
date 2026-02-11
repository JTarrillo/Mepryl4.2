using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAvisoChequeRechazado : CapaPresentacionBase.frmBaseGrillaABM
    {
        public CapaNegocio.Cheque rglEntidad;

        public frmAvisoChequeRechazado()
        {
            InitializeComponent();
        }

        public frmAvisoChequeRechazado(Guid cuentaID, Comunes.Configuracion config)
            : base(config, ModoApertura.CONSULTA)
        {
            this.EntidadNombre = "Cheque";
            InitializeComponent();
            inicializarGrilla(new CapaNegocio.ChequeFactory(config, "Cheque"), "cuentaID='" + cuentaID.ToString() + "' AND rechazado=1");
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

                dgItems.Focus();
            }
            catch (Exception ex)
            {
                Comunes.ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void mostrarDatosObjeto()
        {
            base.mostrarDatosObjeto();
            try
            {
                rglEntidad = (CapaNegocio.Cheque)base.rglEntidad;
                /*cboaNroCuenta.cboCombo.SelectedValue = rglEntidad.cuentaID.ToString();
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
                dtpFechaBaja.Value = rglEntidad.fechaBaja;*/

                //Datos del rechazo
                //chChequeRechazado.Checked = rglEntidad.rechazado;
                dtpFechaRechazo.Value = rglEntidad.fechaRechazo;
                tbComentariosRechazo.Text = rglEntidad.comentariosRechazo;
            }
            catch (Exception ex)
            {
                Comunes.ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        protected override void recuperarObjetoPorCodigo()
        {
            base.recuperandoObjeto = true;
            if (dgItems.CurrentCell != null)
                base.recuperarObjetoPorCodigo(dgItems["codigo", dgItems.CurrentCell.RowIndex].Value.ToString());
            base.recuperandoObjeto = false;
        }

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new CapaNegocio.ChequeFactory(this.configuracion, this.EntidadNombre);
        }

    }
}

