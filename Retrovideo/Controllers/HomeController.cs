using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Retrovideo.Models;
using RetroVideoData.Models;
using RetroVideoServices;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Retrovideo.Controllers
{
    public class HomeController : Controller
    {
       
        private GenresServices genresServices;
       
        private FilmServices filmServices;
       

        public HomeController(GenresServices genresServices, FilmServices filmServices)
        {
            this.genresServices = genresServices;
            this.filmServices = filmServices;
          
        }

        public async Task<IActionResult> Index()
        {

            return View( await genresServices.GetAllGenres());
        }
       
        public async Task<IActionResult> Genre(int Id)
        {
            var genrenaam = await genresServices.GetGenre(Id);
            ViewBag.genre = genrenaam.Naam;
            return View( new FilmPerGenreViewmodel
            {
                Genres = await genresServices.GetAllGenres(),
                FilmsPerGenre = await filmServices.GetAlleFilmsPerGenre(Id)
            });
        }

        public async Task<IActionResult> Detail(int Id)
        {
            var filmdetail = await filmServices.GetFilmInfo(Id);
            var FilmModel = new FilmDetailViewModel
            {
                Id = Id,
                Naam = filmdetail.Titel,
                ImageURL = "~/Images/" + Id + ".jpg",
                Prijs = filmdetail.Prijs,
                Voorraad = filmdetail.Voorraad,
                Gereserveerd = filmdetail.Gereserveerd,
                Beschikbaar = filmdetail.Voorraad - filmdetail.Gereserveerd
            };
            
            return View( FilmModel);
        }

        public IActionResult Inmandje(int Id)
        {
            SortedSet<int> inMandje = new SortedSet<int>();
            var mandje = HttpContext.Session.GetString("mandje");
            if (!string.IsNullOrEmpty(mandje))
            inMandje = JsonConvert.DeserializeObject<SortedSet<int>>(mandje);
            inMandje.Add(Id);
            HttpContext.Session.SetString("mandje", JsonConvert.SerializeObject(inMandje));

            return RedirectToAction("index","InMandje");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
