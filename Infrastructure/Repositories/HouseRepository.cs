using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class HouseRepository : IGenericEntityRepository<House>
    {
        private readonly ApplicationDbContext context;
        public HouseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(House house)
        {
            try
            {
                await context.Houses.AddAsync(house);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(house.EstateId);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException!.ToString());
            }
        }

        public Task<Result<Guid>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<House>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<House> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(House house)
        {
            throw new NotImplementedException();
        }
    }
}
