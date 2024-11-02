


using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        public Task<Result<Guid>> AddAsync(Credential credential)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Credential>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Credential> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Credential credential)
        {
            throw new NotImplementedException();
        }
    }
}
