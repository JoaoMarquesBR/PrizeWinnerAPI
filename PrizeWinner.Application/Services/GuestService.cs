using PrizeWinner.Application.Interface.IRepository;
using PrizeWinnerAPI.Domain;
using PrizeWinnerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Services
{
    public class GuestService : IGuestService<Guest> 
    {
        private readonly IGuestRepository<Guest> _guestRepo;

        public GuestService(IGuestRepository<Guest> guestRepo)
        {
            _guestRepo = guestRepo;
        }

        public async Task Add(Guest entity)
        {
            await _guestRepo.Add(entity);
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _guestRepo.GetAll();
        }

        public async Task<Guest> GetById(object id)
        {
            return await _guestRepo.GetById(id);
        }
    }
}
