using System;
using System.Collections.Generic;
using System.Text;
using RetroVideoData.Models;
using RetroVideoData.Repositories;
using System.Transactions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.Design;

namespace RetroVideoServices
{
    
    public class ReservatieService
    {
        private IReservatieRepository reservatieRepository;
        private IFilmRepository filmRepository;
        private FilmServices filmServices;
        public ReservatieService(IReservatieRepository reservatieRepository, IFilmRepository filmRepository, FilmServices filmServices)
        {
            this.reservatieRepository = reservatieRepository;
            this.filmRepository = filmRepository;
            this.filmServices = filmServices;
        }

        public async Task<Reservatie> Reservatiebijvoegen(int filmId, int klantId) => await reservatieRepository.Add(new Reservatie
        {
            FilmId = filmId,
            KlantId = klantId,
            Tijdstip = DateTime.Now
        });


        public void Reserveer(int filmId, int gereserveerdAantal, int klantId) 
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                Task<Reservatie> addReservatie = Reservatiebijvoegen(filmId, klantId);
                Task<Film> updateFilm = filmServices.UpdateRecord(filmId, gereserveerdAantal);
                transactionScope.Complete();
            }
            catch 
            {
                
            }
            

        }
    }
}
