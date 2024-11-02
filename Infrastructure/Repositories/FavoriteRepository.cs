

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        public Task<Result<Guid>> AddAsync(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Favorite>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Favorite favorite)
        {
            throw new NotImplementedException();
        }
    }
}
