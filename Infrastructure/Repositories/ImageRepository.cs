

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ImageRepository : IGenericEntityRepository<Image>
    {
        private readonly ApplicationDbContext context;
        public ImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Image image)
        {
            try
            {
                await context.Images.AddAsync(image);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(image.EstateId);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException!.ToString());
            }
        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<IEnumerable<Image>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //public Task<Image> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public Task UpdateAsync(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
