using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Application.Use_Cases.Commands.EstateC;

namespace Application.Use_Cases.CommandHandlers.EstateCH
{
    public class CreateEstateCommandHandler : IRequestHandler<CreateEstateCommand, Result<Guid>>
    {
        private readonly IEstateRepository repository;
        private readonly IMapper mapper;

        public CreateEstateCommandHandler(IEstateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = mapper.Map<Estate>(request);
            return await repository.AddAsync(estate);
        }
    }
}
