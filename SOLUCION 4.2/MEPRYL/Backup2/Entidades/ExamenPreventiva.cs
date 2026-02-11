using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ExamenPreventiva
    {
        private Int64 id;
        private Guid idTipoExamen;
        private int biotipo;
        private int entAire;
        private int ruiAgre;
        private int ruiCard;
        private int silencios;
        private int taMax;
        private int taMin;
        private int pulso;
        private int abdomen;
        private int hernias;
        private int varices;
        private int apGenitour;
        private int pielYFaneras;
        private int apLocomotor;
        private int snc;
        private int ojoDer;
        private int ojoDerLent;
        private int ojoIzq;
        private int ojoIzqLent;
        private int visionCromatica;
        private int odonto;
        private int dictFisico;
        private string obsFisico;
        private Guid medico;
        private string talla;
        private string peso;
        private string antCli;
        private string antQui;
        private string antTrau;
        private string gRojos;
        private string gBlancos;
        private string hemoglob;
        private string hemato;
        private string eritro;
        private int cayado;
        private int segmentado;
        private int eosinof;
        private int basof;
        private int linfoc;
        private int monoc;
        private int glucemia;
        private int uremia;
        private int chagas;
        private int vdrl;
        private int grupo;
        private int factor;
        private int color;
        private int aspecto;
        private string densidad;
        private int ph;
        private int glucosa;
        private int proteinas;
        private int hemoglobOrina;
        private int bilirrubina;
        private int celulas;
        private int leucocitos;
        private int hematies;
        private int piocitos;
        private int mucus;
        private int dictLab;
        private string obsSerieRoja;
        private string obsSerieBlanca;
        private string otrosOrina1;
        private string otrosOrina2;
        private string obsLaborat;
        private int rxTorax;
        private int rxColumna;
        private int dictRx;
        private string otrosRx;
        private string obsRx;
        private int ecg;
        private int dictCar;
        private string obsCar;
        private int dictFinal;

        public ExamenPreventiva()
        {
            this.id = -1;
            this.idTipoExamen = Guid.Empty;
            this.biotipo = -1;
            this.entAire = -1;
            this.ruiAgre = -1;
            this.ruiCard = -1;
            this.silencios = -1;
            this.taMax = -1;
            this.taMin = -1;
            this.pulso = -1;
            this.abdomen = -1;
            this.hernias = -1;
            this.varices = -1;
            this.apGenitour = -1;
            this.pielYFaneras = -1;
            this.apLocomotor = -1;
            this.snc = -1;
            this.ojoDer = -1;
            this.ojoDerLent = -1;
            this.ojoIzq = -1;
            this.ojoIzqLent = -1;
            this.visionCromatica = -1;
            this.odonto = -1;
            this.dictFisico = -1;
            this.obsFisico = string.Empty;
            this.medico = Guid.Empty;
            this.talla = string.Empty;
            this.peso = string.Empty;
            this.antCli = string.Empty;
            this.antQui = string.Empty;
            this.antTrau = string.Empty;
            this.gRojos = string.Empty;
            this.gBlancos = string.Empty;
            this.hemoglob = string.Empty;
            this.hemato = string.Empty;
            this.eritro = string.Empty;
            this.cayado = -1;
            this.segmentado = -1;
            this.eosinof = -1;
            this.basof = -1;
            this.linfoc = -1;
            this.monoc = -1;
            this.glucemia = -1;
            this.uremia = -1;
            this.chagas = -1;
            this.vdrl = -1;
            this.grupo = -1;
            this.factor = -1;
            this.color = -1;
            this.aspecto = -1;
            this.densidad = string.Empty;
            this.ph = -1;
            this.glucosa = -1;
            this.proteinas = -1;
            this.hemoglobOrina = -1;
            this.bilirrubina = -1;
            this.celulas = -1;
            this.leucocitos = -1;
            this.hematies = -1;
            this.piocitos = -1;
            this.mucus = -1;
            this.dictLab = -1;
            this.obsSerieBlanca = string.Empty;
            this.obsSerieRoja = string.Empty;
            this.otrosOrina1 = string.Empty;
            this.otrosOrina2 = string.Empty;
            this.obsLaborat = string.Empty;
            this.rxTorax = -1;
            this.rxColumna = -1;
            this.dictRx = -1;
            this.otrosRx = string.Empty;
            this.obsRx = string.Empty;
            this.ecg = -1;
            this.dictCar = -1;
            this.obsCar = string.Empty;
            this.dictFinal = -1;        
        }

        #region Getters&Setters

        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public Guid IdTipoExamen
        {
            get { return idTipoExamen; }
            set { idTipoExamen = value; }
        }

        public int Biotipo
        {
            get { return biotipo; }
            set { biotipo = value; }
        }

        public int EntAire
        {
            get { return entAire; }
            set { entAire = value; }
        }

        public int RuiAgre
        {
            get { return ruiAgre; }
            set { ruiAgre = value; }
        }

        public int RuiCard
        {
            get { return ruiCard; }
            set { ruiCard = value; }
        }

        public int Silencios
        {
            get { return silencios; }
            set { silencios = value; }
        }

        public int TaMax
        {
            get { return taMax; }
            set { taMax = value; }
        }

        public int TaMin
        {
            get { return taMin; }
            set { taMin = value; }
        }

        public int Pulso
        {
            get { return pulso; }
            set { pulso = value; }
        }

        public int Abdomen
        {
            get { return abdomen; }
            set { abdomen = value; }
        }

        public int Hernias
        {
            get { return hernias; }
            set { hernias = value; }
        }

        public int Varices
        {
            get { return varices; }
            set { varices = value; }
        }

        public int ApGenitour
        {
            get { return apGenitour; }
            set { apGenitour = value; }
        }

        public int PielYFaneras
        {
            get { return pielYFaneras; }
            set { pielYFaneras = value; }
        }

        public int ApLocomotor
        {
            get { return apLocomotor; }
            set { apLocomotor = value; }
        }

        public int Snc
        {
            get { return snc; }
            set { snc = value; }
        }

        public int OjoDer
        {
            get { return ojoDer; }
            set { ojoDer = value; }
        }

        public int OjoDerLent
        {
            get { return ojoDerLent; }
            set { ojoDerLent = value; }
        }

        public int OjoIzq
        {
            get { return ojoIzq; }
            set { ojoIzq = value; }
        }

        public int OjoIzqLent
        {
            get { return ojoIzqLent; }
            set { ojoIzqLent = value; }
        }

        public string AntTrau
        {
            get { return antTrau; }
            set { antTrau = value; }
        }

        public string AntQui
        {
            get { return antQui; }
            set { antQui = value; }
        }

        public string AntCli
        {
            get { return antCli; }
            set { antCli = value; }
        }

        public string Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public string Talla
        {
            get { return talla; }
            set { talla = value; }
        }

        public Guid Medico
        {
            get { return medico; }
            set { medico = value; }
        }

        public string ObsFisico
        {
            get { return obsFisico; }
            set { obsFisico = value; }
        }

        public int DictFisico
        {
            get { return dictFisico; }
            set { dictFisico = value; }
        }

        public int Odonto
        {
            get { return odonto; }
            set { odonto = value; }
        }

        public int VisionCromatica
        {
            get { return visionCromatica; }
            set { visionCromatica = value; }
        }

        public int Glucosa
        {
            get { return glucosa; }
            set { glucosa = value; }
        }

        public int Ph
        {
            get { return ph; }
            set { ph = value; }
        }

        public string Densidad
        {
            get { return densidad; }
            set { densidad = value; }
        }

        public int Aspecto
        {
            get { return aspecto; }
            set { aspecto = value; }
        }

        public int Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Factor
        {
            get { return factor; }
            set { factor = value; }
        }

        public int Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        public int Vdrl
        {
            get { return vdrl; }
            set { vdrl = value; }
        }

        public int Chagas
        {
            get { return chagas; }
            set { chagas = value; }
        }

        public int Uremia
        {
            get { return uremia; }
            set { uremia = value; }
        }

        public int Glucemia
        {
            get { return glucemia; }
            set { glucemia = value; }
        }

        public int Monoc
        {
            get { return monoc; }
            set { monoc = value; }
        }

        public int Linfoc
        {
            get { return linfoc; }
            set { linfoc = value; }
        }

        public int Basof
        {
            get { return basof; }
            set { basof = value; }
        }

        public int Eosinof
        {
            get { return eosinof; }
            set { eosinof = value; }
        }

        public int Segmentado
        {
            get { return segmentado; }
            set { segmentado = value; }
        }

        public int Cayado
        {
            get { return cayado; }
            set { cayado = value; }
        }

        public string Eritro
        {
            get { return eritro; }
            set { eritro = value; }
        }

        public string Hemato
        {
            get { return hemato; }
            set { hemato = value; }
        }

        public string Hemoglob
        {
            get { return hemoglob; }
            set { hemoglob = value; }
        }

        public string GBlancos
        {
            get { return gBlancos; }
            set { gBlancos = value; }
        }

        public string GRojos
        {
            get { return gRojos; }
            set { gRojos = value; }
        }

        public int DictFinal
        {
            get { return dictFinal; }
            set { dictFinal = value; }
        }

        public string ObsCar
        {
            get { return obsCar; }
            set { obsCar = value; }
        }

        public int DictCar
        {
            get { return dictCar; }
            set { dictCar = value; }
        }

        public int Ecg
        {
            get { return ecg; }
            set { ecg = value; }
        }

        public string ObsRx
        {
            get { return obsRx; }
            set { obsRx = value; }
        }

        public string OtrosRx
        {
            get { return otrosRx; }
            set { otrosRx = value; }
        }

        public int DictRx
        {
            get { return dictRx; }
            set { dictRx = value; }
        }

        public int RxColumna
        {
            get { return rxColumna; }
            set { rxColumna = value; }
        }

        public int RxTorax
        {
            get { return rxTorax; }
            set { rxTorax = value; }
        }

        public string ObsLaborat
        {
            get { return obsLaborat; }
            set { obsLaborat = value; }
        }

        public string OtrosOrina2
        {
            get { return otrosOrina2; }
            set { otrosOrina2 = value; }
        }

        public string OtrosOrina1
        {
            get { return otrosOrina1; }
            set { otrosOrina1 = value; }
        }

        public string ObsSerieBlanca
        {
            get { return obsSerieBlanca; }
            set { obsSerieBlanca = value; }
        }

        public string ObsSerieRoja
        {
            get { return obsSerieRoja; }
            set { obsSerieRoja = value; }
        }

        public int DictLab
        {
            get { return dictLab; }
            set { dictLab = value; }
        }

        public int Mucus
        {
            get { return mucus; }
            set { mucus = value; }
        }

        public int Piocitos
        {
            get { return piocitos; }
            set { piocitos = value; }
        }

        public int Hematies
        {
            get { return hematies; }
            set { hematies = value; }
        }

        public int Leucocitos
        {
            get { return leucocitos; }
            set { leucocitos = value; }
        }

        public int Celulas
        {
            get { return celulas; }
            set { celulas = value; }
        }

        public int Bilirrubina
        {
            get { return bilirrubina; }
            set { bilirrubina = value; }
        }

        public int HemoglobOrina
        {
            get { return hemoglobOrina; }
            set { hemoglobOrina = value; }
        }

        public int Proteinas
        {
            get { return proteinas; }
            set { proteinas = value; }
        }

        #endregion

    }
}
