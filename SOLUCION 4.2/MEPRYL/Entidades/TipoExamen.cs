using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entidades
{
    public class TipoExamen
    {
        private int estado; // Estado: 1 = activo, 0 = inactivo

    
        private Guid id;
        private int codigo;
        private int idMotivoConsulta;
        private string descripcion;
        private string descripcionInformes;
        private Double precioBase;
        private DataTable clinico;
        private DataTable hematologia;
        private DataTable quimicaHematica;
        private DataTable serologia;
        private DataTable perfilLipidico;
        private DataTable bacteriologia;
        private DataTable orina;
        private DataTable laboralesBasicas;
        private DataTable craneoYMSuperior;
        private DataTable troncoYPelvis;
        private DataTable miembroInferior; 
        private DataTable estComplementarios;
        private bool modificado;
        private Guid idTipoExamenPaciente;
        private string textoClinico;
        private string textoLaboratorio;
        private string textoRx;
        private string textoEstComplement;
        private int? tipo; // Agrega este campo privado

        private bool padre;
        private string idPadre;



        public TipoExamen()
        {
            id = Guid.Empty;
            codigo = -1;
            idMotivoConsulta = -1;
            descripcion = string.Empty;
            descripcionInformes = string.Empty;
            precioBase = 0;
            clinico = new DataTable();
            hematologia = new DataTable();
            quimicaHematica = new DataTable();
            serologia = new DataTable();
            perfilLipidico = new DataTable();
            bacteriologia = new DataTable();
            orina = new DataTable();
            laboralesBasicas = new DataTable();
            craneoYMSuperior = new DataTable();
            troncoYPelvis = new DataTable();
            miembroInferior = new DataTable();
            estComplementarios = new DataTable();
            modificado = false;
            idTipoExamenPaciente = Guid.Empty;
            textoClinico = string.Empty;
            textoLaboratorio = string.Empty;
            textoRx = string.Empty;
            textoEstComplement = string.Empty;

            padre = false;
            idPadre = string.Empty;
        }

        #region Getters&Setters

        public string TextoClinico
        {
            get { return textoClinico; }
            set { textoClinico = value; }
        }

        public string TextoRx
        {
            get { return textoRx; }
            set { textoRx = value; }
        }

        public string TextoEstComplement
        {
            get { return textoEstComplement; }
            set { textoEstComplement = value; }
        }


        public string TextoLaboratorio
        {
            get { return textoLaboratorio; }
            set { textoLaboratorio = value; }
        }

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public int IdMotivoConsulta
        {
            get { return idMotivoConsulta; }
            set { idMotivoConsulta = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string DescripcionInformes
        {
            get { return descripcionInformes; }
            set { descripcionInformes = value; }
        }

        public Double PrecioBase
        {
            get { return precioBase; }
            set { precioBase = value; }
        }

        public DataTable Clinico
        {
            get { return clinico; }
            set { clinico = value; }
        }

        public DataTable Hematologia
        {
            get { return hematologia; }
            set { hematologia = value; }
        }

        public DataTable QuimicaHematica
        {
            get { return quimicaHematica; }
            set { quimicaHematica = value; }
        }

        public DataTable Serologia
        {
            get { return serologia; }
            set { serologia = value; }
        }

        public DataTable PerfilLipidico
        {
            get { return perfilLipidico; }
            set { perfilLipidico = value; }
        }

        public DataTable LaboralesBasicas
        {
            get { return laboralesBasicas; }
            set { laboralesBasicas = value; }
        }

        public DataTable MiembroInferior
        {
            get { return miembroInferior; }
            set { miembroInferior = value; }
        }

        public DataTable TroncoYPelvis
        {
            get { return troncoYPelvis; }
            set { troncoYPelvis = value; }
        }

        public DataTable EstComplementarios
        {
            get { return estComplementarios; }
            set { estComplementarios = value; }
        }

        public DataTable CraneoYMSuperior
        {
            get { return craneoYMSuperior; }
            set { craneoYMSuperior = value; }
        }

        public DataTable Orina
        {
            get { return orina; }
            set { orina = value; }
        }

        public DataTable Bacteriologia
        {
            get { return bacteriologia; }
            set { bacteriologia = value; }
        }

        public bool Modificado
        {
            get { return modificado; }
            set { modificado = value; }
        }

        public Guid IdTipoExamenPaciente
        {
            get { return idTipoExamenPaciente; }
            set { idTipoExamenPaciente = value; }
        }

        public bool Padre
        {
            get { return padre; }
            set { padre = value; }
        }

        public string IdPadre
        {
            get { return idPadre; }
            set { idPadre = value; }
        }

        #endregion
    }
}
