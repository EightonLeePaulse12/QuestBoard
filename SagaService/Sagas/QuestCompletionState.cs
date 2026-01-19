using MassTransit;

namespace SagaService.Sagas
{
    public class QuestCompletionState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        // Business identifiers
        public Guid QuestId { get; set; }
        public Guid PlayerId { get; set; }

        // Tracking progress
        public bool XpAwarded { get; set; }
        public bool EmailSent { get; set; }

        // Required for state machines
        public string CurrentState { get; set; } = default!;
    }
}
