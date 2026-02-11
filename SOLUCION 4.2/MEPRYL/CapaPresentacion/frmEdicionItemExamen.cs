using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmEdicionItemExamen : Form
    {
        public string Codigo { get => txtCodigo.Text; set => txtCodigo.Text = value; }
        public string NombreCompleto { get => txtNombreCompleto.Text; set => txtNombreCompleto.Text = value; }
        public string NombreInformes { get => txtNombreInforme.Text; set => txtNombreInforme.Text = value; }
        public string Seccion { get => cboSeccion.Text; set => cboSeccion.Text = value; }
        public string Subseccion { get => cboSubseccion.Text; set => cboSubseccion.Text = value; }

        public frmEdicionItemExamen()
        {
            InitializeComponent();
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterParent;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            this.Load += FrmEdicionItemExamen_Load;
        }

        private void FrmEdicionItemExamen_Load(object sender, EventArgs e)
        {
            // Establecer tamaño fijo para que se vea el botón Guardar
            this.Width = 1000;
            this.Height = 150;

            // Poblar Seccion con valores únicos
            DataTable dtSecciones = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT DISTINCT Seccion FROM SeccionSubseccion ORDER BY Seccion");
            cboSeccion.Items.Clear();
            foreach (DataRow row in dtSecciones.Rows)
            {
                cboSeccion.Items.Add(row["Seccion"].ToString());
            }
            cboSeccion.SelectedIndexChanged += CboSeccion_SelectedIndexChanged;
        }

        private void CboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Poblar Subseccion con valores únicos para la sección seleccionada
            string seccion = cboSeccion.Text;
            if (!string.IsNullOrEmpty(seccion))
            {
                DataTable dtSubsecciones = Comunes.SQLConnector.obtenerTablaSegunConsultaString($"SELECT DISTINCT Subseccion FROM SeccionSubseccion WHERE Seccion = '{seccion}' ORDER BY Subseccion");
                cboSubseccion.Items.Clear();
                foreach (DataRow row in dtSubsecciones.Rows)
                {
                    cboSubseccion.Items.Add(row["Subseccion"].ToString());
                }
            }
        }

        public event EventHandler GuardarClick;
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarClick?.Invoke(this, EventArgs.Empty);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Selecciona automáticamente la sección y subsección en los ComboBox.
        /// Debe llamarse después de crear el formulario y antes de mostrarlo.
        /// </summary>
        public void SeleccionarSeccionYSubseccion(string seccion, string subseccion)
        {
            // Selecciona la sección ignorando mayúsculas/minúsculas y espacios
            int seccionIndex = -1;
            for (int i = 0; i < cboSeccion.Items.Count; i++)
            {
                if (cboSeccion.Items[i].ToString().Trim().ToUpper() == seccion.Trim().ToUpper())
                {
                    seccionIndex = i;
                    break;
                }
            }
            cboSeccion.SelectedIndex = seccionIndex;

            // Dispara el evento para poblar subsecciones
            CboSeccion_SelectedIndexChanged(cboSeccion, EventArgs.Empty);

            // Selecciona la subsección ignorando mayúsculas/minúsculas y espacios
            int subseccionIndex = -1;
            for (int i = 0; i < cboSubseccion.Items.Count; i++)
            {
                if (cboSubseccion.Items[i].ToString().Trim().ToUpper() == subseccion.Trim().ToUpper())
                {
                    subseccionIndex = i;
                    break;
                }
            }
            cboSubseccion.SelectedIndex = subseccionIndex;
        }
    }
}
