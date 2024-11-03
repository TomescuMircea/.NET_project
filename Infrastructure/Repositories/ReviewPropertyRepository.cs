

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ReviewPropertyRepository : IReviewPropertyRepository
    {
        private readonly ApplicationDbContext context;
        public ReviewPropertyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(ReviewProperty reviewProperty)
        {
            await context.ReviewProperties.AddAsync(reviewProperty);
            await context.SaveChangesAsync();
            return Result<Guid>.Success(reviewProperty.Id);
        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<ReviewProperty>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ReviewProperty> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(ReviewProperty reviewProperty)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
