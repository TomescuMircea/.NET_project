using Domain.Common;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPayRepository
    {
        Task<Result<Guid>> AddAsync(Pay pay);
        //Task<IEnumerable<Pay>> GetAllAsync();
        //Task<Pay> GetByIdAsync(Guid id);
        //Task UpdateAsync(Pay pay);
        //Task DeleteAsync(Guid id);
    }

}
