using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserInformationAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.UserInformationAggregate;

public sealed class UserInformation : AggregateRoot<UserInformationId>
{
    public string Bio { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public User User { get; private set; } = null!;

    public string? UserName { get; private set; }
    public string? Email { get; private set; }

    private UserInformation(UserInformationId userInformationId, string bio, User user) : base(userInformationId)
    {
        Bio = bio;
        User = user;
        UserId = user.Id;
        UserName = user.Name;
        Email = user.Email;
    }

    public static UserInformation Create(string bio, User user)
    {
        UserInformation userInformation = new UserInformation(UserInformationId.CreateUnique(), bio, user);
        return userInformation;
    }

    public UserInformation()
    {
    }
}
