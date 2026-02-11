using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmImagenesExamen : Form
    {
        public frmImagenesExamen()
        {
            InitializeComponent();
            cargarImagenes();
        }

        private void cargarImagenes()
        {
            DataTable imagCarg = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.ImagenesExamenes where codigo = 1");
            DataTable imagNoCarg = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.ImagenesExamenes where codigo = 2");
            setearCargado(imagCarg); 
            setearNoCargado(imagNoCarg);
        }

        private void setearCargado(DataTable table)
        {
            setearValores(table,tbIdCarg,pbCarg);
        }

        private void setearNoCargado(DataTable table)
        {
            setearValores(table, tbIdNoCarg, pbNoCarg);
        }

        private void setearValores(DataTable tb, TextBox tbId, PictureBox pb)
        {
            if (tb.Rows.Count > 0)
            {
                tbId.Text = tb.Rows[0].ItemArray[0].ToString();
                byte[] imageBuffer = (byte[])tb.Rows[0].ItemArray[2];
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms = new System.IO.MemoryStream(imageBuffer);
                pb.Image = Image.FromStream(ms);
            }
            else
            {
                tbId.Text = "";
                pb.Image = null;
            }
        }

        private void botFD_Click(object sender, EventArgs e)
        {
            abrirFD(pbCarg);
        }

        private void botFL1_Click(object sender, EventArgs e)
        {
            abrirFD(pbNoCarg);
        }

        private void abrirFD(PictureBox pb)
        {
            if (pb.Image == null)
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        pb.Image = Image.FromFile(openFileDialog.FileName.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("¡No se soporta el formato del archivo seleccionado!",
                            "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("¡Primero debe eliminar la imágen actual!", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botAgCarg_Click(object sender, EventArgs e)
        {
            agregarImagen(pbCarg,1);
        }

        private void botAgNoCarg_Click(object sender, EventArgs e)
        {
            agregarImagen(pbNoCarg,2);
        }

        private void agregarImagen(PictureBox pb, int codigo)
        {
            if (pb.Image != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                List<string> listAdd = SQLConnector.generarListaParaProcedure("codigo", "imagen");
                SQLConnector.executeProcedure("sp_ImagenesExamenes_Add", listAdd, codigo, ms.GetBuffer());
                MessageBox.Show("Imágen guardada correctamente", 
                    "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarImagenes();

            }
            else
            {
                MessageBox.Show("¡Seleccione una imágen!",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botQuitCarg_Click(object sender, EventArgs e)
        {
            eliminarImagen(tbIdCarg,pbCarg);
        }

        private void botQuitNoCarg_Click(object sender, EventArgs e)
        {
            eliminarImagen(tbIdNoCarg,pbNoCarg);
        }

        private void eliminarImagen(TextBox tb, PictureBox pb)
        {
            if (pb.Image != null)
            {
                int id = Convert.ToInt16(tb.Text);
                List<string> listDelete = SQLConnector.generarListaParaProcedure("id");
                SQLConnector.executeProcedure("sp_ImagenesExamenes_Delete", listDelete, id);
                MessageBox.Show("Imágen eliminada correctamente",
                      "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarImagenes();
            }
            else
            {
                MessageBox.Show("¡No hay ninguna imágen para eliminar!",
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
