using MediatR;

namespace Sober.Application.Pages.UserInterests.Commands;

public record DeleteInterestCommand(Guid id, Guid userId) : IRequest<bool>;
