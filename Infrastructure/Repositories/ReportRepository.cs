
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext context;
        public ReportRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Report report)
        {
            try
            {
                await context.Reports.AddAsync(report);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(report.Id);
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

        //public Task<IEnumerable<Report>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Report> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(Report report)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
