using MassTransit;
using PlayerService.Infrastructure;
using Shared.Contracts.DTOs;
using Shared.Library.Entities;

namespace PlayerService.Repository
{
    public class PlayerRepo(PlayerDbContext context, IPublishEndpoint publishEndpoint) : IPlayerRepo
    {
        public async Task<ServiceResponse> CreatePlayerAsync(Player playerData)
        {
            context.Players.Add(playerData);
            await context.SaveChangesAsync();
            return new ServiceResponse(true, "Player created successfully");
        }
    }
}