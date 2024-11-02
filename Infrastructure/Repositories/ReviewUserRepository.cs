

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class ReviewUserRepository : IReviewUserRepository
    {
        public Task<Result<Guid>> AddAsync(ReviewUser reviewUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReviewUser> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReviewUser reviewUser)
        {
            throw new NotImplementedException();
        }
    }
}
