using Application.Use_Cases.Commands.EstateC;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.EstateCH
{
    public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateCommand>
    {
        private readonly IGenericEntityRepository<Estate> repository;
        private readonly IMapper mapper;

        public UpdateEstateCommandHandler(IGenericEntityRepository<Estate> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = mapper.Map<Estate>(request);
            return repository.UpdateAsync(estate);
        }
    }
}
