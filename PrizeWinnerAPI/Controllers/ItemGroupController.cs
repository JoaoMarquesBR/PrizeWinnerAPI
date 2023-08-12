using Microsoft.AspNetCore.Mvc;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Domain.Entities;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("/ItemRoute")]
    public class ItemGroupController : ControllerBase
    {
        private readonly IItemService<Item> _itemService;

        public ItemGroupController(IItemService<Item> itemService)
        {
            _itemService = itemService;
        }

        //[HttpGet("GetAll")]
        //public async Task<List<ItemRepository>> getAll()
        //{
        //    //return await _itemRepository.GetAll()/*/*;*/*/
        //}

        [HttpPost("Add")]
        public async Task Add(ItemContract request) { 

            Item item = new Item();
            item.Name = request.itemName;
            item.Price = request.price;

            await _itemService.Add(item);
        }

    }
}
