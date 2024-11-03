using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class PayRepository : IPayRepository
    {
        private readonly ApplicationDbContext context;
        public PayRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Pay pay)
        {
            await context.Pays.AddAsync(pay);
            await context.SaveChangesAsync();
            return Result<Guid>.Success(pay.Id);
        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Pay>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Pay> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(Pay pay)
        //{
        //    throw new NotImplementedException();
        //}
    }
}