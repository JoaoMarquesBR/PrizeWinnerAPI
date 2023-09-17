using Microsoft.EntityFrameworkCore;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Domain.Entities;

using System.ComponentModel;

namespace PrizeWinnerAPI.Repositories
{
    public class GuestRepository : IGuestRepository<Guest>
    {
        private readonly TheFactoryDevContext _appDbContext;

        public GuestRepository(TheFactoryDevContext ctc) { 
            _appDbContext = ctc;
        }

        public async Task<Guest> GetRandom()
        {
            try
            {
                List<Guest>? guestList = await _appDbContext.Guests.ToListAsync();
                Random random = new Random();
                int randomNumber = random.Next(0, guestList.Count);
                return guestList.ElementAt(randomNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }



        public Task<Guest> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Guest entity)
        {
            try
            {
 await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _appDbContext.Guests.ToListAsync();
        }

        public async Task<IEnumerable<Guest>> GetGuestsByGroupID(int groupID)
        {
            return await _appDbContext.Guests.Where(x=> x.PromotionGroupId == groupID).ToListAsync();
        }
    }

}
