using Application.Use_Cases.Commands.BusinessSpaceC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.BusinessSpaceCH
{
    public class CreateBusinessSpaceCommandHandler : IRequestHandler<CreateBusinessSpaceCommand, Result<Guid>>
    {
        private readonly IGenericEntityRepository<BusinessSpace> repository;
        private readonly IMapper mapper;

        public CreateBusinessSpaceCommandHandler(IGenericEntityRepository<BusinessSpace> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateBusinessSpaceCommand request, CancellationToken cancellationToken)
        {
            var businessSpace = mapper.Map<BusinessSpace>(request);
            var result = await repository.AddAsync(businessSpace);
            if (result.IsSuccess)
            {
                return Result<Guid>.Success(result.Data);
            }
            return Result<Guid>.Failure(result.ErrorMessage);
        }
    }
}
