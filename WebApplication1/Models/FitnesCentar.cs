using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FitnesCentar
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int Godina { get; set; }
        public Korisnik Vlasnik { get; set; }
        public float CenaMesecne { get; set; }
        public float CenaGodisnje { get; set; }
        public float CenaTreninga { get; set; }
        public float CenaGrupnog { get; set; }
        public float CenaPersonalnog { get; set; }
        public bool Obrisan { get; set; }

        public FitnesCentar()
        {

        }

        public FitnesCentar(int id, string naziv, string adresa, int godina, string korisnickoIme, float cenaMesecne, float cenaGodisnje, float cenaTreninga, float cenaGrupnog, float cenaPersonalnog, bool obrisan)
        {
            Id = id;
            Naziv = naziv;
            Adresa = adresa;
            Godina = godina;
            Vlasnik = new Korisnik();
            Vlasnik.KorisnickoIme = korisnickoIme;
            CenaMesecne = cenaMesecne;
            CenaGodisnje = cenaGodisnje;
            CenaTreninga = cenaTreninga;
            CenaGrupnog = cenaGrupnog;
            CenaPersonalnog = cenaPersonalnog;
            Obrisan = obrisan;
        }
        public FitnesCentar(int id, string naziv, string adresa, int godina, float cenaMesecne, float cenaGodisnje, float cenaTreninga, float cenaGrupnog, float cenaPersonalnog)
        {
            Id = id;
            Naziv = naziv;
            Adresa = adresa;
            Godina = godina;
            CenaMesecne = cenaMesecne;
            CenaGodisnje = cenaGodisnje;
            CenaTreninga = cenaTreninga;
            CenaGrupnog = cenaGrupnog;
            CenaPersonalnog = cenaPersonalnog;
        }
    }
}