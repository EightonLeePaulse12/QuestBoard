using Shared.Library.Enums;

namespace QuestService.Domain
{
    public class Quest
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int RewardXp { get; set; }
        public QuestStatus Status { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }
}