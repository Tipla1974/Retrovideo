using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrovideo.Models
{
    public class BevestigingViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
       
        public string StraatNummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }


    }
}
