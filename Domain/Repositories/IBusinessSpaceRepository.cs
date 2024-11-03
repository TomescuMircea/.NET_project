using Domain.Common;
using Domain.Entities;
namespace Domain.Repositories
{
    public interface IBusinessSpaceRepository
    {
        Task<IEnumerable<BusinessSpace>> GetAllAsync();
        Task<BusinessSpace> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(BusinessSpace businessSpace);
        Task UpdateAsync(BusinessSpace businessSpace);
        Task DeleteAsync(Guid id);
    }
}
