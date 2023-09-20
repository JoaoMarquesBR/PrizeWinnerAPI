using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PrizeWinner.Application.Interface.IRepository;
using PrizeWinner.Contracts.Records;
using PrizeWinner.Contracts.Responses;

namespace PrizeWinnerAPI.Controllers
{
    [ApiController]
    [Route("Group")]
    public class GroupController : ControllerBase
    {
        private readonly IPromotionGroupService _group;

        public GroupController(IPromotionGroupService grouRepo)
        {
            _group = grouRepo;
        }

        [HttpGet("All")]
        public async Task<List<GroupResponse>> getAll()
        {
            return await _group.GetAll();
        }

        [HttpPost("Add")]
        public  async Task<IActionResult> Add([FromBody] PromotionGroupContract request)
        {
            await _group.Add(request);

            return Ok();
        }

    }
}
