﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Retrovideo.Models;
using RetroVideoData.Models;
using RetroVideoServices;


namespace Retrovideo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ICollection<InMandje> Winkelmandje = new List<InMandje>();
        private GenresServices genresServices;
       
        private FilmServices filmServices;
       

        public HomeController(GenresServices genresServices, FilmServices filmServices)
        {
            this.genresServices = genresServices;
            this.filmServices = filmServices;
          
        }

        public IActionResult Index()
        {

            return View( genresServices.GetAllGenres());
        }
       
        public IActionResult Genre(int Id)
        {
            var genrenaam = genresServices.GetGenre(Id);
            ViewBag.genre = genrenaam.Naam;
            return View(new FilmPerGenreViewmodel
            {
                Genres = genresServices.GetAllGenres(),
                FilmsPerGenre = filmServices.GetAlleFilmsPerGenre(Id)
            });
        }

        public IActionResult Detail(int Id)
        {
            var filmdetail = filmServices.GetFilmInfo(Id);
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
            
            return View(FilmModel);
        }

        public IActionResult Inmandje(int Id)
        {
            var item = filmServices.GetFilmInfo(Id);
            var inMandje = new InMandje
            {

                FilmId = item.Id,
                Naam = item.Titel,
                Prijs = item.Prijs
            };
            Winkelmandje.Add(inMandje);
            ViewBag.Aantal = Winkelmandje.Count;

            return View();
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
