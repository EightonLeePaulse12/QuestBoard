using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaService.Sagas.QuestCompletion;
using SagaService.Sagas.QuestCreation;
using System.Collections.Generic;

namespace SagaService.Data
{
    public class SagaDbContext : MassTransit.EntityFrameworkCoreIntegration.SagaDbContext
    {
        public SagaDbContext(DbContextOptions<SagaDbContext> options) : base(options) { }

        // FIX: This satisfies the "NotImplementedException" error.
        // It tells MassTransit which maps to use for the database.
        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get
            {
                yield return new QuestCreationStateMap();
                yield return new QuestCompletionStateMap();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This ensures EF applies the rules inside your Map classes below
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SagaDbContext).Assembly);
        }
    }

    // These remain OUTSIDE the DbContext class so EF can find them easily
    public class QuestCreationStateMap : SagaClassMap<QuestCreationState>
    {
        protected override void Configure(EntityTypeBuilder<QuestCreationState> entity, ModelBuilder model)
        {
            entity.Property(x => x.CurrentState).HasMaxLength(64);
            entity.Property(x => x.RowVersion).IsRowVersion();
        }
    }

    public class QuestCompletionStateMap : SagaClassMap<QuestCompletionState>
    {
        protected override void Configure(EntityTypeBuilder<QuestCompletionState> entity, ModelBuilder model)
        {
            entity.Property(x => x.CurrentState).HasMaxLength(64);
            entity.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}