using QuestService.Domain;
using Shared.Contracts.DTOs;

namespace QuestService.Repository
{
    public interface IQuestRepo
    {
        Task<List<Quest>?> GetAllQuestsByPlayerIdAsync(Guid playerId);

        Task<ServiceResponse> AddQuestAsync(Quest quest);

        Task<ServiceResponse> MarkQuestCompletedAsync(Guid questId);
    }
}