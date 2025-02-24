using MediatR;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.Publications.Queries.Query;

public record GetPublicationQuery() : IRequest<IEnumerable<PublicationResponse>>
{ }
