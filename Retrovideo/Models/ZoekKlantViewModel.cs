using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retrovideo.Models
{
    public class ZoekKlantViewModel
    {
        [Display(Name = "Familienaam bevat :")]
        public string Letters { get; set; }
        public List<Klant> Klanten { get; set; }
    }
}
