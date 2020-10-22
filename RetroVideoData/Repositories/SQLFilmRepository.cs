using Microsoft.EntityFrameworkCore;
using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoData.Repositories
{
    public class SQLFilmRepository : IFilmRepository
    {
        private RetrovideoDBContext context;
        public SQLFilmRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }

        public async Task<Film> GetFilmDetail(int Id)
        {
            return await context.Films.FindAsync(Id);
        }

        public async Task<IEnumerable<Film>> GetFilmsMetId(SortedSet<int> lijst)
        {
            return await context.Films
                .Where(film => lijst.Contains(film.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Film>> GetFilmsVanGenre(int genreId)
        {
            return await context.Films
                .Where(film => film.GenreId == genreId)
                .ToListAsync();
                
        }

        public async Task<Film> update(int filmId, int statusGereserveerd)
        {
            Film filmUpdate = await context.Films.FindAsync(filmId);
            //var item = context.Films.Find(filmId);
            filmUpdate.Gereserveerd = statusGereserveerd;
            
            await context.SaveChangesAsync();
            return filmUpdate;
        }
    }
}
