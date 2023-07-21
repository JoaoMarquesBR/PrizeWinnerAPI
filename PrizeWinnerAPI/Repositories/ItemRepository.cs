using Microsoft.EntityFrameworkCore;
using PrizeWinnerAPI.Models;
using System.ComponentModel;

namespace PrizeWinnerAPI.Repositories
{
    public class ItemRepository
    {
        private readonly AppDbContext _appDbContext;

        //public ItemRepository(AppDbContext ctc) { 
        //    _appDbContext = ctc;
        //}

        //public async Task<List<Item>> GetAll() {
        //    return await _appDbContext.Item.ToListAsync();
        //}

        //public async Task AddGuest(Item item)
        //{
        //    try
        //    {
        //        await _appDbContext.AddAsync(item);
        //        await _appDbContext.SaveChangesAsync();

        //    }catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //}

    }

}
