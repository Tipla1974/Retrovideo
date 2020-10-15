using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Repositories
{
    public interface IKlantRepository
    {
        IEnumerable<Klant> Getall(string Letters);

        Klant GetKlantInfo(int Id);
    }
}
