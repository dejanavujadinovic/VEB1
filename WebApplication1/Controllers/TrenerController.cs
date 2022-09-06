using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TrenerController : Controller
    {
        //private int IdFC;   id fitnes centra za koji se prikazuju detalji
        private static bool vecprijavljen; //da li je prijavljen za izabrani trening
        private static bool popunjentermin;
        // GET: Trener
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
                return RedirectToAction("Index", "Trener");
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
            return View("~/Views/Trener/Index.cshtml");
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
            return View("~/Views/Trener/Index.cshtml");
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
            return View("~/Views/Trener/Detalji.cshtml");
        }
        private static List<GrupniTrening> ranijiTreninzi;
        private static List<GrupniTrening> predstojecitreninzi;
        public ActionResult MojiTreninzi()
        {
            List<Korisnik> treninzitrenera = (List<Korisnik>)HttpContext.Application["treneri"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<GrupniTrening> novitreninzi = new List<GrupniTrening>();
            List<GrupniTrening> staritreninzi = new List<GrupniTrening>();
            if (TempData["Error"] == null)
            {
                TempData["Error"] = "";
            }
            else
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            foreach (var item in treninzitrenera)
            {
                if(item.KorisnickoIme==korisnik.KorisnickoIme)
                {
                    foreach(var item1 in grupnitreninzi)
                    {
                        if(item1.Id==item.IdTreninga)
                        {
                            if(item1.Obrisan==false)
                            {
                                if (item1.DatumVremeTreninga > DateTime.Now)
                                    novitreninzi.Add(item1);
                                else
                                    staritreninzi.Add(item1);
                            }
                                
                        }
                    }
                }
            }
            ranijiTreninzi = staritreninzi;
            predstojecitreninzi = novitreninzi;
            ViewBag.BrojPosetilaca = spisakposetilaca;
            ViewBag.SpisakTreninga = novitreninzi;
            ViewBag.SpisakTreninga2 = staritreninzi;
            return View(fitnescentri);
        }
        public ActionResult DodajTrening()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajTrening(GrupniTrening trening)
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<Korisnik> centritrenera = (List<Korisnik>)HttpContext.Application["trenercentar"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<Korisnik> treninzitrenera = (List<Korisnik>)HttpContext.Application["treneri"];
            ViewBag.Error = "";
            if (trening.DatumVremeTreninga < DateTime.Now.AddDays(3))
            {
                ViewBag.Error = "Trening mora biti kreiran najmanje 3 dana unapred!";
                return View("~/Views/Trener/DodajTrening.cshtml");
            }
            if(trening.FitnesCentar==null)
            {
                trening.FitnesCentar = new FitnesCentar();
            }
            foreach (var item in centritrenera)
            {
                if(korisnik.KorisnickoIme==item.KorisnickoIme)
                {

                    trening.FitnesCentar.Id = item.IdCentra;
                }
            }
            trening.Id = grupnitreninzi.Count + 1;
            Podaci.UnesiGrupniTrening(trening);
            Podaci.UnesiTreningTrenera(korisnik.KorisnickoIme, trening.Id);
            grupnitreninzi.Add(trening);
            korisnik.IdTreninga = trening.Id;
            treninzitrenera.Add(korisnik);
            HttpContext.Application["grupnitreninzi"] = grupnitreninzi;
            HttpContext.Application["treneri"] = treninzitrenera;
            
            return RedirectToAction("MojiTreninzi", "Trener");
        }
        public ActionResult IzmenaTreninga(int id)
        {
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            foreach(var item in grupnitreninzi)
            {
                if(item.Id==id)
                {
                    if (item.DatumVremeTreninga > DateTime.Now)
                    {
                        ViewBag.Trening = item;
                        TempData["Error"] = "";
                    }
                    else
                    {
                        TempData["Error"] = "Mozete da modifikujete samo one treninge koji se jos nisu odrzali!";
                        return RedirectToAction("MojiTreninzi");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult IzmenaTreninga(GrupniTrening trening, int id)
        {
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<Korisnik> centritrenera = (List<Korisnik>)HttpContext.Application["trenercentar"];
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            foreach (var item in grupnitreninzi)
            {
                if(item.Id==id)
                {
                    item.Naziv = trening.Naziv;
                    item.TipTreninga = trening.TipTreninga;
                    item.TrajanjeTreninga = trening.TrajanjeTreninga;
                    item.DatumVremeTreninga = trening.DatumVremeTreninga;
                    item.MaxPosetilaca = trening.MaxPosetilaca;
                    foreach (var item1 in centritrenera)
                    {
                        if (korisnik.KorisnickoIme == item1.KorisnickoIme)
                        {
                            foreach(var item2 in fitnescentri)
                            {
                                if(item2.Id==item1.IdCentra)
                                {
                                    item.FitnesCentar = item2;
                                }
                            }
                        }
                    }
                }
            }
            foreach(var item in grupnitreninzi)
            {
                if(item.Id==trening.Id)
                {
                    trening = item;
                    break;
                }
            }
            Podaci.IzmeniTrening(trening);
            HttpContext.Application["grupnitreninzi"] = grupnitreninzi;
            return RedirectToAction("MojiTreninzi", "Trener");
        }
        public ActionResult BrisanjeTreninga(int id)
        {
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];

            bool dozvoljenobrisanje = true;
            foreach (var item in grupnitreninzi)
            {
                if (item.Id == id)
                {
                    if (item.Obrisan == false)
                    {
                        foreach (var item1 in spisakposetilaca)
                        {
                            if (item1.Id == item.Id)
                            {
                                dozvoljenobrisanje = false;
                                break;
                            }
                        }
                        if (!dozvoljenobrisanje)
                            break;
                    }
                }
                if (!dozvoljenobrisanje)
                    break;
            }
            if(!dozvoljenobrisanje)
            {
                TempData["Error"] = "Ne mozete brisati trening na kome ima prijavljenih posetilaca!";
                return RedirectToAction("MojiTreninzi", "Trener");
            }
            foreach (var item in grupnitreninzi)
            {
                if(item.Id==id)
                    item.Obrisan = true;

                TempData["Error"] = "";                
                Podaci.IzmeniTrening(item);
                HttpContext.Application["grupnitreninzi"] = grupnitreninzi;                
            }
            return RedirectToAction("MojiTreninzi", "Trener");
        }
        public ActionResult SpisakPosetilaca(int id)
        {
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<Korisnik> posetioci = new List<Korisnik>();

            foreach(var item in spisakposetilaca)
            {
                if(item.Id==id)
                {
                    foreach(var item1 in korisnici)
                    {
                        if(item1.KorisnickoIme==item.KorisnickoImePos)
                        {
                            posetioci.Add(item1);
                        }
                    }
                }
            }
            ViewBag.Posetioci = posetioci;
            return View();
        }
        public ActionResult PretragaT(string naziv, string tip, string minvrednost, string maxvrednost)
        {
            List<Korisnik> treninzitrenera = (List<Korisnik>)HttpContext.Application["treneri"];
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            List<GrupniTrening> novaLista = new List<GrupniTrening>();

            List<GrupniTrening> pomLista = new List<GrupniTrening>();
            foreach (var item in treninzitrenera)
            {
                if (item.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    foreach (var item1 in grupnitreninzi)
                    {
                        if (item1.Id == item.IdTreninga)
                        {
                            if (item1.Obrisan == false)
                            {
                                if (item1.DatumVremeTreninga < DateTime.Now)
                                    novaLista.Add(item1);
                            }
                        }
                    }
                }
            }
            if (naziv == "" && tip == "" && minvrednost == "" && maxvrednost == "")
            {
                return RedirectToAction("MojiTreninzi", "Trener");
            }
            else if (naziv != "" && tip == "" && minvrednost == "" && maxvrednost == "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv)
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip != "" && minvrednost == "" && maxvrednost == "")
            {
                foreach (var item in novaLista)
                {
                    if (item.TipTreninga == tip)
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip == "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in novaLista)
                {
                    if (item.DatumVremeTreninga >= DateTime.Parse(minvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip == "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip == "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.DatumVremeTreninga >= DateTime.Parse(minvrednost) && item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip != "" && minvrednost == "" && maxvrednost == "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv && item.TipTreninga == tip)
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip == "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv && item.DatumVremeTreninga >= DateTime.Parse(minvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip == "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv && item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip == "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv && item.DatumVremeTreninga >= DateTime.Parse(minvrednost) && item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip != "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in novaLista)
                {
                    if (item.TipTreninga == tip && item.DatumVremeTreninga >= DateTime.Parse(minvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip != "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.TipTreninga == tip && item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip != "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.TipTreninga == tip && item.DatumVremeTreninga >= DateTime.Parse(minvrednost) && item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip != "" && minvrednost != "" && maxvrednost == "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv && item.TipTreninga == tip && item.DatumVremeTreninga >= DateTime.Parse(minvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv != "" && tip != "" && minvrednost == "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv && item.TipTreninga == tip && item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }
            else if (naziv == "" && tip != "" && minvrednost != "" && maxvrednost != "")
            {
                foreach (var item in novaLista)
                {
                    if (item.Naziv == naziv && item.TipTreninga == tip && item.DatumVremeTreninga >= DateTime.Parse(minvrednost) && item.DatumVremeTreninga <= DateTime.Parse(maxvrednost))
                        pomLista.Add(item);
                }
            }

            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];
            List<GrupniTrening> novitreninzi = new List<GrupniTrening>();
            List<GrupniTrening> staritreninzi = new List<GrupniTrening>();
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];

            foreach (var item in treninzitrenera)
            {
                if (item.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    foreach (var item1 in grupnitreninzi)
                    {
                        if (item1.Id == item.IdTreninga)
                        {
                            if (item1.Obrisan == false)
                            {
                                if (item1.DatumVremeTreninga > DateTime.Now)
                                    novitreninzi.Add(item1);
                                else
                                {
                                    if(pomLista.Contains(item1))
                                        staritreninzi.Add(item1);
                                }
                            }

                        }
                    }
                }
            }

            ViewBag.BrojPosetilaca = spisakposetilaca;
            ViewBag.SpisakTreninga = novitreninzi;
            ViewBag.SpisakTreninga2 = staritreninzi;

            return View("~/Views/Trener/MojiTreninzi.cshtml", fitnescentri);
        }
        public ActionResult SortiranjeT(string vrednost, string nacin)
        {
            List<GrupniTrening> grupnitreninzi = (List<GrupniTrening>)HttpContext.Application["grupnitreninzi"];
            List<GrupniTrening> novaLista = new List<GrupniTrening>();
            List<FitnesCentar> fitnescentri = (List<FitnesCentar>)HttpContext.Application["fitnescentri"];
            List<GrupniTrening> spisakposetilaca = (List<GrupniTrening>)HttpContext.Application["spisakposetilaca"];

            if (vrednost == "Naziv")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = ranijiTreninzi.OrderBy(x => x.Naziv).ToList();
                }
                else
                {
                    novaLista = ranijiTreninzi.OrderByDescending(x => x.Naziv).ToList();
                }
            }
            else if (vrednost == "Tip treninga")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = ranijiTreninzi.OrderBy(x => x.TipTreninga).ToList();
                }
                else
                {
                    novaLista = ranijiTreninzi.OrderByDescending(x => x.TipTreninga).ToList();
                }
            }
            else if (vrednost == "Datum i vreme odrzavanja treninga")
            {
                if (nacin == "Rastuce")
                {
                    novaLista = ranijiTreninzi.OrderBy(x => x.DatumVremeTreninga).ToList();
                }
                else
                {
                    novaLista = ranijiTreninzi.OrderByDescending(x => x.DatumVremeTreninga).ToList();
                }
            }
            ViewBag.BrojPosetilaca = spisakposetilaca;
            ViewBag.SpisakTreninga = predstojecitreninzi;
            ViewBag.SpisakTreninga2 = novaLista;
            return View("~/Views/Trener/MojiTreninzi.cshtml", fitnescentri);
        }
    }
}