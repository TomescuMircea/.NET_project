

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class ReviewPropertyRepository : IReviewPropertyRepository
    {
        public Task<Result<Guid>> AddAsync(ReviewProperty reviewProperty)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewProperty>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReviewProperty> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReviewProperty reviewProperty)
        {
            throw new NotImplementedException();
        }
    }
}
