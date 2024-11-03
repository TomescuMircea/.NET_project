using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(Guid id);
    }
}
