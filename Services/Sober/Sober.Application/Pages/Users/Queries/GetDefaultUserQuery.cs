using MediatR;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Application.Pages.Users.Queries;

public record GetDefaultUserQuery : IRequest<UserInformation>{}
public record GetUserByIdQuery(Guid userId): IRequest<User> { }
public record GetUserInformationByIdQuery(Guid userId): IRequest<UserInformation> { }
