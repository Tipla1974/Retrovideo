using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RetroVideoData.Models;
using RetroVideoData.Repositories;

namespace RetroVideoServices
{
    public class FilmServices
    {
        private IFilmRepository filmRepository;

        public FilmServices(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        public async Task<Film> GetFilmInfo(int filmId)
        {
            return await filmRepository.GetFilmDetail(filmId);

        }

        public async Task<IEnumerable<Film>> GetAlleFilmsPerGenre(int genreId)
        {
            return await filmRepository.GetFilmsVanGenre(genreId);
        }
        public async Task<IEnumerable<Film>> GetFilmInfo(SortedSet<int> lijst)
        {
            return await filmRepository.GetFilmsMetId(lijst);
        }
        public async Task<Film> UpdateRecord(int filmId, int aantalGereserveerd)
        {
            return await filmRepository.update(filmId, aantalGereserveerd);


        }
    }
}
