using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Repositories
{
    public interface IFilmRepository
    {
        Film GetFilmDetail(int Id);
        IEnumerable<Film> GetFilmsVanGenre(int genreId);

        IEnumerable<Film> GetFilmsMetId(SortedSet<int> lijst);
    }
}
