using MediatR;
using Sober.Domain.Aggregates.PublicationAggregate;

namespace Sober.Application.Pages.Publications.Queries.Query;


public record GetPublicationByIdQuery(Guid publiationId) : IRequest<Publication>;
