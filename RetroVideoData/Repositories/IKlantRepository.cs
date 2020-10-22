using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoData.Repositories
{
    public interface IKlantRepository
    {
        Task<IEnumerable<Klant>> Getall(string Letters);

        Task<Klant> GetKlantInfo(int Id);

    }
}
