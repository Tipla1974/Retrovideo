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

        public Klant GetKlantInfo(int Id)
        {
            return context.Klanten.Find(Id);
        }

        IEnumerable<Klant> IKlantRepository.Getall(string Letters)
        {
            return context.Klanten
                .OrderBy(klant => klant.Familienaam)
                .Where(klant => klant.Familienaam.Contains(Letters));
            
        }
    }
}
