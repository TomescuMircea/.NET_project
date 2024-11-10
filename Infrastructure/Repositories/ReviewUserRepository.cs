using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ReviewUserRepository : IGenericEntityRepository<ReviewUser>
    {
        private readonly ApplicationDbContext context;
        public ReviewUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(ReviewUser reviewUser)
        {
            try
            {
                await context.ReviewUsers.AddAsync(reviewUser);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(reviewUser.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException!.ToString());
            }
        }

        public Task<Result<Guid>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReviewUser?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Guid>> UpdateAsync(ReviewUser reviewUser)
        {
            throw new NotImplementedException();
        }
    }
}
