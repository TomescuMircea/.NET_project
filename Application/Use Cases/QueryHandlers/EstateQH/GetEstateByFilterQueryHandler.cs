using Application.DTO;
using Application.Use_Cases.Queries.EstateQ;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.QueryHandlers.EstateQH
{
    public class GetEstateByFilterQueryHandler : IRequestHandler<GetEstateByFilterQuery, List<EstateDto>>
    {
        private readonly IGenericEntityRepository<Estate> repository;
        private readonly IMapper mapper;

        public GetEstateByFilterQueryHandler(IGenericEntityRepository<Estate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<EstateDto>> Handle(GetEstateByFilterQuery request, CancellationToken cancellationToken)
        {
            var estates = await repository.GetAllAsync();
            var filteredEstates = estates.AsQueryable();

            if (request.Address != default)
            {
                filteredEstates = filteredEstates.Where(e => e.Address == request.Address);
            }

            if (request.Type != default)
            {
                filteredEstates = filteredEstates.Where(e => e.Type == request.Type);
            }

            if (request.Size != default)
            {
                if (request.Size > 0)
                    filteredEstates = filteredEstates.Where(e => e.Size == request.Size);
                else
                    return null;
            }

            if (request.Price != default)
            {
                if (request.Price > 0)
                    filteredEstates = filteredEstates.Where(e => e.Price == request.Price);
                else
                    return null;
            }

            return mapper.Map<List<EstateDto>>(filteredEstates.ToList());
        }
    }
}
