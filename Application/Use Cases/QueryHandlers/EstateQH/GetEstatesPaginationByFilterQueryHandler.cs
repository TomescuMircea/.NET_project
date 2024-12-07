using Application.DTO;
using Application.Use_Cases.Queries.EstateQ;
using Application.Utils;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Gridify;
using MediatR;

namespace Application.Use_Cases.QueryHandlers.EstateQH
{
    public class GetEstatesPaginationByFilterQueryHandler : IRequestHandler<GetEstatesPaginationByFilterQuery, Result<PagedResult<EstateDto>>>
    {
        private readonly IGenericEntityRepository<Estate> repository;
        private readonly IMapper mapper;
        private readonly List<IFilterStrategy> filterStrategies;

        public GetEstatesPaginationByFilterQueryHandler(IGenericEntityRepository<Estate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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
            var query = (await repository.GetAllAsync()).AsQueryable();

            foreach (var strategy in filterStrategies)
            {
                query = strategy.ApplyFilter(query, request);
            }

            // Apply paging
            var pagedEstates = query.ApplyPaging(request.Page, request.PageSize);

            var estateDtos = mapper.Map<List<EstateDto>>(pagedEstates);

            var pagedResult = new PagedResult<EstateDto>(estateDtos, query.Count());

            return Result<PagedResult<EstateDto>>.Success(pagedResult);
        }
    }
}


//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//using Application.DTO;
//using Application.Use_Cases.Queries.EstateQ;
//using Application.Utils;
//using AutoMapper;
//using Domain.Common;
//using Domain.Entities;
//using Domain.Repositories;
//using MediatR;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using System.Text;
//using System.Data;

//namespace Application.Use_Cases.QueryHandlers.EstateQH
//{
//    public class GetEstatesPaginationByFilterQueryHandler : IRequestHandler<GetEstatesPaginationByFilterQuery, Result<PagedResult<EstateDto>>>
//    {
//        private readonly IGenericEntityRepository<Estate> repository;
//        private readonly IMapper mapper;
//        private readonly DbContext dbContext;
//        private readonly List<IFilterStrategy> filterStrategies;

//        public GetEstatesPaginationByFilterQueryHandler(IGenericEntityRepository<Estate> repository, IMapper mapper, DbContext dbContext)
//        {
//            this.repository = repository;
//            this.mapper = mapper;
//            this.dbContext = dbContext;
//            filterStrategies = new List<IFilterStrategy>
//                    {
//                        new NameFilterStrategy(),
//                        new AddressFilterStrategy(),
//                        new TypeFilterStrategy(),
//                        new SizeFilterStrategy(),
//                        new PriceFilterStrategy()
//                    };
//        }

//        public async Task<Result<PagedResult<EstateDto>>> Handle(GetEstatesPaginationByFilterQuery request, CancellationToken cancellationToken)
//        {
//            var sqlQuery = new StringBuilder("SELECT * FROM Estates WHERE 1=1");

//            foreach (var strategy in filterStrategies)
//            {
//                strategy.ApplyFilter(sqlQuery, request);
//            }

//            sqlQuery.Append(" ORDER BY ListingData OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY");

//            var parameters = new List<SqlParameter>
//                    {
//                        new SqlParameter("@Offset", (request.Page - 1) * request.PageSize),
//                        new SqlParameter("@PageSize", request.PageSize)
//                    };

//            var estates = await dbContext.Set<Estate>()
//                .FromSqlRaw(sqlQuery.ToString(), parameters.ToArray())
//                .ToListAsync(cancellationToken);

//            var totalCount = await dbContext.Set<Estate>()
//                .FromSqlRaw("SELECT COUNT(*) FROM Estates WHERE 1=1")
//                .CountAsync(cancellationToken);

//            var estateDtos = mapper.Map<List<EstateDto>>(estates);

//            var pagedResult = new PagedResult<EstateDto>(estateDtos, totalCount);

//            return Result<PagedResult<EstateDto>>.Success(pagedResult);
//        }
//    }
//}