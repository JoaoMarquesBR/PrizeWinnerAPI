using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Services
{
    public class ItemGroupService : IItemGroupService<ItemGroup>
    {
        private readonly IItemGroupRepository<ItemGroup> _itemGroupRepo;

        public ItemGroupService(IItemGroupRepository<ItemGroup> itemRepo)
        {
            _itemGroupRepo = itemRepo;
        }

        public async Task Add(ItemGroup entity)
        {
            await _itemGroupRepo.Add(entity);
        }

        public async Task<IEnumerable<ItemGroup>> GetAll()
        {
            return await _itemGroupRepo.GetAll();
        }

        public async Task<ItemGroup> GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
