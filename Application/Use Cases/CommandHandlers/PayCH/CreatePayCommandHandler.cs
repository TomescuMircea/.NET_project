using Application.Use_Cases.Commands.PayC;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers.PayCH
{
    public class CreatePayCommandHandler : IRequestHandler<CreatePayCommand, Result<Guid>>
    {
        private readonly IPayRepository repository;
        private readonly IMapper mapper;

        public CreatePayCommandHandler(IPayRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreatePayCommand request, CancellationToken cancellationToken)
        {
            var transact = mapper.Map<Pay>(request);
            var result = await repository.AddAsync(transact);
            return Result<Guid>.Success(result.Data);
        }
    }
}
