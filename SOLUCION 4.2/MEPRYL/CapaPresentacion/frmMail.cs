using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CapaNegocioMepryl;
using Entidades;

namespace CapaPresentacion
{
    public partial class frmMail : Form
    {
        private static frmMail instancia;
        private static Entidades.Mail tipoMail;
        private static List<Guid> idsTipoExamen;

        public delegate void DelegateDevolverResultadoEnvio(bool resultado, List<Guid> lista);
        public DelegateDevolverResultadoEnvio objDelegateDevolverResultadoEnvio = null;

        public static frmMail GetForm()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmMail();
                tipoMail = new Entidades.Mail();
                idsTipoExamen = new List<Guid>();
            }
            return instancia;
        }

        public frmMail()
        {
            InitializeComponent();
        }

        public void mostrar(Form frm)
        {
            this.MdiParent = frm;
            this.Show();
            this.Focus();
        }

        public void agregarIdTipoExamen(Guid idTipoExamen)
        {
            idsTipoExamen.Add(idTipoExamen);
        }


        public void setearAsunto(string texto)
        {
            tbAsunto.Text = texto;
        }

        public void setearMensaje(string texto)
        {
            tbMensaje.Text = texto;
        }

        public void archivosAdjuntos(List<string> a)
        {
            agregarArchivosAdjuntos(a);
        }

        public void direccionesMail(List<string> a)
        {
            agregarDireccionesDeMail(a);
        }

        public void mailLaboral()
        {
            tipoMail.Cuenta = "laboral@mepryl.com.ar";
            tipoMail.Contraseña = "M123_laboral";
            tipoMail.TextoCuenta = "Centro Médico Mepryl. Departamento Medicina Laboral";
        }

        public void mailPreventiva()
        {
            tipoMail.Cuenta = "resultados@mepryl.com.ar";
            tipoMail.Contraseña = "M123_resultados";
            tipoMail.TextoCuenta = "Centro Médico Mepryl. Departamento Medicina Preventiva";
        }

        private void agregarDireccionesDeMail(List<string> a)
        {
            foreach (string direccionMail in a)
            {
                if (!existeEnDgv(dgvDestinatarios, direccionMail))
                {
                    dgvDestinatarios.Rows.Add(direccionMail);
                }
            }
        }

        private void agregarArchivosAdjuntos(List<string> a)
        {
            foreach (string rutaArchivo in a)
            {
                if (!existeEnDgv(dgvArchivosAdjuntos, rutaArchivo))
                {
                    agregarArchivoAdjunto(rutaArchivo);
                }
            }
        }

        private bool existeEnDgv(DataGridView dgv, string valor)
        {
            foreach (DataGridViewRow dgvR in dgv.Rows)
            {
                if (dgvR.Cells[0].Value.ToString() == valor)
                {
                    return true;
                }
            }
            return false;
        }

        private void agregarArchivoAdjunto(string ruta)
        {
            dgvArchivosAdjuntos.Rows.Add(ruta);
        }

        private void botAddDestinatario_Click(object sender, EventArgs e)
        {
            if(validarDestinatario())
            {
                agregarDestinatario();
            }
            else
            {
                MessageBox.Show("El mail ingresado no es válido. Por favor verifique","Mail Inválido",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void agregarDestinatario()
        {
            dgvDestinatarios.Rows.Add(tbDestinatario.Text);
            tbDestinatario.Clear();
        }

        private bool validarDestinatario()
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(tbDestinatario.Text, expresion))
            {
                if (Regex.Replace(tbDestinatario.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void tbDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { botAddDestinatario.PerformClick(); }
        }

        private void dgvDestinatarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1){ eliminarDestinatario(e.RowIndex);}
        }

        private void eliminarDestinatario(int row)
        {
            dgvDestinatarios.Rows.RemoveAt(row);
        }

        private void dgvArchivosAdjuntos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1) { eliminarArchivoAdjunto(e.RowIndex); }
        }

        private void eliminarArchivoAdjunto(int row)
        {
            dgvArchivosAdjuntos.Rows.RemoveAt(row);
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario();
        }

        private void cerrarFormulario()
        {
            this.Close();
        }

        private void botAddArchivoAdjunto_Click(object sender, EventArgs e)
        {
            abrirOpenFileDialog();
        }

        private void abrirOpenFileDialog()
        {
            openFileDialog.ShowDialog();
            if (openFileDialog.CheckFileExists)
            {
                agregarArchivoAdjunto(openFileDialog.FileName);
            }
        }

        private void botEnviar_Click(object sender, EventArgs e)
        {
            prepararEnvioMail();
        }

        private void prepararEnvioMail()
        {
            if (comprobarDestinatarios() && comprobarAsunto())
            {
                enviarMail();
            }
        }

        private bool comprobarDestinatarios()
        {
            if (dgvDestinatarios.Rows.Count > 0) { return true; }
            MessageBox.Show("No se puede enviar el mail. ¡Por favor ingrese destinatarios!",
                "Error al enviar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private bool comprobarAsunto()
        {
            if (tbAsunto.Text.Length == 0)
            {
                DialogResult result = MessageBox.Show("Se está a punto de enviar un mail sin asunto. ¿Desea continuar?",
                    "Enviar mail sin asunto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { return true; }
                return false;
            }
            return true;
        }

        private void enviarMail()
        {
            CapaNegocioMepryl.Mail enviador = new CapaNegocioMepryl.Mail();
            Entidades.Mail mail = new Entidades.Mail();
            mail.Adjuntos = obtenerAdjuntos();
            mail.Destinatarios = obtenerDestinatarios();
            mail.Asunto = tbAsunto.Text;
            mail.Cuerpo = tbMensaje.Text;
            mail.Host = "mail.mepryl.com.ar";
            mail.Cuenta = tipoMail.Cuenta;
            mail.Contraseña = tipoMail.Contraseña;
            mail.TextoCuenta = tipoMail.TextoCuenta;            
            Cursor.Current = Cursors.WaitCursor;
            enviador.enviarMail(mail);
            Cursor.Current = Cursors.Default;
            if (mail.Error == -1)
            {
                MessageBox.Show(mail.MensajeError, "Error al enviar mail",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (objDelegateDevolverResultadoEnvio != null)
                {
                    objDelegateDevolverResultadoEnvio(false, idsTipoExamen);
                }
            }
            else
            {
                MessageBox.Show("Mail enviado correctamente", "Envio mail",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (objDelegateDevolverResultadoEnvio != null)
                {
                    objDelegateDevolverResultadoEnvio(true, idsTipoExamen);
                }
                botCancelar.PerformClick();
            }
        }

        private List<string> obtenerAdjuntos()
        {
            List<string> retorno = new List<string>();
            foreach (DataGridViewRow r in dgvArchivosAdjuntos.Rows)
            {
                retorno.Add(r.Cells[0].Value.ToString());
            }
            return retorno;
        }

        private List<string> obtenerDestinatarios()
        {
            List<string> retorno = new List<string>();
            foreach (DataGridViewRow r in dgvDestinatarios.Rows)
            {
                retorno.Add(r.Cells[0].Value.ToString());
            }
            return retorno;
        }
 


    }
}
