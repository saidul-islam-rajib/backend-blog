using MediatR;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.Tags.Queries;

public class GetTagsWithTopicsQuery : IRequest<IEnumerable<TagWithTopicResponse>>
{
}
