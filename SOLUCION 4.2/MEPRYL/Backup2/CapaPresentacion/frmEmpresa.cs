using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmEmpresa : Form
    {
        private frmBusquedaEmpresa frmBusqueda;
        private CapaNegocioMepryl.Empresa empresa;

        public frmEmpresa(frmBusquedaEmpresa frm)
        {
            InitializeComponent();
            frmBusqueda = frm;
            empresa = new CapaNegocioMepryl.Empresa();
        }

        public void modoConsulta(object idEmpresa)
        {
            botGuardar.Visible = false;
            botCancelar.Visible = false;
            botVolver.Visible = true;
            botModificar.Visible = true;
            setearId(idEmpresa);
            mostrarDatos();
            lbTitulo.Text = "Ficha de Empresa";
            cambiarHabilitacionControles(false);
        }

        public void modoEdicion(object idEmpresa)
        {
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            botVolver.Visible = false;
            botModificar.Visible = false;
            setearId(idEmpresa);
            mostrarDatos();
            lbTitulo.Text = "Edición de Empresa";
            cambiarHabilitacionControles(true);
            tbRazonSocial.Focus();
        }

        public void modoNuevo()
        {
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            botVolver.Visible = false;
            botModificar.Visible = false;
            limpiarFormulario();
            lbTitulo.Text = "Ingreso de Médico";
            cambiarHabilitacionControles(true);
            tbRazonSocial.Focus();
        }

        private void limpiarFormulario()
        {
            tbId.Clear();
            tbRazonSocial.Clear();
            tbNombreFantasia.Clear();
            cboTipoDocumento.SelectedIndex = -1;
            tbNroDocumento.Clear();
            cboTipoContribuyente.SelectedIndex = -1;
            tbDireccion.Clear();
            tbCodigoPostal.Clear();
            tbLocalidad.Clear();
            cboProvincia.SelectedIndex = -1;
            cboTipoEntidad.SelectedIndex = -1;
            cboArt.SelectedIndex = -1;
            tbActividadPrincipal.Clear();
            tbCantPersonal.Clear();
            tbPaginaWeb.Clear();
            tbFechaAlta.Clear();
            cboClienteActivo.SelectedIndex = -1;
            pbLogo.Image = null;
            tbApeNom1.Clear();
            cboArea1.SelectedIndex = -1;
            tbTelefono1.Clear();
            tbCelular1.Clear();
            tbMail1.Clear();
            tbApeNom2.Clear();
            cboArea2.SelectedIndex = -1;
            tbTelefono2.Clear();
            tbCelular2.Clear();
            tbMail2.Clear(); 
            tbApeNom3.Clear();
            cboArea3.SelectedIndex = -1;
            tbTelefono3.Clear();
            tbCelular3.Clear();
            tbMail3.Clear();
            cboCategoria.SelectedIndex = -1;
            cboCondicionVenta.SelectedIndex = -1;
            cboTipoContrato.SelectedIndex = -1;
            cboListaPrecios.SelectedIndex = -1;
            cbModifConFact.Checked = false;
            tbDiaHorarioPago.Clear();
            tbObservaciones.Clear();
            tbImporte.Clear();
            tbInteres.Clear();
            tbUltAnio.Clear();
            tbUltMes.Clear();
            cbConsultas.Checked = false;
            cbExAptitud.Checked = false;
            cbVisitas.Checked = false;
            tbCantExAptitud.Clear();
            tbCantVisitas.Clear();
        }

        private void setearId(object id)
        {
            tbId.Text = id.ToString();
        }

        private void cambiarHabilitacionControles(bool estado)
        {
            tbRazonSocial.Enabled = estado;
            tbNombreFantasia.Enabled = estado;
            cboTipoDocumento.Enabled = estado;
            tbNroDocumento.Enabled = estado;
            cboTipoContribuyente.Enabled = estado;
            tbDireccion.Enabled = estado;
            tbCodigoPostal.Enabled = estado;
            tbLocalidad.Enabled = estado;
            cboProvincia.Enabled = estado;
            cboTipoEntidad.Enabled = estado;
            cboArt.Enabled = false;
            tbActividadPrincipal.Enabled = estado;
            tbCantPersonal.Enabled = estado;
            tbPaginaWeb.Enabled = estado;
            cboClienteActivo.Enabled = estado;
            tbFechaAlta.Enabled = false;
            botCargarLoco.Enabled = estado;
            tbApeNom1.Enabled = estado;
            cboArea1.Enabled = estado;
            tbTelefono1.Enabled = estado;
            tbCelular1.Enabled = estado;
            tbMail1.Enabled = estado;
            tbApeNom2.Enabled = estado;
            cboArea2.Enabled = estado;
            tbTelefono2.Enabled = estado;
            tbCelular2.Enabled = estado;
            tbMail2.Enabled = estado;
            tbApeNom3.Enabled = estado;
            cboArea3.Enabled = estado;
            tbTelefono3.Enabled = estado;
            tbCelular3.Enabled = estado;
            tbMail3.Enabled = estado;
            cboCategoria.Enabled = estado;
            cboCondicionVenta.Enabled = estado;
            cboTipoContrato.Enabled = estado;
            cboListaPrecios.Enabled = false;
            cbModifConFact.Enabled = false;
            tbDiaHorarioPago.Enabled = estado;
            tbObservaciones.Enabled = estado;
            tbImporte.Enabled = estado;
            tbInteres.Enabled = estado;
            tbUltMes.Enabled = false;
            tbUltAnio.Enabled = false;
            cbConsultas.Enabled = estado;
            cbExAptitud.Enabled = estado;
            cbVisitas.Enabled = estado;
            tbCantExAptitud.Enabled = estado;
            tbCantVisitas.Enabled = estado;
            if (estado) { verificarValorCheckBoxs();  }
            comprobarAbono();
        }

        private void mostrarDatos()
        {
            Entidades.Empresa entidad = empresa.cargarDatos(tbId.Text);
            llenarFormulario(entidad);
        }

        private void llenarFormulario(Entidades.Empresa entidad)
        {
            tbId.Text = entidad.Id.ToString();
            tbRazonSocial.Text = entidad.RazonSocial;
            tbNombreFantasia.Text = entidad.NombreFantasia;
            if (entidad.TipoDocumento != string.Empty) { cboTipoDocumento.SelectedItem = entidad.TipoDocumento; }
            tbNroDocumento.Text = entidad.NumeroDocumento;
            if (entidad.TipoContribuyente != string.Empty) { cboTipoContribuyente.SelectedItem = entidad.TipoContribuyente; }
            tbDireccion.Text = entidad.Direccion;
            tbCodigoPostal.Text = entidad.CodigoPostal;
            tbLocalidad.Text = entidad.Localidad;
            if (entidad.Provincia != string.Empty) { cboProvincia.SelectedItem = entidad.Provincia; }
            if (entidad.TipoEntidad != string.Empty) { cboTipoEntidad.SelectedItem = entidad.TipoEntidad; }
            if (entidad.Art != Guid.Empty) { cboArt.SelectedValue = entidad.Art; }
            tbActividadPrincipal.Text = entidad.ActividadPrincipal;
            if (entidad.CantPersonal != -1) { tbCantPersonal.Text = entidad.CantPersonal.ToString(); }
            tbPaginaWeb.Text = entidad.PaginaWeb;
            if (entidad.Activo != string.Empty) { cboClienteActivo.SelectedItem = entidad.Activo; }
            if (entidad.FechaAlta != string.Empty) { tbFechaAlta.Text = entidad.FechaAlta; }
            if (entidad.Logo.Length > 0)
            {
                pbLogo.Image = Image.FromStream(entidad.Logo);
                pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            tbApeNom1.Text = entidad.ApeNom1;
            if (entidad.Area1 != string.Empty) { cboArea1.SelectedItem = entidad.Area1; }
            tbTelefono1.Text = entidad.Telefono1;
            tbCelular1.Text = entidad.Celular1;
            tbMail1.Text = entidad.Email1;
            tbApeNom2.Text = entidad.ApeNom2;
            if (entidad.Area2 != string.Empty) { cboArea2.SelectedItem = entidad.Area2; }
            tbTelefono2.Text = entidad.Telefono2;
            tbCelular2.Text = entidad.Celular2;
            tbMail2.Text = entidad.Email2;
            tbApeNom3.Text = entidad.ApeNom3;
            if (entidad.Area3 != string.Empty) { cboArea3.SelectedItem = entidad.Area3; }
            tbTelefono3.Text = entidad.Telefono3;
            tbCelular3.Text = entidad.Celular3;
            tbMail3.Text = entidad.Email3;
            if (entidad.Categoria != string.Empty) { cboCategoria.SelectedItem = entidad.Categoria; }
            if (entidad.CondicionVenta != string.Empty) { cboCondicionVenta.SelectedItem = entidad.CondicionVenta; }
            if (entidad.TipoContrato != string.Empty) { cboTipoContrato.SelectedItem = entidad.TipoContrato; }
            if (entidad.ListaPrecios != Guid.Empty) { cboListaPrecios.SelectedValue = entidad.ListaPrecios; }
            cbModifConFact.Checked = entidad.ModifConFact;
            tbDiaHorarioPago.Text = entidad.DiasYHorariosPago;
            tbObservaciones.Text = entidad.Observaciones;
            if (entidad.ImpAbono != 0) { tbImporte.Text = entidad.ImpAbono.ToString();  }
            if (entidad.IntMora != 0) { tbInteres.Text = entidad.IntMora.ToString(); }          
            tbUltMes.Text = entidad.UltMesFact;
            tbUltAnio.Text = entidad.UltAnioFact;
            cbConsultas.Checked = entidad.Consultas;
            cbExAptitud.Checked = entidad.ExAptitud;
            cbVisitas.Checked = entidad.Visitas;
            if (entidad.CantExAptitud != -1) { tbCantExAptitud.Text = entidad.CantExAptitud.ToString(); }
            if (entidad.CantVisitas != -1) { tbCantVisitas.Text = entidad.CantVisitas.ToString(); }
            verificarValorCheckBoxs();
        }

        private Entidades.Empresa cargarDatos()
        {
            Entidades.Empresa retorno = new Entidades.Empresa();
            if (tbId.Text != string.Empty) { retorno.Id = new Guid(tbId.Text); }
            retorno.RazonSocial = tbRazonSocial.Text;
            retorno.NombreFantasia = tbNombreFantasia.Text;
            if (cboTipoDocumento.SelectedIndex != -1) { retorno.TipoDocumento = cboTipoDocumento.SelectedItem.ToString(); }
            retorno.NumeroDocumento = tbNroDocumento.Text.Replace("-","");
            if (cboTipoContribuyente.SelectedIndex != -1) { retorno.TipoContribuyente = cboTipoContribuyente.SelectedItem.ToString(); }
            retorno.Direccion = tbDireccion.Text;
            retorno.CodigoPostal = tbCodigoPostal.Text;
            retorno.Localidad = tbLocalidad.Text;
            if (cboProvincia.SelectedIndex != -1) { retorno.Provincia = cboProvincia.SelectedItem.ToString(); }
            if (cboTipoEntidad.SelectedIndex != -1) { retorno.TipoEntidad = cboTipoEntidad.SelectedItem.ToString(); }
            if (cboArt.SelectedIndex != -1) { retorno.Art = new Guid(cboArt.SelectedValue.ToString()); }
            retorno.ActividadPrincipal = tbActividadPrincipal.Text;
            if (tbCantPersonal.Text != string.Empty) { retorno.CantPersonal = Convert.ToInt16(tbCantPersonal.Text); }
            retorno.PaginaWeb = tbPaginaWeb.Text;
            if (cboClienteActivo.SelectedIndex != -1) { retorno.Activo = cboClienteActivo.SelectedItem.ToString(); }
            retorno.Logo = cargarImagen();
            retorno.ApeNom1 = tbApeNom1.Text;
            retorno.ApeNom2 = tbApeNom2.Text;
            retorno.ApeNom3 = tbApeNom3.Text;
            if (cboArea1.SelectedIndex != -1) { retorno.Area1 = cboArea1.SelectedItem.ToString(); }
            if (cboArea2.SelectedIndex != -1) { retorno.Area2 = cboArea1.SelectedItem.ToString(); }
            if (cboArea3.SelectedIndex != -1) { retorno.Area3 = cboArea1.SelectedItem.ToString(); }
            retorno.Telefono1 = tbTelefono1.Text;
            retorno.Telefono2 = tbTelefono2.Text;
            retorno.Telefono3 = tbTelefono3.Text;
            retorno.Celular1 = tbCelular1.Text;
            retorno.Celular2 = tbCelular2.Text;
            retorno.Celular3 = tbCelular3.Text;
            retorno.Email1 = tbMail1.Text;
            retorno.Email2 = tbMail2.Text;
            retorno.Email3 = tbMail3.Text;
            if (cboCategoria.SelectedIndex != -1) { retorno.Categoria = cboCategoria.SelectedItem.ToString(); }
            if (cboCondicionVenta.SelectedIndex != -1) { retorno.CondicionVenta = cboCondicionVenta.SelectedItem.ToString(); }
            if (cboTipoContrato.SelectedIndex != -1) { retorno.TipoContrato = cboTipoContrato.SelectedItem.ToString(); }
            if (cboListaPrecios.SelectedIndex != -1) { retorno.ListaPrecios = new Guid(cboListaPrecios.SelectedValue.ToString()); }
            retorno.ModifConFact = cbModifConFact.Checked;
            retorno.DiasYHorariosPago = tbDiaHorarioPago.Text;
            retorno.Observaciones = tbObservaciones.Text;
            if (tbImporte.Text != string.Empty) { retorno.ImpAbono = Convert.ToDecimal(tbImporte.Text); }
            if (tbInteres.Text != string.Empty) { retorno.IntMora = Convert.ToDecimal(tbInteres.Text); }
            retorno.Consultas = cbConsultas.Checked;
            retorno.ExAptitud = cbExAptitud.Checked;
            retorno.Visitas = cbVisitas.Checked;
            if (tbCantExAptitud.Text != string.Empty) { retorno.CantExAptitud = Convert.ToInt16(tbCantExAptitud.Text); }
            if (tbCantVisitas.Text != string.Empty) { retorno.CantVisitas = Convert.ToInt16(tbCantVisitas.Text); }
            return retorno;
        }

        private System.IO.MemoryStream cargarImagen()
        {
            if(pbLogo.Image != null)
            {
                System.IO.MemoryStream msLogo = new System.IO.MemoryStream();
                pbLogo.Image.Save(msLogo, System.Drawing.Imaging.ImageFormat.Png);
                return msLogo;
 
            }
            return new System.IO.MemoryStream();                  
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            modoEdicion(tbId.Text);
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            guardarDatos();
        }

        private void guardarDatos()
        {
            if (tbId.Text == string.Empty)
            {
                nuevaEmpresa();
            }
            else
            {
                editarEmpresa();
            }
        }

        private void nuevaEmpresa()
        {
            Entidades.Empresa entidad = cargarDatos();
            Entidades.Resultado resultado = empresa.nuevaEmpresa(entidad);
            if (resultado.Modo == -1)
            {
                MessageBox.Show("Error al crear empresa.\nError: " + resultado.Mensaje, "Ingresar Empresa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("¡Empresa ingresada correctamente!", "Ingresar Empresa",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmBusqueda.actualizarListado();
            }
        }

        private void editarEmpresa()
        {
            Entidades.Empresa entidad = cargarDatos();
            Entidades.Resultado resultado = empresa.editarEmpresa(entidad);
            if (resultado.Modo == -1)
            {
                MessageBox.Show("Error al editar los datos de la empresa.\nError: " + resultado.Mensaje, "Editar Empresa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("¡Datos actualizados correctamente correctamente!", "Editar Empresa",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmBusqueda.actualizarListado();
            }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            cerrar();
        }

        private void botVolver_Click(object sender, EventArgs e)
        {
            cerrar();
        }

        private void cerrar()
        {
            this.Close();
        }

        private void botCargarLoco_Click(object sender, EventArgs e)
        {
            abrirFD();
        }

        private void abrirFD()
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string direccion = openFileDialog.FileName.ToString();
                    pbLogo.Image = Image.FromFile(direccion);
                    pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    MessageBox.Show("¡No se soporta el formato del archivo seleccionado!");
                }
            }
        }

        private void cbVisitas_CheckedChanged(object sender, EventArgs e)
        {
            verificarValorCheckBoxs();
        }

        private void cbExAptitud_CheckedChanged(object sender, EventArgs e)
        {
            verificarValorCheckBoxs();
        }

        private void verificarValorCheckBoxs()
        {
            if (cbExAptitud.Checked) { tbCantExAptitud.Enabled = true; }
            else { tbCantExAptitud.Enabled = false; tbCantExAptitud.Clear(); }
            if (cbVisitas.Checked) { tbCantVisitas.Enabled = true; }
            else { tbCantVisitas.Enabled = false; tbCantVisitas.Clear(); }
        }

        private void tbImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumerosDecimales(e, tbImporte);
        }

        private void tbInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumerosDecimales(e, tbInteres);
        }

        private void soloNumerosDecimales(KeyPressEventArgs e, TextBox tb)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;            
            }
            tb.Text = tb.Text.Replace('.',',');
            tb.SelectionStart = tb.Text.Length;
        }

        private void soloNumeros(KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void tbCantVisitas_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbCantExAptitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbCelular1_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbCantPersonal_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void cboTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            comprobarAbono();
        }

        private void comprobarAbono()
        {
            panelAbono.Visible = false;
            panelPrestaciones.Visible = false;
            if (cboTipoContrato.SelectedIndex == 0)
            {
                panelAbono.Visible = true;
                panelPrestaciones.Visible = true;
            }
        }

        private void tbTelefono1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
                (sender as TextBox).Paste();
        }


     
    }
}
