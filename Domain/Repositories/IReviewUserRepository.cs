using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IReviewUserRepository
    {
        Task<IEnumerable<ReviewUser>> GetAllAsync();
        Task<ReviewUser> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(ReviewUser reviewUser);
        Task UpdateAsync(ReviewUser reviewUser);
        Task DeleteAsync(Guid id);
    }
}
