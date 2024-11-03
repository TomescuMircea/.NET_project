
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Result<Guid>.Success(user.Id);
        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<User>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<User> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(User user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
