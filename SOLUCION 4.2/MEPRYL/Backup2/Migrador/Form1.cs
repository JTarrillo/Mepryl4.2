using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using Comunes;
namespace Migrador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            corregirApellidoyNombre();                
        }


        private void migracionAnterior()
        {
            Configuracion conf = new Configuracion();
            SqlDataReader dr = SqlHelper.ExecuteReader(conf.getConectionString(),
                                                        CommandType.Text, "SELECT * FROM Paciente WHERE ltrim(rtrim(apellido))='' AND ltrim(rtrim(nombres))=''");
            SqlConnection con = new SqlConnection(conf.getConectionString());
            con.Open();
            if (dr.HasRows)
            {
                int cont = 1;
                string apellido = "";
                string nombres = "";
                DateTime fechaNacimiento = DateTime.Now;
                while (dr.Read())
                {
                    try
                    {
                        apellido = "";
                        nombres = "";

                        if (dr["apellido"].ToString().Trim() == "" && dr["nombres"].ToString().Trim() == "")
                        {
                            //Separa el nombre
                            if (dr["apellido2"].ToString().Trim() != "")
                            {
                                string[] aNombres = dr["apellido2"].ToString().Replace("  ", " ").Split(' ');
                                apellido = aNombres[0];
                                nombres = "";
                                for (int i = 1; i <= aNombres.Length - 1; i++)
                                    nombres += aNombres[i] + " ";
                            }

                            //Calcula la fecha de nacimiento
                            fechaNacimiento = DateTime.Parse("28/12/1800").Add(new TimeSpan(int.Parse(dr["fecha_imp"].ToString()), 0, 0, 0));

                            //Guarda los cambios
                            SqlHelper.ExecuteNonQuery(con, CommandType.Text,
                                "UPDATE Paciente SET    apellido='" + apellido.Replace('\'', ' ') + "', " +
                                                        "nombres='" + nombres.Replace('\'', ' ') + "', " +
                                                        "fechaNacimiento=" + Utilidades.fechaCanonicaSQL(fechaNacimiento, "00:00:00") + " " +
                                "WHERE id='" + dr["id"].ToString() + "'");

                        }
                        lbEtiqueta.Text = cont.ToString() + ": " + apellido + ", " + nombres + ", " + fechaNacimiento.ToString();
                        cont++;
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        if (DialogResult.Retry != MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel))
                            break;
                    }
                }
            }
        }
 
        private void corregirApellidoyNombre()
        {
            Configuracion conf = new Configuracion();
            SqlDataReader dr = SqlHelper.ExecuteReader(conf.getConectionString(),
                                                        CommandType.Text, "SELECT * FROM Paciente WHERE ltrim(rtrim(apellido))='' AND ltrim(rtrim(nombres))=''");
            SqlConnection con = new SqlConnection(conf.getConectionString());
            con.Open();
            if (dr.HasRows)
            {
                int cont = 1;
                string apellido = "";
                string nombres = "";
                while (dr.Read())
                {
                    try
                    {
                        apellido = "";
                        nombres = "";

                        if (dr["apellido"].ToString().Trim() == "" && dr["nombres"].ToString().Trim() == "")
                        {
                            //Separa el nombre
                            if (dr["apellido2"].ToString().Trim() != "")
                            {
                                string[] aNombres = dr["apellido2"].ToString().Replace("  ", " ").Split(' ');
                                apellido = aNombres[0];
                                nombres = "";
                                for (int i = 1; i <= aNombres.Length - 1; i++)
                                    nombres += aNombres[i] + " ";
                            }

                            //Guarda los cambios
                            SqlHelper.ExecuteNonQuery(con, CommandType.Text,
                                "UPDATE Paciente SET    apellido='" + apellido.Replace('\'',' ') + "', " +
                                                        "nombres='" + nombres.Replace('\'', ' ') + "' " +
                                "WHERE id='" + dr["id"].ToString() + "'");

                        }
                        lbEtiqueta.Text = cont.ToString() + ": " + apellido + ", " + nombres;
                        cont++;
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        if (DialogResult.Retry != MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel))
                            break;
                    }
                }
            }
        }

    }
      
}