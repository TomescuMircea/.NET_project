

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        public Task<Result<Guid>> AddAsync(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Apartment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Apartment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Apartment apartment)
        {
            throw new NotImplementedException();
        }
    }
}
