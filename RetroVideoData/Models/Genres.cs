using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RetroVideoData.Models
{
    public class Genres
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Naam { get; set; }

    }
}
