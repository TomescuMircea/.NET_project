using Domain.Common;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEstateRepository
    {
        Task<IEnumerable<Estate>> GetAllAsync();
        Task<Estate> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(Estate estate);
        Task UpdateAsync(Estate estate);
        Task DeleteAsync(Guid id);
    }
}
