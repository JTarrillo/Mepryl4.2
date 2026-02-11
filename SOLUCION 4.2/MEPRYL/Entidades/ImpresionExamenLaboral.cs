using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ImpresionExamenLaboral
    {
        public ImpresionExamenLaboral()
        {
            this.tipoExamen = "";
            this.fecha = "";
            this.nro = "";
            this.empresa = "";
            this.dni = "";
            this.nacimiento = "";
            this.apellidoNombre = "";
            this.nacionalidad = "";
            this.direccion = "";
            this.localidad = "";
            this.telefono = "";
            this.tarea = "";
            this.antCli = "";
            this.antQui = "";
            this.antTrau = "";
            this.talla = "";
            this.peso = "";
            this.imc = "";
            this.entAire = "";
            this.ruiAgre = "";
            this.ruiCard = "";
            this.silencios = "";
            this.taMax = "";
            this.taMin = "";
            this.pulso = "";
            this.abdomen = "";
            this.hernias = "";
            this.varices = "";
            this.apGenitour = "";
            this.pielYFaneras = "";
            this.apLocomotor = "";
            this.snc = "";
            this.ojoDer = "";
            this.ojoDerLent = "";
            this.ojoIzq = "";
            this.ojoIzqLent = "";
            this.visionCromatica = "";
            this.exOdonto = "";
            this.equil = "";
            this.equilTxt = "";
            this.medico = "";
            this.obsCli = "";
            this.txtEncabezado1 = "";
            this.encabezado1 = "";
            this.txtEncabezado2 = "";
            this.encabezado2 = "";
            this.txtEncabezado3 = "";
            this.encabezado3 = "";
            this.txtEncabezado4 = "";
            this.encabezado4 = "";
            this.txtEncabezado5 = "";
            this.encabezado5 = "";
            this.txtEncabezado6 = "";
            this.encabezado6 = "";
            this.txtEncabezado7 = "";
            this.encabezado7 = "";
            this.txtEncabezado8 = "";
            this.encabezado8 = "";
            this.txtEncabezado9 = "";
            this.encabezado9 = "";
            this.txtEncabezado10 = "";
            this.encabezado10 = "";
            this.dictFinal = "";
            this.observaciones = "";
        
        }

        private string tipoExamen;

        public string TipoExamen
        {
            get { return tipoExamen; }
            set { tipoExamen = value; }
        }
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string nro;

        public string Nro
        {
            get { return nro; }
            set { nro = value; }
        }
        private string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private string dni;

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        private string nacimiento;

        public string Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }
        private string apellidoNombre;

        public string ApellidoNombre
        {
            get { return apellidoNombre; }
            set { apellidoNombre = value; }
        }
        private string nacionalidad;

        public string Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string localidad;

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string tarea;

        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }
        private string antCli;

        public string AntCli
        {
            get { return antCli; }
            set { antCli = value; }
        }
        private string antQui;

        public string AntQui
        {
            get { return antQui; }
            set { antQui = value; }
        }
        private string antTrau;

        public string AntTrau
        {
            get { return antTrau; }
            set { antTrau = value; }
        }
        private string talla;

        public string Talla
        {
            get { return talla; }
            set { talla = value; }
        }
        private string peso;

        public string Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private string imc;

        public string Imc
        {
            get { return imc; }
            set { imc = value; }
        }
        private string entAire;

        public string EntAire
        {
            get { return entAire; }
            set { entAire = value; }
        }
        private string ruiAgre;

        public string RuiAgre
        {
            get { return ruiAgre; }
            set { ruiAgre = value; }
        }
        private string ruiCard;

        public string RuiCard
        {
            get { return ruiCard; }
            set { ruiCard = value; }
        }
        private string silencios;

        public string Silencios
        {
            get { return silencios; }
            set { silencios = value; }
        }
        private string taMax;

        public string TaMax
        {
            get { return taMax; }
            set { taMax = value; }
        }
        private string taMin;

        public string TaMin
        {
            get { return taMin; }
            set { taMin = value; }
        }
        private string pulso;

        public string Pulso
        {
            get { return pulso; }
            set { pulso = value; }
        }
        private string abdomen;

        public string Abdomen
        {
            get { return abdomen; }
            set { abdomen = value; }
        }
        private string hernias;

        public string Hernias
        {
            get { return hernias; }
            set { hernias = value; }
        }
        private string varices;

        public string Varices
        {
            get { return varices; }
            set { varices = value; }
        }
        private string apGenitour;

        public string ApGenitour
        {
            get { return apGenitour; }
            set { apGenitour = value; }
        }
        private string pielYFaneras;

        public string PielYFaneras
        {
            get { return pielYFaneras; }
            set { pielYFaneras = value; }
        }
        private string apLocomotor;

        public string ApLocomotor
        {
            get { return apLocomotor; }
            set { apLocomotor = value; }
        }
        private string snc;

        public string Snc
        {
            get { return snc; }
            set { snc = value; }
        }
        private string ojoDer;

        public string OjoDer
        {
            get { return ojoDer; }
            set { ojoDer = value; }
        }
        private string ojoDerLent;

        public string OjoDerLent
        {
            get { return ojoDerLent; }
            set { ojoDerLent = value; }
        }
        private string ojoIzq;

        public string OjoIzq
        {
            get { return ojoIzq; }
            set { ojoIzq = value; }
        }
        private string ojoIzqLent;

        public string OjoIzqLent
        {
            get { return ojoIzqLent; }
            set { ojoIzqLent = value; }
        }
        private string visionCromatica;

        public string VisionCromatica
        {
            get { return visionCromatica; }
            set { visionCromatica = value; }
        }
        private string exOdonto;

        public string ExOdonto
        {
            get { return exOdonto; }
            set { exOdonto = value; }
        }
        private string equil;

        public string Equil
        {
            get { return equil; }
            set { equil = value; }
        }
        private string equilTxt;

        public string EquilTxt
        {
            get { return equilTxt; }
            set { equilTxt = value; }
        }
        private string medico;

        public string Medico
        {
            get { return medico; }
            set { medico = value; }
        }
        private string obsCli;

        public string ObsCli
        {
            get { return obsCli; }
            set { obsCli = value; }
        }
        private string encabezado1;

        public string Encabezado1
        {
            get { return encabezado1; }
            set { encabezado1 = value; }
        }
        private string txtEncabezado1;

        public string TxtEncabezado1
        {
            get { return txtEncabezado1; }
            set { txtEncabezado1 = value; }
        }
        private string encabezado2;

        public string Encabezado2
        {
            get { return encabezado2; }
            set { encabezado2 = value; }
        }
        private string txtEncabezado2;

        public string TxtEncabezado2
        {
            get { return txtEncabezado2; }
            set { txtEncabezado2 = value; }
        }
        private string encabezado3;

        public string Encabezado3
        {
            get { return encabezado3; }
            set { encabezado3 = value; }
        }
        private string txtEncabezado3;

        public string TxtEncabezado3
        {
            get { return txtEncabezado3; }
            set { txtEncabezado3 = value; }
        }
        private string encabezado4;

        public string Encabezado4
        {
            get { return encabezado4; }
            set { encabezado4 = value; }
        }
        private string txtEncabezado4;

        public string TxtEncabezado4
        {
            get { return txtEncabezado4; }
            set { txtEncabezado4 = value; }
        }
        private string encabezado5;

        public string Encabezado5
        {
            get { return encabezado5; }
            set { encabezado5 = value; }
        }
        private string txtEncabezado5;

        public string TxtEncabezado5
        {
            get { return txtEncabezado5; }
            set { txtEncabezado5 = value; }
        }
        private string encabezado6;

        public string Encabezado6
        {
            get { return encabezado6; }
            set { encabezado6 = value; }
        }
        private string txtEncabezado6;

        public string TxtEncabezado6
        {
            get { return txtEncabezado6; }
            set { txtEncabezado6 = value; }
        }
        private string encabezado7;

        public string Encabezado7
        {
            get { return encabezado7; }
            set { encabezado7 = value; }
        }
        private string txtEncabezado7;

        public string TxtEncabezado7
        {
            get { return txtEncabezado7; }
            set { txtEncabezado7 = value; }
        }
        private string encabezado8;

        public string Encabezado8
        {
            get { return encabezado8; }
            set { encabezado8 = value; }
        }
        private string txtEncabezado8;

        public string TxtEncabezado8
        {
            get { return txtEncabezado8; }
            set { txtEncabezado8 = value; }
        }
        private string encabezado9;

        public string Encabezado9
        {
            get { return encabezado9; }
            set { encabezado9 = value; }
        }
        private string txtEncabezado9;

        public string TxtEncabezado9
        {
            get { return txtEncabezado9; }
            set { txtEncabezado9 = value; }
        }
        private string encabezado10;

        public string Encabezado10
        {
            get { return encabezado10; }
            set { encabezado10 = value; }
        }
        private string txtEncabezado10;

        public string TxtEncabezado10
        {
            get { return txtEncabezado10; }
            set { txtEncabezado10 = value; }
        }
        private string dictFinal;

        public string DictFinal
        {
            get { return dictFinal; }
            set { dictFinal = value; }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }


    }
}
