using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ApartmentRepository : IGenericEntityRepository<Apartment>
    {
        private readonly ApplicationDbContext context;
        public ApartmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Apartment apartment)
        {
            try
            {
                await context.Apartments.AddAsync(apartment);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(apartment.EstateId);
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

        public Task<IEnumerable<Apartment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Apartment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Guid>> UpdateAsync(Apartment apartment)
        {
            throw new NotImplementedException();
        }
    }
}
