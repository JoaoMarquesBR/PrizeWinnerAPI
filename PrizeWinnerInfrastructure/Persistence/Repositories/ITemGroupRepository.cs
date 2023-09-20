using Microsoft.EntityFrameworkCore;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Domain.Entities;

namespace PrizeWinnerAPI.Repositories
{
    public class ITemGroupRepository : IItemGroupRepository<ItemGroup>
    {
        private readonly TheFactoryDevContext _appDbContext;

        public ITemGroupRepository(TheFactoryDevContext ctc)
        {
            _appDbContext = ctc;
        }

        public async Task Add(ItemGroup entity)
        {
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemGroup>> GetAll()
        {
            return await _appDbContext.ItemGroups.ToListAsync();
        }

        public Task<ItemGroup> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemGroup>> GetPrizesByGroupId(int groupId)
        {
            return await _appDbContext.ItemGroups.
                Where(x => x.PromotionGroupId == groupId).
                ToListAsync();
        }

        public async Task Remove(int itemGroupId)
        {
            ItemGroup itemGroupToRemove = await _appDbContext.ItemGroups.FirstOrDefaultAsync(x => x.ItemGroupId == itemGroupId);

            if (itemGroupToRemove != null)
            {
                _appDbContext.ItemGroups.Remove(itemGroupToRemove);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
