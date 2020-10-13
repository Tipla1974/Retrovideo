using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retrovideo.Models
{
    public class InMandje
    {
        
        public int FilmId { get; set; }
        public string Naam { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; }
    }
}
