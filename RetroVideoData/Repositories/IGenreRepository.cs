using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Repositories
{
    public interface IGenreRepository
    {
        Genre Get(int id);
        IEnumerable<Genre> Getall();
    }
}
