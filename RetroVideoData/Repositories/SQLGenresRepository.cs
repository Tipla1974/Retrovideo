using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroVideoData.Repositories
{
    
    public class SQLGenresRepository : IGenreRepository
    {
        private RetrovideoDBContext context;
        public SQLGenresRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }
        public Genre Get(int Id)
        {
            return context.Genres.Find(Id);
        }

        public IEnumerable<Genre> Getall()
        {
            return context.Genres
                .OrderBy(r => r.Naam) ;
        }
    }
}
