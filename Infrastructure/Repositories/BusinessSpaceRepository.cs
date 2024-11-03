using Domain.Common;
using Domain.Entities;
using Domain.Repositories;


namespace Infrastructure.Repositories
{
    public class BusinessSpaceRepository : IBusinessSpaceRepository
    {
        public Task<Result<Guid>> AddAsync(BusinessSpace businessSpace)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BusinessSpace>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BusinessSpace> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BusinessSpace businessSpace)
        {
            throw new NotImplementedException();
        }
    }
}
