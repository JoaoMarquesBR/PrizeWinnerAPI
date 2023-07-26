using PrizeWinner.Contracts.Records;
using PrizeWinnerAPI.Domain;
using PrizeWinnerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IPromotionGroupService
    {
        Task Add(PromotionGroupContract promotionGroup);
            
        Task<IEnumerable<PromotionGroup>> GetAll();

    }
}
