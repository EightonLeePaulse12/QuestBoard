using MassTransit;
using Shared.Contracts.DomainEvents;
using Shared.Contracts.Sagas;

namespace SagaService.Sagas
{
    public class QuestCompletionSaga : MassTransitStateMachine<QuestCompletionState>
    {
        // States
        public State WaitingForXp { get; private set; }
        public State Completed { get; private set; }

        // Events we listen to
        public Event<QuestCompleted> QuestCompleted { get; private set; }
        public Event<PlayerLeveledUp> PlayerLeveledUp { get; private set; }

        public QuestCompletionSaga()
        {
            // Tell MassTransit where state is stored
            InstanceState(x => x.CurrentState);

            // How to correlate messages to the same saga instance
            Event(() => QuestCompleted, x =>
                x.CorrelateById(ctx => ctx.Message.PlayerId));

            Initially(
                When(QuestCompleted)
                    .Then(ctx =>
                    {
                        ctx.Instance.QuestId = ctx.Data.Id;
                        ctx.Instance.PlayerId = ctx.Data.PlayerId;
                    })
                    .Publish(ctx =>
                        new AwardXp(ctx.Data.PlayerId, ctx.Data.RewardXp))
                        .TransitionTo(WaitingForXp)
            );

            During(WaitingForXp,
                When(PlayerLeveledUp)
                .Publish(ctx =>
                    new SendLevelUpEmail(ctx.Data.PlayerId, ctx.Data.NewLevel))
                        .TransitionTo(Completed)
                        );
        }
    }
}
