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
                MessageBox.Show("No se pudo obtener la información del tipo de examen.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idEspecialidad = dtInfo.Rows[0]["idEspecialidad"].ToString();
            string idPadre = dtInfo.Rows[0]["idPadre"].ToString();
            string idMotivoConsulta = dtInfo.Rows[0]["idMotivoConsulta"].ToString();

            DataTable dtTipos = _mesaEntrada.cargarTiposDeExamen(idMotivoConsulta);
            cbTipoPadre.DataSource = dtTipos;
            cbTipoPadre.ValueMember = "id";
            cbTipoPadre.DisplayMember = "descripcion";
            cbTipoPadre.SelectedIndex = -1;

            // Asignar DESPUÉS del binding para que el SelectedIndexChanged disparado por DataSource
            // no consuma _idEspecialidadActual prematuramente con el primer item
            _idEspecialidadActual = idEspecialidad;

            // Pre-seleccionar el padre actual (dispara SelectedIndexChanged que carga cbSubtipo)
            if (Guid.TryParse(idPadre, out Guid guidPadre))
                cbTipoPadre.SelectedValue = guidPadre;
        }

        private void cbTipoPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPadre.SelectedIndex == -1 || cbTipoPadre.SelectedValue == null) return;
            string idPadre = cbTipoPadre.SelectedValue.ToString();
            if (!Guid.TryParse(idPadre, out _)) return;

            DataTable dtSubtipos = _mesaEntrada.cargarSubtiposDeTipoPadre(idPadre);
            cbSubtipo.DataSource = dtSubtipos;
            cbSubtipo.ValueMember = "id";
            cbSubtipo.DisplayMember = "descripcion";
            cbSubtipo.SelectedIndex = -1;

            // Pre-seleccionar subtipo actual (solo en la carga inicial)
            if (!string.IsNullOrEmpty(_idEspecialidadActual))
            {
                if (Guid.TryParse(_idEspecialidadActual, out Guid guidSubtipo))
                    cbSubtipo.SelectedValue = guidSubtipo;
                _idEspecialidadActual = null;
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

            if (_strMotivoConsulta == _strTipoConsulta)
            {
                _mesaEntrada.ActualizaTipoExamenIDConsulta(_strIdConsulta, idSubtipo);
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
