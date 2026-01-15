using Microsoft.AspNetCore.Mvc;
using QuestService.Domain;
using QuestService.Repository;
using Shared.Contracts.DTOs;

namespace QuestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController(IQuestRepo questRepo) : ControllerBase
    {
        [HttpGet("{playerId}")]
        public async Task<ActionResult<IEnumerable<Quest>>> GetQuestsAsync(Guid playerId)
        {
            try
            {
                var quests = await questRepo.GetAllQuestsByPlayerIdAsync(playerId);
                return Ok(quests);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> CreateQuest([FromBody] Quest quest)
        {
            var createdQuest = await questRepo.AddQuestAsync(quest);
            var response = new ServiceResponse
            {
                Flag = createdQuest != null,
                Message = createdQuest != null ? "Quest created successfully." : "Failed to create quest."
            };
            return CreatedAtAction(nameof(CreateQuest), response);
        }

        [HttpPost("complete/{questId}")]
        public async Task<ActionResult<ServiceResponse>> MarkQuestCompleted(Guid questId)
        {
            var result = await questRepo.MarkQuestCompletedAsync(questId);

            return result.Flag ? Ok(result) : BadRequest();
        }
    }
}