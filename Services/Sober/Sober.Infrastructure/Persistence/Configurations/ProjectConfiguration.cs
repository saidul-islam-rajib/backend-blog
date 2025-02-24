using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.ProjectAggregates;
using Sober.Domain.Aggregates.ProjectAggregates.Entities;
using Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        ConfigureProjectTable(builder);
        ConfigureProjectTopicTable(builder);
    }    

    private void ConfigureProjectTable(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => ProjectId.Create(value))
            .ValueGeneratedNever()
            .HasColumnName("ProjectId");

        builder.Property(x => x.ProjectTitle).HasMaxLength(100).IsRequired();
        builder.Property(x => x.ProjectSummary).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.ProjectSrcLink).HasMaxLength(300).IsRequired();
        builder.Property(x => x.ProjectImage).IsRequired();
        builder.Property(x => x.DisplayDate)
            .HasConversion(
                v => v.HasValue ? v.Value.ToString("MMMM dd, yyyy") : null,
                v => string.IsNullOrEmpty(v) ? (DateTime?)null : DateTime.Parse(v)).IsRequired(false);
        builder.Property(x => x.StartDate)
            .HasConversion(
                v => v.HasValue ? v.Value.ToString("MMMM dd, yyyy") : null,
                v => string.IsNullOrEmpty(v) ? (DateTime?)null : DateTime.Parse(v)).IsRequired(false);
        builder.Property(x => x.EndDate)
            .HasConversion(
                v => v.HasValue ? v.Value.ToString("MMMM dd, yyyy") : null, 
                v => string.IsNullOrEmpty(v) ? (DateTime?)null : DateTime.Parse(v)).IsRequired(false);

        builder.Property(x => x.PostId).HasConversion(id => id.Value, value => PostId.Create(value)).IsRequired();
        builder.Property(x => x.UserId).HasConversion(id => id.Value, value => UserId.Create(value)).IsRequired();

        builder.HasOne<Post>().WithMany().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureProjectTopicTable(EntityTypeBuilder<Project> builder)
    {
        builder.OwnsMany(x => x.ProjectSection, sb =>
        {
            sb.ToTable("ProjectTopics");
            sb.WithOwner().HasForeignKey("ProjectId");
            sb.HasKey("Id", "ProjectId");

            sb.Property(x => x.Id).ValueGeneratedNever().HasColumnName("ProjectTopicId")
                .HasConversion(id => id.Value, value => ProjectSectionId.Create(value));
            sb.Property(x => x.TopicId).HasConversion(id => id.Value, value => TopicId.Create(value)).IsRequired();

            sb.HasOne(x => x.Topic)
                .WithMany()
                .HasForeignKey(x => x.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            sb.OwnsMany(t => t.ProjectTags, tb =>
            {
                tb.ToTable("ProjectTags");
                tb.WithOwner().HasForeignKey("ProjectTopicId", "ProjectId");
                tb.HasKey(nameof(ProjectTag.Id), "ProjectTopicId", "ProjectId");
                tb.Property(t => t.Id).ValueGeneratedNever().HasColumnName("ProjectTagId")
                    .HasConversion(id => id.Value, value => ProjectTagId.Create(value));

                tb.Property(x => x.TagId).HasConversion(id => id.Value, value => TagId.Create(value)).IsRequired();

                tb.HasOne(x => x.Tag)
                .WithMany()
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            });
            sb.Navigation(s => s.ProjectTags).Metadata.SetField("_tags");
            sb.Navigation(s => s.ProjectTags).UsePropertyAccessMode(PropertyAccessMode.Field);
        });
        builder.Metadata.FindNavigation(nameof(Project.ProjectSection))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
