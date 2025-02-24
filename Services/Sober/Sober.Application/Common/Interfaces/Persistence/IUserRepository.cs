using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<UserInformation> GetDefaultUser();
    User? GetUserByEmail(string email);
    void Add(User user);
    Task<User> GetUserByIdAsync(Guid userId);
    Task<UserInformation> GetUserInformationByUserIdAsync(Guid userId);
    void CreateUserInformation(UserInformation userInformation);
}
