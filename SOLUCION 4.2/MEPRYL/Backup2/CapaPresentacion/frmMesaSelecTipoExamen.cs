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
    public partial class frmMesaSelecTipoExamen : Form
    {
        private string strMotivoConsulta = "";        
        private string strResultado = "";
        private string strIdEmpresa = "";
        private string strIdPaciente = "";
        private string strIdTurno = "";
        private string strIdTipoExamen = "";
        private string strIdConsulta = "";
        private string strResultadoID = "";
        private string strTipoConsulta = "";

        CapaNegocioMepryl.MesaEntrada mesaEntrada;
        CapaNegocioMepryl.ExamenPreventiva exPreventiva;

        public frmMesaSelecTipoExamen(string MotivoConsulta, string IdPaciente, string IdEmpresa, string IdTurno, string IdTipoExamen, string IdConsulta, string TipoConsulta)
        {
            InitializeComponent();
            strMotivoConsulta = MotivoConsulta;
            strTipoConsulta = TipoConsulta;
            strIdEmpresa = IdEmpresa;
            strIdPaciente = IdPaciente;
            strIdTurno = IdTurno;
            strIdTipoExamen = IdTipoExamen;
            strIdConsulta = IdConsulta;
        }
        
        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(strResultado)))
            {
                if (strMotivoConsulta == strTipoConsulta)
                {
                    mesaEntrada.ActualizaTipoExamenIDConsulta(strIdConsulta, TipoExamenID());
                }else
                {
                    frmMesaDeEntrada frmMesaEntrada = new frmMesaDeEntrada();
                    frmMesaEntrada.CambiarTipoExamen(NombreTipoExamen(), strMotivoConsulta, strIdPaciente, strIdEmpresa, strIdTurno, strIdConsulta, TipoExamenID());
                    //invalidarConsulta();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Tipo de Exámen", "Seleccionar Tipo de Exámen",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void botonPreventiva_CheckedChanged(object sender, EventArgs e)
        {
            if (botonPreventiva.Checked)
            {
                llenarGridView("1");
                strMotivoConsulta = "P";
            }
            else
            {
                dgvGrilla.DataSource = null;
            }
        }

        private void llenarGridView(string idMotivoConsulta)
        {
            mesaEntrada = new MesaEntrada();
            dgvGrilla.DataSource = mesaEntrada.cargarTiposDeExamen(idMotivoConsulta);
            dgvGrilla.Columns[0].Visible = false;
            dgvGrilla.Columns[1].Width = 285;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ColumnHeadersVisible = false;
        }

        private void BuscarGridView(string strValor)
        {
            mesaEntrada = new MesaEntrada();
            dgvGrilla.DataSource = mesaEntrada.cargarTiposDeExamenBuscar(strValor);
            dgvGrilla.Columns[0].Visible = false;
            dgvGrilla.Columns[1].Width = 285;
            dgvGrilla.RowHeadersVisible = false;
            dgvGrilla.ColumnHeadersVisible = false;
        }

        private void botonLaboral_CheckedChanged(object sender, EventArgs e)
        {
            if (botonLaboral.Checked)
            {
                llenarGridView("2");
                strMotivoConsulta = "L";
            }
            else
            {
                dgvGrilla.DataSource = null;
            }
        }

        private void botonClinica_CheckedChanged(object sender, EventArgs e)
        {
            if (botonClinica.Checked)
            {
                llenarGridView("3");
                strMotivoConsulta = "EC";
            }
            else
            {
                dgvGrilla.DataSource = null;
            }
        }

        private void botonConsultorio_CheckedChanged(object sender, EventArgs e)
        {
            if (botonConsultorio.Checked)
            {
                llenarGridView("4");
                strMotivoConsulta = "CO";
            }
            else
            {
                dgvGrilla.DataSource = null;
            }
        }

        private void botonRepeticion_CheckedChanged(object sender, EventArgs e)
        {
            if (botonRepeticion.Checked)
            {
                llenarGridView("5");
                strMotivoConsulta = "R";
            }
            else
            {
                dgvGrilla.DataSource = null;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarGridView(txtBuscar.Text);
        }

        private void frmMesaSelecTipoExamen_Load(object sender, EventArgs e)
        {
            //BuscarGridView(txtBuscar.Text);
            switch (strMotivoConsulta)
            {
                case "P":
                    botonLaboral.Enabled = false;
                    botonPreventiva.Checked = true;
                    break;
                case "L":
                    botonPreventiva.Enabled = false;
                    botonLaboral.Checked = true;
                    break;
            }
        }

        private void IDTipoDeExamen(int intRowIndex)
        {
            strResultado = dgvGrilla.Rows[intRowIndex].Cells[1].Value.ToString();
            strResultadoID = dgvGrilla.Rows[intRowIndex].Cells[0].Value.ToString();
        }

        public string NombreTipoExamen()
        {
            return strResultado;
        }

        private string TipoExamenID()
        {
            return strResultadoID;
        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1))
            {
                IDTipoDeExamen(e.RowIndex);
            }
        }

        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                IDTipoDeExamen(e.RowIndex);
            }

            botAceptar.PerformClick();
        }

        private void invalidarConsulta()
        {            
            try
            {
                exPreventiva = new ExamenPreventiva();
                exPreventiva.eliminarExamen(strIdTipoExamen, strIdConsulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Elimine manualmente el ingreso duplicado. Error:\n\n" + ex.ToString(),
                        "Eliminar Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}