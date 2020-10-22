using RetroVideoData.Models;
using RetroVideoData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoServices
{
    public class KlantServices
    {
        private IKlantRepository klantRepository;

        public KlantServices(IKlantRepository klantRepository)
        {
            this.klantRepository = klantRepository;
        }
        public async Task<IEnumerable<Klant>> GetKlanten (string Letters)
        {
            return await klantRepository.Getall(Letters);
                    
        }
        public async Task<Klant> GetklantInfo(int Id)
        {
            return await klantRepository.GetKlantInfo(Id);
        }
    }
}
