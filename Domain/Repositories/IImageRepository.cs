using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
   public interface IImageRepository
    {
        Task<Result<Guid>> AddAsync(Image image);
        //Task<IEnumerable<Image>> GetAllAsync();
        //Task<Image> GetByIdAsync(Guid id);
        //Task UpdateAsync(Image image);
        //Task DeleteAsync(Guid id);
    }
}
