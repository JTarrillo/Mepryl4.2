using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Comunes;
using System.Data.OleDb;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmImportarJugadores : Form
    {
        int errores;
        private ExamenPreventiva preventiva;

        public frmImportarJugadores()
        {
            InitializeComponent();
            preventiva = new ExamenPreventiva();
        }

        private void frmImportarJugadores_Load(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            progressBar.Visible = false;
            progressBar.Value = 1;
        }

        private void botonCargar_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Excel (.xls)|*.xls";
            DialogResult result = openFileDialog.ShowDialog();
            tbArchivo.Text = openFileDialog.FileName;
  
        }

        private void importar()
        {
            if (DialogResult.OK == MessageBox.Show("¿Desea comenzar la importación de registros del archivo " + openFileDialog.FileName + "?", "Importación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                realizarImportacion();
            }
        }

        private void botonImportar_Click(object sender, EventArgs e)
        {
            if (tbArchivo.Text != "")
            {
                importar();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se cargo la dirección del archivo", "Importar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void realizarImportacion()
        {            
            string myexceldataquery = "select * from [DATOS$]";
  
            try
            {

                string excelConnectionString = @"provider=Microsoft.Jet.OLEDB.4.0;data source=" + tbArchivo.Text + ";Extended Properties=Excel 8.0;";
                OleDbConnection oledbconn = new OleDbConnection(excelConnectionString);
                OleDbDataAdapter da = new OleDbDataAdapter(myexceldataquery, oledbconn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                string fecha = "";
                string nroEx = "";
                string examen = "";
                string dni = "";
                string apellido = "";
                string nombre = "";
                string nacimiento = "";
                string club = "";
                string club2 = ""; // GRV
                string rx = "";
                string telefono = ""; // GRV
                string Celular = ""; // GRV
                string Email = ""; // GRV

                int contadorFilas = ds.Tables[0].Rows.Count;
                progressBar.Visible = true;
                progressBar.Minimum = 1;
                progressBar.Maximum = contadorFilas;
                progressBar.Step = 1;
                int registro = 0;
                errores = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    fecha = row.ItemArray[0].ToString();
                    if (fecha != "")
                    {
                        nroEx = row.ItemArray[1].ToString();
                        examen = row.ItemArray[2].ToString();
                        dni = row.ItemArray[3].ToString();
                        apellido = row.ItemArray[4].ToString();
                        nombre = row.ItemArray[5].ToString();
                        nacimiento = row.ItemArray[6].ToString();
                        // GRV - Modificado
                        //club = row.ItemArray[7].ToString();
                        club = row.ItemArray[7].ToString();
                        if (club.IndexOf("/") != -1)
                        {
                            club2 = club.Substring(club.IndexOf("/") + 1, club.Length - (club.IndexOf("/") + 1));                            
                            club = club.Substring(0, club.IndexOf("/"));
                        }
                        // GRV - Fin
                        rx = row.ItemArray[8].ToString();
                        // GRV - Modifcado
                        telefono = row.ItemArray[9].ToString();
                        Celular = row.ItemArray[10].ToString();
                        Email = row.ItemArray[11].ToString();

                        if (nroEx != "" && examen != "" && dni != "" && apellido != "" && nacimiento != ""
                            && club != "")
                        {
                            bool estado;
                            // GRV - Modificado
                            // estado = cargarPaciente(dni, apellido, nombre, nacimiento, club, registro, fecha, nroEx);
                            if (string.IsNullOrEmpty(club2))
                                estado = cargarPaciente(dni, apellido, nombre, nacimiento, club, registro, fecha, nroEx, telefono, Celular, Email);
                            else
                                estado = cargarPaciente(dni, apellido, nombre, nacimiento, club, registro, fecha, nroEx, club2, telefono, Celular, Email);
                            club2 = "";
                            // GRV - Fin
                            if (!estado) { break; }
                            estado = crearConsultaYExamen(fecha, nroEx, examen, rx, dni, registro);
                            if (!estado) { break; }
                            progressBar.PerformStep();
                            registro++;
                        }
                        else
                        {
                            DialogResult r = MessageBox.Show("El exámen Nº " + nroEx + " no pudo ser importado. Fallo en la lectura de una celda. Compruebe el excel", "Error",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Error);
                            errores++;
                            if (r == DialogResult.Cancel)
                            {
                                break;
                            }
                        }
                       
                    }
                }
                MessageBox.Show("¡Importacion realizada!\nRegistros importados: " + registro.ToString() + "\nRegistros con errores: " + errores.ToString(), "Importación Pacientes",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                progressBar.Visible = false;
                progressBar.Value = 1;
              

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // private bool cargarPaciente(string dni, string ape, string nom, string nac, string club, int registro, string fecha, string nroEx)
        private bool cargarPaciente(string dni, string ape, string nom, string nac, string club, int registro, string fecha, string nroEx, string strTelefono, string strCelular, string strEmail)
        {
            string idPac;
            DataTable datosPac = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Paciente where dni = '" + dni + "'");
            DataTable datosClub = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Club where descripcion = '" + club + "'");
            string fechaStr = (Convert.ToDateTime(fecha)).ToShortDateString();
            DataTable te = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id from dbo.Consulta c inner join 
            dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
            where CONVERT(date,c.fecha) = '" + fechaStr + "' and c.identificador = '" + nroEx + "'");
            if (datosPac.Rows.Count > 0)
            {
                idPac = datosPac.Rows[0].ItemArray[0].ToString();
                if (datosClub.Rows.Count > 0)
                {
                    actualizarClub(idPac, datosClub, te);
                    actualizarPaciente(idPac, ape, nom, nac, dni, strTelefono, strCelular, strEmail);
                    return true;
                }
                else
                {
                    DialogResult r = MessageBox.Show("El club paciente " + ape + " " + nom + ", Nº Examen " + nroEx + " no pudo ser ingresado. No se encuentra el nombre del club\n" +
                          "¡Verifique el Excel!",
                        "Cargar Club", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    errores++;
                    if (r == DialogResult.Cancel)
                    {
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                List<string> listaAddPac = SQLConnector.generarListaParaProcedure("@codigo", "@apellido", "@nombre", "@dni", "@nacimiento");
                SQLConnector.executeProcedure("sp_Paciente_InsertImportacionPreventiva", listaAddPac, dni, ape, nom, dni, Convert.ToDateTime(nac));
                DataTable pacCreado = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Paciente where dni = '" + dni + "'");
                idPac = pacCreado.Rows[0].ItemArray[0].ToString();
                if (datosClub.Rows.Count > 0)
                {
                    actualizarClub(idPac, datosClub, te);
                    return true;
                }
                else
                {
                    DialogResult r = MessageBox.Show("El club paciente " + ape + " " + nom + ", Nº Examen " + nroEx + " no pudo ser ingresado. No se encuentra el nombre del club\n" +
                        "¡Verifique el Excel!",
                        "Cargar Club", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    errores++;
                    if (r == DialogResult.Cancel)
                    {
                        return false;
                    }
                    return true;
                }
                
            }
        }

        private bool cargarPaciente(string dni, string ape, string nom, string nac, string club, int registro, string fecha, string nroEx, string club2, string strTelefono, string strCelular, string strEmail)
        {
            string idPac;
            DataTable datosPac = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Paciente where dni = '" + dni + "'");
            // GRV - Modificado
            //DataTable datosClub = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Club where descripcion = '" + club + "'");
            DataTable datosClub = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Club where descripcion = '" + club + "' OR descripcion = '" + club2 + "'");
            string fechaStr = (Convert.ToDateTime(fecha)).ToShortDateString();
            DataTable te = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id from dbo.Consulta c inner join 
            dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
            where CONVERT(date,c.fecha) = '" + fechaStr + "' and c.identificador = '" + nroEx + "'");
            if (datosPac.Rows.Count > 0)
            {
                idPac = datosPac.Rows[0].ItemArray[0].ToString();
                if (datosClub.Rows.Count > 0)
                {
                    actualizarClub(idPac, datosClub, te);
                    actualizarPaciente(idPac, ape, nom, nac, dni, strTelefono, strCelular, strEmail);
                    return true;
                }
                else
                {
                    DialogResult r = MessageBox.Show("El club paciente " + ape + " " + nom + ", Nº Examen " + nroEx + " no pudo ser ingresado. No se encuentra el nombre del club\n" +
                          "¡Verifique el Excel!",
                        "Cargar Club", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    errores++;
                    if (r == DialogResult.Cancel)
                    {
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                List<string> listaAddPac = SQLConnector.generarListaParaProcedure("@codigo", "@apellido", "@nombre", "@dni", "@nacimiento");
                SQLConnector.executeProcedure("sp_Paciente_InsertImportacionPreventiva", listaAddPac, dni, ape, nom, dni, Convert.ToDateTime(nac));
                DataTable pacCreado = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Paciente where dni = '" + dni + "'");
                idPac = pacCreado.Rows[0].ItemArray[0].ToString();
                if (datosClub.Rows.Count > 0)
                {
                    actualizarClub(idPac, datosClub, te);
                    return true;
                }
                else
                {
                    DialogResult r = MessageBox.Show("El club paciente " + ape + " " + nom + ", Nº Examen " + nroEx + " no pudo ser ingresado. No se encuentra el nombre del club\n" +
                        "¡Verifique el Excel!",
                        "Cargar Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errores++;
                    if (r == DialogResult.Cancel)
                    {
                        return false;
                    }
                    return true;
                }

            }
        }

        //private void actualizarPaciente(string id, string ape, string nom, string nac, string dni)
        private void actualizarPaciente(string id, string ape, string nom, string nac, string dni, string strTelefono, string strCelular, string strEmail)
        {
            List<string> listaUpdate = SQLConnector.generarListaParaProcedure("@id", "@apellido", "@nombre", "@nacimiento", "@dni", "@telefono", "@celular", "@email");
            SQLConnector.executeProcedure("sp_Paciente_UpdateImportacion", listaUpdate, new Guid(id), ape, nom,
                Convert.ToDateTime(nac), dni, strTelefono, strCelular, strEmail);

        }

        private void actualizarClub(string id, DataTable club, DataTable te)
        {
            List<string> addTe = SQLConnector.generarListaParaProcedure("@idTipoExamen","@idClub");
            if (club.Rows.Count > 0)
            {
                List<string> delete = new List<string>();
                delete.Add("@id");
                SQLConnector.executeProcedure("sp_Paciente_DeleteClub", delete, new Guid(id));                
                // GRV - Modificado
                //agregarClub(club.Rows[0].ItemArray[0].ToString(), id);
                for (int i = 0; i < club.Rows.Count; i++)
                    agregarClub(club.Rows[i].ItemArray[0].ToString(), id);
                List<string> deleteTe = SQLConnector.generarListaParaProcedure("@idTipoExamen");
                if(te.Rows.Count > 0)
                {
                    SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Delete", deleteTe, new Guid(te.Rows[0].ItemArray[0].ToString()));
                    // GRV - Modificado
                    //SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", addTe, new Guid(te.Rows[0].ItemArray[0].ToString()),
                    //    club.Rows[0].ItemArray[0].ToString());
                    for (int i = 0; i < club.Rows.Count; i++)
                        SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", addTe, new Guid(te.Rows[0].ItemArray[0].ToString()),
                            club.Rows[i].ItemArray[0].ToString());
                }

            }
        }

        private void agregarClub(string idClub, string idPac)
        {
            List<string> procAddClubPac = SQLConnector.generarListaParaProcedure("@idPaciente", "@idClub");
            SQLConnector.executeProcedure("sp_Paciente_AddClub", procAddClubPac, new Guid(idPac), new Guid(idClub));
        }

        private bool crearConsultaYExamen(string fecha, string nroEx, string ex, string rx, string dni, int registro)
        {
            Etiqueta:
            DataTable cons = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Consulta where fecha = '" + (Convert.ToDateTime(fecha)).ToShortDateString() + "' and identificador = '" + nroEx + "'");
            DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Paciente where dni = '" + dni + "'");
            if (estaHabilitado(paciente.Rows[0].ItemArray[0].ToString()))
            {
                if (cons.Rows.Count == 0)
                {

                    DataTable esp = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Especialidad where descripcion = '" + ex + "'");
                    if (esp.Rows.Count > 0 && paciente.Rows.Count > 0)
                    {
                        List<string> listaCreateCons = SQLConnector.generarListaParaProcedure("@tipo", "@fecha", "@nroOrden", "@identificador", "@pacienteID", "@observaciones", "@valido", "@idTurno");
                        string idConsulta = SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", listaCreateCons, "P", Convert.ToDateTime(fecha), "", nroEx, new Guid(paciente.Rows[0].ItemArray[0].ToString()), "", 1, new Guid("00000000-0000-0000-0000-000000000000"));
                        double imp;
                        if (esp.Rows[0].ItemArray[9].ToString() != "")
                        {
                            imp = Convert.ToDouble(esp.Rows[0].ItemArray[9].ToString());
                        }
                        else
                        {
                            imp = 0;
                        }
                        List<string> lista = SQLConnector.generarListaParaProcedure("@idConsulta", "@idTurno", "@modificado", "@idEspecialidad", "@importe", "@factClub");
                        string modificado = "";
                        if (rx != "") { modificado = "(*)"; }
                        string retorno = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", lista, new Guid(idConsulta), new Guid("00000000-0000-0000-0000-000000000000"), modificado, new Guid(esp.Rows[0].ItemArray[0].ToString()), imp, "0");

                        CapaNegocioMepryl.TipoExamen tipoExamen = new TipoExamen();


                        Entidades.TipoExamen entidad = tipoExamen.cargarEstudiosPorTipoExamen(esp.Rows[0][0].ToString());
                        entidad.IdTipoExamenPaciente = new Guid(retorno);
                        if (rx != "") { entidad.LaboralesBasicas.Rows[0][2] = false; }

                        tipoExamen.crearEstudiosPorExamen(entidad);

                        ExamenPreventiva exPreventiva = new ExamenPreventiva();

                        exPreventiva.crearExamen(retorno);
 
                        DataTable c = SQLConnector.obtenerTablaSegunConsultaString("select cp.club from dbo.clubesPorPaciente cp where cp.paciente = '" + paciente.Rows[0].ItemArray[0].ToString() + "'");
                        if (c.Rows.Count > 0)
                        {
                            foreach (DataRow r in c.Rows)
                            {
                                if (r.ItemArray[0].ToString() != "00000000-0000-0000-0000-000000000000")
                                {
                                    List<string> add = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                                    SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", add, new Guid(retorno), new Guid(r.ItemArray[0].ToString()));
                                }
                            }
                        }

                        return true;


                    }
                    else
                    {
                        DialogResult r = MessageBox.Show("El Nº Examen " + nroEx + " no pudo ser ingresado por que el campo exámen no es válido",
                            "Crear Consulta", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        errores++;
                        if (r == DialogResult.Cancel)
                        {
                            return false;
                        }
                        return true;
                    }
                }
                else
                {
                    List<string> listUpdate = SQLConnector.generarListaParaProcedure("@id", "@idPaciente");
                    SQLConnector.executeProcedure("sp_Consulta_UpdateIdPaciente", listUpdate, new Guid(cons.Rows[0].ItemArray[0].ToString()),
                        new Guid(paciente.Rows[0].ItemArray[0].ToString()));
                    SQLConnector.executeProcedure("sp_Turno_UpdateIdPaciente", listUpdate, new Guid(cons.Rows[0].ItemArray[14].ToString()),
                        new Guid(paciente.Rows[0].ItemArray[0].ToString()));
                    return true;
                }
            }
            else
            {
                DialogResult r = MessageBox.Show("El Examen Nº " + nroEx + " no pudo ser ingresado debido a que el jugador está inhabilitado. ¿Desea habilitarlo ahora?"
                ,"Jugador Inhabilitado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel)
                {
                    errores++;
                    return false;            
                  
                }
                else if (r == DialogResult.Yes)
                {
                    habilitarJugador(paciente.Rows[0].ItemArray[0].ToString());
                    goto Etiqueta;
                }
                return true;
            }






        }

        private bool estaHabilitado(string idPaciente)
        {
            DataTable ultimoExRealizado = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id from dbo.Consulta
            c inner join dbo.TipoExamenDePaciente tep
            on tep.idConsulta = c.id where c.pacienteID = '" + idPaciente + "' and c.tipo = 'P' order by c.fecha desc");
            if(ultimoExRealizado.Rows.Count > 0)
            {
                return !preventiva.estaInhabilitado(ultimoExRealizado.Rows[0].ItemArray[0]);
            }
            return true;
        }

        private void habilitarJugador(string idPaciente)
        {
            DataTable ultimoExRealizado = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, tep.id from dbo.Consulta
            c inner join dbo.TipoExamenDePaciente tep
            on tep.idConsulta = c.id where c.pacienteID = '" + idPaciente + "' and c.tipo = 'P' order by c.fecha desc");
            if (ultimoExRealizado.Rows.Count > 0)
            {
                string idTe = ultimoExRealizado.Rows[0].ItemArray[1].ToString();
                string idC = ultimoExRealizado.Rows[0].ItemArray[0].ToString();
                preventiva.eliminarExamen(idTe, idC);
            }
        }







    }
}
