using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Retrovideo.Controllers
{
    public class KlantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
