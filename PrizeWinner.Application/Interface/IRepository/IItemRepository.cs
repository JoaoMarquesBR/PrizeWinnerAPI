using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IItemRepository<T> : IGenericRepository<T> where T : class
    {
       

    }
}
