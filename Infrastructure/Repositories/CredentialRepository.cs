using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class CredentialRepository : IGenericEntityRepository<Credential>
    {
        private readonly ApplicationDbContext context;
        public CredentialRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Credential credential)
        {
            try
            {
                await context.Credentials.AddAsync(credential);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(credential.UserId);
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

        public Task<IEnumerable<Credential>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Credential> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Guid>> UpdateAsync(Credential credential)
        {
            throw new NotImplementedException();
        }
    }
}
