using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApplication1.Models
{
    public class Podaci
    {
        public static List<FitnesCentar> CitajFitnesCentre(string path)
        {
            List<FitnesCentar> fitnescentri = new List<FitnesCentar>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                FitnesCentar p = new FitnesCentar(int.Parse(tokens[0]), tokens[1], tokens[2], int.Parse(tokens[3]), tokens[4], float.Parse(tokens[5]), float.Parse(tokens[6]), float.Parse(tokens[7]), float.Parse(tokens[8]), float.Parse(tokens[9]), bool.Parse(tokens[10]));
                fitnescentri.Add(p);
            }
            sr.Close();
            stream.Close();

            return fitnescentri;
        }
        public static void UnesiFitnesCentar(FitnesCentar centar)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/fitnescentri.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"{centar.Id};{centar.Naziv};{centar.Adresa};{centar.Godina};{centar.Vlasnik.KorisnickoIme};{centar.CenaMesecne};{centar.CenaGodisnje};{centar.CenaTreninga};{centar.CenaGrupnog};{centar.CenaPersonalnog};{centar.Obrisan}");
            sw.Close();
            stream.Close();
        }
        public static List<GrupniTrening> CitajGrupneTreninge(string path)
        {
            List<GrupniTrening> grupnitreninzi = new List<GrupniTrening>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                GrupniTrening p = new GrupniTrening(int.Parse(tokens[0]), tokens[1], tokens[2], int.Parse(tokens[3]), float.Parse(tokens[4]), DateTime.Parse(tokens[5]), int.Parse(tokens[6]), bool.Parse(tokens[7]));
                grupnitreninzi.Add(p);
            }
            sr.Close();
            stream.Close();

            return grupnitreninzi;
        }
        public static void UnesiGrupniTrening(GrupniTrening trening)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/grupnitreninzi.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"{trening.Id};{trening.Naziv};{trening.TipTreninga};{trening.FitnesCentar.Id};{trening.TrajanjeTreninga};{trening.DatumVremeTreninga};{trening.MaxPosetilaca};{trening.Obrisan}");
            sw.Close();
            stream.Close();
        }
        public static List<Komentar> CitajKomentare(string path)
        {
            List<Komentar> grupnitreninzi = new List<Komentar>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Komentar p = new Komentar(int.Parse(tokens[0]), tokens[1], int.Parse(tokens[2]), tokens[3], int.Parse(tokens[4]), bool.Parse(tokens[5]));
                grupnitreninzi.Add(p);
            }
            sr.Close();
            stream.Close();

            return grupnitreninzi;
        }
        public static void UnesiKomentar(Komentar komentar)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/komentari.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);
            
            sw.WriteLine($"{komentar.Id};{komentar.Posetilac.KorisnickoIme};{komentar.FitnesCentar.Id};{komentar.TekstKomentara};{komentar.Ocena};{komentar.Odobren}");
            sw.Close();
            stream.Close();
        }
        public static List<Korisnik> CitajKorisnike(string path)
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Korisnik p = new Korisnik(tokens[0], tokens[1], tokens[2], tokens[3], (Pol)Enum.Parse(typeof(Pol), tokens[4]), tokens[5], DateTime.Parse(tokens[6]), (Uloga)Enum.Parse(typeof(Uloga),tokens[7]), bool.Parse(tokens[8]));
                korisnici.Add(p);
            }
            sr.Close();
            stream.Close();

            return korisnici;
        }
        public static void UnesiKorisnika(Korisnik korisnik)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/korisnici.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"{korisnik.KorisnickoIme};{korisnik.Lozinka};{korisnik.Ime};{korisnik.Prezime};{korisnik.Pol};{korisnik.Email};{korisnik.DatumRodjenja};{korisnik.Uloga};{korisnik.ZabranaPrijave}");
            sw.Close();
            stream.Close();
        }
        public static void UnesiKorisnikaNaTrening(int id, string korisnickoIme)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/spisakposetilaca.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"{id};{korisnickoIme}");
            sw.Close();
            stream.Close();
        }
        public static List<GrupniTrening> CitajSpisakPosetilaca(string path)
        {
            List<GrupniTrening> spisakPosetilaca = new List<GrupniTrening>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                GrupniTrening p = new GrupniTrening(int.Parse(tokens[0]), tokens[1]);
                spisakPosetilaca.Add(p);
            }
            sr.Close();
            stream.Close();

            return spisakPosetilaca;
        }
        public static List<Korisnik> CitajTreningeTrenera(string path)
        {
            List<Korisnik> treninzitrenra = new List<Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Korisnik p = new Korisnik(tokens[0], int.Parse(tokens[1]));
                treninzitrenra.Add(p);
            }
            sr.Close();
            stream.Close();

            return treninzitrenra;
        }
        public static void UnesiTreningTrenera(string korisnickoIme, int id)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/treneri.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"{korisnickoIme};{id}");
            sw.Close();
            stream.Close();
        }
        public static List<Korisnik> CitajCentreTrenera(string path)
        {
            List<Korisnik> centritrenera = new List<Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Korisnik p = new Korisnik(int.Parse(tokens[0]), tokens[1]);
                centritrenera.Add(p);
            }
            sr.Close();
            stream.Close();

            return centritrenera;
        }
        public static void IzmeniTrening(GrupniTrening trening)
        {
            string path = HttpContext.Current.Server.MapPath(@"~/App_Data/grupnitreninzi.txt");
            string[] lines = File.ReadAllLines(path);
            //List<string> newLines = new List<string>();
            for(int i=0; i<lines.Count(); i++)
            {
                string[] tokens = lines[i].Split(';');
                if(int.Parse(tokens[0])==trening.Id)
                {
                    lines[i] = $"{trening.Id};{trening.Naziv};{trening.TipTreninga};{trening.FitnesCentar.Id};{trening.TrajanjeTreninga};{trening.DatumVremeTreninga};{trening.MaxPosetilaca};{trening.Obrisan}";
                }
            }
            File.WriteAllLines(path, lines);
        }
        public static List<Korisnik> CitajCentreVlasnika(string path)
        {
            List<Korisnik> centritrenera = new List<Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Korisnik p = new Korisnik(int.Parse(tokens[0]), tokens[1]);
                centritrenera.Add(p);
            }
            sr.Close();
            stream.Close();

            return centritrenera;
        }
        public static void UnesiCentarVlasnika(int id, string korisnickoIme)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/centarvlasnik.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"{id};{korisnickoIme}");
            sw.Close();
            stream.Close();
        }    
        public static void UnesiTreneraUCentar(int id, string korisnickoIme)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/trenercentar.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"{id};{korisnickoIme}");
            sw.Close();
            stream.Close();
        }
        public static void IzmeniFitnesCentar(FitnesCentar centar)
        {
            string path = HttpContext.Current.Server.MapPath(@"~/App_Data/fitnescentri.txt");
            string[] lines = File.ReadAllLines(path);
            //List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] tokens = lines[i].Split(';');
                if (int.Parse(tokens[0]) == centar.Id)
                {
                    lines[i] = $"{centar.Id};{centar.Naziv};{centar.Adresa};{centar.Godina};{centar.Vlasnik.KorisnickoIme};{centar.CenaMesecne};{centar.CenaGodisnje};{centar.CenaTreninga};{centar.CenaGrupnog};{centar.CenaPersonalnog};{centar.Obrisan}";
                }
            }
            File.WriteAllLines(path, lines);
        }
        public static void IzmeniKorisnika(Korisnik korisnik)
        {
            string path = HttpContext.Current.Server.MapPath(@"~/App_Data/korisnici.txt");
            string[] lines = File.ReadAllLines(path);
            //List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] tokens = lines[i].Split(';');
                if (tokens[0] == korisnik.KorisnickoIme)
                {
                    lines[i] = $"{korisnik.KorisnickoIme};{korisnik.Lozinka};{korisnik.Ime};{korisnik.Prezime};{korisnik.Pol};{korisnik.Email};{korisnik.DatumRodjenja};{korisnik.Uloga};{korisnik.ZabranaPrijave}";
                }
            }
            File.WriteAllLines(path, lines);
        }
        public static void IzmeniKomentar(Komentar komentar)
        {
            //string path = @"C:\Users\dejan\Desktop\VEB1\WebApplication1\WebApplication1\App_Data\komentari.txt";
            string path = HttpContext.Current.Server.MapPath(@"~/App_Data/komentari.txt");
            string[] lines = File.ReadAllLines(path);
            //List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] tokens = lines[i].Split(';');
                if (int.Parse(tokens[0]) == komentar.Id)
                {
                    lines[i] = $"{komentar.Id};{komentar.Posetilac.KorisnickoIme};{komentar.FitnesCentar.Id};{komentar.TekstKomentara};{komentar.Ocena};{komentar.Odobren}";
                }
            }
            File.WriteAllLines(path, lines);
        }
    }
}