using System;
using System.Collections.Generic;
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
            try
            {
                string sql = "SELECT id AS profesionalID, apellido + ' ' + nombres AS profesionalTexto FROM Profesional ORDER BY apellido, nombres";
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);

                if (dt.Rows.Count > 0)
                {
                    cmbProfesional.DataSource = dt;
                    cmbProfesional.DisplayMember = "profesionalTexto";
                    cmbProfesional.ValueMember = "profesionalID";
                    cmbProfesional.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar profesionales: {ex.Message}");
                MessageBox.Show("Error al cargar profesionales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReplicar_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validaciones
                if (!ValidarEntradas())
                    return;

                DateTime origenDesde = dtpOrigenDesde.Value.Date;
                DateTime origenHasta = dtpOrigenHasta.Value.Date;
                DateTime destinoDesde = dtpDestinoDesde.Value.Date;
                DateTime destinoHasta = dtpDestinoHasta.Value.Date;
                string profesionalID = cmbProfesional.SelectedValue.ToString();

                // ✅ Confirmación del usuario
                DialogResult result = MessageBox.Show(
                    $"¿Desea replicar los horarios?\n\n" +
                    $"Profesional: {cmbProfesional.Text}\n" +
                    $"Período Origen: {origenDesde:dd/MM/yyyy} - {origenHasta:dd/MM/yyyy}\n" +
                    $"Período Destino: {destinoDesde:dd/MM/yyyy} - {destinoHasta:dd/MM/yyyy}",
                    "Confirmar Replicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // ✅ Obtener horarios del período origen
                DataTable horarios = ObtenerHorarios(profesionalID, origenDesde, origenHasta);

                if (horarios.Rows.Count == 0)
                {
                    MessageBox.Show("No hay horarios en el período seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ✅ Verificar si existen horarios en el período destino
                DataTable horariosExistentes = ObtenerHorarios(profesionalID, destinoDesde, destinoHasta);

                if (horariosExistentes.Rows.Count > 0)
                {
                    DialogResult resultDelete = MessageBox.Show(
                        $"Ya existen {horariosExistentes.Rows.Count} horarios en el período destino.\n\n¿Desea eliminarlos antes de replicar?",
                        "Horarios Existentes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (resultDelete == DialogResult.Cancel)
                        return;

                    if (resultDelete == DialogResult.Yes)
                    {
                        EliminarHorarios(profesionalID, destinoDesde, destinoHasta);
                    }
                }

                // ✅ Replicar horarios
                int cantidadReplicada = ReplicarHorarios(horarios, destinoDesde, destinoHasta, profesionalID);

                MessageBox.Show(
                    $"✅ Replicación completada exitosamente.\n\n{cantidadReplicada} horarios replicados.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en btnReplicar_Click: {ex.Message}");
                MessageBox.Show("Error al replicar horarios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarEntradas()
        {
            if (cmbProfesional.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un profesional.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProfesional.Focus();
                return false;
            }

            if (dtpOrigenDesde.Value >= dtpOrigenHasta.Value)
            {
                MessageBox.Show("La fecha 'Origen Desde' debe ser anterior a 'Origen Hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDestinoDesde.Value >= dtpDestinoHasta.Value)
            {
                MessageBox.Show("La fecha 'Destino Desde' debe ser anterior a 'Destino Hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDestinoDesde.Value <= dtpOrigenHasta.Value)
            {
                MessageBox.Show("El período destino debe ser posterior al período origen para evitar solapamientos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private DataTable ObtenerHorarios(string profesionalID, DateTime desde, DateTime hasta)
        {
            try
            {
                // ✅ Usar v_Horario para obtener datos con profesionalTexto y especialidadTexto calculados
                string sql = $@"
                    SELECT *
                    FROM v_Horario
                    WHERE profesionalID = '{profesionalID}'
                      AND CONVERT(DATE, fechaDesde) >= '{desde:yyyy-MM-dd}'
                      AND CONVERT(DATE, fechaHasta) <= '{hasta:yyyy-MM-dd}'
                    ORDER BY fechaDesde";

                System.Diagnostics.Debug.WriteLine($"[DEBUG] ObtenerHorarios SQL: {sql}");
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);

                // ✅ Validar que dt no sea null antes de acceder a Rows
                if (dt != null)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] ObtenerHorarios: Se encontraron {dt.Rows.Count} horarios");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] ObtenerHorarios: SQLConnector retornó null");
                    dt = new DataTable(); // Crear tabla vacía
                }

                return dt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en ObtenerHorarios: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        private int ReplicarHorarios(DataTable horarios, DateTime destinoDesde, DateTime destinoHasta, string profesionalID)
        {
            int cantidadReplicada = 0;

            try
            {
                foreach (DataRow row in horarios.Rows)
                {
                    try
                    {
                        // ✅ Manejo seguro de NULL values
                        string codigo = row["codigo"] != DBNull.Value ? row["codigo"].ToString().Replace("'", "''") : "";
                        string diasSimplificado = row["diasSimplificado"] != DBNull.Value ? row["diasSimplificado"].ToString().Replace("'", "''") : "";
                        string horaDesde = row["horaDesde"] != DBNull.Value ? row["horaDesde"].ToString() : "00:00";
                        string horaHasta = row["horaHasta"] != DBNull.Value ? row["horaHasta"].ToString() : "00:00";
                        int cantidadTurnos = row["cantidadTurnos"] != DBNull.Value ? Convert.ToInt32(row["cantidadTurnos"]) : 0;
                        int citarCada = row["citarCada"] != DBNull.Value ? Convert.ToInt32(row["citarCada"]) : 0;
                        int pacientesGrupo = row["pacientesGrupo"] != DBNull.Value ? Convert.ToInt32(row["pacientesGrupo"]) : 0;
                        string observaciones = row["observaciones"] != DBNull.Value ? row["observaciones"].ToString().Replace("'", "''") : "";
                        string registroBLOB = row["registroBLOB"] != DBNull.Value ? row["registroBLOB"].ToString().Replace("'", "''") : "";

                        string insertSql = $@"
                            INSERT INTO Horario (
                                id, codigo, profesionalID, especialidadID,
                                domingo, lunes, martes, miercoles, jueves, viernes, sabado,
                                diasSimplificado, horaDesde, horaHasta, cantidadTurnos, citarCada, pacientesGrupo,
                                fechaDesde, fechaHasta, observaciones, registroBLOB,
                                actualizacion_local, operacion_local, sincronizado, serverID
                            )
                            VALUES (
                                NEWID(), '{codigo}', '{row["profesionalID"]}', '{row["especialidadID"]}',
                                {Convert.ToInt32(row["domingo"])}, {Convert.ToInt32(row["lunes"])}, {Convert.ToInt32(row["martes"])},
                                {Convert.ToInt32(row["miercoles"])}, {Convert.ToInt32(row["jueves"])}, {Convert.ToInt32(row["viernes"])}, {Convert.ToInt32(row["sabado"])},
                                '{diasSimplificado}', '{horaDesde}', '{horaHasta}', {cantidadTurnos}, {citarCada}, {pacientesGrupo},
                                CONVERT(DATE, '{destinoDesde:yyyy-MM-dd}'), CONVERT(DATE, '{destinoHasta:yyyy-MM-dd}'), '{observaciones}', '{registroBLOB}',
                                GETDATE(), 'I', NULL, NULL
                            )";

                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Replicando horario SQL:\n{insertSql}");
                        SQLConnector.EjecutarConsulta(insertSql);
                        cantidadReplicada++;
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] ✅ Horario replicado correctamente");
                    }
                    catch (System.Data.SqlClient.SqlException sqlEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] ❌ SqlException: {sqlEx.Message}");
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] SqlException Line: {sqlEx.LineNumber}");
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] SqlException Number: {sqlEx.Number}");
                        foreach (System.Data.SqlClient.SqlError error in sqlEx.Errors)
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUG] Error: {error.Message}");
                        }
                    }
                    catch (Exception exRow)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] ❌ Error al replicar fila: {exRow.GetType().Name} - {exRow.Message}");
                        if (exRow.InnerException != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUG] InnerException: {exRow.InnerException.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Error en ReplicarHorarios: {ex.Message}");
                throw;
            }

            return cantidadReplicada;
        }

        private void EliminarHorarios(string profesionalID, DateTime desde, DateTime hasta)
        {
            try
            {
                string deleteSql = $@"
                    DELETE FROM Horario
                    WHERE profesionalID = '{profesionalID}'
                      AND fechaDesde >= '{desde:yyyy-MM-dd}'
                      AND fechaHasta <= '{hasta:yyyy-MM-dd}'";

                SQLConnector.EjecutarConsulta(deleteSql);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en EliminarHorarios: {ex.Message}");
                throw;
            }
        }
    }
}