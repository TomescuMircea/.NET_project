using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IReviewUserRepository
    {
        Task<Result<Guid>> AddAsync(ReviewUser reviewUser);
        //Task<IEnumerable<ReviewUser>> GetAllAsync();
        //Task<ReviewUser> GetByIdAsync(Guid id);
        //Task UpdateAsync(ReviewUser reviewUser);
        //Task DeleteAsync(Guid id);
    }
}
