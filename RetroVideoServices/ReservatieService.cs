using System;
using System.Collections.Generic;
using System.Text;
using RetroVideoData.Models;
using RetroVideoData.Repositories;
using System.Transactions;
using Newtonsoft.Json;

namespace RetroVideoServices
{
    public class ReservatieService
    {
        private IReservatieRepository reservatieRepository;
        private IFilmRepository filmRepository;
        public ReservatieService(IReservatieRepository reservatieRepository, IFilmRepository filmRepository)
        {
            this.reservatieRepository = reservatieRepository;
            this.filmRepository = filmRepository;
        }

        public void Reservatiebijvoegen(int filmId, int klantId)
        {
            reservatieRepository.Add(new Reservatie
            {
                FilmId = filmId,
                KlantId = klantId,
                ReservatieDatum = DateTime.Now
            }) ;
            
            

            
        }
    }
}
