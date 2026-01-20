using MassTransit;
using Microsoft.EntityFrameworkCore;
using SagaService.Data;
using SagaService.Sagas.QuestCompletion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SagaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddMassTransit(x =>
{
    x.AddSagaStateMachine<QuestCompletionSaga, QuestCompletionState>()
        .EntityFrameworkRepository(r =>
        {
            r.ConcurrencyMode = ConcurrencyMode.Pessimistic;
            r.AddDbContext<DbContext, SagaDbContext>();
        });

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.Run();
