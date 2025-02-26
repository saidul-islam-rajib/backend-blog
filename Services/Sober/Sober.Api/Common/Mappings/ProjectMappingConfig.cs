using Mapster;
using Sober.Application.Pages.Projects.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.ProjectAggregates;
using Sober.Domain.Aggregates.ProjectAggregates.Entities;

namespace Sober.Api.Common.Mappings;

public class ProjectMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(ProjectRequest Request, Guid UserId, string ImagePath), CreateProjectCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.ProjectImage, src => src.ImagePath)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Project, ProjectResponse>()
            .Map(dest => dest.ProjectId, src => src.Id.Value)
            .Map(dest => dest.PostId, src => src.PostId.Value)
            .Map(dest => dest.ProjectTitle, src => src.ProjectTitle)
            .Map(dest => dest.ProjectSrcLink, src => src.ProjectSrcLink)
            .Map(dest => dest.ProjectImage, src => src.ProjectImage)
            .Map(dest => dest.DisplayDate, src => src.DisplayDate)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.EndDate, src => src.EndDate);

        config.NewConfig<ProjectSection, ProjectSectionResponse>()
            .Map(dest => dest.ProjectSectionId, src => src.Id.Value)
            .Map(dest => dest.TopicId, src => src.TopicId.Value)
            .Map(dest => dest.TopicName, src => src.Topic.TopicName)
            .Map(dest => dest.ProjectTags, src => src.ProjectTags);

        config.NewConfig<ProjectTag, ProjectTagResponse>()
            .Map(dest => dest.ProjectTagId, src => src.Id.Value)
            .Map(dest => dest.TagId, src => src.TagId.Value)
            .Map(dest => dest.ProjectTagName, src => src.Tag.TagName);

    }
}
