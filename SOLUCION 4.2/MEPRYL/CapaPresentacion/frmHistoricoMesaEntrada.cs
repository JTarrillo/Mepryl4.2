using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmHistoricoMesaEntrada : DevExpress.XtraEditors.XtraForm
    {
        string fechaDesde, fechaHasta;
        CapaNegocioMepryl.TipoExamen tipoEx;

        public frmHistoricoMesaEntrada()
        {
            InitializeComponent();
            tipoEx = new CapaNegocioMepryl.TipoExamen();
            fechaDesde = DateTime.Today.ToShortDateString();
            fechaHasta = DateTime.Today.ToShortDateString();
           
            cargarSinFiltro();
            cboTipoBusqueda.SelectedIndex = 0;
        }

        public frmHistoricoMesaEntrada(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            tipoEx = new CapaNegocioMepryl.TipoExamen();
            fechaDesde = DateTime.Today.ToShortDateString();
            fechaHasta = DateTime.Today.ToShortDateString();

            
            cargarSinFiltro();
            cboTipoBusqueda.SelectedIndex = 0;
        }

       

        private void cargarSinFiltro()
        {
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.pacienteID, tep.id, CONVERT(date, c.fecha), 
            e.descripcion, c.nroOrden, c.identificador,
            c.tipo, tep.modificado from dbo.Consulta c inner join
            dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id inner join dbo.Especialidad e on tep.idEspecialidad
            = e.id inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id where Convert(Date,c.fecha) >= '" + fechaDesde + @"' 
            and Convert(Date,c.fecha) <= '" + fechaHasta + "' and c.nroOrden > 0 order by c.fecha asc, convert(int,c.nroOrden)");

            //            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as 'idConsulta', c.pacienteID as 'idPaciente', tep.id as 'idTipoExamen', CONVERT(date, c.fecha) as 'Fecha', 
            //e.descripcion as 'Examen', c.nroOrden as 'Nº Orden', c.identificador as 'Nº Examen', CP.Apellidos as 'Apellido', CP.Nombres as 'Nombre', CP.DNI,  
            //YEAR(CONVERT(DATE,CP.FechaNacimiento, 105)) as Categoria, CEE.imagen as 'Liga', CEE.Club, CEE.Empresa, '' as LigaDesc, c.tipo as 'Tipo', '' as Estudios
            //                from dbo.Consulta c 
            //                inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id 
            //                inner join dbo.Especialidad e on tep.idEspecialidad = e.id 
            //                inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            //                INNER JOIN dbo.vwConsultarPacientes CP on c.pacienteID =  CP.id
            //                INNER JOIN dbo.vwConsultaEmpresaPorTipoExamen CEE on CEE.idTipoExamen = tep.id AND CEE.Tipo = CP.TipoPaciente
            //                where Convert(Date,c.fecha) >= '" + fechaDesde + @"' 
            //                and Convert(Date,c.fecha) <= '" + fechaHasta + @"' 
            //                and c.nroOrden > 0 
            //                order by c.fecha asc, convert(int,c.nroOrden)");

            DataTable tabla = procesarTablaConsulta(consulta, false);
            cargarGrilla(tabla);
            //cargarGrilla(consulta);
        }

        private void cargarConFiltro()
        {
            string filtro = "";
            //if (cboTipoBusqueda.SelectedIndex == 0) filtro = " and e.descripcion LIKE '%" + tbBusqueda.Text + "%'";
            if (cboTipoBusqueda.SelectedIndex == 0) filtro = " and e.descripcion LIKE '" + tbBusqueda.Text + "%' ";
            string fechaHasta = tpHasta.Value.ToShortDateString();
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.pacienteID, tep.id, CONVERT(date, c.fecha), 
            e.descripcion, c.nroOrden, c.identificador,
            c.tipo, tep.modificado from dbo.Consulta c inner join
            dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id inner join dbo.Especialidad e on tep.idEspecialidad
            = e.id inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id where Convert(Date,c.fecha) >= '" + fechaDesde + @"' 
            and Convert(Date,c.fecha) <= '" + fechaHasta + "'" + filtro + " and c.nroOrden > 0 order by c.fecha asc, convert(int,c.nroOrden) asc");

            //            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as 'idConsulta', c.pacienteID as 'idPaciente', tep.id as 'idTipoExamen', CONVERT(date, c.fecha) as 'Fecha', 
            //e.descripcion as 'Examen', c.nroOrden as 'Nº Orden', c.identificador as 'Nº Examen', CP.Apellidos as 'Apellido', CP.Nombres as 'Nombre', CP.DNI,  
            //YEAR(CONVERT(DATE,CP.FechaNacimiento, 105)) as Categoria, CEE.imagen as 'Liga', CEE.Club, CEE.Empresa, '' as LigaDesc, c.tipo as 'Tipo', '' as Estudios
            //                from dbo.Consulta c 
            //                inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id 
            //                inner join dbo.Especialidad e on tep.idEspecialidad = e.id 
            //                inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id
            //                INNER JOIN dbo.vwConsultarPacientes CP on c.pacienteID =  CP.id
            //                INNER JOIN dbo.vwConsultaEmpresaPorTipoExamen CEE on CEE.idTipoExamen = tep.id AND CEE.Tipo = CP.TipoPaciente
            //                where Convert(Date,c.fecha) >= '" + fechaDesde + @"' 
            //                and Convert(Date,c.fecha) <= '" + fechaHasta + @"'" + filtro + @" 
            //                and c.nroOrden > 0 
            //                order by c.fecha asc, convert(int,c.nroOrden)");
            DataTable tabla = procesarTablaConsulta(consulta, true);
            cargarGrilla(tabla);
            //cargarGrilla(consulta);

        }

        private DataTable procesarTablaConsulta(DataTable consulta, bool filtro)
        {
            progressBar.Minimum = 1;
            progressBar.Maximum = consulta.Rows.Count;
            progressBar.Visible = true;

            DataTable retorno = new DataTable();
            retorno.Columns.Add("idConsulta");
            retorno.Columns.Add("idPaciente");
            retorno.Columns.Add("idTipoExamen");
            retorno.Columns.Add("fechaConsulta");
            retorno.Columns.Add("tipoExamen");
            retorno.Columns.Add("nroOrden");
            retorno.Columns.Add("identificador");
            retorno.Columns.Add("apellido");
            retorno.Columns.Add("nombre");
            retorno.Columns.Add("dni");
            retorno.Columns.Add("tipoConsulta");
            retorno.Columns.Add("nacimiento");

            foreach (DataRow r in consulta.Rows)
            {
                object dr = cargarDatoPaciente(r.ItemArray[1].ToString(), filtro);
                if (dr != null)
                {
                    string nacimientoString;
                    try
                    {
                        nacimientoString = Convert.ToDateTime(((DataRow)dr).ItemArray[3].ToString()).ToShortDateString();
                    }
                    catch
                    {
                        nacimientoString = string.Empty;
                    }
                    retorno.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], r.ItemArray[3],
                    r.ItemArray[4].ToString() + " " + r.ItemArray[8].ToString(), r.ItemArray[5], r.ItemArray[6], ((DataRow)dr).ItemArray[1], ((DataRow)dr).ItemArray[2],
                    ((DataRow)dr).ItemArray[0], r.ItemArray[7], nacimientoString);

                }
                progressBar.PerformStep();
            }
            progressBar.Visible = false;

            return retorno;
        }

        private object cargarDatoPaciente(string idPaciente, bool filtro)
        {
            string txtFiltro = "";
            if (cboTipoBusqueda.SelectedIndex == 1 && filtro) txtFiltro = " and p.apellido LIKE '%" + tbBusqueda.Text + "%'";
            if (cboTipoBusqueda.SelectedIndex == 2 && filtro) txtFiltro = " and p.dni LIKE '%" + tbBusqueda.Text + "%'";
            if (cboTipoBusqueda.SelectedIndex == 3 && filtro) txtFiltro = " and YEAR(p.fechaNacimiento) = '" + tbBusqueda.Text + "'";
            DataTable pacientePreventiva = SQLConnector.obtenerTablaSegunConsultaString(@"
                    select p.dni, p.apellido, p.nombres as Paciente, p.fechaNacimiento
                    from dbo.Paciente p
                    where p.id = '" + idPaciente + "'" + txtFiltro);
            if (pacientePreventiva.Rows.Count > 0)
            {
                return pacientePreventiva.Rows[0];
            }
            else
            {
                DataTable pacienteLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"
                        select p.dni, p.apellido, p.nombres as Paciente,
                        p.fechaNacimiento
                        from dbo.PacienteLaboral p
                        where p.id = '" + idPaciente + "'" + txtFiltro);
                if (pacienteLaboral.Rows.Count > 0)
                {
                    return pacienteLaboral.Rows[0];
                }
                return null;

            }
        }

        private void cargarGrilla(DataTable dtGrilla)
        {
            if (dgv.Rows.Count > 0)
            {
                dgv.Rows.Clear();
            }

            progressBar.Minimum = 0;
            progressBar.Maximum = dtGrilla.Rows.Count;
            if (dtGrilla.Rows.Count > 0)
            {
                progressBar.Value = 1;
            }
            progressBar.Visible = true;

            foreach (DataRow r in dtGrilla.Rows)
            {
                if (r.ItemArray[10].ToString() == "P" && (botonP.Checked || botonT.Checked))
                {
                    cargarPreventiva(r);
                    dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else if (r.ItemArray[10].ToString() == "L" && (botonL.Checked || botonT.Checked))
                {
                    cargarLaboral(r);
                    dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Moccasin;
                }
                else if (r.ItemArray[10].ToString() == "EC" && (botonEC.Checked || botonT.Checked))
                {
                    cargarOtros(r);
                    dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Azure;
                }

                else if (r.ItemArray[10].ToString() == "CO" && (botonC.Checked || botonT.Checked))
                {
                    cargarOtros(r);
                    //dgv.Rows.Add(r);
                    dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }
                else if (r.ItemArray[10].ToString() == "R" && (botonR.Checked || botonT.Checked))
                {
                    cargarOtros(r);
                    //dgv.Rows.Add(r);
                    dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                progressBar.PerformStep();
            }
            tbTotal.Text = "Total Pacientes: " + dgv.Rows.Count.ToString();
            progressBar.Visible = false;

        }

        public char verificarTipoPaciente(Guid idPaciente)
        {
            DataTable pacientePreventiva = SQLConnector.obtenerTablaSegunConsultaString(@"
                    select *
                    from dbo.Paciente p
                    where p.id = '" + idPaciente + "'");
            if (pacientePreventiva.Rows.Count > 0)
            {
                return 'P';
            }
            else
            {
                return 'L';
            }
        }


        private void cargarOtros(DataRow r)
        {
            //SI SON ESTUDIOS COMPLEMENTARIOS, CONSULTORIOS O REPETICIONES

            string categor = "";
            object liga = null;
            object club = "";
            object ligaDescrip = "";
            object empresaText = "";

            if (verificarTipoPaciente(new Guid(r.ItemArray[1].ToString())) == 'P')
            {
                DataTable clubes = SQLConnector.obtenerTablaSegunConsultaString(@"select l.id, l.descripcion, l.imagen, c.id, c.descripcion
                , e.descripcion, l.idEspecialidad, e.id as Especialidad from dbo.clubesPorTipoExamen cp inner join dbo.Club c on cp.idClub = c.id
                inner join dbo.Liga l on c.ligaID = l.id inner join dbo.TipoExamenDePaciente tep on
                cp.idTipoExamen = tep.id inner join dbo.Especialidad e on tep.idEspecialidad = e.id 
                where cp.idTipoExamen = '" + r.ItemArray[2].ToString() + "'");


                if (clubes.Rows.Count > 0)
                {
                    foreach (DataRow row in clubes.Rows)
                    {
                        if (row.ItemArray[2].ToString() != "")
                        {
                            byte[] imageBuffer = (byte[])row.ItemArray[2];
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                            liga = Image.FromStream(ms);
                            club = clubes.Rows[0].ItemArray[4];
                            ligaDescrip = row.ItemArray[1];
                        }
                        else
                        {
                            club = clubes.Rows[0].ItemArray[4];
                            ligaDescrip = row.ItemArray[1];
                        }
                    }

                    categor = Convert.ToDateTime(r.ItemArray[11].ToString()).Year.ToString();


                }
            }
            else
            {

                DataTable empresa = SQLConnector.obtenerTablaSegunConsultaString(@"select e.razonSocial from dbo.empresaPorTipoDeExamen ete
                inner join dbo.Empresa e on ete.idEmpresa = e.id
                where ete.idTipoExamen = '" + r.ItemArray[2].ToString() + "'");
                if (empresa.Rows.Count > 0)
                {
                    empresaText = empresa.Rows[0].ItemArray[0];
                }
                else
                {
                    empresaText = "";

                }
            }



            DateTime fecha = Convert.ToDateTime(r.ItemArray[3].ToString());
            agregar(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], fecha.ToShortDateString(),
            r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9],
            categor, liga, club, empresaText, ligaDescrip, r.ItemArray[10], cargarItems(r.ItemArray[2].ToString()));
        }

        private string cargarItems(string idTipoEx)
        {
            Entidades.TipoExamen entidad = tipoEx.cargarEstudiosPorExamen(idTipoEx);
            string retorno = string.Empty;
            agregarCadenaString(ref retorno, entidad.TextoClinico);
            agregarCadenaString(ref retorno, entidad.TextoLaboratorio);
            agregarCadenaString(ref retorno, entidad.TextoRx);
            agregarCadenaString(ref retorno, entidad.TextoEstComplement);
            return retorno;
        }

        private void agregarCadenaString(ref string retorno, string texto)
        {
            if (texto != string.Empty)
            {
                if (retorno != string.Empty)
                {
                    retorno = retorno + " - " + texto;
                }
                else
                {
                    retorno = texto;
                }
            }
        }


        private void buscar()
        {
            if (tbBusqueda.Text != "")
            {

                if (gbFecha.Enabled)
                {
                    fechaDesde = tpFecha.Value.ToShortDateString();
                    fechaHasta = tpFecha.Value.ToShortDateString();
                }
                else
                {
                    fechaDesde = tpDesde.Value.ToShortDateString();
                    fechaHasta = tpHasta.Value.ToShortDateString();
                }
                cargarConFiltro();
                this.ActiveControl = dgv;
            }
            else
            {
                MessageBox.Show("¡Ingrese una palabra para buscar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbBusqueda.Focus();
            }
        }

        private void cargarPreventiva(DataRow r)
        {
            //SI ES PREVENTIVA
            DataTable clubes = SQLConnector.obtenerTablaSegunConsultaString(@"select l.id, l.descripcion, l.imagen, c.id, c.descripcion
                , e.descripcion, l.idEspecialidad, e.id as Especialidad, l.pathImagen from dbo.clubesPorTipoExamen cp inner join dbo.Club c on cp.idClub = c.id
                inner join dbo.Liga l on c.ligaID = l.id inner join dbo.TipoExamenDePaciente tep on
                cp.idTipoExamen = tep.id inner join dbo.Especialidad e on tep.idEspecialidad = e.id 
                where cp.idTipoExamen = '" + r.ItemArray[2].ToString() + "'");

            if (clubes.Rows.Count > 0)
            {
                bool agrego = false;
                string idEsp = clubes.Rows[0].ItemArray[7].ToString();
                Image imgEscudo = null;

                foreach (DataRow row in clubes.Rows)
                {
                    if (!string.IsNullOrEmpty(row.ItemArray[8].ToString()))
                    {
                        imgEscudo = Image.FromFile(row.ItemArray[8].ToString());
                    }

                    if (idEsp == row.ItemArray[6].ToString() && !agrego)
                    {
                        byte[] imageBuffer = (byte[])row.ItemArray[2];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);

                        DateTime fecha = Convert.ToDateTime(r.ItemArray[3].ToString());
                        //agregar(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], fecha.ToShortDateString(),
                        //r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9],
                        //Convert.ToDateTime(r.ItemArray[11]).Year.ToString(), Image.FromStream(ms), clubes.Rows[0].ItemArray[4], "", row.ItemArray[1], r.ItemArray[11], cargarItems(r.ItemArray[2].ToString()));
                        agregar(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], fecha.ToShortDateString(),
                        r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9],
                        Convert.ToDateTime(r.ItemArray[11]).Year.ToString(), imgEscudo, clubes.Rows[0].ItemArray[4], "", row.ItemArray[1], r.ItemArray[11], cargarItems(r.ItemArray[2].ToString()));
                        agrego = true;
                    }

                }
                if (!agrego)
                {
                    DateTime fecha = Convert.ToDateTime(r.ItemArray[3].ToString());
                    agregar(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], fecha.ToShortDateString(),
                    r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9],
                    Convert.ToDateTime(r.ItemArray[11]).Year.ToString(), imgEscudo, clubes.Rows[0].ItemArray[4].ToString(), "", clubes.Rows[0].ItemArray[1], r.ItemArray[11], cargarItems(r.ItemArray[2].ToString()));

                }
            }
            else
            {
                DateTime fecha = Convert.ToDateTime(r.ItemArray[3].ToString());
                agregar(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], fecha.ToShortDateString(),
                r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9],
                Convert.ToDateTime(r.ItemArray[11]).Year.ToString(), null, "", "", "", r.ItemArray[10], cargarItems(r.ItemArray[2].ToString()));
            }

        }

        private void cargarLaboral(DataRow r)
        {
            //SI ES LABORAL
            DataTable empresa = SQLConnector.obtenerTablaSegunConsultaString(@"select e.razonSocial from dbo.empresaPorTipoDeExamen ete
                inner join dbo.Empresa e on ete.idEmpresa = e.id
                where ete.idTipoExamen = '" + r.ItemArray[2].ToString() + "'");
            if (empresa.Rows.Count > 0)
            {
                DateTime fecha = Convert.ToDateTime(r.ItemArray[3]);
                agregar(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], fecha.ToShortDateString(),
                r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9]
                , "", null, "", empresa.Rows[0].ItemArray[0], "", r.ItemArray[10], cargarItems(r.ItemArray[2].ToString()));
            }
            else
            {
                DateTime fecha = Convert.ToDateTime(r.ItemArray[3]);
                agregar(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], fecha.ToShortDateString(),
                r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9]
                , "", null, "", "", "", r.ItemArray[10], cargarItems(r.ItemArray[2].ToString()));

            }
        }

        private void agregar(object idC, object idP, object idTe, object f, object e, object no, object ne,
                object ap, object nom, object dni, object categoria, object liga, object club, object empresa, object ligaDescrip, object tipo,
                object estudios)
        {
            dgv.Rows.Add(idC, idP, idTe, f, e, no, ne, ap, nom, dni, categoria, liga, club, empresa, ligaDescrip, tipo, estudios);
        }

        private void butImprimirListado_Click(object sender, EventArgs e)
        {
            rptHistoricoME doc = new rptHistoricoME();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("idConsulta");
            tabla.Columns.Add("idPaciente");
            tabla.Columns.Add("idTipoExamen");
            tabla.Columns.Add("Fecha");
            tabla.Columns.Add("Examen");
            tabla.Columns.Add("Nº Ord.");
            tabla.Columns.Add("Nº Ex.");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("DNI");
            tabla.Columns.Add("Liga1");
            tabla.Columns.Add("Club");
            tabla.Columns.Add("Empresa");
            tabla.Columns.Add("Liga");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                tabla.Rows.Add(row.Cells[0].Value, row.Cells[1].Value,
                    row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value,
                    row.Cells[5].Value, row.Cells[6].Value, row.Cells[7].Value,
                    row.Cells[8].Value, row.Cells[9].Value, row.Cells[11].Value,
                    row.Cells[12].Value, row.Cells[13].Value, row.Cells[14].Value);
            }
            doc.SetDataSource(tabla);
            doc.SetParameterValue("fecha", "Desde: " + tpDesde.Value.ToShortDateString() +
            " Hasta: " + tpHasta.Value.ToShortDateString());
            doc.SetParameterValue("cantidad", "Cantidad de Pacientes: " + tabla.Rows.Count.ToString());
            int numero = 47;
            int cantHojas = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Index > numero)
                {
                    numero = numero + 48;
                    cantHojas = cantHojas + 1;
                }
            }
            doc.PrintToPrinter(1, false, 1, cantHojas);
        }

        private void botonP_CheckedChanged(object sender, EventArgs e)
        {
            cargarSinFiltro();
        }

        private void botonL_CheckedChanged(object sender, EventArgs e)
        {
            cargarSinFiltro();
        }

        private void botonEC_CheckedChanged(object sender, EventArgs e)
        {
            cargarSinFiltro();
        }

        private void botonC_CheckedChanged(object sender, EventArgs e)
        {
            cargarSinFiltro();
        }

        private void botonR_CheckedChanged(object sender, EventArgs e)
        {
            cargarSinFiltro();
        }

        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscar();
            }
        }


        private void botonBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            botonP.Checked = false;
            botonT.Checked = true;
            botonL.Checked = false;
            botonC.Checked = false;
            botonR.Checked = false;
            botonEC.Checked = false;
            cargarSinFiltro();
            tbBusqueda.Text = "";
            cboTipoBusqueda.SelectedIndex = 0;
            this.ActiveControl = dgv;
        }

        private void botMostrarEstudios_Click(object sender, EventArgs e)
        {
            if (dgv.Columns["Estudios"].Visible) { dgv.Columns["Estudios"].Visible = false; }
            else { dgv.Columns["Estudios"].Visible = true; }
        }

        private void botonRango_Click(object sender, EventArgs e)
        {
            gbFecha.Enabled = false;
            gbRango.Enabled = true;
        }

        private void botonFecha_Click(object sender, EventArgs e)
        {
            gbFecha.Enabled = true;
            gbRango.Enabled = false;
        }

        private void botBuscarFecha_Click(object sender, EventArgs e)
        {
            fechaDesde = tpDesde.Value.ToShortDateString();
            fechaHasta = tpHasta.Value.ToShortDateString();
            botonT.Checked = true;
            cargarSinFiltro();
        }

        private void bbiMostrarEstudio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botMostrarEstudios_Click(sender, e);
        }

        private void bbiImprimirListado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            butImprimirListado_Click(sender, e);
        }

        private void tpFecha_ValueChanged(object sender, EventArgs e)
        {
            fechaDesde = tpFecha.Value.ToShortDateString();
            fechaHasta = tpFecha.Value.ToShortDateString();
            botonT.Checked = true;
            cargarSinFiltro();
        }
    }

}

