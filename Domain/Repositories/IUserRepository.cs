using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<Result<Guid>> AddAsync(User user);
        //Task<IEnumerable<User>> GetAllAsync();
        //Task<User> GetByIdAsync(Guid id);
        //Task UpdateAsync(User user);
        //Task DeleteAsync(Guid id);
    }
}
