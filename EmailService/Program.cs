using EmailService.Consumers;
using EmailService.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.DTOs;
using Shared.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddScoped<IEmailServices, EmailServices>();

builder.Services.AddMassTransitConf(builder.Configuration, "email-service", x =>
{
    x.AddConsumer<QuestCompletedConsumer>();
    x.AddConsumer<PlayerLeveledUpConsumer>();
    x.AddConsumer<QuestCreatedConsumer>();
    x.AddConsumer<XpAwardedConsumer>();
});

var app = builder.Build();

app.MapPost("/email-notifications", async ([FromBody] EmailStructure email, IEmailServices service) =>
{
    await service.SendEmailAsync(email);
    return Results.Ok();
});

app.Run();                                                         