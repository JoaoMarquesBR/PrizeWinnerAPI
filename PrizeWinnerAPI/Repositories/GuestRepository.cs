using Microsoft.EntityFrameworkCore;
using PrizeWinnerAPI.Models;
using System.ComponentModel;

namespace PrizeWinnerAPI.Repositories
{
    public class GuestRepository
    {
        private readonly AppDbContext _appDbContext;

        public GuestRepository(AppDbContext ctc) { 
            _appDbContext = ctc;
        }

        public async Task<List<Guest>> GetAll() {
            return await _appDbContext.Guests.ToListAsync();
        }

        public async Task AddGuest(Guest guest)
        {
            try
            {
                await _appDbContext.AddAsync(guest);
                await _appDbContext.SaveChangesAsync();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public async Task<Guest> GetRandom()
        {
            try
            {
                List<Guest>? guestList =  await _appDbContext.Guests.ToListAsync();
                Random random = new Random();
                int randomNumber = random.Next(0, guestList.Count);
                return guestList.ElementAt(randomNumber);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

    }

}
