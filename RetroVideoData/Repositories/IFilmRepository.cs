using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace RetroVideoData.Repositories
{
    public interface IFilmRepository
    {
        Task<Film> GetFilmDetail(int Id);
        Task<IEnumerable<Film>> GetFilmsVanGenre(int genreId);

        Task<IEnumerable<Film>> GetFilmsMetId(SortedSet<int> lijst);

        Task<Film> update(int filmId, int statusGereserveerd);
    }
}
