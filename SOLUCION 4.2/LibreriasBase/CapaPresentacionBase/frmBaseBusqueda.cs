using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocioBase;

namespace CapaPresentacionBase
{
    public abstract partial class frmBaseBusqueda : Form
    {
        public Configuracion configuracion;
        public string EntidadNombre = "";
        public Control controlContenedorResultados;
        
        public EntidadFactoryBase entidadFac;

        public bool habilitarBusquedaAutomatica = true;
        public bool habilitarBusquedaInicial = true;

        //Define el Delegado 
        public delegate void DelegateDevolverID(string ID);
        public DelegateDevolverID objDelegateDevolverID = null;
        

        public object delegado;

        public frmBaseBusqueda()
        {
            InitializeComponent();
        }

        public frmBaseBusqueda(Configuracion conf, string entidadNom): this(conf, entidadNom, true, true)
        {
 
        }

        public frmBaseBusqueda(Configuracion conf, string entidadNom, bool habilitarBusquedaAutomatica, bool habilitarBusquedaInicial)
        {
            InitializeComponent();

            this.configuracion = conf;
            this.EntidadNombre = entidadNom;
            this.Text = "Buscar " + this.EntidadNombre;
            this.lbTitulo.Text = "Buscar " + this.EntidadNombre;
            this.habilitarBusquedaAutomatica = habilitarBusquedaAutomatica;
            this.habilitarBusquedaInicial = habilitarBusquedaInicial;
        

           //entidadFac = new EntidadFactoryBase(this.configuracion, this.EntidadNombre);
            crearEntidadFac();

            if (this.habilitarBusquedaInicial)
                buscar();
        }

        public abstract void crearEntidadFac();


        public string buscarCodigo(string codigo)
        {
            return "";
        }

        private void frmBaseBusqueda_Shown(object sender, EventArgs e)
        {
            tbPalabrasClave.Focus();
        }

        private void butBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        //Realiza la búsqueda
        private void buscar()
        {
            try
            {
                dgvItems.DataSource = entidadFac.getSelect(tbPalabrasClave.Text);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbPalabrasClave_TextChanged(object sender, EventArgs e)
        {
            if (tbPalabrasClave.Text.Trim().Length > 3 && this.habilitarBusquedaAutomatica)
                buscar();
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    aceptar();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    cancelar();
                    this.Close();
                    break;
            }
        }

        private void tbPalabrasClave_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (this.habilitarBusquedaAutomatica)
                            aceptar();
                        else
                            buscar();

                        e.Handled = true;
                        break;
                    }
                case Keys.Down:
                    dgvItems.Focus();
                    break;
                case Keys.Escape:
                    cancelar();
                    break;
            }
        }

        //Cierra devolviendo el valor seleccionado
        private void aceptar()
        {
            string id = Utilidades.ID_VACIO;
            if (dgvItems.RowCount > 0)
            {
                if (dgvItems.CurrentRow.Index > -1)
                {
                    id = dgvItems.CurrentRow.Cells["id"].Value.ToString();
                }
            }
            this.Close();

            //Devuelve el ID del Articulo Seleccionado
            if (objDelegateDevolverID != null)
                objDelegateDevolverID(id);
        }

        //Cierra cancelando la búsqueda
        private void cancelar()
        {
            this.Close();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            aceptar();
        }


    }
}