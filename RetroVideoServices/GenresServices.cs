using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RetroVideoData.Models;
using RetroVideoData.Repositories;

namespace RetroVideoServices
{ 
    public class GenresServices
    {
      private IGenreRepository genresRepository;
        
      public GenresServices(IGenreRepository genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await genresRepository.Getall();
        }
        
        public async Task<Genre> GetGenre(int Id)
        {
            return await genresRepository.Get(Id);
        }
    }

  
}
