using Microsoft.AspNetCore.Mvc;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Domain.Entities;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("/Item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService<Item> _itemService;

        public ItemController(IItemService<Item> itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<Item>> getAll()
        {
            return await _itemService.GetAll();
        }

        [HttpPost("Add")]
        public async Task Add(ItemContract request) { 

            Item item = new Item();
            item.Name = request.itemName;
            item.Price = request.price;

            await _itemService.Add(item);
        }

    }
}
