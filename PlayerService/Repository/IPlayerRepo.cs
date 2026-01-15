using Shared.Contracts.DTOs;
using Shared.Library.Entities;

namespace PlayerService.Repository
{
    public interface IPlayerRepo
    {
        Task<ServiceResponse> CreatePlayerAsync(Player playerData);
    }
}