using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Models
{
    public class Reservaties
    {
        public int KlantId { get; set; }
        public int FilmId { get; set; }
        public DateTime Reservatie { get; set; }
    }
}
