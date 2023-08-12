using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Services
{
    public class PromotionGroupService : IPromotionGroupService
    {
        private readonly IPromotionGroupRepository _group;

        public PromotionGroupService(IPromotionGroupRepository grouRepo)
        {
            _group = grouRepo;
        }

        public async Task Add(PromotionGroupContract promotionGroup)
        {
            PromotionGroup group = new();
            group.GroupName= promotionGroup.GroupName;
            group.CreatedDate = DateTime.Now;

            await _group.Add(group);
        }

        public async Task<IEnumerable<PromotionGroup>> GetAll()
        {
            return await _group.GetAll();
        }
    }
}
