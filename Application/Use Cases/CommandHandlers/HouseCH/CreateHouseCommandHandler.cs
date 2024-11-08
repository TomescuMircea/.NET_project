using Application.Use_Cases.Commands.HouseC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.HouseCH
{
    public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<House> repository;
        private readonly IMapper mapper;

        public CreateHouseCommandHandler(IGenericEntityRepository<House> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            var house = mapper.Map<House>(request);
            var result = await repository.AddAsync(house);
            if (result.IsSuccess)
            {
                return Result<Guid>.Success(result.Data);
            }
            return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
