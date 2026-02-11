using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmSeleccionarProfesional : Form
    {
        private CapaNegocioMepryl.Profesionales profesionales;
        private CapaNegocioMepryl.UsuarioSistema usuario;
        private string strIdUsuario = "";

        public frmSeleccionarProfesional(string idUsuario)
        {
            InitializeComponent();
            profesionales = new CapaNegocioMepryl.Profesionales();
            usuario = new CapaNegocioMepryl.UsuarioSistema();
            strIdUsuario = idUsuario;

            InicializarDataGridView();
            CargarDatosDGV();
            //cargarDGV();
            //seleccionaRegistro();
        }

        private void cargarDGV()
        {
            dgv.DataSource = profesionales.cargarProfesionalesReducido();
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            string idProfesional = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();

            usuario.ActualizaProfesionalAsignado(strIdUsuario, idProfesional);

            this.Close();
        }

        private void seleccionaRegistro()
        {
            string strResultado = "";
            string strIdProfesional = "";

            strIdProfesional = usuario.RecuperaIDProfesionalAsignado(strIdUsuario);

            if (dgv.Rows.Count > 0)
            {
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    strResultado = dgv.Rows[i].Cells[0].Value.ToString();

                    if (strResultado == strIdProfesional)
                    {
                        dgv.Rows[i].Selected = true;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        return;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarColumnaDGV(string nombreOculto, string nombreAMostrar, bool visible, string TipoColumna)
        {
            switch (TipoColumna)
            {
                case "CheckBox":
                    DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
                    dgv.Columns.Add(col1);
                    dgv.Columns[7].Name = nombreOculto;
                    dgv.Columns[7].HeaderText = nombreAMostrar;
                    dgv.Columns[7].Visible = visible;
                    break;
                case "Image":
                    DataGridViewImageColumn col2 = new DataGridViewImageColumn();
                    col2.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgv.Columns.Add(col2);
                    dgv.Columns[5].Name = nombreOculto;
                    dgv.Columns[5].HeaderText = nombreAMostrar;
                    dgv.Columns[5].Visible = visible;
                    break;
                case "Button":
                    //DataGridViewButtonColumn col3 = new DataGridViewButtonColumn();                    
                    DataGridViewImageColumn col3 = new DataGridViewImageColumn();
                    col3.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgv.Columns.Add(col3);
                    dgv.Columns[15].Name = nombreOculto;
                    dgv.Columns[15].HeaderText = nombreAMostrar;
                    dgv.Columns[15].Visible = visible;
                    break;
                default:
                    dgv.Columns.Add(nombreOculto, nombreAMostrar);
                    dgv.Columns[nombreOculto].Visible = visible;
                    break;
            }

        }

        private void InicializarDataGridView()
        {
            AgregarColumnaDGV("id", "Id", false, "Text");
            AgregarColumnaDGV("Medico", "Médico", true, "Text");
            AgregarColumnaDGV("Especialidad", "Especialidad", true, "Text");            
                        
            dgv.Columns[1].Width = 200;
            dgv.Columns[2].Width = 160;           

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void CargarDatosDGV()
        {
            if (dgv.Rows.Count > 0)
                dgv.Rows.Clear();

            foreach (DataRow r in profesionales.cargarProfesionalesReducido().Rows)
            {
                dgv.Rows.Add(r.ItemArray);
            }

            seleccionaRegistro();
            
            dgv.AllowUserToAddRows = false; // Elimina la última fila en blanco
        }
    }
}
