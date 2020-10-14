using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Retrovideo.Models;
using RetroVideoData.Models;
using RetroVideoServices;

namespace Retrovideo.Controllers
{
    public class KlantController : Controller
    {
        private readonly RetrovideoDBContext _context;
        private KlantServices klantServices;

        public KlantController(RetrovideoDBContext context, KlantServices klantServices)
        {
            this.klantServices = klantServices;
            _context = context;

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
                form.Klanten = await _context.Klanten
                    .OrderBy(KlantZoeken => KlantZoeken.Familienaam)
                    .Where(Deelnaam => Deelnaam.Familienaam.Contains(form.Letters))
                    .ToListAsync();
            }
            return View("Zoekform", form);
        }
    }
}
