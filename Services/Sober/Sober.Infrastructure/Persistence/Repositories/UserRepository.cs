using Microsoft.EntityFrameworkCore;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogDbContext _dbContext;

        public UserRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            //return _users.SingleOrDefault(x => x.Email == email);
            var response = _dbContext.Users.SingleOrDefault(x => x.Email == email);
            return response;
        }

        public async Task<UserInformation> GetDefaultUser()
        {
            UserInformation? user = await _dbContext.UserInformations.Include(x => x.User).FirstOrDefaultAsync();
            return user;
        }
                
        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(new UserId(userId)));
            return user;
        }

        public void CreateUserInformation(UserInformation userInformation)
        {
            _dbContext.UserInformations.Add(userInformation);
            _dbContext.SaveChangesAsync();
        }

        public async Task<UserInformation> GetUserInformationByUserIdAsync(Guid userId)
        {
            UserInformation? user = await _dbContext.UserInformations.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId.Equals(new UserId(userId)));
            if(user is null)
            {
                throw new Exception("User Information is not found!");
            }

            return user;
        }
    }
}
