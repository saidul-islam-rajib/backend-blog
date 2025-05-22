using MediatR;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.Tags.Queries;

public record GetAllTagQuery
    : IRequest<IEnumerable<TagResponse>>
{
}
