using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.Entities;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Infrastructure.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            ConfigurePostTable(builder);
            ConfigurePostSectionTable(builder);
            ConfigureTopicTable(builder);
        }

        

        private void ConfigurePostTable(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever().HasConversion(id => id.Value, value => PostId.Create(value));
            builder.Property(x => x.PostTitle).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PostImage).IsRequired(false);
            builder.Property(x => x.PostAbstract).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Conclusion).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.ReadingMinute).HasMaxLength(4).IsRequired();

            builder.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigurePostSectionTable(EntityTypeBuilder<Post> builder)
        {
            builder.OwnsMany(p => p.Sections, sb =>
            {
                sb.ToTable("PostSections");
                sb.WithOwner().HasForeignKey("PostId");
                sb.HasKey("Id", "PostId");

                sb.Property(s => s.Id)
                  .ValueGeneratedNever()
                  .HasColumnName("PostSectionId")                  
                  .HasConversion(id => id.Value, value => PostSectionId.Create(value));
                sb.Property(s => s.SectionTitle).HasMaxLength(100);
                sb.Property(s => s.SectionImage).IsRequired(false);
                sb.Property(s => s.SectionDescription).HasMaxLength(1000);

                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("PostItems");
                    ib.WithOwner().HasForeignKey("PostSectionId", "PostId");
                    ib.HasKey(nameof(PostItem.Id), "PostSectionId", "PostId");

                    ib.Property(i => i.Id).ValueGeneratedNever().HasColumnName("PostItemId")
                    .HasConversion(id => id.Value, value => PostItemId.Create(value));
                    ib.Property(i => i.PostItemTitle).HasMaxLength(100);
                    ib.Property(i => i.PostItemImage).IsRequired(false);
                    ib.Property(i => i.PostItemDescription).HasMaxLength(1000);
                });

                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Post.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureTopicTable(EntityTypeBuilder<Post> builder)
        {
            builder.OwnsMany(t => t.TopicIds, tb =>
            {
                tb.ToTable("TopicTags");
                tb.WithOwner().HasForeignKey("PostId");
                tb.HasKey("Id", "PostId");

                tb.Property(t => t.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("TopicTagId")
                    .HasConversion(id => id.Value, value => PostTopicId.Create(value));
                tb.Property(t => t.TopicTitle).HasMaxLength(100);
            });
            builder.Metadata.FindNavigation(nameof(Post.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }


    }
}
