using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Models
{
    public class Films
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Titel { get; set; }
        public int Voorraad { get; set; }
        public int Gereserveerd { get; set; }
        public decimal prijs { get; set; }
    }
}
