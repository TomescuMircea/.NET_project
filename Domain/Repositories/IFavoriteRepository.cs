using Domain.Common;
using Domain.Entities;



namespace Domain.Repositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllAsync();
        Task<Favorite> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(Favorite favorite);
        Task UpdateAsync(Favorite favorite);
        Task DeleteAsync(Guid id);
    }
}
