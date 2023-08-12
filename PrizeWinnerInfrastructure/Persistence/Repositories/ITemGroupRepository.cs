﻿using Microsoft.EntityFrameworkCore;
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
    }
}
