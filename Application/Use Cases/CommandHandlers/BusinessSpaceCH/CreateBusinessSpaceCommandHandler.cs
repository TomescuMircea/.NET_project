using Application.Use_Cases.Commands.BusinessSpaceC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Use_Cases.CommandHandlers.BusinessSpaceCH
{
    public class CreateBusinessSpaceCommandHandler
    {
        private readonly IBusinessSpaceRepository repository;
        private readonly IMapper mapper;

        public CreateBusinessSpaceCommandHandler(IBusinessSpaceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateBusinessSpaceCommand request, CancellationToken cancellationToken)
        {
            var businessSpace = mapper.Map<BusinessSpace>(request);
            return await repository.AddAsync(businessSpace);
        }
    }
}
