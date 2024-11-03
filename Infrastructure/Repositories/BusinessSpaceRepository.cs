using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repositories
{
    public class BusinessSpaceRepository : IBusinessSpaceRepository
    {
        private readonly ApplicationDbContext context;
        public BusinessSpaceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(BusinessSpace businessSpace)
        {
            try
            {
                await context.BusinessSpaces.AddAsync(businessSpace);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(businessSpace.EstateId);
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

        //public Task<IEnumerable<BusinessSpace>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<BusinessSpace> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(BusinessSpace businessSpace)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
