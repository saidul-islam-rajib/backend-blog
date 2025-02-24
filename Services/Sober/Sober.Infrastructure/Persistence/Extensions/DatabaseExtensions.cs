using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();
        //await SeedDataAsync(context);
    }

    private static async Task SeedDataAsync(BlogDbContext context)
    {
        var userId = UserId.CreateUnique();
        var postId = PostId.CreateUnique();
        var topicId = TopicId.CreateUnique();
        var tagId = TagId.CreateUnique();

        if (!await context.Users.AnyAsync())
        {
            userId = await SeedUserAsync(context);
        }
        if (!await context.Posts.AnyAsync())
        {
            postId = await SeedPostAsync(context, userId);
        }

        if(!await context.Topics.AnyAsync())
        {
            topicId = await SeedTopicAsync(context);
        }
        if (!await context.Tags.AnyAsync())
        {
            tagId = await SeedTagAsync(context, topicId);
        }
        if(!await context.Projects.AnyAsync())
        {
            await SeedProjectAsync(context, userId, postId, topicId, tagId);
        }

        if(!await context.Experiences.AnyAsync())
        {
            await SeedExperienceAsync(context, userId);
        }

        if (!await context.Publications.AnyAsync())
        {
            await SeedPublicationAsync(context, userId);
        }
        if (!await context.Interests.AnyAsync())
        {
            await SeedInterestAsync(context, userId);
        }

        if (!await context.AdditionalSkills.AnyAsync())
        {
            await SeedAdditionalSkillAsync(context, userId);
        }

        if (!await context.Educations.AnyAsync())
        {
            await SeedEducationAsync(context, userId);
        }

        if (!await context.Comments.AnyAsync())
        {
            await SeedCommentAsync(context, postId);
        }

    }

    private static async Task<UserId> SeedUserAsync(BlogDbContext context)
    {
        var user = InitialData.CreateUserAsync();
        await context.Users.AddRangeAsync(user);
        await context.SaveChangesAsync();

        return user.Id;
    }

    private static async Task<TopicId> SeedTopicAsync(BlogDbContext context)
    {
        var topic = InitialData.CreateTopicAsync();
        await context.Topics.AddRangeAsync(topic);
        await context.SaveChangesAsync();

        return topic.Id;
    }

    private static async Task<TagId> SeedTagAsync(BlogDbContext context, TopicId topicId)
    {
        var tag = InitialData.CreateTagAsync(topicId);
        await context.Tags.AddRangeAsync(tag);
        await context.SaveChangesAsync();

        return tag.Id;
    }

    private static async Task SeedProjectAsync(BlogDbContext context, UserId userId, PostId postId, TopicId topicId, TagId tagId)
    {
        var project = InitialData.CreateProjectAsync(userId, postId, topicId, tagId);
        await context.Projects.AddRangeAsync(project);
        await context.SaveChangesAsync();
    }


    private static async Task SeedExperienceAsync(BlogDbContext context, UserId userId)
    {
        var experiences = InitialData.CreateExperienceAsync(userId);
        await context.Experiences.AddRangeAsync(experiences);
        await context.SaveChangesAsync();
    }

    private static async Task SeedPublicationAsync(BlogDbContext context, UserId userId)
    {
        var publicatoins = InitialData.CreatePublicationAsync(userId);
        await context.Publications.AddRangeAsync(publicatoins);
        await context.SaveChangesAsync();
    }
    private static async Task SeedInterestAsync(BlogDbContext context, UserId userId)
    {
        var interests = InitialData.CreateInterestAsync(userId);
        await context.Interests.AddRangeAsync(interests);
        await context.SaveChangesAsync();
    }
    private static async Task SeedAdditionalSkillAsync(BlogDbContext context, UserId userId)
    {
        var skills = InitialData.CreateAdditionalSkillAsync(userId);
        await context.AdditionalSkills.AddRangeAsync(skills);
        await context.SaveChangesAsync();
    }

    private static async Task SeedEducationAsync(BlogDbContext context, UserId userId)
    {
        var educations = InitialData.CreateEducationAsync(userId);
        await context.Educations.AddRangeAsync(educations);
        await context.SaveChangesAsync();
    }

    private static async Task SeedCommentAsync(BlogDbContext context, PostId postId)
    {
        var comments = InitialData.CreateCommentAsync(postId);
        await context.Comments.AddRangeAsync(comments);
        await context.SaveChangesAsync();
    }

    private static async Task<PostId> SeedPostAsync(BlogDbContext context, UserId userId)
    {
        List<Post> posts = InitialData.CreatePostAsync(userId);
        await context.Posts.AddRangeAsync(posts);
        await context.SaveChangesAsync();

        return posts[0].Id;
    }
}
