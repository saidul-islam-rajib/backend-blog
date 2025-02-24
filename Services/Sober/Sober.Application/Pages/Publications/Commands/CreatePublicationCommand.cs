using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.PublicationAggregate;

namespace Sober.Application.Pages.Publications.Commands;

public record CreatePublicationCommand
(
    Guid UserId,
    string Title,
    string PublicationImage,
    string Summary,
    List<PublicationKeyCommand> Keys,
    string JournalName,
    DateTime Date
) : IRequest<ErrorOr<Publication>>;

public record PublicationKeyCommand(string Key);
