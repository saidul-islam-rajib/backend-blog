using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.CommentAggregate.ValueObjects;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            ConfigureCommentTable(builder);
        }

        private void ConfigureCommentTable(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever().HasConversion(id => id.Value, value => CommentId.Create(value));
            
            builder.Property(x => x.Name).HasMaxLength(100);            
            builder.Property(x => x.Comments).HasMaxLength(500);

            builder.Property(x => x.PostTitle).HasMaxLength(100);
            builder.Property(x => x.PostId).HasConversion(id => id.Value, value => PostId.Create(value)).IsRequired();
            builder.HasOne<Post>().WithMany().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
