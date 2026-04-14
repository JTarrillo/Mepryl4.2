using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class frmPermisosUsuario : Form
    {
        public Dictionary<string, bool> Permisos { get; private set; }

        private CheckBox chkActivo;
        private CheckBox chkVentanilla, chkMesaEntrada, chkPacientes, chkExamenes;
        private CheckBox chkConfiguracion, chkTurnos, chkResumen, chkAudiometria;
        private CheckBox chkFacturacion;
        private CheckBox chkVer, chkModificar, chkEliminar;
        private Button btnAceptar, btnCancelar;

        public frmPermisosUsuario(string strUsuario, DataRow row, bool blnEsAdmin)
        {
            this.Text = "Permisos - " + strUsuario;
            this.Size = new Size(420, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Microsoft Sans Serif", 9.75F);

            // Estado
            chkActivo = new CheckBox { Text = "Usuario Activo", Location = new Point(20, 15), AutoSize = true };
            chkActivo.Checked = Convert.ToBoolean(row["Activo"]);
            this.Controls.Add(chkActivo);

            // Grupo Acceso a Pantallas
            GroupBox gpbPantallas = new GroupBox
            {
                Text = "Acceso a Pantallas",
                Location = new Point(15, 45),
                Size = new Size(375, 130)
            };

            chkVentanilla = CrearCheck("Ventanilla", 20, 25, row["VentVentanilla"]);
            chkMesaEntrada = CrearCheck("Mesa de Entrada", 20, 50, row["VentMesa"]);
            chkPacientes = CrearCheck("Pacientes", 20, 75, row["VentPacientes"]);
            chkExamenes = CrearCheck("Exámenes", 20, 100, row["VentExamenes"]);
            chkConfiguracion = CrearCheck("Configuración", 190, 25, row["VentConfiguracion"]);
            chkTurnos = CrearCheck("Turnos", 190, 50, row["VentTurnos"]);
            chkResumen = CrearCheck("Planilla del día", 190, 75, row["VentResumen"]);
            chkAudiometria = CrearCheck("Ver Audiometría", 190, 100, row["VentAudiometria"]);

            gpbPantallas.Controls.AddRange(new Control[] {
                chkVentanilla, chkMesaEntrada, chkPacientes, chkExamenes,
                chkConfiguracion, chkTurnos, chkResumen, chkAudiometria
            });
            this.Controls.Add(gpbPantallas);

            // Facturación aparte
            chkFacturacion = CrearCheck("Ver Facturación", 20, 25, row["VentFacturacion"]);
            GroupBox gpbExtra = new GroupBox
            {
                Text = "Otros",
                Location = new Point(15, 180),
                Size = new Size(375, 55)
            };
            gpbExtra.Controls.Add(chkFacturacion);
            this.Controls.Add(gpbExtra);

            // Grupo Permisos
            GroupBox gpbPermisos = new GroupBox
            {
                Text = "Permisos",
                Location = new Point(15, 240),
                Size = new Size(375, 55)
            };

            chkVer = CrearCheck("Ver", 20, 25, row["PermisoVer"]);
            chkModificar = CrearCheck("Modificar", 120, 25, row["PermisoModificar"]);
            chkEliminar = CrearCheck("Eliminar", 250, 25, row["PermisoEliminar"]);

            gpbPermisos.Controls.AddRange(new Control[] { chkVer, chkModificar, chkEliminar });
            this.Controls.Add(gpbPermisos);

            // Botones
            btnAceptar = new Button
            {
                Text = "Guardar",
                DialogResult = DialogResult.OK,
                Location = new Point(110, 310),
                Size = new Size(90, 35),
                Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold)
            };
            btnAceptar.Click += (s, e) => CargarPermisos();

            btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new Point(210, 310),
                Size = new Size(90, 35),
                Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold)
            };

            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;

            // Si no es admin, todo deshabilitado
            if (!blnEsAdmin)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                btnCancelar.Enabled = true;
            }
        }

        private CheckBox CrearCheck(string texto, int x, int y, object valor)
        {
            CheckBox chk = new CheckBox
            {
                Text = texto,
                Location = new Point(x, y),
                AutoSize = true,
                Checked = Convert.ToBoolean(valor)
            };
            return chk;
        }

        private void CargarPermisos()
        {
            Permisos = new Dictionary<string, bool>
            {
                { "Activo", chkActivo.Checked },
                { "VentVentanilla", chkVentanilla.Checked },
                { "VentMesa", chkMesaEntrada.Checked },
                { "VentPacientes", chkPacientes.Checked },
                { "VentExamenes", chkExamenes.Checked },
                { "VentConfiguracion", chkConfiguracion.Checked },
                { "VentTurnos", chkTurnos.Checked },
                { "VentResumen", chkResumen.Checked },
                { "VentAudiometria", chkAudiometria.Checked },
                { "VentFacturacion", chkFacturacion.Checked },
                { "PermisoVer", chkVer.Checked },
                { "PermisoModificar", chkModificar.Checked },
                { "PermisoEliminar", chkEliminar.Checked }
            };
        }
    }
}
