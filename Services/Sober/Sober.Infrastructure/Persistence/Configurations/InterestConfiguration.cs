using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.InterestAggregates;
using Sober.Domain.Aggregates.InterestAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations;

public class InterestConfiguration
    : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        ConfigureInterestTable(builder);
        ConfigureInterestKeyTable(builder);
    }

    private void ConfigureInterestTable(EntityTypeBuilder<Interest> builder)
    {
        builder.ToTable("Interests");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => InterestId.Create(value))
            .ValueGeneratedNever();

        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.UserId).HasConversion(id => id.Value, value => UserId.Create(value))
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureInterestKeyTable(EntityTypeBuilder<Interest> builder)
    {
        builder.OwnsMany(x => x.Keys, sb =>
        {
            sb.ToTable("InterestKey");
            sb.WithOwner().HasForeignKey("InterestId");
            sb.HasKey("Id", "InterestId");
            sb.Property(x => x.Id).ValueGeneratedNever().HasColumnName("InterestKeyId")
                .HasConversion(id => id.Value, value => InterestKeyId.Create(value));
            sb.Property(x => x.Key).HasMaxLength(1000);
        });
    }
}
