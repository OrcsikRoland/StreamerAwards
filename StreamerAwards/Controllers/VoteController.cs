using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamerAwards.Entities.DTOs;
using StreamerAwards.Logic.Services;

namespace StreamerAwards.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly VoteService _service;

        public VoteController(VoteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CastVote(string streamerId, string categoryId)
        {
            try
            {
                _service.CastVote(streamerId, categoryId);
                return Ok("Vote successfully cast.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{categoryId}/winner")]
        public IActionResult GetCategoryWinner(string categoryId)
        {
            var winner = _service.GetCategoryWinner(categoryId);
            if (winner == null)
                return NotFound($"No winner found for category ID {categoryId}.");

            return Ok(winner);
        }
    }
}
