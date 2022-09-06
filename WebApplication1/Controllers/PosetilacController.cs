using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PosetilacController : Controller
    {
        private int IdFC;   //id fitnes centra za koji se prikazuju detalji
        private static bool vecprijavljen; //da li je prijavljen za izabrani trening
        private static bool popunjentermin;
        // GET: Posetilac
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
                return RedirectToAction("Index", "Posetilac");
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
            return View("~/Views/Posetilac/Index.cshtml");
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
            return View("~/Views/Posetilac/Index.cshtml");
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
                if (item.DatumVremeTreninga > DateTime.Now && item.FitnesCentar.Id==id)
                {
                    foreach(var item1 in spisakposetilaca)
                    {
                        foreach(var item2 in korisnici)
                        {
                            if (item.SpisakPosetilaca == null)
                                item.SpisakPosetilaca = new List<Korisnik>();
                            if(item1.KorisnickoImePos==item2.KorisnickoIme)
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
            else if(popunjentermin)
                ViewBag.ErrorMessage = "Na izabranom terminu vise nema mesta!";
            else
                ViewBag.ErrorMessage = "";
            vecprijavljen = false;
            popunjentermin = false;
            return View("~/Views/Posetilac/Detalji.cshtml");
        }
        public ActionResult PrijavaNaTrening(int id)
        {
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];

            foreach(var item in spisakposetilaca)
            {
                foreach(var item2 in korisnici)
                {
                    if(item.KorisnickoImePos==item2.KorisnickoIme)
                    {
                        foreach(var item3 in grupnitreninzi)
                        {
                            if (item3.SpisakPosetilaca == null)
                                item3.SpisakPosetilaca = new List<Korisnik>();
                            if(item.Id==item3.Id)
                                if(!item3.SpisakPosetilaca.Contains(item2))
                                    item3.SpisakPosetilaca.Add(item2);
                        }
                        
                    }
                }
            }

            foreach(var item in grupnitreninzi)
            {
                if (item.SpisakPosetilaca == null)
                    item.SpisakPosetilaca = new List<Korisnik>();
                if(item.Id==id)
                {
                    IdFC = item.FitnesCentar.Id;

                    if (!item.SpisakPosetilaca.Contains(korisnik) && item.MaxPosetilaca > item.SpisakPosetilaca.Count)
                    {
                        item.SpisakPosetilaca.Add(korisnik);
                        Podaci.UnesiKorisnikaNaTrening(item.Id, korisnik.KorisnickoIme);
                        spisakposetilaca.Add(item);
                        vecprijavljen = false;
                        popunjentermin = false;
                    }
                    else if (item.SpisakPosetilaca.Contains(korisnik))
                        vecprijavljen = true;
                    else if (item.MaxPosetilaca <= item.SpisakPosetilaca.Count)
                        popunjentermin = true;
                }               
            }

            HttpContext.Application["spisakposetilaca"] = spisakposetilaca;
            return RedirectToAction("Detalji", new { id=IdFC});
        }
        private static List<GrupniTrening> istorijatreninga;
        public ActionResult IstorijaTreninga()
        {
            istorijatreninga = new List<GrupniTrening>();
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            //List<GrupniTrening> novaLista = new List<GrupniTrening>();
            if(istorijatreninga==null)
            {
                istorijatreninga = new List<GrupniTrening>();
            }
            foreach(var item in spisakposetilaca)
            {
                if(item.SpisakPosetilaca==null)
                {
                    item.SpisakPosetilaca = new List<Korisnik>();
                }                
                foreach(var item2 in korisnici)
                {                    
                    if(item.KorisnickoImePos==item2.KorisnickoIme)
                    {
                        item.SpisakPosetilaca.Add(item2);
                    }
                }
                if (item.SpisakPosetilaca.Contains(korisnik))
                {
                    foreach(var item3 in grupnitreninzi)
                    {
                        if(item.Id==item3.Id)
                        {
                            if(item3.DatumVremeTreninga<DateTime.Now)
                                istorijatreninga.Add(item3);
                        }
                    }
                }
            }            
            
            ViewBag.SpisakTreninga = istorijatreninga;
            return View(fitnescentri);
        }
        public ActionResult PretragaT(string naziv, string tip, string nazivfitnesc)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<GrupniTrening> pomLista = new List<GrupniTrening>();

            foreach(var item in grupnitreninzi)
            {
                foreach(var item1 in fitnescentri)
                {
                    if(item.FitnesCentar.Id==item1.Id)
                    {
                        item.FitnesCentar = item1;
                        break;
                    }
                }
            }

            if (naziv == "" && tip == "" && nazivfitnesc == "")
            {
                return RedirectToAction("IstorijaTreninga", "Posetilac");
            }
            else if (naziv == "" && tip == "" && nazivfitnesc != "")
            {
                foreach(var item in istorijatreninga)
                {
                    if (item.FitnesCentar.Naziv == nazivfitnesc)
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip != "" && nazivfitnesc == "")
            {
                foreach (var item in istorijatreninga)
                {
                    if (item.TipTreninga == tip)
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip == "" && nazivfitnesc == "")
            {
                foreach (var item in istorijatreninga)
                {
                    if (item.Naziv == naziv)
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip != "" && nazivfitnesc != "")
            {
                foreach (var item in istorijatreninga)
                {
                    if (item.FitnesCentar.Naziv == nazivfitnesc && item.TipTreninga == tip)
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip == "" && nazivfitnesc != "")
            {
                foreach (var item in istorijatreninga)
                {
                    if (item.FitnesCentar.Naziv == nazivfitnesc && item.Naziv == naziv)
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip != "" && nazivfitnesc == "")
            {
                foreach (var item in istorijatreninga)
                {
                    if (item.Naziv == naziv && item.TipTreninga == tip)
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip != "" && nazivfitnesc != "")
            {
                foreach (var item in istorijatreninga)
                {
                    if (item.Naziv == naziv && item.TipTreninga == tip && item.FitnesCentar.Naziv == nazivfitnesc)
                        pomLista.Add(item);
                }
            }
            
            ViewBag.SpisakTreninga = pomLista;
            //istorijatreninga = new List<GrupniTrening>();
            return View("~/Views/Posetilac/IstorijaTreninga.cshtml", fitnescentri);
        }
        public ActionResult SortiranjeT(string vrednost, string nacin)
        {
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<GrupniTrening> novaLista = new List<GrupniTrening>();

            if (vrednost == "Naziv")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = istorijatreninga.OrderBy(x => x.Naziv).ToList();
                }
                else
                {
                    novaLista = istorijatreninga.OrderByDescending(x => x.Naziv).ToList();
                }
            }
            else if (vrednost == "Tip treninga")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = istorijatreninga.OrderBy(x => x.TipTreninga).ToList();
                }
                else
                {
                    novaLista = istorijatreninga.OrderByDescending(x => x.TipTreninga).ToList();
                }
            }
            else if (vrednost == "Datum i vreme odrzavanja treninga")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = istorijatreninga.OrderBy(x => x.DatumVremeTreninga).ToList();
                }
                else
                {
                    novaLista = istorijatreninga.OrderByDescending(x => x.DatumVremeTreninga).ToList();
                }
            }
            if (nacin == "" && vrednost == "")
                ViewBag.SpisakTreninga = istorijatreninga;
            else
                ViewBag.SpisakTreninga = novaLista;
            return View("~/Views/Posetilac/IstorijaTreninga.cshtml", fitnesCentri);
        }
        public ActionResult Komentar(int id)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            idFCkomentar = id;
            foreach(var item in spisakposetilaca)
            {
                if(item.KorisnickoImePos==korisnik.KorisnickoIme)
                {
                    foreach(var item1 in grupnitreninzi)
                    {
                        if(item1.Id==item.Id)
                        {
                            if(item1.FitnesCentar.Id==id)
                            {
                                return View("~/Views/Posetilac/Komentar.cshtml");
                            }
                        }
                    }
                }
            }
            return View("~/Views/Posetilac/KomentarGreska.cshtml");
        }
        private static int idFCkomentar;
        public ActionResult Komentari(string komentar, int ocena)
        {
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];

            Komentar k = new Komentar();
            k.Id = komentari.Count() + 1;
            k.Posetilac.KorisnickoIme = korisnik.KorisnickoIme;
            k.FitnesCentar.Id = idFCkomentar;
            k.TekstKomentara = komentar;
            k.Ocena = ocena;
            k.Odobren = false;
            komentari.Add(k);
            Podaci.UnesiKomentar(k);
            HttpContext.Application["komentari"] = komentari;

            return RedirectToAction("Index", "Posetilac");
        }
    }
}