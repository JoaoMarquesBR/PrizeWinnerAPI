using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Contracts.Records.PromotionGoupContracts;
using PrizeWinner.Contracts.Responses;
using PrizeWinner.Domain.Entities;
using System.Text.RegularExpressions;

namespace PrizeWinner.Application.Services
{
    public class PromotionGroupService : IPromotionGroupService
    {
        private readonly IPromotionGroupRepository _groupRepo;
        private readonly IItemGroupRepository<ItemGroup> _itemGroupRepo;
        private readonly IGuestRepository<Guest> _guestRepo;

        private readonly IItemRepository<Item> _itemRepo;


        public PromotionGroupService(IPromotionGroupRepository grouRepo, IItemGroupRepository<ItemGroup> itemGroupRepo,
                                      IItemRepository<Item> itemRepo, IGuestRepository<Guest> guestRepo)
        {
            _guestRepo = guestRepo;
            _groupRepo = grouRepo;
            _itemGroupRepo = itemGroupRepo;
            _itemRepo = itemRepo;
        }

        public async Task Add(PromotionGroupContract promotionGroup)
        {
            PromotionGroup group = new();
            group.GroupName = promotionGroup.GroupName;
            //group.CreatedDate = promotionGroup.date;

            await _groupRepo.Add(group);

            if (promotionGroup.itemsId?.Count >= 0)
            {
                foreach (int id in promotionGroup.itemsId)
                {
                    //first verify if ID exists in itemGroup table
                    if (await _itemRepo.GetById(id) != null)
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
            IEnumerable<PromotionGroup> groupList = await _groupRepo.GetAll();

            List<GroupResponse> groupResponseList = new List<GroupResponse>();

            foreach (PromotionGroup group in groupList)
            {
                GroupResponse GroupAggregation = new();
                GroupAggregation.PromotionGroupId = group.PromotionGroupId;
                GroupAggregation.GroupName = group.GroupName;
                GroupAggregation.CreatedDate = group.CreatedDate;
                GroupAggregation.itemList = new();

                GroupAggregation.Participants = _guestRepo.GetGuestsByGroupID(group.PromotionGroupId).Result.Count();

                List<ItemGroup> itemGroupList = await _itemGroupRepo.GetPrizesByGroupId(group.PromotionGroupId);

                foreach (ItemGroup itemGroupItem in itemGroupList)
                {
                    Item item = await _itemRepo.GetById(itemGroupItem.ItemId);
                    GroupAggregation.itemList.Add(item);
                }

                groupResponseList.Add(GroupAggregation);
            }

            return groupResponseList;
        }

        public async Task Update(UpdateGroupRequest updateRequest)
        {
            PromotionGroup originalGroup = await _groupRepo.GetById(updateRequest.groupId);
            originalGroup.GroupName = updateRequest.GroupName;

            List<ItemGroup> itemGroupList = await _itemGroupRepo.GetPrizesByGroupId(originalGroup.PromotionGroupId);

            for (int i = 0; i < updateRequest.itemsId.Count; i++)
            {
                //in case group does not have itemId in It, we need to insert It
                int itemId = updateRequest.itemsId[i];
                if (!itemGroupList.Any(x => x.ItemId == itemId))
                {
                    ItemGroup newItemGroup = new ItemGroup();
                    newItemGroup.PromotionGroupId = originalGroup.PromotionGroupId;
                    newItemGroup.ItemId = updateRequest.itemsId.ElementAt(i);

                    await _itemGroupRepo.Add(newItemGroup);
                    itemGroupList.Add(newItemGroup);
                }
            }


            for (int i = 0; i < itemGroupList.Count; i++)
            {
                if (!updateRequest.itemsId.Contains((int)itemGroupList.ElementAt(i).ItemId))
                {
                    await _itemGroupRepo.Remove(itemGroupList.ElementAt(i).ItemGroupId);
                }
            }


            await _groupRepo.Update(originalGroup);

        }
    }
}
