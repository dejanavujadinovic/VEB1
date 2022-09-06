using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum TipTreninga
    {
        yoga,
        les_mills_tone,
        body_pump
    }
    public class GrupniTrening
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string TipTreninga { get; set; }
        public FitnesCentar FitnesCentar { get; set; }
        public float TrajanjeTreninga { get; set; }
        public DateTime DatumVremeTreninga { get; set ; }
        public int MaxPosetilaca { get; set; }
        public List<Korisnik> SpisakPosetilaca { get; set; }
        public string KorisnickoImePos { get; set; }
        public bool Obrisan { get; set; }
        public string FormatiranDatum
        {
            get
            {
                return DatumVremeTreninga.ToString("dd/MM/yyyy HH:mm");
            }
        }

        public GrupniTrening()
        {

        }

        public GrupniTrening(int id, string naziv, string tipTreninga, int idfc, float trajanjeTreninga, DateTime datumVremeTreninga, int maxPosetilaca, bool obrisan)
        {
            Id = id;
            Naziv = naziv;
            TipTreninga = tipTreninga;
            FitnesCentar = new FitnesCentar();
            FitnesCentar.Id = idfc;
            TrajanjeTreninga = trajanjeTreninga;
            DatumVremeTreninga = datumVremeTreninga;
            MaxPosetilaca = maxPosetilaca;
            Obrisan = obrisan;
            //SpisakPosetilaca = new List<Korisnik>();
        }
        public GrupniTrening(int id, string korisnickoime)
        {
            Id = id;
            KorisnickoImePos = korisnickoime;
        }
    }  
}