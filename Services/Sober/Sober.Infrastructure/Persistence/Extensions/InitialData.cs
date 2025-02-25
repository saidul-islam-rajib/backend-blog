using Sober.Domain.Aggregates.AdditionalSkillAggregate;
using Sober.Domain.Aggregates.AdditionalSkillAggregate.Entities;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.Entities;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate.Entities;
using Sober.Domain.Aggregates.InterestAggregates;
using Sober.Domain.Aggregates.InterestAggregates.Entities;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.Entities;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.ProjectAggregates;
using Sober.Domain.Aggregates.ProjectAggregates.Entities;
using Sober.Domain.Aggregates.PublicationAggregate;
using Sober.Domain.Aggregates.PublicationAggregate.Entities;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Extensions;

internal class InitialData
{
    public static List<Education> CreateEducationAsync(UserId userId)
    {
        var educations = new List<Education>
        {
            Education.Create(
                userId,
                "Daffodil International University",
                "diu.png",
                "Computer Science & Engineering",
                false,
                new List<EducationSection>
                {
                    EducationSection.Create("Learned basics of Algorithms, Data Structure, Computer Networks, Operating Systems etc"),
                    EducationSection.Create("Participated several programming contests including ICPC, IUPC, CPC etc")
                },
                new DateTime(2018, 01, 01),
                new DateTime(2022, 02, 22)
            )
        };

        return educations;
    }
    public static List<Experience> CreateExperienceAsync(UserId userId)
    {
        var experiences = new List<Experience>
        {
            Experience.Create(
                userId,
                "ASA International Management Services Limited",
                "AMSL",
                "amsl.png",
                "Intern Software Engineer",
                false,
                true,
                new List<ExperienceSection>
                {
                    ExperienceSection.Create("Improved application performance around 30%")
                },
                new DateTime(2022, 10, 10),
                new DateTime(2023, 01, 10)),

            Experience.Create(
                userId,
                "ASA International Management Services Limited",
                "AMSL",
                "amsl.png",
                "Junior Software Engineer",
                true,
                true,
                new List<ExperienceSection>
                {
                    ExperienceSection.Create("Design, Develop and Maintain software applicatoin"),
                    ExperienceSection.Create("Fix bugs of an existing software application"),
                    ExperienceSection.Create("Got extensive knowledge on microservices integration, devops pipeline etc")
                },
                new DateTime(2023, 01, 11),
                new DateTime(2025, 01, 02))
        };

        return experiences;
    }
    public static List<Publication> CreatePublicationAsync(UserId userId)
    {
        var publications = new List<Publication>
        {
            Publication.Create(
                "A method for finding eligible employees based on specification",
                "The name of our country is Bangladesh. Bangladesh is a small country but it has a large population. Majority of it's population are poor and illiterate. They don't know how to read and write.",
                userId,
                
                new List<PublicationKey>
                {
                    PublicationKey.Create("FAHP"),
                    PublicationKey.Create("AHP"),
                },
                "Journal Name Not Found!",
                new DateTime(2025, 01, 11),
                null),

            Publication.Create(
                "A method for finding eligible employees based on specification v2",
                "The name of our country is Bangladesh. Bangladesh is a small country but it has a large population. Majority of it's population are poor and illiterate. They don't know how to read and write. v2",
                userId,

                new List<PublicationKey>
                {
                    PublicationKey.Create("ELECTRE")
                },
                null,
                null,
                null)
        };

        return publications;
    }

    public static List<Interest> CreateInterestAsync(UserId userId)
    {
        var publications = new List<Interest>
        {
            Interest.Create(
                "Test interest title",
                userId,
                new List<InterestKey>
                {
                    InterestKey.Create("First Interest Key"),
                    InterestKey.Create("Second Interest Key")
                },
                null)
        };

        return publications;
    }

    public static List<AdditionalSkill> CreateAdditionalSkillAsync(UserId userId)
    {
        var skills = new List<AdditionalSkill>
        {
            AdditionalSkill.Create(
                "Additional Skill Title",
                userId,
                new List<AdditionalKey>
                {
                    AdditionalKey.Create("Additional first key"),
                    AdditionalKey.Create("Additional second key"),
                    AdditionalKey.Create("Additional third key")
                },
                null)
        };

        return skills;
    }

    public static Topic CreateTopicAsync()
    {
        var topic = Topic.Create("Data Structure & Algorithms");
        return topic;
    }

    public static Tag CreateTagAsync(TopicId topicId)
    {
        var tag = Tag.Create("Depth First Search", topicId);
        return tag;
    }
    public static Project CreateProjectAsync(UserId userId, PostId postId, TopicId topicId, TagId tagId)
    {
        var project =
                Project.Create(
                    new List<ProjectSection>
                    {
                        ProjectSection.Create(
                            topicId,
                            new List<ProjectTag>
                            {
                                ProjectTag.Create(tagId),
                                ProjectTag.Create(tagId)
                            }
                        )
                    },
                    "Testing project title",
                    "Testing project summary",
                    "http:sober.org.bd",
                    "rajib.png",
                    userId,
                    postId,
                    new DateTime(2022, 10, 10),
                    new DateTime(2025, 11, 11),
                    new DateTime(2024, 12, 1)
                );

        return project;
    }

    public static List<Comment> CreateCommentAsync(PostId postId)
    {
        var comments = new List<Comment>
        {
            Comment.Create(
                postId,
                "Sajib Ahmed",
                "This is one of the best project...",
                "Post Title 1"),

            Comment.Create(
                postId,
                "Rakib Ahmed",
                "This is one of the best project...",
                "Post Title 2")
        };
        return comments;
    }

    public static User CreateUserAsync()
    {
        var user = User.Create(
            "Saidul Islam Rajib",
            "saidul.is.rajib@gmail.com",
            "Test@123"
        );
        return user;
    }

    public static List<Post> CreatePostAsync(UserId userId)
    {

        var posts =  new List<Post>
            {
                Post.Create(
                    userId,
                    "POST TITLE 1",
                    "This is post abstraction",
                    "this is all about conclusions.",
                    10,
                    new List<PostSection>
                    {
                        PostSection.Create(
                            "Section title 1",
                            "Section description",
                            new List<PostItem>
                            {
                                PostItem.Create(
                                    "item title 1",
                                    "item description 1",
                                    "first.png"
                                ),
                                PostItem.Create(
                                    "item title 2",
                                    "item description 2",
                                    "second.png"
                                )
                            },
                            null
                        )
                    },
                    new List<PostTopic>
                    {
                        PostTopic.Create(
                            UserId.Create(Guid.NewGuid()),
                            "Topic title 1"
                        )
                    },
                    null
                )
            };

        return posts;
    }
}
