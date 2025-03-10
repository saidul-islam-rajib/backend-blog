using MediatR;

namespace Sober.Application.Pages.Publications.Commands;

public record DeletePublicationCommand(Guid publicationId, Guid userId) : IRequest<bool>;
