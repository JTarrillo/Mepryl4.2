using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmMesaSelecSubtipoExamen : Form
    {
        private string _strMotivoConsulta;
        private string _strIdPaciente;
        private string _strIdEmpresa;
        private string _strIdTurno;
        private string _strIdTipoExamen;
        private string _strIdConsulta;
        private string _strTipoConsulta;
        private string _idEspecialidadActual;
        private string _idEspecialidadOriginal;

        private MesaEntrada _mesaEntrada;

        public frmMesaSelecSubtipoExamen(string MotivoConsulta, string IdPaciente, string IdEmpresa, string IdTurno, string IdTipoExamen, string IdConsulta, string TipoConsulta)
        {
            InitializeComponent();
            _strMotivoConsulta = MotivoConsulta;
            _strIdPaciente = IdPaciente;
            _strIdEmpresa = IdEmpresa;
            _strIdTurno = IdTurno;
            _strIdTipoExamen = IdTipoExamen;
            _strIdConsulta = IdConsulta;
            _strTipoConsulta = TipoConsulta;
            _mesaEntrada = new MesaEntrada();
        }

        private void frmMesaSelecSubtipoExamen_Load(object sender, EventArgs e)
        {
            DataTable dtInfo = _mesaEntrada.obtenerInfoEspecialidad(_strIdTipoExamen);
            if (dtInfo == null || dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("No se pudo obtener la información del tipo de examen para el ID: " + _strIdTipoExamen, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idEspecialidad = dtInfo.Rows[0]["idEspecialidad"].ToString();
            string idPadre = dtInfo.Rows[0]["idPadre"].ToString();
            string idMotivoConsulta = dtInfo.Rows[0]["idMotivoConsulta"].ToString();

            DataTable dtTipos = _mesaEntrada.cargarTiposDeExamen(idMotivoConsulta);
            
            // SIEMPRE establecer ValueMember y DisplayMember ANTES del DataSource
            cbTipoPadre.ValueMember = "id";
            cbTipoPadre.DisplayMember = "descripcion";
            cbTipoPadre.DataSource = dtTipos;
            
            _idEspecialidadOriginal = idEspecialidad;
            _idEspecialidadActual = idEspecialidad;

            // Pre-seleccionar el padre actual (dispara SelectedIndexChanged que carga cbSubtipo)
            if (!string.IsNullOrEmpty(idPadre))
            {
                if (Guid.TryParse(idPadre, out Guid guidPadre))
                {
                    cbTipoPadre.SelectedValue = guidPadre;
                    // Fallback si no seleccionó por Guid (a veces el DataSource tiene strings)
                    if (cbTipoPadre.SelectedValue == null || (Guid)cbTipoPadre.SelectedValue != guidPadre)
                    {
                        cbTipoPadre.SelectedValue = idPadre;
                    }
                }
                else
                {
                    cbTipoPadre.SelectedValue = idPadre;
                }
                
                // Forzar la pre-selección del subtipo si ya se cargó en el SelectedIndexChanged
                if (cbSubtipo.DataSource != null)
                {
                    PreseleccionarSubtipo(_idEspecialidadOriginal);
                }
            }
        }

        private void PreseleccionarSubtipo(string idSubtipo)
        {
            if (string.IsNullOrEmpty(idSubtipo)) return;

            if (Guid.TryParse(idSubtipo, out Guid guidSub))
            {
                cbSubtipo.SelectedValue = guidSub;
                if (cbSubtipo.SelectedValue == null || (Guid)cbSubtipo.SelectedValue != guidSub)
                {
                    cbSubtipo.SelectedValue = idSubtipo;
                }
            }
            else
            {
                cbSubtipo.SelectedValue = idSubtipo;
            }
        }

        private void cbTipoPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPadre.SelectedIndex == -1 || cbTipoPadre.SelectedValue == null) return;
            
            string idPadre = "";
            if (cbTipoPadre.SelectedValue is Guid guid)
                idPadre = guid.ToString();
            else if (cbTipoPadre.SelectedValue is DataRowView drv)
                idPadre = drv["id"].ToString();
            else
                idPadre = cbTipoPadre.SelectedValue.ToString();

            if (!Guid.TryParse(idPadre, out _)) return;

            DataTable dtSubtipos = _mesaEntrada.cargarSubtiposDeTipoPadre(idPadre);
            
            cbSubtipo.ValueMember = "id";
            cbSubtipo.DisplayMember = "descripcion";
            cbSubtipo.DataSource = dtSubtipos;

            // Si es la carga inicial, pre-seleccionar el subtipo original
            if (_idEspecialidadActual != null)
            {
                PreseleccionarSubtipo(_idEspecialidadActual);
                _idEspecialidadActual = null; // Solo la primera vez
            }
            else
            {
                cbSubtipo.SelectedIndex = -1;
            }
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            if (cbTipoPadre.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Examen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbSubtipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Subtipo de Examen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string idSubtipo = cbSubtipo.SelectedValue.ToString();
            string nombreSubtipo = cbSubtipo.Text;

            // Si no hubo cambio, cerrar sin hacer nada
            if (string.Equals(idSubtipo, _idEspecialidadOriginal, StringComparison.OrdinalIgnoreCase))
            {
                this.Close();
                return;
            }

            if (_strMotivoConsulta == _strTipoConsulta)
            {
                _mesaEntrada.ActualizaTipoExamenIDTipoExamen(_strIdTipoExamen, idSubtipo);
            }
            else
            {
                frmMesaDeEntrada frmMesaEntrada = new frmMesaDeEntrada();
                frmMesaEntrada.CambiarTipoExamen(nombreSubtipo, _strMotivoConsulta, _strIdPaciente, _strIdEmpresa, _strIdTurno, _strIdConsulta, idSubtipo);
            }

            this.Close();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
