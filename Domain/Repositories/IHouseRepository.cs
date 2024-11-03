using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IHouseRepository
    {
        Task<Result<Guid>> AddAsync(House house);
        //Task<IEnumerable<House>> GetAllAsync();
        //Task<House> GetByIdAsync(Guid id);
        //Task UpdateAsync(House house);
        //Task DeleteAsync(Guid id);
    }
}
