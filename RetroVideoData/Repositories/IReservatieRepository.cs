using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RetroVideoData.Models;

namespace RetroVideoData.Repositories
{
    public interface IReservatieRepository
    {
        Task<Reservatie> Add(Reservatie nieuweReservatie);
    }
}
