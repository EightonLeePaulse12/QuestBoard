using MassTransit;
using Shared.Contracts.Commands;
using Shared.Contracts.DomainEvents;

namespace SagaService.Sagas.QuestCompletion
{
    public class QuestCompletionSaga : MassTransitStateMachine<QuestCompletionState>
    {
        // States
        public State WaitingForXp { get; private set; }
        public State Completed { get; private set; }

        // Events we listen to
        public Event<QuestCompleted> QuestCompleted { get; private set; }
        public Event<XpAwarded> XpAwarded { get; private set; }

        public QuestCompletionSaga()
        {
            InstanceState(x => x.CurrentState);

            Event(() => QuestCompleted, x =>
            {
                x.CorrelateById(ctx => ctx.Message.QuestId);
            });

            Event(() => XpAwarded, x =>
            {
                x.CorrelateById(ctx => ctx.Message.QuestId);
            });

            Initially(
                When(QuestCompleted)
                    .Then(ctx =>
                    {
                        ctx.Saga.QuestId = ctx.Message.QuestId;
                        ctx.Saga.PlayerId = ctx.Message.PlayerId;
                    })
                    .Publish(ctx => new AwardXp(
                        ctx.Message.PlayerId,
                        ctx.Message.RewardXp
                    ))
                    .TransitionTo(WaitingForXp)
            );

            During(WaitingForXp,
                When(XpAwarded)
                    .Publish(ctx => new SendEmail( // Not yet implemented
                        ctx.Saga.PlayerId,
                        "Xp Received!",
                        $"Congratulations on receiving {ctx.Message.Amount}Xp"
                    ))
                    .Finalize()
            );

            SetCompletedWhenFinalized();
        }
    }
}
