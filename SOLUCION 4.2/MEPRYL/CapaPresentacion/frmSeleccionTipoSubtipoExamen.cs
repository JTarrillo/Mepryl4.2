using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmSeleccionTipoSubtipoExamen : Form
    {
        public delegate void DelegateSeleccionSubtipo(string idSubtipo, string descripcionSubtipo);
        public DelegateSeleccionSubtipo objDelegateSeleccionSubtipo;

        public delegate void DelegateBuscarPaciente(string idSubtipo, string descripcionSubtipo);
        public DelegateBuscarPaciente objDelegateBuscarPaciente;

        private string _idMotivoConsulta;
        private MesaEntrada _mesaEntrada;
        private string _idSubtipoSeleccionado;
        private string _descripcionSubtipoSeleccionado;

        public frmSeleccionTipoSubtipoExamen(string idMotivoConsulta)
        {
            InitializeComponent();
            _idMotivoConsulta = idMotivoConsulta;
            _mesaEntrada = new MesaEntrada();
        }

        public frmSeleccionTipoSubtipoExamen(string idMotivoConsulta, Image imagenCancelar, Image imagenBuscarPaciente) : this(idMotivoConsulta)
        {
            btnCancelar.Image = imagenCancelar;
            btnBuscarPaciente.Image = imagenBuscarPaciente;
        }

        private void frmSeleccionTipoSubtipoExamen_Load(object sender, EventArgs e)
        {
            CargarTiposPadre();
        }

        private void CargarTiposPadre()
        {
            DataTable dt = _mesaEntrada.cargarTiposDeExamen(_idMotivoConsulta);
            cbTipoPadre.DataSource = dt;
            cbTipoPadre.ValueMember = "id";
            cbTipoPadre.DisplayMember = "descripcion";
            cbTipoPadre.SelectedIndex = -1;
            cbSubtipo.DataSource = null;
        }

        private void cbTipoPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPadre.SelectedIndex != -1 && cbTipoPadre.SelectedValue != null)
            {
                string idTipoPadre = cbTipoPadre.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(idTipoPadre) && Guid.TryParse(idTipoPadre, out _))
                {
                    CargarSubtipos(idTipoPadre);
                }
            }
        }

        private void CargarSubtipos(string idTipoPadre)
        {
            DataTable dt = _mesaEntrada.cargarSubtiposDeTipoPadre(idTipoPadre);
            cbSubtipo.DataSource = dt;
            cbSubtipo.ValueMember = "id";
            cbSubtipo.DisplayMember = "descripcion";
            cbSubtipo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbTipoPadre.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Examen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbSubtipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Subtipo de Examen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _idSubtipoSeleccionado = cbSubtipo.SelectedValue.ToString();
            _descripcionSubtipoSeleccionado = cbSubtipo.Text;

            objDelegateSeleccionSubtipo?.Invoke(_idSubtipoSeleccionado, _descripcionSubtipoSeleccionado);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (cbTipoPadre.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Examen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbSubtipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Subtipo de Examen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _idSubtipoSeleccionado = cbSubtipo.SelectedValue.ToString();
            _descripcionSubtipoSeleccionado = cbSubtipo.Text;

            objDelegateBuscarPaciente?.Invoke(_idSubtipoSeleccionado, _descripcionSubtipoSeleccionado);
        }
    }
}
