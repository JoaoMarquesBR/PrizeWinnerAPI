using Microsoft.AspNetCore.Mvc;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Domain.Entities;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("/Guest")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService<Guest> _guestService;

        public GuestController(IGuestService<Guest>guestService) {
            _guestService = guestService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _guestService.GetAll();
        }

        [HttpGet("GetByGroupID")]
        public async Task<IEnumerable<Guest>> GetByGroupID(int groupID)
        {
            return await _guestService.GetGuestsByGroupID(groupID);
        }

        //[HttpGet("GetRandom")]
        //public async Task<IEnumerable<Guest>> GetRandom()
        //{
        //    return await _guestService.GetRandom();
        //}

        [HttpPost("Add")]
        public async Task Add(GuestContract req)
        {
            Guest guest = new Guest();
            guest.UserEmail = req.userEmail;
            guest.FirstName = req.firstName;
            guest.LastName = req.lastName;
            guest.GroupId = req.promotionGroupID;
            guest.SignedInDate = DateTime.Now;

            await _guestService.Add(guest);
        }

    }
}
