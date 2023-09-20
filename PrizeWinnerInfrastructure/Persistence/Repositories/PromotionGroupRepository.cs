using Microsoft.EntityFrameworkCore;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Domain.Entities;

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

        public async Task<PromotionGroup?> GetById(int groupId)
        {
            return await _appDbContext.PromotionGroups.FirstOrDefaultAsync(x=>x.PromotionGroupId==groupId);
        }

        public async Task Update(PromotionGroup entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }

}
