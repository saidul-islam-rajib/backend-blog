using Microsoft.EntityFrameworkCore;
using Sober.Domain.Aggregates.AdditionalSkillAggregate;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.FeedbackAggregate;
using Sober.Domain.Aggregates.InterestAggregates;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.ProjectAggregates;
using Sober.Domain.Aggregates.PublicationAggregate;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.TagAggregates;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserInformationAggregate;
namespace Sober.Infrastructure.Persistence
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserInformation> UserInformations { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<Experience> Experiences { get; set; } = null!;
        public DbSet<Education> Educations { get; set; } = null!;
        public DbSet<Publication> Publications { get; set; } = null!;
        public DbSet<AdditionalSkill> AdditionalSkills { get; set; } = null!;
        public DbSet<Interest> Interests { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
