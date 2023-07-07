using Microsoft.AspNetCore.Mvc;
using PrizeWinnerAPI.DTO;
using PrizeWinnerAPI.Models;
using PrizeWinnerAPI.Repositories;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("/thefactoryAPI")]
    public class GuestController : ControllerBase
    {
        private readonly GuestRepository _guestRepository;

        public GuestController(GuestRepository guestRepo)
        {
            _guestRepository = guestRepo;
        }

        [HttpGet("GetAll")]
        public async Task<List<Guest>> getAll()
        {
            return await _guestRepository.GetAll();
        }

         [HttpGet("GetRandom")]
        public async Task<Guest> GetRandom()
        {
            return await _guestRepository.GetRandom();
        }

        [HttpPost("AddGuest")]
        public async Task Add(GuestDTO dto)
        {
            Guest guest = new Guest();
            guest.UserEmail = dto.UserEmail;
            guest.FirstName = dto.FirstName;

            await _guestRepository.AddGuest(guest);
        }

    }
}
