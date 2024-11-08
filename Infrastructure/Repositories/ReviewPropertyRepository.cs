

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Repositories
{
    public class ReviewPropertyRepository : IGenericEntityRepository<ReviewProperty>
    {
        private readonly ApplicationDbContext context;
        public ReviewPropertyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(ReviewProperty reviewProperty)
        {
            try
            {
                await context.ReviewProperties.AddAsync(reviewProperty);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(reviewProperty.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException!.ToString());
            }
        }

        public Task<IEnumerable<ReviewProperty>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReviewProperty reviewProperty)
        {
            throw new NotImplementedException();
        }
    }
}
