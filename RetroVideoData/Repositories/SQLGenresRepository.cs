using RetroVideoData.Models;
using System;
using System.Collections.Generic;
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
        public Genres Get(int Id)
        {
            return context.Genres.Find(Id);
        }

        public IEnumerable<Genres> Getall()
        {
            return context.Genres;
        }
    }
}
