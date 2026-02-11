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
    public partial class frmExamen : DevExpress.XtraEditors.XtraForm
    {
        public string idExamen;
        public string idPaciente;
        bool modoEdicion;
        public frmExamen(string idEx, string idPac, bool mod)
        {
            InitializeComponent();
            this.idExamen = idEx;
            this.idPaciente = idPac;
            this.modoEdicion = mod;
            cargarFormulario();
        }

        private void cargarFormulario()
        {

            if (this.modoEdicion)
            {
                DataTable examen;
                examen = SQLConnector.obtenerTablaSegunConsultaString(@"select convert(date,e.fecha) as Fecha, e.orden as 'Nº Orden', p.id as IdPaciente, p.apellido as Apellido, 
                p.nombres as Nombre, p.dni as DNI from Examen e inner join Paciente p on 
                e.pacienteId = p.id where e.id = '" + idExamen.ToString() + "'");
                DateTime fecha = (DateTime)examen.Rows[0].ItemArray[0];
                lblFecha.Text = fecha.Date.ToShortDateString();
                lblOrden.Text = examen.Rows[0].ItemArray[1].ToString();
                lblDni.Text = examen.Rows[0].ItemArray[5].ToString();
                lblNombre.Text = examen.Rows[0].ItemArray[3].ToString() + " " + examen.Rows[0].ItemArray[4].ToString();
                MessageBox.Show(idExamen);
                DataTable clubesPorExamen;
                clubesPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select ce.id as Id, l.id as IdLiga, l.descripcion as Liga, c.id as IdClub, c.descripcion as Club from DataSmSTurnos_Test.dbo.ClubPorExamen ce 
                inner join DataSmSTurnos_Test.dbo.Club c on ce.idClub = c.id inner join DataSmSTurnos_Test.dbo.Liga l on c.ligaID = l.id where ce.idExamen = '" + this.idExamen + "'");
                dgvClubes.DataSource = clubesPorExamen;
                dgvClubes.Columns[0].Visible = false;
                dgvClubes.Columns[1].Visible = false;
                dgvClubes.Columns[3].Visible = false;
                this.ActiveControl = lblDni;
                lblDni.Focus();
            }
            else
            {
                DataTable paciente;
                paciente = SQLConnector.obtenerTablaSegunConsultaString("select p.apellido, p.nombres, p.dni from Paciente p where p.id = '" + idPaciente.ToString() + "'");
                lblFecha.Text = DateTime.Today.Date.ToShortDateString();
                lblOrden.Text = "200";
                lblNombre.Text = paciente.Rows[0].ItemArray[0].ToString() + " " + paciente.Rows[0].ItemArray[1].ToString();
                lblDni.Text = paciente.Rows[0].ItemArray[2].ToString();
                DataTable clubes;
                clubes = SQLConnector.obtenerTablaSegunConsultaString(@"select l.id as IdLiga, l.descripcion as Liga, c.id as IdClub, c.descripcion as Club from clubesPorPaciente cp inner join Club c on cp.club = c.id
                inner join .Liga l on c.ligaID = l.id where cp.paciente = '" + idPaciente.ToString() + "'");
                dgvClubes.DataSource = clubes;
                dgvClubes.Columns[0].Visible = false;
                dgvClubes.Columns[2].Visible = false;
            }
        }

        private void botonExamenFisico_Click(object sender, EventArgs e)
        {
                  
            //Form examenFisico = new frmExamenFisico();
            //Utilidades.abrirFormulario(this.MdiParent, examenFisico, new Configuracion());
        
        }

        private void botonLab_Click(object sender, EventArgs e)
        {
           // Form examenLab = new frmExamenLaboratorio();
            //Utilidades.abrirFormulario(this.MdiParent, examenLab, new Configuracion());
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
            }
            else
            {
                string idExamen =  SQLConnector.executeProcedureWithReturnValue("sp_Examen_Add", SQLConnector.generarListaParaProcedure("@fecha", "@orden", "@pacienteId"), Convert.ToDateTime(lblFecha.Text), Convert.ToInt16(lblOrden.Text), this.idPaciente);
                foreach (DataGridViewRow row in dgvClubes.Rows)
                {
                    SQLConnector.executeProcedure("sp_ClubPorExamen_Add", SQLConnector.generarListaParaProcedure("@idExamen", "@idClub"), idExamen, row.Cells[2].Value.ToString());
                }
            }
        }

        private void botonRx_Click(object sender, EventArgs e)
        {
           // Form examenRX = new frmRX();
            //Utilidades.abrirFormulario(this.MdiParent, examenRX, new Configuracion());
        }

        private void botonCardiologia_Click(object sender, EventArgs e)
        {
            //Form examenCardiologico = new frmExamenCardiologia();
            //Utilidades.abrirFormulario(this.MdiParent, examenCardiologico, new Configuracion());
        }


 
 

    }
}
