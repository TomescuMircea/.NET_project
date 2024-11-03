

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public Task<Result<Guid>> AddAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
