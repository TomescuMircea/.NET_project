
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        public Task<Result<Guid>> AddAsync(Report report)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Report>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
