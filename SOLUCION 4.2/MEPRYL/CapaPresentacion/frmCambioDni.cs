using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCambioDni : Form
    {
        private frmPaciente formPaciente;
        private CapaNegocioMepryl.PacienteDuplicado pacienteDuplicado;

        public frmCambioDni(string idPaciente1, string idPaciente2, frmPaciente frm)
        {
            InitializeComponent();
            formPaciente = frm;
            tbId1.Text = idPaciente1;
            tbId2.Text = idPaciente2;
            pacienteDuplicado = new CapaNegocioMepryl.PacienteDuplicado();
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            Entidades.PacienteDuplicado paciente1 = pacienteDuplicado.cargarDatosEntidad(tbId1.Text);
            Entidades.PacienteDuplicado paciente2 = pacienteDuplicado.cargarDatosEntidad(tbId2.Text);
            llenarFormularioPaciente1(paciente1);
            llenarFormularioPaciente2(paciente2);
            botEliminar1.Enabled = false;
            botEliminar2.Enabled = false;
            if (dgv1.Rows.Count <= 0) { botEliminar1.Enabled = true; }
            if (dgv2.Rows.Count <= 0) { botEliminar2.Enabled = true; }
        }

        private void llenarFormularioPaciente1(Entidades.PacienteDuplicado paciente)
        {
            tbId1.Text = paciente.Id.ToString();
            tbApellido1.Text = paciente.Apellido;
            tbNombre1.Text = paciente.Nombre;
            tbFechaNacimiento1.Text = paciente.FechaNacimiento;
            tbDni1.Text = paciente.Dni;
            dgv1.DataSource = paciente.ConsultasYExamenes;
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[4].Visible = false;
        }

        private void llenarFormularioPaciente2(Entidades.PacienteDuplicado paciente)
        {
            tbId2.Text = paciente.Id.ToString();
            tbApellido2.Text = paciente.Apellido;
            tbNombre2.Text = paciente.Nombre;
            tbFechaNacimiento2.Text = paciente.FechaNacimiento;
            tbDni2.Text = paciente.Dni;
            dgv2.DataSource = paciente.ConsultasYExamenes;
            dgv2.Columns[0].Visible = false;
            dgv2.Columns[4].Visible = false;
        }

        private void botIzquierda_Click(object sender, EventArgs e)
        {
            moverDatos((DataTable)dgv2.DataSource, tbId1.Text);
        }

        private void botDerecha_Click(object sender, EventArgs e)
        {
            moverDatos((DataTable)dgv1.DataSource, tbId2.Text);
        }

        private void moverDatos(DataTable tabla, string idPaciente)
        {
            DialogResult result = MessageBox.Show("¡Al realizar esta acción se unificarán las historias clínicas en un solo paciente! ¿Desea Continuar?",
                "Unificar Historias Clínicas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                pacienteDuplicado.moverDatos(tabla, idPaciente);
                inicializarFormulario();
            }
        }

        private void botEliminar1_Click(object sender, EventArgs e)
        {
            eliminarPaciente(tbId1.Text, tbId2.Text);
        }

        private void botEliminar2_Click(object sender, EventArgs e)
        {
            eliminarPaciente(tbId2.Text, tbId1.Text);
        }

        private void eliminarPaciente(string id, string idAConservar)
        {
            pacienteDuplicado.eliminarPaciente(id);
            formPaciente.recibirIdPaciente(idAConservar);
            this.Close();
        }

   

   

  
    }
}
