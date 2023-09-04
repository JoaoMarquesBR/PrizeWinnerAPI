using Microsoft.EntityFrameworkCore;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Domain.Entities;
using System.ComponentModel;

namespace PrizeWinnerAPI.Repositories
{
    public class IItemRepository : IItemRepository<Item>
    {
        private readonly TheFactoryDevContext _appDbContext;

        public IItemRepository(TheFactoryDevContext ctc) { 
            _appDbContext = ctc;
        }

        public async Task Add(Item entity)
        {
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _appDbContext.Items.ToListAsync();
        }

        public async Task<Item> GetById(object id)
        {
            int intValue = (int)id; 
            return await _appDbContext.Items.FirstOrDefaultAsync(x => x.ItemId == intValue);
        }
    }

}
