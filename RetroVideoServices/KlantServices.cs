using RetroVideoData.Models;
using RetroVideoData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoServices
{
    public class KlantServices
    {
        private IKlantRepository klantRepository;

        public KlantServices(IKlantRepository klantRepository)
        {
            this.klantRepository = klantRepository;
        }
        public IEnumerable<Klant> GetKlanten (string Letters)
        {
            return klantRepository.Getall(Letters);
        }
    }
}
