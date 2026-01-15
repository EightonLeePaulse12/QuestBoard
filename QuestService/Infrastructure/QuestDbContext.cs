using Microsoft.EntityFrameworkCore;
using QuestService.Domain;

namespace QuestService.Infrastructure
{
    public class QuestDbContext : DbContext
    {
        public QuestDbContext(DbContextOptions<QuestDbContext> options) : base(options)
        {
        }

        public DbSet<Quest> Quests { get; set; }
    }
}