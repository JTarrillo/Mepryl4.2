using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmModificarLigasClubes : Form
    {
        private string strID = "";
        private string strCodigo = "";
        private string strLiga = "";
        private string strDescripcion = "";
        private bool blnActivo = false;
        private string strPathImagen = "";
        private bool blnActualizar = false;

        private CapaNegocioMepryl.LigaMantenimiento Liga;
        
        public frmModificarLigasClubes(string ID, string Codigo, string sLiga, string Descripcion, bool Activo, string PathImagen, bool Actualizar)
        {
            InitializeComponent();
            Liga = new CapaNegocioMepryl.LigaMantenimiento();
            strID = ID;
            strCodigo = Codigo;
            strLiga = sLiga;
            strDescripcion = Descripcion;
            blnActivo = Activo;
            strPathImagen = PathImagen;
            blnActualizar = Actualizar;

            LlenarFormulario();
        }

        private void ptbImagen_DoubleClick(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void LlenarFormulario()
        {
            if (blnActualizar == true)
            {
                txtNombre.Text = strLiga;
                txtDescripcion.Text = strDescripcion;
                chkActivo.Checked = blnActivo;
                if (!(string.IsNullOrEmpty(strPathImagen)))
                    ptbImagen.Image = Image.FromFile(strPathImagen);

                this.Text = "Modificar registro";
            }
            else
            {
                this.Text = "Nuevo registro";
            }

            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;
        }

        private void AbrirArchivo()
        {
            OpenFileDialog ofdAbrirArchivo = new OpenFileDialog();

            ofdAbrirArchivo.InitialDirectory = "S:\\FOTOS ESCUDO";
            ofdAbrirArchivo.Filter = "JPEG|*.jpg;*.jpeg;*.jpe|PNG|*.png";

            if (ofdAbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                strPathImagen = ofdAbrirArchivo.FileName;
                ptbImagen.Image = Image.FromFile(strPathImagen);                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNombre.Text)))
            {
                guardar();
                this.Close();
            }
            else
                MessageBox.Show("Antes de guardar debe asignar un nombre a la Liga.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void guardar()
        { 
            CargarDatos();
            Liga.ActualizarLigas(ObtenerDatosDGV());           
        }

        private void CargarDatos()
        {
            strLiga = txtNombre.Text;
            strDescripcion = txtDescripcion.Text;
            blnActivo = chkActivo.Checked;
        }
                
        private DataTable ObtenerDatosDGV()
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Id", typeof(System.String));
            dt.Columns.Add("Codigo", typeof(System.String));
            dt.Columns.Add("Liga", typeof(System.String));
            dt.Columns.Add("Descripcion", typeof(System.String));                        
            dt.Columns.Add("Activo", typeof(System.Boolean));            
            dt.Columns.Add("PathImagen", typeof(System.String));
        
            DataRow row = dt.NewRow();

            row["Id"] = strID;
            row["Codigo"] = strCodigo;
            row["Liga"] = strLiga;
            row["Descripcion"] = strDescripcion;                
            row["Activo"] = blnActivo;                
            row["PathImagen"] = strPathImagen;

            dt.Rows.Add(row);
            
            return dt;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }
    }
}
