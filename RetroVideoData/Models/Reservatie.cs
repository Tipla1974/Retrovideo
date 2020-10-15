using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace RetroVideoData.Models
{
    [Table("Reservaties")]
    public class Reservatie
    {
        public int KlantId { get; set; }
        public int FilmId { get; set; }
        [Column("Reservatie")]
        public DateTime ReservatieDatum { get; set; }
    }
}
