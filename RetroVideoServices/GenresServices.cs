using System;
using System.Collections.Generic;
using System.Text;
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

        public IEnumerable<Genre> GetAllGenres()
        {
            return genresRepository.Getall();
        }
        
        public Genre GetGenre(int Id)
        {
            return genresRepository.Get(Id);
        }
    }

  
}
