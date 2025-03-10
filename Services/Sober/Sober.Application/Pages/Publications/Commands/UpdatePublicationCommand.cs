using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.PublicationAggregate;

namespace Sober.Application.Pages.Publications.Commands;

public record UpdatePublicationCommand(
    Guid UserId,
    Guid PublicationId,
    string? Title,
    string? PublicationImage,
    string? Summary,
    string? JournalName,
    List<UpdatePublicationKeyCommand>? Keys,
    DateTime? Date) : IRequest<ErrorOr<Publication>>;


public record UpdatePublicationKeyCommand(string? Key);

