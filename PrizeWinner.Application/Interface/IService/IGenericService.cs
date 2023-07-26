using PrizeWinnerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Interface.IService
{
    public interface IGenericService<T> where T : class
    {
        //Task<IEnumerable<T>> GetAll();
        //Task<T> GetById(object id);
        //Task Add(T entity);

    }
}
