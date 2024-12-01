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

        public GetEstatesPaginationByFilterQueryHandler(IGenericEntityRepository<Estate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<PagedResult<EstateDto>>> Handle(GetEstatesPaginationByFilterQuery request, CancellationToken cancellationToken)
        {
            var estates = await repository.GetAllAsync();
            var query = estates.AsQueryable();

            if (request.Name != default)
            {
                query = query.Where(e => e.Name.Contains(request.Name));
            }

            if (request.Address != default)
            {
                query = query.Where(e => e.Address.Contains(request.Address));
            }

            if (request.Type != default)
            {
                query = query.Where(e => e.Type.Contains(request.Type));
            }

            if (request.Size != default)
            {
                if (request.Size > 0)
                    query = query.Where(e => e.Size == request.Size);
                else
                    return Result<PagedResult<EstateDto>>.Failure("Invalid size value");
            }

            if (request.Price != default)
            {
                if (request.Price > 0)
                    query = query.Where(e => e.Price == request.Price);
                else
                    return Result<PagedResult<EstateDto>>.Failure("Invalid price value");
            }

            // Apply paging
            var pagedEstates = query.ApplyPaging(request.Page, request.PageSize);

            var estateDtos = mapper.Map<List<EstateDto>>(pagedEstates);

            var pagedResult = new PagedResult<EstateDto>(estateDtos, query.Count());

            return Result<PagedResult<EstateDto>>.Success(pagedResult);
        }
    }
}
