using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ExamenLaboral
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
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
        private string entradaAire;

        public string EntradaAire
        {
            get { return entradaAire; }
            set { entradaAire = value; }
        }
        private string ruidosAgre;

        public string RuidosAgre
        {
            get { return ruidosAgre; }
            set { ruidosAgre = value; }
        }
        private string ruidosCard;

        public string RuidosCard
        {
            get { return ruidosCard; }
            set { ruidosCard = value; }
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
        private string observacionesCli;

        public string ObservacionesCli
        {
            get { return observacionesCli; }
            set { observacionesCli = value; }
        }
        private string medico;

        public string Medico
        {
            get { return medico; }
            set { medico = value; }
        }
        private string dictamenCli;

        public string DictamenCli
        {
            get { return dictamenCli; }
            set { dictamenCli = value; }
        }
        private string gRojos;

        public string GRojos
        {
            get { return gRojos; }
            set { gRojos = value; }
        }
        private string gBlancos;

        public string GBlancos
        {
            get { return gBlancos; }
            set { gBlancos = value; }
        }
        private string hemoglobina;

        public string Hemoglobina
        {
            get { return hemoglobina; }
            set { hemoglobina = value; }
        }
        private string hematocrito;

        public string Hematocrito
        {
            get { return hematocrito; }
            set { hematocrito = value; }
        }
        private string eritro;

        public string Eritro
        {
            get { return eritro; }
            set { eritro = value; }
        }
        private string plaquetas;

        public string Plaquetas
        {
            get { return plaquetas; }
            set { plaquetas = value; }
        }
        private string obsSerieRoja;

        public string ObsSerieRoja
        {
            get { return obsSerieRoja; }
            set { obsSerieRoja = value; }
        }
        private string cayado;

        public string Cayado
        {
            get { return cayado; }
            set { cayado = value; }
        }
        private string segmentado;

        public string Segmentado
        {
            get { return segmentado; }
            set { segmentado = value; }
        }
        private string eosinof;

        public string Eosinof
        {
            get { return eosinof; }
            set { eosinof = value; }
        }
        private string basof;

        public string Basof
        {
            get { return basof; }
            set { basof = value; }
        }
        private string linfoc;

        public string Linfoc
        {
            get { return linfoc; }
            set { linfoc = value; }
        }
        private string monoc;

        public string Monoc
        {
            get { return monoc; }
            set { monoc = value; }
        }
        private string obsSerieBlanca;

        public string ObsSerieBlanca
        {
            get { return obsSerieBlanca; }
            set { obsSerieBlanca = value; }
        }
        private string glucemia;

        public string Glucemia
        {
            get { return glucemia; }
            set { glucemia = value; }
        }
        private string uremia;

        public string Uremia
        {
            get { return uremia; }
            set { uremia = value; }
        }
        private string chagas;

        public string Chagas
        {
            get { return chagas; }
            set { chagas = value; }
        }
        private string vdrl;

        public string Vdrl
        {
            get { return vdrl; }
            set { vdrl = value; }
        }
        private string grupo;

        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        private string factor;

        public string Factor
        {
            get { return factor; }
            set { factor = value; }
        }
        private string uricemia;

        public string Uricemia
        {
            get { return uricemia; }
            set { uricemia = value; }
        }
        private string te;

        public string Te
        {
            get { return te; }
            set { te = value; }
        }
        private string otrosQuimicaHemat;

        public string OtrosQuimicaHemat
        {
            get { return otrosQuimicaHemat; }
            set { otrosQuimicaHemat = value; }
        }
        private string colTotal;

        public string ColTotal
        {
            get { return colTotal; }
            set { colTotal = value; }
        }
        private string hdl;

        public string Hdl
        {
            get { return hdl; }
            set { hdl = value; }
        }
        private string ldl;

        public string Ldl
        {
            get { return ldl; }
            set { ldl = value; }
        }
        private string triglic;

        public string Triglic
        {
            get { return triglic; }
            set { triglic = value; }
        }
        private string otrosPerfilLipidico;

        public string OtrosPerfilLipidico
        {
            get { return otrosPerfilLipidico; }
            set { otrosPerfilLipidico = value; }
        }
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private string aspecto;

        public string Aspecto
        {
            get { return aspecto; }
            set { aspecto = value; }
        }
        private string densidad;

        public string Densidad
        {
            get { return densidad; }
            set { densidad = value; }
        }
        private string ph;

        public string Ph
        {
            get { return ph; }
            set { ph = value; }
        }
        private string celulas;

        public string Celulas
        {
            get { return celulas; }
            set { celulas = value; }
        }
        private string leuco;

        public string Leuco
        {
            get { return leuco; }
            set { leuco = value; }
        }
        private string hematies;

        public string Hematies
        {
            get { return hematies; }
            set { hematies = value; }
        }
        private string prot;

        public string Prot
        {
            get { return prot; }
            set { prot = value; }
        }
        private string gluc;

        public string Gluc
        {
            get { return gluc; }
            set { gluc = value; }
        }
        private string hemogOrina;

        public string HemogOrina
        {
            get { return hemogOrina; }
            set { hemogOrina = value; }
        }
        private string cetonas;

        public string Cetonas
        {
            get { return cetonas; }
            set { cetonas = value; }
        }
        private string bilirrubina;

        public string Bilirrubina
        {
            get { return bilirrubina; }
            set { bilirrubina = value; }
        }
        private string otrosOrina;

        public string OtrosOrina
        {
            get { return otrosOrina; }
            set { otrosOrina = value; }
        }
        private string observacionesLab;

        public string ObservacionesLab
        {
            get { return observacionesLab; }
            set { observacionesLab = value; }
        }
        private string dictamenLab;

        public string DictamenLab
        {
            get { return dictamenLab; }
            set { dictamenLab = value; }
        }
        private string toraxF;

        public string ToraxF
        {
            get { return toraxF; }
            set { toraxF = value; }
        }
        private string lumbarF;

        public string LumbarF
        {
            get { return lumbarF; }
            set { lumbarF = value; }
        }
        private string lumbarP;

        public string LumbarP
        {
            get { return lumbarP; }
            set { lumbarP = value; }
        }
        private string cervicalF;

        public string CervicalF
        {
            get { return cervicalF; }
            set { cervicalF = value; }
        }
        private string cervicalP;

        public string CervicalP
        {
            get { return cervicalP; }
            set { cervicalP = value; }
        }

        private string fnp;

        public string Fnp
        {
            get { return fnp; }
            set { fnp = value; }
        }

        private string mnp;

        public string Mnp
        {
            get { return mnp; }
            set { mnp = value; }
        }

        private string hombrosF;

        public string HombrosF
        {
            get { return hombrosF; }
            set { hombrosF = value; }
        }
        private string rodillasF;

        public string RodillasF
        {
            get { return rodillasF; }
            set { rodillasF = value; }
        }
        private string caderasF;

        public string CaderasF
        {
            get { return caderasF; }
            set { caderasF = value; }
        }
        private string tobillosF;

        public string TobillosF
        {
            get { return tobillosF; }
            set { tobillosF = value; }
        }
        private string craneoFyP;

        public string CraneoFyP
        {
            get { return craneoFyP; }
            set { craneoFyP = value; }
        }
        private string hombroF;

        public string HombroF
        {
            get { return hombroF; }
            set { hombroF = value; }
        }
        private string hombroVP;

        public string HombroVP
        {
            get { return hombroVP; }
            set { hombroVP = value; }
        }
        private string humeroFyP;

        public string HumeroFyP
        {
            get { return humeroFyP; }
            set { humeroFyP = value; }
        }
        private string codoFyP;

        public string CodoFyP
        {
            get { return codoFyP; }
            set { codoFyP = value; }
        }
        private string antebrazoFyP;

        public string AntebrazoFyP
        {
            get { return antebrazoFyP; }
            set { antebrazoFyP = value; }
        }
        private string munecaFyP;

        public string MunecaFyP
        {
            get { return munecaFyP; }
            set { munecaFyP = value; }
        }
        private string manoFyP;

        public string ManoFyP
        {
            get { return manoFyP; }
            set { manoFyP = value; }
        }
        private string toraxP;

        public string ToraxP
        {
            get { return toraxP; }
            set { toraxP = value; }
        }
        private string pCostalFyO;

        public string PCostalFyO
        {
            get { return pCostalFyO; }
            set { pCostalFyO = value; }
        }
        private string colDorsalFyP;

        public string ColDorsalFyP
        {
            get { return colDorsalFyP; }
            set { colDorsalFyP = value; }
        }
        private string pelvisF;

        public string PelvisF
        {
            get { return pelvisF; }
            set { pelvisF = value; }
        }
        private string caderaF;

        public string CaderaF
        {
            get { return caderaF; }
            set { caderaF = value; }
        }
        private string caderaP;

        public string CaderaP
        {
            get { return caderaP; }
            set { caderaP = value; }
        }
        private string femurFyP;

        public string FemurFyP
        {
            get { return femurFyP; }
            set { femurFyP = value; }
        }
        private string rodillaF;

        public string RodillaF
        {
            get { return rodillaF; }
            set { rodillaF = value; }
        }
        private string rodillaP;

        public string RodillaP
        {
            get { return rodillaP; }
            set { rodillaP = value; }
        }
        private string piernaFyP;

        public string PiernaFyP
        {
            get { return piernaFyP; }
            set { piernaFyP = value; }
        }
        private string tobilloFyP;

        public string TobilloFyP
        {
            get { return tobilloFyP; }
            set { tobilloFyP = value; }
        }
        private string axialDeCalcaneo;

        public string AxialDeCalcaneo
        {
            get { return axialDeCalcaneo; }
            set { axialDeCalcaneo = value; }
        }
        private string pieFyP;

        public string PieFyP
        {
            get { return pieFyP; }
            set { pieFyP = value; }
        }
        private string audio;

        public string Audio
        {
            get { return audio; }
            set { audio = value; }
        }
        private string ergo;

        public string Ergo
        {
            get { return ergo; }
            set { ergo = value; }
        }
        private string eco;

        public string Eco
        {
            get { return eco; }
            set { eco = value; }
        }
        private string psico;

        public string Psico
        {
            get { return psico; }
            set { psico = value; }
        }
        private string espiro;

        public string Espiro
        {
            get { return espiro; }
            set { espiro = value; }
        }
        private string eeg;

        public string Eeg
        {
            get { return eeg; }
            set { eeg = value; }
        }
        private string iTorg;

        public string ITorg
        {
            get { return iTorg; }
            set { iTorg = value; }
        }
        private string ecg;

        public string Ecg
        {
            get { return ecg; }
            set { ecg = value; }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        private string dictamen;

        public string Dictamen
        {
            get { return dictamen; }
            set { dictamen = value; }
        }

        private string na;

        public string Na
        {
            get { return na; }
            set { na = value; }
        }

        private string k;

        public string K
        {
            get { return k; }
            set { k = value; }
        }

        private string protTotales;

        public string ProtTotales
        {
            get { return protTotales; }
            set { protTotales = value; }
        }

        private string albumina;

        public string Albumina
        {
            get { return albumina; }
            set { albumina = value; }
        }

        private string alfa1;

        public string ALFA1
        {
            get { return alfa1; }
            set { alfa1 = value; }
        }

        private string alfa2;

        public string ALFA2
        {
            get { return alfa2; }
            set { alfa2 = value; }
        }

        private string beta1;

        public string BETA1 
        {
            get { return beta1; }
            set { beta1 = value; } 
        }

        private string beta2;

        public string BETA2
        {
            get { return beta2; }
            set { beta2 = value; }
        }

        private string gammaglob;

        public string Gammaglob
        {
            get { return gammaglob; }
            set { gammaglob = value; }
        }

        private string relacAlbGlob;

        public string RelacAlbGlob
        {
            get { return relacAlbGlob; }
            set { relacAlbGlob = value; }
        }

        private string creat;

        public string Creat 
        {
            get { return creat; }
            set { creat = value; }
        }

        public ExamenLaboral()
        {
            this.id = new Guid();
            this.antCli = string.Empty;
            this.antQui = string.Empty;
            this.antTrau = string.Empty;
            this.talla = string.Empty;
            this.peso = string.Empty;
            this.entradaAire = string.Empty;
            this.ruidosAgre = string.Empty;
            this.ruidosCard = string.Empty;
            this.silencios = string.Empty;
            this.taMax = string.Empty;
            this.taMin = string.Empty;
            this.pulso = string.Empty;
            this.abdomen = string.Empty;
            this.hernias = string.Empty;
            this.varices = string.Empty;
            this.apGenitour = string.Empty;
            this.pielYFaneras = string.Empty;
            this.apLocomotor = string.Empty;
            this.snc = string.Empty;
            this.ojoDer = string.Empty;
            this.ojoDerLent = string.Empty;
            this.ojoIzq = string.Empty;
            this.ojoIzqLent = string.Empty;
            this.visionCromatica = string.Empty;
            this.exOdonto = string.Empty;
            this.equil = string.Empty;
            this.observacionesCli = string.Empty;
            this.medico = string.Empty;
            this.dictamenCli = string.Empty;
            this.gRojos = string.Empty;
            this.gBlancos = string.Empty;
            this.hemoglobina = string.Empty;
            this.hematocrito = string.Empty;
            this.eritro = string.Empty;
            this.plaquetas = string.Empty;
            this.obsSerieRoja = string.Empty;
            this.cayado = string.Empty;
            this.segmentado = string.Empty;
            this.eosinof = string.Empty;
            this.basof = string.Empty;
            this.linfoc = string.Empty;
            this.monoc = string.Empty;
            this.obsSerieBlanca = string.Empty;
            this.glucemia = string.Empty;
            this.uremia = string.Empty;
            this.chagas = string.Empty;
            this.vdrl = string.Empty;
            this.grupo = string.Empty;
            this.factor = string.Empty;
            this.uricemia = string.Empty;
            this.te = string.Empty;
            this.otrosQuimicaHemat = string.Empty;
            this.colTotal = string.Empty;
            this.hdl = string.Empty;
            this.ldl = string.Empty;
            this.triglic = string.Empty;
            this.otrosPerfilLipidico = string.Empty;
            this.color = string.Empty;
            this.aspecto = string.Empty;
            this.densidad = string.Empty;
            this.ph = string.Empty;
            this.celulas = string.Empty;
            this.leuco = string.Empty;
            this.hematies = string.Empty;
            this.prot = string.Empty;
            this.gluc = string.Empty;
            this.hemogOrina = string.Empty;
            this.cetonas = string.Empty;
            this.bilirrubina = string.Empty;
            this.otrosOrina = string.Empty;
            this.observacionesLab = string.Empty;
            this.dictamenLab = string.Empty;
            this.toraxF = string.Empty;
            this.lumbarF = string.Empty;
            this.lumbarP = string.Empty;
            this.cervicalF = string.Empty;
            this.cervicalP = string.Empty;
            this.fnp = string.Empty;
            this.mnp = string.Empty;
            this.hombrosF = string.Empty;
            this.rodillasF = string.Empty;
            this.caderasF = string.Empty;
            this.tobillosF = string.Empty;
            this.craneoFyP = string.Empty;
            this.hombroF = string.Empty;
            this.hombroVP = string.Empty;
            this.humeroFyP = string.Empty;
            this.codoFyP = string.Empty;
            this.antebrazoFyP = string.Empty;
            this.munecaFyP = string.Empty;
            this.manoFyP = string.Empty;
            this.toraxP = string.Empty;
            this.pCostalFyO = string.Empty;
            this.colDorsalFyP = string.Empty;
            this.pelvisF = string.Empty;
            this.caderaF = string.Empty;
            this.caderaP = string.Empty;
            this.femurFyP = string.Empty;
            this.rodillaF = string.Empty;
            this.rodillaP = string.Empty;
            this.piernaFyP = string.Empty;
            this.tobilloFyP = string.Empty;
            this.axialDeCalcaneo = string.Empty;
            this.pieFyP = string.Empty;
            this.audio = string.Empty;
            this.ergo = string.Empty;
            this.eco = string.Empty;
            this.psico = string.Empty;
            this.espiro = string.Empty;
            this.eeg = string.Empty;
            this.iTorg = string.Empty;
            this.ecg = string.Empty;
            this.observaciones = string.Empty;
            this.dictamen = string.Empty;

            this.na = string.Empty;
            this.k = string.Empty;
            this.protTotales = string.Empty;
            this.albumina = string.Empty;
            this.alfa1 = string.Empty;
            this.alfa2 = string.Empty;
            this.beta1 = string.Empty;
            this.beta2 = string.Empty;
            this.gammaglob = string.Empty;
            this.relacAlbGlob = string.Empty;
            this.creat = string.Empty;
        }
    }
}
