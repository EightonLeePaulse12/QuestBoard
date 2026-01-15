using Microsoft.EntityFrameworkCore;
using QuestService.Infrastructure;
using QuestService.Repository;
using Shared.Infrastructure.Messaging;
using Shared.Library.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommonInfrastructure(builder.Configuration);

builder.Services.AddDbContext<QuestDbContext>(conf =>
{
    conf.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddswaggerUI(builder.Configuration, "Quest Service", "Microservice for managing quest service");

builder.Services.AddScoped<IQuestRepo, QuestRepo>();

builder.Services.AddMassTransitConf(builder.Configuration, "QuestService");

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();