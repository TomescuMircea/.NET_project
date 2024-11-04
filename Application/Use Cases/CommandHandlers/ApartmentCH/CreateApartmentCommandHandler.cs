using Application.Use_Cases.Commands.ApartmentC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.ApartmentCH
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<Apartment> repository;
        private readonly IMapper mapper;

        public CreateApartmentCommandHandler(IGenericEntityRepository<Apartment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = mapper.Map<Apartment>(request);
            var result = await repository.AddAsync(apartment);
            if (result.IsSuccess)
            {
                return Result<Guid>.Success(result.Data);
            }
            return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
