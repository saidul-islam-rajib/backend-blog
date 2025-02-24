using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            ConfigureEducationTable(builder);
            ConfigureEducationSectionTable(builder);
        }        

        private void ConfigureEducationTable(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => EducationId.Create(value));

            builder.Property(x => x.InstituteName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.InstituteLogo)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.Department)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.IsCurrentStudent);

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired(false);

            builder.Property(x => x.UserId)
                .HasConversion(id => id.Value, value => UserId.Create(value))
                .IsRequired();            
        }

        private void ConfigureEducationSectionTable(EntityTypeBuilder<Education> builder)
        {
            builder.OwnsMany(e => e.EducationSection, sb =>
            {
                sb.ToTable("EducationSection");
                sb.WithOwner()
                    .HasForeignKey("EducationId");
                sb.HasKey("Id", "EducationId");
                sb.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("EducationSectionId")
                    .HasConversion(id => id.Value, value => EducationSectionId.Create(value));
                sb.Property(e => e.SectionDescription).HasMaxLength(1000);
            });
        }
    }
}
