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
        public Task<Result<Guid>> AddAsync(Estate book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Estate> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Estate book)
        {
            throw new NotImplementedException();
        }
    }
}
