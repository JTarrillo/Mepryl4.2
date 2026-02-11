using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaPresentacionBase;
using CapaNegocio;
using Comunes;
using CapaNegocioBase;
namespace CapaPresentacion
{
    public partial class frmBusquedaClubxLiga :Form
    {
        public EntidadFactoryBase entidadFac;
        public Configuracion configuracion;
        public string EntidadNombre = "";
        public string idLiga;
        public string clubSeleccionado = "";
        public string idCLub = "";
        public delegate void DelegateDevolverID(string ID);
        public DelegateDevolverID objDelegateDevolverID = null;
        public frmBusquedaClubxLiga()
        {
            InitializeComponent();
        }

        public frmBusquedaClubxLiga(Configuracion conf, string entidadNom,string idLiga)
        {
            InitializeComponent();

            this.configuracion = conf;
            this.EntidadNombre = entidadNom;
            this.Text = "Buscar " + this.EntidadNombre;
            this.idLiga = idLiga; 
        

            //entidadFac = new EntidadFactoryBase(this.configuracion, this.EntidadNombre);
            crearEntidadFac();

            
                buscar();
        }
        //public frmBusquedaClubxLiga(Configuracion conf, string entidadNom,string idLiga)
           
        //{
        //    this.txtBusqueda.CharacterCasing = CharacterCasing.Upper;
        //  //  this.tbPalabrasClave.CharacterCasing = CharacterCasing.Upper;
            
        //}

         public  void crearEntidadFac()
        {
            this.entidadFac = new EntidadGeneralFactory(this.configuracion, this.EntidadNombre,this.idLiga);
        }


         private void buscar()
         {
             try
             {
                 dgvClub.DataSource = entidadFac.getSelectClub(this.idLiga);

                 dgvClub.Columns[1].Visible = false;
                
             }
             catch (Exception ex)
             {
                 ManejadorErrores.escribirLog(ex, true, this.configuracion);
             }
         }
        //Viviana
         private void buscarClub()
         {
             try
             {
                 dgvClub.DataSource = entidadFac.getSelectBusClub(txtBusqueda.Text,this.idLiga);
                 dgvClub.Columns[1].Visible = false;
             }
             catch (Exception ex)
             {
                 ManejadorErrores.escribirLog(ex, true, this.configuracion);
             }
         }
         private void aceptar()
         { 
             string id = Utilidades.ID_VACIO;
             string descrip = "";
             DataGridViewRow row = dgvClub.CurrentRow;
             if (this.dgvClub.RowCount > 0)
             {
                 descrip = row.Cells[0].Value.ToString();
                 id = row.Cells[1].Value.ToString();
    
                 //id = dgvClub.Rows[dgvClub.CurrentCell.RowIndex].Cells["id"].Value.ToString();//grilla1.Rows(grilla1.CurrentCell.RowIndex).Cells(* ).Value
                     //descrip = this.dgvClub.CurrentRow.Cells["descripcion"].Value.ToString();
               
             }
             this.Close();
             clubSeleccionado =descrip ;
             idCLub = id;
             //Devuelve el ID del Articulo Seleccionado
             if (objDelegateDevolverID != null)
                 objDelegateDevolverID(id);
         }

         private void btnBuscar_Click(object sender, EventArgs e)
         {
             buscarClub();
            
         }

         private void txtBusqueda_TextChanged(object sender, EventArgs e)
         {
             buscarClub();
         }

         private void dgvClub_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
         {
             aceptar();
         }

         private void dgvClub_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == '\r')
             {
                 aceptar();
             }
         }

        
    }
}
