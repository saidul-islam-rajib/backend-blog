using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Domain.Entities
{
    public record User
    {
        public UserId Id { get; init; } = UserId.CreateUnique();
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;

        private User(UserId id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            var user = new User(UserId.CreateUnique(), firstName, lastName, email, password);
            return user;                        
        }

        public User()
        {
        }
    }
}
