using FluentValidation;

namespace Sober.Application.Pages.Projects.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.ProjectTitle).NotEmpty();
        RuleFor(x => x.ProjectSummary).NotEmpty();
        RuleFor(x => x.ProjectSrcLink).NotEmpty();
        RuleFor(x => x.ProjectImage).NotEmpty();
        RuleFor(x => x.ProjectTopics)
            .ForEach(topic =>
            {
                topic.ChildRules(topicValidator =>
                {
                    topicValidator.RuleFor(t => t.TopicId).NotEmpty();
                    topicValidator.RuleFor(t => t.ProjectTags)
                    .ForEach(tag =>
                    {
                        tag.ChildRules(tagValidator =>
                        {
                            tagValidator.RuleFor(t => t.TagId).NotEmpty();
                        });
                    });
                });
            });
    }
}
