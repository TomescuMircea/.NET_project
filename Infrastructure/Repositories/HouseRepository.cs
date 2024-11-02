


using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        public Task<Result<Guid>> AddAsync(House house)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<House>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<House> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(House house)
        {
            throw new NotImplementedException();
        }
    }
}
