using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string Name { get; } = null!;
        public string Email { get; } = null!;
        public string Password { get; } = null!;

        private User(
            UserId userId,
            string name,
            string email,
            string password) : base(userId)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public static User Create(
            string name,
            string email,
            string password)
        {
            User user = new User(
                UserId.CreateUnique(),
                name,
                email,
                password);
            return user;
        }

        public User()
        {
        }
    }
}
