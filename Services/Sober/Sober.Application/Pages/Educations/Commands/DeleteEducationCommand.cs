using MediatR;

namespace Sober.Application.Pages.Educations.Commands;

public record DeleteEducationCommand(Guid educationId, Guid userId) : IRequest<bool>;
