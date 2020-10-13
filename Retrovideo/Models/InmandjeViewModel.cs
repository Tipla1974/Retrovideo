using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RetroVideoData.Models;


namespace Retrovideo.Models
{
    public class InmandjeViewModel
    {
        public IEnumerable<InMandje> Mandje { get; set; }

    }
}
