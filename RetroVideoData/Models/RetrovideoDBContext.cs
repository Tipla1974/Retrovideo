using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Models
{
    public class RetrovideoDBContext : DbContext
    {
        public DbSet<Films> Films { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Klanten> Klanten { get; set; }
        public DbSet<Reservaties> Reservaties { get; set; }

        public RetrovideoDBContext() { }
        public RetrovideoDBContext(DbContextOptions options) : base(options) { }
    }
}
