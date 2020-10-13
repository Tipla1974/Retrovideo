using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Retrovideo.Models;
using RetroVideoData.Models;
using RetroVideoServices;

namespace Retrovideo.Controllers
{
    public class InMandjeController : Controller
    {
        private static readonly ICollection<InMandje> Winkelmandje = new List<InMandje>();
        public IActionResult Index()
        {
            @ViewBag.TotalePrijs = 0;
            return View(new InmandjeViewModel { Mandje = Winkelmandje});
        }
    }
}
