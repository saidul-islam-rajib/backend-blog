using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.AdditionalSkillAggregate;
using Sober.Domain.Aggregates.AdditionalSkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations;

public class AdditionalSkillConfiguration : IEntityTypeConfiguration<AdditionalSkill>
{
    public void Configure(EntityTypeBuilder<AdditionalSkill> builder)
    {
        ConfigureAdditionalSkillTable(builder);
        ConfigureAdditionalSkillKeyTable(builder);
    }

    private void ConfigureAdditionalSkillTable(EntityTypeBuilder<AdditionalSkill> builder)
    {
        builder.ToTable("AdditionalSkill");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => AdditionalSkillId.Create(value))
            .ValueGeneratedNever();

        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Image).IsRequired(false);
        builder.Property(x => x.UserId)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .IsRequired();
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureAdditionalSkillKeyTable(EntityTypeBuilder<AdditionalSkill> builder)
    {
        builder.OwnsMany(x => x.Keys, sb =>
        {
            sb.ToTable("AdditionalSkillKey");
            sb.WithOwner().HasForeignKey("AdditionalSkillId");
            sb.HasKey("Id", "AdditionalSkillId");

            sb.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("AdditionalSkillKeyId")
                .HasConversion(id => id.Value, value => AdditionalSkillKeyId.Create(value));
            sb.Property(x => x.Key).HasMaxLength(1000).IsRequired(false);
        });
    }
}
