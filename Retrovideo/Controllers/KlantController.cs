using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Retrovideo.Models;
using RetroVideoServices;

namespace Retrovideo.Controllers
{
    public class KlantController : Controller
    {
        private KlantServices klantServices;

        public KlantController(KlantServices klantServices)
        {
            this.klantServices = klantServices;
            

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Zoeknaam()
        {
            return View();
        }
    }
}
