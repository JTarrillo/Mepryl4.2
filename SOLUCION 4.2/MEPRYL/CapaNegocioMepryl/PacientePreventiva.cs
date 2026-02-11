using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class PacientePreventiva
    {
        private CapaDatosMepryl.PacientePreventiva PacientePre;
        public int CodigoRX = 0;

        public PacientePreventiva()
        {
            //Constructor
            PacientePre = new CapaDatosMepryl.PacientePreventiva();
            CodigoRX = PacientePre.CodigoRX;
        }

        public DataTable ListarLigaActiva()
        {
            return PacientePre.ListarLigaActiva();
        }

        public DataTable ListarLigaNoInfantil()
        {
            return PacientePre.ListarLigaNoInfantil();
        }

        public bool PerteneceLigaInfantil(string IdClub)
        {
            return PacientePre.PerteneceLigaInfantil(IdClub);
        }

        public bool PerteneceClubAFA(string IdClub)
        {
            return PacientePre.PerteneceClubAFA(IdClub);
        }

        public int AnioCategoriaJuvenil(string IdLiga)
        {
            return PacientePre.AnioCategoriaJuvenil(IdLiga);
        }

        public DateTime FechaUltimoExamen(string strDNI)
        {
            return PacientePre.FechaUltimoExamen(strDNI);
        }

        public bool DebeRealizarExamenRX(string strDNI)
        {
            return PacientePre.DebeRealizarExamenRX(strDNI);
        }

        public bool VerificaRX(string IdLiga)
        {
            return PacientePre.VerificaRX(IdLiga);
        }

        public bool VerificaClub(string IdLiga)
        {
            return PacientePre.VerificaClub(IdLiga);
        }

        public bool VerificaAdmiteMenores(string IdLiga)
        {
            return PacientePre.VerificaAdmiteMenores(IdLiga);
        }

        public int AnioCategoriaInfantil(string IdLiga)
        {
            return PacientePre.AnioCategoriaInfantil(IdLiga);
        }

        public bool LigaEstaActiva(string strIdLiga)
        {
            return PacientePre.LigaEstaActiva(strIdLiga);
        }

        public DateTime FechaUltimoExamenAFA(string strDNI)
        {
            return PacientePre.FechaUltimoExamenAFA(strDNI);
        }

        public DateTime FechaUltimoExamenLIGA(string strDNI)
        {
            return PacientePre.FechaUltimoExamenLIGA(strDNI);
        }

        public int ObtenerCodigoTipoExamen(string strDNI)
        {
            return PacientePre.ObtenerCodigoTipoExamen(strDNI);
        }

        public DataTable ListarLigaNoJuvenil()
        {
            return PacientePre.ListarLigaNoJuvenil();
        }

        public int CategoriaPaciente(string strDNI)
        {
            return PacientePre.CategoriaPaciente(strDNI);
        }

        public string ObtenerDNIpaciente(string strIdPaciente)
        {
            return PacientePre.ObtenerDNIpaciente(strIdPaciente);
        }

        public DateTime FechaExamenEsteAnio(string strDNI)
        {
            return PacientePre.FechaExamenEsteAnio(strDNI);
        }

        public bool ClubPerteneceAFA(string strIdLiga)
        {
            return PacientePre.ClubPerteneceAFA(strIdLiga);
        }

        public DataTable ListarLigaNoJuvenilNoInfantil()
        {
            return PacientePre.ListarLigaNoJuvenilNoInfantil();
        }

        public bool ExistePaciente(string strDNI)
        {
            return PacientePre.ExistePaciente(strDNI);
        }

        public DataTable ListaLigaPorCategoria(int intCategoria)
        {
            return PacientePre.ListaLigaPorCategoria(intCategoria);
        }

        public string VerMail(string strDNI)
        {
            return PacientePre.VerMail(strDNI);
        }

        public bool ActualizarMail(string strDNI, string strMail)
        {
            return PacientePre.ActualizarMail(strDNI, strMail);
        }

        public bool VerificaTieneExamenAFAInfantil(string strDNI)
        {
            return PacientePre.VerificaTieneExamenAFAInfantil(strDNI);
        }

        public DataTable ListarLigaCategoriaDescripcion(int intCategoria, string strDescripcion)
        {
            return PacientePre.ListarLigaCategoriaDescripcion(intCategoria, strDescripcion);
        }

        public DataTable ListarPacientePorDNI(string strDNI)
        {
            return PacientePre.ListarPacientePorDNI(strDNI);
        }
        }
}
