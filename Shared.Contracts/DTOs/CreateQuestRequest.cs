namespace Shared.Contracts.DTOs
{
    public class CreateQuestRequest
    {
        public Guid PlayerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int XpReward { get; set; }
    }
}