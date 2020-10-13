using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroVideoData.Repositories
{
    public class SQLKlantRepository : IKlantRepository
    {
        private RetrovideoDBContext context;
        public SQLKlantRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }

        IEnumerable<Klant> IKlantRepository.Getall(string Letters)
        {
            return context.Klanten
                .OrderBy(k => k.Familienaam)
                .Where(k => k.Familienaam.Contains(Letters));
            
        }
    }
}
