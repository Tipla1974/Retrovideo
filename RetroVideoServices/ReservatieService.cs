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
using System.Data;

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


        public List<string> Reserveer(IEnumerable<Film> FilmLijst, int klantId) 
        {
            var FilmZonderVoorraad = new List<string>();
                                 
         
            foreach (var film in FilmLijst)
            {
                

                    var gereserveerdAantal = film.Gereserveerd + 1;

                    try
                    {
                   
                    var transactionOptions = new TransactionOptions
                        {
                            IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
                        };
                        using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
                    if ((film.Voorraad - film.Gereserveerd) == 0)
                    {
                        throw new VoorraadException(film.Titel);
                    }
                    Task<Reservatie> addReservatie = Reservatiebijvoegen(film.Id, klantId);
                        Task<Film> updateFilm = filmServices.UpdateRecord(film.Id, gereserveerdAantal);
                        transactionScope.Complete();
                    }
                    catch (VoorraadException)
                    {
                    FilmZonderVoorraad.Add(film.Titel);
                        
                    }
                
            }
            return FilmZonderVoorraad;
        }
    }
    
    public class VoorraadException : Exception
    {
        public VoorraadException(string message) : base(message)
        {
               
        }
    }
}
