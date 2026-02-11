using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using System.Data.OleDb;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmImportacionCasino : Form
    {
        private int errores;

        private DataTable localidades;
        private DataTable nacionalidades;
        private DataTable esp;

        public delegate void DelegateFormulario(string fecha);
        public DelegateFormulario objDelegateFormulario = null;

        public frmImportacionCasino()
        {
            InitializeComponent();
            inicializarTablas();
        }

        private void inicializarTablas()
        {
            localidades = SQLConnector.obtenerTablaSegunConsultaString(@"select id, pres from dbo.Prestaciones");
            nacionalidades = SQLConnector.obtenerTablaSegunConsultaString(@"select id, descripcion from dbo.Nacionalidad");
            esp = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Especialidad where descripcion = 'CASINO'");
        }

        private void botonImportar_Click(object sender, EventArgs e)
        {
            if (tbArchivo.Text != "")
            {
                importar();
            }
            else
            {
                MessageBox.Show("No se cargo la dirección del archivo", "Importar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void importar()
        {
            if (DialogResult.OK == MessageBox.Show("¿Desea comenzar la importación de registros del archivo " + openFileDialog.FileName + "?", "Importación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                realizarImportacion();
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
                string apellido = "";
                string nombre = "";
                string sexo = "";
                string dni = "";
                string nroOrden = "";
                string nacionalidad = "";
                string nacimiento = "";
                string domicilio = "";
                string localidad = "";
                string tarea = "";

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
                    nroOrden = row.ItemArray[1].ToString();

                    if (fecha != "" && nroOrden != "")
                    {
                        apellido = row.ItemArray[2].ToString();
                        nombre = row.ItemArray[3].ToString();
                        sexo = row.ItemArray[5].ToString();
                        dni = row.ItemArray[4].ToString();
                        nacionalidad = row.ItemArray[6].ToString();
                        nacimiento = row.ItemArray[7].ToString();
                        domicilio = row.ItemArray[8].ToString();
                        localidad = row.ItemArray[9].ToString();
                        tarea = row.ItemArray[11].ToString();
                        if (dni != "" && apellido != "" && nombre != "")
                        {
                            bool estado;
                            estado = cargarPaciente(dni, apellido, nombre, sexo, nacionalidad, nacimiento, domicilio, localidad, tarea);
                            if (!estado) { break; }
                            estado = crearConsultaYExamen(fecha, nroOrden, dni, registro, tarea);
                            if (!estado) { break; }
                            progressBar.PerformStep();
                            registro++;
                        }
                        else
                        {
                            DialogResult r = MessageBox.Show("El exámen Nº " + nroOrden + " no pudo ser importado. Fallo en la lectura de una celda. Compruebe el excel", "Error",
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
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = false;
                progressBar.Value = 1;
                if (objDelegateFormulario != null)
                {
                    objDelegateFormulario(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                    this.Close();
                }   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool crearConsultaYExamen(string fecha, string nroOrden, string dni, int registro, string tarea)
        {
            DataTable cons = SQLConnector.obtenerTablaSegunConsultaString(@"Select * from dbo.Consulta where fecha = '" + (Convert.ToDateTime(fecha)).ToShortDateString() + @"' 
            and identificador = 'L" + Convert.ToInt16(nroOrden).ToString() + "'");
            DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.PacienteLaboral where dni = '" + dni + "'");
            if (cons.Rows.Count == 0)
            {
                if (paciente.Rows.Count > 0)
                {
                    List<string> listaCreateCons = SQLConnector.generarListaParaProcedure("@tipo", "@fecha", "@nroOrden", "@identificador", "@pacienteID", "@observaciones", "@valido", "@idTurno");
                    string idConsulta = SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", listaCreateCons, "L", Convert.ToDateTime(fecha), "", "L" + Convert.ToInt16(nroOrden).ToString()
                        , new Guid(paciente.Rows[0].ItemArray[0].ToString()), "", 1, new Guid("00000000-0000-0000-0000-000000000000"));
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
                    string retorno = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", lista, new Guid(idConsulta), new Guid("00000000-0000-0000-0000-000000000000"), null,
                        new Guid(esp.Rows[0].ItemArray[0].ToString()), imp, "0");

                    TipoExamen tipoExamen = new TipoExamen();
                    Entidades.TipoExamen entidad = tipoExamen.cargarEstudiosPorTipoExamen(esp.Rows[0][0].ToString());
                    entidad.IdTipoExamenPaciente = new Guid(retorno);

                    tipoExamen.crearEstudiosPorExamen(entidad);



                    string idConsultaLaboral = ingresarConsultaLaboral(retorno, 1);

                    Guid idExamenLaboral = new Guid(SQLConnector.executeProcedureWithReturnValue("dbo.sp_ExamenLaboral_Insert", null, null));
                    List<string> updateConsultaLaboral = SQLConnector.generarListaParaProcedure("@id", "@idExamen");
                    SQLConnector.executeProcedure("sp_ConsultaLaboral_UpdateIdExamen", updateConsultaLaboral,
                        new Guid(idConsultaLaboral), idExamenLaboral);

                    List<string> list = SQLConnector.generarListaParaProcedure("@idTipoExamen",
                     "@idEmpresa", "@tarea");
                    SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Add", list,
                    new Guid(retorno), new Guid("B48A61F1-611D-4055-A185-8AE79FF79B9E"),
                    devolverString(tarea));

                }
                return true;
            }
            else
            {
                DialogResult r = MessageBox.Show("El Nro. de Orden: " + nroOrden + " no pudo ser ingresado porque ya existe otra consulta con ese Nro.",
                    "Crear Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errores++;
                if (r == DialogResult.Cancel)
                {
                    return false;
                }
                return true;
            }
   
        }

        private string ingresarConsultaLaboral(string idTe, int tipo)
        {
            List<string> addConsultaLaboral = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@tipo");
            return SQLConnector.executeProcedureWithReturnValue("sp_ConsultaLaboral_Insert", addConsultaLaboral, new Guid(idTe), tipo);
        }
  

        private bool cargarPaciente(string dni, string ape, string nom, string sexo, string nac, string nacimiento
            , string domicilio, string localidad, string tarea)
        {
            try
            {
                DataTable datosPac = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.PacienteLaboral where dni = '" + dni + "'");
                if (datosPac.Rows.Count > 0)
                {
                    string idPac = datosPac.Rows[0].ItemArray[0].ToString();
                    actualizarDatosDePaciente(dni, ape, nom, sexo, nac, nacimiento, domicilio, localidad, idPac, tarea);
                }
                else
                {
                    cargarNuevoPaciente(dni, ape, nom, sexo, nac, nacimiento, domicilio, localidad, tarea);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void cargarNuevoPaciente(string dni, string ape, string nom, string sexo,
            string nac, string nacimiento, string domicilio, string localidad, string tarea)
        {
                PacienteLaboral pl = new PacienteLaboral();
                pl.guardarDatosEntidadNueva(llenarEntidad(dni, ape, nom, sexo, nac, nacimiento, domicilio, localidad, Guid.Empty.ToString(),
                tarea));
        }

        private void actualizarDatosDePaciente(string dni, string ape, string nom, string sexo,
          string nac, string nacimiento, string domicilio, string localidad, string id, string tarea)
        {
            PacienteLaboral pl = new PacienteLaboral();
            pl.guardarDatosEntidadEdicion(llenarEntidad(dni, ape, nom, sexo, nac, nacimiento, domicilio, localidad, id,
                tarea));
        }

        private object devolverDateTime(string nacimiento)
        {
            try
            {
                DateTime nac = Convert.ToDateTime(nacimiento);
                return nac;
            }
            catch
            {
                return null;
            }
        }

        private object devolverString(string str)
        {
            if (str.Length > 0)
            {
                return str;
            }
            return null;
        }

        private object devolverNacionalidad(string nacionalidad)
        {
            DataRow[] drC = nacionalidades.Select("descripcion = '" + nacionalidad + "'");
            if (drC.Length > 0)
            {
                return new Guid(drC[0][0].ToString());
            }
            return null;
        }

        private object devolverLocalidad(string localidad)
        {
            DataRow[] drC = localidades.Select("pres = '" + localidad + "'");
            if (drC.Length > 0)
            {
                return new Guid(drC[0][0].ToString());
            }
            return null;
        }

        private void botonCargar_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Excel (.xls)|*.xls";
            DialogResult result = openFileDialog.ShowDialog();
            tbArchivo.Text = openFileDialog.FileName;
        }

        private Entidades.PacienteLaboral llenarEntidad(string dni, string ape, string nom, string sexo,
          string nac, string nacimiento, string domicilio, string localidad, string id, string tarea)
        {
            Entidades.PacienteLaboral retorno = new Entidades.PacienteLaboral();
            retorno.Id = new Guid(id);
            retorno.Sexo = sexo;
            retorno.Dni = dni;
            retorno.Cuil = Utilidades.calcularCuil(dni, sexo);
            retorno.Apellido = ape;
            retorno.Nombre = nom;
            try
            {
                retorno.Nacimiento = Convert.ToDateTime(nacimiento);
            }
            catch
            {
                retorno.Nacimiento = new DateTime(1800, 1, 1);
            }
            if (devolverNacionalidad(nac) != null)
            {
                retorno.Nacionalidad = (Guid)devolverNacionalidad(nac);
            }
            retorno.Tarea = tarea;
            retorno.Direccion = domicilio;

            if(devolverLocalidad(localidad) != null)
            {
                retorno.IdLocalidad = (Guid)devolverLocalidad(localidad);
            }
            retorno.IdEmpresa = new Guid("B48A61F1-611D-4055-A185-8AE79FF79B9E");
            return retorno;
        }
    }
}
