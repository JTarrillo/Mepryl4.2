using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmConfigUbicacionFotos : Form
    {
        UbicacionFotos DirectorioFotos = new UbicacionFotos();

        public frmConfigUbicacionFotos()
        {
            InitializeComponent();
        }

        private void btnPreventiva_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtPreventiva.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }

        private void btnLaboral_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdMostrarDirectorio = new FolderBrowserDialog();

            if (fbdMostrarDirectorio.ShowDialog() == DialogResult.OK)
            {
                txtLaboral.Text = fbdMostrarDirectorio.SelectedPath;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            DirectorioFotos.GuardarDirectorioFotos(txtPreventiva.Text, txtLaboral.Text);
            MessageBox.Show("¡Se guardó correctamente!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmConfigUbicacionFotos_Load(object sender, EventArgs e)
        {
            txtLaboral.Text = DirectorioFotos.UbicacionFotoLaboral();
            txtPreventiva.Text = DirectorioFotos.UbicacionFotopreventiva();
        }


    }
}
