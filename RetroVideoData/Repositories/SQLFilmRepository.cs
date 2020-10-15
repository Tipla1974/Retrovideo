using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroVideoData.Repositories
{
    public class SQLFilmRepository : IFilmRepository
    {
        private RetrovideoDBContext context;
        public SQLFilmRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }

        public Film GetFilmDetail(int Id)
        {
            return context.Films.Find(Id);
        }

        public IEnumerable<Film> GetFilmsMetId(SortedSet<int> lijst)
        {
            return context.Films
                .Where(film => lijst.Contains(film.Id));
        }

        public IEnumerable<Film> GetFilmsVanGenre(int genreId)
        {
            return context.Films
                .Where(film => film.GenreId == genreId);
                
        }

        public void update(int filmId, int statusGereserveerd)
        {
            var item = context.Films.Find(filmId);
            item.Gereserveerd = statusGereserveerd;
            
        }
    }
}
