using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Services
{
    public class ItemService : IItemService<Item>
    {
        private readonly IItemRepository<Item> _guestRepo;

        public ItemService(IItemRepository<Item> itemRepo)
        {
            _guestRepo = itemRepo;
        }

        public async Task Add(Item entity)
        {
            await _guestRepo.Add(entity);
        }

        async Task<IEnumerable<Item>> IGenericRepository<Item>.GetAll()
        {
            return await _guestRepo.GetAll();

        }

        async Task<Item> IGenericRepository<Item>.GetById(object id)
        {
            return await _guestRepo.GetById(id);
        }
    }
}
