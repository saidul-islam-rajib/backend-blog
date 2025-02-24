using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.PublicationAggregate;
using Sober.Domain.Aggregates.PublicationAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations;

public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
{
    public void Configure(EntityTypeBuilder<Publication> builder)
    {
        ConfigurePublicationTable(builder);
        ConfigurePublicationKeyTable(builder);
    }

    private void ConfigurePublicationTable(EntityTypeBuilder<Publication> builder)
    {
        builder.ToTable("Publications");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => PublicationId.Create(value))
            .ValueGeneratedNever();

        builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
        builder.Property(x => x.JournalName).HasMaxLength(150).IsRequired(false);
        builder.Property(x => x.Summary).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Date);

        builder.Property(x => x.UserId)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    private void ConfigurePublicationKeyTable(EntityTypeBuilder<Publication> builder)
    {
        builder.OwnsMany(x => x.Keys, sb =>
        {
            sb.ToTable("PublicationKey");
            sb.WithOwner().HasForeignKey("PublicationId");
            sb.HasKey("Id", "PublicationId");
            sb.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnName("PublicationKeyId")
            .HasConversion(id => id.Value, value => PublicationKeyId.Create(value));
            sb.Property(x => x.Key).HasMaxLength(100);
        });
    }
}
