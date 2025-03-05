using MediatR;

namespace Sober.Application.Pages.Experiences.Commands;

public record DeleteExperienceCommand(Guid experienceId, Guid userId) : IRequest<bool>;
