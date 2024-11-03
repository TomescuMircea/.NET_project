using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IContactRepository
    {
        Task<Result<Guid>> AddAsync(Contact contact);
        //Task<IEnumerable<Contact>> GetAllAsync();
        //Task<Contact> GetByIdAsync(Guid id);
        //Task UpdateAsync(Contact contact);
        //Task DeleteAsync(Guid id);
    }
}
