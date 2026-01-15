using Microsoft.EntityFrameworkCore;
using PlayerService.Consumers;
using PlayerService.Infrastructure;
using PlayerService.Repository;
using Shared.Infrastructure.Messaging;
using Shared.Library.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCommonInfrastructure(builder.Configuration);

builder.Services.AddDbContext<PlayerDbContext>(conf =>
{
    conf.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();

builder.Services.AddOpenApi();

builder.Services.AddswaggerUI(builder.Configuration, "Player Service", "Microservice for managing player service");

builder.Services.AddMassTransitConf(builder.Configuration, "player-service", x =>
{
    x.AddConsumer<QuestCompletedConsumer>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();