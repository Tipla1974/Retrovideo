using System;
using System.Collections.Generic;
using System.Text;
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

        public Film GetFilmInfo(int filmId)
        {
            return filmRepository.GetFilmDetail(filmId);

        }

        public IEnumerable<Film> GetAlleFilmsPerGenre(int genreId)
        {
            return filmRepository.GetFilmsVanGenre(genreId);
        }
    }
}
