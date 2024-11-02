using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IReviewPropertyRepository
    {
        Task<IEnumerable<ReviewProperty>> GetAllAsync();
        Task<ReviewProperty> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(ReviewProperty reviewProperty);
        Task UpdateAsync(ReviewProperty reviewProperty);
        Task DeleteAsync(Guid id);
    }
}
