using Shared.Library.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestService.Domain
{
    public class Quest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int RewardXp { get; set; }
        public QuestStatus Status { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }
}
