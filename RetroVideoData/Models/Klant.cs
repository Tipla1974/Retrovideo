using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RetroVideoData.Models
{
    public class Klant
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Familienaam { get; set; }
        [StringLength(20)]
        public string Voornaam { get; set; }
        [StringLength(30)]
        public string StraatNummer { get; set; }
        [StringLength(10)]
        public string Postcode { get; set; }
        [StringLength(30)]
        public string Gemeente { get; set; }
    }
}
