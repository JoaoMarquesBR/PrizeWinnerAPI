using Microsoft.AspNetCore.Mvc;
using PrizeWinnerAPI.DTO;
using PrizeWinnerAPI.Models;
using PrizeWinnerAPI.Repositories;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("/ItemRoute")]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepository _itemRepository;

        public ItemController(ItemRepository itemRepo)
        {
            _itemRepository = itemRepo;
        }

        [HttpGet("GetAll")]
        public async Task<List<ItemRepository>> getAll()
        {
            return await _itemRepository.GetAll();
        }

        [HttpPost("AddItem")]
        public async Task Add(GuestDTO dto)
        {
            
        }

    }
}
