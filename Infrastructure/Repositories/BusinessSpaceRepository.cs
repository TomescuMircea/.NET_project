﻿using Domain.Common;
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
            await context.BusinessSpaces.AddAsync(businessSpace);
            await context.SaveChangesAsync();
            return Result<Guid>.Success(businessSpace.EstateId);
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