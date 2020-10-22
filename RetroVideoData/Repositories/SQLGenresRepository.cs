using Microsoft.EntityFrameworkCore;
using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoData.Repositories
{
    
    public class SQLGenresRepository : IGenreRepository
    {
        private RetrovideoDBContext context;
        public SQLGenresRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }
        public async Task<Genre> Get(int Id)
        {
            return await context.Genres.FindAsync(Id);
        }

        public async Task<IEnumerable<Genre>> Getall()
        {
            return await context.Genres
                .OrderBy(r => r.Naam)
                .ToListAsync();
        }
    }
}
