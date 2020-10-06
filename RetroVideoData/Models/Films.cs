using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RetroVideoData.Models
{
    public class Films
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        [StringLength(30)]
        public string Titel { get; set; }
        public int Voorraad { get; set; }
        public int Gereserveerd { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; }
    }
}
