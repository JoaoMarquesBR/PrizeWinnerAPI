using Microsoft.AspNetCore.Mvc;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Domain.Entities;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("/thefactoryAPI")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService<Guest> _guestService;

        public GuestController(IGuestService<Guest>guestService) {
            _guestService = guestService;
        }

        //[HttpGet("GetAll")]
        //public async Task<List<Guest>> getAll()
        //{
        //    return await _guestRepository.GetAll();
        //}

        // [HttpGet("GetRandom")]
        //public async Task<Guest> GetRandom()
        //{
        //    return await _guestRepository.GetRandom();
        //}

        [HttpPost("AddGuest")]
        public async Task Add(GuestContract req)
        {
            Guest guest = new Guest();
            guest.UserEmail = req.userEmail;
            guest.FirstName = req.firstName;
            //guest.GroupId = req.promotionGroupID;

            await _guestService.Add(guest);
        }

    }
}
