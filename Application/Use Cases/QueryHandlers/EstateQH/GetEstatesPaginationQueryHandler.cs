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
    public class GetEstatesPaginationQueryHandler : IRequestHandler<GetEstatesPaginationQuery, Result<PagedResult<EstateDto>>>
    {
        private readonly IGenericEntityRepository<Estate> repository;
        private readonly IMapper mapper;

        public GetEstatesPaginationQueryHandler(IGenericEntityRepository<Estate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<PagedResult<EstateDto>>> Handle(GetEstatesPaginationQuery request, CancellationToken cancellationToken)
        {
            var estates = await repository.GetAllAsync();
            var query = estates.AsQueryable();

            // Apply paging
            var pagedEstates = query.ApplyPaging(request.Page, request.PageSize);

            var estateDtos = mapper.Map<List<EstateDto>>(pagedEstates);

            var pagedResult = new PagedResult<EstateDto>(estateDtos, query.Count());

            return Result<PagedResult<EstateDto>>.Success(pagedResult);
        }
    }
}
