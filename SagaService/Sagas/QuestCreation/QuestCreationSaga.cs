using MassTransit;
using Shared.Contracts.Commands;
using Shared.Contracts.DomainEvents;

namespace SagaService.Sagas.QuestCreation
{
    public class QuestCreationSaga : MassTransitStateMachine<QuestCreationState>
    {
        // States
        public State Completed { get; private set; }

        // Events we listen to
        public Event<QuestCreated> QuestCreated { get; private set; }

        public QuestCreationSaga()
        {
            // Tell MassTransit where state is stored
            InstanceState(x => x.CurrentState);

            // How to correlate messages to the same saga instance
            Event(() => QuestCreated,
                x => x.CorrelateById(ctx => ctx.Message.QuestId));

            Initially(
                When(QuestCreated)
                .Then(ctx =>
                {
                    ctx.Saga.QuestId = ctx.Message.QuestId;
                    ctx.Saga.PlayerId = ctx.Message.PlayerId;
                })
                .Publish(ctx => new SendEmail( // Not yet implemented
                        ctx.Saga.PlayerId,
                        "Level Up!",
                        "Congratulations on leveling up!"
                    ))
                        .TransitionTo(Completed)
            );
        }
    }
}
