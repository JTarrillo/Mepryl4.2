using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmBorrarTurnos : Form
    {
        Configuracion configuracion;
        public frmBorrarTurnos(Configuracion config)
        {
            InitializeComponent();
            this.configuracion = config;

            //Toma el último código de Turno
            tbUltimoCodigoTurno.Text = this.configuracion.obtenerParametro("CODIGO_TURNO").ToString();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
            {
                dtpFechaHasta.Value = dtpFechaDesde.Value.Date;
            }
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaHasta.Value.Date < dtpFechaDesde.Value.Date)
            {
                dtpFechaDesde.Value = dtpFechaHasta.Value.Date;
            }
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            TurnoFactory tf = new TurnoFactory(this.configuracion, "Turno");
            int registros = int.Parse(tf.contarTurnosPorFechas(dtpFechaDesde.Value, dtpFechaHasta.Value));
            if (registros > 0)
            {
                if (MessageBox.Show("Está a punto de borrar permanentemente " + registros.ToString() + " TURNOS comprendidos en el período \n" + dtpFechaDesde.Value.ToShortDateString() + " - " + dtpFechaHasta.Value.ToShortDateString() +
                                    "\n\n\t¿Desea continuar?", "Borrar Turnos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    tf.eliminarTurnosPorFechas(dtpFechaDesde.Value, dtpFechaHasta.Value);
                    MessageBox.Show("Se han eliminado " + registros + "TURNOS de la base de datos.", "Borrar Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("No hay TURNOS para este rango de fechas. \n" + dtpFechaDesde.Value.ToShortDateString() + " - " + dtpFechaHasta.Value.ToShortDateString(), "Borrar Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tf = null;
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            tbUltimoCodigoTurno.Text = tbUltimoCodigoTurno.Text.Trim();
            string codigoActual = this.configuracion.obtenerParametro("CODIGO_TURNO").ToString();
            if (!Utilidades.IsNumeric(tbUltimoCodigoTurno.Text))
                MessageBox.Show("El código debe contener un valor numérico.", "Código Turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Esta a punto de cambiar el Último Código de Turno: " + codigoActual + " por: " + tbUltimoCodigoTurno.Text +
                                   "\n\n\t¿Desea continuar?", "Resetear Último Código de Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.configuracion.guardarParametro("CODIGO_TURNO", int.Parse(tbUltimoCodigoTurno.Text));
                    MessageBox.Show("Ahora el Último Código de Turno es: " + tbUltimoCodigoTurno.Text, "Resetear Último Código de Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}