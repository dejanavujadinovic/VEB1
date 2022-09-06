using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum Pol
    {
        Musko,
        Zensko
    }
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Uloga Uloga { get; set; }
        public List<GrupniTrening> GrupniTreninziPrijavljen { get; set; }
        public List<GrupniTrening> GrupniTreninziAngazovan { get; set; }
        public FitnesCentar FitnesCentarAngazovan { get; set; }       
        public List<FitnesCentar> FitnesCentarVlasnik { get; set; }
        public int IdTreninga { get; set; }
        public int IdCentra { get; set; }
        public bool ZabranaPrijave { get; set; }
        public string FormatiranDatum
        {
            get
            {
                return DatumRodjenja.ToString("dd/MM/yyyy");
            }
        }
        //public int IdCentraVlasnik { get; set; }
        
        

        public Korisnik()
        {
            //DatumRodjenja.Date.ToString();
        }

        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, Pol pol, string email, DateTime datumRodjenja, Uloga uloga, bool zabranaPrijave)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
            ZabranaPrijave = zabranaPrijave;
        }
        public Korisnik(string korisnickoIme, int id)
        {
            KorisnickoIme = korisnickoIme;
            IdTreninga = id;
        }
        public Korisnik(int id, string korime)
        {
            KorisnickoIme = korime;
            IdCentra = id;
        }
    }
}