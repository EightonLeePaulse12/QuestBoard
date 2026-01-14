using Microsoft.EntityFrameworkCore;
using PlayerService.Infrastructure;
using Shared.Contracts.DomainEvents;
using Shared.Infrastructure.Messaging;
using Shared.Library.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCommonInfrastructure(builder.Configuration);

builder.Services.AddDbContext<PlayerDbContext>(conf =>
{
    conf.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddOpenApi();

builder.Services.AddswaggerUI(builder.Configuration, "Player Service", "Microservice for managing player service");

builder.Services.AddMassTransitConf(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
