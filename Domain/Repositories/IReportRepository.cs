﻿using Domain.Common;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report> GetByIdAsync(Guid id);
        Task<Result<Guid>> AddAsync(Report report);
        Task UpdateAsync(Report report);
        Task DeleteAsync(Guid id);
    }
}