using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmAgregarTipoExamen : Form
    {
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public bool Estado { get; set; }

        public FrmAgregarTipoExamen(string titulo = "Nuevo Tipo Examen")
        {
            InitializeComponent();
            this.Text = titulo;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Crear controles
            System.Windows.Forms.Label lblDescripcion = new System.Windows.Forms.Label();
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new System.Drawing.Point(15, 20);
            lblDescripcion.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(lblDescripcion);

            System.Windows.Forms.TextBox txtDescripcion = new System.Windows.Forms.TextBox();
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Location = new System.Drawing.Point(100, 20);
            txtDescripcion.Size = new System.Drawing.Size(300, 20);
            txtDescripcion.Text = Descripcion;
            this.Controls.Add(txtDescripcion);

            System.Windows.Forms.Label lblPrecio = new System.Windows.Forms.Label();
            lblPrecio.Text = "Precio:";
            lblPrecio.Location = new System.Drawing.Point(15, 60);
            lblPrecio.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(lblPrecio);

            System.Windows.Forms.TextBox txtPrecio = new System.Windows.Forms.TextBox();
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Location = new System.Drawing.Point(100, 60);
            txtPrecio.Size = new System.Drawing.Size(100, 20);
            txtPrecio.Text = Precio.ToString();
            this.Controls.Add(txtPrecio);

            System.Windows.Forms.Label lblEstado = new System.Windows.Forms.Label();
            lblEstado.Text = "Estado:";
            lblEstado.Location = new System.Drawing.Point(15, 100);
            lblEstado.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(lblEstado);

            System.Windows.Forms.CheckBox chkEstado = new System.Windows.Forms.CheckBox();
            chkEstado.Name = "chkEstado";
            chkEstado.Text = "Activo";
            chkEstado.Location = new System.Drawing.Point(100, 100);
            chkEstado.Size = new System.Drawing.Size(80, 20);
            chkEstado.Checked = true; // Default: Activo
            this.Controls.Add(chkEstado);

            System.Windows.Forms.Button btnOK = new System.Windows.Forms.Button();
            btnOK.Text = "Aceptar";
            btnOK.Location = new System.Drawing.Point(150, 140);
            btnOK.Size = new System.Drawing.Size(80, 30);
            btnOK.BackColor = System.Drawing.Color.LightGreen;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Ingrese una descripción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtPrecio.Text, out double precio))
                {
                    MessageBox.Show("Ingrese un precio válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Descripcion = txtDescripcion.Text;
                Precio = precio;
                Estado = chkEstado.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(btnOK);

            System.Windows.Forms.Button btnCancel = new System.Windows.Forms.Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Location = new System.Drawing.Point(240, 140);
            btnCancel.Size = new System.Drawing.Size(80, 30);
            btnCancel.BackColor = System.Drawing.Color.LightCoral;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnCancel);

            this.ClientSize = new System.Drawing.Size(420, 190);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
