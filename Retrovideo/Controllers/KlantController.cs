using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Retrovideo.Models;
using RetroVideoData.Models;
using RetroVideoServices;
using Newtonsoft.Json;
using System.Transactions;


namespace Retrovideo.Controllers
{
    
    public class KlantController : Controller
    {
        private readonly RetrovideoDBContext retrovideoDBContext;
        private KlantServices klantServices;
        private FilmServices filmServices;
        private ReservatieService reservatie;
        private RetrovideoDBContext context;

        public KlantController(RetrovideoDBContext retrovideoDBContext, KlantServices klantServices, FilmServices filmServices, ReservatieService reservatie, RetrovideoDBContext context)
        {
            this.klantServices = klantServices;
            this.retrovideoDBContext = retrovideoDBContext;
            this.filmServices = filmServices;
            this.reservatie = reservatie;
            this.context = context;
        }


        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Zoekform()
        {
            return View(new ZoekKlantViewModel());
        }
        public async Task<IActionResult> Zoeknaam(ZoekKlantViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                form.Klanten = (List<Klant>) await klantServices.GetKlanten(form.Letters);
                    
            }
            return View("Zoekform", form);
        }
        public async Task<IActionResult> KlantBevestiging(int Id)
        {
            var mandjeSessionVariablel = HttpContext.Session.GetString("mandje");
            var inmandje = JsonConvert.DeserializeObject<SortedSet<int>>(mandjeSessionVariablel);
            ViewBag.AantalInMandje = inmandje.Count();
            var klantDetail = await klantServices.GetklantInfo(Id);
            return View(new BevestigingViewModel 
            {
                Id = Id,
                Naam = klantDetail.Voornaam + " " + klantDetail.Familienaam,
                StraatNummer = klantDetail.StraatNummer,
                Postcode = klantDetail.Postcode,
                Gemeente = klantDetail.Gemeente
            });
        }
        public async Task<IActionResult> ReservatieBevestigd(int Id)
        {
            var mandjeSessionVariablel = HttpContext.Session.GetString("mandje");
            var inmandje = JsonConvert.DeserializeObject<SortedSet<int>>(mandjeSessionVariablel);
            var FilmLijst = await filmServices.GetFilmInfo(inmandje);
            
            return View(reservatie.Reserveer(FilmLijst, Id));
           
            
        }
    }

}
