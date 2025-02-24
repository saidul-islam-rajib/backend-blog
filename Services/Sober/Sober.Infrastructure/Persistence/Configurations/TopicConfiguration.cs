using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            ConfigureSkillTable(builder);
        }

        private void ConfigureSkillTable(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(id => id.Value, value => TopicId.Create(value))
                .ValueGeneratedNever()
                .HasColumnName("TopicId");

            builder.Property(x => x.TopicName).HasMaxLength(50).IsRequired();

        }
    }
}
