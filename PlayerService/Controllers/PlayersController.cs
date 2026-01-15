using Microsoft.AspNetCore.Mvc;
using PlayerService.Repository;
using Shared.Contracts.DTOs;
using Shared.Library.Entities;

namespace PlayerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController(IPlayerRepo playerRepo) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> CreatePlayer(Player player)
        {
            var response = await playerRepo.CreatePlayerAsync(player);

            return response.Flag ? Ok(response) : BadRequest(response);
        }
    }
}