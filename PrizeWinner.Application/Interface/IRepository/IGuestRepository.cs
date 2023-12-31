﻿using PrizeWinner.Domain.Entities;

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

       Task<IEnumerable<Guest>>GetGuestsByGroupID(int groupID);
    }
}
