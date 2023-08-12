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

        public Task<IEnumerable<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetById(object id)
        {
            throw new NotImplementedException();
        }
    }

}
