using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Contracts.Responses;
using PrizeWinner.Domain.Entities;

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

        public async Task<List<GroupResponse>> GetAll()
        {
            IEnumerable<PromotionGroup> groupList = await _group.GetAll();

            List<GroupResponse> groupResponseList = new List<GroupResponse>();

            foreach(PromotionGroup group in groupList)
            {
                GroupResponse GroupAggregation = new();
                GroupAggregation.GroupName = group.GroupName;
                GroupAggregation.CreatedDate = group.CreatedDate;
                GroupAggregation.itemList = new();

                List<ItemGroup> itemGroupList =await _itemGroupRepo.GetPrizesByGroupId(group.PromotionGroupId);

                foreach(ItemGroup itemGroupItem in itemGroupList)
                {
                    Item item = await _itemRepo.GetById(itemGroupItem.ItemId);
                    GroupAggregation.itemList.Add(item);
                }

                groupResponseList.Add(GroupAggregation);
            }

            return groupResponseList;
        }
    }
}
