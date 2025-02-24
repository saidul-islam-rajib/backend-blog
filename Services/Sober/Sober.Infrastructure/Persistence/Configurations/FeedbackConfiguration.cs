using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.FeedbackAggregate;
using Sober.Domain.Aggregates.FeedbackAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        ConfigureFeedbackTable(builder);
    }

    private void ConfigureFeedbackTable(EntityTypeBuilder<Feedback> builder)
    {
        builder.ToTable(nameof(Feedback));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => FeedbackId.Create(value))
            .ValueGeneratedNever()
            .HasColumnName("FeedbackId");

        builder.Property(f => f.Email).HasMaxLength(100).IsRequired(true);
        builder.Property(f => f.Name).HasMaxLength(100).IsRequired(false);
        builder.Property(f => f.Comment).HasMaxLength(1000).IsRequired(false);
        builder.Property(f => f.GuestIpAddress).HasMaxLength(100).IsRequired(false);
    }
}
