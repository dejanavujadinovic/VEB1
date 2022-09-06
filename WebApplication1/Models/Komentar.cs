using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public Korisnik Posetilac { get; set; }
        public FitnesCentar FitnesCentar { get; set; }
        public string TekstKomentara { get; set; }
        public int Ocena { get; set; }
        public bool Odobren { get; set; }

        public Komentar()
        {
            Posetilac = new Korisnik();
            FitnesCentar = new FitnesCentar();
        }

        public Komentar(string tekstKomentara, int ocena)
        {
            //Posetilac = posetilac;
            //FitnesCentar = fitnesCentar;
            TekstKomentara = tekstKomentara;
            Ocena = ocena;
        }
        public Komentar(int id, string korisnickoIme, int idfc, string tekstKomentara, int ocena, bool odobren)
        {
            Id = id;
            Posetilac = new Korisnik();
            FitnesCentar = new FitnesCentar();
            Posetilac.KorisnickoIme = korisnickoIme;
            FitnesCentar.Id = idfc;
            TekstKomentara = tekstKomentara;
            Ocena = ocena;
            Odobren = odobren;
        }
    }
}