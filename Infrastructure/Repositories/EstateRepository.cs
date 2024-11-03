using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class EstateRepository : IEstateRepository
    {
        private readonly ApplicationDbContext context;
        public EstateRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Estate estate)
        {
            try
            {
                await context.Estates.AddAsync(estate);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(estate.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException?.ToString() ?? ex.Message);
            }
        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Estate>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Estate> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(Estate estate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
