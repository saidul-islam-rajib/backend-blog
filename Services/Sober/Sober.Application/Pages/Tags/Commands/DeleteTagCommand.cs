using MediatR;

namespace Sober.Application.Pages.Tags.Commands;

public record DeleteTagCommand(Guid tagId) : IRequest<bool>;
