using Microsoft.EntityFrameworkCore;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinnerAPI.Domain;
using PrizeWinnerAPI.Models;

namespace PrizeWinnerAPI.Repositories
{
    public class ItemRepository : IItemRepository<Item>
    {
        private readonly TheFactoryDevContext _appDbContext;

        public ItemRepository(TheFactoryDevContext ctc)
        {
            _appDbContext = ctc;
        }

        public async Task<IEnumerable<Item>>GetAll()
        {
            return await _appDbContext.Items.ToListAsync();
        }

        public async Task Add(Item item)
        {
            try
            {
                await _appDbContext.AddAsync(item);
                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public Task<Item> GetById(object id)
        {
            throw new NotImplementedException();
        }
       
    }
}
