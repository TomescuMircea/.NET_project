using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class PayRepository : IGenericEntityRepository<Pay>
    {
        private readonly ApplicationDbContext context;
        public PayRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Pay pay)
        {
            try
            {
                await context.Pays.AddAsync(pay);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(pay.Id);
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

        public Task<IEnumerable<Pay>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pay> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Pay pay)
        {
            throw new NotImplementedException();
        }
    }
}