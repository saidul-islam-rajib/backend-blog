using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserInformationAggregate;
using Sober.Domain.Aggregates.UserInformationAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations;

public class UserInformationConfiguration : IEntityTypeConfiguration<UserInformation>
{
    public void Configure(EntityTypeBuilder<UserInformation> builder)
    {
        ConfigureUserInformationTable(builder);
    }

    private void ConfigureUserInformationTable(EntityTypeBuilder<UserInformation> builder)
    {
        builder.ToTable(nameof(UserInformation));
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => UserInformationId.Create(value))
            .ValueGeneratedNever();

        builder.Property(x => x.Bio).HasMaxLength(2000).IsRequired();
        builder.Property(x => x.UserName).HasColumnName("Name").HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.Email).HasMaxLength(50).IsRequired(false);


        builder.Property(x => x.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value))
                .IsRequired();

        builder.HasOne(x => x.User)
        .WithMany()
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
