using Microsoft.EntityFrameworkCore;
using RetroVideoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoData.Repositories
{
    public class SQLKlantRepository : IKlantRepository
    {
        private RetrovideoDBContext context;
        public SQLKlantRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }

        public async Task<Klant> GetKlantInfo(int Id)
        {
            return await context.Klanten.FindAsync(Id);
        }

        public async Task<IEnumerable<Klant>> Getall(string Letters)
        {
            return await context.Klanten
                .OrderBy(klant => klant.Familienaam)
                .Where(klant => klant.Familienaam.Contains(Letters))
                .ToListAsync();
            
        }
    }
}
