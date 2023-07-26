using PrizeWinnerAPI.Domain;
using PrizeWinnerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IGuestRepository<T> : IGenericRepository<T> where T : class
    {
       Task<Guest> GetRandom();

    }
}
