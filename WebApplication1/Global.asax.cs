using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            List<FitnesCentar> fitnescentri = Podaci.CitajFitnesCentre("~/App_Data/fitnescentri.txt");
            HttpContext.Current.Application["fitnescentri"] = fitnescentri;

            List<GrupniTrening> grupnitreninzi = Podaci.CitajGrupneTreninge("~/App_Data/grupnitreninzi.txt");
            HttpContext.Current.Application["grupnitreninzi"] = grupnitreninzi;

            List<Komentar> komentari = Podaci.CitajKomentare("~/App_Data/komentari.txt");
            HttpContext.Current.Application["komentari"] = komentari;

            List<Korisnik> korisnici = Podaci.CitajKorisnike("~/App_Data/korisnici.txt");
            HttpContext.Current.Application["korisnici"] = korisnici;

            List<GrupniTrening> spisakposetilaca = Podaci.CitajSpisakPosetilaca("~/App_Data/spisakposetilaca.txt");
            HttpContext.Current.Application["spisakposetilaca"] = spisakposetilaca;

            List<Korisnik> trenertreninzi = Podaci.CitajTreningeTrenera("~/App_Data/treneri.txt");
            HttpContext.Current.Application["treneri"] = trenertreninzi;

            List<Korisnik> trenericentri = Podaci.CitajCentreTrenera("~/App_Data/trenercentar.txt");
            HttpContext.Current.Application["trenercentar"] = trenericentri;

            List<Korisnik> centarvlasnika = Podaci.CitajCentreVlasnika("~/App_Data/centarvlasnik.txt");
            HttpContext.Current.Application["centarvlasnik"] = centarvlasnika;
        }
    }
}
