using Microsoft.AspNetCore.Mvc;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Application.Services;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Domain.Entities;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("/ItemGroup")]
    public class ItemGroupController : ControllerBase
    {
        private readonly IItemGroupService<ItemGroup> _itemGroupService;

        public ItemGroupController(IItemGroupService<ItemGroup> itemGroupService)
        {
            _itemGroupService = itemGroupService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ItemGroup>> getAll()
        {
            return await _itemGroupService.GetAll();
        }

        [HttpPost("Add")]
        public async Task Add(ItemGroupContract request) {

            ItemGroup itemGroup = new()
            {
                ItemId = request.ItemID,
                PromotionGroupId = request.PromotionGroupID
            };

            await _itemGroupService.Add(itemGroup);
        }

    }
}
