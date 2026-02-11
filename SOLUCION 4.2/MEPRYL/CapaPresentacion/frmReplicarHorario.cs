using System;
using System.Data;
using System.Windows.Forms;
using Comunes;
namespace CapaPresentacion
{
    public partial class frmReplicarHorario : Form
    {
        public frmReplicarHorario()
        {
            InitializeComponent();
            CargarProfesionales();
        }

        private void CargarProfesionales()
        {
            // Puedes ajustar la consulta según tu modelo de datos
            string sql = "SELECT id AS profesionalID, apellido + ' ' + nombres AS profesionalTexto FROM Profesional ORDER BY apellido, nombres";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);
            cmbProfesional.DataSource = dt;
            cmbProfesional.DisplayMember = "profesionalTexto";
            cmbProfesional.ValueMember = "profesionalID";
            cmbProfesional.SelectedIndex = -1;
        }

        private void btnReplicar_Click(object sender, EventArgs e)
        {
            DateTime origenDesde = dtpOrigenDesde.Value.Date;
            DateTime origenHasta = dtpOrigenHasta.Value.Date;
            DateTime destinoDesde = dtpDestinoDesde.Value.Date;
            DateTime destinoHasta = dtpDestinoHasta.Value.Date;

            // Validar selección de profesional
            if (cmbProfesional.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un profesional.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string profesionalID = cmbProfesional.SelectedValue.ToString();

            // 1. Buscar horarios existentes en el rango origen
            string sql = $@"
                SELECT * FROM v_Horario
                WHERE profesionalID = '{profesionalID}'
                  AND fechaDesde >= '{origenDesde:yyyy-MM-dd}'
                  AND fechaHasta <= '{origenHasta:yyyy-MM-dd}'";

            DataTable horarios = SQLConnector.obtenerTablaSegunConsultaString(sql);

            if (horarios.Rows.Count == 0)
            {
                MessageBox.Show("No hay horarios en el período seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataRow row in horarios.Rows)
            {
                string insertSql = $@"
                    INSERT INTO Horario (
                        profesionalTexto, especialidadTexto, fechaDesde, fechaHasta, diasSimplificado,
                        horaDesde, horaHasta, citarCada, pacientesGrupo, cantidadTurnos, codigo,
                        profesionalID, especialidadID, domingo, lunes, martes, miercoles, jueves, viernes, sabado,
                        observaciones, registroBLOB, id
                    )
                    VALUES (
                        '{row["profesionalTexto"]}', '{row["especialidadTexto"]}',
                        '{destinoDesde:yyyy-MM-dd}', '{destinoHasta:yyyy-MM-dd}', '{row["diasSimplificado"]}',
                        '{row["horaDesde"]}', '{row["horaHasta"]}', {row["citarCada"]}, {row["pacientesGrupo"]}, {row["cantidadTurnos"]}, {row["codigo"]},
                        '{row["profesionalID"]}', '{row["especialidadID"]}', {Convert.ToInt32(row["domingo"])} , {Convert.ToInt32(row["lunes"])} , {Convert.ToInt32(row["martes"])} ,
                        {Convert.ToInt32(row["miercoles"])} , {Convert.ToInt32(row["jueves"])} , {Convert.ToInt32(row["viernes"])} , {Convert.ToInt32(row["sabado"])} ,
                        '{row["observaciones"]}', '{row["registroBLOB"]}', NEWID()
                    )";
                SQLConnector.EjecutarConsulta(insertSql);
            }

            MessageBox.Show("Horarios replicados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}