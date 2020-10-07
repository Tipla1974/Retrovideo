using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Repositories
{
    public interface IGenreRepository
    {
        Genres Get(int id);
        IEnumerable<Genres> Getall();
    }
}
