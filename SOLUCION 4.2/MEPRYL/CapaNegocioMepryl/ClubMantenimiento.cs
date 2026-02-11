using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using CapaDatosMepryl;

namespace CapaNegocioMepryl
{
    public class ClubMantenimiento
    {
        private CapaDatosMepryl.ClubMantenimiento Club; 

        public ClubMantenimiento()
        {
            Club = new CapaDatosMepryl.ClubMantenimiento();
            // Constructor
        }

        public DataTable MostrarClubConFiltro(string strFiltro)
        {
            return Club.MostrarClubConFiltro(strFiltro);
        }

        public DataTable MostrarClubConFiltro(string strFiltro, string strFiltro2)
        {
            return Club.MostrarClubConFiltro(strFiltro, strFiltro2);
        }

        public bool ActualizarClub(DataTable dtTabla)
        {
            return Club.ActualizarClub(dtTabla);
        }

        public bool EliminarClub(string strID)
        {
            return Club.EliminarClub(strID);
        }

        public string LigaDelClub(string strNombreClub)
        {
            return Club.LigaDelClub(strNombreClub);
        }

        public DataTable LigaDelClubPorNombre(string strNombreClub)
        {
            return Club.LigaDelClubPorNombre(strNombreClub);
        }
    }
}
