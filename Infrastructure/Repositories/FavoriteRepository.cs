

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : IGenericEntityRepository<Favorite>
    {
        private readonly ApplicationDbContext context;
        public FavoriteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Favorite favorite)
        {
            try
            {
                await context.Favorites.AddAsync(favorite);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(favorite.UserId);

            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException?.ToString() ?? ex.Message);
            }
        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Favorite>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Favorite> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(Favorite favorite)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
