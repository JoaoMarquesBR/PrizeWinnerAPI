using PrizeWinnerAPI.Domain;
using PrizeWinnerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IPromotionGroupRepository
    {
        Task Add(PromotionGroup entity);

        Task<IEnumerable<PromotionGroup>> GetAll();

    }
}
