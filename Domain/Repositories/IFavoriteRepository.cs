using Domain.Common;
using Domain.Entities;



namespace Domain.Repositories
{
    public interface IFavoriteRepository
    {
        Task<Result<Guid>> AddAsync(Favorite favorite);
        //Task<IEnumerable<Favorite>> GetAllAsync();
        //Task<Favorite> GetByIdAsync(Guid id);
        //Task UpdateAsync(Favorite favorite);
        //Task DeleteAsync(Guid id);
    }
}
