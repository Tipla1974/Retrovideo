using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetroVideoData.Models
{
    public class RetrovideoDBContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Reservatie> Reservaties { get; set; }
        

        public RetrovideoDBContext() { }
        public RetrovideoDBContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reservatie>().HasKey(r => new { r.KlantId, r.FilmId, r.Tijdstip });



        }
    }
}
