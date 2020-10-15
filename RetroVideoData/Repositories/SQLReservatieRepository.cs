using RetroVideoData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetroVideoData.Repositories
{
    public class SQLReservatieRepository : IReservatieRepository
    {
        private RetrovideoDBContext context;
        public SQLReservatieRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }
        public void Add(Reservatie nieuweReservatie)
        {
            context.Reservaties.Add(nieuweReservatie);
            context.SaveChanges();
        }
    }
}
