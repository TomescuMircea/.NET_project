using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface ICredentialRepository
    {
        Task<Result<Guid>> AddAsync(Credential credential);
        //Task<IEnumerable<Credential>> GetAllAsync();
        //Task<Credential> GetByIdAsync(Guid id);
        //Task UpdateAsync(Credential credential);
        //Task DeleteAsync(Guid id);
    }
}
