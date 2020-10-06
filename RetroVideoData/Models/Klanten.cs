using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Models
{
    public class Klanten
    {
        public int Id { get; set; }
        public string Familienaam { get; set; }
        public string Voornaam { get; set; }
        public string StraatNummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
    }
}
