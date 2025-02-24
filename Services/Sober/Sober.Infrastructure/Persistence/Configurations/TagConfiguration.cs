using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        ConfigureTagTable(builder);
    }

    private void ConfigureTagTable(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => TagId.Create(value));
        builder.Property(t => t.TagName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.TopicId)
            .HasConversion(id => id.Value, value => TopicId.Create(value)).IsRequired();

        builder.HasOne(t => t.Topic)
        .WithMany()
        .HasForeignKey(tag => tag.TopicId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
