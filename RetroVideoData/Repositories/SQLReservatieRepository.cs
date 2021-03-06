﻿using RetroVideoData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoData.Repositories
{
    public class SQLReservatieRepository : IReservatieRepository
    {
        private RetrovideoDBContext context;
        public SQLReservatieRepository(RetrovideoDBContext context)
        {
            this.context = context;
        }
        public async Task<Reservatie> Add(Reservatie nieuweReservatie)
        {
            context.Reservaties.Add(nieuweReservatie);
            await context.SaveChangesAsync();
            return nieuweReservatie;
        }
    }
}
