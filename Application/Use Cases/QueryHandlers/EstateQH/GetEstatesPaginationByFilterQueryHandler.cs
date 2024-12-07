using Application.DTO;
using Application.Use_Cases.Queries.EstateQ;
using Application.Utils;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Use_Cases.QueryHandlers.EstateQH
{
    public class GetEstatesPaginationByFilterQueryHandler : IRequestHandler<GetEstatesPaginationByFilterQuery, Result<PagedResult<EstateDto>>>
    {
        private readonly IGenericEntityRepository<Estate> repository;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        private readonly List<IFilterStrategy> filterStrategies;

        public GetEstatesPaginationByFilterQueryHandler(IGenericEntityRepository<Estate> repository, IMapper mapper, ApplicationDbContext dbContext)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.dbContext = dbContext;
            filterStrategies = new List<IFilterStrategy>
                    {
                        new NameFilterStrategy(),
                        new AddressFilterStrategy(),
                        new TypeFilterStrategy(),
                        new SizeFilterStrategy(),
                        new PriceFilterStrategy()
                    };
        }

        public async Task<Result<PagedResult<EstateDto>>> Handle(GetEstatesPaginationByFilterQuery request, CancellationToken cancellationToken)
        {
            var sqlQuery = new StringBuilder("SELECT * FROM \"Estates\" WHERE 1=1");

            foreach (var strategy in filterStrategies)
            {
                strategy.ApplyFilter(sqlQuery, request);
            }

            var estates = await dbContext.Set<Estate>()
                .FromSqlRaw(sqlQuery.ToString())
                .ToListAsync(cancellationToken);

            var pagedEstates = estates.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            var estateDtos = mapper.Map<List<EstateDto>>(pagedEstates);

            var pagedResult = new PagedResult<EstateDto>(estateDtos, estates.Count);

            return Result<PagedResult<EstateDto>>.Success(pagedResult);
        }
    }
}