using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IReviewPropertyRepository
    {
        Task<Result<Guid>> AddAsync(ReviewProperty reviewProperty);
        //Task<IEnumerable<ReviewProperty>> GetAllAsync();
        //Task<ReviewProperty> GetByIdAsync(Guid id);
        //Task UpdateAsync(ReviewProperty reviewProperty);
        //Task DeleteAsync(Guid id);
    }
}
