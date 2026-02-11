using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocio;
using CapaNegocioBase;

namespace UserControls
{
    public partial class ucComboBoxActualizable : UserControl
    {
        public Configuracion configuracion;
        public string EntidadNombre;
        private DataTable tabla;
        public bool mayusculas = false;
        
        public ucComboBoxActualizable()
        {
            InitializeComponent();
        }

        public event EventHandler SelectedIndexChanged;

        public void inicializar(Configuracion conf, string nombreEntidad)
        {
            this.configuracion = conf;
            this.EntidadNombre = nombreEntidad;

            cargarCombo();
        }

        public void inicializar(Configuracion conf, string nombreEntidad, string filtro)
        {
            this.configuracion = conf;
            this.EntidadNombre = nombreEntidad;

            cargarCombo(filtro);
        }
        public void cargarCombo()
        {
            cargarCombo(null);
        }
        public void cargarCombo(string filtro)
        {
            try
            {
                EntidadGeneralFactory negEntidadFac = new EntidadGeneralFactory(this.configuracion, this.EntidadNombre);
                tabla = negEntidadFac.getAllInDataTable(filtro);
                
                cboCombo.DisplayMember = "descripcion";
                cboCombo.ValueMember = "id";
                cboCombo.DataSource = tabla;

                cboCombo.AutoCompleteSource = AutoCompleteSource.ListItems;

                negEntidadFac = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void ucComboBoxActualizable_Enter(object sender, EventArgs e)
        {
            cboCombo.Focus();
        }

        //Devuelve el ID seleccionado. Si es un dato nuevo, lo da de alta y devuelve el nuevo ID
        public Guid obtenerID()
        {
            Guid id = new Guid(Utilidades.ID_VACIO);
            try
            {
                if (cboCombo.SelectedValue != null)
                    id = new Guid(cboCombo.SelectedValue.ToString());
                else if (cboCombo.Text != "")
                {
                    EntidadGeneralFactory negEntidadFac = new EntidadGeneralFactory(this.configuracion, this.EntidadNombre);
                    EntidadBase negEntidad = negEntidadFac.alta(cboCombo.Text);

                    if (negEntidad != null)
                    {
                        id = negEntidad.id;
                        cargarCombo();
                        cboCombo.SelectedValue = id;
                    }


                    negEntidad = null;
                    negEntidadFac = null;
                }
                else
                    id = new Guid(Utilidades.ID_VACIO);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return id;
        }

        public void seleccionarItem(CapaNegocioBase.EntidadBase item)
        {
            try
            {
                Utilidades.comboSeleccionarItemById(item.id, ref cboCombo);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obtenerID().ToString());
        }

        private void cboCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);
        }

        public void limpiarItems()
        {
            cboCombo.DataSource = null;
        }

        private void cboCombo_TextChanged(object sender, EventArgs e)
        {
            if (this.mayusculas)
            {
                if (cboCombo.Text.Trim() != "")
                {
                    int Pos = cboCombo.SelectionStart;
                    this.mayusculas = false;
                    cboCombo.Text = cboCombo.Text.ToUpper();
                    this.mayusculas = true;
                    cboCombo.SelectionStart = Pos;
                }
            }
        }
    }
}
