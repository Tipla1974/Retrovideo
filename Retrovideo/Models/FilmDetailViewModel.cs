using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrovideo.Models
{
    public class FilmDetailViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string ImageURL { get; set; }
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public int Gereserveerd { get; set; }
        public int Beschikbaar { get; set; }


    }
}
