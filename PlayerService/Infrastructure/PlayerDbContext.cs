using Microsoft.EntityFrameworkCore;
using Shared.Library.Entities;

namespace PlayerService.Infrastructure
{
    public class PlayerDbContext(DbContextOptions<PlayerDbContext> options) : DbContext(options)
    {
        public DbSet<Player> Players { get; set; }
    }
}