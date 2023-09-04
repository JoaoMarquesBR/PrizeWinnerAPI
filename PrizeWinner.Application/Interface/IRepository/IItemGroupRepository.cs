using PrizeWinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IItemGroupRepository<T> : IGenericRepository<T> where T : class
    {
        Task<List<ItemGroup>> GetPrizesByGroupId(int groupId);
    }
}
