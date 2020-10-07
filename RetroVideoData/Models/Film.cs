using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RetroVideoData.Models
{
    [Table("Films")]
    public class Film
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
