using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetroVideoData.Models;

namespace Retrovideo.Models
{
    public class FilmPerGenreViewmodel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Film> FilmsPerGenre { get; set; }
    }
}
