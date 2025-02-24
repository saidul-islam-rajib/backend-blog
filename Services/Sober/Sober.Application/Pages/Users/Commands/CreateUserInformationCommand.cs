using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Application.Pages.Users.Commands;

public record CreateUserInformationCommand(Guid UserId, string UserBio)
    : IRequest<ErrorOr<UserInformation>>;