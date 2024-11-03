using Domain.Common;
using Domain.Entities;
namespace Domain.Repositories
{
    public interface IBusinessSpaceRepository
    {
        Task<Result<Guid>> AddAsync(BusinessSpace businessSpace);
        //Task<IEnumerable<BusinessSpace>> GetAllAsync();
        //Task<BusinessSpace> GetByIdAsync(Guid id);
        //Task UpdateAsync(BusinessSpace businessSpace);
        //Task DeleteAsync(Guid id);
    }
}
