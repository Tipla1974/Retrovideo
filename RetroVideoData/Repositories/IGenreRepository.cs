using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoData.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> Get(int id);
        Task<IEnumerable<Genre>> Getall();
    }
}
