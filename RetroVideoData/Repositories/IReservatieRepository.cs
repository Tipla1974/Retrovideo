using System;
using System.Collections.Generic;
using System.Text;
using RetroVideoData.Models;

namespace RetroVideoData.Repositories
{
    public interface IReservatieRepository
    {
        void Add(Reservatie nieuweReservatie);
    }
}
