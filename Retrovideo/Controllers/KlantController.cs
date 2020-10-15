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

        public KlantController(RetrovideoDBContext retrovideoDBContext, KlantServices klantServices, FilmServices filmServices, ReservatieService reservatie)
        {
            this.klantServices = klantServices;
            this.retrovideoDBContext = retrovideoDBContext;
            this.filmServices = filmServices;
            this.reservatie = reservatie;
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
        {if (this.ModelState.IsValid)
            {
                form.Klanten = await retrovideoDBContext.Klanten
                    .OrderBy(KlantZoeken => KlantZoeken.Familienaam)
                    .Where(Deelnaam => Deelnaam.Familienaam.Contains(form.Letters))
                    .ToListAsync();
            }
            return View("Zoekform", form);
        }
        public IActionResult KlantBevestiging(int Id)
        {
            var mandjeSessionVariablel = HttpContext.Session.GetString("mandje");
            var inmandje = JsonConvert.DeserializeObject<SortedSet<int>>(mandjeSessionVariablel);
            ViewBag.AantalInMandje = inmandje.Count();
            var klantDetail = klantServices.GetklantInfo(Id);
            return View(new BevestigingViewModel 
            {
                Id = Id,
                Naam = klantDetail.Voornaam + " " + klantDetail.Familienaam,
                StraatNummer = klantDetail.StraatNummer,
                Postcode = klantDetail.Postcode,
                Gemeente = klantDetail.Gemeente
            });
        }
        public IActionResult ReservatieBevestigd(int Id)
        {
            var mandjeSessionVariablel = HttpContext.Session.GetString("mandje");
            var inmandje = JsonConvert.DeserializeObject<SortedSet<int>>(mandjeSessionVariablel);
            var FilmLijst = filmServices.GetFilmInfo(inmandje);
            ViewBag.geslaagd = false;
            try
            {
                
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                
                foreach(var film in FilmLijst)
                {
                    if((film.Voorraad - film.Gereserveerd)> 0)
                    {
                        var gereserveerdAantal = film.Gereserveerd + 1;
                        reservatie.Reservatiebijvoegen(film.Id, Id);
                        filmServices.UpdateRecord(film.Id, gereserveerdAantal);
                        inmandje.Remove(film.Id);
                    }                 
                }
                transactionScope.Complete();
            }
            catch (Exception)
            {
                throw;
            }
            HttpContext.Session.SetString("mandje", JsonConvert.SerializeObject(inmandje));
            if (inmandje.Count() == 0)
            {
                ViewBag.geslaagd = true;
                return View();
            }
            else
            {
                return View(filmServices.GetFilmInfo(inmandje));
            }
            
        }
    }
}
