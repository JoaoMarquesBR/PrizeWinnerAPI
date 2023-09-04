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
        private readonly IItemGroupRepository<ItemGroup> _itemGroupRepo;
        private readonly IItemRepository<Item> _itemRepo;


        public PromotionGroupService(IPromotionGroupRepository grouRepo, IItemGroupRepository<ItemGroup>itemGroupRepo,
                                      IItemRepository<Item>itemRepo)
        {
            _group = grouRepo;
            _itemGroupRepo = itemGroupRepo;
            _itemRepo = itemRepo;
        }

        public async Task Add(PromotionGroupContract promotionGroup)
        {
            PromotionGroup group = new();
            group.GroupName= promotionGroup.GroupName;
            group.CreatedDate = promotionGroup.date;

            await _group.Add(group);

            if (promotionGroup.itemsId?.Count >= 0)
            {
                foreach(int id in  promotionGroup.itemsId)
                {
                    //first verify if ID exists in itemGroup table
                    if(await _itemRepo.GetById(id) != null)
                    {
                        ItemGroup itemGroup = new ItemGroup();
                        itemGroup.ItemId = id;
                        itemGroup.PromotionGroupId = group.PromotionGroupId;

                        await _itemGroupRepo.Add(itemGroup);
                    }
                  
                }

            }
        }

        public async Task<IEnumerable<PromotionGroup>> GetAll()
        {
            return await _group.GetAll();
        }
    }
}
