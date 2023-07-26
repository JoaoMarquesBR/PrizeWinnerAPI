using Microsoft.EntityFrameworkCore;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinnerAPI.Domain;
using PrizeWinnerAPI.Models;
using System.ComponentModel;

namespace PrizeWinnerAPI.Repositories
{
    public class PromotionGroupRepository : IPromotionGroupRepository
    {
        private readonly TheFactoryDevContext _appDbContext;

        public PromotionGroupRepository(TheFactoryDevContext ctc) { 
            _appDbContext = ctc;
        }

     
        public Task<PromotionGroup> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(PromotionGroup entity)
        {
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PromotionGroup>> GetAll()
        {
            return await _appDbContext.PromotionGroups.ToListAsync();
        }
    }

}
