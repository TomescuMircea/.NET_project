

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ReviewUserRepository : IReviewUserRepository
    {
        private readonly ApplicationDbContext context;
        public ReviewUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(ReviewUser reviewUser)
        {
            await context.ReviewUsers.AddAsync(reviewUser);
            await context.SaveChangesAsync();
            return Result<Guid>.Success(reviewUser.Id);
        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<ReviewUser>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ReviewUser> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(ReviewUser reviewUser)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
