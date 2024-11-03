using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<Result<Guid>> AddAsync(Apartment apartment);
        //Task<IEnumerable<Apartment>> GetAllAsync();
        //Task<Apartment> GetByIdAsync(Guid id);
        //Task UpdateAsync(Apartment apartment);
        //Task DeleteAsync(Guid id);



    }
}
