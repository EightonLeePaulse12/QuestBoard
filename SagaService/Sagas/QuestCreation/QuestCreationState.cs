using MassTransit;

namespace SagaService.Sagas.QuestCreation
{
    public class QuestCreationState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public Guid QuestId { get; set; }
        public Guid PlayerId { get; set; }
        public bool EmailSent { get; set; }
        public string CurrentState { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
