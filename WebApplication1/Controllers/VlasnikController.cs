using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VlasnikController : Controller
    {
        // GET: Vlasnik
        private static bool vecprijavljen; //da li je prijavljen za izabrani trening
        private static bool popunjentermin;
        public ActionResult Index()
        {
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
                return RedirectToAction("Index", "Vlasnik");
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
            return View("~/Views/Vlasnik/Index.cshtml");
        }
        public ActionResult Sortiranje(string vrednost, string nacin)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<FitnesCentar> novaLista = new List<FitnesCentar>();

            if (vrednost == "Naziv")
            {
                if (nacin == "Rastuce")
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
            return View("~/Views/Vlasnik/Index.cshtml");
        }
        public ActionResult Detalji(int id)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];
            List<GrupniTrening> novaLista = new List<GrupniTrening>();
            List<Komentar> novaListaK = new List<Komentar>();
            ViewBag.Centri = fitnescentri;

            foreach (var item in grupnitreninzi)
            {
                if (item.DatumVremeTreninga > DateTime.Now && item.FitnesCentar.Id == id)
                {
                    foreach (var item1 in spisakposetilaca)
                    {
                        foreach (var item2 in korisnici)
                        {
                            if (item.SpisakPosetilaca == null)
                                item.SpisakPosetilaca = new List<Korisnik>();
                            if (item1.KorisnickoImePos == item2.KorisnickoIme)
                            {
                                if (item.Id == item1.Id)
                                {
                                    if (!item.SpisakPosetilaca.Contains(item2))
                                    {
                                        item.SpisakPosetilaca.Add(item2);

                                    }

                                }
                            }
                        }
                    }
                    novaLista.Add(item);
                }
            }
            ViewBag.Treninzi = novaLista;

            foreach (var item in komentari)
            {
                if (item.FitnesCentar.Id == id)
                {
                    if(item.Odobren)
                        novaListaK.Add(item);
                }
            }
            ViewBag.Komentari = novaListaK;

            foreach (var item in fitnescentri)
            {
                if (item.Id == id)
                {
                    ViewBag.Centar = id;
                }
            }
            if (vecprijavljen)
                ViewBag.ErrorMessage = "Vec ste prijavljeni za izabrani trening!";
            else if (popunjentermin)
                ViewBag.ErrorMessage = "Na izabranom terminu vise nema mesta!";
            else
                ViewBag.ErrorMessage = "";
            vecprijavljen = false;
            popunjentermin = false;
            return View("~/Views/Vlasnik/Detalji.cshtml");
        }
        public ActionResult DodajTrenera()
        {
            List<Korisnik> centrivlasnik = (List<Korisnik>)HttpContext.Application["centarvlasnik"];
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<FitnesCentar> novaLista = new List<FitnesCentar>();

            foreach(var item in centrivlasnik)
            {
                if(item.KorisnickoIme==korisnik.KorisnickoIme)
                {
                    foreach(var item1 in fitnescentri)
                    {
                        if(item1.Id==item.IdCentra)
                        {
                            novaLista.Add(item1);
                            break;
                        }
                    }
                }
            }
            if(TempData["Error"]==null)
            {
                TempData["Error"] = "";
            }
            ViewBag.Error = TempData["Error"].ToString();
            ViewBag.CentriVlasnika = novaLista;
            return View();
        }
        [HttpPost]
        public ActionResult DodajTrenera(Korisnik korisnik, string centar)
        {
            int idCentra = 0;
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<Korisnik> trenercentar = (List<Korisnik>)HttpContext.Application["trenercentar"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            foreach(var item in fitnescentri)
            {
                if(item.Naziv==centar)
                {
                    idCentra = item.Id;
                    break;
                }
            }
            TempData["Error"] = "";
            foreach (var item in trenercentar)
            {
                if(item.KorisnickoIme==korisnik.KorisnickoIme)
                {
                    TempData["Error"] = $"Trener sa korisnickim imenom <{korisnik.KorisnickoIme}> vec radi u nekom fitnes centru!";
                    return RedirectToAction("DodajTrenera");
                }
            }
            korisnik.Uloga = Uloga.Trener;
            Podaci.UnesiKorisnika(korisnik);
            Podaci.UnesiTreneraUCentar(idCentra, korisnik.KorisnickoIme);
            korisnici.Add(korisnik);
            trenercentar.Add(korisnik);
            HttpContext.Application["korisnici"] = korisnici;
            HttpContext.Application["trenercentar"] = trenercentar;
            return RedirectToAction("Index");
        }
        public ActionResult MojiCentri()
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<Korisnik> centrivlasnik = (List<Korisnik>)HttpContext.Application["centarvlasnik"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<FitnesCentar> novaLista = new List<FitnesCentar>();

            foreach (var item in centrivlasnik)
            {
                if(item.KorisnickoIme==korisnik.KorisnickoIme)
                {
                    foreach(var item1 in fitnescentri)
                    {
                        if(item.IdCentra==item1.Id)
                        {
                            if(item1.Obrisan==false)
                                novaLista.Add(item1);
                        }
                    }
                }
            }
            if(TempData["zabranjenobrisanje"]==null)
            {
                TempData["zabranjenobrisanje"] = "";
            }
            ViewBag.Error = TempData["zabranjenobrisanje"];
            return View(novaLista);
        }
        public ActionResult DodajCentar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajCentar(FitnesCentar fitnesCentar)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<Korisnik> centrivlasnik = (List<Korisnik>)HttpContext.Application["centarvlasnik"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];

            fitnesCentar.Obrisan = false;
            fitnesCentar.Vlasnik = korisnik;
            fitnesCentar.Id = fitnescentri.Count() + 1;
            Podaci.UnesiFitnesCentar(fitnesCentar);
            Podaci.UnesiCentarVlasnika(fitnesCentar.Id, korisnik.KorisnickoIme);
            fitnescentri.Add(fitnesCentar);
            korisnik.IdCentra = fitnesCentar.Id;
            centrivlasnik.Add(korisnik);
            HttpContext.Application["fitnescentri"] = fitnescentri;
            HttpContext.Application["centarvlasnik"] = centrivlasnik;

            return RedirectToAction("MojiCentri");
        }
        public ActionResult IzmeniCentar(int id)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];

            foreach(var item in fitnescentri)
            {
                if(item.Id==id)
                {
                    ViewBag.Centar = item;
                    break;
                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult IzmeniCentar(FitnesCentar fitnesCentar)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            fitnesCentar.Vlasnik = korisnik;
            foreach (var item in fitnescentri)
            {
                if(item.Id==fitnesCentar.Id)
                {
                    item.Id = fitnesCentar.Id;
                    item.Naziv = fitnesCentar.Naziv;
                    item.Adresa = fitnesCentar.Adresa;
                    item.Vlasnik = korisnik;
                    item.CenaMesecne = fitnesCentar.CenaMesecne;
                    item.CenaGodisnje = fitnesCentar.CenaGodisnje;
                    item.CenaTreninga = fitnesCentar.CenaTreninga;
                    item.CenaGrupnog = fitnesCentar.CenaGrupnog;
                    item.CenaPersonalnog = fitnesCentar.CenaPersonalnog;
                    item.Godina = fitnesCentar.Godina;
                }
            }
            Podaci.IzmeniFitnesCentar(fitnesCentar);
            HttpContext.Application["fitnescentri"] = fitnescentri;
            return RedirectToAction("MojiCentri");
        }
        public ActionResult IzbrisiCentar(int id)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<Korisnik> trenercentar = (List<Korisnik>)HttpContext.Application["trenercentar"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<Korisnik> treninzitrenera = (List<Korisnik>)HttpContext.Application["treneri"];

            bool zabranjenobrisanje = false;
            foreach(var item in grupnitreninzi)
            {
                if(item.FitnesCentar.Id==id)
                {
                    if (item.DatumVremeTreninga > DateTime.Now)
                    {
                        zabranjenobrisanje = true;
                        break;
                    }
                }
            }
            if (!zabranjenobrisanje)
            {
                foreach (var item in fitnescentri)
                {
                    if (item.Id == id)
                    {
                        item.Obrisan = true;


                        foreach (var item1 in trenercentar)
                        {
                            if (item1.IdCentra == item.Id)
                            {
                                foreach (var item2 in korisnici)
                                {
                                    if (item2.KorisnickoIme == item1.KorisnickoIme)
                                    {
                                        item2.ZabranaPrijave = true;
                                        Podaci.IzmeniKorisnika(item2);

                                    }
                                }
                            }
                        }
                        Podaci.IzmeniFitnesCentar(item);
                        //break;
                    }
                }
                HttpContext.Application["fitnescentri"] = fitnescentri;
                HttpContext.Application["korisnici"] = korisnici;
            }
            else
            {
                TempData["zabranjenobrisanje"] = "Ne mozete brisati fitnes centar u kome ima zakazanih treninga!";
            }
            return RedirectToAction("MojiCentri");
        }
        public ActionResult Zaposleni()
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<Korisnik> trenercentar = (List<Korisnik>)HttpContext.Application["trenercentar"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<Korisnik> novaLista = new List<Korisnik>();

            foreach (var item in fitnescentri)
            {
                if(item.Vlasnik.KorisnickoIme==korisnik.KorisnickoIme)
                {
                    foreach(var item1 in trenercentar)
                    {
                        if(item1.IdCentra==item.Id)
                        {
                            foreach(var item2 in korisnici)
                            {
                                if(item1.KorisnickoIme==item2.KorisnickoIme)
                                {
                                    if(item2.ZabranaPrijave==false)
                                        novaLista.Add(item2);
                                }
                            }
                        }
                    }
                }
            }
            ViewBag.Zaposleni = novaLista;

            return View();
        }
        public ActionResult BlokirajTrenera(string korisnickoIme)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            foreach(var item in korisnici)
            {
                if(item.KorisnickoIme==korisnickoIme)
                {
                    item.ZabranaPrijave = true;
                    Podaci.IzmeniKorisnika(item);
                    break;
                }
            }
            HttpContext.Application["korisnici"] = korisnici;
            return RedirectToAction("Zaposleni");
        }
        public ActionResult Komentari()
        {
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];
            List<FitnesCentar> centri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<Komentar> novaLista = new List<Komentar>();

            
            korisnik.FitnesCentarVlasnik = new List<FitnesCentar>();
            

            foreach(var item in centri)
            {
                if(korisnik.KorisnickoIme==item.Vlasnik.KorisnickoIme)
                {
                    korisnik.FitnesCentarVlasnik.Add(item);
                }
            }
            foreach (var item in komentari)
            {
                if(item.Odobren==false)
                {
                    foreach(var item1 in korisnik.FitnesCentarVlasnik)
                    {
                        if (item1.Id == item.FitnesCentar.Id)
                            novaLista.Add(item);
                    }
                }
                foreach (var item2 in centri)
                {
                    if (item2.Id == item.FitnesCentar.Id)
                    {
                        item.FitnesCentar.Naziv = item2.Naziv;
                        break;
                    }
                }
            }
            
            ViewBag.Komentari = novaLista;
            return View();
        }
        public ActionResult OdobriKomentar(int id)
        {
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];

            foreach(var item in komentari)
            {
                if(item.Id==id)
                {
                    item.Odobren = true;
                    Podaci.IzmeniKomentar(item);
                    break;
                }
            }

            HttpContext.Application["komentari"] = komentari;
            return RedirectToAction("Komentari");
        }
    }
}