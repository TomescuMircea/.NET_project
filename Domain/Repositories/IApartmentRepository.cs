using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> GetAllAsync();
        Task<Apartment> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(Apartment apartment);
        Task UpdateAsync(Apartment apartment);
        Task DeleteAsync(Guid id);



    }
}
