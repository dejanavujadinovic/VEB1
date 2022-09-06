using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //List<FitnesCentar> novaLista = new List<FitnesCentar>();
        // GET: Home
        public ActionResult Index()
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            if(korisnik==null)
            {
                
            }
            else if(korisnik.Uloga==Uloga.Posetilac)
            {
                return RedirectToAction("Index", "Posetilac");
            }
            else if(korisnik.Uloga==Uloga.Trener)
            {
                return RedirectToAction("Index", "Trener");
            }
            else if(korisnik.Uloga==Uloga.Vlasnik)
            {
                return RedirectToAction("Index", "Vlasnik");
            }
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            var novaLista = fitnescentri.OrderBy(x => x.Naziv).ToList(); //sortirani po nazivu
            ViewBag.Centri = novaLista;
            return View();
        }
        public ActionResult Pretraga(string naziv, string adresa, string minvrednost, string maxvrednost)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<FitnesCentar> novaLista = new List<FitnesCentar>();

            if (naziv == "" && adresa == "" && minvrednost == "" && maxvrednost == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else if (naziv != "" && adresa == "" && minvrednost == "" && maxvrednost == "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv)
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa != "" && minvrednost == "" && maxvrednost == "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Adresa == adresa)
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa == "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Godina >= int.Parse(minvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa == "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa == "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Godina >= int.Parse(minvrednost) && item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv != "" && adresa != "" && minvrednost == "" && maxvrednost == "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv && item.Adresa == adresa)
                        novaLista.Add(item);
                }
            }
            else if (naziv != "" && adresa == "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv && item.Godina >= int.Parse(minvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv != "" && adresa == "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv && item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv != "" && adresa == "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv && item.Godina >= int.Parse(minvrednost) && item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa != "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Adresa == adresa && item.Godina >= int.Parse(minvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa != "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Adresa == adresa && item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa != "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Adresa == adresa && item.Godina >= int.Parse(minvrednost) && item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv != "" && adresa != "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv && item.Adresa == adresa && item.Godina >= int.Parse(minvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv != "" && adresa != "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv && item.Adresa == adresa && item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }
            else if (naziv == "" && adresa != "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Naziv == naziv && item.Adresa == adresa && item.Godina >= int.Parse(minvrednost) && item.Godina <= int.Parse(maxvrednost))
                        novaLista.Add(item);
                }
            }

            if (naziv == "" && adresa == "" && minvrednost == "" && maxvrednost == "")
                ViewBag.Centri = fitnescentri;
            else
                ViewBag.Centri = novaLista;
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult Sortiranje(string vrednost, string nacin)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<FitnesCentar> novaLista = new List<FitnesCentar>();

            if (vrednost=="Naziv")
            {
                if(nacin=="Rastuce")
                {
                    novaLista = fitnescentri.OrderBy(x => x.Naziv).ToList();
                }
                else
                {
                    novaLista = fitnescentri.OrderByDescending(x => x.Naziv).ToList();
                }
            }
            else if (vrednost == "Adresa")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = fitnescentri.OrderBy(x => x.Adresa).ToList();
                }
                else
                {
                    novaLista = fitnescentri.OrderByDescending(x => x.Adresa).ToList();
                }
            }
            else if (vrednost == "Godina")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = fitnescentri.OrderBy(x => x.Godina).ToList();
                }
                else
                {
                    novaLista = fitnescentri.OrderByDescending(x => x.Godina).ToList();
                }
            }
            if (nacin == "" && vrednost == "")
                ViewBag.Centri = fitnescentri;
            else
                ViewBag.Centri = novaLista;
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult Detalji(int id)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<GrupniTrening> novaLista = new List<GrupniTrening>();
            List<Komentar> novaListaK = new List<Komentar>();
            ViewBag.Centri = fitnescentri;
            
            foreach(var item in grupnitreninzi)
            {
                if (item.SpisakPosetilaca == null)
                    item.SpisakPosetilaca = new List<Korisnik>();
                foreach (var item1 in spisakposetilaca)
                {
                    if (item1.Id == item.Id)
                    {
                        foreach(var item2 in korisnici)
                        {
                            if(item1.KorisnickoImePos == item2.KorisnickoIme)
                            {
                                item.SpisakPosetilaca.Add(item2);
                            }
                        }
                    }
                }
                if (item.DatumVremeTreninga > DateTime.Now && item.FitnesCentar.Id==id)
                {
                    novaLista.Add(item);
                }                                
            }
            ViewBag.Treninzi = novaLista;

            foreach(var item in komentari)
            {
                if(item.FitnesCentar.Id==id)
                {
                    if(item.Odobren)
                        novaListaK.Add(item);
                }
            }
            ViewBag.Komentari = novaListaK;

            foreach (var item in fitnescentri)
            {
                if(item.Id==id)
                {
                    ViewBag.Centar = id;
                }                
            }
            return View("~/Views/Home/Detalji.cshtml");
        }
        public ActionResult Registracija()
        {
            //Korisnik korisnik = new Korisnik();
            //Session["korisnik"] = korisnik;
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult Registracija(Korisnik korisnik)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            ViewBag.Error = "";
            foreach (var item in korisnici)
            {
                if(item.KorisnickoIme==korisnik.KorisnickoIme)
                {
                    ViewBag.Error = $"Korisnicko ime <{korisnik.KorisnickoIme}> vec postoji! Molimo izaberite drugo korisnicko ime!";
                    return View();
                }
            }
            korisnici.Add(korisnik);
            Podaci.UnesiKorisnika(korisnik);
            HttpContext.Application["korisnici"] = korisnici;
            Session["korisnik"] = korisnik;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Prijava()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult Prijava(string korisnickoIme, string lozinka)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            ViewBag.Error = "";
            foreach (var k in korisnici)
            {
                if (k.ZabranaPrijave == false)
                {
                    if (k.KorisnickoIme == korisnickoIme && k.Lozinka == lozinka)
                    {
                        Session["korisnik"] = k;
                        if (k.Uloga == Uloga.Posetilac)
                        {
                            return RedirectToAction("Index", "Posetilac");
                        }
                        else if (k.Uloga == Uloga.Trener)
                        {
                            return RedirectToAction("Index", "Trener");
                        }
                        else if (k.Uloga == Uloga.Vlasnik)
                        {
                            return RedirectToAction("Index", "Vlasnik");
                        }
                    }                    
                }
            }
            ViewBag.Error = "Neispravno korisnicko ime ili lozinka!";
            return View();
        }
        public static string pomKorIme;
        public ActionResult UrediProfil()
        {
            //List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            ViewBag.Error = "";
            Korisnik korisnik = (Korisnik)Session["korisnik"];

            if(korisnik == null)
            {
                return RedirectToAction("NijePrijavljen", "Home");
            }
            pomKorIme = korisnik.KorisnickoIme;
            ViewBag.Profil = korisnik;

            return View();
        }
        [HttpPost]
        public ActionResult UrediProfil(Korisnik korisnik)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik k = (Korisnik)Session["korisnik"];
            ViewBag.Error = "";
            foreach (var item in korisnici)
            {
                //if(item.KorisnickoIme==korisnik.KorisnickoIme)
                //{
                //    ViewBag.Error = $"Korisnicko ime <{korisnik.KorisnickoIme}> vec postoji! Molimo izaberite drugo korisnicko ime!";
                //    return View();
                //}
                if(item.KorisnickoIme==pomKorIme)
                {
                    item.KorisnickoIme = k.KorisnickoIme;
                    item.Lozinka = korisnik.Lozinka;
                    item.Ime = korisnik.Ime;
                    item.Prezime = korisnik.Prezime;
                    item.Pol = korisnik.Pol;
                    item.Email = korisnik.Email;
                    item.DatumRodjenja = korisnik.DatumRodjenja;
                    item.Uloga = k.Uloga;
                    Podaci.IzmeniKorisnika(item);

                }
            }
            HttpContext.Application["korisnici"] = korisnici;
            return RedirectToAction("Index");
        }
        public ActionResult NijePrijavljen()
        {
            return View();
        }
        public ActionResult Odjava()
        {
            Session["korisnik"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}