using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Retrovideo.Models;
using RetroVideoData.Models;
using RetroVideoServices;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Retrovideo.Controllers
{
    public class InMandjeController : Controller
    {
        
        private FilmServices filmServices;
        public InMandjeController( FilmServices filmServices)
        {
            
            this.filmServices = filmServices;

        }

        public async Task<IActionResult> Index()
        {
            var mandjeSessionVariablel = HttpContext.Session.GetString("mandje");
            var inmandje = JsonConvert.DeserializeObject<SortedSet<int>>(mandjeSessionVariablel);
            // set weer ophalen uit de session
            return View( await filmServices.GetFilmInfo(inmandje)) ;
        }
    }
}
